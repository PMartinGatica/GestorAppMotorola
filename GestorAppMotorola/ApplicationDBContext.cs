using GestorAppMotorola.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Gestion_Instalacion_APP
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Operario> Operario { get; set; }
        public DbSet<App> App { get; set; }
        public DbSet<Instalacion> Instalacion { get; set; }


    }
}