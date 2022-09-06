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
   public class r_balancegeneralpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_balancegeneralpdf.aspx")), "contabilidad.r_balancegeneralpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_balancegeneralpdf.aspx")))) ;
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

      public r_balancegeneralpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_balancegeneralpdf( IGxContext context )
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
         r_balancegeneralpdf objr_balancegeneralpdf;
         objr_balancegeneralpdf = new r_balancegeneralpdf();
         objr_balancegeneralpdf.AV11Ano = aP0_Ano;
         objr_balancegeneralpdf.AV12Mes = aP1_Mes;
         objr_balancegeneralpdf.AV38Tipo = aP2_Tipo;
         objr_balancegeneralpdf.AV48Moneda = aP3_Moneda;
         objr_balancegeneralpdf.context.SetSubmitInitialConfig(context);
         objr_balancegeneralpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_balancegeneralpdf);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_Tipo=this.AV38Tipo;
         aP3_Moneda=this.AV48Moneda;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_balancegeneralpdf)stateInfo).executePrivate();
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
            AV33Empresa = AV34Session.Get("Empresa");
            AV32EmpDir = AV34Session.Get("EmpDir");
            AV35EmpRUC = AV34Session.Get("EmpRUC");
            AV36Ruta = AV34Session.Get("RUTA") + "/Logo.jpg";
            AV37Logo = AV36Ruta;
            AV53Logo_GXI = GXDbFile.PathToUrl( AV36Ruta);
            AV8TotTipo = "BAL";
            AV13Titulo = "Balance General";
            AV50Titulo2 = "";
            /* Using cursor P00BN2 */
            pr_default.execute(0, new Object[] {AV48Moneda});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P00BN2_A180MonCod[0];
               A1234MonDsc = P00BN2_A1234MonDsc[0];
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
            /* Using cursor P00BN3 */
            pr_default.execute(1, new Object[] {AV8TotTipo});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A114TotTipo = P00BN3_A114TotTipo[0];
               A115TotRub = P00BN3_A115TotRub[0];
               A1928TotDsc = P00BN3_A1928TotDsc[0];
               A1929TotDscTot = P00BN3_A1929TotDscTot[0];
               A120TotOrd = P00BN3_A120TotOrd[0];
               AV9TotRub = A115TotRub;
               AV27ImpTot = 0.00m;
               AV28ImpTotSal = 0.00m;
               HBN0( false, 20) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1928TotDsc, "")), 16, Gx_line+2, 396, Gx_line+18, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               /* Using cursor P00BN4 */
               pr_default.execute(2, new Object[] {AV8TotTipo, AV9TotRub});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A115TotRub = P00BN4_A115TotRub[0];
                  A114TotTipo = P00BN4_A114TotTipo[0];
                  A1829RubSts = P00BN4_A1829RubSts[0];
                  A116RubCod = P00BN4_A116RubCod[0];
                  A1822RubDsc = P00BN4_A1822RubDsc[0];
                  A1823RubDscTot = P00BN4_A1823RubDscTot[0];
                  A117RubOrd = P00BN4_A117RubOrd[0];
                  AV10RubCod = A116RubCod;
                  AV25ImpRub = 0.00m;
                  AV26ImpRubSal = 0.00m;
                  HBN0( false, 23) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1822RubDsc, "")), 16, Gx_line+3, 396, Gx_line+19, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+23);
                  /* Using cursor P00BN5 */
                  pr_default.execute(3, new Object[] {AV8TotTipo, AV9TotRub, AV10RubCod});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A116RubCod = P00BN5_A116RubCod[0];
                     A115TotRub = P00BN5_A115TotRub[0];
                     A114TotTipo = P00BN5_A114TotTipo[0];
                     A118RubLinCod = P00BN5_A118RubLinCod[0];
                     A1826RubLinDsc = P00BN5_A1826RubLinDsc[0];
                     A119RubLinOrd = P00BN5_A119RubLinOrd[0];
                     AV8TotTipo = A114TotTipo;
                     AV9TotRub = A115TotRub;
                     AV10RubCod = A116RubCod;
                     AV42RubLinCod = A118RubLinCod;
                     GXt_decimal3 = AV18ImpBalAnt;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV19AnoAnt,  AV20MesAnt,  "ANT",  "", out  GXt_decimal3) ;
                     AV18ImpBalAnt = GXt_decimal3;
                     GXt_decimal3 = AV17ImpBal;
                     new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV11Ano,  AV12Mes,  "ACT",  "", out  GXt_decimal3) ;
                     AV17ImpBal = GXt_decimal3;
                     AV18ImpBalAnt = NumberUtil.Round( AV18ImpBalAnt/ (decimal)(AV49Cambio), 2);
                     AV17ImpBal = NumberUtil.Round( AV17ImpBal/ (decimal)(AV49Cambio), 2);
                     HBN0( false, 17) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1826RubLinDsc, "")), 16, Gx_line+0, 396, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17ImpBal, "ZZZZZZ,ZZZ,ZZ9.99")), 494, Gx_line+0, 601, Gx_line+15, 2+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
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
                     AV25ImpRub = (decimal)(AV25ImpRub+AV17ImpBal);
                     AV26ImpRubSal = (decimal)(AV26ImpRubSal+AV18ImpBalAnt);
                     pr_default.readNext(3);
                  }
                  pr_default.close(3);
                  HBN0( false, 25) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1823RubDscTot, "")), 16, Gx_line+7, 397, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV25ImpRub, "ZZZZZZ,ZZZ,ZZ9.99")), 494, Gx_line+5, 601, Gx_line+20, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(454, Gx_line+5, 640, Gx_line+5, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+25);
                  AV27ImpTot = (decimal)(AV27ImpTot+AV25ImpRub);
                  AV28ImpTotSal = (decimal)(AV28ImpTotSal+AV26ImpRubSal);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               HBN0( false, 42) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1929TotDscTot, "")), 16, Gx_line+8, 397, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27ImpTot, "ZZZZZZ,ZZZ,ZZ9.99")), 494, Gx_line+8, 601, Gx_line+23, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(456, Gx_line+6, 642, Gx_line+6, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+42);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HBN0( true, 0) ;
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
         /* Using cursor P00BN6 */
         pr_default.execute(4, new Object[] {AV8TotTipo, AV9TotRub, AV10RubCod, AV42RubLinCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A118RubLinCod = P00BN6_A118RubLinCod[0];
            A116RubCod = P00BN6_A116RubCod[0];
            A115TotRub = P00BN6_A115TotRub[0];
            A114TotTipo = P00BN6_A114TotTipo[0];
            A860CueDsc = P00BN6_A860CueDsc[0];
            A91CueCod = P00BN6_A91CueCod[0];
            A860CueDsc = P00BN6_A860CueDsc[0];
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
            HBN0( false, 20) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39CueDsc, "")), 152, Gx_line+3, 440, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Cuenta, "")), 51, Gx_line+3, 130, Gx_line+18, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 494, Gx_line+3, 601, Gx_line+18, 2+256, 0, 0, 0) ;
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
         /* Using cursor P00BN7 */
         pr_default.execute(5, new Object[] {AV43Len, AV40Cuenta});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A91CueCod = P00BN7_A91CueCod[0];
            AV45CueCod = A91CueCod;
            GXt_char1 = "";
            GXt_char4 = "";
            new GeneXus.Programs.contabilidad.poptienesaldocuentamesactual(context ).execute( ref  AV11Ano, ref  AV12Mes, ref  AV45CueCod, ref  GXt_char1, ref  GXt_char4, out  AV46Debe, out  AV47Haber) ;
            AV44ImpMov = (decimal)(AV46Debe-AV47Haber);
            if ( ( StringUtil.StrCmp(AV8TotTipo, "BAL") == 0 ) && ( AV9TotRub == 2 ) )
            {
               AV44ImpMov = (decimal)(AV44ImpMov*-1);
            }
            AV41Saldo = (decimal)(AV41Saldo+AV44ImpMov);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void HBN0( bool bFoot ,
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 183, Gx_line+14, 639, Gx_line+39, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Titulo2, "")), 183, Gx_line+39, 639, Gx_line+64, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+117, 800, Gx_line+146, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción", 120, Gx_line+125, 189, Gx_line+139, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mes Actual", 534, Gx_line+125, 600, Gx_line+139, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Empresa, "")), 14, Gx_line+64, 384, Gx_line+82, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35EmpRUC, "")), 14, Gx_line+81, 385, Gx_line+99, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 183, Gx_line+64, 639, Gx_line+89, 1, 0, 0, 0) ;
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
         AV53Logo_GXI = "";
         AV8TotTipo = "";
         AV13Titulo = "";
         AV50Titulo2 = "";
         scmdbuf = "";
         P00BN2_A180MonCod = new int[1] ;
         P00BN2_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV29cMes = "";
         AV30FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV15Fecha = DateTime.MinValue;
         GXt_date2 = DateTime.MinValue;
         AV14Periodo = "";
         P00BN3_A114TotTipo = new string[] {""} ;
         P00BN3_A115TotRub = new int[1] ;
         P00BN3_A1928TotDsc = new string[] {""} ;
         P00BN3_A1929TotDscTot = new string[] {""} ;
         P00BN3_A120TotOrd = new short[1] ;
         A114TotTipo = "";
         A1928TotDsc = "";
         A1929TotDscTot = "";
         P00BN4_A115TotRub = new int[1] ;
         P00BN4_A114TotTipo = new string[] {""} ;
         P00BN4_A1829RubSts = new short[1] ;
         P00BN4_A116RubCod = new int[1] ;
         P00BN4_A1822RubDsc = new string[] {""} ;
         P00BN4_A1823RubDscTot = new string[] {""} ;
         P00BN4_A117RubOrd = new short[1] ;
         A1822RubDsc = "";
         A1823RubDscTot = "";
         P00BN5_A116RubCod = new int[1] ;
         P00BN5_A115TotRub = new int[1] ;
         P00BN5_A114TotTipo = new string[] {""} ;
         P00BN5_A118RubLinCod = new int[1] ;
         P00BN5_A1826RubLinDsc = new string[] {""} ;
         P00BN5_A119RubLinOrd = new short[1] ;
         A1826RubLinDsc = "";
         P00BN6_A118RubLinCod = new int[1] ;
         P00BN6_A116RubCod = new int[1] ;
         P00BN6_A115TotRub = new int[1] ;
         P00BN6_A114TotTipo = new string[] {""} ;
         P00BN6_A860CueDsc = new string[] {""} ;
         P00BN6_A91CueCod = new string[] {""} ;
         A860CueDsc = "";
         A91CueCod = "";
         AV40Cuenta = "";
         AV39CueDsc = "";
         P00BN7_A91CueCod = new string[] {""} ;
         AV45CueCod = "";
         GXt_char1 = "";
         GXt_char4 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_balancegeneralpdf__default(),
            new Object[][] {
                new Object[] {
               P00BN2_A180MonCod, P00BN2_A1234MonDsc
               }
               , new Object[] {
               P00BN3_A114TotTipo, P00BN3_A115TotRub, P00BN3_A1928TotDsc, P00BN3_A1929TotDscTot, P00BN3_A120TotOrd
               }
               , new Object[] {
               P00BN4_A115TotRub, P00BN4_A114TotTipo, P00BN4_A1829RubSts, P00BN4_A116RubCod, P00BN4_A1822RubDsc, P00BN4_A1823RubDscTot, P00BN4_A117RubOrd
               }
               , new Object[] {
               P00BN5_A116RubCod, P00BN5_A115TotRub, P00BN5_A114TotTipo, P00BN5_A118RubLinCod, P00BN5_A1826RubLinDsc, P00BN5_A119RubLinOrd
               }
               , new Object[] {
               P00BN6_A118RubLinCod, P00BN6_A116RubCod, P00BN6_A115TotRub, P00BN6_A114TotTipo, P00BN6_A860CueDsc, P00BN6_A91CueCod
               }
               , new Object[] {
               P00BN7_A91CueCod
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
      private decimal AV27ImpTot ;
      private decimal AV28ImpTotSal ;
      private decimal AV25ImpRub ;
      private decimal AV26ImpRubSal ;
      private decimal AV18ImpBalAnt ;
      private decimal AV17ImpBal ;
      private decimal GXt_decimal3 ;
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
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string AV29cMes ;
      private string AV30FechaC ;
      private string AV14Periodo ;
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
      private string GXt_char1 ;
      private string GXt_char4 ;
      private DateTime AV16FechaD ;
      private DateTime AV15Fecha ;
      private DateTime GXt_date2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private string AV53Logo_GXI ;
      private string AV37Logo ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_Tipo ;
      private int aP3_Moneda ;
      private IDataStoreProvider pr_default ;
      private int[] P00BN2_A180MonCod ;
      private string[] P00BN2_A1234MonDsc ;
      private string[] P00BN3_A114TotTipo ;
      private int[] P00BN3_A115TotRub ;
      private string[] P00BN3_A1928TotDsc ;
      private string[] P00BN3_A1929TotDscTot ;
      private short[] P00BN3_A120TotOrd ;
      private int[] P00BN4_A115TotRub ;
      private string[] P00BN4_A114TotTipo ;
      private short[] P00BN4_A1829RubSts ;
      private int[] P00BN4_A116RubCod ;
      private string[] P00BN4_A1822RubDsc ;
      private string[] P00BN4_A1823RubDscTot ;
      private short[] P00BN4_A117RubOrd ;
      private int[] P00BN5_A116RubCod ;
      private int[] P00BN5_A115TotRub ;
      private string[] P00BN5_A114TotTipo ;
      private int[] P00BN5_A118RubLinCod ;
      private string[] P00BN5_A1826RubLinDsc ;
      private short[] P00BN5_A119RubLinOrd ;
      private int[] P00BN6_A118RubLinCod ;
      private int[] P00BN6_A116RubCod ;
      private int[] P00BN6_A115TotRub ;
      private string[] P00BN6_A114TotTipo ;
      private string[] P00BN6_A860CueDsc ;
      private string[] P00BN6_A91CueCod ;
      private string[] P00BN7_A91CueCod ;
   }

   public class r_balancegeneralpdf__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BN2;
          prmP00BN2 = new Object[] {
          new ParDef("@AV48Moneda",GXType.Int32,6,0)
          };
          Object[] prmP00BN3;
          prmP00BN3 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0)
          };
          Object[] prmP00BN4;
          prmP00BN4 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0)
          };
          Object[] prmP00BN5;
          prmP00BN5 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV10RubCod",GXType.Int32,6,0)
          };
          Object[] prmP00BN6;
          prmP00BN6 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV10RubCod",GXType.Int32,6,0) ,
          new ParDef("@AV42RubLinCod",GXType.Int32,6,0)
          };
          Object[] prmP00BN7;
          prmP00BN7 = new Object[] {
          new ParDef("@AV43Len",GXType.Int32,5,0) ,
          new ParDef("@AV40Cuenta",GXType.Char,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BN2", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV48Moneda ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BN2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BN3", "SELECT [TotTipo], [TotRub], [TotDsc], [TotDscTot], [TotOrd] FROM [CBRUBROST] WHERE [TotTipo] = @AV8TotTipo ORDER BY [TotOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BN3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BN4", "SELECT [TotRub], [TotTipo], [RubSts], [RubCod], [RubDsc], [RubDscTot], [RubOrd] FROM [CBRUBROS] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) ORDER BY [RubOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BN4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BN5", "SELECT [RubCod], [TotRub], [TotTipo], [RubLinCod], [RubLinDsc], [RubLinOrd] FROM [CBRUBROSL] WHERE ([TotTipo] = @AV8TotTipo) AND ([TotRub] = @AV9TotRub) AND ([RubCod] = @AV10RubCod) ORDER BY [RubLinOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BN5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BN6", "SELECT T1.[RubLinCod], T1.[RubCod], T1.[TotRub], T1.[TotTipo], T2.[CueDsc], T1.[CueCod] FROM ([CBRUBROSLD] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE T1.[TotTipo] = @AV8TotTipo and T1.[TotRub] = @AV9TotRub and T1.[RubCod] = @AV10RubCod and T1.[RubLinCod] = @AV42RubLinCod ORDER BY T1.[TotTipo], T1.[TotRub], T1.[RubCod], T1.[RubLinCod], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BN6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BN7", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE SUBSTRING([CueCod], 1, @AV43Len) = @AV40Cuenta ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BN7,100, GxCacheFrequency.OFF ,true,false )
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
