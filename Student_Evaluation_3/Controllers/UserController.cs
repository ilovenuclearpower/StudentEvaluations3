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
            User result = new User();
            try
            {
                result = (User)_context.Users.Where(u => u.UserName == user.UserName);
            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }
            if (Hashing.VerifyPassword(user.Password, result.Password))
            {
                //Code for loading user into HttpContext here
                return View();
            }
            else
            {
                return View("Error", new ErrorViewModel());
            }


        }
    }
}