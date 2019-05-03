using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student_Evaluation_3.Data;
using Student_Evaluation_3.Security;
using Student_Evaluation_3.Models;

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
                //Code for loading user into HttpContext here
                return View();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("User/password combination doesn't match");
                return View("Error", new ErrorViewModel());
            }


        }
    }
}