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
    UPDATE  Usuario SET nombre=TRIM(nombre),correo=TRIM(correo),cargo=TRIM(cargo),
    especialidad=TRIM(especialidad),nroColMedico=TRIM(nroColmedico),
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
    INSERT INTO Cie (codigo, enfermedad) VALUES (TRIM(codigo),TRIM(enfermedad));
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
    update Cie set codigo=TRIM(codigo),enfermedad=TRIM(enfermedad) where id=id_update;
    COMMIT;
END$
DELIMITER ;