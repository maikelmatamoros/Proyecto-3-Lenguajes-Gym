using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto3lenguajes.Models;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Proyecto3lenguajes.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly IHostingEnvironment hostingEnvironment;
        public HomeController(IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        SqlConnection conn = new SqlConnection("Server = 163.178.107.10; Database=IF4101Proyecto3AM;User ID = laboratorios; Password=Saucr.118;MultipleActiveResultSets=true");


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult loginA()
        {
            return View(new Administrador());
        }
        public IActionResult PaginaPricipal()
        {
            return View(new Administrador());
        }
        public IActionResult Actualizar()
        {
            return View(new Administrador());
        }
        public IActionResult loginAdm()
        {
            return View(new Administrador());
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public string InsertarGym(Administrador administrador)
        {

            var uniqueFileName = administrador.logo.FileName;
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
            var filePath = Path.Combine(uploads, uniqueFileName);
            administrador.logo.CopyTo(new FileStream(filePath, FileMode.Create));

            conn.Open();
            SqlCommand com = new SqlCommand
            {

                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "sp_ingresarCentro"

            };
            
            com.Parameters.Add("@nombre", SqlDbType.VarChar).Value = administrador.nombre_negocio;
            com.Parameters.Add("@pass", SqlDbType.VarChar).Value = administrador.pass;
            com.Parameters.Add("@descrpcion", SqlDbType.VarChar).Value = administrador.descripcion;
            com.Parameters.Add("@ubicacion", SqlDbType.VarChar).Value = administrador.ubicacion;
            com.Parameters.Add("@telefono", SqlDbType.VarChar).Value = administrador.telefono;
            com.Parameters.Add("@correo", SqlDbType.VarChar).Value = administrador.correo;
            com.Parameters.Add("@capacidadM", SqlDbType.Int).Value = administrador.capacidad;
            com.Parameters.Add("@porcentaje", SqlDbType.Int).Value = administrador.porcentaje;
            com.Parameters.Add("@horaI", SqlDbType.VarChar).Value = administrador.horaI;
            com.Parameters.Add("@horaC", SqlDbType.VarChar).Value = administrador.horaC;
            com.Parameters.Add("@ruta", SqlDbType.VarChar).Value = uniqueFileName;
            
            string idAdm = "";
            SqlDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    idAdm = rdr.GetString(0);

                }
                rdr.Close();
                conn.Close();
                var id = Convert.ToInt32(idAdm);
                conn.Open();
                
                for (int i = 0; i < administrador.imagenes.Count(); i++)
                {
                    SqlCommand coms = new SqlCommand
                    {

                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "sp_fotos"

                    };
                    var uniqueFileNames = administrador.imagenes[i].FileName;
                    var upload = Path.Combine(hostingEnvironment.WebRootPath, "img");
                    var filePaths = Path.Combine(uploads, uniqueFileNames);
                    administrador.imagenes[i].CopyTo(new FileStream(filePaths, FileMode.Create));
                    coms.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    coms.Parameters.Add("@ruta", SqlDbType.VarChar).Value = uniqueFileNames;
                    coms.ExecuteNonQuery();
                }
                conn.Close();


            }

            return idAdm;
        }
        
             public JsonResult obtenerDetalles(int id)
        {
            
            List<Administrador> adm = new List<Administrador>();
            conn.Open();
            SqlCommand com = new SqlCommand
            {

                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "sp_obtenerDetalles"

            };
            com.Parameters.Add("@id", SqlDbType.Int).Value = id;

            SqlDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Administrador c = new Administrador();
                    c.descripcion = rdr.GetString(0);
                    c.ubicacion = rdr.GetString(1);
                    c.telefono = rdr.GetString(2);
                    c.correo = rdr.GetString(3);
                    c.capacidad = rdr.GetInt32(4);
                    c.porcentaje = rdr.GetInt32(5);
                    c.horaI = rdr.GetString(6);
                    c.horaC = rdr.GetString(7);
                    adm.Add(c);

                }
                rdr.Close();
                conn.Close();
            }

            return Json(new { data = adm });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
