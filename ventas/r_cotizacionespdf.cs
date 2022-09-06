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
namespace GeneXus.Programs.ventas {
   public class r_cotizacionespdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "ventas.r_cotizacionespdf.aspx")), "ventas.r_cotizacionespdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "ventas.r_cotizacionespdf.aspx")))) ;
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
                  AV55ProdCod = GetPar( "ProdCod");
                  AV14MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV30FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV31FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV43PedSts = GetPar( "PedSts");
                  AV59VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
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

      public r_cotizacionespdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_cotizacionespdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CliCod ,
                           ref string aP1_ProdCod ,
                           ref int aP2_MonCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref string aP5_PedSts ,
                           ref int aP6_VenCod )
      {
         this.AV10CliCod = aP0_CliCod;
         this.AV55ProdCod = aP1_ProdCod;
         this.AV14MonCod = aP2_MonCod;
         this.AV30FDesde = aP3_FDesde;
         this.AV31FHasta = aP4_FHasta;
         this.AV43PedSts = aP5_PedSts;
         this.AV59VenCod = aP6_VenCod;
         initialize();
         executePrivate();
         aP0_CliCod=this.AV10CliCod;
         aP1_ProdCod=this.AV55ProdCod;
         aP2_MonCod=this.AV14MonCod;
         aP3_FDesde=this.AV30FDesde;
         aP4_FHasta=this.AV31FHasta;
         aP5_PedSts=this.AV43PedSts;
         aP6_VenCod=this.AV59VenCod;
      }

      public int executeUdp( ref string aP0_CliCod ,
                             ref string aP1_ProdCod ,
                             ref int aP2_MonCod ,
                             ref DateTime aP3_FDesde ,
                             ref DateTime aP4_FHasta ,
                             ref string aP5_PedSts )
      {
         execute(ref aP0_CliCod, ref aP1_ProdCod, ref aP2_MonCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_PedSts, ref aP6_VenCod);
         return AV59VenCod ;
      }

      public void executeSubmit( ref string aP0_CliCod ,
                                 ref string aP1_ProdCod ,
                                 ref int aP2_MonCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref string aP5_PedSts ,
                                 ref int aP6_VenCod )
      {
         r_cotizacionespdf objr_cotizacionespdf;
         objr_cotizacionespdf = new r_cotizacionespdf();
         objr_cotizacionespdf.AV10CliCod = aP0_CliCod;
         objr_cotizacionespdf.AV55ProdCod = aP1_ProdCod;
         objr_cotizacionespdf.AV14MonCod = aP2_MonCod;
         objr_cotizacionespdf.AV30FDesde = aP3_FDesde;
         objr_cotizacionespdf.AV31FHasta = aP4_FHasta;
         objr_cotizacionespdf.AV43PedSts = aP5_PedSts;
         objr_cotizacionespdf.AV59VenCod = aP6_VenCod;
         objr_cotizacionespdf.context.SetSubmitInitialConfig(context);
         objr_cotizacionespdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_cotizacionespdf);
         aP0_CliCod=this.AV10CliCod;
         aP1_ProdCod=this.AV55ProdCod;
         aP2_MonCod=this.AV14MonCod;
         aP3_FDesde=this.AV30FDesde;
         aP4_FHasta=this.AV31FHasta;
         aP5_PedSts=this.AV43PedSts;
         aP6_VenCod=this.AV59VenCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_cotizacionespdf)stateInfo).executePrivate();
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
            AV39Empresa = AV42Session.Get("Empresa");
            AV38EmpDir = AV42Session.Get("EmpDir");
            AV37EmpRUC = AV42Session.Get("EmpRUC");
            AV40Ruta = AV42Session.Get("RUTA") + "/Logo.jpg";
            AV41Logo = AV40Ruta;
            AV62Logo_GXI = GXDbFile.PathToUrl( AV40Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV24Filtro3 = "Todos";
            AV25Filtro4 = AV30FDesde;
            AV26Filtro5 = AV31FHasta;
            /* Using cursor P00E22 */
            pr_default.execute(0, new Object[] {AV10CliCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A45CliCod = P00E22_A45CliCod[0];
               A161CliDsc = P00E22_A161CliDsc[0];
               AV22Filtro1 = A161CliDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00E23 */
            pr_default.execute(1, new Object[] {AV14MonCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A180MonCod = P00E23_A180MonCod[0];
               A1234MonDsc = P00E23_A1234MonDsc[0];
               AV23Filtro2 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV24Filtro3 = ((AV32Opcion==1) ? "Pendientes" : "Todos");
            AV49TotGeneral = 0.00m;
            AV19TotGImporte = 0.00m;
            AV20TotGPagos = 0.00m;
            AV21TotGSaldo = 0.00m;
            AV44Item = 0;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV10CliCod ,
                                                 AV14MonCod ,
                                                 AV43PedSts ,
                                                 AV59VenCod ,
                                                 A45CliCod ,
                                                 A180MonCod ,
                                                 A807CotSts ,
                                                 A179CotVendCod ,
                                                 A796CotFec ,
                                                 AV30FDesde ,
                                                 AV31FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00E24 */
            pr_default.execute(2, new Object[] {AV30FDesde, AV31FHasta, AV10CliCod, AV14MonCod, AV43PedSts, AV59VenCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A807CotSts = P00E24_A807CotSts[0];
               A796CotFec = P00E24_A796CotFec[0];
               A177CotCod = P00E24_A177CotCod[0];
               A179CotVendCod = P00E24_A179CotVendCod[0];
               A180MonCod = P00E24_A180MonCod[0];
               A45CliCod = P00E24_A45CliCod[0];
               A161CliDsc = P00E24_A161CliDsc[0];
               A1234MonDsc = P00E24_A1234MonDsc[0];
               A1234MonDsc = P00E24_A1234MonDsc[0];
               A161CliDsc = P00E24_A161CliDsc[0];
               AV44Item = (int)(AV44Item+1);
               AV54PedCliCod = A45CliCod;
               AV52CliDsc = A161CliDsc;
               HE20( false, 21) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52CliDsc, "")), 47, Gx_line+4, 428, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV44Item), "ZZZZ9")), 8, Gx_line+4, 40, Gx_line+19, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 470, Gx_line+4, 742, Gx_line+18, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
               AV34PedDCan = 0.00m;
               AV35PedDCanDsp = 0.00m;
               AV36PedDCanFac = 0.00m;
               AV46Precio = 0.00m;
               AV47Dscto = 0.00m;
               AV48PreTot = 0.00m;
               pr_default.dynParam(3, new Object[]{ new Object[]{
                                                    AV55ProdCod ,
                                                    A28ProdCod ,
                                                    A177CotCod } ,
                                                    new int[]{
                                                    }
               });
               /* Using cursor P00E25 */
               pr_default.execute(3, new Object[] {A177CotCod, AV55ProdCod});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A49UniCod = P00E25_A49UniCod[0];
                  A28ProdCod = P00E25_A28ProdCod[0];
                  A770CotDCan = P00E25_A770CotDCan[0];
                  A771CotDPre = P00E25_A771CotDPre[0];
                  A772CotDDsct1 = P00E25_A772CotDDsct1[0];
                  A768CotDTot = P00E25_A768CotDTot[0];
                  A779CotDObs = P00E25_A779CotDObs[0];
                  A55ProdDsc = P00E25_A55ProdDsc[0];
                  A1997UniAbr = P00E25_A1997UniAbr[0];
                  A183CotDItem = P00E25_A183CotDItem[0];
                  A49UniCod = P00E25_A49UniCod[0];
                  A55ProdDsc = P00E25_A55ProdDsc[0];
                  A1997UniAbr = P00E25_A1997UniAbr[0];
                  AV34PedDCan = (decimal)(AV34PedDCan+A770CotDCan);
                  AV46Precio = (decimal)(AV46Precio+A771CotDPre);
                  AV47Dscto = (decimal)(AV47Dscto+A772CotDDsct1);
                  AV48PreTot = (decimal)(AV48PreTot+A768CotDTot);
                  AV51PedDObs = StringUtil.Trim( A779CotDObs);
                  AV58CotSts = A807CotSts;
                  AV50Producto = (String.IsNullOrEmpty(StringUtil.RTrim( AV51PedDObs)) ? StringUtil.Trim( A55ProdDsc) : StringUtil.Trim( AV51PedDObs));
                  AV57Estado = ((StringUtil.StrCmp(A807CotSts, "A")==0) ? "Anulado" : ((StringUtil.StrCmp(A807CotSts, "")==0) ? "Por Autorizar" : ((StringUtil.StrCmp(A807CotSts, "R")==0) ? "Rechazado" : "Autorizado")));
                  HE20( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A177CotCod, "")), 5, Gx_line+1, 58, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A796CotFec, "99/99/99"), 68, Gx_line+1, 127, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 134, Gx_line+1, 222, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Producto, "")), 224, Gx_line+1, 466, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 470, Gx_line+1, 514, Gx_line+16, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A771CotDPre, "ZZZ,ZZZ,ZZ9.9999")), 509, Gx_line+1, 610, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A772CotDDsct1, "ZZ9.99")), 629, Gx_line+1, 668, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A768CotDTot, "ZZZZ,ZZZ,ZZ9.99")), 636, Gx_line+1, 750, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Estado, "")), 755, Gx_line+1, 808, Gx_line+16, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               AV49TotGeneral = (decimal)(AV49TotGeneral+AV48PreTot);
               HE20( false, 24) ;
               getPrinter().GxDrawLine(532, Gx_line+1, 782, Gx_line+1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Cliente", 259, Gx_line+5, 334, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48PreTot, "ZZZZZZ,ZZZ,ZZ9.99")), 636, Gx_line+5, 743, Gx_line+20, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47Dscto, "ZZZZZZ,ZZZ,ZZ9.99")), 560, Gx_line+5, 667, Gx_line+20, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46Precio, "ZZZZ,ZZZ,ZZ9.9999")), 509, Gx_line+5, 616, Gx_line+20, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HE20( true, 0) ;
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

      protected void HE20( bool bFoot ,
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
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total General", 410, Gx_line+8, 490, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49TotGeneral, "ZZZZZZ,ZZZ,ZZ9.99")), 636, Gx_line+8, 743, Gx_line+23, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+41);
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
               getPrinter().GxDrawText("Hora:", 710, Gx_line+26, 742, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 710, Gx_line+44, 754, Gx_line+58, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 710, Gx_line+8, 749, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 773, Gx_line+44, 812, Gx_line+59, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 750, Gx_line+26, 810, Gx_line+40, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 765, Gx_line+8, 812, Gx_line+23, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cotización", 8, Gx_line+224, 69, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 84, Gx_line+224, 119, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Unidad", 481, Gx_line+224, 523, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+215, 822, Gx_line+242, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Cotizaciones", 303, Gx_line+52, 521, Gx_line+72, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 135, Gx_line+224, 176, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 230, Gx_line+224, 284, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 191, Gx_line+103, 233, Gx_line+117, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 191, Gx_line+125, 239, Gx_line+139, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 191, Gx_line+147, 217, Gx_line+161, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 191, Gx_line+169, 228, Gx_line+183, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta", 191, Gx_line+190, 226, Gx_line+204, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 247, Gx_line+98, 590, Gx_line+122, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro2, "")), 247, Gx_line+120, 590, Gx_line+144, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro3, "")), 247, Gx_line+142, 590, Gx_line+166, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV25Filtro4, "99/99/99"), 247, Gx_line+164, 590, Gx_line+188, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV26Filtro5, "99/99/99"), 247, Gx_line+184, 590, Gx_line+208, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV41Logo)) ? AV62Logo_GXI : AV41Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 14, Gx_line+11, 172, Gx_line+89) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Precio Unit.", 551, Gx_line+224, 619, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dscto", 636, Gx_line+224, 670, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total", 710, Gx_line+224, 741, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37EmpRUC, "")), 14, Gx_line+106, 152, Gx_line+124, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Empresa, "")), 14, Gx_line+89, 320, Gx_line+107, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Estado", 761, Gx_line+224, 802, Gx_line+238, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+242);
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
         AV39Empresa = "";
         AV42Session = context.GetSession();
         AV38EmpDir = "";
         AV37EmpRUC = "";
         AV40Ruta = "";
         AV41Logo = "";
         AV62Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         AV25Filtro4 = DateTime.MinValue;
         AV26Filtro5 = DateTime.MinValue;
         scmdbuf = "";
         P00E22_A45CliCod = new string[] {""} ;
         P00E22_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         P00E23_A180MonCod = new int[1] ;
         P00E23_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         A807CotSts = "";
         A796CotFec = DateTime.MinValue;
         P00E24_A807CotSts = new string[] {""} ;
         P00E24_A796CotFec = new DateTime[] {DateTime.MinValue} ;
         P00E24_A177CotCod = new string[] {""} ;
         P00E24_A179CotVendCod = new int[1] ;
         P00E24_A180MonCod = new int[1] ;
         P00E24_A45CliCod = new string[] {""} ;
         P00E24_A161CliDsc = new string[] {""} ;
         P00E24_A1234MonDsc = new string[] {""} ;
         A177CotCod = "";
         AV54PedCliCod = "";
         AV52CliDsc = "";
         A28ProdCod = "";
         P00E25_A49UniCod = new int[1] ;
         P00E25_A177CotCod = new string[] {""} ;
         P00E25_A28ProdCod = new string[] {""} ;
         P00E25_A770CotDCan = new decimal[1] ;
         P00E25_A771CotDPre = new decimal[1] ;
         P00E25_A772CotDDsct1 = new decimal[1] ;
         P00E25_A768CotDTot = new decimal[1] ;
         P00E25_A779CotDObs = new string[] {""} ;
         P00E25_A55ProdDsc = new string[] {""} ;
         P00E25_A1997UniAbr = new string[] {""} ;
         P00E25_A183CotDItem = new short[1] ;
         A779CotDObs = "";
         A55ProdDsc = "";
         A1997UniAbr = "";
         AV51PedDObs = "";
         AV58CotSts = "";
         AV50Producto = "";
         AV57Estado = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV41Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas.r_cotizacionespdf__default(),
            new Object[][] {
                new Object[] {
               P00E22_A45CliCod, P00E22_A161CliDsc
               }
               , new Object[] {
               P00E23_A180MonCod, P00E23_A1234MonDsc
               }
               , new Object[] {
               P00E24_A807CotSts, P00E24_A796CotFec, P00E24_A177CotCod, P00E24_A179CotVendCod, P00E24_A180MonCod, P00E24_A45CliCod, P00E24_A161CliDsc, P00E24_A1234MonDsc
               }
               , new Object[] {
               P00E25_A49UniCod, P00E25_A177CotCod, P00E25_A28ProdCod, P00E25_A770CotDCan, P00E25_A771CotDPre, P00E25_A772CotDDsct1, P00E25_A768CotDTot, P00E25_A779CotDObs, P00E25_A55ProdDsc, P00E25_A1997UniAbr,
               P00E25_A183CotDItem
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
      private short AV32Opcion ;
      private short A183CotDItem ;
      private int AV14MonCod ;
      private int AV59VenCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int AV44Item ;
      private int A179CotVendCod ;
      private int Gx_OldLine ;
      private int A49UniCod ;
      private decimal AV49TotGeneral ;
      private decimal AV19TotGImporte ;
      private decimal AV20TotGPagos ;
      private decimal AV21TotGSaldo ;
      private decimal AV34PedDCan ;
      private decimal AV35PedDCanDsp ;
      private decimal AV36PedDCanFac ;
      private decimal AV46Precio ;
      private decimal AV47Dscto ;
      private decimal AV48PreTot ;
      private decimal A770CotDCan ;
      private decimal A771CotDPre ;
      private decimal A772CotDDsct1 ;
      private decimal A768CotDTot ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10CliCod ;
      private string AV55ProdCod ;
      private string AV43PedSts ;
      private string AV39Empresa ;
      private string AV38EmpDir ;
      private string AV37EmpRUC ;
      private string AV40Ruta ;
      private string AV22Filtro1 ;
      private string AV23Filtro2 ;
      private string AV24Filtro3 ;
      private string scmdbuf ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A1234MonDsc ;
      private string A807CotSts ;
      private string A177CotCod ;
      private string AV54PedCliCod ;
      private string AV52CliDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1997UniAbr ;
      private string AV58CotSts ;
      private string AV50Producto ;
      private string AV57Estado ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV30FDesde ;
      private DateTime AV31FHasta ;
      private DateTime AV25Filtro4 ;
      private DateTime AV26Filtro5 ;
      private DateTime A796CotFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A779CotDObs ;
      private string AV51PedDObs ;
      private string AV62Logo_GXI ;
      private string AV41Logo ;
      private string Logo ;
      private IGxSession AV42Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CliCod ;
      private string aP1_ProdCod ;
      private int aP2_MonCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private string aP5_PedSts ;
      private int aP6_VenCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00E22_A45CliCod ;
      private string[] P00E22_A161CliDsc ;
      private int[] P00E23_A180MonCod ;
      private string[] P00E23_A1234MonDsc ;
      private string[] P00E24_A807CotSts ;
      private DateTime[] P00E24_A796CotFec ;
      private string[] P00E24_A177CotCod ;
      private int[] P00E24_A179CotVendCod ;
      private int[] P00E24_A180MonCod ;
      private string[] P00E24_A45CliCod ;
      private string[] P00E24_A161CliDsc ;
      private string[] P00E24_A1234MonDsc ;
      private int[] P00E25_A49UniCod ;
      private string[] P00E25_A177CotCod ;
      private string[] P00E25_A28ProdCod ;
      private decimal[] P00E25_A770CotDCan ;
      private decimal[] P00E25_A771CotDPre ;
      private decimal[] P00E25_A772CotDDsct1 ;
      private decimal[] P00E25_A768CotDTot ;
      private string[] P00E25_A779CotDObs ;
      private string[] P00E25_A55ProdDsc ;
      private string[] P00E25_A1997UniAbr ;
      private short[] P00E25_A183CotDItem ;
   }

   public class r_cotizacionespdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E24( IGxContext context ,
                                             string AV10CliCod ,
                                             int AV14MonCod ,
                                             string AV43PedSts ,
                                             int AV59VenCod ,
                                             string A45CliCod ,
                                             int A180MonCod ,
                                             string A807CotSts ,
                                             int A179CotVendCod ,
                                             DateTime A796CotFec ,
                                             DateTime AV30FDesde ,
                                             DateTime AV31FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CotSts], T1.[CotFec], T1.[CotCod], T1.[CotVendCod], T1.[MonCod], T1.[CliCod], T3.[CliDsc], T2.[MonDsc] FROM (([CLCOTIZA] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[MonCod]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T1.[CliCod])";
         AddWhere(sWhereString, "(T1.[CotFec] >= @AV30FDesde and T1.[CotFec] <= @AV31FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV10CliCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! ( StringUtil.StrCmp(AV43PedSts, "TT") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CotSts] = @AV43PedSts)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV59VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CotVendCod] = @AV59VenCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CliCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00E25( IGxContext context ,
                                             string AV55ProdCod ,
                                             string A28ProdCod ,
                                             string A177CotCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T1.[CotCod], T1.[ProdCod], T1.[CotDCan], T1.[CotDPre], T1.[CotDDsct1], T1.[CotDTot], T1.[CotDObs], T2.[ProdDsc], T3.[UniAbr], T1.[CotDItem] FROM (([CLCOTIZADET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod])";
         AddWhere(sWhereString, "(T1.[CotCod] = @CotCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV55ProdCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CotCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P00E24(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] );
               case 3 :
                     return conditional_P00E25(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
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
          Object[] prmP00E22;
          prmP00E22 = new Object[] {
          new ParDef("@AV10CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00E23;
          prmP00E23 = new Object[] {
          new ParDef("@AV14MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00E24;
          prmP00E24 = new Object[] {
          new ParDef("@AV30FDesde",GXType.Date,8,0) ,
          new ParDef("@AV31FHasta",GXType.Date,8,0) ,
          new ParDef("@AV10CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV43PedSts",GXType.NChar,1,0) ,
          new ParDef("@AV59VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00E25;
          prmP00E25 = new Object[] {
          new ParDef("@CotCod",GXType.NChar,10,0) ,
          new ParDef("@AV55ProdCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00E22", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV10CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E22,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E23", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV14MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E23,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E24", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E24,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E25", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E25,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((string[]) buf[9])[0] = rslt.getString(10, 5);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                return;
       }
    }

 }

}
