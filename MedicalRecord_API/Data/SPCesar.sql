USE dbhistorias;

-- CIA SEGURO
DELIMITER $
DROP PROCEDURE IF EXISTS InsertCiaSeguro_sp;
CREATE PROCEDURE InsertCiaSeguro_sp(
    IN nombre VARCHAR(50),
    IN abreviatura VARCHAR(20),
    OUT id INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET id = -1;
        ROLLBACK;
    END;

    START TRANSACTION;

    INSERT INTO CiaSeguro(nombre, abreviatura) 
    VALUES(TRIM(nombre), TRIM(abreviatura));

    SET id = LAST_INSERT_ID();

    COMMIT;
END$
DELIMITER ;

DELIMITER $
DROP PROCEDURE IF EXISTS UpdateCiaSeguro_sp;
CREATE PROCEDURE UpdateCiaSeguro_sp(
    IN idUpdate INT,
    IN nombre VARCHAR(50),
    IN abreviatura VARCHAR(20)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;

    UPDATE CiaSeguro
    SET nombre = TRIM(nombre),
        abreviatura = TRIM(abreviatura)
    WHERE id = idUpdate;

    COMMIT;
END$
DELIMITER ;

-- DIRECTORIO
DELIMITER $
DROP PROCEDURE IF EXISTS InsertDirectorio_sp;
CREATE PROCEDURE InsertDirectorio_sp(
    IN nombre VARCHAR(80),
    IN representante VARCHAR(80),
    IN telefono VARCHAR(40),
    IN celular VARCHAR(40),
    IN email VARCHAR(80),
    IN direccion VARCHAR(180),
    OUT id INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET id = -1;
        ROLLBACK;
    END;

    START TRANSACTION;

    INSERT INTO Directorio (nombre, representante, telefono, celular, email, direccion)
    VALUES (TRIM(nombre), TRIM(representante), telefono, celular, TRIM(email), TRIM(direccion));

    SET id = LAST_INSERT_ID();

    COMMIT;
END$
DELIMITER ;

DELIMITER $
DROP PROCEDURE IF EXISTS UpdateDirectorio_sp;
CREATE PROCEDURE UpdateDirectorio_sp(
    IN idUpdate INT,
    IN nombre VARCHAR(80),
    IN representante VARCHAR(80),
    IN telefono VARCHAR(40),
    IN celular VARCHAR(40),
    IN email VARCHAR(80),
    IN direccion VARCHAR(180),
    IN estado BOOL
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;

    UPDATE Directorio
    SET nombre = TRIM(nombre),
        representante = TRIM(representante),
        telefono = telefono,
        celular = celular,
        email = TRIM(email),
        direccion = TRIM(direccion),
        estado = estado
    WHERE id = idUpdate;

    COMMIT;
END$
DELIMITER ;

-- PROCEDIMIENTO
DELIMITER $
DROP PROCEDURE IF EXISTS InsertProcedimiento_sp;
CREATE PROCEDURE InsertProcedimiento_sp(
    IN nombre VARCHAR(50),
    IN abreviatura VARCHAR(20),
    OUT id INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET id = -1;
        ROLLBACK;
    END;

    START TRANSACTION;

    INSERT INTO Procedimiento (nombre, abreviatura) 
    VALUES (TRIM(nombre), TRIM(abreviatura));

    SET id = LAST_INSERT_ID();

    COMMIT;
END$
DELIMITER ;

DELIMITER $
DROP PROCEDURE IF EXISTS UpdateProcedimiento_sp;
CREATE PROCEDURE UpdateProcedimiento_sp(
    IN idUpdate INT,
    IN nombre VARCHAR(50),
    IN abreviatura VARCHAR(20)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;

    UPDATE Procedimientos
    SET nombre = TRIM(nombre),
        abreviatura = TRIM(abreviatura)
    WHERE id = idUpdate;

    COMMIT;
END$
DELIMITER ;

-- CAMPO VISUAL
-- NO HAY NINGUN PROCEDIMIENTO PARA ESO

-- OCUPACION
DELIMITER $
DROP PROCEDURE IF EXISTS InsertOcupacion_sp;
CREATE PROCEDURE InsertOcupacion_sp(
    IN nombre VARCHAR(30),
    IN detalle VARCHAR(50),
    OUT id INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET id = -1;
        ROLLBACK;
    END;

    START TRANSACTION;

    INSERT INTO Ocupacion (nombre, detalle)
    VALUES (TRIM(nombre), TRIM(detalle));
    SET id = LAST_INSERT_ID();

    COMMIT;
END$
DELIMITER ;

DELIMITER $
DROP PROCEDURE IF EXISTS UpdateOcupacion_sp;
CREATE PROCEDURE UpdateOcupacion_sp(
    IN idUpdate INT,
    IN nombre VARCHAR(30),
    IN detalle VARCHAR(50)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;

    UPDATE Ocupacion
    SET nombre = TRIM(nombre),
        detalle = TRIM(detalle)
    WHERE id = idUpdate;

    COMMIT;
END$
DELIMITER ;

-- ALERGIA
DELIMITER $
DROP PROCEDURE IF EXISTS InsertAlergia_sp;
CREATE PROCEDURE InsertAlergia_sp(
    IN nombre VARCHAR(50),
    OUT id INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET id = -1;
        ROLLBACK;
    END;

    START TRANSACTION;

    INSERT INTO Alergia (nombre)
    VALUES (TRIM(nombre));
    SET id = LAST_INSERT_ID();

    COMMIT;
END$
DELIMITER ;

DELIMITER $
DROP PROCEDURE IF EXISTS UpdateAlergia_sp;
CREATE PROCEDURE UpdateAlergia_sp(
    IN idUpdate INT,
    IN nombre VARCHAR(50)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;
    
    UPDATE Alergia SET nombre = TRIM(nombre)
    WHERE id = idUpdate;

    COMMIT;
END$
DELIMITER ;

-- DETALLE ALERGIA
DELIMITER $
DROP PROCEDURE IF EXISTS InsertDetalleAlergia_sp;
CREATE PROCEDURE InsertDetalleAlergia_sp(
    IN idAlergia INT,
    IN idPaciente INT,
    OUT id INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET id = -1;
        ROLLBACK;
    END;

    START TRANSACTION;

    INSERT INTO DetalleAlergia (idAlergia, idPaciente)
    VALUES (idAlergia, idPaciente);
    SET id = LAST_INSERT_ID();

    COMMIT;
END$
DELIMITER ;

-- PACIENTE
DROP PROCEDURE IF EXISTS InsertPaciente_sp;
DELIMITER $
CREATE PROCEDURE InsertPaciente_sp(
    IN condicion CHAR(1),
    IN aPaterno VARCHAR(25),
    IN aMaterno VARCHAR(25),
    IN nombres VARCHAR(50),
    IN tipoDocumento CHAR(1),
    IN numeroDocumento VARCHAR(12),
    IN fechaNacimiento DATETIME,
    IN edad VARCHAR(3),
    IN sexo CHAR(1),
    IN estadoCivil CHAR(1),
    IN grupoSanguineo VARCHAR(10),
    IN nacionalidad CHAR(1),
    IN idDepartamento INT,
    IN idProvincia INT,
    IN idDistrito INT,
    IN direccion VARCHAR(60),
    IN telefono VARCHAR(20),
    IN celular VARCHAR(20),
    IN centroTrabajo VARCHAR(40),
    IN asegurado BOOL,
    IN idCiaSeguro INT,
    IN numeroCarnet VARCHAR(10),
    IN contacto VARCHAR(50),
    IN idParentesco INT,
    IN telefonoContacto VARCHAR(20),
    IN celularContacto VARCHAR(20),
    IN perfil VARCHAR(200),
    IN antecedentesClinicos VARCHAR(150),
    IN antecedentesFamiliares VARCHAR(150),
    IN idOcupacion INT,
    IN presionArterial CHAR(3),
    IN campoVisual VARCHAR(6),
    IN email VARCHAR(80),
    IN diabetico BOOL,
    IN idDiabetes INT,
    IN alergico BOOL,
    OUT Id INT
)
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET id = -1;
        ROLLBACK;
	END;
    
    START TRANSACTION;
    
    INSERT INTO PACIENTE
    (condicion, aPaterno, aMaterno, nombres, tipoDocumento, numeroDocumento, fechaNacimiento, edad, sexo,
    estadoCivil, grupoSanguineo, nacionalidad, idDepartamento, idProvincia, idDistrito, direccion, telefono, celular,
    centroTrabajo, asegurado, idCiaSeguro, numeroCarnet, contacto, idParentesco, telefonoContacto, celularContacto,
    perfil, antecedentesClinicos, antecedentesFamiliares, idOcupacion, presionArterial, campoVisual, email,
    diabetico, idDiabetes, alergico)
    VALUES (condicion, TRIM(aPaterno), TRIM(aMaterno), TRIM(nombres), tipoDocumento, numeroDocumento, fechaNacimiento, edad, sexo,
    estadoCivil, grupoSanguineo, nacionalidad, idDepartamento, idProvincia, idDistrito, TRIM(direccion), telefono, celular,
    TRIM(centroTrabajo), asegurado, idCiaSeguro, numeroCarnet, TRIM(contacto), idParentesco, telefonoContacto, celularContacto,
    TRIM(perfil), TRIM(antecedentesClinicos), TRIM(antecedentesFamiliares), idOcupacion, presionArterial, campoVisual, TRIM(email),
    diabetico, idDiabetes, alergico);
    
    SET id = LAST_INSERT_ID();
    
    COMMIT;
END$
DELIMITER ;

DROP PROCEDURE IF EXISTS UpdatePaciente_sp;
DELIMITER $
CREATE PROCEDURE UpdatePaciente_sp(
    IN condicion CHAR(1),
    IN tipoDocumento CHAR(1),
    IN numeroDocumento VARCHAR(12),
    IN estadoCivil CHAR(1),
    IN idDepartamento INT,
    IN idProvincia INT,
    IN idDistrito INT,
    IN direccion VARCHAR(60),
    IN telefono VARCHAR(20),
    IN celular VARCHAR(20),
    IN centroTrabajo VARCHAR(40),
    IN asegurado BOOL,
    IN idCiaSeguro INT,
    IN numeroCarnet VARCHAR(10),
    IN contacto VARCHAR(50),
    IN idParentesco INT,
    IN telefonoContacto VARCHAR(20),
    IN celularContacto VARCHAR(20),
    IN perfil VARCHAR(200),
    IN antecedentesClinicos VARCHAR(150),
    IN antecedentesFamiliares VARCHAR(150),
    IN idOcupacion INT,
    IN presionArterial CHAR(3),
    IN campoVisual VARCHAR(6),
    IN email VARCHAR(80),
    IN diabetico BOOL,
    IN idDiabetes INT,
    IN alergico BOOL,
    OUT idUpdate INT
)
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
	END;
    
    START TRANSACTION;
    
	UPDATE PACIENTE 
	SET 
		condicion = TRIM(condicion),
		tipoDocumento = tipoDocumento,
		numeroDocumento = numeroDocumento,
		estadoCivil = estadoCivil,
		idDepartamento = idDepartamento,
		idProvincia = idProvincia,
		idDistrito = idDistrito,
		direccion = TRIM(direccion),
		telefono = telefono,
		celular = celular,
		centroTrabajo = TRIM(centroTrabajo),
		asegurado = asegurado,
		idCiaSeguro = idCiaSeguro,
		numeroCarnet = numeroCarnet,
		contacto = contacto,
		idParentesco = idParentesco,
		telefonoContacto = telefonoContacto,
		celularContacto = celularContacto,
		perfil = TRIM(perfil),
		antecedentesClinicos = TRIM(antecedentesClinicos),
		antecedentesFamiliares = TRIM(antecedentesFamiliares),
		idOcupacion = idOcupacion,
		presionArterial = presionArterial,
		campoVisual = campoVisual,
		email = TRIM(email),
		diabetico = diabetico,
		idDiabetes = idDiabetes,
		alergico = alergico
	WHERE
		id = idUpdate;
			
			COMMIT;
END$
DELIMITER ;