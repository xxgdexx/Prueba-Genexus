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
namespace GeneXus.Programs.produccion {
   public class r_paresumencostotipomovimientoexcel : GXProcedure
   {
      public r_paresumencostotipomovimientoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_paresumencostotipomovimientoexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_MovCod ,
                           ref int aP1_LinCod ,
                           ref string aP2_Prodcod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref int aP5_AlmCod ,
                           ref int aP6_SublCod ,
                           ref int aP7_FamCod ,
                           out string aP8_Filename ,
                           out string aP9_ErrorMessage )
      {
         this.AV128MovCod = aP0_MovCod;
         this.AV82LinCod = aP1_LinCod;
         this.AV78Prodcod = aP2_Prodcod;
         this.AV77FDesde = aP3_FDesde;
         this.AV76FHasta = aP4_FHasta;
         this.AV79AlmCod = aP5_AlmCod;
         this.AV81SublCod = aP6_SublCod;
         this.AV80FamCod = aP7_FamCod;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_MovCod=this.AV128MovCod;
         aP1_LinCod=this.AV82LinCod;
         aP2_Prodcod=this.AV78Prodcod;
         aP3_FDesde=this.AV77FDesde;
         aP4_FHasta=this.AV76FHasta;
         aP5_AlmCod=this.AV79AlmCod;
         aP6_SublCod=this.AV81SublCod;
         aP7_FamCod=this.AV80FamCod;
         aP8_Filename=this.AV10Filename;
         aP9_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref int aP0_MovCod ,
                                ref int aP1_LinCod ,
                                ref string aP2_Prodcod ,
                                ref DateTime aP3_FDesde ,
                                ref DateTime aP4_FHasta ,
                                ref int aP5_AlmCod ,
                                ref int aP6_SublCod ,
                                ref int aP7_FamCod ,
                                out string aP8_Filename )
      {
         execute(ref aP0_MovCod, ref aP1_LinCod, ref aP2_Prodcod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_AlmCod, ref aP6_SublCod, ref aP7_FamCod, out aP8_Filename, out aP9_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_MovCod ,
                                 ref int aP1_LinCod ,
                                 ref string aP2_Prodcod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref int aP5_AlmCod ,
                                 ref int aP6_SublCod ,
                                 ref int aP7_FamCod ,
                                 out string aP8_Filename ,
                                 out string aP9_ErrorMessage )
      {
         r_paresumencostotipomovimientoexcel objr_paresumencostotipomovimientoexcel;
         objr_paresumencostotipomovimientoexcel = new r_paresumencostotipomovimientoexcel();
         objr_paresumencostotipomovimientoexcel.AV128MovCod = aP0_MovCod;
         objr_paresumencostotipomovimientoexcel.AV82LinCod = aP1_LinCod;
         objr_paresumencostotipomovimientoexcel.AV78Prodcod = aP2_Prodcod;
         objr_paresumencostotipomovimientoexcel.AV77FDesde = aP3_FDesde;
         objr_paresumencostotipomovimientoexcel.AV76FHasta = aP4_FHasta;
         objr_paresumencostotipomovimientoexcel.AV79AlmCod = aP5_AlmCod;
         objr_paresumencostotipomovimientoexcel.AV81SublCod = aP6_SublCod;
         objr_paresumencostotipomovimientoexcel.AV80FamCod = aP7_FamCod;
         objr_paresumencostotipomovimientoexcel.AV10Filename = "" ;
         objr_paresumencostotipomovimientoexcel.AV11ErrorMessage = "" ;
         objr_paresumencostotipomovimientoexcel.context.SetSubmitInitialConfig(context);
         objr_paresumencostotipomovimientoexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_paresumencostotipomovimientoexcel);
         aP0_MovCod=this.AV128MovCod;
         aP1_LinCod=this.AV82LinCod;
         aP2_Prodcod=this.AV78Prodcod;
         aP3_FDesde=this.AV77FDesde;
         aP4_FHasta=this.AV76FHasta;
         aP5_AlmCod=this.AV79AlmCod;
         aP6_SublCod=this.AV81SublCod;
         aP7_FamCod=this.AV80FamCod;
         aP8_Filename=this.AV10Filename;
         aP9_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_paresumencostotipomovimientoexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasResumenCostoTipoMovimiento.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasResumenCostoTipoMovimiento.xlsx";
         AV10Filename = "Excel/ResumenCostoTipoMovimiento" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV70FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 6;
         AV15FirstColumn = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV128MovCod ,
                                              AV82LinCod ,
                                              AV78Prodcod ,
                                              AV79AlmCod ,
                                              AV81SublCod ,
                                              AV80FamCod ,
                                              A22MvAMov ,
                                              A52LinCod ,
                                              A28ProdCod ,
                                              A21MvAlm ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A25MvAFec ,
                                              AV77FDesde ,
                                              AV76FHasta ,
                                              A1370MVSts ,
                                              A1158LinStk ,
                                              A1269MvAlmCos } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00G52 */
         pr_default.execute(0, new Object[] {AV77FDesde, AV76FHasta, AV128MovCod, AV82LinCod, AV78Prodcod, AV79AlmCod, AV81SublCod, AV80FamCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKG52 = false;
            A28ProdCod = P00G52_A28ProdCod[0];
            A1269MvAlmCos = P00G52_A1269MvAlmCos[0];
            A1278MvARef = P00G52_A1278MvARef[0];
            A24DocNum = P00G52_A24DocNum[0];
            n24DocNum = P00G52_n24DocNum[0];
            A1274MvAMovDsc = P00G52_A1274MvAMovDsc[0];
            A1248MvADCant = P00G52_A1248MvADCant[0];
            A1250MVADPrecio = P00G52_A1250MVADPrecio[0];
            A1249MVADCosto = P00G52_A1249MVADCosto[0];
            A14MvACod = P00G52_A14MvACod[0];
            A13MvATip = P00G52_A13MvATip[0];
            A25MvAFec = P00G52_A25MvAFec[0];
            A1158LinStk = P00G52_A1158LinStk[0];
            A1370MVSts = P00G52_A1370MVSts[0];
            A50FamCod = P00G52_A50FamCod[0];
            n50FamCod = P00G52_n50FamCod[0];
            A51SublCod = P00G52_A51SublCod[0];
            n51SublCod = P00G52_n51SublCod[0];
            A21MvAlm = P00G52_A21MvAlm[0];
            A52LinCod = P00G52_A52LinCod[0];
            A22MvAMov = P00G52_A22MvAMov[0];
            A55ProdDsc = P00G52_A55ProdDsc[0];
            A1153LinDsc = P00G52_A1153LinDsc[0];
            A30MvADItem = P00G52_A30MvADItem[0];
            A50FamCod = P00G52_A50FamCod[0];
            n50FamCod = P00G52_n50FamCod[0];
            A51SublCod = P00G52_A51SublCod[0];
            n51SublCod = P00G52_n51SublCod[0];
            A52LinCod = P00G52_A52LinCod[0];
            A55ProdDsc = P00G52_A55ProdDsc[0];
            A1158LinStk = P00G52_A1158LinStk[0];
            A1153LinDsc = P00G52_A1153LinDsc[0];
            A1278MvARef = P00G52_A1278MvARef[0];
            A24DocNum = P00G52_A24DocNum[0];
            n24DocNum = P00G52_n24DocNum[0];
            A25MvAFec = P00G52_A25MvAFec[0];
            A1370MVSts = P00G52_A1370MVSts[0];
            A21MvAlm = P00G52_A21MvAlm[0];
            A22MvAMov = P00G52_A22MvAMov[0];
            A1269MvAlmCos = P00G52_A1269MvAlmCos[0];
            A1274MvAMovDsc = P00G52_A1274MvAMovDsc[0];
            AV78Prodcod = A28ProdCod;
            AV135ProdDsc = StringUtil.Trim( A55ProdDsc);
            AV134LinDsc = StringUtil.Trim( A1153LinDsc);
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00G52_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRKG52 = false;
               A1269MvAlmCos = P00G52_A1269MvAlmCos[0];
               A1278MvARef = P00G52_A1278MvARef[0];
               A24DocNum = P00G52_A24DocNum[0];
               n24DocNum = P00G52_n24DocNum[0];
               A1274MvAMovDsc = P00G52_A1274MvAMovDsc[0];
               A1248MvADCant = P00G52_A1248MvADCant[0];
               A1250MVADPrecio = P00G52_A1250MVADPrecio[0];
               A1249MVADCosto = P00G52_A1249MVADCosto[0];
               A14MvACod = P00G52_A14MvACod[0];
               A13MvATip = P00G52_A13MvATip[0];
               A25MvAFec = P00G52_A25MvAFec[0];
               A21MvAlm = P00G52_A21MvAlm[0];
               A22MvAMov = P00G52_A22MvAMov[0];
               A30MvADItem = P00G52_A30MvADItem[0];
               A1278MvARef = P00G52_A1278MvARef[0];
               A24DocNum = P00G52_A24DocNum[0];
               n24DocNum = P00G52_n24DocNum[0];
               A25MvAFec = P00G52_A25MvAFec[0];
               A21MvAlm = P00G52_A21MvAlm[0];
               A22MvAMov = P00G52_A22MvAMov[0];
               A1269MvAlmCos = P00G52_A1269MvAlmCos[0];
               A1274MvAMovDsc = P00G52_A1274MvAMovDsc[0];
               if ( A1269MvAlmCos == 1 )
               {
                  AV122MVATip = A13MvATip;
                  AV123MVACod = A14MvACod;
                  AV129MVAFec = A25MvAFec;
                  AV136MVARef = A1278MvARef;
                  AV37DocNum = A24DocNum;
                  AV130MVAMovDsc = A1274MvAMovDsc;
                  AV131MVADCant = A1248MvADCant;
                  AV132MVADPrecio = A1250MVADPrecio;
                  AV133MVADCosto = A1249MVADCosto;
                  /* Execute user subroutine: 'DETALLE' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
               }
               BRKG52 = true;
               pr_default.readNext(0);
            }
            if ( ! BRKG52 )
            {
               BRKG52 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
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
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV134LinDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV78Prodcod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV135ProdDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV122MVATip);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV123MVACod);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV129MVAFec ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Date = GXt_dtime1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV136MVARef);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV37DocNum);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Text = StringUtil.Trim( AV130MVAMovDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV131MVADCant);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV132MVADPrecio);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(AV133MVADCosto);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S121( )
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
         A25MvAFec = DateTime.MinValue;
         A1370MVSts = "";
         P00G52_A28ProdCod = new string[] {""} ;
         P00G52_A1269MvAlmCos = new short[1] ;
         P00G52_A1278MvARef = new string[] {""} ;
         P00G52_A24DocNum = new string[] {""} ;
         P00G52_n24DocNum = new bool[] {false} ;
         P00G52_A1274MvAMovDsc = new string[] {""} ;
         P00G52_A1248MvADCant = new decimal[1] ;
         P00G52_A1250MVADPrecio = new decimal[1] ;
         P00G52_A1249MVADCosto = new decimal[1] ;
         P00G52_A14MvACod = new string[] {""} ;
         P00G52_A13MvATip = new string[] {""} ;
         P00G52_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00G52_A1158LinStk = new short[1] ;
         P00G52_A1370MVSts = new string[] {""} ;
         P00G52_A50FamCod = new int[1] ;
         P00G52_n50FamCod = new bool[] {false} ;
         P00G52_A51SublCod = new int[1] ;
         P00G52_n51SublCod = new bool[] {false} ;
         P00G52_A21MvAlm = new int[1] ;
         P00G52_A52LinCod = new int[1] ;
         P00G52_A22MvAMov = new int[1] ;
         P00G52_A55ProdDsc = new string[] {""} ;
         P00G52_A1153LinDsc = new string[] {""} ;
         P00G52_A30MvADItem = new int[1] ;
         A1278MvARef = "";
         A24DocNum = "";
         A1274MvAMovDsc = "";
         A14MvACod = "";
         A13MvATip = "";
         A55ProdDsc = "";
         A1153LinDsc = "";
         AV135ProdDsc = "";
         AV134LinDsc = "";
         AV122MVATip = "";
         AV123MVACod = "";
         AV129MVAFec = DateTime.MinValue;
         AV136MVARef = "";
         AV37DocNum = "";
         AV130MVAMovDsc = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_paresumencostotipomovimientoexcel__default(),
            new Object[][] {
                new Object[] {
               P00G52_A28ProdCod, P00G52_A1269MvAlmCos, P00G52_A1278MvARef, P00G52_A24DocNum, P00G52_n24DocNum, P00G52_A1274MvAMovDsc, P00G52_A1248MvADCant, P00G52_A1250MVADPrecio, P00G52_A1249MVADCosto, P00G52_A14MvACod,
               P00G52_A13MvATip, P00G52_A25MvAFec, P00G52_A1158LinStk, P00G52_A1370MVSts, P00G52_A50FamCod, P00G52_n50FamCod, P00G52_A51SublCod, P00G52_n51SublCod, P00G52_A21MvAlm, P00G52_A52LinCod,
               P00G52_A22MvAMov, P00G52_A55ProdDsc, P00G52_A1153LinDsc, P00G52_A30MvADItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1158LinStk ;
      private short A1269MvAlmCos ;
      private int AV128MovCod ;
      private int AV82LinCod ;
      private int AV79AlmCod ;
      private int AV81SublCod ;
      private int AV80FamCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A22MvAMov ;
      private int A52LinCod ;
      private int A21MvAlm ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A30MvADItem ;
      private decimal A1248MvADCant ;
      private decimal A1250MVADPrecio ;
      private decimal A1249MVADCosto ;
      private decimal AV131MVADCant ;
      private decimal AV132MVADPrecio ;
      private decimal AV133MVADCosto ;
      private string AV78Prodcod ;
      private string AV71Path ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A1370MVSts ;
      private string A1278MvARef ;
      private string A24DocNum ;
      private string A1274MvAMovDsc ;
      private string A14MvACod ;
      private string A13MvATip ;
      private string A55ProdDsc ;
      private string A1153LinDsc ;
      private string AV135ProdDsc ;
      private string AV134LinDsc ;
      private string AV122MVATip ;
      private string AV123MVACod ;
      private string AV136MVARef ;
      private string AV37DocNum ;
      private string AV130MVAMovDsc ;
      private DateTime GXt_dtime1 ;
      private DateTime AV77FDesde ;
      private DateTime AV76FHasta ;
      private DateTime A25MvAFec ;
      private DateTime AV129MVAFec ;
      private bool returnInSub ;
      private bool BRKG52 ;
      private bool n24DocNum ;
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
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private int aP5_AlmCod ;
      private int aP6_SublCod ;
      private int aP7_FamCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00G52_A28ProdCod ;
      private short[] P00G52_A1269MvAlmCos ;
      private string[] P00G52_A1278MvARef ;
      private string[] P00G52_A24DocNum ;
      private bool[] P00G52_n24DocNum ;
      private string[] P00G52_A1274MvAMovDsc ;
      private decimal[] P00G52_A1248MvADCant ;
      private decimal[] P00G52_A1250MVADPrecio ;
      private decimal[] P00G52_A1249MVADCosto ;
      private string[] P00G52_A14MvACod ;
      private string[] P00G52_A13MvATip ;
      private DateTime[] P00G52_A25MvAFec ;
      private short[] P00G52_A1158LinStk ;
      private string[] P00G52_A1370MVSts ;
      private int[] P00G52_A50FamCod ;
      private bool[] P00G52_n50FamCod ;
      private int[] P00G52_A51SublCod ;
      private bool[] P00G52_n51SublCod ;
      private int[] P00G52_A21MvAlm ;
      private int[] P00G52_A52LinCod ;
      private int[] P00G52_A22MvAMov ;
      private string[] P00G52_A55ProdDsc ;
      private string[] P00G52_A1153LinDsc ;
      private int[] P00G52_A30MvADItem ;
      private string aP8_Filename ;
      private string aP9_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class r_paresumencostotipomovimientoexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00G52( IGxContext context ,
                                             int AV128MovCod ,
                                             int AV82LinCod ,
                                             string AV78Prodcod ,
                                             int AV79AlmCod ,
                                             int AV81SublCod ,
                                             int AV80FamCod ,
                                             int A22MvAMov ,
                                             int A52LinCod ,
                                             string A28ProdCod ,
                                             int A21MvAlm ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             DateTime A25MvAFec ,
                                             DateTime AV77FDesde ,
                                             DateTime AV76FHasta ,
                                             string A1370MVSts ,
                                             short A1158LinStk ,
                                             short A1269MvAlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[8];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCod], T5.[AlmCos] AS MvAlmCos, T4.[MvARef], T4.[DocNum], T6.[MovDsc] AS MvAMovDsc, T1.[MvADCant], T1.[MVADPrecio], T1.[MVADCosto], T1.[MvACod], T1.[MvATip], T4.[MvAFec], T3.[LinStk], T4.[MVSts], T2.[FamCod], T2.[SublCod], T4.[MvAlm] AS MvAlm, T2.[LinCod], T4.[MvAMov] AS MvAMov, T2.[ProdDsc], T3.[LinDsc], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T4 ON T4.[MvATip] = T1.[MvATip] AND T4.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T5 ON T5.[AlmCod] = T4.[MvAlm]) INNER JOIN [CMOVALMACEN] T6 ON T6.[MovCod] = T4.[MvAMov])";
         AddWhere(sWhereString, "(T4.[MvAFec] >= @AV77FDesde and T4.[MvAFec] <= @AV76FHasta)");
         AddWhere(sWhereString, "(T4.[MVSts] <> 'A')");
         AddWhere(sWhereString, "(T3.[LinStk] = 1)");
         AddWhere(sWhereString, "(T5.[AlmCos] = 1)");
         if ( ! (0==AV128MovCod) )
         {
            AddWhere(sWhereString, "(T4.[MvAMov] = @AV128MovCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV82LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV82LinCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV78Prodcod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV79AlmCod) )
         {
            AddWhere(sWhereString, "(T4.[MvAlm] = @AV79AlmCod)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV81SublCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV81SublCod)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV80FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV80FamCod)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T4.[MvAFec], T1.[MvATip], T1.[MvACod]";
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
                     return conditional_P00G52(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00G52;
          prmP00G52 = new Object[] {
          new ParDef("@AV77FDesde",GXType.Date,8,0) ,
          new ParDef("@AV76FHasta",GXType.Date,8,0) ,
          new ParDef("@AV128MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV82LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV78Prodcod",GXType.NChar,15,0) ,
          new ParDef("@AV79AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV81SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV80FamCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00G52", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G52,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 12);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 12);
                ((string[]) buf[10])[0] = rslt.getString(10, 3);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
                ((short[]) buf[12])[0] = rslt.getShort(12);
                ((string[]) buf[13])[0] = rslt.getString(13, 1);
                ((int[]) buf[14])[0] = rslt.getInt(14);
                ((bool[]) buf[15])[0] = rslt.wasNull(14);
                ((int[]) buf[16])[0] = rslt.getInt(15);
                ((bool[]) buf[17])[0] = rslt.wasNull(15);
                ((int[]) buf[18])[0] = rslt.getInt(16);
                ((int[]) buf[19])[0] = rslt.getInt(17);
                ((int[]) buf[20])[0] = rslt.getInt(18);
                ((string[]) buf[21])[0] = rslt.getString(19, 100);
                ((string[]) buf[22])[0] = rslt.getString(20, 100);
                ((int[]) buf[23])[0] = rslt.getInt(21);
                return;
       }
    }

 }

}
