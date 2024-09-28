using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataLayer.Models;
using DataLayer.Models.MenuApp;
using DataLayer.Models.Caja;

namespace DataLayer.PDbContex
{
   public  class PDbContext:DbContext
    {
        public PDbContext():base("POS2")
        {
            Database.SetInitializer<PDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();           
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pais> Paises { get; set; }

        public DbSet<Region> Regiones { get; set; }

        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Municipio> Municipios { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Imagen> ImagenesProducto { get; set; }

        public DbSet<Versiones> Versiones{ get; set; }

        public DbSet<Envase> Envases { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Descuentos> Descuentos { get; set; }
        
        public DbSet<Almacenes> Almacenes { get; set; }

        public DbSet<TipoMovimiento> TipoMovimientos { get; set; }

        public DbSet<TipoPago> TipoPagos { get; set; }

        public DbSet<MovimientoAlmacen> MovimientoAlmacenes { get; set; }

        public DbSet<DetalleMovimientoAlmacen> DetalleMovimientoAlmacenes { get; set; }

        public DbSet<CuentasPorPagar> CuentasPorPagar { get; set; }

        public DbSet<DetalleCuentaPorPagar> DetalleCuentaPorPagar { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Suplidores> Suplidores { get; set; }

        public DbSet<ContactosSuplidores> ContactosSuplidores { get; set; }

        public DbSet<DgiiNcfSecuencia> DgiiNcfSecuencia { get; set; }

        public DbSet<DgiiNcf> DgiiNcf { get; set; }

        public DbSet<Precio> Precios { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<DetallePedido> DetallePedido { get; set; }

        public DbSet<Facturacion> Facturacion { get; set; }

        public DbSet<DetalleFacturacion> DetalleFacturacion { get; set; }

        public DbSet<TipoTransaccion> TipoTransaccion { get; set; }

        public DbSet<CuentasPorCobrar> CuentasPorCobrar { get; set; }

        public DbSet<DetalleCuentasPorCobrar> DetalleCuentasPorCobrar { get; set; }

        public DbSet<Cotizacion> Cotizacion { get; set; }

        public DbSet<DetalleCotizacion> DetalleCotizacion { get; set; }
        public DbSet<Gn_Perfil> Gn_Perfil { get; set; }//cambiar despues
        public DbSet<Gn_Permiso> Gn_Permiso { get; set; }
        public DbSet<Gn_Menu> Gn_Menu { get; set; }
        

        //Nuevas clases

        //MODULO DE SEGURIDAD

        public DbSet<SC_EMP001> SC_EMP001  { get; set; }
        public DbSet<SC_SUC001> SC_SUC001 { get; set; }
        public DbSet<SC_HORA_X_USR002> SC_HORA_X_USR002 { get; set; }
        public DbSet<SC_HORAGROUP002> SC_HORAGROUP002 { get; set; }
        public DbSet<SC_HORARIO001> SC_HORARIO001 { get; set; }
        public DbSet<SC_IMP001> SC_IMP001 { get; set; }
        public DbSet<SC_IPSYS001> SC_IPSYS001 { get; set; }
        public DbSet<SC_MUNIC001> SC_MUNIC001 { get; set; }
        public DbSet<SC_PAIS001> SC_PAIS001 { get; set; }
        public DbSet<SC_PROV001> SC_PROV001 { get; set; }
        public DbSet<SC_REG001> SC_REG001 { get; set; }
        public DbSet<SC_USUAR001> SC_USUAR001 { get; set; }
       
        
        public DbSet<Ciudades_X_Paises> Ciudades_X_Paises { get; set; }

        public DbSet<Tipo_Identificacion> Tipo_Identificacion { get; set; }

        public DbSet<Bancos> Bancos { get; set; }

        public DbSet<AperturaCierreCaja> AperturaCierreCajas { get; set; }

        public DbSet<Caja> Cajas { get; set; }

        public DbSet<Billetes_Moneda> Billetes_Moneda { get; set; }

        public DbSet<BovedaCaja> BovedaCajas { get; set; }

        public DbSet<BovedaCajaDesglose> BovedaCajaDesgloses { get; set; }

        public DbSet<BovedaMovimiento> BovedaMovimientoes { get; set; }

        public DbSet<ConciliacionTCTF> ConciliacionTCTFs { get; set; }

        public DbSet<Moneda> Monedas { get; set; }

        public DbSet<CuentaBancos> CuentaBancos { get; set; }

        public DbSet<MovimientoBanco> MovimientoBancoes { get; set; }

        public DbSet<TipoMovimientoBanco> TipoMovimientoBancoes { get; set; }

        public DbSet<gn_menu> gn_menus { get; set; }

        //FIN DE MOULO DE SEGURIDAD




    }
}
