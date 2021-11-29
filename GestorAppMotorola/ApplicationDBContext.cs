using API_Gestion_Instalacion_APP.Modelos;
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

        public DbSet<Operarios> Operarios { get; set; }
        public DbSet<Apps> Apps { get; set; }
        public DbSet<Instalaciones> Instalaciones { get; set; }


    }
}