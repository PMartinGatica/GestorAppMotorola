﻿// <auto-generated />
using System;
using GestorAppMotorola;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestorAppMotorola.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20211207123145_Segundo")]
    partial class Segundo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("GestorAppMotorola.Modelos.App", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("App");
                });

            modelBuilder.Entity("GestorAppMotorola.Modelos.Instalacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppId")
                        .HasColumnType("int");

                    b.Property<bool>("Exitosa")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int>("OperarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppId");

                    b.HasIndex("OperarioId");

                    b.ToTable("Instalacion");
                });

            modelBuilder.Entity("GestorAppMotorola.Modelos.Operario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Operario");
                });

            modelBuilder.Entity("GestorAppMotorola.Modelos.Instalacion", b =>
                {
                    b.HasOne("GestorAppMotorola.Modelos.App", "App")
                        .WithMany("Instalacion")
                        .HasForeignKey("AppId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorAppMotorola.Modelos.Operario", "Operario")
                        .WithMany("Instalacion")
                        .HasForeignKey("OperarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("App");

                    b.Navigation("Operario");
                });

            modelBuilder.Entity("GestorAppMotorola.Modelos.App", b =>
                {
                    b.Navigation("Instalacion");
                });

            modelBuilder.Entity("GestorAppMotorola.Modelos.Operario", b =>
                {
                    b.Navigation("Instalacion");
                });
#pragma warning restore 612, 618
        }
    }
}