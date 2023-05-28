using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Kadrovska.models;

namespace Kadrovska.repositories
{
    public static class ZahtjevRepository
    {
		/// <summary>
		/// Vraća zahtjev kojem odgovara korisniku sa danim autentifikacijskim kodom
		/// </summary>
		/// <param name="authCode"></param>
		/// <returns></returns>
		public static CRequest GetRequest( string authCode )
        {
            CRequest request = null;

            string sql = $"SELECT * FROM Zahtjevi WHERE GoogleAuthCode = '{authCode}'";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if( reader.HasRows )
            {
                reader.Read();
                request = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return request;
        } //public static Student GetStudent
        /// <summary>
        /// Vraća listu SVIH zahtjeva
        /// </summary>
        /// <returns></returns>
        public static List<CRequest> GetRequests()
        {
            var requests = new List<CRequest>();

            string sql = "SELECT * FROM Zahtjevi";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                CRequest request = CreateObject(reader);
                requests.Add(request);
            }

            reader.Close();
            DB.CloseConnection();

            return requests;
        } //public static List
        /// <summary>
        /// Vraća listu zahtjeva koji odgovaraju korisniku sa danim internim ID-jom
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
		public static List<CRequest> GetRequests( int iUserID )
		{
			var requests = new List<CRequest>();

			string sql = $"SELECT * FROM Zahtjevi WHERE IDKorisnika ={iUserID}";

			DB.OpenConnection();
			var reader = DB.GetDataReader(sql);
			while (reader.Read())
			{
				CRequest request = CreateObject(reader);
				requests.Add(request);
			}

			reader.Close();
			DB.CloseConnection();

			return requests;
		} //public static List
		/// <summary>
		///  Kreira objekt klase CRequest te u isti učita podatke sa Baze
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		private static CRequest CreateObject(SqlDataReader reader)
        {         
            int iID = int.Parse(reader["ID"].ToString());
            int iIDUser = int.Parse(reader["IDKorisnika"].ToString());
            DateTime datCreationTime;
            try
            {
                datCreationTime = DateTime.Parse(reader["DatumDavanjaZahtjeva"].ToString());
            }
            catch (Exception)
            {
                datCreationTime = new DateTime();
            }
            int iType = int.Parse(reader["IDVrsteZahtjeva"].ToString());
            DateTime datStart;
            try
            {
                datStart = DateTime.Parse(reader["PocetakOdsustva"].ToString());
            }
            catch (Exception)
            {
                datStart = new DateTime();
            }
            DateTime datEnd;
            try
            {
                datEnd = DateTime.Parse(reader["KrajOdsustva"].ToString());
            }
            catch (Exception)
            {
                datEnd = new DateTime();
            }

            string strDescription = reader["Opis"].ToString();

            int iStatus = int.Parse(reader["StatusZahtjeva"].ToString());

            DateTime datLastModified;
            try
            {
                datLastModified = DateTime.Parse(reader["DatumPromjeneZahtjeva"].ToString());
            }
            catch (Exception)
            {
                datLastModified = new DateTime();
            }
            int iIDApprover;
			try
            {
                iIDApprover = int.Parse(reader["IDOdobrivatelja"].ToString());
            }
            catch (Exception)
            {
				iIDApprover = -1;
            }

			var korisnik = new CRequest
            {
                m_iID = iID,
                m_datCreationTime = datCreationTime,
                m_iType = iType,
                m_datStart = datStart,
                m_datEnd = datEnd,
                m_strDescription = strDescription,
                m_iIDUser = iIDUser,
                m_iStatus = iStatus,
                m_datLastModified = datLastModified,
                m_iIDApprover = iIDApprover,
            };

            return korisnik;
        } //private static Student
        /// <summary>
        /// Dodaje dani zahtjev u bazu podataka
        /// Pošto je opis text box sa bilo kojim upitom
        /// Očisti mu ' kako nebi korisnik mogao napraviti SQL injection
        /// 
        /// Osobno bi to napravio pomomču @ parametra ali nam DB dll to ne omogućava
        /// </summary>
        /// <param name="request"></param>
        public static void InsertRequest( CRequest request )
        {
            string sql = $"INSERT INTO Zahtjevi (";
            sql += "IDKorisnika, DatumDavanjaZahtjeva, ";
            sql += "IDVrsteZahtjeva, PocetakOdsustva, KrajOdsustva, ";
            sql += "Opis, StatusZahtjeva) ";
            sql += "VALUES (";
            sql += $"{request.m_iIDUser}, ";
            sql += $"GETDATE(), ";
            sql += $"{request.m_iType}, ";
            sql += $"'{request.m_datStart.Date.ToString("yyyy-MM-dd")}', ";
            sql += $"'{request.m_datEnd.Date.ToString("yyyy-MM-dd")}', ";
            sql += $"'{request.m_strDescription.Replace("'", "''")}', ";
            sql += $"1 ";
            sql += $")";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
        /// <summary>
        /// Ova funkcija nam služi da ažuriramo upit sa danim ID-jem
        /// Koristi informacije novog CRequest-a
        ///
        /// Samo dodaje odgovornu osobu ako je navedena
        /// </summary>
        /// <param name="request"></param>
        /// <param name="iID"></param>
        public static void UpdateRequest(CRequest request, int iID)
        {
            string sql = $"UPDATE Zahtjevi SET ";
			sql += $"IDKorisnika = '{request.m_iIDUser}', ";
			sql += $"IDVrsteZahtjeva = {request.m_iType}, ";
			sql += $"PocetakOdsustva = '{request.m_datStart.ToString("yyyy-MM-dd")}', ";
			sql += $"KrajOdsustva = '{request.m_datEnd.ToString("yyyy-MM-dd")}', ";
			sql += $"StatusZahtjeva = 1 ,";
			sql += $"DatumPromjeneZahtjeva = GETDATE() ,";
			sql += $"Opis = '{request.m_strDescription.Replace("'", "''")}' ";

            if( request.m_iIDApprover > 0 )
			    sql += $",IDOdobrivatelja = {request.m_iIDApprover} ";

			sql += $" WHERE ID = {iID};";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
        /// <summary>
        /// Ova metoda uklanja dani zahtjev
        /// </summary>
        /// <param name="iID"></param>
		public static void DeleteRequest(int iID)
		{
			string sql = $"DELETE FROM Zahtjevi WHERE ID={iID};";
			DB.OpenConnection();
			DB.ExecuteCommand(sql);
			DB.CloseConnection();
		}
	} //public class ZahtjevRepository
}
