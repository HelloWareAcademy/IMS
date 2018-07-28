using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMS_2018_07_25.DAL;
using IMS_2018_07_25.Models;

namespace IMS_2018_07_25.Controllers
{
    public class MarkupsController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Markups
        public ActionResult Index()
        {
            var markups = db.Markups.Include(m => m.Item).Include(m => m.Price);
            return View(markups.ToList());
        }

        // GET: Markups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Markup markup = db.Markups.Find(id);
            if (markup == null)
            {
                return HttpNotFound();
            }
            return View(markup);
        }

        // GET: Markups/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name");
            ViewBag.PricingId = new SelectList(db.Pricings, "Id", "Name");
            return View();
        }

        // POST: Markups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,PricingId,MarkupPercentage")] Markup markup)
        {
            if (ModelState.IsValid)
            {
                db.Markups.Add(markup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", markup.ItemId);
            ViewBag.PricingId = new SelectList(db.Pricings, "Id", "Name", markup.PricingId);
            return View(markup);
        }

        // GET: Markups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Markup markup = db.Markups.Find(id);
            if (markup == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", markup.ItemId);
            ViewBag.PricingId = new SelectList(db.Pricings, "Id", "Name", markup.PricingId);
            return View(markup);
        }

        // POST: Markups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,PricingId,MarkupPercentage")] Markup markup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(markup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", markup.ItemId);
            ViewBag.PricingId = new SelectList(db.Pricings, "Id", "Name", markup.PricingId);
            return View(markup);
        }

        // GET: Markups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Markup markup = db.Markups.Find(id);
            if (markup == null)
            {
                return HttpNotFound();
            }
            return View(markup);
        }

        // POST: Markups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Markup markup = db.Markups.Find(id);
            db.Markups.Remove(markup);
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
