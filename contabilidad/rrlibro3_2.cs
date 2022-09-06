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
   public class rrlibro3_2 : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.rrlibro3_2.aspx")), "contabilidad.rrlibro3_2.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.rrlibro3_2.aspx")))) ;
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

      public rrlibro3_2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrlibro3_2( IGxContext context )
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
         rrlibro3_2 objrrlibro3_2;
         objrrlibro3_2 = new rrlibro3_2();
         objrrlibro3_2.AV11Ano = aP0_Ano;
         objrrlibro3_2.AV12Mes = aP1_Mes;
         objrrlibro3_2.AV34cCuenta1 = aP2_cCuenta1;
         objrrlibro3_2.context.SetSubmitInitialConfig(context);
         objrrlibro3_2.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrlibro3_2);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_cCuenta1=this.AV34cCuenta1;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrlibro3_2)stateInfo).executePrivate();
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
            AV98Logo_GXI = GXDbFile.PathToUrl( AV54Ruta);
            AV51FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV51FechaC, 2);
            GXt_char1 = AV50cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV50cMes = GXt_char1;
            AV13Titulo = "FORMATO 3.2: LIBRO DE INVENTARIOS Y BALANCES - DETALLE DE SALDO DE LA CUENTA 10 - EFECTIVO Y EQUIVALENTE DE EFECTIVO";
            AV14Periodo = StringUtil.Upper( AV50cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV47TDebeMO = 0.00m;
            AV48ThaberMO = 0.00m;
            AV55TDebePagMo = 0.00m;
            AV56THaberPagMo = 0.00m;
            /* Using cursor P00CC2 */
            pr_default.execute(0, new Object[] {AV11Ano});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKCC3 = false;
               A133CueCodAux = P00CC2_A133CueCodAux[0];
               A91CueCod = P00CC2_A91CueCod[0];
               A127VouAno = P00CC2_A127VouAno[0];
               A860CueDsc = P00CC2_A860CueDsc[0];
               A70TipACod = P00CC2_A70TipACod[0];
               n70TipACod = P00CC2_n70TipACod[0];
               A128VouMes = P00CC2_A128VouMes[0];
               A126TASICod = P00CC2_A126TASICod[0];
               A129VouNum = P00CC2_A129VouNum[0];
               A130VouDSec = P00CC2_A130VouDSec[0];
               A860CueDsc = P00CC2_A860CueDsc[0];
               A70TipACod = P00CC2_A70TipACod[0];
               n70TipACod = P00CC2_n70TipACod[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00CC2_A91CueCod[0], A91CueCod) == 0 ) )
               {
                  BRKCC3 = false;
                  A133CueCodAux = P00CC2_A133CueCodAux[0];
                  A127VouAno = P00CC2_A127VouAno[0];
                  A128VouMes = P00CC2_A128VouMes[0];
                  A126TASICod = P00CC2_A126TASICod[0];
                  A129VouNum = P00CC2_A129VouNum[0];
                  A130VouDSec = P00CC2_A130VouDSec[0];
                  BRKCC3 = true;
                  pr_default.readNext(0);
               }
               AV25CueCod = A91CueCod;
               AV41CueDsc = A860CueDsc;
               AV83TipACod = A70TipACod;
               AV63SaldoDMN = 0.00m;
               AV64SaldoHMN = 0.00m;
               AV65SaldoDME = 0.00m;
               AV66SaldoHME = 0.00m;
               AV47TDebeMO = 0.00m;
               AV48ThaberMO = 0.00m;
               AV39TDebeME = 0.00m;
               AV40THaberME = 0.00m;
               new GeneXus.Programs.contabilidad.pobtienesaldoscuenta(context ).execute( ref  AV25CueCod, ref  AV11Ano, ref  AV12Mes, out  AV63SaldoDMN, out  AV64SaldoHMN, out  AV65SaldoDME, out  AV66SaldoHME) ;
               AV67SaldoMN = (decimal)(AV63SaldoDMN-AV64SaldoHMN);
               AV84SaldoME = (decimal)(AV65SaldoDME-AV66SaldoHME);
               AV63SaldoDMN = ((AV67SaldoMN>Convert.ToDecimal(0)) ? AV67SaldoMN : (decimal)(0));
               AV64SaldoHMN = ((AV67SaldoMN<Convert.ToDecimal(0)) ? AV67SaldoMN*-1 : (decimal)(0));
               AV65SaldoDME = ((AV84SaldoME>Convert.ToDecimal(0)) ? AV84SaldoME : (decimal)(0));
               AV66SaldoHME = ((AV84SaldoME<Convert.ToDecimal(0)) ? AV84SaldoME*-1 : (decimal)(0));
               AV85Flag = 0;
               if ( ! (Convert.ToDecimal(0)==AV63SaldoDMN) || ! (Convert.ToDecimal(0)==AV64SaldoHMN) || ! (Convert.ToDecimal(0)==AV65SaldoDME) || ! (Convert.ToDecimal(0)==AV66SaldoHME) )
               {
                  AV85Flag = 1;
               }
               /* Execute user subroutine: 'VALIDAMOV' */
               S141 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'DETALLE' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! BRKCC3 )
               {
                  BRKCC3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HCC0( false, 58) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General :", 678, Gx_line+22, 764, Gx_line+36, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(773, Gx_line+13, 1046, Gx_line+13, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55TDebePagMo, "ZZZZZZ,ZZZ,ZZ9.99")), 790, Gx_line+22, 897, Gx_line+37, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56THaberPagMo, "ZZZZZZ,ZZZ,ZZ9.99")), 931, Gx_line+22, 1038, Gx_line+37, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+58);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HCC0( true, 0) ;
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
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV74CueDAxu = "";
         AV86TotalSDMN = 0.00m;
         AV87TotalSHMN = 0.00m;
         AV88TotalSDME = 0.00m;
         AV89TotalSHME = 0.00m;
         AV22TDebe = AV63SaldoDMN;
         AV23THaber = AV64SaldoHMN;
         AV45TDebeE = AV65SaldoDME;
         AV46THaberE = AV66SaldoHME;
         /* Execute user subroutine: 'MOVIMIENTOS' */
         S121 ();
         if (returnInSub) return;
         AV22TDebe = (decimal)(AV22TDebe+AV86TotalSDMN);
         AV23THaber = (decimal)(AV23THaber+AV87TotalSHMN);
         AV45TDebeE = (decimal)(AV45TDebeE+AV88TotalSDME);
         AV46THaberE = (decimal)(AV46THaberE+AV89TotalSHME);
         AV47TDebeMO = AV22TDebe;
         AV48ThaberMO = AV23THaber;
         AV39TDebeME = AV45TDebeE;
         AV40THaberME = AV46THaberE;
         if ( AV85Flag == 1 )
         {
            AV91Saldo = (decimal)(AV47TDebeMO-AV48ThaberMO);
            if ( ( AV91Saldo < Convert.ToDecimal( 0 )) )
            {
               AV47TDebeMO = 0.00m;
               AV48ThaberMO = (decimal)(AV91Saldo*-1);
            }
            else
            {
               AV47TDebeMO = AV91Saldo;
               AV48ThaberMO = 0.00m;
            }
            AV55TDebePagMo = (decimal)(AV55TDebePagMo+AV47TDebeMO);
            AV56THaberPagMo = (decimal)(AV56THaberPagMo+AV48ThaberMO);
            /* Execute user subroutine: 'VALIDACUENTABANCOS' */
            S131 ();
            if (returnInSub) return;
            HCC0( false, 22) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TDebeMO, "ZZZZZZ,ZZZ,ZZ9.99")), 790, Gx_line+4, 897, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 24, Gx_line+4, 103, Gx_line+19, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41CueDsc, "")), 117, Gx_line+3, 456, Gx_line+20, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48ThaberMO, "ZZZZZZ,ZZZ,ZZ9.99")), 931, Gx_line+4, 1038, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93EntFinaciera, "")), 474, Gx_line+4, 527, Gx_line+19, 1+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94NroCuenta, "")), 564, Gx_line+4, 669, Gx_line+19, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95TipoMoneda, "")), 727, Gx_line+4, 738, Gx_line+19, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+22);
         }
      }

      protected void S121( )
      {
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
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
         /* Using cursor P00CC3 */
         pr_default.execute(1, new Object[] {AV25CueCod, AV11Ano, AV12Mes, AV33cCosto});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A126TASICod = P00CC3_A126TASICod[0];
            A129VouNum = P00CC3_A129VouNum[0];
            A2077VouSts = P00CC3_A2077VouSts[0];
            A79COSCod = P00CC3_A79COSCod[0];
            n79COSCod = P00CC3_n79COSCod[0];
            A91CueCod = P00CC3_A91CueCod[0];
            A128VouMes = P00CC3_A128VouMes[0];
            A127VouAno = P00CC3_A127VouAno[0];
            A2069VouDTcmb = P00CC3_A2069VouDTcmb[0];
            A2075VouGls = P00CC3_A2075VouGls[0];
            A132VouDTipCod = P00CC3_A132VouDTipCod[0];
            A2054VouDGls = P00CC3_A2054VouDGls[0];
            A131VouDMon = P00CC3_A131VouDMon[0];
            A2052VouDDebO = P00CC3_A2052VouDDebO[0];
            A2056VouDHabO = P00CC3_A2056VouDHabO[0];
            A2051VouDDeb = P00CC3_A2051VouDDeb[0];
            A2055VouDHab = P00CC3_A2055VouDHab[0];
            A135VouDFec = P00CC3_A135VouDFec[0];
            A130VouDSec = P00CC3_A130VouDSec[0];
            A2077VouSts = P00CC3_A2077VouSts[0];
            A2075VouGls = P00CC3_A2075VouGls[0];
            AV37DebeME = 0.00m;
            AV38HaberME = 0.00m;
            AV49Glosa = StringUtil.Trim( A2075VouGls);
            AV82VouDTipCod = A132VouDTipCod;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV49Glosa = StringUtil.Trim( A2054VouDGls);
            }
            if ( ! ( A131VouDMon == 1 ) )
            {
               AV37DebeME = A2052VouDDebO;
               AV38HaberME = A2056VouDHabO;
            }
            AV86TotalSDMN = (decimal)(AV86TotalSDMN+A2051VouDDeb);
            AV87TotalSHMN = (decimal)(AV87TotalSHMN+A2055VouDHab);
            AV88TotalSDME = (decimal)(AV88TotalSDME+AV37DebeME);
            AV89TotalSHME = (decimal)(AV89TotalSHME+AV38HaberME);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
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
         /* Using cursor P00CC4 */
         pr_default.execute(2, new Object[] {AV11Ano, AV12Mes, AV25CueCod, AV33cCosto});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00CC4_A126TASICod[0];
            A129VouNum = P00CC4_A129VouNum[0];
            A79COSCod = P00CC4_A79COSCod[0];
            n79COSCod = P00CC4_n79COSCod[0];
            A2077VouSts = P00CC4_A2077VouSts[0];
            A91CueCod = P00CC4_A91CueCod[0];
            A128VouMes = P00CC4_A128VouMes[0];
            A127VouAno = P00CC4_A127VouAno[0];
            A2069VouDTcmb = P00CC4_A2069VouDTcmb[0];
            A130VouDSec = P00CC4_A130VouDSec[0];
            A2077VouSts = P00CC4_A2077VouSts[0];
            AV85Flag = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'VALIDACUENTABANCOS' Routine */
         returnInSub = false;
         AV93EntFinaciera = "";
         AV94NroCuenta = "";
         AV95TipoMoneda = "";
         /* Using cursor P00CC5 */
         pr_default.execute(3, new Object[] {AV25CueCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A372BanCod = P00CC5_A372BanCod[0];
            A378CBCueCod = P00CC5_A378CBCueCod[0];
            A180MonCod = P00CC5_A180MonCod[0];
            A377CBCod = P00CC5_A377CBCod[0];
            A484BanSunat = P00CC5_A484BanSunat[0];
            A484BanSunat = P00CC5_A484BanSunat[0];
            AV95TipoMoneda = StringUtil.Trim( StringUtil.Str( (decimal)(A180MonCod), 10, 0));
            AV94NroCuenta = StringUtil.Trim( A377CBCod);
            AV93EntFinaciera = A484BanSunat;
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void HCC0( bool bFoot ,
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
               getPrinter().GxDrawText("Página:", 921, Gx_line+20, 965, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 976, Gx_line+20, 1015, Gx_line+35, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 32, Gx_line+8, 408, Gx_line+26, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 106, Gx_line+40, 732, Gx_line+58, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 32, Gx_line+76, 418, Gx_line+93, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52EmpRUC, "")), 106, Gx_line+57, 232, Gx_line+75, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 32, Gx_line+40, 97, Gx_line+58, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 32, Gx_line+57, 68, Gx_line+75, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+96);
               getPrinter().GxDrawRect(19, Gx_line+0, 1047, Gx_line+65, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("R E F E R E N C I A   D E   L A   C U E N T A", 500, Gx_line+2, 723, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(109, Gx_line+19, 109, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(455, Gx_line+1, 455, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("CUENTA CONTABLE DIVISIONARIA", 132, Gx_line+2, 327, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("CODIGO", 41, Gx_line+35, 88, Gx_line+49, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(19, Gx_line+18, 1047, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("D E N O M I N A C I O N", 214, Gx_line+35, 339, Gx_line+49, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(776, Gx_line+1, 776, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(542, Gx_line+19, 542, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(682, Gx_line+18, 682, Gx_line+64, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("SALDO CONTABLE FINAL", 844, Gx_line+2, 981, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("ENTIDAD", 473, Gx_line+25, 525, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FINANCIERA", 464, Gx_line+42, 535, Gx_line+56, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("NRO. DE LA", 582, Gx_line+25, 646, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("CUENTA", 591, Gx_line+42, 637, Gx_line+56, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("MONEDA", 707, Gx_line+42, 757, Gx_line+56, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("TIPO DE", 709, Gx_line+25, 756, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(906, Gx_line+19, 906, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("DEUDOR", 817, Gx_line+35, 866, Gx_line+49, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("ACREEDOR", 954, Gx_line+35, 1016, Gx_line+49, 0+256, 0, 0, 0) ;
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
         AV27Empresa = "";
         AV30Session = context.GetSession();
         AV28EmpDir = "";
         AV52EmpRUC = "";
         AV54Ruta = "";
         AV53Logo = "";
         AV98Logo_GXI = "";
         AV51FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV50cMes = "";
         GXt_char1 = "";
         AV13Titulo = "";
         AV14Periodo = "";
         scmdbuf = "";
         P00CC2_A133CueCodAux = new string[] {""} ;
         P00CC2_A91CueCod = new string[] {""} ;
         P00CC2_A127VouAno = new short[1] ;
         P00CC2_A860CueDsc = new string[] {""} ;
         P00CC2_A70TipACod = new int[1] ;
         P00CC2_n70TipACod = new bool[] {false} ;
         P00CC2_A128VouMes = new short[1] ;
         P00CC2_A126TASICod = new int[1] ;
         P00CC2_A129VouNum = new string[] {""} ;
         P00CC2_A130VouDSec = new int[1] ;
         A133CueCodAux = "";
         A91CueCod = "";
         A860CueDsc = "";
         A129VouNum = "";
         AV25CueCod = "";
         AV41CueDsc = "";
         AV74CueDAxu = "";
         AV93EntFinaciera = "";
         AV94NroCuenta = "";
         AV95TipoMoneda = "";
         AV33cCosto = "";
         A79COSCod = "";
         P00CC3_A126TASICod = new int[1] ;
         P00CC3_A129VouNum = new string[] {""} ;
         P00CC3_A2077VouSts = new short[1] ;
         P00CC3_A79COSCod = new string[] {""} ;
         P00CC3_n79COSCod = new bool[] {false} ;
         P00CC3_A91CueCod = new string[] {""} ;
         P00CC3_A128VouMes = new short[1] ;
         P00CC3_A127VouAno = new short[1] ;
         P00CC3_A2069VouDTcmb = new decimal[1] ;
         P00CC3_A2075VouGls = new string[] {""} ;
         P00CC3_A132VouDTipCod = new string[] {""} ;
         P00CC3_A2054VouDGls = new string[] {""} ;
         P00CC3_A131VouDMon = new int[1] ;
         P00CC3_A2052VouDDebO = new decimal[1] ;
         P00CC3_A2056VouDHabO = new decimal[1] ;
         P00CC3_A2051VouDDeb = new decimal[1] ;
         P00CC3_A2055VouDHab = new decimal[1] ;
         P00CC3_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00CC3_A130VouDSec = new int[1] ;
         A2075VouGls = "";
         A132VouDTipCod = "";
         A2054VouDGls = "";
         A135VouDFec = DateTime.MinValue;
         AV49Glosa = "";
         AV82VouDTipCod = "";
         P00CC4_A126TASICod = new int[1] ;
         P00CC4_A129VouNum = new string[] {""} ;
         P00CC4_A79COSCod = new string[] {""} ;
         P00CC4_n79COSCod = new bool[] {false} ;
         P00CC4_A2077VouSts = new short[1] ;
         P00CC4_A91CueCod = new string[] {""} ;
         P00CC4_A128VouMes = new short[1] ;
         P00CC4_A127VouAno = new short[1] ;
         P00CC4_A2069VouDTcmb = new decimal[1] ;
         P00CC4_A130VouDSec = new int[1] ;
         P00CC5_A372BanCod = new int[1] ;
         P00CC5_A378CBCueCod = new string[] {""} ;
         P00CC5_A180MonCod = new int[1] ;
         P00CC5_A377CBCod = new string[] {""} ;
         P00CC5_A484BanSunat = new string[] {""} ;
         A378CBCueCod = "";
         A377CBCod = "";
         A484BanSunat = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rrlibro3_2__default(),
            new Object[][] {
                new Object[] {
               P00CC2_A133CueCodAux, P00CC2_A91CueCod, P00CC2_A127VouAno, P00CC2_A860CueDsc, P00CC2_A70TipACod, P00CC2_n70TipACod, P00CC2_A128VouMes, P00CC2_A126TASICod, P00CC2_A129VouNum, P00CC2_A130VouDSec
               }
               , new Object[] {
               P00CC3_A126TASICod, P00CC3_A129VouNum, P00CC3_A2077VouSts, P00CC3_A79COSCod, P00CC3_n79COSCod, P00CC3_A91CueCod, P00CC3_A128VouMes, P00CC3_A127VouAno, P00CC3_A2069VouDTcmb, P00CC3_A2075VouGls,
               P00CC3_A132VouDTipCod, P00CC3_A2054VouDGls, P00CC3_A131VouDMon, P00CC3_A2052VouDDebO, P00CC3_A2056VouDHabO, P00CC3_A2051VouDDeb, P00CC3_A2055VouDHab, P00CC3_A135VouDFec, P00CC3_A130VouDSec
               }
               , new Object[] {
               P00CC4_A126TASICod, P00CC4_A129VouNum, P00CC4_A79COSCod, P00CC4_n79COSCod, P00CC4_A2077VouSts, P00CC4_A91CueCod, P00CC4_A128VouMes, P00CC4_A127VouAno, P00CC4_A2069VouDTcmb, P00CC4_A130VouDSec
               }
               , new Object[] {
               P00CC5_A372BanCod, P00CC5_A378CBCueCod, P00CC5_A180MonCod, P00CC5_A377CBCod, P00CC5_A484BanSunat
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
      private int A131VouDMon ;
      private int A372BanCod ;
      private int A180MonCod ;
      private decimal AV47TDebeMO ;
      private decimal AV48ThaberMO ;
      private decimal AV55TDebePagMo ;
      private decimal AV56THaberPagMo ;
      private decimal AV63SaldoDMN ;
      private decimal AV64SaldoHMN ;
      private decimal AV65SaldoDME ;
      private decimal AV66SaldoHME ;
      private decimal AV39TDebeME ;
      private decimal AV40THaberME ;
      private decimal AV67SaldoMN ;
      private decimal AV84SaldoME ;
      private decimal AV86TotalSDMN ;
      private decimal AV87TotalSHMN ;
      private decimal AV88TotalSDME ;
      private decimal AV89TotalSHME ;
      private decimal AV22TDebe ;
      private decimal AV23THaber ;
      private decimal AV45TDebeE ;
      private decimal AV46THaberE ;
      private decimal AV91Saldo ;
      private decimal A2069VouDTcmb ;
      private decimal A2052VouDDebO ;
      private decimal A2056VouDHabO ;
      private decimal A2051VouDDeb ;
      private decimal A2055VouDHab ;
      private decimal AV37DebeME ;
      private decimal AV38HaberME ;
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
      private string AV74CueDAxu ;
      private string AV93EntFinaciera ;
      private string AV94NroCuenta ;
      private string AV95TipoMoneda ;
      private string AV33cCosto ;
      private string A79COSCod ;
      private string A2075VouGls ;
      private string A132VouDTipCod ;
      private string A2054VouDGls ;
      private string AV49Glosa ;
      private string AV82VouDTipCod ;
      private string A378CBCueCod ;
      private string A377CBCod ;
      private string A484BanSunat ;
      private DateTime AV16FechaD ;
      private DateTime A135VouDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKCC3 ;
      private bool n70TipACod ;
      private bool returnInSub ;
      private bool n79COSCod ;
      private string AV98Logo_GXI ;
      private string AV53Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_cCuenta1 ;
      private IDataStoreProvider pr_default ;
      private string[] P00CC2_A133CueCodAux ;
      private string[] P00CC2_A91CueCod ;
      private short[] P00CC2_A127VouAno ;
      private string[] P00CC2_A860CueDsc ;
      private int[] P00CC2_A70TipACod ;
      private bool[] P00CC2_n70TipACod ;
      private short[] P00CC2_A128VouMes ;
      private int[] P00CC2_A126TASICod ;
      private string[] P00CC2_A129VouNum ;
      private int[] P00CC2_A130VouDSec ;
      private int[] P00CC3_A126TASICod ;
      private string[] P00CC3_A129VouNum ;
      private short[] P00CC3_A2077VouSts ;
      private string[] P00CC3_A79COSCod ;
      private bool[] P00CC3_n79COSCod ;
      private string[] P00CC3_A91CueCod ;
      private short[] P00CC3_A128VouMes ;
      private short[] P00CC3_A127VouAno ;
      private decimal[] P00CC3_A2069VouDTcmb ;
      private string[] P00CC3_A2075VouGls ;
      private string[] P00CC3_A132VouDTipCod ;
      private string[] P00CC3_A2054VouDGls ;
      private int[] P00CC3_A131VouDMon ;
      private decimal[] P00CC3_A2052VouDDebO ;
      private decimal[] P00CC3_A2056VouDHabO ;
      private decimal[] P00CC3_A2051VouDDeb ;
      private decimal[] P00CC3_A2055VouDHab ;
      private DateTime[] P00CC3_A135VouDFec ;
      private int[] P00CC3_A130VouDSec ;
      private int[] P00CC4_A126TASICod ;
      private string[] P00CC4_A129VouNum ;
      private string[] P00CC4_A79COSCod ;
      private bool[] P00CC4_n79COSCod ;
      private short[] P00CC4_A2077VouSts ;
      private string[] P00CC4_A91CueCod ;
      private short[] P00CC4_A128VouMes ;
      private short[] P00CC4_A127VouAno ;
      private decimal[] P00CC4_A2069VouDTcmb ;
      private int[] P00CC4_A130VouDSec ;
      private int[] P00CC5_A372BanCod ;
      private string[] P00CC5_A378CBCueCod ;
      private int[] P00CC5_A180MonCod ;
      private string[] P00CC5_A377CBCod ;
      private string[] P00CC5_A484BanSunat ;
   }

   public class rrlibro3_2__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CC3( IGxContext context ,
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
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[COSCod], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T2.[VouGls], T1.[VouDTipCod], T1.[VouDGls], T1.[VouDMon], T1.[VouDDebO], T1.[VouDHabO], T1.[VouDDeb], T1.[VouDHab], T1.[VouDFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
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
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[VouDFec]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00CC4( IGxContext context ,
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
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T1.[COSCod], T2.[VouSts], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV25CueCod)");
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
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00CC3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] );
               case 2 :
                     return conditional_P00CC4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CC2;
          prmP00CC2 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0)
          };
          Object[] prmP00CC5;
          prmP00CC5 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0)
          };
          Object[] prmP00CC3;
          prmP00CC3 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00CC4;
          prmP00CC4 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CC2", "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouAno], T2.[CueDsc], T2.[TipACod], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (SUBSTRING(T1.[CueCod], 1, 2) = '10') AND (T1.[VouAno] = @AV11Ano) ORDER BY T1.[CueCod], T1.[CueCodAux] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CC3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CC4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CC5", "SELECT T1.[BanCod], T1.[CBCueCod], T1.[MonCod], T1.[CBCod], T2.[BanSunat] FROM ([TSCUENTABANCO] T1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = T1.[BanCod]) WHERE T1.[CBCueCod] = @AV25CueCod ORDER BY T1.[CBCueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC5,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(17);
                ((int[]) buf[18])[0] = rslt.getInt(18);
                return;
             case 2 :
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
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 5);
                return;
       }
    }

 }

}
