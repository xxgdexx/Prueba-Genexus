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
   public class r_resumenmovimientobancosconceptopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "bancos.r_resumenmovimientobancosconceptopdf.aspx")), "bancos.r_resumenmovimientobancosconceptopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "bancos.r_resumenmovimientobancosconceptopdf.aspx")))) ;
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
                  AV40ConBCod = (int)(NumberUtil.Val( GetPar( "ConBCod"), "."));
                  AV41TipADCod = GetPar( "TipADCod");
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

      public r_resumenmovimientobancosconceptopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenmovimientobancosconceptopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_BanCod ,
                           ref DateTime aP1_FDesde ,
                           ref DateTime aP2_FHasta ,
                           ref int aP3_ConBCod ,
                           ref string aP4_TipADCod )
      {
         this.AV14BanCod = aP0_BanCod;
         this.AV35FDesde = aP1_FDesde;
         this.AV36FHasta = aP2_FHasta;
         this.AV40ConBCod = aP3_ConBCod;
         this.AV41TipADCod = aP4_TipADCod;
         initialize();
         executePrivate();
         aP0_BanCod=this.AV14BanCod;
         aP1_FDesde=this.AV35FDesde;
         aP2_FHasta=this.AV36FHasta;
         aP3_ConBCod=this.AV40ConBCod;
         aP4_TipADCod=this.AV41TipADCod;
      }

      public string executeUdp( ref int aP0_BanCod ,
                                ref DateTime aP1_FDesde ,
                                ref DateTime aP2_FHasta ,
                                ref int aP3_ConBCod )
      {
         execute(ref aP0_BanCod, ref aP1_FDesde, ref aP2_FHasta, ref aP3_ConBCod, ref aP4_TipADCod);
         return AV41TipADCod ;
      }

      public void executeSubmit( ref int aP0_BanCod ,
                                 ref DateTime aP1_FDesde ,
                                 ref DateTime aP2_FHasta ,
                                 ref int aP3_ConBCod ,
                                 ref string aP4_TipADCod )
      {
         r_resumenmovimientobancosconceptopdf objr_resumenmovimientobancosconceptopdf;
         objr_resumenmovimientobancosconceptopdf = new r_resumenmovimientobancosconceptopdf();
         objr_resumenmovimientobancosconceptopdf.AV14BanCod = aP0_BanCod;
         objr_resumenmovimientobancosconceptopdf.AV35FDesde = aP1_FDesde;
         objr_resumenmovimientobancosconceptopdf.AV36FHasta = aP2_FHasta;
         objr_resumenmovimientobancosconceptopdf.AV40ConBCod = aP3_ConBCod;
         objr_resumenmovimientobancosconceptopdf.AV41TipADCod = aP4_TipADCod;
         objr_resumenmovimientobancosconceptopdf.context.SetSubmitInitialConfig(context);
         objr_resumenmovimientobancosconceptopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenmovimientobancosconceptopdf);
         aP0_BanCod=this.AV14BanCod;
         aP1_FDesde=this.AV35FDesde;
         aP2_FHasta=this.AV36FHasta;
         aP3_ConBCod=this.AV40ConBCod;
         aP4_TipADCod=this.AV41TipADCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenmovimientobancosconceptopdf)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 9, 16834, 11909, 0, 1, 1, 0, 1, 1) )
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
            AV46Logo_GXI = GXDbFile.PathToUrl( AV32Ruta);
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
                                                 AV41TipADCod ,
                                                 AV40ConBCod ,
                                                 A379LBBanCod ,
                                                 A1065LBDCueAux ,
                                                 A386LBConBan ,
                                                 A1079LBFech ,
                                                 AV35FDesde ,
                                                 AV36FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00A22 */
            pr_default.execute(0, new Object[] {AV35FDesde, AV36FHasta, AV14BanCod, AV41TipADCod, AV40ConBCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1085LBMonCod = P00A22_A1085LBMonCod[0];
               A1079LBFech = P00A22_A1079LBFech[0];
               A386LBConBan = P00A22_A386LBConBan[0];
               A1065LBDCueAux = P00A22_A1065LBDCueAux[0];
               A379LBBanCod = P00A22_A379LBBanCod[0];
               A1053LBBanAbr = P00A22_A1053LBBanAbr[0];
               A1233MonAbr = P00A22_A1233MonAbr[0];
               n1233MonAbr = P00A22_n1233MonAbr[0];
               A1067LBDDebe = P00A22_A1067LBDDebe[0];
               A1074LBDHaber = P00A22_A1074LBDHaber[0];
               A1057LBConcepto = P00A22_A1057LBConcepto[0];
               A1075LBDocumento = P00A22_A1075LBDocumento[0];
               A381LBRegistro = P00A22_A381LBRegistro[0];
               A380LBCBCod = P00A22_A380LBCBCod[0];
               A383LBDITem = P00A22_A383LBDITem[0];
               A1053LBBanAbr = P00A22_A1053LBBanAbr[0];
               A1079LBFech = P00A22_A1079LBFech[0];
               A1057LBConcepto = P00A22_A1057LBConcepto[0];
               A1075LBDocumento = P00A22_A1075LBDocumento[0];
               A1085LBMonCod = P00A22_A1085LBMonCod[0];
               A1233MonAbr = P00A22_A1233MonAbr[0];
               n1233MonAbr = P00A22_n1233MonAbr[0];
               AV38BanAbr = StringUtil.Trim( A1053LBBanAbr);
               AV43MonAbr = StringUtil.Trim( A1233MonAbr);
               AV9CTBco = A380LBCBCod;
               AV10Debe = A1067LBDDebe;
               AV11Haber = A1074LBDHaber;
               AV42LBDCueAux = A1065LBDCueAux;
               AV23Mov = (decimal)(AV10Debe-AV11Haber);
               AV12Saldo = (decimal)(AV12Saldo+AV23Mov);
               AV39LBConcepto = StringUtil.Trim( A1057LBConcepto);
               AV26LBBeneficia = "";
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42LBDCueAux)) )
               {
                  /* Execute user subroutine: 'AUXILIAR' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
               }
               HA20( false, 20) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV10Debe, "ZZZZZZ,ZZZ,ZZ9.99")), 631, Gx_line+4, 721, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV11Haber, "ZZZZZZ,ZZZ,ZZ9.99")), 709, Gx_line+4, 799, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A381LBRegistro, "")), 139, Gx_line+3, 199, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A1079LBFech, "99/99/99"), 266, Gx_line+3, 309, Gx_line+20, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39LBConcepto, "")), 310, Gx_line+3, 495, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1075LBDocumento, "")), 200, Gx_line+2, 263, Gx_line+20, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9CTBco, "")), 42, Gx_line+4, 137, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38BanAbr, "")), 2, Gx_line+4, 41, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26LBBeneficia, "")), 501, Gx_line+3, 628, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43MonAbr, "")), 633, Gx_line+3, 658, Gx_line+19, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               AV18TDebe = (decimal)(AV18TDebe+AV10Debe);
               AV19THaber = (decimal)(AV19THaber+AV11Haber);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            HA20( false, 31) ;
            getPrinter().GxDrawLine(607, Gx_line+2, 804, Gx_line+2, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18TDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 596, Gx_line+6, 720, Gx_line+20, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19THaber, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 798, Gx_line+20, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+31);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HA20( true, 0) ;
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
         /* 'AUXILIAR' Routine */
         returnInSub = false;
         /* Using cursor P00A23 */
         pr_default.execute(1, new Object[] {AV42LBDCueAux});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A71TipADCod = P00A23_A71TipADCod[0];
            A72TipADDsc = P00A23_A72TipADDsc[0];
            A70TipACod = P00A23_A70TipACod[0];
            AV26LBBeneficia = StringUtil.Trim( A72TipADDsc);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void HA20( bool bFoot ,
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
               getPrinter().GxDrawText("Resumen de Movimiento Bancos", 273, Gx_line+13, 547, Gx_line+33, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+109, 804, Gx_line+143, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Registro", 135, Gx_line+120, 203, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Doc.", 208, Gx_line+120, 251, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 270, Gx_line+120, 305, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Concepto", 311, Gx_line+120, 367, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Debe", 690, Gx_line+120, 721, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber", 763, Gx_line+120, 799, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hora:", 691, Gx_line+32, 723, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 691, Gx_line+50, 735, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 691, Gx_line+15, 730, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 733, Gx_line+14, 780, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 696, Gx_line+31, 780, Gx_line+46, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 742, Gx_line+49, 781, Gx_line+64, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde :", 286, Gx_line+44, 334, Gx_line+59, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta :", 420, Gx_line+44, 466, Gx_line+59, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV36FHasta, "99/99/99"), 467, Gx_line+44, 522, Gx_line+60, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV35FDesde, "99/99/99"), 338, Gx_line+44, 393, Gx_line+60, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV33Logo)) ? AV46Logo_GXI : AV33Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 19, Gx_line+3, 174, Gx_line+71) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31EmpRUC, "")), 19, Gx_line+90, 390, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Empresa, "")), 19, Gx_line+72, 387, Gx_line+90, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Banco", 6, Gx_line+120, 42, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cuenta", 48, Gx_line+120, 91, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Auxiliar", 504, Gx_line+120, 550, Gx_line+134, 0+256, 0, 0, 0) ;
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
         AV46Logo_GXI = "";
         AV22FechaCHR = "";
         AV21Fecha = DateTime.MinValue;
         AV24CMes = "";
         GXt_char1 = "";
         AV8BanDsc = "";
         AV9CTBco = "";
         scmdbuf = "";
         A1065LBDCueAux = "";
         A1079LBFech = DateTime.MinValue;
         P00A22_A1085LBMonCod = new int[1] ;
         P00A22_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P00A22_A386LBConBan = new int[1] ;
         P00A22_A1065LBDCueAux = new string[] {""} ;
         P00A22_A379LBBanCod = new int[1] ;
         P00A22_A1053LBBanAbr = new string[] {""} ;
         P00A22_A1233MonAbr = new string[] {""} ;
         P00A22_n1233MonAbr = new bool[] {false} ;
         P00A22_A1067LBDDebe = new decimal[1] ;
         P00A22_A1074LBDHaber = new decimal[1] ;
         P00A22_A1057LBConcepto = new string[] {""} ;
         P00A22_A1075LBDocumento = new string[] {""} ;
         P00A22_A381LBRegistro = new string[] {""} ;
         P00A22_A380LBCBCod = new string[] {""} ;
         P00A22_A383LBDITem = new int[1] ;
         A1053LBBanAbr = "";
         A1233MonAbr = "";
         A1057LBConcepto = "";
         A1075LBDocumento = "";
         A381LBRegistro = "";
         A380LBCBCod = "";
         AV38BanAbr = "";
         AV43MonAbr = "";
         AV42LBDCueAux = "";
         AV39LBConcepto = "";
         AV26LBBeneficia = "";
         P00A23_A71TipADCod = new string[] {""} ;
         P00A23_A72TipADDsc = new string[] {""} ;
         P00A23_A70TipACod = new int[1] ;
         A71TipADCod = "";
         A72TipADDsc = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV33Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.r_resumenmovimientobancosconceptopdf__default(),
            new Object[][] {
                new Object[] {
               P00A22_A1085LBMonCod, P00A22_A1079LBFech, P00A22_A386LBConBan, P00A22_A1065LBDCueAux, P00A22_A379LBBanCod, P00A22_A1053LBBanAbr, P00A22_A1233MonAbr, P00A22_n1233MonAbr, P00A22_A1067LBDDebe, P00A22_A1074LBDHaber,
               P00A22_A1057LBConcepto, P00A22_A1075LBDocumento, P00A22_A381LBRegistro, P00A22_A380LBCBCod, P00A22_A383LBDITem
               }
               , new Object[] {
               P00A23_A71TipADCod, P00A23_A72TipADDsc, P00A23_A70TipACod
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
      private int AV14BanCod ;
      private int AV40ConBCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A379LBBanCod ;
      private int A386LBConBan ;
      private int A1085LBMonCod ;
      private int A383LBDITem ;
      private int Gx_OldLine ;
      private int A70TipACod ;
      private decimal AV10Debe ;
      private decimal AV11Haber ;
      private decimal AV12Saldo ;
      private decimal AV13SaldoIni ;
      private decimal AV18TDebe ;
      private decimal A1067LBDDebe ;
      private decimal A1074LBDHaber ;
      private decimal AV23Mov ;
      private decimal AV19THaber ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV41TipADCod ;
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
      private string A1065LBDCueAux ;
      private string A1053LBBanAbr ;
      private string A1233MonAbr ;
      private string A1057LBConcepto ;
      private string A1075LBDocumento ;
      private string A381LBRegistro ;
      private string A380LBCBCod ;
      private string AV38BanAbr ;
      private string AV43MonAbr ;
      private string AV42LBDCueAux ;
      private string AV39LBConcepto ;
      private string AV26LBBeneficia ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV35FDesde ;
      private DateTime AV36FHasta ;
      private DateTime AV21Fecha ;
      private DateTime A1079LBFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1233MonAbr ;
      private bool returnInSub ;
      private string AV46Logo_GXI ;
      private string AV33Logo ;
      private string Logo ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_BanCod ;
      private DateTime aP1_FDesde ;
      private DateTime aP2_FHasta ;
      private int aP3_ConBCod ;
      private string aP4_TipADCod ;
      private IDataStoreProvider pr_default ;
      private int[] P00A22_A1085LBMonCod ;
      private DateTime[] P00A22_A1079LBFech ;
      private int[] P00A22_A386LBConBan ;
      private string[] P00A22_A1065LBDCueAux ;
      private int[] P00A22_A379LBBanCod ;
      private string[] P00A22_A1053LBBanAbr ;
      private string[] P00A22_A1233MonAbr ;
      private bool[] P00A22_n1233MonAbr ;
      private decimal[] P00A22_A1067LBDDebe ;
      private decimal[] P00A22_A1074LBDHaber ;
      private string[] P00A22_A1057LBConcepto ;
      private string[] P00A22_A1075LBDocumento ;
      private string[] P00A22_A381LBRegistro ;
      private string[] P00A22_A380LBCBCod ;
      private int[] P00A22_A383LBDITem ;
      private string[] P00A23_A71TipADCod ;
      private string[] P00A23_A72TipADDsc ;
      private int[] P00A23_A70TipACod ;
   }

   public class r_resumenmovimientobancosconceptopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A22( IGxContext context ,
                                             int AV14BanCod ,
                                             string AV41TipADCod ,
                                             int AV40ConBCod ,
                                             int A379LBBanCod ,
                                             string A1065LBDCueAux ,
                                             int A386LBConBan ,
                                             DateTime A1079LBFech ,
                                             DateTime AV35FDesde ,
                                             DateTime AV36FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T4.[MonCod] AS LBMonCod, T3.[LBFech], T1.[LBConBan], T1.[LBDCueAux], T1.[LBBanCod] AS LBBanCod, T2.[BanAbr] AS LBBanAbr, T5.[MonAbr], T1.[LBDDebe], T1.[LBDHaber], T3.[LBConcepto], T3.[LBDocumento], T1.[LBRegistro], T1.[LBCBCod] AS LBCBCod, T1.[LBDITem] FROM (((([TSLIBROBANCOSDET] T1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = T1.[LBBanCod]) INNER JOIN [TSLIBROBANCOS] T3 ON T3.[LBBanCod] = T1.[LBBanCod] AND T3.[LBCBCod] = T1.[LBCBCod] AND T3.[LBRegistro] = T1.[LBRegistro]) INNER JOIN [TSCUENTABANCO] T4 ON T4.[BanCod] = T1.[LBBanCod] AND T4.[CBCod] = T1.[LBCBCod]) INNER JOIN [CMONEDAS] T5 ON T5.[MonCod] = T4.[MonCod])";
         AddWhere(sWhereString, "(T3.[LBFech] >= @AV35FDesde)");
         AddWhere(sWhereString, "(T3.[LBFech] <= @AV36FHasta)");
         if ( ! (0==AV14BanCod) )
         {
            AddWhere(sWhereString, "(T1.[LBBanCod] = @AV14BanCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TipADCod)) )
         {
            AddWhere(sWhereString, "(T1.[LBDCueAux] = @AV41TipADCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV40ConBCod) )
         {
            AddWhere(sWhereString, "(T1.[LBConBan] = @AV40ConBCod)");
         }
         else
         {
            GXv_int2[4] = 1;
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
                     return conditional_P00A22(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] );
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
          Object[] prmP00A23;
          prmP00A23 = new Object[] {
          new ParDef("@AV42LBDCueAux",GXType.NChar,20,0)
          };
          Object[] prmP00A22;
          prmP00A22 = new Object[] {
          new ParDef("@AV35FDesde",GXType.Date,8,0) ,
          new ParDef("@AV36FHasta",GXType.Date,8,0) ,
          new ParDef("@AV14BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV41TipADCod",GXType.NChar,20,0) ,
          new ParDef("@AV40ConBCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A22", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A22,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00A23", "SELECT [TipADCod], [TipADDsc], [TipACod] FROM [CBAUXILIARES] WHERE [TipADCod] = @AV42LBDCueAux ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A23,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 60);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((string[]) buf[12])[0] = rslt.getString(12, 10);
                ((string[]) buf[13])[0] = rslt.getString(13, 20);
                ((int[]) buf[14])[0] = rslt.getInt(14);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
