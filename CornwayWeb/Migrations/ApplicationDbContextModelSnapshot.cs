﻿// <auto-generated />
using System;
using CornwayWeb.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CornwayWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CornwayWeb.Model.Cosecha", b =>
                {
                    b.Property<int>("IdCosecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCosecha"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Fecha")
                        .HasMaxLength(10)
                        .HasColumnType("date");

                    b.Property<int>("IdCultivo")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("IdCosecha");

                    b.HasIndex("IdCultivo");

                    b.ToTable("Cosechas");
                });

            modelBuilder.Entity("CornwayWeb.Model.Cultivos", b =>
                {
                    b.Property<int>("IdCultivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCultivo"));

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoCultivo")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCultivo");

                    b.HasIndex("IdTipoCultivo");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Cultivos");
                });

            modelBuilder.Entity("CornwayWeb.Model.GestionesCultivo", b =>
                {
                    b.Property<int>("IdGestionCultivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGestionCultivo"));

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly>("FechaGestion")
                        .HasColumnType("date");

                    b.Property<int>("IdCultivo")
                        .HasColumnType("int");

                    b.Property<int>("IdInsumoGestionCultivo")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoGestionCultivo")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("IdGestionCultivo");

                    b.HasIndex("IdCultivo");

                    b.HasIndex("IdInsumoGestionCultivo");

                    b.HasIndex("IdTipoGestionCultivo");

                    b.ToTable("GestionesCultivos");
                });

            modelBuilder.Entity("CornwayWeb.Model.InsumosGestionCultivo", b =>
                {
                    b.Property<int>("IdInsumoGestionCultivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInsumoGestionCultivo"));

                    b.Property<double>("Dosis")
                        .HasColumnType("float");

                    b.Property<int>("IdInsumoCultivo")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Unidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdInsumoGestionCultivo");

                    b.HasIndex("IdInsumoCultivo");

                    b.ToTable("InsumosGestionCultivos");
                });

            modelBuilder.Entity("CornwayWeb.Model.Partida", b =>
                {
                    b.Property<int>("IdPartida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPartida"));

                    b.Property<int>("IdCosecha")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Monedas")
                        .HasColumnType("int");

                    b.HasKey("IdPartida");

                    b.HasIndex("IdCosecha");

                    b.ToTable("Partidas");
                });

            modelBuilder.Entity("CornwayWeb.Model.TipoUsuario", b =>
                {
                    b.Property<int>("IdTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoUsuario"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdTipoUsuario");

                    b.ToTable("TipoUsuarios");
                });

            modelBuilder.Entity("CornwayWeb.Model.TiposCultivo", b =>
                {
                    b.Property<int>("IdTipoCultivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoCultivo"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdTipoCultivo");

                    b.ToTable("TiposCultivo");
                });

            modelBuilder.Entity("CornwayWeb.Model.TiposGestionCultivo", b =>
                {
                    b.Property<int>("IdTipoGestionCultivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoGestionCultivo"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdTipoGestionCultivo");

                    b.ToTable("TiposGestionCultivos");
                });

            modelBuilder.Entity("CornwayWeb.Model.TiposInsumoGestionCultivo", b =>
                {
                    b.Property<int>("IdTipoInsumoGestionCultivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoInsumoGestionCultivo"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdTipoInsumoGestionCultivo");

                    b.ToTable("TiposInsumoGestionCultivos");
                });

            modelBuilder.Entity("CornwayWeb.Model.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdTipoUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdTipoUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CornwayWeb.Models.InsumoCultivo", b =>
                {
                    b.Property<int>("IdInsumoCultivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInsumoCultivo"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoInsumoGestionCultivo")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("IdInsumoCultivo");

                    b.HasIndex("IdTipoInsumoGestionCultivo");

                    b.ToTable("InsumoCultivos");
                });

            modelBuilder.Entity("CornwayWeb.Model.Cosecha", b =>
                {
                    b.HasOne("CornwayWeb.Model.Cultivos", "Cultivo")
                        .WithMany()
                        .HasForeignKey("IdCultivo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cultivo");
                });

            modelBuilder.Entity("CornwayWeb.Model.Cultivos", b =>
                {
                    b.HasOne("CornwayWeb.Model.TiposCultivo", "TiposCultivo")
                        .WithMany()
                        .HasForeignKey("IdTipoCultivo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CornwayWeb.Model.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TiposCultivo");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("CornwayWeb.Model.GestionesCultivo", b =>
                {
                    b.HasOne("CornwayWeb.Model.Cultivos", "Cultivos")
                        .WithMany()
                        .HasForeignKey("IdCultivo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CornwayWeb.Model.InsumosGestionCultivo", "InsumosGestionCultivo")
                        .WithMany()
                        .HasForeignKey("IdInsumoGestionCultivo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CornwayWeb.Model.TiposGestionCultivo", "TiposGestionCultivo")
                        .WithMany()
                        .HasForeignKey("IdTipoGestionCultivo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cultivos");

                    b.Navigation("InsumosGestionCultivo");

                    b.Navigation("TiposGestionCultivo");
                });

            modelBuilder.Entity("CornwayWeb.Model.InsumosGestionCultivo", b =>
                {
                    b.HasOne("CornwayWeb.Models.InsumoCultivo", "InsumoCultivo")
                        .WithMany()
                        .HasForeignKey("IdInsumoCultivo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InsumoCultivo");
                });

            modelBuilder.Entity("CornwayWeb.Model.Partida", b =>
                {
                    b.HasOne("CornwayWeb.Model.Cosecha", "Cosecha")
                        .WithMany()
                        .HasForeignKey("IdCosecha")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cosecha");
                });

            modelBuilder.Entity("CornwayWeb.Model.Usuarios", b =>
                {
                    b.HasOne("CornwayWeb.Model.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("CornwayWeb.Models.InsumoCultivo", b =>
                {
                    b.HasOne("CornwayWeb.Model.TiposInsumoGestionCultivo", "TiposInsumoGestionCultivo")
                        .WithMany()
                        .HasForeignKey("IdTipoInsumoGestionCultivo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TiposInsumoGestionCultivo");
                });
#pragma warning restore 612, 618
        }
    }
}
