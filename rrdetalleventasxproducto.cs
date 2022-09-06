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
   public class rrdetalleventasxproducto : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrdetalleventasxproducto.aspx")), "rrdetalleventasxproducto.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrdetalleventasxproducto.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "VenCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV100VenCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV66ProdCod = GetPar( "ProdCod");
                  AV15CliCod = GetPar( "CliCod");
                  AV43Fdesde = context.localUtil.ParseDateParm( GetPar( "Fdesde"));
                  AV45FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV55LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
                  AV72SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV81Tipo = GetPar( "Tipo");
                  AV77TieCod = (int)(NumberUtil.Val( GetPar( "TieCod"), "."));
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

      public rrdetalleventasxproducto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrdetalleventasxproducto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_VenCod ,
                           ref string aP1_ProdCod ,
                           ref string aP2_CliCod ,
                           ref DateTime aP3_Fdesde ,
                           ref DateTime aP4_FHasta ,
                           ref int aP5_LinCod ,
                           ref int aP6_SubLCod ,
                           ref string aP7_Tipo ,
                           ref int aP8_TieCod )
      {
         this.AV100VenCod = aP0_VenCod;
         this.AV66ProdCod = aP1_ProdCod;
         this.AV15CliCod = aP2_CliCod;
         this.AV43Fdesde = aP3_Fdesde;
         this.AV45FHasta = aP4_FHasta;
         this.AV55LinCod = aP5_LinCod;
         this.AV72SubLCod = aP6_SubLCod;
         this.AV81Tipo = aP7_Tipo;
         this.AV77TieCod = aP8_TieCod;
         initialize();
         executePrivate();
         aP0_VenCod=this.AV100VenCod;
         aP1_ProdCod=this.AV66ProdCod;
         aP2_CliCod=this.AV15CliCod;
         aP3_Fdesde=this.AV43Fdesde;
         aP4_FHasta=this.AV45FHasta;
         aP5_LinCod=this.AV55LinCod;
         aP6_SubLCod=this.AV72SubLCod;
         aP7_Tipo=this.AV81Tipo;
         aP8_TieCod=this.AV77TieCod;
      }

      public int executeUdp( ref int aP0_VenCod ,
                             ref string aP1_ProdCod ,
                             ref string aP2_CliCod ,
                             ref DateTime aP3_Fdesde ,
                             ref DateTime aP4_FHasta ,
                             ref int aP5_LinCod ,
                             ref int aP6_SubLCod ,
                             ref string aP7_Tipo )
      {
         execute(ref aP0_VenCod, ref aP1_ProdCod, ref aP2_CliCod, ref aP3_Fdesde, ref aP4_FHasta, ref aP5_LinCod, ref aP6_SubLCod, ref aP7_Tipo, ref aP8_TieCod);
         return AV77TieCod ;
      }

      public void executeSubmit( ref int aP0_VenCod ,
                                 ref string aP1_ProdCod ,
                                 ref string aP2_CliCod ,
                                 ref DateTime aP3_Fdesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref int aP5_LinCod ,
                                 ref int aP6_SubLCod ,
                                 ref string aP7_Tipo ,
                                 ref int aP8_TieCod )
      {
         rrdetalleventasxproducto objrrdetalleventasxproducto;
         objrrdetalleventasxproducto = new rrdetalleventasxproducto();
         objrrdetalleventasxproducto.AV100VenCod = aP0_VenCod;
         objrrdetalleventasxproducto.AV66ProdCod = aP1_ProdCod;
         objrrdetalleventasxproducto.AV15CliCod = aP2_CliCod;
         objrrdetalleventasxproducto.AV43Fdesde = aP3_Fdesde;
         objrrdetalleventasxproducto.AV45FHasta = aP4_FHasta;
         objrrdetalleventasxproducto.AV55LinCod = aP5_LinCod;
         objrrdetalleventasxproducto.AV72SubLCod = aP6_SubLCod;
         objrrdetalleventasxproducto.AV81Tipo = aP7_Tipo;
         objrrdetalleventasxproducto.AV77TieCod = aP8_TieCod;
         objrrdetalleventasxproducto.context.SetSubmitInitialConfig(context);
         objrrdetalleventasxproducto.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrdetalleventasxproducto);
         aP0_VenCod=this.AV100VenCod;
         aP1_ProdCod=this.AV66ProdCod;
         aP2_CliCod=this.AV15CliCod;
         aP3_Fdesde=this.AV43Fdesde;
         aP4_FHasta=this.AV45FHasta;
         aP5_LinCod=this.AV55LinCod;
         aP6_SubLCod=this.AV72SubLCod;
         aP7_Tipo=this.AV81Tipo;
         aP8_TieCod=this.AV77TieCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrdetalleventasxproducto)stateInfo).executePrivate();
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
            AV37Empresa = AV71Session.Get("Empresa");
            AV36EmpDir = AV71Session.Get("EmpDir");
            AV38EmpRUC = AV71Session.Get("EmpRUC");
            AV69Ruta = AV71Session.Get("RUTA") + "/Logo.jpg";
            AV58Logo = AV69Ruta;
            AV104Logo_GXI = GXDbFile.PathToUrl( AV69Ruta);
            AV62Opcion = "Opcion : " + ((StringUtil.StrCmp(AV81Tipo, "T")==0) ? "Todos" : ((StringUtil.StrCmp(AV81Tipo, "M")==0) ? "Muestras" : "Ventas"));
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV77TieCod ,
                                                 AV15CliCod ,
                                                 AV66ProdCod ,
                                                 AV55LinCod ,
                                                 AV72SubLCod ,
                                                 AV100VenCod ,
                                                 AV81Tipo ,
                                                 A178TieCod ,
                                                 A231DocCliCod ,
                                                 A28ProdCod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A227DocVendCod ,
                                                 A946DocTipo ,
                                                 A232DocFec ,
                                                 AV43Fdesde ,
                                                 AV45FHasta ,
                                                 A941DocSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00EO2 */
            pr_default.execute(0, new Object[] {AV43Fdesde, AV45FHasta, AV77TieCod, AV15CliCod, AV66ProdCod, AV55LinCod, AV72SubLCod, AV100VenCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKEO3 = false;
               A149TipCod = P00EO2_A149TipCod[0];
               A24DocNum = P00EO2_A24DocNum[0];
               n24DocNum = P00EO2_n24DocNum[0];
               A55ProdDsc = P00EO2_A55ProdDsc[0];
               A28ProdCod = P00EO2_A28ProdCod[0];
               A941DocSts = P00EO2_A941DocSts[0];
               A946DocTipo = P00EO2_A946DocTipo[0];
               A227DocVendCod = P00EO2_A227DocVendCod[0];
               A51SublCod = P00EO2_A51SublCod[0];
               n51SublCod = P00EO2_n51SublCod[0];
               A52LinCod = P00EO2_A52LinCod[0];
               A231DocCliCod = P00EO2_A231DocCliCod[0];
               A178TieCod = P00EO2_A178TieCod[0];
               n178TieCod = P00EO2_n178TieCod[0];
               A232DocFec = P00EO2_A232DocFec[0];
               A894DocDpre = P00EO2_A894DocDpre[0];
               A233DocItem = P00EO2_A233DocItem[0];
               A941DocSts = P00EO2_A941DocSts[0];
               A946DocTipo = P00EO2_A946DocTipo[0];
               A227DocVendCod = P00EO2_A227DocVendCod[0];
               A231DocCliCod = P00EO2_A231DocCliCod[0];
               A178TieCod = P00EO2_A178TieCod[0];
               n178TieCod = P00EO2_n178TieCod[0];
               A232DocFec = P00EO2_A232DocFec[0];
               A55ProdDsc = P00EO2_A55ProdDsc[0];
               A51SublCod = P00EO2_A51SublCod[0];
               n51SublCod = P00EO2_n51SublCod[0];
               A52LinCod = P00EO2_A52LinCod[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00EO2_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRKEO3 = false;
                  A149TipCod = P00EO2_A149TipCod[0];
                  A24DocNum = P00EO2_A24DocNum[0];
                  n24DocNum = P00EO2_n24DocNum[0];
                  A55ProdDsc = P00EO2_A55ProdDsc[0];
                  A233DocItem = P00EO2_A233DocItem[0];
                  A55ProdDsc = P00EO2_A55ProdDsc[0];
                  BRKEO3 = true;
                  pr_default.readNext(0);
               }
               AV19Codigo = A28ProdCod;
               AV68Producto = StringUtil.Trim( A55ProdDsc);
               AV91TProducto = "Total : " + StringUtil.Trim( AV68Producto);
               AV74TCantidad = 0.00m;
               AV93TTotalMN = 0.00m;
               AV92TTotalME = 0.00m;
               AV76TExpresadoMN = 0.00m;
               AV75TExpresadoME = 0.00m;
               HEO0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Producto, "")), 2, Gx_line+3, 628, Gx_line+18, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               /* Execute user subroutine: 'DETALLE' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               HEO0( false, 40) ;
               getPrinter().GxDrawLine(570, Gx_line+8, 1125, Gx_line+8, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75TExpresadoME, "ZZZZZZ,ZZZ,ZZ9.99")), 1001, Gx_line+15, 1126, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV76TExpresadoMN, "ZZZZZZ,ZZZ,ZZ9.99")), 890, Gx_line+15, 1015, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV92TTotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 776, Gx_line+15, 901, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV93TTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+15, 798, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74TCantidad, "ZZZZ,ZZZ,ZZ9.9999")), 570, Gx_line+15, 695, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV91TProducto, "")), 149, Gx_line+15, 556, Gx_line+29, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               AV94TTTCantidad = (decimal)(AV94TTTCantidad+AV74TCantidad);
               AV98TTTotalMN = (decimal)(AV98TTTotalMN+AV93TTotalMN);
               AV97TTTotalME = (decimal)(AV97TTTotalME+AV92TTotalME);
               AV96TTTExpresadoMN = (decimal)(AV96TTTExpresadoMN+AV76TExpresadoMN);
               AV95TTTExpresadoME = (decimal)(AV95TTTExpresadoME+AV75TExpresadoME);
               if ( ! BRKEO3 )
               {
                  BRKEO3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HEO0( false, 60) ;
            getPrinter().GxDrawLine(572, Gx_line+17, 1125, Gx_line+17, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV94TTTCantidad, "ZZZZ,ZZZ,ZZ9.9999")), 570, Gx_line+23, 695, Gx_line+38, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV98TTTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+23, 798, Gx_line+38, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV97TTTotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 776, Gx_line+23, 901, Gx_line+38, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV96TTTExpresadoMN, "ZZZZZZ,ZZZ,ZZ9.99")), 890, Gx_line+23, 1015, Gx_line+38, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV95TTTExpresadoME, "ZZZZZZ,ZZZ,ZZ9.99")), 1001, Gx_line+23, 1126, Gx_line+38, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("TOTAL GENERAL", 465, Gx_line+23, 558, Gx_line+37, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+60);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HEO0( true, 0) ;
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
         /* 'DETALLE' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV77TieCod ,
                                              AV55LinCod ,
                                              AV15CliCod ,
                                              AV72SubLCod ,
                                              AV100VenCod ,
                                              AV81Tipo ,
                                              A178TieCod ,
                                              A52LinCod ,
                                              A231DocCliCod ,
                                              A51SublCod ,
                                              A227DocVendCod ,
                                              A946DocTipo ,
                                              A232DocFec ,
                                              AV43Fdesde ,
                                              AV45FHasta ,
                                              A941DocSts ,
                                              A28ProdCod ,
                                              AV19Codigo } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00EO3 */
         pr_default.execute(1, new Object[] {AV43Fdesde, AV45FHasta, AV19Codigo, AV77TieCod, AV55LinCod, AV15CliCod, AV72SubLCod, AV100VenCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A49UniCod = P00EO3_A49UniCod[0];
            A28ProdCod = P00EO3_A28ProdCod[0];
            A941DocSts = P00EO3_A941DocSts[0];
            A946DocTipo = P00EO3_A946DocTipo[0];
            A227DocVendCod = P00EO3_A227DocVendCod[0];
            A51SublCod = P00EO3_A51SublCod[0];
            n51SublCod = P00EO3_n51SublCod[0];
            A231DocCliCod = P00EO3_A231DocCliCod[0];
            A52LinCod = P00EO3_A52LinCod[0];
            A178TieCod = P00EO3_A178TieCod[0];
            n178TieCod = P00EO3_n178TieCod[0];
            A232DocFec = P00EO3_A232DocFec[0];
            A894DocDpre = P00EO3_A894DocDpre[0];
            A887DocCliDsc = P00EO3_A887DocCliDsc[0];
            A1997UniAbr = P00EO3_A1997UniAbr[0];
            A24DocNum = P00EO3_A24DocNum[0];
            n24DocNum = P00EO3_n24DocNum[0];
            A149TipCod = P00EO3_A149TipCod[0];
            A230DocMonCod = P00EO3_A230DocMonCod[0];
            A226DocMovCod = P00EO3_A226DocMovCod[0];
            A899DocDcto = P00EO3_A899DocDcto[0];
            A892DocDTot = P00EO3_A892DocDTot[0];
            A511TipSigno = P00EO3_A511TipSigno[0];
            A895DocDCan = P00EO3_A895DocDCan[0];
            A882DocAnticipos = P00EO3_A882DocAnticipos[0];
            A929DocFecRef = P00EO3_A929DocFecRef[0];
            A233DocItem = P00EO3_A233DocItem[0];
            A49UniCod = P00EO3_A49UniCod[0];
            A51SublCod = P00EO3_A51SublCod[0];
            n51SublCod = P00EO3_n51SublCod[0];
            A52LinCod = P00EO3_A52LinCod[0];
            A1997UniAbr = P00EO3_A1997UniAbr[0];
            A511TipSigno = P00EO3_A511TipSigno[0];
            A941DocSts = P00EO3_A941DocSts[0];
            A946DocTipo = P00EO3_A946DocTipo[0];
            A227DocVendCod = P00EO3_A227DocVendCod[0];
            A231DocCliCod = P00EO3_A231DocCliCod[0];
            A178TieCod = P00EO3_A178TieCod[0];
            n178TieCod = P00EO3_n178TieCod[0];
            A232DocFec = P00EO3_A232DocFec[0];
            A230DocMonCod = P00EO3_A230DocMonCod[0];
            A226DocMovCod = P00EO3_A226DocMovCod[0];
            A899DocDcto = P00EO3_A899DocDcto[0];
            A882DocAnticipos = P00EO3_A882DocAnticipos[0];
            A929DocFecRef = P00EO3_A929DocFecRef[0];
            A887DocCliDsc = P00EO3_A887DocCliDsc[0];
            AV16Cliente = StringUtil.Trim( A887DocCliDsc);
            AV99UniAbr = StringUtil.Trim( A1997UniAbr);
            AV30DocNum = A24DocNum;
            AV26DocFec = A232DocFec;
            AV80TipCod = A149TipCod;
            AV44Fecha = A232DocFec;
            AV59MonCod = A230DocMonCod;
            AV29DocMovCod = A226DocMovCod;
            AV65PorDscto = A899DocDcto;
            AV21Descuento = NumberUtil.Round( (NumberUtil.Round( A892DocDTot, 2)*AV65PorDscto)/ (decimal)(100), 2);
            AV82Total = NumberUtil.Round( (NumberUtil.Round( A892DocDTot, 2)-AV21Descuento)*A511TipSigno, 2);
            AV11Cantidad = NumberUtil.Round( A895DocDCan*A511TipSigno, 4);
            AV101DocAnticipos = (decimal)(NumberUtil.Round( A882DocAnticipos, 2)*A511TipSigno);
            AV61MVACod = "";
            /* Execute user subroutine: 'GUIAS' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            if ( ( StringUtil.StrCmp(AV80TipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV80TipCod, "ND") == 0 ) )
            {
               /* Execute user subroutine: 'VALIDATIPOMOVIMIENTO' */
               S135 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               AV44Fecha = ((StringUtil.StrCmp(AV80TipCod, "NC")==0)||(StringUtil.StrCmp(AV80TipCod, "ND")==0) ? A929DocFecRef : A232DocFec);
            }
            GXt_decimal1 = AV10Cambio;
            GXt_int2 = 2;
            GXt_char3 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV44Fecha, ref  GXt_char3, out  GXt_decimal1) ;
            AV10Cambio = GXt_decimal1;
            if ( ! (Convert.ToDecimal(0)==AV101DocAnticipos) )
            {
               /* Execute user subroutine: 'SUBTOTAL' */
               S145 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               AV64Porcentaje = NumberUtil.Round( AV82Total/ (decimal)(((Convert.ToDecimal(0)==AV73SubTotal) ? (decimal)(1) : AV73SubTotal)), 10);
               AV9Anticipo = NumberUtil.Round( AV64Porcentaje*AV101DocAnticipos, 2);
            }
            else
            {
               AV64Porcentaje = 0.00m;
               AV9Anticipo = 0.00m;
               AV73SubTotal = 0.00m;
            }
            AV82Total = (decimal)(AV82Total-(AV9Anticipo+AV21Descuento));
            AV84TotalMN = ((AV59MonCod==1) ? AV82Total : (decimal)(0));
            AV83TotalME = ((AV59MonCod==1) ? (decimal)(0) : AV82Total);
            AV42ExpresadoMN = ((AV59MonCod==1) ? AV82Total : NumberUtil.Round( AV82Total*AV10Cambio, 2));
            AV41ExpresadoME = ((AV59MonCod==1) ? NumberUtil.Round( AV82Total/ (decimal)(AV10Cambio), 2) : AV82Total);
            HEO0( false, 22) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Cliente, "")), 2, Gx_line+3, 316, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV99UniAbr, "")), 544, Gx_line+3, 597, Gx_line+18, 1+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV11Cantidad, "ZZZZ,ZZZ,ZZ9.9999")), 581, Gx_line+3, 688, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV84TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 691, Gx_line+3, 798, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV83TotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 794, Gx_line+3, 901, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42ExpresadoMN, "ZZZZZZ,ZZZ,ZZ9.99")), 907, Gx_line+3, 1014, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41ExpresadoME, "ZZZZZZ,ZZZ,ZZ9.99")), 1019, Gx_line+3, 1126, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV26DocFec, "99/99/99"), 320, Gx_line+3, 367, Gx_line+18, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30DocNum, "")), 377, Gx_line+3, 441, Gx_line+18, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61MVACod, "")), 458, Gx_line+3, 522, Gx_line+18, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+22);
            AV74TCantidad = (decimal)(AV74TCantidad+AV11Cantidad);
            AV93TTotalMN = (decimal)(AV93TTotalMN+AV84TotalMN);
            AV92TTotalME = (decimal)(AV92TTotalME+AV83TotalME);
            AV76TExpresadoMN = (decimal)(AV76TExpresadoMN+AV42ExpresadoMN);
            AV75TExpresadoME = (decimal)(AV75TExpresadoME+AV41ExpresadoME);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S125( )
      {
         /* 'GUIAS' Routine */
         returnInSub = false;
         /* Using cursor P00EO4 */
         pr_default.execute(2, new Object[] {AV80TipCod, AV30DocNum});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A1370MVSts = P00EO4_A1370MVSts[0];
            A23DocTip = P00EO4_A23DocTip[0];
            n23DocTip = P00EO4_n23DocTip[0];
            A24DocNum = P00EO4_A24DocNum[0];
            n24DocNum = P00EO4_n24DocNum[0];
            A14MvACod = P00EO4_A14MvACod[0];
            A13MvATip = P00EO4_A13MvATip[0];
            AV61MVACod = A14MvACod;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S135( )
      {
         /* 'VALIDATIPOMOVIMIENTO' Routine */
         returnInSub = false;
         /* Using cursor P00EO5 */
         pr_default.execute(3, new Object[] {AV29DocMovCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A235MovVCod = P00EO5_A235MovVCod[0];
            A1242MovVAbr = P00EO5_A1242MovVAbr[0];
            if ( ! ( StringUtil.StrCmp(A1242MovVAbr, "SI") == 0 ) )
            {
               AV11Cantidad = 0.00m;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void S145( )
      {
         /* 'SUBTOTAL' Routine */
         returnInSub = false;
         /* Using cursor P00EO7 */
         pr_default.execute(4, new Object[] {AV80TipCod, AV30DocNum});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A24DocNum = P00EO7_A24DocNum[0];
            n24DocNum = P00EO7_n24DocNum[0];
            A149TipCod = P00EO7_A149TipCod[0];
            A927DocSubExonerado = P00EO7_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EO7_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EO7_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EO7_A920DocSubAfecto[0];
            A927DocSubExonerado = P00EO7_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EO7_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EO7_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EO7_A920DocSubAfecto[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            AV73SubTotal = NumberUtil.Round( A919DocSub, 2);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void HEO0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 984, Gx_line+28, 1016, Gx_line+42, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 984, Gx_line+45, 1028, Gx_line+59, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 984, Gx_line+11, 1023, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1041, Gx_line+45, 1080, Gx_line+60, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1009, Gx_line+28, 1078, Gx_line+42, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1032, Gx_line+11, 1079, Gx_line+26, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PRODUCTO", 119, Gx_line+92, 184, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("TOTAL", 835, Gx_line+84, 874, Gx_line+98, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+81, 1128, Gx_line+116, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Detalle de Ventas por Producto", 425, Gx_line+28, 692, Gx_line+48, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("CANTIDAD", 617, Gx_line+92, 678, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("TOTAL", 730, Gx_line+84, 769, Gx_line+98, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Empresa, "")), 19, Gx_line+11, 404, Gx_line+29, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(317, Gx_line+81, 317, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(697, Gx_line+82, 697, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(800, Gx_line+82, 800, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1016, Gx_line+81, 1016, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(903, Gx_line+82, 903, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(596, Gx_line+81, 596, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("UNIDAD", 548, Gx_line+92, 595, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde", 425, Gx_line+53, 465, Gx_line+68, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV43Fdesde, "99/99/99"), 485, Gx_line+48, 559, Gx_line+72, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 585, Gx_line+53, 622, Gx_line+68, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV45FHasta, "99/99/99"), 636, Gx_line+48, 710, Gx_line+72, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("FACTURADO MN", 703, Gx_line+99, 796, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FACTURADO ME", 808, Gx_line+99, 900, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("EXPRESADO MN", 914, Gx_line+92, 1004, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("EXPRESADO ME", 1030, Gx_line+92, 1119, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Opcion, "")), 5, Gx_line+60, 266, Gx_line+76, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(456, Gx_line+81, 456, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(544, Gx_line+81, 544, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(375, Gx_line+81, 375, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("FECHA", 327, Gx_line+92, 364, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° FACTURA", 381, Gx_line+92, 453, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° GUIA", 471, Gx_line+92, 519, Gx_line+106, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+117);
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
         AV37Empresa = "";
         AV71Session = context.GetSession();
         AV36EmpDir = "";
         AV38EmpRUC = "";
         AV69Ruta = "";
         AV58Logo = "";
         AV104Logo_GXI = "";
         AV62Opcion = "";
         scmdbuf = "";
         A231DocCliCod = "";
         A28ProdCod = "";
         A946DocTipo = "";
         A232DocFec = DateTime.MinValue;
         A941DocSts = "";
         P00EO2_A149TipCod = new string[] {""} ;
         P00EO2_A24DocNum = new string[] {""} ;
         P00EO2_n24DocNum = new bool[] {false} ;
         P00EO2_A55ProdDsc = new string[] {""} ;
         P00EO2_A28ProdCod = new string[] {""} ;
         P00EO2_A941DocSts = new string[] {""} ;
         P00EO2_A946DocTipo = new string[] {""} ;
         P00EO2_A227DocVendCod = new int[1] ;
         P00EO2_A51SublCod = new int[1] ;
         P00EO2_n51SublCod = new bool[] {false} ;
         P00EO2_A52LinCod = new int[1] ;
         P00EO2_A231DocCliCod = new string[] {""} ;
         P00EO2_A178TieCod = new int[1] ;
         P00EO2_n178TieCod = new bool[] {false} ;
         P00EO2_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EO2_A894DocDpre = new decimal[1] ;
         P00EO2_A233DocItem = new long[1] ;
         A149TipCod = "";
         A24DocNum = "";
         A55ProdDsc = "";
         AV19Codigo = "";
         AV68Producto = "";
         AV91TProducto = "";
         P00EO3_A49UniCod = new int[1] ;
         P00EO3_A28ProdCod = new string[] {""} ;
         P00EO3_A941DocSts = new string[] {""} ;
         P00EO3_A946DocTipo = new string[] {""} ;
         P00EO3_A227DocVendCod = new int[1] ;
         P00EO3_A51SublCod = new int[1] ;
         P00EO3_n51SublCod = new bool[] {false} ;
         P00EO3_A231DocCliCod = new string[] {""} ;
         P00EO3_A52LinCod = new int[1] ;
         P00EO3_A178TieCod = new int[1] ;
         P00EO3_n178TieCod = new bool[] {false} ;
         P00EO3_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EO3_A894DocDpre = new decimal[1] ;
         P00EO3_A887DocCliDsc = new string[] {""} ;
         P00EO3_A1997UniAbr = new string[] {""} ;
         P00EO3_A24DocNum = new string[] {""} ;
         P00EO3_n24DocNum = new bool[] {false} ;
         P00EO3_A149TipCod = new string[] {""} ;
         P00EO3_A230DocMonCod = new int[1] ;
         P00EO3_A226DocMovCod = new int[1] ;
         P00EO3_A899DocDcto = new decimal[1] ;
         P00EO3_A892DocDTot = new decimal[1] ;
         P00EO3_A511TipSigno = new short[1] ;
         P00EO3_A895DocDCan = new decimal[1] ;
         P00EO3_A882DocAnticipos = new decimal[1] ;
         P00EO3_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P00EO3_A233DocItem = new long[1] ;
         A887DocCliDsc = "";
         A1997UniAbr = "";
         A929DocFecRef = DateTime.MinValue;
         AV16Cliente = "";
         AV99UniAbr = "";
         AV30DocNum = "";
         AV26DocFec = DateTime.MinValue;
         AV80TipCod = "";
         AV44Fecha = DateTime.MinValue;
         AV61MVACod = "";
         GXt_char3 = "";
         P00EO4_A1370MVSts = new string[] {""} ;
         P00EO4_A23DocTip = new string[] {""} ;
         P00EO4_n23DocTip = new bool[] {false} ;
         P00EO4_A24DocNum = new string[] {""} ;
         P00EO4_n24DocNum = new bool[] {false} ;
         P00EO4_A14MvACod = new string[] {""} ;
         P00EO4_A13MvATip = new string[] {""} ;
         A1370MVSts = "";
         A23DocTip = "";
         A14MvACod = "";
         A13MvATip = "";
         P00EO5_A235MovVCod = new int[1] ;
         P00EO5_A1242MovVAbr = new string[] {""} ;
         A1242MovVAbr = "";
         P00EO7_A24DocNum = new string[] {""} ;
         P00EO7_n24DocNum = new bool[] {false} ;
         P00EO7_A149TipCod = new string[] {""} ;
         P00EO7_A927DocSubExonerado = new decimal[1] ;
         P00EO7_A922DocSubSelectivo = new decimal[1] ;
         P00EO7_A921DocSubInafecto = new decimal[1] ;
         P00EO7_A920DocSubAfecto = new decimal[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrdetalleventasxproducto__default(),
            new Object[][] {
                new Object[] {
               P00EO2_A149TipCod, P00EO2_A24DocNum, P00EO2_A55ProdDsc, P00EO2_A28ProdCod, P00EO2_A941DocSts, P00EO2_A946DocTipo, P00EO2_A227DocVendCod, P00EO2_A51SublCod, P00EO2_n51SublCod, P00EO2_A52LinCod,
               P00EO2_A231DocCliCod, P00EO2_A178TieCod, P00EO2_n178TieCod, P00EO2_A232DocFec, P00EO2_A894DocDpre, P00EO2_A233DocItem
               }
               , new Object[] {
               P00EO3_A49UniCod, P00EO3_A28ProdCod, P00EO3_A941DocSts, P00EO3_A946DocTipo, P00EO3_A227DocVendCod, P00EO3_A51SublCod, P00EO3_n51SublCod, P00EO3_A231DocCliCod, P00EO3_A52LinCod, P00EO3_A178TieCod,
               P00EO3_n178TieCod, P00EO3_A232DocFec, P00EO3_A894DocDpre, P00EO3_A887DocCliDsc, P00EO3_A1997UniAbr, P00EO3_A24DocNum, P00EO3_A149TipCod, P00EO3_A230DocMonCod, P00EO3_A226DocMovCod, P00EO3_A899DocDcto,
               P00EO3_A892DocDTot, P00EO3_A511TipSigno, P00EO3_A895DocDCan, P00EO3_A882DocAnticipos, P00EO3_A929DocFecRef, P00EO3_A233DocItem
               }
               , new Object[] {
               P00EO4_A1370MVSts, P00EO4_A23DocTip, P00EO4_n23DocTip, P00EO4_A24DocNum, P00EO4_n24DocNum, P00EO4_A14MvACod, P00EO4_A13MvATip
               }
               , new Object[] {
               P00EO5_A235MovVCod, P00EO5_A1242MovVAbr
               }
               , new Object[] {
               P00EO7_A24DocNum, P00EO7_A149TipCod, P00EO7_A927DocSubExonerado, P00EO7_A922DocSubSelectivo, P00EO7_A921DocSubInafecto, P00EO7_A920DocSubAfecto
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
      private short A511TipSigno ;
      private int AV100VenCod ;
      private int AV55LinCod ;
      private int AV72SubLCod ;
      private int AV77TieCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A178TieCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A227DocVendCod ;
      private int Gx_OldLine ;
      private int A49UniCod ;
      private int A230DocMonCod ;
      private int A226DocMovCod ;
      private int AV59MonCod ;
      private int AV29DocMovCod ;
      private int GXt_int2 ;
      private int A235MovVCod ;
      private long A233DocItem ;
      private decimal A894DocDpre ;
      private decimal AV74TCantidad ;
      private decimal AV93TTotalMN ;
      private decimal AV92TTotalME ;
      private decimal AV76TExpresadoMN ;
      private decimal AV75TExpresadoME ;
      private decimal AV94TTTCantidad ;
      private decimal AV98TTTotalMN ;
      private decimal AV97TTTotalME ;
      private decimal AV96TTTExpresadoMN ;
      private decimal AV95TTTExpresadoME ;
      private decimal A899DocDcto ;
      private decimal A892DocDTot ;
      private decimal A895DocDCan ;
      private decimal A882DocAnticipos ;
      private decimal AV65PorDscto ;
      private decimal AV21Descuento ;
      private decimal AV82Total ;
      private decimal AV11Cantidad ;
      private decimal AV101DocAnticipos ;
      private decimal AV10Cambio ;
      private decimal GXt_decimal1 ;
      private decimal AV64Porcentaje ;
      private decimal AV73SubTotal ;
      private decimal AV9Anticipo ;
      private decimal AV84TotalMN ;
      private decimal AV83TotalME ;
      private decimal AV42ExpresadoMN ;
      private decimal AV41ExpresadoME ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A919DocSub ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV66ProdCod ;
      private string AV15CliCod ;
      private string AV81Tipo ;
      private string AV37Empresa ;
      private string AV36EmpDir ;
      private string AV38EmpRUC ;
      private string AV69Ruta ;
      private string AV62Opcion ;
      private string scmdbuf ;
      private string A231DocCliCod ;
      private string A28ProdCod ;
      private string A946DocTipo ;
      private string A941DocSts ;
      private string A149TipCod ;
      private string A24DocNum ;
      private string A55ProdDsc ;
      private string AV68Producto ;
      private string AV91TProducto ;
      private string A887DocCliDsc ;
      private string A1997UniAbr ;
      private string AV16Cliente ;
      private string AV99UniAbr ;
      private string AV30DocNum ;
      private string AV80TipCod ;
      private string AV61MVACod ;
      private string GXt_char3 ;
      private string A1370MVSts ;
      private string A23DocTip ;
      private string A14MvACod ;
      private string A13MvATip ;
      private string A1242MovVAbr ;
      private string Gx_time ;
      private DateTime AV43Fdesde ;
      private DateTime AV45FHasta ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV26DocFec ;
      private DateTime AV44Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKEO3 ;
      private bool n24DocNum ;
      private bool n51SublCod ;
      private bool n178TieCod ;
      private bool returnInSub ;
      private bool n23DocTip ;
      private string AV104Logo_GXI ;
      private string AV19Codigo ;
      private string AV58Logo ;
      private IGxSession AV71Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_VenCod ;
      private string aP1_ProdCod ;
      private string aP2_CliCod ;
      private DateTime aP3_Fdesde ;
      private DateTime aP4_FHasta ;
      private int aP5_LinCod ;
      private int aP6_SubLCod ;
      private string aP7_Tipo ;
      private int aP8_TieCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00EO2_A149TipCod ;
      private string[] P00EO2_A24DocNum ;
      private bool[] P00EO2_n24DocNum ;
      private string[] P00EO2_A55ProdDsc ;
      private string[] P00EO2_A28ProdCod ;
      private string[] P00EO2_A941DocSts ;
      private string[] P00EO2_A946DocTipo ;
      private int[] P00EO2_A227DocVendCod ;
      private int[] P00EO2_A51SublCod ;
      private bool[] P00EO2_n51SublCod ;
      private int[] P00EO2_A52LinCod ;
      private string[] P00EO2_A231DocCliCod ;
      private int[] P00EO2_A178TieCod ;
      private bool[] P00EO2_n178TieCod ;
      private DateTime[] P00EO2_A232DocFec ;
      private decimal[] P00EO2_A894DocDpre ;
      private long[] P00EO2_A233DocItem ;
      private int[] P00EO3_A49UniCod ;
      private string[] P00EO3_A28ProdCod ;
      private string[] P00EO3_A941DocSts ;
      private string[] P00EO3_A946DocTipo ;
      private int[] P00EO3_A227DocVendCod ;
      private int[] P00EO3_A51SublCod ;
      private bool[] P00EO3_n51SublCod ;
      private string[] P00EO3_A231DocCliCod ;
      private int[] P00EO3_A52LinCod ;
      private int[] P00EO3_A178TieCod ;
      private bool[] P00EO3_n178TieCod ;
      private DateTime[] P00EO3_A232DocFec ;
      private decimal[] P00EO3_A894DocDpre ;
      private string[] P00EO3_A887DocCliDsc ;
      private string[] P00EO3_A1997UniAbr ;
      private string[] P00EO3_A24DocNum ;
      private bool[] P00EO3_n24DocNum ;
      private string[] P00EO3_A149TipCod ;
      private int[] P00EO3_A230DocMonCod ;
      private int[] P00EO3_A226DocMovCod ;
      private decimal[] P00EO3_A899DocDcto ;
      private decimal[] P00EO3_A892DocDTot ;
      private short[] P00EO3_A511TipSigno ;
      private decimal[] P00EO3_A895DocDCan ;
      private decimal[] P00EO3_A882DocAnticipos ;
      private DateTime[] P00EO3_A929DocFecRef ;
      private long[] P00EO3_A233DocItem ;
      private string[] P00EO4_A1370MVSts ;
      private string[] P00EO4_A23DocTip ;
      private bool[] P00EO4_n23DocTip ;
      private string[] P00EO4_A24DocNum ;
      private bool[] P00EO4_n24DocNum ;
      private string[] P00EO4_A14MvACod ;
      private string[] P00EO4_A13MvATip ;
      private int[] P00EO5_A235MovVCod ;
      private string[] P00EO5_A1242MovVAbr ;
      private string[] P00EO7_A24DocNum ;
      private bool[] P00EO7_n24DocNum ;
      private string[] P00EO7_A149TipCod ;
      private decimal[] P00EO7_A927DocSubExonerado ;
      private decimal[] P00EO7_A922DocSubSelectivo ;
      private decimal[] P00EO7_A921DocSubInafecto ;
      private decimal[] P00EO7_A920DocSubAfecto ;
   }

   public class rrdetalleventasxproducto__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EO2( IGxContext context ,
                                             int AV77TieCod ,
                                             string AV15CliCod ,
                                             string AV66ProdCod ,
                                             int AV55LinCod ,
                                             int AV72SubLCod ,
                                             int AV100VenCod ,
                                             string AV81Tipo ,
                                             int A178TieCod ,
                                             string A231DocCliCod ,
                                             string A28ProdCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV43Fdesde ,
                                             DateTime AV45FHasta ,
                                             string A941DocSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[8];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T1.[DocNum], T3.[ProdDsc], T1.[ProdCod], T2.[DocSts], T2.[DocTipo], T2.[DocVendCod], T3.[SublCod], T3.[LinCod], T2.[DocCliCod] AS DocCliCod, T2.[TieCod], T2.[DocFec], T1.[DocDpre], T1.[DocItem] FROM (([CLVENTASDET] T1 INNER JOIN [CLVENTAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod])";
         AddWhere(sWhereString, "(T2.[DocFec] >= @AV43Fdesde)");
         AddWhere(sWhereString, "(T2.[DocFec] <= @AV45FHasta)");
         AddWhere(sWhereString, "(T2.[DocSts] <> 'A')");
         if ( ! (0==AV77TieCod) )
         {
            AddWhere(sWhereString, "(T2.[TieCod] = @AV77TieCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[DocCliCod] = @AV15CliCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV66ProdCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV55LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV55LinCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV72SubLCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV72SubLCod)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV100VenCod) )
         {
            AddWhere(sWhereString, "(T2.[DocVendCod] = @AV100VenCod)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV81Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV81Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV81Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'X')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T3.[ProdDsc]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00EO3( IGxContext context ,
                                             int AV77TieCod ,
                                             int AV55LinCod ,
                                             string AV15CliCod ,
                                             int AV72SubLCod ,
                                             int AV100VenCod ,
                                             string AV81Tipo ,
                                             int A178TieCod ,
                                             int A52LinCod ,
                                             string A231DocCliCod ,
                                             int A51SublCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV43Fdesde ,
                                             DateTime AV45FHasta ,
                                             string A941DocSts ,
                                             string A28ProdCod ,
                                             string AV19Codigo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[8];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T1.[ProdCod], T5.[DocSts], T5.[DocTipo], T5.[DocVendCod], T2.[SublCod], T5.[DocCliCod] AS DocCliCod, T2.[LinCod], T5.[TieCod], T5.[DocFec], T1.[DocDpre], T6.[CliDsc] AS DocCliDsc, T3.[UniAbr], T1.[DocNum], T1.[TipCod], T5.[DocMonCod], T5.[DocMovCod], T5.[DocDcto], T1.[DocDTot], T4.[TipSigno], T1.[DocDCan], T5.[DocAnticipos], T5.[DocFecRef], T1.[DocItem] FROM ((((([CLVENTASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CTIPDOC] T4 ON T4.[TipCod] = T1.[TipCod]) INNER JOIN [CLVENTAS] T5 ON T5.[TipCod] = T1.[TipCod] AND T5.[DocNum] = T1.[DocNum]) INNER JOIN [CLCLIENTES] T6 ON T6.[CliCod] = T5.[DocCliCod])";
         AddWhere(sWhereString, "(T5.[DocFec] >= @AV43Fdesde)");
         AddWhere(sWhereString, "(T5.[DocFec] <= @AV45FHasta)");
         AddWhere(sWhereString, "(T5.[DocSts] <> 'A')");
         AddWhere(sWhereString, "(T1.[ProdCod] = @AV19Codigo)");
         if ( ! (0==AV77TieCod) )
         {
            AddWhere(sWhereString, "(T5.[TieCod] = @AV77TieCod)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV55LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV55LinCod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15CliCod)) )
         {
            AddWhere(sWhereString, "(T5.[DocCliCod] = @AV15CliCod)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV72SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV72SubLCod)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! (0==AV100VenCod) )
         {
            AddWhere(sWhereString, "(T5.[DocVendCod] = @AV100VenCod)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( StringUtil.StrCmp(AV81Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T5.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV81Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T5.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV81Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T5.[DocTipo] <> 'X')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T5.[DocCliCod], T5.[DocFec]";
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
               case 0 :
                     return conditional_P00EO2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] );
               case 1 :
                     return conditional_P00EO3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
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
          Object[] prmP00EO4;
          prmP00EO4 = new Object[] {
          new ParDef("@AV80TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV30DocNum",GXType.NChar,12,0)
          };
          Object[] prmP00EO5;
          prmP00EO5 = new Object[] {
          new ParDef("@AV29DocMovCod",GXType.Int32,6,0)
          };
          Object[] prmP00EO7;
          prmP00EO7 = new Object[] {
          new ParDef("@AV80TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV30DocNum",GXType.NChar,12,0)
          };
          Object[] prmP00EO2;
          prmP00EO2 = new Object[] {
          new ParDef("@AV43Fdesde",GXType.Date,8,0) ,
          new ParDef("@AV45FHasta",GXType.Date,8,0) ,
          new ParDef("@AV77TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV15CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV66ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV55LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV72SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV100VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00EO3;
          prmP00EO3 = new Object[] {
          new ParDef("@AV43Fdesde",GXType.Date,8,0) ,
          new ParDef("@AV45FHasta",GXType.Date,8,0) ,
          new ParDef("@AV19Codigo",GXType.NVarChar,20,0) ,
          new ParDef("@AV77TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV55LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV15CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV72SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV100VenCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EO2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EO3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EO3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EO4", "SELECT [MVSts], [DocTip], [DocNum], [MvACod], [MvATip] FROM [AGUIAS] WHERE ([DocTip] = @AV80TipCod and [DocNum] = @AV30DocNum) AND ([MVSts] <> 'A') ORDER BY [DocTip], [DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EO4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EO5", "SELECT [MovVCod], [MovVAbr] FROM [CMOVVENTAS] WHERE [MovVCod] = @AV29DocMovCod ORDER BY [MovVCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EO5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EO7", "SELECT T1.[DocNum], T1.[TipCod], COALESCE( T2.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T2.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T2.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T2.[DocSubAfecto], 0) AS DocSubAfecto FROM ([CLVENTAS] T1 LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) WHERE T1.[TipCod] = @AV80TipCod and T1.[DocNum] = @AV30DocNum ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EO7,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((string[]) buf[5])[0] = rslt.getString(6, 1);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 20);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(12);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
                ((long[]) buf[15])[0] = rslt.getLong(14);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(10);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 100);
                ((string[]) buf[14])[0] = rslt.getString(13, 5);
                ((string[]) buf[15])[0] = rslt.getString(14, 12);
                ((string[]) buf[16])[0] = rslt.getString(15, 3);
                ((int[]) buf[17])[0] = rslt.getInt(16);
                ((int[]) buf[18])[0] = rslt.getInt(17);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(19);
                ((short[]) buf[21])[0] = rslt.getShort(20);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(22);
                ((DateTime[]) buf[24])[0] = rslt.getGXDate(23);
                ((long[]) buf[25])[0] = rslt.getLong(24);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 12);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 12);
                ((string[]) buf[6])[0] = rslt.getString(5, 3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                return;
       }
    }

 }

}
