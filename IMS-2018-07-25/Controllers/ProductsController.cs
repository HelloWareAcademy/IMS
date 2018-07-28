using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMS_2018_07_25.DAL;
using IMS_2018_07_25.Models;

namespace IMS_2018_07_25.Controllers
{
    public class ProductsController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", item.CategoryId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name", item.StatusId);

            db.Entry(item).Collection(i=>i.Markups).Load();
            db.Entry(item).Collection(i => i.Inventories).Load();

            foreach (var itemMarkup in item.Markups)
            {
                db.Entry(itemMarkup).Reference(m=>m.Price).Load();
            }

            foreach (var itemInventory in item.Inventories)
            {
                db.Entry(itemInventory).Reference(m => m.Location).Load();
            }

            return View(item);
        }
    }
}