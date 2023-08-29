using AppTccBackend.Enum;
using AppTccBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace AppTccBackend.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Usuarios");



          

            // Configurações específicas de propriedades comuns aqui

            // Configurações específicas de propriedades de Usuario aqui
        }
    }



}
/* public void Configure(EntityTypeBuilder<Usuario> builder)
 {
     builder.HasKey(e => e.Id);
     builder.Property(e => e.Nome).IsRequired().HasMaxLength(255);
     builder.Property(e => e.DataNascimento).IsRequired();
     builder.Property(e => e.Sexo).IsRequired();
     builder.Property(e => e.Telefone).IsRequired();
     builder.Property(e => e.Email).IsRequired();
     builder.Property(e => e.Senha).IsRequired();
     builder.HasDiscriminator<TipoUsuario>("Tipo")
            .HasValue<Paciente>(TipoUsuario.Paciente)
            .HasValue<Medico>(TipoUsuario.Medico);

// Configuração do discriminator
     builder.HasDiscriminator<TipoUsuario>("Tipo")
            .HasValue<Medico>(TipoUsuario.Medico)
            .HasValue<Paciente>(TipoUsuario.Paciente);
 }
*/

