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
   public class r_resumenconsignacionexcel : GXProcedure
   {
      public r_resumenconsignacionexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenconsignacionexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_AlmCod ,
                           ref int aP1_LinCod ,
                           ref int aP2_SublCod ,
                           ref string aP3_ProdCod ,
                           ref string aP4_CliCod ,
                           ref DateTime aP5_FDesde ,
                           ref DateTime aP6_FHasta ,
                           out string aP7_Filename ,
                           out string aP8_ErrorMessage )
      {
         this.AV55AlmCod = aP0_AlmCod;
         this.AV50LinCod = aP1_LinCod;
         this.AV51SublCod = aP2_SublCod;
         this.AV9ProdCod = aP3_ProdCod;
         this.AV8CliCod = aP4_CliCod;
         this.AV11FDesde = aP5_FDesde;
         this.AV12FHasta = aP6_FHasta;
         this.AV39Filename = "" ;
         this.AV16ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_AlmCod=this.AV55AlmCod;
         aP1_LinCod=this.AV50LinCod;
         aP2_SublCod=this.AV51SublCod;
         aP3_ProdCod=this.AV9ProdCod;
         aP4_CliCod=this.AV8CliCod;
         aP5_FDesde=this.AV11FDesde;
         aP6_FHasta=this.AV12FHasta;
         aP7_Filename=this.AV39Filename;
         aP8_ErrorMessage=this.AV16ErrorMessage;
      }

      public string executeUdp( ref int aP0_AlmCod ,
                                ref int aP1_LinCod ,
                                ref int aP2_SublCod ,
                                ref string aP3_ProdCod ,
                                ref string aP4_CliCod ,
                                ref DateTime aP5_FDesde ,
                                ref DateTime aP6_FHasta ,
                                out string aP7_Filename )
      {
         execute(ref aP0_AlmCod, ref aP1_LinCod, ref aP2_SublCod, ref aP3_ProdCod, ref aP4_CliCod, ref aP5_FDesde, ref aP6_FHasta, out aP7_Filename, out aP8_ErrorMessage);
         return AV16ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_AlmCod ,
                                 ref int aP1_LinCod ,
                                 ref int aP2_SublCod ,
                                 ref string aP3_ProdCod ,
                                 ref string aP4_CliCod ,
                                 ref DateTime aP5_FDesde ,
                                 ref DateTime aP6_FHasta ,
                                 out string aP7_Filename ,
                                 out string aP8_ErrorMessage )
      {
         r_resumenconsignacionexcel objr_resumenconsignacionexcel;
         objr_resumenconsignacionexcel = new r_resumenconsignacionexcel();
         objr_resumenconsignacionexcel.AV55AlmCod = aP0_AlmCod;
         objr_resumenconsignacionexcel.AV50LinCod = aP1_LinCod;
         objr_resumenconsignacionexcel.AV51SublCod = aP2_SublCod;
         objr_resumenconsignacionexcel.AV9ProdCod = aP3_ProdCod;
         objr_resumenconsignacionexcel.AV8CliCod = aP4_CliCod;
         objr_resumenconsignacionexcel.AV11FDesde = aP5_FDesde;
         objr_resumenconsignacionexcel.AV12FHasta = aP6_FHasta;
         objr_resumenconsignacionexcel.AV39Filename = "" ;
         objr_resumenconsignacionexcel.AV16ErrorMessage = "" ;
         objr_resumenconsignacionexcel.context.SetSubmitInitialConfig(context);
         objr_resumenconsignacionexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenconsignacionexcel);
         aP0_AlmCod=this.AV55AlmCod;
         aP1_LinCod=this.AV50LinCod;
         aP2_SublCod=this.AV51SublCod;
         aP3_ProdCod=this.AV9ProdCod;
         aP4_CliCod=this.AV8CliCod;
         aP5_FDesde=this.AV11FDesde;
         aP6_FHasta=this.AV12FHasta;
         aP7_Filename=this.AV39Filename;
         aP8_ErrorMessage=this.AV16ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenconsignacionexcel)stateInfo).executePrivate();
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
         AV36Archivo.Source = "Excel/PlantillasResumenConsignaciones.xlsx";
         AV37Path = AV36Archivo.GetPath();
         AV38FilenameOrigen = StringUtil.Trim( AV37Path) + "\\PlantillasResumenConsignaciones.xlsx";
         AV39Filename = "Excel/ResumenConsignaciones" + ".xlsx";
         AV40ExcelDocument.Clear();
         AV40ExcelDocument.Template = AV38FilenameOrigen;
         AV40ExcelDocument.Open(AV39Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Using cursor P008O2 */
         pr_default.execute(0, new Object[] {AV8CliCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A45CliCod = P008O2_A45CliCod[0];
            A161CliDsc = P008O2_A161CliDsc[0];
            AV17Filtro1 = A161CliDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV44CellRow = 6;
         AV45FirstColumn = 1;
         AV24Item = 0;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV50LinCod ,
                                              AV8CliCod ,
                                              AV9ProdCod ,
                                              A52LinCod ,
                                              A15MVCliCod ,
                                              A28ProdCod ,
                                              A25MvAFec ,
                                              AV11FDesde ,
                                              AV12FHasta ,
                                              A21MvAlm ,
                                              AV55AlmCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P008O3 */
         pr_default.execute(1, new Object[] {AV11FDesde, AV12FHasta, AV55AlmCod, AV50LinCod, AV8CliCod, AV9ProdCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK8O3 = false;
            A13MvATip = P008O3_A13MvATip[0];
            A14MvACod = P008O3_A14MvACod[0];
            A21MvAlm = P008O3_A21MvAlm[0];
            A1290MVCliDsc = P008O3_A1290MVCliDsc[0];
            A15MVCliCod = P008O3_A15MVCliCod[0];
            n15MVCliCod = P008O3_n15MVCliCod[0];
            A25MvAFec = P008O3_A25MvAFec[0];
            A28ProdCod = P008O3_A28ProdCod[0];
            A52LinCod = P008O3_A52LinCod[0];
            A30MvADItem = P008O3_A30MvADItem[0];
            A21MvAlm = P008O3_A21MvAlm[0];
            A15MVCliCod = P008O3_A15MVCliCod[0];
            n15MVCliCod = P008O3_n15MVCliCod[0];
            A25MvAFec = P008O3_A25MvAFec[0];
            A1290MVCliDsc = P008O3_A1290MVCliDsc[0];
            A52LinCod = P008O3_A52LinCod[0];
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P008O3_A15MVCliCod[0], A15MVCliCod) == 0 ) )
            {
               BRK8O3 = false;
               A13MvATip = P008O3_A13MvATip[0];
               A14MvACod = P008O3_A14MvACod[0];
               A1290MVCliDsc = P008O3_A1290MVCliDsc[0];
               A30MvADItem = P008O3_A30MvADItem[0];
               A1290MVCliDsc = P008O3_A1290MVCliDsc[0];
               BRK8O3 = true;
               pr_default.readNext(1);
            }
            AV48MVCliCod = A15MVCliCod;
            AV49MVCliDsc = A1290MVCliDsc;
            /* Execute user subroutine: 'PRODUCTOS' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               this.cleanup();
               if (true) return;
            }
            if ( ! BRK8O3 )
            {
               BRK8O3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         AV40ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV40ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'PRODUCTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV50LinCod ,
                                              AV9ProdCod ,
                                              A52LinCod ,
                                              A28ProdCod ,
                                              A25MvAFec ,
                                              AV11FDesde ,
                                              AV12FHasta ,
                                              A21MvAlm ,
                                              AV55AlmCod ,
                                              A15MVCliCod ,
                                              AV48MVCliCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P008O4 */
         pr_default.execute(2, new Object[] {AV11FDesde, AV12FHasta, AV55AlmCod, AV48MVCliCod, AV50LinCod, AV9ProdCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK8O5 = false;
            A13MvATip = P008O4_A13MvATip[0];
            A14MvACod = P008O4_A14MvACod[0];
            A55ProdDsc = P008O4_A55ProdDsc[0];
            A28ProdCod = P008O4_A28ProdCod[0];
            A25MvAFec = P008O4_A25MvAFec[0];
            A15MVCliCod = P008O4_A15MVCliCod[0];
            n15MVCliCod = P008O4_n15MVCliCod[0];
            A52LinCod = P008O4_A52LinCod[0];
            A21MvAlm = P008O4_A21MvAlm[0];
            A30MvADItem = P008O4_A30MvADItem[0];
            A25MvAFec = P008O4_A25MvAFec[0];
            A15MVCliCod = P008O4_A15MVCliCod[0];
            n15MVCliCod = P008O4_n15MVCliCod[0];
            A21MvAlm = P008O4_A21MvAlm[0];
            A55ProdDsc = P008O4_A55ProdDsc[0];
            A52LinCod = P008O4_A52LinCod[0];
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P008O4_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRK8O5 = false;
               A13MvATip = P008O4_A13MvATip[0];
               A14MvACod = P008O4_A14MvACod[0];
               A55ProdDsc = P008O4_A55ProdDsc[0];
               A30MvADItem = P008O4_A30MvADItem[0];
               A55ProdDsc = P008O4_A55ProdDsc[0];
               BRK8O5 = true;
               pr_default.readNext(2);
            }
            AV46Codigo = A28ProdCod;
            AV35Producto = A55ProdDsc;
            AV52StkIng = 0;
            AV53StkSal = 0;
            AV54StkAct = 0;
            /* Execute user subroutine: 'DETALLES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'PRODUCTOSEXCEL' */
            S135 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            if ( ! BRK8O5 )
            {
               BRK8O5 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S125( )
      {
         /* 'DETALLES' Routine */
         returnInSub = false;
         /* Using cursor P008O5 */
         pr_default.execute(3, new Object[] {AV46Codigo, AV11FDesde, AV12FHasta, AV55AlmCod, AV48MVCliCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A14MvACod = P008O5_A14MvACod[0];
            A25MvAFec = P008O5_A25MvAFec[0];
            A28ProdCod = P008O5_A28ProdCod[0];
            A15MVCliCod = P008O5_A15MVCliCod[0];
            n15MVCliCod = P008O5_n15MVCliCod[0];
            A21MvAlm = P008O5_A21MvAlm[0];
            A1248MvADCant = P008O5_A1248MvADCant[0];
            A13MvATip = P008O5_A13MvATip[0];
            A30MvADItem = P008O5_A30MvADItem[0];
            A25MvAFec = P008O5_A25MvAFec[0];
            A15MVCliCod = P008O5_A15MVCliCod[0];
            n15MVCliCod = P008O5_n15MVCliCod[0];
            A21MvAlm = P008O5_A21MvAlm[0];
            AV53StkSal = (decimal)(AV53StkSal+((!(StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1248MvADCant : (decimal)(0))));
            AV52StkIng = (decimal)(AV52StkIng+(((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1248MvADCant : (decimal)(0))));
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV54StkAct = (decimal)(AV52StkIng-AV53StkSal);
      }

      protected void S135( )
      {
         /* 'PRODUCTOSEXCEL' Routine */
         returnInSub = false;
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV48MVCliCod);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+2), 1, 1).Text = StringUtil.Trim( AV46Codigo);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+3), 1, 1).Text = StringUtil.Trim( AV35Producto);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+4), 1, 1).Number = (double)(AV52StkIng);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+5), 1, 1).Number = (double)(AV53StkSal);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+6), 1, 1).Number = (double)(AV54StkAct);
         AV44CellRow = (long)(AV44CellRow+1);
      }

      protected void S141( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV40ExcelDocument.ErrCode != 0 )
         {
            AV39Filename = "";
            AV16ErrorMessage = AV40ExcelDocument.ErrDescription;
            AV40ExcelDocument.Close();
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
         AV39Filename = "";
         AV16ErrorMessage = "";
         AV36Archivo = new GxFile(context.GetPhysicalPath());
         AV37Path = "";
         AV38FilenameOrigen = "";
         AV40ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P008O2_A45CliCod = new string[] {""} ;
         P008O2_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         AV17Filtro1 = "";
         A15MVCliCod = "";
         A28ProdCod = "";
         A25MvAFec = DateTime.MinValue;
         P008O3_A13MvATip = new string[] {""} ;
         P008O3_A14MvACod = new string[] {""} ;
         P008O3_A21MvAlm = new int[1] ;
         P008O3_A1290MVCliDsc = new string[] {""} ;
         P008O3_A15MVCliCod = new string[] {""} ;
         P008O3_n15MVCliCod = new bool[] {false} ;
         P008O3_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008O3_A28ProdCod = new string[] {""} ;
         P008O3_A52LinCod = new int[1] ;
         P008O3_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A1290MVCliDsc = "";
         AV48MVCliCod = "";
         AV49MVCliDsc = "";
         P008O4_A13MvATip = new string[] {""} ;
         P008O4_A14MvACod = new string[] {""} ;
         P008O4_A55ProdDsc = new string[] {""} ;
         P008O4_A28ProdCod = new string[] {""} ;
         P008O4_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008O4_A15MVCliCod = new string[] {""} ;
         P008O4_n15MVCliCod = new bool[] {false} ;
         P008O4_A52LinCod = new int[1] ;
         P008O4_A21MvAlm = new int[1] ;
         P008O4_A30MvADItem = new int[1] ;
         A55ProdDsc = "";
         AV46Codigo = "";
         AV35Producto = "";
         P008O5_A14MvACod = new string[] {""} ;
         P008O5_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008O5_A28ProdCod = new string[] {""} ;
         P008O5_A15MVCliCod = new string[] {""} ;
         P008O5_n15MVCliCod = new bool[] {false} ;
         P008O5_A21MvAlm = new int[1] ;
         P008O5_A1248MvADCant = new decimal[1] ;
         P008O5_A13MvATip = new string[] {""} ;
         P008O5_A30MvADItem = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_resumenconsignacionexcel__default(),
            new Object[][] {
                new Object[] {
               P008O2_A45CliCod, P008O2_A161CliDsc
               }
               , new Object[] {
               P008O3_A13MvATip, P008O3_A14MvACod, P008O3_A21MvAlm, P008O3_A1290MVCliDsc, P008O3_A15MVCliCod, P008O3_n15MVCliCod, P008O3_A25MvAFec, P008O3_A28ProdCod, P008O3_A52LinCod, P008O3_A30MvADItem
               }
               , new Object[] {
               P008O4_A13MvATip, P008O4_A14MvACod, P008O4_A55ProdDsc, P008O4_A28ProdCod, P008O4_A25MvAFec, P008O4_A15MVCliCod, P008O4_n15MVCliCod, P008O4_A52LinCod, P008O4_A21MvAlm, P008O4_A30MvADItem
               }
               , new Object[] {
               P008O5_A14MvACod, P008O5_A25MvAFec, P008O5_A28ProdCod, P008O5_A15MVCliCod, P008O5_n15MVCliCod, P008O5_A21MvAlm, P008O5_A1248MvADCant, P008O5_A13MvATip, P008O5_A30MvADItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV55AlmCod ;
      private int AV50LinCod ;
      private int AV51SublCod ;
      private int AV24Item ;
      private int A52LinCod ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private long AV44CellRow ;
      private long AV45FirstColumn ;
      private decimal AV52StkIng ;
      private decimal AV53StkSal ;
      private decimal AV54StkAct ;
      private decimal A1248MvADCant ;
      private string AV9ProdCod ;
      private string AV8CliCod ;
      private string AV37Path ;
      private string scmdbuf ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A15MVCliCod ;
      private string A28ProdCod ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A1290MVCliDsc ;
      private string AV48MVCliCod ;
      private string AV49MVCliDsc ;
      private string A55ProdDsc ;
      private string AV46Codigo ;
      private string AV35Producto ;
      private DateTime AV11FDesde ;
      private DateTime AV12FHasta ;
      private DateTime A25MvAFec ;
      private bool returnInSub ;
      private bool BRK8O3 ;
      private bool n15MVCliCod ;
      private bool BRK8O5 ;
      private string AV39Filename ;
      private string AV16ErrorMessage ;
      private string AV38FilenameOrigen ;
      private string AV17Filtro1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_AlmCod ;
      private int aP1_LinCod ;
      private int aP2_SublCod ;
      private string aP3_ProdCod ;
      private string aP4_CliCod ;
      private DateTime aP5_FDesde ;
      private DateTime aP6_FHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P008O2_A45CliCod ;
      private string[] P008O2_A161CliDsc ;
      private string[] P008O3_A13MvATip ;
      private string[] P008O3_A14MvACod ;
      private int[] P008O3_A21MvAlm ;
      private string[] P008O3_A1290MVCliDsc ;
      private string[] P008O3_A15MVCliCod ;
      private bool[] P008O3_n15MVCliCod ;
      private DateTime[] P008O3_A25MvAFec ;
      private string[] P008O3_A28ProdCod ;
      private int[] P008O3_A52LinCod ;
      private int[] P008O3_A30MvADItem ;
      private string[] P008O4_A13MvATip ;
      private string[] P008O4_A14MvACod ;
      private string[] P008O4_A55ProdDsc ;
      private string[] P008O4_A28ProdCod ;
      private DateTime[] P008O4_A25MvAFec ;
      private string[] P008O4_A15MVCliCod ;
      private bool[] P008O4_n15MVCliCod ;
      private int[] P008O4_A52LinCod ;
      private int[] P008O4_A21MvAlm ;
      private int[] P008O4_A30MvADItem ;
      private string[] P008O5_A14MvACod ;
      private DateTime[] P008O5_A25MvAFec ;
      private string[] P008O5_A28ProdCod ;
      private string[] P008O5_A15MVCliCod ;
      private bool[] P008O5_n15MVCliCod ;
      private int[] P008O5_A21MvAlm ;
      private decimal[] P008O5_A1248MvADCant ;
      private string[] P008O5_A13MvATip ;
      private int[] P008O5_A30MvADItem ;
      private string aP7_Filename ;
      private string aP8_ErrorMessage ;
      private ExcelDocumentI AV40ExcelDocument ;
      private GxFile AV36Archivo ;
   }

   public class r_resumenconsignacionexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008O3( IGxContext context ,
                                             int AV50LinCod ,
                                             string AV8CliCod ,
                                             string AV9ProdCod ,
                                             int A52LinCod ,
                                             string A15MVCliCod ,
                                             string A28ProdCod ,
                                             DateTime A25MvAFec ,
                                             DateTime AV11FDesde ,
                                             DateTime AV12FHasta ,
                                             int A21MvAlm ,
                                             int AV55AlmCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T2.[MvAlm], T3.[CliDsc] AS MVCliDsc, T2.[MVCliCod] AS MVCliCod, T2.[MvAFec], T1.[ProdCod], T4.[LinCod], T1.[MvADItem] FROM ((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) LEFT JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T2.[MVCliCod]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod])";
         AddWhere(sWhereString, "(T2.[MvAFec] >= @AV11FDesde)");
         AddWhere(sWhereString, "(T2.[MvAFec] <= @AV12FHasta)");
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV55AlmCod)");
         if ( ! (0==AV50LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV50LinCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[MVCliCod] = @AV8CliCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV9ProdCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[MVCliCod], T3.[CliDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008O4( IGxContext context ,
                                             int AV50LinCod ,
                                             string AV9ProdCod ,
                                             int A52LinCod ,
                                             string A28ProdCod ,
                                             DateTime A25MvAFec ,
                                             DateTime AV11FDesde ,
                                             DateTime AV12FHasta ,
                                             int A21MvAlm ,
                                             int AV55AlmCod ,
                                             string A15MVCliCod ,
                                             string AV48MVCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T3.[ProdDsc], T1.[ProdCod], T2.[MvAFec], T2.[MVCliCod] AS MVCliCod, T3.[LinCod], T2.[MvAlm], T1.[MvADItem] FROM (([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod])";
         AddWhere(sWhereString, "(T2.[MvAFec] >= @AV11FDesde)");
         AddWhere(sWhereString, "(T2.[MvAFec] <= @AV12FHasta)");
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV55AlmCod)");
         AddWhere(sWhereString, "(T2.[MVCliCod] = @AV48MVCliCod)");
         if ( ! (0==AV50LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV50LinCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV9ProdCod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T3.[ProdDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P008O3(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
               case 2 :
                     return conditional_P008O4(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
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
          Object[] prmP008O2;
          prmP008O2 = new Object[] {
          new ParDef("@AV8CliCod",GXType.NChar,20,0)
          };
          Object[] prmP008O5;
          prmP008O5 = new Object[] {
          new ParDef("@AV46Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV11FDesde",GXType.Date,8,0) ,
          new ParDef("@AV12FHasta",GXType.Date,8,0) ,
          new ParDef("@AV55AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV48MVCliCod",GXType.NChar,20,0)
          };
          Object[] prmP008O3;
          prmP008O3 = new Object[] {
          new ParDef("@AV11FDesde",GXType.Date,8,0) ,
          new ParDef("@AV12FHasta",GXType.Date,8,0) ,
          new ParDef("@AV55AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV50LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV8CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV9ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP008O4;
          prmP008O4 = new Object[] {
          new ParDef("@AV11FDesde",GXType.Date,8,0) ,
          new ParDef("@AV12FHasta",GXType.Date,8,0) ,
          new ParDef("@AV55AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV48MVCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV50LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV9ProdCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008O2", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV8CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008O2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008O3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008O4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008O4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008O5", "SELECT T1.[MvACod], T2.[MvAFec], T1.[ProdCod], T2.[MVCliCod] AS MVCliCod, T2.[MvAlm], T1.[MvADCant], T1.[MvATip], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T1.[ProdCod] = @AV46Codigo) AND (T2.[MvAFec] >= @AV11FDesde) AND (T2.[MvAFec] <= @AV12FHasta) AND (T2.[MvAlm] = @AV55AlmCod) AND (T2.[MVCliCod] = @AV48MVCliCod) ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008O5,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 15);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
       }
    }

 }

}
