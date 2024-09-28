create table BovedaCaja
(
id int primary key identity (1,1),
Descripcion varchar(100),
MontoGeneral decimal(15,2),
idMoneda int,
FechaCreacion datetime,
UsuarioIDCrea int,
FechaActualizacion datetime,
UsuarioIDActualiza int,
idEmpresa bigint,
IdSucursal bigint,
idUsuarioResposable int
);

create table BovedaCajaDesglose
(
id int primary key identity (1,1),
idBoveda int,
idIdmoneda int, 
idbilletes_moneda varchar(1000),
Cantidad int,
idEmpresa bigint,
IdSucursal bigint
);

create table Billetes_Moneda
(
id int primary key identity (1,1),
descripcion varchar(100),
valor_BM decimal(15,2),
idMoneda int,
numeroOrden int,
idEmpresa bigint
);

create table Moneda
(
id int primary key identity (1,1),
descripcion varchar(100),
siglas varchar(10),
simbolo varchar(100),
idPais int,
idEmpresa bigint
);


create table TipoOperacionBoveda
(
Id  int primary key identity (1,1),
Codigo int,
Descripcion varchar(100),
Entrada_Salida varchar(1),---si se le suma o resta
idMoneda int,
UsuarioIDCrea int,
FechaCreacion datetime,
FechaActualizacion datetime,
UsuarioIDActualiza int,
idEmpresa bigint
);


create table BovedaMovimiento
(
Id  int primary key identity (1,1),
idMoneda int,
idTipoOperacionBoveda int,
Descripcion varchar(400),
Entrada_Salida varchar(1),
valorTotalMovimiento decimal(15,2),
idDesgloseXcajero int,--si es un moviento de inicio o cierre de caja
FechaCreacion datetime,
UsuarioIDCrea int,
FechaActualizacion datetime,
UsuarioIDActualiza int,
idEmpresa bigint,
IdSucursal bigint
);

create table DesgloseXcajero
(Id  int primary key identity (1,1),
 idBilletes_Moneda int,
 catidadBillete int,
 idCaja int,
 idUsuarioResposable int,
 tipoDesglose varchar(1), --I=Inicio C=Cierre
 FechaCreacion datetime,
 UsuarioIDCrea int,
 FechaActualizacion datetime,
 UsuarioIDActualiza int,
 idEmpresa bigint,
 IdSucursal bigint
)

CREATE TABLE Caja
(Id  int primary key identity (1,1),
 numeroCaja int,
 NombreCaja varchar(30),
 idUsuarioResposable int,
 UsuarioIDCrea int,
 FechaActualizacion datetime,
 UsuarioIDActualiza int,
 EstadoCaja varchar(4),--A=abierta C=cerrada E=Eliminada,I=inavilitada, SNI=sin iniciar SNC =sinCerrar
 idEmpresa bigint,
 IdSucursal bigint
);

create table DescuadrexCajero
(
Id  int primary key identity (1,1),
idDesgloseXcajero int,
Observaciones varchar(400),
TipoDescuadre varchar(1), --E=Excedente F--Faltante
valor_Total decimal(15,2),
valor_real decimal(15,2),
idEmpresa bigint,
IdSucursal bigint

);

create table DescuadrexCajeroDesglose
(
Id  int primary key identity (1,1),
idDescuadre int,
idMoneda int,
idbilleteMoneda int,
idEmpresa bigint,
IdSucursal bigint
);