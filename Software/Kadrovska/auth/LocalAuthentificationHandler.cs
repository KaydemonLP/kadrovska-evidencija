using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Util.Store;
using System;
using System.Diagnostics;
using System.Threading;

namespace Kadrovska.Auth
{
    public static class LocalAuthentificationHandler
    {
        private readonly static string m_strClientID = "124344079041-c391ah5vts0jild1r3kq2cslnnqd1k7f.apps.googleusercontent.com";
        private readonly static string m_strClientSecret = "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";
        private readonly static string m_strLocalUserName = "user";

        private static UserCredential m_Credential = null;
        private static GoogleJsonWebSignature.Payload m_UserInfo = null;
        private static FileDataStore m_FileDataStore = new FileDataStore($"{Program.g_strAppDataFolder}/{Program.g_strAuthFolder}");
        private static CLoginReciever m_Receiver = new CLoginReciever();
        private static bool m_bStarted = false;


        public static string m_strAuthUrlFull = "";

        private static String []GetScopes()
        {
            String[] scopes =
{
                    "openid profile email"
                };

            return scopes;
        }

        private static ClientSecrets GetClientSecrets() 
        {
            ClientSecrets secrets = new ClientSecrets();
            secrets.ClientId = m_strClientID;
            secrets.ClientSecret = m_strClientSecret;

            var initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = secrets,
            };

            return secrets;
        }

        public static UserCredential GetLocalCredential()
        {
            return m_Credential;
        }

        public static GoogleJsonWebSignature.Payload GetUserInfo()
        {
            return m_UserInfo;
        }
        public static void ClearActiveUserCredential()
        {
            m_Credential = null;
        }

        public static void ClearUserCredentialFiles()
        {
            m_FileDataStore.ClearAsync();
        }

        /// <summary>
        /// Započinje process autorizacije u posebnoj dretvi
        /// Kada je autorizacija završena, obavjesti 
        /// </summary>
        public static void StartGoogleAuthentificationProcess()
        {
            // Ne radi ništa ako već imamo podatke
            if( m_Credential != null )
                return;

            // Već ćekamo na unos, samo otvori browser
            if( m_bStarted )
            {
                // Ako nemamo još url, onda korisni pre-brzo klika, ignoriraj
                if( m_strAuthUrlFull == "" )
                    return;

                FrmLogin.SetStatusText("Otvaranje pretrazivaca...");
                Process.Start(m_strAuthUrlFull);
                return;
            }

            m_bStarted = true;

            FrmLogin.SetStatusText("Pokretanje...");

            // Inače, pokreni novi threat i započni listener
            ThreadPool.QueueUserWorkItem((state) =>
            {
                try
                {
                    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync
                        (
                        GetClientSecrets(),
                        GetScopes(),
                        m_strLocalUserName,
                        CancellationToken.None, m_FileDataStore, m_Receiver).Result;

                    m_Credential = credential;

                    TokenResponse token = m_Credential.Token;
                    m_UserInfo = GoogleJsonWebSignature.ValidateAsync(token.IdToken).Result;
                }
                catch( Exception status )
                {
                    string strMessage = status.InnerException.Message;
                    
                    if( strMessage == "" )
                        strMessage = "Dogodila se pogreska tjekom obrade vaseg zahtjeva, molimo vas pokusajte ponovo.";
                    
                    FrmLogin.SetStatusText(strMessage, FrmLogin.StatusType.Error);
                    return;
                }
                finally
                {
                    m_strAuthUrlFull = "";
                    m_bStarted = false;
                }

                FrmLogin.Main.Invoke(new Action(FrmLogin.Main.OnCredentialsLoaded));
            });
        }
    }
}
