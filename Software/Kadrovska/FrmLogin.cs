using System;
using Kadrovska.Auth;
using System.Windows.Forms;
using Kadrovska.repositories;
using System.Drawing;

namespace Kadrovska
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
        /// <summary>
        /// Ovu metodu poziva AuthHandler tijekom obrade prijave
        /// Postavlja text statusnog Label-a, te ovisno o vrsti
        /// postavlja i boju
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="type"></param>
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
        /// <summary>
        /// Konstruktor
        /// Postavlja statičnu varijablu "Main" na "this" kako bi druge klase
        /// mogle koristiti ovu formu bez da je spremimo untar njih.
        /// </summary>
        public FrmLogin()
        {
            Main = this;
            InitializeComponent();
        }
        /// <summary>
        /// Metoda koja se pokrene kada kliknemo tipku login
        /// Poziva klasu Autentification Managera da započinje process autentifikacije
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LocalAuthentificationHandler.StartGoogleAuthentificationProcess();
        }

        /// <summary>
        /// Nakon prijave, ako korisnik ne postoji, dodajemo ga u sistem
        /// U ovom prototipu, korisnik se automatski smatra Radnikom
        /// U završnom programu, administrator bi ih prvo trebao potvrditi
        /// </summary>
        private void InsertUserIfNotExistYet()
        {
            if (KorisnikRepository.GetUser(LocalAuthentificationHandler.GetUserInfo().Subject) == null)
				KorisnikRepository.InsertUser(LocalAuthentificationHandler.GetLocalCredential(), LocalAuthentificationHandler.GetUserInfo());
        }

        /// <summary>
        /// Autentification manager pokreće ovu metodu kada je potvrđen vaš korisnički račun
        /// </summary>
        public void OnCredentialsLoaded()
        {
            FrmMainContainer frmMainContainer = new FrmMainContainer();
            InsertUserIfNotExistYet();

            Hide();
            frmMainContainer.ShowDialog();
            Close();
        }

        /// <summary>
        /// Ova metoda se poziva kada se forma prvo učita
        /// Ona poziva metodu Autentification Managera koja obriše postojeće zapise prijašnjih prijava
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            LocalAuthentificationHandler.ClearUserCredentialFiles();
        }
    }
}
