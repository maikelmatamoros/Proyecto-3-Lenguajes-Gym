using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClienteWebGym.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteWebGym.Controllers
{
    public class ClienteController : Controller
    {
        WebApiGymConnection con = new WebApiGymConnection();

        public IActionResult ClienteGymList()
        {
            return View();
        }

        public IActionResult LoginView()
        {
            ViewBag.Logo = HttpContext.Session.GetString("Logo");
            ViewBag.Nombre= HttpContext.Session.GetString("Nombre");
            return View();
        }

        public IActionResult UsuarioMainView()
        {
            return View();
        }

        [HttpPost]
        public String LoginToCenter(int Center,String Nombre,String Logo)
        {
            HttpContext.Session.SetString("Centro", Center.ToString());
            HttpContext.Session.SetString("Logo", Logo);
            HttpContext.Session.SetString("Nombre", Nombre);
            return "S";
        }

        [HttpPost]
        public async Task<String> Login(String Usuario, String Contraseña) {
            int centro = int.Parse(HttpContext.Session.GetString("Centro"));
            string response= await con.Login(centro, Usuario, Contraseña);
            if (response == "S")
            {
                HttpContext.Session.SetString("User", Usuario);
            }
            return response;

        }

        [HttpGet]
        public async Task<JsonResult> ObtenerUsuarios()
        {
            String datos= await con.ObtenerCentros();
            
            return Json(new { data = datos });
        }

        [HttpGet]
        public async Task<JsonResult> ObtenerOcupacion(String fecha)
        {
            String centro= HttpContext.Session.GetString("Centro");
            String datos = await con.ObtenerHoras(centro, fecha);

            return Json(new { data = datos });
        }

    }
}