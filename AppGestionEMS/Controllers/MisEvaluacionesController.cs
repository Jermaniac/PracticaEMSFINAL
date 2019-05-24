using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppGestionEMS.Models;
using Microsoft.AspNet.Identity;

namespace AppGestionEMS.Controllers
{
    public class MisEvaluacionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MisEvaluaciones
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var evaluaciones = db.Evaluaciones.Include(e => e.Curso).Include(e => e.User).Where(p => p.UserId == currentUserId);
            return View(evaluaciones.ToList());
        }

        // GET: MisEvaluaciones/Details/5
        public ActionResult Details(int? curso, string grupo, string user, string grupopracticas)
        {
            if (curso == null || grupo == null || user == null || grupopracticas == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluaciones evaluaciones = db.Evaluaciones.Find(user, curso, grupo, grupopracticas);
            if (evaluaciones == null)
            {
                return HttpNotFound();
            }
            return View(evaluaciones);
        }

        // GET: MisEvaluaciones/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "CursoId");
            ViewBag.GrupoId = new SelectList(db.Grupos, "GrupoId", "GrupoId");
            ViewBag.GrupoPracticasId = new SelectList(db.GrupoPracticas, "GrupoPracticasId", "GrupoPracticasId");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: MisEvaluaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,CursoId,GrupoId,GrupoPracticasId,ordinariaExtraordinaria,nota,examenPractica,notaFinal")] Evaluaciones evaluaciones)
        {
            if (ModelState.IsValid)
            {
                db.Evaluaciones.Add(evaluaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "CursoId", evaluaciones.CursoId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "GrupoId", "GrupoId", evaluaciones.GrupoId);
            ViewBag.GrupoPracticasId = new SelectList(db.GrupoPracticas, "GrupoPracticasId", "GrupoPracticasId", evaluaciones.GrupoPracticasId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", evaluaciones.UserId);
            return View(evaluaciones);
        }

        // GET: MisEvaluaciones/Edit/5
        public ActionResult Edit(int? curso, string grupo, string user, string grupopracticas)
        {
            if (curso == null || grupo == null || user == null || grupopracticas == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluaciones evaluaciones = db.Evaluaciones.Find(user, curso, grupo, grupopracticas);
            if (evaluaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "CursoId", evaluaciones.CursoId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "GrupoId", "GrupoId", evaluaciones.GrupoId);
            ViewBag.GrupoPracticasId = new SelectList(db.GrupoPracticas, "GrupoPracticasId", "GrupoPracticasId", evaluaciones.GrupoPracticasId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", evaluaciones.UserId);
            return View(evaluaciones);
        }

        // POST: MisEvaluaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,CursoId,GrupoId,GrupoPracticasId,ordinariaExtraordinaria,nota,examenPractica,notaFinal")] Evaluaciones evaluaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "CursoId", evaluaciones.CursoId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "GrupoId", "GrupoId", evaluaciones.GrupoId);
            ViewBag.GrupoPracticasId = new SelectList(db.GrupoPracticas, "GrupoPracticasId", "GrupoPracticasId", evaluaciones.GrupoPracticasId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", evaluaciones.UserId);
            return View(evaluaciones);
        }

        // GET: MisEvaluaciones/Delete/5
        public ActionResult Delete(int? curso, string grupo, string user, string grupopracticas)
        {
            if (curso == null || grupo == null || user == null || grupopracticas == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluaciones evaluaciones = db.Evaluaciones.Find(user, curso, grupo, grupopracticas);
            if (evaluaciones == null)
            {
                return HttpNotFound();
            }
            return View(evaluaciones);
        }

        // POST: MisEvaluaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? curso, string grupo, string user, string grupopracticas)
        {
            Evaluaciones evaluaciones = db.Evaluaciones.Find(user,curso,grupo,grupopracticas);
            db.Evaluaciones.Remove(evaluaciones);
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
