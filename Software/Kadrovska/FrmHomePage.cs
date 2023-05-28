using Kadrovska.Auth;
using System;
using System.Windows.Forms;

namespace Kadrovska
{
    public partial class FrmHomePage : Form
    {
        /// <summary>
        /// Standardni konstruktor za Forme
        /// </summary>
        public FrmHomePage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Ova metoda se pokreće kada se ova forma prvi puta pokrene
        /// Postavlja labelu za dobrodošlicu da uključuje vaše ime :D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmHomePage_Load(object sender, EventArgs e)
        {
            string strName = LocalAuthentificationHandler.GetUserInfo().GivenName;
            m_lblWelcome.Text += $"{strName}";
        }
        /// <summary>
        /// U budučnosti će ovaj gumb slati na vaš mail podatke koje o vama spremimo
        /// No, za ovaj prototip, pošto nije dio Use Case-a, nije implementirano
        /// Te otvori skočni prozor koji vas o tome obavijesti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void btnGDPR_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Ova funkcionalnost nije dio prototipa.", "Upozorenje", MessageBoxButtons.OK);
		}
	}
}
