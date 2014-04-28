using MapsAgo.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var users = db.Users;
            // IQueryable<IdentityRole>
            ViewBag.RoleList = RoleManager.Roles;
            //ViewBag.RoleList = new SelectList(roles, "Id", "Name");
            return View(users.ToList());
        }
	}
}