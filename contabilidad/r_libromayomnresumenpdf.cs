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
   public class r_libromayomnresumenpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_libromayomnresumenpdf.aspx")), "contabilidad.r_libromayomnresumenpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_libromayomnresumenpdf.aspx")))) ;
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
                  AV33cCosto = GetPar( "cCosto");
                  AV34cCuenta1 = GetPar( "cCuenta1");
                  AV35cCuenta2 = GetPar( "cCuenta2");
                  AV42cOpc = (short)(NumberUtil.Val( GetPar( "cOpc"), "."));
                  AV77CueCodAux = GetPar( "CueCodAux");
                  AV92TipoN = GetPar( "TipoN");
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

      public r_libromayomnresumenpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_libromayomnresumenpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref string aP2_cCosto ,
                           ref string aP3_cCuenta1 ,
                           ref string aP4_cCuenta2 ,
                           ref short aP5_cOpc ,
                           ref string aP6_CueCodAux ,
                           ref string aP7_TipoN )
      {
         this.AV11Ano = aP0_Ano;
         this.AV12Mes = aP1_Mes;
         this.AV33cCosto = aP2_cCosto;
         this.AV34cCuenta1 = aP3_cCuenta1;
         this.AV35cCuenta2 = aP4_cCuenta2;
         this.AV42cOpc = aP5_cOpc;
         this.AV77CueCodAux = aP6_CueCodAux;
         this.AV92TipoN = aP7_TipoN;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_cCosto=this.AV33cCosto;
         aP3_cCuenta1=this.AV34cCuenta1;
         aP4_cCuenta2=this.AV35cCuenta2;
         aP5_cOpc=this.AV42cOpc;
         aP6_CueCodAux=this.AV77CueCodAux;
         aP7_TipoN=this.AV92TipoN;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref string aP2_cCosto ,
                                ref string aP3_cCuenta1 ,
                                ref string aP4_cCuenta2 ,
                                ref short aP5_cOpc ,
                                ref string aP6_CueCodAux )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_cCosto, ref aP3_cCuenta1, ref aP4_cCuenta2, ref aP5_cOpc, ref aP6_CueCodAux, ref aP7_TipoN);
         return AV92TipoN ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_cCosto ,
                                 ref string aP3_cCuenta1 ,
                                 ref string aP4_cCuenta2 ,
                                 ref short aP5_cOpc ,
                                 ref string aP6_CueCodAux ,
                                 ref string aP7_TipoN )
      {
         r_libromayomnresumenpdf objr_libromayomnresumenpdf;
         objr_libromayomnresumenpdf = new r_libromayomnresumenpdf();
         objr_libromayomnresumenpdf.AV11Ano = aP0_Ano;
         objr_libromayomnresumenpdf.AV12Mes = aP1_Mes;
         objr_libromayomnresumenpdf.AV33cCosto = aP2_cCosto;
         objr_libromayomnresumenpdf.AV34cCuenta1 = aP3_cCuenta1;
         objr_libromayomnresumenpdf.AV35cCuenta2 = aP4_cCuenta2;
         objr_libromayomnresumenpdf.AV42cOpc = aP5_cOpc;
         objr_libromayomnresumenpdf.AV77CueCodAux = aP6_CueCodAux;
         objr_libromayomnresumenpdf.AV92TipoN = aP7_TipoN;
         objr_libromayomnresumenpdf.context.SetSubmitInitialConfig(context);
         objr_libromayomnresumenpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_libromayomnresumenpdf);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_cCosto=this.AV33cCosto;
         aP3_cCuenta1=this.AV34cCuenta1;
         aP4_cCuenta2=this.AV35cCuenta2;
         aP5_cOpc=this.AV42cOpc;
         aP6_CueCodAux=this.AV77CueCodAux;
         aP7_TipoN=this.AV92TipoN;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_libromayomnresumenpdf)stateInfo).executePrivate();
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
            AV73EmpRUC = AV30Session.Get("EmpRUC");
            AV75Ruta = AV30Session.Get("RUTA") + "/Logo.jpg";
            AV74Logo = AV75Ruta;
            AV95Logo_GXI = GXDbFile.PathToUrl( AV75Ruta);
            AV85UsuCod = AV30Session.Get("Usuario");
            AV87Totales1 = ((StringUtil.StrCmp(AV86Tipo, "R")==0) ? "Totales de la Cuenta" : "");
            AV72FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV72FechaC, 2);
            GXt_char1 = AV71cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV71cMes = GXt_char1;
            AV13Titulo = "Mayor General Analitico";
            AV14Periodo = "Año : " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0)) + " Mes : " + AV71cMes;
            AV78TDebePagMo = 0.00m;
            AV79THaberPagMo = 0.00m;
            AV80TDebePagMe = 0.00m;
            AV81THaberPagMe = 0.00m;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV34cCuenta1 ,
                                                 AV35cCuenta2 ,
                                                 AV77CueCodAux ,
                                                 A91CueCod ,
                                                 A133CueCodAux ,
                                                 A127VouAno ,
                                                 AV11Ano } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00BG2 */
            pr_default.execute(0, new Object[] {AV11Ano, AV34cCuenta1, AV35cCuenta2, AV77CueCodAux});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKBG3 = false;
               A133CueCodAux = P00BG2_A133CueCodAux[0];
               A91CueCod = P00BG2_A91CueCod[0];
               A127VouAno = P00BG2_A127VouAno[0];
               A860CueDsc = P00BG2_A860CueDsc[0];
               A70TipACod = P00BG2_A70TipACod[0];
               n70TipACod = P00BG2_n70TipACod[0];
               A128VouMes = P00BG2_A128VouMes[0];
               A126TASICod = P00BG2_A126TASICod[0];
               A129VouNum = P00BG2_A129VouNum[0];
               A130VouDSec = P00BG2_A130VouDSec[0];
               A860CueDsc = P00BG2_A860CueDsc[0];
               A70TipACod = P00BG2_A70TipACod[0];
               n70TipACod = P00BG2_n70TipACod[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BG2_A91CueCod[0], A91CueCod) == 0 ) )
               {
                  BRKBG3 = false;
                  A133CueCodAux = P00BG2_A133CueCodAux[0];
                  A127VouAno = P00BG2_A127VouAno[0];
                  A128VouMes = P00BG2_A128VouMes[0];
                  A126TASICod = P00BG2_A126TASICod[0];
                  A129VouNum = P00BG2_A129VouNum[0];
                  A130VouDSec = P00BG2_A130VouDSec[0];
                  BRKBG3 = true;
                  pr_default.readNext(0);
               }
               AV25CueCod = StringUtil.Trim( A91CueCod);
               AV91Cuenta = StringUtil.Trim( A91CueCod);
               AV41CueDsc = A860CueDsc;
               AV76TipACod = A70TipACod;
               AV50SaldoDMN = 0.00m;
               AV51SaldoHMN = 0.00m;
               AV52SaldoDME = 0.00m;
               AV53SaldoHME = 0.00m;
               AV47TDebeMO = 0.00m;
               AV48ThaberMO = 0.00m;
               AV39TDebeME = 0.00m;
               AV40THaberME = 0.00m;
               new GeneXus.Programs.contabilidad.pobtienesaldoscuenta(context ).execute( ref  AV25CueCod, ref  AV11Ano, ref  AV12Mes, out  AV50SaldoDMN, out  AV51SaldoHMN, out  AV52SaldoDME, out  AV53SaldoHME) ;
               AV69SaldoMN = (decimal)(AV50SaldoDMN-AV51SaldoHMN);
               AV70SaldoME = (decimal)(AV52SaldoDME-AV53SaldoHME);
               AV50SaldoDMN = ((AV69SaldoMN>Convert.ToDecimal(0)) ? AV69SaldoMN : (decimal)(0));
               AV51SaldoHMN = ((AV69SaldoMN<Convert.ToDecimal(0)) ? AV69SaldoMN*-1 : (decimal)(0));
               AV52SaldoDME = ((AV70SaldoME>Convert.ToDecimal(0)) ? AV70SaldoME : (decimal)(0));
               AV53SaldoHME = ((AV70SaldoME<Convert.ToDecimal(0)) ? AV70SaldoME*-1 : (decimal)(0));
               AV49Flag = 0;
               if ( ! (Convert.ToDecimal(0)==AV50SaldoDMN) || ! (Convert.ToDecimal(0)==AV51SaldoHMN) || ! (Convert.ToDecimal(0)==AV52SaldoDME) || ! (Convert.ToDecimal(0)==AV53SaldoHME) )
               {
                  AV49Flag = 1;
               }
               /* Execute user subroutine: 'VALIDAMOV' */
               S151 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ( AV49Flag == 1 ) && ( StringUtil.StrCmp(AV92TipoN, "D") == 0 ) )
               {
                  HBG0( false, 20) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 7, Gx_line+3, 71, Gx_line+14, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41CueDsc, "")), 71, Gx_line+3, 489, Gx_line+14, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50SaldoDMN, "ZZZZZZ,ZZZ,ZZ9.99")), 611, Gx_line+5, 683, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51SaldoHMN, "ZZZZZZ,ZZZ,ZZ9.99")), 685, Gx_line+6, 757, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Saldo Anterior Cuenta ", 514, Gx_line+4, 606, Gx_line+14, 0+256, 0, 0, 0) ;
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
               if ( ! BRKBG3 )
               {
                  BRKBG3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HBG0( false, 35) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 536, Gx_line+8, 592, Gx_line+18, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV78TDebePagMo, "ZZZZZZ,ZZZ,ZZ9.99")), 611, Gx_line+8, 683, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV79THaberPagMo, "ZZZZZZ,ZZZ,ZZ9.99")), 685, Gx_line+8, 757, Gx_line+19, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+35);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HBG0( true, 0) ;
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
         AV58CueDAxu = "";
         AV61TotalSDMN = 0.00m;
         AV62TotalSHMN = 0.00m;
         AV63TotalSDME = 0.00m;
         AV64TotalSHME = 0.00m;
         AV22TDebe = AV50SaldoDMN;
         AV23THaber = AV51SaldoHMN;
         AV45TDebeE = AV52SaldoDME;
         AV46THaberE = AV53SaldoHME;
         /* Execute user subroutine: 'MOVIMIENTOS' */
         S121 ();
         if (returnInSub) return;
         AV22TDebe = (decimal)(AV22TDebe+AV61TotalSDMN);
         AV23THaber = (decimal)(AV23THaber+AV62TotalSHMN);
         AV45TDebeE = (decimal)(AV45TDebeE+AV63TotalSDME);
         AV46THaberE = (decimal)(AV46THaberE+AV64TotalSHME);
         AV47TDebeMO = AV22TDebe;
         AV48ThaberMO = AV23THaber;
         AV39TDebeME = AV45TDebeE;
         AV40THaberME = AV46THaberE;
         AV78TDebePagMo = (decimal)(AV78TDebePagMo+AV47TDebeMO);
         AV79THaberPagMo = (decimal)(AV79THaberPagMo+AV48ThaberMO);
         AV80TDebePagMe = (decimal)(AV80TDebePagMe+AV39TDebeME);
         AV81THaberPagMe = (decimal)(AV81THaberPagMe+AV40THaberME);
         if ( AV49Flag == 1 )
         {
            AV66DifMN = (decimal)(AV47TDebeMO-AV48ThaberMO);
            AV67DifME = (decimal)(AV39TDebeME-AV40THaberME);
            AV84Totales = StringUtil.Trim( AV25CueCod) + " " + StringUtil.Trim( AV41CueDsc);
            HBG0( false, 33) ;
            getPrinter().GxDrawLine(631, Gx_line+5, 784, Gx_line+5, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TDebeMO, "ZZZZZZ,ZZZ,ZZ9.99")), 611, Gx_line+10, 683, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48ThaberMO, "ZZZZZZ,ZZZ,ZZ9.99")), 685, Gx_line+10, 757, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66DifMN, "ZZZZZZ,ZZZ,ZZ9.99")), 761, Gx_line+10, 833, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84Totales, "")), 339, Gx_line+10, 605, Gx_line+20, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV87Totales1, "")), 341, Gx_line+10, 607, Gx_line+20, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+33);
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
                                              AV91Cuenta ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BG3 */
         pr_default.execute(1, new Object[] {AV91Cuenta, AV11Ano, AV12Mes, AV33cCosto});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A126TASICod = P00BG3_A126TASICod[0];
            A2077VouSts = P00BG3_A2077VouSts[0];
            A79COSCod = P00BG3_A79COSCod[0];
            n79COSCod = P00BG3_n79COSCod[0];
            A91CueCod = P00BG3_A91CueCod[0];
            A128VouMes = P00BG3_A128VouMes[0];
            A127VouAno = P00BG3_A127VouAno[0];
            A129VouNum = P00BG3_A129VouNum[0];
            A1894TASIAbr = P00BG3_A1894TASIAbr[0];
            A2075VouGls = P00BG3_A2075VouGls[0];
            A133CueCodAux = P00BG3_A133CueCodAux[0];
            A2054VouDGls = P00BG3_A2054VouDGls[0];
            A131VouDMon = P00BG3_A131VouDMon[0];
            A2052VouDDebO = P00BG3_A2052VouDDebO[0];
            A2056VouDHabO = P00BG3_A2056VouDHabO[0];
            A136VouReg = P00BG3_A136VouReg[0];
            A2069VouDTcmb = P00BG3_A2069VouDTcmb[0];
            A2053VouDDoc = P00BG3_A2053VouDDoc[0];
            A2055VouDHab = P00BG3_A2055VouDHab[0];
            A2051VouDDeb = P00BG3_A2051VouDDeb[0];
            A135VouDFec = P00BG3_A135VouDFec[0];
            A130VouDSec = P00BG3_A130VouDSec[0];
            A1894TASIAbr = P00BG3_A1894TASIAbr[0];
            A2077VouSts = P00BG3_A2077VouSts[0];
            A2075VouGls = P00BG3_A2075VouGls[0];
            AV82Comprobante = StringUtil.Trim( A1894TASIAbr) + "-" + StringUtil.Substring( StringUtil.Trim( A129VouNum), 7, 4);
            AV37DebeME = 0.00m;
            AV38HaberME = 0.00m;
            AV68Glosa = StringUtil.Trim( A2075VouGls);
            AV77CueCodAux = A133CueCodAux;
            AV88Auxiliar = "";
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A133CueCodAux)) )
            {
               /* Execute user subroutine: 'VALIDAAUXILIAR' */
               S135 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
            }
            /* Execute user subroutine: 'VALIDATIPODOC' */
            S145 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV68Glosa = StringUtil.Trim( A2054VouDGls);
            }
            if ( ! ( A131VouDMon == 1 ) )
            {
               AV37DebeME = A2052VouDDebO;
               AV38HaberME = A2056VouDHabO;
            }
            if ( StringUtil.StrCmp(AV92TipoN, "D") == 0 )
            {
               HBG0( false, 18) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2051VouDDeb, "ZZZ,ZZZ,ZZ9.99")), 611, Gx_line+3, 675, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2055VouDHab, "ZZZ,ZZZ,ZZ9.99")), 685, Gx_line+3, 749, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A135VouDFec, "99/99/99"), 59, Gx_line+3, 91, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82Comprobante, "")), 5, Gx_line+3, 48, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83Costos, "")), 93, Gx_line+3, 152, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A133CueCodAux, "")), 156, Gx_line+2, 235, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2053VouDDoc, "")), 482, Gx_line+1, 564, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2069VouDTcmb, "ZZZZZZZZ9.99999")), 558, Gx_line+3, 622, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136VouReg, "")), 398, Gx_line+2, 459, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Glosa, "")), 763, Gx_line+3, 919, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88Auxiliar, "")), 236, Gx_line+2, 391, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV90TD, "")), 461, Gx_line+2, 480, Gx_line+13, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
            }
            AV61TotalSDMN = (decimal)(AV61TotalSDMN+A2051VouDDeb);
            AV62TotalSHMN = (decimal)(AV62TotalSHMN+A2055VouDHab);
            AV63TotalSDME = (decimal)(AV63TotalSDME+AV37DebeME);
            AV64TotalSHME = (decimal)(AV64TotalSHME+AV38HaberME);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S151( )
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
         /* Using cursor P00BG4 */
         pr_default.execute(2, new Object[] {AV11Ano, AV12Mes, AV25CueCod, AV33cCosto});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00BG4_A126TASICod[0];
            A129VouNum = P00BG4_A129VouNum[0];
            A79COSCod = P00BG4_A79COSCod[0];
            n79COSCod = P00BG4_n79COSCod[0];
            A2077VouSts = P00BG4_A2077VouSts[0];
            A91CueCod = P00BG4_A91CueCod[0];
            A128VouMes = P00BG4_A128VouMes[0];
            A127VouAno = P00BG4_A127VouAno[0];
            A2069VouDTcmb = P00BG4_A2069VouDTcmb[0];
            A130VouDSec = P00BG4_A130VouDSec[0];
            A2077VouSts = P00BG4_A2077VouSts[0];
            AV49Flag = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S135( )
      {
         /* 'VALIDAAUXILIAR' Routine */
         returnInSub = false;
         /* Using cursor P00BG5 */
         pr_default.execute(3, new Object[] {AV77CueCodAux});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A71TipADCod = P00BG5_A71TipADCod[0];
            A72TipADDsc = P00BG5_A72TipADDsc[0];
            A70TipACod = P00BG5_A70TipACod[0];
            n70TipACod = P00BG5_n70TipACod[0];
            AV88Auxiliar = StringUtil.Trim( A72TipADDsc);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S145( )
      {
         /* 'VALIDATIPODOC' Routine */
         returnInSub = false;
         AV90TD = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89VouDTipCod)) )
         {
            /* Using cursor P00BG6 */
            pr_default.execute(4, new Object[] {AV89VouDTipCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A149TipCod = P00BG6_A149TipCod[0];
               A306TipAbr = P00BG6_A306TipAbr[0];
               AV90TD = StringUtil.Trim( A306TipAbr);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
         }
      }

      protected void HBG0( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 296, Gx_line+25, 752, Gx_line+47, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 296, Gx_line+47, 752, Gx_line+69, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 9, Gx_line+75, 377, Gx_line+93, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73EmpRUC, "")), 9, Gx_line+93, 380, Gx_line+111, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV74Logo)) ? AV95Logo_GXI : AV74Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 8, Gx_line+8, 140, Gx_line+74) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 973, Gx_line+49, 1013, Gx_line+62, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1027, Gx_line+49, 1059, Gx_line+62, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1021, Gx_line+13, 1060, Gx_line+26, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha:", 973, Gx_line+14, 1007, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hora:", 973, Gx_line+31, 1003, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 992, Gx_line+30, 1060, Gx_line+43, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuario:", 973, Gx_line+67, 1017, Gx_line+80, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85UsuCod, "")), 1017, Gx_line+67, 1060, Gx_line+80, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+111);
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 52, Gx_line+17, 78, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Debe", 657, Gx_line+18, 680, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber", 723, Gx_line+18, 749, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Comprob.", 4, Gx_line+17, 46, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 1096, Gx_line+33, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Cuenta", 11, Gx_line+3, 41, Gx_line+13, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 594, Gx_line+4, 613, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Centro de Costos", 89, Gx_line+17, 159, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Auxiliar", 165, Gx_line+17, 196, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Registro", 403, Gx_line+17, 451, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T/D", 463, Gx_line+17, 481, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Nro.Doc.", 495, Gx_line+17, 532, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cambio", 588, Gx_line+17, 620, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Glosa", 804, Gx_line+18, 828, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Articulo", 938, Gx_line+18, 969, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 1000, Gx_line+18, 1037, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Descripción Auxiliar", 247, Gx_line+17, 327, Gx_line+27, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+33);
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
         AV73EmpRUC = "";
         AV75Ruta = "";
         AV74Logo = "";
         AV95Logo_GXI = "";
         AV85UsuCod = "";
         AV87Totales1 = "";
         AV86Tipo = "";
         AV72FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV71cMes = "";
         GXt_char1 = "";
         AV13Titulo = "";
         AV14Periodo = "";
         scmdbuf = "";
         A91CueCod = "";
         A133CueCodAux = "";
         P00BG2_A133CueCodAux = new string[] {""} ;
         P00BG2_A91CueCod = new string[] {""} ;
         P00BG2_A127VouAno = new short[1] ;
         P00BG2_A860CueDsc = new string[] {""} ;
         P00BG2_A70TipACod = new int[1] ;
         P00BG2_n70TipACod = new bool[] {false} ;
         P00BG2_A128VouMes = new short[1] ;
         P00BG2_A126TASICod = new int[1] ;
         P00BG2_A129VouNum = new string[] {""} ;
         P00BG2_A130VouDSec = new int[1] ;
         A860CueDsc = "";
         A129VouNum = "";
         AV25CueCod = "";
         AV91Cuenta = "";
         AV41CueDsc = "";
         AV58CueDAxu = "";
         AV84Totales = "";
         A79COSCod = "";
         P00BG3_A126TASICod = new int[1] ;
         P00BG3_A2077VouSts = new short[1] ;
         P00BG3_A79COSCod = new string[] {""} ;
         P00BG3_n79COSCod = new bool[] {false} ;
         P00BG3_A91CueCod = new string[] {""} ;
         P00BG3_A128VouMes = new short[1] ;
         P00BG3_A127VouAno = new short[1] ;
         P00BG3_A129VouNum = new string[] {""} ;
         P00BG3_A1894TASIAbr = new string[] {""} ;
         P00BG3_A2075VouGls = new string[] {""} ;
         P00BG3_A133CueCodAux = new string[] {""} ;
         P00BG3_A2054VouDGls = new string[] {""} ;
         P00BG3_A131VouDMon = new int[1] ;
         P00BG3_A2052VouDDebO = new decimal[1] ;
         P00BG3_A2056VouDHabO = new decimal[1] ;
         P00BG3_A136VouReg = new string[] {""} ;
         P00BG3_A2069VouDTcmb = new decimal[1] ;
         P00BG3_A2053VouDDoc = new string[] {""} ;
         P00BG3_A2055VouDHab = new decimal[1] ;
         P00BG3_A2051VouDDeb = new decimal[1] ;
         P00BG3_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BG3_A130VouDSec = new int[1] ;
         A1894TASIAbr = "";
         A2075VouGls = "";
         A2054VouDGls = "";
         A136VouReg = "";
         A2053VouDDoc = "";
         A135VouDFec = DateTime.MinValue;
         AV82Comprobante = "";
         AV68Glosa = "";
         AV88Auxiliar = "";
         AV83Costos = "";
         AV90TD = "";
         P00BG4_A126TASICod = new int[1] ;
         P00BG4_A129VouNum = new string[] {""} ;
         P00BG4_A79COSCod = new string[] {""} ;
         P00BG4_n79COSCod = new bool[] {false} ;
         P00BG4_A2077VouSts = new short[1] ;
         P00BG4_A91CueCod = new string[] {""} ;
         P00BG4_A128VouMes = new short[1] ;
         P00BG4_A127VouAno = new short[1] ;
         P00BG4_A2069VouDTcmb = new decimal[1] ;
         P00BG4_A130VouDSec = new int[1] ;
         P00BG5_A71TipADCod = new string[] {""} ;
         P00BG5_A72TipADDsc = new string[] {""} ;
         P00BG5_A70TipACod = new int[1] ;
         P00BG5_n70TipACod = new bool[] {false} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         AV89VouDTipCod = "";
         P00BG6_A149TipCod = new string[] {""} ;
         P00BG6_A306TipAbr = new string[] {""} ;
         A149TipCod = "";
         A306TipAbr = "";
         AV74Logo = "";
         sImgUrl = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_libromayomnresumenpdf__default(),
            new Object[][] {
                new Object[] {
               P00BG2_A133CueCodAux, P00BG2_A91CueCod, P00BG2_A127VouAno, P00BG2_A860CueDsc, P00BG2_A70TipACod, P00BG2_n70TipACod, P00BG2_A128VouMes, P00BG2_A126TASICod, P00BG2_A129VouNum, P00BG2_A130VouDSec
               }
               , new Object[] {
               P00BG3_A126TASICod, P00BG3_A2077VouSts, P00BG3_A79COSCod, P00BG3_n79COSCod, P00BG3_A91CueCod, P00BG3_A128VouMes, P00BG3_A127VouAno, P00BG3_A129VouNum, P00BG3_A1894TASIAbr, P00BG3_A2075VouGls,
               P00BG3_A133CueCodAux, P00BG3_A2054VouDGls, P00BG3_A131VouDMon, P00BG3_A2052VouDDebO, P00BG3_A2056VouDHabO, P00BG3_A136VouReg, P00BG3_A2069VouDTcmb, P00BG3_A2053VouDDoc, P00BG3_A2055VouDHab, P00BG3_A2051VouDDeb,
               P00BG3_A135VouDFec, P00BG3_A130VouDSec
               }
               , new Object[] {
               P00BG4_A126TASICod, P00BG4_A129VouNum, P00BG4_A79COSCod, P00BG4_n79COSCod, P00BG4_A2077VouSts, P00BG4_A91CueCod, P00BG4_A128VouMes, P00BG4_A127VouAno, P00BG4_A2069VouDTcmb, P00BG4_A130VouDSec
               }
               , new Object[] {
               P00BG5_A71TipADCod, P00BG5_A72TipADDsc, P00BG5_A70TipACod
               }
               , new Object[] {
               P00BG6_A149TipCod, P00BG6_A306TipAbr
               }
            }
         );
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV11Ano ;
      private short AV12Mes ;
      private short AV42cOpc ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short AV49Flag ;
      private short A2077VouSts ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A70TipACod ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int AV76TipACod ;
      private int Gx_OldLine ;
      private int A131VouDMon ;
      private decimal AV78TDebePagMo ;
      private decimal AV79THaberPagMo ;
      private decimal AV80TDebePagMe ;
      private decimal AV81THaberPagMe ;
      private decimal AV50SaldoDMN ;
      private decimal AV51SaldoHMN ;
      private decimal AV52SaldoDME ;
      private decimal AV53SaldoHME ;
      private decimal AV47TDebeMO ;
      private decimal AV48ThaberMO ;
      private decimal AV39TDebeME ;
      private decimal AV40THaberME ;
      private decimal AV69SaldoMN ;
      private decimal AV70SaldoME ;
      private decimal AV61TotalSDMN ;
      private decimal AV62TotalSHMN ;
      private decimal AV63TotalSDME ;
      private decimal AV64TotalSHME ;
      private decimal AV22TDebe ;
      private decimal AV23THaber ;
      private decimal AV45TDebeE ;
      private decimal AV46THaberE ;
      private decimal AV66DifMN ;
      private decimal AV67DifME ;
      private decimal A2052VouDDebO ;
      private decimal A2056VouDHabO ;
      private decimal A2069VouDTcmb ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private decimal AV37DebeME ;
      private decimal AV38HaberME ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV33cCosto ;
      private string AV34cCuenta1 ;
      private string AV35cCuenta2 ;
      private string AV77CueCodAux ;
      private string AV92TipoN ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV73EmpRUC ;
      private string AV75Ruta ;
      private string AV85UsuCod ;
      private string AV87Totales1 ;
      private string AV86Tipo ;
      private string AV72FechaC ;
      private string AV71cMes ;
      private string GXt_char1 ;
      private string AV13Titulo ;
      private string AV14Periodo ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A133CueCodAux ;
      private string A860CueDsc ;
      private string A129VouNum ;
      private string AV25CueCod ;
      private string AV91Cuenta ;
      private string AV41CueDsc ;
      private string AV58CueDAxu ;
      private string AV84Totales ;
      private string A79COSCod ;
      private string A1894TASIAbr ;
      private string A2075VouGls ;
      private string A2054VouDGls ;
      private string A136VouReg ;
      private string A2053VouDDoc ;
      private string AV82Comprobante ;
      private string AV68Glosa ;
      private string AV83Costos ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string AV89VouDTipCod ;
      private string A149TipCod ;
      private string A306TipAbr ;
      private string sImgUrl ;
      private string Gx_time ;
      private DateTime AV16FechaD ;
      private DateTime A135VouDFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKBG3 ;
      private bool n70TipACod ;
      private bool returnInSub ;
      private bool n79COSCod ;
      private string AV95Logo_GXI ;
      private string AV88Auxiliar ;
      private string AV90TD ;
      private string AV74Logo ;
      private string Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_cCosto ;
      private string aP3_cCuenta1 ;
      private string aP4_cCuenta2 ;
      private short aP5_cOpc ;
      private string aP6_CueCodAux ;
      private string aP7_TipoN ;
      private IDataStoreProvider pr_default ;
      private string[] P00BG2_A133CueCodAux ;
      private string[] P00BG2_A91CueCod ;
      private short[] P00BG2_A127VouAno ;
      private string[] P00BG2_A860CueDsc ;
      private int[] P00BG2_A70TipACod ;
      private bool[] P00BG2_n70TipACod ;
      private short[] P00BG2_A128VouMes ;
      private int[] P00BG2_A126TASICod ;
      private string[] P00BG2_A129VouNum ;
      private int[] P00BG2_A130VouDSec ;
      private int[] P00BG3_A126TASICod ;
      private short[] P00BG3_A2077VouSts ;
      private string[] P00BG3_A79COSCod ;
      private bool[] P00BG3_n79COSCod ;
      private string[] P00BG3_A91CueCod ;
      private short[] P00BG3_A128VouMes ;
      private short[] P00BG3_A127VouAno ;
      private string[] P00BG3_A129VouNum ;
      private string[] P00BG3_A1894TASIAbr ;
      private string[] P00BG3_A2075VouGls ;
      private string[] P00BG3_A133CueCodAux ;
      private string[] P00BG3_A2054VouDGls ;
      private int[] P00BG3_A131VouDMon ;
      private decimal[] P00BG3_A2052VouDDebO ;
      private decimal[] P00BG3_A2056VouDHabO ;
      private string[] P00BG3_A136VouReg ;
      private decimal[] P00BG3_A2069VouDTcmb ;
      private string[] P00BG3_A2053VouDDoc ;
      private decimal[] P00BG3_A2055VouDHab ;
      private decimal[] P00BG3_A2051VouDDeb ;
      private DateTime[] P00BG3_A135VouDFec ;
      private int[] P00BG3_A130VouDSec ;
      private int[] P00BG4_A126TASICod ;
      private string[] P00BG4_A129VouNum ;
      private string[] P00BG4_A79COSCod ;
      private bool[] P00BG4_n79COSCod ;
      private short[] P00BG4_A2077VouSts ;
      private string[] P00BG4_A91CueCod ;
      private short[] P00BG4_A128VouMes ;
      private short[] P00BG4_A127VouAno ;
      private decimal[] P00BG4_A2069VouDTcmb ;
      private int[] P00BG4_A130VouDSec ;
      private string[] P00BG5_A71TipADCod ;
      private string[] P00BG5_A72TipADDsc ;
      private int[] P00BG5_A70TipACod ;
      private bool[] P00BG5_n70TipACod ;
      private string[] P00BG6_A149TipCod ;
      private string[] P00BG6_A306TipAbr ;
   }

   public class r_libromayomnresumenpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BG2( IGxContext context ,
                                             string AV34cCuenta1 ,
                                             string AV35cCuenta2 ,
                                             string AV77CueCodAux ,
                                             string A91CueCod ,
                                             string A133CueCodAux ,
                                             short A127VouAno ,
                                             short AV11Ano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouAno], T2.[CueDsc], T2.[TipACod], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34cCuenta1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] >= @AV34cCuenta1)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35cCuenta2)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] <= @AV35cCuenta2)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77CueCodAux)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV77CueCodAux)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00BG3( IGxContext context ,
                                             string AV33cCosto ,
                                             string A79COSCod ,
                                             short A127VouAno ,
                                             short AV11Ano ,
                                             short A128VouMes ,
                                             short AV12Mes ,
                                             short A2077VouSts ,
                                             string AV91Cuenta ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T3.[VouSts], T1.[COSCod], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouNum], T2.[TASIAbr], T3.[VouGls], T1.[CueCodAux], T1.[VouDGls], T1.[VouDMon], T1.[VouDDebO], T1.[VouDHabO], T1.[VouReg], T1.[VouDTcmb], T1.[VouDDoc], T1.[VouDHab], T1.[VouDDeb], T1.[VouDFec], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV91Cuenta)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano)");
         AddWhere(sWhereString, "(T1.[VouMes] = @AV12Mes)");
         AddWhere(sWhereString, "(T3.[VouSts] = 1)");
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

      protected Object[] conditional_P00BG4( IGxContext context ,
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
         short[] GXv_int6 = new short[4];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T1.[COSCod], T2.[VouSts], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV25CueCod)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV33cCosto)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BG2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
               case 1 :
                     return conditional_P00BG3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] );
               case 2 :
                     return conditional_P00BG4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BG5;
          prmP00BG5 = new Object[] {
          new ParDef("@AV77CueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00BG6;
          prmP00BG6 = new Object[] {
          new ParDef("@AV89VouDTipCod",GXType.NChar,3,0)
          };
          Object[] prmP00BG2;
          prmP00BG2 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV34cCuenta1",GXType.Char,15,0) ,
          new ParDef("@AV35cCuenta2",GXType.Char,15,0) ,
          new ParDef("@AV77CueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00BG3;
          prmP00BG3 = new Object[] {
          new ParDef("@AV91Cuenta",GXType.NChar,15,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00BG4;
          prmP00BG4 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BG2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BG3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BG4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BG5", "SELECT [TipADCod], [TipADDsc], [TipACod] FROM [CBAUXILIARES] WHERE [TipADCod] = @AV77CueCodAux ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BG6", "SELECT [TipCod], [TipAbr] FROM [CTIPDOC] WHERE [TipCod] = @AV89VouDTipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG6,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 10);
                ((string[]) buf[8])[0] = rslt.getString(8, 5);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((string[]) buf[10])[0] = rslt.getString(10, 20);
                ((string[]) buf[11])[0] = rslt.getString(11, 100);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 15);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((string[]) buf[17])[0] = rslt.getString(17, 20);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(20);
                ((int[]) buf[21])[0] = rslt.getInt(21);
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
       }
    }

 }

}
