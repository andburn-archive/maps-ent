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
            
            //ICollection<UserListViewModel> userList = new List<UserListViewModel>();

            // TODO: must be a better way to do this, LINQ?
            //foreach (var u in users)
            //{
            //    var udvm = new UserListViewModel
            //    {
            //        Id = u.Id,
            //        UserName = u.UserName,
            //        Email = u.Email
            //    };
            //    var rivm = new List<RoleItemViewModel>();
            //    foreach (var r in roles)
            //    {
            //        rivm.Add(new RoleItemViewModel
            //        {
            //            Id = r.Id,
            //            Name = r.Name,
            //            Checked = u.Roles.Any(x => x.RoleId == r.Id)
            //        });                    
            //    }
            //    udvm.UserRoles = rivm;
            //    userList.Add(udvm);
            //}

            // Test values for view
            var userList = new List<UserListViewModel>
            {
                new UserListViewModel {
                    Id = "100", UserName = "Joe", Email = "joe@e.com",
                    UserRoles = new List<RoleItemViewModel> {
                        new RoleItemViewModel {
                            Id = "200", Name = "Auth", Checked = true
                        },
                        new RoleItemViewModel {
                            Id = "210", Name = "Admin", Checked = false
                        },
                        new RoleItemViewModel {
                            Id = "220", Name = "None", Checked = false
                        }
                    }
                },
                new UserListViewModel {
                    Id = "110", UserName = "Bill", Email = "bill@e.com",
                    UserRoles = new List<RoleItemViewModel> {
                        new RoleItemViewModel {
                            Id = "200", Name = "Auth", Checked = true
                        },
                        new RoleItemViewModel {
                            Id = "210", Name = "Admin", Checked = true
                        },
                        new RoleItemViewModel {
                            Id = "220", Name = "None", Checked = false
                        }
                    }
                },
            };

            return View(userList);
        }

        //
        // GET: /Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Users/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Users/Edit/5
        public ActionResult Edit(int id)
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
