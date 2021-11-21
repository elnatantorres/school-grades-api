using Google.Cloud.Firestore;
using System;

namespace SchoolGrades.API.Models
{
    [FirestoreData]
    public class AssessmentGrade
    {
        /// <summary>
        /// The assessment id.
        /// </summary>
        public string AssessmentId { get; set; }
        /// <summary>
        /// The evaluated assessment.
        /// </summary>
        [FirestoreProperty]
        public string Assessment { get; set; }

        /// <summary>
        /// The assessment date.
        /// </summary>
        [FirestoreProperty]
        public string AssessmentDate { get; set; }

        /// <summary>
        /// The grade of the assessment.
        /// </summary>
        [FirestoreProperty]
        public float Grade { get; set; }

        /// <summary>
        /// The date which the grade was given.
        /// </summary>
        [FirestoreProperty]
        public string GradeDate { get; set; }

        /// <summary>
        /// The name of the evaluated student.
        [FirestoreProperty]
        public string StudentName { get; set; }

        /// <summary>
        /// The evaluated subject.
        /// </summary>
        [FirestoreProperty]
        public string Subject { get; set; }

        /// <summary>
        /// The teacher who performed the evaluation.
        /// </summary>
        [FirestoreProperty]
        public string Teacher { get; set; }
    }
}
