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
   public class rrlibro3_1 : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.rrlibro3_1.aspx")), "contabilidad.rrlibro3_1.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.rrlibro3_1.aspx")))) ;
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

      public rrlibro3_1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrlibro3_1( IGxContext context )
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
         rrlibro3_1 objrrlibro3_1;
         objrrlibro3_1 = new rrlibro3_1();
         objrrlibro3_1.AV11Ano = aP0_Ano;
         objrrlibro3_1.AV12Mes = aP1_Mes;
         objrrlibro3_1.AV38Tipo = aP2_Tipo;
         objrrlibro3_1.AV48Moneda = aP3_Moneda;
         objrrlibro3_1.context.SetSubmitInitialConfig(context);
         objrrlibro3_1.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrlibro3_1);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_Tipo=this.AV38Tipo;
         aP3_Moneda=this.AV48Moneda;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrlibro3_1)stateInfo).executePrivate();
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
            AV30FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV30FechaC, 2);
            GXt_char1 = AV29cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV29cMes = GXt_char1;
            AV13Titulo = "FORMATO 3.1: LIBRO DE INVENTARIOS Y BALANCES - ESTADO DE SITUACIÓN FINANCIERA";
            AV14Periodo = StringUtil.Upper( AV29cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            /* Using cursor P00CM2 */
            pr_default.execute(0, new Object[] {AV48Moneda});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P00CM2_A180MonCod[0];
               A1234MonDsc = P00CM2_A1234MonDsc[0];
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
            AV8TotTipo = "BAL";
            if ( AV48Moneda == 1 )
            {
               AV49Cambio = (decimal)(1);
            }
            AV19AnoAnt = AV11Ano;
            AV20MesAnt = (short)(AV12Mes-1);
            /* Using cursor P00CM3 */
            pr_default.execute(1, new Object[] {AV8TotTipo});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A115TotRub = P00CM3_A115TotRub[0];
               A114TotTipo = P00CM3_A114TotTipo[0];
               A1928TotDsc = P00CM3_A1928TotDsc[0];
               A1929TotDscTot = P00CM3_A1929TotDscTot[0];
               A120TotOrd = P00CM3_A120TotOrd[0];
               AV9TotRub = A115TotRub;
               AV52cActivo = A1928TotDsc;
               AV62TotDscTot = A1929TotDscTot;
               AV68SdtBalanceActivoItem.gxTpr_Baltipo = 1;
               AV68SdtBalanceActivoItem.gxTpr_Baltotales = AV52cActivo;
               AV69SdtBalanceActivo.Add(AV68SdtBalanceActivoItem, 0);
               AV68SdtBalanceActivoItem = new SdtSdtBalance_SdtCuentaItem(context);
               AV65IRub = 1;
               /* Using cursor P00CM4 */
               pr_default.execute(2, new Object[] {AV8TotTipo, AV9TotRub});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A115TotRub = P00CM4_A115TotRub[0];
                  A114TotTipo = P00CM4_A114TotTipo[0];
                  A1829RubSts = P00CM4_A1829RubSts[0];
                  A116RubCod = P00CM4_A116RubCod[0];
                  A1822RubDsc = P00CM4_A1822RubDsc[0];
                  A1823RubDscTot = P00CM4_A1823RubDscTot[0];
                  A117RubOrd = P00CM4_A117RubOrd[0];
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
                  /* Using cursor P00CM5 */
                  pr_default.execute(3, new Object[] {AV8TotTipo, AV9TotRub, AV10RubCod});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A116RubCod = P00CM5_A116RubCod[0];
                     A115TotRub = P00CM5_A115TotRub[0];
                     A114TotTipo = P00CM5_A114TotTipo[0];
                     A118RubLinCod = P00CM5_A118RubLinCod[0];
                     A1826RubLinDsc = P00CM5_A1826RubLinDsc[0];
                     A119RubLinOrd = P00CM5_A119RubLinOrd[0];
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
            /* Using cursor P00CM6 */
            pr_default.execute(4, new Object[] {AV8TotTipo});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A115TotRub = P00CM6_A115TotRub[0];
               A114TotTipo = P00CM6_A114TotTipo[0];
               A1928TotDsc = P00CM6_A1928TotDsc[0];
               A1929TotDscTot = P00CM6_A1929TotDscTot[0];
               A120TotOrd = P00CM6_A120TotOrd[0];
               AV9TotRub = A115TotRub;
               AV52cActivo = A1928TotDsc;
               AV62TotDscTot = A1929TotDscTot;
               AV70SdtBalancePasivoItem.gxTpr_Baltipo = 1;
               AV70SdtBalancePasivoItem.gxTpr_Baltotales = AV52cActivo;
               AV71SdtBalancePasivo.Add(AV70SdtBalancePasivoItem, 0);
               AV70SdtBalancePasivoItem = new SdtSdtBalance_SdtCuentaItem(context);
               AV65IRub = 1;
               /* Using cursor P00CM7 */
               pr_default.execute(5, new Object[] {AV8TotTipo, AV9TotRub});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A115TotRub = P00CM7_A115TotRub[0];
                  A114TotTipo = P00CM7_A114TotTipo[0];
                  A1829RubSts = P00CM7_A1829RubSts[0];
                  A116RubCod = P00CM7_A116RubCod[0];
                  A1822RubDsc = P00CM7_A1822RubDsc[0];
                  A1823RubDscTot = P00CM7_A1823RubDscTot[0];
                  A117RubOrd = P00CM7_A117RubOrd[0];
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
                  /* Using cursor P00CM8 */
                  pr_default.execute(6, new Object[] {AV8TotTipo, AV9TotRub, AV10RubCod});
                  while ( (pr_default.getStatus(6) != 101) )
                  {
                     A116RubCod = P00CM8_A116RubCod[0];
                     A115TotRub = P00CM8_A115TotRub[0];
                     A114TotTipo = P00CM8_A114TotTipo[0];
                     A118RubLinCod = P00CM8_A118RubLinCod[0];
                     A1826RubLinDsc = P00CM8_A1826RubLinDsc[0];
                     A119RubLinOrd = P00CM8_A119RubLinOrd[0];
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
                  HCM0( false, 20) ;
                  getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52cActivo, "")), 16, Gx_line+2, 396, Gx_line+18, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53cPasivo, "")), 497, Gx_line+0, 877, Gx_line+16, 0, 0, 0, 0) ;
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
                     HCM0( false, 23) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54RubActivo, "")), 16, Gx_line+3, 396, Gx_line+19, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55RubPasivo, "")), 497, Gx_line+5, 877, Gx_line+21, 0, 0, 0, 0) ;
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
                        HCM0( false, 17) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56RubLinActivo, "")), 16, Gx_line+0, 370, Gx_line+16, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17ImpBal, "ZZZZZZ,ZZZ,ZZ9.99")), 348, Gx_line+1, 455, Gx_line+16, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18ImpBalAnt, "ZZZZZZ,ZZZ,ZZ9.99")), 836, Gx_line+0, 943, Gx_line+15, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57RubLinPasivo, "")), 504, Gx_line+0, 847, Gx_line+16, 0, 0, 0, 0) ;
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
                     HCM0( false, 25) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61RubDscTot, "")), 16, Gx_line+7, 315, Gx_line+23, 2, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV25ImpRub, "ZZZZZZ,ZZZ,ZZ9.99")), 348, Gx_line+8, 455, Gx_line+23, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV26ImpRubSal, "ZZZZZZ,ZZZ,ZZ9.99")), 836, Gx_line+8, 943, Gx_line+23, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawLine(326, Gx_line+4, 476, Gx_line+4, 1, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64RubDscTotP, "")), 504, Gx_line+7, 803, Gx_line+23, 2, 0, 0, 0) ;
                     getPrinter().GxDrawLine(815, Gx_line+4, 965, Gx_line+4, 1, 0, 0, 0, 0) ;
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
                  HCM0( false, 35) ;
                  getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62TotDscTot, "")), 16, Gx_line+11, 275, Gx_line+27, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28ImpTotSal, "ZZZZZZ,ZZZ,ZZ9.99")), 836, Gx_line+14, 943, Gx_line+29, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27ImpTot, "ZZZZZZ,ZZZ,ZZ9.99")), 348, Gx_line+14, 455, Gx_line+29, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(326, Gx_line+6, 476, Gx_line+6, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63TotDsctTotP, "")), 503, Gx_line+11, 762, Gx_line+27, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(815, Gx_line+6, 965, Gx_line+6, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+35);
               }
               AV51I = (short)(AV51I+1);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HCM0( true, 0) ;
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

      protected void HCM0( bool bFoot ,
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
               getPrinter().GxDrawRect(0, Gx_line+91, 480, Gx_line+120, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("EJERCICIO O", 372, Gx_line+92, 445, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 11, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 8, Gx_line+7, 447, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 70, Gx_line+32, 592, Gx_line+47, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Empresa, "")), 7, Gx_line+68, 412, Gx_line+85, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35EmpRUC, "")), 70, Gx_line+50, 175, Gx_line+65, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 7, Gx_line+32, 63, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 7, Gx_line+50, 38, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("PERIODO", 382, Gx_line+105, 435, Gx_line+119, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(492, Gx_line+91, 972, Gx_line+120, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("EJERCICIO O", 864, Gx_line+92, 937, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("PERIODO", 874, Gx_line+105, 927, Gx_line+119, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+120);
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
         AV30FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV29cMes = "";
         AV13Titulo = "";
         AV14Periodo = "";
         scmdbuf = "";
         P00CM2_A180MonCod = new int[1] ;
         P00CM2_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV50Titulo2 = "";
         AV15Fecha = DateTime.MinValue;
         GXt_date2 = DateTime.MinValue;
         GXt_char1 = "";
         AV8TotTipo = "";
         P00CM3_A115TotRub = new int[1] ;
         P00CM3_A114TotTipo = new string[] {""} ;
         P00CM3_A1928TotDsc = new string[] {""} ;
         P00CM3_A1929TotDscTot = new string[] {""} ;
         P00CM3_A120TotOrd = new short[1] ;
         A114TotTipo = "";
         A1928TotDsc = "";
         A1929TotDscTot = "";
         AV52cActivo = "";
         AV62TotDscTot = "";
         AV68SdtBalanceActivoItem = new SdtSdtBalance_SdtCuentaItem(context);
         AV69SdtBalanceActivo = new GXBaseCollection<SdtSdtBalance_SdtCuentaItem>( context, "SdtCuentaItem", "SIGERP_ADVANCED");
         P00CM4_A115TotRub = new int[1] ;
         P00CM4_A114TotTipo = new string[] {""} ;
         P00CM4_A1829RubSts = new short[1] ;
         P00CM4_A116RubCod = new int[1] ;
         P00CM4_A1822RubDsc = new string[] {""} ;
         P00CM4_A1823RubDscTot = new string[] {""} ;
         P00CM4_A117RubOrd = new short[1] ;
         A1822RubDsc = "";
         A1823RubDscTot = "";
         AV54RubActivo = "";
         AV61RubDscTot = "";
         P00CM5_A116RubCod = new int[1] ;
         P00CM5_A115TotRub = new int[1] ;
         P00CM5_A114TotTipo = new string[] {""} ;
         P00CM5_A118RubLinCod = new int[1] ;
         P00CM5_A1826RubLinDsc = new string[] {""} ;
         P00CM5_A119RubLinOrd = new short[1] ;
         A1826RubLinDsc = "";
         AV56RubLinActivo = "";
         P00CM6_A115TotRub = new int[1] ;
         P00CM6_A114TotTipo = new string[] {""} ;
         P00CM6_A1928TotDsc = new string[] {""} ;
         P00CM6_A1929TotDscTot = new string[] {""} ;
         P00CM6_A120TotOrd = new short[1] ;
         AV70SdtBalancePasivoItem = new SdtSdtBalance_SdtCuentaItem(context);
         AV71SdtBalancePasivo = new GXBaseCollection<SdtSdtBalance_SdtCuentaItem>( context, "SdtCuentaItem", "SIGERP_ADVANCED");
         P00CM7_A115TotRub = new int[1] ;
         P00CM7_A114TotTipo = new string[] {""} ;
         P00CM7_A1829RubSts = new short[1] ;
         P00CM7_A116RubCod = new int[1] ;
         P00CM7_A1822RubDsc = new string[] {""} ;
         P00CM7_A1823RubDscTot = new string[] {""} ;
         P00CM7_A117RubOrd = new short[1] ;
         P00CM8_A116RubCod = new int[1] ;
         P00CM8_A115TotRub = new int[1] ;
         P00CM8_A114TotTipo = new string[] {""} ;
         P00CM8_A118RubLinCod = new int[1] ;
         P00CM8_A1826RubLinDsc = new string[] {""} ;
         P00CM8_A119RubLinOrd = new short[1] ;
         AV53cPasivo = "";
         AV55RubPasivo = "";
         AV57RubLinPasivo = "";
         AV64RubDscTotP = "";
         AV63TotDsctTotP = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rrlibro3_1__default(),
            new Object[][] {
                new Object[] {
               P00CM2_A180MonCod, P00CM2_A1234MonDsc
               }
               , new Object[] {
               P00CM3_A115TotRub, P00CM3_A114TotTipo, P00CM3_A1928TotDsc, P00CM3_A1929TotDscTot, P00CM3_A120TotOrd
               }
               , new Object[] {
               P00CM4_A115TotRub, P00CM4_A114TotTipo, P00CM4_A1829RubSts, P00CM4_A116RubCod, P00CM4_A1822RubDsc, P00CM4_A1823RubDscTot, P00CM4_A117RubOrd
               }
               , new Object[] {
               P00CM5_A116RubCod, P00CM5_A115TotRub, P00CM5_A114TotTipo, P00CM5_A118RubLinCod, P00CM5_A1826RubLinDsc, P00CM5_A119RubLinOrd
               }
               , new Object[] {
               P00CM6_A115TotRub, P00CM6_A114TotTipo, P00CM6_A1928TotDsc, P00CM6_A1929TotDscTot, P00CM6_A120TotOrd
               }
               , new Object[] {
               P00CM7_A115TotRub, P00CM7_A114TotTipo, P00CM7_A1829RubSts, P00CM7_A116RubCod, P00CM7_A1822RubDsc, P00CM7_A1823RubDscTot, P00CM7_A117RubOrd
               }
               , new Object[] {
               P00CM8_A116RubCod, P00CM8_A115TotRub, P00CM8_A114TotTipo, P00CM8_A118RubLinCod, P00CM8_A1826RubLinDsc, P00CM8_A119RubLinOrd
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
      private string AV30FechaC ;
      private string AV29cMes ;
      private string AV13Titulo ;
      private string AV14Periodo ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string AV50Titulo2 ;
      private string GXt_char1 ;
      private string AV8TotTipo ;
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
      private int[] P00CM2_A180MonCod ;
      private string[] P00CM2_A1234MonDsc ;
      private int[] P00CM3_A115TotRub ;
      private string[] P00CM3_A114TotTipo ;
      private string[] P00CM3_A1928TotDsc ;
      private string[] P00CM3_A1929TotDscTot ;
      private short[] P00CM3_A120TotOrd ;
      private int[] P00CM4_A115TotRub ;
      private string[] P00CM4_A114TotTipo ;
      private short[] P00CM4_A1829RubSts ;
      private int[] P00CM4_A116RubCod ;
      private string[] P00CM4_A1822RubDsc ;
      private string[] P00CM4_A1823RubDscTot ;
      private short[] P00CM4_A117RubOrd ;
      private int[] P00CM5_A116RubCod ;
      private int[] P00CM5_A115TotRub ;
      private string[] P00CM5_A114TotTipo ;
      private int[] P00CM5_A118RubLinCod ;
      private string[] P00CM5_A1826RubLinDsc ;
      private short[] P00CM5_A119RubLinOrd ;
      private int[] P00CM6_A115TotRub ;
      private string[] P00CM6_A114TotTipo ;
      private string[] P00CM6_A1928TotDsc ;
      private string[] P00CM6_A1929TotDscTot ;
      private short[] P00CM6_A120TotOrd ;
      private int[] P00CM7_A115TotRub ;
      private string[] P00CM7_A114TotTipo ;
      private short[] P00CM7_A1829RubSts ;
      private int[] P00CM7_A116RubCod ;
      private string[] P00CM7_A1822RubDsc ;
      private string[] P00CM7_A1823RubDscTot ;
      private short[] P00CM7_A117RubOrd ;
      private int[] P00CM8_A116RubCod ;
      private int[] P00CM8_A115TotRub ;
      private string[] P00CM8_A114TotTipo ;
      private int[] P00CM8_A118RubLinCod ;
      private string[] P00CM8_A1826RubLinDsc ;
      private short[] P00CM8_A119RubLinOrd ;
      private GXBaseCollection<SdtSdtBalance_SdtCuentaItem> AV69SdtBalanceActivo ;
      private GXBaseCollection<SdtSdtBalance_SdtCuentaItem> AV71SdtBalancePasivo ;
      private SdtSdtBalance_SdtCuentaItem AV68SdtBalanceActivoItem ;
      private SdtSdtBalance_SdtCuentaItem AV70SdtBalancePasivoItem ;
   }

   public class rrlibro3_1__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CM2;
          prmP00CM2 = new Object[] {
          new ParDef("@AV48Moneda",GXType.Int32,6,0)
          };
          Object[] prmP00CM3;
          prmP00CM3 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0)
          };
          Object[] prmP00CM4;
          prmP00CM4 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0)
          };
          Object[] prmP00CM5;
          prmP00CM5 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV10RubCod",GXType.Int32,6,0)
          };
          Object[] prmP00CM6;
          prmP00CM6 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0)
          };
          Object[] prmP00CM7;
          prmP00CM7 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0)
          };
          Object[] prmP00CM8;
          prmP00CM8 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV10RubCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CM2", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV48Moneda ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CM2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CM3", "SELECT [TotRub], [TotTipo], [TotDsc], [TotDscTot], [TotOrd] FROM [CBRUBROST] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = 1) ORDER BY [TotOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CM3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CM4", "SELECT [TotRub], [TotTipo], [RubSts], [RubCod], [RubDsc], [RubDscTot], [RubOrd] FROM [CBRUBROS] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) ORDER BY [RubOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CM4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CM5", "SELECT [RubCod], [TotRub], [TotTipo], [RubLinCod], [RubLinDsc], [RubLinOrd] FROM [CBRUBROSL] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) AND ([RubCod] = @AV10RubCod) ORDER BY [RubLinOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CM5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CM6", "SELECT [TotRub], [TotTipo], [TotDsc], [TotDscTot], [TotOrd] FROM [CBRUBROST] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = 2) ORDER BY [TotOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CM6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CM7", "SELECT [TotRub], [TotTipo], [RubSts], [RubCod], [RubDsc], [RubDscTot], [RubOrd] FROM [CBRUBROS] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) ORDER BY [RubOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CM7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CM8", "SELECT [RubCod], [TotRub], [TotTipo], [RubLinCod], [RubLinDsc], [RubLinOrd] FROM [CBRUBROSL] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) AND ([RubCod] = @AV10RubCod) ORDER BY [RubLinOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CM8,100, GxCacheFrequency.OFF ,true,false )
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
