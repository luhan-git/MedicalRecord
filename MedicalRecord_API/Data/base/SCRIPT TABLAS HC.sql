USE [BDHISTORIAS]
GO
/****** Object:  Table [dbo].[AgendaCitas]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgendaCitas](
	[id_cita] [int] IDENTITY(1,1) NOT NULL,
	[id_paciente] [int] NOT NULL,
	[fch_cita] [datetime] NOT NULL,
	[hra_cira] [varchar](12) NOT NULL,
	[motivo] [varchar](50) NULL,
	[id_medico] [int] NOT NULL,
	[tipo_paci] [char](1) NOT NULL,
	[tipo_cita] [char](1) NOT NULL,
	[estado] [char](1) NOT NULL,
	[monto] [numeric](12, 2) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[CampoVisual]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CampoVisual](
	[IDPAC] [bigint] NULL,
	[CAMPO_VIS] [nvarchar](6) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[CiaSeguros]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CiaSeguros](
	[id_cia] [int] IDENTITY(1,1) NOT NULL,
	[nombre_cia] [varchar](50) NOT NULL,
	[nemo_cia] [varchar](20) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[CIE]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CIE](
	[id_cie] [int] IDENTITY(1,1) NOT NULL,
	[codcie] [varchar](5) NOT NULL,
	[enfermedad] [varchar](120) NOT NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consulta](
	[id_consulta] [int] IDENTITY(1,1) NOT NULL,
	[nro_consulta] [int] NOT NULL,
	[id_paciente] [int] NOT NULL,
	[fch_consulta] [datetime] NOT NULL,
	[motivo] [varchar](80) NOT NULL,
	[enf_actual] [varchar](800) NULL,
	[davsc] [varchar](10) NULL,
	[iavsc] [varchar](10) NULL,
	[davcc] [varchar](10) NULL,
	[iavcc] [varchar](10) NULL,
	[dpio] [varchar](10) NULL,
	[ipio] [varchar](10) NULL,
	[diagnostico] [varchar](200) NULL,
	[sp] [varchar](80) NULL,
	[detaExam] [varchar](40) NULL,
	[valorK] [varchar](80) NULL,
	[shimer] [varchar](10) NULL,
	[atiendeProE] [varchar](180) NULL,
	[notaProE] [varchar](120) NULL,
	[id_medico] [int] NULL,
	[examOcular] [varchar](400) NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[id_consulta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [SECONDARY]
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[DiagCIE]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiagCIE](
	[id_consulta] [int] NULL,
	[id_cie] [int] NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[Directorio]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directorio](
	[id_directorio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](80) NULL,
	[repre] [varchar](80) NULL,
	[fono] [varchar](40) NULL,
	[celular] [varchar](40) NULL,
	[email] [varchar](80) NULL,
	[direccion] [varchar](180) NULL,
	[estado] [varchar](1) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[ExamenesLaboratorio]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamenesLaboratorio](
	[id_exam] [int] IDENTITY(1,1) NOT NULL,
	[nombre_exam] [varchar](50) NOT NULL,
	[nemo_exam] [varchar](20) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[HorarioConsultas]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HorarioConsultas](
	[id_paciente] [int] NOT NULL,
	[fch_Cita] [varchar](10) NULL,
	[hra_Cita] [varchar](10) NULL,
	[fch_Consulta] [varchar](10) NULL,
	[hra_Consulta] [varchar](10) NULL,
	[id_Consulta] [int] NULL,
	[estado] [varchar](1) NOT NULL,
	[observa] [varchar](300) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[imagenes]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[imagenes](
	[id_imagen] [int] IDENTITY(1,1) NOT NULL,
	[id_consulta] [int] NULL,
	[name_imagen] [varchar](20) NULL,
	[desc_imagen] [varchar](100) NULL,
	[fech_imagen] [varchar](10) NULL,
	[foto_imagen] [image] NULL
) ON [SECONDARY] TEXTIMAGE_ON [SECONDARY]
GO
/****** Object:  Table [dbo].[IndicaExamenes]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndicaExamenes](
	[id_consulta] [int] NULL,
	[id_examen] [int] NULL,
	[fch_resulExam] [datetime] NULL,
	[observaExam] [varchar](200) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[InformesPaciente]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformesPaciente](
	[id_info] [int] IDENTITY(1,1) NOT NULL,
	[nro_info] [int] NOT NULL,
	[id_paciente] [int] NOT NULL,
	[fch_info] [datetime] NOT NULL,
	[informe] [nvarchar](max) NULL,
 CONSTRAINT [PK_InfoPaciente] PRIMARY KEY CLUSTERED 
(
	[id_info] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [SECONDARY]
) ON [SECONDARY] TEXTIMAGE_ON [SECONDARY]
GO
/****** Object:  Table [dbo].[Lineas]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lineas](
	[id_linea] [int] IDENTITY(1,1) NOT NULL,
	[nombre_linea] [varchar](40) NOT NULL,
	[nemo_linea] [varchar](4) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[Medicacion]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicacion](
	[id_consulta] [int] NULL,
	[id_medicamento] [int] NULL,
	[dosis] [varchar](80) NULL,
	[indicacion] [varchar](300) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[Medicamentos]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicamentos](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[cod_articulo] [varchar](7) NULL,
	[id_linea] [int] NOT NULL,
	[id_sunidad] [int] NOT NULL,
	[name_comercial] [varchar](50) NULL,
	[name_generico] [varchar](50) NULL,
	[id_tipo] [tinyint] NULL,
	[estado] [varchar](1) NULL,
	[dosis] [varchar](80) NULL,
	[indicacion] [varchar](180) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[id_medico] [int] IDENTITY(1,1) NOT NULL,
	[nombre_med] [varchar](50) NOT NULL,
	[espe_med] [varchar](30) NULL,
	[nro_cmed] [varchar](6) NULL,
	[estado] [char](1) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[MedidaLentes]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedidaLentes](
	[id_consulta] [int] NULL,
	[idpaciente] [int] NOT NULL,
	[OISPHL] [nvarchar](6) NULL,
	[OICYSL] [nvarchar](6) NULL,
	[OIAXIL] [nvarchar](6) NULL,
	[ODSPHL] [nvarchar](6) NULL,
	[ODCYSL] [nvarchar](6) NULL,
	[ODAXIL] [nvarchar](6) NULL,
	[PDL] [nvarchar](3) NULL,
	[OBSL] [nvarchar](120) NULL,
	[OISPHC] [nvarchar](6) NULL,
	[OICYSC] [nvarchar](6) NULL,
	[OIAXIC] [nvarchar](6) NULL,
	[ODSPHC] [nvarchar](6) NULL,
	[ODCYSC] [nvarchar](6) NULL,
	[ODAXIC] [nvarchar](6) NULL,
	[PDC] [nvarchar](3) NULL,
	[OBSC] [nvarchar](120) NULL,
	[ODAV] [varchar](6) NULL,
	[OIAV] [varchar](6) NULL,
	[atencion] [char](1) NULL,
	[observaOpt] [varchar](180) NULL,
	[condi] [char](1) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[Ocupacion]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ocupacion](
	[id_ocupa] [int] NOT NULL,
	[nombre_ocupa] [varchar](60) NULL,
	[detalle_ocupa] [varchar](20) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[OrdenesVarias]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesVarias](
	[id_consulta] [int] NULL,
	[idpaciente] [int] NOT NULL,
	[atencion] [varchar](180) NULL,
	[orden] [varchar](800) NULL,
	[observa] [varchar](120) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[paciente]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paciente](
	[idpaciente] [int] IDENTITY(1,1) NOT NULL,
	[nhisto] [varchar](7) NULL,
	[fching] [datetime] NOT NULL,
	[condicion] [char](1) NOT NULL,
	[apaterno] [varchar](25) NOT NULL,
	[amaterno] [varchar](25) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[tipdoc] [char](1) NOT NULL,
	[nrodocu] [varchar](12) NULL,
	[fchnac] [datetime] NOT NULL,
	[sexo] [char](1) NOT NULL,
	[estcivil] [char](1) NOT NULL,
	[gruposa] [varchar](10) NULL,
	[nacion] [char](1) NOT NULL,
	[procede] [varchar](60) NULL,
	[iddepa] [int] NOT NULL,
	[idprov] [int] NOT NULL,
	[iddist] [int] NOT NULL,
	[direcc] [varchar](60) NULL,
	[idocupa] [int] NULL,
	[telcasa] [varchar](20) NULL,
	[centrab] [varchar](40) NULL,
	[celular] [varchar](20) NULL,
	[asegu] [char](1) NOT NULL,
	[ncarnet] [varchar](10) NULL,
	[ciasegu] [int] NULL,
	[contacto] [varchar](60) NULL,
	[idparen] [int] NULL,
	[telcon] [varchar](20) NULL,
	[celcon] [varchar](20) NULL,
	[perfil] [varchar](200) NULL,
	[anteclinic] [varchar](160) NULL,
	[antefam] [varchar](160) NULL,
	[historia_c] [nvarchar](max) NULL,
	[edad] [varchar](3) NULL,
	[lugar_nac] [varchar](20) NULL,
	[ocupacion] [varchar](25) NULL,
	[hipertenso] [char](1) NULL,
	[diabetes] [char](1) NULL,
	[tipoDiabetes] [varchar](20) NULL,
	[alergico] [char](1) NULL,
	[tipoAlergia] [varchar](25) NULL,
	[CV] [varchar](6) NULL,
	[id_medico] [int] NULL,
	[email] [varchar](80) NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[idpaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [SECONDARY]
) ON [SECONDARY] TEXTIMAGE_ON [SECONDARY]
GO
/****** Object:  Table [dbo].[Presentaciones]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presentaciones](
	[id_presenta] [int] IDENTITY(1,1) NOT NULL,
	[nombre_prese] [varchar](30) NOT NULL,
	[nemo_prese] [varchar](4) NOT NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[ProcedEspeciales]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcedEspeciales](
	[id_consulta] [int] NOT NULL,
	[id_proce] [int] NOT NULL,
	[fch_resulProce] [datetime] NULL,
	[observa] [varchar](800) NULL,
	[imagenes] [char](1) NULL,
	[ubicacion] [varchar](160) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[Procedimientos]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Procedimientos](
	[id_proce] [int] IDENTITY(1,1) NOT NULL,
	[nombre_proce] [varchar](50) NOT NULL,
	[nemo_proce] [varchar](20) NULL
) ON [SECONDARY]
GO
/****** Object:  Table [dbo].[UBICACION]    Script Date: 09/05/2024 14:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UBICACION](
	[id_ubica] [int] NOT NULL,
	[tab_tipreg] [int] NOT NULL,
	[tab_codreg] [char](6) NOT NULL,
	[tab_nombre] [varchar](30) NULL,
	[tab_codrela] [char](6) NULL
) ON [SECONDARY]
GO
