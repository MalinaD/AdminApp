

namespace AdminUserActionsApp.Controllers
{
    using AdminUserActionsApp.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Authorize]
    public class UserController : BaseController
    {
        // GET: Users
        public ActionResult Index(string username)
        {
            //var userProfile = this.Data.Users.All()
            //    .Where(x => x.UserName == username)
            //    .Select(User.ViewModel)
            //    .FirstOrDefault();

            //if (userProfile == null)
            //{
            //    return this.HttpNotFound("User does not exist");
            //}



            return this.View();
        }

        public ActionResult MyProfile()
        {
            return this.Redirect("/User/mimi");
        }

        [OutputCache(Duration = 60)]
        [Authorize]
        public ActionResult GetParam(string name)
        {
            return Content(string.Format("{0} - {1}", name, DateTime.Now));
        }
    }
}