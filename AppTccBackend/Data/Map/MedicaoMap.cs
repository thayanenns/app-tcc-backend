using AppTccBackend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppTccBackend.Data.Map
{
    public class MedicaoMap : IEntityTypeConfiguration<Medicao>
    {
        public void Configure(EntityTypeBuilder<Medicao> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.DataMedicao).IsRequired();
            builder.Property(e => e.Batimentos).IsRequired();
            builder.Property(e => e.Glicemia).IsRequired();
            builder.Property(e => e.PressaoSistolica).IsRequired();
            builder.Property(e => e.PressaoDiastolica).IsRequired();
            builder.Property(e => e.EmJejum).IsRequired();
            builder.Property(e => e.Peso).IsRequired();
            builder.Property(e => e.Altura).IsRequired();
            builder.HasOne(e => e.Paciente)
                   .WithMany(p => p.Medicoes)
                   .HasForeignKey(e => e.PacienteId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
