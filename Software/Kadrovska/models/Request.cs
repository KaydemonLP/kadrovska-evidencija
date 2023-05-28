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

		public bool IsAwaitingApproval()
		{
			return m_iStatus == 1;
		}

		public string GetTypeName()
		{
			return StaticRepositories.VrstaZahtjevaRepository.GetItem(x => x.m_iID == m_iType).m_strName;
		}

		public string GetStatusText()
		{
			return StaticRepositories.StatusZahtjevaRepository.GetItem(x => x.m_iID == m_iStatus).m_strStatusText;
		}

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
