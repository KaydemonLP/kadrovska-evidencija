using Evaluation_Manager;
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
    public partial class FrmMainContainer : Form
    {
        private int m_iActiveIndex;

        List<Form> m_aFormList;
        List<Button> m_aNavButtonList;

        // 
        // 
        // 
        // 

        Color colNavButton = Color.FromArgb(255, 105, 92, 142);
        Color colNavButtonSelected = Color.FromArgb(90, 76, 130);
        Color colNavButtonHover = Color.FromArgb(68, 56, 102);
        Color colNavButtonPress = Color.FromArgb(90, 76, 130);

        public FrmMainContainer()
        {
            InitializeComponent();

            // Mora se napraviti nakon Initialise Component tako da se
            // FrmMainContainer može postaviti na "IsMdiParent"

            m_aFormList = new List<Form>();
            // Fill with null first
            for (int i = 0; i < 6; i++)
                m_aFormList.Add(null);

            m_aFormList[0] = new FrmHomePage();
            m_aFormList[1] = new FrmMyRequests();


			for (int i = 0; i < 6; i++)
            {
                if (m_aFormList[i] == null)
                    continue;

                m_aFormList[i].MdiParent = this;
                m_aFormList[i].Dock = DockStyle.Fill;
            }
            
            m_aNavButtonList = new List<Button>
            {
                btnHome,
                btnMyRequests,
                btnProfile,
                btnIncomingRequests,
                btnUsers,
                btnRecord
            };
        }

        private void FrmMainContainer_Load(object sender, EventArgs e)
        {
            //Display the child window
            m_iActiveIndex = 0;
            m_aFormList[m_iActiveIndex].Show();
        }

        private void FrmMainContainer_NavClick(object sender, EventArgs e)
        {
            int iIndex = ((Button)sender).TabIndex;
            if( m_aFormList[iIndex] == null )
                return;

            if( iIndex == m_iActiveIndex )
                return;

            m_aFormList[m_iActiveIndex].Hide();
            m_aFormList[iIndex].Show();

            m_aNavButtonList[m_iActiveIndex].BackColor = colNavButton;
            m_aNavButtonList[m_iActiveIndex].FlatAppearance.MouseOverBackColor = colNavButtonHover;
            m_aNavButtonList[m_iActiveIndex].FlatAppearance.MouseDownBackColor = colNavButtonPress;

            m_iActiveIndex = iIndex;

            m_aNavButtonList[m_iActiveIndex].BackColor = colNavButtonSelected;
            m_aNavButtonList[m_iActiveIndex].FlatAppearance.MouseOverBackColor = colNavButtonSelected;
            m_aNavButtonList[m_iActiveIndex].FlatAppearance.MouseDownBackColor = colNavButtonSelected;
        }
    }
}
