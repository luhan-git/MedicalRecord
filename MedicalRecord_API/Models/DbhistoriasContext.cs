using Microsoft.EntityFrameworkCore;

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

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Ciaseguro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ciaseguro");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

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

            entity.HasIndex(e => e.Codigo, "codigo").IsUnique();

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

            entity.HasIndex(e => e.IdCie, "idCie");

            entity.HasIndex(e => e.IdPaciente, "idPaciente");

            entity.HasIndex(e => e.IdUsuario, "idUsuario");

            entity.HasIndex(e => e.NumeroConsulta, "numeroConsulta").IsUnique();

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
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
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

            entity.HasOne(d => d.IdCieNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdCie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("consulta_ibfk_1");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("consulta_ibfk_3");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("consulta_ibfk_2");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("departamento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Detallealergium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detallealergia");

            entity.HasIndex(e => e.IdAlergia, "idAlergia");

            entity.HasIndex(e => e.IdPaciente, "idPaciente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAlergia).HasColumnName("idAlergia");
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.Reacciones)
                .HasMaxLength(200)
                .HasColumnName("reacciones");

            entity.HasOne(d => d.IdAlergiaNavigation).WithMany(p => p.Detallealergia)
                .HasForeignKey(d => d.IdAlergia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detallealergia_ibfk_1");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Detallealergia)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detallealergia_ibfk_2");
        });

        modelBuilder.Entity<Detalleexaman>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detalleexamen");

            entity.HasIndex(e => e.IdConsulta, "idConsulta");

            entity.HasIndex(e => e.IdExamenLab, "idExamenLab");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasMaxLength(255)
                .HasColumnName("detalle");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.FechaResultado)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime")
                .HasColumnName("fechaResultado");
            entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");
            entity.Property(e => e.IdExamenLab).HasColumnName("idExamenLab");
            entity.Property(e => e.Resultado)
                .HasMaxLength(500)
                .HasColumnName("resultado");

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Detalleexamen)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalleexamen_ibfk_1");

            entity.HasOne(d => d.IdExamenLabNavigation).WithMany(p => p.Detalleexamen)
                .HasForeignKey(d => d.IdExamenLab)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalleexamen_ibfk_2");
        });

        modelBuilder.Entity<Detalleprocedimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detalleprocedimiento");

            entity.HasIndex(e => e.IdConsulta, "idConsulta");

            entity.HasIndex(e => e.IdProcedimiento, "idProcedimiento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasMaxLength(255)
                .HasColumnName("detalle");
            entity.Property(e => e.Directorio)
                .HasMaxLength(500)
                .HasColumnName("directorio");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.FechaResultado)
                .ValueGeneratedOnAddOrUpdate()
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

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Detalleprocedimientos)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalleprocedimiento_ibfk_1");

            entity.HasOne(d => d.IdProcedimientoNavigation).WithMany(p => p.Detalleprocedimientos)
                .HasForeignKey(d => d.IdProcedimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalleprocedimiento_ibfk_2");
        });

        modelBuilder.Entity<Diabete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("diabetes");

            entity.HasIndex(e => e.Tipo, "tipo").IsUnique();

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

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

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

            entity.HasIndex(e => e.IdProvincia, "idProvincia");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Distritos)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("distrito_ibfk_1");
        });

        modelBuilder.Entity<Examenlaboratorio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("examenlaboratorio");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

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

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

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

            entity.HasIndex(e => e.IdConsulta, "idConsulta");

            entity.HasIndex(e => e.IdMedicamento, "idMedicamento");

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

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Medicacions)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicacion_ibfk_1");

            entity.HasOne(d => d.IdMedicamentoNavigation).WithMany(p => p.Medicacions)
                .HasForeignKey(d => d.IdMedicamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicacion_ibfk_2");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("medicamento");

            entity.HasIndex(e => e.Codigo, "codigo").IsUnique();

            entity.HasIndex(e => e.IdLaboratorio, "idLaboratorio");

            entity.HasIndex(e => e.IdPresentacion, "idPresentacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(7)
                .HasColumnName("codigo");
            entity.Property(e => e.Dosis)
                .HasMaxLength(80)
                .HasColumnName("dosis");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsFixedLength()
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

            entity.HasOne(d => d.IdLaboratorioNavigation).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.IdLaboratorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicamento_ibfk_2");

            entity.HasOne(d => d.IdPresentacionNavigation).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.IdPresentacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicamento_ibfk_1");
        });

        modelBuilder.Entity<Medidalente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("medidalente");

            entity.HasIndex(e => e.IdConsulta, "idConsulta");

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

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Medidalentes)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medidalente_ibfk_1");
        });

        modelBuilder.Entity<Ocupacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ocupacion");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasMaxLength(50)
                .HasColumnName("detalle");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("paciente");

            entity.HasIndex(e => e.IdCiaSeguro, "idCiaSeguro");

            entity.HasIndex(e => e.IdDepartamento, "idDepartamento");

            entity.HasIndex(e => e.IdDiabetes, "idDiabetes");

            entity.HasIndex(e => e.IdDistrito, "idDistrito");

            entity.HasIndex(e => e.IdOcupacion, "idOcupacion");

            entity.HasIndex(e => e.IdParentesco, "idParentesco");

            entity.HasIndex(e => e.IdProvincia, "idProvincia");

            entity.HasIndex(e => e.NumeroCarnet, "numeroCarnet").IsUnique();

            entity.HasIndex(e => e.NumeroDocumento, "numeroDocumento").IsUnique();

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
                .HasDefaultValueSql("'0'")
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
                .HasDefaultValueSql("'0'")
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
                .HasDefaultValueSql("'0'")
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
                .HasDefaultValueSql("'1'")
                .IsFixedLength()
                .HasColumnName("presionArterial");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("sexo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.TelefonoContacto)
                .HasMaxLength(20)
                .HasColumnName("telefonoContacto");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .IsFixedLength()
                .HasColumnName("tipoDocumento");

            entity.HasOne(d => d.IdCiaSeguroNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdCiaSeguro)
                .HasConstraintName("paciente_ibfk_4");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paciente_ibfk_1");

            entity.HasOne(d => d.IdDiabetesNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdDiabetes)
                .HasConstraintName("paciente_ibfk_7");

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdDistrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paciente_ibfk_3");

            entity.HasOne(d => d.IdOcupacionNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdOcupacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paciente_ibfk_6");

            entity.HasOne(d => d.IdParentescoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdParentesco)
                .HasConstraintName("paciente_ibfk_5");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paciente_ibfk_2");
        });

        modelBuilder.Entity<Parentesco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("parentesco");

            entity.HasIndex(e => e.Valor, "valor").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Valor)
                .HasMaxLength(20)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Presentacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("presentacion");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

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

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

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

            entity.HasIndex(e => e.IdDepartamento, "idDepartamento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("provincia_ibfk_1");
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
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
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
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasColumnName("rol");
            entity.Property(e => e.UltimaSesion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ultimaSesion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
