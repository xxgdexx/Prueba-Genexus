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
namespace GeneXus.Programs {
   public class rrmovimientosentregarendir : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrmovimientosentregarendir.aspx")), "rrmovimientosentregarendir.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrmovimientosentregarendir.aspx")))) ;
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
               AV30EntCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV49MVLEntCod = GetPar( "MVLEntCod");
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

      public rrmovimientosentregarendir( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrmovimientosentregarendir( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_EntCod ,
                           ref string aP1_MVLEntCod )
      {
         this.AV30EntCod = aP0_EntCod;
         this.AV49MVLEntCod = aP1_MVLEntCod;
         initialize();
         executePrivate();
         aP0_EntCod=this.AV30EntCod;
         aP1_MVLEntCod=this.AV49MVLEntCod;
      }

      public string executeUdp( ref int aP0_EntCod )
      {
         execute(ref aP0_EntCod, ref aP1_MVLEntCod);
         return AV49MVLEntCod ;
      }

      public void executeSubmit( ref int aP0_EntCod ,
                                 ref string aP1_MVLEntCod )
      {
         rrmovimientosentregarendir objrrmovimientosentregarendir;
         objrrmovimientosentregarendir = new rrmovimientosentregarendir();
         objrrmovimientosentregarendir.AV30EntCod = aP0_EntCod;
         objrrmovimientosentregarendir.AV49MVLEntCod = aP1_MVLEntCod;
         objrrmovimientosentregarendir.context.SetSubmitInitialConfig(context);
         objrrmovimientosentregarendir.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrmovimientosentregarendir);
         aP0_EntCod=this.AV30EntCod;
         aP1_MVLEntCod=this.AV49MVLEntCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrmovimientosentregarendir)stateInfo).executePrivate();
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
            AV27Empresa = AV62Session.Get("Empresa");
            AV26EmpDir = AV62Session.Get("EmpDir");
            AV29EmpTelf = AV62Session.Get("EmpTelf");
            AV67UsuCod = AV62Session.Get("UsuCod");
            /* Execute user subroutine: 'CABECERA' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Using cursor P00A52 */
            pr_default.execute(0, new Object[] {AV30EntCod, AV49MVLEntCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A411MVLConcEntCod = P00A52_A411MVLConcEntCod[0];
               A403MVLEntCod = P00A52_A403MVLEntCod[0];
               A365EntCod = P00A52_A365EntCod[0];
               A1332MVLEntConc = P00A52_A1332MVLEntConc[0];
               A1327MVLEMBanCod = P00A52_A1327MVLEMBanCod[0];
               A1333MVLEntDoc = P00A52_A1333MVLEntDoc[0];
               A1335MVLEntFec = P00A52_A1335MVLEntFec[0];
               A1309MVLConEntDsc = P00A52_A1309MVLConEntDsc[0];
               A1331MVLEMTipo = P00A52_A1331MVLEMTipo[0];
               A1336MVLEntImp = P00A52_A1336MVLEntImp[0];
               A409MVLECosCod = P00A52_A409MVLECosCod[0];
               n409MVLECosCod = P00A52_n409MVLECosCod[0];
               A408MVLEPrvCod = P00A52_A408MVLEPrvCod[0];
               A1321MVLECueAuxCod = P00A52_A1321MVLECueAuxCod[0];
               A1308MVLConEntCue = P00A52_A1308MVLConEntCue[0];
               A404MVLEITem = P00A52_A404MVLEITem[0];
               A1309MVLConEntDsc = P00A52_A1309MVLConEntDsc[0];
               A1308MVLConEntCue = P00A52_A1308MVLConEntCue[0];
               AV41MVLCajConc = ((0==A1327MVLEMBanCod) ? A1332MVLEntConc : "Cierre de Entrega a Rendir");
               AV42MVLCajDoc = A1333MVLEntDoc;
               AV43MVLCajFec = A1335MVLEntFec;
               AV45MVLConCajDsc = A1309MVLConEntDsc;
               AV44MVLCajImp = (decimal)(A1336MVLEntImp*((StringUtil.StrCmp(A1331MVLEMTipo, "0")==0) ? -1 : 1));
               AV47MVLCosCod = A409MVLECosCod;
               GXt_decimal1 = AV65TipVenta;
               GXt_char2 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV12AperMonCod, ref  AV43MVLCajFec, ref  GXt_char2, out  GXt_decimal1) ;
               AV65TipVenta = GXt_decimal1;
               AV65TipVenta = ((AV12AperMonCod==1) ? (decimal)(1) : AV65TipVenta);
               AV34Imporigen = NumberUtil.Round( AV44MVLCajImp*AV65TipVenta, 2);
               AV50MVLPrvCod = A408MVLEPrvCod;
               AV48MVLCueAuxCod = A1321MVLECueAuxCod;
               AV46MVLConEntCue = ((0==A1327MVLEMBanCod) ? A1308MVLConEntCue : "");
               /* Execute user subroutine: 'NOMBRECENTROCOSTO' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48MVLCueAuxCod)) )
               {
                  AV48MVLCueAuxCod = AV50MVLPrvCod;
               }
               AV66Total = (decimal)(AV66Total-AV44MVLCajImp);
               HA50( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV43MVLCajFec, "99/99/99"), 2, Gx_line+3, 49, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41MVLCajConc, "")), 215, Gx_line+3, 532, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42MVLCajDoc, "")), 53, Gx_line+3, 126, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48MVLCueAuxCod, "")), 133, Gx_line+3, 209, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+0, 0, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(49, Gx_line+0, 49, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(129, Gx_line+0, 129, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(213, Gx_line+0, 213, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(535, Gx_line+0, 535, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(617, Gx_line+0, 617, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44MVLCajImp, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+3, 809, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(752, Gx_line+0, 752, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Costo, "")), 620, Gx_line+5, 751, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46MVLConEntCue, "")), 541, Gx_line+3, 615, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(813, Gx_line+0, 813, Gx_line+19, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            HA50( false, 20) ;
            getPrinter().GxDrawLine(0, Gx_line+0, 813, Gx_line+0, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            HA50( false, 161) ;
            getPrinter().GxDrawRect(0, Gx_line+61, 813, Gx_line+159, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(0, Gx_line+127, 813, Gx_line+127, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(411, Gx_line+63, 411, Gx_line+161, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Revisado", 125, Gx_line+136, 180, Gx_line+150, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Autorizado", 567, Gx_line+136, 633, Gx_line+150, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Usuario : ", 4, Gx_line+44, 59, Gx_line+58, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67UsuCod, "")), 60, Gx_line+44, 113, Gx_line+58, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Por Reembolsar", 622, Gx_line+6, 714, Gx_line+20, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66Total, "ZZZZZZ,ZZZ,ZZ9.99")), 726, Gx_line+7, 811, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61porReponer, "ZZZZZZZZZZZ9.99")), 702, Gx_line+34, 812, Gx_line+49, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Saldo", 622, Gx_line+34, 681, Gx_line+47, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+161);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HA50( true, 0) ;
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
         /* 'CABECERA' Routine */
         returnInSub = false;
         AV66Total = 0.00m;
         AV31Estado = "";
         /* Using cursor P00A53 */
         pr_default.execute(1, new Object[] {AV30EntCod, AV49MVLEntCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A370AperEForCod = P00A53_A370AperEForCod[0];
            A366AperEntCod = P00A53_A366AperEntCod[0];
            A365EntCod = P00A53_A365EntCod[0];
            A972EntDsc = P00A53_A972EntDsc[0];
            A988ForDsc = P00A53_A988ForDsc[0];
            n988ForDsc = P00A53_n988ForDsc[0];
            A449AperEntFec = P00A53_A449AperEntFec[0];
            A368AperEBanCod = P00A53_A368AperEBanCod[0];
            n368AperEBanCod = P00A53_n368AperEBanCod[0];
            A369AperECueBan = P00A53_A369AperECueBan[0];
            n369AperECueBan = P00A53_n369AperECueBan[0];
            A444AperECheque = P00A53_A444AperECheque[0];
            A451AperESts = P00A53_A451AperESts[0];
            A371AperEMonCod = P00A53_A371AperEMonCod[0];
            A454AperETope = P00A53_A454AperETope[0];
            A450AperESaldo = P00A53_A450AperESaldo[0];
            A445AperEImporte = P00A53_A445AperEImporte[0];
            A447AperEReponer = P00A53_A447AperEReponer[0];
            A988ForDsc = P00A53_A988ForDsc[0];
            n988ForDsc = P00A53_n988ForDsc[0];
            A972EntDsc = P00A53_A972EntDsc[0];
            A446AperEImpTotal = (decimal)(A447AperEReponer+A445AperEImporte);
            AV20CajDsc = A972EntDsc;
            AV33ForDsc = A988ForDsc;
            AV8AperCajFec = A449AperEntFec;
            AV40MVLCajCod = AV49MVLEntCod;
            AV70AperEImpTotal = A446AperEImpTotal;
            AV17BanCod = A368AperEBanCod;
            AV18BanDsc = "";
            AV10AperCueBan = A369AperECueBan;
            AV9AperCheque = A444AperECheque;
            AV15AperSts = A451AperESts;
            AV12AperMonCod = A371AperEMonCod;
            AV16AperTope = A454AperETope;
            AV14AperSaldo = A450AperESaldo;
            AV13AperReponer = A447AperEReponer;
            AV11AperImpTotal = A446AperEImpTotal;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV31Estado = (String.IsNullOrEmpty(StringUtil.RTrim( AV15AperSts)) ? "Abierto" : "Cerrado");
         /* Using cursor P00A54 */
         pr_default.execute(2, new Object[] {AV17BanCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A372BanCod = P00A54_A372BanCod[0];
            A482BanDsc = P00A54_A482BanDsc[0];
            AV18BanDsc = A482BanDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         /* Using cursor P00A55 */
         pr_default.execute(3, new Object[] {AV12AperMonCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A180MonCod = P00A55_A180MonCod[0];
            A1234MonDsc = P00A55_A1234MonDsc[0];
            AV39MonDsc = A1234MonDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         AV66Total = AV11AperImpTotal;
      }

      protected void S121( )
      {
         /* 'NOMBRECENTROCOSTO' Routine */
         returnInSub = false;
         AV25Costo = "";
         /* Using cursor P00A56 */
         pr_default.execute(4, new Object[] {AV47MVLCosCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A79COSCod = P00A56_A79COSCod[0];
            A761COSDsc = P00A56_A761COSDsc[0];
            AV25Costo = A761COSDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void HA50( bool bFoot ,
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
               getPrinter().GxDrawText("Entrega a Rendir", 338, Gx_line+73, 506, Gx_line+97, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+131, 813, Gx_line+317, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Entrega a Rendir", 17, Gx_line+138, 116, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Entrega", 17, Gx_line+159, 81, Gx_line+173, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Forma de Pago", 17, Gx_line+181, 106, Gx_line+195, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Banco", 17, Gx_line+203, 53, Gx_line+217, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cuenta", 17, Gx_line+225, 60, Gx_line+239, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 17, Gx_line+271, 67, Gx_line+285, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20CajDsc, "")), 134, Gx_line+138, 401, Gx_line+152, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Cheque", 17, Gx_line+247, 78, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 14, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49MVLEntCod, "")), 367, Gx_line+98, 498, Gx_line+122, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33ForDsc, "")), 134, Gx_line+181, 408, Gx_line+195, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40MVLCajCod, "")), 134, Gx_line+159, 232, Gx_line+173, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70AperEImpTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 134, Gx_line+271, 241, Gx_line+286, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18BanDsc, "")), 134, Gx_line+203, 411, Gx_line+217, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10AperCueBan, "")), 134, Gx_line+225, 239, Gx_line+240, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9AperCheque, "")), 134, Gx_line+247, 239, Gx_line+262, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha Apertura", 477, Gx_line+138, 569, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Estado", 477, Gx_line+159, 518, Gx_line+173, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 477, Gx_line+181, 525, Gx_line+195, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tope x Mov.", 477, Gx_line+203, 549, Gx_line+217, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Reposiciones", 477, Gx_line+225, 555, Gx_line+239, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total", 477, Gx_line+247, 508, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV8AperCajFec, "99/99/99"), 597, Gx_line+140, 644, Gx_line+155, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31Estado, "")), 597, Gx_line+161, 676, Gx_line+176, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16AperTope, "ZZZZZZ,ZZZ,ZZ9.99")), 597, Gx_line+203, 704, Gx_line+218, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39MonDsc, "")), 597, Gx_line+183, 776, Gx_line+197, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV13AperReponer, "ZZZZZZ,ZZZ,ZZ9.99")), 597, Gx_line+225, 704, Gx_line+240, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV11AperImpTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 597, Gx_line+247, 704, Gx_line+262, 2+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV38Logo)) ? A40000Logo_GXI : AV38Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 13, Gx_line+3, 171, Gx_line+81) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28EmpRUC, "")), 13, Gx_line+113, 273, Gx_line+131, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26EmpDir, "")), 13, Gx_line+95, 340, Gx_line+113, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 13, Gx_line+78, 338, Gx_line+96, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 9, Gx_line+299, 44, Gx_line+313, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Docum.", 59, Gx_line+299, 120, Gx_line+313, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Concepto", 319, Gx_line+299, 375, Gx_line+313, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 759, Gx_line+299, 809, Gx_line+313, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cuenta", 556, Gx_line+299, 599, Gx_line+313, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(49, Gx_line+292, 49, Gx_line+318, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(213, Gx_line+292, 213, Gx_line+318, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(535, Gx_line+291, 535, Gx_line+317, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(617, Gx_line+292, 617, Gx_line+318, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(129, Gx_line+292, 129, Gx_line+318, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Auxiliar/RUC", 132, Gx_line+299, 208, Gx_line+313, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(752, Gx_line+291, 752, Gx_line+317, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Centro Costos", 642, Gx_line+299, 728, Gx_line+313, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+291, 812, Gx_line+291, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+318);
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
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
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
         AV62Session = context.GetSession();
         AV26EmpDir = "";
         AV29EmpTelf = "";
         AV67UsuCod = "";
         scmdbuf = "";
         P00A52_A411MVLConcEntCod = new int[1] ;
         P00A52_A403MVLEntCod = new string[] {""} ;
         P00A52_A365EntCod = new int[1] ;
         P00A52_A1332MVLEntConc = new string[] {""} ;
         P00A52_A1327MVLEMBanCod = new int[1] ;
         P00A52_A1333MVLEntDoc = new string[] {""} ;
         P00A52_A1335MVLEntFec = new DateTime[] {DateTime.MinValue} ;
         P00A52_A1309MVLConEntDsc = new string[] {""} ;
         P00A52_A1331MVLEMTipo = new string[] {""} ;
         P00A52_A1336MVLEntImp = new decimal[1] ;
         P00A52_A409MVLECosCod = new string[] {""} ;
         P00A52_n409MVLECosCod = new bool[] {false} ;
         P00A52_A408MVLEPrvCod = new string[] {""} ;
         P00A52_A1321MVLECueAuxCod = new string[] {""} ;
         P00A52_A1308MVLConEntCue = new string[] {""} ;
         P00A52_A404MVLEITem = new int[1] ;
         A403MVLEntCod = "";
         A1332MVLEntConc = "";
         A1333MVLEntDoc = "";
         A1335MVLEntFec = DateTime.MinValue;
         A1309MVLConEntDsc = "";
         A1331MVLEMTipo = "";
         A409MVLECosCod = "";
         A408MVLEPrvCod = "";
         A1321MVLECueAuxCod = "";
         A1308MVLConEntCue = "";
         AV41MVLCajConc = "";
         AV42MVLCajDoc = "";
         AV43MVLCajFec = DateTime.MinValue;
         AV45MVLConCajDsc = "";
         AV47MVLCosCod = "";
         GXt_char2 = "";
         AV50MVLPrvCod = "";
         AV48MVLCueAuxCod = "";
         AV46MVLConEntCue = "";
         AV25Costo = "";
         AV31Estado = "";
         P00A53_A370AperEForCod = new int[1] ;
         P00A53_A366AperEntCod = new string[] {""} ;
         P00A53_A365EntCod = new int[1] ;
         P00A53_A972EntDsc = new string[] {""} ;
         P00A53_A988ForDsc = new string[] {""} ;
         P00A53_n988ForDsc = new bool[] {false} ;
         P00A53_A449AperEntFec = new DateTime[] {DateTime.MinValue} ;
         P00A53_A368AperEBanCod = new int[1] ;
         P00A53_n368AperEBanCod = new bool[] {false} ;
         P00A53_A369AperECueBan = new string[] {""} ;
         P00A53_n369AperECueBan = new bool[] {false} ;
         P00A53_A444AperECheque = new string[] {""} ;
         P00A53_A451AperESts = new string[] {""} ;
         P00A53_A371AperEMonCod = new int[1] ;
         P00A53_A454AperETope = new decimal[1] ;
         P00A53_A450AperESaldo = new decimal[1] ;
         P00A53_A445AperEImporte = new decimal[1] ;
         P00A53_A447AperEReponer = new decimal[1] ;
         A366AperEntCod = "";
         A972EntDsc = "";
         A988ForDsc = "";
         A449AperEntFec = DateTime.MinValue;
         A369AperECueBan = "";
         A444AperECheque = "";
         A451AperESts = "";
         AV20CajDsc = "";
         AV33ForDsc = "";
         AV8AperCajFec = DateTime.MinValue;
         AV40MVLCajCod = "";
         AV18BanDsc = "";
         AV10AperCueBan = "";
         AV9AperCheque = "";
         AV15AperSts = "";
         P00A54_A372BanCod = new int[1] ;
         P00A54_A482BanDsc = new string[] {""} ;
         A482BanDsc = "";
         P00A55_A180MonCod = new int[1] ;
         P00A55_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV39MonDsc = "";
         P00A56_A79COSCod = new string[] {""} ;
         P00A56_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV38Logo = "";
         sImgUrl = "";
         AV38Logo = "";
         A40000Logo_GXI = "";
         AV28EmpRUC = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrmovimientosentregarendir__default(),
            new Object[][] {
                new Object[] {
               P00A52_A411MVLConcEntCod, P00A52_A403MVLEntCod, P00A52_A365EntCod, P00A52_A1332MVLEntConc, P00A52_A1327MVLEMBanCod, P00A52_A1333MVLEntDoc, P00A52_A1335MVLEntFec, P00A52_A1309MVLConEntDsc, P00A52_A1331MVLEMTipo, P00A52_A1336MVLEntImp,
               P00A52_A409MVLECosCod, P00A52_n409MVLECosCod, P00A52_A408MVLEPrvCod, P00A52_A1321MVLECueAuxCod, P00A52_A1308MVLConEntCue, P00A52_A404MVLEITem
               }
               , new Object[] {
               P00A53_A370AperEForCod, P00A53_A366AperEntCod, P00A53_A365EntCod, P00A53_A972EntDsc, P00A53_A988ForDsc, P00A53_n988ForDsc, P00A53_A449AperEntFec, P00A53_A368AperEBanCod, P00A53_n368AperEBanCod, P00A53_A369AperECueBan,
               P00A53_n369AperECueBan, P00A53_A444AperECheque, P00A53_A451AperESts, P00A53_A371AperEMonCod, P00A53_A454AperETope, P00A53_A450AperESaldo, P00A53_A445AperEImporte, P00A53_A447AperEReponer
               }
               , new Object[] {
               P00A54_A372BanCod, P00A54_A482BanDsc
               }
               , new Object[] {
               P00A55_A180MonCod, P00A55_A1234MonDsc
               }
               , new Object[] {
               P00A56_A79COSCod, P00A56_A761COSDsc
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
      private int AV30EntCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A411MVLConcEntCod ;
      private int A365EntCod ;
      private int A1327MVLEMBanCod ;
      private int A404MVLEITem ;
      private int AV12AperMonCod ;
      private int Gx_OldLine ;
      private int A370AperEForCod ;
      private int A368AperEBanCod ;
      private int A371AperEMonCod ;
      private int AV17BanCod ;
      private int A372BanCod ;
      private int A180MonCod ;
      private decimal A1336MVLEntImp ;
      private decimal AV44MVLCajImp ;
      private decimal AV65TipVenta ;
      private decimal GXt_decimal1 ;
      private decimal AV34Imporigen ;
      private decimal AV66Total ;
      private decimal AV61porReponer ;
      private decimal A454AperETope ;
      private decimal A450AperESaldo ;
      private decimal A445AperEImporte ;
      private decimal A447AperEReponer ;
      private decimal A446AperEImpTotal ;
      private decimal AV70AperEImpTotal ;
      private decimal AV16AperTope ;
      private decimal AV14AperSaldo ;
      private decimal AV13AperReponer ;
      private decimal AV11AperImpTotal ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV49MVLEntCod ;
      private string AV27Empresa ;
      private string AV26EmpDir ;
      private string AV29EmpTelf ;
      private string AV67UsuCod ;
      private string scmdbuf ;
      private string A403MVLEntCod ;
      private string A1332MVLEntConc ;
      private string A1333MVLEntDoc ;
      private string A1309MVLConEntDsc ;
      private string A409MVLECosCod ;
      private string A408MVLEPrvCod ;
      private string A1321MVLECueAuxCod ;
      private string A1308MVLConEntCue ;
      private string AV41MVLCajConc ;
      private string AV42MVLCajDoc ;
      private string AV45MVLConCajDsc ;
      private string AV47MVLCosCod ;
      private string GXt_char2 ;
      private string AV50MVLPrvCod ;
      private string AV48MVLCueAuxCod ;
      private string AV46MVLConEntCue ;
      private string AV25Costo ;
      private string AV31Estado ;
      private string A366AperEntCod ;
      private string A972EntDsc ;
      private string A988ForDsc ;
      private string A369AperECueBan ;
      private string A444AperECheque ;
      private string A451AperESts ;
      private string AV20CajDsc ;
      private string AV33ForDsc ;
      private string AV40MVLCajCod ;
      private string AV18BanDsc ;
      private string AV10AperCueBan ;
      private string AV9AperCheque ;
      private string AV15AperSts ;
      private string A482BanDsc ;
      private string A1234MonDsc ;
      private string AV39MonDsc ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private string AV28EmpRUC ;
      private DateTime A1335MVLEntFec ;
      private DateTime AV43MVLCajFec ;
      private DateTime A449AperEntFec ;
      private DateTime AV8AperCajFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool n409MVLECosCod ;
      private bool n988ForDsc ;
      private bool n368AperEBanCod ;
      private bool n369AperECueBan ;
      private string A1331MVLEMTipo ;
      private string A40000Logo_GXI ;
      private string Logo ;
      private string AV38Logo ;
      private IGxSession AV62Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_EntCod ;
      private string aP1_MVLEntCod ;
      private IDataStoreProvider pr_default ;
      private int[] P00A52_A411MVLConcEntCod ;
      private string[] P00A52_A403MVLEntCod ;
      private int[] P00A52_A365EntCod ;
      private string[] P00A52_A1332MVLEntConc ;
      private int[] P00A52_A1327MVLEMBanCod ;
      private string[] P00A52_A1333MVLEntDoc ;
      private DateTime[] P00A52_A1335MVLEntFec ;
      private string[] P00A52_A1309MVLConEntDsc ;
      private string[] P00A52_A1331MVLEMTipo ;
      private decimal[] P00A52_A1336MVLEntImp ;
      private string[] P00A52_A409MVLECosCod ;
      private bool[] P00A52_n409MVLECosCod ;
      private string[] P00A52_A408MVLEPrvCod ;
      private string[] P00A52_A1321MVLECueAuxCod ;
      private string[] P00A52_A1308MVLConEntCue ;
      private int[] P00A52_A404MVLEITem ;
      private int[] P00A53_A370AperEForCod ;
      private string[] P00A53_A366AperEntCod ;
      private int[] P00A53_A365EntCod ;
      private string[] P00A53_A972EntDsc ;
      private string[] P00A53_A988ForDsc ;
      private bool[] P00A53_n988ForDsc ;
      private DateTime[] P00A53_A449AperEntFec ;
      private int[] P00A53_A368AperEBanCod ;
      private bool[] P00A53_n368AperEBanCod ;
      private string[] P00A53_A369AperECueBan ;
      private bool[] P00A53_n369AperECueBan ;
      private string[] P00A53_A444AperECheque ;
      private string[] P00A53_A451AperESts ;
      private int[] P00A53_A371AperEMonCod ;
      private decimal[] P00A53_A454AperETope ;
      private decimal[] P00A53_A450AperESaldo ;
      private decimal[] P00A53_A445AperEImporte ;
      private decimal[] P00A53_A447AperEReponer ;
      private int[] P00A54_A372BanCod ;
      private string[] P00A54_A482BanDsc ;
      private int[] P00A55_A180MonCod ;
      private string[] P00A55_A1234MonDsc ;
      private string[] P00A56_A79COSCod ;
      private string[] P00A56_A761COSDsc ;
   }

   public class rrmovimientosentregarendir__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00A52;
          prmP00A52 = new Object[] {
          new ParDef("@AV30EntCod",GXType.Int32,6,0) ,
          new ParDef("@AV49MVLEntCod",GXType.NChar,10,0)
          };
          Object[] prmP00A53;
          prmP00A53 = new Object[] {
          new ParDef("@AV30EntCod",GXType.Int32,6,0) ,
          new ParDef("@AV49MVLEntCod",GXType.NChar,10,0)
          };
          Object[] prmP00A54;
          prmP00A54 = new Object[] {
          new ParDef("@AV17BanCod",GXType.Int32,6,0)
          };
          Object[] prmP00A55;
          prmP00A55 = new Object[] {
          new ParDef("@AV12AperMonCod",GXType.Int32,6,0)
          };
          Object[] prmP00A56;
          prmP00A56 = new Object[] {
          new ParDef("@AV47MVLCosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A52", "SELECT T1.[MVLConcEntCod] AS MVLConcEntCod, T1.[MVLEntCod], T1.[EntCod], T1.[MVLEntConc], T1.[MVLEMBanCod], T1.[MVLEntDoc], T1.[MVLEntFec], T2.[ConEntDsc] AS MVLConEntDsc, T1.[MVLEMTipo], T1.[MVLEntImp], T1.[MVLECosCod], T1.[MVLEPrvCod], T1.[MVLECueAuxCod], T2.[CueCod] AS MVLConEntCue, T1.[MVLEITem] FROM ([TSMOVENTREGA] T1 INNER JOIN [TSCONCEPTOENTREGA] T2 ON T2.[ConEntCod] = T1.[MVLConcEntCod]) WHERE T1.[EntCod] = @AV30EntCod and T1.[MVLEntCod] = @AV49MVLEntCod ORDER BY T1.[EntCod], T1.[MVLEntCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A52,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00A53", "SELECT T1.[AperEForCod] AS AperEForCod, T1.[AperEntCod], T1.[EntCod], T3.[EntDsc], T2.[ForDsc], T1.[AperEntFec], T1.[AperEBanCod], T1.[AperECueBan], T1.[AperECheque], T1.[AperESts], T1.[AperEMonCod], T1.[AperETope], T1.[AperESaldo], T1.[AperEImporte], T1.[AperEReponer] FROM (([TSAPERTURAENTREGA] T1 INNER JOIN [CFORMAPAGO] T2 ON T2.[ForCod] = T1.[AperEForCod]) INNER JOIN [TSENTREGAS] T3 ON T3.[EntCod] = T1.[EntCod]) WHERE T1.[EntCod] = @AV30EntCod and T1.[AperEntCod] = @AV49MVLEntCod ORDER BY T1.[EntCod], T1.[AperEntCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A53,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A54", "SELECT [BanCod], [BanDsc] FROM [TSBANCOS] WHERE [BanCod] = @AV17BanCod ORDER BY [BanCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A54,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A55", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV12AperMonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A55,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A56", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV47MVLCosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A56,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 10);
                ((bool[]) buf[11])[0] = rslt.wasNull(11);
                ((string[]) buf[12])[0] = rslt.getString(12, 20);
                ((string[]) buf[13])[0] = rslt.getString(13, 20);
                ((string[]) buf[14])[0] = rslt.getString(14, 15);
                ((int[]) buf[15])[0] = rslt.getInt(15);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 20);
                ((string[]) buf[12])[0] = rslt.getString(10, 1);
                ((int[]) buf[13])[0] = rslt.getInt(11);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(15);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
