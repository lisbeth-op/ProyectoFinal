﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PFinal.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20230409080654_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("DetalleOrdenDeProduccion", b =>
                {
                    b.Property<int>("DetelleOrdenDeProduccionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrdenDeProduccionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrdenProduccionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetelleOrdenDeProduccionID");

                    b.HasIndex("OrdenDeProduccionId");

                    b.ToTable("DetalleOrdenDeProduccion");
                });

            modelBuilder.Entity("DetalleRecetas", b =>
                {
                    b.Property<int>("DetalleRecetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MateriaPrimaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecetaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetalleRecetaId");

                    b.HasIndex("RecetaId");

                    b.ToTable("DetalleRecetas");
                });

            modelBuilder.Entity("MateriasPrimas", b =>
                {
                    b.Property<int>("MateriaPrimaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("MateriaPrimaId");

                    b.ToTable("MateriasPrimas");
                });

            modelBuilder.Entity("OrdenDeProducciones", b =>
                {
                    b.Property<int>("OrdenDeProduccionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CostoTotal")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("OrdenDeProduccionId");

                    b.ToTable("OrdenDeProducciones");
                });

            modelBuilder.Entity("Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int>("RecetaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Descripcion = "Dulce de leche",
                            Existencia = 100,
                            Nombre = "Bizcocho",
                            Precio = 500.0,
                            RecetaId = 0
                        },
                        new
                        {
                            ProductoId = 2,
                            Descripcion = "De agua",
                            Existencia = 100,
                            Nombre = "Pan",
                            Precio = 50.0,
                            RecetaId = 0
                        },
                        new
                        {
                            ProductoId = 3,
                            Descripcion = "De coco",
                            Existencia = 100,
                            Nombre = "Galletas",
                            Precio = 50.0,
                            RecetaId = 0
                        });
                });

            modelBuilder.Entity("Recetas", b =>
                {
                    b.Property<int>("RecetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RecetaId");

                    b.ToTable("Recetas");
                });

            modelBuilder.Entity("DetalleOrdenDeProduccion", b =>
                {
                    b.HasOne("OrdenDeProducciones", null)
                        .WithMany("DetalleOrdenDeProduccions")
                        .HasForeignKey("OrdenDeProduccionId");
                });

            modelBuilder.Entity("DetalleRecetas", b =>
                {
                    b.HasOne("Recetas", null)
                        .WithMany("detalleRecetas")
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrdenDeProducciones", b =>
                {
                    b.Navigation("DetalleOrdenDeProduccions");
                });

            modelBuilder.Entity("Recetas", b =>
                {
                    b.Navigation("detalleRecetas");
                });
#pragma warning restore 612, 618
        }
    }
}
