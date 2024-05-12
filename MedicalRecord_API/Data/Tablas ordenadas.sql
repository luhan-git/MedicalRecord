CREATE DATABASE DBHISTORIAS;
USE DBHISTORIAS;

CREATE TABLE UBICACION(
	id_ubica int AUTO_INCREMENT  PRIMARY KEY,
	tab_tipreg int NOT NULL,
	tab_codreg char(6) NOT NULL,
	tab_nombre varchar(30) NULL,
	tab_codrela char(6) NULL
);

CREATE TABLE Medicos(
	id_medico int AUTO_INCREMENT PRIMARY KEY ,
	nombre_med varchar(50) NOT NULL,
	espe_med varchar(30) NULL,
	nro_cmed varchar(6) NULL,
	estado bool default true
);

CREATE TABLE Lineas(--Laboratorios
	id_linea int AUTO_INCREMENT PRIMARY KEY ,
	nombre_linea varchar(40) NOT NULL,
	nemo_linea varchar(4) NULL
);

--Presentación de los medicamentos
CREATE TABLE Presentaciones(
	id_presenta int AUTO_INCREMENT PRIMARY KEY ,
	nombre_prese varchar(30) NOT NULL,
	nemo_prese varchar(4) NOT NULL
);

CREATE TABLE Medicamentos(
	id_articulo int AUTO_INCREMENT PRIMARY KEY ,
	cod_articulo varchar(7) NULL,
	id_linea int NOT NULL,--laboratorio(linea)
	id_sunidad int NOT NULL,--tipo de unidad
	name_comercial varchar(50) NULL,
	name_generico varchar(50) NULL,
	id_tipo tinyint NULL,--presentaciones
	estado varchar(1) NULL,
	dosis varchar(80) NULL,
	indicacion varchar(180) NULL
);

CREATE TABLE CIE(
	id_cie int AUTO_INCREMENT PRIMARY KEY ,
	codcie varchar(5) NOT NULL,
	enfermedad varchar(120) NOT NULL
);

CREATE TABLE ExamenesLaboratorio(
	id_exam int AUTO_INCREMENT PRIMARY KEY ,
	nombre_exam varchar(50) NOT NULL,
	nemo_exam varchar(20) NULL
);

CREATE TABLE Procedimientos(
	id_proce int AUTO_INCREMENT PRIMARY KEY,
	nombre_proce varchar(50) NOT NULL,
	nemo_proce varchar(20) NULL
);

CREATE TABLE CiaSeguros(
	id_cia int AUTO_INCREMENT PRIMARY KEY,
	nombre_cia varchar(50) NOT NULL,
	nemo_cia varchar(20) NULL
);

CREATE TABLE Directorio(
	id_directorio int AUTO_INCREMENT PRIMARY KEY ,
	nombre varchar(80) NULL,
	repre varchar(80) NULL,
	fono varchar(40) NULL,
	celular varchar(40) NULL,
	email varchar(80) NULL,
	direccion varchar(180) NULL,
	estado varchar(1) NULL
);

CREATE TABLE Ocupacion(
	id_ocupa int AUTO_INCREMENT  PRIMARY KEY,
	nombre_ocupa varchar(60) NULL,
	detalle_ocupa varchar(20) NULL
);

-- Proceso de atención
CREATE TABLE paciente(
	idpaciente int AUTO_INCREMENT PRIMARY KEY,
	nhisto varchar(7) NULL,
	fching datetime NOT NULL,
	condicion char(1) NOT NULL,
	apaterno varchar(25) NOT NULL,
	amaterno varchar(25) NOT NULL,
	nombres varchar(50) NOT NULL,
	tipdoc char(1) NOT NULL,
	nrodocu varchar(12) NULL,
	fchnac datetime NOT NULL,
	sexo char(1) NOT NULL,
	estcivil char(1) NOT NULL,
	gruposa varchar(10) NULL,
	nacion char(1) NOT NULL,
	procede varchar(60) NULL,
	iddepa int NOT NULL,
	idprov int NOT NULL,
	iddist int NOT NULL,
	direcc varchar(60) NULL,
	idocupa int NULL,
	telcasa varchar(20) NULL,
	centrab varchar(40) NULL,
	celular varchar(20) NULL,
	asegu char(1) NOT NULL,
	ncarnet varchar(10) NULL,
	ciasegu int NULL,
	contacto varchar(60) NULL,
	idparen int NULL,
	telcon varchar(20) NULL,
	celcon varchar(20) NULL,
	perfil varchar(200) NULL,
	anteclinic varchar(160) NULL,
	antefam varchar(160) NULL,
	historia_c nvarchar(255) NULL,
	edad varchar(3) NULL,
	lugar_nac varchar(20) NULL,
	ocupacion varchar(25) NULL,
	hipertenso char(1) NULL,
	diabetes char(1) NULL,
	tipoDiabetes varchar(20) NULL,
	alergico char(1) NULL,
	tipoAlergia varchar(25) NULL,
	CV varchar(6) NULL,
	id_medico int NULL,
	email varchar(80) NULL
);

CREATE TABLE Consulta(
	id_consulta int AUTO_INCREMENT PRIMARY KEY ,
	nro_consulta int NOT NULL,
	id_paciente int NOT NULL,
	fch_consulta datetime NOT NULL,
	motivo varchar(80) NOT NULL,
	enf_actual varchar(800) NULL,
	davsc varchar(10) NULL,
	iavsc varchar(10) NULL,
	davcc varchar(10) NULL,
	iavcc varchar(10) NULL,
	dpio varchar(10) NULL,
	ipio varchar(10) NULL,
	diagnostico varchar(200) NULL,
	sp varchar(80) NULL,
	detaExam varchar(40) NULL,
	valorK varchar(80) NULL,
	shimer varchar(10) NULL,
	atiendeProE varchar(180) NULL,
	notaProE varchar(120) NULL,
	id_medico int NULL,
	examOcular varchar(400) NULL
);

--Detalle entre consulta y examenes de laboratorio
CREATE TABLE IndicaExamenes(
	id_consulta int AUTO_INCREMENT  PRIMARY KEY,
	id_examen int NULL,
	fch_resulExam datetime NULL,
	observaExam varchar(200) NULL
);

--Detalle entre consulta y procedimientos
CREATE TABLE ProcedEspeciales(
	id_consulta int AUTO_INCREMENT  PRIMARY KEY,
	id_proce int NOT NULL,
	fch_resulProce datetime NULL,
	observa varchar(800) NULL,
	imagenes char(1) NULL,
	ubicacion varchar(160) NULL
);

--Incluye la medida de lentes
CREATE TABLE MedidaLentes(
	id_consulta int AUTO_INCREMENT  PRIMARY KEY,
	idpaciente int NOT NULL,
	OISPHL nvarchar(6) NULL,
	OICYSL nvarchar(6) NULL,
	OIAXIL nvarchar(6) NULL,
	ODSPHL nvarchar(6) NULL,
	ODCYSL nvarchar(6) NULL,
	ODAXIL nvarchar(6) NULL,
	PDL nvarchar(3) NULL,
	OBSL nvarchar(120) NULL,
	OISPHC nvarchar(6) NULL,
	OICYSC nvarchar(6) NULL,
	OIAXIC nvarchar(6) NULL,
	ODSPHC nvarchar(6) NULL,
	ODCYSC nvarchar(6) NULL,
	ODAXIC nvarchar(6) NULL,
	PDC nvarchar(3) NULL,
	OBSC nvarchar(120) NULL,
	ODAV varchar(6) NULL,
	OIAV varchar(6) NULL,
	atencion char(1) NULL,
	observaOpt varchar(180) NULL,
	condi char(1) NULL
);

--Detalle entre consulta y medicamentos
CREATE TABLE Medicacion(
	id_consulta int AUTO_INCREMENT  PRIMARY KEY,
	id_medicamento int NULL,
	dosis varchar(80) NULL,
	indicacion varchar(300) NULL
);

-- Junto con la medicacion se incluye las ordenes
CREATE TABLE OrdenesVarias(
	id_consulta int AUTO_INCREMENT  PRIMARY KEY,
	idpaciente int NOT NULL,
	atencion varchar(180) NULL,
	orden varchar(800) NULL,
	observa varchar(120) NULL
);



--------------------------------------------------
-- Aun no se implementa pero incluirlo en el sistema
CREATE TABLE AgendaCitas(
	id_cita int AUTO_INCREMENT  PRIMARY KEY,
	id_paciente int NOT NULL,
	fch_cita datetime NOT NULL,
	hra_cira varchar(12) NOT NULL,
	motivo varchar(50) NULL,
	id_medico int NOT NULL,
	tipo_paci char(1) NOT NULL,
	tipo_cita char(1) NOT NULL,
	estado char(1) NOT NULL,
	monto numeric(12, 2) NULL
);

-- ESTA TABLA YA NO SE UTILIZA EN EL SISTEMA
CREATE TABLE CampoVisual(
    IDPAC bigint AUTO_INCREMENT PRIMARY KEY,
    CAMPO_VIS CHAR(6) CHARACTER SET utf8mb4 NULL
);


-- ESTA TABLA YA NO SE DEBE UTILIZAR EN EL SISTEMA
CREATE TABLE DiagCIE(
	id_consulta int  AUTO_INCREMENT  PRIMARY KEY,
	id_cie int NULL
);

-- Los datos pueden ir directamente en la las citas
CREATE TABLE HorarioConsultas(
	id_paciente int AUTO_INCREMENT  PRIMARY KEY,
	fch_Cita varchar(10) NULL,
	hra_Cita varchar(10) NULL,
	fch_Consulta varchar(10) NULL,
	hra_Consulta varchar(10) NULL,
	id_Consulta int NULL,
	estado varchar(1) NOT NULL,
	observa varchar(300) NULL
);

-- Se va a utilizar para el historial de las consultas
CREATE TABLE imagenes(
	id_imagen int AUTO_INCREMENT PRIMARY KEY ,
	id_consulta int NULL,
	name_imagen varchar(20) NULL,
	desc_imagen varchar(100) NULL,
	fech_imagen varchar(10) NULL,
	foto_url varchar(255) NULL
);

CREATE TABLE InformesPaciente(
	id_info int AUTO_INCREMENT PRIMARY KEY,
	nro_info int NOT NULL,
	id_paciente int NOT NULL,
	fch_info datetime NOT NULL,
	informe nvarchar(255) NULL
);


