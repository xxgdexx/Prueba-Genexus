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
   public class rrcuentasxcobrarexpresado : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrcuentasxcobrarexpresado.aspx")), "rrcuentasxcobrarexpresado.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrcuentasxcobrarexpresado.aspx")))) ;
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
               AV43TipCCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13CliCod = GetPar( "CliCod");
                  AV45TipCod = GetPar( "TipCod");
                  AV32MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV22FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV54ZonCod = (int)(NumberUtil.Val( GetPar( "ZonCod"), "."));
                  AV40Serie = GetPar( "Serie");
                  AV46TipLetras = (short)(NumberUtil.Val( GetPar( "TipLetras"), "."));
                  AV55VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
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

      public rrcuentasxcobrarexpresado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrcuentasxcobrarexpresado( IGxContext context )
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
         this.AV43TipCCod = aP0_TipCCod;
         this.AV13CliCod = aP1_CliCod;
         this.AV45TipCod = aP2_TipCod;
         this.AV32MonCod = aP3_MonCod;
         this.AV22FHasta = aP4_FHasta;
         this.AV54ZonCod = aP5_ZonCod;
         this.AV40Serie = aP6_Serie;
         this.AV46TipLetras = aP7_TipLetras;
         this.AV55VenCod = aP8_VenCod;
         initialize();
         executePrivate();
         aP0_TipCCod=this.AV43TipCCod;
         aP1_CliCod=this.AV13CliCod;
         aP2_TipCod=this.AV45TipCod;
         aP3_MonCod=this.AV32MonCod;
         aP4_FHasta=this.AV22FHasta;
         aP5_ZonCod=this.AV54ZonCod;
         aP6_Serie=this.AV40Serie;
         aP7_TipLetras=this.AV46TipLetras;
         aP8_VenCod=this.AV55VenCod;
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
         return AV55VenCod ;
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
         rrcuentasxcobrarexpresado objrrcuentasxcobrarexpresado;
         objrrcuentasxcobrarexpresado = new rrcuentasxcobrarexpresado();
         objrrcuentasxcobrarexpresado.AV43TipCCod = aP0_TipCCod;
         objrrcuentasxcobrarexpresado.AV13CliCod = aP1_CliCod;
         objrrcuentasxcobrarexpresado.AV45TipCod = aP2_TipCod;
         objrrcuentasxcobrarexpresado.AV32MonCod = aP3_MonCod;
         objrrcuentasxcobrarexpresado.AV22FHasta = aP4_FHasta;
         objrrcuentasxcobrarexpresado.AV54ZonCod = aP5_ZonCod;
         objrrcuentasxcobrarexpresado.AV40Serie = aP6_Serie;
         objrrcuentasxcobrarexpresado.AV46TipLetras = aP7_TipLetras;
         objrrcuentasxcobrarexpresado.AV55VenCod = aP8_VenCod;
         objrrcuentasxcobrarexpresado.context.SetSubmitInitialConfig(context);
         objrrcuentasxcobrarexpresado.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrcuentasxcobrarexpresado);
         aP0_TipCCod=this.AV43TipCCod;
         aP1_CliCod=this.AV13CliCod;
         aP2_TipCod=this.AV45TipCod;
         aP3_MonCod=this.AV32MonCod;
         aP4_FHasta=this.AV22FHasta;
         aP5_ZonCod=this.AV54ZonCod;
         aP6_Serie=this.AV40Serie;
         aP7_TipLetras=this.AV46TipLetras;
         aP8_VenCod=this.AV55VenCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrcuentasxcobrarexpresado)stateInfo).executePrivate();
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
            AV19Empresa = AV41Session.Get("Empresa");
            AV18EmpDir = AV41Session.Get("EmpDir");
            AV20EmpRUC = AV41Session.Get("EmpRUC");
            AV36Ruta = AV41Session.Get("RUTA") + "/Logo.jpg";
            AV31Logo = AV36Ruta;
            AV58Logo_GXI = GXDbFile.PathToUrl( AV36Ruta);
            AV23Filtro1 = "Todos";
            AV24Filtro2 = "Todos";
            AV25Filtro3 = "Todos";
            AV26Filtro4 = "Todos";
            /* Using cursor P00E92 */
            pr_default.execute(0, new Object[] {AV45TipCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A149TipCod = P00E92_A149TipCod[0];
               A1910TipDsc = P00E92_A1910TipDsc[0];
               AV23Filtro1 = A1910TipDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00E93 */
            pr_default.execute(1, new Object[] {AV43TipCCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A159TipCCod = P00E93_A159TipCCod[0];
               n159TipCCod = P00E93_n159TipCCod[0];
               A1905TipCDsc = P00E93_A1905TipCDsc[0];
               AV24Filtro2 = A1905TipCDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00E94 */
            pr_default.execute(2, new Object[] {AV32MonCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A180MonCod = P00E94_A180MonCod[0];
               A1234MonDsc = P00E94_A1234MonDsc[0];
               n1234MonDsc = P00E94_n1234MonDsc[0];
               AV25Filtro3 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P00E95 */
            pr_default.execute(3, new Object[] {AV13CliCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A45CliCod = P00E95_A45CliCod[0];
               A161CliDsc = P00E95_A161CliDsc[0];
               AV26Filtro4 = A161CliDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            AV48TotGSaldo = 0.00m;
            AV49TotGSaldoExp = 0.00m;
            if ( DateTimeUtil.ResetTime ( AV22FHasta ) == DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
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
            HE90( false, 28) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48TotGSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+9, 670, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49TotGSaldoExp, "ZZZZZZ,ZZZ,ZZ9.99")), 680, Gx_line+9, 785, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(565, Gx_line+4, 787, Gx_line+4, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 360, Gx_line+10, 440, Gx_line+24, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+28);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HE90( true, 0) ;
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
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV13CliCod ,
                                              AV43TipCCod ,
                                              AV45TipCod ,
                                              AV54ZonCod ,
                                              AV55VenCod ,
                                              AV40Serie ,
                                              AV46TipLetras ,
                                              A188CCCliCod ,
                                              A159TipCCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A186CCVendCod ,
                                              A185CCDocNum ,
                                              A507CCFecUltPago ,
                                              AV22FHasta ,
                                              A190CCFech ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00E96 */
         pr_default.execute(4, new Object[] {AV22FHasta, AV22FHasta, AV13CliCod, AV43TipCCod, AV45TipCod, AV54ZonCod, AV55VenCod, AV40Serie});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKE97 = false;
            A189CCCliDsc = P00E96_A189CCCliDsc[0];
            A185CCDocNum = P00E96_A185CCDocNum[0];
            A511TipSigno = P00E96_A511TipSigno[0];
            n511TipSigno = P00E96_n511TipSigno[0];
            A513CCImpTotal = P00E96_A513CCImpTotal[0];
            A509CCImpPago = P00E96_A509CCImpPago[0];
            A187CCmonCod = P00E96_A187CCmonCod[0];
            A508CCFVcto = P00E96_A508CCFVcto[0];
            A1234MonDsc = P00E96_A1234MonDsc[0];
            n1234MonDsc = P00E96_n1234MonDsc[0];
            A306TipAbr = P00E96_A306TipAbr[0];
            n306TipAbr = P00E96_n306TipAbr[0];
            A190CCFech = P00E96_A190CCFech[0];
            A184CCTipCod = P00E96_A184CCTipCod[0];
            A506CCEstado = P00E96_A506CCEstado[0];
            A507CCFecUltPago = P00E96_A507CCFecUltPago[0];
            A186CCVendCod = P00E96_A186CCVendCod[0];
            A158ZonCod = P00E96_A158ZonCod[0];
            n158ZonCod = P00E96_n158ZonCod[0];
            A159TipCCod = P00E96_A159TipCCod[0];
            n159TipCCod = P00E96_n159TipCCod[0];
            A188CCCliCod = P00E96_A188CCCliCod[0];
            A630CliTel2 = P00E96_A630CliTel2[0];
            n630CliTel2 = P00E96_n630CliTel2[0];
            A629CliTel1 = P00E96_A629CliTel1[0];
            n629CliTel1 = P00E96_n629CliTel1[0];
            A1234MonDsc = P00E96_A1234MonDsc[0];
            n1234MonDsc = P00E96_n1234MonDsc[0];
            A511TipSigno = P00E96_A511TipSigno[0];
            n511TipSigno = P00E96_n511TipSigno[0];
            A306TipAbr = P00E96_A306TipAbr[0];
            n306TipAbr = P00E96_n306TipAbr[0];
            A158ZonCod = P00E96_A158ZonCod[0];
            n158ZonCod = P00E96_n158ZonCod[0];
            A159TipCCod = P00E96_A159TipCCod[0];
            n159TipCCod = P00E96_n159TipCCod[0];
            A630CliTel2 = P00E96_A630CliTel2[0];
            n630CliTel2 = P00E96_n630CliTel2[0];
            A629CliTel1 = P00E96_A629CliTel1[0];
            n629CliTel1 = P00E96_n629CliTel1[0];
            AV8CCCliCod = StringUtil.Trim( A188CCCliCod);
            AV14CliDsc = StringUtil.Trim( A188CCCliCod) + " - " + StringUtil.Trim( A189CCCliDsc);
            AV42Telf = "Telf : " + StringUtil.Trim( A629CliTel1) + (!String.IsNullOrEmpty(StringUtil.RTrim( A630CliTel2)) ? " / "+StringUtil.Trim( A630CliTel2) : "");
            /* Execute user subroutine: 'VALIDAMOV' */
            S127 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            if ( AV27Flag == 1 )
            {
               HE90( false, 21) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14CliDsc, "")), 8, Gx_line+3, 434, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42Telf, "")), 457, Gx_line+3, 718, Gx_line+18, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
            }
            AV52TotSaldo = 0.00m;
            AV53TotSaldoExp = 0.00m;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00E96_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRKE97 = false;
               A185CCDocNum = P00E96_A185CCDocNum[0];
               A511TipSigno = P00E96_A511TipSigno[0];
               n511TipSigno = P00E96_n511TipSigno[0];
               A513CCImpTotal = P00E96_A513CCImpTotal[0];
               A509CCImpPago = P00E96_A509CCImpPago[0];
               A187CCmonCod = P00E96_A187CCmonCod[0];
               A508CCFVcto = P00E96_A508CCFVcto[0];
               A1234MonDsc = P00E96_A1234MonDsc[0];
               n1234MonDsc = P00E96_n1234MonDsc[0];
               A306TipAbr = P00E96_A306TipAbr[0];
               n306TipAbr = P00E96_n306TipAbr[0];
               A190CCFech = P00E96_A190CCFech[0];
               A184CCTipCod = P00E96_A184CCTipCod[0];
               A1234MonDsc = P00E96_A1234MonDsc[0];
               n1234MonDsc = P00E96_n1234MonDsc[0];
               A511TipSigno = P00E96_A511TipSigno[0];
               n511TipSigno = P00E96_n511TipSigno[0];
               A306TipAbr = P00E96_A306TipAbr[0];
               n306TipAbr = P00E96_n306TipAbr[0];
               AV12CCTipCod = A184CCTipCod;
               AV9CCDocNum = A185CCDocNum;
               AV29Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV34Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV28ImpDoc = A513CCImpTotal;
               AV33PagoDoc = A509CCImpPago;
               AV11CCmonCod = A187CCmonCod;
               AV10CCFech = A190CCFech;
               AV38SaldoExp = 0;
               /* Execute user subroutine: 'PAGOS' */
               S138 ();
               if ( returnInSub )
               {
                  pr_default.close(4);
                  returnInSub = true;
                  if (true) return;
               }
               if ( ( AV33PagoDoc < Convert.ToDecimal( 0 )) )
               {
                  AV34Pagos = 0;
                  AV33PagoDoc = 0;
               }
               AV29Importe = (decimal)(AV28ImpDoc*A511TipSigno);
               AV34Pagos = (decimal)(AV33PagoDoc*A511TipSigno);
               AV37Saldo = (decimal)((AV28ImpDoc-AV33PagoDoc)*A511TipSigno);
               GXt_decimal1 = AV44TipCmb;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV10CCFech, ref  GXt_char3, out  GXt_decimal1) ;
               GXt_decimal4 = AV44TipCmb;
               GXt_int5 = 2;
               GXt_char6 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int5, ref  AV10CCFech, ref  GXt_char6, out  GXt_decimal4) ;
               AV44TipCmb = ((AV11CCmonCod==AV32MonCod) ? (decimal)(1) : GXt_decimal4);
               AV47TipoCambio = ((AV11CCmonCod==AV32MonCod) ? "" : StringUtil.Trim( StringUtil.Str( AV44TipCmb, 10, 4)));
               AV38SaldoExp = ((AV11CCmonCod==AV32MonCod) ? AV37Saldo : ((AV11CCmonCod==1) ? NumberUtil.Round( AV37Saldo/ (decimal)(AV44TipCmb), 2) : NumberUtil.Round( AV37Saldo/ (decimal)(AV44TipCmb), 2)));
               AV17Dias = (int)(DateTimeUtil.DDiff(AV22FHasta,A508CCFVcto));
               if ( ( AV37Saldo != Convert.ToDecimal( 0 )) )
               {
                  AV52TotSaldo = (decimal)(AV52TotSaldo+AV37Saldo);
                  AV53TotSaldoExp = (decimal)(AV53TotSaldoExp+AV38SaldoExp);
                  HE90( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A185CCDocNum, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A190CCFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A508CCFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 383, Gx_line+2, 508, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 574, Gx_line+2, 671, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38SaldoExp, "ZZZZZZ,ZZZ,ZZ9.99")), 681, Gx_line+2, 786, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17Dias), "ZZZZ9")), 308, Gx_line+2, 365, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TipoCambio, "")), 512, Gx_line+2, 562, Gx_line+17, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
               }
               BRKE97 = true;
               pr_default.readNext(4);
            }
            if ( ( AV52TotSaldo != Convert.ToDecimal( 0 )) )
            {
               HE90( false, 24) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 574, Gx_line+6, 671, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TotSaldoExp, "ZZZZZZ,ZZZ,ZZ9.99")), 681, Gx_line+6, 786, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(565, Gx_line+1, 787, Gx_line+1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Cliente", 349, Gx_line+6, 424, Gx_line+20, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
            }
            AV48TotGSaldo = (decimal)(AV48TotGSaldo+AV52TotSaldo);
            AV49TotGSaldoExp = (decimal)(AV49TotGSaldoExp+AV53TotSaldoExp);
            if ( ! BRKE97 )
            {
               BRKE97 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S141( )
      {
         /* 'CUENTACOBRAR' Routine */
         returnInSub = false;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV13CliCod ,
                                              AV43TipCCod ,
                                              AV45TipCod ,
                                              AV54ZonCod ,
                                              AV55VenCod ,
                                              AV40Serie ,
                                              AV46TipLetras ,
                                              A188CCCliCod ,
                                              A159TipCCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A186CCVendCod ,
                                              A185CCDocNum ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P00E97 */
         pr_default.execute(5, new Object[] {AV13CliCod, AV43TipCCod, AV45TipCod, AV54ZonCod, AV55VenCod, AV40Serie});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKE99 = false;
            A189CCCliDsc = P00E97_A189CCCliDsc[0];
            A511TipSigno = P00E97_A511TipSigno[0];
            n511TipSigno = P00E97_n511TipSigno[0];
            A513CCImpTotal = P00E97_A513CCImpTotal[0];
            A509CCImpPago = P00E97_A509CCImpPago[0];
            A187CCmonCod = P00E97_A187CCmonCod[0];
            A508CCFVcto = P00E97_A508CCFVcto[0];
            A1234MonDsc = P00E97_A1234MonDsc[0];
            n1234MonDsc = P00E97_n1234MonDsc[0];
            A185CCDocNum = P00E97_A185CCDocNum[0];
            A306TipAbr = P00E97_A306TipAbr[0];
            n306TipAbr = P00E97_n306TipAbr[0];
            A190CCFech = P00E97_A190CCFech[0];
            A184CCTipCod = P00E97_A184CCTipCod[0];
            A506CCEstado = P00E97_A506CCEstado[0];
            A186CCVendCod = P00E97_A186CCVendCod[0];
            A158ZonCod = P00E97_A158ZonCod[0];
            n158ZonCod = P00E97_n158ZonCod[0];
            A159TipCCod = P00E97_A159TipCCod[0];
            n159TipCCod = P00E97_n159TipCCod[0];
            A188CCCliCod = P00E97_A188CCCliCod[0];
            A630CliTel2 = P00E97_A630CliTel2[0];
            n630CliTel2 = P00E97_n630CliTel2[0];
            A629CliTel1 = P00E97_A629CliTel1[0];
            n629CliTel1 = P00E97_n629CliTel1[0];
            A1234MonDsc = P00E97_A1234MonDsc[0];
            n1234MonDsc = P00E97_n1234MonDsc[0];
            A511TipSigno = P00E97_A511TipSigno[0];
            n511TipSigno = P00E97_n511TipSigno[0];
            A306TipAbr = P00E97_A306TipAbr[0];
            n306TipAbr = P00E97_n306TipAbr[0];
            A158ZonCod = P00E97_A158ZonCod[0];
            n158ZonCod = P00E97_n158ZonCod[0];
            A159TipCCod = P00E97_A159TipCCod[0];
            n159TipCCod = P00E97_n159TipCCod[0];
            A630CliTel2 = P00E97_A630CliTel2[0];
            n630CliTel2 = P00E97_n630CliTel2[0];
            A629CliTel1 = P00E97_A629CliTel1[0];
            n629CliTel1 = P00E97_n629CliTel1[0];
            AV8CCCliCod = A188CCCliCod;
            AV14CliDsc = StringUtil.Trim( A188CCCliCod) + " - " + StringUtil.Trim( A189CCCliDsc);
            AV42Telf = "Telf : " + StringUtil.Trim( A629CliTel1) + (!String.IsNullOrEmpty(StringUtil.RTrim( A630CliTel2)) ? " / "+StringUtil.Trim( A630CliTel2) : "");
            HE90( false, 21) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14CliDsc, "")), 8, Gx_line+3, 434, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42Telf, "")), 457, Gx_line+3, 718, Gx_line+18, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+21);
            AV52TotSaldo = 0.00m;
            AV53TotSaldoExp = 0.00m;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00E97_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRKE99 = false;
               A511TipSigno = P00E97_A511TipSigno[0];
               n511TipSigno = P00E97_n511TipSigno[0];
               A513CCImpTotal = P00E97_A513CCImpTotal[0];
               A509CCImpPago = P00E97_A509CCImpPago[0];
               A187CCmonCod = P00E97_A187CCmonCod[0];
               A508CCFVcto = P00E97_A508CCFVcto[0];
               A1234MonDsc = P00E97_A1234MonDsc[0];
               n1234MonDsc = P00E97_n1234MonDsc[0];
               A185CCDocNum = P00E97_A185CCDocNum[0];
               A306TipAbr = P00E97_A306TipAbr[0];
               n306TipAbr = P00E97_n306TipAbr[0];
               A190CCFech = P00E97_A190CCFech[0];
               A184CCTipCod = P00E97_A184CCTipCod[0];
               A1234MonDsc = P00E97_A1234MonDsc[0];
               n1234MonDsc = P00E97_n1234MonDsc[0];
               A511TipSigno = P00E97_A511TipSigno[0];
               n511TipSigno = P00E97_n511TipSigno[0];
               A306TipAbr = P00E97_A306TipAbr[0];
               n306TipAbr = P00E97_n306TipAbr[0];
               AV29Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV34Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV11CCmonCod = A187CCmonCod;
               AV37Saldo = (decimal)((A513CCImpTotal-A509CCImpPago)*A511TipSigno);
               AV17Dias = (int)(DateTimeUtil.DDiff(AV22FHasta,A508CCFVcto));
               AV10CCFech = A190CCFech;
               GXt_decimal4 = AV44TipCmb;
               GXt_int5 = 2;
               GXt_char6 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int5, ref  AV10CCFech, ref  GXt_char6, out  GXt_decimal4) ;
               GXt_decimal1 = AV44TipCmb;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV10CCFech, ref  GXt_char3, out  GXt_decimal1) ;
               AV44TipCmb = ((AV11CCmonCod==AV32MonCod) ? (decimal)(1) : GXt_decimal1);
               AV47TipoCambio = ((AV11CCmonCod==AV32MonCod) ? "" : StringUtil.Trim( StringUtil.Str( AV44TipCmb, 10, 4)));
               AV38SaldoExp = ((AV11CCmonCod==AV32MonCod) ? AV37Saldo : ((AV11CCmonCod==1) ? NumberUtil.Round( AV37Saldo/ (decimal)(AV44TipCmb), 2) : NumberUtil.Round( AV37Saldo/ (decimal)(AV44TipCmb), 2)));
               AV52TotSaldo = (decimal)(AV52TotSaldo+AV37Saldo);
               AV53TotSaldoExp = (decimal)(AV53TotSaldoExp+AV38SaldoExp);
               HE90( false, 18) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A185CCDocNum, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A190CCFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A508CCFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 383, Gx_line+2, 508, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 574, Gx_line+2, 671, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38SaldoExp, "ZZZZZZ,ZZZ,ZZ9.99")), 681, Gx_line+2, 786, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17Dias), "ZZZZ9")), 308, Gx_line+2, 365, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TipoCambio, "")), 512, Gx_line+2, 562, Gx_line+17, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               BRKE99 = true;
               pr_default.readNext(5);
            }
            HE90( false, 24) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 574, Gx_line+6, 671, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TotSaldoExp, "ZZZZZZ,ZZZ,ZZ9.99")), 681, Gx_line+6, 786, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(565, Gx_line+1, 787, Gx_line+1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Cliente", 349, Gx_line+6, 424, Gx_line+20, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+24);
            AV48TotGSaldo = (decimal)(AV48TotGSaldo+AV52TotSaldo);
            AV49TotGSaldoExp = (decimal)(AV49TotGSaldoExp+AV53TotSaldoExp);
            if ( ! BRKE99 )
            {
               BRKE99 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S127( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         AV27Flag = 0;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV43TipCCod ,
                                              AV45TipCod ,
                                              AV54ZonCod ,
                                              AV55VenCod ,
                                              AV40Serie ,
                                              AV46TipLetras ,
                                              A159TipCCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A186CCVendCod ,
                                              A185CCDocNum ,
                                              A507CCFecUltPago ,
                                              AV22FHasta ,
                                              A190CCFech ,
                                              A506CCEstado ,
                                              A188CCCliCod ,
                                              AV8CCCliCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00E98 */
         pr_default.execute(6, new Object[] {AV22FHasta, AV22FHasta, AV8CCCliCod, AV43TipCCod, AV45TipCod, AV54ZonCod, AV55VenCod, AV40Serie});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A188CCCliCod = P00E98_A188CCCliCod[0];
            A506CCEstado = P00E98_A506CCEstado[0];
            A185CCDocNum = P00E98_A185CCDocNum[0];
            A190CCFech = P00E98_A190CCFech[0];
            A507CCFecUltPago = P00E98_A507CCFecUltPago[0];
            A186CCVendCod = P00E98_A186CCVendCod[0];
            A158ZonCod = P00E98_A158ZonCod[0];
            n158ZonCod = P00E98_n158ZonCod[0];
            A184CCTipCod = P00E98_A184CCTipCod[0];
            A159TipCCod = P00E98_A159TipCCod[0];
            n159TipCCod = P00E98_n159TipCCod[0];
            A513CCImpTotal = P00E98_A513CCImpTotal[0];
            A187CCmonCod = P00E98_A187CCmonCod[0];
            A509CCImpPago = P00E98_A509CCImpPago[0];
            A511TipSigno = P00E98_A511TipSigno[0];
            n511TipSigno = P00E98_n511TipSigno[0];
            A158ZonCod = P00E98_A158ZonCod[0];
            n158ZonCod = P00E98_n158ZonCod[0];
            A159TipCCod = P00E98_A159TipCCod[0];
            n159TipCCod = P00E98_n159TipCCod[0];
            A511TipSigno = P00E98_A511TipSigno[0];
            n511TipSigno = P00E98_n511TipSigno[0];
            AV12CCTipCod = A184CCTipCod;
            AV9CCDocNum = A185CCDocNum;
            AV29Importe = A513CCImpTotal;
            AV11CCmonCod = A187CCmonCod;
            AV33PagoDoc = A509CCImpPago;
            /* Execute user subroutine: 'PAGOS' */
            S138 ();
            if ( returnInSub )
            {
               pr_default.close(6);
               returnInSub = true;
               if (true) return;
            }
            if ( ( AV33PagoDoc < Convert.ToDecimal( 0 )) )
            {
               AV33PagoDoc = 0;
            }
            AV30ImporteVal = (decimal)(AV29Importe*A511TipSigno);
            AV35PagosVal = (decimal)(AV33PagoDoc*A511TipSigno);
            AV39SaldoVal = (decimal)((AV29Importe-AV33PagoDoc)*A511TipSigno);
            if ( ( AV39SaldoVal != Convert.ToDecimal( 0 )) )
            {
               AV27Flag = 1;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S138( )
      {
         /* 'PAGOS' Routine */
         returnInSub = false;
         /* Using cursor P00E99 */
         pr_default.execute(7, new Object[] {AV12CCTipCod, AV9CCDocNum, AV22FHasta});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A166CobTip = P00E99_A166CobTip[0];
            A167CobCod = P00E99_A167CobCod[0];
            A661CobSts = P00E99_A661CobSts[0];
            A655CobFec = P00E99_A655CobFec[0];
            A176CobDocNum = P00E99_A176CobDocNum[0];
            A175CobTipCod = P00E99_A175CobTipCod[0];
            A172CobMon = P00E99_A172CobMon[0];
            A654CobDTot = P00E99_A654CobDTot[0];
            A663CobTipCam = P00E99_A663CobTipCam[0];
            A173Item = P00E99_A173Item[0];
            A661CobSts = P00E99_A661CobSts[0];
            A655CobFec = P00E99_A655CobFec[0];
            A172CobMon = P00E99_A172CobMon[0];
            AV16CobMon = A172CobMon;
            AV15CobDtot = NumberUtil.Round( A654CobDTot, 2);
            if ( ( AV15CobDtot < Convert.ToDecimal( 0 )) )
            {
               AV15CobDtot = (decimal)(AV15CobDtot*-1);
            }
            if ( AV11CCmonCod == AV16CobMon )
            {
               AV33PagoDoc = (decimal)(AV33PagoDoc-AV15CobDtot);
            }
            else
            {
               if ( AV11CCmonCod == 1 )
               {
                  AV33PagoDoc = (decimal)(AV33PagoDoc-(NumberUtil.Round( AV15CobDtot*A663CobTipCam, 2)));
               }
               else
               {
                  AV33PagoDoc = (decimal)(AV33PagoDoc-(NumberUtil.Round( AV15CobDtot/ (decimal)(A663CobTipCam), 2)));
               }
            }
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void HE90( bool bFoot ,
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
               getPrinter().GxDrawText("T/D", 14, Gx_line+201, 37, Gx_line+215, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Documento", 71, Gx_line+201, 156, Gx_line+215, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dias Vcto", 324, Gx_line+201, 379, Gx_line+215, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mon Origen.", 397, Gx_line+201, 468, Gx_line+215, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo Origen", 592, Gx_line+201, 667, Gx_line+215, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+195, 797, Gx_line+221, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuentas por Cobrar Expresado en : ", 266, Gx_line+70, 568, Gx_line+90, 1+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 174, Gx_line+201, 209, Gx_line+215, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Vcto", 236, Gx_line+201, 301, Gx_line+215, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo Expresado", 685, Gx_line+201, 783, Gx_line+215, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Documento", 192, Gx_line+148, 307, Gx_line+162, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Cliente", 192, Gx_line+170, 279, Gx_line+184, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro1, "")), 309, Gx_line+143, 652, Gx_line+167, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro2, "")), 309, Gx_line+165, 652, Gx_line+189, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18EmpDir, "")), 19, Gx_line+29, 404, Gx_line+47, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20EmpRUC, "")), 19, Gx_line+46, 404, Gx_line+64, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Empresa, "")), 19, Gx_line+11, 404, Gx_line+29, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 340, Gx_line+111, 370, Gx_line+131, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV22FHasta, "99/99/99"), 379, Gx_line+111, 461, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Filtro3, "")), 266, Gx_line+90, 569, Gx_line+111, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T.C.", 528, Gx_line+201, 550, Gx_line+215, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+221);
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
         AV19Empresa = "";
         AV41Session = context.GetSession();
         AV18EmpDir = "";
         AV20EmpRUC = "";
         AV36Ruta = "";
         AV31Logo = "";
         AV58Logo_GXI = "";
         AV23Filtro1 = "";
         AV24Filtro2 = "";
         AV25Filtro3 = "";
         AV26Filtro4 = "";
         scmdbuf = "";
         P00E92_A149TipCod = new string[] {""} ;
         P00E92_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         P00E93_A159TipCCod = new int[1] ;
         P00E93_n159TipCCod = new bool[] {false} ;
         P00E93_A1905TipCDsc = new string[] {""} ;
         A1905TipCDsc = "";
         P00E94_A180MonCod = new int[1] ;
         P00E94_A1234MonDsc = new string[] {""} ;
         P00E94_n1234MonDsc = new bool[] {false} ;
         A1234MonDsc = "";
         P00E95_A45CliCod = new string[] {""} ;
         P00E95_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         A188CCCliCod = "";
         A184CCTipCod = "";
         A185CCDocNum = "";
         A507CCFecUltPago = DateTime.MinValue;
         A190CCFech = DateTime.MinValue;
         A506CCEstado = "";
         P00E96_A189CCCliDsc = new string[] {""} ;
         P00E96_A185CCDocNum = new string[] {""} ;
         P00E96_A511TipSigno = new short[1] ;
         P00E96_n511TipSigno = new bool[] {false} ;
         P00E96_A513CCImpTotal = new decimal[1] ;
         P00E96_A509CCImpPago = new decimal[1] ;
         P00E96_A187CCmonCod = new int[1] ;
         P00E96_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00E96_A1234MonDsc = new string[] {""} ;
         P00E96_n1234MonDsc = new bool[] {false} ;
         P00E96_A306TipAbr = new string[] {""} ;
         P00E96_n306TipAbr = new bool[] {false} ;
         P00E96_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00E96_A184CCTipCod = new string[] {""} ;
         P00E96_A506CCEstado = new string[] {""} ;
         P00E96_A507CCFecUltPago = new DateTime[] {DateTime.MinValue} ;
         P00E96_A186CCVendCod = new int[1] ;
         P00E96_A158ZonCod = new int[1] ;
         P00E96_n158ZonCod = new bool[] {false} ;
         P00E96_A159TipCCod = new int[1] ;
         P00E96_n159TipCCod = new bool[] {false} ;
         P00E96_A188CCCliCod = new string[] {""} ;
         P00E96_A630CliTel2 = new string[] {""} ;
         P00E96_n630CliTel2 = new bool[] {false} ;
         P00E96_A629CliTel1 = new string[] {""} ;
         P00E96_n629CliTel1 = new bool[] {false} ;
         A189CCCliDsc = "";
         A508CCFVcto = DateTime.MinValue;
         A306TipAbr = "";
         A630CliTel2 = "";
         A629CliTel1 = "";
         AV8CCCliCod = "";
         AV14CliDsc = "";
         AV42Telf = "";
         AV12CCTipCod = "";
         AV9CCDocNum = "";
         AV10CCFech = DateTime.MinValue;
         AV47TipoCambio = "";
         P00E97_A189CCCliDsc = new string[] {""} ;
         P00E97_A511TipSigno = new short[1] ;
         P00E97_n511TipSigno = new bool[] {false} ;
         P00E97_A513CCImpTotal = new decimal[1] ;
         P00E97_A509CCImpPago = new decimal[1] ;
         P00E97_A187CCmonCod = new int[1] ;
         P00E97_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00E97_A1234MonDsc = new string[] {""} ;
         P00E97_n1234MonDsc = new bool[] {false} ;
         P00E97_A185CCDocNum = new string[] {""} ;
         P00E97_A306TipAbr = new string[] {""} ;
         P00E97_n306TipAbr = new bool[] {false} ;
         P00E97_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00E97_A184CCTipCod = new string[] {""} ;
         P00E97_A506CCEstado = new string[] {""} ;
         P00E97_A186CCVendCod = new int[1] ;
         P00E97_A158ZonCod = new int[1] ;
         P00E97_n158ZonCod = new bool[] {false} ;
         P00E97_A159TipCCod = new int[1] ;
         P00E97_n159TipCCod = new bool[] {false} ;
         P00E97_A188CCCliCod = new string[] {""} ;
         P00E97_A630CliTel2 = new string[] {""} ;
         P00E97_n630CliTel2 = new bool[] {false} ;
         P00E97_A629CliTel1 = new string[] {""} ;
         P00E97_n629CliTel1 = new bool[] {false} ;
         GXt_char6 = "";
         GXt_char3 = "";
         P00E98_A188CCCliCod = new string[] {""} ;
         P00E98_A506CCEstado = new string[] {""} ;
         P00E98_A185CCDocNum = new string[] {""} ;
         P00E98_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00E98_A507CCFecUltPago = new DateTime[] {DateTime.MinValue} ;
         P00E98_A186CCVendCod = new int[1] ;
         P00E98_A158ZonCod = new int[1] ;
         P00E98_n158ZonCod = new bool[] {false} ;
         P00E98_A184CCTipCod = new string[] {""} ;
         P00E98_A159TipCCod = new int[1] ;
         P00E98_n159TipCCod = new bool[] {false} ;
         P00E98_A513CCImpTotal = new decimal[1] ;
         P00E98_A187CCmonCod = new int[1] ;
         P00E98_A509CCImpPago = new decimal[1] ;
         P00E98_A511TipSigno = new short[1] ;
         P00E98_n511TipSigno = new bool[] {false} ;
         P00E99_A166CobTip = new string[] {""} ;
         P00E99_A167CobCod = new string[] {""} ;
         P00E99_A661CobSts = new string[] {""} ;
         P00E99_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         P00E99_A176CobDocNum = new string[] {""} ;
         P00E99_A175CobTipCod = new string[] {""} ;
         P00E99_A172CobMon = new int[1] ;
         P00E99_A654CobDTot = new decimal[1] ;
         P00E99_A663CobTipCam = new decimal[1] ;
         P00E99_A173Item = new int[1] ;
         A166CobTip = "";
         A167CobCod = "";
         A661CobSts = "";
         A655CobFec = DateTime.MinValue;
         A176CobDocNum = "";
         A175CobTipCod = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrcuentasxcobrarexpresado__default(),
            new Object[][] {
                new Object[] {
               P00E92_A149TipCod, P00E92_A1910TipDsc
               }
               , new Object[] {
               P00E93_A159TipCCod, P00E93_A1905TipCDsc
               }
               , new Object[] {
               P00E94_A180MonCod, P00E94_A1234MonDsc
               }
               , new Object[] {
               P00E95_A45CliCod, P00E95_A161CliDsc
               }
               , new Object[] {
               P00E96_A189CCCliDsc, P00E96_A185CCDocNum, P00E96_A511TipSigno, P00E96_n511TipSigno, P00E96_A513CCImpTotal, P00E96_A509CCImpPago, P00E96_A187CCmonCod, P00E96_A508CCFVcto, P00E96_A1234MonDsc, P00E96_n1234MonDsc,
               P00E96_A306TipAbr, P00E96_n306TipAbr, P00E96_A190CCFech, P00E96_A184CCTipCod, P00E96_A506CCEstado, P00E96_A507CCFecUltPago, P00E96_A186CCVendCod, P00E96_A158ZonCod, P00E96_n158ZonCod, P00E96_A159TipCCod,
               P00E96_n159TipCCod, P00E96_A188CCCliCod, P00E96_A630CliTel2, P00E96_n630CliTel2, P00E96_A629CliTel1, P00E96_n629CliTel1
               }
               , new Object[] {
               P00E97_A189CCCliDsc, P00E97_A511TipSigno, P00E97_n511TipSigno, P00E97_A513CCImpTotal, P00E97_A509CCImpPago, P00E97_A187CCmonCod, P00E97_A508CCFVcto, P00E97_A1234MonDsc, P00E97_n1234MonDsc, P00E97_A185CCDocNum,
               P00E97_A306TipAbr, P00E97_n306TipAbr, P00E97_A190CCFech, P00E97_A184CCTipCod, P00E97_A506CCEstado, P00E97_A186CCVendCod, P00E97_A158ZonCod, P00E97_n158ZonCod, P00E97_A159TipCCod, P00E97_n159TipCCod,
               P00E97_A188CCCliCod, P00E97_A630CliTel2, P00E97_n630CliTel2, P00E97_A629CliTel1, P00E97_n629CliTel1
               }
               , new Object[] {
               P00E98_A188CCCliCod, P00E98_A506CCEstado, P00E98_A185CCDocNum, P00E98_A190CCFech, P00E98_A507CCFecUltPago, P00E98_A186CCVendCod, P00E98_A158ZonCod, P00E98_n158ZonCod, P00E98_A184CCTipCod, P00E98_A159TipCCod,
               P00E98_n159TipCCod, P00E98_A513CCImpTotal, P00E98_A187CCmonCod, P00E98_A509CCImpPago, P00E98_A511TipSigno, P00E98_n511TipSigno
               }
               , new Object[] {
               P00E99_A166CobTip, P00E99_A167CobCod, P00E99_A661CobSts, P00E99_A655CobFec, P00E99_A176CobDocNum, P00E99_A175CobTipCod, P00E99_A172CobMon, P00E99_A654CobDTot, P00E99_A663CobTipCam, P00E99_A173Item
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
      private short AV46TipLetras ;
      private short A511TipSigno ;
      private short AV27Flag ;
      private int AV43TipCCod ;
      private int AV32MonCod ;
      private int AV54ZonCod ;
      private int AV55VenCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A159TipCCod ;
      private int A180MonCod ;
      private int Gx_OldLine ;
      private int A158ZonCod ;
      private int A186CCVendCod ;
      private int A187CCmonCod ;
      private int AV11CCmonCod ;
      private int AV17Dias ;
      private int GXt_int5 ;
      private int GXt_int2 ;
      private int A172CobMon ;
      private int A173Item ;
      private int AV16CobMon ;
      private decimal AV48TotGSaldo ;
      private decimal AV49TotGSaldoExp ;
      private decimal A513CCImpTotal ;
      private decimal A509CCImpPago ;
      private decimal AV52TotSaldo ;
      private decimal AV53TotSaldoExp ;
      private decimal AV29Importe ;
      private decimal AV34Pagos ;
      private decimal AV28ImpDoc ;
      private decimal AV33PagoDoc ;
      private decimal AV38SaldoExp ;
      private decimal AV37Saldo ;
      private decimal AV44TipCmb ;
      private decimal GXt_decimal4 ;
      private decimal GXt_decimal1 ;
      private decimal AV30ImporteVal ;
      private decimal AV35PagosVal ;
      private decimal AV39SaldoVal ;
      private decimal A654CobDTot ;
      private decimal A663CobTipCam ;
      private decimal AV15CobDtot ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV13CliCod ;
      private string AV45TipCod ;
      private string AV40Serie ;
      private string AV19Empresa ;
      private string AV18EmpDir ;
      private string AV20EmpRUC ;
      private string AV36Ruta ;
      private string AV23Filtro1 ;
      private string AV24Filtro2 ;
      private string AV25Filtro3 ;
      private string AV26Filtro4 ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private string A1905TipCDsc ;
      private string A1234MonDsc ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A188CCCliCod ;
      private string A184CCTipCod ;
      private string A185CCDocNum ;
      private string A506CCEstado ;
      private string A189CCCliDsc ;
      private string A306TipAbr ;
      private string A630CliTel2 ;
      private string A629CliTel1 ;
      private string AV8CCCliCod ;
      private string AV14CliDsc ;
      private string AV12CCTipCod ;
      private string AV9CCDocNum ;
      private string AV47TipoCambio ;
      private string GXt_char6 ;
      private string GXt_char3 ;
      private string A166CobTip ;
      private string A167CobCod ;
      private string A661CobSts ;
      private string A176CobDocNum ;
      private string A175CobTipCod ;
      private string Gx_time ;
      private DateTime AV22FHasta ;
      private DateTime A507CCFecUltPago ;
      private DateTime A190CCFech ;
      private DateTime A508CCFVcto ;
      private DateTime AV10CCFech ;
      private DateTime A655CobFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n159TipCCod ;
      private bool n1234MonDsc ;
      private bool returnInSub ;
      private bool BRKE97 ;
      private bool n511TipSigno ;
      private bool n306TipAbr ;
      private bool n158ZonCod ;
      private bool n630CliTel2 ;
      private bool n629CliTel1 ;
      private bool BRKE99 ;
      private string AV58Logo_GXI ;
      private string AV42Telf ;
      private string AV31Logo ;
      private IGxSession AV41Session ;
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
      private string[] P00E92_A149TipCod ;
      private string[] P00E92_A1910TipDsc ;
      private int[] P00E93_A159TipCCod ;
      private bool[] P00E93_n159TipCCod ;
      private string[] P00E93_A1905TipCDsc ;
      private int[] P00E94_A180MonCod ;
      private string[] P00E94_A1234MonDsc ;
      private bool[] P00E94_n1234MonDsc ;
      private string[] P00E95_A45CliCod ;
      private string[] P00E95_A161CliDsc ;
      private string[] P00E96_A189CCCliDsc ;
      private string[] P00E96_A185CCDocNum ;
      private short[] P00E96_A511TipSigno ;
      private bool[] P00E96_n511TipSigno ;
      private decimal[] P00E96_A513CCImpTotal ;
      private decimal[] P00E96_A509CCImpPago ;
      private int[] P00E96_A187CCmonCod ;
      private DateTime[] P00E96_A508CCFVcto ;
      private string[] P00E96_A1234MonDsc ;
      private bool[] P00E96_n1234MonDsc ;
      private string[] P00E96_A306TipAbr ;
      private bool[] P00E96_n306TipAbr ;
      private DateTime[] P00E96_A190CCFech ;
      private string[] P00E96_A184CCTipCod ;
      private string[] P00E96_A506CCEstado ;
      private DateTime[] P00E96_A507CCFecUltPago ;
      private int[] P00E96_A186CCVendCod ;
      private int[] P00E96_A158ZonCod ;
      private bool[] P00E96_n158ZonCod ;
      private int[] P00E96_A159TipCCod ;
      private bool[] P00E96_n159TipCCod ;
      private string[] P00E96_A188CCCliCod ;
      private string[] P00E96_A630CliTel2 ;
      private bool[] P00E96_n630CliTel2 ;
      private string[] P00E96_A629CliTel1 ;
      private bool[] P00E96_n629CliTel1 ;
      private string[] P00E97_A189CCCliDsc ;
      private short[] P00E97_A511TipSigno ;
      private bool[] P00E97_n511TipSigno ;
      private decimal[] P00E97_A513CCImpTotal ;
      private decimal[] P00E97_A509CCImpPago ;
      private int[] P00E97_A187CCmonCod ;
      private DateTime[] P00E97_A508CCFVcto ;
      private string[] P00E97_A1234MonDsc ;
      private bool[] P00E97_n1234MonDsc ;
      private string[] P00E97_A185CCDocNum ;
      private string[] P00E97_A306TipAbr ;
      private bool[] P00E97_n306TipAbr ;
      private DateTime[] P00E97_A190CCFech ;
      private string[] P00E97_A184CCTipCod ;
      private string[] P00E97_A506CCEstado ;
      private int[] P00E97_A186CCVendCod ;
      private int[] P00E97_A158ZonCod ;
      private bool[] P00E97_n158ZonCod ;
      private int[] P00E97_A159TipCCod ;
      private bool[] P00E97_n159TipCCod ;
      private string[] P00E97_A188CCCliCod ;
      private string[] P00E97_A630CliTel2 ;
      private bool[] P00E97_n630CliTel2 ;
      private string[] P00E97_A629CliTel1 ;
      private bool[] P00E97_n629CliTel1 ;
      private string[] P00E98_A188CCCliCod ;
      private string[] P00E98_A506CCEstado ;
      private string[] P00E98_A185CCDocNum ;
      private DateTime[] P00E98_A190CCFech ;
      private DateTime[] P00E98_A507CCFecUltPago ;
      private int[] P00E98_A186CCVendCod ;
      private int[] P00E98_A158ZonCod ;
      private bool[] P00E98_n158ZonCod ;
      private string[] P00E98_A184CCTipCod ;
      private int[] P00E98_A159TipCCod ;
      private bool[] P00E98_n159TipCCod ;
      private decimal[] P00E98_A513CCImpTotal ;
      private int[] P00E98_A187CCmonCod ;
      private decimal[] P00E98_A509CCImpPago ;
      private short[] P00E98_A511TipSigno ;
      private bool[] P00E98_n511TipSigno ;
      private string[] P00E99_A166CobTip ;
      private string[] P00E99_A167CobCod ;
      private string[] P00E99_A661CobSts ;
      private DateTime[] P00E99_A655CobFec ;
      private string[] P00E99_A176CobDocNum ;
      private string[] P00E99_A175CobTipCod ;
      private int[] P00E99_A172CobMon ;
      private decimal[] P00E99_A654CobDTot ;
      private decimal[] P00E99_A663CobTipCam ;
      private int[] P00E99_A173Item ;
   }

   public class rrcuentasxcobrarexpresado__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E96( IGxContext context ,
                                             string AV13CliCod ,
                                             int AV43TipCCod ,
                                             string AV45TipCod ,
                                             int AV54ZonCod ,
                                             int AV55VenCod ,
                                             string AV40Serie ,
                                             short AV46TipLetras ,
                                             string A188CCCliCod ,
                                             int A159TipCCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A186CCVendCod ,
                                             string A185CCDocNum ,
                                             DateTime A507CCFecUltPago ,
                                             DateTime AV22FHasta ,
                                             DateTime A190CCFech ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[8];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliDsc], T1.[CCDocNum], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCmonCod] AS CCmonCod, T1.[CCFVcto], T2.[MonDsc], T3.[TipAbr], T1.[CCFech], T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T1.[CCFecUltPago], T1.[CCVendCod], T4.[ZonCod], T4.[TipCCod], T1.[CCCliCod] AS CCCliCod, T4.[CliTel2], T4.[CliTel1] FROM ((([CLCUENTACOBRAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T1.[CCFecUltPago] > @AV22FHasta or (T1.[CCFecUltPago] = convert( DATETIME, '17530101', 112 )))");
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV22FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] <> 'A')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (0==AV43TipCCod) )
         {
            AddWhere(sWhereString, "(T4.[TipCCod] = @AV43TipCCod)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV45TipCod)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! (0==AV54ZonCod) )
         {
            AddWhere(sWhereString, "(T4.[ZonCod] = @AV54ZonCod)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (0==AV55VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV55VenCod)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CCDocNum], 1, 3) = @AV40Serie)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! (0==AV46TipLetras) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] <> 'LET')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCTipCod], T1.[CCFech]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00E97( IGxContext context ,
                                             string AV13CliCod ,
                                             int AV43TipCCod ,
                                             string AV45TipCod ,
                                             int AV54ZonCod ,
                                             int AV55VenCod ,
                                             string AV40Serie ,
                                             short AV46TipLetras ,
                                             string A188CCCliCod ,
                                             int A159TipCCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A186CCVendCod ,
                                             string A185CCDocNum ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[6];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliDsc], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCmonCod] AS CCmonCod, T1.[CCFVcto], T2.[MonDsc], T1.[CCDocNum], T3.[TipAbr], T1.[CCFech], T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T1.[CCVendCod], T4.[ZonCod], T4.[TipCCod], T1.[CCCliCod] AS CCCliCod, T4.[CliTel2], T4.[CliTel1] FROM ((([CLCUENTACOBRAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T1.[CCEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! (0==AV43TipCCod) )
         {
            AddWhere(sWhereString, "(T4.[TipCCod] = @AV43TipCCod)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV45TipCod)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! (0==AV54ZonCod) )
         {
            AddWhere(sWhereString, "(T4.[ZonCod] = @AV54ZonCod)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! (0==AV55VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV55VenCod)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CCDocNum], 1, 3) = @AV40Serie)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! (0==AV46TipLetras) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] <> 'LET')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCTipCod], T1.[CCFech]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00E98( IGxContext context ,
                                             int AV43TipCCod ,
                                             string AV45TipCod ,
                                             int AV54ZonCod ,
                                             int AV55VenCod ,
                                             string AV40Serie ,
                                             short AV46TipLetras ,
                                             int A159TipCCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A186CCVendCod ,
                                             string A185CCDocNum ,
                                             DateTime A507CCFecUltPago ,
                                             DateTime AV22FHasta ,
                                             DateTime A190CCFech ,
                                             string A506CCEstado ,
                                             string A188CCCliCod ,
                                             string AV8CCCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[8];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliCod] AS CCCliCod, T1.[CCEstado], T1.[CCDocNum], T1.[CCFech], T1.[CCFecUltPago], T1.[CCVendCod], T2.[ZonCod], T1.[CCTipCod] AS CCTipCod, T2.[TipCCod], T1.[CCImpTotal], T1.[CCmonCod] AS CCmonCod, T1.[CCImpPago], T3.[TipSigno] FROM (([CLCUENTACOBRAR] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[CCCliCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod])";
         AddWhere(sWhereString, "(T1.[CCFecUltPago] > @AV22FHasta or (T1.[CCFecUltPago] = convert( DATETIME, '17530101', 112 )))");
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV22FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] <> 'A')");
         AddWhere(sWhereString, "(T1.[CCCliCod] = @AV8CCCliCod)");
         if ( ! (0==AV43TipCCod) )
         {
            AddWhere(sWhereString, "(T2.[TipCCod] = @AV43TipCCod)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV45TipCod)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ! (0==AV54ZonCod) )
         {
            AddWhere(sWhereString, "(T2.[ZonCod] = @AV54ZonCod)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ! (0==AV55VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV55VenCod)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CCDocNum], 1, 3) = @AV40Serie)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ! (0==AV46TipLetras) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] <> 'LET')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCTipCod], T1.[CCFech]";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 4 :
                     return conditional_P00E96(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] );
               case 5 :
                     return conditional_P00E97(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
               case 6 :
                     return conditional_P00E98(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] );
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
          Object[] prmP00E92;
          prmP00E92 = new Object[] {
          new ParDef("@AV45TipCod",GXType.NChar,3,0)
          };
          Object[] prmP00E93;
          prmP00E93 = new Object[] {
          new ParDef("@AV43TipCCod",GXType.Int32,6,0)
          };
          Object[] prmP00E94;
          prmP00E94 = new Object[] {
          new ParDef("@AV32MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00E95;
          prmP00E95 = new Object[] {
          new ParDef("@AV13CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00E99;
          prmP00E99 = new Object[] {
          new ParDef("@AV12CCTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV9CCDocNum",GXType.NChar,12,0) ,
          new ParDef("@AV22FHasta",GXType.Date,8,0)
          };
          Object[] prmP00E96;
          prmP00E96 = new Object[] {
          new ParDef("@AV22FHasta",GXType.Date,8,0) ,
          new ParDef("@AV22FHasta",GXType.Date,8,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV43TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV45TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV54ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV55VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV40Serie",GXType.Char,3,0)
          };
          Object[] prmP00E97;
          prmP00E97 = new Object[] {
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV43TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV45TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV54ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV55VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV40Serie",GXType.Char,3,0)
          };
          Object[] prmP00E98;
          prmP00E98 = new Object[] {
          new ParDef("@AV22FHasta",GXType.Date,8,0) ,
          new ParDef("@AV22FHasta",GXType.Date,8,0) ,
          new ParDef("@AV8CCCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV43TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV45TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV54ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV55VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV40Serie",GXType.Char,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00E92", "SELECT [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipCod] = @AV45TipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E92,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E93", "SELECT [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @AV43TipCCod ORDER BY [TipCCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E93,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E94", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV32MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E94,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E95", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV13CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E95,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E96", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E96,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E97", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E97,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E98", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E98,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E99", "SELECT T1.[CobTip], T1.[CobCod], T2.[CobSts], T2.[CobFec], T1.[CobDocNum], T1.[CobTipCod], T2.[CobMon], T1.[CobDTot], T1.[CobTipCam], T1.[Item] FROM ([CLCOBRANZADET] T1 INNER JOIN [CLCOBRANZA] T2 ON T2.[CobTip] = T1.[CobTip] AND T2.[CobCod] = T1.[CobCod]) WHERE (T1.[CobTipCod] = @AV12CCTipCod and T1.[CobDocNum] = @AV9CCDocNum) AND (T2.[CobFec] > @AV22FHasta) AND (T2.[CobSts] <> 'A') ORDER BY T1.[CobTipCod], T1.[CobDocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E99,100, GxCacheFrequency.OFF ,false,false )
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
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
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
             case 6 :
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
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((short[]) buf[14])[0] = rslt.getShort(13);
                ((bool[]) buf[15])[0] = rslt.wasNull(13);
                return;
             case 7 :
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
