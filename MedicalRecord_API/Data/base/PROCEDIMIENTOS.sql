USE [BDHISTORIAS]
GO
/****** Object:  StoredProcedure [dbo].[_BuscaConsultaMedidasxfecha_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[_BuscaConsultaMedidasxfecha_sp] 
                 (@fch_consulta	datetime)
AS
SELECT NRO_CONSULTA, fechaC=convert(char(10),fch_consulta,103), nombre = P.apaterno + ' ' + P.amaterno + ' ' + P.nombres, 
       P.nrodocu, P.nhisto,  M.*,
	   Estado = ( SELECT CASE
			WHEN M.atencion = 0 or M.atencion is null THEN ' - . - '
			WHEN M.atencion = 1 THEN 'ATENDIDO'
			WHEN M.atencion = 2 THEN 'C/PEDIDO'
			WHEN M.atencion = 3 THEN 'POR ATENDER'
			WHEN M.atencion = 3 THEN 'NO ADQUIRIO'
	     	        END AS sEstado)
FROM MedidaLentes M inner join consulta C on M.id_consulta = C.id_consulta 
                    inner join paciente P on C.id_paciente = P.idpaciente 
WHERE C.fch_consulta = convert(datetime,convert(char(10),@fch_consulta,103),103) and condi = 0
ORDER BY fch_consulta DESC, P.apaterno, P.amaterno
GO
/****** Object:  StoredProcedure [dbo].[_BuscaConsultaMedidasxPaciente_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[_BuscaConsultaMedidasxPaciente_sp]
                 (@id_peciente	int)
AS
SELECT NRO_CONSULTA, fechaC=convert(char(10),fch_consulta,103), nombre = P.apaterno + ' ' + P.amaterno + ' ' + P.nombres, 
       P.nrodocu, P.nhisto,  M.*,
	   Estado = ( SELECT CASE
			WHEN M.atencion = 0 or M.atencion is null THEN ' - . - '
			WHEN M.atencion = 1 THEN 'ATENDIDO'
			WHEN M.atencion = 2 THEN 'C/PEDIDO'
			WHEN M.atencion = 3 THEN 'POR ATENDER'
			WHEN M.atencion = 3 THEN 'NO ADQUIRIO'
	     	        END AS sEstado)
FROM MedidaLentes M inner join consulta C on M.id_consulta = C.id_consulta 
                    inner join paciente P on C.id_paciente = P.idpaciente
WHERE id_paciente = @id_peciente and condi = 0
ORDER BY fch_consulta DESC
GO
/****** Object:  StoredProcedure [dbo].[_BuscaShimerEnConsulta_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[_BuscaShimerEnConsulta_sp]
                 (@id_peciente	int)
AS
SELECT id_consulta, NRO_CONSULTA, fch_consulta, shimer 
FROM consulta 
WHERE id_paciente = @id_peciente AND SHIMER IS NOT NULL
ORDER BY fch_consulta DESC
GO
/****** Object:  StoredProcedure [dbo].[_DeleteCia_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROC [dbo].[_DeleteCia_sp]
@id_cia [int]
AS
BEGIN TRAN
DELETE CiaSeguros
WHERE id_cia = @id_cia
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
	RETURN
   END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[_DeleteConsulta_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[_DeleteConsulta_sp]
       (@id_consulta	int)
AS
BEGIN TRAN
DELETE [Consulta]
WHERE [id_consulta] = @id_consulta
IF (@@error<>0)
     BEGIN
           ROLLBACK
     END
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[_DeleteDiagCIE_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_DeleteDiagCIE_sp]
(	@id_consulta [int])
AS
BEGIN TRAN
DELETE [DiagCIE] 
WHERE [id_consulta]= @id_consulta
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
   END
COMMIT TRANSACTION


GO
/****** Object:  StoredProcedure [dbo].[_DeleteDirectorio_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROC [dbo].[_DeleteDirectorio_sp]
@id_directorio [int]
AS
BEGIN TRAN
DELETE Directorio
WHERE id_directorio = @id_directorio
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
	RETURN
   END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[_DeleteExamenLab_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROC [dbo].[_DeleteExamenLab_sp]
@id_exam [int]
AS
BEGIN TRAN
DELETE ExamenesLaboratorio 
WHERE id_exam = @id_exam
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
	RETURN
   END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[_DeleteIndicaExamenes_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[_DeleteIndicaExamenes_sp]
(	@id_consulta [int])
AS
BEGIN TRAN
DELETE [IndicaExamenes] 
WHERE [id_consulta]=@id_consulta
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
   END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[_DeleteLinea_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---sp_helptext _DeleteLinea_sp
CREATE  PROC [dbo].[_DeleteLinea_sp]
@id_Linea [int]
AS
BEGIN TRAN
DELETE Lineas
WHERE id_Linea = @id_Linea
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
	RETURN
   END
COMMIT TRANSACTION



GO
/****** Object:  StoredProcedure [dbo].[_DeleteMedicacion_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_DeleteMedicacion_sp]
(	@id_consulta [int])
AS
BEGIN TRAN
DELETE [Medicacion] 
WHERE [id_consulta]=@id_consulta
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
   END
COMMIT TRANSACTION


GO
/****** Object:  StoredProcedure [dbo].[_DeleteMedicamento_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[_DeleteMedicamento_sp]
@id_medicamento [int]
AS
BEGIN TRAN
DELETE Medicamentos 
WHERE id_articulo= @id_medicamento
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
	RETURN
   END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[_DeleteMedicos_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROC [dbo].[_DeleteMedicos_sp]
@id_medico [int]
AS
BEGIN TRAN
DELETE Medicos
WHERE id_medico = @id_medico
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
	RETURN
   END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[_DeleteMedidaLentes_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROCEDURE [dbo].[_DeleteMedidaLentes_sp]
       (@id_consulta	int)
AS
BEGIN TRAN
DELETE MedidaLentes
WHERE [id_consulta] = @id_consulta
IF (@@error<>0)
     BEGIN
           ROLLBACK
     END
COMMIT TRAN

GO
/****** Object:  StoredProcedure [dbo].[_DeleteOcupacion_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[_DeleteOcupacion_sp]
     ( @id_ocupa	int )
AS
BEGIN TRAN
DELETE [Ocupacion]
WHERE [id_ocupa] = @id_ocupa
IF (@@error<>0)
     BEGIN
           ROLLBACK
           RETURN
     END
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[_DeleteOrdenesVarias_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create  PROCEDURE [dbo].[_DeleteOrdenesVarias_sp]
       (@id_consulta	int)
AS
BEGIN TRAN
DELETE OrdenesVarias
WHERE [id_consulta] = @id_consulta
IF (@@error<>0)
     BEGIN
           ROLLBACK
     END
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[_DeletePaciente_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[_DeletePaciente_sp]
       (@idpaciente	int)
AS
BEGIN TRAN
DELETE [Paciente]
WHERE [idpaciente] = @idpaciente
IF (@@error<>0)
     BEGIN
           ROLLBACK
     END
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[_DeleteProcedEspeciales_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_DeleteProcedEspeciales_sp]
(	@id_consulta [int])
AS
BEGIN TRAN
DELETE [ProcedEspeciales] 
WHERE [id_consulta]=@id_consulta
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
   END
COMMIT TRANSACTION



GO
/****** Object:  StoredProcedure [dbo].[_DeleteProcedimiento_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[_DeleteProcedimiento_sp]
@id_proce [int]
AS
BEGIN TRAN
DELETE Procedimientos
WHERE id_proce = @id_proce
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
	RETURN
   END
COMMIT TRANSACTION
GO


/****** Object:  StoredProcedure [dbo].[_InsertConsulta_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[_InsertConsulta_sp]
       (@id_paciente 	int,
		@nro_consulta	int,
		@fch_consulta	datetime,
		@motivo 	varchar (80),
		@sp     	varchar (80),
		@enf_actual varchar (800),
		@valorK		varchar (80),
		@shimer		varchar (10),
		@davsc   	varchar (10),
		@iavsc 		varchar (10),
		@davcc 		varchar (10),
		@iavcc 		varchar (10),
		@dpio	    varchar (10),
		@ipio	    varchar (10),
		@diagnostico 	varchar (200),
		@detaExam 	varchar (40),
		@atiendePro varchar (180),
		@notaPro 	varchar (120),
		@id_medico  int,
		@exam_ocular varchar (400))
AS
BEGIN TRAN
INSERT INTO Consulta ([id_paciente], [nro_consulta], [fch_consulta], [motivo], [sp], [enf_actual], [valorK], [shimer], [davsc], [iavsc],
		              [davcc], [iavcc], [dpio], [ipio], [diagnostico], [detaExam], [atiendeProE], [notaProE], [id_medico], [examOcular] )
             VALUES ( @id_paciente, @nro_consulta, @fch_consulta, @motivo, @sp, @enf_actual, @valorK, @shimer, @davsc, @iavsc, 
                      @davcc, @iavcc, @dpio, @ipio, @diagnostico, @detaExam, @atiendePro, @notaPro, @id_medico, @exam_ocular)
IF (@@error<>0)
     BEGIN
           ROLLBACK
           RETURN (-1)
     END
COMMIT TRAN
RETURN (@@identity)
GO
/****** Object:  StoredProcedure [dbo].[_InsertDiagCIE_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[_InsertDiagCIE_sp]
(	@id_consulta [int],
        @id_cie [int])
AS
BEGIN TRAN
INSERT [DiagCIE] ([id_consulta], [id_cie])
        VALUES ( @id_consulta, @id_cie) 
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
   END
COMMIT TRANSACTION

GO

/****** Object:  StoredProcedure [dbo].[_InsertExamenLab_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[_InsertExamenLab_sp]
@nombre_exam	varchar(50),
@nemo_exam	varchar(20),
@id_exam 	int OUTPUT
AS
BEGIN TRAN
INSERT INTO ExamenesLaboratorio (nombre_exam, nemo_exam) 
VALUES( @nombre_exam, @nemo_exam) 
IF @@error <> 0
   BEGIN
	SET @id_exam = -1
	ROLLBACK TRAN
	RETURN
   END
COMMIT TRANSACTION
SET @id_exam = @@identity
GO
/****** Object:  StoredProcedure [dbo].[_InsertHorarioConsultas_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[_InsertHorarioConsultas_sp]
(	@id_paciente [int],
	@fch_Cita [varchar] (10),
	@hra_Cita [varchar] (10),
	@fch_Consulta [varchar] (10),
	@hra_Consulta [varchar] (10),
	@id_Consulta [int],
	@estado [varchar] (1),
	@observa [varchar] (300))
AS
BEGIN TRAN
INSERT [HorarioConsultas] ([id_paciente], [fch_Cita], [hra_Cita], [fch_Consulta], [hra_Consulta],
                           [id_Consulta], [estado], [observa])
        VALUES ( @id_paciente, @fch_Cita, @hra_Cita, @fch_Consulta, @hra_Consulta, 
                 @id_Consulta, @estado, @observa) 
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
   END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[_InsertImagen_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---select * from imagenes

CREATE PROCEDURE [dbo].[_InsertImagen_sp]
                 (@id_consulta	int,
                  @name_imagen	varchar(20),
                  @desc_imagen  varchar(100),
                  @fech_imagen	varchar(10))  
AS
BEGIN TRAN
INSERT INTO imagenes(id_consulta,name_imagen,desc_imagen,fech_imagen)
              VALUES(@id_consulta,@name_imagen,@desc_imagen,@fech_imagen)
IF @@error<>0
   BEGIN
   ROLLBACK TRAN
   END
COMMIT TRAN
RETURN @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[_InsertIndicacionExamenes_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create  PROCEDURE [dbo].[_InsertIndicacionExamenes_sp]
(	@id_consulta [int],
	@id_examen [int],
	@fch_resulExam [datetime],
	@observaExam [varchar] (200))
AS
BEGIN TRAN
INSERT [IndicaExamenes] ([id_consulta], [id_examen], [fch_resulExam], [observaExam])
        VALUES ( @id_consulta, @id_examen, @fch_resulExam, @observaExam) 
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
   END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[_InsertInformePacientes_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[_InsertInformePacientes_sp]
       (@id_paciente 	int,
		@nro_info	int,
		@fch_info	datetime,
		@informe	nvarchar (max))
AS
BEGIN TRAN
INSERT INTO InformesPaciente ([id_paciente], [nro_info], [fch_info], [informe])
             VALUES ( @id_paciente, @nro_info, @fch_info, @informe )
IF (@@error<>0)
     BEGIN
           ROLLBACK
           RETURN (-1)
     END
COMMIT TRAN
RETURN (@@identity)
GO
/****** Object:  StoredProcedure [dbo].[_InsertLinea_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---sp_helptext _InsertLinea_sp
CREATE  PROC [dbo].[_InsertLinea_sp]
@nombre_linea	varchar(40),
@nemo_linea	varchar(4),
@id_Linea 	int OUTPUT
AS
BEGIN TRAN
INSERT INTO Lineas( nombre_linea, nemo_linea) 
VALUES( @nombre_linea, @nemo_linea) 
IF @@error <> 0
   BEGIN
	SET @id_Linea = -1
	ROLLBACK TRAN
	RETURN
   END
COMMIT TRANSACTION
SET @id_Linea = @@identity


GO
/****** Object:  StoredProcedure [dbo].[_InsertMedicacion_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[_InsertMedicacion_sp]
(	@id_consulta [int],
	@id_medicamento [int],
	@dosis [varchar] (80),
	@indicacion [varchar] (300))
AS
BEGIN TRAN
INSERT [Medicacion] ([id_consulta], [id_medicamento], [dosis], [indicacion])
        VALUES ( @id_consulta, @id_medicamento, @dosis, @indicacion) 
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
   END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[_InsertMedicamento_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[_InsertMedicamento_sp]
@cod_articulo	varchar(7),
@name_comercial	varchar(50),
@name_generico	varchar(50),
@id_linea	int,
@id_tipo	tinyint,
@id_sunidad	int, 
@dosis		varchar(80), 
@indicacion	varchar(180),
@estado 	varchar(1)
AS

DECLARE @id_lab	    varchar(3)
DECLARE @correla  	varchar(4)
DECLARE @codi	    varchar(7)

set @id_lab = @id_linea
SET @id_lab = REPLICATE('0', 3 - DATALENGTH(@id_lab)) + @id_lab

--- Obtengo el Maximo Correlativo
SET @correla = (SELECT RTRIM(CAST((ISNULL(MAX(RIGHT(cod_articulo,4)),0) + 1) AS varchar))
	            FROM Medicamentos WHERE LEFT(cod_articulo,3) = @id_lab )
	
---SET @id_linea = REPLICATE('0', 3 - DATALENGTH(@id_linea)) + @id_linea
SET @correla  = REPLICATE('0', 4 - DATALENGTH(@correla)) + @correla
SET @codi = @id_lab + @correla

BEGIN TRAN
INSERT Medicamentos ([cod_articulo],[name_comercial],[name_generico], [id_linea], 
                     [id_tipo], [id_sunidad], [dosis], [indicacion], [estado])
VALUES ( @codi, @name_comercial, @name_generico, @id_linea, 
         @id_tipo, @id_sunidad, @dosis, @indicacion, @estado )
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
	RETURN -1
   END
COMMIT TRANSACTION
RETURN @@identity

GO
/****** Object:  StoredProcedure [dbo].[_InsertMedicos_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[_InsertMedidaLentes_sp]
       (@id_consulta  int,
	    @idpaciente  int,
		@OISPHL    nvarchar(6),
		@OICYSL    nvarchar(6),
		@OIAXIL    nvarchar(6),
		@ODSPHL    nvarchar(6),
		@ODCYSL    nvarchar(6),
		@ODAXIL    nvarchar(6),
		@PDL    nvarchar(3),
		@OBSL    nvarchar(120),
		@ODAV    nvarchar(6),
		@OIAV    nvarchar(6),
		@OISPHC    nvarchar(6),
		@OICYSC    nvarchar(6),
		@OIAXIC    nvarchar(6),
		@ODSPHC    nvarchar(6),
		@ODCYSC    nvarchar(6),
		@ODAXIC    nvarchar(6),
		@PDC    nvarchar(3),
		@OBSC    nvarchar(120),
		@condi    char(1))
AS
BEGIN TRAN
INSERT INTO MedidaLentes ([id_consulta], [idpaciente], [OISPHL], [OICYSL], [OIAXIL], [ODSPHL], [ODCYSL], [ODAXIL], [PDL], [OBSL],
	                      [ODAV], [OIAV], [OISPHC], [OICYSC],	[OIAXIC], [ODSPHC],	[ODCYSC], [ODAXIC], [PDC], [OBSC], [condi] )
             VALUES ( @id_consulta, @idpaciente, @OISPHL,	@OICYSL, @OIAXIL, @ODSPHL,	@ODCYSL, @ODAXIL, @PDL,	@OBSL,
		              @ODAV, @OIAV, @OISPHC, @OICYSC, @OIAXIC, @ODSPHC, @ODCYSC, @ODAXIC, @PDC,	@OBSC, @condi )
IF (@@error<>0)
     BEGIN
           ROLLBACK
           RETURN (-1)
     END
COMMIT TRAN
RETURN (@@identity)
GO

/****** Object:  StoredProcedure [dbo].[_InsertOrdenesVarias_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[_InsertOrdenesVarias_sp]
       (@id_consulta  int,
	    @idpaciente  int,
		@atencion   varchar(180),
		@orden      varchar(800),
		@observa   varchar(120))
AS
BEGIN TRAN
INSERT INTO OrdenesVarias ([id_consulta], [idpaciente], [atencion], [orden], [observa] )
             VALUES ( @id_consulta, @idpaciente, @atencion, @orden, @observa )
IF (@@error<>0)
     BEGIN
           ROLLBACK
           RETURN (-1)
     END
COMMIT TRAN
RETURN (@@identity)
GO
/****** Object:  StoredProcedure [dbo].[_InsertPaciente_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE      PROCEDURE [dbo].[_InsertPaciente_sp]
       (@nhisto		char(7),
		@fching 	datetime,
		@condicion	char(1),
		@apaterno	varchar(25),
		@amaterno	varchar(25),
		@nombres	varchar(60),
		@tipdoc		char(1),
		@nrodocu	char(12),
		@fchnac		datetime,
		@sexo		char(1),
		@estcivil	char(1),
		@gruposa	char(1),
		@nacion		char(1),
		@procede	varchar(60),
		@iddepa		int,
		@idprov		int,
		@iddist		int,
		@direcc		varchar(60),
		@telcasa	varchar(20),
		@celular	varchar(20),
		@idocupa	int,
		@centrab	varchar(40),
		@asegu		char(1),
		@ncarnet	varchar(10),
		@ciaSeguro	int,
		@contacto	varchar(60),
		@idparen	int,
		@telcon		varchar(20),
		@celcon		varchar(20),
		@perfil		varchar(200),
		@antecli    varchar(160),
		@antefam    varchar(160),
		@hipertenso char(1),
        @diabetes   char(1),
        @tipoDiabetes varchar(20),
        @alergico    char(1), 
	    @tipoAlergia varchar(25),
		@cv          varchar(6),
		@ocupacion   varchar(25),
		@email       varchar(80),
		@id_medico	 int)
AS
BEGIN TRAN
INSERT INTO [Paciente]( [nhisto], [fching],[condicion],[apaterno],[amaterno], [nombres], [tipdoc], [nrodocu],[fchnac], [sexo], [estcivil],
                  	[gruposa], [nacion], [procede], [iddepa], [idprov], [iddist], [direcc], [idocupa], [telcasa] , [centrab],  
                  	[celular], [asegu],[ncarnet], [ciasegu],[contacto] , [idparen] , [telcon] , [celcon] , 
					[perfil], [anteclinic],[antefam], [hipertenso], [diabetes],[tipoDiabetes], [alergico],[tipoAlergia], [CV], [ocupacion], [email], [id_medico] )
               VALUES ( @nhisto, @fching, @condicion, @apaterno,@amaterno,@nombres, @tipdoc, @nrodocu, @fchnac,@sexo, @estcivil, 
                  	@gruposa, @nacion, @procede , @iddepa , @idprov, @iddist , @direcc , @idocupa , @telcasa  , @centrab , 
                  	@celular , @asegu, @ncarnet , @ciaSeguro, @contacto  , @idparen  , @telcon  , @celcon ,
	                @perfil , @antecli ,@antefam, @hipertenso, @diabetes, @tipoDiabetes, @alergico, @tipoAlergia, @cv, @ocupacion, @email, @id_medico)
IF (@@error<>0)
     BEGIN
           ROLLBACK
           RETURN (-1)
     END
COMMIT TRAN
RETURN (@@identity)
GO
/****** Object:  StoredProcedure [dbo].[_InsertProcedEspeciales_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[_InsertProcedEspeciales_sp]
(	@id_consulta [int],
	@id_proce [int],
	@fch_resulProce [datetime],
	@observa [varchar](800),
	@imagenes [char](1),
	@ubicacion [varchar](160))
AS
BEGIN TRAN
INSERT [ProcedEspeciales] ([id_consulta], [id_proce], [fch_resulProce], [observa], [imagenes], [ubicacion])
                   VALUES (@id_consulta, @id_proce, @fch_resulProce, @observa, @imagenes, @ubicacion) 
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
   END
COMMIT TRANSACTION
GO

/****** Object:  StoredProcedure [dbo].[_ObtieneCIE_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[_ObtieneCIE_sp]
AS
select * from CIE 
--order by codcie
ORDER BY enfermedad ASC
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneConsultas_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[_ObtieneConsultas_sp]
                 (@id_paciente	int)
AS
SELECT * 
FROM CONSULTA 
WHERE id_paciente= @id_paciente
ORDER BY nro_consulta DESC
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneConsultaxID_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[_ObtieneConsultaxID_sp]
                 (@id_consulta	int) 
AS
select * from consulta where id_consulta=@id_consulta
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneDiagCIE_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[_ObtieneDiagCIE_sp]
                 (@id_consulta	int)
as

select d.*, c.codcie,c.enfermedad
from diagcie d inner join cie c on d.id_cie=c.id_cie
where d.id_consulta=@id_consulta
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneDirectorio_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[_ObtieneDirectorio_sp]
AS
SELECT *
FROM Directorio 
order by nombre asc
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneExamenesIndicados_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[_ObtieneExamenesIndicados_sp]
(	@id_consulta [int])
AS
SELECT P.*,PE.nombre_exam
FROM [IndicaExamenes] P inner join [ExamenesLaboratorio] PE ON P.id_examen=PE.id_exam
WHERE P.id_consulta=@id_consulta
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneFechaHoraServidor_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  PROCEDURE [dbo].[_ObtieneFechaHoraServidor_sp]
                (@datetime	datetime OUTPUT )
AS
SELECT @datetime = GETDATE()

GO
/****** Object:  StoredProcedure [dbo].[_ObtieneImagenes_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_ObtieneImagenes_sp]
                 (@id_consulta	int)
AS
SELECT * FROM imagenes WHERE id_consulta=@id_consulta
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneInformePacientexID_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create  PROCEDURE [dbo].[_ObtieneInformePacientexID_sp]
                 (@id_info	int) 
AS
select * from InformesPaciente where id_info=@id_info
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneInformes_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[_ObtieneInformes_sp]
                 (@id_paciente	int)
AS
SELECT * 
FROM InformesPaciente 
WHERE id_paciente= @id_paciente
ORDER BY nro_info DESC
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneMedicacion_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[_ObtieneMedicacion_sp]
(	@id_consulta [int])
AS
SELECT M.*,Me.cod_articulo, Me.name_generico,
       nombre=(CASE ME.id_tipo WHEN '0' THEN Me.name_comercial ELSE Me.name_generico END)
FROM [Medicacion] M INNER JOIN [Medicamentos] Me ON M.id_medicamento=ME.id_articulo
WHERE M.id_consulta=@id_consulta
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneMedicamentos_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[_ObtieneMedicamentos_sp]
AS
SELECT m.id_articulo,m.cod_articulo,m.name_comercial,m.name_generico,m.id_tipo,
       m.estado,m.id_linea,m.id_sunidad,l.nombre_linea,p.nombre_prese,m.dosis,m.indicacion
FROM medicamentos m inner join lineas l on m.id_linea=l.id_linea
                    inner join presentaciones p on m.id_sunidad=id_presenta
order by name_comercial asc


GO
/****** Object:  StoredProcedure [dbo].[_ObtieneMedidaLentes_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[_ObtieneMedidaLentes_sp]
                 (@id_consulta	int)
AS
SELECT * FROM MedidaLentes WHERE id_consulta=@id_consulta
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneMedidaLentesAnte_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[_ObtieneMedidaLentesAnte_sp]
                 (@id_paciente	int,
				  @fchConsulta	char(10))
AS
SELECT M.*, C.fch_consulta
FROM MedidaLentes M inner join Consulta C on C.id_consulta = M.id_consulta
WHERE idpaciente=@id_paciente and convert(datetime,C.fch_consulta,103) < convert(datetime,@fchConsulta,103)
order by M.id_consulta desc
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneOrdenesVarias_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create PROCEDURE [dbo].[_ObtieneOrdenesVarias_sp]
                 (@id_consulta	int)
AS
SELECT * FROM OrdenesVarias WHERE id_consulta=@id_consulta
GO
/****** Object:  StoredProcedure [dbo].[_ObtienePacientes_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[_ObtienePacientes_sp]
AS
SELECT * FROM PACIENTE ORDER BY nombres ASC
GO
/****** Object:  StoredProcedure [dbo].[_ObtienePacientexHC_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[_ObtienePacientexHC_sp]
                 (@nhisto	int) 
AS
select * from paciente where nhisto=@nhisto
GO
/****** Object:  StoredProcedure [dbo].[_ObtienePacientexID_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_ObtienePacientexID_sp]
                 (@idpaciente	int) 
AS
select * from paciente where idpaciente=@idpaciente
GO
/****** Object:  StoredProcedure [dbo].[_ObtienePacientexNHC_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[_ObtienePacientexNHC_sp]
                 (@nhisto	int) 
AS
select * from paciente where nhisto=@nhisto
GO
/****** Object:  StoredProcedure [dbo].[_ObtienePadronGeneralPacientes_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[_ObtienePadronGeneralPacientes_sp]
AS
SELECT idpaciente, nHisto, Reg=convert(char(10),fching,103), nombre=(apaterno+' '+amaterno+' '+nombres), nrodocu, 
       FNac=convert(char(10),fchnac,103), email=ISNULL(email,''), direcc, telcasa=ISNULL(telcasa,''), celular=ISNULL(celular,''), 
	   ocupacion=ISNULL(ocupacion,''), lugar_nac=ISNULL(lugar_nac,''), edad=ISNULL(edad,''), cv=ISNULL(cv,''), centrab=ISNULL(centrab,''),
TDoc = ( SELECT CASE
		WHEN tipdoc = 0 THEN 'DNI'
		WHEN tipdoc = 1 THEN 'CEX'
		WHEN tipdoc = 3 THEN 'PAS'
		WHEN tipdoc = 3 THEN 'PNA'
	     END AS strTDoc),
Sexop = ( SELECT CASE
		WHEN sexo = 0 THEN 'MASCULINO'
		WHEN sexo = 1 THEN 'FENENINO'
	     END AS strSexop),
Ecivil = ( SELECT CASE
		WHEN estcivil = 0 then 'SOLTERO'
		WHEN estcivil = 1 then 'CASADO'
		WHEN estcivil = 2 then 'VIUDO'
		WHEN estcivil = 3 then 'DIVORCIADO'
		WHEN estcivil = 4 then 'CONVIVIENTE'
	     END AS strEcivil),
GS = ( SELECT CASE
		WHEN gruposa = 0 THEN 'NO INDICA'
		WHEN gruposa = 1 THEN 'O +'
		WHEN gruposa = 2 THEN 'O -'
		WHEN gruposa = 3 THEN 'A +'
		WHEN gruposa = 4 THEN 'A -'
		WHEN gruposa = 5 THEN 'B +'
		WHEN gruposa = 6 THEN 'B -'
		WHEN gruposa = 7 THEN 'AB +'
		WHEN gruposa = 8 THEN 'AB -'
	     END AS strGS),
Seguro = ( SELECT CASE
		WHEN sexo = 0 THEN 'SI'
		WHEN sexo = 1 THEN 'NO'
	     END AS strSeguro), ncarnet=isnull(ncarnet,''),
Condi= ( SELECT CASE
		WHEN condicion = 0 THEN 'REGULAR'
		WHEN condicion = 1 THEN 'RETIRADO'
		WHEN condicion = 2 THEN 'FALLECIDO'
	     END AS strCondi),
Nacional = ( SELECT CASE
		WHEN nacion = 0 THEN 'PERUANA'
		WHEN nacion = 1 THEN 'EXTRANGERA'
	     END AS strNacional), procede,
Dpto=ISNULL((select tab_nombre from UBICACION where id_ubica=P.iddepa),''),
Prov=ISNULL((select tab_nombre from UBICACION where id_ubica=P.idprov),''),
Dist=ISNULL((select tab_nombre from UBICACION where id_ubica=P.iddist),''),
O.nombre_ocupa, S.nombre_cia 
FROM paciente P inner join Ocupacion O on O.id_ocupa = P.idocupa  
                inner join CiaSeguros S on S.id_cia = P.ciasegu 
ORDER BY apaterno, amaterno
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneProcedEspeciales_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_ObtieneProcedEspeciales_sp]
(	@id_consulta [int])
AS
SELECT P.*,PE.nombre_proce
FROM [ProcedEspeciales] P inner join [Procedimientos] PE ON P.id_proce=PE.id_proce
WHERE P.id_consulta=@id_consulta
GO
/****** Object:  StoredProcedure [dbo].[_ObtieneUbicacion_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[_ObtieneUbicacion_sp]
                 (@tiporeg	int,
                  @trela	char(6))
AS
IF @trela = ''
   SELECT *
   FROM [UBICACION]
   WHERE tab_tipreg = @tiporeg
   ORDER BY tab_nombre
ELSE
   SELECT *
   FROM [UBICACION]
   WHERE tab_tipreg = @tiporeg AND tab_codrela = @trela
   ORDER BY tab_nombre

GO
/****** Object:  StoredProcedure [dbo].[_SeleccionaCia_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create    PROC [dbo].[_SeleccionaCia_sp]
@nombre varchar(50)
AS

SELECT id_cia, nombre_cia, nemo_cia,
       'name_cia' = REPLICATE('0', 3 - DATALENGTH(cast(id_cia as varchar))) + cast(id_cia as varchar) + ' - ' + nombre_cia
FROM CiaSeguros
WHERE nombre_cia LIKE @nombre + '%'
GO
/****** Object:  StoredProcedure [dbo].[_SeleccionaCiaxID_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROC [dbo].[_SeleccionaCiaxID_sp]
@id_cia [int]
AS
SELECT *
FROM CiaSeguros
WHERE id_cia = @id_cia
GO
/****** Object:  StoredProcedure [dbo].[_SeleccionaExamenesLab_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create    PROC [dbo].[_SeleccionaExamenesLab_sp]
@nombre varchar(50)
AS
SELECT id_exam, nombre_exam, nemo_exam,
       'name_proce' = REPLICATE('0', 3 - DATALENGTH(cast(id_exam as varchar))) + cast(id_exam as varchar) + ' - ' + nombre_exam
FROM ExamenesLaboratorio
WHERE nombre_exam LIKE @nombre + '%'
GO
/****** Object:  StoredProcedure [dbo].[_SeleccionaLineas_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---sp_helptext _SeleccionaLineas_sp
CREATE    PROC [dbo].[_SeleccionaLineas_sp]
@nombre varchar(40)
AS

SELECT id_linea, nombre_linea, nemo_linea,
       'name_linea' = REPLICATE('0', 3 - DATALENGTH(cast(id_linea as varchar))) + cast(id_linea as varchar) + ' - ' + nombre_linea
FROM Lineas
WHERE nombre_Linea LIKE @nombre + '%'


GO
/****** Object:  StoredProcedure [dbo].[_SeleccionaLineaxID_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---sp_helptext _SeleccionaLineaxID_sp
CREATE  PROC [dbo].[_SeleccionaLineaxID_sp]
@id_Linea [int]
AS
SELECT *
FROM Lineas
WHERE id_Linea = @id_Linea
GO
/****** Object:  StoredProcedure [dbo].[_SeleccionaMedicos_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create    PROC [dbo].[_SeleccionaMedicos_sp]
@nombre varchar(50)
AS

SELECT id_medico, nombre_med, espe_med,
       'name_med' = REPLICATE('0', 3 - DATALENGTH(cast(id_medico as varchar))) + cast(id_medico as varchar) + ' - ' + nombre_med
FROM Medicos
WHERE nombre_med LIKE @nombre + '%'
GO
/****** Object:  StoredProcedure [dbo].[_SeleccionaMedicoxID_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROC [dbo].[_SeleccionaMedicoxID_sp]
@id_medico [int]
AS
SELECT *
FROM Medicos
WHERE id_medico = @id_medico
GO
/****** Object:  StoredProcedure [dbo].[_SeleccionaProcedimiento_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROC [dbo].[_SeleccionaProcedimiento_sp]
@nombre varchar(50)
AS
SELECT id_proce, nombre_proce, nemo_proce,
       'name_proce' = REPLICATE('0', 3 - DATALENGTH(cast(id_proce as varchar))) + cast(id_proce as varchar) + ' - ' + nombre_proce
FROM Procedimientos
WHERE nombre_proce LIKE @nombre + '%'
GO
/****** Object:  StoredProcedure [dbo].[_SeleccionaProcedimientoxID_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[_SeleccionaProcedimientoxID_sp]
@id_proce [int]
AS
SELECT *
FROM Procedimientos
WHERE id_proce = @id_proce
GO
/****** Object:  StoredProcedure [dbo].[_SelectCias_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[_SelectCias_sp]
AS
SELECT  id_cia, nombre_cia, nemo_cia,
       'name_cia' = REPLICATE('0', 3 - DATALENGTH(cast(id_cia as varchar))) + cast(id_cia as varchar) + ' - ' + nombre_cia
FROM CiaSeguros
ORDER BY nombre_cia
GO
/****** Object:  StoredProcedure [dbo].[_SelectExamenesLab_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROC [dbo].[_SelectExamenesLab_sp]
AS
SELECT  id_exam, nombre_exam, nemo_exam,
        cod_proce= REPLICATE('0', 3 - DATALENGTH(cast(id_exam as varchar))) + cast(id_exam as varchar), 
       'name_proce' = REPLICATE('0', 3 - DATALENGTH(cast(id_exam as varchar))) + cast(id_exam as varchar) + ' - ' + nombre_exam
FROM ExamenesLaboratorio 
ORDER BY nombre_exam

GO
/****** Object:  StoredProcedure [dbo].[_SelectLineas_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_SelectLineas_sp]
AS
SELECT  id_linea, nombre_linea, nemo_linea,
       'name_linea' = REPLICATE('0', 3 - DATALENGTH(cast(id_linea as varchar))) + cast(id_linea as varchar) + ' - ' + nombre_linea
FROM Lineas
ORDER BY nombre_linea



GO
/****** Object:  StoredProcedure [dbo].[_SelectMedicos_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROC [dbo].[_SelectMedicos_sp]
AS
SELECT *,
       'name_med' = REPLICATE('0', 3 - DATALENGTH(cast(id_medico as varchar))) + cast(id_medico as varchar) + ' - ' + nombre_med
FROM Medicos
ORDER BY nombre_med
GO
/****** Object:  StoredProcedure [dbo].[_SelectOcupacion_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_SelectOcupacion_sp]
AS
SELECT [id_ocupa], [nombre_ocupa], [detalle_ocupa]
FROM [Ocupacion]
ORDER BY nombre_ocupa asc
GO
/****** Object:  StoredProcedure [dbo].[_SelectPresenta_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create   PROCEDURE [dbo].[_SelectPresenta_sp]
AS
SELECT *
FROM [Presentaciones]
ORDER BY nombre_prese


GO
/****** Object:  StoredProcedure [dbo].[_SelectProcedimiento_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[_SelectProcedimiento_sp]
AS
SELECT  id_proce, nombre_proce, nemo_proce,
        cod_proce= REPLICATE('0', 3 - DATALENGTH(cast(id_proce as varchar))) + cast(id_proce as varchar), 
       'name_proce' = REPLICATE('0', 3 - DATALENGTH(cast(id_proce as varchar))) + cast(id_proce as varchar) + ' - ' + nombre_proce
FROM Procedimientos
ORDER BY nombre_proce

GO
/****** Object:  StoredProcedure [dbo].[_UpdateAtencionMedidaOPT_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[_UpdateAtencionMedidaOPT_sp]
       (@id_consulta   int,
		@atencion      char(1),
		@observaOpt    varchar(180))
AS
BEGIN TRAN
UPDATE MedidaLentes
SET  atencion = @atencion,
     observaOpt = @observaOpt
WHERE [id_consulta] = @id_consulta
IF (@@error<>0)
     BEGIN
           ROLLBACK
     END
COMMIT TRAN
GO

/****** Object:  StoredProcedure [dbo].[_UpdateConsulta_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[_UpdateConsulta_sp]
       (@id_consulta	int,
	    @id_paciente 	int,
	    @nro_consulta	int,
		@fch_consulta	datetime,
		@motivo 	varchar (80),
		@sp     	varchar (80),
		@enf_actual 	varchar (800),
		@valorK		varchar (80),
		@shimer		varchar (10),
		@davsc   	varchar (10),
		@iavsc 		varchar (10),
		@davcc 		varchar (10),
		@iavcc 		varchar (10),
		@dpio	    varchar (10),
		@ipio	    varchar (10),
		@diagnostico 	varchar (200),
		@detaExam 	varchar (40),
		@atiendePro varchar (180),
		@notaPro 	varchar (120),
		@id_medico  int,
		@exam_ocular varchar (400))
AS
BEGIN TRAN
UPDATE [Consulta]
SET     id_paciente=@id_paciente,
		nro_consulta=@nro_consulta,
		fch_consulta=@fch_consulta,
		motivo=@motivo,
		sp=@sp,
		enf_actual=@enf_actual,
		valorK=@valorK,
		shimer=@shimer,
		davsc=@davsc,
		iavsc=@iavsc,
		davcc=@davcc,
		iavcc=@iavcc,
		dpio=@dpio,
		ipio=@ipio,
		diagnostico=@diagnostico,
		detaExam=@detaExam,
		atiendeProE=@atiendePro,
		notaProE=@notaPro,
		id_medico=@id_medico,
		examOcular=@exam_ocular
WHERE [id_consulta] = @id_consulta
IF (@@error<>0)
     BEGIN
           ROLLBACK
     END
COMMIT TRAN
GO

/****** Object:  StoredProcedure [dbo].[_UpdateExamenLab_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   PROC [dbo].[_UpdateExamenLab_sp]
@id_exam 	int, 
@nombre_exam	varchar(50),
@nemo_exam	varchar(20)
AS
BEGIN TRAN
UPDATE ExamenesLaboratorio
SET nombre_exam  = @nombre_exam,
    nemo_exam  = @nemo_exam
WHERE id_exam = @id_exam
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
	RETURN
   END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[_UpdateInformePacientes_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[_UpdateInformePacientes_sp]
       (@id_info	int,
	    @id_paciente 	int,
	    @nro_info	int,
		@fch_info	datetime,
		@informe	varchar (80))
AS
BEGIN TRAN
UPDATE InformesPaciente
SET     id_paciente=@id_paciente,
		nro_info=@nro_info,
		fch_info=@fch_info,
		informe=@informe
WHERE [id_info] = @id_info
IF (@@error<>0)
     BEGIN
           ROLLBACK
     END
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[_UpdateLinea_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[_UpdateLinea_sp]
@id_cia 	int, 
@nombre_cia	varchar(50),
@nemo_cia	varchar(20)
AS
BEGIN TRAN
UPDATE CiaSeguros
SET nombre_cia  = @nombre_cia,
    nemo_cia  = @nemo_cia
WHERE id_cia = @id_cia	
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
	RETURN
   END
COMMIT TRANSACTION

GO
/****** Object:  StoredProcedure [dbo].[_UpdateMedicamento_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[_UpdateMedicamento_sp]
@id_articulo 	int,
@cod_articulo	varchar(7),
@name_comercial	varchar(50),
@name_generico	varchar(50),
@id_linea		int,
@id_tipo		tinyint,
@id_sunidad		int, 
@dosis		    varchar(80), 
@indicacion  	varchar(180),
@estado 		varchar(1)
AS
BEGIN TRAN
UPDATE Medicamentos
SET name_comercial = @name_comercial,	
    name_generico  = @name_generico,	
    id_linea = @id_linea,	
    id_tipo = @id_tipo,	
    id_sunidad = @id_sunidad,
	dosis=@dosis,
	indicacion=@indicacion,
    estado    = @estado
WHERE id_articulo = @id_articulo  
IF @@error <> 0	
   BEGIN
	ROLLBACK TRAN
	RETURN
  END
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[_UpdateMedicos_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[_UpdateMedidaLentes_sp]
       (@id_consulta	int,
	    @idpaciente  int,
		@OISPHL    nvarchar(6),
		@OICYSL    nvarchar(6),
		@OIAXIL    nvarchar(6),
		@ODSPHL    nvarchar(6),
		@ODCYSL    nvarchar(6),
		@ODAXIL    nvarchar(6),
		@PDL    nvarchar(3),
		@OBSL    nvarchar(120),
		@OISPHC    nvarchar(6),
		@OICYSC    nvarchar(6),
		@OIAXIC    nvarchar(6),
		@ODSPHC    nvarchar(6),
		@ODCYSC    nvarchar(6),
		@ODAXIC    nvarchar(6),
		@PDC    nvarchar(3),
		@OBSC    nvarchar(120))
AS
BEGIN TRAN
UPDATE MedidaLentes
SET     idpaciente=@idpaciente,
		OISPHL=@OISPHL,
		OICYSL=@OICYSL,
		OIAXIL=@OIAXIL,
		ODSPHL=@ODSPHL,
		ODCYSL=@ODCYSL,
		ODAXIL=@ODAXIL,
		PDL=@PDL,
		OBSL=@OBSL,
		OISPHC=@OISPHC,
		OICYSC=@OICYSC,
		OIAXIC=@OIAXIC,
		ODSPHC=@ODSPHC,
		ODCYSC=@ODCYSC,
		ODAXIC=@ODAXIC,
		PDC=@PDC,
		OBSC=@OBSC
WHERE [id_consulta] = @id_consulta
IF (@@error<>0)
     BEGIN
           ROLLBACK
     END
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[_UpdateOcupacion_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE  PROCEDURE [dbo].[_UpdateOcupacion_sp]
     ( @id_ocupa	int,
       @nombre_ocupa	varchar(30),
       @detalle_ocupa	varchar(15)
     )
AS
BEGIN TRAN
UPDATE [Ocupacion]
SET [nombre_ocupa] = @nombre_ocupa,
    [detalle_ocupa]= @detalle_ocupa
WHERE [id_ocupa] = @id_ocupa

IF (@@error<>0)
     BEGIN
           ROLLBACK
           RETURN
     END
COMMIT TRAN

GO
/****** Object:  StoredProcedure [dbo].[_UpdateOrdenesVarias_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[_UpdateOrdenesVarias_sp]
       (@id_consulta	int,
	    @idpaciente  int,
		@atencion   varchar(180),
		@orden      varchar(800),
		@observa   varchar(120))
AS
BEGIN TRAN
UPDATE OrdenesVarias
SET     idpaciente=@idpaciente,
		atencion=@atencion,
		orden=@orden,
		observa=@observa
WHERE [id_consulta] = @id_consulta
IF (@@error<>0)
     BEGIN
           ROLLBACK
     END
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[_UpdatePaciente_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE       PROCEDURE [dbo].[_UpdatePaciente_sp]
       (@idpaciente     int,
        @nhisto		char(7),
		@fching 	datetime,
		@condicion	char(1),
		@apaterno	varchar(25),
		@amaterno	varchar(25),
		@nombres	varchar(60),
		@tipdoc		char(1),
		@nrodocu	char(10),
		@fchnac		datetime,
		@sexo		char(1),
		@estcivil	char(1),
		@gruposa	char(1),
		@nacion		char(1),
		@procede	varchar(60),
		@iddepa		int,
		@idprov		int,
		@iddist		int,
		@direcc		varchar(60),
		@telcasa	varchar(20),
		@celular	varchar(20),
		@idocupa	int,
		@centrab	varchar(40),
		@asegu		char(1),
		@ncarnet	varchar(10),
		@ciaSeguro	int,
		@contacto	varchar(60),
		@idparen	int,
		@telcon		varchar(20),
		@celcon		varchar(20),
		@perfil		varchar(200),
		@antecli         varchar(160),
		@antefam        varchar(160),
		@hipertenso char(1),
        @diabetes   char(1),
        @tipoDiabetes varchar(20),
        @alergico    char(1), 
	    @tipoAlergia varchar(25),
		@cv          varchar(6),
		@ocupacion   varchar(25),
		@email       varchar(80),
		@id_medico	 int)
AS
BEGIN TRAN
UPDATE [Paciente]
SET     nhisto = @nhisto,
		fching = @fching,
		condicion=@condicion,
		apaterno=@apaterno,
		amaterno=@amaterno,
		nombres=@nombres,
		tipdoc=@tipdoc,
		nrodocu=@nrodocu,
		fchnac=@fchnac,
		sexo=@sexo,
		estcivil=@estcivil,
		gruposa=@gruposa,
		nacion=@nacion,
		procede=@procede,
		iddepa=@iddepa,
		idprov=@idprov,
		iddist=@iddist,
		direcc=@direcc,
		telcasa=@telcasa,
		celular=@celular,
		idocupa=@idocupa,
		centrab=@centrab,
		asegu=@asegu,
		ncarnet=@ncarnet,
		ciasegu=@ciaSeguro,
		contacto=@contacto,
		idparen=@idparen,
		telcon=@telcon,
		celcon=@celcon,
		perfil=@perfil,
		anteclinic=@antecli,
		antefam=@antefam,
		hipertenso=@hipertenso,
        diabetes=@diabetes,
        tipoDiabetes=@tipoDiabetes,
        alergico=@alergico, 
	    tipoAlergia=@tipoAlergia,
		CV = @cv,
		ocupacion=@ocupacion,
		email = @email,
		id_medico=@id_medico
WHERE [idpaciente] = @idpaciente
IF (@@error<>0)
     BEGIN
           ROLLBACK
     END
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[_UpdateProcedimiento_sp]    Script Date: 1/05/2024 12:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[_UpdateProcedimiento_sp]
@id_proce 	int, 
@nombre_proce	varchar(50),
@nemo_proce	varchar(20)
AS
BEGIN TRAN
UPDATE Procedimientos
SET nombre_proce  = @nombre_proce,
    nemo_proce  = @nemo_proce
WHERE id_proce = @id_proce
IF @@error <> 0
   BEGIN
	ROLLBACK TRAN
	RETURN
   END
COMMIT TRANSACTION
GO
