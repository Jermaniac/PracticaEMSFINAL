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
    public class TutoriasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tutorias
        public ActionResult Index()
        {
            var tutorias = db.Tutorias.Include(t => t.Convocatoria).Include(t => t.Curso).Include(t => t.GrupoPractica).Include(t => t.User);
            return View(tutorias.ToList());
        }

        // GET: Tutorias/Details/5
        public ActionResult Details(string convocatoria ,int? curso , string grupopracticas , string user )
        {
            if (convocatoria == null || curso == null || grupopracticas == null || user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutorias tutorias = db.Tutorias.Find(user, grupopracticas, curso, convocatoria);
            if (tutorias == null)
            {
                return HttpNotFound();
            }
            return View(tutorias);
        }

        // GET: Tutorias/Create
        public ActionResult Create()
        {
            var profesores = from user in db.Users
                             from u_r in user.Roles
                             join rol in db.Roles on u_r.RoleId equals rol.Id
                             where rol.Name == "profesor"
                             select user.UserName;
            ViewBag.ConvocatoriaId = new SelectList(db.Convocatorias, "ConvocatoriaId", "ConvocatoriaId");
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "CursoId");
            ViewBag.GrupoPracticasId = new SelectList(db.GrupoPracticas, "GrupoPracticasId", "GrupoPracticasId");
            ViewBag.UserId = new SelectList(db.Users.Where(u => profesores.Contains(u.UserName)), "Id", "Name"); 
            return View();
        }

        // POST: Tutorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,GrupoPracticasId,CursoId,ConvocatoriaId,IdTutoria,IdAsignatura,fecha")] Tutorias tutorias)
        {
            if (ModelState.IsValid)
            {
                db.Tutorias.Add(tutorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConvocatoriaId = new SelectList(db.Convocatorias, "ConvocatoriaId", "ConvocatoriaId", tutorias.ConvocatoriaId);
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "CursoId", tutorias.CursoId);
            ViewBag.GrupoPracticasId = new SelectList(db.GrupoPracticas, "GrupoPracticasId", "GrupoPracticasId", tutorias.GrupoPracticasId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", tutorias.UserId);
            return View(tutorias);
        }

        // GET: Tutorias/Edit/5
        public ActionResult Edit(string convocatoria, int? curso, string grupopracticas, string user)
        {
            if (convocatoria == null || curso == null || grupopracticas == null || user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutorias tutorias = db.Tutorias.Find(user, grupopracticas, curso, convocatoria);
            if (tutorias == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConvocatoriaId = new SelectList(db.Convocatorias, "ConvocatoriaId", "ConvocatoriaId", tutorias.ConvocatoriaId);
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "CursoId", tutorias.CursoId);
            ViewBag.GrupoPracticasId = new SelectList(db.GrupoPracticas, "GrupoPracticasId", "GrupoPracticasId", tutorias.GrupoPracticasId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", tutorias.UserId);
            return View(tutorias);
        }

        // POST: Tutorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,GrupoPracticasId,CursoId,ConvocatoriaId,IdTutoria,IdAsignatura,fecha")] Tutorias tutorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConvocatoriaId = new SelectList(db.Convocatorias, "ConvocatoriaId", "ConvocatoriaId", tutorias.ConvocatoriaId);
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "CursoId", tutorias.CursoId);
            ViewBag.GrupoPracticasId = new SelectList(db.GrupoPracticas, "GrupoPracticasId", "GrupoPracticasId", tutorias.GrupoPracticasId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", tutorias.UserId);
            return View(tutorias);
        }

        // GET: Tutorias/Delete/5
        public ActionResult Delete(string convocatoria, int? curso, string grupopracticas, string user)
        {
            if (convocatoria == null || curso == null || grupopracticas == null || user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutorias tutorias = db.Tutorias.Find(user, grupopracticas, curso, convocatoria);
            if (tutorias == null)
            {
                return HttpNotFound();
            }
            return View(tutorias);
        }

        // POST: Tutorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string convocatoria, int? curso, string grupopracticas, string user)
        {
            Tutorias tutorias = db.Tutorias.Find(user,grupopracticas,curso,convocatoria);
            db.Tutorias.Remove(tutorias);
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
