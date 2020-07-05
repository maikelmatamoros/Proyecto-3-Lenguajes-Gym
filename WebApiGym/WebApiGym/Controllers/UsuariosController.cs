using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiGym.Data;
using WebApiGym.Models;

namespace WebApiGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly GymContext _context;
        //private readonly QueryContext _query;

        public UsuariosController(GymContext context)
        {
            _context = context;
            //_query = query;
        }

        //Petición tipo Get: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tb_usuario>>> GetUsuariosItems()
        {
        
            return await _context.tb_Usuario.FromSqlRaw<tb_usuario>("sp_getUsers").ToListAsync();
        }

        [Route("[action]/")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vistaCentro>>> GetCentros() 
        {
            return await _context.centroInfo.FromSqlRaw("sp_obtenerGymVistas").ToListAsync();
        }

        //[Route("[action]/")]
        //[HttpPost]
        //public async Task<ActionResult<IEnumerable<queryLoginResult>>> LoginToCentro(String id, String userName, String password)
        //{
        //    return await _query.loginQueryResult.FromSqlRaw("sp_loginToCentro @id,@usuario,@pass", id, userName, password).ToListAsync();
        //}



    }
}