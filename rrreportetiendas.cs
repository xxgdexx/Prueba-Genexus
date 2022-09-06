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
   public class rrreportetiendas : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrreportetiendas.aspx")), "rrreportetiendas.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrreportetiendas.aspx")))) ;
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
               AV18FDesde = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV20FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV31Moneda = (int)(NumberUtil.Val( GetPar( "Moneda"), "."));
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

      public rrreportetiendas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrreportetiendas( IGxContext context )
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
         this.AV18FDesde = aP0_FDesde;
         this.AV20FHasta = aP1_FHasta;
         this.AV31Moneda = aP2_Moneda;
         initialize();
         executePrivate();
         aP0_FDesde=this.AV18FDesde;
         aP1_FHasta=this.AV20FHasta;
         aP2_Moneda=this.AV31Moneda;
      }

      public int executeUdp( ref DateTime aP0_FDesde ,
                             ref DateTime aP1_FHasta )
      {
         execute(ref aP0_FDesde, ref aP1_FHasta, ref aP2_Moneda);
         return AV31Moneda ;
      }

      public void executeSubmit( ref DateTime aP0_FDesde ,
                                 ref DateTime aP1_FHasta ,
                                 ref int aP2_Moneda )
      {
         rrreportetiendas objrrreportetiendas;
         objrrreportetiendas = new rrreportetiendas();
         objrrreportetiendas.AV18FDesde = aP0_FDesde;
         objrrreportetiendas.AV20FHasta = aP1_FHasta;
         objrrreportetiendas.AV31Moneda = aP2_Moneda;
         objrrreportetiendas.context.SetSubmitInitialConfig(context);
         objrrreportetiendas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrreportetiendas);
         aP0_FDesde=this.AV18FDesde;
         aP1_FHasta=this.AV20FHasta;
         aP2_Moneda=this.AV31Moneda;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrreportetiendas)stateInfo).executePrivate();
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
            AV14Empresa = AV42Session.Get("Empresa");
            AV13EmpDir = AV42Session.Get("EmpDir");
            AV15EmpRUC = AV42Session.Get("EmpRUC");
            AV40Ruta = AV42Session.Get("RUTA") + "/Logo.jpg";
            AV28Logo = AV40Ruta;
            AV58Logo_GXI = GXDbFile.PathToUrl( AV40Ruta);
            AV21Filtro1 = context.localUtil.DToC( AV18FDesde, 2, "/");
            AV22Filtro2 = context.localUtil.DToC( AV20FHasta, 2, "/");
            AV23Filtro3 = "Todos";
            /* Using cursor P009I2 */
            pr_default.execute(0, new Object[] {AV31Moneda});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P009I2_A180MonCod[0];
               A1234MonDsc = P009I2_A1234MonDsc[0];
               AV23Filtro3 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV47TMes = 0.00m;
            /* Using cursor P009I3 */
            pr_default.execute(1, new Object[] {AV18FDesde, AV20FHasta});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRK9I4 = false;
               A1898TieDsc = P009I3_A1898TieDsc[0];
               A178TieCod = P009I3_A178TieCod[0];
               n178TieCod = P009I3_n178TieCod[0];
               A941DocSts = P009I3_A941DocSts[0];
               A232DocFec = P009I3_A232DocFec[0];
               A149TipCod = P009I3_A149TipCod[0];
               A24DocNum = P009I3_A24DocNum[0];
               A1898TieDsc = P009I3_A1898TieDsc[0];
               while ( (pr_default.getStatus(1) != 101) && ( P009I3_A178TieCod[0] == A178TieCod ) )
               {
                  BRK9I4 = false;
                  A1898TieDsc = P009I3_A1898TieDsc[0];
                  A149TipCod = P009I3_A149TipCod[0];
                  A24DocNum = P009I3_A24DocNum[0];
                  A1898TieDsc = P009I3_A1898TieDsc[0];
                  BRK9I4 = true;
                  pr_default.readNext(1);
               }
               AV43TieCod = A178TieCod;
               AV44TieDsc = A1898TieDsc;
               /* Execute user subroutine: 'VENTASTIPOLOCAL' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! (Convert.ToDecimal(0)==AV29Mes1) )
               {
                  H9I0( false, 23) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV43TieCod), "ZZZZZ9")), 24, Gx_line+4, 58, Gx_line+19, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TieDsc, "")), 85, Gx_line+4, 433, Gx_line+19, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Mes1, "ZZZZZZ,ZZZ,ZZ9.99")), 425, Gx_line+5, 546, Gx_line+20, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+23);
                  AV47TMes = (decimal)(AV47TMes+AV29Mes1);
               }
               if ( ! BRK9I4 )
               {
                  BRK9I4 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
            H9I0( false, 29) ;
            getPrinter().GxDrawLine(435, Gx_line+5, 557, Gx_line+5, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 336, Gx_line+10, 416, Gx_line+24, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TMes, "ZZZZZZ,ZZZ,ZZ9.99")), 421, Gx_line+9, 546, Gx_line+24, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+29);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9I0( true, 0) ;
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
         /* 'VENTASTIPOLOCAL' Routine */
         returnInSub = false;
         AV29Mes1 = 0.00m;
         AV12DocMonCod = AV31Moneda;
         /* Using cursor P009I5 */
         pr_default.execute(2, new Object[] {AV43TieCod, AV18FDesde, AV20FHasta});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A24DocNum = P009I5_A24DocNum[0];
            A941DocSts = P009I5_A941DocSts[0];
            A232DocFec = P009I5_A232DocFec[0];
            A178TieCod = P009I5_A178TieCod[0];
            n178TieCod = P009I5_n178TieCod[0];
            A230DocMonCod = P009I5_A230DocMonCod[0];
            A149TipCod = P009I5_A149TipCod[0];
            A511TipSigno = P009I5_A511TipSigno[0];
            A929DocFecRef = P009I5_A929DocFecRef[0];
            A927DocSubExonerado = P009I5_A927DocSubExonerado[0];
            A922DocSubSelectivo = P009I5_A922DocSubSelectivo[0];
            A921DocSubInafecto = P009I5_A921DocSubInafecto[0];
            A920DocSubAfecto = P009I5_A920DocSubAfecto[0];
            A899DocDcto = P009I5_A899DocDcto[0];
            A511TipSigno = P009I5_A511TipSigno[0];
            A927DocSubExonerado = P009I5_A927DocSubExonerado[0];
            A922DocSubSelectivo = P009I5_A922DocSubSelectivo[0];
            A921DocSubInafecto = P009I5_A921DocSubInafecto[0];
            A920DocSubAfecto = P009I5_A920DocSubAfecto[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
            AV30MonCod = A230DocMonCod;
            AV46TipCod = A149TipCod;
            AV19Fecha = A232DocFec;
            AV27Importe = NumberUtil.Round( (A919DocSub-A918DocDscto)*A511TipSigno, 2);
            if ( ( StringUtil.StrCmp(AV46TipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV46TipCod, "ND") == 0 ) )
            {
               AV19Fecha = A929DocFecRef;
            }
            if ( AV12DocMonCod != 1 )
            {
               if ( AV30MonCod == 1 )
               {
                  GXt_decimal1 = AV9Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV30MonCod, ref  AV19Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV9Cambio = GXt_decimal1;
                  AV27Importe = NumberUtil.Round( AV27Importe/ (decimal)(AV9Cambio), 2);
               }
            }
            else
            {
               if ( AV30MonCod != 1 )
               {
                  GXt_decimal1 = AV9Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV30MonCod, ref  AV19Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV9Cambio = GXt_decimal1;
                  AV27Importe = NumberUtil.Round( AV27Importe*AV9Cambio, 2);
               }
            }
            AV29Mes1 = (decimal)(AV29Mes1+AV27Importe);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void H9I0( bool bFoot ,
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
               getPrinter().GxDrawText("Resumen de Venta por Locales", 266, Gx_line+52, 527, Gx_line+72, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha Desde", 197, Gx_line+90, 272, Gx_line+104, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Hasta", 199, Gx_line+111, 272, Gx_line+125, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 224, Gx_line+133, 272, Gx_line+147, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21Filtro1, "")), 281, Gx_line+84, 624, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro2, "")), 281, Gx_line+106, 624, Gx_line+130, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro3, "")), 281, Gx_line+128, 624, Gx_line+152, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV28Logo)) ? AV58Logo_GXI : AV28Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 11, Gx_line+16, 166, Gx_line+92) ;
               getPrinter().GxDrawRect(5, Gx_line+161, 560, Gx_line+184, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Local", 114, Gx_line+167, 145, Gx_line+181, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Codigo", 18, Gx_line+167, 59, Gx_line+181, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 467, Gx_line+167, 517, Gx_line+181, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+184);
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
         add_metrics2( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
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
         AV14Empresa = "";
         AV42Session = context.GetSession();
         AV13EmpDir = "";
         AV15EmpRUC = "";
         AV40Ruta = "";
         AV28Logo = "";
         AV58Logo_GXI = "";
         AV21Filtro1 = "";
         AV22Filtro2 = "";
         AV23Filtro3 = "";
         scmdbuf = "";
         P009I2_A180MonCod = new int[1] ;
         P009I2_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         P009I3_A1898TieDsc = new string[] {""} ;
         P009I3_A178TieCod = new int[1] ;
         P009I3_n178TieCod = new bool[] {false} ;
         P009I3_A941DocSts = new string[] {""} ;
         P009I3_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P009I3_A149TipCod = new string[] {""} ;
         P009I3_A24DocNum = new string[] {""} ;
         A1898TieDsc = "";
         A941DocSts = "";
         A232DocFec = DateTime.MinValue;
         A149TipCod = "";
         A24DocNum = "";
         AV44TieDsc = "";
         P009I5_A24DocNum = new string[] {""} ;
         P009I5_A941DocSts = new string[] {""} ;
         P009I5_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P009I5_A178TieCod = new int[1] ;
         P009I5_n178TieCod = new bool[] {false} ;
         P009I5_A230DocMonCod = new int[1] ;
         P009I5_A149TipCod = new string[] {""} ;
         P009I5_A511TipSigno = new short[1] ;
         P009I5_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P009I5_A927DocSubExonerado = new decimal[1] ;
         P009I5_A922DocSubSelectivo = new decimal[1] ;
         P009I5_A921DocSubInafecto = new decimal[1] ;
         P009I5_A920DocSubAfecto = new decimal[1] ;
         P009I5_A899DocDcto = new decimal[1] ;
         A929DocFecRef = DateTime.MinValue;
         AV46TipCod = "";
         AV19Fecha = DateTime.MinValue;
         GXt_char2 = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV28Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrreportetiendas__default(),
            new Object[][] {
                new Object[] {
               P009I2_A180MonCod, P009I2_A1234MonDsc
               }
               , new Object[] {
               P009I3_A1898TieDsc, P009I3_A178TieCod, P009I3_n178TieCod, P009I3_A941DocSts, P009I3_A232DocFec, P009I3_A149TipCod, P009I3_A24DocNum
               }
               , new Object[] {
               P009I5_A24DocNum, P009I5_A941DocSts, P009I5_A232DocFec, P009I5_A178TieCod, P009I5_n178TieCod, P009I5_A230DocMonCod, P009I5_A149TipCod, P009I5_A511TipSigno, P009I5_A929DocFecRef, P009I5_A927DocSubExonerado,
               P009I5_A922DocSubSelectivo, P009I5_A921DocSubInafecto, P009I5_A920DocSubAfecto, P009I5_A899DocDcto
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
      private short A511TipSigno ;
      private int AV31Moneda ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int A178TieCod ;
      private int AV43TieCod ;
      private int Gx_OldLine ;
      private int AV12DocMonCod ;
      private int A230DocMonCod ;
      private int AV30MonCod ;
      private decimal AV47TMes ;
      private decimal AV29Mes1 ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A899DocDcto ;
      private decimal A919DocSub ;
      private decimal A918DocDscto ;
      private decimal AV27Importe ;
      private decimal AV9Cambio ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV14Empresa ;
      private string AV13EmpDir ;
      private string AV15EmpRUC ;
      private string AV40Ruta ;
      private string AV21Filtro1 ;
      private string AV22Filtro2 ;
      private string AV23Filtro3 ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string A1898TieDsc ;
      private string A941DocSts ;
      private string A149TipCod ;
      private string A24DocNum ;
      private string AV44TieDsc ;
      private string AV46TipCod ;
      private string GXt_char2 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV18FDesde ;
      private DateTime AV20FHasta ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV19Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK9I4 ;
      private bool n178TieCod ;
      private bool returnInSub ;
      private string AV58Logo_GXI ;
      private string AV28Logo ;
      private string Logo ;
      private IGxSession AV42Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FDesde ;
      private DateTime aP1_FHasta ;
      private int aP2_Moneda ;
      private IDataStoreProvider pr_default ;
      private int[] P009I2_A180MonCod ;
      private string[] P009I2_A1234MonDsc ;
      private string[] P009I3_A1898TieDsc ;
      private int[] P009I3_A178TieCod ;
      private bool[] P009I3_n178TieCod ;
      private string[] P009I3_A941DocSts ;
      private DateTime[] P009I3_A232DocFec ;
      private string[] P009I3_A149TipCod ;
      private string[] P009I3_A24DocNum ;
      private string[] P009I5_A24DocNum ;
      private string[] P009I5_A941DocSts ;
      private DateTime[] P009I5_A232DocFec ;
      private int[] P009I5_A178TieCod ;
      private bool[] P009I5_n178TieCod ;
      private int[] P009I5_A230DocMonCod ;
      private string[] P009I5_A149TipCod ;
      private short[] P009I5_A511TipSigno ;
      private DateTime[] P009I5_A929DocFecRef ;
      private decimal[] P009I5_A927DocSubExonerado ;
      private decimal[] P009I5_A922DocSubSelectivo ;
      private decimal[] P009I5_A921DocSubInafecto ;
      private decimal[] P009I5_A920DocSubAfecto ;
      private decimal[] P009I5_A899DocDcto ;
   }

   public class rrreportetiendas__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009I2;
          prmP009I2 = new Object[] {
          new ParDef("@AV31Moneda",GXType.Int32,6,0)
          };
          Object[] prmP009I3;
          prmP009I3 = new Object[] {
          new ParDef("@AV18FDesde",GXType.Date,8,0) ,
          new ParDef("@AV20FHasta",GXType.Date,8,0)
          };
          Object[] prmP009I5;
          prmP009I5 = new Object[] {
          new ParDef("@AV43TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV18FDesde",GXType.Date,8,0) ,
          new ParDef("@AV20FHasta",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009I2", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV31Moneda ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009I2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009I3", "SELECT T2.[TieDsc], T1.[TieCod], T1.[DocSts], T1.[DocFec], T1.[TipCod], T1.[DocNum] FROM ([CLVENTAS] T1 LEFT JOIN [SGTIENDAS] T2 ON T2.[TieCod] = T1.[TieCod]) WHERE (T1.[DocFec] >= @AV18FDesde) AND (T1.[DocFec] <= @AV20FHasta) AND (Not T1.[DocSts] = 'A') ORDER BY T1.[TieCod], T2.[TieDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009I3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009I5", "SELECT T1.[DocNum], T1.[DocSts], T1.[DocFec], T1.[TieCod], T1.[DocMonCod], T1.[TipCod], T2.[TipSigno], T1.[DocFecRef], COALESCE( T3.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T3.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T3.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T3.[DocSubAfecto], 0) AS DocSubAfecto, T1.[DocDcto] FROM (([CLVENTAS] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T3 ON T3.[TipCod] = T1.[TipCod] AND T3.[DocNum] = T1.[DocNum]) WHERE (T1.[TieCod] = @AV43TieCod) AND (T1.[DocFec] >= @AV18FDesde) AND (T1.[DocFec] <= @AV20FHasta) AND (T1.[DocSts] <> 'A') ORDER BY T1.[TieCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009I5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((string[]) buf[6])[0] = rslt.getString(6, 12);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 3);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                return;
       }
    }

 }

}
