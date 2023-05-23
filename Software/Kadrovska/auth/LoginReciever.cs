using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Logging;
using Google.Apis.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kadrovska.Auth
{
    public class CLoginReciever : ICodeReceiver
    {
        public CLoginReciever()
        {
            RedirectUri = $"http://localhost:{GetRandomUnusedPort()}/authorize/";
        }

        // Close page response for this instance.
        private readonly string m_strClosePageResponse =
        @"<html>
          <head><title>OAuth 2.0 Authentication Token Received</title></head>
          <body>
            Received verification code. You may now close this window.
            <script type='text/javascript'>
              // This doesn't work on every browser.
              window.setTimeout(function() {
                  this.focus();
                  window.opener = this;
                  window.open('', '_self', ''); 
                  window.close(); 
                }, 1000);
              //if (window.opener) { window.opener.checkToken(); }
            </script>
          </body>
        </html>";

        // There is a race condition on the port used for the loopback callback.
        // This is not good, but is now difficult to change due to RedirectUri and ReceiveCodeAsync
        // being public methods.

        public string RedirectUri
        {
            get; set;
        }

        Process m_Browser = null;

        public async Task<AuthorizationCodeResponseUrl> ReceiveCodeAsync(AuthorizationCodeRequestUrl url,
            CancellationToken taskCancellationToken)
        {
            var authorizationUrl = url.Build().AbsoluteUri;
            var listener = StartListener();

            m_Browser = Process.Start(authorizationUrl);
            m_Browser.Exited += (object sender,EventArgs e) => {
                listener.Stop();
            };

            var ret = await GetResponseFromListener(listener, taskCancellationToken).ConfigureAwait(false);

            return ret;
        }

        private static int GetRandomUnusedPort()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            try
            {
                listener.Start();
                return ((IPEndPoint)listener.LocalEndpoint).Port;
            }
            finally
            {
                listener.Stop();
            }
        }


        private HttpListener StartListener()
        {
            try
            {
                var listener = new HttpListener();
                listener.Prefixes.Add(RedirectUri);
                listener.Start();
                return listener;
            }
            catch
            {
                // Fail
                throw;
            }
        }

        private async Task<AuthorizationCodeResponseUrl> GetResponseFromListener(HttpListener listener, CancellationToken ct)
        {
            HttpListenerContext context;
            using (ct.Register(listener.Stop))
            {
                // Wait to get the authorization code response.
                try
                {
                    context = await listener.GetContextAsync().ConfigureAwait(false);
                }
                catch (Exception) when (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                    // Next line will never be reached because cancellation will always have been requested in this catch block.
                    // But it's required to satisfy compiler.
                    throw new InvalidOperationException();
                }
                catch (Exception) when (m_Browser == null)
                {

                    throw;
                }

            }
            NameValueCollection coll = context.Request.QueryString;

            // Write a "close" response.
            var bytes = Encoding.UTF8.GetBytes(m_strClosePageResponse);
            context.Response.ContentLength64 = bytes.Length;
            context.Response.SendChunked = false;
            context.Response.KeepAlive = false;
            var output = context.Response.OutputStream;
            await output.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
            await output.FlushAsync().ConfigureAwait(false);
            output.Close();
            context.Response.Close();

            // Create a new response URL with a dictionary that contains all the response query parameters.
            return new AuthorizationCodeResponseUrl(coll.AllKeys.ToDictionary(k => k, k => coll[k]));
        }
    }
}
