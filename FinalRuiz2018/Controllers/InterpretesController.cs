using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalRuiz2018.Clasess;
using FinalRuiz2018.Models;

namespace FinalRuiz2018.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InterpretesController : Controller
    {
        private FinalRuiz2018DbContext db = new FinalRuiz2018DbContext();

        // GET: Interpretes
        public ActionResult Index()
        {
            var interpretes = db.Interpretes.Include(i => i.Nacionalidad);
            return View(interpretes.ToList());
        }

        // GET: Interpretes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interprete interprete = db.Interpretes.Find(id);
            if (interprete == null)
            {
                return HttpNotFound();
            }
            return View(interprete);
        }

        // GET: Interpretes/Create
        public ActionResult Create()
        {
            ViewBag.NacionalidadId = new SelectList(CombosHelper.GetNacionalidades(), "NacionalidadId", "Nombre");
            return View();
        }

        // POST: Interpretes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InterpreteId,Apellido,Nombres,NacionalidadId")] Interprete interprete)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Interpretes.Add(interprete);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null &&
                        ex.InnerException.InnerException != null &&
                        ex.InnerException.InnerException.Message.Contains("IX"))
                    {
                        ModelState.AddModelError(string.Empty, "El interprete que desea agregar ya existe");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);

                    }
                }
            }

            ViewBag.NacionalidadId = new SelectList(CombosHelper.GetNacionalidades(), "NacionalidadId", "Nombre", interprete.NacionalidadId);
            return View(interprete);
        }

        // GET: Interpretes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interprete interprete = db.Interpretes.Find(id);
            if (interprete == null)
            {
                return HttpNotFound();
            }
            ViewBag.NacionalidadId = new SelectList(CombosHelper.GetNacionalidades(), "NacionalidadId", "Nombre", interprete.NacionalidadId);
            return View(interprete);
        }

        // POST: Interpretes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InterpreteId,Apellido,Nombres,NacionalidadId")] Interprete interprete)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(interprete).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null &&
                        ex.InnerException.InnerException != null &&
                        ex.InnerException.InnerException.Message.Contains("IX"))
                    {
                        ModelState.AddModelError(string.Empty, "El interprete que modificó ya existe");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);

                    }
                }
            }
            ViewBag.NacionalidadId = new SelectList(CombosHelper.GetNacionalidades(), "NacionalidadId", "Nombre", interprete.NacionalidadId);
            return View(interprete);
        }

        // GET: Interpretes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interprete interprete = db.Interpretes.Find(id);
            if (interprete == null)
            {
                return HttpNotFound();
            }
            return View(interprete);
        }

        // POST: Interpretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Interprete interprete = db.Interpretes.Find(id);
            db.Interpretes.Remove(interprete);
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
