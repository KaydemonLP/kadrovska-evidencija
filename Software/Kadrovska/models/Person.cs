using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager.models
{
    public abstract class CPerson
    {
        [DisplayName("ID")]
        public int m_iID
        {
            get;// { return m_iID }
            set;// { m_iID = value }
        }

        [DisplayName("First Name")]
        public string m_strFirstName
        {
            get; set;
        }

        [DisplayName("Last Name")]
        public string m_strLastName
        {
           get; set;
        }

        public override string ToString()
        {
            return m_strFirstName + " " + m_strLastName;
        }
    }
}
