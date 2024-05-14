CREATE DATABASE DBHISTORIAS;
USE DBHISTORIAS;

CREATE TABLE Usuario (
    id INT AUTO_INCREMENT PRIMARY KEY,
    usuario VARCHAR(16) NOT NULL,
    correo VARCHAR(50) NOT NULL,
    clave VARCHAR(250) NOT NULL,
    activo BIT DEFAULT 1,
    feCHARegistro TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    ultimaSesion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    CONSTRAINT UQ_USUARIO_Usuario UNIQUE(usuario),
    CONSTRAINT UQ_USUARIO_Correo UNIQUE(correo)
);

CREATE TABLE Ubicacion (
	idUbica INT AUTO_INCREMENT  PRIMARY KEY,
	tipReg INT NOT NULL,
	codReg CHAR(6) NOT NULL,
	nombre VARCHAR(30) NULL,
	codRela CHAR(6) NULL
);

CREATE TABLE Medicos (
	idMedico INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	especialidad VARCHAR(30) NULL,
	nroColMedico VARCHAR(6) NULL,
	estado BOOL DEFAULT TRUE
);

CREATE TABLE Laboratorio (
	idLaboratorio INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(40) NOT NULL,
	abrev VARCHAR(4) NULL
);

CREATE TABLE Presentaciones (
	idPresentacion INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(30) NOT NULL,
	abrev VARCHAR(4) NULL
);

CREATE TABLE CIE (
	idCIE INT AUTO_INCREMENT PRIMARY KEY,
	codigo VARCHAR(5) NOT NULL,
	enfermedad VARCHAR(120) NOT NULL
);

CREATE TABLE ExamenesLaboratorio (
	idExamenLab INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	abrev VARCHAR(20) NULL
);

CREATE TABLE Procedimientos (
	idProcedimiento INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	abrev VARCHAR(20) NULL
);

CREATE TABLE CiaSeguros (
	idCiaSeguro INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	abrev VARCHAR(20) NULL
);

CREATE TABLE Directorio (
	idDirectorio INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(80) NOT NULL,
	repre VARCHAR(80) NULL,
	fono VARCHAR(40) NULL,
	celular VARCHAR(40) NULL,
	email VARCHAR(80) NULL,
	direccion VARCHAR(180) NULL,
	estado BOOL DEFAULT TRUE
);

CREATE TABLE Ocupacion (
	idOcupacion INT AUTO_INCREMENT  PRIMARY KEY,
	nombre VARCHAR(60) NOT NULL,
	detalle VARCHAR(20) NULL
);

CREATE TABLE Medicamentos (
	idMedicamento INT AUTO_INCREMENT PRIMARY KEY,
	codigo VARCHAR(7) NOT NULL,
	nameComercial VARCHAR(50) NULL,
	nameGenerico VARCHAR(50) NULL,
	estado VARCHAR(1) NULL,
	dosis VARCHAR(80) NULL,
	indicacion VARCHAR(180) NULL,
    idSubUnidad INT NOT NULL,--
    idPresentacion INT NOT NULL,
    idLaboratorio INT NOT NULL,
    
    FOREIGN KEY (idPresentacion) REFERENCES Presentaciones(idPresentacion),
    FOREIGN KEY (idLaboratorio) REFERENCES Laboratorio(idLaboratorio)
);

CREATE TABLE Diabetes (
    idDiabetes INT AUTO_INCREMENT PRIMARY KEY,
    tipo VARCHAR(50) NOT NULL,
    descripcion TEXT,
    causas TEXT,
    tratamiento TEXT
);

CREATE TABLE Alergias (
    idAlergia INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    tratamiento TEXT
);

CREATE TABLE Pacientes(
	idpaciente INT AUTO_INCREMENT PRIMARY KEY,
	nhisto VARCHAR(7) NULL,
	fching datetime NOT NULL,
	condicion CHAR(1) NOT NULL,
	apaterno VARCHAR(25) NOT NULL,
	amaterno VARCHAR(25) NOT NULL,
	nombres VARCHAR(50) NOT NULL,
	tipdoc CHAR(1) NOT NULL,
	nrodocu VARCHAR(12) NOT NULL,
	fchnac datetime NOT NULL,
	sexo CHAR(1) NOT NULL,
	estcivil CHAR(1) NOT NULL,
	gruposa VARCHAR(10) NULL,
	nacion CHAR(1) NOT NULL,
	procede VARCHAR(60) NULL,
	idDepa INT NOT NULL,
	idProv INT NOT NULL,
	idDist INT NOT NULL,
	direcc VARCHAR(60) NULL,
	telcasa VARCHAR(20) NULL,
	centrab VARCHAR(40) NULL,
	celular VARCHAR(20) NULL,
	ncarnet VARCHAR(10) NULL,
	contacto VARCHAR(60) NULL,
	telcon VARCHAR(20) NULL,
	celcon VARCHAR(20) NULL,
	perfil VARCHAR(200) NULL,
	anteclinic VARCHAR(160) NULL,
	antefam VARCHAR(160) NULL,
	historia TEXT NULL,
	edad VARCHAR(3) NULL,
	lugarNacimiento VARCHAR(20) NULL,
	ocupacion VARCHAR(25) NULL,
	hipertenso CHAR(1) NULL,
	CV VARCHAR(6) NULL,
	email VARCHAR(80) NULL,
	idCiaSeguro INT NOT NULL,
	idMedico INT NOT NULL,
	idOcupacion INT NULL,
    idDiabetes INT NOT NULL,
    idAlergia INT NOT NULL,
    idParen INT NULL,

    
    FOREIGN KEY (idCiaSeguro) REFERENCES CiaSeguros(idCiaSeguro),
    FOREIGN KEY (idMedico) REFERENCES Medicos(idMedico),
    FOREIGN KEY (idOcupacion) REFERENCES Ocupacion(idOcupacion),
    FOREIGN KEY (idDiabetes) REFERENCES Diabetes(idDiabetes),
    FOREIGN KEY (idAlergia) REFERENCES Alergias(idAlergia)
    
);

CREATE TABLE DetalleAlergia (
    idDetAlergia INT AUTO_INCREMENT PRIMARY KEY,
	gravedad ENUM('Leve', 'Moderada', 'Grave') NOT NULL,
    idPaciente INT NOT NULL,
    idAlergia INT NOT NULL,
    
    FOREIGN KEY (idPaciente) REFERENCES Pacientes(idPaciente),
    FOREIGN KEY (idAlergia) REFERENCES Alergias(idAlergia)
);

CREATE TABLE Consultas(
	idConsulta INT AUTO_INCREMENT PRIMARY KEY,
	nroConsulta INT NOT NULL,
	fchConsulta datetime NOT NULL,
	motivo VARCHAR(80) NOT NULL,
	enfActual VARCHAR(800) NULL,
	davsc VARCHAR(10) NULL,
	iavsc VARCHAR(10) NULL,
	davcc VARCHAR(10) NULL,
	iavcc VARCHAR(10) NULL,
	dpio VARCHAR(10) NULL,
	ipio VARCHAR(10) NULL,
	diagnostico VARCHAR(200) NULL,
	sp VARCHAR(80) NULL,
	detaExam VARCHAR(40) NULL,
	valorK VARCHAR(80) NULL,
	shimer VARCHAR(10) NULL,
	atiendeProE VARCHAR(180) NULL,
	notaProE VARCHAR(120) NULL,
	examOcular VARCHAR(400) NULL,
    idMedico INT NOT NULL,
	idPaciente INT NOT NULL,
    idCiaSeguro INT NOT NULL,
    
	FOREIGN KEY (idMedico) REFERENCES MedicoS(idMedico),
    FOREIGN KEY (idPaciente) REFERENCES Pacientes(idPaciente),
    FOREIGN KEY (idCiaSeguro) REFERENCES CiaSeguros(idCiaSeguro)
);

CREATE TABLE Historial (
	idHistorial INT AUTO_INCREMENT PRIMARY KEY,
    idConsulta INT NOT NULL,
    idPaciente INT NOT NULL,
    
    FOREIGN KEY (idConsulta) REFERENCES Consultas(idConsulta),
	FOREIGN KEY (idPaciente) REFERENCES Pacientes(idPaciente)
);

CREATE TABLE DetalleExamen (
	idConsulta INT NOT NULL,
    idExamenLab INT NOT NULL,
    
    FOREIGN KEY (idConsulta) REFERENCES Consultas(idConsulta),
	FOREIGN KEY (idExamenLab) REFERENCES ExamenesLaboratorio(idExamenLab)
);

CREATE TABLE DetalleProcedimiento(
	idConsulta INT NOT NULL,
    idProcedimiento INT NOT NULL,
    
    FOREIGN KEY (idConsulta) REFERENCES Consultas(idConsulta),
	FOREIGN KEY (idProcedimiento) REFERENCES Procedimientos(idProcedimiento)
);

CREATE TABLE MedidaLentes(
	idMedidaLentes INT AUTO_INCREMENT  PRIMARY KEY,
	OISPHL VARCHAR(6) NULL,
	OICYSL VARCHAR(6) NULL,
	OIAXIL VARCHAR(6) NULL,
	ODSPHL VARCHAR(6) NULL,
	ODCYSL VARCHAR(6) NULL,
	ODAXIL VARCHAR(6) NULL,
	PDL VARCHAR(3) NULL,
	OBSL VARCHAR(120) NULL,
	OISPHC VARCHAR(6) NULL,
	OICYSC VARCHAR(6) NULL,
	OIAXIC VARCHAR(6) NULL,
	ODSPHC VARCHAR(6) NULL,
	ODCYSC VARCHAR(6) NULL,
	ODAXIC VARCHAR(6) NULL,
	PDC VARCHAR(3) NULL,
	OBSC VARCHAR(120) NULL,
	ODAV VARCHAR(6) NULL,
	OIAV VARCHAR(6) NULL,
	atencion CHAR(1) NULL,
	observaOpt VARCHAR(180) NULL,
	condi CHAR(1) NULL,
	idConsulta INT NOT NULL,
    
    FOREIGN KEY (idConsulta) REFERENCES Consultas(idConsulta)
);

CREATE TABLE Medicaciones(
	idMedicaciones INT AUTO_INCREMENT PRIMARY KEY,
	dosis VARCHAR(80) NOT NULL,
	indicacion VARCHAR(300) NULL,
	idConsulta INT NOT NULL,
	idMedicamento INT NOT NULL,
    
    FOREIGN KEY (idConsulta) REFERENCES Consultas(idConsulta),
    FOREIGN KEY (idMedicamento) REFERENCES Medicamentos(idMedicamento)
);

CREATE TABLE OrdenesVarias(
	idConsulta INT AUTO_INCREMENT PRIMARY KEY,
	atencion VARCHAR(180) NULL,
	orden VARCHAR(800) NULL,
	observa VARCHAR(120) NULL,
	idPaciente INT NOT NULL,
    
    FOREIGN KEY (idPaciente) REFERENCES Pacientes(idPaciente)
);

CREATE TABLE AgendaCitas(
	idCita INT AUTO_INCREMENT  PRIMARY KEY,
	fchCita datetime NOT NULL,
	hraCita VARCHAR(12) NOT NULL,
	motivo VARCHAR(50) NULL,
	tipoPaciente CHAR(1) NOT NULL,
	tipoCita CHAR(1) NOT NULL,
	estado CHAR(1) NOT NULL,
	monto numeric(12, 2) NULL,
	idMedico INT NOT NULL,
	idPaciente INT NOT NULL,
    
    FOREIGN KEY (idMedico) REFERENCES Medicos(idMedico),
    FOREIGN KEY (idPaciente) REFERENCES Pacientes(idPaciente)
);