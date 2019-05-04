using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student_Evaluation_3.Models;
using Microsoft.EntityFrameworkCore;
using Student_Evaluation_3.Data;

namespace Student_Evaluation_3.Controllers
{
    
    public class EvaluationController : Controller
    {
        private SchoolContext db;
        public EvaluationController(SchoolContext SchoolContext)
        {
            db = SchoolContext;
        }
        public IActionResult Evaluation()
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

        public IActionResult Main()
        {
            return View();
        }

    }
}