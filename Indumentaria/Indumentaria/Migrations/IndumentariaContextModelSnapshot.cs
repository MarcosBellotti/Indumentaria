﻿// <auto-generated />
using Indumentaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Indumentaria.Migrations
{
    [DbContext(typeof(IndumentariaContext))]
    partial class IndumentariaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Indumentaria.Models.Marca", b =>
                {
                    b.Property<int>("MarcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarcaId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarcaId");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("Indumentaria.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDeProductoId")
                        .HasColumnType("int");

                    b.HasKey("ProductoId");

                    b.HasIndex("MarcaId");

                    b.HasIndex("TipoDeProductoId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Indumentaria.Models.ProductoPorTalle", b =>
                {
                    b.Property<int>("ProductoPorTalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoPorTalleId"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("Talle")
                        .HasColumnType("int");

                    b.HasKey("ProductoPorTalleId");

                    b.HasIndex("ProductoId");

                    b.ToTable("ProductosPorTalle");
                });

            modelBuilder.Entity("Indumentaria.Models.Proveedor", b =>
                {
                    b.Property<int>("ProveedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProveedorId"));

                    b.Property<int>("Cuit")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroDeCelular")
                        .HasColumnType("int");

                    b.HasKey("ProveedorId");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Indumentaria.Models.ProveedorMarca", b =>
                {
                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.HasKey("ProveedorId", "MarcaId");

                    b.HasIndex("MarcaId");

                    b.ToTable("ProveedoresMarcas");
                });

            modelBuilder.Entity("Indumentaria.Models.TipoDeProducto", b =>
                {
                    b.Property<int>("TipoDeProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoDeProductoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoDeProductoId");

                    b.ToTable("TiposDeProducto");
                });

            modelBuilder.Entity("Indumentaria.Models.Producto", b =>
                {
                    b.HasOne("Indumentaria.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Indumentaria.Models.TipoDeProducto", "TipoDeProducto")
                        .WithMany()
                        .HasForeignKey("TipoDeProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");

                    b.Navigation("TipoDeProducto");
                });

            modelBuilder.Entity("Indumentaria.Models.ProductoPorTalle", b =>
                {
                    b.HasOne("Indumentaria.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Indumentaria.Models.ProveedorMarca", b =>
                {
                    b.HasOne("Indumentaria.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Indumentaria.Models.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");

                    b.Navigation("Proveedor");
                });
#pragma warning restore 612, 618
        }
    }
}
