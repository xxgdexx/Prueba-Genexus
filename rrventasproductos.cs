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
   public class rrventasproductos : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrventasproductos.aspx")), "rrventasproductos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrventasproductos.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "pLinCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV39pLinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV45pSubLCod = (int)(NumberUtil.Val( GetPar( "pSubLCod"), "."));
                  AV42pProdCod = GetPar( "pProdCod");
                  AV26FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV28FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV61Tipo = GetPar( "Tipo");
                  AV38pDocCliCod = GetPar( "pDocCliCod");
                  AV49pZonCod = (int)(NumberUtil.Val( GetPar( "pZonCod"), "."));
                  AV48pVenCod = (int)(NumberUtil.Val( GetPar( "pVenCod"), "."));
                  AV46pTieCod = (int)(NumberUtil.Val( GetPar( "pTieCod"), "."));
                  AV47pTipCCod = (int)(NumberUtil.Val( GetPar( "pTipCCod"), "."));
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

      public rrventasproductos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrventasproductos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_pLinCod ,
                           ref int aP1_pSubLCod ,
                           ref string aP2_pProdCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref string aP5_Tipo ,
                           ref string aP6_pDocCliCod ,
                           ref int aP7_pZonCod ,
                           ref int aP8_pVenCod ,
                           ref int aP9_pTieCod ,
                           ref int aP10_pTipCCod ,
                           ref short aP11_CheckRec )
      {
         this.AV39pLinCod = aP0_pLinCod;
         this.AV45pSubLCod = aP1_pSubLCod;
         this.AV42pProdCod = aP2_pProdCod;
         this.AV26FDesde = aP3_FDesde;
         this.AV28FHasta = aP4_FHasta;
         this.AV61Tipo = aP5_Tipo;
         this.AV38pDocCliCod = aP6_pDocCliCod;
         this.AV49pZonCod = aP7_pZonCod;
         this.AV48pVenCod = aP8_pVenCod;
         this.AV46pTieCod = aP9_pTieCod;
         this.AV47pTipCCod = aP10_pTipCCod;
         this.AV12CheckRec = aP11_CheckRec;
         initialize();
         executePrivate();
         aP0_pLinCod=this.AV39pLinCod;
         aP1_pSubLCod=this.AV45pSubLCod;
         aP2_pProdCod=this.AV42pProdCod;
         aP3_FDesde=this.AV26FDesde;
         aP4_FHasta=this.AV28FHasta;
         aP5_Tipo=this.AV61Tipo;
         aP6_pDocCliCod=this.AV38pDocCliCod;
         aP7_pZonCod=this.AV49pZonCod;
         aP8_pVenCod=this.AV48pVenCod;
         aP9_pTieCod=this.AV46pTieCod;
         aP10_pTipCCod=this.AV47pTipCCod;
         aP11_CheckRec=this.AV12CheckRec;
      }

      public short executeUdp( ref int aP0_pLinCod ,
                               ref int aP1_pSubLCod ,
                               ref string aP2_pProdCod ,
                               ref DateTime aP3_FDesde ,
                               ref DateTime aP4_FHasta ,
                               ref string aP5_Tipo ,
                               ref string aP6_pDocCliCod ,
                               ref int aP7_pZonCod ,
                               ref int aP8_pVenCod ,
                               ref int aP9_pTieCod ,
                               ref int aP10_pTipCCod )
      {
         execute(ref aP0_pLinCod, ref aP1_pSubLCod, ref aP2_pProdCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_Tipo, ref aP6_pDocCliCod, ref aP7_pZonCod, ref aP8_pVenCod, ref aP9_pTieCod, ref aP10_pTipCCod, ref aP11_CheckRec);
         return AV12CheckRec ;
      }

      public void executeSubmit( ref int aP0_pLinCod ,
                                 ref int aP1_pSubLCod ,
                                 ref string aP2_pProdCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref string aP5_Tipo ,
                                 ref string aP6_pDocCliCod ,
                                 ref int aP7_pZonCod ,
                                 ref int aP8_pVenCod ,
                                 ref int aP9_pTieCod ,
                                 ref int aP10_pTipCCod ,
                                 ref short aP11_CheckRec )
      {
         rrventasproductos objrrventasproductos;
         objrrventasproductos = new rrventasproductos();
         objrrventasproductos.AV39pLinCod = aP0_pLinCod;
         objrrventasproductos.AV45pSubLCod = aP1_pSubLCod;
         objrrventasproductos.AV42pProdCod = aP2_pProdCod;
         objrrventasproductos.AV26FDesde = aP3_FDesde;
         objrrventasproductos.AV28FHasta = aP4_FHasta;
         objrrventasproductos.AV61Tipo = aP5_Tipo;
         objrrventasproductos.AV38pDocCliCod = aP6_pDocCliCod;
         objrrventasproductos.AV49pZonCod = aP7_pZonCod;
         objrrventasproductos.AV48pVenCod = aP8_pVenCod;
         objrrventasproductos.AV46pTieCod = aP9_pTieCod;
         objrrventasproductos.AV47pTipCCod = aP10_pTipCCod;
         objrrventasproductos.AV12CheckRec = aP11_CheckRec;
         objrrventasproductos.context.SetSubmitInitialConfig(context);
         objrrventasproductos.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrventasproductos);
         aP0_pLinCod=this.AV39pLinCod;
         aP1_pSubLCod=this.AV45pSubLCod;
         aP2_pProdCod=this.AV42pProdCod;
         aP3_FDesde=this.AV26FDesde;
         aP4_FHasta=this.AV28FHasta;
         aP5_Tipo=this.AV61Tipo;
         aP6_pDocCliCod=this.AV38pDocCliCod;
         aP7_pZonCod=this.AV49pZonCod;
         aP8_pVenCod=this.AV48pVenCod;
         aP9_pTieCod=this.AV46pTieCod;
         aP10_pTipCCod=this.AV47pTipCCod;
         aP11_CheckRec=this.AV12CheckRec;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrventasproductos)stateInfo).executePrivate();
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
            AV23Empresa = AV53Session.Get("Empresa");
            AV22EmpDir = AV53Session.Get("EmpDir");
            AV24EmpRUC = AV53Session.Get("EmpRUC");
            AV50Ruta = AV53Session.Get("RUTA") + "/Logo.jpg";
            AV35Logo = AV50Ruta;
            AV74Logo_GXI = GXDbFile.PathToUrl( AV50Ruta);
            AV29Filtro1 = "Todos";
            AV30Filtro2 = "Todos";
            AV31Filtro3 = "Todos";
            AV32Filtro4 = "Todos";
            /* Using cursor P00EG2 */
            pr_default.execute(0, new Object[] {AV39pLinCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A52LinCod = P00EG2_A52LinCod[0];
               A1153LinDsc = P00EG2_A1153LinDsc[0];
               AV29Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00EG3 */
            pr_default.execute(1, new Object[] {AV45pSubLCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A51SublCod = P00EG3_A51SublCod[0];
               n51SublCod = P00EG3_n51SublCod[0];
               A1892SublDsc = P00EG3_A1892SublDsc[0];
               AV30Filtro2 = A1892SublDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00EG4 */
            pr_default.execute(2, new Object[] {AV42pProdCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A28ProdCod = P00EG4_A28ProdCod[0];
               A55ProdDsc = P00EG4_A55ProdDsc[0];
               AV31Filtro3 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P00EG5 */
            pr_default.execute(3, new Object[] {AV38pDocCliCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A45CliCod = P00EG5_A45CliCod[0];
               A161CliDsc = P00EG5_A161CliDsc[0];
               AV32Filtro4 = StringUtil.Trim( A161CliDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            AV64TotalGeneral = 0.00m;
            AV65TotalGeneralME = 0.00m;
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 AV46pTieCod ,
                                                 AV39pLinCod ,
                                                 AV45pSubLCod ,
                                                 AV42pProdCod ,
                                                 AV47pTipCCod ,
                                                 AV38pDocCliCod ,
                                                 AV48pVenCod ,
                                                 AV49pZonCod ,
                                                 AV12CheckRec ,
                                                 AV61Tipo ,
                                                 A178TieCod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A28ProdCod ,
                                                 A159TipCCod ,
                                                 A231DocCliCod ,
                                                 A227DocVendCod ,
                                                 A158ZonCod ,
                                                 A149TipCod ,
                                                 A946DocTipo ,
                                                 A232DocFec ,
                                                 AV26FDesde ,
                                                 AV28FHasta ,
                                                 A941DocSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00EG6 */
            pr_default.execute(4, new Object[] {AV26FDesde, AV28FHasta, AV46pTieCod, AV39pLinCod, AV45pSubLCod, AV42pProdCod, AV47pTipCCod, AV38pDocCliCod, AV48pVenCod, AV49pZonCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               BRKEG7 = false;
               A28ProdCod = P00EG6_A28ProdCod[0];
               A149TipCod = P00EG6_A149TipCod[0];
               A24DocNum = P00EG6_A24DocNum[0];
               A232DocFec = P00EG6_A232DocFec[0];
               A511TipSigno = P00EG6_A511TipSigno[0];
               A230DocMonCod = P00EG6_A230DocMonCod[0];
               A899DocDcto = P00EG6_A899DocDcto[0];
               A226DocMovCod = P00EG6_A226DocMovCod[0];
               A892DocDTot = P00EG6_A892DocDTot[0];
               A895DocDCan = P00EG6_A895DocDCan[0];
               A882DocAnticipos = P00EG6_A882DocAnticipos[0];
               A929DocFecRef = P00EG6_A929DocFecRef[0];
               A941DocSts = P00EG6_A941DocSts[0];
               A946DocTipo = P00EG6_A946DocTipo[0];
               A158ZonCod = P00EG6_A158ZonCod[0];
               n158ZonCod = P00EG6_n158ZonCod[0];
               A227DocVendCod = P00EG6_A227DocVendCod[0];
               A231DocCliCod = P00EG6_A231DocCliCod[0];
               A159TipCCod = P00EG6_A159TipCCod[0];
               n159TipCCod = P00EG6_n159TipCCod[0];
               A51SublCod = P00EG6_A51SublCod[0];
               n51SublCod = P00EG6_n51SublCod[0];
               A52LinCod = P00EG6_A52LinCod[0];
               A178TieCod = P00EG6_A178TieCod[0];
               n178TieCod = P00EG6_n178TieCod[0];
               A894DocDpre = P00EG6_A894DocDpre[0];
               A55ProdDsc = P00EG6_A55ProdDsc[0];
               A233DocItem = P00EG6_A233DocItem[0];
               A51SublCod = P00EG6_A51SublCod[0];
               n51SublCod = P00EG6_n51SublCod[0];
               A52LinCod = P00EG6_A52LinCod[0];
               A55ProdDsc = P00EG6_A55ProdDsc[0];
               A511TipSigno = P00EG6_A511TipSigno[0];
               A232DocFec = P00EG6_A232DocFec[0];
               A230DocMonCod = P00EG6_A230DocMonCod[0];
               A899DocDcto = P00EG6_A899DocDcto[0];
               A226DocMovCod = P00EG6_A226DocMovCod[0];
               A882DocAnticipos = P00EG6_A882DocAnticipos[0];
               A929DocFecRef = P00EG6_A929DocFecRef[0];
               A941DocSts = P00EG6_A941DocSts[0];
               A946DocTipo = P00EG6_A946DocTipo[0];
               A227DocVendCod = P00EG6_A227DocVendCod[0];
               A231DocCliCod = P00EG6_A231DocCliCod[0];
               A178TieCod = P00EG6_A178TieCod[0];
               n178TieCod = P00EG6_n178TieCod[0];
               A158ZonCod = P00EG6_A158ZonCod[0];
               n158ZonCod = P00EG6_n158ZonCod[0];
               A159TipCCod = P00EG6_A159TipCCod[0];
               n159TipCCod = P00EG6_n159TipCCod[0];
               AV43ProdCod = A28ProdCod;
               AV44ProdDsc = A55ProdDsc;
               AV68TotalVenta = 0.00m;
               AV69TotalVentaME = 0.00m;
               AV67TotalMN = 0.00m;
               AV66TotalME = 0.00m;
               AV10Cant = 0.00m;
               AV11Cantidad = 0.00m;
               AV56TCantidad = 0.00m;
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00EG6_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRKEG7 = false;
                  A149TipCod = P00EG6_A149TipCod[0];
                  A24DocNum = P00EG6_A24DocNum[0];
                  A232DocFec = P00EG6_A232DocFec[0];
                  A511TipSigno = P00EG6_A511TipSigno[0];
                  A230DocMonCod = P00EG6_A230DocMonCod[0];
                  A899DocDcto = P00EG6_A899DocDcto[0];
                  A226DocMovCod = P00EG6_A226DocMovCod[0];
                  A892DocDTot = P00EG6_A892DocDTot[0];
                  A895DocDCan = P00EG6_A895DocDCan[0];
                  A882DocAnticipos = P00EG6_A882DocAnticipos[0];
                  A929DocFecRef = P00EG6_A929DocFecRef[0];
                  A233DocItem = P00EG6_A233DocItem[0];
                  A511TipSigno = P00EG6_A511TipSigno[0];
                  A232DocFec = P00EG6_A232DocFec[0];
                  A230DocMonCod = P00EG6_A230DocMonCod[0];
                  A899DocDcto = P00EG6_A899DocDcto[0];
                  A226DocMovCod = P00EG6_A226DocMovCod[0];
                  A882DocAnticipos = P00EG6_A882DocAnticipos[0];
                  A929DocFecRef = P00EG6_A929DocFecRef[0];
                  if ( StringUtil.StrCmp(A28ProdCod, AV43ProdCod) == 0 )
                  {
                     AV60TipCod2 = A149TipCod;
                     AV21DocNum2 = A24DocNum;
                     AV27Fecha = A232DocFec;
                     AV62TipSigno = A511TipSigno;
                     AV36MonCod = A230DocMonCod;
                     AV41PorDscto = A899DocDcto;
                     AV20DocMovCod = A226DocMovCod;
                     AV14Descuento = (decimal)(NumberUtil.Round( (NumberUtil.Round( A892DocDTot, 2)*AV41PorDscto)/ (decimal)(100), 2)*A511TipSigno);
                     AV63Total = NumberUtil.Round( (NumberUtil.Round( A892DocDTot, 2)-AV14Descuento)*A511TipSigno, 2);
                     AV10Cant = NumberUtil.Round( A895DocDCan*A511TipSigno, 2);
                     AV15DocAnticipos = (decimal)(NumberUtil.Round( A882DocAnticipos, 2)*A511TipSigno);
                     AV18DocDTot = (decimal)(NumberUtil.Round( A892DocDTot, 2)*A511TipSigno);
                     if ( ( StringUtil.StrCmp(AV60TipCod2, "NC") == 0 ) || ( StringUtil.StrCmp(AV60TipCod2, "ND") == 0 ) )
                     {
                        /* Execute user subroutine: 'VALIDATIPOMOVIMIENTO' */
                        S111 ();
                        if ( returnInSub )
                        {
                           pr_default.close(4);
                           this.cleanup();
                           if (true) return;
                        }
                        AV27Fecha = A929DocFecRef;
                     }
                     GXt_decimal1 = AV9Cambio;
                     GXt_int2 = 2;
                     GXt_char3 = "V";
                     new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV27Fecha, ref  GXt_char3, out  GXt_decimal1) ;
                     AV9Cambio = GXt_decimal1;
                     if ( ! (Convert.ToDecimal(0)==AV15DocAnticipos) )
                     {
                        /* Execute user subroutine: 'SUBTOTAL' */
                        S121 ();
                        if ( returnInSub )
                        {
                           pr_default.close(4);
                           this.cleanup();
                           if (true) return;
                        }
                        AV40Porcentaje = NumberUtil.Round( AV18DocDTot/ (decimal)(AV55SubTotal), 10);
                        AV8Anticipo = NumberUtil.Round( AV40Porcentaje*AV15DocAnticipos, 2);
                     }
                     else
                     {
                        AV40Porcentaje = 0.00m;
                        AV8Anticipo = 0.00m;
                        AV55SubTotal = 0.00m;
                     }
                     AV63Total = (decimal)(AV63Total-(AV8Anticipo+AV14Descuento));
                     AV67TotalMN = ((AV36MonCod==1) ? AV63Total : NumberUtil.Round( AV63Total*AV9Cambio, 2));
                     AV66TotalME = ((AV36MonCod==1) ? NumberUtil.Round( AV63Total/ (decimal)(AV9Cambio), 2) : AV63Total);
                     AV68TotalVenta = (decimal)(AV68TotalVenta+AV67TotalMN);
                     AV69TotalVentaME = (decimal)(AV69TotalVentaME+AV66TotalME);
                     AV11Cantidad = (decimal)(AV11Cantidad+AV10Cant);
                  }
                  BRKEG7 = true;
                  pr_default.readNext(4);
               }
               AV52SDTVentaProductosITem.gxTpr_Clicod = AV43ProdCod;
               AV52SDTVentaProductosITem.gxTpr_Clidsc = AV44ProdDsc;
               AV52SDTVentaProductosITem.gxTpr_Cantidad = AV11Cantidad;
               AV52SDTVentaProductosITem.gxTpr_Importe = AV68TotalVenta;
               AV52SDTVentaProductosITem.gxTpr_Importe1 = AV69TotalVentaME;
               AV51SDTVentaProductos.Add(AV52SDTVentaProductosITem, 0);
               AV52SDTVentaProductosITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
               AV64TotalGeneral = (decimal)(AV64TotalGeneral+AV68TotalVenta);
               if ( ! BRKEG7 )
               {
                  BRKEG7 = true;
                  pr_default.readNext(4);
               }
            }
            pr_default.close(4);
            AV51SDTVentaProductos.Sort("[Importe]");
            AV64TotalGeneral = 0.00m;
            AV65TotalGeneralME = 0.00m;
            AV84GXV1 = 1;
            while ( AV84GXV1 <= AV51SDTVentaProductos.Count )
            {
               AV52SDTVentaProductosITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV51SDTVentaProductos.Item(AV84GXV1));
               AV43ProdCod = AV52SDTVentaProductosITem.gxTpr_Clicod;
               AV44ProdDsc = AV52SDTVentaProductosITem.gxTpr_Clidsc;
               AV11Cantidad = AV52SDTVentaProductosITem.gxTpr_Cantidad;
               AV68TotalVenta = AV52SDTVentaProductosITem.gxTpr_Importe;
               AV69TotalVentaME = AV52SDTVentaProductosITem.gxTpr_Importe1;
               HEG0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43ProdCod, "@!")), 10, Gx_line+3, 117, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44ProdDsc, "")), 121, Gx_line+3, 451, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68TotalVenta, "ZZZZZZ,ZZZ,ZZ9.99")), 546, Gx_line+3, 670, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV11Cantidad, "ZZZZ,ZZZ,ZZ9.9999")), 450, Gx_line+3, 557, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69TotalVentaME, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+3, 780, Gx_line+18, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV64TotalGeneral = (decimal)(AV64TotalGeneral+AV68TotalVenta);
               AV65TotalGeneralME = (decimal)(AV65TotalGeneralME+AV69TotalVentaME);
               AV84GXV1 = (int)(AV84GXV1+1);
            }
            HEG0( false, 52) ;
            getPrinter().GxDrawLine(563, Gx_line+9, 785, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 417, Gx_line+17, 497, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TotalGeneral, "ZZZZZZ,ZZZ,ZZ9.99")), 564, Gx_line+16, 671, Gx_line+31, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TotalGeneralME, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+15, 780, Gx_line+30, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HEG0( true, 0) ;
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
         /* 'VALIDATIPOMOVIMIENTO' Routine */
         returnInSub = false;
         /* Using cursor P00EG7 */
         pr_default.execute(5, new Object[] {AV20DocMovCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A235MovVCod = P00EG7_A235MovVCod[0];
            A1242MovVAbr = P00EG7_A1242MovVAbr[0];
            if ( ! ( StringUtil.StrCmp(A1242MovVAbr, "SI") == 0 ) )
            {
               AV10Cant = 0.00m;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
      }

      protected void S121( )
      {
         /* 'SUBTOTAL' Routine */
         returnInSub = false;
         /* Using cursor P00EG9 */
         pr_default.execute(6, new Object[] {AV60TipCod2, AV21DocNum2});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A24DocNum = P00EG9_A24DocNum[0];
            A149TipCod = P00EG9_A149TipCod[0];
            A927DocSubExonerado = P00EG9_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EG9_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EG9_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EG9_A920DocSubAfecto[0];
            A927DocSubExonerado = P00EG9_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EG9_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EG9_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EG9_A920DocSubAfecto[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            AV55SubTotal = NumberUtil.Round( A919DocSub, 2);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
      }

      protected void HEG0( bool bFoot ,
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
               getPrinter().GxDrawText("Linea de Productos", 171, Gx_line+121, 283, Gx_line+135, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Sub Linea de productos", 171, Gx_line+143, 308, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Productos", 171, Gx_line+165, 231, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Filtro1, "")), 314, Gx_line+116, 657, Gx_line+140, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Filtro2, "")), 314, Gx_line+138, 657, Gx_line+162, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31Filtro3, "")), 314, Gx_line+159, 657, Gx_line+183, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+210, 797, Gx_line+236, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 714, Gx_line+24, 761, Gx_line+39, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 699, Gx_line+43, 759, Gx_line+57, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 722, Gx_line+63, 761, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 18, Gx_line+217, 59, Gx_line+231, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Venta MN", 585, Gx_line+217, 675, Gx_line+231, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Productos", 125, Gx_line+217, 185, Gx_line+231, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 500, Gx_line+217, 553, Gx_line+231, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV35Logo)) ? AV74Logo_GXI : AV35Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+19, 176, Gx_line+97) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Ventas por Productos", 256, Gx_line+43, 548, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Del :", 274, Gx_line+65, 315, Gx_line+85, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV26FDesde, "99/99/99"), 323, Gx_line+63, 397, Gx_line+87, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 399, Gx_line+65, 429, Gx_line+85, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV28FHasta, "99/99/99"), 433, Gx_line+63, 507, Gx_line+87, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Expresado en :", 242, Gx_line+88, 369, Gx_line+108, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Filtro5, "")), 374, Gx_line+85, 563, Gx_line+109, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cliente", 171, Gx_line+185, 213, Gx_line+199, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32Filtro4, "")), 314, Gx_line+180, 657, Gx_line+204, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Venta ME", 702, Gx_line+217, 791, Gx_line+231, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+236);
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
         AV23Empresa = "";
         AV53Session = context.GetSession();
         AV22EmpDir = "";
         AV24EmpRUC = "";
         AV50Ruta = "";
         AV35Logo = "";
         AV74Logo_GXI = "";
         AV29Filtro1 = "";
         AV30Filtro2 = "";
         AV31Filtro3 = "";
         AV32Filtro4 = "";
         scmdbuf = "";
         P00EG2_A52LinCod = new int[1] ;
         P00EG2_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P00EG3_A51SublCod = new int[1] ;
         P00EG3_n51SublCod = new bool[] {false} ;
         P00EG3_A1892SublDsc = new string[] {""} ;
         A1892SublDsc = "";
         P00EG4_A28ProdCod = new string[] {""} ;
         P00EG4_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00EG5_A45CliCod = new string[] {""} ;
         P00EG5_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         A231DocCliCod = "";
         A149TipCod = "";
         A946DocTipo = "";
         A232DocFec = DateTime.MinValue;
         A941DocSts = "";
         P00EG6_A28ProdCod = new string[] {""} ;
         P00EG6_A149TipCod = new string[] {""} ;
         P00EG6_A24DocNum = new string[] {""} ;
         P00EG6_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EG6_A511TipSigno = new short[1] ;
         P00EG6_A230DocMonCod = new int[1] ;
         P00EG6_A899DocDcto = new decimal[1] ;
         P00EG6_A226DocMovCod = new int[1] ;
         P00EG6_A892DocDTot = new decimal[1] ;
         P00EG6_A895DocDCan = new decimal[1] ;
         P00EG6_A882DocAnticipos = new decimal[1] ;
         P00EG6_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P00EG6_A941DocSts = new string[] {""} ;
         P00EG6_A946DocTipo = new string[] {""} ;
         P00EG6_A158ZonCod = new int[1] ;
         P00EG6_n158ZonCod = new bool[] {false} ;
         P00EG6_A227DocVendCod = new int[1] ;
         P00EG6_A231DocCliCod = new string[] {""} ;
         P00EG6_A159TipCCod = new int[1] ;
         P00EG6_n159TipCCod = new bool[] {false} ;
         P00EG6_A51SublCod = new int[1] ;
         P00EG6_n51SublCod = new bool[] {false} ;
         P00EG6_A52LinCod = new int[1] ;
         P00EG6_A178TieCod = new int[1] ;
         P00EG6_n178TieCod = new bool[] {false} ;
         P00EG6_A894DocDpre = new decimal[1] ;
         P00EG6_A55ProdDsc = new string[] {""} ;
         P00EG6_A233DocItem = new long[1] ;
         A24DocNum = "";
         A929DocFecRef = DateTime.MinValue;
         AV43ProdCod = "";
         AV44ProdDsc = "";
         AV60TipCod2 = "";
         AV21DocNum2 = "";
         AV27Fecha = DateTime.MinValue;
         GXt_char3 = "";
         AV52SDTVentaProductosITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV51SDTVentaProductos = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         P00EG7_A235MovVCod = new int[1] ;
         P00EG7_A1242MovVAbr = new string[] {""} ;
         A1242MovVAbr = "";
         P00EG9_A24DocNum = new string[] {""} ;
         P00EG9_A149TipCod = new string[] {""} ;
         P00EG9_A927DocSubExonerado = new decimal[1] ;
         P00EG9_A922DocSubSelectivo = new decimal[1] ;
         P00EG9_A921DocSubInafecto = new decimal[1] ;
         P00EG9_A920DocSubAfecto = new decimal[1] ;
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV35Logo = "";
         sImgUrl = "";
         AV33Filtro5 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrventasproductos__default(),
            new Object[][] {
                new Object[] {
               P00EG2_A52LinCod, P00EG2_A1153LinDsc
               }
               , new Object[] {
               P00EG3_A51SublCod, P00EG3_A1892SublDsc
               }
               , new Object[] {
               P00EG4_A28ProdCod, P00EG4_A55ProdDsc
               }
               , new Object[] {
               P00EG5_A45CliCod, P00EG5_A161CliDsc
               }
               , new Object[] {
               P00EG6_A28ProdCod, P00EG6_A149TipCod, P00EG6_A24DocNum, P00EG6_A232DocFec, P00EG6_A511TipSigno, P00EG6_A230DocMonCod, P00EG6_A899DocDcto, P00EG6_A226DocMovCod, P00EG6_A892DocDTot, P00EG6_A895DocDCan,
               P00EG6_A882DocAnticipos, P00EG6_A929DocFecRef, P00EG6_A941DocSts, P00EG6_A946DocTipo, P00EG6_A158ZonCod, P00EG6_n158ZonCod, P00EG6_A227DocVendCod, P00EG6_A231DocCliCod, P00EG6_A159TipCCod, P00EG6_n159TipCCod,
               P00EG6_A51SublCod, P00EG6_n51SublCod, P00EG6_A52LinCod, P00EG6_A178TieCod, P00EG6_n178TieCod, P00EG6_A894DocDpre, P00EG6_A55ProdDsc, P00EG6_A233DocItem
               }
               , new Object[] {
               P00EG7_A235MovVCod, P00EG7_A1242MovVAbr
               }
               , new Object[] {
               P00EG9_A24DocNum, P00EG9_A149TipCod, P00EG9_A927DocSubExonerado, P00EG9_A922DocSubSelectivo, P00EG9_A921DocSubInafecto, P00EG9_A920DocSubAfecto
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
      private short AV12CheckRec ;
      private short A511TipSigno ;
      private short AV62TipSigno ;
      private int AV39pLinCod ;
      private int AV45pSubLCod ;
      private int AV49pZonCod ;
      private int AV48pVenCod ;
      private int AV46pTieCod ;
      private int AV47pTipCCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A178TieCod ;
      private int A159TipCCod ;
      private int A227DocVendCod ;
      private int A158ZonCod ;
      private int A230DocMonCod ;
      private int A226DocMovCod ;
      private int AV36MonCod ;
      private int AV20DocMovCod ;
      private int GXt_int2 ;
      private int AV84GXV1 ;
      private int Gx_OldLine ;
      private int A235MovVCod ;
      private long A233DocItem ;
      private decimal AV64TotalGeneral ;
      private decimal AV65TotalGeneralME ;
      private decimal A899DocDcto ;
      private decimal A892DocDTot ;
      private decimal A895DocDCan ;
      private decimal A882DocAnticipos ;
      private decimal A894DocDpre ;
      private decimal AV68TotalVenta ;
      private decimal AV69TotalVentaME ;
      private decimal AV67TotalMN ;
      private decimal AV66TotalME ;
      private decimal AV10Cant ;
      private decimal AV11Cantidad ;
      private decimal AV56TCantidad ;
      private decimal AV41PorDscto ;
      private decimal AV14Descuento ;
      private decimal AV63Total ;
      private decimal AV15DocAnticipos ;
      private decimal AV18DocDTot ;
      private decimal AV9Cambio ;
      private decimal GXt_decimal1 ;
      private decimal AV40Porcentaje ;
      private decimal AV55SubTotal ;
      private decimal AV8Anticipo ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A919DocSub ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV42pProdCod ;
      private string AV61Tipo ;
      private string AV38pDocCliCod ;
      private string AV23Empresa ;
      private string AV22EmpDir ;
      private string AV24EmpRUC ;
      private string AV50Ruta ;
      private string AV29Filtro1 ;
      private string AV30Filtro2 ;
      private string AV31Filtro3 ;
      private string AV32Filtro4 ;
      private string scmdbuf ;
      private string A1153LinDsc ;
      private string A1892SublDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A231DocCliCod ;
      private string A149TipCod ;
      private string A946DocTipo ;
      private string A941DocSts ;
      private string A24DocNum ;
      private string AV43ProdCod ;
      private string AV44ProdDsc ;
      private string AV60TipCod2 ;
      private string AV21DocNum2 ;
      private string GXt_char3 ;
      private string A1242MovVAbr ;
      private string Gx_time ;
      private string sImgUrl ;
      private string AV33Filtro5 ;
      private DateTime AV26FDesde ;
      private DateTime AV28FHasta ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV27Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n51SublCod ;
      private bool BRKEG7 ;
      private bool n158ZonCod ;
      private bool n159TipCCod ;
      private bool n178TieCod ;
      private bool returnInSub ;
      private string AV74Logo_GXI ;
      private string AV35Logo ;
      private string Logo ;
      private IGxSession AV53Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_pLinCod ;
      private int aP1_pSubLCod ;
      private string aP2_pProdCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private string aP5_Tipo ;
      private string aP6_pDocCliCod ;
      private int aP7_pZonCod ;
      private int aP8_pVenCod ;
      private int aP9_pTieCod ;
      private int aP10_pTipCCod ;
      private short aP11_CheckRec ;
      private IDataStoreProvider pr_default ;
      private int[] P00EG2_A52LinCod ;
      private string[] P00EG2_A1153LinDsc ;
      private int[] P00EG3_A51SublCod ;
      private bool[] P00EG3_n51SublCod ;
      private string[] P00EG3_A1892SublDsc ;
      private string[] P00EG4_A28ProdCod ;
      private string[] P00EG4_A55ProdDsc ;
      private string[] P00EG5_A45CliCod ;
      private string[] P00EG5_A161CliDsc ;
      private string[] P00EG6_A28ProdCod ;
      private string[] P00EG6_A149TipCod ;
      private string[] P00EG6_A24DocNum ;
      private DateTime[] P00EG6_A232DocFec ;
      private short[] P00EG6_A511TipSigno ;
      private int[] P00EG6_A230DocMonCod ;
      private decimal[] P00EG6_A899DocDcto ;
      private int[] P00EG6_A226DocMovCod ;
      private decimal[] P00EG6_A892DocDTot ;
      private decimal[] P00EG6_A895DocDCan ;
      private decimal[] P00EG6_A882DocAnticipos ;
      private DateTime[] P00EG6_A929DocFecRef ;
      private string[] P00EG6_A941DocSts ;
      private string[] P00EG6_A946DocTipo ;
      private int[] P00EG6_A158ZonCod ;
      private bool[] P00EG6_n158ZonCod ;
      private int[] P00EG6_A227DocVendCod ;
      private string[] P00EG6_A231DocCliCod ;
      private int[] P00EG6_A159TipCCod ;
      private bool[] P00EG6_n159TipCCod ;
      private int[] P00EG6_A51SublCod ;
      private bool[] P00EG6_n51SublCod ;
      private int[] P00EG6_A52LinCod ;
      private int[] P00EG6_A178TieCod ;
      private bool[] P00EG6_n178TieCod ;
      private decimal[] P00EG6_A894DocDpre ;
      private string[] P00EG6_A55ProdDsc ;
      private long[] P00EG6_A233DocItem ;
      private int[] P00EG7_A235MovVCod ;
      private string[] P00EG7_A1242MovVAbr ;
      private string[] P00EG9_A24DocNum ;
      private string[] P00EG9_A149TipCod ;
      private decimal[] P00EG9_A927DocSubExonerado ;
      private decimal[] P00EG9_A922DocSubSelectivo ;
      private decimal[] P00EG9_A921DocSubInafecto ;
      private decimal[] P00EG9_A920DocSubAfecto ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV51SDTVentaProductos ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV52SDTVentaProductosITem ;
   }

   public class rrventasproductos__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EG6( IGxContext context ,
                                             int AV46pTieCod ,
                                             int AV39pLinCod ,
                                             int AV45pSubLCod ,
                                             string AV42pProdCod ,
                                             int AV47pTipCCod ,
                                             string AV38pDocCliCod ,
                                             int AV48pVenCod ,
                                             int AV49pZonCod ,
                                             short AV12CheckRec ,
                                             string AV61Tipo ,
                                             int A178TieCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A28ProdCod ,
                                             int A159TipCCod ,
                                             string A231DocCliCod ,
                                             int A227DocVendCod ,
                                             int A158ZonCod ,
                                             string A149TipCod ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV26FDesde ,
                                             DateTime AV28FHasta ,
                                             string A941DocSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCod], T1.[TipCod], T1.[DocNum], T4.[DocFec], T3.[TipSigno], T4.[DocMonCod], T4.[DocDcto], T4.[DocMovCod], T1.[DocDTot], T1.[DocDCan], T4.[DocAnticipos], T4.[DocFecRef], T4.[DocSts], T4.[DocTipo], T5.[ZonCod], T4.[DocVendCod], T4.[DocCliCod] AS DocCliCod, T5.[TipCCod], T2.[SublCod], T2.[LinCod], T4.[TieCod], T1.[DocDpre], T2.[ProdDsc], T1.[DocItem] FROM (((([CLVENTASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CLVENTAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum]) INNER JOIN [CLCLIENTES] T5 ON T5.[CliCod] = T4.[DocCliCod])";
         AddWhere(sWhereString, "(T4.[DocFec] >= @AV26FDesde and T4.[DocFec] <= @AV28FHasta)");
         AddWhere(sWhereString, "(T4.[DocSts] <> 'A')");
         if ( ! (0==AV46pTieCod) )
         {
            AddWhere(sWhereString, "(T4.[TieCod] = @AV46pTieCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV39pLinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV39pLinCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV45pSubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV45pSubLCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42pProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV42pProdCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV47pTipCCod) )
         {
            AddWhere(sWhereString, "(T5.[TipCCod] = @AV47pTipCCod)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38pDocCliCod)) )
         {
            AddWhere(sWhereString, "(T4.[DocCliCod] = @AV38pDocCliCod)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV48pVenCod) )
         {
            AddWhere(sWhereString, "(T4.[DocVendCod] = @AV48pVenCod)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV49pZonCod) )
         {
            AddWhere(sWhereString, "(T5.[ZonCod] = @AV49pZonCod)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV12CheckRec == 0 )
         {
            AddWhere(sWhereString, "(Not T1.[TipCod] = 'REC')");
         }
         if ( StringUtil.StrCmp(AV61Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV61Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV61Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] <> 'X')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 4 :
                     return conditional_P00EG6(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] );
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
          Object[] prmP00EG2;
          prmP00EG2 = new Object[] {
          new ParDef("@AV39pLinCod",GXType.Int32,6,0)
          };
          Object[] prmP00EG3;
          prmP00EG3 = new Object[] {
          new ParDef("@AV45pSubLCod",GXType.Int32,6,0)
          };
          Object[] prmP00EG4;
          prmP00EG4 = new Object[] {
          new ParDef("@AV42pProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00EG5;
          prmP00EG5 = new Object[] {
          new ParDef("@AV38pDocCliCod",GXType.NChar,20,0)
          };
          Object[] prmP00EG7;
          prmP00EG7 = new Object[] {
          new ParDef("@AV20DocMovCod",GXType.Int32,6,0)
          };
          Object[] prmP00EG9;
          prmP00EG9 = new Object[] {
          new ParDef("@AV60TipCod2",GXType.NChar,3,0) ,
          new ParDef("@AV21DocNum2",GXType.NChar,12,0)
          };
          Object[] prmP00EG6;
          prmP00EG6 = new Object[] {
          new ParDef("@AV26FDesde",GXType.Date,8,0) ,
          new ParDef("@AV28FHasta",GXType.Date,8,0) ,
          new ParDef("@AV46pTieCod",GXType.Int32,6,0) ,
          new ParDef("@AV39pLinCod",GXType.Int32,6,0) ,
          new ParDef("@AV45pSubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV42pProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV47pTipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV38pDocCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV48pVenCod",GXType.Int32,6,0) ,
          new ParDef("@AV49pZonCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EG2", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV39pLinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EG2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EG3", "SELECT [SublCod], [SublDsc] FROM [CSUBLPROD] WHERE [SublCod] = @AV45pSubLCod ORDER BY [SublCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EG3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EG4", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV42pProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EG4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EG5", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV38pDocCliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EG5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EG6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EG6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EG7", "SELECT [MovVCod], [MovVAbr] FROM [CMOVVENTAS] WHERE [MovVCod] = @AV20DocMovCod ORDER BY [MovVCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EG7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EG9", "SELECT T1.[DocNum], T1.[TipCod], COALESCE( T2.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T2.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T2.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T2.[DocSubAfecto], 0) AS DocSubAfecto FROM ([CLVENTAS] T1 LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) WHERE T1.[TipCod] = @AV60TipCod2 and T1.[DocNum] = @AV21DocNum2 ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EG9,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 1);
                ((string[]) buf[13])[0] = rslt.getString(14, 1);
                ((int[]) buf[14])[0] = rslt.getInt(15);
                ((bool[]) buf[15])[0] = rslt.wasNull(15);
                ((int[]) buf[16])[0] = rslt.getInt(16);
                ((string[]) buf[17])[0] = rslt.getString(17, 20);
                ((int[]) buf[18])[0] = rslt.getInt(18);
                ((bool[]) buf[19])[0] = rslt.wasNull(18);
                ((int[]) buf[20])[0] = rslt.getInt(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((int[]) buf[22])[0] = rslt.getInt(20);
                ((int[]) buf[23])[0] = rslt.getInt(21);
                ((bool[]) buf[24])[0] = rslt.wasNull(21);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(22);
                ((string[]) buf[26])[0] = rslt.getString(23, 100);
                ((long[]) buf[27])[0] = rslt.getLong(24);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
             case 6 :
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
