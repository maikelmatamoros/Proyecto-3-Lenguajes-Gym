using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteWebGym.Models
{
    public class CentroInfoGeneral
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string Logo { get; set; }
        public List<string> Imagenes { get; set; }
    }
}
