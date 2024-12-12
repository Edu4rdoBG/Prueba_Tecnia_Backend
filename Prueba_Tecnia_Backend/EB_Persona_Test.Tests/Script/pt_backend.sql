

DROP TABLE IF EXISTS cat_eb_persona;

CREATE TABLE cat_eb_persona(
    nId INT NOT NULL AUTO_INCREMENT COMMENT 'Id unico del registro',
    sNombre VARCHAR(50) NOT NULL COMMENT 'Nombres de la persona',
    sApellido VARCHAR(50) NOT NULL COMMENT 'Apellidos de la persona',
    sIdentificacion VARCHAR(25) NOT NULL DEFAULT '' COMMENT 'ID de identificacion de la persona',
    sCorreo VARCHAR(50) NOT NULL COMMENT 'Correo electronico',
    sProfesion VARCHAR(50) NOT NULL DEFAULT '' COMMENT 'Profesion que ejerce la persona',
    sEstadoCivil VARCHAR(15) NOT NULL COMMENT 'El estado civil actual de la persona',
    PRIMARY KEY (nId)
) COMMENT 'Tabla de registro de personas.' ;

-- ============ Procedimientos almacenados


DROP PROCEDURE IF EXISTS sp_select_eb_persona;

DELIMITER $$
CREATE PROCEDURE sp_select_eb_persona()
BEGIN
	SELECT
		nId,
		sNombre, 
        sApellido, 
        sIdentificacion, 
        sCorreo, 
        sProfesion, 
        sEstadoCivil 
	  FROM cat_eb_persona;
END $$
DELIMITER ;


-- ====================


DROP PROCEDURE IF EXISTS sp_insert_eb_persona;

DELIMITER $$
CREATE PROCEDURE sp_insert_eb_persona(
    IN CksNombre VARCHAR(50),
    IN CksApellido VARCHAR(50),
    IN CksIdentificacion VARCHAR(25),
    IN CksCorreo VARCHAR(50),
    IN CksProfesion VARCHAR(50),
    IN CksEstadoCivil VARCHAR(15)
)
BEGIN
    INSERT INTO cat_eb_persona (
        sNombre, 
        sApellido, 
        sIdentificacion, 
        sCorreo, 
        sProfesion, 
        sEstadoCivil
    ) VALUES (
        CksNombre, 
        CksApellido, 
        CksIdentificacion, 
        CksCorreo, 
        CksProfesion, 
        CksEstadoCivil
    );
    Select LAST_INSERT_ID() as nId;
END $$
DELIMITER ;

-- =================


DROP PROCEDURE IF EXISTS sp_update_eb_persona;

DELIMITER $$
CREATE PROCEDURE sp_update_eb_persona(
    IN CknId INT,
    IN CksNombre VARCHAR(50),
    IN CksApellido VARCHAR(50),
    IN CksIdentificacion VARCHAR(25),
    IN CksCorreo VARCHAR(50),
    IN CksProfesion VARCHAR(50),
    IN CksEstadoCivil VARCHAR(15)
)
BEGIN
    UPDATE cat_eb_persona
    SET
        sNombre = CksNombre,
        sApellido = CksApellido,
        sIdentificacion = CksIdentificacion,
        sCorreo = CksCorreo,
        sProfesion = CksProfesion,
        sEstadoCivil = CksEstadoCivil
    WHERE
        nId = CknId;
    
    Select ROW_COUNT() As nFila;
END $$
DELIMITER ;


-- ============== 


DROP PROCEDURE IF EXISTS sp_delete_eb_persona;

DELIMITER $$
CREATE PROCEDURE sp_delete_eb_persona(
    IN CknId INT
)
BEGIN
	DECLARE _nExist INT DEFAULT 0;
    Select Count(nId) Into _nExist From cat_eb_persona Where nId = CknId;
    
    IF _nExist > 0 THEN
		DELETE FROM cat_eb_persona
		WHERE nId = CknId;
        
		Select Count(nId) As nFila From cat_eb_persona Where nId = CknId;
	ELSE 
		Select -1 As nFila;
    END IF;
END $$
DELIMITER ;
