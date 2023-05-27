using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
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

		public List<DateTime> m_aTakenDates = new List<DateTime>();
		private bool m_bLoadingData = false;

        public void ReSupplyRequestData()
        {
			string strAuthCode = LocalAuthentificationHandler.GetUserInfo().Subject;
			int iUserID = KorisnikRepository.GetUser(strAuthCode).m_iID;
			var requests = ZahtjevRepository.GetRequests(iUserID);

			m_bLoadingData = true;
			dgvZahtjevi.DataSource = requests;
			m_bLoadingData = false;

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

			HideOrShowEditButtons();

			LoadTakenDates(requests);
		}

		private void LoadTakenDates(List<CRequest> requests)
		{
			cldStartAbsense.RemoveAllBoldedDates();
			cldEndAbsense.RemoveAllBoldedDates();
			m_aTakenDates.Clear();

			foreach ( CRequest request in requests )
			{
				for( 
					DateTime date = DateTime.Now.Date > request.m_datStart.Date ? DateTime.Now.Date : request.m_datStart;
					date.Date <= request.m_datEnd.Date; date = date.AddDays(1) )
				{
                    cldStartAbsense.AddBoldedDate(date);
                    cldEndAbsense.AddBoldedDate(date);
                    m_aTakenDates.Add(date);
                }
			}

			// Ovo je malo neuobičajeno, no, nažalost, Invalidate layout ne Refresh-a BoldedDate
			// Tako da moramo ručno promijeniti stranicu i natrag da se ponovno postave
			var initial = cldStartAbsense.SelectionStart;
			cldStartAbsense.SelectionStart = cldStartAbsense.SelectionStart.AddMonths(1);
			cldStartAbsense.Refresh();

			cldStartAbsense.SelectionStart = initial;
			cldStartAbsense.Refresh();

			initial = cldEndAbsense.SelectionStart;
			cldEndAbsense.SelectionStart = cldEndAbsense.SelectionStart.AddMonths(2);
			cldEndAbsense.Refresh();

			cldEndAbsense.SelectionStart = initial;
			cldEndAbsense.Refresh();
		}

		private void FrmMyRequests_Load(object sender, EventArgs e)
        {
			ReSupplyRequestData();
			cboType.DataSource = StaticRepositories.VrstaZahtjevaRepository.GetList();

			cldStartAbsense.MinDate = DateTime.Now;
			cldEndAbsense.MinDate = DateTime.Now;
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
					cell.Value = user.m_strIme + " " + user.m_strPrezime;
				}
				break;
			}
		}

		private void OpenCalendarAtLabel( MonthCalendar calendar, Label label )
		{
			calendar.Visible = true;

			var location = // Daje nam "Absolutnu" lokaciju label-a, tako da se naš popup kalendar može snaći
				label.FindForm().PointToClient(label.Parent.PointToScreen(label.Location));

			location.Y += label.Height;
			location.Y -= calendar.Height;

			calendar.Location = location;

			calendar.Focus();
		}

		private void lblStartAbsenseInput_Click(object sender, EventArgs e)
		{
			OpenCalendarAtLabel( cldStartAbsense, ((Label)sender));
		}

		private void lblEndAbsenseInput_Click(object sender, EventArgs e)
		{
			OpenCalendarAtLabel( cldEndAbsense, ((Label)sender) );
		}

		private void cld_Leave(object sender, EventArgs e)
		{
			((MonthCalendar)(sender)).Visible = false;
		}

		private void SetLabelToDate(Label lblStartAbsenseInput, MonthCalendar sender, DateRangeEventArgs date)
		{
            if( m_aTakenDates.Exists(x => x.Date == date.Start.Date) )
				return;

			sender.Visible = false;

			lblStartAbsenseInput.Text = date.Start.Date.ToString("dd/MMMM/yyyy");
		}

		private void SetMinimumEndDate( DateTime date )
		{
			cldEndAbsense.MinDate = date;
			lblEndAbsenseInput.Text = "--/--/--";
		}

		private void cldStartAbsense_DateSelected(object sender, DateRangeEventArgs date)
		{
			SetLabelToDate( lblStartAbsenseInput, ((MonthCalendar)(sender)), date );

			SetMinimumEndDate( date.Start.Date );
		}

		private void cldEndAbsense_DateSelected(object sender, DateRangeEventArgs date)
		{
            SetLabelToDate( lblEndAbsenseInput, ((MonthCalendar)(sender)), date );
		}

		private CRequest GetRequestFromInputs()
		{
			CRequest request = new CRequest();

			request.m_iIDUser = KorisnikRepository.GetUser(LocalAuthentificationHandler.GetUserInfo().Subject).m_iID;
			request.m_iType = ((CVrstaZahtjeva)cboType.SelectedItem).m_iID;
			request.m_datStart = DateTime.Parse(lblStartAbsenseInput.Text);
			request.m_datEnd = DateTime.Parse(lblEndAbsenseInput.Text);
			request.m_strDescription = txtOpis.Text;

			return request;
		}

		private void ResetSubmitForm()
		{
			cldStartAbsense.SelectionStart = DateTime.Now;
			cldEndAbsense.MinDate = cldStartAbsense.SelectionStart;
			cldEndAbsense.SelectionStart = DateTime.Now;
			cboType.SelectedIndex = 0;
			lblStartAbsenseInput.Text = "--/--/--";
			lblEndAbsenseInput.Text = "--/--/--";
			txtOpis.Text = "";

			EnableSubmitForm();
		}

		private void EnableSubmitForm()
		{
			btnSubmit.Enabled = true;
			cboType.Enabled = true;
			lblStartAbsenseInput.Enabled = true;
			lblEndAbsenseInput.Enabled = true;
			txtOpis.Enabled = true;
		}

		private void DisableSubmitForm()
		{
			btnSubmit.Enabled = false;
			cboType.Enabled = false;
			lblStartAbsenseInput.Enabled = false;
			lblEndAbsenseInput.Enabled = false;
			txtOpis.Enabled = false;
		}

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			CRequest request = GetRequestFromInputs();
			DisableSubmitForm();

			ThreadPool.QueueUserWorkItem((state) =>
			{
				ZahtjevRepository.InsertRequest(request);
                

                Invoke(new Action(() => 
				{
                    ReSupplyRequestData();

					ResetSubmitForm();
				}));
                
            });
		}

		private void EnableEditButtons()
		{
			btnEdit.Enabled = true;
			btnErase.Enabled = true;
		}

		private void DisableEditButtons()
		{
			btnEdit.Enabled = false;
			btnErase.Enabled = false;
		}

		private void HideOrShowEditButtons()
		{
			if( dgvZahtjevi.CurrentRow != null )
				dgvZahtjevi.CurrentRow.Selected = dgvZahtjevi.CurrentCell.Selected;

			if ( dgvZahtjevi.SelectedRows.Count != 1 )
			{
				DisableEditButtons();
				return;
			}

			CRequest request = (CRequest)dgvZahtjevi.SelectedRows[0].DataBoundItem;

			if( !request.IsAwaitingApproval() )
			{
				DisableEditButtons();
				return;
			}

			EnableEditButtons();
		}

		private void dgvZahtjevi_CurrentCellChanged(object sender, EventArgs e)
		{
			if( m_bLoadingData )
				return;

			HideOrShowEditButtons();
		}

		private void btnErase_Click(object sender, EventArgs e)
		{
			if( dgvZahtjevi.SelectedRows.Count != 1 )
				return;

			CRequest request = (CRequest)dgvZahtjevi.SelectedRows[0].DataBoundItem;

			ZahtjevRepository.DeleteRequest(request.m_iID);
			ReSupplyRequestData();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if( dgvZahtjevi.SelectedRows.Count != 1 )
				return;

			CRequest request = (CRequest)dgvZahtjevi.SelectedRows[0].DataBoundItem;

			FrmEditRequest frmEdit = new FrmEditRequest(request, this);
			frmEdit.ShowDialog();
		}
	}
}
