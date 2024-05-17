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

    public virtual DbSet<Alergium> Alergia { get; set; }

    public virtual DbSet<Ciaseguro> Ciaseguros { get; set; }

    public virtual DbSet<Cie> Cies { get; set; }

    public virtual DbSet<Consultum> Consulta { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Detallealergium> Detallealergia { get; set; }

    public virtual DbSet<Detalleexaman> Detalleexamen { get; set; }

    public virtual DbSet<Detalleprocedimiento> Detalleprocedimientos { get; set; }

    public virtual DbSet<Diabete> Diabetes { get; set; }

    public virtual DbSet<Directorio> Directorios { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Examenlaboratorio> Examenlaboratorios { get; set; }

    public virtual DbSet<Laboratorio> Laboratorios { get; set; }

    public virtual DbSet<Medicacion> Medicacions { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Medidalente> Medidalentes { get; set; }

    public virtual DbSet<Ocupacion> Ocupacions { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Parentesco> Parentescos { get; set; }

    public virtual DbSet<Presentacion> Presentacions { get; set; }

    public virtual DbSet<Procedimiento> Procedimientos { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Alergium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("alergia");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Ciaseguro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ciaseguro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abreviatura)
                .HasMaxLength(20)
                .HasColumnName("abreviatura");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cie");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .HasColumnName("codigo");
            entity.Property(e => e.Enfermedad)
                .HasMaxLength(120)
                .HasColumnName("enfermedad");
        });

        modelBuilder.Entity<Consultum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("consulta");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Davcc)
                .HasMaxLength(10)
                .HasColumnName("davcc");
            entity.Property(e => e.Davsc)
                .HasMaxLength(10)
                .HasColumnName("davsc");
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(200)
                .HasColumnName("diagnostico");
            entity.Property(e => e.Dpio)
                .HasMaxLength(10)
                .HasColumnName("dpio");
            entity.Property(e => e.EnfermedadActual)
                .HasMaxLength(200)
                .HasColumnName("enfermedadActual");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.FechaConsulta)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fechaConsulta");
            entity.Property(e => e.Iavcc)
                .HasMaxLength(10)
                .HasColumnName("iavcc");
            entity.Property(e => e.Iavsc)
                .HasMaxLength(10)
                .HasColumnName("iavsc");
            entity.Property(e => e.IdCie).HasColumnName("idCie");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Ipio)
                .HasMaxLength(10)
                .HasColumnName("ipio");
            entity.Property(e => e.Motivo)
                .HasMaxLength(80)
                .HasColumnName("motivo");
            entity.Property(e => e.NumeroConsulta)
                .HasMaxLength(7)
                .HasColumnName("numeroConsulta");
            entity.Property(e => e.Shimer)
                .HasMaxLength(10)
                .HasColumnName("shimer");
            entity.Property(e => e.ValorK)
                .HasMaxLength(80)
                .HasColumnName("valorK");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("departamento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Departamento1)
                .HasMaxLength(50)
                .HasColumnName("departamento");
        });

        modelBuilder.Entity<Detallealergium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detallealergia");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasMaxLength(50)
                .HasColumnName("detalle");
            entity.Property(e => e.IdAlergia).HasColumnName("idAlergia");
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Detalleexaman>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detalleexamen");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasMaxLength(255)
                .HasColumnName("detalle");
            entity.Property(e => e.FechaResultado)
                .HasColumnType("datetime")
                .HasColumnName("fechaResultado");
            entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");
            entity.Property(e => e.IdExamenLab).HasColumnName("idExamenLab");
            entity.Property(e => e.Resultado)
                .HasMaxLength(500)
                .HasColumnName("resultado");
        });

        modelBuilder.Entity<Detalleprocedimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detalleprocedimiento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasMaxLength(255)
                .HasColumnName("detalle");
            entity.Property(e => e.Directorio)
                .HasMaxLength(500)
                .HasColumnName("directorio");
            entity.Property(e => e.FechaResultado)
                .HasColumnType("datetime")
                .HasColumnName("fechaResultado");
            entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");
            entity.Property(e => e.IdProcedimiento).HasColumnName("idProcedimiento");
            entity.Property(e => e.Imagenes)
                .HasDefaultValueSql("'0'")
                .HasColumnName("imagenes");
            entity.Property(e => e.Indicacion)
                .HasMaxLength(255)
                .HasColumnName("indicacion");
            entity.Property(e => e.Resultado)
                .HasMaxLength(500)
                .HasColumnName("resultado");
        });

        modelBuilder.Entity<Diabete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("diabetes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasMaxLength(100)
                .HasColumnName("detalle");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Directorio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("directorio");

            entity.Property(e => e.Id).HasColumnName("id");
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
                .HasDefaultValueSql("'1'")
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .HasColumnName("nombre");
            entity.Property(e => e.Representante)
                .HasMaxLength(80)
                .HasColumnName("representante");
            entity.Property(e => e.Telefono)
                .HasMaxLength(40)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("distrito");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Distrito1)
                .HasMaxLength(50)
                .HasColumnName("distrito");
            entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");
        });

        modelBuilder.Entity<Examenlaboratorio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("examenlaboratorio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abreviatura)
                .HasMaxLength(20)
                .HasColumnName("abreviatura");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Laboratorio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("laboratorio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abreviatura)
                .HasMaxLength(4)
                .HasColumnName("abreviatura");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Medicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("medicacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dosis)
                .HasMaxLength(80)
                .HasColumnName("dosis");
            entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");
            entity.Property(e => e.IdMedicamento).HasColumnName("idMedicamento");
            entity.Property(e => e.Indicacion)
                .HasMaxLength(300)
                .HasColumnName("indicacion");
            entity.Property(e => e.OrdenMedica)
                .HasMaxLength(500)
                .HasColumnName("ordenMedica");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("medicamento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(7)
                .HasColumnName("codigo");
            entity.Property(e => e.Dosis)
                .HasMaxLength(80)
                .HasColumnName("dosis");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .HasColumnName("estado");
            entity.Property(e => e.IdLaboratorio).HasColumnName("idLaboratorio");
            entity.Property(e => e.IdPresentacion).HasColumnName("idPresentacion");
            entity.Property(e => e.Indicacion)
                .HasMaxLength(180)
                .HasColumnName("indicacion");
            entity.Property(e => e.NombreComercial)
                .HasMaxLength(50)
                .HasColumnName("nombreComercial");
            entity.Property(e => e.NombreGenerico)
                .HasMaxLength(50)
                .HasColumnName("nombreGenerico");
        });

        modelBuilder.Entity<Medidalente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("medidalente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");
            entity.Property(e => e.Obsc)
                .HasMaxLength(120)
                .HasColumnName("OBSC");
            entity.Property(e => e.Obsl)
                .HasMaxLength(120)
                .HasColumnName("OBSL");
            entity.Property(e => e.Odav)
                .HasMaxLength(6)
                .HasColumnName("ODAV");
            entity.Property(e => e.Odaxic)
                .HasMaxLength(6)
                .HasColumnName("ODAXIC");
            entity.Property(e => e.Odaxil)
                .HasMaxLength(6)
                .HasColumnName("ODAXIL");
            entity.Property(e => e.Odcysc)
                .HasMaxLength(6)
                .HasColumnName("ODCYSC");
            entity.Property(e => e.Odcysl)
                .HasMaxLength(6)
                .HasColumnName("ODCYSL");
            entity.Property(e => e.Odsphc)
                .HasMaxLength(6)
                .HasColumnName("ODSPHC");
            entity.Property(e => e.Odsphl)
                .HasMaxLength(6)
                .HasColumnName("ODSPHL");
            entity.Property(e => e.Oiav)
                .HasMaxLength(6)
                .HasColumnName("OIAV");
            entity.Property(e => e.Oiaxic)
                .HasMaxLength(6)
                .HasColumnName("OIAXIC");
            entity.Property(e => e.Oiaxil)
                .HasMaxLength(6)
                .HasColumnName("OIAXIL");
            entity.Property(e => e.Oicysc)
                .HasMaxLength(6)
                .HasColumnName("OICYSC");
            entity.Property(e => e.Oicysl)
                .HasMaxLength(6)
                .HasColumnName("OICYSL");
            entity.Property(e => e.Oisphc)
                .HasMaxLength(6)
                .HasColumnName("OISPHC");
            entity.Property(e => e.Oisphl)
                .HasMaxLength(6)
                .HasColumnName("OISPHL");
            entity.Property(e => e.Pdc)
                .HasMaxLength(3)
                .HasColumnName("PDC");
            entity.Property(e => e.Pdl)
                .HasMaxLength(3)
                .HasColumnName("PDL");
            entity.Property(e => e.Preventiva)
                .HasDefaultValueSql("'0'")
                .HasColumnName("preventiva");
        });

        modelBuilder.Entity<Ocupacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ocupacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasMaxLength(20)
                .HasColumnName("detalle");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("paciente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AMaterno)
                .HasMaxLength(25)
                .HasColumnName("aMaterno");
            entity.Property(e => e.APaterno)
                .HasMaxLength(25)
                .HasColumnName("aPaterno");
            entity.Property(e => e.Alergico)
                .HasDefaultValueSql("'0'")
                .HasColumnName("alergico");
            entity.Property(e => e.AntecedentesClinicos)
                .HasMaxLength(150)
                .HasColumnName("antecedentesClinicos");
            entity.Property(e => e.AntecedentesFamiliares)
                .HasMaxLength(150)
                .HasColumnName("antecedentesFamiliares");
            entity.Property(e => e.Asegurado)
                .HasDefaultValueSql("'0'")
                .HasColumnName("asegurado");
            entity.Property(e => e.CampoVisual)
                .HasMaxLength(6)
                .HasColumnName("campoVisual");
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .HasColumnName("celular");
            entity.Property(e => e.CelularContacto)
                .HasMaxLength(20)
                .HasColumnName("celularContacto");
            entity.Property(e => e.CentroTrabajo)
                .HasMaxLength(40)
                .HasColumnName("centroTrabajo");
            entity.Property(e => e.Condicion)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("condicion");
            entity.Property(e => e.Contacto)
                .HasMaxLength(50)
                .HasColumnName("contacto");
            entity.Property(e => e.Diabetico)
                .HasDefaultValueSql("'0'")
                .HasColumnName("diabetico");
            entity.Property(e => e.Direccion)
                .HasMaxLength(60)
                .HasColumnName("direccion");
            entity.Property(e => e.Edad)
                .HasMaxLength(3)
                .HasColumnName("edad");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .HasColumnName("email");
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("estadoCivil");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.GrupoSanguineo)
                .HasMaxLength(10)
                .HasColumnName("grupoSanguineo");
            entity.Property(e => e.IdCiaSeguro).HasColumnName("idCiaSeguro");
            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.IdDiabetes).HasColumnName("idDiabetes");
            entity.Property(e => e.IdDistrito).HasColumnName("idDistrito");
            entity.Property(e => e.IdOcupacion).HasColumnName("idOcupacion");
            entity.Property(e => e.IdParentesco).HasColumnName("idParentesco");
            entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("nacionalidad");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .HasColumnName("nombres");
            entity.Property(e => e.NumeroCarnet)
                .HasMaxLength(10)
                .HasColumnName("numeroCarnet");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(12)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.Perfil)
                .HasMaxLength(200)
                .HasColumnName("perfil");
            entity.Property(e => e.PresionArterial)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("presionArterial");
            entity.Property(e => e.Sexo).HasColumnName("sexo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.TelefonoContacto)
                .HasMaxLength(20)
                .HasColumnName("telefonoContacto");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("tipoDocumento");
        });

        modelBuilder.Entity<Parentesco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("parentesco");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Valor)
                .HasMaxLength(20)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Presentacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("presentacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abreviatura)
                .HasMaxLength(4)
                .HasColumnName("abreviatura");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Procedimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("procedimiento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abreviatura)
                .HasMaxLength(20)
                .HasColumnName("abreviatura");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("provincia");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.Provincia)
                .HasMaxLength(50)
                .HasColumnName("provincia");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Correo, "correo").IsUnique();

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Cargo)
                .HasMaxLength(30)
                .HasColumnName("cargo");
            entity.Property(e => e.Clave)
                .HasMaxLength(250)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("correo");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(30)
                .HasColumnName("especialidad");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NroColMedico)
                .HasMaxLength(6)
                .HasColumnName("nroColMedico");
            entity.Property(e => e.UltimaSesion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ultimaSesion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
