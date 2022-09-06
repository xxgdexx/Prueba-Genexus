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
   public class rrlibro3_17 : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.rrlibro3_17.aspx")), "contabilidad.rrlibro3_17.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.rrlibro3_17.aspx")))) ;
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

      public rrlibro3_17( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrlibro3_17( IGxContext context )
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
         rrlibro3_17 objrrlibro3_17;
         objrrlibro3_17 = new rrlibro3_17();
         objrrlibro3_17.AV11Ano = aP0_Ano;
         objrrlibro3_17.AV12Mes = aP1_Mes;
         objrrlibro3_17.AV69nDig = aP2_nDig;
         objrrlibro3_17.context.SetSubmitInitialConfig(context);
         objrrlibro3_17.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrlibro3_17);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_nDig=this.AV69nDig;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrlibro3_17)stateInfo).executePrivate();
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
            AV28EmpDir = AV30Session.Get("EmpDir");
            AV70EmpRUC = AV30Session.Get("EmpRUC");
            AV71Ruta = AV30Session.Get("RUTA") + "/Logo.jpg";
            AV72Logo = AV71Ruta;
            AV146Logo_GXI = GXDbFile.PathToUrl( AV71Ruta);
            AV67FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV67FechaC, 2);
            GXt_char1 = AV68cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV68cMes = GXt_char1;
            AV13Titulo = "FORMATO 3.17 : LIBRO DE INVENTARIOS Y BALANCES - BALANCE DE COMPROBACIÓN";
            AV14Periodo = StringUtil.Upper( AV68cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
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
               /* Using cursor P00CL2 */
               pr_default.execute(0, new Object[] {AV69nDig});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A91CueCod = P00CL2_A91CueCod[0];
                  A109CueGasDebe = P00CL2_A109CueGasDebe[0];
                  n109CueGasDebe = P00CL2_n109CueGasDebe[0];
                  A860CueDsc = P00CL2_A860CueDsc[0];
                  A868CueRef1 = P00CL2_A868CueRef1[0];
                  A869CueRef2 = P00CL2_A869CueRef2[0];
                  A870CueRef3 = P00CL2_A870CueRef3[0];
                  A872CueRef5 = P00CL2_A872CueRef5[0];
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
                     HCL0( false, 20) ;
                     getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV110SaldoFunH, "ZZZZZZ,ZZZ,ZZ9.99")), 1009, Gx_line+5, 1099, Gx_line+18, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV109SaldoFunD, "ZZZZZZ,ZZZ,ZZ9.99")), 907, Gx_line+5, 997, Gx_line+18, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV106SaldoInvH, "ZZZZZZ,ZZZ,ZZ9.99")), 807, Gx_line+5, 897, Gx_line+18, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV105SaldoInvD, "ZZZZZZ,ZZZ,ZZ9.99")), 721, Gx_line+5, 811, Gx_line+18, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV104SaldoAjusH, "ZZZZZZ,ZZZ,ZZ9.99")), 641, Gx_line+5, 731, Gx_line+18, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV103SaldoAjusD, "ZZZZZZ,ZZZ,ZZ9.99")), 565, Gx_line+5, 655, Gx_line+18, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102SaldoAcumH, "ZZZZZZ,ZZZ,ZZ9.99")), 492, Gx_line+5, 582, Gx_line+18, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV101SaldoAcumD, "ZZZZZZ,ZZZ,ZZ9.99")), 411, Gx_line+5, 501, Gx_line+18, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV100SaldoIniH, "ZZZZZZ,ZZZ,ZZ9.99")), 343, Gx_line+5, 433, Gx_line+18, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV99SaldoIniD, "ZZZZZZ,ZZZ,ZZ9.99")), 271, Gx_line+5, 361, Gx_line+18, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV130DscCueNdig, "")), 76, Gx_line+5, 289, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV129CodCueNDig, "")), 14, Gx_line+5, 57, Gx_line+18, 0+256, 0, 0, 0) ;
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
               /* Using cursor P00CL3 */
               pr_default.execute(1);
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A91CueCod = P00CL3_A91CueCod[0];
                  A109CueGasDebe = P00CL3_A109CueGasDebe[0];
                  n109CueGasDebe = P00CL3_n109CueGasDebe[0];
                  A860CueDsc = P00CL3_A860CueDsc[0];
                  A868CueRef1 = P00CL3_A868CueRef1[0];
                  A869CueRef2 = P00CL3_A869CueRef2[0];
                  A870CueRef3 = P00CL3_A870CueRef3[0];
                  A872CueRef5 = P00CL3_A872CueRef5[0];
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
                  /* Execute user subroutine: 'MOVIMIENTOMES' */
                  S131 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     this.cleanup();
                     if (true) return;
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
            HCL0( false, 89) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV111TSaldoIniD, "ZZZZZZ,ZZZ,ZZ9.99")), 271, Gx_line+9, 361, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV112TSaldoIniH, "ZZZZZZ,ZZZ,ZZ9.99")), 343, Gx_line+9, 433, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV113TSaldoAcumD, "ZZZZZZ,ZZZ,ZZ9.99")), 411, Gx_line+9, 501, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV114TSaldoAcumH, "ZZZZZZ,ZZZ,ZZ9.99")), 492, Gx_line+9, 582, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV115TSaldoAjusD, "ZZZZZZ,ZZZ,ZZ9.99")), 565, Gx_line+9, 655, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV116TSaldoAjusH, "ZZZZZZ,ZZZ,ZZ9.99")), 641, Gx_line+9, 731, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV117TSaldoInvD, "ZZZZZZ,ZZZ,ZZ9.99")), 721, Gx_line+9, 811, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV118TSaldoInvH, "ZZZZZZ,ZZZ,ZZ9.99")), 807, Gx_line+9, 897, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV121TSaldoFunD, "ZZZZZZ,ZZZ,ZZ9.99")), 907, Gx_line+9, 997, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV122TSaldoFunH, "ZZZZZZ,ZZZ,ZZ9.99")), 1009, Gx_line+9, 1099, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(290, Gx_line+24, 1107, Gx_line+73, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(290, Gx_line+49, 1107, Gx_line+49, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(733, Gx_line+24, 733, Gx_line+73, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(901, Gx_line+25, 901, Gx_line+72, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("RESULTADO DEL EJERCICIO O PERIODO", 424, Gx_line+29, 648, Gx_line+43, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(290, Gx_line+1, 1101, Gx_line+1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV131DifBalance1, "ZZZZZZ,ZZZ,ZZ9.99")), 721, Gx_line+32, 811, Gx_line+45, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV132DifBalance2, "ZZZZZZ,ZZZ,ZZ9.99")), 807, Gx_line+32, 897, Gx_line+45, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV137TotBalance1, "ZZZZZZ,ZZZ,ZZ9.99")), 721, Gx_line+56, 811, Gx_line+69, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV138TotBalance2, "ZZZZZZ,ZZZ,ZZ9.99")), 807, Gx_line+56, 897, Gx_line+69, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV136DifFuncion2, "ZZZZZZ,ZZZ,ZZ9.99")), 1009, Gx_line+32, 1099, Gx_line+45, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV135DifFuncion1, "ZZZZZZ,ZZZ,ZZ9.99")), 907, Gx_line+32, 997, Gx_line+45, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV141TotFuncion1, "ZZZZZZ,ZZZ,ZZ9.99")), 907, Gx_line+56, 997, Gx_line+69, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV142TotFuncion2, "ZZZZZZ,ZZZ,ZZ9.99")), 1009, Gx_line+56, 1099, Gx_line+69, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+89);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HCL0( true, 0) ;
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
         /* Using cursor P00CL4 */
         pr_default.execute(2, new Object[] {AV11Ano, AV12Mes, AV49nCueCod});
         c2051VouDDeb = P00CL4_A2051VouDDeb[0];
         c2055VouDHab = P00CL4_A2055VouDHab[0];
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
         /* Using cursor P00CL5 */
         pr_default.execute(3, new Object[] {AV11Ano, AV12Mes, AV69nDig, AV73Cuenta});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A126TASICod = P00CL5_A126TASICod[0];
            A129VouNum = P00CL5_A129VouNum[0];
            A91CueCod = P00CL5_A91CueCod[0];
            A2077VouSts = P00CL5_A2077VouSts[0];
            A128VouMes = P00CL5_A128VouMes[0];
            A127VouAno = P00CL5_A127VouAno[0];
            A130VouDSec = P00CL5_A130VouDSec[0];
            A2077VouSts = P00CL5_A2077VouSts[0];
            AV74Flag = 0;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV86MesAnt = (short)(AV12Mes-1);
         /* Using cursor P00CL6 */
         pr_default.execute(4, new Object[] {AV11Ano, AV86MesAnt, AV69nDig, AV73Cuenta});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A123SalCueCod = P00CL6_A123SalCueCod[0];
            A122SalVouMes = P00CL6_A122SalVouMes[0];
            A121SalVouAno = P00CL6_A121SalVouAno[0];
            A124SalMonCod = P00CL6_A124SalMonCod[0];
            A125SalCueAux = P00CL6_A125SalCueAux[0];
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
         /* Using cursor P00CL7 */
         pr_default.execute(5, new Object[] {AV69nDig, AV73Cuenta, AV11Ano});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKCL8 = false;
            A133CueCodAux = P00CL7_A133CueCodAux[0];
            A91CueCod = P00CL7_A91CueCod[0];
            A127VouAno = P00CL7_A127VouAno[0];
            A2053VouDDoc = P00CL7_A2053VouDDoc[0];
            A860CueDsc = P00CL7_A860CueDsc[0];
            A868CueRef1 = P00CL7_A868CueRef1[0];
            A869CueRef2 = P00CL7_A869CueRef2[0];
            A870CueRef3 = P00CL7_A870CueRef3[0];
            A872CueRef5 = P00CL7_A872CueRef5[0];
            A128VouMes = P00CL7_A128VouMes[0];
            A126TASICod = P00CL7_A126TASICod[0];
            A129VouNum = P00CL7_A129VouNum[0];
            A130VouDSec = P00CL7_A130VouDSec[0];
            A860CueDsc = P00CL7_A860CueDsc[0];
            A868CueRef1 = P00CL7_A868CueRef1[0];
            A869CueRef2 = P00CL7_A869CueRef2[0];
            A870CueRef3 = P00CL7_A870CueRef3[0];
            A872CueRef5 = P00CL7_A872CueRef5[0];
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00CL7_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRKCL8 = false;
               A133CueCodAux = P00CL7_A133CueCodAux[0];
               A127VouAno = P00CL7_A127VouAno[0];
               A128VouMes = P00CL7_A128VouMes[0];
               A126TASICod = P00CL7_A126TASICod[0];
               A129VouNum = P00CL7_A129VouNum[0];
               A130VouDSec = P00CL7_A130VouDSec[0];
               BRKCL8 = true;
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
            GXt_decimal2 = AV66Anterior;
            new GeneXus.Programs.contabilidad.psaldocuenta(context ).execute(  AV49nCueCod,  AV11Ano,  AV12Mes,  AV143MonCod, out  GXt_decimal2) ;
            AV66Anterior = GXt_decimal2;
            AV51DebeSaldo = ((AV66Anterior>Convert.ToDecimal(0)) ? AV66Anterior : (decimal)(0));
            AV52HaberSaldo = ((AV66Anterior<Convert.ToDecimal(0)) ? AV66Anterior*-1 : (decimal)(0));
            AV55DebeAcumula = AV53nDebeMes;
            AV56HaberAcumula = AV54nHaberMes;
            AV59nSaldo = (decimal)((AV55DebeAcumula+AV51DebeSaldo)-(AV56HaberAcumula+AV52HaberSaldo));
            if ( ( AV59nSaldo > Convert.ToDecimal( 0 )) )
            {
               AV87nSaldoA = AV59nSaldo;
               AV88nSaldoD = 0.00m;
            }
            else
            {
               AV87nSaldoA = 0.00m;
               AV88nSaldoD = (decimal)(AV59nSaldo*-1);
            }
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
               HCL0( false, 18) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49nCueCod, "")), 14, Gx_line+3, 78, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50nCueDsc, "")), 76, Gx_line+3, 286, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55DebeAcumula, "ZZZZZZ,ZZZ,ZZ9.99")), 411, Gx_line+3, 501, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56HaberAcumula, "ZZZZZZ,ZZZ,ZZ9.99")), 492, Gx_line+3, 582, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88nSaldoD, "ZZZZZZ,ZZZ,ZZ9.99")), 641, Gx_line+3, 731, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87nSaldoA, "ZZZZZZ,ZZZ,ZZ9.99")), 565, Gx_line+3, 655, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52HaberSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 343, Gx_line+3, 433, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51DebeSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 271, Gx_line+3, 361, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV94nSaldoInvP, "ZZZZZZ,ZZZ,ZZ9.99")), 807, Gx_line+4, 897, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV93nSaldoInvA, "ZZZZZZ,ZZZ,ZZ9.99")), 721, Gx_line+4, 811, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV98nSaldoFunG, "ZZZZZZ,ZZZ,ZZ9.99")), 1009, Gx_line+3, 1099, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV97nSaldoFunP, "ZZZZZZ,ZZZ,ZZ9.99")), 907, Gx_line+3, 997, Gx_line+16, 2+256, 0, 0, 0) ;
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
            if ( ! BRKCL8 )
            {
               BRKCL8 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void HCL0( bool bFoot ,
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
               getPrinter().GxDrawText("Página:", 986, Gx_line+26, 1030, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1042, Gx_line+26, 1081, Gx_line+41, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 17, Gx_line+24, 331, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 85, Gx_line+55, 607, Gx_line+70, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 17, Gx_line+91, 468, Gx_line+105, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70EmpRUC, "")), 85, Gx_line+73, 190, Gx_line+88, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 17, Gx_line+55, 73, Gx_line+69, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 17, Gx_line+73, 48, Gx_line+87, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+111);
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("DENOMINACIÓN", 148, Gx_line+39, 237, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("HABER", 525, Gx_line+39, 564, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(76, Gx_line+28, 76, Gx_line+59, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(292, Gx_line+0, 292, Gx_line+59, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(435, Gx_line+1, 435, Gx_line+59, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(733, Gx_line+0, 733, Gx_line+59, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("CODIGO", 21, Gx_line+39, 66, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("SALDOS INICIALES", 316, Gx_line+10, 420, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(10, Gx_line+0, 1106, Gx_line+59, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+28, 1106, Gx_line+28, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("DEBE", 458, Gx_line+39, 486, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("SALDOS FINALES", 615, Gx_line+10, 708, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(901, Gx_line+0, 901, Gx_line+59, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("SALDOS FINALES DEL", 764, Gx_line+3, 880, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DEUDOR", 593, Gx_line+39, 638, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("ACREDEDOR", 656, Gx_line+39, 723, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("PASIVO Y", 827, Gx_line+32, 881, Gx_line+45, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("ACTIVO", 746, Gx_line+39, 791, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("GANANCIAS", 1027, Gx_line+39, 1094, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("PÉRDIDAS", 928, Gx_line+39, 984, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(584, Gx_line+1, 584, Gx_line+59, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("MOVIMIENTOS", 467, Gx_line+10, 548, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("ACREDEDOR", 365, Gx_line+39, 432, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DEUDOR", 305, Gx_line+39, 350, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("CUENTA Y SUB CUENTA CONTABLE", 71, Gx_line+9, 258, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("BALANCE GENERAL", 770, Gx_line+15, 874, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("SALDOS FINALES DEL ESTADO", 920, Gx_line+3, 1082, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("PERDIDA Y GANANCIA POR FUNCION", 903, Gx_line+15, 1104, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("PATRIMONIO", 817, Gx_line+44, 892, Gx_line+57, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+64);
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
         AV28EmpDir = "";
         AV70EmpRUC = "";
         AV71Ruta = "";
         AV72Logo = "";
         AV146Logo_GXI = "";
         AV67FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV68cMes = "";
         GXt_char1 = "";
         AV13Titulo = "";
         AV14Periodo = "";
         AV129CodCueNDig = "";
         AV130DscCueNdig = "";
         scmdbuf = "";
         P00CL2_A91CueCod = new string[] {""} ;
         P00CL2_A109CueGasDebe = new string[] {""} ;
         P00CL2_n109CueGasDebe = new bool[] {false} ;
         P00CL2_A860CueDsc = new string[] {""} ;
         P00CL2_A868CueRef1 = new short[1] ;
         P00CL2_A869CueRef2 = new short[1] ;
         P00CL2_A870CueRef3 = new short[1] ;
         P00CL2_A872CueRef5 = new short[1] ;
         A91CueCod = "";
         A109CueGasDebe = "";
         A860CueDsc = "";
         AV73Cuenta = "";
         AV41CueDsc = "";
         AV85Totales = "";
         P00CL3_A91CueCod = new string[] {""} ;
         P00CL3_A109CueGasDebe = new string[] {""} ;
         P00CL3_n109CueGasDebe = new bool[] {false} ;
         P00CL3_A860CueDsc = new string[] {""} ;
         P00CL3_A868CueRef1 = new short[1] ;
         P00CL3_A869CueRef2 = new short[1] ;
         P00CL3_A870CueRef3 = new short[1] ;
         P00CL3_A872CueRef5 = new short[1] ;
         AV49nCueCod = "";
         P00CL4_A2051VouDDeb = new decimal[1] ;
         P00CL4_A2055VouDHab = new decimal[1] ;
         P00CL5_A126TASICod = new int[1] ;
         P00CL5_A129VouNum = new string[] {""} ;
         P00CL5_A91CueCod = new string[] {""} ;
         P00CL5_A2077VouSts = new short[1] ;
         P00CL5_A128VouMes = new short[1] ;
         P00CL5_A127VouAno = new short[1] ;
         P00CL5_A130VouDSec = new int[1] ;
         A129VouNum = "";
         P00CL6_A123SalCueCod = new string[] {""} ;
         P00CL6_A122SalVouMes = new short[1] ;
         P00CL6_A121SalVouAno = new short[1] ;
         P00CL6_A124SalMonCod = new int[1] ;
         P00CL6_A125SalCueAux = new string[] {""} ;
         A123SalCueCod = "";
         A125SalCueAux = "";
         P00CL7_A133CueCodAux = new string[] {""} ;
         P00CL7_A91CueCod = new string[] {""} ;
         P00CL7_A127VouAno = new short[1] ;
         P00CL7_A2053VouDDoc = new string[] {""} ;
         P00CL7_A860CueDsc = new string[] {""} ;
         P00CL7_A868CueRef1 = new short[1] ;
         P00CL7_A869CueRef2 = new short[1] ;
         P00CL7_A870CueRef3 = new short[1] ;
         P00CL7_A872CueRef5 = new short[1] ;
         P00CL7_A128VouMes = new short[1] ;
         P00CL7_A126TASICod = new int[1] ;
         P00CL7_A129VouNum = new string[] {""} ;
         P00CL7_A130VouDSec = new int[1] ;
         A133CueCodAux = "";
         A2053VouDDoc = "";
         AV50nCueDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rrlibro3_17__default(),
            new Object[][] {
                new Object[] {
               P00CL2_A91CueCod, P00CL2_A109CueGasDebe, P00CL2_n109CueGasDebe, P00CL2_A860CueDsc, P00CL2_A868CueRef1, P00CL2_A869CueRef2, P00CL2_A870CueRef3, P00CL2_A872CueRef5
               }
               , new Object[] {
               P00CL3_A91CueCod, P00CL3_A109CueGasDebe, P00CL3_n109CueGasDebe, P00CL3_A860CueDsc, P00CL3_A868CueRef1, P00CL3_A869CueRef2, P00CL3_A870CueRef3, P00CL3_A872CueRef5
               }
               , new Object[] {
               P00CL4_A2051VouDDeb, P00CL4_A2055VouDHab
               }
               , new Object[] {
               P00CL5_A126TASICod, P00CL5_A129VouNum, P00CL5_A91CueCod, P00CL5_A2077VouSts, P00CL5_A128VouMes, P00CL5_A127VouAno, P00CL5_A130VouDSec
               }
               , new Object[] {
               P00CL6_A123SalCueCod, P00CL6_A122SalVouMes, P00CL6_A121SalVouAno, P00CL6_A124SalMonCod, P00CL6_A125SalCueAux
               }
               , new Object[] {
               P00CL7_A133CueCodAux, P00CL7_A91CueCod, P00CL7_A127VouAno, P00CL7_A2053VouDDoc, P00CL7_A860CueDsc, P00CL7_A868CueRef1, P00CL7_A869CueRef2, P00CL7_A870CueRef3, P00CL7_A872CueRef5, P00CL7_A128VouMes,
               P00CL7_A126TASICod, P00CL7_A129VouNum, P00CL7_A130VouDSec
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
      private decimal GXt_decimal2 ;
      private decimal AV59nSaldo ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV70EmpRUC ;
      private string AV71Ruta ;
      private string AV67FechaC ;
      private string AV68cMes ;
      private string GXt_char1 ;
      private string AV13Titulo ;
      private string AV14Periodo ;
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
      private DateTime AV16FechaD ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n109CueGasDebe ;
      private bool returnInSub ;
      private bool BRKCL8 ;
      private string AV146Logo_GXI ;
      private string AV72Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private short aP2_nDig ;
      private IDataStoreProvider pr_default ;
      private string[] P00CL2_A91CueCod ;
      private string[] P00CL2_A109CueGasDebe ;
      private bool[] P00CL2_n109CueGasDebe ;
      private string[] P00CL2_A860CueDsc ;
      private short[] P00CL2_A868CueRef1 ;
      private short[] P00CL2_A869CueRef2 ;
      private short[] P00CL2_A870CueRef3 ;
      private short[] P00CL2_A872CueRef5 ;
      private string[] P00CL3_A91CueCod ;
      private string[] P00CL3_A109CueGasDebe ;
      private bool[] P00CL3_n109CueGasDebe ;
      private string[] P00CL3_A860CueDsc ;
      private short[] P00CL3_A868CueRef1 ;
      private short[] P00CL3_A869CueRef2 ;
      private short[] P00CL3_A870CueRef3 ;
      private short[] P00CL3_A872CueRef5 ;
      private decimal[] P00CL4_A2051VouDDeb ;
      private decimal[] P00CL4_A2055VouDHab ;
      private int[] P00CL5_A126TASICod ;
      private string[] P00CL5_A129VouNum ;
      private string[] P00CL5_A91CueCod ;
      private short[] P00CL5_A2077VouSts ;
      private short[] P00CL5_A128VouMes ;
      private short[] P00CL5_A127VouAno ;
      private int[] P00CL5_A130VouDSec ;
      private string[] P00CL6_A123SalCueCod ;
      private short[] P00CL6_A122SalVouMes ;
      private short[] P00CL6_A121SalVouAno ;
      private int[] P00CL6_A124SalMonCod ;
      private string[] P00CL6_A125SalCueAux ;
      private string[] P00CL7_A133CueCodAux ;
      private string[] P00CL7_A91CueCod ;
      private short[] P00CL7_A127VouAno ;
      private string[] P00CL7_A2053VouDDoc ;
      private string[] P00CL7_A860CueDsc ;
      private short[] P00CL7_A868CueRef1 ;
      private short[] P00CL7_A869CueRef2 ;
      private short[] P00CL7_A870CueRef3 ;
      private short[] P00CL7_A872CueRef5 ;
      private short[] P00CL7_A128VouMes ;
      private int[] P00CL7_A126TASICod ;
      private string[] P00CL7_A129VouNum ;
      private int[] P00CL7_A130VouDSec ;
   }

   public class rrlibro3_17__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CL2;
          prmP00CL2 = new Object[] {
          new ParDef("@AV69nDig",GXType.Int16,2,0)
          };
          Object[] prmP00CL3;
          prmP00CL3 = new Object[] {
          };
          Object[] prmP00CL4;
          prmP00CL4 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV49nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00CL5;
          prmP00CL5 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV69nDig",GXType.Int16,2,0) ,
          new ParDef("@AV73Cuenta",GXType.Char,15,0)
          };
          Object[] prmP00CL6;
          prmP00CL6 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV86MesAnt",GXType.Int16,2,0) ,
          new ParDef("@AV69nDig",GXType.Int16,2,0) ,
          new ParDef("@AV73Cuenta",GXType.Char,15,0)
          };
          Object[] prmP00CL7;
          prmP00CL7 = new Object[] {
          new ParDef("@AV69nDig",GXType.Int16,2,0) ,
          new ParDef("@AV73Cuenta",GXType.Char,15,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CL2", "SELECT [CueCod], [CueGasDebe], [CueDsc], [CueRef1], [CueRef2], [CueRef3], [CueRef5] FROM [CBPLANCUENTA] WHERE LEN([CueCod]) = @AV69nDig ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CL3", "SELECT [CueCod], [CueGasDebe], [CueDsc], [CueRef1], [CueRef2], [CueRef3], [CueRef5] FROM [CBPLANCUENTA] WHERE LEN([CueCod]) = 2 ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CL4", "SELECT SUM(T1.[VouDDeb]), SUM(T1.[VouDHab]) FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV49nCueCod) AND (T2.[VouSts] = 1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CL5", "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T1.[CueCod], T2.[VouSts], T1.[VouMes], T1.[VouAno], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes) AND (SUBSTRING(T1.[CueCod], 1, @AV69nDig) = @AV73Cuenta) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CL6", "SELECT TOP 1 [SalCueCod], [SalVouMes], [SalVouAno], [SalMonCod], [SalCueAux] FROM [CBSALDOMENSUAL] WHERE ([SalVouAno] = @AV11Ano and [SalVouMes] = @AV86MesAnt) AND (SUBSTRING([SalCueCod], 1, @AV69nDig) = @AV73Cuenta) ORDER BY [SalVouAno], [SalVouMes], [SalCueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CL7", "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouAno], T1.[VouDDoc], T2.[CueDsc], T2.[CueRef1], T2.[CueRef2], T2.[CueRef3], T2.[CueRef5], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (SUBSTRING(T1.[CueCod], 1, @AV69nDig) = @AV73Cuenta) AND (T1.[VouAno] = @AV11Ano) ORDER BY T1.[CueCod], T1.[CueCodAux] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL7,100, GxCacheFrequency.OFF ,true,false )
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
