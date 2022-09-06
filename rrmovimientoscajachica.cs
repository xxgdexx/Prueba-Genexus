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
   public class rrmovimientoscajachica : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrmovimientoscajachica.aspx")), "rrmovimientoscajachica.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrmovimientoscajachica.aspx")))) ;
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
               AV35CajCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV36MVLCajCod = GetPar( "MVLCajCod");
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

      public rrmovimientoscajachica( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrmovimientoscajachica( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_CajCod ,
                           ref string aP1_MVLCajCod )
      {
         this.AV35CajCod = aP0_CajCod;
         this.AV36MVLCajCod = aP1_MVLCajCod;
         initialize();
         executePrivate();
         aP0_CajCod=this.AV35CajCod;
         aP1_MVLCajCod=this.AV36MVLCajCod;
      }

      public string executeUdp( ref int aP0_CajCod )
      {
         execute(ref aP0_CajCod, ref aP1_MVLCajCod);
         return AV36MVLCajCod ;
      }

      public void executeSubmit( ref int aP0_CajCod ,
                                 ref string aP1_MVLCajCod )
      {
         rrmovimientoscajachica objrrmovimientoscajachica;
         objrrmovimientoscajachica = new rrmovimientoscajachica();
         objrrmovimientoscajachica.AV35CajCod = aP0_CajCod;
         objrrmovimientoscajachica.AV36MVLCajCod = aP1_MVLCajCod;
         objrrmovimientoscajachica.context.SetSubmitInitialConfig(context);
         objrrmovimientoscajachica.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrmovimientoscajachica);
         aP0_CajCod=this.AV35CajCod;
         aP1_MVLCajCod=this.AV36MVLCajCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrmovimientoscajachica)stateInfo).executePrivate();
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
         M_bot = 12;
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
            P_lines = (int)(gxYPage-(lineHeight*12));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV19Empresa = AV20Session.Get("Empresa");
            AV21EmpDir = AV20Session.Get("EmpDir");
            AV22EmpTelf = AV20Session.Get("EmpTelf");
            AV55UsuCod = AV20Session.Get("Usuario");
            AV40Total = 0.00m;
            AV49Estado = "";
            /* Using cursor P009T2 */
            pr_default.execute(0, new Object[] {AV35CajCod, AV36MVLCajCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A363AperForCod = P009T2_A363AperForCod[0];
               A359AperCajCod = P009T2_A359AperCajCod[0];
               A358CajCod = P009T2_A358CajCod[0];
               A486CajDsc = P009T2_A486CajDsc[0];
               A988ForDsc = P009T2_A988ForDsc[0];
               n988ForDsc = P009T2_n988ForDsc[0];
               A441AperCajFec = P009T2_A441AperCajFec[0];
               A361AperBanCod = P009T2_A361AperBanCod[0];
               n361AperBanCod = P009T2_n361AperBanCod[0];
               A362AperCueBan = P009T2_A362AperCueBan[0];
               n362AperCueBan = P009T2_n362AperCueBan[0];
               A442AperCheque = P009T2_A442AperCheque[0];
               A470AperSts = P009T2_A470AperSts[0];
               A364AperMonCod = P009T2_A364AperMonCod[0];
               A473AperTope = P009T2_A473AperTope[0];
               A467AperReponer = P009T2_A467AperReponer[0];
               A455AperImporte = P009T2_A455AperImporte[0];
               A457AperSaldo = P009T2_A457AperSaldo[0];
               A988ForDsc = P009T2_A988ForDsc[0];
               n988ForDsc = P009T2_n988ForDsc[0];
               A486CajDsc = P009T2_A486CajDsc[0];
               A456AperImpTotal = (decimal)(A457AperSaldo+A455AperImporte);
               AV37CajDsc = A486CajDsc;
               AV38ForDsc = A988ForDsc;
               AV47AperCajFec = A441AperCajFec;
               AV39MVLCajImp = A456AperImpTotal;
               AV9BanCod = A361AperBanCod;
               AV10BanDsc = "";
               AV45AperCueBan = A362AperCueBan;
               AV46AperCheque = A442AperCheque;
               AV48AperSts = A470AperSts;
               AV57AperMonCod = A364AperMonCod;
               AV51AperTope = A473AperTope;
               AV52AperSaldo = A457AperSaldo;
               AV53AperReponer = A467AperReponer;
               AV54AperImpTotal = A456AperImpTotal;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV49Estado = (String.IsNullOrEmpty(StringUtil.RTrim( AV48AperSts)) ? "Abierto" : "Cerrado");
            /* Using cursor P009T3 */
            pr_default.execute(1, new Object[] {AV9BanCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A372BanCod = P009T3_A372BanCod[0];
               A482BanDsc = P009T3_A482BanDsc[0];
               AV10BanDsc = A482BanDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P009T4 */
            pr_default.execute(2, new Object[] {AV57AperMonCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A180MonCod = P009T4_A180MonCod[0];
               A1234MonDsc = P009T4_A1234MonDsc[0];
               AV50MonDsc = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV40Total = 0.00m;
            /* Using cursor P009T5 */
            pr_default.execute(3, new Object[] {AV35CajCod, AV36MVLCajCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A399MVLConcCajCod = P009T5_A399MVLConcCajCod[0];
               A391MVLCajCod = P009T5_A391MVLCajCod[0];
               A358CajCod = P009T5_A358CajCod[0];
               A1292MVLCajConc = P009T5_A1292MVLCajConc[0];
               A1293MVLCajDoc = P009T5_A1293MVLCajDoc[0];
               A1295MVLCajFec = P009T5_A1295MVLCajFec[0];
               A1307MVLConCajDsc = P009T5_A1307MVLConCajDsc[0];
               A1296MVLCajImp = P009T5_A1296MVLCajImp[0];
               A396MVLPrvCod = P009T5_A396MVLPrvCod[0];
               A397MVLCosCod = P009T5_A397MVLCosCod[0];
               n397MVLCosCod = P009T5_n397MVLCosCod[0];
               A1297MVLCajReg = P009T5_A1297MVLCajReg[0];
               A1306MVLConCajCue = P009T5_A1306MVLConCajCue[0];
               A1310MVLCueAuxCod = P009T5_A1310MVLCueAuxCod[0];
               A392MVLITem = P009T5_A392MVLITem[0];
               A1307MVLConCajDsc = P009T5_A1307MVLConCajDsc[0];
               A1306MVLConCajCue = P009T5_A1306MVLConCajCue[0];
               AV41MVLCajConc = A1292MVLCajConc;
               AV44MVLCajDoc = A1293MVLCajDoc;
               AV42MVLCajFec = A1295MVLCajFec;
               AV43MVLConCajDsc = A1307MVLConCajDsc;
               AV39MVLCajImp = A1296MVLCajImp;
               AV58MVLPrvCod = A396MVLPrvCod;
               AV62MVLCosCod = A397MVLCosCod;
               AV66MVLCajReg = A1297MVLCajReg;
               /* Execute user subroutine: 'NOMBRECENTROCOSTO' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  this.cleanup();
                  if (true) return;
               }
               AV63MVLConCajCue = A1306MVLConCajCue;
               AV56MVLCueAuxCod = A1310MVLCueAuxCod;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56MVLCueAuxCod)) )
               {
                  AV56MVLCueAuxCod = AV58MVLPrvCod;
               }
               AV40Total = (decimal)(AV40Total+AV39MVLCajImp);
               H9T0( false, 20) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV42MVLCajFec, "99/99/99"), 2, Gx_line+3, 42, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41MVLCajConc, "")), 267, Gx_line+2, 527, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44MVLCajDoc, "")), 44, Gx_line+2, 104, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56MVLCueAuxCod, "")), 196, Gx_line+2, 256, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+0, 0, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+0, 42, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(109, Gx_line+0, 109, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(265, Gx_line+0, 265, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(535, Gx_line+0, 535, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(617, Gx_line+0, 617, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39MVLCajImp, "ZZZZZZ,ZZZ,ZZ9.99")), 736, Gx_line+2, 810, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(752, Gx_line+0, 752, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Costo, "")), 620, Gx_line+4, 751, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1306MVLConCajCue, "")), 547, Gx_line+2, 607, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(815, Gx_line+0, 815, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(183, Gx_line+0, 183, Gx_line+20, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66MVLCajReg, "")), 117, Gx_line+2, 177, Gx_line+16, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV64porReponer = (decimal)(AV54AperImpTotal-AV40Total);
            H9T0( false, 15) ;
            getPrinter().GxDrawLine(0, Gx_line+0, 815, Gx_line+0, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+15);
            H9T0( false, 177) ;
            getPrinter().GxDrawRect(0, Gx_line+81, 815, Gx_line+171, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(0, Gx_line+134, 815, Gx_line+134, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(238, Gx_line+82, 238, Gx_line+171, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Revisado", 93, Gx_line+146, 148, Gx_line+160, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Autorizado", 649, Gx_line+144, 715, Gx_line+158, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Por Reembolsar", 623, Gx_line+6, 715, Gx_line+20, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40Total, "ZZZZZZ,ZZZ,ZZ9.99")), 725, Gx_line+7, 810, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Usuario : ", 15, Gx_line+50, 70, Gx_line+64, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55UsuCod, "")), 80, Gx_line+51, 133, Gx_line+66, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Elaborado por", 368, Gx_line+143, 449, Gx_line+157, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(567, Gx_line+82, 567, Gx_line+171, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64porReponer, "ZZZZZZZZZZZ9.99")), 701, Gx_line+40, 811, Gx_line+55, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Saldo", 623, Gx_line+40, 682, Gx_line+53, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+177);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9T0( true, 0) ;
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
         /* 'NOMBRECENTROCOSTO' Routine */
         returnInSub = false;
         AV65Costo = "";
         /* Using cursor P009T6 */
         pr_default.execute(4, new Object[] {AV62MVLCosCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A79COSCod = P009T6_A79COSCod[0];
            A761COSDsc = P009T6_A761COSDsc[0];
            AV65Costo = A761COSDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void H9T0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 683, Gx_line+25, 715, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 683, Gx_line+43, 727, Gx_line+57, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 683, Gx_line+8, 722, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 742, Gx_line+8, 789, Gx_line+23, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 704, Gx_line+25, 788, Gx_line+40, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 750, Gx_line+43, 789, Gx_line+58, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 14, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Caja Chica", 354, Gx_line+5, 459, Gx_line+29, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+131, 815, Gx_line+330, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Caja Chica", 17, Gx_line+154, 78, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Caja", 17, Gx_line+176, 61, Gx_line+190, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Forma de Pago", 17, Gx_line+198, 106, Gx_line+212, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Banco", 17, Gx_line+220, 53, Gx_line+234, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cuenta", 17, Gx_line+242, 60, Gx_line+256, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37CajDsc, "")), 129, Gx_line+154, 396, Gx_line+168, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+303, 814, Gx_line+303, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 5, Gx_line+311, 36, Gx_line+322, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Docum.", 48, Gx_line+311, 102, Gx_line+322, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Concepto", 371, Gx_line+311, 420, Gx_line+322, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 759, Gx_line+311, 803, Gx_line+322, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Cheque", 17, Gx_line+264, 78, Gx_line+278, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuenta", 556, Gx_line+311, 593, Gx_line+322, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 14, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36MVLCajCod, "")), 348, Gx_line+30, 479, Gx_line+54, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38ForDsc, "")), 129, Gx_line+198, 403, Gx_line+212, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36MVLCajCod, "")), 129, Gx_line+176, 227, Gx_line+190, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10BanDsc, "")), 129, Gx_line+220, 406, Gx_line+234, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AperCueBan, "")), 129, Gx_line+242, 234, Gx_line+257, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AperCheque, "")), 129, Gx_line+264, 234, Gx_line+279, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha Apertura", 488, Gx_line+149, 580, Gx_line+163, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Estado", 488, Gx_line+171, 529, Gx_line+185, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 488, Gx_line+193, 536, Gx_line+208, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tope x Mov.", 488, Gx_line+215, 560, Gx_line+229, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Reposiciones", 488, Gx_line+258, 566, Gx_line+272, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total", 488, Gx_line+282, 519, Gx_line+296, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV47AperCajFec, "99/99/99"), 605, Gx_line+151, 652, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Estado, "")), 605, Gx_line+173, 684, Gx_line+188, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51AperTope, "ZZZZZZ,ZZZ,ZZ9.99")), 605, Gx_line+215, 712, Gx_line+230, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50MonDsc, "")), 605, Gx_line+195, 784, Gx_line+210, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53AperReponer, "ZZZZZZ,ZZZ,ZZ9.99")), 605, Gx_line+258, 712, Gx_line+273, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54AperImpTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 605, Gx_line+282, 712, Gx_line+297, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+304, 42, Gx_line+330, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(265, Gx_line+304, 265, Gx_line+330, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(535, Gx_line+303, 535, Gx_line+329, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(617, Gx_line+304, 617, Gx_line+330, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(109, Gx_line+304, 109, Gx_line+330, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Auxiliar/RUC", 193, Gx_line+311, 263, Gx_line+322, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV59Logo)) ? A40000Logo_GXI : AV59Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 13, Gx_line+3, 171, Gx_line+81) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60EmpRUC, "")), 13, Gx_line+113, 273, Gx_line+131, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21EmpDir, "")), 13, Gx_line+95, 340, Gx_line+113, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Empresa, "")), 13, Gx_line+78, 338, Gx_line+96, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52AperSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 605, Gx_line+236, 712, Gx_line+251, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Saldo Anterior", 488, Gx_line+236, 573, Gx_line+250, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(752, Gx_line+303, 752, Gx_line+329, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Centro Costos", 642, Gx_line+310, 728, Gx_line+324, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(183, Gx_line+304, 183, Gx_line+330, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Registro", 115, Gx_line+311, 175, Gx_line+322, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+330);
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
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics2( )
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
         AV19Empresa = "";
         AV20Session = context.GetSession();
         AV21EmpDir = "";
         AV22EmpTelf = "";
         AV55UsuCod = "";
         AV49Estado = "";
         scmdbuf = "";
         P009T2_A363AperForCod = new int[1] ;
         P009T2_A359AperCajCod = new string[] {""} ;
         P009T2_A358CajCod = new int[1] ;
         P009T2_A486CajDsc = new string[] {""} ;
         P009T2_A988ForDsc = new string[] {""} ;
         P009T2_n988ForDsc = new bool[] {false} ;
         P009T2_A441AperCajFec = new DateTime[] {DateTime.MinValue} ;
         P009T2_A361AperBanCod = new int[1] ;
         P009T2_n361AperBanCod = new bool[] {false} ;
         P009T2_A362AperCueBan = new string[] {""} ;
         P009T2_n362AperCueBan = new bool[] {false} ;
         P009T2_A442AperCheque = new string[] {""} ;
         P009T2_A470AperSts = new string[] {""} ;
         P009T2_A364AperMonCod = new int[1] ;
         P009T2_A473AperTope = new decimal[1] ;
         P009T2_A467AperReponer = new decimal[1] ;
         P009T2_A455AperImporte = new decimal[1] ;
         P009T2_A457AperSaldo = new decimal[1] ;
         A359AperCajCod = "";
         A486CajDsc = "";
         A988ForDsc = "";
         A441AperCajFec = DateTime.MinValue;
         A362AperCueBan = "";
         A442AperCheque = "";
         A470AperSts = "";
         AV37CajDsc = "";
         AV38ForDsc = "";
         AV47AperCajFec = DateTime.MinValue;
         AV10BanDsc = "";
         AV45AperCueBan = "";
         AV46AperCheque = "";
         AV48AperSts = "";
         P009T3_A372BanCod = new int[1] ;
         P009T3_A482BanDsc = new string[] {""} ;
         A482BanDsc = "";
         P009T4_A180MonCod = new int[1] ;
         P009T4_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV50MonDsc = "";
         P009T5_A399MVLConcCajCod = new int[1] ;
         P009T5_A391MVLCajCod = new string[] {""} ;
         P009T5_A358CajCod = new int[1] ;
         P009T5_A1292MVLCajConc = new string[] {""} ;
         P009T5_A1293MVLCajDoc = new string[] {""} ;
         P009T5_A1295MVLCajFec = new DateTime[] {DateTime.MinValue} ;
         P009T5_A1307MVLConCajDsc = new string[] {""} ;
         P009T5_A1296MVLCajImp = new decimal[1] ;
         P009T5_A396MVLPrvCod = new string[] {""} ;
         P009T5_A397MVLCosCod = new string[] {""} ;
         P009T5_n397MVLCosCod = new bool[] {false} ;
         P009T5_A1297MVLCajReg = new string[] {""} ;
         P009T5_A1306MVLConCajCue = new string[] {""} ;
         P009T5_A1310MVLCueAuxCod = new string[] {""} ;
         P009T5_A392MVLITem = new int[1] ;
         A391MVLCajCod = "";
         A1292MVLCajConc = "";
         A1293MVLCajDoc = "";
         A1295MVLCajFec = DateTime.MinValue;
         A1307MVLConCajDsc = "";
         A396MVLPrvCod = "";
         A397MVLCosCod = "";
         A1297MVLCajReg = "";
         A1306MVLConCajCue = "";
         A1310MVLCueAuxCod = "";
         AV41MVLCajConc = "";
         AV44MVLCajDoc = "";
         AV42MVLCajFec = DateTime.MinValue;
         AV43MVLConCajDsc = "";
         AV58MVLPrvCod = "";
         AV62MVLCosCod = "";
         AV66MVLCajReg = "";
         AV63MVLConCajCue = "";
         AV56MVLCueAuxCod = "";
         AV65Costo = "";
         P009T6_A79COSCod = new string[] {""} ;
         P009T6_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV59Logo = "";
         sImgUrl = "";
         AV59Logo = "";
         A40000Logo_GXI = "";
         AV60EmpRUC = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrmovimientoscajachica__default(),
            new Object[][] {
                new Object[] {
               P009T2_A363AperForCod, P009T2_A359AperCajCod, P009T2_A358CajCod, P009T2_A486CajDsc, P009T2_A988ForDsc, P009T2_n988ForDsc, P009T2_A441AperCajFec, P009T2_A361AperBanCod, P009T2_n361AperBanCod, P009T2_A362AperCueBan,
               P009T2_n362AperCueBan, P009T2_A442AperCheque, P009T2_A470AperSts, P009T2_A364AperMonCod, P009T2_A473AperTope, P009T2_A467AperReponer, P009T2_A455AperImporte, P009T2_A457AperSaldo
               }
               , new Object[] {
               P009T3_A372BanCod, P009T3_A482BanDsc
               }
               , new Object[] {
               P009T4_A180MonCod, P009T4_A1234MonDsc
               }
               , new Object[] {
               P009T5_A399MVLConcCajCod, P009T5_A391MVLCajCod, P009T5_A358CajCod, P009T5_A1292MVLCajConc, P009T5_A1293MVLCajDoc, P009T5_A1295MVLCajFec, P009T5_A1307MVLConCajDsc, P009T5_A1296MVLCajImp, P009T5_A396MVLPrvCod, P009T5_A397MVLCosCod,
               P009T5_n397MVLCosCod, P009T5_A1297MVLCajReg, P009T5_A1306MVLConCajCue, P009T5_A1310MVLCueAuxCod, P009T5_A392MVLITem
               }
               , new Object[] {
               P009T6_A79COSCod, P009T6_A761COSDsc
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
      private int AV35CajCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A363AperForCod ;
      private int A358CajCod ;
      private int A361AperBanCod ;
      private int A364AperMonCod ;
      private int AV9BanCod ;
      private int AV57AperMonCod ;
      private int A372BanCod ;
      private int A180MonCod ;
      private int A399MVLConcCajCod ;
      private int A392MVLITem ;
      private int Gx_OldLine ;
      private decimal AV40Total ;
      private decimal A473AperTope ;
      private decimal A467AperReponer ;
      private decimal A455AperImporte ;
      private decimal A457AperSaldo ;
      private decimal A456AperImpTotal ;
      private decimal AV39MVLCajImp ;
      private decimal AV51AperTope ;
      private decimal AV52AperSaldo ;
      private decimal AV53AperReponer ;
      private decimal AV54AperImpTotal ;
      private decimal A1296MVLCajImp ;
      private decimal AV64porReponer ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV36MVLCajCod ;
      private string AV19Empresa ;
      private string AV21EmpDir ;
      private string AV22EmpTelf ;
      private string AV55UsuCod ;
      private string AV49Estado ;
      private string scmdbuf ;
      private string A359AperCajCod ;
      private string A486CajDsc ;
      private string A988ForDsc ;
      private string A362AperCueBan ;
      private string A442AperCheque ;
      private string A470AperSts ;
      private string AV37CajDsc ;
      private string AV38ForDsc ;
      private string AV10BanDsc ;
      private string AV45AperCueBan ;
      private string AV46AperCheque ;
      private string AV48AperSts ;
      private string A482BanDsc ;
      private string A1234MonDsc ;
      private string AV50MonDsc ;
      private string A391MVLCajCod ;
      private string A1292MVLCajConc ;
      private string A1293MVLCajDoc ;
      private string A1307MVLConCajDsc ;
      private string A396MVLPrvCod ;
      private string A397MVLCosCod ;
      private string A1297MVLCajReg ;
      private string A1306MVLConCajCue ;
      private string A1310MVLCueAuxCod ;
      private string AV41MVLCajConc ;
      private string AV44MVLCajDoc ;
      private string AV43MVLConCajDsc ;
      private string AV58MVLPrvCod ;
      private string AV62MVLCosCod ;
      private string AV66MVLCajReg ;
      private string AV63MVLConCajCue ;
      private string AV56MVLCueAuxCod ;
      private string AV65Costo ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private string AV60EmpRUC ;
      private DateTime A441AperCajFec ;
      private DateTime AV47AperCajFec ;
      private DateTime A1295MVLCajFec ;
      private DateTime AV42MVLCajFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n988ForDsc ;
      private bool n361AperBanCod ;
      private bool n362AperCueBan ;
      private bool n397MVLCosCod ;
      private bool returnInSub ;
      private string A40000Logo_GXI ;
      private string Logo ;
      private string AV59Logo ;
      private IGxSession AV20Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_CajCod ;
      private string aP1_MVLCajCod ;
      private IDataStoreProvider pr_default ;
      private int[] P009T2_A363AperForCod ;
      private string[] P009T2_A359AperCajCod ;
      private int[] P009T2_A358CajCod ;
      private string[] P009T2_A486CajDsc ;
      private string[] P009T2_A988ForDsc ;
      private bool[] P009T2_n988ForDsc ;
      private DateTime[] P009T2_A441AperCajFec ;
      private int[] P009T2_A361AperBanCod ;
      private bool[] P009T2_n361AperBanCod ;
      private string[] P009T2_A362AperCueBan ;
      private bool[] P009T2_n362AperCueBan ;
      private string[] P009T2_A442AperCheque ;
      private string[] P009T2_A470AperSts ;
      private int[] P009T2_A364AperMonCod ;
      private decimal[] P009T2_A473AperTope ;
      private decimal[] P009T2_A467AperReponer ;
      private decimal[] P009T2_A455AperImporte ;
      private decimal[] P009T2_A457AperSaldo ;
      private int[] P009T3_A372BanCod ;
      private string[] P009T3_A482BanDsc ;
      private int[] P009T4_A180MonCod ;
      private string[] P009T4_A1234MonDsc ;
      private int[] P009T5_A399MVLConcCajCod ;
      private string[] P009T5_A391MVLCajCod ;
      private int[] P009T5_A358CajCod ;
      private string[] P009T5_A1292MVLCajConc ;
      private string[] P009T5_A1293MVLCajDoc ;
      private DateTime[] P009T5_A1295MVLCajFec ;
      private string[] P009T5_A1307MVLConCajDsc ;
      private decimal[] P009T5_A1296MVLCajImp ;
      private string[] P009T5_A396MVLPrvCod ;
      private string[] P009T5_A397MVLCosCod ;
      private bool[] P009T5_n397MVLCosCod ;
      private string[] P009T5_A1297MVLCajReg ;
      private string[] P009T5_A1306MVLConCajCue ;
      private string[] P009T5_A1310MVLCueAuxCod ;
      private int[] P009T5_A392MVLITem ;
      private string[] P009T6_A79COSCod ;
      private string[] P009T6_A761COSDsc ;
   }

   public class rrmovimientoscajachica__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009T2;
          prmP009T2 = new Object[] {
          new ParDef("@AV35CajCod",GXType.Int32,6,0) ,
          new ParDef("@AV36MVLCajCod",GXType.NChar,10,0)
          };
          Object[] prmP009T3;
          prmP009T3 = new Object[] {
          new ParDef("@AV9BanCod",GXType.Int32,6,0)
          };
          Object[] prmP009T4;
          prmP009T4 = new Object[] {
          new ParDef("@AV57AperMonCod",GXType.Int32,6,0)
          };
          Object[] prmP009T5;
          prmP009T5 = new Object[] {
          new ParDef("@AV35CajCod",GXType.Int32,6,0) ,
          new ParDef("@AV36MVLCajCod",GXType.NChar,10,0)
          };
          Object[] prmP009T6;
          prmP009T6 = new Object[] {
          new ParDef("@AV62MVLCosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009T2", "SELECT T1.[AperForCod] AS AperForCod, T1.[AperCajCod], T1.[CajCod], T3.[CajDsc], T2.[ForDsc], T1.[AperCajFec], T1.[AperBanCod], T1.[AperCueBan], T1.[AperCheque], T1.[AperSts], T1.[AperMonCod], T1.[AperTope], T1.[AperReponer], T1.[AperImporte], T1.[AperSaldo] FROM (([TSAPERTURACAJA] T1 INNER JOIN [CFORMAPAGO] T2 ON T2.[ForCod] = T1.[AperForCod]) INNER JOIN [TSCAJACHICA] T3 ON T3.[CajCod] = T1.[CajCod]) WHERE T1.[CajCod] = @AV35CajCod and T1.[AperCajCod] = @AV36MVLCajCod ORDER BY T1.[CajCod], T1.[AperCajCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009T2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009T3", "SELECT [BanCod], [BanDsc] FROM [TSBANCOS] WHERE [BanCod] = @AV9BanCod ORDER BY [BanCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009T3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009T4", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV57AperMonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009T4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009T5", "SELECT T1.[MVLConcCajCod] AS MVLConcCajCod, T1.[MVLCajCod], T1.[CajCod], T1.[MVLCajConc], T1.[MVLCajDoc], T1.[MVLCajFec], T2.[ConCajDsc] AS MVLConCajDsc, T1.[MVLCajImp], T1.[MVLPrvCod], T1.[MVLCosCod], T1.[MVLCajReg], T2.[CueCod] AS MVLConCajCue, T1.[MVLCueAuxCod], T1.[MVLITem] FROM ([TSMOVCAJACHICA] T1 INNER JOIN [TSCONCEPTOCAJA] T2 ON T2.[ConCajCod] = T1.[MVLConcCajCod]) WHERE T1.[CajCod] = @AV35CajCod and T1.[MVLCajCod] = @AV36MVLCajCod ORDER BY T1.[CajCod], T1.[MVLCajCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009T5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009T6", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV62MVLCosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009T6,1, GxCacheFrequency.OFF ,false,true )
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
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 10);
                ((string[]) buf[12])[0] = rslt.getString(12, 15);
                ((string[]) buf[13])[0] = rslt.getString(13, 20);
                ((int[]) buf[14])[0] = rslt.getInt(14);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
