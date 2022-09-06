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
   public class rrventasproductossig : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrventasproductossig.aspx")), "rrventasproductossig.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrventasproductossig.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "FDesde");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV27FDesde = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV29FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV40Moneda = (int)(NumberUtil.Val( GetPar( "Moneda"), "."));
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

      public rrventasproductossig( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrventasproductossig( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FDesde ,
                           ref DateTime aP1_FHasta ,
                           ref int aP2_Moneda )
      {
         this.AV27FDesde = aP0_FDesde;
         this.AV29FHasta = aP1_FHasta;
         this.AV40Moneda = aP2_Moneda;
         initialize();
         executePrivate();
         aP0_FDesde=this.AV27FDesde;
         aP1_FHasta=this.AV29FHasta;
         aP2_Moneda=this.AV40Moneda;
      }

      public int executeUdp( ref DateTime aP0_FDesde ,
                             ref DateTime aP1_FHasta )
      {
         execute(ref aP0_FDesde, ref aP1_FHasta, ref aP2_Moneda);
         return AV40Moneda ;
      }

      public void executeSubmit( ref DateTime aP0_FDesde ,
                                 ref DateTime aP1_FHasta ,
                                 ref int aP2_Moneda )
      {
         rrventasproductossig objrrventasproductossig;
         objrrventasproductossig = new rrventasproductossig();
         objrrventasproductossig.AV27FDesde = aP0_FDesde;
         objrrventasproductossig.AV29FHasta = aP1_FHasta;
         objrrventasproductossig.AV40Moneda = aP2_Moneda;
         objrrventasproductossig.context.SetSubmitInitialConfig(context);
         objrrventasproductossig.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrventasproductossig);
         aP0_FDesde=this.AV27FDesde;
         aP1_FHasta=this.AV29FHasta;
         aP2_Moneda=this.AV40Moneda;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrventasproductossig)stateInfo).executePrivate();
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
            AV24Empresa = AV57Session.Get("Empresa");
            AV23EmpDir = AV57Session.Get("EmpDir");
            AV25EmpRUC = AV57Session.Get("EmpRUC");
            AV54Ruta = AV57Session.Get("RUTA") + "/Logo.jpg";
            AV37Logo = AV54Ruta;
            AV78Logo_GXI = GXDbFile.PathToUrl( AV54Ruta);
            AV30Filtro1 = "Todos";
            AV31Filtro2 = "Todos";
            AV32Filtro3 = "Todos";
            AV33Filtro4 = "Todos";
            AV68TotalGeneral = 0.00m;
            AV69TotalGeneralME = 0.00m;
            /* Using cursor P00ER2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1159LinSts = P00ER2_A1159LinSts[0];
               A1153LinDsc = P00ER2_A1153LinDsc[0];
               A52LinCod = P00ER2_A52LinCod[0];
               AV35LinCod = A52LinCod;
               AV36LinDsc = A1153LinDsc;
               /* Execute user subroutine: 'VENTASLINEAPRODUCTOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! (Convert.ToDecimal(0)==AV38Mes1) )
               {
                  AV56SDTVentaProductosITem.gxTpr_Clicod = StringUtil.Trim( StringUtil.Str( (decimal)(AV35LinCod), 10, 0));
                  AV56SDTVentaProductosITem.gxTpr_Clidsc = AV36LinDsc;
                  AV56SDTVentaProductosITem.gxTpr_Cantidad = (decimal)(0);
                  AV56SDTVentaProductosITem.gxTpr_Importe = AV38Mes1;
                  AV56SDTVentaProductosITem.gxTpr_Importe1 = (decimal)(0);
                  AV55SDTVentaProductos.Add(AV56SDTVentaProductosITem, 0);
                  AV56SDTVentaProductosITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV55SDTVentaProductos.Sort("[Importe]");
            AV68TotalGeneral = 0.00m;
            AV69TotalGeneralME = 0.00m;
            AV83GXV1 = 1;
            while ( AV83GXV1 <= AV55SDTVentaProductos.Count )
            {
               AV56SDTVentaProductosITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV55SDTVentaProductos.Item(AV83GXV1));
               AV47ProdCod = AV56SDTVentaProductosITem.gxTpr_Clicod;
               AV48ProdDsc = AV56SDTVentaProductosITem.gxTpr_Clidsc;
               AV12Cantidad = AV56SDTVentaProductosITem.gxTpr_Cantidad;
               AV72TotalVenta = AV56SDTVentaProductosITem.gxTpr_Importe;
               AV73TotalVentaME = AV56SDTVentaProductosITem.gxTpr_Importe1;
               HER0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47ProdCod, "@!")), 10, Gx_line+3, 117, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48ProdDsc, "")), 121, Gx_line+3, 451, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72TotalVenta, "ZZZZZZ,ZZZ,ZZ9.99")), 546, Gx_line+3, 670, Gx_line+16, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV68TotalGeneral = (decimal)(AV68TotalGeneral+AV72TotalVenta);
               AV69TotalGeneralME = (decimal)(AV69TotalGeneralME+AV73TotalVentaME);
               AV83GXV1 = (int)(AV83GXV1+1);
            }
            HER0( false, 52) ;
            getPrinter().GxDrawLine(562, Gx_line+9, 683, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 417, Gx_line+17, 497, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68TotalGeneral, "ZZZZZZ,ZZZ,ZZ9.99")), 564, Gx_line+16, 671, Gx_line+31, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HER0( true, 0) ;
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
         /* 'VENTASLINEAPRODUCTOS' Routine */
         returnInSub = false;
         AV38Mes1 = 0.00m;
         AV20DocMonCod = AV40Moneda;
         /* Using cursor P00ER3 */
         pr_default.execute(1, new Object[] {AV27FDesde, AV29FHasta, AV35LinCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A24DocNum = P00ER3_A24DocNum[0];
            A28ProdCod = P00ER3_A28ProdCod[0];
            A941DocSts = P00ER3_A941DocSts[0];
            A232DocFec = P00ER3_A232DocFec[0];
            A52LinCod = P00ER3_A52LinCod[0];
            A230DocMonCod = P00ER3_A230DocMonCod[0];
            A149TipCod = P00ER3_A149TipCod[0];
            A511TipSigno = P00ER3_A511TipSigno[0];
            A892DocDTot = P00ER3_A892DocDTot[0];
            A929DocFecRef = P00ER3_A929DocFecRef[0];
            A233DocItem = P00ER3_A233DocItem[0];
            A52LinCod = P00ER3_A52LinCod[0];
            A511TipSigno = P00ER3_A511TipSigno[0];
            A941DocSts = P00ER3_A941DocSts[0];
            A232DocFec = P00ER3_A232DocFec[0];
            A230DocMonCod = P00ER3_A230DocMonCod[0];
            A929DocFecRef = P00ER3_A929DocFecRef[0];
            AV39MonCod = A230DocMonCod;
            AV63TipCod = A149TipCod;
            AV28Fecha = A232DocFec;
            AV8Importe = NumberUtil.Round( (A892DocDTot)*A511TipSigno, 2);
            if ( ( StringUtil.StrCmp(AV63TipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV63TipCod, "ND") == 0 ) )
            {
               AV28Fecha = A929DocFecRef;
            }
            if ( AV20DocMonCod != 1 )
            {
               if ( AV39MonCod == 1 )
               {
                  GXt_decimal1 = AV10Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV39MonCod, ref  AV28Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV10Cambio = GXt_decimal1;
                  AV8Importe = NumberUtil.Round( AV8Importe/ (decimal)(AV10Cambio), 2);
               }
            }
            else
            {
               if ( AV39MonCod != 1 )
               {
                  GXt_decimal1 = AV10Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV39MonCod, ref  AV28Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV10Cambio = GXt_decimal1;
                  AV8Importe = NumberUtil.Round( AV8Importe*AV10Cambio, 2);
               }
            }
            AV38Mes1 = (decimal)(AV38Mes1+AV8Importe);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void HER0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 669, Gx_line+43, 701, Gx_line+57, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 669, Gx_line+63, 713, Gx_line+77, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 669, Gx_line+24, 708, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+123, 797, Gx_line+149, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 714, Gx_line+24, 761, Gx_line+39, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 699, Gx_line+43, 759, Gx_line+57, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 722, Gx_line+63, 761, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 18, Gx_line+129, 59, Gx_line+143, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Venta", 592, Gx_line+129, 661, Gx_line+143, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Linea", 125, Gx_line+129, 157, Gx_line+143, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV37Logo)) ? AV78Logo_GXI : AV37Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+19, 176, Gx_line+97) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Ventas por Lineas", 256, Gx_line+43, 517, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Del :", 274, Gx_line+65, 315, Gx_line+85, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV27FDesde, "99/99/99"), 323, Gx_line+63, 397, Gx_line+87, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 399, Gx_line+65, 429, Gx_line+85, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV29FHasta, "99/99/99"), 433, Gx_line+63, 507, Gx_line+87, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Expresado en :", 242, Gx_line+88, 369, Gx_line+108, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Filtro5, "")), 374, Gx_line+85, 563, Gx_line+109, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+149);
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
         AV24Empresa = "";
         AV57Session = context.GetSession();
         AV23EmpDir = "";
         AV25EmpRUC = "";
         AV54Ruta = "";
         AV37Logo = "";
         AV78Logo_GXI = "";
         AV30Filtro1 = "";
         AV31Filtro2 = "";
         AV32Filtro3 = "";
         AV33Filtro4 = "";
         scmdbuf = "";
         P00ER2_A1159LinSts = new short[1] ;
         P00ER2_A1153LinDsc = new string[] {""} ;
         P00ER2_A52LinCod = new int[1] ;
         A1153LinDsc = "";
         AV36LinDsc = "";
         AV56SDTVentaProductosITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV55SDTVentaProductos = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         AV47ProdCod = "";
         AV48ProdDsc = "";
         P00ER3_A24DocNum = new string[] {""} ;
         P00ER3_A28ProdCod = new string[] {""} ;
         P00ER3_A941DocSts = new string[] {""} ;
         P00ER3_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00ER3_A52LinCod = new int[1] ;
         P00ER3_A230DocMonCod = new int[1] ;
         P00ER3_A149TipCod = new string[] {""} ;
         P00ER3_A511TipSigno = new short[1] ;
         P00ER3_A892DocDTot = new decimal[1] ;
         P00ER3_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P00ER3_A233DocItem = new long[1] ;
         A24DocNum = "";
         A28ProdCod = "";
         A941DocSts = "";
         A232DocFec = DateTime.MinValue;
         A149TipCod = "";
         A929DocFecRef = DateTime.MinValue;
         AV63TipCod = "";
         AV28Fecha = DateTime.MinValue;
         GXt_char2 = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV37Logo = "";
         sImgUrl = "";
         AV34Filtro5 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrventasproductossig__default(),
            new Object[][] {
                new Object[] {
               P00ER2_A1159LinSts, P00ER2_A1153LinDsc, P00ER2_A52LinCod
               }
               , new Object[] {
               P00ER3_A24DocNum, P00ER3_A28ProdCod, P00ER3_A941DocSts, P00ER3_A232DocFec, P00ER3_A52LinCod, P00ER3_A230DocMonCod, P00ER3_A149TipCod, P00ER3_A511TipSigno, P00ER3_A892DocDTot, P00ER3_A929DocFecRef,
               P00ER3_A233DocItem
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
      private short A1159LinSts ;
      private short A511TipSigno ;
      private int AV40Moneda ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A52LinCod ;
      private int AV35LinCod ;
      private int AV83GXV1 ;
      private int Gx_OldLine ;
      private int AV20DocMonCod ;
      private int A230DocMonCod ;
      private int AV39MonCod ;
      private long A233DocItem ;
      private decimal AV68TotalGeneral ;
      private decimal AV69TotalGeneralME ;
      private decimal AV38Mes1 ;
      private decimal AV12Cantidad ;
      private decimal AV72TotalVenta ;
      private decimal AV73TotalVentaME ;
      private decimal A892DocDTot ;
      private decimal AV8Importe ;
      private decimal AV10Cambio ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV24Empresa ;
      private string AV23EmpDir ;
      private string AV25EmpRUC ;
      private string AV54Ruta ;
      private string AV30Filtro1 ;
      private string AV31Filtro2 ;
      private string AV32Filtro3 ;
      private string AV33Filtro4 ;
      private string scmdbuf ;
      private string A1153LinDsc ;
      private string AV36LinDsc ;
      private string AV47ProdCod ;
      private string AV48ProdDsc ;
      private string A24DocNum ;
      private string A28ProdCod ;
      private string A941DocSts ;
      private string A149TipCod ;
      private string AV63TipCod ;
      private string GXt_char2 ;
      private string Gx_time ;
      private string sImgUrl ;
      private string AV34Filtro5 ;
      private DateTime AV27FDesde ;
      private DateTime AV29FHasta ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV28Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private string AV78Logo_GXI ;
      private string AV37Logo ;
      private string Logo ;
      private IGxSession AV57Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FDesde ;
      private DateTime aP1_FHasta ;
      private int aP2_Moneda ;
      private IDataStoreProvider pr_default ;
      private short[] P00ER2_A1159LinSts ;
      private string[] P00ER2_A1153LinDsc ;
      private int[] P00ER2_A52LinCod ;
      private string[] P00ER3_A24DocNum ;
      private string[] P00ER3_A28ProdCod ;
      private string[] P00ER3_A941DocSts ;
      private DateTime[] P00ER3_A232DocFec ;
      private int[] P00ER3_A52LinCod ;
      private int[] P00ER3_A230DocMonCod ;
      private string[] P00ER3_A149TipCod ;
      private short[] P00ER3_A511TipSigno ;
      private decimal[] P00ER3_A892DocDTot ;
      private DateTime[] P00ER3_A929DocFecRef ;
      private long[] P00ER3_A233DocItem ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV55SDTVentaProductos ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV56SDTVentaProductosITem ;
   }

   public class rrventasproductossig__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00ER2;
          prmP00ER2 = new Object[] {
          };
          Object[] prmP00ER3;
          prmP00ER3 = new Object[] {
          new ParDef("@AV27FDesde",GXType.Date,8,0) ,
          new ParDef("@AV29FHasta",GXType.Date,8,0) ,
          new ParDef("@AV35LinCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00ER2", "SELECT [LinSts], [LinDsc], [LinCod] FROM [CLINEAPROD] WHERE [LinSts] = 1 ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ER2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00ER3", "SELECT T1.[DocNum], T1.[ProdCod], T4.[DocSts], T4.[DocFec], T2.[LinCod], T4.[DocMonCod], T1.[TipCod], T3.[TipSigno], T1.[DocDTot], T4.[DocFecRef], T1.[DocItem] FROM ((([CLVENTASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CLVENTAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum]) WHERE (T4.[DocFec] >= @AV27FDesde) AND (T4.[DocFec] <= @AV29FHasta) AND (T4.[DocSts] <> 'A') AND (T2.[LinCod] = @AV35LinCod) ORDER BY T1.[TipCod], T1.[DocNum], T1.[DocItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ER3,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 3);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
       }
    }

 }

}
