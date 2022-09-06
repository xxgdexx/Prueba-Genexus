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
namespace GeneXus.Programs.contabilidad {
   public class r_reportecostocentrocostospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_reportecostocentrocostospdf.aspx")), "contabilidad.r_reportecostocentrocostospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_reportecostocentrocostospdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "Ano");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8Ano = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV34Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
                  AV49CosCod = GetPar( "CosCod");
                  AV36Moneda = (int)(NumberUtil.Val( GetPar( "Moneda"), "."));
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

      public r_reportecostocentrocostospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reportecostocentrocostospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref string aP2_CosCod ,
                           ref int aP3_Moneda )
      {
         this.AV8Ano = aP0_Ano;
         this.AV34Mes = aP1_Mes;
         this.AV49CosCod = aP2_CosCod;
         this.AV36Moneda = aP3_Moneda;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV34Mes;
         aP2_CosCod=this.AV49CosCod;
         aP3_Moneda=this.AV36Moneda;
      }

      public int executeUdp( ref short aP0_Ano ,
                             ref short aP1_Mes ,
                             ref string aP2_CosCod )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_CosCod, ref aP3_Moneda);
         return AV36Moneda ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_CosCod ,
                                 ref int aP3_Moneda )
      {
         r_reportecostocentrocostospdf objr_reportecostocentrocostospdf;
         objr_reportecostocentrocostospdf = new r_reportecostocentrocostospdf();
         objr_reportecostocentrocostospdf.AV8Ano = aP0_Ano;
         objr_reportecostocentrocostospdf.AV34Mes = aP1_Mes;
         objr_reportecostocentrocostospdf.AV49CosCod = aP2_CosCod;
         objr_reportecostocentrocostospdf.AV36Moneda = aP3_Moneda;
         objr_reportecostocentrocostospdf.context.SetSubmitInitialConfig(context);
         objr_reportecostocentrocostospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reportecostocentrocostospdf);
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV34Mes;
         aP2_CosCod=this.AV49CosCod;
         aP3_Moneda=this.AV36Moneda;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reportecostocentrocostospdf)stateInfo).executePrivate();
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
            AV15Empresa = AV43Session.Get("Empresa");
            AV52EmpDir = AV43Session.Get("EmpDir");
            AV53EmpRUC = AV43Session.Get("EmpRUC");
            AV44Ruta = AV43Session.Get("RUTA") + "/Logo.jpg";
            AV33Logo = AV44Ruta;
            AV56Logo_GXI = GXDbFile.PathToUrl( AV44Ruta);
            AV48TotTipo = "RCC";
            AV39Titulo = "Reporte de Costo / Centro de Costos";
            AV40Titulo2 = "";
            /* Using cursor P00BR2 */
            pr_default.execute(0, new Object[] {AV49CosCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A79COSCod = P00BR2_A79COSCod[0];
               A761COSDsc = P00BR2_A761COSDsc[0];
               AV40Titulo2 = StringUtil.Trim( A761COSDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            GXt_char1 = AV11cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV34Mes, out  GXt_char1) ;
            AV11cMes = GXt_char1;
            GXt_decimal2 = AV10Cambio;
            GXt_char1 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV36Moneda, ref  AV16Fecha, ref  GXt_char1, out  GXt_decimal2) ;
            AV10Cambio = GXt_decimal2;
            if ( AV36Moneda == 1 )
            {
               AV10Cambio = (decimal)(1);
            }
            AV37Periodo = StringUtil.Trim( AV11cMes) + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0));
            AV30ImpTot = 0;
            AV28ImpRub = 0;
            AV42TotIng = 0;
            AV41TotEgr = 0;
            /* Using cursor P00BR3 */
            pr_default.execute(1, new Object[] {AV48TotTipo});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A114TotTipo = P00BR3_A114TotTipo[0];
               A115TotRub = P00BR3_A115TotRub[0];
               A1928TotDsc = P00BR3_A1928TotDsc[0];
               A120TotOrd = P00BR3_A120TotOrd[0];
               AV47TotRub = A115TotRub;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1928TotDsc)) )
               {
                  HBR0( false, 29) ;
                  getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1928TotDsc, "")), 16, Gx_line+3, 396, Gx_line+19, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+29);
               }
               /* Using cursor P00BR4 */
               pr_default.execute(2, new Object[] {AV48TotTipo, AV47TotRub});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A115TotRub = P00BR4_A115TotRub[0];
                  A114TotTipo = P00BR4_A114TotTipo[0];
                  A1829RubSts = P00BR4_A1829RubSts[0];
                  A116RubCod = P00BR4_A116RubCod[0];
                  A1822RubDsc = P00BR4_A1822RubDsc[0];
                  A1823RubDscTot = P00BR4_A1823RubDscTot[0];
                  A117RubOrd = P00BR4_A117RubOrd[0];
                  AV45RubCod = A116RubCod;
                  AV28ImpRub = 0;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1822RubDsc)) )
                  {
                     HBR0( false, 22) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1822RubDsc, "")), 34, Gx_line+3, 414, Gx_line+19, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+22);
                  }
                  /* Using cursor P00BR5 */
                  pr_default.execute(3, new Object[] {AV48TotTipo, AV47TotRub, AV45RubCod});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A116RubCod = P00BR5_A116RubCod[0];
                     A115TotRub = P00BR5_A115TotRub[0];
                     A114TotTipo = P00BR5_A114TotTipo[0];
                     A118RubLinCod = P00BR5_A118RubLinCod[0];
                     A1826RubLinDsc = P00BR5_A1826RubLinDsc[0];
                     A119RubLinOrd = P00BR5_A119RubLinOrd[0];
                     AV48TotTipo = A114TotTipo;
                     AV47TotRub = A115TotRub;
                     AV45RubCod = A116RubCod;
                     AV46RubLinCod = A118RubLinCod;
                     GXt_decimal2 = AV25ImpBal;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  AV34Mes,  "ACT",  AV49CosCod, out  GXt_decimal2) ;
                     AV25ImpBal = GXt_decimal2;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1826RubLinDsc)) )
                     {
                        HBR0( false, 17) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1826RubLinDsc, "")), 52, Gx_line+0, 432, Gx_line+16, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV25ImpBal, "ZZZZZZ,ZZZ,ZZ9.99")), 441, Gx_line+0, 548, Gx_line+15, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+17);
                     }
                     AV28ImpRub = (decimal)(AV28ImpRub+AV25ImpBal);
                     pr_default.readNext(3);
                  }
                  pr_default.close(3);
                  AV42TotIng = (decimal)(AV42TotIng+(((AV47TotRub==1) ? AV28ImpRub : (decimal)(0))));
                  AV41TotEgr = (decimal)(AV41TotEgr+(((AV47TotRub==2) ? AV28ImpRub : (decimal)(0))));
                  HBR0( false, 32) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1823RubDscTot, "")), 16, Gx_line+7, 397, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28ImpRub, "ZZZZZZ,ZZZ,ZZ9.99")), 441, Gx_line+5, 548, Gx_line+20, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(440, Gx_line+5, 762, Gx_line+5, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+32);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV42TotIng = ((AV42TotIng<Convert.ToDecimal(0)) ? AV42TotIng*-1 : AV42TotIng);
            AV41TotEgr = ((AV41TotEgr<Convert.ToDecimal(0)) ? AV41TotEgr*-1 : AV41TotEgr);
            AV22Final = (decimal)(AV42TotIng-AV41TotEgr);
            HBR0( false, 42) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV22Final, "ZZZZZZ,ZZZ,ZZ9.99")), 441, Gx_line+8, 548, Gx_line+23, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(442, Gx_line+6, 764, Gx_line+6, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 314, Gx_line+8, 398, Gx_line+23, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+42);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HBR0( true, 0) ;
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

      protected void HBR0( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Titulo, "")), 183, Gx_line+8, 639, Gx_line+33, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Periodo, "")), 183, Gx_line+58, 639, Gx_line+83, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+100, 800, Gx_line+129, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción", 120, Gx_line+108, 189, Gx_line+122, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mes Actual", 481, Gx_line+108, 547, Gx_line+122, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Titulo2, "")), 183, Gx_line+33, 639, Gx_line+58, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Empresa, "")), 6, Gx_line+56, 377, Gx_line+74, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53EmpRUC, "")), 6, Gx_line+74, 377, Gx_line+92, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+129);
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
         AV15Empresa = "";
         AV43Session = context.GetSession();
         AV52EmpDir = "";
         AV53EmpRUC = "";
         AV44Ruta = "";
         AV33Logo = "";
         AV56Logo_GXI = "";
         AV48TotTipo = "";
         AV39Titulo = "";
         AV40Titulo2 = "";
         scmdbuf = "";
         P00BR2_A79COSCod = new string[] {""} ;
         P00BR2_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         AV11cMes = "";
         AV16Fecha = DateTime.MinValue;
         GXt_char1 = "";
         AV37Periodo = "";
         P00BR3_A114TotTipo = new string[] {""} ;
         P00BR3_A115TotRub = new int[1] ;
         P00BR3_A1928TotDsc = new string[] {""} ;
         P00BR3_A120TotOrd = new short[1] ;
         A114TotTipo = "";
         A1928TotDsc = "";
         P00BR4_A115TotRub = new int[1] ;
         P00BR4_A114TotTipo = new string[] {""} ;
         P00BR4_A1829RubSts = new short[1] ;
         P00BR4_A116RubCod = new int[1] ;
         P00BR4_A1822RubDsc = new string[] {""} ;
         P00BR4_A1823RubDscTot = new string[] {""} ;
         P00BR4_A117RubOrd = new short[1] ;
         A1822RubDsc = "";
         A1823RubDscTot = "";
         P00BR5_A116RubCod = new int[1] ;
         P00BR5_A115TotRub = new int[1] ;
         P00BR5_A114TotTipo = new string[] {""} ;
         P00BR5_A118RubLinCod = new int[1] ;
         P00BR5_A1826RubLinDsc = new string[] {""} ;
         P00BR5_A119RubLinOrd = new short[1] ;
         A1826RubLinDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_reportecostocentrocostospdf__default(),
            new Object[][] {
                new Object[] {
               P00BR2_A79COSCod, P00BR2_A761COSDsc
               }
               , new Object[] {
               P00BR3_A114TotTipo, P00BR3_A115TotRub, P00BR3_A1928TotDsc, P00BR3_A120TotOrd
               }
               , new Object[] {
               P00BR4_A115TotRub, P00BR4_A114TotTipo, P00BR4_A1829RubSts, P00BR4_A116RubCod, P00BR4_A1822RubDsc, P00BR4_A1823RubDscTot, P00BR4_A117RubOrd
               }
               , new Object[] {
               P00BR5_A116RubCod, P00BR5_A115TotRub, P00BR5_A114TotTipo, P00BR5_A118RubLinCod, P00BR5_A1826RubLinDsc, P00BR5_A119RubLinOrd
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV8Ano ;
      private short AV34Mes ;
      private short A120TotOrd ;
      private short A1829RubSts ;
      private short A117RubOrd ;
      private short A119RubLinOrd ;
      private int AV36Moneda ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A115TotRub ;
      private int AV47TotRub ;
      private int Gx_OldLine ;
      private int A116RubCod ;
      private int AV45RubCod ;
      private int A118RubLinCod ;
      private int AV46RubLinCod ;
      private decimal AV10Cambio ;
      private decimal AV30ImpTot ;
      private decimal AV28ImpRub ;
      private decimal AV42TotIng ;
      private decimal AV41TotEgr ;
      private decimal AV25ImpBal ;
      private decimal GXt_decimal2 ;
      private decimal AV22Final ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV49CosCod ;
      private string AV15Empresa ;
      private string AV52EmpDir ;
      private string AV53EmpRUC ;
      private string AV44Ruta ;
      private string AV48TotTipo ;
      private string AV39Titulo ;
      private string AV40Titulo2 ;
      private string scmdbuf ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string AV11cMes ;
      private string GXt_char1 ;
      private string AV37Periodo ;
      private string A114TotTipo ;
      private string A1928TotDsc ;
      private string A1822RubDsc ;
      private string A1823RubDscTot ;
      private string A1826RubLinDsc ;
      private DateTime AV16Fecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string AV56Logo_GXI ;
      private string AV33Logo ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_CosCod ;
      private int aP3_Moneda ;
      private IDataStoreProvider pr_default ;
      private string[] P00BR2_A79COSCod ;
      private string[] P00BR2_A761COSDsc ;
      private string[] P00BR3_A114TotTipo ;
      private int[] P00BR3_A115TotRub ;
      private string[] P00BR3_A1928TotDsc ;
      private short[] P00BR3_A120TotOrd ;
      private int[] P00BR4_A115TotRub ;
      private string[] P00BR4_A114TotTipo ;
      private short[] P00BR4_A1829RubSts ;
      private int[] P00BR4_A116RubCod ;
      private string[] P00BR4_A1822RubDsc ;
      private string[] P00BR4_A1823RubDscTot ;
      private short[] P00BR4_A117RubOrd ;
      private int[] P00BR5_A116RubCod ;
      private int[] P00BR5_A115TotRub ;
      private string[] P00BR5_A114TotTipo ;
      private int[] P00BR5_A118RubLinCod ;
      private string[] P00BR5_A1826RubLinDsc ;
      private short[] P00BR5_A119RubLinOrd ;
   }

   public class r_reportecostocentrocostospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BR2;
          prmP00BR2 = new Object[] {
          new ParDef("@AV49CosCod",GXType.NChar,10,0)
          };
          Object[] prmP00BR3;
          prmP00BR3 = new Object[] {
          new ParDef("@AV48TotTipo",GXType.NChar,3,0)
          };
          Object[] prmP00BR4;
          prmP00BR4 = new Object[] {
          new ParDef("@AV48TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV47TotRub",GXType.Int32,6,0)
          };
          Object[] prmP00BR5;
          prmP00BR5 = new Object[] {
          new ParDef("@AV48TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV47TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV45RubCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BR2", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV49CosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BR2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BR3", "SELECT [TotTipo], [TotRub], [TotDsc], [TotOrd] FROM [CBRUBROST] WHERE [TotTipo] = @AV48TotTipo ORDER BY [TotOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BR3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BR4", "SELECT [TotRub], [TotTipo], [RubSts], [RubCod], [RubDsc], [RubDscTot], [RubOrd] FROM [CBRUBROS] WHERE ([TotTipo] = @AV48TotTipo) AND ([TotRub] = @AV47TotRub) ORDER BY [RubOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BR4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BR5", "SELECT [RubCod], [TotRub], [TotTipo], [RubLinCod], [RubLinDsc], [RubLinOrd] FROM [CBRUBROSL] WHERE ([TotTipo] = @AV48TotTipo) AND ([TotRub] = @AV47TotRub) AND ([RubCod] = @AV45RubCod) ORDER BY [RubLinOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BR5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
