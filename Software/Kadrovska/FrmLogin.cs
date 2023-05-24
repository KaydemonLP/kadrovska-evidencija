using Evaluation_Manager.models;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Util.Store;
using Kadrovska;
using Kadrovska.Auth;
using System;
using System.Security.AccessControl;
using System.Threading;
using System.Windows.Forms;

namespace Evaluation_Manager
{
    public partial class FrmLogin : Form
    {
        public static FrmLogin Main;
        public FrmLogin()
        {
            Main = this;
            InitializeComponent();
        }

        public static CTeacher m_LoggedTeacher {
            get; set;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LocalAuthentificationHandler.StartGoogleAuthentificationProcess();
        }

        public void OnCredentialsLoaded()
        {
            FrmHomePage frmHomePage = new FrmHomePage();
            Hide();
            frmHomePage.ShowDialog();
            Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            LocalAuthentificationHandler.ClearUserCredentialFiles();
        }
    }
}
