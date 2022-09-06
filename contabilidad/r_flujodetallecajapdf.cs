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
   public class r_flujodetallecajapdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_flujodetallecajapdf.aspx")), "contabilidad.r_flujodetallecajapdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_flujodetallecajapdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "FDesde");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV38FDesde = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV39FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV22CosCod = GetPar( "CosCod");
                  AV33Moneda = (int)(NumberUtil.Val( GetPar( "Moneda"), "."));
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

      public r_flujodetallecajapdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_flujodetallecajapdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FDesde ,
                           ref DateTime aP1_FHasta ,
                           ref string aP2_CosCod ,
                           ref int aP3_Moneda )
      {
         this.AV38FDesde = aP0_FDesde;
         this.AV39FHasta = aP1_FHasta;
         this.AV22CosCod = aP2_CosCod;
         this.AV33Moneda = aP3_Moneda;
         initialize();
         executePrivate();
         aP0_FDesde=this.AV38FDesde;
         aP1_FHasta=this.AV39FHasta;
         aP2_CosCod=this.AV22CosCod;
         aP3_Moneda=this.AV33Moneda;
      }

      public int executeUdp( ref DateTime aP0_FDesde ,
                             ref DateTime aP1_FHasta ,
                             ref string aP2_CosCod )
      {
         execute(ref aP0_FDesde, ref aP1_FHasta, ref aP2_CosCod, ref aP3_Moneda);
         return AV33Moneda ;
      }

      public void executeSubmit( ref DateTime aP0_FDesde ,
                                 ref DateTime aP1_FHasta ,
                                 ref string aP2_CosCod ,
                                 ref int aP3_Moneda )
      {
         r_flujodetallecajapdf objr_flujodetallecajapdf;
         objr_flujodetallecajapdf = new r_flujodetallecajapdf();
         objr_flujodetallecajapdf.AV38FDesde = aP0_FDesde;
         objr_flujodetallecajapdf.AV39FHasta = aP1_FHasta;
         objr_flujodetallecajapdf.AV22CosCod = aP2_CosCod;
         objr_flujodetallecajapdf.AV33Moneda = aP3_Moneda;
         objr_flujodetallecajapdf.context.SetSubmitInitialConfig(context);
         objr_flujodetallecajapdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_flujodetallecajapdf);
         aP0_FDesde=this.AV38FDesde;
         aP1_FHasta=this.AV39FHasta;
         aP2_CosCod=this.AV22CosCod;
         aP3_Moneda=this.AV33Moneda;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_flujodetallecajapdf)stateInfo).executePrivate();
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
            AV10Empresa = AV14Session.Get("Empresa");
            AV11EmpDir = AV14Session.Get("EmpDir");
            AV12EmpRUC = AV14Session.Get("EmpRUC");
            AV13Ruta = AV14Session.Get("RUTA") + "/Logo.jpg";
            AV9Logo = AV13Ruta;
            AV44Logo_GXI = GXDbFile.PathToUrl( AV13Ruta);
            AV28Titulo1 = "Del : " + context.localUtil.DToC( AV38FDesde, 2, "/") + " Al : " + context.localUtil.DToC( AV39FHasta, 2, "/");
            AV29Titulo2 = "";
            /* Using cursor P00CY2 */
            pr_default.execute(0, new Object[] {AV22CosCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A79COSCod = P00CY2_A79COSCod[0];
               A761COSDsc = P00CY2_A761COSDsc[0];
               AV29Titulo2 = StringUtil.Trim( A761COSDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV15Tipo = "INGRESOS";
            AV30Tipo2 = "TOTAL INGRESOS";
            AV20CBFlujTip = "I";
            AV26TotIng = 0.00m;
            AV31Totales = 0.00m;
            HCY0( false, 24) ;
            getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Tipo, "")), 7, Gx_line+2, 783, Gx_line+22, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+24);
            /* Using cursor P00CY3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A2269CBFlujTip = P00CY3_A2269CBFlujTip[0];
               A2277CBFlujDsc = P00CY3_A2277CBFlujDsc[0];
               A2270CBFlujCod = P00CY3_A2270CBFlujCod[0];
               AV18Rubro = A2277CBFlujDsc;
               AV17CBFlujCod = A2270CBFlujCod;
               AV40TotRubros = 0.00m;
               HCY0( false, 23) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Rubro, "")), 41, Gx_line+2, 682, Gx_line+22, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+23);
               /* Using cursor P00CY4 */
               pr_default.execute(2, new Object[] {AV17CBFlujCod});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A2270CBFlujCod = P00CY4_A2270CBFlujCod[0];
                  A2269CBFlujTip = P00CY4_A2269CBFlujTip[0];
                  A2276CBFlujCDsc = P00CY4_A2276CBFlujCDsc[0];
                  A2271CBFlujCCod = P00CY4_A2271CBFlujCCod[0];
                  AV21CBFlujCCod = A2271CBFlujCCod;
                  AV19Lineas = A2276CBFlujCDsc;
                  /* Execute user subroutine: 'IMPORTE' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(2);
                     this.cleanup();
                     if (true) return;
                  }
                  HCY0( false, 23) ;
                  getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Lineas, "")), 120, Gx_line+4, 526, Gx_line+19, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23Total, "ZZZZZZ,ZZZ,ZZ9.99")), 542, Gx_line+4, 667, Gx_line+20, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+23);
                  AV26TotIng = (decimal)(AV26TotIng+AV23Total);
                  AV40TotRubros = (decimal)(AV40TotRubros+AV23Total);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               HCY0( false, 38) ;
               getPrinter().GxDrawLine(526, Gx_line+8, 691, Gx_line+8, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40TotRubros, "ZZZZZZ,ZZZ,ZZ9.99")), 524, Gx_line+13, 667, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Rubro", 444, Gx_line+13, 521, Gx_line+28, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+38);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV31Totales = AV26TotIng;
            HCY0( false, 41) ;
            getPrinter().GxDrawLine(526, Gx_line+7, 691, Gx_line+7, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Tipo2, "")), 155, Gx_line+10, 521, Gx_line+28, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31Totales, "ZZZZZZ,ZZZ,ZZ9.99")), 524, Gx_line+11, 667, Gx_line+29, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+41);
            AV15Tipo = "EGRESOS";
            AV30Tipo2 = "TOTAL EGRESOS";
            AV20CBFlujTip = "E";
            AV27TotEgr = 0.00m;
            HCY0( false, 24) ;
            getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Tipo, "")), 7, Gx_line+2, 783, Gx_line+22, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+24);
            /* Using cursor P00CY5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               A2269CBFlujTip = P00CY5_A2269CBFlujTip[0];
               A2277CBFlujDsc = P00CY5_A2277CBFlujDsc[0];
               A2270CBFlujCod = P00CY5_A2270CBFlujCod[0];
               AV18Rubro = A2277CBFlujDsc;
               AV17CBFlujCod = A2270CBFlujCod;
               AV40TotRubros = 0.00m;
               HCY0( false, 23) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Rubro, "")), 41, Gx_line+2, 682, Gx_line+22, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+23);
               /* Using cursor P00CY6 */
               pr_default.execute(4, new Object[] {AV17CBFlujCod});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A2270CBFlujCod = P00CY6_A2270CBFlujCod[0];
                  A2269CBFlujTip = P00CY6_A2269CBFlujTip[0];
                  A2276CBFlujCDsc = P00CY6_A2276CBFlujCDsc[0];
                  A2271CBFlujCCod = P00CY6_A2271CBFlujCCod[0];
                  AV21CBFlujCCod = A2271CBFlujCCod;
                  AV19Lineas = A2276CBFlujCDsc;
                  /* Execute user subroutine: 'IMPORTE' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(4);
                     this.cleanup();
                     if (true) return;
                  }
                  HCY0( false, 23) ;
                  getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Lineas, "")), 120, Gx_line+4, 526, Gx_line+19, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23Total, "ZZZZZZ,ZZZ,ZZ9.99")), 542, Gx_line+4, 667, Gx_line+20, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+23);
                  AV27TotEgr = (decimal)(AV27TotEgr+AV23Total);
                  AV40TotRubros = (decimal)(AV40TotRubros+AV23Total);
                  pr_default.readNext(4);
               }
               pr_default.close(4);
               HCY0( false, 38) ;
               getPrinter().GxDrawLine(526, Gx_line+8, 691, Gx_line+8, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40TotRubros, "ZZZZZZ,ZZZ,ZZ9.99")), 524, Gx_line+13, 667, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Rubro", 444, Gx_line+13, 521, Gx_line+28, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+38);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV31Totales = AV27TotEgr;
            HCY0( false, 41) ;
            getPrinter().GxDrawLine(526, Gx_line+7, 691, Gx_line+7, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Tipo2, "")), 155, Gx_line+10, 521, Gx_line+28, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31Totales, "ZZZZZZ,ZZZ,ZZ9.99")), 524, Gx_line+11, 667, Gx_line+29, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+41);
            AV37Saldo = (decimal)(AV26TotIng-AV27TotEgr);
            HCY0( false, 39) ;
            getPrinter().GxDrawLine(526, Gx_line+5, 691, Gx_line+5, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 524, Gx_line+9, 667, Gx_line+27, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("SALDO", 475, Gx_line+9, 521, Gx_line+27, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+39);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HCY0( true, 0) ;
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
         /* 'IMPORTE' Routine */
         returnInSub = false;
         AV23Total = 0.00m;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV22CosCod ,
                                              A79COSCod ,
                                              A1079LBFech ,
                                              AV38FDesde ,
                                              AV39FHasta ,
                                              AV20CBFlujTip ,
                                              AV17CBFlujCod ,
                                              AV21CBFlujCCod ,
                                              A2269CBFlujTip ,
                                              A2270CBFlujCod ,
                                              A2271CBFlujCCod } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00CY7 */
         pr_default.execute(5, new Object[] {AV20CBFlujTip, AV17CBFlujCod, AV21CBFlujCCod, AV38FDesde, AV39FHasta, AV22CosCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A2265CBFlujCBanCod = P00CY7_A2265CBFlujCBanCod[0];
            A2266CBFlujCCuenta = P00CY7_A2266CBFlujCCuenta[0];
            A2267CBFlujCRegistro = P00CY7_A2267CBFlujCRegistro[0];
            A79COSCod = P00CY7_A79COSCod[0];
            A1079LBFech = P00CY7_A1079LBFech[0];
            n1079LBFech = P00CY7_n1079LBFech[0];
            A2271CBFlujCCod = P00CY7_A2271CBFlujCCod[0];
            A2270CBFlujCod = P00CY7_A2270CBFlujCod[0];
            A2269CBFlujTip = P00CY7_A2269CBFlujTip[0];
            A2272CBFlujCMonCod = P00CY7_A2272CBFlujCMonCod[0];
            A2275CBFlujCCosto = P00CY7_A2275CBFlujCCosto[0];
            A1091LBTipCmb = P00CY7_A1091LBTipCmb[0];
            n1091LBTipCmb = P00CY7_n1091LBTipCmb[0];
            A2263CBFlujCAno = P00CY7_A2263CBFlujCAno[0];
            A2264CBFlujCMes = P00CY7_A2264CBFlujCMes[0];
            A2268CBFlujCItem = P00CY7_A2268CBFlujCItem[0];
            A2272CBFlujCMonCod = P00CY7_A2272CBFlujCMonCod[0];
            A1079LBFech = P00CY7_A1079LBFech[0];
            n1079LBFech = P00CY7_n1079LBFech[0];
            A1091LBTipCmb = P00CY7_A1091LBTipCmb[0];
            n1091LBTipCmb = P00CY7_n1091LBTipCmb[0];
            AV34LBFech = A1079LBFech;
            AV32MonCod = A2272CBFlujCMonCod;
            AV35Importe = A2275CBFlujCCosto;
            AV41LBTipCmb = A1091LBTipCmb;
            if ( AV33Moneda != AV32MonCod )
            {
               GXt_decimal1 = AV36TipVenta;
               GXt_int2 = 2;
               GXt_char3 = "C";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV34LBFech, ref  GXt_char3, out  GXt_decimal1) ;
               AV36TipVenta = GXt_decimal1;
               if ( AV33Moneda == 1 )
               {
                  AV35Importe = NumberUtil.Round( AV35Importe*AV36TipVenta, 2);
               }
               else
               {
                  AV35Importe = NumberUtil.Round( AV35Importe/ (decimal)(AV36TipVenta), 2);
               }
            }
            AV23Total = (decimal)(AV23Total+AV35Importe);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void HCY0( bool bFoot ,
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
               AV8Titulo = "Flujo de Caja";
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hora:", 661, Gx_line+35, 693, Gx_line+49, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 661, Gx_line+53, 705, Gx_line+67, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 661, Gx_line+18, 700, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 721, Gx_line+17, 768, Gx_line+32, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 683, Gx_line+34, 767, Gx_line+49, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 729, Gx_line+52, 768, Gx_line+67, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8Titulo, "")), 183, Gx_line+18, 639, Gx_line+43, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Conceptos", 65, Gx_line+115, 127, Gx_line+129, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+108, 798, Gx_line+135, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV9Logo)) ? AV44Logo_GXI : AV9Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 17, Gx_line+19, 175, Gx_line+97) ;
               getPrinter().GxDrawText("Importe", 592, Gx_line+115, 642, Gx_line+129, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Titulo1, "")), 183, Gx_line+44, 639, Gx_line+69, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Titulo2, "")), 183, Gx_line+70, 639, Gx_line+95, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+135);
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
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
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
         AV10Empresa = "";
         AV14Session = context.GetSession();
         AV11EmpDir = "";
         AV12EmpRUC = "";
         AV13Ruta = "";
         AV9Logo = "";
         AV44Logo_GXI = "";
         AV28Titulo1 = "";
         AV29Titulo2 = "";
         scmdbuf = "";
         P00CY2_A79COSCod = new string[] {""} ;
         P00CY2_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         AV15Tipo = "";
         AV30Tipo2 = "";
         AV20CBFlujTip = "";
         P00CY3_A2269CBFlujTip = new string[] {""} ;
         P00CY3_A2277CBFlujDsc = new string[] {""} ;
         P00CY3_A2270CBFlujCod = new string[] {""} ;
         A2269CBFlujTip = "";
         A2277CBFlujDsc = "";
         A2270CBFlujCod = "";
         AV18Rubro = "";
         AV17CBFlujCod = "";
         P00CY4_A2270CBFlujCod = new string[] {""} ;
         P00CY4_A2269CBFlujTip = new string[] {""} ;
         P00CY4_A2276CBFlujCDsc = new string[] {""} ;
         P00CY4_A2271CBFlujCCod = new string[] {""} ;
         A2276CBFlujCDsc = "";
         A2271CBFlujCCod = "";
         AV21CBFlujCCod = "";
         AV19Lineas = "";
         P00CY5_A2269CBFlujTip = new string[] {""} ;
         P00CY5_A2277CBFlujDsc = new string[] {""} ;
         P00CY5_A2270CBFlujCod = new string[] {""} ;
         P00CY6_A2270CBFlujCod = new string[] {""} ;
         P00CY6_A2269CBFlujTip = new string[] {""} ;
         P00CY6_A2276CBFlujCDsc = new string[] {""} ;
         P00CY6_A2271CBFlujCCod = new string[] {""} ;
         A1079LBFech = DateTime.MinValue;
         P00CY7_A2265CBFlujCBanCod = new int[1] ;
         P00CY7_A2266CBFlujCCuenta = new string[] {""} ;
         P00CY7_A2267CBFlujCRegistro = new string[] {""} ;
         P00CY7_A79COSCod = new string[] {""} ;
         P00CY7_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P00CY7_n1079LBFech = new bool[] {false} ;
         P00CY7_A2271CBFlujCCod = new string[] {""} ;
         P00CY7_A2270CBFlujCod = new string[] {""} ;
         P00CY7_A2269CBFlujTip = new string[] {""} ;
         P00CY7_A2272CBFlujCMonCod = new int[1] ;
         P00CY7_A2275CBFlujCCosto = new decimal[1] ;
         P00CY7_A1091LBTipCmb = new decimal[1] ;
         P00CY7_n1091LBTipCmb = new bool[] {false} ;
         P00CY7_A2263CBFlujCAno = new short[1] ;
         P00CY7_A2264CBFlujCMes = new short[1] ;
         P00CY7_A2268CBFlujCItem = new int[1] ;
         A2266CBFlujCCuenta = "";
         A2267CBFlujCRegistro = "";
         AV34LBFech = DateTime.MinValue;
         GXt_char3 = "";
         AV8Titulo = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV9Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_flujodetallecajapdf__default(),
            new Object[][] {
                new Object[] {
               P00CY2_A79COSCod, P00CY2_A761COSDsc
               }
               , new Object[] {
               P00CY3_A2269CBFlujTip, P00CY3_A2277CBFlujDsc, P00CY3_A2270CBFlujCod
               }
               , new Object[] {
               P00CY4_A2270CBFlujCod, P00CY4_A2269CBFlujTip, P00CY4_A2276CBFlujCDsc, P00CY4_A2271CBFlujCCod
               }
               , new Object[] {
               P00CY5_A2269CBFlujTip, P00CY5_A2277CBFlujDsc, P00CY5_A2270CBFlujCod
               }
               , new Object[] {
               P00CY6_A2270CBFlujCod, P00CY6_A2269CBFlujTip, P00CY6_A2276CBFlujCDsc, P00CY6_A2271CBFlujCCod
               }
               , new Object[] {
               P00CY7_A2265CBFlujCBanCod, P00CY7_A2266CBFlujCCuenta, P00CY7_A2267CBFlujCRegistro, P00CY7_A79COSCod, P00CY7_A1079LBFech, P00CY7_n1079LBFech, P00CY7_A2271CBFlujCCod, P00CY7_A2270CBFlujCod, P00CY7_A2269CBFlujTip, P00CY7_A2272CBFlujCMonCod,
               P00CY7_A2275CBFlujCCosto, P00CY7_A1091LBTipCmb, P00CY7_n1091LBTipCmb, P00CY7_A2263CBFlujCAno, P00CY7_A2264CBFlujCMes, P00CY7_A2268CBFlujCItem
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
      private short A2263CBFlujCAno ;
      private short A2264CBFlujCMes ;
      private int AV33Moneda ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A2265CBFlujCBanCod ;
      private int A2272CBFlujCMonCod ;
      private int A2268CBFlujCItem ;
      private int AV32MonCod ;
      private int GXt_int2 ;
      private decimal AV26TotIng ;
      private decimal AV31Totales ;
      private decimal AV40TotRubros ;
      private decimal AV23Total ;
      private decimal AV27TotEgr ;
      private decimal AV37Saldo ;
      private decimal A2275CBFlujCCosto ;
      private decimal A1091LBTipCmb ;
      private decimal AV35Importe ;
      private decimal AV41LBTipCmb ;
      private decimal AV36TipVenta ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV22CosCod ;
      private string AV10Empresa ;
      private string AV11EmpDir ;
      private string AV12EmpRUC ;
      private string AV13Ruta ;
      private string AV28Titulo1 ;
      private string AV29Titulo2 ;
      private string scmdbuf ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string AV15Tipo ;
      private string AV30Tipo2 ;
      private string AV20CBFlujTip ;
      private string A2269CBFlujTip ;
      private string A2277CBFlujDsc ;
      private string A2270CBFlujCod ;
      private string AV18Rubro ;
      private string AV17CBFlujCod ;
      private string A2276CBFlujCDsc ;
      private string A2271CBFlujCCod ;
      private string AV21CBFlujCCod ;
      private string AV19Lineas ;
      private string A2266CBFlujCCuenta ;
      private string A2267CBFlujCRegistro ;
      private string GXt_char3 ;
      private string AV8Titulo ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV38FDesde ;
      private DateTime AV39FHasta ;
      private DateTime A1079LBFech ;
      private DateTime AV34LBFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool n1079LBFech ;
      private bool n1091LBTipCmb ;
      private string AV44Logo_GXI ;
      private string AV9Logo ;
      private string Logo ;
      private IGxSession AV14Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FDesde ;
      private DateTime aP1_FHasta ;
      private string aP2_CosCod ;
      private int aP3_Moneda ;
      private IDataStoreProvider pr_default ;
      private string[] P00CY2_A79COSCod ;
      private string[] P00CY2_A761COSDsc ;
      private string[] P00CY3_A2269CBFlujTip ;
      private string[] P00CY3_A2277CBFlujDsc ;
      private string[] P00CY3_A2270CBFlujCod ;
      private string[] P00CY4_A2270CBFlujCod ;
      private string[] P00CY4_A2269CBFlujTip ;
      private string[] P00CY4_A2276CBFlujCDsc ;
      private string[] P00CY4_A2271CBFlujCCod ;
      private string[] P00CY5_A2269CBFlujTip ;
      private string[] P00CY5_A2277CBFlujDsc ;
      private string[] P00CY5_A2270CBFlujCod ;
      private string[] P00CY6_A2270CBFlujCod ;
      private string[] P00CY6_A2269CBFlujTip ;
      private string[] P00CY6_A2276CBFlujCDsc ;
      private string[] P00CY6_A2271CBFlujCCod ;
      private int[] P00CY7_A2265CBFlujCBanCod ;
      private string[] P00CY7_A2266CBFlujCCuenta ;
      private string[] P00CY7_A2267CBFlujCRegistro ;
      private string[] P00CY7_A79COSCod ;
      private DateTime[] P00CY7_A1079LBFech ;
      private bool[] P00CY7_n1079LBFech ;
      private string[] P00CY7_A2271CBFlujCCod ;
      private string[] P00CY7_A2270CBFlujCod ;
      private string[] P00CY7_A2269CBFlujTip ;
      private int[] P00CY7_A2272CBFlujCMonCod ;
      private decimal[] P00CY7_A2275CBFlujCCosto ;
      private decimal[] P00CY7_A1091LBTipCmb ;
      private bool[] P00CY7_n1091LBTipCmb ;
      private short[] P00CY7_A2263CBFlujCAno ;
      private short[] P00CY7_A2264CBFlujCMes ;
      private int[] P00CY7_A2268CBFlujCItem ;
   }

   public class r_flujodetallecajapdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CY7( IGxContext context ,
                                             string AV22CosCod ,
                                             string A79COSCod ,
                                             DateTime A1079LBFech ,
                                             DateTime AV38FDesde ,
                                             DateTime AV39FHasta ,
                                             string AV20CBFlujTip ,
                                             string AV17CBFlujCod ,
                                             string AV21CBFlujCCod ,
                                             string A2269CBFlujTip ,
                                             string A2270CBFlujCod ,
                                             string A2271CBFlujCCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[CBFlujCBanCod] AS CBFlujCBanCod, T1.[CBFlujCCuenta] AS CBFlujCCuenta, T1.[CBFlujCRegistro] AS CBFlujCRegistro, T1.[COSCod], T3.[LBFech], T1.[CBFlujCCod], T1.[CBFlujCod], T1.[CBFlujTip], T2.[MonCod] AS CBFlujCMonCod, T1.[CBFlujCCosto], T3.[LBTipCmb], T1.[CBFlujCAno], T1.[CBFlujCMes], T1.[CBFlujCItem] FROM (([CBFLUJOCONCEPTOSDET] T1 INNER JOIN [TSCUENTABANCO] T2 ON T2.[BanCod] = T1.[CBFlujCBanCod] AND T2.[CBCod] = T1.[CBFlujCCuenta]) INNER JOIN [TSLIBROBANCOS] T3 ON T3.[LBBanCod] = T1.[CBFlujCBanCod] AND T3.[LBCBCod] = T1.[CBFlujCCuenta] AND T3.[LBRegistro] = T1.[CBFlujCRegistro])";
         AddWhere(sWhereString, "(T1.[CBFlujTip] = @AV20CBFlujTip and T1.[CBFlujCod] = @AV17CBFlujCod and T1.[CBFlujCCod] = @AV21CBFlujCCod)");
         AddWhere(sWhereString, "(T3.[LBFech] >= @AV38FDesde)");
         AddWhere(sWhereString, "(T3.[LBFech] <= @AV39FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CosCod)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV22CosCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CBFlujTip], T1.[CBFlujCod], T1.[CBFlujCCod]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 5 :
                     return conditional_P00CY7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
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
          Object[] prmP00CY2;
          prmP00CY2 = new Object[] {
          new ParDef("@AV22CosCod",GXType.NChar,10,0)
          };
          Object[] prmP00CY3;
          prmP00CY3 = new Object[] {
          };
          Object[] prmP00CY4;
          prmP00CY4 = new Object[] {
          new ParDef("@AV17CBFlujCod",GXType.NChar,5,0)
          };
          Object[] prmP00CY5;
          prmP00CY5 = new Object[] {
          };
          Object[] prmP00CY6;
          prmP00CY6 = new Object[] {
          new ParDef("@AV17CBFlujCod",GXType.NChar,5,0)
          };
          Object[] prmP00CY7;
          prmP00CY7 = new Object[] {
          new ParDef("@AV20CBFlujTip",GXType.NChar,1,0) ,
          new ParDef("@AV17CBFlujCod",GXType.NChar,5,0) ,
          new ParDef("@AV21CBFlujCCod",GXType.NChar,5,0) ,
          new ParDef("@AV38FDesde",GXType.Date,8,0) ,
          new ParDef("@AV39FHasta",GXType.Date,8,0) ,
          new ParDef("@AV22CosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CY2", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV22CosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CY2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CY3", "SELECT [CBFlujTip], [CBFlujDsc], [CBFlujCod] FROM [CBFLUJOTITULO] WHERE [CBFlujTip] = 'I' ORDER BY [CBFlujTip], [CBFlujCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CY3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CY4", "SELECT [CBFlujCod], [CBFlujTip], [CBFlujCDsc], [CBFlujCCod] FROM [CBFLUJOTITULODET] WHERE [CBFlujTip] = 'I' and [CBFlujCod] = @AV17CBFlujCod ORDER BY [CBFlujTip], [CBFlujCod], [CBFlujCCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CY4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CY5", "SELECT [CBFlujTip], [CBFlujDsc], [CBFlujCod] FROM [CBFLUJOTITULO] WHERE [CBFlujTip] = 'E' ORDER BY [CBFlujTip], [CBFlujCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CY5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CY6", "SELECT [CBFlujCod], [CBFlujTip], [CBFlujCDsc], [CBFlujCCod] FROM [CBFLUJOTITULODET] WHERE [CBFlujTip] = 'E' and [CBFlujCod] = @AV17CBFlujCod ORDER BY [CBFlujTip], [CBFlujCod], [CBFlujCCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CY6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CY7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CY7,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 5);
                ((string[]) buf[7])[0] = rslt.getString(7, 5);
                ((string[]) buf[8])[0] = rslt.getString(8, 1);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((short[]) buf[13])[0] = rslt.getShort(12);
                ((short[]) buf[14])[0] = rslt.getShort(13);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
