using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadrovska.models
{
    public class CRequest
    {
        public int m_iID;
        public DateTime m_datCreationTime;
        public int m_iType;
        public DateTime m_datStart;
        public DateTime m_datEnd;
        public string m_strDescription;
        public int m_iIDUser;
        public int m_iStatus;
        public DateTime m_datLastModified;
        public int m_iIDApprover;
    }
}
