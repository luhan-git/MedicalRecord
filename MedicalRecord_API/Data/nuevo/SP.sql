USE dbhistorias;
-- Usuario
DELIMITER $
DROP PROCEDURE IF EXISTS sp_InsertUsuario;
CREATE PROCEDURE sp_InsertUsuario(
  IN nombre VARCHAR(50),
  IN correo VARCHAR(50),
  IN clave VARCHAR(250),
  IN cargo VARCHAR(30),
  IN especialidad VARCHAR(30),
  IN nroColMedico VARCHAR(6)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;
    INSERT INTO Usuario (nombre,correo,clave,cargo,especialidad,nroColMedico)
    VALUES (nombre,correo,clave,cargo,especialidad,nroColMedico);
    COMMIT;
END$
DELIMITER ;

DELIMITER $
DROP PROCEDURE IF EXISTS sp_UpdateUsuario;
CREATE PROCEDURE sp_UpdateUsuario(
  IN idUpdate INT,
  IN nombre VARCHAR(50),
  IN correo VARCHAR(50),
  IN cargo VARCHAR(30),
  IN especialidad VARCHAR(30),
  IN nroColMedico VARCHAR(6),
  IN activo BOOL
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;
    UPDATE  Usuario SET nombre=nombre,correo=correo,cargo=cargo,
    especialidad=especialidad,nroColMedico=nroColmedico=nroColMedico,
    activo=activo where id=id_pdate;
    COMMIT;
END$
DELIMITER ;

-- CIE
DELIMITER $
DROP PROCEDURE IF EXISTS sp_InsertCie;
CREATE PROCEDURE sp_InsertCie(
  IN codigo VARCHAR(5),
  IN enfermedad VARCHAR(120)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;
    START TRANSACTION;
    INSERT INTO Cie (codigo, enfermedad) VALUES (codigo,enfermedad);
    COMMIT;
END$
DELIMITER ;

DELIMITER $
DROP PROCEDURE IF EXISTS sp_UpdateCie;
CREATE PROCEDURE sp_UpdateCie(
  IN idUpdate int,
  IN codigo VARCHAR(5),
  IN enfermedad VARCHAR(20)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;
    START TRANSACTION;
    update Cie set codigo=codigo,enfermedad=enfermedad where id=id_update;
    COMMIT;
END$
DELIMITER ;

-- CIA SEGURO --- MIO 
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
    VALUES(nombre, abreviatura);

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
    SET nombre = nombre,
        abreviatura = abreviatura
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
        ROLLBACK;
        SET id = -1;
    END;

    START TRANSACTION;

    INSERT INTO Directorio (nombre, representante, telefono, celular, email, direccion)
    VALUES (nombre, representante, telefono, celular, email, direccion);

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
    SET nombre = nombre,
        representante = representante,
        telefono = telefono,
        celular = celular,
        email = email,
        direccion = direccion,
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
        ROLLBACK;
        SET id = -1;
    END;

    START TRANSACTION;

    INSERT INTO Procedimiento (nombre, abreviatura) 
    VALUES (nombre, abreviatura);

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
    SET nombre = nombre,
        abreviatura = abreviatura
    WHERE id = idUpdate;

    COMMIT;
END$
DELIMITER ;

-- CAMPO VISUAL
-- NO HAY NINGUN PROCEDIMIENTO PARA ESO - LO REVISO MAS ADELANTE

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
        ROLLBACK;
    END;

    START TRANSACTION;

    INSERT INTO Ocupacion (nombre, detalle)
    VALUES (nombre, detalle);
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
    SET nombre = nombre,
        detalle = detalle
    WHERE id = idUpdate;

    COMMIT;
END$
DELIMITER ;