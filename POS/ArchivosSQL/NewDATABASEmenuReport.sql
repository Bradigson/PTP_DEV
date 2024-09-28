USE [master]
GO
/****** Object:  Database [PosMenuReport]    Script Date: 7/9/2018 2:36:06 a.m. ******/
CREATE DATABASE [PosMenuReport]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PosMenuReport', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PosMenuReport.mdf' , SIZE = 9408KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PosMenuReport_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PosMenuReport_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PosMenuReport] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PosMenuReport].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PosMenuReport] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PosMenuReport] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PosMenuReport] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PosMenuReport] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PosMenuReport] SET ARITHABORT OFF 
GO
ALTER DATABASE [PosMenuReport] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PosMenuReport] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PosMenuReport] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PosMenuReport] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PosMenuReport] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PosMenuReport] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PosMenuReport] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PosMenuReport] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PosMenuReport] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PosMenuReport] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PosMenuReport] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PosMenuReport] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PosMenuReport] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PosMenuReport] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PosMenuReport] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PosMenuReport] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PosMenuReport] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PosMenuReport] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PosMenuReport] SET  MULTI_USER 
GO
ALTER DATABASE [PosMenuReport] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PosMenuReport] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PosMenuReport] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PosMenuReport] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PosMenuReport] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PosMenuReport]
GO
/****** Object:  Table [dbo].[adm_Usuarios]    Script Date: 7/9/2018 2:36:06 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[gn_empresas]    Script Date: 7/9/2018 2:36:06 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[gn_menu]    Script Date: 7/9/2018 2:36:06 a.m. ******/
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
	[MenuIcon] [nvarchar](25) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[gn_perfil]    Script Date: 7/9/2018 2:36:06 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[gn_perfil](
	[FechaCreada] [date] NULL,
	[IDPerfil] [int] NOT NULL,
	[Perfil] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[IDUsuario] [bigint] NULL,
	[Bloquear] [int] NULL,
	[UltimaFechaModificacion] [date] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[gn_permiso]    Script Date: 7/9/2018 2:36:06 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gn_permiso](
	[IDPerminso] [bigint] NOT NULL,
	[IDPerfil] [int] NULL,
	[IDMenu] [int] NULL,
	[IDSucursal] [bigint] NULL,
	[IDEmpresa] [bigint] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[gn_sucursal]    Script Date: 7/9/2018 2:36:06 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
INSERT [dbo].[adm_Usuarios] ([FechaCreada], [IDUsuario], [Usuario], [PasswordUS], [IDPerfil], [Nombre], [Apellido], [img], [Cedula], [Telefono], [Email], [ID_Pais], [ID_Region], [ID_Provincia], [ID_Municipio], [ID_Sectores], [Direccion], [Cargo], [IDEmpresa], [IDSucusal], [IDUSuarioCreador], [Bloquear], [UltimaFechaModificacion]) VALUES (CAST(N'2018-07-10' AS Date), 100, N'amendez', N'123', 10, N'Anthony', N'Mendez', N'Imagenes/Users/user01.jpg', N'02200', N'8097100000', N'antony00@htomail.com', 1, 1, 1, 1, 1, N'1', N'Cagero', 1003, 1000, 1, 0, NULL)
INSERT [dbo].[gn_empresas] ([FechaCreada], [IDEmpresa], [Empresa], [ServidorDB], [UsuarioDB], [PasswordDB], [DBnombre], [IP]) VALUES (CAST(N'2018-07-10' AS Date), 1003, N'Luner', N'ninguno', N'ninguna', N'12', N'11', N'1')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (1, N'Productos', 0, 3, NULL, N' fa fa-list-ol')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (2, N'Facturacion', 0, 1, NULL, N'fa  fa-cart-plus')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (3, N'Cofiguracion', 0, 100, NULL, N'fa  fa-cog')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (4, N'Productos', 1, 1, N'Productos', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (5, N'Marcas', 1, 2, N'Marcas', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (6, N'Version', 1, 3, N'Version', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (7, N'Envase', 1, 4, N'Envase', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (8, N'Asig. Precios', 1, 5, N'Precios', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (9, N'Compras', 0, 4, NULL, N'fa fa-truck')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (10, N'Pedios', 9, 1, N'Pedidos', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (11, N'Cuentas por Pagar(CXP)', 9, 2, N'CuentasPorPagar', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (12, N'Descuento', 1, 5, N'Descuentos', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (13, N'Inventario ', 0, 2, NULL, N'fa  fa-cubes')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (14, N'Movimiento al Inventario', 13, 1, N'MovimientoAlmacen', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (15, N'Almacen', 13, 2, N'Almacenes', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (16, N'Inventario Actual', 13, 3, N'MovimientoAlmacen/ListaProductos', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (17, N'Suplidores', 0, 6, N'', N'fa  fa-user')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (18, N'Crear Suplidores', 17, 1, N'Suplidores', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (19, N'Crear Factura', 2, 1, N'Facturacion', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (20, N'Clientes', 0, 6, NULL, N' fa fa-user-plus')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (21, N'Crear Clientes', 20, 1, N'Clientes', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (22, N'Cuentas por Cobrar (CxC)', 20, 2, N'CuentasPorCobrar', N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (23, N'Crear Usuario ', 3, 1, NULL, N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (24, N'Crear Perfil', 3, 2, NULL, N'fa fa-circle-o')
INSERT [dbo].[gn_menu] ([IDMenu], [Menu], [Nivel], [Orden], [URL], [MenuIcon]) VALUES (25, N'Asignar Permisos', 3, 3, NULL, N'fa fa-circle-o')
INSERT [dbo].[gn_perfil] ([FechaCreada], [IDPerfil], [Perfil], [Descripcion], [IDUsuario], [Bloquear], [UltimaFechaModificacion]) VALUES (CAST(N'2018-07-10' AS Date), 10, N'Administrador', N'en', 1, NULL, NULL)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (1, 10, 1, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (2, 10, 2, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (3, 10, 3, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (4, 10, 4, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (5, 10, 5, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (6, 10, 6, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (7, 10, 7, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (8, 10, 8, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (9, 10, 9, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (10, 10, 10, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (11, 10, 11, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (12, 10, 12, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (13, 10, 13, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (14, 10, 14, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (15, 10, 15, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (16, 10, 16, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (17, 10, 17, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (18, 10, 18, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (19, 10, 19, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (20, 10, 20, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (21, 10, 21, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (22, 10, 22, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (23, 10, 23, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (24, 10, 24, 1000, 1003)
INSERT [dbo].[gn_permiso] ([IDPerminso], [IDPerfil], [IDMenu], [IDSucursal], [IDEmpresa]) VALUES (25, 10, 25, 1000, 1003)
INSERT [dbo].[gn_sucursal] ([FechaCreada], [IDSucursal], [Sucursal], [Esquema], [Telefono1], [Telefono2], [Email], [SitoWeb], [RNC], [ID_Pais], [ID_Region], [ID_Provincia], [ID_Municipio], [ID_Sectores], [Direccion], [logo], [UltimaFechaModificacion], [Bloquear], [IP], [IDEmpresa]) VALUES (CAST(N'2018-07-10' AS Date), 1000, N'Luner Principal', N'dbo', N'8097170000', N'8291234569', N'Luner@hotmail.com', N'luner.com', N'12312312312', 1, 1, 1, 1, 1, N'1', N'Imagenes/Company/company01.jpg', CAST(N'2018-07-10' AS Date), 0, N'1', 1003)
/****** Object:  StoredProcedure [dbo].[spEmpresa]    Script Date: 7/9/2018 2:36:07 a.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spMenu]    Script Date: 7/9/2018 2:36:07 a.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spPermisos]    Script Date: 7/9/2018 2:36:07 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spPermisos]
(   @flag int,
	@IDPerminso bigint ,
	@IDPerfil int,
	@IDMenu int ,
	@IDSucursal bigint ,
	@IDEmpresa bigint

)
as
begin

if(@flag =1)
begin
SELECT A.[IDPerminso]
      ,A.[IDPerfil]      
      ,A.[IDSucursal]
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
      ,[IDSucursal]
      ,[IDEmpresa]
  FROM [dbo].[gn_permiso]
  end
  end




GO
/****** Object:  StoredProcedure [dbo].[spSucursal]    Script Date: 7/9/2018 2:36:07 a.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spUsuario]    Script Date: 7/9/2018 2:36:07 a.m. ******/
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
ALTER DATABASE [PosMenuReport] SET  READ_WRITE 
GO
