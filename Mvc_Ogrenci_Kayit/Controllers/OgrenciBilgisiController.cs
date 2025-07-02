using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_Ogrenci_Kayit.Models;

namespace Mvc_Ogrenci_Kayit.Controllers
{
    public class OgrenciBilgisiController : Controller
    {
        private OgrenciKayitMvcEntities db = new OgrenciKayitMvcEntities();

        // GET: OgrenciBilgisi
        public ActionResult Index()
        {
            return View(db.OgrenciBilgi.ToList());
        }

        // GET: OgrenciBilgisi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciBilgi ogrenciBilgi = db.OgrenciBilgi.Find(id);
            if (ogrenciBilgi == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciBilgi);
        }

        // GET: OgrenciBilgisi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OgrenciBilgisi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrId,OgrAd,OgrSoyad,OgrMail,OgrFotograf,OgrAdres")] OgrenciBilgi ogrenciBilgi)
        {
            if (ModelState.IsValid)
            {
                db.OgrenciBilgi.Add(ogrenciBilgi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogrenciBilgi);
        }

        // GET: OgrenciBilgisi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciBilgi ogrenciBilgi = db.OgrenciBilgi.Find(id);
            if (ogrenciBilgi == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciBilgi);
        }

        // POST: OgrenciBilgisi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrId,OgrAd,OgrSoyad,OgrMail,OgrFotograf,OgrAdres")] OgrenciBilgi ogrenciBilgi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenciBilgi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenciBilgi);
        }

        // GET: OgrenciBilgisi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciBilgi ogrenciBilgi = db.OgrenciBilgi.Find(id);
            if (ogrenciBilgi == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciBilgi);
        }

        // POST: OgrenciBilgisi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OgrenciBilgi ogrenciBilgi = db.OgrenciBilgi.Find(id);
            db.OgrenciBilgi.Remove(ogrenciBilgi);
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
