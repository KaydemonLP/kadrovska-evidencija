using Kadrovska.repositories;
using Kadrovska.staticrepositories;
using System;
using System.ComponentModel;

namespace Kadrovska.models
{
    public class CRequest
    {
		[DisplayName("ID")]
		public int m_iID
		{
			get; set;
		}
		[DisplayName("Vrijeme kreiranja zahtjeva")]
		public DateTime m_datCreationTime
		{
			get; set;
		}
		[DisplayName("Vrsta zahtjeva")]
		public int m_iType
		{
			get; set;
		}
		[DisplayName("Početak odsustva")]
		public DateTime m_datStart
		{
			get; set;
		}
		[DisplayName("Kraj odsustva")]
		public DateTime m_datEnd
		{
			get; set;
		}
		[DisplayName("Opis")]
		public string m_strDescription
		{
			get; set;
		}
		[DisplayName("Korisnik")]
		public int m_iIDUser
		{
			get; set;
		}
		[DisplayName("Status")]
		public int m_iStatus
		{
			get; set;
		}
		[DisplayName("Vrijeme odobrenja")]
		public DateTime m_datLastModified
		{
			get; set;
		}
		[DisplayName("Odgovorna osoba")]
		public int m_iIDApprover
		{
			get; set;
		}
		/// <summary>
		/// Status 1 označava da Zahtjev čeka na odobrenje
		/// </summary>
		/// <returns></returns>
		public bool IsAwaitingApproval()
		{
			return m_iStatus == 1;
		}
		/// <summary>
		/// Ova metoda vraća ime vrste koja odgovara ID-ju vrste
		/// </summary>
		/// <returns></returns>
		public string GetTypeName()
		{
			return StaticRepositories.VrstaZahtjevaRepository.GetItem(x => x.m_iID == m_iType).m_strName;
		}
		/// <summary>
		/// Ova metoda vraća text statusa koja odgovara ID-ju statusa
		/// </summary>
		/// <returns></returns>
		public string GetStatusText()
		{
			return StaticRepositories.StatusZahtjevaRepository.GetItem(x => x.m_iID == m_iStatus).m_strStatusText;
		}
		/// <summary>
		/// Ova metoda vraća ime i prezime odgovorne osobe
		/// Pošto se dodani korisnici mogu mijenjati tijekom izvođenja programa
		/// Moramo ponovno provijeriti bazu podataka tijekom runtime-a
		/// </summary>
		/// <returns></returns>
		public string GetApproverName()
		{
			if( m_iIDApprover <= 0 )
				return "";

			var user = KorisnikRepository.GetUser(m_iIDApprover);

			// Set the formatted value to the translated string
			return user.m_strIme + " " + user.m_strPrezime;
		}
	}
}
