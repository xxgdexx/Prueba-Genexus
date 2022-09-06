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
   public class r_balancegeneralanualpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_balancegeneralanualpdf.aspx")), "contabilidad.r_balancegeneralanualpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_balancegeneralanualpdf.aspx")))) ;
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
               AV11Ano = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV38Tipo = GetPar( "Tipo");
                  AV48Moneda = (int)(NumberUtil.Val( GetPar( "Moneda"), "."));
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

      public r_balancegeneralanualpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_balancegeneralanualpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref string aP1_Tipo ,
                           ref int aP2_Moneda )
      {
         this.AV11Ano = aP0_Ano;
         this.AV38Tipo = aP1_Tipo;
         this.AV48Moneda = aP2_Moneda;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Tipo=this.AV38Tipo;
         aP2_Moneda=this.AV48Moneda;
      }

      public int executeUdp( ref short aP0_Ano ,
                             ref string aP1_Tipo )
      {
         execute(ref aP0_Ano, ref aP1_Tipo, ref aP2_Moneda);
         return AV48Moneda ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref string aP1_Tipo ,
                                 ref int aP2_Moneda )
      {
         r_balancegeneralanualpdf objr_balancegeneralanualpdf;
         objr_balancegeneralanualpdf = new r_balancegeneralanualpdf();
         objr_balancegeneralanualpdf.AV11Ano = aP0_Ano;
         objr_balancegeneralanualpdf.AV38Tipo = aP1_Tipo;
         objr_balancegeneralanualpdf.AV48Moneda = aP2_Moneda;
         objr_balancegeneralanualpdf.context.SetSubmitInitialConfig(context);
         objr_balancegeneralanualpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_balancegeneralanualpdf);
         aP0_Ano=this.AV11Ano;
         aP1_Tipo=this.AV38Tipo;
         aP2_Moneda=this.AV48Moneda;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_balancegeneralanualpdf)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 2, 9, 11909, 16834, 0, 1, 1, 0, 1, 1) )
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
            AV33Empresa = AV34Session.Get("Empresa");
            AV32EmpDir = AV34Session.Get("EmpDir");
            AV35EmpRUC = AV34Session.Get("EmpRUC");
            AV36Ruta = AV34Session.Get("RUTA") + "/Logo.jpg";
            AV37Logo = AV36Ruta;
            AV92Logo_GXI = GXDbFile.PathToUrl( AV36Ruta);
            AV8TotTipo = "BAL";
            AV13Titulo = "Balance General - Anual";
            AV50Titulo2 = "";
            AV14Periodo = "Año : " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            /* Using cursor P00D42 */
            pr_default.execute(0, new Object[] {AV48Moneda});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P00D42_A180MonCod[0];
               A1234MonDsc = P00D42_A1234MonDsc[0];
               AV50Titulo2 = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            GXt_decimal1 = AV49Cambio;
            GXt_char2 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV48Moneda, ref  AV15Fecha, ref  GXt_char2, out  GXt_decimal1) ;
            AV49Cambio = GXt_decimal1;
            if ( AV48Moneda == 1 )
            {
               AV49Cambio = (decimal)(1);
            }
            AV51nAper = 0.00m;
            AV52nEnero = 0.00m;
            AV53nFebrero = 0.00m;
            AV54nMarzo = 0.00m;
            AV55nAbril = 0.00m;
            AV56nMayo = 0.00m;
            AV57nJunio = 0.00m;
            AV58nJulio = 0.00m;
            AV59nAgosto = 0.00m;
            AV60nSep = 0.00m;
            AV61nOct = 0.00m;
            AV62nNov = 0.00m;
            AV63nDic = 0.00m;
            /* Using cursor P00D43 */
            pr_default.execute(1, new Object[] {AV8TotTipo});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A114TotTipo = P00D43_A114TotTipo[0];
               A115TotRub = P00D43_A115TotRub[0];
               A1928TotDsc = P00D43_A1928TotDsc[0];
               A1929TotDscTot = P00D43_A1929TotDscTot[0];
               A120TotOrd = P00D43_A120TotOrd[0];
               AV9TotRub = A115TotRub;
               AV77TTAper = 0.00m;
               AV78TTEnero = 0.00m;
               AV79TTFebrero = 0.00m;
               AV80TTMarzo = 0.00m;
               AV81TTAbril = 0.00m;
               AV82TTMayo = 0.00m;
               AV83TTJunio = 0.00m;
               AV84TTJulio = 0.00m;
               AV85TTAgosto = 0.00m;
               AV86TTSep = 0.00m;
               AV87TTOct = 0.00m;
               AV88TTNov = 0.00m;
               AV89TTDic = 0.00m;
               HD40( false, 16) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1928TotDsc, "")), 1, Gx_line+0, 308, Gx_line+16, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+16);
               /* Using cursor P00D44 */
               pr_default.execute(2, new Object[] {AV8TotTipo, AV9TotRub});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A115TotRub = P00D44_A115TotRub[0];
                  A114TotTipo = P00D44_A114TotTipo[0];
                  A1829RubSts = P00D44_A1829RubSts[0];
                  A116RubCod = P00D44_A116RubCod[0];
                  A1822RubDsc = P00D44_A1822RubDsc[0];
                  A1823RubDscTot = P00D44_A1823RubDscTot[0];
                  A117RubOrd = P00D44_A117RubOrd[0];
                  AV10RubCod = A116RubCod;
                  AV64nTAper = 0.00m;
                  AV65nTEnero = 0.00m;
                  AV66nTFebrero = 0.00m;
                  AV67nTMarzo = 0.00m;
                  AV68nTAbril = 0.00m;
                  AV69nTMayo = 0.00m;
                  AV70nTJunio = 0.00m;
                  AV71nTJulio = 0.00m;
                  AV72nTAgosto = 0.00m;
                  AV73nTSep = 0.00m;
                  AV74nTOct = 0.00m;
                  AV75nTNov = 0.00m;
                  AV76nTDic = 0.00m;
                  HD40( false, 16) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1822RubDsc, "")), 0, Gx_line+0, 308, Gx_line+16, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+16);
                  /* Using cursor P00D45 */
                  pr_default.execute(3, new Object[] {AV8TotTipo, AV9TotRub, AV10RubCod});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A116RubCod = P00D45_A116RubCod[0];
                     A115TotRub = P00D45_A115TotRub[0];
                     A114TotTipo = P00D45_A114TotTipo[0];
                     A118RubLinCod = P00D45_A118RubLinCod[0];
                     A1826RubLinDsc = P00D45_A1826RubLinDsc[0];
                     A119RubLinOrd = P00D45_A119RubLinOrd[0];
                     AV8TotTipo = A114TotTipo;
                     AV9TotRub = A115TotRub;
                     AV10RubCod = A116RubCod;
                     AV42RubLinCod = A118RubLinCod;
                     GXt_decimal1 = AV51nAper;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  0,  "ACT",  "", out  GXt_decimal1) ;
                     AV51nAper = GXt_decimal1;
                     GXt_decimal1 = AV52nEnero;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  1,  "ACT",  "", out  GXt_decimal1) ;
                     AV52nEnero = GXt_decimal1;
                     GXt_decimal1 = AV53nFebrero;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  2,  "ACT",  "", out  GXt_decimal1) ;
                     AV53nFebrero = GXt_decimal1;
                     GXt_decimal1 = AV54nMarzo;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  3,  "ACT",  "", out  GXt_decimal1) ;
                     AV54nMarzo = GXt_decimal1;
                     GXt_decimal1 = AV55nAbril;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  4,  "ACT",  "", out  GXt_decimal1) ;
                     AV55nAbril = GXt_decimal1;
                     GXt_decimal1 = AV56nMayo;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  5,  "ACT",  "", out  GXt_decimal1) ;
                     AV56nMayo = GXt_decimal1;
                     GXt_decimal1 = AV57nJunio;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  6,  "ACT",  "", out  GXt_decimal1) ;
                     AV57nJunio = GXt_decimal1;
                     GXt_decimal1 = AV58nJulio;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  7,  "ACT",  "", out  GXt_decimal1) ;
                     AV58nJulio = GXt_decimal1;
                     GXt_decimal1 = AV59nAgosto;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  8,  "ACT",  "", out  GXt_decimal1) ;
                     AV59nAgosto = GXt_decimal1;
                     GXt_decimal1 = AV60nSep;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  9,  "ACT",  "", out  GXt_decimal1) ;
                     AV60nSep = GXt_decimal1;
                     GXt_decimal1 = AV61nOct;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  10,  "ACT",  "", out  GXt_decimal1) ;
                     AV61nOct = GXt_decimal1;
                     GXt_decimal1 = AV62nNov;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  11,  "ACT",  "", out  GXt_decimal1) ;
                     AV62nNov = GXt_decimal1;
                     GXt_decimal1 = AV63nDic;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  12,  "ACT",  "", out  GXt_decimal1) ;
                     AV63nDic = GXt_decimal1;
                     AV51nAper = NumberUtil.Round( AV51nAper/ (decimal)(AV49Cambio), 2);
                     AV52nEnero = NumberUtil.Round( AV52nEnero/ (decimal)(AV49Cambio), 2);
                     AV53nFebrero = NumberUtil.Round( AV53nFebrero/ (decimal)(AV49Cambio), 2);
                     AV54nMarzo = NumberUtil.Round( AV54nMarzo/ (decimal)(AV49Cambio), 2);
                     AV55nAbril = NumberUtil.Round( AV55nAbril/ (decimal)(AV49Cambio), 2);
                     AV56nMayo = NumberUtil.Round( AV56nMayo/ (decimal)(AV49Cambio), 2);
                     AV57nJunio = NumberUtil.Round( AV57nJunio/ (decimal)(AV49Cambio), 2);
                     AV58nJulio = NumberUtil.Round( AV58nJulio/ (decimal)(AV49Cambio), 2);
                     AV59nAgosto = NumberUtil.Round( AV59nAgosto/ (decimal)(AV49Cambio), 2);
                     AV60nSep = NumberUtil.Round( AV60nSep/ (decimal)(AV49Cambio), 2);
                     AV61nOct = NumberUtil.Round( AV61nOct/ (decimal)(AV49Cambio), 2);
                     AV62nNov = NumberUtil.Round( AV62nNov/ (decimal)(AV49Cambio), 2);
                     AV63nDic = NumberUtil.Round( AV63nDic/ (decimal)(AV49Cambio), 2);
                     HD40( false, 16) ;
                     getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1826RubLinDsc, "")), 13, Gx_line+0, 312, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51nAper, "ZZZZZZ,ZZZ,ZZ9.99")), 292, Gx_line+2, 364, Gx_line+11, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52nEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 359, Gx_line+2, 431, Gx_line+11, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57nJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 686, Gx_line+2, 758, Gx_line+11, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59nAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+2, 887, Gx_line+11, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53nFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 423, Gx_line+2, 495, Gx_line+11, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54nMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+2, 562, Gx_line+11, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55nAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 558, Gx_line+2, 630, Gx_line+11, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56nMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 618, Gx_line+2, 690, Gx_line+11, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58nJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 750, Gx_line+2, 822, Gx_line+11, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60nSep, "ZZZZZZ,ZZZ,ZZ9.99")), 879, Gx_line+2, 951, Gx_line+11, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61nOct, "ZZZZZZ,ZZZ,ZZ9.99")), 947, Gx_line+2, 1019, Gx_line+11, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62nNov, "ZZZZZZ,ZZZ,ZZ9.99")), 1010, Gx_line+2, 1082, Gx_line+11, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63nDic, "ZZZZZZ,ZZZ,ZZ9.99")), 1072, Gx_line+2, 1144, Gx_line+11, 2+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+16);
                     if ( StringUtil.StrCmp(AV38Tipo, "C") == 0 )
                     {
                        /* Execute user subroutine: 'DETALLECUENTAS' */
                        S111 ();
                        if ( returnInSub )
                        {
                           pr_default.close(3);
                           this.cleanup();
                           if (true) return;
                        }
                     }
                     AV64nTAper = (decimal)(AV64nTAper+AV51nAper);
                     AV65nTEnero = (decimal)(AV65nTEnero+AV52nEnero);
                     AV66nTFebrero = (decimal)(AV66nTFebrero+AV53nFebrero);
                     AV67nTMarzo = (decimal)(AV67nTMarzo+AV54nMarzo);
                     AV68nTAbril = (decimal)(AV68nTAbril+AV55nAbril);
                     AV69nTMayo = (decimal)(AV69nTMayo+AV56nMayo);
                     AV70nTJunio = (decimal)(AV70nTJunio+AV57nJunio);
                     AV71nTJulio = (decimal)(AV71nTJulio+AV58nJulio);
                     AV72nTAgosto = (decimal)(AV72nTAgosto+AV59nAgosto);
                     AV73nTSep = (decimal)(AV73nTSep+AV60nSep);
                     AV74nTOct = (decimal)(AV74nTOct+AV61nOct);
                     AV75nTNov = (decimal)(AV75nTNov+AV62nNov);
                     AV76nTDic = (decimal)(AV76nTDic+AV63nDic);
                     pr_default.readNext(3);
                  }
                  pr_default.close(3);
                  HD40( false, 17) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1823RubDscTot, "")), 9, Gx_line+1, 281, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64nTAper, "ZZZZZZ,ZZZ,ZZ9.99")), 292, Gx_line+4, 364, Gx_line+13, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65nTEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 359, Gx_line+4, 431, Gx_line+13, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70nTJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 686, Gx_line+4, 758, Gx_line+13, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72nTAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+4, 887, Gx_line+13, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66nTFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 423, Gx_line+4, 495, Gx_line+13, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67nTMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+4, 562, Gx_line+13, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68nTAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 558, Gx_line+4, 630, Gx_line+13, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69nTMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 618, Gx_line+4, 690, Gx_line+13, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71nTJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 750, Gx_line+4, 822, Gx_line+13, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73nTSep, "ZZZZZZ,ZZZ,ZZ9.99")), 879, Gx_line+4, 951, Gx_line+13, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74nTOct, "ZZZZZZ,ZZZ,ZZ9.99")), 947, Gx_line+4, 1019, Gx_line+13, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75nTNov, "ZZZZZZ,ZZZ,ZZ9.99")), 1010, Gx_line+4, 1082, Gx_line+13, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV76nTDic, "ZZZZZZ,ZZZ,ZZ9.99")), 1072, Gx_line+4, 1144, Gx_line+13, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(294, Gx_line+1, 1146, Gx_line+1, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
                  AV77TTAper = (decimal)(AV77TTAper+AV64nTAper);
                  AV78TTEnero = (decimal)(AV78TTEnero+AV65nTEnero);
                  AV79TTFebrero = (decimal)(AV79TTFebrero+AV66nTFebrero);
                  AV80TTMarzo = (decimal)(AV80TTMarzo+AV67nTMarzo);
                  AV81TTAbril = (decimal)(AV81TTAbril+AV68nTAbril);
                  AV82TTMayo = (decimal)(AV82TTMayo+AV69nTMayo);
                  AV83TTJunio = (decimal)(AV83TTJunio+AV70nTJunio);
                  AV84TTJulio = (decimal)(AV84TTJulio+AV71nTJulio);
                  AV85TTAgosto = (decimal)(AV85TTAgosto+AV72nTAgosto);
                  AV86TTSep = (decimal)(AV86TTSep+AV73nTSep);
                  AV87TTOct = (decimal)(AV87TTOct+AV74nTOct);
                  AV88TTNov = (decimal)(AV88TTNov+AV75nTNov);
                  AV89TTDic = (decimal)(AV89TTDic+AV76nTDic);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               HD40( false, 27) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1929TotDscTot, "")), 8, Gx_line+7, 281, Gx_line+23, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV78TTEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 359, Gx_line+9, 431, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV83TTJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 686, Gx_line+9, 758, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85TTAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+9, 887, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV79TTFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 423, Gx_line+9, 495, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV80TTMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+9, 562, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV81TTAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 558, Gx_line+9, 630, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV82TTMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 618, Gx_line+9, 690, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV84TTJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 750, Gx_line+9, 822, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV86TTSep, "ZZZZZZ,ZZZ,ZZ9.99")), 879, Gx_line+9, 951, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87TTOct, "ZZZZZZ,ZZZ,ZZ9.99")), 947, Gx_line+9, 1019, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88TTNov, "ZZZZZZ,ZZZ,ZZ9.99")), 1010, Gx_line+9, 1082, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(293, Gx_line+3, 1145, Gx_line+3, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89TTDic, "ZZZZZZ,ZZZ,ZZ9.99")), 1072, Gx_line+9, 1144, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV77TTAper, "ZZZZZZ,ZZZ,ZZ9.99")), 292, Gx_line+9, 364, Gx_line+18, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+27);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HD40( true, 0) ;
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
         /* 'DETALLECUENTAS' Routine */
         returnInSub = false;
         /* Using cursor P00D46 */
         pr_default.execute(4, new Object[] {AV8TotTipo, AV9TotRub, AV10RubCod, AV42RubLinCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A118RubLinCod = P00D46_A118RubLinCod[0];
            A116RubCod = P00D46_A116RubCod[0];
            A115TotRub = P00D46_A115TotRub[0];
            A114TotTipo = P00D46_A114TotTipo[0];
            A860CueDsc = P00D46_A860CueDsc[0];
            A91CueCod = P00D46_A91CueCod[0];
            A860CueDsc = P00D46_A860CueDsc[0];
            AV43Len = StringUtil.Len( A91CueCod);
            AV40Cuenta = A91CueCod;
            AV39CueDsc = A860CueDsc;
            AV41Saldo = 0.00m;
            /* Execute user subroutine: 'OBTIENESALDO' */
            S127 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            HD40( false, 20) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39CueDsc, "")), 79, Gx_line+3, 308, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Cuenta, "")), 14, Gx_line+3, 78, Gx_line+16, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S127( )
      {
         /* 'OBTIENESALDO' Routine */
         returnInSub = false;
         AV44ImpMov = 0.00m;
         /* Using cursor P00D47 */
         pr_default.execute(5, new Object[] {AV43Len, AV40Cuenta});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A91CueCod = P00D47_A91CueCod[0];
            AV45CueCod = A91CueCod;
            GXt_char2 = "";
            GXt_char3 = "";
            new GeneXus.Programs.contabilidad.poptienesaldocuentamesactual(context ).execute( ref  AV11Ano, ref  AV12Mes, ref  AV45CueCod, ref  GXt_char2, ref  GXt_char3, out  AV46Debe, out  AV47Haber) ;
            AV44ImpMov = (decimal)(AV46Debe-AV47Haber);
            if ( StringUtil.StrCmp(AV8TotTipo, "BAL") == 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Substring( AV45CueCod, 1, 1), "4") >= 0 )
               {
                  AV44ImpMov = (decimal)(AV44ImpMov*-1);
               }
            }
            AV41Saldo = (decimal)(AV41Saldo+AV44ImpMov);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void HD40( bool bFoot ,
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 352, Gx_line+14, 808, Gx_line+39, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Titulo2, "")), 352, Gx_line+39, 808, Gx_line+64, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+117, 1148, Gx_line+146, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción", 105, Gx_line+124, 165, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Empresa, "")), 14, Gx_line+64, 384, Gx_line+82, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35EmpRUC, "")), 14, Gx_line+81, 385, Gx_line+99, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 352, Gx_line+64, 808, Gx_line+89, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Apertura", 316, Gx_line+124, 365, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(306, Gx_line+117, 306, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Enero", 390, Gx_line+124, 421, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(371, Gx_line+118, 371, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(436, Gx_line+117, 436, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Febrero", 450, Gx_line+124, 493, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(501, Gx_line+118, 501, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Marzo", 517, Gx_line+124, 550, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(566, Gx_line+118, 566, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Abril", 585, Gx_line+124, 612, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(631, Gx_line+118, 631, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Junio", 715, Gx_line+124, 743, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(696, Gx_line+118, 696, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Mayo", 653, Gx_line+124, 682, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(761, Gx_line+118, 761, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Julio", 781, Gx_line+124, 806, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(826, Gx_line+118, 826, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Agosto", 838, Gx_line+124, 875, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(891, Gx_line+118, 891, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Sept.", 911, Gx_line+124, 938, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(956, Gx_line+118, 956, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Oct.", 977, Gx_line+124, 999, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1021, Gx_line+118, 1021, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Nov.", 1042, Gx_line+124, 1066, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1086, Gx_line+118, 1086, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Dic.", 1108, Gx_line+124, 1128, Gx_line+137, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+146);
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
         AV33Empresa = "";
         AV34Session = context.GetSession();
         AV32EmpDir = "";
         AV35EmpRUC = "";
         AV36Ruta = "";
         AV37Logo = "";
         AV92Logo_GXI = "";
         AV8TotTipo = "";
         AV13Titulo = "";
         AV50Titulo2 = "";
         AV14Periodo = "";
         scmdbuf = "";
         P00D42_A180MonCod = new int[1] ;
         P00D42_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV15Fecha = DateTime.MinValue;
         P00D43_A114TotTipo = new string[] {""} ;
         P00D43_A115TotRub = new int[1] ;
         P00D43_A1928TotDsc = new string[] {""} ;
         P00D43_A1929TotDscTot = new string[] {""} ;
         P00D43_A120TotOrd = new short[1] ;
         A114TotTipo = "";
         A1928TotDsc = "";
         A1929TotDscTot = "";
         P00D44_A115TotRub = new int[1] ;
         P00D44_A114TotTipo = new string[] {""} ;
         P00D44_A1829RubSts = new short[1] ;
         P00D44_A116RubCod = new int[1] ;
         P00D44_A1822RubDsc = new string[] {""} ;
         P00D44_A1823RubDscTot = new string[] {""} ;
         P00D44_A117RubOrd = new short[1] ;
         A1822RubDsc = "";
         A1823RubDscTot = "";
         P00D45_A116RubCod = new int[1] ;
         P00D45_A115TotRub = new int[1] ;
         P00D45_A114TotTipo = new string[] {""} ;
         P00D45_A118RubLinCod = new int[1] ;
         P00D45_A1826RubLinDsc = new string[] {""} ;
         P00D45_A119RubLinOrd = new short[1] ;
         A1826RubLinDsc = "";
         P00D46_A118RubLinCod = new int[1] ;
         P00D46_A116RubCod = new int[1] ;
         P00D46_A115TotRub = new int[1] ;
         P00D46_A114TotTipo = new string[] {""} ;
         P00D46_A860CueDsc = new string[] {""} ;
         P00D46_A91CueCod = new string[] {""} ;
         A860CueDsc = "";
         A91CueCod = "";
         AV40Cuenta = "";
         AV39CueDsc = "";
         P00D47_A91CueCod = new string[] {""} ;
         AV45CueCod = "";
         GXt_char2 = "";
         GXt_char3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_balancegeneralanualpdf__default(),
            new Object[][] {
                new Object[] {
               P00D42_A180MonCod, P00D42_A1234MonDsc
               }
               , new Object[] {
               P00D43_A114TotTipo, P00D43_A115TotRub, P00D43_A1928TotDsc, P00D43_A1929TotDscTot, P00D43_A120TotOrd
               }
               , new Object[] {
               P00D44_A115TotRub, P00D44_A114TotTipo, P00D44_A1829RubSts, P00D44_A116RubCod, P00D44_A1822RubDsc, P00D44_A1823RubDscTot, P00D44_A117RubOrd
               }
               , new Object[] {
               P00D45_A116RubCod, P00D45_A115TotRub, P00D45_A114TotTipo, P00D45_A118RubLinCod, P00D45_A1826RubLinDsc, P00D45_A119RubLinOrd
               }
               , new Object[] {
               P00D46_A118RubLinCod, P00D46_A116RubCod, P00D46_A115TotRub, P00D46_A114TotTipo, P00D46_A860CueDsc, P00D46_A91CueCod
               }
               , new Object[] {
               P00D47_A91CueCod
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV11Ano ;
      private short A120TotOrd ;
      private short A1829RubSts ;
      private short A117RubOrd ;
      private short A119RubLinOrd ;
      private short AV12Mes ;
      private int AV48Moneda ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int A115TotRub ;
      private int AV9TotRub ;
      private int Gx_OldLine ;
      private int A116RubCod ;
      private int AV10RubCod ;
      private int A118RubLinCod ;
      private int AV42RubLinCod ;
      private int AV43Len ;
      private decimal AV49Cambio ;
      private decimal AV51nAper ;
      private decimal AV52nEnero ;
      private decimal AV53nFebrero ;
      private decimal AV54nMarzo ;
      private decimal AV55nAbril ;
      private decimal AV56nMayo ;
      private decimal AV57nJunio ;
      private decimal AV58nJulio ;
      private decimal AV59nAgosto ;
      private decimal AV60nSep ;
      private decimal AV61nOct ;
      private decimal AV62nNov ;
      private decimal AV63nDic ;
      private decimal AV77TTAper ;
      private decimal AV78TTEnero ;
      private decimal AV79TTFebrero ;
      private decimal AV80TTMarzo ;
      private decimal AV81TTAbril ;
      private decimal AV82TTMayo ;
      private decimal AV83TTJunio ;
      private decimal AV84TTJulio ;
      private decimal AV85TTAgosto ;
      private decimal AV86TTSep ;
      private decimal AV87TTOct ;
      private decimal AV88TTNov ;
      private decimal AV89TTDic ;
      private decimal AV64nTAper ;
      private decimal AV65nTEnero ;
      private decimal AV66nTFebrero ;
      private decimal AV67nTMarzo ;
      private decimal AV68nTAbril ;
      private decimal AV69nTMayo ;
      private decimal AV70nTJunio ;
      private decimal AV71nTJulio ;
      private decimal AV72nTAgosto ;
      private decimal AV73nTSep ;
      private decimal AV74nTOct ;
      private decimal AV75nTNov ;
      private decimal AV76nTDic ;
      private decimal GXt_decimal1 ;
      private decimal AV41Saldo ;
      private decimal AV44ImpMov ;
      private decimal AV46Debe ;
      private decimal AV47Haber ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV38Tipo ;
      private string AV33Empresa ;
      private string AV32EmpDir ;
      private string AV35EmpRUC ;
      private string AV36Ruta ;
      private string AV8TotTipo ;
      private string AV13Titulo ;
      private string AV50Titulo2 ;
      private string AV14Periodo ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string A114TotTipo ;
      private string A1928TotDsc ;
      private string A1929TotDscTot ;
      private string A1822RubDsc ;
      private string A1823RubDscTot ;
      private string A1826RubLinDsc ;
      private string A860CueDsc ;
      private string A91CueCod ;
      private string AV40Cuenta ;
      private string AV39CueDsc ;
      private string AV45CueCod ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private DateTime AV15Fecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private string AV92Logo_GXI ;
      private string AV37Logo ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private string aP1_Tipo ;
      private int aP2_Moneda ;
      private IDataStoreProvider pr_default ;
      private int[] P00D42_A180MonCod ;
      private string[] P00D42_A1234MonDsc ;
      private string[] P00D43_A114TotTipo ;
      private int[] P00D43_A115TotRub ;
      private string[] P00D43_A1928TotDsc ;
      private string[] P00D43_A1929TotDscTot ;
      private short[] P00D43_A120TotOrd ;
      private int[] P00D44_A115TotRub ;
      private string[] P00D44_A114TotTipo ;
      private short[] P00D44_A1829RubSts ;
      private int[] P00D44_A116RubCod ;
      private string[] P00D44_A1822RubDsc ;
      private string[] P00D44_A1823RubDscTot ;
      private short[] P00D44_A117RubOrd ;
      private int[] P00D45_A116RubCod ;
      private int[] P00D45_A115TotRub ;
      private string[] P00D45_A114TotTipo ;
      private int[] P00D45_A118RubLinCod ;
      private string[] P00D45_A1826RubLinDsc ;
      private short[] P00D45_A119RubLinOrd ;
      private int[] P00D46_A118RubLinCod ;
      private int[] P00D46_A116RubCod ;
      private int[] P00D46_A115TotRub ;
      private string[] P00D46_A114TotTipo ;
      private string[] P00D46_A860CueDsc ;
      private string[] P00D46_A91CueCod ;
      private string[] P00D47_A91CueCod ;
   }

   public class r_balancegeneralanualpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00D42;
          prmP00D42 = new Object[] {
          new ParDef("@AV48Moneda",GXType.Int32,6,0)
          };
          Object[] prmP00D43;
          prmP00D43 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0)
          };
          Object[] prmP00D44;
          prmP00D44 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0)
          };
          Object[] prmP00D45;
          prmP00D45 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV10RubCod",GXType.Int32,6,0)
          };
          Object[] prmP00D46;
          prmP00D46 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV10RubCod",GXType.Int32,6,0) ,
          new ParDef("@AV42RubLinCod",GXType.Int32,6,0)
          };
          Object[] prmP00D47;
          prmP00D47 = new Object[] {
          new ParDef("@AV43Len",GXType.Int32,5,0) ,
          new ParDef("@AV40Cuenta",GXType.Char,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D42", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV48Moneda ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D42,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00D43", "SELECT [TotTipo], [TotRub], [TotDsc], [TotDscTot], [TotOrd] FROM [CBRUBROST] WHERE [TotTipo] = @AV8TotTipo ORDER BY [TotOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D43,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D44", "SELECT [TotRub], [TotTipo], [RubSts], [RubCod], [RubDsc], [RubDscTot], [RubOrd] FROM [CBRUBROS] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) ORDER BY [RubOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D44,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D45", "SELECT [RubCod], [TotRub], [TotTipo], [RubLinCod], [RubLinDsc], [RubLinOrd] FROM [CBRUBROSL] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) AND ([RubCod] = @AV10RubCod) ORDER BY [RubLinOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D45,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D46", "SELECT T1.[RubLinCod], T1.[RubCod], T1.[TotRub], T1.[TotTipo], T2.[CueDsc], T1.[CueCod] FROM ([CBRUBROSLD] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE T1.[TotTipo] = @AV8TotTipo and T1.[TotRub] = @AV9TotRub and T1.[RubCod] = @AV10RubCod and T1.[RubLinCod] = @AV42RubLinCod ORDER BY T1.[TotTipo], T1.[TotRub], T1.[RubCod], T1.[RubLinCod], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D46,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D47", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE SUBSTRING([CueCod], 1, @AV43Len) = @AV40Cuenta ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D47,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((short[]) buf[4])[0] = rslt.getShort(5);
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
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                return;
       }
    }

 }

}
