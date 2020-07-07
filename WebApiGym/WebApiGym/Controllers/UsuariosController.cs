using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

        [Route("[action]/")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tb_control>>> ObtenerOcupacion(int id,String fecha)
        {
            var idI = new SqlParameter
            {
                ParameterName = "id",
                Value = id
            };

            var fechaI = new SqlParameter
            {
                ParameterName = "fecha",
                Value = fecha
            };
            return await _context.ControlInfo.FromSqlRaw("sp_getHorarios @id,@fecha", idI,fechaI).ToListAsync();
        }


        [Route("[action]/")]
        [HttpPost]
        public async Task<ActionResult<String>> LoginToCentro([FromBody]LoginModel lm)
        {
            var resutl=new SqlParameter { 
                ParameterName="Result",
                Value = 'E',
                Direction = ParameterDirection.Output };
            
            var idI = new SqlParameter
            {
                ParameterName = "id",
                Value = lm.id
            };

            var usuarioI = new SqlParameter
            {
                ParameterName = "usuario",
                Value = lm.userName
            };

            var passI = new SqlParameter
            {
                ParameterName = "pass",
                Value = lm.password
            };

            var resultado= await _context.Database.ExecuteSqlRawAsync("sp_loginToCentro @id,@usuario,@pass,@result output", idI, usuarioI, passI,resutl);
            return (String)resutl.Value;
        }



    }
}