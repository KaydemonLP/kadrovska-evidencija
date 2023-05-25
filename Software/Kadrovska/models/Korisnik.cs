using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadrovska.models
{
    public class CKorisnik
    {
        public int m_iID
        {
            get;set;
        }
        public string m_strIme
		{
			get; set;
		}
		public string m_strPrezime
		{
			get; set;
		}
		public DateTime m_datRodendan
		{
			get; set;
		}
		public string m_strGoogleAuthCode
		{
			get; set;
		}
	}
}
