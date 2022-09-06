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
   public class r_libromayorgeneralpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_libromayorgeneralpdf.aspx")), "contabilidad.r_libromayorgeneralpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_libromayorgeneralpdf.aspx")))) ;
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
                  AV35cCuenta2 = GetPar( "cCuenta2");
                  AV42cOpc = (short)(NumberUtil.Val( GetPar( "cOpc"), "."));
                  AV77CueCodAux = GetPar( "CueCodAux");
                  AV33cCosto = GetPar( "cCosto");
                  AV87cCosto2 = GetPar( "cCosto2");
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

      public r_libromayorgeneralpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_libromayorgeneralpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref string aP2_cCuenta1 ,
                           ref string aP3_cCuenta2 ,
                           ref short aP4_cOpc ,
                           ref string aP5_CueCodAux ,
                           ref string aP6_cCosto ,
                           ref string aP7_cCosto2 )
      {
         this.AV11Ano = aP0_Ano;
         this.AV12Mes = aP1_Mes;
         this.AV34cCuenta1 = aP2_cCuenta1;
         this.AV35cCuenta2 = aP3_cCuenta2;
         this.AV42cOpc = aP4_cOpc;
         this.AV77CueCodAux = aP5_CueCodAux;
         this.AV33cCosto = aP6_cCosto;
         this.AV87cCosto2 = aP7_cCosto2;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_cCuenta1=this.AV34cCuenta1;
         aP3_cCuenta2=this.AV35cCuenta2;
         aP4_cOpc=this.AV42cOpc;
         aP5_CueCodAux=this.AV77CueCodAux;
         aP6_cCosto=this.AV33cCosto;
         aP7_cCosto2=this.AV87cCosto2;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref string aP2_cCuenta1 ,
                                ref string aP3_cCuenta2 ,
                                ref short aP4_cOpc ,
                                ref string aP5_CueCodAux ,
                                ref string aP6_cCosto )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_cCuenta1, ref aP3_cCuenta2, ref aP4_cOpc, ref aP5_CueCodAux, ref aP6_cCosto, ref aP7_cCosto2);
         return AV87cCosto2 ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_cCuenta1 ,
                                 ref string aP3_cCuenta2 ,
                                 ref short aP4_cOpc ,
                                 ref string aP5_CueCodAux ,
                                 ref string aP6_cCosto ,
                                 ref string aP7_cCosto2 )
      {
         r_libromayorgeneralpdf objr_libromayorgeneralpdf;
         objr_libromayorgeneralpdf = new r_libromayorgeneralpdf();
         objr_libromayorgeneralpdf.AV11Ano = aP0_Ano;
         objr_libromayorgeneralpdf.AV12Mes = aP1_Mes;
         objr_libromayorgeneralpdf.AV34cCuenta1 = aP2_cCuenta1;
         objr_libromayorgeneralpdf.AV35cCuenta2 = aP3_cCuenta2;
         objr_libromayorgeneralpdf.AV42cOpc = aP4_cOpc;
         objr_libromayorgeneralpdf.AV77CueCodAux = aP5_CueCodAux;
         objr_libromayorgeneralpdf.AV33cCosto = aP6_cCosto;
         objr_libromayorgeneralpdf.AV87cCosto2 = aP7_cCosto2;
         objr_libromayorgeneralpdf.context.SetSubmitInitialConfig(context);
         objr_libromayorgeneralpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_libromayorgeneralpdf);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_cCuenta1=this.AV34cCuenta1;
         aP3_cCuenta2=this.AV35cCuenta2;
         aP4_cOpc=this.AV42cOpc;
         aP5_CueCodAux=this.AV77CueCodAux;
         aP6_cCosto=this.AV33cCosto;
         aP7_cCosto2=this.AV87cCosto2;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_libromayorgeneralpdf)stateInfo).executePrivate();
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
            AV90Logo_GXI = GXDbFile.PathToUrl( AV75Ruta);
            AV72FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV72FechaC, 2);
            GXt_char1 = AV71cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV71cMes = GXt_char1;
            AV13Titulo = "Libro Mayor General";
            AV14Periodo = "Año : " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0)) + " Mes : " + AV71cMes;
            AV78TDebePagMo = 0.00m;
            AV79THaberPagMo = 0.00m;
            AV80TDebePagMe = 0.00m;
            AV81THaberPagMe = 0.00m;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV34cCuenta1 ,
                                                 AV35cCuenta2 ,
                                                 AV77CueCodAux ,
                                                 AV33cCosto ,
                                                 AV87cCosto2 ,
                                                 A91CueCod ,
                                                 A133CueCodAux ,
                                                 A79COSCod ,
                                                 A127VouAno ,
                                                 AV11Ano } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00BB2 */
            pr_default.execute(0, new Object[] {AV11Ano, AV34cCuenta1, AV35cCuenta2, AV77CueCodAux, AV33cCosto, AV87cCosto2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKBB3 = false;
               A133CueCodAux = P00BB2_A133CueCodAux[0];
               A91CueCod = P00BB2_A91CueCod[0];
               A79COSCod = P00BB2_A79COSCod[0];
               n79COSCod = P00BB2_n79COSCod[0];
               A127VouAno = P00BB2_A127VouAno[0];
               A860CueDsc = P00BB2_A860CueDsc[0];
               A70TipACod = P00BB2_A70TipACod[0];
               n70TipACod = P00BB2_n70TipACod[0];
               A859CueCos = P00BB2_A859CueCos[0];
               A128VouMes = P00BB2_A128VouMes[0];
               A126TASICod = P00BB2_A126TASICod[0];
               A129VouNum = P00BB2_A129VouNum[0];
               A130VouDSec = P00BB2_A130VouDSec[0];
               A860CueDsc = P00BB2_A860CueDsc[0];
               A70TipACod = P00BB2_A70TipACod[0];
               n70TipACod = P00BB2_n70TipACod[0];
               A859CueCos = P00BB2_A859CueCos[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BB2_A91CueCod[0], A91CueCod) == 0 ) )
               {
                  BRKBB3 = false;
                  A133CueCodAux = P00BB2_A133CueCodAux[0];
                  A127VouAno = P00BB2_A127VouAno[0];
                  A128VouMes = P00BB2_A128VouMes[0];
                  A126TASICod = P00BB2_A126TASICod[0];
                  A129VouNum = P00BB2_A129VouNum[0];
                  A130VouDSec = P00BB2_A130VouDSec[0];
                  BRKBB3 = true;
                  pr_default.readNext(0);
               }
               AV25CueCod = A91CueCod;
               AV41CueDsc = A860CueDsc;
               AV76TipACod = A70TipACod;
               AV84CueCos = A859CueCos;
               AV21CosCod = "";
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
               S211 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( AV49Flag == 1 )
               {
                  HBB0( false, 20) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 4, Gx_line+3, 83, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41CueDsc, "")), 96, Gx_line+3, 397, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50SaldoDMN, "ZZZZZZ,ZZZ,ZZ9.99")), 677, Gx_line+3, 784, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51SaldoHMN, "ZZZZZZ,ZZZ,ZZ9.99")), 781, Gx_line+3, 888, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52SaldoDME, "ZZZZZZ,ZZZ,ZZ9.99")), 866, Gx_line+3, 973, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53SaldoHME, "ZZZZZZ,ZZZ,ZZ9.99")), 965, Gx_line+3, 1072, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Saldo Anterior Cuenta ", 458, Gx_line+4, 591, Gx_line+18, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
               if ( AV76TipACod > 0 )
               {
                  /* Execute user subroutine: 'AUXILIARES' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
               }
               else
               {
                  if ( AV84CueCos == 1 )
                  {
                     /* Execute user subroutine: 'PORCENTROCOSTO' */
                     S171 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        this.cleanup();
                        if (true) return;
                     }
                  }
                  else
                  {
                     /* Execute user subroutine: 'PORCUENTA' */
                     S151 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        this.cleanup();
                        if (true) return;
                     }
                  }
               }
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
                  HBB0( false, 55) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Cuenta :", 508, Gx_line+8, 590, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(670, Gx_line+5, 1077, Gx_line+5, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TDebeMO, "ZZZZZZ,ZZZ,ZZ9.99")), 677, Gx_line+8, 784, Gx_line+23, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48ThaberMO, "ZZZZZZ,ZZZ,ZZ9.99")), 781, Gx_line+8, 888, Gx_line+23, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39TDebeME, "ZZZZZZ,ZZZ,ZZ9.99")), 866, Gx_line+8, 973, Gx_line+23, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40THaberME, "ZZZZZZ,ZZZ,ZZ9.99")), 965, Gx_line+8, 1072, Gx_line+23, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 605, Gx_line+8, 684, Gx_line+23, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Saldo Cuenta :", 508, Gx_line+29, 592, Gx_line+43, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66DifMN, "ZZZZZZ,ZZZ,ZZ9.99")), 677, Gx_line+29, 784, Gx_line+44, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67DifME, "ZZZZZZ,ZZZ,ZZ9.99")), 866, Gx_line+29, 973, Gx_line+44, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+55);
               }
               if ( ! BRKBB3 )
               {
                  BRKBB3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HBB0( true, 0) ;
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
         AV22TDebe = 0.00m;
         AV23THaber = 0.00m;
         AV45TDebeE = 0.00m;
         AV46THaberE = 0.00m;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV77CueCodAux ,
                                              AV33cCosto ,
                                              AV87cCosto2 ,
                                              A133CueCodAux ,
                                              A79COSCod ,
                                              A127VouAno ,
                                              AV11Ano ,
                                              A91CueCod ,
                                              AV25CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BB3 */
         pr_default.execute(1, new Object[] {AV11Ano, AV25CueCod, AV77CueCodAux, AV33cCosto, AV87cCosto2});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKBB5 = false;
            A91CueCod = P00BB3_A91CueCod[0];
            A133CueCodAux = P00BB3_A133CueCodAux[0];
            A79COSCod = P00BB3_A79COSCod[0];
            n79COSCod = P00BB3_n79COSCod[0];
            A127VouAno = P00BB3_A127VouAno[0];
            A128VouMes = P00BB3_A128VouMes[0];
            A126TASICod = P00BB3_A126TASICod[0];
            A129VouNum = P00BB3_A129VouNum[0];
            A130VouDSec = P00BB3_A130VouDSec[0];
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00BB3_A133CueCodAux[0], A133CueCodAux) == 0 ) )
            {
               BRKBB5 = false;
               A91CueCod = P00BB3_A91CueCod[0];
               A127VouAno = P00BB3_A127VouAno[0];
               A128VouMes = P00BB3_A128VouMes[0];
               A126TASICod = P00BB3_A126TASICod[0];
               A129VouNum = P00BB3_A129VouNum[0];
               A130VouDSec = P00BB3_A130VouDSec[0];
               BRKBB5 = true;
               pr_default.readNext(1);
            }
            AV58CueDAxu = A133CueCodAux;
            /* Execute user subroutine: 'NOMBREAUXILIAR' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV54SaldoDAMN = 0.00m;
            AV55SaldoHAMN = 0.00m;
            AV56SaldoDAME = 0.00m;
            AV57SaldoHAME = 0.00m;
            AV61TotalSDMN = 0.00m;
            AV62TotalSHMN = 0.00m;
            AV63TotalSDME = 0.00m;
            AV64TotalSHME = 0.00m;
            AV59Flag1 = 0;
            new GeneXus.Programs.contabilidad.pobtienesaldoscuentaauxiliar(context ).execute( ref  AV25CueCod, ref  AV58CueDAxu, ref  AV11Ano, ref  AV12Mes, out  AV54SaldoDAMN, out  AV55SaldoHAMN, out  AV56SaldoDAME, out  AV57SaldoHAME) ;
            AV69SaldoMN = (decimal)(AV54SaldoDAMN-AV55SaldoHAMN);
            AV70SaldoME = (decimal)(AV56SaldoDAME-AV57SaldoHAME);
            AV54SaldoDAMN = ((AV69SaldoMN>Convert.ToDecimal(0)) ? AV69SaldoMN : (decimal)(0));
            AV55SaldoHAMN = ((AV69SaldoMN<Convert.ToDecimal(0)) ? AV69SaldoMN*-1 : (decimal)(0));
            AV56SaldoDAME = ((AV70SaldoME>Convert.ToDecimal(0)) ? AV70SaldoME : (decimal)(0));
            AV57SaldoHAME = ((AV70SaldoME<Convert.ToDecimal(0)) ? AV70SaldoME*-1 : (decimal)(0));
            if ( ! (Convert.ToDecimal(0)==AV54SaldoDAMN) || ! (Convert.ToDecimal(0)==AV55SaldoHAMN) || ! (Convert.ToDecimal(0)==AV56SaldoDAME) || ! (Convert.ToDecimal(0)==AV57SaldoHAME) )
            {
               AV59Flag1 = 1;
            }
            AV61TotalSDMN = AV54SaldoDAMN;
            AV62TotalSHMN = AV55SaldoHAMN;
            AV63TotalSDME = AV56SaldoDAME;
            AV64TotalSHME = AV57SaldoHAME;
            /* Execute user subroutine: 'VALIDAMOVAUXILIAR' */
            S135 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            if ( AV59Flag1 == 1 )
            {
               HBB0( false, 20) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58CueDAxu, "")), 5, Gx_line+1, 110, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60CueDAxuDsc, "")), 97, Gx_line+1, 398, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Saldo Anterior Auxiliar ", 455, Gx_line+2, 591, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54SaldoDAMN, "ZZZZZZ,ZZZ,ZZ9.99")), 677, Gx_line+1, 784, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55SaldoHAMN, "ZZZZZZ,ZZZ,ZZ9.99")), 781, Gx_line+1, 888, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56SaldoDAME, "ZZZZZZ,ZZZ,ZZ9.99")), 866, Gx_line+1, 973, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57SaldoHAME, "ZZZZZZ,ZZZ,ZZ9.99")), 965, Gx_line+1, 1072, Gx_line+16, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
            /* Execute user subroutine: 'MOVIMIENTOSAUXILIAR' */
            S145 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV22TDebe = (decimal)(AV22TDebe+AV61TotalSDMN);
            AV23THaber = (decimal)(AV23THaber+AV62TotalSHMN);
            AV45TDebeE = (decimal)(AV45TDebeE+AV63TotalSDME);
            AV46THaberE = (decimal)(AV46THaberE+AV64TotalSHME);
            if ( AV59Flag1 == 1 )
            {
               AV66DifMN = (decimal)(AV61TotalSDMN-AV62TotalSHMN);
               AV67DifME = (decimal)(AV63TotalSDME-AV64TotalSHME);
               HBB0( false, 42) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Auxiliar :", 502, Gx_line+3, 587, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61TotalSDMN, "ZZZZZZ,ZZZ,ZZ9.99")), 677, Gx_line+2, 784, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62TotalSHMN, "ZZZZZZ,ZZZ,ZZ9.99")), 781, Gx_line+2, 888, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63TotalSDME, "ZZZZZZ,ZZZ,ZZ9.99")), 866, Gx_line+2, 973, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TotalSHME, "ZZZZZZ,ZZZ,ZZ9.99")), 965, Gx_line+2, 1072, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58CueDAxu, "")), 605, Gx_line+3, 710, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Saldo Auxiliar :", 499, Gx_line+22, 586, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66DifMN, "ZZZZZZ,ZZZ,ZZ9.99")), 677, Gx_line+22, 784, Gx_line+37, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67DifME, "ZZZZZZ,ZZZ,ZZ9.99")), 866, Gx_line+22, 973, Gx_line+37, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(670, Gx_line+2, 1077, Gx_line+2, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+42);
            }
            if ( ! BRKBB5 )
            {
               BRKBB5 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S151( )
      {
         /* 'PORCUENTA' Routine */
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
         S161 ();
         if (returnInSub) return;
         AV22TDebe = (decimal)(AV22TDebe+AV61TotalSDMN);
         AV23THaber = (decimal)(AV23THaber+AV62TotalSHMN);
         AV45TDebeE = (decimal)(AV45TDebeE+AV63TotalSDME);
         AV46THaberE = (decimal)(AV46THaberE+AV64TotalSHME);
      }

      protected void S171( )
      {
         /* 'PORCENTROCOSTO' Routine */
         returnInSub = false;
         AV22TDebe = 0.00m;
         AV23THaber = 0.00m;
         AV45TDebeE = 0.00m;
         AV46THaberE = 0.00m;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV33cCosto ,
                                              AV87cCosto2 ,
                                              A79COSCod ,
                                              A127VouAno ,
                                              AV11Ano } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BB4 */
         pr_default.execute(2, new Object[] {AV11Ano, AV33cCosto, AV87cCosto2});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKBB7 = false;
            A129VouNum = P00BB4_A129VouNum[0];
            A79COSCod = P00BB4_A79COSCod[0];
            n79COSCod = P00BB4_n79COSCod[0];
            A127VouAno = P00BB4_A127VouAno[0];
            A761COSDsc = P00BB4_A761COSDsc[0];
            A128VouMes = P00BB4_A128VouMes[0];
            A126TASICod = P00BB4_A126TASICod[0];
            A130VouDSec = P00BB4_A130VouDSec[0];
            A761COSDsc = P00BB4_A761COSDsc[0];
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00BB4_A79COSCod[0], A79COSCod) == 0 ) )
            {
               BRKBB7 = false;
               A129VouNum = P00BB4_A129VouNum[0];
               A127VouAno = P00BB4_A127VouAno[0];
               A128VouMes = P00BB4_A128VouMes[0];
               A126TASICod = P00BB4_A126TASICod[0];
               A130VouDSec = P00BB4_A130VouDSec[0];
               BRKBB7 = true;
               pr_default.readNext(2);
            }
            AV58CueDAxu = "";
            AV21CosCod = A79COSCod;
            AV85CosDsc = "Centro de Costo : " + StringUtil.Trim( AV21CosCod) + " - " + StringUtil.Trim( A761COSDsc);
            AV54SaldoDAMN = 0.00m;
            AV55SaldoHAMN = 0.00m;
            AV56SaldoDAME = 0.00m;
            AV57SaldoHAME = 0.00m;
            AV61TotalSDMN = 0.00m;
            AV62TotalSHMN = 0.00m;
            AV63TotalSDME = 0.00m;
            AV64TotalSHME = 0.00m;
            AV59Flag1 = 0;
            new GeneXus.Programs.contabilidad.pobtienesaldoscuentacentrocosto(context ).execute( ref  AV25CueCod, ref  AV21CosCod, ref  AV11Ano, ref  AV12Mes, out  AV54SaldoDAMN, out  AV55SaldoHAMN, out  AV56SaldoDAME, out  AV57SaldoHAME) ;
            AV69SaldoMN = (decimal)(AV54SaldoDAMN-AV55SaldoHAMN);
            AV70SaldoME = (decimal)(AV56SaldoDAME-AV57SaldoHAME);
            AV54SaldoDAMN = ((AV69SaldoMN>Convert.ToDecimal(0)) ? AV69SaldoMN : (decimal)(0));
            AV55SaldoHAMN = ((AV69SaldoMN<Convert.ToDecimal(0)) ? AV69SaldoMN*-1 : (decimal)(0));
            AV56SaldoDAME = ((AV70SaldoME>Convert.ToDecimal(0)) ? AV70SaldoME : (decimal)(0));
            AV57SaldoHAME = ((AV70SaldoME<Convert.ToDecimal(0)) ? AV70SaldoME*-1 : (decimal)(0));
            if ( ! (Convert.ToDecimal(0)==AV54SaldoDAMN) || ! (Convert.ToDecimal(0)==AV55SaldoHAMN) || ! (Convert.ToDecimal(0)==AV56SaldoDAME) || ! (Convert.ToDecimal(0)==AV57SaldoHAME) )
            {
               AV59Flag1 = 1;
            }
            AV61TotalSDMN = AV54SaldoDAMN;
            AV62TotalSHMN = AV55SaldoHAMN;
            AV63TotalSDME = AV56SaldoDAME;
            AV64TotalSHME = AV57SaldoHAME;
            /* Execute user subroutine: 'VALIDAMOVCENTROCOSTO' */
            S187 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            if ( AV59Flag1 == 1 )
            {
               HBB0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85CosDsc, "")), 5, Gx_line+0, 427, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Saldo Anterior C.Costo", 495, Gx_line+1, 627, Gx_line+15, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54SaldoDAMN, "ZZZZZZ,ZZZ,ZZ9.99")), 677, Gx_line+0, 784, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55SaldoHAMN, "ZZZZZZ,ZZZ,ZZ9.99")), 781, Gx_line+0, 888, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56SaldoDAME, "ZZZZZZ,ZZZ,ZZ9.99")), 866, Gx_line+0, 973, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57SaldoHAME, "ZZZZZZ,ZZZ,ZZ9.99")), 965, Gx_line+0, 1072, Gx_line+15, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
            /* Execute user subroutine: 'MOVIMIENTOSCENTROCOSTO' */
            S197 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            AV22TDebe = (decimal)(AV22TDebe+AV61TotalSDMN);
            AV23THaber = (decimal)(AV23THaber+AV62TotalSHMN);
            AV45TDebeE = (decimal)(AV45TDebeE+AV63TotalSDME);
            AV46THaberE = (decimal)(AV46THaberE+AV64TotalSHME);
            if ( AV59Flag1 == 1 )
            {
               AV66DifMN = (decimal)(AV61TotalSDMN-AV62TotalSHMN);
               AV67DifME = (decimal)(AV63TotalSDME-AV64TotalSHME);
               HBB0( false, 53) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total C.Costo :", 501, Gx_line+10, 585, Gx_line+24, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61TotalSDMN, "ZZZZZZ,ZZZ,ZZ9.99")), 677, Gx_line+9, 784, Gx_line+24, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62TotalSHMN, "ZZZZZZ,ZZZ,ZZ9.99")), 781, Gx_line+9, 888, Gx_line+24, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63TotalSDME, "ZZZZZZ,ZZZ,ZZ9.99")), 866, Gx_line+9, 973, Gx_line+24, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TotalSHME, "ZZZZZZ,ZZZ,ZZ9.99")), 965, Gx_line+9, 1072, Gx_line+24, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21CosCod, "")), 605, Gx_line+10, 658, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Saldo C.Costo :", 499, Gx_line+29, 585, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66DifMN, "ZZZZZZ,ZZZ,ZZ9.99")), 677, Gx_line+29, 784, Gx_line+44, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67DifME, "ZZZZZZ,ZZZ,ZZ9.99")), 866, Gx_line+29, 973, Gx_line+44, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(677, Gx_line+9, 1084, Gx_line+9, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+53);
            }
            if ( ! BRKBB7 )
            {
               BRKBB7 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S125( )
      {
         /* 'NOMBREAUXILIAR' Routine */
         returnInSub = false;
         AV100GXLvl296 = 0;
         /* Using cursor P00BB5 */
         pr_default.execute(3, new Object[] {AV76TipACod, AV58CueDAxu});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A71TipADCod = P00BB5_A71TipADCod[0];
            A70TipACod = P00BB5_A70TipACod[0];
            n70TipACod = P00BB5_n70TipACod[0];
            A72TipADDsc = P00BB5_A72TipADDsc[0];
            AV100GXLvl296 = 1;
            AV60CueDAxuDsc = A72TipADDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         if ( AV100GXLvl296 == 0 )
         {
            AV60CueDAxuDsc = "SIN AUXILIAR";
         }
      }

      protected void S161( )
      {
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV33cCosto ,
                                              AV87cCosto2 ,
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
         /* Using cursor P00BB6 */
         pr_default.execute(4, new Object[] {AV25CueCod, AV11Ano, AV12Mes, AV33cCosto, AV87cCosto2});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A126TASICod = P00BB6_A126TASICod[0];
            A2077VouSts = P00BB6_A2077VouSts[0];
            A79COSCod = P00BB6_A79COSCod[0];
            n79COSCod = P00BB6_n79COSCod[0];
            A91CueCod = P00BB6_A91CueCod[0];
            A128VouMes = P00BB6_A128VouMes[0];
            A127VouAno = P00BB6_A127VouAno[0];
            A2069VouDTcmb = P00BB6_A2069VouDTcmb[0];
            A2075VouGls = P00BB6_A2075VouGls[0];
            A132VouDTipCod = P00BB6_A132VouDTipCod[0];
            A2054VouDGls = P00BB6_A2054VouDGls[0];
            A131VouDMon = P00BB6_A131VouDMon[0];
            A2052VouDDebO = P00BB6_A2052VouDDebO[0];
            A2056VouDHabO = P00BB6_A2056VouDHabO[0];
            A129VouNum = P00BB6_A129VouNum[0];
            A1894TASIAbr = P00BB6_A1894TASIAbr[0];
            A2053VouDDoc = P00BB6_A2053VouDDoc[0];
            A136VouReg = P00BB6_A136VouReg[0];
            A2055VouDHab = P00BB6_A2055VouDHab[0];
            A2051VouDDeb = P00BB6_A2051VouDDeb[0];
            A135VouDFec = P00BB6_A135VouDFec[0];
            A130VouDSec = P00BB6_A130VouDSec[0];
            A1894TASIAbr = P00BB6_A1894TASIAbr[0];
            A2077VouSts = P00BB6_A2077VouSts[0];
            A2075VouGls = P00BB6_A2075VouGls[0];
            AV37DebeME = 0.00m;
            AV38HaberME = 0.00m;
            AV68Glosa = StringUtil.Trim( A2075VouGls);
            AV83VouDTipCod = A132VouDTipCod;
            /* Execute user subroutine: 'TIPODOCUMENTO' */
            S2010 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV68Glosa = StringUtil.Trim( A2054VouDGls);
            }
            if ( ! ( A131VouDMon == 1 ) )
            {
               AV37DebeME = NumberUtil.Round( A2052VouDDebO, 2);
               AV38HaberME = NumberUtil.Round( A2056VouDHabO, 2);
            }
            HBB0( false, 18) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2051VouDDeb, "ZZZ,ZZZ,ZZ9.99")), 689, Gx_line+0, 784, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2055VouDHab, "ZZZ,ZZZ,ZZ9.99")), 793, Gx_line+0, 888, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37DebeME, "ZZZZZZ,ZZZ,ZZ9.99")), 866, Gx_line+0, 973, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38HaberME, "ZZZZZZ,ZZZ,ZZ9.99")), 965, Gx_line+0, 1072, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136VouReg, "")), 316, Gx_line+0, 395, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Glosa, "")), 407, Gx_line+0, 702, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2053VouDDoc, "")), 225, Gx_line+0, 305, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A135VouDFec, "99/99/99"), 151, Gx_line+0, 198, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1894TASIAbr, "")), 10, Gx_line+0, 63, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A129VouNum, "")), 71, Gx_line+0, 124, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82TipAbr, "")), 202, Gx_line+0, 223, Gx_line+14, 1, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+18);
            AV61TotalSDMN = (decimal)(AV61TotalSDMN+(NumberUtil.Round( A2051VouDDeb, 2)));
            AV62TotalSHMN = (decimal)(AV62TotalSHMN+(NumberUtil.Round( A2055VouDHab, 2)));
            AV63TotalSDME = (decimal)(AV63TotalSDME+AV37DebeME);
            AV64TotalSHME = (decimal)(AV64TotalSHME+AV38HaberME);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S197( )
      {
         /* 'MOVIMIENTOSCENTROCOSTO' Routine */
         returnInSub = false;
         /* Using cursor P00BB7 */
         pr_default.execute(5, new Object[] {AV25CueCod, AV11Ano, AV12Mes, AV21CosCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A126TASICod = P00BB7_A126TASICod[0];
            A2077VouSts = P00BB7_A2077VouSts[0];
            A79COSCod = P00BB7_A79COSCod[0];
            n79COSCod = P00BB7_n79COSCod[0];
            A91CueCod = P00BB7_A91CueCod[0];
            A128VouMes = P00BB7_A128VouMes[0];
            A127VouAno = P00BB7_A127VouAno[0];
            A2069VouDTcmb = P00BB7_A2069VouDTcmb[0];
            A2075VouGls = P00BB7_A2075VouGls[0];
            A132VouDTipCod = P00BB7_A132VouDTipCod[0];
            A2054VouDGls = P00BB7_A2054VouDGls[0];
            A131VouDMon = P00BB7_A131VouDMon[0];
            A2052VouDDebO = P00BB7_A2052VouDDebO[0];
            A2056VouDHabO = P00BB7_A2056VouDHabO[0];
            A129VouNum = P00BB7_A129VouNum[0];
            A1894TASIAbr = P00BB7_A1894TASIAbr[0];
            A2053VouDDoc = P00BB7_A2053VouDDoc[0];
            A136VouReg = P00BB7_A136VouReg[0];
            A2055VouDHab = P00BB7_A2055VouDHab[0];
            A2051VouDDeb = P00BB7_A2051VouDDeb[0];
            A135VouDFec = P00BB7_A135VouDFec[0];
            A130VouDSec = P00BB7_A130VouDSec[0];
            A1894TASIAbr = P00BB7_A1894TASIAbr[0];
            A2077VouSts = P00BB7_A2077VouSts[0];
            A2075VouGls = P00BB7_A2075VouGls[0];
            AV37DebeME = 0.00m;
            AV38HaberME = 0.00m;
            AV68Glosa = StringUtil.Trim( A2075VouGls);
            AV83VouDTipCod = A132VouDTipCod;
            /* Execute user subroutine: 'TIPODOCUMENTO' */
            S2010 ();
            if ( returnInSub )
            {
               pr_default.close(5);
               returnInSub = true;
               if (true) return;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV68Glosa = StringUtil.Trim( A2054VouDGls);
            }
            if ( ! ( A131VouDMon == 1 ) )
            {
               AV37DebeME = NumberUtil.Round( A2052VouDDebO, 2);
               AV38HaberME = NumberUtil.Round( A2056VouDHabO, 2);
            }
            HBB0( false, 18) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2051VouDDeb, "ZZZ,ZZZ,ZZ9.99")), 689, Gx_line+0, 784, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2055VouDHab, "ZZZ,ZZZ,ZZ9.99")), 793, Gx_line+0, 888, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37DebeME, "ZZZZZZ,ZZZ,ZZ9.99")), 866, Gx_line+0, 973, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38HaberME, "ZZZZZZ,ZZZ,ZZ9.99")), 965, Gx_line+0, 1072, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136VouReg, "")), 316, Gx_line+0, 395, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Glosa, "")), 407, Gx_line+0, 702, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2053VouDDoc, "")), 225, Gx_line+0, 305, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A135VouDFec, "99/99/99"), 151, Gx_line+0, 198, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1894TASIAbr, "")), 10, Gx_line+0, 63, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A129VouNum, "")), 71, Gx_line+0, 124, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82TipAbr, "")), 202, Gx_line+0, 223, Gx_line+14, 1, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+18);
            AV61TotalSDMN = (decimal)(AV61TotalSDMN+(NumberUtil.Round( A2051VouDDeb, 2)));
            AV62TotalSHMN = (decimal)(AV62TotalSHMN+(NumberUtil.Round( A2055VouDHab, 2)));
            AV63TotalSDME = (decimal)(AV63TotalSDME+AV37DebeME);
            AV64TotalSHME = (decimal)(AV64TotalSHME+AV38HaberME);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S145( )
      {
         /* 'MOVIMIENTOSAUXILIAR' Routine */
         returnInSub = false;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV33cCosto ,
                                              AV87cCosto2 ,
                                              A79COSCod ,
                                              A127VouAno ,
                                              AV11Ano ,
                                              A128VouMes ,
                                              AV12Mes ,
                                              A133CueCodAux ,
                                              AV58CueDAxu ,
                                              A2077VouSts ,
                                              AV25CueCod ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BB8 */
         pr_default.execute(6, new Object[] {AV25CueCod, AV11Ano, AV12Mes, AV58CueDAxu, AV33cCosto, AV87cCosto2});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A126TASICod = P00BB8_A126TASICod[0];
            A2077VouSts = P00BB8_A2077VouSts[0];
            A79COSCod = P00BB8_A79COSCod[0];
            n79COSCod = P00BB8_n79COSCod[0];
            A133CueCodAux = P00BB8_A133CueCodAux[0];
            A91CueCod = P00BB8_A91CueCod[0];
            A128VouMes = P00BB8_A128VouMes[0];
            A127VouAno = P00BB8_A127VouAno[0];
            A2069VouDTcmb = P00BB8_A2069VouDTcmb[0];
            A2075VouGls = P00BB8_A2075VouGls[0];
            A132VouDTipCod = P00BB8_A132VouDTipCod[0];
            A2054VouDGls = P00BB8_A2054VouDGls[0];
            A131VouDMon = P00BB8_A131VouDMon[0];
            A2052VouDDebO = P00BB8_A2052VouDDebO[0];
            A2056VouDHabO = P00BB8_A2056VouDHabO[0];
            A129VouNum = P00BB8_A129VouNum[0];
            A1894TASIAbr = P00BB8_A1894TASIAbr[0];
            A2053VouDDoc = P00BB8_A2053VouDDoc[0];
            A136VouReg = P00BB8_A136VouReg[0];
            A2055VouDHab = P00BB8_A2055VouDHab[0];
            A2051VouDDeb = P00BB8_A2051VouDDeb[0];
            A135VouDFec = P00BB8_A135VouDFec[0];
            A130VouDSec = P00BB8_A130VouDSec[0];
            A1894TASIAbr = P00BB8_A1894TASIAbr[0];
            A2077VouSts = P00BB8_A2077VouSts[0];
            A2075VouGls = P00BB8_A2075VouGls[0];
            AV37DebeME = 0.00m;
            AV38HaberME = 0.00m;
            AV68Glosa = StringUtil.Trim( A2075VouGls);
            AV83VouDTipCod = A132VouDTipCod;
            /* Execute user subroutine: 'TIPODOCUMENTO' */
            S2010 ();
            if ( returnInSub )
            {
               pr_default.close(6);
               returnInSub = true;
               if (true) return;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV68Glosa = StringUtil.Trim( A2054VouDGls);
            }
            if ( ! ( A131VouDMon == 1 ) )
            {
               AV37DebeME = NumberUtil.Round( A2052VouDDebO, 2);
               AV38HaberME = NumberUtil.Round( A2056VouDHabO, 2);
            }
            HBB0( false, 18) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2051VouDDeb, "ZZZ,ZZZ,ZZ9.99")), 689, Gx_line+0, 784, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2055VouDHab, "ZZZ,ZZZ,ZZ9.99")), 793, Gx_line+0, 888, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37DebeME, "ZZZZZZ,ZZZ,ZZ9.99")), 866, Gx_line+0, 973, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38HaberME, "ZZZZZZ,ZZZ,ZZ9.99")), 965, Gx_line+0, 1072, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136VouReg, "")), 316, Gx_line+0, 395, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Glosa, "")), 407, Gx_line+0, 702, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2053VouDDoc, "")), 225, Gx_line+0, 305, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A135VouDFec, "99/99/99"), 151, Gx_line+0, 198, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1894TASIAbr, "")), 10, Gx_line+0, 63, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A129VouNum, "")), 71, Gx_line+0, 124, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82TipAbr, "")), 202, Gx_line+0, 223, Gx_line+14, 1, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+18);
            AV61TotalSDMN = (decimal)(AV61TotalSDMN+(NumberUtil.Round( A2051VouDDeb, 2)));
            AV62TotalSHMN = (decimal)(AV62TotalSHMN+(NumberUtil.Round( A2055VouDHab, 2)));
            AV63TotalSDME = (decimal)(AV63TotalSDME+AV37DebeME);
            AV64TotalSHME = (decimal)(AV64TotalSHME+AV38HaberME);
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S211( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV33cCosto ,
                                              AV87cCosto2 ,
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
         /* Using cursor P00BB9 */
         pr_default.execute(7, new Object[] {AV11Ano, AV12Mes, AV25CueCod, AV33cCosto, AV87cCosto2});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A126TASICod = P00BB9_A126TASICod[0];
            A129VouNum = P00BB9_A129VouNum[0];
            A79COSCod = P00BB9_A79COSCod[0];
            n79COSCod = P00BB9_n79COSCod[0];
            A2077VouSts = P00BB9_A2077VouSts[0];
            A91CueCod = P00BB9_A91CueCod[0];
            A128VouMes = P00BB9_A128VouMes[0];
            A127VouAno = P00BB9_A127VouAno[0];
            A2069VouDTcmb = P00BB9_A2069VouDTcmb[0];
            A130VouDSec = P00BB9_A130VouDSec[0];
            A2077VouSts = P00BB9_A2077VouSts[0];
            AV49Flag = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void S135( )
      {
         /* 'VALIDAMOVAUXILIAR' Routine */
         returnInSub = false;
         pr_default.dynParam(8, new Object[]{ new Object[]{
                                              AV33cCosto ,
                                              AV87cCosto2 ,
                                              A79COSCod ,
                                              A2077VouSts ,
                                              AV11Ano ,
                                              AV12Mes ,
                                              AV25CueCod ,
                                              AV58CueDAxu ,
                                              A127VouAno ,
                                              A128VouMes ,
                                              A91CueCod ,
                                              A133CueCodAux } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BB10 */
         pr_default.execute(8, new Object[] {AV11Ano, AV12Mes, AV25CueCod, AV58CueDAxu, AV33cCosto, AV87cCosto2});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A126TASICod = P00BB10_A126TASICod[0];
            A129VouNum = P00BB10_A129VouNum[0];
            A2077VouSts = P00BB10_A2077VouSts[0];
            A79COSCod = P00BB10_A79COSCod[0];
            n79COSCod = P00BB10_n79COSCod[0];
            A133CueCodAux = P00BB10_A133CueCodAux[0];
            A91CueCod = P00BB10_A91CueCod[0];
            A128VouMes = P00BB10_A128VouMes[0];
            A127VouAno = P00BB10_A127VouAno[0];
            A2069VouDTcmb = P00BB10_A2069VouDTcmb[0];
            A130VouDSec = P00BB10_A130VouDSec[0];
            A2077VouSts = P00BB10_A2077VouSts[0];
            AV59Flag1 = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(8);
         }
         pr_default.close(8);
      }

      protected void S187( )
      {
         /* 'VALIDAMOVCENTROCOSTO' Routine */
         returnInSub = false;
         /* Using cursor P00BB11 */
         pr_default.execute(9, new Object[] {AV11Ano, AV12Mes, AV25CueCod, AV21CosCod});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A126TASICod = P00BB11_A126TASICod[0];
            A129VouNum = P00BB11_A129VouNum[0];
            A2077VouSts = P00BB11_A2077VouSts[0];
            A79COSCod = P00BB11_A79COSCod[0];
            n79COSCod = P00BB11_n79COSCod[0];
            A91CueCod = P00BB11_A91CueCod[0];
            A128VouMes = P00BB11_A128VouMes[0];
            A127VouAno = P00BB11_A127VouAno[0];
            A2069VouDTcmb = P00BB11_A2069VouDTcmb[0];
            A130VouDSec = P00BB11_A130VouDSec[0];
            A2077VouSts = P00BB11_A2077VouSts[0];
            AV59Flag1 = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(9);
         }
         pr_default.close(9);
      }

      protected void S2010( )
      {
         /* 'TIPODOCUMENTO' Routine */
         returnInSub = false;
         AV82TipAbr = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83VouDTipCod)) )
         {
            /* Using cursor P00BB12 */
            pr_default.execute(10, new Object[] {AV83VouDTipCod});
            while ( (pr_default.getStatus(10) != 101) )
            {
               A149TipCod = P00BB12_A149TipCod[0];
               A306TipAbr = P00BB12_A306TipAbr[0];
               AV82TipAbr = StringUtil.Trim( A306TipAbr);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(10);
         }
      }

      protected void HBB0( bool bFoot ,
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 296, Gx_line+25, 752, Gx_line+59, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 296, Gx_line+56, 752, Gx_line+90, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 9, Gx_line+90, 377, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73EmpRUC, "")), 9, Gx_line+107, 380, Gx_line+125, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV74Logo)) ? AV90Logo_GXI : AV74Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 8, Gx_line+8, 166, Gx_line+86) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hora:", 957, Gx_line+38, 989, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 957, Gx_line+54, 1001, Gx_line+68, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 957, Gx_line+21, 996, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1014, Gx_line+54, 1053, Gx_line+69, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 982, Gx_line+38, 1051, Gx_line+52, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1005, Gx_line+21, 1052, Gx_line+36, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+129);
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 161, Gx_line+20, 196, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Documento", 226, Gx_line+20, 295, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Debe", 730, Gx_line+21, 761, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber", 827, Gx_line+21, 863, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Registro", 336, Gx_line+20, 387, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Debe", 942, Gx_line+20, 973, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber", 1032, Gx_line+20, 1068, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(696, Gx_line+0, 696, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(900, Gx_line+1, 900, Gx_line+36, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("T.Asiento", 4, Gx_line+20, 60, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe Moneda Nacional", 719, Gx_line+2, 871, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe Moneda Extranjera", 905, Gx_line+2, 1071, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 1096, Gx_line+36, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(696, Gx_line+19, 1096, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+18, 408, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Asiento", 52, Gx_line+2, 98, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(145, Gx_line+0, 145, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Asiento", 72, Gx_line+20, 134, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(407, Gx_line+0, 407, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Glosa", 530, Gx_line+13, 563, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Documento", 240, Gx_line+2, 309, Gx_line+16, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
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
         AV90Logo_GXI = "";
         AV72FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV71cMes = "";
         GXt_char1 = "";
         AV13Titulo = "";
         AV14Periodo = "";
         scmdbuf = "";
         A91CueCod = "";
         A133CueCodAux = "";
         A79COSCod = "";
         P00BB2_A133CueCodAux = new string[] {""} ;
         P00BB2_A91CueCod = new string[] {""} ;
         P00BB2_A79COSCod = new string[] {""} ;
         P00BB2_n79COSCod = new bool[] {false} ;
         P00BB2_A127VouAno = new short[1] ;
         P00BB2_A860CueDsc = new string[] {""} ;
         P00BB2_A70TipACod = new int[1] ;
         P00BB2_n70TipACod = new bool[] {false} ;
         P00BB2_A859CueCos = new short[1] ;
         P00BB2_A128VouMes = new short[1] ;
         P00BB2_A126TASICod = new int[1] ;
         P00BB2_A129VouNum = new string[] {""} ;
         P00BB2_A130VouDSec = new int[1] ;
         A860CueDsc = "";
         A129VouNum = "";
         AV25CueCod = "";
         AV41CueDsc = "";
         AV21CosCod = "";
         P00BB3_A91CueCod = new string[] {""} ;
         P00BB3_A133CueCodAux = new string[] {""} ;
         P00BB3_A79COSCod = new string[] {""} ;
         P00BB3_n79COSCod = new bool[] {false} ;
         P00BB3_A127VouAno = new short[1] ;
         P00BB3_A128VouMes = new short[1] ;
         P00BB3_A126TASICod = new int[1] ;
         P00BB3_A129VouNum = new string[] {""} ;
         P00BB3_A130VouDSec = new int[1] ;
         AV58CueDAxu = "";
         AV60CueDAxuDsc = "";
         P00BB4_A129VouNum = new string[] {""} ;
         P00BB4_A79COSCod = new string[] {""} ;
         P00BB4_n79COSCod = new bool[] {false} ;
         P00BB4_A127VouAno = new short[1] ;
         P00BB4_A761COSDsc = new string[] {""} ;
         P00BB4_A128VouMes = new short[1] ;
         P00BB4_A126TASICod = new int[1] ;
         P00BB4_A130VouDSec = new int[1] ;
         A761COSDsc = "";
         AV85CosDsc = "";
         P00BB5_A71TipADCod = new string[] {""} ;
         P00BB5_A70TipACod = new int[1] ;
         P00BB5_n70TipACod = new bool[] {false} ;
         P00BB5_A72TipADDsc = new string[] {""} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         P00BB6_A126TASICod = new int[1] ;
         P00BB6_A2077VouSts = new short[1] ;
         P00BB6_A79COSCod = new string[] {""} ;
         P00BB6_n79COSCod = new bool[] {false} ;
         P00BB6_A91CueCod = new string[] {""} ;
         P00BB6_A128VouMes = new short[1] ;
         P00BB6_A127VouAno = new short[1] ;
         P00BB6_A2069VouDTcmb = new decimal[1] ;
         P00BB6_A2075VouGls = new string[] {""} ;
         P00BB6_A132VouDTipCod = new string[] {""} ;
         P00BB6_A2054VouDGls = new string[] {""} ;
         P00BB6_A131VouDMon = new int[1] ;
         P00BB6_A2052VouDDebO = new decimal[1] ;
         P00BB6_A2056VouDHabO = new decimal[1] ;
         P00BB6_A129VouNum = new string[] {""} ;
         P00BB6_A1894TASIAbr = new string[] {""} ;
         P00BB6_A2053VouDDoc = new string[] {""} ;
         P00BB6_A136VouReg = new string[] {""} ;
         P00BB6_A2055VouDHab = new decimal[1] ;
         P00BB6_A2051VouDDeb = new decimal[1] ;
         P00BB6_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BB6_A130VouDSec = new int[1] ;
         A2075VouGls = "";
         A132VouDTipCod = "";
         A2054VouDGls = "";
         A1894TASIAbr = "";
         A2053VouDDoc = "";
         A136VouReg = "";
         A135VouDFec = DateTime.MinValue;
         AV68Glosa = "";
         AV83VouDTipCod = "";
         AV82TipAbr = "";
         P00BB7_A126TASICod = new int[1] ;
         P00BB7_A2077VouSts = new short[1] ;
         P00BB7_A79COSCod = new string[] {""} ;
         P00BB7_n79COSCod = new bool[] {false} ;
         P00BB7_A91CueCod = new string[] {""} ;
         P00BB7_A128VouMes = new short[1] ;
         P00BB7_A127VouAno = new short[1] ;
         P00BB7_A2069VouDTcmb = new decimal[1] ;
         P00BB7_A2075VouGls = new string[] {""} ;
         P00BB7_A132VouDTipCod = new string[] {""} ;
         P00BB7_A2054VouDGls = new string[] {""} ;
         P00BB7_A131VouDMon = new int[1] ;
         P00BB7_A2052VouDDebO = new decimal[1] ;
         P00BB7_A2056VouDHabO = new decimal[1] ;
         P00BB7_A129VouNum = new string[] {""} ;
         P00BB7_A1894TASIAbr = new string[] {""} ;
         P00BB7_A2053VouDDoc = new string[] {""} ;
         P00BB7_A136VouReg = new string[] {""} ;
         P00BB7_A2055VouDHab = new decimal[1] ;
         P00BB7_A2051VouDDeb = new decimal[1] ;
         P00BB7_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BB7_A130VouDSec = new int[1] ;
         P00BB8_A126TASICod = new int[1] ;
         P00BB8_A2077VouSts = new short[1] ;
         P00BB8_A79COSCod = new string[] {""} ;
         P00BB8_n79COSCod = new bool[] {false} ;
         P00BB8_A133CueCodAux = new string[] {""} ;
         P00BB8_A91CueCod = new string[] {""} ;
         P00BB8_A128VouMes = new short[1] ;
         P00BB8_A127VouAno = new short[1] ;
         P00BB8_A2069VouDTcmb = new decimal[1] ;
         P00BB8_A2075VouGls = new string[] {""} ;
         P00BB8_A132VouDTipCod = new string[] {""} ;
         P00BB8_A2054VouDGls = new string[] {""} ;
         P00BB8_A131VouDMon = new int[1] ;
         P00BB8_A2052VouDDebO = new decimal[1] ;
         P00BB8_A2056VouDHabO = new decimal[1] ;
         P00BB8_A129VouNum = new string[] {""} ;
         P00BB8_A1894TASIAbr = new string[] {""} ;
         P00BB8_A2053VouDDoc = new string[] {""} ;
         P00BB8_A136VouReg = new string[] {""} ;
         P00BB8_A2055VouDHab = new decimal[1] ;
         P00BB8_A2051VouDDeb = new decimal[1] ;
         P00BB8_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BB8_A130VouDSec = new int[1] ;
         P00BB9_A126TASICod = new int[1] ;
         P00BB9_A129VouNum = new string[] {""} ;
         P00BB9_A79COSCod = new string[] {""} ;
         P00BB9_n79COSCod = new bool[] {false} ;
         P00BB9_A2077VouSts = new short[1] ;
         P00BB9_A91CueCod = new string[] {""} ;
         P00BB9_A128VouMes = new short[1] ;
         P00BB9_A127VouAno = new short[1] ;
         P00BB9_A2069VouDTcmb = new decimal[1] ;
         P00BB9_A130VouDSec = new int[1] ;
         P00BB10_A126TASICod = new int[1] ;
         P00BB10_A129VouNum = new string[] {""} ;
         P00BB10_A2077VouSts = new short[1] ;
         P00BB10_A79COSCod = new string[] {""} ;
         P00BB10_n79COSCod = new bool[] {false} ;
         P00BB10_A133CueCodAux = new string[] {""} ;
         P00BB10_A91CueCod = new string[] {""} ;
         P00BB10_A128VouMes = new short[1] ;
         P00BB10_A127VouAno = new short[1] ;
         P00BB10_A2069VouDTcmb = new decimal[1] ;
         P00BB10_A130VouDSec = new int[1] ;
         P00BB11_A126TASICod = new int[1] ;
         P00BB11_A129VouNum = new string[] {""} ;
         P00BB11_A2077VouSts = new short[1] ;
         P00BB11_A79COSCod = new string[] {""} ;
         P00BB11_n79COSCod = new bool[] {false} ;
         P00BB11_A91CueCod = new string[] {""} ;
         P00BB11_A128VouMes = new short[1] ;
         P00BB11_A127VouAno = new short[1] ;
         P00BB11_A2069VouDTcmb = new decimal[1] ;
         P00BB11_A130VouDSec = new int[1] ;
         P00BB12_A149TipCod = new string[] {""} ;
         P00BB12_A306TipAbr = new string[] {""} ;
         A149TipCod = "";
         A306TipAbr = "";
         AV74Logo = "";
         sImgUrl = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_libromayorgeneralpdf__default(),
            new Object[][] {
                new Object[] {
               P00BB2_A133CueCodAux, P00BB2_A91CueCod, P00BB2_A79COSCod, P00BB2_n79COSCod, P00BB2_A127VouAno, P00BB2_A860CueDsc, P00BB2_A70TipACod, P00BB2_n70TipACod, P00BB2_A859CueCos, P00BB2_A128VouMes,
               P00BB2_A126TASICod, P00BB2_A129VouNum, P00BB2_A130VouDSec
               }
               , new Object[] {
               P00BB3_A91CueCod, P00BB3_A133CueCodAux, P00BB3_A79COSCod, P00BB3_n79COSCod, P00BB3_A127VouAno, P00BB3_A128VouMes, P00BB3_A126TASICod, P00BB3_A129VouNum, P00BB3_A130VouDSec
               }
               , new Object[] {
               P00BB4_A129VouNum, P00BB4_A79COSCod, P00BB4_n79COSCod, P00BB4_A127VouAno, P00BB4_A761COSDsc, P00BB4_A128VouMes, P00BB4_A126TASICod, P00BB4_A130VouDSec
               }
               , new Object[] {
               P00BB5_A71TipADCod, P00BB5_A70TipACod, P00BB5_A72TipADDsc
               }
               , new Object[] {
               P00BB6_A126TASICod, P00BB6_A2077VouSts, P00BB6_A79COSCod, P00BB6_n79COSCod, P00BB6_A91CueCod, P00BB6_A128VouMes, P00BB6_A127VouAno, P00BB6_A2069VouDTcmb, P00BB6_A2075VouGls, P00BB6_A132VouDTipCod,
               P00BB6_A2054VouDGls, P00BB6_A131VouDMon, P00BB6_A2052VouDDebO, P00BB6_A2056VouDHabO, P00BB6_A129VouNum, P00BB6_A1894TASIAbr, P00BB6_A2053VouDDoc, P00BB6_A136VouReg, P00BB6_A2055VouDHab, P00BB6_A2051VouDDeb,
               P00BB6_A135VouDFec, P00BB6_A130VouDSec
               }
               , new Object[] {
               P00BB7_A126TASICod, P00BB7_A2077VouSts, P00BB7_A79COSCod, P00BB7_n79COSCod, P00BB7_A91CueCod, P00BB7_A128VouMes, P00BB7_A127VouAno, P00BB7_A2069VouDTcmb, P00BB7_A2075VouGls, P00BB7_A132VouDTipCod,
               P00BB7_A2054VouDGls, P00BB7_A131VouDMon, P00BB7_A2052VouDDebO, P00BB7_A2056VouDHabO, P00BB7_A129VouNum, P00BB7_A1894TASIAbr, P00BB7_A2053VouDDoc, P00BB7_A136VouReg, P00BB7_A2055VouDHab, P00BB7_A2051VouDDeb,
               P00BB7_A135VouDFec, P00BB7_A130VouDSec
               }
               , new Object[] {
               P00BB8_A126TASICod, P00BB8_A2077VouSts, P00BB8_A79COSCod, P00BB8_n79COSCod, P00BB8_A133CueCodAux, P00BB8_A91CueCod, P00BB8_A128VouMes, P00BB8_A127VouAno, P00BB8_A2069VouDTcmb, P00BB8_A2075VouGls,
               P00BB8_A132VouDTipCod, P00BB8_A2054VouDGls, P00BB8_A131VouDMon, P00BB8_A2052VouDDebO, P00BB8_A2056VouDHabO, P00BB8_A129VouNum, P00BB8_A1894TASIAbr, P00BB8_A2053VouDDoc, P00BB8_A136VouReg, P00BB8_A2055VouDHab,
               P00BB8_A2051VouDDeb, P00BB8_A135VouDFec, P00BB8_A130VouDSec
               }
               , new Object[] {
               P00BB9_A126TASICod, P00BB9_A129VouNum, P00BB9_A79COSCod, P00BB9_n79COSCod, P00BB9_A2077VouSts, P00BB9_A91CueCod, P00BB9_A128VouMes, P00BB9_A127VouAno, P00BB9_A2069VouDTcmb, P00BB9_A130VouDSec
               }
               , new Object[] {
               P00BB10_A126TASICod, P00BB10_A129VouNum, P00BB10_A2077VouSts, P00BB10_A79COSCod, P00BB10_n79COSCod, P00BB10_A133CueCodAux, P00BB10_A91CueCod, P00BB10_A128VouMes, P00BB10_A127VouAno, P00BB10_A2069VouDTcmb,
               P00BB10_A130VouDSec
               }
               , new Object[] {
               P00BB11_A126TASICod, P00BB11_A129VouNum, P00BB11_A2077VouSts, P00BB11_A79COSCod, P00BB11_n79COSCod, P00BB11_A91CueCod, P00BB11_A128VouMes, P00BB11_A127VouAno, P00BB11_A2069VouDTcmb, P00BB11_A130VouDSec
               }
               , new Object[] {
               P00BB12_A149TipCod, P00BB12_A306TipAbr
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV11Ano ;
      private short AV12Mes ;
      private short AV42cOpc ;
      private short A127VouAno ;
      private short A859CueCos ;
      private short A128VouMes ;
      private short AV84CueCos ;
      private short AV49Flag ;
      private short AV59Flag1 ;
      private short AV100GXLvl296 ;
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
      private decimal AV22TDebe ;
      private decimal AV23THaber ;
      private decimal AV45TDebeE ;
      private decimal AV46THaberE ;
      private decimal AV66DifMN ;
      private decimal AV67DifME ;
      private decimal AV54SaldoDAMN ;
      private decimal AV55SaldoHAMN ;
      private decimal AV56SaldoDAME ;
      private decimal AV57SaldoHAME ;
      private decimal AV61TotalSDMN ;
      private decimal AV62TotalSHMN ;
      private decimal AV63TotalSDME ;
      private decimal AV64TotalSHME ;
      private decimal A2069VouDTcmb ;
      private decimal A2052VouDDebO ;
      private decimal A2056VouDHabO ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private decimal AV37DebeME ;
      private decimal AV38HaberME ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV34cCuenta1 ;
      private string AV35cCuenta2 ;
      private string AV77CueCodAux ;
      private string AV33cCosto ;
      private string AV87cCosto2 ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV73EmpRUC ;
      private string AV75Ruta ;
      private string AV72FechaC ;
      private string AV71cMes ;
      private string GXt_char1 ;
      private string AV13Titulo ;
      private string AV14Periodo ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A133CueCodAux ;
      private string A79COSCod ;
      private string A860CueDsc ;
      private string A129VouNum ;
      private string AV25CueCod ;
      private string AV41CueDsc ;
      private string AV21CosCod ;
      private string AV58CueDAxu ;
      private string AV60CueDAxuDsc ;
      private string A761COSDsc ;
      private string AV85CosDsc ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string A2075VouGls ;
      private string A132VouDTipCod ;
      private string A2054VouDGls ;
      private string A1894TASIAbr ;
      private string A2053VouDDoc ;
      private string A136VouReg ;
      private string AV68Glosa ;
      private string AV83VouDTipCod ;
      private string AV82TipAbr ;
      private string A149TipCod ;
      private string A306TipAbr ;
      private string sImgUrl ;
      private string Gx_time ;
      private DateTime AV16FechaD ;
      private DateTime A135VouDFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKBB3 ;
      private bool n79COSCod ;
      private bool n70TipACod ;
      private bool returnInSub ;
      private bool BRKBB5 ;
      private bool BRKBB7 ;
      private string AV90Logo_GXI ;
      private string AV74Logo ;
      private string Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_cCuenta1 ;
      private string aP3_cCuenta2 ;
      private short aP4_cOpc ;
      private string aP5_CueCodAux ;
      private string aP6_cCosto ;
      private string aP7_cCosto2 ;
      private IDataStoreProvider pr_default ;
      private string[] P00BB2_A133CueCodAux ;
      private string[] P00BB2_A91CueCod ;
      private string[] P00BB2_A79COSCod ;
      private bool[] P00BB2_n79COSCod ;
      private short[] P00BB2_A127VouAno ;
      private string[] P00BB2_A860CueDsc ;
      private int[] P00BB2_A70TipACod ;
      private bool[] P00BB2_n70TipACod ;
      private short[] P00BB2_A859CueCos ;
      private short[] P00BB2_A128VouMes ;
      private int[] P00BB2_A126TASICod ;
      private string[] P00BB2_A129VouNum ;
      private int[] P00BB2_A130VouDSec ;
      private string[] P00BB3_A91CueCod ;
      private string[] P00BB3_A133CueCodAux ;
      private string[] P00BB3_A79COSCod ;
      private bool[] P00BB3_n79COSCod ;
      private short[] P00BB3_A127VouAno ;
      private short[] P00BB3_A128VouMes ;
      private int[] P00BB3_A126TASICod ;
      private string[] P00BB3_A129VouNum ;
      private int[] P00BB3_A130VouDSec ;
      private string[] P00BB4_A129VouNum ;
      private string[] P00BB4_A79COSCod ;
      private bool[] P00BB4_n79COSCod ;
      private short[] P00BB4_A127VouAno ;
      private string[] P00BB4_A761COSDsc ;
      private short[] P00BB4_A128VouMes ;
      private int[] P00BB4_A126TASICod ;
      private int[] P00BB4_A130VouDSec ;
      private string[] P00BB5_A71TipADCod ;
      private int[] P00BB5_A70TipACod ;
      private bool[] P00BB5_n70TipACod ;
      private string[] P00BB5_A72TipADDsc ;
      private int[] P00BB6_A126TASICod ;
      private short[] P00BB6_A2077VouSts ;
      private string[] P00BB6_A79COSCod ;
      private bool[] P00BB6_n79COSCod ;
      private string[] P00BB6_A91CueCod ;
      private short[] P00BB6_A128VouMes ;
      private short[] P00BB6_A127VouAno ;
      private decimal[] P00BB6_A2069VouDTcmb ;
      private string[] P00BB6_A2075VouGls ;
      private string[] P00BB6_A132VouDTipCod ;
      private string[] P00BB6_A2054VouDGls ;
      private int[] P00BB6_A131VouDMon ;
      private decimal[] P00BB6_A2052VouDDebO ;
      private decimal[] P00BB6_A2056VouDHabO ;
      private string[] P00BB6_A129VouNum ;
      private string[] P00BB6_A1894TASIAbr ;
      private string[] P00BB6_A2053VouDDoc ;
      private string[] P00BB6_A136VouReg ;
      private decimal[] P00BB6_A2055VouDHab ;
      private decimal[] P00BB6_A2051VouDDeb ;
      private DateTime[] P00BB6_A135VouDFec ;
      private int[] P00BB6_A130VouDSec ;
      private int[] P00BB7_A126TASICod ;
      private short[] P00BB7_A2077VouSts ;
      private string[] P00BB7_A79COSCod ;
      private bool[] P00BB7_n79COSCod ;
      private string[] P00BB7_A91CueCod ;
      private short[] P00BB7_A128VouMes ;
      private short[] P00BB7_A127VouAno ;
      private decimal[] P00BB7_A2069VouDTcmb ;
      private string[] P00BB7_A2075VouGls ;
      private string[] P00BB7_A132VouDTipCod ;
      private string[] P00BB7_A2054VouDGls ;
      private int[] P00BB7_A131VouDMon ;
      private decimal[] P00BB7_A2052VouDDebO ;
      private decimal[] P00BB7_A2056VouDHabO ;
      private string[] P00BB7_A129VouNum ;
      private string[] P00BB7_A1894TASIAbr ;
      private string[] P00BB7_A2053VouDDoc ;
      private string[] P00BB7_A136VouReg ;
      private decimal[] P00BB7_A2055VouDHab ;
      private decimal[] P00BB7_A2051VouDDeb ;
      private DateTime[] P00BB7_A135VouDFec ;
      private int[] P00BB7_A130VouDSec ;
      private int[] P00BB8_A126TASICod ;
      private short[] P00BB8_A2077VouSts ;
      private string[] P00BB8_A79COSCod ;
      private bool[] P00BB8_n79COSCod ;
      private string[] P00BB8_A133CueCodAux ;
      private string[] P00BB8_A91CueCod ;
      private short[] P00BB8_A128VouMes ;
      private short[] P00BB8_A127VouAno ;
      private decimal[] P00BB8_A2069VouDTcmb ;
      private string[] P00BB8_A2075VouGls ;
      private string[] P00BB8_A132VouDTipCod ;
      private string[] P00BB8_A2054VouDGls ;
      private int[] P00BB8_A131VouDMon ;
      private decimal[] P00BB8_A2052VouDDebO ;
      private decimal[] P00BB8_A2056VouDHabO ;
      private string[] P00BB8_A129VouNum ;
      private string[] P00BB8_A1894TASIAbr ;
      private string[] P00BB8_A2053VouDDoc ;
      private string[] P00BB8_A136VouReg ;
      private decimal[] P00BB8_A2055VouDHab ;
      private decimal[] P00BB8_A2051VouDDeb ;
      private DateTime[] P00BB8_A135VouDFec ;
      private int[] P00BB8_A130VouDSec ;
      private int[] P00BB9_A126TASICod ;
      private string[] P00BB9_A129VouNum ;
      private string[] P00BB9_A79COSCod ;
      private bool[] P00BB9_n79COSCod ;
      private short[] P00BB9_A2077VouSts ;
      private string[] P00BB9_A91CueCod ;
      private short[] P00BB9_A128VouMes ;
      private short[] P00BB9_A127VouAno ;
      private decimal[] P00BB9_A2069VouDTcmb ;
      private int[] P00BB9_A130VouDSec ;
      private int[] P00BB10_A126TASICod ;
      private string[] P00BB10_A129VouNum ;
      private short[] P00BB10_A2077VouSts ;
      private string[] P00BB10_A79COSCod ;
      private bool[] P00BB10_n79COSCod ;
      private string[] P00BB10_A133CueCodAux ;
      private string[] P00BB10_A91CueCod ;
      private short[] P00BB10_A128VouMes ;
      private short[] P00BB10_A127VouAno ;
      private decimal[] P00BB10_A2069VouDTcmb ;
      private int[] P00BB10_A130VouDSec ;
      private int[] P00BB11_A126TASICod ;
      private string[] P00BB11_A129VouNum ;
      private short[] P00BB11_A2077VouSts ;
      private string[] P00BB11_A79COSCod ;
      private bool[] P00BB11_n79COSCod ;
      private string[] P00BB11_A91CueCod ;
      private short[] P00BB11_A128VouMes ;
      private short[] P00BB11_A127VouAno ;
      private decimal[] P00BB11_A2069VouDTcmb ;
      private int[] P00BB11_A130VouDSec ;
      private string[] P00BB12_A149TipCod ;
      private string[] P00BB12_A306TipAbr ;
   }

   public class r_libromayorgeneralpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BB2( IGxContext context ,
                                             string AV34cCuenta1 ,
                                             string AV35cCuenta2 ,
                                             string AV77CueCodAux ,
                                             string AV33cCosto ,
                                             string AV87cCosto2 ,
                                             string A91CueCod ,
                                             string A133CueCodAux ,
                                             string A79COSCod ,
                                             short A127VouAno ,
                                             short AV11Ano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[CueCodAux], T1.[CueCod], T1.[COSCod], T1.[VouAno], T2.[CueDsc], T2.[TipACod], T2.[CueCos], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] >= @AV33cCosto)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87cCosto2)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] <= @AV87cCosto2)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00BB3( IGxContext context ,
                                             string AV77CueCodAux ,
                                             string AV33cCosto ,
                                             string AV87cCosto2 ,
                                             string A133CueCodAux ,
                                             string A79COSCod ,
                                             short A127VouAno ,
                                             short AV11Ano ,
                                             string A91CueCod ,
                                             string AV25CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[5];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [CueCod], [CueCodAux], [COSCod], [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET]";
         AddWhere(sWhereString, "([VouAno] = @AV11Ano)");
         AddWhere(sWhereString, "([CueCod] = @AV25CueCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77CueCodAux)) )
         {
            AddWhere(sWhereString, "([CueCodAux] = @AV77CueCodAux)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "([COSCod] >= @AV33cCosto)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87cCosto2)) )
         {
            AddWhere(sWhereString, "([COSCod] <= @AV87cCosto2)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueCodAux], [CueCod]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00BB4( IGxContext context ,
                                             string AV33cCosto ,
                                             string AV87cCosto2 ,
                                             string A79COSCod ,
                                             short A127VouAno ,
                                             short AV11Ano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[3];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[VouNum], T1.[COSCod], T1.[VouAno], T2.[COSDsc], T1.[VouMes], T1.[TASICod], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 LEFT JOIN [CBCOSTOS] T2 ON T2.[COSCod] = T1.[COSCod])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] >= @AV33cCosto)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87cCosto2)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] <= @AV87cCosto2)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[COSCod], T1.[VouNum]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00BB6( IGxContext context ,
                                             string AV33cCosto ,
                                             string AV87cCosto2 ,
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
         short[] GXv_int8 = new short[5];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T3.[VouSts], T1.[COSCod], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T3.[VouGls], T1.[VouDTipCod], T1.[VouDGls], T1.[VouDMon], T1.[VouDDebO], T1.[VouDHabO], T1.[VouNum], T2.[TASIAbr], T1.[VouDDoc], T1.[VouReg], T1.[VouDHab], T1.[VouDDeb], T1.[VouDFec], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV25CueCod)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano)");
         AddWhere(sWhereString, "(T1.[VouMes] = @AV12Mes)");
         AddWhere(sWhereString, "(T3.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] >= @AV33cCosto)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87cCosto2)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] <= @AV87cCosto2)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[VouDFec]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00BB8( IGxContext context ,
                                             string AV33cCosto ,
                                             string AV87cCosto2 ,
                                             string A79COSCod ,
                                             short A127VouAno ,
                                             short AV11Ano ,
                                             short A128VouMes ,
                                             short AV12Mes ,
                                             string A133CueCodAux ,
                                             string AV58CueDAxu ,
                                             short A2077VouSts ,
                                             string AV25CueCod ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[6];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T3.[VouSts], T1.[COSCod], T1.[CueCodAux], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T3.[VouGls], T1.[VouDTipCod], T1.[VouDGls], T1.[VouDMon], T1.[VouDDebO], T1.[VouDHabO], T1.[VouNum], T2.[TASIAbr], T1.[VouDDoc], T1.[VouReg], T1.[VouDHab], T1.[VouDDeb], T1.[VouDFec], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV25CueCod)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano)");
         AddWhere(sWhereString, "(T1.[VouMes] = @AV12Mes)");
         AddWhere(sWhereString, "(T1.[CueCodAux] = @AV58CueDAxu)");
         AddWhere(sWhereString, "(T3.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] >= @AV33cCosto)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87cCosto2)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] <= @AV87cCosto2)");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[VouDFec]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P00BB9( IGxContext context ,
                                             string AV33cCosto ,
                                             string AV87cCosto2 ,
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
         short[] GXv_int12 = new short[5];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T1.[COSCod], T2.[VouSts], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV25CueCod)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] >= @AV33cCosto)");
         }
         else
         {
            GXv_int12[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87cCosto2)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] <= @AV87cCosto2)");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod]";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_P00BB10( IGxContext context ,
                                              string AV33cCosto ,
                                              string AV87cCosto2 ,
                                              string A79COSCod ,
                                              short A2077VouSts ,
                                              short AV11Ano ,
                                              short AV12Mes ,
                                              string AV25CueCod ,
                                              string AV58CueDAxu ,
                                              short A127VouAno ,
                                              short A128VouMes ,
                                              string A91CueCod ,
                                              string A133CueCodAux )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[6];
         Object[] GXv_Object15 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[COSCod], T1.[CueCodAux], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV25CueCod and T1.[CueCodAux] = @AV58CueDAxu)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] >= @AV33cCosto)");
         }
         else
         {
            GXv_int14[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87cCosto2)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] <= @AV87cCosto2)");
         }
         else
         {
            GXv_int14[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod], T1.[CueCodAux]";
         GXv_Object15[0] = scmdbuf;
         GXv_Object15[1] = GXv_int14;
         return GXv_Object15 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BB2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] );
               case 1 :
                     return conditional_P00BB3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] );
               case 2 :
                     return conditional_P00BB4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] );
               case 4 :
                     return conditional_P00BB6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
               case 6 :
                     return conditional_P00BB8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
               case 7 :
                     return conditional_P00BB9(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] );
               case 8 :
                     return conditional_P00BB10(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BB5;
          prmP00BB5 = new Object[] {
          new ParDef("@AV76TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV58CueDAxu",GXType.NChar,20,0)
          };
          Object[] prmP00BB7;
          prmP00BB7 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV21CosCod",GXType.NChar,10,0)
          };
          Object[] prmP00BB11;
          prmP00BB11 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV21CosCod",GXType.NChar,10,0)
          };
          Object[] prmP00BB12;
          prmP00BB12 = new Object[] {
          new ParDef("@AV83VouDTipCod",GXType.NChar,3,0)
          };
          Object[] prmP00BB2;
          prmP00BB2 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV34cCuenta1",GXType.Char,15,0) ,
          new ParDef("@AV35cCuenta2",GXType.Char,15,0) ,
          new ParDef("@AV77CueCodAux",GXType.NChar,20,0) ,
          new ParDef("@AV33cCosto",GXType.Char,10,0) ,
          new ParDef("@AV87cCosto2",GXType.Char,10,0)
          };
          Object[] prmP00BB3;
          prmP00BB3 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV77CueCodAux",GXType.NChar,20,0) ,
          new ParDef("@AV33cCosto",GXType.Char,10,0) ,
          new ParDef("@AV87cCosto2",GXType.Char,10,0)
          };
          Object[] prmP00BB4;
          prmP00BB4 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV33cCosto",GXType.Char,10,0) ,
          new ParDef("@AV87cCosto2",GXType.Char,10,0)
          };
          Object[] prmP00BB6;
          prmP00BB6 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV33cCosto",GXType.Char,10,0) ,
          new ParDef("@AV87cCosto2",GXType.Char,10,0)
          };
          Object[] prmP00BB8;
          prmP00BB8 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV58CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV33cCosto",GXType.Char,10,0) ,
          new ParDef("@AV87cCosto2",GXType.Char,10,0)
          };
          Object[] prmP00BB9;
          prmP00BB9 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV33cCosto",GXType.Char,10,0) ,
          new ParDef("@AV87cCosto2",GXType.Char,10,0)
          };
          Object[] prmP00BB10;
          prmP00BB10 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV58CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV33cCosto",GXType.Char,10,0) ,
          new ParDef("@AV87cCosto2",GXType.Char,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BB2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BB3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BB4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BB5", "SELECT [TipADCod], [TipACod], [TipADDsc] FROM [CBAUXILIARES] WHERE [TipACod] = @AV76TipACod and [TipADCod] = @AV58CueDAxu ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BB6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BB7", "SELECT T1.[TASICod], T3.[VouSts], T1.[COSCod], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T3.[VouGls], T1.[VouDTipCod], T1.[VouDGls], T1.[VouDMon], T1.[VouDDebO], T1.[VouDHabO], T1.[VouNum], T2.[TASIAbr], T1.[VouDDoc], T1.[VouReg], T1.[VouDHab], T1.[VouDDeb], T1.[VouDFec], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum]) WHERE (T1.[CueCod] = @AV25CueCod) AND (T1.[VouAno] = @AV11Ano) AND (T1.[VouMes] = @AV12Mes) AND (T1.[COSCod] = @AV21CosCod) AND (T3.[VouSts] = 1) ORDER BY T1.[CueCod], T1.[VouDFec] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BB8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BB9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BB10", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BB11", "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[COSCod], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV25CueCod) AND (T1.[COSCod] = @AV21CosCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB11,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BB12", "SELECT [TipCod], [TipAbr] FROM [CTIPDOC] WHERE [TipCod] = @AV83VouDTipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB12,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((short[]) buf[8])[0] = rslt.getShort(7);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 10);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getString(9, 3);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((string[]) buf[14])[0] = rslt.getString(14, 10);
                ((string[]) buf[15])[0] = rslt.getString(15, 5);
                ((string[]) buf[16])[0] = rslt.getString(16, 20);
                ((string[]) buf[17])[0] = rslt.getString(17, 15);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(20);
                ((int[]) buf[21])[0] = rslt.getInt(21);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getString(9, 3);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((string[]) buf[14])[0] = rslt.getString(14, 10);
                ((string[]) buf[15])[0] = rslt.getString(15, 5);
                ((string[]) buf[16])[0] = rslt.getString(16, 20);
                ((string[]) buf[17])[0] = rslt.getString(17, 15);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(20);
                ((int[]) buf[21])[0] = rslt.getInt(21);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
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
                ((string[]) buf[15])[0] = rslt.getString(15, 10);
                ((string[]) buf[16])[0] = rslt.getString(16, 5);
                ((string[]) buf[17])[0] = rslt.getString(17, 20);
                ((string[]) buf[18])[0] = rslt.getString(18, 15);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(20);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(21);
                ((int[]) buf[22])[0] = rslt.getInt(22);
                return;
             case 7 :
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
             case 8 :
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
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
       }
    }

 }

}
