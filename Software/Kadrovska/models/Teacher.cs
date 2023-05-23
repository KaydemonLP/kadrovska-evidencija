using Evaluation_Manager.repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager.models
{
    public class CTeacher : CPerson
    {
        [DisplayName("Username")]
        public string m_strUsername
        {
            get; set;
        }

        [DisplayName("Password")]
        public string m_strPassword
        {
            get; set;
        }   

        public bool CheckPassword( string password )
        {
            return password == m_strPassword;
        }

        public void PerformEvaluation( CStudent student, CActivity activity, int points )
        {
            CEvaluation evaluation = EvaluationRepository.GetEvaluation(student, activity);
            if( evaluation == null )
            {
                EvaluationRepository.InsertEvaluation(student, activity, this, points);
            }
            else
            {
                EvaluationRepository.UpdateEvaluation(evaluation, this, points);
            }
        }
    }
}
