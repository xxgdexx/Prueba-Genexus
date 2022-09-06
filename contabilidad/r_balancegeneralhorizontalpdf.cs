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
   public class r_balancegeneralhorizontalpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_balancegeneralhorizontalpdf.aspx")), "contabilidad.r_balancegeneralhorizontalpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_balancegeneralhorizontalpdf.aspx")))) ;
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
                  AV12Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
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

      public r_balancegeneralhorizontalpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_balancegeneralhorizontalpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref string aP2_Tipo ,
                           ref int aP3_Moneda )
      {
         this.AV11Ano = aP0_Ano;
         this.AV12Mes = aP1_Mes;
         this.AV38Tipo = aP2_Tipo;
         this.AV48Moneda = aP3_Moneda;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_Tipo=this.AV38Tipo;
         aP3_Moneda=this.AV48Moneda;
      }

      public int executeUdp( ref short aP0_Ano ,
                             ref short aP1_Mes ,
                             ref string aP2_Tipo )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_Tipo, ref aP3_Moneda);
         return AV48Moneda ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_Tipo ,
                                 ref int aP3_Moneda )
      {
         r_balancegeneralhorizontalpdf objr_balancegeneralhorizontalpdf;
         objr_balancegeneralhorizontalpdf = new r_balancegeneralhorizontalpdf();
         objr_balancegeneralhorizontalpdf.AV11Ano = aP0_Ano;
         objr_balancegeneralhorizontalpdf.AV12Mes = aP1_Mes;
         objr_balancegeneralhorizontalpdf.AV38Tipo = aP2_Tipo;
         objr_balancegeneralhorizontalpdf.AV48Moneda = aP3_Moneda;
         objr_balancegeneralhorizontalpdf.context.SetSubmitInitialConfig(context);
         objr_balancegeneralhorizontalpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_balancegeneralhorizontalpdf);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_Tipo=this.AV38Tipo;
         aP3_Moneda=this.AV48Moneda;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_balancegeneralhorizontalpdf)stateInfo).executePrivate();
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
            AV75Logo_GXI = GXDbFile.PathToUrl( AV36Ruta);
            AV8TotTipo = "BAL";
            AV13Titulo = "Balance General";
            AV50Titulo2 = "";
            /* Using cursor P00D52 */
            pr_default.execute(0, new Object[] {AV48Moneda});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P00D52_A180MonCod[0];
               A1234MonDsc = P00D52_A1234MonDsc[0];
               AV50Titulo2 = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            GXt_char1 = AV29cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV29cMes = GXt_char1;
            AV30FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV30FechaC, 2);
            GXt_date2 = AV15Fecha;
            new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV16FechaD, out  GXt_date2) ;
            AV15Fecha = GXt_date2;
            GXt_decimal3 = AV49Cambio;
            GXt_char1 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV48Moneda, ref  AV15Fecha, ref  GXt_char1, out  GXt_decimal3) ;
            AV49Cambio = GXt_decimal3;
            if ( AV48Moneda == 1 )
            {
               AV49Cambio = (decimal)(1);
            }
            if ( AV12Mes == 0 )
            {
               AV14Periodo = "Al : " + "01/01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            }
            else
            {
               AV14Periodo = "Al : " + context.localUtil.DToC( AV15Fecha, 2, "/");
            }
            AV19AnoAnt = AV11Ano;
            AV20MesAnt = (short)(AV12Mes-1);
            /* Using cursor P00D53 */
            pr_default.execute(1, new Object[] {AV8TotTipo});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A115TotRub = P00D53_A115TotRub[0];
               A114TotTipo = P00D53_A114TotTipo[0];
               A1928TotDsc = P00D53_A1928TotDsc[0];
               A1929TotDscTot = P00D53_A1929TotDscTot[0];
               A120TotOrd = P00D53_A120TotOrd[0];
               AV9TotRub = A115TotRub;
               AV52cActivo = A1928TotDsc;
               AV62TotDscTot = A1929TotDscTot;
               AV68SdtBalanceActivoItem.gxTpr_Baltipo = 1;
               AV68SdtBalanceActivoItem.gxTpr_Baltotales = AV52cActivo;
               AV69SdtBalanceActivo.Add(AV68SdtBalanceActivoItem, 0);
               AV68SdtBalanceActivoItem = new SdtSdtBalance_SdtCuentaItem(context);
               AV65IRub = 1;
               /* Using cursor P00D54 */
               pr_default.execute(2, new Object[] {AV8TotTipo, AV9TotRub});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A115TotRub = P00D54_A115TotRub[0];
                  A114TotTipo = P00D54_A114TotTipo[0];
                  A1829RubSts = P00D54_A1829RubSts[0];
                  A116RubCod = P00D54_A116RubCod[0];
                  A1822RubDsc = P00D54_A1822RubDsc[0];
                  A1823RubDscTot = P00D54_A1823RubDscTot[0];
                  A117RubOrd = P00D54_A117RubOrd[0];
                  AV10RubCod = A116RubCod;
                  AV54RubActivo = A1822RubDsc;
                  AV61RubDscTot = A1823RubDscTot;
                  AV25ImpRub = 0.00m;
                  AV26ImpRubSal = 0.00m;
                  AV68SdtBalanceActivoItem.gxTpr_Baltipo = 1;
                  AV68SdtBalanceActivoItem.gxTpr_Balrubcod = (int)(AV65IRub);
                  AV68SdtBalanceActivoItem.gxTpr_Balrubros = AV54RubActivo;
                  AV69SdtBalanceActivo.Add(AV68SdtBalanceActivoItem, 0);
                  AV68SdtBalanceActivoItem = new SdtSdtBalance_SdtCuentaItem(context);
                  AV67TLin = 1;
                  /* Using cursor P00D55 */
                  pr_default.execute(3, new Object[] {AV8TotTipo, AV9TotRub, AV10RubCod});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A116RubCod = P00D55_A116RubCod[0];
                     A115TotRub = P00D55_A115TotRub[0];
                     A114TotTipo = P00D55_A114TotTipo[0];
                     A118RubLinCod = P00D55_A118RubLinCod[0];
                     A1826RubLinDsc = P00D55_A1826RubLinDsc[0];
                     A119RubLinOrd = P00D55_A119RubLinOrd[0];
                     AV8TotTipo = A114TotTipo;
                     AV9TotRub = A115TotRub;
                     AV10RubCod = A116RubCod;
                     AV42RubLinCod = A118RubLinCod;
                     AV56RubLinActivo = A1826RubLinDsc;
                     GXt_decimal3 = AV17ImpBal;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  AV12Mes,  "ACT",  "", out  GXt_decimal3) ;
                     AV17ImpBal = GXt_decimal3;
                     AV17ImpBal = NumberUtil.Round( AV17ImpBal/ (decimal)(AV49Cambio), 2);
                     AV68SdtBalanceActivoItem.gxTpr_Baltipo = 1;
                     AV68SdtBalanceActivoItem.gxTpr_Balrubcod = (int)(AV65IRub);
                     AV68SdtBalanceActivoItem.gxTpr_Ballincod = (int)(AV67TLin);
                     AV68SdtBalanceActivoItem.gxTpr_Balconceptoactivo = AV56RubLinActivo;
                     AV68SdtBalanceActivoItem.gxTpr_Balimporteactivo = AV17ImpBal;
                     AV69SdtBalanceActivo.Add(AV68SdtBalanceActivoItem, 0);
                     AV68SdtBalanceActivoItem = new SdtSdtBalance_SdtCuentaItem(context);
                     AV25ImpRub = (decimal)(AV25ImpRub+AV17ImpBal);
                     AV67TLin = (long)(AV67TLin+1);
                     pr_default.readNext(3);
                  }
                  pr_default.close(3);
                  AV68SdtBalanceActivoItem.gxTpr_Baltipo = 1;
                  AV68SdtBalanceActivoItem.gxTpr_Balrubcod = (int)(AV65IRub);
                  AV68SdtBalanceActivoItem.gxTpr_Baltrubros = AV61RubDscTot;
                  AV68SdtBalanceActivoItem.gxTpr_Balimporteactivo = AV25ImpRub;
                  AV69SdtBalanceActivo.Add(AV68SdtBalanceActivoItem, 0);
                  AV68SdtBalanceActivoItem = new SdtSdtBalance_SdtCuentaItem(context);
                  AV27ImpTot = (decimal)(AV27ImpTot+AV25ImpRub);
                  AV65IRub = (long)(AV65IRub+1);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               AV68SdtBalanceActivoItem.gxTpr_Baltipo = 1;
               AV68SdtBalanceActivoItem.gxTpr_Balttotales = AV62TotDscTot;
               AV68SdtBalanceActivoItem.gxTpr_Balimporteactivo = AV27ImpTot;
               AV69SdtBalanceActivo.Add(AV68SdtBalanceActivoItem, 0);
               AV68SdtBalanceActivoItem = new SdtSdtBalance_SdtCuentaItem(context);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Using cursor P00D56 */
            pr_default.execute(4, new Object[] {AV8TotTipo});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A115TotRub = P00D56_A115TotRub[0];
               A114TotTipo = P00D56_A114TotTipo[0];
               A1928TotDsc = P00D56_A1928TotDsc[0];
               A1929TotDscTot = P00D56_A1929TotDscTot[0];
               A120TotOrd = P00D56_A120TotOrd[0];
               AV9TotRub = A115TotRub;
               AV52cActivo = A1928TotDsc;
               AV62TotDscTot = A1929TotDscTot;
               AV70SdtBalancePasivoItem.gxTpr_Baltipo = 1;
               AV70SdtBalancePasivoItem.gxTpr_Baltotales = AV52cActivo;
               AV71SdtBalancePasivo.Add(AV70SdtBalancePasivoItem, 0);
               AV70SdtBalancePasivoItem = new SdtSdtBalance_SdtCuentaItem(context);
               AV65IRub = 1;
               /* Using cursor P00D57 */
               pr_default.execute(5, new Object[] {AV8TotTipo, AV9TotRub});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A115TotRub = P00D57_A115TotRub[0];
                  A114TotTipo = P00D57_A114TotTipo[0];
                  A1829RubSts = P00D57_A1829RubSts[0];
                  A116RubCod = P00D57_A116RubCod[0];
                  A1822RubDsc = P00D57_A1822RubDsc[0];
                  A1823RubDscTot = P00D57_A1823RubDscTot[0];
                  A117RubOrd = P00D57_A117RubOrd[0];
                  AV10RubCod = A116RubCod;
                  AV54RubActivo = A1822RubDsc;
                  AV61RubDscTot = A1823RubDscTot;
                  AV25ImpRub = 0.00m;
                  AV26ImpRubSal = 0.00m;
                  AV70SdtBalancePasivoItem.gxTpr_Baltipo = 1;
                  AV70SdtBalancePasivoItem.gxTpr_Balrubcod = (int)(AV65IRub);
                  AV70SdtBalancePasivoItem.gxTpr_Balrubros = AV54RubActivo;
                  AV71SdtBalancePasivo.Add(AV70SdtBalancePasivoItem, 0);
                  AV70SdtBalancePasivoItem = new SdtSdtBalance_SdtCuentaItem(context);
                  AV67TLin = 1;
                  /* Using cursor P00D58 */
                  pr_default.execute(6, new Object[] {AV8TotTipo, AV9TotRub, AV10RubCod});
                  while ( (pr_default.getStatus(6) != 101) )
                  {
                     A116RubCod = P00D58_A116RubCod[0];
                     A115TotRub = P00D58_A115TotRub[0];
                     A114TotTipo = P00D58_A114TotTipo[0];
                     A118RubLinCod = P00D58_A118RubLinCod[0];
                     A1826RubLinDsc = P00D58_A1826RubLinDsc[0];
                     A119RubLinOrd = P00D58_A119RubLinOrd[0];
                     AV8TotTipo = A114TotTipo;
                     AV9TotRub = A115TotRub;
                     AV10RubCod = A116RubCod;
                     AV42RubLinCod = A118RubLinCod;
                     AV56RubLinActivo = A1826RubLinDsc;
                     GXt_decimal3 = AV18ImpBalAnt;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  AV12Mes,  "ACT",  "", out  GXt_decimal3) ;
                     AV18ImpBalAnt = GXt_decimal3;
                     AV18ImpBalAnt = NumberUtil.Round( AV18ImpBalAnt/ (decimal)(AV49Cambio), 2);
                     AV70SdtBalancePasivoItem.gxTpr_Baltipo = 1;
                     AV70SdtBalancePasivoItem.gxTpr_Balrubcod = (int)(AV65IRub);
                     AV70SdtBalancePasivoItem.gxTpr_Ballincod = (int)(AV67TLin);
                     AV70SdtBalancePasivoItem.gxTpr_Balconceptoactivo = AV56RubLinActivo;
                     AV70SdtBalancePasivoItem.gxTpr_Balimporteactivo = AV18ImpBalAnt;
                     AV71SdtBalancePasivo.Add(AV70SdtBalancePasivoItem, 0);
                     AV70SdtBalancePasivoItem = new SdtSdtBalance_SdtCuentaItem(context);
                     AV25ImpRub = (decimal)(AV25ImpRub+AV18ImpBalAnt);
                     AV67TLin = (long)(AV67TLin+1);
                     pr_default.readNext(6);
                  }
                  pr_default.close(6);
                  AV70SdtBalancePasivoItem.gxTpr_Baltipo = 1;
                  AV70SdtBalancePasivoItem.gxTpr_Balrubcod = (int)(AV65IRub);
                  AV70SdtBalancePasivoItem.gxTpr_Baltrubros = AV61RubDscTot;
                  AV70SdtBalancePasivoItem.gxTpr_Balimporteactivo = AV25ImpRub;
                  AV71SdtBalancePasivo.Add(AV70SdtBalancePasivoItem, 0);
                  AV70SdtBalancePasivoItem = new SdtSdtBalance_SdtCuentaItem(context);
                  AV28ImpTotSal = (decimal)(AV28ImpTotSal+AV25ImpRub);
                  AV65IRub = (long)(AV65IRub+1);
                  pr_default.readNext(5);
               }
               pr_default.close(5);
               AV70SdtBalancePasivoItem.gxTpr_Baltipo = 1;
               AV70SdtBalancePasivoItem.gxTpr_Balttotales = AV62TotDscTot;
               AV70SdtBalancePasivoItem.gxTpr_Balimporteactivo = AV28ImpTotSal;
               AV71SdtBalancePasivo.Add(AV70SdtBalancePasivoItem, 0);
               AV70SdtBalancePasivoItem = new SdtSdtBalance_SdtCuentaItem(context);
               pr_default.readNext(4);
            }
            pr_default.close(4);
            AV51I = 1;
            while ( AV51I < 2 )
            {
               AV52cActivo = "";
               AV53cPasivo = "";
               AV83GXV1 = 1;
               while ( AV83GXV1 <= AV69SdtBalanceActivo.Count )
               {
                  AV68SdtBalanceActivoItem = ((SdtSdtBalance_SdtCuentaItem)AV69SdtBalanceActivo.Item(AV83GXV1));
                  if ( ( AV68SdtBalanceActivoItem.gxTpr_Baltipo == AV51I ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV68SdtBalanceActivoItem.gxTpr_Baltotales)) )
                  {
                     AV52cActivo = AV68SdtBalanceActivoItem.gxTpr_Baltotales;
                  }
                  AV83GXV1 = (int)(AV83GXV1+1);
               }
               AV84GXV2 = 1;
               while ( AV84GXV2 <= AV71SdtBalancePasivo.Count )
               {
                  AV70SdtBalancePasivoItem = ((SdtSdtBalance_SdtCuentaItem)AV71SdtBalancePasivo.Item(AV84GXV2));
                  if ( ( AV70SdtBalancePasivoItem.gxTpr_Baltipo == AV51I ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV70SdtBalancePasivoItem.gxTpr_Baltotales)) )
                  {
                     AV53cPasivo = AV70SdtBalancePasivoItem.gxTpr_Baltotales;
                  }
                  AV84GXV2 = (int)(AV84GXV2+1);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52cActivo)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV53cPasivo)) )
               {
                  HD50( false, 20) ;
                  getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52cActivo, "")), 16, Gx_line+2, 396, Gx_line+18, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53cPasivo, "")), 511, Gx_line+0, 891, Gx_line+16, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
               AV58II = 1;
               while ( AV58II < 10 )
               {
                  AV54RubActivo = "";
                  AV55RubPasivo = "";
                  AV85GXV3 = 1;
                  while ( AV85GXV3 <= AV69SdtBalanceActivo.Count )
                  {
                     AV68SdtBalanceActivoItem = ((SdtSdtBalance_SdtCuentaItem)AV69SdtBalanceActivo.Item(AV85GXV3));
                     if ( ( AV68SdtBalanceActivoItem.gxTpr_Baltipo == AV51I ) && ( AV68SdtBalanceActivoItem.gxTpr_Balrubcod == AV58II ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV68SdtBalanceActivoItem.gxTpr_Balrubros)) )
                     {
                        AV54RubActivo = AV68SdtBalanceActivoItem.gxTpr_Balrubros;
                     }
                     AV85GXV3 = (int)(AV85GXV3+1);
                  }
                  AV86GXV4 = 1;
                  while ( AV86GXV4 <= AV71SdtBalancePasivo.Count )
                  {
                     AV70SdtBalancePasivoItem = ((SdtSdtBalance_SdtCuentaItem)AV71SdtBalancePasivo.Item(AV86GXV4));
                     if ( ( AV70SdtBalancePasivoItem.gxTpr_Baltipo == AV51I ) && ( AV70SdtBalancePasivoItem.gxTpr_Balrubcod == AV58II ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV70SdtBalancePasivoItem.gxTpr_Balrubros)) )
                     {
                        AV55RubPasivo = AV70SdtBalancePasivoItem.gxTpr_Balrubros;
                     }
                     AV86GXV4 = (int)(AV86GXV4+1);
                  }
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54RubActivo)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV55RubPasivo)) )
                  {
                     HD50( false, 23) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54RubActivo, "")), 16, Gx_line+3, 396, Gx_line+19, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55RubPasivo, "")), 511, Gx_line+5, 891, Gx_line+21, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+23);
                  }
                  AV72III = 1;
                  while ( AV72III < 20 )
                  {
                     AV56RubLinActivo = "";
                     AV57RubLinPasivo = "";
                     AV17ImpBal = 0.00m;
                     AV18ImpBalAnt = 0.00m;
                     AV87GXV5 = 1;
                     while ( AV87GXV5 <= AV69SdtBalanceActivo.Count )
                     {
                        AV68SdtBalanceActivoItem = ((SdtSdtBalance_SdtCuentaItem)AV69SdtBalanceActivo.Item(AV87GXV5));
                        if ( ( AV68SdtBalanceActivoItem.gxTpr_Baltipo == AV51I ) && ( AV68SdtBalanceActivoItem.gxTpr_Balrubcod == AV58II ) && ( AV68SdtBalanceActivoItem.gxTpr_Ballincod == AV72III ) )
                        {
                           AV56RubLinActivo = AV68SdtBalanceActivoItem.gxTpr_Balconceptoactivo;
                           AV17ImpBal = AV68SdtBalanceActivoItem.gxTpr_Balimporteactivo;
                        }
                        AV87GXV5 = (int)(AV87GXV5+1);
                     }
                     AV88GXV6 = 1;
                     while ( AV88GXV6 <= AV71SdtBalancePasivo.Count )
                     {
                        AV70SdtBalancePasivoItem = ((SdtSdtBalance_SdtCuentaItem)AV71SdtBalancePasivo.Item(AV88GXV6));
                        if ( ( AV70SdtBalancePasivoItem.gxTpr_Baltipo == AV51I ) && ( AV70SdtBalancePasivoItem.gxTpr_Balrubcod == AV58II ) && ( AV70SdtBalancePasivoItem.gxTpr_Ballincod == AV72III ) )
                        {
                           AV57RubLinPasivo = AV70SdtBalancePasivoItem.gxTpr_Balconceptoactivo;
                           AV18ImpBalAnt = AV70SdtBalancePasivoItem.gxTpr_Balimporteactivo;
                        }
                        AV88GXV6 = (int)(AV88GXV6+1);
                     }
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56RubLinActivo)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV57RubLinPasivo)) )
                     {
                        HD50( false, 17) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56RubLinActivo, "")), 16, Gx_line+0, 370, Gx_line+16, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17ImpBal, "ZZZZZZ,ZZZ,ZZ9.99")), 338, Gx_line+1, 445, Gx_line+16, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18ImpBalAnt, "ZZZZZZ,ZZZ,ZZ9.99")), 905, Gx_line+0, 1012, Gx_line+15, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57RubLinPasivo, "")), 519, Gx_line+0, 873, Gx_line+16, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+17);
                     }
                     AV72III = (long)(AV72III+1);
                  }
                  AV61RubDscTot = "";
                  AV64RubDscTotP = "";
                  AV25ImpRub = 0.00m;
                  AV26ImpRubSal = 0.00m;
                  AV89GXV7 = 1;
                  while ( AV89GXV7 <= AV69SdtBalanceActivo.Count )
                  {
                     AV68SdtBalanceActivoItem = ((SdtSdtBalance_SdtCuentaItem)AV69SdtBalanceActivo.Item(AV89GXV7));
                     if ( ( AV68SdtBalanceActivoItem.gxTpr_Baltipo == AV51I ) && ( AV68SdtBalanceActivoItem.gxTpr_Balrubcod == AV58II ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV68SdtBalanceActivoItem.gxTpr_Baltrubros)) )
                     {
                        AV61RubDscTot = AV68SdtBalanceActivoItem.gxTpr_Baltrubros;
                        AV25ImpRub = AV68SdtBalanceActivoItem.gxTpr_Balimporteactivo;
                     }
                     AV89GXV7 = (int)(AV89GXV7+1);
                  }
                  AV90GXV8 = 1;
                  while ( AV90GXV8 <= AV71SdtBalancePasivo.Count )
                  {
                     AV70SdtBalancePasivoItem = ((SdtSdtBalance_SdtCuentaItem)AV71SdtBalancePasivo.Item(AV90GXV8));
                     if ( ( AV70SdtBalancePasivoItem.gxTpr_Baltipo == AV51I ) && ( AV70SdtBalancePasivoItem.gxTpr_Balrubcod == AV58II ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV70SdtBalancePasivoItem.gxTpr_Baltrubros)) )
                     {
                        AV64RubDscTotP = AV70SdtBalancePasivoItem.gxTpr_Baltrubros;
                        AV26ImpRubSal = AV70SdtBalancePasivoItem.gxTpr_Balimporteactivo;
                     }
                     AV90GXV8 = (int)(AV90GXV8+1);
                  }
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61RubDscTot)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV64RubDscTotP)) )
                  {
                     HD50( false, 25) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61RubDscTot, "")), 16, Gx_line+7, 315, Gx_line+23, 2, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV25ImpRub, "ZZZZZZ,ZZZ,ZZ9.99")), 338, Gx_line+8, 445, Gx_line+23, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV26ImpRubSal, "ZZZZZZ,ZZZ,ZZ9.99")), 905, Gx_line+8, 1012, Gx_line+23, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawLine(326, Gx_line+4, 476, Gx_line+4, 1, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64RubDscTotP, "")), 558, Gx_line+7, 857, Gx_line+23, 2, 0, 0, 0) ;
                     getPrinter().GxDrawLine(883, Gx_line+4, 1033, Gx_line+4, 1, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+25);
                  }
                  AV58II = (long)(AV58II+1);
               }
               AV62TotDscTot = "";
               AV63TotDsctTotP = "";
               AV27ImpTot = 0.00m;
               AV28ImpTotSal = 0.00m;
               AV91GXV9 = 1;
               while ( AV91GXV9 <= AV69SdtBalanceActivo.Count )
               {
                  AV68SdtBalanceActivoItem = ((SdtSdtBalance_SdtCuentaItem)AV69SdtBalanceActivo.Item(AV91GXV9));
                  if ( ( AV68SdtBalanceActivoItem.gxTpr_Baltipo == AV51I ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV68SdtBalanceActivoItem.gxTpr_Balttotales)) )
                  {
                     AV62TotDscTot = AV68SdtBalanceActivoItem.gxTpr_Balttotales;
                     AV27ImpTot = AV68SdtBalanceActivoItem.gxTpr_Balimporteactivo;
                  }
                  AV91GXV9 = (int)(AV91GXV9+1);
               }
               AV92GXV10 = 1;
               while ( AV92GXV10 <= AV71SdtBalancePasivo.Count )
               {
                  AV70SdtBalancePasivoItem = ((SdtSdtBalance_SdtCuentaItem)AV71SdtBalancePasivo.Item(AV92GXV10));
                  if ( ( AV70SdtBalancePasivoItem.gxTpr_Baltipo == AV51I ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV70SdtBalancePasivoItem.gxTpr_Balttotales)) )
                  {
                     AV63TotDsctTotP = AV70SdtBalancePasivoItem.gxTpr_Balttotales;
                     AV28ImpTotSal = AV70SdtBalancePasivoItem.gxTpr_Balimporteactivo;
                  }
                  AV92GXV10 = (int)(AV92GXV10+1);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TotDscTot)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TotDsctTotP)) )
               {
                  HD50( false, 30) ;
                  getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62TotDscTot, "")), 16, Gx_line+9, 275, Gx_line+25, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28ImpTotSal, "ZZZZZZ,ZZZ,ZZ9.99")), 905, Gx_line+11, 1012, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27ImpTot, "ZZZZZZ,ZZZ,ZZ9.99")), 338, Gx_line+11, 445, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(326, Gx_line+4, 476, Gx_line+4, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63TotDsctTotP, "")), 545, Gx_line+9, 804, Gx_line+25, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(883, Gx_line+4, 1033, Gx_line+4, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               AV51I = (short)(AV51I+1);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HD50( true, 0) ;
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

      protected void HD50( bool bFoot ,
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 350, Gx_line+10, 806, Gx_line+35, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Titulo2, "")), 350, Gx_line+35, 806, Gx_line+60, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+93, 1072, Gx_line+116, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción", 120, Gx_line+96, 189, Gx_line+110, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Acumulado", 372, Gx_line+96, 439, Gx_line+110, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Acumulado", 917, Gx_line+96, 984, Gx_line+110, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Empresa, "")), 14, Gx_line+52, 384, Gx_line+70, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35EmpRUC, "")), 14, Gx_line+70, 385, Gx_line+88, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 350, Gx_line+60, 806, Gx_line+85, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+116);
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
         AV75Logo_GXI = "";
         AV8TotTipo = "";
         AV13Titulo = "";
         AV50Titulo2 = "";
         scmdbuf = "";
         P00D52_A180MonCod = new int[1] ;
         P00D52_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV29cMes = "";
         AV30FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV15Fecha = DateTime.MinValue;
         GXt_date2 = DateTime.MinValue;
         GXt_char1 = "";
         AV14Periodo = "";
         P00D53_A115TotRub = new int[1] ;
         P00D53_A114TotTipo = new string[] {""} ;
         P00D53_A1928TotDsc = new string[] {""} ;
         P00D53_A1929TotDscTot = new string[] {""} ;
         P00D53_A120TotOrd = new short[1] ;
         A114TotTipo = "";
         A1928TotDsc = "";
         A1929TotDscTot = "";
         AV52cActivo = "";
         AV62TotDscTot = "";
         AV68SdtBalanceActivoItem = new SdtSdtBalance_SdtCuentaItem(context);
         AV69SdtBalanceActivo = new GXBaseCollection<SdtSdtBalance_SdtCuentaItem>( context, "SdtCuentaItem", "SIGERP_ADVANCED");
         P00D54_A115TotRub = new int[1] ;
         P00D54_A114TotTipo = new string[] {""} ;
         P00D54_A1829RubSts = new short[1] ;
         P00D54_A116RubCod = new int[1] ;
         P00D54_A1822RubDsc = new string[] {""} ;
         P00D54_A1823RubDscTot = new string[] {""} ;
         P00D54_A117RubOrd = new short[1] ;
         A1822RubDsc = "";
         A1823RubDscTot = "";
         AV54RubActivo = "";
         AV61RubDscTot = "";
         P00D55_A116RubCod = new int[1] ;
         P00D55_A115TotRub = new int[1] ;
         P00D55_A114TotTipo = new string[] {""} ;
         P00D55_A118RubLinCod = new int[1] ;
         P00D55_A1826RubLinDsc = new string[] {""} ;
         P00D55_A119RubLinOrd = new short[1] ;
         A1826RubLinDsc = "";
         AV56RubLinActivo = "";
         P00D56_A115TotRub = new int[1] ;
         P00D56_A114TotTipo = new string[] {""} ;
         P00D56_A1928TotDsc = new string[] {""} ;
         P00D56_A1929TotDscTot = new string[] {""} ;
         P00D56_A120TotOrd = new short[1] ;
         AV70SdtBalancePasivoItem = new SdtSdtBalance_SdtCuentaItem(context);
         AV71SdtBalancePasivo = new GXBaseCollection<SdtSdtBalance_SdtCuentaItem>( context, "SdtCuentaItem", "SIGERP_ADVANCED");
         P00D57_A115TotRub = new int[1] ;
         P00D57_A114TotTipo = new string[] {""} ;
         P00D57_A1829RubSts = new short[1] ;
         P00D57_A116RubCod = new int[1] ;
         P00D57_A1822RubDsc = new string[] {""} ;
         P00D57_A1823RubDscTot = new string[] {""} ;
         P00D57_A117RubOrd = new short[1] ;
         P00D58_A116RubCod = new int[1] ;
         P00D58_A115TotRub = new int[1] ;
         P00D58_A114TotTipo = new string[] {""} ;
         P00D58_A118RubLinCod = new int[1] ;
         P00D58_A1826RubLinDsc = new string[] {""} ;
         P00D58_A119RubLinOrd = new short[1] ;
         AV53cPasivo = "";
         AV55RubPasivo = "";
         AV57RubLinPasivo = "";
         AV64RubDscTotP = "";
         AV63TotDsctTotP = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_balancegeneralhorizontalpdf__default(),
            new Object[][] {
                new Object[] {
               P00D52_A180MonCod, P00D52_A1234MonDsc
               }
               , new Object[] {
               P00D53_A115TotRub, P00D53_A114TotTipo, P00D53_A1928TotDsc, P00D53_A1929TotDscTot, P00D53_A120TotOrd
               }
               , new Object[] {
               P00D54_A115TotRub, P00D54_A114TotTipo, P00D54_A1829RubSts, P00D54_A116RubCod, P00D54_A1822RubDsc, P00D54_A1823RubDscTot, P00D54_A117RubOrd
               }
               , new Object[] {
               P00D55_A116RubCod, P00D55_A115TotRub, P00D55_A114TotTipo, P00D55_A118RubLinCod, P00D55_A1826RubLinDsc, P00D55_A119RubLinOrd
               }
               , new Object[] {
               P00D56_A115TotRub, P00D56_A114TotTipo, P00D56_A1928TotDsc, P00D56_A1929TotDscTot, P00D56_A120TotOrd
               }
               , new Object[] {
               P00D57_A115TotRub, P00D57_A114TotTipo, P00D57_A1829RubSts, P00D57_A116RubCod, P00D57_A1822RubDsc, P00D57_A1823RubDscTot, P00D57_A117RubOrd
               }
               , new Object[] {
               P00D58_A116RubCod, P00D58_A115TotRub, P00D58_A114TotTipo, P00D58_A118RubLinCod, P00D58_A1826RubLinDsc, P00D58_A119RubLinOrd
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
      private short AV12Mes ;
      private short AV19AnoAnt ;
      private short AV20MesAnt ;
      private short A120TotOrd ;
      private short A1829RubSts ;
      private short A117RubOrd ;
      private short A119RubLinOrd ;
      private short AV51I ;
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
      private int A118RubLinCod ;
      private int AV42RubLinCod ;
      private int AV83GXV1 ;
      private int AV84GXV2 ;
      private int Gx_OldLine ;
      private int AV85GXV3 ;
      private int AV86GXV4 ;
      private int AV87GXV5 ;
      private int AV88GXV6 ;
      private int AV89GXV7 ;
      private int AV90GXV8 ;
      private int AV91GXV9 ;
      private int AV92GXV10 ;
      private long AV65IRub ;
      private long AV67TLin ;
      private long AV58II ;
      private long AV72III ;
      private decimal AV49Cambio ;
      private decimal AV25ImpRub ;
      private decimal AV26ImpRubSal ;
      private decimal AV17ImpBal ;
      private decimal AV27ImpTot ;
      private decimal AV18ImpBalAnt ;
      private decimal GXt_decimal3 ;
      private decimal AV28ImpTotSal ;
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
      private string AV29cMes ;
      private string AV30FechaC ;
      private string GXt_char1 ;
      private string AV14Periodo ;
      private string A114TotTipo ;
      private string A1928TotDsc ;
      private string A1929TotDscTot ;
      private string AV52cActivo ;
      private string AV62TotDscTot ;
      private string A1822RubDsc ;
      private string A1823RubDscTot ;
      private string AV54RubActivo ;
      private string AV61RubDscTot ;
      private string A1826RubLinDsc ;
      private string AV56RubLinActivo ;
      private string AV53cPasivo ;
      private string AV55RubPasivo ;
      private string AV57RubLinPasivo ;
      private string AV64RubDscTotP ;
      private string AV63TotDsctTotP ;
      private DateTime AV16FechaD ;
      private DateTime AV15Fecha ;
      private DateTime GXt_date2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string AV75Logo_GXI ;
      private string AV37Logo ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_Tipo ;
      private int aP3_Moneda ;
      private IDataStoreProvider pr_default ;
      private int[] P00D52_A180MonCod ;
      private string[] P00D52_A1234MonDsc ;
      private int[] P00D53_A115TotRub ;
      private string[] P00D53_A114TotTipo ;
      private string[] P00D53_A1928TotDsc ;
      private string[] P00D53_A1929TotDscTot ;
      private short[] P00D53_A120TotOrd ;
      private int[] P00D54_A115TotRub ;
      private string[] P00D54_A114TotTipo ;
      private short[] P00D54_A1829RubSts ;
      private int[] P00D54_A116RubCod ;
      private string[] P00D54_A1822RubDsc ;
      private string[] P00D54_A1823RubDscTot ;
      private short[] P00D54_A117RubOrd ;
      private int[] P00D55_A116RubCod ;
      private int[] P00D55_A115TotRub ;
      private string[] P00D55_A114TotTipo ;
      private int[] P00D55_A118RubLinCod ;
      private string[] P00D55_A1826RubLinDsc ;
      private short[] P00D55_A119RubLinOrd ;
      private int[] P00D56_A115TotRub ;
      private string[] P00D56_A114TotTipo ;
      private string[] P00D56_A1928TotDsc ;
      private string[] P00D56_A1929TotDscTot ;
      private short[] P00D56_A120TotOrd ;
      private int[] P00D57_A115TotRub ;
      private string[] P00D57_A114TotTipo ;
      private short[] P00D57_A1829RubSts ;
      private int[] P00D57_A116RubCod ;
      private string[] P00D57_A1822RubDsc ;
      private string[] P00D57_A1823RubDscTot ;
      private short[] P00D57_A117RubOrd ;
      private int[] P00D58_A116RubCod ;
      private int[] P00D58_A115TotRub ;
      private string[] P00D58_A114TotTipo ;
      private int[] P00D58_A118RubLinCod ;
      private string[] P00D58_A1826RubLinDsc ;
      private short[] P00D58_A119RubLinOrd ;
      private GXBaseCollection<SdtSdtBalance_SdtCuentaItem> AV69SdtBalanceActivo ;
      private GXBaseCollection<SdtSdtBalance_SdtCuentaItem> AV71SdtBalancePasivo ;
      private SdtSdtBalance_SdtCuentaItem AV68SdtBalanceActivoItem ;
      private SdtSdtBalance_SdtCuentaItem AV70SdtBalancePasivoItem ;
   }

   public class r_balancegeneralhorizontalpdf__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00D52;
          prmP00D52 = new Object[] {
          new ParDef("@AV48Moneda",GXType.Int32,6,0)
          };
          Object[] prmP00D53;
          prmP00D53 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0)
          };
          Object[] prmP00D54;
          prmP00D54 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0)
          };
          Object[] prmP00D55;
          prmP00D55 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV10RubCod",GXType.Int32,6,0)
          };
          Object[] prmP00D56;
          prmP00D56 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0)
          };
          Object[] prmP00D57;
          prmP00D57 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0)
          };
          Object[] prmP00D58;
          prmP00D58 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV10RubCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D52", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV48Moneda ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D52,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00D53", "SELECT [TotRub], [TotTipo], [TotDsc], [TotDscTot], [TotOrd] FROM [CBRUBROST] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = 1) ORDER BY [TotOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D53,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D54", "SELECT [TotRub], [TotTipo], [RubSts], [RubCod], [RubDsc], [RubDscTot], [RubOrd] FROM [CBRUBROS] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) ORDER BY [RubOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D54,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D55", "SELECT [RubCod], [TotRub], [TotTipo], [RubLinCod], [RubLinDsc], [RubLinOrd] FROM [CBRUBROSL] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) AND ([RubCod] = @AV10RubCod) ORDER BY [RubLinOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D55,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D56", "SELECT [TotRub], [TotTipo], [TotDsc], [TotDscTot], [TotOrd] FROM [CBRUBROST] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = 2) ORDER BY [TotOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D56,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D57", "SELECT [TotRub], [TotTipo], [RubSts], [RubCod], [RubDsc], [RubDscTot], [RubOrd] FROM [CBRUBROS] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) ORDER BY [RubOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D57,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D58", "SELECT [RubCod], [TotRub], [TotTipo], [RubLinCod], [RubLinDsc], [RubLinOrd] FROM [CBRUBROSL] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) AND ([RubCod] = @AV10RubCod) ORDER BY [RubLinOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D58,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 6 :
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
