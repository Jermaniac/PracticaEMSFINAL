using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppGestionEMS.Models;

namespace AppGestionProyectoEMS.Controllers
{
    [Authorize(Roles = "admin,profesor")]
    public class MatriculasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Matriculas
        public ActionResult Index()
        {
            var matriculas = db.Matriculas.Include(m => m.Curso).Include(m => m.Grupo).Include(m => m.User);
            return View(matriculas.ToList());
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? curso, string grupo, string user, string nummatricula, DateTime fecha)
        {
            if (curso == null || grupo == null || user == null || nummatricula == null || fecha == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(user, curso, grupo);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            return View(matriculas);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            var alumnos = from user in db.Users
                          from u_r in user.Roles
                          join rol in db.Roles on u_r.RoleId equals rol.Id
                          where rol.Name == "alumno"
                          select user.UserName;
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "CursoId");
            ViewBag.GrupoId = new SelectList(db.Grupos, "GrupoId", "GrupoId");
            ViewBag.UserId = new SelectList(db.Users.Where(u => alumnos.Contains(u.UserName)), "Id", "Name");
            return View();
        }

        // POST: Matriculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,CursoId,GrupoId,numMatricula,fecha")] Matriculas matriculas)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matriculas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "CursoId", matriculas.CursoId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "GrupoId", "GrupoId", matriculas.GrupoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", matriculas.UserId);
            return View(matriculas);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? curso, string grupo, string user, string nummatricula, DateTime fecha)
        {
            if (curso == null || grupo == null || user == null || nummatricula == null || fecha == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(user, curso, grupo);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "CursoId", matriculas.CursoId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "GrupoId", "GrupoId", matriculas.GrupoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", matriculas.UserId);
            return View(matriculas);
        }

        // POST: Matriculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,CursoId,GrupoId,numMatricula,fecha")] Matriculas matriculas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matriculas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "CursoId", matriculas.CursoId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "GrupoId", "GrupoId", matriculas.GrupoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", matriculas.UserId);
            return View(matriculas);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? curso, string grupo, string user, string nummatricula, DateTime fecha)
        {
            if (curso == null || grupo == null || user == null || nummatricula == null || fecha == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(user, curso, grupo);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            return View(matriculas);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? curso, string grupo, string user, string nummatricula, DateTime fecha)
        {
            Matriculas matriculas = db.Matriculas.Find(user, curso, grupo);
            db.Matriculas.Remove(matriculas);
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
