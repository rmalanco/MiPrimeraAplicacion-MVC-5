using MiPrimeraAplicacion.Data;
using MiPrimeraAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;

namespace MiPrimeraAplicacion.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Usuarios
        //[OutputCache(Duration = 60)]
        [OutputCache(CacheProfile = "Cache1Minute")]
        // OutputCache es un atributo que permite almacenar en caché el resultado de un método de acción durante un tiempo determinado, esto puede mejorar el rendimiento de la aplicación.
        public ActionResult Index()
        {
            var usuarios = from u in db.Usuarios
                           orderby u.Id
                           select u;

            return View(usuarios);
        }

        // GET: Usuarios/Details/5
        [OutputCache(Duration = int.MaxValue, VaryByParam = "id")]
        public ActionResult Details(int id)
        {
            return DetailsUser(id);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    LimpiarCache();
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return DetailsUser(id);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    LimpiarCache();
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return DetailsUser(id);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            try
            {
                var usuarioEliminar = db.Usuarios.Single(u => u.Id == usuario.Id);
                db.Usuarios.Remove(usuarioEliminar);
                db.SaveChanges();
                LimpiarCache();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult DetailsUser(int id)
        {
            var usuario = db.Usuarios.SingleOrDefault(u => u.Id == id);
            return View(usuario);
        }
        
        // Metodo de limpieza de cache
        private void LimpiarCache()
        {
            Response.RemoveOutputCacheItem(Url.Action("Index"));
        }
    }
}

