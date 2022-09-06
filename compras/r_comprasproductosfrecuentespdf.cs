using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.compras {
   public class r_comprasproductosfrecuentespdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_comprasproductosfrecuentespdf.aspx")), "compras.r_comprasproductosfrecuentespdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_comprasproductosfrecuentespdf.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "LinCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV30LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV31SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV28ProdCod = GetPar( "ProdCod");
                  AV14FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV15FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV32DocMonCod = (int)(NumberUtil.Val( GetPar( "DocMonCod"), "."));
                  AV46PrvCod = GetPar( "PrvCod");
                  AV47Tipo = GetPar( "Tipo");
                  AV50Tipo2 = GetPar( "Tipo2");
               }
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public r_comprasproductosfrecuentespdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_comprasproductosfrecuentespdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SubLCod ,
                           ref string aP2_ProdCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref int aP5_DocMonCod ,
                           ref string aP6_PrvCod ,
                           ref string aP7_Tipo ,
                           ref string aP8_Tipo2 )
      {
         this.AV30LinCod = aP0_LinCod;
         this.AV31SubLCod = aP1_SubLCod;
         this.AV28ProdCod = aP2_ProdCod;
         this.AV14FDesde = aP3_FDesde;
         this.AV15FHasta = aP4_FHasta;
         this.AV32DocMonCod = aP5_DocMonCod;
         this.AV46PrvCod = aP6_PrvCod;
         this.AV47Tipo = aP7_Tipo;
         this.AV50Tipo2 = aP8_Tipo2;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV30LinCod;
         aP1_SubLCod=this.AV31SubLCod;
         aP2_ProdCod=this.AV28ProdCod;
         aP3_FDesde=this.AV14FDesde;
         aP4_FHasta=this.AV15FHasta;
         aP5_DocMonCod=this.AV32DocMonCod;
         aP6_PrvCod=this.AV46PrvCod;
         aP7_Tipo=this.AV47Tipo;
         aP8_Tipo2=this.AV50Tipo2;
      }

      public string executeUdp( ref int aP0_LinCod ,
                                ref int aP1_SubLCod ,
                                ref string aP2_ProdCod ,
                                ref DateTime aP3_FDesde ,
                                ref DateTime aP4_FHasta ,
                                ref int aP5_DocMonCod ,
                                ref string aP6_PrvCod ,
                                ref string aP7_Tipo )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_ProdCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_DocMonCod, ref aP6_PrvCod, ref aP7_Tipo, ref aP8_Tipo2);
         return AV50Tipo2 ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref string aP2_ProdCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref int aP5_DocMonCod ,
                                 ref string aP6_PrvCod ,
                                 ref string aP7_Tipo ,
                                 ref string aP8_Tipo2 )
      {
         r_comprasproductosfrecuentespdf objr_comprasproductosfrecuentespdf;
         objr_comprasproductosfrecuentespdf = new r_comprasproductosfrecuentespdf();
         objr_comprasproductosfrecuentespdf.AV30LinCod = aP0_LinCod;
         objr_comprasproductosfrecuentespdf.AV31SubLCod = aP1_SubLCod;
         objr_comprasproductosfrecuentespdf.AV28ProdCod = aP2_ProdCod;
         objr_comprasproductosfrecuentespdf.AV14FDesde = aP3_FDesde;
         objr_comprasproductosfrecuentespdf.AV15FHasta = aP4_FHasta;
         objr_comprasproductosfrecuentespdf.AV32DocMonCod = aP5_DocMonCod;
         objr_comprasproductosfrecuentespdf.AV46PrvCod = aP6_PrvCod;
         objr_comprasproductosfrecuentespdf.AV47Tipo = aP7_Tipo;
         objr_comprasproductosfrecuentespdf.AV50Tipo2 = aP8_Tipo2;
         objr_comprasproductosfrecuentespdf.context.SetSubmitInitialConfig(context);
         objr_comprasproductosfrecuentespdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_comprasproductosfrecuentespdf);
         aP0_LinCod=this.AV30LinCod;
         aP1_SubLCod=this.AV31SubLCod;
         aP2_ProdCod=this.AV28ProdCod;
         aP3_FDesde=this.AV14FDesde;
         aP4_FHasta=this.AV15FHasta;
         aP5_DocMonCod=this.AV32DocMonCod;
         aP6_PrvCod=this.AV46PrvCod;
         aP7_Tipo=this.AV47Tipo;
         aP8_Tipo2=this.AV50Tipo2;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_comprasproductosfrecuentespdf)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 9, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV39Empresa = AV43Session.Get("Empresa");
            AV40EmpDir = AV43Session.Get("EmpDir");
            AV41EmpRUC = AV43Session.Get("EmpRUC");
            AV42Ruta = AV43Session.Get("RUTA") + "/Logo.jpg";
            AV44Logo = AV42Ruta;
            AV56Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV16Filtro1 = "Todos";
            AV17Filtro2 = "Todos";
            AV18Filtro3 = "Todos";
            AV19Filtro4 = ((StringUtil.StrCmp(AV47Tipo, "F")==0) ? "Reporte de Productos Frecuentes" : "Reporte de Productos No Frecuentes");
            /* Using cursor P00DF2 */
            pr_default.execute(0, new Object[] {AV30LinCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A52LinCod = P00DF2_A52LinCod[0];
               n52LinCod = P00DF2_n52LinCod[0];
               A1153LinDsc = P00DF2_A1153LinDsc[0];
               AV16Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00DF3 */
            pr_default.execute(1, new Object[] {AV31SubLCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A51SublCod = P00DF3_A51SublCod[0];
               n51SublCod = P00DF3_n51SublCod[0];
               A1892SublDsc = P00DF3_A1892SublDsc[0];
               AV17Filtro2 = A1892SublDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00DF4 */
            pr_default.execute(2, new Object[] {AV28ProdCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A28ProdCod = P00DF4_A28ProdCod[0];
               A55ProdDsc = P00DF4_A55ProdDsc[0];
               AV18Filtro3 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P00DF5 */
            pr_default.execute(3, new Object[] {AV32DocMonCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A180MonCod = P00DF5_A180MonCod[0];
               A1234MonDsc = P00DF5_A1234MonDsc[0];
               AV20Filtro5 = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            if ( StringUtil.StrCmp(AV50Tipo2, "D") == 0 )
            {
               AV27TotalGeneral = 0.00m;
               pr_default.dynParam(4, new Object[]{ new Object[]{
                                                    AV30LinCod ,
                                                    AV31SubLCod ,
                                                    AV28ProdCod ,
                                                    AV46PrvCod ,
                                                    AV47Tipo ,
                                                    A52LinCod ,
                                                    A51SublCod ,
                                                    A254ComDProCod ,
                                                    A244PrvCod ,
                                                    A1696ProdFrecuente ,
                                                    A707ComFReg ,
                                                    AV14FDesde ,
                                                    AV15FHasta } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                                    TypeConstants.DATE, TypeConstants.DATE
                                                    }
               });
               /* Using cursor P00DF6 */
               pr_default.execute(4, new Object[] {AV14FDesde, AV15FHasta, AV30LinCod, AV31SubLCod, AV28ProdCod, AV46PrvCod});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  BRKDF7 = false;
                  A149TipCod = P00DF6_A149TipCod[0];
                  A243ComCod = P00DF6_A243ComCod[0];
                  A254ComDProCod = P00DF6_A254ComDProCod[0];
                  n254ComDProCod = P00DF6_n254ComDProCod[0];
                  A1696ProdFrecuente = P00DF6_A1696ProdFrecuente[0];
                  n1696ProdFrecuente = P00DF6_n1696ProdFrecuente[0];
                  A707ComFReg = P00DF6_A707ComFReg[0];
                  A244PrvCod = P00DF6_A244PrvCod[0];
                  A51SublCod = P00DF6_A51SublCod[0];
                  n51SublCod = P00DF6_n51SublCod[0];
                  A52LinCod = P00DF6_A52LinCod[0];
                  n52LinCod = P00DF6_n52LinCod[0];
                  A686ComDPre = P00DF6_A686ComDPre[0];
                  A694ComDDsc = P00DF6_A694ComDDsc[0];
                  A250ComDItem = P00DF6_A250ComDItem[0];
                  A251ComDOrdCod = P00DF6_A251ComDOrdCod[0];
                  A1696ProdFrecuente = P00DF6_A1696ProdFrecuente[0];
                  n1696ProdFrecuente = P00DF6_n1696ProdFrecuente[0];
                  A51SublCod = P00DF6_A51SublCod[0];
                  n51SublCod = P00DF6_n51SublCod[0];
                  A52LinCod = P00DF6_A52LinCod[0];
                  n52LinCod = P00DF6_n52LinCod[0];
                  A707ComFReg = P00DF6_A707ComFReg[0];
                  while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00DF6_A254ComDProCod[0], A254ComDProCod) == 0 ) )
                  {
                     BRKDF7 = false;
                     A149TipCod = P00DF6_A149TipCod[0];
                     A243ComCod = P00DF6_A243ComCod[0];
                     A244PrvCod = P00DF6_A244PrvCod[0];
                     A250ComDItem = P00DF6_A250ComDItem[0];
                     A251ComDOrdCod = P00DF6_A251ComDOrdCod[0];
                     BRKDF7 = true;
                     pr_default.readNext(4);
                  }
                  AV28ProdCod = A254ComDProCod;
                  AV29ProdDsc = A694ComDDsc;
                  AV23TotalVenta = 0.00m;
                  AV24Total = 0.00m;
                  AV36Cant = 0.00m;
                  AV34Cantidad = 0.00m;
                  AV35TCantidad = 0.00m;
                  /* Execute user subroutine: 'PRODUCTOS' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(4);
                     this.cleanup();
                     if (true) return;
                  }
                  AV48SDTComprasProductoITem.gxTpr_Clicod = AV28ProdCod;
                  AV48SDTComprasProductoITem.gxTpr_Clidsc = AV29ProdDsc;
                  AV48SDTComprasProductoITem.gxTpr_Cantidad = AV34Cantidad;
                  AV48SDTComprasProductoITem.gxTpr_Importe = AV23TotalVenta;
                  AV49SDTComprasProducto.Add(AV48SDTComprasProductoITem, 0);
                  AV48SDTComprasProductoITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
                  AV27TotalGeneral = (decimal)(AV27TotalGeneral+AV23TotalVenta);
                  if ( ! BRKDF7 )
                  {
                     BRKDF7 = true;
                     pr_default.readNext(4);
                  }
               }
               pr_default.close(4);
               AV49SDTComprasProducto.Sort("[Importe]");
               AV66GXV1 = 1;
               while ( AV66GXV1 <= AV49SDTComprasProducto.Count )
               {
                  AV48SDTComprasProductoITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV49SDTComprasProducto.Item(AV66GXV1));
                  AV28ProdCod = AV48SDTComprasProductoITem.gxTpr_Clicod;
                  AV29ProdDsc = AV48SDTComprasProductoITem.gxTpr_Clidsc;
                  AV34Cantidad = AV48SDTComprasProductoITem.gxTpr_Cantidad;
                  AV23TotalVenta = AV48SDTComprasProductoITem.gxTpr_Importe;
                  HDF0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28ProdCod, "@!")), 18, Gx_line+0, 143, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23TotalVenta, "ZZZZZZ,ZZZ,ZZ9.99")), 625, Gx_line+2, 749, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34Cantidad, "ZZZZ,ZZZ,ZZ9.9999")), 524, Gx_line+1, 631, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29ProdDsc, "")), 148, Gx_line+2, 511, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  AV66GXV1 = (int)(AV66GXV1+1);
               }
               HDF0( false, 72) ;
               getPrinter().GxDrawLine(590, Gx_line+9, 785, Gx_line+9, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total General", 417, Gx_line+17, 497, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27TotalGeneral, "ZZZZZZ,ZZZ,ZZ9.99")), 643, Gx_line+16, 750, Gx_line+31, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+72);
            }
            else
            {
               /* Execute user subroutine: 'FRECUENTES' */
               S121 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               AV53Por = 0.00m;
               AV27TotalGeneral = (decimal)(AV51Total1+AV52Total2);
               AV29ProdDsc = "Producto Frecuentes";
               AV23TotalVenta = AV51Total1;
               AV53Por = ((AV27TotalGeneral==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV51Total1/ (decimal)(AV27TotalGeneral))*100, 2));
               HDF0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29ProdDsc, "")), 40, Gx_line+2, 345, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23TotalVenta, "ZZZZZZ,ZZZ,ZZ9.99")), 354, Gx_line+2, 478, Gx_line+15, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53Por, "ZZ9.99")), 525, Gx_line+1, 564, Gx_line+16, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV53Por = 0.00m;
               AV29ProdDsc = "Producto No Frecuentes";
               AV23TotalVenta = AV52Total2;
               AV53Por = ((AV27TotalGeneral==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV52Total2/ (decimal)(AV27TotalGeneral))*100, 2));
               HDF0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29ProdDsc, "")), 40, Gx_line+2, 345, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23TotalVenta, "ZZZZZZ,ZZZ,ZZ9.99")), 354, Gx_line+2, 478, Gx_line+15, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53Por, "ZZ9.99")), 525, Gx_line+1, 564, Gx_line+16, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               HDF0( false, 30) ;
               getPrinter().GxDrawLine(319, Gx_line+6, 586, Gx_line+6, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total General", 253, Gx_line+10, 333, Gx_line+24, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27TotalGeneral, "ZZZZZZ,ZZZ,ZZ9.99")), 372, Gx_line+10, 479, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("100.00 %", 532, Gx_line+10, 589, Gx_line+24, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HDF0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'PRODUCTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV30LinCod ,
                                              AV31SubLCod ,
                                              AV46PrvCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A244PrvCod ,
                                              A254ComDProCod ,
                                              A707ComFReg ,
                                              AV14FDesde ,
                                              AV15FHasta ,
                                              AV28ProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00DF7 */
         pr_default.execute(5, new Object[] {AV28ProdCod, AV14FDesde, AV15FHasta, AV30LinCod, AV31SubLCod, AV46PrvCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A243ComCod = P00DF7_A243ComCod[0];
            A707ComFReg = P00DF7_A707ComFReg[0];
            A254ComDProCod = P00DF7_A254ComDProCod[0];
            n254ComDProCod = P00DF7_n254ComDProCod[0];
            A244PrvCod = P00DF7_A244PrvCod[0];
            A51SublCod = P00DF7_A51SublCod[0];
            n51SublCod = P00DF7_n51SublCod[0];
            A52LinCod = P00DF7_A52LinCod[0];
            n52LinCod = P00DF7_n52LinCod[0];
            A149TipCod = P00DF7_A149TipCod[0];
            A248ComFec = P00DF7_A248ComFec[0];
            A704ComFecPago = P00DF7_A704ComFecPago[0];
            A724ComRefFec = P00DF7_A724ComRefFec[0];
            A511TipSigno = P00DF7_A511TipSigno[0];
            A246ComMon = P00DF7_A246ComMon[0];
            A689ComDDct = P00DF7_A689ComDDct[0];
            A686ComDPre = P00DF7_A686ComDPre[0];
            A685ComDCant = P00DF7_A685ComDCant[0];
            A250ComDItem = P00DF7_A250ComDItem[0];
            A251ComDOrdCod = P00DF7_A251ComDOrdCod[0];
            A51SublCod = P00DF7_A51SublCod[0];
            n51SublCod = P00DF7_n51SublCod[0];
            A52LinCod = P00DF7_A52LinCod[0];
            n52LinCod = P00DF7_n52LinCod[0];
            A511TipSigno = P00DF7_A511TipSigno[0];
            A707ComFReg = P00DF7_A707ComFReg[0];
            A248ComFec = P00DF7_A248ComFec[0];
            A704ComFecPago = P00DF7_A704ComFecPago[0];
            A724ComRefFec = P00DF7_A724ComRefFec[0];
            A246ComMon = P00DF7_A246ComMon[0];
            A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
            A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
            A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
            AV45TipCod2 = A149TipCod;
            AV25Fecha = (((StringUtil.StrCmp(AV45TipCod2, "NC")==0)||(StringUtil.StrCmp(AV45TipCod2, "ND")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : ((DateTime.MinValue==A704ComFecPago) ? A248ComFec : A704ComFecPago));
            AV33TipSigno = A511TipSigno;
            AV12MonCod = A246ComMon;
            AV24Total = NumberUtil.Round( NumberUtil.Round( A684ComDTot, 2)*A511TipSigno, 2);
            AV36Cant = NumberUtil.Round( A685ComDCant*A511TipSigno, 2);
            if ( ( StringUtil.StrCmp(AV45TipCod2, "NC") == 0 ) || ( StringUtil.StrCmp(AV45TipCod2, "ND") == 0 ) )
            {
               AV25Fecha = A707ComFReg;
            }
            if ( ( AV32DocMonCod != 1 ) && ( AV32DocMonCod != 0 ) )
            {
               if ( AV12MonCod == 1 )
               {
                  GXt_decimal1 = AV26Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV12MonCod, ref  AV25Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV26Cambio = GXt_decimal1;
                  AV24Total = NumberUtil.Round( AV24Total/ (decimal)(AV26Cambio), 2);
               }
            }
            else
            {
               if ( AV12MonCod != 1 )
               {
                  GXt_decimal1 = AV26Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV12MonCod, ref  AV25Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV26Cambio = GXt_decimal1;
                  AV24Total = NumberUtil.Round( AV24Total*AV26Cambio, 2);
               }
            }
            AV23TotalVenta = (decimal)(AV23TotalVenta+AV24Total);
            AV34Cantidad = (decimal)(AV34Cantidad+AV36Cant);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S121( )
      {
         /* 'FRECUENTES' Routine */
         returnInSub = false;
         AV51Total1 = 0.00m;
         AV52Total2 = 0.00m;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV30LinCod ,
                                              AV31SubLCod ,
                                              AV46PrvCod ,
                                              AV28ProdCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A244PrvCod ,
                                              A254ComDProCod ,
                                              A707ComFReg ,
                                              AV14FDesde ,
                                              AV15FHasta ,
                                              A1696ProdFrecuente } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00DF8 */
         pr_default.execute(6, new Object[] {AV14FDesde, AV15FHasta, AV30LinCod, AV31SubLCod, AV46PrvCod, AV28ProdCod});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A243ComCod = P00DF8_A243ComCod[0];
            A707ComFReg = P00DF8_A707ComFReg[0];
            A1696ProdFrecuente = P00DF8_A1696ProdFrecuente[0];
            n1696ProdFrecuente = P00DF8_n1696ProdFrecuente[0];
            A254ComDProCod = P00DF8_A254ComDProCod[0];
            n254ComDProCod = P00DF8_n254ComDProCod[0];
            A244PrvCod = P00DF8_A244PrvCod[0];
            A51SublCod = P00DF8_A51SublCod[0];
            n51SublCod = P00DF8_n51SublCod[0];
            A52LinCod = P00DF8_A52LinCod[0];
            n52LinCod = P00DF8_n52LinCod[0];
            A149TipCod = P00DF8_A149TipCod[0];
            A248ComFec = P00DF8_A248ComFec[0];
            A704ComFecPago = P00DF8_A704ComFecPago[0];
            A724ComRefFec = P00DF8_A724ComRefFec[0];
            A511TipSigno = P00DF8_A511TipSigno[0];
            A246ComMon = P00DF8_A246ComMon[0];
            A689ComDDct = P00DF8_A689ComDDct[0];
            A686ComDPre = P00DF8_A686ComDPre[0];
            A685ComDCant = P00DF8_A685ComDCant[0];
            A250ComDItem = P00DF8_A250ComDItem[0];
            A251ComDOrdCod = P00DF8_A251ComDOrdCod[0];
            A1696ProdFrecuente = P00DF8_A1696ProdFrecuente[0];
            n1696ProdFrecuente = P00DF8_n1696ProdFrecuente[0];
            A51SublCod = P00DF8_A51SublCod[0];
            n51SublCod = P00DF8_n51SublCod[0];
            A52LinCod = P00DF8_A52LinCod[0];
            n52LinCod = P00DF8_n52LinCod[0];
            A511TipSigno = P00DF8_A511TipSigno[0];
            A707ComFReg = P00DF8_A707ComFReg[0];
            A248ComFec = P00DF8_A248ComFec[0];
            A704ComFecPago = P00DF8_A704ComFecPago[0];
            A724ComRefFec = P00DF8_A724ComRefFec[0];
            A246ComMon = P00DF8_A246ComMon[0];
            A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
            A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
            A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
            AV45TipCod2 = A149TipCod;
            AV25Fecha = (((StringUtil.StrCmp(AV45TipCod2, "NC")==0)||(StringUtil.StrCmp(AV45TipCod2, "ND")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : ((DateTime.MinValue==A704ComFecPago) ? A248ComFec : A704ComFecPago));
            AV33TipSigno = A511TipSigno;
            AV12MonCod = A246ComMon;
            AV24Total = NumberUtil.Round( NumberUtil.Round( A684ComDTot, 2)*A511TipSigno, 2);
            AV36Cant = NumberUtil.Round( A685ComDCant*A511TipSigno, 2);
            if ( ( AV32DocMonCod != 1 ) && ( AV32DocMonCod != 0 ) )
            {
               if ( AV12MonCod == 1 )
               {
                  GXt_decimal1 = AV26Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV12MonCod, ref  AV25Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV26Cambio = GXt_decimal1;
                  AV24Total = NumberUtil.Round( AV24Total/ (decimal)(AV26Cambio), 2);
               }
            }
            else
            {
               if ( AV12MonCod != 1 )
               {
                  GXt_decimal1 = AV26Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV12MonCod, ref  AV25Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV26Cambio = GXt_decimal1;
                  AV24Total = NumberUtil.Round( AV24Total*AV26Cambio, 2);
               }
            }
            AV51Total1 = (decimal)(AV51Total1+AV24Total);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV30LinCod ,
                                              AV31SubLCod ,
                                              AV46PrvCod ,
                                              AV28ProdCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A244PrvCod ,
                                              A254ComDProCod ,
                                              A707ComFReg ,
                                              AV14FDesde ,
                                              AV15FHasta ,
                                              A1696ProdFrecuente } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00DF9 */
         pr_default.execute(7, new Object[] {AV14FDesde, AV15FHasta, AV30LinCod, AV31SubLCod, AV46PrvCod, AV28ProdCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A243ComCod = P00DF9_A243ComCod[0];
            A707ComFReg = P00DF9_A707ComFReg[0];
            A1696ProdFrecuente = P00DF9_A1696ProdFrecuente[0];
            n1696ProdFrecuente = P00DF9_n1696ProdFrecuente[0];
            A254ComDProCod = P00DF9_A254ComDProCod[0];
            n254ComDProCod = P00DF9_n254ComDProCod[0];
            A244PrvCod = P00DF9_A244PrvCod[0];
            A51SublCod = P00DF9_A51SublCod[0];
            n51SublCod = P00DF9_n51SublCod[0];
            A52LinCod = P00DF9_A52LinCod[0];
            n52LinCod = P00DF9_n52LinCod[0];
            A149TipCod = P00DF9_A149TipCod[0];
            A248ComFec = P00DF9_A248ComFec[0];
            A704ComFecPago = P00DF9_A704ComFecPago[0];
            A724ComRefFec = P00DF9_A724ComRefFec[0];
            A511TipSigno = P00DF9_A511TipSigno[0];
            A246ComMon = P00DF9_A246ComMon[0];
            A689ComDDct = P00DF9_A689ComDDct[0];
            A686ComDPre = P00DF9_A686ComDPre[0];
            A685ComDCant = P00DF9_A685ComDCant[0];
            A250ComDItem = P00DF9_A250ComDItem[0];
            A251ComDOrdCod = P00DF9_A251ComDOrdCod[0];
            A1696ProdFrecuente = P00DF9_A1696ProdFrecuente[0];
            n1696ProdFrecuente = P00DF9_n1696ProdFrecuente[0];
            A51SublCod = P00DF9_A51SublCod[0];
            n51SublCod = P00DF9_n51SublCod[0];
            A52LinCod = P00DF9_A52LinCod[0];
            n52LinCod = P00DF9_n52LinCod[0];
            A511TipSigno = P00DF9_A511TipSigno[0];
            A707ComFReg = P00DF9_A707ComFReg[0];
            A248ComFec = P00DF9_A248ComFec[0];
            A704ComFecPago = P00DF9_A704ComFecPago[0];
            A724ComRefFec = P00DF9_A724ComRefFec[0];
            A246ComMon = P00DF9_A246ComMon[0];
            A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
            A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
            A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
            AV45TipCod2 = A149TipCod;
            AV25Fecha = (((StringUtil.StrCmp(AV45TipCod2, "NC")==0)||(StringUtil.StrCmp(AV45TipCod2, "ND")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : ((DateTime.MinValue==A704ComFecPago) ? A248ComFec : A704ComFecPago));
            AV33TipSigno = A511TipSigno;
            AV12MonCod = A246ComMon;
            AV24Total = NumberUtil.Round( NumberUtil.Round( A684ComDTot, 2)*A511TipSigno, 2);
            AV36Cant = NumberUtil.Round( A685ComDCant*A511TipSigno, 2);
            if ( ( AV32DocMonCod != 1 ) && ( AV32DocMonCod != 0 ) )
            {
               if ( AV12MonCod == 1 )
               {
                  GXt_decimal1 = AV26Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV12MonCod, ref  AV25Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV26Cambio = GXt_decimal1;
                  AV24Total = NumberUtil.Round( AV24Total/ (decimal)(AV26Cambio), 2);
               }
            }
            else
            {
               if ( AV12MonCod != 1 )
               {
                  GXt_decimal1 = AV26Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV12MonCod, ref  AV25Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV26Cambio = GXt_decimal1;
                  AV24Total = NumberUtil.Round( AV24Total*AV26Cambio, 2);
               }
            }
            AV52Total2 = (decimal)(AV52Total2+AV24Total);
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void HDF0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if ( StringUtil.StrCmp(AV50Tipo2, "D") == 0 )
               {
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Hora:", 669, Gx_line+43, 701, Gx_line+57, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Página:", 669, Gx_line+63, 713, Gx_line+77, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Fecha:", 669, Gx_line+24, 708, Gx_line+38, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Linea de Productos", 171, Gx_line+121, 283, Gx_line+135, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Sub Linea de productos", 171, Gx_line+143, 308, Gx_line+157, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Productos", 171, Gx_line+165, 231, Gx_line+179, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Filtro1, "")), 314, Gx_line+116, 657, Gx_line+140, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17Filtro2, "")), 314, Gx_line+138, 657, Gx_line+162, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Filtro3, "")), 314, Gx_line+159, 657, Gx_line+183, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(0, Gx_line+192, 797, Gx_line+218, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 714, Gx_line+24, 761, Gx_line+39, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 699, Gx_line+43, 759, Gx_line+57, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 722, Gx_line+63, 761, Gx_line+78, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Codigo", 24, Gx_line+199, 65, Gx_line+213, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Total Compra", 672, Gx_line+199, 752, Gx_line+213, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Productos", 155, Gx_line+199, 215, Gx_line+213, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Cantidad", 574, Gx_line+199, 627, Gx_line+213, 0+256, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV44Logo)) ? AV56Logo_GXI : AV44Logo);
                  getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+19, 176, Gx_line+97) ;
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Del :", 274, Gx_line+65, 315, Gx_line+85, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV14FDesde, "99/99/99"), 323, Gx_line+63, 397, Gx_line+87, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Al :", 399, Gx_line+65, 429, Gx_line+85, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV15FHasta, "99/99/99"), 433, Gx_line+63, 507, Gx_line+87, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Expresado en :", 242, Gx_line+88, 369, Gx_line+108, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20Filtro5, "")), 374, Gx_line+85, 563, Gx_line+109, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Filtro4, "")), 227, Gx_line+38, 611, Gx_line+62, 1, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+218);
               }
               else
               {
                  AV19Filtro4 = "Resumen Comparativo por Tipo de Producto";
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Hora:", 669, Gx_line+35, 701, Gx_line+49, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Página:", 669, Gx_line+55, 713, Gx_line+69, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Fecha:", 669, Gx_line+17, 708, Gx_line+31, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Linea de Productos", 171, Gx_line+114, 283, Gx_line+128, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Sub Linea de productos", 171, Gx_line+135, 308, Gx_line+149, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Productos", 171, Gx_line+157, 231, Gx_line+171, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Filtro1, "")), 314, Gx_line+108, 657, Gx_line+132, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17Filtro2, "")), 314, Gx_line+130, 657, Gx_line+154, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Filtro3, "")), 314, Gx_line+152, 657, Gx_line+176, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(0, Gx_line+184, 797, Gx_line+210, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 714, Gx_line+17, 761, Gx_line+32, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 699, Gx_line+35, 759, Gx_line+49, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 722, Gx_line+55, 761, Gx_line+70, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Compra", 393, Gx_line+191, 473, Gx_line+205, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Tipo de Producto", 119, Gx_line+192, 219, Gx_line+206, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("%", 538, Gx_line+193, 553, Gx_line+207, 0+256, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV44Logo)) ? AV56Logo_GXI : AV44Logo);
                  getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+11, 176, Gx_line+89) ;
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Del :", 274, Gx_line+57, 315, Gx_line+77, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV14FDesde, "99/99/99"), 323, Gx_line+55, 397, Gx_line+79, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Al :", 399, Gx_line+57, 429, Gx_line+77, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV15FHasta, "99/99/99"), 433, Gx_line+55, 507, Gx_line+79, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Expresado en :", 242, Gx_line+80, 369, Gx_line+100, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20Filtro5, "")), 374, Gx_line+78, 563, Gx_line+102, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Filtro4, "")), 227, Gx_line+30, 611, Gx_line+54, 1, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+210);
               }
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         GXDecQS = "";
         gxfirstwebparm = "";
         AV39Empresa = "";
         AV43Session = context.GetSession();
         AV40EmpDir = "";
         AV41EmpRUC = "";
         AV42Ruta = "";
         AV44Logo = "";
         AV56Logo_GXI = "";
         AV16Filtro1 = "";
         AV17Filtro2 = "";
         AV18Filtro3 = "";
         AV19Filtro4 = "";
         scmdbuf = "";
         P00DF2_A52LinCod = new int[1] ;
         P00DF2_n52LinCod = new bool[] {false} ;
         P00DF2_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P00DF3_A51SublCod = new int[1] ;
         P00DF3_n51SublCod = new bool[] {false} ;
         P00DF3_A1892SublDsc = new string[] {""} ;
         A1892SublDsc = "";
         P00DF4_A28ProdCod = new string[] {""} ;
         P00DF4_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00DF5_A180MonCod = new int[1] ;
         P00DF5_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV20Filtro5 = "";
         A254ComDProCod = "";
         A244PrvCod = "";
         A707ComFReg = DateTime.MinValue;
         P00DF6_A149TipCod = new string[] {""} ;
         P00DF6_A243ComCod = new string[] {""} ;
         P00DF6_A254ComDProCod = new string[] {""} ;
         P00DF6_n254ComDProCod = new bool[] {false} ;
         P00DF6_A1696ProdFrecuente = new short[1] ;
         P00DF6_n1696ProdFrecuente = new bool[] {false} ;
         P00DF6_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00DF6_A244PrvCod = new string[] {""} ;
         P00DF6_A51SublCod = new int[1] ;
         P00DF6_n51SublCod = new bool[] {false} ;
         P00DF6_A52LinCod = new int[1] ;
         P00DF6_n52LinCod = new bool[] {false} ;
         P00DF6_A686ComDPre = new decimal[1] ;
         P00DF6_A694ComDDsc = new string[] {""} ;
         P00DF6_A250ComDItem = new short[1] ;
         P00DF6_A251ComDOrdCod = new string[] {""} ;
         A149TipCod = "";
         A243ComCod = "";
         A694ComDDsc = "";
         A251ComDOrdCod = "";
         AV29ProdDsc = "";
         AV48SDTComprasProductoITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV49SDTComprasProducto = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         P00DF7_A243ComCod = new string[] {""} ;
         P00DF7_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00DF7_A254ComDProCod = new string[] {""} ;
         P00DF7_n254ComDProCod = new bool[] {false} ;
         P00DF7_A244PrvCod = new string[] {""} ;
         P00DF7_A51SublCod = new int[1] ;
         P00DF7_n51SublCod = new bool[] {false} ;
         P00DF7_A52LinCod = new int[1] ;
         P00DF7_n52LinCod = new bool[] {false} ;
         P00DF7_A149TipCod = new string[] {""} ;
         P00DF7_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DF7_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00DF7_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00DF7_A511TipSigno = new short[1] ;
         P00DF7_A246ComMon = new int[1] ;
         P00DF7_A689ComDDct = new decimal[1] ;
         P00DF7_A686ComDPre = new decimal[1] ;
         P00DF7_A685ComDCant = new decimal[1] ;
         P00DF7_A250ComDItem = new short[1] ;
         P00DF7_A251ComDOrdCod = new string[] {""} ;
         A248ComFec = DateTime.MinValue;
         A704ComFecPago = DateTime.MinValue;
         A724ComRefFec = DateTime.MinValue;
         AV45TipCod2 = "";
         AV25Fecha = DateTime.MinValue;
         P00DF8_A243ComCod = new string[] {""} ;
         P00DF8_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00DF8_A1696ProdFrecuente = new short[1] ;
         P00DF8_n1696ProdFrecuente = new bool[] {false} ;
         P00DF8_A254ComDProCod = new string[] {""} ;
         P00DF8_n254ComDProCod = new bool[] {false} ;
         P00DF8_A244PrvCod = new string[] {""} ;
         P00DF8_A51SublCod = new int[1] ;
         P00DF8_n51SublCod = new bool[] {false} ;
         P00DF8_A52LinCod = new int[1] ;
         P00DF8_n52LinCod = new bool[] {false} ;
         P00DF8_A149TipCod = new string[] {""} ;
         P00DF8_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DF8_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00DF8_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00DF8_A511TipSigno = new short[1] ;
         P00DF8_A246ComMon = new int[1] ;
         P00DF8_A689ComDDct = new decimal[1] ;
         P00DF8_A686ComDPre = new decimal[1] ;
         P00DF8_A685ComDCant = new decimal[1] ;
         P00DF8_A250ComDItem = new short[1] ;
         P00DF8_A251ComDOrdCod = new string[] {""} ;
         P00DF9_A243ComCod = new string[] {""} ;
         P00DF9_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00DF9_A1696ProdFrecuente = new short[1] ;
         P00DF9_n1696ProdFrecuente = new bool[] {false} ;
         P00DF9_A254ComDProCod = new string[] {""} ;
         P00DF9_n254ComDProCod = new bool[] {false} ;
         P00DF9_A244PrvCod = new string[] {""} ;
         P00DF9_A51SublCod = new int[1] ;
         P00DF9_n51SublCod = new bool[] {false} ;
         P00DF9_A52LinCod = new int[1] ;
         P00DF9_n52LinCod = new bool[] {false} ;
         P00DF9_A149TipCod = new string[] {""} ;
         P00DF9_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DF9_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00DF9_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00DF9_A511TipSigno = new short[1] ;
         P00DF9_A246ComMon = new int[1] ;
         P00DF9_A689ComDDct = new decimal[1] ;
         P00DF9_A686ComDPre = new decimal[1] ;
         P00DF9_A685ComDCant = new decimal[1] ;
         P00DF9_A250ComDItem = new short[1] ;
         P00DF9_A251ComDOrdCod = new string[] {""} ;
         GXt_char2 = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV44Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_comprasproductosfrecuentespdf__default(),
            new Object[][] {
                new Object[] {
               P00DF2_A52LinCod, P00DF2_A1153LinDsc
               }
               , new Object[] {
               P00DF3_A51SublCod, P00DF3_A1892SublDsc
               }
               , new Object[] {
               P00DF4_A28ProdCod, P00DF4_A55ProdDsc
               }
               , new Object[] {
               P00DF5_A180MonCod, P00DF5_A1234MonDsc
               }
               , new Object[] {
               P00DF6_A149TipCod, P00DF6_A243ComCod, P00DF6_A254ComDProCod, P00DF6_n254ComDProCod, P00DF6_A1696ProdFrecuente, P00DF6_n1696ProdFrecuente, P00DF6_A707ComFReg, P00DF6_A244PrvCod, P00DF6_A51SublCod, P00DF6_n51SublCod,
               P00DF6_A52LinCod, P00DF6_n52LinCod, P00DF6_A686ComDPre, P00DF6_A694ComDDsc, P00DF6_A250ComDItem, P00DF6_A251ComDOrdCod
               }
               , new Object[] {
               P00DF7_A243ComCod, P00DF7_A707ComFReg, P00DF7_A254ComDProCod, P00DF7_n254ComDProCod, P00DF7_A244PrvCod, P00DF7_A51SublCod, P00DF7_n51SublCod, P00DF7_A52LinCod, P00DF7_n52LinCod, P00DF7_A149TipCod,
               P00DF7_A248ComFec, P00DF7_A704ComFecPago, P00DF7_A724ComRefFec, P00DF7_A511TipSigno, P00DF7_A246ComMon, P00DF7_A689ComDDct, P00DF7_A686ComDPre, P00DF7_A685ComDCant, P00DF7_A250ComDItem, P00DF7_A251ComDOrdCod
               }
               , new Object[] {
               P00DF8_A243ComCod, P00DF8_A707ComFReg, P00DF8_A1696ProdFrecuente, P00DF8_n1696ProdFrecuente, P00DF8_A254ComDProCod, P00DF8_n254ComDProCod, P00DF8_A244PrvCod, P00DF8_A51SublCod, P00DF8_n51SublCod, P00DF8_A52LinCod,
               P00DF8_n52LinCod, P00DF8_A149TipCod, P00DF8_A248ComFec, P00DF8_A704ComFecPago, P00DF8_A724ComRefFec, P00DF8_A511TipSigno, P00DF8_A246ComMon, P00DF8_A689ComDDct, P00DF8_A686ComDPre, P00DF8_A685ComDCant,
               P00DF8_A250ComDItem, P00DF8_A251ComDOrdCod
               }
               , new Object[] {
               P00DF9_A243ComCod, P00DF9_A707ComFReg, P00DF9_A1696ProdFrecuente, P00DF9_n1696ProdFrecuente, P00DF9_A254ComDProCod, P00DF9_n254ComDProCod, P00DF9_A244PrvCod, P00DF9_A51SublCod, P00DF9_n51SublCod, P00DF9_A52LinCod,
               P00DF9_n52LinCod, P00DF9_A149TipCod, P00DF9_A248ComFec, P00DF9_A704ComFecPago, P00DF9_A724ComRefFec, P00DF9_A511TipSigno, P00DF9_A246ComMon, P00DF9_A689ComDDct, P00DF9_A686ComDPre, P00DF9_A685ComDCant,
               P00DF9_A250ComDItem, P00DF9_A251ComDOrdCod
               }
            }
         );
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short A1696ProdFrecuente ;
      private short A250ComDItem ;
      private short A511TipSigno ;
      private short AV33TipSigno ;
      private int AV30LinCod ;
      private int AV31SubLCod ;
      private int AV32DocMonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A180MonCod ;
      private int AV66GXV1 ;
      private int Gx_OldLine ;
      private int A246ComMon ;
      private int AV12MonCod ;
      private decimal AV27TotalGeneral ;
      private decimal A686ComDPre ;
      private decimal AV23TotalVenta ;
      private decimal AV24Total ;
      private decimal AV36Cant ;
      private decimal AV34Cantidad ;
      private decimal AV35TCantidad ;
      private decimal AV53Por ;
      private decimal AV51Total1 ;
      private decimal AV52Total2 ;
      private decimal A689ComDDct ;
      private decimal A685ComDCant ;
      private decimal A688ComDSub ;
      private decimal A687ComDDescuento ;
      private decimal A684ComDTot ;
      private decimal AV26Cambio ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV28ProdCod ;
      private string AV46PrvCod ;
      private string AV47Tipo ;
      private string AV50Tipo2 ;
      private string AV39Empresa ;
      private string AV40EmpDir ;
      private string AV41EmpRUC ;
      private string AV42Ruta ;
      private string AV16Filtro1 ;
      private string AV17Filtro2 ;
      private string AV18Filtro3 ;
      private string AV19Filtro4 ;
      private string scmdbuf ;
      private string A1153LinDsc ;
      private string A1892SublDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1234MonDsc ;
      private string AV20Filtro5 ;
      private string A254ComDProCod ;
      private string A244PrvCod ;
      private string A149TipCod ;
      private string A243ComCod ;
      private string A694ComDDsc ;
      private string A251ComDOrdCod ;
      private string AV29ProdDsc ;
      private string AV45TipCod2 ;
      private string GXt_char2 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV14FDesde ;
      private DateTime AV15FHasta ;
      private DateTime A707ComFReg ;
      private DateTime A248ComFec ;
      private DateTime A704ComFecPago ;
      private DateTime A724ComRefFec ;
      private DateTime AV25Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n52LinCod ;
      private bool n51SublCod ;
      private bool BRKDF7 ;
      private bool n254ComDProCod ;
      private bool n1696ProdFrecuente ;
      private bool returnInSub ;
      private string AV56Logo_GXI ;
      private string AV44Logo ;
      private string Logo ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private string aP2_ProdCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private int aP5_DocMonCod ;
      private string aP6_PrvCod ;
      private string aP7_Tipo ;
      private string aP8_Tipo2 ;
      private IDataStoreProvider pr_default ;
      private int[] P00DF2_A52LinCod ;
      private bool[] P00DF2_n52LinCod ;
      private string[] P00DF2_A1153LinDsc ;
      private int[] P00DF3_A51SublCod ;
      private bool[] P00DF3_n51SublCod ;
      private string[] P00DF3_A1892SublDsc ;
      private string[] P00DF4_A28ProdCod ;
      private string[] P00DF4_A55ProdDsc ;
      private int[] P00DF5_A180MonCod ;
      private string[] P00DF5_A1234MonDsc ;
      private string[] P00DF6_A149TipCod ;
      private string[] P00DF6_A243ComCod ;
      private string[] P00DF6_A254ComDProCod ;
      private bool[] P00DF6_n254ComDProCod ;
      private short[] P00DF6_A1696ProdFrecuente ;
      private bool[] P00DF6_n1696ProdFrecuente ;
      private DateTime[] P00DF6_A707ComFReg ;
      private string[] P00DF6_A244PrvCod ;
      private int[] P00DF6_A51SublCod ;
      private bool[] P00DF6_n51SublCod ;
      private int[] P00DF6_A52LinCod ;
      private bool[] P00DF6_n52LinCod ;
      private decimal[] P00DF6_A686ComDPre ;
      private string[] P00DF6_A694ComDDsc ;
      private short[] P00DF6_A250ComDItem ;
      private string[] P00DF6_A251ComDOrdCod ;
      private string[] P00DF7_A243ComCod ;
      private DateTime[] P00DF7_A707ComFReg ;
      private string[] P00DF7_A254ComDProCod ;
      private bool[] P00DF7_n254ComDProCod ;
      private string[] P00DF7_A244PrvCod ;
      private int[] P00DF7_A51SublCod ;
      private bool[] P00DF7_n51SublCod ;
      private int[] P00DF7_A52LinCod ;
      private bool[] P00DF7_n52LinCod ;
      private string[] P00DF7_A149TipCod ;
      private DateTime[] P00DF7_A248ComFec ;
      private DateTime[] P00DF7_A704ComFecPago ;
      private DateTime[] P00DF7_A724ComRefFec ;
      private short[] P00DF7_A511TipSigno ;
      private int[] P00DF7_A246ComMon ;
      private decimal[] P00DF7_A689ComDDct ;
      private decimal[] P00DF7_A686ComDPre ;
      private decimal[] P00DF7_A685ComDCant ;
      private short[] P00DF7_A250ComDItem ;
      private string[] P00DF7_A251ComDOrdCod ;
      private string[] P00DF8_A243ComCod ;
      private DateTime[] P00DF8_A707ComFReg ;
      private short[] P00DF8_A1696ProdFrecuente ;
      private bool[] P00DF8_n1696ProdFrecuente ;
      private string[] P00DF8_A254ComDProCod ;
      private bool[] P00DF8_n254ComDProCod ;
      private string[] P00DF8_A244PrvCod ;
      private int[] P00DF8_A51SublCod ;
      private bool[] P00DF8_n51SublCod ;
      private int[] P00DF8_A52LinCod ;
      private bool[] P00DF8_n52LinCod ;
      private string[] P00DF8_A149TipCod ;
      private DateTime[] P00DF8_A248ComFec ;
      private DateTime[] P00DF8_A704ComFecPago ;
      private DateTime[] P00DF8_A724ComRefFec ;
      private short[] P00DF8_A511TipSigno ;
      private int[] P00DF8_A246ComMon ;
      private decimal[] P00DF8_A689ComDDct ;
      private decimal[] P00DF8_A686ComDPre ;
      private decimal[] P00DF8_A685ComDCant ;
      private short[] P00DF8_A250ComDItem ;
      private string[] P00DF8_A251ComDOrdCod ;
      private string[] P00DF9_A243ComCod ;
      private DateTime[] P00DF9_A707ComFReg ;
      private short[] P00DF9_A1696ProdFrecuente ;
      private bool[] P00DF9_n1696ProdFrecuente ;
      private string[] P00DF9_A254ComDProCod ;
      private bool[] P00DF9_n254ComDProCod ;
      private string[] P00DF9_A244PrvCod ;
      private int[] P00DF9_A51SublCod ;
      private bool[] P00DF9_n51SublCod ;
      private int[] P00DF9_A52LinCod ;
      private bool[] P00DF9_n52LinCod ;
      private string[] P00DF9_A149TipCod ;
      private DateTime[] P00DF9_A248ComFec ;
      private DateTime[] P00DF9_A704ComFecPago ;
      private DateTime[] P00DF9_A724ComRefFec ;
      private short[] P00DF9_A511TipSigno ;
      private int[] P00DF9_A246ComMon ;
      private decimal[] P00DF9_A689ComDDct ;
      private decimal[] P00DF9_A686ComDPre ;
      private decimal[] P00DF9_A685ComDCant ;
      private short[] P00DF9_A250ComDItem ;
      private string[] P00DF9_A251ComDOrdCod ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV49SDTComprasProducto ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV48SDTComprasProductoITem ;
   }

   public class r_comprasproductosfrecuentespdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DF6( IGxContext context ,
                                             int AV30LinCod ,
                                             int AV31SubLCod ,
                                             string AV28ProdCod ,
                                             string AV46PrvCod ,
                                             string AV47Tipo ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A254ComDProCod ,
                                             string A244PrvCod ,
                                             short A1696ProdFrecuente ,
                                             DateTime A707ComFReg ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T1.[ComCod], T1.[ComDProCod] AS ComDProCod, T2.[ProdFrecuente], T3.[ComFReg], T1.[PrvCod], T2.[SublCod], T2.[LinCod], T1.[ComDPre], T1.[ComDDsc], T1.[ComDItem], T1.[ComDOrdCod] FROM (([CPCOMPRASDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ComDProCod]) INNER JOIN [CPCOMPRAS] T3 ON T3.[TipCod] = T1.[TipCod] AND T3.[ComCod] = T1.[ComCod] AND T3.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(Not T1.[ComDProCod] IS NULL)");
         AddWhere(sWhereString, "(T3.[ComFReg] >= @AV14FDesde and T3.[ComFReg] <= @AV15FHasta)");
         if ( ! (0==AV30LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV30LinCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV31SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV31SubLCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDProCod] = @AV28ProdCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV46PrvCod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV47Tipo, "F") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProdFrecuente] = 1)");
         }
         if ( ! ( StringUtil.StrCmp(AV47Tipo, "F") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProdFrecuente] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComDProCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00DF7( IGxContext context ,
                                             int AV30LinCod ,
                                             int AV31SubLCod ,
                                             string AV46PrvCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A244PrvCod ,
                                             string A254ComDProCod ,
                                             DateTime A707ComFReg ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta ,
                                             string AV28ProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[6];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[ComCod], T4.[ComFReg], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[SublCod], T2.[LinCod], T1.[TipCod], T4.[ComFec], T4.[ComFecPago], T4.[ComRefFec], T3.[TipSigno], T4.[ComMon], T1.[ComDDct], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem], T1.[ComDOrdCod] FROM ((([CPCOMPRASDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ComDProCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(T1.[ComDProCod] = @AV28ProdCod)");
         AddWhere(sWhereString, "(Not T1.[ComDProCod] IS NULL)");
         AddWhere(sWhereString, "(T4.[ComFReg] >= @AV14FDesde and T4.[ComFReg] <= @AV15FHasta)");
         if ( ! (0==AV30LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV30LinCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV31SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV31SubLCod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV46PrvCod)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComDProCod]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00DF8( IGxContext context ,
                                             int AV30LinCod ,
                                             int AV31SubLCod ,
                                             string AV46PrvCod ,
                                             string AV28ProdCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A244PrvCod ,
                                             string A254ComDProCod ,
                                             DateTime A707ComFReg ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta ,
                                             short A1696ProdFrecuente )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[6];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[ComCod], T4.[ComFReg], T2.[ProdFrecuente], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[SublCod], T2.[LinCod], T1.[TipCod], T4.[ComFec], T4.[ComFecPago], T4.[ComRefFec], T3.[TipSigno], T4.[ComMon], T1.[ComDDct], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem], T1.[ComDOrdCod] FROM ((([CPCOMPRASDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ComDProCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(Not T1.[ComDProCod] IS NULL)");
         AddWhere(sWhereString, "(T4.[ComFReg] >= @AV14FDesde and T4.[ComFReg] <= @AV15FHasta)");
         AddWhere(sWhereString, "(T2.[ProdFrecuente] = 1)");
         if ( ! (0==AV30LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV30LinCod)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (0==AV31SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV31SubLCod)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV46PrvCod)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDProCod] = @AV28ProdCod)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipCod], T1.[ComCod], T1.[PrvCod], T1.[ComDItem], T1.[ComDOrdCod]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00DF9( IGxContext context ,
                                             int AV30LinCod ,
                                             int AV31SubLCod ,
                                             string AV46PrvCod ,
                                             string AV28ProdCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A244PrvCod ,
                                             string A254ComDProCod ,
                                             DateTime A707ComFReg ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta ,
                                             short A1696ProdFrecuente )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[6];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.[ComCod], T4.[ComFReg], T2.[ProdFrecuente], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[SublCod], T2.[LinCod], T1.[TipCod], T4.[ComFec], T4.[ComFecPago], T4.[ComRefFec], T3.[TipSigno], T4.[ComMon], T1.[ComDDct], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem], T1.[ComDOrdCod] FROM ((([CPCOMPRASDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ComDProCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(Not T1.[ComDProCod] IS NULL)");
         AddWhere(sWhereString, "(T4.[ComFReg] >= @AV14FDesde and T4.[ComFReg] <= @AV15FHasta)");
         AddWhere(sWhereString, "(T2.[ProdFrecuente] = 0)");
         if ( ! (0==AV30LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV30LinCod)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! (0==AV31SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV31SubLCod)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV46PrvCod)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDProCod] = @AV28ProdCod)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipCod], T1.[ComCod], T1.[PrvCod], T1.[ComDItem], T1.[ComDOrdCod]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 4 :
                     return conditional_P00DF6(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] );
               case 5 :
                     return conditional_P00DF7(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] );
               case 6 :
                     return conditional_P00DF8(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] );
               case 7 :
                     return conditional_P00DF9(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DF2;
          prmP00DF2 = new Object[] {
          new ParDef("@AV30LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00DF3;
          prmP00DF3 = new Object[] {
          new ParDef("@AV31SubLCod",GXType.Int32,6,0)
          };
          Object[] prmP00DF4;
          prmP00DF4 = new Object[] {
          new ParDef("@AV28ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DF5;
          prmP00DF5 = new Object[] {
          new ParDef("@AV32DocMonCod",GXType.Int32,6,0)
          };
          Object[] prmP00DF6;
          prmP00DF6 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV30LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV31SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV28ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV46PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DF7;
          prmP00DF7 = new Object[] {
          new ParDef("@AV28ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV30LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV31SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV46PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DF8;
          prmP00DF8 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV30LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV31SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV46PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV28ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DF9;
          prmP00DF9 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV30LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV31SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV46PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV28ProdCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DF2", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV30LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DF2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DF3", "SELECT [SublCod], [SublDsc] FROM [CSUBLPROD] WHERE [SublCod] = @AV31SubLCod ORDER BY [SublCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DF3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DF4", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV28ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DF4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DF5", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV32DocMonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DF5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DF6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DF6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DF7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DF7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DF8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DF8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DF9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DF9,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 20);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((int[]) buf[10])[0] = rslt.getInt(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 100);
                ((short[]) buf[14])[0] = rslt.getShort(11);
                ((string[]) buf[15])[0] = rslt.getString(12, 10);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 3);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(10);
                ((short[]) buf[13])[0] = rslt.getShort(11);
                ((int[]) buf[14])[0] = rslt.getInt(12);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(15);
                ((short[]) buf[18])[0] = rslt.getShort(16);
                ((string[]) buf[19])[0] = rslt.getString(17, 10);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 20);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 3);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(11);
                ((short[]) buf[15])[0] = rslt.getShort(12);
                ((int[]) buf[16])[0] = rslt.getInt(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(16);
                ((short[]) buf[20])[0] = rslt.getShort(17);
                ((string[]) buf[21])[0] = rslt.getString(18, 10);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 20);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 3);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(11);
                ((short[]) buf[15])[0] = rslt.getShort(12);
                ((int[]) buf[16])[0] = rslt.getInt(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(16);
                ((short[]) buf[20])[0] = rslt.getShort(17);
                ((string[]) buf[21])[0] = rslt.getString(18, 10);
                return;
       }
    }

 }

}
