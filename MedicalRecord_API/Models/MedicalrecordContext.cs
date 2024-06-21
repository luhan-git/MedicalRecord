using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MedicalRecord_API.Models;

public partial class MedicalrecordContext : DbContext
{
    public MedicalrecordContext()
    {
    }

    public MedicalrecordContext(DbContextOptions<MedicalrecordContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alergia> Alergias { get; set; }

    public virtual DbSet<Antecedente> Antecedentes { get; set; }

    public virtual DbSet<Consulta> Consultas { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Cy> Cies { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Detallealergia> Detallealergias { get; set; }

    public virtual DbSet<Diabete> Diabetes { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Examene> Examenes { get; set; }

    public virtual DbSet<Laboratorio> Laboratorios { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Medidalente> Medidalentes { get; set; }

    public virtual DbSet<Ocupacione> Ocupaciones { get; set; }

    public virtual DbSet<Ordenesmedica> Ordenesmedicas { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Parentesco> Parentescos { get; set; }

    public virtual DbSet<Presentacione> Presentaciones { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Receta> Recetas { get; set; }

    public virtual DbSet<Seguro> Seguros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Alergia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("alergias");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Antecedente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("antecedentes");

            entity.HasIndex(e => e.IdDiabete, "idDiabete");

            entity.HasIndex(e => e.IdPaciente, "idPaciente").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AntecedentesClinicos)
                .HasMaxLength(150)
                .HasColumnName("antecedentesClinicos");
            entity.Property(e => e.AntecedentesFamiliares)
                .HasMaxLength(150)
                .HasColumnName("antecedentesFamiliares");
            entity.Property(e => e.CampoVisual)
                .HasMaxLength(6)
                .HasColumnName("campoVisual");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.IdDiabete).HasColumnName("idDiabete");
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.PresionArterial)
                .HasMaxLength(3)
                .HasDefaultValueSql("'1'")
                .IsFixedLength()
                .HasColumnName("presionArterial");

            entity.HasOne(d => d.IdDiabeteNavigation).WithMany(p => p.Antecedentes)
                .HasForeignKey(d => d.IdDiabete)
                .HasConstraintName("antecedentes_ibfk_1");

            entity.HasOne(d => d.IdPacienteNavigation).WithOne(p => p.Antecedente)
                .HasForeignKey<Antecedente>(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("antecedentes_ibfk_2");
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("consultas");

            entity.HasIndex(e => e.Correlacional, "Correlacional").IsUnique();

            entity.HasIndex(e => e.IdCie, "idCie");

            entity.HasIndex(e => e.IdPaciente, "idPaciente");

            entity.HasIndex(e => e.IdUsuario, "idUsuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correlacional).HasMaxLength(7);
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
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Ipio)
                .HasMaxLength(10)
                .HasColumnName("ipio");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Motivo)
                .HasMaxLength(80)
                .HasColumnName("motivo");
            entity.Property(e => e.Shimer)
                .HasMaxLength(10)
                .HasColumnName("shimer");
            entity.Property(e => e.ValorK)
                .HasMaxLength(80)
                .HasColumnName("valorK");

            entity.HasOne(d => d.IdCieNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdCie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("consultas_ibfk_1");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("consultas_ibfk_3");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("consultas_ibfk_2");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contactos");

            entity.HasIndex(e => e.IdPaciente, "idPaciente");

            entity.HasIndex(e => e.IdParentesco, "idParentesco");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .HasColumnName("celular");
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.IdParentesco).HasColumnName("idParentesco");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contactos_ibfk_2");

            entity.HasOne(d => d.IdParentescoNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.IdParentesco)
                .HasConstraintName("contactos_ibfk_1");
        });

        modelBuilder.Entity<Cy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cies");

            entity.HasIndex(e => e.Codigo, "codigo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .HasColumnName("codigo");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("departamentos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Detallealergia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detallealergias");

            entity.HasIndex(e => e.IdAlergia, "idAlergia");

            entity.HasIndex(e => e.IdAntecedente, "idAntecedente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAlergia).HasColumnName("idAlergia");
            entity.Property(e => e.IdAntecedente).HasColumnName("idAntecedente");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Reacciones)
                .HasMaxLength(200)
                .HasColumnName("reacciones");

            entity.HasOne(d => d.IdAlergiaNavigation).WithMany(p => p.Detallealergia)
                .HasForeignKey(d => d.IdAlergia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detallealergias_ibfk_1");

            entity.HasOne(d => d.IdAntecedenteNavigation).WithMany(p => p.Detallealergia)
                .HasForeignKey(d => d.IdAntecedente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detallealergias_ibfk_2");
        });

        modelBuilder.Entity<Diabete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("diabetes");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasMaxLength(100)
                .HasColumnName("detalle");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("distritos");

            entity.HasIndex(e => e.IdProvincia, "idProvincia");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Distritos)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("distritos_ibfk_1");
        });

        modelBuilder.Entity<Examene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("examenes");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(15)
                .HasDefaultValueSql("'general'")
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Laboratorio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("laboratorios");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("medicamentos");

            entity.HasIndex(e => e.Codigo, "codigo").IsUnique();

            entity.HasIndex(e => e.IdLaboratorio, "idLaboratorio");

            entity.HasIndex(e => e.IdPresentacion, "idPresentacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(7)
                .HasColumnName("codigo");
            entity.Property(e => e.Comercial)
                .HasMaxLength(50)
                .HasColumnName("comercial");
            entity.Property(e => e.Costo)
                .HasDefaultValueSql("'0'")
                .HasColumnName("costo");
            entity.Property(e => e.Dosis)
                .HasMaxLength(20)
                .HasColumnName("dosis");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .HasDefaultValueSql("'2'")
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.Generico)
                .HasMaxLength(50)
                .HasColumnName("generico");
            entity.Property(e => e.IdLaboratorio).HasColumnName("idLaboratorio");
            entity.Property(e => e.IdPresentacion).HasColumnName("idPresentacion");
            entity.Property(e => e.Indicacion)
                .HasMaxLength(180)
                .HasColumnName("indicacion");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Stock)
                .HasDefaultValueSql("'0'")
                .HasColumnName("stock");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(20)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdLaboratorioNavigation).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.IdLaboratorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicamentos_ibfk_2");

            entity.HasOne(d => d.IdPresentacionNavigation).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.IdPresentacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicamentos_ibfk_1");
        });

        modelBuilder.Entity<Medidalente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("medidalentes");

            entity.HasIndex(e => e.IdConsulta, "idConsulta");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
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

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Medidalentes)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medidalentes_ibfk_1");
        });

        modelBuilder.Entity<Ocupacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ocupaciones");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasMaxLength(50)
                .HasColumnName("detalle");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Ordenesmedica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ordenesmedicas");

            entity.HasIndex(e => e.IdConsulta, "idConsulta");

            entity.HasIndex(e => e.IdExamen, "idExamen");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaResultados)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fechaResultados");
            entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");
            entity.Property(e => e.IdExamen).HasColumnName("idExamen");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.NombreExamen)
                .HasMaxLength(50)
                .HasColumnName("nombreExamen");
            entity.Property(e => e.Resultados)
                .HasMaxLength(20)
                .HasColumnName("resultados");

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Ordenesmedicas)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ordenesmedicas_ibfk_1");

            entity.HasOne(d => d.IdExamenNavigation).WithMany(p => p.Ordenesmedicas)
                .HasForeignKey(d => d.IdExamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ordenesmedicas_ibfk_2");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pacientes");

            entity.HasIndex(e => e.IdDepartamento, "idDepartamento");

            entity.HasIndex(e => e.IdDistrito, "idDistrito");

            entity.HasIndex(e => e.IdOcupacion, "idOcupacion");

            entity.HasIndex(e => e.IdProvincia, "idProvincia");

            entity.HasIndex(e => e.IdSeguro, "idSeguro");

            entity.HasIndex(e => e.NumeroCarnet, "numeroCarnet").IsUnique();

            entity.HasIndex(e => e.NumeroDocumento, "numeroDocumento").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AMaterno)
                .HasMaxLength(25)
                .HasColumnName("aMaterno");
            entity.Property(e => e.APaterno)
                .HasMaxLength(25)
                .HasColumnName("aPaterno");
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .HasColumnName("celular");
            entity.Property(e => e.CentroTrabajo)
                .HasMaxLength(40)
                .HasColumnName("centroTrabajo");
            entity.Property(e => e.Condicion)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .IsFixedLength()
                .HasColumnName("condicion");
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
                .HasDefaultValueSql("'0'")
                .IsFixedLength()
                .HasColumnName("estadoCivil");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.GrupoSanguineo)
                .HasMaxLength(10)
                .HasDefaultValueSql("'0'")
                .HasColumnName("grupoSanguineo");
            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.IdDistrito).HasColumnName("idDistrito");
            entity.Property(e => e.IdOcupacion).HasColumnName("idOcupacion");
            entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");
            entity.Property(e => e.IdSeguro).HasColumnName("idSeguro");
            entity.Property(e => e.IsAlergico)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isAlergico");
            entity.Property(e => e.IsAsegurado)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isAsegurado");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.IsDiabetico)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDiabetico");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("nacionalidad");
            entity.Property(e => e.NumeroCarnet)
                .HasMaxLength(10)
                .HasColumnName("numeroCarnet");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(12)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.Perfil)
                .HasMaxLength(200)
                .HasColumnName("perfil");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(50)
                .HasColumnName("primerNombre");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(50)
                .HasColumnName("segundoNombre");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("sexo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .IsFixedLength()
                .HasColumnName("tipoDocumento");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pacientes_ibfk_1");

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdDistrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pacientes_ibfk_3");

            entity.HasOne(d => d.IdOcupacionNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdOcupacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pacientes_ibfk_4");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pacientes_ibfk_2");

            entity.HasOne(d => d.IdSeguroNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdSeguro)
                .HasConstraintName("pacientes_ibfk_5");
        });

        modelBuilder.Entity<Parentesco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("parentescos");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Presentacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("presentaciones");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("provincias");

            entity.HasIndex(e => e.IdDepartamento, "idDepartamento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("provincias_ibfk_1");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("recetas");

            entity.HasIndex(e => e.IdConsulta, "idConsulta");

            entity.HasIndex(e => e.IdMedicamento, "idMedicamento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(250)
                .HasColumnName("diagnostico");
            entity.Property(e => e.Dosis)
                .HasMaxLength(15)
                .HasColumnName("dosis");
            entity.Property(e => e.Frecuencia)
                .HasMaxLength(15)
                .HasColumnName("frecuencia");
            entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");
            entity.Property(e => e.IdMedicamento).HasColumnName("idMedicamento");
            entity.Property(e => e.Indicaciones)
                .HasMaxLength(50)
                .HasColumnName("indicaciones");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recetas_ibfk_1");

            entity.HasOne(d => d.IdMedicamentoNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IdMedicamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recetas_ibfk_2");
        });

        modelBuilder.Entity<Seguro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("seguros");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Correo, "correo").IsUnique();

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
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
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IsActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("isActivo");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDelete");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasDefaultValueSql("'cliente'")
                .HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
