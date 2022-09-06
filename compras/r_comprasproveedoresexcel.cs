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
namespace GeneXus.Programs.compras {
   public class r_comprasproveedoresexcel : GXProcedure
   {
      public r_comprasproveedoresexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_comprasproveedoresexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TPrvCod ,
                           ref string aP1_PrvCod ,
                           ref string aP2_TipCod ,
                           ref string aP3_PaiCod ,
                           ref DateTime aP4_FDesde ,
                           ref DateTime aP5_FHasta ,
                           ref int aP6_DocMonCod ,
                           ref string aP7_Tipo ,
                           out string aP8_Filename ,
                           out string aP9_ErrorMessage )
      {
         this.AV47TPrvCod = aP0_TPrvCod;
         this.AV32PrvCod = aP1_PrvCod;
         this.AV37TipCod = aP2_TipCod;
         this.AV28PaiCod = aP3_PaiCod;
         this.AV19FDesde = aP4_FDesde;
         this.AV21FHasta = aP5_FHasta;
         this.AV16DocMonCod = aP6_DocMonCod;
         this.AV39Tipo = aP7_Tipo;
         this.AV22Filename = "" ;
         this.AV17ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_TPrvCod=this.AV47TPrvCod;
         aP1_PrvCod=this.AV32PrvCod;
         aP2_TipCod=this.AV37TipCod;
         aP3_PaiCod=this.AV28PaiCod;
         aP4_FDesde=this.AV19FDesde;
         aP5_FHasta=this.AV21FHasta;
         aP6_DocMonCod=this.AV16DocMonCod;
         aP7_Tipo=this.AV39Tipo;
         aP8_Filename=this.AV22Filename;
         aP9_ErrorMessage=this.AV17ErrorMessage;
      }

      public string executeUdp( ref int aP0_TPrvCod ,
                                ref string aP1_PrvCod ,
                                ref string aP2_TipCod ,
                                ref string aP3_PaiCod ,
                                ref DateTime aP4_FDesde ,
                                ref DateTime aP5_FHasta ,
                                ref int aP6_DocMonCod ,
                                ref string aP7_Tipo ,
                                out string aP8_Filename )
      {
         execute(ref aP0_TPrvCod, ref aP1_PrvCod, ref aP2_TipCod, ref aP3_PaiCod, ref aP4_FDesde, ref aP5_FHasta, ref aP6_DocMonCod, ref aP7_Tipo, out aP8_Filename, out aP9_ErrorMessage);
         return AV17ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_TPrvCod ,
                                 ref string aP1_PrvCod ,
                                 ref string aP2_TipCod ,
                                 ref string aP3_PaiCod ,
                                 ref DateTime aP4_FDesde ,
                                 ref DateTime aP5_FHasta ,
                                 ref int aP6_DocMonCod ,
                                 ref string aP7_Tipo ,
                                 out string aP8_Filename ,
                                 out string aP9_ErrorMessage )
      {
         r_comprasproveedoresexcel objr_comprasproveedoresexcel;
         objr_comprasproveedoresexcel = new r_comprasproveedoresexcel();
         objr_comprasproveedoresexcel.AV47TPrvCod = aP0_TPrvCod;
         objr_comprasproveedoresexcel.AV32PrvCod = aP1_PrvCod;
         objr_comprasproveedoresexcel.AV37TipCod = aP2_TipCod;
         objr_comprasproveedoresexcel.AV28PaiCod = aP3_PaiCod;
         objr_comprasproveedoresexcel.AV19FDesde = aP4_FDesde;
         objr_comprasproveedoresexcel.AV21FHasta = aP5_FHasta;
         objr_comprasproveedoresexcel.AV16DocMonCod = aP6_DocMonCod;
         objr_comprasproveedoresexcel.AV39Tipo = aP7_Tipo;
         objr_comprasproveedoresexcel.AV22Filename = "" ;
         objr_comprasproveedoresexcel.AV17ErrorMessage = "" ;
         objr_comprasproveedoresexcel.context.SetSubmitInitialConfig(context);
         objr_comprasproveedoresexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_comprasproveedoresexcel);
         aP0_TPrvCod=this.AV47TPrvCod;
         aP1_PrvCod=this.AV32PrvCod;
         aP2_TipCod=this.AV37TipCod;
         aP3_PaiCod=this.AV28PaiCod;
         aP4_FDesde=this.AV19FDesde;
         aP5_FHasta=this.AV21FHasta;
         aP6_DocMonCod=this.AV16DocMonCod;
         aP7_Tipo=this.AV39Tipo;
         aP8_Filename=this.AV22Filename;
         aP9_ErrorMessage=this.AV17ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_comprasproveedoresexcel)stateInfo).executePrivate();
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
         AV8Archivo.Source = "Excel/PlantillasAnalisisComprasProveedor.xlsx";
         AV29Path = AV8Archivo.GetPath();
         AV23FilenameOrigen = StringUtil.Trim( AV29Path) + "\\PlantillasAnalisisComprasProveedor.xlsx";
         AV22Filename = "Excel/AnalisisComprasProveedor" + ".xlsx";
         AV18ExcelDocument.Clear();
         AV18ExcelDocument.Template = AV23FilenameOrigen;
         AV18ExcelDocument.Open(AV22Filename);
         /* Using cursor P00AS2 */
         pr_default.execute(0, new Object[] {AV16DocMonCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A180MonCod = P00AS2_A180MonCod[0];
            A1234MonDsc = P00AS2_A1234MonDsc[0];
            AV24Filtro1 = StringUtil.Trim( A1234MonDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV10CellRow = 3;
         AV25FirstColumn = 1;
         AV18ExcelDocument.get_Cells(AV10CellRow, AV25FirstColumn+1, 1, 1).Text = "Del : "+context.localUtil.DToC( AV19FDesde, 2, "/")+" Al : "+context.localUtil.DToC( AV21FHasta, 2, "/");
         AV10CellRow = 4;
         AV25FirstColumn = 1;
         AV18ExcelDocument.get_Cells(AV10CellRow, AV25FirstColumn+1, 1, 1).Text = "Expresado en : "+StringUtil.Trim( AV24Filtro1);
         AV42TotalGeneral = 0.00m;
         AV43TotalGeneralME = 0.00m;
         AV10CellRow = 6;
         AV25FirstColumn = 1;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV47TPrvCod ,
                                              AV32PrvCod ,
                                              AV37TipCod ,
                                              AV28PaiCod ,
                                              AV39Tipo ,
                                              A298TprvCod ,
                                              A244PrvCod ,
                                              A149TipCod ,
                                              A139PaiCod ,
                                              A1158LinStk ,
                                              A254ComDProCod ,
                                              A253ComDCueCod ,
                                              A697ComDOrdTip ,
                                              A707ComFReg ,
                                              AV19FDesde ,
                                              AV21FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AS3 */
         pr_default.execute(1, new Object[] {AV19FDesde, AV21FHasta, AV47TPrvCod, AV32PrvCod, AV37TipCod, AV28PaiCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAS3 = false;
            A243ComCod = P00AS3_A243ComCod[0];
            A52LinCod = P00AS3_A52LinCod[0];
            n52LinCod = P00AS3_n52LinCod[0];
            A247PrvDsc = P00AS3_A247PrvDsc[0];
            A244PrvCod = P00AS3_A244PrvCod[0];
            A707ComFReg = P00AS3_A707ComFReg[0];
            A697ComDOrdTip = P00AS3_A697ComDOrdTip[0];
            A253ComDCueCod = P00AS3_A253ComDCueCod[0];
            n253ComDCueCod = P00AS3_n253ComDCueCod[0];
            A254ComDProCod = P00AS3_A254ComDProCod[0];
            n254ComDProCod = P00AS3_n254ComDProCod[0];
            A1158LinStk = P00AS3_A1158LinStk[0];
            A139PaiCod = P00AS3_A139PaiCod[0];
            A149TipCod = P00AS3_A149TipCod[0];
            A298TprvCod = P00AS3_A298TprvCod[0];
            A300PrvConpCod = P00AS3_A300PrvConpCod[0];
            A250ComDItem = P00AS3_A250ComDItem[0];
            A251ComDOrdCod = P00AS3_A251ComDOrdCod[0];
            A139PaiCod = P00AS3_A139PaiCod[0];
            A298TprvCod = P00AS3_A298TprvCod[0];
            A300PrvConpCod = P00AS3_A300PrvConpCod[0];
            A52LinCod = P00AS3_A52LinCod[0];
            n52LinCod = P00AS3_n52LinCod[0];
            A1158LinStk = P00AS3_A1158LinStk[0];
            A247PrvDsc = P00AS3_A247PrvDsc[0];
            A707ComFReg = P00AS3_A707ComFReg[0];
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00AS3_A244PrvCod[0], A244PrvCod) == 0 ) )
            {
               BRKAS3 = false;
               A243ComCod = P00AS3_A243ComCod[0];
               A247PrvDsc = P00AS3_A247PrvDsc[0];
               A149TipCod = P00AS3_A149TipCod[0];
               A250ComDItem = P00AS3_A250ComDItem[0];
               A251ComDOrdCod = P00AS3_A251ComDOrdCod[0];
               A247PrvDsc = P00AS3_A247PrvDsc[0];
               BRKAS3 = true;
               pr_default.readNext(1);
            }
            AV14DocCliCod = A244PrvCod;
            AV15DocCliDsc = A247PrvDsc;
            AV33PrvConpCod = A300PrvConpCod;
            AV45TotalVenta = 0.00m;
            AV46TotalVentaME = 0.00m;
            AV41Total = 0.00m;
            AV44TotalME = 0.00m;
            /* Execute user subroutine: 'PROVEEDORES' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               this.cleanup();
               if (true) return;
            }
            AV35SDTComprasProveedorITem.gxTpr_Clicod = AV14DocCliCod;
            AV35SDTComprasProveedorITem.gxTpr_Clidsc = AV15DocCliDsc;
            AV35SDTComprasProveedorITem.gxTpr_Importe = AV45TotalVenta;
            AV35SDTComprasProveedorITem.gxTpr_Importe1 = AV46TotalVentaME;
            AV35SDTComprasProveedorITem.gxTpr_Cantidad = (decimal)(AV33PrvConpCod);
            AV34SDTComprasProveedor.Add(AV35SDTComprasProveedorITem, 0);
            AV35SDTComprasProveedorITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
            AV42TotalGeneral = (decimal)(AV42TotalGeneral+AV45TotalVenta);
            AV43TotalGeneralME = (decimal)(AV43TotalGeneralME+AV46TotalVentaME);
            if ( ! BRKAS3 )
            {
               BRKAS3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         AV34SDTComprasProveedor.Sort("[Importe]");
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV34SDTComprasProveedor.Count )
         {
            AV35SDTComprasProveedorITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV34SDTComprasProveedor.Item(AV53GXV1));
            AV14DocCliCod = AV35SDTComprasProveedorITem.gxTpr_Clicod;
            AV15DocCliDsc = AV35SDTComprasProveedorITem.gxTpr_Clidsc;
            AV45TotalVenta = AV35SDTComprasProveedorITem.gxTpr_Importe;
            AV46TotalVentaME = AV35SDTComprasProveedorITem.gxTpr_Importe1;
            AV33PrvConpCod = (int)(AV35SDTComprasProveedorITem.gxTpr_Cantidad);
            AV30Porcentaje = NumberUtil.Round( (AV45TotalVenta/ (decimal)(AV42TotalGeneral))*100, 2);
            AV31Porcentaje2 = NumberUtil.Round( (AV46TotalVentaME/ (decimal)(AV43TotalGeneralME))*100, 2);
            AV36SumPorcent = (decimal)(AV36SumPorcent+AV30Porcentaje);
            /* Execute user subroutine: 'DETALLE' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
         AV18ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV18ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'PROVEEDORES' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV47TPrvCod ,
                                              AV32PrvCod ,
                                              AV37TipCod ,
                                              AV28PaiCod ,
                                              AV39Tipo ,
                                              A298TprvCod ,
                                              A244PrvCod ,
                                              A149TipCod ,
                                              A139PaiCod ,
                                              A1158LinStk ,
                                              A254ComDProCod ,
                                              A253ComDCueCod ,
                                              A697ComDOrdTip ,
                                              A707ComFReg ,
                                              AV19FDesde ,
                                              AV21FHasta ,
                                              AV14DocCliCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AS4 */
         pr_default.execute(2, new Object[] {AV19FDesde, AV21FHasta, AV14DocCliCod, AV47TPrvCod, AV32PrvCod, AV37TipCod, AV28PaiCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A243ComCod = P00AS4_A243ComCod[0];
            A52LinCod = P00AS4_A52LinCod[0];
            n52LinCod = P00AS4_n52LinCod[0];
            A244PrvCod = P00AS4_A244PrvCod[0];
            A707ComFReg = P00AS4_A707ComFReg[0];
            A697ComDOrdTip = P00AS4_A697ComDOrdTip[0];
            A253ComDCueCod = P00AS4_A253ComDCueCod[0];
            n253ComDCueCod = P00AS4_n253ComDCueCod[0];
            A254ComDProCod = P00AS4_A254ComDProCod[0];
            n254ComDProCod = P00AS4_n254ComDProCod[0];
            A1158LinStk = P00AS4_A1158LinStk[0];
            A139PaiCod = P00AS4_A139PaiCod[0];
            A149TipCod = P00AS4_A149TipCod[0];
            A298TprvCod = P00AS4_A298TprvCod[0];
            A704ComFecPago = P00AS4_A704ComFecPago[0];
            A724ComRefFec = P00AS4_A724ComRefFec[0];
            A246ComMon = P00AS4_A246ComMon[0];
            A511TipSigno = P00AS4_A511TipSigno[0];
            A248ComFec = P00AS4_A248ComFec[0];
            A689ComDDct = P00AS4_A689ComDDct[0];
            A686ComDPre = P00AS4_A686ComDPre[0];
            A685ComDCant = P00AS4_A685ComDCant[0];
            A250ComDItem = P00AS4_A250ComDItem[0];
            A251ComDOrdCod = P00AS4_A251ComDOrdCod[0];
            A139PaiCod = P00AS4_A139PaiCod[0];
            A298TprvCod = P00AS4_A298TprvCod[0];
            A52LinCod = P00AS4_A52LinCod[0];
            n52LinCod = P00AS4_n52LinCod[0];
            A1158LinStk = P00AS4_A1158LinStk[0];
            A511TipSigno = P00AS4_A511TipSigno[0];
            A707ComFReg = P00AS4_A707ComFReg[0];
            A704ComFecPago = P00AS4_A704ComFecPago[0];
            A724ComRefFec = P00AS4_A724ComRefFec[0];
            A246ComMon = P00AS4_A246ComMon[0];
            A248ComFec = P00AS4_A248ComFec[0];
            A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
            A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
            A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
            AV38TipCod2 = A149TipCod;
            AV20Fecha = (((StringUtil.StrCmp(AV38TipCod2, "NC")==0)||(StringUtil.StrCmp(AV38TipCod2, "ND")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : ((DateTime.MinValue==A704ComFecPago) ? A248ComFec : A704ComFecPago));
            AV27MonCod = A246ComMon;
            GXt_decimal1 = AV9Cambio;
            GXt_int2 = 2;
            GXt_char3 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV20Fecha, ref  GXt_char3, out  GXt_decimal1) ;
            AV9Cambio = GXt_decimal1;
            AV40Tot = NumberUtil.Round( A684ComDTot, 2);
            AV41Total = ((AV27MonCod==1) ? NumberUtil.Round( AV40Tot*A511TipSigno, 2) : NumberUtil.Round( AV40Tot*A511TipSigno, 2)*AV9Cambio);
            AV44TotalME = ((AV27MonCod==1) ? NumberUtil.Round( AV40Tot*A511TipSigno, 2)/ (decimal)(AV9Cambio) : NumberUtil.Round( AV40Tot*A511TipSigno, 2));
            AV45TotalVenta = (decimal)(AV45TotalVenta+AV41Total);
            AV46TotalVentaME = (decimal)(AV46TotalVentaME+AV44TotalME);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV18ExcelDocument.ErrCode != 0 )
         {
            AV22Filename = "";
            AV17ErrorMessage = AV18ExcelDocument.ErrDescription;
            AV18ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S131( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV13CondicionPago = "";
         if ( ! (0==AV33PrvConpCod) )
         {
            /* Using cursor P00AS5 */
            pr_default.execute(3, new Object[] {AV14DocCliCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A300PrvConpCod = P00AS5_A300PrvConpCod[0];
               A244PrvCod = P00AS5_A244PrvCod[0];
               A1756PrvConpDsc = P00AS5_A1756PrvConpDsc[0];
               A1756PrvConpDsc = P00AS5_A1756PrvConpDsc[0];
               AV13CondicionPago = StringUtil.Trim( A1756PrvConpDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
         }
         AV18ExcelDocument.get_Cells(AV10CellRow, AV25FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV14DocCliCod);
         AV18ExcelDocument.get_Cells(AV10CellRow, AV25FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV15DocCliDsc);
         AV18ExcelDocument.get_Cells(AV10CellRow, AV25FirstColumn+2, 1, 1).Number = (double)(AV45TotalVenta);
         AV18ExcelDocument.get_Cells(AV10CellRow, AV25FirstColumn+3, 1, 1).Number = (double)(AV30Porcentaje);
         AV18ExcelDocument.get_Cells(AV10CellRow, AV25FirstColumn+4, 1, 1).Number = (double)(AV46TotalVentaME);
         AV18ExcelDocument.get_Cells(AV10CellRow, AV25FirstColumn+5, 1, 1).Number = (double)(AV31Porcentaje2);
         AV18ExcelDocument.get_Cells(AV10CellRow, AV25FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV13CondicionPago);
         AV10CellRow = (int)(AV10CellRow+1);
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
         AV22Filename = "";
         AV17ErrorMessage = "";
         AV8Archivo = new GxFile(context.GetPhysicalPath());
         AV29Path = "";
         AV23FilenameOrigen = "";
         AV18ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P00AS2_A180MonCod = new int[1] ;
         P00AS2_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV24Filtro1 = "";
         A244PrvCod = "";
         A149TipCod = "";
         A139PaiCod = "";
         A254ComDProCod = "";
         A253ComDCueCod = "";
         A697ComDOrdTip = "";
         A707ComFReg = DateTime.MinValue;
         P00AS3_A243ComCod = new string[] {""} ;
         P00AS3_A52LinCod = new int[1] ;
         P00AS3_n52LinCod = new bool[] {false} ;
         P00AS3_A247PrvDsc = new string[] {""} ;
         P00AS3_A244PrvCod = new string[] {""} ;
         P00AS3_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AS3_A697ComDOrdTip = new string[] {""} ;
         P00AS3_A253ComDCueCod = new string[] {""} ;
         P00AS3_n253ComDCueCod = new bool[] {false} ;
         P00AS3_A254ComDProCod = new string[] {""} ;
         P00AS3_n254ComDProCod = new bool[] {false} ;
         P00AS3_A1158LinStk = new short[1] ;
         P00AS3_A139PaiCod = new string[] {""} ;
         P00AS3_A149TipCod = new string[] {""} ;
         P00AS3_A298TprvCod = new int[1] ;
         P00AS3_A300PrvConpCod = new int[1] ;
         P00AS3_A250ComDItem = new short[1] ;
         P00AS3_A251ComDOrdCod = new string[] {""} ;
         A243ComCod = "";
         A247PrvDsc = "";
         A251ComDOrdCod = "";
         AV14DocCliCod = "";
         AV15DocCliDsc = "";
         AV35SDTComprasProveedorITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV34SDTComprasProveedor = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         P00AS4_A243ComCod = new string[] {""} ;
         P00AS4_A52LinCod = new int[1] ;
         P00AS4_n52LinCod = new bool[] {false} ;
         P00AS4_A244PrvCod = new string[] {""} ;
         P00AS4_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AS4_A697ComDOrdTip = new string[] {""} ;
         P00AS4_A253ComDCueCod = new string[] {""} ;
         P00AS4_n253ComDCueCod = new bool[] {false} ;
         P00AS4_A254ComDProCod = new string[] {""} ;
         P00AS4_n254ComDProCod = new bool[] {false} ;
         P00AS4_A1158LinStk = new short[1] ;
         P00AS4_A139PaiCod = new string[] {""} ;
         P00AS4_A149TipCod = new string[] {""} ;
         P00AS4_A298TprvCod = new int[1] ;
         P00AS4_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00AS4_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00AS4_A246ComMon = new int[1] ;
         P00AS4_A511TipSigno = new short[1] ;
         P00AS4_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AS4_A689ComDDct = new decimal[1] ;
         P00AS4_A686ComDPre = new decimal[1] ;
         P00AS4_A685ComDCant = new decimal[1] ;
         P00AS4_A250ComDItem = new short[1] ;
         P00AS4_A251ComDOrdCod = new string[] {""} ;
         A704ComFecPago = DateTime.MinValue;
         A724ComRefFec = DateTime.MinValue;
         A248ComFec = DateTime.MinValue;
         AV38TipCod2 = "";
         AV20Fecha = DateTime.MinValue;
         GXt_char3 = "";
         AV13CondicionPago = "";
         P00AS5_A300PrvConpCod = new int[1] ;
         P00AS5_A244PrvCod = new string[] {""} ;
         P00AS5_A1756PrvConpDsc = new string[] {""} ;
         A1756PrvConpDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_comprasproveedoresexcel__default(),
            new Object[][] {
                new Object[] {
               P00AS2_A180MonCod, P00AS2_A1234MonDsc
               }
               , new Object[] {
               P00AS3_A243ComCod, P00AS3_A52LinCod, P00AS3_n52LinCod, P00AS3_A247PrvDsc, P00AS3_A244PrvCod, P00AS3_A707ComFReg, P00AS3_A697ComDOrdTip, P00AS3_A253ComDCueCod, P00AS3_n253ComDCueCod, P00AS3_A254ComDProCod,
               P00AS3_n254ComDProCod, P00AS3_A1158LinStk, P00AS3_A139PaiCod, P00AS3_A149TipCod, P00AS3_A298TprvCod, P00AS3_A300PrvConpCod, P00AS3_A250ComDItem, P00AS3_A251ComDOrdCod
               }
               , new Object[] {
               P00AS4_A243ComCod, P00AS4_A52LinCod, P00AS4_n52LinCod, P00AS4_A244PrvCod, P00AS4_A707ComFReg, P00AS4_A697ComDOrdTip, P00AS4_A253ComDCueCod, P00AS4_n253ComDCueCod, P00AS4_A254ComDProCod, P00AS4_n254ComDProCod,
               P00AS4_A1158LinStk, P00AS4_A139PaiCod, P00AS4_A149TipCod, P00AS4_A298TprvCod, P00AS4_A704ComFecPago, P00AS4_A724ComRefFec, P00AS4_A246ComMon, P00AS4_A511TipSigno, P00AS4_A248ComFec, P00AS4_A689ComDDct,
               P00AS4_A686ComDPre, P00AS4_A685ComDCant, P00AS4_A250ComDItem, P00AS4_A251ComDOrdCod
               }
               , new Object[] {
               P00AS5_A300PrvConpCod, P00AS5_A244PrvCod, P00AS5_A1756PrvConpDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1158LinStk ;
      private short A250ComDItem ;
      private short A511TipSigno ;
      private int AV47TPrvCod ;
      private int AV16DocMonCod ;
      private int A180MonCod ;
      private int AV10CellRow ;
      private int AV25FirstColumn ;
      private int A298TprvCod ;
      private int A52LinCod ;
      private int A300PrvConpCod ;
      private int AV33PrvConpCod ;
      private int AV53GXV1 ;
      private int A246ComMon ;
      private int AV27MonCod ;
      private int GXt_int2 ;
      private decimal AV42TotalGeneral ;
      private decimal AV43TotalGeneralME ;
      private decimal AV45TotalVenta ;
      private decimal AV46TotalVentaME ;
      private decimal AV41Total ;
      private decimal AV44TotalME ;
      private decimal AV30Porcentaje ;
      private decimal AV31Porcentaje2 ;
      private decimal AV36SumPorcent ;
      private decimal A689ComDDct ;
      private decimal A686ComDPre ;
      private decimal A685ComDCant ;
      private decimal A688ComDSub ;
      private decimal A687ComDDescuento ;
      private decimal A684ComDTot ;
      private decimal AV9Cambio ;
      private decimal GXt_decimal1 ;
      private decimal AV40Tot ;
      private string AV32PrvCod ;
      private string AV37TipCod ;
      private string AV28PaiCod ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string A244PrvCod ;
      private string A149TipCod ;
      private string A139PaiCod ;
      private string A254ComDProCod ;
      private string A253ComDCueCod ;
      private string A243ComCod ;
      private string A247PrvDsc ;
      private string A251ComDOrdCod ;
      private string AV14DocCliCod ;
      private string AV15DocCliDsc ;
      private string AV38TipCod2 ;
      private string GXt_char3 ;
      private string A1756PrvConpDsc ;
      private DateTime AV19FDesde ;
      private DateTime AV21FHasta ;
      private DateTime A707ComFReg ;
      private DateTime A704ComFecPago ;
      private DateTime A724ComRefFec ;
      private DateTime A248ComFec ;
      private DateTime AV20Fecha ;
      private bool returnInSub ;
      private bool BRKAS3 ;
      private bool n52LinCod ;
      private bool n253ComDCueCod ;
      private bool n254ComDProCod ;
      private string AV39Tipo ;
      private string AV22Filename ;
      private string AV17ErrorMessage ;
      private string AV29Path ;
      private string AV23FilenameOrigen ;
      private string AV24Filtro1 ;
      private string A697ComDOrdTip ;
      private string AV13CondicionPago ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TPrvCod ;
      private string aP1_PrvCod ;
      private string aP2_TipCod ;
      private string aP3_PaiCod ;
      private DateTime aP4_FDesde ;
      private DateTime aP5_FHasta ;
      private int aP6_DocMonCod ;
      private string aP7_Tipo ;
      private IDataStoreProvider pr_default ;
      private int[] P00AS2_A180MonCod ;
      private string[] P00AS2_A1234MonDsc ;
      private string[] P00AS3_A243ComCod ;
      private int[] P00AS3_A52LinCod ;
      private bool[] P00AS3_n52LinCod ;
      private string[] P00AS3_A247PrvDsc ;
      private string[] P00AS3_A244PrvCod ;
      private DateTime[] P00AS3_A707ComFReg ;
      private string[] P00AS3_A697ComDOrdTip ;
      private string[] P00AS3_A253ComDCueCod ;
      private bool[] P00AS3_n253ComDCueCod ;
      private string[] P00AS3_A254ComDProCod ;
      private bool[] P00AS3_n254ComDProCod ;
      private short[] P00AS3_A1158LinStk ;
      private string[] P00AS3_A139PaiCod ;
      private string[] P00AS3_A149TipCod ;
      private int[] P00AS3_A298TprvCod ;
      private int[] P00AS3_A300PrvConpCod ;
      private short[] P00AS3_A250ComDItem ;
      private string[] P00AS3_A251ComDOrdCod ;
      private string[] P00AS4_A243ComCod ;
      private int[] P00AS4_A52LinCod ;
      private bool[] P00AS4_n52LinCod ;
      private string[] P00AS4_A244PrvCod ;
      private DateTime[] P00AS4_A707ComFReg ;
      private string[] P00AS4_A697ComDOrdTip ;
      private string[] P00AS4_A253ComDCueCod ;
      private bool[] P00AS4_n253ComDCueCod ;
      private string[] P00AS4_A254ComDProCod ;
      private bool[] P00AS4_n254ComDProCod ;
      private short[] P00AS4_A1158LinStk ;
      private string[] P00AS4_A139PaiCod ;
      private string[] P00AS4_A149TipCod ;
      private int[] P00AS4_A298TprvCod ;
      private DateTime[] P00AS4_A704ComFecPago ;
      private DateTime[] P00AS4_A724ComRefFec ;
      private int[] P00AS4_A246ComMon ;
      private short[] P00AS4_A511TipSigno ;
      private DateTime[] P00AS4_A248ComFec ;
      private decimal[] P00AS4_A689ComDDct ;
      private decimal[] P00AS4_A686ComDPre ;
      private decimal[] P00AS4_A685ComDCant ;
      private short[] P00AS4_A250ComDItem ;
      private string[] P00AS4_A251ComDOrdCod ;
      private int[] P00AS5_A300PrvConpCod ;
      private string[] P00AS5_A244PrvCod ;
      private string[] P00AS5_A1756PrvConpDsc ;
      private string aP8_Filename ;
      private string aP9_ErrorMessage ;
      private ExcelDocumentI AV18ExcelDocument ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV34SDTComprasProveedor ;
      private GxFile AV8Archivo ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV35SDTComprasProveedorITem ;
   }

   public class r_comprasproveedoresexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AS3( IGxContext context ,
                                             int AV47TPrvCod ,
                                             string AV32PrvCod ,
                                             string AV37TipCod ,
                                             string AV28PaiCod ,
                                             string AV39Tipo ,
                                             int A298TprvCod ,
                                             string A244PrvCod ,
                                             string A149TipCod ,
                                             string A139PaiCod ,
                                             short A1158LinStk ,
                                             string A254ComDProCod ,
                                             string A253ComDCueCod ,
                                             string A697ComDOrdTip ,
                                             DateTime A707ComFReg ,
                                             DateTime AV19FDesde ,
                                             DateTime AV21FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[ComCod], T3.[LinCod], T5.[PrvDsc], T1.[PrvCod], T5.[ComFReg], T1.[ComDOrdTip], T1.[ComDCueCod], T1.[ComDProCod] AS ComDProCod, T4.[LinStk], T2.[PaiCod], T1.[TipCod], T2.[TprvCod], T2.[PrvConpCod] AS PrvConpCod, T1.[ComDItem], T1.[ComDOrdCod] FROM (((([CPCOMPRASDET] T1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = T1.[PrvCod]) LEFT JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ComDProCod]) LEFT JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T3.[LinCod]) INNER JOIN [CPCOMPRAS] T5 ON T5.[TipCod] = T1.[TipCod] AND T5.[ComCod] = T1.[ComCod] AND T5.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(T5.[ComFReg] >= @AV19FDesde and T5.[ComFReg] <= @AV21FHasta)");
         if ( ! (0==AV47TPrvCod) )
         {
            AddWhere(sWhereString, "(T2.[TprvCod] = @AV47TPrvCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV32PrvCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[TipCod] = @AV37TipCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28PaiCod)) )
         {
            AddWhere(sWhereString, "(T2.[PaiCod] = @AV28PaiCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV39Tipo, "P") == 0 )
         {
            AddWhere(sWhereString, "(T4.[LinStk] = 1 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         if ( StringUtil.StrCmp(AV39Tipo, "S") == 0 )
         {
            AddWhere(sWhereString, "(T4.[LinStk] = 0 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         if ( StringUtil.StrCmp(AV39Tipo, "G") == 0 )
         {
            AddWhere(sWhereString, "(Not (T1.[ComDCueCod] = '') and (T1.[ComDOrdTip] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PrvCod], T5.[PrvDsc]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00AS4( IGxContext context ,
                                             int AV47TPrvCod ,
                                             string AV32PrvCod ,
                                             string AV37TipCod ,
                                             string AV28PaiCod ,
                                             string AV39Tipo ,
                                             int A298TprvCod ,
                                             string A244PrvCod ,
                                             string A149TipCod ,
                                             string A139PaiCod ,
                                             short A1158LinStk ,
                                             string A254ComDProCod ,
                                             string A253ComDCueCod ,
                                             string A697ComDOrdTip ,
                                             DateTime A707ComFReg ,
                                             DateTime AV19FDesde ,
                                             DateTime AV21FHasta ,
                                             string AV14DocCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[7];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[ComCod], T3.[LinCod], T1.[PrvCod], T6.[ComFReg], T1.[ComDOrdTip], T1.[ComDCueCod], T1.[ComDProCod] AS ComDProCod, T4.[LinStk], T2.[PaiCod], T1.[TipCod], T2.[TprvCod], T6.[ComFecPago], T6.[ComRefFec], T6.[ComMon], T5.[TipSigno], T6.[ComFec], T1.[ComDDct], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem], T1.[ComDOrdCod] FROM ((((([CPCOMPRASDET] T1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = T1.[PrvCod]) LEFT JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ComDProCod]) LEFT JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T3.[LinCod]) INNER JOIN [CTIPDOC] T5 ON T5.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod])";
         AddWhere(sWhereString, "(T6.[ComFReg] >= @AV19FDesde and T6.[ComFReg] <= @AV21FHasta)");
         AddWhere(sWhereString, "(T1.[PrvCod] = @AV14DocCliCod)");
         if ( ! (0==AV47TPrvCod) )
         {
            AddWhere(sWhereString, "(T2.[TprvCod] = @AV47TPrvCod)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV32PrvCod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[TipCod] = @AV37TipCod)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28PaiCod)) )
         {
            AddWhere(sWhereString, "(T2.[PaiCod] = @AV28PaiCod)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV39Tipo, "P") == 0 )
         {
            AddWhere(sWhereString, "(T4.[LinStk] = 1 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         if ( StringUtil.StrCmp(AV39Tipo, "S") == 0 )
         {
            AddWhere(sWhereString, "(T4.[LinStk] = 0 and ( Not (T1.[ComDProCod] = '') and Not T1.[ComDProCod] IS NULL))");
         }
         if ( StringUtil.StrCmp(AV39Tipo, "G") == 0 )
         {
            AddWhere(sWhereString, "(Not (T1.[ComDCueCod] = '') and (T1.[ComDOrdTip] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T6.[ComFec]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00AS3(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] );
               case 2 :
                     return conditional_P00AS4(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AS2;
          prmP00AS2 = new Object[] {
          new ParDef("@AV16DocMonCod",GXType.Int32,6,0)
          };
          Object[] prmP00AS5;
          prmP00AS5 = new Object[] {
          new ParDef("@AV14DocCliCod",GXType.NChar,20,0)
          };
          Object[] prmP00AS3;
          prmP00AS3 = new Object[] {
          new ParDef("@AV19FDesde",GXType.Date,8,0) ,
          new ParDef("@AV21FHasta",GXType.Date,8,0) ,
          new ParDef("@AV47TPrvCod",GXType.Int32,6,0) ,
          new ParDef("@AV32PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV37TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV28PaiCod",GXType.NChar,4,0)
          };
          Object[] prmP00AS4;
          prmP00AS4 = new Object[] {
          new ParDef("@AV19FDesde",GXType.Date,8,0) ,
          new ParDef("@AV21FHasta",GXType.Date,8,0) ,
          new ParDef("@AV14DocCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV47TPrvCod",GXType.Int32,6,0) ,
          new ParDef("@AV32PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV37TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV28PaiCod",GXType.NChar,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AS2", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV16DocMonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AS2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AS3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AS3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AS4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AS4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AS5", "SELECT T1.[PrvConpCod] AS PrvConpCod, T1.[PrvCod], T2.[ConpDsc] AS PrvConpDsc FROM ([CPPROVEEDORES] T1 INNER JOIN [CCONDICIONPAGO] T2 ON T2.[Conpcod] = T1.[PrvConpCod]) WHERE T1.[PrvCod] = @AV14DocCliCod ORDER BY T1.[PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AS5,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 15);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 15);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((short[]) buf[11])[0] = rslt.getShort(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 4);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((int[]) buf[14])[0] = rslt.getInt(12);
                ((int[]) buf[15])[0] = rslt.getInt(13);
                ((short[]) buf[16])[0] = rslt.getShort(14);
                ((string[]) buf[17])[0] = rslt.getString(15, 10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 15);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 15);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((short[]) buf[10])[0] = rslt.getShort(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 4);
                ((string[]) buf[12])[0] = rslt.getString(10, 3);
                ((int[]) buf[13])[0] = rslt.getInt(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(12);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(13);
                ((int[]) buf[16])[0] = rslt.getInt(14);
                ((short[]) buf[17])[0] = rslt.getShort(15);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(16);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(19);
                ((short[]) buf[22])[0] = rslt.getShort(20);
                ((string[]) buf[23])[0] = rslt.getString(21, 10);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
