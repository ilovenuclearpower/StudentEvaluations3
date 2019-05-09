using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student_Evaluation_3.Data;
using Student_Evaluation_3.Security;
using Student_Evaluation_3.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Student_Evaluation_3.Controllers
{
    public class AdminController : Controller
    {
        private SchoolContext db;
        public AdminController(SchoolContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(Student input)
        {
            input.Password = Hashing.HashPassword(input.Password);
            db.Students.Add(input);
            db.SaveChangesAsync();
            return View();
        }

        public IActionResult Toolbar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateInstructor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateInstructor(Instructor instructor)
        {
            instructor.Password = Hashing.HashPassword(instructor.Password);
            db.Instructors.Add(instructor);
            db.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public IActionResult EnrollStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnrollStudent(Enrollment enrollment)
        {
            db.Enrollments.Add(enrollment);
            db.SaveChangesAsync();
            return View();
        }


        [HttpGet]
        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCourse(Course enrollment)
        {
            db.Courses.Add(enrollment);
            db.SaveChangesAsync();
            return View();
        }


        [HttpGet]
        public IActionResult AssignFaculty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AssignFaculty(GroupAssignment enrollment)
        {
            db.GroupAssignments.Add(enrollment);
            db.SaveChangesAsync();
            return View();
        }


        [HttpGet]
        public IActionResult AssignGroupToCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AssignGroupToCourse(Stakeholder enrollment)
        {
            db.Stakeholders.Add(enrollment);
            db.SaveChangesAsync();
            return View();
        }



    }
}
