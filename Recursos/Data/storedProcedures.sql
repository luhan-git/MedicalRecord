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
  IN nroColMedico VARCHAR(6),
  IN rol VARCHAR(20)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;
    INSERT INTO Usuario (nombre,correo,clave,cargo,especialidad,nroColMedico,rol)
    VALUES (nombre,correo,clave,cargo,especialidad,nroColMedico,rol);
    COMMIT;
END$
DELIMITER ;

DELIMITER $
DROP PROCEDURE IF EXISTS sp_UpdateUsuario;
CREATE PROCEDURE sp_UpdateUsuario(
  IN idUpdate INT,
  IN nombre VARCHAR(50),
  IN correo VARCHAR(50),
  IN clave  VARCHAR(250),
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
    UPDATE  Usuario SET nombre=nombre,correo=correo,clave=clave,cargo=cargo,
    especialidad=especialidad,nroColMedico=nroColmedico,
    activo=activo where id=idUpdate;
    COMMIT;
END$
DELIMITER ;

-- CIE
DELIMITER $
DROP PROCEDURE IF EXISTS sp_InsertCie;
CREATE PROCEDURE sp_InsertCie(
  IN codigo VARCHAR(5),
  IN enfermedad VARCHAR(50)
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
    update Cie set codigo=codigo,enfermedad=enfermedad where id=idUpdate;
    COMMIT;
END$
DELIMITER ;
-- ALERGIA
DELIMITER $
DROP PROCEDURE IF EXISTS sp_InsertAlergia;
CREATE PROCEDURE sp_InsertAlergia(
    IN nombre VARCHAR(20)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;
    START TRANSACTION;
    INSERT INTO Alergia (nombre) VALUES (nombre);
    COMMIT;
END$
DELIMITER ;
DELIMITER $
DROP PROCEDURE IF EXISTS sp_UpdateAlergia;
CREATE PROCEDURE sp_UpdateAlergia(
    IN idUpdate INT,
    IN nombre VARCHAR(50)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;
    START TRANSACTION;
    UPDATE Alergia SET nombre =nombre where id=idUpdate;
    COMMIT;
END$
DELIMITER ;
-- revisar

-- CIA SEGURO
DELIMITER $
DROP PROCEDURE IF EXISTS sp_InsertCiaSeguro;
CREATE PROCEDURE sp_InsertCiaSeguro(
    IN nombre VARCHAR(50),
    IN abreviatura VARCHAR(20)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;
    START TRANSACTION;
    INSERT INTO CiaSeguro(nombre, abreviatura)VALUES(nombre, abreviatura);
    COMMIT;
END$
DELIMITER ;
DELIMITER $
DROP PROCEDURE IF EXISTS sp_UpdateCiaSeguro;
CREATE PROCEDURE sp_UpdateCiaSeguro(
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
    SET nombre = nombre,abreviatura = abreviatura WHERE id = idUpdate;
    COMMIT;
END$
DELIMITER ;
