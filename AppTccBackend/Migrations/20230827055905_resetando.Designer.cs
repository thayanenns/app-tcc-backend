﻿// <auto-generated />
using System;
using AppTccBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppTccBackend.Migrations
{
    [DbContext(typeof(ApiContexto))]
    [Migration("20230827055905_resetando")]
    partial class resetando
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AppTccBackend.Models.Medicao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataMedicao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("EmJejum")
                        .HasColumnType("boolean");

                    b.Property<int>("Glicemia")
                        .HasColumnType("integer");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("uuid");

                    b.Property<int>("PressaoDiastolica")
                        .HasColumnType("integer");

                    b.Property<int>("PressaoSistolica")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Medicoes");
                });

            modelBuilder.Entity("AppTccBackend.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<int>("TipoUsuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AppTccBackend.Models.Medico", b =>
                {
                    b.HasBaseType("AppTccBackend.Models.Usuario");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("AppTccBackend.Models.Paciente", b =>
                {
                    b.HasBaseType("AppTccBackend.Models.Usuario");

                    b.Property<Guid?>("MedicoId")
                        .HasColumnType("uuid");

                    b.HasIndex("MedicoId");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("AppTccBackend.Models.Medicao", b =>
                {
                    b.HasOne("AppTccBackend.Models.Paciente", "Paciente")
                        .WithMany("Medicoes")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("AppTccBackend.Models.Paciente", b =>
                {
                    b.HasOne("AppTccBackend.Models.Medico", "Medico")
                        .WithMany("Pacientes")
                        .HasForeignKey("MedicoId");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("AppTccBackend.Models.Medico", b =>
                {
                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("AppTccBackend.Models.Paciente", b =>
                {
                    b.Navigation("Medicoes");
                });
#pragma warning restore 612, 618
        }
    }
}
