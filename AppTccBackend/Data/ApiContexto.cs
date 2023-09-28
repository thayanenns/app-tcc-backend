using AppTccBackend.Data.Map;
using AppTccBackend.Enum;
using AppTccBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AppTccBackend.Data
{
    public class ApiContexto : DbContext
    {
        public ApiContexto(DbContextOptions<ApiContexto> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medicao> Medicoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
            .HasDiscriminator<int>("TipoUsuario")
            .HasValue<Medico>(0)
            .HasValue<Paciente>(1);


            base.OnModelCreating(modelBuilder);
        }

    }
}

