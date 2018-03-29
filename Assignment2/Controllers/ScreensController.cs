using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    
    public class ScreensController : Controller
    {
        private MoviesEntities db = new MoviesEntities();
        [AllowAnonymous]
        // GET: Screens
        public ActionResult Index()
        {
            var screens = db.Screens.Include(s => s.Theater);
            return View(screens.ToList());
        }
        [Authorize]
        // GET: Screens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screen screen = db.Screens.Find(id);
            if (screen == null)
            {
                return HttpNotFound();
            }
            return View(screen);
        }
        [Authorize]
        // GET: Screens/Create
        public ActionResult Create()
        {
            ViewBag.Theater_id = new SelectList(db.Theaters, "Theater_id", "TheaterName");
            return View();
        }

        // POST: Screens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Theater_id,Screen_id,No_of_Seats,Current_Movie,ThreeD")] Screen screen)
        {
            if (ModelState.IsValid)
            {
                db.Screens.Add(screen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Theater_id = new SelectList(db.Theaters, "Theater_id", "TheaterName", screen.Theater_id);
            return View(screen);
        }
        [Authorize]
        // GET: Screens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screen screen = db.Screens.Find(id);
            if (screen == null)
            {
                return HttpNotFound();
            }
            ViewBag.Theater_id = new SelectList(db.Theaters, "Theater_id", "TheaterName", screen.Theater_id);
            return View(screen);
        }

        // POST: Screens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Theater_id,Screen_id,No_of_Seats,Current_Movie,ThreeD")] Screen screen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(screen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Theater_id = new SelectList(db.Theaters, "Theater_id", "TheaterName", screen.Theater_id);
            return View(screen);
        }
        [Authorize]
        // GET: Screens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screen screen = db.Screens.Find(id);
            if (screen == null)
            {
                return HttpNotFound();
            }
            return View(screen);
        }

        // POST: Screens/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Screen screen = db.Screens.Find(id);
            db.Screens.Remove(screen);
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
