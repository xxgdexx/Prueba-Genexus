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
   public class r_resumenbancovsflujopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_resumenbancovsflujopdf.aspx")), "contabilidad.r_resumenbancovsflujopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_resumenbancovsflujopdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "BanCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV14BanCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV35FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV36FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV53LBCBCod = GetPar( "LBCBCod");
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

      public r_resumenbancovsflujopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenbancovsflujopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_BanCod ,
                           ref DateTime aP1_FDesde ,
                           ref DateTime aP2_FHasta ,
                           ref string aP3_LBCBCod )
      {
         this.AV14BanCod = aP0_BanCod;
         this.AV35FDesde = aP1_FDesde;
         this.AV36FHasta = aP2_FHasta;
         this.AV53LBCBCod = aP3_LBCBCod;
         initialize();
         executePrivate();
         aP0_BanCod=this.AV14BanCod;
         aP1_FDesde=this.AV35FDesde;
         aP2_FHasta=this.AV36FHasta;
         aP3_LBCBCod=this.AV53LBCBCod;
      }

      public string executeUdp( ref int aP0_BanCod ,
                                ref DateTime aP1_FDesde ,
                                ref DateTime aP2_FHasta )
      {
         execute(ref aP0_BanCod, ref aP1_FDesde, ref aP2_FHasta, ref aP3_LBCBCod);
         return AV53LBCBCod ;
      }

      public void executeSubmit( ref int aP0_BanCod ,
                                 ref DateTime aP1_FDesde ,
                                 ref DateTime aP2_FHasta ,
                                 ref string aP3_LBCBCod )
      {
         r_resumenbancovsflujopdf objr_resumenbancovsflujopdf;
         objr_resumenbancovsflujopdf = new r_resumenbancovsflujopdf();
         objr_resumenbancovsflujopdf.AV14BanCod = aP0_BanCod;
         objr_resumenbancovsflujopdf.AV35FDesde = aP1_FDesde;
         objr_resumenbancovsflujopdf.AV36FHasta = aP2_FHasta;
         objr_resumenbancovsflujopdf.AV53LBCBCod = aP3_LBCBCod;
         objr_resumenbancovsflujopdf.context.SetSubmitInitialConfig(context);
         objr_resumenbancovsflujopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenbancovsflujopdf);
         aP0_BanCod=this.AV14BanCod;
         aP1_FDesde=this.AV35FDesde;
         aP2_FHasta=this.AV36FHasta;
         aP3_LBCBCod=this.AV53LBCBCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenbancovsflujopdf)stateInfo).executePrivate();
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
            AV29Empresa = AV34Session.Get("Empresa");
            AV30EmpDir = AV34Session.Get("EmpDir");
            AV31EmpRUC = AV34Session.Get("EmpRUC");
            AV32Ruta = AV34Session.Get("RUTA") + "/Logo.jpg";
            AV33Logo = AV32Ruta;
            AV56Logo_GXI = GXDbFile.PathToUrl( AV32Ruta);
            AV22FechaCHR = "01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV17LBMes), 10, 0)) + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16LBAno), 10, 0));
            AV21Fecha = context.localUtil.CToD( AV22FechaCHR, 2);
            GXt_char1 = AV24CMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV17LBMes, out  GXt_char1) ;
            AV24CMes = GXt_char1;
            AV8BanDsc = "";
            AV9CTBco = "";
            AV10Debe = 0.00m;
            AV11Haber = 0.00m;
            AV12Saldo = AV13SaldoIni;
            AV18TDebe = 0.00m;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14BanCod ,
                                                 AV53LBCBCod ,
                                                 A379LBBanCod ,
                                                 A380LBCBCod ,
                                                 A1079LBFech ,
                                                 AV35FDesde ,
                                                 AV36FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00D02 */
            pr_default.execute(0, new Object[] {AV35FDesde, AV36FHasta, AV14BanCod, AV53LBCBCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1085LBMonCod = P00D02_A1085LBMonCod[0];
               A1079LBFech = P00D02_A1079LBFech[0];
               n1079LBFech = P00D02_n1079LBFech[0];
               A380LBCBCod = P00D02_A380LBCBCod[0];
               A379LBBanCod = P00D02_A379LBBanCod[0];
               A1053LBBanAbr = P00D02_A1053LBBanAbr[0];
               A1233MonAbr = P00D02_A1233MonAbr[0];
               n1233MonAbr = P00D02_n1233MonAbr[0];
               A1057LBConcepto = P00D02_A1057LBConcepto[0];
               A1054LBBeneficia = P00D02_A1054LBBeneficia[0];
               A1075LBDocumento = P00D02_A1075LBDocumento[0];
               A381LBRegistro = P00D02_A381LBRegistro[0];
               A1073LBTHaber = P00D02_A1073LBTHaber[0];
               A1072LBTDebe = P00D02_A1072LBTDebe[0];
               A1070LBTipo = P00D02_A1070LBTipo[0];
               A1053LBBanAbr = P00D02_A1053LBBanAbr[0];
               A1085LBMonCod = P00D02_A1085LBMonCod[0];
               A1233MonAbr = P00D02_A1233MonAbr[0];
               n1233MonAbr = P00D02_n1233MonAbr[0];
               A1071LBTSaldo = (((A1072LBTDebe-A1073LBTHaber)<Convert.ToDecimal(0)) ? (A1072LBTDebe-A1073LBTHaber)*-1 : (((A1073LBTHaber-A1072LBTDebe)<Convert.ToDecimal(0)) ? (A1073LBTHaber-A1072LBTDebe)*-1 : A1072LBTDebe-A1073LBTHaber));
               A1082LBHaberTot = ((A1070LBTipo==0) ? A1071LBTSaldo : (decimal)(0));
               A1069LBDebeTot = ((A1070LBTipo==1) ? A1071LBTSaldo : (decimal)(0));
               AV44LBBanCod = A379LBBanCod;
               AV38BanAbr = StringUtil.Trim( A1053LBBanAbr);
               AV43MonAbr = StringUtil.Trim( A1233MonAbr);
               AV52LBRegistro = A381LBRegistro;
               AV9CTBco = A380LBCBCod;
               AV10Debe = A1069LBDebeTot;
               AV11Haber = A1082LBHaberTot;
               AV23Mov = (decimal)(AV10Debe-AV11Haber);
               AV46Mov2 = ((AV23Mov<Convert.ToDecimal(0)) ? AV23Mov*-1 : AV23Mov);
               AV12Saldo = (decimal)(AV12Saldo+AV23Mov);
               AV39LBConcepto = StringUtil.Trim( A1057LBConcepto);
               AV26LBBeneficia = StringUtil.Trim( A1054LBBeneficia);
               /* Execute user subroutine: 'IMPORTE' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               AV47Dif = (decimal)(AV46Mov2-AV45Total);
               AV48TDif = (decimal)(AV48TDif+AV47Dif);
               AV49TTotal = (decimal)(AV49TTotal+AV45Total);
               HD00( false, 20) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV10Debe, "ZZZZZZ,ZZZ,ZZ9.99")), 646, Gx_line+4, 736, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV11Haber, "ZZZZZZ,ZZZ,ZZ9.99")), 724, Gx_line+4, 814, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A381LBRegistro, "")), 139, Gx_line+2, 199, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A1079LBFech, "99/99/99"), 266, Gx_line+2, 309, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39LBConcepto, "")), 310, Gx_line+2, 495, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1075LBDocumento, "")), 200, Gx_line+1, 263, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9CTBco, "")), 42, Gx_line+3, 137, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38BanAbr, "")), 2, Gx_line+3, 41, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43MonAbr, "")), 633, Gx_line+2, 658, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26LBBeneficia, "")), 501, Gx_line+2, 628, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45Total, "ZZZZZZ,ZZZ,ZZ9.99")), 829, Gx_line+4, 919, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47Dif, "ZZZZZZ,ZZZ,ZZ9.99")), 930, Gx_line+4, 1020, Gx_line+17, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               AV18TDebe = (decimal)(AV18TDebe+AV10Debe);
               AV19THaber = (decimal)(AV19THaber+AV11Haber);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            HD00( false, 31) ;
            getPrinter().GxDrawLine(607, Gx_line+2, 1032, Gx_line+2, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18TDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 610, Gx_line+7, 734, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19THaber, "ZZZZZZ,ZZZ,ZZ9.99")), 689, Gx_line+7, 813, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49TTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 811, Gx_line+7, 918, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48TDif, "ZZZZZZ,ZZZ,ZZ9.99")), 913, Gx_line+7, 1020, Gx_line+22, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+31);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HD00( true, 0) ;
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
         /* 'IMPORTE' Routine */
         returnInSub = false;
         AV45Total = 0.00m;
         /* Using cursor P00D03 */
         pr_default.execute(1, new Object[] {AV44LBBanCod, AV9CTBco, AV52LBRegistro});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A2267CBFlujCRegistro = P00D03_A2267CBFlujCRegistro[0];
            A2266CBFlujCCuenta = P00D03_A2266CBFlujCCuenta[0];
            A2265CBFlujCBanCod = P00D03_A2265CBFlujCBanCod[0];
            A1079LBFech = P00D03_A1079LBFech[0];
            n1079LBFech = P00D03_n1079LBFech[0];
            A2272CBFlujCMonCod = P00D03_A2272CBFlujCMonCod[0];
            A2275CBFlujCCosto = P00D03_A2275CBFlujCCosto[0];
            A2263CBFlujCAno = P00D03_A2263CBFlujCAno[0];
            A2264CBFlujCMes = P00D03_A2264CBFlujCMes[0];
            A2268CBFlujCItem = P00D03_A2268CBFlujCItem[0];
            A1079LBFech = P00D03_A1079LBFech[0];
            n1079LBFech = P00D03_n1079LBFech[0];
            A2272CBFlujCMonCod = P00D03_A2272CBFlujCMonCod[0];
            AV50LBFech = A1079LBFech;
            AV28MonCod = A2272CBFlujCMonCod;
            AV51Importe = A2275CBFlujCCosto;
            AV45Total = (decimal)(AV45Total+AV51Importe);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void HD00( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Bancos vs Flujo de Caja", 395, Gx_line+20, 704, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+109, 1032, Gx_line+143, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Registro", 135, Gx_line+120, 203, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Doc.", 208, Gx_line+120, 251, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 270, Gx_line+120, 305, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Concepto", 311, Gx_line+120, 367, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Debe", 690, Gx_line+120, 721, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber", 763, Gx_line+120, 799, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hora:", 935, Gx_line+32, 967, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 935, Gx_line+50, 979, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 935, Gx_line+15, 974, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 978, Gx_line+14, 1025, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 941, Gx_line+31, 1025, Gx_line+46, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 986, Gx_line+49, 1025, Gx_line+64, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde :", 408, Gx_line+51, 456, Gx_line+66, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta :", 542, Gx_line+51, 588, Gx_line+66, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV36FHasta, "99/99/99"), 589, Gx_line+51, 644, Gx_line+67, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV35FDesde, "99/99/99"), 459, Gx_line+51, 514, Gx_line+67, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV33Logo)) ? AV56Logo_GXI : AV33Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 19, Gx_line+3, 174, Gx_line+71) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31EmpRUC, "")), 19, Gx_line+90, 390, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Empresa, "")), 19, Gx_line+72, 387, Gx_line+90, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Banco", 6, Gx_line+120, 42, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cuenta", 48, Gx_line+120, 91, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Auxiliar", 504, Gx_line+120, 550, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(824, Gx_line+110, 824, Gx_line+143, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(928, Gx_line+109, 928, Gx_line+142, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(667, Gx_line+110, 667, Gx_line+143, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Flujo de Caja", 841, Gx_line+120, 917, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Diferencia", 941, Gx_line+120, 1001, Gx_line+134, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+144);
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
         AV29Empresa = "";
         AV34Session = context.GetSession();
         AV30EmpDir = "";
         AV31EmpRUC = "";
         AV32Ruta = "";
         AV33Logo = "";
         AV56Logo_GXI = "";
         AV22FechaCHR = "";
         AV21Fecha = DateTime.MinValue;
         AV24CMes = "";
         GXt_char1 = "";
         AV8BanDsc = "";
         AV9CTBco = "";
         scmdbuf = "";
         A380LBCBCod = "";
         A1079LBFech = DateTime.MinValue;
         P00D02_A1085LBMonCod = new int[1] ;
         P00D02_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P00D02_n1079LBFech = new bool[] {false} ;
         P00D02_A380LBCBCod = new string[] {""} ;
         P00D02_A379LBBanCod = new int[1] ;
         P00D02_A1053LBBanAbr = new string[] {""} ;
         P00D02_A1233MonAbr = new string[] {""} ;
         P00D02_n1233MonAbr = new bool[] {false} ;
         P00D02_A1057LBConcepto = new string[] {""} ;
         P00D02_A1054LBBeneficia = new string[] {""} ;
         P00D02_A1075LBDocumento = new string[] {""} ;
         P00D02_A381LBRegistro = new string[] {""} ;
         P00D02_A1073LBTHaber = new decimal[1] ;
         P00D02_A1072LBTDebe = new decimal[1] ;
         P00D02_A1070LBTipo = new short[1] ;
         A1053LBBanAbr = "";
         A1233MonAbr = "";
         A1057LBConcepto = "";
         A1054LBBeneficia = "";
         A1075LBDocumento = "";
         A381LBRegistro = "";
         AV38BanAbr = "";
         AV43MonAbr = "";
         AV52LBRegistro = "";
         AV39LBConcepto = "";
         AV26LBBeneficia = "";
         P00D03_A2267CBFlujCRegistro = new string[] {""} ;
         P00D03_A2266CBFlujCCuenta = new string[] {""} ;
         P00D03_A2265CBFlujCBanCod = new int[1] ;
         P00D03_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P00D03_n1079LBFech = new bool[] {false} ;
         P00D03_A2272CBFlujCMonCod = new int[1] ;
         P00D03_A2275CBFlujCCosto = new decimal[1] ;
         P00D03_A2263CBFlujCAno = new short[1] ;
         P00D03_A2264CBFlujCMes = new short[1] ;
         P00D03_A2268CBFlujCItem = new int[1] ;
         A2267CBFlujCRegistro = "";
         A2266CBFlujCCuenta = "";
         AV50LBFech = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV33Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_resumenbancovsflujopdf__default(),
            new Object[][] {
                new Object[] {
               P00D02_A1085LBMonCod, P00D02_A1079LBFech, P00D02_A380LBCBCod, P00D02_A379LBBanCod, P00D02_A1053LBBanAbr, P00D02_A1233MonAbr, P00D02_n1233MonAbr, P00D02_A1057LBConcepto, P00D02_A1054LBBeneficia, P00D02_A1075LBDocumento,
               P00D02_A381LBRegistro, P00D02_A1073LBTHaber, P00D02_A1072LBTDebe, P00D02_A1070LBTipo
               }
               , new Object[] {
               P00D03_A2267CBFlujCRegistro, P00D03_A2266CBFlujCCuenta, P00D03_A2265CBFlujCBanCod, P00D03_A1079LBFech, P00D03_n1079LBFech, P00D03_A2272CBFlujCMonCod, P00D03_A2275CBFlujCCosto, P00D03_A2263CBFlujCAno, P00D03_A2264CBFlujCMes, P00D03_A2268CBFlujCItem
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
      private short AV17LBMes ;
      private short AV16LBAno ;
      private short A1070LBTipo ;
      private short A2263CBFlujCAno ;
      private short A2264CBFlujCMes ;
      private int AV14BanCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A379LBBanCod ;
      private int A1085LBMonCod ;
      private int AV44LBBanCod ;
      private int Gx_OldLine ;
      private int A2265CBFlujCBanCod ;
      private int A2272CBFlujCMonCod ;
      private int A2268CBFlujCItem ;
      private int AV28MonCod ;
      private decimal AV10Debe ;
      private decimal AV11Haber ;
      private decimal AV12Saldo ;
      private decimal AV13SaldoIni ;
      private decimal AV18TDebe ;
      private decimal A1073LBTHaber ;
      private decimal A1072LBTDebe ;
      private decimal A1071LBTSaldo ;
      private decimal A1082LBHaberTot ;
      private decimal A1069LBDebeTot ;
      private decimal AV23Mov ;
      private decimal AV46Mov2 ;
      private decimal AV47Dif ;
      private decimal AV45Total ;
      private decimal AV48TDif ;
      private decimal AV49TTotal ;
      private decimal AV19THaber ;
      private decimal A2275CBFlujCCosto ;
      private decimal AV51Importe ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV53LBCBCod ;
      private string AV29Empresa ;
      private string AV30EmpDir ;
      private string AV31EmpRUC ;
      private string AV32Ruta ;
      private string AV22FechaCHR ;
      private string AV24CMes ;
      private string GXt_char1 ;
      private string AV8BanDsc ;
      private string AV9CTBco ;
      private string scmdbuf ;
      private string A380LBCBCod ;
      private string A1053LBBanAbr ;
      private string A1233MonAbr ;
      private string A1057LBConcepto ;
      private string A1054LBBeneficia ;
      private string A1075LBDocumento ;
      private string A381LBRegistro ;
      private string AV38BanAbr ;
      private string AV43MonAbr ;
      private string AV52LBRegistro ;
      private string AV39LBConcepto ;
      private string AV26LBBeneficia ;
      private string A2267CBFlujCRegistro ;
      private string A2266CBFlujCCuenta ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV35FDesde ;
      private DateTime AV36FHasta ;
      private DateTime AV21Fecha ;
      private DateTime A1079LBFech ;
      private DateTime AV50LBFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1079LBFech ;
      private bool n1233MonAbr ;
      private bool returnInSub ;
      private string AV56Logo_GXI ;
      private string AV33Logo ;
      private string Logo ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_BanCod ;
      private DateTime aP1_FDesde ;
      private DateTime aP2_FHasta ;
      private string aP3_LBCBCod ;
      private IDataStoreProvider pr_default ;
      private int[] P00D02_A1085LBMonCod ;
      private DateTime[] P00D02_A1079LBFech ;
      private bool[] P00D02_n1079LBFech ;
      private string[] P00D02_A380LBCBCod ;
      private int[] P00D02_A379LBBanCod ;
      private string[] P00D02_A1053LBBanAbr ;
      private string[] P00D02_A1233MonAbr ;
      private bool[] P00D02_n1233MonAbr ;
      private string[] P00D02_A1057LBConcepto ;
      private string[] P00D02_A1054LBBeneficia ;
      private string[] P00D02_A1075LBDocumento ;
      private string[] P00D02_A381LBRegistro ;
      private decimal[] P00D02_A1073LBTHaber ;
      private decimal[] P00D02_A1072LBTDebe ;
      private short[] P00D02_A1070LBTipo ;
      private string[] P00D03_A2267CBFlujCRegistro ;
      private string[] P00D03_A2266CBFlujCCuenta ;
      private int[] P00D03_A2265CBFlujCBanCod ;
      private DateTime[] P00D03_A1079LBFech ;
      private bool[] P00D03_n1079LBFech ;
      private int[] P00D03_A2272CBFlujCMonCod ;
      private decimal[] P00D03_A2275CBFlujCCosto ;
      private short[] P00D03_A2263CBFlujCAno ;
      private short[] P00D03_A2264CBFlujCMes ;
      private int[] P00D03_A2268CBFlujCItem ;
   }

   public class r_resumenbancovsflujopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00D02( IGxContext context ,
                                             int AV14BanCod ,
                                             string AV53LBCBCod ,
                                             int A379LBBanCod ,
                                             string A380LBCBCod ,
                                             DateTime A1079LBFech ,
                                             DateTime AV35FDesde ,
                                             DateTime AV36FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T3.[MonCod] AS LBMonCod, T1.[LBFech], T1.[LBCBCod] AS LBCBCod, T1.[LBBanCod] AS LBBanCod, T2.[BanAbr] AS LBBanAbr, T4.[MonAbr], T1.[LBConcepto], T1.[LBBeneficia], T1.[LBDocumento], T1.[LBRegistro], T1.[LBTHaber], T1.[LBTDebe], T1.[LBTipo] FROM ((([TSLIBROBANCOS] T1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = T1.[LBBanCod]) INNER JOIN [TSCUENTABANCO] T3 ON T3.[BanCod] = T1.[LBBanCod] AND T3.[CBCod] = T1.[LBCBCod]) INNER JOIN [CMONEDAS] T4 ON T4.[MonCod] = T3.[MonCod])";
         AddWhere(sWhereString, "(T1.[LBFech] >= @AV35FDesde)");
         AddWhere(sWhereString, "(T1.[LBFech] <= @AV36FHasta)");
         if ( ! (0==AV14BanCod) )
         {
            AddWhere(sWhereString, "(T1.[LBBanCod] = @AV14BanCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53LBCBCod)) )
         {
            AddWhere(sWhereString, "(T1.[LBCBCod] = @AV53LBCBCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[LBBanCod], T1.[LBCBCod], T1.[LBRegistro]";
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
                     return conditional_P00D02(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00D03;
          prmP00D03 = new Object[] {
          new ParDef("@AV44LBBanCod",GXType.Int32,6,0) ,
          new ParDef("@AV9CTBco",GXType.NChar,20,0) ,
          new ParDef("@AV52LBRegistro",GXType.NChar,10,0)
          };
          Object[] prmP00D02;
          prmP00D02 = new Object[] {
          new ParDef("@AV35FDesde",GXType.Date,8,0) ,
          new ParDef("@AV36FHasta",GXType.Date,8,0) ,
          new ParDef("@AV14BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV53LBCBCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D02,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D03", "SELECT T1.[CBFlujCRegistro] AS CBFlujCRegistro, T1.[CBFlujCCuenta] AS CBFlujCCuenta, T1.[CBFlujCBanCod] AS CBFlujCBanCod, T2.[LBFech], T3.[MonCod] AS CBFlujCMonCod, T1.[CBFlujCCosto], T1.[CBFlujCAno], T1.[CBFlujCMes], T1.[CBFlujCItem] FROM (([CBFLUJOCONCEPTOSDET] T1 INNER JOIN [TSLIBROBANCOS] T2 ON T2.[LBBanCod] = T1.[CBFlujCBanCod] AND T2.[LBCBCod] = T1.[CBFlujCCuenta] AND T2.[LBRegistro] = T1.[CBFlujCRegistro]) INNER JOIN [TSCUENTABANCO] T3 ON T3.[BanCod] = T1.[CBFlujCBanCod] AND T3.[CBCod] = T1.[CBFlujCCuenta]) WHERE (T1.[CBFlujCBanCod] = @AV44LBBanCod) AND (T1.[CBFlujCCuenta] = @AV9CTBco) AND (T1.[CBFlujCRegistro] = @AV52LBRegistro) ORDER BY T1.[CBFlujCAno], T1.[CBFlujCMes], T1.[CBFlujCBanCod], T1.[CBFlujCCuenta], T1.[CBFlujCRegistro], T1.[CBFlujCItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D03,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 5);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 60);
                ((string[]) buf[8])[0] = rslt.getString(8, 60);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getString(10, 10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
