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

namespace Student_Evaluation_3.Controllers
{
    public class UserController : Controller
    {
        private SchoolContext _context;

        public UserController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Models.User user)
        {
            var candidateuser = _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault<User>();
            System.Diagnostics.Debug.WriteLine(user.UserName);
            if (Hashing.VerifyPassword(user.Password, candidateuser.Password))
            {
                
                string role = "";
                var candidatestudent = _context.Students.Where(u => u.UserID == candidateuser.UserID).FirstOrDefault<Student>();
                var candidateinstructor = _context.Instructors.Where(u => u.UserID == candidateuser.UserID).FirstOrDefault<Instructor>();
                if (candidatestudent != null)
                {
                    role = "Student";
                }
                else
                {
                    role = "Instructor";
                }
                System.Diagnostics.Debug.WriteLine("Success!");
                var userClaims = new List<System.Security.Claims.Claim>()
                {
                    new System.Security.Claims.Claim("Role", role),
                };
                if (role == "Student")
                {
                    userClaims.Append(new System.Security.Claims.Claim("Name", candidatestudent.UserName));
                    userClaims.Append(new System.Security.Claims.Claim("StudentID", candidatestudent.StudentID.ToString()));
                    userClaims.Append(new System.Security.Claims.Claim("UserID", candidatestudent.UserID.ToString()));
                }
                else
                {
                    userClaims.Append(new System.Security.Claims.Claim("Name", candidateinstructor.UserName));
                    userClaims.Append(new System.Security.Claims.Claim("InstructorID", candidateinstructor.InstructorID.ToString()));
                    userClaims.Append(new System.Security.Claims.Claim("UserID", candidateinstructor.UserID.ToString()));

                }
                var newuser = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(userClaims, "Custom"));
                HttpContext.Authentication.SignInAsync("Cookie", newuser);
                //Code for loading user into HttpContext here
                System.Diagnostics.Debug.WriteLine("User login successful" + HttpContext.User.Identity.IsAuthenticated);
                return RedirectToAction("Main", "Evaluation");
            }
            else
            {
                return View("Error", new ErrorViewModel());
            }


        }
    }
}