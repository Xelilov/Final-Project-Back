using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProjectShopping.Models;

namespace FinalProjectShopping.Areas.Admins.Controllers
{
    public class InnerSubcategryController : Controller
    {
        private FinalProjectEntities db = new FinalProjectEntities();

        // GET: Admins/InnerSubcategry
        public ActionResult Index()
        {
            var innerSubcategories = db.InnerSubcategories.Include(i => i.Subcategory);
            return View(innerSubcategories.ToList());
        }

        // GET: Admins/InnerSubcategry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InnerSubcategory innerSubcategory = db.InnerSubcategories.Find(id);
            if (innerSubcategory == null)
            {
                return HttpNotFound();
            }
            return View(innerSubcategory);
        }

        // GET: Admins/InnerSubcategry/Create
        public ActionResult Create()
        {
            ViewBag.innersubcategory_subcategory_id = new SelectList(db.Subcategories, "subcategory_id", "subcategory_name");
            return View();
        }

        // POST: Admins/InnerSubcategry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "innersubcategory_id,innersubcategory_name,innersubcategory_subcategory_id")] InnerSubcategory innerSubcategory)
        {
            if (ModelState.IsValid)
            {
                db.InnerSubcategories.Add(innerSubcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.innersubcategory_subcategory_id = new SelectList(db.Subcategories, "subcategory_id", "subcategory_name", innerSubcategory.innersubcategory_subcategory_id);
            return View(innerSubcategory);
        }

        // GET: Admins/InnerSubcategry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InnerSubcategory innerSubcategory = db.InnerSubcategories.Find(id);
            if (innerSubcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.innersubcategory_subcategory_id = new SelectList(db.Subcategories, "subcategory_id", "subcategory_name", innerSubcategory.innersubcategory_subcategory_id);
            return View(innerSubcategory);
        }

        // POST: Admins/InnerSubcategry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "innersubcategory_id,innersubcategory_name,innersubcategory_subcategory_id")] InnerSubcategory innerSubcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(innerSubcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.innersubcategory_subcategory_id = new SelectList(db.Subcategories, "subcategory_id", "subcategory_name", innerSubcategory.innersubcategory_subcategory_id);
            return View(innerSubcategory);
        }

        // GET: Admins/InnerSubcategry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InnerSubcategory innerSubcategory = db.InnerSubcategories.Find(id);
            if (innerSubcategory == null)
            {
                return HttpNotFound();
            }
            return View(innerSubcategory);
        }

        // POST: Admins/InnerSubcategry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InnerSubcategory innerSubcategory = db.InnerSubcategories.Find(id);
            db.InnerSubcategories.Remove(innerSubcategory);
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
