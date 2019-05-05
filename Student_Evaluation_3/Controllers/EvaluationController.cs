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
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(Evaluation input)
        {
            db.Evaluations.Add(input);
            db.SaveChanges();
            return View("/View/Success");
        }

        [UserLoginFilter]
        public IActionResult Main()
        {
            IEnumerable<Course> courses;
            if (HttpContext.User.HasClaim("Role", "Student"))
            {
                var StudentID = HttpContext.User.Claims.Where(c => c.Type == "StudentID").Select(t => t.Value).FirstOrDefault();
                var CourseIDs = db.Enrollments.Where(c => c.StudentID.ToString() == StudentID).Select(t => t.CourseID);

            }
            return View();
        }

    }
}