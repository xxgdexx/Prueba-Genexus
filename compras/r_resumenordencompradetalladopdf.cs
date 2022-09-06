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
namespace GeneXus.Programs.compras {
   public class r_resumenordencompradetalladopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_resumenordencompradetalladopdf.aspx")), "compras.r_resumenordencompradetalladopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_resumenordencompradetalladopdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "PrvCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV51PrvCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV75TprvCod = (int)(NumberUtil.Val( GetPar( "TprvCod"), "."));
                  AV44MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV30FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV32FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV49ProdCod = GetPar( "ProdCod");
                  AV38Lincod = (int)(NumberUtil.Val( GetPar( "Lincod"), "."));
                  AV46Opc = (short)(NumberUtil.Val( GetPar( "Opc"), "."));
                  AV12CosCod = GetPar( "CosCod");
                  AV60TipOrden = GetPar( "TipOrden");
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

      public r_resumenordencompradetalladopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenordencompradetalladopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_PrvCod ,
                           ref int aP1_TprvCod ,
                           ref int aP2_MonCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref string aP5_ProdCod ,
                           ref int aP6_Lincod ,
                           ref short aP7_Opc ,
                           ref string aP8_CosCod ,
                           ref string aP9_TipOrden )
      {
         this.AV51PrvCod = aP0_PrvCod;
         this.AV75TprvCod = aP1_TprvCod;
         this.AV44MonCod = aP2_MonCod;
         this.AV30FDesde = aP3_FDesde;
         this.AV32FHasta = aP4_FHasta;
         this.AV49ProdCod = aP5_ProdCod;
         this.AV38Lincod = aP6_Lincod;
         this.AV46Opc = aP7_Opc;
         this.AV12CosCod = aP8_CosCod;
         this.AV60TipOrden = aP9_TipOrden;
         initialize();
         executePrivate();
         aP0_PrvCod=this.AV51PrvCod;
         aP1_TprvCod=this.AV75TprvCod;
         aP2_MonCod=this.AV44MonCod;
         aP3_FDesde=this.AV30FDesde;
         aP4_FHasta=this.AV32FHasta;
         aP5_ProdCod=this.AV49ProdCod;
         aP6_Lincod=this.AV38Lincod;
         aP7_Opc=this.AV46Opc;
         aP8_CosCod=this.AV12CosCod;
         aP9_TipOrden=this.AV60TipOrden;
      }

      public string executeUdp( ref string aP0_PrvCod ,
                                ref int aP1_TprvCod ,
                                ref int aP2_MonCod ,
                                ref DateTime aP3_FDesde ,
                                ref DateTime aP4_FHasta ,
                                ref string aP5_ProdCod ,
                                ref int aP6_Lincod ,
                                ref short aP7_Opc ,
                                ref string aP8_CosCod )
      {
         execute(ref aP0_PrvCod, ref aP1_TprvCod, ref aP2_MonCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_ProdCod, ref aP6_Lincod, ref aP7_Opc, ref aP8_CosCod, ref aP9_TipOrden);
         return AV60TipOrden ;
      }

      public void executeSubmit( ref string aP0_PrvCod ,
                                 ref int aP1_TprvCod ,
                                 ref int aP2_MonCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref string aP5_ProdCod ,
                                 ref int aP6_Lincod ,
                                 ref short aP7_Opc ,
                                 ref string aP8_CosCod ,
                                 ref string aP9_TipOrden )
      {
         r_resumenordencompradetalladopdf objr_resumenordencompradetalladopdf;
         objr_resumenordencompradetalladopdf = new r_resumenordencompradetalladopdf();
         objr_resumenordencompradetalladopdf.AV51PrvCod = aP0_PrvCod;
         objr_resumenordencompradetalladopdf.AV75TprvCod = aP1_TprvCod;
         objr_resumenordencompradetalladopdf.AV44MonCod = aP2_MonCod;
         objr_resumenordencompradetalladopdf.AV30FDesde = aP3_FDesde;
         objr_resumenordencompradetalladopdf.AV32FHasta = aP4_FHasta;
         objr_resumenordencompradetalladopdf.AV49ProdCod = aP5_ProdCod;
         objr_resumenordencompradetalladopdf.AV38Lincod = aP6_Lincod;
         objr_resumenordencompradetalladopdf.AV46Opc = aP7_Opc;
         objr_resumenordencompradetalladopdf.AV12CosCod = aP8_CosCod;
         objr_resumenordencompradetalladopdf.AV60TipOrden = aP9_TipOrden;
         objr_resumenordencompradetalladopdf.context.SetSubmitInitialConfig(context);
         objr_resumenordencompradetalladopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenordencompradetalladopdf);
         aP0_PrvCod=this.AV51PrvCod;
         aP1_TprvCod=this.AV75TprvCod;
         aP2_MonCod=this.AV44MonCod;
         aP3_FDesde=this.AV30FDesde;
         aP4_FHasta=this.AV32FHasta;
         aP5_ProdCod=this.AV49ProdCod;
         aP6_Lincod=this.AV38Lincod;
         aP7_Opc=this.AV46Opc;
         aP8_CosCod=this.AV12CosCod;
         aP9_TipOrden=this.AV60TipOrden;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenordencompradetalladopdf)stateInfo).executePrivate();
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
            AV26Empresa = AV53Session.Get("Empresa");
            AV25EmpDir = AV53Session.Get("EmpDir");
            AV27EmpRUC = AV53Session.Get("EmpRUC");
            AV52Ruta = AV53Session.Get("RUTA") + "/Logo.jpg";
            AV39Logo = AV52Ruta;
            AV80Logo_GXI = GXDbFile.PathToUrl( AV52Ruta);
            AV45Moneda = "(Todos)";
            AV59TipoOrdenes = ((StringUtil.StrCmp(AV60TipOrden, "O")==0) ? "Compra" : ((StringUtil.StrCmp(AV60TipOrden, "S")==0) ? "Servicio" : "(Todos)"));
            /* Using cursor P007S2 */
            pr_default.execute(0, new Object[] {AV44MonCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P007S2_A180MonCod[0];
               A1234MonDsc = P007S2_A1234MonDsc[0];
               AV45Moneda = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV70TotGCant = 0.0000m;
            AV72TotGPrecio = 0.00m;
            AV73TotGTotal = 0.00m;
            AV40ME = 0.00m;
            AV42MN = 0.00m;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV51PrvCod ,
                                                 AV44MonCod ,
                                                 AV49ProdCod ,
                                                 AV38Lincod ,
                                                 AV12CosCod ,
                                                 A244PrvCod ,
                                                 A290OrdMonCod ,
                                                 A28ProdCod ,
                                                 A52LinCod ,
                                                 A291OrdCosCod ,
                                                 A1462OrdSts ,
                                                 AV32FHasta ,
                                                 A293OrdFec ,
                                                 AV30FDesde } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P007S3 */
            pr_default.execute(1, new Object[] {AV32FHasta, AV30FDesde, AV51PrvCod, AV44MonCod, AV49ProdCod, AV38Lincod, AV12CosCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A292OrdConpCod = P007S3_A292OrdConpCod[0];
               A1462OrdSts = P007S3_A1462OrdSts[0];
               A291OrdCosCod = P007S3_A291OrdCosCod[0];
               n291OrdCosCod = P007S3_n291OrdCosCod[0];
               A52LinCod = P007S3_A52LinCod[0];
               A28ProdCod = P007S3_A28ProdCod[0];
               A290OrdMonCod = P007S3_A290OrdMonCod[0];
               A293OrdFec = P007S3_A293OrdFec[0];
               A244PrvCod = P007S3_A244PrvCod[0];
               A289OrdCod = P007S3_A289OrdCod[0];
               A1427OrdConpDsc = P007S3_A1427OrdConpDsc[0];
               A1233MonAbr = P007S3_A1233MonAbr[0];
               n1233MonAbr = P007S3_n1233MonAbr[0];
               A1444OrdDTot = P007S3_A1444OrdDTot[0];
               A55ProdDsc = P007S3_A55ProdDsc[0];
               A1431OrdDCan = P007S3_A1431OrdDCan[0];
               A1438OrdDPre = P007S3_A1438OrdDPre[0];
               A247PrvDsc = P007S3_A247PrvDsc[0];
               A295OrdDItem = P007S3_A295OrdDItem[0];
               A52LinCod = P007S3_A52LinCod[0];
               A55ProdDsc = P007S3_A55ProdDsc[0];
               A292OrdConpCod = P007S3_A292OrdConpCod[0];
               A1462OrdSts = P007S3_A1462OrdSts[0];
               A291OrdCosCod = P007S3_A291OrdCosCod[0];
               n291OrdCosCod = P007S3_n291OrdCosCod[0];
               A290OrdMonCod = P007S3_A290OrdMonCod[0];
               A293OrdFec = P007S3_A293OrdFec[0];
               A244PrvCod = P007S3_A244PrvCod[0];
               A1427OrdConpDsc = P007S3_A1427OrdConpDsc[0];
               A1233MonAbr = P007S3_A1233MonAbr[0];
               n1233MonAbr = P007S3_n1233MonAbr[0];
               A247PrvDsc = P007S3_A247PrvDsc[0];
               AV47OrdFec = A293OrdFec;
               AV21DocMonCod = A290OrdMonCod;
               AV11Codigo = A28ProdCod;
               H7S0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A247PrvDsc, "")), 190, Gx_line+2, 418, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A293OrdFec, "99/99/99"), 67, Gx_line+1, 111, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1438OrdDPre, "ZZZZZ,ZZZ,ZZ9.999999")), 791, Gx_line+2, 896, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1431OrdDCan, "ZZZZ,ZZZ,ZZ9.9999")), 740, Gx_line+2, 830, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A244PrvCod, "@!")), 113, Gx_line+1, 189, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Codigo, "")), 453, Gx_line+1, 525, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 528, Gx_line+1, 757, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1444OrdDTot, "ZZZ,ZZZ,ZZ9.99")), 876, Gx_line+2, 971, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1233MonAbr, "")), 421, Gx_line+2, 451, Gx_line+13, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1427OrdConpDsc, "")), 968, Gx_line+2, 1104, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A289OrdCod, "")), 6, Gx_line+2, 49, Gx_line+15, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV70TotGCant = (decimal)(AV70TotGCant+A1431OrdDCan);
               AV72TotGPrecio = (decimal)(AV72TotGPrecio+A1438OrdDPre);
               AV73TotGTotal = (decimal)(AV73TotGTotal+A1444OrdDTot);
               AV42MN = (decimal)(AV42MN+(((A290OrdMonCod==1) ? A1444OrdDTot : (decimal)(0))));
               AV40ME = (decimal)(AV40ME+(((A290OrdMonCod==2) ? A1444OrdDTot : (decimal)(0))));
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Using cursor P007S4 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               A180MonCod = P007S4_A180MonCod[0];
               A1234MonDsc = P007S4_A1234MonDsc[0];
               AV43MNDsc = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P007S5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               A180MonCod = P007S5_A180MonCod[0];
               A1234MonDsc = P007S5_A1234MonDsc[0];
               AV41MEDsc = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            H7S0( false, 77) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 646, Gx_line+11, 726, Gx_line+25, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42MN, "ZZZZZZ,ZZZ,ZZ9.99")), 638, Gx_line+30, 745, Gx_line+45, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(418, Gx_line+8, 762, Gx_line+63, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(419, Gx_line+26, 762, Gx_line+26, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(617, Gx_line+8, 617, Gx_line+62, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40ME, "ZZZZZZ,ZZZ,ZZ9.99")), 638, Gx_line+47, 745, Gx_line+62, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43MNDsc, "")), 422, Gx_line+30, 614, Gx_line+44, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41MEDsc, "")), 422, Gx_line+47, 615, Gx_line+61, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Moneda", 477, Gx_line+11, 525, Gx_line+25, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+77);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7S0( true, 0) ;
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

      protected void H7S0( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Reporte de Orden de Compra Detallado", 374, Gx_line+38, 710, Gx_line+58, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+130, 1106, Gx_line+156, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1028, Gx_line+21, 1075, Gx_line+36, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1014, Gx_line+40, 1074, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1036, Gx_line+59, 1075, Gx_line+74, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 73, Gx_line+138, 104, Gx_line+151, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Codigo", 466, Gx_line+138, 502, Gx_line+151, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio", 850, Gx_line+138, 884, Gx_line+151, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde", 392, Gx_line+84, 432, Gx_line+99, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV30FDesde, "99/99/99"), 452, Gx_line+82, 526, Gx_line+100, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 552, Gx_line+84, 589, Gx_line+99, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV32FHasta, "99/99/99"), 603, Gx_line+81, 677, Gx_line+102, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("R.U.C", 139, Gx_line+138, 168, Gx_line+151, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 284, Gx_line+138, 340, Gx_line+151, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 628, Gx_line+138, 676, Gx_line+151, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 770, Gx_line+138, 817, Gx_line+151, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV39Logo)) ? AV80Logo_GXI : AV39Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 16, Gx_line+11, 174, Gx_line+89) ;
               getPrinter().GxDrawLine(114, Gx_line+131, 114, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(185, Gx_line+131, 185, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(419, Gx_line+131, 419, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(525, Gx_line+130, 525, Gx_line+155, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(757, Gx_line+131, 757, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(828, Gx_line+131, 828, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(896, Gx_line+131, 896, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Empresa, "")), 16, Gx_line+95, 384, Gx_line+113, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27EmpRUC, "")), 16, Gx_line+113, 384, Gx_line+131, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Moneda", 392, Gx_line+107, 444, Gx_line+122, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45Moneda, "")), 452, Gx_line+102, 637, Gx_line+126, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total", 918, Gx_line+138, 946, Gx_line+151, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(451, Gx_line+131, 451, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Mon", 424, Gx_line+138, 447, Gx_line+151, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(966, Gx_line+131, 966, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Condición Pago", 995, Gx_line+138, 1075, Gx_line+151, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(60, Gx_line+131, 60, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Orden", 7, Gx_line+138, 56, Gx_line+151, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59TipoOrdenes, "")), 445, Gx_line+59, 630, Gx_line+83, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+156);
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
         AV26Empresa = "";
         AV53Session = context.GetSession();
         AV25EmpDir = "";
         AV27EmpRUC = "";
         AV52Ruta = "";
         AV39Logo = "";
         AV80Logo_GXI = "";
         AV45Moneda = "";
         AV59TipoOrdenes = "";
         scmdbuf = "";
         P007S2_A180MonCod = new int[1] ;
         P007S2_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         A244PrvCod = "";
         A28ProdCod = "";
         A291OrdCosCod = "";
         A1462OrdSts = "";
         A293OrdFec = DateTime.MinValue;
         P007S3_A292OrdConpCod = new int[1] ;
         P007S3_A1462OrdSts = new string[] {""} ;
         P007S3_A291OrdCosCod = new string[] {""} ;
         P007S3_n291OrdCosCod = new bool[] {false} ;
         P007S3_A52LinCod = new int[1] ;
         P007S3_A28ProdCod = new string[] {""} ;
         P007S3_A290OrdMonCod = new int[1] ;
         P007S3_A293OrdFec = new DateTime[] {DateTime.MinValue} ;
         P007S3_A244PrvCod = new string[] {""} ;
         P007S3_A289OrdCod = new string[] {""} ;
         P007S3_A1427OrdConpDsc = new string[] {""} ;
         P007S3_A1233MonAbr = new string[] {""} ;
         P007S3_n1233MonAbr = new bool[] {false} ;
         P007S3_A1444OrdDTot = new decimal[1] ;
         P007S3_A55ProdDsc = new string[] {""} ;
         P007S3_A1431OrdDCan = new decimal[1] ;
         P007S3_A1438OrdDPre = new decimal[1] ;
         P007S3_A247PrvDsc = new string[] {""} ;
         P007S3_A295OrdDItem = new int[1] ;
         A289OrdCod = "";
         A1427OrdConpDsc = "";
         A1233MonAbr = "";
         A55ProdDsc = "";
         A247PrvDsc = "";
         AV47OrdFec = DateTime.MinValue;
         AV11Codigo = "";
         P007S4_A180MonCod = new int[1] ;
         P007S4_A1234MonDsc = new string[] {""} ;
         AV43MNDsc = "";
         P007S5_A180MonCod = new int[1] ;
         P007S5_A1234MonDsc = new string[] {""} ;
         AV41MEDsc = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV39Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_resumenordencompradetalladopdf__default(),
            new Object[][] {
                new Object[] {
               P007S2_A180MonCod, P007S2_A1234MonDsc
               }
               , new Object[] {
               P007S3_A292OrdConpCod, P007S3_A1462OrdSts, P007S3_A291OrdCosCod, P007S3_n291OrdCosCod, P007S3_A52LinCod, P007S3_A28ProdCod, P007S3_A290OrdMonCod, P007S3_A293OrdFec, P007S3_A244PrvCod, P007S3_A289OrdCod,
               P007S3_A1427OrdConpDsc, P007S3_A1233MonAbr, P007S3_n1233MonAbr, P007S3_A1444OrdDTot, P007S3_A55ProdDsc, P007S3_A1431OrdDCan, P007S3_A1438OrdDPre, P007S3_A247PrvDsc, P007S3_A295OrdDItem
               }
               , new Object[] {
               P007S4_A180MonCod, P007S4_A1234MonDsc
               }
               , new Object[] {
               P007S5_A180MonCod, P007S5_A1234MonDsc
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
      private short AV46Opc ;
      private int AV75TprvCod ;
      private int AV44MonCod ;
      private int AV38Lincod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int A290OrdMonCod ;
      private int A52LinCod ;
      private int A292OrdConpCod ;
      private int A295OrdDItem ;
      private int AV21DocMonCod ;
      private int Gx_OldLine ;
      private decimal AV70TotGCant ;
      private decimal AV72TotGPrecio ;
      private decimal AV73TotGTotal ;
      private decimal AV40ME ;
      private decimal AV42MN ;
      private decimal A1444OrdDTot ;
      private decimal A1431OrdDCan ;
      private decimal A1438OrdDPre ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV51PrvCod ;
      private string AV49ProdCod ;
      private string AV12CosCod ;
      private string AV26Empresa ;
      private string AV25EmpDir ;
      private string AV27EmpRUC ;
      private string AV52Ruta ;
      private string AV45Moneda ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string A244PrvCod ;
      private string A28ProdCod ;
      private string A291OrdCosCod ;
      private string A1462OrdSts ;
      private string A289OrdCod ;
      private string A1427OrdConpDsc ;
      private string A1233MonAbr ;
      private string A55ProdDsc ;
      private string A247PrvDsc ;
      private string AV11Codigo ;
      private string AV43MNDsc ;
      private string AV41MEDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV30FDesde ;
      private DateTime AV32FHasta ;
      private DateTime A293OrdFec ;
      private DateTime AV47OrdFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n291OrdCosCod ;
      private bool n1233MonAbr ;
      private string AV60TipOrden ;
      private string AV80Logo_GXI ;
      private string AV59TipoOrdenes ;
      private string AV39Logo ;
      private string Logo ;
      private IGxSession AV53Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_PrvCod ;
      private int aP1_TprvCod ;
      private int aP2_MonCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private string aP5_ProdCod ;
      private int aP6_Lincod ;
      private short aP7_Opc ;
      private string aP8_CosCod ;
      private string aP9_TipOrden ;
      private IDataStoreProvider pr_default ;
      private int[] P007S2_A180MonCod ;
      private string[] P007S2_A1234MonDsc ;
      private int[] P007S3_A292OrdConpCod ;
      private string[] P007S3_A1462OrdSts ;
      private string[] P007S3_A291OrdCosCod ;
      private bool[] P007S3_n291OrdCosCod ;
      private int[] P007S3_A52LinCod ;
      private string[] P007S3_A28ProdCod ;
      private int[] P007S3_A290OrdMonCod ;
      private DateTime[] P007S3_A293OrdFec ;
      private string[] P007S3_A244PrvCod ;
      private string[] P007S3_A289OrdCod ;
      private string[] P007S3_A1427OrdConpDsc ;
      private string[] P007S3_A1233MonAbr ;
      private bool[] P007S3_n1233MonAbr ;
      private decimal[] P007S3_A1444OrdDTot ;
      private string[] P007S3_A55ProdDsc ;
      private decimal[] P007S3_A1431OrdDCan ;
      private decimal[] P007S3_A1438OrdDPre ;
      private string[] P007S3_A247PrvDsc ;
      private int[] P007S3_A295OrdDItem ;
      private int[] P007S4_A180MonCod ;
      private string[] P007S4_A1234MonDsc ;
      private int[] P007S5_A180MonCod ;
      private string[] P007S5_A1234MonDsc ;
   }

   public class r_resumenordencompradetalladopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007S3( IGxContext context ,
                                             string AV51PrvCod ,
                                             int AV44MonCod ,
                                             string AV49ProdCod ,
                                             int AV38Lincod ,
                                             string AV12CosCod ,
                                             string A244PrvCod ,
                                             int A290OrdMonCod ,
                                             string A28ProdCod ,
                                             int A52LinCod ,
                                             string A291OrdCosCod ,
                                             string A1462OrdSts ,
                                             DateTime AV32FHasta ,
                                             DateTime A293OrdFec ,
                                             DateTime AV30FDesde )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T3.[OrdConpCod] AS OrdConpCod, T3.[OrdSts], T3.[OrdCosCod], T2.[LinCod], T1.[ProdCod], T3.[OrdMonCod] AS OrdMonCod, T3.[OrdFec], T3.[PrvCod], T1.[OrdCod], T4.[ConpDsc] AS OrdConpDsc, T5.[MonAbr], T1.[OrdDTot], T2.[ProdDsc], T1.[OrdDCan], T1.[OrdDPre], T6.[PrvDsc], T1.[OrdDItem] FROM ((((([CPORDENDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CPORDEN] T3 ON T3.[OrdCod] = T1.[OrdCod]) INNER JOIN [CCONDICIONPAGO] T4 ON T4.[Conpcod] = T3.[OrdConpCod]) INNER JOIN [CMONEDAS] T5 ON T5.[MonCod] = T3.[OrdMonCod]) INNER JOIN [CPPROVEEDORES] T6 ON T6.[PrvCod] = T3.[PrvCod])";
         AddWhere(sWhereString, "(T3.[OrdFec] <= @AV32FHasta)");
         AddWhere(sWhereString, "(Not T3.[OrdSts] = 'A')");
         AddWhere(sWhereString, "(T3.[OrdFec] >= @AV30FDesde)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51PrvCod)) )
         {
            AddWhere(sWhereString, "(T3.[PrvCod] = @AV51PrvCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV44MonCod) )
         {
            AddWhere(sWhereString, "(T3.[OrdMonCod] = @AV44MonCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV49ProdCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV38Lincod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV38Lincod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12CosCod)) )
         {
            AddWhere(sWhereString, "(T3.[OrdCosCod] = @AV12CosCod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[OrdFec] DESC";
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
                     return conditional_P007S3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] );
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
          Object[] prmP007S2;
          prmP007S2 = new Object[] {
          new ParDef("@AV44MonCod",GXType.Int32,6,0)
          };
          Object[] prmP007S4;
          prmP007S4 = new Object[] {
          };
          Object[] prmP007S5;
          prmP007S5 = new Object[] {
          };
          Object[] prmP007S3;
          prmP007S3 = new Object[] {
          new ParDef("@AV32FHasta",GXType.Date,8,0) ,
          new ParDef("@AV30FDesde",GXType.Date,8,0) ,
          new ParDef("@AV51PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV44MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV49ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV38Lincod",GXType.Int32,6,0) ,
          new ParDef("@AV12CosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007S2", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV44MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007S2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007S3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007S4", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = 1 ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007S4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007S5", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = 2 ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007S5,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 5);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 100);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
                ((string[]) buf[17])[0] = rslt.getString(16, 100);
                ((int[]) buf[18])[0] = rslt.getInt(17);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
