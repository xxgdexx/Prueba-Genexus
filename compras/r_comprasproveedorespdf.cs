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
   public class r_comprasproveedorespdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_comprasproveedorespdf.aspx")), "compras.r_comprasproveedorespdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_comprasproveedorespdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "TPrvCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV49TPrvCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV32PrvCod = GetPar( "PrvCod");
                  AV39TipCod = GetPar( "TipCod");
                  AV29PaiCod = GetPar( "PaiCod");
                  AV18FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV20FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV12DocMonCod = (int)(NumberUtil.Val( GetPar( "DocMonCod"), "."));
                  AV41Tipo = GetPar( "Tipo");
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

      public r_comprasproveedorespdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_comprasproveedorespdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TPrvCod ,
                           ref string aP1_PrvCod ,
                           ref string aP2_TipCod ,
                           ref string aP3_PaiCod ,
                           ref DateTime aP4_FDesde ,
                           ref DateTime aP5_FHasta ,
                           ref int aP6_DocMonCod ,
                           ref string aP7_Tipo )
      {
         this.AV49TPrvCod = aP0_TPrvCod;
         this.AV32PrvCod = aP1_PrvCod;
         this.AV39TipCod = aP2_TipCod;
         this.AV29PaiCod = aP3_PaiCod;
         this.AV18FDesde = aP4_FDesde;
         this.AV20FHasta = aP5_FHasta;
         this.AV12DocMonCod = aP6_DocMonCod;
         this.AV41Tipo = aP7_Tipo;
         initialize();
         executePrivate();
         aP0_TPrvCod=this.AV49TPrvCod;
         aP1_PrvCod=this.AV32PrvCod;
         aP2_TipCod=this.AV39TipCod;
         aP3_PaiCod=this.AV29PaiCod;
         aP4_FDesde=this.AV18FDesde;
         aP5_FHasta=this.AV20FHasta;
         aP6_DocMonCod=this.AV12DocMonCod;
         aP7_Tipo=this.AV41Tipo;
      }

      public string executeUdp( ref int aP0_TPrvCod ,
                                ref string aP1_PrvCod ,
                                ref string aP2_TipCod ,
                                ref string aP3_PaiCod ,
                                ref DateTime aP4_FDesde ,
                                ref DateTime aP5_FHasta ,
                                ref int aP6_DocMonCod )
      {
         execute(ref aP0_TPrvCod, ref aP1_PrvCod, ref aP2_TipCod, ref aP3_PaiCod, ref aP4_FDesde, ref aP5_FHasta, ref aP6_DocMonCod, ref aP7_Tipo);
         return AV41Tipo ;
      }

      public void executeSubmit( ref int aP0_TPrvCod ,
                                 ref string aP1_PrvCod ,
                                 ref string aP2_TipCod ,
                                 ref string aP3_PaiCod ,
                                 ref DateTime aP4_FDesde ,
                                 ref DateTime aP5_FHasta ,
                                 ref int aP6_DocMonCod ,
                                 ref string aP7_Tipo )
      {
         r_comprasproveedorespdf objr_comprasproveedorespdf;
         objr_comprasproveedorespdf = new r_comprasproveedorespdf();
         objr_comprasproveedorespdf.AV49TPrvCod = aP0_TPrvCod;
         objr_comprasproveedorespdf.AV32PrvCod = aP1_PrvCod;
         objr_comprasproveedorespdf.AV39TipCod = aP2_TipCod;
         objr_comprasproveedorespdf.AV29PaiCod = aP3_PaiCod;
         objr_comprasproveedorespdf.AV18FDesde = aP4_FDesde;
         objr_comprasproveedorespdf.AV20FHasta = aP5_FHasta;
         objr_comprasproveedorespdf.AV12DocMonCod = aP6_DocMonCod;
         objr_comprasproveedorespdf.AV41Tipo = aP7_Tipo;
         objr_comprasproveedorespdf.context.SetSubmitInitialConfig(context);
         objr_comprasproveedorespdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_comprasproveedorespdf);
         aP0_TPrvCod=this.AV49TPrvCod;
         aP1_PrvCod=this.AV32PrvCod;
         aP2_TipCod=this.AV39TipCod;
         aP3_PaiCod=this.AV29PaiCod;
         aP4_FDesde=this.AV18FDesde;
         aP5_FHasta=this.AV20FHasta;
         aP6_DocMonCod=this.AV12DocMonCod;
         aP7_Tipo=this.AV41Tipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_comprasproveedorespdf)stateInfo).executePrivate();
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
            AV15Empresa = AV36Session.Get("Empresa");
            AV14EmpDir = AV36Session.Get("EmpDir");
            AV16EmpRUC = AV36Session.Get("EmpRUC");
            AV33Ruta = AV36Session.Get("RUTA") + "/Logo.jpg";
            AV27Logo = AV33Ruta;
            AV52Logo_GXI = GXDbFile.PathToUrl( AV33Ruta);
            AV21Filtro1 = "(Todos)";
            AV22Filtro2 = "(Todos)";
            AV23Filtro3 = "(Todos)";
            AV24Filtro4 = ((StringUtil.StrCmp(AV41Tipo, "P")==0) ? "Productos" : ((StringUtil.StrCmp(AV41Tipo, "S")==0) ? "Servicio" : ((StringUtil.StrCmp(AV41Tipo, "G")==0) ? "Gastos" : "(Todos)")));
            /* Using cursor P00AR2 */
            pr_default.execute(0, new Object[] {AV39TipCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A149TipCod = P00AR2_A149TipCod[0];
               A1910TipDsc = P00AR2_A1910TipDsc[0];
               AV21Filtro1 = A1910TipDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00AR3 */
            pr_default.execute(1, new Object[] {AV49TPrvCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A298TprvCod = P00AR3_A298TprvCod[0];
               A1941TprvDsc = P00AR3_A1941TprvDsc[0];
               AV22Filtro2 = A1941TprvDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00AR4 */
            pr_default.execute(2, new Object[] {AV32PrvCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A244PrvCod = P00AR4_A244PrvCod[0];
               AV23Filtro3 = A244PrvCod;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P00AR5 */
            pr_default.execute(3, new Object[] {AV12DocMonCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A180MonCod = P00AR5_A180MonCod[0];
               A1234MonDsc = P00AR5_A1234MonDsc[0];
               AV25Filtro5 = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            AV44TotalGeneral = 0.00m;
            AV45TotalGeneralME = 0.00m;
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 AV49TPrvCod ,
                                                 AV32PrvCod ,
                                                 AV39TipCod ,
                                                 AV29PaiCod ,
                                                 AV41Tipo ,
                                                 A298TprvCod ,
                                                 A244PrvCod ,
                                                 A149TipCod ,
                                                 A139PaiCod ,
                                                 A1158LinStk ,
                                                 A254ComDProCod ,
                                                 A253ComDCueCod ,
                                                 A697ComDOrdTip ,
                                                 A707ComFReg ,
                                                 AV18FDesde ,
                                                 AV20FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00AR6 */
            pr_default.execute(4, new Object[] {AV18FDesde, AV20FHasta, AV49TPrvCod, AV32PrvCod, AV39TipCod, AV29PaiCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               BRKAR7 = false;
               A243ComCod = P00AR6_A243ComCod[0];
               A52LinCod = P00AR6_A52LinCod[0];
               n52LinCod = P00AR6_n52LinCod[0];
               A247PrvDsc = P00AR6_A247PrvDsc[0];
               A244PrvCod = P00AR6_A244PrvCod[0];
               A707ComFReg = P00AR6_A707ComFReg[0];
               A697ComDOrdTip = P00AR6_A697ComDOrdTip[0];
               A253ComDCueCod = P00AR6_A253ComDCueCod[0];
               n253ComDCueCod = P00AR6_n253ComDCueCod[0];
               A254ComDProCod = P00AR6_A254ComDProCod[0];
               n254ComDProCod = P00AR6_n254ComDProCod[0];
               A1158LinStk = P00AR6_A1158LinStk[0];
               A139PaiCod = P00AR6_A139PaiCod[0];
               A149TipCod = P00AR6_A149TipCod[0];
               A298TprvCod = P00AR6_A298TprvCod[0];
               A250ComDItem = P00AR6_A250ComDItem[0];
               A251ComDOrdCod = P00AR6_A251ComDOrdCod[0];
               A139PaiCod = P00AR6_A139PaiCod[0];
               A298TprvCod = P00AR6_A298TprvCod[0];
               A52LinCod = P00AR6_A52LinCod[0];
               n52LinCod = P00AR6_n52LinCod[0];
               A1158LinStk = P00AR6_A1158LinStk[0];
               A247PrvDsc = P00AR6_A247PrvDsc[0];
               A707ComFReg = P00AR6_A707ComFReg[0];
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00AR6_A244PrvCod[0], A244PrvCod) == 0 ) )
               {
                  BRKAR7 = false;
                  A243ComCod = P00AR6_A243ComCod[0];
                  A247PrvDsc = P00AR6_A247PrvDsc[0];
                  A149TipCod = P00AR6_A149TipCod[0];
                  A250ComDItem = P00AR6_A250ComDItem[0];
                  A251ComDOrdCod = P00AR6_A251ComDOrdCod[0];
                  A247PrvDsc = P00AR6_A247PrvDsc[0];
                  BRKAR7 = true;
                  pr_default.readNext(4);
               }
               AV10DocCliCod = A244PrvCod;
               AV11DocCliDsc = A247PrvDsc;
               AV47TotalVenta = 0.00m;
               AV48TotalVentaME = 0.00m;
               AV43Total = 0.00m;
               AV46TotalME = 0.00m;
               /* Execute user subroutine: 'PROVEEDORES' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(4);
                  this.cleanup();
                  if (true) return;
               }
               AV35SDTComprasProveedorITem.gxTpr_Clicod = AV10DocCliCod;
               AV35SDTComprasProveedorITem.gxTpr_Clidsc = AV11DocCliDsc;
               AV35SDTComprasProveedorITem.gxTpr_Importe = AV47TotalVenta;
               AV35SDTComprasProveedorITem.gxTpr_Importe1 = AV48TotalVentaME;
               AV34SDTComprasProveedor.Add(AV35SDTComprasProveedorITem, 0);
               AV35SDTComprasProveedorITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
               AV44TotalGeneral = (decimal)(AV44TotalGeneral+AV47TotalVenta);
               AV45TotalGeneralME = (decimal)(AV45TotalGeneralME+AV48TotalVentaME);
               if ( ! BRKAR7 )
               {
                  BRKAR7 = true;
                  pr_default.readNext(4);
               }
            }
            pr_default.close(4);
            AV34SDTComprasProveedor.Sort("[Importe]");
            AV26Flag90 = 0;
            AV37SumPorcent = 0;
            AV62GXV1 = 1;
            while ( AV62GXV1 <= AV34SDTComprasProveedor.Count )
            {
               AV35SDTComprasProveedorITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV34SDTComprasProveedor.Item(AV62GXV1));
               AV10DocCliCod = AV35SDTComprasProveedorITem.gxTpr_Clicod;
               AV11DocCliDsc = AV35SDTComprasProveedorITem.gxTpr_Clidsc;
               AV47TotalVenta = AV35SDTComprasProveedorITem.gxTpr_Importe;
               AV48TotalVentaME = AV35SDTComprasProveedorITem.gxTpr_Importe1;
               AV30Porcentaje = NumberUtil.Round( (AV47TotalVenta/ (decimal)(AV44TotalGeneral))*100, 2);
               AV31Porcentaje2 = NumberUtil.Round( (AV48TotalVentaME/ (decimal)(AV45TotalGeneralME))*100, 2);
               AV37SumPorcent = (decimal)(AV37SumPorcent+AV30Porcentaje);
               if ( ( AV37SumPorcent >= Convert.ToDecimal( 90 )) && ( AV26Flag90 == 0 ) )
               {
                  AV26Flag90 = 1;
                  HAR0( false, 39) ;
                  getPrinter().GxDrawLine(3, Gx_line+9, 793, Gx_line+9, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("90 %", 335, Gx_line+12, 367, Gx_line+26, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+39);
               }
               HAR0( false, 16) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11DocCliDsc, "")), 124, Gx_line+2, 510, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TotalVenta, "ZZZZZZ,ZZZ,ZZ9.99")), 485, Gx_line+1, 592, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10DocCliCod, "")), 2, Gx_line+1, 107, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48TotalVentaME, "ZZZZZZ,ZZZ,ZZ9.99")), 645, Gx_line+1, 752, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV30Porcentaje, "9.99")), 609, Gx_line+1, 635, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31Porcentaje2, "9.99")), 768, Gx_line+1, 794, Gx_line+16, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+16);
               AV62GXV1 = (int)(AV62GXV1+1);
            }
            HAR0( false, 52) ;
            getPrinter().GxDrawLine(479, Gx_line+7, 757, Gx_line+7, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 400, Gx_line+17, 480, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44TotalGeneral, "ZZZZZZZZZ,ZZ9.99")), 492, Gx_line+17, 593, Gx_line+32, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TotalGeneralME, "ZZZZZZ,ZZZ,ZZ9.99")), 645, Gx_line+16, 752, Gx_line+31, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAR0( true, 0) ;
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
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV49TPrvCod ,
                                              AV32PrvCod ,
                                              AV39TipCod ,
                                              AV29PaiCod ,
                                              AV41Tipo ,
                                              A298TprvCod ,
                                              A244PrvCod ,
                                              A149TipCod ,
                                              A139PaiCod ,
                                              A1158LinStk ,
                                              A254ComDProCod ,
                                              A253ComDCueCod ,
                                              A697ComDOrdTip ,
                                              A707ComFReg ,
                                              AV18FDesde ,
                                              AV20FHasta ,
                                              AV10DocCliCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AR7 */
         pr_default.execute(5, new Object[] {AV18FDesde, AV20FHasta, AV10DocCliCod, AV49TPrvCod, AV32PrvCod, AV39TipCod, AV29PaiCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A243ComCod = P00AR7_A243ComCod[0];
            A52LinCod = P00AR7_A52LinCod[0];
            n52LinCod = P00AR7_n52LinCod[0];
            A244PrvCod = P00AR7_A244PrvCod[0];
            A707ComFReg = P00AR7_A707ComFReg[0];
            A697ComDOrdTip = P00AR7_A697ComDOrdTip[0];
            A253ComDCueCod = P00AR7_A253ComDCueCod[0];
            n253ComDCueCod = P00AR7_n253ComDCueCod[0];
            A254ComDProCod = P00AR7_A254ComDProCod[0];
            n254ComDProCod = P00AR7_n254ComDProCod[0];
            A1158LinStk = P00AR7_A1158LinStk[0];
            A139PaiCod = P00AR7_A139PaiCod[0];
            A149TipCod = P00AR7_A149TipCod[0];
            A298TprvCod = P00AR7_A298TprvCod[0];
            A704ComFecPago = P00AR7_A704ComFecPago[0];
            A724ComRefFec = P00AR7_A724ComRefFec[0];
            A246ComMon = P00AR7_A246ComMon[0];
            A511TipSigno = P00AR7_A511TipSigno[0];
            A248ComFec = P00AR7_A248ComFec[0];
            A689ComDDct = P00AR7_A689ComDDct[0];
            A686ComDPre = P00AR7_A686ComDPre[0];
            A685ComDCant = P00AR7_A685ComDCant[0];
            A250ComDItem = P00AR7_A250ComDItem[0];
            A251ComDOrdCod = P00AR7_A251ComDOrdCod[0];
            A139PaiCod = P00AR7_A139PaiCod[0];
            A298TprvCod = P00AR7_A298TprvCod[0];
            A52LinCod = P00AR7_A52LinCod[0];
            n52LinCod = P00AR7_n52LinCod[0];
            A1158LinStk = P00AR7_A1158LinStk[0];
            A511TipSigno = P00AR7_A511TipSigno[0];
            A707ComFReg = P00AR7_A707ComFReg[0];
            A704ComFecPago = P00AR7_A704ComFecPago[0];
            A724ComRefFec = P00AR7_A724ComRefFec[0];
            A246ComMon = P00AR7_A246ComMon[0];
            A248ComFec = P00AR7_A248ComFec[0];
            A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
            A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
            A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
            AV40TipCod2 = A149TipCod;
            AV19Fecha = (((StringUtil.StrCmp(AV40TipCod2, "NC")==0)||(StringUtil.StrCmp(AV40TipCod2, "ND")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : ((DateTime.MinValue==A704ComFecPago) ? A248ComFec : A704ComFecPago));
            AV28MonCod = A246ComMon;
            GXt_decimal1 = AV8Cambio;
            GXt_int2 = 2;
            GXt_char3 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV19Fecha, ref  GXt_char3, out  GXt_decimal1) ;
            AV8Cambio = GXt_decimal1;
            AV42Tot = NumberUtil.Round( A684ComDTot, 2);
            AV43Total = ((AV28MonCod==1) ? NumberUtil.Round( AV42Tot*A511TipSigno, 2) : NumberUtil.Round( AV42Tot*A511TipSigno, 2)*AV8Cambio);
            AV46TotalME = ((AV28MonCod==1) ? NumberUtil.Round( AV42Tot*A511TipSigno, 2)/ (decimal)(AV8Cambio) : NumberUtil.Round( AV42Tot*A511TipSigno, 2));
            AV47TotalVenta = (decimal)(AV47TotalVenta+AV43Total);
            AV48TotalVentaME = (decimal)(AV48TotalVentaME+AV46TotalME);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void HAR0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 670, Gx_line+43, 702, Gx_line+57, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 670, Gx_line+63, 714, Gx_line+77, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 670, Gx_line+24, 709, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Analisis de Compras por Proveedor", 273, Gx_line+26, 571, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo de Documento", 174, Gx_line+115, 289, Gx_line+129, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Proveedor", 174, Gx_line+138, 282, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 174, Gx_line+160, 236, Gx_line+174, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21Filtro1, "")), 292, Gx_line+108, 635, Gx_line+132, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro2, "")), 292, Gx_line+130, 635, Gx_line+154, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro3, "")), 292, Gx_line+153, 635, Gx_line+177, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+214, 797, Gx_line+240, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 722, Gx_line+24, 769, Gx_line+39, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 707, Gx_line+43, 767, Gx_line+57, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 730, Gx_line+63, 769, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo Proveedor", 8, Gx_line+220, 113, Gx_line+234, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 184, Gx_line+220, 246, Gx_line+234, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Compra MN", 490, Gx_line+220, 591, Gx_line+234, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Del :", 291, Gx_line+48, 332, Gx_line+68, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV18FDesde, "99/99/99"), 340, Gx_line+46, 414, Gx_line+70, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 416, Gx_line+48, 446, Gx_line+68, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV20FHasta, "99/99/99"), 450, Gx_line+46, 524, Gx_line+70, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV27Logo)) ? AV52Logo_GXI : AV27Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+19, 176, Gx_line+97) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Expresado en :", 258, Gx_line+71, 385, Gx_line+91, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Filtro5, "")), 391, Gx_line+69, 580, Gx_line+93, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Compra ME", 656, Gx_line+220, 756, Gx_line+234, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("%", 614, Gx_line+220, 629, Gx_line+234, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(476, Gx_line+215, 476, Gx_line+240, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(600, Gx_line+214, 600, Gx_line+240, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(638, Gx_line+214, 638, Gx_line+240, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(760, Gx_line+214, 760, Gx_line+240, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("%", 771, Gx_line+220, 786, Gx_line+234, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(117, Gx_line+215, 117, Gx_line+240, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro4, "")), 292, Gx_line+177, 635, Gx_line+201, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo Reporte", 174, Gx_line+183, 251, Gx_line+197, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+240);
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
         AV15Empresa = "";
         AV36Session = context.GetSession();
         AV14EmpDir = "";
         AV16EmpRUC = "";
         AV33Ruta = "";
         AV27Logo = "";
         AV52Logo_GXI = "";
         AV21Filtro1 = "";
         AV22Filtro2 = "";
         AV23Filtro3 = "";
         AV24Filtro4 = "";
         scmdbuf = "";
         P00AR2_A149TipCod = new string[] {""} ;
         P00AR2_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         P00AR3_A298TprvCod = new int[1] ;
         P00AR3_A1941TprvDsc = new string[] {""} ;
         A1941TprvDsc = "";
         P00AR4_A244PrvCod = new string[] {""} ;
         A244PrvCod = "";
         P00AR5_A180MonCod = new int[1] ;
         P00AR5_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV25Filtro5 = "";
         A139PaiCod = "";
         A254ComDProCod = "";
         A253ComDCueCod = "";
         A697ComDOrdTip = "";
         A707ComFReg = DateTime.MinValue;
         P00AR6_A243ComCod = new string[] {""} ;
         P00AR6_A52LinCod = new int[1] ;
         P00AR6_n52LinCod = new bool[] {false} ;
         P00AR6_A247PrvDsc = new string[] {""} ;
         P00AR6_A244PrvCod = new string[] {""} ;
         P00AR6_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AR6_A697ComDOrdTip = new string[] {""} ;
         P00AR6_A253ComDCueCod = new string[] {""} ;
         P00AR6_n253ComDCueCod = new bool[] {false} ;
         P00AR6_A254ComDProCod = new string[] {""} ;
         P00AR6_n254ComDProCod = new bool[] {false} ;
         P00AR6_A1158LinStk = new short[1] ;
         P00AR6_A139PaiCod = new string[] {""} ;
         P00AR6_A149TipCod = new string[] {""} ;
         P00AR6_A298TprvCod = new int[1] ;
         P00AR6_A250ComDItem = new short[1] ;
         P00AR6_A251ComDOrdCod = new string[] {""} ;
         A243ComCod = "";
         A247PrvDsc = "";
         A251ComDOrdCod = "";
         AV10DocCliCod = "";
         AV11DocCliDsc = "";
         AV35SDTComprasProveedorITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV34SDTComprasProveedor = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         P00AR7_A243ComCod = new string[] {""} ;
         P00AR7_A52LinCod = new int[1] ;
         P00AR7_n52LinCod = new bool[] {false} ;
         P00AR7_A244PrvCod = new string[] {""} ;
         P00AR7_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AR7_A697ComDOrdTip = new string[] {""} ;
         P00AR7_A253ComDCueCod = new string[] {""} ;
         P00AR7_n253ComDCueCod = new bool[] {false} ;
         P00AR7_A254ComDProCod = new string[] {""} ;
         P00AR7_n254ComDProCod = new bool[] {false} ;
         P00AR7_A1158LinStk = new short[1] ;
         P00AR7_A139PaiCod = new string[] {""} ;
         P00AR7_A149TipCod = new string[] {""} ;
         P00AR7_A298TprvCod = new int[1] ;
         P00AR7_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00AR7_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00AR7_A246ComMon = new int[1] ;
         P00AR7_A511TipSigno = new short[1] ;
         P00AR7_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AR7_A689ComDDct = new decimal[1] ;
         P00AR7_A686ComDPre = new decimal[1] ;
         P00AR7_A685ComDCant = new decimal[1] ;
         P00AR7_A250ComDItem = new short[1] ;
         P00AR7_A251ComDOrdCod = new string[] {""} ;
         A704ComFecPago = DateTime.MinValue;
         A724ComRefFec = DateTime.MinValue;
         A248ComFec = DateTime.MinValue;
         AV40TipCod2 = "";
         AV19Fecha = DateTime.MinValue;
         GXt_char3 = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV27Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_comprasproveedorespdf__default(),
            new Object[][] {
                new Object[] {
               P00AR2_A149TipCod, P00AR2_A1910TipDsc
               }
               , new Object[] {
               P00AR3_A298TprvCod, P00AR3_A1941TprvDsc
               }
               , new Object[] {
               P00AR4_A244PrvCod
               }
               , new Object[] {
               P00AR5_A180MonCod, P00AR5_A1234MonDsc
               }
               , new Object[] {
               P00AR6_A243ComCod, P00AR6_A52LinCod, P00AR6_n52LinCod, P00AR6_A247PrvDsc, P00AR6_A244PrvCod, P00AR6_A707ComFReg, P00AR6_A697ComDOrdTip, P00AR6_A253ComDCueCod, P00AR6_n253ComDCueCod, P00AR6_A254ComDProCod,
               P00AR6_n254ComDProCod, P00AR6_A1158LinStk, P00AR6_A139PaiCod, P00AR6_A149TipCod, P00AR6_A298TprvCod, P00AR6_A250ComDItem, P00AR6_A251ComDOrdCod
               }
               , new Object[] {
               P00AR7_A243ComCod, P00AR7_A52LinCod, P00AR7_n52LinCod, P00AR7_A244PrvCod, P00AR7_A707ComFReg, P00AR7_A697ComDOrdTip, P00AR7_A253ComDCueCod, P00AR7_n253ComDCueCod, P00AR7_A254ComDProCod, P00AR7_n254ComDProCod,
               P00AR7_A1158LinStk, P00AR7_A139PaiCod, P00AR7_A149TipCod, P00AR7_A298TprvCod, P00AR7_A704ComFecPago, P00AR7_A724ComRefFec, P00AR7_A246ComMon, P00AR7_A511TipSigno, P00AR7_A248ComFec, P00AR7_A689ComDDct,
               P00AR7_A686ComDPre, P00AR7_A685ComDCant, P00AR7_A250ComDItem, P00AR7_A251ComDOrdCod
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
      private short AV26Flag90 ;
      private short A511TipSigno ;
      private int AV49TPrvCod ;
      private int AV12DocMonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A298TprvCod ;
      private int A180MonCod ;
      private int A52LinCod ;
      private int AV62GXV1 ;
      private int Gx_OldLine ;
      private int A246ComMon ;
      private int AV28MonCod ;
      private int GXt_int2 ;
      private decimal AV44TotalGeneral ;
      private decimal AV45TotalGeneralME ;
      private decimal AV47TotalVenta ;
      private decimal AV48TotalVentaME ;
      private decimal AV43Total ;
      private decimal AV46TotalME ;
      private decimal AV37SumPorcent ;
      private decimal AV30Porcentaje ;
      private decimal AV31Porcentaje2 ;
      private decimal A689ComDDct ;
      private decimal A686ComDPre ;
      private decimal A685ComDCant ;
      private decimal A688ComDSub ;
      private decimal A687ComDDescuento ;
      private decimal A684ComDTot ;
      private decimal AV8Cambio ;
      private decimal GXt_decimal1 ;
      private decimal AV42Tot ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV32PrvCod ;
      private string AV39TipCod ;
      private string AV29PaiCod ;
      private string AV15Empresa ;
      private string AV14EmpDir ;
      private string AV16EmpRUC ;
      private string AV33Ruta ;
      private string AV21Filtro1 ;
      private string AV22Filtro2 ;
      private string AV23Filtro3 ;
      private string AV24Filtro4 ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private string A1941TprvDsc ;
      private string A244PrvCod ;
      private string A1234MonDsc ;
      private string AV25Filtro5 ;
      private string A139PaiCod ;
      private string A254ComDProCod ;
      private string A253ComDCueCod ;
      private string A243ComCod ;
      private string A247PrvDsc ;
      private string A251ComDOrdCod ;
      private string AV10DocCliCod ;
      private string AV11DocCliDsc ;
      private string AV40TipCod2 ;
      private string GXt_char3 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV18FDesde ;
      private DateTime AV20FHasta ;
      private DateTime A707ComFReg ;
      private DateTime A704ComFecPago ;
      private DateTime A724ComRefFec ;
      private DateTime A248ComFec ;
      private DateTime AV19Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKAR7 ;
      private bool n52LinCod ;
      private bool n253ComDCueCod ;
      private bool n254ComDProCod ;
      private bool returnInSub ;
      private string AV41Tipo ;
      private string AV52Logo_GXI ;
      private string A697ComDOrdTip ;
      private string AV27Logo ;
      private string Logo ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TPrvCod ;
      private string aP1_PrvCod ;
      private string aP2_TipCod ;
      private string aP3_PaiCod ;
      private DateTime aP4_FDesde ;
      private DateTime aP5_FHasta ;
      private int aP6_DocMonCod ;
      private string aP7_Tipo ;
      private IDataStoreProvider pr_default ;
      private string[] P00AR2_A149TipCod ;
      private string[] P00AR2_A1910TipDsc ;
      private int[] P00AR3_A298TprvCod ;
      private string[] P00AR3_A1941TprvDsc ;
      private string[] P00AR4_A244PrvCod ;
      private int[] P00AR5_A180MonCod ;
      private string[] P00AR5_A1234MonDsc ;
      private string[] P00AR6_A243ComCod ;
      private int[] P00AR6_A52LinCod ;
      private bool[] P00AR6_n52LinCod ;
      private string[] P00AR6_A247PrvDsc ;
      private string[] P00AR6_A244PrvCod ;
      private DateTime[] P00AR6_A707ComFReg ;
      private string[] P00AR6_A697ComDOrdTip ;
      private string[] P00AR6_A253ComDCueCod ;
      private bool[] P00AR6_n253ComDCueCod ;
      private string[] P00AR6_A254ComDProCod ;
      private bool[] P00AR6_n254ComDProCod ;
      private short[] P00AR6_A1158LinStk ;
      private string[] P00AR6_A139PaiCod ;
      private string[] P00AR6_A149TipCod ;
      private int[] P00AR6_A298TprvCod ;
      private short[] P00AR6_A250ComDItem ;
      private string[] P00AR6_A251ComDOrdCod ;
      private string[] P00AR7_A243ComCod ;
      private int[] P00AR7_A52LinCod ;
      private bool[] P00AR7_n52LinCod ;
      private string[] P00AR7_A244PrvCod ;
      private DateTime[] P00AR7_A707ComFReg ;
      private string[] P00AR7_A697ComDOrdTip ;
      private string[] P00AR7_A253ComDCueCod ;
      private bool[] P00AR7_n253ComDCueCod ;
      private string[] P00AR7_A254ComDProCod ;
      private bool[] P00AR7_n254ComDProCod ;
      private short[] P00AR7_A1158LinStk ;
      private string[] P00AR7_A139PaiCod ;
      private string[] P00AR7_A149TipCod ;
      private int[] P00AR7_A298TprvCod ;
      private DateTime[] P00AR7_A704ComFecPago ;
      private DateTime[] P00AR7_A724ComRefFec ;
      private int[] P00AR7_A246ComMon ;
      private short[] P00AR7_A511TipSigno ;
      private DateTime[] P00AR7_A248ComFec ;
      private decimal[] P00AR7_A689ComDDct ;
      private decimal[] P00AR7_A686ComDPre ;
      private decimal[] P00AR7_A685ComDCant ;
      private short[] P00AR7_A250ComDItem ;
      private string[] P00AR7_A251ComDOrdCod ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV34SDTComprasProveedor ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV35SDTComprasProveedorITem ;
   }

   public class r_comprasproveedorespdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AR6( IGxContext context ,
                                             int AV49TPrvCod ,
                                             string AV32PrvCod ,
                                             string AV39TipCod ,
                                             string AV29PaiCod ,
                                             string AV41Tipo ,
                                             int A298TprvCod ,
                                             string A244PrvCod ,
                                             string A149TipCod ,
                                             string A139PaiCod ,
                                             short A1158LinStk ,
                                             string A254ComDProCod ,
                                             string A253ComDCueCod ,
                                             string A697ComDOrdTip ,
                                             DateTime A707ComFReg ,
                                             DateTime AV18FDesde ,
                                             DateTime AV20FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[ComCod], T3.[LinCod], T5.[PrvDsc], T1.[PrvCod], T5.[ComFReg], T1.[ComDOrdTip], T1.[ComDCueCod], T1.[ComDProCod] AS ComDProCod, T4.[LinStk], T2.[PaiCod], T1.[TipCod], T2.[TprvCod], T1.[ComDItem], T1.[ComDOrdCod] FROM (((([CPCOMPRASDET] T1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = T1.[PrvCod]) LEFT JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ComDProCod]) LEFT JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T3.[LinCod]) INNER JOIN [CPCOMPRAS] T5 ON T5.[TipCod] = T1.[TipCod] AND T5.[ComCod] = T1.[ComCod] AND T5.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(T5.[ComFReg] >= @AV18FDesde and T5.[ComFReg] <= @AV20FHasta)");
         if ( ! (0==AV49TPrvCod) )
         {
            AddWhere(sWhereString, "(T2.[TprvCod] = @AV49TPrvCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV32PrvCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[TipCod] = @AV39TipCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29PaiCod)) )
         {
            AddWhere(sWhereString, "(T2.[PaiCod] = @AV29PaiCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV41Tipo, "P") == 0 )
         {
            AddWhere(sWhereString, "(T4.[LinStk] = 1 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         if ( StringUtil.StrCmp(AV41Tipo, "S") == 0 )
         {
            AddWhere(sWhereString, "(T4.[LinStk] = 0 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         if ( StringUtil.StrCmp(AV41Tipo, "G") == 0 )
         {
            AddWhere(sWhereString, "(Not (T1.[ComDCueCod] = '') and (T1.[ComDOrdTip] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PrvCod], T5.[PrvDsc]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00AR7( IGxContext context ,
                                             int AV49TPrvCod ,
                                             string AV32PrvCod ,
                                             string AV39TipCod ,
                                             string AV29PaiCod ,
                                             string AV41Tipo ,
                                             int A298TprvCod ,
                                             string A244PrvCod ,
                                             string A149TipCod ,
                                             string A139PaiCod ,
                                             short A1158LinStk ,
                                             string A254ComDProCod ,
                                             string A253ComDCueCod ,
                                             string A697ComDOrdTip ,
                                             DateTime A707ComFReg ,
                                             DateTime AV18FDesde ,
                                             DateTime AV20FHasta ,
                                             string AV10DocCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[7];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[ComCod], T3.[LinCod], T1.[PrvCod], T6.[ComFReg], T1.[ComDOrdTip], T1.[ComDCueCod], T1.[ComDProCod] AS ComDProCod, T4.[LinStk], T2.[PaiCod], T1.[TipCod], T2.[TprvCod], T6.[ComFecPago], T6.[ComRefFec], T6.[ComMon], T5.[TipSigno], T6.[ComFec], T1.[ComDDct], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem], T1.[ComDOrdCod] FROM ((((([CPCOMPRASDET] T1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = T1.[PrvCod]) LEFT JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ComDProCod]) LEFT JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T3.[LinCod]) INNER JOIN [CTIPDOC] T5 ON T5.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(T6.[ComFReg] >= @AV18FDesde and T6.[ComFReg] <= @AV20FHasta)");
         AddWhere(sWhereString, "(T1.[PrvCod] = @AV10DocCliCod)");
         if ( ! (0==AV49TPrvCod) )
         {
            AddWhere(sWhereString, "(T2.[TprvCod] = @AV49TPrvCod)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV32PrvCod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[TipCod] = @AV39TipCod)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29PaiCod)) )
         {
            AddWhere(sWhereString, "(T2.[PaiCod] = @AV29PaiCod)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV41Tipo, "P") == 0 )
         {
            AddWhere(sWhereString, "(T4.[LinStk] = 1 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         if ( StringUtil.StrCmp(AV41Tipo, "S") == 0 )
         {
            AddWhere(sWhereString, "(T4.[LinStk] = 0 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         if ( StringUtil.StrCmp(AV41Tipo, "G") == 0 )
         {
            AddWhere(sWhereString, "(Not (T1.[ComDCueCod] = '') and (T1.[ComDOrdTip] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T6.[ComFec]";
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
               case 4 :
                     return conditional_P00AR6(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] );
               case 5 :
                     return conditional_P00AR7(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AR2;
          prmP00AR2 = new Object[] {
          new ParDef("@AV39TipCod",GXType.NChar,3,0)
          };
          Object[] prmP00AR3;
          prmP00AR3 = new Object[] {
          new ParDef("@AV49TPrvCod",GXType.Int32,6,0)
          };
          Object[] prmP00AR4;
          prmP00AR4 = new Object[] {
          new ParDef("@AV32PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AR5;
          prmP00AR5 = new Object[] {
          new ParDef("@AV12DocMonCod",GXType.Int32,6,0)
          };
          Object[] prmP00AR6;
          prmP00AR6 = new Object[] {
          new ParDef("@AV18FDesde",GXType.Date,8,0) ,
          new ParDef("@AV20FHasta",GXType.Date,8,0) ,
          new ParDef("@AV49TPrvCod",GXType.Int32,6,0) ,
          new ParDef("@AV32PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV39TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV29PaiCod",GXType.NChar,4,0)
          };
          Object[] prmP00AR7;
          prmP00AR7 = new Object[] {
          new ParDef("@AV18FDesde",GXType.Date,8,0) ,
          new ParDef("@AV20FHasta",GXType.Date,8,0) ,
          new ParDef("@AV10DocCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV49TPrvCod",GXType.Int32,6,0) ,
          new ParDef("@AV32PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV39TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV29PaiCod",GXType.NChar,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AR2", "SELECT [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipCod] = @AV39TipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AR2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AR3", "SELECT [TprvCod], [TprvDsc] FROM [CTIPOPROVEEDOR] WHERE [TprvCod] = @AV49TPrvCod ORDER BY [TprvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AR3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AR4", "SELECT [PrvCod] FROM [CPPROVEEDORES] WHERE [PrvCod] = @AV32PrvCod ORDER BY [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AR4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AR5", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV12DocMonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AR5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AR6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AR6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AR7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AR7,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 15);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 15);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((short[]) buf[11])[0] = rslt.getShort(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 4);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((int[]) buf[14])[0] = rslt.getInt(12);
                ((short[]) buf[15])[0] = rslt.getShort(13);
                ((string[]) buf[16])[0] = rslt.getString(14, 10);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 15);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 15);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((short[]) buf[10])[0] = rslt.getShort(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 4);
                ((string[]) buf[12])[0] = rslt.getString(10, 3);
                ((int[]) buf[13])[0] = rslt.getInt(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(12);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(13);
                ((int[]) buf[16])[0] = rslt.getInt(14);
                ((short[]) buf[17])[0] = rslt.getShort(15);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(16);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(19);
                ((short[]) buf[22])[0] = rslt.getShort(20);
                ((string[]) buf[23])[0] = rslt.getString(21, 10);
                return;
       }
    }

 }

}
