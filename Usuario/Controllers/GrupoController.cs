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
    public class GrupoController : Controller
    {
        private UsuarioContext  context = new UsuarioContext();

        public ActionResult Index()
        {
            var model = context.Grupos.ToArray();
            return View(model);
        }
        public ActionResult CreateGrupo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateGrupo(Models.Grupo us)
        {
            if (ModelState.IsValid)
            {
                context.Grupos.Add(us);
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
            Models.Grupo us = context.Grupos.Find(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Models.Grupo us = context.Grupos.Find(id);
            context.Grupos.Remove(us);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Grupo us = context.Grupos.Find(id);
            var model = new Models.Grupo();
            model.group_name = us.group_name;
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Models.Grupo us)
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
            Models.Grupo us = context.Grupos.Find(id);
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