using Kadrovska.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kadrovska
{
    public partial class FrmMyRequests : Form
    {
        public FrmMyRequests()
        {
            InitializeComponent();
        }

        private void FrmMyRequests_Load(object sender, EventArgs e)
        {
            string strName = LocalAuthentificationHandler.GetUserInfo().GivenName;
            m_lblWelcome.Text += $"{strName}";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
