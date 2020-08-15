using CapaModelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpleadoVehiculos>().HasKey(x => new {x.EmpleadoVehiculosID });
        }

        
        public DbSet<AutomovilM> automiviles { get; set; }
        public DbSet<EmpleadoM> empleado { get; set; }
        public DbSet<ClienteM> clientes { get; set; }
        public DbSet<EmpleadoVehiculos> empleadosVehiculos { get; set; }
        public DbSet<Entrega> entregas { get; set; }


    }
}
