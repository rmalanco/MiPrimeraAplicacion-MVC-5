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
        public ActionResult Index()
        {
            var usuarios = from u in db.Usuarios
                           orderby u.Id
                           select u;

            return View(usuarios);
        }

        // GET: Usuarios/Details/5
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult DetailsUser(int id)
        {
            var usuario = db.Usuarios.Single(u => u.Id == id);
            return View(usuario);
        }


        
    }
}

