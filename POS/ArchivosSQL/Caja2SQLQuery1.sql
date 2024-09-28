create table Bancos
( 
Id int primary key identity(1,1),
Banco varchar(100) not null,
FechaCreacion date,
idUsuarioCrea int,
FechaModificacion date,
Estado bit,
IdEmpresa bigInt,
IdSucursal bigInt,
FOREIGN KEY (IdEmpresa) REFERENCES  [dbo].[SC_EMP001](CODIGO_EMP),
FOREIGN KEY (IdSucursal) REFERENCES [dbo].[SC_SUC001](CODIGO_SUC)
);

create table CuentaBancos
(
Id int primary key identity(1,1),
IdBanco int ,
IdMoneda int,
NombreCuenta varchar(100) not null,
NumeroCuenta varchar(100) not null,
Balance decimal,
BalanceAnterior decimal,
FechaCreacion date,
idUsuarioCrea int,
FechaModificacion date,
Estado bit,
IdEmpresa bigInt,
IdSucursal bigInt,
FOREIGN KEY (IdBanco) REFERENCES Bancos(id),
FOREIGN KEY (IdMoneda) REFERENCES Moneda(id),
FOREIGN KEY (IdEmpresa) REFERENCES  [dbo].[SC_EMP001](CODIGO_EMP),
FOREIGN KEY (IdSucursal) REFERENCES [dbo].[SC_SUC001](CODIGO_SUC)
);
create table  TipoMovimientoBanco
(
Id bigint primary key identity(1,1),
Descripcion varchar(100) not null,
FechaCreacion date,
DebitoCreditootro varchar(1),
InternoExterno varchar(1),
IdUsuarioCrea int,
Estado bit,
IdEmpresa bigInt,
FOREIGN KEY (IdUsuarioCrea) REFERENCES [SC_USUAR001](CODIGO_USUARIO),
FOREIGN KEY (IdEmpresa) REFERENCES  [dbo].[SC_EMP001](CODIGO_EMP)
);
--del banco a lo interno o externo
create table MovimientoBanco
(
Id bigint primary key identity(1,1),
IdBanco int,
Monto decimal,
Fecha_movimiento date,
Detalle varchar(200),
idTipoMovimientoBanco int,
idUsuario int,
IdEmpresa bigInt,
IdSucursal bigInt,
IdMoneda int,
FOREIGN KEY (idUsuario) REFERENCES [SC_USUAR001](CODIGO_USUARIO),
FOREIGN KEY (IdEmpresa) REFERENCES  [dbo].[SC_EMP001](CODIGO_EMP),
FOREIGN KEY (IdSucursal) REFERENCES [dbo].[SC_SUC001](CODIGO_SUC)
);


select * from [dbo].[BovedaCaja]
select * from [dbo].[BovedaCajaDesglose]
select * from [dbo].[BovedaMovimiento]
select * from [dbo].[Billetes_Moneda]
select * from [dbo].[Caja]

create table AperturaCierreCaja
(
 id bigint primary key identity(1,1),
 Fecha_apertura date,
 AperturCierre varchar(1),
 MontoInicio  decimal,
 MontoConfirmado decimal,
 idCaja int,
 DeclaroFatante varchar(1),
 MontoFaltante decimal,
 DeclaroExcedente decimal,
 MontoExcedente decimal,
 IdMoneda int,
 idUsuarioReponCaja int,
 MotoEfectivoCierre decimal,
 totalOperacionesEfectivo int,
 MontoTarjetaOtransferenciaCierre decimal,
 totalOperacionesTajeta int,
 MontoGeneral decimal,
 ConciliadoAlCuadre varchar(1),
 idUsuarioConfirmaCO int,
 ConciliarTJoTransaferencia varchar(1),
 idUsuarioConfirmaTjoTF int,
 idConciliacion int,
 FechaCoinciliacionTJoTF date,
 IdEmpresa bigInt,
 IdSucursal bigInt,
 FOREIGN KEY (IdEmpresa) REFERENCES  [dbo].[SC_EMP001](CODIGO_EMP),
 FOREIGN KEY (IdSucursal) REFERENCES [dbo].[SC_SUC001](CODIGO_SUC),
 FOREIGN KEY (idUsuarioConfirmaTjoTF) REFERENCES [SC_USUAR001](CODIGO_USUARIO),
 FOREIGN KEY (idUsuarioConfirmaCO) REFERENCES [SC_USUAR001](CODIGO_USUARIO),
 FOREIGN KEY (idUsuarioReponCaja) REFERENCES [SC_USUAR001](CODIGO_USUARIO),
 FOREIGN KEY (IdMoneda) REFERENCES moneda(id),
 FOREIGN KEY (idCaja) REFERENCES caja(id),

);

create table ConciliacionTCTF
(
 id bigint primary key identity(1,1),
 idCaja int,
 idFactura int,
 idMoneda int,
 montoPagadoTCTF decimal,
 [VTnoAuth] varchar(50),
 [VT4digit] int,
 montoPagadoTCTFEX decimal,
 VTnoAuthEX varchar(50),
 VT4digitEX int,
 Conciliado varchar(1),
 IdEmpresa bigInt,
 IdSucursal bigInt,
 FOREIGN KEY (IdEmpresa) REFERENCES  [dbo].[SC_EMP001](CODIGO_EMP),
 FOREIGN KEY (IdSucursal) REFERENCES [dbo].[SC_SUC001](CODIGO_SUC),
 FOREIGN KEY (IdMoneda) REFERENCES moneda(id),
 FOREIGN KEY (idCaja) REFERENCES caja(id),
 FOREIGN KEY (idFactura) REFERENCES Facturacion(id)
)


