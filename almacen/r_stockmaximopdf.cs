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
   public class r_stockmaximopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "almacen.r_stockmaximopdf.aspx")), "almacen.r_stockmaximopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "almacen.r_stockmaximopdf.aspx")))) ;
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
               AV8LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV20SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
                  AV10Prodcod = GetPar( "Prodcod");
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

      public r_stockmaximopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_stockmaximopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SublCod ,
                           ref string aP2_Prodcod )
      {
         this.AV8LinCod = aP0_LinCod;
         this.AV20SublCod = aP1_SublCod;
         this.AV10Prodcod = aP2_Prodcod;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV8LinCod;
         aP1_SublCod=this.AV20SublCod;
         aP2_Prodcod=this.AV10Prodcod;
      }

      public string executeUdp( ref int aP0_LinCod ,
                                ref int aP1_SublCod )
      {
         execute(ref aP0_LinCod, ref aP1_SublCod, ref aP2_Prodcod);
         return AV10Prodcod ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SublCod ,
                                 ref string aP2_Prodcod )
      {
         r_stockmaximopdf objr_stockmaximopdf;
         objr_stockmaximopdf = new r_stockmaximopdf();
         objr_stockmaximopdf.AV8LinCod = aP0_LinCod;
         objr_stockmaximopdf.AV20SublCod = aP1_SublCod;
         objr_stockmaximopdf.AV10Prodcod = aP2_Prodcod;
         objr_stockmaximopdf.context.SetSubmitInitialConfig(context);
         objr_stockmaximopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_stockmaximopdf);
         aP0_LinCod=this.AV8LinCod;
         aP1_SublCod=this.AV20SublCod;
         aP2_Prodcod=this.AV10Prodcod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_stockmaximopdf)stateInfo).executePrivate();
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
            AV21Empresa = AV26Session.Get("Empresa");
            AV22EmpDir = AV26Session.Get("EmpDir");
            AV23EmpRUC = AV26Session.Get("EmpRUC");
            AV24Ruta = AV26Session.Get("RUTA") + "/Logo.jpg";
            AV25Logo = AV24Ruta;
            AV30Logo_GXI = GXDbFile.PathToUrl( AV24Ruta);
            AV12Titulo = "Productos Encima de Stock Maximo";
            AV16Codigo = "";
            AV15Producto = "";
            AV17StkMax = 0.00m;
            AV18StkAct = 0.00m;
            AV19StkDif = 0.00m;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8LinCod ,
                                                 AV20SublCod ,
                                                 AV10Prodcod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A28ProdCod ,
                                                 A1716ProdStkMax ,
                                                 A1718ProdSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00852 */
            pr_default.execute(0, new Object[] {AV8LinCod, AV20SublCod, AV10Prodcod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1718ProdSts = P00852_A1718ProdSts[0];
               A1716ProdStkMax = P00852_A1716ProdStkMax[0];
               A28ProdCod = P00852_A28ProdCod[0];
               A51SublCod = P00852_A51SublCod[0];
               n51SublCod = P00852_n51SublCod[0];
               A52LinCod = P00852_A52LinCod[0];
               A55ProdDsc = P00852_A55ProdDsc[0];
               AV16Codigo = A28ProdCod;
               AV15Producto = A55ProdDsc;
               AV17StkMax = A1716ProdStkMax;
               AV18StkAct = 0.00m;
               AV27StockA = 0.00m;
               /* Execute user subroutine: 'VALIDASTOCK' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( AV18StkAct > AV17StkMax )
               {
                  H850( false, 21) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 4, Gx_line+1, 118, Gx_line+21, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 119, Gx_line+0, 498, Gx_line+20, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Stock Maximo", 522, Gx_line+3, 606, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17StkMax, "ZZZZZZ,ZZZ,ZZ9.99")), 639, Gx_line+3, 746, Gx_line+18, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+21);
                  /* Using cursor P00853 */
                  pr_default.execute(1, new Object[] {AV16Codigo});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A28ProdCod = P00853_A28ProdCod[0];
                     A436AlmDsc = P00853_A436AlmDsc[0];
                     A63AlmCod = P00853_A63AlmCod[0];
                     A1882StkSal = P00853_A1882StkSal[0];
                     A1881StkIng = P00853_A1881StkIng[0];
                     A436AlmDsc = P00853_A436AlmDsc[0];
                     A1880StkAct = (decimal)(A1881StkIng-A1882StkSal);
                     AV11Almacen = A436AlmDsc;
                     AV18StkAct = A1880StkAct;
                     AV27StockA = (decimal)(AV27StockA+AV18StkAct);
                     H850( false, 20) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18StkAct, "ZZZZZZ,ZZZ,ZZ9.99")), 639, Gx_line+3, 746, Gx_line+18, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Almacen, "")), 230, Gx_line+3, 574, Gx_line+17, 2, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                     pr_default.readNext(1);
                  }
                  pr_default.close(1);
                  AV19StkDif = (decimal)(AV27StockA-AV17StkMax);
                  H850( false, 23) ;
                  getPrinter().GxDrawLine(625, Gx_line+2, 790, Gx_line+2, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Diferencia de Exceso", 483, Gx_line+6, 605, Gx_line+20, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19StkDif, "ZZZZZZ,ZZZ,ZZ9.99")), 639, Gx_line+5, 746, Gx_line+20, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+23);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            H850( false, 25) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+25);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H850( true, 0) ;
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
         /* 'VALIDASTOCK' Routine */
         returnInSub = false;
         /* Using cursor P00854 */
         pr_default.execute(2, new Object[] {AV16Codigo});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A28ProdCod = P00854_A28ProdCod[0];
            A63AlmCod = P00854_A63AlmCod[0];
            A1882StkSal = P00854_A1882StkSal[0];
            A1881StkIng = P00854_A1881StkIng[0];
            A1880StkAct = (decimal)(A1881StkIng-A1882StkSal);
            AV18StkAct = (decimal)(AV18StkAct+A1880StkAct);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void H850( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 663, Gx_line+40, 695, Gx_line+54, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 663, Gx_line+57, 707, Gx_line+71, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 663, Gx_line+22, 702, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 730, Gx_line+57, 769, Gx_line+72, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 710, Gx_line+40, 767, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 722, Gx_line+22, 769, Gx_line+37, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Titulo, "")), 189, Gx_line+72, 633, Gx_line+97, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+120, 796, Gx_line+146, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 23, Gx_line+124, 64, Gx_line+138, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Descripción", 125, Gx_line+124, 194, Gx_line+138, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Almacen", 314, Gx_line+124, 366, Gx_line+138, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Actual", 676, Gx_line+124, 751, Gx_line+138, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV25Logo)) ? AV30Logo_GXI : AV25Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 8, Gx_line+20, 163, Gx_line+99) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+146);
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
         AV21Empresa = "";
         AV26Session = context.GetSession();
         AV22EmpDir = "";
         AV23EmpRUC = "";
         AV24Ruta = "";
         AV25Logo = "";
         AV30Logo_GXI = "";
         AV12Titulo = "";
         AV16Codigo = "";
         AV15Producto = "";
         scmdbuf = "";
         A28ProdCod = "";
         P00852_A1718ProdSts = new short[1] ;
         P00852_A1716ProdStkMax = new decimal[1] ;
         P00852_A28ProdCod = new string[] {""} ;
         P00852_A51SublCod = new int[1] ;
         P00852_n51SublCod = new bool[] {false} ;
         P00852_A52LinCod = new int[1] ;
         P00852_A55ProdDsc = new string[] {""} ;
         A55ProdDsc = "";
         P00853_A28ProdCod = new string[] {""} ;
         P00853_A436AlmDsc = new string[] {""} ;
         P00853_A63AlmCod = new int[1] ;
         P00853_A1882StkSal = new decimal[1] ;
         P00853_A1881StkIng = new decimal[1] ;
         A436AlmDsc = "";
         AV11Almacen = "";
         P00854_A28ProdCod = new string[] {""} ;
         P00854_A63AlmCod = new int[1] ;
         P00854_A1882StkSal = new decimal[1] ;
         P00854_A1881StkIng = new decimal[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV25Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_stockmaximopdf__default(),
            new Object[][] {
                new Object[] {
               P00852_A1718ProdSts, P00852_A1716ProdStkMax, P00852_A28ProdCod, P00852_A51SublCod, P00852_n51SublCod, P00852_A52LinCod, P00852_A55ProdDsc
               }
               , new Object[] {
               P00853_A28ProdCod, P00853_A436AlmDsc, P00853_A63AlmCod, P00853_A1882StkSal, P00853_A1881StkIng
               }
               , new Object[] {
               P00854_A28ProdCod, P00854_A63AlmCod, P00854_A1882StkSal, P00854_A1881StkIng
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
      private short A1718ProdSts ;
      private int AV8LinCod ;
      private int AV20SublCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int Gx_OldLine ;
      private int A63AlmCod ;
      private decimal AV17StkMax ;
      private decimal AV18StkAct ;
      private decimal AV19StkDif ;
      private decimal A1716ProdStkMax ;
      private decimal AV27StockA ;
      private decimal A1882StkSal ;
      private decimal A1881StkIng ;
      private decimal A1880StkAct ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10Prodcod ;
      private string AV21Empresa ;
      private string AV22EmpDir ;
      private string AV23EmpRUC ;
      private string AV24Ruta ;
      private string AV12Titulo ;
      private string AV16Codigo ;
      private string AV15Producto ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A436AlmDsc ;
      private string AV11Almacen ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private string AV30Logo_GXI ;
      private string AV25Logo ;
      private string Logo ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SublCod ;
      private string aP2_Prodcod ;
      private IDataStoreProvider pr_default ;
      private short[] P00852_A1718ProdSts ;
      private decimal[] P00852_A1716ProdStkMax ;
      private string[] P00852_A28ProdCod ;
      private int[] P00852_A51SublCod ;
      private bool[] P00852_n51SublCod ;
      private int[] P00852_A52LinCod ;
      private string[] P00852_A55ProdDsc ;
      private string[] P00853_A28ProdCod ;
      private string[] P00853_A436AlmDsc ;
      private int[] P00853_A63AlmCod ;
      private decimal[] P00853_A1882StkSal ;
      private decimal[] P00853_A1881StkIng ;
      private string[] P00854_A28ProdCod ;
      private int[] P00854_A63AlmCod ;
      private decimal[] P00854_A1882StkSal ;
      private decimal[] P00854_A1881StkIng ;
   }

   public class r_stockmaximopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00852( IGxContext context ,
                                             int AV8LinCod ,
                                             int AV20SublCod ,
                                             string AV10Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A28ProdCod ,
                                             decimal A1716ProdStkMax ,
                                             short A1718ProdSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ProdSts], [ProdStkMax], [ProdCod], [SublCod], [LinCod], [ProdDsc] FROM [APRODUCTOS]";
         AddWhere(sWhereString, "([ProdStkMax] > 0)");
         AddWhere(sWhereString, "([ProdSts] = 1)");
         if ( ! (0==AV8LinCod) )
         {
            AddWhere(sWhereString, "([LinCod] = @AV8LinCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV20SublCod) )
         {
            AddWhere(sWhereString, "([SublCod] = @AV20SublCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Prodcod)) )
         {
            AddWhere(sWhereString, "([ProdCod] = @AV10Prodcod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProdCod]";
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
                     return conditional_P00852(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (short)dynConstraints[7] );
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
          Object[] prmP00853;
          prmP00853 = new Object[] {
          new ParDef("@AV16Codigo",GXType.NChar,15,0)
          };
          Object[] prmP00854;
          prmP00854 = new Object[] {
          new ParDef("@AV16Codigo",GXType.NChar,15,0)
          };
          Object[] prmP00852;
          prmP00852 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV20SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00852", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00852,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00853", "SELECT T1.[ProdCod], T2.[AlmDsc], T1.[AlmCod], T1.[StkSal], T1.[StkIng] FROM ([ASTOCKACTUAL] T1 INNER JOIN [CALMACEN] T2 ON T2.[AlmCod] = T1.[AlmCod]) WHERE T1.[ProdCod] = @AV16Codigo ORDER BY T1.[AlmCod], T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00853,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00854", "SELECT [ProdCod], [AlmCod], [StkSal], [StkIng] FROM [ASTOCKACTUAL] WHERE [ProdCod] = @AV16Codigo ORDER BY [AlmCod], [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00854,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
       }
    }

 }

}
