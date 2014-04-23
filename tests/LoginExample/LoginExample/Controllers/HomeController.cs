using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginExample.Controllers
{
    public class HomeController : Controller
    {   
        // anyone can anonymously view the index page
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        //only an admin user can view the ABOUT page
        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //Protected by the deafulat filter above
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}