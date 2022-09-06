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
   public class r_analisiscomprasproductospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_analisiscomprasproductospdf.aspx")), "compras.r_analisiscomprasproductospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_analisiscomprasproductospdf.aspx")))) ;
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
                  AV60SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV53ProdCod = GetPar( "ProdCod");
                  AV31FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV33FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV26DocMonCod = (int)(NumberUtil.Val( GetPar( "DocMonCod"), "."));
                  AV55PrvCod = GetPar( "PrvCod");
                  AV65Tipo = GetPar( "Tipo");
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

      public r_analisiscomprasproductospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_analisiscomprasproductospdf( IGxContext context )
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
         this.AV60SubLCod = aP1_SubLCod;
         this.AV53ProdCod = aP2_ProdCod;
         this.AV31FDesde = aP3_FDesde;
         this.AV33FHasta = aP4_FHasta;
         this.AV26DocMonCod = aP5_DocMonCod;
         this.AV55PrvCod = aP6_PrvCod;
         this.AV65Tipo = aP7_Tipo;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV39LinCod;
         aP1_SubLCod=this.AV60SubLCod;
         aP2_ProdCod=this.AV53ProdCod;
         aP3_FDesde=this.AV31FDesde;
         aP4_FHasta=this.AV33FHasta;
         aP5_DocMonCod=this.AV26DocMonCod;
         aP6_PrvCod=this.AV55PrvCod;
         aP7_Tipo=this.AV65Tipo;
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
         return AV65Tipo ;
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
         r_analisiscomprasproductospdf objr_analisiscomprasproductospdf;
         objr_analisiscomprasproductospdf = new r_analisiscomprasproductospdf();
         objr_analisiscomprasproductospdf.AV39LinCod = aP0_LinCod;
         objr_analisiscomprasproductospdf.AV60SubLCod = aP1_SubLCod;
         objr_analisiscomprasproductospdf.AV53ProdCod = aP2_ProdCod;
         objr_analisiscomprasproductospdf.AV31FDesde = aP3_FDesde;
         objr_analisiscomprasproductospdf.AV33FHasta = aP4_FHasta;
         objr_analisiscomprasproductospdf.AV26DocMonCod = aP5_DocMonCod;
         objr_analisiscomprasproductospdf.AV55PrvCod = aP6_PrvCod;
         objr_analisiscomprasproductospdf.AV65Tipo = aP7_Tipo;
         objr_analisiscomprasproductospdf.context.SetSubmitInitialConfig(context);
         objr_analisiscomprasproductospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_analisiscomprasproductospdf);
         aP0_LinCod=this.AV39LinCod;
         aP1_SubLCod=this.AV60SubLCod;
         aP2_ProdCod=this.AV53ProdCod;
         aP3_FDesde=this.AV31FDesde;
         aP4_FHasta=this.AV33FHasta;
         aP5_DocMonCod=this.AV26DocMonCod;
         aP6_PrvCod=this.AV55PrvCod;
         aP7_Tipo=this.AV65Tipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_analisiscomprasproductospdf)stateInfo).executePrivate();
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
            AV28Empresa = AV59Session.Get("Empresa");
            AV27EmpDir = AV59Session.Get("EmpDir");
            AV29EmpRUC = AV59Session.Get("EmpRUC");
            AV56Ruta = AV59Session.Get("RUTA") + "/Logo.jpg";
            AV40Logo = AV56Ruta;
            AV75Logo_GXI = GXDbFile.PathToUrl( AV56Ruta);
            AV34Filtro1 = "(Todos)";
            AV35Filtro2 = "(Todos)";
            AV36Filtro3 = ((StringUtil.StrCmp(AV65Tipo, "P")==0) ? "Productos" : ((StringUtil.StrCmp(AV65Tipo, "S")==0) ? "Servicio" : ((StringUtil.StrCmp(AV65Tipo, "G")==0) ? "Gastos" : "(Todos)")));
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
            /* Using cursor P00DG2 */
            pr_default.execute(0, new Object[] {AV55PrvCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A244PrvCod = P00DG2_A244PrvCod[0];
               A247PrvDsc = P00DG2_A247PrvDsc[0];
               AV34Filtro1 = StringUtil.Trim( A247PrvDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00DG3 */
            pr_default.execute(1, new Object[] {AV53ProdCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = P00DG3_A28ProdCod[0];
               A55ProdDsc = P00DG3_A55ProdDsc[0];
               AV35Filtro2 = StringUtil.Trim( A55ProdDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00DG4 */
            pr_default.execute(2, new Object[] {AV26DocMonCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A180MonCod = P00DG4_A180MonCod[0];
               A1234MonDsc = P00DG4_A1234MonDsc[0];
               AV38Filtro5 = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV68TotalGeneral = 0.00m;
            /* Execute user subroutine: 'PRODUCTOS' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            if ( ( StringUtil.StrCmp(AV65Tipo, "G") == 0 ) || ( StringUtil.StrCmp(AV65Tipo, "T") == 0 ) )
            {
               /* Execute user subroutine: 'GASTOS' */
               S131 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            AV57SDTComprasProducto.Sort("[Importe]");
            AV82GXV1 = 1;
            while ( AV82GXV1 <= AV57SDTComprasProducto.Count )
            {
               AV58SDTComprasProductoITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV57SDTComprasProducto.Item(AV82GXV1));
               AV53ProdCod = AV58SDTComprasProductoITem.gxTpr_Clicod;
               AV54ProdDsc = AV58SDTComprasProductoITem.gxTpr_Clidsc;
               AV14Cantidad = AV58SDTComprasProductoITem.gxTpr_Cantidad;
               AV69TotalVenta = AV58SDTComprasProductoITem.gxTpr_Importe;
               AV41Mes1 = AV58SDTComprasProductoITem.gxTpr_Mes1;
               AV42Mes2 = AV58SDTComprasProductoITem.gxTpr_Mes2;
               AV43Mes3 = AV58SDTComprasProductoITem.gxTpr_Mes3;
               AV15CantMes1 = AV58SDTComprasProductoITem.gxTpr_Cantmes1;
               AV16CantMes2 = AV58SDTComprasProductoITem.gxTpr_Cantmes2;
               AV17CantMes3 = AV58SDTComprasProductoITem.gxTpr_Cantmes3;
               AV48MesProm = NumberUtil.Round( (AV41Mes1+AV42Mes2+AV43Mes3)/ (decimal)(3), 2);
               AV18CantProm = NumberUtil.Round( (AV15CantMes1+AV16CantMes2+AV17CantMes3)/ (decimal)(3), 2);
               AV51Porcentaje = (!(Convert.ToDecimal(0)==AV68TotalGeneral) ? NumberUtil.Round( (AV69TotalVenta/ (decimal)(AV68TotalGeneral))*100, 4) : (decimal)(0));
               AV70TPorcentaje = (decimal)(100);
               HDG0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53ProdCod, "@!")), 5, Gx_line+2, 104, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54ProdDsc, "")), 109, Gx_line+4, 418, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69TotalVenta, "ZZZZZZ,ZZZ,ZZ9.99")), 518, Gx_line+3, 642, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV14Cantidad, "ZZZZ,ZZZ,ZZ9.9999")), 444, Gx_line+2, 551, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41Mes1, "ZZZZZZ,ZZZ,ZZ9.99")), 816, Gx_line+3, 940, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42Mes2, "ZZZZZZ,ZZZ,ZZ9.99")), 923, Gx_line+3, 1047, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43Mes3, "ZZZZZZ,ZZZ,ZZ9.99")), 1017, Gx_line+3, 1141, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51Porcentaje, "ZZ9.9999")), 420, Gx_line+2, 471, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48MesProm, "ZZZZZZ,ZZZ,ZZ9.99")), 710, Gx_line+3, 834, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18CantProm, "ZZZZ,ZZZ,ZZ9.9999")), 618, Gx_line+3, 742, Gx_line+16, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV82GXV1 = (int)(AV82GXV1+1);
            }
            HDG0( false, 52) ;
            getPrinter().GxDrawLine(383, Gx_line+9, 658, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 325, Gx_line+17, 405, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68TotalGeneral, "ZZZZZZ,ZZZ,ZZ9.99")), 535, Gx_line+16, 642, Gx_line+31, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70TPorcentaje, "ZZ9.9999")), 420, Gx_line+16, 471, Gx_line+31, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61TCantidad, "ZZZZ,ZZZ,ZZ9.9999")), 444, Gx_line+16, 551, Gx_line+31, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HDG0( true, 0) ;
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
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV39LinCod ,
                                              AV60SubLCod ,
                                              AV53ProdCod ,
                                              AV55PrvCod ,
                                              AV65Tipo ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A254ComDProCod ,
                                              A244PrvCod ,
                                              A1158LinStk ,
                                              A697ComDOrdTip ,
                                              A707ComFReg ,
                                              AV31FDesde ,
                                              AV33FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE
                                              }
         });
         /* Using cursor P00DG5 */
         pr_default.execute(3, new Object[] {AV31FDesde, AV33FHasta, AV39LinCod, AV60SubLCod, AV53ProdCod, AV55PrvCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKDG6 = false;
            A149TipCod = P00DG5_A149TipCod[0];
            A243ComCod = P00DG5_A243ComCod[0];
            A694ComDDsc = P00DG5_A694ComDDsc[0];
            A254ComDProCod = P00DG5_A254ComDProCod[0];
            n254ComDProCod = P00DG5_n254ComDProCod[0];
            A707ComFReg = P00DG5_A707ComFReg[0];
            A697ComDOrdTip = P00DG5_A697ComDOrdTip[0];
            A1158LinStk = P00DG5_A1158LinStk[0];
            A244PrvCod = P00DG5_A244PrvCod[0];
            A51SublCod = P00DG5_A51SublCod[0];
            n51SublCod = P00DG5_n51SublCod[0];
            A52LinCod = P00DG5_A52LinCod[0];
            n52LinCod = P00DG5_n52LinCod[0];
            A686ComDPre = P00DG5_A686ComDPre[0];
            A250ComDItem = P00DG5_A250ComDItem[0];
            A251ComDOrdCod = P00DG5_A251ComDOrdCod[0];
            A51SublCod = P00DG5_A51SublCod[0];
            n51SublCod = P00DG5_n51SublCod[0];
            A52LinCod = P00DG5_A52LinCod[0];
            n52LinCod = P00DG5_n52LinCod[0];
            A1158LinStk = P00DG5_A1158LinStk[0];
            A707ComFReg = P00DG5_A707ComFReg[0];
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00DG5_A254ComDProCod[0], A254ComDProCod) == 0 ) )
            {
               BRKDG6 = false;
               A149TipCod = P00DG5_A149TipCod[0];
               A243ComCod = P00DG5_A243ComCod[0];
               A694ComDDsc = P00DG5_A694ComDDsc[0];
               A244PrvCod = P00DG5_A244PrvCod[0];
               A250ComDItem = P00DG5_A250ComDItem[0];
               A251ComDOrdCod = P00DG5_A251ComDOrdCod[0];
               BRKDG6 = true;
               pr_default.readNext(3);
            }
            AV72Codigo = A254ComDProCod;
            AV54ProdDsc = A694ComDDsc;
            AV69TotalVenta = 0.00m;
            AV67Total = 0.00m;
            AV41Mes1 = 0.00m;
            AV42Mes2 = 0.00m;
            AV43Mes3 = 0.00m;
            AV15CantMes1 = 0.0000m;
            AV16CantMes2 = 0.0000m;
            AV17CantMes3 = 0.0000m;
            AV13Cant = 0.00m;
            AV14Cantidad = 0.00m;
            /* Execute user subroutine: 'DETALLEPRODUCTOS' */
            S126 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV58SDTComprasProductoITem.gxTpr_Clicod = AV72Codigo;
            AV58SDTComprasProductoITem.gxTpr_Clidsc = AV54ProdDsc;
            AV58SDTComprasProductoITem.gxTpr_Cantidad = AV14Cantidad;
            AV58SDTComprasProductoITem.gxTpr_Importe = AV69TotalVenta;
            AV58SDTComprasProductoITem.gxTpr_Mes1 = AV41Mes1;
            AV58SDTComprasProductoITem.gxTpr_Mes2 = AV42Mes2;
            AV58SDTComprasProductoITem.gxTpr_Mes3 = AV43Mes3;
            AV58SDTComprasProductoITem.gxTpr_Cantmes1 = AV15CantMes1;
            AV58SDTComprasProductoITem.gxTpr_Cantmes2 = AV16CantMes2;
            AV58SDTComprasProductoITem.gxTpr_Cantmes3 = AV17CantMes3;
            AV57SDTComprasProducto.Add(AV58SDTComprasProductoITem, 0);
            AV58SDTComprasProductoITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
            AV68TotalGeneral = (decimal)(AV68TotalGeneral+AV69TotalVenta);
            AV61TCantidad = (decimal)(AV61TCantidad+AV14Cantidad);
            if ( ! BRKDG6 )
            {
               BRKDG6 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S131( )
      {
         /* 'GASTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV39LinCod ,
                                              AV60SubLCod ,
                                              AV53ProdCod ,
                                              AV55PrvCod ,
                                              AV65Tipo ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A254ComDProCod ,
                                              A244PrvCod ,
                                              A253ComDCueCod ,
                                              A697ComDOrdTip ,
                                              A707ComFReg ,
                                              AV31FDesde ,
                                              AV33FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE
                                              }
         });
         /* Using cursor P00DG6 */
         pr_default.execute(4, new Object[] {AV31FDesde, AV33FHasta, AV39LinCod, AV60SubLCod, AV53ProdCod, AV55PrvCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKDG8 = false;
            A149TipCod = P00DG6_A149TipCod[0];
            A243ComCod = P00DG6_A243ComCod[0];
            A694ComDDsc = P00DG6_A694ComDDsc[0];
            A253ComDCueCod = P00DG6_A253ComDCueCod[0];
            n253ComDCueCod = P00DG6_n253ComDCueCod[0];
            A707ComFReg = P00DG6_A707ComFReg[0];
            A697ComDOrdTip = P00DG6_A697ComDOrdTip[0];
            A244PrvCod = P00DG6_A244PrvCod[0];
            A254ComDProCod = P00DG6_A254ComDProCod[0];
            n254ComDProCod = P00DG6_n254ComDProCod[0];
            A51SublCod = P00DG6_A51SublCod[0];
            n51SublCod = P00DG6_n51SublCod[0];
            A52LinCod = P00DG6_A52LinCod[0];
            n52LinCod = P00DG6_n52LinCod[0];
            A686ComDPre = P00DG6_A686ComDPre[0];
            A250ComDItem = P00DG6_A250ComDItem[0];
            A251ComDOrdCod = P00DG6_A251ComDOrdCod[0];
            A707ComFReg = P00DG6_A707ComFReg[0];
            A51SublCod = P00DG6_A51SublCod[0];
            n51SublCod = P00DG6_n51SublCod[0];
            A52LinCod = P00DG6_A52LinCod[0];
            n52LinCod = P00DG6_n52LinCod[0];
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00DG6_A253ComDCueCod[0], A253ComDCueCod) == 0 ) )
            {
               BRKDG8 = false;
               A149TipCod = P00DG6_A149TipCod[0];
               A243ComCod = P00DG6_A243ComCod[0];
               A694ComDDsc = P00DG6_A694ComDDsc[0];
               A244PrvCod = P00DG6_A244PrvCod[0];
               A250ComDItem = P00DG6_A250ComDItem[0];
               A251ComDOrdCod = P00DG6_A251ComDOrdCod[0];
               BRKDG8 = true;
               pr_default.readNext(4);
            }
            AV72Codigo = A253ComDCueCod;
            AV54ProdDsc = A694ComDDsc;
            AV69TotalVenta = 0.00m;
            AV67Total = 0.00m;
            AV41Mes1 = 0.00m;
            AV42Mes2 = 0.00m;
            AV43Mes3 = 0.00m;
            AV15CantMes1 = 0.0000m;
            AV16CantMes2 = 0.0000m;
            AV17CantMes3 = 0.0000m;
            AV13Cant = 0.00m;
            AV14Cantidad = 0.00m;
            /* Execute user subroutine: 'DETALLEGASTOS' */
            S148 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            AV58SDTComprasProductoITem.gxTpr_Clicod = AV72Codigo;
            AV58SDTComprasProductoITem.gxTpr_Clidsc = AV54ProdDsc;
            AV58SDTComprasProductoITem.gxTpr_Cantidad = AV14Cantidad;
            AV58SDTComprasProductoITem.gxTpr_Importe = AV69TotalVenta;
            AV58SDTComprasProductoITem.gxTpr_Mes1 = AV41Mes1;
            AV58SDTComprasProductoITem.gxTpr_Mes2 = AV42Mes2;
            AV58SDTComprasProductoITem.gxTpr_Mes3 = AV43Mes3;
            AV58SDTComprasProductoITem.gxTpr_Cantmes1 = AV15CantMes1;
            AV58SDTComprasProductoITem.gxTpr_Cantmes2 = AV16CantMes2;
            AV58SDTComprasProductoITem.gxTpr_Cantmes3 = AV17CantMes3;
            AV57SDTComprasProducto.Add(AV58SDTComprasProductoITem, 0);
            AV58SDTComprasProductoITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
            AV68TotalGeneral = (decimal)(AV68TotalGeneral+AV69TotalVenta);
            AV61TCantidad = (decimal)(AV61TCantidad+AV14Cantidad);
            if ( ! BRKDG8 )
            {
               BRKDG8 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S126( )
      {
         /* 'DETALLEPRODUCTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV39LinCod ,
                                              AV60SubLCod ,
                                              AV55PrvCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A244PrvCod ,
                                              A707ComFReg ,
                                              AV31FDesde ,
                                              AV33FHasta ,
                                              AV72Codigo ,
                                              A254ComDProCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00DG7 */
         pr_default.execute(5, new Object[] {AV72Codigo, AV31FDesde, AV33FHasta, AV39LinCod, AV60SubLCod, AV55PrvCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A243ComCod = P00DG7_A243ComCod[0];
            A707ComFReg = P00DG7_A707ComFReg[0];
            A254ComDProCod = P00DG7_A254ComDProCod[0];
            n254ComDProCod = P00DG7_n254ComDProCod[0];
            A244PrvCod = P00DG7_A244PrvCod[0];
            A51SublCod = P00DG7_A51SublCod[0];
            n51SublCod = P00DG7_n51SublCod[0];
            A52LinCod = P00DG7_A52LinCod[0];
            n52LinCod = P00DG7_n52LinCod[0];
            A149TipCod = P00DG7_A149TipCod[0];
            A248ComFec = P00DG7_A248ComFec[0];
            A704ComFecPago = P00DG7_A704ComFecPago[0];
            A724ComRefFec = P00DG7_A724ComRefFec[0];
            A511TipSigno = P00DG7_A511TipSigno[0];
            A246ComMon = P00DG7_A246ComMon[0];
            A689ComDDct = P00DG7_A689ComDDct[0];
            A686ComDPre = P00DG7_A686ComDPre[0];
            A685ComDCant = P00DG7_A685ComDCant[0];
            A250ComDItem = P00DG7_A250ComDItem[0];
            A251ComDOrdCod = P00DG7_A251ComDOrdCod[0];
            A51SublCod = P00DG7_A51SublCod[0];
            n51SublCod = P00DG7_n51SublCod[0];
            A52LinCod = P00DG7_A52LinCod[0];
            n52LinCod = P00DG7_n52LinCod[0];
            A511TipSigno = P00DG7_A511TipSigno[0];
            A707ComFReg = P00DG7_A707ComFReg[0];
            A248ComFec = P00DG7_A248ComFec[0];
            A704ComFecPago = P00DG7_A704ComFecPago[0];
            A724ComRefFec = P00DG7_A724ComRefFec[0];
            A246ComMon = P00DG7_A246ComMon[0];
            A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
            A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
            A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
            AV64TipCod2 = A149TipCod;
            AV32Fecha = (((StringUtil.StrCmp(AV64TipCod2, "NC")==0)||(StringUtil.StrCmp(AV64TipCod2, "ND")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : ((DateTime.MinValue==A704ComFecPago) ? A248ComFec : A704ComFecPago));
            AV66TipSigno = A511TipSigno;
            AV49MonCod = A246ComMon;
            AV67Total = NumberUtil.Round( NumberUtil.Round( A684ComDTot, 2)*A511TipSigno, 2);
            AV13Cant = NumberUtil.Round( A685ComDCant*A511TipSigno, 2);
            if ( AV26DocMonCod == 2 )
            {
               if ( AV49MonCod == 1 )
               {
                  GXt_decimal2 = AV12Cambio;
                  GXt_int3 = 2;
                  GXt_char1 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int3, ref  AV32Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                  AV12Cambio = GXt_decimal2;
                  AV67Total = NumberUtil.Round( AV67Total/ (decimal)(AV12Cambio), 2);
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
                  AV67Total = NumberUtil.Round( AV67Total*AV12Cambio, 2);
               }
            }
            if ( ( DateTimeUtil.Year( AV32Fecha) == AV9AnoAnt1 ) && ( DateTimeUtil.Month( AV32Fecha) == AV45MesAnt1 ) )
            {
               AV41Mes1 = (decimal)(AV41Mes1+AV67Total);
               AV15CantMes1 = (decimal)(AV15CantMes1+AV13Cant);
            }
            if ( ( DateTimeUtil.Year( AV32Fecha) == AV10AnoAnt2 ) && ( DateTimeUtil.Month( AV32Fecha) == AV46MesAnt2 ) )
            {
               AV42Mes2 = (decimal)(AV42Mes2+AV67Total);
               AV16CantMes2 = (decimal)(AV16CantMes2+AV13Cant);
            }
            if ( ( DateTimeUtil.Year( AV32Fecha) == AV11AnoAnt3 ) && ( DateTimeUtil.Month( AV32Fecha) == AV47MesAnt3 ) )
            {
               AV43Mes3 = (decimal)(AV43Mes3+AV67Total);
               AV17CantMes3 = (decimal)(AV17CantMes3+AV13Cant);
            }
            AV69TotalVenta = (decimal)(AV69TotalVenta+AV67Total);
            AV14Cantidad = (decimal)(AV14Cantidad+AV13Cant);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S148( )
      {
         /* 'DETALLEGASTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV39LinCod ,
                                              AV60SubLCod ,
                                              AV55PrvCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A244PrvCod ,
                                              A697ComDOrdTip ,
                                              A707ComFReg ,
                                              AV31FDesde ,
                                              AV33FHasta ,
                                              AV72Codigo ,
                                              A253ComDCueCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00DG8 */
         pr_default.execute(6, new Object[] {AV72Codigo, AV31FDesde, AV33FHasta, AV39LinCod, AV60SubLCod, AV55PrvCod});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A243ComCod = P00DG8_A243ComCod[0];
            A254ComDProCod = P00DG8_A254ComDProCod[0];
            n254ComDProCod = P00DG8_n254ComDProCod[0];
            A707ComFReg = P00DG8_A707ComFReg[0];
            A697ComDOrdTip = P00DG8_A697ComDOrdTip[0];
            A253ComDCueCod = P00DG8_A253ComDCueCod[0];
            n253ComDCueCod = P00DG8_n253ComDCueCod[0];
            A244PrvCod = P00DG8_A244PrvCod[0];
            A51SublCod = P00DG8_A51SublCod[0];
            n51SublCod = P00DG8_n51SublCod[0];
            A52LinCod = P00DG8_A52LinCod[0];
            n52LinCod = P00DG8_n52LinCod[0];
            A149TipCod = P00DG8_A149TipCod[0];
            A248ComFec = P00DG8_A248ComFec[0];
            A704ComFecPago = P00DG8_A704ComFecPago[0];
            A724ComRefFec = P00DG8_A724ComRefFec[0];
            A511TipSigno = P00DG8_A511TipSigno[0];
            A246ComMon = P00DG8_A246ComMon[0];
            A689ComDDct = P00DG8_A689ComDDct[0];
            A686ComDPre = P00DG8_A686ComDPre[0];
            A685ComDCant = P00DG8_A685ComDCant[0];
            A250ComDItem = P00DG8_A250ComDItem[0];
            A251ComDOrdCod = P00DG8_A251ComDOrdCod[0];
            A51SublCod = P00DG8_A51SublCod[0];
            n51SublCod = P00DG8_n51SublCod[0];
            A52LinCod = P00DG8_A52LinCod[0];
            n52LinCod = P00DG8_n52LinCod[0];
            A511TipSigno = P00DG8_A511TipSigno[0];
            A707ComFReg = P00DG8_A707ComFReg[0];
            A248ComFec = P00DG8_A248ComFec[0];
            A704ComFecPago = P00DG8_A704ComFecPago[0];
            A724ComRefFec = P00DG8_A724ComRefFec[0];
            A246ComMon = P00DG8_A246ComMon[0];
            A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
            A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
            A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
            AV64TipCod2 = A149TipCod;
            AV32Fecha = (((StringUtil.StrCmp(AV64TipCod2, "NC")==0)||(StringUtil.StrCmp(AV64TipCod2, "ND")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : ((DateTime.MinValue==A704ComFecPago) ? A248ComFec : A704ComFecPago));
            AV66TipSigno = A511TipSigno;
            AV49MonCod = A246ComMon;
            AV67Total = NumberUtil.Round( NumberUtil.Round( A684ComDTot, 2)*A511TipSigno, 2);
            AV13Cant = NumberUtil.Round( A685ComDCant*A511TipSigno, 2);
            if ( AV26DocMonCod == 2 )
            {
               if ( AV49MonCod == 1 )
               {
                  GXt_decimal2 = AV12Cambio;
                  GXt_int3 = 2;
                  GXt_char1 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int3, ref  AV32Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                  AV12Cambio = GXt_decimal2;
                  AV67Total = NumberUtil.Round( AV67Total/ (decimal)(AV12Cambio), 2);
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
                  AV67Total = NumberUtil.Round( AV67Total*AV12Cambio, 2);
               }
            }
            if ( ( DateTimeUtil.Year( AV32Fecha) == AV9AnoAnt1 ) && ( DateTimeUtil.Month( AV32Fecha) == AV45MesAnt1 ) )
            {
               AV41Mes1 = (decimal)(AV41Mes1+AV67Total);
               AV15CantMes1 = (decimal)(AV15CantMes1+AV13Cant);
            }
            if ( ( DateTimeUtil.Year( AV32Fecha) == AV10AnoAnt2 ) && ( DateTimeUtil.Month( AV32Fecha) == AV46MesAnt2 ) )
            {
               AV42Mes2 = (decimal)(AV42Mes2+AV67Total);
               AV16CantMes2 = (decimal)(AV16CantMes2+AV13Cant);
            }
            if ( ( DateTimeUtil.Year( AV32Fecha) == AV11AnoAnt3 ) && ( DateTimeUtil.Month( AV32Fecha) == AV47MesAnt3 ) )
            {
               AV43Mes3 = (decimal)(AV43Mes3+AV67Total);
               AV17CantMes3 = (decimal)(AV17CantMes3+AV13Cant);
            }
            AV69TotalVenta = (decimal)(AV69TotalVenta+AV67Total);
            AV14Cantidad = (decimal)(AV14Cantidad+AV13Cant);
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void HDG0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 1013, Gx_line+35, 1045, Gx_line+49, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 1013, Gx_line+55, 1057, Gx_line+69, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 1013, Gx_line+17, 1052, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Proveedor", 426, Gx_line+94, 494, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Productos", 425, Gx_line+116, 494, Gx_line+130, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Filtro1, "")), 510, Gx_line+88, 853, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Filtro2, "")), 510, Gx_line+110, 853, Gx_line+134, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1057, Gx_line+17, 1104, Gx_line+32, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1043, Gx_line+35, 1103, Gx_line+49, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1066, Gx_line+55, 1105, Gx_line+70, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 35, Gx_line+171, 76, Gx_line+185, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Compra", 564, Gx_line+171, 644, Gx_line+185, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Productos", 238, Gx_line+171, 298, Gx_line+185, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 486, Gx_line+171, 539, Gx_line+185, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV40Logo)) ? AV75Logo_GXI : AV40Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+19, 176, Gx_line+97) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Analisis de Compras por Productos", 453, Gx_line+12, 748, Gx_line+32, 0, 0, 0, 0) ;
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
               getPrinter().GxDrawText("%", 447, Gx_line+171, 462, Gx_line+185, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1046, Gx_line+158, 1046, Gx_line+194, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+158, 1147, Gx_line+196, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(941, Gx_line+159, 941, Gx_line+195, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(836, Gx_line+158, 836, Gx_line+196, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(103, Gx_line+159, 103, Gx_line+194, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(428, Gx_line+158, 428, Gx_line+196, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(475, Gx_line+158, 475, Gx_line+196, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(553, Gx_line+158, 553, Gx_line+194, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(744, Gx_line+178, 744, Gx_line+197, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20cMesAnt1, "")), 842, Gx_line+171, 934, Gx_line+186, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21cMesAnt2, "")), 950, Gx_line+171, 1042, Gx_line+186, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22cMesAnt3, "")), 1049, Gx_line+170, 1141, Gx_line+185, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Promedio de Compra", 688, Gx_line+160, 812, Gx_line+174, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 672, Gx_line+179, 725, Gx_line+193, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 766, Gx_line+179, 816, Gx_line+193, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(654, Gx_line+158, 654, Gx_line+196, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(654, Gx_line+178, 836, Gx_line+178, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36Filtro3, "")), 510, Gx_line+134, 853, Gx_line+158, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo Reporte", 426, Gx_line+139, 495, Gx_line+153, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+197);
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
         AV59Session = context.GetSession();
         AV27EmpDir = "";
         AV29EmpRUC = "";
         AV56Ruta = "";
         AV40Logo = "";
         AV75Logo_GXI = "";
         AV34Filtro1 = "";
         AV35Filtro2 = "";
         AV36Filtro3 = "";
         AV20cMesAnt1 = "";
         AV21cMesAnt2 = "";
         AV22cMesAnt3 = "";
         scmdbuf = "";
         P00DG2_A244PrvCod = new string[] {""} ;
         P00DG2_A247PrvDsc = new string[] {""} ;
         A244PrvCod = "";
         A247PrvDsc = "";
         P00DG3_A28ProdCod = new string[] {""} ;
         P00DG3_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00DG4_A180MonCod = new int[1] ;
         P00DG4_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV38Filtro5 = "";
         AV57SDTComprasProducto = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         AV58SDTComprasProductoITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV54ProdDsc = "";
         A254ComDProCod = "";
         A697ComDOrdTip = "";
         A707ComFReg = DateTime.MinValue;
         P00DG5_A149TipCod = new string[] {""} ;
         P00DG5_A243ComCod = new string[] {""} ;
         P00DG5_A694ComDDsc = new string[] {""} ;
         P00DG5_A254ComDProCod = new string[] {""} ;
         P00DG5_n254ComDProCod = new bool[] {false} ;
         P00DG5_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00DG5_A697ComDOrdTip = new string[] {""} ;
         P00DG5_A1158LinStk = new short[1] ;
         P00DG5_A244PrvCod = new string[] {""} ;
         P00DG5_A51SublCod = new int[1] ;
         P00DG5_n51SublCod = new bool[] {false} ;
         P00DG5_A52LinCod = new int[1] ;
         P00DG5_n52LinCod = new bool[] {false} ;
         P00DG5_A686ComDPre = new decimal[1] ;
         P00DG5_A250ComDItem = new short[1] ;
         P00DG5_A251ComDOrdCod = new string[] {""} ;
         A149TipCod = "";
         A243ComCod = "";
         A694ComDDsc = "";
         A251ComDOrdCod = "";
         AV72Codigo = "";
         A253ComDCueCod = "";
         P00DG6_A149TipCod = new string[] {""} ;
         P00DG6_A243ComCod = new string[] {""} ;
         P00DG6_A694ComDDsc = new string[] {""} ;
         P00DG6_A253ComDCueCod = new string[] {""} ;
         P00DG6_n253ComDCueCod = new bool[] {false} ;
         P00DG6_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00DG6_A697ComDOrdTip = new string[] {""} ;
         P00DG6_A244PrvCod = new string[] {""} ;
         P00DG6_A254ComDProCod = new string[] {""} ;
         P00DG6_n254ComDProCod = new bool[] {false} ;
         P00DG6_A51SublCod = new int[1] ;
         P00DG6_n51SublCod = new bool[] {false} ;
         P00DG6_A52LinCod = new int[1] ;
         P00DG6_n52LinCod = new bool[] {false} ;
         P00DG6_A686ComDPre = new decimal[1] ;
         P00DG6_A250ComDItem = new short[1] ;
         P00DG6_A251ComDOrdCod = new string[] {""} ;
         P00DG7_A243ComCod = new string[] {""} ;
         P00DG7_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00DG7_A254ComDProCod = new string[] {""} ;
         P00DG7_n254ComDProCod = new bool[] {false} ;
         P00DG7_A244PrvCod = new string[] {""} ;
         P00DG7_A51SublCod = new int[1] ;
         P00DG7_n51SublCod = new bool[] {false} ;
         P00DG7_A52LinCod = new int[1] ;
         P00DG7_n52LinCod = new bool[] {false} ;
         P00DG7_A149TipCod = new string[] {""} ;
         P00DG7_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DG7_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00DG7_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00DG7_A511TipSigno = new short[1] ;
         P00DG7_A246ComMon = new int[1] ;
         P00DG7_A689ComDDct = new decimal[1] ;
         P00DG7_A686ComDPre = new decimal[1] ;
         P00DG7_A685ComDCant = new decimal[1] ;
         P00DG7_A250ComDItem = new short[1] ;
         P00DG7_A251ComDOrdCod = new string[] {""} ;
         A248ComFec = DateTime.MinValue;
         A704ComFecPago = DateTime.MinValue;
         A724ComRefFec = DateTime.MinValue;
         AV64TipCod2 = "";
         AV32Fecha = DateTime.MinValue;
         P00DG8_A243ComCod = new string[] {""} ;
         P00DG8_A254ComDProCod = new string[] {""} ;
         P00DG8_n254ComDProCod = new bool[] {false} ;
         P00DG8_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00DG8_A697ComDOrdTip = new string[] {""} ;
         P00DG8_A253ComDCueCod = new string[] {""} ;
         P00DG8_n253ComDCueCod = new bool[] {false} ;
         P00DG8_A244PrvCod = new string[] {""} ;
         P00DG8_A51SublCod = new int[1] ;
         P00DG8_n51SublCod = new bool[] {false} ;
         P00DG8_A52LinCod = new int[1] ;
         P00DG8_n52LinCod = new bool[] {false} ;
         P00DG8_A149TipCod = new string[] {""} ;
         P00DG8_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DG8_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00DG8_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00DG8_A511TipSigno = new short[1] ;
         P00DG8_A246ComMon = new int[1] ;
         P00DG8_A689ComDDct = new decimal[1] ;
         P00DG8_A686ComDPre = new decimal[1] ;
         P00DG8_A685ComDCant = new decimal[1] ;
         P00DG8_A250ComDItem = new short[1] ;
         P00DG8_A251ComDOrdCod = new string[] {""} ;
         GXt_char1 = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV40Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_analisiscomprasproductospdf__default(),
            new Object[][] {
                new Object[] {
               P00DG2_A244PrvCod, P00DG2_A247PrvDsc
               }
               , new Object[] {
               P00DG3_A28ProdCod, P00DG3_A55ProdDsc
               }
               , new Object[] {
               P00DG4_A180MonCod, P00DG4_A1234MonDsc
               }
               , new Object[] {
               P00DG5_A149TipCod, P00DG5_A243ComCod, P00DG5_A694ComDDsc, P00DG5_A254ComDProCod, P00DG5_n254ComDProCod, P00DG5_A707ComFReg, P00DG5_A697ComDOrdTip, P00DG5_A1158LinStk, P00DG5_A244PrvCod, P00DG5_A51SublCod,
               P00DG5_n51SublCod, P00DG5_A52LinCod, P00DG5_n52LinCod, P00DG5_A686ComDPre, P00DG5_A250ComDItem, P00DG5_A251ComDOrdCod
               }
               , new Object[] {
               P00DG6_A149TipCod, P00DG6_A243ComCod, P00DG6_A694ComDDsc, P00DG6_A253ComDCueCod, P00DG6_n253ComDCueCod, P00DG6_A707ComFReg, P00DG6_A697ComDOrdTip, P00DG6_A244PrvCod, P00DG6_A254ComDProCod, P00DG6_n254ComDProCod,
               P00DG6_A51SublCod, P00DG6_n51SublCod, P00DG6_A52LinCod, P00DG6_n52LinCod, P00DG6_A686ComDPre, P00DG6_A250ComDItem, P00DG6_A251ComDOrdCod
               }
               , new Object[] {
               P00DG7_A243ComCod, P00DG7_A707ComFReg, P00DG7_A254ComDProCod, P00DG7_n254ComDProCod, P00DG7_A244PrvCod, P00DG7_A51SublCod, P00DG7_n51SublCod, P00DG7_A52LinCod, P00DG7_n52LinCod, P00DG7_A149TipCod,
               P00DG7_A248ComFec, P00DG7_A704ComFecPago, P00DG7_A724ComRefFec, P00DG7_A511TipSigno, P00DG7_A246ComMon, P00DG7_A689ComDDct, P00DG7_A686ComDPre, P00DG7_A685ComDCant, P00DG7_A250ComDItem, P00DG7_A251ComDOrdCod
               }
               , new Object[] {
               P00DG8_A243ComCod, P00DG8_A254ComDProCod, P00DG8_n254ComDProCod, P00DG8_A707ComFReg, P00DG8_A697ComDOrdTip, P00DG8_A253ComDCueCod, P00DG8_n253ComDCueCod, P00DG8_A244PrvCod, P00DG8_A51SublCod, P00DG8_n51SublCod,
               P00DG8_A52LinCod, P00DG8_n52LinCod, P00DG8_A149TipCod, P00DG8_A248ComFec, P00DG8_A704ComFecPago, P00DG8_A724ComRefFec, P00DG8_A511TipSigno, P00DG8_A246ComMon, P00DG8_A689ComDDct, P00DG8_A686ComDPre,
               P00DG8_A685ComDCant, P00DG8_A250ComDItem, P00DG8_A251ComDOrdCod
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
      private short A1158LinStk ;
      private short A250ComDItem ;
      private short A511TipSigno ;
      private short AV66TipSigno ;
      private int AV39LinCod ;
      private int AV60SubLCod ;
      private int AV26DocMonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int AV82GXV1 ;
      private int Gx_OldLine ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A246ComMon ;
      private int AV49MonCod ;
      private int GXt_int3 ;
      private decimal AV68TotalGeneral ;
      private decimal AV14Cantidad ;
      private decimal AV69TotalVenta ;
      private decimal AV41Mes1 ;
      private decimal AV42Mes2 ;
      private decimal AV43Mes3 ;
      private decimal AV15CantMes1 ;
      private decimal AV16CantMes2 ;
      private decimal AV17CantMes3 ;
      private decimal AV48MesProm ;
      private decimal AV18CantProm ;
      private decimal AV51Porcentaje ;
      private decimal AV70TPorcentaje ;
      private decimal AV61TCantidad ;
      private decimal A686ComDPre ;
      private decimal AV67Total ;
      private decimal AV13Cant ;
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
      private string AV65Tipo ;
      private string AV28Empresa ;
      private string AV27EmpDir ;
      private string AV29EmpRUC ;
      private string AV56Ruta ;
      private string AV34Filtro1 ;
      private string AV35Filtro2 ;
      private string AV36Filtro3 ;
      private string scmdbuf ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1234MonDsc ;
      private string AV38Filtro5 ;
      private string AV54ProdDsc ;
      private string A254ComDProCod ;
      private string A149TipCod ;
      private string A243ComCod ;
      private string A694ComDDsc ;
      private string A251ComDOrdCod ;
      private string AV72Codigo ;
      private string A253ComDCueCod ;
      private string AV64TipCod2 ;
      private string GXt_char1 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV31FDesde ;
      private DateTime AV33FHasta ;
      private DateTime A707ComFReg ;
      private DateTime A248ComFec ;
      private DateTime A704ComFecPago ;
      private DateTime A724ComRefFec ;
      private DateTime AV32Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool BRKDG6 ;
      private bool n254ComDProCod ;
      private bool n51SublCod ;
      private bool n52LinCod ;
      private bool BRKDG8 ;
      private bool n253ComDCueCod ;
      private string AV75Logo_GXI ;
      private string AV20cMesAnt1 ;
      private string AV21cMesAnt2 ;
      private string AV22cMesAnt3 ;
      private string A697ComDOrdTip ;
      private string AV40Logo ;
      private string Logo ;
      private IGxSession AV59Session ;
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
      private string[] P00DG2_A244PrvCod ;
      private string[] P00DG2_A247PrvDsc ;
      private string[] P00DG3_A28ProdCod ;
      private string[] P00DG3_A55ProdDsc ;
      private int[] P00DG4_A180MonCod ;
      private string[] P00DG4_A1234MonDsc ;
      private string[] P00DG5_A149TipCod ;
      private string[] P00DG5_A243ComCod ;
      private string[] P00DG5_A694ComDDsc ;
      private string[] P00DG5_A254ComDProCod ;
      private bool[] P00DG5_n254ComDProCod ;
      private DateTime[] P00DG5_A707ComFReg ;
      private string[] P00DG5_A697ComDOrdTip ;
      private short[] P00DG5_A1158LinStk ;
      private string[] P00DG5_A244PrvCod ;
      private int[] P00DG5_A51SublCod ;
      private bool[] P00DG5_n51SublCod ;
      private int[] P00DG5_A52LinCod ;
      private bool[] P00DG5_n52LinCod ;
      private decimal[] P00DG5_A686ComDPre ;
      private short[] P00DG5_A250ComDItem ;
      private string[] P00DG5_A251ComDOrdCod ;
      private string[] P00DG6_A149TipCod ;
      private string[] P00DG6_A243ComCod ;
      private string[] P00DG6_A694ComDDsc ;
      private string[] P00DG6_A253ComDCueCod ;
      private bool[] P00DG6_n253ComDCueCod ;
      private DateTime[] P00DG6_A707ComFReg ;
      private string[] P00DG6_A697ComDOrdTip ;
      private string[] P00DG6_A244PrvCod ;
      private string[] P00DG6_A254ComDProCod ;
      private bool[] P00DG6_n254ComDProCod ;
      private int[] P00DG6_A51SublCod ;
      private bool[] P00DG6_n51SublCod ;
      private int[] P00DG6_A52LinCod ;
      private bool[] P00DG6_n52LinCod ;
      private decimal[] P00DG6_A686ComDPre ;
      private short[] P00DG6_A250ComDItem ;
      private string[] P00DG6_A251ComDOrdCod ;
      private string[] P00DG7_A243ComCod ;
      private DateTime[] P00DG7_A707ComFReg ;
      private string[] P00DG7_A254ComDProCod ;
      private bool[] P00DG7_n254ComDProCod ;
      private string[] P00DG7_A244PrvCod ;
      private int[] P00DG7_A51SublCod ;
      private bool[] P00DG7_n51SublCod ;
      private int[] P00DG7_A52LinCod ;
      private bool[] P00DG7_n52LinCod ;
      private string[] P00DG7_A149TipCod ;
      private DateTime[] P00DG7_A248ComFec ;
      private DateTime[] P00DG7_A704ComFecPago ;
      private DateTime[] P00DG7_A724ComRefFec ;
      private short[] P00DG7_A511TipSigno ;
      private int[] P00DG7_A246ComMon ;
      private decimal[] P00DG7_A689ComDDct ;
      private decimal[] P00DG7_A686ComDPre ;
      private decimal[] P00DG7_A685ComDCant ;
      private short[] P00DG7_A250ComDItem ;
      private string[] P00DG7_A251ComDOrdCod ;
      private string[] P00DG8_A243ComCod ;
      private string[] P00DG8_A254ComDProCod ;
      private bool[] P00DG8_n254ComDProCod ;
      private DateTime[] P00DG8_A707ComFReg ;
      private string[] P00DG8_A697ComDOrdTip ;
      private string[] P00DG8_A253ComDCueCod ;
      private bool[] P00DG8_n253ComDCueCod ;
      private string[] P00DG8_A244PrvCod ;
      private int[] P00DG8_A51SublCod ;
      private bool[] P00DG8_n51SublCod ;
      private int[] P00DG8_A52LinCod ;
      private bool[] P00DG8_n52LinCod ;
      private string[] P00DG8_A149TipCod ;
      private DateTime[] P00DG8_A248ComFec ;
      private DateTime[] P00DG8_A704ComFecPago ;
      private DateTime[] P00DG8_A724ComRefFec ;
      private short[] P00DG8_A511TipSigno ;
      private int[] P00DG8_A246ComMon ;
      private decimal[] P00DG8_A689ComDDct ;
      private decimal[] P00DG8_A686ComDPre ;
      private decimal[] P00DG8_A685ComDCant ;
      private short[] P00DG8_A250ComDItem ;
      private string[] P00DG8_A251ComDOrdCod ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV57SDTComprasProducto ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV58SDTComprasProductoITem ;
   }

   public class r_analisiscomprasproductospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DG5( IGxContext context ,
                                             int AV39LinCod ,
                                             int AV60SubLCod ,
                                             string AV53ProdCod ,
                                             string AV55PrvCod ,
                                             string AV65Tipo ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A254ComDProCod ,
                                             string A244PrvCod ,
                                             short A1158LinStk ,
                                             string A697ComDOrdTip ,
                                             DateTime A707ComFReg ,
                                             DateTime AV31FDesde ,
                                             DateTime AV33FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T1.[ComCod], T1.[ComDDsc], T1.[ComDProCod] AS ComDProCod, T4.[ComFReg], T1.[ComDOrdTip], T3.[LinStk], T1.[PrvCod], T2.[SublCod], T2.[LinCod], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ((([CPCOMPRASDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ComDProCod]) LEFT JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [CPCOMPRAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(( Not (T1.[ComDProCod] = '') and Not (T1.[ComDOrdTip] = '')))");
         AddWhere(sWhereString, "(T4.[ComFReg] >= @AV31FDesde and T4.[ComFReg] <= @AV33FHasta)");
         if ( ! (0==AV39LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV39LinCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV60SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV60SubLCod)");
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
         if ( StringUtil.StrCmp(AV65Tipo, "P") == 0 )
         {
            AddWhere(sWhereString, "(T3.[LinStk] = 1 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         if ( StringUtil.StrCmp(AV65Tipo, "S") == 0 )
         {
            AddWhere(sWhereString, "(T3.[LinStk] = 0 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         if ( StringUtil.StrCmp(AV65Tipo, "G") == 0 )
         {
            AddWhere(sWhereString, "(T3.[LinStk] = 2 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComDProCod], T1.[ComDDsc]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00DG6( IGxContext context ,
                                             int AV39LinCod ,
                                             int AV60SubLCod ,
                                             string AV53ProdCod ,
                                             string AV55PrvCod ,
                                             string AV65Tipo ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A254ComDProCod ,
                                             string A244PrvCod ,
                                             string A253ComDCueCod ,
                                             string A697ComDOrdTip ,
                                             DateTime A707ComFReg ,
                                             DateTime AV31FDesde ,
                                             DateTime AV33FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[6];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T1.[ComCod], T1.[ComDDsc], T1.[ComDCueCod], T2.[ComFReg], T1.[ComDOrdTip], T1.[PrvCod], T1.[ComDProCod] AS ComDProCod, T3.[SublCod], T3.[LinCod], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM (([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) LEFT JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ComDProCod])";
         AddWhere(sWhereString, "(T2.[ComFReg] >= @AV31FDesde and T2.[ComFReg] <= @AV33FHasta)");
         if ( ! (0==AV39LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV39LinCod)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! (0==AV60SubLCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV60SubLCod)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDProCod] = @AV53ProdCod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV55PrvCod)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( StringUtil.StrCmp(AV65Tipo, "T") == 0 )
         {
            AddWhere(sWhereString, "(( Not (T1.[ComDCueCod] = '') and Not T1.[ComDCueCod] IS NULL and (T1.[ComDOrdTip] = '')))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComDCueCod], T1.[ComDDsc]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00DG7( IGxContext context ,
                                             int AV39LinCod ,
                                             int AV60SubLCod ,
                                             string AV55PrvCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A244PrvCod ,
                                             DateTime A707ComFReg ,
                                             DateTime AV31FDesde ,
                                             DateTime AV33FHasta ,
                                             string AV72Codigo ,
                                             string A254ComDProCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[6];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[ComCod], T4.[ComFReg], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[SublCod], T2.[LinCod], T1.[TipCod], T4.[ComFec], T4.[ComFecPago], T4.[ComRefFec], T3.[TipSigno], T4.[ComMon], T1.[ComDDct], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem], T1.[ComDOrdCod] FROM ((([CPCOMPRASDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ComDProCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(T1.[ComDProCod] = @AV72Codigo)");
         AddWhere(sWhereString, "(T4.[ComFReg] >= @AV31FDesde and T4.[ComFReg] <= @AV33FHasta)");
         if ( ! (0==AV39LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV39LinCod)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! (0==AV60SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV60SubLCod)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV55PrvCod)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComDProCod]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00DG8( IGxContext context ,
                                             int AV39LinCod ,
                                             int AV60SubLCod ,
                                             string AV55PrvCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A244PrvCod ,
                                             string A697ComDOrdTip ,
                                             DateTime A707ComFReg ,
                                             DateTime AV31FDesde ,
                                             DateTime AV33FHasta ,
                                             string AV72Codigo ,
                                             string A253ComDCueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[6];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.[ComCod], T1.[ComDProCod] AS ComDProCod, T4.[ComFReg], T1.[ComDOrdTip], T1.[ComDCueCod], T1.[PrvCod], T2.[SublCod], T2.[LinCod], T1.[TipCod], T4.[ComFec], T4.[ComFecPago], T4.[ComRefFec], T3.[TipSigno], T4.[ComMon], T1.[ComDDct], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem], T1.[ComDOrdCod] FROM ((([CPCOMPRASDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ComDProCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(T1.[ComDCueCod] = @AV72Codigo)");
         AddWhere(sWhereString, "((T1.[ComDOrdTip] = ''))");
         AddWhere(sWhereString, "(T4.[ComFReg] >= @AV31FDesde and T4.[ComFReg] <= @AV33FHasta)");
         if ( ! (0==AV39LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV39LinCod)");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ! (0==AV60SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV60SubLCod)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV55PrvCod)");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComDCueCod]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_P00DG5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] );
               case 4 :
                     return conditional_P00DG6(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] );
               case 5 :
                     return conditional_P00DG7(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
               case 6 :
                     return conditional_P00DG8(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DG2;
          prmP00DG2 = new Object[] {
          new ParDef("@AV55PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DG3;
          prmP00DG3 = new Object[] {
          new ParDef("@AV53ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DG4;
          prmP00DG4 = new Object[] {
          new ParDef("@AV26DocMonCod",GXType.Int32,6,0)
          };
          Object[] prmP00DG5;
          prmP00DG5 = new Object[] {
          new ParDef("@AV31FDesde",GXType.Date,8,0) ,
          new ParDef("@AV33FHasta",GXType.Date,8,0) ,
          new ParDef("@AV39LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV60SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV53ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV55PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DG6;
          prmP00DG6 = new Object[] {
          new ParDef("@AV31FDesde",GXType.Date,8,0) ,
          new ParDef("@AV33FHasta",GXType.Date,8,0) ,
          new ParDef("@AV39LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV60SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV53ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV55PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DG7;
          prmP00DG7 = new Object[] {
          new ParDef("@AV72Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV31FDesde",GXType.Date,8,0) ,
          new ParDef("@AV33FHasta",GXType.Date,8,0) ,
          new ParDef("@AV39LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV60SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV55PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DG8;
          prmP00DG8 = new Object[] {
          new ParDef("@AV72Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV31FDesde",GXType.Date,8,0) ,
          new ParDef("@AV33FHasta",GXType.Date,8,0) ,
          new ParDef("@AV39LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV60SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV55PrvCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DG2", "SELECT [PrvCod], [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @AV55PrvCod ORDER BY [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DG3", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV53ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DG4", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV26DocMonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DG5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DG6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DG7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DG8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG8,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
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
             case 4 :
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
             case 5 :
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
             case 6 :
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
