using System.Data.SqlClient;

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
		/// <summary>
		/// Implementacija SetWithSQLReader metode
		/// Učita ID i Ime sa SQL Tablice
		/// </summary>
		/// <param name="reader"></param>
		public void SetWithSQLReader(SqlDataReader reader)
		{
			m_iID = int.Parse(reader["ID"].ToString());
			m_strName = reader["Ime"].ToString();
		}
	}
}
