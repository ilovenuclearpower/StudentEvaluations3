using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;
using Student_Evaluation_3.Data;
using Student_Evaluation_3.Controllers;

namespace Student_Evaluation_3.ActionFilters
{

    public class UserLoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "User" },
                        { "action", "Login" }
                    });
            }
        }

    }

    [ServiceFilter(typeof(EditFilter))]
    public class EditFilter : ActionFilterAttribute
    {
        SchoolContext db;
        public EditFilter(SchoolContext dbcontext) : base()
        {
            db = dbcontext;
        }
   
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
                
                if (context.HttpContext.User.HasClaim("Role", "Student"))
                {
                    string claimType = "StudentID";
                    Claim claim = context.HttpContext.User.FindFirst(claimType);
                    string studentid = claim == null ? string.Empty : claim.Value;

                }

        }
    }

    public class InstructorFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.IsInRole("Student"))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "Evaluation" },
                        { "action" , "Main" }
                    });
            }
        }
    }
    public class StudentFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.HasClaim("Role", "Instructor"))
            {
                {
                    context.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                        { "controller", "Evaluation" },
                        { "action", "Main" }
                        });
                }
            }
        }
    }
}
