using System.Data.SqlClient;

namespace Kadrovska.models
{
	public interface IStaticRepositoryItem
	{
		void SetWithSQLReader(SqlDataReader reader);
	}
}
