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
   public class rrresumenpedidosproductos : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrresumenpedidosproductos.aspx")), "rrresumenpedidosproductos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrresumenpedidosproductos.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "pTieCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV44pTieCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV72pTPedCod = (int)(NumberUtil.Val( GetPar( "pTPedCod"), "."));
                  AV45pTipCCod = (int)(NumberUtil.Val( GetPar( "pTipCCod"), "."));
                  AV37pLinCod = (int)(NumberUtil.Val( GetPar( "pLinCod"), "."));
                  AV43pSubLCod = (int)(NumberUtil.Val( GetPar( "pSubLCod"), "."));
                  AV46pVenCod = (int)(NumberUtil.Val( GetPar( "pVenCod"), "."));
                  AV71pCliCod = GetPar( "pCliCod");
                  AV40pProdCod = GetPar( "pProdCod");
                  AV24FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV26FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV59Tipo = GetPar( "Tipo");
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

      public rrresumenpedidosproductos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrresumenpedidosproductos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_pTieCod ,
                           ref int aP1_pTPedCod ,
                           ref int aP2_pTipCCod ,
                           ref int aP3_pLinCod ,
                           ref int aP4_pSubLCod ,
                           ref int aP5_pVenCod ,
                           ref string aP6_pCliCod ,
                           ref string aP7_pProdCod ,
                           ref DateTime aP8_FDesde ,
                           ref DateTime aP9_FHasta ,
                           ref string aP10_Tipo )
      {
         this.AV44pTieCod = aP0_pTieCod;
         this.AV72pTPedCod = aP1_pTPedCod;
         this.AV45pTipCCod = aP2_pTipCCod;
         this.AV37pLinCod = aP3_pLinCod;
         this.AV43pSubLCod = aP4_pSubLCod;
         this.AV46pVenCod = aP5_pVenCod;
         this.AV71pCliCod = aP6_pCliCod;
         this.AV40pProdCod = aP7_pProdCod;
         this.AV24FDesde = aP8_FDesde;
         this.AV26FHasta = aP9_FHasta;
         this.AV59Tipo = aP10_Tipo;
         initialize();
         executePrivate();
         aP0_pTieCod=this.AV44pTieCod;
         aP1_pTPedCod=this.AV72pTPedCod;
         aP2_pTipCCod=this.AV45pTipCCod;
         aP3_pLinCod=this.AV37pLinCod;
         aP4_pSubLCod=this.AV43pSubLCod;
         aP5_pVenCod=this.AV46pVenCod;
         aP6_pCliCod=this.AV71pCliCod;
         aP7_pProdCod=this.AV40pProdCod;
         aP8_FDesde=this.AV24FDesde;
         aP9_FHasta=this.AV26FHasta;
         aP10_Tipo=this.AV59Tipo;
      }

      public string executeUdp( ref int aP0_pTieCod ,
                                ref int aP1_pTPedCod ,
                                ref int aP2_pTipCCod ,
                                ref int aP3_pLinCod ,
                                ref int aP4_pSubLCod ,
                                ref int aP5_pVenCod ,
                                ref string aP6_pCliCod ,
                                ref string aP7_pProdCod ,
                                ref DateTime aP8_FDesde ,
                                ref DateTime aP9_FHasta )
      {
         execute(ref aP0_pTieCod, ref aP1_pTPedCod, ref aP2_pTipCCod, ref aP3_pLinCod, ref aP4_pSubLCod, ref aP5_pVenCod, ref aP6_pCliCod, ref aP7_pProdCod, ref aP8_FDesde, ref aP9_FHasta, ref aP10_Tipo);
         return AV59Tipo ;
      }

      public void executeSubmit( ref int aP0_pTieCod ,
                                 ref int aP1_pTPedCod ,
                                 ref int aP2_pTipCCod ,
                                 ref int aP3_pLinCod ,
                                 ref int aP4_pSubLCod ,
                                 ref int aP5_pVenCod ,
                                 ref string aP6_pCliCod ,
                                 ref string aP7_pProdCod ,
                                 ref DateTime aP8_FDesde ,
                                 ref DateTime aP9_FHasta ,
                                 ref string aP10_Tipo )
      {
         rrresumenpedidosproductos objrrresumenpedidosproductos;
         objrrresumenpedidosproductos = new rrresumenpedidosproductos();
         objrrresumenpedidosproductos.AV44pTieCod = aP0_pTieCod;
         objrrresumenpedidosproductos.AV72pTPedCod = aP1_pTPedCod;
         objrrresumenpedidosproductos.AV45pTipCCod = aP2_pTipCCod;
         objrrresumenpedidosproductos.AV37pLinCod = aP3_pLinCod;
         objrrresumenpedidosproductos.AV43pSubLCod = aP4_pSubLCod;
         objrrresumenpedidosproductos.AV46pVenCod = aP5_pVenCod;
         objrrresumenpedidosproductos.AV71pCliCod = aP6_pCliCod;
         objrrresumenpedidosproductos.AV40pProdCod = aP7_pProdCod;
         objrrresumenpedidosproductos.AV24FDesde = aP8_FDesde;
         objrrresumenpedidosproductos.AV26FHasta = aP9_FHasta;
         objrrresumenpedidosproductos.AV59Tipo = aP10_Tipo;
         objrrresumenpedidosproductos.context.SetSubmitInitialConfig(context);
         objrrresumenpedidosproductos.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrresumenpedidosproductos);
         aP0_pTieCod=this.AV44pTieCod;
         aP1_pTPedCod=this.AV72pTPedCod;
         aP2_pTipCCod=this.AV45pTipCCod;
         aP3_pLinCod=this.AV37pLinCod;
         aP4_pSubLCod=this.AV43pSubLCod;
         aP5_pVenCod=this.AV46pVenCod;
         aP6_pCliCod=this.AV71pCliCod;
         aP7_pProdCod=this.AV40pProdCod;
         aP8_FDesde=this.AV24FDesde;
         aP9_FHasta=this.AV26FHasta;
         aP10_Tipo=this.AV59Tipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrresumenpedidosproductos)stateInfo).executePrivate();
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
            AV21Empresa = AV51Session.Get("Empresa");
            AV20EmpDir = AV51Session.Get("EmpDir");
            AV22EmpRUC = AV51Session.Get("EmpRUC");
            AV48Ruta = AV51Session.Get("RUTA") + "/Logo.jpg";
            AV33Logo = AV48Ruta;
            AV76Logo_GXI = GXDbFile.PathToUrl( AV48Ruta);
            AV27Filtro1 = "Todos";
            AV28Filtro2 = "Todos";
            AV29Filtro3 = "Todos";
            AV30Filtro4 = "Todos";
            /* Using cursor P00E12 */
            pr_default.execute(0, new Object[] {AV37pLinCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A52LinCod = P00E12_A52LinCod[0];
               A1153LinDsc = P00E12_A1153LinDsc[0];
               AV27Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00E13 */
            pr_default.execute(1, new Object[] {AV43pSubLCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A51SublCod = P00E13_A51SublCod[0];
               n51SublCod = P00E13_n51SublCod[0];
               A1892SublDsc = P00E13_A1892SublDsc[0];
               AV28Filtro2 = A1892SublDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00E14 */
            pr_default.execute(2, new Object[] {AV40pProdCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A28ProdCod = P00E14_A28ProdCod[0];
               A55ProdDsc = P00E14_A55ProdDsc[0];
               AV29Filtro3 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P00E15 */
            pr_default.execute(3, new Object[] {AV71pCliCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A45CliCod = P00E15_A45CliCod[0];
               A161CliDsc = P00E15_A161CliDsc[0];
               AV30Filtro4 = StringUtil.Trim( A161CliDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            AV62TotalGeneral = 0.00m;
            /* Execute user subroutine: 'AGRUPAPORLINEAS' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            HE10( false, 52) ;
            getPrinter().GxDrawLine(483, Gx_line+9, 622, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 388, Gx_line+17, 468, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62TotalGeneral, "ZZZZZZ,ZZZ,ZZ9.99")), 498, Gx_line+16, 605, Gx_line+31, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HE10( true, 0) ;
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
         /* 'AGRUPAPORLINEAS' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV44pTieCod ,
                                              AV72pTPedCod ,
                                              AV45pTipCCod ,
                                              AV37pLinCod ,
                                              AV43pSubLCod ,
                                              AV46pVenCod ,
                                              AV36pDocCliCod ,
                                              AV40pProdCod ,
                                              AV59Tipo ,
                                              A178TieCod ,
                                              A212TPedCod ,
                                              A159TipCCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A211PedVendCod ,
                                              A45CliCod ,
                                              A28ProdCod ,
                                              A215PedFec ,
                                              AV24FDesde ,
                                              AV26FHasta ,
                                              A1595PedFecAten ,
                                              A1606PedSts } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00E16 */
         pr_default.execute(4, new Object[] {AV44pTieCod, AV72pTPedCod, AV45pTipCCod, AV37pLinCod, AV43pSubLCod, AV46pVenCod, AV36pDocCliCod, AV40pProdCod, AV24FDesde, AV26FHasta, AV24FDesde, AV26FHasta});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKE17 = false;
            A210PedCod = P00E16_A210PedCod[0];
            A1153LinDsc = P00E16_A1153LinDsc[0];
            A52LinCod = P00E16_A52LinCod[0];
            A1606PedSts = P00E16_A1606PedSts[0];
            A1595PedFecAten = P00E16_A1595PedFecAten[0];
            n1595PedFecAten = P00E16_n1595PedFecAten[0];
            A215PedFec = P00E16_A215PedFec[0];
            A28ProdCod = P00E16_A28ProdCod[0];
            A45CliCod = P00E16_A45CliCod[0];
            A211PedVendCod = P00E16_A211PedVendCod[0];
            A51SublCod = P00E16_A51SublCod[0];
            n51SublCod = P00E16_n51SublCod[0];
            A159TipCCod = P00E16_A159TipCCod[0];
            A212TPedCod = P00E16_A212TPedCod[0];
            A178TieCod = P00E16_A178TieCod[0];
            A1559PedDCanFAC = P00E16_A1559PedDCanFAC[0];
            A216PedDItem = P00E16_A216PedDItem[0];
            A1606PedSts = P00E16_A1606PedSts[0];
            A1595PedFecAten = P00E16_A1595PedFecAten[0];
            n1595PedFecAten = P00E16_n1595PedFecAten[0];
            A215PedFec = P00E16_A215PedFec[0];
            A45CliCod = P00E16_A45CliCod[0];
            A211PedVendCod = P00E16_A211PedVendCod[0];
            A212TPedCod = P00E16_A212TPedCod[0];
            A178TieCod = P00E16_A178TieCod[0];
            A159TipCCod = P00E16_A159TipCCod[0];
            A52LinCod = P00E16_A52LinCod[0];
            A51SublCod = P00E16_A51SublCod[0];
            n51SublCod = P00E16_n51SublCod[0];
            A1153LinDsc = P00E16_A1153LinDsc[0];
            while ( (pr_default.getStatus(4) != 101) && ( P00E16_A52LinCod[0] == A52LinCod ) )
            {
               BRKE17 = false;
               A210PedCod = P00E16_A210PedCod[0];
               A1153LinDsc = P00E16_A1153LinDsc[0];
               A28ProdCod = P00E16_A28ProdCod[0];
               A216PedDItem = P00E16_A216PedDItem[0];
               A1153LinDsc = P00E16_A1153LinDsc[0];
               BRKE17 = true;
               pr_default.readNext(4);
            }
            AV32LinCod = A52LinCod;
            AV73LinDsc = A1153LinDsc;
            HE10( false, 31) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73LinDsc, "")), 10, Gx_line+7, 600, Gx_line+25, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+31);
            /* Execute user subroutine: 'PRODUCTOSPORLINEAS' */
            S127 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            if ( ! BRKE17 )
            {
               BRKE17 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S127( )
      {
         /* 'PRODUCTOSPORLINEAS' Routine */
         returnInSub = false;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV44pTieCod ,
                                              AV72pTPedCod ,
                                              AV45pTipCCod ,
                                              AV43pSubLCod ,
                                              AV46pVenCod ,
                                              AV36pDocCliCod ,
                                              AV40pProdCod ,
                                              AV59Tipo ,
                                              A178TieCod ,
                                              A212TPedCod ,
                                              A159TipCCod ,
                                              A51SublCod ,
                                              A211PedVendCod ,
                                              A45CliCod ,
                                              A28ProdCod ,
                                              A215PedFec ,
                                              AV24FDesde ,
                                              AV26FHasta ,
                                              A1595PedFecAten ,
                                              A1606PedSts ,
                                              A52LinCod ,
                                              AV32LinCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00E17 */
         pr_default.execute(5, new Object[] {AV32LinCod, AV44pTieCod, AV72pTPedCod, AV45pTipCCod, AV43pSubLCod, AV46pVenCod, AV36pDocCliCod, AV40pProdCod, AV24FDesde, AV26FHasta, AV24FDesde, AV26FHasta});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKE19 = false;
            A210PedCod = P00E17_A210PedCod[0];
            A52LinCod = P00E17_A52LinCod[0];
            A55ProdDsc = P00E17_A55ProdDsc[0];
            A28ProdCod = P00E17_A28ProdCod[0];
            A1554PedDCan = P00E17_A1554PedDCan[0];
            A1606PedSts = P00E17_A1606PedSts[0];
            A1595PedFecAten = P00E17_A1595PedFecAten[0];
            n1595PedFecAten = P00E17_n1595PedFecAten[0];
            A215PedFec = P00E17_A215PedFec[0];
            A45CliCod = P00E17_A45CliCod[0];
            A211PedVendCod = P00E17_A211PedVendCod[0];
            A51SublCod = P00E17_A51SublCod[0];
            n51SublCod = P00E17_n51SublCod[0];
            A159TipCCod = P00E17_A159TipCCod[0];
            A212TPedCod = P00E17_A212TPedCod[0];
            A178TieCod = P00E17_A178TieCod[0];
            A216PedDItem = P00E17_A216PedDItem[0];
            A1606PedSts = P00E17_A1606PedSts[0];
            A1595PedFecAten = P00E17_A1595PedFecAten[0];
            n1595PedFecAten = P00E17_n1595PedFecAten[0];
            A215PedFec = P00E17_A215PedFec[0];
            A45CliCod = P00E17_A45CliCod[0];
            A211PedVendCod = P00E17_A211PedVendCod[0];
            A212TPedCod = P00E17_A212TPedCod[0];
            A178TieCod = P00E17_A178TieCod[0];
            A159TipCCod = P00E17_A159TipCCod[0];
            A52LinCod = P00E17_A52LinCod[0];
            A51SublCod = P00E17_A51SublCod[0];
            n51SublCod = P00E17_n51SublCod[0];
            AV41ProdCod = A28ProdCod;
            AV42ProdDsc = A55ProdDsc;
            AV12Cantidad = 0.00m;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00E17_A55ProdDsc[0], A55ProdDsc) == 0 ) )
            {
               BRKE19 = false;
               A210PedCod = P00E17_A210PedCod[0];
               A28ProdCod = P00E17_A28ProdCod[0];
               A1554PedDCan = P00E17_A1554PedDCan[0];
               A216PedDItem = P00E17_A216PedDItem[0];
               if ( StringUtil.StrCmp(A28ProdCod, AV41ProdCod) == 0 )
               {
                  AV12Cantidad = (decimal)(AV12Cantidad+A1554PedDCan);
               }
               BRKE19 = true;
               pr_default.readNext(5);
            }
            HE10( false, 19) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41ProdCod, "@!")), 10, Gx_line+3, 117, Gx_line+19, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42ProdDsc, "")), 121, Gx_line+3, 490, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV12Cantidad, "ZZZZ,ZZZ,ZZ9.9999")), 498, Gx_line+3, 605, Gx_line+18, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV62TotalGeneral = (decimal)(AV62TotalGeneral+AV12Cantidad);
            if ( ! BRKE19 )
            {
               BRKE19 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void HE10( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 669, Gx_line+43, 701, Gx_line+57, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 669, Gx_line+63, 713, Gx_line+77, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 669, Gx_line+24, 708, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Linea de Productos", 171, Gx_line+98, 283, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Sub Linea de productos", 171, Gx_line+120, 308, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Productos", 171, Gx_line+142, 231, Gx_line+156, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Filtro1, "")), 314, Gx_line+93, 657, Gx_line+117, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Filtro2, "")), 314, Gx_line+115, 657, Gx_line+139, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Filtro3, "")), 314, Gx_line+136, 657, Gx_line+160, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+190, 797, Gx_line+216, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 714, Gx_line+24, 761, Gx_line+39, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 699, Gx_line+43, 759, Gx_line+57, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 722, Gx_line+63, 761, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 18, Gx_line+196, 59, Gx_line+210, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Productos", 142, Gx_line+196, 202, Gx_line+210, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 553, Gx_line+196, 606, Gx_line+210, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV33Logo)) ? AV76Logo_GXI : AV33Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+19, 176, Gx_line+97) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Pedidos por Productos", 256, Gx_line+43, 556, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Del :", 274, Gx_line+65, 315, Gx_line+85, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV24FDesde, "99/99/99"), 323, Gx_line+63, 397, Gx_line+87, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 399, Gx_line+65, 429, Gx_line+85, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV26FHasta, "99/99/99"), 433, Gx_line+63, 507, Gx_line+87, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cliente", 171, Gx_line+162, 213, Gx_line+176, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Filtro4, "")), 314, Gx_line+157, 657, Gx_line+181, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+216);
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
         AV51Session = context.GetSession();
         AV20EmpDir = "";
         AV22EmpRUC = "";
         AV48Ruta = "";
         AV33Logo = "";
         AV76Logo_GXI = "";
         AV27Filtro1 = "";
         AV28Filtro2 = "";
         AV29Filtro3 = "";
         AV30Filtro4 = "";
         scmdbuf = "";
         P00E12_A52LinCod = new int[1] ;
         P00E12_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P00E13_A51SublCod = new int[1] ;
         P00E13_n51SublCod = new bool[] {false} ;
         P00E13_A1892SublDsc = new string[] {""} ;
         A1892SublDsc = "";
         P00E14_A28ProdCod = new string[] {""} ;
         P00E14_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00E15_A45CliCod = new string[] {""} ;
         P00E15_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         AV36pDocCliCod = "";
         A215PedFec = DateTime.MinValue;
         A1595PedFecAten = (DateTime)(DateTime.MinValue);
         A1606PedSts = "";
         P00E16_A210PedCod = new string[] {""} ;
         P00E16_A1153LinDsc = new string[] {""} ;
         P00E16_A52LinCod = new int[1] ;
         P00E16_A1606PedSts = new string[] {""} ;
         P00E16_A1595PedFecAten = new DateTime[] {DateTime.MinValue} ;
         P00E16_n1595PedFecAten = new bool[] {false} ;
         P00E16_A215PedFec = new DateTime[] {DateTime.MinValue} ;
         P00E16_A28ProdCod = new string[] {""} ;
         P00E16_A45CliCod = new string[] {""} ;
         P00E16_A211PedVendCod = new int[1] ;
         P00E16_A51SublCod = new int[1] ;
         P00E16_n51SublCod = new bool[] {false} ;
         P00E16_A159TipCCod = new int[1] ;
         P00E16_A212TPedCod = new int[1] ;
         P00E16_A178TieCod = new int[1] ;
         P00E16_A1559PedDCanFAC = new decimal[1] ;
         P00E16_A216PedDItem = new short[1] ;
         A210PedCod = "";
         AV73LinDsc = "";
         P00E17_A210PedCod = new string[] {""} ;
         P00E17_A52LinCod = new int[1] ;
         P00E17_A55ProdDsc = new string[] {""} ;
         P00E17_A28ProdCod = new string[] {""} ;
         P00E17_A1554PedDCan = new decimal[1] ;
         P00E17_A1606PedSts = new string[] {""} ;
         P00E17_A1595PedFecAten = new DateTime[] {DateTime.MinValue} ;
         P00E17_n1595PedFecAten = new bool[] {false} ;
         P00E17_A215PedFec = new DateTime[] {DateTime.MinValue} ;
         P00E17_A45CliCod = new string[] {""} ;
         P00E17_A211PedVendCod = new int[1] ;
         P00E17_A51SublCod = new int[1] ;
         P00E17_n51SublCod = new bool[] {false} ;
         P00E17_A159TipCCod = new int[1] ;
         P00E17_A212TPedCod = new int[1] ;
         P00E17_A178TieCod = new int[1] ;
         P00E17_A216PedDItem = new short[1] ;
         AV41ProdCod = "";
         AV42ProdDsc = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV33Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrresumenpedidosproductos__default(),
            new Object[][] {
                new Object[] {
               P00E12_A52LinCod, P00E12_A1153LinDsc
               }
               , new Object[] {
               P00E13_A51SublCod, P00E13_A1892SublDsc
               }
               , new Object[] {
               P00E14_A28ProdCod, P00E14_A55ProdDsc
               }
               , new Object[] {
               P00E15_A45CliCod, P00E15_A161CliDsc
               }
               , new Object[] {
               P00E16_A210PedCod, P00E16_A1153LinDsc, P00E16_A52LinCod, P00E16_A1606PedSts, P00E16_A1595PedFecAten, P00E16_n1595PedFecAten, P00E16_A215PedFec, P00E16_A28ProdCod, P00E16_A45CliCod, P00E16_A211PedVendCod,
               P00E16_A51SublCod, P00E16_n51SublCod, P00E16_A159TipCCod, P00E16_A212TPedCod, P00E16_A178TieCod, P00E16_A1559PedDCanFAC, P00E16_A216PedDItem
               }
               , new Object[] {
               P00E17_A210PedCod, P00E17_A52LinCod, P00E17_A55ProdDsc, P00E17_A28ProdCod, P00E17_A1554PedDCan, P00E17_A1606PedSts, P00E17_A1595PedFecAten, P00E17_n1595PedFecAten, P00E17_A215PedFec, P00E17_A45CliCod,
               P00E17_A211PedVendCod, P00E17_A51SublCod, P00E17_n51SublCod, P00E17_A159TipCCod, P00E17_A212TPedCod, P00E17_A178TieCod, P00E17_A216PedDItem
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
      private short A216PedDItem ;
      private int AV44pTieCod ;
      private int AV72pTPedCod ;
      private int AV45pTipCCod ;
      private int AV37pLinCod ;
      private int AV43pSubLCod ;
      private int AV46pVenCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int Gx_OldLine ;
      private int A178TieCod ;
      private int A212TPedCod ;
      private int A159TipCCod ;
      private int A211PedVendCod ;
      private int AV32LinCod ;
      private decimal AV62TotalGeneral ;
      private decimal A1559PedDCanFAC ;
      private decimal A1554PedDCan ;
      private decimal AV12Cantidad ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV71pCliCod ;
      private string AV40pProdCod ;
      private string AV59Tipo ;
      private string AV21Empresa ;
      private string AV20EmpDir ;
      private string AV22EmpRUC ;
      private string AV48Ruta ;
      private string AV27Filtro1 ;
      private string AV28Filtro2 ;
      private string AV29Filtro3 ;
      private string AV30Filtro4 ;
      private string scmdbuf ;
      private string A1153LinDsc ;
      private string A1892SublDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string AV36pDocCliCod ;
      private string A1606PedSts ;
      private string A210PedCod ;
      private string AV73LinDsc ;
      private string AV41ProdCod ;
      private string AV42ProdDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime A1595PedFecAten ;
      private DateTime AV24FDesde ;
      private DateTime AV26FHasta ;
      private DateTime A215PedFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private bool BRKE17 ;
      private bool n1595PedFecAten ;
      private bool BRKE19 ;
      private string AV76Logo_GXI ;
      private string AV33Logo ;
      private string Logo ;
      private IGxSession AV51Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_pTieCod ;
      private int aP1_pTPedCod ;
      private int aP2_pTipCCod ;
      private int aP3_pLinCod ;
      private int aP4_pSubLCod ;
      private int aP5_pVenCod ;
      private string aP6_pCliCod ;
      private string aP7_pProdCod ;
      private DateTime aP8_FDesde ;
      private DateTime aP9_FHasta ;
      private string aP10_Tipo ;
      private IDataStoreProvider pr_default ;
      private int[] P00E12_A52LinCod ;
      private string[] P00E12_A1153LinDsc ;
      private int[] P00E13_A51SublCod ;
      private bool[] P00E13_n51SublCod ;
      private string[] P00E13_A1892SublDsc ;
      private string[] P00E14_A28ProdCod ;
      private string[] P00E14_A55ProdDsc ;
      private string[] P00E15_A45CliCod ;
      private string[] P00E15_A161CliDsc ;
      private string[] P00E16_A210PedCod ;
      private string[] P00E16_A1153LinDsc ;
      private int[] P00E16_A52LinCod ;
      private string[] P00E16_A1606PedSts ;
      private DateTime[] P00E16_A1595PedFecAten ;
      private bool[] P00E16_n1595PedFecAten ;
      private DateTime[] P00E16_A215PedFec ;
      private string[] P00E16_A28ProdCod ;
      private string[] P00E16_A45CliCod ;
      private int[] P00E16_A211PedVendCod ;
      private int[] P00E16_A51SublCod ;
      private bool[] P00E16_n51SublCod ;
      private int[] P00E16_A159TipCCod ;
      private int[] P00E16_A212TPedCod ;
      private int[] P00E16_A178TieCod ;
      private decimal[] P00E16_A1559PedDCanFAC ;
      private short[] P00E16_A216PedDItem ;
      private string[] P00E17_A210PedCod ;
      private int[] P00E17_A52LinCod ;
      private string[] P00E17_A55ProdDsc ;
      private string[] P00E17_A28ProdCod ;
      private decimal[] P00E17_A1554PedDCan ;
      private string[] P00E17_A1606PedSts ;
      private DateTime[] P00E17_A1595PedFecAten ;
      private bool[] P00E17_n1595PedFecAten ;
      private DateTime[] P00E17_A215PedFec ;
      private string[] P00E17_A45CliCod ;
      private int[] P00E17_A211PedVendCod ;
      private int[] P00E17_A51SublCod ;
      private bool[] P00E17_n51SublCod ;
      private int[] P00E17_A159TipCCod ;
      private int[] P00E17_A212TPedCod ;
      private int[] P00E17_A178TieCod ;
      private short[] P00E17_A216PedDItem ;
   }

   public class rrresumenpedidosproductos__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E16( IGxContext context ,
                                             int AV44pTieCod ,
                                             int AV72pTPedCod ,
                                             int AV45pTipCCod ,
                                             int AV37pLinCod ,
                                             int AV43pSubLCod ,
                                             int AV46pVenCod ,
                                             string AV36pDocCliCod ,
                                             string AV40pProdCod ,
                                             string AV59Tipo ,
                                             int A178TieCod ,
                                             int A212TPedCod ,
                                             int A159TipCCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A211PedVendCod ,
                                             string A45CliCod ,
                                             string A28ProdCod ,
                                             DateTime A215PedFec ,
                                             DateTime AV24FDesde ,
                                             DateTime AV26FHasta ,
                                             DateTime A1595PedFecAten ,
                                             string A1606PedSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[PedCod], T5.[LinDsc], T4.[LinCod], T2.[PedSts], T2.[PedFecAten], T2.[PedFec], T1.[ProdCod], T2.[CliCod], T2.[PedVendCod], T4.[SublCod], T3.[TipCCod], T2.[TPedCod], T2.[TieCod], T1.[PedDCanFAC], T1.[PedDItem] FROM (((([CLPEDIDOSDET] T1 INNER JOIN [CLPEDIDOS] T2 ON T2.[PedCod] = T1.[PedCod]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T2.[CliCod]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T4.[LinCod])";
         AddWhere(sWhereString, "(T2.[PedSts] <> 'A')");
         if ( ! (0==AV44pTieCod) )
         {
            AddWhere(sWhereString, "(T2.[TieCod] = @AV44pTieCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV72pTPedCod) )
         {
            AddWhere(sWhereString, "(T2.[TPedCod] = @AV72pTPedCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV45pTipCCod) )
         {
            AddWhere(sWhereString, "(T3.[TipCCod] = @AV45pTipCCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV37pLinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV37pLinCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV43pSubLCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV43pSubLCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV46pVenCod) )
         {
            AddWhere(sWhereString, "(T2.[PedVendCod] = @AV46pVenCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36pDocCliCod)) )
         {
            AddWhere(sWhereString, "(T2.[CliCod] = @AV36pDocCliCod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40pProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV40pProdCod)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Tipo, "P") == 0 )
         {
            AddWhere(sWhereString, "(T2.[PedFec] >= @AV24FDesde and T2.[PedFec] <= @AV26FHasta)");
         }
         else
         {
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
         }
         if ( ! ( StringUtil.StrCmp(AV59Tipo, "P") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[PedFecAten] >= @AV24FDesde and T2.[PedFecAten] <= @AV26FHasta)");
         }
         else
         {
            GXv_int1[10] = 1;
            GXv_int1[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.[LinCod], T5.[LinDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00E17( IGxContext context ,
                                             int AV44pTieCod ,
                                             int AV72pTPedCod ,
                                             int AV45pTipCCod ,
                                             int AV43pSubLCod ,
                                             int AV46pVenCod ,
                                             string AV36pDocCliCod ,
                                             string AV40pProdCod ,
                                             string AV59Tipo ,
                                             int A178TieCod ,
                                             int A212TPedCod ,
                                             int A159TipCCod ,
                                             int A51SublCod ,
                                             int A211PedVendCod ,
                                             string A45CliCod ,
                                             string A28ProdCod ,
                                             DateTime A215PedFec ,
                                             DateTime AV24FDesde ,
                                             DateTime AV26FHasta ,
                                             DateTime A1595PedFecAten ,
                                             string A1606PedSts ,
                                             int A52LinCod ,
                                             int AV32LinCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[PedCod], T4.[LinCod], T1.[ProdDsc], T1.[ProdCod], T1.[PedDCan], T2.[PedSts], T2.[PedFecAten], T2.[PedFec], T2.[CliCod], T2.[PedVendCod], T4.[SublCod], T3.[TipCCod], T2.[TPedCod], T2.[TieCod], T1.[PedDItem] FROM ((([CLPEDIDOSDET] T1 INNER JOIN [CLPEDIDOS] T2 ON T2.[PedCod] = T1.[PedCod]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T2.[CliCod]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod])";
         AddWhere(sWhereString, "(T2.[PedSts] <> 'A')");
         AddWhere(sWhereString, "(T4.[LinCod] = @AV32LinCod)");
         if ( ! (0==AV44pTieCod) )
         {
            AddWhere(sWhereString, "(T2.[TieCod] = @AV44pTieCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV72pTPedCod) )
         {
            AddWhere(sWhereString, "(T2.[TPedCod] = @AV72pTPedCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV45pTipCCod) )
         {
            AddWhere(sWhereString, "(T3.[TipCCod] = @AV45pTipCCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV43pSubLCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV43pSubLCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV46pVenCod) )
         {
            AddWhere(sWhereString, "(T2.[PedVendCod] = @AV46pVenCod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36pDocCliCod)) )
         {
            AddWhere(sWhereString, "(T2.[CliCod] = @AV36pDocCliCod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40pProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV40pProdCod)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Tipo, "P") == 0 )
         {
            AddWhere(sWhereString, "(T2.[PedFec] >= @AV24FDesde and T2.[PedFec] <= @AV26FHasta)");
         }
         else
         {
            GXv_int3[8] = 1;
            GXv_int3[9] = 1;
         }
         if ( ! ( StringUtil.StrCmp(AV59Tipo, "P") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[PedFecAten] >= @AV24FDesde and T2.[PedFecAten] <= @AV26FHasta)");
         }
         else
         {
            GXv_int3[10] = 1;
            GXv_int3[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 4 :
                     return conditional_P00E16(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] );
               case 5 :
                     return conditional_P00E17(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] );
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
          Object[] prmP00E12;
          prmP00E12 = new Object[] {
          new ParDef("@AV37pLinCod",GXType.Int32,6,0)
          };
          Object[] prmP00E13;
          prmP00E13 = new Object[] {
          new ParDef("@AV43pSubLCod",GXType.Int32,6,0)
          };
          Object[] prmP00E14;
          prmP00E14 = new Object[] {
          new ParDef("@AV40pProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00E15;
          prmP00E15 = new Object[] {
          new ParDef("@AV71pCliCod",GXType.NChar,20,0)
          };
          Object[] prmP00E16;
          prmP00E16 = new Object[] {
          new ParDef("@AV44pTieCod",GXType.Int32,6,0) ,
          new ParDef("@AV72pTPedCod",GXType.Int32,6,0) ,
          new ParDef("@AV45pTipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV37pLinCod",GXType.Int32,6,0) ,
          new ParDef("@AV43pSubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV46pVenCod",GXType.Int32,6,0) ,
          new ParDef("@AV36pDocCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV40pProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV24FDesde",GXType.Date,8,0) ,
          new ParDef("@AV26FHasta",GXType.Date,8,0) ,
          new ParDef("@AV24FDesde",GXType.Date,8,0) ,
          new ParDef("@AV26FHasta",GXType.Date,8,0)
          };
          Object[] prmP00E17;
          prmP00E17 = new Object[] {
          new ParDef("@AV32LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV44pTieCod",GXType.Int32,6,0) ,
          new ParDef("@AV72pTPedCod",GXType.Int32,6,0) ,
          new ParDef("@AV45pTipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV43pSubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV46pVenCod",GXType.Int32,6,0) ,
          new ParDef("@AV36pDocCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV40pProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV24FDesde",GXType.Date,8,0) ,
          new ParDef("@AV26FHasta",GXType.Date,8,0) ,
          new ParDef("@AV24FDesde",GXType.Date,8,0) ,
          new ParDef("@AV26FHasta",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00E12", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV37pLinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E12,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E13", "SELECT [SublCod], [SublDsc] FROM [CSUBLPROD] WHERE [SublCod] = @AV43pSubLCod ORDER BY [SublCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E13,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E14", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV40pProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E14,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E15", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV71pCliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E15,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E16", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E16,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E17", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E17,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 15);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((short[]) buf[16])[0] = rslt.getShort(15);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 1);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                ((short[]) buf[16])[0] = rslt.getShort(15);
                return;
       }
    }

 }

}
