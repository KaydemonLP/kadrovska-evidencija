using System;
using Evaluation_Manager.models;
using Kadrovska;
using Kadrovska.Auth;
using System.Windows.Forms;
using Evaluation_Manager.repositories;

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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LocalAuthentificationHandler.StartGoogleAuthentificationProcess();
        }

        private void InsertUserIfNotExistYet()
        {
            if (KorisnikRepository.GetUser(LocalAuthentificationHandler.GetUserInfo().Subject) == null)
				KorisnikRepository.InsertUser(LocalAuthentificationHandler.GetLocalCredential(), LocalAuthentificationHandler.GetUserInfo());
        }

        public void OnCredentialsLoaded()
        {
            FrmMainContainer frmMainContainer = new FrmMainContainer();
            InsertUserIfNotExistYet();

            Hide();
            frmMainContainer.ShowDialog();
            Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            LocalAuthentificationHandler.ClearUserCredentialFiles();
        }
    }
}
