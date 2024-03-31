using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacion.Models
{
    [Table("Alumnos", Schema = "dbo")]
    public class Alumno
    {
        [Key]
        public int AlumnoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Column("Apellido")]
        public string Apellidos { get; set; }
        public DateTime FechaMatricula { get; set; }
        [NotMapped]
        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + Apellidos;
            }
        }
        public virtual ICollection<Matricula> Matriculas { get; set; }        
    }
}