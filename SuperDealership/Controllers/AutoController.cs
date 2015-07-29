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

        public ActionResult Admin()
        {
            return View(db.Vehicle.ToList());
        }


        [AllowAnonymous]
        public ActionResult Index(string autoType, string autoMake, string autoModel, string autoYear, string autoMPGLow, string autoMPGHigh, string autoColor, string autoMSRP, string autoMileage, string autoVIN, string autoUserID)
        {
        //    var AutoList = new List<Auto>();

        //    var autoQry = from a in db.Vehicle
        //                  where a.UserID == 1
        //                  select a;
        //    foreach (var a in autoQry)
        //    {
        //        AutoList.Add(a);
        //    }

        //    return View(AutoList);
        //}

            var TypeLst = new List<string>();
            var MakeLst = new List<string>();
            var ModelLst = new List<string>();
            var YearLst = new List<string>();
            //var MPGLowLst = new List<string>();
            //var MPGHighLst = new List<string>();
            //var ColorLst = new List<string>();
            //var MSRPLst = new List<string>();
            //var MileageLst = new List<string>();
            //var UserIDLst = new List<string>();
            //var VINLst = new List<string>();

            //Creates list of distinct types
            var TypeQry = from a in db.Vehicle
                          orderby a.Type
                          select a.Type;

            TypeLst.AddRange(TypeQry.Distinct());
            ViewBag.autoType = new SelectList(TypeLst);

            //Creates list of distinct makes
            var MakeQry = from a in db.Vehicle
                          orderby a.Make
                          select a.Make;

            MakeLst.AddRange(MakeQry.Distinct());
            ViewBag.autoMake = new SelectList(MakeLst);

            //Creates list of distinct models
            var ModelQry = from a in db.Vehicle
                           orderby a.Model
                           select a.Model;

            ModelLst.AddRange(ModelQry.Distinct());
            ViewBag.autoModel = new SelectList(ModelLst);

            //Creates list of distinct years
            var YearQry = from a in db.Vehicle
                          orderby a.Year
                          select a.Year.ToString();

            YearLst.AddRange(YearQry.Distinct());
            ViewBag.autoYear = new SelectList(YearLst);

            ////Creates list of distinct MPGLow
            //var MPGLowQry = from a in db.Vehicle
            //                orderby a.MPGLow
            //                select a.MPGLow.ToString();

            //MPGLowLst.AddRange(MPGLowQry.Distinct());
            //ViewBag.autoMPGLow = new SelectList(MPGLowLst);

            ////Creates list of distinct MPGHigh
            //var MPGHighQry = from a in db.Vehicle
            //                 orderby a.MPGHigh
            //                 select a.MPGHigh.ToString();

            //MPGHighLst.AddRange(MPGHighQry.Distinct());
            //ViewBag.autoMPGHigh = new SelectList(MPGHighLst);

            ////Creates list of distinct colors
            //var ColorQry = from a in db.Vehicle
            //               orderby a.Color
            //               select a.Color;

            //ColorLst.AddRange(ColorQry.Distinct());
            //ViewBag.autoColor = new SelectList(ColorLst);

            ////Creates list of distinct MSRP
            //var MSRPQry = from a in db.Vehicle
            //              orderby a.MSRP
            //              select a.MSRP.ToString();

            //MSRPLst.AddRange(MSRPQry.Distinct());
            //ViewBag.autoMSRP = new SelectList(MSRPLst);

            ////Creates list of distinct Mileage
            //var MileageQry = from a in db.Vehicle
            //                 orderby a.Mileage
            //                 select a.Mileage.ToString();

            //MileageLst.AddRange(MileageQry.Distinct());
            //ViewBag.autoMileage = new SelectList(MileageLst);

            ////Creates list of distinct UserID
            //var UserIDQry = from a in db.Vehicle
            //                orderby a.UserID
            //                select a.UserID.ToString();

            //UserIDLst.AddRange(UserIDQry.Distinct());
            //ViewBag.autoUserID = new SelectList(UserIDLst);

            ////Creates list of distinct VIN
            //var VINQry = from a in db.Vehicle
            //             orderby a.VIN
            //             select a.VIN.ToString();

            //VINLst.AddRange(VINQry.Distinct());
            //ViewBag.autoVIN = new SelectList(VINLst);

            var autos = from d in db.Vehicle
                        where d.IsOwned == false
                        select d;

            if (!String.IsNullOrEmpty(autoType))
            {
                autos = autos.Where(x => x.Type == autoType);
            }

            if (!String.IsNullOrEmpty(autoMake))
            {
                autos = autos.Where(x => x.Make == autoMake);
            }

            if (!String.IsNullOrEmpty(autoModel))
            {
                autos = autos.Where(x => x.Model == autoModel);
            }

            if (!String.IsNullOrEmpty(autoYear))
            {
                autos = autos.Where(x => x.Year.ToString() == autoYear);
            }

            //if (!String.IsNullOrEmpty(autoMPGLow))
            //{
            //    autos = autos.Where(x => x.MPGLow.ToString() == autoMPGLow);
            //}

            //if (!String.IsNullOrEmpty(autoMPGHigh))
            //{
            //    autos = autos.Where(x => x.MPGHigh.ToString() == autoMPGHigh);
            //}

            //if (!String.IsNullOrEmpty(autoColor))
            //{
            //    autos = autos.Where(x => x.Color == autoColor);
            //}

            //if (!String.IsNullOrEmpty(autoMSRP))
            //{
            //    autos = autos.Where(x => x.MSRP.ToString() == autoMSRP);
            //}

            //if (!String.IsNullOrEmpty(autoMileage))
            //{
            //    autos = autos.Where(x => x.Mileage.ToString() == autoMileage);
            //}

            //if (!String.IsNullOrEmpty(autoUserID))
            //{
            //    autos = autos.Where(x => x.UserID.ToString() == autoUserID);
            //}

            //if (!String.IsNullOrEmpty(autoVIN))
            //{
            //    autos = autos.Where(x => x.VIN.ToString() == autoVIN);
            //}

            return View(autos);
        }
            
            //

            //foreach (Auto item in db.Vehicle)
            //{
            //    if (item.UserID == 0)
            //    {
            //        AutoList.Add(item);
            //    }
            //}

            //return View (AutoList);
            //}

            //foreach (var Auto.UserID in db.Vehicle)
            //{
            //    if (auto.UserID == 0)
            //        UserIdList.Add(auto)
            //} 

            //      
            //return View(db.Vehicle.ToList());




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

        [AllowAnonymous]


        public ActionResult About(string modelCar, string searchString)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.Vehicle
                           orderby d.Make
                           select d.Make;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.modelCar = new SelectList(GenreLst);

            var car = from m in db.Vehicle
                      select m;



            if (!String.IsNullOrEmpty(searchString))
            {

                car = car.Where(s => s.Model.Contains(searchString));
            }



            if (!String.IsNullOrEmpty(modelCar))
            {

                car = car.Where(x => x.Make == modelCar);
            }


            return View(car);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}
