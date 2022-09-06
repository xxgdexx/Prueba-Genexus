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
   public class r_cuentasxpagarvctopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_cuentasxpagarvctopdf.aspx")), "compras.r_cuentasxpagarvctopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_cuentasxpagarvctopdf.aspx")))) ;
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
                  AV9EstCod = GetPar( "EstCod");
                  AV30PrvCod = GetPar( "PrvCod");
                  AV13TipCod = GetPar( "TipCod");
                  AV14MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV32Hdesde = context.localUtil.ParseDateParm( GetPar( "Hdesde"));
                  AV33HHasta = context.localUtil.ParseDateParm( GetPar( "HHasta"));
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

      public r_cuentasxpagarvctopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_cuentasxpagarvctopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TprvCod ,
                           ref string aP1_EstCod ,
                           ref string aP2_PrvCod ,
                           ref string aP3_TipCod ,
                           ref int aP4_MonCod ,
                           ref DateTime aP5_Hdesde ,
                           ref DateTime aP6_HHasta )
      {
         this.AV31TprvCod = aP0_TprvCod;
         this.AV9EstCod = aP1_EstCod;
         this.AV30PrvCod = aP2_PrvCod;
         this.AV13TipCod = aP3_TipCod;
         this.AV14MonCod = aP4_MonCod;
         this.AV32Hdesde = aP5_Hdesde;
         this.AV33HHasta = aP6_HHasta;
         initialize();
         executePrivate();
         aP0_TprvCod=this.AV31TprvCod;
         aP1_EstCod=this.AV9EstCod;
         aP2_PrvCod=this.AV30PrvCod;
         aP3_TipCod=this.AV13TipCod;
         aP4_MonCod=this.AV14MonCod;
         aP5_Hdesde=this.AV32Hdesde;
         aP6_HHasta=this.AV33HHasta;
      }

      public DateTime executeUdp( ref int aP0_TprvCod ,
                                  ref string aP1_EstCod ,
                                  ref string aP2_PrvCod ,
                                  ref string aP3_TipCod ,
                                  ref int aP4_MonCod ,
                                  ref DateTime aP5_Hdesde )
      {
         execute(ref aP0_TprvCod, ref aP1_EstCod, ref aP2_PrvCod, ref aP3_TipCod, ref aP4_MonCod, ref aP5_Hdesde, ref aP6_HHasta);
         return AV33HHasta ;
      }

      public void executeSubmit( ref int aP0_TprvCod ,
                                 ref string aP1_EstCod ,
                                 ref string aP2_PrvCod ,
                                 ref string aP3_TipCod ,
                                 ref int aP4_MonCod ,
                                 ref DateTime aP5_Hdesde ,
                                 ref DateTime aP6_HHasta )
      {
         r_cuentasxpagarvctopdf objr_cuentasxpagarvctopdf;
         objr_cuentasxpagarvctopdf = new r_cuentasxpagarvctopdf();
         objr_cuentasxpagarvctopdf.AV31TprvCod = aP0_TprvCod;
         objr_cuentasxpagarvctopdf.AV9EstCod = aP1_EstCod;
         objr_cuentasxpagarvctopdf.AV30PrvCod = aP2_PrvCod;
         objr_cuentasxpagarvctopdf.AV13TipCod = aP3_TipCod;
         objr_cuentasxpagarvctopdf.AV14MonCod = aP4_MonCod;
         objr_cuentasxpagarvctopdf.AV32Hdesde = aP5_Hdesde;
         objr_cuentasxpagarvctopdf.AV33HHasta = aP6_HHasta;
         objr_cuentasxpagarvctopdf.context.SetSubmitInitialConfig(context);
         objr_cuentasxpagarvctopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_cuentasxpagarvctopdf);
         aP0_TprvCod=this.AV31TprvCod;
         aP1_EstCod=this.AV9EstCod;
         aP2_PrvCod=this.AV30PrvCod;
         aP3_TipCod=this.AV13TipCod;
         aP4_MonCod=this.AV14MonCod;
         aP5_Hdesde=this.AV32Hdesde;
         aP6_HHasta=this.AV33HHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_cuentasxpagarvctopdf)stateInfo).executePrivate();
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
            AV37Empresa = AV34Session.Get("Empresa");
            AV36EmpDir = AV34Session.Get("EmpDir");
            AV38EmpRUC = AV34Session.Get("EmpRUC");
            AV39Ruta = AV34Session.Get("RUTA") + "/Logo.jpg";
            AV40Logo = AV39Ruta;
            AV45Logo_GXI = GXDbFile.PathToUrl( AV39Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV24Filtro3 = "Todos";
            AV25Filtro4 = "Todos";
            AV26Filtro5 = "Todos";
            /* Using cursor P009Q2 */
            pr_default.execute(0, new Object[] {AV13TipCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A149TipCod = P009Q2_A149TipCod[0];
               A1910TipDsc = P009Q2_A1910TipDsc[0];
               AV22Filtro1 = A1910TipDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P009Q3 */
            pr_default.execute(1, new Object[] {AV31TprvCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A298TprvCod = P009Q3_A298TprvCod[0];
               n298TprvCod = P009Q3_n298TprvCod[0];
               A1941TprvDsc = P009Q3_A1941TprvDsc[0];
               AV23Filtro2 = A1941TprvDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P009Q4 */
            pr_default.execute(2, new Object[] {AV14MonCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A180MonCod = P009Q4_A180MonCod[0];
               A1234MonDsc = P009Q4_A1234MonDsc[0];
               AV24Filtro3 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P009Q5 */
            pr_default.execute(3, new Object[] {AV9EstCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A140EstCod = P009Q5_A140EstCod[0];
               n140EstCod = P009Q5_n140EstCod[0];
               A602EstDsc = P009Q5_A602EstDsc[0];
               A139PaiCod = P009Q5_A139PaiCod[0];
               AV25Filtro4 = A602EstDsc;
               pr_default.readNext(3);
            }
            pr_default.close(3);
            /* Using cursor P009Q6 */
            pr_default.execute(4, new Object[] {AV30PrvCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A244PrvCod = P009Q6_A244PrvCod[0];
               A247PrvDsc = P009Q6_A247PrvDsc[0];
               AV26Filtro5 = A247PrvDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            AV19TotGImporte = 0.00m;
            AV20TotGPagos = 0.00m;
            AV21TotGSaldo = 0.00m;
            pr_default.dynParam(5, new Object[]{ new Object[]{
                                                 AV30PrvCod ,
                                                 AV9EstCod ,
                                                 AV31TprvCod ,
                                                 AV14MonCod ,
                                                 AV13TipCod ,
                                                 A262CPPrvCod ,
                                                 A140EstCod ,
                                                 A298TprvCod ,
                                                 A263CPMonCod ,
                                                 A260CPTipCod ,
                                                 A817CPFVcto ,
                                                 AV32Hdesde ,
                                                 AV33HHasta ,
                                                 A815CPEstado } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P009Q7 */
            pr_default.execute(5, new Object[] {AV32Hdesde, AV33HHasta, AV30PrvCod, AV9EstCod, AV31TprvCod, AV14MonCod, AV13TipCod});
            while ( (pr_default.getStatus(5) != 101) )
            {
               BRK9Q8 = false;
               A262CPPrvCod = P009Q7_A262CPPrvCod[0];
               A511TipSigno = P009Q7_A511TipSigno[0];
               n511TipSigno = P009Q7_n511TipSigno[0];
               A820CPImpTotal = P009Q7_A820CPImpTotal[0];
               A818CPImpPago = P009Q7_A818CPImpPago[0];
               A817CPFVcto = P009Q7_A817CPFVcto[0];
               A830CPMonDsc = P009Q7_A830CPMonDsc[0];
               A264CPFech = P009Q7_A264CPFech[0];
               A856CPTipAbr = P009Q7_A856CPTipAbr[0];
               A261CPComCod = P009Q7_A261CPComCod[0];
               A260CPTipCod = P009Q7_A260CPTipCod[0];
               A815CPEstado = P009Q7_A815CPEstado[0];
               A263CPMonCod = P009Q7_A263CPMonCod[0];
               A298TprvCod = P009Q7_A298TprvCod[0];
               n298TprvCod = P009Q7_n298TprvCod[0];
               A140EstCod = P009Q7_A140EstCod[0];
               n140EstCod = P009Q7_n140EstCod[0];
               A831CPPrvDsc = P009Q7_A831CPPrvDsc[0];
               A298TprvCod = P009Q7_A298TprvCod[0];
               n298TprvCod = P009Q7_n298TprvCod[0];
               A140EstCod = P009Q7_A140EstCod[0];
               n140EstCod = P009Q7_n140EstCod[0];
               A831CPPrvDsc = P009Q7_A831CPPrvDsc[0];
               A511TipSigno = P009Q7_A511TipSigno[0];
               n511TipSigno = P009Q7_n511TipSigno[0];
               A856CPTipAbr = P009Q7_A856CPTipAbr[0];
               A830CPMonDsc = P009Q7_A830CPMonDsc[0];
               H9Q0( false, 21) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A831CPPrvDsc, "")), 8, Gx_line+4, 612, Gx_line+19, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
               AV16TotImporte = 0.00m;
               AV17TotPagos = 0.00m;
               AV18TotSaldo = 0.00m;
               while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P009Q7_A262CPPrvCod[0], A262CPPrvCod) == 0 ) )
               {
                  BRK9Q8 = false;
                  A511TipSigno = P009Q7_A511TipSigno[0];
                  n511TipSigno = P009Q7_n511TipSigno[0];
                  A820CPImpTotal = P009Q7_A820CPImpTotal[0];
                  A818CPImpPago = P009Q7_A818CPImpPago[0];
                  A817CPFVcto = P009Q7_A817CPFVcto[0];
                  A830CPMonDsc = P009Q7_A830CPMonDsc[0];
                  A264CPFech = P009Q7_A264CPFech[0];
                  A856CPTipAbr = P009Q7_A856CPTipAbr[0];
                  A261CPComCod = P009Q7_A261CPComCod[0];
                  A260CPTipCod = P009Q7_A260CPTipCod[0];
                  A263CPMonCod = P009Q7_A263CPMonCod[0];
                  A511TipSigno = P009Q7_A511TipSigno[0];
                  n511TipSigno = P009Q7_n511TipSigno[0];
                  A856CPTipAbr = P009Q7_A856CPTipAbr[0];
                  A830CPMonDsc = P009Q7_A830CPMonDsc[0];
                  AV28Importe = (decimal)(A820CPImpTotal*A511TipSigno);
                  AV29Pagos = (decimal)(A818CPImpPago*A511TipSigno);
                  AV15Saldo = (decimal)((A820CPImpTotal-A818CPImpPago)*A511TipSigno);
                  AV16TotImporte = (decimal)(AV16TotImporte+AV28Importe);
                  AV17TotPagos = (decimal)(AV17TotPagos+AV29Pagos);
                  AV18TotSaldo = (decimal)(AV18TotSaldo+AV15Saldo);
                  AV27Dias = (int)(DateTimeUtil.DDiff(A817CPFVcto,DateTimeUtil.Today( context)));
                  H9Q0( false, 17) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A856CPTipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A261CPComCod, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A264CPFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A817CPFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A830CPMonDsc, "")), 394, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV15Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV27Dias), "ZZZZ9")), 313, Gx_line+1, 370, Gx_line+16, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
                  BRK9Q8 = true;
                  pr_default.readNext(5);
               }
               H9Q0( false, 24) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(466, Gx_line+1, 788, Gx_line+1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Proveedor", 331, Gx_line+5, 427, Gx_line+19, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
               AV19TotGImporte = (decimal)(AV19TotGImporte+AV16TotImporte);
               AV20TotGPagos = (decimal)(AV20TotGPagos+AV17TotPagos);
               AV21TotGSaldo = (decimal)(AV21TotGSaldo+AV18TotSaldo);
               if ( ! BRK9Q8 )
               {
                  BRK9Q8 = true;
                  pr_default.readNext(5);
               }
            }
            pr_default.close(5);
            H9Q0( false, 28) ;
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
            H9Q0( true, 0) ;
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

      protected void H9Q0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 664, Gx_line+32, 696, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 664, Gx_line+50, 708, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 664, Gx_line+15, 703, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 733, Gx_line+50, 772, Gx_line+65, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 710, Gx_line+32, 770, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 725, Gx_line+15, 772, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 14, Gx_line+221, 37, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Documento", 71, Gx_line+221, 156, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dias Vcto", 324, Gx_line+221, 379, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 395, Gx_line+221, 443, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe Total", 473, Gx_line+221, 556, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+214, 797, Gx_line+240, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuentas por Pagar Vencimiento", 255, Gx_line+70, 524, Gx_line+90, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 174, Gx_line+221, 209, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Vcto", 236, Gx_line+221, 301, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 719, Gx_line+221, 752, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pago", 616, Gx_line+221, 646, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Documento", 177, Gx_line+123, 292, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Proveedor", 177, Gx_line+145, 285, Gx_line+159, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 177, Gx_line+167, 225, Gx_line+181, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 177, Gx_line+190, 239, Gx_line+204, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 314, Gx_line+118, 657, Gx_line+142, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro2, "")), 314, Gx_line+140, 657, Gx_line+164, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro3, "")), 314, Gx_line+161, 657, Gx_line+185, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Filtro5, "")), 314, Gx_line+184, 657, Gx_line+208, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38EmpRUC, "")), 11, Gx_line+51, 396, Gx_line+69, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36EmpDir, "")), 11, Gx_line+34, 396, Gx_line+52, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Empresa, "")), 11, Gx_line+17, 396, Gx_line+35, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Del :", 269, Gx_line+93, 310, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV32Hdesde, "99/99/99"), 308, Gx_line+93, 389, Gx_line+113, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Al :", 395, Gx_line+93, 425, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV33HHasta, "99/99/99"), 434, Gx_line+93, 515, Gx_line+113, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+240);
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
         AV37Empresa = "";
         AV34Session = context.GetSession();
         AV36EmpDir = "";
         AV38EmpRUC = "";
         AV39Ruta = "";
         AV40Logo = "";
         AV45Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         AV25Filtro4 = "";
         AV26Filtro5 = "";
         scmdbuf = "";
         P009Q2_A149TipCod = new string[] {""} ;
         P009Q2_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         P009Q3_A298TprvCod = new int[1] ;
         P009Q3_n298TprvCod = new bool[] {false} ;
         P009Q3_A1941TprvDsc = new string[] {""} ;
         A1941TprvDsc = "";
         P009Q4_A180MonCod = new int[1] ;
         P009Q4_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         P009Q5_A140EstCod = new string[] {""} ;
         P009Q5_n140EstCod = new bool[] {false} ;
         P009Q5_A602EstDsc = new string[] {""} ;
         P009Q5_A139PaiCod = new string[] {""} ;
         A140EstCod = "";
         A602EstDsc = "";
         A139PaiCod = "";
         P009Q6_A244PrvCod = new string[] {""} ;
         P009Q6_A247PrvDsc = new string[] {""} ;
         A244PrvCod = "";
         A247PrvDsc = "";
         A262CPPrvCod = "";
         A260CPTipCod = "";
         A817CPFVcto = DateTime.MinValue;
         A815CPEstado = "";
         P009Q7_A262CPPrvCod = new string[] {""} ;
         P009Q7_A511TipSigno = new short[1] ;
         P009Q7_n511TipSigno = new bool[] {false} ;
         P009Q7_A820CPImpTotal = new decimal[1] ;
         P009Q7_A818CPImpPago = new decimal[1] ;
         P009Q7_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         P009Q7_A830CPMonDsc = new string[] {""} ;
         P009Q7_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009Q7_A856CPTipAbr = new string[] {""} ;
         P009Q7_A261CPComCod = new string[] {""} ;
         P009Q7_A260CPTipCod = new string[] {""} ;
         P009Q7_A815CPEstado = new string[] {""} ;
         P009Q7_A263CPMonCod = new int[1] ;
         P009Q7_A298TprvCod = new int[1] ;
         P009Q7_n298TprvCod = new bool[] {false} ;
         P009Q7_A140EstCod = new string[] {""} ;
         P009Q7_n140EstCod = new bool[] {false} ;
         P009Q7_A831CPPrvDsc = new string[] {""} ;
         A830CPMonDsc = "";
         A264CPFech = DateTime.MinValue;
         A856CPTipAbr = "";
         A261CPComCod = "";
         A831CPPrvDsc = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_cuentasxpagarvctopdf__default(),
            new Object[][] {
                new Object[] {
               P009Q2_A149TipCod, P009Q2_A1910TipDsc
               }
               , new Object[] {
               P009Q3_A298TprvCod, P009Q3_A1941TprvDsc
               }
               , new Object[] {
               P009Q4_A180MonCod, P009Q4_A1234MonDsc
               }
               , new Object[] {
               P009Q5_A140EstCod, P009Q5_A602EstDsc, P009Q5_A139PaiCod
               }
               , new Object[] {
               P009Q6_A244PrvCod, P009Q6_A247PrvDsc
               }
               , new Object[] {
               P009Q7_A262CPPrvCod, P009Q7_A511TipSigno, P009Q7_n511TipSigno, P009Q7_A820CPImpTotal, P009Q7_A818CPImpPago, P009Q7_A817CPFVcto, P009Q7_A830CPMonDsc, P009Q7_A264CPFech, P009Q7_A856CPTipAbr, P009Q7_A261CPComCod,
               P009Q7_A260CPTipCod, P009Q7_A815CPEstado, P009Q7_A263CPMonCod, P009Q7_A298TprvCod, P009Q7_n298TprvCod, P009Q7_A140EstCod, P009Q7_n140EstCod, P009Q7_A831CPPrvDsc
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
      private int AV31TprvCod ;
      private int AV14MonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A298TprvCod ;
      private int A180MonCod ;
      private int A263CPMonCod ;
      private int Gx_OldLine ;
      private int AV27Dias ;
      private decimal AV19TotGImporte ;
      private decimal AV20TotGPagos ;
      private decimal AV21TotGSaldo ;
      private decimal A820CPImpTotal ;
      private decimal A818CPImpPago ;
      private decimal AV16TotImporte ;
      private decimal AV17TotPagos ;
      private decimal AV18TotSaldo ;
      private decimal AV28Importe ;
      private decimal AV29Pagos ;
      private decimal AV15Saldo ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV9EstCod ;
      private string AV30PrvCod ;
      private string AV13TipCod ;
      private string AV37Empresa ;
      private string AV36EmpDir ;
      private string AV38EmpRUC ;
      private string AV39Ruta ;
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
      private string A140EstCod ;
      private string A602EstDsc ;
      private string A139PaiCod ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A262CPPrvCod ;
      private string A260CPTipCod ;
      private string A815CPEstado ;
      private string A830CPMonDsc ;
      private string A856CPTipAbr ;
      private string A261CPComCod ;
      private string A831CPPrvDsc ;
      private string Gx_time ;
      private DateTime AV32Hdesde ;
      private DateTime AV33HHasta ;
      private DateTime A817CPFVcto ;
      private DateTime A264CPFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n298TprvCod ;
      private bool n140EstCod ;
      private bool BRK9Q8 ;
      private bool n511TipSigno ;
      private string AV45Logo_GXI ;
      private string AV40Logo ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TprvCod ;
      private string aP1_EstCod ;
      private string aP2_PrvCod ;
      private string aP3_TipCod ;
      private int aP4_MonCod ;
      private DateTime aP5_Hdesde ;
      private DateTime aP6_HHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P009Q2_A149TipCod ;
      private string[] P009Q2_A1910TipDsc ;
      private int[] P009Q3_A298TprvCod ;
      private bool[] P009Q3_n298TprvCod ;
      private string[] P009Q3_A1941TprvDsc ;
      private int[] P009Q4_A180MonCod ;
      private string[] P009Q4_A1234MonDsc ;
      private string[] P009Q5_A140EstCod ;
      private bool[] P009Q5_n140EstCod ;
      private string[] P009Q5_A602EstDsc ;
      private string[] P009Q5_A139PaiCod ;
      private string[] P009Q6_A244PrvCod ;
      private string[] P009Q6_A247PrvDsc ;
      private string[] P009Q7_A262CPPrvCod ;
      private short[] P009Q7_A511TipSigno ;
      private bool[] P009Q7_n511TipSigno ;
      private decimal[] P009Q7_A820CPImpTotal ;
      private decimal[] P009Q7_A818CPImpPago ;
      private DateTime[] P009Q7_A817CPFVcto ;
      private string[] P009Q7_A830CPMonDsc ;
      private DateTime[] P009Q7_A264CPFech ;
      private string[] P009Q7_A856CPTipAbr ;
      private string[] P009Q7_A261CPComCod ;
      private string[] P009Q7_A260CPTipCod ;
      private string[] P009Q7_A815CPEstado ;
      private int[] P009Q7_A263CPMonCod ;
      private int[] P009Q7_A298TprvCod ;
      private bool[] P009Q7_n298TprvCod ;
      private string[] P009Q7_A140EstCod ;
      private bool[] P009Q7_n140EstCod ;
      private string[] P009Q7_A831CPPrvDsc ;
   }

   public class r_cuentasxpagarvctopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009Q7( IGxContext context ,
                                             string AV30PrvCod ,
                                             string AV9EstCod ,
                                             int AV31TprvCod ,
                                             int AV14MonCod ,
                                             string AV13TipCod ,
                                             string A262CPPrvCod ,
                                             string A140EstCod ,
                                             int A298TprvCod ,
                                             int A263CPMonCod ,
                                             string A260CPTipCod ,
                                             DateTime A817CPFVcto ,
                                             DateTime AV32Hdesde ,
                                             DateTime AV33HHasta ,
                                             string A815CPEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CPPrvCod] AS CPPrvCod, T3.[TipSigno], T1.[CPImpTotal], T1.[CPImpPago], T1.[CPFVcto], T4.[MonDsc] AS CPMonDsc, T1.[CPFech], T3.[TipAbr] AS CPTipAbr, T1.[CPComCod], T1.[CPTipCod] AS CPTipCod, T1.[CPEstado], T1.[CPMonCod] AS CPMonCod, T2.[TprvCod], T2.[EstCod], T2.[PrvDsc] AS CPPrvDsc FROM ((([CPCUENTAPAGAR] T1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = T1.[CPPrvCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CPTipCod]) INNER JOIN [CMONEDAS] T4 ON T4.[MonCod] = T1.[CPMonCod])";
         AddWhere(sWhereString, "(T1.[CPFVcto] >= @AV32Hdesde and T1.[CPFVcto] <= @AV33HHasta)");
         AddWhere(sWhereString, "(T1.[CPEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV30PrvCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9EstCod)) )
         {
            AddWhere(sWhereString, "(T2.[EstCod] = @AV9EstCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV31TprvCod) )
         {
            AddWhere(sWhereString, "(T2.[TprvCod] = @AV31TprvCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPTipCod] = @AV13TipCod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CPPrvCod], T1.[CPTipCod], T1.[CPComCod]";
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
                     return conditional_P009Q7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] );
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
          Object[] prmP009Q2;
          prmP009Q2 = new Object[] {
          new ParDef("@AV13TipCod",GXType.NChar,3,0)
          };
          Object[] prmP009Q3;
          prmP009Q3 = new Object[] {
          new ParDef("@AV31TprvCod",GXType.Int32,6,0)
          };
          Object[] prmP009Q4;
          prmP009Q4 = new Object[] {
          new ParDef("@AV14MonCod",GXType.Int32,6,0)
          };
          Object[] prmP009Q5;
          prmP009Q5 = new Object[] {
          new ParDef("@AV9EstCod",GXType.NChar,4,0)
          };
          Object[] prmP009Q6;
          prmP009Q6 = new Object[] {
          new ParDef("@AV30PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP009Q7;
          prmP009Q7 = new Object[] {
          new ParDef("@AV32Hdesde",GXType.Date,8,0) ,
          new ParDef("@AV33HHasta",GXType.Date,8,0) ,
          new ParDef("@AV30PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV9EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV31TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV13TipCod",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009Q2", "SELECT [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipCod] = @AV13TipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Q3", "SELECT [TprvCod], [TprvDsc] FROM [CTIPOPROVEEDOR] WHERE [TprvCod] = @AV31TprvCod ORDER BY [TprvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Q4", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV14MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Q5", "SELECT [EstCod], [EstDsc], [PaiCod] FROM [CESTADOS] WHERE [EstCod] = @AV9EstCod ORDER BY [PaiCod], [EstCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009Q6", "SELECT [PrvCod], [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @AV30PrvCod ORDER BY [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Q7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q7,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 5);
                ((string[]) buf[9])[0] = rslt.getString(9, 15);
                ((string[]) buf[10])[0] = rslt.getString(10, 3);
                ((string[]) buf[11])[0] = rslt.getString(11, 1);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((int[]) buf[13])[0] = rslt.getInt(13);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                ((string[]) buf[15])[0] = rslt.getString(14, 4);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                ((string[]) buf[17])[0] = rslt.getString(15, 100);
                return;
       }
    }

 }

}
