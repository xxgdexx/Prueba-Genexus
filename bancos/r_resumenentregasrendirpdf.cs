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
   public class r_resumenentregasrendirpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "bancos.r_resumenentregasrendirpdf.aspx")), "bancos.r_resumenentregasrendirpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "bancos.r_resumenentregasrendirpdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "EntCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV16EntCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV25MVLEntCod = GetPar( "MVLEntCod");
                  AV19FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV20FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV33AperESts = GetPar( "AperESts");
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

      public r_resumenentregasrendirpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenentregasrendirpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_EntCod ,
                           ref string aP1_MVLEntCod ,
                           ref DateTime aP2_FDesde ,
                           ref DateTime aP3_FHasta ,
                           ref string aP4_AperESts )
      {
         this.AV16EntCod = aP0_EntCod;
         this.AV25MVLEntCod = aP1_MVLEntCod;
         this.AV19FDesde = aP2_FDesde;
         this.AV20FHasta = aP3_FHasta;
         this.AV33AperESts = aP4_AperESts;
         initialize();
         executePrivate();
         aP0_EntCod=this.AV16EntCod;
         aP1_MVLEntCod=this.AV25MVLEntCod;
         aP2_FDesde=this.AV19FDesde;
         aP3_FHasta=this.AV20FHasta;
         aP4_AperESts=this.AV33AperESts;
      }

      public string executeUdp( ref int aP0_EntCod ,
                                ref string aP1_MVLEntCod ,
                                ref DateTime aP2_FDesde ,
                                ref DateTime aP3_FHasta )
      {
         execute(ref aP0_EntCod, ref aP1_MVLEntCod, ref aP2_FDesde, ref aP3_FHasta, ref aP4_AperESts);
         return AV33AperESts ;
      }

      public void executeSubmit( ref int aP0_EntCod ,
                                 ref string aP1_MVLEntCod ,
                                 ref DateTime aP2_FDesde ,
                                 ref DateTime aP3_FHasta ,
                                 ref string aP4_AperESts )
      {
         r_resumenentregasrendirpdf objr_resumenentregasrendirpdf;
         objr_resumenentregasrendirpdf = new r_resumenentregasrendirpdf();
         objr_resumenentregasrendirpdf.AV16EntCod = aP0_EntCod;
         objr_resumenentregasrendirpdf.AV25MVLEntCod = aP1_MVLEntCod;
         objr_resumenentregasrendirpdf.AV19FDesde = aP2_FDesde;
         objr_resumenentregasrendirpdf.AV20FHasta = aP3_FHasta;
         objr_resumenentregasrendirpdf.AV33AperESts = aP4_AperESts;
         objr_resumenentregasrendirpdf.context.SetSubmitInitialConfig(context);
         objr_resumenentregasrendirpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenentregasrendirpdf);
         aP0_EntCod=this.AV16EntCod;
         aP1_MVLEntCod=this.AV25MVLEntCod;
         aP2_FDesde=this.AV19FDesde;
         aP3_FHasta=this.AV20FHasta;
         aP4_AperESts=this.AV33AperESts;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenentregasrendirpdf)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11938, 0, 1, 1, 0, 1, 1) )
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
            AV13Empresa = AV27Session.Get("Empresa");
            AV12EmpDir = AV27Session.Get("EmpDir");
            AV15EmpTelf = AV27Session.Get("EmpTelf");
            AV31UsuCod = AV27Session.Get("Usuario");
            AV28Total = 0.00m;
            AV18Estado = "";
            AV21Filtro1 = "Todos";
            AV22Filtro2 = "Todos";
            /* Using cursor P00A42 */
            pr_default.execute(0, new Object[] {AV16EntCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A365EntCod = P00A42_A365EntCod[0];
               A972EntDsc = P00A42_A972EntDsc[0];
               AV21Filtro1 = A972EntDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV22Filtro2 = "Del : " + context.localUtil.DToC( AV19FDesde, 2, "/") + " Al : " + context.localUtil.DToC( AV20FHasta, 2, "/");
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV16EntCod ,
                                                 AV25MVLEntCod ,
                                                 AV33AperESts ,
                                                 A365EntCod ,
                                                 A366AperEntCod ,
                                                 A451AperESts ,
                                                 A449AperEntFec ,
                                                 AV19FDesde ,
                                                 AV20FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00A43 */
            pr_default.execute(1, new Object[] {AV19FDesde, AV20FHasta, AV16EntCod, AV25MVLEntCod, AV33AperESts});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A449AperEntFec = P00A43_A449AperEntFec[0];
               A451AperESts = P00A43_A451AperESts[0];
               A366AperEntCod = P00A43_A366AperEntCod[0];
               A365EntCod = P00A43_A365EntCod[0];
               A972EntDsc = P00A43_A972EntDsc[0];
               A371AperEMonCod = P00A43_A371AperEMonCod[0];
               A1233MonAbr = P00A43_A1233MonAbr[0];
               n1233MonAbr = P00A43_n1233MonAbr[0];
               A445AperEImporte = P00A43_A445AperEImporte[0];
               A447AperEReponer = P00A43_A447AperEReponer[0];
               A972EntDsc = P00A43_A972EntDsc[0];
               A1233MonAbr = P00A43_A1233MonAbr[0];
               n1233MonAbr = P00A43_n1233MonAbr[0];
               A446AperEImpTotal = (decimal)(A447AperEReponer+A445AperEImporte);
               AV10AperEntCod = A366AperEntCod;
               AV16EntCod = A365EntCod;
               AV17EntDsc = A972EntDsc;
               AV11AperEntFec = A449AperEntFec;
               AV8AperEImpTotal = A446AperEImpTotal;
               AV9APerEMonCod = A371AperEMonCod;
               AV24MonAbr = StringUtil.Trim( A1233MonAbr);
               AV28Total = 0.00m;
               AV18Estado = (String.IsNullOrEmpty(StringUtil.RTrim( A451AperESts)) ? "Abierto" : "Cerrado");
               /* Execute user subroutine: 'MOVIMIENTOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               AV26Saldo = (decimal)(AV8AperEImpTotal-AV28Total);
               HA40( false, 19) ;
               getPrinter().GxDrawLine(0, Gx_line+0, 0, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(78, Gx_line+0, 78, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(141, Gx_line+0, 141, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(447, Gx_line+0, 447, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(725, Gx_line+0, 725, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(646, Gx_line+0, 646, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(798, Gx_line+0, 798, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10AperEntCod, "")), 5, Gx_line+2, 58, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV11AperEntFec, "99/99/99"), 82, Gx_line+2, 129, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EntDsc, "")), 145, Gx_line+2, 404, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Estado, "")), 730, Gx_line+2, 796, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(543, Gx_line+0, 543, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(407, Gx_line+0, 407, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV8AperEImpTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 428, Gx_line+2, 535, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28Total, "ZZZZZZ,ZZZ,ZZ9.99")), 536, Gx_line+2, 643, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV26Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 615, Gx_line+2, 722, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24MonAbr, "")), 411, Gx_line+2, 443, Gx_line+17, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV29TotalApe = (decimal)(AV29TotalApe+AV8AperEImpTotal);
               AV30TotalMov = (decimal)(AV30TotalMov+AV28Total);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            HA40( false, 50) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Totales", 379, Gx_line+15, 424, Gx_line+29, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29TotalApe, "ZZZZZZ,ZZZ,ZZ9.99")), 428, Gx_line+15, 535, Gx_line+30, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(0, Gx_line+0, 799, Gx_line+0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV30TotalMov, "ZZZZZZ,ZZZ,ZZ9.99")), 536, Gx_line+15, 643, Gx_line+30, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32TSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 615, Gx_line+15, 722, Gx_line+30, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+50);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HA40( true, 0) ;
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
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         /* Using cursor P00A44 */
         pr_default.execute(2, new Object[] {AV16EntCod, AV10AperEntCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A403MVLEntCod = P00A44_A403MVLEntCod[0];
            A365EntCod = P00A44_A365EntCod[0];
            A1331MVLEMTipo = P00A44_A1331MVLEMTipo[0];
            A1336MVLEntImp = P00A44_A1336MVLEntImp[0];
            A404MVLEITem = P00A44_A404MVLEITem[0];
            AV28Total = (decimal)(AV28Total+(A1336MVLEntImp*((StringUtil.StrCmp(A1331MVLEMTipo, "0")==0) ? -1 : 1)));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void HA40( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 664, Gx_line+23, 696, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 664, Gx_line+41, 708, Gx_line+55, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 664, Gx_line+6, 703, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 722, Gx_line+6, 769, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 684, Gx_line+23, 768, Gx_line+38, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 727, Gx_line+41, 766, Gx_line+56, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 14, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Entregas a Rendir", 277, Gx_line+27, 583, Gx_line+51, 1+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV23Logo)) ? A40000Logo_GXI : AV23Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 13, Gx_line+3, 171, Gx_line+81) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14EmpRUC, "")), 13, Gx_line+96, 273, Gx_line+114, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Empresa, "")), 13, Gx_line+78, 272, Gx_line+96, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Entrega Rendir", 233, Gx_line+68, 322, Gx_line+82, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Periodo", 276, Gx_line+90, 322, Gx_line+104, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21Filtro1, "")), 330, Gx_line+63, 673, Gx_line+87, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro2, "")), 330, Gx_line+84, 673, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+123, 799, Gx_line+148, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(78, Gx_line+123, 78, Gx_line+147, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Entrega", 8, Gx_line+128, 72, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 91, Gx_line+128, 126, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Personal", 250, Gx_line+128, 302, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Imp.Apertura", 456, Gx_line+128, 537, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Imp.Movimiento", 547, Gx_line+128, 645, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Estado", 740, Gx_line+128, 781, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(141, Gx_line+124, 141, Gx_line+148, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(447, Gx_line+124, 447, Gx_line+148, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(543, Gx_line+124, 543, Gx_line+148, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(646, Gx_line+124, 646, Gx_line+148, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(407, Gx_line+124, 407, Gx_line+148, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(725, Gx_line+124, 725, Gx_line+148, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 669, Gx_line+128, 702, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mon.", 416, Gx_line+128, 445, Gx_line+142, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+148);
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
         AV13Empresa = "";
         AV27Session = context.GetSession();
         AV12EmpDir = "";
         AV15EmpTelf = "";
         AV31UsuCod = "";
         AV18Estado = "";
         AV21Filtro1 = "";
         AV22Filtro2 = "";
         scmdbuf = "";
         P00A42_A365EntCod = new int[1] ;
         P00A42_A972EntDsc = new string[] {""} ;
         A972EntDsc = "";
         A366AperEntCod = "";
         A451AperESts = "";
         A449AperEntFec = DateTime.MinValue;
         P00A43_A449AperEntFec = new DateTime[] {DateTime.MinValue} ;
         P00A43_A451AperESts = new string[] {""} ;
         P00A43_A366AperEntCod = new string[] {""} ;
         P00A43_A365EntCod = new int[1] ;
         P00A43_A972EntDsc = new string[] {""} ;
         P00A43_A371AperEMonCod = new int[1] ;
         P00A43_A1233MonAbr = new string[] {""} ;
         P00A43_n1233MonAbr = new bool[] {false} ;
         P00A43_A445AperEImporte = new decimal[1] ;
         P00A43_A447AperEReponer = new decimal[1] ;
         A1233MonAbr = "";
         AV10AperEntCod = "";
         AV17EntDsc = "";
         AV11AperEntFec = DateTime.MinValue;
         AV24MonAbr = "";
         P00A44_A403MVLEntCod = new string[] {""} ;
         P00A44_A365EntCod = new int[1] ;
         P00A44_A1331MVLEMTipo = new string[] {""} ;
         P00A44_A1336MVLEntImp = new decimal[1] ;
         P00A44_A404MVLEITem = new int[1] ;
         A403MVLEntCod = "";
         A1331MVLEMTipo = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV23Logo = "";
         sImgUrl = "";
         AV23Logo = "";
         A40000Logo_GXI = "";
         AV14EmpRUC = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.r_resumenentregasrendirpdf__default(),
            new Object[][] {
                new Object[] {
               P00A42_A365EntCod, P00A42_A972EntDsc
               }
               , new Object[] {
               P00A43_A449AperEntFec, P00A43_A451AperESts, P00A43_A366AperEntCod, P00A43_A365EntCod, P00A43_A972EntDsc, P00A43_A371AperEMonCod, P00A43_A1233MonAbr, P00A43_n1233MonAbr, P00A43_A445AperEImporte, P00A43_A447AperEReponer
               }
               , new Object[] {
               P00A44_A403MVLEntCod, P00A44_A365EntCod, P00A44_A1331MVLEMTipo, P00A44_A1336MVLEntImp, P00A44_A404MVLEITem
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
      private int AV16EntCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A365EntCod ;
      private int A371AperEMonCod ;
      private int AV9APerEMonCod ;
      private int Gx_OldLine ;
      private int A404MVLEITem ;
      private decimal AV28Total ;
      private decimal A445AperEImporte ;
      private decimal A447AperEReponer ;
      private decimal A446AperEImpTotal ;
      private decimal AV8AperEImpTotal ;
      private decimal AV26Saldo ;
      private decimal AV29TotalApe ;
      private decimal AV30TotalMov ;
      private decimal AV32TSaldo ;
      private decimal A1336MVLEntImp ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV25MVLEntCod ;
      private string AV33AperESts ;
      private string AV13Empresa ;
      private string AV12EmpDir ;
      private string AV15EmpTelf ;
      private string AV31UsuCod ;
      private string AV18Estado ;
      private string AV21Filtro1 ;
      private string AV22Filtro2 ;
      private string scmdbuf ;
      private string A972EntDsc ;
      private string A366AperEntCod ;
      private string A451AperESts ;
      private string A1233MonAbr ;
      private string AV10AperEntCod ;
      private string AV17EntDsc ;
      private string AV24MonAbr ;
      private string A403MVLEntCod ;
      private string Gx_time ;
      private string sImgUrl ;
      private string AV14EmpRUC ;
      private DateTime AV19FDesde ;
      private DateTime AV20FHasta ;
      private DateTime A449AperEntFec ;
      private DateTime AV11AperEntFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1233MonAbr ;
      private bool returnInSub ;
      private string A1331MVLEMTipo ;
      private string A40000Logo_GXI ;
      private string Logo ;
      private string AV23Logo ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_EntCod ;
      private string aP1_MVLEntCod ;
      private DateTime aP2_FDesde ;
      private DateTime aP3_FHasta ;
      private string aP4_AperESts ;
      private IDataStoreProvider pr_default ;
      private int[] P00A42_A365EntCod ;
      private string[] P00A42_A972EntDsc ;
      private DateTime[] P00A43_A449AperEntFec ;
      private string[] P00A43_A451AperESts ;
      private string[] P00A43_A366AperEntCod ;
      private int[] P00A43_A365EntCod ;
      private string[] P00A43_A972EntDsc ;
      private int[] P00A43_A371AperEMonCod ;
      private string[] P00A43_A1233MonAbr ;
      private bool[] P00A43_n1233MonAbr ;
      private decimal[] P00A43_A445AperEImporte ;
      private decimal[] P00A43_A447AperEReponer ;
      private string[] P00A44_A403MVLEntCod ;
      private int[] P00A44_A365EntCod ;
      private string[] P00A44_A1331MVLEMTipo ;
      private decimal[] P00A44_A1336MVLEntImp ;
      private int[] P00A44_A404MVLEITem ;
   }

   public class r_resumenentregasrendirpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A43( IGxContext context ,
                                             int AV16EntCod ,
                                             string AV25MVLEntCod ,
                                             string AV33AperESts ,
                                             int A365EntCod ,
                                             string A366AperEntCod ,
                                             string A451AperESts ,
                                             DateTime A449AperEntFec ,
                                             DateTime AV19FDesde ,
                                             DateTime AV20FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[AperEntFec], T1.[AperESts], T1.[AperEntCod], T1.[EntCod], T2.[EntDsc], T1.[AperEMonCod] AS AperEMonCod, T3.[MonAbr], T1.[AperEImporte], T1.[AperEReponer] FROM (([TSAPERTURAENTREGA] T1 INNER JOIN [TSENTREGAS] T2 ON T2.[EntCod] = T1.[EntCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[AperEMonCod])";
         AddWhere(sWhereString, "(T1.[AperEntFec] >= @AV19FDesde)");
         AddWhere(sWhereString, "(T1.[AperEntFec] <= @AV20FHasta)");
         if ( ! (0==AV16EntCod) )
         {
            AddWhere(sWhereString, "(T1.[EntCod] = @AV16EntCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25MVLEntCod)) )
         {
            AddWhere(sWhereString, "(T1.[AperEntCod] = @AV25MVLEntCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! ( StringUtil.StrCmp(AV33AperESts, "X") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[AperESts] = @AV33AperESts)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[EntCod], T1.[AperEntFec]";
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
               case 1 :
                     return conditional_P00A43(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00A42;
          prmP00A42 = new Object[] {
          new ParDef("@AV16EntCod",GXType.Int32,6,0)
          };
          Object[] prmP00A44;
          prmP00A44 = new Object[] {
          new ParDef("@AV16EntCod",GXType.Int32,6,0) ,
          new ParDef("@AV10AperEntCod",GXType.NChar,10,0)
          };
          Object[] prmP00A43;
          prmP00A43 = new Object[] {
          new ParDef("@AV19FDesde",GXType.Date,8,0) ,
          new ParDef("@AV20FHasta",GXType.Date,8,0) ,
          new ParDef("@AV16EntCod",GXType.Int32,6,0) ,
          new ParDef("@AV25MVLEntCod",GXType.NChar,10,0) ,
          new ParDef("@AV33AperESts",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A42", "SELECT [EntCod], [EntDsc] FROM [TSENTREGAS] WHERE [EntCod] = @AV16EntCod ORDER BY [EntCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A42,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A43", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A43,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00A44", "SELECT [MVLEntCod], [EntCod], [MVLEMTipo], [MVLEntImp], [MVLEITem] FROM [TSMOVENTREGA] WHERE [EntCod] = @AV16EntCod and [MVLEntCod] = @AV10AperEntCod ORDER BY [EntCod], [MVLEntCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A44,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
