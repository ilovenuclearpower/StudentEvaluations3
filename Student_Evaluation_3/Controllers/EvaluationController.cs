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

        [Authorize(Roles = "Instructor")]
        public IActionResult EvalList(int id)
        {
            List<Evaluation> evals;
            evals = FindEvalsForCourse(id).ToList();
            List<int> evalints = new List<int>();
            foreach (Evaluation eval in evals)
            {
                evalints.Add(eval.EvaluationID);
            }
            List<GroupAssignment> groupAssignments = db.GroupAssignments.Where(g => g.InstructorID == ParseUserID()).ToList();
            List<int> groups = new List<int>();
            foreach (GroupAssignment assignment in groupAssignments)
            {
                groups.Add(assignment.FacultyGroupID);
            }
            List<Stakeholder> allowedstakeholders = db.Stakeholders.Where(s => groups.Contains(s.FacultyGroupID)).ToList();
            List<int> allowedstakeholderints = new List<int>();
            foreach (Stakeholder stakeholder in allowedstakeholders)
            {
                allowedstakeholderints.Add(stakeholder.StakeholderID);
            }
            List<Evaluation> allowedevals = db.Evaluations.Where(e => evalints.Contains(e.EvaluationID) && allowedstakeholderints.Contains(e.StakeholderID)).ToList();

            return View(allowedevals);
        }

        [Authorize(Roles = "User")]
        public IActionResult Eval(int id)
        {
            Evaluation eval = FindEvalByID(id);
            if (HttpContext.User.IsInRole("Student") && (eval == null))
            {
                return RedirectToAction("Edit", new { id = id });
            }
            else if (eval == null)
            {
                return Main();
            }
            return View(eval);
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
            var enrollment = db.Enrollments.Where(en => en.CourseID == id && en.StudentID == ParseUserID()).FirstOrDefault();
            return enrollment;
        }

        [NonAction]
        public Stakeholder FindStakeHolderForCourse(int id)
        {
            Stakeholder stakeholder = db.Stakeholders.Where(e => e.CourseID == id).FirstOrDefault();
            return stakeholder;
        }

        [NonAction]
        public IEnumerable<Evaluation> FindEvalsForCourse(int id)
        {

            Stakeholder stakeholder = db.Stakeholders.Where(s => s.CourseID == id).FirstOrDefault();
            List<Evaluation> evaluations = db.Evaluations.Where(e => e.StakeholderID == stakeholder.StakeholderID).ToList();

            return evaluations;
        }

        [NonAction]
        public Evaluation FindEvalForStudent(int id)
        {
            Enrollment enrollment = FindEnrollmentForCourse(id);
            Stakeholder stakeholder = db.Stakeholders.Where(s => s.CourseID == id).FirstOrDefault();
            var eval = db.Evaluations.Where(e => e.EnrollmentID == enrollment.EnrollmentID).Select(c => c).FirstOrDefault();
            if (eval == null)
            {
                eval = new Evaluation();
                eval.EnrollmentID = enrollment.EnrollmentID;
                eval.StakeholderID = stakeholder.StakeholderID;
            }
            return eval;  
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
                    courses.Add(db.Courses.Where(c => c.CourseID == enrollment.CourseID).FirstOrDefault());
                }
                return courses;
            }
            else
            {
                List<GroupAssignment> groupAssignments = db.GroupAssignments.Where(g => g.InstructorID == ParseUserID()).ToList();
                List<int> groups = new List<int>();
                foreach (GroupAssignment assignment in groupAssignments)
                {
                    groups.Add(assignment.FacultyGroupID);
                }
                List<Stakeholder> stakeholders = db.Stakeholders.Where(e => groups.Contains(e.FacultyGroupID)).ToList();
                List<Course> courses = new List<Course>();
                foreach (Stakeholder stakeholder in stakeholders)
                {
                    courses.Add(db.Courses.Where(c => c.CourseID == stakeholder.CourseID).FirstOrDefault());
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
}