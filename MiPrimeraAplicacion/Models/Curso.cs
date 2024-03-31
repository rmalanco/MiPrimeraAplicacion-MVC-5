using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacion.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        [ConcurrencyCheck]
        //[MaxLength(50), MinLength(3)]
        [StringLength(50, MinimumLength = 3)]
        public string Titulo { get; set; }
        [Index]
        public int Creditos { get; set; }
        public int NumeroClases { get; set; }
        [Timestamp]
        public byte[] TStamp { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
        [InverseProperty("SiguienteCurso")]
        public virtual ICollection<Matricula> SiguienteCurso { get; set; }
        [InverseProperty("AnteriorCurso")]
        public virtual ICollection<Matricula> AnteriorCurso { get; set; }
    }
}