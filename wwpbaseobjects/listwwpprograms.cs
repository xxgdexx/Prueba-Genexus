using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class listwwpprograms : GXProcedure
   {
      public listwwpprograms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public listwwpprograms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "SIGERP_ADVANCED") ;
         initialize();
         executePrivate();
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> executeUdp( )
      {
         execute(out aP0_ProgramNames);
         return AV9ProgramNames ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         listwwpprograms objlistwwpprograms;
         objlistwwpprograms = new listwwpprograms();
         objlistwwpprograms.AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "SIGERP_ADVANCED") ;
         objlistwwpprograms.context.SetSubmitInitialConfig(context);
         objlistwwpprograms.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlistwwpprograms);
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listwwpprograms)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "SIGERP_ADVANCED");
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV16WWPContext) ;
         AV13name = "Configuracion.MovimientoVentaWW";
         AV14description = " Movimientos de Credito / Debito";
         AV15link = formatLink("configuracion.movimientoventaww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Contabilidad.AuxiliaresWW";
         AV14description = " Auxiliares";
         AV15link = formatLink("contabilidad.auxiliaresww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Contabilidad.TipoAsientosWW";
         AV14description = " Tipos de Asientos Contables";
         AV15link = formatLink("contabilidad.tipoasientosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.ZonasWW";
         AV14description = " Zonas";
         AV15link = formatLink("configuracion.zonasww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.ListaPreciosWW";
         AV14description = " Lista de Precios";
         AV15link = formatLink("configuracion.listapreciosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Contabilidad.TipoAuxiliarWW";
         AV14description = " Tipos de Auxiliares";
         AV15link = formatLink("contabilidad.tipoauxiliarww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Bancos.EntregaRendirWW";
         AV14description = " Entrega Rendir Cuenta";
         AV15link = formatLink("bancos.entregarendirww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "WWPBaseObjects.WWP_Notificaciones";
         AV14description = "Notificaciones";
         AV15link = formatLink("wwpbaseobjects.wwp_notificaciones.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Bancos.CajaChicaWW";
         AV14description = " Caja Chica";
         AV15link = formatLink("bancos.cajachicaww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Generales.WWBusquedaCliente";
         AV14description = "Selecciona  Cliente";
         AV15link = formatLink("generales.wwbusquedacliente.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.ProvinciaWW";
         AV14description = " Provincia";
         AV15link = formatLink("configuracion.provinciaww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "WWPBaseObjects.MenuItemAppMenuWW";
         AV14description = "Application Menus";
         AV15link = formatLink("wwpbaseobjects.menuitemappmenuww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Bancos.ConceptoEntregaRendirWW";
         AV14description = " Conceptos Entrega Rendir Cuenta";
         AV15link = formatLink("bancos.conceptoentregarendirww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Bancos.BancosWW";
         AV14description = " Bancos";
         AV15link = formatLink("bancos.bancosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.TipoCambioWW";
         AV14description = "Tipos de Cambio";
         AV15link = formatLink("configuracion.tipocambioww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.CorrelativosWW";
         AV14description = " Correlativos";
         AV15link = formatLink("configuracion.correlativosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.TipoProveedorWW";
         AV14description = " Tipo Proveedor";
         AV15link = formatLink("configuracion.tipoproveedorww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Bancos.ConceptosCajaChicaWW";
         AV14description = " Conceptos de Caja Chica";
         AV15link = formatLink("bancos.conceptoscajachicaww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Contabilidad.CentroCostoWW";
         AV14description = " Centros de Costos";
         AV15link = formatLink("contabilidad.centrocostoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.PaisesWW";
         AV14description = " Paises";
         AV15link = formatLink("configuracion.paisesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Generales.WWBusquedaTrabajador";
         AV14description = "Selecciona  Cliente";
         AV15link = formatLink("generales.wwbusquedatrabajador.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.ChoferesWW";
         AV14description = " Choferes";
         AV15link = formatLink("configuracion.choferesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Contabilidad.PlanCuentasWW";
         AV14description = " Plan de Cuentas";
         AV15link = formatLink("contabilidad.plancuentasww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Reloj_Interface.Reloj_CodigoIDWW";
         AV14description = "Codigos Registrados en Reloj";
         AV15link = formatLink("reloj_interface.reloj_codigoidww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Bancos.ConceptoBancosWW";
         AV14description = " Conceptos de Bancos";
         AV15link = formatLink("bancos.conceptobancosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Reloj_Interface.RelojWW";
         AV14description = " Reloj";
         AV15link = formatLink("reloj_interface.relojww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.TipoClienteWW";
         AV14description = " Tipo Cliente";
         AV15link = formatLink("configuracion.tipoclienteww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.DepartamentosWW";
         AV14description = " Departamentos";
         AV15link = formatLink("configuracion.departamentosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Generales.WWBusquedaProducto";
         AV14description = "Selecciona  Producto";
         AV15link = formatLink("generales.wwbusquedaproducto.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.MovimientoAlmacenWW";
         AV14description = " Movimientos de Almacen";
         AV15link = formatLink("configuracion.movimientoalmacenww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.VendedoresWW";
         AV14description = " Vendedores / Cobradores";
         AV15link = formatLink("configuracion.vendedoresww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Contabilidad.RubrosWW";
         AV14description = " Rubros";
         AV15link = formatLink("contabilidad.rubrosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.AreasWW";
         AV14description = " Areas de la Empresa";
         AV15link = formatLink("configuracion.areasww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.TipoListaPrecioWW";
         AV14description = " Tipos de Listas de Precios";
         AV15link = formatLink("configuracion.tipolistaprecioww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.SubLineaWW";
         AV14description = " Sub Lineas de Productos";
         AV15link = formatLink("configuracion.sublineaww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.LineasProductosWW";
         AV14description = " Lineas de Productos";
         AV15link = formatLink("configuracion.lineasproductosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.MonedasWW";
         AV14description = " Monedas";
         AV15link = formatLink("configuracion.monedasww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Reloj_Interface.Reloj_HorarioWW";
         AV14description = "Horario del Personal";
         AV15link = formatLink("reloj_interface.reloj_horarioww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.FormaPagoWW";
         AV14description = "Formas de Pago";
         AV15link = formatLink("configuracion.formapagoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.EmpresasTransportesWW";
         AV14description = " Empresas de Transportes";
         AV15link = formatLink("configuracion.empresastransportesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.FamiliaWW";
         AV14description = " Familia";
         AV15link = formatLink("configuracion.familiaww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Contabilidad.ConceptoComprasWW";
         AV14description = " Conceptos de Compras";
         AV15link = formatLink("contabilidad.conceptocomprasww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Seguridad.CierreModulosWW";
         AV14description = " Cierre Modulos";
         AV15link = formatLink("seguridad.cierremodulosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Contabilidad.RubrosTotalesWW";
         AV14description = " Rubros Totales";
         AV15link = formatLink("contabilidad.rubrostotalesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Produccion.ConceptosOrdenesProduccionWW";
         AV14description = " Conceptos de Ordenes de Produccion";
         AV15link = formatLink("produccion.conceptosordenesproduccionww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Generales.WWBusquedaProveedor";
         AV14description = "Selecciona  Proveedor";
         AV15link = formatLink("generales.wwbusquedaproveedor.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Seguridad.NumeracionDocumentosWW";
         AV14description = " Numeracion Documentos";
         AV15link = formatLink("seguridad.numeraciondocumentosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.UnidadMedidaWW";
         AV14description = "Unidades de Medida";
         AV15link = formatLink("configuracion.unidadmedidaww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.BonificacionWW";
         AV14description = " Bonificacion";
         AV15link = formatLink("configuracion.bonificacionww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Seguridad.Auditoria";
         AV14description = "Auditoria";
         AV15link = formatLink("seguridad.auditoria.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.CondicionPagoWW";
         AV14description = "Condiciones de Pago";
         AV15link = formatLink("configuracion.condicionpagoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.TipoPedidoWW";
         AV14description = " Tipos de Pedidos";
         AV15link = formatLink("configuracion.tipopedidoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Produccion.OperariosWW";
         AV14description = " Operarios";
         AV15link = formatLink("produccion.operariosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Almacen.ProductosWW";
         AV14description = " Productos";
         AV15link = formatLink("almacen.productosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.DistritosWW";
         AV14description = " Distritos";
         AV15link = formatLink("configuracion.distritosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Ventas.ClientesWW";
         AV14description = " Clientes";
         AV15link = formatLink("ventas.clientesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Seguridad.UsuariosWW";
         AV14description = " Usuarios";
         AV15link = formatLink("seguridad.usuariosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Produccion.ConceptosOrdenesServicioWW";
         AV14description = " Conceptos de Ordenes Servicio";
         AV15link = formatLink("produccion.conceptosordenesservicioww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Bancos.CuentaBancosWW";
         AV14description = " Cuenta Bancos";
         AV15link = formatLink("bancos.cuentabancosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Seguridad.LocalesWW";
         AV14description = " Locales";
         AV15link = formatLink("seguridad.localesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Contabilidad.LineasWW";
         AV14description = " Lineas";
         AV15link = formatLink("contabilidad.lineasww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.AlmacenesWW";
         AV14description = " Almacenes";
         AV15link = formatLink("configuracion.almacenesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Produccion.MaquinasWW";
         AV14description = " Maquinas";
         AV15link = formatLink("produccion.maquinasww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Configuracion.TipoDocumentoWW";
         AV14description = "Tipo de Documentos";
         AV15link = formatLink("configuracion.tipodocumentoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "Seguridad.NotificacionesWW";
         AV14description = " Notificaciones";
         AV15link = formatLink("seguridad.notificacionesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ADDPROGRAM' Routine */
         returnInSub = false;
         AV8IsAuthorized = true;
         if ( AV8IsAuthorized )
         {
            AV10ProgramName = new GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName(context);
            AV10ProgramName.gxTpr_Name = AV13name;
            AV10ProgramName.gxTpr_Description = AV14description;
            AV10ProgramName.gxTpr_Link = AV15link;
            AV9ProgramNames.Add(AV10ProgramName, 0);
         }
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "SIGERP_ADVANCED");
         AV16WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13name = "";
         AV14description = "";
         AV15link = "";
         AV10ProgramName = new GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private string AV13name ;
      private string AV14description ;
      private string AV15link ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> aP0_ProgramNames ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> AV9ProgramNames ;
      private GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName AV10ProgramName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV16WWPContext ;
   }

}
