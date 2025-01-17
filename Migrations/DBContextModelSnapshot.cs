﻿// <auto-generated />
using GestionTareas.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionTareas.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("GestionTareas.Application.Tareas", b =>
                {
                    b.Property<int>("IdTarea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DescripcionTarea")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreTarea")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdTarea");

                    b.ToTable("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
