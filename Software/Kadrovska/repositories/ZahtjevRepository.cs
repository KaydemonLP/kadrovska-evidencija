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
using System.Security.Cryptography;

namespace Evaluation_Manager.repositories
{
    public static class ZahtjevRepository
    {
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
            sql += $"'{request.m_strDescription}', ";
            sql += $"1 ";
            sql += $")";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public static void UpdateRequest(CRequest request, int iID)
        {
            string sql = $"UPDATE Zahtjevi SET ";
			sql += $"IDKorisnika = '{request.m_iIDUser}', ";
			sql += $"IDVrsteZahtjeva = {request.m_iType}, ";
			sql += $"PocetakOdustva = '{request.m_datStart.ToString("yyyy-MM-dd")}', ";
			sql += $"KrajOdsustva = '{request.m_datEnd.ToString("yyyy-MM-dd")}', ";
			sql += $"Opis = '{request.m_strDescription}', ";
			sql += $"StatusZahtjeva = 1, ";
			sql += $"DatumPromjeneZahtjeva = GETDATE(), ";
			sql += $"IDOdobrivatelja = {request.m_iIDApprover}, ";
			sql += $" WHERE ID = {iID}";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
    } //public class ZahtjevRepository
}
