using DBLayer;
using Evaluation_Manager.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Evaluation_Manager.repositories {
    public static class ActivityRepository {
        public static CActivity GetActivity(int id) {
            CActivity activity = null;

            string sql = $"SELECT * FROM Activities WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows) {
                reader.Read();
                activity = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return activity;
        } //public static activity GetActivity

        public static List<CActivity> GetActivities() {
            var activities = new List<CActivity>();

            string sql = "SELECT * FROM Activities";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read()) {
                CActivity activity = CreateObject(reader);
                activities.Add(activity);
            }

            reader.Close();
            DB.CloseConnection();

            return activities;
        } //public static List

        private static CActivity CreateObject(SqlDataReader reader) {
            int id = int.Parse(reader["Id"].ToString());
            string name = reader["Name"].ToString();
            string description = reader["Description"].ToString();
            int maxPoints = int.Parse(reader["MaxPoints"].ToString());
            int minPointsGrade = int.Parse(reader["MinPointsForGrade"].ToString());
            int minPoitnsSignature = int.Parse(reader["MinPointsforSignature"].ToString());

            var activity = new CActivity {
                m_iID = id,
                m_strName = name,
                m_strDescription = description,
                m_iMaxPoints = maxPoints,
                m_iMinPointsGrade = minPointsGrade,
                m_iMinPointsSignature = minPoitnsSignature,
            };

            return activity;
        }

    }
}
