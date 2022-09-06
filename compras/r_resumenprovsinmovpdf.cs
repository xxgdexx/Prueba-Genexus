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
namespace GeneXus.Programs.compras {
   public class r_resumenprovsinmovpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_resumenprovsinmovpdf.aspx")), "compras.r_resumenprovsinmovpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_resumenprovsinmovpdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "TprvCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV31TprvCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV30PrvCod = GetPar( "PrvCod");
                  AV53FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV36FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public r_resumenprovsinmovpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenprovsinmovpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TprvCod ,
                           ref string aP1_PrvCod ,
                           ref DateTime aP2_FDesde ,
                           ref DateTime aP3_FHasta )
      {
         this.AV31TprvCod = aP0_TprvCod;
         this.AV30PrvCod = aP1_PrvCod;
         this.AV53FDesde = aP2_FDesde;
         this.AV36FHasta = aP3_FHasta;
         initialize();
         executePrivate();
         aP0_TprvCod=this.AV31TprvCod;
         aP1_PrvCod=this.AV30PrvCod;
         aP2_FDesde=this.AV53FDesde;
         aP3_FHasta=this.AV36FHasta;
      }

      public DateTime executeUdp( ref int aP0_TprvCod ,
                                  ref string aP1_PrvCod ,
                                  ref DateTime aP2_FDesde )
      {
         execute(ref aP0_TprvCod, ref aP1_PrvCod, ref aP2_FDesde, ref aP3_FHasta);
         return AV36FHasta ;
      }

      public void executeSubmit( ref int aP0_TprvCod ,
                                 ref string aP1_PrvCod ,
                                 ref DateTime aP2_FDesde ,
                                 ref DateTime aP3_FHasta )
      {
         r_resumenprovsinmovpdf objr_resumenprovsinmovpdf;
         objr_resumenprovsinmovpdf = new r_resumenprovsinmovpdf();
         objr_resumenprovsinmovpdf.AV31TprvCod = aP0_TprvCod;
         objr_resumenprovsinmovpdf.AV30PrvCod = aP1_PrvCod;
         objr_resumenprovsinmovpdf.AV53FDesde = aP2_FDesde;
         objr_resumenprovsinmovpdf.AV36FHasta = aP3_FHasta;
         objr_resumenprovsinmovpdf.context.SetSubmitInitialConfig(context);
         objr_resumenprovsinmovpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenprovsinmovpdf);
         aP0_TprvCod=this.AV31TprvCod;
         aP1_PrvCod=this.AV30PrvCod;
         aP2_FDesde=this.AV53FDesde;
         aP3_FHasta=this.AV36FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenprovsinmovpdf)stateInfo).executePrivate();
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
            AV34Empresa = AV35Session.Get("Empresa");
            AV33EmpDir = AV35Session.Get("EmpDir");
            AV43EmpRUC = AV35Session.Get("EmpRUC");
            AV44Ruta = AV35Session.Get("RUTA") + "/Logo.jpg";
            AV45Logo = AV44Ruta;
            AV57Logo_GXI = GXDbFile.PathToUrl( AV44Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV54Periodo = "Del : " + context.localUtil.DToC( AV53FDesde, 2, "/") + " Al : " + context.localUtil.DToC( AV36FHasta, 2, "/");
            /* Using cursor P00AQ2 */
            pr_default.execute(0, new Object[] {AV31TprvCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A298TprvCod = P00AQ2_A298TprvCod[0];
               A1941TprvDsc = P00AQ2_A1941TprvDsc[0];
               AV22Filtro1 = A1941TprvDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00AQ3 */
            pr_default.execute(1, new Object[] {AV30PrvCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A244PrvCod = P00AQ3_A244PrvCod[0];
               A247PrvDsc = P00AQ3_A247PrvDsc[0];
               AV23Filtro2 = A247PrvDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV49Item = 1;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV31TprvCod ,
                                                 AV30PrvCod ,
                                                 A298TprvCod ,
                                                 A244PrvCod ,
                                                 A1777PrvSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00AQ4 */
            pr_default.execute(2, new Object[] {AV31TprvCod, AV30PrvCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A1777PrvSts = P00AQ4_A1777PrvSts[0];
               A244PrvCod = P00AQ4_A244PrvCod[0];
               A298TprvCod = P00AQ4_A298TprvCod[0];
               A247PrvDsc = P00AQ4_A247PrvDsc[0];
               AV30PrvCod = A244PrvCod;
               AV52PrvDsc = A247PrvDsc;
               AV50Fecha = DateTime.MinValue;
               AV51ComCod = "";
               /* Execute user subroutine: 'VALIDADOCUMENTOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               if ( AV12Flag == 0 )
               {
                  HAQ0( false, 17) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV49Item), "ZZZZ9")), 13, Gx_line+2, 45, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30PrvCod, "@!")), 69, Gx_line+2, 174, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52PrvDsc, "")), 177, Gx_line+2, 558, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV50Fecha, "99/99/99"), 589, Gx_line+2, 636, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51ComCod, "")), 674, Gx_line+2, 753, Gx_line+17, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
                  AV49Item = (int)(AV49Item+1);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            HAQ0( false, 28) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+28);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAQ0( true, 0) ;
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
         /* 'VALIDADOCUMENTOS' Routine */
         returnInSub = false;
         /* Using cursor P00AQ5 */
         pr_default.execute(3, new Object[] {AV53FDesde, AV30PrvCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A264CPFech = P00AQ5_A264CPFech[0];
            A262CPPrvCod = P00AQ5_A262CPPrvCod[0];
            A261CPComCod = P00AQ5_A261CPComCod[0];
            A260CPTipCod = P00AQ5_A260CPTipCod[0];
            AV50Fecha = A264CPFech;
            AV51ComCod = A261CPComCod;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV12Flag = 0;
         /* Using cursor P00AQ6 */
         pr_default.execute(4, new Object[] {AV36FHasta, AV30PrvCod, AV53FDesde});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A264CPFech = P00AQ6_A264CPFech[0];
            A262CPPrvCod = P00AQ6_A262CPPrvCod[0];
            A260CPTipCod = P00AQ6_A260CPTipCod[0];
            A261CPComCod = P00AQ6_A261CPComCod[0];
            AV12Flag = 1;
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void HAQ0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 664, Gx_line+31, 696, Gx_line+45, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 664, Gx_line+49, 708, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 664, Gx_line+14, 703, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 733, Gx_line+49, 772, Gx_line+64, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 710, Gx_line+31, 770, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 725, Gx_line+14, 772, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("R.U.C.", 75, Gx_line+173, 109, Gx_line+187, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 177, Gx_line+173, 239, Gx_line+187, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+168, 797, Gx_line+194, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Proveedores Sin Movimientos", 240, Gx_line+71, 600, Gx_line+91, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha Ult. Mov", 565, Gx_line+173, 651, Gx_line+187, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Documento", 669, Gx_line+173, 754, Gx_line+187, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Proveedor", 118, Gx_line+123, 226, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 118, Gx_line+146, 180, Gx_line+160, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 253, Gx_line+118, 596, Gx_line+142, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro2, "")), 253, Gx_line+141, 596, Gx_line+165, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43EmpRUC, "")), 14, Gx_line+46, 399, Gx_line+64, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33EmpDir, "")), 14, Gx_line+29, 399, Gx_line+47, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Empresa, "")), 14, Gx_line+11, 399, Gx_line+29, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Periodo, "")), 253, Gx_line+95, 587, Gx_line+116, 1+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Items.", 14, Gx_line+173, 54, Gx_line+187, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+194);
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
         AV34Empresa = "";
         AV35Session = context.GetSession();
         AV33EmpDir = "";
         AV43EmpRUC = "";
         AV44Ruta = "";
         AV45Logo = "";
         AV57Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV54Periodo = "";
         scmdbuf = "";
         P00AQ2_A298TprvCod = new int[1] ;
         P00AQ2_A1941TprvDsc = new string[] {""} ;
         A1941TprvDsc = "";
         P00AQ3_A244PrvCod = new string[] {""} ;
         P00AQ3_A247PrvDsc = new string[] {""} ;
         A244PrvCod = "";
         A247PrvDsc = "";
         P00AQ4_A1777PrvSts = new short[1] ;
         P00AQ4_A244PrvCod = new string[] {""} ;
         P00AQ4_A298TprvCod = new int[1] ;
         P00AQ4_A247PrvDsc = new string[] {""} ;
         AV52PrvDsc = "";
         AV50Fecha = DateTime.MinValue;
         AV51ComCod = "";
         P00AQ5_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P00AQ5_A262CPPrvCod = new string[] {""} ;
         P00AQ5_A261CPComCod = new string[] {""} ;
         P00AQ5_A260CPTipCod = new string[] {""} ;
         A264CPFech = DateTime.MinValue;
         A262CPPrvCod = "";
         A261CPComCod = "";
         A260CPTipCod = "";
         P00AQ6_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P00AQ6_A262CPPrvCod = new string[] {""} ;
         P00AQ6_A260CPTipCod = new string[] {""} ;
         P00AQ6_A261CPComCod = new string[] {""} ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_resumenprovsinmovpdf__default(),
            new Object[][] {
                new Object[] {
               P00AQ2_A298TprvCod, P00AQ2_A1941TprvDsc
               }
               , new Object[] {
               P00AQ3_A244PrvCod, P00AQ3_A247PrvDsc
               }
               , new Object[] {
               P00AQ4_A1777PrvSts, P00AQ4_A244PrvCod, P00AQ4_A298TprvCod, P00AQ4_A247PrvDsc
               }
               , new Object[] {
               P00AQ5_A264CPFech, P00AQ5_A262CPPrvCod, P00AQ5_A261CPComCod, P00AQ5_A260CPTipCod
               }
               , new Object[] {
               P00AQ6_A264CPFech, P00AQ6_A262CPPrvCod, P00AQ6_A260CPTipCod, P00AQ6_A261CPComCod
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
      private short A1777PrvSts ;
      private short AV12Flag ;
      private int AV31TprvCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A298TprvCod ;
      private int AV49Item ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV30PrvCod ;
      private string AV34Empresa ;
      private string AV33EmpDir ;
      private string AV43EmpRUC ;
      private string AV44Ruta ;
      private string AV22Filtro1 ;
      private string AV23Filtro2 ;
      private string AV54Periodo ;
      private string scmdbuf ;
      private string A1941TprvDsc ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string AV52PrvDsc ;
      private string AV51ComCod ;
      private string A262CPPrvCod ;
      private string A261CPComCod ;
      private string A260CPTipCod ;
      private string Gx_time ;
      private DateTime AV53FDesde ;
      private DateTime AV36FHasta ;
      private DateTime AV50Fecha ;
      private DateTime A264CPFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private string AV57Logo_GXI ;
      private string AV45Logo ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TprvCod ;
      private string aP1_PrvCod ;
      private DateTime aP2_FDesde ;
      private DateTime aP3_FHasta ;
      private IDataStoreProvider pr_default ;
      private int[] P00AQ2_A298TprvCod ;
      private string[] P00AQ2_A1941TprvDsc ;
      private string[] P00AQ3_A244PrvCod ;
      private string[] P00AQ3_A247PrvDsc ;
      private short[] P00AQ4_A1777PrvSts ;
      private string[] P00AQ4_A244PrvCod ;
      private int[] P00AQ4_A298TprvCod ;
      private string[] P00AQ4_A247PrvDsc ;
      private DateTime[] P00AQ5_A264CPFech ;
      private string[] P00AQ5_A262CPPrvCod ;
      private string[] P00AQ5_A261CPComCod ;
      private string[] P00AQ5_A260CPTipCod ;
      private DateTime[] P00AQ6_A264CPFech ;
      private string[] P00AQ6_A262CPPrvCod ;
      private string[] P00AQ6_A260CPTipCod ;
      private string[] P00AQ6_A261CPComCod ;
   }

   public class r_resumenprovsinmovpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AQ4( IGxContext context ,
                                             int AV31TprvCod ,
                                             string AV30PrvCod ,
                                             int A298TprvCod ,
                                             string A244PrvCod ,
                                             short A1777PrvSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [PrvSts], [PrvCod], [TprvCod], [PrvDsc] FROM [CPPROVEEDORES]";
         AddWhere(sWhereString, "([PrvSts] = 1)");
         if ( ! (0==AV31TprvCod) )
         {
            AddWhere(sWhereString, "([TprvCod] = @AV31TprvCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30PrvCod)) )
         {
            AddWhere(sWhereString, "([PrvCod] = @AV30PrvCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PrvDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P00AQ4(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] );
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
          Object[] prmP00AQ2;
          prmP00AQ2 = new Object[] {
          new ParDef("@AV31TprvCod",GXType.Int32,6,0)
          };
          Object[] prmP00AQ3;
          prmP00AQ3 = new Object[] {
          new ParDef("@AV30PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AQ5;
          prmP00AQ5 = new Object[] {
          new ParDef("@AV53FDesde",GXType.Date,8,0) ,
          new ParDef("@AV30PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AQ6;
          prmP00AQ6 = new Object[] {
          new ParDef("@AV36FHasta",GXType.Date,8,0) ,
          new ParDef("@AV30PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV53FDesde",GXType.Date,8,0)
          };
          Object[] prmP00AQ4;
          prmP00AQ4 = new Object[] {
          new ParDef("@AV31TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV30PrvCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AQ2", "SELECT [TprvCod], [TprvDsc] FROM [CTIPOPROVEEDOR] WHERE [TprvCod] = @AV31TprvCod ORDER BY [TprvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AQ2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AQ3", "SELECT [PrvCod], [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @AV30PrvCod ORDER BY [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AQ3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AQ4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AQ4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AQ5", "SELECT [CPFech], [CPPrvCod], [CPComCod], [CPTipCod] FROM [CPCUENTAPAGAR] WHERE ([CPFech] < @AV53FDesde) AND ([CPPrvCod] = @AV30PrvCod) ORDER BY [CPFech] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AQ5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AQ6", "SELECT [CPFech], [CPPrvCod], [CPTipCod], [CPComCod] FROM [CPCUENTAPAGAR] WHERE ([CPFech] <= @AV36FHasta) AND ([CPPrvCod] = @AV30PrvCod) AND ([CPFech] >= @AV53FDesde) ORDER BY [CPFech] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AQ6,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 3 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                return;
             case 4 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                return;
       }
    }

 }

}
