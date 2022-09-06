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
   public class rrlibro3_4 : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.rrlibro3_4.aspx")), "contabilidad.rrlibro3_4.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.rrlibro3_4.aspx")))) ;
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
                  AV34cCuenta1 = GetPar( "cCuenta1");
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

      public rrlibro3_4( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrlibro3_4( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref string aP2_cCuenta1 )
      {
         this.AV11Ano = aP0_Ano;
         this.AV12Mes = aP1_Mes;
         this.AV34cCuenta1 = aP2_cCuenta1;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_cCuenta1=this.AV34cCuenta1;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_cCuenta1);
         return AV34cCuenta1 ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_cCuenta1 )
      {
         rrlibro3_4 objrrlibro3_4;
         objrrlibro3_4 = new rrlibro3_4();
         objrrlibro3_4.AV11Ano = aP0_Ano;
         objrrlibro3_4.AV12Mes = aP1_Mes;
         objrrlibro3_4.AV34cCuenta1 = aP2_cCuenta1;
         objrrlibro3_4.context.SetSubmitInitialConfig(context);
         objrrlibro3_4.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrlibro3_4);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_cCuenta1=this.AV34cCuenta1;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrlibro3_4)stateInfo).executePrivate();
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
            AV52EmpRUC = AV30Session.Get("EmpRUC");
            AV54Ruta = AV30Session.Get("RUTA") + "/Logo.jpg";
            AV53Logo = AV54Ruta;
            AV97Logo_GXI = GXDbFile.PathToUrl( AV54Ruta);
            AV51FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV51FechaC, 2);
            GXt_char1 = AV50cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV50cMes = GXt_char1;
            AV51FechaC = "01/01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV94FecDoc = context.localUtil.CToD( AV51FechaC, 2);
            AV13Titulo = "FORMATO 3.4: LIBRO DE INVENTARIOS Y BALANCES - DETALLE DE SALDO DE LA CUENTA 14";
            AV73Titulo1 = "CUENTAS POR COBRAR AL PERSONAL, A LOS ACCIONISTAS (O SOCIOS),DIRECTORES Y GERENTES";
            AV14Periodo = StringUtil.Upper( AV50cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV47TDebeMO = 0.00m;
            AV48ThaberMO = 0.00m;
            AV24TSaldo = 0.00m;
            AV55TDebePagMo = 0.00m;
            AV56THaberPagMo = 0.00m;
            /* Using cursor P00CE2 */
            pr_default.execute(0, new Object[] {AV11Ano});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKCE3 = false;
               A133CueCodAux = P00CE2_A133CueCodAux[0];
               A91CueCod = P00CE2_A91CueCod[0];
               A127VouAno = P00CE2_A127VouAno[0];
               A860CueDsc = P00CE2_A860CueDsc[0];
               A70TipACod = P00CE2_A70TipACod[0];
               n70TipACod = P00CE2_n70TipACod[0];
               A128VouMes = P00CE2_A128VouMes[0];
               A126TASICod = P00CE2_A126TASICod[0];
               A129VouNum = P00CE2_A129VouNum[0];
               A130VouDSec = P00CE2_A130VouDSec[0];
               A860CueDsc = P00CE2_A860CueDsc[0];
               A70TipACod = P00CE2_A70TipACod[0];
               n70TipACod = P00CE2_n70TipACod[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00CE2_A91CueCod[0], A91CueCod) == 0 ) )
               {
                  BRKCE3 = false;
                  A133CueCodAux = P00CE2_A133CueCodAux[0];
                  A127VouAno = P00CE2_A127VouAno[0];
                  A128VouMes = P00CE2_A128VouMes[0];
                  A126TASICod = P00CE2_A126TASICod[0];
                  A129VouNum = P00CE2_A129VouNum[0];
                  A130VouDSec = P00CE2_A130VouDSec[0];
                  BRKCE3 = true;
                  pr_default.readNext(0);
               }
               AV25CueCod = A91CueCod;
               AV41CueDsc = A860CueDsc;
               AV83TipACod = A70TipACod;
               AV63SaldoDMN = 0.00m;
               AV64SaldoHMN = 0.00m;
               AV47TDebeMO = 0.00m;
               AV48ThaberMO = 0.00m;
               new GeneXus.Programs.contabilidad.pobtienesaldoscuenta(context ).execute( ref  AV25CueCod, ref  AV11Ano, ref  AV12Mes, out  AV63SaldoDMN, out  AV64SaldoHMN, out  AV65SaldoDME, out  AV66SaldoHME) ;
               AV67SaldoMN = (decimal)(AV63SaldoDMN-AV64SaldoHMN);
               AV63SaldoDMN = ((AV67SaldoMN>Convert.ToDecimal(0)) ? AV67SaldoMN : (decimal)(0));
               AV64SaldoHMN = ((AV67SaldoMN<Convert.ToDecimal(0)) ? AV67SaldoMN*-1 : (decimal)(0));
               AV85Flag = 0;
               if ( ! (Convert.ToDecimal(0)==AV63SaldoDMN) || ! (Convert.ToDecimal(0)==AV64SaldoHMN) )
               {
                  AV85Flag = 1;
               }
               /* Execute user subroutine: 'VALIDAMOV' */
               S181 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ( AV85Flag == 1 ) && ! (0==AV83TipACod) )
               {
                  HCE0( false, 22) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 15, Gx_line+3, 94, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41CueDsc, "")), 117, Gx_line+3, 639, Gx_line+18, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+22);
               }
               /* Execute user subroutine: 'AUXILIARES' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! BRKCE3 )
               {
                  BRKCE3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HCE0( false, 58) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Saldo Final Total", 615, Gx_line+27, 712, Gx_line+41, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV24TSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+27, 842, Gx_line+42, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(722, Gx_line+14, 1013, Gx_line+14, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+58);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HCE0( true, 0) ;
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
         /* 'AUXILIARES' Routine */
         returnInSub = false;
         if ( AV83TipACod > 0 )
         {
            AV22TDebe = 0.00m;
            AV23THaber = 0.00m;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV74CueCodAux ,
                                                 A133CueCodAux ,
                                                 A127VouAno ,
                                                 AV11Ano ,
                                                 A91CueCod ,
                                                 AV25CueCod } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00CE3 */
            pr_default.execute(1, new Object[] {AV11Ano, AV25CueCod, AV74CueCodAux});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRKCE5 = false;
               A91CueCod = P00CE3_A91CueCod[0];
               A133CueCodAux = P00CE3_A133CueCodAux[0];
               A127VouAno = P00CE3_A127VouAno[0];
               A128VouMes = P00CE3_A128VouMes[0];
               A126TASICod = P00CE3_A126TASICod[0];
               A129VouNum = P00CE3_A129VouNum[0];
               A130VouDSec = P00CE3_A130VouDSec[0];
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00CE3_A133CueCodAux[0], A133CueCodAux) == 0 ) )
               {
                  BRKCE5 = false;
                  A91CueCod = P00CE3_A91CueCod[0];
                  A127VouAno = P00CE3_A127VouAno[0];
                  A128VouMes = P00CE3_A128VouMes[0];
                  A126TASICod = P00CE3_A126TASICod[0];
                  A129VouNum = P00CE3_A129VouNum[0];
                  A130VouDSec = P00CE3_A130VouDSec[0];
                  BRKCE5 = true;
                  pr_default.readNext(1);
               }
               AV78CueDAxu = A133CueCodAux;
               /* Execute user subroutine: 'NOMBREAUXILIAR' */
               S125 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               AV79SaldoDAMN = 0.00m;
               AV80SaldoHAMN = 0.00m;
               AV88TotalSDMN = 0.00m;
               AV89TotalSHMN = 0.00m;
               AV86Flag1 = 0;
               new GeneXus.Programs.contabilidad.pobtienesaldoscuentaauxiliar(context ).execute( ref  AV25CueCod, ref  AV78CueDAxu, ref  AV11Ano, ref  AV12Mes, out  AV79SaldoDAMN, out  AV80SaldoHAMN, out  AV81SaldoDAME, out  AV82SaldoHAME) ;
               AV67SaldoMN = (decimal)(AV79SaldoDAMN-AV80SaldoHAMN);
               AV79SaldoDAMN = ((AV67SaldoMN>Convert.ToDecimal(0)) ? AV67SaldoMN : (decimal)(0));
               AV80SaldoHAMN = ((AV67SaldoMN<Convert.ToDecimal(0)) ? AV67SaldoMN*-1 : (decimal)(0));
               if ( ! (Convert.ToDecimal(0)==AV79SaldoDAMN) || ! (Convert.ToDecimal(0)==AV80SaldoHAMN) )
               {
                  AV86Flag1 = 1;
               }
               AV88TotalSDMN = AV79SaldoDAMN;
               AV89TotalSHMN = AV80SaldoHAMN;
               /* Execute user subroutine: 'VALIDAMOVAUXILIAR' */
               S135 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'MOVIMIENTOSAUXILIAR' */
               S145 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               AV22TDebe = (decimal)(AV22TDebe+AV88TotalSDMN);
               AV23THaber = (decimal)(AV23THaber+AV89TotalSHMN);
               if ( AV86Flag1 == 1 )
               {
                  AV75DifMN = (decimal)(AV88TotalSDMN-AV89TotalSHMN);
                  AV24TSaldo = (decimal)(AV24TSaldo+AV75DifMN);
                  if ( ( AV75DifMN != Convert.ToDecimal( 0 )) )
                  {
                     /* Execute user subroutine: 'DATOSADICIONALES' */
                     S155 ();
                     if ( returnInSub )
                     {
                        pr_default.close(1);
                        returnInSub = true;
                        if (true) return;
                     }
                     HCE0( false, 17) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75DifMN, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+0, 842, Gx_line+15, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76TipAbr, "")), 15, Gx_line+0, 68, Gx_line+15, 1+256, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77CueDAxuDsc, "")), 205, Gx_line+0, 646, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78CueDAxu, "")), 77, Gx_line+0, 182, Gx_line+15, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV94FecDoc, "99/99/99"), 916, Gx_line+0, 963, Gx_line+15, 0+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                  }
               }
               if ( ! BRKCE5 )
               {
                  BRKCE5 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
         }
         else
         {
            AV78CueDAxu = "";
            AV88TotalSDMN = AV63SaldoDMN;
            AV89TotalSHMN = AV64SaldoHMN;
            AV22TDebe = 0.00m;
            AV23THaber = 0.00m;
            /* Execute user subroutine: 'MOVIMIENTOS' */
            S161 ();
            if (returnInSub) return;
            AV75DifMN = (decimal)(AV88TotalSDMN-AV89TotalSHMN);
            AV24TSaldo = (decimal)(AV24TSaldo+AV75DifMN);
            if ( ( AV75DifMN != Convert.ToDecimal( 0 )) )
            {
               /* Execute user subroutine: 'DATOSADICIONALES' */
               S155 ();
               if (returnInSub) return;
               HCE0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 15, Gx_line+3, 94, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41CueDsc, "")), 117, Gx_line+3, 639, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75DifMN, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+3, 842, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV94FecDoc, "99/99/99"), 916, Gx_line+3, 963, Gx_line+18, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
            AV22TDebe = (decimal)(AV22TDebe+AV88TotalSDMN);
            AV23THaber = (decimal)(AV23THaber+AV89TotalSHMN);
         }
         AV47TDebeMO = AV22TDebe;
         AV48ThaberMO = AV23THaber;
         AV55TDebePagMo = (decimal)(AV55TDebePagMo+AV47TDebeMO);
         AV56THaberPagMo = (decimal)(AV56THaberPagMo+AV48ThaberMO);
         if ( AV85Flag == 1 )
         {
            AV75DifMN = (decimal)(AV47TDebeMO-AV48ThaberMO);
            HCE0( false, 30) ;
            getPrinter().GxDrawLine(722, Gx_line+5, 1015, Gx_line+5, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Sub Total - ", 581, Gx_line+10, 649, Gx_line+24, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75DifMN, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+10, 842, Gx_line+25, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 652, Gx_line+10, 747, Gx_line+25, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+30);
         }
      }

      protected void S125( )
      {
         /* 'NOMBREAUXILIAR' Routine */
         returnInSub = false;
         AV103GXLvl177 = 0;
         /* Using cursor P00CE4 */
         pr_default.execute(2, new Object[] {AV83TipACod, AV78CueDAxu});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A71TipADCod = P00CE4_A71TipADCod[0];
            A70TipACod = P00CE4_A70TipACod[0];
            n70TipACod = P00CE4_n70TipACod[0];
            A72TipADDsc = P00CE4_A72TipADDsc[0];
            AV103GXLvl177 = 1;
            AV77CueDAxuDsc = A72TipADDsc;
            /* Execute user subroutine: 'TIPODOCUMENTO' */
            S177 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( AV103GXLvl177 == 0 )
         {
            AV77CueDAxuDsc = "SIN AUXILIAR";
         }
      }

      protected void S177( )
      {
         /* 'TIPODOCUMENTO' Routine */
         returnInSub = false;
         AV76TipAbr = ((StringUtil.Len( StringUtil.Trim( AV78CueDAxu))==11) ? "6" : "1");
      }

      protected void S161( )
      {
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV33cCosto ,
                                              A79COSCod ,
                                              A127VouAno ,
                                              AV11Ano ,
                                              A128VouMes ,
                                              AV12Mes ,
                                              A2077VouSts ,
                                              AV25CueCod ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CE5 */
         pr_default.execute(3, new Object[] {AV25CueCod, AV11Ano, AV12Mes, AV33cCosto});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A126TASICod = P00CE5_A126TASICod[0];
            A129VouNum = P00CE5_A129VouNum[0];
            A2077VouSts = P00CE5_A2077VouSts[0];
            A79COSCod = P00CE5_A79COSCod[0];
            n79COSCod = P00CE5_n79COSCod[0];
            A91CueCod = P00CE5_A91CueCod[0];
            A128VouMes = P00CE5_A128VouMes[0];
            A127VouAno = P00CE5_A127VouAno[0];
            A2069VouDTcmb = P00CE5_A2069VouDTcmb[0];
            A2075VouGls = P00CE5_A2075VouGls[0];
            A132VouDTipCod = P00CE5_A132VouDTipCod[0];
            A2054VouDGls = P00CE5_A2054VouDGls[0];
            A2051VouDDeb = P00CE5_A2051VouDDeb[0];
            A2055VouDHab = P00CE5_A2055VouDHab[0];
            A135VouDFec = P00CE5_A135VouDFec[0];
            A130VouDSec = P00CE5_A130VouDSec[0];
            A2077VouSts = P00CE5_A2077VouSts[0];
            A2075VouGls = P00CE5_A2075VouGls[0];
            AV49Glosa = StringUtil.Trim( A2075VouGls);
            AV93VouDTipCod = A132VouDTipCod;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV49Glosa = StringUtil.Trim( A2054VouDGls);
            }
            AV88TotalSDMN = (decimal)(AV88TotalSDMN+A2051VouDDeb);
            AV89TotalSHMN = (decimal)(AV89TotalSHMN+A2055VouDHab);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S145( )
      {
         /* 'MOVIMIENTOSAUXILIAR' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV33cCosto ,
                                              A79COSCod ,
                                              A127VouAno ,
                                              AV11Ano ,
                                              A128VouMes ,
                                              AV12Mes ,
                                              A133CueCodAux ,
                                              AV78CueDAxu ,
                                              A2077VouSts ,
                                              AV25CueCod ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CE6 */
         pr_default.execute(4, new Object[] {AV25CueCod, AV11Ano, AV12Mes, AV78CueDAxu, AV33cCosto});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A126TASICod = P00CE6_A126TASICod[0];
            A129VouNum = P00CE6_A129VouNum[0];
            A2077VouSts = P00CE6_A2077VouSts[0];
            A79COSCod = P00CE6_A79COSCod[0];
            n79COSCod = P00CE6_n79COSCod[0];
            A133CueCodAux = P00CE6_A133CueCodAux[0];
            A91CueCod = P00CE6_A91CueCod[0];
            A128VouMes = P00CE6_A128VouMes[0];
            A127VouAno = P00CE6_A127VouAno[0];
            A2069VouDTcmb = P00CE6_A2069VouDTcmb[0];
            A2075VouGls = P00CE6_A2075VouGls[0];
            A132VouDTipCod = P00CE6_A132VouDTipCod[0];
            A2054VouDGls = P00CE6_A2054VouDGls[0];
            A2051VouDDeb = P00CE6_A2051VouDDeb[0];
            A2055VouDHab = P00CE6_A2055VouDHab[0];
            A135VouDFec = P00CE6_A135VouDFec[0];
            A130VouDSec = P00CE6_A130VouDSec[0];
            A2077VouSts = P00CE6_A2077VouSts[0];
            A2075VouGls = P00CE6_A2075VouGls[0];
            AV49Glosa = StringUtil.Trim( A2075VouGls);
            AV93VouDTipCod = A132VouDTipCod;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV49Glosa = StringUtil.Trim( A2054VouDGls);
            }
            AV88TotalSDMN = (decimal)(AV88TotalSDMN+A2051VouDDeb);
            AV89TotalSHMN = (decimal)(AV89TotalSHMN+A2055VouDHab);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S181( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV33cCosto ,
                                              A79COSCod ,
                                              A2077VouSts ,
                                              AV11Ano ,
                                              AV12Mes ,
                                              AV25CueCod ,
                                              A127VouAno ,
                                              A128VouMes ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CE7 */
         pr_default.execute(5, new Object[] {AV11Ano, AV12Mes, AV25CueCod, AV33cCosto});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A126TASICod = P00CE7_A126TASICod[0];
            A129VouNum = P00CE7_A129VouNum[0];
            A79COSCod = P00CE7_A79COSCod[0];
            n79COSCod = P00CE7_n79COSCod[0];
            A2077VouSts = P00CE7_A2077VouSts[0];
            A91CueCod = P00CE7_A91CueCod[0];
            A128VouMes = P00CE7_A128VouMes[0];
            A127VouAno = P00CE7_A127VouAno[0];
            A2069VouDTcmb = P00CE7_A2069VouDTcmb[0];
            A130VouDSec = P00CE7_A130VouDSec[0];
            A2077VouSts = P00CE7_A2077VouSts[0];
            AV85Flag = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S135( )
      {
         /* 'VALIDAMOVAUXILIAR' Routine */
         returnInSub = false;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV33cCosto ,
                                              A79COSCod ,
                                              A2077VouSts ,
                                              AV11Ano ,
                                              AV12Mes ,
                                              AV25CueCod ,
                                              AV78CueDAxu ,
                                              A127VouAno ,
                                              A128VouMes ,
                                              A91CueCod ,
                                              A133CueCodAux } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CE8 */
         pr_default.execute(6, new Object[] {AV11Ano, AV12Mes, AV25CueCod, AV78CueDAxu, AV33cCosto});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A126TASICod = P00CE8_A126TASICod[0];
            A129VouNum = P00CE8_A129VouNum[0];
            A2077VouSts = P00CE8_A2077VouSts[0];
            A79COSCod = P00CE8_A79COSCod[0];
            n79COSCod = P00CE8_n79COSCod[0];
            A133CueCodAux = P00CE8_A133CueCodAux[0];
            A91CueCod = P00CE8_A91CueCod[0];
            A128VouMes = P00CE8_A128VouMes[0];
            A127VouAno = P00CE8_A127VouAno[0];
            A2069VouDTcmb = P00CE8_A2069VouDTcmb[0];
            A130VouDSec = P00CE8_A130VouDSec[0];
            A2077VouSts = P00CE8_A2077VouSts[0];
            AV86Flag1 = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S155( )
      {
         /* 'DATOSADICIONALES' Routine */
         returnInSub = false;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV78CueDAxu ,
                                              A133CueCodAux ,
                                              A2074VouFec ,
                                              AV11Ano ,
                                              A91CueCod ,
                                              AV25CueCod } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CE9 */
         pr_default.execute(7, new Object[] {AV11Ano, AV25CueCod, AV78CueDAxu});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A127VouAno = P00CE9_A127VouAno[0];
            A128VouMes = P00CE9_A128VouMes[0];
            A126TASICod = P00CE9_A126TASICod[0];
            A129VouNum = P00CE9_A129VouNum[0];
            A91CueCod = P00CE9_A91CueCod[0];
            A133CueCodAux = P00CE9_A133CueCodAux[0];
            A2074VouFec = P00CE9_A2074VouFec[0];
            A135VouDFec = P00CE9_A135VouDFec[0];
            A130VouDSec = P00CE9_A130VouDSec[0];
            A2074VouFec = P00CE9_A2074VouFec[0];
            AV94FecDoc = A135VouDFec;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void HCE0( bool bFoot ,
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
               getPrinter().GxDrawText("P�gina:", 919, Gx_line+15, 963, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 974, Gx_line+15, 1013, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 14, Gx_line+4, 640, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 88, Gx_line+50, 714, Gx_line+68, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 14, Gx_line+86, 419, Gx_line+103, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52EmpRUC, "")), 88, Gx_line+68, 214, Gx_line+86, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 14, Gx_line+50, 79, Gx_line+68, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 14, Gx_line+68, 50, Gx_line+86, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73Titulo1, "")), 14, Gx_line+22, 640, Gx_line+40, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+111);
               getPrinter().GxDrawLine(75, Gx_line+35, 75, Gx_line+64, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(701, Gx_line+1, 701, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("MONTO DE LA", 747, Gx_line+15, 825, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 1014, Gx_line+65, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("CUENTA POR COBRAR", 724, Gx_line+30, 848, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DOCUMENTO DE IDENTIDAD", 23, Gx_line+21, 181, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(203, Gx_line+19, 203, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(859, Gx_line+0, 859, Gx_line+64, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("FECHA DE EMISI�N", 880, Gx_line+8, 988, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("APELLIDOS Y NOMBRES,", 422, Gx_line+24, 558, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("INFORMACI�N DEL ACCIONISTA, SOCIO O PERSONAL", 125, Gx_line+3, 424, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("TIPO", 23, Gx_line+45, 52, Gx_line+59, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+18, 701, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("DENOMINACI�N O RAZ�N SOCIAL", 395, Gx_line+44, 586, Gx_line+58, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+35, 204, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N�MERO", 114, Gx_line+45, 164, Gx_line+59, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DE PAGO", 909, Gx_line+41, 960, Gx_line+55, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DEL COMPROBANTE", 879, Gx_line+25, 990, Gx_line+39, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+65);
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
         AV52EmpRUC = "";
         AV54Ruta = "";
         AV53Logo = "";
         AV97Logo_GXI = "";
         AV51FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV50cMes = "";
         GXt_char1 = "";
         AV94FecDoc = DateTime.MinValue;
         AV13Titulo = "";
         AV73Titulo1 = "";
         AV14Periodo = "";
         scmdbuf = "";
         P00CE2_A133CueCodAux = new string[] {""} ;
         P00CE2_A91CueCod = new string[] {""} ;
         P00CE2_A127VouAno = new short[1] ;
         P00CE2_A860CueDsc = new string[] {""} ;
         P00CE2_A70TipACod = new int[1] ;
         P00CE2_n70TipACod = new bool[] {false} ;
         P00CE2_A128VouMes = new short[1] ;
         P00CE2_A126TASICod = new int[1] ;
         P00CE2_A129VouNum = new string[] {""} ;
         P00CE2_A130VouDSec = new int[1] ;
         A133CueCodAux = "";
         A91CueCod = "";
         A860CueDsc = "";
         A129VouNum = "";
         AV25CueCod = "";
         AV41CueDsc = "";
         AV74CueCodAux = "";
         P00CE3_A91CueCod = new string[] {""} ;
         P00CE3_A133CueCodAux = new string[] {""} ;
         P00CE3_A127VouAno = new short[1] ;
         P00CE3_A128VouMes = new short[1] ;
         P00CE3_A126TASICod = new int[1] ;
         P00CE3_A129VouNum = new string[] {""} ;
         P00CE3_A130VouDSec = new int[1] ;
         AV78CueDAxu = "";
         AV76TipAbr = "";
         AV77CueDAxuDsc = "";
         P00CE4_A71TipADCod = new string[] {""} ;
         P00CE4_A70TipACod = new int[1] ;
         P00CE4_n70TipACod = new bool[] {false} ;
         P00CE4_A72TipADDsc = new string[] {""} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         AV33cCosto = "";
         A79COSCod = "";
         P00CE5_A126TASICod = new int[1] ;
         P00CE5_A129VouNum = new string[] {""} ;
         P00CE5_A2077VouSts = new short[1] ;
         P00CE5_A79COSCod = new string[] {""} ;
         P00CE5_n79COSCod = new bool[] {false} ;
         P00CE5_A91CueCod = new string[] {""} ;
         P00CE5_A128VouMes = new short[1] ;
         P00CE5_A127VouAno = new short[1] ;
         P00CE5_A2069VouDTcmb = new decimal[1] ;
         P00CE5_A2075VouGls = new string[] {""} ;
         P00CE5_A132VouDTipCod = new string[] {""} ;
         P00CE5_A2054VouDGls = new string[] {""} ;
         P00CE5_A2051VouDDeb = new decimal[1] ;
         P00CE5_A2055VouDHab = new decimal[1] ;
         P00CE5_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00CE5_A130VouDSec = new int[1] ;
         A2075VouGls = "";
         A132VouDTipCod = "";
         A2054VouDGls = "";
         A135VouDFec = DateTime.MinValue;
         AV49Glosa = "";
         AV93VouDTipCod = "";
         P00CE6_A126TASICod = new int[1] ;
         P00CE6_A129VouNum = new string[] {""} ;
         P00CE6_A2077VouSts = new short[1] ;
         P00CE6_A79COSCod = new string[] {""} ;
         P00CE6_n79COSCod = new bool[] {false} ;
         P00CE6_A133CueCodAux = new string[] {""} ;
         P00CE6_A91CueCod = new string[] {""} ;
         P00CE6_A128VouMes = new short[1] ;
         P00CE6_A127VouAno = new short[1] ;
         P00CE6_A2069VouDTcmb = new decimal[1] ;
         P00CE6_A2075VouGls = new string[] {""} ;
         P00CE6_A132VouDTipCod = new string[] {""} ;
         P00CE6_A2054VouDGls = new string[] {""} ;
         P00CE6_A2051VouDDeb = new decimal[1] ;
         P00CE6_A2055VouDHab = new decimal[1] ;
         P00CE6_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00CE6_A130VouDSec = new int[1] ;
         P00CE7_A126TASICod = new int[1] ;
         P00CE7_A129VouNum = new string[] {""} ;
         P00CE7_A79COSCod = new string[] {""} ;
         P00CE7_n79COSCod = new bool[] {false} ;
         P00CE7_A2077VouSts = new short[1] ;
         P00CE7_A91CueCod = new string[] {""} ;
         P00CE7_A128VouMes = new short[1] ;
         P00CE7_A127VouAno = new short[1] ;
         P00CE7_A2069VouDTcmb = new decimal[1] ;
         P00CE7_A130VouDSec = new int[1] ;
         P00CE8_A126TASICod = new int[1] ;
         P00CE8_A129VouNum = new string[] {""} ;
         P00CE8_A2077VouSts = new short[1] ;
         P00CE8_A79COSCod = new string[] {""} ;
         P00CE8_n79COSCod = new bool[] {false} ;
         P00CE8_A133CueCodAux = new string[] {""} ;
         P00CE8_A91CueCod = new string[] {""} ;
         P00CE8_A128VouMes = new short[1] ;
         P00CE8_A127VouAno = new short[1] ;
         P00CE8_A2069VouDTcmb = new decimal[1] ;
         P00CE8_A130VouDSec = new int[1] ;
         A2074VouFec = DateTime.MinValue;
         P00CE9_A127VouAno = new short[1] ;
         P00CE9_A128VouMes = new short[1] ;
         P00CE9_A126TASICod = new int[1] ;
         P00CE9_A129VouNum = new string[] {""} ;
         P00CE9_A91CueCod = new string[] {""} ;
         P00CE9_A133CueCodAux = new string[] {""} ;
         P00CE9_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         P00CE9_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00CE9_A130VouDSec = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rrlibro3_4__default(),
            new Object[][] {
                new Object[] {
               P00CE2_A133CueCodAux, P00CE2_A91CueCod, P00CE2_A127VouAno, P00CE2_A860CueDsc, P00CE2_A70TipACod, P00CE2_n70TipACod, P00CE2_A128VouMes, P00CE2_A126TASICod, P00CE2_A129VouNum, P00CE2_A130VouDSec
               }
               , new Object[] {
               P00CE3_A91CueCod, P00CE3_A133CueCodAux, P00CE3_A127VouAno, P00CE3_A128VouMes, P00CE3_A126TASICod, P00CE3_A129VouNum, P00CE3_A130VouDSec
               }
               , new Object[] {
               P00CE4_A71TipADCod, P00CE4_A70TipACod, P00CE4_A72TipADDsc
               }
               , new Object[] {
               P00CE5_A126TASICod, P00CE5_A129VouNum, P00CE5_A2077VouSts, P00CE5_A79COSCod, P00CE5_n79COSCod, P00CE5_A91CueCod, P00CE5_A128VouMes, P00CE5_A127VouAno, P00CE5_A2069VouDTcmb, P00CE5_A2075VouGls,
               P00CE5_A132VouDTipCod, P00CE5_A2054VouDGls, P00CE5_A2051VouDDeb, P00CE5_A2055VouDHab, P00CE5_A135VouDFec, P00CE5_A130VouDSec
               }
               , new Object[] {
               P00CE6_A126TASICod, P00CE6_A129VouNum, P00CE6_A2077VouSts, P00CE6_A79COSCod, P00CE6_n79COSCod, P00CE6_A133CueCodAux, P00CE6_A91CueCod, P00CE6_A128VouMes, P00CE6_A127VouAno, P00CE6_A2069VouDTcmb,
               P00CE6_A2075VouGls, P00CE6_A132VouDTipCod, P00CE6_A2054VouDGls, P00CE6_A2051VouDDeb, P00CE6_A2055VouDHab, P00CE6_A135VouDFec, P00CE6_A130VouDSec
               }
               , new Object[] {
               P00CE7_A126TASICod, P00CE7_A129VouNum, P00CE7_A79COSCod, P00CE7_n79COSCod, P00CE7_A2077VouSts, P00CE7_A91CueCod, P00CE7_A128VouMes, P00CE7_A127VouAno, P00CE7_A2069VouDTcmb, P00CE7_A130VouDSec
               }
               , new Object[] {
               P00CE8_A126TASICod, P00CE8_A129VouNum, P00CE8_A2077VouSts, P00CE8_A79COSCod, P00CE8_n79COSCod, P00CE8_A133CueCodAux, P00CE8_A91CueCod, P00CE8_A128VouMes, P00CE8_A127VouAno, P00CE8_A2069VouDTcmb,
               P00CE8_A130VouDSec
               }
               , new Object[] {
               P00CE9_A127VouAno, P00CE9_A128VouMes, P00CE9_A126TASICod, P00CE9_A129VouNum, P00CE9_A91CueCod, P00CE9_A133CueCodAux, P00CE9_A2074VouFec, P00CE9_A135VouDFec, P00CE9_A130VouDSec
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
      private short A127VouAno ;
      private short A128VouMes ;
      private short AV85Flag ;
      private short AV86Flag1 ;
      private short AV103GXLvl177 ;
      private short A2077VouSts ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A70TipACod ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int AV83TipACod ;
      private int Gx_OldLine ;
      private decimal AV47TDebeMO ;
      private decimal AV48ThaberMO ;
      private decimal AV24TSaldo ;
      private decimal AV55TDebePagMo ;
      private decimal AV56THaberPagMo ;
      private decimal AV63SaldoDMN ;
      private decimal AV64SaldoHMN ;
      private decimal AV65SaldoDME ;
      private decimal AV66SaldoHME ;
      private decimal AV67SaldoMN ;
      private decimal AV22TDebe ;
      private decimal AV23THaber ;
      private decimal AV79SaldoDAMN ;
      private decimal AV80SaldoHAMN ;
      private decimal AV88TotalSDMN ;
      private decimal AV89TotalSHMN ;
      private decimal AV81SaldoDAME ;
      private decimal AV82SaldoHAME ;
      private decimal AV75DifMN ;
      private decimal A2069VouDTcmb ;
      private decimal A2051VouDDeb ;
      private decimal A2055VouDHab ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV34cCuenta1 ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV52EmpRUC ;
      private string AV54Ruta ;
      private string AV51FechaC ;
      private string AV50cMes ;
      private string GXt_char1 ;
      private string AV13Titulo ;
      private string AV73Titulo1 ;
      private string AV14Periodo ;
      private string scmdbuf ;
      private string A133CueCodAux ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string A129VouNum ;
      private string AV25CueCod ;
      private string AV41CueDsc ;
      private string AV74CueCodAux ;
      private string AV78CueDAxu ;
      private string AV76TipAbr ;
      private string AV77CueDAxuDsc ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string AV33cCosto ;
      private string A79COSCod ;
      private string A2075VouGls ;
      private string A132VouDTipCod ;
      private string A2054VouDGls ;
      private string AV49Glosa ;
      private string AV93VouDTipCod ;
      private DateTime AV16FechaD ;
      private DateTime AV94FecDoc ;
      private DateTime A135VouDFec ;
      private DateTime A2074VouFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKCE3 ;
      private bool n70TipACod ;
      private bool returnInSub ;
      private bool BRKCE5 ;
      private bool n79COSCod ;
      private string AV97Logo_GXI ;
      private string AV53Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_cCuenta1 ;
      private IDataStoreProvider pr_default ;
      private string[] P00CE2_A133CueCodAux ;
      private string[] P00CE2_A91CueCod ;
      private short[] P00CE2_A127VouAno ;
      private string[] P00CE2_A860CueDsc ;
      private int[] P00CE2_A70TipACod ;
      private bool[] P00CE2_n70TipACod ;
      private short[] P00CE2_A128VouMes ;
      private int[] P00CE2_A126TASICod ;
      private string[] P00CE2_A129VouNum ;
      private int[] P00CE2_A130VouDSec ;
      private string[] P00CE3_A91CueCod ;
      private string[] P00CE3_A133CueCodAux ;
      private short[] P00CE3_A127VouAno ;
      private short[] P00CE3_A128VouMes ;
      private int[] P00CE3_A126TASICod ;
      private string[] P00CE3_A129VouNum ;
      private int[] P00CE3_A130VouDSec ;
      private string[] P00CE4_A71TipADCod ;
      private int[] P00CE4_A70TipACod ;
      private bool[] P00CE4_n70TipACod ;
      private string[] P00CE4_A72TipADDsc ;
      private int[] P00CE5_A126TASICod ;
      private string[] P00CE5_A129VouNum ;
      private short[] P00CE5_A2077VouSts ;
      private string[] P00CE5_A79COSCod ;
      private bool[] P00CE5_n79COSCod ;
      private string[] P00CE5_A91CueCod ;
      private short[] P00CE5_A128VouMes ;
      private short[] P00CE5_A127VouAno ;
      private decimal[] P00CE5_A2069VouDTcmb ;
      private string[] P00CE5_A2075VouGls ;
      private string[] P00CE5_A132VouDTipCod ;
      private string[] P00CE5_A2054VouDGls ;
      private decimal[] P00CE5_A2051VouDDeb ;
      private decimal[] P00CE5_A2055VouDHab ;
      private DateTime[] P00CE5_A135VouDFec ;
      private int[] P00CE5_A130VouDSec ;
      private int[] P00CE6_A126TASICod ;
      private string[] P00CE6_A129VouNum ;
      private short[] P00CE6_A2077VouSts ;
      private string[] P00CE6_A79COSCod ;
      private bool[] P00CE6_n79COSCod ;
      private string[] P00CE6_A133CueCodAux ;
      private string[] P00CE6_A91CueCod ;
      private short[] P00CE6_A128VouMes ;
      private short[] P00CE6_A127VouAno ;
      private decimal[] P00CE6_A2069VouDTcmb ;
      private string[] P00CE6_A2075VouGls ;
      private string[] P00CE6_A132VouDTipCod ;
      private string[] P00CE6_A2054VouDGls ;
      private decimal[] P00CE6_A2051VouDDeb ;
      private decimal[] P00CE6_A2055VouDHab ;
      private DateTime[] P00CE6_A135VouDFec ;
      private int[] P00CE6_A130VouDSec ;
      private int[] P00CE7_A126TASICod ;
      private string[] P00CE7_A129VouNum ;
      private string[] P00CE7_A79COSCod ;
      private bool[] P00CE7_n79COSCod ;
      private short[] P00CE7_A2077VouSts ;
      private string[] P00CE7_A91CueCod ;
      private short[] P00CE7_A128VouMes ;
      private short[] P00CE7_A127VouAno ;
      private decimal[] P00CE7_A2069VouDTcmb ;
      private int[] P00CE7_A130VouDSec ;
      private int[] P00CE8_A126TASICod ;
      private string[] P00CE8_A129VouNum ;
      private short[] P00CE8_A2077VouSts ;
      private string[] P00CE8_A79COSCod ;
      private bool[] P00CE8_n79COSCod ;
      private string[] P00CE8_A133CueCodAux ;
      private string[] P00CE8_A91CueCod ;
      private short[] P00CE8_A128VouMes ;
      private short[] P00CE8_A127VouAno ;
      private decimal[] P00CE8_A2069VouDTcmb ;
      private int[] P00CE8_A130VouDSec ;
      private short[] P00CE9_A127VouAno ;
      private short[] P00CE9_A128VouMes ;
      private int[] P00CE9_A126TASICod ;
      private string[] P00CE9_A129VouNum ;
      private string[] P00CE9_A91CueCod ;
      private string[] P00CE9_A133CueCodAux ;
      private DateTime[] P00CE9_A2074VouFec ;
      private DateTime[] P00CE9_A135VouDFec ;
      private int[] P00CE9_A130VouDSec ;
   }

   public class rrlibro3_4__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CE3( IGxContext context ,
                                             string AV74CueCodAux ,
                                             string A133CueCodAux ,
                                             short A127VouAno ,
                                             short AV11Ano ,
                                             string A91CueCod ,
                                             string AV25CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[3];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [CueCod], [CueCodAux], [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET]";
         AddWhere(sWhereString, "([VouAno] = @AV11Ano)");
         AddWhere(sWhereString, "([CueCod] = @AV25CueCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74CueCodAux)) )
         {
            AddWhere(sWhereString, "([CueCodAux] = @AV74CueCodAux)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueCodAux], [CueCod]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00CE5( IGxContext context ,
                                             string AV33cCosto ,
                                             string A79COSCod ,
                                             short A127VouAno ,
                                             short AV11Ano ,
                                             short A128VouMes ,
                                             short AV12Mes ,
                                             short A2077VouSts ,
                                             string AV25CueCod ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[COSCod], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T2.[VouGls], T1.[VouDTipCod], T1.[VouDGls], T1.[VouDDeb], T1.[VouDHab], T1.[VouDFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV25CueCod)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano)");
         AddWhere(sWhereString, "(T1.[VouMes] = @AV12Mes)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV33cCosto)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[VouDFec]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00CE6( IGxContext context ,
                                             string AV33cCosto ,
                                             string A79COSCod ,
                                             short A127VouAno ,
                                             short AV11Ano ,
                                             short A128VouMes ,
                                             short AV12Mes ,
                                             string A133CueCodAux ,
                                             string AV78CueDAxu ,
                                             short A2077VouSts ,
                                             string AV25CueCod ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[5];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[COSCod], T1.[CueCodAux], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T2.[VouGls], T1.[VouDTipCod], T1.[VouDGls], T1.[VouDDeb], T1.[VouDHab], T1.[VouDFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV25CueCod)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano)");
         AddWhere(sWhereString, "(T1.[VouMes] = @AV12Mes)");
         AddWhere(sWhereString, "(T1.[CueCodAux] = @AV78CueDAxu)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV33cCosto)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[VouDFec]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00CE7( IGxContext context ,
                                             string AV33cCosto ,
                                             string A79COSCod ,
                                             short A2077VouSts ,
                                             short AV11Ano ,
                                             short AV12Mes ,
                                             string AV25CueCod ,
                                             short A127VouAno ,
                                             short A128VouMes ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[4];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T1.[COSCod], T2.[VouSts], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV25CueCod)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV33cCosto)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00CE8( IGxContext context ,
                                             string AV33cCosto ,
                                             string A79COSCod ,
                                             short A2077VouSts ,
                                             short AV11Ano ,
                                             short AV12Mes ,
                                             string AV25CueCod ,
                                             string AV78CueDAxu ,
                                             short A127VouAno ,
                                             short A128VouMes ,
                                             string A91CueCod ,
                                             string A133CueCodAux )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[5];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[COSCod], T1.[CueCodAux], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV25CueCod and T1.[CueCodAux] = @AV78CueDAxu)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV33cCosto)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod], T1.[CueCodAux]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P00CE9( IGxContext context ,
                                             string AV78CueDAxu ,
                                             string A133CueCodAux ,
                                             DateTime A2074VouFec ,
                                             short AV11Ano ,
                                             string A91CueCod ,
                                             string AV25CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[3];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[CueCod], T1.[CueCodAux], T2.[VouFec], T1.[VouDFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(YEAR(T2.[VouFec]) = @AV11Ano)");
         AddWhere(sWhereString, "(T1.[CueCod] = @AV25CueCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78CueDAxu)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV78CueDAxu)");
         }
         else
         {
            GXv_int12[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[VouFec]";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00CE3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] );
               case 3 :
                     return conditional_P00CE5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] );
               case 4 :
                     return conditional_P00CE6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
               case 5 :
                     return conditional_P00CE7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] );
               case 6 :
                     return conditional_P00CE8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
               case 7 :
                     return conditional_P00CE9(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CE2;
          prmP00CE2 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0)
          };
          Object[] prmP00CE4;
          prmP00CE4 = new Object[] {
          new ParDef("@AV83TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV78CueDAxu",GXType.NChar,20,0)
          };
          Object[] prmP00CE3;
          prmP00CE3 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV74CueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00CE5;
          prmP00CE5 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00CE6;
          prmP00CE6 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV78CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00CE7;
          prmP00CE7 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00CE8;
          prmP00CE8 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV78CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00CE9;
          prmP00CE9 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV78CueDAxu",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CE2", "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouAno], T2.[CueDsc], T2.[TipACod], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (SUBSTRING(T1.[CueCod], 1, 2) = '14') AND (T1.[VouAno] = @AV11Ano) ORDER BY T1.[CueCod], T1.[CueCodAux] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CE2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CE3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CE3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CE4", "SELECT [TipADCod], [TipACod], [TipADDsc] FROM [CBAUXILIARES] WHERE [TipACod] = @AV83TipACod and [TipADCod] = @AV78CueDAxu ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CE4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00CE5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CE5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CE6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CE6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CE7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CE7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CE8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CE8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CE9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CE9,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 10);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((string[]) buf[10])[0] = rslt.getString(10, 3);
                ((string[]) buf[11])[0] = rslt.getString(11, 100);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(14);
                ((int[]) buf[15])[0] = rslt.getInt(15);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 15);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 3);
                ((string[]) buf[12])[0] = rslt.getString(12, 100);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(15);
                ((int[]) buf[16])[0] = rslt.getInt(16);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 15);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
