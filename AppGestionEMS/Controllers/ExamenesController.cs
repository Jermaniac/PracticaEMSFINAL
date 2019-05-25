using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppGestionEMS.Models;

namespace AppGestionEMS.Controllers
{
    [Authorize(Roles = "profesor,admin")]

    public class ExamenesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Examenes
        public ActionResult Index()
        {
            return View(db.Examenes.ToList());
        }

        // GET: Examenes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examenes examenes = db.Examenes.Find(id);
            if (examenes == null)
            {
                return HttpNotFound();
            }
            return View(examenes);
        }

        // GET: Examenes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Examenes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamenesId")] Examenes examenes)
        {
            if (ModelState.IsValid)
            {
                db.Examenes.Add(examenes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examenes);
        }

        // GET: Examenes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examenes examenes = db.Examenes.Find(id);
            if (examenes == null)
            {
                return HttpNotFound();
            }
            return View(examenes);
        }

        // POST: Examenes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamenesId")] Examenes examenes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examenes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examenes);
        }

        // GET: Examenes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examenes examenes = db.Examenes.Find(id);
            if (examenes == null)
            {
                return HttpNotFound();
            }
            return View(examenes);
        }

        // POST: Examenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Examenes examenes = db.Examenes.Find(id);
            db.Examenes.Remove(examenes);
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
