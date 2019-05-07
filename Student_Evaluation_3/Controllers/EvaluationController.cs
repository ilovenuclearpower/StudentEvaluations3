using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student_Evaluation_3.Models;
using Microsoft.EntityFrameworkCore;
using Student_Evaluation_3.Data;
using Student_Evaluation_3.ActionFilters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Student_Evaluation_3.Security;

namespace Student_Evaluation_3.Controllers
{
    
    public class EvaluationController : Controller
    {
        private SchoolContext db;
        public EvaluationController(SchoolContext SchoolContext)
        {
            db = SchoolContext;
        }

        [Student_Evaluation_3.ActionFilters.InstructorFilter]
        public IActionResult EvalList(int id)
        {
            List<Evaluation> evals;
            if (HttpContext.User.IsInRole("Student"))
            {
                return Eval(id);
            }
            else
            {
                Stakeholder stakeholder = db.Stakeholders.Where(e => e.CourseID == id && e.InstructorID == int.Parse(HttpContext.User.Claims.Where(u => u.Type == "InstructorID").Select(u => u.Value).FirstOrDefault())).FirstOrDefault();
                Instructor instructor = db.Instructors.Where(i => i.InstructorID == stakeholder.InstructorID.ToString()).FirstOrDefault();
                evals = db.Evaluations.Where(e => e.CourseID == id && e.Instructors.Contains(instructor)).ToList();
            }
            return View(evals);
        }

        public IActionResult Eval(int id)
        {
            if (HttpContext.User.IsInRole("Instructor"))
            {
                return EvalList(id);
            }
            else
            {

                Evaluation eval = db.Evaluations.Where(e => (e.StudentID == int.Parse(HttpContext.User.Claims.Where(u => u.Type == "StudentID").Select(u => u.Value).FirstOrDefault())) && e.CourseID == id).FirstOrDefault();
                if (string.IsNullOrEmpty(eval.why_course))
                {
                    return Edit(id);
                }
                return View(eval);
            }
        }



        [HttpGet]
        [StudentFilter]
        public IActionResult Edit(int id)
        {
            Evaluation editedCourse = db.Evaluations.Where(e => (e.StudentID == int.Parse(HttpContext.User.Claims.Where(u => u.Type == "StudentID").Select(u => u.Value).FirstOrDefault())) && e.CourseID == id).FirstOrDefault();
            return View(editedCourse);
        }

        [HttpPost]
        public IActionResult Edit(Evaluation input)
        {
            db.Evaluations.Add(input);
            db.SaveChanges();
            return RedirectToAction("Main", "Evaluation");
        }

        [Authorize(Roles = "User")]
        public IActionResult Main()
        {
            IEnumerable<Course> courses;
            if (HttpContext.User.IsInRole("Student"))
            {
                var principal = HttpContext.User;
                ClaimsIdentity identity = principal.Identities.FirstOrDefault();
                Claim claim = identity.FindFirst(CustomClaimTypes.StudentID);
                int StudentID = int.Parse(claim.Value);
                System.Diagnostics.Debug.WriteLine(StudentID);
                IQueryable<int> CourseIDs = db.Enrollments.Where(c => c.StudentID == StudentID).Select(t => t.CourseID);
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