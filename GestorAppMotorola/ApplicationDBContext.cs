using GestorAppMotorola.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SensorTelefono>()
                .HasKey(x => new { x.SensorId, x.TelefonoId });
        }

        public DbSet<Operario> Operario { get; set; }
        public DbSet<App> App { get; set; }
        public DbSet<Instalacion> Instalacion { get; set; }
        public DbSet<Sensor> Sensor { get; set; }
        public DbSet<Telefono> Telefono { get; set; }
        public DbSet<SensorTelefono> SensorTelefono { get; set; }

        internal Task SaveChangesasync()
        {
            throw new NotImplementedException();
        }
    }
}