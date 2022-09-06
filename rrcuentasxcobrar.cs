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
   public class rrcuentasxcobrar : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrcuentasxcobrar.aspx")), "rrcuentasxcobrar.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrcuentasxcobrar.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "TipCCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8TipCCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10CliCod = GetPar( "CliCod");
                  AV13TipCod = GetPar( "TipCod");
                  AV14MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV36FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV49ZonCod = (int)(NumberUtil.Val( GetPar( "ZonCod"), "."));
                  AV50Serie = GetPar( "Serie");
                  AV55TipLetras = (short)(NumberUtil.Val( GetPar( "TipLetras"), "."));
                  AV60VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
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

      public rrcuentasxcobrar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrcuentasxcobrar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TipCCod ,
                           ref string aP1_CliCod ,
                           ref string aP2_TipCod ,
                           ref int aP3_MonCod ,
                           ref DateTime aP4_FHasta ,
                           ref int aP5_ZonCod ,
                           ref string aP6_Serie ,
                           ref short aP7_TipLetras ,
                           ref int aP8_VenCod )
      {
         this.AV8TipCCod = aP0_TipCCod;
         this.AV10CliCod = aP1_CliCod;
         this.AV13TipCod = aP2_TipCod;
         this.AV14MonCod = aP3_MonCod;
         this.AV36FHasta = aP4_FHasta;
         this.AV49ZonCod = aP5_ZonCod;
         this.AV50Serie = aP6_Serie;
         this.AV55TipLetras = aP7_TipLetras;
         this.AV60VenCod = aP8_VenCod;
         initialize();
         executePrivate();
         aP0_TipCCod=this.AV8TipCCod;
         aP1_CliCod=this.AV10CliCod;
         aP2_TipCod=this.AV13TipCod;
         aP3_MonCod=this.AV14MonCod;
         aP4_FHasta=this.AV36FHasta;
         aP5_ZonCod=this.AV49ZonCod;
         aP6_Serie=this.AV50Serie;
         aP7_TipLetras=this.AV55TipLetras;
         aP8_VenCod=this.AV60VenCod;
      }

      public int executeUdp( ref int aP0_TipCCod ,
                             ref string aP1_CliCod ,
                             ref string aP2_TipCod ,
                             ref int aP3_MonCod ,
                             ref DateTime aP4_FHasta ,
                             ref int aP5_ZonCod ,
                             ref string aP6_Serie ,
                             ref short aP7_TipLetras )
      {
         execute(ref aP0_TipCCod, ref aP1_CliCod, ref aP2_TipCod, ref aP3_MonCod, ref aP4_FHasta, ref aP5_ZonCod, ref aP6_Serie, ref aP7_TipLetras, ref aP8_VenCod);
         return AV60VenCod ;
      }

      public void executeSubmit( ref int aP0_TipCCod ,
                                 ref string aP1_CliCod ,
                                 ref string aP2_TipCod ,
                                 ref int aP3_MonCod ,
                                 ref DateTime aP4_FHasta ,
                                 ref int aP5_ZonCod ,
                                 ref string aP6_Serie ,
                                 ref short aP7_TipLetras ,
                                 ref int aP8_VenCod )
      {
         rrcuentasxcobrar objrrcuentasxcobrar;
         objrrcuentasxcobrar = new rrcuentasxcobrar();
         objrrcuentasxcobrar.AV8TipCCod = aP0_TipCCod;
         objrrcuentasxcobrar.AV10CliCod = aP1_CliCod;
         objrrcuentasxcobrar.AV13TipCod = aP2_TipCod;
         objrrcuentasxcobrar.AV14MonCod = aP3_MonCod;
         objrrcuentasxcobrar.AV36FHasta = aP4_FHasta;
         objrrcuentasxcobrar.AV49ZonCod = aP5_ZonCod;
         objrrcuentasxcobrar.AV50Serie = aP6_Serie;
         objrrcuentasxcobrar.AV55TipLetras = aP7_TipLetras;
         objrrcuentasxcobrar.AV60VenCod = aP8_VenCod;
         objrrcuentasxcobrar.context.SetSubmitInitialConfig(context);
         objrrcuentasxcobrar.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrcuentasxcobrar);
         aP0_TipCCod=this.AV8TipCCod;
         aP1_CliCod=this.AV10CliCod;
         aP2_TipCod=this.AV13TipCod;
         aP3_MonCod=this.AV14MonCod;
         aP4_FHasta=this.AV36FHasta;
         aP5_ZonCod=this.AV49ZonCod;
         aP6_Serie=this.AV50Serie;
         aP7_TipLetras=this.AV55TipLetras;
         aP8_VenCod=this.AV60VenCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrcuentasxcobrar)stateInfo).executePrivate();
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
            AV34Empresa = AV35Session.Get("Empresa");
            AV32EmpDir = AV35Session.Get("EmpDir");
            AV42EmpRUC = AV35Session.Get("EmpRUC");
            AV43Ruta = AV35Session.Get("RUTA") + "/Logo.jpg";
            AV44Logo = AV43Ruta;
            AV63Logo_GXI = GXDbFile.PathToUrl( AV43Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV24Filtro3 = "Todos";
            AV25Filtro4 = "Todos";
            /* Using cursor P00902 */
            pr_default.execute(0, new Object[] {AV13TipCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A149TipCod = P00902_A149TipCod[0];
               A1910TipDsc = P00902_A1910TipDsc[0];
               AV22Filtro1 = A1910TipDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00903 */
            pr_default.execute(1, new Object[] {AV8TipCCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A159TipCCod = P00903_A159TipCCod[0];
               n159TipCCod = P00903_n159TipCCod[0];
               A1905TipCDsc = P00903_A1905TipCDsc[0];
               AV23Filtro2 = A1905TipCDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00904 */
            pr_default.execute(2, new Object[] {AV14MonCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A180MonCod = P00904_A180MonCod[0];
               A1234MonDsc = P00904_A1234MonDsc[0];
               n1234MonDsc = P00904_n1234MonDsc[0];
               AV24Filtro3 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P00905 */
            pr_default.execute(3, new Object[] {AV10CliCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A45CliCod = P00905_A45CliCod[0];
               A161CliDsc = P00905_A161CliDsc[0];
               AV25Filtro4 = A161CliDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            AV19TotGImporte = 0.00m;
            AV20TotGPagos = 0.00m;
            AV21TotGSaldo = 0.00m;
            AV51TotalMN = 0.00m;
            AV52TotalME = 0.00m;
            if ( DateTimeUtil.ResetTime ( AV36FHasta ) == DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
            {
               /* Execute user subroutine: 'CUENTACOBRAR' */
               S141 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            else
            {
               /* Execute user subroutine: 'CUENTACOBRARAL' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( (0==AV14MonCod) )
            {
               AV53MonMN = "";
               AV54MonME = "";
               /* Using cursor P00906 */
               pr_default.execute(4);
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A1234MonDsc = P00906_A1234MonDsc[0];
                  n1234MonDsc = P00906_n1234MonDsc[0];
                  A180MonCod = P00906_A180MonCod[0];
                  if ( A180MonCod == 1 )
                  {
                     AV53MonMN = StringUtil.Trim( A1234MonDsc);
                  }
                  if ( A180MonCod == 2 )
                  {
                     AV54MonME = StringUtil.Trim( A1234MonDsc);
                  }
                  pr_default.readNext(4);
               }
               pr_default.close(4);
               H900( false, 86) ;
               getPrinter().GxDrawRect(188, Gx_line+7, 603, Gx_line+79, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(422, Gx_line+7, 422, Gx_line+79, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(188, Gx_line+29, 603, Gx_line+29, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(188, Gx_line+52, 603, Gx_line+52, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Moneda", 285, Gx_line+11, 333, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total General", 460, Gx_line+11, 540, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53MonMN, "")), 194, Gx_line+34, 415, Gx_line+48, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54MonME, "")), 194, Gx_line+58, 415, Gx_line+72, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 464, Gx_line+34, 571, Gx_line+49, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 464, Gx_line+58, 571, Gx_line+73, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+86);
            }
            else
            {
               H900( false, 28) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19TotGImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 468, Gx_line+9, 565, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20TotGPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 569, Gx_line+9, 674, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV21TotGSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+9, 778, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(465, Gx_line+4, 787, Gx_line+4, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total General", 360, Gx_line+10, 440, Gx_line+24, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+28);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H900( true, 0) ;
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
         /* 'CUENTACOBRARAL' Routine */
         returnInSub = false;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV10CliCod ,
                                              AV8TipCCod ,
                                              AV14MonCod ,
                                              AV13TipCod ,
                                              AV49ZonCod ,
                                              AV60VenCod ,
                                              AV50Serie ,
                                              AV55TipLetras ,
                                              A188CCCliCod ,
                                              A159TipCCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A186CCVendCod ,
                                              A185CCDocNum ,
                                              A507CCFecUltPago ,
                                              AV36FHasta ,
                                              A190CCFech ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00907 */
         pr_default.execute(5, new Object[] {AV36FHasta, AV36FHasta, AV10CliCod, AV8TipCCod, AV14MonCod, AV13TipCod, AV49ZonCod, AV60VenCod, AV50Serie});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK908 = false;
            A189CCCliDsc = P00907_A189CCCliDsc[0];
            A185CCDocNum = P00907_A185CCDocNum[0];
            A511TipSigno = P00907_A511TipSigno[0];
            n511TipSigno = P00907_n511TipSigno[0];
            A513CCImpTotal = P00907_A513CCImpTotal[0];
            A509CCImpPago = P00907_A509CCImpPago[0];
            A187CCmonCod = P00907_A187CCmonCod[0];
            A508CCFVcto = P00907_A508CCFVcto[0];
            A1234MonDsc = P00907_A1234MonDsc[0];
            n1234MonDsc = P00907_n1234MonDsc[0];
            A306TipAbr = P00907_A306TipAbr[0];
            n306TipAbr = P00907_n306TipAbr[0];
            A190CCFech = P00907_A190CCFech[0];
            A184CCTipCod = P00907_A184CCTipCod[0];
            A506CCEstado = P00907_A506CCEstado[0];
            A507CCFecUltPago = P00907_A507CCFecUltPago[0];
            A186CCVendCod = P00907_A186CCVendCod[0];
            A158ZonCod = P00907_A158ZonCod[0];
            n158ZonCod = P00907_n158ZonCod[0];
            A159TipCCod = P00907_A159TipCCod[0];
            n159TipCCod = P00907_n159TipCCod[0];
            A188CCCliCod = P00907_A188CCCliCod[0];
            A630CliTel2 = P00907_A630CliTel2[0];
            n630CliTel2 = P00907_n630CliTel2[0];
            A629CliTel1 = P00907_A629CliTel1[0];
            n629CliTel1 = P00907_n629CliTel1[0];
            A1234MonDsc = P00907_A1234MonDsc[0];
            n1234MonDsc = P00907_n1234MonDsc[0];
            A511TipSigno = P00907_A511TipSigno[0];
            n511TipSigno = P00907_n511TipSigno[0];
            A306TipAbr = P00907_A306TipAbr[0];
            n306TipAbr = P00907_n306TipAbr[0];
            A158ZonCod = P00907_A158ZonCod[0];
            n158ZonCod = P00907_n158ZonCod[0];
            A159TipCCod = P00907_A159TipCCod[0];
            n159TipCCod = P00907_n159TipCCod[0];
            A630CliTel2 = P00907_A630CliTel2[0];
            n630CliTel2 = P00907_n630CliTel2[0];
            A629CliTel1 = P00907_A629CliTel1[0];
            n629CliTel1 = P00907_n629CliTel1[0];
            AV48CCCliCod = StringUtil.Trim( A188CCCliCod);
            AV47CliDsc = StringUtil.Trim( A188CCCliCod) + " - " + StringUtil.Trim( A189CCCliDsc);
            AV59Telf = "Telf : " + StringUtil.Trim( A629CliTel1) + (!String.IsNullOrEmpty(StringUtil.RTrim( A630CliTel2)) ? " / "+StringUtil.Trim( A630CliTel2) : "");
            /* Execute user subroutine: 'VALIDAMOV' */
            S128 ();
            if ( returnInSub )
            {
               pr_default.close(5);
               returnInSub = true;
               if (true) return;
            }
            if ( AV12Flag == 1 )
            {
               H900( false, 21) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47CliDsc, "")), 8, Gx_line+3, 434, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59Telf, "")), 457, Gx_line+3, 718, Gx_line+18, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
            }
            AV16TotImporte = 0.00m;
            AV17TotPagos = 0.00m;
            AV18TotSaldo = 0.00m;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00907_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRK908 = false;
               A185CCDocNum = P00907_A185CCDocNum[0];
               A511TipSigno = P00907_A511TipSigno[0];
               n511TipSigno = P00907_n511TipSigno[0];
               A513CCImpTotal = P00907_A513CCImpTotal[0];
               A509CCImpPago = P00907_A509CCImpPago[0];
               A187CCmonCod = P00907_A187CCmonCod[0];
               A508CCFVcto = P00907_A508CCFVcto[0];
               A1234MonDsc = P00907_A1234MonDsc[0];
               n1234MonDsc = P00907_n1234MonDsc[0];
               A306TipAbr = P00907_A306TipAbr[0];
               n306TipAbr = P00907_n306TipAbr[0];
               A190CCFech = P00907_A190CCFech[0];
               A184CCTipCod = P00907_A184CCTipCod[0];
               A1234MonDsc = P00907_A1234MonDsc[0];
               n1234MonDsc = P00907_n1234MonDsc[0];
               A511TipSigno = P00907_A511TipSigno[0];
               n511TipSigno = P00907_n511TipSigno[0];
               A306TipAbr = P00907_A306TipAbr[0];
               n306TipAbr = P00907_n306TipAbr[0];
               AV37CCTipCod = A184CCTipCod;
               AV38CCDocNum = A185CCDocNum;
               AV29Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV30Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV45ImpDoc = A513CCImpTotal;
               AV46PagoDoc = A509CCImpPago;
               AV39CCmonCod = A187CCmonCod;
               /* Execute user subroutine: 'PAGOS' */
               S139 ();
               if ( returnInSub )
               {
                  pr_default.close(5);
                  returnInSub = true;
                  if (true) return;
               }
               if ( ( AV46PagoDoc < Convert.ToDecimal( 0 )) )
               {
                  AV30Pagos = 0;
                  AV46PagoDoc = 0;
               }
               AV29Importe = (decimal)(AV45ImpDoc*A511TipSigno);
               AV30Pagos = (decimal)(AV46PagoDoc*A511TipSigno);
               AV15Saldo = (decimal)((AV45ImpDoc-AV46PagoDoc)*A511TipSigno);
               AV31Dias = (int)(DateTimeUtil.DDiff(AV36FHasta,A508CCFVcto));
               if ( ( AV15Saldo != Convert.ToDecimal( 0 )) )
               {
                  AV16TotImporte = (decimal)(AV16TotImporte+AV29Importe);
                  AV17TotPagos = (decimal)(AV17TotPagos+AV30Pagos);
                  AV18TotSaldo = (decimal)(AV18TotSaldo+AV15Saldo);
                  AV51TotalMN = (decimal)(AV51TotalMN+(((AV39CCmonCod==1) ? AV15Saldo : (decimal)(0))));
                  AV52TotalME = (decimal)(AV52TotalME+(((AV39CCmonCod==2) ? AV15Saldo : (decimal)(0))));
                  H900( false, 17) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A185CCDocNum, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A190CCFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A508CCFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 394, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV30Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV15Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31Dias), "ZZZZ9")), 308, Gx_line+2, 365, Gx_line+17, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
               }
               BRK908 = true;
               pr_default.readNext(5);
            }
            if ( ( AV18TotSaldo != Convert.ToDecimal( 0 )) )
            {
               H900( false, 24) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(466, Gx_line+1, 788, Gx_line+1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Cliente", 349, Gx_line+6, 424, Gx_line+20, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
            }
            AV19TotGImporte = (decimal)(AV19TotGImporte+AV16TotImporte);
            AV20TotGPagos = (decimal)(AV20TotGPagos+AV17TotPagos);
            AV21TotGSaldo = (decimal)(AV21TotGSaldo+AV18TotSaldo);
            if ( ! BRK908 )
            {
               BRK908 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S141( )
      {
         /* 'CUENTACOBRAR' Routine */
         returnInSub = false;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV10CliCod ,
                                              AV8TipCCod ,
                                              AV14MonCod ,
                                              AV13TipCod ,
                                              AV49ZonCod ,
                                              AV60VenCod ,
                                              AV50Serie ,
                                              AV55TipLetras ,
                                              A188CCCliCod ,
                                              A159TipCCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A186CCVendCod ,
                                              A185CCDocNum ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor P00908 */
         pr_default.execute(6, new Object[] {AV10CliCod, AV8TipCCod, AV14MonCod, AV13TipCod, AV49ZonCod, AV60VenCod, AV50Serie});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK9010 = false;
            A189CCCliDsc = P00908_A189CCCliDsc[0];
            A511TipSigno = P00908_A511TipSigno[0];
            n511TipSigno = P00908_n511TipSigno[0];
            A513CCImpTotal = P00908_A513CCImpTotal[0];
            A509CCImpPago = P00908_A509CCImpPago[0];
            A508CCFVcto = P00908_A508CCFVcto[0];
            A187CCmonCod = P00908_A187CCmonCod[0];
            A1234MonDsc = P00908_A1234MonDsc[0];
            n1234MonDsc = P00908_n1234MonDsc[0];
            A185CCDocNum = P00908_A185CCDocNum[0];
            A306TipAbr = P00908_A306TipAbr[0];
            n306TipAbr = P00908_n306TipAbr[0];
            A190CCFech = P00908_A190CCFech[0];
            A184CCTipCod = P00908_A184CCTipCod[0];
            A506CCEstado = P00908_A506CCEstado[0];
            A186CCVendCod = P00908_A186CCVendCod[0];
            A158ZonCod = P00908_A158ZonCod[0];
            n158ZonCod = P00908_n158ZonCod[0];
            A159TipCCod = P00908_A159TipCCod[0];
            n159TipCCod = P00908_n159TipCCod[0];
            A188CCCliCod = P00908_A188CCCliCod[0];
            A630CliTel2 = P00908_A630CliTel2[0];
            n630CliTel2 = P00908_n630CliTel2[0];
            A629CliTel1 = P00908_A629CliTel1[0];
            n629CliTel1 = P00908_n629CliTel1[0];
            A1234MonDsc = P00908_A1234MonDsc[0];
            n1234MonDsc = P00908_n1234MonDsc[0];
            A511TipSigno = P00908_A511TipSigno[0];
            n511TipSigno = P00908_n511TipSigno[0];
            A306TipAbr = P00908_A306TipAbr[0];
            n306TipAbr = P00908_n306TipAbr[0];
            A158ZonCod = P00908_A158ZonCod[0];
            n158ZonCod = P00908_n158ZonCod[0];
            A159TipCCod = P00908_A159TipCCod[0];
            n159TipCCod = P00908_n159TipCCod[0];
            A630CliTel2 = P00908_A630CliTel2[0];
            n630CliTel2 = P00908_n630CliTel2[0];
            A629CliTel1 = P00908_A629CliTel1[0];
            n629CliTel1 = P00908_n629CliTel1[0];
            AV48CCCliCod = A188CCCliCod;
            AV47CliDsc = StringUtil.Trim( A188CCCliCod) + " - " + StringUtil.Trim( A189CCCliDsc);
            AV59Telf = "Telf : " + StringUtil.Trim( A629CliTel1) + (!String.IsNullOrEmpty(StringUtil.RTrim( A630CliTel2)) ? " / "+StringUtil.Trim( A630CliTel2) : "");
            H900( false, 21) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47CliDsc, "")), 8, Gx_line+3, 434, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59Telf, "")), 457, Gx_line+3, 718, Gx_line+18, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+21);
            AV16TotImporte = 0.00m;
            AV17TotPagos = 0.00m;
            AV18TotSaldo = 0.00m;
            while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P00908_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRK9010 = false;
               A511TipSigno = P00908_A511TipSigno[0];
               n511TipSigno = P00908_n511TipSigno[0];
               A513CCImpTotal = P00908_A513CCImpTotal[0];
               A509CCImpPago = P00908_A509CCImpPago[0];
               A508CCFVcto = P00908_A508CCFVcto[0];
               A187CCmonCod = P00908_A187CCmonCod[0];
               A1234MonDsc = P00908_A1234MonDsc[0];
               n1234MonDsc = P00908_n1234MonDsc[0];
               A185CCDocNum = P00908_A185CCDocNum[0];
               A306TipAbr = P00908_A306TipAbr[0];
               n306TipAbr = P00908_n306TipAbr[0];
               A190CCFech = P00908_A190CCFech[0];
               A184CCTipCod = P00908_A184CCTipCod[0];
               A1234MonDsc = P00908_A1234MonDsc[0];
               n1234MonDsc = P00908_n1234MonDsc[0];
               A511TipSigno = P00908_A511TipSigno[0];
               n511TipSigno = P00908_n511TipSigno[0];
               A306TipAbr = P00908_A306TipAbr[0];
               n306TipAbr = P00908_n306TipAbr[0];
               AV29Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV30Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV15Saldo = (decimal)((A513CCImpTotal-A509CCImpPago)*A511TipSigno);
               AV31Dias = (int)(DateTimeUtil.DDiff(AV36FHasta,A508CCFVcto));
               AV16TotImporte = (decimal)(AV16TotImporte+AV29Importe);
               AV17TotPagos = (decimal)(AV17TotPagos+AV30Pagos);
               AV18TotSaldo = (decimal)(AV18TotSaldo+AV15Saldo);
               AV51TotalMN = (decimal)(AV51TotalMN+(((A187CCmonCod==1) ? AV15Saldo : (decimal)(0))));
               AV52TotalME = (decimal)(AV52TotalME+(((A187CCmonCod==2) ? AV15Saldo : (decimal)(0))));
               H900( false, 17) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A185CCDocNum, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A190CCFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A508CCFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 394, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV30Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV15Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31Dias), "ZZZZ9")), 308, Gx_line+2, 365, Gx_line+17, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               BRK9010 = true;
               pr_default.readNext(6);
            }
            H900( false, 24) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(466, Gx_line+1, 788, Gx_line+1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Cliente", 349, Gx_line+6, 424, Gx_line+20, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+24);
            AV19TotGImporte = (decimal)(AV19TotGImporte+AV16TotImporte);
            AV20TotGPagos = (decimal)(AV20TotGPagos+AV17TotPagos);
            AV21TotGSaldo = (decimal)(AV21TotGSaldo+AV18TotSaldo);
            if ( ! BRK9010 )
            {
               BRK9010 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      protected void S128( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         AV12Flag = 0;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV8TipCCod ,
                                              AV14MonCod ,
                                              AV13TipCod ,
                                              AV49ZonCod ,
                                              AV60VenCod ,
                                              AV50Serie ,
                                              AV55TipLetras ,
                                              A159TipCCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A186CCVendCod ,
                                              A185CCDocNum ,
                                              A507CCFecUltPago ,
                                              AV36FHasta ,
                                              A190CCFech ,
                                              A506CCEstado ,
                                              A188CCCliCod ,
                                              AV48CCCliCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00909 */
         pr_default.execute(7, new Object[] {AV36FHasta, AV36FHasta, AV48CCCliCod, AV8TipCCod, AV14MonCod, AV13TipCod, AV49ZonCod, AV60VenCod, AV50Serie});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A188CCCliCod = P00909_A188CCCliCod[0];
            A506CCEstado = P00909_A506CCEstado[0];
            A185CCDocNum = P00909_A185CCDocNum[0];
            A190CCFech = P00909_A190CCFech[0];
            A507CCFecUltPago = P00909_A507CCFecUltPago[0];
            A186CCVendCod = P00909_A186CCVendCod[0];
            A158ZonCod = P00909_A158ZonCod[0];
            n158ZonCod = P00909_n158ZonCod[0];
            A184CCTipCod = P00909_A184CCTipCod[0];
            A187CCmonCod = P00909_A187CCmonCod[0];
            A159TipCCod = P00909_A159TipCCod[0];
            n159TipCCod = P00909_n159TipCCod[0];
            A513CCImpTotal = P00909_A513CCImpTotal[0];
            A509CCImpPago = P00909_A509CCImpPago[0];
            A511TipSigno = P00909_A511TipSigno[0];
            n511TipSigno = P00909_n511TipSigno[0];
            A158ZonCod = P00909_A158ZonCod[0];
            n158ZonCod = P00909_n158ZonCod[0];
            A159TipCCod = P00909_A159TipCCod[0];
            n159TipCCod = P00909_n159TipCCod[0];
            A511TipSigno = P00909_A511TipSigno[0];
            n511TipSigno = P00909_n511TipSigno[0];
            AV37CCTipCod = A184CCTipCod;
            AV38CCDocNum = A185CCDocNum;
            AV29Importe = A513CCImpTotal;
            AV39CCmonCod = A187CCmonCod;
            AV46PagoDoc = A509CCImpPago;
            /* Execute user subroutine: 'PAGOS' */
            S139 ();
            if ( returnInSub )
            {
               pr_default.close(7);
               returnInSub = true;
               if (true) return;
            }
            if ( ( AV46PagoDoc < Convert.ToDecimal( 0 )) )
            {
               AV46PagoDoc = 0;
            }
            AV56ImporteVal = (decimal)(AV29Importe*A511TipSigno);
            AV57PagosVal = (decimal)(AV46PagoDoc*A511TipSigno);
            AV58SaldoVal = (decimal)((AV29Importe-AV46PagoDoc)*A511TipSigno);
            if ( ( AV58SaldoVal != Convert.ToDecimal( 0 )) )
            {
               AV12Flag = 1;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void S139( )
      {
         /* 'PAGOS' Routine */
         returnInSub = false;
         /* Using cursor P009010 */
         pr_default.execute(8, new Object[] {AV37CCTipCod, AV38CCDocNum, AV36FHasta});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A166CobTip = P009010_A166CobTip[0];
            A167CobCod = P009010_A167CobCod[0];
            A661CobSts = P009010_A661CobSts[0];
            A655CobFec = P009010_A655CobFec[0];
            A176CobDocNum = P009010_A176CobDocNum[0];
            A175CobTipCod = P009010_A175CobTipCod[0];
            A172CobMon = P009010_A172CobMon[0];
            A654CobDTot = P009010_A654CobDTot[0];
            A663CobTipCam = P009010_A663CobTipCam[0];
            A173Item = P009010_A173Item[0];
            A661CobSts = P009010_A661CobSts[0];
            A655CobFec = P009010_A655CobFec[0];
            A172CobMon = P009010_A172CobMon[0];
            AV40CobMon = A172CobMon;
            AV41CobDtot = NumberUtil.Round( A654CobDTot, 2);
            if ( ( AV41CobDtot < Convert.ToDecimal( 0 )) )
            {
               AV41CobDtot = (decimal)(AV41CobDtot*-1);
            }
            if ( AV39CCmonCod == AV40CobMon )
            {
               AV46PagoDoc = (decimal)(AV46PagoDoc-AV41CobDtot);
            }
            else
            {
               if ( AV39CCmonCod == 1 )
               {
                  AV46PagoDoc = (decimal)(AV46PagoDoc-(NumberUtil.Round( AV41CobDtot*A663CobTipCam, 2)));
               }
               else
               {
                  AV46PagoDoc = (decimal)(AV46PagoDoc-(NumberUtil.Round( AV41CobDtot/ (decimal)(A663CobTipCam), 2)));
               }
            }
            pr_default.readNext(8);
         }
         pr_default.close(8);
      }

      protected void H900( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 675, Gx_line+29, 707, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 675, Gx_line+46, 719, Gx_line+60, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 675, Gx_line+13, 714, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 731, Gx_line+46, 770, Gx_line+61, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 700, Gx_line+29, 769, Gx_line+43, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 723, Gx_line+13, 770, Gx_line+28, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 14, Gx_line+223, 37, Gx_line+237, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Documento", 71, Gx_line+224, 156, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dias Vcto", 324, Gx_line+224, 379, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 395, Gx_line+224, 443, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe Total", 473, Gx_line+224, 556, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+217, 797, Gx_line+243, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuentas por Cobrar ", 302, Gx_line+70, 473, Gx_line+90, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 174, Gx_line+224, 209, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Vcto", 236, Gx_line+224, 301, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 719, Gx_line+224, 752, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pago", 616, Gx_line+224, 646, Gx_line+238, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Documento", 192, Gx_line+126, 307, Gx_line+140, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Cliente", 192, Gx_line+148, 279, Gx_line+162, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 192, Gx_line+170, 240, Gx_line+184, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 192, Gx_line+194, 234, Gx_line+208, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 309, Gx_line+121, 652, Gx_line+145, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro2, "")), 309, Gx_line+143, 652, Gx_line+167, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro3, "")), 309, Gx_line+165, 652, Gx_line+189, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Filtro4, "")), 309, Gx_line+189, 652, Gx_line+213, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32EmpDir, "")), 19, Gx_line+29, 404, Gx_line+47, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42EmpRUC, "")), 19, Gx_line+46, 404, Gx_line+64, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Empresa, "")), 19, Gx_line+11, 404, Gx_line+29, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 324, Gx_line+93, 354, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV36FHasta, "99/99/99"), 364, Gx_line+93, 446, Gx_line+114, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+243);
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
         AV34Empresa = "";
         AV35Session = context.GetSession();
         AV32EmpDir = "";
         AV42EmpRUC = "";
         AV43Ruta = "";
         AV44Logo = "";
         AV63Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         AV25Filtro4 = "";
         scmdbuf = "";
         P00902_A149TipCod = new string[] {""} ;
         P00902_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         P00903_A159TipCCod = new int[1] ;
         P00903_n159TipCCod = new bool[] {false} ;
         P00903_A1905TipCDsc = new string[] {""} ;
         A1905TipCDsc = "";
         P00904_A180MonCod = new int[1] ;
         P00904_A1234MonDsc = new string[] {""} ;
         P00904_n1234MonDsc = new bool[] {false} ;
         A1234MonDsc = "";
         P00905_A45CliCod = new string[] {""} ;
         P00905_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         AV53MonMN = "";
         AV54MonME = "";
         P00906_A1234MonDsc = new string[] {""} ;
         P00906_n1234MonDsc = new bool[] {false} ;
         P00906_A180MonCod = new int[1] ;
         A188CCCliCod = "";
         A184CCTipCod = "";
         A185CCDocNum = "";
         A507CCFecUltPago = DateTime.MinValue;
         A190CCFech = DateTime.MinValue;
         A506CCEstado = "";
         P00907_A189CCCliDsc = new string[] {""} ;
         P00907_A185CCDocNum = new string[] {""} ;
         P00907_A511TipSigno = new short[1] ;
         P00907_n511TipSigno = new bool[] {false} ;
         P00907_A513CCImpTotal = new decimal[1] ;
         P00907_A509CCImpPago = new decimal[1] ;
         P00907_A187CCmonCod = new int[1] ;
         P00907_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00907_A1234MonDsc = new string[] {""} ;
         P00907_n1234MonDsc = new bool[] {false} ;
         P00907_A306TipAbr = new string[] {""} ;
         P00907_n306TipAbr = new bool[] {false} ;
         P00907_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00907_A184CCTipCod = new string[] {""} ;
         P00907_A506CCEstado = new string[] {""} ;
         P00907_A507CCFecUltPago = new DateTime[] {DateTime.MinValue} ;
         P00907_A186CCVendCod = new int[1] ;
         P00907_A158ZonCod = new int[1] ;
         P00907_n158ZonCod = new bool[] {false} ;
         P00907_A159TipCCod = new int[1] ;
         P00907_n159TipCCod = new bool[] {false} ;
         P00907_A188CCCliCod = new string[] {""} ;
         P00907_A630CliTel2 = new string[] {""} ;
         P00907_n630CliTel2 = new bool[] {false} ;
         P00907_A629CliTel1 = new string[] {""} ;
         P00907_n629CliTel1 = new bool[] {false} ;
         A189CCCliDsc = "";
         A508CCFVcto = DateTime.MinValue;
         A306TipAbr = "";
         A630CliTel2 = "";
         A629CliTel1 = "";
         AV48CCCliCod = "";
         AV47CliDsc = "";
         AV59Telf = "";
         AV37CCTipCod = "";
         AV38CCDocNum = "";
         P00908_A189CCCliDsc = new string[] {""} ;
         P00908_A511TipSigno = new short[1] ;
         P00908_n511TipSigno = new bool[] {false} ;
         P00908_A513CCImpTotal = new decimal[1] ;
         P00908_A509CCImpPago = new decimal[1] ;
         P00908_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00908_A187CCmonCod = new int[1] ;
         P00908_A1234MonDsc = new string[] {""} ;
         P00908_n1234MonDsc = new bool[] {false} ;
         P00908_A185CCDocNum = new string[] {""} ;
         P00908_A306TipAbr = new string[] {""} ;
         P00908_n306TipAbr = new bool[] {false} ;
         P00908_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00908_A184CCTipCod = new string[] {""} ;
         P00908_A506CCEstado = new string[] {""} ;
         P00908_A186CCVendCod = new int[1] ;
         P00908_A158ZonCod = new int[1] ;
         P00908_n158ZonCod = new bool[] {false} ;
         P00908_A159TipCCod = new int[1] ;
         P00908_n159TipCCod = new bool[] {false} ;
         P00908_A188CCCliCod = new string[] {""} ;
         P00908_A630CliTel2 = new string[] {""} ;
         P00908_n630CliTel2 = new bool[] {false} ;
         P00908_A629CliTel1 = new string[] {""} ;
         P00908_n629CliTel1 = new bool[] {false} ;
         P00909_A188CCCliCod = new string[] {""} ;
         P00909_A506CCEstado = new string[] {""} ;
         P00909_A185CCDocNum = new string[] {""} ;
         P00909_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00909_A507CCFecUltPago = new DateTime[] {DateTime.MinValue} ;
         P00909_A186CCVendCod = new int[1] ;
         P00909_A158ZonCod = new int[1] ;
         P00909_n158ZonCod = new bool[] {false} ;
         P00909_A184CCTipCod = new string[] {""} ;
         P00909_A187CCmonCod = new int[1] ;
         P00909_A159TipCCod = new int[1] ;
         P00909_n159TipCCod = new bool[] {false} ;
         P00909_A513CCImpTotal = new decimal[1] ;
         P00909_A509CCImpPago = new decimal[1] ;
         P00909_A511TipSigno = new short[1] ;
         P00909_n511TipSigno = new bool[] {false} ;
         P009010_A166CobTip = new string[] {""} ;
         P009010_A167CobCod = new string[] {""} ;
         P009010_A661CobSts = new string[] {""} ;
         P009010_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         P009010_A176CobDocNum = new string[] {""} ;
         P009010_A175CobTipCod = new string[] {""} ;
         P009010_A172CobMon = new int[1] ;
         P009010_A654CobDTot = new decimal[1] ;
         P009010_A663CobTipCam = new decimal[1] ;
         P009010_A173Item = new int[1] ;
         A166CobTip = "";
         A167CobCod = "";
         A661CobSts = "";
         A655CobFec = DateTime.MinValue;
         A176CobDocNum = "";
         A175CobTipCod = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrcuentasxcobrar__default(),
            new Object[][] {
                new Object[] {
               P00902_A149TipCod, P00902_A1910TipDsc
               }
               , new Object[] {
               P00903_A159TipCCod, P00903_A1905TipCDsc
               }
               , new Object[] {
               P00904_A180MonCod, P00904_A1234MonDsc
               }
               , new Object[] {
               P00905_A45CliCod, P00905_A161CliDsc
               }
               , new Object[] {
               P00906_A1234MonDsc, P00906_A180MonCod
               }
               , new Object[] {
               P00907_A189CCCliDsc, P00907_A185CCDocNum, P00907_A511TipSigno, P00907_n511TipSigno, P00907_A513CCImpTotal, P00907_A509CCImpPago, P00907_A187CCmonCod, P00907_A508CCFVcto, P00907_A1234MonDsc, P00907_n1234MonDsc,
               P00907_A306TipAbr, P00907_n306TipAbr, P00907_A190CCFech, P00907_A184CCTipCod, P00907_A506CCEstado, P00907_A507CCFecUltPago, P00907_A186CCVendCod, P00907_A158ZonCod, P00907_n158ZonCod, P00907_A159TipCCod,
               P00907_n159TipCCod, P00907_A188CCCliCod, P00907_A630CliTel2, P00907_n630CliTel2, P00907_A629CliTel1, P00907_n629CliTel1
               }
               , new Object[] {
               P00908_A189CCCliDsc, P00908_A511TipSigno, P00908_n511TipSigno, P00908_A513CCImpTotal, P00908_A509CCImpPago, P00908_A508CCFVcto, P00908_A187CCmonCod, P00908_A1234MonDsc, P00908_n1234MonDsc, P00908_A185CCDocNum,
               P00908_A306TipAbr, P00908_n306TipAbr, P00908_A190CCFech, P00908_A184CCTipCod, P00908_A506CCEstado, P00908_A186CCVendCod, P00908_A158ZonCod, P00908_n158ZonCod, P00908_A159TipCCod, P00908_n159TipCCod,
               P00908_A188CCCliCod, P00908_A630CliTel2, P00908_n630CliTel2, P00908_A629CliTel1, P00908_n629CliTel1
               }
               , new Object[] {
               P00909_A188CCCliCod, P00909_A506CCEstado, P00909_A185CCDocNum, P00909_A190CCFech, P00909_A507CCFecUltPago, P00909_A186CCVendCod, P00909_A158ZonCod, P00909_n158ZonCod, P00909_A184CCTipCod, P00909_A187CCmonCod,
               P00909_A159TipCCod, P00909_n159TipCCod, P00909_A513CCImpTotal, P00909_A509CCImpPago, P00909_A511TipSigno, P00909_n511TipSigno
               }
               , new Object[] {
               P009010_A166CobTip, P009010_A167CobCod, P009010_A661CobSts, P009010_A655CobFec, P009010_A176CobDocNum, P009010_A175CobTipCod, P009010_A172CobMon, P009010_A654CobDTot, P009010_A663CobTipCam, P009010_A173Item
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
      private short AV55TipLetras ;
      private short A511TipSigno ;
      private short AV12Flag ;
      private int AV8TipCCod ;
      private int AV14MonCod ;
      private int AV49ZonCod ;
      private int AV60VenCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A159TipCCod ;
      private int A180MonCod ;
      private int Gx_OldLine ;
      private int A187CCmonCod ;
      private int A158ZonCod ;
      private int A186CCVendCod ;
      private int AV39CCmonCod ;
      private int AV31Dias ;
      private int A172CobMon ;
      private int A173Item ;
      private int AV40CobMon ;
      private decimal AV19TotGImporte ;
      private decimal AV20TotGPagos ;
      private decimal AV21TotGSaldo ;
      private decimal AV51TotalMN ;
      private decimal AV52TotalME ;
      private decimal A513CCImpTotal ;
      private decimal A509CCImpPago ;
      private decimal AV16TotImporte ;
      private decimal AV17TotPagos ;
      private decimal AV18TotSaldo ;
      private decimal AV29Importe ;
      private decimal AV30Pagos ;
      private decimal AV45ImpDoc ;
      private decimal AV46PagoDoc ;
      private decimal AV15Saldo ;
      private decimal AV56ImporteVal ;
      private decimal AV57PagosVal ;
      private decimal AV58SaldoVal ;
      private decimal A654CobDTot ;
      private decimal A663CobTipCam ;
      private decimal AV41CobDtot ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10CliCod ;
      private string AV13TipCod ;
      private string AV50Serie ;
      private string AV34Empresa ;
      private string AV32EmpDir ;
      private string AV42EmpRUC ;
      private string AV43Ruta ;
      private string AV22Filtro1 ;
      private string AV23Filtro2 ;
      private string AV24Filtro3 ;
      private string AV25Filtro4 ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private string A1905TipCDsc ;
      private string A1234MonDsc ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string AV53MonMN ;
      private string AV54MonME ;
      private string A188CCCliCod ;
      private string A184CCTipCod ;
      private string A185CCDocNum ;
      private string A506CCEstado ;
      private string A189CCCliDsc ;
      private string A306TipAbr ;
      private string A630CliTel2 ;
      private string A629CliTel1 ;
      private string AV48CCCliCod ;
      private string AV47CliDsc ;
      private string AV37CCTipCod ;
      private string AV38CCDocNum ;
      private string A166CobTip ;
      private string A167CobCod ;
      private string A661CobSts ;
      private string A176CobDocNum ;
      private string A175CobTipCod ;
      private string Gx_time ;
      private DateTime AV36FHasta ;
      private DateTime A507CCFecUltPago ;
      private DateTime A190CCFech ;
      private DateTime A508CCFVcto ;
      private DateTime A655CobFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n159TipCCod ;
      private bool n1234MonDsc ;
      private bool returnInSub ;
      private bool BRK908 ;
      private bool n511TipSigno ;
      private bool n306TipAbr ;
      private bool n158ZonCod ;
      private bool n630CliTel2 ;
      private bool n629CliTel1 ;
      private bool BRK9010 ;
      private string AV63Logo_GXI ;
      private string AV59Telf ;
      private string AV44Logo ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TipCCod ;
      private string aP1_CliCod ;
      private string aP2_TipCod ;
      private int aP3_MonCod ;
      private DateTime aP4_FHasta ;
      private int aP5_ZonCod ;
      private string aP6_Serie ;
      private short aP7_TipLetras ;
      private int aP8_VenCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00902_A149TipCod ;
      private string[] P00902_A1910TipDsc ;
      private int[] P00903_A159TipCCod ;
      private bool[] P00903_n159TipCCod ;
      private string[] P00903_A1905TipCDsc ;
      private int[] P00904_A180MonCod ;
      private string[] P00904_A1234MonDsc ;
      private bool[] P00904_n1234MonDsc ;
      private string[] P00905_A45CliCod ;
      private string[] P00905_A161CliDsc ;
      private string[] P00906_A1234MonDsc ;
      private bool[] P00906_n1234MonDsc ;
      private int[] P00906_A180MonCod ;
      private string[] P00907_A189CCCliDsc ;
      private string[] P00907_A185CCDocNum ;
      private short[] P00907_A511TipSigno ;
      private bool[] P00907_n511TipSigno ;
      private decimal[] P00907_A513CCImpTotal ;
      private decimal[] P00907_A509CCImpPago ;
      private int[] P00907_A187CCmonCod ;
      private DateTime[] P00907_A508CCFVcto ;
      private string[] P00907_A1234MonDsc ;
      private bool[] P00907_n1234MonDsc ;
      private string[] P00907_A306TipAbr ;
      private bool[] P00907_n306TipAbr ;
      private DateTime[] P00907_A190CCFech ;
      private string[] P00907_A184CCTipCod ;
      private string[] P00907_A506CCEstado ;
      private DateTime[] P00907_A507CCFecUltPago ;
      private int[] P00907_A186CCVendCod ;
      private int[] P00907_A158ZonCod ;
      private bool[] P00907_n158ZonCod ;
      private int[] P00907_A159TipCCod ;
      private bool[] P00907_n159TipCCod ;
      private string[] P00907_A188CCCliCod ;
      private string[] P00907_A630CliTel2 ;
      private bool[] P00907_n630CliTel2 ;
      private string[] P00907_A629CliTel1 ;
      private bool[] P00907_n629CliTel1 ;
      private string[] P00908_A189CCCliDsc ;
      private short[] P00908_A511TipSigno ;
      private bool[] P00908_n511TipSigno ;
      private decimal[] P00908_A513CCImpTotal ;
      private decimal[] P00908_A509CCImpPago ;
      private DateTime[] P00908_A508CCFVcto ;
      private int[] P00908_A187CCmonCod ;
      private string[] P00908_A1234MonDsc ;
      private bool[] P00908_n1234MonDsc ;
      private string[] P00908_A185CCDocNum ;
      private string[] P00908_A306TipAbr ;
      private bool[] P00908_n306TipAbr ;
      private DateTime[] P00908_A190CCFech ;
      private string[] P00908_A184CCTipCod ;
      private string[] P00908_A506CCEstado ;
      private int[] P00908_A186CCVendCod ;
      private int[] P00908_A158ZonCod ;
      private bool[] P00908_n158ZonCod ;
      private int[] P00908_A159TipCCod ;
      private bool[] P00908_n159TipCCod ;
      private string[] P00908_A188CCCliCod ;
      private string[] P00908_A630CliTel2 ;
      private bool[] P00908_n630CliTel2 ;
      private string[] P00908_A629CliTel1 ;
      private bool[] P00908_n629CliTel1 ;
      private string[] P00909_A188CCCliCod ;
      private string[] P00909_A506CCEstado ;
      private string[] P00909_A185CCDocNum ;
      private DateTime[] P00909_A190CCFech ;
      private DateTime[] P00909_A507CCFecUltPago ;
      private int[] P00909_A186CCVendCod ;
      private int[] P00909_A158ZonCod ;
      private bool[] P00909_n158ZonCod ;
      private string[] P00909_A184CCTipCod ;
      private int[] P00909_A187CCmonCod ;
      private int[] P00909_A159TipCCod ;
      private bool[] P00909_n159TipCCod ;
      private decimal[] P00909_A513CCImpTotal ;
      private decimal[] P00909_A509CCImpPago ;
      private short[] P00909_A511TipSigno ;
      private bool[] P00909_n511TipSigno ;
      private string[] P009010_A166CobTip ;
      private string[] P009010_A167CobCod ;
      private string[] P009010_A661CobSts ;
      private DateTime[] P009010_A655CobFec ;
      private string[] P009010_A176CobDocNum ;
      private string[] P009010_A175CobTipCod ;
      private int[] P009010_A172CobMon ;
      private decimal[] P009010_A654CobDTot ;
      private decimal[] P009010_A663CobTipCam ;
      private int[] P009010_A173Item ;
   }

   public class rrcuentasxcobrar__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00907( IGxContext context ,
                                             string AV10CliCod ,
                                             int AV8TipCCod ,
                                             int AV14MonCod ,
                                             string AV13TipCod ,
                                             int AV49ZonCod ,
                                             int AV60VenCod ,
                                             string AV50Serie ,
                                             short AV55TipLetras ,
                                             string A188CCCliCod ,
                                             int A159TipCCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A186CCVendCod ,
                                             string A185CCDocNum ,
                                             DateTime A507CCFecUltPago ,
                                             DateTime AV36FHasta ,
                                             DateTime A190CCFech ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliDsc], T1.[CCDocNum], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCmonCod] AS CCmonCod, T1.[CCFVcto], T2.[MonDsc], T3.[TipAbr], T1.[CCFech], T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T1.[CCFecUltPago], T1.[CCVendCod], T4.[ZonCod], T4.[TipCCod], T1.[CCCliCod] AS CCCliCod, T4.[CliTel2], T4.[CliTel1] FROM ((([CLCUENTACOBRAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T1.[CCFecUltPago] > @AV36FHasta or (T1.[CCFecUltPago] = convert( DATETIME, '17530101', 112 )))");
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV36FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] <> 'A')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV10CliCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV8TipCCod) )
         {
            AddWhere(sWhereString, "(T4.[TipCCod] = @AV8TipCCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV13TipCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV49ZonCod) )
         {
            AddWhere(sWhereString, "(T4.[ZonCod] = @AV49ZonCod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV60VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV60VenCod)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CCDocNum], 1, 3) = @AV50Serie)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV55TipLetras) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] <> 'LET')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCTipCod], T1.[CCFech]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00908( IGxContext context ,
                                             string AV10CliCod ,
                                             int AV8TipCCod ,
                                             int AV14MonCod ,
                                             string AV13TipCod ,
                                             int AV49ZonCod ,
                                             int AV60VenCod ,
                                             string AV50Serie ,
                                             short AV55TipLetras ,
                                             string A188CCCliCod ,
                                             int A159TipCCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A186CCVendCod ,
                                             string A185CCDocNum ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliDsc], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCFVcto], T1.[CCmonCod] AS CCmonCod, T2.[MonDsc], T1.[CCDocNum], T3.[TipAbr], T1.[CCFech], T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T1.[CCVendCod], T4.[ZonCod], T4.[TipCCod], T1.[CCCliCod] AS CCCliCod, T4.[CliTel2], T4.[CliTel1] FROM ((([CLCUENTACOBRAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T1.[CCEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV10CliCod)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV8TipCCod) )
         {
            AddWhere(sWhereString, "(T4.[TipCCod] = @AV8TipCCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV13TipCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV49ZonCod) )
         {
            AddWhere(sWhereString, "(T4.[ZonCod] = @AV49ZonCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV60VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV60VenCod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CCDocNum], 1, 3) = @AV50Serie)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV55TipLetras) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] <> 'LET')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCTipCod], T1.[CCFech]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00909( IGxContext context ,
                                             int AV8TipCCod ,
                                             int AV14MonCod ,
                                             string AV13TipCod ,
                                             int AV49ZonCod ,
                                             int AV60VenCod ,
                                             string AV50Serie ,
                                             short AV55TipLetras ,
                                             int A159TipCCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A186CCVendCod ,
                                             string A185CCDocNum ,
                                             DateTime A507CCFecUltPago ,
                                             DateTime AV36FHasta ,
                                             DateTime A190CCFech ,
                                             string A506CCEstado ,
                                             string A188CCCliCod ,
                                             string AV48CCCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[9];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliCod] AS CCCliCod, T1.[CCEstado], T1.[CCDocNum], T1.[CCFech], T1.[CCFecUltPago], T1.[CCVendCod], T2.[ZonCod], T1.[CCTipCod] AS CCTipCod, T1.[CCmonCod] AS CCmonCod, T2.[TipCCod], T1.[CCImpTotal], T1.[CCImpPago], T3.[TipSigno] FROM (([CLCUENTACOBRAR] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[CCCliCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod])";
         AddWhere(sWhereString, "(T1.[CCFecUltPago] > @AV36FHasta or (T1.[CCFecUltPago] = convert( DATETIME, '17530101', 112 )))");
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV36FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] <> 'A')");
         AddWhere(sWhereString, "(T1.[CCCliCod] = @AV48CCCliCod)");
         if ( ! (0==AV8TipCCod) )
         {
            AddWhere(sWhereString, "(T2.[TipCCod] = @AV8TipCCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV13TipCod)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV49ZonCod) )
         {
            AddWhere(sWhereString, "(T2.[ZonCod] = @AV49ZonCod)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV60VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV60VenCod)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CCDocNum], 1, 3) = @AV50Serie)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (0==AV55TipLetras) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] <> 'LET')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCTipCod], T1.[CCFech]";
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
               case 5 :
                     return conditional_P00907(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] );
               case 6 :
                     return conditional_P00908(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 7 :
                     return conditional_P00909(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
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
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00902;
          prmP00902 = new Object[] {
          new ParDef("@AV13TipCod",GXType.NChar,3,0)
          };
          Object[] prmP00903;
          prmP00903 = new Object[] {
          new ParDef("@AV8TipCCod",GXType.Int32,6,0)
          };
          Object[] prmP00904;
          prmP00904 = new Object[] {
          new ParDef("@AV14MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00905;
          prmP00905 = new Object[] {
          new ParDef("@AV10CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00906;
          prmP00906 = new Object[] {
          };
          Object[] prmP009010;
          prmP009010 = new Object[] {
          new ParDef("@AV37CCTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV38CCDocNum",GXType.NChar,12,0) ,
          new ParDef("@AV36FHasta",GXType.Date,8,0)
          };
          Object[] prmP00907;
          prmP00907 = new Object[] {
          new ParDef("@AV36FHasta",GXType.Date,8,0) ,
          new ParDef("@AV36FHasta",GXType.Date,8,0) ,
          new ParDef("@AV10CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV8TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV13TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV49ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV60VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV50Serie",GXType.Char,3,0)
          };
          Object[] prmP00908;
          prmP00908 = new Object[] {
          new ParDef("@AV10CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV8TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV13TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV49ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV60VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV50Serie",GXType.Char,3,0)
          };
          Object[] prmP00909;
          prmP00909 = new Object[] {
          new ParDef("@AV36FHasta",GXType.Date,8,0) ,
          new ParDef("@AV36FHasta",GXType.Date,8,0) ,
          new ParDef("@AV48CCCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV8TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV13TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV49ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV60VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV50Serie",GXType.Char,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00902", "SELECT [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipCod] = @AV13TipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00902,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00903", "SELECT [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @AV8TipCCod ORDER BY [TipCCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00903,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00904", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV14MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00904,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00905", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV10CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00905,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00906", "SELECT [MonDsc], [MonCod] FROM [CMONEDAS] ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00906,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00907", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00907,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00908", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00908,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00909", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00909,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009010", "SELECT T1.[CobTip], T1.[CobCod], T2.[CobSts], T2.[CobFec], T1.[CobDocNum], T1.[CobTipCod], T2.[CobMon], T1.[CobDTot], T1.[CobTipCam], T1.[Item] FROM ([CLCOBRANZADET] T1 INNER JOIN [CLCOBRANZA] T2 ON T2.[CobTip] = T1.[CobTip] AND T2.[CobCod] = T1.[CobCod]) WHERE (T1.[CobTipCod] = @AV37CCTipCod and T1.[CobDocNum] = @AV38CCDocNum) AND (T2.[CobFec] > @AV36FHasta) AND (T2.[CobSts] <> 'A') ORDER BY T1.[CobTipCod], T1.[CobDocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009010,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(10);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((string[]) buf[14])[0] = rslt.getString(12, 1);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(13);
                ((int[]) buf[16])[0] = rslt.getInt(14);
                ((int[]) buf[17])[0] = rslt.getInt(15);
                ((bool[]) buf[18])[0] = rslt.wasNull(15);
                ((int[]) buf[19])[0] = rslt.getInt(16);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                ((string[]) buf[21])[0] = rslt.getString(17, 20);
                ((string[]) buf[22])[0] = rslt.getString(18, 20);
                ((bool[]) buf[23])[0] = rslt.wasNull(18);
                ((string[]) buf[24])[0] = rslt.getString(19, 20);
                ((bool[]) buf[25])[0] = rslt.wasNull(19);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 12);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(10);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((string[]) buf[14])[0] = rslt.getString(12, 1);
                ((int[]) buf[15])[0] = rslt.getInt(13);
                ((int[]) buf[16])[0] = rslt.getInt(14);
                ((bool[]) buf[17])[0] = rslt.wasNull(14);
                ((int[]) buf[18])[0] = rslt.getInt(15);
                ((bool[]) buf[19])[0] = rslt.wasNull(15);
                ((string[]) buf[20])[0] = rslt.getString(16, 20);
                ((string[]) buf[21])[0] = rslt.getString(17, 20);
                ((bool[]) buf[22])[0] = rslt.wasNull(17);
                ((string[]) buf[23])[0] = rslt.getString(18, 20);
                ((bool[]) buf[24])[0] = rslt.wasNull(18);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 3);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((short[]) buf[14])[0] = rslt.getShort(13);
                ((bool[]) buf[15])[0] = rslt.wasNull(13);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                return;
       }
    }

 }

}
