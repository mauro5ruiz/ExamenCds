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
    [Authorize(Roles = "Usuario")]
    public class ComprasController : Controller
    {
        private FinalRuiz2018DbContext db = new FinalRuiz2018DbContext();

        // GET: Compras
        public ActionResult Index()
        {
            var compras = db.Compras.Include(c => c.Proveedor);
            return View(compras.ToList());
        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            var usuario = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == User.Identity.Name);
            if (usuario==null)
            {
                return RedirectToAction("Index","Home");
            }

            var tmp = db.DetallesCompraTmps.Where(pdt => pdt.NombreUsuario == usuario.NombreUsuario).ToList();
            var compraViewModel = new CompraViewModel
            {
                Detalles = tmp,
                Fecha = DateTime.Now
            };
            ViewBag.ProveedorId = new SelectList(CombosHelper.GetProveedores(), "ProveedorId", "RazonSocial");
            return View(compraViewModel);
        }

        // POST: Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompraId,ProveedorId,Fecha,Observaciones")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compras.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProveedorId = new SelectList(CombosHelper.GetProveedores(), "ProveedorId", "RazonSocial", compra.ProveedorId);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProveedorId = new SelectList(CombosHelper.GetProveedores(), "ProveedorId", "RazonSocial", compra.ProveedorId);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompraId,ProveedorId,Fecha,Observaciones")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProveedorId = new SelectList(CombosHelper.GetProveedores(), "ProveedorId", "RazonSocial", compra.ProveedorId);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.Compras.Find(id);
            db.Compras.Remove(compra);
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
