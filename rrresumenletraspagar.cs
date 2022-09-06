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
   public class rrresumenletraspagar : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrresumenletraspagar.aspx")), "rrresumenletraspagar.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrresumenletraspagar.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "PrvCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV37PrvCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV38BanCod = (int)(NumberUtil.Val( GetPar( "BanCod"), "."));
                  AV49LetPSec = (int)(NumberUtil.Val( GetPar( "LetPSec"), "."));
                  AV14MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV30FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV31FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV54CPEstado = GetPar( "CPEstado");
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

      public rrresumenletraspagar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrresumenletraspagar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_PrvCod ,
                           ref int aP1_BanCod ,
                           ref int aP2_LetPSec ,
                           ref int aP3_MonCod ,
                           ref DateTime aP4_FDesde ,
                           ref DateTime aP5_FHasta ,
                           ref string aP6_CPEstado )
      {
         this.AV37PrvCod = aP0_PrvCod;
         this.AV38BanCod = aP1_BanCod;
         this.AV49LetPSec = aP2_LetPSec;
         this.AV14MonCod = aP3_MonCod;
         this.AV30FDesde = aP4_FDesde;
         this.AV31FHasta = aP5_FHasta;
         this.AV54CPEstado = aP6_CPEstado;
         initialize();
         executePrivate();
         aP0_PrvCod=this.AV37PrvCod;
         aP1_BanCod=this.AV38BanCod;
         aP2_LetPSec=this.AV49LetPSec;
         aP3_MonCod=this.AV14MonCod;
         aP4_FDesde=this.AV30FDesde;
         aP5_FHasta=this.AV31FHasta;
         aP6_CPEstado=this.AV54CPEstado;
      }

      public string executeUdp( ref string aP0_PrvCod ,
                                ref int aP1_BanCod ,
                                ref int aP2_LetPSec ,
                                ref int aP3_MonCod ,
                                ref DateTime aP4_FDesde ,
                                ref DateTime aP5_FHasta )
      {
         execute(ref aP0_PrvCod, ref aP1_BanCod, ref aP2_LetPSec, ref aP3_MonCod, ref aP4_FDesde, ref aP5_FHasta, ref aP6_CPEstado);
         return AV54CPEstado ;
      }

      public void executeSubmit( ref string aP0_PrvCod ,
                                 ref int aP1_BanCod ,
                                 ref int aP2_LetPSec ,
                                 ref int aP3_MonCod ,
                                 ref DateTime aP4_FDesde ,
                                 ref DateTime aP5_FHasta ,
                                 ref string aP6_CPEstado )
      {
         rrresumenletraspagar objrrresumenletraspagar;
         objrrresumenletraspagar = new rrresumenletraspagar();
         objrrresumenletraspagar.AV37PrvCod = aP0_PrvCod;
         objrrresumenletraspagar.AV38BanCod = aP1_BanCod;
         objrrresumenletraspagar.AV49LetPSec = aP2_LetPSec;
         objrrresumenletraspagar.AV14MonCod = aP3_MonCod;
         objrrresumenletraspagar.AV30FDesde = aP4_FDesde;
         objrrresumenletraspagar.AV31FHasta = aP5_FHasta;
         objrrresumenletraspagar.AV54CPEstado = aP6_CPEstado;
         objrrresumenletraspagar.context.SetSubmitInitialConfig(context);
         objrrresumenletraspagar.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrresumenletraspagar);
         aP0_PrvCod=this.AV37PrvCod;
         aP1_BanCod=this.AV38BanCod;
         aP2_LetPSec=this.AV49LetPSec;
         aP3_MonCod=this.AV14MonCod;
         aP4_FDesde=this.AV30FDesde;
         aP5_FHasta=this.AV31FHasta;
         aP6_CPEstado=this.AV54CPEstado;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrresumenletraspagar)stateInfo).executePrivate();
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
            AV43Empresa = AV48Session.Get("Empresa");
            AV44EmpDir = AV48Session.Get("EmpDir");
            AV45EmpRUC = AV48Session.Get("EmpRUC");
            AV46Ruta = AV48Session.Get("RUTA") + "/Logo.jpg";
            AV47Logo = AV46Ruta;
            AV58Logo_GXI = GXDbFile.PathToUrl( AV46Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = context.localUtil.DToC( AV30FDesde, 2, "/");
            AV24Filtro3 = context.localUtil.DToC( AV31FHasta, 2, "/");
            /* Using cursor P00AA2 */
            pr_default.execute(0, new Object[] {AV14MonCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P00AA2_A180MonCod[0];
               A1234MonDsc = P00AA2_A1234MonDsc[0];
               AV22Filtro1 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV16TotImporte = 0.00m;
            AV18TotSaldo = 0.00m;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV37PrvCod ,
                                                 AV38BanCod ,
                                                 AV49LetPSec ,
                                                 AV14MonCod ,
                                                 A267LetPPrvCod ,
                                                 A1127LetPBanCod ,
                                                 A1142LetPSec ,
                                                 A266LetPMonCod ,
                                                 A1146LetPTipo ,
                                                 AV30FDesde ,
                                                 A1135LetPFecVcto ,
                                                 AV31FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00AA3 */
            pr_default.execute(1, new Object[] {AV30FDesde, AV31FHasta, AV37PrvCod, AV38BanCod, AV49LetPSec, AV14MonCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A265LetPLetCod = P00AA3_A265LetPLetCod[0];
               A1146LetPTipo = P00AA3_A1146LetPTipo[0];
               A1135LetPFecVcto = P00AA3_A1135LetPFecVcto[0];
               A266LetPMonCod = P00AA3_A266LetPMonCod[0];
               A1142LetPSec = P00AA3_A1142LetPSec[0];
               A1127LetPBanCod = P00AA3_A1127LetPBanCod[0];
               A267LetPPrvCod = P00AA3_A267LetPPrvCod[0];
               A269LetPTipCod = P00AA3_A269LetPTipCod[0];
               A1131LetPDocNum = P00AA3_A1131LetPDocNum[0];
               A1133LetPDPrvCod = P00AA3_A1133LetPDPrvCod[0];
               A1138LetPImpDet = P00AA3_A1138LetPImpDet[0];
               A1130LetPDias = P00AA3_A1130LetPDias[0];
               A1128LetPBanNum = P00AA3_A1128LetPBanNum[0];
               A247PrvDsc = P00AA3_A247PrvDsc[0];
               n247PrvDsc = P00AA3_n247PrvDsc[0];
               A1134LetPFecLet = P00AA3_A1134LetPFecLet[0];
               A268LetPItem = P00AA3_A268LetPItem[0];
               A266LetPMonCod = P00AA3_A266LetPMonCod[0];
               A267LetPPrvCod = P00AA3_A267LetPPrvCod[0];
               A247PrvDsc = P00AA3_A247PrvDsc[0];
               n247PrvDsc = P00AA3_n247PrvDsc[0];
               AV51LetCTipCod = A269LetPTipCod;
               AV52LetCDocNum = A1131LetPDocNum;
               AV55LetPPrvCod = A1133LetPDPrvCod;
               AV50LetCBanCod = A1127LetPBanCod;
               AV40Seccion = "";
               /* Execute user subroutine: 'BANCO' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'SALDOCXC' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               if ( A1142LetPSec == 1 )
               {
                  AV40Seccion = "Cartera";
               }
               if ( A1142LetPSec == 2 )
               {
                  AV40Seccion = "Descuento";
               }
               if ( A1142LetPSec == 3 )
               {
                  AV40Seccion = "Cobranza";
               }
               if ( A1142LetPSec == 4 )
               {
                  AV40Seccion = "Cobranza Libre";
               }
               if ( A1142LetPSec == 5 )
               {
                  AV40Seccion = "Garantia";
               }
               if ( A1142LetPSec == 6 )
               {
                  AV40Seccion = "Protestado";
               }
               if ( A1142LetPSec == 7 )
               {
                  AV40Seccion = "Refinanciado";
               }
               if ( StringUtil.StrCmp(AV53Estado, AV54CPEstado) == 0 )
               {
                  AV16TotImporte = (decimal)(AV16TotImporte+A1138LetPImpDet);
                  AV18TotSaldo = (decimal)(AV18TotSaldo+AV15Saldo);
                  HAA0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A1134LetPFecLet, "99/99/99"), 5, Gx_line+1, 52, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A247PrvDsc, "")), 64, Gx_line+1, 353, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Seccion, "")), 600, Gx_line+1, 673, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1128LetPBanNum, "")), 684, Gx_line+1, 762, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41Banco, "")), 449, Gx_line+0, 590, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1131LetPDocNum, "")), 359, Gx_line+1, 453, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1138LetPImpDet, "ZZZZZZ,ZZZ,ZZ9.99")), 748, Gx_line+1, 855, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1130LetPDias), "ZZZ9")), 863, Gx_line+1, 893, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A1135LetPFecVcto, "99/99/99"), 906, Gx_line+1, 961, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1138LetPImpDet, "ZZZZZZ,ZZZ,ZZ9.99")), 938, Gx_line+1, 1063, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV15Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 1019, Gx_line+1, 1144, Gx_line+16, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            HAA0( false, 86) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 1019, Gx_line+36, 1144, Gx_line+51, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 938, Gx_line+36, 1063, Gx_line+51, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 834, Gx_line+36, 914, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(959, Gx_line+29, 1148, Gx_line+29, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+86);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAA0( true, 0) ;
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
         /* 'BANCO' Routine */
         returnInSub = false;
         AV41Banco = "";
         /* Using cursor P00AA4 */
         pr_default.execute(2, new Object[] {AV50LetCBanCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A372BanCod = P00AA4_A372BanCod[0];
            A482BanDsc = P00AA4_A482BanDsc[0];
            AV41Banco = A482BanDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      protected void S121( )
      {
         /* 'SALDOCXC' Routine */
         returnInSub = false;
         AV15Saldo = 0.00m;
         AV53Estado = "";
         /* Using cursor P00AA5 */
         pr_default.execute(3, new Object[] {AV51LetCTipCod, AV52LetCDocNum, AV55LetPPrvCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A262CPPrvCod = P00AA5_A262CPPrvCod[0];
            A261CPComCod = P00AA5_A261CPComCod[0];
            A260CPTipCod = P00AA5_A260CPTipCod[0];
            A815CPEstado = P00AA5_A815CPEstado[0];
            A818CPImpPago = P00AA5_A818CPImpPago[0];
            A820CPImpTotal = P00AA5_A820CPImpTotal[0];
            A819CPImpSaldo = (decimal)(A820CPImpTotal-A818CPImpPago);
            AV15Saldo = A819CPImpSaldo;
            AV53Estado = A815CPEstado;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void HAA0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 1038, Gx_line+39, 1070, Gx_line+53, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 1038, Gx_line+56, 1082, Gx_line+70, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 1038, Gx_line+21, 1077, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1094, Gx_line+56, 1133, Gx_line+71, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1071, Gx_line+39, 1131, Gx_line+53, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1085, Gx_line+21, 1132, Gx_line+36, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 14, Gx_line+166, 49, Gx_line+180, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 157, Gx_line+166, 219, Gx_line+180, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Banco", 495, Gx_line+176, 531, Gx_line+190, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+151, 1148, Gx_line+194, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Letras por Pagar", 467, Gx_line+54, 610, Gx_line+74, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Letra", 379, Gx_line+166, 428, Gx_line+180, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tenedor de Documento", 534, Gx_line+153, 673, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 373, Gx_line+95, 410, Gx_line+109, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta", 547, Gx_line+95, 582, Gx_line+109, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro2, "")), 426, Gx_line+90, 492, Gx_line+114, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro3, "")), 600, Gx_line+90, 666, Gx_line+114, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Imp. Letra", 782, Gx_line+166, 844, Gx_line+180, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV47Logo)) ? AV58Logo_GXI : AV47Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+26, 176, Gx_line+104) ;
               getPrinter().GxDrawText("Moneda", 373, Gx_line+118, 421, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 426, Gx_line+113, 769, Gx_line+137, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Sec", 627, Gx_line+176, 649, Gx_line+190, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Banco", 695, Gx_line+176, 748, Gx_line+190, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dias", 863, Gx_line+166, 889, Gx_line+180, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Vcto", 905, Gx_line+166, 970, Gx_line+180, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pagos", 1041, Gx_line+153, 1077, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 993, Gx_line+176, 1043, Gx_line+190, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 1090, Gx_line+176, 1123, Gx_line+190, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(973, Gx_line+152, 973, Gx_line+194, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(895, Gx_line+152, 895, Gx_line+194, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(854, Gx_line+152, 854, Gx_line+194, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(764, Gx_line+152, 764, Gx_line+194, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(447, Gx_line+152, 447, Gx_line+194, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(365, Gx_line+152, 365, Gx_line+194, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(61, Gx_line+152, 61, Gx_line+194, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(447, Gx_line+169, 765, Gx_line+169, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(678, Gx_line+169, 678, Gx_line+193, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(593, Gx_line+170, 593, Gx_line+194, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(973, Gx_line+169, 1148, Gx_line+169, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1065, Gx_line+170, 1065, Gx_line+194, 1, 0, 0, 0, 0) ;
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
         AV43Empresa = "";
         AV48Session = context.GetSession();
         AV44EmpDir = "";
         AV45EmpRUC = "";
         AV46Ruta = "";
         AV47Logo = "";
         AV58Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         scmdbuf = "";
         P00AA2_A180MonCod = new int[1] ;
         P00AA2_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         A267LetPPrvCod = "";
         A1146LetPTipo = "";
         A1135LetPFecVcto = DateTime.MinValue;
         P00AA3_A265LetPLetCod = new string[] {""} ;
         P00AA3_A1146LetPTipo = new string[] {""} ;
         P00AA3_A1135LetPFecVcto = new DateTime[] {DateTime.MinValue} ;
         P00AA3_A266LetPMonCod = new int[1] ;
         P00AA3_A1142LetPSec = new int[1] ;
         P00AA3_A1127LetPBanCod = new int[1] ;
         P00AA3_A267LetPPrvCod = new string[] {""} ;
         P00AA3_A269LetPTipCod = new string[] {""} ;
         P00AA3_A1131LetPDocNum = new string[] {""} ;
         P00AA3_A1133LetPDPrvCod = new string[] {""} ;
         P00AA3_A1138LetPImpDet = new decimal[1] ;
         P00AA3_A1130LetPDias = new short[1] ;
         P00AA3_A1128LetPBanNum = new string[] {""} ;
         P00AA3_A247PrvDsc = new string[] {""} ;
         P00AA3_n247PrvDsc = new bool[] {false} ;
         P00AA3_A1134LetPFecLet = new DateTime[] {DateTime.MinValue} ;
         P00AA3_A268LetPItem = new int[1] ;
         A265LetPLetCod = "";
         A269LetPTipCod = "";
         A1131LetPDocNum = "";
         A1133LetPDPrvCod = "";
         A1128LetPBanNum = "";
         A247PrvDsc = "";
         A1134LetPFecLet = DateTime.MinValue;
         AV51LetCTipCod = "";
         AV52LetCDocNum = "";
         AV55LetPPrvCod = "";
         AV40Seccion = "";
         AV53Estado = "";
         AV41Banco = "";
         P00AA4_A372BanCod = new int[1] ;
         P00AA4_A482BanDsc = new string[] {""} ;
         A482BanDsc = "";
         P00AA5_A262CPPrvCod = new string[] {""} ;
         P00AA5_A261CPComCod = new string[] {""} ;
         P00AA5_A260CPTipCod = new string[] {""} ;
         P00AA5_A815CPEstado = new string[] {""} ;
         P00AA5_A818CPImpPago = new decimal[1] ;
         P00AA5_A820CPImpTotal = new decimal[1] ;
         A262CPPrvCod = "";
         A261CPComCod = "";
         A260CPTipCod = "";
         A815CPEstado = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV47Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrresumenletraspagar__default(),
            new Object[][] {
                new Object[] {
               P00AA2_A180MonCod, P00AA2_A1234MonDsc
               }
               , new Object[] {
               P00AA3_A265LetPLetCod, P00AA3_A1146LetPTipo, P00AA3_A1135LetPFecVcto, P00AA3_A266LetPMonCod, P00AA3_A1142LetPSec, P00AA3_A1127LetPBanCod, P00AA3_A267LetPPrvCod, P00AA3_A269LetPTipCod, P00AA3_A1131LetPDocNum, P00AA3_A1133LetPDPrvCod,
               P00AA3_A1138LetPImpDet, P00AA3_A1130LetPDias, P00AA3_A1128LetPBanNum, P00AA3_A247PrvDsc, P00AA3_n247PrvDsc, P00AA3_A1134LetPFecLet, P00AA3_A268LetPItem
               }
               , new Object[] {
               P00AA4_A372BanCod, P00AA4_A482BanDsc
               }
               , new Object[] {
               P00AA5_A262CPPrvCod, P00AA5_A261CPComCod, P00AA5_A260CPTipCod, P00AA5_A815CPEstado, P00AA5_A818CPImpPago, P00AA5_A820CPImpTotal
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
      private short A1130LetPDias ;
      private int AV38BanCod ;
      private int AV49LetPSec ;
      private int AV14MonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int A1127LetPBanCod ;
      private int A1142LetPSec ;
      private int A266LetPMonCod ;
      private int A268LetPItem ;
      private int AV50LetCBanCod ;
      private int Gx_OldLine ;
      private int A372BanCod ;
      private decimal AV16TotImporte ;
      private decimal AV18TotSaldo ;
      private decimal A1138LetPImpDet ;
      private decimal AV15Saldo ;
      private decimal A818CPImpPago ;
      private decimal A820CPImpTotal ;
      private decimal A819CPImpSaldo ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV37PrvCod ;
      private string AV54CPEstado ;
      private string AV43Empresa ;
      private string AV44EmpDir ;
      private string AV45EmpRUC ;
      private string AV46Ruta ;
      private string AV22Filtro1 ;
      private string AV23Filtro2 ;
      private string AV24Filtro3 ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string A267LetPPrvCod ;
      private string A1146LetPTipo ;
      private string A265LetPLetCod ;
      private string A269LetPTipCod ;
      private string A1131LetPDocNum ;
      private string A1133LetPDPrvCod ;
      private string A1128LetPBanNum ;
      private string A247PrvDsc ;
      private string AV51LetCTipCod ;
      private string AV52LetCDocNum ;
      private string AV55LetPPrvCod ;
      private string AV40Seccion ;
      private string AV53Estado ;
      private string AV41Banco ;
      private string A482BanDsc ;
      private string A262CPPrvCod ;
      private string A261CPComCod ;
      private string A260CPTipCod ;
      private string A815CPEstado ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV30FDesde ;
      private DateTime AV31FHasta ;
      private DateTime A1135LetPFecVcto ;
      private DateTime A1134LetPFecLet ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n247PrvDsc ;
      private bool returnInSub ;
      private string AV58Logo_GXI ;
      private string AV47Logo ;
      private string Logo ;
      private IGxSession AV48Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_PrvCod ;
      private int aP1_BanCod ;
      private int aP2_LetPSec ;
      private int aP3_MonCod ;
      private DateTime aP4_FDesde ;
      private DateTime aP5_FHasta ;
      private string aP6_CPEstado ;
      private IDataStoreProvider pr_default ;
      private int[] P00AA2_A180MonCod ;
      private string[] P00AA2_A1234MonDsc ;
      private string[] P00AA3_A265LetPLetCod ;
      private string[] P00AA3_A1146LetPTipo ;
      private DateTime[] P00AA3_A1135LetPFecVcto ;
      private int[] P00AA3_A266LetPMonCod ;
      private int[] P00AA3_A1142LetPSec ;
      private int[] P00AA3_A1127LetPBanCod ;
      private string[] P00AA3_A267LetPPrvCod ;
      private string[] P00AA3_A269LetPTipCod ;
      private string[] P00AA3_A1131LetPDocNum ;
      private string[] P00AA3_A1133LetPDPrvCod ;
      private decimal[] P00AA3_A1138LetPImpDet ;
      private short[] P00AA3_A1130LetPDias ;
      private string[] P00AA3_A1128LetPBanNum ;
      private string[] P00AA3_A247PrvDsc ;
      private bool[] P00AA3_n247PrvDsc ;
      private DateTime[] P00AA3_A1134LetPFecLet ;
      private int[] P00AA3_A268LetPItem ;
      private int[] P00AA4_A372BanCod ;
      private string[] P00AA4_A482BanDsc ;
      private string[] P00AA5_A262CPPrvCod ;
      private string[] P00AA5_A261CPComCod ;
      private string[] P00AA5_A260CPTipCod ;
      private string[] P00AA5_A815CPEstado ;
      private decimal[] P00AA5_A818CPImpPago ;
      private decimal[] P00AA5_A820CPImpTotal ;
   }

   public class rrresumenletraspagar__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AA3( IGxContext context ,
                                             string AV37PrvCod ,
                                             int AV38BanCod ,
                                             int AV49LetPSec ,
                                             int AV14MonCod ,
                                             string A267LetPPrvCod ,
                                             int A1127LetPBanCod ,
                                             int A1142LetPSec ,
                                             int A266LetPMonCod ,
                                             string A1146LetPTipo ,
                                             DateTime AV30FDesde ,
                                             DateTime A1135LetPFecVcto ,
                                             DateTime AV31FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[LetPLetCod], T1.[LetPTipo], T1.[LetPFecVcto], T2.[LetPMonCod], T1.[LetPSec], T1.[LetPBanCod], T2.[LetPPrvCod] AS LetPPrvCod, T1.[LetPTipCod], T1.[LetPDocNum], T1.[LetPDPrvCod], T1.[LetPImpDet], T1.[LetPDias], T1.[LetPBanNum], T3.[PrvDsc], T1.[LetPFecLet], T1.[LetPItem] FROM (([CPLETRASDET] T1 INNER JOIN [CPLETRAS] T2 ON T2.[LetPLetCod] = T1.[LetPLetCod]) INNER JOIN [CPPROVEEDORES] T3 ON T3.[PrvCod] = T2.[LetPPrvCod])";
         AddWhere(sWhereString, "(T1.[LetPFecVcto] >= @AV30FDesde)");
         AddWhere(sWhereString, "(T1.[LetPTipo] = 'L')");
         AddWhere(sWhereString, "(T1.[LetPFecVcto] <= @AV31FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37PrvCod)) )
         {
            AddWhere(sWhereString, "(T2.[LetPPrvCod] = @AV37PrvCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV38BanCod) )
         {
            AddWhere(sWhereString, "(T1.[LetPBanCod] = @AV38BanCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV49LetPSec) )
         {
            AddWhere(sWhereString, "(T1.[LetPSec] = @AV49LetPSec)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T2.[LetPMonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[LetPFecVcto]";
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
                     return conditional_P00AA3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] );
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
          Object[] prmP00AA2;
          prmP00AA2 = new Object[] {
          new ParDef("@AV14MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00AA4;
          prmP00AA4 = new Object[] {
          new ParDef("@AV50LetCBanCod",GXType.Int32,6,0)
          };
          Object[] prmP00AA5;
          prmP00AA5 = new Object[] {
          new ParDef("@AV51LetCTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV52LetCDocNum",GXType.NChar,15,0) ,
          new ParDef("@AV55LetPPrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AA3;
          prmP00AA3 = new Object[] {
          new ParDef("@AV30FDesde",GXType.Date,8,0) ,
          new ParDef("@AV31FHasta",GXType.Date,8,0) ,
          new ParDef("@AV37PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV38BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV49LetPSec",GXType.Int32,6,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AA2", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV14MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AA2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AA3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AA3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AA4", "SELECT [BanCod], [BanDsc] FROM [TSBANCOS] WHERE [BanCod] = @AV50LetCBanCod ORDER BY [BanCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AA4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AA5", "SELECT [CPPrvCod], [CPComCod], [CPTipCod], [CPEstado], [CPImpPago], [CPImpTotal] FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @AV51LetCTipCod and [CPComCod] = @AV52LetCDocNum and [CPPrvCod] = @AV55LetPPrvCod ORDER BY [CPTipCod], [CPComCod], [CPPrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AA5,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getString(8, 3);
                ((string[]) buf[8])[0] = rslt.getString(9, 15);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 20);
                ((string[]) buf[13])[0] = rslt.getString(14, 100);
                ((bool[]) buf[14])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(15);
                ((int[]) buf[16])[0] = rslt.getInt(16);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                return;
       }
    }

 }

}
