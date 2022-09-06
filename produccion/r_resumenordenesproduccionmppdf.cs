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
   public class r_resumenordenesproduccionmppdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.r_resumenordenesproduccionmppdf.aspx")), "produccion.r_resumenordenesproduccionmppdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.r_resumenordenesproduccionmppdf.aspx")))) ;
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
               AV30FDesde = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV31FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV45ProdCod = GetPar( "ProdCod");
                  AV48OrdCod = GetPar( "OrdCod");
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

      public r_resumenordenesproduccionmppdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenordenesproduccionmppdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FDesde ,
                           ref DateTime aP1_FHasta ,
                           ref string aP2_ProdCod ,
                           ref string aP3_OrdCod )
      {
         this.AV30FDesde = aP0_FDesde;
         this.AV31FHasta = aP1_FHasta;
         this.AV45ProdCod = aP2_ProdCod;
         this.AV48OrdCod = aP3_OrdCod;
         initialize();
         executePrivate();
         aP0_FDesde=this.AV30FDesde;
         aP1_FHasta=this.AV31FHasta;
         aP2_ProdCod=this.AV45ProdCod;
         aP3_OrdCod=this.AV48OrdCod;
      }

      public string executeUdp( ref DateTime aP0_FDesde ,
                                ref DateTime aP1_FHasta ,
                                ref string aP2_ProdCod )
      {
         execute(ref aP0_FDesde, ref aP1_FHasta, ref aP2_ProdCod, ref aP3_OrdCod);
         return AV48OrdCod ;
      }

      public void executeSubmit( ref DateTime aP0_FDesde ,
                                 ref DateTime aP1_FHasta ,
                                 ref string aP2_ProdCod ,
                                 ref string aP3_OrdCod )
      {
         r_resumenordenesproduccionmppdf objr_resumenordenesproduccionmppdf;
         objr_resumenordenesproduccionmppdf = new r_resumenordenesproduccionmppdf();
         objr_resumenordenesproduccionmppdf.AV30FDesde = aP0_FDesde;
         objr_resumenordenesproduccionmppdf.AV31FHasta = aP1_FHasta;
         objr_resumenordenesproduccionmppdf.AV45ProdCod = aP2_ProdCod;
         objr_resumenordenesproduccionmppdf.AV48OrdCod = aP3_OrdCod;
         objr_resumenordenesproduccionmppdf.context.SetSubmitInitialConfig(context);
         objr_resumenordenesproduccionmppdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenordenesproduccionmppdf);
         aP0_FDesde=this.AV30FDesde;
         aP1_FHasta=this.AV31FHasta;
         aP2_ProdCod=this.AV45ProdCod;
         aP3_OrdCod=this.AV48OrdCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenordenesproduccionmppdf)stateInfo).executePrivate();
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
            AV54Logo_GXI = GXDbFile.PathToUrl( AV41Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV24Filtro3 = "Todos";
            AV25Filtro4 = AV30FDesde;
            AV26Filtro5 = AV31FHasta;
            AV24Filtro3 = ((AV32Opcion==1) ? "Pendientes" : "Todos");
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV48OrdCod ,
                                                 AV45ProdCod ,
                                                 A325ProFec ,
                                                 AV30FDesde ,
                                                 AV31FHasta ,
                                                 A323ProProdCod ,
                                                 A322ProCod } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00FK2 */
            pr_default.execute(0, new Object[] {AV30FDesde, AV31FHasta, AV45ProdCod, AV48OrdCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A49UniCod = P00FK2_A49UniCod[0];
               n49UniCod = P00FK2_n49UniCod[0];
               A1997UniAbr = P00FK2_A1997UniAbr[0];
               A322ProCod = P00FK2_A322ProCod[0];
               A323ProProdCod = P00FK2_A323ProProdCod[0];
               A325ProFec = P00FK2_A325ProFec[0];
               A1655ProCantProdIng = P00FK2_A1655ProCantProdIng[0];
               A1654ProCantProd = P00FK2_A1654ProCantProd[0];
               A1738ProProdDsc = P00FK2_A1738ProProdDsc[0];
               A49UniCod = P00FK2_A49UniCod[0];
               n49UniCod = P00FK2_n49UniCod[0];
               A1738ProProdDsc = P00FK2_A1738ProProdDsc[0];
               A1997UniAbr = P00FK2_A1997UniAbr[0];
               AV49ProCod = A322ProCod;
               AV50ProDCantFormula = 0.00m;
               AV51ProDCantIng = 0.00m;
               AV34PedDCan = 0.00m;
               AV35PedDCanDsp = 0.00m;
               AV36PedDCanFac = 0.00m;
               HFK0( false, 27) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A322ProCod, "")), 8, Gx_line+3, 61, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A325ProFec, "99/99/99"), 79, Gx_line+3, 126, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A323ProProdCod, "@!")), 144, Gx_line+3, 223, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1738ProProdDsc, "")), 232, Gx_line+3, 573, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(8, Gx_line+23, 777, Gx_line+23, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1654ProCantProd, "ZZZZ,ZZZ,ZZ9.9999")), 514, Gx_line+3, 621, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1655ProCantProdIng, "ZZZZ,ZZZ,ZZ9.9999")), 594, Gx_line+3, 701, Gx_line+18, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+27);
               /* Using cursor P00FK3 */
               pr_default.execute(1, new Object[] {AV49ProCod});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A1680ProDConcepto = P00FK3_A1680ProDConcepto[0];
                  A322ProCod = P00FK3_A322ProCod[0];
                  A1677ProDCantFormula = P00FK3_A1677ProDCantFormula[0];
                  A1678ProDCantIng = P00FK3_A1678ProDCantIng[0];
                  A1656ProCosto = P00FK3_A1656ProCosto[0];
                  A1704ProDProdDsc = P00FK3_A1704ProDProdDsc[0];
                  A327ProDProdCod = P00FK3_A327ProDProdCod[0];
                  n327ProDProdCod = P00FK3_n327ProDProdCod[0];
                  A326ProDItem = P00FK3_A326ProDItem[0];
                  A1704ProDProdDsc = P00FK3_A1704ProDProdDsc[0];
                  AV50ProDCantFormula = A1677ProDCantFormula;
                  AV51ProDCantIng = A1678ProDCantIng;
                  AV34PedDCan = (decimal)(AV34PedDCan+A1677ProDCantFormula);
                  AV35PedDCanDsp = (decimal)(AV35PedDCanDsp+A1678ProDCantIng);
                  AV36PedDCanFac = (decimal)(AV36PedDCanFac+A1656ProCosto);
                  HFK0( false, 20) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A327ProDProdCod, "@!")), 8, Gx_line+2, 87, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1704ProDProdDsc, "")), 84, Gx_line+2, 482, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1656ProCosto, "ZZZZZZ,ZZZ,ZZ9.99")), 681, Gx_line+2, 788, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51ProDCantIng, "ZZZZ,ZZZ,ZZ9.9999")), 594, Gx_line+2, 701, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50ProDCantFormula, "ZZZZ,ZZZ,ZZ9.9999")), 514, Gx_line+2, 621, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 485, Gx_line+1, 529, Gx_line+16, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               HFK0( false, 38) ;
               getPrinter().GxDrawLine(466, Gx_line+2, 788, Gx_line+2, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Orden", 369, Gx_line+5, 439, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36PedDCanFac, "ZZZZZZ,ZZZ,ZZ9.99")), 682, Gx_line+6, 787, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35PedDCanDsp, "ZZZZ,ZZZ,ZZ9.9999")), 595, Gx_line+6, 700, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34PedDCan, "ZZZZ,ZZZ,ZZ9.9999")), 523, Gx_line+6, 620, Gx_line+21, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+38);
               /* Execute user subroutine: 'ENTRADAS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'SALIDAS' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'REINGRESO' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               /* Eject command */
               Gx_OldLine = Gx_line;
               Gx_line = (int)(P_lines+1);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HFK0( true, 0) ;
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
         /* 'ENTRADAS' Routine */
         returnInSub = false;
         HFK0( false, 43) ;
         getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 336, Gx_line+24, 377, Gx_line+38, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("Producto", 420, Gx_line+25, 474, Gx_line+39, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("Cantidad", 709, Gx_line+25, 762, Gx_line+39, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawRect(0, Gx_line+20, 797, Gx_line+43, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Entradas de Almacen", 332, Gx_line+2, 457, Gx_line+16, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("N. Entrada", 13, Gx_line+25, 73, Gx_line+39, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("Fecha", 100, Gx_line+25, 135, Gx_line+39, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("Almacen", 186, Gx_line+25, 238, Gx_line+39, 0+256, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+43);
         /* Using cursor P00FK4 */
         pr_default.execute(2, new Object[] {AV49ProCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A21MvAlm = P00FK4_A21MvAlm[0];
            A1276MvAOcom = P00FK4_A1276MvAOcom[0];
            A1286MvATMov = P00FK4_A1286MvATMov[0];
            A13MvATip = P00FK4_A13MvATip[0];
            A1370MVSts = P00FK4_A1370MVSts[0];
            A1248MvADCant = P00FK4_A1248MvADCant[0];
            A55ProdDsc = P00FK4_A55ProdDsc[0];
            A28ProdCod = P00FK4_A28ProdCod[0];
            A1271MvAlmDsc = P00FK4_A1271MvAlmDsc[0];
            A14MvACod = P00FK4_A14MvACod[0];
            A25MvAFec = P00FK4_A25MvAFec[0];
            A30MvADItem = P00FK4_A30MvADItem[0];
            A55ProdDsc = P00FK4_A55ProdDsc[0];
            A21MvAlm = P00FK4_A21MvAlm[0];
            A1276MvAOcom = P00FK4_A1276MvAOcom[0];
            A1286MvATMov = P00FK4_A1286MvATMov[0];
            A1370MVSts = P00FK4_A1370MVSts[0];
            A25MvAFec = P00FK4_A25MvAFec[0];
            A1271MvAlmDsc = P00FK4_A1271MvAlmDsc[0];
            HFK0( false, 15) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 13, Gx_line+0, 77, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 96, Gx_line+0, 143, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1271MvAlmDsc, "")), 156, Gx_line+0, 328, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 335, Gx_line+0, 423, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 429, Gx_line+0, 667, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1248MvADCant, "ZZZZ,ZZZ,ZZ9.9999")), 682, Gx_line+0, 789, Gx_line+15, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+15);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S121( )
      {
         /* 'SALIDAS' Routine */
         returnInSub = false;
         HFK0( false, 41) ;
         getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 336, Gx_line+22, 377, Gx_line+36, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("Producto", 420, Gx_line+23, 474, Gx_line+37, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("Cantidad", 709, Gx_line+23, 762, Gx_line+37, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawRect(0, Gx_line+18, 797, Gx_line+41, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Salidas de Almacen", 332, Gx_line+0, 447, Gx_line+14, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("N. Salida", 13, Gx_line+23, 63, Gx_line+37, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("Fecha", 100, Gx_line+23, 135, Gx_line+37, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("Almacen", 186, Gx_line+23, 238, Gx_line+37, 0+256, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+41);
         /* Using cursor P00FK5 */
         pr_default.execute(3, new Object[] {AV49ProCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A21MvAlm = P00FK5_A21MvAlm[0];
            A1276MvAOcom = P00FK5_A1276MvAOcom[0];
            A1286MvATMov = P00FK5_A1286MvATMov[0];
            A13MvATip = P00FK5_A13MvATip[0];
            A1370MVSts = P00FK5_A1370MVSts[0];
            A1248MvADCant = P00FK5_A1248MvADCant[0];
            A55ProdDsc = P00FK5_A55ProdDsc[0];
            A28ProdCod = P00FK5_A28ProdCod[0];
            A1271MvAlmDsc = P00FK5_A1271MvAlmDsc[0];
            A14MvACod = P00FK5_A14MvACod[0];
            A25MvAFec = P00FK5_A25MvAFec[0];
            A30MvADItem = P00FK5_A30MvADItem[0];
            A55ProdDsc = P00FK5_A55ProdDsc[0];
            A21MvAlm = P00FK5_A21MvAlm[0];
            A1276MvAOcom = P00FK5_A1276MvAOcom[0];
            A1286MvATMov = P00FK5_A1286MvATMov[0];
            A1370MVSts = P00FK5_A1370MVSts[0];
            A25MvAFec = P00FK5_A25MvAFec[0];
            A1271MvAlmDsc = P00FK5_A1271MvAlmDsc[0];
            HFK0( false, 15) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 14, Gx_line+0, 78, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 97, Gx_line+0, 144, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1271MvAlmDsc, "")), 157, Gx_line+0, 329, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 336, Gx_line+0, 424, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 430, Gx_line+0, 668, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1248MvADCant, "ZZZZ,ZZZ,ZZ9.9999")), 683, Gx_line+0, 790, Gx_line+15, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+15);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S131( )
      {
         /* 'REINGRESO' Routine */
         returnInSub = false;
         HFK0( false, 41) ;
         getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Almacen", 186, Gx_line+23, 238, Gx_line+37, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("Fecha", 100, Gx_line+23, 135, Gx_line+37, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("N. Entrada", 12, Gx_line+23, 72, Gx_line+37, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("Reingreso de Almacen", 332, Gx_line+3, 464, Gx_line+17, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawRect(0, Gx_line+18, 797, Gx_line+41, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Cantidad", 709, Gx_line+23, 762, Gx_line+37, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("Producto", 420, Gx_line+23, 474, Gx_line+37, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo", 336, Gx_line+22, 377, Gx_line+36, 0+256, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+41);
         /* Using cursor P00FK6 */
         pr_default.execute(4, new Object[] {AV49ProCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A21MvAlm = P00FK6_A21MvAlm[0];
            A1276MvAOcom = P00FK6_A1276MvAOcom[0];
            A1286MvATMov = P00FK6_A1286MvATMov[0];
            A13MvATip = P00FK6_A13MvATip[0];
            A1370MVSts = P00FK6_A1370MVSts[0];
            A1271MvAlmDsc = P00FK6_A1271MvAlmDsc[0];
            A14MvACod = P00FK6_A14MvACod[0];
            A55ProdDsc = P00FK6_A55ProdDsc[0];
            A28ProdCod = P00FK6_A28ProdCod[0];
            A1248MvADCant = P00FK6_A1248MvADCant[0];
            A25MvAFec = P00FK6_A25MvAFec[0];
            A30MvADItem = P00FK6_A30MvADItem[0];
            A21MvAlm = P00FK6_A21MvAlm[0];
            A1276MvAOcom = P00FK6_A1276MvAOcom[0];
            A1286MvATMov = P00FK6_A1286MvATMov[0];
            A1370MVSts = P00FK6_A1370MVSts[0];
            A25MvAFec = P00FK6_A25MvAFec[0];
            A1271MvAlmDsc = P00FK6_A1271MvAlmDsc[0];
            A55ProdDsc = P00FK6_A55ProdDsc[0];
            HFK0( false, 17) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1248MvADCant, "ZZZZ,ZZZ,ZZ9.9999")), 682, Gx_line+0, 789, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 335, Gx_line+0, 423, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 429, Gx_line+0, 667, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 12, Gx_line+0, 76, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 96, Gx_line+0, 143, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1271MvAlmDsc, "")), 156, Gx_line+0, 328, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+17);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void HFK0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 664, Gx_line+45, 696, Gx_line+59, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 664, Gx_line+63, 708, Gx_line+77, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 664, Gx_line+27, 703, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 731, Gx_line+63, 770, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 708, Gx_line+45, 768, Gx_line+59, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 723, Gx_line+27, 770, Gx_line+42, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 13, Gx_line+175, 54, Gx_line+189, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 104, Gx_line+175, 158, Gx_line+189, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Unidad", 486, Gx_line+175, 528, Gx_line+189, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Detalle de Ordenes de Producción", 259, Gx_line+76, 546, Gx_line+96, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Costo MN", 718, Gx_line+175, 773, Gx_line+189, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Salida", 659, Gx_line+175, 695, Gx_line+189, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 180, Gx_line+105, 217, Gx_line+119, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta", 180, Gx_line+126, 215, Gx_line+140, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV25Filtro4, "99/99/99"), 247, Gx_line+100, 590, Gx_line+124, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV26Filtro5, "99/99/99"), 247, Gx_line+121, 590, Gx_line+145, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Formulada", 557, Gx_line+175, 621, Gx_line+189, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(548, Gx_line+173, 789, Gx_line+173, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidades", 636, Gx_line+155, 703, Gx_line+169, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV42Logo)) ? AV54Logo_GXI : AV42Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 11, Gx_line+2, 166, Gx_line+78) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38Empresa, "")), 11, Gx_line+73, 240, Gx_line+91, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40EmpRUC, "")), 11, Gx_line+91, 185, Gx_line+109, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+154, 797, Gx_line+193, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+193);
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
         AV54Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         AV25Filtro4 = DateTime.MinValue;
         AV26Filtro5 = DateTime.MinValue;
         scmdbuf = "";
         A325ProFec = DateTime.MinValue;
         A323ProProdCod = "";
         A322ProCod = "";
         P00FK2_A49UniCod = new int[1] ;
         P00FK2_n49UniCod = new bool[] {false} ;
         P00FK2_A1997UniAbr = new string[] {""} ;
         P00FK2_A322ProCod = new string[] {""} ;
         P00FK2_A323ProProdCod = new string[] {""} ;
         P00FK2_A325ProFec = new DateTime[] {DateTime.MinValue} ;
         P00FK2_A1655ProCantProdIng = new decimal[1] ;
         P00FK2_A1654ProCantProd = new decimal[1] ;
         P00FK2_A1738ProProdDsc = new string[] {""} ;
         A1997UniAbr = "";
         A1738ProProdDsc = "";
         AV49ProCod = "";
         P00FK3_A1680ProDConcepto = new string[] {""} ;
         P00FK3_A322ProCod = new string[] {""} ;
         P00FK3_A1677ProDCantFormula = new decimal[1] ;
         P00FK3_A1678ProDCantIng = new decimal[1] ;
         P00FK3_A1656ProCosto = new decimal[1] ;
         P00FK3_A1704ProDProdDsc = new string[] {""} ;
         P00FK3_A327ProDProdCod = new string[] {""} ;
         P00FK3_n327ProDProdCod = new bool[] {false} ;
         P00FK3_A326ProDItem = new int[1] ;
         A1680ProDConcepto = "";
         A1704ProDProdDsc = "";
         A327ProDProdCod = "";
         P00FK4_A21MvAlm = new int[1] ;
         P00FK4_A1276MvAOcom = new string[] {""} ;
         P00FK4_A1286MvATMov = new short[1] ;
         P00FK4_A13MvATip = new string[] {""} ;
         P00FK4_A1370MVSts = new string[] {""} ;
         P00FK4_A1248MvADCant = new decimal[1] ;
         P00FK4_A55ProdDsc = new string[] {""} ;
         P00FK4_A28ProdCod = new string[] {""} ;
         P00FK4_A1271MvAlmDsc = new string[] {""} ;
         P00FK4_A14MvACod = new string[] {""} ;
         P00FK4_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FK4_A30MvADItem = new int[1] ;
         A1276MvAOcom = "";
         A13MvATip = "";
         A1370MVSts = "";
         A55ProdDsc = "";
         A28ProdCod = "";
         A1271MvAlmDsc = "";
         A14MvACod = "";
         A25MvAFec = DateTime.MinValue;
         P00FK5_A21MvAlm = new int[1] ;
         P00FK5_A1276MvAOcom = new string[] {""} ;
         P00FK5_A1286MvATMov = new short[1] ;
         P00FK5_A13MvATip = new string[] {""} ;
         P00FK5_A1370MVSts = new string[] {""} ;
         P00FK5_A1248MvADCant = new decimal[1] ;
         P00FK5_A55ProdDsc = new string[] {""} ;
         P00FK5_A28ProdCod = new string[] {""} ;
         P00FK5_A1271MvAlmDsc = new string[] {""} ;
         P00FK5_A14MvACod = new string[] {""} ;
         P00FK5_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FK5_A30MvADItem = new int[1] ;
         P00FK6_A21MvAlm = new int[1] ;
         P00FK6_A1276MvAOcom = new string[] {""} ;
         P00FK6_A1286MvATMov = new short[1] ;
         P00FK6_A13MvATip = new string[] {""} ;
         P00FK6_A1370MVSts = new string[] {""} ;
         P00FK6_A1271MvAlmDsc = new string[] {""} ;
         P00FK6_A14MvACod = new string[] {""} ;
         P00FK6_A55ProdDsc = new string[] {""} ;
         P00FK6_A28ProdCod = new string[] {""} ;
         P00FK6_A1248MvADCant = new decimal[1] ;
         P00FK6_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FK6_A30MvADItem = new int[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV42Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_resumenordenesproduccionmppdf__default(),
            new Object[][] {
                new Object[] {
               P00FK2_A49UniCod, P00FK2_n49UniCod, P00FK2_A1997UniAbr, P00FK2_A322ProCod, P00FK2_A323ProProdCod, P00FK2_A325ProFec, P00FK2_A1655ProCantProdIng, P00FK2_A1654ProCantProd, P00FK2_A1738ProProdDsc
               }
               , new Object[] {
               P00FK3_A1680ProDConcepto, P00FK3_A322ProCod, P00FK3_A1677ProDCantFormula, P00FK3_A1678ProDCantIng, P00FK3_A1656ProCosto, P00FK3_A1704ProDProdDsc, P00FK3_A327ProDProdCod, P00FK3_n327ProDProdCod, P00FK3_A326ProDItem
               }
               , new Object[] {
               P00FK4_A21MvAlm, P00FK4_A1276MvAOcom, P00FK4_A1286MvATMov, P00FK4_A13MvATip, P00FK4_A1370MVSts, P00FK4_A1248MvADCant, P00FK4_A55ProdDsc, P00FK4_A28ProdCod, P00FK4_A1271MvAlmDsc, P00FK4_A14MvACod,
               P00FK4_A25MvAFec, P00FK4_A30MvADItem
               }
               , new Object[] {
               P00FK5_A21MvAlm, P00FK5_A1276MvAOcom, P00FK5_A1286MvATMov, P00FK5_A13MvATip, P00FK5_A1370MVSts, P00FK5_A1248MvADCant, P00FK5_A55ProdDsc, P00FK5_A28ProdCod, P00FK5_A1271MvAlmDsc, P00FK5_A14MvACod,
               P00FK5_A25MvAFec, P00FK5_A30MvADItem
               }
               , new Object[] {
               P00FK6_A21MvAlm, P00FK6_A1276MvAOcom, P00FK6_A1286MvATMov, P00FK6_A13MvATip, P00FK6_A1370MVSts, P00FK6_A1271MvAlmDsc, P00FK6_A14MvACod, P00FK6_A55ProdDsc, P00FK6_A28ProdCod, P00FK6_A1248MvADCant,
               P00FK6_A25MvAFec, P00FK6_A30MvADItem
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
      private short A1286MvATMov ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A49UniCod ;
      private int Gx_OldLine ;
      private int A326ProDItem ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private decimal A1655ProCantProdIng ;
      private decimal A1654ProCantProd ;
      private decimal AV50ProDCantFormula ;
      private decimal AV51ProDCantIng ;
      private decimal AV34PedDCan ;
      private decimal AV35PedDCanDsp ;
      private decimal AV36PedDCanFac ;
      private decimal A1677ProDCantFormula ;
      private decimal A1678ProDCantIng ;
      private decimal A1656ProCosto ;
      private decimal A1248MvADCant ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV45ProdCod ;
      private string AV48OrdCod ;
      private string AV38Empresa ;
      private string AV39EmpDir ;
      private string AV40EmpRUC ;
      private string AV41Ruta ;
      private string AV22Filtro1 ;
      private string AV23Filtro2 ;
      private string AV24Filtro3 ;
      private string scmdbuf ;
      private string A323ProProdCod ;
      private string A322ProCod ;
      private string A1997UniAbr ;
      private string A1738ProProdDsc ;
      private string AV49ProCod ;
      private string A1680ProDConcepto ;
      private string A1704ProDProdDsc ;
      private string A327ProDProdCod ;
      private string A1276MvAOcom ;
      private string A13MvATip ;
      private string A1370MVSts ;
      private string A55ProdDsc ;
      private string A28ProdCod ;
      private string A1271MvAlmDsc ;
      private string A14MvACod ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV30FDesde ;
      private DateTime AV31FHasta ;
      private DateTime AV25Filtro4 ;
      private DateTime AV26Filtro5 ;
      private DateTime A325ProFec ;
      private DateTime A25MvAFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n49UniCod ;
      private bool n327ProDProdCod ;
      private bool returnInSub ;
      private string AV54Logo_GXI ;
      private string AV42Logo ;
      private string Logo ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FDesde ;
      private DateTime aP1_FHasta ;
      private string aP2_ProdCod ;
      private string aP3_OrdCod ;
      private IDataStoreProvider pr_default ;
      private int[] P00FK2_A49UniCod ;
      private bool[] P00FK2_n49UniCod ;
      private string[] P00FK2_A1997UniAbr ;
      private string[] P00FK2_A322ProCod ;
      private string[] P00FK2_A323ProProdCod ;
      private DateTime[] P00FK2_A325ProFec ;
      private decimal[] P00FK2_A1655ProCantProdIng ;
      private decimal[] P00FK2_A1654ProCantProd ;
      private string[] P00FK2_A1738ProProdDsc ;
      private string[] P00FK3_A1680ProDConcepto ;
      private string[] P00FK3_A322ProCod ;
      private decimal[] P00FK3_A1677ProDCantFormula ;
      private decimal[] P00FK3_A1678ProDCantIng ;
      private decimal[] P00FK3_A1656ProCosto ;
      private string[] P00FK3_A1704ProDProdDsc ;
      private string[] P00FK3_A327ProDProdCod ;
      private bool[] P00FK3_n327ProDProdCod ;
      private int[] P00FK3_A326ProDItem ;
      private int[] P00FK4_A21MvAlm ;
      private string[] P00FK4_A1276MvAOcom ;
      private short[] P00FK4_A1286MvATMov ;
      private string[] P00FK4_A13MvATip ;
      private string[] P00FK4_A1370MVSts ;
      private decimal[] P00FK4_A1248MvADCant ;
      private string[] P00FK4_A55ProdDsc ;
      private string[] P00FK4_A28ProdCod ;
      private string[] P00FK4_A1271MvAlmDsc ;
      private string[] P00FK4_A14MvACod ;
      private DateTime[] P00FK4_A25MvAFec ;
      private int[] P00FK4_A30MvADItem ;
      private int[] P00FK5_A21MvAlm ;
      private string[] P00FK5_A1276MvAOcom ;
      private short[] P00FK5_A1286MvATMov ;
      private string[] P00FK5_A13MvATip ;
      private string[] P00FK5_A1370MVSts ;
      private decimal[] P00FK5_A1248MvADCant ;
      private string[] P00FK5_A55ProdDsc ;
      private string[] P00FK5_A28ProdCod ;
      private string[] P00FK5_A1271MvAlmDsc ;
      private string[] P00FK5_A14MvACod ;
      private DateTime[] P00FK5_A25MvAFec ;
      private int[] P00FK5_A30MvADItem ;
      private int[] P00FK6_A21MvAlm ;
      private string[] P00FK6_A1276MvAOcom ;
      private short[] P00FK6_A1286MvATMov ;
      private string[] P00FK6_A13MvATip ;
      private string[] P00FK6_A1370MVSts ;
      private string[] P00FK6_A1271MvAlmDsc ;
      private string[] P00FK6_A14MvACod ;
      private string[] P00FK6_A55ProdDsc ;
      private string[] P00FK6_A28ProdCod ;
      private decimal[] P00FK6_A1248MvADCant ;
      private DateTime[] P00FK6_A25MvAFec ;
      private int[] P00FK6_A30MvADItem ;
   }

   public class r_resumenordenesproduccionmppdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FK2( IGxContext context ,
                                             string AV48OrdCod ,
                                             string AV45ProdCod ,
                                             DateTime A325ProFec ,
                                             DateTime AV30FDesde ,
                                             DateTime AV31FHasta ,
                                             string A323ProProdCod ,
                                             string A322ProCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T3.[UniAbr], T1.[ProCod], T1.[ProProdCod] AS ProProdCod, T1.[ProFec], T1.[ProCantProdIng], T1.[ProCantProd], T2.[ProdDsc] AS ProProdDsc FROM (([POORDENES] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProProdCod]) LEFT JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod])";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48OrdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProFec] >= @AV30FDesde)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48OrdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProFec] <= @AV31FHasta)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProProdCod] = @AV45ProdCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48OrdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProCod] = @AV48OrdCod)");
         }
         else
         {
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
               case 0 :
                     return conditional_P00FK2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
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
          Object[] prmP00FK3;
          prmP00FK3 = new Object[] {
          new ParDef("@AV49ProCod",GXType.NChar,10,0)
          };
          Object[] prmP00FK4;
          prmP00FK4 = new Object[] {
          new ParDef("@AV49ProCod",GXType.NChar,10,0)
          };
          Object[] prmP00FK5;
          prmP00FK5 = new Object[] {
          new ParDef("@AV49ProCod",GXType.NChar,10,0)
          };
          Object[] prmP00FK6;
          prmP00FK6 = new Object[] {
          new ParDef("@AV49ProCod",GXType.NChar,10,0)
          };
          Object[] prmP00FK2;
          prmP00FK2 = new Object[] {
          new ParDef("@AV30FDesde",GXType.Date,8,0) ,
          new ParDef("@AV31FHasta",GXType.Date,8,0) ,
          new ParDef("@AV45ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV48OrdCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FK2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FK2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FK3", "SELECT T1.[ProDConcepto], T1.[ProCod], T1.[ProDCantFormula], T1.[ProDCantIng], T1.[ProCosto], T2.[ProdDsc] AS ProDProdDsc, T1.[ProDProdCod] AS ProDProdCod, T1.[ProDItem] FROM ([POORDENESDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProDProdCod]) WHERE (T1.[ProCod] = @AV49ProCod) AND ((T1.[ProDConcepto] = '')) ORDER BY T1.[ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FK3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FK4", "SELECT T3.[MvAlm] AS MvAlm, T3.[MvAOcom], T3.[MvATMov], T1.[MvATip], T3.[MVSts], T1.[MvADCant], T2.[ProdDsc], T1.[ProdCod], T4.[AlmDsc] AS MvAlmDsc, T1.[MvACod], T3.[MvAFec], T1.[MvADItem] FROM ((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [AGUIAS] T3 ON T3.[MvATip] = T1.[MvATip] AND T3.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T3.[MvAlm]) WHERE (T3.[MVSts] <> 'A') AND (T3.[MvAOcom] = @AV49ProCod) AND (T3.[MvATMov] = 2) AND (T1.[MvATip] = 'ING') ORDER BY T3.[MvAFec] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FK4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FK5", "SELECT T3.[MvAlm] AS MvAlm, T3.[MvAOcom], T3.[MvATMov], T1.[MvATip], T3.[MVSts], T1.[MvADCant], T2.[ProdDsc], T1.[ProdCod], T4.[AlmDsc] AS MvAlmDsc, T1.[MvACod], T3.[MvAFec], T1.[MvADItem] FROM ((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [AGUIAS] T3 ON T3.[MvATip] = T1.[MvATip] AND T3.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T3.[MvAlm]) WHERE (T3.[MVSts] <> 'A') AND (T1.[MvATip] <> 'ING') AND (T3.[MvAOcom] = @AV49ProCod) AND (T3.[MvATMov] = 2) ORDER BY T3.[MvAFec] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FK5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FK6", "SELECT T2.[MvAlm] AS MvAlm, T2.[MvAOcom], T2.[MvATMov], T1.[MvATip], T2.[MVSts], T3.[AlmDsc] AS MvAlmDsc, T1.[MvACod], T4.[ProdDsc], T1.[ProdCod], T1.[MvADCant], T2.[MvAFec], T1.[MvADItem] FROM ((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) WHERE (T2.[MVSts] <> 'A') AND (T2.[MvAOcom] = @AV49ProCod) AND (T2.[MvATMov] = 3) AND (T1.[MvATip] = 'ING') ORDER BY T2.[MvAFec] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FK6,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 5);
                ((string[]) buf[3])[0] = rslt.getString(3, 10);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 15);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((string[]) buf[9])[0] = rslt.getString(10, 12);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((int[]) buf[11])[0] = rslt.getInt(12);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 15);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((string[]) buf[9])[0] = rslt.getString(10, 12);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((int[]) buf[11])[0] = rslt.getInt(12);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 12);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 15);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((int[]) buf[11])[0] = rslt.getInt(12);
                return;
       }
    }

 }

}
