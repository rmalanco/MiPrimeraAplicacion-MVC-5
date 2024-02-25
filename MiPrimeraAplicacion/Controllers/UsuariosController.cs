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

// Que es un Modelo:
// Un modelo en MVC es la representación de los datos con los que el sistema opera. 
// El modelo es la parte de la aplicación que gestiona la lógica de negocio, 
// la lógica de acceso a los datos y las estructuras de datos que se utilizan. 
// En resumen, el modelo es el componente de la aplicación que gestiona los datos y las reglas de negocio.

// ¿Qué es un HtmlHelper?
// Los HtmlHelpers son métodos que generan código HTML.

// Que es el Model Binding:
// El model binding es el proceso de asignar valores de las peticiones HTTP a los parámetros de los métodos de acción de un controlador.
// ejemplo:
// public ActionResult Edit(int id, FormCollection collection)
// {
//     var usuario = listUsuarios.Single(u => u.Id == id);
//     if (TryUpdateModel(usuario))
//     {
//         return RedirectToAction("Index");
//     }
//     return View(usuario);
// }
// como podemos ver el id es un parametro que se le pasa a la accion y el FormCollection es un parametro que se le pasa a la accion

//[NonAction]
//public List<Usuario> ObtenerUsuarios()
//{
//    return new List<Usuario>
//    {
//        new Usuario { Id = 1, UserName = "admin", Password = "admin" },
//        new Usuario { Id = 2, UserName = "user", Password = "user" }
//    };
//}

