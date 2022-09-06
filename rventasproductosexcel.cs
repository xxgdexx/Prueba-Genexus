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
using GeneXus.XML;
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class rventasproductosexcel : GXProcedure
   {
      public rventasproductosexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rventasproductosexcel( IGxContext context )
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
                           ref short aP11_CheckRec ,
                           out string aP12_Filename ,
                           out string aP13_ErrorMessage )
      {
         this.AV56pLinCod = aP0_pLinCod;
         this.AV67pSubLCod = aP1_pSubLCod;
         this.AV59pProdCod = aP2_pProdCod;
         this.AV28FDesde = aP3_FDesde;
         this.AV30FHasta = aP4_FHasta;
         this.AV82Tipo = aP5_Tipo;
         this.AV45pDocCliCod = aP6_pDocCliCod;
         this.AV71pZonCod = aP7_pZonCod;
         this.AV70pVenCod = aP8_pVenCod;
         this.AV68pTieCod = aP9_pTieCod;
         this.AV69pTipCCod = aP10_pTipCCod;
         this.AV16CheckRec = aP11_CheckRec;
         this.AV31Filename = "" ;
         this.AV25ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_pLinCod=this.AV56pLinCod;
         aP1_pSubLCod=this.AV67pSubLCod;
         aP2_pProdCod=this.AV59pProdCod;
         aP3_FDesde=this.AV28FDesde;
         aP4_FHasta=this.AV30FHasta;
         aP5_Tipo=this.AV82Tipo;
         aP6_pDocCliCod=this.AV45pDocCliCod;
         aP7_pZonCod=this.AV71pZonCod;
         aP8_pVenCod=this.AV70pVenCod;
         aP9_pTieCod=this.AV68pTieCod;
         aP10_pTipCCod=this.AV69pTipCCod;
         aP11_CheckRec=this.AV16CheckRec;
         aP12_Filename=this.AV31Filename;
         aP13_ErrorMessage=this.AV25ErrorMessage;
      }

      public string executeUdp( ref int aP0_pLinCod ,
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
                                ref short aP11_CheckRec ,
                                out string aP12_Filename )
      {
         execute(ref aP0_pLinCod, ref aP1_pSubLCod, ref aP2_pProdCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_Tipo, ref aP6_pDocCliCod, ref aP7_pZonCod, ref aP8_pVenCod, ref aP9_pTieCod, ref aP10_pTipCCod, ref aP11_CheckRec, out aP12_Filename, out aP13_ErrorMessage);
         return AV25ErrorMessage ;
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
                                 ref short aP11_CheckRec ,
                                 out string aP12_Filename ,
                                 out string aP13_ErrorMessage )
      {
         rventasproductosexcel objrventasproductosexcel;
         objrventasproductosexcel = new rventasproductosexcel();
         objrventasproductosexcel.AV56pLinCod = aP0_pLinCod;
         objrventasproductosexcel.AV67pSubLCod = aP1_pSubLCod;
         objrventasproductosexcel.AV59pProdCod = aP2_pProdCod;
         objrventasproductosexcel.AV28FDesde = aP3_FDesde;
         objrventasproductosexcel.AV30FHasta = aP4_FHasta;
         objrventasproductosexcel.AV82Tipo = aP5_Tipo;
         objrventasproductosexcel.AV45pDocCliCod = aP6_pDocCliCod;
         objrventasproductosexcel.AV71pZonCod = aP7_pZonCod;
         objrventasproductosexcel.AV70pVenCod = aP8_pVenCod;
         objrventasproductosexcel.AV68pTieCod = aP9_pTieCod;
         objrventasproductosexcel.AV69pTipCCod = aP10_pTipCCod;
         objrventasproductosexcel.AV16CheckRec = aP11_CheckRec;
         objrventasproductosexcel.AV31Filename = "" ;
         objrventasproductosexcel.AV25ErrorMessage = "" ;
         objrventasproductosexcel.context.SetSubmitInitialConfig(context);
         objrventasproductosexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrventasproductosexcel);
         aP0_pLinCod=this.AV56pLinCod;
         aP1_pSubLCod=this.AV67pSubLCod;
         aP2_pProdCod=this.AV59pProdCod;
         aP3_FDesde=this.AV28FDesde;
         aP4_FHasta=this.AV30FHasta;
         aP5_Tipo=this.AV82Tipo;
         aP6_pDocCliCod=this.AV45pDocCliCod;
         aP7_pZonCod=this.AV71pZonCod;
         aP8_pVenCod=this.AV70pVenCod;
         aP9_pTieCod=this.AV68pTieCod;
         aP10_pTipCCod=this.AV69pTipCCod;
         aP11_CheckRec=this.AV16CheckRec;
         aP12_Filename=this.AV31Filename;
         aP13_ErrorMessage=this.AV25ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rventasproductosexcel)stateInfo).executePrivate();
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
         AV12Archivo.Source = "Excel/PlantillasRVentasProductos.xlsx";
         AV44Path = AV12Archivo.GetPath();
         AV32FilenameOrigen = StringUtil.Trim( AV44Path) + "\\PlantillasRVentasProductos.xlsx";
         AV31Filename = "Excel/VentasProductos" + ".xlsx";
         AV26ExcelDocument.Clear();
         AV26ExcelDocument.Template = AV32FilenameOrigen;
         AV26ExcelDocument.Open(AV31Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV15CellRow = 6;
         AV36FirstColumn = 1;
         AV37Item = 0;
         AV33Filtro1 = "Del : " + context.localUtil.DToC( AV28FDesde, 2, "/") + " Al : " + context.localUtil.DToC( AV30FHasta, 2, "/");
         AV26ExcelDocument.get_Cells(3, (int)(AV36FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV33Filtro1);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV68pTieCod ,
                                              AV56pLinCod ,
                                              AV67pSubLCod ,
                                              AV59pProdCod ,
                                              AV69pTipCCod ,
                                              AV45pDocCliCod ,
                                              AV70pVenCod ,
                                              AV71pZonCod ,
                                              AV16CheckRec ,
                                              AV82Tipo ,
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
                                              AV28FDesde ,
                                              AV30FHasta ,
                                              A941DocSts } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00EH2 */
         pr_default.execute(0, new Object[] {AV28FDesde, AV30FHasta, AV68pTieCod, AV56pLinCod, AV67pSubLCod, AV59pProdCod, AV69pTipCCod, AV45pDocCliCod, AV70pVenCod, AV71pZonCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKEH2 = false;
            A28ProdCod = P00EH2_A28ProdCod[0];
            A149TipCod = P00EH2_A149TipCod[0];
            A24DocNum = P00EH2_A24DocNum[0];
            A232DocFec = P00EH2_A232DocFec[0];
            A511TipSigno = P00EH2_A511TipSigno[0];
            A230DocMonCod = P00EH2_A230DocMonCod[0];
            A899DocDcto = P00EH2_A899DocDcto[0];
            A226DocMovCod = P00EH2_A226DocMovCod[0];
            A892DocDTot = P00EH2_A892DocDTot[0];
            A895DocDCan = P00EH2_A895DocDCan[0];
            A882DocAnticipos = P00EH2_A882DocAnticipos[0];
            A929DocFecRef = P00EH2_A929DocFecRef[0];
            A941DocSts = P00EH2_A941DocSts[0];
            A946DocTipo = P00EH2_A946DocTipo[0];
            A158ZonCod = P00EH2_A158ZonCod[0];
            n158ZonCod = P00EH2_n158ZonCod[0];
            A227DocVendCod = P00EH2_A227DocVendCod[0];
            A231DocCliCod = P00EH2_A231DocCliCod[0];
            A159TipCCod = P00EH2_A159TipCCod[0];
            n159TipCCod = P00EH2_n159TipCCod[0];
            A51SublCod = P00EH2_A51SublCod[0];
            n51SublCod = P00EH2_n51SublCod[0];
            A52LinCod = P00EH2_A52LinCod[0];
            A178TieCod = P00EH2_A178TieCod[0];
            n178TieCod = P00EH2_n178TieCod[0];
            A894DocDpre = P00EH2_A894DocDpre[0];
            A55ProdDsc = P00EH2_A55ProdDsc[0];
            A233DocItem = P00EH2_A233DocItem[0];
            A51SublCod = P00EH2_A51SublCod[0];
            n51SublCod = P00EH2_n51SublCod[0];
            A52LinCod = P00EH2_A52LinCod[0];
            A55ProdDsc = P00EH2_A55ProdDsc[0];
            A511TipSigno = P00EH2_A511TipSigno[0];
            A232DocFec = P00EH2_A232DocFec[0];
            A230DocMonCod = P00EH2_A230DocMonCod[0];
            A899DocDcto = P00EH2_A899DocDcto[0];
            A226DocMovCod = P00EH2_A226DocMovCod[0];
            A882DocAnticipos = P00EH2_A882DocAnticipos[0];
            A929DocFecRef = P00EH2_A929DocFecRef[0];
            A941DocSts = P00EH2_A941DocSts[0];
            A946DocTipo = P00EH2_A946DocTipo[0];
            A227DocVendCod = P00EH2_A227DocVendCod[0];
            A231DocCliCod = P00EH2_A231DocCliCod[0];
            A178TieCod = P00EH2_A178TieCod[0];
            n178TieCod = P00EH2_n178TieCod[0];
            A158ZonCod = P00EH2_A158ZonCod[0];
            n158ZonCod = P00EH2_n158ZonCod[0];
            A159TipCCod = P00EH2_A159TipCCod[0];
            n159TipCCod = P00EH2_n159TipCCod[0];
            AV62ProdCod = A28ProdCod;
            AV64ProdDsc = A55ProdDsc;
            AV91TotalVenta = 0.00m;
            AV92TotalVentaME = 0.00m;
            AV90TotalMN = 0.00m;
            AV89TotalME = 0.00m;
            AV14Cant = 0.00m;
            AV8Cantidad = 0.00m;
            AV10TCantidad = 0.00m;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00EH2_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRKEH2 = false;
               A149TipCod = P00EH2_A149TipCod[0];
               A24DocNum = P00EH2_A24DocNum[0];
               A232DocFec = P00EH2_A232DocFec[0];
               A511TipSigno = P00EH2_A511TipSigno[0];
               A230DocMonCod = P00EH2_A230DocMonCod[0];
               A899DocDcto = P00EH2_A899DocDcto[0];
               A226DocMovCod = P00EH2_A226DocMovCod[0];
               A892DocDTot = P00EH2_A892DocDTot[0];
               A895DocDCan = P00EH2_A895DocDCan[0];
               A882DocAnticipos = P00EH2_A882DocAnticipos[0];
               A929DocFecRef = P00EH2_A929DocFecRef[0];
               A233DocItem = P00EH2_A233DocItem[0];
               A511TipSigno = P00EH2_A511TipSigno[0];
               A232DocFec = P00EH2_A232DocFec[0];
               A230DocMonCod = P00EH2_A230DocMonCod[0];
               A899DocDcto = P00EH2_A899DocDcto[0];
               A226DocMovCod = P00EH2_A226DocMovCod[0];
               A882DocAnticipos = P00EH2_A882DocAnticipos[0];
               A929DocFecRef = P00EH2_A929DocFecRef[0];
               if ( StringUtil.StrCmp(A28ProdCod, AV62ProdCod) == 0 )
               {
                  AV81TipCod2 = A149TipCod;
                  AV24DocNum2 = A24DocNum;
                  AV29Fecha = A232DocFec;
                  AV84TipSigno = A511TipSigno;
                  AV40MonCod = A230DocMonCod;
                  AV58PorDscto = A899DocDcto;
                  AV9DocMovCod = A226DocMovCod;
                  AV19Descuento = (decimal)(NumberUtil.Round( (NumberUtil.Round( A892DocDTot, 2)*AV58PorDscto)/ (decimal)(100), 2)*A511TipSigno);
                  AV86Total = NumberUtil.Round( (NumberUtil.Round( A892DocDTot, 2)-AV19Descuento)*A511TipSigno, 2);
                  AV14Cant = NumberUtil.Round( A895DocDCan*A511TipSigno, 2);
                  AV20DocAnticipos = (decimal)(NumberUtil.Round( A882DocAnticipos, 2)*A511TipSigno);
                  AV23DocDTot = (decimal)(NumberUtil.Round( A892DocDTot, 2)*A511TipSigno);
                  if ( ( StringUtil.StrCmp(AV81TipCod2, "NC") == 0 ) || ( StringUtil.StrCmp(AV81TipCod2, "ND") == 0 ) )
                  {
                     /* Execute user subroutine: 'VALIDATIPOMOVIMIENTO' */
                     S131 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        this.cleanup();
                        if (true) return;
                     }
                     AV29Fecha = A929DocFecRef;
                  }
                  GXt_decimal1 = AV13Cambio;
                  GXt_int2 = 2;
                  GXt_char3 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV29Fecha, ref  GXt_char3, out  GXt_decimal1) ;
                  AV13Cambio = GXt_decimal1;
                  if ( ! (Convert.ToDecimal(0)==AV20DocAnticipos) )
                  {
                     /* Execute user subroutine: 'SUBTOTAL' */
                     S141 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        this.cleanup();
                        if (true) return;
                     }
                     AV57Porcentaje = NumberUtil.Round( AV23DocDTot/ (decimal)(AV76SubTotal), 10);
                     AV11Anticipo = NumberUtil.Round( AV57Porcentaje*AV20DocAnticipos, 2);
                  }
                  else
                  {
                     AV57Porcentaje = 0.00m;
                     AV11Anticipo = 0.00m;
                     AV76SubTotal = 0.00m;
                  }
                  AV86Total = (decimal)(AV86Total-(AV11Anticipo+AV19Descuento));
                  AV90TotalMN = ((AV40MonCod==1) ? AV86Total : NumberUtil.Round( AV86Total*AV13Cambio, 2));
                  AV89TotalME = ((AV40MonCod==1) ? NumberUtil.Round( AV86Total/ (decimal)(AV13Cambio), 2) : AV86Total);
                  AV91TotalVenta = (decimal)(AV91TotalVenta+AV90TotalMN);
                  AV92TotalVentaME = (decimal)(AV92TotalVentaME+AV89TotalME);
                  AV8Cantidad = (decimal)(AV8Cantidad+AV14Cant);
               }
               BRKEH2 = true;
               pr_default.readNext(0);
            }
            AV73SDTVentaProductosITem.gxTpr_Clicod = AV62ProdCod;
            AV73SDTVentaProductosITem.gxTpr_Clidsc = AV64ProdDsc;
            AV73SDTVentaProductosITem.gxTpr_Cantidad = AV8Cantidad;
            AV73SDTVentaProductosITem.gxTpr_Importe = AV91TotalVenta;
            AV73SDTVentaProductosITem.gxTpr_Importe1 = AV92TotalVentaME;
            AV72SDTVentaProductos.Add(AV73SDTVentaProductosITem, 0);
            AV73SDTVentaProductosITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
            AV87TotalGeneral = (decimal)(AV87TotalGeneral+AV91TotalVenta);
            if ( ! BRKEH2 )
            {
               BRKEH2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV72SDTVentaProductos.Sort("[Importe]");
         AV87TotalGeneral = 0.00m;
         AV88TotalGeneralME = 0.00m;
         AV103GXV1 = 1;
         while ( AV103GXV1 <= AV72SDTVentaProductos.Count )
         {
            AV73SDTVentaProductosITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV72SDTVentaProductos.Item(AV103GXV1));
            AV62ProdCod = AV73SDTVentaProductosITem.gxTpr_Clicod;
            AV64ProdDsc = AV73SDTVentaProductosITem.gxTpr_Clidsc;
            AV8Cantidad = AV73SDTVentaProductosITem.gxTpr_Cantidad;
            AV91TotalVenta = AV73SDTVentaProductosITem.gxTpr_Importe;
            AV92TotalVentaME = AV73SDTVentaProductosITem.gxTpr_Importe1;
            /* Execute user subroutine: 'DETALLE' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            AV87TotalGeneral = (decimal)(AV87TotalGeneral+AV91TotalVenta);
            AV88TotalGeneralME = (decimal)(AV88TotalGeneralME+AV92TotalVentaME);
            AV103GXV1 = (int)(AV103GXV1+1);
         }
         AV26ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV26ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV26ExcelDocument.get_Cells((int)(AV15CellRow), (int)(AV36FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV62ProdCod);
         AV26ExcelDocument.get_Cells((int)(AV15CellRow), (int)(AV36FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV64ProdDsc);
         AV26ExcelDocument.get_Cells((int)(AV15CellRow), (int)(AV36FirstColumn+2), 1, 1).Number = (double)(AV8Cantidad);
         AV26ExcelDocument.get_Cells((int)(AV15CellRow), (int)(AV36FirstColumn+3), 1, 1).Number = (double)(AV91TotalVenta);
         AV26ExcelDocument.get_Cells((int)(AV15CellRow), (int)(AV36FirstColumn+4), 1, 1).Number = (double)(AV92TotalVentaME);
         AV15CellRow = (long)(AV15CellRow+1);
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV26ExcelDocument.ErrCode != 0 )
         {
            AV31Filename = "";
            AV25ErrorMessage = AV26ExcelDocument.ErrDescription;
            AV26ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S131( )
      {
         /* 'VALIDATIPOMOVIMIENTO' Routine */
         returnInSub = false;
         /* Using cursor P00EH3 */
         pr_default.execute(1, new Object[] {AV9DocMovCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A235MovVCod = P00EH3_A235MovVCod[0];
            A1242MovVAbr = P00EH3_A1242MovVAbr[0];
            if ( ! ( StringUtil.StrCmp(A1242MovVAbr, "SI") == 0 ) )
            {
               AV14Cant = 0.00m;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'SUBTOTAL' Routine */
         returnInSub = false;
         /* Using cursor P00EH5 */
         pr_default.execute(2, new Object[] {AV81TipCod2, AV24DocNum2});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A24DocNum = P00EH5_A24DocNum[0];
            A149TipCod = P00EH5_A149TipCod[0];
            A927DocSubExonerado = P00EH5_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EH5_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EH5_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EH5_A920DocSubAfecto[0];
            A927DocSubExonerado = P00EH5_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EH5_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EH5_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EH5_A920DocSubAfecto[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            AV76SubTotal = NumberUtil.Round( A919DocSub, 2);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
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
         AV31Filename = "";
         AV25ErrorMessage = "";
         AV12Archivo = new GxFile(context.GetPhysicalPath());
         AV44Path = "";
         AV32FilenameOrigen = "";
         AV26ExcelDocument = new ExcelDocumentI();
         AV33Filtro1 = "";
         scmdbuf = "";
         A28ProdCod = "";
         A231DocCliCod = "";
         A149TipCod = "";
         A946DocTipo = "";
         A232DocFec = DateTime.MinValue;
         A941DocSts = "";
         P00EH2_A28ProdCod = new string[] {""} ;
         P00EH2_A149TipCod = new string[] {""} ;
         P00EH2_A24DocNum = new string[] {""} ;
         P00EH2_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EH2_A511TipSigno = new short[1] ;
         P00EH2_A230DocMonCod = new int[1] ;
         P00EH2_A899DocDcto = new decimal[1] ;
         P00EH2_A226DocMovCod = new int[1] ;
         P00EH2_A892DocDTot = new decimal[1] ;
         P00EH2_A895DocDCan = new decimal[1] ;
         P00EH2_A882DocAnticipos = new decimal[1] ;
         P00EH2_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P00EH2_A941DocSts = new string[] {""} ;
         P00EH2_A946DocTipo = new string[] {""} ;
         P00EH2_A158ZonCod = new int[1] ;
         P00EH2_n158ZonCod = new bool[] {false} ;
         P00EH2_A227DocVendCod = new int[1] ;
         P00EH2_A231DocCliCod = new string[] {""} ;
         P00EH2_A159TipCCod = new int[1] ;
         P00EH2_n159TipCCod = new bool[] {false} ;
         P00EH2_A51SublCod = new int[1] ;
         P00EH2_n51SublCod = new bool[] {false} ;
         P00EH2_A52LinCod = new int[1] ;
         P00EH2_A178TieCod = new int[1] ;
         P00EH2_n178TieCod = new bool[] {false} ;
         P00EH2_A894DocDpre = new decimal[1] ;
         P00EH2_A55ProdDsc = new string[] {""} ;
         P00EH2_A233DocItem = new long[1] ;
         A24DocNum = "";
         A929DocFecRef = DateTime.MinValue;
         A55ProdDsc = "";
         AV62ProdCod = "";
         AV64ProdDsc = "";
         AV81TipCod2 = "";
         AV24DocNum2 = "";
         AV29Fecha = DateTime.MinValue;
         GXt_char3 = "";
         AV73SDTVentaProductosITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV72SDTVentaProductos = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         P00EH3_A235MovVCod = new int[1] ;
         P00EH3_A1242MovVAbr = new string[] {""} ;
         A1242MovVAbr = "";
         P00EH5_A24DocNum = new string[] {""} ;
         P00EH5_A149TipCod = new string[] {""} ;
         P00EH5_A927DocSubExonerado = new decimal[1] ;
         P00EH5_A922DocSubSelectivo = new decimal[1] ;
         P00EH5_A921DocSubInafecto = new decimal[1] ;
         P00EH5_A920DocSubAfecto = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rventasproductosexcel__default(),
            new Object[][] {
                new Object[] {
               P00EH2_A28ProdCod, P00EH2_A149TipCod, P00EH2_A24DocNum, P00EH2_A232DocFec, P00EH2_A511TipSigno, P00EH2_A230DocMonCod, P00EH2_A899DocDcto, P00EH2_A226DocMovCod, P00EH2_A892DocDTot, P00EH2_A895DocDCan,
               P00EH2_A882DocAnticipos, P00EH2_A929DocFecRef, P00EH2_A941DocSts, P00EH2_A946DocTipo, P00EH2_A158ZonCod, P00EH2_n158ZonCod, P00EH2_A227DocVendCod, P00EH2_A231DocCliCod, P00EH2_A159TipCCod, P00EH2_n159TipCCod,
               P00EH2_A51SublCod, P00EH2_n51SublCod, P00EH2_A52LinCod, P00EH2_A178TieCod, P00EH2_n178TieCod, P00EH2_A894DocDpre, P00EH2_A55ProdDsc, P00EH2_A233DocItem
               }
               , new Object[] {
               P00EH3_A235MovVCod, P00EH3_A1242MovVAbr
               }
               , new Object[] {
               P00EH5_A24DocNum, P00EH5_A149TipCod, P00EH5_A927DocSubExonerado, P00EH5_A922DocSubSelectivo, P00EH5_A921DocSubInafecto, P00EH5_A920DocSubAfecto
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16CheckRec ;
      private short A511TipSigno ;
      private short AV84TipSigno ;
      private int AV56pLinCod ;
      private int AV67pSubLCod ;
      private int AV71pZonCod ;
      private int AV70pVenCod ;
      private int AV68pTieCod ;
      private int AV69pTipCCod ;
      private int AV37Item ;
      private int A178TieCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A159TipCCod ;
      private int A227DocVendCod ;
      private int A158ZonCod ;
      private int A230DocMonCod ;
      private int A226DocMovCod ;
      private int AV40MonCod ;
      private int AV9DocMovCod ;
      private int GXt_int2 ;
      private int AV103GXV1 ;
      private int A235MovVCod ;
      private long AV15CellRow ;
      private long AV36FirstColumn ;
      private long A233DocItem ;
      private decimal A899DocDcto ;
      private decimal A892DocDTot ;
      private decimal A895DocDCan ;
      private decimal A882DocAnticipos ;
      private decimal A894DocDpre ;
      private decimal AV91TotalVenta ;
      private decimal AV92TotalVentaME ;
      private decimal AV90TotalMN ;
      private decimal AV89TotalME ;
      private decimal AV14Cant ;
      private decimal AV8Cantidad ;
      private decimal AV10TCantidad ;
      private decimal AV58PorDscto ;
      private decimal AV19Descuento ;
      private decimal AV86Total ;
      private decimal AV20DocAnticipos ;
      private decimal AV23DocDTot ;
      private decimal AV13Cambio ;
      private decimal GXt_decimal1 ;
      private decimal AV57Porcentaje ;
      private decimal AV76SubTotal ;
      private decimal AV11Anticipo ;
      private decimal AV87TotalGeneral ;
      private decimal AV88TotalGeneralME ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A919DocSub ;
      private string AV59pProdCod ;
      private string AV82Tipo ;
      private string AV45pDocCliCod ;
      private string AV44Path ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A231DocCliCod ;
      private string A149TipCod ;
      private string A946DocTipo ;
      private string A941DocSts ;
      private string A24DocNum ;
      private string A55ProdDsc ;
      private string AV62ProdCod ;
      private string AV64ProdDsc ;
      private string AV81TipCod2 ;
      private string AV24DocNum2 ;
      private string GXt_char3 ;
      private string A1242MovVAbr ;
      private DateTime AV28FDesde ;
      private DateTime AV30FHasta ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV29Fecha ;
      private bool returnInSub ;
      private bool BRKEH2 ;
      private bool n158ZonCod ;
      private bool n159TipCCod ;
      private bool n51SublCod ;
      private bool n178TieCod ;
      private string AV31Filename ;
      private string AV25ErrorMessage ;
      private string AV32FilenameOrigen ;
      private string AV33Filtro1 ;
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
      private string[] P00EH2_A28ProdCod ;
      private string[] P00EH2_A149TipCod ;
      private string[] P00EH2_A24DocNum ;
      private DateTime[] P00EH2_A232DocFec ;
      private short[] P00EH2_A511TipSigno ;
      private int[] P00EH2_A230DocMonCod ;
      private decimal[] P00EH2_A899DocDcto ;
      private int[] P00EH2_A226DocMovCod ;
      private decimal[] P00EH2_A892DocDTot ;
      private decimal[] P00EH2_A895DocDCan ;
      private decimal[] P00EH2_A882DocAnticipos ;
      private DateTime[] P00EH2_A929DocFecRef ;
      private string[] P00EH2_A941DocSts ;
      private string[] P00EH2_A946DocTipo ;
      private int[] P00EH2_A158ZonCod ;
      private bool[] P00EH2_n158ZonCod ;
      private int[] P00EH2_A227DocVendCod ;
      private string[] P00EH2_A231DocCliCod ;
      private int[] P00EH2_A159TipCCod ;
      private bool[] P00EH2_n159TipCCod ;
      private int[] P00EH2_A51SublCod ;
      private bool[] P00EH2_n51SublCod ;
      private int[] P00EH2_A52LinCod ;
      private int[] P00EH2_A178TieCod ;
      private bool[] P00EH2_n178TieCod ;
      private decimal[] P00EH2_A894DocDpre ;
      private string[] P00EH2_A55ProdDsc ;
      private long[] P00EH2_A233DocItem ;
      private int[] P00EH3_A235MovVCod ;
      private string[] P00EH3_A1242MovVAbr ;
      private string[] P00EH5_A24DocNum ;
      private string[] P00EH5_A149TipCod ;
      private decimal[] P00EH5_A927DocSubExonerado ;
      private decimal[] P00EH5_A922DocSubSelectivo ;
      private decimal[] P00EH5_A921DocSubInafecto ;
      private decimal[] P00EH5_A920DocSubAfecto ;
      private string aP12_Filename ;
      private string aP13_ErrorMessage ;
      private ExcelDocumentI AV26ExcelDocument ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV72SDTVentaProductos ;
      private GxFile AV12Archivo ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV73SDTVentaProductosITem ;
   }

   public class rventasproductosexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EH2( IGxContext context ,
                                             int AV68pTieCod ,
                                             int AV56pLinCod ,
                                             int AV67pSubLCod ,
                                             string AV59pProdCod ,
                                             int AV69pTipCCod ,
                                             string AV45pDocCliCod ,
                                             int AV70pVenCod ,
                                             int AV71pZonCod ,
                                             short AV16CheckRec ,
                                             string AV82Tipo ,
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
                                             DateTime AV28FDesde ,
                                             DateTime AV30FHasta ,
                                             string A941DocSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCod], T1.[TipCod], T1.[DocNum], T4.[DocFec], T3.[TipSigno], T4.[DocMonCod], T4.[DocDcto], T4.[DocMovCod], T1.[DocDTot], T1.[DocDCan], T4.[DocAnticipos], T4.[DocFecRef], T4.[DocSts], T4.[DocTipo], T5.[ZonCod], T4.[DocVendCod], T4.[DocCliCod] AS DocCliCod, T5.[TipCCod], T2.[SublCod], T2.[LinCod], T4.[TieCod], T1.[DocDpre], T2.[ProdDsc], T1.[DocItem] FROM (((([CLVENTASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CLVENTAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum]) INNER JOIN [CLCLIENTES] T5 ON T5.[CliCod] = T4.[DocCliCod])";
         AddWhere(sWhereString, "(T4.[DocFec] >= @AV28FDesde and T4.[DocFec] <= @AV30FHasta)");
         AddWhere(sWhereString, "(T4.[DocSts] <> 'A')");
         if ( ! (0==AV68pTieCod) )
         {
            AddWhere(sWhereString, "(T4.[TieCod] = @AV68pTieCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV56pLinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV56pLinCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV67pSubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV67pSubLCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59pProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV59pProdCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV69pTipCCod) )
         {
            AddWhere(sWhereString, "(T5.[TipCCod] = @AV69pTipCCod)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45pDocCliCod)) )
         {
            AddWhere(sWhereString, "(T4.[DocCliCod] = @AV45pDocCliCod)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV70pVenCod) )
         {
            AddWhere(sWhereString, "(T4.[DocVendCod] = @AV70pVenCod)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV71pZonCod) )
         {
            AddWhere(sWhereString, "(T5.[ZonCod] = @AV71pZonCod)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV16CheckRec == 0 )
         {
            AddWhere(sWhereString, "(Not T1.[TipCod] = 'REC')");
         }
         if ( StringUtil.StrCmp(AV82Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV82Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV82Tipo, "V") == 0 )
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
               case 0 :
                     return conditional_P00EH2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00EH3;
          prmP00EH3 = new Object[] {
          new ParDef("@AV9DocMovCod",GXType.Int32,6,0)
          };
          Object[] prmP00EH5;
          prmP00EH5 = new Object[] {
          new ParDef("@AV81TipCod2",GXType.NChar,3,0) ,
          new ParDef("@AV24DocNum2",GXType.NChar,12,0)
          };
          Object[] prmP00EH2;
          prmP00EH2 = new Object[] {
          new ParDef("@AV28FDesde",GXType.Date,8,0) ,
          new ParDef("@AV30FHasta",GXType.Date,8,0) ,
          new ParDef("@AV68pTieCod",GXType.Int32,6,0) ,
          new ParDef("@AV56pLinCod",GXType.Int32,6,0) ,
          new ParDef("@AV67pSubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV59pProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV69pTipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV45pDocCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV70pVenCod",GXType.Int32,6,0) ,
          new ParDef("@AV71pZonCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EH2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EH2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EH3", "SELECT [MovVCod], [MovVAbr] FROM [CMOVVENTAS] WHERE [MovVCod] = @AV9DocMovCod ORDER BY [MovVCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EH3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EH5", "SELECT T1.[DocNum], T1.[TipCod], COALESCE( T2.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T2.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T2.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T2.[DocSubAfecto], 0) AS DocSubAfecto FROM ([CLVENTAS] T1 LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) WHERE T1.[TipCod] = @AV81TipCod2 and T1.[DocNum] = @AV24DocNum2 ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EH5,1, GxCacheFrequency.OFF ,false,true )
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
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
             case 2 :
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
