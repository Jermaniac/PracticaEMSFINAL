﻿using System;
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

    public class EvaluacionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Evaluaciones
        public ActionResult Index()
        {
            var evaluaciones = db.Evaluaciones.Include(e => e.Curso).Include(e => e.Grupo).Include(e => e.GrupoPractica).Include(e => e.User);
            return View(evaluaciones.ToList());
        }

        // GET: Evaluaciones/Details/5
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

        // GET: Evaluaciones/Create
        public ActionResult Create()
        {
            var alumnos = from user in db.Users
                          from u_r in user.Roles
                          join rol in db.Roles on u_r.RoleId equals rol.Id
                          where rol.Name == "alumno"
                          select user.UserName;
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "CursoId");
            ViewBag.GrupoId = new SelectList(db.Grupos, "GrupoId", "GrupoId");
            ViewBag.GrupoPracticasId = new SelectList(db.GrupoPracticas, "GrupoPracticasId", "GrupoPracticasId");
            ViewBag.UserId = new SelectList(db.Users.Where(u => alumnos.Contains(u.UserName)), "Id", "Name");
            return View();
        }

        // POST: Evaluaciones/Create
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

        // GET: Evaluaciones/Edit/5
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

        // POST: Evaluaciones/Edit/5
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

        // GET: Evaluaciones/Delete/5
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

        // POST: Evaluaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? curso, string grupo, string user, string grupopracticas)
        {
            Evaluaciones evaluaciones = db.Evaluaciones.Find(user, curso, grupo,grupopracticas);
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
