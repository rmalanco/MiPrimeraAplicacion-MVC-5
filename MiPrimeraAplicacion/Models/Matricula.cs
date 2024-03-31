using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacion.Models
{
    public class Matricula
    {
        public int MatriculaId { get; set; }
        public int CursoId { get; set; }
        public int AlumnoId { get; set; }
        public double Precio { get; set; }
        public virtual Curso SiguienteCurso { get; set; }
        public virtual Curso AnteriorCurso { get; set; }
        [ForeignKey("CursoId")]
        public virtual Curso Curso { get; set; }
        [ForeignKey("AlumnoId")]
        public virtual Alumno Alumno { get; set; }        
    }
}