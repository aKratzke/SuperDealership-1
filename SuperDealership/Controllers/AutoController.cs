using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuperDealership.Models;

namespace SuperDealership.Controllers
{
    public class AutoController : Controller
    {
        private SuperDealership.DAL.AutoDBContext db = new SuperDealership.DAL.AutoDBContext();
        [Authorize]
        // GET: Auto




        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Vehicle.ToList());
        }




        // GET: Auto/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Vehicle.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // GET: Auto/Create



        [Authorize(Users = "Admin@Yahoo.com")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Type,Make,Model,Year,MPGLow,MPGHigh,Color,MSRP,Mileage,VIN,CarImg")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Vehicle.Add(auto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auto);
        }

        [AllowAnonymous]
        // GET: Auto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Vehicle.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }


        // POST: Auto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Users = "Admin@Yahoo.com")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Type,Make,Model,Year,MPGLow,MPGHigh,Color,MSRP,Mileage,VIN,CarImg")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auto);
        }

        [Authorize(Users = "Admin@Yahoo.com")]
        // GET: Auto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Vehicle.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: Auto/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Users = "Admin@Yahoo.com")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auto auto = db.Vehicle.Find(id);
            db.Vehicle.Remove(auto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Users = "Admin@Yahoo.com")]
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
