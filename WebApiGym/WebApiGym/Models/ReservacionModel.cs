using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGym.Models
{
    public class ReservacionModel
    {
        public string centro_nombre { get; set; }
        public string control_hora_bloque { get; set; }

        public string control_hora_dia { get; set; }
    }
}
