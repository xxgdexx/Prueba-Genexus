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
namespace GeneXus.Programs.produccion {
   public class r_ordenesproduccionpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.r_ordenesproduccionpdf.aspx")), "produccion.r_ordenesproduccionpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.r_ordenesproduccionpdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "ProdCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV49ProdCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV30FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV31FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV50ProCod = GetPar( "ProCod");
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

      public r_ordenesproduccionpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_ordenesproduccionpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProdCod ,
                           ref DateTime aP1_FDesde ,
                           ref DateTime aP2_FHasta ,
                           ref string aP3_ProCod )
      {
         this.AV49ProdCod = aP0_ProdCod;
         this.AV30FDesde = aP1_FDesde;
         this.AV31FHasta = aP2_FHasta;
         this.AV50ProCod = aP3_ProCod;
         initialize();
         executePrivate();
         aP0_ProdCod=this.AV49ProdCod;
         aP1_FDesde=this.AV30FDesde;
         aP2_FHasta=this.AV31FHasta;
         aP3_ProCod=this.AV50ProCod;
      }

      public string executeUdp( ref string aP0_ProdCod ,
                                ref DateTime aP1_FDesde ,
                                ref DateTime aP2_FHasta )
      {
         execute(ref aP0_ProdCod, ref aP1_FDesde, ref aP2_FHasta, ref aP3_ProCod);
         return AV50ProCod ;
      }

      public void executeSubmit( ref string aP0_ProdCod ,
                                 ref DateTime aP1_FDesde ,
                                 ref DateTime aP2_FHasta ,
                                 ref string aP3_ProCod )
      {
         r_ordenesproduccionpdf objr_ordenesproduccionpdf;
         objr_ordenesproduccionpdf = new r_ordenesproduccionpdf();
         objr_ordenesproduccionpdf.AV49ProdCod = aP0_ProdCod;
         objr_ordenesproduccionpdf.AV30FDesde = aP1_FDesde;
         objr_ordenesproduccionpdf.AV31FHasta = aP2_FHasta;
         objr_ordenesproduccionpdf.AV50ProCod = aP3_ProCod;
         objr_ordenesproduccionpdf.context.SetSubmitInitialConfig(context);
         objr_ordenesproduccionpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_ordenesproduccionpdf);
         aP0_ProdCod=this.AV49ProdCod;
         aP1_FDesde=this.AV30FDesde;
         aP2_FHasta=this.AV31FHasta;
         aP3_ProCod=this.AV50ProCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_ordenesproduccionpdf)stateInfo).executePrivate();
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
            AV38Empresa = AV43Session.Get("Empresa");
            AV39EmpDir = AV43Session.Get("EmpDir");
            AV40EmpRUC = AV43Session.Get("EmpRUC");
            AV41Ruta = AV43Session.Get("RUTA") + "/Logo.jpg";
            AV42Logo = AV41Ruta;
            AV56Logo_GXI = GXDbFile.PathToUrl( AV41Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV24Filtro3 = "Todos";
            /* Using cursor P00FI2 */
            pr_default.execute(0, new Object[] {AV49ProdCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A28ProdCod = P00FI2_A28ProdCod[0];
               A55ProdDsc = P00FI2_A55ProdDsc[0];
               AV22Filtro1 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV19TotGImporte = 0.00m;
            AV20TotGPagos = 0.00m;
            AV21TotGSaldo = 0.00m;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV49ProdCod ,
                                                 AV50ProCod ,
                                                 AV30FDesde ,
                                                 AV31FHasta ,
                                                 A323ProProdCod ,
                                                 A322ProCod ,
                                                 A325ProFec } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00FI3 */
            pr_default.execute(1, new Object[] {AV49ProdCod, AV50ProCod, AV30FDesde, AV31FHasta});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A49UniCod = P00FI3_A49UniCod[0];
               n49UniCod = P00FI3_n49UniCod[0];
               A1997UniAbr = P00FI3_A1997UniAbr[0];
               A325ProFec = P00FI3_A325ProFec[0];
               A322ProCod = P00FI3_A322ProCod[0];
               A323ProProdCod = P00FI3_A323ProProdCod[0];
               A1655ProCantProdIng = P00FI3_A1655ProCantProdIng[0];
               A1654ProCantProd = P00FI3_A1654ProCantProd[0];
               A1738ProProdDsc = P00FI3_A1738ProProdDsc[0];
               A49UniCod = P00FI3_A49UniCod[0];
               n49UniCod = P00FI3_n49UniCod[0];
               A1738ProProdDsc = P00FI3_A1738ProProdDsc[0];
               A1997UniAbr = P00FI3_A1997UniAbr[0];
               AV51Orden = A322ProCod;
               HFI0( false, 111) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A323ProProdCod, "@!")), 93, Gx_line+25, 188, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A322ProCod, "")), 93, Gx_line+5, 157, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A325ProFec, "99/99/99"), 277, Gx_line+5, 332, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 7, Gx_line+95, 48, Gx_line+109, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+94, 807, Gx_line+111, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 100, Gx_line+95, 154, Gx_line+109, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Unidad", 354, Gx_line+95, 396, Gx_line+109, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cant. Formula", 415, Gx_line+95, 497, Gx_line+109, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cant. Salida", 523, Gx_line+95, 593, Gx_line+109, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Costo", 617, Gx_line+95, 685, Gx_line+109, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1738ProProdDsc, "")), 191, Gx_line+25, 673, Gx_line+42, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1654ProCantProd, "ZZZZ,ZZZ,ZZ9.9999")), 93, Gx_line+45, 218, Gx_line+63, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1655ProCantProdIng, "ZZZZ,ZZZ,ZZ9.9999")), 443, Gx_line+45, 568, Gx_line+63, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Orden", 6, Gx_line+6, 67, Gx_line+24, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Orden", 186, Gx_line+5, 270, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 6, Gx_line+26, 68, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cant Producir", 6, Gx_line+46, 99, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cant Producida", 352, Gx_line+45, 455, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+76, 807, Gx_line+95, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Materia Prima", 349, Gx_line+76, 444, Gx_line+94, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+111);
               AV34PedDCan = 0.00m;
               AV35PedDCanDsp = 0.00m;
               AV36PedDCanFac = 0.00m;
               AV53TotalCosto = 0.00m;
               /* Using cursor P00FI4 */
               pr_default.execute(2, new Object[] {AV51Orden});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A1680ProDConcepto = P00FI4_A1680ProDConcepto[0];
                  A322ProCod = P00FI4_A322ProCod[0];
                  A326ProDItem = P00FI4_A326ProDItem[0];
                  A1656ProCosto = P00FI4_A1656ProCosto[0];
                  A1677ProDCantFormula = P00FI4_A1677ProDCantFormula[0];
                  A1678ProDCantIng = P00FI4_A1678ProDCantIng[0];
                  A1704ProDProdDsc = P00FI4_A1704ProDProdDsc[0];
                  A327ProDProdCod = P00FI4_A327ProDProdCod[0];
                  n327ProDProdCod = P00FI4_n327ProDProdCod[0];
                  A1704ProDProdDsc = P00FI4_A1704ProDProdDsc[0];
                  AV53TotalCosto = (decimal)(AV53TotalCosto+A1656ProCosto);
                  HFI0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A327ProDProdCod, "@!")), 3, Gx_line+1, 91, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1704ProDProdDsc, "")), 88, Gx_line+1, 343, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1656ProCosto, "ZZZZZZ,ZZZ,ZZ9.99")), 579, Gx_line+1, 685, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1678ProDCantIng, "ZZZ,ZZZ,ZZ9.99999999")), 468, Gx_line+1, 594, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1677ProDCantFormula, "ZZZ,ZZZ,ZZ9.99999999")), 399, Gx_line+1, 496, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 348, Gx_line+1, 392, Gx_line+16, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               /* Execute user subroutine: 'MANOOBRA' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'MAQUINA' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'VARIOS' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'DISTIBUYE' */
               S141 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               HFI0( false, 26) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total General", 457, Gx_line+5, 547, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(582, Gx_line+3, 720, Gx_line+3, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TotalCosto, "ZZZZZZ,ZZZ,ZZ9.99")), 579, Gx_line+9, 686, Gx_line+24, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+26);
               HFI0( false, 61) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+61);
               /* Eject command */
               Gx_OldLine = Gx_line;
               Gx_line = (int)(P_lines+1);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HFI0( true, 0) ;
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
         /* 'MANOOBRA' Routine */
         returnInSub = false;
         AV12Flag = 0;
         /* Using cursor P00FI5 */
         pr_default.execute(3, new Object[] {AV51Orden});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A322ProCod = P00FI5_A322ProCod[0];
            A1457OrdOpeHora = P00FI5_A1457OrdOpeHora[0];
            A321OPECod = P00FI5_A321OPECod[0];
            AV12Flag = 1;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( AV12Flag == 1 )
         {
            HFI0( false, 53) ;
            getPrinter().GxDrawRect(0, Gx_line+16, 807, Gx_line+35, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Mano de Obra", 349, Gx_line+16, 444, Gx_line+34, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Costo Total", 523, Gx_line+36, 591, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Costo Hora", 426, Gx_line+36, 492, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("N° Horas", 354, Gx_line+36, 406, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Operario", 100, Gx_line+36, 152, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Codigo", 7, Gx_line+36, 48, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+35, 807, Gx_line+52, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+53);
         }
         /* Using cursor P00FI6 */
         pr_default.execute(4, new Object[] {AV51Orden});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A322ProCod = P00FI6_A322ProCod[0];
            A1422OPEDsc = P00FI6_A1422OPEDsc[0];
            A321OPECod = P00FI6_A321OPECod[0];
            A1455OrdOpeCosto = P00FI6_A1455OrdOpeCosto[0];
            A1457OrdOpeHora = P00FI6_A1457OrdOpeHora[0];
            A1422OPEDsc = P00FI6_A1422OPEDsc[0];
            A1456OrdOpeCostoTotal = NumberUtil.Round( A1457OrdOpeHora*A1455OrdOpeCosto, 2);
            AV53TotalCosto = (decimal)(AV53TotalCosto+A1456OrdOpeCostoTotal);
            HFI0( false, 19) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A321OPECod, "")), 5, Gx_line+1, 84, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1422OPEDsc, "")), 85, Gx_line+1, 340, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1455OrdOpeCosto, "ZZZZZZ,ZZZ,ZZ9.99")), 389, Gx_line+1, 496, Gx_line+16, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1457OrdOpeHora, "ZZZZZZ,ZZZ,ZZ9.99")), 349, Gx_line+1, 456, Gx_line+16, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1456OrdOpeCostoTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 493, Gx_line+1, 600, Gx_line+16, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S121( )
      {
         /* 'MAQUINA' Routine */
         returnInSub = false;
         AV12Flag = 0;
         /* Using cursor P00FI7 */
         pr_default.execute(5, new Object[] {AV51Orden});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A322ProCod = P00FI7_A322ProCod[0];
            A1727ProMaqCosto = P00FI7_A1727ProMaqCosto[0];
            A320MAQCod = P00FI7_A320MAQCod[0];
            AV12Flag = 1;
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( AV12Flag == 1 )
         {
            HFI0( false, 53) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Maquinas", 364, Gx_line+16, 429, Gx_line+34, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Costo Total", 523, Gx_line+36, 591, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Costo Hora", 426, Gx_line+36, 492, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("N° Horas", 354, Gx_line+36, 406, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Maquina", 100, Gx_line+36, 151, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Codigo", 7, Gx_line+36, 48, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+35, 807, Gx_line+52, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+16, 807, Gx_line+35, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+53);
         }
         /* Using cursor P00FI8 */
         pr_default.execute(6, new Object[] {AV51Orden});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A322ProCod = P00FI8_A322ProCod[0];
            A1220MAQDsc = P00FI8_A1220MAQDsc[0];
            A320MAQCod = P00FI8_A320MAQCod[0];
            A1727ProMaqCosto = P00FI8_A1727ProMaqCosto[0];
            A1729ProMaqHora = P00FI8_A1729ProMaqHora[0];
            A1220MAQDsc = P00FI8_A1220MAQDsc[0];
            A1728ProMaqCostoTotal = NumberUtil.Round( A1729ProMaqHora*A1727ProMaqCosto, 2);
            AV53TotalCosto = (decimal)(AV53TotalCosto+A1728ProMaqCostoTotal);
            HFI0( false, 18) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A320MAQCod, "")), 3, Gx_line+1, 82, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1220MAQDsc, "")), 83, Gx_line+1, 338, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1729ProMaqHora, "ZZZZZZ,ZZZ,ZZ9.99")), 347, Gx_line+1, 410, Gx_line+15, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1727ProMaqCosto, "ZZZZZZ,ZZZ,ZZ9.99")), 386, Gx_line+1, 492, Gx_line+15, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1728ProMaqCostoTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 491, Gx_line+1, 597, Gx_line+15, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+18);
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S131( )
      {
         /* 'VARIOS' Routine */
         returnInSub = false;
         AV12Flag = 0;
         /* Using cursor P00FI9 */
         pr_default.execute(7, new Object[] {AV51Orden});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A322ProCod = P00FI9_A322ProCod[0];
            A1725ProGasConcepto = P00FI9_A1725ProGasConcepto[0];
            A328ProGasCod = P00FI9_A328ProGasCod[0];
            AV12Flag = 1;
            pr_default.readNext(7);
         }
         pr_default.close(7);
         if ( AV12Flag == 1 )
         {
            HFI0( false, 55) ;
            getPrinter().GxDrawRect(0, Gx_line+35, 807, Gx_line+52, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+17, 807, Gx_line+36, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 7, Gx_line+36, 48, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Concepto", 100, Gx_line+36, 156, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Costo Total", 523, Gx_line+36, 591, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Concepto Varios", 356, Gx_line+17, 467, Gx_line+35, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+55);
         }
         /* Using cursor P00FI10 */
         pr_default.execute(8, new Object[] {AV51Orden});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A322ProCod = P00FI10_A322ProCod[0];
            A1726ProGasCosto = P00FI10_A1726ProGasCosto[0];
            A328ProGasCod = P00FI10_A328ProGasCod[0];
            A1725ProGasConcepto = P00FI10_A1725ProGasConcepto[0];
            AV53TotalCosto = (decimal)(AV53TotalCosto+A1726ProGasCosto);
            HFI0( false, 15) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1726ProGasCosto, "ZZZZZ,ZZZ,ZZ9.999999")), 489, Gx_line+0, 595, Gx_line+14, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1725ProGasConcepto, "")), 81, Gx_line+0, 336, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A328ProGasCod), "ZZZ9")), 1, Gx_line+0, 80, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+15);
            pr_default.readNext(8);
         }
         pr_default.close(8);
      }

      protected void S141( )
      {
         /* 'DISTIBUYE' Routine */
         returnInSub = false;
         AV12Flag = 0;
         /* Using cursor P00FI11 */
         pr_default.execute(9, new Object[] {AV51Orden});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A1680ProDConcepto = P00FI11_A1680ProDConcepto[0];
            A322ProCod = P00FI11_A322ProCod[0];
            A326ProDItem = P00FI11_A326ProDItem[0];
            AV12Flag = 1;
            pr_default.readNext(9);
         }
         pr_default.close(9);
         if ( AV12Flag == 1 )
         {
            HFI0( false, 53) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Costo Total", 523, Gx_line+36, 591, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+16, 807, Gx_line+35, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+35, 807, Gx_line+52, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Distribución de Costos", 321, Gx_line+16, 472, Gx_line+34, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Concepto", 100, Gx_line+36, 156, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Codigo", 7, Gx_line+36, 48, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("% Afectación", 419, Gx_line+36, 499, Gx_line+50, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+53);
         }
         /* Using cursor P00FI12 */
         pr_default.execute(10, new Object[] {AV51Orden});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A1680ProDConcepto = P00FI12_A1680ProDConcepto[0];
            A322ProCod = P00FI12_A322ProCod[0];
            A326ProDItem = P00FI12_A326ProDItem[0];
            A1656ProCosto = P00FI12_A1656ProCosto[0];
            A1677ProDCantFormula = P00FI12_A1677ProDCantFormula[0];
            A327ProDProdCod = P00FI12_A327ProDProdCod[0];
            n327ProDProdCod = P00FI12_n327ProDProdCod[0];
            AV53TotalCosto = (decimal)(AV53TotalCosto+A1656ProCosto);
            AV52Porcentaje = NumberUtil.Round( A1677ProDCantFormula*100, 4);
            HFI0( false, 21) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A327ProDProdCod, "@!")), 5, Gx_line+3, 93, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1680ProDConcepto, "")), 90, Gx_line+3, 345, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52Porcentaje, "ZZZZ,ZZZ,ZZ9.9999")), 386, Gx_line+3, 493, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1656ProCosto, "ZZZZZZ,ZZZ,ZZ9.99")), 491, Gx_line+3, 597, Gx_line+17, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+21);
            pr_default.readNext(10);
         }
         pr_default.close(10);
      }

      protected void HFI0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 660, Gx_line+32, 692, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 660, Gx_line+50, 704, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 660, Gx_line+15, 699, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 730, Gx_line+50, 769, Gx_line+65, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 707, Gx_line+32, 767, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 722, Gx_line+15, 769, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Ordenes Producción Detallado", 224, Gx_line+52, 590, Gx_line+72, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Producto", 210, Gx_line+90, 272, Gx_line+108, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 230, Gx_line+116, 273, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Al", 352, Gx_line+116, 367, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 281, Gx_line+85, 624, Gx_line+109, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV30FDesde, "99/99/99"), 281, Gx_line+116, 336, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV31FHasta, "99/99/99"), 382, Gx_line+116, 437, Gx_line+134, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV42Logo)) ? AV56Logo_GXI : AV42Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 11, Gx_line+16, 166, Gx_line+92) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+142);
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
         AV38Empresa = "";
         AV43Session = context.GetSession();
         AV39EmpDir = "";
         AV40EmpRUC = "";
         AV41Ruta = "";
         AV42Logo = "";
         AV56Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         scmdbuf = "";
         P00FI2_A28ProdCod = new string[] {""} ;
         P00FI2_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         A323ProProdCod = "";
         A322ProCod = "";
         A325ProFec = DateTime.MinValue;
         P00FI3_A49UniCod = new int[1] ;
         P00FI3_n49UniCod = new bool[] {false} ;
         P00FI3_A1997UniAbr = new string[] {""} ;
         P00FI3_A325ProFec = new DateTime[] {DateTime.MinValue} ;
         P00FI3_A322ProCod = new string[] {""} ;
         P00FI3_A323ProProdCod = new string[] {""} ;
         P00FI3_A1655ProCantProdIng = new decimal[1] ;
         P00FI3_A1654ProCantProd = new decimal[1] ;
         P00FI3_A1738ProProdDsc = new string[] {""} ;
         A1997UniAbr = "";
         A1738ProProdDsc = "";
         AV51Orden = "";
         P00FI4_A1680ProDConcepto = new string[] {""} ;
         P00FI4_A322ProCod = new string[] {""} ;
         P00FI4_A326ProDItem = new int[1] ;
         P00FI4_A1656ProCosto = new decimal[1] ;
         P00FI4_A1677ProDCantFormula = new decimal[1] ;
         P00FI4_A1678ProDCantIng = new decimal[1] ;
         P00FI4_A1704ProDProdDsc = new string[] {""} ;
         P00FI4_A327ProDProdCod = new string[] {""} ;
         P00FI4_n327ProDProdCod = new bool[] {false} ;
         A1680ProDConcepto = "";
         A1704ProDProdDsc = "";
         A327ProDProdCod = "";
         P00FI5_A322ProCod = new string[] {""} ;
         P00FI5_A1457OrdOpeHora = new decimal[1] ;
         P00FI5_A321OPECod = new string[] {""} ;
         A321OPECod = "";
         P00FI6_A322ProCod = new string[] {""} ;
         P00FI6_A1422OPEDsc = new string[] {""} ;
         P00FI6_A321OPECod = new string[] {""} ;
         P00FI6_A1455OrdOpeCosto = new decimal[1] ;
         P00FI6_A1457OrdOpeHora = new decimal[1] ;
         A1422OPEDsc = "";
         P00FI7_A322ProCod = new string[] {""} ;
         P00FI7_A1727ProMaqCosto = new decimal[1] ;
         P00FI7_A320MAQCod = new string[] {""} ;
         A320MAQCod = "";
         P00FI8_A322ProCod = new string[] {""} ;
         P00FI8_A1220MAQDsc = new string[] {""} ;
         P00FI8_A320MAQCod = new string[] {""} ;
         P00FI8_A1727ProMaqCosto = new decimal[1] ;
         P00FI8_A1729ProMaqHora = new decimal[1] ;
         A1220MAQDsc = "";
         P00FI9_A322ProCod = new string[] {""} ;
         P00FI9_A1725ProGasConcepto = new string[] {""} ;
         P00FI9_A328ProGasCod = new short[1] ;
         A1725ProGasConcepto = "";
         P00FI10_A322ProCod = new string[] {""} ;
         P00FI10_A1726ProGasCosto = new decimal[1] ;
         P00FI10_A328ProGasCod = new short[1] ;
         P00FI10_A1725ProGasConcepto = new string[] {""} ;
         P00FI11_A1680ProDConcepto = new string[] {""} ;
         P00FI11_A322ProCod = new string[] {""} ;
         P00FI11_A326ProDItem = new int[1] ;
         P00FI12_A1680ProDConcepto = new string[] {""} ;
         P00FI12_A322ProCod = new string[] {""} ;
         P00FI12_A326ProDItem = new int[1] ;
         P00FI12_A1656ProCosto = new decimal[1] ;
         P00FI12_A1677ProDCantFormula = new decimal[1] ;
         P00FI12_A327ProDProdCod = new string[] {""} ;
         P00FI12_n327ProDProdCod = new bool[] {false} ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV42Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_ordenesproduccionpdf__default(),
            new Object[][] {
                new Object[] {
               P00FI2_A28ProdCod, P00FI2_A55ProdDsc
               }
               , new Object[] {
               P00FI3_A49UniCod, P00FI3_n49UniCod, P00FI3_A1997UniAbr, P00FI3_A325ProFec, P00FI3_A322ProCod, P00FI3_A323ProProdCod, P00FI3_A1655ProCantProdIng, P00FI3_A1654ProCantProd, P00FI3_A1738ProProdDsc
               }
               , new Object[] {
               P00FI4_A1680ProDConcepto, P00FI4_A322ProCod, P00FI4_A326ProDItem, P00FI4_A1656ProCosto, P00FI4_A1677ProDCantFormula, P00FI4_A1678ProDCantIng, P00FI4_A1704ProDProdDsc, P00FI4_A327ProDProdCod, P00FI4_n327ProDProdCod
               }
               , new Object[] {
               P00FI5_A322ProCod, P00FI5_A1457OrdOpeHora, P00FI5_A321OPECod
               }
               , new Object[] {
               P00FI6_A322ProCod, P00FI6_A1422OPEDsc, P00FI6_A321OPECod, P00FI6_A1455OrdOpeCosto, P00FI6_A1457OrdOpeHora
               }
               , new Object[] {
               P00FI7_A322ProCod, P00FI7_A1727ProMaqCosto, P00FI7_A320MAQCod
               }
               , new Object[] {
               P00FI8_A322ProCod, P00FI8_A1220MAQDsc, P00FI8_A320MAQCod, P00FI8_A1727ProMaqCosto, P00FI8_A1729ProMaqHora
               }
               , new Object[] {
               P00FI9_A322ProCod, P00FI9_A1725ProGasConcepto, P00FI9_A328ProGasCod
               }
               , new Object[] {
               P00FI10_A322ProCod, P00FI10_A1726ProGasCosto, P00FI10_A328ProGasCod, P00FI10_A1725ProGasConcepto
               }
               , new Object[] {
               P00FI11_A1680ProDConcepto, P00FI11_A322ProCod, P00FI11_A326ProDItem
               }
               , new Object[] {
               P00FI12_A1680ProDConcepto, P00FI12_A322ProCod, P00FI12_A326ProDItem, P00FI12_A1656ProCosto, P00FI12_A1677ProDCantFormula, P00FI12_A327ProDProdCod, P00FI12_n327ProDProdCod
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
      private short AV12Flag ;
      private short A328ProGasCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A49UniCod ;
      private int Gx_OldLine ;
      private int A326ProDItem ;
      private decimal AV19TotGImporte ;
      private decimal AV20TotGPagos ;
      private decimal AV21TotGSaldo ;
      private decimal A1655ProCantProdIng ;
      private decimal A1654ProCantProd ;
      private decimal AV34PedDCan ;
      private decimal AV35PedDCanDsp ;
      private decimal AV36PedDCanFac ;
      private decimal AV53TotalCosto ;
      private decimal A1656ProCosto ;
      private decimal A1677ProDCantFormula ;
      private decimal A1678ProDCantIng ;
      private decimal A1457OrdOpeHora ;
      private decimal A1455OrdOpeCosto ;
      private decimal A1456OrdOpeCostoTotal ;
      private decimal A1727ProMaqCosto ;
      private decimal A1729ProMaqHora ;
      private decimal A1728ProMaqCostoTotal ;
      private decimal A1726ProGasCosto ;
      private decimal AV52Porcentaje ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV49ProdCod ;
      private string AV50ProCod ;
      private string AV38Empresa ;
      private string AV39EmpDir ;
      private string AV40EmpRUC ;
      private string AV41Ruta ;
      private string AV22Filtro1 ;
      private string AV23Filtro2 ;
      private string AV24Filtro3 ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A323ProProdCod ;
      private string A322ProCod ;
      private string A1997UniAbr ;
      private string A1738ProProdDsc ;
      private string AV51Orden ;
      private string A1680ProDConcepto ;
      private string A1704ProDProdDsc ;
      private string A327ProDProdCod ;
      private string A321OPECod ;
      private string A1422OPEDsc ;
      private string A320MAQCod ;
      private string A1220MAQDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV30FDesde ;
      private DateTime AV31FHasta ;
      private DateTime A325ProFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n49UniCod ;
      private bool n327ProDProdCod ;
      private bool returnInSub ;
      private string AV56Logo_GXI ;
      private string A1725ProGasConcepto ;
      private string AV42Logo ;
      private string Logo ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProdCod ;
      private DateTime aP1_FDesde ;
      private DateTime aP2_FHasta ;
      private string aP3_ProCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00FI2_A28ProdCod ;
      private string[] P00FI2_A55ProdDsc ;
      private int[] P00FI3_A49UniCod ;
      private bool[] P00FI3_n49UniCod ;
      private string[] P00FI3_A1997UniAbr ;
      private DateTime[] P00FI3_A325ProFec ;
      private string[] P00FI3_A322ProCod ;
      private string[] P00FI3_A323ProProdCod ;
      private decimal[] P00FI3_A1655ProCantProdIng ;
      private decimal[] P00FI3_A1654ProCantProd ;
      private string[] P00FI3_A1738ProProdDsc ;
      private string[] P00FI4_A1680ProDConcepto ;
      private string[] P00FI4_A322ProCod ;
      private int[] P00FI4_A326ProDItem ;
      private decimal[] P00FI4_A1656ProCosto ;
      private decimal[] P00FI4_A1677ProDCantFormula ;
      private decimal[] P00FI4_A1678ProDCantIng ;
      private string[] P00FI4_A1704ProDProdDsc ;
      private string[] P00FI4_A327ProDProdCod ;
      private bool[] P00FI4_n327ProDProdCod ;
      private string[] P00FI5_A322ProCod ;
      private decimal[] P00FI5_A1457OrdOpeHora ;
      private string[] P00FI5_A321OPECod ;
      private string[] P00FI6_A322ProCod ;
      private string[] P00FI6_A1422OPEDsc ;
      private string[] P00FI6_A321OPECod ;
      private decimal[] P00FI6_A1455OrdOpeCosto ;
      private decimal[] P00FI6_A1457OrdOpeHora ;
      private string[] P00FI7_A322ProCod ;
      private decimal[] P00FI7_A1727ProMaqCosto ;
      private string[] P00FI7_A320MAQCod ;
      private string[] P00FI8_A322ProCod ;
      private string[] P00FI8_A1220MAQDsc ;
      private string[] P00FI8_A320MAQCod ;
      private decimal[] P00FI8_A1727ProMaqCosto ;
      private decimal[] P00FI8_A1729ProMaqHora ;
      private string[] P00FI9_A322ProCod ;
      private string[] P00FI9_A1725ProGasConcepto ;
      private short[] P00FI9_A328ProGasCod ;
      private string[] P00FI10_A322ProCod ;
      private decimal[] P00FI10_A1726ProGasCosto ;
      private short[] P00FI10_A328ProGasCod ;
      private string[] P00FI10_A1725ProGasConcepto ;
      private string[] P00FI11_A1680ProDConcepto ;
      private string[] P00FI11_A322ProCod ;
      private int[] P00FI11_A326ProDItem ;
      private string[] P00FI12_A1680ProDConcepto ;
      private string[] P00FI12_A322ProCod ;
      private int[] P00FI12_A326ProDItem ;
      private decimal[] P00FI12_A1656ProCosto ;
      private decimal[] P00FI12_A1677ProDCantFormula ;
      private string[] P00FI12_A327ProDProdCod ;
      private bool[] P00FI12_n327ProDProdCod ;
   }

   public class r_ordenesproduccionpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FI3( IGxContext context ,
                                             string AV49ProdCod ,
                                             string AV50ProCod ,
                                             DateTime AV30FDesde ,
                                             DateTime AV31FHasta ,
                                             string A323ProProdCod ,
                                             string A322ProCod ,
                                             DateTime A325ProFec )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T3.[UniAbr], T1.[ProFec], T1.[ProCod], T1.[ProProdCod] AS ProProdCod, T1.[ProCantProdIng], T1.[ProCantProd], T2.[ProdDsc] AS ProProdDsc FROM (([POORDENES] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProProdCod]) LEFT JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProProdCod] = @AV49ProdCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50ProCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProCod] = @AV50ProCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV30FDesde) && ! (DateTime.MinValue==AV31FHasta) )
         {
            AddWhere(sWhereString, "(T1.[ProFec] >= @AV30FDesde and T1.[ProFec] <= @AV31FHasta)");
         }
         else
         {
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProCod]";
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
                     return conditional_P00FI3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] );
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FI2;
          prmP00FI2 = new Object[] {
          new ParDef("@AV49ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00FI4;
          prmP00FI4 = new Object[] {
          new ParDef("@AV51Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FI5;
          prmP00FI5 = new Object[] {
          new ParDef("@AV51Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FI6;
          prmP00FI6 = new Object[] {
          new ParDef("@AV51Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FI7;
          prmP00FI7 = new Object[] {
          new ParDef("@AV51Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FI8;
          prmP00FI8 = new Object[] {
          new ParDef("@AV51Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FI9;
          prmP00FI9 = new Object[] {
          new ParDef("@AV51Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FI10;
          prmP00FI10 = new Object[] {
          new ParDef("@AV51Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FI11;
          prmP00FI11 = new Object[] {
          new ParDef("@AV51Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FI12;
          prmP00FI12 = new Object[] {
          new ParDef("@AV51Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FI3;
          prmP00FI3 = new Object[] {
          new ParDef("@AV49ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV50ProCod",GXType.NChar,10,0) ,
          new ParDef("@AV30FDesde",GXType.Date,8,0) ,
          new ParDef("@AV31FHasta",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FI2", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV49ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FI3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FI4", "SELECT T1.[ProDConcepto], T1.[ProCod], T1.[ProDItem], T1.[ProCosto], T1.[ProDCantFormula], T1.[ProDCantIng], T2.[ProdDsc] AS ProDProdDsc, T1.[ProDProdCod] AS ProDProdCod FROM ([POORDENESDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProDProdCod]) WHERE (T1.[ProCod] = @AV51Orden) AND ((T1.[ProDConcepto] = '')) ORDER BY T1.[ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FI5", "SELECT [ProCod], [OrdOpeHora], [OPECod] FROM [POORDENOPERARIO] WHERE [ProCod] = @AV51Orden ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FI6", "SELECT T1.[ProCod], T2.[OPEDsc], T1.[OPECod], T1.[OrdOpeCosto], T1.[OrdOpeHora] FROM ([POORDENOPERARIO] T1 INNER JOIN [POOPERARIOS] T2 ON T2.[OPECod] = T1.[OPECod]) WHERE T1.[ProCod] = @AV51Orden ORDER BY T1.[ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FI7", "SELECT [ProCod], [ProMaqCosto], [MAQCod] FROM [POORDENMAQ] WHERE [ProCod] = @AV51Orden ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FI8", "SELECT T1.[ProCod], T2.[MAQDsc], T1.[MAQCod], T1.[ProMaqCosto], T1.[ProMaqHora] FROM ([POORDENMAQ] T1 INNER JOIN [POMAQUINA] T2 ON T2.[MAQCod] = T1.[MAQCod]) WHERE T1.[ProCod] = @AV51Orden ORDER BY T1.[ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FI9", "SELECT [ProCod], [ProGasConcepto], [ProGasCod] FROM [POORDENGASTO] WHERE [ProCod] = @AV51Orden ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FI10", "SELECT [ProCod], [ProGasCosto], [ProGasCod], [ProGasConcepto] FROM [POORDENGASTO] WHERE [ProCod] = @AV51Orden ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI10,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FI11", "SELECT [ProDConcepto], [ProCod], [ProDItem] FROM [POORDENESDET] WHERE ([ProCod] = @AV51Orden) AND (Not ([ProDConcepto] = '')) ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FI12", "SELECT [ProDConcepto], [ProCod], [ProDItem], [ProCosto], [ProDCantFormula], [ProDProdCod] AS ProDProdCod FROM [POORDENESDET] WHERE ([ProCod] = @AV51Orden) AND (Not ([ProDConcepto] = '')) ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI12,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 5);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 10);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 15);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
