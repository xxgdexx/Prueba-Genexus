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
namespace GeneXus.Programs {
   public class rrpedidodetalle : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrpedidodetalle.aspx")), "rrpedidodetalle.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrpedidodetalle.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "CliCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV10CliCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV8TipCCod = (int)(NumberUtil.Val( GetPar( "TipCCod"), "."));
                  AV14MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV30FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV31FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV46PedCod = GetPar( "PedCod");
                  AV47TPedCod = (int)(NumberUtil.Val( GetPar( "TPedCod"), "."));
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

      public rrpedidodetalle( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrpedidodetalle( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CliCod ,
                           ref int aP1_TipCCod ,
                           ref int aP2_MonCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref string aP5_PedCod ,
                           ref int aP6_TPedCod )
      {
         this.AV10CliCod = aP0_CliCod;
         this.AV8TipCCod = aP1_TipCCod;
         this.AV14MonCod = aP2_MonCod;
         this.AV30FDesde = aP3_FDesde;
         this.AV31FHasta = aP4_FHasta;
         this.AV46PedCod = aP5_PedCod;
         this.AV47TPedCod = aP6_TPedCod;
         initialize();
         executePrivate();
         aP0_CliCod=this.AV10CliCod;
         aP1_TipCCod=this.AV8TipCCod;
         aP2_MonCod=this.AV14MonCod;
         aP3_FDesde=this.AV30FDesde;
         aP4_FHasta=this.AV31FHasta;
         aP5_PedCod=this.AV46PedCod;
         aP6_TPedCod=this.AV47TPedCod;
      }

      public int executeUdp( ref string aP0_CliCod ,
                             ref int aP1_TipCCod ,
                             ref int aP2_MonCod ,
                             ref DateTime aP3_FDesde ,
                             ref DateTime aP4_FHasta ,
                             ref string aP5_PedCod )
      {
         execute(ref aP0_CliCod, ref aP1_TipCCod, ref aP2_MonCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_PedCod, ref aP6_TPedCod);
         return AV47TPedCod ;
      }

      public void executeSubmit( ref string aP0_CliCod ,
                                 ref int aP1_TipCCod ,
                                 ref int aP2_MonCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref string aP5_PedCod ,
                                 ref int aP6_TPedCod )
      {
         rrpedidodetalle objrrpedidodetalle;
         objrrpedidodetalle = new rrpedidodetalle();
         objrrpedidodetalle.AV10CliCod = aP0_CliCod;
         objrrpedidodetalle.AV8TipCCod = aP1_TipCCod;
         objrrpedidodetalle.AV14MonCod = aP2_MonCod;
         objrrpedidodetalle.AV30FDesde = aP3_FDesde;
         objrrpedidodetalle.AV31FHasta = aP4_FHasta;
         objrrpedidodetalle.AV46PedCod = aP5_PedCod;
         objrrpedidodetalle.AV47TPedCod = aP6_TPedCod;
         objrrpedidodetalle.context.SetSubmitInitialConfig(context);
         objrrpedidodetalle.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrpedidodetalle);
         aP0_CliCod=this.AV10CliCod;
         aP1_TipCCod=this.AV8TipCCod;
         aP2_MonCod=this.AV14MonCod;
         aP3_FDesde=this.AV30FDesde;
         aP4_FHasta=this.AV31FHasta;
         aP5_PedCod=this.AV46PedCod;
         aP6_TPedCod=this.AV47TPedCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrpedidodetalle)stateInfo).executePrivate();
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
            AV38Empresa = AV43Session.Get("Empresa");
            AV39EmpDir = AV43Session.Get("EmpDir");
            AV40EmpRUC = AV43Session.Get("EmpRUC");
            AV41Ruta = AV43Session.Get("RUTA") + "/Logo.jpg";
            AV42Logo = AV41Ruta;
            AV50Logo_GXI = GXDbFile.PathToUrl( AV41Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV24Filtro3 = "Todos";
            AV25Filtro4 = AV30FDesde;
            AV26Filtro5 = AV31FHasta;
            /* Using cursor P00AH2 */
            pr_default.execute(0, new Object[] {AV10CliCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A45CliCod = P00AH2_A45CliCod[0];
               A161CliDsc = P00AH2_A161CliDsc[0];
               AV22Filtro1 = A161CliDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00AH3 */
            pr_default.execute(1, new Object[] {AV14MonCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A180MonCod = P00AH3_A180MonCod[0];
               A1234MonDsc = P00AH3_A1234MonDsc[0];
               AV23Filtro2 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV24Filtro3 = ((AV32Opcion==1) ? "Pendientes" : "Todos");
            AV19TotGImporte = 0.00m;
            AV20TotGPagos = 0.00m;
            AV21TotGSaldo = 0.00m;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV10CliCod ,
                                                 AV8TipCCod ,
                                                 AV14MonCod ,
                                                 AV47TPedCod ,
                                                 AV46PedCod ,
                                                 AV30FDesde ,
                                                 AV31FHasta ,
                                                 A45CliCod ,
                                                 A159TipCCod ,
                                                 A180MonCod ,
                                                 A212TPedCod ,
                                                 A210PedCod ,
                                                 A215PedFec ,
                                                 A1549PedCotiza } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00AH4 */
            pr_default.execute(2, new Object[] {AV10CliCod, AV8TipCCod, AV14MonCod, AV47TPedCod, AV46PedCod, AV30FDesde, AV31FHasta});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A210PedCod = P00AH4_A210PedCod[0];
               A215PedFec = P00AH4_A215PedFec[0];
               A1549PedCotiza = P00AH4_A1549PedCotiza[0];
               A212TPedCod = P00AH4_A212TPedCod[0];
               A180MonCod = P00AH4_A180MonCod[0];
               A159TipCCod = P00AH4_A159TipCCod[0];
               A45CliCod = P00AH4_A45CliCod[0];
               A1234MonDsc = P00AH4_A1234MonDsc[0];
               A161CliDsc = P00AH4_A161CliDsc[0];
               A1234MonDsc = P00AH4_A1234MonDsc[0];
               A159TipCCod = P00AH4_A159TipCCod[0];
               A161CliDsc = P00AH4_A161CliDsc[0];
               AV46PedCod = A210PedCod;
               HAH0( false, 55) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A161CliDsc, "")), 211, Gx_line+13, 595, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 611, Gx_line+13, 806, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A210PedCod, "")), 6, Gx_line+11, 109, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A215PedFec, "99/99/99"), 115, Gx_line+11, 204, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 7, Gx_line+38, 48, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+32, 807, Gx_line+55, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 100, Gx_line+38, 154, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Unidad", 331, Gx_line+38, 373, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 415, Gx_line+38, 468, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio", 514, Gx_line+38, 551, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Descuento", 609, Gx_line+38, 673, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total", 724, Gx_line+38, 755, Gx_line+52, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+55);
               AV34PedDCan = 0.00m;
               AV35PedDCanDsp = 0.00m;
               AV36PedDCanFac = 0.00m;
               /* Using cursor P00AH5 */
               pr_default.execute(3, new Object[] {A210PedCod});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A49UniCod = P00AH5_A49UniCod[0];
                  A1997UniAbr = P00AH5_A1997UniAbr[0];
                  A55ProdDsc = P00AH5_A55ProdDsc[0];
                  A28ProdCod = P00AH5_A28ProdCod[0];
                  A1554PedDCan = P00AH5_A1554PedDCan[0];
                  A1553PedDPre = P00AH5_A1553PedDPre[0];
                  A1551PedDTot = P00AH5_A1551PedDTot[0];
                  A216PedDItem = P00AH5_A216PedDItem[0];
                  A49UniCod = P00AH5_A49UniCod[0];
                  A1997UniAbr = P00AH5_A1997UniAbr[0];
                  A1552PedDSub = NumberUtil.Round( A1553PedDPre*A1554PedDCan, 4);
                  A1561PedDDcto = NumberUtil.Round( A1552PedDSub-A1551PedDTot, 4);
                  HAH0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 6, Gx_line+1, 94, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 88, Gx_line+1, 326, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1561PedDDcto, "ZZZZZZ,ZZZ,ZZ9.99")), 547, Gx_line+1, 654, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1553PedDPre, "ZZZZ,ZZZ,ZZ9.9999")), 457, Gx_line+1, 564, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1554PedDCan, "ZZZZ,ZZZ,ZZ9.9999")), 377, Gx_line+1, 484, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 327, Gx_line+1, 371, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1551PedDTot, "ZZZZ,ZZZ,ZZ9.99")), 639, Gx_line+1, 753, Gx_line+16, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               HAH0( false, 48) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 363, Gx_line+29, 404, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 440, Gx_line+30, 494, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 722, Gx_line+30, 775, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+25, 807, Gx_line+48, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Salidas de Almacen", 332, Gx_line+5, 447, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N. Salida", 52, Gx_line+30, 102, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 135, Gx_line+30, 170, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Almacen", 222, Gx_line+30, 274, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T/S", 16, Gx_line+30, 38, Gx_line+44, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+48);
               /* Execute user subroutine: 'MOVALMACENES' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               HAH0( false, 44) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 198, Gx_line+26, 239, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 281, Gx_line+26, 335, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 553, Gx_line+26, 606, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 138, Gx_line+26, 173, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Documentos de Ventas", 331, Gx_line+1, 467, Gx_line+15, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N. Doc.", 63, Gx_line+26, 103, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+21, 807, Gx_line+44, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("T/D", 6, Gx_line+26, 29, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio", 651, Gx_line+26, 688, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total", 736, Gx_line+26, 767, Gx_line+40, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+44);
               /* Execute user subroutine: 'COMPRAS' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAH0( true, 0) ;
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
         /* 'MOVALMACENES' Routine */
         returnInSub = false;
         /* Using cursor P00AH6 */
         pr_default.execute(4, new Object[] {AV46PedCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A21MvAlm = P00AH6_A21MvAlm[0];
            A1370MVSts = P00AH6_A1370MVSts[0];
            A20MVPedCod = P00AH6_A20MVPedCod[0];
            n20MVPedCod = P00AH6_n20MVPedCod[0];
            A13MvATip = P00AH6_A13MvATip[0];
            A1248MvADCant = P00AH6_A1248MvADCant[0];
            A55ProdDsc = P00AH6_A55ProdDsc[0];
            A28ProdCod = P00AH6_A28ProdCod[0];
            A1271MvAlmDsc = P00AH6_A1271MvAlmDsc[0];
            A25MvAFec = P00AH6_A25MvAFec[0];
            A14MvACod = P00AH6_A14MvACod[0];
            A30MvADItem = P00AH6_A30MvADItem[0];
            A55ProdDsc = P00AH6_A55ProdDsc[0];
            A21MvAlm = P00AH6_A21MvAlm[0];
            A1370MVSts = P00AH6_A1370MVSts[0];
            A20MVPedCod = P00AH6_A20MVPedCod[0];
            n20MVPedCod = P00AH6_n20MVPedCod[0];
            A25MvAFec = P00AH6_A25MvAFec[0];
            A1271MvAlmDsc = P00AH6_A1271MvAlmDsc[0];
            HAH0( false, 20) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 47, Gx_line+3, 111, Gx_line+18, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 126, Gx_line+3, 173, Gx_line+18, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1271MvAlmDsc, "")), 186, Gx_line+3, 353, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 356, Gx_line+3, 444, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 444, Gx_line+3, 713, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1248MvADCant, "ZZZZ,ZZZ,ZZ9.9999")), 692, Gx_line+3, 799, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13MvATip, "")), 10, Gx_line+3, 42, Gx_line+18, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S121( )
      {
         /* 'COMPRAS' Routine */
         returnInSub = false;
         /* Using cursor P00AH7 */
         pr_default.execute(5, new Object[] {AV46PedCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A149TipCod = P00AH7_A149TipCod[0];
            A941DocSts = P00AH7_A941DocSts[0];
            A937DocPedCod = P00AH7_A937DocPedCod[0];
            A892DocDTot = P00AH7_A892DocDTot[0];
            A894DocDpre = P00AH7_A894DocDpre[0];
            A895DocDCan = P00AH7_A895DocDCan[0];
            A55ProdDsc = P00AH7_A55ProdDsc[0];
            A28ProdCod = P00AH7_A28ProdCod[0];
            A232DocFec = P00AH7_A232DocFec[0];
            A24DocNum = P00AH7_A24DocNum[0];
            A306TipAbr = P00AH7_A306TipAbr[0];
            A233DocItem = P00AH7_A233DocItem[0];
            A306TipAbr = P00AH7_A306TipAbr[0];
            A55ProdDsc = P00AH7_A55ProdDsc[0];
            A941DocSts = P00AH7_A941DocSts[0];
            A937DocPedCod = P00AH7_A937DocPedCod[0];
            A232DocFec = P00AH7_A232DocFec[0];
            HAH0( false, 22) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 3, Gx_line+3, 39, Gx_line+19, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A24DocNum, "")), 58, Gx_line+4, 122, Gx_line+19, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A232DocFec, "99/99/99"), 139, Gx_line+4, 186, Gx_line+19, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 197, Gx_line+4, 276, Gx_line+19, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 280, Gx_line+4, 518, Gx_line+19, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A895DocDCan, "ZZZZ,ZZZ,ZZ9.9999")), 515, Gx_line+4, 622, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A894DocDpre, "ZZZZ,ZZZ,ZZ9.9999")), 607, Gx_line+4, 714, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A892DocDTot, "ZZZZ,ZZZ,ZZ9.99")), 670, Gx_line+4, 784, Gx_line+19, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+22);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void HAH0( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hora:", 627, Gx_line+32, 659, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 627, Gx_line+50, 671, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 627, Gx_line+15, 666, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 695, Gx_line+50, 734, Gx_line+65, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 672, Gx_line+32, 732, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 686, Gx_line+15, 733, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Reporte de Detalle de Pedidos", 266, Gx_line+52, 526, Gx_line+72, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cliente", 224, Gx_line+90, 266, Gx_line+104, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 224, Gx_line+111, 272, Gx_line+125, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 224, Gx_line+133, 250, Gx_line+147, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 224, Gx_line+155, 261, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta", 224, Gx_line+176, 259, Gx_line+190, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 281, Gx_line+84, 624, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro2, "")), 281, Gx_line+106, 624, Gx_line+130, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro3, "")), 281, Gx_line+128, 624, Gx_line+152, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV25Filtro4, "99/99/99"), 281, Gx_line+150, 624, Gx_line+174, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV26Filtro5, "99/99/99"), 281, Gx_line+171, 624, Gx_line+195, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV42Logo)) ? AV50Logo_GXI : AV42Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 11, Gx_line+16, 166, Gx_line+92) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+201);
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
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
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
         AV38Empresa = "";
         AV43Session = context.GetSession();
         AV39EmpDir = "";
         AV40EmpRUC = "";
         AV41Ruta = "";
         AV42Logo = "";
         AV50Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         AV25Filtro4 = DateTime.MinValue;
         AV26Filtro5 = DateTime.MinValue;
         scmdbuf = "";
         P00AH2_A45CliCod = new string[] {""} ;
         P00AH2_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         P00AH3_A180MonCod = new int[1] ;
         P00AH3_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         A210PedCod = "";
         A215PedFec = DateTime.MinValue;
         P00AH4_A210PedCod = new string[] {""} ;
         P00AH4_A215PedFec = new DateTime[] {DateTime.MinValue} ;
         P00AH4_A1549PedCotiza = new short[1] ;
         P00AH4_A212TPedCod = new int[1] ;
         P00AH4_A180MonCod = new int[1] ;
         P00AH4_A159TipCCod = new int[1] ;
         P00AH4_A45CliCod = new string[] {""} ;
         P00AH4_A1234MonDsc = new string[] {""} ;
         P00AH4_A161CliDsc = new string[] {""} ;
         P00AH5_A49UniCod = new int[1] ;
         P00AH5_A210PedCod = new string[] {""} ;
         P00AH5_A1997UniAbr = new string[] {""} ;
         P00AH5_A55ProdDsc = new string[] {""} ;
         P00AH5_A28ProdCod = new string[] {""} ;
         P00AH5_A1554PedDCan = new decimal[1] ;
         P00AH5_A1553PedDPre = new decimal[1] ;
         P00AH5_A1551PedDTot = new decimal[1] ;
         P00AH5_A216PedDItem = new short[1] ;
         A1997UniAbr = "";
         A55ProdDsc = "";
         A28ProdCod = "";
         P00AH6_A21MvAlm = new int[1] ;
         P00AH6_A1370MVSts = new string[] {""} ;
         P00AH6_A20MVPedCod = new string[] {""} ;
         P00AH6_n20MVPedCod = new bool[] {false} ;
         P00AH6_A13MvATip = new string[] {""} ;
         P00AH6_A1248MvADCant = new decimal[1] ;
         P00AH6_A55ProdDsc = new string[] {""} ;
         P00AH6_A28ProdCod = new string[] {""} ;
         P00AH6_A1271MvAlmDsc = new string[] {""} ;
         P00AH6_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00AH6_A14MvACod = new string[] {""} ;
         P00AH6_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A20MVPedCod = "";
         A13MvATip = "";
         A1271MvAlmDsc = "";
         A25MvAFec = DateTime.MinValue;
         A14MvACod = "";
         P00AH7_A149TipCod = new string[] {""} ;
         P00AH7_A941DocSts = new string[] {""} ;
         P00AH7_A937DocPedCod = new string[] {""} ;
         P00AH7_A892DocDTot = new decimal[1] ;
         P00AH7_A894DocDpre = new decimal[1] ;
         P00AH7_A895DocDCan = new decimal[1] ;
         P00AH7_A55ProdDsc = new string[] {""} ;
         P00AH7_A28ProdCod = new string[] {""} ;
         P00AH7_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00AH7_A24DocNum = new string[] {""} ;
         P00AH7_A306TipAbr = new string[] {""} ;
         P00AH7_A233DocItem = new long[1] ;
         A149TipCod = "";
         A941DocSts = "";
         A937DocPedCod = "";
         A232DocFec = DateTime.MinValue;
         A24DocNum = "";
         A306TipAbr = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV42Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrpedidodetalle__default(),
            new Object[][] {
                new Object[] {
               P00AH2_A45CliCod, P00AH2_A161CliDsc
               }
               , new Object[] {
               P00AH3_A180MonCod, P00AH3_A1234MonDsc
               }
               , new Object[] {
               P00AH4_A210PedCod, P00AH4_A215PedFec, P00AH4_A1549PedCotiza, P00AH4_A212TPedCod, P00AH4_A180MonCod, P00AH4_A159TipCCod, P00AH4_A45CliCod, P00AH4_A1234MonDsc, P00AH4_A161CliDsc
               }
               , new Object[] {
               P00AH5_A49UniCod, P00AH5_A210PedCod, P00AH5_A1997UniAbr, P00AH5_A55ProdDsc, P00AH5_A28ProdCod, P00AH5_A1554PedDCan, P00AH5_A1553PedDPre, P00AH5_A1551PedDTot, P00AH5_A216PedDItem
               }
               , new Object[] {
               P00AH6_A21MvAlm, P00AH6_A1370MVSts, P00AH6_A20MVPedCod, P00AH6_n20MVPedCod, P00AH6_A13MvATip, P00AH6_A1248MvADCant, P00AH6_A55ProdDsc, P00AH6_A28ProdCod, P00AH6_A1271MvAlmDsc, P00AH6_A25MvAFec,
               P00AH6_A14MvACod, P00AH6_A30MvADItem
               }
               , new Object[] {
               P00AH7_A149TipCod, P00AH7_A941DocSts, P00AH7_A937DocPedCod, P00AH7_A892DocDTot, P00AH7_A894DocDpre, P00AH7_A895DocDCan, P00AH7_A55ProdDsc, P00AH7_A28ProdCod, P00AH7_A232DocFec, P00AH7_A24DocNum,
               P00AH7_A306TipAbr, P00AH7_A233DocItem
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV32Opcion ;
      private short A1549PedCotiza ;
      private short A216PedDItem ;
      private int AV8TipCCod ;
      private int AV14MonCod ;
      private int AV47TPedCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int A159TipCCod ;
      private int A212TPedCod ;
      private int Gx_OldLine ;
      private int A49UniCod ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private long A233DocItem ;
      private decimal AV19TotGImporte ;
      private decimal AV20TotGPagos ;
      private decimal AV21TotGSaldo ;
      private decimal AV34PedDCan ;
      private decimal AV35PedDCanDsp ;
      private decimal AV36PedDCanFac ;
      private decimal A1554PedDCan ;
      private decimal A1553PedDPre ;
      private decimal A1551PedDTot ;
      private decimal A1552PedDSub ;
      private decimal A1561PedDDcto ;
      private decimal A1248MvADCant ;
      private decimal A892DocDTot ;
      private decimal A894DocDpre ;
      private decimal A895DocDCan ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10CliCod ;
      private string AV46PedCod ;
      private string AV38Empresa ;
      private string AV39EmpDir ;
      private string AV40EmpRUC ;
      private string AV41Ruta ;
      private string AV22Filtro1 ;
      private string AV23Filtro2 ;
      private string AV24Filtro3 ;
      private string scmdbuf ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A1234MonDsc ;
      private string A210PedCod ;
      private string A1997UniAbr ;
      private string A55ProdDsc ;
      private string A28ProdCod ;
      private string A1370MVSts ;
      private string A20MVPedCod ;
      private string A13MvATip ;
      private string A1271MvAlmDsc ;
      private string A14MvACod ;
      private string A149TipCod ;
      private string A941DocSts ;
      private string A937DocPedCod ;
      private string A24DocNum ;
      private string A306TipAbr ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV30FDesde ;
      private DateTime AV31FHasta ;
      private DateTime AV25Filtro4 ;
      private DateTime AV26Filtro5 ;
      private DateTime A215PedFec ;
      private DateTime A25MvAFec ;
      private DateTime A232DocFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool n20MVPedCod ;
      private string AV50Logo_GXI ;
      private string AV42Logo ;
      private string Logo ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CliCod ;
      private int aP1_TipCCod ;
      private int aP2_MonCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private string aP5_PedCod ;
      private int aP6_TPedCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00AH2_A45CliCod ;
      private string[] P00AH2_A161CliDsc ;
      private int[] P00AH3_A180MonCod ;
      private string[] P00AH3_A1234MonDsc ;
      private string[] P00AH4_A210PedCod ;
      private DateTime[] P00AH4_A215PedFec ;
      private short[] P00AH4_A1549PedCotiza ;
      private int[] P00AH4_A212TPedCod ;
      private int[] P00AH4_A180MonCod ;
      private int[] P00AH4_A159TipCCod ;
      private string[] P00AH4_A45CliCod ;
      private string[] P00AH4_A1234MonDsc ;
      private string[] P00AH4_A161CliDsc ;
      private int[] P00AH5_A49UniCod ;
      private string[] P00AH5_A210PedCod ;
      private string[] P00AH5_A1997UniAbr ;
      private string[] P00AH5_A55ProdDsc ;
      private string[] P00AH5_A28ProdCod ;
      private decimal[] P00AH5_A1554PedDCan ;
      private decimal[] P00AH5_A1553PedDPre ;
      private decimal[] P00AH5_A1551PedDTot ;
      private short[] P00AH5_A216PedDItem ;
      private int[] P00AH6_A21MvAlm ;
      private string[] P00AH6_A1370MVSts ;
      private string[] P00AH6_A20MVPedCod ;
      private bool[] P00AH6_n20MVPedCod ;
      private string[] P00AH6_A13MvATip ;
      private decimal[] P00AH6_A1248MvADCant ;
      private string[] P00AH6_A55ProdDsc ;
      private string[] P00AH6_A28ProdCod ;
      private string[] P00AH6_A1271MvAlmDsc ;
      private DateTime[] P00AH6_A25MvAFec ;
      private string[] P00AH6_A14MvACod ;
      private int[] P00AH6_A30MvADItem ;
      private string[] P00AH7_A149TipCod ;
      private string[] P00AH7_A941DocSts ;
      private string[] P00AH7_A937DocPedCod ;
      private decimal[] P00AH7_A892DocDTot ;
      private decimal[] P00AH7_A894DocDpre ;
      private decimal[] P00AH7_A895DocDCan ;
      private string[] P00AH7_A55ProdDsc ;
      private string[] P00AH7_A28ProdCod ;
      private DateTime[] P00AH7_A232DocFec ;
      private string[] P00AH7_A24DocNum ;
      private string[] P00AH7_A306TipAbr ;
      private long[] P00AH7_A233DocItem ;
   }

   public class rrpedidodetalle__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AH4( IGxContext context ,
                                             string AV10CliCod ,
                                             int AV8TipCCod ,
                                             int AV14MonCod ,
                                             int AV47TPedCod ,
                                             string AV46PedCod ,
                                             DateTime AV30FDesde ,
                                             DateTime AV31FHasta ,
                                             string A45CliCod ,
                                             int A159TipCCod ,
                                             int A180MonCod ,
                                             int A212TPedCod ,
                                             string A210PedCod ,
                                             DateTime A215PedFec ,
                                             short A1549PedCotiza )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[PedCod], T1.[PedFec], T1.[PedCotiza], T1.[TPedCod], T1.[MonCod], T3.[TipCCod], T1.[CliCod], T2.[MonDsc], T3.[CliDsc] FROM (([CLPEDIDOS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[MonCod]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T1.[CliCod])";
         AddWhere(sWhereString, "(T1.[PedCotiza] = 0)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV10CliCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV8TipCCod) )
         {
            AddWhere(sWhereString, "(T3.[TipCCod] = @AV8TipCCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV47TPedCod) )
         {
            AddWhere(sWhereString, "(T1.[TPedCod] = @AV47TPedCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46PedCod)) )
         {
            AddWhere(sWhereString, "(T1.[PedCod] = @AV46PedCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV30FDesde) && ! (DateTime.MinValue==AV31FHasta) )
         {
            AddWhere(sWhereString, "(T1.[PedFec] >= @AV30FDesde and T1.[PedFec] <= @AV31FHasta)");
         }
         else
         {
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PedCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P00AH4(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AH2;
          prmP00AH2 = new Object[] {
          new ParDef("@AV10CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00AH3;
          prmP00AH3 = new Object[] {
          new ParDef("@AV14MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00AH5;
          prmP00AH5 = new Object[] {
          new ParDef("@PedCod",GXType.NChar,10,0)
          };
          Object[] prmP00AH6;
          prmP00AH6 = new Object[] {
          new ParDef("@AV46PedCod",GXType.NChar,10,0)
          };
          Object[] prmP00AH7;
          prmP00AH7 = new Object[] {
          new ParDef("@AV46PedCod",GXType.NChar,10,0)
          };
          Object[] prmP00AH4;
          prmP00AH4 = new Object[] {
          new ParDef("@AV10CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV8TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV47TPedCod",GXType.Int32,6,0) ,
          new ParDef("@AV46PedCod",GXType.NChar,10,0) ,
          new ParDef("@AV30FDesde",GXType.Date,8,0) ,
          new ParDef("@AV31FHasta",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AH2", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV10CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AH2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AH3", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV14MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AH3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AH4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AH4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AH5", "SELECT T2.[UniCod], T1.[PedCod], T3.[UniAbr], T1.[ProdDsc], T1.[ProdCod], T1.[PedDCan], T1.[PedDPre], T1.[PedDTot], T1.[PedDItem] FROM (([CLPEDIDOSDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) WHERE T1.[PedCod] = @PedCod ORDER BY T1.[PedCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AH5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AH6", "SELECT T3.[MvAlm] AS MvAlm, T3.[MVSts], T3.[MVPedCod], T1.[MvATip], T1.[MvADCant], T2.[ProdDsc], T1.[ProdCod], T4.[AlmDsc] AS MvAlmDsc, T3.[MvAFec], T1.[MvACod], T1.[MvADItem] FROM ((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [AGUIAS] T3 ON T3.[MvATip] = T1.[MvATip] AND T3.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T3.[MvAlm]) WHERE (T3.[MVSts] <> 'A') AND (T3.[MVPedCod] = @AV46PedCod) ORDER BY T1.[MvATip], T1.[MvACod], T1.[MvADItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AH6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AH7", "SELECT T1.[TipCod], T4.[DocSts], T4.[DocPedCod], T1.[DocDTot], T1.[DocDpre], T1.[DocDCan], T3.[ProdDsc], T1.[ProdCod], T4.[DocFec], T1.[DocNum], T2.[TipAbr], T1.[DocItem] FROM ((([CLVENTASDET] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLVENTAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum]) WHERE (T4.[DocSts] <> 'A') AND (T4.[DocPedCod] = @AV46PedCod) ORDER BY T1.[TipCod], T1.[DocNum], T1.[DocItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AH7,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((string[]) buf[7])[0] = rslt.getString(7, 15);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 12);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 15);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 12);
                ((string[]) buf[10])[0] = rslt.getString(11, 5);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                return;
       }
    }

 }

}
