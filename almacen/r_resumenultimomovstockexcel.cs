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
namespace GeneXus.Programs.almacen {
   public class r_resumenultimomovstockexcel : GXProcedure
   {
      public r_resumenultimomovstockexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenultimomovstockexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SubLCod ,
                           ref int aP2_FamCod ,
                           ref string aP3_Prodcod ,
                           ref DateTime aP4_FDesde ,
                           ref short aP5_nOrden ,
                           ref int aP6_AlmCod ,
                           ref string aP7_TipInforme ,
                           ref int aP8_MovCod ,
                           out string aP9_Filename ,
                           out string aP10_ErrorMessage )
      {
         this.AV62LinCod = aP0_LinCod;
         this.AV88SubLCod = aP1_SubLCod;
         this.AV34FamCod = aP2_FamCod;
         this.AV77Prodcod = aP3_Prodcod;
         this.AV35FDesde = aP4_FDesde;
         this.AV73nOrden = aP5_nOrden;
         this.AV8AlmCod = aP6_AlmCod;
         this.AV93TipInforme = aP7_TipInforme;
         this.AV66MovCod = aP8_MovCod;
         this.AV39Filename = "" ;
         this.AV32ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV62LinCod;
         aP1_SubLCod=this.AV88SubLCod;
         aP2_FamCod=this.AV34FamCod;
         aP3_Prodcod=this.AV77Prodcod;
         aP4_FDesde=this.AV35FDesde;
         aP5_nOrden=this.AV73nOrden;
         aP6_AlmCod=this.AV8AlmCod;
         aP7_TipInforme=this.AV93TipInforme;
         aP8_MovCod=this.AV66MovCod;
         aP9_Filename=this.AV39Filename;
         aP10_ErrorMessage=this.AV32ErrorMessage;
      }

      public string executeUdp( ref int aP0_LinCod ,
                                ref int aP1_SubLCod ,
                                ref int aP2_FamCod ,
                                ref string aP3_Prodcod ,
                                ref DateTime aP4_FDesde ,
                                ref short aP5_nOrden ,
                                ref int aP6_AlmCod ,
                                ref string aP7_TipInforme ,
                                ref int aP8_MovCod ,
                                out string aP9_Filename )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_FamCod, ref aP3_Prodcod, ref aP4_FDesde, ref aP5_nOrden, ref aP6_AlmCod, ref aP7_TipInforme, ref aP8_MovCod, out aP9_Filename, out aP10_ErrorMessage);
         return AV32ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref int aP2_FamCod ,
                                 ref string aP3_Prodcod ,
                                 ref DateTime aP4_FDesde ,
                                 ref short aP5_nOrden ,
                                 ref int aP6_AlmCod ,
                                 ref string aP7_TipInforme ,
                                 ref int aP8_MovCod ,
                                 out string aP9_Filename ,
                                 out string aP10_ErrorMessage )
      {
         r_resumenultimomovstockexcel objr_resumenultimomovstockexcel;
         objr_resumenultimomovstockexcel = new r_resumenultimomovstockexcel();
         objr_resumenultimomovstockexcel.AV62LinCod = aP0_LinCod;
         objr_resumenultimomovstockexcel.AV88SubLCod = aP1_SubLCod;
         objr_resumenultimomovstockexcel.AV34FamCod = aP2_FamCod;
         objr_resumenultimomovstockexcel.AV77Prodcod = aP3_Prodcod;
         objr_resumenultimomovstockexcel.AV35FDesde = aP4_FDesde;
         objr_resumenultimomovstockexcel.AV73nOrden = aP5_nOrden;
         objr_resumenultimomovstockexcel.AV8AlmCod = aP6_AlmCod;
         objr_resumenultimomovstockexcel.AV93TipInforme = aP7_TipInforme;
         objr_resumenultimomovstockexcel.AV66MovCod = aP8_MovCod;
         objr_resumenultimomovstockexcel.AV39Filename = "" ;
         objr_resumenultimomovstockexcel.AV32ErrorMessage = "" ;
         objr_resumenultimomovstockexcel.context.SetSubmitInitialConfig(context);
         objr_resumenultimomovstockexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenultimomovstockexcel);
         aP0_LinCod=this.AV62LinCod;
         aP1_SubLCod=this.AV88SubLCod;
         aP2_FamCod=this.AV34FamCod;
         aP3_Prodcod=this.AV77Prodcod;
         aP4_FDesde=this.AV35FDesde;
         aP5_nOrden=this.AV73nOrden;
         aP6_AlmCod=this.AV8AlmCod;
         aP7_TipInforme=this.AV93TipInforme;
         aP8_MovCod=this.AV66MovCod;
         aP9_Filename=this.AV39Filename;
         aP10_ErrorMessage=this.AV32ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenultimomovstockexcel)stateInfo).executePrivate();
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
         AV12Archivo.Source = "Excel/PlantillasUltimoMovStock.xlsx";
         AV75Path = AV12Archivo.GetPath();
         AV40FilenameOrigen = StringUtil.Trim( AV75Path) + "\\PlantillasUltimoMovStock.xlsx";
         AV39Filename = "Excel/UltimoMovStock" + ".xlsx";
         AV33ExcelDocument.Clear();
         AV33ExcelDocument.Template = AV40FilenameOrigen;
         AV33ExcelDocument.Open(AV39Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13CellRow = 5;
         AV41FirstColumn = 1;
         AV58Item = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV62LinCod ,
                                              AV88SubLCod ,
                                              AV34FamCod ,
                                              AV77Prodcod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A28ProdCod ,
                                              A1880StkAct ,
                                              AV8AlmCod ,
                                              A63AlmCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor P008U2 */
         pr_default.execute(0, new Object[] {AV8AlmCod, AV62LinCod, AV88SubLCod, AV34FamCod, AV77Prodcod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1880StkAct = P008U2_A1880StkAct[0];
            A63AlmCod = P008U2_A63AlmCod[0];
            A28ProdCod = P008U2_A28ProdCod[0];
            A50FamCod = P008U2_A50FamCod[0];
            n50FamCod = P008U2_n50FamCod[0];
            A51SublCod = P008U2_A51SublCod[0];
            n51SublCod = P008U2_n51SublCod[0];
            A52LinCod = P008U2_A52LinCod[0];
            A55ProdDsc = P008U2_A55ProdDsc[0];
            A1881StkIng = P008U2_A1881StkIng[0];
            A1882StkSal = P008U2_A1882StkSal[0];
            A50FamCod = P008U2_A50FamCod[0];
            n50FamCod = P008U2_n50FamCod[0];
            A51SublCod = P008U2_A51SublCod[0];
            n51SublCod = P008U2_n51SublCod[0];
            A52LinCod = P008U2_A52LinCod[0];
            A55ProdDsc = P008U2_A55ProdDsc[0];
            AV77Prodcod = A28ProdCod;
            AV79ProdDsc = A55ProdDsc;
            AV84StkAct = A1880StkAct;
            AV36Fecha = DateTime.MinValue;
            AV68MVATip = "";
            AV18ComCod = "";
            AV67MovDsc = "";
            AV76Precio = 0.00m;
            AV101Total = 0.00m;
            /* Execute user subroutine: 'VALIDADOCUMENTOS' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'DETALLES' */
            S131 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV58Item = (long)(AV58Item+1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV33ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV33ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'VALIDADOCUMENTOS' Routine */
         returnInSub = false;
         AV42Flag = 0;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV66MovCod ,
                                              AV93TipInforme ,
                                              A22MvAMov ,
                                              A1286MvATMov ,
                                              A13MvATip ,
                                              A1370MVSts ,
                                              A21MvAlm ,
                                              AV8AlmCod ,
                                              A28ProdCod ,
                                              AV77Prodcod ,
                                              AV35FDesde } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE
                                              }
         });
         /* Using cursor P008U3 */
         pr_default.execute(1, new Object[] {AV35FDesde, AV8AlmCod, AV77Prodcod, AV66MovCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A21MvAlm = P008U3_A21MvAlm[0];
            A28ProdCod = P008U3_A28ProdCod[0];
            A13MvATip = P008U3_A13MvATip[0];
            A1286MvATMov = P008U3_A1286MvATMov[0];
            A22MvAMov = P008U3_A22MvAMov[0];
            A25MvAFec = P008U3_A25MvAFec[0];
            A1370MVSts = P008U3_A1370MVSts[0];
            A14MvACod = P008U3_A14MvACod[0];
            A1274MvAMovDsc = P008U3_A1274MvAMovDsc[0];
            A1250MVADPrecio = P008U3_A1250MVADPrecio[0];
            A1249MVADCosto = P008U3_A1249MVADCosto[0];
            A30MvADItem = P008U3_A30MvADItem[0];
            A21MvAlm = P008U3_A21MvAlm[0];
            A1286MvATMov = P008U3_A1286MvATMov[0];
            A22MvAMov = P008U3_A22MvAMov[0];
            A25MvAFec = P008U3_A25MvAFec[0];
            A1370MVSts = P008U3_A1370MVSts[0];
            A1274MvAMovDsc = P008U3_A1274MvAMovDsc[0];
            AV18ComCod = A14MvACod;
            AV36Fecha = A25MvAFec;
            AV68MVATip = A13MvATip;
            AV67MovDsc = StringUtil.Trim( A1274MvAMovDsc);
            AV76Precio = A1250MVADPrecio;
            AV101Total = A1249MVADCosto;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV33ExcelDocument.ErrCode != 0 )
         {
            AV39Filename = "";
            AV32ErrorMessage = AV33ExcelDocument.ErrDescription;
            AV33ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S131( )
      {
         /* 'DETALLES' Routine */
         returnInSub = false;
         AV33ExcelDocument.get_Cells(AV13CellRow, AV41FirstColumn+0, 1, 1).Number = AV58Item;
         AV33ExcelDocument.get_Cells(AV13CellRow, AV41FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV77Prodcod);
         AV33ExcelDocument.get_Cells(AV13CellRow, AV41FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV79ProdDsc);
         AV33ExcelDocument.get_Cells(AV13CellRow, AV41FirstColumn+3, 1, 1).Number = (double)(AV84StkAct);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV36Fecha ) ;
         AV33ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV33ExcelDocument.get_Cells(AV13CellRow, AV41FirstColumn+4, 1, 1).Date = GXt_dtime1;
         AV33ExcelDocument.get_Cells(AV13CellRow, AV41FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV68MVATip);
         AV33ExcelDocument.get_Cells(AV13CellRow, AV41FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV18ComCod);
         AV33ExcelDocument.get_Cells(AV13CellRow, AV41FirstColumn+7, 1, 1).Number = (double)(AV76Precio);
         AV33ExcelDocument.get_Cells(AV13CellRow, AV41FirstColumn+8, 1, 1).Number = (double)(AV101Total);
         AV33ExcelDocument.get_Cells(AV13CellRow, AV41FirstColumn+9, 1, 1).Text = StringUtil.Trim( AV67MovDsc);
         AV13CellRow = (int)(AV13CellRow+1);
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
         AV39Filename = "";
         AV32ErrorMessage = "";
         AV12Archivo = new GxFile(context.GetPhysicalPath());
         AV75Path = "";
         AV40FilenameOrigen = "";
         AV33ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         A28ProdCod = "";
         P008U2_A1880StkAct = new decimal[1] ;
         P008U2_A63AlmCod = new int[1] ;
         P008U2_A28ProdCod = new string[] {""} ;
         P008U2_A50FamCod = new int[1] ;
         P008U2_n50FamCod = new bool[] {false} ;
         P008U2_A51SublCod = new int[1] ;
         P008U2_n51SublCod = new bool[] {false} ;
         P008U2_A52LinCod = new int[1] ;
         P008U2_A55ProdDsc = new string[] {""} ;
         P008U2_A1881StkIng = new decimal[1] ;
         P008U2_A1882StkSal = new decimal[1] ;
         A55ProdDsc = "";
         AV79ProdDsc = "";
         AV36Fecha = DateTime.MinValue;
         AV68MVATip = "";
         AV18ComCod = "";
         AV67MovDsc = "";
         A13MvATip = "";
         A1370MVSts = "";
         P008U3_A21MvAlm = new int[1] ;
         P008U3_A28ProdCod = new string[] {""} ;
         P008U3_A13MvATip = new string[] {""} ;
         P008U3_A1286MvATMov = new short[1] ;
         P008U3_A22MvAMov = new int[1] ;
         P008U3_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008U3_A1370MVSts = new string[] {""} ;
         P008U3_A14MvACod = new string[] {""} ;
         P008U3_A1274MvAMovDsc = new string[] {""} ;
         P008U3_A1250MVADPrecio = new decimal[1] ;
         P008U3_A1249MVADCosto = new decimal[1] ;
         P008U3_A30MvADItem = new int[1] ;
         A25MvAFec = DateTime.MinValue;
         A14MvACod = "";
         A1274MvAMovDsc = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_resumenultimomovstockexcel__default(),
            new Object[][] {
                new Object[] {
               P008U2_A1880StkAct, P008U2_A63AlmCod, P008U2_A28ProdCod, P008U2_A50FamCod, P008U2_n50FamCod, P008U2_A51SublCod, P008U2_n51SublCod, P008U2_A52LinCod, P008U2_A55ProdDsc, P008U2_A1881StkIng,
               P008U2_A1882StkSal
               }
               , new Object[] {
               P008U3_A21MvAlm, P008U3_A28ProdCod, P008U3_A13MvATip, P008U3_A1286MvATMov, P008U3_A22MvAMov, P008U3_A25MvAFec, P008U3_A1370MVSts, P008U3_A14MvACod, P008U3_A1274MvAMovDsc, P008U3_A1250MVADPrecio,
               P008U3_A1249MVADCosto, P008U3_A30MvADItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV73nOrden ;
      private short AV42Flag ;
      private short A1286MvATMov ;
      private int AV62LinCod ;
      private int AV88SubLCod ;
      private int AV34FamCod ;
      private int AV8AlmCod ;
      private int AV66MovCod ;
      private int AV13CellRow ;
      private int AV41FirstColumn ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A63AlmCod ;
      private int A22MvAMov ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private long AV58Item ;
      private decimal A1880StkAct ;
      private decimal A1881StkIng ;
      private decimal A1882StkSal ;
      private decimal AV84StkAct ;
      private decimal AV76Precio ;
      private decimal AV101Total ;
      private decimal A1250MVADPrecio ;
      private decimal A1249MVADCosto ;
      private string AV77Prodcod ;
      private string AV93TipInforme ;
      private string AV75Path ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string AV79ProdDsc ;
      private string AV68MVATip ;
      private string AV18ComCod ;
      private string AV67MovDsc ;
      private string A13MvATip ;
      private string A1370MVSts ;
      private string A14MvACod ;
      private string A1274MvAMovDsc ;
      private DateTime GXt_dtime1 ;
      private DateTime AV35FDesde ;
      private DateTime AV36Fecha ;
      private DateTime A25MvAFec ;
      private bool returnInSub ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private string AV39Filename ;
      private string AV32ErrorMessage ;
      private string AV40FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private int aP2_FamCod ;
      private string aP3_Prodcod ;
      private DateTime aP4_FDesde ;
      private short aP5_nOrden ;
      private int aP6_AlmCod ;
      private string aP7_TipInforme ;
      private int aP8_MovCod ;
      private IDataStoreProvider pr_default ;
      private decimal[] P008U2_A1880StkAct ;
      private int[] P008U2_A63AlmCod ;
      private string[] P008U2_A28ProdCod ;
      private int[] P008U2_A50FamCod ;
      private bool[] P008U2_n50FamCod ;
      private int[] P008U2_A51SublCod ;
      private bool[] P008U2_n51SublCod ;
      private int[] P008U2_A52LinCod ;
      private string[] P008U2_A55ProdDsc ;
      private decimal[] P008U2_A1881StkIng ;
      private decimal[] P008U2_A1882StkSal ;
      private int[] P008U3_A21MvAlm ;
      private string[] P008U3_A28ProdCod ;
      private string[] P008U3_A13MvATip ;
      private short[] P008U3_A1286MvATMov ;
      private int[] P008U3_A22MvAMov ;
      private DateTime[] P008U3_A25MvAFec ;
      private string[] P008U3_A1370MVSts ;
      private string[] P008U3_A14MvACod ;
      private string[] P008U3_A1274MvAMovDsc ;
      private decimal[] P008U3_A1250MVADPrecio ;
      private decimal[] P008U3_A1249MVADCosto ;
      private int[] P008U3_A30MvADItem ;
      private string aP9_Filename ;
      private string aP10_ErrorMessage ;
      private ExcelDocumentI AV33ExcelDocument ;
      private GxFile AV12Archivo ;
   }

   public class r_resumenultimomovstockexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008U2( IGxContext context ,
                                             int AV62LinCod ,
                                             int AV88SubLCod ,
                                             int AV34FamCod ,
                                             string AV77Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             decimal A1880StkAct ,
                                             int AV8AlmCod ,
                                             int A63AlmCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[StkIng] - T1.[StkSal] AS StkAct, T1.[AlmCod], T1.[ProdCod], T2.[FamCod], T2.[SublCod], T2.[LinCod], T2.[ProdDsc], T1.[StkIng], T1.[StkSal] FROM ([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod])";
         AddWhere(sWhereString, "(T1.[AlmCod] = @AV8AlmCod)");
         AddWhere(sWhereString, "(T1.[StkIng] - T1.[StkSal] <> 0)");
         if ( ! (0==AV62LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV62LinCod)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV88SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV88SubLCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV34FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV34FamCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV77Prodcod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[AlmCod], T1.[ProdCod]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P008U3( IGxContext context ,
                                             int AV66MovCod ,
                                             string AV93TipInforme ,
                                             int A22MvAMov ,
                                             short A1286MvATMov ,
                                             string A13MvATip ,
                                             string A1370MVSts ,
                                             int A21MvAlm ,
                                             int AV8AlmCod ,
                                             string A28ProdCod ,
                                             string AV77Prodcod ,
                                             DateTime AV35FDesde )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT TOP 1 T2.[MvAlm], T1.[ProdCod], T1.[MvATip], T2.[MvATMov], T2.[MvAMov] AS MvAMov, T2.[MvAFec], T2.[MVSts], T1.[MvACod], T3.[MovDsc] AS MvAMovDsc, T1.[MVADPrecio], T1.[MVADCosto], T1.[MvADItem] FROM (([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T3 ON T3.[MovCod] = T2.[MvAMov])";
         AddWhere(sWhereString, "(T2.[MvAFec] <= @AV35FDesde)");
         AddWhere(sWhereString, "(T2.[MVSts] <> 'A')");
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV8AlmCod)");
         AddWhere(sWhereString, "(T1.[ProdCod] = @AV77Prodcod)");
         if ( ! (0==AV66MovCod) )
         {
            AddWhere(sWhereString, "(T2.[MvAMov] = @AV66MovCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV93TipInforme, "C") == 0 )
         {
            AddWhere(sWhereString, "(T2.[MvATMov] = 1)");
         }
         if ( StringUtil.StrCmp(AV93TipInforme, "C") == 0 )
         {
            AddWhere(sWhereString, "(T1.[MvATip] = 'ING')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[MvAFec] DESC";
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
                     return conditional_P008U2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
               case 1 :
                     return conditional_P008U3(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008U2;
          prmP008U2 = new Object[] {
          new ParDef("@AV8AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV62LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV88SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV34FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV77Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP008U3;
          prmP008U3 = new Object[] {
          new ParDef("@AV35FDesde",GXType.Date,8,0) ,
          new ParDef("@AV8AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV77Prodcod",GXType.NChar,15,0) ,
          new ParDef("@AV66MovCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008U2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008U3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008U3,1, GxCacheFrequency.OFF ,false,true )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 100);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 1);
                ((string[]) buf[7])[0] = rslt.getString(8, 12);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((int[]) buf[11])[0] = rslt.getInt(12);
                return;
       }
    }

 }

}
