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

namespace Evaluation_Manager.repositories
{
    public static class KorisnikRepository
    {
		public static CKorisnik GetUser( string authCode )
        {
            CKorisnik user = null;

            string sql = $"SELECT * FROM Korisnici WHERE GoogleAuthCode = '{authCode}'";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if( reader.HasRows )
            {
                reader.Read();
                user = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return user;
        } //public static Student GetStudent

		public static CKorisnik GetUser(int id)
		{
			CKorisnik user = null;

			string sql = $"SELECT * FROM Korisnici WHERE ID = '{id}'";
			DB.OpenConnection();
			var reader = DB.GetDataReader(sql);
			if (reader.HasRows)
			{
				reader.Read();
				user = CreateObject(reader);
				reader.Close();
			}

			DB.CloseConnection();
			return user;
		} //public static Student GetStudent

		public static List<CKorisnik> GetUsers()
        {
            var users = new List<CKorisnik>();

            string sql = "SELECT * FROM Korisnici";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                CKorisnik user = CreateObject(reader);
                users.Add(user);
            }

            reader.Close();
            DB.CloseConnection();

            return users;
        } //public static List

        private static CKorisnik CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["ID"].ToString());
            string firstName = reader["Ime"].ToString();
            string lastName = reader["Prezime"].ToString();

            DateTime datRodendan;
            try
            {
                datRodendan = DateTime.Parse(reader["DatRodendan"].ToString());
            }
            catch (Exception)
            {
                datRodendan = new DateTime();
            }
            
            string googleAuthCode = reader["GoogleAuthCode"].ToString();


            var korisnik = new CKorisnik
            {
                m_iID = id,
                m_strIme = firstName,
                m_strPrezime = lastName,
                m_datRodendan = datRodendan,
                m_strGoogleAuthCode = googleAuthCode
            };

            return korisnik;
        } //private static Student

        public static void InsertUser(UserCredential userCredential, GoogleJsonWebSignature.Payload userInfo)
        {
            string sql = $"INSERT INTO Korisnici (Ime, Prezime, GoogleAuthCode) VALUES ('{userInfo.GivenName}', '{userInfo.FamilyName}', '{userInfo.Subject}' )";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public static void UpdateUser(GoogleJsonWebSignature.Payload userInfo, DateTime date)
        {
            string sql = $"UPDATE Korisnici SET Ime = '{userInfo.GivenName}', Prezime = '{userInfo.FamilyName}', DatRodendan = '{date}' WHERE GoogleAuthCode = '{userInfo.Subject}'";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
    } //public class KorisnikRepository
}
