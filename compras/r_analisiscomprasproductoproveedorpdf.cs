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
   public class r_analisiscomprasproductoproveedorpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_analisiscomprasproductoproveedorpdf.aspx")), "compras.r_analisiscomprasproductoproveedorpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_analisiscomprasproductoproveedorpdf.aspx")))) ;
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
               AV39LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV61SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV53ProdCod = GetPar( "ProdCod");
                  AV31FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV33FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV26DocMonCod = (int)(NumberUtil.Val( GetPar( "DocMonCod"), "."));
                  AV55PrvCod = GetPar( "PrvCod");
                  AV66Tipo = GetPar( "Tipo");
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

      public r_analisiscomprasproductoproveedorpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_analisiscomprasproductoproveedorpdf( IGxContext context )
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
         this.AV39LinCod = aP0_LinCod;
         this.AV61SubLCod = aP1_SubLCod;
         this.AV53ProdCod = aP2_ProdCod;
         this.AV31FDesde = aP3_FDesde;
         this.AV33FHasta = aP4_FHasta;
         this.AV26DocMonCod = aP5_DocMonCod;
         this.AV55PrvCod = aP6_PrvCod;
         this.AV66Tipo = aP7_Tipo;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV39LinCod;
         aP1_SubLCod=this.AV61SubLCod;
         aP2_ProdCod=this.AV53ProdCod;
         aP3_FDesde=this.AV31FDesde;
         aP4_FHasta=this.AV33FHasta;
         aP5_DocMonCod=this.AV26DocMonCod;
         aP6_PrvCod=this.AV55PrvCod;
         aP7_Tipo=this.AV66Tipo;
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
         return AV66Tipo ;
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
         r_analisiscomprasproductoproveedorpdf objr_analisiscomprasproductoproveedorpdf;
         objr_analisiscomprasproductoproveedorpdf = new r_analisiscomprasproductoproveedorpdf();
         objr_analisiscomprasproductoproveedorpdf.AV39LinCod = aP0_LinCod;
         objr_analisiscomprasproductoproveedorpdf.AV61SubLCod = aP1_SubLCod;
         objr_analisiscomprasproductoproveedorpdf.AV53ProdCod = aP2_ProdCod;
         objr_analisiscomprasproductoproveedorpdf.AV31FDesde = aP3_FDesde;
         objr_analisiscomprasproductoproveedorpdf.AV33FHasta = aP4_FHasta;
         objr_analisiscomprasproductoproveedorpdf.AV26DocMonCod = aP5_DocMonCod;
         objr_analisiscomprasproductoproveedorpdf.AV55PrvCod = aP6_PrvCod;
         objr_analisiscomprasproductoproveedorpdf.AV66Tipo = aP7_Tipo;
         objr_analisiscomprasproductoproveedorpdf.context.SetSubmitInitialConfig(context);
         objr_analisiscomprasproductoproveedorpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_analisiscomprasproductoproveedorpdf);
         aP0_LinCod=this.AV39LinCod;
         aP1_SubLCod=this.AV61SubLCod;
         aP2_ProdCod=this.AV53ProdCod;
         aP3_FDesde=this.AV31FDesde;
         aP4_FHasta=this.AV33FHasta;
         aP5_DocMonCod=this.AV26DocMonCod;
         aP6_PrvCod=this.AV55PrvCod;
         aP7_Tipo=this.AV66Tipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_analisiscomprasproductoproveedorpdf)stateInfo).executePrivate();
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
            AV28Empresa = AV60Session.Get("Empresa");
            AV27EmpDir = AV60Session.Get("EmpDir");
            AV29EmpRUC = AV60Session.Get("EmpRUC");
            AV57Ruta = AV60Session.Get("RUTA") + "/Logo.jpg";
            AV40Logo = AV57Ruta;
            AV78Logo_GXI = GXDbFile.PathToUrl( AV57Ruta);
            AV34Filtro1 = "(Todos)";
            AV44MesActual = (short)(DateTimeUtil.Month( AV33FHasta));
            AV8AnoActual = (short)(DateTimeUtil.Year( AV33FHasta));
            AV45MesAnt1 = (short)(((AV44MesActual==1) ? 12 : AV44MesActual-1));
            AV9AnoAnt1 = (short)(((AV44MesActual==1) ? AV8AnoActual-1 : AV8AnoActual));
            AV46MesAnt2 = (short)(((AV45MesAnt1==1) ? 12 : AV45MesAnt1-1));
            AV10AnoAnt2 = (short)(((AV45MesAnt1==1) ? AV9AnoAnt1-1 : AV9AnoAnt1));
            AV47MesAnt3 = (short)(((AV46MesAnt2==1) ? 12 : AV46MesAnt2-1));
            AV11AnoAnt3 = (short)(((AV46MesAnt2==1) ? AV10AnoAnt2-1 : AV10AnoAnt2));
            GXt_char1 = AV20cMesAnt1;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV45MesAnt1, out  GXt_char1) ;
            AV20cMesAnt1 = GXt_char1 + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV9AnoAnt1), 10, 0));
            GXt_char1 = AV21cMesAnt2;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV46MesAnt2, out  GXt_char1) ;
            AV21cMesAnt2 = GXt_char1 + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV10AnoAnt2), 10, 0));
            GXt_char1 = AV22cMesAnt3;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV47MesAnt3, out  GXt_char1) ;
            AV22cMesAnt3 = GXt_char1 + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11AnoAnt3), 10, 0));
            /* Using cursor P00DH2 */
            pr_default.execute(0, new Object[] {AV53ProdCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A28ProdCod = P00DH2_A28ProdCod[0];
               A55ProdDsc = P00DH2_A55ProdDsc[0];
               AV34Filtro1 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00DH3 */
            pr_default.execute(1, new Object[] {AV26DocMonCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A180MonCod = P00DH3_A180MonCod[0];
               A1234MonDsc = P00DH3_A1234MonDsc[0];
               AV38Filtro5 = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV69TotalGeneral = 0.00m;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV39LinCod ,
                                                 AV61SubLCod ,
                                                 AV53ProdCod ,
                                                 AV55PrvCod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A254ComDProCod ,
                                                 A244PrvCod ,
                                                 A697ComDOrdTip ,
                                                 A707ComFReg ,
                                                 AV31FDesde ,
                                                 AV33FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00DH4 */
            pr_default.execute(2, new Object[] {AV31FDesde, AV33FHasta, AV39LinCod, AV61SubLCod, AV53ProdCod, AV55PrvCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               BRKDH5 = false;
               A149TipCod = P00DH4_A149TipCod[0];
               A243ComCod = P00DH4_A243ComCod[0];
               A247PrvDsc = P00DH4_A247PrvDsc[0];
               A244PrvCod = P00DH4_A244PrvCod[0];
               A707ComFReg = P00DH4_A707ComFReg[0];
               A697ComDOrdTip = P00DH4_A697ComDOrdTip[0];
               A254ComDProCod = P00DH4_A254ComDProCod[0];
               n254ComDProCod = P00DH4_n254ComDProCod[0];
               A51SublCod = P00DH4_A51SublCod[0];
               n51SublCod = P00DH4_n51SublCod[0];
               A52LinCod = P00DH4_A52LinCod[0];
               n52LinCod = P00DH4_n52LinCod[0];
               A686ComDPre = P00DH4_A686ComDPre[0];
               A250ComDItem = P00DH4_A250ComDItem[0];
               A251ComDOrdCod = P00DH4_A251ComDOrdCod[0];
               A247PrvDsc = P00DH4_A247PrvDsc[0];
               A707ComFReg = P00DH4_A707ComFReg[0];
               A51SublCod = P00DH4_A51SublCod[0];
               n51SublCod = P00DH4_n51SublCod[0];
               A52LinCod = P00DH4_A52LinCod[0];
               n52LinCod = P00DH4_n52LinCod[0];
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00DH4_A244PrvCod[0], A244PrvCod) == 0 ) )
               {
                  BRKDH5 = false;
                  A149TipCod = P00DH4_A149TipCod[0];
                  A243ComCod = P00DH4_A243ComCod[0];
                  A247PrvDsc = P00DH4_A247PrvDsc[0];
                  A250ComDItem = P00DH4_A250ComDItem[0];
                  A251ComDOrdCod = P00DH4_A251ComDOrdCod[0];
                  A247PrvDsc = P00DH4_A247PrvDsc[0];
                  BRKDH5 = true;
                  pr_default.readNext(2);
               }
               AV55PrvCod = A244PrvCod;
               AV56PrvDsc = A247PrvDsc;
               AV70TotalVenta = 0.00m;
               AV68Total = 0.00m;
               AV41Mes1 = 0.00m;
               AV42Mes2 = 0.00m;
               AV43Mes3 = 0.00m;
               AV15CantMes1 = 0.0000m;
               AV16CantMes2 = 0.0000m;
               AV17CantMes3 = 0.0000m;
               AV13Cant = 0.00m;
               AV14Cantidad = 0.00m;
               /* Execute user subroutine: 'PROVEEDORES' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               AV59SDTComprasProductoITem.gxTpr_Clicod = AV55PrvCod;
               AV59SDTComprasProductoITem.gxTpr_Clidsc = StringUtil.Trim( AV56PrvDsc);
               AV59SDTComprasProductoITem.gxTpr_Cantidad = AV14Cantidad;
               AV59SDTComprasProductoITem.gxTpr_Importe = AV70TotalVenta;
               AV59SDTComprasProductoITem.gxTpr_Mes1 = AV41Mes1;
               AV59SDTComprasProductoITem.gxTpr_Mes2 = AV42Mes2;
               AV59SDTComprasProductoITem.gxTpr_Mes3 = AV43Mes3;
               AV59SDTComprasProductoITem.gxTpr_Cantmes1 = AV15CantMes1;
               AV59SDTComprasProductoITem.gxTpr_Cantmes2 = AV16CantMes2;
               AV59SDTComprasProductoITem.gxTpr_Cantmes3 = AV17CantMes3;
               AV59SDTComprasProductoITem.gxTpr_Porcentaje = (decimal)(AV75LinStk);
               AV58SDTComprasProducto.Add(AV59SDTComprasProductoITem, 0);
               AV59SDTComprasProductoITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
               AV69TotalGeneral = (decimal)(AV69TotalGeneral+AV70TotalVenta);
               AV62TCantidad = (decimal)(AV62TCantidad+AV14Cantidad);
               if ( ! BRKDH5 )
               {
                  BRKDH5 = true;
                  pr_default.readNext(2);
               }
            }
            pr_default.close(2);
            AV58SDTComprasProducto.Sort("[Importe]");
            AV86GXV1 = 1;
            while ( AV86GXV1 <= AV58SDTComprasProducto.Count )
            {
               AV59SDTComprasProductoITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV58SDTComprasProducto.Item(AV86GXV1));
               AV55PrvCod = AV59SDTComprasProductoITem.gxTpr_Clicod;
               AV56PrvDsc = AV59SDTComprasProductoITem.gxTpr_Clidsc;
               AV14Cantidad = AV59SDTComprasProductoITem.gxTpr_Cantidad;
               AV70TotalVenta = AV59SDTComprasProductoITem.gxTpr_Importe;
               AV41Mes1 = AV59SDTComprasProductoITem.gxTpr_Mes1;
               AV42Mes2 = AV59SDTComprasProductoITem.gxTpr_Mes2;
               AV43Mes3 = AV59SDTComprasProductoITem.gxTpr_Mes3;
               AV15CantMes1 = AV59SDTComprasProductoITem.gxTpr_Cantmes1;
               AV16CantMes2 = AV59SDTComprasProductoITem.gxTpr_Cantmes2;
               AV17CantMes3 = AV59SDTComprasProductoITem.gxTpr_Cantmes3;
               AV75LinStk = (short)(AV59SDTComprasProductoITem.gxTpr_Porcentaje);
               AV72Precio1 = 0;
               AV73Precio2 = 0;
               AV74Precio3 = 0;
               AV18CantProm = 0;
               if ( AV75LinStk == 1 )
               {
                  AV72Precio1 = (!(Convert.ToDecimal(0)==AV15CantMes1) ? NumberUtil.Round( AV41Mes1/ (decimal)(AV15CantMes1), 4) : (decimal)(0));
                  AV73Precio2 = (!(Convert.ToDecimal(0)==AV16CantMes2) ? NumberUtil.Round( AV42Mes2/ (decimal)(AV16CantMes2), 4) : (decimal)(0));
                  AV74Precio3 = (!(Convert.ToDecimal(0)==AV17CantMes3) ? NumberUtil.Round( AV43Mes3/ (decimal)(AV17CantMes3), 4) : (decimal)(0));
                  AV18CantProm = (!(Convert.ToDecimal(0)==AV14Cantidad) ? NumberUtil.Round( AV70TotalVenta/ (decimal)(AV14Cantidad), 4) : (decimal)(0));
               }
               AV48MesProm = AV70TotalVenta;
               AV51Porcentaje = (!(Convert.ToDecimal(0)==AV69TotalGeneral) ? NumberUtil.Round( (AV70TotalVenta/ (decimal)(AV69TotalGeneral))*100, 4) : (decimal)(0));
               AV71TPorcentaje = (decimal)(AV71TPorcentaje+AV51Porcentaje);
               HDH0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55PrvCod, "@!")), 5, Gx_line+2, 104, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56PrvDsc, "")), 109, Gx_line+3, 425, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41Mes1, "ZZZZZZ,ZZZ,ZZ9.99")), 614, Gx_line+3, 738, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42Mes2, "ZZZZZZ,ZZZ,ZZ9.99")), 780, Gx_line+3, 904, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43Mes3, "ZZZZZZ,ZZZ,ZZ9.99")), 939, Gx_line+3, 1063, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51Porcentaje, "ZZ9.9999")), 425, Gx_line+2, 476, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48MesProm, "ZZZZZZ,ZZZ,ZZ9.99")), 444, Gx_line+3, 568, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18CantProm, "ZZZZ,ZZZ,ZZ9.9999")), 536, Gx_line+3, 660, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72Precio1, "ZZZZ,ZZZ,ZZ9.9999")), 703, Gx_line+3, 827, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74Precio3, "ZZZZ,ZZZ,ZZ9.9999")), 1024, Gx_line+3, 1148, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73Precio2, "ZZZZ,ZZZ,ZZ9.9999")), 869, Gx_line+3, 993, Gx_line+16, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV86GXV1 = (int)(AV86GXV1+1);
            }
            HDH0( false, 52) ;
            getPrinter().GxDrawLine(383, Gx_line+9, 572, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 325, Gx_line+17, 405, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69TotalGeneral, "ZZZZZZ,ZZZ,ZZ9.99")), 461, Gx_line+17, 568, Gx_line+32, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71TPorcentaje, "ZZ9.9999")), 425, Gx_line+17, 476, Gx_line+32, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HDH0( true, 0) ;
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
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV39LinCod ,
                                              AV61SubLCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A254ComDProCod ,
                                              A697ComDOrdTip ,
                                              A707ComFReg ,
                                              AV31FDesde ,
                                              AV33FHasta ,
                                              A244PrvCod ,
                                              AV55PrvCod ,
                                              AV53ProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00DH5 */
         pr_default.execute(3, new Object[] {AV53ProdCod, AV31FDesde, AV33FHasta, AV55PrvCod, AV39LinCod, AV61SubLCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A243ComCod = P00DH5_A243ComCod[0];
            A707ComFReg = P00DH5_A707ComFReg[0];
            A697ComDOrdTip = P00DH5_A697ComDOrdTip[0];
            A254ComDProCod = P00DH5_A254ComDProCod[0];
            n254ComDProCod = P00DH5_n254ComDProCod[0];
            A244PrvCod = P00DH5_A244PrvCod[0];
            A51SublCod = P00DH5_A51SublCod[0];
            n51SublCod = P00DH5_n51SublCod[0];
            A52LinCod = P00DH5_A52LinCod[0];
            n52LinCod = P00DH5_n52LinCod[0];
            A149TipCod = P00DH5_A149TipCod[0];
            A248ComFec = P00DH5_A248ComFec[0];
            A511TipSigno = P00DH5_A511TipSigno[0];
            A246ComMon = P00DH5_A246ComMon[0];
            A1158LinStk = P00DH5_A1158LinStk[0];
            A689ComDDct = P00DH5_A689ComDDct[0];
            A686ComDPre = P00DH5_A686ComDPre[0];
            A685ComDCant = P00DH5_A685ComDCant[0];
            A250ComDItem = P00DH5_A250ComDItem[0];
            A251ComDOrdCod = P00DH5_A251ComDOrdCod[0];
            A51SublCod = P00DH5_A51SublCod[0];
            n51SublCod = P00DH5_n51SublCod[0];
            A52LinCod = P00DH5_A52LinCod[0];
            n52LinCod = P00DH5_n52LinCod[0];
            A1158LinStk = P00DH5_A1158LinStk[0];
            A511TipSigno = P00DH5_A511TipSigno[0];
            A707ComFReg = P00DH5_A707ComFReg[0];
            A248ComFec = P00DH5_A248ComFec[0];
            A246ComMon = P00DH5_A246ComMon[0];
            A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
            A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
            A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
            AV65TipCod2 = A149TipCod;
            AV32Fecha = A248ComFec;
            AV67TipSigno = A511TipSigno;
            AV49MonCod = A246ComMon;
            AV68Total = NumberUtil.Round( NumberUtil.Round( A684ComDTot, 2)*A511TipSigno, 2);
            AV13Cant = NumberUtil.Round( A685ComDCant*A511TipSigno, 2);
            AV75LinStk = A1158LinStk;
            if ( AV26DocMonCod == 2 )
            {
               if ( AV49MonCod == 1 )
               {
                  GXt_decimal2 = AV12Cambio;
                  GXt_int3 = 2;
                  GXt_char1 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int3, ref  AV32Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                  AV12Cambio = GXt_decimal2;
                  AV68Total = NumberUtil.Round( AV68Total/ (decimal)(AV12Cambio), 2);
               }
            }
            else
            {
               if ( AV49MonCod == 2 )
               {
                  GXt_decimal2 = AV12Cambio;
                  GXt_int3 = 2;
                  GXt_char1 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int3, ref  AV32Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                  AV12Cambio = GXt_decimal2;
                  AV68Total = NumberUtil.Round( AV68Total*AV12Cambio, 2);
               }
            }
            if ( ( DateTimeUtil.Year( AV32Fecha) == AV9AnoAnt1 ) && ( DateTimeUtil.Month( AV32Fecha) == AV45MesAnt1 ) )
            {
               AV41Mes1 = (decimal)(AV41Mes1+AV68Total);
               AV15CantMes1 = (decimal)(AV15CantMes1+AV13Cant);
            }
            if ( ( DateTimeUtil.Year( AV32Fecha) == AV10AnoAnt2 ) && ( DateTimeUtil.Month( AV32Fecha) == AV46MesAnt2 ) )
            {
               AV42Mes2 = (decimal)(AV42Mes2+AV68Total);
               AV16CantMes2 = (decimal)(AV16CantMes2+AV13Cant);
            }
            if ( ( DateTimeUtil.Year( AV32Fecha) == AV11AnoAnt3 ) && ( DateTimeUtil.Month( AV32Fecha) == AV47MesAnt3 ) )
            {
               AV43Mes3 = (decimal)(AV43Mes3+AV68Total);
               AV17CantMes3 = (decimal)(AV17CantMes3+AV13Cant);
            }
            AV70TotalVenta = (decimal)(AV70TotalVenta+AV68Total);
            AV14Cantidad = (decimal)(AV14Cantidad+AV13Cant);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void HDH0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 1027, Gx_line+35, 1059, Gx_line+49, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 1027, Gx_line+55, 1071, Gx_line+69, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 1027, Gx_line+17, 1066, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Producto", 435, Gx_line+93, 497, Gx_line+107, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Filtro1, "")), 510, Gx_line+88, 853, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1072, Gx_line+17, 1119, Gx_line+32, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1057, Gx_line+35, 1117, Gx_line+49, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1080, Gx_line+55, 1119, Gx_line+70, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("RUC / Codigo", 14, Gx_line+132, 91, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 238, Gx_line+132, 300, Gx_line+146, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV40Logo)) ? AV78Logo_GXI : AV40Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+19, 176, Gx_line+97) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Analisis de Compras Producto / Proveedor", 421, Gx_line+12, 781, Gx_line+32, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Del :", 471, Gx_line+36, 512, Gx_line+56, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV31FDesde, "99/99/99"), 520, Gx_line+34, 594, Gx_line+58, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 596, Gx_line+36, 626, Gx_line+56, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV33FHasta, "99/99/99"), 630, Gx_line+34, 704, Gx_line+58, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Expresado en :", 439, Gx_line+59, 566, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38Filtro5, "")), 571, Gx_line+57, 760, Gx_line+81, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("%", 447, Gx_line+132, 462, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+120, 1147, Gx_line+158, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(662, Gx_line+120, 662, Gx_line+158, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(103, Gx_line+120, 103, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(428, Gx_line+120, 428, Gx_line+158, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(570, Gx_line+140, 570, Gx_line+158, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20cMesAnt1, "")), 705, Gx_line+122, 797, Gx_line+137, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Promedio de Compra", 514, Gx_line+122, 638, Gx_line+136, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 498, Gx_line+141, 548, Gx_line+155, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio", 598, Gx_line+141, 635, Gx_line+155, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(480, Gx_line+120, 480, Gx_line+158, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(480, Gx_line+140, 662, Gx_line+140, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(829, Gx_line+121, 829, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 679, Gx_line+141, 729, Gx_line+155, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio", 773, Gx_line+141, 810, Gx_line+155, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(661, Gx_line+140, 843, Gx_line+140, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(840, Gx_line+140, 1022, Gx_line+140, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio", 941, Gx_line+141, 978, Gx_line+155, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 847, Gx_line+141, 897, Gx_line+155, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21cMesAnt2, "")), 866, Gx_line+122, 958, Gx_line+137, 1, 0, 0, 1) ;
               getPrinter().GxDrawLine(964, Gx_line+140, 1146, Gx_line+140, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio", 1092, Gx_line+141, 1129, Gx_line+155, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 1010, Gx_line+141, 1060, Gx_line+155, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22cMesAnt3, "")), 1027, Gx_line+122, 1119, Gx_line+137, 1, 0, 0, 1) ;
               getPrinter().GxDrawLine(992, Gx_line+120, 992, Gx_line+158, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+158);
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
         AV28Empresa = "";
         AV60Session = context.GetSession();
         AV27EmpDir = "";
         AV29EmpRUC = "";
         AV57Ruta = "";
         AV40Logo = "";
         AV78Logo_GXI = "";
         AV34Filtro1 = "";
         AV20cMesAnt1 = "";
         AV21cMesAnt2 = "";
         AV22cMesAnt3 = "";
         scmdbuf = "";
         P00DH2_A28ProdCod = new string[] {""} ;
         P00DH2_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00DH3_A180MonCod = new int[1] ;
         P00DH3_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV38Filtro5 = "";
         A254ComDProCod = "";
         A244PrvCod = "";
         A697ComDOrdTip = "";
         A707ComFReg = DateTime.MinValue;
         P00DH4_A149TipCod = new string[] {""} ;
         P00DH4_A243ComCod = new string[] {""} ;
         P00DH4_A247PrvDsc = new string[] {""} ;
         P00DH4_A244PrvCod = new string[] {""} ;
         P00DH4_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00DH4_A697ComDOrdTip = new string[] {""} ;
         P00DH4_A254ComDProCod = new string[] {""} ;
         P00DH4_n254ComDProCod = new bool[] {false} ;
         P00DH4_A51SublCod = new int[1] ;
         P00DH4_n51SublCod = new bool[] {false} ;
         P00DH4_A52LinCod = new int[1] ;
         P00DH4_n52LinCod = new bool[] {false} ;
         P00DH4_A686ComDPre = new decimal[1] ;
         P00DH4_A250ComDItem = new short[1] ;
         P00DH4_A251ComDOrdCod = new string[] {""} ;
         A149TipCod = "";
         A243ComCod = "";
         A247PrvDsc = "";
         A251ComDOrdCod = "";
         AV56PrvDsc = "";
         AV59SDTComprasProductoITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV58SDTComprasProducto = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         P00DH5_A243ComCod = new string[] {""} ;
         P00DH5_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00DH5_A697ComDOrdTip = new string[] {""} ;
         P00DH5_A254ComDProCod = new string[] {""} ;
         P00DH5_n254ComDProCod = new bool[] {false} ;
         P00DH5_A244PrvCod = new string[] {""} ;
         P00DH5_A51SublCod = new int[1] ;
         P00DH5_n51SublCod = new bool[] {false} ;
         P00DH5_A52LinCod = new int[1] ;
         P00DH5_n52LinCod = new bool[] {false} ;
         P00DH5_A149TipCod = new string[] {""} ;
         P00DH5_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DH5_A511TipSigno = new short[1] ;
         P00DH5_A246ComMon = new int[1] ;
         P00DH5_A1158LinStk = new short[1] ;
         P00DH5_A689ComDDct = new decimal[1] ;
         P00DH5_A686ComDPre = new decimal[1] ;
         P00DH5_A685ComDCant = new decimal[1] ;
         P00DH5_A250ComDItem = new short[1] ;
         P00DH5_A251ComDOrdCod = new string[] {""} ;
         A248ComFec = DateTime.MinValue;
         AV65TipCod2 = "";
         AV32Fecha = DateTime.MinValue;
         GXt_char1 = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV40Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_analisiscomprasproductoproveedorpdf__default(),
            new Object[][] {
                new Object[] {
               P00DH2_A28ProdCod, P00DH2_A55ProdDsc
               }
               , new Object[] {
               P00DH3_A180MonCod, P00DH3_A1234MonDsc
               }
               , new Object[] {
               P00DH4_A149TipCod, P00DH4_A243ComCod, P00DH4_A247PrvDsc, P00DH4_A244PrvCod, P00DH4_A707ComFReg, P00DH4_A697ComDOrdTip, P00DH4_A254ComDProCod, P00DH4_n254ComDProCod, P00DH4_A51SublCod, P00DH4_n51SublCod,
               P00DH4_A52LinCod, P00DH4_n52LinCod, P00DH4_A686ComDPre, P00DH4_A250ComDItem, P00DH4_A251ComDOrdCod
               }
               , new Object[] {
               P00DH5_A243ComCod, P00DH5_A707ComFReg, P00DH5_A697ComDOrdTip, P00DH5_A254ComDProCod, P00DH5_n254ComDProCod, P00DH5_A244PrvCod, P00DH5_A51SublCod, P00DH5_n51SublCod, P00DH5_A52LinCod, P00DH5_n52LinCod,
               P00DH5_A149TipCod, P00DH5_A248ComFec, P00DH5_A511TipSigno, P00DH5_A246ComMon, P00DH5_A1158LinStk, P00DH5_A689ComDDct, P00DH5_A686ComDPre, P00DH5_A685ComDCant, P00DH5_A250ComDItem, P00DH5_A251ComDOrdCod
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
      private short AV44MesActual ;
      private short AV8AnoActual ;
      private short AV45MesAnt1 ;
      private short AV9AnoAnt1 ;
      private short AV46MesAnt2 ;
      private short AV10AnoAnt2 ;
      private short AV47MesAnt3 ;
      private short AV11AnoAnt3 ;
      private short A250ComDItem ;
      private short AV75LinStk ;
      private short A511TipSigno ;
      private short A1158LinStk ;
      private short AV67TipSigno ;
      private int AV39LinCod ;
      private int AV61SubLCod ;
      private int AV26DocMonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int AV86GXV1 ;
      private int Gx_OldLine ;
      private int A246ComMon ;
      private int AV49MonCod ;
      private int GXt_int3 ;
      private decimal AV69TotalGeneral ;
      private decimal A686ComDPre ;
      private decimal AV70TotalVenta ;
      private decimal AV68Total ;
      private decimal AV41Mes1 ;
      private decimal AV42Mes2 ;
      private decimal AV43Mes3 ;
      private decimal AV15CantMes1 ;
      private decimal AV16CantMes2 ;
      private decimal AV17CantMes3 ;
      private decimal AV13Cant ;
      private decimal AV14Cantidad ;
      private decimal AV62TCantidad ;
      private decimal AV72Precio1 ;
      private decimal AV73Precio2 ;
      private decimal AV74Precio3 ;
      private decimal AV18CantProm ;
      private decimal AV48MesProm ;
      private decimal AV51Porcentaje ;
      private decimal AV71TPorcentaje ;
      private decimal A689ComDDct ;
      private decimal A685ComDCant ;
      private decimal A688ComDSub ;
      private decimal A687ComDDescuento ;
      private decimal A684ComDTot ;
      private decimal AV12Cambio ;
      private decimal GXt_decimal2 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV53ProdCod ;
      private string AV55PrvCod ;
      private string AV66Tipo ;
      private string AV28Empresa ;
      private string AV27EmpDir ;
      private string AV29EmpRUC ;
      private string AV57Ruta ;
      private string AV34Filtro1 ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1234MonDsc ;
      private string AV38Filtro5 ;
      private string A254ComDProCod ;
      private string A244PrvCod ;
      private string A149TipCod ;
      private string A243ComCod ;
      private string A247PrvDsc ;
      private string A251ComDOrdCod ;
      private string AV56PrvDsc ;
      private string AV65TipCod2 ;
      private string GXt_char1 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV31FDesde ;
      private DateTime AV33FHasta ;
      private DateTime A707ComFReg ;
      private DateTime A248ComFec ;
      private DateTime AV32Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKDH5 ;
      private bool n254ComDProCod ;
      private bool n51SublCod ;
      private bool n52LinCod ;
      private bool returnInSub ;
      private string AV78Logo_GXI ;
      private string AV20cMesAnt1 ;
      private string AV21cMesAnt2 ;
      private string AV22cMesAnt3 ;
      private string A697ComDOrdTip ;
      private string AV40Logo ;
      private string Logo ;
      private IGxSession AV60Session ;
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
      private string[] P00DH2_A28ProdCod ;
      private string[] P00DH2_A55ProdDsc ;
      private int[] P00DH3_A180MonCod ;
      private string[] P00DH3_A1234MonDsc ;
      private string[] P00DH4_A149TipCod ;
      private string[] P00DH4_A243ComCod ;
      private string[] P00DH4_A247PrvDsc ;
      private string[] P00DH4_A244PrvCod ;
      private DateTime[] P00DH4_A707ComFReg ;
      private string[] P00DH4_A697ComDOrdTip ;
      private string[] P00DH4_A254ComDProCod ;
      private bool[] P00DH4_n254ComDProCod ;
      private int[] P00DH4_A51SublCod ;
      private bool[] P00DH4_n51SublCod ;
      private int[] P00DH4_A52LinCod ;
      private bool[] P00DH4_n52LinCod ;
      private decimal[] P00DH4_A686ComDPre ;
      private short[] P00DH4_A250ComDItem ;
      private string[] P00DH4_A251ComDOrdCod ;
      private string[] P00DH5_A243ComCod ;
      private DateTime[] P00DH5_A707ComFReg ;
      private string[] P00DH5_A697ComDOrdTip ;
      private string[] P00DH5_A254ComDProCod ;
      private bool[] P00DH5_n254ComDProCod ;
      private string[] P00DH5_A244PrvCod ;
      private int[] P00DH5_A51SublCod ;
      private bool[] P00DH5_n51SublCod ;
      private int[] P00DH5_A52LinCod ;
      private bool[] P00DH5_n52LinCod ;
      private string[] P00DH5_A149TipCod ;
      private DateTime[] P00DH5_A248ComFec ;
      private short[] P00DH5_A511TipSigno ;
      private int[] P00DH5_A246ComMon ;
      private short[] P00DH5_A1158LinStk ;
      private decimal[] P00DH5_A689ComDDct ;
      private decimal[] P00DH5_A686ComDPre ;
      private decimal[] P00DH5_A685ComDCant ;
      private short[] P00DH5_A250ComDItem ;
      private string[] P00DH5_A251ComDOrdCod ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV58SDTComprasProducto ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV59SDTComprasProductoITem ;
   }

   public class r_analisiscomprasproductoproveedorpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DH4( IGxContext context ,
                                             int AV39LinCod ,
                                             int AV61SubLCod ,
                                             string AV53ProdCod ,
                                             string AV55PrvCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A254ComDProCod ,
                                             string A244PrvCod ,
                                             string A697ComDOrdTip ,
                                             DateTime A707ComFReg ,
                                             DateTime AV31FDesde ,
                                             DateTime AV33FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T1.[ComCod], T2.[PrvDsc], T1.[PrvCod], T2.[ComFReg], T1.[ComDOrdTip], T1.[ComDProCod] AS ComDProCod, T3.[SublCod], T3.[LinCod], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM (([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) LEFT JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ComDProCod])";
         AddWhere(sWhereString, "(( Not (T1.[ComDProCod] = '') and Not (T1.[ComDOrdTip] = '')))");
         AddWhere(sWhereString, "(T2.[ComFReg] >= @AV31FDesde and T2.[ComFReg] <= @AV33FHasta)");
         if ( ! (0==AV39LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV39LinCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV61SubLCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV61SubLCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDProCod] = @AV53ProdCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV55PrvCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PrvCod], T2.[PrvDsc]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00DH5( IGxContext context ,
                                             int AV39LinCod ,
                                             int AV61SubLCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A254ComDProCod ,
                                             string A697ComDOrdTip ,
                                             DateTime A707ComFReg ,
                                             DateTime AV31FDesde ,
                                             DateTime AV33FHasta ,
                                             string A244PrvCod ,
                                             string AV55PrvCod ,
                                             string AV53ProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[6];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[ComCod], T5.[ComFReg], T1.[ComDOrdTip], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[SublCod], T2.[LinCod], T1.[TipCod], T5.[ComFec], T4.[TipSigno], T5.[ComMon], T3.[LinStk], T1.[ComDDct], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem], T1.[ComDOrdCod] FROM (((([CPCOMPRASDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ComDProCod]) LEFT JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [CTIPDOC] T4 ON T4.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T5 ON T5.[TipCod] = T1.[TipCod] AND T5.[ComCod] = T1.[ComCod] AND T5.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(T1.[ComDProCod] = @AV53ProdCod)");
         AddWhere(sWhereString, "(( Not (T1.[ComDProCod] = '') and Not (T1.[ComDOrdTip] = '')))");
         AddWhere(sWhereString, "(T5.[ComFReg] >= @AV31FDesde and T5.[ComFReg] <= @AV33FHasta)");
         AddWhere(sWhereString, "(T1.[PrvCod] = @AV55PrvCod)");
         if ( ! (0==AV39LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV39LinCod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (0==AV61SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV61SubLCod)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComDProCod]";
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
               case 2 :
                     return conditional_P00DH4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] );
               case 3 :
                     return conditional_P00DH5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
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
          Object[] prmP00DH2;
          prmP00DH2 = new Object[] {
          new ParDef("@AV53ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DH3;
          prmP00DH3 = new Object[] {
          new ParDef("@AV26DocMonCod",GXType.Int32,6,0)
          };
          Object[] prmP00DH4;
          prmP00DH4 = new Object[] {
          new ParDef("@AV31FDesde",GXType.Date,8,0) ,
          new ParDef("@AV33FHasta",GXType.Date,8,0) ,
          new ParDef("@AV39LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV61SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV53ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV55PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DH5;
          prmP00DH5 = new Object[] {
          new ParDef("@AV53ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV31FDesde",GXType.Date,8,0) ,
          new ParDef("@AV33FHasta",GXType.Date,8,0) ,
          new ParDef("@AV55PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV39LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV61SubLCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DH2", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV53ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DH2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DH3", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV26DocMonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DH3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DH4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DH4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DH5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DH5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(10);
                ((short[]) buf[13])[0] = rslt.getShort(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 10);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 3);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(9);
                ((short[]) buf[12])[0] = rslt.getShort(10);
                ((int[]) buf[13])[0] = rslt.getInt(11);
                ((short[]) buf[14])[0] = rslt.getShort(12);
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
