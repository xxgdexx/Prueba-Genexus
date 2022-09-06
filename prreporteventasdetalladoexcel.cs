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
   public class prreporteventasdetalladoexcel : GXProcedure
   {
      public prreporteventasdetalladoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public prreporteventasdetalladoexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_Lincod ,
                           ref int aP1_SublCod ,
                           ref int aP2_FamCod ,
                           ref int aP3_Vendedor ,
                           ref string aP4_ProdCod ,
                           ref string aP5_CliCod ,
                           ref int aP6_MonCod ,
                           ref DateTime aP7_FDesde ,
                           ref DateTime aP8_FHasta ,
                           ref short aP9_Opc ,
                           ref string aP10_Tipo ,
                           ref int aP11_ZonCod ,
                           ref int aP12_TieCod ,
                           ref int aP13_TipCCod ,
                           ref short aP14_CheckRec ,
                           out string aP15_Filename ,
                           out string aP16_ErrorMessage )
      {
         this.AV61Lincod = aP0_Lincod;
         this.AV87SublCod = aP1_SublCod;
         this.AV48FamCod = aP2_FamCod;
         this.AV113Vendedor = aP3_Vendedor;
         this.AV81ProdCod = aP4_ProdCod;
         this.AV15CliCod = aP5_CliCod;
         this.AV64MonCod = aP6_MonCod;
         this.AV50FDesde = aP7_FDesde;
         this.AV52FHasta = aP8_FHasta;
         this.AV66Opc = aP9_Opc;
         this.AV94Tipo = aP10_Tipo;
         this.AV115ZonCod = aP11_ZonCod;
         this.AV90TieCod = aP12_TieCod;
         this.AV117TipCCod = aP13_TipCCod;
         this.AV14CheckRec = aP14_CheckRec;
         this.AV53Filename = "" ;
         this.AV45ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Lincod=this.AV61Lincod;
         aP1_SublCod=this.AV87SublCod;
         aP2_FamCod=this.AV48FamCod;
         aP3_Vendedor=this.AV113Vendedor;
         aP4_ProdCod=this.AV81ProdCod;
         aP5_CliCod=this.AV15CliCod;
         aP6_MonCod=this.AV64MonCod;
         aP7_FDesde=this.AV50FDesde;
         aP8_FHasta=this.AV52FHasta;
         aP9_Opc=this.AV66Opc;
         aP10_Tipo=this.AV94Tipo;
         aP11_ZonCod=this.AV115ZonCod;
         aP12_TieCod=this.AV90TieCod;
         aP13_TipCCod=this.AV117TipCCod;
         aP14_CheckRec=this.AV14CheckRec;
         aP15_Filename=this.AV53Filename;
         aP16_ErrorMessage=this.AV45ErrorMessage;
      }

      public string executeUdp( ref int aP0_Lincod ,
                                ref int aP1_SublCod ,
                                ref int aP2_FamCod ,
                                ref int aP3_Vendedor ,
                                ref string aP4_ProdCod ,
                                ref string aP5_CliCod ,
                                ref int aP6_MonCod ,
                                ref DateTime aP7_FDesde ,
                                ref DateTime aP8_FHasta ,
                                ref short aP9_Opc ,
                                ref string aP10_Tipo ,
                                ref int aP11_ZonCod ,
                                ref int aP12_TieCod ,
                                ref int aP13_TipCCod ,
                                ref short aP14_CheckRec ,
                                out string aP15_Filename )
      {
         execute(ref aP0_Lincod, ref aP1_SublCod, ref aP2_FamCod, ref aP3_Vendedor, ref aP4_ProdCod, ref aP5_CliCod, ref aP6_MonCod, ref aP7_FDesde, ref aP8_FHasta, ref aP9_Opc, ref aP10_Tipo, ref aP11_ZonCod, ref aP12_TieCod, ref aP13_TipCCod, ref aP14_CheckRec, out aP15_Filename, out aP16_ErrorMessage);
         return AV45ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_Lincod ,
                                 ref int aP1_SublCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_Vendedor ,
                                 ref string aP4_ProdCod ,
                                 ref string aP5_CliCod ,
                                 ref int aP6_MonCod ,
                                 ref DateTime aP7_FDesde ,
                                 ref DateTime aP8_FHasta ,
                                 ref short aP9_Opc ,
                                 ref string aP10_Tipo ,
                                 ref int aP11_ZonCod ,
                                 ref int aP12_TieCod ,
                                 ref int aP13_TipCCod ,
                                 ref short aP14_CheckRec ,
                                 out string aP15_Filename ,
                                 out string aP16_ErrorMessage )
      {
         prreporteventasdetalladoexcel objprreporteventasdetalladoexcel;
         objprreporteventasdetalladoexcel = new prreporteventasdetalladoexcel();
         objprreporteventasdetalladoexcel.AV61Lincod = aP0_Lincod;
         objprreporteventasdetalladoexcel.AV87SublCod = aP1_SublCod;
         objprreporteventasdetalladoexcel.AV48FamCod = aP2_FamCod;
         objprreporteventasdetalladoexcel.AV113Vendedor = aP3_Vendedor;
         objprreporteventasdetalladoexcel.AV81ProdCod = aP4_ProdCod;
         objprreporteventasdetalladoexcel.AV15CliCod = aP5_CliCod;
         objprreporteventasdetalladoexcel.AV64MonCod = aP6_MonCod;
         objprreporteventasdetalladoexcel.AV50FDesde = aP7_FDesde;
         objprreporteventasdetalladoexcel.AV52FHasta = aP8_FHasta;
         objprreporteventasdetalladoexcel.AV66Opc = aP9_Opc;
         objprreporteventasdetalladoexcel.AV94Tipo = aP10_Tipo;
         objprreporteventasdetalladoexcel.AV115ZonCod = aP11_ZonCod;
         objprreporteventasdetalladoexcel.AV90TieCod = aP12_TieCod;
         objprreporteventasdetalladoexcel.AV117TipCCod = aP13_TipCCod;
         objprreporteventasdetalladoexcel.AV14CheckRec = aP14_CheckRec;
         objprreporteventasdetalladoexcel.AV53Filename = "" ;
         objprreporteventasdetalladoexcel.AV45ErrorMessage = "" ;
         objprreporteventasdetalladoexcel.context.SetSubmitInitialConfig(context);
         objprreporteventasdetalladoexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprreporteventasdetalladoexcel);
         aP0_Lincod=this.AV61Lincod;
         aP1_SublCod=this.AV87SublCod;
         aP2_FamCod=this.AV48FamCod;
         aP3_Vendedor=this.AV113Vendedor;
         aP4_ProdCod=this.AV81ProdCod;
         aP5_CliCod=this.AV15CliCod;
         aP6_MonCod=this.AV64MonCod;
         aP7_FDesde=this.AV50FDesde;
         aP8_FHasta=this.AV52FHasta;
         aP9_Opc=this.AV66Opc;
         aP10_Tipo=this.AV94Tipo;
         aP11_ZonCod=this.AV115ZonCod;
         aP12_TieCod=this.AV90TieCod;
         aP13_TipCCod=this.AV117TipCCod;
         aP14_CheckRec=this.AV14CheckRec;
         aP15_Filename=this.AV53Filename;
         aP16_ErrorMessage=this.AV45ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prreporteventasdetalladoexcel)stateInfo).executePrivate();
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
         AV11Archivo.Source = "Excel/PlantillasVentasDetallado.xlsx";
         AV67Path = AV11Archivo.GetPath();
         AV54FilenameOrigen = StringUtil.Trim( AV67Path) + "\\PlantillasVentasDetallado.xlsx";
         AV53Filename = "Excel/VentasDetallado" + ".xlsx";
         AV46ExcelDocument.Clear();
         AV46ExcelDocument.Template = AV54FilenameOrigen;
         AV46ExcelDocument.Open(AV53Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Using cursor P00EI2 */
         pr_default.execute(0, new Object[] {AV15CliCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A45CliCod = P00EI2_A45CliCod[0];
            A161CliDsc = P00EI2_A161CliDsc[0];
            AV55Filtro1 = A161CliDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00EI3 */
         pr_default.execute(1, new Object[] {AV64MonCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A180MonCod = P00EI3_A180MonCod[0];
            A1234MonDsc = P00EI3_A1234MonDsc[0];
            n1234MonDsc = P00EI3_n1234MonDsc[0];
            A1233MonAbr = P00EI3_A1233MonAbr[0];
            AV56Filtro2 = A1234MonDsc;
            AV63MonAbr = A1233MonAbr;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV13CellRow = 5;
         AV58FirstColumn = 1;
         AV60Item = 0;
         AV101TotGCant = 0.0000m;
         AV103TotGImp = 0.00m;
         AV100TotGCanEqv = 0.00m;
         AV46ExcelDocument.get_Cells(4, 15, 1, 1).Text = "VALOR VENTA EXPRESADO EN "+StringUtil.Trim( AV63MonAbr);
         /* Execute user subroutine: 'MUESTRADETALLES' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV46ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV46ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'MUESTRADETALLES' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV90TieCod ,
                                              AV113Vendedor ,
                                              AV15CliCod ,
                                              AV94Tipo ,
                                              AV81ProdCod ,
                                              AV87SublCod ,
                                              AV48FamCod ,
                                              AV115ZonCod ,
                                              AV117TipCCod ,
                                              AV14CheckRec ,
                                              A178TieCod ,
                                              A227DocVendCod ,
                                              A231DocCliCod ,
                                              A946DocTipo ,
                                              A28ProdCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A158ZonCod ,
                                              A159TipCCod ,
                                              A149TipCod ,
                                              A232DocFec ,
                                              AV50FDesde ,
                                              AV52FHasta ,
                                              A941DocSts } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE
                                              }
         });
         /* Using cursor P00EI4 */
         pr_default.execute(2, new Object[] {AV50FDesde, AV52FHasta, AV90TieCod, AV113Vendedor, AV15CliCod, AV94Tipo, AV81ProdCod, AV87SublCod, AV48FamCod, AV115ZonCod, AV117TipCCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A52LinCod = P00EI4_A52LinCod[0];
            A139PaiCod = P00EI4_A139PaiCod[0];
            n139PaiCod = P00EI4_n139PaiCod[0];
            A140EstCod = P00EI4_A140EstCod[0];
            n140EstCod = P00EI4_n140EstCod[0];
            A141ProvCod = P00EI4_A141ProvCod[0];
            n141ProvCod = P00EI4_n141ProvCod[0];
            A142DisCod = P00EI4_A142DisCod[0];
            n142DisCod = P00EI4_n142DisCod[0];
            A149TipCod = P00EI4_A149TipCod[0];
            A159TipCCod = P00EI4_A159TipCCod[0];
            n159TipCCod = P00EI4_n159TipCCod[0];
            A158ZonCod = P00EI4_A158ZonCod[0];
            n158ZonCod = P00EI4_n158ZonCod[0];
            A50FamCod = P00EI4_A50FamCod[0];
            n50FamCod = P00EI4_n50FamCod[0];
            A51SublCod = P00EI4_A51SublCod[0];
            n51SublCod = P00EI4_n51SublCod[0];
            A28ProdCod = P00EI4_A28ProdCod[0];
            A946DocTipo = P00EI4_A946DocTipo[0];
            A941DocSts = P00EI4_A941DocSts[0];
            A232DocFec = P00EI4_A232DocFec[0];
            A231DocCliCod = P00EI4_A231DocCliCod[0];
            A227DocVendCod = P00EI4_A227DocVendCod[0];
            A178TieCod = P00EI4_A178TieCod[0];
            n178TieCod = P00EI4_n178TieCod[0];
            A1898TieDsc = P00EI4_A1898TieDsc[0];
            A929DocFecRef = P00EI4_A929DocFecRef[0];
            A230DocMonCod = P00EI4_A230DocMonCod[0];
            A226DocMovCod = P00EI4_A226DocMovCod[0];
            A233DocItem = P00EI4_A233DocItem[0];
            A1234MonDsc = P00EI4_A1234MonDsc[0];
            n1234MonDsc = P00EI4_n1234MonDsc[0];
            A1702ProdPeso = P00EI4_A1702ProdPeso[0];
            A511TipSigno = P00EI4_A511TipSigno[0];
            A899DocDcto = P00EI4_A899DocDcto[0];
            A887DocCliDsc = P00EI4_A887DocCliDsc[0];
            A885DocCliDir = P00EI4_A885DocCliDir[0];
            A604DisDsc = P00EI4_A604DisDsc[0];
            A306TipAbr = P00EI4_A306TipAbr[0];
            A24DocNum = P00EI4_A24DocNum[0];
            A55ProdDsc = P00EI4_A55ProdDsc[0];
            A880DocAlmCod = P00EI4_A880DocAlmCod[0];
            A229DocConpCod = P00EI4_A229DocConpCod[0];
            A886DocCliDirItem = P00EI4_A886DocCliDirItem[0];
            A882DocAnticipos = P00EI4_A882DocAnticipos[0];
            A937DocPedCod = P00EI4_A937DocPedCod[0];
            A911DocDPed = P00EI4_A911DocDPed[0];
            A939DocRef = P00EI4_A939DocRef[0];
            A951DocUsuCod = P00EI4_A951DocUsuCod[0];
            A952DocUsuFec = P00EI4_A952DocUsuFec[0];
            A228DocLisp = P00EI4_A228DocLisp[0];
            n228DocLisp = P00EI4_n228DocLisp[0];
            A1153LinDsc = P00EI4_A1153LinDsc[0];
            A953DocVendDsc = P00EI4_A953DocVendDsc[0];
            A895DocDCan = P00EI4_A895DocDCan[0];
            A894DocDpre = P00EI4_A894DocDpre[0];
            A892DocDTot = P00EI4_A892DocDTot[0];
            A511TipSigno = P00EI4_A511TipSigno[0];
            A306TipAbr = P00EI4_A306TipAbr[0];
            A52LinCod = P00EI4_A52LinCod[0];
            A50FamCod = P00EI4_A50FamCod[0];
            n50FamCod = P00EI4_n50FamCod[0];
            A51SublCod = P00EI4_A51SublCod[0];
            n51SublCod = P00EI4_n51SublCod[0];
            A1702ProdPeso = P00EI4_A1702ProdPeso[0];
            A55ProdDsc = P00EI4_A55ProdDsc[0];
            A1153LinDsc = P00EI4_A1153LinDsc[0];
            A946DocTipo = P00EI4_A946DocTipo[0];
            A941DocSts = P00EI4_A941DocSts[0];
            A232DocFec = P00EI4_A232DocFec[0];
            A231DocCliCod = P00EI4_A231DocCliCod[0];
            A227DocVendCod = P00EI4_A227DocVendCod[0];
            A178TieCod = P00EI4_A178TieCod[0];
            n178TieCod = P00EI4_n178TieCod[0];
            A929DocFecRef = P00EI4_A929DocFecRef[0];
            A230DocMonCod = P00EI4_A230DocMonCod[0];
            A226DocMovCod = P00EI4_A226DocMovCod[0];
            A899DocDcto = P00EI4_A899DocDcto[0];
            A880DocAlmCod = P00EI4_A880DocAlmCod[0];
            A229DocConpCod = P00EI4_A229DocConpCod[0];
            A886DocCliDirItem = P00EI4_A886DocCliDirItem[0];
            A882DocAnticipos = P00EI4_A882DocAnticipos[0];
            A937DocPedCod = P00EI4_A937DocPedCod[0];
            A939DocRef = P00EI4_A939DocRef[0];
            A951DocUsuCod = P00EI4_A951DocUsuCod[0];
            A952DocUsuFec = P00EI4_A952DocUsuFec[0];
            A228DocLisp = P00EI4_A228DocLisp[0];
            n228DocLisp = P00EI4_n228DocLisp[0];
            A139PaiCod = P00EI4_A139PaiCod[0];
            n139PaiCod = P00EI4_n139PaiCod[0];
            A140EstCod = P00EI4_A140EstCod[0];
            n140EstCod = P00EI4_n140EstCod[0];
            A141ProvCod = P00EI4_A141ProvCod[0];
            n141ProvCod = P00EI4_n141ProvCod[0];
            A142DisCod = P00EI4_A142DisCod[0];
            n142DisCod = P00EI4_n142DisCod[0];
            A159TipCCod = P00EI4_A159TipCCod[0];
            n159TipCCod = P00EI4_n159TipCCod[0];
            A158ZonCod = P00EI4_A158ZonCod[0];
            n158ZonCod = P00EI4_n158ZonCod[0];
            A887DocCliDsc = P00EI4_A887DocCliDsc[0];
            A885DocCliDir = P00EI4_A885DocCliDir[0];
            A604DisDsc = P00EI4_A604DisDsc[0];
            A953DocVendDsc = P00EI4_A953DocVendDsc[0];
            A1898TieDsc = P00EI4_A1898TieDsc[0];
            A1234MonDsc = P00EI4_A1234MonDsc[0];
            n1234MonDsc = P00EI4_n1234MonDsc[0];
            A893DocDSub = NumberUtil.Round( A894DocDpre*A895DocDCan, 4);
            A900DocDDcto = NumberUtil.Round( A893DocDSub-A892DocDTot, 2);
            AV114VenDsc = A953DocVendDsc;
            AV92TipCod = A149TipCod;
            AV8TieDsc = A1898TieDsc;
            AV34DocFec = A232DocFec;
            AV35DocFecRef = A929DocFecRef;
            AV38DocMonCod = A230DocMonCod;
            AV39DocMovCod = A226DocMovCod;
            AV36DocItem = A233DocItem;
            AV65MonDsc = A1234MonDsc;
            AV84ProdPeso = A1702ProdPeso;
            AV96TipSigno = A511TipSigno;
            AV30DocDcto = A899DocDcto;
            AV23DocCliCod = A231DocCliCod;
            AV25DocCliDsc = A887DocCliDsc;
            AV119CliDir = A885DocCliDir;
            AV117TipCCod = A159TipCCod;
            AV118DisDsc = A604DisDsc;
            AV91TipAbr = A306TipAbr;
            AV40DocNum = A24DocNum;
            AV62LineaNom = A1153LinDsc;
            AV82ProdCodC = A28ProdCod;
            AV83ProdDsc = A55ProdDsc;
            AV29DocDCan = (decimal)(A895DocDCan*AV96TipSigno);
            AV115ZonCod = A158ZonCod;
            AV21DocAlmCod = A880DocAlmCod;
            AV27DocConpCod = A229DocConpCod;
            AV24DocCliDirItem = A886DocCliDirItem;
            AV22DocAnticipos = A882DocAnticipos;
            AV41DocPedCod = (String.IsNullOrEmpty(StringUtil.RTrim( A911DocDPed)) ? A937DocPedCod : A911DocDPed);
            AV42DocRef = A939DocRef;
            AV95TipoVenta = "";
            AV43DocTipo = A946DocTipo;
            AV87SublCod = A51SublCod;
            AV48FamCod = A50FamCod;
            AV88SubLDsc = "";
            AV49FamDsc = "";
            AV110UsuCod = A951DocUsuCod;
            AV111UsuFec = A952DocUsuFec;
            AV59ForDsc = "";
            AV37DocLisp = A228DocLisp;
            AV93TipLDsc = "";
            AV120TipCDsc = "";
            AV22DocAnticipos = NumberUtil.Round( A882DocAnticipos, 2);
            AV33DocDTot = NumberUtil.Round( A892DocDTot, 2);
            if ( ! (Convert.ToDecimal(0)==AV22DocAnticipos) )
            {
               /* Execute user subroutine: 'SUBTOTAL' */
               S124 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
               AV78Porcentaje = NumberUtil.Round( AV33DocDTot/ (decimal)(AV89SubTotal), 10);
               AV10Anticipo = NumberUtil.Round( AV78Porcentaje*AV22DocAnticipos, 2);
            }
            else
            {
               AV78Porcentaje = 0.00m;
               AV10Anticipo = 0.00m;
               AV89SubTotal = 0.00m;
            }
            if ( ( StringUtil.StrCmp(AV43DocTipo, "V") == 0 ) || ( StringUtil.StrCmp(AV43DocTipo, "P") == 0 ) || ( StringUtil.StrCmp(AV43DocTipo, "U") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( AV43DocTipo)) )
            {
               AV95TipoVenta = "Venta Normal";
            }
            if ( StringUtil.StrCmp(AV43DocTipo, "S") == 0 )
            {
               AV95TipoVenta = "Venta de Servicios";
            }
            if ( StringUtil.StrCmp(AV43DocTipo, "M") == 0 )
            {
               AV95TipoVenta = "Venta de Muestra";
            }
            if ( StringUtil.StrCmp(AV43DocTipo, "A") == 0 )
            {
               AV95TipoVenta = "Venta de Anticipos";
            }
            if ( StringUtil.StrCmp(AV43DocTipo, "E") == 0 )
            {
               AV95TipoVenta = "Venta de Exportación";
            }
            if ( StringUtil.StrCmp(AV43DocTipo, "X") == 0 )
            {
               AV95TipoVenta = "Venta de Muestra Exportación";
            }
            GXt_decimal1 = AV18Costo;
            new pobtienecostorentabilidadpromedio(context ).execute(  AV92TipCod,  AV40DocNum,  AV82ProdCodC,  AV36DocItem,  AV64MonCod, out  GXt_decimal1) ;
            AV18Costo = GXt_decimal1;
            /* Execute user subroutine: 'ZONA' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            AV51Fecha = ((StringUtil.StrCmp(AV92TipCod, "NC")==0)||(StringUtil.StrCmp(AV92TipCod, "ND")==0) ? AV35DocFecRef : AV34DocFec);
            GXt_decimal1 = AV97TipVenta;
            GXt_int2 = 2;
            GXt_char3 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV51Fecha, ref  GXt_char3, out  GXt_decimal1) ;
            AV97TipVenta = GXt_decimal1;
            if ( AV64MonCod == 1 )
            {
               AV19DescProd = (decimal)(NumberUtil.Round( A900DocDDcto, 2)*AV96TipSigno);
               AV20Descuento = (decimal)(NumberUtil.Round( (A892DocDTot*AV30DocDcto)/ (decimal)(100), 2)*AV96TipSigno);
               AV33DocDTot = (decimal)(NumberUtil.Round( A892DocDTot, 2)*AV96TipSigno);
               AV22DocAnticipos = (decimal)(NumberUtil.Round( AV10Anticipo, 2)*AV96TipSigno);
               AV32DocDPre = (decimal)(NumberUtil.Round( A894DocDpre, 4)*AV96TipSigno);
               if ( AV38DocMonCod == 2 )
               {
                  AV33DocDTot = NumberUtil.Round( AV33DocDTot*AV97TipVenta, 2);
                  AV22DocAnticipos = NumberUtil.Round( AV22DocAnticipos*AV97TipVenta, 2);
                  AV32DocDPre = NumberUtil.Round( AV32DocDPre*AV97TipVenta, 2);
                  AV19DescProd = NumberUtil.Round( AV19DescProd*AV97TipVenta, 2);
                  AV20Descuento = NumberUtil.Round( AV20Descuento*AV97TipVenta, 2);
               }
            }
            else
            {
               AV19DescProd = (decimal)(NumberUtil.Round( A900DocDDcto, 2)*AV96TipSigno);
               AV20Descuento = (decimal)(NumberUtil.Round( (A892DocDTot*AV30DocDcto)/ (decimal)(100), 2)*AV96TipSigno);
               AV33DocDTot = (decimal)(NumberUtil.Round( A892DocDTot, 2)*AV96TipSigno);
               AV22DocAnticipos = (decimal)(NumberUtil.Round( AV10Anticipo, 2)*AV96TipSigno);
               AV32DocDPre = (decimal)(NumberUtil.Round( A894DocDpre, 4)*AV96TipSigno);
               if ( AV38DocMonCod == 1 )
               {
                  AV19DescProd = NumberUtil.Round( AV19DescProd/ (decimal)(AV97TipVenta), 2);
                  AV33DocDTot = NumberUtil.Round( AV33DocDTot/ (decimal)(AV97TipVenta), 2);
                  AV32DocDPre = NumberUtil.Round( AV32DocDPre/ (decimal)(AV97TipVenta), 2);
                  AV20Descuento = NumberUtil.Round( AV20Descuento/ (decimal)(AV97TipVenta), 2);
                  AV22DocAnticipos = NumberUtil.Round( AV22DocAnticipos/ (decimal)(AV97TipVenta), 2);
               }
            }
            AV33DocDTot = (decimal)(AV33DocDTot-(AV22DocAnticipos+AV20Descuento));
            AV12CanEQV = NumberUtil.Round( AV29DocDCan*AV84ProdPeso, 4);
            /* Execute user subroutine: 'VALIDATIPOMOVIMIENTO' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'DETALLE' */
            S154 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            AV99TotCant = (decimal)(AV99TotCant+AV29DocDCan);
            AV107TotImp = (decimal)(AV107TotImp+AV33DocDTot);
            AV98TotCanEqv = (decimal)(AV98TotCanEqv+AV12CanEQV);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S161( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV46ExcelDocument.ErrCode != 0 )
         {
            AV53Filename = "";
            AV45ErrorMessage = AV46ExcelDocument.ErrDescription;
            AV46ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S154( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV114VenDsc);
         GXt_dtime4 = DateTimeUtil.ResetTime( AV34DocFec ) ;
         AV46ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+1), 1, 1).Date = GXt_dtime4;
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+2), 1, 1).Text = StringUtil.Trim( AV23DocCliCod);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+3), 1, 1).Text = StringUtil.Trim( AV25DocCliDsc);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+4), 1, 1).Text = StringUtil.Trim( AV91TipAbr);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+5), 1, 1).Text = StringUtil.Trim( AV40DocNum);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+6), 1, 1).Text = StringUtil.Trim( AV41DocPedCod);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+7), 1, 1).Text = StringUtil.Trim( AV65MonDsc);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+8), 1, 1).Text = StringUtil.Trim( AV82ProdCodC);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+9), 1, 1).Text = StringUtil.Trim( AV62LineaNom);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+10), 1, 1).Text = StringUtil.Trim( AV88SubLDsc);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+11), 1, 1).Text = StringUtil.Trim( AV49FamDsc);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+12), 1, 1).Text = StringUtil.Trim( AV83ProdDsc);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+13), 1, 1).Number = (double)(AV29DocDCan);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+14), 1, 1).Number = (double)(AV32DocDPre);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+15), 1, 1).Number = (double)(AV19DescProd);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+16), 1, 1).Number = (double)(AV20Descuento);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+17), 1, 1).Number = (double)(AV33DocDTot);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+18), 1, 1).Number = (double)(AV97TipVenta);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+19), 1, 1).Text = StringUtil.Trim( AV116ZonDsc);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+20), 1, 1).Text = StringUtil.Trim( AV9AlmDsc);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+21), 1, 1).Text = StringUtil.Trim( AV28DocConpDsc);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+22), 1, 1).Number = (double)(AV18Costo);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+23), 1, 1).Text = StringUtil.Trim( AV95TipoVenta);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+24), 1, 1).Text = StringUtil.Trim( AV8TieDsc);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+25), 1, 1).Text = StringUtil.Trim( AV93TipLDsc);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+26), 1, 1).Text = StringUtil.Trim( AV59ForDsc);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+27), 1, 1).Text = StringUtil.Trim( AV42DocRef);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+28), 1, 1).Text = StringUtil.Trim( AV118DisDsc);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+29), 1, 1).Text = StringUtil.Trim( AV119CliDir);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+30), 1, 1).Text = StringUtil.Trim( AV120TipCDsc);
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+31), 1, 1).Text = StringUtil.Trim( AV110UsuCod);
         AV46ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV46ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV58FirstColumn+32), 1, 1).Date = AV111UsuFec;
         AV13CellRow = (long)(AV13CellRow+1);
      }

      protected void S134( )
      {
         /* 'ZONA' Routine */
         returnInSub = false;
         new pobtenerzonacliente(context ).execute( ref  AV23DocCliCod, ref  AV24DocCliDirItem, out  AV115ZonCod, out  AV116ZonDsc) ;
         AV9AlmDsc = "";
         /* Using cursor P00EI5 */
         pr_default.execute(3, new Object[] {AV21DocAlmCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A63AlmCod = P00EI5_A63AlmCod[0];
            A436AlmDsc = P00EI5_A436AlmDsc[0];
            AV9AlmDsc = StringUtil.Trim( A436AlmDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         AV28DocConpDsc = "";
         /* Using cursor P00EI6 */
         pr_default.execute(4, new Object[] {AV27DocConpCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A137Conpcod = P00EI6_A137Conpcod[0];
            A753ConpDsc = P00EI6_A753ConpDsc[0];
            AV28DocConpDsc = A753ConpDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         AV26DocCliDscSuc = "";
         if ( ! (0==AV24DocCliDirItem) )
         {
            /* Using cursor P00EI7 */
            pr_default.execute(5, new Object[] {AV23DocCliCod, AV24DocCliDirItem});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A164CliDirItem = P00EI7_A164CliDirItem[0];
               A45CliCod = P00EI7_A45CliCod[0];
               A600CliDirDsc = P00EI7_A600CliDirDsc[0];
               AV26DocCliDscSuc = StringUtil.Trim( A600CliDirDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
         }
         /* Using cursor P00EI8 */
         pr_default.execute(6, new Object[] {AV87SublCod});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A51SublCod = P00EI8_A51SublCod[0];
            n51SublCod = P00EI8_n51SublCod[0];
            A1892SublDsc = P00EI8_A1892SublDsc[0];
            AV88SubLDsc = StringUtil.Trim( A1892SublDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
         /* Using cursor P00EI9 */
         pr_default.execute(7, new Object[] {AV48FamCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A50FamCod = P00EI9_A50FamCod[0];
            n50FamCod = P00EI9_n50FamCod[0];
            A977FamDsc = P00EI9_A977FamDsc[0];
            AV49FamDsc = StringUtil.Trim( A977FamDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(7);
         /* Using cursor P00EI10 */
         pr_default.execute(8, new Object[] {AV37DocLisp});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A202TipLCod = P00EI10_A202TipLCod[0];
            A1912TipLDsc = P00EI10_A1912TipLDsc[0];
            AV93TipLDsc = StringUtil.Trim( A1912TipLDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(8);
         /* Using cursor P00EI11 */
         pr_default.execute(9, new Object[] {AV92TipCod, AV40DocNum});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A143ForCod = P00EI11_A143ForCod[0];
            A176CobDocNum = P00EI11_A176CobDocNum[0];
            A175CobTipCod = P00EI11_A175CobTipCod[0];
            A988ForDsc = P00EI11_A988ForDsc[0];
            A166CobTip = P00EI11_A166CobTip[0];
            A167CobCod = P00EI11_A167CobCod[0];
            A173Item = P00EI11_A173Item[0];
            A988ForDsc = P00EI11_A988ForDsc[0];
            AV59ForDsc = StringUtil.Trim( A988ForDsc);
            pr_default.readNext(9);
         }
         pr_default.close(9);
         /* Using cursor P00EI12 */
         pr_default.execute(10, new Object[] {AV117TipCCod});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A159TipCCod = P00EI12_A159TipCCod[0];
            n159TipCCod = P00EI12_n159TipCCod[0];
            A1905TipCDsc = P00EI12_A1905TipCDsc[0];
            AV120TipCDsc = A1905TipCDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(10);
      }

      protected void S124( )
      {
         /* 'SUBTOTAL' Routine */
         returnInSub = false;
         /* Using cursor P00EI14 */
         pr_default.execute(11, new Object[] {AV92TipCod, AV40DocNum});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A24DocNum = P00EI14_A24DocNum[0];
            A149TipCod = P00EI14_A149TipCod[0];
            A927DocSubExonerado = P00EI14_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EI14_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EI14_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EI14_A920DocSubAfecto[0];
            A927DocSubExonerado = P00EI14_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EI14_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EI14_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EI14_A920DocSubAfecto[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            AV89SubTotal = NumberUtil.Round( A919DocSub, 2);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(11);
      }

      protected void S144( )
      {
         /* 'VALIDATIPOMOVIMIENTO' Routine */
         returnInSub = false;
         /* Using cursor P00EI15 */
         pr_default.execute(12, new Object[] {AV39DocMovCod});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A235MovVCod = P00EI15_A235MovVCod[0];
            A1242MovVAbr = P00EI15_A1242MovVAbr[0];
            if ( ! ( StringUtil.StrCmp(A1242MovVAbr, "SI") == 0 ) )
            {
               AV29DocDCan = 0.00m;
               AV12CanEQV = 0.00m;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(12);
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
         AV53Filename = "";
         AV45ErrorMessage = "";
         AV11Archivo = new GxFile(context.GetPhysicalPath());
         AV67Path = "";
         AV54FilenameOrigen = "";
         AV46ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P00EI2_A45CliCod = new string[] {""} ;
         P00EI2_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         AV55Filtro1 = "";
         P00EI3_A180MonCod = new int[1] ;
         P00EI3_A1234MonDsc = new string[] {""} ;
         P00EI3_n1234MonDsc = new bool[] {false} ;
         P00EI3_A1233MonAbr = new string[] {""} ;
         A1234MonDsc = "";
         A1233MonAbr = "";
         AV56Filtro2 = "";
         AV63MonAbr = "";
         A231DocCliCod = "";
         A946DocTipo = "";
         A28ProdCod = "";
         A149TipCod = "";
         A232DocFec = DateTime.MinValue;
         A941DocSts = "";
         P00EI4_A52LinCod = new int[1] ;
         P00EI4_A139PaiCod = new string[] {""} ;
         P00EI4_n139PaiCod = new bool[] {false} ;
         P00EI4_A140EstCod = new string[] {""} ;
         P00EI4_n140EstCod = new bool[] {false} ;
         P00EI4_A141ProvCod = new string[] {""} ;
         P00EI4_n141ProvCod = new bool[] {false} ;
         P00EI4_A142DisCod = new string[] {""} ;
         P00EI4_n142DisCod = new bool[] {false} ;
         P00EI4_A149TipCod = new string[] {""} ;
         P00EI4_A159TipCCod = new int[1] ;
         P00EI4_n159TipCCod = new bool[] {false} ;
         P00EI4_A158ZonCod = new int[1] ;
         P00EI4_n158ZonCod = new bool[] {false} ;
         P00EI4_A50FamCod = new int[1] ;
         P00EI4_n50FamCod = new bool[] {false} ;
         P00EI4_A51SublCod = new int[1] ;
         P00EI4_n51SublCod = new bool[] {false} ;
         P00EI4_A28ProdCod = new string[] {""} ;
         P00EI4_A946DocTipo = new string[] {""} ;
         P00EI4_A941DocSts = new string[] {""} ;
         P00EI4_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EI4_A231DocCliCod = new string[] {""} ;
         P00EI4_A227DocVendCod = new int[1] ;
         P00EI4_A178TieCod = new int[1] ;
         P00EI4_n178TieCod = new bool[] {false} ;
         P00EI4_A1898TieDsc = new string[] {""} ;
         P00EI4_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P00EI4_A230DocMonCod = new int[1] ;
         P00EI4_A226DocMovCod = new int[1] ;
         P00EI4_A233DocItem = new long[1] ;
         P00EI4_A1234MonDsc = new string[] {""} ;
         P00EI4_n1234MonDsc = new bool[] {false} ;
         P00EI4_A1702ProdPeso = new decimal[1] ;
         P00EI4_A511TipSigno = new short[1] ;
         P00EI4_A899DocDcto = new decimal[1] ;
         P00EI4_A887DocCliDsc = new string[] {""} ;
         P00EI4_A885DocCliDir = new string[] {""} ;
         P00EI4_A604DisDsc = new string[] {""} ;
         P00EI4_A306TipAbr = new string[] {""} ;
         P00EI4_A24DocNum = new string[] {""} ;
         P00EI4_A55ProdDsc = new string[] {""} ;
         P00EI4_A880DocAlmCod = new int[1] ;
         P00EI4_A229DocConpCod = new int[1] ;
         P00EI4_A886DocCliDirItem = new int[1] ;
         P00EI4_A882DocAnticipos = new decimal[1] ;
         P00EI4_A937DocPedCod = new string[] {""} ;
         P00EI4_A911DocDPed = new string[] {""} ;
         P00EI4_A939DocRef = new string[] {""} ;
         P00EI4_A951DocUsuCod = new string[] {""} ;
         P00EI4_A952DocUsuFec = new DateTime[] {DateTime.MinValue} ;
         P00EI4_A228DocLisp = new int[1] ;
         P00EI4_n228DocLisp = new bool[] {false} ;
         P00EI4_A1153LinDsc = new string[] {""} ;
         P00EI4_A953DocVendDsc = new string[] {""} ;
         P00EI4_A895DocDCan = new decimal[1] ;
         P00EI4_A894DocDpre = new decimal[1] ;
         P00EI4_A892DocDTot = new decimal[1] ;
         A139PaiCod = "";
         A140EstCod = "";
         A141ProvCod = "";
         A142DisCod = "";
         A1898TieDsc = "";
         A929DocFecRef = DateTime.MinValue;
         A887DocCliDsc = "";
         A885DocCliDir = "";
         A604DisDsc = "";
         A306TipAbr = "";
         A24DocNum = "";
         A55ProdDsc = "";
         A937DocPedCod = "";
         A911DocDPed = "";
         A939DocRef = "";
         A951DocUsuCod = "";
         A952DocUsuFec = (DateTime)(DateTime.MinValue);
         A1153LinDsc = "";
         A953DocVendDsc = "";
         AV114VenDsc = "";
         AV92TipCod = "";
         AV8TieDsc = "";
         AV34DocFec = DateTime.MinValue;
         AV35DocFecRef = DateTime.MinValue;
         AV65MonDsc = "";
         AV23DocCliCod = "";
         AV25DocCliDsc = "";
         AV119CliDir = "";
         AV118DisDsc = "";
         AV91TipAbr = "";
         AV40DocNum = "";
         AV62LineaNom = "";
         AV82ProdCodC = "";
         AV83ProdDsc = "";
         AV41DocPedCod = "";
         AV42DocRef = "";
         AV95TipoVenta = "";
         AV43DocTipo = "";
         AV88SubLDsc = "";
         AV49FamDsc = "";
         AV110UsuCod = "";
         AV111UsuFec = (DateTime)(DateTime.MinValue);
         AV59ForDsc = "";
         AV93TipLDsc = "";
         AV120TipCDsc = "";
         AV51Fecha = DateTime.MinValue;
         GXt_char3 = "";
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         AV116ZonDsc = "";
         AV9AlmDsc = "";
         AV28DocConpDsc = "";
         P00EI5_A63AlmCod = new int[1] ;
         P00EI5_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         P00EI6_A137Conpcod = new int[1] ;
         P00EI6_A753ConpDsc = new string[] {""} ;
         A753ConpDsc = "";
         AV26DocCliDscSuc = "";
         P00EI7_A164CliDirItem = new int[1] ;
         P00EI7_A45CliCod = new string[] {""} ;
         P00EI7_A600CliDirDsc = new string[] {""} ;
         A600CliDirDsc = "";
         P00EI8_A51SublCod = new int[1] ;
         P00EI8_n51SublCod = new bool[] {false} ;
         P00EI8_A1892SublDsc = new string[] {""} ;
         A1892SublDsc = "";
         P00EI9_A50FamCod = new int[1] ;
         P00EI9_n50FamCod = new bool[] {false} ;
         P00EI9_A977FamDsc = new string[] {""} ;
         A977FamDsc = "";
         P00EI10_A202TipLCod = new int[1] ;
         P00EI10_A1912TipLDsc = new string[] {""} ;
         A1912TipLDsc = "";
         P00EI11_A143ForCod = new int[1] ;
         P00EI11_A176CobDocNum = new string[] {""} ;
         P00EI11_A175CobTipCod = new string[] {""} ;
         P00EI11_A988ForDsc = new string[] {""} ;
         P00EI11_A166CobTip = new string[] {""} ;
         P00EI11_A167CobCod = new string[] {""} ;
         P00EI11_A173Item = new int[1] ;
         A176CobDocNum = "";
         A175CobTipCod = "";
         A988ForDsc = "";
         A166CobTip = "";
         A167CobCod = "";
         P00EI12_A159TipCCod = new int[1] ;
         P00EI12_n159TipCCod = new bool[] {false} ;
         P00EI12_A1905TipCDsc = new string[] {""} ;
         A1905TipCDsc = "";
         P00EI14_A24DocNum = new string[] {""} ;
         P00EI14_A149TipCod = new string[] {""} ;
         P00EI14_A927DocSubExonerado = new decimal[1] ;
         P00EI14_A922DocSubSelectivo = new decimal[1] ;
         P00EI14_A921DocSubInafecto = new decimal[1] ;
         P00EI14_A920DocSubAfecto = new decimal[1] ;
         P00EI15_A235MovVCod = new int[1] ;
         P00EI15_A1242MovVAbr = new string[] {""} ;
         A1242MovVAbr = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prreporteventasdetalladoexcel__default(),
            new Object[][] {
                new Object[] {
               P00EI2_A45CliCod, P00EI2_A161CliDsc
               }
               , new Object[] {
               P00EI3_A180MonCod, P00EI3_A1234MonDsc, P00EI3_A1233MonAbr
               }
               , new Object[] {
               P00EI4_A52LinCod, P00EI4_A139PaiCod, P00EI4_n139PaiCod, P00EI4_A140EstCod, P00EI4_n140EstCod, P00EI4_A141ProvCod, P00EI4_n141ProvCod, P00EI4_A142DisCod, P00EI4_n142DisCod, P00EI4_A149TipCod,
               P00EI4_A159TipCCod, P00EI4_n159TipCCod, P00EI4_A158ZonCod, P00EI4_n158ZonCod, P00EI4_A50FamCod, P00EI4_n50FamCod, P00EI4_A51SublCod, P00EI4_n51SublCod, P00EI4_A28ProdCod, P00EI4_A946DocTipo,
               P00EI4_A941DocSts, P00EI4_A232DocFec, P00EI4_A231DocCliCod, P00EI4_A227DocVendCod, P00EI4_A178TieCod, P00EI4_n178TieCod, P00EI4_A1898TieDsc, P00EI4_A929DocFecRef, P00EI4_A230DocMonCod, P00EI4_A226DocMovCod,
               P00EI4_A233DocItem, P00EI4_A1234MonDsc, P00EI4_n1234MonDsc, P00EI4_A1702ProdPeso, P00EI4_A511TipSigno, P00EI4_A899DocDcto, P00EI4_A887DocCliDsc, P00EI4_A885DocCliDir, P00EI4_A604DisDsc, P00EI4_A306TipAbr,
               P00EI4_A24DocNum, P00EI4_A55ProdDsc, P00EI4_A880DocAlmCod, P00EI4_A229DocConpCod, P00EI4_A886DocCliDirItem, P00EI4_A882DocAnticipos, P00EI4_A937DocPedCod, P00EI4_A911DocDPed, P00EI4_A939DocRef, P00EI4_A951DocUsuCod,
               P00EI4_A952DocUsuFec, P00EI4_A228DocLisp, P00EI4_n228DocLisp, P00EI4_A1153LinDsc, P00EI4_A953DocVendDsc, P00EI4_A895DocDCan, P00EI4_A894DocDpre, P00EI4_A892DocDTot
               }
               , new Object[] {
               P00EI5_A63AlmCod, P00EI5_A436AlmDsc
               }
               , new Object[] {
               P00EI6_A137Conpcod, P00EI6_A753ConpDsc
               }
               , new Object[] {
               P00EI7_A164CliDirItem, P00EI7_A45CliCod, P00EI7_A600CliDirDsc
               }
               , new Object[] {
               P00EI8_A51SublCod, P00EI8_A1892SublDsc
               }
               , new Object[] {
               P00EI9_A50FamCod, P00EI9_A977FamDsc
               }
               , new Object[] {
               P00EI10_A202TipLCod, P00EI10_A1912TipLDsc
               }
               , new Object[] {
               P00EI11_A143ForCod, P00EI11_A176CobDocNum, P00EI11_A175CobTipCod, P00EI11_A988ForDsc, P00EI11_A166CobTip, P00EI11_A167CobCod, P00EI11_A173Item
               }
               , new Object[] {
               P00EI12_A159TipCCod, P00EI12_A1905TipCDsc
               }
               , new Object[] {
               P00EI14_A24DocNum, P00EI14_A149TipCod, P00EI14_A927DocSubExonerado, P00EI14_A922DocSubSelectivo, P00EI14_A921DocSubInafecto, P00EI14_A920DocSubAfecto
               }
               , new Object[] {
               P00EI15_A235MovVCod, P00EI15_A1242MovVAbr
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV66Opc ;
      private short AV14CheckRec ;
      private short A511TipSigno ;
      private short AV96TipSigno ;
      private int AV61Lincod ;
      private int AV87SublCod ;
      private int AV48FamCod ;
      private int AV113Vendedor ;
      private int AV64MonCod ;
      private int AV115ZonCod ;
      private int AV90TieCod ;
      private int AV117TipCCod ;
      private int A180MonCod ;
      private int AV60Item ;
      private int A178TieCod ;
      private int A227DocVendCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A158ZonCod ;
      private int A159TipCCod ;
      private int A52LinCod ;
      private int A230DocMonCod ;
      private int A226DocMovCod ;
      private int A880DocAlmCod ;
      private int A229DocConpCod ;
      private int A886DocCliDirItem ;
      private int A228DocLisp ;
      private int AV38DocMonCod ;
      private int AV39DocMovCod ;
      private int AV21DocAlmCod ;
      private int AV27DocConpCod ;
      private int AV24DocCliDirItem ;
      private int AV37DocLisp ;
      private int GXt_int2 ;
      private int A63AlmCod ;
      private int A137Conpcod ;
      private int A164CliDirItem ;
      private int A202TipLCod ;
      private int A143ForCod ;
      private int A173Item ;
      private int A235MovVCod ;
      private long AV13CellRow ;
      private long AV58FirstColumn ;
      private long A233DocItem ;
      private long AV36DocItem ;
      private decimal AV101TotGCant ;
      private decimal AV103TotGImp ;
      private decimal AV100TotGCanEqv ;
      private decimal A1702ProdPeso ;
      private decimal A899DocDcto ;
      private decimal A882DocAnticipos ;
      private decimal A895DocDCan ;
      private decimal A894DocDpre ;
      private decimal A892DocDTot ;
      private decimal A893DocDSub ;
      private decimal A900DocDDcto ;
      private decimal AV84ProdPeso ;
      private decimal AV30DocDcto ;
      private decimal AV29DocDCan ;
      private decimal AV22DocAnticipos ;
      private decimal AV33DocDTot ;
      private decimal AV78Porcentaje ;
      private decimal AV89SubTotal ;
      private decimal AV10Anticipo ;
      private decimal AV18Costo ;
      private decimal AV97TipVenta ;
      private decimal GXt_decimal1 ;
      private decimal AV19DescProd ;
      private decimal AV20Descuento ;
      private decimal AV32DocDPre ;
      private decimal AV12CanEQV ;
      private decimal AV99TotCant ;
      private decimal AV107TotImp ;
      private decimal AV98TotCanEqv ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A919DocSub ;
      private string AV81ProdCod ;
      private string AV15CliCod ;
      private string AV94Tipo ;
      private string AV67Path ;
      private string scmdbuf ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A1234MonDsc ;
      private string A1233MonAbr ;
      private string AV63MonAbr ;
      private string A231DocCliCod ;
      private string A946DocTipo ;
      private string A28ProdCod ;
      private string A149TipCod ;
      private string A941DocSts ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A141ProvCod ;
      private string A142DisCod ;
      private string A1898TieDsc ;
      private string A887DocCliDsc ;
      private string A885DocCliDir ;
      private string A604DisDsc ;
      private string A306TipAbr ;
      private string A24DocNum ;
      private string A55ProdDsc ;
      private string A937DocPedCod ;
      private string A939DocRef ;
      private string A951DocUsuCod ;
      private string A1153LinDsc ;
      private string A953DocVendDsc ;
      private string AV114VenDsc ;
      private string AV92TipCod ;
      private string AV8TieDsc ;
      private string AV65MonDsc ;
      private string AV23DocCliCod ;
      private string AV25DocCliDsc ;
      private string AV119CliDir ;
      private string AV118DisDsc ;
      private string AV91TipAbr ;
      private string AV40DocNum ;
      private string AV62LineaNom ;
      private string AV82ProdCodC ;
      private string AV83ProdDsc ;
      private string AV41DocPedCod ;
      private string AV42DocRef ;
      private string AV95TipoVenta ;
      private string AV43DocTipo ;
      private string AV88SubLDsc ;
      private string AV49FamDsc ;
      private string AV110UsuCod ;
      private string AV59ForDsc ;
      private string AV93TipLDsc ;
      private string AV120TipCDsc ;
      private string GXt_char3 ;
      private string AV116ZonDsc ;
      private string AV9AlmDsc ;
      private string AV28DocConpDsc ;
      private string A436AlmDsc ;
      private string A753ConpDsc ;
      private string AV26DocCliDscSuc ;
      private string A600CliDirDsc ;
      private string A1892SublDsc ;
      private string A977FamDsc ;
      private string A1912TipLDsc ;
      private string A176CobDocNum ;
      private string A175CobTipCod ;
      private string A988ForDsc ;
      private string A166CobTip ;
      private string A167CobCod ;
      private string A1905TipCDsc ;
      private string A1242MovVAbr ;
      private DateTime A952DocUsuFec ;
      private DateTime AV111UsuFec ;
      private DateTime GXt_dtime4 ;
      private DateTime AV50FDesde ;
      private DateTime AV52FHasta ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV34DocFec ;
      private DateTime AV35DocFecRef ;
      private DateTime AV51Fecha ;
      private bool returnInSub ;
      private bool n1234MonDsc ;
      private bool n139PaiCod ;
      private bool n140EstCod ;
      private bool n141ProvCod ;
      private bool n142DisCod ;
      private bool n159TipCCod ;
      private bool n158ZonCod ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool n178TieCod ;
      private bool n228DocLisp ;
      private string AV53Filename ;
      private string AV45ErrorMessage ;
      private string AV54FilenameOrigen ;
      private string AV55Filtro1 ;
      private string AV56Filtro2 ;
      private string A911DocDPed ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_Lincod ;
      private int aP1_SublCod ;
      private int aP2_FamCod ;
      private int aP3_Vendedor ;
      private string aP4_ProdCod ;
      private string aP5_CliCod ;
      private int aP6_MonCod ;
      private DateTime aP7_FDesde ;
      private DateTime aP8_FHasta ;
      private short aP9_Opc ;
      private string aP10_Tipo ;
      private int aP11_ZonCod ;
      private int aP12_TieCod ;
      private int aP13_TipCCod ;
      private short aP14_CheckRec ;
      private IDataStoreProvider pr_default ;
      private string[] P00EI2_A45CliCod ;
      private string[] P00EI2_A161CliDsc ;
      private int[] P00EI3_A180MonCod ;
      private string[] P00EI3_A1234MonDsc ;
      private bool[] P00EI3_n1234MonDsc ;
      private string[] P00EI3_A1233MonAbr ;
      private int[] P00EI4_A52LinCod ;
      private string[] P00EI4_A139PaiCod ;
      private bool[] P00EI4_n139PaiCod ;
      private string[] P00EI4_A140EstCod ;
      private bool[] P00EI4_n140EstCod ;
      private string[] P00EI4_A141ProvCod ;
      private bool[] P00EI4_n141ProvCod ;
      private string[] P00EI4_A142DisCod ;
      private bool[] P00EI4_n142DisCod ;
      private string[] P00EI4_A149TipCod ;
      private int[] P00EI4_A159TipCCod ;
      private bool[] P00EI4_n159TipCCod ;
      private int[] P00EI4_A158ZonCod ;
      private bool[] P00EI4_n158ZonCod ;
      private int[] P00EI4_A50FamCod ;
      private bool[] P00EI4_n50FamCod ;
      private int[] P00EI4_A51SublCod ;
      private bool[] P00EI4_n51SublCod ;
      private string[] P00EI4_A28ProdCod ;
      private string[] P00EI4_A946DocTipo ;
      private string[] P00EI4_A941DocSts ;
      private DateTime[] P00EI4_A232DocFec ;
      private string[] P00EI4_A231DocCliCod ;
      private int[] P00EI4_A227DocVendCod ;
      private int[] P00EI4_A178TieCod ;
      private bool[] P00EI4_n178TieCod ;
      private string[] P00EI4_A1898TieDsc ;
      private DateTime[] P00EI4_A929DocFecRef ;
      private int[] P00EI4_A230DocMonCod ;
      private int[] P00EI4_A226DocMovCod ;
      private long[] P00EI4_A233DocItem ;
      private string[] P00EI4_A1234MonDsc ;
      private bool[] P00EI4_n1234MonDsc ;
      private decimal[] P00EI4_A1702ProdPeso ;
      private short[] P00EI4_A511TipSigno ;
      private decimal[] P00EI4_A899DocDcto ;
      private string[] P00EI4_A887DocCliDsc ;
      private string[] P00EI4_A885DocCliDir ;
      private string[] P00EI4_A604DisDsc ;
      private string[] P00EI4_A306TipAbr ;
      private string[] P00EI4_A24DocNum ;
      private string[] P00EI4_A55ProdDsc ;
      private int[] P00EI4_A880DocAlmCod ;
      private int[] P00EI4_A229DocConpCod ;
      private int[] P00EI4_A886DocCliDirItem ;
      private decimal[] P00EI4_A882DocAnticipos ;
      private string[] P00EI4_A937DocPedCod ;
      private string[] P00EI4_A911DocDPed ;
      private string[] P00EI4_A939DocRef ;
      private string[] P00EI4_A951DocUsuCod ;
      private DateTime[] P00EI4_A952DocUsuFec ;
      private int[] P00EI4_A228DocLisp ;
      private bool[] P00EI4_n228DocLisp ;
      private string[] P00EI4_A1153LinDsc ;
      private string[] P00EI4_A953DocVendDsc ;
      private decimal[] P00EI4_A895DocDCan ;
      private decimal[] P00EI4_A894DocDpre ;
      private decimal[] P00EI4_A892DocDTot ;
      private int[] P00EI5_A63AlmCod ;
      private string[] P00EI5_A436AlmDsc ;
      private int[] P00EI6_A137Conpcod ;
      private string[] P00EI6_A753ConpDsc ;
      private int[] P00EI7_A164CliDirItem ;
      private string[] P00EI7_A45CliCod ;
      private string[] P00EI7_A600CliDirDsc ;
      private int[] P00EI8_A51SublCod ;
      private bool[] P00EI8_n51SublCod ;
      private string[] P00EI8_A1892SublDsc ;
      private int[] P00EI9_A50FamCod ;
      private bool[] P00EI9_n50FamCod ;
      private string[] P00EI9_A977FamDsc ;
      private int[] P00EI10_A202TipLCod ;
      private string[] P00EI10_A1912TipLDsc ;
      private int[] P00EI11_A143ForCod ;
      private string[] P00EI11_A176CobDocNum ;
      private string[] P00EI11_A175CobTipCod ;
      private string[] P00EI11_A988ForDsc ;
      private string[] P00EI11_A166CobTip ;
      private string[] P00EI11_A167CobCod ;
      private int[] P00EI11_A173Item ;
      private int[] P00EI12_A159TipCCod ;
      private bool[] P00EI12_n159TipCCod ;
      private string[] P00EI12_A1905TipCDsc ;
      private string[] P00EI14_A24DocNum ;
      private string[] P00EI14_A149TipCod ;
      private decimal[] P00EI14_A927DocSubExonerado ;
      private decimal[] P00EI14_A922DocSubSelectivo ;
      private decimal[] P00EI14_A921DocSubInafecto ;
      private decimal[] P00EI14_A920DocSubAfecto ;
      private int[] P00EI15_A235MovVCod ;
      private string[] P00EI15_A1242MovVAbr ;
      private string aP15_Filename ;
      private string aP16_ErrorMessage ;
      private ExcelDocumentI AV46ExcelDocument ;
      private GxFile AV11Archivo ;
   }

   public class prreporteventasdetalladoexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EI4( IGxContext context ,
                                             int AV90TieCod ,
                                             int AV113Vendedor ,
                                             string AV15CliCod ,
                                             string AV94Tipo ,
                                             string AV81ProdCod ,
                                             int AV87SublCod ,
                                             int AV48FamCod ,
                                             int AV115ZonCod ,
                                             int AV117TipCCod ,
                                             short AV14CheckRec ,
                                             int A178TieCod ,
                                             int A227DocVendCod ,
                                             string A231DocCliCod ,
                                             string A946DocTipo ,
                                             string A28ProdCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A158ZonCod ,
                                             int A159TipCCod ,
                                             string A149TipCod ,
                                             DateTime A232DocFec ,
                                             DateTime AV50FDesde ,
                                             DateTime AV52FHasta ,
                                             string A941DocSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[11];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T3.[LinCod], T6.[PaiCod], T6.[EstCod], T6.[ProvCod], T6.[DisCod], T1.[TipCod], T6.[TipCCod], T6.[ZonCod], T3.[FamCod], T3.[SublCod], T1.[ProdCod], T5.[DocTipo], T5.[DocSts], T5.[DocFec], T5.[DocCliCod] AS DocCliCod, T5.[DocVendCod] AS DocVendCod, T5.[TieCod], T9.[TieDsc], T5.[DocFecRef], T5.[DocMonCod] AS DocMonCod, T5.[DocMovCod], T1.[DocItem], T10.[MonDsc], T3.[ProdPeso], T2.[TipSigno], T5.[DocDcto], T6.[CliDsc] AS DocCliDsc, T6.[CliDir] AS DocCliDir, T7.[DisDsc], T2.[TipAbr], T1.[DocNum], T3.[ProdDsc], T5.[DocAlmCod], T5.[DocConpCod], T5.[DocCliDirItem], T5.[DocAnticipos], T5.[DocPedCod], T1.[DocDPed], T5.[DocRef], T5.[DocUsuCod], T5.[DocUsuFec], T5.[DocLisp], T4.[LinDsc], T8.[VenDsc] AS DocVendDsc, T1.[DocDCan], T1.[DocDpre], T1.[DocDTot] FROM ((((((((([CLVENTASDET] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T3.[LinCod]) INNER JOIN [CLVENTAS] T5 ON T5.[TipCod] = T1.[TipCod] AND T5.[DocNum] = T1.[DocNum]) INNER JOIN [CLCLIENTES] T6 ON T6.[CliCod] = T5.[DocCliCod]) LEFT JOIN [CDISTRITOS] T7 ON T7.[PaiCod] = T6.[PaiCod] AND T7.[EstCod] = T6.[EstCod] AND T7.[ProvCod] = T6.[ProvCod] AND T7.[DisCod] = T6.[DisCod]) INNER JOIN [CVENDEDORES] T8 ON T8.[VenCod] = T5.[DocVendCod]) LEFT JOIN [SGTIENDAS] T9 ON T9.[TieCod] = T5.[TieCod]) INNER JOIN [CMONEDAS] T10 ON T10.[MonCod] = T5.[DocMonCod])";
         AddWhere(sWhereString, "(T5.[DocFec] >= @AV50FDesde and T5.[DocFec] <= @AV52FHasta)");
         AddWhere(sWhereString, "(T5.[DocSts] <> 'A')");
         if ( ! (0==AV90TieCod) )
         {
            AddWhere(sWhereString, "(T5.[TieCod] = @AV90TieCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV113Vendedor) )
         {
            AddWhere(sWhereString, "(T5.[DocVendCod] = @AV113Vendedor)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15CliCod)) )
         {
            AddWhere(sWhereString, "(T5.[DocCliCod] = @AV15CliCod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV94Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T5.[DocTipo] = @AV94Tipo)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV94Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T5.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV94Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T5.[DocTipo] <> 'X')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV81ProdCod)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV87SublCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV87SublCod)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (0==AV48FamCod) )
         {
            AddWhere(sWhereString, "(T3.[FamCod] = @AV48FamCod)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (0==AV115ZonCod) )
         {
            AddWhere(sWhereString, "(T6.[ZonCod] = @AV115ZonCod)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (0==AV117TipCCod) )
         {
            AddWhere(sWhereString, "(T6.[TipCCod] = @AV117TipCCod)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV14CheckRec == 0 )
         {
            AddWhere(sWhereString, "(Not T1.[TipCod] = 'REC')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T8.[VenDsc], T4.[LinDsc]";
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
                     return conditional_P00EI4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00EI2;
          prmP00EI2 = new Object[] {
          new ParDef("@AV15CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00EI3;
          prmP00EI3 = new Object[] {
          new ParDef("@AV64MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00EI5;
          prmP00EI5 = new Object[] {
          new ParDef("@AV21DocAlmCod",GXType.Int32,6,0)
          };
          Object[] prmP00EI6;
          prmP00EI6 = new Object[] {
          new ParDef("@AV27DocConpCod",GXType.Int32,6,0)
          };
          Object[] prmP00EI7;
          prmP00EI7 = new Object[] {
          new ParDef("@AV23DocCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV24DocCliDirItem",GXType.Int32,6,0)
          };
          Object[] prmP00EI8;
          prmP00EI8 = new Object[] {
          new ParDef("@AV87SublCod",GXType.Int32,6,0)
          };
          Object[] prmP00EI9;
          prmP00EI9 = new Object[] {
          new ParDef("@AV48FamCod",GXType.Int32,6,0)
          };
          Object[] prmP00EI10;
          prmP00EI10 = new Object[] {
          new ParDef("@AV37DocLisp",GXType.Int32,6,0)
          };
          Object[] prmP00EI11;
          prmP00EI11 = new Object[] {
          new ParDef("@AV92TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV40DocNum",GXType.NChar,12,0)
          };
          Object[] prmP00EI12;
          prmP00EI12 = new Object[] {
          new ParDef("@AV117TipCCod",GXType.Int32,6,0)
          };
          Object[] prmP00EI14;
          prmP00EI14 = new Object[] {
          new ParDef("@AV92TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV40DocNum",GXType.NChar,12,0)
          };
          Object[] prmP00EI15;
          prmP00EI15 = new Object[] {
          new ParDef("@AV39DocMovCod",GXType.Int32,6,0)
          };
          Object[] prmP00EI4;
          prmP00EI4 = new Object[] {
          new ParDef("@AV50FDesde",GXType.Date,8,0) ,
          new ParDef("@AV52FHasta",GXType.Date,8,0) ,
          new ParDef("@AV90TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV113Vendedor",GXType.Int32,6,0) ,
          new ParDef("@AV15CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV94Tipo",GXType.NChar,1,0) ,
          new ParDef("@AV81ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV87SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV48FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV115ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV117TipCCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EI2", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV15CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EI2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EI3", "SELECT [MonCod], [MonDsc], [MonAbr] FROM [CMONEDAS] WHERE [MonCod] = @AV64MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EI3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EI4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EI4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EI5", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV21DocAlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EI5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EI6", "SELECT [Conpcod], [ConpDsc] FROM [CCONDICIONPAGO] WHERE [Conpcod] = @AV27DocConpCod ORDER BY [Conpcod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EI6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EI7", "SELECT [CliDirItem], [CliCod], [CliDirDsc] FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @AV23DocCliCod and [CliDirItem] = @AV24DocCliDirItem ORDER BY [CliCod], [CliDirItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EI7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EI8", "SELECT [SublCod], [SublDsc] FROM [CSUBLPROD] WHERE [SublCod] = @AV87SublCod ORDER BY [SublCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EI8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EI9", "SELECT [FamCod], [FamDsc] FROM [CFAMILIA] WHERE [FamCod] = @AV48FamCod ORDER BY [FamCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EI9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EI10", "SELECT [TipLCod], [TipLDsc] FROM [CTIPOSLISTAS] WHERE [TipLCod] = @AV37DocLisp ORDER BY [TipLCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EI10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EI11", "SELECT T1.[ForCod], T1.[CobDocNum], T1.[CobTipCod], T2.[ForDsc], T1.[CobTip], T1.[CobCod], T1.[Item] FROM ([CLCOBRANZADET] T1 INNER JOIN [CFORMAPAGO] T2 ON T2.[ForCod] = T1.[ForCod]) WHERE T1.[CobTipCod] = @AV92TipCod and T1.[CobDocNum] = @AV40DocNum ORDER BY T1.[CobTipCod], T1.[CobDocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EI11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EI12", "SELECT [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @AV117TipCCod ORDER BY [TipCCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EI12,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EI14", "SELECT T1.[DocNum], T1.[TipCod], COALESCE( T2.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T2.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T2.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T2.[DocSubAfecto], 0) AS DocSubAfecto FROM ([CLVENTAS] T1 LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) WHERE T1.[TipCod] = @AV92TipCod and T1.[DocNum] = @AV40DocNum ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EI14,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EI15", "SELECT [MovVCod], [MovVAbr] FROM [CMOVVENTAS] WHERE [MovVCod] = @AV39DocMovCod ORDER BY [MovVCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EI15,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 4);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 4);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getString(6, 3);
                ((int[]) buf[10])[0] = rslt.getInt(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((int[]) buf[12])[0] = rslt.getInt(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((int[]) buf[14])[0] = rslt.getInt(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((int[]) buf[16])[0] = rslt.getInt(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((string[]) buf[18])[0] = rslt.getString(11, 15);
                ((string[]) buf[19])[0] = rslt.getString(12, 1);
                ((string[]) buf[20])[0] = rslt.getString(13, 1);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(14);
                ((string[]) buf[22])[0] = rslt.getString(15, 20);
                ((int[]) buf[23])[0] = rslt.getInt(16);
                ((int[]) buf[24])[0] = rslt.getInt(17);
                ((bool[]) buf[25])[0] = rslt.wasNull(17);
                ((string[]) buf[26])[0] = rslt.getString(18, 100);
                ((DateTime[]) buf[27])[0] = rslt.getGXDate(19);
                ((int[]) buf[28])[0] = rslt.getInt(20);
                ((int[]) buf[29])[0] = rslt.getInt(21);
                ((long[]) buf[30])[0] = rslt.getLong(22);
                ((string[]) buf[31])[0] = rslt.getString(23, 100);
                ((bool[]) buf[32])[0] = rslt.wasNull(23);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(24);
                ((short[]) buf[34])[0] = rslt.getShort(25);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(26);
                ((string[]) buf[36])[0] = rslt.getString(27, 100);
                ((string[]) buf[37])[0] = rslt.getString(28, 100);
                ((string[]) buf[38])[0] = rslt.getString(29, 100);
                ((string[]) buf[39])[0] = rslt.getString(30, 5);
                ((string[]) buf[40])[0] = rslt.getString(31, 12);
                ((string[]) buf[41])[0] = rslt.getString(32, 100);
                ((int[]) buf[42])[0] = rslt.getInt(33);
                ((int[]) buf[43])[0] = rslt.getInt(34);
                ((int[]) buf[44])[0] = rslt.getInt(35);
                ((decimal[]) buf[45])[0] = rslt.getDecimal(36);
                ((string[]) buf[46])[0] = rslt.getString(37, 10);
                ((string[]) buf[47])[0] = rslt.getVarchar(38);
                ((string[]) buf[48])[0] = rslt.getString(39, 12);
                ((string[]) buf[49])[0] = rslt.getString(40, 10);
                ((DateTime[]) buf[50])[0] = rslt.getGXDateTime(41);
                ((int[]) buf[51])[0] = rslt.getInt(42);
                ((bool[]) buf[52])[0] = rslt.wasNull(42);
                ((string[]) buf[53])[0] = rslt.getString(43, 100);
                ((string[]) buf[54])[0] = rslt.getString(44, 100);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(45);
                ((decimal[]) buf[56])[0] = rslt.getDecimal(46);
                ((decimal[]) buf[57])[0] = rslt.getDecimal(47);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((string[]) buf[5])[0] = rslt.getString(6, 12);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
       }
    }

 }

}
