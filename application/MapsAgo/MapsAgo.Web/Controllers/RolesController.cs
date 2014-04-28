using MapsAgo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapsAgo.Web.Controllers
{
    public class RolesController : Controller
    {

        private MapsAgoDbContext db = new MapsAgoDbContext();

        // GET: /Roles/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var users = db.Users;
            ViewBag.RoleList = new SelectList(db.Users, "Id", "Name");
            return View(users.ToList());
        }
	}
}