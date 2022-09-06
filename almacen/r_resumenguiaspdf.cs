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
   public class r_resumenguiaspdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "almacen.r_resumenguiaspdf.aspx")), "almacen.r_resumenguiaspdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "almacen.r_resumenguiaspdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "LinCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV26LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV43SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV34Prodcod = GetPar( "Prodcod");
                  AV18FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV19FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV23Flag = (short)(NumberUtil.Val( GetPar( "Flag"), "."));
                  AV10CliCod = GetPar( "CliCod");
                  AV32MVCliOrigen = (int)(NumberUtil.Val( GetPar( "MVCliOrigen"), "."));
                  AV28MovCod = (int)(NumberUtil.Val( GetPar( "MovCod"), "."));
                  AV31MVCCosto = GetPar( "MVCCosto");
                  AV52ChoCod = (int)(NumberUtil.Val( GetPar( "ChoCod"), "."));
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

      public r_resumenguiaspdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenguiaspdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SubLCod ,
                           ref string aP2_Prodcod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref short aP5_Flag ,
                           ref string aP6_CliCod ,
                           ref int aP7_MVCliOrigen ,
                           ref int aP8_MovCod ,
                           ref string aP9_MVCCosto ,
                           ref int aP10_ChoCod )
      {
         this.AV26LinCod = aP0_LinCod;
         this.AV43SubLCod = aP1_SubLCod;
         this.AV34Prodcod = aP2_Prodcod;
         this.AV18FDesde = aP3_FDesde;
         this.AV19FHasta = aP4_FHasta;
         this.AV23Flag = aP5_Flag;
         this.AV10CliCod = aP6_CliCod;
         this.AV32MVCliOrigen = aP7_MVCliOrigen;
         this.AV28MovCod = aP8_MovCod;
         this.AV31MVCCosto = aP9_MVCCosto;
         this.AV52ChoCod = aP10_ChoCod;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV26LinCod;
         aP1_SubLCod=this.AV43SubLCod;
         aP2_Prodcod=this.AV34Prodcod;
         aP3_FDesde=this.AV18FDesde;
         aP4_FHasta=this.AV19FHasta;
         aP5_Flag=this.AV23Flag;
         aP6_CliCod=this.AV10CliCod;
         aP7_MVCliOrigen=this.AV32MVCliOrigen;
         aP8_MovCod=this.AV28MovCod;
         aP9_MVCCosto=this.AV31MVCCosto;
         aP10_ChoCod=this.AV52ChoCod;
      }

      public int executeUdp( ref int aP0_LinCod ,
                             ref int aP1_SubLCod ,
                             ref string aP2_Prodcod ,
                             ref DateTime aP3_FDesde ,
                             ref DateTime aP4_FHasta ,
                             ref short aP5_Flag ,
                             ref string aP6_CliCod ,
                             ref int aP7_MVCliOrigen ,
                             ref int aP8_MovCod ,
                             ref string aP9_MVCCosto )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_Prodcod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_Flag, ref aP6_CliCod, ref aP7_MVCliOrigen, ref aP8_MovCod, ref aP9_MVCCosto, ref aP10_ChoCod);
         return AV52ChoCod ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref string aP2_Prodcod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref short aP5_Flag ,
                                 ref string aP6_CliCod ,
                                 ref int aP7_MVCliOrigen ,
                                 ref int aP8_MovCod ,
                                 ref string aP9_MVCCosto ,
                                 ref int aP10_ChoCod )
      {
         r_resumenguiaspdf objr_resumenguiaspdf;
         objr_resumenguiaspdf = new r_resumenguiaspdf();
         objr_resumenguiaspdf.AV26LinCod = aP0_LinCod;
         objr_resumenguiaspdf.AV43SubLCod = aP1_SubLCod;
         objr_resumenguiaspdf.AV34Prodcod = aP2_Prodcod;
         objr_resumenguiaspdf.AV18FDesde = aP3_FDesde;
         objr_resumenguiaspdf.AV19FHasta = aP4_FHasta;
         objr_resumenguiaspdf.AV23Flag = aP5_Flag;
         objr_resumenguiaspdf.AV10CliCod = aP6_CliCod;
         objr_resumenguiaspdf.AV32MVCliOrigen = aP7_MVCliOrigen;
         objr_resumenguiaspdf.AV28MovCod = aP8_MovCod;
         objr_resumenguiaspdf.AV31MVCCosto = aP9_MVCCosto;
         objr_resumenguiaspdf.AV52ChoCod = aP10_ChoCod;
         objr_resumenguiaspdf.context.SetSubmitInitialConfig(context);
         objr_resumenguiaspdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenguiaspdf);
         aP0_LinCod=this.AV26LinCod;
         aP1_SubLCod=this.AV43SubLCod;
         aP2_Prodcod=this.AV34Prodcod;
         aP3_FDesde=this.AV18FDesde;
         aP4_FHasta=this.AV19FHasta;
         aP5_Flag=this.AV23Flag;
         aP6_CliCod=this.AV10CliCod;
         aP7_MVCliOrigen=this.AV32MVCliOrigen;
         aP8_MovCod=this.AV28MovCod;
         aP9_MVCCosto=this.AV31MVCCosto;
         aP10_ChoCod=this.AV52ChoCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenguiaspdf)stateInfo).executePrivate();
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
            AV15Empresa = AV39Session.Get("Empresa");
            AV14EmpDir = AV39Session.Get("EmpDir");
            AV16EmpRUC = AV39Session.Get("EmpRUC");
            AV36Ruta = AV39Session.Get("RUTA") + "/Logo.jpg";
            AV27Logo = AV36Ruta;
            AV60Logo_GXI = GXDbFile.PathToUrl( AV36Ruta);
            AV45Titulo = "Resumen de Guias de Remisión";
            AV46Titulo2 = "Del : " + context.localUtil.DToC( AV18FDesde, 2, "/") + "   Al : " + context.localUtil.DToC( AV19FHasta, 2, "/");
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV10CliCod ,
                                                 AV28MovCod ,
                                                 AV32MVCliOrigen ,
                                                 AV31MVCCosto ,
                                                 AV52ChoCod ,
                                                 A15MVCliCod ,
                                                 A22MvAMov ,
                                                 A16MVCliOrigen ,
                                                 A1287MVCCosto ,
                                                 A10ChoCod ,
                                                 A25MvAFec ,
                                                 AV18FDesde ,
                                                 AV19FHasta ,
                                                 A13MvATip } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00DO2 */
            pr_default.execute(0, new Object[] {AV18FDesde, AV19FHasta, AV10CliCod, AV28MovCod, AV32MVCliOrigen, AV31MVCCosto, AV52ChoCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKDO3 = false;
               A13MvATip = P00DO2_A13MvATip[0];
               A1287MVCCosto = P00DO2_A1287MVCCosto[0];
               A10ChoCod = P00DO2_A10ChoCod[0];
               A16MVCliOrigen = P00DO2_A16MVCliOrigen[0];
               n16MVCliOrigen = P00DO2_n16MVCliOrigen[0];
               A22MvAMov = P00DO2_A22MvAMov[0];
               A15MVCliCod = P00DO2_A15MVCliCod[0];
               n15MVCliCod = P00DO2_n15MVCliCod[0];
               A25MvAFec = P00DO2_A25MvAFec[0];
               A14MvACod = P00DO2_A14MvACod[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00DO2_A1287MVCCosto[0], A1287MVCCosto) == 0 ) )
               {
                  BRKDO3 = false;
                  A13MvATip = P00DO2_A13MvATip[0];
                  A14MvACod = P00DO2_A14MvACod[0];
                  BRKDO3 = true;
                  pr_default.readNext(0);
               }
               AV13CosCod = StringUtil.Trim( A1287MVCCosto);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CosCod)) )
               {
                  /* Execute user subroutine: 'CENTROCOSTO' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
               }
               /* Execute user subroutine: 'RESUMENGUIAS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! BRKDO3 )
               {
                  BRKDO3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HDO0( true, 0) ;
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
         /* 'RESUMENGUIAS' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV10CliCod ,
                                              AV28MovCod ,
                                              AV32MVCliOrigen ,
                                              A15MVCliCod ,
                                              A22MvAMov ,
                                              A16MVCliOrigen ,
                                              A25MvAFec ,
                                              AV18FDesde ,
                                              AV19FHasta ,
                                              A1287MVCCosto ,
                                              AV13CosCod ,
                                              A13MvATip } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00DO3 */
         pr_default.execute(1, new Object[] {AV18FDesde, AV19FHasta, AV13CosCod, AV10CliCod, AV28MovCod, AV32MVCliOrigen});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A14MvACod = P00DO3_A14MvACod[0];
            A13MvATip = P00DO3_A13MvATip[0];
            A16MVCliOrigen = P00DO3_A16MVCliOrigen[0];
            n16MVCliOrigen = P00DO3_n16MVCliOrigen[0];
            A22MvAMov = P00DO3_A22MvAMov[0];
            A15MVCliCod = P00DO3_A15MVCliCod[0];
            n15MVCliCod = P00DO3_n15MVCliCod[0];
            A25MvAFec = P00DO3_A25MvAFec[0];
            A1287MVCCosto = P00DO3_A1287MVCCosto[0];
            A1290MVCliDsc = P00DO3_A1290MVCliDsc[0];
            A1370MVSts = P00DO3_A1370MVSts[0];
            A20MVPedCod = P00DO3_A20MVPedCod[0];
            n20MVPedCod = P00DO3_n20MVPedCod[0];
            A23DocTip = P00DO3_A23DocTip[0];
            n23DocTip = P00DO3_n23DocTip[0];
            A24DocNum = P00DO3_A24DocNum[0];
            n24DocNum = P00DO3_n24DocNum[0];
            A1290MVCliDsc = P00DO3_A1290MVCliDsc[0];
            AV53MVCliDsc = ((StringUtil.StrCmp(A1370MVSts, "A")==0) ? "ANULADA" : StringUtil.Trim( A1290MVCliDsc));
            AV54MVPedCod = ((StringUtil.StrCmp(A1370MVSts, "A")==0) ? "" : StringUtil.Trim( A20MVPedCod));
            AV55DocTip = ((StringUtil.StrCmp(A1370MVSts, "A")==0) ? "" : StringUtil.Trim( A23DocTip));
            AV56DocNum = ((StringUtil.StrCmp(A1370MVSts, "A")==0) ? "" : StringUtil.Trim( A24DocNum));
            if ( AV23Flag == 2 )
            {
               /* Using cursor P00DO4 */
               pr_default.execute(2, new Object[] {A13MvATip, A14MvACod});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A49UniCod = P00DO4_A49UniCod[0];
                  A1997UniAbr = P00DO4_A1997UniAbr[0];
                  A55ProdDsc = P00DO4_A55ProdDsc[0];
                  A28ProdCod = P00DO4_A28ProdCod[0];
                  A30MvADItem = P00DO4_A30MvADItem[0];
                  A49UniCod = P00DO4_A49UniCod[0];
                  A55ProdDsc = P00DO4_A55ProdDsc[0];
                  A1997UniAbr = P00DO4_A1997UniAbr[0];
                  HDO0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 49, Gx_line+1, 144, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40StkAct, "ZZZZ,ZZZ,ZZ9.9999")), 657, Gx_line+1, 764, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 147, Gx_line+1, 563, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 578, Gx_line+1, 610, Gx_line+16, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV25ITemProd), "ZZZZ9")), 4, Gx_line+1, 36, Gx_line+16, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'CENTROCOSTO' Routine */
         returnInSub = false;
         AV57CosDsc = "";
         /* Using cursor P00DO5 */
         pr_default.execute(3, new Object[] {AV13CosCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A79COSCod = P00DO5_A79COSCod[0];
            A761COSDsc = P00DO5_A761COSDsc[0];
            AV57CosDsc = StringUtil.Trim( A79COSCod) + "  -  " + StringUtil.Trim( A761COSDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void HDO0( bool bFoot ,
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
                  getPrinter().GxDrawText("Total :", 600, Gx_line+7, 637, Gx_line+21, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47Total, "ZZZZ,ZZZ,ZZ9.9999")), 657, Gx_line+7, 764, Gx_line+22, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(655, Gx_line+3, 771, Gx_line+3, 1, 0, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 728, Gx_line+57, 767, Gx_line+72, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 708, Gx_line+40, 765, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 720, Gx_line+22, 767, Gx_line+37, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Titulo2, "")), 189, Gx_line+57, 645, Gx_line+82, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+114, 796, Gx_line+140, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 68, Gx_line+119, 109, Gx_line+133, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Descripción", 170, Gx_line+119, 239, Gx_line+133, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Actual", 680, Gx_line+119, 755, Gx_line+133, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV27Logo)) ? AV60Logo_GXI : AV27Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 15, Gx_line+5, 159, Gx_line+74) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45Titulo, "")), 189, Gx_line+32, 645, Gx_line+57, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("UNM", 581, Gx_line+119, 608, Gx_line+133, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N°", 20, Gx_line+119, 35, Gx_line+133, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Empresa, "")), 17, Gx_line+76, 325, Gx_line+94, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16EmpRUC, "")), 17, Gx_line+94, 134, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8Almacen, "")), 189, Gx_line+82, 645, Gx_line+107, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+140);
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
         AV39Session = context.GetSession();
         AV14EmpDir = "";
         AV16EmpRUC = "";
         AV36Ruta = "";
         AV27Logo = "";
         AV60Logo_GXI = "";
         AV45Titulo = "";
         AV46Titulo2 = "";
         scmdbuf = "";
         A15MVCliCod = "";
         A1287MVCCosto = "";
         A25MvAFec = DateTime.MinValue;
         A13MvATip = "";
         P00DO2_A13MvATip = new string[] {""} ;
         P00DO2_A1287MVCCosto = new string[] {""} ;
         P00DO2_A10ChoCod = new int[1] ;
         P00DO2_A16MVCliOrigen = new int[1] ;
         P00DO2_n16MVCliOrigen = new bool[] {false} ;
         P00DO2_A22MvAMov = new int[1] ;
         P00DO2_A15MVCliCod = new string[] {""} ;
         P00DO2_n15MVCliCod = new bool[] {false} ;
         P00DO2_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00DO2_A14MvACod = new string[] {""} ;
         A14MvACod = "";
         AV13CosCod = "";
         P00DO3_A14MvACod = new string[] {""} ;
         P00DO3_A13MvATip = new string[] {""} ;
         P00DO3_A16MVCliOrigen = new int[1] ;
         P00DO3_n16MVCliOrigen = new bool[] {false} ;
         P00DO3_A22MvAMov = new int[1] ;
         P00DO3_A15MVCliCod = new string[] {""} ;
         P00DO3_n15MVCliCod = new bool[] {false} ;
         P00DO3_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00DO3_A1287MVCCosto = new string[] {""} ;
         P00DO3_A1290MVCliDsc = new string[] {""} ;
         P00DO3_A1370MVSts = new string[] {""} ;
         P00DO3_A20MVPedCod = new string[] {""} ;
         P00DO3_n20MVPedCod = new bool[] {false} ;
         P00DO3_A23DocTip = new string[] {""} ;
         P00DO3_n23DocTip = new bool[] {false} ;
         P00DO3_A24DocNum = new string[] {""} ;
         P00DO3_n24DocNum = new bool[] {false} ;
         A1290MVCliDsc = "";
         A1370MVSts = "";
         A20MVPedCod = "";
         A23DocTip = "";
         A24DocNum = "";
         AV53MVCliDsc = "";
         AV54MVPedCod = "";
         AV55DocTip = "";
         AV56DocNum = "";
         P00DO4_A49UniCod = new int[1] ;
         P00DO4_A13MvATip = new string[] {""} ;
         P00DO4_A14MvACod = new string[] {""} ;
         P00DO4_A1997UniAbr = new string[] {""} ;
         P00DO4_A55ProdDsc = new string[] {""} ;
         P00DO4_A28ProdCod = new string[] {""} ;
         P00DO4_A30MvADItem = new int[1] ;
         A1997UniAbr = "";
         A55ProdDsc = "";
         A28ProdCod = "";
         AV57CosDsc = "";
         P00DO5_A79COSCod = new string[] {""} ;
         P00DO5_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV27Logo = "";
         sImgUrl = "";
         AV8Almacen = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_resumenguiaspdf__default(),
            new Object[][] {
                new Object[] {
               P00DO2_A13MvATip, P00DO2_A1287MVCCosto, P00DO2_A10ChoCod, P00DO2_A16MVCliOrigen, P00DO2_n16MVCliOrigen, P00DO2_A22MvAMov, P00DO2_A15MVCliCod, P00DO2_n15MVCliCod, P00DO2_A25MvAFec, P00DO2_A14MvACod
               }
               , new Object[] {
               P00DO3_A14MvACod, P00DO3_A13MvATip, P00DO3_A16MVCliOrigen, P00DO3_n16MVCliOrigen, P00DO3_A22MvAMov, P00DO3_A15MVCliCod, P00DO3_n15MVCliCod, P00DO3_A25MvAFec, P00DO3_A1287MVCCosto, P00DO3_A1290MVCliDsc,
               P00DO3_A1370MVSts, P00DO3_A20MVPedCod, P00DO3_n20MVPedCod, P00DO3_A23DocTip, P00DO3_n23DocTip, P00DO3_A24DocNum, P00DO3_n24DocNum
               }
               , new Object[] {
               P00DO4_A49UniCod, P00DO4_A13MvATip, P00DO4_A14MvACod, P00DO4_A1997UniAbr, P00DO4_A55ProdDsc, P00DO4_A28ProdCod, P00DO4_A30MvADItem
               }
               , new Object[] {
               P00DO5_A79COSCod, P00DO5_A761COSDsc
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
      private short AV23Flag ;
      private int AV26LinCod ;
      private int AV43SubLCod ;
      private int AV32MVCliOrigen ;
      private int AV28MovCod ;
      private int AV52ChoCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A22MvAMov ;
      private int A16MVCliOrigen ;
      private int A10ChoCod ;
      private int A49UniCod ;
      private int A30MvADItem ;
      private int AV25ITemProd ;
      private int Gx_OldLine ;
      private decimal AV40StkAct ;
      private decimal AV47Total ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV34Prodcod ;
      private string AV10CliCod ;
      private string AV31MVCCosto ;
      private string AV15Empresa ;
      private string AV14EmpDir ;
      private string AV16EmpRUC ;
      private string AV36Ruta ;
      private string AV45Titulo ;
      private string AV46Titulo2 ;
      private string scmdbuf ;
      private string A15MVCliCod ;
      private string A1287MVCCosto ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string AV13CosCod ;
      private string A1290MVCliDsc ;
      private string A1370MVSts ;
      private string A20MVPedCod ;
      private string A23DocTip ;
      private string A24DocNum ;
      private string AV53MVCliDsc ;
      private string AV54MVPedCod ;
      private string AV55DocTip ;
      private string AV56DocNum ;
      private string A1997UniAbr ;
      private string A55ProdDsc ;
      private string A28ProdCod ;
      private string AV57CosDsc ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private string AV8Almacen ;
      private DateTime AV18FDesde ;
      private DateTime AV19FHasta ;
      private DateTime A25MvAFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKDO3 ;
      private bool n16MVCliOrigen ;
      private bool n15MVCliCod ;
      private bool returnInSub ;
      private bool n20MVPedCod ;
      private bool n23DocTip ;
      private bool n24DocNum ;
      private string AV60Logo_GXI ;
      private string AV27Logo ;
      private string Logo ;
      private IGxSession AV39Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private string aP2_Prodcod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private short aP5_Flag ;
      private string aP6_CliCod ;
      private int aP7_MVCliOrigen ;
      private int aP8_MovCod ;
      private string aP9_MVCCosto ;
      private int aP10_ChoCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00DO2_A13MvATip ;
      private string[] P00DO2_A1287MVCCosto ;
      private int[] P00DO2_A10ChoCod ;
      private int[] P00DO2_A16MVCliOrigen ;
      private bool[] P00DO2_n16MVCliOrigen ;
      private int[] P00DO2_A22MvAMov ;
      private string[] P00DO2_A15MVCliCod ;
      private bool[] P00DO2_n15MVCliCod ;
      private DateTime[] P00DO2_A25MvAFec ;
      private string[] P00DO2_A14MvACod ;
      private string[] P00DO3_A14MvACod ;
      private string[] P00DO3_A13MvATip ;
      private int[] P00DO3_A16MVCliOrigen ;
      private bool[] P00DO3_n16MVCliOrigen ;
      private int[] P00DO3_A22MvAMov ;
      private string[] P00DO3_A15MVCliCod ;
      private bool[] P00DO3_n15MVCliCod ;
      private DateTime[] P00DO3_A25MvAFec ;
      private string[] P00DO3_A1287MVCCosto ;
      private string[] P00DO3_A1290MVCliDsc ;
      private string[] P00DO3_A1370MVSts ;
      private string[] P00DO3_A20MVPedCod ;
      private bool[] P00DO3_n20MVPedCod ;
      private string[] P00DO3_A23DocTip ;
      private bool[] P00DO3_n23DocTip ;
      private string[] P00DO3_A24DocNum ;
      private bool[] P00DO3_n24DocNum ;
      private int[] P00DO4_A49UniCod ;
      private string[] P00DO4_A13MvATip ;
      private string[] P00DO4_A14MvACod ;
      private string[] P00DO4_A1997UniAbr ;
      private string[] P00DO4_A55ProdDsc ;
      private string[] P00DO4_A28ProdCod ;
      private int[] P00DO4_A30MvADItem ;
      private string[] P00DO5_A79COSCod ;
      private string[] P00DO5_A761COSDsc ;
   }

   public class r_resumenguiaspdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DO2( IGxContext context ,
                                             string AV10CliCod ,
                                             int AV28MovCod ,
                                             int AV32MVCliOrigen ,
                                             string AV31MVCCosto ,
                                             int AV52ChoCod ,
                                             string A15MVCliCod ,
                                             int A22MvAMov ,
                                             int A16MVCliOrigen ,
                                             string A1287MVCCosto ,
                                             int A10ChoCod ,
                                             DateTime A25MvAFec ,
                                             DateTime AV18FDesde ,
                                             DateTime AV19FHasta ,
                                             string A13MvATip )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [MvATip], [MVCCosto], [ChoCod], [MVCliOrigen], [MvAMov], [MVCliCod] AS MVCliCod, [MvAFec], [MvACod] FROM [AGUIAS]";
         AddWhere(sWhereString, "([MvAFec] >= @AV18FDesde)");
         AddWhere(sWhereString, "([MvAFec] <= @AV19FHasta)");
         AddWhere(sWhereString, "([MvATip] = 'REM')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CliCod)) )
         {
            AddWhere(sWhereString, "([MVCliCod] = @AV10CliCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV28MovCod) )
         {
            AddWhere(sWhereString, "([MvAMov] = @AV28MovCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV32MVCliOrigen) )
         {
            AddWhere(sWhereString, "([MVCliOrigen] = @AV32MVCliOrigen)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31MVCCosto)) )
         {
            AddWhere(sWhereString, "([MVCCosto] = @AV31MVCCosto)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV52ChoCod) )
         {
            AddWhere(sWhereString, "([ChoCod] = @AV52ChoCod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MVCCosto], [MvATip]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00DO3( IGxContext context ,
                                             string AV10CliCod ,
                                             int AV28MovCod ,
                                             int AV32MVCliOrigen ,
                                             string A15MVCliCod ,
                                             int A22MvAMov ,
                                             int A16MVCliOrigen ,
                                             DateTime A25MvAFec ,
                                             DateTime AV18FDesde ,
                                             DateTime AV19FHasta ,
                                             string A1287MVCCosto ,
                                             string AV13CosCod ,
                                             string A13MvATip )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[MvACod], T1.[MvATip], T1.[MVCliOrigen], T1.[MvAMov], T1.[MVCliCod] AS MVCliCod, T1.[MvAFec], T1.[MVCCosto], T2.[CliDsc] AS MVCliDsc, T1.[MVSts], T1.[MVPedCod], T1.[DocTip], T1.[DocNum] FROM ([AGUIAS] T1 LEFT JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[MVCliCod])";
         AddWhere(sWhereString, "(T1.[MvATip] = 'REM')");
         AddWhere(sWhereString, "(T1.[MvAFec] >= @AV18FDesde)");
         AddWhere(sWhereString, "(T1.[MvAFec] <= @AV19FHasta)");
         AddWhere(sWhereString, "(T1.[MVCCosto] = @AV13CosCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[MVCliCod] = @AV10CliCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV28MovCod) )
         {
            AddWhere(sWhereString, "(T1.[MvAMov] = @AV28MovCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV32MVCliOrigen) )
         {
            AddWhere(sWhereString, "(T1.[MVCliOrigen] = @AV32MVCliOrigen)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[MvATip], T1.[MvACod]";
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
                     return conditional_P00DO2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] );
               case 1 :
                     return conditional_P00DO3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
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
          Object[] prmP00DO4;
          prmP00DO4 = new Object[] {
          new ParDef("@MvATip",GXType.NChar,3,0) ,
          new ParDef("@MvACod",GXType.NChar,12,0)
          };
          Object[] prmP00DO5;
          prmP00DO5 = new Object[] {
          new ParDef("@AV13CosCod",GXType.NChar,10,0)
          };
          Object[] prmP00DO2;
          prmP00DO2 = new Object[] {
          new ParDef("@AV18FDesde",GXType.Date,8,0) ,
          new ParDef("@AV19FHasta",GXType.Date,8,0) ,
          new ParDef("@AV10CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV28MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV32MVCliOrigen",GXType.Int32,6,0) ,
          new ParDef("@AV31MVCCosto",GXType.NChar,10,0) ,
          new ParDef("@AV52ChoCod",GXType.Int32,6,0)
          };
          Object[] prmP00DO3;
          prmP00DO3 = new Object[] {
          new ParDef("@AV18FDesde",GXType.Date,8,0) ,
          new ParDef("@AV19FHasta",GXType.Date,8,0) ,
          new ParDef("@AV13CosCod",GXType.NChar,10,0) ,
          new ParDef("@AV10CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV28MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV32MVCliOrigen",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DO2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DO3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DO3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DO4", "SELECT T2.[UniCod], T1.[MvATip], T1.[MvACod], T3.[UniAbr], T2.[ProdDsc], T1.[ProdCod], T1.[MvADItem] FROM (([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) WHERE T1.[MvATip] = @MvATip and T1.[MvACod] = @MvACod ORDER BY T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DO4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DO5", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV13CosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DO5,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 12);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 10);
                ((string[]) buf[9])[0] = rslt.getString(8, 100);
                ((string[]) buf[10])[0] = rslt.getString(9, 1);
                ((string[]) buf[11])[0] = rslt.getString(10, 10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((string[]) buf[15])[0] = rslt.getString(12, 12);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
