using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoTickets;

namespace ProyectoTickets.Controllers
{
    public class INCIDENTE_CLIENTEController : Controller
    {
        private db_a7cc1a_ticketsdbEntities1 db = new db_a7cc1a_ticketsdbEntities1();

        // GET: INCIDENTE_CLIENTE
        public ActionResult Index()
        {
            var iNCIDENTE = db.INCIDENTE.Include(i => i.AspNetUsers).Include(i => i.CANAL_ORIGEN).Include(i => i.CATEGORIA).Include(i => i.ESTADO).Include(i => i.PRIORIDAD);
            return View(iNCIDENTE.ToList());
        }

        // GET: INCIDENTE_CLIENTE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCIDENTE iNCIDENTE = db.INCIDENTE.Find(id);
            if (iNCIDENTE == null)
            {
                return HttpNotFound();
            }
            return View(iNCIDENTE);
        }

        // GET: INCIDENTE_CLIENTE/Create
        public ActionResult Create()
        {
            ViewBag.ID_USUARIO = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ID_ORIGEN = new SelectList(db.CANAL_ORIGEN, "ID_ORIGEN", "NOMBRE_ORIGEN");
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "NOMBRE_CATEGORIA");
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE_ESTADO");
            ViewBag.ID_PRIORIDAD = new SelectList(db.PRIORIDAD, "ID_PRIORIDAD", "NOMBRE_PRIORIDAD");
            return View();
        }

        // POST: INCIDENTE_CLIENTE/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_INCIDENTE,ID_USUARIO,ID_CATEGORIA,ID_PRIORIDAD,ID_ESTADO,ID_ORIGEN,NOMBRE,DESCRIPCION,FECHA_CREACION,FECHA_ACTUALIZACION,DURACION,MOTIVO_CIERRE")] INCIDENTE iNCIDENTE)
        {
            if (ModelState.IsValid)
            {
                db.INCIDENTE.Add(iNCIDENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_USUARIO = new SelectList(db.AspNetUsers, "Id", "Email", iNCIDENTE.ID_USUARIO);
            ViewBag.ID_ORIGEN = new SelectList(db.CANAL_ORIGEN, "ID_ORIGEN", "NOMBRE_ORIGEN", iNCIDENTE.ID_ORIGEN);
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "NOMBRE_CATEGORIA", iNCIDENTE.ID_CATEGORIA);
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE_ESTADO", iNCIDENTE.ID_ESTADO);
            ViewBag.ID_PRIORIDAD = new SelectList(db.PRIORIDAD, "ID_PRIORIDAD", "NOMBRE_PRIORIDAD", iNCIDENTE.ID_PRIORIDAD);
            return View(iNCIDENTE);
        }

        // GET: INCIDENTE_CLIENTE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCIDENTE iNCIDENTE = db.INCIDENTE.Find(id);
            if (iNCIDENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_USUARIO = new SelectList(db.AspNetUsers, "Id", "Email", iNCIDENTE.ID_USUARIO);
            ViewBag.ID_ORIGEN = new SelectList(db.CANAL_ORIGEN, "ID_ORIGEN", "NOMBRE_ORIGEN", iNCIDENTE.ID_ORIGEN);
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "NOMBRE_CATEGORIA", iNCIDENTE.ID_CATEGORIA);
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE_ESTADO", iNCIDENTE.ID_ESTADO);
            ViewBag.ID_PRIORIDAD = new SelectList(db.PRIORIDAD, "ID_PRIORIDAD", "NOMBRE_PRIORIDAD", iNCIDENTE.ID_PRIORIDAD);
            return View(iNCIDENTE);
        }

        // POST: INCIDENTE_CLIENTE/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_INCIDENTE,ID_USUARIO,ID_CATEGORIA,ID_PRIORIDAD,ID_ESTADO,ID_ORIGEN,NOMBRE,DESCRIPCION,FECHA_CREACION,FECHA_ACTUALIZACION,DURACION,MOTIVO_CIERRE")] INCIDENTE iNCIDENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNCIDENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_USUARIO = new SelectList(db.AspNetUsers, "Id", "Email", iNCIDENTE.ID_USUARIO);
            ViewBag.ID_ORIGEN = new SelectList(db.CANAL_ORIGEN, "ID_ORIGEN", "NOMBRE_ORIGEN", iNCIDENTE.ID_ORIGEN);
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "NOMBRE_CATEGORIA", iNCIDENTE.ID_CATEGORIA);
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE_ESTADO", iNCIDENTE.ID_ESTADO);
            ViewBag.ID_PRIORIDAD = new SelectList(db.PRIORIDAD, "ID_PRIORIDAD", "NOMBRE_PRIORIDAD", iNCIDENTE.ID_PRIORIDAD);
            return View(iNCIDENTE);
        }

        // GET: INCIDENTE_CLIENTE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCIDENTE iNCIDENTE = db.INCIDENTE.Find(id);
            if (iNCIDENTE == null)
            {
                return HttpNotFound();
            }
            return View(iNCIDENTE);
        }

        // POST: INCIDENTE_CLIENTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INCIDENTE iNCIDENTE = db.INCIDENTE.Find(id);
            db.INCIDENTE.Remove(iNCIDENTE);
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
