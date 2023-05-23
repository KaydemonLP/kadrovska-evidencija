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
    public partial class FrmWebInfo : Form
    {
        public void SetText(string text)
        {
            debug.Text = text;
        }
        public FrmWebInfo()
        {
            InitializeComponent();
        }

        private void FrmWebInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
