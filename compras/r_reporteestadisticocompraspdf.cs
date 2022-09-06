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
   public class r_reporteestadisticocompraspdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_reporteestadisticocompraspdf.aspx")), "compras.r_reporteestadisticocompraspdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_reporteestadisticocompraspdf.aspx")))) ;
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
               AV30LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV54FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV28ProdCod = GetPar( "ProdCod");
                  AV14FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV15FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public r_reporteestadisticocompraspdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reporteestadisticocompraspdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_FamCod ,
                           ref string aP2_ProdCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta )
      {
         this.AV30LinCod = aP0_LinCod;
         this.AV54FamCod = aP1_FamCod;
         this.AV28ProdCod = aP2_ProdCod;
         this.AV14FDesde = aP3_FDesde;
         this.AV15FHasta = aP4_FHasta;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV30LinCod;
         aP1_FamCod=this.AV54FamCod;
         aP2_ProdCod=this.AV28ProdCod;
         aP3_FDesde=this.AV14FDesde;
         aP4_FHasta=this.AV15FHasta;
      }

      public DateTime executeUdp( ref int aP0_LinCod ,
                                  ref int aP1_FamCod ,
                                  ref string aP2_ProdCod ,
                                  ref DateTime aP3_FDesde )
      {
         execute(ref aP0_LinCod, ref aP1_FamCod, ref aP2_ProdCod, ref aP3_FDesde, ref aP4_FHasta);
         return AV15FHasta ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_FamCod ,
                                 ref string aP2_ProdCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta )
      {
         r_reporteestadisticocompraspdf objr_reporteestadisticocompraspdf;
         objr_reporteestadisticocompraspdf = new r_reporteestadisticocompraspdf();
         objr_reporteestadisticocompraspdf.AV30LinCod = aP0_LinCod;
         objr_reporteestadisticocompraspdf.AV54FamCod = aP1_FamCod;
         objr_reporteestadisticocompraspdf.AV28ProdCod = aP2_ProdCod;
         objr_reporteestadisticocompraspdf.AV14FDesde = aP3_FDesde;
         objr_reporteestadisticocompraspdf.AV15FHasta = aP4_FHasta;
         objr_reporteestadisticocompraspdf.context.SetSubmitInitialConfig(context);
         objr_reporteestadisticocompraspdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reporteestadisticocompraspdf);
         aP0_LinCod=this.AV30LinCod;
         aP1_FamCod=this.AV54FamCod;
         aP2_ProdCod=this.AV28ProdCod;
         aP3_FDesde=this.AV14FDesde;
         aP4_FHasta=this.AV15FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reporteestadisticocompraspdf)stateInfo).executePrivate();
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
            AV39Empresa = AV43Session.Get("Empresa");
            AV40EmpDir = AV43Session.Get("EmpDir");
            AV41EmpRUC = AV43Session.Get("EmpRUC");
            AV42Ruta = AV43Session.Get("RUTA") + "/Logo.jpg";
            AV44Logo = AV42Ruta;
            AV62Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV16Filtro1 = "Todos";
            AV17Filtro2 = "Todos";
            AV18Filtro3 = "Todos";
            /* Using cursor P00DD2 */
            pr_default.execute(0, new Object[] {AV30LinCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A52LinCod = P00DD2_A52LinCod[0];
               n52LinCod = P00DD2_n52LinCod[0];
               A1153LinDsc = P00DD2_A1153LinDsc[0];
               AV16Filtro1 = "Linea : " + StringUtil.Trim( A1153LinDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00DD3 */
            pr_default.execute(1, new Object[] {AV54FamCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A50FamCod = P00DD3_A50FamCod[0];
               n50FamCod = P00DD3_n50FamCod[0];
               A977FamDsc = P00DD3_A977FamDsc[0];
               AV16Filtro1 = "Familia : " + StringUtil.Trim( A977FamDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00DD4 */
            pr_default.execute(2, new Object[] {AV28ProdCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A28ProdCod = P00DD4_A28ProdCod[0];
               A55ProdDsc = P00DD4_A55ProdDsc[0];
               AV16Filtro1 = "Producto : " + StringUtil.Trim( A55ProdDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV57TotalGeneralMN = 0.00m;
            AV58TotalGeneralME = 0.00m;
            AV59TotalPor = (decimal)(100);
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV30LinCod ,
                                                 AV54FamCod ,
                                                 AV28ProdCod ,
                                                 A52LinCod ,
                                                 A50FamCod ,
                                                 A254ComDProCod ,
                                                 A707ComFReg ,
                                                 AV14FDesde ,
                                                 AV15FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00DD5 */
            pr_default.execute(3, new Object[] {AV14FDesde, AV15FHasta, AV30LinCod, AV54FamCod, AV28ProdCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               BRKDD6 = false;
               A149TipCod = P00DD5_A149TipCod[0];
               A243ComCod = P00DD5_A243ComCod[0];
               A247PrvDsc = P00DD5_A247PrvDsc[0];
               A244PrvCod = P00DD5_A244PrvCod[0];
               A707ComFReg = P00DD5_A707ComFReg[0];
               A254ComDProCod = P00DD5_A254ComDProCod[0];
               n254ComDProCod = P00DD5_n254ComDProCod[0];
               A50FamCod = P00DD5_A50FamCod[0];
               n50FamCod = P00DD5_n50FamCod[0];
               A52LinCod = P00DD5_A52LinCod[0];
               n52LinCod = P00DD5_n52LinCod[0];
               A250ComDItem = P00DD5_A250ComDItem[0];
               A251ComDOrdCod = P00DD5_A251ComDOrdCod[0];
               A247PrvDsc = P00DD5_A247PrvDsc[0];
               A707ComFReg = P00DD5_A707ComFReg[0];
               A50FamCod = P00DD5_A50FamCod[0];
               n50FamCod = P00DD5_n50FamCod[0];
               A52LinCod = P00DD5_A52LinCod[0];
               n52LinCod = P00DD5_n52LinCod[0];
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00DD5_A244PrvCod[0], A244PrvCod) == 0 ) )
               {
                  BRKDD6 = false;
                  A149TipCod = P00DD5_A149TipCod[0];
                  A243ComCod = P00DD5_A243ComCod[0];
                  A247PrvDsc = P00DD5_A247PrvDsc[0];
                  A250ComDItem = P00DD5_A250ComDItem[0];
                  A251ComDOrdCod = P00DD5_A251ComDOrdCod[0];
                  A247PrvDsc = P00DD5_A247PrvDsc[0];
                  BRKDD6 = true;
                  pr_default.readNext(3);
               }
               AV46PrvCod = A244PrvCod;
               AV50PrvDsc = A247PrvDsc;
               AV51ImpMN = 0.00m;
               AV52ImpME = 0.00m;
               AV53Por = 0.00m;
               /* Execute user subroutine: 'PROVEEDORES' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  this.cleanup();
                  if (true) return;
               }
               AV51ImpMN = AV55TotalMN;
               AV52ImpME = AV56TotalME;
               AV57TotalGeneralMN = (decimal)(AV57TotalGeneralMN+AV51ImpMN);
               AV58TotalGeneralME = (decimal)(AV58TotalGeneralME+AV52ImpME);
               if ( ! (Convert.ToDecimal(0)==AV51ImpMN) )
               {
                  AV48SDTComprasProductoITem.gxTpr_Clicod = AV46PrvCod;
                  AV48SDTComprasProductoITem.gxTpr_Clidsc = AV50PrvDsc;
                  AV48SDTComprasProductoITem.gxTpr_Importe = AV51ImpMN;
                  AV48SDTComprasProductoITem.gxTpr_Importe1 = AV52ImpME;
                  AV48SDTComprasProductoITem.gxTpr_Importe2 = AV53Por;
                  AV49SDTComprasProducto.Add(AV48SDTComprasProductoITem, 0);
                  AV48SDTComprasProductoITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
               }
               if ( ! BRKDD6 )
               {
                  BRKDD6 = true;
                  pr_default.readNext(3);
               }
            }
            pr_default.close(3);
            AV49SDTComprasProducto.Sort("[Importe]");
            AV71GXV1 = 1;
            while ( AV71GXV1 <= AV49SDTComprasProducto.Count )
            {
               AV48SDTComprasProductoITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV49SDTComprasProducto.Item(AV71GXV1));
               AV46PrvCod = AV48SDTComprasProductoITem.gxTpr_Clicod;
               AV50PrvDsc = AV48SDTComprasProductoITem.gxTpr_Clidsc;
               AV51ImpMN = AV48SDTComprasProductoITem.gxTpr_Importe;
               AV52ImpME = AV48SDTComprasProductoITem.gxTpr_Importe1;
               AV53Por = NumberUtil.Round( (AV51ImpMN/ (decimal)(AV57TotalGeneralMN))*100, 2);
               HDD0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46PrvCod, "@!")), 6, Gx_line+2, 111, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50PrvDsc, "")), 115, Gx_line+3, 478, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52ImpME, "ZZZZZZ,ZZZ,ZZ9.99")), 594, Gx_line+2, 701, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51ImpMN, "ZZZZZZ,ZZZ,ZZ9.99")), 486, Gx_line+2, 593, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53Por, "ZZ9.99")), 725, Gx_line+2, 764, Gx_line+17, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV71GXV1 = (int)(AV71GXV1+1);
            }
            HDD0( false, 52) ;
            getPrinter().GxDrawLine(497, Gx_line+9, 785, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 394, Gx_line+16, 474, Gx_line+30, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57TotalGeneralMN, "ZZZZZZ,ZZZ,ZZ9.99")), 486, Gx_line+16, 593, Gx_line+31, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58TotalGeneralME, "ZZZZZZ,ZZZ,ZZ9.99")), 594, Gx_line+16, 701, Gx_line+31, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59TotalPor, "ZZ9.99")), 725, Gx_line+16, 764, Gx_line+31, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HDD0( true, 0) ;
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
         /* 'PROVEEDORES' Routine */
         returnInSub = false;
         AV55TotalMN = 0.00m;
         AV56TotalME = 0.00m;
         AV24Total = 0.00m;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV30LinCod ,
                                              AV54FamCod ,
                                              AV28ProdCod ,
                                              A52LinCod ,
                                              A50FamCod ,
                                              A254ComDProCod ,
                                              A707ComFReg ,
                                              AV14FDesde ,
                                              AV15FHasta ,
                                              A244PrvCod ,
                                              AV46PrvCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00DD6 */
         pr_default.execute(4, new Object[] {AV14FDesde, AV15FHasta, AV46PrvCod, AV30LinCod, AV54FamCod, AV28ProdCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A243ComCod = P00DD6_A243ComCod[0];
            A707ComFReg = P00DD6_A707ComFReg[0];
            A254ComDProCod = P00DD6_A254ComDProCod[0];
            n254ComDProCod = P00DD6_n254ComDProCod[0];
            A50FamCod = P00DD6_A50FamCod[0];
            n50FamCod = P00DD6_n50FamCod[0];
            A52LinCod = P00DD6_A52LinCod[0];
            n52LinCod = P00DD6_n52LinCod[0];
            A244PrvCod = P00DD6_A244PrvCod[0];
            A149TipCod = P00DD6_A149TipCod[0];
            A248ComFec = P00DD6_A248ComFec[0];
            A704ComFecPago = P00DD6_A704ComFecPago[0];
            A724ComRefFec = P00DD6_A724ComRefFec[0];
            A511TipSigno = P00DD6_A511TipSigno[0];
            A246ComMon = P00DD6_A246ComMon[0];
            A689ComDDct = P00DD6_A689ComDDct[0];
            A686ComDPre = P00DD6_A686ComDPre[0];
            A685ComDCant = P00DD6_A685ComDCant[0];
            A250ComDItem = P00DD6_A250ComDItem[0];
            A251ComDOrdCod = P00DD6_A251ComDOrdCod[0];
            A50FamCod = P00DD6_A50FamCod[0];
            n50FamCod = P00DD6_n50FamCod[0];
            A52LinCod = P00DD6_A52LinCod[0];
            n52LinCod = P00DD6_n52LinCod[0];
            A511TipSigno = P00DD6_A511TipSigno[0];
            A707ComFReg = P00DD6_A707ComFReg[0];
            A248ComFec = P00DD6_A248ComFec[0];
            A704ComFecPago = P00DD6_A704ComFecPago[0];
            A724ComRefFec = P00DD6_A724ComRefFec[0];
            A246ComMon = P00DD6_A246ComMon[0];
            A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
            A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
            A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
            AV45TipCod2 = A149TipCod;
            AV25Fecha = (((StringUtil.StrCmp(AV45TipCod2, "NC")==0)||(StringUtil.StrCmp(AV45TipCod2, "ND")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : ((DateTime.MinValue==A704ComFecPago) ? A248ComFec : A704ComFecPago));
            AV33TipSigno = A511TipSigno;
            AV12MonCod = A246ComMon;
            AV24Total = NumberUtil.Round( NumberUtil.Round( A684ComDTot, 2)*A511TipSigno, 2);
            GXt_decimal1 = AV26Cambio;
            GXt_int2 = 2;
            GXt_char3 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV25Fecha, ref  GXt_char3, out  GXt_decimal1) ;
            AV26Cambio = GXt_decimal1;
            if ( AV12MonCod == 1 )
            {
               AV55TotalMN = (decimal)(AV55TotalMN+AV24Total);
               AV56TotalME = (decimal)(AV56TotalME+(NumberUtil.Round( AV24Total/ (decimal)(AV26Cambio), 2)));
            }
            else
            {
               AV56TotalME = (decimal)(AV56TotalME+AV24Total);
               AV55TotalMN = (decimal)(AV55TotalMN+(NumberUtil.Round( AV24Total*AV26Cambio, 2)));
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void HDD0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 669, Gx_line+43, 701, Gx_line+57, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 669, Gx_line+63, 713, Gx_line+77, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 669, Gx_line+24, 708, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Filtro1, "")), 189, Gx_line+65, 660, Gx_line+85, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+121, 797, Gx_line+147, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 714, Gx_line+24, 761, Gx_line+39, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 699, Gx_line+43, 759, Gx_line+57, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 722, Gx_line+63, 761, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("R.U.C.", 19, Gx_line+128, 53, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total ME", 648, Gx_line+127, 699, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 164, Gx_line+128, 226, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total MN", 536, Gx_line+127, 588, Gx_line+141, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV44Logo)) ? AV62Logo_GXI : AV44Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+19, 176, Gx_line+97) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen Estadistico de Compras por", 259, Gx_line+43, 574, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Del :", 283, Gx_line+90, 324, Gx_line+110, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV14FDesde, "99/99/99"), 332, Gx_line+88, 406, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 408, Gx_line+90, 438, Gx_line+110, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV15FHasta, "99/99/99"), 443, Gx_line+88, 517, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("%", 738, Gx_line+127, 753, Gx_line+141, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+147);
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
         AV39Empresa = "";
         AV43Session = context.GetSession();
         AV40EmpDir = "";
         AV41EmpRUC = "";
         AV42Ruta = "";
         AV44Logo = "";
         AV62Logo_GXI = "";
         AV16Filtro1 = "";
         AV17Filtro2 = "";
         AV18Filtro3 = "";
         scmdbuf = "";
         P00DD2_A52LinCod = new int[1] ;
         P00DD2_n52LinCod = new bool[] {false} ;
         P00DD2_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P00DD3_A50FamCod = new int[1] ;
         P00DD3_n50FamCod = new bool[] {false} ;
         P00DD3_A977FamDsc = new string[] {""} ;
         A977FamDsc = "";
         P00DD4_A28ProdCod = new string[] {""} ;
         P00DD4_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         A254ComDProCod = "";
         A707ComFReg = DateTime.MinValue;
         P00DD5_A149TipCod = new string[] {""} ;
         P00DD5_A243ComCod = new string[] {""} ;
         P00DD5_A247PrvDsc = new string[] {""} ;
         P00DD5_A244PrvCod = new string[] {""} ;
         P00DD5_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00DD5_A254ComDProCod = new string[] {""} ;
         P00DD5_n254ComDProCod = new bool[] {false} ;
         P00DD5_A50FamCod = new int[1] ;
         P00DD5_n50FamCod = new bool[] {false} ;
         P00DD5_A52LinCod = new int[1] ;
         P00DD5_n52LinCod = new bool[] {false} ;
         P00DD5_A250ComDItem = new short[1] ;
         P00DD5_A251ComDOrdCod = new string[] {""} ;
         A149TipCod = "";
         A243ComCod = "";
         A247PrvDsc = "";
         A244PrvCod = "";
         A251ComDOrdCod = "";
         AV46PrvCod = "";
         AV50PrvDsc = "";
         AV48SDTComprasProductoITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV49SDTComprasProducto = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         P00DD6_A243ComCod = new string[] {""} ;
         P00DD6_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00DD6_A254ComDProCod = new string[] {""} ;
         P00DD6_n254ComDProCod = new bool[] {false} ;
         P00DD6_A50FamCod = new int[1] ;
         P00DD6_n50FamCod = new bool[] {false} ;
         P00DD6_A52LinCod = new int[1] ;
         P00DD6_n52LinCod = new bool[] {false} ;
         P00DD6_A244PrvCod = new string[] {""} ;
         P00DD6_A149TipCod = new string[] {""} ;
         P00DD6_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DD6_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00DD6_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00DD6_A511TipSigno = new short[1] ;
         P00DD6_A246ComMon = new int[1] ;
         P00DD6_A689ComDDct = new decimal[1] ;
         P00DD6_A686ComDPre = new decimal[1] ;
         P00DD6_A685ComDCant = new decimal[1] ;
         P00DD6_A250ComDItem = new short[1] ;
         P00DD6_A251ComDOrdCod = new string[] {""} ;
         A248ComFec = DateTime.MinValue;
         A704ComFecPago = DateTime.MinValue;
         A724ComRefFec = DateTime.MinValue;
         AV45TipCod2 = "";
         AV25Fecha = DateTime.MinValue;
         GXt_char3 = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV44Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_reporteestadisticocompraspdf__default(),
            new Object[][] {
                new Object[] {
               P00DD2_A52LinCod, P00DD2_A1153LinDsc
               }
               , new Object[] {
               P00DD3_A50FamCod, P00DD3_A977FamDsc
               }
               , new Object[] {
               P00DD4_A28ProdCod, P00DD4_A55ProdDsc
               }
               , new Object[] {
               P00DD5_A149TipCod, P00DD5_A243ComCod, P00DD5_A247PrvDsc, P00DD5_A244PrvCod, P00DD5_A707ComFReg, P00DD5_A254ComDProCod, P00DD5_n254ComDProCod, P00DD5_A50FamCod, P00DD5_n50FamCod, P00DD5_A52LinCod,
               P00DD5_n52LinCod, P00DD5_A250ComDItem, P00DD5_A251ComDOrdCod
               }
               , new Object[] {
               P00DD6_A243ComCod, P00DD6_A707ComFReg, P00DD6_A254ComDProCod, P00DD6_n254ComDProCod, P00DD6_A50FamCod, P00DD6_n50FamCod, P00DD6_A52LinCod, P00DD6_n52LinCod, P00DD6_A244PrvCod, P00DD6_A149TipCod,
               P00DD6_A248ComFec, P00DD6_A704ComFecPago, P00DD6_A724ComRefFec, P00DD6_A511TipSigno, P00DD6_A246ComMon, P00DD6_A689ComDDct, P00DD6_A686ComDPre, P00DD6_A685ComDCant, P00DD6_A250ComDItem, P00DD6_A251ComDOrdCod
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
      private short A250ComDItem ;
      private short A511TipSigno ;
      private short AV33TipSigno ;
      private int AV30LinCod ;
      private int AV54FamCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A52LinCod ;
      private int A50FamCod ;
      private int AV71GXV1 ;
      private int Gx_OldLine ;
      private int A246ComMon ;
      private int AV12MonCod ;
      private int GXt_int2 ;
      private decimal AV57TotalGeneralMN ;
      private decimal AV58TotalGeneralME ;
      private decimal AV59TotalPor ;
      private decimal AV51ImpMN ;
      private decimal AV52ImpME ;
      private decimal AV53Por ;
      private decimal AV55TotalMN ;
      private decimal AV56TotalME ;
      private decimal AV24Total ;
      private decimal A689ComDDct ;
      private decimal A686ComDPre ;
      private decimal A685ComDCant ;
      private decimal A688ComDSub ;
      private decimal A687ComDDescuento ;
      private decimal A684ComDTot ;
      private decimal AV26Cambio ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV28ProdCod ;
      private string AV39Empresa ;
      private string AV40EmpDir ;
      private string AV41EmpRUC ;
      private string AV42Ruta ;
      private string AV16Filtro1 ;
      private string AV17Filtro2 ;
      private string AV18Filtro3 ;
      private string scmdbuf ;
      private string A1153LinDsc ;
      private string A977FamDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A254ComDProCod ;
      private string A149TipCod ;
      private string A243ComCod ;
      private string A247PrvDsc ;
      private string A244PrvCod ;
      private string A251ComDOrdCod ;
      private string AV46PrvCod ;
      private string AV50PrvDsc ;
      private string AV45TipCod2 ;
      private string GXt_char3 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV14FDesde ;
      private DateTime AV15FHasta ;
      private DateTime A707ComFReg ;
      private DateTime A248ComFec ;
      private DateTime A704ComFecPago ;
      private DateTime A724ComRefFec ;
      private DateTime AV25Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n52LinCod ;
      private bool n50FamCod ;
      private bool BRKDD6 ;
      private bool n254ComDProCod ;
      private bool returnInSub ;
      private string AV62Logo_GXI ;
      private string AV44Logo ;
      private string Logo ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_FamCod ;
      private string aP2_ProdCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private IDataStoreProvider pr_default ;
      private int[] P00DD2_A52LinCod ;
      private bool[] P00DD2_n52LinCod ;
      private string[] P00DD2_A1153LinDsc ;
      private int[] P00DD3_A50FamCod ;
      private bool[] P00DD3_n50FamCod ;
      private string[] P00DD3_A977FamDsc ;
      private string[] P00DD4_A28ProdCod ;
      private string[] P00DD4_A55ProdDsc ;
      private string[] P00DD5_A149TipCod ;
      private string[] P00DD5_A243ComCod ;
      private string[] P00DD5_A247PrvDsc ;
      private string[] P00DD5_A244PrvCod ;
      private DateTime[] P00DD5_A707ComFReg ;
      private string[] P00DD5_A254ComDProCod ;
      private bool[] P00DD5_n254ComDProCod ;
      private int[] P00DD5_A50FamCod ;
      private bool[] P00DD5_n50FamCod ;
      private int[] P00DD5_A52LinCod ;
      private bool[] P00DD5_n52LinCod ;
      private short[] P00DD5_A250ComDItem ;
      private string[] P00DD5_A251ComDOrdCod ;
      private string[] P00DD6_A243ComCod ;
      private DateTime[] P00DD6_A707ComFReg ;
      private string[] P00DD6_A254ComDProCod ;
      private bool[] P00DD6_n254ComDProCod ;
      private int[] P00DD6_A50FamCod ;
      private bool[] P00DD6_n50FamCod ;
      private int[] P00DD6_A52LinCod ;
      private bool[] P00DD6_n52LinCod ;
      private string[] P00DD6_A244PrvCod ;
      private string[] P00DD6_A149TipCod ;
      private DateTime[] P00DD6_A248ComFec ;
      private DateTime[] P00DD6_A704ComFecPago ;
      private DateTime[] P00DD6_A724ComRefFec ;
      private short[] P00DD6_A511TipSigno ;
      private int[] P00DD6_A246ComMon ;
      private decimal[] P00DD6_A689ComDDct ;
      private decimal[] P00DD6_A686ComDPre ;
      private decimal[] P00DD6_A685ComDCant ;
      private short[] P00DD6_A250ComDItem ;
      private string[] P00DD6_A251ComDOrdCod ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV49SDTComprasProducto ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV48SDTComprasProductoITem ;
   }

   public class r_reporteestadisticocompraspdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DD5( IGxContext context ,
                                             int AV30LinCod ,
                                             int AV54FamCod ,
                                             string AV28ProdCod ,
                                             int A52LinCod ,
                                             int A50FamCod ,
                                             string A254ComDProCod ,
                                             DateTime A707ComFReg ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[5];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T1.[ComCod], T2.[PrvDsc], T1.[PrvCod], T2.[ComFReg], T1.[ComDProCod] AS ComDProCod, T3.[FamCod], T3.[LinCod], T1.[ComDItem], T1.[ComDOrdCod] FROM (([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) LEFT JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ComDProCod])";
         AddWhere(sWhereString, "(Not T1.[ComDProCod] IS NULL)");
         AddWhere(sWhereString, "(T2.[ComFReg] >= @AV14FDesde)");
         AddWhere(sWhereString, "(T2.[ComFReg] <= @AV15FHasta)");
         if ( ! (0==AV30LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV30LinCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV54FamCod) )
         {
            AddWhere(sWhereString, "(T3.[FamCod] = @AV54FamCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDProCod] = @AV28ProdCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PrvCod], T2.[PrvDsc]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00DD6( IGxContext context ,
                                             int AV30LinCod ,
                                             int AV54FamCod ,
                                             string AV28ProdCod ,
                                             int A52LinCod ,
                                             int A50FamCod ,
                                             string A254ComDProCod ,
                                             DateTime A707ComFReg ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta ,
                                             string A244PrvCod ,
                                             string AV46PrvCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[6];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[ComCod], T4.[ComFReg], T1.[ComDProCod] AS ComDProCod, T2.[FamCod], T2.[LinCod], T1.[PrvCod], T1.[TipCod], T4.[ComFec], T4.[ComFecPago], T4.[ComRefFec], T3.[TipSigno], T4.[ComMon], T1.[ComDDct], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem], T1.[ComDOrdCod] FROM ((([CPCOMPRASDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ComDProCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(Not T1.[ComDProCod] IS NULL)");
         AddWhere(sWhereString, "(T4.[ComFReg] >= @AV14FDesde and T4.[ComFReg] <= @AV15FHasta)");
         AddWhere(sWhereString, "(T1.[PrvCod] = @AV46PrvCod)");
         if ( ! (0==AV30LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV30LinCod)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV54FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV54FamCod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDProCod] = @AV28ProdCod)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipCod], T1.[ComCod], T1.[PrvCod], T1.[ComDItem], T1.[ComDOrdCod]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_P00DD5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] );
               case 4 :
                     return conditional_P00DD6(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
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
          Object[] prmP00DD2;
          prmP00DD2 = new Object[] {
          new ParDef("@AV30LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00DD3;
          prmP00DD3 = new Object[] {
          new ParDef("@AV54FamCod",GXType.Int32,6,0)
          };
          Object[] prmP00DD4;
          prmP00DD4 = new Object[] {
          new ParDef("@AV28ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DD5;
          prmP00DD5 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV30LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV54FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV28ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DD6;
          prmP00DD6 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV46PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV30LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV54FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV28ProdCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DD2", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV30LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DD3", "SELECT [FamCod], [FamDsc] FROM [CFAMILIA] WHERE [FamCod] = @AV54FamCod ORDER BY [FamCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DD4", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV28ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DD5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DD6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((short[]) buf[11])[0] = rslt.getShort(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 10);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 20);
                ((string[]) buf[9])[0] = rslt.getString(7, 3);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(10);
                ((short[]) buf[13])[0] = rslt.getShort(11);
                ((int[]) buf[14])[0] = rslt.getInt(12);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(15);
                ((short[]) buf[18])[0] = rslt.getShort(16);
                ((string[]) buf[19])[0] = rslt.getString(17, 10);
                return;
       }
    }

 }

}
