using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Kadrovska.repositories;
using Kadrovska.staticrepositories;
using Kadrovska.Auth;
using Kadrovska.models;

namespace Kadrovska
{
    public partial class FrmMyRequests : Form
    {
		ZahtjevSubmitHandler m_RequestHandler;
		public static FrmMyRequests Default;
		public FrmMyRequests()
        {
			Default = this;

			InitializeComponent();

			m_RequestHandler = new ZahtjevSubmitHandler
			(
				btnSubmit,
				btnReset,
				cboType,
				lblStartAbsenseInput,
				lblEndAbsenseInput,
				txtOpis,
				cldStartAbsense,
				cldEndAbsense,
				this
			);
		}

		List<CRequest> m_aRequests;

		private bool m_bLoadingData = false;

		#region DisplayRequestsMethods
		public void ReSupplyRequestData()
        {
			string strAuthCode = LocalAuthentificationHandler.GetUserInfo().Subject;
			int iUserID = KorisnikRepository.GetUser(strAuthCode).m_iID;
			m_aRequests = ZahtjevRepository.GetRequests(iUserID);

			m_bLoadingData = true;
			dgvZahtjevi.DataSource = m_aRequests;
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

			ZahtjevRequestHandler.LoadTakenDates(m_aRequests);
		}

		private void FrmMyRequests_Load(object sender, EventArgs e)
        {
			ZahtjevRequestHandler.AddCalendar(cldStartAbsense);
			ZahtjevRequestHandler.AddCalendar(cldEndAbsense);

			ReSupplyRequestData();

			m_RequestHandler.ResetForm();
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

					if(id <= 0)
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

		private void SelectRowOfSelectedCell()
		{
			if (dgvZahtjevi.CurrentRow != null)
				dgvZahtjevi.CurrentRow.Selected = dgvZahtjevi.CurrentCell.Selected;
		}

		private void DisableEditIfDatePassed(DateTime date)
		{
			if (date < DateTime.Now.Date)
				btnEdit.Enabled = false;
		}

		private void HideOrShowEditButtons()
		{
			SelectRowOfSelectedCell();

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

			DisableEditIfDatePassed( request.m_datEnd.Date );
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

			DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da zelite izbrisati ovaj zahtjev?", "Upozorenje", MessageBoxButtons.YesNo);
			if( dialogResult == DialogResult.No )
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

		#endregion

		#region SendRequest
		private void lblStartAbsenseInput_Click(object sender, EventArgs e)
		{
			ZahtjevRequestHandler.OpenCalendarAtLabel( cldStartAbsense, ((Label)sender));
		}

		private void lblEndAbsenseInput_Click(object sender, EventArgs e)
		{
			ZahtjevRequestHandler.OpenCalendarAtLabel( cldEndAbsense, ((Label)sender) );
		}

		private void cld_Leave(object sender, EventArgs e)
		{
			((MonthCalendar)(sender)).Visible = false;
		}

		private void SetMinimumEndDate( DateTime date )
		{
			cldEndAbsense.MinDate = date;
			lblEndAbsenseInput.Text = ZahtjevRequestHandler.m_strDefaultDate;
		}

		private void cldStartAbsense_DateSelected(object sender, DateRangeEventArgs date)
		{
			bool bSuccess = ZahtjevRequestHandler.SetLabelToDate( lblStartAbsenseInput, date.Start.Date, ((MonthCalendar)(sender)) );

			((MonthCalendar)(sender)).Visible = !bSuccess;

			if( bSuccess )
			{ 
				SetMinimumEndDate(date.Start.Date);
				m_RequestHandler.CalculateSubmitButtonState();
			}
		}

		private void cldEndAbsense_DateSelected(object sender, DateRangeEventArgs date)
		{
			bool bSuccess = ZahtjevRequestHandler.SetLabelToDate( lblEndAbsenseInput, date.Start.Date, ((MonthCalendar)(sender)) );

			((MonthCalendar)(sender)).Visible = !bSuccess;


			if( bSuccess )
			{
				m_RequestHandler.CalculateSubmitButtonState();
			}
		}

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			m_RequestHandler.OnSendClick();
		}

		#endregion

		private void btnReset_Click(object sender, EventArgs e)
		{
			m_RequestHandler.OnResetClick();
		}

		private bool SearchRequest( CRequest request )
		{
			string searchText = txtSearch.Text.ToLower();

			bool ret = false;

			ret |= request.m_datCreationTime.ToString().ToLower().Contains(searchText);
			ret |= request.GetTypeName().ToLower().Contains(searchText);
			ret |= request.m_datStart.Date.ToString().ToLower().Contains(searchText);
			ret |= request.m_datEnd.Date.ToString().ToLower().Contains(searchText);
			ret |= request.m_strDescription.ToLower().Contains(searchText);
			ret |= request.GetApproverName().ToLower().Contains(searchText);
			ret |= request.GetStatusText().ToLower().Contains(searchText);

			return ret;
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			dgvZahtjevi.DataSource = m_aRequests.FindAll(SearchRequest);
		}
	}
}
