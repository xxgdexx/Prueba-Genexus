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
   public class r_saldoscontablespdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_saldoscontablespdf.aspx")), "contabilidad.r_saldoscontablespdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_saldoscontablespdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "FDesde");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV17FDesde = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV18Fhasta = context.localUtil.ParseDateParm( GetPar( "Fhasta"));
                  AV34cCuenta1 = GetPar( "cCuenta1");
                  AV35cCuenta2 = GetPar( "cCuenta2");
                  AV33cCosto = GetPar( "cCosto");
                  AV77CueCodAux = GetPar( "CueCodAux");
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

      public r_saldoscontablespdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_saldoscontablespdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FDesde ,
                           ref DateTime aP1_Fhasta ,
                           ref string aP2_cCuenta1 ,
                           ref string aP3_cCuenta2 ,
                           ref string aP4_cCosto ,
                           ref string aP5_CueCodAux )
      {
         this.AV17FDesde = aP0_FDesde;
         this.AV18Fhasta = aP1_Fhasta;
         this.AV34cCuenta1 = aP2_cCuenta1;
         this.AV35cCuenta2 = aP3_cCuenta2;
         this.AV33cCosto = aP4_cCosto;
         this.AV77CueCodAux = aP5_CueCodAux;
         initialize();
         executePrivate();
         aP0_FDesde=this.AV17FDesde;
         aP1_Fhasta=this.AV18Fhasta;
         aP2_cCuenta1=this.AV34cCuenta1;
         aP3_cCuenta2=this.AV35cCuenta2;
         aP4_cCosto=this.AV33cCosto;
         aP5_CueCodAux=this.AV77CueCodAux;
      }

      public string executeUdp( ref DateTime aP0_FDesde ,
                                ref DateTime aP1_Fhasta ,
                                ref string aP2_cCuenta1 ,
                                ref string aP3_cCuenta2 ,
                                ref string aP4_cCosto )
      {
         execute(ref aP0_FDesde, ref aP1_Fhasta, ref aP2_cCuenta1, ref aP3_cCuenta2, ref aP4_cCosto, ref aP5_CueCodAux);
         return AV77CueCodAux ;
      }

      public void executeSubmit( ref DateTime aP0_FDesde ,
                                 ref DateTime aP1_Fhasta ,
                                 ref string aP2_cCuenta1 ,
                                 ref string aP3_cCuenta2 ,
                                 ref string aP4_cCosto ,
                                 ref string aP5_CueCodAux )
      {
         r_saldoscontablespdf objr_saldoscontablespdf;
         objr_saldoscontablespdf = new r_saldoscontablespdf();
         objr_saldoscontablespdf.AV17FDesde = aP0_FDesde;
         objr_saldoscontablespdf.AV18Fhasta = aP1_Fhasta;
         objr_saldoscontablespdf.AV34cCuenta1 = aP2_cCuenta1;
         objr_saldoscontablespdf.AV35cCuenta2 = aP3_cCuenta2;
         objr_saldoscontablespdf.AV33cCosto = aP4_cCosto;
         objr_saldoscontablespdf.AV77CueCodAux = aP5_CueCodAux;
         objr_saldoscontablespdf.context.SetSubmitInitialConfig(context);
         objr_saldoscontablespdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_saldoscontablespdf);
         aP0_FDesde=this.AV17FDesde;
         aP1_Fhasta=this.AV18Fhasta;
         aP2_cCuenta1=this.AV34cCuenta1;
         aP3_cCuenta2=this.AV35cCuenta2;
         aP4_cCosto=this.AV33cCosto;
         aP5_CueCodAux=this.AV77CueCodAux;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_saldoscontablespdf)stateInfo).executePrivate();
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
            AV84Logo_GXI = GXDbFile.PathToUrl( AV75Ruta);
            AV72FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV72FechaC, 2);
            GXt_char1 = AV71cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV71cMes = GXt_char1;
            AV13Titulo = "Saldos Contables";
            AV14Periodo = "Periodo : " + context.localUtil.DToC( AV17FDesde, 2, "/") + " Al " + context.localUtil.DToC( AV18Fhasta, 2, "/");
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
                                                 A135VouDFec ,
                                                 AV17FDesde ,
                                                 AV18Fhasta } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00AW2 */
            pr_default.execute(0, new Object[] {AV17FDesde, AV18Fhasta, AV34cCuenta1, AV35cCuenta2, AV77CueCodAux});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKAW3 = false;
               A133CueCodAux = P00AW2_A133CueCodAux[0];
               A91CueCod = P00AW2_A91CueCod[0];
               A135VouDFec = P00AW2_A135VouDFec[0];
               A860CueDsc = P00AW2_A860CueDsc[0];
               A70TipACod = P00AW2_A70TipACod[0];
               n70TipACod = P00AW2_n70TipACod[0];
               A127VouAno = P00AW2_A127VouAno[0];
               A128VouMes = P00AW2_A128VouMes[0];
               A126TASICod = P00AW2_A126TASICod[0];
               A129VouNum = P00AW2_A129VouNum[0];
               A130VouDSec = P00AW2_A130VouDSec[0];
               A860CueDsc = P00AW2_A860CueDsc[0];
               A70TipACod = P00AW2_A70TipACod[0];
               n70TipACod = P00AW2_n70TipACod[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AW2_A91CueCod[0], A91CueCod) == 0 ) )
               {
                  BRKAW3 = false;
                  A133CueCodAux = P00AW2_A133CueCodAux[0];
                  A127VouAno = P00AW2_A127VouAno[0];
                  A128VouMes = P00AW2_A128VouMes[0];
                  A126TASICod = P00AW2_A126TASICod[0];
                  A129VouNum = P00AW2_A129VouNum[0];
                  A130VouDSec = P00AW2_A130VouDSec[0];
                  BRKAW3 = true;
                  pr_default.readNext(0);
               }
               AV25CueCod = A91CueCod;
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
               AV22TDebe = 0.00m;
               AV23THaber = 0.00m;
               AV45TDebeE = 0.00m;
               AV46THaberE = 0.00m;
               GXt_char1 = "";
               new GeneXus.Programs.contabilidad.pobtienesaldoscuentarangosfechas(context ).execute( ref  AV25CueCod, ref  GXt_char1, ref  AV17FDesde, out  AV50SaldoDMN, out  AV51SaldoHMN, out  AV52SaldoDME, out  AV53SaldoHME) ;
               AV69SaldoMN = (decimal)(AV50SaldoDMN-AV51SaldoHMN);
               AV70SaldoME = (decimal)(AV52SaldoDME-AV53SaldoHME);
               AV47TDebeMO = ((AV69SaldoMN>Convert.ToDecimal(0)) ? AV69SaldoMN : (decimal)(0));
               AV48ThaberMO = ((AV69SaldoMN<Convert.ToDecimal(0)) ? AV69SaldoMN*-1 : (decimal)(0));
               AV39TDebeME = ((AV70SaldoME>Convert.ToDecimal(0)) ? AV70SaldoME : (decimal)(0));
               AV40THaberME = ((AV70SaldoME<Convert.ToDecimal(0)) ? AV70SaldoME*-1 : (decimal)(0));
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
               S161 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( AV49Flag == 1 )
               {
                  HAW0( false, 20) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 4, Gx_line+3, 83, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41CueDsc, "")), 96, Gx_line+3, 397, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50SaldoDMN, "ZZZZZZ,ZZZ,ZZ9.99")), 743, Gx_line+3, 850, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51SaldoHMN, "ZZZZZZ,ZZZ,ZZ9.99")), 830, Gx_line+3, 937, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52SaldoDME, "ZZZZZZ,ZZZ,ZZ9.99")), 902, Gx_line+3, 1009, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53SaldoHME, "ZZZZZZ,ZZZ,ZZ9.99")), 978, Gx_line+3, 1085, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Saldo Anterior Cuenta ", 509, Gx_line+4, 642, Gx_line+18, 0+256, 0, 0, 0) ;
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
               if ( ! BRKAW3 )
               {
                  BRKAW3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HAW0( false, 35) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 563, Gx_line+7, 643, Gx_line+21, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV78TDebePagMo, "ZZZZZZ,ZZZ,ZZ9.99")), 743, Gx_line+8, 850, Gx_line+23, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV79THaberPagMo, "ZZZZZZ,ZZZ,ZZ9.99")), 830, Gx_line+8, 937, Gx_line+23, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV80TDebePagMe, "ZZZZZZ,ZZZ,ZZ9.99")), 902, Gx_line+8, 1009, Gx_line+23, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV81THaberPagMe, "ZZZZZZ,ZZZ,ZZ9.99")), 978, Gx_line+8, 1085, Gx_line+23, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+35);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAW0( true, 0) ;
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
         if ( AV76TipACod > 0 )
         {
            AV22TDebe = 0.00m;
            AV23THaber = 0.00m;
            AV45TDebeE = 0.00m;
            AV46THaberE = 0.00m;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV77CueCodAux ,
                                                 A133CueCodAux ,
                                                 A135VouDFec ,
                                                 AV17FDesde ,
                                                 AV18Fhasta ,
                                                 A91CueCod ,
                                                 AV25CueCod } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00AW3 */
            pr_default.execute(1, new Object[] {AV17FDesde, AV18Fhasta, AV25CueCod, AV77CueCodAux});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRKAW5 = false;
               A134CueAuxCod = P00AW3_A134CueAuxCod[0];
               A133CueCodAux = P00AW3_A133CueCodAux[0];
               A91CueCod = P00AW3_A91CueCod[0];
               A135VouDFec = P00AW3_A135VouDFec[0];
               A127VouAno = P00AW3_A127VouAno[0];
               A128VouMes = P00AW3_A128VouMes[0];
               A126TASICod = P00AW3_A126TASICod[0];
               A129VouNum = P00AW3_A129VouNum[0];
               A130VouDSec = P00AW3_A130VouDSec[0];
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00AW3_A133CueCodAux[0], A133CueCodAux) == 0 ) )
               {
                  BRKAW5 = false;
                  A134CueAuxCod = P00AW3_A134CueAuxCod[0];
                  A127VouAno = P00AW3_A127VouAno[0];
                  A128VouMes = P00AW3_A128VouMes[0];
                  A126TASICod = P00AW3_A126TASICod[0];
                  A129VouNum = P00AW3_A129VouNum[0];
                  A130VouDSec = P00AW3_A130VouDSec[0];
                  BRKAW5 = true;
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
               new GeneXus.Programs.contabilidad.pobtienesaldoscuentarangosfechas(context ).execute( ref  AV25CueCod, ref  AV58CueDAxu, ref  AV17FDesde, out  AV54SaldoDAMN, out  AV55SaldoHAMN, out  AV56SaldoDAME, out  AV57SaldoHAME) ;
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
                  HAW0( false, 20) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58CueDAxu, "")), 5, Gx_line+1, 110, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60CueDAxuDsc, "")), 97, Gx_line+1, 398, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Saldo Anterior Auxiliar ", 506, Gx_line+2, 642, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54SaldoDAMN, "ZZZZZZ,ZZZ,ZZ9.99")), 743, Gx_line+1, 850, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55SaldoHAMN, "ZZZZZZ,ZZZ,ZZ9.99")), 830, Gx_line+1, 937, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56SaldoDAME, "ZZZZZZ,ZZZ,ZZ9.99")), 902, Gx_line+1, 1009, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57SaldoHAME, "ZZZZZZ,ZZZ,ZZ9.99")), 978, Gx_line+1, 1085, Gx_line+16, 2+256, 0, 0, 0) ;
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
                  HAW0( false, 26) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Saldo Auxiliar :", 555, Gx_line+7, 642, Gx_line+21, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66DifMN, "ZZZZZZ,ZZZ,ZZ9.99")), 743, Gx_line+7, 850, Gx_line+22, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67DifME, "ZZZZZZ,ZZZ,ZZ9.99")), 902, Gx_line+7, 1009, Gx_line+22, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58CueDAxu, "")), 645, Gx_line+7, 750, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+26);
               }
               if ( ! BRKAW5 )
               {
                  BRKAW5 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
         }
         else
         {
            AV58CueDAxu = "";
            AV61TotalSDMN = 0.00m;
            AV62TotalSHMN = 0.00m;
            AV63TotalSDME = 0.00m;
            AV64TotalSHME = 0.00m;
            /* Execute user subroutine: 'MOVIMIENTOS' */
            S151 ();
            if (returnInSub) return;
            AV22TDebe = (decimal)(AV22TDebe+AV61TotalSDMN);
            AV23THaber = (decimal)(AV23THaber+AV62TotalSHMN);
            AV45TDebeE = (decimal)(AV45TDebeE+AV63TotalSDME);
            AV46THaberE = (decimal)(AV46THaberE+AV64TotalSHME);
         }
         AV47TDebeMO = (decimal)(AV47TDebeMO+AV22TDebe);
         AV48ThaberMO = (decimal)(AV48ThaberMO+AV23THaber);
         AV39TDebeME = (decimal)(AV39TDebeME+AV45TDebeE);
         AV40THaberME = (decimal)(AV40THaberME+AV46THaberE);
         AV78TDebePagMo = (decimal)(AV78TDebePagMo+AV47TDebeMO);
         AV79THaberPagMo = (decimal)(AV79THaberPagMo+AV48ThaberMO);
         AV80TDebePagMe = (decimal)(AV80TDebePagMe+AV39TDebeME);
         AV81THaberPagMe = (decimal)(AV81THaberPagMe+AV40THaberME);
         if ( AV49Flag == 1 )
         {
            AV66DifMN = (decimal)(AV47TDebeMO-AV48ThaberMO);
            AV67DifME = (decimal)(AV39TDebeME-AV40THaberME);
            HAW0( false, 55) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Cuenta :", 560, Gx_line+8, 642, Gx_line+22, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(676, Gx_line+3, 1096, Gx_line+3, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TDebeMO, "ZZZZZZ,ZZZ,ZZ9.99")), 743, Gx_line+8, 850, Gx_line+23, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48ThaberMO, "ZZZZZZ,ZZZ,ZZ9.99")), 830, Gx_line+8, 937, Gx_line+23, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39TDebeME, "ZZZZZZ,ZZZ,ZZ9.99")), 902, Gx_line+8, 1009, Gx_line+23, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40THaberME, "ZZZZZZ,ZZZ,ZZ9.99")), 978, Gx_line+8, 1085, Gx_line+23, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 645, Gx_line+8, 724, Gx_line+23, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Saldo Cuenta :", 558, Gx_line+29, 642, Gx_line+43, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66DifMN, "ZZZZZZ,ZZZ,ZZ9.99")), 743, Gx_line+29, 850, Gx_line+44, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67DifME, "ZZZZZZ,ZZZ,ZZ9.99")), 902, Gx_line+29, 1009, Gx_line+44, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+55);
         }
      }

      protected void S125( )
      {
         /* 'NOMBREAUXILIAR' Routine */
         returnInSub = false;
         AV90GXLvl213 = 0;
         /* Using cursor P00AW4 */
         pr_default.execute(2, new Object[] {AV76TipACod, AV58CueDAxu});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A71TipADCod = P00AW4_A71TipADCod[0];
            A70TipACod = P00AW4_A70TipACod[0];
            n70TipACod = P00AW4_n70TipACod[0];
            A72TipADDsc = P00AW4_A72TipADDsc[0];
            AV90GXLvl213 = 1;
            AV60CueDAxuDsc = A72TipADDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( AV90GXLvl213 == 0 )
         {
            AV60CueDAxuDsc = "SIN AUXILIAR";
         }
      }

      protected void S151( )
      {
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV33cCosto ,
                                              A79COSCod ,
                                              A2077VouSts ,
                                              AV25CueCod ,
                                              AV17FDesde ,
                                              A91CueCod ,
                                              A135VouDFec ,
                                              AV18Fhasta } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AW5 */
         pr_default.execute(3, new Object[] {AV25CueCod, AV17FDesde, AV18Fhasta, AV33cCosto});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A127VouAno = P00AW5_A127VouAno[0];
            A128VouMes = P00AW5_A128VouMes[0];
            A126TASICod = P00AW5_A126TASICod[0];
            A2077VouSts = P00AW5_A2077VouSts[0];
            A79COSCod = P00AW5_A79COSCod[0];
            n79COSCod = P00AW5_n79COSCod[0];
            A91CueCod = P00AW5_A91CueCod[0];
            A135VouDFec = P00AW5_A135VouDFec[0];
            A2069VouDTcmb = P00AW5_A2069VouDTcmb[0];
            A2075VouGls = P00AW5_A2075VouGls[0];
            A2054VouDGls = P00AW5_A2054VouDGls[0];
            A131VouDMon = P00AW5_A131VouDMon[0];
            A2052VouDDebO = P00AW5_A2052VouDDebO[0];
            A2056VouDHabO = P00AW5_A2056VouDHabO[0];
            A136VouReg = P00AW5_A136VouReg[0];
            A2053VouDDoc = P00AW5_A2053VouDDoc[0];
            A129VouNum = P00AW5_A129VouNum[0];
            A1894TASIAbr = P00AW5_A1894TASIAbr[0];
            A133CueCodAux = P00AW5_A133CueCodAux[0];
            A2055VouDHab = P00AW5_A2055VouDHab[0];
            A2051VouDDeb = P00AW5_A2051VouDDeb[0];
            A130VouDSec = P00AW5_A130VouDSec[0];
            A1894TASIAbr = P00AW5_A1894TASIAbr[0];
            A2077VouSts = P00AW5_A2077VouSts[0];
            A2075VouGls = P00AW5_A2075VouGls[0];
            AV37DebeME = 0.00m;
            AV38HaberME = 0.00m;
            AV68Glosa = StringUtil.Trim( A2075VouGls);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV68Glosa = StringUtil.Trim( A2054VouDGls);
            }
            if ( ! ( A131VouDMon == 1 ) )
            {
               AV37DebeME = A2052VouDDebO;
               AV38HaberME = A2056VouDHabO;
            }
            HAW0( false, 18) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2051VouDDeb, "ZZZ,ZZZ,ZZ9.99")), 755, Gx_line+1, 850, Gx_line+16, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2055VouDHab, "ZZZ,ZZZ,ZZ9.99")), 842, Gx_line+1, 937, Gx_line+16, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37DebeME, "ZZZZZZ,ZZZ,ZZ9.99")), 902, Gx_line+1, 1009, Gx_line+16, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38HaberME, "ZZZZZZ,ZZZ,ZZ9.99")), 978, Gx_line+1, 1085, Gx_line+16, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Glosa, "")), 524, Gx_line+1, 766, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), 10, Gx_line+1, 89, Gx_line+16, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A79COSCod, "")), 79, Gx_line+1, 132, Gx_line+16, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A133CueCodAux, "")), 131, Gx_line+1, 210, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1894TASIAbr, "")), 210, Gx_line+1, 246, Gx_line+15, 1, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A129VouNum, "")), 252, Gx_line+1, 305, Gx_line+16, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2053VouDDoc, "")), 317, Gx_line+1, 401, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136VouReg, "")), 396, Gx_line+1, 475, Gx_line+16, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A135VouDFec, "99/99/99"), 474, Gx_line+1, 521, Gx_line+16, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+18);
            AV61TotalSDMN = (decimal)(AV61TotalSDMN+A2051VouDDeb);
            AV62TotalSHMN = (decimal)(AV62TotalSHMN+A2055VouDHab);
            AV63TotalSDME = (decimal)(AV63TotalSDME+AV37DebeME);
            AV64TotalSHME = (decimal)(AV64TotalSHME+AV38HaberME);
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
                                              A133CueCodAux ,
                                              AV58CueDAxu ,
                                              A2077VouSts ,
                                              AV25CueCod ,
                                              AV17FDesde ,
                                              A91CueCod ,
                                              A135VouDFec ,
                                              AV18Fhasta } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AW6 */
         pr_default.execute(4, new Object[] {AV25CueCod, AV17FDesde, AV58CueDAxu, AV18Fhasta, AV33cCosto});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A127VouAno = P00AW6_A127VouAno[0];
            A128VouMes = P00AW6_A128VouMes[0];
            A126TASICod = P00AW6_A126TASICod[0];
            A2077VouSts = P00AW6_A2077VouSts[0];
            A79COSCod = P00AW6_A79COSCod[0];
            n79COSCod = P00AW6_n79COSCod[0];
            A133CueCodAux = P00AW6_A133CueCodAux[0];
            A91CueCod = P00AW6_A91CueCod[0];
            A135VouDFec = P00AW6_A135VouDFec[0];
            A2069VouDTcmb = P00AW6_A2069VouDTcmb[0];
            A2075VouGls = P00AW6_A2075VouGls[0];
            A2054VouDGls = P00AW6_A2054VouDGls[0];
            A131VouDMon = P00AW6_A131VouDMon[0];
            A2052VouDDebO = P00AW6_A2052VouDDebO[0];
            A2056VouDHabO = P00AW6_A2056VouDHabO[0];
            A136VouReg = P00AW6_A136VouReg[0];
            A2053VouDDoc = P00AW6_A2053VouDDoc[0];
            A129VouNum = P00AW6_A129VouNum[0];
            A1894TASIAbr = P00AW6_A1894TASIAbr[0];
            A2055VouDHab = P00AW6_A2055VouDHab[0];
            A2051VouDDeb = P00AW6_A2051VouDDeb[0];
            A130VouDSec = P00AW6_A130VouDSec[0];
            A1894TASIAbr = P00AW6_A1894TASIAbr[0];
            A2077VouSts = P00AW6_A2077VouSts[0];
            A2075VouGls = P00AW6_A2075VouGls[0];
            AV37DebeME = 0.00m;
            AV38HaberME = 0.00m;
            AV68Glosa = StringUtil.Trim( A2075VouGls);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV68Glosa = StringUtil.Trim( A2054VouDGls);
            }
            if ( ! ( A131VouDMon == 1 ) )
            {
               AV37DebeME = A2052VouDDebO;
               AV38HaberME = A2056VouDHabO;
            }
            HAW0( false, 18) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2051VouDDeb, "ZZZ,ZZZ,ZZ9.99")), 755, Gx_line+1, 850, Gx_line+16, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2055VouDHab, "ZZZ,ZZZ,ZZ9.99")), 842, Gx_line+1, 937, Gx_line+16, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37DebeME, "ZZZZZZ,ZZZ,ZZ9.99")), 902, Gx_line+1, 1009, Gx_line+16, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38HaberME, "ZZZZZZ,ZZZ,ZZ9.99")), 978, Gx_line+1, 1085, Gx_line+16, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Glosa, "")), 524, Gx_line+1, 766, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), 10, Gx_line+1, 89, Gx_line+16, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A79COSCod, "")), 79, Gx_line+1, 132, Gx_line+16, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A133CueCodAux, "")), 131, Gx_line+1, 210, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1894TASIAbr, "")), 210, Gx_line+1, 246, Gx_line+15, 1, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A129VouNum, "")), 252, Gx_line+1, 305, Gx_line+16, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2053VouDDoc, "")), 317, Gx_line+1, 401, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136VouReg, "")), 396, Gx_line+1, 475, Gx_line+16, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A135VouDFec, "99/99/99"), 474, Gx_line+1, 521, Gx_line+16, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+18);
            AV61TotalSDMN = (decimal)(AV61TotalSDMN+A2051VouDDeb);
            AV62TotalSHMN = (decimal)(AV62TotalSHMN+A2055VouDHab);
            AV63TotalSDME = (decimal)(AV63TotalSDME+AV37DebeME);
            AV64TotalSHME = (decimal)(AV64TotalSHME+AV38HaberME);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S161( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV33cCosto ,
                                              A79COSCod ,
                                              A135VouDFec ,
                                              AV17FDesde ,
                                              AV18Fhasta ,
                                              A2077VouSts ,
                                              AV25CueCod ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00AW7 */
         pr_default.execute(5, new Object[] {AV25CueCod, AV17FDesde, AV18Fhasta, AV33cCosto});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A127VouAno = P00AW7_A127VouAno[0];
            A128VouMes = P00AW7_A128VouMes[0];
            A126TASICod = P00AW7_A126TASICod[0];
            A129VouNum = P00AW7_A129VouNum[0];
            A79COSCod = P00AW7_A79COSCod[0];
            n79COSCod = P00AW7_n79COSCod[0];
            A2077VouSts = P00AW7_A2077VouSts[0];
            A91CueCod = P00AW7_A91CueCod[0];
            A135VouDFec = P00AW7_A135VouDFec[0];
            A2069VouDTcmb = P00AW7_A2069VouDTcmb[0];
            A130VouDSec = P00AW7_A130VouDSec[0];
            A2077VouSts = P00AW7_A2077VouSts[0];
            AV49Flag = 1;
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
                                              A135VouDFec ,
                                              AV17FDesde ,
                                              AV18Fhasta ,
                                              A2077VouSts ,
                                              AV25CueCod ,
                                              AV58CueDAxu ,
                                              A91CueCod ,
                                              A133CueCodAux } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00AW8 */
         pr_default.execute(6, new Object[] {AV25CueCod, AV58CueDAxu, AV17FDesde, AV18Fhasta, AV33cCosto});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A127VouAno = P00AW8_A127VouAno[0];
            A128VouMes = P00AW8_A128VouMes[0];
            A126TASICod = P00AW8_A126TASICod[0];
            A129VouNum = P00AW8_A129VouNum[0];
            A2077VouSts = P00AW8_A2077VouSts[0];
            A79COSCod = P00AW8_A79COSCod[0];
            n79COSCod = P00AW8_n79COSCod[0];
            A133CueCodAux = P00AW8_A133CueCodAux[0];
            A91CueCod = P00AW8_A91CueCod[0];
            A135VouDFec = P00AW8_A135VouDFec[0];
            A2069VouDTcmb = P00AW8_A2069VouDTcmb[0];
            A130VouDSec = P00AW8_A130VouDSec[0];
            A2077VouSts = P00AW8_A2077VouSts[0];
            AV59Flag1 = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void HAW0( bool bFoot ,
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
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV74Logo)) ? AV84Logo_GXI : AV74Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 8, Gx_line+8, 166, Gx_line+86) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 976, Gx_line+23, 1020, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1026, Gx_line+23, 1065, Gx_line+38, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+130);
               getPrinter().GxDrawRect(0, Gx_line+0, 1096, Gx_line+26, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Glosa", 586, Gx_line+5, 619, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Registro", 399, Gx_line+5, 467, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Documento", 320, Gx_line+5, 389, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Asiento", 253, Gx_line+5, 315, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T.A.", 218, Gx_line+5, 241, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Auxiliar", 141, Gx_line+5, 187, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("C.Costos", 79, Gx_line+5, 130, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cuenta", 10, Gx_line+5, 53, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber ME", 1020, Gx_line+5, 1076, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Debe ME", 956, Gx_line+5, 1007, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber MN", 872, Gx_line+5, 929, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Debe MN", 794, Gx_line+5, 846, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 479, Gx_line+5, 514, Gx_line+19, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+26);
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
         AV84Logo_GXI = "";
         AV72FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV71cMes = "";
         AV13Titulo = "";
         AV14Periodo = "";
         scmdbuf = "";
         A91CueCod = "";
         A133CueCodAux = "";
         A135VouDFec = DateTime.MinValue;
         P00AW2_A133CueCodAux = new string[] {""} ;
         P00AW2_A91CueCod = new string[] {""} ;
         P00AW2_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00AW2_A860CueDsc = new string[] {""} ;
         P00AW2_A70TipACod = new int[1] ;
         P00AW2_n70TipACod = new bool[] {false} ;
         P00AW2_A127VouAno = new short[1] ;
         P00AW2_A128VouMes = new short[1] ;
         P00AW2_A126TASICod = new int[1] ;
         P00AW2_A129VouNum = new string[] {""} ;
         P00AW2_A130VouDSec = new int[1] ;
         A860CueDsc = "";
         A129VouNum = "";
         AV25CueCod = "";
         AV41CueDsc = "";
         GXt_char1 = "";
         P00AW3_A134CueAuxCod = new string[] {""} ;
         P00AW3_A133CueCodAux = new string[] {""} ;
         P00AW3_A91CueCod = new string[] {""} ;
         P00AW3_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00AW3_A127VouAno = new short[1] ;
         P00AW3_A128VouMes = new short[1] ;
         P00AW3_A126TASICod = new int[1] ;
         P00AW3_A129VouNum = new string[] {""} ;
         P00AW3_A130VouDSec = new int[1] ;
         A134CueAuxCod = "";
         AV58CueDAxu = "";
         AV60CueDAxuDsc = "";
         P00AW4_A71TipADCod = new string[] {""} ;
         P00AW4_A70TipACod = new int[1] ;
         P00AW4_n70TipACod = new bool[] {false} ;
         P00AW4_A72TipADDsc = new string[] {""} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         A79COSCod = "";
         P00AW5_A127VouAno = new short[1] ;
         P00AW5_A128VouMes = new short[1] ;
         P00AW5_A126TASICod = new int[1] ;
         P00AW5_A2077VouSts = new short[1] ;
         P00AW5_A79COSCod = new string[] {""} ;
         P00AW5_n79COSCod = new bool[] {false} ;
         P00AW5_A91CueCod = new string[] {""} ;
         P00AW5_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00AW5_A2069VouDTcmb = new decimal[1] ;
         P00AW5_A2075VouGls = new string[] {""} ;
         P00AW5_A2054VouDGls = new string[] {""} ;
         P00AW5_A131VouDMon = new int[1] ;
         P00AW5_A2052VouDDebO = new decimal[1] ;
         P00AW5_A2056VouDHabO = new decimal[1] ;
         P00AW5_A136VouReg = new string[] {""} ;
         P00AW5_A2053VouDDoc = new string[] {""} ;
         P00AW5_A129VouNum = new string[] {""} ;
         P00AW5_A1894TASIAbr = new string[] {""} ;
         P00AW5_A133CueCodAux = new string[] {""} ;
         P00AW5_A2055VouDHab = new decimal[1] ;
         P00AW5_A2051VouDDeb = new decimal[1] ;
         P00AW5_A130VouDSec = new int[1] ;
         A2075VouGls = "";
         A2054VouDGls = "";
         A136VouReg = "";
         A2053VouDDoc = "";
         A1894TASIAbr = "";
         AV68Glosa = "";
         P00AW6_A127VouAno = new short[1] ;
         P00AW6_A128VouMes = new short[1] ;
         P00AW6_A126TASICod = new int[1] ;
         P00AW6_A2077VouSts = new short[1] ;
         P00AW6_A79COSCod = new string[] {""} ;
         P00AW6_n79COSCod = new bool[] {false} ;
         P00AW6_A133CueCodAux = new string[] {""} ;
         P00AW6_A91CueCod = new string[] {""} ;
         P00AW6_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00AW6_A2069VouDTcmb = new decimal[1] ;
         P00AW6_A2075VouGls = new string[] {""} ;
         P00AW6_A2054VouDGls = new string[] {""} ;
         P00AW6_A131VouDMon = new int[1] ;
         P00AW6_A2052VouDDebO = new decimal[1] ;
         P00AW6_A2056VouDHabO = new decimal[1] ;
         P00AW6_A136VouReg = new string[] {""} ;
         P00AW6_A2053VouDDoc = new string[] {""} ;
         P00AW6_A129VouNum = new string[] {""} ;
         P00AW6_A1894TASIAbr = new string[] {""} ;
         P00AW6_A2055VouDHab = new decimal[1] ;
         P00AW6_A2051VouDDeb = new decimal[1] ;
         P00AW6_A130VouDSec = new int[1] ;
         P00AW7_A127VouAno = new short[1] ;
         P00AW7_A128VouMes = new short[1] ;
         P00AW7_A126TASICod = new int[1] ;
         P00AW7_A129VouNum = new string[] {""} ;
         P00AW7_A79COSCod = new string[] {""} ;
         P00AW7_n79COSCod = new bool[] {false} ;
         P00AW7_A2077VouSts = new short[1] ;
         P00AW7_A91CueCod = new string[] {""} ;
         P00AW7_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00AW7_A2069VouDTcmb = new decimal[1] ;
         P00AW7_A130VouDSec = new int[1] ;
         P00AW8_A127VouAno = new short[1] ;
         P00AW8_A128VouMes = new short[1] ;
         P00AW8_A126TASICod = new int[1] ;
         P00AW8_A129VouNum = new string[] {""} ;
         P00AW8_A2077VouSts = new short[1] ;
         P00AW8_A79COSCod = new string[] {""} ;
         P00AW8_n79COSCod = new bool[] {false} ;
         P00AW8_A133CueCodAux = new string[] {""} ;
         P00AW8_A91CueCod = new string[] {""} ;
         P00AW8_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00AW8_A2069VouDTcmb = new decimal[1] ;
         P00AW8_A130VouDSec = new int[1] ;
         AV74Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_saldoscontablespdf__default(),
            new Object[][] {
                new Object[] {
               P00AW2_A133CueCodAux, P00AW2_A91CueCod, P00AW2_A135VouDFec, P00AW2_A860CueDsc, P00AW2_A70TipACod, P00AW2_n70TipACod, P00AW2_A127VouAno, P00AW2_A128VouMes, P00AW2_A126TASICod, P00AW2_A129VouNum,
               P00AW2_A130VouDSec
               }
               , new Object[] {
               P00AW3_A134CueAuxCod, P00AW3_A133CueCodAux, P00AW3_A91CueCod, P00AW3_A135VouDFec, P00AW3_A127VouAno, P00AW3_A128VouMes, P00AW3_A126TASICod, P00AW3_A129VouNum, P00AW3_A130VouDSec
               }
               , new Object[] {
               P00AW4_A71TipADCod, P00AW4_A70TipACod, P00AW4_A72TipADDsc
               }
               , new Object[] {
               P00AW5_A127VouAno, P00AW5_A128VouMes, P00AW5_A126TASICod, P00AW5_A2077VouSts, P00AW5_A79COSCod, P00AW5_n79COSCod, P00AW5_A91CueCod, P00AW5_A135VouDFec, P00AW5_A2069VouDTcmb, P00AW5_A2075VouGls,
               P00AW5_A2054VouDGls, P00AW5_A131VouDMon, P00AW5_A2052VouDDebO, P00AW5_A2056VouDHabO, P00AW5_A136VouReg, P00AW5_A2053VouDDoc, P00AW5_A129VouNum, P00AW5_A1894TASIAbr, P00AW5_A133CueCodAux, P00AW5_A2055VouDHab,
               P00AW5_A2051VouDDeb, P00AW5_A130VouDSec
               }
               , new Object[] {
               P00AW6_A127VouAno, P00AW6_A128VouMes, P00AW6_A126TASICod, P00AW6_A2077VouSts, P00AW6_A79COSCod, P00AW6_n79COSCod, P00AW6_A133CueCodAux, P00AW6_A91CueCod, P00AW6_A135VouDFec, P00AW6_A2069VouDTcmb,
               P00AW6_A2075VouGls, P00AW6_A2054VouDGls, P00AW6_A131VouDMon, P00AW6_A2052VouDDebO, P00AW6_A2056VouDHabO, P00AW6_A136VouReg, P00AW6_A2053VouDDoc, P00AW6_A129VouNum, P00AW6_A1894TASIAbr, P00AW6_A2055VouDHab,
               P00AW6_A2051VouDDeb, P00AW6_A130VouDSec
               }
               , new Object[] {
               P00AW7_A127VouAno, P00AW7_A128VouMes, P00AW7_A126TASICod, P00AW7_A129VouNum, P00AW7_A79COSCod, P00AW7_n79COSCod, P00AW7_A2077VouSts, P00AW7_A91CueCod, P00AW7_A135VouDFec, P00AW7_A2069VouDTcmb,
               P00AW7_A130VouDSec
               }
               , new Object[] {
               P00AW8_A127VouAno, P00AW8_A128VouMes, P00AW8_A126TASICod, P00AW8_A129VouNum, P00AW8_A2077VouSts, P00AW8_A79COSCod, P00AW8_n79COSCod, P00AW8_A133CueCodAux, P00AW8_A91CueCod, P00AW8_A135VouDFec,
               P00AW8_A2069VouDTcmb, P00AW8_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV12Mes ;
      private short AV11Ano ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short AV49Flag ;
      private short AV59Flag1 ;
      private short AV90GXLvl213 ;
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
      private decimal AV22TDebe ;
      private decimal AV23THaber ;
      private decimal AV45TDebeE ;
      private decimal AV46THaberE ;
      private decimal AV69SaldoMN ;
      private decimal AV70SaldoME ;
      private decimal AV54SaldoDAMN ;
      private decimal AV55SaldoHAMN ;
      private decimal AV56SaldoDAME ;
      private decimal AV57SaldoHAME ;
      private decimal AV61TotalSDMN ;
      private decimal AV62TotalSHMN ;
      private decimal AV63TotalSDME ;
      private decimal AV64TotalSHME ;
      private decimal AV66DifMN ;
      private decimal AV67DifME ;
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
      private string AV33cCosto ;
      private string AV77CueCodAux ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV73EmpRUC ;
      private string AV75Ruta ;
      private string AV72FechaC ;
      private string AV71cMes ;
      private string AV13Titulo ;
      private string AV14Periodo ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A133CueCodAux ;
      private string A860CueDsc ;
      private string A129VouNum ;
      private string AV25CueCod ;
      private string AV41CueDsc ;
      private string GXt_char1 ;
      private string A134CueAuxCod ;
      private string AV58CueDAxu ;
      private string AV60CueDAxuDsc ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string A79COSCod ;
      private string A2075VouGls ;
      private string A2054VouDGls ;
      private string A136VouReg ;
      private string A2053VouDDoc ;
      private string A1894TASIAbr ;
      private string AV68Glosa ;
      private string sImgUrl ;
      private DateTime AV17FDesde ;
      private DateTime AV18Fhasta ;
      private DateTime AV16FechaD ;
      private DateTime A135VouDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKAW3 ;
      private bool n70TipACod ;
      private bool returnInSub ;
      private bool BRKAW5 ;
      private bool n79COSCod ;
      private string AV84Logo_GXI ;
      private string AV74Logo ;
      private string Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FDesde ;
      private DateTime aP1_Fhasta ;
      private string aP2_cCuenta1 ;
      private string aP3_cCuenta2 ;
      private string aP4_cCosto ;
      private string aP5_CueCodAux ;
      private IDataStoreProvider pr_default ;
      private string[] P00AW2_A133CueCodAux ;
      private string[] P00AW2_A91CueCod ;
      private DateTime[] P00AW2_A135VouDFec ;
      private string[] P00AW2_A860CueDsc ;
      private int[] P00AW2_A70TipACod ;
      private bool[] P00AW2_n70TipACod ;
      private short[] P00AW2_A127VouAno ;
      private short[] P00AW2_A128VouMes ;
      private int[] P00AW2_A126TASICod ;
      private string[] P00AW2_A129VouNum ;
      private int[] P00AW2_A130VouDSec ;
      private string[] P00AW3_A134CueAuxCod ;
      private string[] P00AW3_A133CueCodAux ;
      private string[] P00AW3_A91CueCod ;
      private DateTime[] P00AW3_A135VouDFec ;
      private short[] P00AW3_A127VouAno ;
      private short[] P00AW3_A128VouMes ;
      private int[] P00AW3_A126TASICod ;
      private string[] P00AW3_A129VouNum ;
      private int[] P00AW3_A130VouDSec ;
      private string[] P00AW4_A71TipADCod ;
      private int[] P00AW4_A70TipACod ;
      private bool[] P00AW4_n70TipACod ;
      private string[] P00AW4_A72TipADDsc ;
      private short[] P00AW5_A127VouAno ;
      private short[] P00AW5_A128VouMes ;
      private int[] P00AW5_A126TASICod ;
      private short[] P00AW5_A2077VouSts ;
      private string[] P00AW5_A79COSCod ;
      private bool[] P00AW5_n79COSCod ;
      private string[] P00AW5_A91CueCod ;
      private DateTime[] P00AW5_A135VouDFec ;
      private decimal[] P00AW5_A2069VouDTcmb ;
      private string[] P00AW5_A2075VouGls ;
      private string[] P00AW5_A2054VouDGls ;
      private int[] P00AW5_A131VouDMon ;
      private decimal[] P00AW5_A2052VouDDebO ;
      private decimal[] P00AW5_A2056VouDHabO ;
      private string[] P00AW5_A136VouReg ;
      private string[] P00AW5_A2053VouDDoc ;
      private string[] P00AW5_A129VouNum ;
      private string[] P00AW5_A1894TASIAbr ;
      private string[] P00AW5_A133CueCodAux ;
      private decimal[] P00AW5_A2055VouDHab ;
      private decimal[] P00AW5_A2051VouDDeb ;
      private int[] P00AW5_A130VouDSec ;
      private short[] P00AW6_A127VouAno ;
      private short[] P00AW6_A128VouMes ;
      private int[] P00AW6_A126TASICod ;
      private short[] P00AW6_A2077VouSts ;
      private string[] P00AW6_A79COSCod ;
      private bool[] P00AW6_n79COSCod ;
      private string[] P00AW6_A133CueCodAux ;
      private string[] P00AW6_A91CueCod ;
      private DateTime[] P00AW6_A135VouDFec ;
      private decimal[] P00AW6_A2069VouDTcmb ;
      private string[] P00AW6_A2075VouGls ;
      private string[] P00AW6_A2054VouDGls ;
      private int[] P00AW6_A131VouDMon ;
      private decimal[] P00AW6_A2052VouDDebO ;
      private decimal[] P00AW6_A2056VouDHabO ;
      private string[] P00AW6_A136VouReg ;
      private string[] P00AW6_A2053VouDDoc ;
      private string[] P00AW6_A129VouNum ;
      private string[] P00AW6_A1894TASIAbr ;
      private decimal[] P00AW6_A2055VouDHab ;
      private decimal[] P00AW6_A2051VouDDeb ;
      private int[] P00AW6_A130VouDSec ;
      private short[] P00AW7_A127VouAno ;
      private short[] P00AW7_A128VouMes ;
      private int[] P00AW7_A126TASICod ;
      private string[] P00AW7_A129VouNum ;
      private string[] P00AW7_A79COSCod ;
      private bool[] P00AW7_n79COSCod ;
      private short[] P00AW7_A2077VouSts ;
      private string[] P00AW7_A91CueCod ;
      private DateTime[] P00AW7_A135VouDFec ;
      private decimal[] P00AW7_A2069VouDTcmb ;
      private int[] P00AW7_A130VouDSec ;
      private short[] P00AW8_A127VouAno ;
      private short[] P00AW8_A128VouMes ;
      private int[] P00AW8_A126TASICod ;
      private string[] P00AW8_A129VouNum ;
      private short[] P00AW8_A2077VouSts ;
      private string[] P00AW8_A79COSCod ;
      private bool[] P00AW8_n79COSCod ;
      private string[] P00AW8_A133CueCodAux ;
      private string[] P00AW8_A91CueCod ;
      private DateTime[] P00AW8_A135VouDFec ;
      private decimal[] P00AW8_A2069VouDTcmb ;
      private int[] P00AW8_A130VouDSec ;
   }

   public class r_saldoscontablespdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AW2( IGxContext context ,
                                             string AV34cCuenta1 ,
                                             string AV35cCuenta2 ,
                                             string AV77CueCodAux ,
                                             string A91CueCod ,
                                             string A133CueCodAux ,
                                             DateTime A135VouDFec ,
                                             DateTime AV17FDesde ,
                                             DateTime AV18Fhasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouDFec], T2.[CueDsc], T2.[TipACod], T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         AddWhere(sWhereString, "(T1.[VouDFec] >= @AV17FDesde)");
         AddWhere(sWhereString, "(T1.[VouDFec] <= @AV18Fhasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34cCuenta1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] >= @AV34cCuenta1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35cCuenta2)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] <= @AV35cCuenta2)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77CueCodAux)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV77CueCodAux)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00AW3( IGxContext context ,
                                             string AV77CueCodAux ,
                                             string A133CueCodAux ,
                                             DateTime A135VouDFec ,
                                             DateTime AV17FDesde ,
                                             DateTime AV18Fhasta ,
                                             string A91CueCod ,
                                             string AV25CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [CueAuxCod], [CueCodAux], [CueCod], [VouDFec], [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET]";
         AddWhere(sWhereString, "([VouDFec] >= @AV17FDesde)");
         AddWhere(sWhereString, "([VouDFec] <= @AV18Fhasta)");
         AddWhere(sWhereString, "([CueCod] = @AV25CueCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77CueCodAux)) )
         {
            AddWhere(sWhereString, "([CueCodAux] = @AV77CueCodAux)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueCodAux], [CueAuxCod]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00AW5( IGxContext context ,
                                             string AV33cCosto ,
                                             string A79COSCod ,
                                             short A2077VouSts ,
                                             string AV25CueCod ,
                                             DateTime AV17FDesde ,
                                             string A91CueCod ,
                                             DateTime A135VouDFec ,
                                             DateTime AV18Fhasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[4];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T3.[VouSts], T1.[COSCod], T1.[CueCod], T1.[VouDFec], T1.[VouDTcmb], T3.[VouGls], T1.[VouDGls], T1.[VouDMon], T1.[VouDDebO], T1.[VouDHabO], T1.[VouReg], T1.[VouDDoc], T1.[VouNum], T2.[TASIAbr], T1.[CueCodAux], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV25CueCod and T1.[VouDFec] >= @AV17FDesde)");
         AddWhere(sWhereString, "(T3.[VouSts] = 1)");
         AddWhere(sWhereString, "(T1.[VouDFec] <= @AV18Fhasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV33cCosto)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[VouDFec]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00AW6( IGxContext context ,
                                             string AV33cCosto ,
                                             string A79COSCod ,
                                             string A133CueCodAux ,
                                             string AV58CueDAxu ,
                                             short A2077VouSts ,
                                             string AV25CueCod ,
                                             DateTime AV17FDesde ,
                                             string A91CueCod ,
                                             DateTime A135VouDFec ,
                                             DateTime AV18Fhasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[5];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T3.[VouSts], T1.[COSCod], T1.[CueCodAux], T1.[CueCod], T1.[VouDFec], T1.[VouDTcmb], T3.[VouGls], T1.[VouDGls], T1.[VouDMon], T1.[VouDDebO], T1.[VouDHabO], T1.[VouReg], T1.[VouDDoc], T1.[VouNum], T2.[TASIAbr], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV25CueCod and T1.[VouDFec] >= @AV17FDesde)");
         AddWhere(sWhereString, "(T1.[CueCodAux] = @AV58CueDAxu)");
         AddWhere(sWhereString, "(T3.[VouSts] = 1)");
         AddWhere(sWhereString, "(T1.[VouDFec] <= @AV18Fhasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV33cCosto)");
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

      protected Object[] conditional_P00AW7( IGxContext context ,
                                             string AV33cCosto ,
                                             string A79COSCod ,
                                             DateTime A135VouDFec ,
                                             DateTime AV17FDesde ,
                                             DateTime AV18Fhasta ,
                                             short A2077VouSts ,
                                             string AV25CueCod ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[4];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[COSCod], T2.[VouSts], T1.[CueCod], T1.[VouDFec], T1.[VouDTcmb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV25CueCod)");
         AddWhere(sWhereString, "(T1.[VouDFec] >= @AV17FDesde)");
         AddWhere(sWhereString, "(T1.[VouDFec] <= @AV18Fhasta)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV33cCosto)");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P00AW8( IGxContext context ,
                                             string AV33cCosto ,
                                             string A79COSCod ,
                                             DateTime A135VouDFec ,
                                             DateTime AV17FDesde ,
                                             DateTime AV18Fhasta ,
                                             short A2077VouSts ,
                                             string AV25CueCod ,
                                             string AV58CueDAxu ,
                                             string A91CueCod ,
                                             string A133CueCodAux )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[5];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[COSCod], T1.[CueCodAux], T1.[CueCod], T1.[VouDFec], T1.[VouDTcmb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV25CueCod and T1.[CueCodAux] = @AV58CueDAxu)");
         AddWhere(sWhereString, "(T1.[VouDFec] >= @AV17FDesde)");
         AddWhere(sWhereString, "(T1.[VouDFec] <= @AV18Fhasta)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV33cCosto)");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux]";
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
               case 0 :
                     return conditional_P00AW2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] );
               case 1 :
                     return conditional_P00AW3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
               case 3 :
                     return conditional_P00AW5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] );
               case 4 :
                     return conditional_P00AW6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] );
               case 5 :
                     return conditional_P00AW7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] );
               case 6 :
                     return conditional_P00AW8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AW4;
          prmP00AW4 = new Object[] {
          new ParDef("@AV76TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV58CueDAxu",GXType.NChar,20,0)
          };
          Object[] prmP00AW2;
          prmP00AW2 = new Object[] {
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV18Fhasta",GXType.Date,8,0) ,
          new ParDef("@AV34cCuenta1",GXType.Char,15,0) ,
          new ParDef("@AV35cCuenta2",GXType.Char,15,0) ,
          new ParDef("@AV77CueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00AW3;
          prmP00AW3 = new Object[] {
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV18Fhasta",GXType.Date,8,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV77CueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00AW5;
          prmP00AW5 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV18Fhasta",GXType.Date,8,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00AW6;
          prmP00AW6 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV58CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV18Fhasta",GXType.Date,8,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00AW7;
          prmP00AW7 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV18Fhasta",GXType.Date,8,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00AW8;
          prmP00AW8 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV58CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV18Fhasta",GXType.Date,8,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AW2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AW2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AW3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AW3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AW4", "SELECT [TipADCod], [TipACod], [TipADDsc] FROM [CBAUXILIARES] WHERE [TipACod] = @AV76TipACod and [TipADCod] = @AV58CueDAxu ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AW4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AW5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AW5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AW6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AW6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AW7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AW7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AW8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AW8,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 10);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 15);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((string[]) buf[14])[0] = rslt.getString(14, 15);
                ((string[]) buf[15])[0] = rslt.getString(15, 20);
                ((string[]) buf[16])[0] = rslt.getString(16, 10);
                ((string[]) buf[17])[0] = rslt.getString(17, 5);
                ((string[]) buf[18])[0] = rslt.getString(18, 20);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(20);
                ((int[]) buf[21])[0] = rslt.getInt(21);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getString(7, 15);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 100);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 15);
                ((string[]) buf[16])[0] = rslt.getString(16, 20);
                ((string[]) buf[17])[0] = rslt.getString(17, 10);
                ((string[]) buf[18])[0] = rslt.getString(18, 5);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(20);
                ((int[]) buf[21])[0] = rslt.getInt(21);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 15);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((string[]) buf[8])[0] = rslt.getString(8, 15);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                return;
       }
    }

 }

}
