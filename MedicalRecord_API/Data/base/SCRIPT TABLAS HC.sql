USE [BDHISTORIAS]
GO
/**ESTA TABLA DEBEMOS USARLA CUANDO VAMOS A IMPLEMENTAR EL MODULO DE CITAS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgendaCitas](
	[id_cita] [int] IDENTITY(1,1) NOT NULL,
	[id_paciente] [int] NOT NULL,
	[fch_cita] [datetime] NOT NULL,
	[hra_cira] [VARCHAR](12) NOT NULL,
	[motivo] [VARCHAR](50) NULL,
	[id_medico] [int] NOT NULL,
	[tipo_paci] [char](1) NOT NULL,
	[tipo_cita] [char](1) NOT NULL,
	[estado] [char](1) NOT NULL,
	[monto] [numeric](12, 2) NULL
) ON [SECONDARY]
GO
/**EL CAMPO DE ESTA TABLA FUE INGRESADO DIRECTAMENTE EN PACIENTE POR ESO YA NO SE USA
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CampoVisual](
	[IDPAC] [bigint] NULL,
	[CAMPO_VIS] [nVARCHAR](6) NULL
) ON [SECONDARY]
GO
/**ESTA TABLA YA LA USAMOS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CiaSeguros](
	[id_cia] [int] IDENTITY(1,1) NOT NULL,
	[nombre_cia] [VARCHAR](50) NOT NULL,
	[nemo_cia] [VARCHAR](20) NULL
) ON [SECONDARY]
GO
/**ESTA TABLA YA LA USAMOS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CIE](
	[id_cie] [int] IDENTITY(1,1) NOT NULL,
	[codcie] [VARCHAR](5) NOT NULL,
	[enfermedad] [VARCHAR](120) NOT NULL
) ON [SECONDARY]
GO
/**ESTA TABLA YA LA USAMOS PERO HAY UNOS CAMPOS QUE NO SE CONSIDERARON 
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consulta](
	[id_consulta] [int] IDENTITY(1,1) NOT NULL,
	[nro_consulta] [int] NOT NULL,
	[id_paciente] [int] NOT NULL,
	[fch_consulta] [datetime] NOT NULL,
	[motivo] [VARCHAR](80) NOT NULL,
	[enf_actual] [VARCHAR](800) NULL,
	[davsc] [VARCHAR](10) NULL,
	[iavsc] [VARCHAR](10) NULL,
	[davcc] [VARCHAR](10) NULL,
	[iavcc] [VARCHAR](10) NULL,
	[dpio] [VARCHAR](10) NULL,
	[ipio] [VARCHAR](10) NULL,
	[diagnostico] [VARCHAR](200) NULL,
	[sp] [VARCHAR](80) NULL,
	[detaExam] [VARCHAR](40) NULL,
	[valorK] [VARCHAR](80) NULL,
	[shimer] [VARCHAR](10) NULL,
	[atiendeProE] [VARCHAR](180) NULL,
	[notaProE] [VARCHAR](120) NULL,
	[id_medico] [int] NULL,
	[examOcular] [VARCHAR](400) NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[id_consulta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [SECONDARY]
) ON [SECONDARY]
GO
/**ESTA TABLA NO LA USAMOS (NO CE PARA QUE SIRVE EXACAMENTE)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiagCIE](
	[id_consulta] [int] NULL,
	[id_cie] [int] NULL
) ON [SECONDARY]
GO
/**ESTA TABLA YA LA USAMOS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directorio](
	[id_directorio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [VARCHAR](80) NULL,
	[repre] [VARCHAR](80) NULL,
	[fono] [VARCHAR](40) NULL,
	[celular] [VARCHAR](40) NULL,
	[email] [VARCHAR](80) NULL,
	[direccion] [VARCHAR](180) NULL,
	[estado] [VARCHAR](1) NULL
) ON [SECONDARY]
GO
/**ESTA TABLA YA LA USAMOS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamenesLaboratorio](
	[id_exam] [int] IDENTITY(1,1) NOT NULL,
	[nombre_exam] [VARCHAR](50) NOT NULL,
	[nemo_exam] [VARCHAR](20) NULL
) ON [SECONDARY]
GO
/**ESTA TABLA NO LA USAMOS PERO ES PARA EL MODULO DE CITAS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HorarioConsultas](
	[id_paciente] [int] NOT NULL,
	[fch_Cita] [VARCHAR](10) NULL,
	[hra_Cita] [VARCHAR](10) NULL,
	[fch_Consulta] [VARCHAR](10) NULL,
	[hra_Consulta] [VARCHAR](10) NULL,
	[id_Consulta] [int] NULL,
	[estado] [VARCHAR](1) NOT NULL,
	[observa] [VARCHAR](300) NULL
) ON [SECONDARY]
GO
/**ESTA TABLA LA INCLUIMOS EN EL DETALLE DE EXAMENES DE LABORATORIO (YA NO USAR ESTA TABLA)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[imagenes](
	[id_imagen] [int] IDENTITY(1,1) NOT NULL,
	[id_consulta] [int] NULL,
	[name_imagen] [VARCHAR](20) NULL,
	[desc_imagen] [VARCHAR](100) NULL,
	[fech_imagen] [VARCHAR](10) NULL,
	[foto_imagen] [image] NULL
) ON [SECONDARY] TEXTIMAGE_ON [SECONDARY]
GO
/**ESTA TABLA LA USAMOS COMO DETALLE ENTRE LOS EXAMENES DE LABORATORIO Y LA CONSULTA
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndicaExamenes](
	[id_consulta] [int] NULL,
	[id_examen] [int] NULL,
	[fch_resulExam] [datetime] NULL,
	[observaExam] [VARCHAR](200) NULL
) ON [SECONDARY]
GO
/**ESTA TABLA NO SE PARA QUE SE USA (NO LA USAMOS)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformesPaciente](
	[id_info] [int] IDENTITY(1,1) NOT NULL,
	[nro_info] [int] NOT NULL,
	[id_paciente] [int] NOT NULL,
	[fch_info] [datetime] NOT NULL,
	[informe] [nVARCHAR](max) NULL,
 CONSTRAINT [PK_InfoPaciente] PRIMARY KEY CLUSTERED 
(
	[id_info] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [SECONDARY]
) ON [SECONDARY] TEXTIMAGE_ON [SECONDARY]
GO
/**ESTA TABLA HACE REFENRECIA A LOS LABORATORIO (YA LA USAMOS)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lineas](
	[id_linea] [int] IDENTITY(1,1) NOT NULL,
	[nombre_linea] [VARCHAR](40) NOT NULL,
	[nemo_linea] [VARCHAR](4) NULL
) ON [SECONDARY]
GO
/**ESTA TABLA YA LA USAMOS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicacion](
	[id_consulta] [int] NULL,
	[id_medicamento] [int] NULL,
	[dosis] [VARCHAR](80) NULL,
	[indicacion] [VARCHAR](300) NULL
) ON [SECONDARY]
GO
/**ESTA TABLA YA LA USAMOS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicamentos](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[cod_articulo] [VARCHAR](7) NULL,
	[id_linea] [int] NOT NULL,
	[id_sunidad] [int] NOT NULL,
	[name_comercial] [VARCHAR](50) NULL,
	[name_generico] [VARCHAR](50) NULL,
	[id_tipo] [tinyint] NULL,
	[estado] [VARCHAR](1) NULL,
	[dosis] [VARCHAR](80) NULL,
	[indicacion] [VARCHAR](180) NULL
) ON [SECONDARY]
GO
/**ESTA TABLA LA UNIFICAMOS EN LA TABLA USUARIO ASI QUE YA ESTA LISTA
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[id_medico] [int] IDENTITY(1,1) NOT NULL,
	[nombre_med] [VARCHAR](50) NOT NULL,
	[espe_med] [VARCHAR](30) NULL,
	[nro_cmed] [VARCHAR](6) NULL,
	[estado] [char](1) NULL
) ON [SECONDARY]
GO
/**ESTA TABLA YA ESTA
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedidaLentes](
	[id_consulta] [int] NULL,
	[idpaciente] [int] NOT NULL,
	[OISPHL] [nVARCHAR](6) NULL,
	[OICYSL] [nVARCHAR](6) NULL,
	[OIAXIL] [nVARCHAR](6) NULL,
	[ODSPHL] [nVARCHAR](6) NULL,
	[ODCYSL] [nVARCHAR](6) NULL,
	[ODAXIL] [nVARCHAR](6) NULL,
	[PDL] [nVARCHAR](3) NULL,
	[OBSL] [nVARCHAR](120) NULL,
	[OISPHC] [nVARCHAR](6) NULL,
	[OICYSC] [nVARCHAR](6) NULL,
	[OIAXIC] [nVARCHAR](6) NULL,
	[ODSPHC] [nVARCHAR](6) NULL,
	[ODCYSC] [nVARCHAR](6) NULL,
	[ODAXIC] [nVARCHAR](6) NULL,
	[PDC] [nVARCHAR](3) NULL,
	[OBSC] [nVARCHAR](120) NULL,
	[ODAV] [VARCHAR](6) NULL,
	[OIAV] [VARCHAR](6) NULL,
	[atencion] [char](1) NULL,
	[observaOpt] [VARCHAR](180) NULL,
	[condi] [char](1) NULL
) ON [SECONDARY]
GO
/** ESTA TABLA YA ESTA
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ocupacion](
	[id_ocupa] [int] NOT NULL,
	[nombre_ocupa] [VARCHAR](60) NULL,
	[detalle_ocupa] [VARCHAR](20) NULL
) ON [SECONDARY]
GO
/** ESTOS CAMPOS FUERON REGISTRADOS DIRECTAMENTE EN LA CONSULTA YA QUE ALLI PERTENECE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesVarias](
	[id_consulta] [int] NULL,
	[idpaciente] [int] NOT NULL,
	[atencion] [VARCHAR](180) NULL,
	[orden] [VARCHAR](800) NULL,
	[observa] [VARCHAR](120) NULL
) ON [SECONDARY]
GO
/**ESTA TABLA YA ESTA
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paciente](
	[idpaciente] [int] IDENTITY(1,1) NOT NULL,
	[nhisto] [VARCHAR](7) NULL,
	[fching] [datetime] NOT NULL,
	[condicion] [char](1) NOT NULL,
	[apaterno] [VARCHAR](25) NOT NULL,
	[amaterno] [VARCHAR](25) NOT NULL,
	[nombres] [VARCHAR](50) NOT NULL,
	[tipdoc] [char](1) NOT NULL,
	[nrodocu] [VARCHAR](12) NULL,
	[fchnac] [datetime] NOT NULL,
	[sexo] [char](1) NOT NULL,
	[estcivil] [char](1) NOT NULL,
	[gruposa] [VARCHAR](10) NULL,
	[nacion] [char](1) NOT NULL,
	[procede] [VARCHAR](60) NULL,
	[iddepa] [int] NOT NULL,
	[idprov] [int] NOT NULL,
	[iddist] [int] NOT NULL,
	[direcc] [VARCHAR](60) NULL,
	[idocupa] [int] NULL,
	[telcasa] [VARCHAR](20) NULL,
	[centrab] [VARCHAR](40) NULL,
	[celular] [VARCHAR](20) NULL,
	[asegu] [char](1) NOT NULL,
	[ncarnet] [VARCHAR](10) NULL,
	[ciasegu] [int] NULL,
	[contacto] [VARCHAR](60) NULL,
	[idparen] [int] NULL,
	[telcon] [VARCHAR](20) NULL,
	[celcon] [VARCHAR](20) NULL,
	[perfil] [VARCHAR](200) NULL,
	[anteclinic] [VARCHAR](160) NULL,
	[antefam] [VARCHAR](160) NULL,
	[historia_c] [nVARCHAR](max) NULL,
	[edad] [VARCHAR](3) NULL,
	[lugar_nac] [VARCHAR](20) NULL,
	[ocupacion] [VARCHAR](25) NULL,
	[hipertenso] [char](1) NULL,
	[diabetes] [char](1) NULL,
	[tipoDiabetes] [VARCHAR](20) NULL,
	[alergico] [char](1) NULL,
	[tipoAlergia] [VARCHAR](25) NULL,
	[CV] [VARCHAR](6) NULL,
	[id_medico] [int] NULL,
	[email] [VARCHAR](80) NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[idpaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [SECONDARY]
) ON [SECONDARY] TEXTIMAGE_ON [SECONDARY]
GO
/** ESTA TABLA YA ESTA Y ES PARA LA PRESENTACION DE MEDICOS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presentaciones](
	[id_presenta] [int] IDENTITY(1,1) NOT NULL,
	[nombre_prese] [VARCHAR](30) NOT NULL,
	[nemo_prese] [VARCHAR](4) NOT NULL
) ON [SECONDARY]
GO
/** ESTA TABLA YA ESTA INCLUIDA
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcedEspeciales](
	[id_consulta] [int] NOT NULL,
	[id_proce] [int] NOT NULL,
	[fch_resulProce] [datetime] NULL,
	[observa] [VARCHAR](800) NULL,
	[imagenes] [char](1) NULL,
	[ubicacion] [VARCHAR](160) NULL
) ON [SECONDARY]
GO
/** ESTA TABLA YA ESTA INCLUIDA
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Procedimientos](
	[id_proce] [int] IDENTITY(1,1) NOT NULL,
	[nombre_proce] [VARCHAR](50) NOT NULL,
	[nemo_proce] [VARCHAR](20) NULL
) ON [SECONDARY]
GO
/** ESTA TABLA YA ESTA
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UBICACION](
	[id_ubica] [int] NOT NULL,
	[tab_tipreg] [int] NOT NULL,
	[tab_codreg] [char](6) NOT NULL,
	[tab_nombre] [VARCHAR](30) NULL,
	[tab_codrela] [char](6) NULL
) ON [SECONDARY]
GO

dotnet ef dbcontext scaffold "Server=localhost;Database=dbhistorias;User=root;Password=123456;" Pomelo.EntityFrameworkCore.MySql -o Models --force
