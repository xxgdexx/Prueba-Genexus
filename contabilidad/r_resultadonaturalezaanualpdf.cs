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
   public class r_resultadonaturalezaanualpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_resultadonaturalezaanualpdf.aspx")), "contabilidad.r_resultadonaturalezaanualpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_resultadonaturalezaanualpdf.aspx")))) ;
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
                  AV72Tipo = GetPar( "Tipo");
                  AV39Moneda = (int)(NumberUtil.Val( GetPar( "Moneda"), "."));
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

      public r_resultadonaturalezaanualpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resultadonaturalezaanualpdf( IGxContext context )
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
         this.AV8Ano = aP0_Ano;
         this.AV72Tipo = aP1_Tipo;
         this.AV39Moneda = aP2_Moneda;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Tipo=this.AV72Tipo;
         aP2_Moneda=this.AV39Moneda;
      }

      public int executeUdp( ref short aP0_Ano ,
                             ref string aP1_Tipo )
      {
         execute(ref aP0_Ano, ref aP1_Tipo, ref aP2_Moneda);
         return AV39Moneda ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref string aP1_Tipo ,
                                 ref int aP2_Moneda )
      {
         r_resultadonaturalezaanualpdf objr_resultadonaturalezaanualpdf;
         objr_resultadonaturalezaanualpdf = new r_resultadonaturalezaanualpdf();
         objr_resultadonaturalezaanualpdf.AV8Ano = aP0_Ano;
         objr_resultadonaturalezaanualpdf.AV72Tipo = aP1_Tipo;
         objr_resultadonaturalezaanualpdf.AV39Moneda = aP2_Moneda;
         objr_resultadonaturalezaanualpdf.context.SetSubmitInitialConfig(context);
         objr_resultadonaturalezaanualpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resultadonaturalezaanualpdf);
         aP0_Ano=this.AV8Ano;
         aP1_Tipo=this.AV72Tipo;
         aP2_Moneda=this.AV39Moneda;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resultadonaturalezaanualpdf)stateInfo).executePrivate();
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
            AV18Empresa = AV71Session.Get("Empresa");
            AV17EmpDir = AV71Session.Get("EmpDir");
            AV19EmpRUC = AV71Session.Get("EmpRUC");
            AV69Ruta = AV71Session.Get("RUTA") + "/Logo.jpg";
            AV36Logo = AV69Ruta;
            AV94Logo_GXI = GXDbFile.PathToUrl( AV69Ruta);
            AV76TotTipo = "NAT";
            AV73Titulo = "Estado de Ganancias y Pérdidas por Naturaleza - Anual";
            AV74Titulo2 = "";
            AV66Periodo = "Año : " + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0));
            /* Using cursor P00D82 */
            pr_default.execute(0, new Object[] {AV39Moneda});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P00D82_A180MonCod[0];
               A1234MonDsc = P00D82_A1234MonDsc[0];
               AV74Titulo2 = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            GXt_decimal1 = AV10Cambio;
            GXt_char2 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV39Moneda, ref  AV21Fecha, ref  GXt_char2, out  GXt_decimal1) ;
            AV10Cambio = GXt_decimal1;
            if ( AV39Moneda == 1 )
            {
               AV10Cambio = (decimal)(1);
            }
            AV44nEnero = 0.00m;
            AV45nFebrero = 0.00m;
            AV48nMarzo = 0.00m;
            AV40nAbril = 0.00m;
            AV49nMayo = 0.00m;
            AV47nJunio = 0.00m;
            AV46nJulio = 0.00m;
            AV41nAgosto = 0.00m;
            AV52nSep = 0.00m;
            AV51nOct = 0.00m;
            AV50nNov = 0.00m;
            AV43nDic = 0.00m;
            AV55nTAper = 0.00m;
            AV57nTEnero = 0.00m;
            AV58nTFebrero = 0.00m;
            AV61nTMarzo = 0.00m;
            AV53nTAbril = 0.00m;
            AV62nTMayo = 0.00m;
            AV60nTJunio = 0.00m;
            AV59nTJulio = 0.00m;
            AV54nTAgosto = 0.00m;
            AV65nTSep = 0.00m;
            AV64nTOct = 0.00m;
            AV63nTNov = 0.00m;
            AV56nTDic = 0.00m;
            /* Using cursor P00D83 */
            pr_default.execute(1, new Object[] {AV76TotTipo});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A114TotTipo = P00D83_A114TotTipo[0];
               A115TotRub = P00D83_A115TotRub[0];
               A1928TotDsc = P00D83_A1928TotDsc[0];
               A1929TotDscTot = P00D83_A1929TotDscTot[0];
               A120TotOrd = P00D83_A120TotOrd[0];
               AV75TotRub = A115TotRub;
               HD80( false, 18) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1928TotDsc, "")), 1, Gx_line+2, 308, Gx_line+18, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               /* Using cursor P00D84 */
               pr_default.execute(2, new Object[] {AV76TotTipo, AV75TotRub});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A115TotRub = P00D84_A115TotRub[0];
                  A114TotTipo = P00D84_A114TotTipo[0];
                  A1829RubSts = P00D84_A1829RubSts[0];
                  A116RubCod = P00D84_A116RubCod[0];
                  A1822RubDsc = P00D84_A1822RubDsc[0];
                  A1823RubDscTot = P00D84_A1823RubDscTot[0];
                  A117RubOrd = P00D84_A117RubOrd[0];
                  AV67RubCod = A116RubCod;
                  HD80( false, 19) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1822RubDsc, "")), 18, Gx_line+3, 311, Gx_line+19, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
                  /* Using cursor P00D85 */
                  pr_default.execute(3, new Object[] {AV76TotTipo, AV75TotRub, AV67RubCod});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A116RubCod = P00D85_A116RubCod[0];
                     A115TotRub = P00D85_A115TotRub[0];
                     A114TotTipo = P00D85_A114TotTipo[0];
                     A118RubLinCod = P00D85_A118RubLinCod[0];
                     A1826RubLinDsc = P00D85_A1826RubLinDsc[0];
                     A119RubLinOrd = P00D85_A119RubLinOrd[0];
                     AV76TotTipo = A114TotTipo;
                     AV75TotRub = A115TotRub;
                     AV67RubCod = A116RubCod;
                     AV68RubLinCod = A118RubLinCod;
                     GXt_decimal1 = AV44nEnero;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  1,  "ACT",  "", out  GXt_decimal1) ;
                     AV44nEnero = GXt_decimal1;
                     GXt_decimal1 = AV45nFebrero;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  2,  "ACT",  "", out  GXt_decimal1) ;
                     AV45nFebrero = GXt_decimal1;
                     GXt_decimal1 = AV48nMarzo;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  3,  "ACT",  "", out  GXt_decimal1) ;
                     AV48nMarzo = GXt_decimal1;
                     GXt_decimal1 = AV40nAbril;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  4,  "ACT",  "", out  GXt_decimal1) ;
                     AV40nAbril = GXt_decimal1;
                     GXt_decimal1 = AV49nMayo;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  5,  "ACT",  "", out  GXt_decimal1) ;
                     AV49nMayo = GXt_decimal1;
                     GXt_decimal1 = AV47nJunio;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  6,  "ACT",  "", out  GXt_decimal1) ;
                     AV47nJunio = GXt_decimal1;
                     GXt_decimal1 = AV46nJulio;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  7,  "ACT",  "", out  GXt_decimal1) ;
                     AV46nJulio = GXt_decimal1;
                     GXt_decimal1 = AV41nAgosto;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  8,  "ACT",  "", out  GXt_decimal1) ;
                     AV41nAgosto = GXt_decimal1;
                     GXt_decimal1 = AV52nSep;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  9,  "ACT",  "", out  GXt_decimal1) ;
                     AV52nSep = GXt_decimal1;
                     GXt_decimal1 = AV51nOct;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  10,  "ACT",  "", out  GXt_decimal1) ;
                     AV51nOct = GXt_decimal1;
                     GXt_decimal1 = AV50nNov;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  11,  "ACT",  "", out  GXt_decimal1) ;
                     AV50nNov = GXt_decimal1;
                     GXt_decimal1 = AV43nDic;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  12,  "ACT",  "", out  GXt_decimal1) ;
                     AV43nDic = GXt_decimal1;
                     AV44nEnero = (decimal)(AV44nEnero*-1);
                     AV45nFebrero = (decimal)(AV45nFebrero*-1);
                     AV48nMarzo = (decimal)(AV48nMarzo*-1);
                     AV40nAbril = (decimal)(AV40nAbril*-1);
                     AV49nMayo = (decimal)(AV49nMayo*-1);
                     AV47nJunio = (decimal)(AV47nJunio*-1);
                     AV46nJulio = (decimal)(AV46nJulio*-1);
                     AV41nAgosto = (decimal)(AV41nAgosto*-1);
                     AV52nSep = (decimal)(AV52nSep*-1);
                     AV51nOct = (decimal)(AV51nOct*-1);
                     AV50nNov = (decimal)(AV50nNov*-1);
                     AV43nDic = (decimal)(AV43nDic*-1);
                     AV42nAper = NumberUtil.Round( AV42nAper/ (decimal)(AV10Cambio), 2);
                     AV44nEnero = NumberUtil.Round( AV44nEnero/ (decimal)(AV10Cambio), 2);
                     AV45nFebrero = NumberUtil.Round( AV45nFebrero/ (decimal)(AV10Cambio), 2);
                     AV48nMarzo = NumberUtil.Round( AV48nMarzo/ (decimal)(AV10Cambio), 2);
                     AV40nAbril = NumberUtil.Round( AV40nAbril/ (decimal)(AV10Cambio), 2);
                     AV49nMayo = NumberUtil.Round( AV49nMayo/ (decimal)(AV10Cambio), 2);
                     AV47nJunio = NumberUtil.Round( AV47nJunio/ (decimal)(AV10Cambio), 2);
                     AV46nJulio = NumberUtil.Round( AV46nJulio/ (decimal)(AV10Cambio), 2);
                     AV41nAgosto = NumberUtil.Round( AV41nAgosto/ (decimal)(AV10Cambio), 2);
                     AV52nSep = NumberUtil.Round( AV52nSep/ (decimal)(AV10Cambio), 2);
                     AV51nOct = NumberUtil.Round( AV51nOct/ (decimal)(AV10Cambio), 2);
                     AV50nNov = NumberUtil.Round( AV50nNov/ (decimal)(AV10Cambio), 2);
                     AV43nDic = NumberUtil.Round( AV43nDic/ (decimal)(AV10Cambio), 2);
                     HD80( false, 16) ;
                     getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1826RubLinDsc, "")), 35, Gx_line+0, 296, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44nEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 283, Gx_line+1, 373, Gx_line+14, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47nJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 629, Gx_line+1, 719, Gx_line+14, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41nAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 767, Gx_line+1, 857, Gx_line+14, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45nFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 351, Gx_line+1, 441, Gx_line+14, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48nMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 423, Gx_line+1, 513, Gx_line+14, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40nAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 506, Gx_line+3, 578, Gx_line+12, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49nMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 559, Gx_line+1, 649, Gx_line+14, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46nJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 700, Gx_line+1, 790, Gx_line+14, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52nSep, "ZZZZZZ,ZZZ,ZZ9.99")), 852, Gx_line+3, 924, Gx_line+12, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51nOct, "ZZZZZZ,ZZZ,ZZ9.99")), 907, Gx_line+1, 997, Gx_line+14, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50nNov, "ZZZZZZ,ZZZ,ZZ9.99")), 975, Gx_line+1, 1065, Gx_line+14, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43nDic, "ZZZZZZ,ZZZ,ZZ9.99")), 1051, Gx_line+1, 1141, Gx_line+14, 2, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+16);
                     if ( StringUtil.StrCmp(AV72Tipo, "C") == 0 )
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
                     AV55nTAper = (decimal)(AV55nTAper+AV42nAper);
                     AV57nTEnero = (decimal)(AV57nTEnero+AV44nEnero);
                     AV58nTFebrero = (decimal)(AV58nTFebrero+AV45nFebrero);
                     AV61nTMarzo = (decimal)(AV61nTMarzo+AV48nMarzo);
                     AV53nTAbril = (decimal)(AV53nTAbril+AV40nAbril);
                     AV62nTMayo = (decimal)(AV62nTMayo+AV49nMayo);
                     AV60nTJunio = (decimal)(AV60nTJunio+AV47nJunio);
                     AV59nTJulio = (decimal)(AV59nTJulio+AV46nJulio);
                     AV54nTAgosto = (decimal)(AV54nTAgosto+AV41nAgosto);
                     AV65nTSep = (decimal)(AV65nTSep+AV52nSep);
                     AV64nTOct = (decimal)(AV64nTOct+AV51nOct);
                     AV63nTNov = (decimal)(AV63nTNov+AV50nNov);
                     AV56nTDic = (decimal)(AV56nTDic+AV43nDic);
                     pr_default.readNext(3);
                  }
                  pr_default.close(3);
                  HD80( false, 19) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1823RubDscTot, "")), 9, Gx_line+3, 281, Gx_line+19, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57nTEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 301, Gx_line+6, 373, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60nTJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 611, Gx_line+6, 718, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54nTAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 750, Gx_line+6, 857, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58nTFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 333, Gx_line+6, 440, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61nTMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 406, Gx_line+6, 513, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53nTAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 506, Gx_line+6, 578, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62nTMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 542, Gx_line+6, 649, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59nTJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 682, Gx_line+6, 789, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65nTSep, "ZZZZZZ,ZZZ,ZZ9.99")), 852, Gx_line+6, 924, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64nTOct, "ZZZZZZ,ZZZ,ZZ9.99")), 890, Gx_line+6, 997, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63nTNov, "ZZZZZZ,ZZZ,ZZ9.99")), 958, Gx_line+6, 1065, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56nTDic, "ZZZZZZ,ZZZ,ZZ9.99")), 1033, Gx_line+6, 1140, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(294, Gx_line+1, 1141, Gx_line+1, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               HD80( false, 31) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1929TotDscTot, "")), 8, Gx_line+9, 281, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57nTEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 301, Gx_line+12, 373, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60nTJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 594, Gx_line+12, 719, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54nTAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 731, Gx_line+12, 856, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58nTFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 316, Gx_line+12, 441, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61nTMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 388, Gx_line+12, 513, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53nTAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 506, Gx_line+12, 578, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62nTMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 551, Gx_line+12, 649, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59nTJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 683, Gx_line+12, 789, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65nTSep, "ZZZZZZ,ZZZ,ZZ9.99")), 852, Gx_line+12, 924, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64nTOct, "ZZZZZZ,ZZZ,ZZ9.99")), 872, Gx_line+12, 997, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63nTNov, "ZZZZZZ,ZZZ,ZZ9.99")), 941, Gx_line+12, 1066, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(293, Gx_line+8, 1140, Gx_line+8, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56nTDic, "ZZZZZZ,ZZZ,ZZ9.99")), 1016, Gx_line+12, 1141, Gx_line+21, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+31);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HD80( true, 0) ;
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
         /* Using cursor P00D86 */
         pr_default.execute(4, new Object[] {AV76TotTipo, AV75TotRub, AV67RubCod, AV68RubLinCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A118RubLinCod = P00D86_A118RubLinCod[0];
            A116RubCod = P00D86_A116RubCod[0];
            A115TotRub = P00D86_A115TotRub[0];
            A114TotTipo = P00D86_A114TotTipo[0];
            A860CueDsc = P00D86_A860CueDsc[0];
            A91CueCod = P00D86_A91CueCod[0];
            A860CueDsc = P00D86_A860CueDsc[0];
            AV35Len = StringUtil.Len( A91CueCod);
            AV14Cuenta = A91CueCod;
            AV13CueDsc = A860CueDsc;
            AV70Saldo = 0.00m;
            /* Execute user subroutine: 'OBTIENESALDO' */
            S127 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            HD80( false, 20) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13CueDsc, "")), 79, Gx_line+3, 308, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Cuenta, "")), 14, Gx_line+3, 78, Gx_line+16, 0+256, 0, 0, 0) ;
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
         AV30ImpMov = 0.00m;
         /* Using cursor P00D87 */
         pr_default.execute(5, new Object[] {AV35Len, AV14Cuenta});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A91CueCod = P00D87_A91CueCod[0];
            AV12CueCod = A91CueCod;
            GXt_char2 = "";
            GXt_char3 = "";
            new GeneXus.Programs.contabilidad.poptienesaldocuentamesactual(context ).execute( ref  AV8Ano, ref  AV37Mes, ref  AV12CueCod, ref  GXt_char2, ref  GXt_char3, out  AV15Debe, out  AV26Haber) ;
            AV30ImpMov = (decimal)(AV15Debe-AV26Haber);
            if ( StringUtil.StrCmp(AV76TotTipo, "BAL") == 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Substring( AV12CueCod, 1, 1), "4") >= 0 )
               {
                  AV30ImpMov = (decimal)(AV30ImpMov*-1);
               }
            }
            AV70Saldo = (decimal)(AV70Saldo+AV30ImpMov);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void HD80( bool bFoot ,
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73Titulo, "")), 352, Gx_line+14, 808, Gx_line+39, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74Titulo2, "")), 352, Gx_line+39, 808, Gx_line+64, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+117, 1146, Gx_line+146, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción", 105, Gx_line+124, 165, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Empresa, "")), 14, Gx_line+64, 384, Gx_line+82, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19EmpRUC, "")), 14, Gx_line+81, 385, Gx_line+99, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66Periodo, "")), 352, Gx_line+64, 808, Gx_line+89, 1, 0, 0, 0) ;
               getPrinter().GxDrawLine(308, Gx_line+116, 308, Gx_line+144, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Enero", 331, Gx_line+124, 362, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(377, Gx_line+116, 377, Gx_line+144, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Febrero", 392, Gx_line+124, 435, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(446, Gx_line+117, 446, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Marzo", 463, Gx_line+124, 496, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(515, Gx_line+117, 515, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Abril", 536, Gx_line+124, 563, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(584, Gx_line+117, 584, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Junio", 672, Gx_line+124, 700, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(653, Gx_line+117, 653, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Mayo", 604, Gx_line+124, 633, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(722, Gx_line+117, 722, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Julio", 743, Gx_line+124, 768, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(791, Gx_line+117, 791, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Agosto", 807, Gx_line+124, 844, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(860, Gx_line+117, 860, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Sept.", 884, Gx_line+124, 911, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(929, Gx_line+117, 929, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Oct.", 952, Gx_line+124, 974, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(998, Gx_line+117, 998, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Nov.", 1020, Gx_line+124, 1044, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1067, Gx_line+116, 1067, Gx_line+144, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Dic.", 1092, Gx_line+124, 1112, Gx_line+137, 0+256, 0, 0, 0) ;
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
         AV18Empresa = "";
         AV71Session = context.GetSession();
         AV17EmpDir = "";
         AV19EmpRUC = "";
         AV69Ruta = "";
         AV36Logo = "";
         AV94Logo_GXI = "";
         AV76TotTipo = "";
         AV73Titulo = "";
         AV74Titulo2 = "";
         AV66Periodo = "";
         scmdbuf = "";
         P00D82_A180MonCod = new int[1] ;
         P00D82_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV21Fecha = DateTime.MinValue;
         P00D83_A114TotTipo = new string[] {""} ;
         P00D83_A115TotRub = new int[1] ;
         P00D83_A1928TotDsc = new string[] {""} ;
         P00D83_A1929TotDscTot = new string[] {""} ;
         P00D83_A120TotOrd = new short[1] ;
         A114TotTipo = "";
         A1928TotDsc = "";
         A1929TotDscTot = "";
         P00D84_A115TotRub = new int[1] ;
         P00D84_A114TotTipo = new string[] {""} ;
         P00D84_A1829RubSts = new short[1] ;
         P00D84_A116RubCod = new int[1] ;
         P00D84_A1822RubDsc = new string[] {""} ;
         P00D84_A1823RubDscTot = new string[] {""} ;
         P00D84_A117RubOrd = new short[1] ;
         A1822RubDsc = "";
         A1823RubDscTot = "";
         P00D85_A116RubCod = new int[1] ;
         P00D85_A115TotRub = new int[1] ;
         P00D85_A114TotTipo = new string[] {""} ;
         P00D85_A118RubLinCod = new int[1] ;
         P00D85_A1826RubLinDsc = new string[] {""} ;
         P00D85_A119RubLinOrd = new short[1] ;
         A1826RubLinDsc = "";
         P00D86_A118RubLinCod = new int[1] ;
         P00D86_A116RubCod = new int[1] ;
         P00D86_A115TotRub = new int[1] ;
         P00D86_A114TotTipo = new string[] {""} ;
         P00D86_A860CueDsc = new string[] {""} ;
         P00D86_A91CueCod = new string[] {""} ;
         A860CueDsc = "";
         A91CueCod = "";
         AV14Cuenta = "";
         AV13CueDsc = "";
         P00D87_A91CueCod = new string[] {""} ;
         AV12CueCod = "";
         GXt_char2 = "";
         GXt_char3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_resultadonaturalezaanualpdf__default(),
            new Object[][] {
                new Object[] {
               P00D82_A180MonCod, P00D82_A1234MonDsc
               }
               , new Object[] {
               P00D83_A114TotTipo, P00D83_A115TotRub, P00D83_A1928TotDsc, P00D83_A1929TotDscTot, P00D83_A120TotOrd
               }
               , new Object[] {
               P00D84_A115TotRub, P00D84_A114TotTipo, P00D84_A1829RubSts, P00D84_A116RubCod, P00D84_A1822RubDsc, P00D84_A1823RubDscTot, P00D84_A117RubOrd
               }
               , new Object[] {
               P00D85_A116RubCod, P00D85_A115TotRub, P00D85_A114TotTipo, P00D85_A118RubLinCod, P00D85_A1826RubLinDsc, P00D85_A119RubLinOrd
               }
               , new Object[] {
               P00D86_A118RubLinCod, P00D86_A116RubCod, P00D86_A115TotRub, P00D86_A114TotTipo, P00D86_A860CueDsc, P00D86_A91CueCod
               }
               , new Object[] {
               P00D87_A91CueCod
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
      private short A120TotOrd ;
      private short A1829RubSts ;
      private short A117RubOrd ;
      private short A119RubLinOrd ;
      private short AV37Mes ;
      private int AV39Moneda ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int A115TotRub ;
      private int AV75TotRub ;
      private int Gx_OldLine ;
      private int A116RubCod ;
      private int AV67RubCod ;
      private int A118RubLinCod ;
      private int AV68RubLinCod ;
      private int AV35Len ;
      private decimal AV10Cambio ;
      private decimal AV44nEnero ;
      private decimal AV45nFebrero ;
      private decimal AV48nMarzo ;
      private decimal AV40nAbril ;
      private decimal AV49nMayo ;
      private decimal AV47nJunio ;
      private decimal AV46nJulio ;
      private decimal AV41nAgosto ;
      private decimal AV52nSep ;
      private decimal AV51nOct ;
      private decimal AV50nNov ;
      private decimal AV43nDic ;
      private decimal AV55nTAper ;
      private decimal AV57nTEnero ;
      private decimal AV58nTFebrero ;
      private decimal AV61nTMarzo ;
      private decimal AV53nTAbril ;
      private decimal AV62nTMayo ;
      private decimal AV60nTJunio ;
      private decimal AV59nTJulio ;
      private decimal AV54nTAgosto ;
      private decimal AV65nTSep ;
      private decimal AV64nTOct ;
      private decimal AV63nTNov ;
      private decimal AV56nTDic ;
      private decimal GXt_decimal1 ;
      private decimal AV42nAper ;
      private decimal AV70Saldo ;
      private decimal AV30ImpMov ;
      private decimal AV15Debe ;
      private decimal AV26Haber ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV72Tipo ;
      private string AV18Empresa ;
      private string AV17EmpDir ;
      private string AV19EmpRUC ;
      private string AV69Ruta ;
      private string AV76TotTipo ;
      private string AV73Titulo ;
      private string AV74Titulo2 ;
      private string AV66Periodo ;
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
      private string AV14Cuenta ;
      private string AV13CueDsc ;
      private string AV12CueCod ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private DateTime AV21Fecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private string AV94Logo_GXI ;
      private string AV36Logo ;
      private IGxSession AV71Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private string aP1_Tipo ;
      private int aP2_Moneda ;
      private IDataStoreProvider pr_default ;
      private int[] P00D82_A180MonCod ;
      private string[] P00D82_A1234MonDsc ;
      private string[] P00D83_A114TotTipo ;
      private int[] P00D83_A115TotRub ;
      private string[] P00D83_A1928TotDsc ;
      private string[] P00D83_A1929TotDscTot ;
      private short[] P00D83_A120TotOrd ;
      private int[] P00D84_A115TotRub ;
      private string[] P00D84_A114TotTipo ;
      private short[] P00D84_A1829RubSts ;
      private int[] P00D84_A116RubCod ;
      private string[] P00D84_A1822RubDsc ;
      private string[] P00D84_A1823RubDscTot ;
      private short[] P00D84_A117RubOrd ;
      private int[] P00D85_A116RubCod ;
      private int[] P00D85_A115TotRub ;
      private string[] P00D85_A114TotTipo ;
      private int[] P00D85_A118RubLinCod ;
      private string[] P00D85_A1826RubLinDsc ;
      private short[] P00D85_A119RubLinOrd ;
      private int[] P00D86_A118RubLinCod ;
      private int[] P00D86_A116RubCod ;
      private int[] P00D86_A115TotRub ;
      private string[] P00D86_A114TotTipo ;
      private string[] P00D86_A860CueDsc ;
      private string[] P00D86_A91CueCod ;
      private string[] P00D87_A91CueCod ;
   }

   public class r_resultadonaturalezaanualpdf__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00D82;
          prmP00D82 = new Object[] {
          new ParDef("@AV39Moneda",GXType.Int32,6,0)
          };
          Object[] prmP00D83;
          prmP00D83 = new Object[] {
          new ParDef("@AV76TotTipo",GXType.NChar,3,0)
          };
          Object[] prmP00D84;
          prmP00D84 = new Object[] {
          new ParDef("@AV76TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV75TotRub",GXType.Int32,6,0)
          };
          Object[] prmP00D85;
          prmP00D85 = new Object[] {
          new ParDef("@AV76TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV75TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV67RubCod",GXType.Int32,6,0)
          };
          Object[] prmP00D86;
          prmP00D86 = new Object[] {
          new ParDef("@AV76TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV75TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV67RubCod",GXType.Int32,6,0) ,
          new ParDef("@AV68RubLinCod",GXType.Int32,6,0)
          };
          Object[] prmP00D87;
          prmP00D87 = new Object[] {
          new ParDef("@AV35Len",GXType.Int32,5,0) ,
          new ParDef("@AV14Cuenta",GXType.Char,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D82", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV39Moneda ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D82,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00D83", "SELECT [TotTipo], [TotRub], [TotDsc], [TotDscTot], [TotOrd] FROM [CBRUBROST] WHERE [TotTipo] = @AV76TotTipo ORDER BY [TotOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D83,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D84", "SELECT [TotRub], [TotTipo], [RubSts], [RubCod], [RubDsc], [RubDscTot], [RubOrd] FROM [CBRUBROS] WHERE ([TotTipo] = @AV76TotTipo) AND ([TotRub] = @AV75TotRub) ORDER BY [RubOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D84,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D85", "SELECT [RubCod], [TotRub], [TotTipo], [RubLinCod], [RubLinDsc], [RubLinOrd] FROM [CBRUBROSL] WHERE ([TotTipo] = @AV76TotTipo) AND ([TotRub] = @AV75TotRub) AND ([RubCod] = @AV67RubCod) ORDER BY [RubLinOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D85,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D86", "SELECT T1.[RubLinCod], T1.[RubCod], T1.[TotRub], T1.[TotTipo], T2.[CueDsc], T1.[CueCod] FROM ([CBRUBROSLD] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE T1.[TotTipo] = @AV76TotTipo and T1.[TotRub] = @AV75TotRub and T1.[RubCod] = @AV67RubCod and T1.[RubLinCod] = @AV68RubLinCod ORDER BY T1.[TotTipo], T1.[TotRub], T1.[RubCod], T1.[RubLinCod], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D86,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D87", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE SUBSTRING([CueCod], 1, @AV35Len) = @AV14Cuenta ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D87,100, GxCacheFrequency.OFF ,true,false )
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
