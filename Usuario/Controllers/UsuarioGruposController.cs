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
    public class UsuarioGruposController : Controller
    {
        private UsuarioContext context = new UsuarioContext();

        public ActionResult Index()
        {
            var model = context.UsuarioGrupos.ToArray();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateUsuarioGrupo(Models.UsuarioGrupo us)
        {
            if (ModelState.IsValid)
            {
                context.UsuarioGrupos.Add(us);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(us);
        }

       
        [HttpPost]
        public ActionResult Delete(int? usuarioId, int? grupoId)
        {
            Models.UsuarioGrupo us = context.UsuarioGrupos.Find(usuarioId, grupoId);
            context.UsuarioGrupos.Remove(us);
            context.SaveChanges();
            return RedirectToAction("Index");
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