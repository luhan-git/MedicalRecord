DROP DATABASE IF EXISTS MEDICALRECORD;
CREATE DATABASE MEDICALRECORD;
USE MEDICALRECORD;

DROP TABLE IF EXISTS Usuarios;
CREATE TABLE Usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    correo VARCHAR(50) NOT NULL UNIQUE,
    clave VARCHAR(250) NOT NULL,
    cargo VARCHAR(30)  NOT NULL,
	especialidad VARCHAR(30) NULL,
    rol VARCHAR(20) DEFAULT 'cliente',
    isActivo BOOL DEFAULT TRUE,
    isDelete BOOL DEFAULT FALSE,
    fechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    fechaActualizacion DATETIME DEFAULT CURRENT_TIMESTAMP
);

DROP TABLE IF EXISTS Laboratorios;
CREATE TABLE Laboratorios (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(40) NOT NULL UNIQUE,
	isDelete BOOL DEFAULT FALSE
);

DROP TABLE IF EXISTS Presentaciones;
CREATE TABLE Presentaciones (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(30) NOT NULL UNIQUE,
	isDelete BOOL DEFAULT FALSE
);

DROP TABLE IF EXISTS Cies;
CREATE TABLE Cies(
	id INT AUTO_INCREMENT PRIMARY KEY,
	codigo VARCHAR(5) NOT NULL UNIQUE,
	nombre VARCHAR(50) NOT NULL,
	isDelete BOOL DEFAULT FALSE
);

DROP TABLE IF EXISTS Examenes;
CREATE TABLE Examenes(
	id INT AUTO_INCREMENT PRIMARY KEY,
    tipo varchar(15) NOT NULL DEFAULT 'general',
	nombre VARCHAR(50) NOT NULL UNIQUE,
	isDelete BOOL DEFAULT FALSE
);

DROP TABLE IF EXISTS Seguros;
CREATE TABLE Seguros (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL UNIQUE,
	isDelete BOOL DEFAULT FALSE
);

DROP TABLE IF EXISTS Ocupaciones;
CREATE TABLE Ocupaciones (
	id INT AUTO_INCREMENT  PRIMARY KEY,
	nombre VARCHAR(60) NOT NULL UNIQUE,
	detalle VARCHAR(50) NULL,
	isDelete BOOL DEFAULT FALSE
);

DROP TABLE IF EXISTS Medicamentos;
CREATE TABLE Medicamentos (
	id INT AUTO_INCREMENT PRIMARY KEY,
	codigo VARCHAR(7) NOT NULL UNIQUE,
    generico VARCHAR(50) NULL,
	comercial VARCHAR(50) NULL,
    dosis VARCHAR(20),
	indicacion VARCHAR(180) NULL,
    stock INT DEFAULT 0,
    costo FLOAT DEFAULT 0,
    ubicacion VARCHAR(20),
	estado CHAR(1) CHECK(estado IN('0','1','2')) DEFAULT '2',-- 0:descontinuado,1:prueba,2:Activo
    idPresentacion INT NOT NULL,
    idLaboratorio INT NOT NULL,
	isDelete BOOL DEFAULT FALSE,
    FOREIGN KEY (idPresentacion) REFERENCES Presentaciones(id),
    FOREIGN KEY (idLaboratorio) REFERENCES Laboratorios(id)
);

DROP TABLE IF EXISTS Diabetes;
CREATE TABLE Diabetes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    detalle VARCHAR(100),
    isDelete BOOL DEFAULT FALSE
);

DROP TABLE IF EXISTS Alergias;
CREATE TABLE Alergias (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    isDelete BOOL DEFAULT FALSE
);

DROP TABLE IF EXISTS Departamentos;
CREATE TABLE Departamentos(
  id INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=26;

DROP TABLE IF EXISTS Provincias;
CREATE TABLE Provincias(
  id INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(50) NOT NULL,
  idDepartamento INT NOT NULL,
  FOREIGN KEY (idDepartamento) REFERENCES Departamentos(id)
) ENGINE=InnoDB AUTO_INCREMENT=194;

DROP TABLE IF EXISTS Distritos;
CREATE TABLE Distritos(
  id INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(50) NOT NULL,
  idProvincia INT NOT NULL,
  FOREIGN KEY (idProvincia) REFERENCES Provincias(id)
) ENGINE=InnoDB AUTO_INCREMENT=1833;


DROP TABLE IF EXISTS Parentescos;
CREATE TABLE Parentescos(
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(20) NOT NULL UNIQUE,
    isDelete BOOL DEFAULT FALSE
);

DROP TABLE IF EXISTS Pacientes;
CREATE TABLE Pacientes(
	id INT AUTO_INCREMENT PRIMARY KEY,
	condicion CHAR(1) NOT NULL CHECK(condicion IN('0','1','2')) DEFAULT '0',-- Regular, retirado, fallecido
    primerNombre VARCHAR(50) NOT NULL,
    segundoNombre VARCHAR(50) NULL,
	aPaterno VARCHAR(25) NOT NULL,
	aMaterno VARCHAR(25) NOT NULL,
	tipoDocumento CHAR(1) NOT NULL CHECK(tipoDocumento IN('0','1','2','3')) DEFAULT '0',-- DNI ...
	numeroDocumento VARCHAR(12) NOT NULL UNIQUE,
	fechaNacimiento DATETIME NOT NULL,
    edad VARCHAR(3) NOT NULL,
	sexo CHAR(1) NOT NULL CHECK(sexo IN('M', 'F')),
	estadoCivil CHAR(1) NOT NULL CHECK (estadoCivil IN('0','1','2','3','4')) DEFAULT '0',-- Soltero ...
	grupoSanguineo VARCHAR(10) NOT NULL CHECK (grupoSanguineo IN('0','1','2','3','4','5','6','7','8')) DEFAULT '0',-- No indica ...
	nacionalidad CHAR(1) NOT NULL CHECK (nacionalidad IN('0','1') ),-- Peruana/Extranjera
	idDepartamento INT NOT NULL,
	idProvincia INT NOT NULL,
	idDistrito INT NOT NULL,
	direccion VARCHAR(60) NULL,
	telefono VARCHAR(20) NULL,
    celular VARCHAR(20) NULL,
    email VARCHAR(80) NULL,
    idOcupacion INT NOT NULL,
	centroTrabajo VARCHAR(40) NULL,
    isAsegurado BOOL DEFAULT FALSE,
    idSeguro INT NULL,-- foranea
	numeroCarnet VARCHAR(10) NULL UNIQUE,
    perfil VARCHAR(200) NULL,
	isAlergico BOOL DEFAULT FALSE,
	isDiabetico BOOL DEFAULT FALSE,
    isDelete BOOL DEFAULT FALSE,
    FOREIGN KEY (idDepartamento) REFERENCES Departamentos(id),
    FOREIGN KEY (idProvincia) REFERENCES Provincias(id),
    FOREIGN KEY (idDistrito) REFERENCES Distritos(id),
	FOREIGN KEY (idOcupacion) REFERENCES Ocupaciones(id),
    FOREIGN KEY(idSeguro) REFERENCES Seguros(id)
);

DROP TABLE IF EXISTS Contactos;
CREATE TABLE Contactos(
	id INT AUTO_INCREMENT PRIMARY KEY,
	idPaciente INT NOT NULL,
    nombre VARCHAR(50) NULL,
    idParentesco INT NULL,
	telefono VARCHAR(20) NULL,
	celular VARCHAR(20) NULL,
    isDelete BOOL DEFAULT FALSE,
    FOREIGN KEY (idParentesco) REFERENCES Parentescos(id),
	FOREIGN KEY (idPaciente) references Pacientes(id)
);
DROP TABLE IF EXISTS Antecedentes;
CREATE TABLE Antecedentes(
 id INT AUTO_INCREMENT PRIMARY KEY,
 idPaciente INT UNIQUE NOT NULL,
 antecedentesClinicos VARCHAR(150) NULL,
 antecedentesFamiliares VARCHAR(150) NULL,
 presionArterial CHAR(3) NOT NULL CHECK ( presionArterial IN('0','1','2') ) DEFAULT '1',-- bajo normal alto
 campoVisual VARCHAR(6) NULL,
 idDiabete INT NULL,
 fechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP,
 fechaActualizacion DATETIME ON UPDATE CURRENT_TIMESTAMP,
 isDelete BOOL DEFAULT FALSE,
 FOREIGN KEY (idDiabete) REFERENCES Diabetes(id),
 FOREIGN KEY (idPaciente) references Pacientes(id)
);

DROP TABLE IF EXISTS DetalleAlergias;
CREATE TABLE DetalleAlergias (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idAlergia INT NOT NULL,
    idAntecedente INT NOT NULL,
    reacciones VARCHAR(200),
    isDelete BOOL DEFAULT FALSE,
    FOREIGN KEY (idAlergia) REFERENCES Alergias(id),
    FOREIGN KEY (idAntecedente) REFERENCES Antecedentes(id)
);

DROP TABLE IF EXISTS Consultas;
CREATE TABLE Consultas(
	id INT AUTO_INCREMENT PRIMARY KEY,
	Correlacional VARCHAR(7) UNIQUE,
	motivo VARCHAR(80) NOT NULL,
	enfermedadActual VARCHAR(200) NULL,
	davsc VARCHAR(10) NULL,
	iavsc VARCHAR(10) NULL,
	davcc VARCHAR(10) NULL,
	iavcc VARCHAR(10) NULL,
	dpio VARCHAR(10) NULL,
	ipio VARCHAR(10) NULL,
    shimer VARCHAR(10) NULL,
    valorK VARCHAR(80) NULL,
	diagnostico VARCHAR(200) NULL,
    idCie INT NOT NULL,
	idUsuario INT NOT NULL,
    idPaciente INT NOT NULL,
    isDelete BOOL DEFAULT FALSE,
    fechaConsulta DATETIME DEFAULT CURRENT_TIMESTAMP,
    fechaActualizacion DATETIME ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idCie) REFERENCES Cies(id),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(id),
	FOREIGN KEY (idPaciente) REFERENCES Pacientes(id)
);
DROP TABLE IF EXISTS MedidaLentes;
CREATE TABLE MedidaLentes(
	id INT AUTO_INCREMENT  PRIMARY KEY,
    idConsulta INT NOT NULL,
    -- lejos
    ODSPHL VARCHAR(6) NULL,
	ODCYSL VARCHAR(6) NULL,
	ODAXIL VARCHAR(6) NULL,
    ODAV VARCHAR(6) NULL,
	OISPHL VARCHAR(6) NULL,
	OICYSL VARCHAR(6) NULL,
	OIAXIL VARCHAR(6) NULL,
    OIAV VARCHAR(6) NULL,
	PDL VARCHAR(3) NULL,
	OBSL VARCHAR(120) NULL,
    -- cerca
    ODSPHC VARCHAR(6) NULL,
	ODCYSC VARCHAR(6) NULL,
	ODAXIC VARCHAR(6) NULL,
	OISPHC VARCHAR(6) NULL,
	OICYSC VARCHAR(6) NULL,
	OIAXIC VARCHAR(6) NULL,
	PDC VARCHAR(3) NULL,
	OBSC VARCHAR(120) NULL,
    preventiva BOOL DEFAULT FALSE,
    isDelete BOOL DEFAULT FALSE,
    FOREIGN KEY (idConsulta) REFERENCES Consultas(id)
);
DROP TABLE IF EXISTS Recetas;
CREATE TABLE Recetas(
	id INT AUTO_INCREMENT PRIMARY KEY,
    idConsulta INT NOT NULL,
    diagnostico VARCHAR(250),
	idMedicamento INT NOT NULL,
    dosis VARCHAR(15),
    frecuencia VARCHAR(15),
    indicaciones VARCHAR(50),
    isDelete BOOL DEFAULT FALSE,
    FOREIGN KEY (idConsulta) REFERENCES Consultas(id),
    FOREIGN KEY (idMedicamento) REFERENCES Medicamentos(id)
);
DROP TABLE IF EXISTS OrdenesMedicas;
CREATE TABLE OrdenesMedicas(
id INT AUTO_INCREMENT PRIMARY KEY,
idConsulta INT NOT NULL,
idExamen INT NOT NULL,
nombreExamen VARCHAR(50),
descripcion VARCHAR(50),
fechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP,
resultados VARCHAR(20),
fechaResultados DATETIME DEFAULT current_timestamp,
isDelete BOOL DEFAULT FALSE,
FOREIGN KEY (idConsulta) REFERENCES Consultas(id),
FOREIGN KEY (idExamen) REFERENCES Examenes(id)
);



