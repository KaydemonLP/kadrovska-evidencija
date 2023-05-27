using Evaluation_Manager.repositories;
using Evaluation_Manager.staticrepositories;
using Kadrovska.Auth;
using Kadrovska.models;
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
	public partial class FrmEditRequest : Form
	{
		CRequest m_Request;
		FrmMyRequests m_Parent;
		public FrmEditRequest( CRequest request, FrmMyRequests parent )
		{
			m_Request = request;
			m_Parent = parent;
			InitializeComponent();
		}
		private void ResetSubmitForm()
		{
			cldStartAbsense.SelectionStart = m_Request.m_datStart;
			cldEndAbsense.MinDate = cldStartAbsense.SelectionStart;
			cldEndAbsense.SelectionStart = m_Request.m_datEnd;
			cboType.SelectedItem = StaticRepositories.VrstaZahtjevaRepository.GetList().Find( x => x.m_iID == m_Request.m_iType );
			lblStartAbsenseInput.Text = m_Request.m_datStart.ToString("dd/MMM/yyyy");
			lblEndAbsenseInput.Text = m_Request.m_datEnd.ToString("dd/MMM/yyyy");
			txtOpis.Text = m_Request.m_strDescription;
		}

		private void OpenCalendarAtLabel(MonthCalendar calendar, Label label)
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
			OpenCalendarAtLabel(cldStartAbsense, ((Label)sender));
		}

		private void lblEndAbsenseInput_Click(object sender, EventArgs e)
		{
			OpenCalendarAtLabel(cldEndAbsense, ((Label)sender));
		}

		private void cld_Leave(object sender, EventArgs e)
		{
			((MonthCalendar)(sender)).Visible = false;
		}

		private void SetLabelToDate(Label lblStartAbsenseInput, MonthCalendar sender, DateRangeEventArgs date)
		{
			if (m_Parent.m_aTakenDates.Exists(x => x.Date == date.Start.Date))
				return;

			sender.Visible = false;

			lblStartAbsenseInput.Text = date.Start.Date.ToString("dd/MMMM/yyyy");
		}

		private void SetMinimumEndDate(DateTime date)
		{
			cldEndAbsense.MinDate = date;
			lblEndAbsenseInput.Text = "--/--/--";
		}

		private void cldStartAbsense_DateSelected(object sender, DateRangeEventArgs date)
		{
			SetLabelToDate(lblStartAbsenseInput, ((MonthCalendar)(sender)), date);

			SetMinimumEndDate(date.Start.Date);
		}

		private void cldEndAbsense_DateSelected(object sender, DateRangeEventArgs date)
		{
			SetLabelToDate(lblEndAbsenseInput, ((MonthCalendar)(sender)), date);
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

		private void btnEdit_Click(object sender, EventArgs e)
		{
			ZahtjevRepository.UpdateRequest(GetRequestFromInputs(), m_Request.m_iID);
			m_Parent.ReSupplyRequestData();
			Close();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			ResetSubmitForm();
		}

		private void FrmEditRequest_Load(object sender, EventArgs e)
		{
			cboType.DataSource = StaticRepositories.VrstaZahtjevaRepository.GetList();
			ResetSubmitForm();
		}
	}
}
