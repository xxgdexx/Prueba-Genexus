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
   public class r_registrocostospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_registrocostospdf.aspx")), "contabilidad.r_registrocostospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_registrocostospdf.aspx")))) ;
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

      public r_registrocostospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_registrocostospdf( IGxContext context )
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
         r_registrocostospdf objr_registrocostospdf;
         objr_registrocostospdf = new r_registrocostospdf();
         objr_registrocostospdf.AV11Ano = aP0_Ano;
         objr_registrocostospdf.AV38Tipo = aP1_Tipo;
         objr_registrocostospdf.AV48Moneda = aP2_Moneda;
         objr_registrocostospdf.context.SetSubmitInitialConfig(context);
         objr_registrocostospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_registrocostospdf);
         aP0_Ano=this.AV11Ano;
         aP1_Tipo=this.AV38Tipo;
         aP2_Moneda=this.AV48Moneda;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_registrocostospdf)stateInfo).executePrivate();
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
            AV8TotTipo = "COS";
            AV13Titulo = "Registro de Costos";
            AV50Titulo2 = "";
            /* Using cursor P00CR2 */
            pr_default.execute(0, new Object[] {AV48Moneda});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P00CR2_A180MonCod[0];
               A1234MonDsc = P00CR2_A1234MonDsc[0];
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
            AV13Titulo = "FORMATO 10.2: REGISTRO DE COSTOS - ELEMENTOS DEL COSTO MENSUAL";
            AV14Periodo = StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV19AnoAnt = AV11Ano;
            AV20MesAnt = (short)(AV12Mes-1);
            AV76TEnero = 0.00m;
            AV75TFebrero = 0.00m;
            AV74TMarzo = 0.00m;
            AV73TAbril = 0.00m;
            AV72TMayo = 0.00m;
            AV71TJunio = 0.00m;
            AV70TJulio = 0.00m;
            AV69TAgosto = 0.00m;
            AV68TSeptiembre = 0.00m;
            AV67TOctubre = 0.00m;
            AV66TNoviembre = 0.00m;
            AV65TDiciembre = 0.00m;
            AV64TTotal = 0.00m;
            /* Using cursor P00CR3 */
            pr_default.execute(1, new Object[] {AV8TotTipo});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A114TotTipo = P00CR3_A114TotTipo[0];
               A115TotRub = P00CR3_A115TotRub[0];
               A1929TotDscTot = P00CR3_A1929TotDscTot[0];
               A120TotOrd = P00CR3_A120TotOrd[0];
               AV9TotRub = A115TotRub;
               AV27ImpTot = 0.00m;
               /* Using cursor P00CR4 */
               pr_default.execute(2, new Object[] {AV8TotTipo, AV9TotRub});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A115TotRub = P00CR4_A115TotRub[0];
                  A114TotTipo = P00CR4_A114TotTipo[0];
                  A1829RubSts = P00CR4_A1829RubSts[0];
                  A116RubCod = P00CR4_A116RubCod[0];
                  A1822RubDsc = P00CR4_A1822RubDsc[0];
                  A1823RubDscTot = P00CR4_A1823RubDscTot[0];
                  A117RubOrd = P00CR4_A117RubOrd[0];
                  AV10RubCod = A116RubCod;
                  AV77rEnero = 0.00m;
                  AV78rFebrero = 0.00m;
                  AV79rMarzo = 0.00m;
                  AV80rAbril = 0.00m;
                  AV81rMayo = 0.00m;
                  AV82rJunio = 0.00m;
                  AV83rJulio = 0.00m;
                  AV84rAgosto = 0.00m;
                  AV85rSeptiembre = 0.00m;
                  AV86rOctubre = 0.00m;
                  AV87rNoviembre = 0.00m;
                  AV88rDiciembre = 0.00m;
                  AV89rTotal = 0.00m;
                  HCR0( false, 23) ;
                  getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1822RubDsc, "")), 16, Gx_line+3, 255, Gx_line+19, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+23);
                  /* Using cursor P00CR5 */
                  pr_default.execute(3, new Object[] {AV8TotTipo, AV9TotRub, AV10RubCod});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A116RubCod = P00CR5_A116RubCod[0];
                     A115TotRub = P00CR5_A115TotRub[0];
                     A114TotTipo = P00CR5_A114TotTipo[0];
                     A118RubLinCod = P00CR5_A118RubLinCod[0];
                     A1826RubLinDsc = P00CR5_A1826RubLinDsc[0];
                     A119RubLinOrd = P00CR5_A119RubLinOrd[0];
                     AV8TotTipo = A114TotTipo;
                     AV9TotRub = A115TotRub;
                     AV10RubCod = A116RubCod;
                     AV42RubLinCod = A118RubLinCod;
                     GXt_decimal1 = AV51nEnero;
                     new GeneXus.Programs.contabilidad.psaldolineabalancemesactual(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  1, out  GXt_decimal1) ;
                     AV51nEnero = GXt_decimal1;
                     GXt_decimal1 = AV52nFebrero;
                     new GeneXus.Programs.contabilidad.psaldolineabalancemesactual(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  2, out  GXt_decimal1) ;
                     AV52nFebrero = GXt_decimal1;
                     GXt_decimal1 = AV53nMarzo;
                     new GeneXus.Programs.contabilidad.psaldolineabalancemesactual(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  3, out  GXt_decimal1) ;
                     AV53nMarzo = GXt_decimal1;
                     GXt_decimal1 = AV54nAbril;
                     new GeneXus.Programs.contabilidad.psaldolineabalancemesactual(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  4, out  GXt_decimal1) ;
                     AV54nAbril = GXt_decimal1;
                     GXt_decimal1 = AV55nMayo;
                     new GeneXus.Programs.contabilidad.psaldolineabalancemesactual(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  5, out  GXt_decimal1) ;
                     AV55nMayo = GXt_decimal1;
                     GXt_decimal1 = AV56nJunio;
                     new GeneXus.Programs.contabilidad.psaldolineabalancemesactual(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  6, out  GXt_decimal1) ;
                     AV56nJunio = GXt_decimal1;
                     GXt_decimal1 = AV57nJulio;
                     new GeneXus.Programs.contabilidad.psaldolineabalancemesactual(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  7, out  GXt_decimal1) ;
                     AV57nJulio = GXt_decimal1;
                     GXt_decimal1 = AV58nAgosto;
                     new GeneXus.Programs.contabilidad.psaldolineabalancemesactual(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  8, out  GXt_decimal1) ;
                     AV58nAgosto = GXt_decimal1;
                     GXt_decimal1 = AV59nSeptiembre;
                     new GeneXus.Programs.contabilidad.psaldolineabalancemesactual(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  9, out  GXt_decimal1) ;
                     AV59nSeptiembre = GXt_decimal1;
                     GXt_decimal1 = AV60nOctubre;
                     new GeneXus.Programs.contabilidad.psaldolineabalancemesactual(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  10, out  GXt_decimal1) ;
                     AV60nOctubre = GXt_decimal1;
                     GXt_decimal1 = AV61nNoviembre;
                     new GeneXus.Programs.contabilidad.psaldolineabalancemesactual(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  11, out  GXt_decimal1) ;
                     AV61nNoviembre = GXt_decimal1;
                     GXt_decimal1 = AV62nDiciembre;
                     new GeneXus.Programs.contabilidad.psaldolineabalancemesactual(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  12, out  GXt_decimal1) ;
                     AV62nDiciembre = GXt_decimal1;
                     HCR0( false, 18) ;
                     getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1826RubLinDsc, "")), 16, Gx_line+1, 256, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51nEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 254, Gx_line+4, 326, Gx_line+15, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52nFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 320, Gx_line+4, 392, Gx_line+15, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53nMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 386, Gx_line+4, 458, Gx_line+15, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54nAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 453, Gx_line+4, 525, Gx_line+15, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55nMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 519, Gx_line+4, 591, Gx_line+15, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56nJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 586, Gx_line+4, 658, Gx_line+15, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57nJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 651, Gx_line+4, 723, Gx_line+15, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58nAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 721, Gx_line+4, 793, Gx_line+15, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59nSeptiembre, "ZZZZZZ,ZZZ,ZZ9.99")), 788, Gx_line+4, 860, Gx_line+15, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60nOctubre, "ZZZZZZ,ZZZ,ZZ9.99")), 854, Gx_line+4, 926, Gx_line+15, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61nNoviembre, "ZZZZZZ,ZZZ,ZZ9.99")), 922, Gx_line+4, 994, Gx_line+15, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62nDiciembre, "ZZZZZZ,ZZZ,ZZ9.99")), 990, Gx_line+4, 1062, Gx_line+15, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63nTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 1064, Gx_line+4, 1136, Gx_line+15, 2+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+18);
                     AV77rEnero = (decimal)(AV77rEnero+AV51nEnero);
                     AV78rFebrero = (decimal)(AV78rFebrero+AV52nFebrero);
                     AV79rMarzo = (decimal)(AV79rMarzo+AV53nMarzo);
                     AV80rAbril = (decimal)(AV80rAbril+AV54nAbril);
                     AV81rMayo = (decimal)(AV81rMayo+AV55nMayo);
                     AV82rJunio = (decimal)(AV82rJunio+AV56nJunio);
                     AV83rJulio = (decimal)(AV83rJulio+AV57nJulio);
                     AV84rAgosto = (decimal)(AV84rAgosto+AV58nAgosto);
                     AV85rSeptiembre = (decimal)(AV85rSeptiembre+AV59nSeptiembre);
                     AV86rOctubre = (decimal)(AV86rOctubre+AV60nOctubre);
                     AV87rNoviembre = (decimal)(AV87rNoviembre+AV61nNoviembre);
                     AV88rDiciembre = (decimal)(AV88rDiciembre+AV62nDiciembre);
                     AV89rTotal = (decimal)(AV89rTotal+AV63nTotal);
                     pr_default.readNext(3);
                  }
                  pr_default.close(3);
                  HCR0( false, 25) ;
                  getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1823RubDscTot, "")), 16, Gx_line+7, 249, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(252, Gx_line+5, 1140, Gx_line+5, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV78rFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 320, Gx_line+10, 392, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV79rMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 386, Gx_line+10, 458, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV80rAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 453, Gx_line+10, 525, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV81rMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 519, Gx_line+10, 591, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV82rJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 586, Gx_line+10, 658, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV83rJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 651, Gx_line+10, 723, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV84rAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 721, Gx_line+10, 793, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85rSeptiembre, "ZZZZZZ,ZZZ,ZZ9.99")), 788, Gx_line+10, 860, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV86rOctubre, "ZZZZZZ,ZZZ,ZZ9.99")), 854, Gx_line+10, 926, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87rNoviembre, "ZZZZZZ,ZZZ,ZZ9.99")), 922, Gx_line+10, 994, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88rDiciembre, "ZZZZZZ,ZZZ,ZZ9.99")), 990, Gx_line+10, 1062, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89rTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 1064, Gx_line+10, 1136, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV77rEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 254, Gx_line+10, 326, Gx_line+21, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+25);
                  AV76TEnero = (decimal)(AV76TEnero+AV77rEnero);
                  AV75TFebrero = (decimal)(AV75TFebrero+AV78rFebrero);
                  AV74TMarzo = (decimal)(AV74TMarzo+AV79rMarzo);
                  AV73TAbril = (decimal)(AV73TAbril+AV80rAbril);
                  AV72TMayo = (decimal)(AV72TMayo+AV81rMayo);
                  AV71TJunio = (decimal)(AV71TJunio+AV82rJunio);
                  AV70TJulio = (decimal)(AV70TJulio+AV83rJulio);
                  AV69TAgosto = (decimal)(AV69TAgosto+AV84rAgosto);
                  AV68TSeptiembre = (decimal)(AV68TSeptiembre+AV85rSeptiembre);
                  AV67TOctubre = (decimal)(AV67TOctubre+AV86rOctubre);
                  AV66TNoviembre = (decimal)(AV66TNoviembre+AV87rNoviembre);
                  AV65TDiciembre = (decimal)(AV65TDiciembre+AV88rDiciembre);
                  AV64TTotal = (decimal)(AV64TTotal+AV89rTotal);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               HCR0( false, 42) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1929TotDscTot, "")), 16, Gx_line+10, 246, Gx_line+26, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(249, Gx_line+7, 1137, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 1064, Gx_line+14, 1136, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TDiciembre, "ZZZZZZ,ZZZ,ZZ9.99")), 990, Gx_line+14, 1062, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66TNoviembre, "ZZZZZZ,ZZZ,ZZ9.99")), 922, Gx_line+14, 994, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67TOctubre, "ZZZZZZ,ZZZ,ZZ9.99")), 854, Gx_line+14, 926, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68TSeptiembre, "ZZZZZZ,ZZZ,ZZ9.99")), 788, Gx_line+14, 860, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69TAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 721, Gx_line+14, 793, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70TJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 651, Gx_line+14, 723, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71TJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 586, Gx_line+14, 658, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72TMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 519, Gx_line+14, 591, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73TAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 453, Gx_line+14, 525, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74TMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 386, Gx_line+14, 458, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75TFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 320, Gx_line+14, 392, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV76TEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 254, Gx_line+14, 326, Gx_line+25, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+42);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HCR0( true, 0) ;
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

      protected void HCR0( bool bFoot ,
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
               getPrinter().GxDrawRect(1, Gx_line+96, 1140, Gx_line+123, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("CONSUMO DE LA PRODUCCIÓN", 54, Gx_line+104, 183, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1063, Gx_line+97, 1063, Gx_line+123, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(995, Gx_line+97, 995, Gx_line+123, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(860, Gx_line+97, 860, Gx_line+123, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(928, Gx_line+97, 928, Gx_line+123, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(660, Gx_line+97, 660, Gx_line+123, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(593, Gx_line+97, 593, Gx_line+123, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(727, Gx_line+97, 727, Gx_line+123, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(794, Gx_line+97, 794, Gx_line+123, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(392, Gx_line+97, 392, Gx_line+123, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(325, Gx_line+97, 325, Gx_line+123, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(459, Gx_line+97, 459, Gx_line+123, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(526, Gx_line+97, 526, Gx_line+123, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Total", 1088, Gx_line+104, 1110, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Diciembre", 1009, Gx_line+104, 1052, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Noviembre", 938, Gx_line+104, 985, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Octubre", 878, Gx_line+104, 911, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Enero", 279, Gx_line+104, 304, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Febrero", 340, Gx_line+104, 373, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Marzo", 410, Gx_line+104, 436, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Abril", 482, Gx_line+104, 501, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mayo", 548, Gx_line+104, 572, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Junio", 616, Gx_line+104, 639, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Julio", 683, Gx_line+104, 703, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Agosto", 746, Gx_line+104, 775, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Septiembre", 802, Gx_line+104, 851, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(258, Gx_line+97, 258, Gx_line+123, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 923, Gx_line+17, 967, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 978, Gx_line+17, 1017, Gx_line+32, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 16, Gx_line+9, 330, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 90, Gx_line+41, 612, Gx_line+56, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Empresa, "")), 21, Gx_line+77, 472, Gx_line+91, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35EmpRUC, "")), 90, Gx_line+58, 195, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 21, Gx_line+41, 77, Gx_line+55, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 21, Gx_line+58, 52, Gx_line+72, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+123);
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
         scmdbuf = "";
         P00CR2_A180MonCod = new int[1] ;
         P00CR2_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV15Fecha = DateTime.MinValue;
         GXt_char2 = "";
         AV14Periodo = "";
         P00CR3_A114TotTipo = new string[] {""} ;
         P00CR3_A115TotRub = new int[1] ;
         P00CR3_A1929TotDscTot = new string[] {""} ;
         P00CR3_A120TotOrd = new short[1] ;
         A114TotTipo = "";
         A1929TotDscTot = "";
         P00CR4_A115TotRub = new int[1] ;
         P00CR4_A114TotTipo = new string[] {""} ;
         P00CR4_A1829RubSts = new short[1] ;
         P00CR4_A116RubCod = new int[1] ;
         P00CR4_A1822RubDsc = new string[] {""} ;
         P00CR4_A1823RubDscTot = new string[] {""} ;
         P00CR4_A117RubOrd = new short[1] ;
         A1822RubDsc = "";
         A1823RubDscTot = "";
         P00CR5_A116RubCod = new int[1] ;
         P00CR5_A115TotRub = new int[1] ;
         P00CR5_A114TotTipo = new string[] {""} ;
         P00CR5_A118RubLinCod = new int[1] ;
         P00CR5_A1826RubLinDsc = new string[] {""} ;
         P00CR5_A119RubLinOrd = new short[1] ;
         A1826RubLinDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_registrocostospdf__default(),
            new Object[][] {
                new Object[] {
               P00CR2_A180MonCod, P00CR2_A1234MonDsc
               }
               , new Object[] {
               P00CR3_A114TotTipo, P00CR3_A115TotRub, P00CR3_A1929TotDscTot, P00CR3_A120TotOrd
               }
               , new Object[] {
               P00CR4_A115TotRub, P00CR4_A114TotTipo, P00CR4_A1829RubSts, P00CR4_A116RubCod, P00CR4_A1822RubDsc, P00CR4_A1823RubDscTot, P00CR4_A117RubOrd
               }
               , new Object[] {
               P00CR5_A116RubCod, P00CR5_A115TotRub, P00CR5_A114TotTipo, P00CR5_A118RubLinCod, P00CR5_A1826RubLinDsc, P00CR5_A119RubLinOrd
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
      private short AV19AnoAnt ;
      private short AV20MesAnt ;
      private short AV12Mes ;
      private short A120TotOrd ;
      private short A1829RubSts ;
      private short A117RubOrd ;
      private short A119RubLinOrd ;
      private int AV48Moneda ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int A115TotRub ;
      private int AV9TotRub ;
      private int A116RubCod ;
      private int AV10RubCod ;
      private int Gx_OldLine ;
      private int A118RubLinCod ;
      private int AV42RubLinCod ;
      private decimal AV49Cambio ;
      private decimal AV76TEnero ;
      private decimal AV75TFebrero ;
      private decimal AV74TMarzo ;
      private decimal AV73TAbril ;
      private decimal AV72TMayo ;
      private decimal AV71TJunio ;
      private decimal AV70TJulio ;
      private decimal AV69TAgosto ;
      private decimal AV68TSeptiembre ;
      private decimal AV67TOctubre ;
      private decimal AV66TNoviembre ;
      private decimal AV65TDiciembre ;
      private decimal AV64TTotal ;
      private decimal AV27ImpTot ;
      private decimal AV77rEnero ;
      private decimal AV78rFebrero ;
      private decimal AV79rMarzo ;
      private decimal AV80rAbril ;
      private decimal AV81rMayo ;
      private decimal AV82rJunio ;
      private decimal AV83rJulio ;
      private decimal AV84rAgosto ;
      private decimal AV85rSeptiembre ;
      private decimal AV86rOctubre ;
      private decimal AV87rNoviembre ;
      private decimal AV88rDiciembre ;
      private decimal AV89rTotal ;
      private decimal AV51nEnero ;
      private decimal AV52nFebrero ;
      private decimal AV53nMarzo ;
      private decimal AV54nAbril ;
      private decimal AV55nMayo ;
      private decimal AV56nJunio ;
      private decimal AV57nJulio ;
      private decimal AV58nAgosto ;
      private decimal AV59nSeptiembre ;
      private decimal AV60nOctubre ;
      private decimal AV61nNoviembre ;
      private decimal AV62nDiciembre ;
      private decimal GXt_decimal1 ;
      private decimal AV63nTotal ;
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
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string GXt_char2 ;
      private string AV14Periodo ;
      private string A114TotTipo ;
      private string A1929TotDscTot ;
      private string A1822RubDsc ;
      private string A1823RubDscTot ;
      private string A1826RubLinDsc ;
      private DateTime AV15Fecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string AV92Logo_GXI ;
      private string AV37Logo ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private string aP1_Tipo ;
      private int aP2_Moneda ;
      private IDataStoreProvider pr_default ;
      private int[] P00CR2_A180MonCod ;
      private string[] P00CR2_A1234MonDsc ;
      private string[] P00CR3_A114TotTipo ;
      private int[] P00CR3_A115TotRub ;
      private string[] P00CR3_A1929TotDscTot ;
      private short[] P00CR3_A120TotOrd ;
      private int[] P00CR4_A115TotRub ;
      private string[] P00CR4_A114TotTipo ;
      private short[] P00CR4_A1829RubSts ;
      private int[] P00CR4_A116RubCod ;
      private string[] P00CR4_A1822RubDsc ;
      private string[] P00CR4_A1823RubDscTot ;
      private short[] P00CR4_A117RubOrd ;
      private int[] P00CR5_A116RubCod ;
      private int[] P00CR5_A115TotRub ;
      private string[] P00CR5_A114TotTipo ;
      private int[] P00CR5_A118RubLinCod ;
      private string[] P00CR5_A1826RubLinDsc ;
      private short[] P00CR5_A119RubLinOrd ;
   }

   public class r_registrocostospdf__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CR2;
          prmP00CR2 = new Object[] {
          new ParDef("@AV48Moneda",GXType.Int32,6,0)
          };
          Object[] prmP00CR3;
          prmP00CR3 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0)
          };
          Object[] prmP00CR4;
          prmP00CR4 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0)
          };
          Object[] prmP00CR5;
          prmP00CR5 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV10RubCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CR2", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV48Moneda ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CR2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CR3", "SELECT [TotTipo], [TotRub], [TotDscTot], [TotOrd] FROM [CBRUBROST] WHERE [TotTipo] = @AV8TotTipo ORDER BY [TotOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CR3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CR4", "SELECT [TotRub], [TotTipo], [RubSts], [RubCod], [RubDsc], [RubDscTot], [RubOrd] FROM [CBRUBROS] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) ORDER BY [RubOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CR4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CR5", "SELECT [RubCod], [TotRub], [TotTipo], [RubLinCod], [RubLinDsc], [RubLinOrd] FROM [CBRUBROSL] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) AND ([RubCod] = @AV10RubCod) ORDER BY [RubLinOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CR5,100, GxCacheFrequency.OFF ,true,false )
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
