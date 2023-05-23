using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager.models
{
    public class CStudentReportView
    {
        [DisplayName("First Name")]
        public string m_strFirstName { get; set; }
        [DisplayName("Last Name")]
        public string m_strLastName { get; set; }

        [DisplayName("Kolokvij 1")]
        public string m_strK1 { get; set; }
        [DisplayName("Kolokvij 2")]
        public string m_strK2 { get; set; }

        [DisplayName("Zadatak 1")]
        public string m_strZ1 { get; set; }
        [DisplayName("Zadatak 2")]
        public string m_strZ2 { get; set; }
        [DisplayName("Zadatak 3")]
        public string m_strZ3 { get; set; }

        [DisplayName("Has Signature")]
        public string m_strHasSignature { get; set; }
        [DisplayName("Has Grade")]
        public string m_strHasGrade { get; set; }

        [DisplayName("Total Points")]
        public int m_iTotalPoints { get; set; }
        [DisplayName("Grade")]
        public int? m_iGrade { get; set; }

        public CStudentReportView( CStudent student )
        {
            m_strFirstName = student.m_strFirstName;
            m_strLastName = student.m_strLastName;

            m_strHasSignature = student.HasSignature() ? "DA" : "NE";
            m_strHasGrade = student.HasGrade() ? "DA" : "NE";

            m_iTotalPoints = student.CalculateTotalPoints();
            m_iGrade = student.CalculateGrade();

            var evaluations = student.GetEvaluations();

            var kolokvij1 = evaluations.FirstOrDefault(e => e.m_Activity.m_strName == "Kolokvij 1");
            var kolokvij2 = evaluations.FirstOrDefault(e => e.m_Activity.m_strName == "Kolokvij 2");
            var zadaca1 = evaluations.FirstOrDefault(e => e.m_Activity.m_strName == "Zadaca 1");
            var zadaca2 = evaluations.FirstOrDefault(e => e.m_Activity.m_strName == "Zadaca 2");
            var zadaca3 = evaluations.FirstOrDefault(e => e.m_Activity.m_strName == "Zadaca 3");

            m_strK1 = kolokvij1 == null ? "-" : kolokvij1.m_iPoints.ToString();
            m_strK2 = kolokvij2 == null ? "-" : kolokvij2.m_iPoints.ToString();
            m_strZ1 = zadaca1 == null ? "-" : zadaca1.m_iPoints.ToString();
            m_strZ2 = zadaca2 == null ? "-" : zadaca2.m_iPoints.ToString();
            m_strZ3 = zadaca3 == null ? "-" : zadaca3.m_iPoints.ToString();
        }
    }
}
