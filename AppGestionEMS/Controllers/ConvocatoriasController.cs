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
    [Authorize(Roles = "admin,profesor")]

    public class ConvocatoriasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Convocatorias
        public ActionResult Index()
        {
            return View(db.Convocatorias.ToList());
        }

        // GET: Convocatorias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convocatorias convocatorias = db.Convocatorias.Find(id);
            if (convocatorias == null)
            {
                return HttpNotFound();
            }
            return View(convocatorias);
        }

        // GET: Convocatorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Convocatorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConvocatoriaId,actual")] Convocatorias convocatorias)
        {
            if (ModelState.IsValid)
            {
                db.Convocatorias.Add(convocatorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(convocatorias);
        }

        // GET: Convocatorias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convocatorias convocatorias = db.Convocatorias.Find(id);
            if (convocatorias == null)
            {
                return HttpNotFound();
            }
            return View(convocatorias);
        }

        // POST: Convocatorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConvocatoriaId,actual")] Convocatorias convocatorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(convocatorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(convocatorias);
        }

        // GET: Convocatorias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convocatorias convocatorias = db.Convocatorias.Find(id);
            if (convocatorias == null)
            {
                return HttpNotFound();
            }
            return View(convocatorias);
        }

        // POST: Convocatorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Convocatorias convocatorias = db.Convocatorias.Find(id);
            db.Convocatorias.Remove(convocatorias);
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
