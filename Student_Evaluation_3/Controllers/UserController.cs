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
                List<Claim> userClaims;
                if (role == "Student")
                {
                    userClaims = new List<System.Security.Claims.Claim>()
                {
                    new System.Security.Claims.Claim(ClaimTypes.Role, role),
                    new System.Security.Claims.Claim(ClaimTypes.Role, "User"),
                    new System.Security.Claims.Claim("StudentID", candidatestudent.StudentID.ToString()),
                    new Claim("UserID", candidatestudent.UserID.ToString())
                };
                }
                else
                {
                    userClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, role),
                        new Claim(ClaimTypes.Role, "User"),
                        new Claim("InstructorID", candidateinstructor.InstructorID.ToString()),
                        new Claim("UserID", candidateinstructor.UserID.ToString())
                    };
                }

                var newuser = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme));
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, newuser);
                return RedirectToAction("Main", "Evaluation");            }
            else
            {
                return View("Error", new ErrorViewModel());
            }


        }
    }
}