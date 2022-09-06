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
namespace GeneXus.Programs.ventas {
   public class r_resumencobranzapdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "ventas.r_resumencobranzapdf.aspx")), "ventas.r_resumencobranzapdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "ventas.r_resumencobranzapdf.aspx")))) ;
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
                  AV18FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV8CliCod = GetPar( "CliCod");
                  AV21ForCod1 = (int)(NumberUtil.Val( GetPar( "ForCod1"), "."));
                  AV27MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV31TipCod = GetPar( "TipCod");
                  AV29Serie = GetPar( "Serie");
                  AV39VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
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

      public r_resumencobranzapdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumencobranzapdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FDesde ,
                           ref DateTime aP1_FHasta ,
                           ref string aP2_CliCod ,
                           ref int aP3_ForCod1 ,
                           ref int aP4_MonCod ,
                           ref string aP5_TipCod ,
                           ref string aP6_Serie ,
                           ref int aP7_VenCod )
      {
         this.AV17FDesde = aP0_FDesde;
         this.AV18FHasta = aP1_FHasta;
         this.AV8CliCod = aP2_CliCod;
         this.AV21ForCod1 = aP3_ForCod1;
         this.AV27MonCod = aP4_MonCod;
         this.AV31TipCod = aP5_TipCod;
         this.AV29Serie = aP6_Serie;
         this.AV39VenCod = aP7_VenCod;
         initialize();
         executePrivate();
         aP0_FDesde=this.AV17FDesde;
         aP1_FHasta=this.AV18FHasta;
         aP2_CliCod=this.AV8CliCod;
         aP3_ForCod1=this.AV21ForCod1;
         aP4_MonCod=this.AV27MonCod;
         aP5_TipCod=this.AV31TipCod;
         aP6_Serie=this.AV29Serie;
         aP7_VenCod=this.AV39VenCod;
      }

      public int executeUdp( ref DateTime aP0_FDesde ,
                             ref DateTime aP1_FHasta ,
                             ref string aP2_CliCod ,
                             ref int aP3_ForCod1 ,
                             ref int aP4_MonCod ,
                             ref string aP5_TipCod ,
                             ref string aP6_Serie )
      {
         execute(ref aP0_FDesde, ref aP1_FHasta, ref aP2_CliCod, ref aP3_ForCod1, ref aP4_MonCod, ref aP5_TipCod, ref aP6_Serie, ref aP7_VenCod);
         return AV39VenCod ;
      }

      public void executeSubmit( ref DateTime aP0_FDesde ,
                                 ref DateTime aP1_FHasta ,
                                 ref string aP2_CliCod ,
                                 ref int aP3_ForCod1 ,
                                 ref int aP4_MonCod ,
                                 ref string aP5_TipCod ,
                                 ref string aP6_Serie ,
                                 ref int aP7_VenCod )
      {
         r_resumencobranzapdf objr_resumencobranzapdf;
         objr_resumencobranzapdf = new r_resumencobranzapdf();
         objr_resumencobranzapdf.AV17FDesde = aP0_FDesde;
         objr_resumencobranzapdf.AV18FHasta = aP1_FHasta;
         objr_resumencobranzapdf.AV8CliCod = aP2_CliCod;
         objr_resumencobranzapdf.AV21ForCod1 = aP3_ForCod1;
         objr_resumencobranzapdf.AV27MonCod = aP4_MonCod;
         objr_resumencobranzapdf.AV31TipCod = aP5_TipCod;
         objr_resumencobranzapdf.AV29Serie = aP6_Serie;
         objr_resumencobranzapdf.AV39VenCod = aP7_VenCod;
         objr_resumencobranzapdf.context.SetSubmitInitialConfig(context);
         objr_resumencobranzapdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumencobranzapdf);
         aP0_FDesde=this.AV17FDesde;
         aP1_FHasta=this.AV18FHasta;
         aP2_CliCod=this.AV8CliCod;
         aP3_ForCod1=this.AV21ForCod1;
         aP4_MonCod=this.AV27MonCod;
         aP5_TipCod=this.AV31TipCod;
         aP6_Serie=this.AV29Serie;
         aP7_VenCod=this.AV39VenCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumencobranzapdf)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 2, 1, 12240, 15840, 0, 1, 1, 0, 1, 1) )
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
            AV15Empresa = AV30Session.Get("Empresa");
            AV14EmpDir = AV30Session.Get("EmpDir");
            AV16EmpRUC = AV30Session.Get("EmpRUC");
            AV28Ruta = AV30Session.Get("RUTA") + "/Logo.jpg";
            AV26Logo = AV28Ruta;
            AV42Logo_GXI = GXDbFile.PathToUrl( AV28Ruta);
            AV19Filtro1 = "(Todos)";
            /* Using cursor P007N2 */
            pr_default.execute(0, new Object[] {AV39VenCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A309VenCod = P007N2_A309VenCod[0];
               A2045VenDsc = P007N2_A2045VenDsc[0];
               AV19Filtro1 = StringUtil.Trim( A2045VenDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV36TotMN = 0.00m;
            AV35TotME = 0.00m;
            AV25LenSerie = (short)(StringUtil.Len( AV29Serie));
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV31TipCod ,
                                                 AV8CliCod ,
                                                 AV21ForCod1 ,
                                                 AV27MonCod ,
                                                 AV39VenCod ,
                                                 AV25LenSerie ,
                                                 A166CobTip ,
                                                 A645CobCliCod ,
                                                 A143ForCod ,
                                                 A172CobMon ,
                                                 A175CobTipCod ,
                                                 A171CobVendCod ,
                                                 A176CobDocNum ,
                                                 AV29Serie ,
                                                 A661CobSts ,
                                                 AV17FDesde ,
                                                 A655CobFec ,
                                                 AV18FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P007N3 */
            pr_default.execute(1, new Object[] {AV17FDesde, AV18FHasta, AV8CliCod, AV21ForCod1, AV27MonCod, AV31TipCod, AV39VenCod, AV25LenSerie, AV29Serie});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A661CobSts = P007N3_A661CobSts[0];
               A176CobDocNum = P007N3_A176CobDocNum[0];
               A171CobVendCod = P007N3_A171CobVendCod[0];
               A175CobTipCod = P007N3_A175CobTipCod[0];
               A172CobMon = P007N3_A172CobMon[0];
               A143ForCod = P007N3_A143ForCod[0];
               A645CobCliCod = P007N3_A645CobCliCod[0];
               A655CobFec = P007N3_A655CobFec[0];
               A166CobTip = P007N3_A166CobTip[0];
               A663CobTipCam = P007N3_A663CobTipCam[0];
               A654CobDTot = P007N3_A654CobDTot[0];
               A508CCFVcto = P007N3_A508CCFVcto[0];
               n508CCFVcto = P007N3_n508CCFVcto[0];
               A190CCFech = P007N3_A190CCFech[0];
               n190CCFech = P007N3_n190CCFech[0];
               A646CobCliDsc = P007N3_A646CobCliDsc[0];
               A167CobCod = P007N3_A167CobCod[0];
               A656CobMonAbr = P007N3_A656CobMonAbr[0];
               A659CobRef = P007N3_A659CobRef[0];
               A988ForDsc = P007N3_A988ForDsc[0];
               A306TipAbr = P007N3_A306TipAbr[0];
               n306TipAbr = P007N3_n306TipAbr[0];
               A173Item = P007N3_A173Item[0];
               A645CobCliCod = P007N3_A645CobCliCod[0];
               A508CCFVcto = P007N3_A508CCFVcto[0];
               n508CCFVcto = P007N3_n508CCFVcto[0];
               A190CCFech = P007N3_A190CCFech[0];
               n190CCFech = P007N3_n190CCFech[0];
               A646CobCliDsc = P007N3_A646CobCliDsc[0];
               A306TipAbr = P007N3_A306TipAbr[0];
               n306TipAbr = P007N3_n306TipAbr[0];
               A988ForDsc = P007N3_A988ForDsc[0];
               A661CobSts = P007N3_A661CobSts[0];
               A171CobVendCod = P007N3_A171CobVendCod[0];
               A172CobMon = P007N3_A172CobMon[0];
               A655CobFec = P007N3_A655CobFec[0];
               A656CobMonAbr = P007N3_A656CobMonAbr[0];
               AV32TipVenta = A663CobTipCam;
               if ( ( AV32TipVenta == Convert.ToDecimal( 0 )) || ( AV32TipVenta == Convert.ToDecimal( 1 )) )
               {
                  GXt_decimal1 = AV32TipVenta;
                  GXt_int2 = 2;
                  GXt_char3 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A655CobFec, ref  GXt_char3, out  GXt_decimal1) ;
                  AV32TipVenta = GXt_decimal1;
               }
               AV9CobDTot = A654CobDTot;
               AV12CobMN = ((A172CobMon==1) ? AV9CobDTot : (decimal)(0));
               AV11CobME = ((A172CobMon==1) ? (decimal)(0) : AV9CobDTot);
               AV36TotMN = (decimal)(AV36TotMN+AV12CobMN);
               AV35TotME = (decimal)(AV35TotME+AV11CobME);
               H7N0( false, 22) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 5, Gx_line+3, 28, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A176CobDocNum, "")), 31, Gx_line+3, 106, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A988ForDsc, "")), 422, Gx_line+3, 560, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A659CobRef, "")), 565, Gx_line+3, 649, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A656CobMonAbr, "")), 747, Gx_line+3, 780, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV12CobMN, "ZZZZZZ,ZZZ,ZZ9.99")), 790, Gx_line+3, 880, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A655CobFec, "99/99/99"), 1045, Gx_line+3, 1084, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A167CobCod, "")), 963, Gx_line+3, 1036, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A646CobCliDsc, "")), 201, Gx_line+3, 417, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32TipVenta, "ZZZZZZZZ9.99999")), 656, Gx_line+3, 735, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV11CobME, "ZZZZZZ,ZZZ,ZZ9.99")), 864, Gx_line+3, 954, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A190CCFech, "99/99/99"), 111, Gx_line+3, 150, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A508CCFVcto, "99/99/99"), 154, Gx_line+3, 193, Gx_line+17, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+22);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            H7N0( false, 79) ;
            getPrinter().GxDrawLine(705, Gx_line+11, 1075, Gx_line+11, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("TOTAL GENERAL", 655, Gx_line+18, 748, Gx_line+32, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36TotMN, "ZZZZZZ,ZZZ,ZZ9.99")), 730, Gx_line+18, 837, Gx_line+33, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35TotME, "ZZZZZZ,ZZZ,ZZ9.99")), 825, Gx_line+18, 932, Gx_line+33, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+79);
            AV38TTotalMN = 0.00m;
            AV37TTotalME = 0.00m;
            H7N0( false, 28) ;
            getPrinter().GxDrawRect(309, Gx_line+0, 729, Gx_line+28, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(497, Gx_line+0, 497, Gx_line+27, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(616, Gx_line+1, 616, Gx_line+28, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Forma de Pago", 353, Gx_line+6, 442, Gx_line+20, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Importe MN", 524, Gx_line+6, 595, Gx_line+20, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Importe ME", 638, Gx_line+6, 708, Gx_line+20, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+28);
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV21ForCod1 ,
                                                 A143ForCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            /* Using cursor P007N4 */
            pr_default.execute(2, new Object[] {AV21ForCod1});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A143ForCod = P007N4_A143ForCod[0];
               A988ForDsc = P007N4_A988ForDsc[0];
               AV20ForCod = A143ForCod;
               AV22ForDsc = A988ForDsc;
               AV34TotalMN = 0.00m;
               AV33TotalME = 0.00m;
               pr_default.dynParam(3, new Object[]{ new Object[]{
                                                    AV31TipCod ,
                                                    AV8CliCod ,
                                                    AV27MonCod ,
                                                    AV39VenCod ,
                                                    AV25LenSerie ,
                                                    A166CobTip ,
                                                    A645CobCliCod ,
                                                    A172CobMon ,
                                                    A175CobTipCod ,
                                                    A171CobVendCod ,
                                                    A176CobDocNum ,
                                                    AV29Serie ,
                                                    A661CobSts ,
                                                    A143ForCod ,
                                                    AV20ForCod ,
                                                    AV17FDesde ,
                                                    A655CobFec ,
                                                    AV18FHasta } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                    }
               });
               /* Using cursor P007N5 */
               pr_default.execute(3, new Object[] {AV17FDesde, AV20ForCod, AV18FHasta, AV8CliCod, AV27MonCod, AV31TipCod, AV39VenCod, AV25LenSerie, AV29Serie});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A167CobCod = P007N5_A167CobCod[0];
                  A143ForCod = P007N5_A143ForCod[0];
                  A661CobSts = P007N5_A661CobSts[0];
                  A176CobDocNum = P007N5_A176CobDocNum[0];
                  A171CobVendCod = P007N5_A171CobVendCod[0];
                  A175CobTipCod = P007N5_A175CobTipCod[0];
                  A172CobMon = P007N5_A172CobMon[0];
                  A645CobCliCod = P007N5_A645CobCliCod[0];
                  A655CobFec = P007N5_A655CobFec[0];
                  A166CobTip = P007N5_A166CobTip[0];
                  A654CobDTot = P007N5_A654CobDTot[0];
                  A663CobTipCam = P007N5_A663CobTipCam[0];
                  A173Item = P007N5_A173Item[0];
                  A645CobCliCod = P007N5_A645CobCliCod[0];
                  A661CobSts = P007N5_A661CobSts[0];
                  A171CobVendCod = P007N5_A171CobVendCod[0];
                  A172CobMon = P007N5_A172CobMon[0];
                  A655CobFec = P007N5_A655CobFec[0];
                  AV9CobDTot = A654CobDTot;
                  AV13CobTipCam = A663CobTipCam;
                  AV34TotalMN = (decimal)(AV34TotalMN+(((A172CobMon==1) ? AV9CobDTot : (decimal)(0))));
                  AV33TotalME = (decimal)(AV33TotalME+(((A172CobMon==1) ? (decimal)(0) : AV9CobDTot)));
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               AV38TTotalMN = (decimal)(AV38TTotalMN+AV34TotalMN);
               AV37TTotalME = (decimal)(AV37TTotalME+AV33TotalME);
               if ( ! (Convert.ToDecimal(0)==AV34TotalMN) || ! (Convert.ToDecimal(0)==AV33TotalME) )
               {
                  H7N0( false, 21) ;
                  getPrinter().GxDrawLine(309, Gx_line+0, 309, Gx_line+21, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22ForDsc, "")), 313, Gx_line+3, 495, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 506, Gx_line+3, 613, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33TotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 619, Gx_line+3, 726, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(728, Gx_line+0, 728, Gx_line+21, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+21);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            H7N0( false, 28) ;
            getPrinter().GxDrawRect(309, Gx_line+0, 729, Gx_line+28, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(497, Gx_line+0, 497, Gx_line+27, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(616, Gx_line+0, 616, Gx_line+27, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38TTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 506, Gx_line+6, 613, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37TTotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 619, Gx_line+6, 726, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Totales", 431, Gx_line+6, 476, Gx_line+20, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+28);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7N0( true, 0) ;
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

      protected void H7N0( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 11, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde :", 379, Gx_line+65, 437, Gx_line+84, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta :", 535, Gx_line+65, 590, Gx_line+84, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Cobranza", 424, Gx_line+29, 615, Gx_line+49, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 949, Gx_line+51, 993, Gx_line+65, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hora:", 949, Gx_line+32, 981, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 949, Gx_line+15, 988, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1000, Gx_line+15, 1047, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 982, Gx_line+32, 1046, Gx_line+47, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1008, Gx_line+51, 1047, Gx_line+66, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV17FDesde, "99/99/99"), 452, Gx_line+65, 516, Gx_line+85, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV18FHasta, "99/99/99"), 602, Gx_line+65, 666, Gx_line+85, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+126, 1095, Gx_line+156, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 6, Gx_line+135, 27, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N°Doc.", 51, Gx_line+135, 86, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 281, Gx_line+135, 318, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Forma de Pago", 446, Gx_line+135, 525, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Ref/Cheq", 575, Gx_line+135, 625, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe MN", 823, Gx_line+135, 887, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Cob.", 1038, Gx_line+135, 1095, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Cobranza", 966, Gx_line+135, 1032, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 749, Gx_line+135, 791, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T.C.", 699, Gx_line+135, 721, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe ME", 897, Gx_line+135, 959, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 11, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cobrador :", 355, Gx_line+93, 437, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Filtro1, "")), 451, Gx_line+92, 674, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Empresa, "")), 10, Gx_line+81, 350, Gx_line+99, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16EmpRUC, "")), 10, Gx_line+99, 148, Gx_line+117, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV26Logo)) ? AV42Logo_GXI : AV26Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 10, Gx_line+3, 168, Gx_line+81) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 117, Gx_line+135, 148, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("F.Vcto", 157, Gx_line+135, 190, Gx_line+146, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+156);
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
         AV15Empresa = "";
         AV30Session = context.GetSession();
         AV14EmpDir = "";
         AV16EmpRUC = "";
         AV28Ruta = "";
         AV26Logo = "";
         AV42Logo_GXI = "";
         AV19Filtro1 = "";
         scmdbuf = "";
         P007N2_A309VenCod = new int[1] ;
         P007N2_A2045VenDsc = new string[] {""} ;
         A2045VenDsc = "";
         A166CobTip = "";
         A645CobCliCod = "";
         A175CobTipCod = "";
         A176CobDocNum = "";
         A661CobSts = "";
         A655CobFec = DateTime.MinValue;
         P007N3_A661CobSts = new string[] {""} ;
         P007N3_A176CobDocNum = new string[] {""} ;
         P007N3_A171CobVendCod = new int[1] ;
         P007N3_A175CobTipCod = new string[] {""} ;
         P007N3_A172CobMon = new int[1] ;
         P007N3_A143ForCod = new int[1] ;
         P007N3_A645CobCliCod = new string[] {""} ;
         P007N3_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         P007N3_A166CobTip = new string[] {""} ;
         P007N3_A663CobTipCam = new decimal[1] ;
         P007N3_A654CobDTot = new decimal[1] ;
         P007N3_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P007N3_n508CCFVcto = new bool[] {false} ;
         P007N3_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P007N3_n190CCFech = new bool[] {false} ;
         P007N3_A646CobCliDsc = new string[] {""} ;
         P007N3_A167CobCod = new string[] {""} ;
         P007N3_A656CobMonAbr = new string[] {""} ;
         P007N3_A659CobRef = new string[] {""} ;
         P007N3_A988ForDsc = new string[] {""} ;
         P007N3_A306TipAbr = new string[] {""} ;
         P007N3_n306TipAbr = new bool[] {false} ;
         P007N3_A173Item = new int[1] ;
         A508CCFVcto = DateTime.MinValue;
         A190CCFech = DateTime.MinValue;
         A646CobCliDsc = "";
         A167CobCod = "";
         A656CobMonAbr = "";
         A659CobRef = "";
         A988ForDsc = "";
         A306TipAbr = "";
         GXt_char3 = "";
         P007N4_A143ForCod = new int[1] ;
         P007N4_A988ForDsc = new string[] {""} ;
         AV22ForDsc = "";
         P007N5_A167CobCod = new string[] {""} ;
         P007N5_A143ForCod = new int[1] ;
         P007N5_A661CobSts = new string[] {""} ;
         P007N5_A176CobDocNum = new string[] {""} ;
         P007N5_A171CobVendCod = new int[1] ;
         P007N5_A175CobTipCod = new string[] {""} ;
         P007N5_A172CobMon = new int[1] ;
         P007N5_A645CobCliCod = new string[] {""} ;
         P007N5_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         P007N5_A166CobTip = new string[] {""} ;
         P007N5_A654CobDTot = new decimal[1] ;
         P007N5_A663CobTipCam = new decimal[1] ;
         P007N5_A173Item = new int[1] ;
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV26Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas.r_resumencobranzapdf__default(),
            new Object[][] {
                new Object[] {
               P007N2_A309VenCod, P007N2_A2045VenDsc
               }
               , new Object[] {
               P007N3_A661CobSts, P007N3_A176CobDocNum, P007N3_A171CobVendCod, P007N3_A175CobTipCod, P007N3_A172CobMon, P007N3_A143ForCod, P007N3_A645CobCliCod, P007N3_A655CobFec, P007N3_A166CobTip, P007N3_A663CobTipCam,
               P007N3_A654CobDTot, P007N3_A508CCFVcto, P007N3_n508CCFVcto, P007N3_A190CCFech, P007N3_n190CCFech, P007N3_A646CobCliDsc, P007N3_A167CobCod, P007N3_A656CobMonAbr, P007N3_A659CobRef, P007N3_A988ForDsc,
               P007N3_A306TipAbr, P007N3_n306TipAbr, P007N3_A173Item
               }
               , new Object[] {
               P007N4_A143ForCod, P007N4_A988ForDsc
               }
               , new Object[] {
               P007N5_A167CobCod, P007N5_A143ForCod, P007N5_A661CobSts, P007N5_A176CobDocNum, P007N5_A171CobVendCod, P007N5_A175CobTipCod, P007N5_A172CobMon, P007N5_A645CobCliCod, P007N5_A655CobFec, P007N5_A166CobTip,
               P007N5_A654CobDTot, P007N5_A663CobTipCam, P007N5_A173Item
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
      private short AV25LenSerie ;
      private int AV21ForCod1 ;
      private int AV27MonCod ;
      private int AV39VenCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A309VenCod ;
      private int A143ForCod ;
      private int A172CobMon ;
      private int A171CobVendCod ;
      private int A173Item ;
      private int GXt_int2 ;
      private int Gx_OldLine ;
      private int AV20ForCod ;
      private decimal AV36TotMN ;
      private decimal AV35TotME ;
      private decimal A663CobTipCam ;
      private decimal A654CobDTot ;
      private decimal AV32TipVenta ;
      private decimal GXt_decimal1 ;
      private decimal AV9CobDTot ;
      private decimal AV12CobMN ;
      private decimal AV11CobME ;
      private decimal AV38TTotalMN ;
      private decimal AV37TTotalME ;
      private decimal AV34TotalMN ;
      private decimal AV33TotalME ;
      private decimal AV13CobTipCam ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV8CliCod ;
      private string AV31TipCod ;
      private string AV15Empresa ;
      private string AV14EmpDir ;
      private string AV16EmpRUC ;
      private string AV28Ruta ;
      private string AV19Filtro1 ;
      private string scmdbuf ;
      private string A2045VenDsc ;
      private string A166CobTip ;
      private string A645CobCliCod ;
      private string A175CobTipCod ;
      private string A176CobDocNum ;
      private string A661CobSts ;
      private string A646CobCliDsc ;
      private string A167CobCod ;
      private string A656CobMonAbr ;
      private string A659CobRef ;
      private string A988ForDsc ;
      private string A306TipAbr ;
      private string GXt_char3 ;
      private string AV22ForDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV17FDesde ;
      private DateTime AV18FHasta ;
      private DateTime A655CobFec ;
      private DateTime A508CCFVcto ;
      private DateTime A190CCFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n508CCFVcto ;
      private bool n190CCFech ;
      private bool n306TipAbr ;
      private string AV29Serie ;
      private string AV42Logo_GXI ;
      private string AV26Logo ;
      private string Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FDesde ;
      private DateTime aP1_FHasta ;
      private string aP2_CliCod ;
      private int aP3_ForCod1 ;
      private int aP4_MonCod ;
      private string aP5_TipCod ;
      private string aP6_Serie ;
      private int aP7_VenCod ;
      private IDataStoreProvider pr_default ;
      private int[] P007N2_A309VenCod ;
      private string[] P007N2_A2045VenDsc ;
      private string[] P007N3_A661CobSts ;
      private string[] P007N3_A176CobDocNum ;
      private int[] P007N3_A171CobVendCod ;
      private string[] P007N3_A175CobTipCod ;
      private int[] P007N3_A172CobMon ;
      private int[] P007N3_A143ForCod ;
      private string[] P007N3_A645CobCliCod ;
      private DateTime[] P007N3_A655CobFec ;
      private string[] P007N3_A166CobTip ;
      private decimal[] P007N3_A663CobTipCam ;
      private decimal[] P007N3_A654CobDTot ;
      private DateTime[] P007N3_A508CCFVcto ;
      private bool[] P007N3_n508CCFVcto ;
      private DateTime[] P007N3_A190CCFech ;
      private bool[] P007N3_n190CCFech ;
      private string[] P007N3_A646CobCliDsc ;
      private string[] P007N3_A167CobCod ;
      private string[] P007N3_A656CobMonAbr ;
      private string[] P007N3_A659CobRef ;
      private string[] P007N3_A988ForDsc ;
      private string[] P007N3_A306TipAbr ;
      private bool[] P007N3_n306TipAbr ;
      private int[] P007N3_A173Item ;
      private int[] P007N4_A143ForCod ;
      private string[] P007N4_A988ForDsc ;
      private string[] P007N5_A167CobCod ;
      private int[] P007N5_A143ForCod ;
      private string[] P007N5_A661CobSts ;
      private string[] P007N5_A176CobDocNum ;
      private int[] P007N5_A171CobVendCod ;
      private string[] P007N5_A175CobTipCod ;
      private int[] P007N5_A172CobMon ;
      private string[] P007N5_A645CobCliCod ;
      private DateTime[] P007N5_A655CobFec ;
      private string[] P007N5_A166CobTip ;
      private decimal[] P007N5_A654CobDTot ;
      private decimal[] P007N5_A663CobTipCam ;
      private int[] P007N5_A173Item ;
   }

   public class r_resumencobranzapdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007N3( IGxContext context ,
                                             string AV31TipCod ,
                                             string AV8CliCod ,
                                             int AV21ForCod1 ,
                                             int AV27MonCod ,
                                             int AV39VenCod ,
                                             short AV25LenSerie ,
                                             string A166CobTip ,
                                             string A645CobCliCod ,
                                             int A143ForCod ,
                                             int A172CobMon ,
                                             string A175CobTipCod ,
                                             int A171CobVendCod ,
                                             string A176CobDocNum ,
                                             string AV29Serie ,
                                             string A661CobSts ,
                                             DateTime AV17FDesde ,
                                             DateTime A655CobFec ,
                                             DateTime AV18FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T5.[CobSts], T1.[CobDocNum] AS CobDocNum, T5.[CobVendCod], T1.[CobTipCod] AS CobTipCod, T5.[CobMon] AS CobMon, T1.[ForCod], T2.[CCCliCod] AS CobCliCod, T5.[CobFec], T1.[CobTip], T1.[CobTipCam], T1.[CobDTot], T2.[CCFVcto], T2.[CCFech], T2.[CCCliDsc] AS CobCliDsc, T1.[CobCod], T6.[MonAbr] AS CobMonAbr, T1.[CobRef], T4.[ForDsc], T3.[TipAbr], T1.[Item] FROM ((((([CLCOBRANZADET] T1 INNER JOIN [CLCUENTACOBRAR] T2 ON T2.[CCTipCod] = T1.[CobTipCod] AND T2.[CCDocNum] = T1.[CobDocNum]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CobTipCod]) INNER JOIN [CFORMAPAGO] T4 ON T4.[ForCod] = T1.[ForCod]) INNER JOIN [CLCOBRANZA] T5 ON T5.[CobTip] = T1.[CobTip] AND T5.[CobCod] = T1.[CobCod]) INNER JOIN [CMONEDAS] T6 ON T6.[MonCod] = T5.[CobMon])";
         AddWhere(sWhereString, "(T5.[CobFec] >= @AV17FDesde)");
         AddWhere(sWhereString, "((T5.[CobSts] = ''))");
         AddWhere(sWhereString, "(T5.[CobFec] <= @AV18FHasta)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CobTip] = 'C')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[CCCliCod] = @AV8CliCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV21ForCod1) )
         {
            AddWhere(sWhereString, "(T1.[ForCod] = @AV21ForCod1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV27MonCod) )
         {
            AddWhere(sWhereString, "(T5.[CobMon] = @AV27MonCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CobTipCod] = @AV31TipCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV39VenCod) )
         {
            AddWhere(sWhereString, "(T5.[CobVendCod] = @AV39VenCod)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV25LenSerie) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CobDocNum], 1, @AV25LenSerie) = @AV29Serie)");
         }
         else
         {
            GXv_int4[7] = 1;
            GXv_int4[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T5.[CobFec], T1.[CobTipCod], T1.[CobDocNum]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P007N4( IGxContext context ,
                                             int AV21ForCod1 ,
                                             int A143ForCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[1];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [ForCod], [ForDsc] FROM [CFORMAPAGO]";
         if ( ! (0==AV21ForCod1) )
         {
            AddWhere(sWhereString, "([ForCod] = @AV21ForCod1)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ForCod]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P007N5( IGxContext context ,
                                             string AV31TipCod ,
                                             string AV8CliCod ,
                                             int AV27MonCod ,
                                             int AV39VenCod ,
                                             short AV25LenSerie ,
                                             string A166CobTip ,
                                             string A645CobCliCod ,
                                             int A172CobMon ,
                                             string A175CobTipCod ,
                                             int A171CobVendCod ,
                                             string A176CobDocNum ,
                                             string AV29Serie ,
                                             string A661CobSts ,
                                             int A143ForCod ,
                                             int AV20ForCod ,
                                             DateTime AV17FDesde ,
                                             DateTime A655CobFec ,
                                             DateTime AV18FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[9];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[CobCod], T1.[ForCod], T3.[CobSts], T1.[CobDocNum] AS CobDocNum, T3.[CobVendCod], T1.[CobTipCod] AS CobTipCod, T3.[CobMon] AS CobMon, T2.[CCCliCod] AS CobCliCod, T3.[CobFec], T1.[CobTip], T1.[CobDTot], T1.[CobTipCam], T1.[Item] FROM (([CLCOBRANZADET] T1 INNER JOIN [CLCUENTACOBRAR] T2 ON T2.[CCTipCod] = T1.[CobTipCod] AND T2.[CCDocNum] = T1.[CobDocNum]) INNER JOIN [CLCOBRANZA] T3 ON T3.[CobTip] = T1.[CobTip] AND T3.[CobCod] = T1.[CobCod])";
         AddWhere(sWhereString, "(T3.[CobFec] >= @AV17FDesde)");
         AddWhere(sWhereString, "((T3.[CobSts] = ''))");
         AddWhere(sWhereString, "(T1.[ForCod] = @AV20ForCod)");
         AddWhere(sWhereString, "(T3.[CobFec] <= @AV18FHasta)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CobTip] = 'C')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[CCCliCod] = @AV8CliCod)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! (0==AV27MonCod) )
         {
            AddWhere(sWhereString, "(T3.[CobMon] = @AV27MonCod)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CobTipCod] = @AV31TipCod)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (0==AV39VenCod) )
         {
            AddWhere(sWhereString, "(T3.[CobVendCod] = @AV39VenCod)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! (0==AV25LenSerie) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CobDocNum], 1, @AV25LenSerie) = @AV29Serie)");
         }
         else
         {
            GXv_int8[7] = 1;
            GXv_int8[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[CobFec], T1.[CobTipCod], T1.[CobDocNum]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P007N3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] );
               case 2 :
                     return conditional_P007N4(context, (int)dynConstraints[0] , (int)dynConstraints[1] );
               case 3 :
                     return conditional_P007N5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] );
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
          Object[] prmP007N2;
          prmP007N2 = new Object[] {
          new ParDef("@AV39VenCod",GXType.Int32,6,0)
          };
          Object[] prmP007N3;
          prmP007N3 = new Object[] {
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV18FHasta",GXType.Date,8,0) ,
          new ParDef("@AV8CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV21ForCod1",GXType.Int32,6,0) ,
          new ParDef("@AV27MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV31TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV39VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV25LenSerie",GXType.Int16,1,0) ,
          new ParDef("@AV29Serie",GXType.VarChar,4,0)
          };
          Object[] prmP007N4;
          prmP007N4 = new Object[] {
          new ParDef("@AV21ForCod1",GXType.Int32,6,0)
          };
          Object[] prmP007N5;
          prmP007N5 = new Object[] {
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV20ForCod",GXType.Int32,6,0) ,
          new ParDef("@AV18FHasta",GXType.Date,8,0) ,
          new ParDef("@AV8CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV27MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV31TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV39VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV25LenSerie",GXType.Int16,1,0) ,
          new ParDef("@AV29Serie",GXType.VarChar,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007N2", "SELECT [VenCod], [VenDsc] FROM [CVENDEDORES] WHERE [VenCod] = @AV39VenCod ORDER BY [VenCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007N2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007N3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007N4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007N4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007N5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007N5,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 1);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                ((string[]) buf[15])[0] = rslt.getString(14, 100);
                ((string[]) buf[16])[0] = rslt.getString(15, 12);
                ((string[]) buf[17])[0] = rslt.getString(16, 5);
                ((string[]) buf[18])[0] = rslt.getString(17, 20);
                ((string[]) buf[19])[0] = rslt.getString(18, 100);
                ((string[]) buf[20])[0] = rslt.getString(19, 5);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((int[]) buf[22])[0] = rslt.getInt(20);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 12);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 1);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((int[]) buf[12])[0] = rslt.getInt(13);
                return;
       }
    }

 }

}
