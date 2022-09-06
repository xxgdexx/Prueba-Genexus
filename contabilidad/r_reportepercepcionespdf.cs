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
   public class r_reportepercepcionespdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_reportepercepcionespdf.aspx")), "contabilidad.r_reportepercepcionespdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_reportepercepcionespdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "TipCCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8TipCCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10CliCod = GetPar( "CliCod");
                  AV14FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV15FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public r_reportepercepcionespdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reportepercepcionespdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TipCCod ,
                           ref string aP1_CliCod ,
                           ref DateTime aP2_FDesde ,
                           ref DateTime aP3_FHasta )
      {
         this.AV8TipCCod = aP0_TipCCod;
         this.AV10CliCod = aP1_CliCod;
         this.AV14FDesde = aP2_FDesde;
         this.AV15FHasta = aP3_FHasta;
         initialize();
         executePrivate();
         aP0_TipCCod=this.AV8TipCCod;
         aP1_CliCod=this.AV10CliCod;
         aP2_FDesde=this.AV14FDesde;
         aP3_FHasta=this.AV15FHasta;
      }

      public DateTime executeUdp( ref int aP0_TipCCod ,
                                  ref string aP1_CliCod ,
                                  ref DateTime aP2_FDesde )
      {
         execute(ref aP0_TipCCod, ref aP1_CliCod, ref aP2_FDesde, ref aP3_FHasta);
         return AV15FHasta ;
      }

      public void executeSubmit( ref int aP0_TipCCod ,
                                 ref string aP1_CliCod ,
                                 ref DateTime aP2_FDesde ,
                                 ref DateTime aP3_FHasta )
      {
         r_reportepercepcionespdf objr_reportepercepcionespdf;
         objr_reportepercepcionespdf = new r_reportepercepcionespdf();
         objr_reportepercepcionespdf.AV8TipCCod = aP0_TipCCod;
         objr_reportepercepcionespdf.AV10CliCod = aP1_CliCod;
         objr_reportepercepcionespdf.AV14FDesde = aP2_FDesde;
         objr_reportepercepcionespdf.AV15FHasta = aP3_FHasta;
         objr_reportepercepcionespdf.context.SetSubmitInitialConfig(context);
         objr_reportepercepcionespdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reportepercepcionespdf);
         aP0_TipCCod=this.AV8TipCCod;
         aP1_CliCod=this.AV10CliCod;
         aP2_FDesde=this.AV14FDesde;
         aP3_FHasta=this.AV15FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reportepercepcionespdf)stateInfo).executePrivate();
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
            AV39Empresa = AV43Session.Get("Empresa");
            AV40EmpDir = AV43Session.Get("EmpDir");
            AV41EmpRUC = AV43Session.Get("EmpRUC");
            AV42Ruta = AV43Session.Get("RUTA") + "/Logo.jpg";
            AV38Logo = AV42Ruta;
            AV68Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV27TotalGeneral = 0.00m;
            AV33TotalSub = 0.00m;
            AV34TotalIVA = 0.00m;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8TipCCod ,
                                                 AV10CliCod ,
                                                 A159TipCCod ,
                                                 A221PerCliCod ,
                                                 A1617PerFec ,
                                                 AV14FDesde ,
                                                 AV15FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P009B2 */
            pr_default.execute(0, new Object[] {AV14FDesde, AV15FHasta, AV8TipCCod, AV10CliCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A220PerTDoc = P009B2_A220PerTDoc[0];
               A219PerTip = P009B2_A219PerTip[0];
               A218PerCod = P009B2_A218PerCod[0];
               A1617PerFec = P009B2_A1617PerFec[0];
               A221PerCliCod = P009B2_A221PerCliCod[0];
               A159TipCCod = P009B2_A159TipCCod[0];
               n159TipCCod = P009B2_n159TipCCod[0];
               A1616PerCliDsc = P009B2_A1616PerCliDsc[0];
               A1620PerSts = P009B2_A1620PerSts[0];
               A159TipCCod = P009B2_A159TipCCod[0];
               n159TipCCod = P009B2_n159TipCCod[0];
               A1616PerCliDsc = P009B2_A1616PerCliDsc[0];
               AV54PerCod = A218PerCod;
               AV51PerCliCod = A221PerCliCod;
               AV55PerFec = A1617PerFec;
               AV50PerCliDsc = A1616PerCliDsc;
               AV52ImpTPer = 0.00m;
               AV53ImpTMN = 0.00m;
               AV65ImpTPV = 0.00m;
               AV63PerSts = A1620PerSts;
               /* Using cursor P009B3 */
               pr_default.execute(1, new Object[] {A219PerTip, A218PerCod, A220PerTDoc});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A222PerTipCod = P009B3_A222PerTipCod[0];
                  A149TipCod = P009B3_A149TipCod[0];
                  A190CCFech = P009B3_A190CCFech[0];
                  n190CCFech = P009B3_n190CCFech[0];
                  A187CCmonCod = P009B3_A187CCmonCod[0];
                  n187CCmonCod = P009B3_n187CCmonCod[0];
                  A223PerDocNum = P009B3_A223PerDocNum[0];
                  A511TipSigno = P009B3_A511TipSigno[0];
                  A513CCImpTotal = P009B3_A513CCImpTotal[0];
                  n513CCImpTotal = P009B3_n513CCImpTotal[0];
                  A1619PerImpPer = P009B3_A1619PerImpPer[0];
                  A511TipSigno = P009B3_A511TipSigno[0];
                  A190CCFech = P009B3_A190CCFech[0];
                  n190CCFech = P009B3_n190CCFech[0];
                  A187CCmonCod = P009B3_A187CCmonCod[0];
                  n187CCmonCod = P009B3_n187CCmonCod[0];
                  A513CCImpTotal = P009B3_A513CCImpTotal[0];
                  n513CCImpTotal = P009B3_n513CCImpTotal[0];
                  AV56CCFech = A190CCFech;
                  AV57CCMonCod = A187CCmonCod;
                  GXt_decimal1 = AV58TipVenta;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV57CCMonCod, ref  AV56CCFech, ref  GXt_char2, out  GXt_decimal1) ;
                  AV58TipVenta = GXt_decimal1;
                  AV59Numero = StringUtil.Substring( A223PerDocNum, 1, 3) + " - " + StringUtil.Substring( A223PerDocNum, 4, 7);
                  AV60ImpMO = (decimal)(A513CCImpTotal*A511TipSigno);
                  AV61ImpMN = (decimal)(AV60ImpMO*(!(AV57CCMonCod==1) ? AV58TipVenta : (decimal)(1)));
                  AV62ImpPer = (decimal)(A1619PerImpPer*(!(AV57CCMonCod==1) ? AV58TipVenta : (decimal)(1)));
                  AV64ImpPV = (decimal)(AV61ImpMN+AV62ImpPer);
                  AV52ImpTPer = (decimal)(AV52ImpTPer+AV62ImpPer);
                  AV53ImpTMN = (decimal)(AV53ImpTMN+AV61ImpMN);
                  AV65ImpTPV = (decimal)(AV65ImpTPV+AV64ImpPV);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               if ( StringUtil.StrCmp(AV63PerSts, "A") == 0 )
               {
                  AV51PerCliCod = "";
                  AV50PerCliDsc = "Anulado";
                  AV53ImpTMN = 0.00m;
                  AV52ImpTPer = 0.00m;
                  AV65ImpTPV = 0.00m;
               }
               H9B0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50PerCliDsc, "")), 231, Gx_line+2, 469, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65ImpTPV, "ZZZZZZ,ZZZ,ZZ9.99")), 680, Gx_line+1, 787, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54PerCod, "")), 9, Gx_line+1, 62, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV55PerFec, "99/99/99"), 89, Gx_line+1, 136, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52ImpTPer, "ZZZZZZ,ZZZ,ZZ9.99")), 574, Gx_line+1, 681, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53ImpTMN, "ZZZZZZ,ZZZ,ZZ9.99")), 468, Gx_line+1, 575, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51PerCliCod, "")), 142, Gx_line+1, 226, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV33TotalSub = (decimal)(AV33TotalSub+AV53ImpTMN);
               AV34TotalIVA = (decimal)(AV34TotalIVA+AV52ImpTPer);
               AV27TotalGeneral = (decimal)(AV27TotalGeneral+AV65ImpTPV);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            H9B0( false, 65) ;
            getPrinter().GxDrawLine(439, Gx_line+9, 778, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 320, Gx_line+15, 400, Gx_line+29, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27TotalGeneral, "ZZZZZZZZZ,ZZ9.99")), 688, Gx_line+16, 789, Gx_line+31, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34TotalIVA, "ZZZZZZ,ZZZ,ZZ9.99")), 574, Gx_line+16, 681, Gx_line+31, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33TotalSub, "ZZZZZZ,ZZZ,ZZ9.99")), 468, Gx_line+16, 575, Gx_line+31, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+65);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9B0( true, 0) ;
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

      protected void H9B0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 702, Gx_line+49, 734, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 702, Gx_line+69, 746, Gx_line+83, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 702, Gx_line+30, 741, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Reporte de Percepciones", 292, Gx_line+41, 523, Gx_line+60, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+131, 808, Gx_line+157, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 751, Gx_line+30, 798, Gx_line+45, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 736, Gx_line+49, 796, Gx_line+63, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 759, Gx_line+69, 798, Gx_line+84, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cliente", 233, Gx_line+138, 275, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Cobrado", 709, Gx_line+138, 792, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 281, Gx_line+70, 318, Gx_line+84, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV14FDesde, "99/99/99"), 331, Gx_line+65, 405, Gx_line+89, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 416, Gx_line+70, 451, Gx_line+84, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV15FHasta, "99/99/99"), 460, Gx_line+65, 534, Gx_line+89, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Percepción", 5, Gx_line+138, 87, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 94, Gx_line+138, 129, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Monto Pago", 500, Gx_line+138, 571, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Imp. Percepción", 598, Gx_line+138, 694, Gx_line+152, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV38Logo)) ? AV68Logo_GXI : AV38Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+11, 167, Gx_line+89) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Empresa, "")), 9, Gx_line+93, 377, Gx_line+111, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41EmpRUC, "")), 9, Gx_line+110, 238, Gx_line+128, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("R.U.C.", 155, Gx_line+138, 189, Gx_line+152, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+157);
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
         add_metrics2( ) ;
         add_metrics3( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Verdana", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics3( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
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
         AV39Empresa = "";
         AV43Session = context.GetSession();
         AV40EmpDir = "";
         AV41EmpRUC = "";
         AV42Ruta = "";
         AV38Logo = "";
         AV68Logo_GXI = "";
         scmdbuf = "";
         A221PerCliCod = "";
         A1617PerFec = DateTime.MinValue;
         P009B2_A220PerTDoc = new string[] {""} ;
         P009B2_A219PerTip = new string[] {""} ;
         P009B2_A218PerCod = new string[] {""} ;
         P009B2_A1617PerFec = new DateTime[] {DateTime.MinValue} ;
         P009B2_A221PerCliCod = new string[] {""} ;
         P009B2_A159TipCCod = new int[1] ;
         P009B2_n159TipCCod = new bool[] {false} ;
         P009B2_A1616PerCliDsc = new string[] {""} ;
         P009B2_A1620PerSts = new string[] {""} ;
         A220PerTDoc = "";
         A219PerTip = "";
         A218PerCod = "";
         A1616PerCliDsc = "";
         A1620PerSts = "";
         AV54PerCod = "";
         AV51PerCliCod = "";
         AV55PerFec = DateTime.MinValue;
         AV50PerCliDsc = "";
         AV63PerSts = "";
         P009B3_A222PerTipCod = new string[] {""} ;
         P009B3_A149TipCod = new string[] {""} ;
         P009B3_A218PerCod = new string[] {""} ;
         P009B3_A219PerTip = new string[] {""} ;
         P009B3_A220PerTDoc = new string[] {""} ;
         P009B3_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P009B3_n190CCFech = new bool[] {false} ;
         P009B3_A187CCmonCod = new int[1] ;
         P009B3_n187CCmonCod = new bool[] {false} ;
         P009B3_A223PerDocNum = new string[] {""} ;
         P009B3_A511TipSigno = new short[1] ;
         P009B3_A513CCImpTotal = new decimal[1] ;
         P009B3_n513CCImpTotal = new bool[] {false} ;
         P009B3_A1619PerImpPer = new decimal[1] ;
         A222PerTipCod = "";
         A149TipCod = "";
         A190CCFech = DateTime.MinValue;
         A223PerDocNum = "";
         AV56CCFech = DateTime.MinValue;
         GXt_char2 = "";
         AV59Numero = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV38Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_reportepercepcionespdf__default(),
            new Object[][] {
                new Object[] {
               P009B2_A220PerTDoc, P009B2_A219PerTip, P009B2_A218PerCod, P009B2_A1617PerFec, P009B2_A221PerCliCod, P009B2_A159TipCCod, P009B2_n159TipCCod, P009B2_A1616PerCliDsc, P009B2_A1620PerSts
               }
               , new Object[] {
               P009B3_A222PerTipCod, P009B3_A149TipCod, P009B3_A218PerCod, P009B3_A219PerTip, P009B3_A220PerTDoc, P009B3_A190CCFech, P009B3_n190CCFech, P009B3_A187CCmonCod, P009B3_n187CCmonCod, P009B3_A223PerDocNum,
               P009B3_A511TipSigno, P009B3_A513CCImpTotal, P009B3_n513CCImpTotal, P009B3_A1619PerImpPer
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
      private short A511TipSigno ;
      private int AV8TipCCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A159TipCCod ;
      private int A187CCmonCod ;
      private int AV57CCMonCod ;
      private int Gx_OldLine ;
      private decimal AV27TotalGeneral ;
      private decimal AV33TotalSub ;
      private decimal AV34TotalIVA ;
      private decimal AV52ImpTPer ;
      private decimal AV53ImpTMN ;
      private decimal AV65ImpTPV ;
      private decimal A513CCImpTotal ;
      private decimal A1619PerImpPer ;
      private decimal AV58TipVenta ;
      private decimal GXt_decimal1 ;
      private decimal AV60ImpMO ;
      private decimal AV61ImpMN ;
      private decimal AV62ImpPer ;
      private decimal AV64ImpPV ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10CliCod ;
      private string AV39Empresa ;
      private string AV40EmpDir ;
      private string AV41EmpRUC ;
      private string AV42Ruta ;
      private string scmdbuf ;
      private string A221PerCliCod ;
      private string A219PerTip ;
      private string A218PerCod ;
      private string A1616PerCliDsc ;
      private string A1620PerSts ;
      private string AV54PerCod ;
      private string AV51PerCliCod ;
      private string AV50PerCliDsc ;
      private string AV63PerSts ;
      private string A222PerTipCod ;
      private string A149TipCod ;
      private string A223PerDocNum ;
      private string GXt_char2 ;
      private string AV59Numero ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV14FDesde ;
      private DateTime AV15FHasta ;
      private DateTime A1617PerFec ;
      private DateTime AV55PerFec ;
      private DateTime A190CCFech ;
      private DateTime AV56CCFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n159TipCCod ;
      private bool n190CCFech ;
      private bool n187CCmonCod ;
      private bool n513CCImpTotal ;
      private string AV68Logo_GXI ;
      private string A220PerTDoc ;
      private string AV38Logo ;
      private string Logo ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TipCCod ;
      private string aP1_CliCod ;
      private DateTime aP2_FDesde ;
      private DateTime aP3_FHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P009B2_A220PerTDoc ;
      private string[] P009B2_A219PerTip ;
      private string[] P009B2_A218PerCod ;
      private DateTime[] P009B2_A1617PerFec ;
      private string[] P009B2_A221PerCliCod ;
      private int[] P009B2_A159TipCCod ;
      private bool[] P009B2_n159TipCCod ;
      private string[] P009B2_A1616PerCliDsc ;
      private string[] P009B2_A1620PerSts ;
      private string[] P009B3_A222PerTipCod ;
      private string[] P009B3_A149TipCod ;
      private string[] P009B3_A218PerCod ;
      private string[] P009B3_A219PerTip ;
      private string[] P009B3_A220PerTDoc ;
      private DateTime[] P009B3_A190CCFech ;
      private bool[] P009B3_n190CCFech ;
      private int[] P009B3_A187CCmonCod ;
      private bool[] P009B3_n187CCmonCod ;
      private string[] P009B3_A223PerDocNum ;
      private short[] P009B3_A511TipSigno ;
      private decimal[] P009B3_A513CCImpTotal ;
      private bool[] P009B3_n513CCImpTotal ;
      private decimal[] P009B3_A1619PerImpPer ;
   }

   public class r_reportepercepcionespdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009B2( IGxContext context ,
                                             int AV8TipCCod ,
                                             string AV10CliCod ,
                                             int A159TipCCod ,
                                             string A221PerCliCod ,
                                             DateTime A1617PerFec ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[PerTDoc], T1.[PerTip], T1.[PerCod], T1.[PerFec], T1.[PerCliCod] AS PerCliCod, T2.[TipCCod], T2.[CliDsc] AS PerCliDsc, T1.[PerSts] FROM ([CLPERCEPCION] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[PerCliCod])";
         AddWhere(sWhereString, "(T1.[PerFec] >= @AV14FDesde and T1.[PerFec] <= @AV15FHasta)");
         if ( ! (0==AV8TipCCod) )
         {
            AddWhere(sWhereString, "(T2.[TipCCod] = @AV8TipCCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[PerCliCod] = @AV10CliCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PerCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P009B2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] );
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
          Object[] prmP009B3;
          prmP009B3 = new Object[] {
          new ParDef("@PerTip",GXType.NChar,3,0) ,
          new ParDef("@PerCod",GXType.NChar,10,0) ,
          new ParDef("@PerTDoc",GXType.NVarChar,3,0)
          };
          Object[] prmP009B2;
          prmP009B2 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV8TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV10CliCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009B3", "SELECT T1.[PerTipCod] AS PerTipCod, T2.[TipCod], T1.[PerCod], T1.[PerTip], T1.[PerTDoc], T3.[CCFech], T3.[CCmonCod], T1.[PerDocNum] AS PerDocNum, T2.[TipSigno], T3.[CCImpTotal], T1.[PerImpPer] FROM (([CLPERCEPCIONDET] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[PerTipCod]) INNER JOIN [CLCUENTACOBRAR] T3 ON T3.[CCTipCod] = T1.[PerTipCod] AND T3.[CCDocNum] = T1.[PerDocNum]) WHERE T1.[PerTip] = @PerTip and T1.[PerCod] = @PerCod and T1.[PerTDoc] = @PerTDoc ORDER BY T1.[PerTip], T1.[PerCod], T1.[PerTDoc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009B3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((string[]) buf[8])[0] = rslt.getString(8, 1);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 12);
                ((short[]) buf[10])[0] = rslt.getShort(9);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(11);
                return;
       }
    }

 }

}
