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
namespace GeneXus.Programs.bancos {
   public class r_reportemovimientobancospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "bancos.r_reportemovimientobancospdf.aspx")), "bancos.r_reportemovimientobancospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "bancos.r_reportemovimientobancospdf.aspx")))) ;
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
                  AV15CBCod = GetPar( "CBCod");
                  AV35FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV36FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV37Tipo = GetPar( "Tipo");
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

      public r_reportemovimientobancospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reportemovimientobancospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_BanCod ,
                           ref string aP1_CBCod ,
                           ref DateTime aP2_FDesde ,
                           ref DateTime aP3_FHasta ,
                           ref string aP4_Tipo )
      {
         this.AV14BanCod = aP0_BanCod;
         this.AV15CBCod = aP1_CBCod;
         this.AV35FDesde = aP2_FDesde;
         this.AV36FHasta = aP3_FHasta;
         this.AV37Tipo = aP4_Tipo;
         initialize();
         executePrivate();
         aP0_BanCod=this.AV14BanCod;
         aP1_CBCod=this.AV15CBCod;
         aP2_FDesde=this.AV35FDesde;
         aP3_FHasta=this.AV36FHasta;
         aP4_Tipo=this.AV37Tipo;
      }

      public string executeUdp( ref int aP0_BanCod ,
                                ref string aP1_CBCod ,
                                ref DateTime aP2_FDesde ,
                                ref DateTime aP3_FHasta )
      {
         execute(ref aP0_BanCod, ref aP1_CBCod, ref aP2_FDesde, ref aP3_FHasta, ref aP4_Tipo);
         return AV37Tipo ;
      }

      public void executeSubmit( ref int aP0_BanCod ,
                                 ref string aP1_CBCod ,
                                 ref DateTime aP2_FDesde ,
                                 ref DateTime aP3_FHasta ,
                                 ref string aP4_Tipo )
      {
         r_reportemovimientobancospdf objr_reportemovimientobancospdf;
         objr_reportemovimientobancospdf = new r_reportemovimientobancospdf();
         objr_reportemovimientobancospdf.AV14BanCod = aP0_BanCod;
         objr_reportemovimientobancospdf.AV15CBCod = aP1_CBCod;
         objr_reportemovimientobancospdf.AV35FDesde = aP2_FDesde;
         objr_reportemovimientobancospdf.AV36FHasta = aP3_FHasta;
         objr_reportemovimientobancospdf.AV37Tipo = aP4_Tipo;
         objr_reportemovimientobancospdf.context.SetSubmitInitialConfig(context);
         objr_reportemovimientobancospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reportemovimientobancospdf);
         aP0_BanCod=this.AV14BanCod;
         aP1_CBCod=this.AV15CBCod;
         aP2_FDesde=this.AV35FDesde;
         aP3_FHasta=this.AV36FHasta;
         aP4_Tipo=this.AV37Tipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reportemovimientobancospdf)stateInfo).executePrivate();
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
            AV49Logo_GXI = GXDbFile.PathToUrl( AV32Ruta);
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
                                                 AV15CBCod ,
                                                 AV37Tipo ,
                                                 A379LBBanCod ,
                                                 A380LBCBCod ,
                                                 A1070LBTipo ,
                                                 A1079LBFech ,
                                                 AV35FDesde ,
                                                 AV36FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P009Y2 */
            pr_default.execute(0, new Object[] {AV35FDesde, AV36FHasta, AV14BanCod, AV15CBCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK9Y3 = false;
               A1085LBMonCod = P009Y2_A1085LBMonCod[0];
               A380LBCBCod = P009Y2_A380LBCBCod[0];
               A379LBBanCod = P009Y2_A379LBBanCod[0];
               A1079LBFech = P009Y2_A1079LBFech[0];
               A1070LBTipo = P009Y2_A1070LBTipo[0];
               A482BanDsc = P009Y2_A482BanDsc[0];
               n482BanDsc = P009Y2_n482BanDsc[0];
               A1234MonDsc = P009Y2_A1234MonDsc[0];
               n1234MonDsc = P009Y2_n1234MonDsc[0];
               A1233MonAbr = P009Y2_A1233MonAbr[0];
               n1233MonAbr = P009Y2_n1233MonAbr[0];
               A381LBRegistro = P009Y2_A381LBRegistro[0];
               A482BanDsc = P009Y2_A482BanDsc[0];
               n482BanDsc = P009Y2_n482BanDsc[0];
               A1085LBMonCod = P009Y2_A1085LBMonCod[0];
               A1234MonDsc = P009Y2_A1234MonDsc[0];
               n1234MonDsc = P009Y2_n1234MonDsc[0];
               A1233MonAbr = P009Y2_A1233MonAbr[0];
               n1233MonAbr = P009Y2_n1233MonAbr[0];
               while ( (pr_default.getStatus(0) != 101) && ( P009Y2_A379LBBanCod[0] == A379LBBanCod ) && ( StringUtil.StrCmp(P009Y2_A380LBCBCod[0], A380LBCBCod) == 0 ) )
               {
                  BRK9Y3 = false;
                  A1085LBMonCod = P009Y2_A1085LBMonCod[0];
                  A381LBRegistro = P009Y2_A381LBRegistro[0];
                  A1085LBMonCod = P009Y2_A1085LBMonCod[0];
                  BRK9Y3 = true;
                  pr_default.readNext(0);
               }
               AV44LBBanCod = A379LBBanCod;
               AV45LBCBCod = A380LBCBCod;
               AV8BanDsc = A482BanDsc;
               AV27MonDsc = StringUtil.Trim( A1234MonDsc);
               AV43MonAbr = StringUtil.Trim( A1233MonAbr);
               AV46Titulo = StringUtil.Trim( A482BanDsc) + "  -  " + StringUtil.Trim( AV27MonDsc) + " - " + StringUtil.Trim( AV45LBCBCod);
               AV18TDebe = 0.00m;
               AV19THaber = 0.00m;
               H9Y0( false, 20) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Titulo, "")), 11, Gx_line+1, 741, Gx_line+19, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               /* Execute user subroutine: 'DETALLE' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               H9Y0( false, 31) ;
               getPrinter().GxDrawLine(817, Gx_line+2, 1014, Gx_line+2, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18TDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 760, Gx_line+8, 884, Gx_line+22, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19THaber, "ZZZZZZ,ZZZ,ZZ9.99")), 886, Gx_line+8, 1010, Gx_line+22, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43MonAbr, "")), 893, Gx_line+8, 946, Gx_line+23, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43MonAbr, "")), 752, Gx_line+8, 805, Gx_line+23, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total .....", 688, Gx_line+8, 738, Gx_line+22, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+31);
               if ( ! BRK9Y3 )
               {
                  BRK9Y3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9Y0( true, 0) ;
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV37Tipo ,
                                              A1070LBTipo ,
                                              A379LBBanCod ,
                                              AV44LBBanCod ,
                                              A380LBCBCod ,
                                              AV45LBCBCod ,
                                              AV35FDesde ,
                                              A1079LBFech ,
                                              AV36FHasta } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P009Y3 */
         pr_default.execute(1, new Object[] {AV35FDesde, AV44LBBanCod, AV45LBCBCod, AV36FHasta});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A379LBBanCod = P009Y3_A379LBBanCod[0];
            A380LBCBCod = P009Y3_A380LBCBCod[0];
            A1079LBFech = P009Y3_A1079LBFech[0];
            A1057LBConcepto = P009Y3_A1057LBConcepto[0];
            A1054LBBeneficia = P009Y3_A1054LBBeneficia[0];
            A1075LBDocumento = P009Y3_A1075LBDocumento[0];
            A381LBRegistro = P009Y3_A381LBRegistro[0];
            A1073LBTHaber = P009Y3_A1073LBTHaber[0];
            A1072LBTDebe = P009Y3_A1072LBTDebe[0];
            A1070LBTipo = P009Y3_A1070LBTipo[0];
            A1071LBTSaldo = (((A1072LBTDebe-A1073LBTHaber)<Convert.ToDecimal(0)) ? (A1072LBTDebe-A1073LBTHaber)*-1 : (((A1073LBTHaber-A1072LBTDebe)<Convert.ToDecimal(0)) ? (A1073LBTHaber-A1072LBTDebe)*-1 : A1072LBTDebe-A1073LBTHaber));
            A1082LBHaberTot = ((A1070LBTipo==0) ? A1071LBTSaldo : (decimal)(0));
            A1069LBDebeTot = ((A1070LBTipo==1) ? A1071LBTSaldo : (decimal)(0));
            AV9CTBco = A380LBCBCod;
            AV10Debe = A1069LBDebeTot;
            AV11Haber = A1082LBHaberTot;
            AV23Mov = (decimal)(AV10Debe-AV11Haber);
            AV12Saldo = (decimal)(AV12Saldo+AV23Mov);
            AV39LBConcepto = StringUtil.Trim( A1057LBConcepto);
            AV26LBBeneficia = StringUtil.Trim( A1054LBBeneficia);
            H9Y0( false, 20) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV10Debe, "ZZZZZZ,ZZZ,ZZ9.99")), 796, Gx_line+4, 886, Gx_line+17, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV11Haber, "ZZZZZZ,ZZZ,ZZ9.99")), 922, Gx_line+4, 1012, Gx_line+17, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A381LBRegistro, "")), 11, Gx_line+2, 71, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( A1079LBFech, "99/99/99"), 153, Gx_line+2, 196, Gx_line+19, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1075LBDocumento, "")), 83, Gx_line+1, 146, Gx_line+19, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26LBBeneficia, "")), 217, Gx_line+2, 466, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39LBConcepto, "")), 476, Gx_line+2, 822, Gx_line+18, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV18TDebe = (decimal)(AV18TDebe+AV10Debe);
            AV19THaber = (decimal)(AV19THaber+AV11Haber);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void H9Y0( bool bFoot ,
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
               getPrinter().GxDrawText("Reporte de Movimiento de Bancos", 399, Gx_line+18, 690, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+111, 1020, Gx_line+139, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Doc.", 94, Gx_line+118, 137, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 151, Gx_line+118, 186, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Beneficiario", 217, Gx_line+118, 287, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Abonos", 826, Gx_line+118, 871, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cargos", 954, Gx_line+118, 996, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hora:", 920, Gx_line+31, 952, Gx_line+45, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 920, Gx_line+49, 964, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 920, Gx_line+14, 959, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 963, Gx_line+13, 1010, Gx_line+28, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 925, Gx_line+30, 1009, Gx_line+45, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 971, Gx_line+48, 1010, Gx_line+63, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde :", 417, Gx_line+49, 465, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta :", 550, Gx_line+49, 596, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV36FHasta, "99/99/99"), 597, Gx_line+49, 652, Gx_line+65, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV35FDesde, "99/99/99"), 468, Gx_line+49, 523, Gx_line+65, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV33Logo)) ? AV49Logo_GXI : AV33Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 19, Gx_line+3, 174, Gx_line+71) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31EmpRUC, "")), 19, Gx_line+90, 390, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Empresa, "")), 19, Gx_line+72, 387, Gx_line+90, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Registro", 6, Gx_line+118, 74, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Concepto", 476, Gx_line+118, 532, Gx_line+132, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+140);
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
         AV29Empresa = "";
         AV34Session = context.GetSession();
         AV30EmpDir = "";
         AV31EmpRUC = "";
         AV32Ruta = "";
         AV33Logo = "";
         AV49Logo_GXI = "";
         AV22FechaCHR = "";
         AV21Fecha = DateTime.MinValue;
         AV24CMes = "";
         GXt_char1 = "";
         AV8BanDsc = "";
         AV9CTBco = "";
         scmdbuf = "";
         A380LBCBCod = "";
         A1079LBFech = DateTime.MinValue;
         P009Y2_A1085LBMonCod = new int[1] ;
         P009Y2_A380LBCBCod = new string[] {""} ;
         P009Y2_A379LBBanCod = new int[1] ;
         P009Y2_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P009Y2_A1070LBTipo = new short[1] ;
         P009Y2_A482BanDsc = new string[] {""} ;
         P009Y2_n482BanDsc = new bool[] {false} ;
         P009Y2_A1234MonDsc = new string[] {""} ;
         P009Y2_n1234MonDsc = new bool[] {false} ;
         P009Y2_A1233MonAbr = new string[] {""} ;
         P009Y2_n1233MonAbr = new bool[] {false} ;
         P009Y2_A381LBRegistro = new string[] {""} ;
         A482BanDsc = "";
         A1234MonDsc = "";
         A1233MonAbr = "";
         A381LBRegistro = "";
         AV45LBCBCod = "";
         AV27MonDsc = "";
         AV43MonAbr = "";
         AV46Titulo = "";
         P009Y3_A379LBBanCod = new int[1] ;
         P009Y3_A380LBCBCod = new string[] {""} ;
         P009Y3_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P009Y3_A1057LBConcepto = new string[] {""} ;
         P009Y3_A1054LBBeneficia = new string[] {""} ;
         P009Y3_A1075LBDocumento = new string[] {""} ;
         P009Y3_A381LBRegistro = new string[] {""} ;
         P009Y3_A1073LBTHaber = new decimal[1] ;
         P009Y3_A1072LBTDebe = new decimal[1] ;
         P009Y3_A1070LBTipo = new short[1] ;
         A1057LBConcepto = "";
         A1054LBBeneficia = "";
         A1075LBDocumento = "";
         AV39LBConcepto = "";
         AV26LBBeneficia = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV33Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.r_reportemovimientobancospdf__default(),
            new Object[][] {
                new Object[] {
               P009Y2_A1085LBMonCod, P009Y2_A380LBCBCod, P009Y2_A379LBBanCod, P009Y2_A1079LBFech, P009Y2_A1070LBTipo, P009Y2_A482BanDsc, P009Y2_n482BanDsc, P009Y2_A1234MonDsc, P009Y2_n1234MonDsc, P009Y2_A1233MonAbr,
               P009Y2_n1233MonAbr, P009Y2_A381LBRegistro
               }
               , new Object[] {
               P009Y3_A379LBBanCod, P009Y3_A380LBCBCod, P009Y3_A1079LBFech, P009Y3_A1057LBConcepto, P009Y3_A1054LBBeneficia, P009Y3_A1075LBDocumento, P009Y3_A381LBRegistro, P009Y3_A1073LBTHaber, P009Y3_A1072LBTDebe, P009Y3_A1070LBTipo
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
      private decimal AV10Debe ;
      private decimal AV11Haber ;
      private decimal AV12Saldo ;
      private decimal AV13SaldoIni ;
      private decimal AV18TDebe ;
      private decimal AV19THaber ;
      private decimal A1073LBTHaber ;
      private decimal A1072LBTDebe ;
      private decimal A1071LBTSaldo ;
      private decimal A1082LBHaberTot ;
      private decimal A1069LBDebeTot ;
      private decimal AV23Mov ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV15CBCod ;
      private string AV37Tipo ;
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
      private string A482BanDsc ;
      private string A1234MonDsc ;
      private string A1233MonAbr ;
      private string A381LBRegistro ;
      private string AV45LBCBCod ;
      private string AV27MonDsc ;
      private string AV43MonAbr ;
      private string AV46Titulo ;
      private string A1057LBConcepto ;
      private string A1054LBBeneficia ;
      private string A1075LBDocumento ;
      private string AV39LBConcepto ;
      private string AV26LBBeneficia ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV35FDesde ;
      private DateTime AV36FHasta ;
      private DateTime AV21Fecha ;
      private DateTime A1079LBFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK9Y3 ;
      private bool n482BanDsc ;
      private bool n1234MonDsc ;
      private bool n1233MonAbr ;
      private bool returnInSub ;
      private string AV49Logo_GXI ;
      private string AV33Logo ;
      private string Logo ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_BanCod ;
      private string aP1_CBCod ;
      private DateTime aP2_FDesde ;
      private DateTime aP3_FHasta ;
      private string aP4_Tipo ;
      private IDataStoreProvider pr_default ;
      private int[] P009Y2_A1085LBMonCod ;
      private string[] P009Y2_A380LBCBCod ;
      private int[] P009Y2_A379LBBanCod ;
      private DateTime[] P009Y2_A1079LBFech ;
      private short[] P009Y2_A1070LBTipo ;
      private string[] P009Y2_A482BanDsc ;
      private bool[] P009Y2_n482BanDsc ;
      private string[] P009Y2_A1234MonDsc ;
      private bool[] P009Y2_n1234MonDsc ;
      private string[] P009Y2_A1233MonAbr ;
      private bool[] P009Y2_n1233MonAbr ;
      private string[] P009Y2_A381LBRegistro ;
      private int[] P009Y3_A379LBBanCod ;
      private string[] P009Y3_A380LBCBCod ;
      private DateTime[] P009Y3_A1079LBFech ;
      private string[] P009Y3_A1057LBConcepto ;
      private string[] P009Y3_A1054LBBeneficia ;
      private string[] P009Y3_A1075LBDocumento ;
      private string[] P009Y3_A381LBRegistro ;
      private decimal[] P009Y3_A1073LBTHaber ;
      private decimal[] P009Y3_A1072LBTDebe ;
      private short[] P009Y3_A1070LBTipo ;
   }

   public class r_reportemovimientobancospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009Y2( IGxContext context ,
                                             int AV14BanCod ,
                                             string AV15CBCod ,
                                             string AV37Tipo ,
                                             int A379LBBanCod ,
                                             string A380LBCBCod ,
                                             short A1070LBTipo ,
                                             DateTime A1079LBFech ,
                                             DateTime AV35FDesde ,
                                             DateTime AV36FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T3.[MonCod] AS LBMonCod, T1.[LBCBCod] AS LBCBCod, T1.[LBBanCod] AS LBBanCod, T1.[LBFech], T1.[LBTipo], T2.[BanDsc], T4.[MonDsc], T4.[MonAbr], T1.[LBRegistro] FROM ((([TSLIBROBANCOS] T1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = T1.[LBBanCod]) INNER JOIN [TSCUENTABANCO] T3 ON T3.[BanCod] = T1.[LBBanCod] AND T3.[CBCod] = T1.[LBCBCod]) INNER JOIN [CMONEDAS] T4 ON T4.[MonCod] = T3.[MonCod])";
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15CBCod)) )
         {
            AddWhere(sWhereString, "(T1.[LBCBCod] = @AV15CBCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV37Tipo, "I") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LBTipo] = 1)");
         }
         if ( StringUtil.StrCmp(AV37Tipo, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LBTipo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[LBBanCod], T1.[LBCBCod], T3.[MonCod]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P009Y3( IGxContext context ,
                                             string AV37Tipo ,
                                             short A1070LBTipo ,
                                             int A379LBBanCod ,
                                             int AV44LBBanCod ,
                                             string A380LBCBCod ,
                                             string AV45LBCBCod ,
                                             DateTime AV35FDesde ,
                                             DateTime A1079LBFech ,
                                             DateTime AV36FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [LBBanCod] AS LBBanCod, [LBCBCod] AS LBCBCod, [LBFech], [LBConcepto], [LBBeneficia], [LBDocumento], [LBRegistro], [LBTHaber], [LBTDebe], [LBTipo] FROM [TSLIBROBANCOS]";
         AddWhere(sWhereString, "([LBFech] >= @AV35FDesde)");
         AddWhere(sWhereString, "([LBBanCod] = @AV44LBBanCod)");
         AddWhere(sWhereString, "([LBCBCod] = @AV45LBCBCod)");
         AddWhere(sWhereString, "([LBFech] <= @AV36FHasta)");
         if ( StringUtil.StrCmp(AV37Tipo, "I") == 0 )
         {
            AddWhere(sWhereString, "([LBTipo] = 1)");
         }
         if ( StringUtil.StrCmp(AV37Tipo, "E") == 0 )
         {
            AddWhere(sWhereString, "([LBTipo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [LBFech]";
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
               case 0 :
                     return conditional_P009Y2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] );
               case 1 :
                     return conditional_P009Y3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] );
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
          Object[] prmP009Y2;
          prmP009Y2 = new Object[] {
          new ParDef("@AV35FDesde",GXType.Date,8,0) ,
          new ParDef("@AV36FHasta",GXType.Date,8,0) ,
          new ParDef("@AV14BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV15CBCod",GXType.NChar,20,0)
          };
          Object[] prmP009Y3;
          prmP009Y3 = new Object[] {
          new ParDef("@AV35FDesde",GXType.Date,8,0) ,
          new ParDef("@AV44LBBanCod",GXType.Int32,6,0) ,
          new ParDef("@AV45LBCBCod",GXType.NChar,20,0) ,
          new ParDef("@AV36FHasta",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 5);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 60);
                ((string[]) buf[4])[0] = rslt.getString(5, 60);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                return;
       }
    }

 }

}
