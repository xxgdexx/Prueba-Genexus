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
   public class rrreportetotalescobranzaorigen : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrreportetotalescobranzaorigen.aspx")), "rrreportetotalescobranzaorigen.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrreportetotalescobranzaorigen.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "FDesde");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV10FDesde = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV12CliCod = GetPar( "CliCod");
                  AV32ForCod1 = (int)(NumberUtil.Val( GetPar( "ForCod1"), "."));
                  AV14MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV24TipCod = GetPar( "TipCod");
                  AV36VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
                  AV37Serie = GetPar( "Serie");
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

      public rrreportetotalescobranzaorigen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrreportetotalescobranzaorigen( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FDesde ,
                           ref DateTime aP1_FHasta ,
                           ref string aP2_CliCod ,
                           ref int aP3_ForCod1 ,
                           ref int aP4_MonCod ,
                           ref string aP5_TipCod ,
                           ref int aP6_VenCod ,
                           ref string aP7_Serie )
      {
         this.AV10FDesde = aP0_FDesde;
         this.AV11FHasta = aP1_FHasta;
         this.AV12CliCod = aP2_CliCod;
         this.AV32ForCod1 = aP3_ForCod1;
         this.AV14MonCod = aP4_MonCod;
         this.AV24TipCod = aP5_TipCod;
         this.AV36VenCod = aP6_VenCod;
         this.AV37Serie = aP7_Serie;
         initialize();
         executePrivate();
         aP0_FDesde=this.AV10FDesde;
         aP1_FHasta=this.AV11FHasta;
         aP2_CliCod=this.AV12CliCod;
         aP3_ForCod1=this.AV32ForCod1;
         aP4_MonCod=this.AV14MonCod;
         aP5_TipCod=this.AV24TipCod;
         aP6_VenCod=this.AV36VenCod;
         aP7_Serie=this.AV37Serie;
      }

      public string executeUdp( ref DateTime aP0_FDesde ,
                                ref DateTime aP1_FHasta ,
                                ref string aP2_CliCod ,
                                ref int aP3_ForCod1 ,
                                ref int aP4_MonCod ,
                                ref string aP5_TipCod ,
                                ref int aP6_VenCod )
      {
         execute(ref aP0_FDesde, ref aP1_FHasta, ref aP2_CliCod, ref aP3_ForCod1, ref aP4_MonCod, ref aP5_TipCod, ref aP6_VenCod, ref aP7_Serie);
         return AV37Serie ;
      }

      public void executeSubmit( ref DateTime aP0_FDesde ,
                                 ref DateTime aP1_FHasta ,
                                 ref string aP2_CliCod ,
                                 ref int aP3_ForCod1 ,
                                 ref int aP4_MonCod ,
                                 ref string aP5_TipCod ,
                                 ref int aP6_VenCod ,
                                 ref string aP7_Serie )
      {
         rrreportetotalescobranzaorigen objrrreportetotalescobranzaorigen;
         objrrreportetotalescobranzaorigen = new rrreportetotalescobranzaorigen();
         objrrreportetotalescobranzaorigen.AV10FDesde = aP0_FDesde;
         objrrreportetotalescobranzaorigen.AV11FHasta = aP1_FHasta;
         objrrreportetotalescobranzaorigen.AV12CliCod = aP2_CliCod;
         objrrreportetotalescobranzaorigen.AV32ForCod1 = aP3_ForCod1;
         objrrreportetotalescobranzaorigen.AV14MonCod = aP4_MonCod;
         objrrreportetotalescobranzaorigen.AV24TipCod = aP5_TipCod;
         objrrreportetotalescobranzaorigen.AV36VenCod = aP6_VenCod;
         objrrreportetotalescobranzaorigen.AV37Serie = aP7_Serie;
         objrrreportetotalescobranzaorigen.context.SetSubmitInitialConfig(context);
         objrrreportetotalescobranzaorigen.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrreportetotalescobranzaorigen);
         aP0_FDesde=this.AV10FDesde;
         aP1_FHasta=this.AV11FHasta;
         aP2_CliCod=this.AV12CliCod;
         aP3_ForCod1=this.AV32ForCod1;
         aP4_MonCod=this.AV14MonCod;
         aP5_TipCod=this.AV24TipCod;
         aP6_VenCod=this.AV36VenCod;
         aP7_Serie=this.AV37Serie;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrreportetotalescobranzaorigen)stateInfo).executePrivate();
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
            AV21Empresa = AV22Session.Get("Empresa");
            AV20EmpDir = AV22Session.Get("EmpDir");
            AV33EmpRUC = AV22Session.Get("EmpRUC");
            AV34Ruta = AV22Session.Get("RUTA") + "/Logo.jpg";
            AV35Logo = AV34Ruta;
            AV57Logo_GXI = GXDbFile.PathToUrl( AV34Ruta);
            AV38Filtro1 = "(Todos)";
            /* Using cursor P00E42 */
            pr_default.execute(0, new Object[] {AV36VenCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A309VenCod = P00E42_A309VenCod[0];
               A2045VenDsc = P00E42_A2045VenDsc[0];
               AV38Filtro1 = StringUtil.Trim( A2045VenDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV28TTotalMN = 0.00m;
            AV29TTotalME = 0.00m;
            AV30TTotalMO = 0.00m;
            /* Execute user subroutine: 'DETALLADO' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            HE40( false, 74) ;
            getPrinter().GxDrawLine(434, Gx_line+8, 800, Gx_line+8, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Cobranza", 328, Gx_line+18, 418, Gx_line+32, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28TTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 422, Gx_line+16, 529, Gx_line+31, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29TTotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 540, Gx_line+16, 647, Gx_line+31, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV30TTotalMO, "ZZZZZZ,ZZZ,ZZ9.99")), 657, Gx_line+16, 764, Gx_line+31, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+74);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HE40( true, 0) ;
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
         /* 'DETALLADO' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV32ForCod1 ,
                                              A143ForCod ,
                                              AV13ForCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00E43 */
         pr_default.execute(1, new Object[] {AV13ForCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A143ForCod = P00E43_A143ForCod[0];
            A988ForDsc = P00E43_A988ForDsc[0];
            AV13ForCod = A143ForCod;
            AV23ForDsc = A988ForDsc;
            AV51ForDscTotales = "Totales " + StringUtil.Trim( AV23ForDsc);
            AV25TotalMN = 0.00m;
            AV26TotalME = 0.00m;
            AV27TotalMO = 0.00m;
            /* Execute user subroutine: 'VALIDAFORMAPAGO' */
            S124 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            if ( AV50FlagFor == 1 )
            {
               HE40( false, 20) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23ForDsc, "")), 33, Gx_line+2, 385, Gx_line+16, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
            /* Execute user subroutine: 'TIPODOCUMENTO' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV28TTotalMN = (decimal)(AV28TTotalMN+AV25TotalMN);
            AV29TTotalME = (decimal)(AV29TTotalME+AV26TotalME);
            AV30TTotalMO = (decimal)(AV30TTotalMO+AV27TotalMO);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S124( )
      {
         /* 'VALIDAFORMAPAGO' Routine */
         returnInSub = false;
         AV50FlagFor = 0;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV12CliCod ,
                                              AV14MonCod ,
                                              AV36VenCod ,
                                              AV37Serie ,
                                              A645CobCliCod ,
                                              A658CobMonOrigen ,
                                              A171CobVendCod ,
                                              A176CobDocNum ,
                                              A655CobFec ,
                                              AV10FDesde ,
                                              AV11FHasta ,
                                              A661CobSts ,
                                              A143ForCod ,
                                              AV13ForCod ,
                                              A166CobTip } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00E44 */
         pr_default.execute(2, new Object[] {AV10FDesde, AV11FHasta, AV13ForCod, AV12CliCod, AV14MonCod, AV36VenCod, AV37Serie});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A167CobCod = P00E44_A167CobCod[0];
            A175CobTipCod = P00E44_A175CobTipCod[0];
            A661CobSts = P00E44_A661CobSts[0];
            A176CobDocNum = P00E44_A176CobDocNum[0];
            A143ForCod = P00E44_A143ForCod[0];
            A171CobVendCod = P00E44_A171CobVendCod[0];
            A658CobMonOrigen = P00E44_A658CobMonOrigen[0];
            A645CobCliCod = P00E44_A645CobCliCod[0];
            A655CobFec = P00E44_A655CobFec[0];
            A166CobTip = P00E44_A166CobTip[0];
            A173Item = P00E44_A173Item[0];
            A658CobMonOrigen = P00E44_A658CobMonOrigen[0];
            A645CobCliCod = P00E44_A645CobCliCod[0];
            A661CobSts = P00E44_A661CobSts[0];
            A171CobVendCod = P00E44_A171CobVendCod[0];
            A655CobFec = P00E44_A655CobFec[0];
            AV50FlagFor = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S134( )
      {
         /* 'TIPODOCUMENTO' Routine */
         returnInSub = false;
         /* Using cursor P00E45 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A1919TipSts = P00E45_A1919TipSts[0];
            A1910TipDsc = P00E45_A1910TipDsc[0];
            A149TipCod = P00E45_A149TipCod[0];
            AV24TipCod = A149TipCod;
            AV46TipDsc = StringUtil.Trim( A1910TipDsc);
            /* Execute user subroutine: 'TOTALESDOCUMENTO' */
            S146 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            if ( ! (Convert.ToDecimal(0)==AV49MO) )
            {
               HE40( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TipDsc, "")), 88, Gx_line+1, 428, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47MN, "ZZZZZZ,ZZZ,ZZ9.99")), 422, Gx_line+1, 529, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48ME, "ZZZZZZ,ZZZ,ZZ9.99")), 540, Gx_line+1, 647, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49MO, "ZZZZZZ,ZZZ,ZZ9.99")), 657, Gx_line+1, 764, Gx_line+16, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV25TotalMN = (decimal)(AV25TotalMN+AV47MN);
               AV26TotalME = (decimal)(AV26TotalME+AV48ME);
               AV27TotalMO = (decimal)(AV27TotalMO+AV49MO);
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S146( )
      {
         /* 'TOTALESDOCUMENTO' Routine */
         returnInSub = false;
         AV47MN = 0.00m;
         AV48ME = 0.00m;
         AV49MO = 0.00m;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV12CliCod ,
                                              AV14MonCod ,
                                              AV36VenCod ,
                                              AV37Serie ,
                                              A645CobCliCod ,
                                              A658CobMonOrigen ,
                                              A171CobVendCod ,
                                              A176CobDocNum ,
                                              A655CobFec ,
                                              AV10FDesde ,
                                              AV11FHasta ,
                                              A661CobSts ,
                                              A175CobTipCod ,
                                              AV24TipCod ,
                                              A143ForCod ,
                                              AV13ForCod ,
                                              A166CobTip } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00E46 */
         pr_default.execute(4, new Object[] {AV10FDesde, AV11FHasta, AV24TipCod, AV13ForCod, AV12CliCod, AV14MonCod, AV36VenCod, AV37Serie});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A167CobCod = P00E46_A167CobCod[0];
            A661CobSts = P00E46_A661CobSts[0];
            A143ForCod = P00E46_A143ForCod[0];
            A175CobTipCod = P00E46_A175CobTipCod[0];
            A176CobDocNum = P00E46_A176CobDocNum[0];
            A171CobVendCod = P00E46_A171CobVendCod[0];
            A658CobMonOrigen = P00E46_A658CobMonOrigen[0];
            A645CobCliCod = P00E46_A645CobCliCod[0];
            A655CobFec = P00E46_A655CobFec[0];
            A166CobTip = P00E46_A166CobTip[0];
            A654CobDTot = P00E46_A654CobDTot[0];
            A663CobTipCam = P00E46_A663CobTipCam[0];
            A172CobMon = P00E46_A172CobMon[0];
            A173Item = P00E46_A173Item[0];
            A658CobMonOrigen = P00E46_A658CobMonOrigen[0];
            A645CobCliCod = P00E46_A645CobCliCod[0];
            A661CobSts = P00E46_A661CobSts[0];
            A171CobVendCod = P00E46_A171CobVendCod[0];
            A655CobFec = P00E46_A655CobFec[0];
            A172CobMon = P00E46_A172CobMon[0];
            AV17CobDTot = A654CobDTot;
            AV31CobTipCam = A663CobTipCam;
            AV52DocFec = A655CobFec;
            AV53ImporteMN = 0.00m;
            AV54ImporteME = 0.00m;
            if ( A172CobMon != A658CobMonOrigen )
            {
               if ( A172CobMon == 1 )
               {
                  AV54ImporteME = NumberUtil.Round( AV17CobDTot/ (decimal)(AV31CobTipCam), 2);
               }
               else
               {
                  AV53ImporteMN = NumberUtil.Round( AV17CobDTot*AV31CobTipCam, 2);
               }
            }
            else
            {
               AV53ImporteMN = ((A172CobMon==1) ? AV17CobDTot : (decimal)(0));
               AV54ImporteME = ((A172CobMon==1) ? (decimal)(0) : AV17CobDTot);
            }
            AV47MN = (decimal)(AV47MN+AV53ImporteMN);
            AV48ME = (decimal)(AV48ME+AV54ImporteME);
            if ( A172CobMon == A658CobMonOrigen )
            {
               GXt_decimal1 = AV31CobTipCam;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV52DocFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV31CobTipCam = GXt_decimal1;
            }
            AV49MO = (decimal)(AV49MO+(((A172CobMon==1) ? AV17CobDTot : NumberUtil.Round( AV17CobDTot*AV31CobTipCam, 2))));
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void HE40( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Totales de Cobranza", 342, Gx_line+14, 518, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 672, Gx_line+56, 716, Gx_line+70, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hora:", 672, Gx_line+38, 704, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 672, Gx_line+20, 711, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 718, Gx_line+20, 765, Gx_line+35, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 700, Gx_line+38, 764, Gx_line+53, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 726, Gx_line+56, 765, Gx_line+71, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+150, 799, Gx_line+180, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 19, Gx_line+157, 60, Gx_line+171, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Forma de Pago", 124, Gx_line+159, 213, Gx_line+173, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe MN", 454, Gx_line+159, 525, Gx_line+173, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe ME", 570, Gx_line+158, 640, Gx_line+172, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Expresado MN", 678, Gx_line+157, 761, Gx_line+171, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33EmpRUC, "")), 17, Gx_line+128, 318, Gx_line+146, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20EmpDir, "")), 17, Gx_line+111, 321, Gx_line+129, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21Empresa, "")), 17, Gx_line+94, 320, Gx_line+112, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV35Logo)) ? AV57Logo_GXI : AV35Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+9, 176, Gx_line+87) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde :", 267, Gx_line+45, 319, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta :", 417, Gx_line+45, 467, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV10FDesde, "99/99/99"), 332, Gx_line+45, 387, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV11FHasta, "99/99/99"), 483, Gx_line+45, 538, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cobrador :", 246, Gx_line+69, 319, Gx_line+87, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38Filtro1, "")), 332, Gx_line+68, 555, Gx_line+88, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+180);
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
         AV21Empresa = "";
         AV22Session = context.GetSession();
         AV20EmpDir = "";
         AV33EmpRUC = "";
         AV34Ruta = "";
         AV35Logo = "";
         AV57Logo_GXI = "";
         AV38Filtro1 = "";
         scmdbuf = "";
         P00E42_A309VenCod = new int[1] ;
         P00E42_A2045VenDsc = new string[] {""} ;
         A2045VenDsc = "";
         P00E43_A143ForCod = new int[1] ;
         P00E43_A988ForDsc = new string[] {""} ;
         A988ForDsc = "";
         AV23ForDsc = "";
         AV51ForDscTotales = "";
         A645CobCliCod = "";
         A176CobDocNum = "";
         A655CobFec = DateTime.MinValue;
         A661CobSts = "";
         A166CobTip = "";
         P00E44_A167CobCod = new string[] {""} ;
         P00E44_A175CobTipCod = new string[] {""} ;
         P00E44_A661CobSts = new string[] {""} ;
         P00E44_A176CobDocNum = new string[] {""} ;
         P00E44_A143ForCod = new int[1] ;
         P00E44_A171CobVendCod = new int[1] ;
         P00E44_A658CobMonOrigen = new int[1] ;
         P00E44_A645CobCliCod = new string[] {""} ;
         P00E44_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         P00E44_A166CobTip = new string[] {""} ;
         P00E44_A173Item = new int[1] ;
         A167CobCod = "";
         A175CobTipCod = "";
         P00E45_A1919TipSts = new short[1] ;
         P00E45_A1910TipDsc = new string[] {""} ;
         P00E45_A149TipCod = new string[] {""} ;
         A1910TipDsc = "";
         A149TipCod = "";
         AV46TipDsc = "";
         P00E46_A167CobCod = new string[] {""} ;
         P00E46_A661CobSts = new string[] {""} ;
         P00E46_A143ForCod = new int[1] ;
         P00E46_A175CobTipCod = new string[] {""} ;
         P00E46_A176CobDocNum = new string[] {""} ;
         P00E46_A171CobVendCod = new int[1] ;
         P00E46_A658CobMonOrigen = new int[1] ;
         P00E46_A645CobCliCod = new string[] {""} ;
         P00E46_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         P00E46_A166CobTip = new string[] {""} ;
         P00E46_A654CobDTot = new decimal[1] ;
         P00E46_A663CobTipCam = new decimal[1] ;
         P00E46_A172CobMon = new int[1] ;
         P00E46_A173Item = new int[1] ;
         AV52DocFec = DateTime.MinValue;
         GXt_char3 = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV35Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrreportetotalescobranzaorigen__default(),
            new Object[][] {
                new Object[] {
               P00E42_A309VenCod, P00E42_A2045VenDsc
               }
               , new Object[] {
               P00E43_A143ForCod, P00E43_A988ForDsc
               }
               , new Object[] {
               P00E44_A167CobCod, P00E44_A175CobTipCod, P00E44_A661CobSts, P00E44_A176CobDocNum, P00E44_A143ForCod, P00E44_A171CobVendCod, P00E44_A658CobMonOrigen, P00E44_A645CobCliCod, P00E44_A655CobFec, P00E44_A166CobTip,
               P00E44_A173Item
               }
               , new Object[] {
               P00E45_A1919TipSts, P00E45_A1910TipDsc, P00E45_A149TipCod
               }
               , new Object[] {
               P00E46_A167CobCod, P00E46_A661CobSts, P00E46_A143ForCod, P00E46_A175CobTipCod, P00E46_A176CobDocNum, P00E46_A171CobVendCod, P00E46_A658CobMonOrigen, P00E46_A645CobCliCod, P00E46_A655CobFec, P00E46_A166CobTip,
               P00E46_A654CobDTot, P00E46_A663CobTipCam, P00E46_A172CobMon, P00E46_A173Item
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
      private short AV50FlagFor ;
      private short A1919TipSts ;
      private int AV32ForCod1 ;
      private int AV14MonCod ;
      private int AV36VenCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A309VenCod ;
      private int Gx_OldLine ;
      private int A143ForCod ;
      private int AV13ForCod ;
      private int A658CobMonOrigen ;
      private int A171CobVendCod ;
      private int A173Item ;
      private int A172CobMon ;
      private int GXt_int2 ;
      private decimal AV28TTotalMN ;
      private decimal AV29TTotalME ;
      private decimal AV30TTotalMO ;
      private decimal AV25TotalMN ;
      private decimal AV26TotalME ;
      private decimal AV27TotalMO ;
      private decimal AV49MO ;
      private decimal AV47MN ;
      private decimal AV48ME ;
      private decimal A654CobDTot ;
      private decimal A663CobTipCam ;
      private decimal AV17CobDTot ;
      private decimal AV31CobTipCam ;
      private decimal AV53ImporteMN ;
      private decimal AV54ImporteME ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV12CliCod ;
      private string AV24TipCod ;
      private string AV37Serie ;
      private string AV21Empresa ;
      private string AV20EmpDir ;
      private string AV33EmpRUC ;
      private string AV34Ruta ;
      private string AV38Filtro1 ;
      private string scmdbuf ;
      private string A2045VenDsc ;
      private string A988ForDsc ;
      private string AV23ForDsc ;
      private string AV51ForDscTotales ;
      private string A645CobCliCod ;
      private string A176CobDocNum ;
      private string A661CobSts ;
      private string A166CobTip ;
      private string A167CobCod ;
      private string A175CobTipCod ;
      private string A1910TipDsc ;
      private string A149TipCod ;
      private string AV46TipDsc ;
      private string GXt_char3 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV10FDesde ;
      private DateTime AV11FHasta ;
      private DateTime A655CobFec ;
      private DateTime AV52DocFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private string AV57Logo_GXI ;
      private string AV35Logo ;
      private string Logo ;
      private IGxSession AV22Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FDesde ;
      private DateTime aP1_FHasta ;
      private string aP2_CliCod ;
      private int aP3_ForCod1 ;
      private int aP4_MonCod ;
      private string aP5_TipCod ;
      private int aP6_VenCod ;
      private string aP7_Serie ;
      private IDataStoreProvider pr_default ;
      private int[] P00E42_A309VenCod ;
      private string[] P00E42_A2045VenDsc ;
      private int[] P00E43_A143ForCod ;
      private string[] P00E43_A988ForDsc ;
      private string[] P00E44_A167CobCod ;
      private string[] P00E44_A175CobTipCod ;
      private string[] P00E44_A661CobSts ;
      private string[] P00E44_A176CobDocNum ;
      private int[] P00E44_A143ForCod ;
      private int[] P00E44_A171CobVendCod ;
      private int[] P00E44_A658CobMonOrigen ;
      private string[] P00E44_A645CobCliCod ;
      private DateTime[] P00E44_A655CobFec ;
      private string[] P00E44_A166CobTip ;
      private int[] P00E44_A173Item ;
      private short[] P00E45_A1919TipSts ;
      private string[] P00E45_A1910TipDsc ;
      private string[] P00E45_A149TipCod ;
      private string[] P00E46_A167CobCod ;
      private string[] P00E46_A661CobSts ;
      private int[] P00E46_A143ForCod ;
      private string[] P00E46_A175CobTipCod ;
      private string[] P00E46_A176CobDocNum ;
      private int[] P00E46_A171CobVendCod ;
      private int[] P00E46_A658CobMonOrigen ;
      private string[] P00E46_A645CobCliCod ;
      private DateTime[] P00E46_A655CobFec ;
      private string[] P00E46_A166CobTip ;
      private decimal[] P00E46_A654CobDTot ;
      private decimal[] P00E46_A663CobTipCam ;
      private int[] P00E46_A172CobMon ;
      private int[] P00E46_A173Item ;
   }

   public class rrreportetotalescobranzaorigen__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E43( IGxContext context ,
                                             int AV32ForCod1 ,
                                             int A143ForCod ,
                                             int AV13ForCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[1];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ForCod], [ForDsc] FROM [CFORMAPAGO]";
         if ( ! (0==AV32ForCod1) )
         {
            AddWhere(sWhereString, "([ForCod] = @AV13ForCod)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ForCod]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00E44( IGxContext context ,
                                             string AV12CliCod ,
                                             int AV14MonCod ,
                                             int AV36VenCod ,
                                             string AV37Serie ,
                                             string A645CobCliCod ,
                                             int A658CobMonOrigen ,
                                             int A171CobVendCod ,
                                             string A176CobDocNum ,
                                             DateTime A655CobFec ,
                                             DateTime AV10FDesde ,
                                             DateTime AV11FHasta ,
                                             string A661CobSts ,
                                             int A143ForCod ,
                                             int AV13ForCod ,
                                             string A166CobTip )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[7];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[CobCod], T1.[CobTipCod] AS CobTipCod, T3.[CobSts], T1.[CobDocNum] AS CobDocNum, T1.[ForCod], T3.[CobVendCod], T2.[CCmonCod] AS CobMonOrigen, T2.[CCCliCod] AS CobCliCod, T3.[CobFec], T1.[CobTip], T1.[Item] FROM (([CLCOBRANZADET] T1 INNER JOIN [CLCUENTACOBRAR] T2 ON T2.[CCTipCod] = T1.[CobTipCod] AND T2.[CCDocNum] = T1.[CobDocNum]) INNER JOIN [CLCOBRANZA] T3 ON T3.[CobTip] = T1.[CobTip] AND T3.[CobCod] = T1.[CobCod])";
         AddWhere(sWhereString, "(T1.[CobTip] = 'C')");
         AddWhere(sWhereString, "(T3.[CobFec] >= @AV10FDesde)");
         AddWhere(sWhereString, "(T3.[CobFec] <= @AV11FHasta)");
         AddWhere(sWhereString, "((T3.[CobSts] = ''))");
         AddWhere(sWhereString, "(T1.[ForCod] = @AV13ForCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[CCCliCod] = @AV12CliCod)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T2.[CCmonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (0==AV36VenCod) )
         {
            AddWhere(sWhereString, "(T3.[CobVendCod] = @AV36VenCod)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CobDocNum], 1, 3) = @AV37Serie)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CobTip]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00E46( IGxContext context ,
                                             string AV12CliCod ,
                                             int AV14MonCod ,
                                             int AV36VenCod ,
                                             string AV37Serie ,
                                             string A645CobCliCod ,
                                             int A658CobMonOrigen ,
                                             int A171CobVendCod ,
                                             string A176CobDocNum ,
                                             DateTime A655CobFec ,
                                             DateTime AV10FDesde ,
                                             DateTime AV11FHasta ,
                                             string A661CobSts ,
                                             string A175CobTipCod ,
                                             string AV24TipCod ,
                                             int A143ForCod ,
                                             int AV13ForCod ,
                                             string A166CobTip )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[8];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[CobCod], T3.[CobSts], T1.[ForCod], T1.[CobTipCod] AS CobTipCod, T1.[CobDocNum] AS CobDocNum, T3.[CobVendCod], T2.[CCmonCod] AS CobMonOrigen, T2.[CCCliCod] AS CobCliCod, T3.[CobFec], T1.[CobTip], T1.[CobDTot], T1.[CobTipCam], T3.[CobMon], T1.[Item] FROM (([CLCOBRANZADET] T1 INNER JOIN [CLCUENTACOBRAR] T2 ON T2.[CCTipCod] = T1.[CobTipCod] AND T2.[CCDocNum] = T1.[CobDocNum]) INNER JOIN [CLCOBRANZA] T3 ON T3.[CobTip] = T1.[CobTip] AND T3.[CobCod] = T1.[CobCod])";
         AddWhere(sWhereString, "(T1.[CobTip] = 'C')");
         AddWhere(sWhereString, "(T3.[CobFec] >= @AV10FDesde)");
         AddWhere(sWhereString, "(T3.[CobFec] <= @AV11FHasta)");
         AddWhere(sWhereString, "((T3.[CobSts] = ''))");
         AddWhere(sWhereString, "(T1.[CobTipCod] = @AV24TipCod)");
         AddWhere(sWhereString, "(T1.[ForCod] = @AV13ForCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[CCCliCod] = @AV12CliCod)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T2.[CCmonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (0==AV36VenCod) )
         {
            AddWhere(sWhereString, "(T3.[CobVendCod] = @AV36VenCod)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CobDocNum], 1, 3) = @AV37Serie)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CobTip]";
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
               case 1 :
                     return conditional_P00E43(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] );
               case 2 :
                     return conditional_P00E44(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] );
               case 4 :
                     return conditional_P00E46(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] );
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
          Object[] prmP00E42;
          prmP00E42 = new Object[] {
          new ParDef("@AV36VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00E45;
          prmP00E45 = new Object[] {
          };
          Object[] prmP00E43;
          prmP00E43 = new Object[] {
          new ParDef("@AV13ForCod",GXType.Int32,6,0)
          };
          Object[] prmP00E44;
          prmP00E44 = new Object[] {
          new ParDef("@AV10FDesde",GXType.Date,8,0) ,
          new ParDef("@AV11FHasta",GXType.Date,8,0) ,
          new ParDef("@AV13ForCod",GXType.Int32,6,0) ,
          new ParDef("@AV12CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV36VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV37Serie",GXType.Char,3,0)
          };
          Object[] prmP00E46;
          prmP00E46 = new Object[] {
          new ParDef("@AV10FDesde",GXType.Date,8,0) ,
          new ParDef("@AV11FHasta",GXType.Date,8,0) ,
          new ParDef("@AV24TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV13ForCod",GXType.Int32,6,0) ,
          new ParDef("@AV12CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV36VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV37Serie",GXType.Char,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00E42", "SELECT [VenCod], [VenDsc] FROM [CVENDEDORES] WHERE [VenCod] = @AV36VenCod ORDER BY [VenCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E42,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E43", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E43,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E44", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E44,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E45", "SELECT [TipSts], [TipDsc], [TipCod] FROM [CTIPDOC] WHERE [TipSts] = 1 ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E45,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E46", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E46,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 12);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 1);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 1);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((int[]) buf[12])[0] = rslt.getInt(13);
                ((int[]) buf[13])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
