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
   public class r_resumensalidasexcel : GXProcedure
   {
      public r_resumensalidasexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumensalidasexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_MovCod ,
                           ref int aP1_LinCod ,
                           ref string aP2_Prodcod ,
                           ref DateTime aP3_Hdesde ,
                           ref DateTime aP4_HHasta ,
                           ref int aP5_AlmCod ,
                           ref int aP6_SubLCod ,
                           ref int aP7_FamCod ,
                           ref string aP8_CosCod ,
                           ref string aP9_Tipo ,
                           out string aP10_Filename ,
                           out string aP11_ErrorMessage )
      {
         this.AV94MovCod = aP0_MovCod;
         this.AV77LinCod = aP1_LinCod;
         this.AV81Prodcod = aP2_Prodcod;
         this.AV93Hdesde = aP3_Hdesde;
         this.AV92HHasta = aP4_HHasta;
         this.AV80AlmCod = aP5_AlmCod;
         this.AV78SubLCod = aP6_SubLCod;
         this.AV79FamCod = aP7_FamCod;
         this.AV91CosCod = aP8_CosCod;
         this.AV103Tipo = aP9_Tipo;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_MovCod=this.AV94MovCod;
         aP1_LinCod=this.AV77LinCod;
         aP2_Prodcod=this.AV81Prodcod;
         aP3_Hdesde=this.AV93Hdesde;
         aP4_HHasta=this.AV92HHasta;
         aP5_AlmCod=this.AV80AlmCod;
         aP6_SubLCod=this.AV78SubLCod;
         aP7_FamCod=this.AV79FamCod;
         aP8_CosCod=this.AV91CosCod;
         aP9_Tipo=this.AV103Tipo;
         aP10_Filename=this.AV10Filename;
         aP11_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref int aP0_MovCod ,
                                ref int aP1_LinCod ,
                                ref string aP2_Prodcod ,
                                ref DateTime aP3_Hdesde ,
                                ref DateTime aP4_HHasta ,
                                ref int aP5_AlmCod ,
                                ref int aP6_SubLCod ,
                                ref int aP7_FamCod ,
                                ref string aP8_CosCod ,
                                ref string aP9_Tipo ,
                                out string aP10_Filename )
      {
         execute(ref aP0_MovCod, ref aP1_LinCod, ref aP2_Prodcod, ref aP3_Hdesde, ref aP4_HHasta, ref aP5_AlmCod, ref aP6_SubLCod, ref aP7_FamCod, ref aP8_CosCod, ref aP9_Tipo, out aP10_Filename, out aP11_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_MovCod ,
                                 ref int aP1_LinCod ,
                                 ref string aP2_Prodcod ,
                                 ref DateTime aP3_Hdesde ,
                                 ref DateTime aP4_HHasta ,
                                 ref int aP5_AlmCod ,
                                 ref int aP6_SubLCod ,
                                 ref int aP7_FamCod ,
                                 ref string aP8_CosCod ,
                                 ref string aP9_Tipo ,
                                 out string aP10_Filename ,
                                 out string aP11_ErrorMessage )
      {
         r_resumensalidasexcel objr_resumensalidasexcel;
         objr_resumensalidasexcel = new r_resumensalidasexcel();
         objr_resumensalidasexcel.AV94MovCod = aP0_MovCod;
         objr_resumensalidasexcel.AV77LinCod = aP1_LinCod;
         objr_resumensalidasexcel.AV81Prodcod = aP2_Prodcod;
         objr_resumensalidasexcel.AV93Hdesde = aP3_Hdesde;
         objr_resumensalidasexcel.AV92HHasta = aP4_HHasta;
         objr_resumensalidasexcel.AV80AlmCod = aP5_AlmCod;
         objr_resumensalidasexcel.AV78SubLCod = aP6_SubLCod;
         objr_resumensalidasexcel.AV79FamCod = aP7_FamCod;
         objr_resumensalidasexcel.AV91CosCod = aP8_CosCod;
         objr_resumensalidasexcel.AV103Tipo = aP9_Tipo;
         objr_resumensalidasexcel.AV10Filename = "" ;
         objr_resumensalidasexcel.AV11ErrorMessage = "" ;
         objr_resumensalidasexcel.context.SetSubmitInitialConfig(context);
         objr_resumensalidasexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumensalidasexcel);
         aP0_MovCod=this.AV94MovCod;
         aP1_LinCod=this.AV77LinCod;
         aP2_Prodcod=this.AV81Prodcod;
         aP3_Hdesde=this.AV93Hdesde;
         aP4_HHasta=this.AV92HHasta;
         aP5_AlmCod=this.AV80AlmCod;
         aP6_SubLCod=this.AV78SubLCod;
         aP7_FamCod=this.AV79FamCod;
         aP8_CosCod=this.AV91CosCod;
         aP9_Tipo=this.AV103Tipo;
         aP10_Filename=this.AV10Filename;
         aP11_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumensalidasexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasResumenSalida.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasResumenSalida.xlsx";
         AV10Filename = "Excel/ResumenSalidas" + ".xlsx";
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
         AV14CellRow = 5;
         AV15FirstColumn = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV94MovCod ,
                                              AV77LinCod ,
                                              AV78SubLCod ,
                                              AV79FamCod ,
                                              AV81Prodcod ,
                                              AV91CosCod ,
                                              AV103Tipo ,
                                              AV80AlmCod ,
                                              A22MvAMov ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A28ProdCod ,
                                              A1287MVCCosto ,
                                              A1249MVADCosto ,
                                              A21MvAlm ,
                                              A13MvATip ,
                                              A25MvAFec ,
                                              AV93Hdesde ,
                                              AV92HHasta ,
                                              A1370MVSts } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P008H2 */
         pr_default.execute(0, new Object[] {AV93Hdesde, AV92HHasta, AV94MovCod, AV77LinCod, AV78SubLCod, AV79FamCod, AV81Prodcod, AV91CosCod, AV80AlmCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1370MVSts = P008H2_A1370MVSts[0];
            A25MvAFec = P008H2_A25MvAFec[0];
            A21MvAlm = P008H2_A21MvAlm[0];
            A1249MVADCosto = P008H2_A1249MVADCosto[0];
            A13MvATip = P008H2_A13MvATip[0];
            A1287MVCCosto = P008H2_A1287MVCCosto[0];
            A28ProdCod = P008H2_A28ProdCod[0];
            A50FamCod = P008H2_A50FamCod[0];
            n50FamCod = P008H2_n50FamCod[0];
            A51SublCod = P008H2_A51SublCod[0];
            n51SublCod = P008H2_n51SublCod[0];
            A52LinCod = P008H2_A52LinCod[0];
            A22MvAMov = P008H2_A22MvAMov[0];
            A55ProdDsc = P008H2_A55ProdDsc[0];
            A14MvACod = P008H2_A14MvACod[0];
            A1274MvAMovDsc = P008H2_A1274MvAMovDsc[0];
            A1278MvARef = P008H2_A1278MvARef[0];
            A1276MvAOcom = P008H2_A1276MvAOcom[0];
            A1248MvADCant = P008H2_A1248MvADCant[0];
            A30MvADItem = P008H2_A30MvADItem[0];
            A50FamCod = P008H2_A50FamCod[0];
            n50FamCod = P008H2_n50FamCod[0];
            A51SublCod = P008H2_A51SublCod[0];
            n51SublCod = P008H2_n51SublCod[0];
            A52LinCod = P008H2_A52LinCod[0];
            A55ProdDsc = P008H2_A55ProdDsc[0];
            A1370MVSts = P008H2_A1370MVSts[0];
            A25MvAFec = P008H2_A25MvAFec[0];
            A21MvAlm = P008H2_A21MvAlm[0];
            A1287MVCCosto = P008H2_A1287MVCCosto[0];
            A22MvAMov = P008H2_A22MvAMov[0];
            A1278MvARef = P008H2_A1278MvARef[0];
            A1276MvAOcom = P008H2_A1276MvAOcom[0];
            A1274MvAMovDsc = P008H2_A1274MvAMovDsc[0];
            AV81Prodcod = StringUtil.Trim( A28ProdCod);
            AV95ProdDsc = StringUtil.Trim( A55ProdDsc);
            AV96MVATip = StringUtil.Trim( A13MvATip);
            AV97MVACod = StringUtil.Trim( A14MvACod);
            AV98MVAFec = A25MvAFec;
            AV99MVAMovDsc = StringUtil.Trim( A1274MvAMovDsc);
            AV101MVARef = (String.IsNullOrEmpty(StringUtil.RTrim( A1276MvAOcom)) ? A1278MvARef : A1276MvAOcom);
            AV104MVCCosto = A1287MVCCosto;
            AV100MVADCant = A1248MvADCant;
            AV102MVADCosto = A1249MVADCosto;
            /* Execute user subroutine: 'CENTROCOSTO' */
            S131 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'DETALLE' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV81Prodcod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV95ProdDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV96MVATip);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV97MVACod);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV98MVAFec ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Date = GXt_dtime1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV99MVAMovDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV101MVARef);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV100MVADCant);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV102MVADCosto);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Text = StringUtil.Trim( AV105CosDsc);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S131( )
      {
         /* 'CENTROCOSTO' Routine */
         returnInSub = false;
         AV105CosDsc = "";
         /* Using cursor P008H3 */
         pr_default.execute(1, new Object[] {AV104MVCCosto});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A79COSCod = P008H3_A79COSCod[0];
            A761COSDsc = P008H3_A761COSDsc[0];
            AV105CosDsc = StringUtil.Trim( A761COSDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         scmdbuf = "";
         A28ProdCod = "";
         A1287MVCCosto = "";
         A13MvATip = "";
         A25MvAFec = DateTime.MinValue;
         A1370MVSts = "";
         P008H2_A1370MVSts = new string[] {""} ;
         P008H2_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008H2_A21MvAlm = new int[1] ;
         P008H2_A1249MVADCosto = new decimal[1] ;
         P008H2_A13MvATip = new string[] {""} ;
         P008H2_A1287MVCCosto = new string[] {""} ;
         P008H2_A28ProdCod = new string[] {""} ;
         P008H2_A50FamCod = new int[1] ;
         P008H2_n50FamCod = new bool[] {false} ;
         P008H2_A51SublCod = new int[1] ;
         P008H2_n51SublCod = new bool[] {false} ;
         P008H2_A52LinCod = new int[1] ;
         P008H2_A22MvAMov = new int[1] ;
         P008H2_A55ProdDsc = new string[] {""} ;
         P008H2_A14MvACod = new string[] {""} ;
         P008H2_A1274MvAMovDsc = new string[] {""} ;
         P008H2_A1278MvARef = new string[] {""} ;
         P008H2_A1276MvAOcom = new string[] {""} ;
         P008H2_A1248MvADCant = new decimal[1] ;
         P008H2_A30MvADItem = new int[1] ;
         A55ProdDsc = "";
         A14MvACod = "";
         A1274MvAMovDsc = "";
         A1278MvARef = "";
         A1276MvAOcom = "";
         AV95ProdDsc = "";
         AV96MVATip = "";
         AV97MVACod = "";
         AV98MVAFec = DateTime.MinValue;
         AV99MVAMovDsc = "";
         AV101MVARef = "";
         AV104MVCCosto = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV105CosDsc = "";
         P008H3_A79COSCod = new string[] {""} ;
         P008H3_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_resumensalidasexcel__default(),
            new Object[][] {
                new Object[] {
               P008H2_A1370MVSts, P008H2_A25MvAFec, P008H2_A21MvAlm, P008H2_A1249MVADCosto, P008H2_A13MvATip, P008H2_A1287MVCCosto, P008H2_A28ProdCod, P008H2_A50FamCod, P008H2_n50FamCod, P008H2_A51SublCod,
               P008H2_n51SublCod, P008H2_A52LinCod, P008H2_A22MvAMov, P008H2_A55ProdDsc, P008H2_A14MvACod, P008H2_A1274MvAMovDsc, P008H2_A1278MvARef, P008H2_A1276MvAOcom, P008H2_A1248MvADCant, P008H2_A30MvADItem
               }
               , new Object[] {
               P008H3_A79COSCod, P008H3_A761COSDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV94MovCod ;
      private int AV77LinCod ;
      private int AV80AlmCod ;
      private int AV78SubLCod ;
      private int AV79FamCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A22MvAMov ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private decimal A1249MVADCosto ;
      private decimal A1248MvADCant ;
      private decimal AV100MVADCant ;
      private decimal AV102MVADCosto ;
      private string AV81Prodcod ;
      private string AV91CosCod ;
      private string AV103Tipo ;
      private string AV71Path ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A1287MVCCosto ;
      private string A13MvATip ;
      private string A1370MVSts ;
      private string A55ProdDsc ;
      private string A14MvACod ;
      private string A1274MvAMovDsc ;
      private string A1278MvARef ;
      private string A1276MvAOcom ;
      private string AV95ProdDsc ;
      private string AV96MVATip ;
      private string AV97MVACod ;
      private string AV99MVAMovDsc ;
      private string AV101MVARef ;
      private string AV104MVCCosto ;
      private string AV105CosDsc ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private DateTime GXt_dtime1 ;
      private DateTime AV93Hdesde ;
      private DateTime AV92HHasta ;
      private DateTime A25MvAFec ;
      private DateTime AV98MVAFec ;
      private bool returnInSub ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_MovCod ;
      private int aP1_LinCod ;
      private string aP2_Prodcod ;
      private DateTime aP3_Hdesde ;
      private DateTime aP4_HHasta ;
      private int aP5_AlmCod ;
      private int aP6_SubLCod ;
      private int aP7_FamCod ;
      private string aP8_CosCod ;
      private string aP9_Tipo ;
      private IDataStoreProvider pr_default ;
      private string[] P008H2_A1370MVSts ;
      private DateTime[] P008H2_A25MvAFec ;
      private int[] P008H2_A21MvAlm ;
      private decimal[] P008H2_A1249MVADCosto ;
      private string[] P008H2_A13MvATip ;
      private string[] P008H2_A1287MVCCosto ;
      private string[] P008H2_A28ProdCod ;
      private int[] P008H2_A50FamCod ;
      private bool[] P008H2_n50FamCod ;
      private int[] P008H2_A51SublCod ;
      private bool[] P008H2_n51SublCod ;
      private int[] P008H2_A52LinCod ;
      private int[] P008H2_A22MvAMov ;
      private string[] P008H2_A55ProdDsc ;
      private string[] P008H2_A14MvACod ;
      private string[] P008H2_A1274MvAMovDsc ;
      private string[] P008H2_A1278MvARef ;
      private string[] P008H2_A1276MvAOcom ;
      private decimal[] P008H2_A1248MvADCant ;
      private int[] P008H2_A30MvADItem ;
      private string[] P008H3_A79COSCod ;
      private string[] P008H3_A761COSDsc ;
      private string aP10_Filename ;
      private string aP11_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class r_resumensalidasexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008H2( IGxContext context ,
                                             int AV94MovCod ,
                                             int AV77LinCod ,
                                             int AV78SubLCod ,
                                             int AV79FamCod ,
                                             string AV81Prodcod ,
                                             string AV91CosCod ,
                                             string AV103Tipo ,
                                             int AV80AlmCod ,
                                             int A22MvAMov ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             string A1287MVCCosto ,
                                             decimal A1249MVADCosto ,
                                             int A21MvAlm ,
                                             string A13MvATip ,
                                             DateTime A25MvAFec ,
                                             DateTime AV93Hdesde ,
                                             DateTime AV92HHasta ,
                                             string A1370MVSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T3.[MVSts], T3.[MvAFec], T3.[MvAlm], T1.[MVADCosto], T1.[MvATip], T3.[MVCCosto], T1.[ProdCod], T2.[FamCod], T2.[SublCod], T2.[LinCod], T3.[MvAMov] AS MvAMov, T2.[ProdDsc], T1.[MvACod], T4.[MovDsc] AS MvAMovDsc, T3.[MvARef], T3.[MvAOcom], T1.[MvADCant], T1.[MvADItem] FROM ((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [AGUIAS] T3 ON T3.[MvATip] = T1.[MvATip] AND T3.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T4 ON T4.[MovCod] = T3.[MvAMov])";
         AddWhere(sWhereString, "(T1.[MvATip] <> 'ING')");
         AddWhere(sWhereString, "(T3.[MvAFec] >= @AV93Hdesde and T3.[MvAFec] <= @AV92HHasta)");
         AddWhere(sWhereString, "(T3.[MVSts] <> 'A')");
         if ( ! (0==AV94MovCod) )
         {
            AddWhere(sWhereString, "(T3.[MvAMov] = @AV94MovCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV77LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV77LinCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV78SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV78SubLCod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV79FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV79FamCod)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV81Prodcod)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91CosCod)) )
         {
            AddWhere(sWhereString, "(T3.[MVCCosto] = @AV91CosCod)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV103Tipo, "C") == 0 )
         {
            AddWhere(sWhereString, "(T1.[MVADCosto] = 0)");
         }
         if ( StringUtil.StrCmp(AV103Tipo, "S") == 0 )
         {
            AddWhere(sWhereString, "(T1.[MVADCosto] <> 0)");
         }
         if ( ! (0==AV80AlmCod) )
         {
            AddWhere(sWhereString, "(T3.[MvAlm] = @AV80AlmCod)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod]";
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
               case 0 :
                     return conditional_P008H2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] );
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
          Object[] prmP008H3;
          prmP008H3 = new Object[] {
          new ParDef("@AV104MVCCosto",GXType.NChar,10,0)
          };
          Object[] prmP008H2;
          prmP008H2 = new Object[] {
          new ParDef("@AV93Hdesde",GXType.Date,8,0) ,
          new ParDef("@AV92HHasta",GXType.Date,8,0) ,
          new ParDef("@AV94MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV77LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV78SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV79FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV81Prodcod",GXType.NChar,15,0) ,
          new ParDef("@AV91CosCod",GXType.NChar,10,0) ,
          new ParDef("@AV80AlmCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008H2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008H3", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV104MVCCosto ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008H3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 100);
                ((string[]) buf[14])[0] = rslt.getString(13, 12);
                ((string[]) buf[15])[0] = rslt.getString(14, 100);
                ((string[]) buf[16])[0] = rslt.getString(15, 20);
                ((string[]) buf[17])[0] = rslt.getString(16, 10);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(17);
                ((int[]) buf[19])[0] = rslt.getInt(18);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
