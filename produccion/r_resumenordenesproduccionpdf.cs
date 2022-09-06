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
   public class r_resumenordenesproduccionpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.r_resumenordenesproduccionpdf.aspx")), "produccion.r_resumenordenesproduccionpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.r_resumenordenesproduccionpdf.aspx")))) ;
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
               AV45ProdCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV27FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV29FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV47ProSts = GetPar( "ProSts");
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

      public r_resumenordenesproduccionpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenordenesproduccionpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProdCod ,
                           ref DateTime aP1_FDesde ,
                           ref DateTime aP2_FHasta ,
                           ref string aP3_ProSts )
      {
         this.AV45ProdCod = aP0_ProdCod;
         this.AV27FDesde = aP1_FDesde;
         this.AV29FHasta = aP2_FHasta;
         this.AV47ProSts = aP3_ProSts;
         initialize();
         executePrivate();
         aP0_ProdCod=this.AV45ProdCod;
         aP1_FDesde=this.AV27FDesde;
         aP2_FHasta=this.AV29FHasta;
         aP3_ProSts=this.AV47ProSts;
      }

      public string executeUdp( ref string aP0_ProdCod ,
                                ref DateTime aP1_FDesde ,
                                ref DateTime aP2_FHasta )
      {
         execute(ref aP0_ProdCod, ref aP1_FDesde, ref aP2_FHasta, ref aP3_ProSts);
         return AV47ProSts ;
      }

      public void executeSubmit( ref string aP0_ProdCod ,
                                 ref DateTime aP1_FDesde ,
                                 ref DateTime aP2_FHasta ,
                                 ref string aP3_ProSts )
      {
         r_resumenordenesproduccionpdf objr_resumenordenesproduccionpdf;
         objr_resumenordenesproduccionpdf = new r_resumenordenesproduccionpdf();
         objr_resumenordenesproduccionpdf.AV45ProdCod = aP0_ProdCod;
         objr_resumenordenesproduccionpdf.AV27FDesde = aP1_FDesde;
         objr_resumenordenesproduccionpdf.AV29FHasta = aP2_FHasta;
         objr_resumenordenesproduccionpdf.AV47ProSts = aP3_ProSts;
         objr_resumenordenesproduccionpdf.context.SetSubmitInitialConfig(context);
         objr_resumenordenesproduccionpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenordenesproduccionpdf);
         aP0_ProdCod=this.AV45ProdCod;
         aP1_FDesde=this.AV27FDesde;
         aP2_FHasta=this.AV29FHasta;
         aP3_ProSts=this.AV47ProSts;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenordenesproduccionpdf)stateInfo).executePrivate();
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
            AV23Empresa = AV50Session.Get("Empresa");
            AV22EmpDir = AV50Session.Get("EmpDir");
            AV24EmpRUC = AV50Session.Get("EmpRUC");
            AV48Ruta = AV50Session.Get("RUTA") + "/Logo.jpg";
            AV35Logo = AV48Ruta;
            AV70Logo_GXI = GXDbFile.PathToUrl( AV48Ruta);
            AV30Filtro1 = "Todos";
            /* Using cursor P00FG2 */
            pr_default.execute(0, new Object[] {AV45ProdCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A28ProdCod = P00FG2_A28ProdCod[0];
               A55ProdDsc = P00FG2_A55ProdDsc[0];
               AV30Filtro1 = StringUtil.Trim( A55ProdDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV62TotalGeneral = 0.00m;
            AV52TCantidad1 = 0.0000m;
            AV53TCantidad2 = 0.0000m;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV45ProdCod ,
                                                 AV47ProSts ,
                                                 A323ProProdCod ,
                                                 A1740ProSts ,
                                                 A325ProFec ,
                                                 AV27FDesde ,
                                                 AV29FHasta } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00FG3 */
            pr_default.execute(1, new Object[] {AV27FDesde, AV29FHasta, AV45ProdCod, AV47ProSts});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A325ProFec = P00FG3_A325ProFec[0];
               A1740ProSts = P00FG3_A1740ProSts[0];
               A323ProProdCod = P00FG3_A323ProProdCod[0];
               A1654ProCantProd = P00FG3_A1654ProCantProd[0];
               A1655ProCantProdIng = P00FG3_A1655ProCantProdIng[0];
               A1739ProRef = P00FG3_A1739ProRef[0];
               A1738ProProdDsc = P00FG3_A1738ProProdDsc[0];
               A322ProCod = P00FG3_A322ProCod[0];
               A1738ProProdDsc = P00FG3_A1738ProProdDsc[0];
               AV43ProCantProd = A1654ProCantProd;
               AV44ProCantProdIng = A1655ProCantProdIng;
               AV25Estado = ((StringUtil.StrCmp(A1740ProSts, "T")==0) ? "TERMINADO" : "PENDIENTE");
               AV41Orden = A322ProCod;
               AV11CostoT = 0.00m;
               AV54TCosto = 0.00m;
               AV12CostoUnit = 0.0000m;
               /* Execute user subroutine: 'OBTIENECOSTOORDEN' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               AV11CostoT = AV54TCosto;
               AV12CostoUnit = ((AV44ProCantProdIng==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( AV54TCosto/ (decimal)(AV44ProCantProdIng), 4));
               HFG0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1738ProProdDsc, "")), 334, Gx_line+2, 658, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV11CostoT, "ZZZZZZ,ZZZ,ZZ9.99")), 908, Gx_line+1, 1015, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A322ProCod, "")), 8, Gx_line+1, 72, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A325ProFec, "99/99/99"), 82, Gx_line+1, 129, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1739ProRef, "")), 141, Gx_line+1, 241, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A323ProProdCod, "@!")), 247, Gx_line+1, 326, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1655ProCantProdIng, "ZZZZ,ZZZ,ZZ9.9999")), 728, Gx_line+1, 835, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1654ProCantProd, "ZZZZ,ZZZ,ZZ9.9999")), 621, Gx_line+1, 728, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV12CostoUnit, "ZZZZ,ZZZ,ZZ9.9999")), 821, Gx_line+1, 928, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Estado, "")), 1039, Gx_line+2, 1092, Gx_line+17, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV62TotalGeneral = (decimal)(AV62TotalGeneral+AV11CostoT);
               AV52TCantidad1 = (decimal)(AV52TCantidad1+AV43ProCantProd);
               AV53TCantidad2 = (decimal)(AV53TCantidad2+AV44ProCantProdIng);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            HFG0( false, 65) ;
            getPrinter().GxDrawLine(636, Gx_line+9, 1024, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 530, Gx_line+15, 610, Gx_line+29, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62TotalGeneral, "ZZZZZZZZZ,ZZ9.99")), 915, Gx_line+14, 1016, Gx_line+29, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TCantidad1, "ZZZZ,ZZZ,ZZ9.9999")), 621, Gx_line+16, 728, Gx_line+31, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TCantidad2, "ZZZZ,ZZZ,ZZ9.9999")), 728, Gx_line+16, 835, Gx_line+31, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+65);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HFG0( true, 0) ;
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
         /* 'OBTIENECOSTOORDEN' Routine */
         returnInSub = false;
         AV10Costo = 0.00m;
         AV54TCosto = 0.00m;
         AV59TManoObra = 0.00m;
         AV60TMaquina = 0.00m;
         AV67TVarios = 0.00m;
         /* Using cursor P00FG4 */
         pr_default.execute(2, new Object[] {AV41Orden});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A1680ProDConcepto = P00FG4_A1680ProDConcepto[0];
            A322ProCod = P00FG4_A322ProCod[0];
            A327ProDProdCod = P00FG4_A327ProDProdCod[0];
            n327ProDProdCod = P00FG4_n327ProDProdCod[0];
            A326ProDItem = P00FG4_A326ProDItem[0];
            AV46ProDProdCod = A327ProDProdCod;
            AV10Costo = 0.00m;
            /* Execute user subroutine: 'OBTIENECOSTOALMACEN' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            AV54TCosto = (decimal)(AV54TCosto+AV10Costo);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Optimized group. */
         /* Using cursor P00FG5 */
         pr_default.execute(3, new Object[] {AV41Orden});
         c1656ProCosto = P00FG5_A1656ProCosto[0];
         pr_default.close(3);
         AV54TCosto = (decimal)(AV54TCosto+c1656ProCosto);
         /* End optimized group. */
         /* Using cursor P00FG6 */
         pr_default.execute(4, new Object[] {AV41Orden});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A322ProCod = P00FG6_A322ProCod[0];
            A1455OrdOpeCosto = P00FG6_A1455OrdOpeCosto[0];
            A1457OrdOpeHora = P00FG6_A1457OrdOpeHora[0];
            A321OPECod = P00FG6_A321OPECod[0];
            A1456OrdOpeCostoTotal = NumberUtil.Round( A1457OrdOpeHora*A1455OrdOpeCosto, 2);
            AV59TManoObra = (decimal)(AV59TManoObra+A1456OrdOpeCostoTotal);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Using cursor P00FG7 */
         pr_default.execute(5, new Object[] {AV41Orden});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A322ProCod = P00FG7_A322ProCod[0];
            A1727ProMaqCosto = P00FG7_A1727ProMaqCosto[0];
            A1729ProMaqHora = P00FG7_A1729ProMaqHora[0];
            A320MAQCod = P00FG7_A320MAQCod[0];
            A1728ProMaqCostoTotal = NumberUtil.Round( A1729ProMaqHora*A1727ProMaqCosto, 2);
            AV60TMaquina = (decimal)(AV60TMaquina+A1728ProMaqCostoTotal);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Optimized group. */
         /* Using cursor P00FG8 */
         pr_default.execute(6, new Object[] {AV41Orden});
         c1726ProGasCosto = P00FG8_A1726ProGasCosto[0];
         pr_default.close(6);
         AV67TVarios = (decimal)(AV67TVarios+c1726ProGasCosto);
         /* End optimized group. */
         AV54TCosto = (decimal)(AV54TCosto+(AV59TManoObra+AV60TMaquina+AV67TVarios));
      }

      protected void S125( )
      {
         /* 'OBTIENECOSTOALMACEN' Routine */
         returnInSub = false;
         /* Using cursor P00FG9 */
         pr_default.execute(7, new Object[] {AV46ProDProdCod, AV41Orden});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A14MvACod = P00FG9_A14MvACod[0];
            A1370MVSts = P00FG9_A1370MVSts[0];
            A13MvATip = P00FG9_A13MvATip[0];
            A1276MvAOcom = P00FG9_A1276MvAOcom[0];
            A1286MvATMov = P00FG9_A1286MvATMov[0];
            A28ProdCod = P00FG9_A28ProdCod[0];
            A1248MvADCant = P00FG9_A1248MvADCant[0];
            A1250MVADPrecio = P00FG9_A1250MVADPrecio[0];
            A30MvADItem = P00FG9_A30MvADItem[0];
            A1370MVSts = P00FG9_A1370MVSts[0];
            A1276MvAOcom = P00FG9_A1276MvAOcom[0];
            A1286MvATMov = P00FG9_A1286MvATMov[0];
            AV39MvADCant = A1248MvADCant;
            AV40MVADPrecio = A1250MVADPrecio;
            AV10Costo = (decimal)(AV10Costo+(NumberUtil.Round( AV39MvADCant*AV40MVADPrecio, 2)));
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void HFG0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 981, Gx_line+40, 1013, Gx_line+54, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 981, Gx_line+59, 1025, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 981, Gx_line+21, 1020, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Ordenes de Producción", 393, Gx_line+67, 725, Gx_line+86, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Producto", 368, Gx_line+94, 422, Gx_line+108, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Filtro1, "")), 427, Gx_line+89, 770, Gx_line+113, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+150, 1106, Gx_line+176, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1030, Gx_line+21, 1077, Gx_line+36, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1016, Gx_line+40, 1076, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1039, Gx_line+59, 1078, Gx_line+74, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Orden", 15, Gx_line+156, 68, Gx_line+170, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cant Ingresada", 744, Gx_line+158, 836, Gx_line+172, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 368, Gx_line+120, 405, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV27FDesde, "99/99/99"), 427, Gx_line+113, 501, Gx_line+137, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 545, Gx_line+120, 580, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV29FHasta, "99/99/99"), 596, Gx_line+113, 670, Gx_line+137, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 90, Gx_line+156, 125, Gx_line+170, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Codigo", 247, Gx_line+156, 288, Gx_line+170, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 334, Gx_line+157, 388, Gx_line+171, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cant Formula", 649, Gx_line+158, 728, Gx_line+172, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV35Logo)) ? AV70Logo_GXI : AV35Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+11, 167, Gx_line+89) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Empresa, "")), 9, Gx_line+93, 349, Gx_line+111, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24EmpRUC, "")), 9, Gx_line+110, 238, Gx_line+128, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Costo Unit.", 858, Gx_line+157, 923, Gx_line+171, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo Total", 948, Gx_line+157, 1016, Gx_line+171, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Estado", 1045, Gx_line+155, 1086, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Doc.Referencia", 141, Gx_line+156, 231, Gx_line+170, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+176);
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
         add_metrics3( ) ;
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

      protected void add_metrics3( )
      {
         getPrinter().setMetrics("Verdana", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
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
         AV23Empresa = "";
         AV50Session = context.GetSession();
         AV22EmpDir = "";
         AV24EmpRUC = "";
         AV48Ruta = "";
         AV35Logo = "";
         AV70Logo_GXI = "";
         AV30Filtro1 = "";
         scmdbuf = "";
         P00FG2_A28ProdCod = new string[] {""} ;
         P00FG2_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         A323ProProdCod = "";
         A1740ProSts = "";
         A325ProFec = DateTime.MinValue;
         P00FG3_A325ProFec = new DateTime[] {DateTime.MinValue} ;
         P00FG3_A1740ProSts = new string[] {""} ;
         P00FG3_A323ProProdCod = new string[] {""} ;
         P00FG3_A1654ProCantProd = new decimal[1] ;
         P00FG3_A1655ProCantProdIng = new decimal[1] ;
         P00FG3_A1739ProRef = new string[] {""} ;
         P00FG3_A1738ProProdDsc = new string[] {""} ;
         P00FG3_A322ProCod = new string[] {""} ;
         A1739ProRef = "";
         A1738ProProdDsc = "";
         A322ProCod = "";
         AV25Estado = "";
         AV41Orden = "";
         P00FG4_A1680ProDConcepto = new string[] {""} ;
         P00FG4_A322ProCod = new string[] {""} ;
         P00FG4_A327ProDProdCod = new string[] {""} ;
         P00FG4_n327ProDProdCod = new bool[] {false} ;
         P00FG4_A326ProDItem = new int[1] ;
         A1680ProDConcepto = "";
         A327ProDProdCod = "";
         AV46ProDProdCod = "";
         P00FG5_A1656ProCosto = new decimal[1] ;
         P00FG6_A322ProCod = new string[] {""} ;
         P00FG6_A1455OrdOpeCosto = new decimal[1] ;
         P00FG6_A1457OrdOpeHora = new decimal[1] ;
         P00FG6_A321OPECod = new string[] {""} ;
         A321OPECod = "";
         P00FG7_A322ProCod = new string[] {""} ;
         P00FG7_A1727ProMaqCosto = new decimal[1] ;
         P00FG7_A1729ProMaqHora = new decimal[1] ;
         P00FG7_A320MAQCod = new string[] {""} ;
         A320MAQCod = "";
         P00FG8_A1726ProGasCosto = new decimal[1] ;
         P00FG9_A14MvACod = new string[] {""} ;
         P00FG9_A1370MVSts = new string[] {""} ;
         P00FG9_A13MvATip = new string[] {""} ;
         P00FG9_A1276MvAOcom = new string[] {""} ;
         P00FG9_A1286MvATMov = new short[1] ;
         P00FG9_A28ProdCod = new string[] {""} ;
         P00FG9_A1248MvADCant = new decimal[1] ;
         P00FG9_A1250MVADPrecio = new decimal[1] ;
         P00FG9_A30MvADItem = new int[1] ;
         A14MvACod = "";
         A1370MVSts = "";
         A13MvATip = "";
         A1276MvAOcom = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV35Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_resumenordenesproduccionpdf__default(),
            new Object[][] {
                new Object[] {
               P00FG2_A28ProdCod, P00FG2_A55ProdDsc
               }
               , new Object[] {
               P00FG3_A325ProFec, P00FG3_A1740ProSts, P00FG3_A323ProProdCod, P00FG3_A1654ProCantProd, P00FG3_A1655ProCantProdIng, P00FG3_A1739ProRef, P00FG3_A1738ProProdDsc, P00FG3_A322ProCod
               }
               , new Object[] {
               P00FG4_A1680ProDConcepto, P00FG4_A322ProCod, P00FG4_A327ProDProdCod, P00FG4_n327ProDProdCod, P00FG4_A326ProDItem
               }
               , new Object[] {
               P00FG5_A1656ProCosto
               }
               , new Object[] {
               P00FG6_A322ProCod, P00FG6_A1455OrdOpeCosto, P00FG6_A1457OrdOpeHora, P00FG6_A321OPECod
               }
               , new Object[] {
               P00FG7_A322ProCod, P00FG7_A1727ProMaqCosto, P00FG7_A1729ProMaqHora, P00FG7_A320MAQCod
               }
               , new Object[] {
               P00FG8_A1726ProGasCosto
               }
               , new Object[] {
               P00FG9_A14MvACod, P00FG9_A1370MVSts, P00FG9_A13MvATip, P00FG9_A1276MvAOcom, P00FG9_A1286MvATMov, P00FG9_A28ProdCod, P00FG9_A1248MvADCant, P00FG9_A1250MVADPrecio, P00FG9_A30MvADItem
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
      private short A1286MvATMov ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A326ProDItem ;
      private int A30MvADItem ;
      private decimal AV62TotalGeneral ;
      private decimal AV52TCantidad1 ;
      private decimal AV53TCantidad2 ;
      private decimal A1654ProCantProd ;
      private decimal A1655ProCantProdIng ;
      private decimal AV43ProCantProd ;
      private decimal AV44ProCantProdIng ;
      private decimal AV11CostoT ;
      private decimal AV54TCosto ;
      private decimal AV12CostoUnit ;
      private decimal AV10Costo ;
      private decimal AV59TManoObra ;
      private decimal AV60TMaquina ;
      private decimal AV67TVarios ;
      private decimal c1656ProCosto ;
      private decimal A1455OrdOpeCosto ;
      private decimal A1457OrdOpeHora ;
      private decimal A1456OrdOpeCostoTotal ;
      private decimal A1727ProMaqCosto ;
      private decimal A1729ProMaqHora ;
      private decimal A1728ProMaqCostoTotal ;
      private decimal c1726ProGasCosto ;
      private decimal A1248MvADCant ;
      private decimal A1250MVADPrecio ;
      private decimal AV39MvADCant ;
      private decimal AV40MVADPrecio ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV45ProdCod ;
      private string AV47ProSts ;
      private string AV23Empresa ;
      private string AV22EmpDir ;
      private string AV24EmpRUC ;
      private string AV48Ruta ;
      private string AV30Filtro1 ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A323ProProdCod ;
      private string A1740ProSts ;
      private string A1739ProRef ;
      private string A1738ProProdDsc ;
      private string A322ProCod ;
      private string AV25Estado ;
      private string AV41Orden ;
      private string A1680ProDConcepto ;
      private string A327ProDProdCod ;
      private string AV46ProDProdCod ;
      private string A321OPECod ;
      private string A320MAQCod ;
      private string A14MvACod ;
      private string A1370MVSts ;
      private string A13MvATip ;
      private string A1276MvAOcom ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV27FDesde ;
      private DateTime AV29FHasta ;
      private DateTime A325ProFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool n327ProDProdCod ;
      private string AV70Logo_GXI ;
      private string AV35Logo ;
      private string Logo ;
      private IGxSession AV50Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProdCod ;
      private DateTime aP1_FDesde ;
      private DateTime aP2_FHasta ;
      private string aP3_ProSts ;
      private IDataStoreProvider pr_default ;
      private string[] P00FG2_A28ProdCod ;
      private string[] P00FG2_A55ProdDsc ;
      private DateTime[] P00FG3_A325ProFec ;
      private string[] P00FG3_A1740ProSts ;
      private string[] P00FG3_A323ProProdCod ;
      private decimal[] P00FG3_A1654ProCantProd ;
      private decimal[] P00FG3_A1655ProCantProdIng ;
      private string[] P00FG3_A1739ProRef ;
      private string[] P00FG3_A1738ProProdDsc ;
      private string[] P00FG3_A322ProCod ;
      private string[] P00FG4_A1680ProDConcepto ;
      private string[] P00FG4_A322ProCod ;
      private string[] P00FG4_A327ProDProdCod ;
      private bool[] P00FG4_n327ProDProdCod ;
      private int[] P00FG4_A326ProDItem ;
      private decimal[] P00FG5_A1656ProCosto ;
      private string[] P00FG6_A322ProCod ;
      private decimal[] P00FG6_A1455OrdOpeCosto ;
      private decimal[] P00FG6_A1457OrdOpeHora ;
      private string[] P00FG6_A321OPECod ;
      private string[] P00FG7_A322ProCod ;
      private decimal[] P00FG7_A1727ProMaqCosto ;
      private decimal[] P00FG7_A1729ProMaqHora ;
      private string[] P00FG7_A320MAQCod ;
      private decimal[] P00FG8_A1726ProGasCosto ;
      private string[] P00FG9_A14MvACod ;
      private string[] P00FG9_A1370MVSts ;
      private string[] P00FG9_A13MvATip ;
      private string[] P00FG9_A1276MvAOcom ;
      private short[] P00FG9_A1286MvATMov ;
      private string[] P00FG9_A28ProdCod ;
      private decimal[] P00FG9_A1248MvADCant ;
      private decimal[] P00FG9_A1250MVADPrecio ;
      private int[] P00FG9_A30MvADItem ;
   }

   public class r_resumenordenesproduccionpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FG3( IGxContext context ,
                                             string AV45ProdCod ,
                                             string AV47ProSts ,
                                             string A323ProProdCod ,
                                             string A1740ProSts ,
                                             DateTime A325ProFec ,
                                             DateTime AV27FDesde ,
                                             DateTime AV29FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ProFec], T1.[ProSts], T1.[ProProdCod] AS ProProdCod, T1.[ProCantProd], T1.[ProCantProdIng], T1.[ProRef], T2.[ProdDsc] AS ProProdDsc, T1.[ProCod] FROM ([POORDENES] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProProdCod])";
         AddWhere(sWhereString, "(T1.[ProFec] >= @AV27FDesde and T1.[ProFec] <= @AV29FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProProdCod] = @AV45ProdCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47ProSts)) )
         {
            AddWhere(sWhereString, "(T1.[ProSts] = @AV47ProSts)");
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
               case 1 :
                     return conditional_P00FG3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FG2;
          prmP00FG2 = new Object[] {
          new ParDef("@AV45ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00FG4;
          prmP00FG4 = new Object[] {
          new ParDef("@AV41Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FG5;
          prmP00FG5 = new Object[] {
          new ParDef("@AV41Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FG6;
          prmP00FG6 = new Object[] {
          new ParDef("@AV41Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FG7;
          prmP00FG7 = new Object[] {
          new ParDef("@AV41Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FG8;
          prmP00FG8 = new Object[] {
          new ParDef("@AV41Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FG9;
          prmP00FG9 = new Object[] {
          new ParDef("@AV46ProDProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV41Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FG3;
          prmP00FG3 = new Object[] {
          new ParDef("@AV27FDesde",GXType.Date,8,0) ,
          new ParDef("@AV29FHasta",GXType.Date,8,0) ,
          new ParDef("@AV45ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV47ProSts",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FG2", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV45ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FG2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FG3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FG3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FG4", "SELECT [ProDConcepto], [ProCod], [ProDProdCod], [ProDItem] FROM [POORDENESDET] WHERE ([ProCod] = @AV41Orden) AND (([ProDConcepto] = '')) ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FG4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FG5", "SELECT SUM([ProCosto]) FROM [POORDENESDET] WHERE ([ProCod] = @AV41Orden) AND (Not ([ProDConcepto] = '')) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FG5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FG6", "SELECT [ProCod], [OrdOpeCosto], [OrdOpeHora], [OPECod] FROM [POORDENOPERARIO] WHERE [ProCod] = @AV41Orden ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FG6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FG7", "SELECT [ProCod], [ProMaqCosto], [ProMaqHora], [MAQCod] FROM [POORDENMAQ] WHERE [ProCod] = @AV41Orden ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FG7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FG8", "SELECT SUM([ProGasCosto]) FROM [POORDENGASTO] WHERE [ProCod] = @AV41Orden ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FG8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FG9", "SELECT T1.[MvACod], T2.[MVSts], T1.[MvATip], T2.[MvAOcom], T2.[MvATMov], T1.[ProdCod], T1.[MvADCant], T1.[MVADPrecio], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T1.[ProdCod] = @AV46ProDProdCod) AND (T1.[MvATip] <> 'ING') AND (T2.[MVSts] <> 'A') AND (T2.[MvATMov] = 2) AND (T2.[MvAOcom] = @AV41Orden) ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FG9,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                return;
             case 3 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                return;
             case 6 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
