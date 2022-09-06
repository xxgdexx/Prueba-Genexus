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
   public class rrresumenventasxcliente : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrresumenventasxcliente.aspx")), "rrresumenventasxcliente.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrresumenventasxcliente.aspx")))) ;
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
               AV98VenCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV65ProdCod = GetPar( "ProdCod");
                  AV15CliCod = GetPar( "CliCod");
                  AV43Fdesde = context.localUtil.ParseDateParm( GetPar( "Fdesde"));
                  AV45FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV55LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
                  AV71SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV80Tipo = GetPar( "Tipo");
                  AV76TieCod = (int)(NumberUtil.Val( GetPar( "TieCod"), "."));
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

      public rrresumenventasxcliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrresumenventasxcliente( IGxContext context )
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
         this.AV98VenCod = aP0_VenCod;
         this.AV65ProdCod = aP1_ProdCod;
         this.AV15CliCod = aP2_CliCod;
         this.AV43Fdesde = aP3_Fdesde;
         this.AV45FHasta = aP4_FHasta;
         this.AV55LinCod = aP5_LinCod;
         this.AV71SubLCod = aP6_SubLCod;
         this.AV80Tipo = aP7_Tipo;
         this.AV76TieCod = aP8_TieCod;
         initialize();
         executePrivate();
         aP0_VenCod=this.AV98VenCod;
         aP1_ProdCod=this.AV65ProdCod;
         aP2_CliCod=this.AV15CliCod;
         aP3_Fdesde=this.AV43Fdesde;
         aP4_FHasta=this.AV45FHasta;
         aP5_LinCod=this.AV55LinCod;
         aP6_SubLCod=this.AV71SubLCod;
         aP7_Tipo=this.AV80Tipo;
         aP8_TieCod=this.AV76TieCod;
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
         return AV76TieCod ;
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
         rrresumenventasxcliente objrrresumenventasxcliente;
         objrrresumenventasxcliente = new rrresumenventasxcliente();
         objrrresumenventasxcliente.AV98VenCod = aP0_VenCod;
         objrrresumenventasxcliente.AV65ProdCod = aP1_ProdCod;
         objrrresumenventasxcliente.AV15CliCod = aP2_CliCod;
         objrrresumenventasxcliente.AV43Fdesde = aP3_Fdesde;
         objrrresumenventasxcliente.AV45FHasta = aP4_FHasta;
         objrrresumenventasxcliente.AV55LinCod = aP5_LinCod;
         objrrresumenventasxcliente.AV71SubLCod = aP6_SubLCod;
         objrrresumenventasxcliente.AV80Tipo = aP7_Tipo;
         objrrresumenventasxcliente.AV76TieCod = aP8_TieCod;
         objrrresumenventasxcliente.context.SetSubmitInitialConfig(context);
         objrrresumenventasxcliente.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrresumenventasxcliente);
         aP0_VenCod=this.AV98VenCod;
         aP1_ProdCod=this.AV65ProdCod;
         aP2_CliCod=this.AV15CliCod;
         aP3_Fdesde=this.AV43Fdesde;
         aP4_FHasta=this.AV45FHasta;
         aP5_LinCod=this.AV55LinCod;
         aP6_SubLCod=this.AV71SubLCod;
         aP7_Tipo=this.AV80Tipo;
         aP8_TieCod=this.AV76TieCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrresumenventasxcliente)stateInfo).executePrivate();
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
            AV37Empresa = AV70Session.Get("Empresa");
            AV36EmpDir = AV70Session.Get("EmpDir");
            AV38EmpRUC = AV70Session.Get("EmpRUC");
            AV68Ruta = AV70Session.Get("RUTA") + "/Logo.jpg";
            AV58Logo = AV68Ruta;
            AV101Logo_GXI = GXDbFile.PathToUrl( AV68Ruta);
            AV61Opcion = "Opcion : " + ((StringUtil.StrCmp(AV80Tipo, "T")==0) ? "Todos" : ((StringUtil.StrCmp(AV80Tipo, "M")==0) ? "Muestras" : "Ventas"));
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV76TieCod ,
                                                 AV15CliCod ,
                                                 AV65ProdCod ,
                                                 AV55LinCod ,
                                                 AV71SubLCod ,
                                                 AV98VenCod ,
                                                 AV80Tipo ,
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
            /* Using cursor P00EQ2 */
            pr_default.execute(0, new Object[] {AV43Fdesde, AV45FHasta, AV76TieCod, AV15CliCod, AV65ProdCod, AV55LinCod, AV71SubLCod, AV98VenCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKEQ3 = false;
               A149TipCod = P00EQ2_A149TipCod[0];
               A24DocNum = P00EQ2_A24DocNum[0];
               A887DocCliDsc = P00EQ2_A887DocCliDsc[0];
               A231DocCliCod = P00EQ2_A231DocCliCod[0];
               A941DocSts = P00EQ2_A941DocSts[0];
               A946DocTipo = P00EQ2_A946DocTipo[0];
               A227DocVendCod = P00EQ2_A227DocVendCod[0];
               A51SublCod = P00EQ2_A51SublCod[0];
               n51SublCod = P00EQ2_n51SublCod[0];
               A52LinCod = P00EQ2_A52LinCod[0];
               A28ProdCod = P00EQ2_A28ProdCod[0];
               A178TieCod = P00EQ2_A178TieCod[0];
               n178TieCod = P00EQ2_n178TieCod[0];
               A232DocFec = P00EQ2_A232DocFec[0];
               A894DocDpre = P00EQ2_A894DocDpre[0];
               A233DocItem = P00EQ2_A233DocItem[0];
               A231DocCliCod = P00EQ2_A231DocCliCod[0];
               A941DocSts = P00EQ2_A941DocSts[0];
               A946DocTipo = P00EQ2_A946DocTipo[0];
               A227DocVendCod = P00EQ2_A227DocVendCod[0];
               A178TieCod = P00EQ2_A178TieCod[0];
               n178TieCod = P00EQ2_n178TieCod[0];
               A232DocFec = P00EQ2_A232DocFec[0];
               A887DocCliDsc = P00EQ2_A887DocCliDsc[0];
               A51SublCod = P00EQ2_A51SublCod[0];
               n51SublCod = P00EQ2_n51SublCod[0];
               A52LinCod = P00EQ2_A52LinCod[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00EQ2_A231DocCliCod[0], A231DocCliCod) == 0 ) )
               {
                  BRKEQ3 = false;
                  A149TipCod = P00EQ2_A149TipCod[0];
                  A24DocNum = P00EQ2_A24DocNum[0];
                  A887DocCliDsc = P00EQ2_A887DocCliDsc[0];
                  A233DocItem = P00EQ2_A233DocItem[0];
                  A887DocCliDsc = P00EQ2_A887DocCliDsc[0];
                  BRKEQ3 = true;
                  pr_default.readNext(0);
               }
               AV57LineaCod = A231DocCliCod;
               AV56Linea = A887DocCliDsc;
               AV73TCantidad = 0.00m;
               AV91TTotalMN = 0.00m;
               AV90TTotalME = 0.00m;
               AV75TExpresadoMN = 0.00m;
               AV74TExpresadoME = 0.00m;
               HEQ0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Linea, "")), 2, Gx_line+3, 628, Gx_line+18, 0+256, 0, 0, 0) ;
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
               HEQ0( false, 40) ;
               getPrinter().GxDrawLine(444, Gx_line+8, 1095, Gx_line+8, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74TExpresadoME, "ZZZZZZ,ZZZ,ZZ9.99")), 964, Gx_line+15, 1089, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75TExpresadoMN, "ZZZZZZ,ZZZ,ZZ9.99")), 822, Gx_line+15, 947, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV90TTotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 688, Gx_line+15, 813, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV91TTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 547, Gx_line+15, 672, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73TCantidad, "ZZZZ,ZZZ,ZZ9.9999")), 418, Gx_line+15, 543, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("TOTAL", 345, Gx_line+15, 384, Gx_line+29, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               AV92TTTCantidad = (decimal)(AV92TTTCantidad+AV73TCantidad);
               AV96TTTotalMN = (decimal)(AV96TTTotalMN+AV91TTotalMN);
               AV95TTTotalME = (decimal)(AV95TTTotalME+AV90TTotalME);
               AV94TTTExpresadoMN = (decimal)(AV94TTTExpresadoMN+AV75TExpresadoMN);
               AV93TTTExpresadoME = (decimal)(AV93TTTExpresadoME+AV74TExpresadoME);
               if ( ! BRKEQ3 )
               {
                  BRKEQ3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HEQ0( false, 60) ;
            getPrinter().GxDrawLine(444, Gx_line+17, 1097, Gx_line+17, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV92TTTCantidad, "ZZZZ,ZZZ,ZZ9.9999")), 418, Gx_line+23, 543, Gx_line+38, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV96TTTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 547, Gx_line+23, 672, Gx_line+38, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV95TTTotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 688, Gx_line+23, 813, Gx_line+38, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV94TTTExpresadoMN, "ZZZZZZ,ZZZ,ZZ9.99")), 822, Gx_line+23, 947, Gx_line+38, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV93TTTExpresadoME, "ZZZZZZ,ZZZ,ZZ9.99")), 964, Gx_line+23, 1089, Gx_line+38, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("TOTAL GENERAL", 291, Gx_line+23, 384, Gx_line+37, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+60);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HEQ0( true, 0) ;
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
                                              AV76TieCod ,
                                              AV55LinCod ,
                                              AV65ProdCod ,
                                              AV71SubLCod ,
                                              AV98VenCod ,
                                              AV80Tipo ,
                                              A178TieCod ,
                                              A52LinCod ,
                                              A28ProdCod ,
                                              A51SublCod ,
                                              A227DocVendCod ,
                                              A946DocTipo ,
                                              A232DocFec ,
                                              AV43Fdesde ,
                                              AV45FHasta ,
                                              A941DocSts ,
                                              A231DocCliCod ,
                                              AV57LineaCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00EQ3 */
         pr_default.execute(1, new Object[] {AV43Fdesde, AV45FHasta, AV57LineaCod, AV76TieCod, AV55LinCod, AV65ProdCod, AV71SubLCod, AV98VenCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKEQ5 = false;
            A149TipCod = P00EQ3_A149TipCod[0];
            A24DocNum = P00EQ3_A24DocNum[0];
            A49UniCod = P00EQ3_A49UniCod[0];
            A55ProdDsc = P00EQ3_A55ProdDsc[0];
            A28ProdCod = P00EQ3_A28ProdCod[0];
            A941DocSts = P00EQ3_A941DocSts[0];
            A946DocTipo = P00EQ3_A946DocTipo[0];
            A227DocVendCod = P00EQ3_A227DocVendCod[0];
            A51SublCod = P00EQ3_A51SublCod[0];
            n51SublCod = P00EQ3_n51SublCod[0];
            A52LinCod = P00EQ3_A52LinCod[0];
            A178TieCod = P00EQ3_A178TieCod[0];
            n178TieCod = P00EQ3_n178TieCod[0];
            A231DocCliCod = P00EQ3_A231DocCliCod[0];
            A232DocFec = P00EQ3_A232DocFec[0];
            A894DocDpre = P00EQ3_A894DocDpre[0];
            A1997UniAbr = P00EQ3_A1997UniAbr[0];
            A233DocItem = P00EQ3_A233DocItem[0];
            A941DocSts = P00EQ3_A941DocSts[0];
            A946DocTipo = P00EQ3_A946DocTipo[0];
            A227DocVendCod = P00EQ3_A227DocVendCod[0];
            A178TieCod = P00EQ3_A178TieCod[0];
            n178TieCod = P00EQ3_n178TieCod[0];
            A231DocCliCod = P00EQ3_A231DocCliCod[0];
            A232DocFec = P00EQ3_A232DocFec[0];
            A49UniCod = P00EQ3_A49UniCod[0];
            A55ProdDsc = P00EQ3_A55ProdDsc[0];
            A51SublCod = P00EQ3_A51SublCod[0];
            n51SublCod = P00EQ3_n51SublCod[0];
            A52LinCod = P00EQ3_A52LinCod[0];
            A1997UniAbr = P00EQ3_A1997UniAbr[0];
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00EQ3_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRKEQ5 = false;
               A149TipCod = P00EQ3_A149TipCod[0];
               A24DocNum = P00EQ3_A24DocNum[0];
               A55ProdDsc = P00EQ3_A55ProdDsc[0];
               A233DocItem = P00EQ3_A233DocItem[0];
               A55ProdDsc = P00EQ3_A55ProdDsc[0];
               BRKEQ5 = true;
               pr_default.readNext(1);
            }
            AV67Producto = StringUtil.Trim( A28ProdCod);
            AV66ProdDsc = StringUtil.Trim( A55ProdDsc);
            AV97UniAbr = StringUtil.Trim( A1997UniAbr);
            AV11Cantidad = 0.00m;
            AV83TotalMN = 0.00m;
            AV82TotalME = 0.00m;
            AV42ExpresadoMN = 0.00m;
            AV41ExpresadoME = 0.00m;
            /* Execute user subroutine: 'PRODUCTO' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            HEQ0( false, 22) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66ProdDsc, "")), 2, Gx_line+4, 380, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97UniAbr, "")), 385, Gx_line+4, 438, Gx_line+19, 1+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV11Cantidad, "ZZZZ,ZZZ,ZZ9.9999")), 429, Gx_line+4, 536, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV83TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 565, Gx_line+4, 672, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV82TotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 705, Gx_line+4, 812, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42ExpresadoMN, "ZZZZZZ,ZZZ,ZZ9.99")), 840, Gx_line+4, 947, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41ExpresadoME, "ZZZZZZ,ZZZ,ZZ9.99")), 981, Gx_line+4, 1088, Gx_line+19, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+22);
            AV73TCantidad = (decimal)(AV73TCantidad+AV11Cantidad);
            AV91TTotalMN = (decimal)(AV91TTotalMN+AV83TotalMN);
            AV90TTotalME = (decimal)(AV90TTotalME+AV82TotalME);
            AV75TExpresadoMN = (decimal)(AV75TExpresadoMN+AV42ExpresadoMN);
            AV74TExpresadoME = (decimal)(AV74TExpresadoME+AV41ExpresadoME);
            if ( ! BRKEQ5 )
            {
               BRKEQ5 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S125( )
      {
         /* 'PRODUCTO' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV76TieCod ,
                                              AV55LinCod ,
                                              AV71SubLCod ,
                                              AV98VenCod ,
                                              AV80Tipo ,
                                              A178TieCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A227DocVendCod ,
                                              A946DocTipo ,
                                              A232DocFec ,
                                              AV43Fdesde ,
                                              AV45FHasta ,
                                              A941DocSts ,
                                              A231DocCliCod ,
                                              AV57LineaCod ,
                                              AV67Producto ,
                                              A28ProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00EQ4 */
         pr_default.execute(2, new Object[] {AV67Producto, AV43Fdesde, AV45FHasta, AV57LineaCod, AV76TieCod, AV55LinCod, AV71SubLCod, AV98VenCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A941DocSts = P00EQ4_A941DocSts[0];
            A946DocTipo = P00EQ4_A946DocTipo[0];
            A227DocVendCod = P00EQ4_A227DocVendCod[0];
            A51SublCod = P00EQ4_A51SublCod[0];
            n51SublCod = P00EQ4_n51SublCod[0];
            A28ProdCod = P00EQ4_A28ProdCod[0];
            A52LinCod = P00EQ4_A52LinCod[0];
            A178TieCod = P00EQ4_A178TieCod[0];
            n178TieCod = P00EQ4_n178TieCod[0];
            A231DocCliCod = P00EQ4_A231DocCliCod[0];
            A232DocFec = P00EQ4_A232DocFec[0];
            A894DocDpre = P00EQ4_A894DocDpre[0];
            A149TipCod = P00EQ4_A149TipCod[0];
            A24DocNum = P00EQ4_A24DocNum[0];
            A230DocMonCod = P00EQ4_A230DocMonCod[0];
            A226DocMovCod = P00EQ4_A226DocMovCod[0];
            A899DocDcto = P00EQ4_A899DocDcto[0];
            A892DocDTot = P00EQ4_A892DocDTot[0];
            A511TipSigno = P00EQ4_A511TipSigno[0];
            A895DocDCan = P00EQ4_A895DocDCan[0];
            A882DocAnticipos = P00EQ4_A882DocAnticipos[0];
            A929DocFecRef = P00EQ4_A929DocFecRef[0];
            A233DocItem = P00EQ4_A233DocItem[0];
            A51SublCod = P00EQ4_A51SublCod[0];
            n51SublCod = P00EQ4_n51SublCod[0];
            A52LinCod = P00EQ4_A52LinCod[0];
            A511TipSigno = P00EQ4_A511TipSigno[0];
            A941DocSts = P00EQ4_A941DocSts[0];
            A946DocTipo = P00EQ4_A946DocTipo[0];
            A227DocVendCod = P00EQ4_A227DocVendCod[0];
            A178TieCod = P00EQ4_A178TieCod[0];
            n178TieCod = P00EQ4_n178TieCod[0];
            A231DocCliCod = P00EQ4_A231DocCliCod[0];
            A232DocFec = P00EQ4_A232DocFec[0];
            A230DocMonCod = P00EQ4_A230DocMonCod[0];
            A226DocMovCod = P00EQ4_A226DocMovCod[0];
            A899DocDcto = P00EQ4_A899DocDcto[0];
            A882DocAnticipos = P00EQ4_A882DocAnticipos[0];
            A929DocFecRef = P00EQ4_A929DocFecRef[0];
            AV79TipCod = A149TipCod;
            AV30DocNum = A24DocNum;
            AV44Fecha = A232DocFec;
            AV59MonCod = A230DocMonCod;
            AV29DocMovCod = A226DocMovCod;
            AV64PorDscto = A899DocDcto;
            AV19Descuento = NumberUtil.Round( (NumberUtil.Round( A892DocDTot, 2)*AV64PorDscto)/ (decimal)(100), 2);
            AV81Total = NumberUtil.Round( (NumberUtil.Round( A892DocDTot, 2)-AV19Descuento)*A511TipSigno, 2);
            AV24DocDCan = NumberUtil.Round( A895DocDCan*A511TipSigno, 4);
            AV21DocAnticipos = (decimal)(NumberUtil.Round( A882DocAnticipos, 2)*A511TipSigno);
            if ( ( StringUtil.StrCmp(AV79TipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV79TipCod, "ND") == 0 ) )
            {
               /* Execute user subroutine: 'VALIDATIPOMOVIMIENTO' */
               S137 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
               AV44Fecha = ((StringUtil.StrCmp(AV79TipCod, "NC")==0)||(StringUtil.StrCmp(AV79TipCod, "ND")==0) ? A929DocFecRef : A232DocFec);
            }
            if ( ! (Convert.ToDecimal(0)==AV21DocAnticipos) )
            {
               /* Execute user subroutine: 'SUBTOTAL' */
               S147 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
               AV63Porcentaje = NumberUtil.Round( AV81Total/ (decimal)(((Convert.ToDecimal(0)==AV72SubTotal) ? (decimal)(1) : AV72SubTotal)), 10);
               AV9Anticipo = NumberUtil.Round( AV63Porcentaje*AV21DocAnticipos, 2);
            }
            else
            {
               AV63Porcentaje = 0.00m;
               AV9Anticipo = 0.00m;
               AV72SubTotal = 0.00m;
            }
            AV81Total = (decimal)(AV81Total-(AV9Anticipo+AV19Descuento));
            AV11Cantidad = (decimal)(AV11Cantidad+AV24DocDCan);
            GXt_decimal1 = AV10Cambio;
            GXt_int2 = 2;
            GXt_char3 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV44Fecha, ref  GXt_char3, out  GXt_decimal1) ;
            AV10Cambio = GXt_decimal1;
            AV83TotalMN = (decimal)(AV83TotalMN+(((AV59MonCod==1) ? AV81Total : (decimal)(0))));
            AV82TotalME = (decimal)(AV82TotalME+(((AV59MonCod==1) ? (decimal)(0) : AV81Total)));
            AV42ExpresadoMN = (decimal)(AV42ExpresadoMN+(((AV59MonCod==1) ? AV81Total : NumberUtil.Round( AV81Total*AV10Cambio, 2))));
            AV41ExpresadoME = (decimal)(AV41ExpresadoME+(((AV59MonCod==1) ? NumberUtil.Round( AV81Total/ (decimal)(AV10Cambio), 2) : AV81Total)));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S137( )
      {
         /* 'VALIDATIPOMOVIMIENTO' Routine */
         returnInSub = false;
         /* Using cursor P00EQ5 */
         pr_default.execute(3, new Object[] {AV29DocMovCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A235MovVCod = P00EQ5_A235MovVCod[0];
            A1242MovVAbr = P00EQ5_A1242MovVAbr[0];
            if ( ! ( StringUtil.StrCmp(A1242MovVAbr, "SI") == 0 ) )
            {
               AV24DocDCan = 0.00m;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void S147( )
      {
         /* 'SUBTOTAL' Routine */
         returnInSub = false;
         /* Using cursor P00EQ7 */
         pr_default.execute(4, new Object[] {AV79TipCod, AV30DocNum});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A24DocNum = P00EQ7_A24DocNum[0];
            A149TipCod = P00EQ7_A149TipCod[0];
            A927DocSubExonerado = P00EQ7_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EQ7_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EQ7_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EQ7_A920DocSubAfecto[0];
            A927DocSubExonerado = P00EQ7_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EQ7_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EQ7_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EQ7_A920DocSubAfecto[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            AV72SubTotal = NumberUtil.Round( A919DocSub, 2);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void HEQ0( bool bFoot ,
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
               getPrinter().GxDrawText("PRODUCTO", 134, Gx_line+92, 199, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("TOTAL", 734, Gx_line+84, 773, Gx_line+98, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+81, 1097, Gx_line+116, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Ventas por Clientes", 425, Gx_line+28, 701, Gx_line+48, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("CANTIDAD", 465, Gx_line+92, 526, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("TOTAL", 593, Gx_line+84, 632, Gx_line+98, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Empresa, "")), 19, Gx_line+11, 404, Gx_line+29, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(381, Gx_line+81, 381, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(546, Gx_line+82, 546, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(682, Gx_line+82, 682, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(952, Gx_line+81, 952, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(817, Gx_line+82, 817, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(444, Gx_line+81, 444, Gx_line+116, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("UNIDAD", 389, Gx_line+92, 436, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde", 425, Gx_line+53, 465, Gx_line+68, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV43Fdesde, "99/99/99"), 485, Gx_line+48, 559, Gx_line+72, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 585, Gx_line+53, 622, Gx_line+68, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV45FHasta, "99/99/99"), 636, Gx_line+48, 710, Gx_line+72, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("FACTURADO MN", 566, Gx_line+99, 659, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FACTURADO ME", 707, Gx_line+99, 799, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("EXPRESADO MN", 841, Gx_line+92, 931, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("EXPRESADO ME", 979, Gx_line+92, 1068, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61Opcion, "")), 5, Gx_line+60, 266, Gx_line+76, 0+256, 0, 0, 0) ;
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
         AV70Session = context.GetSession();
         AV36EmpDir = "";
         AV38EmpRUC = "";
         AV68Ruta = "";
         AV58Logo = "";
         AV101Logo_GXI = "";
         AV61Opcion = "";
         scmdbuf = "";
         A231DocCliCod = "";
         A28ProdCod = "";
         A946DocTipo = "";
         A232DocFec = DateTime.MinValue;
         A941DocSts = "";
         P00EQ2_A149TipCod = new string[] {""} ;
         P00EQ2_A24DocNum = new string[] {""} ;
         P00EQ2_A887DocCliDsc = new string[] {""} ;
         P00EQ2_A231DocCliCod = new string[] {""} ;
         P00EQ2_A941DocSts = new string[] {""} ;
         P00EQ2_A946DocTipo = new string[] {""} ;
         P00EQ2_A227DocVendCod = new int[1] ;
         P00EQ2_A51SublCod = new int[1] ;
         P00EQ2_n51SublCod = new bool[] {false} ;
         P00EQ2_A52LinCod = new int[1] ;
         P00EQ2_A28ProdCod = new string[] {""} ;
         P00EQ2_A178TieCod = new int[1] ;
         P00EQ2_n178TieCod = new bool[] {false} ;
         P00EQ2_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EQ2_A894DocDpre = new decimal[1] ;
         P00EQ2_A233DocItem = new long[1] ;
         A149TipCod = "";
         A24DocNum = "";
         A887DocCliDsc = "";
         AV57LineaCod = "";
         AV56Linea = "";
         P00EQ3_A149TipCod = new string[] {""} ;
         P00EQ3_A24DocNum = new string[] {""} ;
         P00EQ3_A49UniCod = new int[1] ;
         P00EQ3_A55ProdDsc = new string[] {""} ;
         P00EQ3_A28ProdCod = new string[] {""} ;
         P00EQ3_A941DocSts = new string[] {""} ;
         P00EQ3_A946DocTipo = new string[] {""} ;
         P00EQ3_A227DocVendCod = new int[1] ;
         P00EQ3_A51SublCod = new int[1] ;
         P00EQ3_n51SublCod = new bool[] {false} ;
         P00EQ3_A52LinCod = new int[1] ;
         P00EQ3_A178TieCod = new int[1] ;
         P00EQ3_n178TieCod = new bool[] {false} ;
         P00EQ3_A231DocCliCod = new string[] {""} ;
         P00EQ3_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EQ3_A894DocDpre = new decimal[1] ;
         P00EQ3_A1997UniAbr = new string[] {""} ;
         P00EQ3_A233DocItem = new long[1] ;
         A55ProdDsc = "";
         A1997UniAbr = "";
         AV67Producto = "";
         AV66ProdDsc = "";
         AV97UniAbr = "";
         P00EQ4_A941DocSts = new string[] {""} ;
         P00EQ4_A946DocTipo = new string[] {""} ;
         P00EQ4_A227DocVendCod = new int[1] ;
         P00EQ4_A51SublCod = new int[1] ;
         P00EQ4_n51SublCod = new bool[] {false} ;
         P00EQ4_A28ProdCod = new string[] {""} ;
         P00EQ4_A52LinCod = new int[1] ;
         P00EQ4_A178TieCod = new int[1] ;
         P00EQ4_n178TieCod = new bool[] {false} ;
         P00EQ4_A231DocCliCod = new string[] {""} ;
         P00EQ4_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EQ4_A894DocDpre = new decimal[1] ;
         P00EQ4_A149TipCod = new string[] {""} ;
         P00EQ4_A24DocNum = new string[] {""} ;
         P00EQ4_A230DocMonCod = new int[1] ;
         P00EQ4_A226DocMovCod = new int[1] ;
         P00EQ4_A899DocDcto = new decimal[1] ;
         P00EQ4_A892DocDTot = new decimal[1] ;
         P00EQ4_A511TipSigno = new short[1] ;
         P00EQ4_A895DocDCan = new decimal[1] ;
         P00EQ4_A882DocAnticipos = new decimal[1] ;
         P00EQ4_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P00EQ4_A233DocItem = new long[1] ;
         A929DocFecRef = DateTime.MinValue;
         AV79TipCod = "";
         AV30DocNum = "";
         AV44Fecha = DateTime.MinValue;
         GXt_char3 = "";
         P00EQ5_A235MovVCod = new int[1] ;
         P00EQ5_A1242MovVAbr = new string[] {""} ;
         A1242MovVAbr = "";
         P00EQ7_A24DocNum = new string[] {""} ;
         P00EQ7_A149TipCod = new string[] {""} ;
         P00EQ7_A927DocSubExonerado = new decimal[1] ;
         P00EQ7_A922DocSubSelectivo = new decimal[1] ;
         P00EQ7_A921DocSubInafecto = new decimal[1] ;
         P00EQ7_A920DocSubAfecto = new decimal[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrresumenventasxcliente__default(),
            new Object[][] {
                new Object[] {
               P00EQ2_A149TipCod, P00EQ2_A24DocNum, P00EQ2_A887DocCliDsc, P00EQ2_A231DocCliCod, P00EQ2_A941DocSts, P00EQ2_A946DocTipo, P00EQ2_A227DocVendCod, P00EQ2_A51SublCod, P00EQ2_n51SublCod, P00EQ2_A52LinCod,
               P00EQ2_A28ProdCod, P00EQ2_A178TieCod, P00EQ2_n178TieCod, P00EQ2_A232DocFec, P00EQ2_A894DocDpre, P00EQ2_A233DocItem
               }
               , new Object[] {
               P00EQ3_A149TipCod, P00EQ3_A24DocNum, P00EQ3_A49UniCod, P00EQ3_A55ProdDsc, P00EQ3_A28ProdCod, P00EQ3_A941DocSts, P00EQ3_A946DocTipo, P00EQ3_A227DocVendCod, P00EQ3_A51SublCod, P00EQ3_n51SublCod,
               P00EQ3_A52LinCod, P00EQ3_A178TieCod, P00EQ3_n178TieCod, P00EQ3_A231DocCliCod, P00EQ3_A232DocFec, P00EQ3_A894DocDpre, P00EQ3_A1997UniAbr, P00EQ3_A233DocItem
               }
               , new Object[] {
               P00EQ4_A941DocSts, P00EQ4_A946DocTipo, P00EQ4_A227DocVendCod, P00EQ4_A51SublCod, P00EQ4_n51SublCod, P00EQ4_A28ProdCod, P00EQ4_A52LinCod, P00EQ4_A178TieCod, P00EQ4_n178TieCod, P00EQ4_A231DocCliCod,
               P00EQ4_A232DocFec, P00EQ4_A894DocDpre, P00EQ4_A149TipCod, P00EQ4_A24DocNum, P00EQ4_A230DocMonCod, P00EQ4_A226DocMovCod, P00EQ4_A899DocDcto, P00EQ4_A892DocDTot, P00EQ4_A511TipSigno, P00EQ4_A895DocDCan,
               P00EQ4_A882DocAnticipos, P00EQ4_A929DocFecRef, P00EQ4_A233DocItem
               }
               , new Object[] {
               P00EQ5_A235MovVCod, P00EQ5_A1242MovVAbr
               }
               , new Object[] {
               P00EQ7_A24DocNum, P00EQ7_A149TipCod, P00EQ7_A927DocSubExonerado, P00EQ7_A922DocSubSelectivo, P00EQ7_A921DocSubInafecto, P00EQ7_A920DocSubAfecto
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
      private int AV98VenCod ;
      private int AV55LinCod ;
      private int AV71SubLCod ;
      private int AV76TieCod ;
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
      private decimal AV73TCantidad ;
      private decimal AV91TTotalMN ;
      private decimal AV90TTotalME ;
      private decimal AV75TExpresadoMN ;
      private decimal AV74TExpresadoME ;
      private decimal AV92TTTCantidad ;
      private decimal AV96TTTotalMN ;
      private decimal AV95TTTotalME ;
      private decimal AV94TTTExpresadoMN ;
      private decimal AV93TTTExpresadoME ;
      private decimal AV11Cantidad ;
      private decimal AV83TotalMN ;
      private decimal AV82TotalME ;
      private decimal AV42ExpresadoMN ;
      private decimal AV41ExpresadoME ;
      private decimal A899DocDcto ;
      private decimal A892DocDTot ;
      private decimal A895DocDCan ;
      private decimal A882DocAnticipos ;
      private decimal AV64PorDscto ;
      private decimal AV19Descuento ;
      private decimal AV81Total ;
      private decimal AV24DocDCan ;
      private decimal AV21DocAnticipos ;
      private decimal AV63Porcentaje ;
      private decimal AV72SubTotal ;
      private decimal AV9Anticipo ;
      private decimal AV10Cambio ;
      private decimal GXt_decimal1 ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A919DocSub ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV65ProdCod ;
      private string AV15CliCod ;
      private string AV80Tipo ;
      private string AV37Empresa ;
      private string AV36EmpDir ;
      private string AV38EmpRUC ;
      private string AV68Ruta ;
      private string AV61Opcion ;
      private string scmdbuf ;
      private string A231DocCliCod ;
      private string A28ProdCod ;
      private string A946DocTipo ;
      private string A941DocSts ;
      private string A149TipCod ;
      private string A24DocNum ;
      private string A887DocCliDsc ;
      private string AV57LineaCod ;
      private string AV56Linea ;
      private string A55ProdDsc ;
      private string A1997UniAbr ;
      private string AV67Producto ;
      private string AV66ProdDsc ;
      private string AV97UniAbr ;
      private string AV79TipCod ;
      private string AV30DocNum ;
      private string GXt_char3 ;
      private string A1242MovVAbr ;
      private string Gx_time ;
      private DateTime AV43Fdesde ;
      private DateTime AV45FHasta ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV44Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKEQ3 ;
      private bool n51SublCod ;
      private bool n178TieCod ;
      private bool returnInSub ;
      private bool BRKEQ5 ;
      private string AV101Logo_GXI ;
      private string AV58Logo ;
      private IGxSession AV70Session ;
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
      private string[] P00EQ2_A149TipCod ;
      private string[] P00EQ2_A24DocNum ;
      private string[] P00EQ2_A887DocCliDsc ;
      private string[] P00EQ2_A231DocCliCod ;
      private string[] P00EQ2_A941DocSts ;
      private string[] P00EQ2_A946DocTipo ;
      private int[] P00EQ2_A227DocVendCod ;
      private int[] P00EQ2_A51SublCod ;
      private bool[] P00EQ2_n51SublCod ;
      private int[] P00EQ2_A52LinCod ;
      private string[] P00EQ2_A28ProdCod ;
      private int[] P00EQ2_A178TieCod ;
      private bool[] P00EQ2_n178TieCod ;
      private DateTime[] P00EQ2_A232DocFec ;
      private decimal[] P00EQ2_A894DocDpre ;
      private long[] P00EQ2_A233DocItem ;
      private string[] P00EQ3_A149TipCod ;
      private string[] P00EQ3_A24DocNum ;
      private int[] P00EQ3_A49UniCod ;
      private string[] P00EQ3_A55ProdDsc ;
      private string[] P00EQ3_A28ProdCod ;
      private string[] P00EQ3_A941DocSts ;
      private string[] P00EQ3_A946DocTipo ;
      private int[] P00EQ3_A227DocVendCod ;
      private int[] P00EQ3_A51SublCod ;
      private bool[] P00EQ3_n51SublCod ;
      private int[] P00EQ3_A52LinCod ;
      private int[] P00EQ3_A178TieCod ;
      private bool[] P00EQ3_n178TieCod ;
      private string[] P00EQ3_A231DocCliCod ;
      private DateTime[] P00EQ3_A232DocFec ;
      private decimal[] P00EQ3_A894DocDpre ;
      private string[] P00EQ3_A1997UniAbr ;
      private long[] P00EQ3_A233DocItem ;
      private string[] P00EQ4_A941DocSts ;
      private string[] P00EQ4_A946DocTipo ;
      private int[] P00EQ4_A227DocVendCod ;
      private int[] P00EQ4_A51SublCod ;
      private bool[] P00EQ4_n51SublCod ;
      private string[] P00EQ4_A28ProdCod ;
      private int[] P00EQ4_A52LinCod ;
      private int[] P00EQ4_A178TieCod ;
      private bool[] P00EQ4_n178TieCod ;
      private string[] P00EQ4_A231DocCliCod ;
      private DateTime[] P00EQ4_A232DocFec ;
      private decimal[] P00EQ4_A894DocDpre ;
      private string[] P00EQ4_A149TipCod ;
      private string[] P00EQ4_A24DocNum ;
      private int[] P00EQ4_A230DocMonCod ;
      private int[] P00EQ4_A226DocMovCod ;
      private decimal[] P00EQ4_A899DocDcto ;
      private decimal[] P00EQ4_A892DocDTot ;
      private short[] P00EQ4_A511TipSigno ;
      private decimal[] P00EQ4_A895DocDCan ;
      private decimal[] P00EQ4_A882DocAnticipos ;
      private DateTime[] P00EQ4_A929DocFecRef ;
      private long[] P00EQ4_A233DocItem ;
      private int[] P00EQ5_A235MovVCod ;
      private string[] P00EQ5_A1242MovVAbr ;
      private string[] P00EQ7_A24DocNum ;
      private string[] P00EQ7_A149TipCod ;
      private decimal[] P00EQ7_A927DocSubExonerado ;
      private decimal[] P00EQ7_A922DocSubSelectivo ;
      private decimal[] P00EQ7_A921DocSubInafecto ;
      private decimal[] P00EQ7_A920DocSubAfecto ;
   }

   public class rrresumenventasxcliente__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EQ2( IGxContext context ,
                                             int AV76TieCod ,
                                             string AV15CliCod ,
                                             string AV65ProdCod ,
                                             int AV55LinCod ,
                                             int AV71SubLCod ,
                                             int AV98VenCod ,
                                             string AV80Tipo ,
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
         scmdbuf = "SELECT T1.[TipCod], T1.[DocNum], T3.[CliDsc] AS DocCliDsc, T2.[DocCliCod] AS DocCliCod, T2.[DocSts], T2.[DocTipo], T2.[DocVendCod], T4.[SublCod], T4.[LinCod], T1.[ProdCod], T2.[TieCod], T2.[DocFec], T1.[DocDpre], T1.[DocItem] FROM ((([CLVENTASDET] T1 INNER JOIN [CLVENTAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T2.[DocCliCod]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod])";
         AddWhere(sWhereString, "(T2.[DocFec] >= @AV43Fdesde)");
         AddWhere(sWhereString, "(T2.[DocFec] <= @AV45FHasta)");
         AddWhere(sWhereString, "(T2.[DocSts] <> 'A')");
         if ( ! (0==AV76TieCod) )
         {
            AddWhere(sWhereString, "(T2.[TieCod] = @AV76TieCod)");
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV65ProdCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV55LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV55LinCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV71SubLCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV71SubLCod)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV98VenCod) )
         {
            AddWhere(sWhereString, "(T2.[DocVendCod] = @AV98VenCod)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV80Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV80Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV80Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'X')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[DocCliCod], T3.[CliDsc]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00EQ3( IGxContext context ,
                                             int AV76TieCod ,
                                             int AV55LinCod ,
                                             string AV65ProdCod ,
                                             int AV71SubLCod ,
                                             int AV98VenCod ,
                                             string AV80Tipo ,
                                             int A178TieCod ,
                                             int A52LinCod ,
                                             string A28ProdCod ,
                                             int A51SublCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV43Fdesde ,
                                             DateTime AV45FHasta ,
                                             string A941DocSts ,
                                             string A231DocCliCod ,
                                             string AV57LineaCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[8];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T1.[DocNum], T3.[UniCod], T3.[ProdDsc], T1.[ProdCod], T2.[DocSts], T2.[DocTipo], T2.[DocVendCod], T3.[SublCod], T3.[LinCod], T2.[TieCod], T2.[DocCliCod] AS DocCliCod, T2.[DocFec], T1.[DocDpre], T4.[UniAbr], T1.[DocItem] FROM ((([CLVENTASDET] T1 INNER JOIN [CLVENTAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T4 ON T4.[UniCod] = T3.[UniCod])";
         AddWhere(sWhereString, "(T2.[DocFec] >= @AV43Fdesde)");
         AddWhere(sWhereString, "(T2.[DocFec] <= @AV45FHasta)");
         AddWhere(sWhereString, "(T2.[DocSts] <> 'A')");
         AddWhere(sWhereString, "(T2.[DocCliCod] = @AV57LineaCod)");
         if ( ! (0==AV76TieCod) )
         {
            AddWhere(sWhereString, "(T2.[TieCod] = @AV76TieCod)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV55LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV55LinCod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV65ProdCod)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV71SubLCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV71SubLCod)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! (0==AV98VenCod) )
         {
            AddWhere(sWhereString, "(T2.[DocVendCod] = @AV98VenCod)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( StringUtil.StrCmp(AV80Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV80Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV80Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'X')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T3.[ProdDsc]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00EQ4( IGxContext context ,
                                             int AV76TieCod ,
                                             int AV55LinCod ,
                                             int AV71SubLCod ,
                                             int AV98VenCod ,
                                             string AV80Tipo ,
                                             int A178TieCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV43Fdesde ,
                                             DateTime AV45FHasta ,
                                             string A941DocSts ,
                                             string A231DocCliCod ,
                                             string AV57LineaCod ,
                                             string AV67Producto ,
                                             string A28ProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[8];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T4.[DocSts], T4.[DocTipo], T4.[DocVendCod], T2.[SublCod], T1.[ProdCod], T2.[LinCod], T4.[TieCod], T4.[DocCliCod] AS DocCliCod, T4.[DocFec], T1.[DocDpre], T1.[TipCod], T1.[DocNum], T4.[DocMonCod], T4.[DocMovCod], T4.[DocDcto], T1.[DocDTot], T3.[TipSigno], T1.[DocDCan], T4.[DocAnticipos], T4.[DocFecRef], T1.[DocItem] FROM ((([CLVENTASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CLVENTAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum])";
         AddWhere(sWhereString, "(T1.[ProdCod] = @AV67Producto)");
         AddWhere(sWhereString, "(T4.[DocFec] >= @AV43Fdesde)");
         AddWhere(sWhereString, "(T4.[DocFec] <= @AV45FHasta)");
         AddWhere(sWhereString, "(T4.[DocSts] <> 'A')");
         AddWhere(sWhereString, "(T4.[DocCliCod] = @AV57LineaCod)");
         if ( ! (0==AV76TieCod) )
         {
            AddWhere(sWhereString, "(T4.[TieCod] = @AV76TieCod)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! (0==AV55LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV55LinCod)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (0==AV71SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV71SubLCod)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! (0==AV98VenCod) )
         {
            AddWhere(sWhereString, "(T4.[DocVendCod] = @AV98VenCod)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV80Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV80Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV80Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] <> 'X')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00EQ2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] );
               case 1 :
                     return conditional_P00EQ3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
               case 2 :
                     return conditional_P00EQ4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
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
          Object[] prmP00EQ5;
          prmP00EQ5 = new Object[] {
          new ParDef("@AV29DocMovCod",GXType.Int32,6,0)
          };
          Object[] prmP00EQ7;
          prmP00EQ7 = new Object[] {
          new ParDef("@AV79TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV30DocNum",GXType.NChar,12,0)
          };
          Object[] prmP00EQ2;
          prmP00EQ2 = new Object[] {
          new ParDef("@AV43Fdesde",GXType.Date,8,0) ,
          new ParDef("@AV45FHasta",GXType.Date,8,0) ,
          new ParDef("@AV76TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV15CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV65ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV55LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV71SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV98VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00EQ3;
          prmP00EQ3 = new Object[] {
          new ParDef("@AV43Fdesde",GXType.Date,8,0) ,
          new ParDef("@AV45FHasta",GXType.Date,8,0) ,
          new ParDef("@AV57LineaCod",GXType.NChar,20,0) ,
          new ParDef("@AV76TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV55LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV65ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV71SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV98VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00EQ4;
          prmP00EQ4 = new Object[] {
          new ParDef("@AV67Producto",GXType.NChar,15,0) ,
          new ParDef("@AV43Fdesde",GXType.Date,8,0) ,
          new ParDef("@AV45FHasta",GXType.Date,8,0) ,
          new ParDef("@AV57LineaCod",GXType.NChar,20,0) ,
          new ParDef("@AV76TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV55LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV71SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV98VenCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EQ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EQ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EQ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EQ3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EQ4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EQ4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EQ5", "SELECT [MovVCod], [MovVAbr] FROM [CMOVVENTAS] WHERE [MovVCod] = @AV29DocMovCod ORDER BY [MovVCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EQ5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EQ7", "SELECT T1.[DocNum], T1.[TipCod], COALESCE( T2.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T2.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T2.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T2.[DocSubAfecto], 0) AS DocSubAfecto FROM ([CLVENTAS] T1 LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) WHERE T1.[TipCod] = @AV79TipCod and T1.[DocNum] = @AV30DocNum ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EQ7,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((string[]) buf[5])[0] = rslt.getString(6, 1);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 15);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(12);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
                ((long[]) buf[15])[0] = rslt.getLong(14);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 1);
                ((string[]) buf[6])[0] = rslt.getString(7, 1);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 5);
                ((long[]) buf[17])[0] = rslt.getLong(16);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 3);
                ((string[]) buf[13])[0] = rslt.getString(12, 12);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(16);
                ((short[]) buf[18])[0] = rslt.getShort(17);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(19);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(20);
                ((long[]) buf[22])[0] = rslt.getLong(21);
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
