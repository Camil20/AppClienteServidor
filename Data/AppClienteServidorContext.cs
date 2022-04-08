using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ServerApp.Models;

#nullable disable

namespace ServerApp.Data
{
    public partial class AppClienteServidorContext : DbContext
    {
        public AppClienteServidorContext()
        {
        }

        public AppClienteServidorContext(DbContextOptions<AppClienteServidorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<FacturaDetalle> FacturaDetalles { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-13989EO;Initial Catalog=AppClienteServidor; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.ClienteId).ValueGeneratedNever();

                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Cedula).IsUnicode(false);

                entity.Property(e => e.Ciudad).IsUnicode(false);

                entity.Property(e => e.CorreoElectronico).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Provincia).IsUnicode(false);

                entity.Property(e => e.Sector).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.Property(e => e.FacturaId).ValueGeneratedNever();

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idCienteF");
            });

            modelBuilder.Entity<FacturaDetalle>(entity =>
            {
                entity.HasKey(e => e.DetalleId)
                    .HasName("pk_iddetalle");

                entity.Property(e => e.DetalleId).ValueGeneratedNever();

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.FacturaDetalles)
                    .HasForeignKey(d => d.FacturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idfacturaF");

                entity.HasOne(d => d.Servicio)
                    .WithMany(p => p.FacturaDetalles)
                    .HasForeignKey(d => d.ServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idServicioF");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.Property(e => e.ServicioId).ValueGeneratedNever();

                entity.Property(e => e.Categoria).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
