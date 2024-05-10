-- Medico
CREATE PROCEDURE InsertMedico(
  IN nombre_med VARCHAR(50),
  IN espe_med VARCHAR(20),
  IN nro_cmed VARCHAR(6),
  OUT id_medico INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SELECT -1;
    END;

    START TRANSACTION;

    INSERT INTO medicos (nombre_med, espe_med, nro_cmed) VALUES (nombre_med, espe_med, nro_cmed);
    SET id_medico = LAST_INSERT_ID();

    COMMIT;
END

DELIMITER //
CREATE PROCEDURE UpdateMedico(
  IN id_medico_update int,
  IN nombre_med VARCHAR(50),
  IN espe_med VARCHAR(20),
  IN nro_cmed VARCHAR(6),
  IN estado bool
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SELECT -1;
    END;

    START TRANSACTION;
    UPDATE medicos set nombre_med=nombre_med,espe_med=espe_med,nro_cmed=nro_cmed,estado=estado where id_medico=id_medico_update;
    COMMIT;
END//
DELIMITER ;


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

