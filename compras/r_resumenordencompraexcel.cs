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
   public class r_resumenordencompraexcel : GXProcedure
   {
      public r_resumenordencompraexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenordencompraexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_PrvCod ,
                           ref string aP1_ProdCod ,
                           ref int aP2_MonCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref int aP5_LinCod ,
                           ref short aP6_OpcPed ,
                           ref int aP7_TprvCod ,
                           ref string aP8_CosCod ,
                           ref string aP9_TipOrden ,
                           out string aP10_Filename ,
                           out string aP11_ErrorMessage )
      {
         this.AV53PrvCod = aP0_PrvCod;
         this.AV51ProdCod = aP1_ProdCod;
         this.AV32MonCod = aP2_MonCod;
         this.AV21FDesde = aP3_FDesde;
         this.AV22FHasta = aP4_FHasta;
         this.AV30LinCod = aP5_LinCod;
         this.AV33OpcPed = aP6_OpcPed;
         this.AV60TprvCod = aP7_TprvCod;
         this.AV13CosCod = aP8_CosCod;
         this.AV54TipOrden = aP9_TipOrden;
         this.AV23Filename = "" ;
         this.AV17ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_PrvCod=this.AV53PrvCod;
         aP1_ProdCod=this.AV51ProdCod;
         aP2_MonCod=this.AV32MonCod;
         aP3_FDesde=this.AV21FDesde;
         aP4_FHasta=this.AV22FHasta;
         aP5_LinCod=this.AV30LinCod;
         aP6_OpcPed=this.AV33OpcPed;
         aP7_TprvCod=this.AV60TprvCod;
         aP8_CosCod=this.AV13CosCod;
         aP9_TipOrden=this.AV54TipOrden;
         aP10_Filename=this.AV23Filename;
         aP11_ErrorMessage=this.AV17ErrorMessage;
      }

      public string executeUdp( ref string aP0_PrvCod ,
                                ref string aP1_ProdCod ,
                                ref int aP2_MonCod ,
                                ref DateTime aP3_FDesde ,
                                ref DateTime aP4_FHasta ,
                                ref int aP5_LinCod ,
                                ref short aP6_OpcPed ,
                                ref int aP7_TprvCod ,
                                ref string aP8_CosCod ,
                                ref string aP9_TipOrden ,
                                out string aP10_Filename )
      {
         execute(ref aP0_PrvCod, ref aP1_ProdCod, ref aP2_MonCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_LinCod, ref aP6_OpcPed, ref aP7_TprvCod, ref aP8_CosCod, ref aP9_TipOrden, out aP10_Filename, out aP11_ErrorMessage);
         return AV17ErrorMessage ;
      }

      public void executeSubmit( ref string aP0_PrvCod ,
                                 ref string aP1_ProdCod ,
                                 ref int aP2_MonCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref int aP5_LinCod ,
                                 ref short aP6_OpcPed ,
                                 ref int aP7_TprvCod ,
                                 ref string aP8_CosCod ,
                                 ref string aP9_TipOrden ,
                                 out string aP10_Filename ,
                                 out string aP11_ErrorMessage )
      {
         r_resumenordencompraexcel objr_resumenordencompraexcel;
         objr_resumenordencompraexcel = new r_resumenordencompraexcel();
         objr_resumenordencompraexcel.AV53PrvCod = aP0_PrvCod;
         objr_resumenordencompraexcel.AV51ProdCod = aP1_ProdCod;
         objr_resumenordencompraexcel.AV32MonCod = aP2_MonCod;
         objr_resumenordencompraexcel.AV21FDesde = aP3_FDesde;
         objr_resumenordencompraexcel.AV22FHasta = aP4_FHasta;
         objr_resumenordencompraexcel.AV30LinCod = aP5_LinCod;
         objr_resumenordencompraexcel.AV33OpcPed = aP6_OpcPed;
         objr_resumenordencompraexcel.AV60TprvCod = aP7_TprvCod;
         objr_resumenordencompraexcel.AV13CosCod = aP8_CosCod;
         objr_resumenordencompraexcel.AV54TipOrden = aP9_TipOrden;
         objr_resumenordencompraexcel.AV23Filename = "" ;
         objr_resumenordencompraexcel.AV17ErrorMessage = "" ;
         objr_resumenordencompraexcel.context.SetSubmitInitialConfig(context);
         objr_resumenordencompraexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenordencompraexcel);
         aP0_PrvCod=this.AV53PrvCod;
         aP1_ProdCod=this.AV51ProdCod;
         aP2_MonCod=this.AV32MonCod;
         aP3_FDesde=this.AV21FDesde;
         aP4_FHasta=this.AV22FHasta;
         aP5_LinCod=this.AV30LinCod;
         aP6_OpcPed=this.AV33OpcPed;
         aP7_TprvCod=this.AV60TprvCod;
         aP8_CosCod=this.AV13CosCod;
         aP9_TipOrden=this.AV54TipOrden;
         aP10_Filename=this.AV23Filename;
         aP11_ErrorMessage=this.AV17ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenordencompraexcel)stateInfo).executePrivate();
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
         AV8Archivo.Source = "Excel/PlantillasResumenOrdenes.xlsx";
         AV38Path = AV8Archivo.GetPath();
         AV24FilenameOrigen = StringUtil.Trim( AV38Path) + "\\PlantillasResumenOrdenes.xlsx";
         AV23Filename = "Excel/OrdenesCompraPendientes" + ".xlsx";
         AV19ExcelDocument.Clear();
         AV19ExcelDocument.Template = AV24FilenameOrigen;
         AV19ExcelDocument.Open(AV23Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Using cursor P007T2 */
         pr_default.execute(0, new Object[] {AV53PrvCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A244PrvCod = P007T2_A244PrvCod[0];
            A247PrvDsc = P007T2_A247PrvDsc[0];
            AV25Filtro1 = A247PrvDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P007T3 */
         pr_default.execute(1, new Object[] {AV32MonCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A180MonCod = P007T3_A180MonCod[0];
            A1234MonDsc = P007T3_A1234MonDsc[0];
            AV26Filtro2 = A1234MonDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV9CellRow = 5;
         AV28FirstColumn = 1;
         AV29Item = 0;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV53PrvCod ,
                                              AV32MonCod ,
                                              AV51ProdCod ,
                                              AV30LinCod ,
                                              AV60TprvCod ,
                                              AV13CosCod ,
                                              AV33OpcPed ,
                                              A244PrvCod ,
                                              A290OrdMonCod ,
                                              A28ProdCod ,
                                              A52LinCod ,
                                              A298TprvCod ,
                                              A291OrdCosCod ,
                                              A1462OrdSts ,
                                              AV22FHasta ,
                                              A293OrdFec ,
                                              AV21FDesde } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE
                                              }
         });
         /* Using cursor P007T4 */
         pr_default.execute(2, new Object[] {AV22FHasta, AV21FDesde, AV53PrvCod, AV32MonCod, AV51ProdCod, AV30LinCod, AV60TprvCod, AV13CosCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A49UniCod = P007T4_A49UniCod[0];
            A1462OrdSts = P007T4_A1462OrdSts[0];
            A291OrdCosCod = P007T4_A291OrdCosCod[0];
            n291OrdCosCod = P007T4_n291OrdCosCod[0];
            A298TprvCod = P007T4_A298TprvCod[0];
            A52LinCod = P007T4_A52LinCod[0];
            A28ProdCod = P007T4_A28ProdCod[0];
            A290OrdMonCod = P007T4_A290OrdMonCod[0];
            A293OrdFec = P007T4_A293OrdFec[0];
            A244PrvCod = P007T4_A244PrvCod[0];
            A1466OrdTip = P007T4_A1466OrdTip[0];
            A1233MonAbr = P007T4_A1233MonAbr[0];
            n1233MonAbr = P007T4_n1233MonAbr[0];
            A247PrvDsc = P007T4_A247PrvDsc[0];
            A289OrdCod = P007T4_A289OrdCod[0];
            A1461OrdRequ = P007T4_A1461OrdRequ[0];
            A1434OrdDCanIng = P007T4_A1434OrdDCanIng[0];
            A1432OrdDCanFac = P007T4_A1432OrdDCanFac[0];
            A1997UniAbr = P007T4_A1997UniAbr[0];
            A1444OrdDTot = P007T4_A1444OrdDTot[0];
            A1441OrdDObs = P007T4_A1441OrdDObs[0];
            A55ProdDsc = P007T4_A55ProdDsc[0];
            A1469OrdUsuC = P007T4_A1469OrdUsuC[0];
            A1451OrdFecC = P007T4_A1451OrdFecC[0];
            A1470OrdUsuM = P007T4_A1470OrdUsuM[0];
            A1452OrdFecM = P007T4_A1452OrdFecM[0];
            A1438OrdDPre = P007T4_A1438OrdDPre[0];
            A1431OrdDCan = P007T4_A1431OrdDCan[0];
            A1439OrdDDscto = P007T4_A1439OrdDDscto[0];
            A295OrdDItem = P007T4_A295OrdDItem[0];
            A49UniCod = P007T4_A49UniCod[0];
            A52LinCod = P007T4_A52LinCod[0];
            A55ProdDsc = P007T4_A55ProdDsc[0];
            A1997UniAbr = P007T4_A1997UniAbr[0];
            A1462OrdSts = P007T4_A1462OrdSts[0];
            A291OrdCosCod = P007T4_A291OrdCosCod[0];
            n291OrdCosCod = P007T4_n291OrdCosCod[0];
            A290OrdMonCod = P007T4_A290OrdMonCod[0];
            A293OrdFec = P007T4_A293OrdFec[0];
            A244PrvCod = P007T4_A244PrvCod[0];
            A1466OrdTip = P007T4_A1466OrdTip[0];
            A1461OrdRequ = P007T4_A1461OrdRequ[0];
            A1469OrdUsuC = P007T4_A1469OrdUsuC[0];
            A1451OrdFecC = P007T4_A1451OrdFecC[0];
            A1470OrdUsuM = P007T4_A1470OrdUsuM[0];
            A1452OrdFecM = P007T4_A1452OrdFecM[0];
            A1233MonAbr = P007T4_A1233MonAbr[0];
            n1233MonAbr = P007T4_n1233MonAbr[0];
            A298TprvCod = P007T4_A298TprvCod[0];
            A247PrvDsc = P007T4_A247PrvDsc[0];
            A1437OrdDSub = NumberUtil.Round( A1431OrdDCan*A1438OrdDPre, 2);
            A1436OrdDDescuento = NumberUtil.Round( A1437OrdDSub*A1439OrdDDscto/ (decimal)(100), 2);
            AV37OrdTip = A1466OrdTip;
            AV36OrdFec = A293OrdFec;
            AV15DocMonCod = A290OrdMonCod;
            AV31MonAbr = StringUtil.Trim( A1233MonAbr);
            AV12Codigo = A28ProdCod;
            AV34OrdCosCod = A291OrdCosCod;
            AV39PedCliCod = A244PrvCod;
            AV11CliDsc = A247PrvDsc;
            AV41PedCod = A289OrdCod;
            AV47PedRef = A1461OrdRequ;
            AV46PedFec = A293OrdFec;
            AV42PedDCan = A1431OrdDCan;
            AV43PedDCanDsp = A1434OrdDCanIng;
            AV44PedDCanFac = A1432OrdDCanFac;
            AV61UniAbr = StringUtil.Trim( A1997UniAbr);
            AV49Precio = A1438OrdDPre;
            AV16Dscto = A1436OrdDDescuento;
            AV50PreTot = A1444OrdDTot;
            AV35OrdDObs = StringUtil.Trim( A1441OrdDObs);
            AV52Producto = StringUtil.Trim( A55ProdDsc);
            AV12Codigo = StringUtil.Trim( A28ProdCod);
            AV18Estado = (String.IsNullOrEmpty(StringUtil.RTrim( A1462OrdSts)) ? "PENDIENTE" : ((StringUtil.StrCmp(A1462OrdSts, "T")==0) ? "TERMINADO" : ((StringUtil.StrCmp(A1462OrdSts, "F")==0) ? "FACTURADO" : ((StringUtil.StrCmp(A1462OrdSts, "A")==0) ? "ANULADO" : ((StringUtil.StrCmp(A1462OrdSts, "P")==0) ? "POR AUTORIZAR" : "INGRESADO")))));
            AV62OrdUsuC = A1469OrdUsuC;
            AV64OrdFecC = A1451OrdFecC;
            AV63OrdUsuM = A1470OrdUsuM;
            AV65OrdFecM = A1452OrdFecM;
            AV67MVACod = "";
            AV66MVAFec = DateTime.MinValue;
            AV68ComRef = "";
            /* Execute user subroutine: 'DATOSADICIONALES' */
            S131 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'DETALLE' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               this.cleanup();
               if (true) return;
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV19ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV19ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV19ExcelDocument.ErrCode != 0 )
         {
            AV23Filename = "";
            AV17ErrorMessage = AV19ExcelDocument.ErrDescription;
            AV19ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV14Costo = "";
         /* Using cursor P007T5 */
         pr_default.execute(3, new Object[] {AV34OrdCosCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A79COSCod = P007T5_A79COSCod[0];
            A761COSDsc = P007T5_A761COSDsc[0];
            AV14Costo = StringUtil.Trim( A761COSDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+0), 1, 1).Text = ((StringUtil.StrCmp(AV37OrdTip, "S")==0) ? "Servicio" : "Compra");
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV41PedCod);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+2), 1, 1).Text = StringUtil.Trim( AV47PedRef);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV46PedFec ) ;
         AV19ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+3), 1, 1).Date = GXt_dtime1;
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+4), 1, 1).Text = StringUtil.Trim( AV39PedCliCod);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+5), 1, 1).Text = StringUtil.Trim( AV11CliDsc);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+6), 1, 1).Text = StringUtil.Trim( AV12Codigo);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+7), 1, 1).Text = StringUtil.Trim( AV52Producto);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+8), 1, 1).Text = StringUtil.Trim( AV35OrdDObs);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+9), 1, 1).Text = StringUtil.Trim( AV61UniAbr);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+10), 1, 1).Text = StringUtil.Trim( AV31MonAbr);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+11), 1, 1).Number = (double)(AV49Precio);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+12), 1, 1).Number = (double)(AV16Dscto);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+13), 1, 1).Number = (double)(((AV15DocMonCod==1) ? AV50PreTot : (decimal)(0)));
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+14), 1, 1).Number = (double)(((AV15DocMonCod==2) ? AV50PreTot : (decimal)(0)));
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+15), 1, 1).Text = AV67MVACod;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV66MVAFec ) ;
         AV19ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+16), 1, 1).Date = GXt_dtime1;
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+17), 1, 1).Number = (double)(AV42PedDCan);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+18), 1, 1).Number = (double)(AV43PedDCanDsp);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+19), 1, 1).Number = (double)(AV44PedDCanFac);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+20), 1, 1).Number = (double)(AV42PedDCan-AV43PedDCanDsp);
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+21), 1, 1).Text = AV68ComRef;
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+22), 1, 1).Text = AV14Costo;
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+23), 1, 1).Text = AV18Estado;
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+24), 1, 1).Text = AV62OrdUsuC;
         AV19ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+25), 1, 1).Date = AV64OrdFecC;
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+26), 1, 1).Text = AV63OrdUsuM;
         AV19ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV19ExcelDocument.get_Cells((int)(AV9CellRow), (int)(AV28FirstColumn+27), 1, 1).Date = AV65OrdFecM;
         AV9CellRow = (long)(AV9CellRow+1);
      }

      protected void S131( )
      {
         /* 'DATOSADICIONALES' Routine */
         returnInSub = false;
         /* Using cursor P007T6 */
         pr_default.execute(4, new Object[] {AV41PedCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A1286MvATMov = P007T6_A1286MvATMov[0];
            A1276MvAOcom = P007T6_A1276MvAOcom[0];
            A1370MVSts = P007T6_A1370MVSts[0];
            A13MvATip = P007T6_A13MvATip[0];
            A14MvACod = P007T6_A14MvACod[0];
            A25MvAFec = P007T6_A25MvAFec[0];
            AV67MVACod = A14MvACod;
            AV66MVAFec = A25MvAFec;
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Using cursor P007T7 */
         pr_default.execute(5, new Object[] {AV41PedCod, AV37OrdTip});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A149TipCod = P007T7_A149TipCod[0];
            A243ComCod = P007T7_A243ComCod[0];
            A244PrvCod = P007T7_A244PrvCod[0];
            A697ComDOrdTip = P007T7_A697ComDOrdTip[0];
            A251ComDOrdCod = P007T7_A251ComDOrdCod[0];
            A249ComRef = P007T7_A249ComRef[0];
            A250ComDItem = P007T7_A250ComDItem[0];
            A249ComRef = P007T7_A249ComRef[0];
            AV68ComRef = A249ComRef;
            pr_default.readNext(5);
         }
         pr_default.close(5);
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
         AV23Filename = "";
         AV17ErrorMessage = "";
         AV8Archivo = new GxFile(context.GetPhysicalPath());
         AV38Path = "";
         AV24FilenameOrigen = "";
         AV19ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P007T2_A244PrvCod = new string[] {""} ;
         P007T2_A247PrvDsc = new string[] {""} ;
         A244PrvCod = "";
         A247PrvDsc = "";
         AV25Filtro1 = "";
         P007T3_A180MonCod = new int[1] ;
         P007T3_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV26Filtro2 = "";
         A28ProdCod = "";
         A291OrdCosCod = "";
         A1462OrdSts = "";
         A293OrdFec = DateTime.MinValue;
         P007T4_A49UniCod = new int[1] ;
         P007T4_A1462OrdSts = new string[] {""} ;
         P007T4_A291OrdCosCod = new string[] {""} ;
         P007T4_n291OrdCosCod = new bool[] {false} ;
         P007T4_A298TprvCod = new int[1] ;
         P007T4_A52LinCod = new int[1] ;
         P007T4_A28ProdCod = new string[] {""} ;
         P007T4_A290OrdMonCod = new int[1] ;
         P007T4_A293OrdFec = new DateTime[] {DateTime.MinValue} ;
         P007T4_A244PrvCod = new string[] {""} ;
         P007T4_A1466OrdTip = new string[] {""} ;
         P007T4_A1233MonAbr = new string[] {""} ;
         P007T4_n1233MonAbr = new bool[] {false} ;
         P007T4_A247PrvDsc = new string[] {""} ;
         P007T4_A289OrdCod = new string[] {""} ;
         P007T4_A1461OrdRequ = new string[] {""} ;
         P007T4_A1434OrdDCanIng = new decimal[1] ;
         P007T4_A1432OrdDCanFac = new decimal[1] ;
         P007T4_A1997UniAbr = new string[] {""} ;
         P007T4_A1444OrdDTot = new decimal[1] ;
         P007T4_A1441OrdDObs = new string[] {""} ;
         P007T4_A55ProdDsc = new string[] {""} ;
         P007T4_A1469OrdUsuC = new string[] {""} ;
         P007T4_A1451OrdFecC = new DateTime[] {DateTime.MinValue} ;
         P007T4_A1470OrdUsuM = new string[] {""} ;
         P007T4_A1452OrdFecM = new DateTime[] {DateTime.MinValue} ;
         P007T4_A1438OrdDPre = new decimal[1] ;
         P007T4_A1431OrdDCan = new decimal[1] ;
         P007T4_A1439OrdDDscto = new decimal[1] ;
         P007T4_A295OrdDItem = new int[1] ;
         A1466OrdTip = "";
         A1233MonAbr = "";
         A289OrdCod = "";
         A1461OrdRequ = "";
         A1997UniAbr = "";
         A1441OrdDObs = "";
         A55ProdDsc = "";
         A1469OrdUsuC = "";
         A1451OrdFecC = (DateTime)(DateTime.MinValue);
         A1470OrdUsuM = "";
         A1452OrdFecM = (DateTime)(DateTime.MinValue);
         AV37OrdTip = "";
         AV36OrdFec = DateTime.MinValue;
         AV31MonAbr = "";
         AV12Codigo = "";
         AV34OrdCosCod = "";
         AV39PedCliCod = "";
         AV11CliDsc = "";
         AV41PedCod = "";
         AV47PedRef = "";
         AV46PedFec = DateTime.MinValue;
         AV61UniAbr = "";
         AV35OrdDObs = "";
         AV52Producto = "";
         AV18Estado = "";
         AV62OrdUsuC = "";
         AV64OrdFecC = (DateTime)(DateTime.MinValue);
         AV63OrdUsuM = "";
         AV65OrdFecM = (DateTime)(DateTime.MinValue);
         AV67MVACod = "";
         AV66MVAFec = DateTime.MinValue;
         AV68ComRef = "";
         AV14Costo = "";
         P007T5_A79COSCod = new string[] {""} ;
         P007T5_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         P007T6_A1286MvATMov = new short[1] ;
         P007T6_A1276MvAOcom = new string[] {""} ;
         P007T6_A1370MVSts = new string[] {""} ;
         P007T6_A13MvATip = new string[] {""} ;
         P007T6_A14MvACod = new string[] {""} ;
         P007T6_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         A1276MvAOcom = "";
         A1370MVSts = "";
         A13MvATip = "";
         A14MvACod = "";
         A25MvAFec = DateTime.MinValue;
         P007T7_A149TipCod = new string[] {""} ;
         P007T7_A243ComCod = new string[] {""} ;
         P007T7_A244PrvCod = new string[] {""} ;
         P007T7_A697ComDOrdTip = new string[] {""} ;
         P007T7_A251ComDOrdCod = new string[] {""} ;
         P007T7_A249ComRef = new string[] {""} ;
         P007T7_A250ComDItem = new short[1] ;
         A149TipCod = "";
         A243ComCod = "";
         A697ComDOrdTip = "";
         A251ComDOrdCod = "";
         A249ComRef = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_resumenordencompraexcel__default(),
            new Object[][] {
                new Object[] {
               P007T2_A244PrvCod, P007T2_A247PrvDsc
               }
               , new Object[] {
               P007T3_A180MonCod, P007T3_A1234MonDsc
               }
               , new Object[] {
               P007T4_A49UniCod, P007T4_A1462OrdSts, P007T4_A291OrdCosCod, P007T4_n291OrdCosCod, P007T4_A298TprvCod, P007T4_A52LinCod, P007T4_A28ProdCod, P007T4_A290OrdMonCod, P007T4_A293OrdFec, P007T4_A244PrvCod,
               P007T4_A1466OrdTip, P007T4_A1233MonAbr, P007T4_n1233MonAbr, P007T4_A247PrvDsc, P007T4_A289OrdCod, P007T4_A1461OrdRequ, P007T4_A1434OrdDCanIng, P007T4_A1432OrdDCanFac, P007T4_A1997UniAbr, P007T4_A1444OrdDTot,
               P007T4_A1441OrdDObs, P007T4_A55ProdDsc, P007T4_A1469OrdUsuC, P007T4_A1451OrdFecC, P007T4_A1470OrdUsuM, P007T4_A1452OrdFecM, P007T4_A1438OrdDPre, P007T4_A1431OrdDCan, P007T4_A1439OrdDDscto, P007T4_A295OrdDItem
               }
               , new Object[] {
               P007T5_A79COSCod, P007T5_A761COSDsc
               }
               , new Object[] {
               P007T6_A1286MvATMov, P007T6_A1276MvAOcom, P007T6_A1370MVSts, P007T6_A13MvATip, P007T6_A14MvACod, P007T6_A25MvAFec
               }
               , new Object[] {
               P007T7_A149TipCod, P007T7_A243ComCod, P007T7_A244PrvCod, P007T7_A697ComDOrdTip, P007T7_A251ComDOrdCod, P007T7_A249ComRef, P007T7_A250ComDItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV33OpcPed ;
      private short A1286MvATMov ;
      private short A250ComDItem ;
      private int AV32MonCod ;
      private int AV30LinCod ;
      private int AV60TprvCod ;
      private int A180MonCod ;
      private int AV29Item ;
      private int A290OrdMonCod ;
      private int A52LinCod ;
      private int A298TprvCod ;
      private int A49UniCod ;
      private int A295OrdDItem ;
      private int AV15DocMonCod ;
      private long AV9CellRow ;
      private long AV28FirstColumn ;
      private decimal A1434OrdDCanIng ;
      private decimal A1432OrdDCanFac ;
      private decimal A1444OrdDTot ;
      private decimal A1438OrdDPre ;
      private decimal A1431OrdDCan ;
      private decimal A1439OrdDDscto ;
      private decimal A1437OrdDSub ;
      private decimal A1436OrdDDescuento ;
      private decimal AV42PedDCan ;
      private decimal AV43PedDCanDsp ;
      private decimal AV44PedDCanFac ;
      private decimal AV49Precio ;
      private decimal AV16Dscto ;
      private decimal AV50PreTot ;
      private string AV53PrvCod ;
      private string AV51ProdCod ;
      private string AV13CosCod ;
      private string AV38Path ;
      private string scmdbuf ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A1234MonDsc ;
      private string A28ProdCod ;
      private string A291OrdCosCod ;
      private string A1462OrdSts ;
      private string A1233MonAbr ;
      private string A289OrdCod ;
      private string A1461OrdRequ ;
      private string A1997UniAbr ;
      private string A55ProdDsc ;
      private string A1469OrdUsuC ;
      private string A1470OrdUsuM ;
      private string AV31MonAbr ;
      private string AV12Codigo ;
      private string AV34OrdCosCod ;
      private string AV39PedCliCod ;
      private string AV11CliDsc ;
      private string AV41PedCod ;
      private string AV47PedRef ;
      private string AV61UniAbr ;
      private string AV52Producto ;
      private string AV62OrdUsuC ;
      private string AV63OrdUsuM ;
      private string AV67MVACod ;
      private string AV68ComRef ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string A1276MvAOcom ;
      private string A1370MVSts ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A149TipCod ;
      private string A243ComCod ;
      private string A251ComDOrdCod ;
      private string A249ComRef ;
      private DateTime A1451OrdFecC ;
      private DateTime A1452OrdFecM ;
      private DateTime AV64OrdFecC ;
      private DateTime AV65OrdFecM ;
      private DateTime GXt_dtime1 ;
      private DateTime AV21FDesde ;
      private DateTime AV22FHasta ;
      private DateTime A293OrdFec ;
      private DateTime AV36OrdFec ;
      private DateTime AV46PedFec ;
      private DateTime AV66MVAFec ;
      private DateTime A25MvAFec ;
      private bool returnInSub ;
      private bool n291OrdCosCod ;
      private bool n1233MonAbr ;
      private string A1441OrdDObs ;
      private string AV35OrdDObs ;
      private string AV54TipOrden ;
      private string AV23Filename ;
      private string AV17ErrorMessage ;
      private string AV24FilenameOrigen ;
      private string AV25Filtro1 ;
      private string AV26Filtro2 ;
      private string A1466OrdTip ;
      private string AV37OrdTip ;
      private string AV18Estado ;
      private string AV14Costo ;
      private string A697ComDOrdTip ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_PrvCod ;
      private string aP1_ProdCod ;
      private int aP2_MonCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private int aP5_LinCod ;
      private short aP6_OpcPed ;
      private int aP7_TprvCod ;
      private string aP8_CosCod ;
      private string aP9_TipOrden ;
      private IDataStoreProvider pr_default ;
      private string[] P007T2_A244PrvCod ;
      private string[] P007T2_A247PrvDsc ;
      private int[] P007T3_A180MonCod ;
      private string[] P007T3_A1234MonDsc ;
      private int[] P007T4_A49UniCod ;
      private string[] P007T4_A1462OrdSts ;
      private string[] P007T4_A291OrdCosCod ;
      private bool[] P007T4_n291OrdCosCod ;
      private int[] P007T4_A298TprvCod ;
      private int[] P007T4_A52LinCod ;
      private string[] P007T4_A28ProdCod ;
      private int[] P007T4_A290OrdMonCod ;
      private DateTime[] P007T4_A293OrdFec ;
      private string[] P007T4_A244PrvCod ;
      private string[] P007T4_A1466OrdTip ;
      private string[] P007T4_A1233MonAbr ;
      private bool[] P007T4_n1233MonAbr ;
      private string[] P007T4_A247PrvDsc ;
      private string[] P007T4_A289OrdCod ;
      private string[] P007T4_A1461OrdRequ ;
      private decimal[] P007T4_A1434OrdDCanIng ;
      private decimal[] P007T4_A1432OrdDCanFac ;
      private string[] P007T4_A1997UniAbr ;
      private decimal[] P007T4_A1444OrdDTot ;
      private string[] P007T4_A1441OrdDObs ;
      private string[] P007T4_A55ProdDsc ;
      private string[] P007T4_A1469OrdUsuC ;
      private DateTime[] P007T4_A1451OrdFecC ;
      private string[] P007T4_A1470OrdUsuM ;
      private DateTime[] P007T4_A1452OrdFecM ;
      private decimal[] P007T4_A1438OrdDPre ;
      private decimal[] P007T4_A1431OrdDCan ;
      private decimal[] P007T4_A1439OrdDDscto ;
      private int[] P007T4_A295OrdDItem ;
      private string[] P007T5_A79COSCod ;
      private string[] P007T5_A761COSDsc ;
      private short[] P007T6_A1286MvATMov ;
      private string[] P007T6_A1276MvAOcom ;
      private string[] P007T6_A1370MVSts ;
      private string[] P007T6_A13MvATip ;
      private string[] P007T6_A14MvACod ;
      private DateTime[] P007T6_A25MvAFec ;
      private string[] P007T7_A149TipCod ;
      private string[] P007T7_A243ComCod ;
      private string[] P007T7_A244PrvCod ;
      private string[] P007T7_A697ComDOrdTip ;
      private string[] P007T7_A251ComDOrdCod ;
      private string[] P007T7_A249ComRef ;
      private short[] P007T7_A250ComDItem ;
      private string aP10_Filename ;
      private string aP11_ErrorMessage ;
      private ExcelDocumentI AV19ExcelDocument ;
      private GxFile AV8Archivo ;
   }

   public class r_resumenordencompraexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007T4( IGxContext context ,
                                             string AV53PrvCod ,
                                             int AV32MonCod ,
                                             string AV51ProdCod ,
                                             int AV30LinCod ,
                                             int AV60TprvCod ,
                                             string AV13CosCod ,
                                             short AV33OpcPed ,
                                             string A244PrvCod ,
                                             int A290OrdMonCod ,
                                             string A28ProdCod ,
                                             int A52LinCod ,
                                             int A298TprvCod ,
                                             string A291OrdCosCod ,
                                             string A1462OrdSts ,
                                             DateTime AV22FHasta ,
                                             DateTime A293OrdFec ,
                                             DateTime AV21FDesde )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[8];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T4.[OrdSts], T4.[OrdCosCod], T6.[TprvCod], T2.[LinCod], T1.[ProdCod], T4.[OrdMonCod] AS OrdMonCod, T4.[OrdFec], T4.[PrvCod], T4.[OrdTip], T5.[MonAbr], T6.[PrvDsc], T1.[OrdCod], T4.[OrdRequ], T1.[OrdDCanIng], T1.[OrdDCanFac], T3.[UniAbr], T1.[OrdDTot], T1.[OrdDObs], T2.[ProdDsc], T4.[OrdUsuC], T4.[OrdFecC], T4.[OrdUsuM], T4.[OrdFecM], T1.[OrdDPre], T1.[OrdDCan], T1.[OrdDDscto], T1.[OrdDItem] FROM ((((([CPORDENDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CPORDEN] T4 ON T4.[OrdCod] = T1.[OrdCod]) INNER JOIN [CMONEDAS] T5 ON T5.[MonCod] = T4.[OrdMonCod]) INNER JOIN [CPPROVEEDORES] T6 ON T6.[PrvCod] = T4.[PrvCod])";
         AddWhere(sWhereString, "(T4.[OrdFec] <= @AV22FHasta)");
         AddWhere(sWhereString, "(T4.[OrdSts] <> 'A')");
         AddWhere(sWhereString, "(T4.[OrdFec] >= @AV21FDesde)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53PrvCod)) )
         {
            AddWhere(sWhereString, "(T4.[PrvCod] = @AV53PrvCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV32MonCod) )
         {
            AddWhere(sWhereString, "(T4.[OrdMonCod] = @AV32MonCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV51ProdCod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV30LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV30LinCod)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV60TprvCod) )
         {
            AddWhere(sWhereString, "(T6.[TprvCod] = @AV60TprvCod)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CosCod)) )
         {
            AddWhere(sWhereString, "(T4.[OrdCosCod] = @AV13CosCod)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV33OpcPed == 1 )
         {
            AddWhere(sWhereString, "(T4.[OrdSts] <> 'T')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.[OrdFec] DESC";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P007T4(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] );
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
          Object[] prmP007T2;
          prmP007T2 = new Object[] {
          new ParDef("@AV53PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP007T3;
          prmP007T3 = new Object[] {
          new ParDef("@AV32MonCod",GXType.Int32,6,0)
          };
          Object[] prmP007T5;
          prmP007T5 = new Object[] {
          new ParDef("@AV34OrdCosCod",GXType.NChar,10,0)
          };
          Object[] prmP007T6;
          prmP007T6 = new Object[] {
          new ParDef("@AV41PedCod",GXType.NChar,10,0)
          };
          Object[] prmP007T7;
          prmP007T7 = new Object[] {
          new ParDef("@AV41PedCod",GXType.NChar,10,0) ,
          new ParDef("@AV37OrdTip",GXType.NVarChar,1,0)
          };
          Object[] prmP007T4;
          prmP007T4 = new Object[] {
          new ParDef("@AV22FHasta",GXType.Date,8,0) ,
          new ParDef("@AV21FDesde",GXType.Date,8,0) ,
          new ParDef("@AV53PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV32MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV51ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV30LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV60TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV13CosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007T2", "SELECT [PrvCod], [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @AV53PrvCod ORDER BY [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007T2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007T3", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV32MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007T3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007T4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007T4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007T5", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV34OrdCosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007T5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007T6", "SELECT [MvATMov], [MvAOcom], [MVSts], [MvATip], [MvACod], [MvAFec] FROM [AGUIAS] WHERE ([MvATip] = 'ING') AND (Not [MVSts] = 'A') AND ([MvAOcom] = @AV41PedCod) AND ([MvATMov] = 1) ORDER BY [MvATip] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007T6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007T7", "SELECT T1.[TipCod], T1.[ComCod], T1.[PrvCod], T1.[ComDOrdTip], T1.[ComDOrdCod], T2.[ComRef], T1.[ComDItem] FROM ([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) WHERE (T1.[ComDOrdCod] = @AV41PedCod) AND (T1.[ComDOrdTip] = @AV37OrdTip) ORDER BY T1.[TipCod], T1.[ComCod], T1.[PrvCod], T1.[ComDItem], T1.[ComDOrdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007T7,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 15);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 5);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 100);
                ((string[]) buf[14])[0] = rslt.getString(13, 10);
                ((string[]) buf[15])[0] = rslt.getString(14, 20);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(16);
                ((string[]) buf[18])[0] = rslt.getString(17, 5);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(18);
                ((string[]) buf[20])[0] = rslt.getLongVarchar(19);
                ((string[]) buf[21])[0] = rslt.getString(20, 100);
                ((string[]) buf[22])[0] = rslt.getString(21, 10);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(22);
                ((string[]) buf[24])[0] = rslt.getString(23, 10);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(24);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
                ((int[]) buf[29])[0] = rslt.getInt(28);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
