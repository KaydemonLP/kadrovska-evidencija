using System;
using System.Windows.Forms;
using Evaluation_Manager.repositories;
using Evaluation_Manager.staticrepositories;
using Kadrovska.Auth;
using Kadrovska.models;

namespace Kadrovska
{
    public partial class FrmMyRequests : Form
    {
        public FrmMyRequests()
        {
            InitializeComponent();
        }

        private void ReSupplyRequestData()
        {
			string strAuthCode = LocalAuthentificationHandler.GetUserInfo().Subject;
			int iUserID = KorisnikRepository.GetUser(strAuthCode).m_iID;
			var requests = ZahtjevRepository.GetRequests(iUserID);
			dgvZahtjevi.DataSource = requests;

			dgvZahtjevi.Columns["m_iID"].DisplayIndex = 0;
			dgvZahtjevi.Columns["m_datCreationTime"].DisplayIndex = 1;
			dgvZahtjevi.Columns["m_iType"].DisplayIndex = 2;
			dgvZahtjevi.Columns["m_datStart"].DisplayIndex = 3;
			dgvZahtjevi.Columns["m_datEnd"].DisplayIndex = 4;
			dgvZahtjevi.Columns["m_strDescription"].DisplayIndex = 5;
			dgvZahtjevi.Columns["m_iIDApprover"].DisplayIndex = 6;
			dgvZahtjevi.Columns["m_iStatus"].DisplayIndex = 7;

			dgvZahtjevi.Columns["m_datLastModified"].Visible = false;
			dgvZahtjevi.Columns["m_iIDUser"].Visible = false;
		}

		private void FrmMyRequests_Load(object sender, EventArgs e)
        {
			ReSupplyRequestData();
			cboType.DataSource = StaticRepositories.VrstaZahtjevaRepository.GetList();
			cboType.Height = (int)(pnlAddTable.RowStyles[1].Height * pnlAddTable.Height);

			lblEndAbsenseInput.Text = DateTime.Now.Date.ToString();
			lblStartAbsenseInput.Text = DateTime.Now.Date.ToString();
		}

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		private void dgvZahtjevi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs cell)
		{
			int iColumn = cell.ColumnIndex;
			switch( dgvZahtjevi.Columns[iColumn].Name )
			{
				case "m_iType":
				{
					// Get the ID value from the cell
					int id = (int)cell.Value;

					var translationList = StaticRepositories.VrstaZahtjevaRepository.GetList();
					var type = translationList.Find(x => x.m_iID == id);

					// Set the formatted value to the translated string
					cell.Value = type.m_strName;
				}
				break;
				case "m_iStatus":
				{
					// Get the ID value from the cell
					int id = (int)cell.Value;

					var translationList = StaticRepositories.StatusZahtjevaRepository.GetList();
					var status = translationList.Find(x => x.m_iID == id);

					// Set the formatted value to the translated string
					cell.Value = status.m_strStatusText;
				}
				break;
				case "m_iIDApprover":
				{
					// Get the ID value from the cell
					int id =(int)cell.Value;

					if(id == -1)
					{
						cell.Value = "";
						return;
					}

					var user = KorisnikRepository.GetUser(id);

					// Set the formatted value to the translated string
					cell.Value = user.m_strIme;
				}
				break;
			}
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void lblStartAbsenseInput_Click(object sender, EventArgs e)
		{
			Label label = ((Label)sender);
			
			cldStartAbsense.Visible = true;

			var location = // Daje nam "Absolutnu" lokaciju label-a, tako da se naš popup kalendar može snaći
				label.FindForm().PointToClient(label.Parent.PointToScreen(label.Location));

			location.Y += label.Height;
			location.Y -= cldEndAbsense.Height;

			cldStartAbsense.Location = location;

			cldStartAbsense.Focus();
		}

		private void lblEndAbsenseInput_Click(object sender, EventArgs e)
		{
			Label label = ((Label)sender);
			cldEndAbsense.Visible = true;

			var location = // Daje nam "Absolutnu" lokaciju label-a, tako da se naš popup kalendar može snaći
				label.FindForm().PointToClient(label.Parent.PointToScreen(label.Location));

			location.Y += label.Height;
			location.Y -= cldEndAbsense.Height;

			cldEndAbsense.Location = location;

			cldEndAbsense.Focus();
		}

		private void cld_Leave(object sender, EventArgs e)
		{
			((MonthCalendar)(sender)).Visible = false;
		}

		private void cldStartAbsense_DateSelected(object sender, DateRangeEventArgs date)
		{
			((MonthCalendar)(sender)).Visible = false;
			lblStartAbsenseInput.Text = date.Start.Date.ToString();
		}

		private void cldEndAbsense_DateSelected(object sender, DateRangeEventArgs date)
		{
			((MonthCalendar)(sender)).Visible = false;
			lblEndAbsenseInput.Text = date.Start.Date.ToString();
		}

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			CRequest request = new CRequest();

			request.m_iIDUser = KorisnikRepository.GetUser(LocalAuthentificationHandler.GetUserInfo().Subject).m_iID;
			request.m_iType = ((CVrstaZahtjeva)cboType.SelectedItem).m_iID;
			request.m_datStart = DateTime.Parse( lblStartAbsenseInput.Text );
			request.m_datEnd = DateTime.Parse( lblEndAbsenseInput.Text );
			request.m_strDescription = txtOpis.Text;
			ZahtjevRepository.InsertRequest(request);

			ReSupplyRequestData();
		}
	}
}
