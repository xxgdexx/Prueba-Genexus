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
   public class r_stockactualconsolidadoexcel : GXProcedure
   {
      public r_stockactualconsolidadoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_stockactualconsolidadoexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SubLCod ,
                           ref int aP2_FamCod ,
                           ref int aP3_AlmCod ,
                           ref string aP4_Prodcod ,
                           ref short aP5_nOrden ,
                           ref DateTime aP6_FDesde ,
                           out string aP7_Filename ,
                           out string aP8_ErrorMessage )
      {
         this.AV77LinCod = aP0_LinCod;
         this.AV78SubLCod = aP1_SubLCod;
         this.AV79FamCod = aP2_FamCod;
         this.AV80AlmCod = aP3_AlmCod;
         this.AV81Prodcod = aP4_Prodcod;
         this.AV83nOrden = aP5_nOrden;
         this.AV82FDesde = aP6_FDesde;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV77LinCod;
         aP1_SubLCod=this.AV78SubLCod;
         aP2_FamCod=this.AV79FamCod;
         aP3_AlmCod=this.AV80AlmCod;
         aP4_Prodcod=this.AV81Prodcod;
         aP5_nOrden=this.AV83nOrden;
         aP6_FDesde=this.AV82FDesde;
         aP7_Filename=this.AV10Filename;
         aP8_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref int aP0_LinCod ,
                                ref int aP1_SubLCod ,
                                ref int aP2_FamCod ,
                                ref int aP3_AlmCod ,
                                ref string aP4_Prodcod ,
                                ref short aP5_nOrden ,
                                ref DateTime aP6_FDesde ,
                                out string aP7_Filename )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_FamCod, ref aP3_AlmCod, ref aP4_Prodcod, ref aP5_nOrden, ref aP6_FDesde, out aP7_Filename, out aP8_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCod ,
                                 ref string aP4_Prodcod ,
                                 ref short aP5_nOrden ,
                                 ref DateTime aP6_FDesde ,
                                 out string aP7_Filename ,
                                 out string aP8_ErrorMessage )
      {
         r_stockactualconsolidadoexcel objr_stockactualconsolidadoexcel;
         objr_stockactualconsolidadoexcel = new r_stockactualconsolidadoexcel();
         objr_stockactualconsolidadoexcel.AV77LinCod = aP0_LinCod;
         objr_stockactualconsolidadoexcel.AV78SubLCod = aP1_SubLCod;
         objr_stockactualconsolidadoexcel.AV79FamCod = aP2_FamCod;
         objr_stockactualconsolidadoexcel.AV80AlmCod = aP3_AlmCod;
         objr_stockactualconsolidadoexcel.AV81Prodcod = aP4_Prodcod;
         objr_stockactualconsolidadoexcel.AV83nOrden = aP5_nOrden;
         objr_stockactualconsolidadoexcel.AV82FDesde = aP6_FDesde;
         objr_stockactualconsolidadoexcel.AV10Filename = "" ;
         objr_stockactualconsolidadoexcel.AV11ErrorMessage = "" ;
         objr_stockactualconsolidadoexcel.context.SetSubmitInitialConfig(context);
         objr_stockactualconsolidadoexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_stockactualconsolidadoexcel);
         aP0_LinCod=this.AV77LinCod;
         aP1_SubLCod=this.AV78SubLCod;
         aP2_FamCod=this.AV79FamCod;
         aP3_AlmCod=this.AV80AlmCod;
         aP4_Prodcod=this.AV81Prodcod;
         aP5_nOrden=this.AV83nOrden;
         aP6_FDesde=this.AV82FDesde;
         aP7_Filename=this.AV10Filename;
         aP8_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_stockactualconsolidadoexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasStockConsolidado.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasStockConsolidado.xlsx";
         AV10Filename = "Excel/StockConsolidado" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV70FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV115AlmCodItem = 0;
         AV114Almacen = "";
         AV15FirstColumn = 6;
         AV13ExcelDocument.get_Cells(4, 5, 1, 1).Text = "Referencia";
         AV113i = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV80AlmCod ,
                                              AV77LinCod ,
                                              AV78SubLCod ,
                                              AV79FamCod ,
                                              AV81Prodcod ,
                                              A63AlmCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A28ProdCod ,
                                              A438AlmSts ,
                                              A1158LinStk } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P007P2 */
         pr_default.execute(0, new Object[] {AV80AlmCod, AV77LinCod, AV78SubLCod, AV79FamCod, AV81Prodcod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7P2 = false;
            A28ProdCod = P007P2_A28ProdCod[0];
            A63AlmCod = P007P2_A63AlmCod[0];
            A1158LinStk = P007P2_A1158LinStk[0];
            A438AlmSts = P007P2_A438AlmSts[0];
            A50FamCod = P007P2_A50FamCod[0];
            n50FamCod = P007P2_n50FamCod[0];
            A51SublCod = P007P2_A51SublCod[0];
            n51SublCod = P007P2_n51SublCod[0];
            A52LinCod = P007P2_A52LinCod[0];
            A433AlmAbr = P007P2_A433AlmAbr[0];
            A50FamCod = P007P2_A50FamCod[0];
            n50FamCod = P007P2_n50FamCod[0];
            A51SublCod = P007P2_A51SublCod[0];
            n51SublCod = P007P2_n51SublCod[0];
            A52LinCod = P007P2_A52LinCod[0];
            A1158LinStk = P007P2_A1158LinStk[0];
            A438AlmSts = P007P2_A438AlmSts[0];
            A433AlmAbr = P007P2_A433AlmAbr[0];
            while ( (pr_default.getStatus(0) != 101) && ( P007P2_A63AlmCod[0] == A63AlmCod ) )
            {
               BRK7P2 = false;
               A28ProdCod = P007P2_A28ProdCod[0];
               BRK7P2 = true;
               pr_default.readNext(0);
            }
            AV115AlmCodItem = A63AlmCod;
            AV114Almacen = StringUtil.Trim( A433AlmAbr);
            AV13ExcelDocument.get_Cells(4, AV15FirstColumn, 1, 1).Text = StringUtil.Trim( AV114Almacen);
            AV15FirstColumn = (int)(AV15FirstColumn+1);
            if ( ! BRK7P2 )
            {
               BRK7P2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV13ExcelDocument.get_Cells(4, AV15FirstColumn, 1, 1).Text = "Totales";
         /* Execute user subroutine: 'PRODUCTOS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV13ExcelDocument.ErrCode != 0 )
         {
            AV10Filename = "";
            AV11ErrorMessage = AV13ExcelDocument.ErrDescription;
            AV13ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'PRODUCTOS' Routine */
         returnInSub = false;
         AV14CellRow = 5;
         AV84ITemProd = 1;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV77LinCod ,
                                              AV78SubLCod ,
                                              AV79FamCod ,
                                              AV81Prodcod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A28ProdCod ,
                                              A1880StkAct ,
                                              A1158LinStk } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P007P3 */
         pr_default.execute(1, new Object[] {AV77LinCod, AV78SubLCod, AV79FamCod, AV81Prodcod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7P4 = false;
            A49UniCod = P007P3_A49UniCod[0];
            A55ProdDsc = P007P3_A55ProdDsc[0];
            A28ProdCod = P007P3_A28ProdCod[0];
            A1880StkAct = P007P3_A1880StkAct[0];
            A1158LinStk = P007P3_A1158LinStk[0];
            A50FamCod = P007P3_A50FamCod[0];
            n50FamCod = P007P3_n50FamCod[0];
            A51SublCod = P007P3_A51SublCod[0];
            n51SublCod = P007P3_n51SublCod[0];
            A52LinCod = P007P3_A52LinCod[0];
            A1997UniAbr = P007P3_A1997UniAbr[0];
            A1705ProdRef1 = P007P3_A1705ProdRef1[0];
            A1881StkIng = P007P3_A1881StkIng[0];
            A1882StkSal = P007P3_A1882StkSal[0];
            A63AlmCod = P007P3_A63AlmCod[0];
            A49UniCod = P007P3_A49UniCod[0];
            A55ProdDsc = P007P3_A55ProdDsc[0];
            A50FamCod = P007P3_A50FamCod[0];
            n50FamCod = P007P3_n50FamCod[0];
            A51SublCod = P007P3_A51SublCod[0];
            n51SublCod = P007P3_n51SublCod[0];
            A52LinCod = P007P3_A52LinCod[0];
            A1705ProdRef1 = P007P3_A1705ProdRef1[0];
            A1997UniAbr = P007P3_A1997UniAbr[0];
            A1158LinStk = P007P3_A1158LinStk[0];
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007P3_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRK7P4 = false;
               A55ProdDsc = P007P3_A55ProdDsc[0];
               A63AlmCod = P007P3_A63AlmCod[0];
               A55ProdDsc = P007P3_A55ProdDsc[0];
               BRK7P4 = true;
               pr_default.readNext(1);
            }
            AV89Codigo = A28ProdCod;
            AV90Producto = A55ProdDsc;
            AV112UniAbr = A1997UniAbr;
            AV117ProdRef1 = StringUtil.Trim( A1705ProdRef1);
            AV119Flag = 0;
            AV13ExcelDocument.get_Cells(AV14CellRow, 1, 1, 1).Number = AV84ITemProd;
            AV13ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Text = StringUtil.Trim( AV89Codigo);
            AV13ExcelDocument.get_Cells(AV14CellRow, 3, 1, 1).Text = StringUtil.Trim( AV90Producto);
            AV13ExcelDocument.get_Cells(AV14CellRow, 4, 1, 1).Text = StringUtil.Trim( AV112UniAbr);
            AV13ExcelDocument.get_Cells(AV14CellRow, 5, 1, 1).Text = StringUtil.Trim( AV117ProdRef1);
            /* Execute user subroutine: 'ALMACEN' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV14CellRow = (int)(AV14CellRow+1);
            AV84ITemProd = (long)(AV84ITemProd+1);
            if ( ! BRK7P4 )
            {
               BRK7P4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S134( )
      {
         /* 'ALMACEN' Routine */
         returnInSub = false;
         AV15FirstColumn = 6;
         AV118Total = 0.00m;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV80AlmCod ,
                                              AV77LinCod ,
                                              AV78SubLCod ,
                                              AV79FamCod ,
                                              AV81Prodcod ,
                                              A63AlmCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A28ProdCod ,
                                              A1158LinStk ,
                                              A438AlmSts } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P007P4 */
         pr_default.execute(2, new Object[] {AV80AlmCod, AV77LinCod, AV78SubLCod, AV79FamCod, AV81Prodcod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7P6 = false;
            A28ProdCod = P007P4_A28ProdCod[0];
            A63AlmCod = P007P4_A63AlmCod[0];
            A438AlmSts = P007P4_A438AlmSts[0];
            A1158LinStk = P007P4_A1158LinStk[0];
            A50FamCod = P007P4_A50FamCod[0];
            n50FamCod = P007P4_n50FamCod[0];
            A51SublCod = P007P4_A51SublCod[0];
            n51SublCod = P007P4_n51SublCod[0];
            A52LinCod = P007P4_A52LinCod[0];
            A433AlmAbr = P007P4_A433AlmAbr[0];
            A50FamCod = P007P4_A50FamCod[0];
            n50FamCod = P007P4_n50FamCod[0];
            A51SublCod = P007P4_A51SublCod[0];
            n51SublCod = P007P4_n51SublCod[0];
            A52LinCod = P007P4_A52LinCod[0];
            A1158LinStk = P007P4_A1158LinStk[0];
            A438AlmSts = P007P4_A438AlmSts[0];
            A433AlmAbr = P007P4_A433AlmAbr[0];
            while ( (pr_default.getStatus(2) != 101) && ( P007P4_A63AlmCod[0] == A63AlmCod ) )
            {
               BRK7P6 = false;
               A28ProdCod = P007P4_A28ProdCod[0];
               BRK7P6 = true;
               pr_default.readNext(2);
            }
            AV115AlmCodItem = A63AlmCod;
            AV114Almacen = StringUtil.Trim( A433AlmAbr);
            new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV89Codigo, ref  AV115AlmCodItem, ref  AV82FDesde, out  AV86StkIng, out  AV85StkSal, out  AV116Stock) ;
            AV118Total = (decimal)(AV118Total+AV116Stock);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Number = (double)(AV116Stock);
            AV15FirstColumn = (int)(AV15FirstColumn+1);
            if ( ! BRK7P6 )
            {
               BRK7P6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Number = (double)(AV118Total);
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
         AV10Filename = "";
         AV11ErrorMessage = "";
         AV72Archivo = new GxFile(context.GetPhysicalPath());
         AV71Path = "";
         AV70FilenameOrigen = "";
         AV13ExcelDocument = new ExcelDocumentI();
         AV114Almacen = "";
         scmdbuf = "";
         A28ProdCod = "";
         P007P2_A28ProdCod = new string[] {""} ;
         P007P2_A63AlmCod = new int[1] ;
         P007P2_A1158LinStk = new short[1] ;
         P007P2_A438AlmSts = new short[1] ;
         P007P2_A50FamCod = new int[1] ;
         P007P2_n50FamCod = new bool[] {false} ;
         P007P2_A51SublCod = new int[1] ;
         P007P2_n51SublCod = new bool[] {false} ;
         P007P2_A52LinCod = new int[1] ;
         P007P2_A433AlmAbr = new string[] {""} ;
         A433AlmAbr = "";
         P007P3_A49UniCod = new int[1] ;
         P007P3_A55ProdDsc = new string[] {""} ;
         P007P3_A28ProdCod = new string[] {""} ;
         P007P3_A1880StkAct = new decimal[1] ;
         P007P3_A1158LinStk = new short[1] ;
         P007P3_A50FamCod = new int[1] ;
         P007P3_n50FamCod = new bool[] {false} ;
         P007P3_A51SublCod = new int[1] ;
         P007P3_n51SublCod = new bool[] {false} ;
         P007P3_A52LinCod = new int[1] ;
         P007P3_A1997UniAbr = new string[] {""} ;
         P007P3_A1705ProdRef1 = new string[] {""} ;
         P007P3_A1881StkIng = new decimal[1] ;
         P007P3_A1882StkSal = new decimal[1] ;
         P007P3_A63AlmCod = new int[1] ;
         A55ProdDsc = "";
         A1997UniAbr = "";
         A1705ProdRef1 = "";
         AV89Codigo = "";
         AV90Producto = "";
         AV112UniAbr = "";
         AV117ProdRef1 = "";
         P007P4_A28ProdCod = new string[] {""} ;
         P007P4_A63AlmCod = new int[1] ;
         P007P4_A438AlmSts = new short[1] ;
         P007P4_A1158LinStk = new short[1] ;
         P007P4_A50FamCod = new int[1] ;
         P007P4_n50FamCod = new bool[] {false} ;
         P007P4_A51SublCod = new int[1] ;
         P007P4_n51SublCod = new bool[] {false} ;
         P007P4_A52LinCod = new int[1] ;
         P007P4_A433AlmAbr = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_stockactualconsolidadoexcel__default(),
            new Object[][] {
                new Object[] {
               P007P2_A28ProdCod, P007P2_A63AlmCod, P007P2_A1158LinStk, P007P2_A438AlmSts, P007P2_A50FamCod, P007P2_n50FamCod, P007P2_A51SublCod, P007P2_n51SublCod, P007P2_A52LinCod, P007P2_A433AlmAbr
               }
               , new Object[] {
               P007P3_A49UniCod, P007P3_A55ProdDsc, P007P3_A28ProdCod, P007P3_A1880StkAct, P007P3_A1158LinStk, P007P3_A50FamCod, P007P3_n50FamCod, P007P3_A51SublCod, P007P3_n51SublCod, P007P3_A52LinCod,
               P007P3_A1997UniAbr, P007P3_A1705ProdRef1, P007P3_A1881StkIng, P007P3_A1882StkSal, P007P3_A63AlmCod
               }
               , new Object[] {
               P007P4_A28ProdCod, P007P4_A63AlmCod, P007P4_A438AlmSts, P007P4_A1158LinStk, P007P4_A50FamCod, P007P4_n50FamCod, P007P4_A51SublCod, P007P4_n51SublCod, P007P4_A52LinCod, P007P4_A433AlmAbr
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV83nOrden ;
      private short A438AlmSts ;
      private short A1158LinStk ;
      private short AV119Flag ;
      private int AV77LinCod ;
      private int AV78SubLCod ;
      private int AV79FamCod ;
      private int AV80AlmCod ;
      private int AV115AlmCodItem ;
      private int AV15FirstColumn ;
      private int A63AlmCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int AV14CellRow ;
      private int A49UniCod ;
      private long AV113i ;
      private long AV84ITemProd ;
      private decimal A1880StkAct ;
      private decimal A1881StkIng ;
      private decimal A1882StkSal ;
      private decimal AV118Total ;
      private decimal AV86StkIng ;
      private decimal AV85StkSal ;
      private decimal AV116Stock ;
      private string AV81Prodcod ;
      private string AV71Path ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A433AlmAbr ;
      private string A55ProdDsc ;
      private string A1997UniAbr ;
      private string A1705ProdRef1 ;
      private string AV89Codigo ;
      private string AV90Producto ;
      private string AV112UniAbr ;
      private string AV117ProdRef1 ;
      private DateTime AV82FDesde ;
      private bool returnInSub ;
      private bool BRK7P2 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool BRK7P4 ;
      private bool BRK7P6 ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private string AV114Almacen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private int aP2_FamCod ;
      private int aP3_AlmCod ;
      private string aP4_Prodcod ;
      private short aP5_nOrden ;
      private DateTime aP6_FDesde ;
      private IDataStoreProvider pr_default ;
      private string[] P007P2_A28ProdCod ;
      private int[] P007P2_A63AlmCod ;
      private short[] P007P2_A1158LinStk ;
      private short[] P007P2_A438AlmSts ;
      private int[] P007P2_A50FamCod ;
      private bool[] P007P2_n50FamCod ;
      private int[] P007P2_A51SublCod ;
      private bool[] P007P2_n51SublCod ;
      private int[] P007P2_A52LinCod ;
      private string[] P007P2_A433AlmAbr ;
      private int[] P007P3_A49UniCod ;
      private string[] P007P3_A55ProdDsc ;
      private string[] P007P3_A28ProdCod ;
      private decimal[] P007P3_A1880StkAct ;
      private short[] P007P3_A1158LinStk ;
      private int[] P007P3_A50FamCod ;
      private bool[] P007P3_n50FamCod ;
      private int[] P007P3_A51SublCod ;
      private bool[] P007P3_n51SublCod ;
      private int[] P007P3_A52LinCod ;
      private string[] P007P3_A1997UniAbr ;
      private string[] P007P3_A1705ProdRef1 ;
      private decimal[] P007P3_A1881StkIng ;
      private decimal[] P007P3_A1882StkSal ;
      private int[] P007P3_A63AlmCod ;
      private string[] P007P4_A28ProdCod ;
      private int[] P007P4_A63AlmCod ;
      private short[] P007P4_A438AlmSts ;
      private short[] P007P4_A1158LinStk ;
      private int[] P007P4_A50FamCod ;
      private bool[] P007P4_n50FamCod ;
      private int[] P007P4_A51SublCod ;
      private bool[] P007P4_n51SublCod ;
      private int[] P007P4_A52LinCod ;
      private string[] P007P4_A433AlmAbr ;
      private string aP7_Filename ;
      private string aP8_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class r_stockactualconsolidadoexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007P2( IGxContext context ,
                                             int AV80AlmCod ,
                                             int AV77LinCod ,
                                             int AV78SubLCod ,
                                             int AV79FamCod ,
                                             string AV81Prodcod ,
                                             int A63AlmCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             short A438AlmSts ,
                                             short A1158LinStk )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCod], T1.[AlmCod], T3.[LinStk], T4.[AlmSts], T2.[FamCod], T2.[SublCod], T2.[LinCod], T4.[AlmAbr] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T1.[AlmCod])";
         AddWhere(sWhereString, "(T4.[AlmSts] = 1)");
         AddWhere(sWhereString, "(T3.[LinStk] = 1)");
         if ( ! (0==AV80AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[AlmCod] = @AV80AlmCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV77LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV77LinCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV78SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV78SubLCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV79FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV79FamCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV81Prodcod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[AlmCod], T1.[ProdCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007P3( IGxContext context ,
                                             int AV77LinCod ,
                                             int AV78SubLCod ,
                                             int AV79FamCod ,
                                             string AV81Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             decimal A1880StkAct ,
                                             short A1158LinStk )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T2.[ProdDsc], T1.[ProdCod], T1.[StkIng] - T1.[StkSal] AS StkAct, T4.[LinStk], T2.[FamCod], T2.[SublCod], T2.[LinCod], T3.[UniAbr], T2.[ProdRef1], T1.[StkIng], T1.[StkSal], T1.[AlmCod] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod])";
         AddWhere(sWhereString, "(T1.[StkIng] - T1.[StkSal] <> 0)");
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         if ( ! (0==AV77LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV77LinCod)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV78SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV78SubLCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV79FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV79FamCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV81Prodcod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T2.[ProdDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007P4( IGxContext context ,
                                             int AV80AlmCod ,
                                             int AV77LinCod ,
                                             int AV78SubLCod ,
                                             int AV79FamCod ,
                                             string AV81Prodcod ,
                                             int A63AlmCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             short A1158LinStk ,
                                             short A438AlmSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCod], T1.[AlmCod], T4.[AlmSts], T3.[LinStk], T2.[FamCod], T2.[SublCod], T2.[LinCod], T4.[AlmAbr] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T1.[AlmCod])";
         AddWhere(sWhereString, "(T3.[LinStk] = 1)");
         AddWhere(sWhereString, "(T4.[AlmSts] = 1)");
         if ( ! (0==AV80AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[AlmCod] = @AV80AlmCod)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (0==AV77LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV77LinCod)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV78SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV78SubLCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV79FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV79FamCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV81Prodcod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[AlmCod], T1.[ProdCod]";
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
               case 0 :
                     return conditional_P007P2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
               case 1 :
                     return conditional_P007P3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (short)dynConstraints[9] );
               case 2 :
                     return conditional_P007P4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
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
          Object[] prmP007P2;
          prmP007P2 = new Object[] {
          new ParDef("@AV80AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV77LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV78SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV79FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV81Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP007P3;
          prmP007P3 = new Object[] {
          new ParDef("@AV77LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV78SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV79FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV81Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP007P4;
          prmP007P4 = new Object[] {
          new ParDef("@AV80AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV77LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV78SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV79FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV81Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007P2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007P3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007P4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007P4,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((string[]) buf[11])[0] = rslt.getString(10, 20);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 10);
                return;
       }
    }

 }

}
