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
   public class rrlibro3_13 : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.rrlibro3_13.aspx")), "contabilidad.rrlibro3_13.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.rrlibro3_13.aspx")))) ;
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

      public rrlibro3_13( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrlibro3_13( IGxContext context )
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
         rrlibro3_13 objrrlibro3_13;
         objrrlibro3_13 = new rrlibro3_13();
         objrrlibro3_13.AV11Ano = aP0_Ano;
         objrrlibro3_13.AV12Mes = aP1_Mes;
         objrrlibro3_13.AV34cCuenta1 = aP2_cCuenta1;
         objrrlibro3_13.context.SetSubmitInitialConfig(context);
         objrrlibro3_13.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrlibro3_13);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_cCuenta1=this.AV34cCuenta1;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrlibro3_13)stateInfo).executePrivate();
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
            AV96Logo_GXI = GXDbFile.PathToUrl( AV54Ruta);
            AV51FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV51FechaC, 2);
            GXt_char1 = AV50cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV50cMes = GXt_char1;
            AV13Titulo = "FORMATO 3.13: LIBRO DE INVENTARIOS Y BALANCES - DETALLE DE SALDO DE LA CUENTA 46 - CUENTAS POR PAGAR DIVERSAS TERCEROS";
            AV14Periodo = StringUtil.Upper( AV50cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV47TDebeMO = 0.00m;
            AV48ThaberMO = 0.00m;
            AV24TSaldo = 0.00m;
            AV55TDebePagMo = 0.00m;
            AV56THaberPagMo = 0.00m;
            /* Using cursor P00CK2 */
            pr_default.execute(0, new Object[] {AV11Ano});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKCK3 = false;
               A133CueCodAux = P00CK2_A133CueCodAux[0];
               A91CueCod = P00CK2_A91CueCod[0];
               A127VouAno = P00CK2_A127VouAno[0];
               A860CueDsc = P00CK2_A860CueDsc[0];
               A70TipACod = P00CK2_A70TipACod[0];
               n70TipACod = P00CK2_n70TipACod[0];
               A128VouMes = P00CK2_A128VouMes[0];
               A126TASICod = P00CK2_A126TASICod[0];
               A129VouNum = P00CK2_A129VouNum[0];
               A130VouDSec = P00CK2_A130VouDSec[0];
               A860CueDsc = P00CK2_A860CueDsc[0];
               A70TipACod = P00CK2_A70TipACod[0];
               n70TipACod = P00CK2_n70TipACod[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00CK2_A91CueCod[0], A91CueCod) == 0 ) )
               {
                  BRKCK3 = false;
                  A133CueCodAux = P00CK2_A133CueCodAux[0];
                  A127VouAno = P00CK2_A127VouAno[0];
                  A128VouMes = P00CK2_A128VouMes[0];
                  A126TASICod = P00CK2_A126TASICod[0];
                  A129VouNum = P00CK2_A129VouNum[0];
                  A130VouDSec = P00CK2_A130VouDSec[0];
                  BRKCK3 = true;
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
                  HCK0( false, 20) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41CueDsc, "")), 126, Gx_line+4, 648, Gx_line+19, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 24, Gx_line+4, 103, Gx_line+19, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
               /* Execute user subroutine: 'AUXILIARES' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! BRKCK3 )
               {
                  BRKCK3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HCK0( false, 58) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Saldo Final Total", 834, Gx_line+23, 931, Gx_line+37, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV24TSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 949, Gx_line+23, 1056, Gx_line+38, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(823, Gx_line+14, 1066, Gx_line+14, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+58);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HCK0( true, 0) ;
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
                                                 AV73CueCodAux ,
                                                 A133CueCodAux ,
                                                 A127VouAno ,
                                                 AV11Ano ,
                                                 A91CueCod ,
                                                 AV25CueCod } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00CK3 */
            pr_default.execute(1, new Object[] {AV11Ano, AV25CueCod, AV73CueCodAux});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRKCK5 = false;
               A91CueCod = P00CK3_A91CueCod[0];
               A133CueCodAux = P00CK3_A133CueCodAux[0];
               A127VouAno = P00CK3_A127VouAno[0];
               A128VouMes = P00CK3_A128VouMes[0];
               A126TASICod = P00CK3_A126TASICod[0];
               A129VouNum = P00CK3_A129VouNum[0];
               A130VouDSec = P00CK3_A130VouDSec[0];
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00CK3_A133CueCodAux[0], A133CueCodAux) == 0 ) )
               {
                  BRKCK5 = false;
                  A91CueCod = P00CK3_A91CueCod[0];
                  A127VouAno = P00CK3_A127VouAno[0];
                  A128VouMes = P00CK3_A128VouMes[0];
                  A126TASICod = P00CK3_A126TASICod[0];
                  A129VouNum = P00CK3_A129VouNum[0];
                  A130VouDSec = P00CK3_A130VouDSec[0];
                  BRKCK5 = true;
                  pr_default.readNext(1);
               }
               AV74CueDAxu = A133CueCodAux;
               /* Execute user subroutine: 'NOMBREAUXILIAR' */
               S125 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               AV78SaldoDAMN = 0.00m;
               AV79SaldoHAMN = 0.00m;
               AV86TotalSDMN = 0.00m;
               AV87TotalSHMN = 0.00m;
               AV90Flag1 = 0;
               new GeneXus.Programs.contabilidad.pobtienesaldoscuentaauxiliar(context ).execute( ref  AV25CueCod, ref  AV74CueDAxu, ref  AV11Ano, ref  AV12Mes, out  AV78SaldoDAMN, out  AV79SaldoHAMN, out  AV80SaldoDAME, out  AV81SaldoHAME) ;
               AV67SaldoMN = (decimal)(AV78SaldoDAMN-AV79SaldoHAMN);
               AV78SaldoDAMN = ((AV67SaldoMN>Convert.ToDecimal(0)) ? AV67SaldoMN : (decimal)(0));
               AV79SaldoHAMN = ((AV67SaldoMN<Convert.ToDecimal(0)) ? AV67SaldoMN*-1 : (decimal)(0));
               if ( ! (Convert.ToDecimal(0)==AV78SaldoDAMN) || ! (Convert.ToDecimal(0)==AV79SaldoHAMN) )
               {
                  AV90Flag1 = 1;
               }
               AV86TotalSDMN = AV78SaldoDAMN;
               AV87TotalSHMN = AV79SaldoHAMN;
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
               AV22TDebe = (decimal)(AV22TDebe+AV86TotalSDMN);
               AV23THaber = (decimal)(AV23THaber+AV87TotalSHMN);
               if ( AV90Flag1 == 1 )
               {
                  AV76DifMN = (decimal)(AV86TotalSDMN-AV87TotalSHMN);
                  AV24TSaldo = (decimal)(AV24TSaldo+AV76DifMN);
                  if ( ( AV76DifMN != Convert.ToDecimal( 0 )) )
                  {
                     /* Execute user subroutine: 'DATOSADICIONALES' */
                     S155 ();
                     if ( returnInSub )
                     {
                        pr_default.close(1);
                        returnInSub = true;
                        if (true) return;
                     }
                     HCK0( false, 19) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Cuenta, "")), 504, Gx_line+2, 820, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV76DifMN, "ZZZZZZ,ZZZ,ZZ9.99")), 949, Gx_line+2, 1056, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV93FecDoc, "99/99/99"), 860, Gx_line+2, 907, Gx_line+17, 0+256, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75CueDAxuDsc, "")), 190, Gx_line+2, 499, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74CueDAxu, "")), 82, Gx_line+2, 187, Gx_line+17, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92TipAbr, "")), 24, Gx_line+2, 77, Gx_line+17, 1+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( ! BRKCK5 )
               {
                  BRKCK5 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
         }
         else
         {
            AV74CueDAxu = "";
            AV86TotalSDMN = AV63SaldoDMN;
            AV87TotalSHMN = AV64SaldoHMN;
            AV22TDebe = 0.00m;
            AV23THaber = 0.00m;
            /* Execute user subroutine: 'MOVIMIENTOS' */
            S161 ();
            if (returnInSub) return;
            AV76DifMN = (decimal)(AV86TotalSDMN-AV87TotalSHMN);
            AV24TSaldo = (decimal)(AV24TSaldo+AV76DifMN);
            if ( ( AV76DifMN != Convert.ToDecimal( 0 )) )
            {
               /* Execute user subroutine: 'DATOSADICIONALES' */
               S155 ();
               if (returnInSub) return;
               HCK0( false, 20) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Cuenta, "")), 504, Gx_line+4, 820, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV76DifMN, "ZZZZZZ,ZZZ,ZZ9.99")), 949, Gx_line+4, 1056, Gx_line+19, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV93FecDoc, "99/99/99"), 860, Gx_line+4, 907, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 24, Gx_line+4, 103, Gx_line+19, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
            AV22TDebe = (decimal)(AV22TDebe+AV86TotalSDMN);
            AV23THaber = (decimal)(AV23THaber+AV87TotalSHMN);
         }
         AV47TDebeMO = AV22TDebe;
         AV48ThaberMO = AV23THaber;
         AV55TDebePagMo = (decimal)(AV55TDebePagMo+AV47TDebeMO);
         AV56THaberPagMo = (decimal)(AV56THaberPagMo+AV48ThaberMO);
         if ( AV85Flag == 1 )
         {
            AV76DifMN = (decimal)(AV47TDebeMO-AV48ThaberMO);
            HCK0( false, 34) ;
            getPrinter().GxDrawLine(823, Gx_line+6, 1066, Gx_line+6, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Sub Total - ", 768, Gx_line+13, 836, Gx_line+27, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV76DifMN, "ZZZZZZ,ZZZ,ZZ9.99")), 949, Gx_line+13, 1056, Gx_line+28, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 839, Gx_line+13, 934, Gx_line+28, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+34);
         }
      }

      protected void S125( )
      {
         /* 'NOMBREAUXILIAR' Routine */
         returnInSub = false;
         AV102GXLvl174 = 0;
         /* Using cursor P00CK4 */
         pr_default.execute(2, new Object[] {AV83TipACod, AV74CueDAxu});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A71TipADCod = P00CK4_A71TipADCod[0];
            A70TipACod = P00CK4_A70TipACod[0];
            n70TipACod = P00CK4_n70TipACod[0];
            A72TipADDsc = P00CK4_A72TipADDsc[0];
            AV102GXLvl174 = 1;
            AV75CueDAxuDsc = A72TipADDsc;
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
         if ( AV102GXLvl174 == 0 )
         {
            AV75CueDAxuDsc = "SIN AUXILIAR";
         }
      }

      protected void S177( )
      {
         /* 'TIPODOCUMENTO' Routine */
         returnInSub = false;
         AV92TipAbr = ((StringUtil.Len( StringUtil.Trim( AV74CueDAxu))==11) ? "6" : "1");
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
         /* Using cursor P00CK5 */
         pr_default.execute(3, new Object[] {AV25CueCod, AV11Ano, AV12Mes, AV33cCosto});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A126TASICod = P00CK5_A126TASICod[0];
            A129VouNum = P00CK5_A129VouNum[0];
            A2077VouSts = P00CK5_A2077VouSts[0];
            A79COSCod = P00CK5_A79COSCod[0];
            n79COSCod = P00CK5_n79COSCod[0];
            A91CueCod = P00CK5_A91CueCod[0];
            A128VouMes = P00CK5_A128VouMes[0];
            A127VouAno = P00CK5_A127VouAno[0];
            A2069VouDTcmb = P00CK5_A2069VouDTcmb[0];
            A2075VouGls = P00CK5_A2075VouGls[0];
            A132VouDTipCod = P00CK5_A132VouDTipCod[0];
            A2054VouDGls = P00CK5_A2054VouDGls[0];
            A2051VouDDeb = P00CK5_A2051VouDDeb[0];
            A2055VouDHab = P00CK5_A2055VouDHab[0];
            A135VouDFec = P00CK5_A135VouDFec[0];
            A130VouDSec = P00CK5_A130VouDSec[0];
            A2077VouSts = P00CK5_A2077VouSts[0];
            A2075VouGls = P00CK5_A2075VouGls[0];
            AV49Glosa = StringUtil.Trim( A2075VouGls);
            AV82VouDTipCod = A132VouDTipCod;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV49Glosa = StringUtil.Trim( A2054VouDGls);
            }
            AV86TotalSDMN = (decimal)(AV86TotalSDMN+A2051VouDDeb);
            AV87TotalSHMN = (decimal)(AV87TotalSHMN+A2055VouDHab);
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
                                              AV74CueDAxu ,
                                              A2077VouSts ,
                                              AV25CueCod ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CK6 */
         pr_default.execute(4, new Object[] {AV25CueCod, AV11Ano, AV12Mes, AV74CueDAxu, AV33cCosto});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A126TASICod = P00CK6_A126TASICod[0];
            A129VouNum = P00CK6_A129VouNum[0];
            A2077VouSts = P00CK6_A2077VouSts[0];
            A79COSCod = P00CK6_A79COSCod[0];
            n79COSCod = P00CK6_n79COSCod[0];
            A133CueCodAux = P00CK6_A133CueCodAux[0];
            A91CueCod = P00CK6_A91CueCod[0];
            A128VouMes = P00CK6_A128VouMes[0];
            A127VouAno = P00CK6_A127VouAno[0];
            A2069VouDTcmb = P00CK6_A2069VouDTcmb[0];
            A2075VouGls = P00CK6_A2075VouGls[0];
            A132VouDTipCod = P00CK6_A132VouDTipCod[0];
            A2054VouDGls = P00CK6_A2054VouDGls[0];
            A2051VouDDeb = P00CK6_A2051VouDDeb[0];
            A2055VouDHab = P00CK6_A2055VouDHab[0];
            A135VouDFec = P00CK6_A135VouDFec[0];
            A130VouDSec = P00CK6_A130VouDSec[0];
            A2077VouSts = P00CK6_A2077VouSts[0];
            A2075VouGls = P00CK6_A2075VouGls[0];
            AV49Glosa = StringUtil.Trim( A2075VouGls);
            AV82VouDTipCod = A132VouDTipCod;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV49Glosa = StringUtil.Trim( A2054VouDGls);
            }
            AV86TotalSDMN = (decimal)(AV86TotalSDMN+A2051VouDDeb);
            AV87TotalSHMN = (decimal)(AV87TotalSHMN+A2055VouDHab);
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
         /* Using cursor P00CK7 */
         pr_default.execute(5, new Object[] {AV11Ano, AV12Mes, AV25CueCod, AV33cCosto});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A126TASICod = P00CK7_A126TASICod[0];
            A129VouNum = P00CK7_A129VouNum[0];
            A79COSCod = P00CK7_A79COSCod[0];
            n79COSCod = P00CK7_n79COSCod[0];
            A2077VouSts = P00CK7_A2077VouSts[0];
            A91CueCod = P00CK7_A91CueCod[0];
            A128VouMes = P00CK7_A128VouMes[0];
            A127VouAno = P00CK7_A127VouAno[0];
            A2069VouDTcmb = P00CK7_A2069VouDTcmb[0];
            A130VouDSec = P00CK7_A130VouDSec[0];
            A2077VouSts = P00CK7_A2077VouSts[0];
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
                                              AV74CueDAxu ,
                                              A127VouAno ,
                                              A128VouMes ,
                                              A91CueCod ,
                                              A133CueCodAux } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CK8 */
         pr_default.execute(6, new Object[] {AV11Ano, AV12Mes, AV25CueCod, AV74CueDAxu, AV33cCosto});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A126TASICod = P00CK8_A126TASICod[0];
            A129VouNum = P00CK8_A129VouNum[0];
            A2077VouSts = P00CK8_A2077VouSts[0];
            A79COSCod = P00CK8_A79COSCod[0];
            n79COSCod = P00CK8_n79COSCod[0];
            A133CueCodAux = P00CK8_A133CueCodAux[0];
            A91CueCod = P00CK8_A91CueCod[0];
            A128VouMes = P00CK8_A128VouMes[0];
            A127VouAno = P00CK8_A127VouAno[0];
            A2069VouDTcmb = P00CK8_A2069VouDTcmb[0];
            A130VouDSec = P00CK8_A130VouDSec[0];
            A2077VouSts = P00CK8_A2077VouSts[0];
            AV90Flag1 = 1;
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
                                              AV74CueDAxu ,
                                              A133CueCodAux ,
                                              A2074VouFec ,
                                              AV11Ano ,
                                              A91CueCod ,
                                              AV25CueCod } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CK9 */
         pr_default.execute(7, new Object[] {AV11Ano, AV25CueCod, AV74CueDAxu});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A127VouAno = P00CK9_A127VouAno[0];
            A128VouMes = P00CK9_A128VouMes[0];
            A126TASICod = P00CK9_A126TASICod[0];
            A129VouNum = P00CK9_A129VouNum[0];
            A91CueCod = P00CK9_A91CueCod[0];
            A133CueCodAux = P00CK9_A133CueCodAux[0];
            A2074VouFec = P00CK9_A2074VouFec[0];
            A135VouDFec = P00CK9_A135VouDFec[0];
            A130VouDSec = P00CK9_A130VouDSec[0];
            A2074VouFec = P00CK9_A2074VouFec[0];
            AV93FecDoc = A135VouDFec;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void HCK0( bool bFoot ,
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
               getPrinter().GxDrawText("Página:", 963, Gx_line+17, 1007, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1018, Gx_line+17, 1057, Gx_line+32, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 32, Gx_line+8, 658, Gx_line+26, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 106, Gx_line+40, 732, Gx_line+58, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 32, Gx_line+76, 418, Gx_line+93, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52EmpRUC, "")), 106, Gx_line+57, 232, Gx_line+75, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 32, Gx_line+40, 97, Gx_line+58, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 32, Gx_line+57, 68, Gx_line+75, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+96);
               getPrinter().GxDrawLine(76, Gx_line+35, 76, Gx_line+64, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("FECHA DE EMISIÓN", 830, Gx_line+2, 938, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(19, Gx_line+0, 1066, Gx_line+65, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("DEL COMPROBANTE", 829, Gx_line+17, 940, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DOCUMENTO DE IDENTIDAD", 22, Gx_line+21, 180, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(186, Gx_line+19, 186, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(502, Gx_line+0, 502, Gx_line+64, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("APELLIDOS Y NOMBRES", 285, Gx_line+35, 418, Gx_line+49, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("TIPO", 34, Gx_line+45, 63, Gx_line+59, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(19, Gx_line+18, 503, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(19, Gx_line+35, 187, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("NÚMERO", 104, Gx_line+45, 154, Gx_line+59, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DESCRIPCIÓN DE LA OBLIGACIÓN", 574, Gx_line+21, 764, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("MONTO", 988, Gx_line+6, 1031, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("PENDIENTE", 977, Gx_line+22, 1039, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(819, Gx_line+1, 819, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(949, Gx_line+1, 949, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("DE PAGO", 983, Gx_line+38, 1034, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("O FECHA DE INICIO", 830, Gx_line+31, 938, Gx_line+45, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DE LA OPERACIÓN", 833, Gx_line+46, 936, Gx_line+60, 0+256, 0, 0, 0) ;
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
         AV96Logo_GXI = "";
         AV51FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV50cMes = "";
         GXt_char1 = "";
         AV13Titulo = "";
         AV14Periodo = "";
         scmdbuf = "";
         P00CK2_A133CueCodAux = new string[] {""} ;
         P00CK2_A91CueCod = new string[] {""} ;
         P00CK2_A127VouAno = new short[1] ;
         P00CK2_A860CueDsc = new string[] {""} ;
         P00CK2_A70TipACod = new int[1] ;
         P00CK2_n70TipACod = new bool[] {false} ;
         P00CK2_A128VouMes = new short[1] ;
         P00CK2_A126TASICod = new int[1] ;
         P00CK2_A129VouNum = new string[] {""} ;
         P00CK2_A130VouDSec = new int[1] ;
         A133CueCodAux = "";
         A91CueCod = "";
         A860CueDsc = "";
         A129VouNum = "";
         AV25CueCod = "";
         AV41CueDsc = "";
         AV73CueCodAux = "";
         P00CK3_A91CueCod = new string[] {""} ;
         P00CK3_A133CueCodAux = new string[] {""} ;
         P00CK3_A127VouAno = new short[1] ;
         P00CK3_A128VouMes = new short[1] ;
         P00CK3_A126TASICod = new int[1] ;
         P00CK3_A129VouNum = new string[] {""} ;
         P00CK3_A130VouDSec = new int[1] ;
         AV74CueDAxu = "";
         AV60Cuenta = "";
         AV93FecDoc = DateTime.MinValue;
         AV75CueDAxuDsc = "";
         AV92TipAbr = "";
         P00CK4_A71TipADCod = new string[] {""} ;
         P00CK4_A70TipACod = new int[1] ;
         P00CK4_n70TipACod = new bool[] {false} ;
         P00CK4_A72TipADDsc = new string[] {""} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         AV33cCosto = "";
         A79COSCod = "";
         P00CK5_A126TASICod = new int[1] ;
         P00CK5_A129VouNum = new string[] {""} ;
         P00CK5_A2077VouSts = new short[1] ;
         P00CK5_A79COSCod = new string[] {""} ;
         P00CK5_n79COSCod = new bool[] {false} ;
         P00CK5_A91CueCod = new string[] {""} ;
         P00CK5_A128VouMes = new short[1] ;
         P00CK5_A127VouAno = new short[1] ;
         P00CK5_A2069VouDTcmb = new decimal[1] ;
         P00CK5_A2075VouGls = new string[] {""} ;
         P00CK5_A132VouDTipCod = new string[] {""} ;
         P00CK5_A2054VouDGls = new string[] {""} ;
         P00CK5_A2051VouDDeb = new decimal[1] ;
         P00CK5_A2055VouDHab = new decimal[1] ;
         P00CK5_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00CK5_A130VouDSec = new int[1] ;
         A2075VouGls = "";
         A132VouDTipCod = "";
         A2054VouDGls = "";
         A135VouDFec = DateTime.MinValue;
         AV49Glosa = "";
         AV82VouDTipCod = "";
         P00CK6_A126TASICod = new int[1] ;
         P00CK6_A129VouNum = new string[] {""} ;
         P00CK6_A2077VouSts = new short[1] ;
         P00CK6_A79COSCod = new string[] {""} ;
         P00CK6_n79COSCod = new bool[] {false} ;
         P00CK6_A133CueCodAux = new string[] {""} ;
         P00CK6_A91CueCod = new string[] {""} ;
         P00CK6_A128VouMes = new short[1] ;
         P00CK6_A127VouAno = new short[1] ;
         P00CK6_A2069VouDTcmb = new decimal[1] ;
         P00CK6_A2075VouGls = new string[] {""} ;
         P00CK6_A132VouDTipCod = new string[] {""} ;
         P00CK6_A2054VouDGls = new string[] {""} ;
         P00CK6_A2051VouDDeb = new decimal[1] ;
         P00CK6_A2055VouDHab = new decimal[1] ;
         P00CK6_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00CK6_A130VouDSec = new int[1] ;
         P00CK7_A126TASICod = new int[1] ;
         P00CK7_A129VouNum = new string[] {""} ;
         P00CK7_A79COSCod = new string[] {""} ;
         P00CK7_n79COSCod = new bool[] {false} ;
         P00CK7_A2077VouSts = new short[1] ;
         P00CK7_A91CueCod = new string[] {""} ;
         P00CK7_A128VouMes = new short[1] ;
         P00CK7_A127VouAno = new short[1] ;
         P00CK7_A2069VouDTcmb = new decimal[1] ;
         P00CK7_A130VouDSec = new int[1] ;
         P00CK8_A126TASICod = new int[1] ;
         P00CK8_A129VouNum = new string[] {""} ;
         P00CK8_A2077VouSts = new short[1] ;
         P00CK8_A79COSCod = new string[] {""} ;
         P00CK8_n79COSCod = new bool[] {false} ;
         P00CK8_A133CueCodAux = new string[] {""} ;
         P00CK8_A91CueCod = new string[] {""} ;
         P00CK8_A128VouMes = new short[1] ;
         P00CK8_A127VouAno = new short[1] ;
         P00CK8_A2069VouDTcmb = new decimal[1] ;
         P00CK8_A130VouDSec = new int[1] ;
         A2074VouFec = DateTime.MinValue;
         P00CK9_A127VouAno = new short[1] ;
         P00CK9_A128VouMes = new short[1] ;
         P00CK9_A126TASICod = new int[1] ;
         P00CK9_A129VouNum = new string[] {""} ;
         P00CK9_A91CueCod = new string[] {""} ;
         P00CK9_A133CueCodAux = new string[] {""} ;
         P00CK9_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         P00CK9_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00CK9_A130VouDSec = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rrlibro3_13__default(),
            new Object[][] {
                new Object[] {
               P00CK2_A133CueCodAux, P00CK2_A91CueCod, P00CK2_A127VouAno, P00CK2_A860CueDsc, P00CK2_A70TipACod, P00CK2_n70TipACod, P00CK2_A128VouMes, P00CK2_A126TASICod, P00CK2_A129VouNum, P00CK2_A130VouDSec
               }
               , new Object[] {
               P00CK3_A91CueCod, P00CK3_A133CueCodAux, P00CK3_A127VouAno, P00CK3_A128VouMes, P00CK3_A126TASICod, P00CK3_A129VouNum, P00CK3_A130VouDSec
               }
               , new Object[] {
               P00CK4_A71TipADCod, P00CK4_A70TipACod, P00CK4_A72TipADDsc
               }
               , new Object[] {
               P00CK5_A126TASICod, P00CK5_A129VouNum, P00CK5_A2077VouSts, P00CK5_A79COSCod, P00CK5_n79COSCod, P00CK5_A91CueCod, P00CK5_A128VouMes, P00CK5_A127VouAno, P00CK5_A2069VouDTcmb, P00CK5_A2075VouGls,
               P00CK5_A132VouDTipCod, P00CK5_A2054VouDGls, P00CK5_A2051VouDDeb, P00CK5_A2055VouDHab, P00CK5_A135VouDFec, P00CK5_A130VouDSec
               }
               , new Object[] {
               P00CK6_A126TASICod, P00CK6_A129VouNum, P00CK6_A2077VouSts, P00CK6_A79COSCod, P00CK6_n79COSCod, P00CK6_A133CueCodAux, P00CK6_A91CueCod, P00CK6_A128VouMes, P00CK6_A127VouAno, P00CK6_A2069VouDTcmb,
               P00CK6_A2075VouGls, P00CK6_A132VouDTipCod, P00CK6_A2054VouDGls, P00CK6_A2051VouDDeb, P00CK6_A2055VouDHab, P00CK6_A135VouDFec, P00CK6_A130VouDSec
               }
               , new Object[] {
               P00CK7_A126TASICod, P00CK7_A129VouNum, P00CK7_A79COSCod, P00CK7_n79COSCod, P00CK7_A2077VouSts, P00CK7_A91CueCod, P00CK7_A128VouMes, P00CK7_A127VouAno, P00CK7_A2069VouDTcmb, P00CK7_A130VouDSec
               }
               , new Object[] {
               P00CK8_A126TASICod, P00CK8_A129VouNum, P00CK8_A2077VouSts, P00CK8_A79COSCod, P00CK8_n79COSCod, P00CK8_A133CueCodAux, P00CK8_A91CueCod, P00CK8_A128VouMes, P00CK8_A127VouAno, P00CK8_A2069VouDTcmb,
               P00CK8_A130VouDSec
               }
               , new Object[] {
               P00CK9_A127VouAno, P00CK9_A128VouMes, P00CK9_A126TASICod, P00CK9_A129VouNum, P00CK9_A91CueCod, P00CK9_A133CueCodAux, P00CK9_A2074VouFec, P00CK9_A135VouDFec, P00CK9_A130VouDSec
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
      private short AV90Flag1 ;
      private short AV102GXLvl174 ;
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
      private decimal AV78SaldoDAMN ;
      private decimal AV79SaldoHAMN ;
      private decimal AV86TotalSDMN ;
      private decimal AV87TotalSHMN ;
      private decimal AV80SaldoDAME ;
      private decimal AV81SaldoHAME ;
      private decimal AV76DifMN ;
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
      private string AV14Periodo ;
      private string scmdbuf ;
      private string A133CueCodAux ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string A129VouNum ;
      private string AV25CueCod ;
      private string AV41CueDsc ;
      private string AV73CueCodAux ;
      private string AV74CueDAxu ;
      private string AV60Cuenta ;
      private string AV75CueDAxuDsc ;
      private string AV92TipAbr ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string AV33cCosto ;
      private string A79COSCod ;
      private string A2075VouGls ;
      private string A132VouDTipCod ;
      private string A2054VouDGls ;
      private string AV49Glosa ;
      private string AV82VouDTipCod ;
      private DateTime AV16FechaD ;
      private DateTime AV93FecDoc ;
      private DateTime A135VouDFec ;
      private DateTime A2074VouFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKCK3 ;
      private bool n70TipACod ;
      private bool returnInSub ;
      private bool BRKCK5 ;
      private bool n79COSCod ;
      private string AV96Logo_GXI ;
      private string AV53Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_cCuenta1 ;
      private IDataStoreProvider pr_default ;
      private string[] P00CK2_A133CueCodAux ;
      private string[] P00CK2_A91CueCod ;
      private short[] P00CK2_A127VouAno ;
      private string[] P00CK2_A860CueDsc ;
      private int[] P00CK2_A70TipACod ;
      private bool[] P00CK2_n70TipACod ;
      private short[] P00CK2_A128VouMes ;
      private int[] P00CK2_A126TASICod ;
      private string[] P00CK2_A129VouNum ;
      private int[] P00CK2_A130VouDSec ;
      private string[] P00CK3_A91CueCod ;
      private string[] P00CK3_A133CueCodAux ;
      private short[] P00CK3_A127VouAno ;
      private short[] P00CK3_A128VouMes ;
      private int[] P00CK3_A126TASICod ;
      private string[] P00CK3_A129VouNum ;
      private int[] P00CK3_A130VouDSec ;
      private string[] P00CK4_A71TipADCod ;
      private int[] P00CK4_A70TipACod ;
      private bool[] P00CK4_n70TipACod ;
      private string[] P00CK4_A72TipADDsc ;
      private int[] P00CK5_A126TASICod ;
      private string[] P00CK5_A129VouNum ;
      private short[] P00CK5_A2077VouSts ;
      private string[] P00CK5_A79COSCod ;
      private bool[] P00CK5_n79COSCod ;
      private string[] P00CK5_A91CueCod ;
      private short[] P00CK5_A128VouMes ;
      private short[] P00CK5_A127VouAno ;
      private decimal[] P00CK5_A2069VouDTcmb ;
      private string[] P00CK5_A2075VouGls ;
      private string[] P00CK5_A132VouDTipCod ;
      private string[] P00CK5_A2054VouDGls ;
      private decimal[] P00CK5_A2051VouDDeb ;
      private decimal[] P00CK5_A2055VouDHab ;
      private DateTime[] P00CK5_A135VouDFec ;
      private int[] P00CK5_A130VouDSec ;
      private int[] P00CK6_A126TASICod ;
      private string[] P00CK6_A129VouNum ;
      private short[] P00CK6_A2077VouSts ;
      private string[] P00CK6_A79COSCod ;
      private bool[] P00CK6_n79COSCod ;
      private string[] P00CK6_A133CueCodAux ;
      private string[] P00CK6_A91CueCod ;
      private short[] P00CK6_A128VouMes ;
      private short[] P00CK6_A127VouAno ;
      private decimal[] P00CK6_A2069VouDTcmb ;
      private string[] P00CK6_A2075VouGls ;
      private string[] P00CK6_A132VouDTipCod ;
      private string[] P00CK6_A2054VouDGls ;
      private decimal[] P00CK6_A2051VouDDeb ;
      private decimal[] P00CK6_A2055VouDHab ;
      private DateTime[] P00CK6_A135VouDFec ;
      private int[] P00CK6_A130VouDSec ;
      private int[] P00CK7_A126TASICod ;
      private string[] P00CK7_A129VouNum ;
      private string[] P00CK7_A79COSCod ;
      private bool[] P00CK7_n79COSCod ;
      private short[] P00CK7_A2077VouSts ;
      private string[] P00CK7_A91CueCod ;
      private short[] P00CK7_A128VouMes ;
      private short[] P00CK7_A127VouAno ;
      private decimal[] P00CK7_A2069VouDTcmb ;
      private int[] P00CK7_A130VouDSec ;
      private int[] P00CK8_A126TASICod ;
      private string[] P00CK8_A129VouNum ;
      private short[] P00CK8_A2077VouSts ;
      private string[] P00CK8_A79COSCod ;
      private bool[] P00CK8_n79COSCod ;
      private string[] P00CK8_A133CueCodAux ;
      private string[] P00CK8_A91CueCod ;
      private short[] P00CK8_A128VouMes ;
      private short[] P00CK8_A127VouAno ;
      private decimal[] P00CK8_A2069VouDTcmb ;
      private int[] P00CK8_A130VouDSec ;
      private short[] P00CK9_A127VouAno ;
      private short[] P00CK9_A128VouMes ;
      private int[] P00CK9_A126TASICod ;
      private string[] P00CK9_A129VouNum ;
      private string[] P00CK9_A91CueCod ;
      private string[] P00CK9_A133CueCodAux ;
      private DateTime[] P00CK9_A2074VouFec ;
      private DateTime[] P00CK9_A135VouDFec ;
      private int[] P00CK9_A130VouDSec ;
   }

   public class rrlibro3_13__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CK3( IGxContext context ,
                                             string AV73CueCodAux ,
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73CueCodAux)) )
         {
            AddWhere(sWhereString, "([CueCodAux] = @AV73CueCodAux)");
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

      protected Object[] conditional_P00CK5( IGxContext context ,
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

      protected Object[] conditional_P00CK6( IGxContext context ,
                                             string AV33cCosto ,
                                             string A79COSCod ,
                                             short A127VouAno ,
                                             short AV11Ano ,
                                             short A128VouMes ,
                                             short AV12Mes ,
                                             string A133CueCodAux ,
                                             string AV74CueDAxu ,
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
         AddWhere(sWhereString, "(T1.[CueCodAux] = @AV74CueDAxu)");
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

      protected Object[] conditional_P00CK7( IGxContext context ,
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

      protected Object[] conditional_P00CK8( IGxContext context ,
                                             string AV33cCosto ,
                                             string A79COSCod ,
                                             short A2077VouSts ,
                                             short AV11Ano ,
                                             short AV12Mes ,
                                             string AV25CueCod ,
                                             string AV74CueDAxu ,
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
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV25CueCod and T1.[CueCodAux] = @AV74CueDAxu)");
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

      protected Object[] conditional_P00CK9( IGxContext context ,
                                             string AV74CueDAxu ,
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74CueDAxu)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV74CueDAxu)");
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
                     return conditional_P00CK3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] );
               case 3 :
                     return conditional_P00CK5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] );
               case 4 :
                     return conditional_P00CK6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
               case 5 :
                     return conditional_P00CK7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] );
               case 6 :
                     return conditional_P00CK8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
               case 7 :
                     return conditional_P00CK9(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] );
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
          Object[] prmP00CK2;
          prmP00CK2 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0)
          };
          Object[] prmP00CK4;
          prmP00CK4 = new Object[] {
          new ParDef("@AV83TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV74CueDAxu",GXType.NChar,20,0)
          };
          Object[] prmP00CK3;
          prmP00CK3 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV73CueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00CK5;
          prmP00CK5 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00CK6;
          prmP00CK6 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV74CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00CK7;
          prmP00CK7 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00CK8;
          prmP00CK8 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV74CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00CK9;
          prmP00CK9 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV74CueDAxu",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CK2", "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouAno], T2.[CueDsc], T2.[TipACod], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (SUBSTRING(T1.[CueCod], 1, 2) = '46') AND (T1.[VouAno] = @AV11Ano) ORDER BY T1.[CueCod], T1.[CueCodAux] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CK3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CK4", "SELECT [TipADCod], [TipACod], [TipADDsc] FROM [CBAUXILIARES] WHERE [TipACod] = @AV83TipACod and [TipADCod] = @AV74CueDAxu ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00CK5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CK6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CK7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CK8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CK9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK9,1, GxCacheFrequency.OFF ,false,true )
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
