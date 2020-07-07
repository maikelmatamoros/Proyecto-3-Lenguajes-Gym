using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGym.Models
{
    public class tb_control
    {
        [Key]
        public int control_id { get; set; }
        public int control_centro_id { get; set; }
        public int control_capacidad { get; set; }
        public String control_hora_bloque_inicio { get; set; }
        public String control_hora_bloque_final { get; set; }

        public String control_hora_dia { get; set; }

	}
}
