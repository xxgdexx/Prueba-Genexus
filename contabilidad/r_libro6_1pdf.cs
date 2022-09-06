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
   public class r_libro6_1pdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_libro6_1pdf.aspx")), "contabilidad.r_libro6_1pdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_libro6_1pdf.aspx")))) ;
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
               AV8Ano = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV34Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
                  AV10cCuenta1 = GetPar( "cCuenta1");
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

      public r_libro6_1pdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_libro6_1pdf( IGxContext context )
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
         this.AV8Ano = aP0_Ano;
         this.AV34Mes = aP1_Mes;
         this.AV10cCuenta1 = aP2_cCuenta1;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV34Mes;
         aP2_cCuenta1=this.AV10cCuenta1;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_cCuenta1);
         return AV10cCuenta1 ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_cCuenta1 )
      {
         r_libro6_1pdf objr_libro6_1pdf;
         objr_libro6_1pdf = new r_libro6_1pdf();
         objr_libro6_1pdf.AV8Ano = aP0_Ano;
         objr_libro6_1pdf.AV34Mes = aP1_Mes;
         objr_libro6_1pdf.AV10cCuenta1 = aP2_cCuenta1;
         objr_libro6_1pdf.context.SetSubmitInitialConfig(context);
         objr_libro6_1pdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_libro6_1pdf);
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV34Mes;
         aP2_cCuenta1=this.AV10cCuenta1;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_libro6_1pdf)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 9, 16834, 11909, 0, 1, 1, 0, 1, 1) )
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
            AV22Empresa = AV45Session.Get("Empresa");
            AV21EmpDir = AV45Session.Get("EmpDir");
            AV23EmpRUC = AV45Session.Get("EmpRUC");
            AV37Ruta = AV45Session.Get("RUTA") + "/Logo.jpg";
            AV33Logo = AV37Ruta;
            AV77Logo_GXI = GXDbFile.PathToUrl( AV37Ruta);
            AV27FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV34Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0));
            AV28FechaD = context.localUtil.CToD( AV27FechaC, 2);
            GXt_char1 = AV12cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV34Mes, out  GXt_char1) ;
            AV12cMes = GXt_char1;
            AV62Titulo = "FORMATO 6.1: LIBRO MAYOR";
            AV35Periodo = StringUtil.Upper( AV12cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0));
            AV52TDebeMO = 0.00m;
            AV59ThaberMO = 0.00m;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV10cCuenta1 ,
                                                 A91CueCod ,
                                                 A127VouAno ,
                                                 AV8Ano } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00CA2 */
            pr_default.execute(0, new Object[] {AV8Ano, AV10cCuenta1});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKCA3 = false;
               A133CueCodAux = P00CA2_A133CueCodAux[0];
               A91CueCod = P00CA2_A91CueCod[0];
               A127VouAno = P00CA2_A127VouAno[0];
               A860CueDsc = P00CA2_A860CueDsc[0];
               A128VouMes = P00CA2_A128VouMes[0];
               A126TASICod = P00CA2_A126TASICod[0];
               A129VouNum = P00CA2_A129VouNum[0];
               A130VouDSec = P00CA2_A130VouDSec[0];
               A860CueDsc = P00CA2_A860CueDsc[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00CA2_A91CueCod[0], A91CueCod) == 0 ) )
               {
                  BRKCA3 = false;
                  A133CueCodAux = P00CA2_A133CueCodAux[0];
                  A127VouAno = P00CA2_A127VouAno[0];
                  A128VouMes = P00CA2_A128VouMes[0];
                  A126TASICod = P00CA2_A126TASICod[0];
                  A129VouNum = P00CA2_A129VouNum[0];
                  A130VouDSec = P00CA2_A130VouDSec[0];
                  BRKCA3 = true;
                  pr_default.readNext(0);
               }
               AV15CueCod = StringUtil.Trim( A91CueCod);
               AV18CueDsc = StringUtil.Trim( A860CueDsc);
               AV19Cuenta = StringUtil.Trim( AV15CueCod) + " - " + StringUtil.Trim( AV18CueDsc);
               new GeneXus.Programs.contabilidad.pobtienesaldoscuenta(context ).execute( ref  AV15CueCod, ref  AV8Ano, ref  AV34Mes, out  AV40SaldoDMN, out  AV42SaldoHMN, out  AV39SaldoDME, out  AV41SaldoHME) ;
               AV38Saldo = (decimal)(AV40SaldoDMN-AV42SaldoHMN);
               AV48TDebe = 0.00m;
               AV55THaber = 0.00m;
               /* Execute user subroutine: 'VALIDAMOVIMIENTOS' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! (Convert.ToDecimal(0)==AV38Saldo) || ( AV30Flag == 1 ) )
               {
                  HCA0( false, 15) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("CÓDIGO Y/O DENOMINACIÓN DE LA CUENTA CONTABLE :", 8, Gx_line+0, 324, Gx_line+14, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Cuenta, "")), 342, Gx_line+0, 748, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+15);
                  /* Execute user subroutine: 'MOVIMIENTOS' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
                  AV52TDebeMO = (decimal)(AV52TDebeMO+AV48TDebe);
                  AV59ThaberMO = (decimal)(AV59ThaberMO+AV55THaber);
                  AV65TSaldo = (decimal)((AV48TDebe+AV40SaldoDMN)-(AV55THaber+AV42SaldoHMN));
                  AV66TTDebe = ((AV65TSaldo>Convert.ToDecimal(0)) ? AV65TSaldo : (decimal)(0));
                  AV67TTHaber = ((AV65TSaldo>Convert.ToDecimal(0)) ? (decimal)(0) : AV65TSaldo*-1);
                  HCA0( false, 45) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48TDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 625, Gx_line+6, 697, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55THaber, "ZZZZZZ,ZZZ,ZZ9.99")), 729, Gx_line+6, 801, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(611, Gx_line+2, 811, Gx_line+2, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("MOVIMIENTOS DEL MES", 488, Gx_line+6, 590, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("SALDO ANTERIOR", 514, Gx_line+18, 590, Gx_line+28, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("SALDO FINAL", 532, Gx_line+30, 589, Gx_line+40, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40SaldoDMN, "ZZZZZZ,ZZZ,ZZ9.99")), 625, Gx_line+18, 697, Gx_line+29, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42SaldoHMN, "ZZZZZZ,ZZZ,ZZ9.99")), 729, Gx_line+18, 801, Gx_line+29, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66TTDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 625, Gx_line+30, 697, Gx_line+41, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67TTHaber, "ZZZZZZ,ZZZ,ZZ9.99")), 729, Gx_line+30, 801, Gx_line+41, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+45);
               }
               if ( ! BRKCA3 )
               {
                  BRKCA3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HCA0( false, 30) ;
            getPrinter().GxDrawLine(600, Gx_line+5, 811, Gx_line+5, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("TOTAL GENERAL", 520, Gx_line+11, 590, Gx_line+21, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TDebeMO, "ZZZZZZ,ZZZ,ZZ9.99")), 625, Gx_line+11, 697, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59ThaberMO, "ZZZZZZ,ZZZ,ZZ9.99")), 729, Gx_line+11, 801, Gx_line+22, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+30);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HCA0( true, 0) ;
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
         /* Using cursor P00CA3 */
         pr_default.execute(1, new Object[] {AV8Ano, AV34Mes, AV15CueCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A126TASICod = P00CA3_A126TASICod[0];
            A127VouAno = P00CA3_A127VouAno[0];
            A128VouMes = P00CA3_A128VouMes[0];
            A91CueCod = P00CA3_A91CueCod[0];
            A2077VouSts = P00CA3_A2077VouSts[0];
            A2069VouDTcmb = P00CA3_A2069VouDTcmb[0];
            A1894TASIAbr = P00CA3_A1894TASIAbr[0];
            A129VouNum = P00CA3_A129VouNum[0];
            A2075VouGls = P00CA3_A2075VouGls[0];
            A2054VouDGls = P00CA3_A2054VouDGls[0];
            A2053VouDDoc = P00CA3_A2053VouDDoc[0];
            A2055VouDHab = P00CA3_A2055VouDHab[0];
            A2051VouDDeb = P00CA3_A2051VouDDeb[0];
            A136VouReg = P00CA3_A136VouReg[0];
            A135VouDFec = P00CA3_A135VouDFec[0];
            A130VouDSec = P00CA3_A130VouDSec[0];
            A1894TASIAbr = P00CA3_A1894TASIAbr[0];
            A2077VouSts = P00CA3_A2077VouSts[0];
            A2075VouGls = P00CA3_A2075VouGls[0];
            AV46TASIAbr = StringUtil.Trim( A1894TASIAbr);
            AV73VouReg = StringUtil.Trim( A1894TASIAbr) + "-" + StringUtil.Trim( A129VouNum);
            AV74VouRegC = StringUtil.Trim( A136VouReg);
            AV31Glosa = (String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) ? StringUtil.Trim( A2075VouGls) : StringUtil.Trim( A2054VouDGls));
            AV69VouDDoc = (String.IsNullOrEmpty(StringUtil.RTrim( A2053VouDDoc)) ? StringUtil.Trim( A136VouReg) : StringUtil.Trim( A2053VouDDoc));
            HCA0( false, 13) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73VouReg, "")), 67, Gx_line+1, 131, Gx_line+12, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2051VouDDeb, "ZZZ,ZZZ,ZZ9.99")), 625, Gx_line+1, 689, Gx_line+12, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2055VouDHab, "ZZZ,ZZZ,ZZ9.99")), 729, Gx_line+1, 793, Gx_line+12, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31Glosa, "")), 325, Gx_line+0, 600, Gx_line+13, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( A135VouDFec, "99/99/99"), 6, Gx_line+1, 38, Gx_line+12, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69VouDDoc, "")), 223, Gx_line+0, 302, Gx_line+12, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74VouRegC, "")), 150, Gx_line+1, 214, Gx_line+12, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+13);
            AV48TDebe = (decimal)(AV48TDebe+A2051VouDDeb);
            AV55THaber = (decimal)(AV55THaber+A2055VouDHab);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'VALIDAMOVIMIENTOS' Routine */
         returnInSub = false;
         AV30Flag = 0;
         /* Using cursor P00CA4 */
         pr_default.execute(2, new Object[] {AV8Ano, AV34Mes, AV15CueCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00CA4_A126TASICod[0];
            A129VouNum = P00CA4_A129VouNum[0];
            A127VouAno = P00CA4_A127VouAno[0];
            A128VouMes = P00CA4_A128VouMes[0];
            A91CueCod = P00CA4_A91CueCod[0];
            A2077VouSts = P00CA4_A2077VouSts[0];
            A2069VouDTcmb = P00CA4_A2069VouDTcmb[0];
            A136VouReg = P00CA4_A136VouReg[0];
            A135VouDFec = P00CA4_A135VouDFec[0];
            A130VouDSec = P00CA4_A130VouDSec[0];
            A2077VouSts = P00CA4_A2077VouSts[0];
            AV30Flag = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void HCA0( bool bFoot ,
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
               getPrinter().GxDrawText("Página:", 718, Gx_line+19, 762, Gx_line+33, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 773, Gx_line+19, 812, Gx_line+34, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Titulo, "")), 14, Gx_line+8, 328, Gx_line+24, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Periodo, "")), 75, Gx_line+29, 597, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Empresa, "")), 12, Gx_line+61, 417, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23EmpRUC, "")), 75, Gx_line+45, 180, Gx_line+60, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 12, Gx_line+29, 68, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 12, Gx_line+45, 43, Gx_line+59, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+80);
               getPrinter().GxDrawLine(63, Gx_line+1, 63, Gx_line+46, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(588, Gx_line+1, 588, Gx_line+46, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("SALDOS Y MOVIMIENTOS", 646, Gx_line+7, 752, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 820, Gx_line+46, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("DEBE", 638, Gx_line+32, 661, Gx_line+42, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DEL LIBRO", 161, Gx_line+29, 208, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(220, Gx_line+0, 220, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(704, Gx_line+28, 704, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("HABER", 748, Gx_line+32, 777, Gx_line+42, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DESCRIPCIÓN O GLOSA", 390, Gx_line+9, 497, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("NÚMERO", 166, Gx_line+5, 205, Gx_line+15, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FECHA", 19, Gx_line+5, 47, Gx_line+15, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("OPERACIÓN", 7, Gx_line+29, 58, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(588, Gx_line+27, 820, Gx_line+27, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("DE LA OPERACIÓN", 404, Gx_line+24, 489, Gx_line+34, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("CORRELATIVO", 154, Gx_line+17, 215, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(301, Gx_line+0, 301, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("NÚMERO", 241, Gx_line+5, 280, Gx_line+15, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DOCUMENTO", 232, Gx_line+17, 287, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("SUSTENTO", 236, Gx_line+29, 282, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DE", 26, Gx_line+17, 38, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("NÚMERO", 88, Gx_line+5, 127, Gx_line+15, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("CORRELATIVO", 76, Gx_line+17, 137, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DEL ASIENTO", 78, Gx_line+29, 135, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(148, Gx_line+0, 148, Gx_line+46, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+46);
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
         AV22Empresa = "";
         AV45Session = context.GetSession();
         AV21EmpDir = "";
         AV23EmpRUC = "";
         AV37Ruta = "";
         AV33Logo = "";
         AV77Logo_GXI = "";
         AV27FechaC = "";
         AV28FechaD = DateTime.MinValue;
         AV12cMes = "";
         GXt_char1 = "";
         AV62Titulo = "";
         AV35Periodo = "";
         scmdbuf = "";
         A91CueCod = "";
         P00CA2_A133CueCodAux = new string[] {""} ;
         P00CA2_A91CueCod = new string[] {""} ;
         P00CA2_A127VouAno = new short[1] ;
         P00CA2_A860CueDsc = new string[] {""} ;
         P00CA2_A128VouMes = new short[1] ;
         P00CA2_A126TASICod = new int[1] ;
         P00CA2_A129VouNum = new string[] {""} ;
         P00CA2_A130VouDSec = new int[1] ;
         A133CueCodAux = "";
         A860CueDsc = "";
         A129VouNum = "";
         AV15CueCod = "";
         AV18CueDsc = "";
         AV19Cuenta = "";
         P00CA3_A126TASICod = new int[1] ;
         P00CA3_A127VouAno = new short[1] ;
         P00CA3_A128VouMes = new short[1] ;
         P00CA3_A91CueCod = new string[] {""} ;
         P00CA3_A2077VouSts = new short[1] ;
         P00CA3_A2069VouDTcmb = new decimal[1] ;
         P00CA3_A1894TASIAbr = new string[] {""} ;
         P00CA3_A129VouNum = new string[] {""} ;
         P00CA3_A2075VouGls = new string[] {""} ;
         P00CA3_A2054VouDGls = new string[] {""} ;
         P00CA3_A2053VouDDoc = new string[] {""} ;
         P00CA3_A2055VouDHab = new decimal[1] ;
         P00CA3_A2051VouDDeb = new decimal[1] ;
         P00CA3_A136VouReg = new string[] {""} ;
         P00CA3_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00CA3_A130VouDSec = new int[1] ;
         A1894TASIAbr = "";
         A2075VouGls = "";
         A2054VouDGls = "";
         A2053VouDDoc = "";
         A136VouReg = "";
         A135VouDFec = DateTime.MinValue;
         AV46TASIAbr = "";
         AV73VouReg = "";
         AV74VouRegC = "";
         AV31Glosa = "";
         AV69VouDDoc = "";
         P00CA4_A126TASICod = new int[1] ;
         P00CA4_A129VouNum = new string[] {""} ;
         P00CA4_A127VouAno = new short[1] ;
         P00CA4_A128VouMes = new short[1] ;
         P00CA4_A91CueCod = new string[] {""} ;
         P00CA4_A2077VouSts = new short[1] ;
         P00CA4_A2069VouDTcmb = new decimal[1] ;
         P00CA4_A136VouReg = new string[] {""} ;
         P00CA4_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00CA4_A130VouDSec = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_libro6_1pdf__default(),
            new Object[][] {
                new Object[] {
               P00CA2_A133CueCodAux, P00CA2_A91CueCod, P00CA2_A127VouAno, P00CA2_A860CueDsc, P00CA2_A128VouMes, P00CA2_A126TASICod, P00CA2_A129VouNum, P00CA2_A130VouDSec
               }
               , new Object[] {
               P00CA3_A126TASICod, P00CA3_A127VouAno, P00CA3_A128VouMes, P00CA3_A91CueCod, P00CA3_A2077VouSts, P00CA3_A2069VouDTcmb, P00CA3_A1894TASIAbr, P00CA3_A129VouNum, P00CA3_A2075VouGls, P00CA3_A2054VouDGls,
               P00CA3_A2053VouDDoc, P00CA3_A2055VouDHab, P00CA3_A2051VouDDeb, P00CA3_A136VouReg, P00CA3_A135VouDFec, P00CA3_A130VouDSec
               }
               , new Object[] {
               P00CA4_A126TASICod, P00CA4_A129VouNum, P00CA4_A127VouAno, P00CA4_A128VouMes, P00CA4_A91CueCod, P00CA4_A2077VouSts, P00CA4_A2069VouDTcmb, P00CA4_A136VouReg, P00CA4_A135VouDFec, P00CA4_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV8Ano ;
      private short AV34Mes ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short AV30Flag ;
      private short A2077VouSts ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int Gx_OldLine ;
      private decimal AV52TDebeMO ;
      private decimal AV59ThaberMO ;
      private decimal AV40SaldoDMN ;
      private decimal AV42SaldoHMN ;
      private decimal AV39SaldoDME ;
      private decimal AV41SaldoHME ;
      private decimal AV38Saldo ;
      private decimal AV48TDebe ;
      private decimal AV55THaber ;
      private decimal AV65TSaldo ;
      private decimal AV66TTDebe ;
      private decimal AV67TTHaber ;
      private decimal A2069VouDTcmb ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10cCuenta1 ;
      private string AV22Empresa ;
      private string AV21EmpDir ;
      private string AV23EmpRUC ;
      private string AV37Ruta ;
      private string AV27FechaC ;
      private string AV12cMes ;
      private string GXt_char1 ;
      private string AV62Titulo ;
      private string AV35Periodo ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A133CueCodAux ;
      private string A860CueDsc ;
      private string A129VouNum ;
      private string AV15CueCod ;
      private string AV18CueDsc ;
      private string AV19Cuenta ;
      private string A1894TASIAbr ;
      private string A2075VouGls ;
      private string A2054VouDGls ;
      private string A2053VouDDoc ;
      private string A136VouReg ;
      private string AV46TASIAbr ;
      private string AV73VouReg ;
      private string AV74VouRegC ;
      private string AV31Glosa ;
      private string AV69VouDDoc ;
      private DateTime AV28FechaD ;
      private DateTime A135VouDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKCA3 ;
      private bool returnInSub ;
      private string AV77Logo_GXI ;
      private string AV33Logo ;
      private IGxSession AV45Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_cCuenta1 ;
      private IDataStoreProvider pr_default ;
      private string[] P00CA2_A133CueCodAux ;
      private string[] P00CA2_A91CueCod ;
      private short[] P00CA2_A127VouAno ;
      private string[] P00CA2_A860CueDsc ;
      private short[] P00CA2_A128VouMes ;
      private int[] P00CA2_A126TASICod ;
      private string[] P00CA2_A129VouNum ;
      private int[] P00CA2_A130VouDSec ;
      private int[] P00CA3_A126TASICod ;
      private short[] P00CA3_A127VouAno ;
      private short[] P00CA3_A128VouMes ;
      private string[] P00CA3_A91CueCod ;
      private short[] P00CA3_A2077VouSts ;
      private decimal[] P00CA3_A2069VouDTcmb ;
      private string[] P00CA3_A1894TASIAbr ;
      private string[] P00CA3_A129VouNum ;
      private string[] P00CA3_A2075VouGls ;
      private string[] P00CA3_A2054VouDGls ;
      private string[] P00CA3_A2053VouDDoc ;
      private decimal[] P00CA3_A2055VouDHab ;
      private decimal[] P00CA3_A2051VouDDeb ;
      private string[] P00CA3_A136VouReg ;
      private DateTime[] P00CA3_A135VouDFec ;
      private int[] P00CA3_A130VouDSec ;
      private int[] P00CA4_A126TASICod ;
      private string[] P00CA4_A129VouNum ;
      private short[] P00CA4_A127VouAno ;
      private short[] P00CA4_A128VouMes ;
      private string[] P00CA4_A91CueCod ;
      private short[] P00CA4_A2077VouSts ;
      private decimal[] P00CA4_A2069VouDTcmb ;
      private string[] P00CA4_A136VouReg ;
      private DateTime[] P00CA4_A135VouDFec ;
      private int[] P00CA4_A130VouDSec ;
   }

   public class r_libro6_1pdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CA2( IGxContext context ,
                                             string AV10cCuenta1 ,
                                             string A91CueCod ,
                                             short A127VouAno ,
                                             short AV8Ano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[2];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouAno], T2.[CueDsc], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV8Ano)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cCuenta1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV10cCuenta1)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00CA2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CA3;
          prmP00CA3 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV34Mes",GXType.Int16,2,0) ,
          new ParDef("@AV15CueCod",GXType.NChar,15,0)
          };
          Object[] prmP00CA4;
          prmP00CA4 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV34Mes",GXType.Int16,2,0) ,
          new ParDef("@AV15CueCod",GXType.NChar,15,0)
          };
          Object[] prmP00CA2;
          prmP00CA2 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV10cCuenta1",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CA2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CA2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CA3", "SELECT T1.[TASICod], T1.[VouAno], T1.[VouMes], T1.[CueCod], T3.[VouSts], T1.[VouDTcmb], T2.[TASIAbr], T1.[VouNum], T3.[VouGls], T1.[VouDGls], T1.[VouDDoc], T1.[VouDHab], T1.[VouDDeb], T1.[VouReg], T1.[VouDFec], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano) AND (T1.[VouMes] = @AV34Mes) AND (T1.[CueCod] = @AV15CueCod) AND (T3.[VouSts] = 1) ORDER BY T1.[VouDFec], T1.[VouReg] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CA3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CA4", "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T1.[VouAno], T1.[VouMes], T1.[CueCod], T2.[VouSts], T1.[VouDTcmb], T1.[VouReg], T1.[VouDFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano) AND (T1.[VouMes] = @AV34Mes) AND (T1.[CueCod] = @AV15CueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouDFec], T1.[VouReg] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CA4,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((string[]) buf[7])[0] = rslt.getString(8, 10);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((string[]) buf[10])[0] = rslt.getString(11, 20);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((string[]) buf[13])[0] = rslt.getString(14, 15);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
                ((int[]) buf[15])[0] = rslt.getInt(16);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 15);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                return;
       }
    }

 }

}
