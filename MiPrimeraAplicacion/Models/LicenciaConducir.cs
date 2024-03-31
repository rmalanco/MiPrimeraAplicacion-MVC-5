using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacion.Models
{
    public class LicenciaConducir
    {
        [Key,Column(Order = 1)]
        public int NumeroLicencia { get; set; }
        [Key, Column(Order = 2)]
        public string Pais { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime FechaCaducidad { get; set; }
    }
}