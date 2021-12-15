using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoTickets;
using System.Net.Mail;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace ProyectoTickets.Controllers
{
    public class INCIDENTEController : Controller
    {
        private db_a7cc1a_ticketsdbEntities1 db = new db_a7cc1a_ticketsdbEntities1();

        // GET: INCIDENTE
        public ActionResult Index()
        {
            var iNCIDENTE = db.INCIDENTE.Include(i => i.AspNetUsers).Include(i => i.CANAL_ORIGEN).Include(i => i.CATEGORIA).Include(i => i.ESTADO).Include(i => i.PRIORIDAD);
            return View(iNCIDENTE.ToList());
        }

        // GET: INCIDENTE/Details/5
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

        // GET: INCIDENTE/Create
        public ActionResult Create()
        {
            ViewBag.ID_USUARIO = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ID_ORIGEN = new SelectList(db.CANAL_ORIGEN, "ID_ORIGEN", "NOMBRE_ORIGEN");
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "NOMBRE_CATEGORIA");
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE_ESTADO");
            ViewBag.ID_PRIORIDAD = new SelectList(db.PRIORIDAD, "ID_PRIORIDAD", "NOMBRE_PRIORIDAD");
            return View();
        }

        // POST: INCIDENTE/Create
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
                var id = iNCIDENTE.ID_INCIDENTE;
                var nombre = iNCIDENTE.NOMBRE;
                var descripcion = iNCIDENTE.DESCRIPCION;
                var fecha_creacion = iNCIDENTE.FECHA_CREACION;
                var categoria= iNCIDENTE.CATEGORIA;
                var estado = iNCIDENTE.ESTADO;
                var origen = iNCIDENTE.CANAL_ORIGEN;
                var prioridad = iNCIDENTE.PRIORIDAD;
            

                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("WLI@IMPETUSCR.com", "Sistema de Gestion de Tickets", System.Text.Encoding.UTF8);//Correo de salida
                correo.To.Add("proyectoticketsmvc@gmail.com"); //Correo destino?
                correo.Subject = "ID-00-"+id +" " + nombre; //Asunto
                correo.Body = "Detalle del Ticket: " + descripcion +  "<br>" +
                    "Fecha de Creacion : " + fecha_creacion + "<br>" +
                   "Categoría : " + categoria + "<br>"
                      + "Origen : " +origen + "<br>"
                      + "prioridad : " + prioridad; //Mensaje del correo + 
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
                smtp.Port = 587; //Puerto de salida
                smtp.Credentials = new System.Net.NetworkCredential("WLI@IMPETUSCR.com", "Data123456!!");//Cuenta de correo
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtp.EnableSsl = true;//True si el servidor de correo permite ssl
                smtp.Send(correo);
                //   Debug.WriteLine("test");
                return RedirectToAction("Index");
            }

            ViewBag.ID_USUARIO = new SelectList(db.AspNetUsers, "Id", "Email", iNCIDENTE.ID_USUARIO);
            ViewBag.ID_ORIGEN = new SelectList(db.CANAL_ORIGEN, "ID_ORIGEN", "NOMBRE_ORIGEN", iNCIDENTE.ID_ORIGEN);
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "NOMBRE_CATEGORIA", iNCIDENTE.ID_CATEGORIA);
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE_ESTADO", iNCIDENTE.ID_ESTADO);
            ViewBag.ID_PRIORIDAD = new SelectList(db.PRIORIDAD, "ID_PRIORIDAD", "NOMBRE_PRIORIDAD", iNCIDENTE.ID_PRIORIDAD);
            return View(iNCIDENTE);
        }

        // GET: INCIDENTE/Edit/5
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

        // POST: INCIDENTE/Edit/5
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

        // GET: INCIDENTE/Delete/5
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

        // POST: INCIDENTE/Delete/5
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
