using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoWeb.Models;

public partial class TiendaContext : DbContext
{
    public TiendaContext()
    {
    }

    public TiendaContext(DbContextOptions<TiendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aviso> Avisos { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;port=3307;user=root;password=root;database=tienda");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aviso>(entity =>
        {
            entity.HasKey(e => e.IdAviso).HasName("PRIMARY");

            entity.ToTable("aviso");

            entity.HasIndex(e => e.IdUsuario, "fk_aviso_usuario1_idx");

            entity.Property(e => e.IdAviso).HasColumnName("id_aviso");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(20)
                .HasColumnName("id_usuario");
            entity.Property(e => e.Titulo)
                .HasMaxLength(64)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Avisos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_aviso_usuario1");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.ToTable("categoria");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(64)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(64)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => new { e.IdDetallePedido, e.IdProducto, e.IdPedido }).HasName("PRIMARY");

            entity.ToTable("detalle_pedido");

            entity.HasIndex(e => e.IdPedido, "fk_detalle_pedido_pedido1_idx");

            entity.HasIndex(e => e.IdProducto, "fk_detalle_pedido_producto1_idx");

            entity.Property(e => e.IdDetallePedido)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_detalle_pedido");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Precio)
                .HasPrecision(10)
                .HasColumnName("precio");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_pedido_pedido1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_pedido_producto1");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PRIMARY");

            entity.ToTable("pedido");

            entity.HasIndex(e => e.IdUsuario, "fk_pedido_usuario1_idx");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(20)
                .HasColumnName("id_usuario");
            entity.Property(e => e.Total)
                .HasPrecision(10)
                .HasColumnName("total");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pedido_usuario1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.HasIndex(e => e.IdCategoria, "fk_producto_categoria1_idx");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(256)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Imagen)
                .HasMaxLength(20)
                .HasColumnName("imagen");
            entity.Property(e => e.Importancia).HasColumnName("importancia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10)
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto_categoria1");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolNombre).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.Property(e => e.RolNombre).HasColumnName("rol_nombre");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario)
                .HasMaxLength(20)
                .HasColumnName("id_usuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(20)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(64)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(128)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.Materno)
                .HasMaxLength(64)
                .HasColumnName("materno");
            entity.Property(e => e.Nombres)
                .HasMaxLength(64)
                .HasColumnName("nombres");
            entity.Property(e => e.Paterno)
                .HasMaxLength(64)
                .HasColumnName("paterno");
            entity.Property(e => e.Telefono)
                .HasMaxLength(32)
                .HasColumnName("telefono");

            entity.HasMany(d => d.RolNombres).WithMany(p => p.IdUsuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioRol",
                    r => r.HasOne<Rol>().WithMany()
                        .HasForeignKey("RolNombre")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_usuario_rol_rol1"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_usuario_rol_usuario"),
                    j =>
                    {
                        j.HasKey("IdUsuario", "RolNombre").HasName("PRIMARY");
                        j.ToTable("usuario_rol");
                        j.HasIndex(new[] { "RolNombre" }, "fk_usuario_rol_rol1_idx");
                        j.IndexerProperty<string>("IdUsuario")
                            .HasMaxLength(20)
                            .HasColumnName("id_usuario");
                        j.IndexerProperty<int>("RolNombre").HasColumnName("rol_nombre");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
