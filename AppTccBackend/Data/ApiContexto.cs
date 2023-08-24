using AppTccBackend.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AppTccBackend.Data
{
    public class ApiContexto : DbContext
    {
        public ApiContexto(DbContextOptions<ApiContexto> options) : base(options) { }

        public DbSet<UsuarioModel> Usuario{ get; set; }
        public DbSet<PacienteModel> Paciente { get; set; }
        public DbSet<MedicoModel> Medico { get; set; }
        public DbSet<MedicaoModel> Medicao{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<UsuarioModel>();
            modelBuilder.Entity<MedicoModel>();
            modelBuilder.Entity<PacienteModel>();
            modelBuilder.Entity<MedicaoModel>();*/

            modelBuilder.Entity<MedicoModel>()
                   .HasMany(c => c.Pacientes)
                   .WithOne(e => e.Medico).IsRequired().OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);


        }
    }
}
