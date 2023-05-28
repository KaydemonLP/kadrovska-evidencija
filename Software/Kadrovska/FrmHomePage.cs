using Kadrovska.Auth;
using System;
using System.Windows.Forms;

namespace Kadrovska
{
    public partial class FrmHomePage : Form
    {
        public FrmHomePage()
        {
            InitializeComponent();
        }

        private void FrmHomePage_Load(object sender, EventArgs e)
        {
            string strName = LocalAuthentificationHandler.GetUserInfo().GivenName;
            m_lblWelcome.Text += $"{strName}";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		private void btnGDPR_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Ova funkcionalnost nije dio prototipa.", "Upozorenje", MessageBoxButtons.OK);
		}
	}
}
