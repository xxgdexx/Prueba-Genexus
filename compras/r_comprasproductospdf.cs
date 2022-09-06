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
   public class r_comprasproductospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_comprasproductospdf.aspx")), "compras.r_comprasproductospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_comprasproductospdf.aspx")))) ;
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
               AV28LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV40SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV33ProdCod = GetPar( "ProdCod");
                  AV20FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV22FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV15DocMonCod = (int)(NumberUtil.Val( GetPar( "DocMonCod"), "."));
                  AV35PrvCod = GetPar( "PrvCod");
                  AV45Tipo = GetPar( "Tipo");
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

      public r_comprasproductospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_comprasproductospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SubLCod ,
                           ref string aP2_ProdCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref int aP5_DocMonCod ,
                           ref string aP6_PrvCod ,
                           ref string aP7_Tipo )
      {
         this.AV28LinCod = aP0_LinCod;
         this.AV40SubLCod = aP1_SubLCod;
         this.AV33ProdCod = aP2_ProdCod;
         this.AV20FDesde = aP3_FDesde;
         this.AV22FHasta = aP4_FHasta;
         this.AV15DocMonCod = aP5_DocMonCod;
         this.AV35PrvCod = aP6_PrvCod;
         this.AV45Tipo = aP7_Tipo;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV28LinCod;
         aP1_SubLCod=this.AV40SubLCod;
         aP2_ProdCod=this.AV33ProdCod;
         aP3_FDesde=this.AV20FDesde;
         aP4_FHasta=this.AV22FHasta;
         aP5_DocMonCod=this.AV15DocMonCod;
         aP6_PrvCod=this.AV35PrvCod;
         aP7_Tipo=this.AV45Tipo;
      }

      public string executeUdp( ref int aP0_LinCod ,
                                ref int aP1_SubLCod ,
                                ref string aP2_ProdCod ,
                                ref DateTime aP3_FDesde ,
                                ref DateTime aP4_FHasta ,
                                ref int aP5_DocMonCod ,
                                ref string aP6_PrvCod )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_ProdCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_DocMonCod, ref aP6_PrvCod, ref aP7_Tipo);
         return AV45Tipo ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref string aP2_ProdCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref int aP5_DocMonCod ,
                                 ref string aP6_PrvCod ,
                                 ref string aP7_Tipo )
      {
         r_comprasproductospdf objr_comprasproductospdf;
         objr_comprasproductospdf = new r_comprasproductospdf();
         objr_comprasproductospdf.AV28LinCod = aP0_LinCod;
         objr_comprasproductospdf.AV40SubLCod = aP1_SubLCod;
         objr_comprasproductospdf.AV33ProdCod = aP2_ProdCod;
         objr_comprasproductospdf.AV20FDesde = aP3_FDesde;
         objr_comprasproductospdf.AV22FHasta = aP4_FHasta;
         objr_comprasproductospdf.AV15DocMonCod = aP5_DocMonCod;
         objr_comprasproductospdf.AV35PrvCod = aP6_PrvCod;
         objr_comprasproductospdf.AV45Tipo = aP7_Tipo;
         objr_comprasproductospdf.context.SetSubmitInitialConfig(context);
         objr_comprasproductospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_comprasproductospdf);
         aP0_LinCod=this.AV28LinCod;
         aP1_SubLCod=this.AV40SubLCod;
         aP2_ProdCod=this.AV33ProdCod;
         aP3_FDesde=this.AV20FDesde;
         aP4_FHasta=this.AV22FHasta;
         aP5_DocMonCod=this.AV15DocMonCod;
         aP6_PrvCod=this.AV35PrvCod;
         aP7_Tipo=this.AV45Tipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_comprasproductospdf)stateInfo).executePrivate();
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
            AV17Empresa = AV39Session.Get("Empresa");
            AV16EmpDir = AV39Session.Get("EmpDir");
            AV18EmpRUC = AV39Session.Get("EmpRUC");
            AV36Ruta = AV39Session.Get("RUTA") + "/Logo.jpg";
            AV29Logo = AV36Ruta;
            AV53Logo_GXI = GXDbFile.PathToUrl( AV36Ruta);
            AV23Filtro1 = "(Todos)";
            AV24Filtro2 = "(Todos)";
            AV25Filtro3 = "(Todos)";
            AV26Filtro4 = ((StringUtil.StrCmp(AV45Tipo, "P")==0) ? "Productos" : ((StringUtil.StrCmp(AV45Tipo, "S")==0) ? "Servicio" : ((StringUtil.StrCmp(AV45Tipo, "G")==0) ? "Gastos" : "(Todos)")));
            /* Using cursor P00AT2 */
            pr_default.execute(0, new Object[] {AV28LinCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A52LinCod = P00AT2_A52LinCod[0];
               n52LinCod = P00AT2_n52LinCod[0];
               A1153LinDsc = P00AT2_A1153LinDsc[0];
               AV23Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00AT3 */
            pr_default.execute(1, new Object[] {AV40SubLCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A51SublCod = P00AT3_A51SublCod[0];
               n51SublCod = P00AT3_n51SublCod[0];
               A1892SublDsc = P00AT3_A1892SublDsc[0];
               AV24Filtro2 = A1892SublDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00AT4 */
            pr_default.execute(2, new Object[] {AV33ProdCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A28ProdCod = P00AT4_A28ProdCod[0];
               A55ProdDsc = P00AT4_A55ProdDsc[0];
               AV25Filtro3 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P00AT5 */
            pr_default.execute(3, new Object[] {AV15DocMonCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A180MonCod = P00AT5_A180MonCod[0];
               A1234MonDsc = P00AT5_A1234MonDsc[0];
               AV27Filtro5 = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            AV48TotalGeneral = 0.00m;
            /* Execute user subroutine: 'PRODUCTOS' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            if ( ( StringUtil.StrCmp(AV45Tipo, "G") == 0 ) || ( StringUtil.StrCmp(AV45Tipo, "T") == 0 ) )
            {
               /* Execute user subroutine: 'GASTOS' */
               S131 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            AV37SDTComprasProducto.Sort("[Importe]");
            AV61GXV1 = 1;
            while ( AV61GXV1 <= AV37SDTComprasProducto.Count )
            {
               AV38SDTComprasProductoITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV37SDTComprasProducto.Item(AV61GXV1));
               AV33ProdCod = AV38SDTComprasProductoITem.gxTpr_Clicod;
               AV34ProdDsc = AV38SDTComprasProductoITem.gxTpr_Clidsc;
               AV10Cantidad = AV38SDTComprasProductoITem.gxTpr_Cantidad;
               AV49TotalVenta = AV38SDTComprasProductoITem.gxTpr_Importe;
               HAT0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33ProdCod, "@!")), 18, Gx_line+3, 143, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34ProdDsc, "")), 146, Gx_line+3, 509, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49TotalVenta, "ZZZZZZ,ZZZ,ZZ9.99")), 625, Gx_line+3, 749, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV10Cantidad, "ZZZZ,ZZZ,ZZ9.9999")), 524, Gx_line+3, 631, Gx_line+18, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV61GXV1 = (int)(AV61GXV1+1);
            }
            HAT0( false, 52) ;
            getPrinter().GxDrawLine(590, Gx_line+9, 785, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 417, Gx_line+17, 497, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48TotalGeneral, "ZZZZZZ,ZZZ,ZZ9.99")), 649, Gx_line+16, 756, Gx_line+31, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAT0( true, 0) ;
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
         /* 'PRODUCTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV28LinCod ,
                                              AV40SubLCod ,
                                              AV33ProdCod ,
                                              AV35PrvCod ,
                                              AV45Tipo ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A254ComDProCod ,
                                              A244PrvCod ,
                                              A1158LinStk ,
                                              A697ComDOrdTip ,
                                              A707ComFReg ,
                                              AV20FDesde ,
                                              AV22FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AT6 */
         pr_default.execute(4, new Object[] {AV20FDesde, AV22FHasta, AV28LinCod, AV40SubLCod, AV33ProdCod, AV35PrvCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKAT7 = false;
            A149TipCod = P00AT6_A149TipCod[0];
            A243ComCod = P00AT6_A243ComCod[0];
            A694ComDDsc = P00AT6_A694ComDDsc[0];
            A254ComDProCod = P00AT6_A254ComDProCod[0];
            n254ComDProCod = P00AT6_n254ComDProCod[0];
            A707ComFReg = P00AT6_A707ComFReg[0];
            A697ComDOrdTip = P00AT6_A697ComDOrdTip[0];
            A1158LinStk = P00AT6_A1158LinStk[0];
            A244PrvCod = P00AT6_A244PrvCod[0];
            A51SublCod = P00AT6_A51SublCod[0];
            n51SublCod = P00AT6_n51SublCod[0];
            A52LinCod = P00AT6_A52LinCod[0];
            n52LinCod = P00AT6_n52LinCod[0];
            A686ComDPre = P00AT6_A686ComDPre[0];
            A250ComDItem = P00AT6_A250ComDItem[0];
            A251ComDOrdCod = P00AT6_A251ComDOrdCod[0];
            A51SublCod = P00AT6_A51SublCod[0];
            n51SublCod = P00AT6_n51SublCod[0];
            A52LinCod = P00AT6_A52LinCod[0];
            n52LinCod = P00AT6_n52LinCod[0];
            A1158LinStk = P00AT6_A1158LinStk[0];
            A707ComFReg = P00AT6_A707ComFReg[0];
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00AT6_A254ComDProCod[0], A254ComDProCod) == 0 ) )
            {
               BRKAT7 = false;
               A149TipCod = P00AT6_A149TipCod[0];
               A243ComCod = P00AT6_A243ComCod[0];
               A694ComDDsc = P00AT6_A694ComDDsc[0];
               A244PrvCod = P00AT6_A244PrvCod[0];
               A250ComDItem = P00AT6_A250ComDItem[0];
               A251ComDOrdCod = P00AT6_A251ComDOrdCod[0];
               BRKAT7 = true;
               pr_default.readNext(4);
            }
            AV50Codigo = A254ComDProCod;
            AV34ProdDsc = A694ComDDsc;
            AV49TotalVenta = 0.00m;
            AV47Total = 0.00m;
            AV9Cant = 0.00m;
            AV10Cantidad = 0.00m;
            AV41TCantidad = 0.00m;
            /* Execute user subroutine: 'DETALLEPRODUCTOS' */
            S127 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            AV38SDTComprasProductoITem.gxTpr_Clicod = AV50Codigo;
            AV38SDTComprasProductoITem.gxTpr_Clidsc = AV34ProdDsc;
            AV38SDTComprasProductoITem.gxTpr_Cantidad = AV10Cantidad;
            AV38SDTComprasProductoITem.gxTpr_Importe = AV49TotalVenta;
            AV37SDTComprasProducto.Add(AV38SDTComprasProductoITem, 0);
            AV38SDTComprasProductoITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
            AV48TotalGeneral = (decimal)(AV48TotalGeneral+AV49TotalVenta);
            if ( ! BRKAT7 )
            {
               BRKAT7 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S131( )
      {
         /* 'GASTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV28LinCod ,
                                              AV40SubLCod ,
                                              AV33ProdCod ,
                                              AV35PrvCod ,
                                              AV45Tipo ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A254ComDProCod ,
                                              A244PrvCod ,
                                              A253ComDCueCod ,
                                              A697ComDOrdTip ,
                                              A707ComFReg ,
                                              AV20FDesde ,
                                              AV22FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AT7 */
         pr_default.execute(5, new Object[] {AV20FDesde, AV22FHasta, AV28LinCod, AV40SubLCod, AV33ProdCod, AV35PrvCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKAT9 = false;
            A149TipCod = P00AT7_A149TipCod[0];
            A243ComCod = P00AT7_A243ComCod[0];
            A694ComDDsc = P00AT7_A694ComDDsc[0];
            A253ComDCueCod = P00AT7_A253ComDCueCod[0];
            n253ComDCueCod = P00AT7_n253ComDCueCod[0];
            A707ComFReg = P00AT7_A707ComFReg[0];
            A697ComDOrdTip = P00AT7_A697ComDOrdTip[0];
            A244PrvCod = P00AT7_A244PrvCod[0];
            A254ComDProCod = P00AT7_A254ComDProCod[0];
            n254ComDProCod = P00AT7_n254ComDProCod[0];
            A51SublCod = P00AT7_A51SublCod[0];
            n51SublCod = P00AT7_n51SublCod[0];
            A52LinCod = P00AT7_A52LinCod[0];
            n52LinCod = P00AT7_n52LinCod[0];
            A686ComDPre = P00AT7_A686ComDPre[0];
            A250ComDItem = P00AT7_A250ComDItem[0];
            A251ComDOrdCod = P00AT7_A251ComDOrdCod[0];
            A707ComFReg = P00AT7_A707ComFReg[0];
            A51SublCod = P00AT7_A51SublCod[0];
            n51SublCod = P00AT7_n51SublCod[0];
            A52LinCod = P00AT7_A52LinCod[0];
            n52LinCod = P00AT7_n52LinCod[0];
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00AT7_A253ComDCueCod[0], A253ComDCueCod) == 0 ) )
            {
               BRKAT9 = false;
               A149TipCod = P00AT7_A149TipCod[0];
               A243ComCod = P00AT7_A243ComCod[0];
               A694ComDDsc = P00AT7_A694ComDDsc[0];
               A244PrvCod = P00AT7_A244PrvCod[0];
               A250ComDItem = P00AT7_A250ComDItem[0];
               A251ComDOrdCod = P00AT7_A251ComDOrdCod[0];
               BRKAT9 = true;
               pr_default.readNext(5);
            }
            AV50Codigo = A253ComDCueCod;
            AV34ProdDsc = A694ComDDsc;
            AV49TotalVenta = 0.00m;
            AV47Total = 0.00m;
            AV9Cant = 0.00m;
            AV10Cantidad = 0.00m;
            AV41TCantidad = 0.00m;
            /* Execute user subroutine: 'DETALLEGASTOS' */
            S149 ();
            if ( returnInSub )
            {
               pr_default.close(5);
               returnInSub = true;
               if (true) return;
            }
            AV38SDTComprasProductoITem.gxTpr_Clicod = AV50Codigo;
            AV38SDTComprasProductoITem.gxTpr_Clidsc = AV34ProdDsc;
            AV38SDTComprasProductoITem.gxTpr_Cantidad = AV10Cantidad;
            AV38SDTComprasProductoITem.gxTpr_Importe = AV49TotalVenta;
            AV37SDTComprasProducto.Add(AV38SDTComprasProductoITem, 0);
            AV38SDTComprasProductoITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
            AV48TotalGeneral = (decimal)(AV48TotalGeneral+AV49TotalVenta);
            if ( ! BRKAT9 )
            {
               BRKAT9 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S127( )
      {
         /* 'DETALLEPRODUCTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV28LinCod ,
                                              AV40SubLCod ,
                                              AV35PrvCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A244PrvCod ,
                                              A707ComFReg ,
                                              AV20FDesde ,
                                              AV22FHasta ,
                                              AV50Codigo ,
                                              A254ComDProCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00AT8 */
         pr_default.execute(6, new Object[] {AV50Codigo, AV20FDesde, AV22FHasta, AV28LinCod, AV40SubLCod, AV35PrvCod});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A243ComCod = P00AT8_A243ComCod[0];
            A707ComFReg = P00AT8_A707ComFReg[0];
            A254ComDProCod = P00AT8_A254ComDProCod[0];
            n254ComDProCod = P00AT8_n254ComDProCod[0];
            A244PrvCod = P00AT8_A244PrvCod[0];
            A51SublCod = P00AT8_A51SublCod[0];
            n51SublCod = P00AT8_n51SublCod[0];
            A52LinCod = P00AT8_A52LinCod[0];
            n52LinCod = P00AT8_n52LinCod[0];
            A149TipCod = P00AT8_A149TipCod[0];
            A248ComFec = P00AT8_A248ComFec[0];
            A704ComFecPago = P00AT8_A704ComFecPago[0];
            A724ComRefFec = P00AT8_A724ComRefFec[0];
            A511TipSigno = P00AT8_A511TipSigno[0];
            A246ComMon = P00AT8_A246ComMon[0];
            A689ComDDct = P00AT8_A689ComDDct[0];
            A686ComDPre = P00AT8_A686ComDPre[0];
            A685ComDCant = P00AT8_A685ComDCant[0];
            A250ComDItem = P00AT8_A250ComDItem[0];
            A251ComDOrdCod = P00AT8_A251ComDOrdCod[0];
            A51SublCod = P00AT8_A51SublCod[0];
            n51SublCod = P00AT8_n51SublCod[0];
            A52LinCod = P00AT8_A52LinCod[0];
            n52LinCod = P00AT8_n52LinCod[0];
            A511TipSigno = P00AT8_A511TipSigno[0];
            A707ComFReg = P00AT8_A707ComFReg[0];
            A248ComFec = P00AT8_A248ComFec[0];
            A704ComFecPago = P00AT8_A704ComFecPago[0];
            A724ComRefFec = P00AT8_A724ComRefFec[0];
            A246ComMon = P00AT8_A246ComMon[0];
            A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
            A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
            A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
            AV44TipCod2 = A149TipCod;
            AV21Fecha = (((StringUtil.StrCmp(AV44TipCod2, "NC")==0)||(StringUtil.StrCmp(AV44TipCod2, "ND")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : ((DateTime.MinValue==A704ComFecPago) ? A248ComFec : A704ComFecPago));
            AV46TipSigno = A511TipSigno;
            AV30MonCod = A246ComMon;
            AV47Total = NumberUtil.Round( NumberUtil.Round( A684ComDTot, 2)*A511TipSigno, 2);
            AV9Cant = NumberUtil.Round( A685ComDCant*A511TipSigno, 2);
            if ( ( AV15DocMonCod != 1 ) && ( AV15DocMonCod != 0 ) )
            {
               if ( AV30MonCod == 1 )
               {
                  GXt_decimal1 = AV8Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV30MonCod, ref  AV21Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV8Cambio = GXt_decimal1;
                  AV47Total = NumberUtil.Round( AV47Total/ (decimal)(AV8Cambio), 2);
               }
            }
            else
            {
               if ( AV30MonCod != 1 )
               {
                  GXt_decimal1 = AV8Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV30MonCod, ref  AV21Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV8Cambio = GXt_decimal1;
                  AV47Total = NumberUtil.Round( AV47Total*AV8Cambio, 2);
               }
            }
            AV49TotalVenta = (decimal)(AV49TotalVenta+AV47Total);
            AV10Cantidad = (decimal)(AV10Cantidad+AV9Cant);
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S149( )
      {
         /* 'DETALLEGASTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV28LinCod ,
                                              AV40SubLCod ,
                                              AV35PrvCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A244PrvCod ,
                                              A697ComDOrdTip ,
                                              A707ComFReg ,
                                              AV20FDesde ,
                                              AV22FHasta ,
                                              AV50Codigo ,
                                              A253ComDCueCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00AT9 */
         pr_default.execute(7, new Object[] {AV50Codigo, AV20FDesde, AV22FHasta, AV28LinCod, AV40SubLCod, AV35PrvCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A243ComCod = P00AT9_A243ComCod[0];
            A254ComDProCod = P00AT9_A254ComDProCod[0];
            n254ComDProCod = P00AT9_n254ComDProCod[0];
            A707ComFReg = P00AT9_A707ComFReg[0];
            A697ComDOrdTip = P00AT9_A697ComDOrdTip[0];
            A253ComDCueCod = P00AT9_A253ComDCueCod[0];
            n253ComDCueCod = P00AT9_n253ComDCueCod[0];
            A244PrvCod = P00AT9_A244PrvCod[0];
            A51SublCod = P00AT9_A51SublCod[0];
            n51SublCod = P00AT9_n51SublCod[0];
            A52LinCod = P00AT9_A52LinCod[0];
            n52LinCod = P00AT9_n52LinCod[0];
            A149TipCod = P00AT9_A149TipCod[0];
            A248ComFec = P00AT9_A248ComFec[0];
            A704ComFecPago = P00AT9_A704ComFecPago[0];
            A724ComRefFec = P00AT9_A724ComRefFec[0];
            A511TipSigno = P00AT9_A511TipSigno[0];
            A246ComMon = P00AT9_A246ComMon[0];
            A689ComDDct = P00AT9_A689ComDDct[0];
            A686ComDPre = P00AT9_A686ComDPre[0];
            A685ComDCant = P00AT9_A685ComDCant[0];
            A250ComDItem = P00AT9_A250ComDItem[0];
            A251ComDOrdCod = P00AT9_A251ComDOrdCod[0];
            A51SublCod = P00AT9_A51SublCod[0];
            n51SublCod = P00AT9_n51SublCod[0];
            A52LinCod = P00AT9_A52LinCod[0];
            n52LinCod = P00AT9_n52LinCod[0];
            A511TipSigno = P00AT9_A511TipSigno[0];
            A707ComFReg = P00AT9_A707ComFReg[0];
            A248ComFec = P00AT9_A248ComFec[0];
            A704ComFecPago = P00AT9_A704ComFecPago[0];
            A724ComRefFec = P00AT9_A724ComRefFec[0];
            A246ComMon = P00AT9_A246ComMon[0];
            A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
            A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
            A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
            AV44TipCod2 = A149TipCod;
            AV21Fecha = (((StringUtil.StrCmp(AV44TipCod2, "NC")==0)||(StringUtil.StrCmp(AV44TipCod2, "ND")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : ((DateTime.MinValue==A704ComFecPago) ? A248ComFec : A704ComFecPago));
            AV46TipSigno = A511TipSigno;
            AV30MonCod = A246ComMon;
            AV47Total = NumberUtil.Round( NumberUtil.Round( A684ComDTot, 2)*A511TipSigno, 2);
            AV9Cant = NumberUtil.Round( A685ComDCant*A511TipSigno, 2);
            if ( ( AV15DocMonCod != 1 ) && ( AV15DocMonCod != 0 ) )
            {
               if ( AV30MonCod == 1 )
               {
                  GXt_decimal1 = AV8Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV30MonCod, ref  AV21Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV8Cambio = GXt_decimal1;
                  AV47Total = NumberUtil.Round( AV47Total/ (decimal)(AV8Cambio), 2);
               }
            }
            else
            {
               if ( AV30MonCod != 1 )
               {
                  GXt_decimal1 = AV8Cambio;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV30MonCod, ref  AV21Fecha, ref  GXt_char2, out  GXt_decimal1) ;
                  AV8Cambio = GXt_decimal1;
                  AV47Total = NumberUtil.Round( AV47Total*AV8Cambio, 2);
               }
            }
            AV49TotalVenta = (decimal)(AV49TotalVenta+AV47Total);
            AV10Cantidad = (decimal)(AV10Cantidad+AV9Cant);
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void HAT0( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro1, "")), 314, Gx_line+98, 657, Gx_line+122, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro2, "")), 314, Gx_line+120, 657, Gx_line+144, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Filtro3, "")), 314, Gx_line+142, 657, Gx_line+166, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+196, 797, Gx_line+222, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 714, Gx_line+24, 761, Gx_line+39, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 699, Gx_line+43, 759, Gx_line+57, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 722, Gx_line+63, 761, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo / Cuenta", 19, Gx_line+203, 114, Gx_line+217, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Compra", 672, Gx_line+203, 752, Gx_line+217, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Productos / Servicios", 150, Gx_line+203, 276, Gx_line+217, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 574, Gx_line+203, 627, Gx_line+217, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV29Logo)) ? AV53Logo_GXI : AV29Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+19, 176, Gx_line+97) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Compras por Productos", 256, Gx_line+25, 563, Gx_line+45, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Del :", 274, Gx_line+47, 315, Gx_line+67, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV20FDesde, "99/99/99"), 323, Gx_line+45, 397, Gx_line+69, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 399, Gx_line+47, 429, Gx_line+67, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV22FHasta, "99/99/99"), 433, Gx_line+45, 507, Gx_line+69, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Expresado en :", 242, Gx_line+70, 369, Gx_line+90, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Filtro5, "")), 374, Gx_line+68, 563, Gx_line+92, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Filtro4, "")), 314, Gx_line+164, 657, Gx_line+188, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Linea de Productos", 176, Gx_line+103, 288, Gx_line+117, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Sub Linea de Productos", 176, Gx_line+126, 313, Gx_line+140, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Productos", 176, Gx_line+149, 236, Gx_line+163, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo Reporte", 176, Gx_line+172, 253, Gx_line+186, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+222);
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
         AV17Empresa = "";
         AV39Session = context.GetSession();
         AV16EmpDir = "";
         AV18EmpRUC = "";
         AV36Ruta = "";
         AV29Logo = "";
         AV53Logo_GXI = "";
         AV23Filtro1 = "";
         AV24Filtro2 = "";
         AV25Filtro3 = "";
         AV26Filtro4 = "";
         scmdbuf = "";
         P00AT2_A52LinCod = new int[1] ;
         P00AT2_n52LinCod = new bool[] {false} ;
         P00AT2_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P00AT3_A51SublCod = new int[1] ;
         P00AT3_n51SublCod = new bool[] {false} ;
         P00AT3_A1892SublDsc = new string[] {""} ;
         A1892SublDsc = "";
         P00AT4_A28ProdCod = new string[] {""} ;
         P00AT4_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00AT5_A180MonCod = new int[1] ;
         P00AT5_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV27Filtro5 = "";
         AV37SDTComprasProducto = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         AV38SDTComprasProductoITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV34ProdDsc = "";
         A254ComDProCod = "";
         A244PrvCod = "";
         A697ComDOrdTip = "";
         A707ComFReg = DateTime.MinValue;
         P00AT6_A149TipCod = new string[] {""} ;
         P00AT6_A243ComCod = new string[] {""} ;
         P00AT6_A694ComDDsc = new string[] {""} ;
         P00AT6_A254ComDProCod = new string[] {""} ;
         P00AT6_n254ComDProCod = new bool[] {false} ;
         P00AT6_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AT6_A697ComDOrdTip = new string[] {""} ;
         P00AT6_A1158LinStk = new short[1] ;
         P00AT6_A244PrvCod = new string[] {""} ;
         P00AT6_A51SublCod = new int[1] ;
         P00AT6_n51SublCod = new bool[] {false} ;
         P00AT6_A52LinCod = new int[1] ;
         P00AT6_n52LinCod = new bool[] {false} ;
         P00AT6_A686ComDPre = new decimal[1] ;
         P00AT6_A250ComDItem = new short[1] ;
         P00AT6_A251ComDOrdCod = new string[] {""} ;
         A149TipCod = "";
         A243ComCod = "";
         A694ComDDsc = "";
         A251ComDOrdCod = "";
         AV50Codigo = "";
         A253ComDCueCod = "";
         P00AT7_A149TipCod = new string[] {""} ;
         P00AT7_A243ComCod = new string[] {""} ;
         P00AT7_A694ComDDsc = new string[] {""} ;
         P00AT7_A253ComDCueCod = new string[] {""} ;
         P00AT7_n253ComDCueCod = new bool[] {false} ;
         P00AT7_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AT7_A697ComDOrdTip = new string[] {""} ;
         P00AT7_A244PrvCod = new string[] {""} ;
         P00AT7_A254ComDProCod = new string[] {""} ;
         P00AT7_n254ComDProCod = new bool[] {false} ;
         P00AT7_A51SublCod = new int[1] ;
         P00AT7_n51SublCod = new bool[] {false} ;
         P00AT7_A52LinCod = new int[1] ;
         P00AT7_n52LinCod = new bool[] {false} ;
         P00AT7_A686ComDPre = new decimal[1] ;
         P00AT7_A250ComDItem = new short[1] ;
         P00AT7_A251ComDOrdCod = new string[] {""} ;
         P00AT8_A243ComCod = new string[] {""} ;
         P00AT8_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AT8_A254ComDProCod = new string[] {""} ;
         P00AT8_n254ComDProCod = new bool[] {false} ;
         P00AT8_A244PrvCod = new string[] {""} ;
         P00AT8_A51SublCod = new int[1] ;
         P00AT8_n51SublCod = new bool[] {false} ;
         P00AT8_A52LinCod = new int[1] ;
         P00AT8_n52LinCod = new bool[] {false} ;
         P00AT8_A149TipCod = new string[] {""} ;
         P00AT8_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AT8_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00AT8_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00AT8_A511TipSigno = new short[1] ;
         P00AT8_A246ComMon = new int[1] ;
         P00AT8_A689ComDDct = new decimal[1] ;
         P00AT8_A686ComDPre = new decimal[1] ;
         P00AT8_A685ComDCant = new decimal[1] ;
         P00AT8_A250ComDItem = new short[1] ;
         P00AT8_A251ComDOrdCod = new string[] {""} ;
         A248ComFec = DateTime.MinValue;
         A704ComFecPago = DateTime.MinValue;
         A724ComRefFec = DateTime.MinValue;
         AV44TipCod2 = "";
         AV21Fecha = DateTime.MinValue;
         P00AT9_A243ComCod = new string[] {""} ;
         P00AT9_A254ComDProCod = new string[] {""} ;
         P00AT9_n254ComDProCod = new bool[] {false} ;
         P00AT9_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AT9_A697ComDOrdTip = new string[] {""} ;
         P00AT9_A253ComDCueCod = new string[] {""} ;
         P00AT9_n253ComDCueCod = new bool[] {false} ;
         P00AT9_A244PrvCod = new string[] {""} ;
         P00AT9_A51SublCod = new int[1] ;
         P00AT9_n51SublCod = new bool[] {false} ;
         P00AT9_A52LinCod = new int[1] ;
         P00AT9_n52LinCod = new bool[] {false} ;
         P00AT9_A149TipCod = new string[] {""} ;
         P00AT9_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AT9_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00AT9_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00AT9_A511TipSigno = new short[1] ;
         P00AT9_A246ComMon = new int[1] ;
         P00AT9_A689ComDDct = new decimal[1] ;
         P00AT9_A686ComDPre = new decimal[1] ;
         P00AT9_A685ComDCant = new decimal[1] ;
         P00AT9_A250ComDItem = new short[1] ;
         P00AT9_A251ComDOrdCod = new string[] {""} ;
         GXt_char2 = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV29Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_comprasproductospdf__default(),
            new Object[][] {
                new Object[] {
               P00AT2_A52LinCod, P00AT2_A1153LinDsc
               }
               , new Object[] {
               P00AT3_A51SublCod, P00AT3_A1892SublDsc
               }
               , new Object[] {
               P00AT4_A28ProdCod, P00AT4_A55ProdDsc
               }
               , new Object[] {
               P00AT5_A180MonCod, P00AT5_A1234MonDsc
               }
               , new Object[] {
               P00AT6_A149TipCod, P00AT6_A243ComCod, P00AT6_A694ComDDsc, P00AT6_A254ComDProCod, P00AT6_n254ComDProCod, P00AT6_A707ComFReg, P00AT6_A697ComDOrdTip, P00AT6_A1158LinStk, P00AT6_A244PrvCod, P00AT6_A51SublCod,
               P00AT6_n51SublCod, P00AT6_A52LinCod, P00AT6_n52LinCod, P00AT6_A686ComDPre, P00AT6_A250ComDItem, P00AT6_A251ComDOrdCod
               }
               , new Object[] {
               P00AT7_A149TipCod, P00AT7_A243ComCod, P00AT7_A694ComDDsc, P00AT7_A253ComDCueCod, P00AT7_n253ComDCueCod, P00AT7_A707ComFReg, P00AT7_A697ComDOrdTip, P00AT7_A244PrvCod, P00AT7_A254ComDProCod, P00AT7_n254ComDProCod,
               P00AT7_A51SublCod, P00AT7_n51SublCod, P00AT7_A52LinCod, P00AT7_n52LinCod, P00AT7_A686ComDPre, P00AT7_A250ComDItem, P00AT7_A251ComDOrdCod
               }
               , new Object[] {
               P00AT8_A243ComCod, P00AT8_A707ComFReg, P00AT8_A254ComDProCod, P00AT8_n254ComDProCod, P00AT8_A244PrvCod, P00AT8_A51SublCod, P00AT8_n51SublCod, P00AT8_A52LinCod, P00AT8_n52LinCod, P00AT8_A149TipCod,
               P00AT8_A248ComFec, P00AT8_A704ComFecPago, P00AT8_A724ComRefFec, P00AT8_A511TipSigno, P00AT8_A246ComMon, P00AT8_A689ComDDct, P00AT8_A686ComDPre, P00AT8_A685ComDCant, P00AT8_A250ComDItem, P00AT8_A251ComDOrdCod
               }
               , new Object[] {
               P00AT9_A243ComCod, P00AT9_A254ComDProCod, P00AT9_n254ComDProCod, P00AT9_A707ComFReg, P00AT9_A697ComDOrdTip, P00AT9_A253ComDCueCod, P00AT9_n253ComDCueCod, P00AT9_A244PrvCod, P00AT9_A51SublCod, P00AT9_n51SublCod,
               P00AT9_A52LinCod, P00AT9_n52LinCod, P00AT9_A149TipCod, P00AT9_A248ComFec, P00AT9_A704ComFecPago, P00AT9_A724ComRefFec, P00AT9_A511TipSigno, P00AT9_A246ComMon, P00AT9_A689ComDDct, P00AT9_A686ComDPre,
               P00AT9_A685ComDCant, P00AT9_A250ComDItem, P00AT9_A251ComDOrdCod
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
      private short A1158LinStk ;
      private short A250ComDItem ;
      private short A511TipSigno ;
      private short AV46TipSigno ;
      private int AV28LinCod ;
      private int AV40SubLCod ;
      private int AV15DocMonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A180MonCod ;
      private int AV61GXV1 ;
      private int Gx_OldLine ;
      private int A246ComMon ;
      private int AV30MonCod ;
      private decimal AV48TotalGeneral ;
      private decimal AV10Cantidad ;
      private decimal AV49TotalVenta ;
      private decimal A686ComDPre ;
      private decimal AV47Total ;
      private decimal AV9Cant ;
      private decimal AV41TCantidad ;
      private decimal A689ComDDct ;
      private decimal A685ComDCant ;
      private decimal A688ComDSub ;
      private decimal A687ComDDescuento ;
      private decimal A684ComDTot ;
      private decimal AV8Cambio ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV33ProdCod ;
      private string AV35PrvCod ;
      private string AV45Tipo ;
      private string AV17Empresa ;
      private string AV16EmpDir ;
      private string AV18EmpRUC ;
      private string AV36Ruta ;
      private string AV23Filtro1 ;
      private string AV24Filtro2 ;
      private string AV25Filtro3 ;
      private string AV26Filtro4 ;
      private string scmdbuf ;
      private string A1153LinDsc ;
      private string A1892SublDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1234MonDsc ;
      private string AV27Filtro5 ;
      private string AV34ProdDsc ;
      private string A254ComDProCod ;
      private string A244PrvCod ;
      private string A149TipCod ;
      private string A243ComCod ;
      private string A694ComDDsc ;
      private string A251ComDOrdCod ;
      private string AV50Codigo ;
      private string A253ComDCueCod ;
      private string AV44TipCod2 ;
      private string GXt_char2 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV20FDesde ;
      private DateTime AV22FHasta ;
      private DateTime A707ComFReg ;
      private DateTime A248ComFec ;
      private DateTime A704ComFecPago ;
      private DateTime A724ComRefFec ;
      private DateTime AV21Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n52LinCod ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private bool BRKAT7 ;
      private bool n254ComDProCod ;
      private bool BRKAT9 ;
      private bool n253ComDCueCod ;
      private string AV53Logo_GXI ;
      private string A697ComDOrdTip ;
      private string AV29Logo ;
      private string Logo ;
      private IGxSession AV39Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private string aP2_ProdCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private int aP5_DocMonCod ;
      private string aP6_PrvCod ;
      private string aP7_Tipo ;
      private IDataStoreProvider pr_default ;
      private int[] P00AT2_A52LinCod ;
      private bool[] P00AT2_n52LinCod ;
      private string[] P00AT2_A1153LinDsc ;
      private int[] P00AT3_A51SublCod ;
      private bool[] P00AT3_n51SublCod ;
      private string[] P00AT3_A1892SublDsc ;
      private string[] P00AT4_A28ProdCod ;
      private string[] P00AT4_A55ProdDsc ;
      private int[] P00AT5_A180MonCod ;
      private string[] P00AT5_A1234MonDsc ;
      private string[] P00AT6_A149TipCod ;
      private string[] P00AT6_A243ComCod ;
      private string[] P00AT6_A694ComDDsc ;
      private string[] P00AT6_A254ComDProCod ;
      private bool[] P00AT6_n254ComDProCod ;
      private DateTime[] P00AT6_A707ComFReg ;
      private string[] P00AT6_A697ComDOrdTip ;
      private short[] P00AT6_A1158LinStk ;
      private string[] P00AT6_A244PrvCod ;
      private int[] P00AT6_A51SublCod ;
      private bool[] P00AT6_n51SublCod ;
      private int[] P00AT6_A52LinCod ;
      private bool[] P00AT6_n52LinCod ;
      private decimal[] P00AT6_A686ComDPre ;
      private short[] P00AT6_A250ComDItem ;
      private string[] P00AT6_A251ComDOrdCod ;
      private string[] P00AT7_A149TipCod ;
      private string[] P00AT7_A243ComCod ;
      private string[] P00AT7_A694ComDDsc ;
      private string[] P00AT7_A253ComDCueCod ;
      private bool[] P00AT7_n253ComDCueCod ;
      private DateTime[] P00AT7_A707ComFReg ;
      private string[] P00AT7_A697ComDOrdTip ;
      private string[] P00AT7_A244PrvCod ;
      private string[] P00AT7_A254ComDProCod ;
      private bool[] P00AT7_n254ComDProCod ;
      private int[] P00AT7_A51SublCod ;
      private bool[] P00AT7_n51SublCod ;
      private int[] P00AT7_A52LinCod ;
      private bool[] P00AT7_n52LinCod ;
      private decimal[] P00AT7_A686ComDPre ;
      private short[] P00AT7_A250ComDItem ;
      private string[] P00AT7_A251ComDOrdCod ;
      private string[] P00AT8_A243ComCod ;
      private DateTime[] P00AT8_A707ComFReg ;
      private string[] P00AT8_A254ComDProCod ;
      private bool[] P00AT8_n254ComDProCod ;
      private string[] P00AT8_A244PrvCod ;
      private int[] P00AT8_A51SublCod ;
      private bool[] P00AT8_n51SublCod ;
      private int[] P00AT8_A52LinCod ;
      private bool[] P00AT8_n52LinCod ;
      private string[] P00AT8_A149TipCod ;
      private DateTime[] P00AT8_A248ComFec ;
      private DateTime[] P00AT8_A704ComFecPago ;
      private DateTime[] P00AT8_A724ComRefFec ;
      private short[] P00AT8_A511TipSigno ;
      private int[] P00AT8_A246ComMon ;
      private decimal[] P00AT8_A689ComDDct ;
      private decimal[] P00AT8_A686ComDPre ;
      private decimal[] P00AT8_A685ComDCant ;
      private short[] P00AT8_A250ComDItem ;
      private string[] P00AT8_A251ComDOrdCod ;
      private string[] P00AT9_A243ComCod ;
      private string[] P00AT9_A254ComDProCod ;
      private bool[] P00AT9_n254ComDProCod ;
      private DateTime[] P00AT9_A707ComFReg ;
      private string[] P00AT9_A697ComDOrdTip ;
      private string[] P00AT9_A253ComDCueCod ;
      private bool[] P00AT9_n253ComDCueCod ;
      private string[] P00AT9_A244PrvCod ;
      private int[] P00AT9_A51SublCod ;
      private bool[] P00AT9_n51SublCod ;
      private int[] P00AT9_A52LinCod ;
      private bool[] P00AT9_n52LinCod ;
      private string[] P00AT9_A149TipCod ;
      private DateTime[] P00AT9_A248ComFec ;
      private DateTime[] P00AT9_A704ComFecPago ;
      private DateTime[] P00AT9_A724ComRefFec ;
      private short[] P00AT9_A511TipSigno ;
      private int[] P00AT9_A246ComMon ;
      private decimal[] P00AT9_A689ComDDct ;
      private decimal[] P00AT9_A686ComDPre ;
      private decimal[] P00AT9_A685ComDCant ;
      private short[] P00AT9_A250ComDItem ;
      private string[] P00AT9_A251ComDOrdCod ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV37SDTComprasProducto ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV38SDTComprasProductoITem ;
   }

   public class r_comprasproductospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AT6( IGxContext context ,
                                             int AV28LinCod ,
                                             int AV40SubLCod ,
                                             string AV33ProdCod ,
                                             string AV35PrvCod ,
                                             string AV45Tipo ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A254ComDProCod ,
                                             string A244PrvCod ,
                                             short A1158LinStk ,
                                             string A697ComDOrdTip ,
                                             DateTime A707ComFReg ,
                                             DateTime AV20FDesde ,
                                             DateTime AV22FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T1.[ComCod], T1.[ComDDsc], T1.[ComDProCod] AS ComDProCod, T4.[ComFReg], T1.[ComDOrdTip], T3.[LinStk], T1.[PrvCod], T2.[SublCod], T2.[LinCod], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ((([CPCOMPRASDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ComDProCod]) LEFT JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [CPCOMPRAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(T4.[ComFReg] >= @AV20FDesde and T4.[ComFReg] <= @AV22FHasta)");
         if ( ! (0==AV28LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV28LinCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV40SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV40SubLCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDProCod] = @AV33ProdCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV35PrvCod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV45Tipo, "P") == 0 )
         {
            AddWhere(sWhereString, "(T3.[LinStk] = 1 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         if ( StringUtil.StrCmp(AV45Tipo, "S") == 0 )
         {
            AddWhere(sWhereString, "(T3.[LinStk] = 0 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         if ( StringUtil.StrCmp(AV45Tipo, "G") == 0 )
         {
            AddWhere(sWhereString, "(T3.[LinStk] = 2 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         if ( StringUtil.StrCmp(AV45Tipo, "T") == 0 )
         {
            AddWhere(sWhereString, "(( Not (T1.[ComDProCod] = '') and Not (T1.[ComDOrdTip] = '')))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComDProCod], T1.[ComDDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00AT7( IGxContext context ,
                                             int AV28LinCod ,
                                             int AV40SubLCod ,
                                             string AV33ProdCod ,
                                             string AV35PrvCod ,
                                             string AV45Tipo ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A254ComDProCod ,
                                             string A244PrvCod ,
                                             string A253ComDCueCod ,
                                             string A697ComDOrdTip ,
                                             DateTime A707ComFReg ,
                                             DateTime AV20FDesde ,
                                             DateTime AV22FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[6];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T1.[ComCod], T1.[ComDDsc], T1.[ComDCueCod], T2.[ComFReg], T1.[ComDOrdTip], T1.[PrvCod], T1.[ComDProCod] AS ComDProCod, T3.[SublCod], T3.[LinCod], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM (([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) LEFT JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ComDProCod])";
         AddWhere(sWhereString, "(T2.[ComFReg] >= @AV20FDesde and T2.[ComFReg] <= @AV22FHasta)");
         if ( ! (0==AV28LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV28LinCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV40SubLCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV40SubLCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDProCod] = @AV33ProdCod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV35PrvCod)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV45Tipo, "T") == 0 )
         {
            AddWhere(sWhereString, "(( Not (T1.[ComDCueCod] = '') and Not T1.[ComDCueCod] IS NULL and (T1.[ComDOrdTip] = '')))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComDCueCod], T1.[ComDDsc]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00AT8( IGxContext context ,
                                             int AV28LinCod ,
                                             int AV40SubLCod ,
                                             string AV35PrvCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A244PrvCod ,
                                             DateTime A707ComFReg ,
                                             DateTime AV20FDesde ,
                                             DateTime AV22FHasta ,
                                             string AV50Codigo ,
                                             string A254ComDProCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[6];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[ComCod], T4.[ComFReg], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[SublCod], T2.[LinCod], T1.[TipCod], T4.[ComFec], T4.[ComFecPago], T4.[ComRefFec], T3.[TipSigno], T4.[ComMon], T1.[ComDDct], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem], T1.[ComDOrdCod] FROM ((([CPCOMPRASDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ComDProCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(T1.[ComDProCod] = @AV50Codigo)");
         AddWhere(sWhereString, "(T4.[ComFReg] >= @AV20FDesde and T4.[ComFReg] <= @AV22FHasta)");
         if ( ! (0==AV28LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV28LinCod)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (0==AV40SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV40SubLCod)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV35PrvCod)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComDProCod]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00AT9( IGxContext context ,
                                             int AV28LinCod ,
                                             int AV40SubLCod ,
                                             string AV35PrvCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A244PrvCod ,
                                             string A697ComDOrdTip ,
                                             DateTime A707ComFReg ,
                                             DateTime AV20FDesde ,
                                             DateTime AV22FHasta ,
                                             string AV50Codigo ,
                                             string A253ComDCueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[6];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.[ComCod], T1.[ComDProCod] AS ComDProCod, T4.[ComFReg], T1.[ComDOrdTip], T1.[ComDCueCod], T1.[PrvCod], T2.[SublCod], T2.[LinCod], T1.[TipCod], T4.[ComFec], T4.[ComFecPago], T4.[ComRefFec], T3.[TipSigno], T4.[ComMon], T1.[ComDDct], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem], T1.[ComDOrdCod] FROM ((([CPCOMPRASDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ComDProCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(T1.[ComDCueCod] = @AV50Codigo)");
         AddWhere(sWhereString, "((T1.[ComDOrdTip] = ''))");
         AddWhere(sWhereString, "(T4.[ComFReg] >= @AV20FDesde and T4.[ComFReg] <= @AV22FHasta)");
         if ( ! (0==AV28LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV28LinCod)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! (0==AV40SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV40SubLCod)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV35PrvCod)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComDCueCod]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 4 :
                     return conditional_P00AT6(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] );
               case 5 :
                     return conditional_P00AT7(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] );
               case 6 :
                     return conditional_P00AT8(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
               case 7 :
                     return conditional_P00AT9(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
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
          Object[] prmP00AT2;
          prmP00AT2 = new Object[] {
          new ParDef("@AV28LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00AT3;
          prmP00AT3 = new Object[] {
          new ParDef("@AV40SubLCod",GXType.Int32,6,0)
          };
          Object[] prmP00AT4;
          prmP00AT4 = new Object[] {
          new ParDef("@AV33ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00AT5;
          prmP00AT5 = new Object[] {
          new ParDef("@AV15DocMonCod",GXType.Int32,6,0)
          };
          Object[] prmP00AT6;
          prmP00AT6 = new Object[] {
          new ParDef("@AV20FDesde",GXType.Date,8,0) ,
          new ParDef("@AV22FHasta",GXType.Date,8,0) ,
          new ParDef("@AV28LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV40SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV33ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV35PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AT7;
          prmP00AT7 = new Object[] {
          new ParDef("@AV20FDesde",GXType.Date,8,0) ,
          new ParDef("@AV22FHasta",GXType.Date,8,0) ,
          new ParDef("@AV28LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV40SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV33ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV35PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AT8;
          prmP00AT8 = new Object[] {
          new ParDef("@AV50Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV20FDesde",GXType.Date,8,0) ,
          new ParDef("@AV22FHasta",GXType.Date,8,0) ,
          new ParDef("@AV28LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV40SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV35PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AT9;
          prmP00AT9 = new Object[] {
          new ParDef("@AV50Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV20FDesde",GXType.Date,8,0) ,
          new ParDef("@AV22FHasta",GXType.Date,8,0) ,
          new ParDef("@AV28LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV40SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV35PrvCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AT2", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV28LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AT3", "SELECT [SublCod], [SublDsc] FROM [CSUBLPROD] WHERE [SublCod] = @AV40SubLCod ORDER BY [SublCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AT4", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV33ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AT5", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV15DocMonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AT6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AT7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AT8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AT9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT9,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(11);
                ((short[]) buf[14])[0] = rslt.getShort(12);
                ((string[]) buf[15])[0] = rslt.getString(13, 10);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((string[]) buf[8])[0] = rslt.getString(8, 15);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((int[]) buf[12])[0] = rslt.getInt(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((short[]) buf[15])[0] = rslt.getShort(12);
                ((string[]) buf[16])[0] = rslt.getString(13, 10);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
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
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 20);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((int[]) buf[10])[0] = rslt.getInt(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((string[]) buf[12])[0] = rslt.getString(9, 3);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(11);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(12);
                ((short[]) buf[16])[0] = rslt.getShort(13);
                ((int[]) buf[17])[0] = rslt.getInt(14);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(17);
                ((short[]) buf[21])[0] = rslt.getShort(18);
                ((string[]) buf[22])[0] = rslt.getString(19, 10);
                return;
       }
    }

 }

}
