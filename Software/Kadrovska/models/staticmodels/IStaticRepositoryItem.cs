using System.Data.SqlClient;

namespace Kadrovska.models
{
	/// <summary>
	/// Baza za statične objekte repozitorija
	/// Mora postojati tako da možemo čitati druge podatke
	/// Ovisno o klasi
	/// </summary>
	public interface IStaticRepositoryItem
	{
		void SetWithSQLReader(SqlDataReader reader);
	}
}
