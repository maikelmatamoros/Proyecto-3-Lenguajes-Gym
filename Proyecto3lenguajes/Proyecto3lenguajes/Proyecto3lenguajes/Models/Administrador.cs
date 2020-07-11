using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto3lenguajes.Models
{
    public class Administrador
    {
        public int id_administrador { get; set; }
        public string nombre_negocio { get; set; }
        public string descripcion { get; set; }
        public string ubicacion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public int capacidad { get; set; }
        public int porcentaje { get; set; }
        public string horaI { get; set; }
        public string horaC { get; set; }
        public IFormFile logo { set; get; }
        public string rutaLogo { set; get; }
        public List<IFormFile> imagenes { set; get; }
        public string rutaImagenes { set; get; }
        public string pass { set; get; }
    }
}
