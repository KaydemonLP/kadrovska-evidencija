using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
