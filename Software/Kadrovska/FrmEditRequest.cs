using Kadrovska.models;
using System;
using System.Windows.Forms;

namespace Kadrovska
{
	public partial class FrmEditRequest : Form
	{
		CRequest m_Request;
		ZahtjevEditHandler m_RequestHandler;
		/// <summary>
		/// Konstruktor, postavlja m_Request na zahtjev kojeg obrađivamo
		/// Također izradi novi ZahtjevEditHandler te mu proslijedi nužne komponente
		/// za izradu zahtjeva za uređivanje zahtjeva
		/// </summary>
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
		/// <summary>
		/// Ova metoda prosljeđuje Request handler-u da otvori kalendar za početak odsustva
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lblStartAbsenseInput_Click(object sender, EventArgs e)
		{
			ZahtjevRequestHandler.OpenCalendarAtLabel(cldStartAbsense, ((Label)sender));
		}
		/// <summary>
		/// Ova metoda prosljeđuje Request handler-u da otvori kalendar za kraj odsustva
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lblEndAbsenseInput_Click(object sender, EventArgs e)
		{
			ZahtjevRequestHandler.OpenCalendarAtLabel(cldEndAbsense, ((Label)sender));
		}
		/// <summary>
		/// Ova metoda zatvara kalendar ako kliknemo izvan istog
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cld_Leave(object sender, EventArgs e)
		{
			((MonthCalendar)(sender)).Visible = false;
		}
		/// <summary>
		/// Ova metoda postavlja minimalni datum koji smijemo odabrati za kraj odsustva
		/// Koristi ga kalendar za početak odsustva da osigura da ne možemo imati kraj
		/// prije početka.
		/// </summary>
		/// <param name="date"></param>
		private void SetMinimumEndDate(DateTime date)
		{
			cldEndAbsense.MinDate = date;
			lblEndAbsenseInput.Text = ZahtjevRequestHandler.m_strDefaultDate;
		}
		/// <summary>
		/// Kada u kalendaru odaberemo datum, postavimo labelu na odgovarajuč datum
		/// Ako nam je to uspjelo, sakrij kalendar, postavi minimalni krajnji datum
		/// te provjeri ako smijemo poslati zahtjev
		/// Ako nije, ne radi ništa
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="date"></param>
		private void cldStartAbsense_DateSelected(object sender, DateRangeEventArgs date)
		{
			bool bSuccess = ZahtjevRequestHandler.SetLabelToDate( lblStartAbsenseInput, date.Start.Date, ((MonthCalendar)(sender)));

			((MonthCalendar)(sender)).Visible = !bSuccess;

			if( bSuccess )
				SetMinimumEndDate(date.Start.Date);

			if( bSuccess )
			{
				m_RequestHandler.CalculateSubmitButtonState();
			}
		}
		/// <summary>
		/// Kada u kalendaru odaberemo datum, postavimo labelu na odgovarajuč datum
		/// Ako nam je to uspjelo, sakrij kalendar
		/// te provjeri ako smijemo poslati zahtjev
		/// Ako nije, ne radi ništa
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="date"></param>
		private void cldEndAbsense_DateSelected(object sender, DateRangeEventArgs date)
		{
			bool bSuccess = ZahtjevRequestHandler.SetLabelToDate( lblEndAbsenseInput, date.Start.Date, ((MonthCalendar)(sender)));

			((MonthCalendar)(sender)).Visible = !bSuccess;

			if( bSuccess )
			{
				m_RequestHandler.CalculateSubmitButtonState();
			}
		}
		/// <summary>
		/// Ova metoda se otvara kada pritisnemo gumb za uređivanje zahtjeva
		/// Ona poziva request handler da obavi nužne funkcije za uređivanje zahtjeva, te zatvara ovu formu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEdit_Click(object sender, EventArgs e)
		{
			m_RequestHandler.OnSendClick();
			Close();
		}
		/// <summary>
		/// Ovaj gumb daje request handler-u obavjest da resetira formu za unos
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReset_Click(object sender, EventArgs e)
		{
			m_RequestHandler.OnResetClick();
		}
		/// <summary>
		/// Ova metoda provjerava ako dani "request" ima bilo koje polje koje se podudara
		/// sa našim tekstom pretraživanja
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
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
