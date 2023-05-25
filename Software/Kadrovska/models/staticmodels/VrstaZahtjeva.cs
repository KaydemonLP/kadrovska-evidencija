using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadrovska.models
{
	public class CVrstaZahtjeva : IStaticRepositoryItem
	{
		public int m_iID
		{
			get;set;
		}
		public string m_strName
		{
			get; set;
		}

		override public string ToString()
		{
			return m_strName;
		}

		public void SetWithSQLReader(SqlDataReader reader)
		{
			m_iID = int.Parse(reader["ID"].ToString());
			m_strName = reader["Ime"].ToString();
		}
	}
}
