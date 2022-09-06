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
   public class rrdetalleventas : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrdetalleventas.aspx")), "rrdetalleventas.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrdetalleventas.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "VenCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV50VenCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV46ProdCod = GetPar( "ProdCod");
                  AV10CliCod = GetPar( "CliCod");
                  AV45Fdesde = context.localUtil.ParseDateParm( GetPar( "Fdesde"));
                  AV36FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV63LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
                  AV64SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV65TieCod = (int)(NumberUtil.Val( GetPar( "TieCod"), "."));
                  AV8TipCCod = (int)(NumberUtil.Val( GetPar( "TipCCod"), "."));
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

      public rrdetalleventas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrdetalleventas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_VenCod ,
                           ref string aP1_ProdCod ,
                           ref string aP2_CliCod ,
                           ref DateTime aP3_Fdesde ,
                           ref DateTime aP4_FHasta ,
                           ref int aP5_LinCod ,
                           ref int aP6_SubLCod ,
                           ref int aP7_TieCod ,
                           ref int aP8_TipCCod )
      {
         this.AV50VenCod = aP0_VenCod;
         this.AV46ProdCod = aP1_ProdCod;
         this.AV10CliCod = aP2_CliCod;
         this.AV45Fdesde = aP3_Fdesde;
         this.AV36FHasta = aP4_FHasta;
         this.AV63LinCod = aP5_LinCod;
         this.AV64SubLCod = aP6_SubLCod;
         this.AV65TieCod = aP7_TieCod;
         this.AV8TipCCod = aP8_TipCCod;
         initialize();
         executePrivate();
         aP0_VenCod=this.AV50VenCod;
         aP1_ProdCod=this.AV46ProdCod;
         aP2_CliCod=this.AV10CliCod;
         aP3_Fdesde=this.AV45Fdesde;
         aP4_FHasta=this.AV36FHasta;
         aP5_LinCod=this.AV63LinCod;
         aP6_SubLCod=this.AV64SubLCod;
         aP7_TieCod=this.AV65TieCod;
         aP8_TipCCod=this.AV8TipCCod;
      }

      public int executeUdp( ref int aP0_VenCod ,
                             ref string aP1_ProdCod ,
                             ref string aP2_CliCod ,
                             ref DateTime aP3_Fdesde ,
                             ref DateTime aP4_FHasta ,
                             ref int aP5_LinCod ,
                             ref int aP6_SubLCod ,
                             ref int aP7_TieCod )
      {
         execute(ref aP0_VenCod, ref aP1_ProdCod, ref aP2_CliCod, ref aP3_Fdesde, ref aP4_FHasta, ref aP5_LinCod, ref aP6_SubLCod, ref aP7_TieCod, ref aP8_TipCCod);
         return AV8TipCCod ;
      }

      public void executeSubmit( ref int aP0_VenCod ,
                                 ref string aP1_ProdCod ,
                                 ref string aP2_CliCod ,
                                 ref DateTime aP3_Fdesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref int aP5_LinCod ,
                                 ref int aP6_SubLCod ,
                                 ref int aP7_TieCod ,
                                 ref int aP8_TipCCod )
      {
         rrdetalleventas objrrdetalleventas;
         objrrdetalleventas = new rrdetalleventas();
         objrrdetalleventas.AV50VenCod = aP0_VenCod;
         objrrdetalleventas.AV46ProdCod = aP1_ProdCod;
         objrrdetalleventas.AV10CliCod = aP2_CliCod;
         objrrdetalleventas.AV45Fdesde = aP3_Fdesde;
         objrrdetalleventas.AV36FHasta = aP4_FHasta;
         objrrdetalleventas.AV63LinCod = aP5_LinCod;
         objrrdetalleventas.AV64SubLCod = aP6_SubLCod;
         objrrdetalleventas.AV65TieCod = aP7_TieCod;
         objrrdetalleventas.AV8TipCCod = aP8_TipCCod;
         objrrdetalleventas.context.SetSubmitInitialConfig(context);
         objrrdetalleventas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrdetalleventas);
         aP0_VenCod=this.AV50VenCod;
         aP1_ProdCod=this.AV46ProdCod;
         aP2_CliCod=this.AV10CliCod;
         aP3_Fdesde=this.AV45Fdesde;
         aP4_FHasta=this.AV36FHasta;
         aP5_LinCod=this.AV63LinCod;
         aP6_SubLCod=this.AV64SubLCod;
         aP7_TieCod=this.AV65TieCod;
         aP8_TipCCod=this.AV8TipCCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrdetalleventas)stateInfo).executePrivate();
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
            AV34Empresa = AV35Session.Get("Empresa");
            AV32EmpDir = AV35Session.Get("EmpDir");
            AV42EmpRUC = AV35Session.Get("EmpRUC");
            AV43Ruta = AV35Session.Get("RUTA") + "/Logo.jpg";
            AV44Logo = AV43Ruta;
            AV68Logo_GXI = GXDbFile.PathToUrl( AV43Ruta);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV65TieCod ,
                                                 AV10CliCod ,
                                                 AV50VenCod ,
                                                 AV46ProdCod ,
                                                 AV63LinCod ,
                                                 AV64SubLCod ,
                                                 AV8TipCCod ,
                                                 A178TieCod ,
                                                 A231DocCliCod ,
                                                 A227DocVendCod ,
                                                 A28ProdCod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A159TipCCod ,
                                                 A232DocFec ,
                                                 AV45Fdesde ,
                                                 AV36FHasta ,
                                                 A941DocSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P009H2 */
            pr_default.execute(0, new Object[] {AV45Fdesde, AV36FHasta, AV65TieCod, AV10CliCod, AV50VenCod, AV46ProdCod, AV63LinCod, AV64SubLCod, AV8TipCCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK9H3 = false;
               A230DocMonCod = P009H2_A230DocMonCod[0];
               A24DocNum = P009H2_A24DocNum[0];
               A149TipCod = P009H2_A149TipCod[0];
               A28ProdCod = P009H2_A28ProdCod[0];
               A896DocDDct = P009H2_A896DocDDct[0];
               A894DocDpre = P009H2_A894DocDpre[0];
               A895DocDCan = P009H2_A895DocDCan[0];
               A55ProdDsc = P009H2_A55ProdDsc[0];
               A941DocSts = P009H2_A941DocSts[0];
               A232DocFec = P009H2_A232DocFec[0];
               A159TipCCod = P009H2_A159TipCCod[0];
               n159TipCCod = P009H2_n159TipCCod[0];
               A51SublCod = P009H2_A51SublCod[0];
               n51SublCod = P009H2_n51SublCod[0];
               A52LinCod = P009H2_A52LinCod[0];
               A227DocVendCod = P009H2_A227DocVendCod[0];
               A231DocCliCod = P009H2_A231DocCliCod[0];
               A178TieCod = P009H2_A178TieCod[0];
               n178TieCod = P009H2_n178TieCod[0];
               A887DocCliDsc = P009H2_A887DocCliDsc[0];
               A1234MonDsc = P009H2_A1234MonDsc[0];
               n1234MonDsc = P009H2_n1234MonDsc[0];
               A306TipAbr = P009H2_A306TipAbr[0];
               A946DocTipo = P009H2_A946DocTipo[0];
               A233DocItem = P009H2_A233DocItem[0];
               A306TipAbr = P009H2_A306TipAbr[0];
               A230DocMonCod = P009H2_A230DocMonCod[0];
               A941DocSts = P009H2_A941DocSts[0];
               A232DocFec = P009H2_A232DocFec[0];
               A227DocVendCod = P009H2_A227DocVendCod[0];
               A231DocCliCod = P009H2_A231DocCliCod[0];
               A178TieCod = P009H2_A178TieCod[0];
               n178TieCod = P009H2_n178TieCod[0];
               A946DocTipo = P009H2_A946DocTipo[0];
               A1234MonDsc = P009H2_A1234MonDsc[0];
               n1234MonDsc = P009H2_n1234MonDsc[0];
               A159TipCCod = P009H2_A159TipCCod[0];
               n159TipCCod = P009H2_n159TipCCod[0];
               A887DocCliDsc = P009H2_A887DocCliDsc[0];
               A55ProdDsc = P009H2_A55ProdDsc[0];
               A51SublCod = P009H2_A51SublCod[0];
               n51SublCod = P009H2_n51SublCod[0];
               A52LinCod = P009H2_A52LinCod[0];
               AV47DocCliCod = A231DocCliCod;
               AV48DocCliDsc = A887DocCliDsc;
               AV13TipCod = A149TipCod;
               AV49DocNum = A24DocNum;
               AV60MonDsc = A1234MonDsc;
               AV62TipAbr = A306TipAbr;
               AV58DocFec = A232DocFec;
               AV59DocVendCod = A227DocVendCod;
               AV54Concepto = ((StringUtil.StrCmp(A946DocTipo, "M")==0)||(StringUtil.StrCmp(A946DocTipo, "E")==0) ? "DOCUMENTO DE MUESTRA" : "");
               H9H0( false, 21) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48DocCliDsc, "")), 2, Gx_line+4, 524, Gx_line+19, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
               H9H0( false, 22) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62TipAbr, "")), 2, Gx_line+4, 41, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49DocNum, "")), 48, Gx_line+4, 124, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV59DocVendCod), "ZZZZZ9")), 204, Gx_line+4, 242, Gx_line+18, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV58DocFec, "99/99/99"), 134, Gx_line+4, 180, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Moneda : ", 570, Gx_line+4, 627, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60MonDsc, "")), 635, Gx_line+4, 787, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Concepto, "")), 255, Gx_line+4, 534, Gx_line+18, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+22);
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P009H2_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(P009H2_A24DocNum[0], A24DocNum) == 0 ) )
               {
                  BRK9H3 = false;
                  A28ProdCod = P009H2_A28ProdCod[0];
                  A896DocDDct = P009H2_A896DocDDct[0];
                  A894DocDpre = P009H2_A894DocDpre[0];
                  A895DocDCan = P009H2_A895DocDCan[0];
                  A55ProdDsc = P009H2_A55ProdDsc[0];
                  A233DocItem = P009H2_A233DocItem[0];
                  A55ProdDsc = P009H2_A55ProdDsc[0];
                  if ( StringUtil.StrCmp(A149TipCod, AV13TipCod) == 0 )
                  {
                     if ( StringUtil.StrCmp(A24DocNum, AV49DocNum) == 0 )
                     {
                        H9H0( false, 20) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 253, Gx_line+3, 332, Gx_line+18, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 343, Gx_line+3, 572, Gx_line+17, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A895DocDCan, "ZZZZ,ZZZ,ZZ9.9999")), 533, Gx_line+3, 640, Gx_line+18, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A894DocDpre, "ZZZZ,ZZZ,ZZ9.9999")), 615, Gx_line+3, 722, Gx_line+18, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A896DocDDct, "ZZZZZZ9.99")), 715, Gx_line+3, 779, Gx_line+18, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  BRK9H3 = true;
                  pr_default.readNext(0);
               }
               /* Execute user subroutine: 'TOTALES' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! BRK9H3 )
               {
                  BRK9H3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9H0( true, 0) ;
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
         /* 'TOTALES' Routine */
         returnInSub = false;
         /* Using cursor P009H4 */
         pr_default.execute(1, new Object[] {AV13TipCod, AV49DocNum});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A24DocNum = P009H4_A24DocNum[0];
            A149TipCod = P009H4_A149TipCod[0];
            A932DocICBPER = P009H4_A932DocICBPER[0];
            A935DocRedondeo = P009H4_A935DocRedondeo[0];
            A934DocPorIVA = P009H4_A934DocPorIVA[0];
            A882DocAnticipos = P009H4_A882DocAnticipos[0];
            A899DocDcto = P009H4_A899DocDcto[0];
            A927DocSubExonerado = P009H4_A927DocSubExonerado[0];
            A922DocSubSelectivo = P009H4_A922DocSubSelectivo[0];
            A921DocSubInafecto = P009H4_A921DocSubInafecto[0];
            A920DocSubAfecto = P009H4_A920DocSubAfecto[0];
            A927DocSubExonerado = P009H4_A927DocSubExonerado[0];
            A922DocSubSelectivo = P009H4_A922DocSubSelectivo[0];
            A921DocSubInafecto = P009H4_A921DocSubInafecto[0];
            A920DocSubAfecto = P009H4_A920DocSubAfecto[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
            A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
            A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
            AV51DocSub = A919DocSub;
            AV56DocDscto = A918DocDscto;
            AV52DocIVA = A933DocIVA;
            AV53DocTot = A948DocTot;
            H9H0( false, 60) ;
            getPrinter().GxDrawLine(466, Gx_line+6, 788, Gx_line+6, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Documento", 309, Gx_line+30, 411, Gx_line+44, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Sub Total", 478, Gx_line+13, 534, Gx_line+27, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("I.G.V.", 661, Gx_line+13, 692, Gx_line+27, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Total", 744, Gx_line+13, 775, Gx_line+27, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53DocTot, "ZZZZZZ,ZZZ,ZZ9.99")), 664, Gx_line+30, 771, Gx_line+45, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52DocIVA, "ZZZZZZ,ZZZ,ZZ9.99")), 600, Gx_line+30, 707, Gx_line+45, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51DocSub, "ZZZZ,ZZZ,ZZ9.99")), 427, Gx_line+30, 522, Gx_line+45, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Dscto.", 564, Gx_line+13, 601, Gx_line+27, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56DocDscto, "ZZZZZZ,ZZZ,ZZ9.99")), 511, Gx_line+30, 618, Gx_line+45, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+60);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected void H9H0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 675, Gx_line+29, 707, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 675, Gx_line+46, 719, Gx_line+60, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 675, Gx_line+13, 714, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 731, Gx_line+46, 770, Gx_line+61, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 700, Gx_line+29, 769, Gx_line+43, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 723, Gx_line+13, 770, Gx_line+28, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 14, Gx_line+143, 37, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Doc.", 60, Gx_line+143, 103, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 429, Gx_line+143, 483, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 578, Gx_line+143, 631, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+136, 797, Gx_line+162, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Detalle de Documentos de Clientes", 249, Gx_line+73, 547, Gx_line+93, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Vend.", 207, Gx_line+143, 240, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Codigo", 275, Gx_line+143, 316, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dscto", 742, Gx_line+143, 776, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio", 664, Gx_line+143, 701, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32EmpDir, "")), 19, Gx_line+29, 404, Gx_line+47, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42EmpRUC, "")), 19, Gx_line+46, 404, Gx_line+64, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Empresa, "")), 19, Gx_line+11, 404, Gx_line+29, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(45, Gx_line+138, 45, Gx_line+163, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(126, Gx_line+138, 126, Gx_line+163, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(253, Gx_line+138, 253, Gx_line+163, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(342, Gx_line+138, 342, Gx_line+163, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(569, Gx_line+138, 569, Gx_line+163, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(725, Gx_line+136, 725, Gx_line+161, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(644, Gx_line+138, 644, Gx_line+163, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(199, Gx_line+138, 199, Gx_line+163, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 146, Gx_line+143, 181, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde", 249, Gx_line+98, 289, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV45Fdesde, "99/99/99"), 309, Gx_line+93, 383, Gx_line+117, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 409, Gx_line+98, 446, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV36FHasta, "99/99/99"), 460, Gx_line+93, 534, Gx_line+117, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+163);
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
         AV34Empresa = "";
         AV35Session = context.GetSession();
         AV32EmpDir = "";
         AV42EmpRUC = "";
         AV43Ruta = "";
         AV44Logo = "";
         AV68Logo_GXI = "";
         scmdbuf = "";
         A231DocCliCod = "";
         A28ProdCod = "";
         A232DocFec = DateTime.MinValue;
         A941DocSts = "";
         P009H2_A230DocMonCod = new int[1] ;
         P009H2_A24DocNum = new string[] {""} ;
         P009H2_A149TipCod = new string[] {""} ;
         P009H2_A28ProdCod = new string[] {""} ;
         P009H2_A896DocDDct = new decimal[1] ;
         P009H2_A894DocDpre = new decimal[1] ;
         P009H2_A895DocDCan = new decimal[1] ;
         P009H2_A55ProdDsc = new string[] {""} ;
         P009H2_A941DocSts = new string[] {""} ;
         P009H2_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P009H2_A159TipCCod = new int[1] ;
         P009H2_n159TipCCod = new bool[] {false} ;
         P009H2_A51SublCod = new int[1] ;
         P009H2_n51SublCod = new bool[] {false} ;
         P009H2_A52LinCod = new int[1] ;
         P009H2_A227DocVendCod = new int[1] ;
         P009H2_A231DocCliCod = new string[] {""} ;
         P009H2_A178TieCod = new int[1] ;
         P009H2_n178TieCod = new bool[] {false} ;
         P009H2_A887DocCliDsc = new string[] {""} ;
         P009H2_A1234MonDsc = new string[] {""} ;
         P009H2_n1234MonDsc = new bool[] {false} ;
         P009H2_A306TipAbr = new string[] {""} ;
         P009H2_A946DocTipo = new string[] {""} ;
         P009H2_A233DocItem = new long[1] ;
         A24DocNum = "";
         A149TipCod = "";
         A55ProdDsc = "";
         A887DocCliDsc = "";
         A1234MonDsc = "";
         A306TipAbr = "";
         A946DocTipo = "";
         AV47DocCliCod = "";
         AV48DocCliDsc = "";
         AV13TipCod = "";
         AV49DocNum = "";
         AV60MonDsc = "";
         AV62TipAbr = "";
         AV58DocFec = DateTime.MinValue;
         AV54Concepto = "";
         P009H4_A24DocNum = new string[] {""} ;
         P009H4_A149TipCod = new string[] {""} ;
         P009H4_A932DocICBPER = new decimal[1] ;
         P009H4_A935DocRedondeo = new decimal[1] ;
         P009H4_A934DocPorIVA = new decimal[1] ;
         P009H4_A882DocAnticipos = new decimal[1] ;
         P009H4_A899DocDcto = new decimal[1] ;
         P009H4_A927DocSubExonerado = new decimal[1] ;
         P009H4_A922DocSubSelectivo = new decimal[1] ;
         P009H4_A921DocSubInafecto = new decimal[1] ;
         P009H4_A920DocSubAfecto = new decimal[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrdetalleventas__default(),
            new Object[][] {
                new Object[] {
               P009H2_A230DocMonCod, P009H2_A24DocNum, P009H2_A149TipCod, P009H2_A28ProdCod, P009H2_A896DocDDct, P009H2_A894DocDpre, P009H2_A895DocDCan, P009H2_A55ProdDsc, P009H2_A941DocSts, P009H2_A232DocFec,
               P009H2_A159TipCCod, P009H2_n159TipCCod, P009H2_A51SublCod, P009H2_n51SublCod, P009H2_A52LinCod, P009H2_A227DocVendCod, P009H2_A231DocCliCod, P009H2_A178TieCod, P009H2_n178TieCod, P009H2_A887DocCliDsc,
               P009H2_A1234MonDsc, P009H2_n1234MonDsc, P009H2_A306TipAbr, P009H2_A946DocTipo, P009H2_A233DocItem
               }
               , new Object[] {
               P009H4_A24DocNum, P009H4_A149TipCod, P009H4_A932DocICBPER, P009H4_A935DocRedondeo, P009H4_A934DocPorIVA, P009H4_A882DocAnticipos, P009H4_A899DocDcto, P009H4_A927DocSubExonerado, P009H4_A922DocSubSelectivo, P009H4_A921DocSubInafecto,
               P009H4_A920DocSubAfecto
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
      private int AV50VenCod ;
      private int AV63LinCod ;
      private int AV64SubLCod ;
      private int AV65TieCod ;
      private int AV8TipCCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A178TieCod ;
      private int A227DocVendCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A159TipCCod ;
      private int A230DocMonCod ;
      private int AV59DocVendCod ;
      private int Gx_OldLine ;
      private long A233DocItem ;
      private decimal A896DocDDct ;
      private decimal A894DocDpre ;
      private decimal A895DocDCan ;
      private decimal A932DocICBPER ;
      private decimal A935DocRedondeo ;
      private decimal A934DocPorIVA ;
      private decimal A882DocAnticipos ;
      private decimal A899DocDcto ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A919DocSub ;
      private decimal A918DocDscto ;
      private decimal A933DocIVA ;
      private decimal A948DocTot ;
      private decimal AV51DocSub ;
      private decimal AV56DocDscto ;
      private decimal AV52DocIVA ;
      private decimal AV53DocTot ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV46ProdCod ;
      private string AV10CliCod ;
      private string AV34Empresa ;
      private string AV32EmpDir ;
      private string AV42EmpRUC ;
      private string AV43Ruta ;
      private string scmdbuf ;
      private string A231DocCliCod ;
      private string A28ProdCod ;
      private string A941DocSts ;
      private string A24DocNum ;
      private string A149TipCod ;
      private string A55ProdDsc ;
      private string A887DocCliDsc ;
      private string A1234MonDsc ;
      private string A306TipAbr ;
      private string A946DocTipo ;
      private string AV47DocCliCod ;
      private string AV48DocCliDsc ;
      private string AV13TipCod ;
      private string AV49DocNum ;
      private string AV60MonDsc ;
      private string AV62TipAbr ;
      private string AV54Concepto ;
      private string Gx_time ;
      private DateTime AV45Fdesde ;
      private DateTime AV36FHasta ;
      private DateTime A232DocFec ;
      private DateTime AV58DocFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK9H3 ;
      private bool n159TipCCod ;
      private bool n51SublCod ;
      private bool n178TieCod ;
      private bool n1234MonDsc ;
      private bool returnInSub ;
      private string AV68Logo_GXI ;
      private string AV44Logo ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_VenCod ;
      private string aP1_ProdCod ;
      private string aP2_CliCod ;
      private DateTime aP3_Fdesde ;
      private DateTime aP4_FHasta ;
      private int aP5_LinCod ;
      private int aP6_SubLCod ;
      private int aP7_TieCod ;
      private int aP8_TipCCod ;
      private IDataStoreProvider pr_default ;
      private int[] P009H2_A230DocMonCod ;
      private string[] P009H2_A24DocNum ;
      private string[] P009H2_A149TipCod ;
      private string[] P009H2_A28ProdCod ;
      private decimal[] P009H2_A896DocDDct ;
      private decimal[] P009H2_A894DocDpre ;
      private decimal[] P009H2_A895DocDCan ;
      private string[] P009H2_A55ProdDsc ;
      private string[] P009H2_A941DocSts ;
      private DateTime[] P009H2_A232DocFec ;
      private int[] P009H2_A159TipCCod ;
      private bool[] P009H2_n159TipCCod ;
      private int[] P009H2_A51SublCod ;
      private bool[] P009H2_n51SublCod ;
      private int[] P009H2_A52LinCod ;
      private int[] P009H2_A227DocVendCod ;
      private string[] P009H2_A231DocCliCod ;
      private int[] P009H2_A178TieCod ;
      private bool[] P009H2_n178TieCod ;
      private string[] P009H2_A887DocCliDsc ;
      private string[] P009H2_A1234MonDsc ;
      private bool[] P009H2_n1234MonDsc ;
      private string[] P009H2_A306TipAbr ;
      private string[] P009H2_A946DocTipo ;
      private long[] P009H2_A233DocItem ;
      private string[] P009H4_A24DocNum ;
      private string[] P009H4_A149TipCod ;
      private decimal[] P009H4_A932DocICBPER ;
      private decimal[] P009H4_A935DocRedondeo ;
      private decimal[] P009H4_A934DocPorIVA ;
      private decimal[] P009H4_A882DocAnticipos ;
      private decimal[] P009H4_A899DocDcto ;
      private decimal[] P009H4_A927DocSubExonerado ;
      private decimal[] P009H4_A922DocSubSelectivo ;
      private decimal[] P009H4_A921DocSubInafecto ;
      private decimal[] P009H4_A920DocSubAfecto ;
   }

   public class rrdetalleventas__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009H2( IGxContext context ,
                                             int AV65TieCod ,
                                             string AV10CliCod ,
                                             int AV50VenCod ,
                                             string AV46ProdCod ,
                                             int AV63LinCod ,
                                             int AV64SubLCod ,
                                             int AV8TipCCod ,
                                             int A178TieCod ,
                                             string A231DocCliCod ,
                                             int A227DocVendCod ,
                                             string A28ProdCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A159TipCCod ,
                                             DateTime A232DocFec ,
                                             DateTime AV45Fdesde ,
                                             DateTime AV36FHasta ,
                                             string A941DocSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T3.[DocMonCod] AS DocMonCod, T1.[DocNum], T1.[TipCod], T1.[ProdCod], T1.[DocDDct], T1.[DocDpre], T1.[DocDCan], T6.[ProdDsc], T3.[DocSts], T3.[DocFec], T5.[TipCCod], T6.[SublCod], T6.[LinCod], T3.[DocVendCod], T3.[DocCliCod] AS DocCliCod, T3.[TieCod], T5.[CliDsc] AS DocCliDsc, T4.[MonDsc], T2.[TipAbr], T3.[DocTipo], T1.[DocItem] FROM ((((([CLVENTASDET] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) INNER JOIN [CLVENTAS] T3 ON T3.[TipCod] = T1.[TipCod] AND T3.[DocNum] = T1.[DocNum]) INNER JOIN [CMONEDAS] T4 ON T4.[MonCod] = T3.[DocMonCod]) INNER JOIN [CLCLIENTES] T5 ON T5.[CliCod] = T3.[DocCliCod]) INNER JOIN [APRODUCTOS] T6 ON T6.[ProdCod] = T1.[ProdCod])";
         AddWhere(sWhereString, "(T3.[DocFec] >= @AV45Fdesde and T3.[DocFec] <= @AV36FHasta)");
         AddWhere(sWhereString, "(T3.[DocSts] <> 'A')");
         if ( ! (0==AV65TieCod) )
         {
            AddWhere(sWhereString, "(T3.[TieCod] = @AV65TieCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CliCod)) )
         {
            AddWhere(sWhereString, "(T3.[DocCliCod] = @AV10CliCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV50VenCod) )
         {
            AddWhere(sWhereString, "(T3.[DocVendCod] = @AV50VenCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV46ProdCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV63LinCod) )
         {
            AddWhere(sWhereString, "(T6.[LinCod] = @AV63LinCod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV64SubLCod) )
         {
            AddWhere(sWhereString, "(T6.[SublCod] = @AV64SubLCod)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV8TipCCod) )
         {
            AddWhere(sWhereString, "(T5.[TipCCod] = @AV8TipCCod)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipCod], T1.[DocNum]";
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
                     return conditional_P009H2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] );
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
          Object[] prmP009H4;
          prmP009H4 = new Object[] {
          new ParDef("@AV13TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV49DocNum",GXType.NChar,12,0)
          };
          Object[] prmP009H2;
          prmP009H2 = new Object[] {
          new ParDef("@AV45Fdesde",GXType.Date,8,0) ,
          new ParDef("@AV36FHasta",GXType.Date,8,0) ,
          new ParDef("@AV65TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV10CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV50VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV46ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV63LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV64SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV8TipCCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009H2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009H4", "SELECT T1.[DocNum], T1.[TipCod], T1.[DocICBPER], T1.[DocRedondeo], T1.[DocPorIVA], T1.[DocAnticipos], T1.[DocDcto], COALESCE( T2.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T2.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T2.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T2.[DocSubAfecto], 0) AS DocSubAfecto FROM ([CLVENTAS] T1 LEFT JOIN (SELECT [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) WHERE T1.[TipCod] = @AV13TipCod and T1.[DocNum] = @AV49DocNum ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009H4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 1);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((bool[]) buf[11])[0] = rslt.wasNull(11);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 20);
                ((int[]) buf[17])[0] = rslt.getInt(16);
                ((bool[]) buf[18])[0] = rslt.wasNull(16);
                ((string[]) buf[19])[0] = rslt.getString(17, 100);
                ((string[]) buf[20])[0] = rslt.getString(18, 100);
                ((bool[]) buf[21])[0] = rslt.wasNull(18);
                ((string[]) buf[22])[0] = rslt.getString(19, 5);
                ((string[]) buf[23])[0] = rslt.getString(20, 1);
                ((long[]) buf[24])[0] = rslt.getLong(21);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                return;
       }
    }

 }

}
