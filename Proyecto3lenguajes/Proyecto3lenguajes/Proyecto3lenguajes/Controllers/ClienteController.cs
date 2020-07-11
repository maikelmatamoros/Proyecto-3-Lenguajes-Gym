using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto3lenguajes.Data;
using Proyecto3lenguajes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ClienteWebGym.Models;

namespace ClienteWebGym.Controllers
{
    public class ClienteController : Controller
    {
        ConexionApiWeb con = new ConexionApiWeb();

        public IActionResult ClienteGymList()
        {
            return View();
        }

        public IActionResult CentroInfoView()
        {
            return View();
        }

        public IActionResult ReservacionesView()
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

        [HttpPost]
        public async Task<String> Reservar(String idH)
        {
            List<int> horarios = JsonConvert.DeserializeObject<List<int>>(idH);
            string usuario = HttpContext.Session.GetString("User");
            for (int i = 0; i < horarios.Count();i++) {
                await con.Reservar(horarios[i], usuario);
            }
            
            return "S";

        }



        [HttpGet]
        public async Task<JsonResult> ObtenerUsuarios()
        {
            String datos= await con.ObtenerCentros();
            
            return Json(new { data = datos });
        }

        [HttpPost]
        public async Task<JsonResult> ObtenerClasesVirtuales()
        {
            string usuario = HttpContext.Session.GetString("Centro");
            String datos = await con.ObtenerClases(usuario);
            var model = JsonConvert.DeserializeObject<List<ClasesVirtuales>>(datos);
            return Json(new { data = model });
        }

        [HttpPost]
        public async Task<JsonResult> ObtenerInfoCentro()
        {

            string Centro = HttpContext.Session.GetString("Centro");
            String datos = await con.ObtenerCentroInfoGenera(Centro);
            return Json(new { data = datos });
        
        }

        [HttpGet]
        public async Task<JsonResult> ObtenerOcupacion(String fecha)
        {
            String centro= HttpContext.Session.GetString("Centro");
            string usuario = HttpContext.Session.GetString("User");
            String datos = await con.ObtenerHoras(centro, fecha,usuario);
            var model = JsonConvert.DeserializeObject<List<ControlModel>>(datos);
            return Json(new { data = model});
        }

        [HttpGet]
        public async Task<JsonResult> ObtenerReservaciones(String fecha1,String fecha2)
        {
            string usuario = HttpContext.Session.GetString("User");
            String datos = await con.ObtenerReservaciones(usuario, fecha1, fecha2);
            var model = JsonConvert.DeserializeObject<List<ReservacionModel>>(datos);
            return Json(new { data = model });
        }


    }
}