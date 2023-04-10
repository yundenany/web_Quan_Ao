using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Ban_Quan_Ao.Models;

namespace Web_Ban_Quan_Ao.Areas.Admin.Controllers
{
    public class ClothingController : Controller
    {
        private ClothingModelContext db = new ClothingModelContext();

        // GET: Admin/Clothing
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var clothings = db.Clothings.Include(c => c.Category);
            return View(clothings.ToList());
        }

        // GET: Admin/Clothing/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return HttpNotFound();
            }
            return View(clothing);
        }

        // GET: Admin/Clothing/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.Categories, "id_category", "name_category");
            return View();
        }

        // POST: Admin/Clothing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_clothing,C_name,manufacture,decription,images,category_id,price")] Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                db.Clothings.Add(clothing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.Categories, "id_category", "name_category", clothing.category_id);
            return View(clothing);
        }

        // GET: Admin/Clothing/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.Categories, "id_category", "name_category", clothing.category_id);
            return View(clothing);
        }

        // POST: Admin/Clothing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_clothing,C_name,manufacture,decription,images,category_id,price")] Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.Categories, "id_category", "name_category", clothing.category_id);
            return View(clothing);
        }

        // GET: Admin/Clothing/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return HttpNotFound();
            }
            return View(clothing);
        }

        // POST: Admin/Clothing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clothing clothing = db.Clothings.Find(id);
            db.Clothings.Remove(clothing);
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
