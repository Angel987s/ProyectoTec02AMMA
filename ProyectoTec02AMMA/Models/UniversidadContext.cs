using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoTec02AMMA.Models;

public partial class UniversidadContext : DbContext
{
    public UniversidadContext()
    {
    }

    public UniversidadContext(DbContextOptions<UniversidadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=COMPU\\SQLEXPRESS;Initial Catalog=Universidad;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.CarreraId).HasName("PK__Carreras__3E43B181F5DC1444");

            entity.Property(e => e.CarreraId).HasColumnName("CarreraID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.ProfesorId).HasName("PK__Profesor__4DF3F0285830C0FF");

            entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.CarreraId).HasColumnName("CarreraID");
            entity.Property(e => e.Foto).HasColumnType("image");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Carrera).WithMany(p => p.Profesores)
                .HasForeignKey(d => d.CarreraId)
                .HasConstraintName("FK__Profesore__Carre__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
