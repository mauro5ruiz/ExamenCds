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
using FinalRuiz2018.ViewModels;

namespace FinalRuiz2018.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CdsController : Controller
    {
        private FinalRuiz2018DbContext db = new FinalRuiz2018DbContext();


        public ActionResult AgregarCancion1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cd cd = db.Cds.Find(id);
            if (cd == null)
            {
                return HttpNotFound();

            }

            Cancion cancion = new Cancion
            {
                CdId = cd.CdId,
                Cd = cd
            };
            return View(cancion);
        }

        [HttpPost]
        public ActionResult AgregarCancion1(Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Canciones.Add(cancion);
                    db.SaveChanges();
                    return RedirectToAction($"Details/{cancion.CdId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }         
            }

            return View(cancion);
        }

        // GET: Cds
        public ActionResult Index()
        {
            var cds = db.Cds.Include(c => c.Estilo).Include(c => c.Interprete).Include(c => c.Producto);
            return View(cds.ToList());
        }

        // GET: Cds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cd cd = db.Cds.Find(id);
            if (cd == null)
            {
                return HttpNotFound();
            }
            return View(cd);
        }

        // GET: Cds/Create
        public ActionResult Create()
        {
            var cancion = db.Canciones.ToList();
            var cdViewModel = new CdViewModel
            {
                ProductoId = 1,
                Canciones = cancion,
                Pistas = 1,
                Duracion = 1
            };
            ViewBag.EstiloId = new SelectList(CombosHelper.GetEstilos(), "EstiloId", "Descripcion");
            ViewBag.InterpreteId = new SelectList(CombosHelper.GetInterpretes(), "InterpreteId", "Apellido");

            return View(cdViewModel);
        }

        // POST: Cds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CdViewModel cdViewModel)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var cd = ToCd(cdViewModel);
                        db.Cds.Add(cd);
                        db.SaveChanges();
                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError(string.Empty, ex.Message);
                        if (ex.InnerException != null &&
                            ex.InnerException.InnerException != null &&
                            ex.InnerException.InnerException.Message.Contains("IX"))
                        {
                            ModelState.AddModelError(string.Empty, "El Cd que desea agregar ya existe");
                        }
                        ViewBag.EstiloId = new SelectList(CombosHelper.GetEstilos(), "EstiloId", "Descripcion",
                            cdViewModel.EstiloId);
                        ViewBag.InterpreteId = new SelectList(CombosHelper.GetInterpretes(), "InterpreteId", "Apellido",
                            cdViewModel.InterpreteId);
                        return View(cdViewModel);
                    }
                }
            }
            ViewBag.EstiloId = new SelectList(CombosHelper.GetEstilos(), "EstiloId", "Descripcion", cdViewModel.EstiloId);
            ViewBag.InterpreteId = new SelectList(CombosHelper.GetInterpretes(), "InterpreteId", "Apellido", cdViewModel.InterpreteId);
            return View(cdViewModel);
        }

        private Cd ToCd(CdViewModel cdViewModel)
        {
            return new Cd
            {
                CdId = cdViewModel.CdId,
                Nombre = cdViewModel.Nombre,
                InterpreteId = cdViewModel.InterpreteId,
                EstiloId = cdViewModel.EstiloId,
                Pistas = cdViewModel.Pistas,
                AñoGrabacion = cdViewModel.AñoGrabacion,
                Duracion = cdViewModel.Duracion,
                PrecioCosto = cdViewModel.PrecioCosto,
                PrecioVenta = cdViewModel.PrecioVenta,
                Stock = cdViewModel.Stock,
                ProductoId = cdViewModel.ProductoId
            };
        }

        // GET: Cds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cd cd = db.Cds.Find(id);
            if (cd == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstiloId = new SelectList(CombosHelper.GetEstilos(), "EstiloId", "Descripcion", cd.EstiloId);
            ViewBag.InterpreteId = new SelectList(CombosHelper.GetInterpretes(), "InterpreteId", "Apellido", cd.InterpreteId);
            return View(cd);
        }

        // POST: Cds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CdId,EstiloId,InterpreteId,Pistas,Nombre,AñoGrabacion,Duracion,PrecioCosto,PrecioVenta,Stock,ProductoId")] Cd cd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(cd).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null &&
                        ex.InnerException.InnerException != null &&
                        ex.InnerException.InnerException.Message.Contains("IX"))
                    {
                        ModelState.AddModelError(string.Empty, "El Cd que desea agregar ya existe");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);

                    }
                }
            }
            ViewBag.EstiloId = new SelectList(db.Estilos, "EstiloId", "Descripcion", cd.EstiloId);
            ViewBag.InterpreteId = new SelectList(db.Interpretes, "InterpreteId", "Apellido", cd.InterpreteId);
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "ProductoId", cd.ProductoId);
            return View(cd);
        }

        // GET: Cds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cd cd = db.Cds.Find(id);
            if (cd == null)
            {
                return HttpNotFound();
            }
            return View(cd);
        }

        // POST: Cds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cd cd = db.Cds.Find(id);
            db.Cds.Remove(cd);
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
