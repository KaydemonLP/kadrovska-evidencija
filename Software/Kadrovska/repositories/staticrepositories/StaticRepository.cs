using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Kadrovska.models;

namespace Kadrovska.staticrepositories
{
    public class CStaticRepository<T>
    {
        /// <summary>
        /// Konstruktor
        /// Postavlja ime tablice koju će ovaj repozitorij čitati
        /// </summary>
        /// <param name="strDatabaseName"></param>
        public CStaticRepository( string strDatabaseName )
        {
            m_strDatabaseName = strDatabaseName;

		}

		private List<T> m_aList = new List<T>();
        private string m_strDatabaseName;
        /// <summary>
        /// Vraća listu objekata tablice
        /// </summary>
        /// <returns></returns>
        public List<T> GetList() { return m_aList; }
        /// <summary>
        /// Nađe i vraća objekt koji odgovara funkciji pretraživanja
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
		public T GetItem(Predicate<T> match){ return m_aList.Find(match); }
        /// <summary>
        /// Ova metoda vraća ime tablice koju koristimo
        /// </summary>
        /// <returns></returns>
		private string GetDatabaseName() { return m_strDatabaseName; }
		/// <summary>
		/// Ova metoda postavlja ime tablice koju koristimo
		/// </summary>
		/// <returns></returns>
		public void SetDatabaseName(string name) { m_strDatabaseName = name; }
		/// <summary>
		/// Ova metoda čita sve retke naše tablice i spremi ih u listu
		/// </summary>
		/// <returns></returns>
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
        /// <summary>
        /// Ova metoda kreira objekt te ga ispuni podatkima učitanim u SQL reader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public T CreateObject(SqlDataReader reader)
        {
            T obj = (T)Activator.CreateInstance(typeof(T));
            ((IStaticRepositoryItem)obj).SetWithSQLReader(reader);
            return obj;
        }
    } //public class StaticRepository

    /// <summary>
    /// Ova klasa kreira i drži sve repozitorije koji se ne mijenjaju tijekom izvodbe programa
    /// </summary>
    public static class StaticRepositories
	{
		public static CStaticRepository<CVrstaZahtjeva> VrstaZahtjevaRepository = new CStaticRepository<CVrstaZahtjeva>("VrstaZahtjeva");
		public static CStaticRepository<CStatusZahtjeva> StatusZahtjevaRepository = new CStaticRepository<CStatusZahtjeva>("StatusZahtjeva");

	}
}
