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
   public class rrhistoricocuentacobrar : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrhistoricocuentacobrar.aspx")), "rrhistoricocuentacobrar.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrhistoricocuentacobrar.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "CliCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV10CliCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13TipCod = GetPar( "TipCod");
                  AV14MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV45FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV36FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV47PedSts = GetPar( "PedSts");
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

      public rrhistoricocuentacobrar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrhistoricocuentacobrar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CliCod ,
                           ref string aP1_TipCod ,
                           ref int aP2_MonCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref string aP5_PedSts )
      {
         this.AV10CliCod = aP0_CliCod;
         this.AV13TipCod = aP1_TipCod;
         this.AV14MonCod = aP2_MonCod;
         this.AV45FDesde = aP3_FDesde;
         this.AV36FHasta = aP4_FHasta;
         this.AV47PedSts = aP5_PedSts;
         initialize();
         executePrivate();
         aP0_CliCod=this.AV10CliCod;
         aP1_TipCod=this.AV13TipCod;
         aP2_MonCod=this.AV14MonCod;
         aP3_FDesde=this.AV45FDesde;
         aP4_FHasta=this.AV36FHasta;
         aP5_PedSts=this.AV47PedSts;
      }

      public string executeUdp( ref string aP0_CliCod ,
                                ref string aP1_TipCod ,
                                ref int aP2_MonCod ,
                                ref DateTime aP3_FDesde ,
                                ref DateTime aP4_FHasta )
      {
         execute(ref aP0_CliCod, ref aP1_TipCod, ref aP2_MonCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_PedSts);
         return AV47PedSts ;
      }

      public void executeSubmit( ref string aP0_CliCod ,
                                 ref string aP1_TipCod ,
                                 ref int aP2_MonCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref string aP5_PedSts )
      {
         rrhistoricocuentacobrar objrrhistoricocuentacobrar;
         objrrhistoricocuentacobrar = new rrhistoricocuentacobrar();
         objrrhistoricocuentacobrar.AV10CliCod = aP0_CliCod;
         objrrhistoricocuentacobrar.AV13TipCod = aP1_TipCod;
         objrrhistoricocuentacobrar.AV14MonCod = aP2_MonCod;
         objrrhistoricocuentacobrar.AV45FDesde = aP3_FDesde;
         objrrhistoricocuentacobrar.AV36FHasta = aP4_FHasta;
         objrrhistoricocuentacobrar.AV47PedSts = aP5_PedSts;
         objrrhistoricocuentacobrar.context.SetSubmitInitialConfig(context);
         objrrhistoricocuentacobrar.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrhistoricocuentacobrar);
         aP0_CliCod=this.AV10CliCod;
         aP1_TipCod=this.AV13TipCod;
         aP2_MonCod=this.AV14MonCod;
         aP3_FDesde=this.AV45FDesde;
         aP4_FHasta=this.AV36FHasta;
         aP5_PedSts=this.AV47PedSts;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrhistoricocuentacobrar)stateInfo).executePrivate();
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
            /* Using cursor P00962 */
            pr_default.execute(0, new Object[] {AV13TipCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A149TipCod = P00962_A149TipCod[0];
               A1910TipDsc = P00962_A1910TipDsc[0];
               AV22Filtro1 = A1910TipDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00963 */
            pr_default.execute(1, new Object[] {AV8TipCCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A159TipCCod = P00963_A159TipCCod[0];
               A1905TipCDsc = P00963_A1905TipCDsc[0];
               AV23Filtro2 = A1905TipCDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00964 */
            pr_default.execute(2, new Object[] {AV14MonCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A180MonCod = P00964_A180MonCod[0];
               A1234MonDsc = P00964_A1234MonDsc[0];
               n1234MonDsc = P00964_n1234MonDsc[0];
               AV24Filtro3 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P00965 */
            pr_default.execute(3, new Object[] {AV10CliCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A45CliCod = P00965_A45CliCod[0];
               A161CliDsc = P00965_A161CliDsc[0];
               AV25Filtro4 = A161CliDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            AV19TotGImporte = 0.00m;
            AV20TotGPagos = 0.00m;
            AV21TotGSaldo = 0.00m;
            AV48TotGImporte2 = 0.00m;
            AV49TotGPagos2 = 0.00m;
            AV50TotGSaldos2 = 0.00m;
            /* Execute user subroutine: 'HISTORICOCUENTACOBRAR' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            H960( false, 52) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19TotGImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 468, Gx_line+9, 565, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20TotGPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 569, Gx_line+9, 674, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV21TotGSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+9, 778, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(465, Gx_line+4, 787, Gx_line+4, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General MN", 360, Gx_line+10, 461, Gx_line+24, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48TotGImporte2, "ZZZZZZ,ZZZ,ZZ9.99")), 458, Gx_line+28, 565, Gx_line+43, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49TotGPagos2, "ZZZZZZ,ZZZ,ZZ9.99")), 568, Gx_line+28, 675, Gx_line+43, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50TotGSaldos2, "ZZZZZZ,ZZZ,ZZ9.99")), 672, Gx_line+28, 779, Gx_line+43, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General ME", 360, Gx_line+29, 460, Gx_line+43, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H960( true, 0) ;
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
         /* 'HISTORICOCUENTACOBRAR' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV10CliCod ,
                                              AV9EstCod ,
                                              AV14MonCod ,
                                              AV13TipCod ,
                                              AV47PedSts ,
                                              A188CCCliCod ,
                                              A140EstCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A506CCEstado ,
                                              A190CCFech ,
                                              AV45FDesde ,
                                              AV36FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00966 */
         pr_default.execute(4, new Object[] {AV45FDesde, AV36FHasta, AV10CliCod, AV9EstCod, AV14MonCod, AV13TipCod, AV47PedSts});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A190CCFech = P00966_A190CCFech[0];
            A506CCEstado = P00966_A506CCEstado[0];
            A184CCTipCod = P00966_A184CCTipCod[0];
            A187CCmonCod = P00966_A187CCmonCod[0];
            A140EstCod = P00966_A140EstCod[0];
            n140EstCod = P00966_n140EstCod[0];
            A188CCCliCod = P00966_A188CCCliCod[0];
            A185CCDocNum = P00966_A185CCDocNum[0];
            A511TipSigno = P00966_A511TipSigno[0];
            n511TipSigno = P00966_n511TipSigno[0];
            A513CCImpTotal = P00966_A513CCImpTotal[0];
            A509CCImpPago = P00966_A509CCImpPago[0];
            A508CCFVcto = P00966_A508CCFVcto[0];
            A1234MonDsc = P00966_A1234MonDsc[0];
            n1234MonDsc = P00966_n1234MonDsc[0];
            A306TipAbr = P00966_A306TipAbr[0];
            n306TipAbr = P00966_n306TipAbr[0];
            A511TipSigno = P00966_A511TipSigno[0];
            n511TipSigno = P00966_n511TipSigno[0];
            A306TipAbr = P00966_A306TipAbr[0];
            n306TipAbr = P00966_n306TipAbr[0];
            A1234MonDsc = P00966_A1234MonDsc[0];
            n1234MonDsc = P00966_n1234MonDsc[0];
            A140EstCod = P00966_A140EstCod[0];
            n140EstCod = P00966_n140EstCod[0];
            AV10CliCod = A188CCCliCod;
            AV16TotImporte = 0.00m;
            AV17TotPagos = 0.00m;
            AV18TotSaldo = 0.00m;
            AV37CCTipCod = A184CCTipCod;
            AV38CCDocNum = A185CCDocNum;
            AV46CCEstado = A506CCEstado;
            AV29Importe = (decimal)(((StringUtil.StrCmp(AV46CCEstado, "A")==0) ? (decimal)(0) : A513CCImpTotal)*A511TipSigno);
            AV30Pagos = (decimal)(((StringUtil.StrCmp(AV46CCEstado, "A")==0) ? (decimal)(0) : A509CCImpPago)*A511TipSigno);
            AV39CCmonCod = A187CCmonCod;
            AV15Saldo = (decimal)(((StringUtil.StrCmp(AV46CCEstado, "A")==0) ? (decimal)(0) : (A513CCImpTotal-A509CCImpPago))*A511TipSigno);
            AV31Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A508CCFVcto));
            H960( false, 17) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A185CCDocNum, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A190CCFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A508CCFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 394, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV30Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV15Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31Dias), "ZZZZ9")), 308, Gx_line+2, 365, Gx_line+17, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+17);
            AV19TotGImporte = (decimal)(AV19TotGImporte+(((AV39CCmonCod==1) ? AV29Importe : (decimal)(0))));
            AV20TotGPagos = (decimal)(AV20TotGPagos+(((AV39CCmonCod==1) ? AV30Pagos : (decimal)(0))));
            AV21TotGSaldo = (decimal)(AV21TotGSaldo+(((AV39CCmonCod==1) ? AV15Saldo : (decimal)(0))));
            AV48TotGImporte2 = (decimal)(AV48TotGImporte2+((!(AV39CCmonCod==1) ? AV29Importe : (decimal)(0))));
            AV49TotGPagos2 = (decimal)(AV49TotGPagos2+((!(AV39CCmonCod==1) ? AV30Pagos : (decimal)(0))));
            AV50TotGSaldos2 = (decimal)(AV50TotGSaldos2+((!(AV39CCmonCod==1) ? AV15Saldo : (decimal)(0))));
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void H960( bool bFoot ,
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
               getPrinter().GxDrawText("T/D", 14, Gx_line+236, 37, Gx_line+250, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Documento", 71, Gx_line+238, 156, Gx_line+252, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dias Vcto", 324, Gx_line+238, 379, Gx_line+252, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 395, Gx_line+238, 443, Gx_line+252, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe Total", 473, Gx_line+238, 556, Gx_line+252, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+230, 797, Gx_line+256, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Historico de Cuentas por Cobrar ", 278, Gx_line+70, 555, Gx_line+90, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 174, Gx_line+238, 209, Gx_line+252, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Vcto", 236, Gx_line+238, 301, Gx_line+252, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 719, Gx_line+238, 752, Gx_line+252, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pago", 616, Gx_line+238, 646, Gx_line+252, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Documento", 119, Gx_line+135, 234, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Cliente", 119, Gx_line+157, 206, Gx_line+171, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 119, Gx_line+179, 167, Gx_line+193, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 119, Gx_line+203, 161, Gx_line+217, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 253, Gx_line+130, 596, Gx_line+154, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro2, "")), 253, Gx_line+152, 596, Gx_line+176, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro3, "")), 253, Gx_line+174, 596, Gx_line+198, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Filtro4, "")), 253, Gx_line+198, 596, Gx_line+222, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32EmpDir, "")), 19, Gx_line+29, 404, Gx_line+47, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42EmpRUC, "")), 19, Gx_line+46, 404, Gx_line+64, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Empresa, "")), 19, Gx_line+11, 404, Gx_line+29, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 418, Gx_line+98, 448, Gx_line+118, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV36FHasta, "99/99/99"), 457, Gx_line+98, 539, Gx_line+119, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV45FDesde, "99/99/99"), 325, Gx_line+98, 407, Gx_line+119, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Del :", 285, Gx_line+98, 326, Gx_line+118, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+256);
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
         P00962_A149TipCod = new string[] {""} ;
         P00962_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         P00963_A159TipCCod = new int[1] ;
         P00963_A1905TipCDsc = new string[] {""} ;
         A1905TipCDsc = "";
         P00964_A180MonCod = new int[1] ;
         P00964_A1234MonDsc = new string[] {""} ;
         P00964_n1234MonDsc = new bool[] {false} ;
         A1234MonDsc = "";
         P00965_A45CliCod = new string[] {""} ;
         P00965_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         AV9EstCod = "";
         A188CCCliCod = "";
         A140EstCod = "";
         A184CCTipCod = "";
         A506CCEstado = "";
         A190CCFech = DateTime.MinValue;
         P00966_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00966_A506CCEstado = new string[] {""} ;
         P00966_A184CCTipCod = new string[] {""} ;
         P00966_A187CCmonCod = new int[1] ;
         P00966_A140EstCod = new string[] {""} ;
         P00966_n140EstCod = new bool[] {false} ;
         P00966_A188CCCliCod = new string[] {""} ;
         P00966_A185CCDocNum = new string[] {""} ;
         P00966_A511TipSigno = new short[1] ;
         P00966_n511TipSigno = new bool[] {false} ;
         P00966_A513CCImpTotal = new decimal[1] ;
         P00966_A509CCImpPago = new decimal[1] ;
         P00966_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00966_A1234MonDsc = new string[] {""} ;
         P00966_n1234MonDsc = new bool[] {false} ;
         P00966_A306TipAbr = new string[] {""} ;
         P00966_n306TipAbr = new bool[] {false} ;
         A185CCDocNum = "";
         A508CCFVcto = DateTime.MinValue;
         A306TipAbr = "";
         AV37CCTipCod = "";
         AV38CCDocNum = "";
         AV46CCEstado = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrhistoricocuentacobrar__default(),
            new Object[][] {
                new Object[] {
               P00962_A149TipCod, P00962_A1910TipDsc
               }
               , new Object[] {
               P00963_A159TipCCod, P00963_A1905TipCDsc
               }
               , new Object[] {
               P00964_A180MonCod, P00964_A1234MonDsc
               }
               , new Object[] {
               P00965_A45CliCod, P00965_A161CliDsc
               }
               , new Object[] {
               P00966_A190CCFech, P00966_A506CCEstado, P00966_A184CCTipCod, P00966_A187CCmonCod, P00966_A140EstCod, P00966_n140EstCod, P00966_A188CCCliCod, P00966_A185CCDocNum, P00966_A511TipSigno, P00966_n511TipSigno,
               P00966_A513CCImpTotal, P00966_A509CCImpPago, P00966_A508CCFVcto, P00966_A1234MonDsc, P00966_n1234MonDsc, P00966_A306TipAbr, P00966_n306TipAbr
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
      private int A159TipCCod ;
      private int A180MonCod ;
      private int Gx_OldLine ;
      private int A187CCmonCod ;
      private int AV39CCmonCod ;
      private int AV31Dias ;
      private decimal AV19TotGImporte ;
      private decimal AV20TotGPagos ;
      private decimal AV21TotGSaldo ;
      private decimal AV48TotGImporte2 ;
      private decimal AV49TotGPagos2 ;
      private decimal AV50TotGSaldos2 ;
      private decimal A513CCImpTotal ;
      private decimal A509CCImpPago ;
      private decimal AV16TotImporte ;
      private decimal AV17TotPagos ;
      private decimal AV18TotSaldo ;
      private decimal AV29Importe ;
      private decimal AV30Pagos ;
      private decimal AV15Saldo ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10CliCod ;
      private string AV13TipCod ;
      private string AV47PedSts ;
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
      private string A1905TipCDsc ;
      private string A1234MonDsc ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string AV9EstCod ;
      private string A188CCCliCod ;
      private string A140EstCod ;
      private string A184CCTipCod ;
      private string A506CCEstado ;
      private string A185CCDocNum ;
      private string A306TipAbr ;
      private string AV37CCTipCod ;
      private string AV38CCDocNum ;
      private string AV46CCEstado ;
      private string Gx_time ;
      private DateTime AV45FDesde ;
      private DateTime AV36FHasta ;
      private DateTime A190CCFech ;
      private DateTime A508CCFVcto ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1234MonDsc ;
      private bool returnInSub ;
      private bool n140EstCod ;
      private bool n511TipSigno ;
      private bool n306TipAbr ;
      private string AV53Logo_GXI ;
      private string AV44Logo ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CliCod ;
      private string aP1_TipCod ;
      private int aP2_MonCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private string aP5_PedSts ;
      private IDataStoreProvider pr_default ;
      private string[] P00962_A149TipCod ;
      private string[] P00962_A1910TipDsc ;
      private int[] P00963_A159TipCCod ;
      private string[] P00963_A1905TipCDsc ;
      private int[] P00964_A180MonCod ;
      private string[] P00964_A1234MonDsc ;
      private bool[] P00964_n1234MonDsc ;
      private string[] P00965_A45CliCod ;
      private string[] P00965_A161CliDsc ;
      private DateTime[] P00966_A190CCFech ;
      private string[] P00966_A506CCEstado ;
      private string[] P00966_A184CCTipCod ;
      private int[] P00966_A187CCmonCod ;
      private string[] P00966_A140EstCod ;
      private bool[] P00966_n140EstCod ;
      private string[] P00966_A188CCCliCod ;
      private string[] P00966_A185CCDocNum ;
      private short[] P00966_A511TipSigno ;
      private bool[] P00966_n511TipSigno ;
      private decimal[] P00966_A513CCImpTotal ;
      private decimal[] P00966_A509CCImpPago ;
      private DateTime[] P00966_A508CCFVcto ;
      private string[] P00966_A1234MonDsc ;
      private bool[] P00966_n1234MonDsc ;
      private string[] P00966_A306TipAbr ;
      private bool[] P00966_n306TipAbr ;
   }

   public class rrhistoricocuentacobrar__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00966( IGxContext context ,
                                             string AV10CliCod ,
                                             string AV9EstCod ,
                                             int AV14MonCod ,
                                             string AV13TipCod ,
                                             string AV47PedSts ,
                                             string A188CCCliCod ,
                                             string A140EstCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             string A506CCEstado ,
                                             DateTime A190CCFech ,
                                             DateTime AV45FDesde ,
                                             DateTime AV36FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CCFech], T1.[CCEstado], T1.[CCTipCod] AS CCTipCod, T1.[CCmonCod] AS CCmonCod, T4.[EstCod], T1.[CCCliCod] AS CCCliCod, T1.[CCDocNum], T2.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCFVcto], T3.[MonDsc], T2.[TipAbr] FROM ((([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[CCmonCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T1.[CCFech] >= @AV45FDesde and T1.[CCFech] <= @AV36FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV10CliCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9EstCod)) )
         {
            AddWhere(sWhereString, "(T4.[EstCod] = @AV9EstCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV13TipCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV47PedSts, "TD") != 0 )
         {
            AddWhere(sWhereString, "(T1.[CCEstado] = @AV47PedSts)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliCod], T1.[CCFech]";
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
               case 4 :
                     return conditional_P00966(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] );
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
          Object[] prmP00962;
          prmP00962 = new Object[] {
          new ParDef("@AV13TipCod",GXType.NChar,3,0)
          };
          Object[] prmP00963;
          prmP00963 = new Object[] {
          new ParDef("@AV8TipCCod",GXType.Int32,6,0)
          };
          Object[] prmP00964;
          prmP00964 = new Object[] {
          new ParDef("@AV14MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00965;
          prmP00965 = new Object[] {
          new ParDef("@AV10CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00966;
          prmP00966 = new Object[] {
          new ParDef("@AV45FDesde",GXType.Date,8,0) ,
          new ParDef("@AV36FHasta",GXType.Date,8,0) ,
          new ParDef("@AV10CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV9EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV13TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV47PedSts",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00962", "SELECT [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipCod] = @AV13TipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00962,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00963", "SELECT [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @AV8TipCCod ORDER BY [TipCCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00963,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00964", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV14MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00964,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00965", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV10CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00965,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00966", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00966,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 4 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getString(7, 12);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 100);
                ((bool[]) buf[14])[0] = rslt.wasNull(12);
                ((string[]) buf[15])[0] = rslt.getString(13, 5);
                ((bool[]) buf[16])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
