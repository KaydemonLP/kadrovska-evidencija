using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager.models 
{
    public class CActivity 
    {
        public int m_iID {
            get; set;
        }

        public string m_strName { 
            get; set; 
        }
        public string m_strDescription { 
            get; set; 
        }

        public int m_iMaxPoints {
            get;set;
        }

        public int m_iMinPointsGrade {
            get; set;
        }
        public int m_iMinPointsSignature {
            get; set;
        }

        public override string ToString() {
            return m_strName;
        }
    }
}
