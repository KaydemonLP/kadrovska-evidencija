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
    public partial class FrmEvaluation : Form {
        private CStudent m_Student;
        public FrmEvaluation(CStudent student) {
            InitializeComponent();
            m_Student = student;
        }

        public CActivity GetCurrentActivity() {
            var activities = ActivityRepository.GetActivities();
            return activities[cboActivities.SelectedIndex];
        }

        private void cboActivities_SelectedIndexChanged(object sender, EventArgs e) {
            var currentActivity = GetCurrentActivity();
            txtActivityDescription.Text = currentActivity.m_strDescription;
            txtMinforGrade.Text = currentActivity.m_iMinPointsGrade.ToString() + "/" + currentActivity.m_iMaxPoints.ToString();
            txtMinforSignature.Text = currentActivity.m_iMinPointsSignature.ToString() + "/" + currentActivity.m_iMaxPoints.ToString();

            numPoints.Minimum = 0;
            numPoints.Maximum = currentActivity.m_iMaxPoints;

            CEvaluation evaluation = EvaluationRepository.GetEvaluation(m_Student, currentActivity);

            if( evaluation != null )
            {
                txtTeacher.Text = evaluation.m_Evaluator.m_strFirstName + " " + evaluation.m_Evaluator.m_strLastName;
                txtEvaluationDate.Text = evaluation.m_dateEvaluationDate.ToLongDateString();
                numPoints.Value = evaluation.m_iPoints;
            }
            else
            {
                txtTeacher.Text = FrmLogin.m_LoggedTeacher.m_strFirstName + " " + FrmLogin.m_LoggedTeacher.m_strLastName;
                txtEvaluationDate.Text = "-";
                numPoints.Value = 0;
            }

            
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void FrmEvaluation_Load(object sender, EventArgs e) {
            SetFormText();

            var activities = ActivityRepository.GetActivities();
            cboActivities.DataSource = activities;
        }
        
        private void SetFormText() {
            Text = m_Student.m_strFirstName + " " + m_Student.m_strLastName;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            FrmLogin.m_LoggedTeacher.PerformEvaluation(m_Student, GetCurrentActivity(), (int)(numPoints.Value));
            Close();
        }
    }
}
