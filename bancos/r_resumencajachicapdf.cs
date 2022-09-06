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
   public class r_resumencajachicapdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "bancos.r_resumencajachicapdf.aspx")), "bancos.r_resumencajachicapdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "bancos.r_resumencajachicapdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "CajCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV12CajCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV25MVLCajCod = GetPar( "MVLCajCod");
                  AV19FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV20FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV33AperSts = GetPar( "AperSts");
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

      public r_resumencajachicapdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumencajachicapdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_CajCod ,
                           ref string aP1_MVLCajCod ,
                           ref DateTime aP2_FDesde ,
                           ref DateTime aP3_FHasta ,
                           ref string aP4_AperSts )
      {
         this.AV12CajCod = aP0_CajCod;
         this.AV25MVLCajCod = aP1_MVLCajCod;
         this.AV19FDesde = aP2_FDesde;
         this.AV20FHasta = aP3_FHasta;
         this.AV33AperSts = aP4_AperSts;
         initialize();
         executePrivate();
         aP0_CajCod=this.AV12CajCod;
         aP1_MVLCajCod=this.AV25MVLCajCod;
         aP2_FDesde=this.AV19FDesde;
         aP3_FHasta=this.AV20FHasta;
         aP4_AperSts=this.AV33AperSts;
      }

      public string executeUdp( ref int aP0_CajCod ,
                                ref string aP1_MVLCajCod ,
                                ref DateTime aP2_FDesde ,
                                ref DateTime aP3_FHasta )
      {
         execute(ref aP0_CajCod, ref aP1_MVLCajCod, ref aP2_FDesde, ref aP3_FHasta, ref aP4_AperSts);
         return AV33AperSts ;
      }

      public void executeSubmit( ref int aP0_CajCod ,
                                 ref string aP1_MVLCajCod ,
                                 ref DateTime aP2_FDesde ,
                                 ref DateTime aP3_FHasta ,
                                 ref string aP4_AperSts )
      {
         r_resumencajachicapdf objr_resumencajachicapdf;
         objr_resumencajachicapdf = new r_resumencajachicapdf();
         objr_resumencajachicapdf.AV12CajCod = aP0_CajCod;
         objr_resumencajachicapdf.AV25MVLCajCod = aP1_MVLCajCod;
         objr_resumencajachicapdf.AV19FDesde = aP2_FDesde;
         objr_resumencajachicapdf.AV20FHasta = aP3_FHasta;
         objr_resumencajachicapdf.AV33AperSts = aP4_AperSts;
         objr_resumencajachicapdf.context.SetSubmitInitialConfig(context);
         objr_resumencajachicapdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumencajachicapdf);
         aP0_CajCod=this.AV12CajCod;
         aP1_MVLCajCod=this.AV25MVLCajCod;
         aP2_FDesde=this.AV19FDesde;
         aP3_FHasta=this.AV20FHasta;
         aP4_AperSts=this.AV33AperSts;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumencajachicapdf)stateInfo).executePrivate();
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
            AV15Empresa = AV27Session.Get("Empresa");
            AV14EmpDir = AV27Session.Get("EmpDir");
            AV17EmpTelf = AV27Session.Get("EmpTelf");
            AV31UsuCod = AV27Session.Get("Usuario");
            AV28Total = 0.00m;
            AV18Estado = "";
            AV21Filtro1 = "Todos";
            AV22Filtro2 = "Todos";
            /* Using cursor P007U2 */
            pr_default.execute(0, new Object[] {AV12CajCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A358CajCod = P007U2_A358CajCod[0];
               A486CajDsc = P007U2_A486CajDsc[0];
               AV21Filtro1 = A486CajDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV22Filtro2 = "Del : " + context.localUtil.DToC( AV19FDesde, 2, "/") + " Al : " + context.localUtil.DToC( AV20FHasta, 2, "/");
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV12CajCod ,
                                                 AV25MVLCajCod ,
                                                 AV33AperSts ,
                                                 A358CajCod ,
                                                 A359AperCajCod ,
                                                 A470AperSts ,
                                                 A441AperCajFec ,
                                                 AV19FDesde ,
                                                 AV20FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P007U3 */
            pr_default.execute(1, new Object[] {AV19FDesde, AV20FHasta, AV12CajCod, AV25MVLCajCod, AV33AperSts});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A441AperCajFec = P007U3_A441AperCajFec[0];
               A470AperSts = P007U3_A470AperSts[0];
               A359AperCajCod = P007U3_A359AperCajCod[0];
               A358CajCod = P007U3_A358CajCod[0];
               A486CajDsc = P007U3_A486CajDsc[0];
               A364AperMonCod = P007U3_A364AperMonCod[0];
               A1233MonAbr = P007U3_A1233MonAbr[0];
               n1233MonAbr = P007U3_n1233MonAbr[0];
               A455AperImporte = P007U3_A455AperImporte[0];
               A457AperSaldo = P007U3_A457AperSaldo[0];
               A486CajDsc = P007U3_A486CajDsc[0];
               A1233MonAbr = P007U3_A1233MonAbr[0];
               n1233MonAbr = P007U3_n1233MonAbr[0];
               A456AperImpTotal = (decimal)(A457AperSaldo+A455AperImporte);
               AV9AperCajCod = A359AperCajCod;
               AV12CajCod = A358CajCod;
               AV13CajDsc = A486CajDsc;
               AV10AperCajFec = A441AperCajFec;
               AV11AperImpTotal = A456AperImpTotal;
               AV8AperMonCod = A364AperMonCod;
               AV24MonAbr = StringUtil.Trim( A1233MonAbr);
               AV26Saldo = 0.00m;
               AV28Total = 0.00m;
               AV18Estado = (String.IsNullOrEmpty(StringUtil.RTrim( A470AperSts)) ? "Abierto" : "Cerrado");
               /* Execute user subroutine: 'MOVIMIENTOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               AV26Saldo = (decimal)(AV11AperImpTotal-AV28Total);
               H7U0( false, 19) ;
               getPrinter().GxDrawLine(0, Gx_line+0, 0, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(75, Gx_line+0, 75, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(135, Gx_line+0, 135, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(403, Gx_line+0, 403, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(443, Gx_line+0, 443, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(539, Gx_line+0, 539, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(644, Gx_line+0, 644, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(721, Gx_line+0, 721, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(798, Gx_line+0, 798, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9AperCajCod, "")), 4, Gx_line+2, 64, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV10AperCajFec, "99/99/99"), 81, Gx_line+2, 126, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13CajDsc, "")), 142, Gx_line+2, 399, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24MonAbr, "")), 408, Gx_line+2, 438, Gx_line+17, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV11AperImpTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 441, Gx_line+2, 537, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28Total, "ZZZZZZ,ZZZ,ZZ9.99")), 547, Gx_line+2, 643, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV26Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 622, Gx_line+2, 718, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Estado, "")), 727, Gx_line+2, 798, Gx_line+17, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV29TotalApe = (decimal)(AV29TotalApe+AV11AperImpTotal);
               AV30TotalMov = (decimal)(AV30TotalMov+AV28Total);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            H7U0( false, 89) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32TSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 617, Gx_line+29, 724, Gx_line+44, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV30TotalMov, "ZZZZZZ,ZZZ,ZZ9.99")), 536, Gx_line+29, 643, Gx_line+44, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29TotalApe, "ZZZZZZ,ZZZ,ZZ9.99")), 430, Gx_line+29, 537, Gx_line+44, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Totales", 381, Gx_line+29, 426, Gx_line+43, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(0, Gx_line+0, 799, Gx_line+0, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+89);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7U0( true, 0) ;
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
         /* Optimized group. */
         /* Using cursor P007U4 */
         pr_default.execute(2, new Object[] {AV12CajCod, AV9AperCajCod});
         c1296MVLCajImp = P007U4_A1296MVLCajImp[0];
         pr_default.close(2);
         AV28Total = (decimal)(AV28Total+c1296MVLCajImp);
         /* End optimized group. */
      }

      protected void H7U0( bool bFoot ,
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
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 730, Gx_line+41, 769, Gx_line+56, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 14, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Cajas Chicas", 297, Gx_line+28, 551, Gx_line+52, 1+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV23Logo)) ? A40000Logo_GXI : AV23Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 13, Gx_line+3, 171, Gx_line+81) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Empresa, "")), 13, Gx_line+78, 272, Gx_line+96, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Caja Chica", 261, Gx_line+68, 322, Gx_line+82, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Periodo", 276, Gx_line+90, 322, Gx_line+104, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21Filtro1, "")), 330, Gx_line+63, 673, Gx_line+87, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro2, "")), 330, Gx_line+84, 673, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Imp.Apertura", 452, Gx_line+126, 533, Gx_line+140, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(539, Gx_line+121, 539, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(644, Gx_line+121, 644, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(135, Gx_line+121, 135, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(443, Gx_line+121, 443, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 665, Gx_line+126, 698, Gx_line+140, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mon.", 411, Gx_line+126, 440, Gx_line+140, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(403, Gx_line+121, 403, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(721, Gx_line+121, 721, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Caja", 11, Gx_line+126, 55, Gx_line+140, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 86, Gx_line+126, 121, Gx_line+140, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+121, 799, Gx_line+146, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(74, Gx_line+121, 74, Gx_line+145, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Imp.Movimiento", 543, Gx_line+126, 641, Gx_line+140, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Estado", 735, Gx_line+126, 776, Gx_line+140, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Caja Chica", 246, Gx_line+126, 307, Gx_line+140, 0+256, 0, 0, 0) ;
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
         AV15Empresa = "";
         AV27Session = context.GetSession();
         AV14EmpDir = "";
         AV17EmpTelf = "";
         AV31UsuCod = "";
         AV18Estado = "";
         AV21Filtro1 = "";
         AV22Filtro2 = "";
         scmdbuf = "";
         P007U2_A358CajCod = new int[1] ;
         P007U2_A486CajDsc = new string[] {""} ;
         A486CajDsc = "";
         A359AperCajCod = "";
         A470AperSts = "";
         A441AperCajFec = DateTime.MinValue;
         P007U3_A441AperCajFec = new DateTime[] {DateTime.MinValue} ;
         P007U3_A470AperSts = new string[] {""} ;
         P007U3_A359AperCajCod = new string[] {""} ;
         P007U3_A358CajCod = new int[1] ;
         P007U3_A486CajDsc = new string[] {""} ;
         P007U3_A364AperMonCod = new int[1] ;
         P007U3_A1233MonAbr = new string[] {""} ;
         P007U3_n1233MonAbr = new bool[] {false} ;
         P007U3_A455AperImporte = new decimal[1] ;
         P007U3_A457AperSaldo = new decimal[1] ;
         A1233MonAbr = "";
         AV9AperCajCod = "";
         AV13CajDsc = "";
         AV10AperCajFec = DateTime.MinValue;
         AV24MonAbr = "";
         P007U4_A1296MVLCajImp = new decimal[1] ;
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV23Logo = "";
         sImgUrl = "";
         AV23Logo = "";
         A40000Logo_GXI = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.r_resumencajachicapdf__default(),
            new Object[][] {
                new Object[] {
               P007U2_A358CajCod, P007U2_A486CajDsc
               }
               , new Object[] {
               P007U3_A441AperCajFec, P007U3_A470AperSts, P007U3_A359AperCajCod, P007U3_A358CajCod, P007U3_A486CajDsc, P007U3_A364AperMonCod, P007U3_A1233MonAbr, P007U3_n1233MonAbr, P007U3_A455AperImporte, P007U3_A457AperSaldo
               }
               , new Object[] {
               P007U4_A1296MVLCajImp
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
      private int AV12CajCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A358CajCod ;
      private int A364AperMonCod ;
      private int AV8AperMonCod ;
      private int Gx_OldLine ;
      private decimal AV28Total ;
      private decimal A455AperImporte ;
      private decimal A457AperSaldo ;
      private decimal A456AperImpTotal ;
      private decimal AV11AperImpTotal ;
      private decimal AV26Saldo ;
      private decimal AV29TotalApe ;
      private decimal AV30TotalMov ;
      private decimal AV32TSaldo ;
      private decimal c1296MVLCajImp ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV25MVLCajCod ;
      private string AV33AperSts ;
      private string AV15Empresa ;
      private string AV14EmpDir ;
      private string AV17EmpTelf ;
      private string AV31UsuCod ;
      private string AV18Estado ;
      private string AV21Filtro1 ;
      private string AV22Filtro2 ;
      private string scmdbuf ;
      private string A486CajDsc ;
      private string A359AperCajCod ;
      private string A470AperSts ;
      private string A1233MonAbr ;
      private string AV9AperCajCod ;
      private string AV13CajDsc ;
      private string AV24MonAbr ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV19FDesde ;
      private DateTime AV20FHasta ;
      private DateTime A441AperCajFec ;
      private DateTime AV10AperCajFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1233MonAbr ;
      private bool returnInSub ;
      private string A40000Logo_GXI ;
      private string Logo ;
      private string AV23Logo ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_CajCod ;
      private string aP1_MVLCajCod ;
      private DateTime aP2_FDesde ;
      private DateTime aP3_FHasta ;
      private string aP4_AperSts ;
      private IDataStoreProvider pr_default ;
      private int[] P007U2_A358CajCod ;
      private string[] P007U2_A486CajDsc ;
      private DateTime[] P007U3_A441AperCajFec ;
      private string[] P007U3_A470AperSts ;
      private string[] P007U3_A359AperCajCod ;
      private int[] P007U3_A358CajCod ;
      private string[] P007U3_A486CajDsc ;
      private int[] P007U3_A364AperMonCod ;
      private string[] P007U3_A1233MonAbr ;
      private bool[] P007U3_n1233MonAbr ;
      private decimal[] P007U3_A455AperImporte ;
      private decimal[] P007U3_A457AperSaldo ;
      private decimal[] P007U4_A1296MVLCajImp ;
   }

   public class r_resumencajachicapdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007U3( IGxContext context ,
                                             int AV12CajCod ,
                                             string AV25MVLCajCod ,
                                             string AV33AperSts ,
                                             int A358CajCod ,
                                             string A359AperCajCod ,
                                             string A470AperSts ,
                                             DateTime A441AperCajFec ,
                                             DateTime AV19FDesde ,
                                             DateTime AV20FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[AperCajFec], T1.[AperSts], T1.[AperCajCod], T1.[CajCod], T2.[CajDsc], T1.[AperMonCod] AS AperMonCod, T3.[MonAbr], T1.[AperImporte], T1.[AperSaldo] FROM (([TSAPERTURACAJA] T1 INNER JOIN [TSCAJACHICA] T2 ON T2.[CajCod] = T1.[CajCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[AperMonCod])";
         AddWhere(sWhereString, "(T1.[AperCajFec] >= @AV19FDesde)");
         AddWhere(sWhereString, "(T1.[AperCajFec] <= @AV20FHasta)");
         if ( ! (0==AV12CajCod) )
         {
            AddWhere(sWhereString, "(T1.[CajCod] = @AV12CajCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25MVLCajCod)) )
         {
            AddWhere(sWhereString, "(T1.[AperCajCod] = @AV25MVLCajCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! ( StringUtil.StrCmp(AV33AperSts, "X") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[AperSts] = @AV33AperSts)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CajCod], T1.[AperCajFec]";
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
                     return conditional_P007U3(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] );
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
          Object[] prmP007U2;
          prmP007U2 = new Object[] {
          new ParDef("@AV12CajCod",GXType.Int32,6,0)
          };
          Object[] prmP007U4;
          prmP007U4 = new Object[] {
          new ParDef("@AV12CajCod",GXType.Int32,6,0) ,
          new ParDef("@AV9AperCajCod",GXType.NChar,10,0)
          };
          Object[] prmP007U3;
          prmP007U3 = new Object[] {
          new ParDef("@AV19FDesde",GXType.Date,8,0) ,
          new ParDef("@AV20FHasta",GXType.Date,8,0) ,
          new ParDef("@AV12CajCod",GXType.Int32,6,0) ,
          new ParDef("@AV25MVLCajCod",GXType.NChar,10,0) ,
          new ParDef("@AV33AperSts",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007U2", "SELECT [CajCod], [CajDsc] FROM [TSCAJACHICA] WHERE [CajCod] = @AV12CajCod ORDER BY [CajCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007U2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007U3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007U3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007U4", "SELECT SUM([MVLCajImp]) FROM [TSMOVCAJACHICA] WHERE [CajCod] = @AV12CajCod and [MVLCajCod] = @AV9AperCajCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007U4,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
       }
    }

 }

}
