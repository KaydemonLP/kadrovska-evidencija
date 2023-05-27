using DBLayer;
using Evaluation_Manager.models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kadrovska.models;
using Kadrovska.Auth;

namespace Evaluation_Manager.staticrepositories
{
    public class CStaticRepository<T>
    {
        public CStaticRepository( string strDatabaseName )
        {
            m_strDatabaseName = strDatabaseName;

		}

		private List<T> m_aList = new List<T>();
        private string m_strDatabaseName;

        public List<T> GetList() { return m_aList; }
		public T GetItem(Predicate<T> match){ return m_aList.Find(match); }

		private string GetDatabaseName() { return m_strDatabaseName; }
        public void SetDatabaseName(string name) { m_strDatabaseName = name; }

        public void FetchData()
        {
            m_aList.Clear();

			string sql = $"SELECT * FROM {GetDatabaseName()}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                T obj = CreateObject(reader);
                m_aList.Add(obj);
            }

            reader.Close();
            DB.CloseConnection();
        }

        public T CreateObject(SqlDataReader reader)
        {
            T obj = (T)Activator.CreateInstance(typeof(T));
            ((IStaticRepositoryItem)obj).SetWithSQLReader(reader);
            return obj;
        }
    } //public class StaticRepository

    public static class StaticRepositories
	{
		public static CStaticRepository<CVrstaZahtjeva> VrstaZahtjevaRepository = new CStaticRepository<CVrstaZahtjeva>("VrstaZahtjeva");
		public static CStaticRepository<CStatusZahtjeva> StatusZahtjevaRepository = new CStaticRepository<CStatusZahtjeva>("StatusZahtjeva");

	}
}
