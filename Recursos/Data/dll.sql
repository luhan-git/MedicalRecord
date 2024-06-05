DROP DATABASE IF EXISTS DBHISTORIAS;
CREATE DATABASE DBHISTORIAS;
USE DBHISTORIAS;

DROP TABLE IF EXISTS Usuario;
CREATE TABLE Usuario (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    correo VARCHAR(50) NOT NULL UNIQUE,
    clave VARCHAR(250) NOT NULL,
    cargo VARCHAR(30)  NOT NULL,
	especialidad VARCHAR(30) NULL,
	nroColMedico VARCHAR(6) NULL,
    rol VARCHAR(20) NOT NULL,
    activo BOOL DEFAULT TRUE,
    fechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    fechaActualizacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    ultimaSesion DATETIME DEFAULT CURRENT_TIMESTAMP
);
DROP TABLE IF EXISTS Laboratorio;
CREATE TABLE Laboratorio (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(40) NOT NULL UNIQUE,
	abreviatura VARCHAR(4) NULL
);

DROP TABLE IF EXISTS Presentacion;
CREATE TABLE Presentacion (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(30) NOT NULL UNIQUE,
	abreviatura VARCHAR(4) NULL
);

DROP TABLE IF EXISTS CIE;
CREATE TABLE CIE (
	id INT AUTO_INCREMENT PRIMARY KEY,
	codigo VARCHAR(5) NOT NULL UNIQUE,
	enfermedad VARCHAR(120) NOT NULL
);

DROP TABLE IF EXISTS ExamenLaboratorio;
CREATE TABLE ExamenLaboratorio (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL UNIQUE,
	abreviatura VARCHAR(20) NULL
);

DROP TABLE IF EXISTS Procedimiento;
CREATE TABLE Procedimiento (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL UNIQUE,
	abreviatura VARCHAR(20) NULL
);

DROP TABLE IF EXISTS CiaSeguro;
CREATE TABLE CiaSeguro (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL UNIQUE,
	abreviatura VARCHAR(20) NULL
);

DROP TABLE IF EXISTS Directorio;
CREATE TABLE Directorio (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(80) NOT NULL UNIQUE,
	representante VARCHAR(80) NULL,
	telefono VARCHAR(40) NULL,
	celular VARCHAR(40) NULL,
	email VARCHAR(80) NULL,
	direccion VARCHAR(180) NULL,
	estado BOOL DEFAULT TRUE
);

DROP TABLE IF EXISTS Ocupacion;
CREATE TABLE Ocupacion (
	id INT AUTO_INCREMENT  PRIMARY KEY,
	nombre VARCHAR(60) NOT NULL UNIQUE,
	detalle VARCHAR(50) NULL
);

DROP TABLE IF EXISTS Medicamento;
CREATE TABLE Medicamento (
	id INT AUTO_INCREMENT PRIMARY KEY,
	codigo VARCHAR(7) NOT NULL UNIQUE,
    nombreGenerico VARCHAR(50) NULL,
	nombreComercial VARCHAR(50) NULL,
	estado CHAR(1) NULL,-- 0:descontinuado,1:prueba,2:Activo
	dosis VARCHAR(80) NULL,
	indicacion VARCHAR(180) NULL,
    idPresentacion INT NOT NULL,
    idLaboratorio INT NOT NULL,
    
    FOREIGN KEY (idPresentacion) REFERENCES Presentacion(id),
    FOREIGN KEY (idLaboratorio) REFERENCES Laboratorio(id)
);

DROP TABLE IF EXISTS Diabetes;
CREATE TABLE Diabetes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tipo VARCHAR(50) NOT NULL UNIQUE,
    detalle VARCHAR(100)
);

DROP TABLE IF EXISTS Alergia;
CREATE TABLE Alergia (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE
);

DROP TABLE IF EXISTS Departamento;
CREATE TABLE Departamento (
  id INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=26;

DROP TABLE IF EXISTS Provincia;
CREATE TABLE Provincia (
  id INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(50) NOT NULL,
  idDepartamento INT NOT NULL,
  
  FOREIGN KEY (idDepartamento) REFERENCES Departamento(id)
) ENGINE=InnoDB AUTO_INCREMENT=194;

DROP TABLE IF EXISTS Distrito;
CREATE TABLE Distrito (
  id INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(50) NOT NULL,
  idProvincia INT NOT NULL,
  
  FOREIGN KEY (idProvincia) REFERENCES Provincia(id)
) ENGINE=InnoDB AUTO_INCREMENT=1833;

DROP TABLE IF EXISTS Parentesco;
CREATE TABLE Parentesco(
    id INT AUTO_INCREMENT PRIMARY KEY,
    valor VARCHAR(20) NOT NULL UNIQUE
);

DROP TABLE IF EXISTS Paciente;
CREATE TABLE Paciente(
	id INT AUTO_INCREMENT PRIMARY KEY,
	condicion CHAR(1) NOT NULL CHECK(condicion IN('0','1','2')) DEFAULT '0',-- Regular, retirado, fallecido
	aPaterno VARCHAR(25) NOT NULL,
	aMaterno VARCHAR(25) NOT NULL,
	nombres VARCHAR(50) NOT NULL,
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
	centroTrabajo VARCHAR(40) NULL,
    asegurado BOOL DEFAULT FALSE,
    idCiaSeguro INT NULL,
	numeroCarnet VARCHAR(10) NULL UNIQUE,
	contacto VARCHAR(50) NULL,
    idParentesco INT NULL,
	telefonoContacto VARCHAR(20) NULL,
	celularContacto VARCHAR(20) NULL,
	perfil VARCHAR(200) NULL,
	antecedentesClinicos VARCHAR(150) NULL,
	antecedentesFamiliares VARCHAR(150) NULL,
	idOcupacion INT NOT NULL,
	presionArterial CHAR(3) NOT NULL CHECK ( presionArterial IN('0','1','2') ) DEFAULT '1',
	campoVisual VARCHAR(6) NULL,
	email VARCHAR(80) NULL,
    diabetico BOOL DEFAULT FALSE,
    idDiabetes INT NULL,
    alergico BOOL DEFAULT FALSE,
    fechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    fechaActualizacion DATETIME ON UPDATE CURRENT_TIMESTAMP,
    
    FOREIGN KEY (idDepartamento) REFERENCES Departamento(id),
    FOREIGN KEY (idProvincia) REFERENCES Provincia(id),
    FOREIGN KEY (idDistrito) REFERENCES Distrito(id),
    FOREIGN KEY (idCiaSeguro) REFERENCES CiaSeguro(id),
    FOREIGN KEY (idParentesco) REFERENCES Parentesco(id),
	FOREIGN KEY (idOcupacion) REFERENCES Ocupacion(id),
    FOREIGN KEY (idDiabetes) REFERENCES Diabetes(id)
    
);

DROP TABLE IF EXISTS DetalleAlergia;
CREATE TABLE DetalleAlergia (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idAlergia INT NOT NULL,
    idPaciente INT NOT NULL,
    reacciones VARCHAR(200),
    
    FOREIGN KEY (idAlergia) REFERENCES Alergia(id),
    FOREIGN KEY (idPaciente) REFERENCES Paciente(id)
    
);

DROP TABLE IF EXISTS Consulta;
CREATE TABLE Consulta(
	id INT AUTO_INCREMENT PRIMARY KEY,
	numeroConsulta VARCHAR(7) UNIQUE,
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
    fechaConsulta DATETIME DEFAULT CURRENT_TIMESTAMP,
    fechaActualizacion DATETIME ON UPDATE CURRENT_TIMESTAMP,
    
    FOREIGN KEY (idCie) REFERENCES CIE(id),
    FOREIGN KEY (idUsuario) REFERENCES Usuario(id),
	FOREIGN KEY (idPaciente) REFERENCES Paciente(id)
);

DROP TABLE IF EXISTS DetalleExamen;
CREATE TABLE DetalleExamen (
    id INT AUTO_INCREMENT PRIMARY KEY ,
	idConsulta INT NOT NULL,
    idExamenLab INT NOT NULL,
    detalle VARCHAR(255),
    resultado VARCHAR(500),
    fechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    fechaResultado DATETIME ON UPDATE CURRENT_TIMESTAMP,
    
    FOREIGN KEY (idConsulta) REFERENCES Consulta(id),
    FOREIGN KEY (idExamenLab) REFERENCES ExamenLaboratorio(id)
);

DROP TABLE IF EXISTS DetalleProcedimiento;
CREATE TABLE DetalleProcedimiento(
    id INT AUTO_INCREMENT PRIMARY KEY ,
	idConsulta INT NOT NULL,
    idProcedimiento INT NOT NULL,
    detalle VARCHAR(255),
    indicacion VARCHAR(255),
    resultado VARCHAR(500),
    imagenes BOOL DEFAULT FALSE,
    directorio VARCHAR(500),
    fechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    fechaResultado DATETIME ON UPDATE CURRENT_TIMESTAMP,
    
    FOREIGN KEY (idConsulta) REFERENCES Consulta(id),
    FOREIGN KEY (idProcedimiento) REFERENCES Procedimiento(id)
);

DROP TABLE IF EXISTS MedidaLente;
CREATE TABLE MedidaLente(
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
    
    FOREIGN KEY (idConsulta) REFERENCES Consulta(id)
);

DROP TABLE IF EXISTS Medicacion;
CREATE TABLE Medicacion(
	id INT AUTO_INCREMENT PRIMARY KEY,
    idConsulta INT NOT NULL,
	idMedicamento INT NOT NULL,
	dosis VARCHAR(80) NOT NULL,
	indicacion VARCHAR(300) NULL,
    ordenMedica VARCHAR(500) NULL,
    
    FOREIGN KEY (idConsulta) REFERENCES Consulta(id),
    FOREIGN KEY (idMedicamento) REFERENCES Medicamento(id)
);