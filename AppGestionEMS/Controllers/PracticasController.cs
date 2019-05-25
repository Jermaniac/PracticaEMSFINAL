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

    public class PracticasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Practicas
        public ActionResult Index()
        {
            return View(db.Practicas.ToList());
        }

        // GET: Practicas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practicas practicas = db.Practicas.Find(id);
            if (practicas == null)
            {
                return HttpNotFound();
            }
            return View(practicas);
        }

        // GET: Practicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Practicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PracticasId")] Practicas practicas)
        {
            if (ModelState.IsValid)
            {
                db.Practicas.Add(practicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(practicas);
        }

        // GET: Practicas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practicas practicas = db.Practicas.Find(id);
            if (practicas == null)
            {
                return HttpNotFound();
            }
            return View(practicas);
        }

        // POST: Practicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PracticasId")] Practicas practicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(practicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(practicas);
        }

        // GET: Practicas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practicas practicas = db.Practicas.Find(id);
            if (practicas == null)
            {
                return HttpNotFound();
            }
            return View(practicas);
        }

        // POST: Practicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Practicas practicas = db.Practicas.Find(id);
            db.Practicas.Remove(practicas);
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
