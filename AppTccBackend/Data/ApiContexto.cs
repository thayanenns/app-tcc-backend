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

            // Suas outras configurações

            base.OnModelCreating(modelBuilder);
        }

    }
}

/*
protected override void OnModelCreating(ModelBuilder modelBuilder)
{

 modelBuilder.Entity<Usuario>()
                .HasDiscriminator(u => u.Tipo)
                .HasValue<Medico>(TipoUsuario.Medico)
                .HasValue<Paciente>(TipoUsuario.Paciente);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

    modelBuilder.Entity<Medico>();
    modelBuilder.Entity<Paciente>();
    modelBuilder.Entity<Medicao>();

    modelBuilder.Entity<Medico>()
           .HasMany(c => c.Pacientes)
           .WithOne(e => e.Medico).IsRequired().OnDelete(DeleteBehavior.Cascade);


    modelBuilder.ApplyConfiguration(new UsuarioMap());
    base.OnModelCreating(modelBuilder);






modelBuilder.Entity<Usuario>()
    .HasDiscriminator<TipoUsuario>("Tipo")
    .HasValue<Paciente>(TipoUsuario.Paciente)
    .HasValue<Medico>(TipoUsuario.Medico);

    modelBuilder.Entity<Medicao>().HasOne(m => m.Paciente).WithMany(p => p.Medicoes);

    modelBuilder.ApplyConfiguration(new UsuarioMap());
    modelBuilder.ApplyConfiguration(new MedicaoMap());
    modelBuilder.ApplyConfiguration(new MedicoMap());

    modelBuilder.ApplyConfiguration(new PacienteMap());

*/
