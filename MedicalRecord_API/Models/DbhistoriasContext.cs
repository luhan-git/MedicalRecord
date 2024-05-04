using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MedicalRecord_API.Models;

public partial class DbhistoriasContext : DbContext
{
    public DbhistoriasContext()
    {
    }

    public DbhistoriasContext(DbContextOptions<DbhistoriasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Medico> Medicos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PRIMARY");

            entity.ToTable("medicos");

            entity.Property(e => e.IdMedico).HasColumnName("id_medico");
            entity.Property(e => e.EspeMed)
                .HasMaxLength(30)
                .HasColumnName("espe_med");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasColumnName("estado");
            entity.Property(e => e.NombreMed)
                .HasMaxLength(50)
                .HasColumnName("nombre_med");
            entity.Property(e => e.NroCmed)
                .HasMaxLength(6)
                .HasColumnName("nro_cmed");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
