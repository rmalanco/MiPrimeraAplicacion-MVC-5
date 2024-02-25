using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimeraAplicacion.Controllers
{
    //[Authorize]
    // Authorize: Permite restringir el acceso a los métodos de un controlador a usuarios autenticados
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hello(string name)
        {
            ViewBag.Name = Server.HtmlEncode(name);
            return View();
        }

        //[Authorize (Roles = "Admin")]
        // Authorize: Permite restringir el acceso a los métodos de un controlador a usuarios autenticados
        [OutputCache (Duration = 10)]
        // OutputCache: Permite almacenar en caché el resultado de un método de un controlador
        [ActionName("CurrentTime")]
        // ActionName: Permite cambiar el nombre de un método de un controlador
        public ActionResult CurrentTime()
        {
            ViewBag.CurrentTime = DateTime.Now.ToString("T");
            return View();
        }

        [NonAction]
        // NonAction: Permite ocultar un método de un controlador
        public ActionResult CurrentTime2()
        {
            ViewBag.CurrentTime = CadenaHora();
            return View("CurrentTime");
        }

        private string CadenaHora()
        {
            return DateTime.Now.ToString("T");
        }

        // actions verbs: GET, POST, PUT, DELETE es el tipo de peticion que se hace al servidor
        
        [HttpGet]
        // HttpGet
        // Descripción: Permite que un método de un controlador responda a peticiones GET, las cuales son las peticiones que se realizan al navegar por una página web en la barra de direcciones del navegador
        public ActionResult Get()
        {
            return View();
        }
        // HttpPost
        // Descripción: Permite que un método de un controlador responda a peticiones POST,
        // las cuales son las peticiones que se realizan al enviar un formulario
        [HttpPost]
        public ActionResult Post()
        {
            return View();
        }
        // HttpPut
        // Descripción: Permite que un método de un controlador responda a peticiones PUT,
        // las cuales son las peticiones que se realizan al enviar un formulario
        [HttpPut]
        public ActionResult Put()
        {
            return View();
        }
        // HttpDelete
        // Descripción: Permite que un método de un controlador responda a peticiones DELETE,
        // las cuales son las peticiones que se realizan al enviar un formulario
        [HttpDelete]
        public ActionResult Delete()
        {
            return View();
        }

        // HttpOptions
        // Descripción: Permite que un método de un controlador responda a peticiones OPTIONS,
        // las cuales son las peticiones que se realizan al enviar un formulario
        [HttpOptions]
        public ActionResult Options()
        {
            return View();
        }

        // HttpPatch
        // Descripción: Permite que un método de un controlador responda a peticiones PATCH,
        // las cuales son las peticiones que se realizan al enviar un formulario
        [HttpPatch]
        public ActionResult Patch()
        {
            return View();
        }
    }
} 