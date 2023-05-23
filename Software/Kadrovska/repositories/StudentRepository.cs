using DBLayer;
using Evaluation_Manager.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager.repositories
{
    public static class StudentRepository
    {
        public static CStudent GetStudent(int id)
        {
            CStudent student = null;

            string sql = $"SELECT * FROM Students WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                student = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return student;
        } //public static Student GetStudent

        public static List<CStudent> GetStudents()
        {
            var students = new List<CStudent>();

            string sql = "SELECT * FROM Students";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                CStudent student = CreateObject(reader);
                students.Add(student);
            }

            reader.Close();
            DB.CloseConnection();

            return students;
        } //public static List

        private static CStudent CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string firstName = reader["FirstName"].ToString();
            string lastName = reader["LastName"].ToString();
            int grade = 0;
            try
            {
                grade = int.Parse(reader["Grade"].ToString());

            }
            catch (Exception)
            {
                // Neki studenti imaju NULL grade
            }


            var student = new CStudent
            {
                m_iID = id,
                m_strFirstName = firstName,
                m_strLastName = lastName,
                m_iGrade = grade
            };

            return student;
        } //private static Student

    } //public class StudentRepository
}
