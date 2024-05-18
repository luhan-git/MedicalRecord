-- Usuarios
use dbhistorias;
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

    INSERT INTO Usuario (nombre,correo,clave,cargo,especialidad,nroColMedico) VALUES (nombre,correo,clave,cargo,especialidad,nroColMedico);
    COMMIT;
END;
DELIMITER ;
DELIMITER $
DROP PROCEDURE IF EXISTS sp_UpdateUsuario;
CREATE PROCEDURE sp_UpdateUsuario(
  IN id_update INT,
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
    UPDATE  Usuario SET nombre=nombre,correo=correo,clave=clave,cargo=cargo,especialidad=especialidad,nroColMedico=nroColmedico=nroColMedico
    where id=id_update;
    COMMIT;
END;
DELIMITER ;

-- Cie
DELIMITER /
CREATE PROCEDURE InsertCie(
  IN codcie VARCHAR(5),
  IN enfermedad VARCHAR(20),
  OUT id_cie INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SELECT -1;
    END;

    START TRANSACTION;
    INSERT INTO Cie (codcie, enfermedad) VALUES (codcie,enfermedad);
    set id_cie=LAST_INSERT_ID();
    COMMIT;
END;
CREATE PROCEDURE UpdateCie(
  IN id_cie_update int,
  IN codcie VARCHAR(5),
  IN enfermedad VARCHAR(20)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SELECT -1;
    END;

    START TRANSACTION;
    update Cie set codcie=codcie,enfermedad=enfermedad where id_cie=id_cie_update;
    COMMIT;
END;

DELIMITER;
-- CIA SEGUROS
DELIMITER //

CREATE PROCEDURE InsertCia_sp(
    IN p_nombre_cia VARCHAR(50),
    IN p_nemo_cia VARCHAR(20),
    OUT p_id_cia INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_id_cia = -1;
        ROLLBACK;
    END;

    START TRANSACTION;

    INSERT INTO CiaSeguros(nombre_cia, nemo_cia) 
    VALUES(p_nombre_cia, p_nemo_cia);

    SET p_id_cia = LAST_INSERT_ID();

    COMMIT;
END//

DELIMITER ;

DELIMITER //

CREATE PROCEDURE UpdateCIA_sp(
    IN p_id_cia INT,
    IN p_nombre_cia VARCHAR(50),
    IN p_nemo_cia VARCHAR(20)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;

    UPDATE CiaSeguros
    SET nombre_cia = p_nombre_cia,
        nemo_cia = p_nemo_cia
    WHERE id_cia = p_id_cia;

    COMMIT;
END//

DELIMITER ;


-- DIRECTORIO
DELIMITER //

CREATE PROCEDURE InsertDirectorio_sp(
    IN p_nombre VARCHAR(80),
    IN p_repre VARCHAR(80),
    IN p_fono VARCHAR(40),
    IN p_celular VARCHAR(40),
    IN p_email VARCHAR(80),
    IN p_direccion VARCHAR(180),
    IN p_estado CHAR(1),
    OUT p_id_directorio INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET p_id_directorio = -1;
    END;

    START TRANSACTION;

    INSERT INTO Directorio (nombre, repre, fono, celular, email, direccion, estado)
    VALUES (p_nombre, p_repre, p_fono, p_celular, p_email, p_direccion, p_estado);

    SET p_id_directorio = LAST_INSERT_ID();

    COMMIT;
END//

DELIMITER ;

DELIMITER //

CREATE PROCEDURE UpdateDirectorio_sp(
    IN p_id_directorio INT,
    IN p_nombre VARCHAR(80),
    IN p_repre VARCHAR(80),
    IN p_fono VARCHAR(40),
    IN p_celular VARCHAR(40),
    IN p_email VARCHAR(80),
    IN p_direccion VARCHAR(180),
    IN p_estado CHAR(1)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;

    UPDATE Directorio
    SET nombre = p_nombre,
        repre = p_repre,
        fono = p_fono,
        celular = p_celular,
        email = p_email,
        direccion = p_direccion,
        estado = p_estado
    WHERE id_directorio = p_id_directorio;

    COMMIT;
END//

DELIMITER ;


-- PROCEDIMIENTOS ESPECIALES
DELIMITER //

CREATE PROCEDURE InsertProcedimiento_sp(
    IN p_nombre_proce VARCHAR(50),
    IN p_nemo_proce VARCHAR(20),
    OUT p_id_proce INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET p_id_proce = -1;
    END;

    START TRANSACTION;

    INSERT INTO Procedimientos (nombre_proce, nemo_proce) 
    VALUES (p_nombre_proce, p_nemo_proce);

    SET p_id_proce = LAST_INSERT_ID();

    COMMIT;
END//

DELIMITER ;

DELIMITER //

CREATE PROCEDURE UpdateProcedimiento_sp(
    IN p_id_proce INT,
    IN p_nombre_proce VARCHAR(50),
    IN p_nemo_proce VARCHAR(20)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;

    UPDATE Procedimientos
    SET nombre_proce = p_nombre_proce,
        nemo_proce = p_nemo_proce
    WHERE id_proce = p_id_proce;

    COMMIT;
END//

DELIMITER ;


-- CAMPO VISUAL
--NO HAY NINGUN PROCEDIMIENTO PARA ESO - LO REVISO MAS ADELANTE






--OCUPACION
DELIMITER //

CREATE PROCEDURE InsertOcupacion_sp(
    IN p_nombre_ocupa VARCHAR(30),
    IN p_detalle_ocupa VARCHAR(15),
    OUT p_id_Ocupa INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;

    INSERT INTO Ocupacion (nombre_ocupa, detalle_ocupa)
    VALUES (p_nombre_ocupa, p_detalle_ocupa);
    SET p_id_Ocupa = LAST_INSERT_ID();

    COMMIT;
END//

DELIMITER ;

DELIMITER //

CREATE PROCEDURE UpdateOcupacion_sp(
    IN p_id_ocupa INT,
    IN p_nombre_ocupa VARCHAR(30),
    IN p_detalle_ocupa VARCHAR(15)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;

    UPDATE Ocupacion
    SET nombre_ocupa = p_nombre_ocupa,
        detalle_ocupa = p_detalle_ocupa
    WHERE id_ocupa = p_id_ocupa;

    COMMIT;
END//

DELIMITER ;

