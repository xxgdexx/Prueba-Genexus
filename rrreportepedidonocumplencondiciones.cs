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
   public class rrreportepedidonocumplencondiciones : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrreportepedidonocumplencondiciones.aspx")), "rrreportepedidonocumplencondiciones.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrreportepedidonocumplencondiciones.aspx")))) ;
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
               AV8cCliCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9cConpCod = (int)(NumberUtil.Val( GetPar( "cConpCod"), "."));
                  AV21FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV22FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public rrreportepedidonocumplencondiciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrreportepedidonocumplencondiciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_cCliCod ,
                           ref int aP1_cConpCod ,
                           ref DateTime aP2_FDesde ,
                           ref DateTime aP3_FHasta )
      {
         this.AV8cCliCod = aP0_cCliCod;
         this.AV9cConpCod = aP1_cConpCod;
         this.AV21FDesde = aP2_FDesde;
         this.AV22FHasta = aP3_FHasta;
         initialize();
         executePrivate();
         aP0_cCliCod=this.AV8cCliCod;
         aP1_cConpCod=this.AV9cConpCod;
         aP2_FDesde=this.AV21FDesde;
         aP3_FHasta=this.AV22FHasta;
      }

      public DateTime executeUdp( ref string aP0_cCliCod ,
                                  ref int aP1_cConpCod ,
                                  ref DateTime aP2_FDesde )
      {
         execute(ref aP0_cCliCod, ref aP1_cConpCod, ref aP2_FDesde, ref aP3_FHasta);
         return AV22FHasta ;
      }

      public void executeSubmit( ref string aP0_cCliCod ,
                                 ref int aP1_cConpCod ,
                                 ref DateTime aP2_FDesde ,
                                 ref DateTime aP3_FHasta )
      {
         rrreportepedidonocumplencondiciones objrrreportepedidonocumplencondiciones;
         objrrreportepedidonocumplencondiciones = new rrreportepedidonocumplencondiciones();
         objrrreportepedidonocumplencondiciones.AV8cCliCod = aP0_cCliCod;
         objrrreportepedidonocumplencondiciones.AV9cConpCod = aP1_cConpCod;
         objrrreportepedidonocumplencondiciones.AV21FDesde = aP2_FDesde;
         objrrreportepedidonocumplencondiciones.AV22FHasta = aP3_FHasta;
         objrrreportepedidonocumplencondiciones.context.SetSubmitInitialConfig(context);
         objrrreportepedidonocumplencondiciones.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrreportepedidonocumplencondiciones);
         aP0_cCliCod=this.AV8cCliCod;
         aP1_cConpCod=this.AV9cConpCod;
         aP2_FDesde=this.AV21FDesde;
         aP3_FHasta=this.AV22FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrreportepedidonocumplencondiciones)stateInfo).executePrivate();
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
            AV18Empresa = AV38Session.Get("Empresa");
            AV17EmpDir = AV38Session.Get("EmpDir");
            AV19EmpRUC = AV38Session.Get("EmpRUC");
            AV37Ruta = AV38Session.Get("RUTA") + "/Logo.jpg";
            AV30Logo = AV37Ruta;
            AV42Logo_GXI = GXDbFile.PathToUrl( AV37Ruta);
            AV23Filtro1 = "Del : " + context.localUtil.DToC( AV21FDesde, 2, "/") + " al : " + context.localUtil.DToC( AV22FHasta, 2, "/");
            AV24Filtro2 = "Todos";
            AV25Filtro3 = "Todos";
            /* Using cursor P00E02 */
            pr_default.execute(0, new Object[] {AV8cCliCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A45CliCod = P00E02_A45CliCod[0];
               A161CliDsc = P00E02_A161CliDsc[0];
               AV24Filtro2 = StringUtil.Trim( A161CliDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00E03 */
            pr_default.execute(1, new Object[] {AV9cConpCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A137Conpcod = P00E03_A137Conpcod[0];
               A753ConpDsc = P00E03_A753ConpDsc[0];
               AV25Filtro3 = A753ConpDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV28Item = 0;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV8cCliCod ,
                                                 AV9cConpCod ,
                                                 A45CliCod ,
                                                 A137Conpcod ,
                                                 A215PedFec ,
                                                 AV21FDesde ,
                                                 AV22FHasta ,
                                                 A613CliLim ,
                                                 A1606PedSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL
                                                 }
            });
            /* Using cursor P00E04 */
            pr_default.execute(2, new Object[] {AV21FDesde, AV22FHasta, AV8cCliCod, AV9cConpCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               BRKE05 = false;
               A161CliDsc = P00E04_A161CliDsc[0];
               A45CliCod = P00E04_A45CliCod[0];
               A1606PedSts = P00E04_A1606PedSts[0];
               A613CliLim = P00E04_A613CliLim[0];
               A215PedFec = P00E04_A215PedFec[0];
               A137Conpcod = P00E04_A137Conpcod[0];
               A753ConpDsc = P00E04_A753ConpDsc[0];
               A210PedCod = P00E04_A210PedCod[0];
               A161CliDsc = P00E04_A161CliDsc[0];
               A613CliLim = P00E04_A613CliLim[0];
               A137Conpcod = P00E04_A137Conpcod[0];
               A753ConpDsc = P00E04_A753ConpDsc[0];
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00E04_A45CliCod[0], A45CliCod) == 0 ) )
               {
                  BRKE05 = false;
                  A161CliDsc = P00E04_A161CliDsc[0];
                  A210PedCod = P00E04_A210PedCod[0];
                  A161CliDsc = P00E04_A161CliDsc[0];
                  BRKE05 = true;
                  pr_default.readNext(2);
               }
               AV10CliCod = A45CliCod;
               AV11CliDsc = A161CliDsc;
               AV12CliLim = A613CliLim;
               AV13ConpCod = A137Conpcod;
               AV14ConpDsc = A753ConpDsc;
               AV39Total = 0.00m;
               /* Execute user subroutine: 'DETALLECLIENTE' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! BRKE05 )
               {
                  BRKE05 = true;
                  pr_default.readNext(2);
               }
            }
            pr_default.close(2);
            HE00( false, 41) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Lineas Pedidos con Diferencia", 431, Gx_line+8, 638, Gx_line+22, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV28Item), "ZZZZ9")), 647, Gx_line+8, 679, Gx_line+23, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+41);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HE00( true, 0) ;
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
         /* 'DETALLECLIENTE' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV9cConpCod ,
                                              A137Conpcod ,
                                              A1606PedSts ,
                                              AV10CliCod ,
                                              AV21FDesde ,
                                              A45CliCod ,
                                              A215PedFec ,
                                              AV22FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00E06 */
         pr_default.execute(3, new Object[] {AV10CliCod, AV21FDesde, AV22FHasta, AV9cConpCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A45CliCod = P00E06_A45CliCod[0];
            A1606PedSts = P00E06_A1606PedSts[0];
            A215PedFec = P00E06_A215PedFec[0];
            A137Conpcod = P00E06_A137Conpcod[0];
            A210PedCod = P00E06_A210PedCod[0];
            A214PedConp = P00E06_A214PedConp[0];
            A1548PedConpDsc = P00E06_A1548PedConpDsc[0];
            A1603PedRedondeo = P00E06_A1603PedRedondeo[0];
            A1602PedPorIVA = P00E06_A1602PedPorIVA[0];
            A1590PedPorDsct = P00E06_A1590PedPorDsct[0];
            A1589PedSubExonerado = P00E06_A1589PedSubExonerado[0];
            A1584PedSubSelectivo = P00E06_A1584PedSubSelectivo[0];
            A1583PedSubAfe = P00E06_A1583PedSubAfe[0];
            A1582PedSubIna = P00E06_A1582PedSubIna[0];
            A1598PedICBPER = P00E06_A1598PedICBPER[0];
            A137Conpcod = P00E06_A137Conpcod[0];
            A1589PedSubExonerado = P00E06_A1589PedSubExonerado[0];
            A1584PedSubSelectivo = P00E06_A1584PedSubSelectivo[0];
            A1583PedSubAfe = P00E06_A1583PedSubAfe[0];
            A1582PedSubIna = P00E06_A1582PedSubIna[0];
            A1548PedConpDsc = P00E06_A1548PedConpDsc[0];
            A1581PedSubT = (decimal)(A1582PedSubIna+A1583PedSubAfe+A1584PedSubSelectivo+A1589PedSubExonerado);
            A1580PedDsct = (decimal)(((A1581PedSubT*A1590PedPorDsct)/ (decimal)(100)));
            A1601PedIVA = (decimal)((((A1583PedSubAfe+A1584PedSubSelectivo-A1580PedDsct)*A1602PedPorIVA)/ (decimal)(100))+A1603PedRedondeo);
            A1610PedTotal = (decimal)((A1581PedSubT-A1580PedDsct)+A1601PedIVA+A1598PedICBPER);
            AV31PedCod = A210PedCod;
            AV34PedFec = A215PedFec;
            AV35PedTotal = A1610PedTotal;
            AV32PedConp = A214PedConp;
            AV33PedConpDsc = A1548PedConpDsc;
            AV39Total = A1610PedTotal;
            if ( ! ( AV13ConpCod == AV32PedConp ) )
            {
               AV16Deuda = ((AV12CliLim<AV35PedTotal) ? AV35PedTotal : (decimal)(0));
               AV20Excedente = ((AV12CliLim<AV35PedTotal) ? AV35PedTotal-AV12CliLim : (decimal)(0));
               AV36PorEx = (!(Convert.ToDecimal(0)==AV12CliLim) ? NumberUtil.Round( AV35PedTotal/ (decimal)(AV12CliLim)*100, 2)-100 : (decimal)(0));
               if ( ( AV36PorEx > Convert.ToDecimal( 0 )) )
               {
                  HE00( false, 17) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31PedCod, "")), 5, Gx_line+2, 70, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV34PedFec, "99/99/99"), 69, Gx_line+2, 112, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11CliDsc, "")), 114, Gx_line+2, 397, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV12CliLim, "ZZZZZZZZZZZ9.99")), 397, Gx_line+2, 476, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35PedTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 519, Gx_line+2, 609, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14ConpDsc, "")), 774, Gx_line+2, 938, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33PedConpDsc, "")), 944, Gx_line+2, 1092, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20Excedente, "ZZZZZZ,ZZZ,ZZ9.99")), 600, Gx_line+2, 690, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36PorEx, "ZZ9.99")), 709, Gx_line+2, 741, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16Deuda, "ZZZZZZ,ZZZ,ZZ9.99")), 444, Gx_line+2, 534, Gx_line+15, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
                  AV28Item = (int)(AV28Item+1);
               }
            }
            else
            {
               AV16Deuda = ((AV12CliLim<AV35PedTotal) ? AV35PedTotal : (decimal)(0));
               AV20Excedente = ((AV12CliLim<AV35PedTotal) ? AV35PedTotal-AV12CliLim : (decimal)(0));
               AV36PorEx = (!(Convert.ToDecimal(0)==AV12CliLim) ? NumberUtil.Round( AV35PedTotal/ (decimal)(AV12CliLim)*100, 2)-100 : (decimal)(0));
               if ( ( AV36PorEx > Convert.ToDecimal( 0 )) )
               {
                  HE00( false, 17) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31PedCod, "")), 5, Gx_line+2, 70, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV34PedFec, "99/99/99"), 69, Gx_line+2, 112, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11CliDsc, "")), 114, Gx_line+2, 397, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV12CliLim, "ZZZZZZZZZZZ9.99")), 397, Gx_line+2, 476, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35PedTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 519, Gx_line+2, 609, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14ConpDsc, "")), 774, Gx_line+2, 938, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33PedConpDsc, "")), 944, Gx_line+2, 1092, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20Excedente, "ZZZZZZ,ZZZ,ZZ9.99")), 600, Gx_line+2, 690, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36PorEx, "ZZ9.99")), 709, Gx_line+2, 741, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16Deuda, "ZZZZZZ,ZZZ,ZZ9.99")), 444, Gx_line+2, 534, Gx_line+15, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
                  AV28Item = (int)(AV28Item+1);
               }
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void HE00( bool bFoot ,
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
               getPrinter().GxDrawText("Pedido", 14, Gx_line+141, 50, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 75, Gx_line+141, 106, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+129, 1095, Gx_line+161, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 11, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Reporte de Pedidos Aprobados No Cumplen Condiciones", 415, Gx_line+14, 824, Gx_line+33, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Rangos de Fecha", 415, Gx_line+48, 515, Gx_line+62, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 415, Gx_line+70, 457, Gx_line+84, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Condición Pago", 415, Gx_line+92, 505, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro1, "")), 522, Gx_line+43, 820, Gx_line+67, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro2, "")), 522, Gx_line+65, 820, Gx_line+89, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Filtro3, "")), 522, Gx_line+88, 820, Gx_line+112, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV30Logo)) ? AV42Logo_GXI : AV30Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 14, Gx_line+11, 172, Gx_line+89) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19EmpRUC, "")), 14, Gx_line+106, 152, Gx_line+124, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Empresa, "")), 14, Gx_line+89, 320, Gx_line+107, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cliente", 169, Gx_line+141, 206, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Limite Credito", 407, Gx_line+141, 482, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Deuda", 498, Gx_line+141, 531, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Excedente", 633, Gx_line+141, 687, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Excedente", 700, Gx_line+146, 754, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("%", 718, Gx_line+132, 732, Gx_line+143, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Condición Pago", 802, Gx_line+141, 882, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Condición Pago Pedido", 958, Gx_line+141, 1077, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Valor Pedido", 546, Gx_line+141, 614, Gx_line+152, 0+256, 0, 0, 0) ;
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
         AV18Empresa = "";
         AV38Session = context.GetSession();
         AV17EmpDir = "";
         AV19EmpRUC = "";
         AV37Ruta = "";
         AV30Logo = "";
         AV42Logo_GXI = "";
         AV23Filtro1 = "";
         AV24Filtro2 = "";
         AV25Filtro3 = "";
         scmdbuf = "";
         P00E02_A45CliCod = new string[] {""} ;
         P00E02_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         P00E03_A137Conpcod = new int[1] ;
         P00E03_A753ConpDsc = new string[] {""} ;
         A753ConpDsc = "";
         A215PedFec = DateTime.MinValue;
         A1606PedSts = "";
         P00E04_A161CliDsc = new string[] {""} ;
         P00E04_A45CliCod = new string[] {""} ;
         P00E04_A1606PedSts = new string[] {""} ;
         P00E04_A613CliLim = new decimal[1] ;
         P00E04_A215PedFec = new DateTime[] {DateTime.MinValue} ;
         P00E04_A137Conpcod = new int[1] ;
         P00E04_A753ConpDsc = new string[] {""} ;
         P00E04_A210PedCod = new string[] {""} ;
         A210PedCod = "";
         AV10CliCod = "";
         AV11CliDsc = "";
         AV14ConpDsc = "";
         P00E06_A45CliCod = new string[] {""} ;
         P00E06_A1606PedSts = new string[] {""} ;
         P00E06_A215PedFec = new DateTime[] {DateTime.MinValue} ;
         P00E06_A137Conpcod = new int[1] ;
         P00E06_A210PedCod = new string[] {""} ;
         P00E06_A214PedConp = new int[1] ;
         P00E06_A1548PedConpDsc = new string[] {""} ;
         P00E06_A1603PedRedondeo = new decimal[1] ;
         P00E06_A1602PedPorIVA = new decimal[1] ;
         P00E06_A1590PedPorDsct = new decimal[1] ;
         P00E06_A1589PedSubExonerado = new decimal[1] ;
         P00E06_A1584PedSubSelectivo = new decimal[1] ;
         P00E06_A1583PedSubAfe = new decimal[1] ;
         P00E06_A1582PedSubIna = new decimal[1] ;
         P00E06_A1598PedICBPER = new decimal[1] ;
         A1548PedConpDsc = "";
         AV31PedCod = "";
         AV34PedFec = DateTime.MinValue;
         AV33PedConpDsc = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV30Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrreportepedidonocumplencondiciones__default(),
            new Object[][] {
                new Object[] {
               P00E02_A45CliCod, P00E02_A161CliDsc
               }
               , new Object[] {
               P00E03_A137Conpcod, P00E03_A753ConpDsc
               }
               , new Object[] {
               P00E04_A161CliDsc, P00E04_A45CliCod, P00E04_A1606PedSts, P00E04_A613CliLim, P00E04_A215PedFec, P00E04_A137Conpcod, P00E04_A753ConpDsc, P00E04_A210PedCod
               }
               , new Object[] {
               P00E06_A45CliCod, P00E06_A1606PedSts, P00E06_A215PedFec, P00E06_A137Conpcod, P00E06_A210PedCod, P00E06_A214PedConp, P00E06_A1548PedConpDsc, P00E06_A1603PedRedondeo, P00E06_A1602PedPorIVA, P00E06_A1590PedPorDsct,
               P00E06_A1589PedSubExonerado, P00E06_A1584PedSubSelectivo, P00E06_A1583PedSubAfe, P00E06_A1582PedSubIna, P00E06_A1598PedICBPER
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
      private int AV9cConpCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A137Conpcod ;
      private int AV28Item ;
      private int AV13ConpCod ;
      private int Gx_OldLine ;
      private int A214PedConp ;
      private int AV32PedConp ;
      private decimal A613CliLim ;
      private decimal AV12CliLim ;
      private decimal AV39Total ;
      private decimal A1603PedRedondeo ;
      private decimal A1602PedPorIVA ;
      private decimal A1590PedPorDsct ;
      private decimal A1589PedSubExonerado ;
      private decimal A1584PedSubSelectivo ;
      private decimal A1583PedSubAfe ;
      private decimal A1582PedSubIna ;
      private decimal A1598PedICBPER ;
      private decimal A1581PedSubT ;
      private decimal A1580PedDsct ;
      private decimal A1601PedIVA ;
      private decimal A1610PedTotal ;
      private decimal AV35PedTotal ;
      private decimal AV16Deuda ;
      private decimal AV20Excedente ;
      private decimal AV36PorEx ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV8cCliCod ;
      private string AV18Empresa ;
      private string AV17EmpDir ;
      private string AV19EmpRUC ;
      private string AV37Ruta ;
      private string AV23Filtro1 ;
      private string AV24Filtro2 ;
      private string AV25Filtro3 ;
      private string scmdbuf ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A753ConpDsc ;
      private string A1606PedSts ;
      private string A210PedCod ;
      private string AV10CliCod ;
      private string AV11CliDsc ;
      private string AV14ConpDsc ;
      private string A1548PedConpDsc ;
      private string AV31PedCod ;
      private string AV33PedConpDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV21FDesde ;
      private DateTime AV22FHasta ;
      private DateTime A215PedFec ;
      private DateTime AV34PedFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKE05 ;
      private bool returnInSub ;
      private string AV42Logo_GXI ;
      private string AV30Logo ;
      private string Logo ;
      private IGxSession AV38Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_cCliCod ;
      private int aP1_cConpCod ;
      private DateTime aP2_FDesde ;
      private DateTime aP3_FHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P00E02_A45CliCod ;
      private string[] P00E02_A161CliDsc ;
      private int[] P00E03_A137Conpcod ;
      private string[] P00E03_A753ConpDsc ;
      private string[] P00E04_A161CliDsc ;
      private string[] P00E04_A45CliCod ;
      private string[] P00E04_A1606PedSts ;
      private decimal[] P00E04_A613CliLim ;
      private DateTime[] P00E04_A215PedFec ;
      private int[] P00E04_A137Conpcod ;
      private string[] P00E04_A753ConpDsc ;
      private string[] P00E04_A210PedCod ;
      private string[] P00E06_A45CliCod ;
      private string[] P00E06_A1606PedSts ;
      private DateTime[] P00E06_A215PedFec ;
      private int[] P00E06_A137Conpcod ;
      private string[] P00E06_A210PedCod ;
      private int[] P00E06_A214PedConp ;
      private string[] P00E06_A1548PedConpDsc ;
      private decimal[] P00E06_A1603PedRedondeo ;
      private decimal[] P00E06_A1602PedPorIVA ;
      private decimal[] P00E06_A1590PedPorDsct ;
      private decimal[] P00E06_A1589PedSubExonerado ;
      private decimal[] P00E06_A1584PedSubSelectivo ;
      private decimal[] P00E06_A1583PedSubAfe ;
      private decimal[] P00E06_A1582PedSubIna ;
      private decimal[] P00E06_A1598PedICBPER ;
   }

   public class rrreportepedidonocumplencondiciones__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E04( IGxContext context ,
                                             string AV8cCliCod ,
                                             int AV9cConpCod ,
                                             string A45CliCod ,
                                             int A137Conpcod ,
                                             DateTime A215PedFec ,
                                             DateTime AV21FDesde ,
                                             DateTime AV22FHasta ,
                                             decimal A613CliLim ,
                                             string A1606PedSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.[CliDsc], T1.[CliCod], T1.[PedSts], T2.[CliLim], T1.[PedFec], T2.[Conpcod], T3.[ConpDsc], T1.[PedCod] FROM (([CLPEDIDOS] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[CliCod]) INNER JOIN [CCONDICIONPAGO] T3 ON T3.[Conpcod] = T2.[Conpcod])";
         AddWhere(sWhereString, "(T1.[PedFec] >= @AV21FDesde and T1.[PedFec] <= @AV22FHasta)");
         AddWhere(sWhereString, "(Not (T2.[CliLim] = convert(int, 0)))");
         AddWhere(sWhereString, "(Not T1.[PedSts] = 'A')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cCliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV8cCliCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cConpCod) )
         {
            AddWhere(sWhereString, "(T2.[Conpcod] = @AV9cConpCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CliCod], T2.[CliDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00E06( IGxContext context ,
                                             int AV9cConpCod ,
                                             int A137Conpcod ,
                                             string A1606PedSts ,
                                             string AV10CliCod ,
                                             DateTime AV21FDesde ,
                                             string A45CliCod ,
                                             DateTime A215PedFec ,
                                             DateTime AV22FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CliCod], T1.[PedSts], T1.[PedFec], T2.[Conpcod], T1.[PedCod], T1.[PedConp] AS PedConp, T4.[ConpDsc] AS PedConpDsc, T1.[PedRedondeo], T1.[PedPorIVA], T1.[PedPorDsct], COALESCE( T3.[PedSubExonerado], 0) AS PedSubExonerado, COALESCE( T3.[PedSubSelectivo], 0) AS PedSubSelectivo, COALESCE( T3.[PedSubAfe], 0) AS PedSubAfe, COALESCE( T3.[PedSubIna], 0) AS PedSubIna, T1.[PedICBPER] FROM ((([CLPEDIDOS] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[CliCod]) LEFT JOIN (SELECT SUM(CASE  WHEN [PedDIna] = 1 or [PedDIna] = 4 THEN [PedDTot] ELSE 0 END) AS PedSubIna, [PedCod], SUM(CASE  WHEN [PedDIna] = 2 THEN [PedDTot] ELSE 0 END) AS PedSubExonerado, SUM(CASE  WHEN [PedDIna] = 0 THEN [PedDTot] ELSE 0 END) AS PedSubAfe, SUM(( [PedDValSel] * CAST([PedDCan] AS decimal( 25, 10))) + ( ROUND(CAST(( [PedDTot] * CAST([PedDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2))) AS PedSubSelectivo FROM [CLPEDIDOSDET] GROUP BY [PedCod] ) T3 ON T3.[PedCod] = T1.[PedCod]) INNER JOIN [CCONDICIONPAGO] T4 ON T4.[Conpcod] = T1.[PedConp])";
         AddWhere(sWhereString, "(T1.[CliCod] = @AV10CliCod and T1.[PedFec] >= @AV21FDesde)");
         AddWhere(sWhereString, "(Not T1.[PedSts] = 'A')");
         AddWhere(sWhereString, "(T1.[PedFec] <= @AV22FHasta)");
         if ( ! (0==AV9cConpCod) )
         {
            AddWhere(sWhereString, "(T2.[Conpcod] = @AV9cConpCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CliCod], T1.[PedFec]";
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
                     return conditional_P00E04(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (decimal)dynConstraints[7] , (string)dynConstraints[8] );
               case 3 :
                     return conditional_P00E06(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] );
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
          Object[] prmP00E02;
          prmP00E02 = new Object[] {
          new ParDef("@AV8cCliCod",GXType.NChar,20,0)
          };
          Object[] prmP00E03;
          prmP00E03 = new Object[] {
          new ParDef("@AV9cConpCod",GXType.Int32,6,0)
          };
          Object[] prmP00E04;
          prmP00E04 = new Object[] {
          new ParDef("@AV21FDesde",GXType.Date,8,0) ,
          new ParDef("@AV22FHasta",GXType.Date,8,0) ,
          new ParDef("@AV8cCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV9cConpCod",GXType.Int32,6,0)
          };
          Object[] prmP00E06;
          prmP00E06 = new Object[] {
          new ParDef("@AV10CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV21FDesde",GXType.Date,8,0) ,
          new ParDef("@AV22FHasta",GXType.Date,8,0) ,
          new ParDef("@AV9cConpCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00E02", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV8cCliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E02,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E03", "SELECT [Conpcod], [ConpDsc] FROM [CCONDICIONPAGO] WHERE [Conpcod] = @AV9cConpCod ORDER BY [Conpcod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E03,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E04", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E04,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E06", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E06,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 10);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                return;
       }
    }

 }

}
