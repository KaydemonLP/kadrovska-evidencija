using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager.models 
{
    public class CEvaluation 
    {
        public CActivity m_Activity { 
            get; set; 
        }
        public CStudent m_Student { 
            get; set; 
        }

        public CTeacher m_Evaluator { 
            get; set; 
        }
        public DateTime m_dateEvaluationDate {
            get; set;
        }
        public int m_iPoints {
            get; set;
        }

        public bool IsSufficientForSignature() {
            return m_iPoints >= m_Activity.m_iMinPointsSignature;
        }

        public bool IsSufficientForGrad() {
            return m_iPoints >= m_Activity.m_iMinPointsGrade;
        }
    }
}
