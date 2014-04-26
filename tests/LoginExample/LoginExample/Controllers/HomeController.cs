using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginExample.Controllers
{
    public class HomeController : Controller
    {   
        
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        //only an admin user can view the ABOUT page
        [Authorize(Roles = "Admin , AuthorizedUser")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //only the admin should see this 
        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}