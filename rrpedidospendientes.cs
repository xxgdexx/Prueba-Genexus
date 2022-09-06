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
   public class rrpedidospendientes : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrpedidospendientes.aspx")), "rrpedidospendientes.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrpedidospendientes.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "CliCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV11CliCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV49ProdCod = GetPar( "ProdCod");
                  AV33MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV22FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV23FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV46PedSts = GetPar( "PedSts");
                  AV63TPedCod = (int)(NumberUtil.Val( GetPar( "TPedCod"), "."));
                  AV64VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
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

      public rrpedidospendientes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrpedidospendientes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CliCod ,
                           ref string aP1_ProdCod ,
                           ref int aP2_MonCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref string aP5_PedSts ,
                           ref int aP6_TPedCod ,
                           ref int aP7_VenCod )
      {
         this.AV11CliCod = aP0_CliCod;
         this.AV49ProdCod = aP1_ProdCod;
         this.AV33MonCod = aP2_MonCod;
         this.AV22FDesde = aP3_FDesde;
         this.AV23FHasta = aP4_FHasta;
         this.AV46PedSts = aP5_PedSts;
         this.AV63TPedCod = aP6_TPedCod;
         this.AV64VenCod = aP7_VenCod;
         initialize();
         executePrivate();
         aP0_CliCod=this.AV11CliCod;
         aP1_ProdCod=this.AV49ProdCod;
         aP2_MonCod=this.AV33MonCod;
         aP3_FDesde=this.AV22FDesde;
         aP4_FHasta=this.AV23FHasta;
         aP5_PedSts=this.AV46PedSts;
         aP6_TPedCod=this.AV63TPedCod;
         aP7_VenCod=this.AV64VenCod;
      }

      public int executeUdp( ref string aP0_CliCod ,
                             ref string aP1_ProdCod ,
                             ref int aP2_MonCod ,
                             ref DateTime aP3_FDesde ,
                             ref DateTime aP4_FHasta ,
                             ref string aP5_PedSts ,
                             ref int aP6_TPedCod )
      {
         execute(ref aP0_CliCod, ref aP1_ProdCod, ref aP2_MonCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_PedSts, ref aP6_TPedCod, ref aP7_VenCod);
         return AV64VenCod ;
      }

      public void executeSubmit( ref string aP0_CliCod ,
                                 ref string aP1_ProdCod ,
                                 ref int aP2_MonCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref string aP5_PedSts ,
                                 ref int aP6_TPedCod ,
                                 ref int aP7_VenCod )
      {
         rrpedidospendientes objrrpedidospendientes;
         objrrpedidospendientes = new rrpedidospendientes();
         objrrpedidospendientes.AV11CliCod = aP0_CliCod;
         objrrpedidospendientes.AV49ProdCod = aP1_ProdCod;
         objrrpedidospendientes.AV33MonCod = aP2_MonCod;
         objrrpedidospendientes.AV22FDesde = aP3_FDesde;
         objrrpedidospendientes.AV23FHasta = aP4_FHasta;
         objrrpedidospendientes.AV46PedSts = aP5_PedSts;
         objrrpedidospendientes.AV63TPedCod = aP6_TPedCod;
         objrrpedidospendientes.AV64VenCod = aP7_VenCod;
         objrrpedidospendientes.context.SetSubmitInitialConfig(context);
         objrrpedidospendientes.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrpedidospendientes);
         aP0_CliCod=this.AV11CliCod;
         aP1_ProdCod=this.AV49ProdCod;
         aP2_MonCod=this.AV33MonCod;
         aP3_FDesde=this.AV22FDesde;
         aP4_FHasta=this.AV23FHasta;
         aP5_PedSts=this.AV46PedSts;
         aP6_TPedCod=this.AV63TPedCod;
         aP7_VenCod=this.AV64VenCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrpedidospendientes)stateInfo).executePrivate();
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
            AV18Empresa = AV53Session.Get("Empresa");
            AV17EmpDir = AV53Session.Get("EmpDir");
            AV19EmpRUC = AV53Session.Get("EmpRUC");
            AV51Ruta = AV53Session.Get("RUTA") + "/Logo.jpg";
            AV32Logo = AV51Ruta;
            AV67Logo_GXI = GXDbFile.PathToUrl( AV51Ruta);
            AV24Filtro1 = "Todos";
            AV25Filtro2 = "Todos";
            AV26Filtro3 = "Todos";
            AV27Filtro4 = AV22FDesde;
            AV28Filtro5 = AV23FHasta;
            /* Using cursor P00AF2 */
            pr_default.execute(0, new Object[] {AV11CliCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A45CliCod = P00AF2_A45CliCod[0];
               A161CliDsc = P00AF2_A161CliDsc[0];
               AV24Filtro1 = A161CliDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00AF3 */
            pr_default.execute(1, new Object[] {AV33MonCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A180MonCod = P00AF3_A180MonCod[0];
               A1234MonDsc = P00AF3_A1234MonDsc[0];
               AV25Filtro2 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV26Filtro3 = ((AV34Opcion==1) ? "Pendientes" : "Todos");
            AV56TotGeneral = 0.00m;
            AV57TotGImporte = 0.00m;
            AV58TotGPagos = 0.00m;
            AV59TotGSaldo = 0.00m;
            AV31Item = 0;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV11CliCod ,
                                                 AV33MonCod ,
                                                 AV46PedSts ,
                                                 AV63TPedCod ,
                                                 AV64VenCod ,
                                                 A45CliCod ,
                                                 A180MonCod ,
                                                 A1606PedSts ,
                                                 A212TPedCod ,
                                                 A211PedVendCod ,
                                                 A215PedFec ,
                                                 AV22FDesde ,
                                                 AV23FHasta ,
                                                 A1549PedCotiza } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00AF4 */
            pr_default.execute(2, new Object[] {AV22FDesde, AV23FHasta, AV11CliCod, AV33MonCod, AV46PedSts, AV63TPedCod, AV64VenCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A1605PedRef = P00AF4_A1605PedRef[0];
               A215PedFec = P00AF4_A215PedFec[0];
               A210PedCod = P00AF4_A210PedCod[0];
               A1549PedCotiza = P00AF4_A1549PedCotiza[0];
               A211PedVendCod = P00AF4_A211PedVendCod[0];
               A212TPedCod = P00AF4_A212TPedCod[0];
               A1606PedSts = P00AF4_A1606PedSts[0];
               A180MonCod = P00AF4_A180MonCod[0];
               A45CliCod = P00AF4_A45CliCod[0];
               A161CliDsc = P00AF4_A161CliDsc[0];
               A1545PedCliDespacho = P00AF4_A1545PedCliDespacho[0];
               A1234MonDsc = P00AF4_A1234MonDsc[0];
               A1234MonDsc = P00AF4_A1234MonDsc[0];
               A161CliDsc = P00AF4_A161CliDsc[0];
               AV31Item = (int)(AV31Item+1);
               AV37PedCliCod = A45CliCod;
               AV12CliDsc = A161CliDsc;
               AV38PedCliDespacho = A1545PedCliDespacho;
               if ( ! (0==AV38PedCliDespacho) )
               {
                  /* Execute user subroutine: 'VERIFICACLIENTEDESPACHO' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(2);
                     this.cleanup();
                     if (true) return;
                  }
               }
               HAF0( false, 21) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12CliDsc, "")), 63, Gx_line+4, 444, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31Item), "ZZZZ9")), 8, Gx_line+4, 40, Gx_line+19, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 466, Gx_line+4, 738, Gx_line+18, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
               AV39PedDCan = 0.00m;
               AV40PedDCanDsp = 0.00m;
               AV41PedDCanFac = 0.00m;
               AV47Precio = 0.00m;
               AV15Dscto = 0.00m;
               AV48PreTot = 0.00m;
               pr_default.dynParam(3, new Object[]{ new Object[]{
                                                    AV49ProdCod ,
                                                    A28ProdCod ,
                                                    A210PedCod } ,
                                                    new int[]{
                                                    }
               });
               /* Using cursor P00AF5 */
               pr_default.execute(3, new Object[] {A210PedCod, AV49ProdCod});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A49UniCod = P00AF5_A49UniCod[0];
                  A28ProdCod = P00AF5_A28ProdCod[0];
                  A1558PedDCanDSP = P00AF5_A1558PedDCanDSP[0];
                  A1559PedDCanFAC = P00AF5_A1559PedDCanFAC[0];
                  A1555PedDDct = P00AF5_A1555PedDDct[0];
                  A1556PedDDct2 = P00AF5_A1556PedDDct2[0];
                  A1551PedDTot = P00AF5_A1551PedDTot[0];
                  A1572PedDObs = P00AF5_A1572PedDObs[0];
                  A55ProdDsc = P00AF5_A55ProdDsc[0];
                  A1997UniAbr = P00AF5_A1997UniAbr[0];
                  A1554PedDCan = P00AF5_A1554PedDCan[0];
                  A1553PedDPre = P00AF5_A1553PedDPre[0];
                  A216PedDItem = P00AF5_A216PedDItem[0];
                  A49UniCod = P00AF5_A49UniCod[0];
                  A1997UniAbr = P00AF5_A1997UniAbr[0];
                  A1552PedDSub = NumberUtil.Round( A1553PedDPre*A1554PedDCan, 4);
                  AV39PedDCan = (decimal)(AV39PedDCan+A1554PedDCan);
                  AV40PedDCanDsp = (decimal)(AV40PedDCanDsp+A1558PedDCanDSP);
                  AV41PedDCanFac = (decimal)(AV41PedDCanFac+A1559PedDCanFAC);
                  AV8PedDDct = A1555PedDDct;
                  AV9PedDDct2 = A1556PedDDct2;
                  AV13Descuento = NumberUtil.Round( (A1552PedDSub)*(1-(A1555PedDDct/ (decimal)(100)))*(1-(A1556PedDDct2/ (decimal)(100))), 2);
                  AV44PedDPre = A1553PedDPre;
                  AV15Dscto = NumberUtil.Round( A1552PedDSub-A1551PedDTot, 2);
                  AV45PedDTot = A1551PedDTot;
                  AV47Precio = (decimal)(AV47Precio+AV44PedDPre);
                  AV16Dsctot = (decimal)(AV16Dsctot+AV15Dscto);
                  AV48PreTot = (decimal)(AV48PreTot+AV45PedDTot);
                  AV43PedDObs = StringUtil.Trim( A1572PedDObs);
                  AV50Producto = StringUtil.Trim( A55ProdDsc);
                  HAF0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A210PedCod, "")), 5, Gx_line+2, 79, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A215PedFec, "99/99/99"), 150, Gx_line+1, 209, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 211, Gx_line+1, 299, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Producto, "")), 298, Gx_line+1, 536, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1559PedDCanFAC, "ZZZZ,ZZZ,ZZ9.9999")), 983, Gx_line+1, 1088, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1558PedDCanDSP, "ZZZZ,ZZZ,ZZ9.9999")), 896, Gx_line+1, 1001, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1554PedDCan, "ZZZZ,ZZZ,ZZ9.9999")), 814, Gx_line+1, 911, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 534, Gx_line+1, 578, Gx_line+16, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44PedDPre, "ZZZZ,ZZZ,ZZ9.9999")), 580, Gx_line+1, 687, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV15Dscto, "ZZZZZZ,ZZZ,ZZ9.99")), 650, Gx_line+1, 757, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45PedDTot, "ZZZZ,ZZZ,ZZ9.99")), 732, Gx_line+1, 846, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1605PedRef, "")), 80, Gx_line+2, 151, Gx_line+16, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  AV56TotGeneral = (decimal)(AV56TotGeneral+AV48PreTot);
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               HAF0( false, 24) ;
               getPrinter().GxDrawLine(532, Gx_line+1, 1086, Gx_line+1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Cliente", 331, Gx_line+5, 406, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41PedDCanFac, "ZZZZ,ZZZ,ZZ9.9999")), 983, Gx_line+6, 1088, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40PedDCanDsp, "ZZZZ,ZZZ,ZZ9.9999")), 896, Gx_line+6, 1001, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39PedDCan, "ZZZZ,ZZZ,ZZ9.9999")), 814, Gx_line+6, 911, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48PreTot, "ZZZZZZ,ZZZ,ZZ9.99")), 739, Gx_line+5, 846, Gx_line+20, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16Dsctot, "ZZZZZZ,ZZZ,ZZ9.99")), 650, Gx_line+5, 757, Gx_line+20, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47Precio, "ZZZZ,ZZZ,ZZ9.9999")), 580, Gx_line+5, 687, Gx_line+20, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            HAF0( false, 41) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 649, Gx_line+12, 729, Gx_line+26, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56TotGeneral, "ZZZZZZ,ZZZ,ZZ9.99")), 739, Gx_line+12, 846, Gx_line+27, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+41);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAF0( true, 0) ;
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
         /* 'VERIFICACLIENTEDESPACHO' Routine */
         returnInSub = false;
         /* Using cursor P00AF6 */
         pr_default.execute(4, new Object[] {AV37PedCliCod, AV38PedCliDespacho});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A164CliDirItem = P00AF6_A164CliDirItem[0];
            A45CliCod = P00AF6_A45CliCod[0];
            A600CliDirDsc = P00AF6_A600CliDirDsc[0];
            AV12CliDsc = A600CliDirDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void HAF0( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Pedido", 14, Gx_line+235, 55, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 164, Gx_line+235, 199, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Unidad", 535, Gx_line+235, 577, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+214, 1095, Gx_line+254, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Pedidos", 424, Gx_line+52, 601, Gx_line+72, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 227, Gx_line+235, 268, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 320, Gx_line+235, 374, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Facturada", 1017, Gx_line+235, 1077, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Despachada", 922, Gx_line+235, 995, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 320, Gx_line+107, 362, Gx_line+121, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 320, Gx_line+129, 368, Gx_line+143, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 320, Gx_line+151, 346, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 320, Gx_line+173, 357, Gx_line+187, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta", 320, Gx_line+194, 355, Gx_line+208, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro1, "")), 376, Gx_line+102, 719, Gx_line+126, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Filtro2, "")), 376, Gx_line+124, 719, Gx_line+148, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Filtro3, "")), 376, Gx_line+146, 719, Gx_line+170, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV27Filtro4, "99/99/99"), 376, Gx_line+168, 719, Gx_line+192, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV28Filtro5, "99/99/99"), 376, Gx_line+189, 719, Gx_line+213, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Pedida", 852, Gx_line+235, 893, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(847, Gx_line+233, 1088, Gx_line+233, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 934, Gx_line+216, 987, Gx_line+230, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV32Logo)) ? AV67Logo_GXI : AV32Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 14, Gx_line+11, 172, Gx_line+89) ;
               getPrinter().GxDrawText("Precio Unit.", 629, Gx_line+235, 697, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dscto", 713, Gx_line+235, 747, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total", 804, Gx_line+235, 835, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19EmpRUC, "")), 14, Gx_line+106, 152, Gx_line+124, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Empresa, "")), 14, Gx_line+89, 320, Gx_line+107, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("O/C", 93, Gx_line+235, 116, Gx_line+249, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+254);
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
         AV18Empresa = "";
         AV53Session = context.GetSession();
         AV17EmpDir = "";
         AV19EmpRUC = "";
         AV51Ruta = "";
         AV32Logo = "";
         AV67Logo_GXI = "";
         AV24Filtro1 = "";
         AV25Filtro2 = "";
         AV26Filtro3 = "";
         AV27Filtro4 = DateTime.MinValue;
         AV28Filtro5 = DateTime.MinValue;
         scmdbuf = "";
         P00AF2_A45CliCod = new string[] {""} ;
         P00AF2_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         P00AF3_A180MonCod = new int[1] ;
         P00AF3_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         A1606PedSts = "";
         A215PedFec = DateTime.MinValue;
         P00AF4_A1605PedRef = new string[] {""} ;
         P00AF4_A215PedFec = new DateTime[] {DateTime.MinValue} ;
         P00AF4_A210PedCod = new string[] {""} ;
         P00AF4_A1549PedCotiza = new short[1] ;
         P00AF4_A211PedVendCod = new int[1] ;
         P00AF4_A212TPedCod = new int[1] ;
         P00AF4_A1606PedSts = new string[] {""} ;
         P00AF4_A180MonCod = new int[1] ;
         P00AF4_A45CliCod = new string[] {""} ;
         P00AF4_A161CliDsc = new string[] {""} ;
         P00AF4_A1545PedCliDespacho = new int[1] ;
         P00AF4_A1234MonDsc = new string[] {""} ;
         A1605PedRef = "";
         A210PedCod = "";
         AV37PedCliCod = "";
         AV12CliDsc = "";
         A28ProdCod = "";
         P00AF5_A49UniCod = new int[1] ;
         P00AF5_A210PedCod = new string[] {""} ;
         P00AF5_A28ProdCod = new string[] {""} ;
         P00AF5_A1558PedDCanDSP = new decimal[1] ;
         P00AF5_A1559PedDCanFAC = new decimal[1] ;
         P00AF5_A1555PedDDct = new decimal[1] ;
         P00AF5_A1556PedDDct2 = new decimal[1] ;
         P00AF5_A1551PedDTot = new decimal[1] ;
         P00AF5_A1572PedDObs = new string[] {""} ;
         P00AF5_A55ProdDsc = new string[] {""} ;
         P00AF5_A1997UniAbr = new string[] {""} ;
         P00AF5_A1554PedDCan = new decimal[1] ;
         P00AF5_A1553PedDPre = new decimal[1] ;
         P00AF5_A216PedDItem = new short[1] ;
         A1572PedDObs = "";
         A55ProdDsc = "";
         A1997UniAbr = "";
         AV43PedDObs = "";
         AV50Producto = "";
         P00AF6_A164CliDirItem = new int[1] ;
         P00AF6_A45CliCod = new string[] {""} ;
         P00AF6_A600CliDirDsc = new string[] {""} ;
         A600CliDirDsc = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV32Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrpedidospendientes__default(),
            new Object[][] {
                new Object[] {
               P00AF2_A45CliCod, P00AF2_A161CliDsc
               }
               , new Object[] {
               P00AF3_A180MonCod, P00AF3_A1234MonDsc
               }
               , new Object[] {
               P00AF4_A1605PedRef, P00AF4_A215PedFec, P00AF4_A210PedCod, P00AF4_A1549PedCotiza, P00AF4_A211PedVendCod, P00AF4_A212TPedCod, P00AF4_A1606PedSts, P00AF4_A180MonCod, P00AF4_A45CliCod, P00AF4_A161CliDsc,
               P00AF4_A1545PedCliDespacho, P00AF4_A1234MonDsc
               }
               , new Object[] {
               P00AF5_A49UniCod, P00AF5_A210PedCod, P00AF5_A28ProdCod, P00AF5_A1558PedDCanDSP, P00AF5_A1559PedDCanFAC, P00AF5_A1555PedDDct, P00AF5_A1556PedDDct2, P00AF5_A1551PedDTot, P00AF5_A1572PedDObs, P00AF5_A55ProdDsc,
               P00AF5_A1997UniAbr, P00AF5_A1554PedDCan, P00AF5_A1553PedDPre, P00AF5_A216PedDItem
               }
               , new Object[] {
               P00AF6_A164CliDirItem, P00AF6_A45CliCod, P00AF6_A600CliDirDsc
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
      private short AV34Opcion ;
      private short A1549PedCotiza ;
      private short A216PedDItem ;
      private int AV33MonCod ;
      private int AV63TPedCod ;
      private int AV64VenCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int AV31Item ;
      private int A212TPedCod ;
      private int A211PedVendCod ;
      private int A1545PedCliDespacho ;
      private int AV38PedCliDespacho ;
      private int Gx_OldLine ;
      private int A49UniCod ;
      private int A164CliDirItem ;
      private decimal AV56TotGeneral ;
      private decimal AV57TotGImporte ;
      private decimal AV58TotGPagos ;
      private decimal AV59TotGSaldo ;
      private decimal AV39PedDCan ;
      private decimal AV40PedDCanDsp ;
      private decimal AV41PedDCanFac ;
      private decimal AV47Precio ;
      private decimal AV15Dscto ;
      private decimal AV48PreTot ;
      private decimal A1558PedDCanDSP ;
      private decimal A1559PedDCanFAC ;
      private decimal A1555PedDDct ;
      private decimal A1556PedDDct2 ;
      private decimal A1551PedDTot ;
      private decimal A1554PedDCan ;
      private decimal A1553PedDPre ;
      private decimal A1552PedDSub ;
      private decimal AV8PedDDct ;
      private decimal AV9PedDDct2 ;
      private decimal AV13Descuento ;
      private decimal AV44PedDPre ;
      private decimal AV45PedDTot ;
      private decimal AV16Dsctot ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV11CliCod ;
      private string AV49ProdCod ;
      private string AV46PedSts ;
      private string AV18Empresa ;
      private string AV17EmpDir ;
      private string AV19EmpRUC ;
      private string AV51Ruta ;
      private string AV24Filtro1 ;
      private string AV25Filtro2 ;
      private string AV26Filtro3 ;
      private string scmdbuf ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A1234MonDsc ;
      private string A1606PedSts ;
      private string A1605PedRef ;
      private string A210PedCod ;
      private string AV37PedCliCod ;
      private string AV12CliDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1997UniAbr ;
      private string AV50Producto ;
      private string A600CliDirDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV22FDesde ;
      private DateTime AV23FHasta ;
      private DateTime AV27Filtro4 ;
      private DateTime AV28Filtro5 ;
      private DateTime A215PedFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private string A1572PedDObs ;
      private string AV43PedDObs ;
      private string AV67Logo_GXI ;
      private string AV32Logo ;
      private string Logo ;
      private IGxSession AV53Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CliCod ;
      private string aP1_ProdCod ;
      private int aP2_MonCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private string aP5_PedSts ;
      private int aP6_TPedCod ;
      private int aP7_VenCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00AF2_A45CliCod ;
      private string[] P00AF2_A161CliDsc ;
      private int[] P00AF3_A180MonCod ;
      private string[] P00AF3_A1234MonDsc ;
      private string[] P00AF4_A1605PedRef ;
      private DateTime[] P00AF4_A215PedFec ;
      private string[] P00AF4_A210PedCod ;
      private short[] P00AF4_A1549PedCotiza ;
      private int[] P00AF4_A211PedVendCod ;
      private int[] P00AF4_A212TPedCod ;
      private string[] P00AF4_A1606PedSts ;
      private int[] P00AF4_A180MonCod ;
      private string[] P00AF4_A45CliCod ;
      private string[] P00AF4_A161CliDsc ;
      private int[] P00AF4_A1545PedCliDespacho ;
      private string[] P00AF4_A1234MonDsc ;
      private int[] P00AF5_A49UniCod ;
      private string[] P00AF5_A210PedCod ;
      private string[] P00AF5_A28ProdCod ;
      private decimal[] P00AF5_A1558PedDCanDSP ;
      private decimal[] P00AF5_A1559PedDCanFAC ;
      private decimal[] P00AF5_A1555PedDDct ;
      private decimal[] P00AF5_A1556PedDDct2 ;
      private decimal[] P00AF5_A1551PedDTot ;
      private string[] P00AF5_A1572PedDObs ;
      private string[] P00AF5_A55ProdDsc ;
      private string[] P00AF5_A1997UniAbr ;
      private decimal[] P00AF5_A1554PedDCan ;
      private decimal[] P00AF5_A1553PedDPre ;
      private short[] P00AF5_A216PedDItem ;
      private int[] P00AF6_A164CliDirItem ;
      private string[] P00AF6_A45CliCod ;
      private string[] P00AF6_A600CliDirDsc ;
   }

   public class rrpedidospendientes__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AF4( IGxContext context ,
                                             string AV11CliCod ,
                                             int AV33MonCod ,
                                             string AV46PedSts ,
                                             int AV63TPedCod ,
                                             int AV64VenCod ,
                                             string A45CliCod ,
                                             int A180MonCod ,
                                             string A1606PedSts ,
                                             int A212TPedCod ,
                                             int A211PedVendCod ,
                                             DateTime A215PedFec ,
                                             DateTime AV22FDesde ,
                                             DateTime AV23FHasta ,
                                             short A1549PedCotiza )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[PedRef], T1.[PedFec], T1.[PedCod], T1.[PedCotiza], T1.[PedVendCod], T1.[TPedCod], T1.[PedSts], T1.[MonCod], T1.[CliCod], T3.[CliDsc], T1.[PedCliDespacho], T2.[MonDsc] FROM (([CLPEDIDOS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[MonCod]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T1.[CliCod])";
         AddWhere(sWhereString, "(T1.[PedFec] >= @AV22FDesde and T1.[PedFec] <= @AV23FHasta)");
         AddWhere(sWhereString, "(T1.[PedCotiza] = 0)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV11CliCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV33MonCod) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV33MonCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! ( StringUtil.StrCmp(AV46PedSts, "TT") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PedSts] = @AV46PedSts)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV63TPedCod) )
         {
            AddWhere(sWhereString, "(T1.[TPedCod] = @AV63TPedCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV64VenCod) )
         {
            AddWhere(sWhereString, "(T1.[PedVendCod] = @AV64VenCod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CliCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00AF5( IGxContext context ,
                                             string AV49ProdCod ,
                                             string A28ProdCod ,
                                             string A210PedCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T1.[PedCod], T1.[ProdCod], T1.[PedDCanDSP], T1.[PedDCanFAC], T1.[PedDDct], T1.[PedDDct2], T1.[PedDTot], T1.[PedDObs], T1.[ProdDsc], T3.[UniAbr], T1.[PedDCan], T1.[PedDPre], T1.[PedDItem] FROM (([CLPEDIDOSDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod])";
         AddWhere(sWhereString, "(T1.[PedCod] = @PedCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV49ProdCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PedCod]";
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
                     return conditional_P00AF4(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] );
               case 3 :
                     return conditional_P00AF5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
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
          Object[] prmP00AF2;
          prmP00AF2 = new Object[] {
          new ParDef("@AV11CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00AF3;
          prmP00AF3 = new Object[] {
          new ParDef("@AV33MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00AF6;
          prmP00AF6 = new Object[] {
          new ParDef("@AV37PedCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV38PedCliDespacho",GXType.Int32,6,0)
          };
          Object[] prmP00AF4;
          prmP00AF4 = new Object[] {
          new ParDef("@AV22FDesde",GXType.Date,8,0) ,
          new ParDef("@AV23FHasta",GXType.Date,8,0) ,
          new ParDef("@AV11CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV33MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV46PedSts",GXType.NChar,1,0) ,
          new ParDef("@AV63TPedCod",GXType.Int32,6,0) ,
          new ParDef("@AV64VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00AF5;
          prmP00AF5 = new Object[] {
          new ParDef("@PedCod",GXType.NChar,10,0) ,
          new ParDef("@AV49ProdCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AF2", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV11CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AF2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AF3", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV33MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AF3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AF4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AF4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AF5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AF5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AF6", "SELECT [CliDirItem], [CliCod], [CliDirDsc] FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @AV37PedCliCod and [CliDirItem] = @AV38PedCliDespacho ORDER BY [CliCod], [CliDirItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AF6,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 1);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((string[]) buf[10])[0] = rslt.getString(11, 5);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
