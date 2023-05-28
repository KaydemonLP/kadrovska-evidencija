using System.Data.SqlClient;

namespace Kadrovska.models
{
	public class CStatusZahtjeva : IStaticRepositoryItem
	{
		public int m_iID
		{
			get;set;
		}
		public string m_strStatusText
		{
			get; set;
		}
		public void SetWithSQLReader(SqlDataReader reader)
		{
			m_iID = int.Parse(reader["ID"].ToString());
			m_strStatusText = reader["StatusTxt"].ToString();
		}
	}
}
