using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGym.Models
{
    public class ControlHorarios
    {
        [Key]
        public int control_id { get; set; }
        public int control_capacidad { get; set; }

        public string control_hora_bloque { get; set; }
 

        
    }
}
