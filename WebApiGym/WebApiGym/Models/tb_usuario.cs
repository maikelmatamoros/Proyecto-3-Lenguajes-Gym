using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGym.Models
{
    public class tb_usuario
    {
        [Key]
        public String usuario_userName { get; set; }
        [Required]
        public String usuario_password { get; set; }
        [Required]
        public String usuario_nombre { get; set; }
        [Required]
        public String usuario_apellidos { get; set; }
        [Required]
        public String usuario_cedula { get; set; }

    }
}
