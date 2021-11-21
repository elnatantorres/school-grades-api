using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolGrades.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SchoolGrades.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/assessment-grades")]
    [ApiVersion("1.0")]
    public class AssessmentGradeController : ControllerBase
    {
        private readonly FirestoreDb _firestoreDb;
        private string _credentialsDirectory = Directory.GetCurrentDirectory() + "/usjt-a3-332601-a3c49cdf4250.json";

        public AssessmentGradeController()
        {
            
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", _credentialsDirectory);
            _firestoreDb = FirestoreDb.Create("usjt-a3-332601");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Query gradeQuery = _firestoreDb.Collection("grade");
            QuerySnapshot snapshot = await gradeQuery.GetSnapshotAsync();

            List<AssessmentGrade> grades = new List<AssessmentGrade>();

            foreach(DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                if(documentSnapshot.Exists)
                {
                    Dictionary<string, object> gradesDict = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(gradesDict);

                    AssessmentGrade assessmentGrade = JsonConvert.DeserializeObject<AssessmentGrade>(json);
                    assessmentGrade.AssessmentId = documentSnapshot.Id;

                    grades.Add(assessmentGrade);
                }
            }

            return Ok(grades);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AssessmentGrade grade)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("grade");
            await collectionReference.AddAsync(grade);

            return Created("", "");
        }
    }
}
