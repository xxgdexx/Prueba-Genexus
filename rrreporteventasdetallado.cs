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
   public class rrreporteventasdetallado : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrreporteventasdetallado.aspx")), "rrreporteventasdetallado.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrreporteventasdetallado.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "Lincod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV45Lincod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV63SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
                  AV35FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV84VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
                  AV57ProdCod = GetPar( "ProdCod");
                  AV13CliCod = GetPar( "CliCod");
                  AV52MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV36FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV38FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV54Opc = (short)(NumberUtil.Val( GetPar( "Opc"), "."));
                  AV69Tipo = GetPar( "Tipo");
                  AV86ZonCod = (int)(NumberUtil.Val( GetPar( "ZonCod"), "."));
                  AV70TipoLinea = (short)(NumberUtil.Val( GetPar( "TipoLinea"), "."));
                  AV65TieCod = (int)(NumberUtil.Val( GetPar( "TieCod"), "."));
                  AV66TipCCod = (int)(NumberUtil.Val( GetPar( "TipCCod"), "."));
                  AV12CheckRec = (short)(NumberUtil.Val( GetPar( "CheckRec"), "."));
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

      public rrreporteventasdetallado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrreporteventasdetallado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_Lincod ,
                           ref int aP1_SublCod ,
                           ref int aP2_FamCod ,
                           ref int aP3_VenCod ,
                           ref string aP4_ProdCod ,
                           ref string aP5_CliCod ,
                           ref int aP6_MonCod ,
                           ref DateTime aP7_FDesde ,
                           ref DateTime aP8_FHasta ,
                           ref short aP9_Opc ,
                           ref string aP10_Tipo ,
                           ref int aP11_ZonCod ,
                           ref short aP12_TipoLinea ,
                           ref int aP13_TieCod ,
                           ref int aP14_TipCCod ,
                           ref short aP15_CheckRec )
      {
         this.AV45Lincod = aP0_Lincod;
         this.AV63SublCod = aP1_SublCod;
         this.AV35FamCod = aP2_FamCod;
         this.AV84VenCod = aP3_VenCod;
         this.AV57ProdCod = aP4_ProdCod;
         this.AV13CliCod = aP5_CliCod;
         this.AV52MonCod = aP6_MonCod;
         this.AV36FDesde = aP7_FDesde;
         this.AV38FHasta = aP8_FHasta;
         this.AV54Opc = aP9_Opc;
         this.AV69Tipo = aP10_Tipo;
         this.AV86ZonCod = aP11_ZonCod;
         this.AV70TipoLinea = aP12_TipoLinea;
         this.AV65TieCod = aP13_TieCod;
         this.AV66TipCCod = aP14_TipCCod;
         this.AV12CheckRec = aP15_CheckRec;
         initialize();
         executePrivate();
         aP0_Lincod=this.AV45Lincod;
         aP1_SublCod=this.AV63SublCod;
         aP2_FamCod=this.AV35FamCod;
         aP3_VenCod=this.AV84VenCod;
         aP4_ProdCod=this.AV57ProdCod;
         aP5_CliCod=this.AV13CliCod;
         aP6_MonCod=this.AV52MonCod;
         aP7_FDesde=this.AV36FDesde;
         aP8_FHasta=this.AV38FHasta;
         aP9_Opc=this.AV54Opc;
         aP10_Tipo=this.AV69Tipo;
         aP11_ZonCod=this.AV86ZonCod;
         aP12_TipoLinea=this.AV70TipoLinea;
         aP13_TieCod=this.AV65TieCod;
         aP14_TipCCod=this.AV66TipCCod;
         aP15_CheckRec=this.AV12CheckRec;
      }

      public short executeUdp( ref int aP0_Lincod ,
                               ref int aP1_SublCod ,
                               ref int aP2_FamCod ,
                               ref int aP3_VenCod ,
                               ref string aP4_ProdCod ,
                               ref string aP5_CliCod ,
                               ref int aP6_MonCod ,
                               ref DateTime aP7_FDesde ,
                               ref DateTime aP8_FHasta ,
                               ref short aP9_Opc ,
                               ref string aP10_Tipo ,
                               ref int aP11_ZonCod ,
                               ref short aP12_TipoLinea ,
                               ref int aP13_TieCod ,
                               ref int aP14_TipCCod )
      {
         execute(ref aP0_Lincod, ref aP1_SublCod, ref aP2_FamCod, ref aP3_VenCod, ref aP4_ProdCod, ref aP5_CliCod, ref aP6_MonCod, ref aP7_FDesde, ref aP8_FHasta, ref aP9_Opc, ref aP10_Tipo, ref aP11_ZonCod, ref aP12_TipoLinea, ref aP13_TieCod, ref aP14_TipCCod, ref aP15_CheckRec);
         return AV12CheckRec ;
      }

      public void executeSubmit( ref int aP0_Lincod ,
                                 ref int aP1_SublCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_VenCod ,
                                 ref string aP4_ProdCod ,
                                 ref string aP5_CliCod ,
                                 ref int aP6_MonCod ,
                                 ref DateTime aP7_FDesde ,
                                 ref DateTime aP8_FHasta ,
                                 ref short aP9_Opc ,
                                 ref string aP10_Tipo ,
                                 ref int aP11_ZonCod ,
                                 ref short aP12_TipoLinea ,
                                 ref int aP13_TieCod ,
                                 ref int aP14_TipCCod ,
                                 ref short aP15_CheckRec )
      {
         rrreporteventasdetallado objrrreporteventasdetallado;
         objrrreporteventasdetallado = new rrreporteventasdetallado();
         objrrreporteventasdetallado.AV45Lincod = aP0_Lincod;
         objrrreporteventasdetallado.AV63SublCod = aP1_SublCod;
         objrrreporteventasdetallado.AV35FamCod = aP2_FamCod;
         objrrreporteventasdetallado.AV84VenCod = aP3_VenCod;
         objrrreporteventasdetallado.AV57ProdCod = aP4_ProdCod;
         objrrreporteventasdetallado.AV13CliCod = aP5_CliCod;
         objrrreporteventasdetallado.AV52MonCod = aP6_MonCod;
         objrrreporteventasdetallado.AV36FDesde = aP7_FDesde;
         objrrreporteventasdetallado.AV38FHasta = aP8_FHasta;
         objrrreporteventasdetallado.AV54Opc = aP9_Opc;
         objrrreporteventasdetallado.AV69Tipo = aP10_Tipo;
         objrrreporteventasdetallado.AV86ZonCod = aP11_ZonCod;
         objrrreporteventasdetallado.AV70TipoLinea = aP12_TipoLinea;
         objrrreporteventasdetallado.AV65TieCod = aP13_TieCod;
         objrrreporteventasdetallado.AV66TipCCod = aP14_TipCCod;
         objrrreporteventasdetallado.AV12CheckRec = aP15_CheckRec;
         objrrreporteventasdetallado.context.SetSubmitInitialConfig(context);
         objrrreporteventasdetallado.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrreporteventasdetallado);
         aP0_Lincod=this.AV45Lincod;
         aP1_SublCod=this.AV63SublCod;
         aP2_FamCod=this.AV35FamCod;
         aP3_VenCod=this.AV84VenCod;
         aP4_ProdCod=this.AV57ProdCod;
         aP5_CliCod=this.AV13CliCod;
         aP6_MonCod=this.AV52MonCod;
         aP7_FDesde=this.AV36FDesde;
         aP8_FHasta=this.AV38FHasta;
         aP9_Opc=this.AV54Opc;
         aP10_Tipo=this.AV69Tipo;
         aP11_ZonCod=this.AV86ZonCod;
         aP12_TipoLinea=this.AV70TipoLinea;
         aP13_TieCod=this.AV65TieCod;
         aP14_TipCCod=this.AV66TipCCod;
         aP15_CheckRec=this.AV12CheckRec;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrreporteventasdetallado)stateInfo).executePrivate();
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
            AV32Empresa = AV60Session.Get("Empresa");
            AV31EmpDir = AV60Session.Get("EmpDir");
            AV33EmpRUC = AV60Session.Get("EmpRUC");
            AV59Ruta = AV60Session.Get("RUTA") + "/Logo.jpg";
            AV51Logo = AV59Ruta;
            AV89Logo_GXI = GXDbFile.PathToUrl( AV59Ruta);
            /* Using cursor P00EL2 */
            pr_default.execute(0, new Object[] {AV52MonCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P00EL2_A180MonCod[0];
               A1234MonDsc = P00EL2_A1234MonDsc[0];
               AV53Moneda = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV81TotGCant = 0.0000m;
            AV82TotGImp = 0.00m;
            AV80TotGCanEqv = 0.00m;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV65TieCod ,
                                                 AV84VenCod ,
                                                 AV13CliCod ,
                                                 AV69Tipo ,
                                                 AV57ProdCod ,
                                                 AV45Lincod ,
                                                 AV63SublCod ,
                                                 AV35FamCod ,
                                                 AV86ZonCod ,
                                                 AV66TipCCod ,
                                                 AV12CheckRec ,
                                                 A178TieCod ,
                                                 A227DocVendCod ,
                                                 A231DocCliCod ,
                                                 A946DocTipo ,
                                                 A28ProdCod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A158ZonCod ,
                                                 A159TipCCod ,
                                                 A149TipCod ,
                                                 A232DocFec ,
                                                 AV36FDesde ,
                                                 AV38FHasta ,
                                                 A941DocSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00EL3 */
            pr_default.execute(1, new Object[] {AV36FDesde, AV38FHasta, AV65TieCod, AV84VenCod, AV13CliCod, AV69Tipo, AV57ProdCod, AV45Lincod, AV63SublCod, AV35FamCod, AV86ZonCod, AV66TipCCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRKEL4 = false;
               A24DocNum = P00EL3_A24DocNum[0];
               A231DocCliCod = P00EL3_A231DocCliCod[0];
               A227DocVendCod = P00EL3_A227DocVendCod[0];
               A149TipCod = P00EL3_A149TipCod[0];
               A159TipCCod = P00EL3_A159TipCCod[0];
               n159TipCCod = P00EL3_n159TipCCod[0];
               A158ZonCod = P00EL3_A158ZonCod[0];
               n158ZonCod = P00EL3_n158ZonCod[0];
               A50FamCod = P00EL3_A50FamCod[0];
               n50FamCod = P00EL3_n50FamCod[0];
               A51SublCod = P00EL3_A51SublCod[0];
               n51SublCod = P00EL3_n51SublCod[0];
               A52LinCod = P00EL3_A52LinCod[0];
               A28ProdCod = P00EL3_A28ProdCod[0];
               A946DocTipo = P00EL3_A946DocTipo[0];
               A941DocSts = P00EL3_A941DocSts[0];
               A232DocFec = P00EL3_A232DocFec[0];
               A178TieCod = P00EL3_A178TieCod[0];
               n178TieCod = P00EL3_n178TieCod[0];
               A895DocDCan = P00EL3_A895DocDCan[0];
               A953DocVendDsc = P00EL3_A953DocVendDsc[0];
               A233DocItem = P00EL3_A233DocItem[0];
               A231DocCliCod = P00EL3_A231DocCliCod[0];
               A227DocVendCod = P00EL3_A227DocVendCod[0];
               A946DocTipo = P00EL3_A946DocTipo[0];
               A941DocSts = P00EL3_A941DocSts[0];
               A232DocFec = P00EL3_A232DocFec[0];
               A178TieCod = P00EL3_A178TieCod[0];
               n178TieCod = P00EL3_n178TieCod[0];
               A159TipCCod = P00EL3_A159TipCCod[0];
               n159TipCCod = P00EL3_n159TipCCod[0];
               A158ZonCod = P00EL3_A158ZonCod[0];
               n158ZonCod = P00EL3_n158ZonCod[0];
               A953DocVendDsc = P00EL3_A953DocVendDsc[0];
               A50FamCod = P00EL3_A50FamCod[0];
               n50FamCod = P00EL3_n50FamCod[0];
               A51SublCod = P00EL3_A51SublCod[0];
               n51SublCod = P00EL3_n51SublCod[0];
               A52LinCod = P00EL3_A52LinCod[0];
               while ( (pr_default.getStatus(1) != 101) && ( P00EL3_A227DocVendCod[0] == A227DocVendCod ) )
               {
                  BRKEL4 = false;
                  A24DocNum = P00EL3_A24DocNum[0];
                  A231DocCliCod = P00EL3_A231DocCliCod[0];
                  A149TipCod = P00EL3_A149TipCod[0];
                  A233DocItem = P00EL3_A233DocItem[0];
                  A231DocCliCod = P00EL3_A231DocCliCod[0];
                  BRKEL4 = true;
                  pr_default.readNext(1);
               }
               AV84VenCod = A227DocVendCod;
               AV85VenDsc = A953DocVendDsc;
               AV79TotCant = 0.0000m;
               AV83TotImp = 0.00m;
               AV78TotCanEqv = 0.00m;
               HEL0( false, 21) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Vendedor : ", 10, Gx_line+3, 85, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85VenDsc, "")), 94, Gx_line+3, 720, Gx_line+19, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
               /* Execute user subroutine: 'AGRUPALINEAS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               AV81TotGCant = (decimal)(AV81TotGCant+AV79TotCant);
               AV82TotGImp = (decimal)(AV82TotGImp+AV83TotImp);
               AV80TotGCanEqv = (decimal)(AV80TotGCanEqv+AV78TotCanEqv);
               AV39Filtro1 = "Vendedor : " + StringUtil.Trim( AV85VenDsc);
               HEL0( false, 32) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Filtro1, "")), 368, Gx_line+11, 850, Gx_line+27, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(765, Gx_line+3, 1104, Gx_line+3, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV79TotCant, "ZZZZ,ZZZ,ZZ9.9999")), 827, Gx_line+12, 934, Gx_line+27, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV83TotImp, "ZZZZZZ,ZZZ,ZZ9.99")), 904, Gx_line+12, 1011, Gx_line+27, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV78TotCanEqv, "ZZZZZZ,ZZZ,ZZ9.99")), 1011, Gx_line+12, 1100, Gx_line+27, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+32);
               if ( ! BRKEL4 )
               {
                  BRKEL4 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
            HEL0( false, 52) ;
            getPrinter().GxDrawLine(765, Gx_line+9, 1104, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 649, Gx_line+15, 729, Gx_line+29, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV81TotGCant, "ZZZZ,ZZZ,ZZ9.9999")), 827, Gx_line+15, 934, Gx_line+30, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV82TotGImp, "ZZZZZZ,ZZZ,ZZ9.99")), 904, Gx_line+15, 1011, Gx_line+30, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV80TotGCanEqv, "ZZZZZZ,ZZZ,ZZ9.99")), 1011, Gx_line+15, 1100, Gx_line+30, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HEL0( true, 0) ;
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
         /* 'AGRUPALINEAS' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV45Lincod ,
                                              A52LinCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00EL4 */
         pr_default.execute(2, new Object[] {AV45Lincod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A52LinCod = P00EL4_A52LinCod[0];
            A1153LinDsc = P00EL4_A1153LinDsc[0];
            AV47LineaCod = A52LinCod;
            AV50LineaNom = StringUtil.Trim( A1153LinDsc);
            AV46LineaCant = 0.0000m;
            AV49LineaImp = 0.00m;
            AV48LineaEQV = 0.00m;
            /* Execute user subroutine: 'VALIDALINEA' */
            S126 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            if ( AV44Flag == 1 )
            {
               if ( AV70TipoLinea == 0 )
               {
                  HEL0( false, 19) ;
                  getPrinter().GxAttris("Arial", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV47LineaCod), "ZZZZZ9")), 10, Gx_line+2, 49, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50LineaNom, "")), 56, Gx_line+2, 578, Gx_line+18, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
               /* Execute user subroutine: 'MUESTRADETALLES' */
               S136 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV70TipoLinea == 0 )
               {
                  HEL0( false, 34) ;
                  getPrinter().GxAttris("Arial", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50LineaNom, "")), 313, Gx_line+11, 835, Gx_line+27, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(765, Gx_line+4, 1104, Gx_line+4, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46LineaCant, "ZZZZ,ZZZ,ZZ9.9999")), 827, Gx_line+11, 934, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49LineaImp, "ZZZZZZ,ZZZ,ZZ9.99")), 904, Gx_line+11, 1011, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48LineaEQV, "ZZZZZZ,ZZZ,ZZ9.99")), 1011, Gx_line+11, 1100, Gx_line+26, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+34);
               }
               else
               {
                  HEL0( false, 23) ;
                  getPrinter().GxAttris("Arial", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50LineaNom, "")), 15, Gx_line+4, 537, Gx_line+20, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46LineaCant, "ZZZZ,ZZZ,ZZ9.9999")), 827, Gx_line+4, 934, Gx_line+19, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49LineaImp, "ZZZZZZ,ZZZ,ZZ9.99")), 904, Gx_line+4, 1011, Gx_line+19, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48LineaEQV, "ZZZZZZ,ZZZ,ZZ9.99")), 1011, Gx_line+4, 1100, Gx_line+19, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+23);
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S136( )
      {
         /* 'MUESTRADETALLES' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV65TieCod ,
                                              AV13CliCod ,
                                              AV69Tipo ,
                                              AV57ProdCod ,
                                              AV63SublCod ,
                                              AV35FamCod ,
                                              AV86ZonCod ,
                                              AV66TipCCod ,
                                              AV12CheckRec ,
                                              A178TieCod ,
                                              A231DocCliCod ,
                                              A946DocTipo ,
                                              A28ProdCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A158ZonCod ,
                                              A159TipCCod ,
                                              A149TipCod ,
                                              A232DocFec ,
                                              AV36FDesde ,
                                              AV38FHasta ,
                                              A941DocSts ,
                                              A227DocVendCod ,
                                              AV84VenCod ,
                                              A52LinCod ,
                                              AV47LineaCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00EL5 */
         pr_default.execute(3, new Object[] {AV36FDesde, AV38FHasta, AV84VenCod, AV47LineaCod, AV65TieCod, AV13CliCod, AV69Tipo, AV57ProdCod, AV63SublCod, AV35FamCod, AV86ZonCod, AV66TipCCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A149TipCod = P00EL5_A149TipCod[0];
            A159TipCCod = P00EL5_A159TipCCod[0];
            n159TipCCod = P00EL5_n159TipCCod[0];
            A158ZonCod = P00EL5_A158ZonCod[0];
            n158ZonCod = P00EL5_n158ZonCod[0];
            A50FamCod = P00EL5_A50FamCod[0];
            n50FamCod = P00EL5_n50FamCod[0];
            A51SublCod = P00EL5_A51SublCod[0];
            n51SublCod = P00EL5_n51SublCod[0];
            A28ProdCod = P00EL5_A28ProdCod[0];
            A52LinCod = P00EL5_A52LinCod[0];
            A946DocTipo = P00EL5_A946DocTipo[0];
            A941DocSts = P00EL5_A941DocSts[0];
            A232DocFec = P00EL5_A232DocFec[0];
            A231DocCliCod = P00EL5_A231DocCliCod[0];
            A227DocVendCod = P00EL5_A227DocVendCod[0];
            A178TieCod = P00EL5_A178TieCod[0];
            n178TieCod = P00EL5_n178TieCod[0];
            A24DocNum = P00EL5_A24DocNum[0];
            A230DocMonCod = P00EL5_A230DocMonCod[0];
            A226DocMovCod = P00EL5_A226DocMovCod[0];
            A1702ProdPeso = P00EL5_A1702ProdPeso[0];
            A511TipSigno = P00EL5_A511TipSigno[0];
            A899DocDcto = P00EL5_A899DocDcto[0];
            A929DocFecRef = P00EL5_A929DocFecRef[0];
            A882DocAnticipos = P00EL5_A882DocAnticipos[0];
            A892DocDTot = P00EL5_A892DocDTot[0];
            A895DocDCan = P00EL5_A895DocDCan[0];
            A55ProdDsc = P00EL5_A55ProdDsc[0];
            A306TipAbr = P00EL5_A306TipAbr[0];
            A887DocCliDsc = P00EL5_A887DocCliDsc[0];
            A233DocItem = P00EL5_A233DocItem[0];
            A511TipSigno = P00EL5_A511TipSigno[0];
            A306TipAbr = P00EL5_A306TipAbr[0];
            A50FamCod = P00EL5_A50FamCod[0];
            n50FamCod = P00EL5_n50FamCod[0];
            A51SublCod = P00EL5_A51SublCod[0];
            n51SublCod = P00EL5_n51SublCod[0];
            A52LinCod = P00EL5_A52LinCod[0];
            A1702ProdPeso = P00EL5_A1702ProdPeso[0];
            A55ProdDsc = P00EL5_A55ProdDsc[0];
            A946DocTipo = P00EL5_A946DocTipo[0];
            A941DocSts = P00EL5_A941DocSts[0];
            A232DocFec = P00EL5_A232DocFec[0];
            A231DocCliCod = P00EL5_A231DocCliCod[0];
            A227DocVendCod = P00EL5_A227DocVendCod[0];
            A178TieCod = P00EL5_A178TieCod[0];
            n178TieCod = P00EL5_n178TieCod[0];
            A230DocMonCod = P00EL5_A230DocMonCod[0];
            A226DocMovCod = P00EL5_A226DocMovCod[0];
            A899DocDcto = P00EL5_A899DocDcto[0];
            A929DocFecRef = P00EL5_A929DocFecRef[0];
            A882DocAnticipos = P00EL5_A882DocAnticipos[0];
            A159TipCCod = P00EL5_A159TipCCod[0];
            n159TipCCod = P00EL5_n159TipCCod[0];
            A158ZonCod = P00EL5_A158ZonCod[0];
            n158ZonCod = P00EL5_n158ZonCod[0];
            A887DocCliDsc = P00EL5_A887DocCliDsc[0];
            AV67TipCod = A149TipCod;
            AV28DocNum = A24DocNum;
            AV23DocFec = A232DocFec;
            AV26DocMonCod = A230DocMonCod;
            AV27DocMovCod = A226DocMovCod;
            AV58ProdPeso = A1702ProdPeso;
            AV71TipSigno = A511TipSigno;
            AV20DocDcto = A899DocDcto;
            AV24DocFecRef = A929DocFecRef;
            AV15DocAnticipos = NumberUtil.Round( A882DocAnticipos, 2);
            AV22DocDTot = NumberUtil.Round( A892DocDTot, 2);
            if ( ! (Convert.ToDecimal(0)==AV15DocAnticipos) )
            {
               /* Execute user subroutine: 'SUBTOTAL' */
               S147 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  returnInSub = true;
                  if (true) return;
               }
               AV56Porcentaje = NumberUtil.Round( AV22DocDTot/ (decimal)(AV64SubTotal), 10);
               AV8Anticipo = NumberUtil.Round( AV56Porcentaje*AV15DocAnticipos, 2);
            }
            else
            {
               AV56Porcentaje = 0.00m;
               AV8Anticipo = 0.00m;
               AV64SubTotal = 0.00m;
            }
            if ( AV52MonCod == 1 )
            {
               AV14Descuento = (decimal)(NumberUtil.Round( (A892DocDTot*AV20DocDcto)/ (decimal)(100), 2)*AV71TipSigno);
               AV22DocDTot = (decimal)(NumberUtil.Round( A892DocDTot, 2)*AV71TipSigno);
               AV15DocAnticipos = (decimal)(NumberUtil.Round( AV8Anticipo, 2)*AV71TipSigno);
               if ( AV26DocMonCod == 2 )
               {
                  GXt_decimal1 = AV72TipVenta;
                  GXt_int2 = 2;
                  GXt_char3 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV23DocFec, ref  GXt_char3, out  GXt_decimal1) ;
                  AV72TipVenta = GXt_decimal1;
                  if ( ( StringUtil.StrCmp(AV67TipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV67TipCod, "ND") == 0 ) )
                  {
                     GXt_decimal1 = AV72TipVenta;
                     GXt_int2 = 2;
                     GXt_char3 = "V";
                     new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV24DocFecRef, ref  GXt_char3, out  GXt_decimal1) ;
                     AV72TipVenta = GXt_decimal1;
                  }
                  AV22DocDTot = NumberUtil.Round( AV22DocDTot*AV72TipVenta, 2);
                  AV15DocAnticipos = NumberUtil.Round( AV15DocAnticipos*AV72TipVenta, 2);
               }
            }
            else
            {
               AV14Descuento = (decimal)(NumberUtil.Round( (A892DocDTot*AV20DocDcto)/ (decimal)(100), 2)*AV71TipSigno);
               AV22DocDTot = (decimal)(NumberUtil.Round( A892DocDTot, 2)*AV71TipSigno);
               AV15DocAnticipos = (decimal)(NumberUtil.Round( AV8Anticipo, 2)*AV71TipSigno);
               if ( AV26DocMonCod == 1 )
               {
                  GXt_decimal1 = AV72TipVenta;
                  GXt_int2 = 2;
                  GXt_char3 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV23DocFec, ref  GXt_char3, out  GXt_decimal1) ;
                  AV72TipVenta = GXt_decimal1;
                  if ( ( StringUtil.StrCmp(AV67TipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV67TipCod, "ND") == 0 ) )
                  {
                     GXt_decimal1 = AV72TipVenta;
                     GXt_int2 = 2;
                     GXt_char3 = "V";
                     new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV24DocFecRef, ref  GXt_char3, out  GXt_decimal1) ;
                     AV72TipVenta = GXt_decimal1;
                  }
                  AV22DocDTot = NumberUtil.Round( AV22DocDTot/ (decimal)(AV72TipVenta), 2);
                  AV15DocAnticipos = NumberUtil.Round( AV15DocAnticipos/ (decimal)(AV72TipVenta), 2);
               }
            }
            AV22DocDTot = (decimal)(AV22DocDTot-(AV15DocAnticipos+AV14Descuento));
            AV19DocDCan = (decimal)(A895DocDCan*A511TipSigno);
            AV10CanEQV = NumberUtil.Round( AV19DocDCan*AV58ProdPeso, 2);
            if ( ( StringUtil.StrCmp(AV67TipCod, "ND") == 0 ) || ( StringUtil.StrCmp(AV67TipCod, "NC") == 0 ) )
            {
               /* Execute user subroutine: 'VALIDATIPOMOVIMIENTO' */
               S157 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  returnInSub = true;
                  if (true) return;
               }
            }
            if ( AV70TipoLinea == 0 )
            {
               HEL0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A887DocCliDsc, "")), 140, Gx_line+2, 392, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV10CanEQV, "ZZZZZZ,ZZZ,ZZ9.99")), 1011, Gx_line+1, 1100, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Arial", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A232DocFec, "99/99/99"), 4, Gx_line+1, 49, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV22DocDTot, "ZZZZ,ZZZ,ZZ9.99")), 897, Gx_line+1, 1011, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19DocDCan, "ZZZZ,ZZZ,ZZ9.9999")), 827, Gx_line+1, 934, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A231DocCliCod, "")), 56, Gx_line+1, 134, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 391, Gx_line+2, 421, Gx_line+13, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A24DocNum, "")), 422, Gx_line+1, 486, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 504, Gx_line+1, 580, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 582, Gx_line+1, 852, Gx_line+16, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
            AV46LineaCant = (decimal)(AV46LineaCant+AV19DocDCan);
            AV49LineaImp = (decimal)(AV49LineaImp+AV22DocDTot);
            AV48LineaEQV = (decimal)(AV48LineaEQV+AV10CanEQV);
            AV79TotCant = (decimal)(AV79TotCant+AV19DocDCan);
            AV83TotImp = (decimal)(AV83TotImp+AV22DocDTot);
            AV78TotCanEqv = (decimal)(AV78TotCanEqv+AV10CanEQV);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S147( )
      {
         /* 'SUBTOTAL' Routine */
         returnInSub = false;
         /* Using cursor P00EL7 */
         pr_default.execute(4, new Object[] {AV67TipCod, AV28DocNum});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A24DocNum = P00EL7_A24DocNum[0];
            A149TipCod = P00EL7_A149TipCod[0];
            A927DocSubExonerado = P00EL7_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EL7_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EL7_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EL7_A920DocSubAfecto[0];
            A927DocSubExonerado = P00EL7_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EL7_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EL7_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EL7_A920DocSubAfecto[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            AV64SubTotal = NumberUtil.Round( A919DocSub, 2);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void S126( )
      {
         /* 'VALIDALINEA' Routine */
         returnInSub = false;
         AV44Flag = 0;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV65TieCod ,
                                              AV13CliCod ,
                                              AV69Tipo ,
                                              AV57ProdCod ,
                                              AV63SublCod ,
                                              AV35FamCod ,
                                              AV86ZonCod ,
                                              AV66TipCCod ,
                                              AV12CheckRec ,
                                              A178TieCod ,
                                              A231DocCliCod ,
                                              A946DocTipo ,
                                              A28ProdCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A158ZonCod ,
                                              A159TipCCod ,
                                              A149TipCod ,
                                              A232DocFec ,
                                              AV36FDesde ,
                                              AV38FHasta ,
                                              A941DocSts ,
                                              A227DocVendCod ,
                                              AV84VenCod ,
                                              A52LinCod ,
                                              AV47LineaCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00EL8 */
         pr_default.execute(5, new Object[] {AV36FDesde, AV38FHasta, AV84VenCod, AV47LineaCod, AV65TieCod, AV13CliCod, AV69Tipo, AV57ProdCod, AV63SublCod, AV35FamCod, AV86ZonCod, AV66TipCCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A24DocNum = P00EL8_A24DocNum[0];
            A149TipCod = P00EL8_A149TipCod[0];
            A159TipCCod = P00EL8_A159TipCCod[0];
            n159TipCCod = P00EL8_n159TipCCod[0];
            A158ZonCod = P00EL8_A158ZonCod[0];
            n158ZonCod = P00EL8_n158ZonCod[0];
            A50FamCod = P00EL8_A50FamCod[0];
            n50FamCod = P00EL8_n50FamCod[0];
            A51SublCod = P00EL8_A51SublCod[0];
            n51SublCod = P00EL8_n51SublCod[0];
            A28ProdCod = P00EL8_A28ProdCod[0];
            A52LinCod = P00EL8_A52LinCod[0];
            A946DocTipo = P00EL8_A946DocTipo[0];
            A941DocSts = P00EL8_A941DocSts[0];
            A232DocFec = P00EL8_A232DocFec[0];
            A231DocCliCod = P00EL8_A231DocCliCod[0];
            A227DocVendCod = P00EL8_A227DocVendCod[0];
            A178TieCod = P00EL8_A178TieCod[0];
            n178TieCod = P00EL8_n178TieCod[0];
            A511TipSigno = P00EL8_A511TipSigno[0];
            A895DocDCan = P00EL8_A895DocDCan[0];
            A233DocItem = P00EL8_A233DocItem[0];
            A511TipSigno = P00EL8_A511TipSigno[0];
            A946DocTipo = P00EL8_A946DocTipo[0];
            A941DocSts = P00EL8_A941DocSts[0];
            A232DocFec = P00EL8_A232DocFec[0];
            A231DocCliCod = P00EL8_A231DocCliCod[0];
            A227DocVendCod = P00EL8_A227DocVendCod[0];
            A178TieCod = P00EL8_A178TieCod[0];
            n178TieCod = P00EL8_n178TieCod[0];
            A159TipCCod = P00EL8_A159TipCCod[0];
            n159TipCCod = P00EL8_n159TipCCod[0];
            A158ZonCod = P00EL8_A158ZonCod[0];
            n158ZonCod = P00EL8_n158ZonCod[0];
            A50FamCod = P00EL8_A50FamCod[0];
            n50FamCod = P00EL8_n50FamCod[0];
            A51SublCod = P00EL8_A51SublCod[0];
            n51SublCod = P00EL8_n51SublCod[0];
            A52LinCod = P00EL8_A52LinCod[0];
            AV11Cant = (decimal)(A895DocDCan*A511TipSigno);
            AV44Flag = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S157( )
      {
         /* 'VALIDATIPOMOVIMIENTO' Routine */
         returnInSub = false;
         /* Using cursor P00EL9 */
         pr_default.execute(6, new Object[] {AV27DocMovCod});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A235MovVCod = P00EL9_A235MovVCod[0];
            A1242MovVAbr = P00EL9_A1242MovVAbr[0];
            if ( ! ( StringUtil.StrCmp(A1242MovVAbr, "SI") == 0 ) )
            {
               AV19DocDCan = 0.00m;
               AV10CanEQV = 0.00m;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
      }

      protected void HEL0( bool bFoot ,
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
               getPrinter().GxDrawText("Reporte de Ventas Detallado", 392, Gx_line+44, 639, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+130, 1106, Gx_line+156, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1028, Gx_line+21, 1075, Gx_line+36, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1014, Gx_line+40, 1074, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1036, Gx_line+59, 1075, Gx_line+74, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 8, Gx_line+136, 43, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Codigo", 516, Gx_line+136, 557, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 959, Gx_line+136, 1009, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde", 392, Gx_line+73, 432, Gx_line+88, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV36FDesde, "99/99/99"), 452, Gx_line+68, 526, Gx_line+92, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 552, Gx_line+73, 589, Gx_line+88, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV38FHasta, "99/99/99"), 603, Gx_line+68, 677, Gx_line+92, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("R.U.C", 79, Gx_line+136, 110, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 228, Gx_line+136, 270, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T/D", 397, Gx_line+136, 420, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Numero", 435, Gx_line+136, 482, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 666, Gx_line+136, 720, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 876, Gx_line+136, 929, Gx_line+150, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV51Logo)) ? AV89Logo_GXI : AV51Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 16, Gx_line+11, 174, Gx_line+89) ;
               getPrinter().GxDrawText("Equivalencia", 1029, Gx_line+136, 1103, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(54, Gx_line+131, 54, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(136, Gx_line+131, 136, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(391, Gx_line+131, 391, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(419, Gx_line+130, 419, Gx_line+155, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(501, Gx_line+131, 501, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(581, Gx_line+130, 581, Gx_line+155, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(856, Gx_line+131, 856, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(940, Gx_line+131, 940, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1017, Gx_line+131, 1017, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32Empresa, "")), 16, Gx_line+95, 384, Gx_line+113, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33EmpRUC, "")), 16, Gx_line+113, 384, Gx_line+131, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Expresado en", 392, Gx_line+100, 478, Gx_line+115, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Moneda, "")), 495, Gx_line+95, 680, Gx_line+119, 0, 0, 0, 0) ;
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
         add_metrics2( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Arial", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
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
         AV32Empresa = "";
         AV60Session = context.GetSession();
         AV31EmpDir = "";
         AV33EmpRUC = "";
         AV59Ruta = "";
         AV51Logo = "";
         AV89Logo_GXI = "";
         scmdbuf = "";
         P00EL2_A180MonCod = new int[1] ;
         P00EL2_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV53Moneda = "";
         A231DocCliCod = "";
         A946DocTipo = "";
         A28ProdCod = "";
         A149TipCod = "";
         A232DocFec = DateTime.MinValue;
         A941DocSts = "";
         P00EL3_A24DocNum = new string[] {""} ;
         P00EL3_A231DocCliCod = new string[] {""} ;
         P00EL3_A227DocVendCod = new int[1] ;
         P00EL3_A149TipCod = new string[] {""} ;
         P00EL3_A159TipCCod = new int[1] ;
         P00EL3_n159TipCCod = new bool[] {false} ;
         P00EL3_A158ZonCod = new int[1] ;
         P00EL3_n158ZonCod = new bool[] {false} ;
         P00EL3_A50FamCod = new int[1] ;
         P00EL3_n50FamCod = new bool[] {false} ;
         P00EL3_A51SublCod = new int[1] ;
         P00EL3_n51SublCod = new bool[] {false} ;
         P00EL3_A52LinCod = new int[1] ;
         P00EL3_A28ProdCod = new string[] {""} ;
         P00EL3_A946DocTipo = new string[] {""} ;
         P00EL3_A941DocSts = new string[] {""} ;
         P00EL3_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EL3_A178TieCod = new int[1] ;
         P00EL3_n178TieCod = new bool[] {false} ;
         P00EL3_A895DocDCan = new decimal[1] ;
         P00EL3_A953DocVendDsc = new string[] {""} ;
         P00EL3_A233DocItem = new long[1] ;
         A24DocNum = "";
         A953DocVendDsc = "";
         AV85VenDsc = "";
         AV39Filtro1 = "";
         P00EL4_A52LinCod = new int[1] ;
         P00EL4_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         AV50LineaNom = "";
         P00EL5_A149TipCod = new string[] {""} ;
         P00EL5_A159TipCCod = new int[1] ;
         P00EL5_n159TipCCod = new bool[] {false} ;
         P00EL5_A158ZonCod = new int[1] ;
         P00EL5_n158ZonCod = new bool[] {false} ;
         P00EL5_A50FamCod = new int[1] ;
         P00EL5_n50FamCod = new bool[] {false} ;
         P00EL5_A51SublCod = new int[1] ;
         P00EL5_n51SublCod = new bool[] {false} ;
         P00EL5_A28ProdCod = new string[] {""} ;
         P00EL5_A52LinCod = new int[1] ;
         P00EL5_A946DocTipo = new string[] {""} ;
         P00EL5_A941DocSts = new string[] {""} ;
         P00EL5_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EL5_A231DocCliCod = new string[] {""} ;
         P00EL5_A227DocVendCod = new int[1] ;
         P00EL5_A178TieCod = new int[1] ;
         P00EL5_n178TieCod = new bool[] {false} ;
         P00EL5_A24DocNum = new string[] {""} ;
         P00EL5_A230DocMonCod = new int[1] ;
         P00EL5_A226DocMovCod = new int[1] ;
         P00EL5_A1702ProdPeso = new decimal[1] ;
         P00EL5_A511TipSigno = new short[1] ;
         P00EL5_A899DocDcto = new decimal[1] ;
         P00EL5_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P00EL5_A882DocAnticipos = new decimal[1] ;
         P00EL5_A892DocDTot = new decimal[1] ;
         P00EL5_A895DocDCan = new decimal[1] ;
         P00EL5_A55ProdDsc = new string[] {""} ;
         P00EL5_A306TipAbr = new string[] {""} ;
         P00EL5_A887DocCliDsc = new string[] {""} ;
         P00EL5_A233DocItem = new long[1] ;
         A929DocFecRef = DateTime.MinValue;
         A55ProdDsc = "";
         A306TipAbr = "";
         A887DocCliDsc = "";
         AV67TipCod = "";
         AV28DocNum = "";
         AV23DocFec = DateTime.MinValue;
         AV24DocFecRef = DateTime.MinValue;
         GXt_char3 = "";
         P00EL7_A24DocNum = new string[] {""} ;
         P00EL7_A149TipCod = new string[] {""} ;
         P00EL7_A927DocSubExonerado = new decimal[1] ;
         P00EL7_A922DocSubSelectivo = new decimal[1] ;
         P00EL7_A921DocSubInafecto = new decimal[1] ;
         P00EL7_A920DocSubAfecto = new decimal[1] ;
         P00EL8_A24DocNum = new string[] {""} ;
         P00EL8_A149TipCod = new string[] {""} ;
         P00EL8_A159TipCCod = new int[1] ;
         P00EL8_n159TipCCod = new bool[] {false} ;
         P00EL8_A158ZonCod = new int[1] ;
         P00EL8_n158ZonCod = new bool[] {false} ;
         P00EL8_A50FamCod = new int[1] ;
         P00EL8_n50FamCod = new bool[] {false} ;
         P00EL8_A51SublCod = new int[1] ;
         P00EL8_n51SublCod = new bool[] {false} ;
         P00EL8_A28ProdCod = new string[] {""} ;
         P00EL8_A52LinCod = new int[1] ;
         P00EL8_A946DocTipo = new string[] {""} ;
         P00EL8_A941DocSts = new string[] {""} ;
         P00EL8_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EL8_A231DocCliCod = new string[] {""} ;
         P00EL8_A227DocVendCod = new int[1] ;
         P00EL8_A178TieCod = new int[1] ;
         P00EL8_n178TieCod = new bool[] {false} ;
         P00EL8_A511TipSigno = new short[1] ;
         P00EL8_A895DocDCan = new decimal[1] ;
         P00EL8_A233DocItem = new long[1] ;
         P00EL9_A235MovVCod = new int[1] ;
         P00EL9_A1242MovVAbr = new string[] {""} ;
         A1242MovVAbr = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV51Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrreporteventasdetallado__default(),
            new Object[][] {
                new Object[] {
               P00EL2_A180MonCod, P00EL2_A1234MonDsc
               }
               , new Object[] {
               P00EL3_A24DocNum, P00EL3_A231DocCliCod, P00EL3_A227DocVendCod, P00EL3_A149TipCod, P00EL3_A159TipCCod, P00EL3_n159TipCCod, P00EL3_A158ZonCod, P00EL3_n158ZonCod, P00EL3_A50FamCod, P00EL3_n50FamCod,
               P00EL3_A51SublCod, P00EL3_n51SublCod, P00EL3_A52LinCod, P00EL3_A28ProdCod, P00EL3_A946DocTipo, P00EL3_A941DocSts, P00EL3_A232DocFec, P00EL3_A178TieCod, P00EL3_n178TieCod, P00EL3_A895DocDCan,
               P00EL3_A953DocVendDsc, P00EL3_A233DocItem
               }
               , new Object[] {
               P00EL4_A52LinCod, P00EL4_A1153LinDsc
               }
               , new Object[] {
               P00EL5_A149TipCod, P00EL5_A159TipCCod, P00EL5_n159TipCCod, P00EL5_A158ZonCod, P00EL5_n158ZonCod, P00EL5_A50FamCod, P00EL5_n50FamCod, P00EL5_A51SublCod, P00EL5_n51SublCod, P00EL5_A28ProdCod,
               P00EL5_A52LinCod, P00EL5_A946DocTipo, P00EL5_A941DocSts, P00EL5_A232DocFec, P00EL5_A231DocCliCod, P00EL5_A227DocVendCod, P00EL5_A178TieCod, P00EL5_n178TieCod, P00EL5_A24DocNum, P00EL5_A230DocMonCod,
               P00EL5_A226DocMovCod, P00EL5_A1702ProdPeso, P00EL5_A511TipSigno, P00EL5_A899DocDcto, P00EL5_A929DocFecRef, P00EL5_A882DocAnticipos, P00EL5_A892DocDTot, P00EL5_A895DocDCan, P00EL5_A55ProdDsc, P00EL5_A306TipAbr,
               P00EL5_A887DocCliDsc, P00EL5_A233DocItem
               }
               , new Object[] {
               P00EL7_A24DocNum, P00EL7_A149TipCod, P00EL7_A927DocSubExonerado, P00EL7_A922DocSubSelectivo, P00EL7_A921DocSubInafecto, P00EL7_A920DocSubAfecto
               }
               , new Object[] {
               P00EL8_A24DocNum, P00EL8_A149TipCod, P00EL8_A159TipCCod, P00EL8_n159TipCCod, P00EL8_A158ZonCod, P00EL8_n158ZonCod, P00EL8_A50FamCod, P00EL8_n50FamCod, P00EL8_A51SublCod, P00EL8_n51SublCod,
               P00EL8_A28ProdCod, P00EL8_A52LinCod, P00EL8_A946DocTipo, P00EL8_A941DocSts, P00EL8_A232DocFec, P00EL8_A231DocCliCod, P00EL8_A227DocVendCod, P00EL8_A178TieCod, P00EL8_n178TieCod, P00EL8_A511TipSigno,
               P00EL8_A895DocDCan, P00EL8_A233DocItem
               }
               , new Object[] {
               P00EL9_A235MovVCod, P00EL9_A1242MovVAbr
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
      private short AV54Opc ;
      private short AV70TipoLinea ;
      private short AV12CheckRec ;
      private short AV44Flag ;
      private short A511TipSigno ;
      private short AV71TipSigno ;
      private int AV45Lincod ;
      private int AV63SublCod ;
      private int AV35FamCod ;
      private int AV84VenCod ;
      private int AV52MonCod ;
      private int AV86ZonCod ;
      private int AV65TieCod ;
      private int AV66TipCCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int A178TieCod ;
      private int A227DocVendCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A158ZonCod ;
      private int A159TipCCod ;
      private int Gx_OldLine ;
      private int AV47LineaCod ;
      private int A230DocMonCod ;
      private int A226DocMovCod ;
      private int AV26DocMonCod ;
      private int AV27DocMovCod ;
      private int GXt_int2 ;
      private int A235MovVCod ;
      private long A233DocItem ;
      private decimal AV81TotGCant ;
      private decimal AV82TotGImp ;
      private decimal AV80TotGCanEqv ;
      private decimal A895DocDCan ;
      private decimal AV79TotCant ;
      private decimal AV83TotImp ;
      private decimal AV78TotCanEqv ;
      private decimal AV46LineaCant ;
      private decimal AV49LineaImp ;
      private decimal AV48LineaEQV ;
      private decimal A1702ProdPeso ;
      private decimal A899DocDcto ;
      private decimal A882DocAnticipos ;
      private decimal A892DocDTot ;
      private decimal AV58ProdPeso ;
      private decimal AV20DocDcto ;
      private decimal AV15DocAnticipos ;
      private decimal AV22DocDTot ;
      private decimal AV56Porcentaje ;
      private decimal AV64SubTotal ;
      private decimal AV8Anticipo ;
      private decimal AV14Descuento ;
      private decimal AV72TipVenta ;
      private decimal GXt_decimal1 ;
      private decimal AV19DocDCan ;
      private decimal AV10CanEQV ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A919DocSub ;
      private decimal AV11Cant ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV57ProdCod ;
      private string AV13CliCod ;
      private string AV69Tipo ;
      private string AV32Empresa ;
      private string AV31EmpDir ;
      private string AV33EmpRUC ;
      private string AV59Ruta ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string AV53Moneda ;
      private string A231DocCliCod ;
      private string A946DocTipo ;
      private string A28ProdCod ;
      private string A149TipCod ;
      private string A941DocSts ;
      private string A24DocNum ;
      private string A953DocVendDsc ;
      private string AV85VenDsc ;
      private string AV39Filtro1 ;
      private string A1153LinDsc ;
      private string AV50LineaNom ;
      private string A55ProdDsc ;
      private string A306TipAbr ;
      private string A887DocCliDsc ;
      private string AV67TipCod ;
      private string AV28DocNum ;
      private string GXt_char3 ;
      private string A1242MovVAbr ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV36FDesde ;
      private DateTime AV38FHasta ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV23DocFec ;
      private DateTime AV24DocFecRef ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKEL4 ;
      private bool n159TipCCod ;
      private bool n158ZonCod ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool n178TieCod ;
      private bool returnInSub ;
      private string AV89Logo_GXI ;
      private string AV51Logo ;
      private string Logo ;
      private IGxSession AV60Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_Lincod ;
      private int aP1_SublCod ;
      private int aP2_FamCod ;
      private int aP3_VenCod ;
      private string aP4_ProdCod ;
      private string aP5_CliCod ;
      private int aP6_MonCod ;
      private DateTime aP7_FDesde ;
      private DateTime aP8_FHasta ;
      private short aP9_Opc ;
      private string aP10_Tipo ;
      private int aP11_ZonCod ;
      private short aP12_TipoLinea ;
      private int aP13_TieCod ;
      private int aP14_TipCCod ;
      private short aP15_CheckRec ;
      private IDataStoreProvider pr_default ;
      private int[] P00EL2_A180MonCod ;
      private string[] P00EL2_A1234MonDsc ;
      private string[] P00EL3_A24DocNum ;
      private string[] P00EL3_A231DocCliCod ;
      private int[] P00EL3_A227DocVendCod ;
      private string[] P00EL3_A149TipCod ;
      private int[] P00EL3_A159TipCCod ;
      private bool[] P00EL3_n159TipCCod ;
      private int[] P00EL3_A158ZonCod ;
      private bool[] P00EL3_n158ZonCod ;
      private int[] P00EL3_A50FamCod ;
      private bool[] P00EL3_n50FamCod ;
      private int[] P00EL3_A51SublCod ;
      private bool[] P00EL3_n51SublCod ;
      private int[] P00EL3_A52LinCod ;
      private string[] P00EL3_A28ProdCod ;
      private string[] P00EL3_A946DocTipo ;
      private string[] P00EL3_A941DocSts ;
      private DateTime[] P00EL3_A232DocFec ;
      private int[] P00EL3_A178TieCod ;
      private bool[] P00EL3_n178TieCod ;
      private decimal[] P00EL3_A895DocDCan ;
      private string[] P00EL3_A953DocVendDsc ;
      private long[] P00EL3_A233DocItem ;
      private int[] P00EL4_A52LinCod ;
      private string[] P00EL4_A1153LinDsc ;
      private string[] P00EL5_A149TipCod ;
      private int[] P00EL5_A159TipCCod ;
      private bool[] P00EL5_n159TipCCod ;
      private int[] P00EL5_A158ZonCod ;
      private bool[] P00EL5_n158ZonCod ;
      private int[] P00EL5_A50FamCod ;
      private bool[] P00EL5_n50FamCod ;
      private int[] P00EL5_A51SublCod ;
      private bool[] P00EL5_n51SublCod ;
      private string[] P00EL5_A28ProdCod ;
      private int[] P00EL5_A52LinCod ;
      private string[] P00EL5_A946DocTipo ;
      private string[] P00EL5_A941DocSts ;
      private DateTime[] P00EL5_A232DocFec ;
      private string[] P00EL5_A231DocCliCod ;
      private int[] P00EL5_A227DocVendCod ;
      private int[] P00EL5_A178TieCod ;
      private bool[] P00EL5_n178TieCod ;
      private string[] P00EL5_A24DocNum ;
      private int[] P00EL5_A230DocMonCod ;
      private int[] P00EL5_A226DocMovCod ;
      private decimal[] P00EL5_A1702ProdPeso ;
      private short[] P00EL5_A511TipSigno ;
      private decimal[] P00EL5_A899DocDcto ;
      private DateTime[] P00EL5_A929DocFecRef ;
      private decimal[] P00EL5_A882DocAnticipos ;
      private decimal[] P00EL5_A892DocDTot ;
      private decimal[] P00EL5_A895DocDCan ;
      private string[] P00EL5_A55ProdDsc ;
      private string[] P00EL5_A306TipAbr ;
      private string[] P00EL5_A887DocCliDsc ;
      private long[] P00EL5_A233DocItem ;
      private string[] P00EL7_A24DocNum ;
      private string[] P00EL7_A149TipCod ;
      private decimal[] P00EL7_A927DocSubExonerado ;
      private decimal[] P00EL7_A922DocSubSelectivo ;
      private decimal[] P00EL7_A921DocSubInafecto ;
      private decimal[] P00EL7_A920DocSubAfecto ;
      private string[] P00EL8_A24DocNum ;
      private string[] P00EL8_A149TipCod ;
      private int[] P00EL8_A159TipCCod ;
      private bool[] P00EL8_n159TipCCod ;
      private int[] P00EL8_A158ZonCod ;
      private bool[] P00EL8_n158ZonCod ;
      private int[] P00EL8_A50FamCod ;
      private bool[] P00EL8_n50FamCod ;
      private int[] P00EL8_A51SublCod ;
      private bool[] P00EL8_n51SublCod ;
      private string[] P00EL8_A28ProdCod ;
      private int[] P00EL8_A52LinCod ;
      private string[] P00EL8_A946DocTipo ;
      private string[] P00EL8_A941DocSts ;
      private DateTime[] P00EL8_A232DocFec ;
      private string[] P00EL8_A231DocCliCod ;
      private int[] P00EL8_A227DocVendCod ;
      private int[] P00EL8_A178TieCod ;
      private bool[] P00EL8_n178TieCod ;
      private short[] P00EL8_A511TipSigno ;
      private decimal[] P00EL8_A895DocDCan ;
      private long[] P00EL8_A233DocItem ;
      private int[] P00EL9_A235MovVCod ;
      private string[] P00EL9_A1242MovVAbr ;
   }

   public class rrreporteventasdetallado__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EL3( IGxContext context ,
                                             int AV65TieCod ,
                                             int AV84VenCod ,
                                             string AV13CliCod ,
                                             string AV69Tipo ,
                                             string AV57ProdCod ,
                                             int AV45Lincod ,
                                             int AV63SublCod ,
                                             int AV35FamCod ,
                                             int AV86ZonCod ,
                                             int AV66TipCCod ,
                                             short AV12CheckRec ,
                                             int A178TieCod ,
                                             int A227DocVendCod ,
                                             string A231DocCliCod ,
                                             string A946DocTipo ,
                                             string A28ProdCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A158ZonCod ,
                                             int A159TipCCod ,
                                             string A149TipCod ,
                                             DateTime A232DocFec ,
                                             DateTime AV36FDesde ,
                                             DateTime AV38FHasta ,
                                             string A941DocSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[DocNum], T2.[DocCliCod] AS DocCliCod, T2.[DocVendCod] AS DocVendCod, T1.[TipCod], T3.[TipCCod], T3.[ZonCod], T5.[FamCod], T5.[SublCod], T5.[LinCod], T1.[ProdCod], T2.[DocTipo], T2.[DocSts], T2.[DocFec], T2.[TieCod], T1.[DocDCan], T4.[VenDsc] AS DocVendDsc, T1.[DocItem] FROM (((([CLVENTASDET] T1 INNER JOIN [CLVENTAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T2.[DocCliCod]) INNER JOIN [CVENDEDORES] T4 ON T4.[VenCod] = T2.[DocVendCod]) INNER JOIN [APRODUCTOS] T5 ON T5.[ProdCod] = T1.[ProdCod])";
         AddWhere(sWhereString, "(T2.[DocFec] >= @AV36FDesde and T2.[DocFec] <= @AV38FHasta)");
         AddWhere(sWhereString, "(T2.[DocSts] <> 'A')");
         if ( ! (0==AV65TieCod) )
         {
            AddWhere(sWhereString, "(T2.[TieCod] = @AV65TieCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV84VenCod) )
         {
            AddWhere(sWhereString, "(T2.[DocVendCod] = @AV84VenCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[DocCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV69Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] = @AV69Tipo)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV69Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV69Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'X')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV57ProdCod)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV45Lincod) )
         {
            AddWhere(sWhereString, "(T5.[LinCod] = @AV45Lincod)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV63SublCod) )
         {
            AddWhere(sWhereString, "(T5.[SublCod] = @AV63SublCod)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV35FamCod) )
         {
            AddWhere(sWhereString, "(T5.[FamCod] = @AV35FamCod)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (0==AV86ZonCod) )
         {
            AddWhere(sWhereString, "(T3.[ZonCod] = @AV86ZonCod)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (0==AV66TipCCod) )
         {
            AddWhere(sWhereString, "(T3.[TipCCod] = @AV66TipCCod)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV12CheckRec == 0 )
         {
            AddWhere(sWhereString, "(Not T1.[TipCod] = 'REC')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[DocVendCod], T2.[DocCliCod]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00EL4( IGxContext context ,
                                             int AV45Lincod ,
                                             int A52LinCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[1];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD]";
         if ( ! (0==AV45Lincod) )
         {
            AddWhere(sWhereString, "([LinCod] = @AV45Lincod)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [LinCod]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00EL5( IGxContext context ,
                                             int AV65TieCod ,
                                             string AV13CliCod ,
                                             string AV69Tipo ,
                                             string AV57ProdCod ,
                                             int AV63SublCod ,
                                             int AV35FamCod ,
                                             int AV86ZonCod ,
                                             int AV66TipCCod ,
                                             short AV12CheckRec ,
                                             int A178TieCod ,
                                             string A231DocCliCod ,
                                             string A946DocTipo ,
                                             string A28ProdCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A158ZonCod ,
                                             int A159TipCCod ,
                                             string A149TipCod ,
                                             DateTime A232DocFec ,
                                             DateTime AV36FDesde ,
                                             DateTime AV38FHasta ,
                                             string A941DocSts ,
                                             int A227DocVendCod ,
                                             int AV84VenCod ,
                                             int A52LinCod ,
                                             int AV47LineaCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[12];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T5.[TipCCod], T5.[ZonCod], T3.[FamCod], T3.[SublCod], T1.[ProdCod], T3.[LinCod], T4.[DocTipo], T4.[DocSts], T4.[DocFec], T4.[DocCliCod] AS DocCliCod, T4.[DocVendCod] AS DocVendCod, T4.[TieCod], T1.[DocNum], T4.[DocMonCod], T4.[DocMovCod], T3.[ProdPeso], T2.[TipSigno], T4.[DocDcto], T4.[DocFecRef], T4.[DocAnticipos], T1.[DocDTot], T1.[DocDCan], T3.[ProdDsc], T2.[TipAbr], T5.[CliDsc] AS DocCliDsc, T1.[DocItem] FROM (((([CLVENTASDET] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLVENTAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum]) INNER JOIN [CLCLIENTES] T5 ON T5.[CliCod] = T4.[DocCliCod])";
         AddWhere(sWhereString, "(T4.[DocFec] >= @AV36FDesde and T4.[DocFec] <= @AV38FHasta)");
         AddWhere(sWhereString, "(T4.[DocSts] <> 'A')");
         AddWhere(sWhereString, "(T4.[DocVendCod] = @AV84VenCod)");
         AddWhere(sWhereString, "(T3.[LinCod] = @AV47LineaCod)");
         if ( ! (0==AV65TieCod) )
         {
            AddWhere(sWhereString, "(T4.[TieCod] = @AV65TieCod)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T4.[DocCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( StringUtil.StrCmp(AV69Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] = @AV69Tipo)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV69Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV69Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] <> 'X')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV57ProdCod)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! (0==AV63SublCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV63SublCod)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! (0==AV35FamCod) )
         {
            AddWhere(sWhereString, "(T3.[FamCod] = @AV35FamCod)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! (0==AV86ZonCod) )
         {
            AddWhere(sWhereString, "(T5.[ZonCod] = @AV86ZonCod)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! (0==AV66TipCCod) )
         {
            AddWhere(sWhereString, "(T5.[TipCCod] = @AV66TipCCod)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV12CheckRec == 0 )
         {
            AddWhere(sWhereString, "(Not T1.[TipCod] = 'REC')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipCod], T1.[DocNum], T1.[DocItem]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00EL8( IGxContext context ,
                                             int AV65TieCod ,
                                             string AV13CliCod ,
                                             string AV69Tipo ,
                                             string AV57ProdCod ,
                                             int AV63SublCod ,
                                             int AV35FamCod ,
                                             int AV86ZonCod ,
                                             int AV66TipCCod ,
                                             short AV12CheckRec ,
                                             int A178TieCod ,
                                             string A231DocCliCod ,
                                             string A946DocTipo ,
                                             string A28ProdCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A158ZonCod ,
                                             int A159TipCCod ,
                                             string A149TipCod ,
                                             DateTime A232DocFec ,
                                             DateTime AV36FDesde ,
                                             DateTime AV38FHasta ,
                                             string A941DocSts ,
                                             int A227DocVendCod ,
                                             int AV84VenCod ,
                                             int A52LinCod ,
                                             int AV47LineaCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[12];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[DocNum], T1.[TipCod], T4.[TipCCod], T4.[ZonCod], T5.[FamCod], T5.[SublCod], T1.[ProdCod], T5.[LinCod], T3.[DocTipo], T3.[DocSts], T3.[DocFec], T3.[DocCliCod] AS DocCliCod, T3.[DocVendCod] AS DocVendCod, T3.[TieCod], T2.[TipSigno], T1.[DocDCan], T1.[DocItem] FROM (((([CLVENTASDET] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) INNER JOIN [CLVENTAS] T3 ON T3.[TipCod] = T1.[TipCod] AND T3.[DocNum] = T1.[DocNum]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T3.[DocCliCod]) INNER JOIN [APRODUCTOS] T5 ON T5.[ProdCod] = T1.[ProdCod])";
         AddWhere(sWhereString, "(T3.[DocFec] >= @AV36FDesde and T3.[DocFec] <= @AV38FHasta)");
         AddWhere(sWhereString, "(T3.[DocSts] <> 'A')");
         AddWhere(sWhereString, "(T3.[DocVendCod] = @AV84VenCod)");
         AddWhere(sWhereString, "(T5.[LinCod] = @AV47LineaCod)");
         if ( ! (0==AV65TieCod) )
         {
            AddWhere(sWhereString, "(T3.[TieCod] = @AV65TieCod)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T3.[DocCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( StringUtil.StrCmp(AV69Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T3.[DocTipo] = @AV69Tipo)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( StringUtil.StrCmp(AV69Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T3.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV69Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T3.[DocTipo] <> 'X')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV57ProdCod)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! (0==AV63SublCod) )
         {
            AddWhere(sWhereString, "(T5.[SublCod] = @AV63SublCod)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ! (0==AV35FamCod) )
         {
            AddWhere(sWhereString, "(T5.[FamCod] = @AV35FamCod)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! (0==AV86ZonCod) )
         {
            AddWhere(sWhereString, "(T4.[ZonCod] = @AV86ZonCod)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ! (0==AV66TipCCod) )
         {
            AddWhere(sWhereString, "(T4.[TipCCod] = @AV66TipCCod)");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( AV12CheckRec == 0 )
         {
            AddWhere(sWhereString, "(Not T1.[TipCod] = 'REC')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipCod], T1.[DocNum], T1.[DocItem]";
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
               case 1 :
                     return conditional_P00EL3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (string)dynConstraints[25] );
               case 2 :
                     return conditional_P00EL4(context, (int)dynConstraints[0] , (int)dynConstraints[1] );
               case 3 :
                     return conditional_P00EL5(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] );
               case 5 :
                     return conditional_P00EL8(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] );
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
          Object[] prmP00EL2;
          prmP00EL2 = new Object[] {
          new ParDef("@AV52MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00EL7;
          prmP00EL7 = new Object[] {
          new ParDef("@AV67TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV28DocNum",GXType.NChar,12,0)
          };
          Object[] prmP00EL9;
          prmP00EL9 = new Object[] {
          new ParDef("@AV27DocMovCod",GXType.Int32,6,0)
          };
          Object[] prmP00EL3;
          prmP00EL3 = new Object[] {
          new ParDef("@AV36FDesde",GXType.Date,8,0) ,
          new ParDef("@AV38FHasta",GXType.Date,8,0) ,
          new ParDef("@AV65TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV84VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV69Tipo",GXType.NChar,1,0) ,
          new ParDef("@AV57ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV45Lincod",GXType.Int32,6,0) ,
          new ParDef("@AV63SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV35FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV86ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV66TipCCod",GXType.Int32,6,0)
          };
          Object[] prmP00EL4;
          prmP00EL4 = new Object[] {
          new ParDef("@AV45Lincod",GXType.Int32,6,0)
          };
          Object[] prmP00EL5;
          prmP00EL5 = new Object[] {
          new ParDef("@AV36FDesde",GXType.Date,8,0) ,
          new ParDef("@AV38FHasta",GXType.Date,8,0) ,
          new ParDef("@AV84VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV47LineaCod",GXType.Int32,6,0) ,
          new ParDef("@AV65TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV69Tipo",GXType.NChar,1,0) ,
          new ParDef("@AV57ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV63SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV35FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV86ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV66TipCCod",GXType.Int32,6,0)
          };
          Object[] prmP00EL8;
          prmP00EL8 = new Object[] {
          new ParDef("@AV36FDesde",GXType.Date,8,0) ,
          new ParDef("@AV38FHasta",GXType.Date,8,0) ,
          new ParDef("@AV84VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV47LineaCod",GXType.Int32,6,0) ,
          new ParDef("@AV65TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV69Tipo",GXType.NChar,1,0) ,
          new ParDef("@AV57ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV63SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV35FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV86ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV66TipCCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EL2", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV52MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EL2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EL3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EL3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EL4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EL4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EL5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EL5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EL7", "SELECT T1.[DocNum], T1.[TipCod], COALESCE( T2.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T2.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T2.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T2.[DocSubAfecto], 0) AS DocSubAfecto FROM ([CLVENTAS] T1 LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) WHERE T1.[TipCod] = @AV67TipCod and T1.[DocNum] = @AV28DocNum ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EL7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EL8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EL8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EL9", "SELECT [MovVCod], [MovVAbr] FROM [CMOVVENTAS] WHERE [MovVCod] = @AV27DocMovCod ORDER BY [MovVCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EL9,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((int[]) buf[10])[0] = rslt.getInt(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((int[]) buf[12])[0] = rslt.getInt(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 15);
                ((string[]) buf[14])[0] = rslt.getString(11, 1);
                ((string[]) buf[15])[0] = rslt.getString(12, 1);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(13);
                ((int[]) buf[17])[0] = rslt.getInt(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(15);
                ((string[]) buf[20])[0] = rslt.getString(16, 100);
                ((long[]) buf[21])[0] = rslt.getLong(17);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getString(6, 15);
                ((int[]) buf[10])[0] = rslt.getInt(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 1);
                ((string[]) buf[12])[0] = rslt.getString(9, 1);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                ((int[]) buf[15])[0] = rslt.getInt(12);
                ((int[]) buf[16])[0] = rslt.getInt(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((string[]) buf[18])[0] = rslt.getString(14, 12);
                ((int[]) buf[19])[0] = rslt.getInt(15);
                ((int[]) buf[20])[0] = rslt.getInt(16);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(17);
                ((short[]) buf[22])[0] = rslt.getShort(18);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(19);
                ((DateTime[]) buf[24])[0] = rslt.getGXDate(20);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(23);
                ((string[]) buf[28])[0] = rslt.getString(24, 100);
                ((string[]) buf[29])[0] = rslt.getString(25, 5);
                ((string[]) buf[30])[0] = rslt.getString(26, 100);
                ((long[]) buf[31])[0] = rslt.getLong(27);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((int[]) buf[8])[0] = rslt.getInt(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getString(7, 15);
                ((int[]) buf[11])[0] = rslt.getInt(8);
                ((string[]) buf[12])[0] = rslt.getString(9, 1);
                ((string[]) buf[13])[0] = rslt.getString(10, 1);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(11);
                ((string[]) buf[15])[0] = rslt.getString(12, 20);
                ((int[]) buf[16])[0] = rslt.getInt(13);
                ((int[]) buf[17])[0] = rslt.getInt(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((short[]) buf[19])[0] = rslt.getShort(15);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(16);
                ((long[]) buf[21])[0] = rslt.getLong(17);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
       }
    }

 }

}
