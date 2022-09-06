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
   public class rrordencompracomparativoprecio : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrordencompracomparativoprecio.aspx")), "rrordencompracomparativoprecio.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrordencompracomparativoprecio.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "cPrvCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV13cPrvCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10cLinCod = (int)(NumberUtil.Val( GetPar( "cLinCod"), "."));
                  AV12cProdCod = GetPar( "cProdCod");
                  AV20FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV21FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public rrordencompracomparativoprecio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrordencompracomparativoprecio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_cPrvCod ,
                           ref int aP1_cLinCod ,
                           ref string aP2_cProdCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta )
      {
         this.AV13cPrvCod = aP0_cPrvCod;
         this.AV10cLinCod = aP1_cLinCod;
         this.AV12cProdCod = aP2_cProdCod;
         this.AV20FDesde = aP3_FDesde;
         this.AV21FHasta = aP4_FHasta;
         initialize();
         executePrivate();
         aP0_cPrvCod=this.AV13cPrvCod;
         aP1_cLinCod=this.AV10cLinCod;
         aP2_cProdCod=this.AV12cProdCod;
         aP3_FDesde=this.AV20FDesde;
         aP4_FHasta=this.AV21FHasta;
      }

      public DateTime executeUdp( ref string aP0_cPrvCod ,
                                  ref int aP1_cLinCod ,
                                  ref string aP2_cProdCod ,
                                  ref DateTime aP3_FDesde )
      {
         execute(ref aP0_cPrvCod, ref aP1_cLinCod, ref aP2_cProdCod, ref aP3_FDesde, ref aP4_FHasta);
         return AV21FHasta ;
      }

      public void executeSubmit( ref string aP0_cPrvCod ,
                                 ref int aP1_cLinCod ,
                                 ref string aP2_cProdCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta )
      {
         rrordencompracomparativoprecio objrrordencompracomparativoprecio;
         objrrordencompracomparativoprecio = new rrordencompracomparativoprecio();
         objrrordencompracomparativoprecio.AV13cPrvCod = aP0_cPrvCod;
         objrrordencompracomparativoprecio.AV10cLinCod = aP1_cLinCod;
         objrrordencompracomparativoprecio.AV12cProdCod = aP2_cProdCod;
         objrrordencompracomparativoprecio.AV20FDesde = aP3_FDesde;
         objrrordencompracomparativoprecio.AV21FHasta = aP4_FHasta;
         objrrordencompracomparativoprecio.context.SetSubmitInitialConfig(context);
         objrrordencompracomparativoprecio.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrordencompracomparativoprecio);
         aP0_cPrvCod=this.AV13cPrvCod;
         aP1_cLinCod=this.AV10cLinCod;
         aP2_cProdCod=this.AV12cProdCod;
         aP3_FDesde=this.AV20FDesde;
         aP4_FHasta=this.AV21FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrordencompracomparativoprecio)stateInfo).executePrivate();
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
            AV16Empresa = AV47Session.Get("Empresa");
            AV15EmpDir = AV47Session.Get("EmpDir");
            AV17EmpRUC = AV47Session.Get("EmpRUC");
            AV45Ruta = AV47Session.Get("RUTA") + "/Logo.jpg";
            AV31Logo = AV45Ruta;
            AV63Logo_GXI = GXDbFile.PathToUrl( AV45Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV24Filtro3 = "Del : " + context.localUtil.DToC( AV20FDesde, 2, "/") + " Al : " + context.localUtil.DToC( AV21FHasta, 2, "/");
            /* Using cursor P00A62 */
            pr_default.execute(0, new Object[] {AV13cPrvCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A244PrvCod = P00A62_A244PrvCod[0];
               A247PrvDsc = P00A62_A247PrvDsc[0];
               AV22Filtro1 = A247PrvDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00A63 */
            pr_default.execute(1, new Object[] {AV12cProdCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = P00A63_A28ProdCod[0];
               A55ProdDsc = P00A63_A55ProdDsc[0];
               AV23Filtro2 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV29Item = 0;
            AV50TipoOrdenes = ((StringUtil.StrCmp(AV51TipOrden, "O")==0) ? "Compra" : ((StringUtil.StrCmp(AV51TipOrden, "S")==0) ? "Servicio" : "(Todos)"));
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV13cPrvCod ,
                                                 AV12cProdCod ,
                                                 AV10cLinCod ,
                                                 A244PrvCod ,
                                                 A28ProdCod ,
                                                 A52LinCod ,
                                                 A1462OrdSts ,
                                                 AV20FDesde ,
                                                 A293OrdFec ,
                                                 AV21FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00A64 */
            pr_default.execute(2, new Object[] {AV20FDesde, AV21FHasta, AV13cPrvCod, AV12cProdCod, AV10cLinCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A49UniCod = P00A64_A49UniCod[0];
               A1462OrdSts = P00A64_A1462OrdSts[0];
               A293OrdFec = P00A64_A293OrdFec[0];
               A52LinCod = P00A64_A52LinCod[0];
               A28ProdCod = P00A64_A28ProdCod[0];
               A244PrvCod = P00A64_A244PrvCod[0];
               A290OrdMonCod = P00A64_A290OrdMonCod[0];
               A1431OrdDCan = P00A64_A1431OrdDCan[0];
               A1438OrdDPre = P00A64_A1438OrdDPre[0];
               A247PrvDsc = P00A64_A247PrvDsc[0];
               A1997UniAbr = P00A64_A1997UniAbr[0];
               A55ProdDsc = P00A64_A55ProdDsc[0];
               A289OrdCod = P00A64_A289OrdCod[0];
               A295OrdDItem = P00A64_A295OrdDItem[0];
               A49UniCod = P00A64_A49UniCod[0];
               A52LinCod = P00A64_A52LinCod[0];
               A55ProdDsc = P00A64_A55ProdDsc[0];
               A1997UniAbr = P00A64_A1997UniAbr[0];
               A1462OrdSts = P00A64_A1462OrdSts[0];
               A293OrdFec = P00A64_A293OrdFec[0];
               A244PrvCod = P00A64_A244PrvCod[0];
               A290OrdMonCod = P00A64_A290OrdMonCod[0];
               A247PrvDsc = P00A64_A247PrvDsc[0];
               AV34OrdCod = A289OrdCod;
               AV42PrvCod = A244PrvCod;
               AV41ProdCod = A28ProdCod;
               AV32MonCod = A290OrdMonCod;
               AV60OrdDCan = A1431OrdDCan;
               AV35OrdDPre = A1438OrdDPre;
               AV40Precio = 0.00m;
               AV59Varia = 0.00m;
               /* Execute user subroutine: 'VARIACIONPRECIO' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               AV59Varia = (!(Convert.ToDecimal(0)==AV35OrdDPre) ? NumberUtil.Round( AV40Precio/ (decimal)(AV35OrdDPre)*100, 2)-100 : (decimal)(0));
               if ( ! ( AV35OrdDPre == AV40Precio ) && ! (Convert.ToDecimal(0)==AV40Precio) )
               {
                  HA60( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A289OrdCod, "")), 5, Gx_line+1, 79, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A293OrdFec, "99/99/99"), 74, Gx_line+1, 133, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 404, Gx_line+1, 487, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 491, Gx_line+1, 766, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60OrdDCan, "ZZZZZZ,ZZZ,ZZ9.99")), 768, Gx_line+1, 865, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 869, Gx_line+1, 896, Gx_line+16, 1, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A247PrvDsc, "")), 132, Gx_line+1, 401, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1438OrdDPre, "ZZZZZ,ZZZ,ZZ9.999999")), 882, Gx_line+1, 979, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40Precio, "ZZZZZZZZZZZZ9.9999")), 965, Gx_line+1, 1062, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59Varia, "ZZ9.99")), 1085, Gx_line+1, 1123, Gx_line+16, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  AV29Item = (int)(AV29Item+1);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            HA60( false, 28) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Lineas Ordenes con Diferencia", 514, Gx_line+6, 724, Gx_line+20, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV29Item), "ZZZZ9")), 729, Gx_line+6, 761, Gx_line+21, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+28);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HA60( true, 0) ;
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
         /* 'VARIACIONPRECIO' Routine */
         returnInSub = false;
         /* Using cursor P00A65 */
         pr_default.execute(3, new Object[] {AV41ProdCod, AV42PrvCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A244PrvCod = P00A65_A244PrvCod[0];
            A284CPLisProdCod = P00A65_A284CPLisProdCod[0];
            A829CPLisPrvMN = P00A65_A829CPLisPrvMN[0];
            A828CPLisPrvME = P00A65_A828CPLisPrvME[0];
            A285CPLisPrvItem = P00A65_A285CPLisPrvItem[0];
            if ( AV32MonCod == 1 )
            {
               AV40Precio = A829CPLisPrvMN;
            }
            else
            {
               AV40Precio = A828CPLisPrvME;
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void HA60( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 1014, Gx_line+40, 1046, Gx_line+54, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 1014, Gx_line+57, 1058, Gx_line+71, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 1014, Gx_line+22, 1053, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1081, Gx_line+57, 1120, Gx_line+72, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1058, Gx_line+40, 1118, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1073, Gx_line+22, 1120, Gx_line+37, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("O.Compra", 10, Gx_line+146, 68, Gx_line+160, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 81, Gx_line+146, 116, Gx_line+160, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 571, Gx_line+146, 625, Gx_line+160, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+140, 1138, Gx_line+165, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Reporte Comparativo  de Costos Vs Lista Proveedor", 369, Gx_line+40, 809, Gx_line+60, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Proveedor", 230, Gx_line+146, 292, Gx_line+160, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Codigo", 420, Gx_line+146, 461, Gx_line+160, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio OC", 919, Gx_line+146, 975, Gx_line+160, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio Lista", 997, Gx_line+146, 1066, Gx_line+160, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 343, Gx_line+94, 405, Gx_line+108, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 343, Gx_line+115, 397, Gx_line+129, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Periodo", 343, Gx_line+73, 389, Gx_line+87, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 409, Gx_line+89, 752, Gx_line+113, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro2, "")), 409, Gx_line+110, 752, Gx_line+134, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro3, "")), 409, Gx_line+68, 752, Gx_line+92, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("UM", 871, Gx_line+146, 891, Gx_line+160, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 810, Gx_line+146, 863, Gx_line+160, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV31Logo)) ? AV63Logo_GXI : AV31Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 11, Gx_line+2, 166, Gx_line+78) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Empresa, "")), 11, Gx_line+73, 240, Gx_line+91, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EmpRUC, "")), 11, Gx_line+91, 185, Gx_line+109, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("% Variac.", 1071, Gx_line+146, 1128, Gx_line+160, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+165);
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
         AV16Empresa = "";
         AV47Session = context.GetSession();
         AV15EmpDir = "";
         AV17EmpRUC = "";
         AV45Ruta = "";
         AV31Logo = "";
         AV63Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         scmdbuf = "";
         P00A62_A244PrvCod = new string[] {""} ;
         P00A62_A247PrvDsc = new string[] {""} ;
         A244PrvCod = "";
         A247PrvDsc = "";
         P00A63_A28ProdCod = new string[] {""} ;
         P00A63_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         AV50TipoOrdenes = "";
         AV51TipOrden = "";
         A1462OrdSts = "";
         A293OrdFec = DateTime.MinValue;
         P00A64_A49UniCod = new int[1] ;
         P00A64_A1462OrdSts = new string[] {""} ;
         P00A64_A293OrdFec = new DateTime[] {DateTime.MinValue} ;
         P00A64_A52LinCod = new int[1] ;
         P00A64_A28ProdCod = new string[] {""} ;
         P00A64_A244PrvCod = new string[] {""} ;
         P00A64_A290OrdMonCod = new int[1] ;
         P00A64_A1431OrdDCan = new decimal[1] ;
         P00A64_A1438OrdDPre = new decimal[1] ;
         P00A64_A247PrvDsc = new string[] {""} ;
         P00A64_A1997UniAbr = new string[] {""} ;
         P00A64_A55ProdDsc = new string[] {""} ;
         P00A64_A289OrdCod = new string[] {""} ;
         P00A64_A295OrdDItem = new int[1] ;
         A1997UniAbr = "";
         A289OrdCod = "";
         AV34OrdCod = "";
         AV42PrvCod = "";
         AV41ProdCod = "";
         P00A65_A244PrvCod = new string[] {""} ;
         P00A65_A284CPLisProdCod = new string[] {""} ;
         P00A65_A829CPLisPrvMN = new decimal[1] ;
         P00A65_A828CPLisPrvME = new decimal[1] ;
         P00A65_A285CPLisPrvItem = new short[1] ;
         A284CPLisProdCod = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV31Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrordencompracomparativoprecio__default(),
            new Object[][] {
                new Object[] {
               P00A62_A244PrvCod, P00A62_A247PrvDsc
               }
               , new Object[] {
               P00A63_A28ProdCod, P00A63_A55ProdDsc
               }
               , new Object[] {
               P00A64_A49UniCod, P00A64_A1462OrdSts, P00A64_A293OrdFec, P00A64_A52LinCod, P00A64_A28ProdCod, P00A64_A244PrvCod, P00A64_A290OrdMonCod, P00A64_A1431OrdDCan, P00A64_A1438OrdDPre, P00A64_A247PrvDsc,
               P00A64_A1997UniAbr, P00A64_A55ProdDsc, P00A64_A289OrdCod, P00A64_A295OrdDItem
               }
               , new Object[] {
               P00A65_A244PrvCod, P00A65_A284CPLisProdCod, P00A65_A829CPLisPrvMN, P00A65_A828CPLisPrvME, P00A65_A285CPLisPrvItem
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
      private short A285CPLisPrvItem ;
      private int AV10cLinCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV29Item ;
      private int A52LinCod ;
      private int A49UniCod ;
      private int A290OrdMonCod ;
      private int A295OrdDItem ;
      private int AV32MonCod ;
      private int Gx_OldLine ;
      private decimal A1431OrdDCan ;
      private decimal A1438OrdDPre ;
      private decimal AV60OrdDCan ;
      private decimal AV35OrdDPre ;
      private decimal AV40Precio ;
      private decimal AV59Varia ;
      private decimal A829CPLisPrvMN ;
      private decimal A828CPLisPrvME ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV13cPrvCod ;
      private string AV12cProdCod ;
      private string AV16Empresa ;
      private string AV15EmpDir ;
      private string AV17EmpRUC ;
      private string AV45Ruta ;
      private string AV22Filtro1 ;
      private string AV23Filtro2 ;
      private string AV24Filtro3 ;
      private string scmdbuf ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1462OrdSts ;
      private string A1997UniAbr ;
      private string A289OrdCod ;
      private string AV34OrdCod ;
      private string AV42PrvCod ;
      private string AV41ProdCod ;
      private string A284CPLisProdCod ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV20FDesde ;
      private DateTime AV21FHasta ;
      private DateTime A293OrdFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private string AV63Logo_GXI ;
      private string AV50TipoOrdenes ;
      private string AV51TipOrden ;
      private string AV31Logo ;
      private string Logo ;
      private IGxSession AV47Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_cPrvCod ;
      private int aP1_cLinCod ;
      private string aP2_cProdCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P00A62_A244PrvCod ;
      private string[] P00A62_A247PrvDsc ;
      private string[] P00A63_A28ProdCod ;
      private string[] P00A63_A55ProdDsc ;
      private int[] P00A64_A49UniCod ;
      private string[] P00A64_A1462OrdSts ;
      private DateTime[] P00A64_A293OrdFec ;
      private int[] P00A64_A52LinCod ;
      private string[] P00A64_A28ProdCod ;
      private string[] P00A64_A244PrvCod ;
      private int[] P00A64_A290OrdMonCod ;
      private decimal[] P00A64_A1431OrdDCan ;
      private decimal[] P00A64_A1438OrdDPre ;
      private string[] P00A64_A247PrvDsc ;
      private string[] P00A64_A1997UniAbr ;
      private string[] P00A64_A55ProdDsc ;
      private string[] P00A64_A289OrdCod ;
      private int[] P00A64_A295OrdDItem ;
      private string[] P00A65_A244PrvCod ;
      private string[] P00A65_A284CPLisProdCod ;
      private decimal[] P00A65_A829CPLisPrvMN ;
      private decimal[] P00A65_A828CPLisPrvME ;
      private short[] P00A65_A285CPLisPrvItem ;
   }

   public class rrordencompracomparativoprecio__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A64( IGxContext context ,
                                             string AV13cPrvCod ,
                                             string AV12cProdCod ,
                                             int AV10cLinCod ,
                                             string A244PrvCod ,
                                             string A28ProdCod ,
                                             int A52LinCod ,
                                             string A1462OrdSts ,
                                             DateTime AV20FDesde ,
                                             DateTime A293OrdFec ,
                                             DateTime AV21FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T4.[OrdSts], T4.[OrdFec], T2.[LinCod], T1.[ProdCod], T4.[PrvCod], T4.[OrdMonCod], T1.[OrdDCan], T1.[OrdDPre], T5.[PrvDsc], T3.[UniAbr], T2.[ProdDsc], T1.[OrdCod], T1.[OrdDItem] FROM (((([CPORDENDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CPORDEN] T4 ON T4.[OrdCod] = T1.[OrdCod]) INNER JOIN [CPPROVEEDORES] T5 ON T5.[PrvCod] = T4.[PrvCod])";
         AddWhere(sWhereString, "(T4.[OrdFec] >= @AV20FDesde)");
         AddWhere(sWhereString, "(T4.[OrdSts] <> 'A' and T4.[OrdSts] <> 'P')");
         AddWhere(sWhereString, "(T4.[OrdFec] <= @AV21FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13cPrvCod)) )
         {
            AddWhere(sWhereString, "(T4.[PrvCod] = @AV13cPrvCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV12cProdCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cLinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV10cLinCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.[OrdFec], T1.[OrdCod], T1.[ProdCod]";
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
               case 2 :
                     return conditional_P00A64(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] );
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
          Object[] prmP00A62;
          prmP00A62 = new Object[] {
          new ParDef("@AV13cPrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00A63;
          prmP00A63 = new Object[] {
          new ParDef("@AV12cProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00A65;
          prmP00A65 = new Object[] {
          new ParDef("@AV41ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV42PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00A64;
          prmP00A64 = new Object[] {
          new ParDef("@AV20FDesde",GXType.Date,8,0) ,
          new ParDef("@AV21FHasta",GXType.Date,8,0) ,
          new ParDef("@AV13cPrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV12cProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV10cLinCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A62", "SELECT [PrvCod], [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @AV13cPrvCod ORDER BY [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A62,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A63", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV12cProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A63,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A64", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A64,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00A65", "SELECT [PrvCod], [CPLisProdCod], [CPLisPrvMN], [CPLisPrvME], [CPLisPrvItem] FROM [CPLISTAPRECIOSDET] WHERE ([CPLisProdCod] = @AV41ProdCod) AND ([PrvCod] = @AV42PrvCod) ORDER BY [CPLisProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A65,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((string[]) buf[10])[0] = rslt.getString(11, 5);
                ((string[]) buf[11])[0] = rslt.getString(12, 100);
                ((string[]) buf[12])[0] = rslt.getString(13, 10);
                ((int[]) buf[13])[0] = rslt.getInt(14);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
