using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FinalRuiz2018.Clasess;
using FinalRuiz2018.Models;
using FinalRuiz2018.ViewModels;

namespace FinalRuiz2018.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DvdsController : Controller
    {
        private FinalRuiz2018DbContext db = new FinalRuiz2018DbContext();

        // GET: Dvds
        public ActionResult Index()
        {
            var dvds = db.Dvds.Include(d => d.Categoria).Include(d => d.Genero).Include(d => d.Producto).Include(d => d.TipoDvd);
            return View(dvds.ToList());
        }

        // GET: Dvds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dvd dvd = db.Dvds.Find(id);
            if (dvd == null)
            {
                return HttpNotFound();
            }
            return View(dvd);
        }

        // GET: Dvds/Create
        public ActionResult Create()
        {
            var dvdViewModel = new DvdViewModel
            {
                ProductoId = 3
            };
            ViewBag.CategoriaId = new SelectList(CombosHelper.GetCategorias(), "CategoriaId", "Descripcion");
            ViewBag.GeneroId = new SelectList(CombosHelper.GetGeneros(), "GeneroId", "Descripcion");
            ViewBag.TipoDvdId = new SelectList(CombosHelper.GetTiposDvds(), "TipoDvdId", "Nombre");
            return View(dvdViewModel);
        }

        // POST: Dvds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DvdViewModel dvdViewModel)
        {
            if (ModelState.IsValid)
            {
                using (var transaction=db.Database.BeginTransaction())
                {
                    try
                    {
                        var dvd = ToDvd(dvdViewModel);
                        db.Dvds.Add(dvd);
                        db.SaveChanges();
                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null &&
                            ex.InnerException.InnerException != null &&
                            ex.InnerException.InnerException.Message.Contains("IX"))
                        {
                            ModelState.AddModelError(string.Empty, "El Dvd que desea agregar ya existe");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, ex.Message);

                        }
                        ViewBag.GeneroId = new SelectList(CombosHelper.GetGeneros(), "GeneroId", "Descripcion",
                            dvdViewModel.GeneroId);
                        ViewBag.TipoDvdId = new SelectList(CombosHelper.GetTiposDvds(), "TipoDvdId", "Nombre",
                            dvdViewModel.TipoDvdId);
                        ViewBag.CategoriaId = new SelectList(CombosHelper.GetCategorias(), "CategoriaId", "Descripcion",
                            dvdViewModel.CategoriaId);
                        return View(dvdViewModel);
                    }
                }
            }

            ViewBag.CategoriaId = new SelectList(CombosHelper.GetCategorias(), "CategoriaId", "Descripcion", dvdViewModel.CategoriaId);
            ViewBag.GeneroId = new SelectList(CombosHelper.GetGeneros(), "GeneroId", "Descripcion", dvdViewModel.GeneroId);
            ViewBag.TipoDvdId = new SelectList(CombosHelper.GetTiposDvds(), "TipoDvdId", "Nombre", dvdViewModel.TipoDvdId);
            return View(dvdViewModel);
        }

        private Dvd ToDvd(DvdViewModel dvdViewModel)
        {
            return new Dvd
            {
                DvdId = dvdViewModel.DvdId,
                CategoriaId = dvdViewModel.CategoriaId,
                GeneroId = dvdViewModel.GeneroId,
                TipoDvdId = dvdViewModel.TipoDvdId,
                Titulo = dvdViewModel.Titulo,
                AñoGrabacion = dvdViewModel.AñoGrabacion,
                Duracion = dvdViewModel.Duracion,
                PrecioCosto = dvdViewModel.PrecioCosto,
                PrecioVenta = dvdViewModel.PrecioVenta,
                Stock = dvdViewModel.Stock,
                ProductoId = dvdViewModel.ProductoId
            };
        }

        // GET: Dvds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dvd dvd = db.Dvds.Find(id);
            if (dvd == null)
            {
                return HttpNotFound();
            }           
            ViewBag.CategoriaId = new SelectList(CombosHelper.GetCategorias(), "CategoriaId", "Descripcion", dvd.CategoriaId);
            ViewBag.GeneroId = new SelectList(CombosHelper.GetGeneros(), "GeneroId", "Descripcion", dvd.GeneroId);
            ViewBag.TipoDvdId = new SelectList(CombosHelper.GetTiposDvds(), "TipoDvdId", "Nombre", dvd.TipoDvdId);
            return View(dvd);
        }

        // POST: Dvds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DvdId,CategoriaId,TipoDvdId,GeneroId,Titulo,AñoGrabacion,Duracion,Stock,PrecioCosto,PrecioVenta,ProductoId")] Dvd dvd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(dvd).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null &&
                        ex.InnerException.InnerException != null &&
                        ex.InnerException.InnerException.Message.Contains("IX"))
                    {
                        ModelState.AddModelError(string.Empty, "El Dvd que modificó ya existe");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);

                    }
                }
            }
            ViewBag.CategoriaId = new SelectList(CombosHelper.GetCategorias(), "CategoriaId", "Descripcion", dvd.CategoriaId);
            ViewBag.GeneroId = new SelectList(CombosHelper.GetGeneros(), "GeneroId", "Descripcion", dvd.GeneroId);
            ViewBag.TipoDvdId = new SelectList(CombosHelper.GetTiposDvds(), "TipoDvdId", "Nombre", dvd.TipoDvdId);
            return View(dvd);
        }

        // GET: Dvds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dvd dvd = db.Dvds.Find(id);
            if (dvd == null)
            {
                return HttpNotFound();
            }
            return View(dvd);
        }

        // POST: Dvds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dvd dvd = db.Dvds.Find(id);
            db.Dvds.Remove(dvd);
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
