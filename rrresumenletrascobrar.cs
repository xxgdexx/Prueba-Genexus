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
   public class rrresumenletrascobrar : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrresumenletrascobrar.aspx")), "rrresumenletrascobrar.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrresumenletrascobrar.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "CliCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV13CliCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10BanCod = (int)(NumberUtil.Val( GetPar( "BanCod"), "."));
                  AV43LetPSec = (int)(NumberUtil.Val( GetPar( "LetPSec"), "."));
                  AV46MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV26FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV27FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV12CCEstado = GetPar( "CCEstado");
                  AV60TipFecha = GetPar( "TipFecha");
                  AV71VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
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

      public rrresumenletrascobrar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrresumenletrascobrar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CliCod ,
                           ref int aP1_BanCod ,
                           ref int aP2_LetPSec ,
                           ref int aP3_MonCod ,
                           ref DateTime aP4_FDesde ,
                           ref DateTime aP5_FHasta ,
                           ref string aP6_CCEstado ,
                           ref string aP7_TipFecha ,
                           ref int aP8_VenCod )
      {
         this.AV13CliCod = aP0_CliCod;
         this.AV10BanCod = aP1_BanCod;
         this.AV43LetPSec = aP2_LetPSec;
         this.AV46MonCod = aP3_MonCod;
         this.AV26FDesde = aP4_FDesde;
         this.AV27FHasta = aP5_FHasta;
         this.AV12CCEstado = aP6_CCEstado;
         this.AV60TipFecha = aP7_TipFecha;
         this.AV71VenCod = aP8_VenCod;
         initialize();
         executePrivate();
         aP0_CliCod=this.AV13CliCod;
         aP1_BanCod=this.AV10BanCod;
         aP2_LetPSec=this.AV43LetPSec;
         aP3_MonCod=this.AV46MonCod;
         aP4_FDesde=this.AV26FDesde;
         aP5_FHasta=this.AV27FHasta;
         aP6_CCEstado=this.AV12CCEstado;
         aP7_TipFecha=this.AV60TipFecha;
         aP8_VenCod=this.AV71VenCod;
      }

      public int executeUdp( ref string aP0_CliCod ,
                             ref int aP1_BanCod ,
                             ref int aP2_LetPSec ,
                             ref int aP3_MonCod ,
                             ref DateTime aP4_FDesde ,
                             ref DateTime aP5_FHasta ,
                             ref string aP6_CCEstado ,
                             ref string aP7_TipFecha )
      {
         execute(ref aP0_CliCod, ref aP1_BanCod, ref aP2_LetPSec, ref aP3_MonCod, ref aP4_FDesde, ref aP5_FHasta, ref aP6_CCEstado, ref aP7_TipFecha, ref aP8_VenCod);
         return AV71VenCod ;
      }

      public void executeSubmit( ref string aP0_CliCod ,
                                 ref int aP1_BanCod ,
                                 ref int aP2_LetPSec ,
                                 ref int aP3_MonCod ,
                                 ref DateTime aP4_FDesde ,
                                 ref DateTime aP5_FHasta ,
                                 ref string aP6_CCEstado ,
                                 ref string aP7_TipFecha ,
                                 ref int aP8_VenCod )
      {
         rrresumenletrascobrar objrrresumenletrascobrar;
         objrrresumenletrascobrar = new rrresumenletrascobrar();
         objrrresumenletrascobrar.AV13CliCod = aP0_CliCod;
         objrrresumenletrascobrar.AV10BanCod = aP1_BanCod;
         objrrresumenletrascobrar.AV43LetPSec = aP2_LetPSec;
         objrrresumenletrascobrar.AV46MonCod = aP3_MonCod;
         objrrresumenletrascobrar.AV26FDesde = aP4_FDesde;
         objrrresumenletrascobrar.AV27FHasta = aP5_FHasta;
         objrrresumenletrascobrar.AV12CCEstado = aP6_CCEstado;
         objrrresumenletrascobrar.AV60TipFecha = aP7_TipFecha;
         objrrresumenletrascobrar.AV71VenCod = aP8_VenCod;
         objrrresumenletrascobrar.context.SetSubmitInitialConfig(context);
         objrrresumenletrascobrar.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrresumenletrascobrar);
         aP0_CliCod=this.AV13CliCod;
         aP1_BanCod=this.AV10BanCod;
         aP2_LetPSec=this.AV43LetPSec;
         aP3_MonCod=this.AV46MonCod;
         aP4_FDesde=this.AV26FDesde;
         aP5_FHasta=this.AV27FHasta;
         aP6_CCEstado=this.AV12CCEstado;
         aP7_TipFecha=this.AV60TipFecha;
         aP8_VenCod=this.AV71VenCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrresumenletrascobrar)stateInfo).executePrivate();
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
            AV21Empresa = AV56Session.Get("Empresa");
            AV20EmpDir = AV56Session.Get("EmpDir");
            AV22EmpRUC = AV56Session.Get("EmpRUC");
            AV53Ruta = AV56Session.Get("RUTA") + "/Logo.jpg";
            AV45Logo = AV53Ruta;
            AV74Logo_GXI = GXDbFile.PathToUrl( AV53Ruta);
            AV28Filtro1 = "Todos";
            AV29Filtro2 = context.localUtil.DToC( AV26FDesde, 2, "/");
            AV30Filtro3 = context.localUtil.DToC( AV27FHasta, 2, "/");
            AV31Filtro4 = "Todos";
            /* Using cursor P00E62 */
            pr_default.execute(0, new Object[] {AV46MonCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P00E62_A180MonCod[0];
               A1234MonDsc = P00E62_A1234MonDsc[0];
               AV28Filtro1 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00E63 */
            pr_default.execute(1, new Object[] {AV71VenCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A309VenCod = P00E63_A309VenCod[0];
               A2045VenDsc = P00E63_A2045VenDsc[0];
               AV31Filtro4 = StringUtil.Trim( A2045VenDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV68TTotImporte = 0.00m;
            AV69TTotPagos = 0.00m;
            AV70TTotSaldo = 0.00m;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV13CliCod ,
                                                 AV10BanCod ,
                                                 AV43LetPSec ,
                                                 AV46MonCod ,
                                                 AV60TipFecha ,
                                                 AV71VenCod ,
                                                 A206LetCCliCod ,
                                                 A1104LetCBanCod ,
                                                 A1116LetCSec ,
                                                 A205LetCMonCod ,
                                                 A1108LetCFecLet ,
                                                 AV26FDesde ,
                                                 AV27FHasta ,
                                                 A1109LetCFecVcto ,
                                                 A1123LetCVendCod ,
                                                 A1120LetCTipo } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.INT
                                                 }
            });
            /* Using cursor P00E64 */
            pr_default.execute(2, new Object[] {AV13CliCod, AV10BanCod, AV43LetPSec, AV46MonCod, AV26FDesde, AV27FHasta, AV26FDesde, AV27FHasta, AV71VenCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               BRKE65 = false;
               A204LetCLetCod = P00E64_A204LetCLetCod[0];
               A208LetCTipCod = P00E64_A208LetCTipCod[0];
               n208LetCTipCod = P00E64_n208LetCTipCod[0];
               A209LetCDocNum = P00E64_A209LetCDocNum[0];
               n209LetCDocNum = P00E64_n209LetCDocNum[0];
               A1120LetCTipo = P00E64_A1120LetCTipo[0];
               A1104LetCBanCod = P00E64_A1104LetCBanCod[0];
               A1123LetCVendCod = P00E64_A1123LetCVendCod[0];
               A1109LetCFecVcto = P00E64_A1109LetCFecVcto[0];
               A1108LetCFecLet = P00E64_A1108LetCFecLet[0];
               A205LetCMonCod = P00E64_A205LetCMonCod[0];
               A1116LetCSec = P00E64_A1116LetCSec[0];
               A206LetCCliCod = P00E64_A206LetCCliCod[0];
               A207LetCItem = P00E64_A207LetCItem[0];
               A205LetCMonCod = P00E64_A205LetCMonCod[0];
               A206LetCCliCod = P00E64_A206LetCCliCod[0];
               A1123LetCVendCod = P00E64_A1123LetCVendCod[0];
               while ( (pr_default.getStatus(2) != 101) && ( P00E64_A1104LetCBanCod[0] == A1104LetCBanCod ) )
               {
                  BRKE65 = false;
                  A204LetCLetCod = P00E64_A204LetCLetCod[0];
                  A207LetCItem = P00E64_A207LetCItem[0];
                  BRKE65 = true;
                  pr_default.readNext(2);
               }
               AV14CodBan = A1104LetCBanCod;
               AV61TotGImporte = 0.00m;
               AV62TotGPagos = 0.00m;
               AV63TotGSaldo = 0.00m;
               /* Execute user subroutine: 'BANCO' */
               S151 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               HE60( false, 23) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9Banco, "")), 2, Gx_line+3, 580, Gx_line+19, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+23);
               /* Execute user subroutine: 'SECCION' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               HE60( false, 31) ;
               getPrinter().GxDrawLine(640, Gx_line+3, 1018, Gx_line+3, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63TotGSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 903, Gx_line+10, 1010, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62TotGPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 820, Gx_line+10, 927, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TBanco, "")), 58, Gx_line+9, 636, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61TotGImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 639, Gx_line+10, 746, Gx_line+25, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+31);
               AV68TTotImporte = (decimal)(AV68TTotImporte+AV61TotGImporte);
               AV69TTotPagos = (decimal)(AV69TTotPagos+AV62TotGPagos);
               AV70TTotSaldo = (decimal)(AV70TTotSaldo+AV63TotGSaldo);
               if ( ! BRKE65 )
               {
                  BRKE65 = true;
                  pr_default.readNext(2);
               }
            }
            pr_default.close(2);
            HE60( false, 75) ;
            getPrinter().GxDrawLine(641, Gx_line+27, 1018, Gx_line+27, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70TTotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 903, Gx_line+34, 1010, Gx_line+49, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69TTotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 820, Gx_line+34, 927, Gx_line+49, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 557, Gx_line+34, 637, Gx_line+48, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68TTotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 639, Gx_line+34, 746, Gx_line+49, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+75);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HE60( true, 0) ;
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
         /* 'SECCION' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV13CliCod ,
                                              AV43LetPSec ,
                                              AV46MonCod ,
                                              AV60TipFecha ,
                                              AV71VenCod ,
                                              A206LetCCliCod ,
                                              A1116LetCSec ,
                                              A205LetCMonCod ,
                                              A1108LetCFecLet ,
                                              AV26FDesde ,
                                              AV27FHasta ,
                                              A1109LetCFecVcto ,
                                              A1123LetCVendCod ,
                                              A1104LetCBanCod ,
                                              AV14CodBan ,
                                              A1120LetCTipo } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00E65 */
         pr_default.execute(3, new Object[] {AV14CodBan, AV13CliCod, AV43LetPSec, AV46MonCod, AV26FDesde, AV27FHasta, AV26FDesde, AV27FHasta, AV71VenCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKE67 = false;
            A204LetCLetCod = P00E65_A204LetCLetCod[0];
            A208LetCTipCod = P00E65_A208LetCTipCod[0];
            n208LetCTipCod = P00E65_n208LetCTipCod[0];
            A209LetCDocNum = P00E65_A209LetCDocNum[0];
            n209LetCDocNum = P00E65_n209LetCDocNum[0];
            A1104LetCBanCod = P00E65_A1104LetCBanCod[0];
            A1120LetCTipo = P00E65_A1120LetCTipo[0];
            A1116LetCSec = P00E65_A1116LetCSec[0];
            A1123LetCVendCod = P00E65_A1123LetCVendCod[0];
            A1109LetCFecVcto = P00E65_A1109LetCFecVcto[0];
            A1108LetCFecLet = P00E65_A1108LetCFecLet[0];
            A205LetCMonCod = P00E65_A205LetCMonCod[0];
            A206LetCCliCod = P00E65_A206LetCCliCod[0];
            A207LetCItem = P00E65_A207LetCItem[0];
            A205LetCMonCod = P00E65_A205LetCMonCod[0];
            A206LetCCliCod = P00E65_A206LetCCliCod[0];
            A1123LetCVendCod = P00E65_A1123LetCVendCod[0];
            while ( (pr_default.getStatus(3) != 101) && ( P00E65_A1116LetCSec[0] == A1116LetCSec ) )
            {
               BRKE67 = false;
               A204LetCLetCod = P00E65_A204LetCLetCod[0];
               A207LetCItem = P00E65_A207LetCItem[0];
               BRKE67 = true;
               pr_default.readNext(3);
            }
            AV15CodSec = A1116LetCSec;
            AV64TotImporte = 0.00m;
            AV65TotPagos = 0.00m;
            AV66TotSaldo = 0.00m;
            if ( AV15CodSec == 1 )
            {
               AV55Seccion = "Por Aceptar";
            }
            if ( AV15CodSec == 8 )
            {
               AV55Seccion = "Cartera";
            }
            if ( AV15CodSec == 2 )
            {
               AV55Seccion = "Descuento";
            }
            if ( AV15CodSec == 3 )
            {
               AV55Seccion = "Cobranza";
            }
            if ( AV15CodSec == 4 )
            {
               AV55Seccion = "Cobranza Libre";
            }
            if ( AV15CodSec == 5 )
            {
               AV55Seccion = "Garantia";
            }
            if ( AV15CodSec == 6 )
            {
               AV55Seccion = "Protestado";
            }
            if ( AV15CodSec == 7 )
            {
               AV55Seccion = "Refinanciado";
            }
            if ( AV15CodSec == 10 )
            {
               AV55Seccion = "Refinanciamiento Amort.";
            }
            if ( AV15CodSec == 11 )
            {
               AV55Seccion = "Factura Negociable-Descuento";
            }
            if ( AV15CodSec == 12 )
            {
               AV55Seccion = "Factura Negociable-Cobranza";
            }
            if ( AV15CodSec == 9 )
            {
               AV55Seccion = "Aceptada";
            }
            if ( AV15CodSec == 0 )
            {
               AV55Seccion = "(Ninguno)";
            }
            AV67TSeccion = "Total : " + StringUtil.Trim( AV55Seccion);
            HE60( false, 22) ;
            getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Seccion, "")), 31, Gx_line+2, 591, Gx_line+16, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+22);
            /* Execute user subroutine: 'MOVIMIENTO' */
            S127 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            HE60( false, 30) ;
            getPrinter().GxDrawLine(640, Gx_line+0, 1018, Gx_line+0, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 903, Gx_line+7, 1010, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 820, Gx_line+7, 927, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TSeccion, "")), 58, Gx_line+6, 636, Gx_line+22, 2, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 639, Gx_line+7, 746, Gx_line+22, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+30);
            AV61TotGImporte = (decimal)(AV61TotGImporte+AV64TotImporte);
            AV62TotGPagos = (decimal)(AV62TotGPagos+AV65TotPagos);
            AV63TotGSaldo = (decimal)(AV63TotGSaldo+AV66TotSaldo);
            if ( ! BRKE67 )
            {
               BRKE67 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S127( )
      {
         /* 'MOVIMIENTO' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV13CliCod ,
                                              AV46MonCod ,
                                              AV60TipFecha ,
                                              AV71VenCod ,
                                              A206LetCCliCod ,
                                              A205LetCMonCod ,
                                              A1108LetCFecLet ,
                                              AV26FDesde ,
                                              AV27FHasta ,
                                              A1109LetCFecVcto ,
                                              A1123LetCVendCod ,
                                              A1104LetCBanCod ,
                                              AV14CodBan ,
                                              A1116LetCSec ,
                                              AV15CodSec ,
                                              A1120LetCTipo } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00E66 */
         pr_default.execute(4, new Object[] {AV14CodBan, AV15CodSec, AV13CliCod, AV46MonCod, AV26FDesde, AV27FHasta, AV26FDesde, AV27FHasta, AV71VenCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A1104LetCBanCod = P00E66_A1104LetCBanCod[0];
            A1116LetCSec = P00E66_A1116LetCSec[0];
            A1120LetCTipo = P00E66_A1120LetCTipo[0];
            A1123LetCVendCod = P00E66_A1123LetCVendCod[0];
            A1109LetCFecVcto = P00E66_A1109LetCFecVcto[0];
            A1108LetCFecLet = P00E66_A1108LetCFecLet[0];
            A205LetCMonCod = P00E66_A205LetCMonCod[0];
            A206LetCCliCod = P00E66_A206LetCCliCod[0];
            A204LetCLetCod = P00E66_A204LetCLetCod[0];
            A208LetCTipCod = P00E66_A208LetCTipCod[0];
            n208LetCTipCod = P00E66_n208LetCTipCod[0];
            A209LetCDocNum = P00E66_A209LetCDocNum[0];
            n209LetCDocNum = P00E66_n209LetCDocNum[0];
            A1112LetCImpDet = P00E66_A1112LetCImpDet[0];
            A1233MonAbr = P00E66_A1233MonAbr[0];
            n1233MonAbr = P00E66_n1233MonAbr[0];
            A1107LetCDias = P00E66_A1107LetCDias[0];
            A1105LetCBanNum = P00E66_A1105LetCBanNum[0];
            A161CliDsc = P00E66_A161CliDsc[0];
            n161CliDsc = P00E66_n161CliDsc[0];
            A207LetCItem = P00E66_A207LetCItem[0];
            A205LetCMonCod = P00E66_A205LetCMonCod[0];
            A206LetCCliCod = P00E66_A206LetCCliCod[0];
            A1233MonAbr = P00E66_A1233MonAbr[0];
            n1233MonAbr = P00E66_n1233MonAbr[0];
            A161CliDsc = P00E66_A161CliDsc[0];
            n161CliDsc = P00E66_n161CliDsc[0];
            A1123LetCVendCod = P00E66_A1123LetCVendCod[0];
            AV40LetCLetCod = A204LetCLetCod;
            AV41LetCTipCod = A208LetCTipCod;
            AV39LetCDocNum = A209LetCDocNum;
            /* Execute user subroutine: 'SALDOCXC' */
            S139 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'DOCUMENTOS' */
            S149 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            if ( StringUtil.StrCmp(AV12CCEstado, "O") == 0 )
            {
               AV64TotImporte = (decimal)(AV64TotImporte+A1112LetCImpDet);
               AV65TotPagos = (decimal)(AV65TotPagos+AV48Pagos);
               AV66TotSaldo = (decimal)(AV66TotSaldo+AV54Saldo);
               HE60( false, 18) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A1108LetCFecLet, "99/99/99"), 2, Gx_line+1, 49, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A161CliDsc, "")), 51, Gx_line+1, 392, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1105LetCBanNum, "")), 508, Gx_line+1, 586, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39LetCDocNum, "")), 402, Gx_line+1, 478, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1107LetCDias), "ZZZ9")), 758, Gx_line+1, 784, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A1109LetCFecVcto, "99/99/99"), 799, Gx_line+1, 846, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 820, Gx_line+1, 927, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 903, Gx_line+1, 1010, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Documento1, "")), 1018, Gx_line+1, 1146, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1112LetCImpDet, "ZZZZZZ,ZZZ,ZZ9.99")), 591, Gx_line+1, 698, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1233MonAbr, "")), 716, Gx_line+1, 746, Gx_line+16, 1, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               AV44Lineas = LVCharUtil.LinesWrap( AV18DocObs, 22);
               AV34I = 1;
               while ( AV34I <= AV44Lineas )
               {
                  AV16Comen = LVCharUtil.GetLineWrap( AV18DocObs, AV34I, 22);
                  HE60( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Comen, "")), 1018, Gx_line+2, 1148, Gx_line+16, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  AV34I = (short)(AV34I+1);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(AV23Estado, AV12CCEstado) == 0 )
               {
                  AV64TotImporte = (decimal)(AV64TotImporte+A1112LetCImpDet);
                  AV66TotSaldo = (decimal)(AV66TotSaldo+AV54Saldo);
                  AV65TotPagos = (decimal)(AV65TotPagos+AV48Pagos);
                  HE60( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A1108LetCFecLet, "99/99/99"), 2, Gx_line+1, 49, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A161CliDsc, "")), 51, Gx_line+1, 392, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1105LetCBanNum, "")), 508, Gx_line+1, 586, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39LetCDocNum, "")), 402, Gx_line+1, 478, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1107LetCDias), "ZZZ9")), 758, Gx_line+1, 784, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A1109LetCFecVcto, "99/99/99"), 799, Gx_line+1, 846, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 820, Gx_line+1, 927, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 903, Gx_line+1, 1010, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Documento1, "")), 1018, Gx_line+1, 1146, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1112LetCImpDet, "ZZZZZZ,ZZZ,ZZ9.99")), 591, Gx_line+1, 698, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1233MonAbr, "")), 716, Gx_line+1, 746, Gx_line+16, 1, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  AV44Lineas = LVCharUtil.LinesWrap( AV18DocObs, 22);
                  AV34I = 1;
                  while ( AV34I <= AV44Lineas )
                  {
                     AV16Comen = LVCharUtil.GetLineWrap( AV18DocObs, AV34I, 22);
                     HE60( false, 18) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Comen, "")), 1018, Gx_line+2, 1148, Gx_line+16, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+18);
                     AV34I = (short)(AV34I+1);
                  }
               }
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S151( )
      {
         /* 'BANCO' Routine */
         returnInSub = false;
         AV9Banco = "";
         /* Using cursor P00E67 */
         pr_default.execute(5, new Object[] {AV14CodBan});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A372BanCod = P00E67_A372BanCod[0];
            A482BanDsc = P00E67_A482BanDsc[0];
            AV9Banco = A482BanDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
         AV57TBanco = "Total : " + StringUtil.Trim( AV9Banco);
      }

      protected void S139( )
      {
         /* 'SALDOCXC' Routine */
         returnInSub = false;
         AV54Saldo = 0.00m;
         AV48Pagos = 0.00m;
         AV23Estado = "";
         /* Using cursor P00E68 */
         pr_default.execute(6, new Object[] {AV41LetCTipCod, AV39LetCDocNum});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A185CCDocNum = P00E68_A185CCDocNum[0];
            A184CCTipCod = P00E68_A184CCTipCod[0];
            A506CCEstado = P00E68_A506CCEstado[0];
            A509CCImpPago = P00E68_A509CCImpPago[0];
            A513CCImpTotal = P00E68_A513CCImpTotal[0];
            A512CCImpSaldo = (decimal)(A513CCImpTotal-A509CCImpPago);
            AV48Pagos = A509CCImpPago;
            AV54Saldo = A512CCImpSaldo;
            AV23Estado = A506CCEstado;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
      }

      protected void S149( )
      {
         /* 'DOCUMENTOS' Routine */
         returnInSub = false;
         AV33Flag = 0;
         AV18DocObs = "";
         /* Using cursor P00E69 */
         pr_default.execute(7, new Object[] {AV40LetCLetCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A1120LetCTipo = P00E69_A1120LetCTipo[0];
            A204LetCLetCod = P00E69_A204LetCLetCod[0];
            A209LetCDocNum = P00E69_A209LetCDocNum[0];
            n209LetCDocNum = P00E69_n209LetCDocNum[0];
            A207LetCItem = P00E69_A207LetCItem[0];
            AV18DocObs += StringUtil.Trim( A209LetCDocNum) + "-";
            pr_default.readNext(7);
         }
         pr_default.close(7);
         AV37Len = (decimal)(StringUtil.Len( AV18DocObs)-1);
         AV18DocObs = StringUtil.Substring( AV18DocObs, 1, (int)(AV37Len));
         AV19Documento1 = StringUtil.Substring( AV18DocObs, 1, 22);
         AV37Len = (decimal)(AV37Len-22);
         AV18DocObs = StringUtil.Substring( AV18DocObs, 23, (int)(AV37Len));
      }

      protected void HE60( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 1038, Gx_line+39, 1070, Gx_line+53, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 1038, Gx_line+56, 1082, Gx_line+70, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 1038, Gx_line+21, 1077, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1094, Gx_line+56, 1133, Gx_line+71, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1071, Gx_line+39, 1131, Gx_line+53, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1085, Gx_line+21, 1132, Gx_line+36, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 7, Gx_line+156, 42, Gx_line+170, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 145, Gx_line+156, 187, Gx_line+170, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+142, 1148, Gx_line+185, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Letras por Cobrar", 445, Gx_line+54, 595, Gx_line+74, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Letra", 417, Gx_line+156, 466, Gx_line+170, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Documento", 515, Gx_line+147, 584, Gx_line+161, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 379, Gx_line+82, 416, Gx_line+96, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta", 547, Gx_line+82, 582, Gx_line+96, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Filtro2, "")), 426, Gx_line+82, 492, Gx_line+96, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Filtro3, "")), 600, Gx_line+82, 666, Gx_line+96, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Imp. Letra", 623, Gx_line+156, 685, Gx_line+170, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV45Logo)) ? AV74Logo_GXI : AV45Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 6, Gx_line+18, 164, Gx_line+96) ;
               getPrinter().GxDrawText("Moneda", 369, Gx_line+103, 417, Gx_line+117, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Filtro1, "")), 426, Gx_line+103, 769, Gx_line+117, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Banco", 523, Gx_line+165, 576, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dias", 755, Gx_line+156, 781, Gx_line+170, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("F. Vcto", 799, Gx_line+156, 839, Gx_line+170, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pagos", 908, Gx_line+144, 944, Gx_line+158, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 868, Gx_line+167, 918, Gx_line+181, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 959, Gx_line+167, 992, Gx_line+181, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(851, Gx_line+143, 851, Gx_line+185, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(786, Gx_line+143, 786, Gx_line+185, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(750, Gx_line+143, 750, Gx_line+185, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(598, Gx_line+143, 598, Gx_line+185, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(394, Gx_line+143, 394, Gx_line+185, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(49, Gx_line+143, 49, Gx_line+185, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(852, Gx_line+159, 1012, Gx_line+159, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(929, Gx_line+160, 929, Gx_line+184, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21Empresa, "")), 6, Gx_line+96, 346, Gx_line+114, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22EmpRUC, "")), 6, Gx_line+114, 144, Gx_line+132, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1013, Gx_line+143, 1013, Gx_line+185, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Documentos", 1042, Gx_line+155, 1117, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(495, Gx_line+143, 495, Gx_line+185, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(711, Gx_line+143, 711, Gx_line+185, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Mon.", 716, Gx_line+156, 745, Gx_line+170, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31Filtro4, "")), 426, Gx_line+123, 769, Gx_line+137, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Vendedor", 359, Gx_line+123, 416, Gx_line+137, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+185);
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
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
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
         AV21Empresa = "";
         AV56Session = context.GetSession();
         AV20EmpDir = "";
         AV22EmpRUC = "";
         AV53Ruta = "";
         AV45Logo = "";
         AV74Logo_GXI = "";
         AV28Filtro1 = "";
         AV29Filtro2 = "";
         AV30Filtro3 = "";
         AV31Filtro4 = "";
         scmdbuf = "";
         P00E62_A180MonCod = new int[1] ;
         P00E62_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         P00E63_A309VenCod = new int[1] ;
         P00E63_A2045VenDsc = new string[] {""} ;
         A2045VenDsc = "";
         A206LetCCliCod = "";
         A1108LetCFecLet = DateTime.MinValue;
         A1109LetCFecVcto = DateTime.MinValue;
         A1120LetCTipo = "";
         P00E64_A204LetCLetCod = new string[] {""} ;
         P00E64_A208LetCTipCod = new string[] {""} ;
         P00E64_n208LetCTipCod = new bool[] {false} ;
         P00E64_A209LetCDocNum = new string[] {""} ;
         P00E64_n209LetCDocNum = new bool[] {false} ;
         P00E64_A1120LetCTipo = new string[] {""} ;
         P00E64_A1104LetCBanCod = new int[1] ;
         P00E64_A1123LetCVendCod = new int[1] ;
         P00E64_A1109LetCFecVcto = new DateTime[] {DateTime.MinValue} ;
         P00E64_A1108LetCFecLet = new DateTime[] {DateTime.MinValue} ;
         P00E64_A205LetCMonCod = new int[1] ;
         P00E64_A1116LetCSec = new int[1] ;
         P00E64_A206LetCCliCod = new string[] {""} ;
         P00E64_A207LetCItem = new int[1] ;
         A204LetCLetCod = "";
         A208LetCTipCod = "";
         A209LetCDocNum = "";
         AV9Banco = "";
         AV57TBanco = "";
         P00E65_A204LetCLetCod = new string[] {""} ;
         P00E65_A208LetCTipCod = new string[] {""} ;
         P00E65_n208LetCTipCod = new bool[] {false} ;
         P00E65_A209LetCDocNum = new string[] {""} ;
         P00E65_n209LetCDocNum = new bool[] {false} ;
         P00E65_A1104LetCBanCod = new int[1] ;
         P00E65_A1120LetCTipo = new string[] {""} ;
         P00E65_A1116LetCSec = new int[1] ;
         P00E65_A1123LetCVendCod = new int[1] ;
         P00E65_A1109LetCFecVcto = new DateTime[] {DateTime.MinValue} ;
         P00E65_A1108LetCFecLet = new DateTime[] {DateTime.MinValue} ;
         P00E65_A205LetCMonCod = new int[1] ;
         P00E65_A206LetCCliCod = new string[] {""} ;
         P00E65_A207LetCItem = new int[1] ;
         AV55Seccion = "";
         AV67TSeccion = "";
         P00E66_A1104LetCBanCod = new int[1] ;
         P00E66_A1116LetCSec = new int[1] ;
         P00E66_A1120LetCTipo = new string[] {""} ;
         P00E66_A1123LetCVendCod = new int[1] ;
         P00E66_A1109LetCFecVcto = new DateTime[] {DateTime.MinValue} ;
         P00E66_A1108LetCFecLet = new DateTime[] {DateTime.MinValue} ;
         P00E66_A205LetCMonCod = new int[1] ;
         P00E66_A206LetCCliCod = new string[] {""} ;
         P00E66_A204LetCLetCod = new string[] {""} ;
         P00E66_A208LetCTipCod = new string[] {""} ;
         P00E66_n208LetCTipCod = new bool[] {false} ;
         P00E66_A209LetCDocNum = new string[] {""} ;
         P00E66_n209LetCDocNum = new bool[] {false} ;
         P00E66_A1112LetCImpDet = new decimal[1] ;
         P00E66_A1233MonAbr = new string[] {""} ;
         P00E66_n1233MonAbr = new bool[] {false} ;
         P00E66_A1107LetCDias = new short[1] ;
         P00E66_A1105LetCBanNum = new string[] {""} ;
         P00E66_A161CliDsc = new string[] {""} ;
         P00E66_n161CliDsc = new bool[] {false} ;
         P00E66_A207LetCItem = new int[1] ;
         A1233MonAbr = "";
         A1105LetCBanNum = "";
         A161CliDsc = "";
         AV40LetCLetCod = "";
         AV41LetCTipCod = "";
         AV39LetCDocNum = "";
         AV19Documento1 = "";
         AV18DocObs = "";
         AV16Comen = "";
         AV23Estado = "";
         P00E67_A372BanCod = new int[1] ;
         P00E67_A482BanDsc = new string[] {""} ;
         A482BanDsc = "";
         P00E68_A185CCDocNum = new string[] {""} ;
         P00E68_A184CCTipCod = new string[] {""} ;
         P00E68_A506CCEstado = new string[] {""} ;
         P00E68_A509CCImpPago = new decimal[1] ;
         P00E68_A513CCImpTotal = new decimal[1] ;
         A185CCDocNum = "";
         A184CCTipCod = "";
         A506CCEstado = "";
         P00E69_A1120LetCTipo = new string[] {""} ;
         P00E69_A204LetCLetCod = new string[] {""} ;
         P00E69_A209LetCDocNum = new string[] {""} ;
         P00E69_n209LetCDocNum = new bool[] {false} ;
         P00E69_A207LetCItem = new int[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV45Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrresumenletrascobrar__default(),
            new Object[][] {
                new Object[] {
               P00E62_A180MonCod, P00E62_A1234MonDsc
               }
               , new Object[] {
               P00E63_A309VenCod, P00E63_A2045VenDsc
               }
               , new Object[] {
               P00E64_A204LetCLetCod, P00E64_A208LetCTipCod, P00E64_n208LetCTipCod, P00E64_A209LetCDocNum, P00E64_n209LetCDocNum, P00E64_A1120LetCTipo, P00E64_A1104LetCBanCod, P00E64_A1123LetCVendCod, P00E64_A1109LetCFecVcto, P00E64_A1108LetCFecLet,
               P00E64_A205LetCMonCod, P00E64_A1116LetCSec, P00E64_A206LetCCliCod, P00E64_A207LetCItem
               }
               , new Object[] {
               P00E65_A204LetCLetCod, P00E65_A208LetCTipCod, P00E65_n208LetCTipCod, P00E65_A209LetCDocNum, P00E65_n209LetCDocNum, P00E65_A1104LetCBanCod, P00E65_A1120LetCTipo, P00E65_A1116LetCSec, P00E65_A1123LetCVendCod, P00E65_A1109LetCFecVcto,
               P00E65_A1108LetCFecLet, P00E65_A205LetCMonCod, P00E65_A206LetCCliCod, P00E65_A207LetCItem
               }
               , new Object[] {
               P00E66_A1104LetCBanCod, P00E66_A1116LetCSec, P00E66_A1120LetCTipo, P00E66_A1123LetCVendCod, P00E66_A1109LetCFecVcto, P00E66_A1108LetCFecLet, P00E66_A205LetCMonCod, P00E66_A206LetCCliCod, P00E66_A204LetCLetCod, P00E66_A208LetCTipCod,
               P00E66_n208LetCTipCod, P00E66_A209LetCDocNum, P00E66_n209LetCDocNum, P00E66_A1112LetCImpDet, P00E66_A1233MonAbr, P00E66_n1233MonAbr, P00E66_A1107LetCDias, P00E66_A1105LetCBanNum, P00E66_A161CliDsc, P00E66_n161CliDsc,
               P00E66_A207LetCItem
               }
               , new Object[] {
               P00E67_A372BanCod, P00E67_A482BanDsc
               }
               , new Object[] {
               P00E68_A185CCDocNum, P00E68_A184CCTipCod, P00E68_A506CCEstado, P00E68_A509CCImpPago, P00E68_A513CCImpTotal
               }
               , new Object[] {
               P00E69_A1120LetCTipo, P00E69_A204LetCLetCod, P00E69_A209LetCDocNum, P00E69_n209LetCDocNum, P00E69_A207LetCItem
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
      private short A1107LetCDias ;
      private short AV34I ;
      private short AV33Flag ;
      private int AV10BanCod ;
      private int AV43LetPSec ;
      private int AV46MonCod ;
      private int AV71VenCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int A309VenCod ;
      private int A1104LetCBanCod ;
      private int A1116LetCSec ;
      private int A205LetCMonCod ;
      private int A1123LetCVendCod ;
      private int A207LetCItem ;
      private int AV14CodBan ;
      private int Gx_OldLine ;
      private int AV15CodSec ;
      private int AV44Lineas ;
      private int A372BanCod ;
      private decimal AV68TTotImporte ;
      private decimal AV69TTotPagos ;
      private decimal AV70TTotSaldo ;
      private decimal AV61TotGImporte ;
      private decimal AV62TotGPagos ;
      private decimal AV63TotGSaldo ;
      private decimal AV64TotImporte ;
      private decimal AV65TotPagos ;
      private decimal AV66TotSaldo ;
      private decimal A1112LetCImpDet ;
      private decimal AV48Pagos ;
      private decimal AV54Saldo ;
      private decimal A509CCImpPago ;
      private decimal A513CCImpTotal ;
      private decimal A512CCImpSaldo ;
      private decimal AV37Len ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV13CliCod ;
      private string AV12CCEstado ;
      private string AV60TipFecha ;
      private string AV21Empresa ;
      private string AV20EmpDir ;
      private string AV22EmpRUC ;
      private string AV53Ruta ;
      private string AV28Filtro1 ;
      private string AV29Filtro2 ;
      private string AV30Filtro3 ;
      private string AV31Filtro4 ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string A2045VenDsc ;
      private string A206LetCCliCod ;
      private string A1120LetCTipo ;
      private string A204LetCLetCod ;
      private string A208LetCTipCod ;
      private string A209LetCDocNum ;
      private string AV9Banco ;
      private string AV57TBanco ;
      private string AV55Seccion ;
      private string A1233MonAbr ;
      private string A1105LetCBanNum ;
      private string A161CliDsc ;
      private string AV40LetCLetCod ;
      private string AV41LetCTipCod ;
      private string AV39LetCDocNum ;
      private string AV19Documento1 ;
      private string AV16Comen ;
      private string AV23Estado ;
      private string A482BanDsc ;
      private string A185CCDocNum ;
      private string A184CCTipCod ;
      private string A506CCEstado ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV26FDesde ;
      private DateTime AV27FHasta ;
      private DateTime A1108LetCFecLet ;
      private DateTime A1109LetCFecVcto ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKE65 ;
      private bool n208LetCTipCod ;
      private bool n209LetCDocNum ;
      private bool returnInSub ;
      private bool BRKE67 ;
      private bool n1233MonAbr ;
      private bool n161CliDsc ;
      private string AV18DocObs ;
      private string AV74Logo_GXI ;
      private string AV67TSeccion ;
      private string AV45Logo ;
      private string Logo ;
      private IGxSession AV56Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CliCod ;
      private int aP1_BanCod ;
      private int aP2_LetPSec ;
      private int aP3_MonCod ;
      private DateTime aP4_FDesde ;
      private DateTime aP5_FHasta ;
      private string aP6_CCEstado ;
      private string aP7_TipFecha ;
      private int aP8_VenCod ;
      private IDataStoreProvider pr_default ;
      private int[] P00E62_A180MonCod ;
      private string[] P00E62_A1234MonDsc ;
      private int[] P00E63_A309VenCod ;
      private string[] P00E63_A2045VenDsc ;
      private string[] P00E64_A204LetCLetCod ;
      private string[] P00E64_A208LetCTipCod ;
      private bool[] P00E64_n208LetCTipCod ;
      private string[] P00E64_A209LetCDocNum ;
      private bool[] P00E64_n209LetCDocNum ;
      private string[] P00E64_A1120LetCTipo ;
      private int[] P00E64_A1104LetCBanCod ;
      private int[] P00E64_A1123LetCVendCod ;
      private DateTime[] P00E64_A1109LetCFecVcto ;
      private DateTime[] P00E64_A1108LetCFecLet ;
      private int[] P00E64_A205LetCMonCod ;
      private int[] P00E64_A1116LetCSec ;
      private string[] P00E64_A206LetCCliCod ;
      private int[] P00E64_A207LetCItem ;
      private string[] P00E65_A204LetCLetCod ;
      private string[] P00E65_A208LetCTipCod ;
      private bool[] P00E65_n208LetCTipCod ;
      private string[] P00E65_A209LetCDocNum ;
      private bool[] P00E65_n209LetCDocNum ;
      private int[] P00E65_A1104LetCBanCod ;
      private string[] P00E65_A1120LetCTipo ;
      private int[] P00E65_A1116LetCSec ;
      private int[] P00E65_A1123LetCVendCod ;
      private DateTime[] P00E65_A1109LetCFecVcto ;
      private DateTime[] P00E65_A1108LetCFecLet ;
      private int[] P00E65_A205LetCMonCod ;
      private string[] P00E65_A206LetCCliCod ;
      private int[] P00E65_A207LetCItem ;
      private int[] P00E66_A1104LetCBanCod ;
      private int[] P00E66_A1116LetCSec ;
      private string[] P00E66_A1120LetCTipo ;
      private int[] P00E66_A1123LetCVendCod ;
      private DateTime[] P00E66_A1109LetCFecVcto ;
      private DateTime[] P00E66_A1108LetCFecLet ;
      private int[] P00E66_A205LetCMonCod ;
      private string[] P00E66_A206LetCCliCod ;
      private string[] P00E66_A204LetCLetCod ;
      private string[] P00E66_A208LetCTipCod ;
      private bool[] P00E66_n208LetCTipCod ;
      private string[] P00E66_A209LetCDocNum ;
      private bool[] P00E66_n209LetCDocNum ;
      private decimal[] P00E66_A1112LetCImpDet ;
      private string[] P00E66_A1233MonAbr ;
      private bool[] P00E66_n1233MonAbr ;
      private short[] P00E66_A1107LetCDias ;
      private string[] P00E66_A1105LetCBanNum ;
      private string[] P00E66_A161CliDsc ;
      private bool[] P00E66_n161CliDsc ;
      private int[] P00E66_A207LetCItem ;
      private int[] P00E67_A372BanCod ;
      private string[] P00E67_A482BanDsc ;
      private string[] P00E68_A185CCDocNum ;
      private string[] P00E68_A184CCTipCod ;
      private string[] P00E68_A506CCEstado ;
      private decimal[] P00E68_A509CCImpPago ;
      private decimal[] P00E68_A513CCImpTotal ;
      private string[] P00E69_A1120LetCTipo ;
      private string[] P00E69_A204LetCLetCod ;
      private string[] P00E69_A209LetCDocNum ;
      private bool[] P00E69_n209LetCDocNum ;
      private int[] P00E69_A207LetCItem ;
   }

   public class rrresumenletrascobrar__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E64( IGxContext context ,
                                             string AV13CliCod ,
                                             int AV10BanCod ,
                                             int AV43LetPSec ,
                                             int AV46MonCod ,
                                             string AV60TipFecha ,
                                             int AV71VenCod ,
                                             string A206LetCCliCod ,
                                             int A1104LetCBanCod ,
                                             int A1116LetCSec ,
                                             int A205LetCMonCod ,
                                             DateTime A1108LetCFecLet ,
                                             DateTime AV26FDesde ,
                                             DateTime AV27FHasta ,
                                             DateTime A1109LetCFecVcto ,
                                             int A1123LetCVendCod ,
                                             string A1120LetCTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[LetCLetCod], T1.[LetCTipCod] AS LetCTipCod, T1.[LetCDocNum] AS LetCDocNum, T1.[LetCTipo], T1.[LetCBanCod], T3.[CCVendCod] AS LetCVendCod, T1.[LetCFecVcto], T1.[LetCFecLet], T2.[LetCMonCod] AS LetCMonCod, T1.[LetCSec], T2.[LetCCliCod] AS LetCCliCod, T1.[LetCItem] FROM (([CLLETRASDET] T1 INNER JOIN [CLLETRAS] T2 ON T2.[LetCLetCod] = T1.[LetCLetCod]) LEFT JOIN [CLCUENTACOBRAR] T3 ON T3.[CCTipCod] = T1.[LetCTipCod] AND T3.[CCDocNum] = T1.[LetCDocNum])";
         AddWhere(sWhereString, "(T1.[LetCTipo] = 'L')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[LetCCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV10BanCod) )
         {
            AddWhere(sWhereString, "(T1.[LetCBanCod] = @AV10BanCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV43LetPSec) )
         {
            AddWhere(sWhereString, "(T1.[LetCSec] = @AV43LetPSec)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV46MonCod) )
         {
            AddWhere(sWhereString, "(T2.[LetCMonCod] = @AV46MonCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecLet] >= @AV26FDesde)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecLet] <= @AV27FHasta)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecVcto] >= @AV26FDesde)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecVcto] <= @AV27FHasta)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV71VenCod) )
         {
            AddWhere(sWhereString, "(T3.[CCVendCod] = @AV71VenCod)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[LetCBanCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00E65( IGxContext context ,
                                             string AV13CliCod ,
                                             int AV43LetPSec ,
                                             int AV46MonCod ,
                                             string AV60TipFecha ,
                                             int AV71VenCod ,
                                             string A206LetCCliCod ,
                                             int A1116LetCSec ,
                                             int A205LetCMonCod ,
                                             DateTime A1108LetCFecLet ,
                                             DateTime AV26FDesde ,
                                             DateTime AV27FHasta ,
                                             DateTime A1109LetCFecVcto ,
                                             int A1123LetCVendCod ,
                                             int A1104LetCBanCod ,
                                             int AV14CodBan ,
                                             string A1120LetCTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[LetCLetCod], T1.[LetCTipCod] AS LetCTipCod, T1.[LetCDocNum] AS LetCDocNum, T1.[LetCBanCod], T1.[LetCTipo], T1.[LetCSec], T3.[CCVendCod] AS LetCVendCod, T1.[LetCFecVcto], T1.[LetCFecLet], T2.[LetCMonCod] AS LetCMonCod, T2.[LetCCliCod] AS LetCCliCod, T1.[LetCItem] FROM (([CLLETRASDET] T1 INNER JOIN [CLLETRAS] T2 ON T2.[LetCLetCod] = T1.[LetCLetCod]) LEFT JOIN [CLCUENTACOBRAR] T3 ON T3.[CCTipCod] = T1.[LetCTipCod] AND T3.[CCDocNum] = T1.[LetCDocNum])";
         AddWhere(sWhereString, "(T1.[LetCBanCod] = @AV14CodBan)");
         AddWhere(sWhereString, "(T1.[LetCTipo] = 'L')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[LetCCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV43LetPSec) )
         {
            AddWhere(sWhereString, "(T1.[LetCSec] = @AV43LetPSec)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV46MonCod) )
         {
            AddWhere(sWhereString, "(T2.[LetCMonCod] = @AV46MonCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecLet] >= @AV26FDesde)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecLet] <= @AV27FHasta)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecVcto] >= @AV26FDesde)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecVcto] <= @AV27FHasta)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (0==AV71VenCod) )
         {
            AddWhere(sWhereString, "(T3.[CCVendCod] = @AV71VenCod)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[LetCSec]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00E66( IGxContext context ,
                                             string AV13CliCod ,
                                             int AV46MonCod ,
                                             string AV60TipFecha ,
                                             int AV71VenCod ,
                                             string A206LetCCliCod ,
                                             int A205LetCMonCod ,
                                             DateTime A1108LetCFecLet ,
                                             DateTime AV26FDesde ,
                                             DateTime AV27FHasta ,
                                             DateTime A1109LetCFecVcto ,
                                             int A1123LetCVendCod ,
                                             int A1104LetCBanCod ,
                                             int AV14CodBan ,
                                             int A1116LetCSec ,
                                             int AV15CodSec ,
                                             string A1120LetCTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[9];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[LetCBanCod], T1.[LetCSec], T1.[LetCTipo], T5.[CCVendCod] AS LetCVendCod, T1.[LetCFecVcto], T1.[LetCFecLet], T2.[LetCMonCod] AS LetCMonCod, T2.[LetCCliCod] AS LetCCliCod, T1.[LetCLetCod], T1.[LetCTipCod] AS LetCTipCod, T1.[LetCDocNum] AS LetCDocNum, T1.[LetCImpDet], T3.[MonAbr], T1.[LetCDias], T1.[LetCBanNum], T4.[CliDsc], T1.[LetCItem] FROM (((([CLLETRASDET] T1 INNER JOIN [CLLETRAS] T2 ON T2.[LetCLetCod] = T1.[LetCLetCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T2.[LetCMonCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T2.[LetCCliCod]) LEFT JOIN [CLCUENTACOBRAR] T5 ON T5.[CCTipCod] = T1.[LetCTipCod] AND T5.[CCDocNum] = T1.[LetCDocNum])";
         AddWhere(sWhereString, "(T1.[LetCBanCod] = @AV14CodBan)");
         AddWhere(sWhereString, "(T1.[LetCSec] = @AV15CodSec)");
         AddWhere(sWhereString, "(T1.[LetCTipo] = 'L')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[LetCCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV46MonCod) )
         {
            AddWhere(sWhereString, "(T2.[LetCMonCod] = @AV46MonCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecLet] >= @AV26FDesde)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecLet] <= @AV27FHasta)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecVcto] >= @AV26FDesde)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecVcto] <= @AV27FHasta)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (0==AV71VenCod) )
         {
            AddWhere(sWhereString, "(T5.[CCVendCod] = @AV71VenCod)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[LetCFecVcto]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P00E64(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] );
               case 3 :
                     return conditional_P00E65(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] );
               case 4 :
                     return conditional_P00E66(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] );
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
          Object[] prmP00E62;
          prmP00E62 = new Object[] {
          new ParDef("@AV46MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00E63;
          prmP00E63 = new Object[] {
          new ParDef("@AV71VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00E67;
          prmP00E67 = new Object[] {
          new ParDef("@AV14CodBan",GXType.Int32,6,0)
          };
          Object[] prmP00E68;
          prmP00E68 = new Object[] {
          new ParDef("@AV41LetCTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV39LetCDocNum",GXType.NChar,12,0)
          };
          Object[] prmP00E69;
          prmP00E69 = new Object[] {
          new ParDef("@AV40LetCLetCod",GXType.NChar,10,0)
          };
          Object[] prmP00E64;
          prmP00E64 = new Object[] {
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV10BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV43LetPSec",GXType.Int32,6,0) ,
          new ParDef("@AV46MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV26FDesde",GXType.Date,8,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV26FDesde",GXType.Date,8,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV71VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00E65;
          prmP00E65 = new Object[] {
          new ParDef("@AV14CodBan",GXType.Int32,6,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV43LetPSec",GXType.Int32,6,0) ,
          new ParDef("@AV46MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV26FDesde",GXType.Date,8,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV26FDesde",GXType.Date,8,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV71VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00E66;
          prmP00E66 = new Object[] {
          new ParDef("@AV14CodBan",GXType.Int32,6,0) ,
          new ParDef("@AV15CodSec",GXType.Int32,6,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV46MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV26FDesde",GXType.Date,8,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV26FDesde",GXType.Date,8,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV71VenCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00E62", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV46MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E62,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E63", "SELECT [VenCod], [VenDsc] FROM [CVENDEDORES] WHERE [VenCod] = @AV71VenCod ORDER BY [VenCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E63,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E64", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E64,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E65", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E65,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E66", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E66,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E67", "SELECT [BanCod], [BanDsc] FROM [TSBANCOS] WHERE [BanCod] = @AV14CodBan ORDER BY [BanCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E67,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E68", "SELECT [CCDocNum], [CCTipCod], [CCEstado], [CCImpPago], [CCImpTotal] FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @AV41LetCTipCod and [CCDocNum] = @AV39LetCDocNum ORDER BY [CCTipCod], [CCDocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E68,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E69", "SELECT [LetCTipo], [LetCLetCod], [LetCDocNum] AS LetCDocNum, [LetCItem] FROM [CLLETRASDET] WHERE ([LetCLetCod] = @AV40LetCLetCod) AND ([LetCTipo] = 'D') ORDER BY [LetCLetCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E69,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 12);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 1);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 20);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 12);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 1);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 20);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getString(9, 10);
                ((string[]) buf[9])[0] = rslt.getString(10, 3);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 12);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 5);
                ((bool[]) buf[15])[0] = rslt.wasNull(13);
                ((short[]) buf[16])[0] = rslt.getShort(14);
                ((string[]) buf[17])[0] = rslt.getString(15, 20);
                ((string[]) buf[18])[0] = rslt.getString(16, 100);
                ((bool[]) buf[19])[0] = rslt.wasNull(16);
                ((int[]) buf[20])[0] = rslt.getInt(17);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
