using Evaluation_Manager.models;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Util.Store;
using Kadrovska.Auth;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Evaluation_Manager
{
    public partial class FrmLogin : Form
    {
        public static FrmLogin Default = null;
        public FrmLogin()
        {
            Default = this;
            InitializeComponent();
        }

        public static CTeacher m_LoggedTeacher {
            get; set;
        }

        UserCredential m_Credential = null;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem((state) =>
            {
                ClientSecrets secrets = new ClientSecrets();
                secrets.ClientId = "124344079041-c391ah5vts0jild1r3kq2cslnnqd1k7f.apps.googleusercontent.com";
                secrets.ClientSecret = "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";

                var initializer = new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = secrets,
                };

                String[] scopes =
                {
                    "openid profile email"
                };

                CLoginReciever receiver = new CLoginReciever();

                try
                {
                    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync
                        (
                        secrets,
                        scopes,
                        "user",
                        CancellationToken.None, new FileDataStore("kadrovska.evidencija"), receiver).Result;

                    m_Credential = credential;
                }
                catch
                {
                    throw;
                }

                OnCredentialsLoaded();
            });
        }

        public void OnCredentialsLoaded()
        {
            TokenResponse token = m_Credential.Token;
            var payload = GoogleJsonWebSignature.ValidateAsync(token.IdToken).Result;
            string email = payload.Email;

            label1.Invoke(new Action(() =>
            {
                //label1.Text = token.AccessToken;
            }));

            label2.Invoke(new Action(() =>
            {
                label2.Text = email;
            }));
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
