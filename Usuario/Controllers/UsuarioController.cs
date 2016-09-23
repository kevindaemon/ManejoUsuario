using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Usuario.Data;
using Usuario.Models;
using System.Net;

namespace Usuario.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioContext context = new UsuarioContext();

        // GET: Usuario
        public ActionResult Index()
        {
            var model = context.Usuarios.ToArray();
            return View(model);
        }
        public ActionResult CreateUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUsuario(Models.Usuario us )
        {
            if (ModelState.IsValid)
            {
                context.Usuarios.Add(us);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(us);
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Usuario us = context.Usuarios.Find(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Models.Usuario us = context.Usuarios.Find(id);
            context.Usuarios.Remove(us);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Usuario us = context.Usuarios.Find(id);
            var model = new Models.Usuario();
            model.login = us.login;
            model.name = us.name;
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Models.Usuario us)
        {
            if(ModelState.IsValid)
            {
                context.Entry(us).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(us);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Models.Usuario us = context.Usuarios.Find(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);
        }
        public ActionResult EditPassword(Models.Usuario us)
        {
            if (ModelState.IsValid)
            {
                context.Entry(us).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(us);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}