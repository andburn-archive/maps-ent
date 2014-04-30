using MapsAgo.Common;
using MapsAgo.Model;
using MapsAgo.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapsAgo.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {

        public UserManager<ApplicationUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public MapsAgoDbContext context { get; private set; }

        public UsersController()
        {
            context = new MapsAgoDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }        
        
        //
        // GET: /Users/
        public ActionResult Index()
        {
            IQueryable<ApplicationUser> users = UserManager.Users;            
            IQueryable<IdentityRole> roles = RoleManager.Roles;

            IdentityRole AuthRole = 
                RoleManager.FindByName(AuthTypes.Authorized.ToString());
            IdentityRole AdminRole =
                RoleManager.FindByName(AuthTypes.Admin.ToString());

            // TODO: users without roles will not show, 
            // must ensure all users are assigned roles
            var list = from u in users
                       from r in u.Roles
                       where r.RoleId != AdminRole.Id
                       select new UserListViewModel
                       {
                           Id = u.Id,
                           UserName = u.UserName,
                           Email = u.Email,
                           NumberOfEvents = u.Events.Count(),
                           FlaggedEvents = (from e in u.Events
                                            where e.Flagged
                                            select e).Count(),
                           Authorized = r.RoleId == AuthRole.Id
                       };

            return View(list);
        }

        //
        // GET: /Users/Details/5
        public ActionResult Details(string UserName)
        {
            ApplicationUser user = UserManager.FindByName(UserName);

            IQueryable<ApplicationUser> users = UserManager.Users;
            IQueryable<IdentityRole> roles = RoleManager.Roles;

            IEnumerable<EventItemViewModel> uevents = 
                from e in user.Events
                select new EventItemViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Excerpt = e.Excerpt,
                    Date = e.StartDate.Date
                };
            IEnumerable<RoleItemViewModel> uroles = 
                from r in roles
                where r.Name != AuthTypes.Admin.ToString()
                select new RoleItemViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Checked = user.Roles.Any(x => x.RoleId == r.Id)
                };

            return View(new UserDetailViewModel { 
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                UserRoles = uroles,
                UserEvents = uevents
            });  
        }
        
        //
        // GET: /Users/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        //
        // POST: /Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
