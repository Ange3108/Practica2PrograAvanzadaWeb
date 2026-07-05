using Microsoft.EntityFrameworkCore;
using Practica2.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica2.DAL.Data
{
    public partial class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }

        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // La cadena de conexión se configurará mediante DI.
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categorias");

                entity.HasKey(e => e.IdCategoria);

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("productos");

                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100);

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria");

                entity.HasOne(d => d.Categoria)
                      .WithMany()
                      .HasForeignKey(d => d.IdCategoria);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

