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
   public class r_resumenordenesserviciopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.r_resumenordenesserviciopdf.aspx")), "produccion.r_resumenordenesserviciopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.r_resumenordenesserviciopdf.aspx")))) ;
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
               AV54ProdCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV15FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV53ProSts = GetPar( "ProSts");
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

      public r_resumenordenesserviciopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenordenesserviciopdf( IGxContext context )
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
         this.AV54ProdCod = aP0_ProdCod;
         this.AV14FDesde = aP1_FDesde;
         this.AV15FHasta = aP2_FHasta;
         this.AV53ProSts = aP3_ProSts;
         initialize();
         executePrivate();
         aP0_ProdCod=this.AV54ProdCod;
         aP1_FDesde=this.AV14FDesde;
         aP2_FHasta=this.AV15FHasta;
         aP3_ProSts=this.AV53ProSts;
      }

      public string executeUdp( ref string aP0_ProdCod ,
                                ref DateTime aP1_FDesde ,
                                ref DateTime aP2_FHasta )
      {
         execute(ref aP0_ProdCod, ref aP1_FDesde, ref aP2_FHasta, ref aP3_ProSts);
         return AV53ProSts ;
      }

      public void executeSubmit( ref string aP0_ProdCod ,
                                 ref DateTime aP1_FDesde ,
                                 ref DateTime aP2_FHasta ,
                                 ref string aP3_ProSts )
      {
         r_resumenordenesserviciopdf objr_resumenordenesserviciopdf;
         objr_resumenordenesserviciopdf = new r_resumenordenesserviciopdf();
         objr_resumenordenesserviciopdf.AV54ProdCod = aP0_ProdCod;
         objr_resumenordenesserviciopdf.AV14FDesde = aP1_FDesde;
         objr_resumenordenesserviciopdf.AV15FHasta = aP2_FHasta;
         objr_resumenordenesserviciopdf.AV53ProSts = aP3_ProSts;
         objr_resumenordenesserviciopdf.context.SetSubmitInitialConfig(context);
         objr_resumenordenesserviciopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenordenesserviciopdf);
         aP0_ProdCod=this.AV54ProdCod;
         aP1_FDesde=this.AV14FDesde;
         aP2_FHasta=this.AV15FHasta;
         aP3_ProSts=this.AV53ProSts;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenordenesserviciopdf)stateInfo).executePrivate();
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
            AV39Empresa = AV43Session.Get("Empresa");
            AV40EmpDir = AV43Session.Get("EmpDir");
            AV41EmpRUC = AV43Session.Get("EmpRUC");
            AV42Ruta = AV43Session.Get("RUTA") + "/Logo.jpg";
            AV38Logo = AV42Ruta;
            AV69Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV16Filtro1 = "Todos";
            /* Using cursor P00FF2 */
            pr_default.execute(0, new Object[] {AV54ProdCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A28ProdCod = P00FF2_A28ProdCod[0];
               A55ProdDsc = P00FF2_A55ProdDsc[0];
               AV16Filtro1 = StringUtil.Trim( A55ProdDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV27TotalGeneral = 0.00m;
            AV64TCantidad1 = 0.0000m;
            AV65TCantidad2 = 0.0000m;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV54ProdCod ,
                                                 AV53ProSts ,
                                                 A334PSerProdCod ,
                                                 A1817PSerSts ,
                                                 A1805PSerFec ,
                                                 AV14FDesde ,
                                                 AV15FHasta } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00FF3 */
            pr_default.execute(1, new Object[] {AV14FDesde, AV15FHasta, AV54ProdCod, AV53ProSts});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A1805PSerFec = P00FF3_A1805PSerFec[0];
               A1817PSerSts = P00FF3_A1817PSerSts[0];
               A334PSerProdCod = P00FF3_A334PSerProdCod[0];
               A1793PSerCantSer = P00FF3_A1793PSerCantSer[0];
               A1792PSerCantIng = P00FF3_A1792PSerCantIng[0];
               A1798PSerCostos = P00FF3_A1798PSerCostos[0];
               A1816PSerRef = P00FF3_A1816PSerRef[0];
               A1815PSerProdDsc = P00FF3_A1815PSerProdDsc[0];
               A329PSerCod = P00FF3_A329PSerCod[0];
               A1815PSerProdDsc = P00FF3_A1815PSerProdDsc[0];
               AV66ProCantProd = A1793PSerCantSer;
               AV63ProCantProdIng = A1792PSerCantIng;
               AV52Estado = ((StringUtil.StrCmp(A1817PSerSts, "T")==0) ? "TERMINADO" : "PENDIENTE");
               AV55Orden = A329PSerCod;
               AV51CostoT = 0.00m;
               AV58TCosto = A1798PSerCostos;
               AV51CostoT = AV58TCosto;
               AV50CostoUnit = ((AV63ProCantProdIng==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( AV58TCosto/ (decimal)(AV63ProCantProdIng), 4));
               HFF0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1815PSerProdDsc, "")), 334, Gx_line+2, 658, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51CostoT, "ZZZZZZ,ZZZ,ZZ9.99")), 908, Gx_line+1, 1015, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A329PSerCod, "")), 8, Gx_line+1, 71, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A1805PSerFec, "99/99/99"), 82, Gx_line+1, 128, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1816PSerRef, "")), 141, Gx_line+1, 241, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A334PSerProdCod, "@!")), 247, Gx_line+1, 325, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1792PSerCantIng, "ZZZZZZ,ZZZ,ZZ9.99")), 728, Gx_line+1, 834, Gx_line+15, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1793PSerCantSer, "ZZZZZZ,ZZZ,ZZ9.99")), 621, Gx_line+1, 727, Gx_line+15, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50CostoUnit, "ZZZZ,ZZZ,ZZ9.9999")), 821, Gx_line+1, 928, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Estado, "")), 1039, Gx_line+2, 1092, Gx_line+17, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV27TotalGeneral = (decimal)(AV27TotalGeneral+AV51CostoT);
               AV64TCantidad1 = (decimal)(AV64TCantidad1+AV66ProCantProd);
               AV65TCantidad2 = (decimal)(AV65TCantidad2+AV63ProCantProdIng);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            HFF0( false, 65) ;
            getPrinter().GxDrawLine(636, Gx_line+9, 1024, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 530, Gx_line+15, 610, Gx_line+29, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27TotalGeneral, "ZZZZZZZZZ,ZZ9.99")), 915, Gx_line+14, 1016, Gx_line+29, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TCantidad1, "ZZZZ,ZZZ,ZZ9.9999")), 621, Gx_line+16, 728, Gx_line+31, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TCantidad2, "ZZZZ,ZZZ,ZZ9.9999")), 728, Gx_line+16, 835, Gx_line+31, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+65);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HFF0( true, 0) ;
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

      protected void HFF0( bool bFoot ,
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
               getPrinter().GxDrawText("Resumen de Ordenes de Servicio", 393, Gx_line+67, 695, Gx_line+86, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Servicio", 368, Gx_line+94, 416, Gx_line+108, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Filtro1, "")), 427, Gx_line+89, 770, Gx_line+113, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+150, 1106, Gx_line+176, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1030, Gx_line+21, 1077, Gx_line+36, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1016, Gx_line+40, 1076, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1039, Gx_line+59, 1078, Gx_line+74, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Orden", 15, Gx_line+156, 68, Gx_line+170, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Serv.Atendidos", 744, Gx_line+158, 835, Gx_line+172, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 368, Gx_line+120, 405, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV14FDesde, "99/99/99"), 427, Gx_line+113, 501, Gx_line+137, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 545, Gx_line+120, 580, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV15FHasta, "99/99/99"), 596, Gx_line+113, 670, Gx_line+137, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 90, Gx_line+156, 125, Gx_line+170, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Codigo", 247, Gx_line+156, 288, Gx_line+170, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Servicio", 334, Gx_line+157, 382, Gx_line+171, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Servicios", 649, Gx_line+158, 720, Gx_line+172, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV38Logo)) ? AV69Logo_GXI : AV38Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+11, 167, Gx_line+89) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Empresa, "")), 9, Gx_line+93, 349, Gx_line+111, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41EmpRUC, "")), 9, Gx_line+110, 238, Gx_line+128, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Costo Unit.", 858, Gx_line+157, 923, Gx_line+171, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo Total", 948, Gx_line+157, 1016, Gx_line+171, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Estado", 1045, Gx_line+155, 1086, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Pedido", 143, Gx_line+156, 200, Gx_line+170, 0+256, 0, 0, 0) ;
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
         AV39Empresa = "";
         AV43Session = context.GetSession();
         AV40EmpDir = "";
         AV41EmpRUC = "";
         AV42Ruta = "";
         AV38Logo = "";
         AV69Logo_GXI = "";
         AV16Filtro1 = "";
         scmdbuf = "";
         P00FF2_A28ProdCod = new string[] {""} ;
         P00FF2_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         A334PSerProdCod = "";
         A1817PSerSts = "";
         A1805PSerFec = DateTime.MinValue;
         P00FF3_A1805PSerFec = new DateTime[] {DateTime.MinValue} ;
         P00FF3_A1817PSerSts = new string[] {""} ;
         P00FF3_A334PSerProdCod = new string[] {""} ;
         P00FF3_A1793PSerCantSer = new decimal[1] ;
         P00FF3_A1792PSerCantIng = new decimal[1] ;
         P00FF3_A1798PSerCostos = new decimal[1] ;
         P00FF3_A1816PSerRef = new string[] {""} ;
         P00FF3_A1815PSerProdDsc = new string[] {""} ;
         P00FF3_A329PSerCod = new string[] {""} ;
         A1816PSerRef = "";
         A1815PSerProdDsc = "";
         A329PSerCod = "";
         AV52Estado = "";
         AV55Orden = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV38Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_resumenordenesserviciopdf__default(),
            new Object[][] {
                new Object[] {
               P00FF2_A28ProdCod, P00FF2_A55ProdDsc
               }
               , new Object[] {
               P00FF3_A1805PSerFec, P00FF3_A1817PSerSts, P00FF3_A334PSerProdCod, P00FF3_A1793PSerCantSer, P00FF3_A1792PSerCantIng, P00FF3_A1798PSerCostos, P00FF3_A1816PSerRef, P00FF3_A1815PSerProdDsc, P00FF3_A329PSerCod
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
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal AV27TotalGeneral ;
      private decimal AV64TCantidad1 ;
      private decimal AV65TCantidad2 ;
      private decimal A1793PSerCantSer ;
      private decimal A1792PSerCantIng ;
      private decimal A1798PSerCostos ;
      private decimal AV66ProCantProd ;
      private decimal AV63ProCantProdIng ;
      private decimal AV51CostoT ;
      private decimal AV58TCosto ;
      private decimal AV50CostoUnit ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV54ProdCod ;
      private string AV53ProSts ;
      private string AV39Empresa ;
      private string AV40EmpDir ;
      private string AV41EmpRUC ;
      private string AV42Ruta ;
      private string AV16Filtro1 ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A334PSerProdCod ;
      private string A1817PSerSts ;
      private string A1816PSerRef ;
      private string A1815PSerProdDsc ;
      private string A329PSerCod ;
      private string AV52Estado ;
      private string AV55Orden ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV14FDesde ;
      private DateTime AV15FHasta ;
      private DateTime A1805PSerFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string AV69Logo_GXI ;
      private string AV38Logo ;
      private string Logo ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProdCod ;
      private DateTime aP1_FDesde ;
      private DateTime aP2_FHasta ;
      private string aP3_ProSts ;
      private IDataStoreProvider pr_default ;
      private string[] P00FF2_A28ProdCod ;
      private string[] P00FF2_A55ProdDsc ;
      private DateTime[] P00FF3_A1805PSerFec ;
      private string[] P00FF3_A1817PSerSts ;
      private string[] P00FF3_A334PSerProdCod ;
      private decimal[] P00FF3_A1793PSerCantSer ;
      private decimal[] P00FF3_A1792PSerCantIng ;
      private decimal[] P00FF3_A1798PSerCostos ;
      private string[] P00FF3_A1816PSerRef ;
      private string[] P00FF3_A1815PSerProdDsc ;
      private string[] P00FF3_A329PSerCod ;
   }

   public class r_resumenordenesserviciopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FF3( IGxContext context ,
                                             string AV54ProdCod ,
                                             string AV53ProSts ,
                                             string A334PSerProdCod ,
                                             string A1817PSerSts ,
                                             DateTime A1805PSerFec ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[PSerFec], T1.[PSerSts], T1.[PSerProdCod] AS PSerProdCod, T1.[PSerCantSer], T1.[PSerCantIng], T1.[PSerCostos], T1.[PSerRef], T2.[ProdDsc] AS PSerProdDsc, T1.[PSerCod] FROM ([POSERVICIO] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[PSerProdCod])";
         AddWhere(sWhereString, "(T1.[PSerFec] >= @AV14FDesde and T1.[PSerFec] <= @AV15FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[PSerProdCod] = @AV54ProdCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53ProSts)) )
         {
            AddWhere(sWhereString, "(T1.[PSerSts] = @AV53ProSts)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PSerCod]";
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
                     return conditional_P00FF3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FF2;
          prmP00FF2 = new Object[] {
          new ParDef("@AV54ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00FF3;
          prmP00FF3 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV54ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV53ProSts",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FF2", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV54ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FF2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FF3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FF3,100, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 10);
                return;
       }
    }

 }

}
