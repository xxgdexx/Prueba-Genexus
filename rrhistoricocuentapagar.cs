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
   public class rrhistoricocuentapagar : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrhistoricocuentapagar.aspx")), "rrhistoricocuentapagar.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrhistoricocuentapagar.aspx")))) ;
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
               AV47PrvCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13TipCod = GetPar( "TipCod");
                  AV14MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV45FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV36FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV48ComSts = GetPar( "ComSts");
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

      public rrhistoricocuentapagar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrhistoricocuentapagar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_PrvCod ,
                           ref string aP1_TipCod ,
                           ref int aP2_MonCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref string aP5_ComSts )
      {
         this.AV47PrvCod = aP0_PrvCod;
         this.AV13TipCod = aP1_TipCod;
         this.AV14MonCod = aP2_MonCod;
         this.AV45FDesde = aP3_FDesde;
         this.AV36FHasta = aP4_FHasta;
         this.AV48ComSts = aP5_ComSts;
         initialize();
         executePrivate();
         aP0_PrvCod=this.AV47PrvCod;
         aP1_TipCod=this.AV13TipCod;
         aP2_MonCod=this.AV14MonCod;
         aP3_FDesde=this.AV45FDesde;
         aP4_FHasta=this.AV36FHasta;
         aP5_ComSts=this.AV48ComSts;
      }

      public string executeUdp( ref string aP0_PrvCod ,
                                ref string aP1_TipCod ,
                                ref int aP2_MonCod ,
                                ref DateTime aP3_FDesde ,
                                ref DateTime aP4_FHasta )
      {
         execute(ref aP0_PrvCod, ref aP1_TipCod, ref aP2_MonCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_ComSts);
         return AV48ComSts ;
      }

      public void executeSubmit( ref string aP0_PrvCod ,
                                 ref string aP1_TipCod ,
                                 ref int aP2_MonCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref string aP5_ComSts )
      {
         rrhistoricocuentapagar objrrhistoricocuentapagar;
         objrrhistoricocuentapagar = new rrhistoricocuentapagar();
         objrrhistoricocuentapagar.AV47PrvCod = aP0_PrvCod;
         objrrhistoricocuentapagar.AV13TipCod = aP1_TipCod;
         objrrhistoricocuentapagar.AV14MonCod = aP2_MonCod;
         objrrhistoricocuentapagar.AV45FDesde = aP3_FDesde;
         objrrhistoricocuentapagar.AV36FHasta = aP4_FHasta;
         objrrhistoricocuentapagar.AV48ComSts = aP5_ComSts;
         objrrhistoricocuentapagar.context.SetSubmitInitialConfig(context);
         objrrhistoricocuentapagar.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrhistoricocuentapagar);
         aP0_PrvCod=this.AV47PrvCod;
         aP1_TipCod=this.AV13TipCod;
         aP2_MonCod=this.AV14MonCod;
         aP3_FDesde=this.AV45FDesde;
         aP4_FHasta=this.AV36FHasta;
         aP5_ComSts=this.AV48ComSts;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrhistoricocuentapagar)stateInfo).executePrivate();
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
            AV32EmpDir = AV35Session.Get("EmpDir");
            AV42EmpRUC = AV35Session.Get("EmpRUC");
            AV43Ruta = AV35Session.Get("RUTA") + "/Logo.jpg";
            AV44Logo = AV43Ruta;
            AV53Logo_GXI = GXDbFile.PathToUrl( AV43Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV24Filtro3 = "Todos";
            AV25Filtro4 = "Todos";
            AV26Filtro5 = "Todos";
            /* Using cursor P009R2 */
            pr_default.execute(0, new Object[] {AV13TipCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A149TipCod = P009R2_A149TipCod[0];
               A1910TipDsc = P009R2_A1910TipDsc[0];
               AV22Filtro1 = A1910TipDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P009R3 */
            pr_default.execute(1, new Object[] {AV8TipCCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A298TprvCod = P009R3_A298TprvCod[0];
               A1941TprvDsc = P009R3_A1941TprvDsc[0];
               AV23Filtro2 = A1941TprvDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P009R4 */
            pr_default.execute(2, new Object[] {AV14MonCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A180MonCod = P009R4_A180MonCod[0];
               A1234MonDsc = P009R4_A1234MonDsc[0];
               AV24Filtro3 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P009R5 */
            pr_default.execute(3, new Object[] {AV9EstCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A140EstCod = P009R5_A140EstCod[0];
               A602EstDsc = P009R5_A602EstDsc[0];
               A139PaiCod = P009R5_A139PaiCod[0];
               AV25Filtro4 = A602EstDsc;
               pr_default.readNext(3);
            }
            pr_default.close(3);
            /* Using cursor P009R6 */
            pr_default.execute(4, new Object[] {AV47PrvCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A244PrvCod = P009R6_A244PrvCod[0];
               A247PrvDsc = P009R6_A247PrvDsc[0];
               AV26Filtro5 = A247PrvDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            AV19TotGImporte = 0.00m;
            AV20TotGPagos = 0.00m;
            AV21TotGSaldo = 0.00m;
            /* Execute user subroutine: 'HISTORICOCUENTAPAGAR' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            H9R0( false, 28) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19TotGImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 468, Gx_line+9, 565, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20TotGPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 569, Gx_line+9, 674, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV21TotGSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+9, 778, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(465, Gx_line+4, 787, Gx_line+4, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 360, Gx_line+10, 440, Gx_line+24, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+28);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9R0( true, 0) ;
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
         /* 'HISTORICOCUENTAPAGAR' Routine */
         returnInSub = false;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV47PrvCod ,
                                              AV14MonCod ,
                                              AV13TipCod ,
                                              AV48ComSts ,
                                              A262CPPrvCod ,
                                              A263CPMonCod ,
                                              A260CPTipCod ,
                                              A815CPEstado ,
                                              A264CPFech ,
                                              AV45FDesde ,
                                              AV36FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P009R7 */
         pr_default.execute(5, new Object[] {AV45FDesde, AV36FHasta, AV47PrvCod, AV14MonCod, AV13TipCod, AV48ComSts});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A815CPEstado = P009R7_A815CPEstado[0];
            A264CPFech = P009R7_A264CPFech[0];
            A260CPTipCod = P009R7_A260CPTipCod[0];
            A263CPMonCod = P009R7_A263CPMonCod[0];
            A262CPPrvCod = P009R7_A262CPPrvCod[0];
            A261CPComCod = P009R7_A261CPComCod[0];
            A820CPImpTotal = P009R7_A820CPImpTotal[0];
            A818CPImpPago = P009R7_A818CPImpPago[0];
            A511TipSigno = P009R7_A511TipSigno[0];
            n511TipSigno = P009R7_n511TipSigno[0];
            A817CPFVcto = P009R7_A817CPFVcto[0];
            A856CPTipAbr = P009R7_A856CPTipAbr[0];
            A511TipSigno = P009R7_A511TipSigno[0];
            n511TipSigno = P009R7_n511TipSigno[0];
            A856CPTipAbr = P009R7_A856CPTipAbr[0];
            AV47PrvCod = A262CPPrvCod;
            AV16TotImporte = 0.00m;
            AV17TotPagos = 0.00m;
            AV18TotSaldo = 0.00m;
            AV37CCTipCod = A260CPTipCod;
            AV38CCDocNum = A261CPComCod;
            AV46CCEstado = A815CPEstado;
            AV29Importe = ((StringUtil.StrCmp(AV46CCEstado, "A")==0) ? (decimal)(0) : A820CPImpTotal);
            AV30Pagos = ((StringUtil.StrCmp(AV46CCEstado, "A")==0) ? (decimal)(0) : A818CPImpPago);
            AV39CCmonCod = A263CPMonCod;
            AV15Saldo = (decimal)((AV29Importe-AV30Pagos)*A511TipSigno);
            AV31Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A817CPFVcto));
            H9R0( false, 17) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A856CPTipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A261CPComCod, "")), 75, Gx_line+2, 154, Gx_line+17, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( A264CPFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A817CPFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 394, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV30Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV15Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31Dias), "ZZZZ9")), 308, Gx_line+2, 365, Gx_line+17, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+17);
            AV19TotGImporte = (decimal)(AV19TotGImporte+AV29Importe);
            AV20TotGPagos = (decimal)(AV20TotGPagos+AV30Pagos);
            AV21TotGSaldo = (decimal)(AV21TotGSaldo+AV15Saldo);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void H9R0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 675, Gx_line+29, 707, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 675, Gx_line+46, 719, Gx_line+60, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 675, Gx_line+13, 714, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 731, Gx_line+46, 770, Gx_line+61, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 700, Gx_line+29, 769, Gx_line+43, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 723, Gx_line+13, 770, Gx_line+28, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 14, Gx_line+246, 37, Gx_line+260, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Documento", 71, Gx_line+247, 156, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dias Vcto", 324, Gx_line+247, 379, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 395, Gx_line+247, 443, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe Total", 473, Gx_line+247, 556, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+240, 797, Gx_line+266, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Historico de Cuentas por Pagar", 278, Gx_line+70, 543, Gx_line+90, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 174, Gx_line+247, 209, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Vcto", 236, Gx_line+247, 301, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 719, Gx_line+247, 752, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pago", 616, Gx_line+247, 646, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Documento", 119, Gx_line+108, 234, Gx_line+122, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Proveedor", 119, Gx_line+130, 227, Gx_line+144, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 119, Gx_line+152, 167, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Estado", 119, Gx_line+174, 160, Gx_line+188, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 119, Gx_line+195, 181, Gx_line+209, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 253, Gx_line+103, 596, Gx_line+127, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro2, "")), 253, Gx_line+125, 596, Gx_line+149, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro3, "")), 253, Gx_line+147, 596, Gx_line+171, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Filtro4, "")), 253, Gx_line+169, 596, Gx_line+193, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Filtro5, "")), 253, Gx_line+190, 596, Gx_line+214, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32EmpDir, "")), 19, Gx_line+29, 404, Gx_line+47, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42EmpRUC, "")), 19, Gx_line+46, 404, Gx_line+64, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Empresa, "")), 19, Gx_line+11, 404, Gx_line+29, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+266);
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
         AV32EmpDir = "";
         AV42EmpRUC = "";
         AV43Ruta = "";
         AV44Logo = "";
         AV53Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         AV25Filtro4 = "";
         AV26Filtro5 = "";
         scmdbuf = "";
         P009R2_A149TipCod = new string[] {""} ;
         P009R2_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         P009R3_A298TprvCod = new int[1] ;
         P009R3_A1941TprvDsc = new string[] {""} ;
         A1941TprvDsc = "";
         P009R4_A180MonCod = new int[1] ;
         P009R4_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV9EstCod = "";
         P009R5_A140EstCod = new string[] {""} ;
         P009R5_A602EstDsc = new string[] {""} ;
         P009R5_A139PaiCod = new string[] {""} ;
         A140EstCod = "";
         A602EstDsc = "";
         A139PaiCod = "";
         P009R6_A244PrvCod = new string[] {""} ;
         P009R6_A247PrvDsc = new string[] {""} ;
         A244PrvCod = "";
         A247PrvDsc = "";
         A262CPPrvCod = "";
         A260CPTipCod = "";
         A815CPEstado = "";
         A264CPFech = DateTime.MinValue;
         P009R7_A815CPEstado = new string[] {""} ;
         P009R7_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009R7_A260CPTipCod = new string[] {""} ;
         P009R7_A263CPMonCod = new int[1] ;
         P009R7_A262CPPrvCod = new string[] {""} ;
         P009R7_A261CPComCod = new string[] {""} ;
         P009R7_A820CPImpTotal = new decimal[1] ;
         P009R7_A818CPImpPago = new decimal[1] ;
         P009R7_A511TipSigno = new short[1] ;
         P009R7_n511TipSigno = new bool[] {false} ;
         P009R7_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         P009R7_A856CPTipAbr = new string[] {""} ;
         A261CPComCod = "";
         A817CPFVcto = DateTime.MinValue;
         A856CPTipAbr = "";
         AV37CCTipCod = "";
         AV38CCDocNum = "";
         AV46CCEstado = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrhistoricocuentapagar__default(),
            new Object[][] {
                new Object[] {
               P009R2_A149TipCod, P009R2_A1910TipDsc
               }
               , new Object[] {
               P009R3_A298TprvCod, P009R3_A1941TprvDsc
               }
               , new Object[] {
               P009R4_A180MonCod, P009R4_A1234MonDsc
               }
               , new Object[] {
               P009R5_A140EstCod, P009R5_A602EstDsc, P009R5_A139PaiCod
               }
               , new Object[] {
               P009R6_A244PrvCod, P009R6_A247PrvDsc
               }
               , new Object[] {
               P009R7_A815CPEstado, P009R7_A264CPFech, P009R7_A260CPTipCod, P009R7_A263CPMonCod, P009R7_A262CPPrvCod, P009R7_A261CPComCod, P009R7_A820CPImpTotal, P009R7_A818CPImpPago, P009R7_A511TipSigno, P009R7_n511TipSigno,
               P009R7_A817CPFVcto, P009R7_A856CPTipAbr
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
      private short A511TipSigno ;
      private int AV14MonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV8TipCCod ;
      private int A298TprvCod ;
      private int A180MonCod ;
      private int Gx_OldLine ;
      private int A263CPMonCod ;
      private int AV39CCmonCod ;
      private int AV31Dias ;
      private decimal AV19TotGImporte ;
      private decimal AV20TotGPagos ;
      private decimal AV21TotGSaldo ;
      private decimal A820CPImpTotal ;
      private decimal A818CPImpPago ;
      private decimal AV16TotImporte ;
      private decimal AV17TotPagos ;
      private decimal AV18TotSaldo ;
      private decimal AV29Importe ;
      private decimal AV30Pagos ;
      private decimal AV15Saldo ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV47PrvCod ;
      private string AV13TipCod ;
      private string AV48ComSts ;
      private string AV34Empresa ;
      private string AV32EmpDir ;
      private string AV42EmpRUC ;
      private string AV43Ruta ;
      private string AV22Filtro1 ;
      private string AV23Filtro2 ;
      private string AV24Filtro3 ;
      private string AV25Filtro4 ;
      private string AV26Filtro5 ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private string A1941TprvDsc ;
      private string A1234MonDsc ;
      private string AV9EstCod ;
      private string A140EstCod ;
      private string A602EstDsc ;
      private string A139PaiCod ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A262CPPrvCod ;
      private string A260CPTipCod ;
      private string A815CPEstado ;
      private string A261CPComCod ;
      private string A856CPTipAbr ;
      private string AV37CCTipCod ;
      private string AV38CCDocNum ;
      private string AV46CCEstado ;
      private string Gx_time ;
      private DateTime AV45FDesde ;
      private DateTime AV36FHasta ;
      private DateTime A264CPFech ;
      private DateTime A817CPFVcto ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool n511TipSigno ;
      private string AV53Logo_GXI ;
      private string AV44Logo ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_PrvCod ;
      private string aP1_TipCod ;
      private int aP2_MonCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private string aP5_ComSts ;
      private IDataStoreProvider pr_default ;
      private string[] P009R2_A149TipCod ;
      private string[] P009R2_A1910TipDsc ;
      private int[] P009R3_A298TprvCod ;
      private string[] P009R3_A1941TprvDsc ;
      private int[] P009R4_A180MonCod ;
      private string[] P009R4_A1234MonDsc ;
      private string[] P009R5_A140EstCod ;
      private string[] P009R5_A602EstDsc ;
      private string[] P009R5_A139PaiCod ;
      private string[] P009R6_A244PrvCod ;
      private string[] P009R6_A247PrvDsc ;
      private string[] P009R7_A815CPEstado ;
      private DateTime[] P009R7_A264CPFech ;
      private string[] P009R7_A260CPTipCod ;
      private int[] P009R7_A263CPMonCod ;
      private string[] P009R7_A262CPPrvCod ;
      private string[] P009R7_A261CPComCod ;
      private decimal[] P009R7_A820CPImpTotal ;
      private decimal[] P009R7_A818CPImpPago ;
      private short[] P009R7_A511TipSigno ;
      private bool[] P009R7_n511TipSigno ;
      private DateTime[] P009R7_A817CPFVcto ;
      private string[] P009R7_A856CPTipAbr ;
   }

   public class rrhistoricocuentapagar__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009R7( IGxContext context ,
                                             string AV47PrvCod ,
                                             int AV14MonCod ,
                                             string AV13TipCod ,
                                             string AV48ComSts ,
                                             string A262CPPrvCod ,
                                             int A263CPMonCod ,
                                             string A260CPTipCod ,
                                             string A815CPEstado ,
                                             DateTime A264CPFech ,
                                             DateTime AV45FDesde ,
                                             DateTime AV36FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CPEstado], T1.[CPFech], T1.[CPTipCod] AS CPTipCod, T1.[CPMonCod], T1.[CPPrvCod], T1.[CPComCod], T1.[CPImpTotal], T1.[CPImpPago], T2.[TipSigno], T1.[CPFVcto], T2.[TipAbr] AS CPTipAbr FROM ([CPCUENTAPAGAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CPTipCod])";
         AddWhere(sWhereString, "(T1.[CPFech] >= @AV45FDesde and T1.[CPFech] <= @AV36FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV47PrvCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPTipCod] = @AV13TipCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV48ComSts, "TD") != 0 )
         {
            AddWhere(sWhereString, "(T1.[CPEstado] = @AV48ComSts)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CPTipCod], T1.[CPComCod], T1.[CPPrvCod]";
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
               case 5 :
                     return conditional_P009R7(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] );
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
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009R2;
          prmP009R2 = new Object[] {
          new ParDef("@AV13TipCod",GXType.NChar,3,0)
          };
          Object[] prmP009R3;
          prmP009R3 = new Object[] {
          new ParDef("@AV8TipCCod",GXType.Int32,6,0)
          };
          Object[] prmP009R4;
          prmP009R4 = new Object[] {
          new ParDef("@AV14MonCod",GXType.Int32,6,0)
          };
          Object[] prmP009R5;
          prmP009R5 = new Object[] {
          new ParDef("@AV9EstCod",GXType.NChar,4,0)
          };
          Object[] prmP009R6;
          prmP009R6 = new Object[] {
          new ParDef("@AV47PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP009R7;
          prmP009R7 = new Object[] {
          new ParDef("@AV45FDesde",GXType.Date,8,0) ,
          new ParDef("@AV36FHasta",GXType.Date,8,0) ,
          new ParDef("@AV47PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV13TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV48ComSts",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009R2", "SELECT [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipCod] = @AV13TipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009R2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009R3", "SELECT [TprvCod], [TprvDsc] FROM [CTIPOPROVEEDOR] WHERE [TprvCod] = @AV8TipCCod ORDER BY [TprvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009R3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009R4", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV14MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009R4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009R5", "SELECT [EstCod], [EstDsc], [PaiCod] FROM [CESTADOS] WHERE [EstCod] = @AV9EstCod ORDER BY [PaiCod], [EstCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009R5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009R6", "SELECT [PrvCod], [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @AV47PrvCod ORDER BY [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009R6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009R7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009R7,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
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
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 5);
                return;
       }
    }

 }

}
