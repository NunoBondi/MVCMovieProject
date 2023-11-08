using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EjercicioMVC3.Models;

namespace EjercicioMVC3.Controllers
{
    [Authorize]

    public class RepartosController : Controller
    {
        private EjercicioMVC3ModelContainer db = new EjercicioMVC3ModelContainer();

        // GET: Repartos
        public ActionResult Index()
        {
            var repartos = db.Repartos.Include(r => r.Pelicula).Include(r => r.Actor);
            return View(repartos.ToList());
        }

        // GET: Repartos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparto reparto = db.Repartos.Find(id);
            if (reparto == null)
            {
                return HttpNotFound();
            }
            return View(reparto);
        }

        // GET: Repartos/Create
        public ActionResult Create()
        {
            ViewBag.PeliculaId = new SelectList(db.Peliculas, "Id", "Titulo");
            ViewBag.ActorId = new SelectList(db.Actores, "Id", "NombreActor");
            return View();
        }

        // POST: Repartos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Personaje,PeliculaId,ActorId")] Reparto reparto)
        {
            if (ModelState.IsValid)
            {
                db.Repartos.Add(reparto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PeliculaId = new SelectList(db.Peliculas, "Id", "Titulo", reparto.PeliculaId);
            ViewBag.ActorId = new SelectList(db.Actores, "Id", "NombreActor", reparto.ActorId);
            return View(reparto);
        }

        // GET: Repartos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparto reparto = db.Repartos.Find(id);
            if (reparto == null)
            {
                return HttpNotFound();
            }
            ViewBag.PeliculaId = new SelectList(db.Peliculas, "Id", "Titulo", reparto.PeliculaId);
            ViewBag.ActorId = new SelectList(db.Actores, "Id", "NombreActor", reparto.ActorId);
            return View(reparto);
        }

        // POST: Repartos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Personaje,PeliculaId,ActorId")] Reparto reparto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reparto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PeliculaId = new SelectList(db.Peliculas, "Id", "Titulo", reparto.PeliculaId);
            ViewBag.ActorId = new SelectList(db.Actores, "Id", "NombreActor", reparto.ActorId);
            return View(reparto);
        }

        // GET: Repartos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparto reparto = db.Repartos.Find(id);
            if (reparto == null)
            {
                return HttpNotFound();
            }
            return View(reparto);
        }

        // POST: Repartos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reparto reparto = db.Repartos.Find(id);
            db.Repartos.Remove(reparto);
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
