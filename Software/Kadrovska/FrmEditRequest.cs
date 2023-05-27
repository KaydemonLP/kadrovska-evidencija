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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Kadrovska
{
	public partial class FrmEditRequest : Form
	{
		CRequest m_Request;
		ZahtjevEditHandler m_RequestHandler;
		public FrmEditRequest( CRequest request, FrmMyRequests parent )
		{
			m_Request = request;
			InitializeComponent();

			m_RequestHandler = new ZahtjevEditHandler
			(
				btnEdit,
				btnReset,
				cboType,
				lblStartAbsenseInput,
				lblEndAbsenseInput,
				txtOpis,
				cldStartAbsense,
				cldEndAbsense,
				this,

				m_Request
			);
		}

		private void lblStartAbsenseInput_Click(object sender, EventArgs e)
		{
			ZahtjevRequestHandler.OpenCalendarAtLabel(cldStartAbsense, ((Label)sender));
		}

		private void lblEndAbsenseInput_Click(object sender, EventArgs e)
		{
			ZahtjevRequestHandler.OpenCalendarAtLabel(cldEndAbsense, ((Label)sender));
		}

		private void cld_Leave(object sender, EventArgs e)
		{
			((MonthCalendar)(sender)).Visible = false;
		}

		private void SetMinimumEndDate(DateTime date)
		{
			cldEndAbsense.MinDate = date;
			lblEndAbsenseInput.Text = ZahtjevRequestHandler.m_strDefaultDate;
		}

		private void cldStartAbsense_DateSelected(object sender, DateRangeEventArgs date)
		{
			bool bSuccess = ZahtjevRequestHandler.SetLabelToDate( lblStartAbsenseInput, date.Start.Date, ((MonthCalendar)(sender)));

			((MonthCalendar)(sender)).Visible = !bSuccess;

			if( bSuccess )
				SetMinimumEndDate(date.Start.Date);
		}

		private void cldEndAbsense_DateSelected(object sender, DateRangeEventArgs date)
		{
			bool bSuccess = ZahtjevRequestHandler.SetLabelToDate( lblEndAbsenseInput, date.Start.Date, ((MonthCalendar)(sender)));

			((MonthCalendar)(sender)).Visible = !bSuccess;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			m_RequestHandler.OnSendClick();
			Close();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			m_RequestHandler.OnResetClick();
		}

		private void AllowRequestDateRange()
		{
			for (
				DateTime date = DateTime.Now.Date > m_Request.m_datStart.Date ? DateTime.Now.Date : m_Request.m_datStart;
				date.Date <= m_Request.m_datEnd.Date; date = date.AddDays(1))
			{
				cldStartAbsense.RemoveBoldedDate(date);
				cldEndAbsense.RemoveBoldedDate(date);
			}
		}

		private void FrmEditRequest_Load(object sender, EventArgs e)
		{
			ZahtjevRequestHandler.AddCalendar(cldStartAbsense);
			ZahtjevRequestHandler.AddCalendar(cldEndAbsense);
			FrmMyRequests.Default.ReSupplyRequestData();

			AllowRequestDateRange();

			m_RequestHandler.ResetForm();
		}

		private void FrmEditRequest_FormClosing(object sender, FormClosingEventArgs e)
		{
			ZahtjevRequestHandler.RemoveCalendar(cldStartAbsense);
			ZahtjevRequestHandler.RemoveCalendar(cldEndAbsense);
		}
	}
}
