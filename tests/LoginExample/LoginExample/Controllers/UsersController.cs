using LoginExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginExample.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            var model =
                from r in _users
                orderby r.Name
                select r; 
            return View(model);
        }

        //
        // GET: /User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create
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
        // GET: /User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5
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
        // GET: /User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5
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
        static List<UserListing> _users = new List<UserListing>
        {
            new UserListing
            {
                Id = 1,
                Name = "Adam",
                Approved = false
            },
             new UserListing
            {
                Id = 2,
                Name = "Fiona",
                Approved = false
            },
             new UserListing
            {
                Id = 3,
                Name = "Andrew",
                Approved = false
            }
        };
    }
}
