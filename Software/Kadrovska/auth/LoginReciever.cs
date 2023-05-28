using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kadrovska.Auth
{
    public class CLoginReciever : ICodeReceiver
    {
        public string RedirectUri
        {
            get; set;
        }

        private static HttpListener m_ResponseListener = null;

        private readonly string m_strClosePageResponse =
        @"<html>
          <head><title>Zavrsetak</title></head>
          <body>
            Verifikacija uspjesna, smijete zatvoriti ovaj prozor.
          </body>
        </html>";
        /// <summary>
        /// Konstruktor
        /// Kada se ova klasa kreira, želimo generirati povratnu vezu
        /// Za to posluškivamo portove i koristimo prvi otvoreni
        /// </summary>
        public CLoginReciever()
        {
            RedirectUri = $"http://localhost:{GetRandomUnusedPort()}/authorize/";
        }
        /// <summary>
        /// Metoda koja posluškiva portove kroz TCP listener i vraća prvi otvoreni port
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Pretvori naš string za HTML stranicu koja se vraća nakon uspješne prijave u bajte
        /// koji se mogu prenositi korisniku
        /// </summary>
        /// <returns></returns>
        private byte[] GetResponseStringAsBytes()
        {
            return Encoding.UTF8.GetBytes(m_strClosePageResponse);
        }
		/// <summary>
		/// Pokreće nas prisluškivač odgovora
		/// Kada nam google vraća odgovor na "RedirectUri" ovaj prisluškivać to detektira
		/// </summary>
		/// <exception cref="Exception"></exception>
		private void StartListener()
        {
            if (m_ResponseListener != null)
                return;

            try
            {
                m_ResponseListener = new HttpListener();
                m_ResponseListener.Prefixes.Add(RedirectUri);
                m_ResponseListener.Start();
            }
            catch
            {
                m_ResponseListener = null;
                // Fail
                throw new Exception("Nije bilo moguce pokrenut http slusatelj, provjerite privilegije, portove i postavke Firewall-a, i pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Ova metoda se poziva od strane GoogleAPI-ja kada započinje upit
        /// Ona započinje prisluškivač i otvara nam browser
        /// Na kraju započinje Wait metodu i čeka na odgovor
        /// </summary>
        /// <param name="url"></param>
        /// <param name="taskCancellationToken"></param>
        /// <returns></returns>
        public async Task<AuthorizationCodeResponseUrl> ReceiveCodeAsync(AuthorizationCodeRequestUrl url,
            CancellationToken taskCancellationToken)
        {
            var authorizationUrl = url.Build().AbsoluteUri;
            LocalAuthentificationHandler.m_strAuthUrlFull = authorizationUrl;

            StartListener();

            Process.Start(authorizationUrl);
            FrmLogin.SetStatusText("Otvaranje pretrazivaca...");

            var ret = await GetResponseFromListener(m_ResponseListener, taskCancellationToken).ConfigureAwait(false);

            return ret;
        }
		/// <summary>
		/// Ova metoda rukova čekanjem na odgovor, slanje povratne stranice te obradom odgovora
		/// Dretva stoji na listener.GetContextAsync().ConfigureAwait(false) sve dok se korisnik ne prijavi
		/// </summary>
		/// <param name="listener"></param>
		/// <param name="cancelationToken"></param>
		/// <returns></returns>
		private async Task<AuthorizationCodeResponseUrl> GetResponseFromListener(HttpListener listener, CancellationToken cancelationToken)
        {
            HttpListenerContext comunicationHandler;

            // "Using" postavi da se Registration klasa briše nakon izvođenja ovog dijela koda 
            using( cancelationToken.Register(listener.Stop) )
            {
               comunicationHandler = await listener.GetContextAsync().ConfigureAwait(false);
            }
            FrmLogin.SetStatusText("Odgovor primljen! Otvaranje formi...", FrmLogin.StatusType.Success);
            NameValueCollection query = comunicationHandler.Request.QueryString;

            // Write a "close" response.
            SendHTMLResponseToUser(comunicationHandler);

            // Create a new response URL with a dictionary that contains all the response query parameters.
            return new AuthorizationCodeResponseUrl(query.AllKeys.ToDictionary(k => k, k => query[k]));
        }

        private void SendHTMLResponseToUser(HttpListenerContext communicationtHandler)
        {
            var bytes = GetResponseStringAsBytes();

            communicationtHandler.Response.ContentLength64 = bytes.Length;
            communicationtHandler.Response.SendChunked = false;
            communicationtHandler.Response.KeepAlive = false;

            var output = communicationtHandler.Response.OutputStream;
            output.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
            output.FlushAsync().ConfigureAwait(false);
            output.Close();

            communicationtHandler.Response.Close();
        }
    }
}
