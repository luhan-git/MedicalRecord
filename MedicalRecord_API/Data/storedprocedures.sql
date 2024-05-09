CREATE PROCEDURE sp_crearmedico(
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