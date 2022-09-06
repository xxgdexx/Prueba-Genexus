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
   public class r_libro1_2pdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_libro1_2pdf.aspx")), "contabilidad.r_libro1_2pdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_libro1_2pdf.aspx")))) ;
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
               AV16Ano = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV53Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
                  AV22cCuenta1 = GetPar( "cCuenta1");
                  AV23cCuenta2 = GetPar( "cCuenta2");
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

      public r_libro1_2pdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_libro1_2pdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref string aP2_cCuenta1 ,
                           ref string aP3_cCuenta2 )
      {
         this.AV16Ano = aP0_Ano;
         this.AV53Mes = aP1_Mes;
         this.AV22cCuenta1 = aP2_cCuenta1;
         this.AV23cCuenta2 = aP3_cCuenta2;
         initialize();
         executePrivate();
         aP0_Ano=this.AV16Ano;
         aP1_Mes=this.AV53Mes;
         aP2_cCuenta1=this.AV22cCuenta1;
         aP3_cCuenta2=this.AV23cCuenta2;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref string aP2_cCuenta1 )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_cCuenta1, ref aP3_cCuenta2);
         return AV23cCuenta2 ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_cCuenta1 ,
                                 ref string aP3_cCuenta2 )
      {
         r_libro1_2pdf objr_libro1_2pdf;
         objr_libro1_2pdf = new r_libro1_2pdf();
         objr_libro1_2pdf.AV16Ano = aP0_Ano;
         objr_libro1_2pdf.AV53Mes = aP1_Mes;
         objr_libro1_2pdf.AV22cCuenta1 = aP2_cCuenta1;
         objr_libro1_2pdf.AV23cCuenta2 = aP3_cCuenta2;
         objr_libro1_2pdf.context.SetSubmitInitialConfig(context);
         objr_libro1_2pdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_libro1_2pdf);
         aP0_Ano=this.AV16Ano;
         aP1_Mes=this.AV53Mes;
         aP2_cCuenta1=this.AV22cCuenta1;
         aP3_cCuenta2=this.AV23cCuenta2;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_libro1_2pdf)stateInfo).executePrivate();
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
         M_bot = 2;
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
            P_lines = (int)(gxYPage-(lineHeight*2));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV35Empresa = StringUtil.Trim( AV63Session.Get("Empresa"));
            AV34EmpDir = AV63Session.Get("EmpDir");
            AV36EmpRUC = AV63Session.Get("EmpRUC");
            AV58Ruta = AV63Session.Get("RUTA") + "/Logo.jpg";
            AV52Logo = AV58Ruta;
            AV89Logo_GXI = GXDbFile.PathToUrl( AV58Ruta);
            GXt_char1 = AV24cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV53Mes, out  GXt_char1) ;
            AV24cMes = GXt_char1;
            AV54MesAnt = (short)(AV53Mes-1);
            AV77Titulo = "FORMATO 1.2: LIBRO CAJA Y BANCOS - DETALLE DE LOS MOVIMIENTOS DE LA CUENTA CORRIENTE";
            AV56Periodo = StringUtil.Upper( AV24cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Ano), 10, 0));
            /* Using cursor P00C42 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A378CBCueCod = P00C42_A378CBCueCod[0];
               A504CBSts = P00C42_A504CBSts[0];
               A491CBCueDsc = P00C42_A491CBCueDsc[0];
               A377CBCod = P00C42_A377CBCod[0];
               A372BanCod = P00C42_A372BanCod[0];
               A491CBCueDsc = P00C42_A491CBCueDsc[0];
               AV22cCuenta1 = A378CBCueCod;
               AV30CueDsc = A491CBCueDsc;
               AV19CBCod = A377CBCod;
               AV65TDebe = 0.00m;
               AV71THaber = 0.00m;
               /* Execute user subroutine: 'MOVIMIENTOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HC40( true, 0) ;
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
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         new GeneXus.Programs.contabilidad.psaldocuentames(context ).execute(  AV22cCuenta1,  AV16Ano,  AV54MesAnt, out  AV60SaldoDebe, out  AV61SaldoHaber, out  AV59Saldo) ;
         /* Execute user subroutine: 'VALIDAMOVIMIENTO' */
         S121 ();
         if (returnInSub) return;
         AV60SaldoDebe = ((AV59Saldo>Convert.ToDecimal(0)) ? AV59Saldo : (decimal)(0));
         AV61SaldoHaber = ((AV59Saldo<Convert.ToDecimal(0)) ? AV59Saldo*-1 : (decimal)(0));
         if ( ( AV44Flag == 1 ) || ! (Convert.ToDecimal(0)==AV59Saldo) )
         {
            /* Using cursor P00C43 */
            pr_default.execute(1, new Object[] {AV16Ano, AV53Mes, AV22cCuenta1});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A127VouAno = P00C43_A127VouAno[0];
               A128VouMes = P00C43_A128VouMes[0];
               A91CueCod = P00C43_A91CueCod[0];
               A2077VouSts = P00C43_A2077VouSts[0];
               A126TASICod = P00C43_A126TASICod[0];
               A129VouNum = P00C43_A129VouNum[0];
               A2059VouDRef1 = P00C43_A2059VouDRef1[0];
               A2062VouDRef3 = P00C43_A2062VouDRef3[0];
               A2054VouDGls = P00C43_A2054VouDGls[0];
               A2061VouDRef2 = P00C43_A2061VouDRef2[0];
               A2063VouDRef4 = P00C43_A2063VouDRef4[0];
               A2053VouDDoc = P00C43_A2053VouDDoc[0];
               A860CueDsc = P00C43_A860CueDsc[0];
               A2055VouDHab = P00C43_A2055VouDHab[0];
               A2051VouDDeb = P00C43_A2051VouDDeb[0];
               A136VouReg = P00C43_A136VouReg[0];
               A135VouDFec = P00C43_A135VouDFec[0];
               A130VouDSec = P00C43_A130VouDSec[0];
               A860CueDsc = P00C43_A860CueDsc[0];
               A2077VouSts = P00C43_A2077VouSts[0];
               AV64TASICod = A126TASICod;
               AV84VouNum = A129VouNum;
               AV11VouDRef1 = A2059VouDRef1;
               AV15VouReg = A136VouReg;
               AV9VouDFec = A135VouDFec;
               AV13VouDRef3 = A2062VouDRef3;
               AV10VouDGls = StringUtil.Trim( A2054VouDGls);
               AV12VouDRef2 = StringUtil.Trim( A2061VouDRef2);
               AV13VouDRef3 = StringUtil.Trim( A2062VouDRef3);
               AV14VouDRef4 = StringUtil.Trim( A2063VouDRef4);
               AV8VouDDoc = StringUtil.Trim( A2053VouDDoc);
               AV85DCueCod = A91CueCod;
               AV86DCueDsc = StringUtil.Trim( A860CueDsc);
               AV47LBDDebe = A2055VouDHab;
               AV48LBDHaber = A2051VouDDeb;
               AV65TDebe = (decimal)(AV65TDebe+AV47LBDDebe);
               AV71THaber = (decimal)(AV71THaber+AV48LBDHaber);
               HC40( false, 18) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8VouDDoc, "")), 653, Gx_line+2, 751, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15VouReg, "")), 10, Gx_line+2, 74, Gx_line+13, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV9VouDFec, "99/99/99"), 102, Gx_line+2, 134, Gx_line+13, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10VouDGls, "")), 256, Gx_line+2, 445, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12VouDRef2, "")), 452, Gx_line+2, 648, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85DCueCod, "")), 760, Gx_line+2, 826, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV86DCueDsc, "")), 831, Gx_line+2, 969, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48LBDHaber, "ZZZZZZ,ZZZ,ZZ9.99")), 975, Gx_line+2, 1047, Gx_line+13, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47LBDDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 1056, Gx_line+2, 1128, Gx_line+13, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13VouDRef3, "")), 185, Gx_line+2, 233, Gx_line+13, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV80TSaldo = (decimal)((AV60SaldoDebe+AV71THaber)-(AV61SaldoHaber+AV65TDebe));
            HC40( false, 77) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71THaber, "ZZZZZZ,ZZZ,ZZ9.99")), 975, Gx_line+17, 1047, Gx_line+28, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(967, Gx_line+7, 1133, Gx_line+7, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("MOVIMIENTOS DEL MES", 825, Gx_line+15, 927, Gx_line+25, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SALDO ANTERIOR", 851, Gx_line+35, 927, Gx_line+45, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SALDO FINAL", 870, Gx_line+56, 927, Gx_line+66, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60SaldoDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 975, Gx_line+36, 1047, Gx_line+47, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61SaldoHaber, "ZZZZZZ,ZZZ,ZZ9.99")), 1056, Gx_line+36, 1128, Gx_line+47, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV80TSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 975, Gx_line+58, 1047, Gx_line+69, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 1056, Gx_line+17, 1128, Gx_line+28, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+77);
            /* Eject command */
            Gx_OldLine = Gx_line;
            Gx_line = (int)(P_lines+1);
         }
      }

      protected void S121( )
      {
         /* 'VALIDAMOVIMIENTO' Routine */
         returnInSub = false;
         AV44Flag = 0;
         /* Using cursor P00C44 */
         pr_default.execute(2, new Object[] {AV16Ano, AV53Mes, AV22cCuenta1});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00C44_A126TASICod[0];
            A129VouNum = P00C44_A129VouNum[0];
            A2077VouSts = P00C44_A2077VouSts[0];
            A91CueCod = P00C44_A91CueCod[0];
            A128VouMes = P00C44_A128VouMes[0];
            A127VouAno = P00C44_A127VouAno[0];
            A130VouDSec = P00C44_A130VouDSec[0];
            A2077VouSts = P00C44_A2077VouSts[0];
            AV44Flag = 1;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         /* Using cursor P00C45 */
         pr_default.execute(3, new Object[] {AV16Ano, AV53Mes, AV64TASICod, AV84VouNum, AV22cCuenta1, AV11VouDRef1});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A91CueCod = P00C45_A91CueCod[0];
            A2059VouDRef1 = P00C45_A2059VouDRef1[0];
            A129VouNum = P00C45_A129VouNum[0];
            A126TASICod = P00C45_A126TASICod[0];
            A128VouMes = P00C45_A128VouMes[0];
            A127VouAno = P00C45_A127VouAno[0];
            A136VouReg = P00C45_A136VouReg[0];
            A135VouDFec = P00C45_A135VouDFec[0];
            A2062VouDRef3 = P00C45_A2062VouDRef3[0];
            A2054VouDGls = P00C45_A2054VouDGls[0];
            A2061VouDRef2 = P00C45_A2061VouDRef2[0];
            A2063VouDRef4 = P00C45_A2063VouDRef4[0];
            A2053VouDDoc = P00C45_A2053VouDDoc[0];
            A860CueDsc = P00C45_A860CueDsc[0];
            A2051VouDDeb = P00C45_A2051VouDDeb[0];
            A2055VouDHab = P00C45_A2055VouDHab[0];
            A130VouDSec = P00C45_A130VouDSec[0];
            A860CueDsc = P00C45_A860CueDsc[0];
            AV15VouReg = A136VouReg;
            AV9VouDFec = A135VouDFec;
            AV13VouDRef3 = A2062VouDRef3;
            AV10VouDGls = StringUtil.Trim( A2054VouDGls);
            AV12VouDRef2 = StringUtil.Trim( A2061VouDRef2);
            AV13VouDRef3 = StringUtil.Trim( A2062VouDRef3);
            AV14VouDRef4 = StringUtil.Trim( A2063VouDRef4);
            AV8VouDDoc = StringUtil.Trim( A2053VouDDoc);
            AV85DCueCod = A91CueCod;
            AV86DCueDsc = StringUtil.Trim( A860CueDsc);
            AV47LBDDebe = A2051VouDDeb;
            AV48LBDHaber = A2055VouDHab;
            HC40( false, 18) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8VouDDoc, "")), 653, Gx_line+2, 751, Gx_line+13, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15VouReg, "")), 10, Gx_line+2, 74, Gx_line+13, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV9VouDFec, "99/99/99"), 102, Gx_line+2, 134, Gx_line+13, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10VouDGls, "")), 256, Gx_line+2, 445, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12VouDRef2, "")), 452, Gx_line+2, 648, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85DCueCod, "")), 760, Gx_line+2, 826, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV86DCueDsc, "")), 831, Gx_line+2, 969, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48LBDHaber, "ZZZZZZ,ZZZ,ZZ9.99")), 975, Gx_line+2, 1047, Gx_line+13, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47LBDDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 1056, Gx_line+2, 1128, Gx_line+13, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13VouDRef3, "")), 185, Gx_line+2, 233, Gx_line+13, 1, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+18);
            AV65TDebe = (decimal)(AV65TDebe+A2051VouDDeb);
            AV71THaber = (decimal)(AV71THaber+A2055VouDHab);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void HC40( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77Titulo, "")), 19, Gx_line+8, 541, Gx_line+24, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Periodo, "")), 81, Gx_line+34, 603, Gx_line+49, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Empresa, "")), 18, Gx_line+71, 540, Gx_line+86, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36EmpRUC, "")), 81, Gx_line+52, 186, Gx_line+67, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 1027, Gx_line+29, 1071, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1077, Gx_line+29, 1116, Gx_line+44, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 18, Gx_line+34, 74, Gx_line+48, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 18, Gx_line+52, 49, Gx_line+66, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("ENTIDAD FINANCIERA :", 18, Gx_line+90, 149, Gx_line+104, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("CÓDIGO DE LA CUENTA CORRIENTE:", 18, Gx_line+107, 219, Gx_line+121, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30CueDsc, "")), 225, Gx_line+90, 747, Gx_line+105, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CBCod, "")), 225, Gx_line+107, 330, Gx_line+122, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("CUENTA CONTABLE", 410, Gx_line+107, 517, Gx_line+121, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22cCuenta1, "")), 526, Gx_line+107, 605, Gx_line+122, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+124);
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Código", 769, Gx_line+30, 798, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Denominación", 849, Gx_line+30, 909, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Med. de Pago", 188, Gx_line+22, 245, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Descripción de Operación", 298, Gx_line+29, 402, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(94, Gx_line+1, 94, Gx_line+49, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(254, Gx_line+17, 254, Gx_line+49, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(751, Gx_line+1, 751, Gx_line+49, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("SALDOS Y MOVIMIENTOS", 998, Gx_line+5, 1104, Gx_line+15, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha de ", 113, Gx_line+14, 154, Gx_line+24, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 1136, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Deudor", 996, Gx_line+30, 1027, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Apellidos y Nombres", 502, Gx_line+22, 586, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(171, Gx_line+16, 1136, Gx_line+16, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Número", 31, Gx_line+8, 65, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("del Registro", 24, Gx_line+32, 74, Gx_line+42, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(170, Gx_line+0, 170, Gx_line+49, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Operación", 111, Gx_line+25, 154, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("(Tabla 1)", 196, Gx_line+34, 236, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(446, Gx_line+17, 446, Gx_line+49, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Denominación o Razón Social", 482, Gx_line+36, 604, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(651, Gx_line+18, 651, Gx_line+49, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(970, Gx_line+0, 970, Gx_line+49, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1053, Gx_line+17, 1053, Gx_line+48, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Acreedor", 1071, Gx_line+30, 1108, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("CUENTA CONTABLE ASOCIADA", 792, Gx_line+5, 917, Gx_line+15, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(826, Gx_line+17, 826, Gx_line+48, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("OPERACIONES BANCARIAS", 376, Gx_line+5, 487, Gx_line+15, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Número de", 681, Gx_line+18, 728, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Transacción", 679, Gx_line+29, 729, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Bancaria", 686, Gx_line+39, 722, Gx_line+49, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Correlativo", 25, Gx_line+19, 71, Gx_line+29, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+50);
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
         AV35Empresa = "";
         AV63Session = context.GetSession();
         AV34EmpDir = "";
         AV36EmpRUC = "";
         AV58Ruta = "";
         AV52Logo = "";
         AV89Logo_GXI = "";
         AV24cMes = "";
         GXt_char1 = "";
         AV77Titulo = "";
         AV56Periodo = "";
         scmdbuf = "";
         P00C42_A378CBCueCod = new string[] {""} ;
         P00C42_A504CBSts = new short[1] ;
         P00C42_A491CBCueDsc = new string[] {""} ;
         P00C42_A377CBCod = new string[] {""} ;
         P00C42_A372BanCod = new int[1] ;
         A378CBCueCod = "";
         A491CBCueDsc = "";
         A377CBCod = "";
         AV30CueDsc = "";
         AV19CBCod = "";
         P00C43_A127VouAno = new short[1] ;
         P00C43_A128VouMes = new short[1] ;
         P00C43_A91CueCod = new string[] {""} ;
         P00C43_A2077VouSts = new short[1] ;
         P00C43_A126TASICod = new int[1] ;
         P00C43_A129VouNum = new string[] {""} ;
         P00C43_A2059VouDRef1 = new string[] {""} ;
         P00C43_A2062VouDRef3 = new string[] {""} ;
         P00C43_A2054VouDGls = new string[] {""} ;
         P00C43_A2061VouDRef2 = new string[] {""} ;
         P00C43_A2063VouDRef4 = new string[] {""} ;
         P00C43_A2053VouDDoc = new string[] {""} ;
         P00C43_A860CueDsc = new string[] {""} ;
         P00C43_A2055VouDHab = new decimal[1] ;
         P00C43_A2051VouDDeb = new decimal[1] ;
         P00C43_A136VouReg = new string[] {""} ;
         P00C43_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00C43_A130VouDSec = new int[1] ;
         A91CueCod = "";
         A129VouNum = "";
         A2059VouDRef1 = "";
         A2062VouDRef3 = "";
         A2054VouDGls = "";
         A2061VouDRef2 = "";
         A2063VouDRef4 = "";
         A2053VouDDoc = "";
         A860CueDsc = "";
         A136VouReg = "";
         A135VouDFec = DateTime.MinValue;
         AV84VouNum = "";
         AV11VouDRef1 = "";
         AV15VouReg = "";
         AV9VouDFec = DateTime.MinValue;
         AV13VouDRef3 = "";
         AV10VouDGls = "";
         AV12VouDRef2 = "";
         AV14VouDRef4 = "";
         AV8VouDDoc = "";
         AV85DCueCod = "";
         AV86DCueDsc = "";
         P00C44_A126TASICod = new int[1] ;
         P00C44_A129VouNum = new string[] {""} ;
         P00C44_A2077VouSts = new short[1] ;
         P00C44_A91CueCod = new string[] {""} ;
         P00C44_A128VouMes = new short[1] ;
         P00C44_A127VouAno = new short[1] ;
         P00C44_A130VouDSec = new int[1] ;
         P00C45_A91CueCod = new string[] {""} ;
         P00C45_A2059VouDRef1 = new string[] {""} ;
         P00C45_A129VouNum = new string[] {""} ;
         P00C45_A126TASICod = new int[1] ;
         P00C45_A128VouMes = new short[1] ;
         P00C45_A127VouAno = new short[1] ;
         P00C45_A136VouReg = new string[] {""} ;
         P00C45_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00C45_A2062VouDRef3 = new string[] {""} ;
         P00C45_A2054VouDGls = new string[] {""} ;
         P00C45_A2061VouDRef2 = new string[] {""} ;
         P00C45_A2063VouDRef4 = new string[] {""} ;
         P00C45_A2053VouDDoc = new string[] {""} ;
         P00C45_A860CueDsc = new string[] {""} ;
         P00C45_A2051VouDDeb = new decimal[1] ;
         P00C45_A2055VouDHab = new decimal[1] ;
         P00C45_A130VouDSec = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_libro1_2pdf__default(),
            new Object[][] {
                new Object[] {
               P00C42_A378CBCueCod, P00C42_A504CBSts, P00C42_A491CBCueDsc, P00C42_A377CBCod, P00C42_A372BanCod
               }
               , new Object[] {
               P00C43_A127VouAno, P00C43_A128VouMes, P00C43_A91CueCod, P00C43_A2077VouSts, P00C43_A126TASICod, P00C43_A129VouNum, P00C43_A2059VouDRef1, P00C43_A2062VouDRef3, P00C43_A2054VouDGls, P00C43_A2061VouDRef2,
               P00C43_A2063VouDRef4, P00C43_A2053VouDDoc, P00C43_A860CueDsc, P00C43_A2055VouDHab, P00C43_A2051VouDDeb, P00C43_A136VouReg, P00C43_A135VouDFec, P00C43_A130VouDSec
               }
               , new Object[] {
               P00C44_A126TASICod, P00C44_A129VouNum, P00C44_A2077VouSts, P00C44_A91CueCod, P00C44_A128VouMes, P00C44_A127VouAno, P00C44_A130VouDSec
               }
               , new Object[] {
               P00C45_A91CueCod, P00C45_A2059VouDRef1, P00C45_A129VouNum, P00C45_A126TASICod, P00C45_A128VouMes, P00C45_A127VouAno, P00C45_A136VouReg, P00C45_A135VouDFec, P00C45_A2062VouDRef3, P00C45_A2054VouDGls,
               P00C45_A2061VouDRef2, P00C45_A2063VouDRef4, P00C45_A2053VouDDoc, P00C45_A860CueDsc, P00C45_A2051VouDDeb, P00C45_A2055VouDHab, P00C45_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV16Ano ;
      private short AV53Mes ;
      private short AV54MesAnt ;
      private short A504CBSts ;
      private short AV44Flag ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short A2077VouSts ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A372BanCod ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int AV64TASICod ;
      private int Gx_OldLine ;
      private decimal AV65TDebe ;
      private decimal AV71THaber ;
      private decimal AV60SaldoDebe ;
      private decimal AV61SaldoHaber ;
      private decimal AV59Saldo ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private decimal AV47LBDDebe ;
      private decimal AV48LBDHaber ;
      private decimal AV80TSaldo ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV22cCuenta1 ;
      private string AV23cCuenta2 ;
      private string AV35Empresa ;
      private string AV34EmpDir ;
      private string AV36EmpRUC ;
      private string AV58Ruta ;
      private string AV24cMes ;
      private string GXt_char1 ;
      private string AV77Titulo ;
      private string AV56Periodo ;
      private string scmdbuf ;
      private string A378CBCueCod ;
      private string A491CBCueDsc ;
      private string A377CBCod ;
      private string AV30CueDsc ;
      private string AV19CBCod ;
      private string A91CueCod ;
      private string A129VouNum ;
      private string A2054VouDGls ;
      private string A2053VouDDoc ;
      private string A860CueDsc ;
      private string A136VouReg ;
      private string AV84VouNum ;
      private string AV15VouReg ;
      private string AV10VouDGls ;
      private string AV8VouDDoc ;
      private string AV85DCueCod ;
      private string AV86DCueDsc ;
      private DateTime A135VouDFec ;
      private DateTime AV9VouDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private string AV89Logo_GXI ;
      private string A2059VouDRef1 ;
      private string A2062VouDRef3 ;
      private string A2061VouDRef2 ;
      private string A2063VouDRef4 ;
      private string AV11VouDRef1 ;
      private string AV13VouDRef3 ;
      private string AV12VouDRef2 ;
      private string AV14VouDRef4 ;
      private string AV52Logo ;
      private IGxSession AV63Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_cCuenta1 ;
      private string aP3_cCuenta2 ;
      private IDataStoreProvider pr_default ;
      private string[] P00C42_A378CBCueCod ;
      private short[] P00C42_A504CBSts ;
      private string[] P00C42_A491CBCueDsc ;
      private string[] P00C42_A377CBCod ;
      private int[] P00C42_A372BanCod ;
      private short[] P00C43_A127VouAno ;
      private short[] P00C43_A128VouMes ;
      private string[] P00C43_A91CueCod ;
      private short[] P00C43_A2077VouSts ;
      private int[] P00C43_A126TASICod ;
      private string[] P00C43_A129VouNum ;
      private string[] P00C43_A2059VouDRef1 ;
      private string[] P00C43_A2062VouDRef3 ;
      private string[] P00C43_A2054VouDGls ;
      private string[] P00C43_A2061VouDRef2 ;
      private string[] P00C43_A2063VouDRef4 ;
      private string[] P00C43_A2053VouDDoc ;
      private string[] P00C43_A860CueDsc ;
      private decimal[] P00C43_A2055VouDHab ;
      private decimal[] P00C43_A2051VouDDeb ;
      private string[] P00C43_A136VouReg ;
      private DateTime[] P00C43_A135VouDFec ;
      private int[] P00C43_A130VouDSec ;
      private int[] P00C44_A126TASICod ;
      private string[] P00C44_A129VouNum ;
      private short[] P00C44_A2077VouSts ;
      private string[] P00C44_A91CueCod ;
      private short[] P00C44_A128VouMes ;
      private short[] P00C44_A127VouAno ;
      private int[] P00C44_A130VouDSec ;
      private string[] P00C45_A91CueCod ;
      private string[] P00C45_A2059VouDRef1 ;
      private string[] P00C45_A129VouNum ;
      private int[] P00C45_A126TASICod ;
      private short[] P00C45_A128VouMes ;
      private short[] P00C45_A127VouAno ;
      private string[] P00C45_A136VouReg ;
      private DateTime[] P00C45_A135VouDFec ;
      private string[] P00C45_A2062VouDRef3 ;
      private string[] P00C45_A2054VouDGls ;
      private string[] P00C45_A2061VouDRef2 ;
      private string[] P00C45_A2063VouDRef4 ;
      private string[] P00C45_A2053VouDDoc ;
      private string[] P00C45_A860CueDsc ;
      private decimal[] P00C45_A2051VouDDeb ;
      private decimal[] P00C45_A2055VouDHab ;
      private int[] P00C45_A130VouDSec ;
   }

   public class r_libro1_2pdf__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00C42;
          prmP00C42 = new Object[] {
          };
          Object[] prmP00C43;
          prmP00C43 = new Object[] {
          new ParDef("@AV16Ano",GXType.Int16,4,0) ,
          new ParDef("@AV53Mes",GXType.Int16,2,0) ,
          new ParDef("@AV22cCuenta1",GXType.NChar,15,0)
          };
          Object[] prmP00C44;
          prmP00C44 = new Object[] {
          new ParDef("@AV16Ano",GXType.Int16,4,0) ,
          new ParDef("@AV53Mes",GXType.Int16,2,0) ,
          new ParDef("@AV22cCuenta1",GXType.NChar,15,0)
          };
          Object[] prmP00C45;
          prmP00C45 = new Object[] {
          new ParDef("@AV16Ano",GXType.Int16,4,0) ,
          new ParDef("@AV53Mes",GXType.Int16,2,0) ,
          new ParDef("@AV64TASICod",GXType.Int32,6,0) ,
          new ParDef("@AV84VouNum",GXType.NChar,10,0) ,
          new ParDef("@AV22cCuenta1",GXType.Char,15,0) ,
          new ParDef("@AV11VouDRef1",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C42", "SELECT T1.[CBCueCod] AS CBCueCod, T1.[CBSts], T2.[CueDsc] AS CBCueDsc, T1.[CBCod], T1.[BanCod] FROM ([TSCUENTABANCO] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CBCueCod]) WHERE (SUBSTRING(T1.[CBCueCod], 1, 3) = '104') AND (T1.[CBSts] = 1) ORDER BY T1.[CBCueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C42,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C43", "SELECT T1.[VouAno], T1.[VouMes], T1.[CueCod], T3.[VouSts], T1.[TASICod], T1.[VouNum], T1.[VouDRef1], T1.[VouDRef3], T1.[VouDGls], T1.[VouDRef2], T1.[VouDRef4], T1.[VouDDoc], T2.[CueDsc], T1.[VouDHab], T1.[VouDDeb], T1.[VouReg], T1.[VouDFec], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV16Ano) AND (T1.[VouMes] = @AV53Mes) AND (T1.[CueCod] = @AV22cCuenta1) AND (T3.[VouSts] = 1) ORDER BY T1.[VouDFec], T1.[VouReg] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C43,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C44", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV16Ano and T1.[VouMes] = @AV53Mes and T1.[CueCod] = @AV22cCuenta1) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C44,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C45", "SELECT T1.[CueCod], T1.[VouDRef1], T1.[VouNum], T1.[TASICod], T1.[VouMes], T1.[VouAno], T1.[VouReg], T1.[VouDFec], T1.[VouDRef3], T1.[VouDGls], T1.[VouDRef2], T1.[VouDRef4], T1.[VouDDoc], T2.[CueDsc], T1.[VouDDeb], T1.[VouDHab], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (T1.[VouAno] = @AV16Ano and T1.[VouMes] = @AV53Mes and T1.[TASICod] = @AV64TASICod and T1.[VouNum] = @AV84VouNum) AND (T1.[CueCod] <> @AV22cCuenta1) AND (Not (T1.[VouDRef1] = '')) AND (T1.[VouDRef1] = @AV11VouDRef1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C45,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((string[]) buf[12])[0] = rslt.getString(13, 100);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 15);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
                ((int[]) buf[17])[0] = rslt.getInt(18);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 20);
                ((string[]) buf[13])[0] = rslt.getString(14, 100);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((int[]) buf[16])[0] = rslt.getInt(17);
                return;
       }
    }

 }

}
