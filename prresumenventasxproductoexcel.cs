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
   public class prresumenventasxproductoexcel : GXProcedure
   {
      public prresumenventasxproductoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public prresumenventasxproductoexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_VenCod ,
                           ref string aP1_ProdCod ,
                           ref string aP2_CliCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref int aP5_LinCod ,
                           ref int aP6_SubLCod ,
                           ref string aP7_Tipo ,
                           ref int aP8_TieCod ,
                           out string aP9_Filename ,
                           out string aP10_ErrorMessage )
      {
         this.AV80VenCod = aP0_VenCod;
         this.AV61ProdCod = aP1_ProdCod;
         this.AV13CliCod = aP2_CliCod;
         this.AV29FDesde = aP3_FDesde;
         this.AV32FHasta = aP4_FHasta;
         this.AV41LinCod = aP5_LinCod;
         this.AV64SubLCod = aP6_SubLCod;
         this.AV70Tipo = aP7_Tipo;
         this.AV68TieCod = aP8_TieCod;
         this.AV33Filename = "" ;
         this.AV23ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_VenCod=this.AV80VenCod;
         aP1_ProdCod=this.AV61ProdCod;
         aP2_CliCod=this.AV13CliCod;
         aP3_FDesde=this.AV29FDesde;
         aP4_FHasta=this.AV32FHasta;
         aP5_LinCod=this.AV41LinCod;
         aP6_SubLCod=this.AV64SubLCod;
         aP7_Tipo=this.AV70Tipo;
         aP8_TieCod=this.AV68TieCod;
         aP9_Filename=this.AV33Filename;
         aP10_ErrorMessage=this.AV23ErrorMessage;
      }

      public string executeUdp( ref int aP0_VenCod ,
                                ref string aP1_ProdCod ,
                                ref string aP2_CliCod ,
                                ref DateTime aP3_FDesde ,
                                ref DateTime aP4_FHasta ,
                                ref int aP5_LinCod ,
                                ref int aP6_SubLCod ,
                                ref string aP7_Tipo ,
                                ref int aP8_TieCod ,
                                out string aP9_Filename )
      {
         execute(ref aP0_VenCod, ref aP1_ProdCod, ref aP2_CliCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_LinCod, ref aP6_SubLCod, ref aP7_Tipo, ref aP8_TieCod, out aP9_Filename, out aP10_ErrorMessage);
         return AV23ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_VenCod ,
                                 ref string aP1_ProdCod ,
                                 ref string aP2_CliCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref int aP5_LinCod ,
                                 ref int aP6_SubLCod ,
                                 ref string aP7_Tipo ,
                                 ref int aP8_TieCod ,
                                 out string aP9_Filename ,
                                 out string aP10_ErrorMessage )
      {
         prresumenventasxproductoexcel objprresumenventasxproductoexcel;
         objprresumenventasxproductoexcel = new prresumenventasxproductoexcel();
         objprresumenventasxproductoexcel.AV80VenCod = aP0_VenCod;
         objprresumenventasxproductoexcel.AV61ProdCod = aP1_ProdCod;
         objprresumenventasxproductoexcel.AV13CliCod = aP2_CliCod;
         objprresumenventasxproductoexcel.AV29FDesde = aP3_FDesde;
         objprresumenventasxproductoexcel.AV32FHasta = aP4_FHasta;
         objprresumenventasxproductoexcel.AV41LinCod = aP5_LinCod;
         objprresumenventasxproductoexcel.AV64SubLCod = aP6_SubLCod;
         objprresumenventasxproductoexcel.AV70Tipo = aP7_Tipo;
         objprresumenventasxproductoexcel.AV68TieCod = aP8_TieCod;
         objprresumenventasxproductoexcel.AV33Filename = "" ;
         objprresumenventasxproductoexcel.AV23ErrorMessage = "" ;
         objprresumenventasxproductoexcel.context.SetSubmitInitialConfig(context);
         objprresumenventasxproductoexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprresumenventasxproductoexcel);
         aP0_VenCod=this.AV80VenCod;
         aP1_ProdCod=this.AV61ProdCod;
         aP2_CliCod=this.AV13CliCod;
         aP3_FDesde=this.AV29FDesde;
         aP4_FHasta=this.AV32FHasta;
         aP5_LinCod=this.AV41LinCod;
         aP6_SubLCod=this.AV64SubLCod;
         aP7_Tipo=this.AV70Tipo;
         aP8_TieCod=this.AV68TieCod;
         aP9_Filename=this.AV33Filename;
         aP10_ErrorMessage=this.AV23ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prresumenventasxproductoexcel)stateInfo).executePrivate();
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
         AV9Archivo.Source = "Excel/PlantillasResumenVentaProducto.xlsx";
         AV46Path = AV9Archivo.GetPath();
         AV34FilenameOrigen = StringUtil.Trim( AV46Path) + "\\PlantillasResumenVentaProducto.xlsx";
         AV33Filename = "Excel/ResumenVentaProducto" + ".xlsx";
         AV25ExcelDocument.Clear();
         AV25ExcelDocument.Template = AV34FilenameOrigen;
         AV25ExcelDocument.Open(AV33Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV12CellRow = 6;
         AV38FirstColumn = 1;
         AV40Item = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV68TieCod ,
                                              AV13CliCod ,
                                              AV61ProdCod ,
                                              AV41LinCod ,
                                              AV64SubLCod ,
                                              AV80VenCod ,
                                              AV70Tipo ,
                                              A178TieCod ,
                                              A231DocCliCod ,
                                              A28ProdCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A227DocVendCod ,
                                              A946DocTipo ,
                                              A232DocFec ,
                                              AV29FDesde ,
                                              AV32FHasta ,
                                              A941DocSts } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00EN2 */
         pr_default.execute(0, new Object[] {AV29FDesde, AV32FHasta, AV68TieCod, AV13CliCod, AV61ProdCod, AV41LinCod, AV64SubLCod, AV80VenCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKEN2 = false;
            A149TipCod = P00EN2_A149TipCod[0];
            A24DocNum = P00EN2_A24DocNum[0];
            A1153LinDsc = P00EN2_A1153LinDsc[0];
            A52LinCod = P00EN2_A52LinCod[0];
            A941DocSts = P00EN2_A941DocSts[0];
            A946DocTipo = P00EN2_A946DocTipo[0];
            A227DocVendCod = P00EN2_A227DocVendCod[0];
            A51SublCod = P00EN2_A51SublCod[0];
            n51SublCod = P00EN2_n51SublCod[0];
            A28ProdCod = P00EN2_A28ProdCod[0];
            A231DocCliCod = P00EN2_A231DocCliCod[0];
            A232DocFec = P00EN2_A232DocFec[0];
            A178TieCod = P00EN2_A178TieCod[0];
            n178TieCod = P00EN2_n178TieCod[0];
            A894DocDpre = P00EN2_A894DocDpre[0];
            A233DocItem = P00EN2_A233DocItem[0];
            A941DocSts = P00EN2_A941DocSts[0];
            A946DocTipo = P00EN2_A946DocTipo[0];
            A227DocVendCod = P00EN2_A227DocVendCod[0];
            A231DocCliCod = P00EN2_A231DocCliCod[0];
            A232DocFec = P00EN2_A232DocFec[0];
            A178TieCod = P00EN2_A178TieCod[0];
            n178TieCod = P00EN2_n178TieCod[0];
            A52LinCod = P00EN2_A52LinCod[0];
            A51SublCod = P00EN2_A51SublCod[0];
            n51SublCod = P00EN2_n51SublCod[0];
            A1153LinDsc = P00EN2_A1153LinDsc[0];
            while ( (pr_default.getStatus(0) != 101) && ( P00EN2_A52LinCod[0] == A52LinCod ) )
            {
               BRKEN2 = false;
               A149TipCod = P00EN2_A149TipCod[0];
               A24DocNum = P00EN2_A24DocNum[0];
               A1153LinDsc = P00EN2_A1153LinDsc[0];
               A28ProdCod = P00EN2_A28ProdCod[0];
               A233DocItem = P00EN2_A233DocItem[0];
               A1153LinDsc = P00EN2_A1153LinDsc[0];
               BRKEN2 = true;
               pr_default.readNext(0);
            }
            AV44LineaCod = A52LinCod;
            AV43Linea = A1153LinDsc;
            /* Execute user subroutine: 'DETALLEPRODUCTO' */
            S131 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( ! BRKEN2 )
            {
               BRKEN2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV25ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV25ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV25ExcelDocument.ErrCode != 0 )
         {
            AV33Filename = "";
            AV23ErrorMessage = AV25ExcelDocument.ErrDescription;
            AV25ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV25ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV38FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV43Linea);
         AV25ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV38FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV63Producto);
         AV25ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV38FirstColumn+2), 1, 1).Text = StringUtil.Trim( AV62ProdDsc);
         AV25ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV38FirstColumn+3), 1, 1).Text = StringUtil.Trim( AV79UniAbr);
         AV25ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV38FirstColumn+4), 1, 1).Number = (double)(AV11Cantidad);
         AV25ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV38FirstColumn+5), 1, 1).Number = (double)(AV73TotalMN);
         AV25ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV38FirstColumn+6), 1, 1).Number = (double)(AV72TotalME);
         AV25ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV38FirstColumn+7), 1, 1).Number = (double)(AV28ExpresadoMN);
         AV25ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV38FirstColumn+8), 1, 1).Number = (double)(AV27ExpresadoME);
         AV12CellRow = (long)(AV12CellRow+1);
      }

      protected void S131( )
      {
         /* 'DETALLEPRODUCTO' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV68TieCod ,
                                              AV13CliCod ,
                                              AV61ProdCod ,
                                              AV64SubLCod ,
                                              AV80VenCod ,
                                              AV70Tipo ,
                                              A178TieCod ,
                                              A231DocCliCod ,
                                              A28ProdCod ,
                                              A51SublCod ,
                                              A227DocVendCod ,
                                              A946DocTipo ,
                                              A232DocFec ,
                                              AV29FDesde ,
                                              AV32FHasta ,
                                              A941DocSts ,
                                              A52LinCod ,
                                              AV44LineaCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00EN3 */
         pr_default.execute(1, new Object[] {AV29FDesde, AV32FHasta, AV44LineaCod, AV68TieCod, AV13CliCod, AV61ProdCod, AV64SubLCod, AV80VenCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKEN4 = false;
            A149TipCod = P00EN3_A149TipCod[0];
            A24DocNum = P00EN3_A24DocNum[0];
            A49UniCod = P00EN3_A49UniCod[0];
            A55ProdDsc = P00EN3_A55ProdDsc[0];
            A28ProdCod = P00EN3_A28ProdCod[0];
            A941DocSts = P00EN3_A941DocSts[0];
            A946DocTipo = P00EN3_A946DocTipo[0];
            A227DocVendCod = P00EN3_A227DocVendCod[0];
            A51SublCod = P00EN3_A51SublCod[0];
            n51SublCod = P00EN3_n51SublCod[0];
            A231DocCliCod = P00EN3_A231DocCliCod[0];
            A52LinCod = P00EN3_A52LinCod[0];
            A232DocFec = P00EN3_A232DocFec[0];
            A178TieCod = P00EN3_A178TieCod[0];
            n178TieCod = P00EN3_n178TieCod[0];
            A894DocDpre = P00EN3_A894DocDpre[0];
            A1997UniAbr = P00EN3_A1997UniAbr[0];
            A233DocItem = P00EN3_A233DocItem[0];
            A941DocSts = P00EN3_A941DocSts[0];
            A946DocTipo = P00EN3_A946DocTipo[0];
            A227DocVendCod = P00EN3_A227DocVendCod[0];
            A231DocCliCod = P00EN3_A231DocCliCod[0];
            A232DocFec = P00EN3_A232DocFec[0];
            A178TieCod = P00EN3_A178TieCod[0];
            n178TieCod = P00EN3_n178TieCod[0];
            A49UniCod = P00EN3_A49UniCod[0];
            A55ProdDsc = P00EN3_A55ProdDsc[0];
            A51SublCod = P00EN3_A51SublCod[0];
            n51SublCod = P00EN3_n51SublCod[0];
            A52LinCod = P00EN3_A52LinCod[0];
            A1997UniAbr = P00EN3_A1997UniAbr[0];
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00EN3_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRKEN4 = false;
               A149TipCod = P00EN3_A149TipCod[0];
               A24DocNum = P00EN3_A24DocNum[0];
               A55ProdDsc = P00EN3_A55ProdDsc[0];
               A233DocItem = P00EN3_A233DocItem[0];
               A55ProdDsc = P00EN3_A55ProdDsc[0];
               BRKEN4 = true;
               pr_default.readNext(1);
            }
            AV63Producto = StringUtil.Trim( A28ProdCod);
            AV62ProdDsc = StringUtil.Trim( A55ProdDsc);
            AV79UniAbr = StringUtil.Trim( A1997UniAbr);
            AV11Cantidad = 0.00m;
            AV73TotalMN = 0.00m;
            AV72TotalME = 0.00m;
            AV28ExpresadoMN = 0.00m;
            AV27ExpresadoME = 0.00m;
            /* Execute user subroutine: 'PRODUCTO' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'DETALLE' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            if ( ! BRKEN4 )
            {
               BRKEN4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S144( )
      {
         /* 'PRODUCTO' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV68TieCod ,
                                              AV13CliCod ,
                                              AV64SubLCod ,
                                              AV80VenCod ,
                                              AV70Tipo ,
                                              A178TieCod ,
                                              A231DocCliCod ,
                                              A51SublCod ,
                                              A227DocVendCod ,
                                              A946DocTipo ,
                                              A232DocFec ,
                                              AV29FDesde ,
                                              AV32FHasta ,
                                              A941DocSts ,
                                              A52LinCod ,
                                              AV44LineaCod ,
                                              AV63Producto ,
                                              A28ProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00EN4 */
         pr_default.execute(2, new Object[] {AV63Producto, AV29FDesde, AV32FHasta, AV44LineaCod, AV68TieCod, AV13CliCod, AV64SubLCod, AV80VenCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A941DocSts = P00EN4_A941DocSts[0];
            A946DocTipo = P00EN4_A946DocTipo[0];
            A227DocVendCod = P00EN4_A227DocVendCod[0];
            A51SublCod = P00EN4_A51SublCod[0];
            n51SublCod = P00EN4_n51SublCod[0];
            A231DocCliCod = P00EN4_A231DocCliCod[0];
            A28ProdCod = P00EN4_A28ProdCod[0];
            A52LinCod = P00EN4_A52LinCod[0];
            A232DocFec = P00EN4_A232DocFec[0];
            A178TieCod = P00EN4_A178TieCod[0];
            n178TieCod = P00EN4_n178TieCod[0];
            A894DocDpre = P00EN4_A894DocDpre[0];
            A149TipCod = P00EN4_A149TipCod[0];
            A24DocNum = P00EN4_A24DocNum[0];
            A230DocMonCod = P00EN4_A230DocMonCod[0];
            A226DocMovCod = P00EN4_A226DocMovCod[0];
            A899DocDcto = P00EN4_A899DocDcto[0];
            A892DocDTot = P00EN4_A892DocDTot[0];
            A511TipSigno = P00EN4_A511TipSigno[0];
            A895DocDCan = P00EN4_A895DocDCan[0];
            A882DocAnticipos = P00EN4_A882DocAnticipos[0];
            A929DocFecRef = P00EN4_A929DocFecRef[0];
            A233DocItem = P00EN4_A233DocItem[0];
            A51SublCod = P00EN4_A51SublCod[0];
            n51SublCod = P00EN4_n51SublCod[0];
            A52LinCod = P00EN4_A52LinCod[0];
            A511TipSigno = P00EN4_A511TipSigno[0];
            A941DocSts = P00EN4_A941DocSts[0];
            A946DocTipo = P00EN4_A946DocTipo[0];
            A227DocVendCod = P00EN4_A227DocVendCod[0];
            A231DocCliCod = P00EN4_A231DocCliCod[0];
            A232DocFec = P00EN4_A232DocFec[0];
            A178TieCod = P00EN4_A178TieCod[0];
            n178TieCod = P00EN4_n178TieCod[0];
            A230DocMonCod = P00EN4_A230DocMonCod[0];
            A226DocMovCod = P00EN4_A226DocMovCod[0];
            A899DocDcto = P00EN4_A899DocDcto[0];
            A882DocAnticipos = P00EN4_A882DocAnticipos[0];
            A929DocFecRef = P00EN4_A929DocFecRef[0];
            AV69TipCod = A149TipCod;
            AV21DocNum = A24DocNum;
            AV30Fecha = A232DocFec;
            AV45MonCod = A230DocMonCod;
            AV20DocMovCod = A226DocMovCod;
            AV58PorDscto = A899DocDcto;
            AV17Descuento = NumberUtil.Round( (NumberUtil.Round( A892DocDTot, 2)*AV58PorDscto)/ (decimal)(100), 2);
            AV71Total = NumberUtil.Round( (NumberUtil.Round( A892DocDTot, 2)-AV17Descuento)*A511TipSigno, 2);
            AV19DocDCan = NumberUtil.Round( A895DocDCan*A511TipSigno, 4);
            AV18DocAnticipos = (decimal)(NumberUtil.Round( A882DocAnticipos, 2)*A511TipSigno);
            if ( ( StringUtil.StrCmp(AV69TipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV69TipCod, "ND") == 0 ) )
            {
               /* Execute user subroutine: 'VALIDATIPOMOVIMIENTO' */
               S156 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
               AV30Fecha = A929DocFecRef;
            }
            if ( ! (Convert.ToDecimal(0)==AV18DocAnticipos) )
            {
               /* Execute user subroutine: 'SUBTOTAL' */
               S166 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
               AV57Porcentaje = NumberUtil.Round( AV71Total/ (decimal)(((Convert.ToDecimal(0)==AV65SubTotal) ? (decimal)(1) : AV65SubTotal)), 10);
               AV8Anticipo = NumberUtil.Round( AV57Porcentaje*AV18DocAnticipos, 2);
            }
            else
            {
               AV57Porcentaje = 0.00m;
               AV8Anticipo = 0.00m;
               AV65SubTotal = 0.00m;
            }
            AV71Total = (decimal)(AV71Total-(AV8Anticipo+AV17Descuento));
            AV11Cantidad = (decimal)(AV11Cantidad+AV19DocDCan);
            GXt_decimal1 = AV10Cambio;
            GXt_int2 = 2;
            GXt_char3 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV30Fecha, ref  GXt_char3, out  GXt_decimal1) ;
            AV10Cambio = GXt_decimal1;
            AV73TotalMN = (decimal)(AV73TotalMN+(((AV45MonCod==1) ? AV71Total : (decimal)(0))));
            AV72TotalME = (decimal)(AV72TotalME+(((AV45MonCod==1) ? (decimal)(0) : AV71Total)));
            AV28ExpresadoMN = (decimal)(AV28ExpresadoMN+(((AV45MonCod==1) ? AV71Total : NumberUtil.Round( AV71Total*AV10Cambio, 2))));
            AV27ExpresadoME = (decimal)(AV27ExpresadoME+(((AV45MonCod==1) ? NumberUtil.Round( AV71Total/ (decimal)(AV10Cambio), 2) : AV71Total)));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S156( )
      {
         /* 'VALIDATIPOMOVIMIENTO' Routine */
         returnInSub = false;
         /* Using cursor P00EN5 */
         pr_default.execute(3, new Object[] {AV20DocMovCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A235MovVCod = P00EN5_A235MovVCod[0];
            A1242MovVAbr = P00EN5_A1242MovVAbr[0];
            if ( ! ( StringUtil.StrCmp(A1242MovVAbr, "SI") == 0 ) )
            {
               AV19DocDCan = 0.00m;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void S166( )
      {
         /* 'SUBTOTAL' Routine */
         returnInSub = false;
         /* Using cursor P00EN7 */
         pr_default.execute(4, new Object[] {AV69TipCod, AV21DocNum});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A24DocNum = P00EN7_A24DocNum[0];
            A149TipCod = P00EN7_A149TipCod[0];
            A927DocSubExonerado = P00EN7_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EN7_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EN7_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EN7_A920DocSubAfecto[0];
            A927DocSubExonerado = P00EN7_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EN7_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EN7_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EN7_A920DocSubAfecto[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            AV65SubTotal = NumberUtil.Round( A919DocSub, 2);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
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
         AV33Filename = "";
         AV23ErrorMessage = "";
         AV9Archivo = new GxFile(context.GetPhysicalPath());
         AV46Path = "";
         AV34FilenameOrigen = "";
         AV25ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         A231DocCliCod = "";
         A28ProdCod = "";
         A946DocTipo = "";
         A232DocFec = DateTime.MinValue;
         A941DocSts = "";
         P00EN2_A149TipCod = new string[] {""} ;
         P00EN2_A24DocNum = new string[] {""} ;
         P00EN2_A1153LinDsc = new string[] {""} ;
         P00EN2_A52LinCod = new int[1] ;
         P00EN2_A941DocSts = new string[] {""} ;
         P00EN2_A946DocTipo = new string[] {""} ;
         P00EN2_A227DocVendCod = new int[1] ;
         P00EN2_A51SublCod = new int[1] ;
         P00EN2_n51SublCod = new bool[] {false} ;
         P00EN2_A28ProdCod = new string[] {""} ;
         P00EN2_A231DocCliCod = new string[] {""} ;
         P00EN2_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EN2_A178TieCod = new int[1] ;
         P00EN2_n178TieCod = new bool[] {false} ;
         P00EN2_A894DocDpre = new decimal[1] ;
         P00EN2_A233DocItem = new long[1] ;
         A149TipCod = "";
         A24DocNum = "";
         A1153LinDsc = "";
         AV43Linea = "";
         AV63Producto = "";
         AV62ProdDsc = "";
         AV79UniAbr = "";
         P00EN3_A149TipCod = new string[] {""} ;
         P00EN3_A24DocNum = new string[] {""} ;
         P00EN3_A49UniCod = new int[1] ;
         P00EN3_A55ProdDsc = new string[] {""} ;
         P00EN3_A28ProdCod = new string[] {""} ;
         P00EN3_A941DocSts = new string[] {""} ;
         P00EN3_A946DocTipo = new string[] {""} ;
         P00EN3_A227DocVendCod = new int[1] ;
         P00EN3_A51SublCod = new int[1] ;
         P00EN3_n51SublCod = new bool[] {false} ;
         P00EN3_A231DocCliCod = new string[] {""} ;
         P00EN3_A52LinCod = new int[1] ;
         P00EN3_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EN3_A178TieCod = new int[1] ;
         P00EN3_n178TieCod = new bool[] {false} ;
         P00EN3_A894DocDpre = new decimal[1] ;
         P00EN3_A1997UniAbr = new string[] {""} ;
         P00EN3_A233DocItem = new long[1] ;
         A55ProdDsc = "";
         A1997UniAbr = "";
         P00EN4_A941DocSts = new string[] {""} ;
         P00EN4_A946DocTipo = new string[] {""} ;
         P00EN4_A227DocVendCod = new int[1] ;
         P00EN4_A51SublCod = new int[1] ;
         P00EN4_n51SublCod = new bool[] {false} ;
         P00EN4_A231DocCliCod = new string[] {""} ;
         P00EN4_A28ProdCod = new string[] {""} ;
         P00EN4_A52LinCod = new int[1] ;
         P00EN4_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EN4_A178TieCod = new int[1] ;
         P00EN4_n178TieCod = new bool[] {false} ;
         P00EN4_A894DocDpre = new decimal[1] ;
         P00EN4_A149TipCod = new string[] {""} ;
         P00EN4_A24DocNum = new string[] {""} ;
         P00EN4_A230DocMonCod = new int[1] ;
         P00EN4_A226DocMovCod = new int[1] ;
         P00EN4_A899DocDcto = new decimal[1] ;
         P00EN4_A892DocDTot = new decimal[1] ;
         P00EN4_A511TipSigno = new short[1] ;
         P00EN4_A895DocDCan = new decimal[1] ;
         P00EN4_A882DocAnticipos = new decimal[1] ;
         P00EN4_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P00EN4_A233DocItem = new long[1] ;
         A929DocFecRef = DateTime.MinValue;
         AV69TipCod = "";
         AV21DocNum = "";
         AV30Fecha = DateTime.MinValue;
         GXt_char3 = "";
         P00EN5_A235MovVCod = new int[1] ;
         P00EN5_A1242MovVAbr = new string[] {""} ;
         A1242MovVAbr = "";
         P00EN7_A24DocNum = new string[] {""} ;
         P00EN7_A149TipCod = new string[] {""} ;
         P00EN7_A927DocSubExonerado = new decimal[1] ;
         P00EN7_A922DocSubSelectivo = new decimal[1] ;
         P00EN7_A921DocSubInafecto = new decimal[1] ;
         P00EN7_A920DocSubAfecto = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prresumenventasxproductoexcel__default(),
            new Object[][] {
                new Object[] {
               P00EN2_A149TipCod, P00EN2_A24DocNum, P00EN2_A1153LinDsc, P00EN2_A52LinCod, P00EN2_A941DocSts, P00EN2_A946DocTipo, P00EN2_A227DocVendCod, P00EN2_A51SublCod, P00EN2_n51SublCod, P00EN2_A28ProdCod,
               P00EN2_A231DocCliCod, P00EN2_A232DocFec, P00EN2_A178TieCod, P00EN2_n178TieCod, P00EN2_A894DocDpre, P00EN2_A233DocItem
               }
               , new Object[] {
               P00EN3_A149TipCod, P00EN3_A24DocNum, P00EN3_A49UniCod, P00EN3_A55ProdDsc, P00EN3_A28ProdCod, P00EN3_A941DocSts, P00EN3_A946DocTipo, P00EN3_A227DocVendCod, P00EN3_A51SublCod, P00EN3_n51SublCod,
               P00EN3_A231DocCliCod, P00EN3_A52LinCod, P00EN3_A232DocFec, P00EN3_A178TieCod, P00EN3_n178TieCod, P00EN3_A894DocDpre, P00EN3_A1997UniAbr, P00EN3_A233DocItem
               }
               , new Object[] {
               P00EN4_A941DocSts, P00EN4_A946DocTipo, P00EN4_A227DocVendCod, P00EN4_A51SublCod, P00EN4_n51SublCod, P00EN4_A231DocCliCod, P00EN4_A28ProdCod, P00EN4_A52LinCod, P00EN4_A232DocFec, P00EN4_A178TieCod,
               P00EN4_n178TieCod, P00EN4_A894DocDpre, P00EN4_A149TipCod, P00EN4_A24DocNum, P00EN4_A230DocMonCod, P00EN4_A226DocMovCod, P00EN4_A899DocDcto, P00EN4_A892DocDTot, P00EN4_A511TipSigno, P00EN4_A895DocDCan,
               P00EN4_A882DocAnticipos, P00EN4_A929DocFecRef, P00EN4_A233DocItem
               }
               , new Object[] {
               P00EN5_A235MovVCod, P00EN5_A1242MovVAbr
               }
               , new Object[] {
               P00EN7_A24DocNum, P00EN7_A149TipCod, P00EN7_A927DocSubExonerado, P00EN7_A922DocSubSelectivo, P00EN7_A921DocSubInafecto, P00EN7_A920DocSubAfecto
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A511TipSigno ;
      private int AV80VenCod ;
      private int AV41LinCod ;
      private int AV64SubLCod ;
      private int AV68TieCod ;
      private int AV40Item ;
      private int A178TieCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A227DocVendCod ;
      private int AV44LineaCod ;
      private int A49UniCod ;
      private int A230DocMonCod ;
      private int A226DocMovCod ;
      private int AV45MonCod ;
      private int AV20DocMovCod ;
      private int GXt_int2 ;
      private int A235MovVCod ;
      private long AV12CellRow ;
      private long AV38FirstColumn ;
      private long A233DocItem ;
      private decimal A894DocDpre ;
      private decimal AV11Cantidad ;
      private decimal AV73TotalMN ;
      private decimal AV72TotalME ;
      private decimal AV28ExpresadoMN ;
      private decimal AV27ExpresadoME ;
      private decimal A899DocDcto ;
      private decimal A892DocDTot ;
      private decimal A895DocDCan ;
      private decimal A882DocAnticipos ;
      private decimal AV58PorDscto ;
      private decimal AV17Descuento ;
      private decimal AV71Total ;
      private decimal AV19DocDCan ;
      private decimal AV18DocAnticipos ;
      private decimal AV57Porcentaje ;
      private decimal AV65SubTotal ;
      private decimal AV8Anticipo ;
      private decimal AV10Cambio ;
      private decimal GXt_decimal1 ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A919DocSub ;
      private string AV61ProdCod ;
      private string AV13CliCod ;
      private string AV46Path ;
      private string scmdbuf ;
      private string A231DocCliCod ;
      private string A28ProdCod ;
      private string A946DocTipo ;
      private string A941DocSts ;
      private string A149TipCod ;
      private string A24DocNum ;
      private string A1153LinDsc ;
      private string AV43Linea ;
      private string AV63Producto ;
      private string AV62ProdDsc ;
      private string AV79UniAbr ;
      private string A55ProdDsc ;
      private string A1997UniAbr ;
      private string AV69TipCod ;
      private string AV21DocNum ;
      private string GXt_char3 ;
      private string A1242MovVAbr ;
      private DateTime AV29FDesde ;
      private DateTime AV32FHasta ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV30Fecha ;
      private bool returnInSub ;
      private bool BRKEN2 ;
      private bool n51SublCod ;
      private bool n178TieCod ;
      private bool BRKEN4 ;
      private string AV70Tipo ;
      private string AV33Filename ;
      private string AV23ErrorMessage ;
      private string AV34FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_VenCod ;
      private string aP1_ProdCod ;
      private string aP2_CliCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private int aP5_LinCod ;
      private int aP6_SubLCod ;
      private string aP7_Tipo ;
      private int aP8_TieCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00EN2_A149TipCod ;
      private string[] P00EN2_A24DocNum ;
      private string[] P00EN2_A1153LinDsc ;
      private int[] P00EN2_A52LinCod ;
      private string[] P00EN2_A941DocSts ;
      private string[] P00EN2_A946DocTipo ;
      private int[] P00EN2_A227DocVendCod ;
      private int[] P00EN2_A51SublCod ;
      private bool[] P00EN2_n51SublCod ;
      private string[] P00EN2_A28ProdCod ;
      private string[] P00EN2_A231DocCliCod ;
      private DateTime[] P00EN2_A232DocFec ;
      private int[] P00EN2_A178TieCod ;
      private bool[] P00EN2_n178TieCod ;
      private decimal[] P00EN2_A894DocDpre ;
      private long[] P00EN2_A233DocItem ;
      private string[] P00EN3_A149TipCod ;
      private string[] P00EN3_A24DocNum ;
      private int[] P00EN3_A49UniCod ;
      private string[] P00EN3_A55ProdDsc ;
      private string[] P00EN3_A28ProdCod ;
      private string[] P00EN3_A941DocSts ;
      private string[] P00EN3_A946DocTipo ;
      private int[] P00EN3_A227DocVendCod ;
      private int[] P00EN3_A51SublCod ;
      private bool[] P00EN3_n51SublCod ;
      private string[] P00EN3_A231DocCliCod ;
      private int[] P00EN3_A52LinCod ;
      private DateTime[] P00EN3_A232DocFec ;
      private int[] P00EN3_A178TieCod ;
      private bool[] P00EN3_n178TieCod ;
      private decimal[] P00EN3_A894DocDpre ;
      private string[] P00EN3_A1997UniAbr ;
      private long[] P00EN3_A233DocItem ;
      private string[] P00EN4_A941DocSts ;
      private string[] P00EN4_A946DocTipo ;
      private int[] P00EN4_A227DocVendCod ;
      private int[] P00EN4_A51SublCod ;
      private bool[] P00EN4_n51SublCod ;
      private string[] P00EN4_A231DocCliCod ;
      private string[] P00EN4_A28ProdCod ;
      private int[] P00EN4_A52LinCod ;
      private DateTime[] P00EN4_A232DocFec ;
      private int[] P00EN4_A178TieCod ;
      private bool[] P00EN4_n178TieCod ;
      private decimal[] P00EN4_A894DocDpre ;
      private string[] P00EN4_A149TipCod ;
      private string[] P00EN4_A24DocNum ;
      private int[] P00EN4_A230DocMonCod ;
      private int[] P00EN4_A226DocMovCod ;
      private decimal[] P00EN4_A899DocDcto ;
      private decimal[] P00EN4_A892DocDTot ;
      private short[] P00EN4_A511TipSigno ;
      private decimal[] P00EN4_A895DocDCan ;
      private decimal[] P00EN4_A882DocAnticipos ;
      private DateTime[] P00EN4_A929DocFecRef ;
      private long[] P00EN4_A233DocItem ;
      private int[] P00EN5_A235MovVCod ;
      private string[] P00EN5_A1242MovVAbr ;
      private string[] P00EN7_A24DocNum ;
      private string[] P00EN7_A149TipCod ;
      private decimal[] P00EN7_A927DocSubExonerado ;
      private decimal[] P00EN7_A922DocSubSelectivo ;
      private decimal[] P00EN7_A921DocSubInafecto ;
      private decimal[] P00EN7_A920DocSubAfecto ;
      private string aP9_Filename ;
      private string aP10_ErrorMessage ;
      private ExcelDocumentI AV25ExcelDocument ;
      private GxFile AV9Archivo ;
   }

   public class prresumenventasxproductoexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EN2( IGxContext context ,
                                             int AV68TieCod ,
                                             string AV13CliCod ,
                                             string AV61ProdCod ,
                                             int AV41LinCod ,
                                             int AV64SubLCod ,
                                             int AV80VenCod ,
                                             string AV70Tipo ,
                                             int A178TieCod ,
                                             string A231DocCliCod ,
                                             string A28ProdCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV29FDesde ,
                                             DateTime AV32FHasta ,
                                             string A941DocSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[8];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T1.[DocNum], T4.[LinDsc], T3.[LinCod], T2.[DocSts], T2.[DocTipo], T2.[DocVendCod], T3.[SublCod], T1.[ProdCod], T2.[DocCliCod], T2.[DocFec], T2.[TieCod], T1.[DocDpre], T1.[DocItem] FROM ((([CLVENTASDET] T1 INNER JOIN [CLVENTAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T3.[LinCod])";
         AddWhere(sWhereString, "(T2.[DocFec] >= @AV29FDesde)");
         AddWhere(sWhereString, "(T2.[DocFec] <= @AV32FHasta)");
         AddWhere(sWhereString, "(T2.[DocSts] <> 'A')");
         if ( ! (0==AV68TieCod) )
         {
            AddWhere(sWhereString, "(T2.[TieCod] = @AV68TieCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[DocCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV61ProdCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV41LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV41LinCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV64SubLCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV64SubLCod)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV80VenCod) )
         {
            AddWhere(sWhereString, "(T2.[DocVendCod] = @AV80VenCod)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV70Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV70Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'X')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[LinCod], T4.[LinDsc]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00EN3( IGxContext context ,
                                             int AV68TieCod ,
                                             string AV13CliCod ,
                                             string AV61ProdCod ,
                                             int AV64SubLCod ,
                                             int AV80VenCod ,
                                             string AV70Tipo ,
                                             int A178TieCod ,
                                             string A231DocCliCod ,
                                             string A28ProdCod ,
                                             int A51SublCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV29FDesde ,
                                             DateTime AV32FHasta ,
                                             string A941DocSts ,
                                             int A52LinCod ,
                                             int AV44LineaCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[8];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T1.[DocNum], T3.[UniCod], T3.[ProdDsc], T1.[ProdCod], T2.[DocSts], T2.[DocTipo], T2.[DocVendCod], T3.[SublCod], T2.[DocCliCod], T3.[LinCod], T2.[DocFec], T2.[TieCod], T1.[DocDpre], T4.[UniAbr], T1.[DocItem] FROM ((([CLVENTASDET] T1 INNER JOIN [CLVENTAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T4 ON T4.[UniCod] = T3.[UniCod])";
         AddWhere(sWhereString, "(T2.[DocFec] >= @AV29FDesde)");
         AddWhere(sWhereString, "(T2.[DocFec] <= @AV32FHasta)");
         AddWhere(sWhereString, "(T2.[DocSts] <> 'A')");
         AddWhere(sWhereString, "(T3.[LinCod] = @AV44LineaCod)");
         if ( ! (0==AV68TieCod) )
         {
            AddWhere(sWhereString, "(T2.[TieCod] = @AV68TieCod)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[DocCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV61ProdCod)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV64SubLCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV64SubLCod)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! (0==AV80VenCod) )
         {
            AddWhere(sWhereString, "(T2.[DocVendCod] = @AV80VenCod)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV70Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV70Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'X')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T3.[ProdDsc]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00EN4( IGxContext context ,
                                             int AV68TieCod ,
                                             string AV13CliCod ,
                                             int AV64SubLCod ,
                                             int AV80VenCod ,
                                             string AV70Tipo ,
                                             int A178TieCod ,
                                             string A231DocCliCod ,
                                             int A51SublCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV29FDesde ,
                                             DateTime AV32FHasta ,
                                             string A941DocSts ,
                                             int A52LinCod ,
                                             int AV44LineaCod ,
                                             string AV63Producto ,
                                             string A28ProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[8];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T4.[DocSts], T4.[DocTipo], T4.[DocVendCod], T2.[SublCod], T4.[DocCliCod], T1.[ProdCod], T2.[LinCod], T4.[DocFec], T4.[TieCod], T1.[DocDpre], T1.[TipCod], T1.[DocNum], T4.[DocMonCod], T4.[DocMovCod], T4.[DocDcto], T1.[DocDTot], T3.[TipSigno], T1.[DocDCan], T4.[DocAnticipos], T4.[DocFecRef], T1.[DocItem] FROM ((([CLVENTASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CLVENTAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum])";
         AddWhere(sWhereString, "(T1.[ProdCod] = @AV63Producto)");
         AddWhere(sWhereString, "(T4.[DocFec] >= @AV29FDesde)");
         AddWhere(sWhereString, "(T4.[DocFec] <= @AV32FHasta)");
         AddWhere(sWhereString, "(T4.[DocSts] <> 'A')");
         AddWhere(sWhereString, "(T2.[LinCod] = @AV44LineaCod)");
         if ( ! (0==AV68TieCod) )
         {
            AddWhere(sWhereString, "(T4.[TieCod] = @AV68TieCod)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T4.[DocCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (0==AV64SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV64SubLCod)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! (0==AV80VenCod) )
         {
            AddWhere(sWhereString, "(T4.[DocVendCod] = @AV80VenCod)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV70Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV70Tipo, "V") == 0 )
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
                     return conditional_P00EN2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] );
               case 1 :
                     return conditional_P00EN3(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] );
               case 2 :
                     return conditional_P00EN4(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
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
          Object[] prmP00EN5;
          prmP00EN5 = new Object[] {
          new ParDef("@AV20DocMovCod",GXType.Int32,6,0)
          };
          Object[] prmP00EN7;
          prmP00EN7 = new Object[] {
          new ParDef("@AV69TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV21DocNum",GXType.NChar,12,0)
          };
          Object[] prmP00EN2;
          prmP00EN2 = new Object[] {
          new ParDef("@AV29FDesde",GXType.Date,8,0) ,
          new ParDef("@AV32FHasta",GXType.Date,8,0) ,
          new ParDef("@AV68TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV61ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV41LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV64SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV80VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00EN3;
          prmP00EN3 = new Object[] {
          new ParDef("@AV29FDesde",GXType.Date,8,0) ,
          new ParDef("@AV32FHasta",GXType.Date,8,0) ,
          new ParDef("@AV44LineaCod",GXType.Int32,6,0) ,
          new ParDef("@AV68TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV61ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV64SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV80VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00EN4;
          prmP00EN4 = new Object[] {
          new ParDef("@AV63Producto",GXType.NChar,15,0) ,
          new ParDef("@AV29FDesde",GXType.Date,8,0) ,
          new ParDef("@AV32FHasta",GXType.Date,8,0) ,
          new ParDef("@AV44LineaCod",GXType.Int32,6,0) ,
          new ParDef("@AV68TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV64SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV80VenCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EN2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EN2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EN3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EN3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EN4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EN4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EN5", "SELECT [MovVCod], [MovVAbr] FROM [CMOVVENTAS] WHERE [MovVCod] = @AV20DocMovCod ORDER BY [MovVCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EN5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EN7", "SELECT T1.[DocNum], T1.[TipCod], COALESCE( T2.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T2.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T2.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T2.[DocSubAfecto], 0) AS DocSubAfecto FROM ([CLVENTAS] T1 LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) WHERE T1.[TipCod] = @AV69TipCod and T1.[DocNum] = @AV21DocNum ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EN7,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((string[]) buf[5])[0] = rslt.getString(6, 1);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 15);
                ((string[]) buf[10])[0] = rslt.getString(10, 20);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
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
                ((string[]) buf[10])[0] = rslt.getString(10, 20);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(12);
                ((int[]) buf[13])[0] = rslt.getInt(13);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
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
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 15);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
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
