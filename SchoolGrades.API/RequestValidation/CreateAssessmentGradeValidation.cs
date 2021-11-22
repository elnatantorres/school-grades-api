using SchoolGrades.API.Models;
using System;
using System.Collections.Generic;

namespace SchoolGrades.API.RequestValidation
{
    public class CreateAssessmentGradeValidation
    {
        public static Notification ValidateRequest(AssessmentGrade grade)
        {
            List<string> subjects = new List<string>();
            subjects.Add("mathematics");
            subjects.Add("biology");
            subjects.Add("philosophy");
            subjects.Add("portuguese");
            subjects.Add("physics");
            subjects.Add("sociology");
            subjects.Add("physical education");
            subjects.Add("geography");
            subjects.Add("history");
            subjects.Add("chemistry");

            Notification notification = new Notification();

            if (grade.Assessment != "P1" && grade.Assessment != "P2" && grade.Assessment != "P3")
                notification.Add(nameof(grade.Assessment), "The value of assessment is not valid.");

            if (!DateTime.TryParse(grade.AssessmentDate, out _))
                notification.Add(nameof(grade.AssessmentDate), "The value of assessment date is not valid.");

            if (grade.Grade < 0 || grade.Grade > 10)
                notification.Add(nameof(grade.Grade), "The value of grade is not valid.");

            if (!DateTime.TryParse(grade.GradeDate, out _))
                notification.Add(nameof(grade.GradeDate), "The value of grade date is not valid.");

            if (!subjects.Contains(grade.Subject.ToLower()))
                 notification.Add(nameof(grade.Subject), "The subject is not valid.");

            return notification;

        }
    }
}
