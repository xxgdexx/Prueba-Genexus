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
   public class rrreportepedidoscomparativoprecios : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrreportepedidoscomparativoprecios.aspx")), "rrreportepedidoscomparativoprecios.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrreportepedidoscomparativoprecios.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "cCliCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV12cCliCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV15cProdCod = GetPar( "cProdCod");
                  AV25FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV26FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public rrreportepedidoscomparativoprecios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrreportepedidoscomparativoprecios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_cCliCod ,
                           ref string aP1_cProdCod ,
                           ref DateTime aP2_FDesde ,
                           ref DateTime aP3_FHasta )
      {
         this.AV12cCliCod = aP0_cCliCod;
         this.AV15cProdCod = aP1_cProdCod;
         this.AV25FDesde = aP2_FDesde;
         this.AV26FHasta = aP3_FHasta;
         initialize();
         executePrivate();
         aP0_cCliCod=this.AV12cCliCod;
         aP1_cProdCod=this.AV15cProdCod;
         aP2_FDesde=this.AV25FDesde;
         aP3_FHasta=this.AV26FHasta;
      }

      public DateTime executeUdp( ref string aP0_cCliCod ,
                                  ref string aP1_cProdCod ,
                                  ref DateTime aP2_FDesde )
      {
         execute(ref aP0_cCliCod, ref aP1_cProdCod, ref aP2_FDesde, ref aP3_FHasta);
         return AV26FHasta ;
      }

      public void executeSubmit( ref string aP0_cCliCod ,
                                 ref string aP1_cProdCod ,
                                 ref DateTime aP2_FDesde ,
                                 ref DateTime aP3_FHasta )
      {
         rrreportepedidoscomparativoprecios objrrreportepedidoscomparativoprecios;
         objrrreportepedidoscomparativoprecios = new rrreportepedidoscomparativoprecios();
         objrrreportepedidoscomparativoprecios.AV12cCliCod = aP0_cCliCod;
         objrrreportepedidoscomparativoprecios.AV15cProdCod = aP1_cProdCod;
         objrrreportepedidoscomparativoprecios.AV25FDesde = aP2_FDesde;
         objrrreportepedidoscomparativoprecios.AV26FHasta = aP3_FHasta;
         objrrreportepedidoscomparativoprecios.context.SetSubmitInitialConfig(context);
         objrrreportepedidoscomparativoprecios.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrreportepedidoscomparativoprecios);
         aP0_cCliCod=this.AV12cCliCod;
         aP1_cProdCod=this.AV15cProdCod;
         aP2_FDesde=this.AV25FDesde;
         aP3_FHasta=this.AV26FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrreportepedidoscomparativoprecios)stateInfo).executePrivate();
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
            AV21Empresa = AV63Session.Get("Empresa");
            AV20EmpDir = AV63Session.Get("EmpDir");
            AV22EmpRUC = AV63Session.Get("EmpRUC");
            AV61Ruta = AV63Session.Get("RUTA") + "/Logo.jpg";
            AV36Logo = AV61Ruta;
            AV78Logo_GXI = GXDbFile.PathToUrl( AV61Ruta);
            AV27Filtro1 = "Del : " + context.localUtil.DToC( AV25FDesde, 2, "/") + " al : " + context.localUtil.DToC( AV26FHasta, 2, "/");
            AV28Filtro2 = "Todos";
            AV29Filtro3 = "Todos";
            /* Using cursor P00DY2 */
            pr_default.execute(0, new Object[] {AV12cCliCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A45CliCod = P00DY2_A45CliCod[0];
               A161CliDsc = P00DY2_A161CliDsc[0];
               AV28Filtro2 = StringUtil.Trim( A161CliDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00DY3 */
            pr_default.execute(1, new Object[] {AV15cProdCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = P00DY3_A28ProdCod[0];
               A1679ProdCmp = P00DY3_A1679ProdCmp[0];
               A55ProdDsc = P00DY3_A55ProdDsc[0];
               AV29Filtro3 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV34Item = 0;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV12cCliCod ,
                                                 AV15cProdCod ,
                                                 A45CliCod ,
                                                 A28ProdCod ,
                                                 A215PedFec ,
                                                 AV25FDesde ,
                                                 AV26FHasta ,
                                                 A1606PedSts } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00DY4 */
            pr_default.execute(2, new Object[] {AV25FDesde, AV26FHasta, AV12cCliCod, AV15cProdCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A49UniCod = P00DY4_A49UniCod[0];
               A1606PedSts = P00DY4_A1606PedSts[0];
               A215PedFec = P00DY4_A215PedFec[0];
               A28ProdCod = P00DY4_A28ProdCod[0];
               A45CliCod = P00DY4_A45CliCod[0];
               A161CliDsc = P00DY4_A161CliDsc[0];
               A159TipCCod = P00DY4_A159TipCCod[0];
               A52LinCod = P00DY4_A52LinCod[0];
               A51SublCod = P00DY4_A51SublCod[0];
               n51SublCod = P00DY4_n51SublCod[0];
               A55ProdDsc = P00DY4_A55ProdDsc[0];
               A1997UniAbr = P00DY4_A1997UniAbr[0];
               A213PedLisp = P00DY4_A213PedLisp[0];
               n213PedLisp = P00DY4_n213PedLisp[0];
               A1554PedDCan = P00DY4_A1554PedDCan[0];
               A1553PedDPre = P00DY4_A1553PedDPre[0];
               A1555PedDDct = P00DY4_A1555PedDDct[0];
               A210PedCod = P00DY4_A210PedCod[0];
               A216PedDItem = P00DY4_A216PedDItem[0];
               A49UniCod = P00DY4_A49UniCod[0];
               A52LinCod = P00DY4_A52LinCod[0];
               A51SublCod = P00DY4_A51SublCod[0];
               n51SublCod = P00DY4_n51SublCod[0];
               A1997UniAbr = P00DY4_A1997UniAbr[0];
               A1606PedSts = P00DY4_A1606PedSts[0];
               A215PedFec = P00DY4_A215PedFec[0];
               A45CliCod = P00DY4_A45CliCod[0];
               A213PedLisp = P00DY4_A213PedLisp[0];
               n213PedLisp = P00DY4_n213PedLisp[0];
               A161CliDsc = P00DY4_A161CliDsc[0];
               A159TipCCod = P00DY4_A159TipCCod[0];
               AV43PedCod = A210PedCod;
               AV52PedFec = A215PedFec;
               AV13CliCod = A45CliCod;
               AV14CliDsc = A161CliDsc;
               AV65TipCCod = A159TipCCod;
               AV35LinCod = A52LinCod;
               AV64SubLCod = A51SublCod;
               AV59ProdCod = A28ProdCod;
               AV9ProdDsc = A55ProdDsc;
               AV10UniAbr = A1997UniAbr;
               AV53PedLisp = A213PedLisp;
               AV44PedDCan = A1554PedDCan;
               AV50PedDPre = A1553PedDPre;
               AV47PedDDct = A1555PedDDct;
               GXt_decimal1 = AV57Precio;
               new GeneXus.Programs.generales.rrbuscaprecios(context ).execute( ref  AV59ProdCod, ref  AV53PedLisp, ref  AV13CliCod, out  GXt_decimal1) ;
               AV57Precio = GXt_decimal1;
               AV16Descuento = 0;
               AV55Por1 = (!(Convert.ToDecimal(0)==AV50PedDPre) ? NumberUtil.Round( AV57Precio/ (decimal)(AV50PedDPre)*100, 2)-100 : (decimal)(0));
               AV56Por2 = (!(Convert.ToDecimal(0)==AV47PedDDct) ? NumberUtil.Round( AV16Descuento/ (decimal)(AV47PedDDct)*100, 2)-100 : (decimal)(0));
               if ( ! (0==AV53PedLisp) )
               {
                  if ( ! (Convert.ToDecimal(0)==AV55Por1) || ! (Convert.ToDecimal(0)==AV56Por2) )
                  {
                     HDY0( false, 18) ;
                     getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43PedCod, "")), 5, Gx_line+2, 70, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV52PedFec, "99/99/99"), 69, Gx_line+2, 112, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59ProdCod, "@!")), 362, Gx_line+2, 436, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9ProdDsc, "")), 438, Gx_line+2, 654, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14CliDsc, "")), 114, Gx_line+2, 353, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44PedDCan, "ZZZZZZ,ZZZ,ZZ9.99")), 639, Gx_line+2, 713, Gx_line+16, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10UniAbr, "")), 727, Gx_line+2, 761, Gx_line+16, 1, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50PedDPre, "ZZZZ,ZZZ,ZZ9.9999")), 747, Gx_line+2, 821, Gx_line+16, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57Precio, "ZZZZ,ZZZ,ZZ9.9999")), 808, Gx_line+2, 882, Gx_line+16, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55Por1, "ZZ9.99")), 890, Gx_line+2, 928, Gx_line+16, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47PedDDct, "ZZZZZZ,ZZZ,ZZ9.99")), 923, Gx_line+2, 983, Gx_line+16, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16Descuento, "ZZ9.99")), 965, Gx_line+2, 1039, Gx_line+16, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56Por2, "ZZ9.99")), 1056, Gx_line+2, 1092, Gx_line+16, 2, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+18);
                     AV34Item = (int)(AV34Item+1);
                  }
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            HDY0( false, 41) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Lineas Pedidos con Diferencia", 431, Gx_line+8, 638, Gx_line+22, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34Item), "ZZZZ9")), 647, Gx_line+8, 679, Gx_line+23, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+41);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HDY0( true, 0) ;
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

      protected void HDY0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 973, Gx_line+33, 1005, Gx_line+47, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 973, Gx_line+51, 1017, Gx_line+65, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 973, Gx_line+16, 1012, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1035, Gx_line+51, 1074, Gx_line+66, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1013, Gx_line+33, 1073, Gx_line+47, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1027, Gx_line+16, 1074, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Pedido", 14, Gx_line+142, 50, Gx_line+153, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 75, Gx_line+142, 106, Gx_line+153, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+129, 1095, Gx_line+161, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 11, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Reporte de Pedidos Comparativo de precios vs Lista", 415, Gx_line+14, 824, Gx_line+33, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 378, Gx_line+142, 414, Gx_line+153, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 496, Gx_line+142, 544, Gx_line+153, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Rangos de Fecha", 415, Gx_line+48, 515, Gx_line+62, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 415, Gx_line+70, 457, Gx_line+84, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 415, Gx_line+92, 469, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Filtro1, "")), 526, Gx_line+43, 869, Gx_line+67, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Filtro2, "")), 526, Gx_line+65, 869, Gx_line+89, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Filtro3, "")), 526, Gx_line+88, 869, Gx_line+112, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV36Logo)) ? AV78Logo_GXI : AV36Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 14, Gx_line+11, 172, Gx_line+89) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cantidad", 671, Gx_line+142, 718, Gx_line+153, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("UM", 736, Gx_line+142, 754, Gx_line+153, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio", 788, Gx_line+133, 822, Gx_line+144, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22EmpRUC, "")), 14, Gx_line+106, 152, Gx_line+124, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21Empresa, "")), 14, Gx_line+89, 320, Gx_line+107, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cliente", 169, Gx_line+142, 206, Gx_line+153, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pedido", 786, Gx_line+147, 822, Gx_line+158, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio", 853, Gx_line+133, 887, Gx_line+144, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Lista", 857, Gx_line+147, 883, Gx_line+158, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("%", 907, Gx_line+133, 921, Gx_line+144, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Varic.", 898, Gx_line+147, 929, Gx_line+158, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("%", 1070, Gx_line+133, 1084, Gx_line+144, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Varic.", 1061, Gx_line+147, 1092, Gx_line+158, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Lista", 1014, Gx_line+147, 1040, Gx_line+158, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dscto", 1011, Gx_line+133, 1040, Gx_line+144, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pedido", 949, Gx_line+147, 985, Gx_line+158, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dscto", 952, Gx_line+133, 981, Gx_line+144, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+161);
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
         AV21Empresa = "";
         AV63Session = context.GetSession();
         AV20EmpDir = "";
         AV22EmpRUC = "";
         AV61Ruta = "";
         AV36Logo = "";
         AV78Logo_GXI = "";
         AV27Filtro1 = "";
         AV28Filtro2 = "";
         AV29Filtro3 = "";
         scmdbuf = "";
         P00DY2_A45CliCod = new string[] {""} ;
         P00DY2_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         P00DY3_A28ProdCod = new string[] {""} ;
         P00DY3_A1679ProdCmp = new short[1] ;
         P00DY3_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         A215PedFec = DateTime.MinValue;
         A1606PedSts = "";
         P00DY4_A49UniCod = new int[1] ;
         P00DY4_A1606PedSts = new string[] {""} ;
         P00DY4_A215PedFec = new DateTime[] {DateTime.MinValue} ;
         P00DY4_A28ProdCod = new string[] {""} ;
         P00DY4_A45CliCod = new string[] {""} ;
         P00DY4_A161CliDsc = new string[] {""} ;
         P00DY4_A159TipCCod = new int[1] ;
         P00DY4_A52LinCod = new int[1] ;
         P00DY4_A51SublCod = new int[1] ;
         P00DY4_n51SublCod = new bool[] {false} ;
         P00DY4_A55ProdDsc = new string[] {""} ;
         P00DY4_A1997UniAbr = new string[] {""} ;
         P00DY4_A213PedLisp = new int[1] ;
         P00DY4_n213PedLisp = new bool[] {false} ;
         P00DY4_A1554PedDCan = new decimal[1] ;
         P00DY4_A1553PedDPre = new decimal[1] ;
         P00DY4_A1555PedDDct = new decimal[1] ;
         P00DY4_A210PedCod = new string[] {""} ;
         P00DY4_A216PedDItem = new short[1] ;
         A1997UniAbr = "";
         A210PedCod = "";
         AV43PedCod = "";
         AV52PedFec = DateTime.MinValue;
         AV13CliCod = "";
         AV14CliDsc = "";
         AV59ProdCod = "";
         AV9ProdDsc = "";
         AV10UniAbr = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV36Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrreportepedidoscomparativoprecios__default(),
            new Object[][] {
                new Object[] {
               P00DY2_A45CliCod, P00DY2_A161CliDsc
               }
               , new Object[] {
               P00DY3_A28ProdCod, P00DY3_A1679ProdCmp, P00DY3_A55ProdDsc
               }
               , new Object[] {
               P00DY4_A49UniCod, P00DY4_A1606PedSts, P00DY4_A215PedFec, P00DY4_A28ProdCod, P00DY4_A45CliCod, P00DY4_A161CliDsc, P00DY4_A159TipCCod, P00DY4_A52LinCod, P00DY4_A51SublCod, P00DY4_n51SublCod,
               P00DY4_A55ProdDsc, P00DY4_A1997UniAbr, P00DY4_A213PedLisp, P00DY4_n213PedLisp, P00DY4_A1554PedDCan, P00DY4_A1553PedDPre, P00DY4_A1555PedDDct, P00DY4_A210PedCod, P00DY4_A216PedDItem
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
      private short A1679ProdCmp ;
      private short A216PedDItem ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV34Item ;
      private int A49UniCod ;
      private int A159TipCCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A213PedLisp ;
      private int AV65TipCCod ;
      private int AV35LinCod ;
      private int AV64SubLCod ;
      private int AV53PedLisp ;
      private int Gx_OldLine ;
      private decimal A1554PedDCan ;
      private decimal A1553PedDPre ;
      private decimal A1555PedDDct ;
      private decimal AV44PedDCan ;
      private decimal AV50PedDPre ;
      private decimal AV47PedDDct ;
      private decimal AV57Precio ;
      private decimal GXt_decimal1 ;
      private decimal AV16Descuento ;
      private decimal AV55Por1 ;
      private decimal AV56Por2 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV12cCliCod ;
      private string AV15cProdCod ;
      private string AV21Empresa ;
      private string AV20EmpDir ;
      private string AV22EmpRUC ;
      private string AV61Ruta ;
      private string AV27Filtro1 ;
      private string AV28Filtro2 ;
      private string AV29Filtro3 ;
      private string scmdbuf ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1606PedSts ;
      private string A1997UniAbr ;
      private string A210PedCod ;
      private string AV43PedCod ;
      private string AV13CliCod ;
      private string AV14CliDsc ;
      private string AV59ProdCod ;
      private string AV9ProdDsc ;
      private string AV10UniAbr ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV25FDesde ;
      private DateTime AV26FHasta ;
      private DateTime A215PedFec ;
      private DateTime AV52PedFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n51SublCod ;
      private bool n213PedLisp ;
      private string AV78Logo_GXI ;
      private string AV36Logo ;
      private string Logo ;
      private IGxSession AV63Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_cCliCod ;
      private string aP1_cProdCod ;
      private DateTime aP2_FDesde ;
      private DateTime aP3_FHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P00DY2_A45CliCod ;
      private string[] P00DY2_A161CliDsc ;
      private string[] P00DY3_A28ProdCod ;
      private short[] P00DY3_A1679ProdCmp ;
      private string[] P00DY3_A55ProdDsc ;
      private int[] P00DY4_A49UniCod ;
      private string[] P00DY4_A1606PedSts ;
      private DateTime[] P00DY4_A215PedFec ;
      private string[] P00DY4_A28ProdCod ;
      private string[] P00DY4_A45CliCod ;
      private string[] P00DY4_A161CliDsc ;
      private int[] P00DY4_A159TipCCod ;
      private int[] P00DY4_A52LinCod ;
      private int[] P00DY4_A51SublCod ;
      private bool[] P00DY4_n51SublCod ;
      private string[] P00DY4_A55ProdDsc ;
      private string[] P00DY4_A1997UniAbr ;
      private int[] P00DY4_A213PedLisp ;
      private bool[] P00DY4_n213PedLisp ;
      private decimal[] P00DY4_A1554PedDCan ;
      private decimal[] P00DY4_A1553PedDPre ;
      private decimal[] P00DY4_A1555PedDDct ;
      private string[] P00DY4_A210PedCod ;
      private short[] P00DY4_A216PedDItem ;
   }

   public class rrreportepedidoscomparativoprecios__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DY4( IGxContext context ,
                                             string AV12cCliCod ,
                                             string AV15cProdCod ,
                                             string A45CliCod ,
                                             string A28ProdCod ,
                                             DateTime A215PedFec ,
                                             DateTime AV25FDesde ,
                                             DateTime AV26FHasta ,
                                             string A1606PedSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T4.[PedSts], T4.[PedFec], T1.[ProdCod], T4.[CliCod], T5.[CliDsc], T5.[TipCCod], T2.[LinCod], T2.[SublCod], T1.[ProdDsc], T3.[UniAbr], T4.[PedLisp], T1.[PedDCan], T1.[PedDPre], T1.[PedDDct], T1.[PedCod], T1.[PedDItem] FROM (((([CLPEDIDOSDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CLPEDIDOS] T4 ON T4.[PedCod] = T1.[PedCod]) INNER JOIN [CLCLIENTES] T5 ON T5.[CliCod] = T4.[CliCod])";
         AddWhere(sWhereString, "(T4.[PedFec] >= @AV25FDesde and T4.[PedFec] <= @AV26FHasta)");
         AddWhere(sWhereString, "(Not T4.[PedSts] = 'A')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cCliCod)) )
         {
            AddWhere(sWhereString, "(T4.[CliCod] = @AV12cCliCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15cProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV15cProdCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PedCod]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P00DY4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] );
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
          Object[] prmP00DY2;
          prmP00DY2 = new Object[] {
          new ParDef("@AV12cCliCod",GXType.NChar,20,0)
          };
          Object[] prmP00DY3;
          prmP00DY3 = new Object[] {
          new ParDef("@AV15cProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DY4;
          prmP00DY4 = new Object[] {
          new ParDef("@AV25FDesde",GXType.Date,8,0) ,
          new ParDef("@AV26FHasta",GXType.Date,8,0) ,
          new ParDef("@AV12cCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV15cProdCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DY2", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV12cCliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DY2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DY3", "SELECT [ProdCod], [ProdCmp], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV15cProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DY3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DY4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DY4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 5);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
                ((string[]) buf[17])[0] = rslt.getString(16, 10);
                ((short[]) buf[18])[0] = rslt.getShort(17);
                return;
       }
    }

 }

}
