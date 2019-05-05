using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student_Evaluation_3.Models;
using Microsoft.EntityFrameworkCore;
using Student_Evaluation_3.Data;
using Student_Evaluation_3.ActionFilters;

namespace Student_Evaluation_3.Controllers
{
    
    public class EvaluationController : Controller
    {
        private SchoolContext db;
        public EvaluationController(SchoolContext SchoolContext)
        {
            db = SchoolContext;
        }

        [TypeFilter(typeof(EditFilter))]
        public IActionResult Eval()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editedCourse = db.Courses.Where(c => c.CourseID == id).FirstOrDefault();
            return View(editedCourse);
        }

        [HttpPost]
        [StudentFilter]
        public IActionResult Edit(Evaluation input)
        {
            db.Evaluations.Add(input);
            db.SaveChanges();
            return RedirectToAction("Main", "Evaluation");
        }

        //[UserLoginFilter]
        public IActionResult Main()
        {
            IEnumerable<Course> courses;
            if (HttpContext.User.HasClaim("Role", "Student"))
            {
                string StudentID = HttpContext.User.Claims.Where(c => c.Type == "StudentID").Select(t => t.Value).FirstOrDefault();
                IQueryable<int> CourseIDs = db.Enrollments.Where(c => c.StudentID.ToString() == StudentID).Select(t => t.CourseID);
                List<Course> CoursesForStudent = db.Courses.Where(c => CourseIDs.Contains(c.CourseID)).ToList<Course>();
                courses = CoursesForStudent;

            }
            else
            {
                string InstructorID = HttpContext.User.Claims.Where(c => c.Type == "InstructorID").Select(t => t.Value).FirstOrDefault();
                IQueryable<int> CourseIDs = db.Stakeholders.Where(c => c.InstructorID.ToString() == InstructorID).Select(t => t.CourseID);
                List<Course> CoursesForInstructor = db.Courses.Where(c => CourseIDs.Contains(c.CourseID)).ToList<Course>();
                courses = CoursesForInstructor;
            }
            return View(courses);
        }

    }
}