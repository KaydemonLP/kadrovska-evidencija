using Evaluation_Manager.models;
using Evaluation_Manager.repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager {
    public partial class FrmFinalReport : Form {
        public FrmFinalReport(Form lastform) {
            m_LastForm = lastform;
            InitializeComponent();
        }

        Form m_LastForm;

        private void btnClose_Click(object sender, EventArgs e) 
        {
            Close();
        }

        private List<CStudentReportView> GenerateStudentReport()
        {
            var allStudents = StudentRepository.GetStudents();
            var examReports = new List<CStudentReportView>();

            foreach( var student in allStudents )
            {
                if( !student.HasSignature() )
                    continue;

                var examReport = new CStudentReportView(student);
                examReports.Add(examReport);
            }

            return examReports;

        }

        private void FrmFinalReport_Load(object sender, EventArgs e)
        {
            var results = GenerateStudentReport();
            dgvResults.DataSource = results;

            m_LastForm.Hide();
        }
    }
}
