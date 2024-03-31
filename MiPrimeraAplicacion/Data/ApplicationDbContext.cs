using MiPrimeraAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacion.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext()
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<LicenciaConducir> LicenciasConducir { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
    }
}