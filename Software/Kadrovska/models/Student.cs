using Evaluation_Manager.repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager.models
{
    public class CStudent : CPerson
    {
        [DisplayName("Grade")]
        public int m_iGrade
        {
            get; set;
        }

        public List<CEvaluation> GetEvaluations()
        {
            return EvaluationRepository.GetEvaluations(this);
        }

        public int CalculateTotalPoints() 
        {
            int totalPoints = 0;

            foreach( var evaluation in GetEvaluations() )
            {
                totalPoints += evaluation.m_iPoints;
            }

            return totalPoints;
        }

        private bool IsEvaluationComplete()
        {
            var evaluations = GetEvaluations();
            var activities = ActivityRepository.GetActivities();

            return evaluations.Count == activities.Count;
        }

        public bool HasSignature()
        {
            if( !IsEvaluationComplete() )
                return false;

            foreach( var evaluation in GetEvaluations() )
            {
                if( !evaluation.IsSufficientForSignature() )
                    return false;
            }

            return true;
        }

        public bool HasGrade()
        {
            if( !IsEvaluationComplete() )
                return false;

            foreach( var evaluation in GetEvaluations() )
            {
                if( !evaluation.IsSufficientForGrad() )
                    return false;
            }

            return true;
        }

        public int CalculateGrade()
        {
            if( !HasGrade() )
                return 0;

            int iTotalPoints = CalculateTotalPoints();

            if( iTotalPoints >= 91 )
                return 5;

            if( iTotalPoints >= 76 )
                return 4;
            
            if( iTotalPoints >= 61 )
                return 3;

            if( iTotalPoints >= 50 )
                return 2;

            return 1;
        }
    }
}
