using MapsAgo.Common;
using MapsAgo.Model;
using MapsAgo.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MapsAgo.Web.Controllers
{
    [AuthorizeByRole(RoleType.Admin)]
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
        
        // GET: /Users/
        public ActionResult Index()
        {
            IQueryable<ApplicationUser> users = UserManager.Users;            
            IQueryable<IdentityRole> roles = RoleManager.Roles;

            IdentityRole AuthRole = 
                RoleManager.FindByName(RoleType.Authorized.ToString());
            IdentityRole AdminRole =
                RoleManager.FindByName(RoleType.Admin.ToString());

            // TODO: users without roles will not show, 
            // must ensure all users are assigned roles,
            // more one role => appear more than once too.
            var list = from u in users
                       from r in u.Roles
                       where r.RoleId != AdminRole.Id
                       select new UserListViewModel
                       {
                           Id = u.Id,
                           UserName = u.UserName,
                           Email = u.Email == null 
                                ? "unknown"
                                : u.Email,
                           NumberOfEvents = u.Events.Count(),
                           FlaggedEvents = (from e in u.Events
                                            where e.Flagged
                                            select e).Count(),
                           Authorized = r.RoleId == AuthRole.Id
                       };
            // order list so unauthorized are at bottom
            list = list.Select(x => x)
                .OrderByDescending(x => x.Authorized);
            return View(list);
        }

        // GET: /Users/Details/caaff697-3cbf-458e-9ab8-c926a32d877c
        public ActionResult Details(string id)
        {
            // TODO: can this even be null?
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ApplicationUser user = UserManager.FindById(id);           

            if (user == null)
            {
                return new HttpNotFoundResult("This user does not exist");
            }

            IEnumerable<string> userRoleIds = user.Roles.Select(x => x.RoleId);                             

            IQueryable<IdentityRole> roles = RoleManager.Roles;

            IEnumerable<string> allRoleIds = roles.Select(x => x.Id);
            IEnumerable<string> commonRoles = allRoleIds.Intersect(userRoleIds);

            IEnumerable<EventItemViewModel> uevents = 
                from e in user.Events
                orderby e.LastModified descending
                select new EventItemViewModel(e);

            IEnumerable<RoleItemViewModel> uroles =
                from r in roles
                where r.Name != RoleType.Admin.ToString()
                select new RoleItemViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Checked = commonRoles.Contains(r.Id)
                };

            return View(new UserDetailViewModel { 
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email == null
                        ? "unknown"
                        : user.Email,
                UserRoles = uroles,
                UserEvents = uevents
            });  
        }
        
        // POST: /Users/Details/sd9df-kalsf-3d9dd
        [HttpPost]
        public ActionResult Details(string id, FormCollection collection)
        {            
            int values = collection.Count / 3;
            for (int i = 0; i < values; i++)
            {
                var roleId = collection["UserRoles[" + i + "].Id"];
                var roleName = collection["UserRoles[" + i + "].Name"];
                var roleCheck = collection["UserRoles[" + i + "].Checked"].Split(',')[0];

                bool ticked = roleCheck == "true" ? true : false;
                bool hasRole = UserManager.IsInRole(id, roleName);
                IdentityResult result = null;

                if (hasRole != ticked)
                {
                    // state is different
                    if (hasRole)
                    {
                        result = UserManager.RemoveFromRole(id, roleName);
                    }
                    else 
                    {
                        result = UserManager.AddToRole(id, roleName); 
                    }

                }

                if (result == null || !result.Succeeded)
                {
                    // do something?
                    System.Diagnostics.Debug.WriteLine("details: " + id + ", shit is fucked up!");
                }

            }
            return RedirectToAction("Details", new { id = id });
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
