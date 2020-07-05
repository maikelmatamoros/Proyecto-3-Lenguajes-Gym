using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClienteWebGym.Data;
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

        [HttpGet]
        public async Task<JsonResult> ObtenerUsuarios()
        {
            String datos= await con.ObtenerCentros();
            
            return Json(new { data = datos });
        }

    }
}