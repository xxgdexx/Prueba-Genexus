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
namespace GeneXus.Programs.contabilidad {
   public class r_reporteflujocajaexcel : GXProcedure
   {
      public r_reporteflujocajaexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reporteflujocajaexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FDesde ,
                           ref DateTime aP1_FHasta ,
                           ref string aP2_CosCod ,
                           ref int aP3_Moneda ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV79FDesde = aP0_FDesde;
         this.AV80FHasta = aP1_FHasta;
         this.AV81CosCod = aP2_CosCod;
         this.AV82Moneda = aP3_Moneda;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_FDesde=this.AV79FDesde;
         aP1_FHasta=this.AV80FHasta;
         aP2_CosCod=this.AV81CosCod;
         aP3_Moneda=this.AV82Moneda;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref DateTime aP0_FDesde ,
                                ref DateTime aP1_FHasta ,
                                ref string aP2_CosCod ,
                                ref int aP3_Moneda ,
                                out string aP4_Filename )
      {
         execute(ref aP0_FDesde, ref aP1_FHasta, ref aP2_CosCod, ref aP3_Moneda, out aP4_Filename, out aP5_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref DateTime aP0_FDesde ,
                                 ref DateTime aP1_FHasta ,
                                 ref string aP2_CosCod ,
                                 ref int aP3_Moneda ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         r_reporteflujocajaexcel objr_reporteflujocajaexcel;
         objr_reporteflujocajaexcel = new r_reporteflujocajaexcel();
         objr_reporteflujocajaexcel.AV79FDesde = aP0_FDesde;
         objr_reporteflujocajaexcel.AV80FHasta = aP1_FHasta;
         objr_reporteflujocajaexcel.AV81CosCod = aP2_CosCod;
         objr_reporteflujocajaexcel.AV82Moneda = aP3_Moneda;
         objr_reporteflujocajaexcel.AV10Filename = "" ;
         objr_reporteflujocajaexcel.AV11ErrorMessage = "" ;
         objr_reporteflujocajaexcel.context.SetSubmitInitialConfig(context);
         objr_reporteflujocajaexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reporteflujocajaexcel);
         aP0_FDesde=this.AV79FDesde;
         aP1_FHasta=this.AV80FHasta;
         aP2_CosCod=this.AV81CosCod;
         aP3_Moneda=this.AV82Moneda;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reporteflujocajaexcel)stateInfo).executePrivate();
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
         AV78Empresa = "RAZON SOCIAL : " + AV77Session.Get("Empresa");
         AV73Archivo.Source = "Excel/PlantillasFlujo.xlsx";
         AV72Path = AV73Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV72Path) + "\\PlantillasFlujo.xlsx";
         AV10Filename = "Excel/FlujoCaja" + ".xlsx";
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
         AV14CellRow = 2;
         AV15FirstColumn = 0;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "FLUJO DE CAJA DEL : "+context.localUtil.DToC( AV79FDesde, 2, "/")+" AL : "+context.localUtil.DToC( AV80FHasta, 2, "/");
         AV14CellRow = 5;
         AV15FirstColumn = 1;
         /* Execute user subroutine: 'FLUJOCAJA' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = (int)(AV14CellRow+1);
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
         /* 'FLUJOCAJA' Routine */
         returnInSub = false;
         AV76Tipo = "INGRESOS";
         AV90CBFlujTip = "I";
         AV91TotIng = 0.00m;
         AV89Totales = 0.00m;
         /* Using cursor P00CZ2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2269CBFlujTip = P00CZ2_A2269CBFlujTip[0];
            A2277CBFlujDsc = P00CZ2_A2277CBFlujDsc[0];
            A2270CBFlujCod = P00CZ2_A2270CBFlujCod[0];
            AV83Rubro = A2277CBFlujDsc;
            AV92CBFlujCod = A2270CBFlujCod;
            AV86TotRubros = 0.00m;
            /* Using cursor P00CZ3 */
            pr_default.execute(1, new Object[] {AV92CBFlujCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A2270CBFlujCod = P00CZ3_A2270CBFlujCod[0];
               A2269CBFlujTip = P00CZ3_A2269CBFlujTip[0];
               A2276CBFlujCDsc = P00CZ3_A2276CBFlujCDsc[0];
               A2271CBFlujCCod = P00CZ3_A2271CBFlujCCod[0];
               AV88CBFlujCCod = A2271CBFlujCCod;
               AV84Lineas = A2276CBFlujCDsc;
               /* Execute user subroutine: 'IMPORTE' */
               S133 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'DETALLES' */
               S143 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               AV91TotIng = (decimal)(AV91TotIng+AV85Total);
               AV86TotRubros = (decimal)(AV86TotRubros+AV85Total);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV89Totales = AV91TotIng;
         AV76Tipo = "EGRESOS";
         AV90CBFlujTip = "E";
         AV87TotEgr = 0.00m;
         /* Using cursor P00CZ4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A2269CBFlujTip = P00CZ4_A2269CBFlujTip[0];
            A2277CBFlujDsc = P00CZ4_A2277CBFlujDsc[0];
            A2270CBFlujCod = P00CZ4_A2270CBFlujCod[0];
            AV83Rubro = A2277CBFlujDsc;
            AV92CBFlujCod = A2270CBFlujCod;
            AV86TotRubros = 0.00m;
            /* Using cursor P00CZ5 */
            pr_default.execute(3, new Object[] {AV92CBFlujCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A2270CBFlujCod = P00CZ5_A2270CBFlujCod[0];
               A2269CBFlujTip = P00CZ5_A2269CBFlujTip[0];
               A2276CBFlujCDsc = P00CZ5_A2276CBFlujCDsc[0];
               A2271CBFlujCCod = P00CZ5_A2271CBFlujCCod[0];
               AV88CBFlujCCod = A2271CBFlujCCod;
               AV84Lineas = A2276CBFlujCDsc;
               /* Execute user subroutine: 'IMPORTE' */
               S133 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'DETALLES' */
               S143 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  returnInSub = true;
                  if (true) return;
               }
               AV87TotEgr = (decimal)(AV87TotEgr+AV85Total);
               AV86TotRubros = (decimal)(AV86TotRubros+AV85Total);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV89Totales = AV87TotEgr;
      }

      protected void S143( )
      {
         /* 'DETALLES' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV76Tipo);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV83Rubro);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV84Lineas);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV85Total);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S133( )
      {
         /* 'IMPORTE' Routine */
         returnInSub = false;
         AV85Total = 0.00m;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV81CosCod ,
                                              A79COSCod ,
                                              A1079LBFech ,
                                              AV79FDesde ,
                                              AV80FHasta ,
                                              AV90CBFlujTip ,
                                              AV92CBFlujCod ,
                                              AV88CBFlujCCod ,
                                              A2269CBFlujTip ,
                                              A2270CBFlujCod ,
                                              A2271CBFlujCCod } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00CZ6 */
         pr_default.execute(4, new Object[] {AV90CBFlujTip, AV92CBFlujCod, AV88CBFlujCCod, AV79FDesde, AV80FHasta, AV81CosCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A2265CBFlujCBanCod = P00CZ6_A2265CBFlujCBanCod[0];
            A2266CBFlujCCuenta = P00CZ6_A2266CBFlujCCuenta[0];
            A2267CBFlujCRegistro = P00CZ6_A2267CBFlujCRegistro[0];
            A79COSCod = P00CZ6_A79COSCod[0];
            A1079LBFech = P00CZ6_A1079LBFech[0];
            n1079LBFech = P00CZ6_n1079LBFech[0];
            A2271CBFlujCCod = P00CZ6_A2271CBFlujCCod[0];
            A2270CBFlujCod = P00CZ6_A2270CBFlujCod[0];
            A2269CBFlujTip = P00CZ6_A2269CBFlujTip[0];
            A2272CBFlujCMonCod = P00CZ6_A2272CBFlujCMonCod[0];
            A2275CBFlujCCosto = P00CZ6_A2275CBFlujCCosto[0];
            A1091LBTipCmb = P00CZ6_A1091LBTipCmb[0];
            n1091LBTipCmb = P00CZ6_n1091LBTipCmb[0];
            A2263CBFlujCAno = P00CZ6_A2263CBFlujCAno[0];
            A2264CBFlujCMes = P00CZ6_A2264CBFlujCMes[0];
            A2268CBFlujCItem = P00CZ6_A2268CBFlujCItem[0];
            A2272CBFlujCMonCod = P00CZ6_A2272CBFlujCMonCod[0];
            A1079LBFech = P00CZ6_A1079LBFech[0];
            n1079LBFech = P00CZ6_n1079LBFech[0];
            A1091LBTipCmb = P00CZ6_A1091LBTipCmb[0];
            n1091LBTipCmb = P00CZ6_n1091LBTipCmb[0];
            AV93LBFech = A1079LBFech;
            AV61MonCod = A2272CBFlujCMonCod;
            AV94Importe = A2275CBFlujCCosto;
            AV95LBTipCmb = A1091LBTipCmb;
            if ( AV82Moneda != AV61MonCod )
            {
               if ( AV82Moneda == 1 )
               {
                  AV94Importe = NumberUtil.Round( AV94Importe*AV62TipVenta, 2);
               }
               else
               {
                  AV94Importe = NumberUtil.Round( AV94Importe/ (decimal)(AV62TipVenta), 2);
               }
            }
            AV85Total = (decimal)(AV85Total+AV94Importe);
            pr_default.readNext(4);
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
         AV10Filename = "";
         AV11ErrorMessage = "";
         AV78Empresa = "";
         AV77Session = context.GetSession();
         AV73Archivo = new GxFile(context.GetPhysicalPath());
         AV72Path = "";
         AV70FilenameOrigen = "";
         AV13ExcelDocument = new ExcelDocumentI();
         AV76Tipo = "";
         AV90CBFlujTip = "";
         scmdbuf = "";
         P00CZ2_A2269CBFlujTip = new string[] {""} ;
         P00CZ2_A2277CBFlujDsc = new string[] {""} ;
         P00CZ2_A2270CBFlujCod = new string[] {""} ;
         A2269CBFlujTip = "";
         A2277CBFlujDsc = "";
         A2270CBFlujCod = "";
         AV83Rubro = "";
         AV92CBFlujCod = "";
         P00CZ3_A2270CBFlujCod = new string[] {""} ;
         P00CZ3_A2269CBFlujTip = new string[] {""} ;
         P00CZ3_A2276CBFlujCDsc = new string[] {""} ;
         P00CZ3_A2271CBFlujCCod = new string[] {""} ;
         A2276CBFlujCDsc = "";
         A2271CBFlujCCod = "";
         AV88CBFlujCCod = "";
         AV84Lineas = "";
         P00CZ4_A2269CBFlujTip = new string[] {""} ;
         P00CZ4_A2277CBFlujDsc = new string[] {""} ;
         P00CZ4_A2270CBFlujCod = new string[] {""} ;
         P00CZ5_A2270CBFlujCod = new string[] {""} ;
         P00CZ5_A2269CBFlujTip = new string[] {""} ;
         P00CZ5_A2276CBFlujCDsc = new string[] {""} ;
         P00CZ5_A2271CBFlujCCod = new string[] {""} ;
         A79COSCod = "";
         A1079LBFech = DateTime.MinValue;
         P00CZ6_A2265CBFlujCBanCod = new int[1] ;
         P00CZ6_A2266CBFlujCCuenta = new string[] {""} ;
         P00CZ6_A2267CBFlujCRegistro = new string[] {""} ;
         P00CZ6_A79COSCod = new string[] {""} ;
         P00CZ6_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P00CZ6_n1079LBFech = new bool[] {false} ;
         P00CZ6_A2271CBFlujCCod = new string[] {""} ;
         P00CZ6_A2270CBFlujCod = new string[] {""} ;
         P00CZ6_A2269CBFlujTip = new string[] {""} ;
         P00CZ6_A2272CBFlujCMonCod = new int[1] ;
         P00CZ6_A2275CBFlujCCosto = new decimal[1] ;
         P00CZ6_A1091LBTipCmb = new decimal[1] ;
         P00CZ6_n1091LBTipCmb = new bool[] {false} ;
         P00CZ6_A2263CBFlujCAno = new short[1] ;
         P00CZ6_A2264CBFlujCMes = new short[1] ;
         P00CZ6_A2268CBFlujCItem = new int[1] ;
         A2266CBFlujCCuenta = "";
         A2267CBFlujCRegistro = "";
         AV93LBFech = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_reporteflujocajaexcel__default(),
            new Object[][] {
                new Object[] {
               P00CZ2_A2269CBFlujTip, P00CZ2_A2277CBFlujDsc, P00CZ2_A2270CBFlujCod
               }
               , new Object[] {
               P00CZ3_A2270CBFlujCod, P00CZ3_A2269CBFlujTip, P00CZ3_A2276CBFlujCDsc, P00CZ3_A2271CBFlujCCod
               }
               , new Object[] {
               P00CZ4_A2269CBFlujTip, P00CZ4_A2277CBFlujDsc, P00CZ4_A2270CBFlujCod
               }
               , new Object[] {
               P00CZ5_A2270CBFlujCod, P00CZ5_A2269CBFlujTip, P00CZ5_A2276CBFlujCDsc, P00CZ5_A2271CBFlujCCod
               }
               , new Object[] {
               P00CZ6_A2265CBFlujCBanCod, P00CZ6_A2266CBFlujCCuenta, P00CZ6_A2267CBFlujCRegistro, P00CZ6_A79COSCod, P00CZ6_A1079LBFech, P00CZ6_n1079LBFech, P00CZ6_A2271CBFlujCCod, P00CZ6_A2270CBFlujCod, P00CZ6_A2269CBFlujTip, P00CZ6_A2272CBFlujCMonCod,
               P00CZ6_A2275CBFlujCCosto, P00CZ6_A1091LBTipCmb, P00CZ6_n1091LBTipCmb, P00CZ6_A2263CBFlujCAno, P00CZ6_A2264CBFlujCMes, P00CZ6_A2268CBFlujCItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A2263CBFlujCAno ;
      private short A2264CBFlujCMes ;
      private int AV82Moneda ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A2265CBFlujCBanCod ;
      private int A2272CBFlujCMonCod ;
      private int A2268CBFlujCItem ;
      private int AV61MonCod ;
      private decimal AV91TotIng ;
      private decimal AV89Totales ;
      private decimal AV86TotRubros ;
      private decimal AV85Total ;
      private decimal AV87TotEgr ;
      private decimal A2275CBFlujCCosto ;
      private decimal A1091LBTipCmb ;
      private decimal AV94Importe ;
      private decimal AV95LBTipCmb ;
      private decimal AV62TipVenta ;
      private string AV81CosCod ;
      private string AV78Empresa ;
      private string AV72Path ;
      private string AV76Tipo ;
      private string AV90CBFlujTip ;
      private string scmdbuf ;
      private string A2269CBFlujTip ;
      private string A2277CBFlujDsc ;
      private string A2270CBFlujCod ;
      private string AV92CBFlujCod ;
      private string A2276CBFlujCDsc ;
      private string A2271CBFlujCCod ;
      private string AV88CBFlujCCod ;
      private string A79COSCod ;
      private string A2266CBFlujCCuenta ;
      private string A2267CBFlujCRegistro ;
      private DateTime AV79FDesde ;
      private DateTime AV80FHasta ;
      private DateTime A1079LBFech ;
      private DateTime AV93LBFech ;
      private bool returnInSub ;
      private bool n1079LBFech ;
      private bool n1091LBTipCmb ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private string AV83Rubro ;
      private string AV84Lineas ;
      private IGxSession AV77Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FDesde ;
      private DateTime aP1_FHasta ;
      private string aP2_CosCod ;
      private int aP3_Moneda ;
      private IDataStoreProvider pr_default ;
      private string[] P00CZ2_A2269CBFlujTip ;
      private string[] P00CZ2_A2277CBFlujDsc ;
      private string[] P00CZ2_A2270CBFlujCod ;
      private string[] P00CZ3_A2270CBFlujCod ;
      private string[] P00CZ3_A2269CBFlujTip ;
      private string[] P00CZ3_A2276CBFlujCDsc ;
      private string[] P00CZ3_A2271CBFlujCCod ;
      private string[] P00CZ4_A2269CBFlujTip ;
      private string[] P00CZ4_A2277CBFlujDsc ;
      private string[] P00CZ4_A2270CBFlujCod ;
      private string[] P00CZ5_A2270CBFlujCod ;
      private string[] P00CZ5_A2269CBFlujTip ;
      private string[] P00CZ5_A2276CBFlujCDsc ;
      private string[] P00CZ5_A2271CBFlujCCod ;
      private int[] P00CZ6_A2265CBFlujCBanCod ;
      private string[] P00CZ6_A2266CBFlujCCuenta ;
      private string[] P00CZ6_A2267CBFlujCRegistro ;
      private string[] P00CZ6_A79COSCod ;
      private DateTime[] P00CZ6_A1079LBFech ;
      private bool[] P00CZ6_n1079LBFech ;
      private string[] P00CZ6_A2271CBFlujCCod ;
      private string[] P00CZ6_A2270CBFlujCod ;
      private string[] P00CZ6_A2269CBFlujTip ;
      private int[] P00CZ6_A2272CBFlujCMonCod ;
      private decimal[] P00CZ6_A2275CBFlujCCosto ;
      private decimal[] P00CZ6_A1091LBTipCmb ;
      private bool[] P00CZ6_n1091LBTipCmb ;
      private short[] P00CZ6_A2263CBFlujCAno ;
      private short[] P00CZ6_A2264CBFlujCMes ;
      private int[] P00CZ6_A2268CBFlujCItem ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV73Archivo ;
   }

   public class r_reporteflujocajaexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CZ6( IGxContext context ,
                                             string AV81CosCod ,
                                             string A79COSCod ,
                                             DateTime A1079LBFech ,
                                             DateTime AV79FDesde ,
                                             DateTime AV80FHasta ,
                                             string AV90CBFlujTip ,
                                             string AV92CBFlujCod ,
                                             string AV88CBFlujCCod ,
                                             string A2269CBFlujTip ,
                                             string A2270CBFlujCod ,
                                             string A2271CBFlujCCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CBFlujCBanCod] AS CBFlujCBanCod, T1.[CBFlujCCuenta] AS CBFlujCCuenta, T1.[CBFlujCRegistro] AS CBFlujCRegistro, T1.[COSCod], T3.[LBFech], T1.[CBFlujCCod], T1.[CBFlujCod], T1.[CBFlujTip], T2.[MonCod] AS CBFlujCMonCod, T1.[CBFlujCCosto], T3.[LBTipCmb], T1.[CBFlujCAno], T1.[CBFlujCMes], T1.[CBFlujCItem] FROM (([CBFLUJOCONCEPTOSDET] T1 INNER JOIN [TSCUENTABANCO] T2 ON T2.[BanCod] = T1.[CBFlujCBanCod] AND T2.[CBCod] = T1.[CBFlujCCuenta]) INNER JOIN [TSLIBROBANCOS] T3 ON T3.[LBBanCod] = T1.[CBFlujCBanCod] AND T3.[LBCBCod] = T1.[CBFlujCCuenta] AND T3.[LBRegistro] = T1.[CBFlujCRegistro])";
         AddWhere(sWhereString, "(T1.[CBFlujTip] = @AV90CBFlujTip and T1.[CBFlujCod] = @AV92CBFlujCod and T1.[CBFlujCCod] = @AV88CBFlujCCod)");
         AddWhere(sWhereString, "(T3.[LBFech] >= @AV79FDesde)");
         AddWhere(sWhereString, "(T3.[LBFech] <= @AV80FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81CosCod)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV81CosCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CBFlujTip], T1.[CBFlujCod], T1.[CBFlujCCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 4 :
                     return conditional_P00CZ6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
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
          Object[] prmP00CZ2;
          prmP00CZ2 = new Object[] {
          };
          Object[] prmP00CZ3;
          prmP00CZ3 = new Object[] {
          new ParDef("@AV92CBFlujCod",GXType.NChar,5,0)
          };
          Object[] prmP00CZ4;
          prmP00CZ4 = new Object[] {
          };
          Object[] prmP00CZ5;
          prmP00CZ5 = new Object[] {
          new ParDef("@AV92CBFlujCod",GXType.NChar,5,0)
          };
          Object[] prmP00CZ6;
          prmP00CZ6 = new Object[] {
          new ParDef("@AV90CBFlujTip",GXType.NChar,1,0) ,
          new ParDef("@AV92CBFlujCod",GXType.NChar,5,0) ,
          new ParDef("@AV88CBFlujCCod",GXType.NChar,5,0) ,
          new ParDef("@AV79FDesde",GXType.Date,8,0) ,
          new ParDef("@AV80FHasta",GXType.Date,8,0) ,
          new ParDef("@AV81CosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CZ2", "SELECT [CBFlujTip], [CBFlujDsc], [CBFlujCod] FROM [CBFLUJOTITULO] WHERE [CBFlujTip] = 'I' ORDER BY [CBFlujTip], [CBFlujCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CZ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CZ3", "SELECT [CBFlujCod], [CBFlujTip], [CBFlujCDsc], [CBFlujCCod] FROM [CBFLUJOTITULODET] WHERE [CBFlujTip] = 'I' and [CBFlujCod] = @AV92CBFlujCod ORDER BY [CBFlujTip], [CBFlujCod], [CBFlujCCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CZ3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CZ4", "SELECT [CBFlujTip], [CBFlujDsc], [CBFlujCod] FROM [CBFLUJOTITULO] WHERE [CBFlujTip] = 'E' ORDER BY [CBFlujTip], [CBFlujCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CZ4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CZ5", "SELECT [CBFlujCod], [CBFlujTip], [CBFlujCDsc], [CBFlujCCod] FROM [CBFLUJOTITULODET] WHERE [CBFlujTip] = 'E' and [CBFlujCod] = @AV92CBFlujCod ORDER BY [CBFlujTip], [CBFlujCod], [CBFlujCCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CZ5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CZ6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CZ6,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 5);
                ((string[]) buf[7])[0] = rslt.getString(7, 5);
                ((string[]) buf[8])[0] = rslt.getString(8, 1);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((short[]) buf[13])[0] = rslt.getShort(12);
                ((short[]) buf[14])[0] = rslt.getShort(13);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
