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
   public class r_balancecomprobacionhojatrabajopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_balancecomprobacionhojatrabajopdf.aspx")), "contabilidad.r_balancecomprobacionhojatrabajopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_balancecomprobacionhojatrabajopdf.aspx")))) ;
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
                  AV69nDig = (short)(NumberUtil.Val( GetPar( "nDig"), "."));
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

      public r_balancecomprobacionhojatrabajopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_balancecomprobacionhojatrabajopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref short aP2_nDig )
      {
         this.AV11Ano = aP0_Ano;
         this.AV12Mes = aP1_Mes;
         this.AV69nDig = aP2_nDig;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_nDig=this.AV69nDig;
      }

      public short executeUdp( ref short aP0_Ano ,
                               ref short aP1_Mes )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_nDig);
         return AV69nDig ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref short aP2_nDig )
      {
         r_balancecomprobacionhojatrabajopdf objr_balancecomprobacionhojatrabajopdf;
         objr_balancecomprobacionhojatrabajopdf = new r_balancecomprobacionhojatrabajopdf();
         objr_balancecomprobacionhojatrabajopdf.AV11Ano = aP0_Ano;
         objr_balancecomprobacionhojatrabajopdf.AV12Mes = aP1_Mes;
         objr_balancecomprobacionhojatrabajopdf.AV69nDig = aP2_nDig;
         objr_balancecomprobacionhojatrabajopdf.context.SetSubmitInitialConfig(context);
         objr_balancecomprobacionhojatrabajopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_balancecomprobacionhojatrabajopdf);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_nDig=this.AV69nDig;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_balancecomprobacionhojatrabajopdf)stateInfo).executePrivate();
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
            AV27Empresa = AV30Session.Get("Empresa");
            AV70EmpRUC = AV30Session.Get("EmpRUC");
            AV71Ruta = AV30Session.Get("RUTA") + "/Logo.jpg";
            AV72Logo = AV71Ruta;
            AV147Logo_GXI = GXDbFile.PathToUrl( AV71Ruta);
            AV67FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV67FechaC, 2);
            GXt_date1 = AV15Fecha;
            new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV16FechaD, out  GXt_date1) ;
            AV15Fecha = GXt_date1;
            if ( AV12Mes == 0 )
            {
               AV67FechaC = "01/01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
               AV15Fecha = context.localUtil.CToD( AV67FechaC, 2);
            }
            GXt_char2 = AV68cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char2) ;
            AV68cMes = GXt_char2;
            AV13Titulo = "Balance de Comprobación";
            AV14Periodo = StringUtil.Trim( AV68cMes) + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV144Titulo2 = "Reporte a " + StringUtil.Trim( StringUtil.Str( (decimal)(AV69nDig), 2, 0)) + " Digitos";
            if ( ( AV12Mes == 0 ) || ( AV12Mes == 13 ) )
            {
               AV14Periodo = ((AV12Mes==0) ? "Apertura" : "Cierre");
            }
            AV143MonCod = 1;
            AV99SaldoIniD = 0.00m;
            AV100SaldoIniH = 0.00m;
            AV101SaldoAcumD = 0.00m;
            AV102SaldoAcumH = 0.00m;
            AV103SaldoAjusD = 0.00m;
            AV104SaldoAjusH = 0.00m;
            AV105SaldoInvD = 0.00m;
            AV106SaldoInvH = 0.00m;
            AV107SaldoNatD = 0.00m;
            AV108SaldoNatH = 0.00m;
            AV109SaldoFunD = 0.00m;
            AV110SaldoFunH = 0.00m;
            AV111TSaldoIniD = 0.00m;
            AV112TSaldoIniH = 0.00m;
            AV113TSaldoAcumD = 0.00m;
            AV114TSaldoAcumH = 0.00m;
            AV115TSaldoAjusD = 0.00m;
            AV116TSaldoAjusH = 0.00m;
            AV117TSaldoInvD = 0.00m;
            AV118TSaldoInvH = 0.00m;
            AV119TSaldoNatD = 0.00m;
            AV120TSaldoNatH = 0.00m;
            AV121TSaldoFunD = 0.00m;
            AV122TSaldoFunH = 0.00m;
            AV74Flag = 0;
            AV87nSaldoA = 0.00m;
            AV88nSaldoD = 0.00m;
            AV93nSaldoInvA = 0.00m;
            AV94nSaldoInvP = 0.00m;
            AV95nSaldoNatP = 0.00m;
            AV96nSaldoNatG = 0.00m;
            AV97nSaldoFunP = 0.00m;
            AV98nSaldoFunG = 0.00m;
            AV124Len = 0;
            AV129CodCueNDig = "";
            AV130DscCueNdig = "";
            if ( ! (0==AV69nDig) )
            {
               AV124Len = AV69nDig;
               /* Using cursor P00B82 */
               pr_default.execute(0, new Object[] {AV69nDig});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A91CueCod = P00B82_A91CueCod[0];
                  A109CueGasDebe = P00B82_A109CueGasDebe[0];
                  n109CueGasDebe = P00B82_n109CueGasDebe[0];
                  A860CueDsc = P00B82_A860CueDsc[0];
                  A868CueRef1 = P00B82_A868CueRef1[0];
                  A869CueRef2 = P00B82_A869CueRef2[0];
                  A870CueRef3 = P00B82_A870CueRef3[0];
                  A872CueRef5 = P00B82_A872CueRef5[0];
                  AV129CodCueNDig = StringUtil.Trim( A91CueCod);
                  AV130DscCueNdig = StringUtil.Trim( A860CueDsc);
                  AV73Cuenta = StringUtil.Trim( A91CueCod);
                  AV41CueDsc = StringUtil.Trim( A91CueCod) + " - " + StringUtil.Trim( A860CueDsc);
                  AV89CueRef1 = A868CueRef1;
                  AV90CueRef2 = A869CueRef2;
                  AV91CueRef3 = A870CueRef3;
                  AV92CueRef5 = A872CueRef5;
                  AV99SaldoIniD = 0.00m;
                  AV100SaldoIniH = 0.00m;
                  AV101SaldoAcumD = 0.00m;
                  AV102SaldoAcumH = 0.00m;
                  AV103SaldoAjusD = 0.00m;
                  AV104SaldoAjusH = 0.00m;
                  AV105SaldoInvD = 0.00m;
                  AV106SaldoInvH = 0.00m;
                  AV107SaldoNatD = 0.00m;
                  AV108SaldoNatH = 0.00m;
                  AV109SaldoFunD = 0.00m;
                  AV110SaldoFunH = 0.00m;
                  AV80DebeSaldoT = 0.00m;
                  AV81HaberSaldoT = 0.00m;
                  AV77nDebeMesT = 0.00m;
                  AV78nHaberMesT = 0.00m;
                  AV82DebeAcumulaT = 0.00m;
                  AV83HaberAcumulaT = 0.00m;
                  AV84nSaldoT = 0.00m;
                  /* Execute user subroutine: 'VALIDAMOVMES2DIGITOS' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
                  /* Execute user subroutine: 'MOVIMIENTOMES' */
                  S131 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
                  if ( AV74Flag == 0 )
                  {
                     AV85Totales = "TOTAL CUENTA " + StringUtil.Trim( AV73Cuenta);
                     AV59nSaldo = (decimal)(AV105SaldoInvD-AV106SaldoInvH);
                     AV105SaldoInvD = ((AV59nSaldo>Convert.ToDecimal(0)) ? AV59nSaldo : (decimal)(0));
                     AV106SaldoInvH = ((AV59nSaldo<Convert.ToDecimal(0)) ? AV59nSaldo*-1 : (decimal)(0));
                     AV59nSaldo = (decimal)(AV107SaldoNatD-AV108SaldoNatH);
                     AV107SaldoNatD = ((AV59nSaldo>Convert.ToDecimal(0)) ? AV59nSaldo : (decimal)(0));
                     AV108SaldoNatH = ((AV59nSaldo<Convert.ToDecimal(0)) ? AV59nSaldo*-1 : (decimal)(0));
                     AV59nSaldo = (decimal)(AV109SaldoFunD-AV110SaldoFunH);
                     AV109SaldoFunD = ((AV59nSaldo>Convert.ToDecimal(0)) ? AV59nSaldo : (decimal)(0));
                     AV110SaldoFunH = ((AV59nSaldo<Convert.ToDecimal(0)) ? AV59nSaldo*-1 : (decimal)(0));
                     HB80( false, 20) ;
                     getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV110SaldoFunH, "ZZZZZZ,ZZZ,ZZ9.99")), 1044, Gx_line+5, 1116, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV109SaldoFunD, "ZZZZZZ,ZZZ,ZZ9.99")), 966, Gx_line+5, 1038, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV108SaldoNatH, "ZZZZZZ,ZZZ,ZZ9.99")), 889, Gx_line+5, 961, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV107SaldoNatD, "ZZZZZZ,ZZZ,ZZ9.99")), 821, Gx_line+5, 893, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV106SaldoInvH, "ZZZZZZ,ZZZ,ZZ9.99")), 755, Gx_line+5, 827, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV105SaldoInvD, "ZZZZZZ,ZZZ,ZZ9.99")), 692, Gx_line+5, 764, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV104SaldoAjusH, "ZZZZZZ,ZZZ,ZZ9.99")), 620, Gx_line+5, 692, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV103SaldoAjusD, "ZZZZZZ,ZZZ,ZZ9.99")), 550, Gx_line+5, 622, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102SaldoAcumH, "ZZZZZZ,ZZZ,ZZ9.99")), 485, Gx_line+5, 557, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV101SaldoAcumD, "ZZZZZZ,ZZZ,ZZ9.99")), 421, Gx_line+5, 493, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV100SaldoIniH, "ZZZZZZ,ZZZ,ZZ9.99")), 353, Gx_line+5, 425, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV99SaldoIniD, "ZZZZZZ,ZZZ,ZZ9.99")), 279, Gx_line+5, 351, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV130DscCueNdig, "")), 65, Gx_line+5, 274, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV129CodCueNDig, "")), 6, Gx_line+5, 49, Gx_line+16, 1+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
                  AV111TSaldoIniD = (decimal)(AV111TSaldoIniD+AV99SaldoIniD);
                  AV112TSaldoIniH = (decimal)(AV112TSaldoIniH+AV100SaldoIniH);
                  AV113TSaldoAcumD = (decimal)(AV113TSaldoAcumD+AV101SaldoAcumD);
                  AV114TSaldoAcumH = (decimal)(AV114TSaldoAcumH+AV102SaldoAcumH);
                  AV115TSaldoAjusD = (decimal)(AV115TSaldoAjusD+AV103SaldoAjusD);
                  AV116TSaldoAjusH = (decimal)(AV116TSaldoAjusH+AV104SaldoAjusH);
                  AV117TSaldoInvD = (decimal)(AV117TSaldoInvD+AV105SaldoInvD);
                  AV118TSaldoInvH = (decimal)(AV118TSaldoInvH+AV106SaldoInvH);
                  AV119TSaldoNatD = (decimal)(AV119TSaldoNatD+AV107SaldoNatD);
                  AV120TSaldoNatH = (decimal)(AV120TSaldoNatH+AV108SaldoNatH);
                  AV121TSaldoFunD = (decimal)(AV121TSaldoFunD+AV109SaldoFunD);
                  AV122TSaldoFunH = (decimal)(AV122TSaldoFunH+AV110SaldoFunH);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
            }
            else
            {
               AV69nDig = 2;
               /* Using cursor P00B83 */
               pr_default.execute(1);
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A91CueCod = P00B83_A91CueCod[0];
                  A109CueGasDebe = P00B83_A109CueGasDebe[0];
                  n109CueGasDebe = P00B83_n109CueGasDebe[0];
                  A860CueDsc = P00B83_A860CueDsc[0];
                  A868CueRef1 = P00B83_A868CueRef1[0];
                  A869CueRef2 = P00B83_A869CueRef2[0];
                  A870CueRef3 = P00B83_A870CueRef3[0];
                  A872CueRef5 = P00B83_A872CueRef5[0];
                  AV73Cuenta = StringUtil.Trim( A91CueCod);
                  AV41CueDsc = StringUtil.Trim( A91CueCod) + " - " + StringUtil.Trim( A860CueDsc);
                  AV89CueRef1 = A868CueRef1;
                  AV90CueRef2 = A869CueRef2;
                  AV91CueRef3 = A870CueRef3;
                  AV92CueRef5 = A872CueRef5;
                  AV99SaldoIniD = 0.00m;
                  AV100SaldoIniH = 0.00m;
                  AV101SaldoAcumD = 0.00m;
                  AV102SaldoAcumH = 0.00m;
                  AV103SaldoAjusD = 0.00m;
                  AV104SaldoAjusH = 0.00m;
                  AV105SaldoInvD = 0.00m;
                  AV106SaldoInvH = 0.00m;
                  AV107SaldoNatD = 0.00m;
                  AV108SaldoNatH = 0.00m;
                  AV109SaldoFunD = 0.00m;
                  AV110SaldoFunH = 0.00m;
                  AV80DebeSaldoT = 0.00m;
                  AV81HaberSaldoT = 0.00m;
                  AV77nDebeMesT = 0.00m;
                  AV78nHaberMesT = 0.00m;
                  AV82DebeAcumulaT = 0.00m;
                  AV83HaberAcumulaT = 0.00m;
                  AV84nSaldoT = 0.00m;
                  /* Execute user subroutine: 'VALIDAMOVMES2DIGITOS' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     this.cleanup();
                     if (true) return;
                  }
                  if ( AV74Flag == 0 )
                  {
                     HB80( false, 24) ;
                     getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41CueDsc, "")), 5, Gx_line+5, 423, Gx_line+16, 0+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+24);
                  }
                  /* Execute user subroutine: 'MOVIMIENTOMES' */
                  S131 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     this.cleanup();
                     if (true) return;
                  }
                  if ( AV74Flag == 0 )
                  {
                     AV85Totales = "TOTAL CUENTA " + StringUtil.Trim( AV73Cuenta);
                     HB80( false, 25) ;
                     getPrinter().GxDrawLine(285, Gx_line+3, 1119, Gx_line+3, 1, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV99SaldoIniD, "ZZZZZZ,ZZZ,ZZ9.99")), 279, Gx_line+8, 351, Gx_line+19, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV100SaldoIniH, "ZZZZZZ,ZZZ,ZZ9.99")), 353, Gx_line+8, 425, Gx_line+19, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV101SaldoAcumD, "ZZZZZZ,ZZZ,ZZ9.99")), 421, Gx_line+8, 493, Gx_line+19, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102SaldoAcumH, "ZZZZZZ,ZZZ,ZZ9.99")), 485, Gx_line+8, 557, Gx_line+19, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV104SaldoAjusH, "ZZZZZZ,ZZZ,ZZ9.99")), 620, Gx_line+8, 692, Gx_line+19, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV103SaldoAjusD, "ZZZZZZ,ZZZ,ZZ9.99")), 550, Gx_line+8, 622, Gx_line+19, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV106SaldoInvH, "ZZZZZZ,ZZZ,ZZ9.99")), 755, Gx_line+8, 827, Gx_line+19, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV105SaldoInvD, "ZZZZZZ,ZZZ,ZZ9.99")), 692, Gx_line+8, 764, Gx_line+19, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV108SaldoNatH, "ZZZZZZ,ZZZ,ZZ9.99")), 889, Gx_line+8, 961, Gx_line+19, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV107SaldoNatD, "ZZZZZZ,ZZZ,ZZ9.99")), 821, Gx_line+8, 893, Gx_line+19, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV110SaldoFunH, "ZZZZZZ,ZZZ,ZZ9.99")), 1044, Gx_line+8, 1116, Gx_line+19, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV109SaldoFunD, "ZZZZZZ,ZZZ,ZZ9.99")), 966, Gx_line+8, 1038, Gx_line+19, 2+256, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85Totales, "")), 52, Gx_line+9, 268, Gx_line+19, 2, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+25);
                  }
                  AV111TSaldoIniD = (decimal)(AV111TSaldoIniD+AV99SaldoIniD);
                  AV112TSaldoIniH = (decimal)(AV112TSaldoIniH+AV100SaldoIniH);
                  AV113TSaldoAcumD = (decimal)(AV113TSaldoAcumD+AV101SaldoAcumD);
                  AV114TSaldoAcumH = (decimal)(AV114TSaldoAcumH+AV102SaldoAcumH);
                  AV115TSaldoAjusD = (decimal)(AV115TSaldoAjusD+AV103SaldoAjusD);
                  AV116TSaldoAjusH = (decimal)(AV116TSaldoAjusH+AV104SaldoAjusH);
                  AV117TSaldoInvD = (decimal)(AV117TSaldoInvD+AV105SaldoInvD);
                  AV118TSaldoInvH = (decimal)(AV118TSaldoInvH+AV106SaldoInvH);
                  AV119TSaldoNatD = (decimal)(AV119TSaldoNatD+AV107SaldoNatD);
                  AV120TSaldoNatH = (decimal)(AV120TSaldoNatH+AV108SaldoNatH);
                  AV121TSaldoFunD = (decimal)(AV121TSaldoFunD+AV109SaldoFunD);
                  AV122TSaldoFunH = (decimal)(AV122TSaldoFunH+AV110SaldoFunH);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
            }
            AV131DifBalance1 = 0.00m;
            AV132DifBalance2 = 0.00m;
            AV137TotBalance1 = 0.00m;
            AV138TotBalance2 = 0.00m;
            AV133DifNatura1 = 0.00m;
            AV134DifNatura2 = 0.00m;
            AV139TotNatura1 = 0.00m;
            AV140TotNatura2 = 0.00m;
            AV135DifFuncion1 = 0.00m;
            AV136DifFuncion2 = 0.00m;
            AV141TotFuncion1 = 0.00m;
            AV142TotFuncion2 = 0.00m;
            AV131DifBalance1 = ((AV117TSaldoInvD-AV118TSaldoInvH>Convert.ToDecimal(0)) ? (decimal)(0) : (AV117TSaldoInvD-AV118TSaldoInvH)*-1);
            AV132DifBalance2 = ((AV117TSaldoInvD-AV118TSaldoInvH>Convert.ToDecimal(0)) ? (AV117TSaldoInvD-AV118TSaldoInvH) : (decimal)(0));
            AV137TotBalance1 = (decimal)(AV117TSaldoInvD+AV131DifBalance1);
            AV138TotBalance2 = (decimal)(AV118TSaldoInvH+AV132DifBalance2);
            AV133DifNatura1 = ((AV119TSaldoNatD-AV120TSaldoNatH>Convert.ToDecimal(0)) ? (decimal)(0) : (AV119TSaldoNatD-AV120TSaldoNatH)*-1);
            AV134DifNatura2 = ((AV119TSaldoNatD-AV120TSaldoNatH>Convert.ToDecimal(0)) ? (AV119TSaldoNatD-AV120TSaldoNatH) : (decimal)(0));
            AV139TotNatura1 = (decimal)(AV119TSaldoNatD+AV133DifNatura1);
            AV140TotNatura2 = (decimal)(AV120TSaldoNatH+AV134DifNatura2);
            AV135DifFuncion1 = ((AV121TSaldoFunD-AV122TSaldoFunH>Convert.ToDecimal(0)) ? (decimal)(0) : (AV121TSaldoFunD-AV122TSaldoFunH)*-1);
            AV136DifFuncion2 = ((AV121TSaldoFunD-AV122TSaldoFunH>Convert.ToDecimal(0)) ? (AV121TSaldoFunD-AV122TSaldoFunH) : (decimal)(0));
            AV141TotFuncion1 = (decimal)(AV121TSaldoFunD+AV135DifFuncion1);
            AV142TotFuncion2 = (decimal)(AV122TSaldoFunH+AV136DifFuncion2);
            HB80( false, 89) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General :", 503, Gx_line+54, 589, Gx_line+68, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV111TSaldoIniD, "ZZZZZZ,ZZZ,ZZ9.99")), 279, Gx_line+9, 351, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV112TSaldoIniH, "ZZZZZZ,ZZZ,ZZ9.99")), 353, Gx_line+9, 425, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV113TSaldoAcumD, "ZZZZZZ,ZZZ,ZZ9.99")), 421, Gx_line+9, 493, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV114TSaldoAcumH, "ZZZZZZ,ZZZ,ZZ9.99")), 485, Gx_line+9, 557, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV115TSaldoAjusD, "ZZZZZZ,ZZZ,ZZ9.99")), 550, Gx_line+9, 622, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV116TSaldoAjusH, "ZZZZZZ,ZZZ,ZZ9.99")), 620, Gx_line+9, 692, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV117TSaldoInvD, "ZZZZZZ,ZZZ,ZZ9.99")), 692, Gx_line+9, 764, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV118TSaldoInvH, "ZZZZZZ,ZZZ,ZZ9.99")), 755, Gx_line+9, 827, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV119TSaldoNatD, "ZZZZZZ,ZZZ,ZZ9.99")), 821, Gx_line+9, 893, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV120TSaldoNatH, "ZZZZZZ,ZZZ,ZZ9.99")), 889, Gx_line+9, 961, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV121TSaldoFunD, "ZZZZZZ,ZZZ,ZZ9.99")), 966, Gx_line+9, 1038, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV122TSaldoFunH, "ZZZZZZ,ZZZ,ZZ9.99")), 1044, Gx_line+9, 1116, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(355, Gx_line+24, 1120, Gx_line+73, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(355, Gx_line+49, 1120, Gx_line+49, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(697, Gx_line+24, 697, Gx_line+73, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(830, Gx_line+25, 830, Gx_line+73, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(964, Gx_line+25, 964, Gx_line+72, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Perdida / Ganancia", 490, Gx_line+29, 602, Gx_line+43, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(281, Gx_line+1, 1120, Gx_line+1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV131DifBalance1, "ZZZZZZ,ZZZ,ZZ9.99")), 692, Gx_line+32, 764, Gx_line+43, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV132DifBalance2, "ZZZZZZ,ZZZ,ZZ9.99")), 755, Gx_line+32, 827, Gx_line+43, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV137TotBalance1, "ZZZZZZ,ZZZ,ZZ9.99")), 692, Gx_line+56, 764, Gx_line+67, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV138TotBalance2, "ZZZZZZ,ZZZ,ZZ9.99")), 755, Gx_line+56, 827, Gx_line+67, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV134DifNatura2, "ZZZZZZ,ZZZ,ZZ9.99")), 889, Gx_line+32, 961, Gx_line+43, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV133DifNatura1, "ZZZZZZ,ZZZ,ZZ9.99")), 821, Gx_line+32, 893, Gx_line+43, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV139TotNatura1, "ZZZZZZ,ZZZ,ZZ9.99")), 821, Gx_line+56, 893, Gx_line+67, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV140TotNatura2, "ZZZZZZ,ZZZ,ZZ9.99")), 889, Gx_line+56, 961, Gx_line+67, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV136DifFuncion2, "ZZZZZZ,ZZZ,ZZ9.99")), 1044, Gx_line+32, 1116, Gx_line+43, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV135DifFuncion1, "ZZZZZZ,ZZZ,ZZ9.99")), 966, Gx_line+32, 1038, Gx_line+43, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV141TotFuncion1, "ZZZZZZ,ZZZ,ZZ9.99")), 966, Gx_line+56, 1038, Gx_line+67, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV142TotFuncion2, "ZZZZZZ,ZZZ,ZZ9.99")), 1044, Gx_line+56, 1116, Gx_line+67, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+89);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HB80( true, 0) ;
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
         /* 'VALIDAMOVMES' Routine */
         returnInSub = false;
         /* Optimized group. */
         /* Using cursor P00B84 */
         pr_default.execute(2, new Object[] {AV11Ano, AV12Mes, AV49nCueCod});
         c2051VouDDeb = P00B84_A2051VouDDeb[0];
         c2055VouDHab = P00B84_A2055VouDHab[0];
         pr_default.close(2);
         AV53nDebeMes = (decimal)(AV53nDebeMes+c2051VouDDeb);
         AV54nHaberMes = (decimal)(AV54nHaberMes+c2055VouDHab);
         /* End optimized group. */
      }

      protected void S121( )
      {
         /* 'VALIDAMOVMES2DIGITOS' Routine */
         returnInSub = false;
         AV74Flag = 1;
         /* Using cursor P00B85 */
         pr_default.execute(3, new Object[] {AV11Ano, AV12Mes, AV69nDig, AV73Cuenta});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A126TASICod = P00B85_A126TASICod[0];
            A129VouNum = P00B85_A129VouNum[0];
            A91CueCod = P00B85_A91CueCod[0];
            A2077VouSts = P00B85_A2077VouSts[0];
            A128VouMes = P00B85_A128VouMes[0];
            A127VouAno = P00B85_A127VouAno[0];
            A130VouDSec = P00B85_A130VouDSec[0];
            A2077VouSts = P00B85_A2077VouSts[0];
            AV74Flag = 0;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV86MesAnt = (short)(AV12Mes-1);
         /* Using cursor P00B86 */
         pr_default.execute(4, new Object[] {AV11Ano, AV86MesAnt, AV69nDig, AV73Cuenta});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A123SalCueCod = P00B86_A123SalCueCod[0];
            A122SalVouMes = P00B86_A122SalVouMes[0];
            A121SalVouAno = P00B86_A121SalVouAno[0];
            A124SalMonCod = P00B86_A124SalMonCod[0];
            A125SalCueAux = P00B86_A125SalCueAux[0];
            AV74Flag = 0;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S131( )
      {
         /* 'MOVIMIENTOMES' Routine */
         returnInSub = false;
         /* Using cursor P00B87 */
         pr_default.execute(5, new Object[] {AV69nDig, AV73Cuenta, AV11Ano});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKB88 = false;
            A133CueCodAux = P00B87_A133CueCodAux[0];
            A91CueCod = P00B87_A91CueCod[0];
            A127VouAno = P00B87_A127VouAno[0];
            A2053VouDDoc = P00B87_A2053VouDDoc[0];
            A860CueDsc = P00B87_A860CueDsc[0];
            A868CueRef1 = P00B87_A868CueRef1[0];
            A869CueRef2 = P00B87_A869CueRef2[0];
            A870CueRef3 = P00B87_A870CueRef3[0];
            A872CueRef5 = P00B87_A872CueRef5[0];
            A128VouMes = P00B87_A128VouMes[0];
            A126TASICod = P00B87_A126TASICod[0];
            A129VouNum = P00B87_A129VouNum[0];
            A130VouDSec = P00B87_A130VouDSec[0];
            A860CueDsc = P00B87_A860CueDsc[0];
            A868CueRef1 = P00B87_A868CueRef1[0];
            A869CueRef2 = P00B87_A869CueRef2[0];
            A870CueRef3 = P00B87_A870CueRef3[0];
            A872CueRef5 = P00B87_A872CueRef5[0];
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00B87_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRKB88 = false;
               A133CueCodAux = P00B87_A133CueCodAux[0];
               A127VouAno = P00B87_A127VouAno[0];
               A128VouMes = P00B87_A128VouMes[0];
               A126TASICod = P00B87_A126TASICod[0];
               A129VouNum = P00B87_A129VouNum[0];
               A130VouDSec = P00B87_A130VouDSec[0];
               BRKB88 = true;
               pr_default.readNext(5);
            }
            AV49nCueCod = StringUtil.Trim( A91CueCod);
            AV50nCueDsc = A860CueDsc;
            AV89CueRef1 = A868CueRef1;
            AV90CueRef2 = A869CueRef2;
            AV91CueRef3 = A870CueRef3;
            AV92CueRef5 = A872CueRef5;
            AV51DebeSaldo = 0.00m;
            AV52HaberSaldo = 0.00m;
            AV53nDebeMes = 0.00m;
            AV54nHaberMes = 0.00m;
            AV55DebeAcumula = 0.00m;
            AV56HaberAcumula = 0.00m;
            AV87nSaldoA = 0.00m;
            AV88nSaldoD = 0.00m;
            AV93nSaldoInvA = 0.00m;
            AV94nSaldoInvP = 0.00m;
            AV95nSaldoNatP = 0.00m;
            AV96nSaldoNatG = 0.00m;
            AV97nSaldoFunP = 0.00m;
            AV98nSaldoFunG = 0.00m;
            /* Execute user subroutine: 'VALIDAMOVMES' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(5);
               returnInSub = true;
               if (true) return;
            }
            GXt_decimal3 = AV66Anterior;
            new GeneXus.Programs.contabilidad.psaldocuenta(context ).execute(  AV49nCueCod,  AV11Ano,  AV12Mes,  AV143MonCod, out  GXt_decimal3) ;
            AV66Anterior = GXt_decimal3;
            AV51DebeSaldo = ((AV66Anterior>Convert.ToDecimal(0)) ? AV66Anterior : (decimal)(0));
            AV52HaberSaldo = ((AV66Anterior<Convert.ToDecimal(0)) ? AV66Anterior*-1 : (decimal)(0));
            AV55DebeAcumula = AV53nDebeMes;
            AV56HaberAcumula = AV54nHaberMes;
            AV59nSaldo = (decimal)((AV53nDebeMes+AV51DebeSaldo)-(AV54nHaberMes+AV52HaberSaldo));
            AV87nSaldoA = (decimal)(AV53nDebeMes+AV51DebeSaldo);
            AV88nSaldoD = (decimal)(AV54nHaberMes+AV52HaberSaldo);
            if ( AV89CueRef1 == 1 )
            {
               AV93nSaldoInvA = ((AV59nSaldo>Convert.ToDecimal(0)) ? AV59nSaldo : (decimal)(0));
               AV94nSaldoInvP = ((AV59nSaldo<Convert.ToDecimal(0)) ? AV59nSaldo*-1 : (decimal)(0));
            }
            if ( AV91CueRef3 == 1 )
            {
               AV95nSaldoNatP = ((AV59nSaldo>Convert.ToDecimal(0)) ? AV59nSaldo : (decimal)(0));
               AV96nSaldoNatG = ((AV59nSaldo<Convert.ToDecimal(0)) ? AV59nSaldo*-1 : (decimal)(0));
            }
            if ( AV90CueRef2 == 1 )
            {
               AV97nSaldoFunP = ((AV59nSaldo>Convert.ToDecimal(0)) ? AV59nSaldo : (decimal)(0));
               AV98nSaldoFunG = ((AV59nSaldo<Convert.ToDecimal(0)) ? AV59nSaldo*-1 : (decimal)(0));
            }
            if ( ( ( AV53nDebeMes > Convert.ToDecimal( 0 )) || ( AV54nHaberMes > Convert.ToDecimal( 0 )) || ( AV66Anterior != Convert.ToDecimal( 0 )) ) && ( AV124Len == 0 ) )
            {
               AV59nSaldo = (decimal)(AV93nSaldoInvA-AV94nSaldoInvP);
               AV93nSaldoInvA = ((AV59nSaldo>Convert.ToDecimal(0)) ? AV59nSaldo : (decimal)(0));
               AV94nSaldoInvP = ((AV59nSaldo<Convert.ToDecimal(0)) ? AV59nSaldo*-1 : (decimal)(0));
               AV59nSaldo = (decimal)(AV95nSaldoNatP-AV96nSaldoNatG);
               AV95nSaldoNatP = ((AV59nSaldo>Convert.ToDecimal(0)) ? AV59nSaldo : (decimal)(0));
               AV96nSaldoNatG = ((AV59nSaldo<Convert.ToDecimal(0)) ? AV59nSaldo*-1 : (decimal)(0));
               AV59nSaldo = (decimal)(AV97nSaldoFunP-AV98nSaldoFunG);
               AV97nSaldoFunP = ((AV59nSaldo>Convert.ToDecimal(0)) ? AV59nSaldo : (decimal)(0));
               AV98nSaldoFunG = ((AV59nSaldo<Convert.ToDecimal(0)) ? AV59nSaldo*-1 : (decimal)(0));
               HB80( false, 18) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49nCueCod, "")), 3, Gx_line+3, 67, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50nCueDsc, "")), 65, Gx_line+3, 280, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55DebeAcumula, "ZZZZZZ,ZZZ,ZZ9.99")), 421, Gx_line+3, 493, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56HaberAcumula, "ZZZZZZ,ZZZ,ZZ9.99")), 485, Gx_line+3, 557, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88nSaldoD, "ZZZZZZ,ZZZ,ZZ9.99")), 620, Gx_line+3, 692, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87nSaldoA, "ZZZZZZ,ZZZ,ZZ9.99")), 550, Gx_line+3, 622, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52HaberSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 353, Gx_line+3, 425, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51DebeSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 279, Gx_line+3, 351, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV94nSaldoInvP, "ZZZZZZ,ZZZ,ZZ9.99")), 755, Gx_line+4, 827, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV93nSaldoInvA, "ZZZZZZ,ZZZ,ZZ9.99")), 692, Gx_line+4, 764, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV96nSaldoNatG, "ZZZZZZ,ZZZ,ZZ9.99")), 889, Gx_line+3, 961, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV95nSaldoNatP, "ZZZZZZ,ZZZ,ZZ9.99")), 821, Gx_line+3, 893, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV98nSaldoFunG, "ZZZZZZ,ZZZ,ZZ9.99")), 1044, Gx_line+3, 1116, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV97nSaldoFunP, "ZZZZZZ,ZZZ,ZZ9.99")), 966, Gx_line+3, 1038, Gx_line+14, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
            }
            AV99SaldoIniD = (decimal)(AV99SaldoIniD+AV51DebeSaldo);
            AV100SaldoIniH = (decimal)(AV100SaldoIniH+AV52HaberSaldo);
            AV101SaldoAcumD = (decimal)(AV101SaldoAcumD+AV55DebeAcumula);
            AV102SaldoAcumH = (decimal)(AV102SaldoAcumH+AV56HaberAcumula);
            AV103SaldoAjusD = (decimal)(AV103SaldoAjusD+AV87nSaldoA);
            AV104SaldoAjusH = (decimal)(AV104SaldoAjusH+AV88nSaldoD);
            AV105SaldoInvD = (decimal)(AV105SaldoInvD+AV93nSaldoInvA);
            AV106SaldoInvH = (decimal)(AV106SaldoInvH+AV94nSaldoInvP);
            AV107SaldoNatD = (decimal)(AV107SaldoNatD+AV95nSaldoNatP);
            AV108SaldoNatH = (decimal)(AV108SaldoNatH+AV96nSaldoNatG);
            AV109SaldoFunD = (decimal)(AV109SaldoFunD+AV97nSaldoFunP);
            AV110SaldoFunH = (decimal)(AV110SaldoFunH+AV98nSaldoFunG);
            if ( ! BRKB88 )
            {
               BRKB88 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void HB80( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 392, Gx_line+25, 768, Gx_line+43, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 389, Gx_line+43, 769, Gx_line+60, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 9, Gx_line+90, 377, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70EmpRUC, "")), 9, Gx_line+107, 380, Gx_line+125, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV72Logo)) ? AV147Logo_GXI : AV72Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 10, Gx_line+8, 168, Gx_line+86) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 994, Gx_line+31, 1038, Gx_line+45, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1044, Gx_line+31, 1083, Gx_line+46, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV144Titulo2, "")), 389, Gx_line+60, 769, Gx_line+77, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+127);
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción", 141, Gx_line+14, 201, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber", 511, Gx_line+23, 544, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(66, Gx_line+1, 66, Gx_line+36, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(284, Gx_line+0, 284, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(429, Gx_line+0, 429, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(697, Gx_line+0, 697, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Cuenta", 11, Gx_line+14, 48, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo Anterior", 324, Gx_line+4, 401, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 1121, Gx_line+36, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(284, Gx_line+19, 1120, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(964, Gx_line+0, 964, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Debe", 456, Gx_line+23, 483, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Acumulado Actual", 582, Gx_line+4, 677, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(830, Gx_line+0, 830, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Balance", 744, Gx_line+4, 786, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Resultado Naturaleza", 838, Gx_line+4, 949, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Resultado Función", 996, Gx_line+4, 1091, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Deudor", 575, Gx_line+23, 614, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Acrededor", 628, Gx_line+23, 684, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pasivo", 783, Gx_line+23, 818, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Activo", 718, Gx_line+23, 752, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Ganancia", 901, Gx_line+23, 949, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Perdida", 846, Gx_line+23, 888, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Ganancia", 1050, Gx_line+23, 1098, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Perdida", 985, Gx_line+23, 1027, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(560, Gx_line+0, 560, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Movimiento del Mes", 445, Gx_line+4, 549, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber", 371, Gx_line+24, 404, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Debe", 315, Gx_line+24, 342, Gx_line+37, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+35);
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
         AV27Empresa = "";
         AV30Session = context.GetSession();
         AV70EmpRUC = "";
         AV71Ruta = "";
         AV72Logo = "";
         AV147Logo_GXI = "";
         AV67FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV15Fecha = DateTime.MinValue;
         GXt_date1 = DateTime.MinValue;
         AV68cMes = "";
         GXt_char2 = "";
         AV13Titulo = "";
         AV14Periodo = "";
         AV144Titulo2 = "";
         AV129CodCueNDig = "";
         AV130DscCueNdig = "";
         scmdbuf = "";
         P00B82_A91CueCod = new string[] {""} ;
         P00B82_A109CueGasDebe = new string[] {""} ;
         P00B82_n109CueGasDebe = new bool[] {false} ;
         P00B82_A860CueDsc = new string[] {""} ;
         P00B82_A868CueRef1 = new short[1] ;
         P00B82_A869CueRef2 = new short[1] ;
         P00B82_A870CueRef3 = new short[1] ;
         P00B82_A872CueRef5 = new short[1] ;
         A91CueCod = "";
         A109CueGasDebe = "";
         A860CueDsc = "";
         AV73Cuenta = "";
         AV41CueDsc = "";
         AV85Totales = "";
         P00B83_A91CueCod = new string[] {""} ;
         P00B83_A109CueGasDebe = new string[] {""} ;
         P00B83_n109CueGasDebe = new bool[] {false} ;
         P00B83_A860CueDsc = new string[] {""} ;
         P00B83_A868CueRef1 = new short[1] ;
         P00B83_A869CueRef2 = new short[1] ;
         P00B83_A870CueRef3 = new short[1] ;
         P00B83_A872CueRef5 = new short[1] ;
         AV49nCueCod = "";
         P00B84_A2051VouDDeb = new decimal[1] ;
         P00B84_A2055VouDHab = new decimal[1] ;
         P00B85_A126TASICod = new int[1] ;
         P00B85_A129VouNum = new string[] {""} ;
         P00B85_A91CueCod = new string[] {""} ;
         P00B85_A2077VouSts = new short[1] ;
         P00B85_A128VouMes = new short[1] ;
         P00B85_A127VouAno = new short[1] ;
         P00B85_A130VouDSec = new int[1] ;
         A129VouNum = "";
         P00B86_A123SalCueCod = new string[] {""} ;
         P00B86_A122SalVouMes = new short[1] ;
         P00B86_A121SalVouAno = new short[1] ;
         P00B86_A124SalMonCod = new int[1] ;
         P00B86_A125SalCueAux = new string[] {""} ;
         A123SalCueCod = "";
         A125SalCueAux = "";
         P00B87_A133CueCodAux = new string[] {""} ;
         P00B87_A91CueCod = new string[] {""} ;
         P00B87_A127VouAno = new short[1] ;
         P00B87_A2053VouDDoc = new string[] {""} ;
         P00B87_A860CueDsc = new string[] {""} ;
         P00B87_A868CueRef1 = new short[1] ;
         P00B87_A869CueRef2 = new short[1] ;
         P00B87_A870CueRef3 = new short[1] ;
         P00B87_A872CueRef5 = new short[1] ;
         P00B87_A128VouMes = new short[1] ;
         P00B87_A126TASICod = new int[1] ;
         P00B87_A129VouNum = new string[] {""} ;
         P00B87_A130VouDSec = new int[1] ;
         A133CueCodAux = "";
         A2053VouDDoc = "";
         AV50nCueDsc = "";
         AV72Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_balancecomprobacionhojatrabajopdf__default(),
            new Object[][] {
                new Object[] {
               P00B82_A91CueCod, P00B82_A109CueGasDebe, P00B82_n109CueGasDebe, P00B82_A860CueDsc, P00B82_A868CueRef1, P00B82_A869CueRef2, P00B82_A870CueRef3, P00B82_A872CueRef5
               }
               , new Object[] {
               P00B83_A91CueCod, P00B83_A109CueGasDebe, P00B83_n109CueGasDebe, P00B83_A860CueDsc, P00B83_A868CueRef1, P00B83_A869CueRef2, P00B83_A870CueRef3, P00B83_A872CueRef5
               }
               , new Object[] {
               P00B84_A2051VouDDeb, P00B84_A2055VouDHab
               }
               , new Object[] {
               P00B85_A126TASICod, P00B85_A129VouNum, P00B85_A91CueCod, P00B85_A2077VouSts, P00B85_A128VouMes, P00B85_A127VouAno, P00B85_A130VouDSec
               }
               , new Object[] {
               P00B86_A123SalCueCod, P00B86_A122SalVouMes, P00B86_A121SalVouAno, P00B86_A124SalMonCod, P00B86_A125SalCueAux
               }
               , new Object[] {
               P00B87_A133CueCodAux, P00B87_A91CueCod, P00B87_A127VouAno, P00B87_A2053VouDDoc, P00B87_A860CueDsc, P00B87_A868CueRef1, P00B87_A869CueRef2, P00B87_A870CueRef3, P00B87_A872CueRef5, P00B87_A128VouMes,
               P00B87_A126TASICod, P00B87_A129VouNum, P00B87_A130VouDSec
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
      private short AV69nDig ;
      private short AV74Flag ;
      private short A868CueRef1 ;
      private short A869CueRef2 ;
      private short A870CueRef3 ;
      private short A872CueRef5 ;
      private short AV89CueRef1 ;
      private short AV90CueRef2 ;
      private short AV91CueRef3 ;
      private short AV92CueRef5 ;
      private short A2077VouSts ;
      private short A128VouMes ;
      private short A127VouAno ;
      private short AV86MesAnt ;
      private short A122SalVouMes ;
      private short A121SalVouAno ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV143MonCod ;
      private int Gx_OldLine ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int A124SalMonCod ;
      private long AV124Len ;
      private decimal AV99SaldoIniD ;
      private decimal AV100SaldoIniH ;
      private decimal AV101SaldoAcumD ;
      private decimal AV102SaldoAcumH ;
      private decimal AV103SaldoAjusD ;
      private decimal AV104SaldoAjusH ;
      private decimal AV105SaldoInvD ;
      private decimal AV106SaldoInvH ;
      private decimal AV107SaldoNatD ;
      private decimal AV108SaldoNatH ;
      private decimal AV109SaldoFunD ;
      private decimal AV110SaldoFunH ;
      private decimal AV111TSaldoIniD ;
      private decimal AV112TSaldoIniH ;
      private decimal AV113TSaldoAcumD ;
      private decimal AV114TSaldoAcumH ;
      private decimal AV115TSaldoAjusD ;
      private decimal AV116TSaldoAjusH ;
      private decimal AV117TSaldoInvD ;
      private decimal AV118TSaldoInvH ;
      private decimal AV119TSaldoNatD ;
      private decimal AV120TSaldoNatH ;
      private decimal AV121TSaldoFunD ;
      private decimal AV122TSaldoFunH ;
      private decimal AV87nSaldoA ;
      private decimal AV88nSaldoD ;
      private decimal AV93nSaldoInvA ;
      private decimal AV94nSaldoInvP ;
      private decimal AV95nSaldoNatP ;
      private decimal AV96nSaldoNatG ;
      private decimal AV97nSaldoFunP ;
      private decimal AV98nSaldoFunG ;
      private decimal AV80DebeSaldoT ;
      private decimal AV81HaberSaldoT ;
      private decimal AV77nDebeMesT ;
      private decimal AV78nHaberMesT ;
      private decimal AV82DebeAcumulaT ;
      private decimal AV83HaberAcumulaT ;
      private decimal AV84nSaldoT ;
      private decimal AV59nSaldo ;
      private decimal AV131DifBalance1 ;
      private decimal AV132DifBalance2 ;
      private decimal AV137TotBalance1 ;
      private decimal AV138TotBalance2 ;
      private decimal AV133DifNatura1 ;
      private decimal AV134DifNatura2 ;
      private decimal AV139TotNatura1 ;
      private decimal AV140TotNatura2 ;
      private decimal AV135DifFuncion1 ;
      private decimal AV136DifFuncion2 ;
      private decimal AV141TotFuncion1 ;
      private decimal AV142TotFuncion2 ;
      private decimal c2051VouDDeb ;
      private decimal c2055VouDHab ;
      private decimal AV53nDebeMes ;
      private decimal AV54nHaberMes ;
      private decimal AV51DebeSaldo ;
      private decimal AV52HaberSaldo ;
      private decimal AV55DebeAcumula ;
      private decimal AV56HaberAcumula ;
      private decimal AV66Anterior ;
      private decimal GXt_decimal3 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV27Empresa ;
      private string AV70EmpRUC ;
      private string AV71Ruta ;
      private string AV67FechaC ;
      private string AV68cMes ;
      private string GXt_char2 ;
      private string AV13Titulo ;
      private string AV14Periodo ;
      private string AV144Titulo2 ;
      private string AV129CodCueNDig ;
      private string AV130DscCueNdig ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A109CueGasDebe ;
      private string A860CueDsc ;
      private string AV73Cuenta ;
      private string AV41CueDsc ;
      private string AV85Totales ;
      private string AV49nCueCod ;
      private string A129VouNum ;
      private string A123SalCueCod ;
      private string A125SalCueAux ;
      private string A133CueCodAux ;
      private string A2053VouDDoc ;
      private string AV50nCueDsc ;
      private string sImgUrl ;
      private DateTime AV16FechaD ;
      private DateTime AV15Fecha ;
      private DateTime GXt_date1 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n109CueGasDebe ;
      private bool returnInSub ;
      private bool BRKB88 ;
      private string AV147Logo_GXI ;
      private string AV72Logo ;
      private string Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private short aP2_nDig ;
      private IDataStoreProvider pr_default ;
      private string[] P00B82_A91CueCod ;
      private string[] P00B82_A109CueGasDebe ;
      private bool[] P00B82_n109CueGasDebe ;
      private string[] P00B82_A860CueDsc ;
      private short[] P00B82_A868CueRef1 ;
      private short[] P00B82_A869CueRef2 ;
      private short[] P00B82_A870CueRef3 ;
      private short[] P00B82_A872CueRef5 ;
      private string[] P00B83_A91CueCod ;
      private string[] P00B83_A109CueGasDebe ;
      private bool[] P00B83_n109CueGasDebe ;
      private string[] P00B83_A860CueDsc ;
      private short[] P00B83_A868CueRef1 ;
      private short[] P00B83_A869CueRef2 ;
      private short[] P00B83_A870CueRef3 ;
      private short[] P00B83_A872CueRef5 ;
      private decimal[] P00B84_A2051VouDDeb ;
      private decimal[] P00B84_A2055VouDHab ;
      private int[] P00B85_A126TASICod ;
      private string[] P00B85_A129VouNum ;
      private string[] P00B85_A91CueCod ;
      private short[] P00B85_A2077VouSts ;
      private short[] P00B85_A128VouMes ;
      private short[] P00B85_A127VouAno ;
      private int[] P00B85_A130VouDSec ;
      private string[] P00B86_A123SalCueCod ;
      private short[] P00B86_A122SalVouMes ;
      private short[] P00B86_A121SalVouAno ;
      private int[] P00B86_A124SalMonCod ;
      private string[] P00B86_A125SalCueAux ;
      private string[] P00B87_A133CueCodAux ;
      private string[] P00B87_A91CueCod ;
      private short[] P00B87_A127VouAno ;
      private string[] P00B87_A2053VouDDoc ;
      private string[] P00B87_A860CueDsc ;
      private short[] P00B87_A868CueRef1 ;
      private short[] P00B87_A869CueRef2 ;
      private short[] P00B87_A870CueRef3 ;
      private short[] P00B87_A872CueRef5 ;
      private short[] P00B87_A128VouMes ;
      private int[] P00B87_A126TASICod ;
      private string[] P00B87_A129VouNum ;
      private int[] P00B87_A130VouDSec ;
   }

   public class r_balancecomprobacionhojatrabajopdf__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B82;
          prmP00B82 = new Object[] {
          new ParDef("@AV69nDig",GXType.Int16,2,0)
          };
          Object[] prmP00B83;
          prmP00B83 = new Object[] {
          };
          Object[] prmP00B84;
          prmP00B84 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV49nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00B85;
          prmP00B85 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV69nDig",GXType.Int16,2,0) ,
          new ParDef("@AV73Cuenta",GXType.Char,15,0)
          };
          Object[] prmP00B86;
          prmP00B86 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV86MesAnt",GXType.Int16,2,0) ,
          new ParDef("@AV69nDig",GXType.Int16,2,0) ,
          new ParDef("@AV73Cuenta",GXType.Char,15,0)
          };
          Object[] prmP00B87;
          prmP00B87 = new Object[] {
          new ParDef("@AV69nDig",GXType.Int16,2,0) ,
          new ParDef("@AV73Cuenta",GXType.Char,15,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B82", "SELECT [CueCod], [CueGasDebe], [CueDsc], [CueRef1], [CueRef2], [CueRef3], [CueRef5] FROM [CBPLANCUENTA] WHERE LEN([CueCod]) = @AV69nDig ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B82,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B83", "SELECT [CueCod], [CueGasDebe], [CueDsc], [CueRef1], [CueRef2], [CueRef3], [CueRef5] FROM [CBPLANCUENTA] WHERE LEN([CueCod]) = 2 ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B83,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B84", "SELECT SUM(T1.[VouDDeb]), SUM(T1.[VouDHab]) FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV49nCueCod) AND (T2.[VouSts] = 1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B84,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B85", "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T1.[CueCod], T2.[VouSts], T1.[VouMes], T1.[VouAno], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes) AND (SUBSTRING(T1.[CueCod], 1, @AV69nDig) = @AV73Cuenta) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B85,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00B86", "SELECT TOP 1 [SalCueCod], [SalVouMes], [SalVouAno], [SalMonCod], [SalCueAux] FROM [CBSALDOMENSUAL] WHERE ([SalVouAno] = @AV11Ano and [SalVouMes] = @AV86MesAnt) AND (SUBSTRING([SalCueCod], 1, @AV69nDig) = @AV73Cuenta) ORDER BY [SalVouAno], [SalVouMes], [SalCueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B86,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00B87", "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouAno], T1.[VouDDoc], T2.[CueDsc], T2.[CueRef1], T2.[CueRef2], T2.[CueRef3], T2.[CueRef5], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (SUBSTRING(T1.[CueCod], 1, @AV69nDig) = @AV73Cuenta) AND (T1.[VouAno] = @AV11Ano) ORDER BY T1.[CueCod], T1.[CueCodAux] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B87,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 10);
                ((int[]) buf[12])[0] = rslt.getInt(13);
                return;
       }
    }

 }

}
