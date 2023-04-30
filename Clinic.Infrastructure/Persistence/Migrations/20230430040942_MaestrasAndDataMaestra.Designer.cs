﻿// <auto-generated />
using System;
using Clinic.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clinic.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ClinicDbContext))]
    [Migration("20230430040942_MaestrasAndDataMaestra")]
    partial class MaestrasAndDataMaestra
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clinic.Domain.Entities.DataMaestra", b =>
                {
                    b.Property<string>("nmdato")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cddato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cddato1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cddato2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cddato3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dsdato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("febaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("feregistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("nmmaestro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("nmdato");

                    b.ToTable("MasterData");
                });

            modelBuilder.Entity("Clinic.Domain.Entities.Maestras", b =>
                {
                    b.Property<string>("nmmaestro")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cdmaestro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dsmaestro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("febaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("feregistro")
                        .HasColumnType("datetime2");

                    b.HasKey("nmmaestro");

                    b.ToTable("Masters");
                });

            modelBuilder.Entity("Clinic.Domain.Entities.Pacientes", b =>
                {
                    b.Property<int>("nmid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("nmid"));

                    b.Property<string>("cdusuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dsarl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dscondicion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dseps")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("febaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("feregistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("nmid_medicotra")
                        .HasColumnType("int");

                    b.Property<int>("nmid_persona")
                        .HasColumnType("int");

                    b.HasKey("nmid");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Clinic.Domain.Entities.Personas", b =>
                {
                    b.Property<int>("nmid")
                        .HasColumnType("int");

                    b.Property<string>("cddocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cdgenero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cdtelefono_fijo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cdtelefono_movil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cdtipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cdusuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dsapellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dsdireccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dsemail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dsnombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dsphoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("febaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fenacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("feregistro")
                        .HasColumnType("datetime2");

                    b.HasKey("nmid");

                    b.ToTable("Peoples");
                });
#pragma warning restore 612, 618
        }
    }
}