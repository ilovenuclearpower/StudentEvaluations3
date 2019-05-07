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
        
        [Authorize(Roles = "User")]
        public IActionResult EvalList(int id)
        {
            List<Evaluation> evals;
            if (HttpContext.User.IsInRole("Student"))
            {
                return Eval(FindEvalForStudent(id).EvaluationID);
            }
            else
            {
                Stakeholder stakeholder = FindStakeHolderForCourse(id);
                evals = FindStakeholderEvals(id, stakeholder).ToList();
            }
            return View(evals);
        }

        [Authorize(Roles = "User")]
        public IActionResult Eval(int id)
        {
            Evaluation eval = FindEvalByID(id);
            if (HttpContext.User.IsInRole("Student") && string.IsNullOrEmpty(eval.why_course))
            {
                return Edit(id);
            }
            return View(FindEvalByID(id));
        }



        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Edit(int id)
        {
            if (HttpContext.User.IsInRole("Instructor"))
            {
                return EvalList(id);
            }
            Evaluation editedCourse = FindEvalForStudent(id);
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
            List<Course> courses = FindCourses();
            return View(courses);
        }

        [NonAction]
        public Enrollment FindEnrollmentForCourse(int id)
        {
            return db.Enrollments.Where(en => en.CourseID == id && en.StudentID == ParseUserID()).FirstOrDefault();
        }

        [NonAction]
        public Stakeholder FindStakeHolderForCourse(int id)
        {
            return db.Stakeholders.Where(e => e.CourseID == id && e.InstructorID == ParseUserID()).FirstOrDefault();
        }

        [NonAction]
        public IEnumerable<Evaluation> FindStakeholderEvals(int id, Stakeholder stakeholder)
        {
            return db.Evaluations.Where(e => e.StakeHolderID == stakeholder.StakeholderID).ToList();
        }

        [NonAction]
        public Evaluation FindEvalForStudent(int id)
        {
            Enrollment enrollment = FindEnrollmentForCourse(id);

            return db.Evaluations.Where(e => e.EnrollmentID == enrollment.EnrollmentID).FirstOrDefault();
        }

        [NonAction]
        public List<Course> FindCourses()
        {
            if (HttpContext.User.IsInRole("Student"))
            {
                List<Enrollment> enrollments = db.Enrollments.Where(e => e.StudentID == ParseUserID()).ToList();
                List<Course> courses = new List<Course>();
                foreach (Enrollment enrollment in enrollments)
                {
                    courses.Append(db.Courses.Where(c => c.CourseID == enrollment.EnrollmentID).FirstOrDefault());
                }
                return courses;
            }
            else
            {
                List<Stakeholder> stakeholders = db.Stakeholders.Where(e => e.InstructorID == ParseUserID()).ToList();
                List<Course> courses = new List<Course>();
                foreach (Stakeholder stakeholder in stakeholders)
                {
                    courses.Append(db.Courses.Where(c => c.CourseID == stakeholder.StakeholderID).FirstOrDefault());
                }
                return courses;
            }

        }

        [NonAction]
        public int ParseUserID()
        {
            if (HttpContext.User.IsInRole("Student"))
            {
                return int.Parse(HttpContext.User.Claims.Where(e => e.Type == "StudentID").Select(e => e.Value).FirstOrDefault());
            }
            else
            {
                return int.Parse(HttpContext.User.Claims.Where(e => e.Type == "InstructorID").Select(e => e.Value).FirstOrDefault());

            }
        }

        [NonAction]
        public Evaluation FindEvalByID(int id)
        {
            return db.Evaluations.Where(ev => ev.EvaluationID == id).FirstOrDefault();
        }
}