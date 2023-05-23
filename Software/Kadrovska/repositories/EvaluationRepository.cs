using DBLayer;
using Evaluation_Manager.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager.repositories {
    public static class EvaluationRepository
    {
        public static CEvaluation GetEvaluation(CStudent student, CActivity activity) {
            CEvaluation evaluation = null;
            string sql = $"SELECT * FROM Evaluations WHERE IdStudents = {student.m_iID} AND IdActivities = {activity.m_iID}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows) {
                reader.Read();
                evaluation = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return evaluation;
        }

        public static List<CEvaluation> GetEvaluations(CStudent student) {
            List<CEvaluation> evaluations = new List<CEvaluation>();

            string sql = $"SELECT * FROM Evaluations WHERE IdStudents = {student.m_iID}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read()) {
                CEvaluation evaluation = CreateObject(reader);
                evaluations.Add(evaluation);
            }

            reader.Close();
            DB.CloseConnection();

            return evaluations;
        }

        private static CEvaluation CreateObject(SqlDataReader reader) {
            int idActivities = int.Parse(reader["IdActivities"].ToString());
            var activity = ActivityRepository.GetActivity(idActivities);

            int idStudents = int.Parse(reader["IdStudents"].ToString());
            var student = StudentRepository.GetStudent(idStudents);

            int idTeachers = int.Parse(reader["IdTeachers"].ToString());
            var teacher = TeacherRepository.GetTeacher(idTeachers);

            DateTime evaluationDate =
                     DateTime.Parse(reader["EvaluationDate"].ToString());
            int points = int.Parse(reader["Points"].ToString());

            var evaluation = new CEvaluation
            {
                m_Activity = activity,
                m_Student = student,
                m_Evaluator = teacher,
                m_dateEvaluationDate = evaluationDate,
                m_iPoints = points
            };

            return evaluation;
        }

        public static void InsertEvaluation(CStudent student,CActivity activity, CTeacher teacher, int points) {
            string sql = $"INSERT INTO Evaluations (IdActivities, IdStudents, IdTeachers, EvaluationDate, Points) VALUES ({activity.m_iID}, {student.m_iID}, {teacher.m_iID}, GETDATE(), {points})";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public static void UpdateEvaluation(CEvaluation evaluation, CTeacher teacher, int points) {
            string sql = $"UPDATE Evaluations SET IdTeachers = {teacher.m_iID},  Points = {points}, EvaluationDate = GETDATE() WHERE IdActivities = {evaluation.m_Activity.m_iID} AND IdStudents = {evaluation.m_Student.m_iID}";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
    }
}
