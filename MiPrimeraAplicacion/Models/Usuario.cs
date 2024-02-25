using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MiPrimeraAplicacion.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        // Usuario Longitud de minimo de 3 y maximo de 50
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DisplayName("Nombre de Usuario")]
        public string UserName { get; set; }
        // Contraseña Longitud de minimo de 3 y maximo de 50
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DisplayName("Contraseña")]
        public string Password { get; set; }
    }
}