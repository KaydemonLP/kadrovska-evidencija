using Kadrovska.repositories;
using Kadrovska.staticrepositories;
using Kadrovska.Auth;
using Kadrovska.models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Kadrovska
{
	public class ZahtjevRequestHandler
	{
		public static readonly string m_strDefaultDate = "--/--/--";
		public static readonly string m_strDateFormat = "dd/MMM/yyyy";
		public static List<MonthCalendar> m_aCalendars = new List<MonthCalendar>();

		public Button			m_btnSubmit;
		public Button			m_btnRevert;
		public ComboBox			m_cboType;
		public Label			m_lblStart;
		public Label			m_lblEnd;
		public TextBox			m_txtDescription;
		public MonthCalendar	m_cldStart;
		public MonthCalendar	m_cldEnd;

		public Form			m_Parent;



		#region StaticMethods
		/// <summary>
		/// Dodaje danu kalendar komponentu listi kalendara
		/// Lista se koristi da postavimo koji su datumi več zauzeti
		/// </summary>
		/// <param name="calendar"></param>
		public static void AddCalendar(MonthCalendar calendar)
		{
			m_aCalendars.Add(calendar);
			calendar.MinDate = DateTime.Now.Date;
		}
		/// <summary>
		/// Ukloni danu kalendar komponentu sa liste kalendara
		/// </summary>
		/// <param name="calendar"></param>
		public static void RemoveCalendar(MonthCalendar calendar)
		{
			m_aCalendars.Remove(calendar);
		}
		/// <summary>
		/// Provijeri ako je dani datum več zauzet u odgovarajučem kalendaru
		/// </summary>
		/// <param name="calendar"></param>
		public static bool IsDateTaken( DateTime date, MonthCalendar calendar)
		{
			foreach( DateTime bolded in calendar.BoldedDates )
			{
				if( date.Date == bolded.Date )
					return true;
			}
			return false;
		}
		/// <summary>
		/// Ova metoda učita listu Zahtjeva te kaže svakom kalendaru da su datumi tih zahtjeva zauzeti
		/// </summary>
		/// <param name="requests"></param>
		public static void LoadTakenDates( List<CRequest> requests )
		{
			foreach( MonthCalendar calendar in m_aCalendars )
				calendar.RemoveAllBoldedDates();

			foreach( CRequest request in requests )
			{
				for( 
					DateTime date = DateTime.Now.Date > request.m_datStart.Date ? DateTime.Now.Date : request.m_datStart;
					date.Date <= request.m_datEnd.Date; date = date.AddDays(1) )
				{
					foreach( MonthCalendar calendar in m_aCalendars )
						calendar.AddBoldedDate(date);
                }
			}

			// Ovo je malo neuobičajeno, no, nažalost, Invalidate layout ne Refresh-a BoldedDate
			// Tako da moramo ručno promijeniti stranicu i natrag da se ponovno postave
			foreach( MonthCalendar calendar in m_aCalendars )
			{
				var initial = calendar.SelectionStart;
				calendar.SelectionStart = calendar.SelectionStart.AddMonths(1);
				calendar.Refresh();

				calendar.SelectionStart = initial;
				calendar.Refresh();
			}
		}
		/// <summary>
		/// Ova metoda izračuna mijesto odgovarajuče labele na cijelokupnom ekranu
		/// kako bi kalendar mogli na istu postaviti
		/// 
		/// Ne možemo samo staviti location = location jer se kalendari i labele nalaze
		/// na različitim razinama ugnježdenosti
		/// </summary>
		/// <param name="calendar"></param>
		/// <param name="label"></param>
		public static void OpenCalendarAtLabel( MonthCalendar calendar, Label label )
		{
			calendar.Visible = true;

			var location = // Daje nam "Absolutnu" lokaciju label-a, tako da se naš popup kalendar može snaći
				label.FindForm().PointToClient(label.Parent.PointToScreen(label.Location));

			location.Y += label.Height;
			location.Y -= calendar.Height;

			calendar.Location = location;

			calendar.Focus();
		}
		/// <summary>
		/// Postavlja odgovarajuču labelu na dani datum ako nije zauzet
		/// </summary>
		/// <param name="label"></param>
		/// <param name="date"></param>
		/// <param name="calendar"></param>
		/// <returns></returns>
		public static bool SetLabelToDate( Label label, DateTime date, MonthCalendar calendar )
		{
			if( IsDateTaken(date, calendar) )
				return false;

			label.Text = date.ToString(m_strDateFormat);

			return true;
		}
		#endregion
		/// <summary>
		/// Konstruktor koji uzima i spremi nužne komponente za slanje zahtjeva
		/// </summary>
		/// <param name="btnSubmit"></param>
		/// <param name="btnRevert"></param>
		/// <param name="cboType"></param>
		/// <param name="lblStart"></param>
		/// <param name="lblEnd"></param>
		/// <param name="txtDescription"></param>
		/// <param name="cldStart"></param>
		/// <param name="cldEnd"></param>
		/// <param name="parent"></param>
		public ZahtjevRequestHandler(Button btnSubmit, Button btnRevert, ComboBox cboType, Label lblStart, Label lblEnd,
			TextBox txtDescription, MonthCalendar cldStart,	MonthCalendar cldEnd, Form parent)
		{
			m_btnSubmit = btnSubmit;
			m_btnRevert = btnRevert;
			m_cboType = cboType;
			m_lblStart = lblStart;
			m_lblEnd = lblEnd;
			m_txtDescription = txtDescription;
			m_cldStart = cldStart;
			m_cldEnd = cldEnd;

			m_Parent = parent;

			m_cboType.DataSource = StaticRepositories.VrstaZahtjevaRepository.GetList();
		}
		/// <summary>
		/// Konstruira CRequest od spremljenih komponenti
		/// </summary>
		/// <returns></returns>
		public CRequest GetRequestFromInputs()
		{
			CRequest request = new CRequest();

			string strGoogleAuth = LocalAuthentificationHandler.GetUserInfo().Subject;
			CKorisnik user = KorisnikRepository.GetUser(strGoogleAuth);

			CVrstaZahtjeva type = (CVrstaZahtjeva)m_cboType.SelectedItem;

			request.m_iIDUser = user.m_iID;
			request.m_iType = type.m_iID;
			request.m_datStart = DateTime.Parse(m_lblStart.Text);
			request.m_datEnd = DateTime.Parse(m_lblEnd.Text);
			request.m_strDescription = m_txtDescription.Text;

			return request;
		}
		/// <summary>
		/// Uključuje svaku komponentu za unos
		/// </summary>
		public void EnableFormInput()
		{
			m_btnSubmit.Enabled = true;
			m_btnRevert.Enabled = true;
			m_cboType.Enabled = true;
			m_lblStart.Enabled = true;
			m_lblEnd.Enabled = true;
			m_txtDescription.Enabled = true;
		}
		/// <summary>
		/// Isključuje svaku komponentu za unos
		/// </summary>
		public void DisableFormInput()
		{
			m_btnSubmit.Enabled = false;
			m_btnRevert.Enabled = false;
			m_cboType.Enabled = false;
			m_lblStart.Enabled = false;
			m_lblEnd.Enabled = false;
			m_txtDescription.Enabled = false;
		}
		/// <summary>
		/// Ova metoda provjeri ako su sve nužne komponente ispunjene
		/// Te ako jesu, provjerava ako su ispravne
		/// 
		/// Ako je sve ispravno, onda uključuje gumb za slanje forme
		/// Ako nije, istog isključuje
		/// </summary>
		public void CalculateSubmitButtonState()
		{
			CRequest request;
			try
			{
				request = GetRequestFromInputs();
			}
			catch
			{
				m_btnSubmit.Enabled = false;
				return;
			}

			if( request.m_datEnd < DateTime.Now.Date
				|| request.m_datStart < DateTime.Now.Date )
			{
				m_btnSubmit.Enabled = false;
				return;
			}

			if( request.m_datEnd < request.m_datStart )
			{
				m_btnSubmit.Enabled = false;
				return;
			}

			m_btnSubmit.Enabled = true;
		}
		/// <summary>
		/// Ovo je baza metode koja se poziva kada se želi formu resetirati
		/// Po default-u, samo provjeri ako je gumb valjan
		/// Pošto nakon resetiranja svi unosi promijene vrijednost
		/// </summary>
		virtual public void ResetForm()
		{
			CalculateSubmitButtonState();
		}
		/// <summary>
		/// Ova metoda se odvija kada se želi poslati zahtijev
		/// Po defaultu ništa ne radi
		/// </summary>
		virtual public void OnSendClick() { }

		/// <summary>
		/// Ova metoda se odvija kada pritisnemo gumb za resetiranje forme
		/// Ona poziva funkciju za resetiranje forme
		/// </summary>
		public void OnResetClick()
		{
			ResetForm();
		}
	}

	public class ZahtjevSubmitHandler : ZahtjevRequestHandler
	{
		public ZahtjevSubmitHandler(Button btnSubmit, Button btnRevert, ComboBox cboType, Label lblStart, Label lblEnd,
			TextBox txtDescription, MonthCalendar cldStart, MonthCalendar cldEnd, Form parent) 
			: base(btnSubmit, btnRevert, cboType, lblStart, lblEnd, txtDescription, cldStart, cldEnd, parent)
		{
		}
		/// <summary>
		/// Za submit formu, resetiramo na default vrijednosti svake komponente
		/// </summary>
		public override void ResetForm()
		{
			m_cldStart.SelectionStart = DateTime.Now.Date;
			m_cldEnd.MinDate = m_cldStart.SelectionStart;
			m_cldEnd.SelectionStart = DateTime.Now.Date;
			m_cboType.SelectedIndex = 0;
			m_lblStart.Text = m_strDefaultDate;
			m_lblEnd.Text = m_strDefaultDate;
			m_txtDescription.Text = "";

			EnableFormInput();

			base.ResetForm();
		}

		/// <summary>
		/// Ova metoda šalje upit za izradu novog zahtjeva
		/// 
		/// Zahtjev se obrađuje na zasebnoj dretvi, te tijekom obrade, isključuje unos
		/// 
		/// Nakon što je obrada gotova, unos se ponovno uključuje i forma resetira
		/// </summary>
		public override void OnSendClick()
		{
			CRequest request = GetRequestFromInputs();

			DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da zelite poslati ovaj zahtjev?", "Upozorenje", MessageBoxButtons.YesNo);
			if( dialogResult == DialogResult.No )
				return;

			DisableFormInput();


			ThreadPool.QueueUserWorkItem((state) =>
			{
				ZahtjevRepository.InsertRequest(request);

				m_Parent.Invoke(new Action(() =>
				{
					FrmMyRequests.Default.ReSupplyRequestData();

					ResetForm();
				}));
			});
		}
	}

	public class ZahtjevEditHandler : ZahtjevRequestHandler
	{
		public CRequest m_Request;

		public ZahtjevEditHandler(Button btnSubmit, Button btnRevert, ComboBox cboType, Label lblStart, Label lblEnd,
			TextBox txtDescription, MonthCalendar cldStart, MonthCalendar cldEnd, Form parent, CRequest request)
			: base(btnSubmit, btnRevert, cboType, lblStart, lblEnd, txtDescription, cldStart, cldEnd, parent)
		{
			m_Request = request;
		}
		/// <summary>
		/// Za edit formu, resetiramo na početnu vrijednost zahtjeva kojeg uređivamo
		/// </summary>
		public override void ResetForm()
		{
			m_cldStart.SelectionStart = m_Request.m_datStart;
			m_cldEnd.MinDate = m_cldStart.SelectionStart;
			m_cldEnd.SelectionStart = m_Request.m_datEnd;
			m_cboType.SelectedItem = StaticRepositories.VrstaZahtjevaRepository.GetItem(x => x.m_iID == m_Request.m_iType);
			m_lblStart.Text = m_Request.m_datStart.ToString(m_strDateFormat);
			m_lblEnd.Text = m_Request.m_datEnd.ToString(m_strDateFormat);
			m_txtDescription.Text = m_Request.m_strDescription;

			base.ResetForm();
		}
		/// <summary>
		/// Ova metoda šalje upit za uređivanje zahtjeva
		/// Tijekom obrađivanja, program se pauzira
		/// Nakon što je obrada gotova, forma se ugasi
		/// </summary>
		public override void OnSendClick()
		{
			DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da zelite urediti ovaj zahtjev?", "Upozorenje", MessageBoxButtons.YesNo);
			if( dialogResult == DialogResult.No )
				return;

			ZahtjevRepository.UpdateRequest(GetRequestFromInputs(), m_Request.m_iID);
			FrmMyRequests.Default.ReSupplyRequestData();
		}
	}
}
