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

namespace MapsAgo.Web.Controllers
{
    [AuthorizeByRole(RoleType.Admin, RoleType.Authorized)]
    public class EventController : Controller
    {
        private MapsAgoDbContext db = new MapsAgoDbContext();

        // only the Admin and AuthorizedUser users can view the Events page
        // GET: /Event/     
        public ActionResult Index()
        {
            var events = db.Events
                .Include(e => e.Location)
                .Include(e => e.Type)
                .Include(e => e.User);
            return View(events.ToList());
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

        public ActionResult Create()
        {

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Name");
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }
        [HttpPost]
        public ActionResult Create(NewEventViewModel newEvent)
        {
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
