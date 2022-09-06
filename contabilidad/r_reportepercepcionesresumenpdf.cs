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
   public class r_reportepercepcionesresumenpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_reportepercepcionesresumenpdf.aspx")), "contabilidad.r_reportepercepcionesresumenpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_reportepercepcionesresumenpdf.aspx")))) ;
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

      public r_reportepercepcionesresumenpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reportepercepcionesresumenpdf( IGxContext context )
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
         r_reportepercepcionesresumenpdf objr_reportepercepcionesresumenpdf;
         objr_reportepercepcionesresumenpdf = new r_reportepercepcionesresumenpdf();
         objr_reportepercepcionesresumenpdf.AV8TipCCod = aP0_TipCCod;
         objr_reportepercepcionesresumenpdf.AV10CliCod = aP1_CliCod;
         objr_reportepercepcionesresumenpdf.AV14FDesde = aP2_FDesde;
         objr_reportepercepcionesresumenpdf.AV15FHasta = aP3_FHasta;
         objr_reportepercepcionesresumenpdf.context.SetSubmitInitialConfig(context);
         objr_reportepercepcionesresumenpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reportepercepcionesresumenpdf);
         aP0_TipCCod=this.AV8TipCCod;
         aP1_CliCod=this.AV10CliCod;
         aP2_FDesde=this.AV14FDesde;
         aP3_FHasta=this.AV15FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reportepercepcionesresumenpdf)stateInfo).executePrivate();
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
            AV66Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV27TotalGeneral = 0.00m;
            AV33TotalSub = 0.00m;
            AV34TotalIVA = 0.00m;
            AV52ImpTPer = 0.00m;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8TipCCod ,
                                                 AV10CliCod ,
                                                 A159TipCCod ,
                                                 A221PerCliCod ,
                                                 A1617PerFec ,
                                                 AV14FDesde ,
                                                 AV15FHasta ,
                                                 A1620PerSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00ED2 */
            pr_default.execute(0, new Object[] {AV14FDesde, AV15FHasta, AV8TipCCod, AV10CliCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKED3 = false;
               A1616PerCliDsc = P00ED2_A1616PerCliDsc[0];
               A221PerCliCod = P00ED2_A221PerCliCod[0];
               A1620PerSts = P00ED2_A1620PerSts[0];
               A1617PerFec = P00ED2_A1617PerFec[0];
               A159TipCCod = P00ED2_A159TipCCod[0];
               n159TipCCod = P00ED2_n159TipCCod[0];
               A218PerCod = P00ED2_A218PerCod[0];
               A219PerTip = P00ED2_A219PerTip[0];
               A220PerTDoc = P00ED2_A220PerTDoc[0];
               A1616PerCliDsc = P00ED2_A1616PerCliDsc[0];
               A159TipCCod = P00ED2_A159TipCCod[0];
               n159TipCCod = P00ED2_n159TipCCod[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00ED2_A221PerCliCod[0], A221PerCliCod) == 0 ) )
               {
                  BRKED3 = false;
                  A1616PerCliDsc = P00ED2_A1616PerCliDsc[0];
                  A218PerCod = P00ED2_A218PerCod[0];
                  A219PerTip = P00ED2_A219PerTip[0];
                  A220PerTDoc = P00ED2_A220PerTDoc[0];
                  A1616PerCliDsc = P00ED2_A1616PerCliDsc[0];
                  BRKED3 = true;
                  pr_default.readNext(0);
               }
               AV51PerCliCod = A221PerCliCod;
               AV50PerCliDsc = A1616PerCliDsc;
               AV52ImpTPer = 0.00m;
               /* Execute user subroutine: 'DETALLEPERCEPCIONES' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! (Convert.ToDecimal(0)==AV52ImpTPer) )
               {
                  HED0( false, 19) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50PerCliDsc, "")), 156, Gx_line+3, 559, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52ImpTPer, "ZZZZZZ,ZZZ,ZZ9.99")), 577, Gx_line+2, 684, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51PerCliCod, "")), 15, Gx_line+2, 120, Gx_line+17, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
               AV34TotalIVA = (decimal)(AV34TotalIVA+AV52ImpTPer);
               if ( ! BRKED3 )
               {
                  BRKED3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HED0( false, 65) ;
            getPrinter().GxDrawLine(566, Gx_line+9, 698, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 456, Gx_line+16, 536, Gx_line+30, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34TotalIVA, "ZZZZZZ,ZZZ,ZZ9.99")), 577, Gx_line+16, 684, Gx_line+31, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+65);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HED0( true, 0) ;
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
         /* 'DETALLEPERCEPCIONES' Routine */
         returnInSub = false;
         /* Using cursor P00ED3 */
         pr_default.execute(1, new Object[] {AV14FDesde, AV15FHasta, AV51PerCliCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A218PerCod = P00ED3_A218PerCod[0];
            A219PerTip = P00ED3_A219PerTip[0];
            A220PerTDoc = P00ED3_A220PerTDoc[0];
            A222PerTipCod = P00ED3_A222PerTipCod[0];
            A223PerDocNum = P00ED3_A223PerDocNum[0];
            A1620PerSts = P00ED3_A1620PerSts[0];
            A1617PerFec = P00ED3_A1617PerFec[0];
            A221PerCliCod = P00ED3_A221PerCliCod[0];
            A190CCFech = P00ED3_A190CCFech[0];
            n190CCFech = P00ED3_n190CCFech[0];
            A187CCmonCod = P00ED3_A187CCmonCod[0];
            n187CCmonCod = P00ED3_n187CCmonCod[0];
            A1619PerImpPer = P00ED3_A1619PerImpPer[0];
            A1620PerSts = P00ED3_A1620PerSts[0];
            A1617PerFec = P00ED3_A1617PerFec[0];
            A221PerCliCod = P00ED3_A221PerCliCod[0];
            A190CCFech = P00ED3_A190CCFech[0];
            n190CCFech = P00ED3_n190CCFech[0];
            A187CCmonCod = P00ED3_A187CCmonCod[0];
            n187CCmonCod = P00ED3_n187CCmonCod[0];
            AV56CCFech = A190CCFech;
            AV57CCMonCod = A187CCmonCod;
            GXt_decimal1 = AV58TipVenta;
            GXt_char2 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV57CCMonCod, ref  AV56CCFech, ref  GXt_char2, out  GXt_decimal1) ;
            AV58TipVenta = GXt_decimal1;
            AV62ImpPer = (decimal)(A1619PerImpPer*(!(AV57CCMonCod==1) ? AV58TipVenta : (decimal)(1)));
            AV52ImpTPer = (decimal)(AV52ImpTPer+AV62ImpPer);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void HED0( bool bFoot ,
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
               getPrinter().GxDrawText("REGISTRO DE RÉGIMEN DE PERCEPCIONES", 234, Gx_line+41, 638, Gx_line+60, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+131, 808, Gx_line+157, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 751, Gx_line+30, 798, Gx_line+45, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 736, Gx_line+49, 796, Gx_line+63, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 759, Gx_line+69, 798, Gx_line+84, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Razon Social", 158, Gx_line+138, 233, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 281, Gx_line+70, 318, Gx_line+84, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV14FDesde, "99/99/99"), 331, Gx_line+65, 405, Gx_line+89, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 416, Gx_line+70, 451, Gx_line+84, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV15FHasta, "99/99/99"), 460, Gx_line+65, 534, Gx_line+89, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Monto S/.", 601, Gx_line+138, 659, Gx_line+152, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV38Logo)) ? AV66Logo_GXI : AV38Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+11, 167, Gx_line+89) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Empresa, "")), 9, Gx_line+93, 377, Gx_line+111, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41EmpRUC, "")), 9, Gx_line+110, 238, Gx_line+128, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("R.U.C.", 28, Gx_line+138, 62, Gx_line+152, 0+256, 0, 0, 0) ;
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
         AV66Logo_GXI = "";
         scmdbuf = "";
         A221PerCliCod = "";
         A1617PerFec = DateTime.MinValue;
         A1620PerSts = "";
         P00ED2_A1616PerCliDsc = new string[] {""} ;
         P00ED2_A221PerCliCod = new string[] {""} ;
         P00ED2_A1620PerSts = new string[] {""} ;
         P00ED2_A1617PerFec = new DateTime[] {DateTime.MinValue} ;
         P00ED2_A159TipCCod = new int[1] ;
         P00ED2_n159TipCCod = new bool[] {false} ;
         P00ED2_A218PerCod = new string[] {""} ;
         P00ED2_A219PerTip = new string[] {""} ;
         P00ED2_A220PerTDoc = new string[] {""} ;
         A1616PerCliDsc = "";
         A218PerCod = "";
         A219PerTip = "";
         A220PerTDoc = "";
         AV51PerCliCod = "";
         AV50PerCliDsc = "";
         P00ED3_A218PerCod = new string[] {""} ;
         P00ED3_A219PerTip = new string[] {""} ;
         P00ED3_A220PerTDoc = new string[] {""} ;
         P00ED3_A222PerTipCod = new string[] {""} ;
         P00ED3_A223PerDocNum = new string[] {""} ;
         P00ED3_A1620PerSts = new string[] {""} ;
         P00ED3_A1617PerFec = new DateTime[] {DateTime.MinValue} ;
         P00ED3_A221PerCliCod = new string[] {""} ;
         P00ED3_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00ED3_n190CCFech = new bool[] {false} ;
         P00ED3_A187CCmonCod = new int[1] ;
         P00ED3_n187CCmonCod = new bool[] {false} ;
         P00ED3_A1619PerImpPer = new decimal[1] ;
         A222PerTipCod = "";
         A223PerDocNum = "";
         A190CCFech = DateTime.MinValue;
         AV56CCFech = DateTime.MinValue;
         GXt_char2 = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV38Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_reportepercepcionesresumenpdf__default(),
            new Object[][] {
                new Object[] {
               P00ED2_A1616PerCliDsc, P00ED2_A221PerCliCod, P00ED2_A1620PerSts, P00ED2_A1617PerFec, P00ED2_A159TipCCod, P00ED2_n159TipCCod, P00ED2_A218PerCod, P00ED2_A219PerTip, P00ED2_A220PerTDoc
               }
               , new Object[] {
               P00ED3_A218PerCod, P00ED3_A219PerTip, P00ED3_A220PerTDoc, P00ED3_A222PerTipCod, P00ED3_A223PerDocNum, P00ED3_A1620PerSts, P00ED3_A1617PerFec, P00ED3_A221PerCliCod, P00ED3_A190CCFech, P00ED3_n190CCFech,
               P00ED3_A187CCmonCod, P00ED3_n187CCmonCod, P00ED3_A1619PerImpPer
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
      private int AV8TipCCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A159TipCCod ;
      private int Gx_OldLine ;
      private int A187CCmonCod ;
      private int AV57CCMonCod ;
      private decimal AV27TotalGeneral ;
      private decimal AV33TotalSub ;
      private decimal AV34TotalIVA ;
      private decimal AV52ImpTPer ;
      private decimal A1619PerImpPer ;
      private decimal AV58TipVenta ;
      private decimal GXt_decimal1 ;
      private decimal AV62ImpPer ;
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
      private string A1620PerSts ;
      private string A1616PerCliDsc ;
      private string A218PerCod ;
      private string A219PerTip ;
      private string AV51PerCliCod ;
      private string AV50PerCliDsc ;
      private string A222PerTipCod ;
      private string A223PerDocNum ;
      private string GXt_char2 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV14FDesde ;
      private DateTime AV15FHasta ;
      private DateTime A1617PerFec ;
      private DateTime A190CCFech ;
      private DateTime AV56CCFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKED3 ;
      private bool n159TipCCod ;
      private bool returnInSub ;
      private bool n190CCFech ;
      private bool n187CCmonCod ;
      private string AV66Logo_GXI ;
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
      private string[] P00ED2_A1616PerCliDsc ;
      private string[] P00ED2_A221PerCliCod ;
      private string[] P00ED2_A1620PerSts ;
      private DateTime[] P00ED2_A1617PerFec ;
      private int[] P00ED2_A159TipCCod ;
      private bool[] P00ED2_n159TipCCod ;
      private string[] P00ED2_A218PerCod ;
      private string[] P00ED2_A219PerTip ;
      private string[] P00ED2_A220PerTDoc ;
      private string[] P00ED3_A218PerCod ;
      private string[] P00ED3_A219PerTip ;
      private string[] P00ED3_A220PerTDoc ;
      private string[] P00ED3_A222PerTipCod ;
      private string[] P00ED3_A223PerDocNum ;
      private string[] P00ED3_A1620PerSts ;
      private DateTime[] P00ED3_A1617PerFec ;
      private string[] P00ED3_A221PerCliCod ;
      private DateTime[] P00ED3_A190CCFech ;
      private bool[] P00ED3_n190CCFech ;
      private int[] P00ED3_A187CCmonCod ;
      private bool[] P00ED3_n187CCmonCod ;
      private decimal[] P00ED3_A1619PerImpPer ;
   }

   public class r_reportepercepcionesresumenpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00ED2( IGxContext context ,
                                             int AV8TipCCod ,
                                             string AV10CliCod ,
                                             int A159TipCCod ,
                                             string A221PerCliCod ,
                                             DateTime A1617PerFec ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta ,
                                             string A1620PerSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.[CliDsc] AS PerCliDsc, T1.[PerCliCod] AS PerCliCod, T1.[PerSts], T1.[PerFec], T2.[TipCCod], T1.[PerCod], T1.[PerTip], T1.[PerTDoc] FROM ([CLPERCEPCION] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[PerCliCod])";
         AddWhere(sWhereString, "(T1.[PerFec] >= @AV14FDesde and T1.[PerFec] <= @AV15FHasta)");
         AddWhere(sWhereString, "(T1.[PerSts] <> 'A')");
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
         scmdbuf += " ORDER BY T1.[PerCliCod], T2.[CliDsc]";
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
                     return conditional_P00ED2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] );
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
          Object[] prmP00ED3;
          prmP00ED3 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV51PerCliCod",GXType.NChar,20,0)
          };
          Object[] prmP00ED2;
          prmP00ED2 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV8TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV10CliCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00ED2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ED2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00ED3", "SELECT T1.[PerCod], T1.[PerTip], T1.[PerTDoc], T1.[PerTipCod] AS PerTipCod, T1.[PerDocNum] AS PerDocNum, T2.[PerSts], T2.[PerFec], T2.[PerCliCod] AS PerCliCod, T3.[CCFech], T3.[CCmonCod], T1.[PerImpPer] FROM (([CLPERCEPCIONDET] T1 INNER JOIN [CLPERCEPCION] T2 ON T2.[PerCod] = T1.[PerCod] AND T2.[PerTip] = T1.[PerTip] AND T2.[PerTDoc] = T1.[PerTDoc]) INNER JOIN [CLCUENTACOBRAR] T3 ON T3.[CCTipCod] = T1.[PerTipCod] AND T3.[CCDocNum] = T1.[PerDocNum]) WHERE (T2.[PerFec] >= @AV14FDesde and T2.[PerFec] <= @AV15FHasta) AND (T2.[PerSts] <> 'A') AND (T2.[PerCliCod] = @AV51PerCliCod) ORDER BY T1.[PerTip], T1.[PerCod], T1.[PerTDoc], T1.[PerTipCod], T1.[PerDocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ED3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 10);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                ((string[]) buf[5])[0] = rslt.getString(6, 1);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                return;
       }
    }

 }

}
