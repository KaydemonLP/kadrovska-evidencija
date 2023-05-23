using DBLayer;
using Evaluation_Manager.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Evaluation_Manager.repositories
{
    public static class TeacherRepository 
    {
        public static CTeacher GetTeacher(string username)
        {
            string sql = $"SELECT * FROM Teachers WHERE Username = '{username}'";
            return FetchTeacher(sql);
        }

        public static CTeacher GetTeacher(int id)
        {
            string sql = $"SELECT * FROM Teachers WHERE Id = {id}";
            return FetchTeacher(sql);
        }

        private static CTeacher FetchTeacher(string sql) 
        {
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            CTeacher teacher = null;

            if( reader.HasRows ) 
            {
                reader.Read();
                teacher = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();

            return teacher;
        }

        private static CTeacher CreateObject(SqlDataReader reader) 
        {
            int id = int.Parse(reader["Id"].ToString());
            string firstName = reader["FirstName"].ToString();
            string lastName = reader["LastName"].ToString();
            string username = reader["Username"].ToString();
            string password = reader["Password"].ToString();

            var teacher = new CTeacher 
            {
                m_iID = id,
                m_strFirstName = firstName,
                m_strLastName = lastName,
                m_strUsername = username,
                m_strPassword = password
            };

            return teacher;
        }

    }
}
