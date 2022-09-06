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
   public class rrresumendocumentos : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrresumendocumentos.aspx")), "rrresumendocumentos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrresumendocumentos.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "TipCCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8TipCCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9EstCod = GetPar( "EstCod");
                  AV10CliCod = GetPar( "CliCod");
                  AV11TipCod = GetPar( "TipCod");
                  AV13PaiCod = GetPar( "PaiCod");
                  AV14FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV15FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV28DocMonCod = (int)(NumberUtil.Val( GetPar( "DocMonCod"), "."));
                  AV44DocConpCod = (int)(NumberUtil.Val( GetPar( "DocConpCod"), "."));
                  AV45Serie = GetPar( "Serie");
                  AV49Tipo = GetPar( "Tipo");
                  AV51TieCod = (int)(NumberUtil.Val( GetPar( "TieCod"), "."));
                  AV53VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
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

      public rrresumendocumentos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrresumendocumentos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TipCCod ,
                           ref string aP1_EstCod ,
                           ref string aP2_CliCod ,
                           ref string aP3_TipCod ,
                           ref string aP4_PaiCod ,
                           ref DateTime aP5_FDesde ,
                           ref DateTime aP6_FHasta ,
                           ref int aP7_DocMonCod ,
                           ref int aP8_DocConpCod ,
                           ref string aP9_Serie ,
                           ref string aP10_Tipo ,
                           ref int aP11_TieCod ,
                           ref int aP12_VenCod )
      {
         this.AV8TipCCod = aP0_TipCCod;
         this.AV9EstCod = aP1_EstCod;
         this.AV10CliCod = aP2_CliCod;
         this.AV11TipCod = aP3_TipCod;
         this.AV13PaiCod = aP4_PaiCod;
         this.AV14FDesde = aP5_FDesde;
         this.AV15FHasta = aP6_FHasta;
         this.AV28DocMonCod = aP7_DocMonCod;
         this.AV44DocConpCod = aP8_DocConpCod;
         this.AV45Serie = aP9_Serie;
         this.AV49Tipo = aP10_Tipo;
         this.AV51TieCod = aP11_TieCod;
         this.AV53VenCod = aP12_VenCod;
         initialize();
         executePrivate();
         aP0_TipCCod=this.AV8TipCCod;
         aP1_EstCod=this.AV9EstCod;
         aP2_CliCod=this.AV10CliCod;
         aP3_TipCod=this.AV11TipCod;
         aP4_PaiCod=this.AV13PaiCod;
         aP5_FDesde=this.AV14FDesde;
         aP6_FHasta=this.AV15FHasta;
         aP7_DocMonCod=this.AV28DocMonCod;
         aP8_DocConpCod=this.AV44DocConpCod;
         aP9_Serie=this.AV45Serie;
         aP10_Tipo=this.AV49Tipo;
         aP11_TieCod=this.AV51TieCod;
         aP12_VenCod=this.AV53VenCod;
      }

      public int executeUdp( ref int aP0_TipCCod ,
                             ref string aP1_EstCod ,
                             ref string aP2_CliCod ,
                             ref string aP3_TipCod ,
                             ref string aP4_PaiCod ,
                             ref DateTime aP5_FDesde ,
                             ref DateTime aP6_FHasta ,
                             ref int aP7_DocMonCod ,
                             ref int aP8_DocConpCod ,
                             ref string aP9_Serie ,
                             ref string aP10_Tipo ,
                             ref int aP11_TieCod )
      {
         execute(ref aP0_TipCCod, ref aP1_EstCod, ref aP2_CliCod, ref aP3_TipCod, ref aP4_PaiCod, ref aP5_FDesde, ref aP6_FHasta, ref aP7_DocMonCod, ref aP8_DocConpCod, ref aP9_Serie, ref aP10_Tipo, ref aP11_TieCod, ref aP12_VenCod);
         return AV53VenCod ;
      }

      public void executeSubmit( ref int aP0_TipCCod ,
                                 ref string aP1_EstCod ,
                                 ref string aP2_CliCod ,
                                 ref string aP3_TipCod ,
                                 ref string aP4_PaiCod ,
                                 ref DateTime aP5_FDesde ,
                                 ref DateTime aP6_FHasta ,
                                 ref int aP7_DocMonCod ,
                                 ref int aP8_DocConpCod ,
                                 ref string aP9_Serie ,
                                 ref string aP10_Tipo ,
                                 ref int aP11_TieCod ,
                                 ref int aP12_VenCod )
      {
         rrresumendocumentos objrrresumendocumentos;
         objrrresumendocumentos = new rrresumendocumentos();
         objrrresumendocumentos.AV8TipCCod = aP0_TipCCod;
         objrrresumendocumentos.AV9EstCod = aP1_EstCod;
         objrrresumendocumentos.AV10CliCod = aP2_CliCod;
         objrrresumendocumentos.AV11TipCod = aP3_TipCod;
         objrrresumendocumentos.AV13PaiCod = aP4_PaiCod;
         objrrresumendocumentos.AV14FDesde = aP5_FDesde;
         objrrresumendocumentos.AV15FHasta = aP6_FHasta;
         objrrresumendocumentos.AV28DocMonCod = aP7_DocMonCod;
         objrrresumendocumentos.AV44DocConpCod = aP8_DocConpCod;
         objrrresumendocumentos.AV45Serie = aP9_Serie;
         objrrresumendocumentos.AV49Tipo = aP10_Tipo;
         objrrresumendocumentos.AV51TieCod = aP11_TieCod;
         objrrresumendocumentos.AV53VenCod = aP12_VenCod;
         objrrresumendocumentos.context.SetSubmitInitialConfig(context);
         objrrresumendocumentos.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrresumendocumentos);
         aP0_TipCCod=this.AV8TipCCod;
         aP1_EstCod=this.AV9EstCod;
         aP2_CliCod=this.AV10CliCod;
         aP3_TipCod=this.AV11TipCod;
         aP4_PaiCod=this.AV13PaiCod;
         aP5_FDesde=this.AV14FDesde;
         aP6_FHasta=this.AV15FHasta;
         aP7_DocMonCod=this.AV28DocMonCod;
         aP8_DocConpCod=this.AV44DocConpCod;
         aP9_Serie=this.AV45Serie;
         aP10_Tipo=this.AV49Tipo;
         aP11_TieCod=this.AV51TieCod;
         aP12_VenCod=this.AV53VenCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrresumendocumentos)stateInfo).executePrivate();
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
            AV56Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV16Filtro1 = "Todos";
            AV17Filtro2 = "Todos";
            AV18Filtro3 = "Todos";
            AV19Filtro4 = "Todos";
            AV20Filtro5 = "Todos";
            /* Using cursor P009F2 */
            pr_default.execute(0, new Object[] {AV11TipCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A149TipCod = P009F2_A149TipCod[0];
               A1910TipDsc = P009F2_A1910TipDsc[0];
               AV16Filtro1 = A1910TipDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P009F3 */
            pr_default.execute(1, new Object[] {AV8TipCCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A159TipCCod = P009F3_A159TipCCod[0];
               n159TipCCod = P009F3_n159TipCCod[0];
               A1905TipCDsc = P009F3_A1905TipCDsc[0];
               AV17Filtro2 = A1905TipCDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P009F4 */
            pr_default.execute(2, new Object[] {AV13PaiCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A139PaiCod = P009F4_A139PaiCod[0];
               n139PaiCod = P009F4_n139PaiCod[0];
               A1500PaiDsc = P009F4_A1500PaiDsc[0];
               AV18Filtro3 = A1500PaiDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P009F5 */
            pr_default.execute(3, new Object[] {AV9EstCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A140EstCod = P009F5_A140EstCod[0];
               n140EstCod = P009F5_n140EstCod[0];
               A602EstDsc = P009F5_A602EstDsc[0];
               A139PaiCod = P009F5_A139PaiCod[0];
               n139PaiCod = P009F5_n139PaiCod[0];
               AV19Filtro4 = A602EstDsc;
               pr_default.readNext(3);
            }
            pr_default.close(3);
            /* Using cursor P009F6 */
            pr_default.execute(4, new Object[] {AV10CliCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A45CliCod = P009F6_A45CliCod[0];
               A161CliDsc = P009F6_A161CliDsc[0];
               AV20Filtro5 = A161CliDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            AV27TotalGeneral = 0.00m;
            AV33TotalSub = 0.00m;
            AV34TotalIVA = 0.00m;
            pr_default.dynParam(5, new Object[]{ new Object[]{
                                                 AV51TieCod ,
                                                 AV8TipCCod ,
                                                 AV9EstCod ,
                                                 AV10CliCod ,
                                                 AV11TipCod ,
                                                 AV13PaiCod ,
                                                 AV28DocMonCod ,
                                                 AV44DocConpCod ,
                                                 AV53VenCod ,
                                                 AV49Tipo ,
                                                 AV45Serie ,
                                                 A178TieCod ,
                                                 A159TipCCod ,
                                                 A140EstCod ,
                                                 A231DocCliCod ,
                                                 A149TipCod ,
                                                 A139PaiCod ,
                                                 A230DocMonCod ,
                                                 A229DocConpCod ,
                                                 A227DocVendCod ,
                                                 A946DocTipo ,
                                                 A24DocNum ,
                                                 A232DocFec ,
                                                 AV14FDesde ,
                                                 AV15FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P009F8 */
            pr_default.execute(5, new Object[] {AV14FDesde, AV15FHasta, AV51TieCod, AV8TipCCod, AV9EstCod, AV10CliCod, AV11TipCod, AV13PaiCod, AV28DocMonCod, AV44DocConpCod, AV53VenCod, AV49Tipo, AV45Serie});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A232DocFec = P009F8_A232DocFec[0];
               A24DocNum = P009F8_A24DocNum[0];
               A946DocTipo = P009F8_A946DocTipo[0];
               A227DocVendCod = P009F8_A227DocVendCod[0];
               A229DocConpCod = P009F8_A229DocConpCod[0];
               A230DocMonCod = P009F8_A230DocMonCod[0];
               A139PaiCod = P009F8_A139PaiCod[0];
               n139PaiCod = P009F8_n139PaiCod[0];
               A149TipCod = P009F8_A149TipCod[0];
               A231DocCliCod = P009F8_A231DocCliCod[0];
               A140EstCod = P009F8_A140EstCod[0];
               n140EstCod = P009F8_n140EstCod[0];
               A159TipCCod = P009F8_A159TipCCod[0];
               n159TipCCod = P009F8_n159TipCCod[0];
               A178TieCod = P009F8_A178TieCod[0];
               n178TieCod = P009F8_n178TieCod[0];
               A941DocSts = P009F8_A941DocSts[0];
               A887DocCliDsc = P009F8_A887DocCliDsc[0];
               A511TipSigno = P009F8_A511TipSigno[0];
               A1234MonDsc = P009F8_A1234MonDsc[0];
               n1234MonDsc = P009F8_n1234MonDsc[0];
               A931DocFVcto = P009F8_A931DocFVcto[0];
               A306TipAbr = P009F8_A306TipAbr[0];
               A932DocICBPER = P009F8_A932DocICBPER[0];
               A935DocRedondeo = P009F8_A935DocRedondeo[0];
               A934DocPorIVA = P009F8_A934DocPorIVA[0];
               A882DocAnticipos = P009F8_A882DocAnticipos[0];
               A899DocDcto = P009F8_A899DocDcto[0];
               A927DocSubExonerado = P009F8_A927DocSubExonerado[0];
               A922DocSubSelectivo = P009F8_A922DocSubSelectivo[0];
               A921DocSubInafecto = P009F8_A921DocSubInafecto[0];
               A920DocSubAfecto = P009F8_A920DocSubAfecto[0];
               A1234MonDsc = P009F8_A1234MonDsc[0];
               n1234MonDsc = P009F8_n1234MonDsc[0];
               A511TipSigno = P009F8_A511TipSigno[0];
               A306TipAbr = P009F8_A306TipAbr[0];
               A927DocSubExonerado = P009F8_A927DocSubExonerado[0];
               A922DocSubSelectivo = P009F8_A922DocSubSelectivo[0];
               A921DocSubInafecto = P009F8_A921DocSubInafecto[0];
               A920DocSubAfecto = P009F8_A920DocSubAfecto[0];
               A139PaiCod = P009F8_A139PaiCod[0];
               n139PaiCod = P009F8_n139PaiCod[0];
               A140EstCod = P009F8_A140EstCod[0];
               n140EstCod = P009F8_n140EstCod[0];
               A159TipCCod = P009F8_A159TipCCod[0];
               n159TipCCod = P009F8_n159TipCCod[0];
               A887DocCliDsc = P009F8_A887DocCliDsc[0];
               A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
               A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
               A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
               A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
               AV36DocSts = A941DocSts;
               AV21DocCliCod = A231DocCliCod;
               AV22DocCliDsc = A887DocCliDsc;
               AV35Signo = A511TipSigno;
               AV31DocSub = (decimal)(A919DocSub*AV35Signo);
               AV37DocDscto = (decimal)(A918DocDscto*AV35Signo);
               AV32DocIVA = (decimal)(A933DocIVA*AV35Signo);
               AV23TotalVenta = (decimal)(A948DocTot*AV35Signo);
               AV31DocSub = (decimal)(AV31DocSub-AV37DocDscto);
               AV50TipoVenta = ((StringUtil.StrCmp(A946DocTipo, "M")==0) ? "MUESTRA" : ((StringUtil.StrCmp(A946DocTipo, "A")==0) ? "ANTICIPO" : ((StringUtil.StrCmp(A946DocTipo, "E")==0) ? "EXPORTACION" : ((StringUtil.StrCmp(A946DocTipo, "X")==0) ? "MUESTRA EXPORTACION" : "NORMAL"))));
               if ( StringUtil.StrCmp(AV36DocSts, "A") == 0 )
               {
                  AV21DocCliCod = "";
                  AV22DocCliDsc = "ANULADO";
                  AV35Signo = 1;
                  AV31DocSub = 0.00m;
                  AV32DocIVA = 0.00m;
                  AV23TotalVenta = 0.00m;
               }
               H9F0( false, 19) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22DocCliDsc, "")), 410, Gx_line+2, 696, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23TotalVenta, "ZZZZZZ,ZZZ,ZZ9.99")), 882, Gx_line+1, 1007, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 5, Gx_line+1, 39, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A24DocNum, "")), 45, Gx_line+1, 121, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A232DocFec, "99/99/99"), 142, Gx_line+1, 197, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A931DocFVcto, "99/99/9999"), 206, Gx_line+1, 276, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 267, Gx_line+1, 405, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32DocIVA, "ZZZZZZ,ZZZ,ZZ9.99")), 777, Gx_line+1, 902, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31DocSub, "ZZZZ,ZZZ,ZZ9.99")), 685, Gx_line+1, 795, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TipoVenta, "")), 1019, Gx_line+1, 1083, Gx_line+16, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV33TotalSub = (decimal)(AV33TotalSub+AV31DocSub);
               AV34TotalIVA = (decimal)(AV34TotalIVA+AV32DocIVA);
               AV27TotalGeneral = (decimal)(AV27TotalGeneral+AV23TotalVenta);
               pr_default.readNext(5);
            }
            pr_default.close(5);
            if ( ! (0==AV28DocMonCod) )
            {
               H9F0( false, 38) ;
               getPrinter().GxDrawLine(671, Gx_line+6, 1010, Gx_line+6, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total General", 595, Gx_line+11, 688, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27TotalGeneral, "ZZZZZZZZZ,ZZ9.99")), 890, Gx_line+13, 1008, Gx_line+28, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34TotalIVA, "ZZZZZZ,ZZZ,ZZ9.99")), 777, Gx_line+13, 902, Gx_line+28, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33TotalSub, "ZZZZZZ,ZZZ,ZZ9.99")), 685, Gx_line+13, 810, Gx_line+28, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+38);
            }
            H9F0( false, 49) ;
            getPrinter().GxDrawRect(355, Gx_line+24, 699, Gx_line+49, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(550, Gx_line+24, 550, Gx_line+49, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Moneda", 426, Gx_line+29, 474, Gx_line+43, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Importe Total", 575, Gx_line+29, 658, Gx_line+43, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+49);
            /* Using cursor P009F9 */
            pr_default.execute(6);
            while ( (pr_default.getStatus(6) != 101) )
            {
               A180MonCod = P009F9_A180MonCod[0];
               A1234MonDsc = P009F9_A1234MonDsc[0];
               n1234MonDsc = P009F9_n1234MonDsc[0];
               AV48MonOriGen = A180MonCod;
               AV46Moneda = A1234MonDsc;
               AV47TotalMoneda = 0.00m;
               pr_default.dynParam(7, new Object[]{ new Object[]{
                                                    AV51TieCod ,
                                                    AV8TipCCod ,
                                                    AV9EstCod ,
                                                    AV10CliCod ,
                                                    AV11TipCod ,
                                                    AV13PaiCod ,
                                                    AV28DocMonCod ,
                                                    AV44DocConpCod ,
                                                    AV53VenCod ,
                                                    AV49Tipo ,
                                                    AV45Serie ,
                                                    A178TieCod ,
                                                    A159TipCCod ,
                                                    A140EstCod ,
                                                    A231DocCliCod ,
                                                    A149TipCod ,
                                                    A139PaiCod ,
                                                    A230DocMonCod ,
                                                    A229DocConpCod ,
                                                    A227DocVendCod ,
                                                    A946DocTipo ,
                                                    A24DocNum ,
                                                    A180MonCod ,
                                                    A232DocFec ,
                                                    AV14FDesde ,
                                                    AV15FHasta } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                    TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                    }
               });
               /* Using cursor P009F11 */
               pr_default.execute(7, new Object[] {A180MonCod, AV14FDesde, AV15FHasta, AV51TieCod, AV8TipCCod, AV9EstCod, AV10CliCod, AV11TipCod, AV13PaiCod, AV28DocMonCod, AV44DocConpCod, AV53VenCod, AV49Tipo, AV45Serie});
               while ( (pr_default.getStatus(7) != 101) )
               {
                  A230DocMonCod = P009F11_A230DocMonCod[0];
                  A232DocFec = P009F11_A232DocFec[0];
                  A24DocNum = P009F11_A24DocNum[0];
                  A946DocTipo = P009F11_A946DocTipo[0];
                  A227DocVendCod = P009F11_A227DocVendCod[0];
                  A229DocConpCod = P009F11_A229DocConpCod[0];
                  A139PaiCod = P009F11_A139PaiCod[0];
                  n139PaiCod = P009F11_n139PaiCod[0];
                  A149TipCod = P009F11_A149TipCod[0];
                  A231DocCliCod = P009F11_A231DocCliCod[0];
                  A140EstCod = P009F11_A140EstCod[0];
                  n140EstCod = P009F11_n140EstCod[0];
                  A159TipCCod = P009F11_A159TipCCod[0];
                  n159TipCCod = P009F11_n159TipCCod[0];
                  A178TieCod = P009F11_A178TieCod[0];
                  n178TieCod = P009F11_n178TieCod[0];
                  A511TipSigno = P009F11_A511TipSigno[0];
                  A941DocSts = P009F11_A941DocSts[0];
                  A935DocRedondeo = P009F11_A935DocRedondeo[0];
                  A934DocPorIVA = P009F11_A934DocPorIVA[0];
                  A899DocDcto = P009F11_A899DocDcto[0];
                  A927DocSubExonerado = P009F11_A927DocSubExonerado[0];
                  A922DocSubSelectivo = P009F11_A922DocSubSelectivo[0];
                  A921DocSubInafecto = P009F11_A921DocSubInafecto[0];
                  A920DocSubAfecto = P009F11_A920DocSubAfecto[0];
                  A932DocICBPER = P009F11_A932DocICBPER[0];
                  A882DocAnticipos = P009F11_A882DocAnticipos[0];
                  A511TipSigno = P009F11_A511TipSigno[0];
                  A927DocSubExonerado = P009F11_A927DocSubExonerado[0];
                  A922DocSubSelectivo = P009F11_A922DocSubSelectivo[0];
                  A921DocSubInafecto = P009F11_A921DocSubInafecto[0];
                  A920DocSubAfecto = P009F11_A920DocSubAfecto[0];
                  A139PaiCod = P009F11_A139PaiCod[0];
                  n139PaiCod = P009F11_n139PaiCod[0];
                  A140EstCod = P009F11_A140EstCod[0];
                  n140EstCod = P009F11_n140EstCod[0];
                  A159TipCCod = P009F11_A159TipCCod[0];
                  n159TipCCod = P009F11_n159TipCCod[0];
                  A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
                  A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
                  A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
                  A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
                  AV47TotalMoneda = (decimal)(AV47TotalMoneda+(((StringUtil.StrCmp(A941DocSts, "A")==0) ? (decimal)(0) : A948DocTot*A511TipSigno)));
                  pr_default.readNext(7);
               }
               pr_default.close(7);
               if ( ! (Convert.ToDecimal(0)==AV47TotalMoneda) )
               {
                  H9F0( false, 25) ;
                  getPrinter().GxDrawLine(355, Gx_line+0, 355, Gx_line+25, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(550, Gx_line+0, 550, Gx_line+25, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(355, Gx_line+24, 699, Gx_line+24, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(698, Gx_line+0, 698, Gx_line+24, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Moneda, "")), 370, Gx_line+5, 527, Gx_line+20, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TotalMoneda, "ZZZZZZ,ZZZ,ZZ9.99")), 568, Gx_line+5, 675, Gx_line+20, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+25);
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9F0( true, 0) ;
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

      protected void H9F0( bool bFoot ,
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
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hora:", 981, Gx_line+40, 1014, Gx_line+54, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 981, Gx_line+59, 1027, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 981, Gx_line+21, 1023, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Documentos", 431, Gx_line+67, 664, Gx_line+86, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo de Documento", 294, Gx_line+114, 425, Gx_line+128, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Cliente", 294, Gx_line+135, 396, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Estado", 294, Gx_line+179, 341, Gx_line+193, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 294, Gx_line+200, 342, Gx_line+214, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Filtro1, "")), 427, Gx_line+108, 770, Gx_line+132, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17Filtro2, "")), 427, Gx_line+130, 770, Gx_line+154, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Filtro4, "")), 427, Gx_line+174, 770, Gx_line+198, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20Filtro5, "")), 427, Gx_line+195, 770, Gx_line+219, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+246, 1106, Gx_line+272, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1028, Gx_line+21, 1083, Gx_line+36, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1022, Gx_line+40, 1082, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1039, Gx_line+59, 1084, Gx_line+74, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 9, Gx_line+252, 36, Gx_line+266, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 413, Gx_line+252, 461, Gx_line+266, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Venta", 928, Gx_line+252, 1006, Gx_line+266, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 294, Gx_line+224, 337, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV14FDesde, "99/99/99"), 427, Gx_line+217, 501, Gx_line+241, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 545, Gx_line+224, 585, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV15FHasta, "99/99/99"), 596, Gx_line+217, 670, Gx_line+241, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Pais", 294, Gx_line+157, 323, Gx_line+171, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Filtro3, "")), 427, Gx_line+152, 770, Gx_line+176, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Documento", 44, Gx_line+252, 141, Gx_line+266, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 148, Gx_line+252, 190, Gx_line+266, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("F. Vcto", 210, Gx_line+252, 257, Gx_line+266, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 311, Gx_line+252, 364, Gx_line+266, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Sub - Total", 732, Gx_line+252, 807, Gx_line+266, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("I.G.V.", 846, Gx_line+252, 883, Gx_line+266, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV38Logo)) ? AV56Logo_GXI : AV38Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+11, 167, Gx_line+89) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Empresa, "")), 9, Gx_line+93, 377, Gx_line+111, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41EmpRUC, "")), 9, Gx_line+110, 238, Gx_line+128, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo Venta", 1023, Gx_line+252, 1096, Gx_line+266, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+272);
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
         add_metrics4( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Verdana", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics3( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics4( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
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
         AV56Logo_GXI = "";
         AV16Filtro1 = "";
         AV17Filtro2 = "";
         AV18Filtro3 = "";
         AV19Filtro4 = "";
         AV20Filtro5 = "";
         scmdbuf = "";
         P009F2_A149TipCod = new string[] {""} ;
         P009F2_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         P009F3_A159TipCCod = new int[1] ;
         P009F3_n159TipCCod = new bool[] {false} ;
         P009F3_A1905TipCDsc = new string[] {""} ;
         A1905TipCDsc = "";
         P009F4_A139PaiCod = new string[] {""} ;
         P009F4_n139PaiCod = new bool[] {false} ;
         P009F4_A1500PaiDsc = new string[] {""} ;
         A139PaiCod = "";
         A1500PaiDsc = "";
         P009F5_A140EstCod = new string[] {""} ;
         P009F5_n140EstCod = new bool[] {false} ;
         P009F5_A602EstDsc = new string[] {""} ;
         P009F5_A139PaiCod = new string[] {""} ;
         P009F5_n139PaiCod = new bool[] {false} ;
         A140EstCod = "";
         A602EstDsc = "";
         P009F6_A45CliCod = new string[] {""} ;
         P009F6_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         A231DocCliCod = "";
         A946DocTipo = "";
         A24DocNum = "";
         A232DocFec = DateTime.MinValue;
         P009F8_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P009F8_A24DocNum = new string[] {""} ;
         P009F8_A946DocTipo = new string[] {""} ;
         P009F8_A227DocVendCod = new int[1] ;
         P009F8_A229DocConpCod = new int[1] ;
         P009F8_A230DocMonCod = new int[1] ;
         P009F8_A139PaiCod = new string[] {""} ;
         P009F8_n139PaiCod = new bool[] {false} ;
         P009F8_A149TipCod = new string[] {""} ;
         P009F8_A231DocCliCod = new string[] {""} ;
         P009F8_A140EstCod = new string[] {""} ;
         P009F8_n140EstCod = new bool[] {false} ;
         P009F8_A159TipCCod = new int[1] ;
         P009F8_n159TipCCod = new bool[] {false} ;
         P009F8_A178TieCod = new int[1] ;
         P009F8_n178TieCod = new bool[] {false} ;
         P009F8_A941DocSts = new string[] {""} ;
         P009F8_A887DocCliDsc = new string[] {""} ;
         P009F8_A511TipSigno = new short[1] ;
         P009F8_A1234MonDsc = new string[] {""} ;
         P009F8_n1234MonDsc = new bool[] {false} ;
         P009F8_A931DocFVcto = new DateTime[] {DateTime.MinValue} ;
         P009F8_A306TipAbr = new string[] {""} ;
         P009F8_A932DocICBPER = new decimal[1] ;
         P009F8_A935DocRedondeo = new decimal[1] ;
         P009F8_A934DocPorIVA = new decimal[1] ;
         P009F8_A882DocAnticipos = new decimal[1] ;
         P009F8_A899DocDcto = new decimal[1] ;
         P009F8_A927DocSubExonerado = new decimal[1] ;
         P009F8_A922DocSubSelectivo = new decimal[1] ;
         P009F8_A921DocSubInafecto = new decimal[1] ;
         P009F8_A920DocSubAfecto = new decimal[1] ;
         A941DocSts = "";
         A887DocCliDsc = "";
         A1234MonDsc = "";
         A931DocFVcto = DateTime.MinValue;
         A306TipAbr = "";
         AV36DocSts = "";
         AV21DocCliCod = "";
         AV22DocCliDsc = "";
         AV50TipoVenta = "";
         P009F9_A180MonCod = new int[1] ;
         P009F9_A1234MonDsc = new string[] {""} ;
         P009F9_n1234MonDsc = new bool[] {false} ;
         AV46Moneda = "";
         P009F11_A230DocMonCod = new int[1] ;
         P009F11_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P009F11_A24DocNum = new string[] {""} ;
         P009F11_A946DocTipo = new string[] {""} ;
         P009F11_A227DocVendCod = new int[1] ;
         P009F11_A229DocConpCod = new int[1] ;
         P009F11_A139PaiCod = new string[] {""} ;
         P009F11_n139PaiCod = new bool[] {false} ;
         P009F11_A149TipCod = new string[] {""} ;
         P009F11_A231DocCliCod = new string[] {""} ;
         P009F11_A140EstCod = new string[] {""} ;
         P009F11_n140EstCod = new bool[] {false} ;
         P009F11_A159TipCCod = new int[1] ;
         P009F11_n159TipCCod = new bool[] {false} ;
         P009F11_A178TieCod = new int[1] ;
         P009F11_n178TieCod = new bool[] {false} ;
         P009F11_A511TipSigno = new short[1] ;
         P009F11_A941DocSts = new string[] {""} ;
         P009F11_A935DocRedondeo = new decimal[1] ;
         P009F11_A934DocPorIVA = new decimal[1] ;
         P009F11_A899DocDcto = new decimal[1] ;
         P009F11_A927DocSubExonerado = new decimal[1] ;
         P009F11_A922DocSubSelectivo = new decimal[1] ;
         P009F11_A921DocSubInafecto = new decimal[1] ;
         P009F11_A920DocSubAfecto = new decimal[1] ;
         P009F11_A932DocICBPER = new decimal[1] ;
         P009F11_A882DocAnticipos = new decimal[1] ;
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV38Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrresumendocumentos__default(),
            new Object[][] {
                new Object[] {
               P009F2_A149TipCod, P009F2_A1910TipDsc
               }
               , new Object[] {
               P009F3_A159TipCCod, P009F3_A1905TipCDsc
               }
               , new Object[] {
               P009F4_A139PaiCod, P009F4_A1500PaiDsc
               }
               , new Object[] {
               P009F5_A140EstCod, P009F5_A602EstDsc, P009F5_A139PaiCod
               }
               , new Object[] {
               P009F6_A45CliCod, P009F6_A161CliDsc
               }
               , new Object[] {
               P009F8_A232DocFec, P009F8_A24DocNum, P009F8_A946DocTipo, P009F8_A227DocVendCod, P009F8_A229DocConpCod, P009F8_A230DocMonCod, P009F8_A139PaiCod, P009F8_n139PaiCod, P009F8_A149TipCod, P009F8_A231DocCliCod,
               P009F8_A140EstCod, P009F8_n140EstCod, P009F8_A159TipCCod, P009F8_n159TipCCod, P009F8_A178TieCod, P009F8_n178TieCod, P009F8_A941DocSts, P009F8_A887DocCliDsc, P009F8_A511TipSigno, P009F8_A1234MonDsc,
               P009F8_n1234MonDsc, P009F8_A931DocFVcto, P009F8_A306TipAbr, P009F8_A932DocICBPER, P009F8_A935DocRedondeo, P009F8_A934DocPorIVA, P009F8_A882DocAnticipos, P009F8_A899DocDcto, P009F8_A927DocSubExonerado, P009F8_A922DocSubSelectivo,
               P009F8_A921DocSubInafecto, P009F8_A920DocSubAfecto
               }
               , new Object[] {
               P009F9_A180MonCod, P009F9_A1234MonDsc
               }
               , new Object[] {
               P009F11_A230DocMonCod, P009F11_A232DocFec, P009F11_A24DocNum, P009F11_A946DocTipo, P009F11_A227DocVendCod, P009F11_A229DocConpCod, P009F11_A139PaiCod, P009F11_n139PaiCod, P009F11_A149TipCod, P009F11_A231DocCliCod,
               P009F11_A140EstCod, P009F11_n140EstCod, P009F11_A159TipCCod, P009F11_n159TipCCod, P009F11_A178TieCod, P009F11_n178TieCod, P009F11_A511TipSigno, P009F11_A941DocSts, P009F11_A935DocRedondeo, P009F11_A934DocPorIVA,
               P009F11_A899DocDcto, P009F11_A927DocSubExonerado, P009F11_A922DocSubSelectivo, P009F11_A921DocSubInafecto, P009F11_A920DocSubAfecto, P009F11_A932DocICBPER, P009F11_A882DocAnticipos
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
      private short A511TipSigno ;
      private short AV35Signo ;
      private int AV8TipCCod ;
      private int AV28DocMonCod ;
      private int AV44DocConpCod ;
      private int AV51TieCod ;
      private int AV53VenCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A159TipCCod ;
      private int A178TieCod ;
      private int A230DocMonCod ;
      private int A229DocConpCod ;
      private int A227DocVendCod ;
      private int Gx_OldLine ;
      private int A180MonCod ;
      private int AV48MonOriGen ;
      private decimal AV27TotalGeneral ;
      private decimal AV33TotalSub ;
      private decimal AV34TotalIVA ;
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
      private decimal AV31DocSub ;
      private decimal AV37DocDscto ;
      private decimal AV32DocIVA ;
      private decimal AV23TotalVenta ;
      private decimal AV47TotalMoneda ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV9EstCod ;
      private string AV10CliCod ;
      private string AV11TipCod ;
      private string AV13PaiCod ;
      private string AV45Serie ;
      private string AV49Tipo ;
      private string AV39Empresa ;
      private string AV40EmpDir ;
      private string AV41EmpRUC ;
      private string AV42Ruta ;
      private string AV16Filtro1 ;
      private string AV17Filtro2 ;
      private string AV18Filtro3 ;
      private string AV19Filtro4 ;
      private string AV20Filtro5 ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private string A1905TipCDsc ;
      private string A139PaiCod ;
      private string A1500PaiDsc ;
      private string A140EstCod ;
      private string A602EstDsc ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A231DocCliCod ;
      private string A946DocTipo ;
      private string A24DocNum ;
      private string A941DocSts ;
      private string A887DocCliDsc ;
      private string A1234MonDsc ;
      private string A306TipAbr ;
      private string AV36DocSts ;
      private string AV21DocCliCod ;
      private string AV22DocCliDsc ;
      private string AV50TipoVenta ;
      private string AV46Moneda ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV14FDesde ;
      private DateTime AV15FHasta ;
      private DateTime A232DocFec ;
      private DateTime A931DocFVcto ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n159TipCCod ;
      private bool n139PaiCod ;
      private bool n140EstCod ;
      private bool n178TieCod ;
      private bool n1234MonDsc ;
      private string AV56Logo_GXI ;
      private string AV38Logo ;
      private string Logo ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TipCCod ;
      private string aP1_EstCod ;
      private string aP2_CliCod ;
      private string aP3_TipCod ;
      private string aP4_PaiCod ;
      private DateTime aP5_FDesde ;
      private DateTime aP6_FHasta ;
      private int aP7_DocMonCod ;
      private int aP8_DocConpCod ;
      private string aP9_Serie ;
      private string aP10_Tipo ;
      private int aP11_TieCod ;
      private int aP12_VenCod ;
      private IDataStoreProvider pr_default ;
      private string[] P009F2_A149TipCod ;
      private string[] P009F2_A1910TipDsc ;
      private int[] P009F3_A159TipCCod ;
      private bool[] P009F3_n159TipCCod ;
      private string[] P009F3_A1905TipCDsc ;
      private string[] P009F4_A139PaiCod ;
      private bool[] P009F4_n139PaiCod ;
      private string[] P009F4_A1500PaiDsc ;
      private string[] P009F5_A140EstCod ;
      private bool[] P009F5_n140EstCod ;
      private string[] P009F5_A602EstDsc ;
      private string[] P009F5_A139PaiCod ;
      private bool[] P009F5_n139PaiCod ;
      private string[] P009F6_A45CliCod ;
      private string[] P009F6_A161CliDsc ;
      private DateTime[] P009F8_A232DocFec ;
      private string[] P009F8_A24DocNum ;
      private string[] P009F8_A946DocTipo ;
      private int[] P009F8_A227DocVendCod ;
      private int[] P009F8_A229DocConpCod ;
      private int[] P009F8_A230DocMonCod ;
      private string[] P009F8_A139PaiCod ;
      private bool[] P009F8_n139PaiCod ;
      private string[] P009F8_A149TipCod ;
      private string[] P009F8_A231DocCliCod ;
      private string[] P009F8_A140EstCod ;
      private bool[] P009F8_n140EstCod ;
      private int[] P009F8_A159TipCCod ;
      private bool[] P009F8_n159TipCCod ;
      private int[] P009F8_A178TieCod ;
      private bool[] P009F8_n178TieCod ;
      private string[] P009F8_A941DocSts ;
      private string[] P009F8_A887DocCliDsc ;
      private short[] P009F8_A511TipSigno ;
      private string[] P009F8_A1234MonDsc ;
      private bool[] P009F8_n1234MonDsc ;
      private DateTime[] P009F8_A931DocFVcto ;
      private string[] P009F8_A306TipAbr ;
      private decimal[] P009F8_A932DocICBPER ;
      private decimal[] P009F8_A935DocRedondeo ;
      private decimal[] P009F8_A934DocPorIVA ;
      private decimal[] P009F8_A882DocAnticipos ;
      private decimal[] P009F8_A899DocDcto ;
      private decimal[] P009F8_A927DocSubExonerado ;
      private decimal[] P009F8_A922DocSubSelectivo ;
      private decimal[] P009F8_A921DocSubInafecto ;
      private decimal[] P009F8_A920DocSubAfecto ;
      private int[] P009F9_A180MonCod ;
      private string[] P009F9_A1234MonDsc ;
      private bool[] P009F9_n1234MonDsc ;
      private int[] P009F11_A230DocMonCod ;
      private DateTime[] P009F11_A232DocFec ;
      private string[] P009F11_A24DocNum ;
      private string[] P009F11_A946DocTipo ;
      private int[] P009F11_A227DocVendCod ;
      private int[] P009F11_A229DocConpCod ;
      private string[] P009F11_A139PaiCod ;
      private bool[] P009F11_n139PaiCod ;
      private string[] P009F11_A149TipCod ;
      private string[] P009F11_A231DocCliCod ;
      private string[] P009F11_A140EstCod ;
      private bool[] P009F11_n140EstCod ;
      private int[] P009F11_A159TipCCod ;
      private bool[] P009F11_n159TipCCod ;
      private int[] P009F11_A178TieCod ;
      private bool[] P009F11_n178TieCod ;
      private short[] P009F11_A511TipSigno ;
      private string[] P009F11_A941DocSts ;
      private decimal[] P009F11_A935DocRedondeo ;
      private decimal[] P009F11_A934DocPorIVA ;
      private decimal[] P009F11_A899DocDcto ;
      private decimal[] P009F11_A927DocSubExonerado ;
      private decimal[] P009F11_A922DocSubSelectivo ;
      private decimal[] P009F11_A921DocSubInafecto ;
      private decimal[] P009F11_A920DocSubAfecto ;
      private decimal[] P009F11_A932DocICBPER ;
      private decimal[] P009F11_A882DocAnticipos ;
   }

   public class rrresumendocumentos__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009F8( IGxContext context ,
                                             int AV51TieCod ,
                                             int AV8TipCCod ,
                                             string AV9EstCod ,
                                             string AV10CliCod ,
                                             string AV11TipCod ,
                                             string AV13PaiCod ,
                                             int AV28DocMonCod ,
                                             int AV44DocConpCod ,
                                             int AV53VenCod ,
                                             string AV49Tipo ,
                                             string AV45Serie ,
                                             int A178TieCod ,
                                             int A159TipCCod ,
                                             string A140EstCod ,
                                             string A231DocCliCod ,
                                             string A149TipCod ,
                                             string A139PaiCod ,
                                             int A230DocMonCod ,
                                             int A229DocConpCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             string A24DocNum ,
                                             DateTime A232DocFec ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[13];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[DocFec], T1.[DocNum], T1.[DocTipo], T1.[DocVendCod], T1.[DocConpCod], T1.[DocMonCod] AS DocMonCod, T5.[PaiCod], T1.[TipCod], T1.[DocCliCod] AS DocCliCod, T5.[EstCod], T5.[TipCCod], T1.[TieCod], T1.[DocSts], T5.[CliDsc] AS DocCliDsc, T3.[TipSigno], T2.[MonDsc], T1.[DocFVcto], T3.[TipAbr], T1.[DocICBPER], T1.[DocRedondeo], T1.[DocPorIVA], T1.[DocAnticipos], T1.[DocDcto], COALESCE( T4.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T4.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T4.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T4.[DocSubAfecto], 0) AS DocSubAfecto FROM (((([CLVENTAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[DocMonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum]) INNER JOIN [CLCLIENTES] T5 ON T5.[CliCod] = T1.[DocCliCod])";
         AddWhere(sWhereString, "(T1.[DocFec] >= @AV14FDesde and T1.[DocFec] <= @AV15FHasta)");
         if ( ! (0==AV51TieCod) )
         {
            AddWhere(sWhereString, "(T1.[TieCod] = @AV51TieCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV8TipCCod) )
         {
            AddWhere(sWhereString, "(T5.[TipCCod] = @AV8TipCCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9EstCod)) )
         {
            AddWhere(sWhereString, "(T5.[EstCod] = @AV9EstCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[DocCliCod] = @AV10CliCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[TipCod] = @AV11TipCod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13PaiCod)) )
         {
            AddWhere(sWhereString, "(T5.[PaiCod] = @AV13PaiCod)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV28DocMonCod) )
         {
            AddWhere(sWhereString, "(T1.[DocMonCod] = @AV28DocMonCod)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV44DocConpCod) )
         {
            AddWhere(sWhereString, "(T1.[DocConpCod] = @AV44DocConpCod)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV53VenCod) )
         {
            AddWhere(sWhereString, "(T1.[DocVendCod] = @AV53VenCod)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV49Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] = @AV49Tipo)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV49Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV49Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'X')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[DocNum], 1, 3) = @AV45Serie)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipCod], T1.[DocNum]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P009F11( IGxContext context ,
                                              int AV51TieCod ,
                                              int AV8TipCCod ,
                                              string AV9EstCod ,
                                              string AV10CliCod ,
                                              string AV11TipCod ,
                                              string AV13PaiCod ,
                                              int AV28DocMonCod ,
                                              int AV44DocConpCod ,
                                              int AV53VenCod ,
                                              string AV49Tipo ,
                                              string AV45Serie ,
                                              int A178TieCod ,
                                              int A159TipCCod ,
                                              string A140EstCod ,
                                              string A231DocCliCod ,
                                              string A149TipCod ,
                                              string A139PaiCod ,
                                              int A230DocMonCod ,
                                              int A229DocConpCod ,
                                              int A227DocVendCod ,
                                              string A946DocTipo ,
                                              string A24DocNum ,
                                              int A180MonCod ,
                                              DateTime A232DocFec ,
                                              DateTime AV14FDesde ,
                                              DateTime AV15FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[DocMonCod] AS DocMonCod, T1.[DocFec], T1.[DocNum], T1.[DocTipo], T1.[DocVendCod], T1.[DocConpCod], T4.[PaiCod], T1.[TipCod], T1.[DocCliCod] AS DocCliCod, T4.[EstCod], T4.[TipCCod], T1.[TieCod], T2.[TipSigno], T1.[DocSts], T1.[DocRedondeo], T1.[DocPorIVA], T1.[DocDcto], COALESCE( T3.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T3.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T3.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T3.[DocSubAfecto], 0) AS DocSubAfecto, T1.[DocICBPER], T1.[DocAnticipos] FROM ((([CLVENTAS] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T3 ON T3.[TipCod] = T1.[TipCod] AND T3.[DocNum] = T1.[DocNum]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[DocCliCod])";
         AddWhere(sWhereString, "(T1.[DocMonCod] = @MonCod)");
         AddWhere(sWhereString, "(T1.[DocFec] >= @AV14FDesde and T1.[DocFec] <= @AV15FHasta)");
         if ( ! (0==AV51TieCod) )
         {
            AddWhere(sWhereString, "(T1.[TieCod] = @AV51TieCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV8TipCCod) )
         {
            AddWhere(sWhereString, "(T4.[TipCCod] = @AV8TipCCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9EstCod)) )
         {
            AddWhere(sWhereString, "(T4.[EstCod] = @AV9EstCod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[DocCliCod] = @AV10CliCod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[TipCod] = @AV11TipCod)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13PaiCod)) )
         {
            AddWhere(sWhereString, "(T4.[PaiCod] = @AV13PaiCod)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV28DocMonCod) )
         {
            AddWhere(sWhereString, "(T1.[DocMonCod] = @AV28DocMonCod)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV44DocConpCod) )
         {
            AddWhere(sWhereString, "(T1.[DocConpCod] = @AV44DocConpCod)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (0==AV53VenCod) )
         {
            AddWhere(sWhereString, "(T1.[DocVendCod] = @AV53VenCod)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV49Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] = @AV49Tipo)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV49Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV49Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'X')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[DocNum], 1, 3) = @AV45Serie)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipCod], T1.[DocNum]";
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
               case 5 :
                     return conditional_P009F8(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] );
               case 7 :
                     return conditional_P009F11(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] );
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
          Object[] prmP009F2;
          prmP009F2 = new Object[] {
          new ParDef("@AV11TipCod",GXType.NChar,3,0)
          };
          Object[] prmP009F3;
          prmP009F3 = new Object[] {
          new ParDef("@AV8TipCCod",GXType.Int32,6,0)
          };
          Object[] prmP009F4;
          prmP009F4 = new Object[] {
          new ParDef("@AV13PaiCod",GXType.NChar,4,0)
          };
          Object[] prmP009F5;
          prmP009F5 = new Object[] {
          new ParDef("@AV9EstCod",GXType.NChar,4,0)
          };
          Object[] prmP009F6;
          prmP009F6 = new Object[] {
          new ParDef("@AV10CliCod",GXType.NChar,20,0)
          };
          Object[] prmP009F9;
          prmP009F9 = new Object[] {
          };
          Object[] prmP009F8;
          prmP009F8 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV51TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV8TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV9EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV10CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV11TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV13PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV28DocMonCod",GXType.Int32,6,0) ,
          new ParDef("@AV44DocConpCod",GXType.Int32,6,0) ,
          new ParDef("@AV53VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV49Tipo",GXType.NChar,1,0) ,
          new ParDef("@AV45Serie",GXType.Char,3,0)
          };
          Object[] prmP009F11;
          prmP009F11 = new Object[] {
          new ParDef("@MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV51TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV8TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV9EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV10CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV11TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV13PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV28DocMonCod",GXType.Int32,6,0) ,
          new ParDef("@AV44DocConpCod",GXType.Int32,6,0) ,
          new ParDef("@AV53VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV49Tipo",GXType.NChar,1,0) ,
          new ParDef("@AV45Serie",GXType.Char,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009F2", "SELECT [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipCod] = @AV11TipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009F3", "SELECT [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @AV8TipCCod ORDER BY [TipCCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009F4", "SELECT [PaiCod], [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @AV13PaiCod ORDER BY [PaiCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009F5", "SELECT [EstCod], [EstDsc], [PaiCod] FROM [CESTADOS] WHERE [EstCod] = @AV9EstCod ORDER BY [PaiCod], [EstCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009F6", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV10CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009F8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009F9", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009F11", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F11,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 5 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 4);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 3);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getString(10, 4);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((int[]) buf[14])[0] = rslt.getInt(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getString(13, 1);
                ((string[]) buf[17])[0] = rslt.getString(14, 100);
                ((short[]) buf[18])[0] = rslt.getShort(15);
                ((string[]) buf[19])[0] = rslt.getString(16, 100);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(17);
                ((string[]) buf[22])[0] = rslt.getString(18, 5);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(26);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(27);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 4);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 3);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getString(10, 4);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((int[]) buf[14])[0] = rslt.getInt(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((short[]) buf[16])[0] = rslt.getShort(13);
                ((string[]) buf[17])[0] = rslt.getString(14, 1);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(23);
                return;
       }
    }

 }

}
