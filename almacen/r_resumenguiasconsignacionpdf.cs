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
namespace GeneXus.Programs.almacen {
   public class r_resumenguiasconsignacionpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "almacen.r_resumenguiasconsignacionpdf.aspx")), "almacen.r_resumenguiasconsignacionpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "almacen.r_resumenguiasconsignacionpdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "AlmCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV9AlmCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV21LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
                  AV39SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
                  AV28Prodcod = GetPar( "Prodcod");
                  AV10CliCod = GetPar( "CliCod");
                  AV17FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV19FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public r_resumenguiasconsignacionpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenguiasconsignacionpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_AlmCod ,
                           ref int aP1_LinCod ,
                           ref int aP2_SublCod ,
                           ref string aP3_Prodcod ,
                           ref string aP4_CliCod ,
                           ref DateTime aP5_FDesde ,
                           ref DateTime aP6_FHasta )
      {
         this.AV9AlmCod = aP0_AlmCod;
         this.AV21LinCod = aP1_LinCod;
         this.AV39SublCod = aP2_SublCod;
         this.AV28Prodcod = aP3_Prodcod;
         this.AV10CliCod = aP4_CliCod;
         this.AV17FDesde = aP5_FDesde;
         this.AV19FHasta = aP6_FHasta;
         initialize();
         executePrivate();
         aP0_AlmCod=this.AV9AlmCod;
         aP1_LinCod=this.AV21LinCod;
         aP2_SublCod=this.AV39SublCod;
         aP3_Prodcod=this.AV28Prodcod;
         aP4_CliCod=this.AV10CliCod;
         aP5_FDesde=this.AV17FDesde;
         aP6_FHasta=this.AV19FHasta;
      }

      public DateTime executeUdp( ref int aP0_AlmCod ,
                                  ref int aP1_LinCod ,
                                  ref int aP2_SublCod ,
                                  ref string aP3_Prodcod ,
                                  ref string aP4_CliCod ,
                                  ref DateTime aP5_FDesde )
      {
         execute(ref aP0_AlmCod, ref aP1_LinCod, ref aP2_SublCod, ref aP3_Prodcod, ref aP4_CliCod, ref aP5_FDesde, ref aP6_FHasta);
         return AV19FHasta ;
      }

      public void executeSubmit( ref int aP0_AlmCod ,
                                 ref int aP1_LinCod ,
                                 ref int aP2_SublCod ,
                                 ref string aP3_Prodcod ,
                                 ref string aP4_CliCod ,
                                 ref DateTime aP5_FDesde ,
                                 ref DateTime aP6_FHasta )
      {
         r_resumenguiasconsignacionpdf objr_resumenguiasconsignacionpdf;
         objr_resumenguiasconsignacionpdf = new r_resumenguiasconsignacionpdf();
         objr_resumenguiasconsignacionpdf.AV9AlmCod = aP0_AlmCod;
         objr_resumenguiasconsignacionpdf.AV21LinCod = aP1_LinCod;
         objr_resumenguiasconsignacionpdf.AV39SublCod = aP2_SublCod;
         objr_resumenguiasconsignacionpdf.AV28Prodcod = aP3_Prodcod;
         objr_resumenguiasconsignacionpdf.AV10CliCod = aP4_CliCod;
         objr_resumenguiasconsignacionpdf.AV17FDesde = aP5_FDesde;
         objr_resumenguiasconsignacionpdf.AV19FHasta = aP6_FHasta;
         objr_resumenguiasconsignacionpdf.context.SetSubmitInitialConfig(context);
         objr_resumenguiasconsignacionpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenguiasconsignacionpdf);
         aP0_AlmCod=this.AV9AlmCod;
         aP1_LinCod=this.AV21LinCod;
         aP2_SublCod=this.AV39SublCod;
         aP3_Prodcod=this.AV28Prodcod;
         aP4_CliCod=this.AV10CliCod;
         aP5_FDesde=this.AV17FDesde;
         aP6_FHasta=this.AV19FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenguiasconsignacionpdf)stateInfo).executePrivate();
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
            AV15Empresa = AV32Session.Get("Empresa");
            AV14EmpDir = AV32Session.Get("EmpDir");
            AV16EmpRUC = AV32Session.Get("EmpRUC");
            AV30Ruta = AV32Session.Get("RUTA") + "/Logo.jpg";
            AV22Logo = AV30Ruta;
            AV47Logo_GXI = GXDbFile.PathToUrl( AV30Ruta);
            AV40Titulo = "Resumen de Consignaciones";
            AV41Titulo2 = "Del : " + context.localUtil.DToC( AV17FDesde, 2, "/") + "   Al : " + context.localUtil.DToC( AV19FHasta, 2, "/");
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV21LinCod ,
                                                 AV10CliCod ,
                                                 AV28Prodcod ,
                                                 A52LinCod ,
                                                 A15MVCliCod ,
                                                 A28ProdCod ,
                                                 A25MvAFec ,
                                                 AV17FDesde ,
                                                 AV19FHasta ,
                                                 A21MvAlm ,
                                                 AV9AlmCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            /* Using cursor P008N2 */
            pr_default.execute(0, new Object[] {AV17FDesde, AV19FHasta, AV9AlmCod, AV21LinCod, AV10CliCod, AV28Prodcod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK8N3 = false;
               A13MvATip = P008N2_A13MvATip[0];
               A14MvACod = P008N2_A14MvACod[0];
               A21MvAlm = P008N2_A21MvAlm[0];
               A1290MVCliDsc = P008N2_A1290MVCliDsc[0];
               A15MVCliCod = P008N2_A15MVCliCod[0];
               n15MVCliCod = P008N2_n15MVCliCod[0];
               A25MvAFec = P008N2_A25MvAFec[0];
               A28ProdCod = P008N2_A28ProdCod[0];
               A52LinCod = P008N2_A52LinCod[0];
               A30MvADItem = P008N2_A30MvADItem[0];
               A21MvAlm = P008N2_A21MvAlm[0];
               A15MVCliCod = P008N2_A15MVCliCod[0];
               n15MVCliCod = P008N2_n15MVCliCod[0];
               A25MvAFec = P008N2_A25MvAFec[0];
               A1290MVCliDsc = P008N2_A1290MVCliDsc[0];
               A52LinCod = P008N2_A52LinCod[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P008N2_A15MVCliCod[0], A15MVCliCod) == 0 ) )
               {
                  BRK8N3 = false;
                  A13MvATip = P008N2_A13MvATip[0];
                  A14MvACod = P008N2_A14MvACod[0];
                  A1290MVCliDsc = P008N2_A1290MVCliDsc[0];
                  A30MvADItem = P008N2_A30MvADItem[0];
                  A1290MVCliDsc = P008N2_A1290MVCliDsc[0];
                  BRK8N3 = true;
                  pr_default.readNext(0);
               }
               AV24MVCliCod = A15MVCliCod;
               AV25MVCliDsc = A1290MVCliDsc;
               AV44TStkAct = 0;
               AV43TStkSal = 0;
               AV42TStkIng = 0;
               H8N0( false, 21) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24MVCliCod, "")), 9, Gx_line+3, 88, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25MVCliDsc, "")), 94, Gx_line+3, 616, Gx_line+18, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
               /* Execute user subroutine: 'PRODUCTOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! BRK8N3 )
               {
                  BRK8N3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8N0( true, 0) ;
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
         /* 'PRODUCTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV21LinCod ,
                                              AV28Prodcod ,
                                              A52LinCod ,
                                              A28ProdCod ,
                                              A25MvAFec ,
                                              AV17FDesde ,
                                              AV19FHasta ,
                                              A21MvAlm ,
                                              AV9AlmCod ,
                                              A15MVCliCod ,
                                              AV24MVCliCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P008N3 */
         pr_default.execute(1, new Object[] {AV17FDesde, AV19FHasta, AV9AlmCod, AV24MVCliCod, AV21LinCod, AV28Prodcod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK8N6 = false;
            A13MvATip = P008N3_A13MvATip[0];
            A14MvACod = P008N3_A14MvACod[0];
            A55ProdDsc = P008N3_A55ProdDsc[0];
            A28ProdCod = P008N3_A28ProdCod[0];
            A25MvAFec = P008N3_A25MvAFec[0];
            A15MVCliCod = P008N3_A15MVCliCod[0];
            n15MVCliCod = P008N3_n15MVCliCod[0];
            A52LinCod = P008N3_A52LinCod[0];
            A21MvAlm = P008N3_A21MvAlm[0];
            A30MvADItem = P008N3_A30MvADItem[0];
            A25MvAFec = P008N3_A25MvAFec[0];
            A15MVCliCod = P008N3_A15MVCliCod[0];
            n15MVCliCod = P008N3_n15MVCliCod[0];
            A21MvAlm = P008N3_A21MvAlm[0];
            A55ProdDsc = P008N3_A55ProdDsc[0];
            A52LinCod = P008N3_A52LinCod[0];
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P008N3_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRK8N6 = false;
               A13MvATip = P008N3_A13MvATip[0];
               A14MvACod = P008N3_A14MvACod[0];
               A55ProdDsc = P008N3_A55ProdDsc[0];
               A30MvADItem = P008N3_A30MvADItem[0];
               A55ProdDsc = P008N3_A55ProdDsc[0];
               BRK8N6 = true;
               pr_default.readNext(1);
            }
            AV11Codigo = A28ProdCod;
            AV29Producto = A55ProdDsc;
            AV35StkIng = 0;
            AV37StkSal = 0;
            AV33StkAct = 0;
            /* Execute user subroutine: 'DETALLES' */
            S126 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            H8N0( false, 20) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Producto, "")), 118, Gx_line+2, 550, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33StkAct, "ZZZZZZ,ZZZ,ZZ9.99")), 696, Gx_line+2, 803, Gx_line+17, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37StkSal, "ZZZZ,ZZZ,ZZ9.9999")), 634, Gx_line+2, 741, Gx_line+17, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35StkIng, "ZZZZ,ZZZ,ZZ9.9999")), 549, Gx_line+2, 656, Gx_line+17, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Codigo, "@!")), 12, Gx_line+2, 91, Gx_line+17, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV44TStkAct = (decimal)(AV44TStkAct+AV33StkAct);
            AV42TStkIng = (decimal)(AV42TStkIng+AV35StkIng);
            AV43TStkSal = (decimal)(AV43TStkSal+AV37StkSal);
            if ( ! BRK8N6 )
            {
               BRK8N6 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S126( )
      {
         /* 'DETALLES' Routine */
         returnInSub = false;
         /* Using cursor P008N4 */
         pr_default.execute(2, new Object[] {AV11Codigo, AV17FDesde, AV19FHasta, AV9AlmCod, AV24MVCliCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A14MvACod = P008N4_A14MvACod[0];
            A25MvAFec = P008N4_A25MvAFec[0];
            A28ProdCod = P008N4_A28ProdCod[0];
            A15MVCliCod = P008N4_A15MVCliCod[0];
            n15MVCliCod = P008N4_n15MVCliCod[0];
            A21MvAlm = P008N4_A21MvAlm[0];
            A1248MvADCant = P008N4_A1248MvADCant[0];
            A13MvATip = P008N4_A13MvATip[0];
            A30MvADItem = P008N4_A30MvADItem[0];
            A25MvAFec = P008N4_A25MvAFec[0];
            A15MVCliCod = P008N4_A15MVCliCod[0];
            n15MVCliCod = P008N4_n15MVCliCod[0];
            A21MvAlm = P008N4_A21MvAlm[0];
            AV37StkSal = (decimal)(AV37StkSal+((!(StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1248MvADCant : (decimal)(0))));
            AV35StkIng = (decimal)(AV35StkIng+(((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1248MvADCant : (decimal)(0))));
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV33StkAct = (decimal)(AV35StkIng-AV37StkSal);
      }

      protected void H8N0( bool bFoot ,
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
                  getPrinter().GxDrawLine(567, Gx_line+3, 811, Gx_line+3, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44TStkAct, "ZZZZ,ZZZ,ZZ9.9999")), 696, Gx_line+10, 803, Gx_line+25, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43TStkSal, "ZZZZ,ZZZ,ZZ9.9999")), 634, Gx_line+10, 741, Gx_line+25, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TStkIng, "ZZZZ,ZZZ,ZZ9.9999")), 549, Gx_line+10, 656, Gx_line+25, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Cliente", 465, Gx_line+10, 540, Gx_line+24, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+25);
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
               getPrinter().GxDrawText("Hora:", 663, Gx_line+40, 695, Gx_line+54, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 663, Gx_line+57, 707, Gx_line+71, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 663, Gx_line+22, 702, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 730, Gx_line+57, 769, Gx_line+72, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 710, Gx_line+40, 767, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 722, Gx_line+22, 769, Gx_line+37, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Titulo, "")), 189, Gx_line+43, 633, Gx_line+68, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+111, 816, Gx_line+153, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV22Logo)) ? AV47Logo_GXI : AV22Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 14, Gx_line+4, 152, Gx_line+75) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 27, Gx_line+127, 68, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Entregada", 590, Gx_line+132, 651, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Facturada", 675, Gx_line+132, 735, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41Titulo2, "")), 189, Gx_line+68, 633, Gx_line+93, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Empresa, "")), 14, Gx_line+76, 382, Gx_line+94, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16EmpRUC, "")), 14, Gx_line+94, 184, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Producto", 190, Gx_line+127, 244, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 768, Gx_line+132, 801, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(572, Gx_line+111, 572, Gx_line+153, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(572, Gx_line+127, 816, Gx_line+127, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidades", 655, Gx_line+113, 722, Gx_line+127, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+153);
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
         AV15Empresa = "";
         AV32Session = context.GetSession();
         AV14EmpDir = "";
         AV16EmpRUC = "";
         AV30Ruta = "";
         AV22Logo = "";
         AV47Logo_GXI = "";
         AV40Titulo = "";
         AV41Titulo2 = "";
         scmdbuf = "";
         A15MVCliCod = "";
         A28ProdCod = "";
         A25MvAFec = DateTime.MinValue;
         P008N2_A13MvATip = new string[] {""} ;
         P008N2_A14MvACod = new string[] {""} ;
         P008N2_A21MvAlm = new int[1] ;
         P008N2_A1290MVCliDsc = new string[] {""} ;
         P008N2_A15MVCliCod = new string[] {""} ;
         P008N2_n15MVCliCod = new bool[] {false} ;
         P008N2_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008N2_A28ProdCod = new string[] {""} ;
         P008N2_A52LinCod = new int[1] ;
         P008N2_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A1290MVCliDsc = "";
         AV24MVCliCod = "";
         AV25MVCliDsc = "";
         P008N3_A13MvATip = new string[] {""} ;
         P008N3_A14MvACod = new string[] {""} ;
         P008N3_A55ProdDsc = new string[] {""} ;
         P008N3_A28ProdCod = new string[] {""} ;
         P008N3_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008N3_A15MVCliCod = new string[] {""} ;
         P008N3_n15MVCliCod = new bool[] {false} ;
         P008N3_A52LinCod = new int[1] ;
         P008N3_A21MvAlm = new int[1] ;
         P008N3_A30MvADItem = new int[1] ;
         A55ProdDsc = "";
         AV11Codigo = "";
         AV29Producto = "";
         P008N4_A14MvACod = new string[] {""} ;
         P008N4_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008N4_A28ProdCod = new string[] {""} ;
         P008N4_A15MVCliCod = new string[] {""} ;
         P008N4_n15MVCliCod = new bool[] {false} ;
         P008N4_A21MvAlm = new int[1] ;
         P008N4_A1248MvADCant = new decimal[1] ;
         P008N4_A13MvATip = new string[] {""} ;
         P008N4_A30MvADItem = new int[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV22Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_resumenguiasconsignacionpdf__default(),
            new Object[][] {
                new Object[] {
               P008N2_A13MvATip, P008N2_A14MvACod, P008N2_A21MvAlm, P008N2_A1290MVCliDsc, P008N2_A15MVCliCod, P008N2_n15MVCliCod, P008N2_A25MvAFec, P008N2_A28ProdCod, P008N2_A52LinCod, P008N2_A30MvADItem
               }
               , new Object[] {
               P008N3_A13MvATip, P008N3_A14MvACod, P008N3_A55ProdDsc, P008N3_A28ProdCod, P008N3_A25MvAFec, P008N3_A15MVCliCod, P008N3_n15MVCliCod, P008N3_A52LinCod, P008N3_A21MvAlm, P008N3_A30MvADItem
               }
               , new Object[] {
               P008N4_A14MvACod, P008N4_A25MvAFec, P008N4_A28ProdCod, P008N4_A15MVCliCod, P008N4_n15MVCliCod, P008N4_A21MvAlm, P008N4_A1248MvADCant, P008N4_A13MvATip, P008N4_A30MvADItem
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
      private int AV9AlmCod ;
      private int AV21LinCod ;
      private int AV39SublCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A52LinCod ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private int Gx_OldLine ;
      private decimal AV44TStkAct ;
      private decimal AV43TStkSal ;
      private decimal AV42TStkIng ;
      private decimal AV35StkIng ;
      private decimal AV37StkSal ;
      private decimal AV33StkAct ;
      private decimal A1248MvADCant ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV28Prodcod ;
      private string AV10CliCod ;
      private string AV15Empresa ;
      private string AV14EmpDir ;
      private string AV16EmpRUC ;
      private string AV30Ruta ;
      private string AV40Titulo ;
      private string AV41Titulo2 ;
      private string scmdbuf ;
      private string A15MVCliCod ;
      private string A28ProdCod ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A1290MVCliDsc ;
      private string AV24MVCliCod ;
      private string AV25MVCliDsc ;
      private string A55ProdDsc ;
      private string AV11Codigo ;
      private string AV29Producto ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV17FDesde ;
      private DateTime AV19FHasta ;
      private DateTime A25MvAFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK8N3 ;
      private bool n15MVCliCod ;
      private bool returnInSub ;
      private bool BRK8N6 ;
      private string AV47Logo_GXI ;
      private string AV22Logo ;
      private string Logo ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_AlmCod ;
      private int aP1_LinCod ;
      private int aP2_SublCod ;
      private string aP3_Prodcod ;
      private string aP4_CliCod ;
      private DateTime aP5_FDesde ;
      private DateTime aP6_FHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P008N2_A13MvATip ;
      private string[] P008N2_A14MvACod ;
      private int[] P008N2_A21MvAlm ;
      private string[] P008N2_A1290MVCliDsc ;
      private string[] P008N2_A15MVCliCod ;
      private bool[] P008N2_n15MVCliCod ;
      private DateTime[] P008N2_A25MvAFec ;
      private string[] P008N2_A28ProdCod ;
      private int[] P008N2_A52LinCod ;
      private int[] P008N2_A30MvADItem ;
      private string[] P008N3_A13MvATip ;
      private string[] P008N3_A14MvACod ;
      private string[] P008N3_A55ProdDsc ;
      private string[] P008N3_A28ProdCod ;
      private DateTime[] P008N3_A25MvAFec ;
      private string[] P008N3_A15MVCliCod ;
      private bool[] P008N3_n15MVCliCod ;
      private int[] P008N3_A52LinCod ;
      private int[] P008N3_A21MvAlm ;
      private int[] P008N3_A30MvADItem ;
      private string[] P008N4_A14MvACod ;
      private DateTime[] P008N4_A25MvAFec ;
      private string[] P008N4_A28ProdCod ;
      private string[] P008N4_A15MVCliCod ;
      private bool[] P008N4_n15MVCliCod ;
      private int[] P008N4_A21MvAlm ;
      private decimal[] P008N4_A1248MvADCant ;
      private string[] P008N4_A13MvATip ;
      private int[] P008N4_A30MvADItem ;
   }

   public class r_resumenguiasconsignacionpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008N2( IGxContext context ,
                                             int AV21LinCod ,
                                             string AV10CliCod ,
                                             string AV28Prodcod ,
                                             int A52LinCod ,
                                             string A15MVCliCod ,
                                             string A28ProdCod ,
                                             DateTime A25MvAFec ,
                                             DateTime AV17FDesde ,
                                             DateTime AV19FHasta ,
                                             int A21MvAlm ,
                                             int AV9AlmCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T2.[MvAlm], T3.[CliDsc] AS MVCliDsc, T2.[MVCliCod] AS MVCliCod, T2.[MvAFec], T1.[ProdCod], T4.[LinCod], T1.[MvADItem] FROM ((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) LEFT JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T2.[MVCliCod]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod])";
         AddWhere(sWhereString, "(T2.[MvAFec] >= @AV17FDesde)");
         AddWhere(sWhereString, "(T2.[MvAFec] <= @AV19FHasta)");
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV9AlmCod)");
         if ( ! (0==AV21LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV21LinCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[MVCliCod] = @AV10CliCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV28Prodcod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[MVCliCod], T3.[CliDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008N3( IGxContext context ,
                                             int AV21LinCod ,
                                             string AV28Prodcod ,
                                             int A52LinCod ,
                                             string A28ProdCod ,
                                             DateTime A25MvAFec ,
                                             DateTime AV17FDesde ,
                                             DateTime AV19FHasta ,
                                             int A21MvAlm ,
                                             int AV9AlmCod ,
                                             string A15MVCliCod ,
                                             string AV24MVCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T3.[ProdDsc], T1.[ProdCod], T2.[MvAFec], T2.[MVCliCod] AS MVCliCod, T3.[LinCod], T2.[MvAlm], T1.[MvADItem] FROM (([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod])";
         AddWhere(sWhereString, "(T2.[MvAFec] >= @AV17FDesde)");
         AddWhere(sWhereString, "(T2.[MvAFec] <= @AV19FHasta)");
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV9AlmCod)");
         AddWhere(sWhereString, "(T2.[MVCliCod] = @AV24MVCliCod)");
         if ( ! (0==AV21LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV21LinCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV28Prodcod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T3.[ProdDsc]";
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
               case 0 :
                     return conditional_P008N2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
               case 1 :
                     return conditional_P008N3(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008N4;
          prmP008N4 = new Object[] {
          new ParDef("@AV11Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV19FHasta",GXType.Date,8,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV24MVCliCod",GXType.NChar,20,0)
          };
          Object[] prmP008N2;
          prmP008N2 = new Object[] {
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV19FHasta",GXType.Date,8,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV21LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV10CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV28Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP008N3;
          prmP008N3 = new Object[] {
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV19FHasta",GXType.Date,8,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV24MVCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV21LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV28Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008N4", "SELECT T1.[MvACod], T2.[MvAFec], T1.[ProdCod], T2.[MVCliCod] AS MVCliCod, T2.[MvAlm], T1.[MvADCant], T1.[MvATip], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T1.[ProdCod] = @AV11Codigo) AND (T2.[MvAFec] >= @AV17FDesde) AND (T2.[MvAFec] <= @AV19FHasta) AND (T2.[MvAlm] = @AV9AlmCod) AND (T2.[MVCliCod] = @AV24MVCliCod) ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 15);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
       }
    }

 }

}
