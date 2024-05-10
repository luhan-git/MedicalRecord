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

    public virtual DbSet<Campovisual> Campovisuals { get; set; }

    public virtual DbSet<Ciaseguro> Ciaseguros { get; set; }

    public virtual DbSet<Cie> Cies { get; set; }

    public virtual DbSet<Directorio> Directorios { get; set; }

    public virtual DbSet<Exameneslaboratorio> Exameneslaboratorios { get; set; }

    public virtual DbSet<Linea> Lineas { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Presentacione> Presentaciones { get; set; }

    public virtual DbSet<Procedimiento> Procedimientos { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Campovisual>(entity =>
        {
            entity.HasKey(e => e.Idpac).HasName("PRIMARY");

            entity.ToTable("campovisual");

            entity.Property(e => e.Idpac).HasColumnName("IDPAC");
            entity.Property(e => e.CampoVis)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("CAMPO_VIS");
        });

        modelBuilder.Entity<Ciaseguro>(entity =>
        {
            entity.HasKey(e => e.IdCia).HasName("PRIMARY");

            entity.ToTable("ciaseguros");

            entity.Property(e => e.IdCia).HasColumnName("id_cia");
            entity.Property(e => e.NemoCia)
                .HasMaxLength(20)
                .HasColumnName("nemo_cia");
            entity.Property(e => e.NombreCia)
                .HasMaxLength(50)
                .HasColumnName("nombre_cia");
        });

        modelBuilder.Entity<Cie>(entity =>
        {
            entity.HasKey(e => e.IdCie).HasName("PRIMARY");

            entity.ToTable("cie");

            entity.Property(e => e.IdCie).HasColumnName("id_cie");
            entity.Property(e => e.Codcie)
                .HasMaxLength(5)
                .HasColumnName("codcie");
            entity.Property(e => e.Enfermedad)
                .HasMaxLength(120)
                .HasColumnName("enfermedad");
        });

        modelBuilder.Entity<Directorio>(entity =>
        {
            entity.HasKey(e => e.IdDirectorio).HasName("PRIMARY");

            entity.ToTable("directorio");

            entity.Property(e => e.IdDirectorio).HasColumnName("id_directorio");
            entity.Property(e => e.Celular)
                .HasMaxLength(40)
                .HasColumnName("celular");
            entity.Property(e => e.Direccion)
                .HasMaxLength(180)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .HasColumnName("estado");
            entity.Property(e => e.Fono)
                .HasMaxLength(40)
                .HasColumnName("fono");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .HasColumnName("nombre");
            entity.Property(e => e.Repre)
                .HasMaxLength(80)
                .HasColumnName("repre");
        });

        modelBuilder.Entity<Exameneslaboratorio>(entity =>
        {
            entity.HasKey(e => e.IdExam).HasName("PRIMARY");

            entity.ToTable("exameneslaboratorio");

            entity.Property(e => e.IdExam).HasColumnName("id_exam");
            entity.Property(e => e.NemoExam)
                .HasMaxLength(20)
                .HasColumnName("nemo_exam");
            entity.Property(e => e.NombreExam)
                .HasMaxLength(50)
                .HasColumnName("nombre_exam");
        });

        modelBuilder.Entity<Linea>(entity =>
        {
            entity.HasKey(e => e.IdLinea).HasName("PRIMARY");

            entity.ToTable("lineas");

            entity.Property(e => e.IdLinea).HasColumnName("id_linea");
            entity.Property(e => e.NemoLinea)
                .HasMaxLength(4)
                .HasColumnName("nemo_linea");
            entity.Property(e => e.NombreLinea)
                .HasMaxLength(40)
                .HasColumnName("nombre_linea");
        });

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

        modelBuilder.Entity<Presentacione>(entity =>
        {
            entity.HasKey(e => e.IdPresenta).HasName("PRIMARY");

            entity.ToTable("presentaciones");

            entity.Property(e => e.IdPresenta).HasColumnName("id_presenta");
            entity.Property(e => e.NemoPrese)
                .HasMaxLength(4)
                .HasColumnName("nemo_prese");
            entity.Property(e => e.NombrePrese)
                .HasMaxLength(30)
                .HasColumnName("nombre_prese");
        });

        modelBuilder.Entity<Procedimiento>(entity =>
        {
            entity.HasKey(e => e.IdProce).HasName("PRIMARY");

            entity.ToTable("procedimientos");

            entity.Property(e => e.IdProce).HasColumnName("id_proce");
            entity.Property(e => e.NemoProce)
                .HasMaxLength(20)
                .HasColumnName("nemo_proce");
            entity.Property(e => e.NombreProce)
                .HasMaxLength(50)
                .HasColumnName("nombre_proce");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.IdUbica).HasName("PRIMARY");

            entity.ToTable("ubicacion");

            entity.Property(e => e.IdUbica).HasColumnName("id_ubica");
            entity.Property(e => e.TabCodreg)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("tab_codreg");
            entity.Property(e => e.TabCodrela)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("tab_codrela");
            entity.Property(e => e.TabNombre)
                .HasMaxLength(30)
                .HasColumnName("tab_nombre");
            entity.Property(e => e.TabTipreg).HasColumnName("tab_tipreg");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
