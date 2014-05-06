using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MapsAgo.Model;
using MapsAgo.Web.ViewModels;
using MapsAgo.Web.Models;
using MapsAgo.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MapsAgo.Domain;
using MapsAgo.Domain.Freebase;
using MapsAgo.Web.Views.ViewModels;
using PagedList;

namespace MapsAgo.Web.Controllers
{
    // only the Admin and AuthorizedUser users can view the Events page
    [AuthorizeByRole(RoleType.Admin, RoleType.Authorized)]
    public class EventController : Controller
    {
        private MapsAgoDbContext db = new MapsAgoDbContext();
        
        // GET: /Event/     
        public ActionResult Index(int? page)
        {
            var events = db.Events
                .Include(e => e.Location)
                .Include(e => e.Type)
                .Include(e => e.User)
                .OrderBy(e => e.LastModified);

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(events.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event ev = db.Events.Find(id);
            if (ev == null)
            {
                return HttpNotFound();
            }
            return View(ev);
        }

        public ActionResult Create(
            string mid = "default", string query = "default")
        {
            // TODO: make this part of params
            string type = "(all type:/military/military_conflict)";
            // TODO: User IoC here
            InfoGatherer gather = new InfoGatherer(new FreebaseStrategy());
            SearchAndCreate sc = new SearchAndCreate(
                new List<ISearchResult>(),
                (IDataResource) new FreebaseDataResource(),
                new NewEventViewModel()
                );
            if (mid != "default")
            {
                // get the details of id
                sc.details = gather.Details(mid);
            }
            if (query != "default")
            {
                // get the search results
                sc.results = gather.Search(query, type);
            }
            ViewBag.Package = sc;
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Name");
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            return View(sc);
        }

        [HttpPost]
        public ActionResult Search(string query = "default")
        {
            if (query != "default")
            {
                return RedirectToAction("Create", "Event", new { query = query });
            }
            return RedirectToAction("Create", "Event");
        }

        [HttpPost]
        public ActionResult Create(NewEventViewModel newEvent, int postid = -1)
        {
            if (postid == -1) {

            }

            if (ModelState.IsValid)
            {
                Event e = newEvent.MapToEvent();
                if (e.Location != null) {
                    db.Locations.Add(e.Location);
                }
                if (e.LocationId != 0)
                {
                    e.Location = db.Locations.Find(e.LocationId);
                }
                e.User = db.Users.Find(User.Identity.GetUserId());
                db.Events.Add(e);
                db.SaveChanges();
                return RedirectToAction("Details", "Event", new { id = e.Id });
            }


            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Name");
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // GET: /Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event ev = db.Events.Find(id);
            if (ev == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", ev.LocationId);
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Name", ev.EventTypeId);
            //ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", ev.ApplicationUserId);
            return View(ev);
        }

        // POST: /Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Excerpt,Description,Source,StartDate,EndDate,DateCreated,LastModified,LocationId,EventTypeId,ApplicationUserId")] Event ev)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ev).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", ev.LocationId);
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Name", ev.EventTypeId);
            //ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", ev.ApplicationUserId);
            return View(ev);
        }

        [AuthorizeByRole(RoleType.Admin)]
        // GET: /Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event ev = db.Events.Find(id);
            if (ev == null)
            {
                return HttpNotFound();
            }
            return View(ev);
        }

        // POST: /Event/Delete/5
        [AuthorizeByRole(RoleType.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event ev = db.Events.Find(id);
            db.Events.Remove(ev);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
