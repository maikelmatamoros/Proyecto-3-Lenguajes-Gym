using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApiGym.Data;
using WebApiGym.Models;

namespace WebApiGym.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        private readonly SqlConnection conn;
        
        public UsuariosController(IConfiguration configuration)
        {
            Configuration = configuration;
            conn = new SqlConnection(Configuration.GetConnectionString("BaseConnection"));
        }
        //Petición tipo Get: api/Usuarios
        

        [Route("[action]/")]
        [HttpGet]
        public  String GetCentros()
        {
            List<vistaCentro> centros = new List<vistaCentro>();
            conn.Open();
            SqlCommand com = new SqlCommand
            {

                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "sp_obtenerGymVistas"
            };

            SqlDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    vistaCentro aux = new vistaCentro();
                    aux.centro_id = rdr.GetInt32(0);
                    aux.centro_logo_ruta = rdr.GetString(1);
                    aux.centro_nombre = rdr.GetString(2);
                    aux.centro_ubicacion = rdr.GetString(3);
                    centros.Add(aux);
                }

            }
            rdr.Close();
            conn.Close();

            string j = JsonConvert.SerializeObject(centros);
            return j;
        }

        [Route("[action]/")]
        [HttpPost]
        public string ObtenerOcupacion([FromForm] int id, [FromForm] String fecha, [FromForm] String usuario)
        {
           

            List<ControlHorarios> centros = new List<ControlHorarios>();
            conn.Open();
            SqlCommand com = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "sp_getHorarios"
            };
            com.Parameters.Add("@id", SqlDbType.Int).Value = id;
            com.Parameters.Add("@fecha", SqlDbType.VarChar).Value = fecha;
            com.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
            SqlDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    ControlHorarios aux = new ControlHorarios();
                    aux.control_id = rdr.GetInt32(0);
                    aux.control_capacidad = rdr.GetInt32(1);
                    aux.control_hora_bloque = rdr.GetString(2);
                    centros.Add(aux);
                }
            }
            rdr.Close();
            conn.Close();

            string j = JsonConvert.SerializeObject(centros);
            return j;

        }


        [Route("[action]/")]
        [HttpGet]
        public string ObtenerReservaciones(string usuario, String fecha1, String fecha2)
        {
            

            List<ReservacionModel> categorias = new List<ReservacionModel>();
            conn.Open();
            SqlCommand com = new SqlCommand
            {

                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "sp_obtenerReservaciones"
            };

            com.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
            com.Parameters.Add("@fecha1", SqlDbType.Date).Value = fecha1;
            com.Parameters.Add("@fecha2", SqlDbType.Date).Value = fecha2;


            SqlDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    ReservacionModel aux = new ReservacionModel();
                    aux.centro_nombre = rdr.GetString(0);
                    aux.control_hora_bloque = rdr.GetString(1);
                    aux.control_hora_dia = rdr.GetString(2);
                    categorias.Add(aux);
                }
                rdr.Close();
                conn.Close();
            }

            string j = JsonConvert.SerializeObject(categorias);
            return j;

        }

        [Route("[action]/")]
        [HttpPost]
        public string ObtenerClasesVirtuales([FromForm] string id)
        {
            

            List<ClaseVitrual> r = new List<ClaseVitrual>();
            conn.Open();
            SqlCommand com = new SqlCommand
            {

                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "sp_getClasesVirtuales"
            };
            com.Parameters.Add("@id", SqlDbType.Int).Value = id;
            ClaseVitrual cv = new ClaseVitrual();
            
            SqlDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    cv.id = rdr.GetInt32(0);
                    cv.nombre = rdr.GetString(3);
                    cv.descripcion = rdr.GetString(4);
                    cv.hora = rdr.GetString(1);
                    cv.ruta = rdr.GetString(5);
                    cv.fecha = rdr.GetString(2);
                    r.Add(cv);                
                }
            }
            else {
                cv = null;
            }
            rdr.Close();
            conn.Close();

            string j = JsonConvert.SerializeObject(r);
            return j;

        }





        [Route("[action]/")]
        [HttpPost]
        public string ObtenerCentroInfo([FromForm] string id)
        {
            

            CentroInfo centro = new CentroInfo();
            List<string> imagenes = new List<string>();
            conn.Open();
            SqlCommand comInfo = new SqlCommand
            {

                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "sp_obtenerInfoGeneralCentro"
            };

            SqlCommand comImg = new SqlCommand
            {

                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "sp_obtenerCentroImagenes"
            };

            comInfo.Parameters.Add("@id", SqlDbType.Int).Value = id;
            comImg.Parameters.Add("@id", SqlDbType.Int).Value = id;



            SqlDataReader rdr = comInfo.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    centro.Nombre= rdr.GetString(0);
                    centro.Descripcion= rdr.GetString(1);
                    centro.Ubicacion= rdr.GetString(2);
                    centro.Logo= rdr.GetString(3);
                }
                rdr.Close();
                
            }

            SqlDataReader rdrImg = comImg.ExecuteReader();
            if (rdrImg.HasRows)
            {
                while (rdrImg.Read())
                {
                    imagenes.Add(rdrImg.GetString(0));
                }
                rdrImg.Close();
            }
            conn.Close();
            centro.Imagenes = imagenes;
            string j = JsonConvert.SerializeObject(centro);
            return j;

        }


        [Route("[action]/")]
        [HttpPost]
        public string LoginToCentro([FromBody]LoginModel lm)
        {

            conn.Open();
            SqlCommand com = new SqlCommand
            {

                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "sp_loginToCentro"
            };
            com.Parameters.Add("@id", SqlDbType.Int).Value = lm.id;
            com.Parameters.Add("@usuario", SqlDbType.VarChar).Value = lm.userName;
            com.Parameters.Add("@pass", SqlDbType.VarChar).Value = lm.password;
            com.Parameters.Add("@result", SqlDbType.VarChar,2);
            com.Parameters["@result"].Direction = ParameterDirection.Output;

            com.ExecuteNonQuery();
            
            conn.Close();

            

            return Convert.ToString(com.Parameters["@result"].Value);
        }

        [Route("[action]/")]
        [HttpPost]
        public string Reservar([FromForm] string idH,[FromForm] string usuario)
        {

            conn.Open();
            SqlCommand com = new SqlCommand
            {

                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "sp_reservar"
            };


            com.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
            com.Parameters.Add("@idH", SqlDbType.Int).Value = idH;




            SqlDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Close();
                conn.Close();
                return "T";
            }
            return "F";
        }
    }
}