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
   public class rrcuentasxcobrarformato2 : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrcuentasxcobrarformato2.aspx")), "rrcuentasxcobrarformato2.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrcuentasxcobrarformato2.aspx")))) ;
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
               AV19CliCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV66MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV39FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV97ZonCod = (int)(NumberUtil.Val( GetPar( "ZonCod"), "."));
                  AV75Serie = GetPar( "Serie");
                  AV81TipLetras = (short)(NumberUtil.Val( GetPar( "TipLetras"), "."));
                  AV96VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
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

      public rrcuentasxcobrarformato2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrcuentasxcobrarformato2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CliCod ,
                           ref int aP1_MonCod ,
                           ref DateTime aP2_FHasta ,
                           ref int aP3_ZonCod ,
                           ref string aP4_Serie ,
                           ref short aP5_TipLetras ,
                           ref int aP6_VenCod )
      {
         this.AV19CliCod = aP0_CliCod;
         this.AV66MonCod = aP1_MonCod;
         this.AV39FHasta = aP2_FHasta;
         this.AV97ZonCod = aP3_ZonCod;
         this.AV75Serie = aP4_Serie;
         this.AV81TipLetras = aP5_TipLetras;
         this.AV96VenCod = aP6_VenCod;
         initialize();
         executePrivate();
         aP0_CliCod=this.AV19CliCod;
         aP1_MonCod=this.AV66MonCod;
         aP2_FHasta=this.AV39FHasta;
         aP3_ZonCod=this.AV97ZonCod;
         aP4_Serie=this.AV75Serie;
         aP5_TipLetras=this.AV81TipLetras;
         aP6_VenCod=this.AV96VenCod;
      }

      public int executeUdp( ref string aP0_CliCod ,
                             ref int aP1_MonCod ,
                             ref DateTime aP2_FHasta ,
                             ref int aP3_ZonCod ,
                             ref string aP4_Serie ,
                             ref short aP5_TipLetras )
      {
         execute(ref aP0_CliCod, ref aP1_MonCod, ref aP2_FHasta, ref aP3_ZonCod, ref aP4_Serie, ref aP5_TipLetras, ref aP6_VenCod);
         return AV96VenCod ;
      }

      public void executeSubmit( ref string aP0_CliCod ,
                                 ref int aP1_MonCod ,
                                 ref DateTime aP2_FHasta ,
                                 ref int aP3_ZonCod ,
                                 ref string aP4_Serie ,
                                 ref short aP5_TipLetras ,
                                 ref int aP6_VenCod )
      {
         rrcuentasxcobrarformato2 objrrcuentasxcobrarformato2;
         objrrcuentasxcobrarformato2 = new rrcuentasxcobrarformato2();
         objrrcuentasxcobrarformato2.AV19CliCod = aP0_CliCod;
         objrrcuentasxcobrarformato2.AV66MonCod = aP1_MonCod;
         objrrcuentasxcobrarformato2.AV39FHasta = aP2_FHasta;
         objrrcuentasxcobrarformato2.AV97ZonCod = aP3_ZonCod;
         objrrcuentasxcobrarformato2.AV75Serie = aP4_Serie;
         objrrcuentasxcobrarformato2.AV81TipLetras = aP5_TipLetras;
         objrrcuentasxcobrarformato2.AV96VenCod = aP6_VenCod;
         objrrcuentasxcobrarformato2.context.SetSubmitInitialConfig(context);
         objrrcuentasxcobrarformato2.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrcuentasxcobrarformato2);
         aP0_CliCod=this.AV19CliCod;
         aP1_MonCod=this.AV66MonCod;
         aP2_FHasta=this.AV39FHasta;
         aP3_ZonCod=this.AV97ZonCod;
         aP4_Serie=this.AV75Serie;
         aP5_TipLetras=this.AV81TipLetras;
         aP6_VenCod=this.AV96VenCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrcuentasxcobrarformato2)stateInfo).executePrivate();
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
            AV32Empresa = AV76Session.Get("Empresa");
            AV31EmpDir = AV76Session.Get("EmpDir");
            AV33EmpRUC = AV76Session.Get("EmpRUC");
            AV69Ruta = AV76Session.Get("RUTA") + "/Logo.jpg";
            AV59Logo = AV69Ruta;
            AV102Logo_GXI = GXDbFile.PathToUrl( AV69Ruta);
            if ( DateTimeUtil.ResetTime ( AV39FHasta ) == DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
            {
               /* Execute user subroutine: 'CUENTACOBRARFECHA' */
               S201 ();
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
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HEA0( true, 0) ;
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
         GxHdr3 = true;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV19CliCod ,
                                              AV66MonCod ,
                                              AV79TipCod ,
                                              AV97ZonCod ,
                                              AV96VenCod ,
                                              AV75Serie ,
                                              AV81TipLetras ,
                                              A188CCCliCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A186CCVendCod ,
                                              A185CCDocNum ,
                                              A190CCFech ,
                                              AV39FHasta ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00EA2 */
         pr_default.execute(0, new Object[] {AV39FHasta, AV19CliCod, AV66MonCod, AV79TipCod, AV97ZonCod, AV96VenCod, AV75Serie});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKEA3 = false;
            A160CliVend = P00EA2_A160CliVend[0];
            n160CliVend = P00EA2_n160CliVend[0];
            A139PaiCod = P00EA2_A139PaiCod[0];
            n139PaiCod = P00EA2_n139PaiCod[0];
            A140EstCod = P00EA2_A140EstCod[0];
            n140EstCod = P00EA2_n140EstCod[0];
            A141ProvCod = P00EA2_A141ProvCod[0];
            n141ProvCod = P00EA2_n141ProvCod[0];
            A142DisCod = P00EA2_A142DisCod[0];
            n142DisCod = P00EA2_n142DisCod[0];
            A189CCCliDsc = P00EA2_A189CCCliDsc[0];
            A185CCDocNum = P00EA2_A185CCDocNum[0];
            A511TipSigno = P00EA2_A511TipSigno[0];
            n511TipSigno = P00EA2_n511TipSigno[0];
            A513CCImpTotal = P00EA2_A513CCImpTotal[0];
            A509CCImpPago = P00EA2_A509CCImpPago[0];
            A187CCmonCod = P00EA2_A187CCmonCod[0];
            A1233MonAbr = P00EA2_A1233MonAbr[0];
            n1233MonAbr = P00EA2_n1233MonAbr[0];
            A190CCFech = P00EA2_A190CCFech[0];
            A184CCTipCod = P00EA2_A184CCTipCod[0];
            A508CCFVcto = P00EA2_A508CCFVcto[0];
            A506CCEstado = P00EA2_A506CCEstado[0];
            A186CCVendCod = P00EA2_A186CCVendCod[0];
            A158ZonCod = P00EA2_A158ZonCod[0];
            n158ZonCod = P00EA2_n158ZonCod[0];
            A188CCCliCod = P00EA2_A188CCCliCod[0];
            A596CliDir = P00EA2_A596CliDir[0];
            n596CliDir = P00EA2_n596CliDir[0];
            A602EstDsc = P00EA2_A602EstDsc[0];
            A603ProvDsc = P00EA2_A603ProvDsc[0];
            A604DisDsc = P00EA2_A604DisDsc[0];
            A629CliTel1 = P00EA2_A629CliTel1[0];
            n629CliTel1 = P00EA2_n629CliTel1[0];
            A609CliEma = P00EA2_A609CliEma[0];
            n609CliEma = P00EA2_n609CliEma[0];
            A613CliLim = P00EA2_A613CliLim[0];
            n613CliLim = P00EA2_n613CliLim[0];
            A635CliVendDsc = P00EA2_A635CliVendDsc[0];
            A137Conpcod = P00EA2_A137Conpcod[0];
            n137Conpcod = P00EA2_n137Conpcod[0];
            A1233MonAbr = P00EA2_A1233MonAbr[0];
            n1233MonAbr = P00EA2_n1233MonAbr[0];
            A511TipSigno = P00EA2_A511TipSigno[0];
            n511TipSigno = P00EA2_n511TipSigno[0];
            A160CliVend = P00EA2_A160CliVend[0];
            n160CliVend = P00EA2_n160CliVend[0];
            A139PaiCod = P00EA2_A139PaiCod[0];
            n139PaiCod = P00EA2_n139PaiCod[0];
            A140EstCod = P00EA2_A140EstCod[0];
            n140EstCod = P00EA2_n140EstCod[0];
            A141ProvCod = P00EA2_A141ProvCod[0];
            n141ProvCod = P00EA2_n141ProvCod[0];
            A142DisCod = P00EA2_A142DisCod[0];
            n142DisCod = P00EA2_n142DisCod[0];
            A158ZonCod = P00EA2_A158ZonCod[0];
            n158ZonCod = P00EA2_n158ZonCod[0];
            A596CliDir = P00EA2_A596CliDir[0];
            n596CliDir = P00EA2_n596CliDir[0];
            A629CliTel1 = P00EA2_A629CliTel1[0];
            n629CliTel1 = P00EA2_n629CliTel1[0];
            A609CliEma = P00EA2_A609CliEma[0];
            n609CliEma = P00EA2_n609CliEma[0];
            A613CliLim = P00EA2_A613CliLim[0];
            n613CliLim = P00EA2_n613CliLim[0];
            A137Conpcod = P00EA2_A137Conpcod[0];
            n137Conpcod = P00EA2_n137Conpcod[0];
            A635CliVendDsc = P00EA2_A635CliVendDsc[0];
            A602EstDsc = P00EA2_A602EstDsc[0];
            A603ProvDsc = P00EA2_A603ProvDsc[0];
            A604DisDsc = P00EA2_A604DisDsc[0];
            AV15CCCliCod = A188CCCliCod;
            AV20CliDsc = A189CCCliDsc;
            AV40Filtro1 = StringUtil.Trim( A189CCCliDsc);
            AV42Filtro2 = StringUtil.Trim( A596CliDir);
            AV43Filtro22 = StringUtil.Trim( A604DisDsc) + " - " + StringUtil.Trim( A603ProvDsc) + " - " + StringUtil.Trim( A602EstDsc);
            AV44Filtro3 = StringUtil.Trim( A629CliTel1);
            AV45Filtro4 = StringUtil.Trim( A609CliEma);
            AV46Filtro5 = StringUtil.Trim( A188CCCliCod);
            AV47Filtro6 = "";
            AV21CliZon = A158ZonCod;
            AV48Filtro7 = A613CliLim;
            AV49Filtro8 = "";
            /* Execute user subroutine: 'CONTACTO' */
            S123 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV50Filtro9 = StringUtil.Trim( A635CliVendDsc);
            AV29ConpCod = A137Conpcod;
            AV41Filtro10 = "";
            /* Execute user subroutine: 'CONDICIONPAGO' */
            S133 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV85TotalIMN = 0.00m;
            AV84TotalIME = 0.00m;
            AV89TotalPMN = 0.00m;
            AV88TotalPME = 0.00m;
            AV87TotalMN = 0.00m;
            AV86TotalME = 0.00m;
            AV99FlagCab = 0;
            /* Execute user subroutine: 'ZONA' */
            S143 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'VALIDAMOV' */
            S153 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            if ( AV99FlagCab == 1 )
            {
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00EA2_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
               {
                  BRKEA3 = false;
                  A185CCDocNum = P00EA2_A185CCDocNum[0];
                  A511TipSigno = P00EA2_A511TipSigno[0];
                  n511TipSigno = P00EA2_n511TipSigno[0];
                  A513CCImpTotal = P00EA2_A513CCImpTotal[0];
                  A509CCImpPago = P00EA2_A509CCImpPago[0];
                  A187CCmonCod = P00EA2_A187CCmonCod[0];
                  A1233MonAbr = P00EA2_A1233MonAbr[0];
                  n1233MonAbr = P00EA2_n1233MonAbr[0];
                  A190CCFech = P00EA2_A190CCFech[0];
                  A184CCTipCod = P00EA2_A184CCTipCod[0];
                  A508CCFVcto = P00EA2_A508CCFVcto[0];
                  A1233MonAbr = P00EA2_A1233MonAbr[0];
                  n1233MonAbr = P00EA2_n1233MonAbr[0];
                  A511TipSigno = P00EA2_A511TipSigno[0];
                  n511TipSigno = P00EA2_n511TipSigno[0];
                  AV18CCTipCod = A184CCTipCod;
                  AV16CCDocNum = A185CCDocNum;
                  AV55Importe = (decimal)(A513CCImpTotal*A511TipSigno);
                  AV68Pagos = (decimal)(A509CCImpPago*A511TipSigno);
                  AV54ImpDoc = A513CCImpTotal;
                  AV67PagoDoc = A509CCImpPago;
                  AV17CCmonCod = A187CCmonCod;
                  AV65MonAbr = StringUtil.Trim( A1233MonAbr);
                  AV35Estado = "";
                  AV57LetCBanNum = "";
                  /* Execute user subroutine: 'PAGOS' */
                  S165 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     returnInSub = true;
                     if (true) return;
                  }
                  if ( ( AV67PagoDoc < Convert.ToDecimal( 0 )) )
                  {
                     AV68Pagos = 0;
                     AV67PagoDoc = 0;
                  }
                  AV55Importe = (decimal)(AV54ImpDoc*A511TipSigno);
                  AV68Pagos = (decimal)(AV67PagoDoc*A511TipSigno);
                  AV70Saldo = (decimal)((AV54ImpDoc-AV67PagoDoc)*A511TipSigno);
                  AV30Dias = (int)(DateTimeUtil.DDiff(AV39FHasta,A508CCFVcto));
                  AV18CCTipCod = A184CCTipCod;
                  AV16CCDocNum = A185CCDocNum;
                  AV57LetCBanNum = "";
                  AV35Estado = "";
                  if ( StringUtil.StrCmp(AV18CCTipCod, "LET") == 0 )
                  {
                     /* Execute user subroutine: 'DATOSLETRAS' */
                     S175 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        returnInSub = true;
                        if (true) return;
                     }
                  }
                  if ( ( AV70Saldo != Convert.ToDecimal( 0 )) )
                  {
                     AV85TotalIMN = (decimal)(AV85TotalIMN+(((AV17CCmonCod==1) ? AV55Importe : (decimal)(0))));
                     AV84TotalIME = (decimal)(AV84TotalIME+(((AV17CCmonCod==2) ? AV55Importe : (decimal)(0))));
                     AV89TotalPMN = (decimal)(AV89TotalPMN+(((AV17CCmonCod==1) ? AV68Pagos : (decimal)(0))));
                     AV88TotalPME = (decimal)(AV88TotalPME+(((AV17CCmonCod==2) ? AV68Pagos : (decimal)(0))));
                     AV87TotalMN = (decimal)(AV87TotalMN+(((AV17CCmonCod==1) ? AV70Saldo : (decimal)(0))));
                     AV86TotalME = (decimal)(AV86TotalME+(((AV17CCmonCod==2) ? AV70Saldo : (decimal)(0))));
                     HEA0( false, 19) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A184CCTipCod, "")), 2, Gx_line+1, 29, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A185CCDocNum, "")), 34, Gx_line+1, 105, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.localUtil.Format( A190CCFech, "99/99/99"), 111, Gx_line+1, 153, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.localUtil.Format( A508CCFVcto, "99/99/99"), 167, Gx_line+1, 218, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 243, Gx_line+1, 340, Gx_line+16, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 296, Gx_line+1, 401, Gx_line+16, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 382, Gx_line+1, 487, Gx_line+16, 2, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57LetCBanNum, "")), 590, Gx_line+1, 695, Gx_line+16, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Estado, "")), 688, Gx_line+1, 793, Gx_line+16, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65MonAbr, "")), 493, Gx_line+1, 527, Gx_line+16, 1, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14BanAbr, "")), 541, Gx_line+1, 585, Gx_line+16, 1, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30Dias), "ZZZZ9")), 222, Gx_line+1, 251, Gx_line+16, 2, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
                  BRKEA3 = true;
                  pr_default.readNext(0);
               }
               HEA0( false, 41) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85TotalIMN, "ZZZZZZ,ZZZ,ZZ9.99")), 233, Gx_line+4, 340, Gx_line+19, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89TotalPMN, "ZZZZZZ,ZZZ,ZZ9.99")), 294, Gx_line+4, 401, Gx_line+19, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 380, Gx_line+4, 487, Gx_line+19, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+1, 797, Gx_line+1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total S/.", 179, Gx_line+5, 230, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+40, 797, Gx_line+40, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Total US$", 179, Gx_line+23, 236, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV84TotalIME, "ZZZZZZ,ZZZ,ZZ9.99")), 233, Gx_line+21, 340, Gx_line+36, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88TotalPME, "ZZZZZZ,ZZZ,ZZ9.99")), 294, Gx_line+21, 401, Gx_line+36, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV86TotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 380, Gx_line+21, 487, Gx_line+36, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+41);
               /* Execute user subroutine: 'OBTENERTOTALTIPODOCUMENTO' */
               S183 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'ANALISIS' */
               S193 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
            }
            /* Eject command */
            Gx_OldLine = Gx_line;
            Gx_line = (int)(P_lines+1);
            if ( ! BRKEA3 )
            {
               BRKEA3 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         GxHdr3 = false;
      }

      protected void S201( )
      {
         /* 'CUENTACOBRARFECHA' Routine */
         returnInSub = false;
         GxHdr7 = true;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV19CliCod ,
                                              AV78TipCCod ,
                                              AV66MonCod ,
                                              AV79TipCod ,
                                              AV97ZonCod ,
                                              AV96VenCod ,
                                              AV81TipLetras ,
                                              AV75Serie ,
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
         /* Using cursor P00EA3 */
         pr_default.execute(1, new Object[] {AV19CliCod, AV78TipCCod, AV66MonCod, AV79TipCod, AV97ZonCod, AV96VenCod, AV75Serie});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKEA7 = false;
            A160CliVend = P00EA3_A160CliVend[0];
            n160CliVend = P00EA3_n160CliVend[0];
            A139PaiCod = P00EA3_A139PaiCod[0];
            n139PaiCod = P00EA3_n139PaiCod[0];
            A140EstCod = P00EA3_A140EstCod[0];
            n140EstCod = P00EA3_n140EstCod[0];
            A141ProvCod = P00EA3_A141ProvCod[0];
            n141ProvCod = P00EA3_n141ProvCod[0];
            A142DisCod = P00EA3_A142DisCod[0];
            n142DisCod = P00EA3_n142DisCod[0];
            A189CCCliDsc = P00EA3_A189CCCliDsc[0];
            A511TipSigno = P00EA3_A511TipSigno[0];
            n511TipSigno = P00EA3_n511TipSigno[0];
            A513CCImpTotal = P00EA3_A513CCImpTotal[0];
            A509CCImpPago = P00EA3_A509CCImpPago[0];
            A185CCDocNum = P00EA3_A185CCDocNum[0];
            A187CCmonCod = P00EA3_A187CCmonCod[0];
            A1233MonAbr = P00EA3_A1233MonAbr[0];
            n1233MonAbr = P00EA3_n1233MonAbr[0];
            A190CCFech = P00EA3_A190CCFech[0];
            A184CCTipCod = P00EA3_A184CCTipCod[0];
            A508CCFVcto = P00EA3_A508CCFVcto[0];
            A506CCEstado = P00EA3_A506CCEstado[0];
            A186CCVendCod = P00EA3_A186CCVendCod[0];
            A158ZonCod = P00EA3_A158ZonCod[0];
            n158ZonCod = P00EA3_n158ZonCod[0];
            A159TipCCod = P00EA3_A159TipCCod[0];
            n159TipCCod = P00EA3_n159TipCCod[0];
            A188CCCliCod = P00EA3_A188CCCliCod[0];
            A596CliDir = P00EA3_A596CliDir[0];
            n596CliDir = P00EA3_n596CliDir[0];
            A602EstDsc = P00EA3_A602EstDsc[0];
            A603ProvDsc = P00EA3_A603ProvDsc[0];
            A604DisDsc = P00EA3_A604DisDsc[0];
            A629CliTel1 = P00EA3_A629CliTel1[0];
            n629CliTel1 = P00EA3_n629CliTel1[0];
            A609CliEma = P00EA3_A609CliEma[0];
            n609CliEma = P00EA3_n609CliEma[0];
            A613CliLim = P00EA3_A613CliLim[0];
            n613CliLim = P00EA3_n613CliLim[0];
            A635CliVendDsc = P00EA3_A635CliVendDsc[0];
            A137Conpcod = P00EA3_A137Conpcod[0];
            n137Conpcod = P00EA3_n137Conpcod[0];
            A1233MonAbr = P00EA3_A1233MonAbr[0];
            n1233MonAbr = P00EA3_n1233MonAbr[0];
            A511TipSigno = P00EA3_A511TipSigno[0];
            n511TipSigno = P00EA3_n511TipSigno[0];
            A160CliVend = P00EA3_A160CliVend[0];
            n160CliVend = P00EA3_n160CliVend[0];
            A139PaiCod = P00EA3_A139PaiCod[0];
            n139PaiCod = P00EA3_n139PaiCod[0];
            A140EstCod = P00EA3_A140EstCod[0];
            n140EstCod = P00EA3_n140EstCod[0];
            A141ProvCod = P00EA3_A141ProvCod[0];
            n141ProvCod = P00EA3_n141ProvCod[0];
            A142DisCod = P00EA3_A142DisCod[0];
            n142DisCod = P00EA3_n142DisCod[0];
            A158ZonCod = P00EA3_A158ZonCod[0];
            n158ZonCod = P00EA3_n158ZonCod[0];
            A159TipCCod = P00EA3_A159TipCCod[0];
            n159TipCCod = P00EA3_n159TipCCod[0];
            A596CliDir = P00EA3_A596CliDir[0];
            n596CliDir = P00EA3_n596CliDir[0];
            A629CliTel1 = P00EA3_A629CliTel1[0];
            n629CliTel1 = P00EA3_n629CliTel1[0];
            A609CliEma = P00EA3_A609CliEma[0];
            n609CliEma = P00EA3_n609CliEma[0];
            A613CliLim = P00EA3_A613CliLim[0];
            n613CliLim = P00EA3_n613CliLim[0];
            A137Conpcod = P00EA3_A137Conpcod[0];
            n137Conpcod = P00EA3_n137Conpcod[0];
            A635CliVendDsc = P00EA3_A635CliVendDsc[0];
            A602EstDsc = P00EA3_A602EstDsc[0];
            A603ProvDsc = P00EA3_A603ProvDsc[0];
            A604DisDsc = P00EA3_A604DisDsc[0];
            AV15CCCliCod = A188CCCliCod;
            AV20CliDsc = A189CCCliDsc;
            AV40Filtro1 = StringUtil.Trim( A189CCCliDsc);
            AV42Filtro2 = StringUtil.Trim( A596CliDir);
            AV43Filtro22 = StringUtil.Trim( A604DisDsc) + " - " + StringUtil.Trim( A603ProvDsc) + " - " + StringUtil.Trim( A602EstDsc);
            AV44Filtro3 = StringUtil.Trim( A629CliTel1);
            AV45Filtro4 = StringUtil.Trim( A609CliEma);
            AV46Filtro5 = StringUtil.Trim( A188CCCliCod);
            AV47Filtro6 = "";
            AV21CliZon = A158ZonCod;
            AV48Filtro7 = A613CliLim;
            AV49Filtro8 = "";
            /* Execute user subroutine: 'CONTACTO' */
            S123 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV50Filtro9 = StringUtil.Trim( A635CliVendDsc);
            AV29ConpCod = A137Conpcod;
            AV41Filtro10 = "";
            /* Execute user subroutine: 'CONDICIONPAGO' */
            S133 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV85TotalIMN = 0.00m;
            AV84TotalIME = 0.00m;
            AV89TotalPMN = 0.00m;
            AV88TotalPME = 0.00m;
            AV87TotalMN = 0.00m;
            AV86TotalME = 0.00m;
            AV71SaldoMes1 = 0.00m;
            AV72SaldoMes2 = 0.00m;
            AV73SaldoMes3 = 0.00m;
            AV74SaldoMes4 = 0.00m;
            /* Execute user subroutine: 'ZONA' */
            S143 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00EA3_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRKEA7 = false;
               A511TipSigno = P00EA3_A511TipSigno[0];
               n511TipSigno = P00EA3_n511TipSigno[0];
               A513CCImpTotal = P00EA3_A513CCImpTotal[0];
               A509CCImpPago = P00EA3_A509CCImpPago[0];
               A185CCDocNum = P00EA3_A185CCDocNum[0];
               A187CCmonCod = P00EA3_A187CCmonCod[0];
               A1233MonAbr = P00EA3_A1233MonAbr[0];
               n1233MonAbr = P00EA3_n1233MonAbr[0];
               A190CCFech = P00EA3_A190CCFech[0];
               A184CCTipCod = P00EA3_A184CCTipCod[0];
               A508CCFVcto = P00EA3_A508CCFVcto[0];
               A1233MonAbr = P00EA3_A1233MonAbr[0];
               n1233MonAbr = P00EA3_n1233MonAbr[0];
               A511TipSigno = P00EA3_A511TipSigno[0];
               n511TipSigno = P00EA3_n511TipSigno[0];
               AV55Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV68Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV70Saldo = (decimal)((A513CCImpTotal-A509CCImpPago)*A511TipSigno);
               AV30Dias = (int)(DateTimeUtil.DDiff(AV39FHasta,A508CCFVcto));
               AV18CCTipCod = A184CCTipCod;
               AV16CCDocNum = A185CCDocNum;
               AV17CCmonCod = A187CCmonCod;
               AV65MonAbr = StringUtil.Trim( A1233MonAbr);
               AV57LetCBanNum = "";
               AV35Estado = "";
               if ( StringUtil.StrCmp(AV18CCTipCod, "LET") == 0 )
               {
                  /* Execute user subroutine: 'DATOSLETRAS' */
                  S175 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               if ( ( AV70Saldo != Convert.ToDecimal( 0 )) )
               {
                  AV85TotalIMN = (decimal)(AV85TotalIMN+(((AV17CCmonCod==1) ? AV55Importe : (decimal)(0))));
                  AV84TotalIME = (decimal)(AV84TotalIME+(((AV17CCmonCod==2) ? AV55Importe : (decimal)(0))));
                  AV89TotalPMN = (decimal)(AV89TotalPMN+(((AV17CCmonCod==1) ? AV68Pagos : (decimal)(0))));
                  AV88TotalPME = (decimal)(AV88TotalPME+(((AV17CCmonCod==2) ? AV68Pagos : (decimal)(0))));
                  AV87TotalMN = (decimal)(AV87TotalMN+(((AV17CCmonCod==1) ? AV70Saldo : (decimal)(0))));
                  AV86TotalME = (decimal)(AV86TotalME+(((AV17CCmonCod==2) ? AV70Saldo : (decimal)(0))));
                  HEA0( false, 19) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A184CCTipCod, "")), 2, Gx_line+1, 29, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A185CCDocNum, "")), 34, Gx_line+1, 105, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A190CCFech, "99/99/99"), 111, Gx_line+1, 153, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A508CCFVcto, "99/99/99"), 167, Gx_line+1, 218, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 243, Gx_line+1, 340, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 296, Gx_line+1, 401, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 382, Gx_line+1, 487, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57LetCBanNum, "")), 590, Gx_line+1, 695, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Estado, "")), 688, Gx_line+1, 793, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65MonAbr, "")), 493, Gx_line+1, 527, Gx_line+16, 1, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14BanAbr, "")), 541, Gx_line+1, 585, Gx_line+16, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30Dias), "ZZZZ9")), 222, Gx_line+1, 251, Gx_line+16, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
               BRKEA7 = true;
               pr_default.readNext(1);
            }
            HEA0( false, 41) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85TotalIMN, "ZZZZZZ,ZZZ,ZZ9.99")), 233, Gx_line+4, 340, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89TotalPMN, "ZZZZZZ,ZZZ,ZZ9.99")), 294, Gx_line+4, 401, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 380, Gx_line+4, 487, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(0, Gx_line+1, 797, Gx_line+1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total S/.", 179, Gx_line+5, 230, Gx_line+19, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(0, Gx_line+40, 797, Gx_line+40, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Total US$", 179, Gx_line+23, 236, Gx_line+37, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV84TotalIME, "ZZZZZZ,ZZZ,ZZ9.99")), 233, Gx_line+21, 340, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88TotalPME, "ZZZZZZ,ZZZ,ZZ9.99")), 294, Gx_line+21, 401, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV86TotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 380, Gx_line+21, 487, Gx_line+36, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+41);
            /* Execute user subroutine: 'OBTENERTOTALTIPODOCUMENTO' */
            S183 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'ANALISIS' */
            S193 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            /* Eject command */
            Gx_OldLine = Gx_line;
            Gx_line = (int)(P_lines+1);
            if ( ! BRKEA7 )
            {
               BRKEA7 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         GxHdr7 = false;
      }

      protected void S211( )
      {
         /* 'CUENTACOBRAR' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV78TipCCod ,
                                              AV66MonCod ,
                                              AV97ZonCod ,
                                              AV96VenCod ,
                                              AV81TipLetras ,
                                              AV75Serie ,
                                              A159TipCCod ,
                                              A187CCmonCod ,
                                              A158ZonCod ,
                                              A186CCVendCod ,
                                              A184CCTipCod ,
                                              A185CCDocNum ,
                                              A188CCCliCod ,
                                              AV15CCCliCod ,
                                              AV79TipCod ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor P00EA4 */
         pr_default.execute(2, new Object[] {AV15CCCliCod, AV79TipCod, AV78TipCCod, AV66MonCod, AV97ZonCod, AV96VenCod, AV75Serie});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKEA11 = false;
            A189CCCliDsc = P00EA4_A189CCCliDsc[0];
            A185CCDocNum = P00EA4_A185CCDocNum[0];
            A511TipSigno = P00EA4_A511TipSigno[0];
            n511TipSigno = P00EA4_n511TipSigno[0];
            A513CCImpTotal = P00EA4_A513CCImpTotal[0];
            A509CCImpPago = P00EA4_A509CCImpPago[0];
            A187CCmonCod = P00EA4_A187CCmonCod[0];
            A508CCFVcto = P00EA4_A508CCFVcto[0];
            A190CCFech = P00EA4_A190CCFech[0];
            A184CCTipCod = P00EA4_A184CCTipCod[0];
            A506CCEstado = P00EA4_A506CCEstado[0];
            A186CCVendCod = P00EA4_A186CCVendCod[0];
            A158ZonCod = P00EA4_A158ZonCod[0];
            n158ZonCod = P00EA4_n158ZonCod[0];
            A159TipCCod = P00EA4_A159TipCCod[0];
            n159TipCCod = P00EA4_n159TipCCod[0];
            A188CCCliCod = P00EA4_A188CCCliCod[0];
            A511TipSigno = P00EA4_A511TipSigno[0];
            n511TipSigno = P00EA4_n511TipSigno[0];
            A158ZonCod = P00EA4_A158ZonCod[0];
            n158ZonCod = P00EA4_n158ZonCod[0];
            A159TipCCod = P00EA4_A159TipCCod[0];
            n159TipCCod = P00EA4_n159TipCCod[0];
            AV15CCCliCod = A188CCCliCod;
            AV20CliDsc = A189CCCliDsc;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00EA4_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRKEA11 = false;
               A185CCDocNum = P00EA4_A185CCDocNum[0];
               A511TipSigno = P00EA4_A511TipSigno[0];
               n511TipSigno = P00EA4_n511TipSigno[0];
               A513CCImpTotal = P00EA4_A513CCImpTotal[0];
               A509CCImpPago = P00EA4_A509CCImpPago[0];
               A187CCmonCod = P00EA4_A187CCmonCod[0];
               A508CCFVcto = P00EA4_A508CCFVcto[0];
               A190CCFech = P00EA4_A190CCFech[0];
               A184CCTipCod = P00EA4_A184CCTipCod[0];
               A511TipSigno = P00EA4_A511TipSigno[0];
               n511TipSigno = P00EA4_n511TipSigno[0];
               AV18CCTipCod = A184CCTipCod;
               AV16CCDocNum = A185CCDocNum;
               AV55Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV68Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV54ImpDoc = A513CCImpTotal;
               AV67PagoDoc = A509CCImpPago;
               AV17CCmonCod = A187CCmonCod;
               /* Execute user subroutine: 'PAGOS' */
               S165 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
               AV55Importe = (decimal)(AV54ImpDoc*A511TipSigno);
               AV68Pagos = (decimal)(AV67PagoDoc*A511TipSigno);
               AV70Saldo = (decimal)((AV54ImpDoc-AV67PagoDoc)*A511TipSigno);
               AV30Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A508CCFVcto));
               if ( ( AV70Saldo != Convert.ToDecimal( 0 )) )
               {
                  AV83TotalDMN = (decimal)(AV83TotalDMN+(((AV17CCmonCod==1) ? AV70Saldo : (decimal)(0))));
                  AV82TotalDME = (decimal)(AV82TotalDME+(((AV17CCmonCod==2) ? AV70Saldo : (decimal)(0))));
               }
               BRKEA11 = true;
               pr_default.readNext(2);
            }
            if ( ! BRKEA11 )
            {
               BRKEA11 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S165( )
      {
         /* 'PAGOS' Routine */
         returnInSub = false;
         /* Using cursor P00EA5 */
         pr_default.execute(3, new Object[] {AV18CCTipCod, AV16CCDocNum, AV39FHasta});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A166CobTip = P00EA5_A166CobTip[0];
            A167CobCod = P00EA5_A167CobCod[0];
            A661CobSts = P00EA5_A661CobSts[0];
            A655CobFec = P00EA5_A655CobFec[0];
            A176CobDocNum = P00EA5_A176CobDocNum[0];
            A175CobTipCod = P00EA5_A175CobTipCod[0];
            A172CobMon = P00EA5_A172CobMon[0];
            A654CobDTot = P00EA5_A654CobDTot[0];
            A663CobTipCam = P00EA5_A663CobTipCam[0];
            A173Item = P00EA5_A173Item[0];
            A661CobSts = P00EA5_A661CobSts[0];
            A655CobFec = P00EA5_A655CobFec[0];
            A172CobMon = P00EA5_A172CobMon[0];
            AV28CobMon = A172CobMon;
            AV27CobDtot = NumberUtil.Round( A654CobDTot, 2);
            if ( ( AV27CobDtot < Convert.ToDecimal( 0 )) )
            {
               AV27CobDtot = (decimal)(AV27CobDtot*-1);
            }
            if ( AV17CCmonCod == AV28CobMon )
            {
               AV67PagoDoc = (decimal)(AV67PagoDoc-AV27CobDtot);
            }
            else
            {
               if ( AV17CCmonCod == 1 )
               {
                  AV67PagoDoc = (decimal)(AV67PagoDoc-(NumberUtil.Round( AV27CobDtot*A663CobTipCam, 2)));
               }
               else
               {
                  AV67PagoDoc = (decimal)(AV67PagoDoc-(NumberUtil.Round( AV27CobDtot/ (decimal)(A663CobTipCam), 2)));
               }
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S183( )
      {
         /* 'OBTENERTOTALTIPODOCUMENTO' Routine */
         returnInSub = false;
         /* Using cursor P00EA6 */
         pr_default.execute(4, new Object[] {AV15CCCliCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKEA14 = false;
            A185CCDocNum = P00EA6_A185CCDocNum[0];
            A184CCTipCod = P00EA6_A184CCTipCod[0];
            A188CCCliCod = P00EA6_A188CCCliCod[0];
            A1910TipDsc = P00EA6_A1910TipDsc[0];
            n1910TipDsc = P00EA6_n1910TipDsc[0];
            A1910TipDsc = P00EA6_A1910TipDsc[0];
            n1910TipDsc = P00EA6_n1910TipDsc[0];
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00EA6_A184CCTipCod[0], A184CCTipCod) == 0 ) )
            {
               BRKEA14 = false;
               A185CCDocNum = P00EA6_A185CCDocNum[0];
               BRKEA14 = true;
               pr_default.readNext(4);
            }
            AV79TipCod = A184CCTipCod;
            AV77TipAbr = A184CCTipCod;
            AV80TipDsc = A1910TipDsc;
            AV83TotalDMN = 0.00m;
            AV82TotalDME = 0.00m;
            /* Execute user subroutine: 'CUENTACOBRAR' */
            S211 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            if ( ( AV83TotalDMN != 0.00m ) || ( AV82TotalDME != 0.00m ) )
            {
               HEA0( false, 18) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77TipAbr, "")), 56, Gx_line+2, 104, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80TipDsc, "")), 107, Gx_line+2, 289, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV83TotalDMN, "ZZZZZZ,ZZZ,ZZ9.99")), 294, Gx_line+2, 401, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV82TotalDME, "ZZZZZZ,ZZZ,ZZ9.99")), 380, Gx_line+2, 487, Gx_line+17, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
            }
            if ( ! BRKEA14 )
            {
               BRKEA14 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S193( )
      {
         /* 'ANALISIS' Routine */
         returnInSub = false;
         AV60Mes = (short)(DateTimeUtil.Month( AV39FHasta));
         AV9Ano = (short)(DateTimeUtil.Year( AV39FHasta));
         AV71SaldoMes1 = 0;
         AV72SaldoMes2 = 0;
         AV73SaldoMes3 = 0;
         AV74SaldoMes4 = 0;
         AV61Mes1 = AV60Mes;
         AV10Ano1 = AV9Ano;
         GXt_char1 = AV23cMes1;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV61Mes1, out  GXt_char1) ;
         AV23cMes1 = GXt_char1;
         if ( AV61Mes1 == 12 )
         {
            AV62Mes2 = 1;
            AV11Ano2 = (short)(AV10Ano1+1);
         }
         else
         {
            AV62Mes2 = (short)(AV61Mes1+1);
            AV11Ano2 = AV10Ano1;
         }
         GXt_char1 = AV24cMes2;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV62Mes2, out  GXt_char1) ;
         AV24cMes2 = GXt_char1;
         if ( AV62Mes2 == 12 )
         {
            AV63Mes3 = 1;
            AV12Ano3 = (short)(AV11Ano2+1);
         }
         else
         {
            AV63Mes3 = (short)(AV62Mes2+1);
            AV12Ano3 = AV11Ano2;
         }
         GXt_char1 = AV25cMes3;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV63Mes3, out  GXt_char1) ;
         AV25cMes3 = GXt_char1;
         if ( AV63Mes3 == 12 )
         {
            AV64Mes4 = 1;
            AV13Ano4 = (short)(AV12Ano3+1);
         }
         else
         {
            AV64Mes4 = (short)(AV63Mes3+1);
            AV13Ano4 = AV12Ano3;
         }
         GXt_char1 = AV26cMes4;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV64Mes4, out  GXt_char1) ;
         AV26cMes4 = GXt_char1;
         AV37FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV62Mes2), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano2), 10, 0));
         AV38FechaInicio = context.localUtil.CToD( AV37FechaC, 2);
         /* Using cursor P00EA7 */
         pr_default.execute(5, new Object[] {AV15CCCliCod, AV38FechaInicio});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A184CCTipCod = P00EA7_A184CCTipCod[0];
            A506CCEstado = P00EA7_A506CCEstado[0];
            A508CCFVcto = P00EA7_A508CCFVcto[0];
            A188CCCliCod = P00EA7_A188CCCliCod[0];
            A509CCImpPago = P00EA7_A509CCImpPago[0];
            A513CCImpTotal = P00EA7_A513CCImpTotal[0];
            A511TipSigno = P00EA7_A511TipSigno[0];
            n511TipSigno = P00EA7_n511TipSigno[0];
            A185CCDocNum = P00EA7_A185CCDocNum[0];
            A511TipSigno = P00EA7_A511TipSigno[0];
            n511TipSigno = P00EA7_n511TipSigno[0];
            A512CCImpSaldo = (decimal)(A513CCImpTotal-A509CCImpPago);
            A514CCImpSaldoSig = (decimal)(A512CCImpSaldo*A511TipSigno);
            AV71SaldoMes1 = (decimal)(AV71SaldoMes1+A514CCImpSaldoSig);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Using cursor P00EA8 */
         pr_default.execute(6, new Object[] {AV15CCCliCod, AV11Ano2, AV62Mes2});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A184CCTipCod = P00EA8_A184CCTipCod[0];
            A506CCEstado = P00EA8_A506CCEstado[0];
            A508CCFVcto = P00EA8_A508CCFVcto[0];
            A188CCCliCod = P00EA8_A188CCCliCod[0];
            A509CCImpPago = P00EA8_A509CCImpPago[0];
            A513CCImpTotal = P00EA8_A513CCImpTotal[0];
            A511TipSigno = P00EA8_A511TipSigno[0];
            n511TipSigno = P00EA8_n511TipSigno[0];
            A185CCDocNum = P00EA8_A185CCDocNum[0];
            A511TipSigno = P00EA8_A511TipSigno[0];
            n511TipSigno = P00EA8_n511TipSigno[0];
            A512CCImpSaldo = (decimal)(A513CCImpTotal-A509CCImpPago);
            A514CCImpSaldoSig = (decimal)(A512CCImpSaldo*A511TipSigno);
            AV72SaldoMes2 = (decimal)(AV72SaldoMes2+A514CCImpSaldoSig);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         /* Using cursor P00EA9 */
         pr_default.execute(7, new Object[] {AV15CCCliCod, AV12Ano3, AV63Mes3});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A184CCTipCod = P00EA9_A184CCTipCod[0];
            A506CCEstado = P00EA9_A506CCEstado[0];
            A508CCFVcto = P00EA9_A508CCFVcto[0];
            A188CCCliCod = P00EA9_A188CCCliCod[0];
            A509CCImpPago = P00EA9_A509CCImpPago[0];
            A513CCImpTotal = P00EA9_A513CCImpTotal[0];
            A511TipSigno = P00EA9_A511TipSigno[0];
            n511TipSigno = P00EA9_n511TipSigno[0];
            A185CCDocNum = P00EA9_A185CCDocNum[0];
            A511TipSigno = P00EA9_A511TipSigno[0];
            n511TipSigno = P00EA9_n511TipSigno[0];
            A512CCImpSaldo = (decimal)(A513CCImpTotal-A509CCImpPago);
            A514CCImpSaldoSig = (decimal)(A512CCImpSaldo*A511TipSigno);
            AV73SaldoMes3 = (decimal)(AV73SaldoMes3+A514CCImpSaldoSig);
            pr_default.readNext(7);
         }
         pr_default.close(7);
         /* Using cursor P00EA10 */
         pr_default.execute(8, new Object[] {AV15CCCliCod, AV13Ano4, AV64Mes4});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A184CCTipCod = P00EA10_A184CCTipCod[0];
            A506CCEstado = P00EA10_A506CCEstado[0];
            A508CCFVcto = P00EA10_A508CCFVcto[0];
            A188CCCliCod = P00EA10_A188CCCliCod[0];
            A509CCImpPago = P00EA10_A509CCImpPago[0];
            A513CCImpTotal = P00EA10_A513CCImpTotal[0];
            A511TipSigno = P00EA10_A511TipSigno[0];
            n511TipSigno = P00EA10_n511TipSigno[0];
            A185CCDocNum = P00EA10_A185CCDocNum[0];
            A511TipSigno = P00EA10_A511TipSigno[0];
            n511TipSigno = P00EA10_n511TipSigno[0];
            A512CCImpSaldo = (decimal)(A513CCImpTotal-A509CCImpPago);
            A514CCImpSaldoSig = (decimal)(A512CCImpSaldo*A511TipSigno);
            AV74SaldoMes4 = (decimal)(AV74SaldoMes4+A514CCImpSaldoSig);
            pr_default.readNext(8);
         }
         pr_default.close(8);
         HEA0( false, 88) ;
         getPrinter().GxDrawRect(11, Gx_line+24, 400, Gx_line+71, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
         getPrinter().GxDrawLine(11, Gx_line+43, 400, Gx_line+43, 1, 0, 0, 0, 0) ;
         getPrinter().GxDrawLine(99, Gx_line+24, 99, Gx_line+71, 1, 0, 0, 0, 0) ;
         getPrinter().GxDrawLine(201, Gx_line+24, 201, Gx_line+71, 1, 0, 0, 0, 0) ;
         getPrinter().GxDrawLine(303, Gx_line+25, 303, Gx_line+70, 1, 0, 0, 0, 0) ;
         getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23cMes1, "")), 28, Gx_line+28, 81, Gx_line+43, 1+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24cMes2, "")), 122, Gx_line+28, 175, Gx_line+43, 1+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25cMes3, "")), 223, Gx_line+28, 276, Gx_line+43, 1+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26cMes4, "")), 323, Gx_line+28, 376, Gx_line+43, 1+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71SaldoMes1, "ZZZZZZ,ZZZ,ZZ9.99")), 1, Gx_line+51, 89, Gx_line+65, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72SaldoMes2, "ZZZZZZ,ZZZ,ZZ9.99")), 84, Gx_line+51, 191, Gx_line+66, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73SaldoMes3, "ZZZZZZ,ZZZ,ZZ9.99")), 185, Gx_line+51, 292, Gx_line+66, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74SaldoMes4, "ZZZZZZ,ZZZ,ZZ9.99")), 279, Gx_line+51, 386, Gx_line+66, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawRect(403, Gx_line+24, 792, Gx_line+71, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
         getPrinter().GxDrawLine(403, Gx_line+48, 792, Gx_line+48, 1, 0, 0, 0, 0) ;
         getPrinter().GxDrawLine(625, Gx_line+25, 625, Gx_line+70, 1, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 647, Gx_line+31, 754, Gx_line+46, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV86TotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 647, Gx_line+53, 754, Gx_line+68, 2+256, 0, 0, 0) ;
         getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("DEUDA TOTAL EN S/.", 468, Gx_line+31, 586, Gx_line+45, 0+256, 0, 0, 0) ;
         getPrinter().GxDrawText("DEUDA TOTAL EN US$", 468, Gx_line+53, 592, Gx_line+67, 0+256, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+88);
      }

      protected void S175( )
      {
         /* 'DATOSLETRAS' Routine */
         returnInSub = false;
         /* Using cursor P00EA11 */
         pr_default.execute(9, new Object[] {AV16CCDocNum});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A1120LetCTipo = P00EA11_A1120LetCTipo[0];
            A209LetCDocNum = P00EA11_A209LetCDocNum[0];
            n209LetCDocNum = P00EA11_n209LetCDocNum[0];
            A1105LetCBanNum = P00EA11_A1105LetCBanNum[0];
            A1116LetCSec = P00EA11_A1116LetCSec[0];
            A1104LetCBanCod = P00EA11_A1104LetCBanCod[0];
            A204LetCLetCod = P00EA11_A204LetCLetCod[0];
            A207LetCItem = P00EA11_A207LetCItem[0];
            AV57LetCBanNum = A1105LetCBanNum;
            AV58LetCSec = A1116LetCSec;
            AV56LetCBanCod = A1104LetCBanCod;
            AV14BanAbr = "";
            AV35Estado = "";
            /* Execute user subroutine: 'BANCO' */
            S2220 ();
            if ( returnInSub )
            {
               pr_default.close(9);
               returnInSub = true;
               if (true) return;
            }
            if ( AV58LetCSec == 1 )
            {
               AV35Estado = "Por Aceptar";
            }
            if ( AV58LetCSec == 2 )
            {
               AV35Estado = "Descuento";
            }
            if ( AV58LetCSec == 3 )
            {
               AV35Estado = "Cobranza";
            }
            if ( AV58LetCSec == 4 )
            {
               AV35Estado = "Cobranza Libre";
            }
            if ( AV58LetCSec == 5 )
            {
               AV35Estado = "Garantia";
            }
            if ( AV58LetCSec == 6 )
            {
               AV35Estado = "Protestado";
            }
            if ( AV58LetCSec == 7 )
            {
               AV35Estado = "Refinanciado";
            }
            if ( AV58LetCSec == 8 )
            {
               AV35Estado = "Cartera";
            }
            if ( AV58LetCSec == 9 )
            {
               AV35Estado = "Aceptada";
            }
            if ( AV58LetCSec == 10 )
            {
               AV35Estado = "Refinanciamiento Amort.";
            }
            if ( AV58LetCSec == 11 )
            {
               AV35Estado = "Factura Negociable-Descuento";
            }
            if ( AV58LetCSec == 12 )
            {
               AV35Estado = "Factura Negociable-Cobranza";
            }
            pr_default.readNext(9);
         }
         pr_default.close(9);
      }

      protected void S143( )
      {
         /* 'ZONA' Routine */
         returnInSub = false;
         /* Using cursor P00EA12 */
         pr_default.execute(10, new Object[] {AV21CliZon});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A158ZonCod = P00EA12_A158ZonCod[0];
            n158ZonCod = P00EA12_n158ZonCod[0];
            A2094ZonDsc = P00EA12_A2094ZonDsc[0];
            AV47Filtro6 = A2094ZonDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(10);
      }

      protected void S2220( )
      {
         /* 'BANCO' Routine */
         returnInSub = false;
         /* Using cursor P00EA13 */
         pr_default.execute(11, new Object[] {AV56LetCBanCod});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A372BanCod = P00EA13_A372BanCod[0];
            A481BanAbr = P00EA13_A481BanAbr[0];
            AV14BanAbr = StringUtil.Trim( A481BanAbr);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(11);
      }

      protected void S153( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         pr_default.dynParam(12, new Object[]{ new Object[]{
                                              AV66MonCod ,
                                              AV79TipCod ,
                                              AV97ZonCod ,
                                              AV96VenCod ,
                                              AV75Serie ,
                                              AV81TipLetras ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A186CCVendCod ,
                                              A185CCDocNum ,
                                              A190CCFech ,
                                              AV39FHasta ,
                                              A506CCEstado ,
                                              A188CCCliCod ,
                                              AV15CCCliCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00EA14 */
         pr_default.execute(12, new Object[] {AV39FHasta, AV15CCCliCod, AV66MonCod, AV79TipCod, AV97ZonCod, AV96VenCod, AV75Serie});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A506CCEstado = P00EA14_A506CCEstado[0];
            A190CCFech = P00EA14_A190CCFech[0];
            A185CCDocNum = P00EA14_A185CCDocNum[0];
            A186CCVendCod = P00EA14_A186CCVendCod[0];
            A158ZonCod = P00EA14_A158ZonCod[0];
            n158ZonCod = P00EA14_n158ZonCod[0];
            A184CCTipCod = P00EA14_A184CCTipCod[0];
            A187CCmonCod = P00EA14_A187CCmonCod[0];
            A188CCCliCod = P00EA14_A188CCCliCod[0];
            A511TipSigno = P00EA14_A511TipSigno[0];
            n511TipSigno = P00EA14_n511TipSigno[0];
            A513CCImpTotal = P00EA14_A513CCImpTotal[0];
            A509CCImpPago = P00EA14_A509CCImpPago[0];
            A511TipSigno = P00EA14_A511TipSigno[0];
            n511TipSigno = P00EA14_n511TipSigno[0];
            A158ZonCod = P00EA14_A158ZonCod[0];
            n158ZonCod = P00EA14_n158ZonCod[0];
            AV18CCTipCod = A184CCTipCod;
            AV16CCDocNum = A185CCDocNum;
            AV17CCmonCod = A187CCmonCod;
            AV55Importe = (decimal)(A513CCImpTotal*A511TipSigno);
            AV68Pagos = (decimal)(A509CCImpPago*A511TipSigno);
            AV54ImpDoc = A513CCImpTotal;
            AV67PagoDoc = A509CCImpPago;
            /* Execute user subroutine: 'PAGOS' */
            S165 ();
            if ( returnInSub )
            {
               pr_default.close(12);
               returnInSub = true;
               if (true) return;
            }
            if ( ( AV67PagoDoc < Convert.ToDecimal( 0 )) )
            {
               AV68Pagos = 0;
               AV67PagoDoc = 0;
            }
            AV55Importe = (decimal)(AV54ImpDoc*A511TipSigno);
            AV68Pagos = (decimal)(AV67PagoDoc*A511TipSigno);
            AV70Saldo = (decimal)((AV54ImpDoc-AV67PagoDoc)*A511TipSigno);
            if ( ( AV70Saldo != Convert.ToDecimal( 0 )) )
            {
               AV51Flag = 1;
               AV99FlagCab = 1;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(12);
         }
         pr_default.close(12);
      }

      protected void S133( )
      {
         /* 'CONDICIONPAGO' Routine */
         returnInSub = false;
         /* Using cursor P00EA15 */
         pr_default.execute(13, new Object[] {AV29ConpCod});
         while ( (pr_default.getStatus(13) != 101) )
         {
            A137Conpcod = P00EA15_A137Conpcod[0];
            n137Conpcod = P00EA15_n137Conpcod[0];
            A753ConpDsc = P00EA15_A753ConpDsc[0];
            AV41Filtro10 = StringUtil.Trim( A753ConpDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(13);
      }

      protected void S123( )
      {
         /* 'CONTACTO' Routine */
         returnInSub = false;
         /* Using cursor P00EA16 */
         pr_default.execute(14, new Object[] {AV15CCCliCod});
         while ( (pr_default.getStatus(14) != 101) )
         {
            A45CliCod = P00EA16_A45CliCod[0];
            A578CliConDsc = P00EA16_A578CliConDsc[0];
            A163CliConCod = P00EA16_A163CliConCod[0];
            AV49Filtro8 = A578CliConDsc;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(14);
         }
         pr_default.close(14);
      }

      protected void HEA0( bool bFoot ,
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
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+85);
                  if ( GxHdr3 )
                  {
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+85);
                  }
                  if ( GxHdr7 )
                  {
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+85);
                  }
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
               if ( GxHdr3 )
               {
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
                  getPrinter().GxDrawText("T/D", 6, Gx_line+223, 29, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Numero", 47, Gx_line+223, 94, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Importe", 297, Gx_line+223, 347, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("ESTADO DE CUENTA CORRIENTE AL", 183, Gx_line+75, 491, Gx_line+95, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("F.Emisión", 106, Gx_line+223, 161, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("F.Vcto", 174, Gx_line+223, 210, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Saldo", 445, Gx_line+223, 478, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("A Cuenta", 362, Gx_line+223, 416, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("CLIENTE:", 8, Gx_line+110, 58, Gx_line+123, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("TELEFONO", 8, Gx_line+157, 65, Gx_line+170, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("E - MAIL:", 8, Gx_line+174, 58, Gx_line+187, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Filtro1, "")), 76, Gx_line+108, 373, Gx_line+125, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42Filtro2, "")), 76, Gx_line+124, 373, Gx_line+141, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44Filtro3, "")), 76, Gx_line+157, 373, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45Filtro4, "")), 76, Gx_line+172, 374, Gx_line+189, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31EmpDir, "")), 19, Gx_line+29, 404, Gx_line+47, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33EmpRUC, "")), 19, Gx_line+46, 404, Gx_line+64, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32Empresa, "")), 19, Gx_line+11, 404, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV39FHasta, "99/99/99"), 485, Gx_line+75, 567, Gx_line+96, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("R..U.C:", 389, Gx_line+110, 424, Gx_line+123, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("ZONA:", 389, Gx_line+126, 423, Gx_line+139, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("LINEA CREDITO:", 389, Gx_line+142, 479, Gx_line+155, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("CONTACTO:", 389, Gx_line+157, 455, Gx_line+170, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Filtro5, "")), 475, Gx_line+108, 772, Gx_line+125, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Filtro6, "")), 475, Gx_line+124, 772, Gx_line+141, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Filtro7, "ZZZZZZ,ZZZ,ZZ9.99")), 476, Gx_line+140, 566, Gx_line+157, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Filtro8, "")), 475, Gx_line+155, 773, Gx_line+172, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("N° Unico", 596, Gx_line+223, 646, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Observación", 681, Gx_line+223, 755, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("VENDEDOR:", 8, Gx_line+190, 69, Gx_line+203, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("VENCIMIENTO:", 389, Gx_line+174, 470, Gx_line+187, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Filtro9, "")), 76, Gx_line+188, 374, Gx_line+205, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41Filtro10, "")), 475, Gx_line+172, 773, Gx_line+189, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Moneda", 488, Gx_line+223, 536, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Banco", 545, Gx_line+223, 581, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("DIRECCION:", 8, Gx_line+126, 74, Gx_line+139, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43Filtro22, "")), 76, Gx_line+140, 373, Gx_line+157, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(0, Gx_line+215, 797, Gx_line+241, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Dias", 230, Gx_line+223, 256, Gx_line+237, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+242);
               }
               if ( GxHdr7 )
               {
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
                  getPrinter().GxDrawText("T/D", 6, Gx_line+223, 29, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Numero", 47, Gx_line+223, 94, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Importe", 297, Gx_line+223, 347, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("ESTADO DE CUENTA CORRIENTE AL", 183, Gx_line+75, 491, Gx_line+95, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("F.Emisión", 106, Gx_line+223, 161, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("F.Vcto", 174, Gx_line+223, 210, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Saldo", 445, Gx_line+223, 478, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("A Cuenta", 362, Gx_line+223, 416, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("CLIENTE:", 8, Gx_line+110, 58, Gx_line+123, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("TELEFONO", 8, Gx_line+157, 65, Gx_line+170, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("E - MAIL:", 8, Gx_line+174, 58, Gx_line+187, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Filtro1, "")), 76, Gx_line+108, 373, Gx_line+125, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42Filtro2, "")), 76, Gx_line+124, 373, Gx_line+141, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44Filtro3, "")), 76, Gx_line+157, 373, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45Filtro4, "")), 76, Gx_line+172, 374, Gx_line+189, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31EmpDir, "")), 19, Gx_line+29, 404, Gx_line+47, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33EmpRUC, "")), 19, Gx_line+46, 404, Gx_line+64, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32Empresa, "")), 19, Gx_line+11, 404, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV39FHasta, "99/99/99"), 485, Gx_line+75, 567, Gx_line+96, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("R..U.C:", 389, Gx_line+110, 424, Gx_line+123, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("ZONA:", 389, Gx_line+126, 423, Gx_line+139, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("LINEA CREDITO:", 389, Gx_line+142, 479, Gx_line+155, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("CONTACTO:", 389, Gx_line+157, 455, Gx_line+170, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Filtro5, "")), 475, Gx_line+108, 772, Gx_line+125, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Filtro6, "")), 475, Gx_line+124, 772, Gx_line+141, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Filtro7, "ZZZZZZ,ZZZ,ZZ9.99")), 476, Gx_line+140, 566, Gx_line+157, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Filtro8, "")), 475, Gx_line+155, 773, Gx_line+172, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("N° Unico", 596, Gx_line+223, 646, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Observación", 681, Gx_line+223, 755, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("VENDEDOR:", 8, Gx_line+190, 69, Gx_line+203, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("VENCIMIENTO:", 389, Gx_line+174, 470, Gx_line+187, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Filtro9, "")), 76, Gx_line+188, 374, Gx_line+205, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41Filtro10, "")), 475, Gx_line+172, 773, Gx_line+189, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Moneda", 488, Gx_line+223, 536, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Banco", 545, Gx_line+223, 581, Gx_line+237, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("DIRECCION:", 8, Gx_line+126, 74, Gx_line+139, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43Filtro22, "")), 76, Gx_line+140, 373, Gx_line+157, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(0, Gx_line+215, 797, Gx_line+241, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Dias", 230, Gx_line+223, 256, Gx_line+237, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+242);
               }
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
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
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
         AV32Empresa = "";
         AV76Session = context.GetSession();
         AV31EmpDir = "";
         AV33EmpRUC = "";
         AV69Ruta = "";
         AV59Logo = "";
         AV102Logo_GXI = "";
         scmdbuf = "";
         AV79TipCod = "";
         A188CCCliCod = "";
         A184CCTipCod = "";
         A185CCDocNum = "";
         A190CCFech = DateTime.MinValue;
         A506CCEstado = "";
         P00EA2_A160CliVend = new int[1] ;
         P00EA2_n160CliVend = new bool[] {false} ;
         P00EA2_A139PaiCod = new string[] {""} ;
         P00EA2_n139PaiCod = new bool[] {false} ;
         P00EA2_A140EstCod = new string[] {""} ;
         P00EA2_n140EstCod = new bool[] {false} ;
         P00EA2_A141ProvCod = new string[] {""} ;
         P00EA2_n141ProvCod = new bool[] {false} ;
         P00EA2_A142DisCod = new string[] {""} ;
         P00EA2_n142DisCod = new bool[] {false} ;
         P00EA2_A189CCCliDsc = new string[] {""} ;
         P00EA2_A185CCDocNum = new string[] {""} ;
         P00EA2_A511TipSigno = new short[1] ;
         P00EA2_n511TipSigno = new bool[] {false} ;
         P00EA2_A513CCImpTotal = new decimal[1] ;
         P00EA2_A509CCImpPago = new decimal[1] ;
         P00EA2_A187CCmonCod = new int[1] ;
         P00EA2_A1233MonAbr = new string[] {""} ;
         P00EA2_n1233MonAbr = new bool[] {false} ;
         P00EA2_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00EA2_A184CCTipCod = new string[] {""} ;
         P00EA2_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00EA2_A506CCEstado = new string[] {""} ;
         P00EA2_A186CCVendCod = new int[1] ;
         P00EA2_A158ZonCod = new int[1] ;
         P00EA2_n158ZonCod = new bool[] {false} ;
         P00EA2_A188CCCliCod = new string[] {""} ;
         P00EA2_A596CliDir = new string[] {""} ;
         P00EA2_n596CliDir = new bool[] {false} ;
         P00EA2_A602EstDsc = new string[] {""} ;
         P00EA2_A603ProvDsc = new string[] {""} ;
         P00EA2_A604DisDsc = new string[] {""} ;
         P00EA2_A629CliTel1 = new string[] {""} ;
         P00EA2_n629CliTel1 = new bool[] {false} ;
         P00EA2_A609CliEma = new string[] {""} ;
         P00EA2_n609CliEma = new bool[] {false} ;
         P00EA2_A613CliLim = new decimal[1] ;
         P00EA2_n613CliLim = new bool[] {false} ;
         P00EA2_A635CliVendDsc = new string[] {""} ;
         P00EA2_A137Conpcod = new int[1] ;
         P00EA2_n137Conpcod = new bool[] {false} ;
         A139PaiCod = "";
         A140EstCod = "";
         A141ProvCod = "";
         A142DisCod = "";
         A189CCCliDsc = "";
         A1233MonAbr = "";
         A508CCFVcto = DateTime.MinValue;
         A596CliDir = "";
         A602EstDsc = "";
         A603ProvDsc = "";
         A604DisDsc = "";
         A629CliTel1 = "";
         A609CliEma = "";
         A635CliVendDsc = "";
         AV15CCCliCod = "";
         AV20CliDsc = "";
         AV40Filtro1 = "";
         AV42Filtro2 = "";
         AV43Filtro22 = "";
         AV44Filtro3 = "";
         AV45Filtro4 = "";
         AV46Filtro5 = "";
         AV47Filtro6 = "";
         AV49Filtro8 = "";
         AV50Filtro9 = "";
         AV41Filtro10 = "";
         AV18CCTipCod = "";
         AV16CCDocNum = "";
         AV65MonAbr = "";
         AV35Estado = "";
         AV57LetCBanNum = "";
         AV14BanAbr = "";
         P00EA3_A160CliVend = new int[1] ;
         P00EA3_n160CliVend = new bool[] {false} ;
         P00EA3_A139PaiCod = new string[] {""} ;
         P00EA3_n139PaiCod = new bool[] {false} ;
         P00EA3_A140EstCod = new string[] {""} ;
         P00EA3_n140EstCod = new bool[] {false} ;
         P00EA3_A141ProvCod = new string[] {""} ;
         P00EA3_n141ProvCod = new bool[] {false} ;
         P00EA3_A142DisCod = new string[] {""} ;
         P00EA3_n142DisCod = new bool[] {false} ;
         P00EA3_A189CCCliDsc = new string[] {""} ;
         P00EA3_A511TipSigno = new short[1] ;
         P00EA3_n511TipSigno = new bool[] {false} ;
         P00EA3_A513CCImpTotal = new decimal[1] ;
         P00EA3_A509CCImpPago = new decimal[1] ;
         P00EA3_A185CCDocNum = new string[] {""} ;
         P00EA3_A187CCmonCod = new int[1] ;
         P00EA3_A1233MonAbr = new string[] {""} ;
         P00EA3_n1233MonAbr = new bool[] {false} ;
         P00EA3_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00EA3_A184CCTipCod = new string[] {""} ;
         P00EA3_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00EA3_A506CCEstado = new string[] {""} ;
         P00EA3_A186CCVendCod = new int[1] ;
         P00EA3_A158ZonCod = new int[1] ;
         P00EA3_n158ZonCod = new bool[] {false} ;
         P00EA3_A159TipCCod = new int[1] ;
         P00EA3_n159TipCCod = new bool[] {false} ;
         P00EA3_A188CCCliCod = new string[] {""} ;
         P00EA3_A596CliDir = new string[] {""} ;
         P00EA3_n596CliDir = new bool[] {false} ;
         P00EA3_A602EstDsc = new string[] {""} ;
         P00EA3_A603ProvDsc = new string[] {""} ;
         P00EA3_A604DisDsc = new string[] {""} ;
         P00EA3_A629CliTel1 = new string[] {""} ;
         P00EA3_n629CliTel1 = new bool[] {false} ;
         P00EA3_A609CliEma = new string[] {""} ;
         P00EA3_n609CliEma = new bool[] {false} ;
         P00EA3_A613CliLim = new decimal[1] ;
         P00EA3_n613CliLim = new bool[] {false} ;
         P00EA3_A635CliVendDsc = new string[] {""} ;
         P00EA3_A137Conpcod = new int[1] ;
         P00EA3_n137Conpcod = new bool[] {false} ;
         P00EA4_A189CCCliDsc = new string[] {""} ;
         P00EA4_A185CCDocNum = new string[] {""} ;
         P00EA4_A511TipSigno = new short[1] ;
         P00EA4_n511TipSigno = new bool[] {false} ;
         P00EA4_A513CCImpTotal = new decimal[1] ;
         P00EA4_A509CCImpPago = new decimal[1] ;
         P00EA4_A187CCmonCod = new int[1] ;
         P00EA4_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00EA4_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00EA4_A184CCTipCod = new string[] {""} ;
         P00EA4_A506CCEstado = new string[] {""} ;
         P00EA4_A186CCVendCod = new int[1] ;
         P00EA4_A158ZonCod = new int[1] ;
         P00EA4_n158ZonCod = new bool[] {false} ;
         P00EA4_A159TipCCod = new int[1] ;
         P00EA4_n159TipCCod = new bool[] {false} ;
         P00EA4_A188CCCliCod = new string[] {""} ;
         P00EA5_A166CobTip = new string[] {""} ;
         P00EA5_A167CobCod = new string[] {""} ;
         P00EA5_A661CobSts = new string[] {""} ;
         P00EA5_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         P00EA5_A176CobDocNum = new string[] {""} ;
         P00EA5_A175CobTipCod = new string[] {""} ;
         P00EA5_A172CobMon = new int[1] ;
         P00EA5_A654CobDTot = new decimal[1] ;
         P00EA5_A663CobTipCam = new decimal[1] ;
         P00EA5_A173Item = new int[1] ;
         A166CobTip = "";
         A167CobCod = "";
         A661CobSts = "";
         A655CobFec = DateTime.MinValue;
         A176CobDocNum = "";
         A175CobTipCod = "";
         P00EA6_A185CCDocNum = new string[] {""} ;
         P00EA6_A184CCTipCod = new string[] {""} ;
         P00EA6_A188CCCliCod = new string[] {""} ;
         P00EA6_A1910TipDsc = new string[] {""} ;
         P00EA6_n1910TipDsc = new bool[] {false} ;
         A1910TipDsc = "";
         AV77TipAbr = "";
         AV80TipDsc = "";
         AV23cMes1 = "";
         AV24cMes2 = "";
         AV25cMes3 = "";
         AV26cMes4 = "";
         GXt_char1 = "";
         AV37FechaC = "";
         AV38FechaInicio = DateTime.MinValue;
         P00EA7_A184CCTipCod = new string[] {""} ;
         P00EA7_A506CCEstado = new string[] {""} ;
         P00EA7_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00EA7_A188CCCliCod = new string[] {""} ;
         P00EA7_A509CCImpPago = new decimal[1] ;
         P00EA7_A513CCImpTotal = new decimal[1] ;
         P00EA7_A511TipSigno = new short[1] ;
         P00EA7_n511TipSigno = new bool[] {false} ;
         P00EA7_A185CCDocNum = new string[] {""} ;
         P00EA8_A184CCTipCod = new string[] {""} ;
         P00EA8_A506CCEstado = new string[] {""} ;
         P00EA8_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00EA8_A188CCCliCod = new string[] {""} ;
         P00EA8_A509CCImpPago = new decimal[1] ;
         P00EA8_A513CCImpTotal = new decimal[1] ;
         P00EA8_A511TipSigno = new short[1] ;
         P00EA8_n511TipSigno = new bool[] {false} ;
         P00EA8_A185CCDocNum = new string[] {""} ;
         P00EA9_A184CCTipCod = new string[] {""} ;
         P00EA9_A506CCEstado = new string[] {""} ;
         P00EA9_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00EA9_A188CCCliCod = new string[] {""} ;
         P00EA9_A509CCImpPago = new decimal[1] ;
         P00EA9_A513CCImpTotal = new decimal[1] ;
         P00EA9_A511TipSigno = new short[1] ;
         P00EA9_n511TipSigno = new bool[] {false} ;
         P00EA9_A185CCDocNum = new string[] {""} ;
         P00EA10_A184CCTipCod = new string[] {""} ;
         P00EA10_A506CCEstado = new string[] {""} ;
         P00EA10_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00EA10_A188CCCliCod = new string[] {""} ;
         P00EA10_A509CCImpPago = new decimal[1] ;
         P00EA10_A513CCImpTotal = new decimal[1] ;
         P00EA10_A511TipSigno = new short[1] ;
         P00EA10_n511TipSigno = new bool[] {false} ;
         P00EA10_A185CCDocNum = new string[] {""} ;
         P00EA11_A1120LetCTipo = new string[] {""} ;
         P00EA11_A209LetCDocNum = new string[] {""} ;
         P00EA11_n209LetCDocNum = new bool[] {false} ;
         P00EA11_A1105LetCBanNum = new string[] {""} ;
         P00EA11_A1116LetCSec = new int[1] ;
         P00EA11_A1104LetCBanCod = new int[1] ;
         P00EA11_A204LetCLetCod = new string[] {""} ;
         P00EA11_A207LetCItem = new int[1] ;
         A1120LetCTipo = "";
         A209LetCDocNum = "";
         A1105LetCBanNum = "";
         A204LetCLetCod = "";
         P00EA12_A158ZonCod = new int[1] ;
         P00EA12_n158ZonCod = new bool[] {false} ;
         P00EA12_A2094ZonDsc = new string[] {""} ;
         A2094ZonDsc = "";
         P00EA13_A372BanCod = new int[1] ;
         P00EA13_A481BanAbr = new string[] {""} ;
         A481BanAbr = "";
         P00EA14_A506CCEstado = new string[] {""} ;
         P00EA14_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00EA14_A185CCDocNum = new string[] {""} ;
         P00EA14_A186CCVendCod = new int[1] ;
         P00EA14_A158ZonCod = new int[1] ;
         P00EA14_n158ZonCod = new bool[] {false} ;
         P00EA14_A184CCTipCod = new string[] {""} ;
         P00EA14_A187CCmonCod = new int[1] ;
         P00EA14_A188CCCliCod = new string[] {""} ;
         P00EA14_A511TipSigno = new short[1] ;
         P00EA14_n511TipSigno = new bool[] {false} ;
         P00EA14_A513CCImpTotal = new decimal[1] ;
         P00EA14_A509CCImpPago = new decimal[1] ;
         P00EA15_A137Conpcod = new int[1] ;
         P00EA15_n137Conpcod = new bool[] {false} ;
         P00EA15_A753ConpDsc = new string[] {""} ;
         A753ConpDsc = "";
         P00EA16_A45CliCod = new string[] {""} ;
         P00EA16_A578CliConDsc = new string[] {""} ;
         P00EA16_A163CliConCod = new int[1] ;
         A45CliCod = "";
         A578CliConDsc = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrcuentasxcobrarformato2__default(),
            new Object[][] {
                new Object[] {
               P00EA2_A160CliVend, P00EA2_n160CliVend, P00EA2_A139PaiCod, P00EA2_n139PaiCod, P00EA2_A140EstCod, P00EA2_n140EstCod, P00EA2_A141ProvCod, P00EA2_n141ProvCod, P00EA2_A142DisCod, P00EA2_n142DisCod,
               P00EA2_A189CCCliDsc, P00EA2_A185CCDocNum, P00EA2_A511TipSigno, P00EA2_n511TipSigno, P00EA2_A513CCImpTotal, P00EA2_A509CCImpPago, P00EA2_A187CCmonCod, P00EA2_A1233MonAbr, P00EA2_n1233MonAbr, P00EA2_A190CCFech,
               P00EA2_A184CCTipCod, P00EA2_A508CCFVcto, P00EA2_A506CCEstado, P00EA2_A186CCVendCod, P00EA2_A158ZonCod, P00EA2_n158ZonCod, P00EA2_A188CCCliCod, P00EA2_A596CliDir, P00EA2_n596CliDir, P00EA2_A602EstDsc,
               P00EA2_A603ProvDsc, P00EA2_A604DisDsc, P00EA2_A629CliTel1, P00EA2_n629CliTel1, P00EA2_A609CliEma, P00EA2_n609CliEma, P00EA2_A613CliLim, P00EA2_n613CliLim, P00EA2_A635CliVendDsc, P00EA2_A137Conpcod,
               P00EA2_n137Conpcod
               }
               , new Object[] {
               P00EA3_A160CliVend, P00EA3_n160CliVend, P00EA3_A139PaiCod, P00EA3_n139PaiCod, P00EA3_A140EstCod, P00EA3_n140EstCod, P00EA3_A141ProvCod, P00EA3_n141ProvCod, P00EA3_A142DisCod, P00EA3_n142DisCod,
               P00EA3_A189CCCliDsc, P00EA3_A511TipSigno, P00EA3_n511TipSigno, P00EA3_A513CCImpTotal, P00EA3_A509CCImpPago, P00EA3_A185CCDocNum, P00EA3_A187CCmonCod, P00EA3_A1233MonAbr, P00EA3_n1233MonAbr, P00EA3_A190CCFech,
               P00EA3_A184CCTipCod, P00EA3_A508CCFVcto, P00EA3_A506CCEstado, P00EA3_A186CCVendCod, P00EA3_A158ZonCod, P00EA3_n158ZonCod, P00EA3_A159TipCCod, P00EA3_n159TipCCod, P00EA3_A188CCCliCod, P00EA3_A596CliDir,
               P00EA3_n596CliDir, P00EA3_A602EstDsc, P00EA3_A603ProvDsc, P00EA3_A604DisDsc, P00EA3_A629CliTel1, P00EA3_n629CliTel1, P00EA3_A609CliEma, P00EA3_n609CliEma, P00EA3_A613CliLim, P00EA3_n613CliLim,
               P00EA3_A635CliVendDsc, P00EA3_A137Conpcod, P00EA3_n137Conpcod
               }
               , new Object[] {
               P00EA4_A189CCCliDsc, P00EA4_A185CCDocNum, P00EA4_A511TipSigno, P00EA4_n511TipSigno, P00EA4_A513CCImpTotal, P00EA4_A509CCImpPago, P00EA4_A187CCmonCod, P00EA4_A508CCFVcto, P00EA4_A190CCFech, P00EA4_A184CCTipCod,
               P00EA4_A506CCEstado, P00EA4_A186CCVendCod, P00EA4_A158ZonCod, P00EA4_n158ZonCod, P00EA4_A159TipCCod, P00EA4_n159TipCCod, P00EA4_A188CCCliCod
               }
               , new Object[] {
               P00EA5_A166CobTip, P00EA5_A167CobCod, P00EA5_A661CobSts, P00EA5_A655CobFec, P00EA5_A176CobDocNum, P00EA5_A175CobTipCod, P00EA5_A172CobMon, P00EA5_A654CobDTot, P00EA5_A663CobTipCam, P00EA5_A173Item
               }
               , new Object[] {
               P00EA6_A185CCDocNum, P00EA6_A184CCTipCod, P00EA6_A188CCCliCod, P00EA6_A1910TipDsc, P00EA6_n1910TipDsc
               }
               , new Object[] {
               P00EA7_A184CCTipCod, P00EA7_A506CCEstado, P00EA7_A508CCFVcto, P00EA7_A188CCCliCod, P00EA7_A509CCImpPago, P00EA7_A513CCImpTotal, P00EA7_A511TipSigno, P00EA7_n511TipSigno, P00EA7_A185CCDocNum
               }
               , new Object[] {
               P00EA8_A184CCTipCod, P00EA8_A506CCEstado, P00EA8_A508CCFVcto, P00EA8_A188CCCliCod, P00EA8_A509CCImpPago, P00EA8_A513CCImpTotal, P00EA8_A511TipSigno, P00EA8_n511TipSigno, P00EA8_A185CCDocNum
               }
               , new Object[] {
               P00EA9_A184CCTipCod, P00EA9_A506CCEstado, P00EA9_A508CCFVcto, P00EA9_A188CCCliCod, P00EA9_A509CCImpPago, P00EA9_A513CCImpTotal, P00EA9_A511TipSigno, P00EA9_n511TipSigno, P00EA9_A185CCDocNum
               }
               , new Object[] {
               P00EA10_A184CCTipCod, P00EA10_A506CCEstado, P00EA10_A508CCFVcto, P00EA10_A188CCCliCod, P00EA10_A509CCImpPago, P00EA10_A513CCImpTotal, P00EA10_A511TipSigno, P00EA10_n511TipSigno, P00EA10_A185CCDocNum
               }
               , new Object[] {
               P00EA11_A1120LetCTipo, P00EA11_A209LetCDocNum, P00EA11_n209LetCDocNum, P00EA11_A1105LetCBanNum, P00EA11_A1116LetCSec, P00EA11_A1104LetCBanCod, P00EA11_A204LetCLetCod, P00EA11_A207LetCItem
               }
               , new Object[] {
               P00EA12_A158ZonCod, P00EA12_A2094ZonDsc
               }
               , new Object[] {
               P00EA13_A372BanCod, P00EA13_A481BanAbr
               }
               , new Object[] {
               P00EA14_A506CCEstado, P00EA14_A190CCFech, P00EA14_A185CCDocNum, P00EA14_A186CCVendCod, P00EA14_A158ZonCod, P00EA14_n158ZonCod, P00EA14_A184CCTipCod, P00EA14_A187CCmonCod, P00EA14_A188CCCliCod, P00EA14_A511TipSigno,
               P00EA14_n511TipSigno, P00EA14_A513CCImpTotal, P00EA14_A509CCImpPago
               }
               , new Object[] {
               P00EA15_A137Conpcod, P00EA15_A753ConpDsc
               }
               , new Object[] {
               P00EA16_A45CliCod, P00EA16_A578CliConDsc, P00EA16_A163CliConCod
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
      private short AV81TipLetras ;
      private short A511TipSigno ;
      private short AV99FlagCab ;
      private short AV60Mes ;
      private short AV9Ano ;
      private short AV61Mes1 ;
      private short AV10Ano1 ;
      private short AV62Mes2 ;
      private short AV11Ano2 ;
      private short AV63Mes3 ;
      private short AV12Ano3 ;
      private short AV64Mes4 ;
      private short AV13Ano4 ;
      private short AV51Flag ;
      private int AV66MonCod ;
      private int AV97ZonCod ;
      private int AV96VenCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A187CCmonCod ;
      private int A158ZonCod ;
      private int A186CCVendCod ;
      private int A160CliVend ;
      private int A137Conpcod ;
      private int AV21CliZon ;
      private int AV29ConpCod ;
      private int AV17CCmonCod ;
      private int AV30Dias ;
      private int Gx_OldLine ;
      private int AV78TipCCod ;
      private int A159TipCCod ;
      private int A172CobMon ;
      private int A173Item ;
      private int AV28CobMon ;
      private int A1116LetCSec ;
      private int A1104LetCBanCod ;
      private int A207LetCItem ;
      private int AV58LetCSec ;
      private int AV56LetCBanCod ;
      private int A372BanCod ;
      private int A163CliConCod ;
      private decimal A513CCImpTotal ;
      private decimal A509CCImpPago ;
      private decimal A613CliLim ;
      private decimal AV48Filtro7 ;
      private decimal AV85TotalIMN ;
      private decimal AV84TotalIME ;
      private decimal AV89TotalPMN ;
      private decimal AV88TotalPME ;
      private decimal AV87TotalMN ;
      private decimal AV86TotalME ;
      private decimal AV55Importe ;
      private decimal AV68Pagos ;
      private decimal AV54ImpDoc ;
      private decimal AV67PagoDoc ;
      private decimal AV70Saldo ;
      private decimal AV71SaldoMes1 ;
      private decimal AV72SaldoMes2 ;
      private decimal AV73SaldoMes3 ;
      private decimal AV74SaldoMes4 ;
      private decimal AV83TotalDMN ;
      private decimal AV82TotalDME ;
      private decimal A654CobDTot ;
      private decimal A663CobTipCam ;
      private decimal AV27CobDtot ;
      private decimal A512CCImpSaldo ;
      private decimal A514CCImpSaldoSig ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV19CliCod ;
      private string AV75Serie ;
      private string AV32Empresa ;
      private string AV31EmpDir ;
      private string AV33EmpRUC ;
      private string AV69Ruta ;
      private string scmdbuf ;
      private string AV79TipCod ;
      private string A188CCCliCod ;
      private string A184CCTipCod ;
      private string A185CCDocNum ;
      private string A506CCEstado ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A141ProvCod ;
      private string A142DisCod ;
      private string A189CCCliDsc ;
      private string A1233MonAbr ;
      private string A596CliDir ;
      private string A602EstDsc ;
      private string A603ProvDsc ;
      private string A604DisDsc ;
      private string A629CliTel1 ;
      private string A635CliVendDsc ;
      private string AV15CCCliCod ;
      private string AV20CliDsc ;
      private string AV40Filtro1 ;
      private string AV42Filtro2 ;
      private string AV44Filtro3 ;
      private string AV45Filtro4 ;
      private string AV46Filtro5 ;
      private string AV47Filtro6 ;
      private string AV49Filtro8 ;
      private string AV50Filtro9 ;
      private string AV41Filtro10 ;
      private string AV18CCTipCod ;
      private string AV16CCDocNum ;
      private string AV65MonAbr ;
      private string AV57LetCBanNum ;
      private string AV14BanAbr ;
      private string A166CobTip ;
      private string A167CobCod ;
      private string A661CobSts ;
      private string A176CobDocNum ;
      private string A175CobTipCod ;
      private string A1910TipDsc ;
      private string AV77TipAbr ;
      private string AV80TipDsc ;
      private string GXt_char1 ;
      private string AV37FechaC ;
      private string A1120LetCTipo ;
      private string A209LetCDocNum ;
      private string A1105LetCBanNum ;
      private string A204LetCLetCod ;
      private string A2094ZonDsc ;
      private string A481BanAbr ;
      private string A753ConpDsc ;
      private string A45CliCod ;
      private string A578CliConDsc ;
      private string Gx_time ;
      private DateTime AV39FHasta ;
      private DateTime A190CCFech ;
      private DateTime A508CCFVcto ;
      private DateTime A655CobFec ;
      private DateTime AV38FechaInicio ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool GxHdr3 ;
      private bool BRKEA3 ;
      private bool n160CliVend ;
      private bool n139PaiCod ;
      private bool n140EstCod ;
      private bool n141ProvCod ;
      private bool n142DisCod ;
      private bool n511TipSigno ;
      private bool n1233MonAbr ;
      private bool n158ZonCod ;
      private bool n596CliDir ;
      private bool n629CliTel1 ;
      private bool n609CliEma ;
      private bool n613CliLim ;
      private bool n137Conpcod ;
      private bool GxHdr7 ;
      private bool BRKEA7 ;
      private bool n159TipCCod ;
      private bool BRKEA11 ;
      private bool BRKEA14 ;
      private bool n1910TipDsc ;
      private bool n209LetCDocNum ;
      private string AV102Logo_GXI ;
      private string A609CliEma ;
      private string AV43Filtro22 ;
      private string AV35Estado ;
      private string AV23cMes1 ;
      private string AV24cMes2 ;
      private string AV25cMes3 ;
      private string AV26cMes4 ;
      private string AV59Logo ;
      private IGxSession AV76Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CliCod ;
      private int aP1_MonCod ;
      private DateTime aP2_FHasta ;
      private int aP3_ZonCod ;
      private string aP4_Serie ;
      private short aP5_TipLetras ;
      private int aP6_VenCod ;
      private IDataStoreProvider pr_default ;
      private int[] P00EA2_A160CliVend ;
      private bool[] P00EA2_n160CliVend ;
      private string[] P00EA2_A139PaiCod ;
      private bool[] P00EA2_n139PaiCod ;
      private string[] P00EA2_A140EstCod ;
      private bool[] P00EA2_n140EstCod ;
      private string[] P00EA2_A141ProvCod ;
      private bool[] P00EA2_n141ProvCod ;
      private string[] P00EA2_A142DisCod ;
      private bool[] P00EA2_n142DisCod ;
      private string[] P00EA2_A189CCCliDsc ;
      private string[] P00EA2_A185CCDocNum ;
      private short[] P00EA2_A511TipSigno ;
      private bool[] P00EA2_n511TipSigno ;
      private decimal[] P00EA2_A513CCImpTotal ;
      private decimal[] P00EA2_A509CCImpPago ;
      private int[] P00EA2_A187CCmonCod ;
      private string[] P00EA2_A1233MonAbr ;
      private bool[] P00EA2_n1233MonAbr ;
      private DateTime[] P00EA2_A190CCFech ;
      private string[] P00EA2_A184CCTipCod ;
      private DateTime[] P00EA2_A508CCFVcto ;
      private string[] P00EA2_A506CCEstado ;
      private int[] P00EA2_A186CCVendCod ;
      private int[] P00EA2_A158ZonCod ;
      private bool[] P00EA2_n158ZonCod ;
      private string[] P00EA2_A188CCCliCod ;
      private string[] P00EA2_A596CliDir ;
      private bool[] P00EA2_n596CliDir ;
      private string[] P00EA2_A602EstDsc ;
      private string[] P00EA2_A603ProvDsc ;
      private string[] P00EA2_A604DisDsc ;
      private string[] P00EA2_A629CliTel1 ;
      private bool[] P00EA2_n629CliTel1 ;
      private string[] P00EA2_A609CliEma ;
      private bool[] P00EA2_n609CliEma ;
      private decimal[] P00EA2_A613CliLim ;
      private bool[] P00EA2_n613CliLim ;
      private string[] P00EA2_A635CliVendDsc ;
      private int[] P00EA2_A137Conpcod ;
      private bool[] P00EA2_n137Conpcod ;
      private int[] P00EA3_A160CliVend ;
      private bool[] P00EA3_n160CliVend ;
      private string[] P00EA3_A139PaiCod ;
      private bool[] P00EA3_n139PaiCod ;
      private string[] P00EA3_A140EstCod ;
      private bool[] P00EA3_n140EstCod ;
      private string[] P00EA3_A141ProvCod ;
      private bool[] P00EA3_n141ProvCod ;
      private string[] P00EA3_A142DisCod ;
      private bool[] P00EA3_n142DisCod ;
      private string[] P00EA3_A189CCCliDsc ;
      private short[] P00EA3_A511TipSigno ;
      private bool[] P00EA3_n511TipSigno ;
      private decimal[] P00EA3_A513CCImpTotal ;
      private decimal[] P00EA3_A509CCImpPago ;
      private string[] P00EA3_A185CCDocNum ;
      private int[] P00EA3_A187CCmonCod ;
      private string[] P00EA3_A1233MonAbr ;
      private bool[] P00EA3_n1233MonAbr ;
      private DateTime[] P00EA3_A190CCFech ;
      private string[] P00EA3_A184CCTipCod ;
      private DateTime[] P00EA3_A508CCFVcto ;
      private string[] P00EA3_A506CCEstado ;
      private int[] P00EA3_A186CCVendCod ;
      private int[] P00EA3_A158ZonCod ;
      private bool[] P00EA3_n158ZonCod ;
      private int[] P00EA3_A159TipCCod ;
      private bool[] P00EA3_n159TipCCod ;
      private string[] P00EA3_A188CCCliCod ;
      private string[] P00EA3_A596CliDir ;
      private bool[] P00EA3_n596CliDir ;
      private string[] P00EA3_A602EstDsc ;
      private string[] P00EA3_A603ProvDsc ;
      private string[] P00EA3_A604DisDsc ;
      private string[] P00EA3_A629CliTel1 ;
      private bool[] P00EA3_n629CliTel1 ;
      private string[] P00EA3_A609CliEma ;
      private bool[] P00EA3_n609CliEma ;
      private decimal[] P00EA3_A613CliLim ;
      private bool[] P00EA3_n613CliLim ;
      private string[] P00EA3_A635CliVendDsc ;
      private int[] P00EA3_A137Conpcod ;
      private bool[] P00EA3_n137Conpcod ;
      private string[] P00EA4_A189CCCliDsc ;
      private string[] P00EA4_A185CCDocNum ;
      private short[] P00EA4_A511TipSigno ;
      private bool[] P00EA4_n511TipSigno ;
      private decimal[] P00EA4_A513CCImpTotal ;
      private decimal[] P00EA4_A509CCImpPago ;
      private int[] P00EA4_A187CCmonCod ;
      private DateTime[] P00EA4_A508CCFVcto ;
      private DateTime[] P00EA4_A190CCFech ;
      private string[] P00EA4_A184CCTipCod ;
      private string[] P00EA4_A506CCEstado ;
      private int[] P00EA4_A186CCVendCod ;
      private int[] P00EA4_A158ZonCod ;
      private bool[] P00EA4_n158ZonCod ;
      private int[] P00EA4_A159TipCCod ;
      private bool[] P00EA4_n159TipCCod ;
      private string[] P00EA4_A188CCCliCod ;
      private string[] P00EA5_A166CobTip ;
      private string[] P00EA5_A167CobCod ;
      private string[] P00EA5_A661CobSts ;
      private DateTime[] P00EA5_A655CobFec ;
      private string[] P00EA5_A176CobDocNum ;
      private string[] P00EA5_A175CobTipCod ;
      private int[] P00EA5_A172CobMon ;
      private decimal[] P00EA5_A654CobDTot ;
      private decimal[] P00EA5_A663CobTipCam ;
      private int[] P00EA5_A173Item ;
      private string[] P00EA6_A185CCDocNum ;
      private string[] P00EA6_A184CCTipCod ;
      private string[] P00EA6_A188CCCliCod ;
      private string[] P00EA6_A1910TipDsc ;
      private bool[] P00EA6_n1910TipDsc ;
      private string[] P00EA7_A184CCTipCod ;
      private string[] P00EA7_A506CCEstado ;
      private DateTime[] P00EA7_A508CCFVcto ;
      private string[] P00EA7_A188CCCliCod ;
      private decimal[] P00EA7_A509CCImpPago ;
      private decimal[] P00EA7_A513CCImpTotal ;
      private short[] P00EA7_A511TipSigno ;
      private bool[] P00EA7_n511TipSigno ;
      private string[] P00EA7_A185CCDocNum ;
      private string[] P00EA8_A184CCTipCod ;
      private string[] P00EA8_A506CCEstado ;
      private DateTime[] P00EA8_A508CCFVcto ;
      private string[] P00EA8_A188CCCliCod ;
      private decimal[] P00EA8_A509CCImpPago ;
      private decimal[] P00EA8_A513CCImpTotal ;
      private short[] P00EA8_A511TipSigno ;
      private bool[] P00EA8_n511TipSigno ;
      private string[] P00EA8_A185CCDocNum ;
      private string[] P00EA9_A184CCTipCod ;
      private string[] P00EA9_A506CCEstado ;
      private DateTime[] P00EA9_A508CCFVcto ;
      private string[] P00EA9_A188CCCliCod ;
      private decimal[] P00EA9_A509CCImpPago ;
      private decimal[] P00EA9_A513CCImpTotal ;
      private short[] P00EA9_A511TipSigno ;
      private bool[] P00EA9_n511TipSigno ;
      private string[] P00EA9_A185CCDocNum ;
      private string[] P00EA10_A184CCTipCod ;
      private string[] P00EA10_A506CCEstado ;
      private DateTime[] P00EA10_A508CCFVcto ;
      private string[] P00EA10_A188CCCliCod ;
      private decimal[] P00EA10_A509CCImpPago ;
      private decimal[] P00EA10_A513CCImpTotal ;
      private short[] P00EA10_A511TipSigno ;
      private bool[] P00EA10_n511TipSigno ;
      private string[] P00EA10_A185CCDocNum ;
      private string[] P00EA11_A1120LetCTipo ;
      private string[] P00EA11_A209LetCDocNum ;
      private bool[] P00EA11_n209LetCDocNum ;
      private string[] P00EA11_A1105LetCBanNum ;
      private int[] P00EA11_A1116LetCSec ;
      private int[] P00EA11_A1104LetCBanCod ;
      private string[] P00EA11_A204LetCLetCod ;
      private int[] P00EA11_A207LetCItem ;
      private int[] P00EA12_A158ZonCod ;
      private bool[] P00EA12_n158ZonCod ;
      private string[] P00EA12_A2094ZonDsc ;
      private int[] P00EA13_A372BanCod ;
      private string[] P00EA13_A481BanAbr ;
      private string[] P00EA14_A506CCEstado ;
      private DateTime[] P00EA14_A190CCFech ;
      private string[] P00EA14_A185CCDocNum ;
      private int[] P00EA14_A186CCVendCod ;
      private int[] P00EA14_A158ZonCod ;
      private bool[] P00EA14_n158ZonCod ;
      private string[] P00EA14_A184CCTipCod ;
      private int[] P00EA14_A187CCmonCod ;
      private string[] P00EA14_A188CCCliCod ;
      private short[] P00EA14_A511TipSigno ;
      private bool[] P00EA14_n511TipSigno ;
      private decimal[] P00EA14_A513CCImpTotal ;
      private decimal[] P00EA14_A509CCImpPago ;
      private int[] P00EA15_A137Conpcod ;
      private bool[] P00EA15_n137Conpcod ;
      private string[] P00EA15_A753ConpDsc ;
      private string[] P00EA16_A45CliCod ;
      private string[] P00EA16_A578CliConDsc ;
      private int[] P00EA16_A163CliConCod ;
   }

   public class rrcuentasxcobrarformato2__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EA2( IGxContext context ,
                                             string AV19CliCod ,
                                             int AV66MonCod ,
                                             string AV79TipCod ,
                                             int AV97ZonCod ,
                                             int AV96VenCod ,
                                             string AV75Serie ,
                                             short AV81TipLetras ,
                                             string A188CCCliCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A186CCVendCod ,
                                             string A185CCDocNum ,
                                             DateTime A190CCFech ,
                                             DateTime AV39FHasta ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T4.[CliVend] AS CliVend, T4.[PaiCod], T4.[EstCod], T4.[ProvCod], T4.[DisCod], T1.[CCCliDsc], T1.[CCDocNum], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCmonCod] AS CCmonCod, T2.[MonAbr], T1.[CCFech], T1.[CCTipCod] AS CCTipCod, T1.[CCFVcto], T1.[CCEstado], T1.[CCVendCod], T4.[ZonCod], T1.[CCCliCod] AS CCCliCod, T4.[CliDir], T6.[EstDsc], T7.[ProvDsc], T8.[DisDsc], T4.[CliTel1], T4.[CliEma], T4.[CliLim], T5.[VenDsc] AS CliVendDsc, T4.[Conpcod] FROM ((((((([CLCUENTACOBRAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[CCCliCod]) LEFT JOIN [CVENDEDORES] T5 ON T5.[VenCod] = T4.[CliVend]) LEFT JOIN [CESTADOS] T6 ON T6.[PaiCod] = T4.[PaiCod] AND T6.[EstCod] = T4.[EstCod]) LEFT JOIN [CPROVINCIA] T7 ON T7.[PaiCod] = T4.[PaiCod] AND T7.[EstCod] = T4.[EstCod] AND T7.[ProvCod] = T4.[ProvCod]) LEFT JOIN [CDISTRITOS] T8 ON T8.[PaiCod] = T4.[PaiCod] AND T8.[EstCod] = T4.[EstCod] AND T8.[ProvCod] = T4.[ProvCod] AND T8.[DisCod] = T4.[DisCod])";
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV39FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] <> 'A')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV19CliCod)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV66MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV66MonCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV79TipCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV97ZonCod) )
         {
            AddWhere(sWhereString, "(T4.[ZonCod] = @AV97ZonCod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV96VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV96VenCod)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CCDocNum], 1, 3) = @AV75Serie)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV81TipLetras) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] <> 'LET')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCFVcto], T1.[CCTipCod]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00EA3( IGxContext context ,
                                             string AV19CliCod ,
                                             int AV78TipCCod ,
                                             int AV66MonCod ,
                                             string AV79TipCod ,
                                             int AV97ZonCod ,
                                             int AV96VenCod ,
                                             short AV81TipLetras ,
                                             string AV75Serie ,
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
         short[] GXv_int4 = new short[7];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T4.[CliVend] AS CliVend, T4.[PaiCod], T4.[EstCod], T4.[ProvCod], T4.[DisCod], T1.[CCCliDsc], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCDocNum], T1.[CCmonCod] AS CCmonCod, T2.[MonAbr], T1.[CCFech], T1.[CCTipCod] AS CCTipCod, T1.[CCFVcto], T1.[CCEstado], T1.[CCVendCod], T4.[ZonCod], T4.[TipCCod], T1.[CCCliCod] AS CCCliCod, T4.[CliDir], T6.[EstDsc], T7.[ProvDsc], T8.[DisDsc], T4.[CliTel1], T4.[CliEma], T4.[CliLim], T5.[VenDsc] AS CliVendDsc, T4.[Conpcod] FROM ((((((([CLCUENTACOBRAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[CCCliCod]) LEFT JOIN [CVENDEDORES] T5 ON T5.[VenCod] = T4.[CliVend]) LEFT JOIN [CESTADOS] T6 ON T6.[PaiCod] = T4.[PaiCod] AND T6.[EstCod] = T4.[EstCod]) LEFT JOIN [CPROVINCIA] T7 ON T7.[PaiCod] = T4.[PaiCod] AND T7.[EstCod] = T4.[EstCod] AND T7.[ProvCod] = T4.[ProvCod]) LEFT JOIN [CDISTRITOS] T8 ON T8.[PaiCod] = T4.[PaiCod] AND T8.[EstCod] = T4.[EstCod] AND T8.[ProvCod] = T4.[ProvCod] AND T8.[DisCod] = T4.[DisCod])";
         AddWhere(sWhereString, "(T1.[CCEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV19CliCod)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV78TipCCod) )
         {
            AddWhere(sWhereString, "(T4.[TipCCod] = @AV78TipCCod)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV66MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV66MonCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV79TipCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV97ZonCod) )
         {
            AddWhere(sWhereString, "(T4.[ZonCod] = @AV97ZonCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV96VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV96VenCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV81TipLetras) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] <> 'LET')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CCDocNum], 1, 3) = @AV75Serie)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCFVcto], T1.[CCTipCod]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00EA4( IGxContext context ,
                                             int AV78TipCCod ,
                                             int AV66MonCod ,
                                             int AV97ZonCod ,
                                             int AV96VenCod ,
                                             short AV81TipLetras ,
                                             string AV75Serie ,
                                             int A159TipCCod ,
                                             int A187CCmonCod ,
                                             int A158ZonCod ,
                                             int A186CCVendCod ,
                                             string A184CCTipCod ,
                                             string A185CCDocNum ,
                                             string A188CCCliCod ,
                                             string AV15CCCliCod ,
                                             string AV79TipCod ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[7];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliDsc], T1.[CCDocNum], T2.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCmonCod] AS CCmonCod, T1.[CCFVcto], T1.[CCFech], T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T1.[CCVendCod], T3.[ZonCod], T3.[TipCCod], T1.[CCCliCod] AS CCCliCod FROM (([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T1.[CCCliCod] = @AV15CCCliCod)");
         AddWhere(sWhereString, "(T1.[CCTipCod] = @AV79TipCod)");
         AddWhere(sWhereString, "(T1.[CCEstado] = '')");
         if ( ! (0==AV78TipCCod) )
         {
            AddWhere(sWhereString, "(T3.[TipCCod] = @AV78TipCCod)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! (0==AV66MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV66MonCod)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV97ZonCod) )
         {
            AddWhere(sWhereString, "(T3.[ZonCod] = @AV97ZonCod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (0==AV96VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV96VenCod)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV81TipLetras) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] <> 'LET')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CCDocNum], 1, 3) = @AV75Serie)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCTipCod], T1.[CCFech]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00EA14( IGxContext context ,
                                              int AV66MonCod ,
                                              string AV79TipCod ,
                                              int AV97ZonCod ,
                                              int AV96VenCod ,
                                              string AV75Serie ,
                                              short AV81TipLetras ,
                                              int A187CCmonCod ,
                                              string A184CCTipCod ,
                                              int A158ZonCod ,
                                              int A186CCVendCod ,
                                              string A185CCDocNum ,
                                              DateTime A190CCFech ,
                                              DateTime AV39FHasta ,
                                              string A506CCEstado ,
                                              string A188CCCliCod ,
                                              string AV15CCCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[7];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[CCEstado], T1.[CCFech], T1.[CCDocNum], T1.[CCVendCod], T3.[ZonCod], T1.[CCTipCod] AS CCTipCod, T1.[CCmonCod] AS CCmonCod, T1.[CCCliCod] AS CCCliCod, T2.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago] FROM (([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV39FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] <> 'A')");
         AddWhere(sWhereString, "(T1.[CCCliCod] = @AV15CCCliCod)");
         if ( ! (0==AV66MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV66MonCod)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV79TipCod)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! (0==AV97ZonCod) )
         {
            AddWhere(sWhereString, "(T3.[ZonCod] = @AV97ZonCod)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! (0==AV96VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV96VenCod)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CCDocNum], 1, 3) = @AV75Serie)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! (0==AV81TipLetras) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] <> 'LET')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCTipCod], T1.[CCDocNum]";
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
                     return conditional_P00EA2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (string)dynConstraints[15] );
               case 1 :
                     return conditional_P00EA3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 2 :
                     return conditional_P00EA4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 12 :
                     return conditional_P00EA14(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
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
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00EA5;
          prmP00EA5 = new Object[] {
          new ParDef("@AV18CCTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV16CCDocNum",GXType.NChar,12,0) ,
          new ParDef("@AV39FHasta",GXType.Date,8,0)
          };
          Object[] prmP00EA6;
          prmP00EA6 = new Object[] {
          new ParDef("@AV15CCCliCod",GXType.NChar,20,0)
          };
          Object[] prmP00EA7;
          prmP00EA7 = new Object[] {
          new ParDef("@AV15CCCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV38FechaInicio",GXType.Date,8,0)
          };
          Object[] prmP00EA8;
          prmP00EA8 = new Object[] {
          new ParDef("@AV15CCCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV11Ano2",GXType.Int16,4,0) ,
          new ParDef("@AV62Mes2",GXType.Int16,2,0)
          };
          Object[] prmP00EA9;
          prmP00EA9 = new Object[] {
          new ParDef("@AV15CCCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV12Ano3",GXType.Int16,4,0) ,
          new ParDef("@AV63Mes3",GXType.Int16,2,0)
          };
          Object[] prmP00EA10;
          prmP00EA10 = new Object[] {
          new ParDef("@AV15CCCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV13Ano4",GXType.Int16,4,0) ,
          new ParDef("@AV64Mes4",GXType.Int16,2,0)
          };
          Object[] prmP00EA11;
          prmP00EA11 = new Object[] {
          new ParDef("@AV16CCDocNum",GXType.NChar,12,0)
          };
          Object[] prmP00EA12;
          prmP00EA12 = new Object[] {
          new ParDef("@AV21CliZon",GXType.Int32,6,0)
          };
          Object[] prmP00EA13;
          prmP00EA13 = new Object[] {
          new ParDef("@AV56LetCBanCod",GXType.Int32,6,0)
          };
          Object[] prmP00EA15;
          prmP00EA15 = new Object[] {
          new ParDef("@AV29ConpCod",GXType.Int32,6,0)
          };
          Object[] prmP00EA16;
          prmP00EA16 = new Object[] {
          new ParDef("@AV15CCCliCod",GXType.NChar,20,0)
          };
          Object[] prmP00EA2;
          prmP00EA2 = new Object[] {
          new ParDef("@AV39FHasta",GXType.Date,8,0) ,
          new ParDef("@AV19CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV66MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV79TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV97ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV96VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV75Serie",GXType.Char,3,0)
          };
          Object[] prmP00EA3;
          prmP00EA3 = new Object[] {
          new ParDef("@AV19CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV78TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV66MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV79TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV97ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV96VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV75Serie",GXType.Char,3,0)
          };
          Object[] prmP00EA4;
          prmP00EA4 = new Object[] {
          new ParDef("@AV15CCCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV79TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV78TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV66MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV97ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV96VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV75Serie",GXType.Char,3,0)
          };
          Object[] prmP00EA14;
          prmP00EA14 = new Object[] {
          new ParDef("@AV39FHasta",GXType.Date,8,0) ,
          new ParDef("@AV15CCCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV66MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV79TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV97ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV96VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV75Serie",GXType.Char,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EA2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EA3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EA4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EA5", "SELECT T1.[CobTip], T1.[CobCod], T2.[CobSts], T2.[CobFec], T1.[CobDocNum], T1.[CobTipCod], T2.[CobMon], T1.[CobDTot], T1.[CobTipCam], T1.[Item] FROM ([CLCOBRANZADET] T1 INNER JOIN [CLCOBRANZA] T2 ON T2.[CobTip] = T1.[CobTip] AND T2.[CobCod] = T1.[CobCod]) WHERE (T1.[CobTipCod] = @AV18CCTipCod and T1.[CobDocNum] = @AV16CCDocNum) AND (T2.[CobFec] > @AV39FHasta) AND (T2.[CobSts] <> 'A') ORDER BY T1.[CobTipCod], T1.[CobDocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EA6", "SELECT T1.[CCDocNum], T1.[CCTipCod] AS CCTipCod, T1.[CCCliCod] AS CCCliCod, T2.[TipDsc] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod]) WHERE T1.[CCCliCod] = @AV15CCCliCod ORDER BY T1.[CCTipCod], T1.[CCDocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EA7", "SELECT T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T1.[CCFVcto], T1.[CCCliCod] AS CCCliCod, T1.[CCImpPago], T1.[CCImpTotal], T2.[TipSigno], T1.[CCDocNum] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod]) WHERE (T1.[CCCliCod] = @AV15CCCliCod) AND (T1.[CCFVcto] < @AV38FechaInicio) AND (T1.[CCEstado] = '') ORDER BY T1.[CCCliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EA8", "SELECT T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T1.[CCFVcto], T1.[CCCliCod] AS CCCliCod, T1.[CCImpPago], T1.[CCImpTotal], T2.[TipSigno], T1.[CCDocNum] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod]) WHERE (T1.[CCCliCod] = @AV15CCCliCod) AND (YEAR(T1.[CCFVcto]) = @AV11Ano2) AND (MONTH(T1.[CCFVcto]) = @AV62Mes2) AND (T1.[CCEstado] = '') ORDER BY T1.[CCCliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EA9", "SELECT T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T1.[CCFVcto], T1.[CCCliCod] AS CCCliCod, T1.[CCImpPago], T1.[CCImpTotal], T2.[TipSigno], T1.[CCDocNum] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod]) WHERE (T1.[CCCliCod] = @AV15CCCliCod) AND (YEAR(T1.[CCFVcto]) = @AV12Ano3) AND (MONTH(T1.[CCFVcto]) = @AV63Mes3) AND (T1.[CCEstado] = '') ORDER BY T1.[CCCliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EA10", "SELECT T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T1.[CCFVcto], T1.[CCCliCod] AS CCCliCod, T1.[CCImpPago], T1.[CCImpTotal], T2.[TipSigno], T1.[CCDocNum] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod]) WHERE (T1.[CCCliCod] = @AV15CCCliCod) AND (YEAR(T1.[CCFVcto]) = @AV13Ano4) AND (MONTH(T1.[CCFVcto]) = @AV64Mes4) AND (T1.[CCEstado] = '') ORDER BY T1.[CCCliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA10,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EA11", "SELECT [LetCTipo], [LetCDocNum], [LetCBanNum], [LetCSec], [LetCBanCod], [LetCLetCod], [LetCItem] FROM [CLLETRASDET] WHERE ([LetCDocNum] = @AV16CCDocNum) AND ([LetCTipo] = 'L') ORDER BY [LetCLetCod], [LetCItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EA12", "SELECT [ZonCod], [ZonDsc] FROM [CZONAS] WHERE [ZonCod] = @AV21CliZon ORDER BY [ZonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA12,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EA13", "SELECT [BanCod], [BanAbr] FROM [TSBANCOS] WHERE [BanCod] = @AV56LetCBanCod ORDER BY [BanCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA13,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EA14", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EA15", "SELECT [Conpcod], [ConpDsc] FROM [CCONDICIONPAGO] WHERE [Conpcod] = @AV29ConpCod ORDER BY [Conpcod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA15,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EA16", "SELECT TOP 1 [CliCod], [CliConDsc], [CliConCod] FROM [CLCLIENTESCONTACTOS] WHERE [CliCod] = @AV15CCCliCod ORDER BY [CliCod], [CliConCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA16,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 4);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 4);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 4);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getString(6, 100);
                ((string[]) buf[11])[0] = rslt.getString(7, 12);
                ((short[]) buf[12])[0] = rslt.getShort(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(10);
                ((int[]) buf[16])[0] = rslt.getInt(11);
                ((string[]) buf[17])[0] = rslt.getString(12, 5);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(13);
                ((string[]) buf[20])[0] = rslt.getString(14, 3);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(15);
                ((string[]) buf[22])[0] = rslt.getString(16, 1);
                ((int[]) buf[23])[0] = rslt.getInt(17);
                ((int[]) buf[24])[0] = rslt.getInt(18);
                ((bool[]) buf[25])[0] = rslt.wasNull(18);
                ((string[]) buf[26])[0] = rslt.getString(19, 20);
                ((string[]) buf[27])[0] = rslt.getString(20, 100);
                ((bool[]) buf[28])[0] = rslt.wasNull(20);
                ((string[]) buf[29])[0] = rslt.getString(21, 100);
                ((string[]) buf[30])[0] = rslt.getString(22, 100);
                ((string[]) buf[31])[0] = rslt.getString(23, 100);
                ((string[]) buf[32])[0] = rslt.getString(24, 20);
                ((bool[]) buf[33])[0] = rslt.wasNull(24);
                ((string[]) buf[34])[0] = rslt.getVarchar(25);
                ((bool[]) buf[35])[0] = rslt.wasNull(25);
                ((decimal[]) buf[36])[0] = rslt.getDecimal(26);
                ((bool[]) buf[37])[0] = rslt.wasNull(26);
                ((string[]) buf[38])[0] = rslt.getString(27, 100);
                ((int[]) buf[39])[0] = rslt.getInt(28);
                ((bool[]) buf[40])[0] = rslt.wasNull(28);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 4);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 4);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 4);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getString(6, 100);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(9);
                ((string[]) buf[15])[0] = rslt.getString(10, 12);
                ((int[]) buf[16])[0] = rslt.getInt(11);
                ((string[]) buf[17])[0] = rslt.getString(12, 5);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(13);
                ((string[]) buf[20])[0] = rslt.getString(14, 3);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(15);
                ((string[]) buf[22])[0] = rslt.getString(16, 1);
                ((int[]) buf[23])[0] = rslt.getInt(17);
                ((int[]) buf[24])[0] = rslt.getInt(18);
                ((bool[]) buf[25])[0] = rslt.wasNull(18);
                ((int[]) buf[26])[0] = rslt.getInt(19);
                ((bool[]) buf[27])[0] = rslt.wasNull(19);
                ((string[]) buf[28])[0] = rslt.getString(20, 20);
                ((string[]) buf[29])[0] = rslt.getString(21, 100);
                ((bool[]) buf[30])[0] = rslt.wasNull(21);
                ((string[]) buf[31])[0] = rslt.getString(22, 100);
                ((string[]) buf[32])[0] = rslt.getString(23, 100);
                ((string[]) buf[33])[0] = rslt.getString(24, 100);
                ((string[]) buf[34])[0] = rslt.getString(25, 20);
                ((bool[]) buf[35])[0] = rslt.wasNull(25);
                ((string[]) buf[36])[0] = rslt.getVarchar(26);
                ((bool[]) buf[37])[0] = rslt.wasNull(26);
                ((decimal[]) buf[38])[0] = rslt.getDecimal(27);
                ((bool[]) buf[39])[0] = rslt.wasNull(27);
                ((string[]) buf[40])[0] = rslt.getString(28, 100);
                ((int[]) buf[41])[0] = rslt.getInt(29);
                ((bool[]) buf[42])[0] = rslt.wasNull(29);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 3);
                ((string[]) buf[10])[0] = rslt.getString(10, 1);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                ((bool[]) buf[15])[0] = rslt.wasNull(13);
                ((string[]) buf[16])[0] = rslt.getString(14, 20);
                return;
             case 3 :
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
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 12);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 12);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 12);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 12);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 10);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 3);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
