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
		/// <summary>
		/// Konstruktor, postavlja "Default" na samog sebe, kako bi vanjske klase mogle njemu pristupiti
		/// Također izradi novi ZahtjevSubmitHandler te mu proslijedi nužne komponente
		/// za izradu zahtjeva
		/// </summary>
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
		/// <summary>
		/// Ova metoda služi refresh-anju liste zahtjeva
		/// Tijekom učitavanja podatki nije dozvoljeno tipkama "uredi" i "izbriši" da se promijene
		/// Jer će inaće C# dati grešku
		/// Da se to osigura, koristimo m_bLoadingData
		/// 
		/// Također Učita od tih zahtjeva datume koji su več zauzeti
		/// </summary>
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
		/// <summary>
		/// Ova metoda formatira čelije koje koriste ID da prikažu konkretna imena
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="cell"></param>
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

		/// <summary>
		/// Ova metoda uključuje tipke za uređivanje i brisanje
		/// </summary>
		private void EnableEditButtons()
		{
			btnEdit.Enabled = true;
			btnErase.Enabled = true;
		}
		/// <summary>
		/// Ova metoda isključuje tipke za uređivanje i brisanje
		/// </summary>
		private void DisableEditButtons()
		{
			btnEdit.Enabled = false;
			btnErase.Enabled = false;
		}
		/// <summary>
		/// Ova metoda selektira cijeli redak ako je trenutna čelija selektirana
		/// ili deselektira kada je ona deselektirana
		/// </summary>
		private void SelectRowOfSelectedCell()
		{
			if (dgvZahtjevi.CurrentRow != null)
				dgvZahtjevi.CurrentRow.Selected = dgvZahtjevi.CurrentCell.Selected;
		}
		/// <summary>
		/// Ako je prošao krajnji datum zahtjeva, ne smijemo ga više urediti, samo izbrisat
		/// </summary>
		/// <param name="date"></param>
		private void DisableEditIfDatePassed(DateTime date)
		{
			if (date < DateTime.Now.Date)
				btnEdit.Enabled = false;
		}
		/// <summary>
		/// Pošto ne želimo da nam radnici urede ili izbrišu zahtjev nakon što smo ga odobrili
		/// ova funkcija isključuje tu funkcionalnost
		/// 
		/// Također ne dopušta uređivanje zahtjeva ako je prošao krajnji rok
		/// </summary>
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
		/// <summary>
		/// Kada se promijeni selektirana čelija, provijeri ako smijemo urediti ovaj zapis
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvZahtjevi_CurrentCellChanged(object sender, EventArgs e)
		{
			if( m_bLoadingData )
				return;

			HideOrShowEditButtons();
		}
		/// <summary>
		/// Ova metoda se poziva kada pritisnemo izbriši
		/// Uzima trenutačni redak i zapis, te ga izbriše ako to korisnik potvrđuje
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
		/// <summary>
		/// Ova metoda se poziva kada pritisnemo uredi
		/// Uzima trenutačni redak i zapis, te otvori formu za uređivanje zapisa
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
		/// <summary>
		/// Ova metoda prosljeđuje Request handler-u da otvori kalendar za početak odsustva
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lblStartAbsenseInput_Click(object sender, EventArgs e)
		{
			ZahtjevRequestHandler.OpenCalendarAtLabel( cldStartAbsense, ((Label)sender));
		}
		/// <summary>
		/// Ova metoda prosljeđuje Request handler-u da otvori kalendar za kraj odsustva
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lblEndAbsenseInput_Click(object sender, EventArgs e)
		{
			ZahtjevRequestHandler.OpenCalendarAtLabel( cldEndAbsense, ((Label)sender) );
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
		private void SetMinimumEndDate( DateTime date )
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
			bool bSuccess = ZahtjevRequestHandler.SetLabelToDate( lblStartAbsenseInput, date.Start.Date, ((MonthCalendar)(sender)) );

			((MonthCalendar)(sender)).Visible = !bSuccess;

			if( bSuccess )
			{ 
				SetMinimumEndDate(date.Start.Date);
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
			bool bSuccess = ZahtjevRequestHandler.SetLabelToDate( lblEndAbsenseInput, date.Start.Date, ((MonthCalendar)(sender)) );

			((MonthCalendar)(sender)).Visible = !bSuccess;


			if( bSuccess )
			{
				m_RequestHandler.CalculateSubmitButtonState();
			}
		}
		/// <summary>
		/// Ova metoda se otvara kada pritisnemo gumb za slanje forme
		/// Ona poziva request handler da obavi nužne funkcije za slanje forme
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSubmit_Click(object sender, EventArgs e)
		{
			m_RequestHandler.OnSendClick();
		}

		#endregion
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
		/// <summary>
		/// Ova metoda se odvija kada se naš tekst pretraživanja promijeni
		/// Ona postavi data source tablice na listu zahtjeva koja podudaraju upit 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			dgvZahtjevi.DataSource = m_aRequests.FindAll(SearchRequest);
		}
	}
}
