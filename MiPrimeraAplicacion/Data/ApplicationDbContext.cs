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
    }
}