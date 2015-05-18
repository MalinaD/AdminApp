using AdminUserActionsApp.Context;
using AdminUserActionsApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminUserActionsApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="Administrator")]
        public ActionResult AdminPage()
        {
            ViewBag.Message = "For administrators only: welcome";

            return View();
        }

        public ActionResult UserPage()
        {
            ViewBag.Message = "For users: welcome";
            

            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult CreateAdminRole()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppContext()));
            var roleCreateResult = roleManager.Create(new IdentityRole("Administrator"));

            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new User() { UserName = "admin", Email = "admin@admin.com" };
            var createUserResult = userManager.Create(user, "Admin123!");

            if (!createUserResult.Succeeded)
            {
                throw new Exception(string.Join("; ", createUserResult.Errors));
            }

            userManager.AddToRole(user.Id, "Administrator");

            return View();

        }
    }
}