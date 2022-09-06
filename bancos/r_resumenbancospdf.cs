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
namespace GeneXus.Programs.bancos {
   public class r_resumenbancospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "bancos.r_resumenbancospdf.aspx")), "bancos.r_resumenbancospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "bancos.r_resumenbancospdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "BanCod2");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV23BanCod2 = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14Fecha = context.localUtil.ParseDateParm( GetPar( "Fecha"));
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

      public r_resumenbancospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenbancospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_BanCod2 ,
                           ref DateTime aP1_Fecha )
      {
         this.AV23BanCod2 = aP0_BanCod2;
         this.AV14Fecha = aP1_Fecha;
         initialize();
         executePrivate();
         aP0_BanCod2=this.AV23BanCod2;
         aP1_Fecha=this.AV14Fecha;
      }

      public DateTime executeUdp( ref int aP0_BanCod2 )
      {
         execute(ref aP0_BanCod2, ref aP1_Fecha);
         return AV14Fecha ;
      }

      public void executeSubmit( ref int aP0_BanCod2 ,
                                 ref DateTime aP1_Fecha )
      {
         r_resumenbancospdf objr_resumenbancospdf;
         objr_resumenbancospdf = new r_resumenbancospdf();
         objr_resumenbancospdf.AV23BanCod2 = aP0_BanCod2;
         objr_resumenbancospdf.AV14Fecha = aP1_Fecha;
         objr_resumenbancospdf.context.SetSubmitInitialConfig(context);
         objr_resumenbancospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenbancospdf);
         aP0_BanCod2=this.AV23BanCod2;
         aP1_Fecha=this.AV14Fecha;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenbancospdf)stateInfo).executePrivate();
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
            AV17Empresa = AV21Session.Get("Empresa");
            AV18EmpDir = AV21Session.Get("EmpDir");
            AV19EmpRUC = AV21Session.Get("EmpRUC");
            AV20Ruta = AV21Session.Get("RUTA") + "/Logo.jpg";
            AV16Logo = AV20Ruta;
            AV26Logo_GXI = GXDbFile.PathToUrl( AV20Ruta);
            AV8MonDsc = "";
            AV9BanDsc = "";
            AV10CTBCo = "";
            AV12SaldoT = 0.00m;
            AV15FechaMas = DateTimeUtil.DAdd(AV14Fecha,+((int)(1)));
            /* Using cursor P009U2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1235MonSts = P009U2_A1235MonSts[0];
               A1234MonDsc = P009U2_A1234MonDsc[0];
               A180MonCod = P009U2_A180MonCod[0];
               AV8MonDsc = A1234MonDsc;
               AV22MonCod = A180MonCod;
               H9U0( false, 27) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8MonDsc, "")), 22, Gx_line+5, 752, Gx_line+23, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+27);
               AV11Saldo = 0.00m;
               AV12SaldoT = 0.00m;
               /* Execute user subroutine: 'DETALLEBANCO' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               H9U0( false, 33) ;
               getPrinter().GxDrawLine(485, Gx_line+3, 660, Gx_line+3, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV12SaldoT, "ZZZZZZ,ZZZ,ZZ9.99")), 503, Gx_line+9, 630, Gx_line+23, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8MonDsc, "")), 188, Gx_line+8, 485, Gx_line+25, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+33);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9U0( true, 0) ;
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
         /* 'DETALLEBANCO' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV23BanCod2 ,
                                              A372BanCod ,
                                              A483BanSts } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P009U3 */
         pr_default.execute(1, new Object[] {AV23BanCod2});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A483BanSts = P009U3_A483BanSts[0];
            A372BanCod = P009U3_A372BanCod[0];
            A482BanDsc = P009U3_A482BanDsc[0];
            AV9BanDsc = A482BanDsc;
            AV13BanCod = A372BanCod;
            AV11Saldo = 0.00m;
            /* Using cursor P009U4 */
            pr_default.execute(2, new Object[] {AV13BanCod, AV22MonCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A504CBSts = P009U4_A504CBSts[0];
               A372BanCod = P009U4_A372BanCod[0];
               A180MonCod = P009U4_A180MonCod[0];
               A377CBCod = P009U4_A377CBCod[0];
               AV10CTBCo = StringUtil.Trim( A377CBCod);
               GXt_decimal1 = AV11Saldo;
               new GeneXus.Programs.bancos.pobtienesaldobancos(context ).execute( ref  AV13BanCod, ref  AV10CTBCo, ref  AV15FechaMas, out  GXt_decimal1) ;
               AV11Saldo = GXt_decimal1;
               AV12SaldoT = (decimal)(AV12SaldoT+AV11Saldo);
               H9U0( false, 24) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9BanDsc, "")), 23, Gx_line+5, 246, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10CTBCo, "")), 269, Gx_line+5, 492, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV11Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 503, Gx_line+5, 630, Gx_line+19, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void H9U0( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Bancos", 298, Gx_line+32, 468, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+116, 797, Gx_line+151, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Banco", 26, Gx_line+125, 62, Gx_line+139, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Cuenta", 301, Gx_line+127, 360, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 545, Gx_line+128, 578, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha:", 680, Gx_line+14, 719, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hora:", 680, Gx_line+31, 712, Gx_line+45, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 680, Gx_line+49, 724, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 730, Gx_line+48, 769, Gx_line+63, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 684, Gx_line+30, 768, Gx_line+45, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 722, Gx_line+13, 769, Gx_line+28, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 319, Gx_line+58, 349, Gx_line+78, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV14Fecha, "99/99/99"), 363, Gx_line+58, 445, Gx_line+79, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV16Logo)) ? AV26Logo_GXI : AV16Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 15, Gx_line+18, 173, Gx_line+96) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+151);
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
         AV17Empresa = "";
         AV21Session = context.GetSession();
         AV18EmpDir = "";
         AV19EmpRUC = "";
         AV20Ruta = "";
         AV16Logo = "";
         AV26Logo_GXI = "";
         AV8MonDsc = "";
         AV9BanDsc = "";
         AV10CTBCo = "";
         AV15FechaMas = DateTime.MinValue;
         scmdbuf = "";
         P009U2_A1235MonSts = new short[1] ;
         P009U2_A1234MonDsc = new string[] {""} ;
         P009U2_A180MonCod = new int[1] ;
         A1234MonDsc = "";
         P009U3_A483BanSts = new short[1] ;
         P009U3_A372BanCod = new int[1] ;
         P009U3_A482BanDsc = new string[] {""} ;
         A482BanDsc = "";
         P009U4_A504CBSts = new short[1] ;
         P009U4_A372BanCod = new int[1] ;
         P009U4_A180MonCod = new int[1] ;
         P009U4_A377CBCod = new string[] {""} ;
         A377CBCod = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV16Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.r_resumenbancospdf__default(),
            new Object[][] {
                new Object[] {
               P009U2_A1235MonSts, P009U2_A1234MonDsc, P009U2_A180MonCod
               }
               , new Object[] {
               P009U3_A483BanSts, P009U3_A372BanCod, P009U3_A482BanDsc
               }
               , new Object[] {
               P009U4_A504CBSts, P009U4_A372BanCod, P009U4_A180MonCod, P009U4_A377CBCod
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
      private short A1235MonSts ;
      private short A483BanSts ;
      private short A504CBSts ;
      private int AV23BanCod2 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int AV22MonCod ;
      private int Gx_OldLine ;
      private int A372BanCod ;
      private int AV13BanCod ;
      private decimal AV12SaldoT ;
      private decimal AV11Saldo ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV17Empresa ;
      private string AV18EmpDir ;
      private string AV19EmpRUC ;
      private string AV20Ruta ;
      private string AV8MonDsc ;
      private string AV9BanDsc ;
      private string AV10CTBCo ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string A482BanDsc ;
      private string A377CBCod ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV14Fecha ;
      private DateTime AV15FechaMas ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private string AV26Logo_GXI ;
      private string AV16Logo ;
      private string Logo ;
      private IGxSession AV21Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_BanCod2 ;
      private DateTime aP1_Fecha ;
      private IDataStoreProvider pr_default ;
      private short[] P009U2_A1235MonSts ;
      private string[] P009U2_A1234MonDsc ;
      private int[] P009U2_A180MonCod ;
      private short[] P009U3_A483BanSts ;
      private int[] P009U3_A372BanCod ;
      private string[] P009U3_A482BanDsc ;
      private short[] P009U4_A504CBSts ;
      private int[] P009U4_A372BanCod ;
      private int[] P009U4_A180MonCod ;
      private string[] P009U4_A377CBCod ;
   }

   public class r_resumenbancospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009U3( IGxContext context ,
                                             int AV23BanCod2 ,
                                             int A372BanCod ,
                                             short A483BanSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [BanSts], [BanCod], [BanDsc] FROM [TSBANCOS]";
         AddWhere(sWhereString, "([BanSts] = 1)");
         if ( ! (0==AV23BanCod2) )
         {
            AddWhere(sWhereString, "([BanCod] = @AV23BanCod2)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [BanCod]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P009U3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (short)dynConstraints[2] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009U2;
          prmP009U2 = new Object[] {
          };
          Object[] prmP009U4;
          prmP009U4 = new Object[] {
          new ParDef("@AV13BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV22MonCod",GXType.Int32,6,0)
          };
          Object[] prmP009U3;
          prmP009U3 = new Object[] {
          new ParDef("@AV23BanCod2",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009U2", "SELECT [MonSts], [MonDsc], [MonCod] FROM [CMONEDAS] ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009U2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009U3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009U3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009U4", "SELECT [CBSts], [BanCod], [MonCod], [CBCod] FROM [TSCUENTABANCO] WHERE ([BanCod] = @AV13BanCod) AND ([MonCod] = @AV22MonCod) AND ([CBSts] = 1) ORDER BY [BanCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009U4,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                return;
       }
    }

 }

}
