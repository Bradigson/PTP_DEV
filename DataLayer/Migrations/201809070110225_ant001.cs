namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ant001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Almacenes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 60),
                        Direccion = c.String(nullable: false, maxLength: 100),
                        Telefono = c.String(nullable: false, maxLength: 20),
                        IdUSuarioACargo = c.Int(nullable: false),
                        IdMunicipio = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Municipio", t => t.IdMunicipio, cascadeDelete: true)
                .Index(t => t.IdMunicipio);
            
            CreateTable(
                "dbo.Municipio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        IdProvincia = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provincia", t => t.IdProvincia, cascadeDelete: true)
                .Index(t => t.IdProvincia);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        IdRegion = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Region", t => t.IdRegion, cascadeDelete: true)
                .Index(t => t.IdRegion);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        IdPais = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pais", t => t.IdPais, cascadeDelete: true)
                .Index(t => t.IdPais);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaModificacion = c.DateTime(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 40),
                        Apellido = c.String(maxLength: 40),
                        Cedula = c.String(maxLength: 20),
                        Rnc = c.String(maxLength: 20),
                        Empresa = c.String(maxLength: 100),
                        Direccion = c.String(maxLength: 100),
                        Referencia = c.String(maxLength: 100),
                        Imagen = c.String(),
                        Email = c.String(maxLength: 70),
                        Telefono1 = c.String(maxLength: 20),
                        Telefono2 = c.String(maxLength: 20),
                        IdMunicipio = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Municipio", t => t.IdMunicipio, cascadeDelete: true)
                .Index(t => t.IdMunicipio);
            
            CreateTable(
                "dbo.ContactosSuplidores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSuplidor = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Telefono1 = c.String(nullable: false, maxLength: 30),
                        Telefono2 = c.String(maxLength: 30),
                        Extension = c.String(maxLength: 30),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suplidores", t => t.IdSuplidor, cascadeDelete: true)
                .Index(t => t.IdSuplidor);
            
            CreateTable(
                "dbo.Suplidores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 60),
                        Rnc = c.Int(nullable: false),
                        Telefono = c.String(nullable: false, maxLength: 20),
                        Direccion = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 40),
                        IdMunicipio = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Municipio", t => t.IdMunicipio, cascadeDelete: true)
                .Index(t => t.IdMunicipio);
            
            CreateTable(
                "dbo.CuentasPorCobrar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacturacionId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        MontoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MontoInicial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MontoPendiente = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaUltimoPago = c.DateTime(nullable: false),
                        FechaLimite = c.DateTime(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Facturacion", t => t.FacturacionId, cascadeDelete: true)
                .Index(t => t.FacturacionId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.DetalleCuentasPorCobrar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CuentasPorCobrarId = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaPago = c.DateTime(nullable: false),
                        IsCalceled = c.Boolean(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CuentasPorCobrar", t => t.CuentasPorCobrarId, cascadeDelete: true)
                .Index(t => t.CuentasPorCobrarId);
            
            CreateTable(
                "dbo.Facturacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        NoFactura = c.String(),
                        Ncf = c.String(),
                        SecuenciaId = c.Int(nullable: false),
                        Comentario = c.String(),
                        TipoTransaccionId = c.Int(nullable: false),
                        TipoPagoId = c.Int(nullable: false),
                        MontoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsCanceled = c.Boolean(nullable: false),
                        IsReturned = c.Boolean(nullable: false),
                        Justificacion = c.String(),
                        TotalDescuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalItbis = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CantidadProductos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: false)
                .ForeignKey("dbo.DgiiNcfSecuencia", t => t.SecuenciaId, cascadeDelete: true)
                .ForeignKey("dbo.TipoPago", t => t.TipoPagoId, cascadeDelete: true)
                .ForeignKey("dbo.TipoTransaccion", t => t.TipoTransaccionId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.SecuenciaId)
                .Index(t => t.TipoTransaccionId)
                .Index(t => t.TipoPagoId);
            
            CreateTable(
                "dbo.DgiiNcfSecuencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerieTipoComprobante = c.String(maxLength: 3),
                        Secuecial = c.Int(nullable: false),
                        IdDgiiNcf = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DgiiNcf", t => t.IdDgiiNcf, cascadeDelete: true)
                .Index(t => t.IdDgiiNcf);
            
            CreateTable(
                "dbo.DgiiNcf",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Serie = c.String(),
                        TipoComprobante = c.String(),
                        SecuencialInicial = c.String(),
                        SecuenciaDgii = c.String(),
                        FechaVencimiento = c.DateTime(nullable: false),
                        usuario = c.String(),
                        usuarioUltimaModificacion = c.String(),
                        FechaModificacion = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoPago",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoTransaccion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CuentasPorPagar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                        MontoInicial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MontoDeuda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Restante = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaUltimoPago = c.DateTime(nullable: false),
                        FechaLimitePago = c.DateTime(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        IdMovimientoAlmacen = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovimientoAlmacen", t => t.IdMovimientoAlmacen, cascadeDelete: true)
                .Index(t => t.IdMovimientoAlmacen);
            
            CreateTable(
                "dbo.DetalleCuentaPorPagar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCuentaPorPagar = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaPago = c.DateTime(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        IsCanceled = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CuentasPorPagar", t => t.IdCuentaPorPagar, cascadeDelete: true)
                .Index(t => t.IdCuentaPorPagar);
            
            CreateTable(
                "dbo.MovimientoAlmacen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSuplidor = c.Int(nullable: false),
                        IdTipoMovimiento = c.Int(nullable: false),
                        NoFactura = c.String(nullable: false, maxLength: 30),
                        Ncf = c.String(maxLength: 30),
                        CantidadProducto = c.Int(nullable: false),
                        TotalFacturado = c.Long(nullable: false),
                        IdAlmacen = c.Int(nullable: false),
                        IdTipoPago = c.Int(nullable: false),
                        Motivo = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Almacenes", t => t.IdAlmacen, cascadeDelete: true)
                .ForeignKey("dbo.Suplidores", t => t.IdSuplidor, cascadeDelete: false)
                .ForeignKey("dbo.TipoMovimiento", t => t.IdTipoMovimiento, cascadeDelete: true)
                .ForeignKey("dbo.TipoPago", t => t.IdTipoPago, cascadeDelete: true)
                .Index(t => t.IdSuplidor)
                .Index(t => t.IdTipoMovimiento)
                .Index(t => t.IdAlmacen)
                .Index(t => t.IdTipoPago);
            
            CreateTable(
                "dbo.DetalleMovimientoAlmacen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMovimiento = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovimientoAlmacen", t => t.IdMovimiento, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdMovimiento)
                .Index(t => t.IdProducto);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(maxLength: 250),
                        IdVersion = c.Int(nullable: false),
                        IdEnvase = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        EsLote = c.Boolean(nullable: false),
                        CantidadLote = c.Int(nullable: false),
                        CantidadInventario = c.Int(nullable: false),
                        PrecioBase = c.Double(nullable: false),
                        PrecioCompra = c.Double(nullable: false),
                        CantidadMinima = c.Int(nullable: false),
                        CodigoBarra = c.String(nullable: false, maxLength: 50),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Envase", t => t.IdEnvase, cascadeDelete: true)
                .ForeignKey("dbo.Versiones", t => t.IdVersion, cascadeDelete: true)
                .Index(t => t.IdVersion)
                .Index(t => t.IdEnvase);
            
            CreateTable(
                "dbo.Descuentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProducto = c.Int(nullable: false),
                        DescuentoPorcentaje = c.Int(nullable: false),
                        DescuentoFijo = c.Int(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        TipoDescuento = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        NombreProducto = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producto", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdProducto);
            
            CreateTable(
                "dbo.Envase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Imagen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        Descripcion = c.String(),
                        FechaModificacion = c.DateTime(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                        Producto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producto", t => t.Producto_Id)
                .Index(t => t.Producto_Id);
            
            CreateTable(
                "dbo.Precio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        NumSeq = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producto", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Versiones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Activo = c.Boolean(nullable: false),
                        IdMarca = c.Int(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marca", t => t.IdMarca, cascadeDelete: true)
                .Index(t => t.IdMarca);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Activo = c.Boolean(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoMovimiento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleFacturacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacturacionId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Int(nullable: false),
                        Itbis = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facturacion", t => t.FacturacionId, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.FacturacionId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.DetallePedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producto", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdProducto);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSuplidor = c.Int(nullable: false),
                        Solicitado = c.Boolean(nullable: false),
                        Estado = c.Int(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suplidores", t => t.IdSuplidor, cascadeDelete: true)
                .Index(t => t.IdSuplidor);
            
            CreateTable(
                "dbo.PedidoDetallePedido",
                c => new
                    {
                        Pedido_Id = c.Int(nullable: false),
                        DetallePedido_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pedido_Id, t.DetallePedido_Id })
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id, cascadeDelete: true)
                .ForeignKey("dbo.DetallePedido", t => t.DetallePedido_Id, cascadeDelete: true)
                .Index(t => t.Pedido_Id)
                .Index(t => t.DetallePedido_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetallePedido", "IdProducto", "dbo.Producto");
            DropForeignKey("dbo.Pedido", "IdSuplidor", "dbo.Suplidores");
            DropForeignKey("dbo.PedidoDetallePedido", "DetallePedido_Id", "dbo.DetallePedido");
            DropForeignKey("dbo.PedidoDetallePedido", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.DetalleFacturacion", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.DetalleFacturacion", "FacturacionId", "dbo.Facturacion");
            DropForeignKey("dbo.CuentasPorPagar", "IdMovimientoAlmacen", "dbo.MovimientoAlmacen");
            DropForeignKey("dbo.MovimientoAlmacen", "IdTipoPago", "dbo.TipoPago");
            DropForeignKey("dbo.MovimientoAlmacen", "IdTipoMovimiento", "dbo.TipoMovimiento");
            DropForeignKey("dbo.MovimientoAlmacen", "IdSuplidor", "dbo.Suplidores");
            DropForeignKey("dbo.DetalleMovimientoAlmacen", "IdProducto", "dbo.Producto");
            DropForeignKey("dbo.Producto", "IdVersion", "dbo.Versiones");
            DropForeignKey("dbo.Versiones", "IdMarca", "dbo.Marca");
            DropForeignKey("dbo.Precio", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.Imagen", "Producto_Id", "dbo.Producto");
            DropForeignKey("dbo.Producto", "IdEnvase", "dbo.Envase");
            DropForeignKey("dbo.Descuentos", "IdProducto", "dbo.Producto");
            DropForeignKey("dbo.DetalleMovimientoAlmacen", "IdMovimiento", "dbo.MovimientoAlmacen");
            DropForeignKey("dbo.MovimientoAlmacen", "IdAlmacen", "dbo.Almacenes");
            DropForeignKey("dbo.DetalleCuentaPorPagar", "IdCuentaPorPagar", "dbo.CuentasPorPagar");
            DropForeignKey("dbo.CuentasPorCobrar", "FacturacionId", "dbo.Facturacion");
            DropForeignKey("dbo.Facturacion", "TipoTransaccionId", "dbo.TipoTransaccion");
            DropForeignKey("dbo.Facturacion", "TipoPagoId", "dbo.TipoPago");
            DropForeignKey("dbo.Facturacion", "SecuenciaId", "dbo.DgiiNcfSecuencia");
            DropForeignKey("dbo.DgiiNcfSecuencia", "IdDgiiNcf", "dbo.DgiiNcf");
            DropForeignKey("dbo.Facturacion", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.DetalleCuentasPorCobrar", "CuentasPorCobrarId", "dbo.CuentasPorCobrar");
            DropForeignKey("dbo.CuentasPorCobrar", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Suplidores", "IdMunicipio", "dbo.Municipio");
            DropForeignKey("dbo.ContactosSuplidores", "IdSuplidor", "dbo.Suplidores");
            DropForeignKey("dbo.Cliente", "IdMunicipio", "dbo.Municipio");
            DropForeignKey("dbo.Almacenes", "IdMunicipio", "dbo.Municipio");
            DropForeignKey("dbo.Municipio", "IdProvincia", "dbo.Provincia");
            DropForeignKey("dbo.Provincia", "IdRegion", "dbo.Region");
            DropForeignKey("dbo.Region", "IdPais", "dbo.Pais");
            DropIndex("dbo.PedidoDetallePedido", new[] { "DetallePedido_Id" });
            DropIndex("dbo.PedidoDetallePedido", new[] { "Pedido_Id" });
            DropIndex("dbo.Pedido", new[] { "IdSuplidor" });
            DropIndex("dbo.DetallePedido", new[] { "IdProducto" });
            DropIndex("dbo.DetalleFacturacion", new[] { "ProductoId" });
            DropIndex("dbo.DetalleFacturacion", new[] { "FacturacionId" });
            DropIndex("dbo.Versiones", new[] { "IdMarca" });
            DropIndex("dbo.Precio", new[] { "ProductoId" });
            DropIndex("dbo.Imagen", new[] { "Producto_Id" });
            DropIndex("dbo.Descuentos", new[] { "IdProducto" });
            DropIndex("dbo.Producto", new[] { "IdEnvase" });
            DropIndex("dbo.Producto", new[] { "IdVersion" });
            DropIndex("dbo.DetalleMovimientoAlmacen", new[] { "IdProducto" });
            DropIndex("dbo.DetalleMovimientoAlmacen", new[] { "IdMovimiento" });
            DropIndex("dbo.MovimientoAlmacen", new[] { "IdTipoPago" });
            DropIndex("dbo.MovimientoAlmacen", new[] { "IdAlmacen" });
            DropIndex("dbo.MovimientoAlmacen", new[] { "IdTipoMovimiento" });
            DropIndex("dbo.MovimientoAlmacen", new[] { "IdSuplidor" });
            DropIndex("dbo.DetalleCuentaPorPagar", new[] { "IdCuentaPorPagar" });
            DropIndex("dbo.CuentasPorPagar", new[] { "IdMovimientoAlmacen" });
            DropIndex("dbo.DgiiNcfSecuencia", new[] { "IdDgiiNcf" });
            DropIndex("dbo.Facturacion", new[] { "TipoPagoId" });
            DropIndex("dbo.Facturacion", new[] { "TipoTransaccionId" });
            DropIndex("dbo.Facturacion", new[] { "SecuenciaId" });
            DropIndex("dbo.Facturacion", new[] { "ClienteId" });
            DropIndex("dbo.DetalleCuentasPorCobrar", new[] { "CuentasPorCobrarId" });
            DropIndex("dbo.CuentasPorCobrar", new[] { "ClienteId" });
            DropIndex("dbo.CuentasPorCobrar", new[] { "FacturacionId" });
            DropIndex("dbo.Suplidores", new[] { "IdMunicipio" });
            DropIndex("dbo.ContactosSuplidores", new[] { "IdSuplidor" });
            DropIndex("dbo.Cliente", new[] { "IdMunicipio" });
            DropIndex("dbo.Region", new[] { "IdPais" });
            DropIndex("dbo.Provincia", new[] { "IdRegion" });
            DropIndex("dbo.Municipio", new[] { "IdProvincia" });
            DropIndex("dbo.Almacenes", new[] { "IdMunicipio" });
            DropTable("dbo.PedidoDetallePedido");
            DropTable("dbo.Pedido");
            DropTable("dbo.DetallePedido");
            DropTable("dbo.DetalleFacturacion");
            DropTable("dbo.TipoMovimiento");
            DropTable("dbo.Marca");
            DropTable("dbo.Versiones");
            DropTable("dbo.Precio");
            DropTable("dbo.Imagen");
            DropTable("dbo.Envase");
            DropTable("dbo.Descuentos");
            DropTable("dbo.Producto");
            DropTable("dbo.DetalleMovimientoAlmacen");
            DropTable("dbo.MovimientoAlmacen");
            DropTable("dbo.DetalleCuentaPorPagar");
            DropTable("dbo.CuentasPorPagar");
            DropTable("dbo.TipoTransaccion");
            DropTable("dbo.TipoPago");
            DropTable("dbo.DgiiNcf");
            DropTable("dbo.DgiiNcfSecuencia");
            DropTable("dbo.Facturacion");
            DropTable("dbo.DetalleCuentasPorCobrar");
            DropTable("dbo.CuentasPorCobrar");
            DropTable("dbo.Suplidores");
            DropTable("dbo.ContactosSuplidores");
            DropTable("dbo.Cliente");
            DropTable("dbo.Pais");
            DropTable("dbo.Region");
            DropTable("dbo.Provincia");
            DropTable("dbo.Municipio");
            DropTable("dbo.Almacenes");
        }
    }
}
