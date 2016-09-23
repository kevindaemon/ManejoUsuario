using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Usuario.Data;
using System.Net;

namespace Usuario.Controllers
{
    public class ProgramaController : Controller
    {
        private UsuarioContext context = new UsuarioContext();

        public ActionResult Index()
        {
            var model = context.Programas.ToArray();
            return View(model);
        }
        public ActionResult CreatePrograma()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePrograma(Models.Programa us)
        {
            if (ModelState.IsValid)
            {
                context.Programas.Add(us);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(us);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Programa us = context.Programas.Find(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Models.Programa us = context.Programas.Find(id);
            context.Programas.Remove(us);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Programa us = context.Programas.Find(id);
            var model = new Models.Programa();
            model.ProgramName = us.ProgramName;
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Models.Programa us)
        {
            if (ModelState.IsValid)
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
            Models.Programa us = context.Programas.Find(id);
            if (us == null)
            {
                return HttpNotFound();
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