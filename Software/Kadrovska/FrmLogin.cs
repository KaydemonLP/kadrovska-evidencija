using System;
using Evaluation_Manager.models;
using Kadrovska;
using Kadrovska.Auth;
using System.Windows.Forms;
using Evaluation_Manager.repositories;
using System.Drawing;

namespace Evaluation_Manager
{
    public partial class FrmLogin : Form
    {
        public static FrmLogin Main;
        public enum StatusType
        {
            Info,
            Success,
            Error
        }

        public static void SetStatusText( string strText, StatusType type = StatusType.Info )
        {
            Main.Invoke(new Action( () => 
            {
                switch( type )
                {
                    default:
                    case StatusType.Info:
                        Main.lblStatus.ForeColor = Color.FromArgb(255, 0, 0, 0);
                        break;
                    case StatusType.Success:
                        Main.lblStatus.ForeColor = Color.FromArgb(255, 0, 255, 0);
                        break;
                    case StatusType.Error:
                        Main.lblStatus.ForeColor = Color.FromArgb(255, 255, 0, 0);
                        break;
                }

                Main.lblStatus.Text = strText; 
            }));
        }

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
