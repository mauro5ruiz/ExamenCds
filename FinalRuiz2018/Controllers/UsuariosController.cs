using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalRuiz2018.Clasess;
using FinalRuiz2018.Content;
using FinalRuiz2018.Models;
using FinalRuiz2018.ViewModels;

namespace FinalRuiz2018.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuariosController : Controller
    {
        private FinalRuiz2018DbContext db = new FinalRuiz2018DbContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                using (var transaction=db.Database.BeginTransaction())
                {
                    try
                    {
                        var usuario = ToUsuario(usuarioViewModel);
                        db.Usuarios.Add(usuario);
                        db.SaveChanges();

                        UserHelper.CreateUserASP(usuario.NombreUsuario, "Usuario");
                        if (usuarioViewModel.ArchivoFoto != null)
                        {
                            var folder = "~/Content/Usuarios";
                            var file = $"{usuario.UsuarioId}.jpg";
                            var response = FileHelper.UploadPhoto(usuarioViewModel.ArchivoFoto, folder, file);
                            if (response)
                            {
                                var pic = $"{folder}/{file}";
                                usuario.Foto = pic;
                                db.Entry(usuario).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }

                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return View(usuarioViewModel);
                    }
                }
            }

            return View(usuarioViewModel);
        }

        private Usuario ToUsuario(UsuarioViewModel usuarioViewModel)
        {
            return new Usuario
            {
                Apellido = usuarioViewModel.Apellido,
                Nombres = usuarioViewModel.Nombres,
                Celular = usuarioViewModel.Celular,
                Direccion = usuarioViewModel.Direccion,
                UsuarioId = usuarioViewModel.UsuarioId,
                NombreUsuario = usuarioViewModel.NombreUsuario,
                Foto = usuarioViewModel.Foto
            };
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }

            var usuarioViewModel = ToViewModel(usuario);
            return View(usuarioViewModel);
        }

        private UsuarioViewModel ToViewModel(Usuario usuario)
        {
            return new UsuarioViewModel
            {
                UsuarioId = usuario.UsuarioId,
                Nombres = usuario.Nombres,
                Apellido = usuario.Apellido,
                NombreUsuario = usuario.NombreUsuario,
                Celular = usuario.Celular,
                Foto = usuario.Foto,
                Direccion = usuario.Direccion
            };
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                using (var transaction=db.Database.BeginTransaction())
                {
                    try
                    {
                        var usuario = ToUsuario(usuarioViewModel);
                        if (usuarioViewModel.ArchivoFoto != null)
                        {
                            var folder = "~/Content/Usuarios";
                            var file = $"{usuario.UsuarioId}.jpg";
                            var response = FileHelper.UploadPhoto(usuarioViewModel.ArchivoFoto, folder, file);
                            if (response)
                            {
                                var pic = $"{folder}/{file}";
                                usuario.Foto = pic;
                            }
                        }
                        var db2 = new FinalRuiz2018DbContext();
                        var currentUser = db2.Usuarios.Find(usuario.UsuarioId);
                        if (currentUser.NombreUsuario != usuario.NombreUsuario)
                        {
                            UserHelper.UpdateUserName(currentUser.NombreUsuario, usuario.NombreUsuario);
                        }
                        db2.Dispose();
                        db.Entry(usuario).State = EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError(String.Empty, ex.Message);
                        return View(usuarioViewModel);
                    }
                }
            }
            return View(usuarioViewModel);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
