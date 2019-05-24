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
    [Authorize(Roles = "alumno,admin,profesor")]
    public class GrupoPracticasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GrupoPracticas
        public ActionResult Index()
        {
            return View(db.GrupoPracticas.ToList());
        }

        // GET: GrupoPracticas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoPracticas grupoPracticas = db.GrupoPracticas.Find(id);
            if (grupoPracticas == null)
            {
                return HttpNotFound();
            }
            return View(grupoPracticas);
        }

        // GET: GrupoPracticas/Create
        [Authorize(Roles = "admin,profesor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoPracticas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrupoPracticasId,activo")] GrupoPracticas grupoPracticas)
        {
            if (ModelState.IsValid)
            {
                db.GrupoPracticas.Add(grupoPracticas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupoPracticas);
        }

        // GET: GrupoPracticas/Edit/5
        [Authorize(Roles = "admin,profesor")]

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoPracticas grupoPracticas = db.GrupoPracticas.Find(id);
            if (grupoPracticas == null)
            {
                return HttpNotFound();
            }
            return View(grupoPracticas);
        }

        // POST: GrupoPracticas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin,profesor")]

        public ActionResult Edit([Bind(Include = "GrupoPracticasId,activo")] GrupoPracticas grupoPracticas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoPracticas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoPracticas);
        }

        // GET: GrupoPracticas/Delete/5
        [Authorize(Roles = "admin,profesor")]

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoPracticas grupoPracticas = db.GrupoPracticas.Find(id);
            if (grupoPracticas == null)
            {
                return HttpNotFound();
            }
            return View(grupoPracticas);
        }

        // POST: GrupoPracticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin,profesor")]

        public ActionResult DeleteConfirmed(string id)
        {
            GrupoPracticas grupoPracticas = db.GrupoPracticas.Find(id);
            db.GrupoPracticas.Remove(grupoPracticas);
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
