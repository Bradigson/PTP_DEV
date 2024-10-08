USE [master]
GO
/****** Object:  Database [db_a82d6a_ptpdbtest]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE DATABASE [db_a82d6a_ptpdbtest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'POS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\db_a82d6a_ptpdbtest_data.mdf' , SIZE = 6336KB , MAXSIZE = 1024000KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'POS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\db_a82d6a_ptpdbtest_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_a82d6a_ptpdbtest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET  MULTI_USER 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [db_a82d6a_ptpdbtest]
GO
/****** Object:  Table [dbo].[adm_Usuarios]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adm_Usuarios](
	[FechaCreada] [date] NULL,
	[IDUsuario] [int] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[PasswordUS] [varchar](100) NOT NULL,
	[IDPerfil] [int] NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[img] [varchar](max) NULL,
	[Cedula] [varchar](20) NULL,
	[Telefono] [varchar](15) NULL,
	[Email] [varchar](20) NULL,
	[ID_Pais] [int] NULL,
	[ID_Region] [int] NULL,
	[ID_Provincia] [int] NULL,
	[ID_Municipio] [int] NULL,
	[ID_Sectores] [int] NULL,
	[Direccion] [varchar](200) NULL,
	[Cargo] [varchar](20) NULL,
	[IDEmpresa] [bigint] NULL,
	[IDSucusal] [bigint] NULL,
	[IDUSuarioCreador] [int] NULL,
	[Bloquear] [int] NULL,
	[UltimaFechaModificacion] [date] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Almacenes]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacenes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](60) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[IdUSuarioACargo] [int] NOT NULL,
	[IdMunicipio] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IDEmpresa] [bigint] NULL,
	[AlmacenPrincipal] [varchar](2) NULL,
 CONSTRAINT [PK_dbo.Almacenes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AperturaCierreCaja]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AperturaCierreCaja](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Fecha_apertura] [date] NULL,
	[AperturCierre] [varchar](1) NULL,
	[MontoInicio] [decimal](18, 0) NULL,
	[MontoConfirmado] [decimal](18, 0) NULL,
	[idCaja] [int] NULL,
	[DeclaroFatante] [varchar](1) NULL,
	[MontoFaltante] [decimal](18, 0) NULL,
	[DeclaroExcedente] [decimal](18, 0) NULL,
	[MontoExcedente] [decimal](18, 0) NULL,
	[IdMoneda] [int] NULL,
	[idUsuarioReponCaja] [int] NULL,
	[MotoEfectivoCierre] [decimal](18, 0) NULL,
	[totalOperacionesEfectivo] [int] NULL,
	[MontoTarjetaOtransferenciaCierre] [decimal](18, 0) NULL,
	[totalOperacionesTajeta] [int] NULL,
	[MontoGeneral] [decimal](18, 0) NULL,
	[ConciliadoAlCuadre] [varchar](1) NULL,
	[idUsuarioConfirmaCO] [int] NULL,
	[ConciliarTJoTransaferencia] [varchar](1) NULL,
	[idUsuarioConfirmaTjoTF] [int] NULL,
	[idConciliacion] [int] NULL,
	[FechaCoinciliacionTJoTF] [date] NULL,
	[IdEmpresa] [bigint] NULL,
	[IdSucursal] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bancos]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bancos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Banco] [varchar](100) NOT NULL,
	[FechaCreacion] [date] NULL,
	[idUsuarioCrea] [int] NULL,
	[FechaModificacion] [date] NULL,
	[Estado] [bit] NULL,
	[IdEmpresa] [bigint] NULL,
	[IdSucursal] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Billetes_Moneda]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Billetes_Moneda](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[valor_BM] [decimal](15, 2) NULL,
	[idMoneda] [int] NULL,
	[numeroOrden] [int] NULL,
	[idEmpresa] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BovedaCaja]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BovedaCaja](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[MontoGeneral] [decimal](15, 2) NULL,
	[idMoneda] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioIDCrea] [int] NULL,
	[FechaActualizacion] [datetime] NULL,
	[UsuarioIDActualiza] [int] NULL,
	[idEmpresa] [bigint] NULL,
	[IdSucursal] [bigint] NULL,
	[idUsuarioResposable] [int] NULL,
	[MontoDiaAnterior] [decimal](18, 2) NULL,
	[idUsuarioModifica] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BovedaCajaDesglose]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BovedaCajaDesglose](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBoveda] [int] NULL,
	[idIdmoneda] [int] NULL,
	[idbilletes_moneda] [varchar](1000) NULL,
	[Cantidad] [int] NULL,
	[idEmpresa] [bigint] NULL,
	[IdSucursal] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BovedaMovimiento]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BovedaMovimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idMoneda] [int] NULL,
	[idTipoOperacionBoveda] [int] NULL,
	[Descripcion] [varchar](400) NULL,
	[Entrada_Salida] [varchar](1) NULL,
	[valorTotalMovimiento] [decimal](15, 2) NULL,
	[idDesgloseXcajero] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioIDCrea] [int] NULL,
	[FechaActualizacion] [datetime] NULL,
	[UsuarioIDActualiza] [int] NULL,
	[idEmpresa] [bigint] NULL,
	[IdSucursal] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Caja]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caja](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[numeroCaja] [int] NULL,
	[NombreCaja] [varchar](30) NULL,
	[idUsuarioResposable] [int] NULL,
	[UsuarioIDCrea] [int] NULL,
	[FechaActualizacion] [datetime] NULL,
	[UsuarioIDActualiza] [int] NULL,
	[EstadoCaja] [varchar](4) NULL,
	[idEmpresa] [bigint] NULL,
	[IdSucursal] [bigint] NULL,
	[MontoInicioConfirado] [decimal](18, 2) NULL,
	[MontoUltimoCierre] [decimal](18, 2) NULL,
	[FechaUltimoCierre] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudades_X_Paises]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudades_X_Paises](
	[Cod_Empresa] [int] NOT NULL,
	[Cod_ciudades] [int] NOT NULL,
	[Cod_pais] [int] NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Cod_Usuario] [int] NOT NULL,
	[Cod_Usuario_Modificacion] [int] NOT NULL,
	[Fecha_adicion] [date] NULL,
	[Fecha_modificacion] [date] NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Ciudades_X_Paises_1] PRIMARY KEY CLUSTERED 
(
	[Cod_ciudades] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](40) NOT NULL,
	[Apellido] [nvarchar](40) NULL,
	[Fecha_Cumplano] [date] NULL,
	[Cedula] [nvarchar](20) NULL,
	[Rnc] [nvarchar](20) NULL,
	[Empresa] [nvarchar](100) NULL,
	[Direccion] [nvarchar](100) NULL,
	[Referencia] [nvarchar](100) NULL,
	[Imagen] [nvarchar](max) NULL,
	[Email] [nvarchar](70) NULL,
	[Telefono1] [nvarchar](20) NULL,
	[Telefono2] [nvarchar](20) NULL,
	[IdMunicipio] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[Fecha_Modificacion] [datetime] NULL,
	[Usuario_Adicion] [int] NULL,
	[Usuario_Modificacion] [int] NULL,
	[Sexo] [varchar](1) NULL,
	[Cod_Tipo_Identificacion] [int] NULL,
	[Cod_Ciudad] [int] NULL,
	[Cod_Pais_Nacionalidad] [int] NULL,
	[Cod_Empresa] [int] NULL,
	[Cod_Sucursal] [int] NULL,
	[Cod_Pais] [int] NULL,
	[Cod_Region] [int] NULL,
	[Cod_Provincia] [int] NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConciliacionTCTF]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConciliacionTCTF](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[idCaja] [int] NULL,
	[idFactura] [int] NULL,
	[idMoneda] [int] NULL,
	[montoPagadoTCTF] [decimal](18, 0) NULL,
	[VTnoAuth] [varchar](50) NULL,
	[VT4digit] [int] NULL,
	[montoPagadoTCTFEX] [decimal](18, 0) NULL,
	[VTnoAuthEX] [varchar](50) NULL,
	[VT4digitEX] [int] NULL,
	[Conciliado] [varchar](1) NULL,
	[IdEmpresa] [bigint] NULL,
	[IdSucursal] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactosSuplidores]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactosSuplidores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSuplidor] [int] NOT NULL,
	[Nombre] [nvarchar](30) NOT NULL,
	[Telefono1] [nvarchar](30) NOT NULL,
	[Telefono2] [nvarchar](30) NULL,
	[Extension] [nvarchar](30) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.ContactosSuplidores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cotizacion]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cotizacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[MontoTotal] [decimal](18, 2) NOT NULL,
	[DescuntoTotal] [decimal](18, 2) NOT NULL,
	[ItbisTotal] [decimal](18, 2) NOT NULL,
	[EmpleadoId] [int] NOT NULL,
	[NoFactura] [nvarchar](max) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Cotizacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuentaBancos]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaBancos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdBanco] [int] NULL,
	[IdMoneda] [int] NULL,
	[NombreCuenta] [varchar](100) NOT NULL,
	[NumeroCuenta] [varchar](100) NOT NULL,
	[Balance] [decimal](18, 0) NULL,
	[BalanceAnterior] [decimal](18, 0) NULL,
	[FechaCreacion] [date] NULL,
	[idUsuarioCrea] [int] NULL,
	[FechaModificacion] [date] NULL,
	[Estado] [bit] NULL,
	[IdEmpresa] [bigint] NULL,
	[IdSucursal] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuentasPorCobrar]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentasPorCobrar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacturacionId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[MontoTotal] [decimal](18, 2) NOT NULL,
	[MontoInicial] [decimal](18, 2) NOT NULL,
	[MontoPendiente] [decimal](18, 2) NOT NULL,
	[FechaUltimoPago] [datetime] NOT NULL,
	[FechaLimite] [datetime] NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.CuentasPorCobrar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuentasPorPagar]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentasPorPagar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](250) NOT NULL,
	[MontoInicial] [decimal](18, 2) NOT NULL,
	[MontoDeuda] [decimal](18, 2) NOT NULL,
	[Restante] [decimal](18, 2) NOT NULL,
	[FechaUltimoPago] [datetime] NOT NULL,
	[FechaLimitePago] [datetime] NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdMovimientoAlmacen] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.CuentasPorPagar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DescuadrexCajero]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DescuadrexCajero](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idDesgloseXcajero] [int] NULL,
	[Observaciones] [varchar](400) NULL,
	[TipoDescuadre] [varchar](1) NULL,
	[valor_Total] [decimal](15, 2) NULL,
	[valor_real] [decimal](15, 2) NULL,
	[idEmpresa] [bigint] NULL,
	[IdSucursal] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DescuadrexCajeroDesglose]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DescuadrexCajeroDesglose](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idDescuadre] [int] NULL,
	[idMoneda] [int] NULL,
	[idbilleteMoneda] [int] NULL,
	[idEmpresa] [bigint] NULL,
	[IdSucursal] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Descuentos]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Descuentos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[DescuentoPorcentaje] [int] NOT NULL,
	[DescuentoFijo] [int] NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[TipoDescuento] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[NombreProducto] [nvarchar](max) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Descuentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DesgloseXcajero]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DesgloseXcajero](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idBilletes_Moneda] [int] NULL,
	[catidadBillete] [int] NULL,
	[idCaja] [int] NULL,
	[idUsuarioResposable] [int] NULL,
	[tipoDesglose] [varchar](1) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioIDCrea] [int] NULL,
	[FechaActualizacion] [datetime] NULL,
	[UsuarioIDActualiza] [int] NULL,
	[idEmpresa] [bigint] NULL,
	[IdSucursal] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCotizacion]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCotizacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CotizacionId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Descuento] [decimal](18, 2) NOT NULL,
	[Itbis] [decimal](18, 2) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.DetalleCotizacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCuentaPorPagar]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCuentaPorPagar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMovAlmacen] [int] NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IsCanceled] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.DetalleCuentaPorPagar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCuentasPorCobrar]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCuentasPorCobrar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacturacionId] [int] NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[IsCalceled] [bit] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.DetalleCuentasPorCobrar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFacturacion]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFacturacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacturacionId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Itbis] [decimal](18, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Descuento] [decimal](18, 2) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.DetalleFacturacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleMovimientoAlmacen]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleMovimientoAlmacen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMovimiento] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.DetalleMovimientoAlmacen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.DetallePedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DgiiNcf]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DgiiNcf](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Serie] [nvarchar](max) NOT NULL,
	[TipoComprobante] [nvarchar](max) NOT NULL,
	[SecuencialInicial] [nvarchar](max) NOT NULL,
	[SecuenciaDgii] [nvarchar](max) NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Usuario] [nvarchar](max) NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.DgiiNcf] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DgiiNcfSecuencia]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DgiiNcfSecuencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SerieTipoComprobante] [nvarchar](3) NULL,
	[Secuecial] [int] NOT NULL,
	[IdDgiiNcf] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.DgiiNcfSecuencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Envase]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Envase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Envase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturacion]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[NoFactura] [nvarchar](max) NULL,
	[Ncf] [nvarchar](max) NULL,
	[SecuenciaId] [int] NOT NULL,
	[Comentario] [nvarchar](max) NULL,
	[TipoTransaccionId] [int] NOT NULL,
	[TipoPagoId] [int] NOT NULL,
	[MontoTotal] [decimal](18, 2) NOT NULL,
	[IsCanceled] [bit] NOT NULL,
	[IsReturned] [bit] NOT NULL,
	[Justificacion] [nvarchar](max) NULL,
	[TotalDescuento] [decimal](18, 2) NOT NULL,
	[TotalItbis] [decimal](18, 2) NOT NULL,
	[CantidadProductos] [int] NOT NULL,
	[IdEmpresa] [bigint] NULL,
	[CodigoUsuario] [int] NULL,
	[ValorEfectivo] [decimal](18, 2) NULL,
	[ValorTarjeta] [decimal](18, 2) NULL,
	[VTnoAuth] [varchar](50) NULL,
	[VT4digit] [int] NULL,
	[TipoTarjeta] [varchar](2) NULL,
	[EstaDespachada] [varchar](2) NULL,
	[CantidadImpresion] [int] NULL,
	[Devuelta] [decimal](18, 2) NULL,
 CONSTRAINT [PK_dbo.Facturacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gn_empresas]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gn_empresas](
	[FechaCreada] [date] NULL,
	[IDEmpresa] [bigint] NOT NULL,
	[Empresa] [varchar](100) NULL,
	[ServidorDB] [varchar](100) NOT NULL,
	[UsuarioDB] [varchar](100) NOT NULL,
	[PasswordDB] [varchar](100) NOT NULL,
	[DBnombre] [varchar](100) NOT NULL,
	[IP] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gn_menu]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gn_menu](
	[IDMenu] [int] NOT NULL,
	[Menu] [nvarchar](50) NOT NULL,
	[Nivel] [int] NOT NULL,
	[Orden] [int] NOT NULL,
	[URL] [nvarchar](100) NULL,
	[MenuIcon] [nvarchar](25) NULL,
	[IDEmpresa] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gn_perfil]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gn_perfil](
	[FechaCreada] [date] NULL,
	[IDPerfil] [int] IDENTITY(11,1) NOT NULL,
	[Perfil] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[IDUsuario] [bigint] NULL,
	[Bloquear] [int] NULL,
	[UltimaFechaModificacion] [date] NULL,
	[IDEmpresa] [bigint] NULL,
 CONSTRAINT [PK_gn_perfil] PRIMARY KEY CLUSTERED 
(
	[IDPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gn_permiso]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gn_permiso](
	[IDPerminso] [bigint] IDENTITY(1,1) NOT NULL,
	[IDPerfil] [int] NULL,
	[IDMenu] [int] NULL,
	[IDEmpresa] [bigint] NULL,
 CONSTRAINT [PK_gn_permiso] PRIMARY KEY CLUSTERED 
(
	[IDPerminso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gn_sucursal]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gn_sucursal](
	[FechaCreada] [date] NULL,
	[IDSucursal] [bigint] NOT NULL,
	[Sucursal] [varchar](100) NOT NULL,
	[Esquema] [varchar](50) NOT NULL,
	[Telefono1] [varchar](15) NOT NULL,
	[Telefono2] [varchar](15) NULL,
	[Email] [varchar](100) NULL,
	[SitoWeb] [varchar](100) NULL,
	[RNC] [varchar](100) NOT NULL,
	[ID_Pais] [int] NULL,
	[ID_Region] [int] NULL,
	[ID_Provincia] [int] NULL,
	[ID_Municipio] [int] NULL,
	[ID_Sectores] [int] NULL,
	[Direccion] [varchar](200) NULL,
	[logo] [varchar](max) NULL,
	[UltimaFechaModificacion] [date] NULL,
	[Bloquear] [int] NULL,
	[IP] [varchar](100) NOT NULL,
	[IDEmpresa] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Imagen]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imagen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varbinary](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[Ruta] [nvarchar](max) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[Producto_Id] [int] NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Imagen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IV_ENVCO001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IV_ENVCO001](
	[FECHA_ADICION] [datetime] NULL,
	[CODIGO_ENVC] [bigint] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](100) NOT NULL,
	[BORRAR] [bit] NOT NULL,
	[IP_ADICCION] [varchar](100) NULL,
	[IP_MODIFICACION] [varchar](100) NULL,
	[ID_USUARIO_ADICCION] [bigint] NOT NULL,
	[ID_USUARIO_MODIFICACION] [bigint] NOT NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[LONGITUD] [varchar](100) NULL,
	[LATITUD] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CODIGO_ENVC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IV_PRODC001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IV_PRODC001](
	[CODIGO_PRODC] [bigint] IDENTITY(1,1) NOT NULL,
	[CODIGO_ASIGNADO] [varchar](15) NULL,
	[BAR_CODIGO] [varchar](100) NULL,
	[DESCRIPCION] [varchar](100) NULL,
	[ESTADO] [bit] NULL,
	[IMAGEN] [varchar](max) NULL,
	[LOTE] [bit] NOT NULL,
	[LOTE_CANT] [int] NULL,
	[INV_INICIAL] [int] NULL,
	[PRECIO_BASE] [decimal](18, 2) NULL,
	[PRECIO_COSTO] [decimal](18, 2) NULL,
	[CANT_MINIMA] [int] NULL,
	[CODIGO_CATPR] [bigint] NULL,
	[CODIGO_MARC] [bigint] NULL,
	[CODIGO_VERS] [bigint] NULL,
	[CODIGO_ENVC] [bigint] NULL,
	[BORRAR] [bit] NOT NULL,
	[IP_ADICCION] [varchar](100) NULL,
	[IP_MODIFICACION] [varchar](100) NULL,
	[ID_USUARIO_ADICCION] [bigint] NOT NULL,
	[ID_USUARIO_MODIFICACION] [bigint] NOT NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[LONGITUD] [varchar](100) NULL,
	[LATITUD] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CODIGO_PRODC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IV_VERS001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IV_VERS001](
	[FECHA_ADICION] [datetime] NULL,
	[CODIGO_VERS] [bigint] IDENTITY(1,1) NOT NULL,
	[CODIGO_MARC] [bigint] NULL,
	[DESCRIPCION] [varchar](100) NOT NULL,
	[BORRAR] [bit] NOT NULL,
	[IP_ADICCION] [varchar](100) NULL,
	[IP_MODIFICACION] [varchar](100) NULL,
	[ID_USUARIO_ADICCION] [bigint] NOT NULL,
	[ID_USUARIO_MODIFICACION] [bigint] NOT NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[LONGITUD] [varchar](100) NULL,
	[LATITUD] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CODIGO_VERS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](30) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Marca] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Moneda]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moneda](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[siglas] [varchar](10) NULL,
	[simbolo] [varchar](100) NULL,
	[idPais] [int] NULL,
	[idEmpresa] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimientoAlmacen]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimientoAlmacen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSuplidor] [int] NOT NULL,
	[IdTipoMovimiento] [int] NOT NULL,
	[NoFactura] [nvarchar](30) NOT NULL,
	[Ncf] [nvarchar](30) NULL,
	[CantidadProducto] [int] NOT NULL,
	[TotalFacturado] [bigint] NOT NULL,
	[IdAlmacen] [int] NOT NULL,
	[IdTipoPago] [int] NOT NULL,
	[Motivo] [nvarchar](max) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.MovimientoAlmacen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimientoBanco]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimientoBanco](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdBanco] [int] NULL,
	[Monto] [decimal](18, 0) NULL,
	[Fecha_movimiento] [date] NULL,
	[Detalle] [varchar](200) NULL,
	[idTipoMovimientoBanco] [int] NULL,
	[idUsuario] [int] NULL,
	[IdEmpresa] [bigint] NULL,
	[IdSucursal] [bigint] NULL,
	[IdMoneda] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Municipio]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[IdProvincia] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Municipio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Pais] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSuplidor] [int] NOT NULL,
	[Solicitado] [bit] NOT NULL,
	[Estado] [int] NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoDetallePedido]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoDetallePedido](
	[Pedido_Id] [int] NOT NULL,
	[DetallePedido_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PedidoDetallePedido] PRIMARY KEY CLUSTERED 
(
	[Pedido_Id] ASC,
	[DetallePedido_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Precio]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Precio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Activo] [bit] NOT NULL,
	[NumSeq] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Precio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](250) NULL,
	[IdVersion] [int] NOT NULL,
	[IdEnvase] [int] NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[EsLote] [bit] NOT NULL,
	[CantidadLote] [int] NOT NULL,
	[CantidadInventario] [int] NOT NULL,
	[PrecioBase] [decimal](18, 2) NOT NULL,
	[PrecioCompra] [decimal](18, 2) NOT NULL,
	[CantidadMinima] [int] NOT NULL,
	[CodigoBarra] [nvarchar](50) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
	[Imagen] [varchar](max) NULL,
	[AdmiteDescuento] [bit] NULL,
	[HabilitaVenta] [bit] NULL,
	[EsProducto] [varchar](1) NULL,
	[AplicaImp] [varchar](1) NULL,
	[ValorImpuesto] [decimal](18, 2) NULL,
 CONSTRAINT [PK_dbo.Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[IdRegion] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Provincia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[IdPais] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Region] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC_EMP001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC_EMP001](
	[CODIGO_EMP] [bigint] IDENTITY(1000001,1) NOT NULL,
	[NOMBRE_EMP] [varchar](100) NOT NULL,
	[LOGO_EMP] [varchar](max) NOT NULL,
	[RNC_EMP] [varchar](15) NULL,
	[DIRECCION] [varchar](300) NULL,
	[TELEFONO1] [varchar](15) NOT NULL,
	[TELEFONO2] [varchar](15) NULL,
	[EXT_TEL1] [varchar](10) NULL,
	[EXT_TEL2] [varchar](10) NULL,
	[CANT_SUCURSALES] [int] NOT NULL,
	[CANT_USUARIO] [int] NOT NULL,
	[WEB] [varchar](100) NULL,
	[USUARIO_ADICCION] [int] NOT NULL,
	[FECHA_ADICION] [datetime] NULL,
	[USUARIO_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
 CONSTRAINT [PK__SC_EMP00__04C877E862A3B7BA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_EMP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC_HORA_X_USR002]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC_HORA_X_USR002](
	[CODIGO_EMP] [bigint] NOT NULL,
	[CODIGO_USUARIO] [int] NOT NULL,
	[CODIGO_HRR] [int] NOT NULL,
	[CODIGO_HRRUSR] [int] IDENTITY(1,1) NOT NULL,
	[MINUTOS_PRORROGA] [int] NULL,
	[BORRAR] [bit] NULL,
	[IP_ADICCION] [varchar](100) NULL,
	[IP_MODIFICACION] [varchar](100) NULL,
	[USUARIO_ADICCION] [int] NOT NULL,
	[FECHA_ADICION] [datetime] NULL,
	[USUARIO_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
 CONSTRAINT [PK_HORAUSR] PRIMARY KEY CLUSTERED 
(
	[CODIGO_EMP] ASC,
	[CODIGO_USUARIO] ASC,
	[CODIGO_HRR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC_HORAGROUP002]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC_HORAGROUP002](
	[CODIGO_EMP] [bigint] NOT NULL,
	[CODIGO_HRRGROUP] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_HRR_1] [int] NULL,
	[CODIGO_HRR_2] [int] NULL,
	[CODIGO_HRR_3] [int] NULL,
	[CODIGO_HRR_4] [int] NULL,
	[CODIGO_HRR_5] [int] NULL,
	[CODIGO_HRR_6] [int] NULL,
	[CODIGO_HRR_7] [int] NULL,
	[BORRAR] [bit] NULL,
	[IP_ADICCION] [varchar](100) NULL,
	[IP_MODIFICACION] [varchar](100) NULL,
	[USUARIO_ADICCION] [int] NOT NULL,
	[FECHA_ADICION] [datetime] NULL,
	[USUARIO_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
 CONSTRAINT [PK__SC_HORAG__86A61A4F8B48E394] PRIMARY KEY CLUSTERED 
(
	[CODIGO_HRRGROUP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC_HORARIO001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC_HORARIO001](
	[CODIGO_EMP] [bigint] NOT NULL,
	[CODIGO_HRR] [int] IDENTITY(1,1) NOT NULL,
	[DIA] [varchar](25) NOT NULL,
	[HORA_DESDE] [decimal](4, 2) NULL,
	[HORA_HASTA] [decimal](4, 2) NULL,
	[BORRAR] [bit] NULL,
	[IP_ADICCION] [varchar](100) NULL,
	[IP_MODIFICACION] [varchar](100) NULL,
	[USUARIO_ADICCION] [int] NOT NULL,
	[FECHA_ADICION] [datetime] NULL,
	[USUARIO_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
 CONSTRAINT [PK__SC_HORAR__04898D8510CE713A] PRIMARY KEY CLUSTERED 
(
	[CODIGO_HRR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC_IMP001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC_IMP001](
	[CODIGO_EMP] [int] NOT NULL,
	[CODIGO_IMP] [int] IDENTITY(1,1) NOT NULL,
	[PORCENTAJE] [varchar](50) NULL,
	[VALOR_FIJO] [int] NULL,
	[DESCRIPCION] [varchar](100) NULL,
	[BORRAR] [bit] NOT NULL,
	[IP_ADICCION] [varchar](100) NULL,
	[IP_MODIFICACION] [varchar](100) NULL,
	[USUARIO_ADICCION] [int] NOT NULL,
	[FECHA_ADICION] [datetime] NULL,
	[USUARIO_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[LONGITUD] [varchar](100) NULL,
	[LATITUD] [varchar](100) NULL,
 CONSTRAINT [PK__SC_IMP00__05C071AEC20C023B] PRIMARY KEY CLUSTERED 
(
	[CODIGO_IMP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC_IPSYS001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC_IPSYS001](
	[CODIGO_IPSYS] [int] IDENTITY(1,1) NOT NULL,
	[IP] [varchar](100) NOT NULL,
	[CODIGO_USUARIO] [int] NULL,
	[ID_USUARIO_ADICION] [int] NOT NULL,
	[IP_ADICCION] [int] NULL,
	[FECHA_ADICION] [datetime] NULL,
	[ID_USUARIO_MODIFICACION] [int] NULL,
	[IP_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[LONGITUD] [varchar](100) NULL,
	[LATITUD] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CODIGO_IPSYS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC_MUNIC001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC_MUNIC001](
	[CODIGO_MUNIC] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_MUNIC] [varchar](100) NULL,
	[CODIGO_PROV] [int] NULL,
	[ID_USUARIO_ADICCION] [int] NOT NULL,
	[IP_ADICCION] [int] NULL,
	[FECHA_ADICION] [datetime] NULL,
	[ID_USUARIO_MODIFICACION] [int] NULL,
	[IP_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[LONGITUD] [varchar](100) NULL,
	[LATITUD] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CODIGO_MUNIC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC_PAIS001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC_PAIS001](
	[CODIGO_PAIS] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_PAIS] [varchar](100) NULL,
	[COD_ISO_2] [varchar](2) NULL,
	[COD_ISO_3] [varchar](2) NULL,
	[COD_ISO_NUMERICO] [int] NULL,
	[IP_ADICCION] [varchar](100) NULL,
	[IP_MODIFICACION] [varchar](100) NULL,
	[USUARIO_ADICCION] [int] NOT NULL,
	[FECHA_ADICION] [datetime] NULL,
	[USUARIO_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[LONGITUD] [varchar](100) NULL,
	[LATITUD] [varchar](100) NULL,
	[Nacionalidad] [varchar](50) NULL,
 CONSTRAINT [PK__SC_PAIS0__54EACE23D522B90D] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PAIS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC_PROV001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC_PROV001](
	[CODIGO_PROV] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_PROV] [varchar](100) NULL,
	[CODIGO_REG] [int] NULL,
	[ID_USUARIO_ADICCION] [int] NOT NULL,
	[IP_ADICCION] [int] NULL,
	[FECHA_ADICION] [datetime] NULL,
	[ID_USUARIO_MODIFICACION] [int] NULL,
	[IP_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[LONGITUD] [varchar](100) NULL,
	[LATITUD] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CODIGO_PROV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC_REG001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC_REG001](
	[CODIGO_REG] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_REG] [varchar](100) NULL,
	[CODIGO_PAIS] [int] NULL,
	[ID_USUARIO_ADICCION] [int] NOT NULL,
	[IP_ADICCION] [int] NULL,
	[FECHA_ADICION] [datetime] NULL,
	[ID_USUARIO_MODIFICACION] [int] NULL,
	[IP_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[LONGITUD] [varchar](100) NULL,
	[LATITUD] [varchar](100) NULL,
 CONSTRAINT [PK__SC_REG00__0F2150F94DD2C5CF] PRIMARY KEY CLUSTERED 
(
	[CODIGO_REG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC_SUC001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC_SUC001](
	[CODIGO_EMP] [bigint] NOT NULL,
	[CODIGO_SUC] [bigint] IDENTITY(100000001,1) NOT NULL,
	[NOMBRE_SUC] [varchar](100) NOT NULL,
	[TELEFONO1] [varchar](15) NULL,
	[ID_USUARIO_RESPONSABLE] [int] NULL,
	[Cod_Pais] [int] NOT NULL,
	[Cod_Region] [int] NOT NULL,
	[Cod_Provincia] [int] NOT NULL,
	[IdMunicipio] [int] NOT NULL,
	[DIRECCION] [varchar](250) NULL,
	[ESTADO_SUC] [bit] NULL,
	[IP_ADICCION] [varchar](100) NULL,
	[IP_MODIFICACION] [varchar](100) NULL,
	[USUARIO_ADICCION] [int] NOT NULL,
	[FECHA_ADICION] [datetime] NULL,
	[USUARIO_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[LONGITUD] [varchar](100) NULL,
	[LATITUD] [varchar](100) NULL,
	[PRINCIPAL] [bit] NULL,
 CONSTRAINT [PK__SC_SUC00__0066141296BD8C19] PRIMARY KEY CLUSTERED 
(
	[CODIGO_SUC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC_USUAR001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC_USUAR001](
	[CODIGO_EMP] [bigint] NULL,
	[CODIGO_USUARIO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_USUARIO] [varchar](100) NULL,
	[USUARIO] [varchar](100) NULL,
	[PASSWOR] [varchar](100) NULL,
	[ID_HORARIO] [int] NULL,
	[ID_PERFIL] [int] NULL,
	[CORREO_CONFIRMADO] [bit] NULL,
	[IMAGEN_USUARIO] [varchar](max) NULL,
	[CORREO] [varchar](100) NULL,
	[TELEFONO_PERSONAL] [varchar](15) NULL,
	[EXTENCION_PERSONAL] [varchar](10) NULL,
	[TELEFONO] [varchar](15) NULL,
	[EXTENCION] [varchar](15) NULL,
	[ONLINE_USUARIO] [bit] NULL,
	[CODIGO_SUC] [bigint] NULL,
	[IP_ADICCION] [varchar](100) NULL,
	[IP_MODIFICACION] [varchar](100) NULL,
	[USUARIO_ADICCION] [int] NOT NULL,
	[FECHA_ADICION] [datetime] NULL,
	[USUARIO_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[LONGITUD] [varchar](100) NULL,
	[LATITUD] [varchar](100) NULL,
 CONSTRAINT [PK__SC_USUAR__CAEAC257262B6652] PRIMARY KEY CLUSTERED 
(
	[CODIGO_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suplidores]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suplidores](
	[FechaCreacion] [datetime] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](60) NOT NULL,
	[Rnc] [int] NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](40) NULL,
	[IdMunicipio] [int] NOT NULL,
	[Imagen] [varchar](max) NULL,
	[Borrado] [bit] NOT NULL,
	[Fecha_Modificacion] [datetime] NULL,
	[Usuario_Adicion] [int] NULL,
	[Usuario_Modificacion] [int] NULL,
	[Web] [varchar](100) NULL,
	[Contacto1] [varchar](100) NULL,
	[TelefonoC1] [nvarchar](20) NULL,
	[ExtC1] [nvarchar](10) NULL,
	[Contacto2] [varchar](100) NULL,
	[TelefonoC2] [nvarchar](20) NULL,
	[ExtC2] [nvarchar](10) NULL,
	[Contacto3] [varchar](100) NULL,
	[TelefonoC3] [nvarchar](20) NULL,
	[ExtC3] [nvarchar](10) NULL,
	[ComentarioC1] [varchar](100) NULL,
	[ComentarioC2] [varchar](100) NULL,
	[ComentarioC3] [varchar](100) NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Suplidores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Identificacion]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Identificacion](
	[Cod_Empresa] [int] NOT NULL,
	[Cod_Tipo_Identificacion] [int] NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Cod_Usuario] [int] NOT NULL,
	[Cod_Usuario_Modificacion] [int] NOT NULL,
	[Fecha_adicion] [date] NULL,
	[Fecha_modificacion] [date] NOT NULL,
	[Estado] [bit] NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_Tipo_Identificacion_1] PRIMARY KEY CLUSTERED 
(
	[Cod_Tipo_Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoMovimiento]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMovimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IDEmpresa] [bigint] NULL,
	[IN_OUT] [varchar](1) NULL,
 CONSTRAINT [PK_dbo.TipoMovimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoMovimientoBanco]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMovimientoBanco](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[FechaCreacion] [date] NULL,
	[DebitoCreditootro] [varchar](1) NULL,
	[InternoExterno] [varchar](1) NULL,
	[IdUsuarioCrea] [int] NULL,
	[Estado] [bit] NULL,
	[IdEmpresa] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoOperacionBoveda]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoOperacionBoveda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [int] NULL,
	[Descripcion] [varchar](100) NULL,
	[Entrada_Salida] [varchar](1) NULL,
	[idMoneda] [int] NULL,
	[UsuarioIDCrea] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaActualizacion] [datetime] NULL,
	[UsuarioIDActualiza] [int] NULL,
	[idEmpresa] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPago](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
	[IN_OUT] [varchar](1) NULL,
 CONSTRAINT [PK_dbo.TipoPago] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoTransaccion]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoTransaccion](
	[Id_TIPO] [int] IDENTITY(1,1) NOT NULL,
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_TIPO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Versiones]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Versiones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](30) NOT NULL,
	[Activo] [bit] NOT NULL,
	[IdMarca] [int] NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[IdEmpresa] [bigint] NULL,
 CONSTRAINT [PK_dbo.Versiones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[FacturaPtp]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[FacturaPtp] as 

select a.Id as IDFacturaRow
,a.FechaCreacion as FechaEmisionFactura
,a.clienteId
,a.NoFactura	
,a.Ncf	
,a.SecuenciaId	
,a.Comentario	
,a.TipoTransaccionId	
,a.TipoPagoId	
,a.MontoTotal	
,a.IsCanceled	
,a.IsReturned	
,a.Justificacion	
,a.TotalDescuento	
,a.TotalItbis	
,a.CantidadProductos	
,a.IdEmpresa	
,a.CodigoUsuario	
,a.ValorEfectivo	
,a.ValorTarjeta	
,a.VTnoAuth	
,a.VT4digit	
,a.TipoTarjeta	
,a.EstaDespachada	
,a.CantidadImpresion	
,a.Devuelta
,b.Id as IddetalleF
,b.FacturacionId FacturaIDDetalle	
,b.ProductoId
,c.Descripcion as descripcionProducto
,c.AplicaImp
,b.Precio	
,b.Cantidad	
,b.Itbis	
,b.SubTotal	
,b.Descuento
,d.Id as idCliente
,d.Nombre
,d.Apellido
,d.Cod_Tipo_Identificacion
,d.Cedula
,d.Rnc
,d.Direccion
,d.Referencia
,d.Sexo
,f.LOGO_EMP
,f.NOMBRE_EMP
,f.RNC_EMP
,f.TELEFONO1

from [dbo].[Facturacion] a inner join DetalleFacturacion b
on a.Id=b.FacturacionId  and a.IdEmpresa=b.IdEmpresa inner join Producto c
on b.ProductoId=c.Id and b.IdEmpresa=c.IdEmpresa inner join [dbo].[Cliente] d  
on a.ClienteId=d.Id and d.IdEmpresa=a.IdEmpresa inner join TipoPago  e
on a.TipoPagoId=e.IN_OUT  
INNER join SC_EMP001 f on a.IdEmpresa=f.CODIGO_EMP
--inner join SC_SUC001 g 
--on g.CODIGO_EMP=f.CODIGO_EMP

GO
/****** Object:  Index [IX_IdMunicipio]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdMunicipio] ON [dbo].[Almacenes]
(
	[IdMunicipio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdMunicipio]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdMunicipio] ON [dbo].[Cliente]
(
	[IdMunicipio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdSuplidor]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdSuplidor] ON [dbo].[ContactosSuplidores]
(
	[IdSuplidor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClienteId]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClienteId] ON [dbo].[Cotizacion]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClienteId]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClienteId] ON [dbo].[CuentasPorCobrar]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FacturacionId]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_FacturacionId] ON [dbo].[CuentasPorCobrar]
(
	[FacturacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdMovimientoAlmacen]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdMovimientoAlmacen] ON [dbo].[CuentasPorPagar]
(
	[IdMovimientoAlmacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdProducto]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdProducto] ON [dbo].[Descuentos]
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CotizacionId]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_CotizacionId] ON [dbo].[DetalleCotizacion]
(
	[CotizacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductoId]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductoId] ON [dbo].[DetalleCotizacion]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdCuentaPorPagar]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdCuentaPorPagar] ON [dbo].[DetalleCuentaPorPagar]
(
	[IdMovAlmacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CuentasPorCobrarId]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_CuentasPorCobrarId] ON [dbo].[DetalleCuentasPorCobrar]
(
	[FacturacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FacturacionId]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_FacturacionId] ON [dbo].[DetalleFacturacion]
(
	[FacturacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductoId]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductoId] ON [dbo].[DetalleFacturacion]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdMovimiento]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdMovimiento] ON [dbo].[DetalleMovimientoAlmacen]
(
	[IdMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdProducto]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdProducto] ON [dbo].[DetalleMovimientoAlmacen]
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdProducto]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdProducto] ON [dbo].[DetallePedido]
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdDgiiNcf]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdDgiiNcf] ON [dbo].[DgiiNcfSecuencia]
(
	[IdDgiiNcf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClienteId]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClienteId] ON [dbo].[Facturacion]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SecuenciaId]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_SecuenciaId] ON [dbo].[Facturacion]
(
	[SecuenciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoPagoId]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_TipoPagoId] ON [dbo].[Facturacion]
(
	[TipoPagoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoTransaccionId]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_TipoTransaccionId] ON [dbo].[Facturacion]
(
	[TipoTransaccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_Id]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_Producto_Id] ON [dbo].[Imagen]
(
	[Producto_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdAlmacen]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdAlmacen] ON [dbo].[MovimientoAlmacen]
(
	[IdAlmacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdSuplidor]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdSuplidor] ON [dbo].[MovimientoAlmacen]
(
	[IdSuplidor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdTipoMovimiento]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdTipoMovimiento] ON [dbo].[MovimientoAlmacen]
(
	[IdTipoMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdTipoPago]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdTipoPago] ON [dbo].[MovimientoAlmacen]
(
	[IdTipoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdProvincia]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdProvincia] ON [dbo].[Municipio]
(
	[IdProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdSuplidor]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdSuplidor] ON [dbo].[Pedido]
(
	[IdSuplidor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetallePedido_Id]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_DetallePedido_Id] ON [dbo].[PedidoDetallePedido]
(
	[DetallePedido_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pedido_Id]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_Pedido_Id] ON [dbo].[PedidoDetallePedido]
(
	[Pedido_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductoId]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductoId] ON [dbo].[Precio]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdEnvase]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdEnvase] ON [dbo].[Producto]
(
	[IdEnvase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdVersion]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdVersion] ON [dbo].[Producto]
(
	[IdVersion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdRegion]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdRegion] ON [dbo].[Provincia]
(
	[IdRegion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdPais]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdPais] ON [dbo].[Region]
(
	[IdPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdMunicipio]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdMunicipio] ON [dbo].[Suplidores]
(
	[IdMunicipio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdMarca]    Script Date: 2/24/2022 8:11:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdMarca] ON [dbo].[Versiones]
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ciudades_X_Paises] ADD  DEFAULT (getdate()) FOR [Fecha_adicion]
GO
ALTER TABLE [dbo].[Ciudades_X_Paises] ADD  DEFAULT ((0)) FOR [Estado]
GO
ALTER TABLE [dbo].[IV_ENVCO001] ADD  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[IV_ENVCO001] ADD  DEFAULT ((0)) FOR [BORRAR]
GO
ALTER TABLE [dbo].[IV_ENVCO001] ADD  DEFAULT (getdate()) FOR [FECHA_MODIFICACION]
GO
ALTER TABLE [dbo].[IV_ENVCO001] ADD  DEFAULT ('0') FOR [LONGITUD]
GO
ALTER TABLE [dbo].[IV_ENVCO001] ADD  DEFAULT ('0') FOR [LATITUD]
GO
ALTER TABLE [dbo].[IV_PRODC001] ADD  DEFAULT ((0)) FOR [ESTADO]
GO
ALTER TABLE [dbo].[IV_PRODC001] ADD  DEFAULT ((0)) FOR [BORRAR]
GO
ALTER TABLE [dbo].[IV_PRODC001] ADD  DEFAULT (getdate()) FOR [FECHA_MODIFICACION]
GO
ALTER TABLE [dbo].[IV_PRODC001] ADD  DEFAULT ('0') FOR [LONGITUD]
GO
ALTER TABLE [dbo].[IV_PRODC001] ADD  DEFAULT ('0') FOR [LATITUD]
GO
ALTER TABLE [dbo].[IV_VERS001] ADD  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[IV_VERS001] ADD  DEFAULT ((0)) FOR [BORRAR]
GO
ALTER TABLE [dbo].[IV_VERS001] ADD  DEFAULT (getdate()) FOR [FECHA_MODIFICACION]
GO
ALTER TABLE [dbo].[IV_VERS001] ADD  DEFAULT ('0') FOR [LONGITUD]
GO
ALTER TABLE [dbo].[IV_VERS001] ADD  DEFAULT ('0') FOR [LATITUD]
GO
ALTER TABLE [dbo].[SC_EMP001] ADD  CONSTRAINT [DF__SC_EMP001__FECHA__571DF1D5]  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[SC_HORA_X_USR002] ADD  CONSTRAINT [DF__SC_HORA_X__FECHA__17036CC0]  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[SC_HORAGROUP002] ADD  CONSTRAINT [DF__SC_HORAGR__FECHA__17F790F9]  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[SC_HORARIO001] ADD  CONSTRAINT [DF__SC_HORARI__FECHA__18EBB532]  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[SC_IMP001] ADD  CONSTRAINT [DF__SC_IMP001__BORRA__19DFD96B]  DEFAULT ((0)) FOR [BORRAR]
GO
ALTER TABLE [dbo].[SC_IMP001] ADD  CONSTRAINT [DF__SC_IMP001__FECHA__1AD3FDA4]  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[SC_IMP001] ADD  CONSTRAINT [DF__SC_IMP001__LONGI__1BC821DD]  DEFAULT ('0') FOR [LONGITUD]
GO
ALTER TABLE [dbo].[SC_IMP001] ADD  CONSTRAINT [DF__SC_IMP001__LATIT__1CBC4616]  DEFAULT ('0') FOR [LATITUD]
GO
ALTER TABLE [dbo].[SC_IPSYS001] ADD  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[SC_MUNIC001] ADD  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[SC_PAIS001] ADD  CONSTRAINT [DF__SC_PAIS00__FECHA__66603565]  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[SC_PAIS001] ADD  CONSTRAINT [DF__SC_PAIS00__LONGI__6754599E]  DEFAULT ('0') FOR [LONGITUD]
GO
ALTER TABLE [dbo].[SC_PAIS001] ADD  CONSTRAINT [DF__SC_PAIS00__LATIT__68487DD7]  DEFAULT ('0') FOR [LATITUD]
GO
ALTER TABLE [dbo].[SC_PROV001] ADD  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[SC_PROV001] ADD  DEFAULT ('0') FOR [LONGITUD]
GO
ALTER TABLE [dbo].[SC_PROV001] ADD  DEFAULT ('0') FOR [LATITUD]
GO
ALTER TABLE [dbo].[SC_REG001] ADD  CONSTRAINT [DF__SC_REG001__FECHA__6FE99F9F]  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[SC_REG001] ADD  CONSTRAINT [DF__SC_REG001__LONGI__70DDC3D8]  DEFAULT ('0') FOR [LONGITUD]
GO
ALTER TABLE [dbo].[SC_REG001] ADD  CONSTRAINT [DF__SC_REG001__LATIT__71D1E811]  DEFAULT ('0') FOR [LATITUD]
GO
ALTER TABLE [dbo].[SC_SUC001] ADD  CONSTRAINT [DF__SC_SUC001__ESTAD__74AE54BC]  DEFAULT ((0)) FOR [ESTADO_SUC]
GO
ALTER TABLE [dbo].[SC_SUC001] ADD  CONSTRAINT [DF__SC_SUC001__FECHA__75A278F5]  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[SC_USUAR001] ADD  CONSTRAINT [DF__SC_USUAR0__FECHA__787EE5A0]  DEFAULT (getdate()) FOR [FECHA_ADICION]
GO
ALTER TABLE [dbo].[SC_USUAR001] ADD  CONSTRAINT [DF__SC_USUAR0__LONGI__797309D9]  DEFAULT ('0') FOR [LONGITUD]
GO
ALTER TABLE [dbo].[SC_USUAR001] ADD  CONSTRAINT [DF__SC_USUAR0__LATIT__7A672E12]  DEFAULT ('0') FOR [LATITUD]
GO
ALTER TABLE [dbo].[Tipo_Identificacion] ADD  DEFAULT (getdate()) FOR [Fecha_adicion]
GO
ALTER TABLE [dbo].[Tipo_Identificacion] ADD  DEFAULT ((0)) FOR [Estado]
GO
ALTER TABLE [dbo].[Almacenes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Almacenes_dbo.Municipio_IdMunicipio] FOREIGN KEY([IdMunicipio])
REFERENCES [dbo].[Municipio] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Almacenes] CHECK CONSTRAINT [FK_dbo.Almacenes_dbo.Municipio_IdMunicipio]
GO
ALTER TABLE [dbo].[AperturaCierreCaja]  WITH CHECK ADD FOREIGN KEY([idCaja])
REFERENCES [dbo].[Caja] ([Id])
GO
ALTER TABLE [dbo].[AperturaCierreCaja]  WITH CHECK ADD FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[SC_EMP001] ([CODIGO_EMP])
GO
ALTER TABLE [dbo].[AperturaCierreCaja]  WITH CHECK ADD FOREIGN KEY([IdMoneda])
REFERENCES [dbo].[Moneda] ([id])
GO
ALTER TABLE [dbo].[AperturaCierreCaja]  WITH CHECK ADD FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[SC_SUC001] ([CODIGO_SUC])
GO
ALTER TABLE [dbo].[AperturaCierreCaja]  WITH CHECK ADD FOREIGN KEY([idUsuarioConfirmaTjoTF])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[AperturaCierreCaja]  WITH CHECK ADD FOREIGN KEY([idUsuarioConfirmaCO])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[AperturaCierreCaja]  WITH CHECK ADD FOREIGN KEY([idUsuarioReponCaja])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[Bancos]  WITH CHECK ADD FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[SC_EMP001] ([CODIGO_EMP])
GO
ALTER TABLE [dbo].[Bancos]  WITH CHECK ADD FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[SC_SUC001] ([CODIGO_SUC])
GO
ALTER TABLE [dbo].[ConciliacionTCTF]  WITH CHECK ADD FOREIGN KEY([idCaja])
REFERENCES [dbo].[Caja] ([Id])
GO
ALTER TABLE [dbo].[ConciliacionTCTF]  WITH CHECK ADD FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[SC_EMP001] ([CODIGO_EMP])
GO
ALTER TABLE [dbo].[ConciliacionTCTF]  WITH CHECK ADD FOREIGN KEY([idFactura])
REFERENCES [dbo].[Facturacion] ([Id])
GO
ALTER TABLE [dbo].[ConciliacionTCTF]  WITH CHECK ADD FOREIGN KEY([idMoneda])
REFERENCES [dbo].[Moneda] ([id])
GO
ALTER TABLE [dbo].[ConciliacionTCTF]  WITH CHECK ADD FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[SC_SUC001] ([CODIGO_SUC])
GO
ALTER TABLE [dbo].[ContactosSuplidores]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ContactosSuplidores_dbo.Suplidores_IdSuplidor] FOREIGN KEY([IdSuplidor])
REFERENCES [dbo].[Suplidores] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContactosSuplidores] CHECK CONSTRAINT [FK_dbo.ContactosSuplidores_dbo.Suplidores_IdSuplidor]
GO
ALTER TABLE [dbo].[Cotizacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cotizacion_dbo.Cliente_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cotizacion] CHECK CONSTRAINT [FK_dbo.Cotizacion_dbo.Cliente_ClienteId]
GO
ALTER TABLE [dbo].[CuentaBancos]  WITH CHECK ADD FOREIGN KEY([IdBanco])
REFERENCES [dbo].[Bancos] ([Id])
GO
ALTER TABLE [dbo].[CuentaBancos]  WITH CHECK ADD FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[SC_EMP001] ([CODIGO_EMP])
GO
ALTER TABLE [dbo].[CuentaBancos]  WITH CHECK ADD FOREIGN KEY([IdMoneda])
REFERENCES [dbo].[Moneda] ([id])
GO
ALTER TABLE [dbo].[CuentaBancos]  WITH CHECK ADD FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[SC_SUC001] ([CODIGO_SUC])
GO
ALTER TABLE [dbo].[CuentasPorCobrar]  WITH CHECK ADD  CONSTRAINT [FK_CuentasPorCobrar_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[CuentasPorCobrar] CHECK CONSTRAINT [FK_CuentasPorCobrar_Cliente]
GO
ALTER TABLE [dbo].[CuentasPorCobrar]  WITH CHECK ADD  CONSTRAINT [FK_CuentasPorCobrar_CuentasPorCobrar] FOREIGN KEY([Id])
REFERENCES [dbo].[CuentasPorCobrar] ([Id])
GO
ALTER TABLE [dbo].[CuentasPorCobrar] CHECK CONSTRAINT [FK_CuentasPorCobrar_CuentasPorCobrar]
GO
ALTER TABLE [dbo].[CuentasPorCobrar]  WITH CHECK ADD  CONSTRAINT [FK_CuentasPorCobrar_Facturacion] FOREIGN KEY([FacturacionId])
REFERENCES [dbo].[Facturacion] ([Id])
GO
ALTER TABLE [dbo].[CuentasPorCobrar] CHECK CONSTRAINT [FK_CuentasPorCobrar_Facturacion]
GO
ALTER TABLE [dbo].[CuentasPorPagar]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentasPorPagar_dbo.MovimientoAlmacen_IdMovimientoAlmacen] FOREIGN KEY([IdMovimientoAlmacen])
REFERENCES [dbo].[MovimientoAlmacen] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CuentasPorPagar] CHECK CONSTRAINT [FK_dbo.CuentasPorPagar_dbo.MovimientoAlmacen_IdMovimientoAlmacen]
GO
ALTER TABLE [dbo].[Descuentos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Descuentos_dbo.Producto_IdProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Descuentos] CHECK CONSTRAINT [FK_dbo.Descuentos_dbo.Producto_IdProducto]
GO
ALTER TABLE [dbo].[DetalleCotizacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleCotizacion_dbo.Cotizacion_CotizacionId] FOREIGN KEY([CotizacionId])
REFERENCES [dbo].[Cotizacion] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleCotizacion] CHECK CONSTRAINT [FK_dbo.DetalleCotizacion_dbo.Cotizacion_CotizacionId]
GO
ALTER TABLE [dbo].[DetalleCotizacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleCotizacion_dbo.Producto_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleCotizacion] CHECK CONSTRAINT [FK_dbo.DetalleCotizacion_dbo.Producto_ProductoId]
GO
ALTER TABLE [dbo].[DetalleCuentaPorPagar]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleCuentaPorPagar_dbo.CuentasPorPagar_IdCuentaPorPagar] FOREIGN KEY([IdMovAlmacen])
REFERENCES [dbo].[MovimientoAlmacen] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleCuentaPorPagar] CHECK CONSTRAINT [FK_dbo.DetalleCuentaPorPagar_dbo.CuentasPorPagar_IdCuentaPorPagar]
GO
ALTER TABLE [dbo].[DetalleCuentasPorCobrar]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCuentasPorCobrar_Facturacion] FOREIGN KEY([FacturacionId])
REFERENCES [dbo].[Facturacion] ([Id])
GO
ALTER TABLE [dbo].[DetalleCuentasPorCobrar] CHECK CONSTRAINT [FK_DetalleCuentasPorCobrar_Facturacion]
GO
ALTER TABLE [dbo].[DetalleFacturacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleFacturacion_dbo.Facturacion_FacturacionId] FOREIGN KEY([FacturacionId])
REFERENCES [dbo].[Facturacion] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleFacturacion] CHECK CONSTRAINT [FK_dbo.DetalleFacturacion_dbo.Facturacion_FacturacionId]
GO
ALTER TABLE [dbo].[DetalleFacturacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleFacturacion_dbo.Producto_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleFacturacion] CHECK CONSTRAINT [FK_dbo.DetalleFacturacion_dbo.Producto_ProductoId]
GO
ALTER TABLE [dbo].[DetalleMovimientoAlmacen]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleMovimientoAlmacen_dbo.MovimientoAlmacen_IdMovimiento] FOREIGN KEY([IdMovimiento])
REFERENCES [dbo].[MovimientoAlmacen] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleMovimientoAlmacen] CHECK CONSTRAINT [FK_dbo.DetalleMovimientoAlmacen_dbo.MovimientoAlmacen_IdMovimiento]
GO
ALTER TABLE [dbo].[DetalleMovimientoAlmacen]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleMovimientoAlmacen_dbo.Producto_IdProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleMovimientoAlmacen] CHECK CONSTRAINT [FK_dbo.DetalleMovimientoAlmacen_dbo.Producto_IdProducto]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetallePedido_dbo.Producto_IdProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_dbo.DetallePedido_dbo.Producto_IdProducto]
GO
ALTER TABLE [dbo].[DgiiNcfSecuencia]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DgiiNcfSecuencia_dbo.DgiiNcf_IdDgiiNcf] FOREIGN KEY([IdDgiiNcf])
REFERENCES [dbo].[DgiiNcf] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DgiiNcfSecuencia] CHECK CONSTRAINT [FK_dbo.DgiiNcfSecuencia_dbo.DgiiNcf_IdDgiiNcf]
GO
ALTER TABLE [dbo].[Facturacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Facturacion_dbo.Cliente_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Facturacion] CHECK CONSTRAINT [FK_dbo.Facturacion_dbo.Cliente_ClienteId]
GO
ALTER TABLE [dbo].[Facturacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Facturacion_dbo.DgiiNcfSecuencia_SecuenciaId] FOREIGN KEY([SecuenciaId])
REFERENCES [dbo].[DgiiNcfSecuencia] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Facturacion] CHECK CONSTRAINT [FK_dbo.Facturacion_dbo.DgiiNcfSecuencia_SecuenciaId]
GO
ALTER TABLE [dbo].[Imagen]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Imagen_dbo.Producto_Producto_Id] FOREIGN KEY([Producto_Id])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Imagen] CHECK CONSTRAINT [FK_dbo.Imagen_dbo.Producto_Producto_Id]
GO
ALTER TABLE [dbo].[MovimientoAlmacen]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MovimientoAlmacen_dbo.Almacenes_IdAlmacen] FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacenes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovimientoAlmacen] CHECK CONSTRAINT [FK_dbo.MovimientoAlmacen_dbo.Almacenes_IdAlmacen]
GO
ALTER TABLE [dbo].[MovimientoAlmacen]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MovimientoAlmacen_dbo.Suplidores_IdSuplidor] FOREIGN KEY([IdSuplidor])
REFERENCES [dbo].[Suplidores] ([Id])
GO
ALTER TABLE [dbo].[MovimientoAlmacen] CHECK CONSTRAINT [FK_dbo.MovimientoAlmacen_dbo.Suplidores_IdSuplidor]
GO
ALTER TABLE [dbo].[MovimientoAlmacen]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MovimientoAlmacen_dbo.TipoMovimiento_IdTipoMovimiento] FOREIGN KEY([IdTipoMovimiento])
REFERENCES [dbo].[TipoMovimiento] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovimientoAlmacen] CHECK CONSTRAINT [FK_dbo.MovimientoAlmacen_dbo.TipoMovimiento_IdTipoMovimiento]
GO
ALTER TABLE [dbo].[MovimientoAlmacen]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MovimientoAlmacen_dbo.TipoPago_IdTipoPago] FOREIGN KEY([IdTipoPago])
REFERENCES [dbo].[TipoPago] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovimientoAlmacen] CHECK CONSTRAINT [FK_dbo.MovimientoAlmacen_dbo.TipoPago_IdTipoPago]
GO
ALTER TABLE [dbo].[MovimientoBanco]  WITH CHECK ADD FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[SC_EMP001] ([CODIGO_EMP])
GO
ALTER TABLE [dbo].[MovimientoBanco]  WITH CHECK ADD FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[SC_SUC001] ([CODIGO_SUC])
GO
ALTER TABLE [dbo].[MovimientoBanco]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pedido_dbo.Suplidores_IdSuplidor] FOREIGN KEY([IdSuplidor])
REFERENCES [dbo].[Suplidores] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_dbo.Pedido_dbo.Suplidores_IdSuplidor]
GO
ALTER TABLE [dbo].[PedidoDetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PedidoDetallePedido_dbo.DetallePedido_DetallePedido_Id] FOREIGN KEY([DetallePedido_Id])
REFERENCES [dbo].[DetallePedido] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PedidoDetallePedido] CHECK CONSTRAINT [FK_dbo.PedidoDetallePedido_dbo.DetallePedido_DetallePedido_Id]
GO
ALTER TABLE [dbo].[PedidoDetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PedidoDetallePedido_dbo.Pedido_Pedido_Id] FOREIGN KEY([Pedido_Id])
REFERENCES [dbo].[Pedido] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PedidoDetallePedido] CHECK CONSTRAINT [FK_dbo.PedidoDetallePedido_dbo.Pedido_Pedido_Id]
GO
ALTER TABLE [dbo].[Precio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Precio_dbo.Producto_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Precio] CHECK CONSTRAINT [FK_dbo.Precio_dbo.Producto_ProductoId]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Producto_dbo.Envase_IdEnvase] FOREIGN KEY([IdEnvase])
REFERENCES [dbo].[Envase] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_dbo.Producto_dbo.Envase_IdEnvase]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Producto_dbo.Versiones_IdVersion] FOREIGN KEY([IdVersion])
REFERENCES [dbo].[Versiones] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_dbo.Producto_dbo.Versiones_IdVersion]
GO
ALTER TABLE [dbo].[Provincia]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Provincia_dbo.Region_IdRegion] FOREIGN KEY([IdRegion])
REFERENCES [dbo].[Region] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Provincia] CHECK CONSTRAINT [FK_dbo.Provincia_dbo.Region_IdRegion]
GO
ALTER TABLE [dbo].[Region]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Region_dbo.Pais_IdPais] FOREIGN KEY([IdPais])
REFERENCES [dbo].[Pais] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Region] CHECK CONSTRAINT [FK_dbo.Region_dbo.Pais_IdPais]
GO
ALTER TABLE [dbo].[SC_HORA_X_USR002]  WITH CHECK ADD  CONSTRAINT [FK_HORAUSR_EMP] FOREIGN KEY([CODIGO_EMP])
REFERENCES [dbo].[SC_EMP001] ([CODIGO_EMP])
GO
ALTER TABLE [dbo].[SC_HORA_X_USR002] CHECK CONSTRAINT [FK_HORAUSR_EMP]
GO
ALTER TABLE [dbo].[SC_HORA_X_USR002]  WITH CHECK ADD  CONSTRAINT [FK_HORAUSR_HRR] FOREIGN KEY([CODIGO_HRRUSR])
REFERENCES [dbo].[SC_HORARIO001] ([CODIGO_HRR])
GO
ALTER TABLE [dbo].[SC_HORA_X_USR002] CHECK CONSTRAINT [FK_HORAUSR_HRR]
GO
ALTER TABLE [dbo].[SC_HORA_X_USR002]  WITH CHECK ADD  CONSTRAINT [FK_HORAUSR_USR1] FOREIGN KEY([CODIGO_USUARIO])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_HORA_X_USR002] CHECK CONSTRAINT [FK_HORAUSR_USR1]
GO
ALTER TABLE [dbo].[SC_HORA_X_USR002]  WITH CHECK ADD  CONSTRAINT [FK_HORAUSR_USR2] FOREIGN KEY([USUARIO_ADICCION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_HORA_X_USR002] CHECK CONSTRAINT [FK_HORAUSR_USR2]
GO
ALTER TABLE [dbo].[SC_HORA_X_USR002]  WITH CHECK ADD  CONSTRAINT [FK_HORAUSR_USR3] FOREIGN KEY([USUARIO_MODIFICACION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_HORA_X_USR002] CHECK CONSTRAINT [FK_HORAUSR_USR3]
GO
ALTER TABLE [dbo].[SC_HORAGROUP002]  WITH CHECK ADD  CONSTRAINT [FK_HORAGROUP_EMPRESA] FOREIGN KEY([CODIGO_EMP])
REFERENCES [dbo].[SC_EMP001] ([CODIGO_EMP])
GO
ALTER TABLE [dbo].[SC_HORAGROUP002] CHECK CONSTRAINT [FK_HORAGROUP_EMPRESA]
GO
ALTER TABLE [dbo].[SC_HORAGROUP002]  WITH CHECK ADD  CONSTRAINT [FK_HORAGROUP_HORA1] FOREIGN KEY([CODIGO_HRR_1])
REFERENCES [dbo].[SC_HORARIO001] ([CODIGO_HRR])
GO
ALTER TABLE [dbo].[SC_HORAGROUP002] CHECK CONSTRAINT [FK_HORAGROUP_HORA1]
GO
ALTER TABLE [dbo].[SC_HORAGROUP002]  WITH CHECK ADD  CONSTRAINT [FK_HORAGROUP_HORA2] FOREIGN KEY([CODIGO_HRR_2])
REFERENCES [dbo].[SC_HORARIO001] ([CODIGO_HRR])
GO
ALTER TABLE [dbo].[SC_HORAGROUP002] CHECK CONSTRAINT [FK_HORAGROUP_HORA2]
GO
ALTER TABLE [dbo].[SC_HORAGROUP002]  WITH CHECK ADD  CONSTRAINT [FK_HORAGROUP_HORA3] FOREIGN KEY([CODIGO_HRR_3])
REFERENCES [dbo].[SC_HORARIO001] ([CODIGO_HRR])
GO
ALTER TABLE [dbo].[SC_HORAGROUP002] CHECK CONSTRAINT [FK_HORAGROUP_HORA3]
GO
ALTER TABLE [dbo].[SC_HORAGROUP002]  WITH CHECK ADD  CONSTRAINT [FK_HORAGROUP_HORA4] FOREIGN KEY([CODIGO_HRR_4])
REFERENCES [dbo].[SC_HORARIO001] ([CODIGO_HRR])
GO
ALTER TABLE [dbo].[SC_HORAGROUP002] CHECK CONSTRAINT [FK_HORAGROUP_HORA4]
GO
ALTER TABLE [dbo].[SC_HORAGROUP002]  WITH CHECK ADD  CONSTRAINT [FK_HORAGROUP_HORA5] FOREIGN KEY([CODIGO_HRR_5])
REFERENCES [dbo].[SC_HORARIO001] ([CODIGO_HRR])
GO
ALTER TABLE [dbo].[SC_HORAGROUP002] CHECK CONSTRAINT [FK_HORAGROUP_HORA5]
GO
ALTER TABLE [dbo].[SC_HORAGROUP002]  WITH CHECK ADD  CONSTRAINT [FK_HORAGROUP_HORA6] FOREIGN KEY([CODIGO_HRR_6])
REFERENCES [dbo].[SC_HORARIO001] ([CODIGO_HRR])
GO
ALTER TABLE [dbo].[SC_HORAGROUP002] CHECK CONSTRAINT [FK_HORAGROUP_HORA6]
GO
ALTER TABLE [dbo].[SC_HORAGROUP002]  WITH CHECK ADD  CONSTRAINT [FK_HORAGROUP_HORA7] FOREIGN KEY([CODIGO_HRR_7])
REFERENCES [dbo].[SC_HORARIO001] ([CODIGO_HRR])
GO
ALTER TABLE [dbo].[SC_HORAGROUP002] CHECK CONSTRAINT [FK_HORAGROUP_HORA7]
GO
ALTER TABLE [dbo].[SC_HORAGROUP002]  WITH CHECK ADD  CONSTRAINT [FK_HORAGROUP_USR_ADD] FOREIGN KEY([USUARIO_ADICCION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_HORAGROUP002] CHECK CONSTRAINT [FK_HORAGROUP_USR_ADD]
GO
ALTER TABLE [dbo].[SC_HORAGROUP002]  WITH CHECK ADD  CONSTRAINT [FK_HORAGROUP_USR_MOD] FOREIGN KEY([USUARIO_MODIFICACION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_HORAGROUP002] CHECK CONSTRAINT [FK_HORAGROUP_USR_MOD]
GO
ALTER TABLE [dbo].[SC_HORARIO001]  WITH CHECK ADD  CONSTRAINT [FK_HORARIO_EMPRESA] FOREIGN KEY([CODIGO_EMP])
REFERENCES [dbo].[SC_EMP001] ([CODIGO_EMP])
GO
ALTER TABLE [dbo].[SC_HORARIO001] CHECK CONSTRAINT [FK_HORARIO_EMPRESA]
GO
ALTER TABLE [dbo].[SC_HORARIO001]  WITH CHECK ADD  CONSTRAINT [FK_HORARIO_USUARIO_ADD] FOREIGN KEY([USUARIO_ADICCION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_HORARIO001] CHECK CONSTRAINT [FK_HORARIO_USUARIO_ADD]
GO
ALTER TABLE [dbo].[SC_HORARIO001]  WITH CHECK ADD  CONSTRAINT [FK_HORARIO_USUARIO_MOD] FOREIGN KEY([USUARIO_MODIFICACION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_HORARIO001] CHECK CONSTRAINT [FK_HORARIO_USUARIO_MOD]
GO
ALTER TABLE [dbo].[SC_IMP001]  WITH CHECK ADD  CONSTRAINT [FK_IMP_PAIS] FOREIGN KEY([CODIGO_EMP])
REFERENCES [dbo].[SC_PAIS001] ([CODIGO_PAIS])
GO
ALTER TABLE [dbo].[SC_IMP001] CHECK CONSTRAINT [FK_IMP_PAIS]
GO
ALTER TABLE [dbo].[SC_IMP001]  WITH CHECK ADD  CONSTRAINT [FK_IMP_USU1] FOREIGN KEY([USUARIO_ADICCION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_IMP001] CHECK CONSTRAINT [FK_IMP_USU1]
GO
ALTER TABLE [dbo].[SC_IMP001]  WITH CHECK ADD  CONSTRAINT [FK_IMP_USU2] FOREIGN KEY([USUARIO_MODIFICACION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_IMP001] CHECK CONSTRAINT [FK_IMP_USU2]
GO
ALTER TABLE [dbo].[SC_IMP001]  WITH CHECK ADD  CONSTRAINT [FK_PAIS_USU1] FOREIGN KEY([USUARIO_ADICCION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_IMP001] CHECK CONSTRAINT [FK_PAIS_USU1]
GO
ALTER TABLE [dbo].[SC_IMP001]  WITH CHECK ADD  CONSTRAINT [FK_PAIS_USU2] FOREIGN KEY([USUARIO_MODIFICACION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_IMP001] CHECK CONSTRAINT [FK_PAIS_USU2]
GO
ALTER TABLE [dbo].[SC_IPSYS001]  WITH CHECK ADD  CONSTRAINT [FK_IPSYS_IP_MOD] FOREIGN KEY([IP_MODIFICACION])
REFERENCES [dbo].[SC_IPSYS001] ([CODIGO_IPSYS])
GO
ALTER TABLE [dbo].[SC_IPSYS001] CHECK CONSTRAINT [FK_IPSYS_IP_MOD]
GO
ALTER TABLE [dbo].[SC_IPSYS001]  WITH CHECK ADD  CONSTRAINT [FK_IPSYS_USUA_MOD] FOREIGN KEY([ID_USUARIO_MODIFICACION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_IPSYS001] CHECK CONSTRAINT [FK_IPSYS_USUA_MOD]
GO
ALTER TABLE [dbo].[SC_MUNIC001]  WITH CHECK ADD  CONSTRAINT [FK_MUNIC_PROV] FOREIGN KEY([CODIGO_PROV])
REFERENCES [dbo].[SC_PROV001] ([CODIGO_PROV])
GO
ALTER TABLE [dbo].[SC_MUNIC001] CHECK CONSTRAINT [FK_MUNIC_PROV]
GO
ALTER TABLE [dbo].[SC_PROV001]  WITH CHECK ADD  CONSTRAINT [FK_PROV_REG] FOREIGN KEY([CODIGO_REG])
REFERENCES [dbo].[SC_REG001] ([CODIGO_REG])
GO
ALTER TABLE [dbo].[SC_PROV001] CHECK CONSTRAINT [FK_PROV_REG]
GO
ALTER TABLE [dbo].[SC_REG001]  WITH CHECK ADD  CONSTRAINT [FK_Region_Pais] FOREIGN KEY([CODIGO_PAIS])
REFERENCES [dbo].[SC_PAIS001] ([CODIGO_PAIS])
GO
ALTER TABLE [dbo].[SC_REG001] CHECK CONSTRAINT [FK_Region_Pais]
GO
ALTER TABLE [dbo].[SC_SUC001]  WITH CHECK ADD  CONSTRAINT [FK_EMP_USU2] FOREIGN KEY([USUARIO_MODIFICACION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_SUC001] CHECK CONSTRAINT [FK_EMP_USU2]
GO
ALTER TABLE [dbo].[SC_SUC001]  WITH CHECK ADD  CONSTRAINT [FK_SUC_EMP] FOREIGN KEY([CODIGO_EMP])
REFERENCES [dbo].[SC_EMP001] ([CODIGO_EMP])
GO
ALTER TABLE [dbo].[SC_SUC001] CHECK CONSTRAINT [FK_SUC_EMP]
GO
ALTER TABLE [dbo].[SC_SUC001]  WITH CHECK ADD  CONSTRAINT [FK_SUC_PAIS] FOREIGN KEY([Cod_Pais])
REFERENCES [dbo].[SC_PAIS001] ([CODIGO_PAIS])
GO
ALTER TABLE [dbo].[SC_SUC001] CHECK CONSTRAINT [FK_SUC_PAIS]
GO
ALTER TABLE [dbo].[SC_SUC001]  WITH CHECK ADD  CONSTRAINT [FK_SUC_USU1] FOREIGN KEY([USUARIO_ADICCION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_SUC001] CHECK CONSTRAINT [FK_SUC_USU1]
GO
ALTER TABLE [dbo].[SC_SUC001]  WITH CHECK ADD  CONSTRAINT [FK_SUC_USU2] FOREIGN KEY([USUARIO_MODIFICACION])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[SC_SUC001] CHECK CONSTRAINT [FK_SUC_USU2]
GO
ALTER TABLE [dbo].[Suplidores]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Suplidores_dbo.Municipio_IdMunicipio] FOREIGN KEY([IdMunicipio])
REFERENCES [dbo].[Municipio] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Suplidores] CHECK CONSTRAINT [FK_dbo.Suplidores_dbo.Municipio_IdMunicipio]
GO
ALTER TABLE [dbo].[TipoMovimientoBanco]  WITH CHECK ADD FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[SC_EMP001] ([CODIGO_EMP])
GO
ALTER TABLE [dbo].[TipoMovimientoBanco]  WITH CHECK ADD FOREIGN KEY([IdUsuarioCrea])
REFERENCES [dbo].[SC_USUAR001] ([CODIGO_USUARIO])
GO
ALTER TABLE [dbo].[Versiones]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Versiones_dbo.Marca_IdMarca] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marca] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Versiones] CHECK CONSTRAINT [FK_dbo.Versiones_dbo.Marca_IdMarca]
GO
/****** Object:  StoredProcedure [dbo].[Models]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Models](@tabla varchar(100))
as
begin

declare @name varchar(50)
declare @type varchar(50)
declare @typeC varchar(50)

      --DECLARE AND SET COUNTER.
      DECLARE @Counter INT
      SET @Counter = 1
 
      --DECLARE THE CURSOR FOR A QUERY.
    
       declare listaColun   cursor READ_ONLY  for  select a.name, b.name from  sys.all_columns A, sys.systypes B
   where a.object_id=(select  c.object_id from sys.all_objects c
where name=@tabla) and B.xtype=A.user_type_id
 order by a.column_id 

      --OPEN CURSOR.
      OPEN listaColun
 

      --FETCH THE RECORD INTO THE VARIABLES.
      FETCH NEXT FROM listaColun INTO
       @name,@type
 
      --LOOP UNTIL RECORDS ARE AVAILABLE.
      WHILE @@FETCH_STATUS = 0
      BEGIN
             IF @type='varchar'
			 begin

			 set @typeC='string'; 
			  PRINT 'public '+ @typeC +' '+ @name +' { get; set; }'
			 end
			    IF @type='nvarchar'
			 begin

			 set @typeC='string'; 
			  PRINT 'public '+ @typeC +' '+ @name +' { get; set; }'
			 end
			 
			 
			  IF @type='bigint'
			 begin

			 set @typeC='long'; 
			  PRINT 'public '+ @typeC +' '+ @name +' { get; set; }'
			 end


			   IF @type='int'
			 begin

			 set @typeC='int'; 
			  PRINT 'public '+ @typeC +' '+ @name +' { get; set; }'
			 end

			  IF @type='date'
			 begin

			 set @typeC='DateTime'; 
			  PRINT 'public '+ @typeC +' '+ @name +' { get; set; }'
			 end
            
             IF @type='datetime'
			 begin

			 set @typeC='DateTime'; 
			  PRINT 'public '+ @typeC +' '+ @name +' { get; set; }'
			 end

			   IF @type='bit'
			 begin

			 set @typeC='bool'; 
			  PRINT 'public '+ @typeC +' '+ @name +' { get; set; }'
			 end
             --INCREMENT COUNTER.
             SET @Counter = @Counter + 1
 
             --FETCH THE NEXT RECORD INTO THE VARIABLES.
            FETCH NEXT FROM listaColun INTO
       @name,@type

      END
 
      --CLOSE THE CURSOR.
      CLOSE listaColun
      DEALLOCATE listaColun
	  end

GO
/****** Object:  StoredProcedure [dbo].[SP_SG_EMP001]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--DROP PROCEDURE SP_SG_EMP001;

CREATE PROCEDURE [dbo].[SP_SG_EMP001]
(@FLAG INT,
 @CODIGO_EMP INT,
 @NOMBRE_EMP VARCHAR(100),
 @LOGO_EMP VARCHAR(MAX),
 @RNC_EMP VARCHAR(15),
 @DIRECCION VARCHAR(300),
 @TELEFONO1 VARCHAR(15),
 @TELEFONO2 VARCHAR(15),
 @EXT_TEL1 VARCHAR(10),
 @EXT_TEL2 VARCHAR(10),
 @CANT_SUCURSALES INT,
 @CANT_USUARIO INT,
 @WEB VARCHAR(100),
 @USUARIO_ADICCION INT,
 @FECHA_ADICION DATETIME,
 @USUARIO_MODIFICACION INT,
 @FECHA_MODIFICACION DATETIME
) AS
BEGIN 

	IF(@FLAG=1)
		BEGIN
			SELECT *
			FROM SC_EMP001;
		END;

    IF(@FLAG=2)
		BEGIN
			INSERT INTO [SC_EMP001]
					([NOMBRE_EMP]
					,[LOGO_EMP]
					,[RNC_EMP]
					,[DIRECCION]
					,[TELEFONO1]
					,[TELEFONO2]
					,[EXT_TEL1]
					,[EXT_TEL2]
					,[CANT_SUCURSALES]
					,[CANT_USUARIO]
					,[WEB]
					,USUARIO_ADICCION
					,[FECHA_ADICION],
					 USUARIO_MODIFICACION,
                    FECHA_MODIFICACION )
				VALUES
					(@NOMBRE_EMP
					,@LOGO_EMP
					,@RNC_EMP
					,@DIRECCION
					,@TELEFONO1
					,@TELEFONO2
					,@EXT_TEL1
					,@EXT_TEL2
					,@CANT_SUCURSALES
					,@CANT_USUARIO
					,@WEB
					,@USUARIO_ADICCION
					,@FECHA_ADICION,
					0,
					GETDATE());
				
		END;

	IF(@FLAG=3)
		BEGIN
			UPDATE [dbo].[SC_EMP001]
			SET [NOMBRE_EMP] = @NOMBRE_EMP
				,[LOGO_EMP] = @LOGO_EMP
				,[RNC_EMP] = @RNC_EMP
				,[DIRECCION]= @DIRECCION
				,[TELEFONO1] = @TELEFONO1
				,[TELEFONO2] = @TELEFONO2
				,[EXT_TEL1] = @EXT_TEL1
				,[EXT_TEL2] = @EXT_TEL2
				,[CANT_SUCURSALES] = @CANT_SUCURSALES
				,[CANT_USUARIO] = @CANT_USUARIO
				,[WEB] = @WEB
				,[USUARIO_MODIFICACION] =  @USUARIO_ADICCION 
				,[FECHA_MODIFICACION] = GETDATE()
			WHERE  CODIGO_EMP = @CODIGO_EMP;
	    END;

	IF(@FLAG=4)
		BEGIN
			DELETE FROM [dbo].[SC_EMP001]
			WHERE  CODIGO_EMP = @CODIGO_EMP;
	    END;
END;




GO
/****** Object:  StoredProcedure [dbo].[spEmpresa]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[spEmpresa]
(@flag int,
@IDEmpresa int,
      @Empresa varchar(50),
      @Descripcion varchar(100),
      @RNC varchar(11),
      @Telefono varchar(50),
      @Telefono2 varchar(50),
      @Direccion varchar(50),
      @Dueno varchar(100),
      @Logo image
)
as
begin

if(@flag=1)
begin

SELECT *
      
  FROM [dbo].[gn_empresas]
end


if(@flag=2)
begin

SELECT *
  FROM [dbo].[gn_empresas] where [Empresa] like @Empresa+'%'
end

/* if (@flag=3)
begin
INSERT INTO [dbo].[Empresa]
           ([Empresa]
           ,[Descripcion]
           ,[RNC]
           ,[Telefono]
           ,[Telefono2]
           ,[Direccion]
           ,[Dueno]
           ,[Logo])
     VALUES
           (@Empresa
           ,@Descripcion
           ,@RNC 
           ,@Telefono
           ,@Telefono2
           ,@Direccion
           ,@Dueno
           ,@Logo)
end
if (@flag=4)
begin 

UPDATE [dbo].[Empresa]
   SET [Empresa] = @Empresa
      ,[Descripcion] = @Descripcion
      ,[RNC] = @RNC
      ,[Telefono] = @Telefono
      ,[Telefono2] = @Telefono2
      ,[Direccion] = @Direccion
      ,[Dueno] = @Dueno
      ,[Logo] = @Logo
 WHERE IDEmpresa = @IDEmpresa


end */
end

--spEmpresa 1,'',0,'','', '', '', '','','' 





GO
/****** Object:  StoredProcedure [dbo].[spMenu]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spMenu]
(
    @flag int,
	@IDMenu int ,
	@Menu nvarchar(50) ,
	@Nivel int,
	@Orden int,
	@URL nvarchar (100),
	@MenuIcon nvarchar(25)


)

as
 begin
 if(@flag=1)
 begin
SELECT [IDMenu]
      ,[Menu]
      ,[Nivel]
      ,[Orden]
      ,[URL]
      ,[MenuIcon]
  FROM [dbo].[gn_menu]

  
 
  end
  end






GO
/****** Object:  StoredProcedure [dbo].[spPermisos]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spPermisos]
(   @flag int,
	@IDPerminso bigint ,
	@IDPerfil int,
	@IDMenu int ,	
	@IDEmpresa bigint

)
as
begin

if(@flag =1)
begin
SELECT A.[IDPerminso]
      ,A.[IDPerfil]     
      
      ,A.[IDEmpresa]
	  ,A.[IDMenu]
	  ,B.Menu
	  ,B.MenuIcon
	  ,B.Nivel
	  ,B.Orden
	  ,B.[URL]

  FROM [dbo].[gn_permiso] as A inner join gn_menu B
  on A.IDMenu=B.IDMenu
  
  end

  if(@flag=2)
  begin
  SELECT [IDPerminso]
      ,[IDPerfil]
      ,[IDMenu]
     
      ,[IDEmpresa]
  FROM [dbo].[gn_permiso]
  end
  end





GO
/****** Object:  StoredProcedure [dbo].[spSucursal]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[spSucursal]
(          
@flag int,
 @FechaCreada date
           ,@Sucursal varchar(100)
           ,@Esquema varchar(50)
           ,@Telefono1 varchar(15)
           ,@Telefono2 varchar(15)
           ,@Email varchar(100)
           ,@SitoWeb varchar(100)
           ,@RNC varchar(100)
           ,@ID_Pais int
           ,@ID_Region int
           ,@ID_Provincia int
           ,@ID_Municipio int
           ,@ID_Sectores int
           ,@Direccion varchar(200)
           ,@logo varchar(max)
           ,@UltimaFechaModificacion date
           ,@Bloquear int
           ,@IP varchar(100)
           ,@IDEmpresa bigint

)
as
begin

if(@flag=1)
begin
SELECT [FechaCreada]
      ,[IDSucursal]
      ,[Sucursal]
      ,[Esquema]
      ,[Telefono1]
      ,[Telefono2]
      ,[Email]
      ,[SitoWeb]
      ,[RNC]
      ,[ID_Pais]
      ,[ID_Region]
      ,[ID_Provincia]
      ,[ID_Municipio]
      ,[ID_Sectores]
      ,[Direccion]
      ,[logo]
      ,[UltimaFechaModificacion]
      ,[Bloquear]
      ,[IP]
      ,[IDEmpresa]
  FROM [dbo].[gn_sucursal]
  end
  end






GO
/****** Object:  StoredProcedure [dbo].[spUsuario]    Script Date: 2/24/2022 8:11:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[spUsuario]
(
            @flag int,
			@FechaCreada date,
			@IDUsuario bigint
           ,@Usuario varchar(20)
           ,@PasswordUS varchar(100)
           ,@IDPerfil int
           ,@Nombre varchar(50)
           ,@Apellido varchar(100)
           ,@img varchar(max)
           ,@Cedula varchar(20)
           ,@Telefono varchar(15)
           ,@Email varchar(20)
           ,@ID_Pais int
           ,@ID_Region int
           ,@ID_Provincia int
           ,@ID_Municipio int
           ,@ID_Sectores int
           ,@Direccion varchar(200)
           ,@Cargo varchar(20)
           ,@IDEmpresa bigint
           ,@IDSucusal bigint
           ,@IDUSuarioCreador int
           ,@Bloquear int
           ,@UltimaFechaModificacion date

)
as
begin

if(@flag=1)

begin
SELECT [FechaCreada]
      ,[IDUsuario]
      ,[Usuario]
      ,[PasswordUS]
      ,[IDPerfil]
      ,[Nombre]
      ,[Apellido]
      ,[img]
      ,[Cedula]
      ,[Telefono]
      ,[Email]
      ,[ID_Pais]
      ,[ID_Region]
      ,[ID_Provincia]
      ,[ID_Municipio]
      ,[ID_Sectores]
      ,[Direccion]
      ,[Cargo]
      ,[IDEmpresa]
      ,[IDSucusal]
      ,[IDUSuarioCreador]
      ,[Bloquear]
      ,[UltimaFechaModificacion]
  FROM [dbo].[adm_Usuarios]
  end
  end







GO
USE [master]
GO
ALTER DATABASE [db_a82d6a_ptpdbtest] SET  READ_WRITE 
GO
