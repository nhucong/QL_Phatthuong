using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QL_phatthuong.Models;

namespace QL_phatthuong.Controllers
{
    public class PhanQuasController : Controller
    {
        private QLPTEntities db = new QLPTEntities();

        // GET: PhanQuas
        public ActionResult Index()
        {
            return View(db.PhanQuas.ToList());
        }

        // GET: PhanQuas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanQua phanQua = db.PhanQuas.Find(id);
            if (phanQua == null)
            {
                return HttpNotFound();
            }
            return View(phanQua);
        }

        // GET: PhanQuas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhanQuas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaQua,TenQua,MoTa,GiaTri")] PhanQua phanQua)
        {
            if (ModelState.IsValid)
            {
                db.PhanQuas.Add(phanQua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phanQua);
        }

        // GET: PhanQuas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanQua phanQua = db.PhanQuas.Find(id);
            if (phanQua == null)
            {
                return HttpNotFound();
            }
            return View(phanQua);
        }

        // POST: PhanQuas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaQua,TenQua,MoTa,GiaTri")] PhanQua phanQua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phanQua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phanQua);
        }

        // GET: PhanQuas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanQua phanQua = db.PhanQuas.Find(id);
            if (phanQua == null)
            {
                return HttpNotFound();
            }
            return View(phanQua);
        }

        // POST: PhanQuas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhanQua phanQua = db.PhanQuas.Find(id);
            db.PhanQuas.Remove(phanQua);
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
