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

namespace Evaluation_Manager
{
    public partial class FrmStudents : Form
    {
        public FrmStudents()
        {
            InitializeComponent();
        }

        private void FrmStudents_Load(object sender, EventArgs e)
        {
            ShowStudents();
        }

        private void ShowStudents()
        {
            var students = StudentRepository.GetStudents();
            dgvStudents.DataSource = students;

            dgvStudents.Columns["m_iID"].DisplayIndex = 0;
            dgvStudents.Columns["m_strFirstName"].DisplayIndex = 1;
            dgvStudents.Columns["m_strLastName"].DisplayIndex = 2;
            dgvStudents.Columns["m_iGrade"].DisplayIndex = 3;
        }

        private void btnEvaluateStudent_Click(object sender, EventArgs e) {
            CStudent selectedStudent = dgvStudents.CurrentRow.DataBoundItem as CStudent;

            FrmEvaluation frmEvaluation = new FrmEvaluation(selectedStudent);

            Hide();
            frmEvaluation.ShowDialog();
            Show();
        }

        private void btnGenerateEvaluationReport_Click(object sender, EventArgs e)
        {
            FrmFinalReport frmFinalReport = new FrmFinalReport(this);
            frmFinalReport.ShowDialog();
            Show();
        }
    }
}
