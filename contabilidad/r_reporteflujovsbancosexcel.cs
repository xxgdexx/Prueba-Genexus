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
   public class r_reporteflujovsbancosexcel : GXProcedure
   {
      public r_reporteflujovsbancosexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reporteflujovsbancosexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_BanCod ,
                           ref DateTime aP1_FDesde ,
                           ref DateTime aP2_FHasta ,
                           ref string aP3_LBCBCod ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV95BanCod = aP0_BanCod;
         this.AV79FDesde = aP1_FDesde;
         this.AV80FHasta = aP2_FHasta;
         this.AV96LBCBCod = aP3_LBCBCod;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_BanCod=this.AV95BanCod;
         aP1_FDesde=this.AV79FDesde;
         aP2_FHasta=this.AV80FHasta;
         aP3_LBCBCod=this.AV96LBCBCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref int aP0_BanCod ,
                                ref DateTime aP1_FDesde ,
                                ref DateTime aP2_FHasta ,
                                ref string aP3_LBCBCod ,
                                out string aP4_Filename )
      {
         execute(ref aP0_BanCod, ref aP1_FDesde, ref aP2_FHasta, ref aP3_LBCBCod, out aP4_Filename, out aP5_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_BanCod ,
                                 ref DateTime aP1_FDesde ,
                                 ref DateTime aP2_FHasta ,
                                 ref string aP3_LBCBCod ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         r_reporteflujovsbancosexcel objr_reporteflujovsbancosexcel;
         objr_reporteflujovsbancosexcel = new r_reporteflujovsbancosexcel();
         objr_reporteflujovsbancosexcel.AV95BanCod = aP0_BanCod;
         objr_reporteflujovsbancosexcel.AV79FDesde = aP1_FDesde;
         objr_reporteflujovsbancosexcel.AV80FHasta = aP2_FHasta;
         objr_reporteflujovsbancosexcel.AV96LBCBCod = aP3_LBCBCod;
         objr_reporteflujovsbancosexcel.AV10Filename = "" ;
         objr_reporteflujovsbancosexcel.AV11ErrorMessage = "" ;
         objr_reporteflujovsbancosexcel.context.SetSubmitInitialConfig(context);
         objr_reporteflujovsbancosexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reporteflujovsbancosexcel);
         aP0_BanCod=this.AV95BanCod;
         aP1_FDesde=this.AV79FDesde;
         aP2_FHasta=this.AV80FHasta;
         aP3_LBCBCod=this.AV96LBCBCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reporteflujovsbancosexcel)stateInfo).executePrivate();
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
         AV73Archivo.Source = "Excel/PlantillasFlujoBancos.xlsx";
         AV72Path = AV73Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV72Path) + "\\PlantillasFlujoBancos.xlsx";
         AV10Filename = "Excel/FlujoCajaBancos" + ".xlsx";
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
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "RESUMEN DE BANCOS VS FLUJO DE CAJA : "+context.localUtil.DToC( AV79FDesde, 2, "/")+" AL : "+context.localUtil.DToC( AV80FHasta, 2, "/");
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
         AV104Saldo = 0.00m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV95BanCod ,
                                              AV96LBCBCod ,
                                              A379LBBanCod ,
                                              A380LBCBCod ,
                                              A1079LBFech ,
                                              AV79FDesde ,
                                              AV80FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00D12 */
         pr_default.execute(0, new Object[] {AV79FDesde, AV80FHasta, AV95BanCod, AV96LBCBCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1085LBMonCod = P00D12_A1085LBMonCod[0];
            A1079LBFech = P00D12_A1079LBFech[0];
            n1079LBFech = P00D12_n1079LBFech[0];
            A380LBCBCod = P00D12_A380LBCBCod[0];
            A379LBBanCod = P00D12_A379LBBanCod[0];
            A1053LBBanAbr = P00D12_A1053LBBanAbr[0];
            A1233MonAbr = P00D12_A1233MonAbr[0];
            n1233MonAbr = P00D12_n1233MonAbr[0];
            A1057LBConcepto = P00D12_A1057LBConcepto[0];
            A1054LBBeneficia = P00D12_A1054LBBeneficia[0];
            A1075LBDocumento = P00D12_A1075LBDocumento[0];
            A381LBRegistro = P00D12_A381LBRegistro[0];
            A1073LBTHaber = P00D12_A1073LBTHaber[0];
            A1072LBTDebe = P00D12_A1072LBTDebe[0];
            A1070LBTipo = P00D12_A1070LBTipo[0];
            A1053LBBanAbr = P00D12_A1053LBBanAbr[0];
            A1085LBMonCod = P00D12_A1085LBMonCod[0];
            A1233MonAbr = P00D12_A1233MonAbr[0];
            n1233MonAbr = P00D12_n1233MonAbr[0];
            A1071LBTSaldo = (((A1072LBTDebe-A1073LBTHaber)<Convert.ToDecimal(0)) ? (A1072LBTDebe-A1073LBTHaber)*-1 : (((A1073LBTHaber-A1072LBTDebe)<Convert.ToDecimal(0)) ? (A1073LBTHaber-A1072LBTDebe)*-1 : A1072LBTDebe-A1073LBTHaber));
            A1082LBHaberTot = ((A1070LBTipo==0) ? A1071LBTSaldo : (decimal)(0));
            A1069LBDebeTot = ((A1070LBTipo==1) ? A1071LBTSaldo : (decimal)(0));
            AV98LBBanCod = A379LBBanCod;
            AV97BanAbr = StringUtil.Trim( A1053LBBanAbr);
            AV53MonAbr = StringUtil.Trim( A1233MonAbr);
            AV100LBRegistro = A381LBRegistro;
            AV93LBFech = A1079LBFech;
            AV99CTBco = A380LBCBCod;
            AV26Debe = A1069LBDebeTot;
            AV27Haber = A1082LBHaberTot;
            AV108Mov = (decimal)(AV26Debe-AV27Haber);
            AV109Mov2 = ((AV108Mov<Convert.ToDecimal(0)) ? AV108Mov*-1 : AV108Mov);
            AV104Saldo = (decimal)(AV104Saldo+AV108Mov);
            AV102LBConcepto = StringUtil.Trim( A1057LBConcepto);
            AV103LBBeneficia = StringUtil.Trim( A1054LBBeneficia);
            AV101LBDocumento = StringUtil.Trim( A1075LBDocumento);
            AV113COSDsc = "";
            /* Execute user subroutine: 'IMPORTE' */
            S132 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV105Dif = (decimal)(AV109Mov2-AV85Total);
            AV106TDif = (decimal)(AV106TDif+AV105Dif);
            AV107TTotal = (decimal)(AV107TTotal+AV85Total);
            /* Execute user subroutine: 'DETALLES' */
            S142 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S132( )
      {
         /* 'IMPORTE' Routine */
         returnInSub = false;
         AV85Total = 0.00m;
         AV110CBFlujDsc = "";
         AV111CBFlujCDsc = "";
         /* Using cursor P00D13 */
         pr_default.execute(1, new Object[] {AV98LBBanCod, AV99CTBco, AV100LBRegistro});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A2269CBFlujTip = P00D13_A2269CBFlujTip[0];
            A2270CBFlujCod = P00D13_A2270CBFlujCod[0];
            A2271CBFlujCCod = P00D13_A2271CBFlujCCod[0];
            A2267CBFlujCRegistro = P00D13_A2267CBFlujCRegistro[0];
            A2266CBFlujCCuenta = P00D13_A2266CBFlujCCuenta[0];
            A2265CBFlujCBanCod = P00D13_A2265CBFlujCBanCod[0];
            A1079LBFech = P00D13_A1079LBFech[0];
            n1079LBFech = P00D13_n1079LBFech[0];
            A2272CBFlujCMonCod = P00D13_A2272CBFlujCMonCod[0];
            A2275CBFlujCCosto = P00D13_A2275CBFlujCCosto[0];
            A2277CBFlujDsc = P00D13_A2277CBFlujDsc[0];
            A2276CBFlujCDsc = P00D13_A2276CBFlujCDsc[0];
            A79COSCod = P00D13_A79COSCod[0];
            A2263CBFlujCAno = P00D13_A2263CBFlujCAno[0];
            A2264CBFlujCMes = P00D13_A2264CBFlujCMes[0];
            A2268CBFlujCItem = P00D13_A2268CBFlujCItem[0];
            A2277CBFlujDsc = P00D13_A2277CBFlujDsc[0];
            A2276CBFlujCDsc = P00D13_A2276CBFlujCDsc[0];
            A1079LBFech = P00D13_A1079LBFech[0];
            n1079LBFech = P00D13_n1079LBFech[0];
            A2272CBFlujCMonCod = P00D13_A2272CBFlujCMonCod[0];
            AV93LBFech = A1079LBFech;
            AV61MonCod = A2272CBFlujCMonCod;
            AV94Importe = A2275CBFlujCCosto;
            AV110CBFlujDsc = A2277CBFlujDsc;
            AV111CBFlujCDsc = A2276CBFlujCDsc;
            AV81CosCod = A79COSCod;
            /* Execute user subroutine: 'CENTROCOSTO' */
            S153 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV85Total = (decimal)(AV85Total+AV94Importe);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S153( )
      {
         /* 'CENTROCOSTO' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81CosCod)) )
         {
            /* Using cursor P00D14 */
            pr_default.execute(2, new Object[] {AV81CosCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A79COSCod = P00D14_A79COSCod[0];
               A761COSDsc = P00D14_A761COSDsc[0];
               AV113COSDsc = A761COSDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
      }

      protected void S142( )
      {
         /* 'DETALLES' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV97BanAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV99CTBco);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV100LBRegistro);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV101LBDocumento);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV110CBFlujDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV111CBFlujCDsc);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV93LBFech ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Date = GXt_dtime1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV102LBConcepto);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Text = StringUtil.Trim( AV103LBBeneficia);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Text = StringUtil.Trim( AV113COSDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Text = StringUtil.Trim( AV53MonAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(AV26Debe);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Number = (double)(AV27Haber);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Number = (double)(AV85Total);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+14, 1, 1).Number = (double)(AV105Dif);
         AV14CellRow = (int)(AV14CellRow+1);
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
         scmdbuf = "";
         A380LBCBCod = "";
         A1079LBFech = DateTime.MinValue;
         P00D12_A1085LBMonCod = new int[1] ;
         P00D12_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P00D12_n1079LBFech = new bool[] {false} ;
         P00D12_A380LBCBCod = new string[] {""} ;
         P00D12_A379LBBanCod = new int[1] ;
         P00D12_A1053LBBanAbr = new string[] {""} ;
         P00D12_A1233MonAbr = new string[] {""} ;
         P00D12_n1233MonAbr = new bool[] {false} ;
         P00D12_A1057LBConcepto = new string[] {""} ;
         P00D12_A1054LBBeneficia = new string[] {""} ;
         P00D12_A1075LBDocumento = new string[] {""} ;
         P00D12_A381LBRegistro = new string[] {""} ;
         P00D12_A1073LBTHaber = new decimal[1] ;
         P00D12_A1072LBTDebe = new decimal[1] ;
         P00D12_A1070LBTipo = new short[1] ;
         A1053LBBanAbr = "";
         A1233MonAbr = "";
         A1057LBConcepto = "";
         A1054LBBeneficia = "";
         A1075LBDocumento = "";
         A381LBRegistro = "";
         AV97BanAbr = "";
         AV53MonAbr = "";
         AV100LBRegistro = "";
         AV93LBFech = DateTime.MinValue;
         AV99CTBco = "";
         AV102LBConcepto = "";
         AV103LBBeneficia = "";
         AV101LBDocumento = "";
         AV113COSDsc = "";
         AV110CBFlujDsc = "";
         AV111CBFlujCDsc = "";
         P00D13_A2269CBFlujTip = new string[] {""} ;
         P00D13_A2270CBFlujCod = new string[] {""} ;
         P00D13_A2271CBFlujCCod = new string[] {""} ;
         P00D13_A2267CBFlujCRegistro = new string[] {""} ;
         P00D13_A2266CBFlujCCuenta = new string[] {""} ;
         P00D13_A2265CBFlujCBanCod = new int[1] ;
         P00D13_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P00D13_n1079LBFech = new bool[] {false} ;
         P00D13_A2272CBFlujCMonCod = new int[1] ;
         P00D13_A2275CBFlujCCosto = new decimal[1] ;
         P00D13_A2277CBFlujDsc = new string[] {""} ;
         P00D13_A2276CBFlujCDsc = new string[] {""} ;
         P00D13_A79COSCod = new string[] {""} ;
         P00D13_A2263CBFlujCAno = new short[1] ;
         P00D13_A2264CBFlujCMes = new short[1] ;
         P00D13_A2268CBFlujCItem = new int[1] ;
         A2269CBFlujTip = "";
         A2270CBFlujCod = "";
         A2271CBFlujCCod = "";
         A2267CBFlujCRegistro = "";
         A2266CBFlujCCuenta = "";
         A2277CBFlujDsc = "";
         A2276CBFlujCDsc = "";
         A79COSCod = "";
         AV81CosCod = "";
         P00D14_A79COSCod = new string[] {""} ;
         P00D14_A761COSDsc = new string[] {""} ;
         A761COSDsc = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_reporteflujovsbancosexcel__default(),
            new Object[][] {
                new Object[] {
               P00D12_A1085LBMonCod, P00D12_A1079LBFech, P00D12_A380LBCBCod, P00D12_A379LBBanCod, P00D12_A1053LBBanAbr, P00D12_A1233MonAbr, P00D12_n1233MonAbr, P00D12_A1057LBConcepto, P00D12_A1054LBBeneficia, P00D12_A1075LBDocumento,
               P00D12_A381LBRegistro, P00D12_A1073LBTHaber, P00D12_A1072LBTDebe, P00D12_A1070LBTipo
               }
               , new Object[] {
               P00D13_A2269CBFlujTip, P00D13_A2270CBFlujCod, P00D13_A2271CBFlujCCod, P00D13_A2267CBFlujCRegistro, P00D13_A2266CBFlujCCuenta, P00D13_A2265CBFlujCBanCod, P00D13_A1079LBFech, P00D13_n1079LBFech, P00D13_A2272CBFlujCMonCod, P00D13_A2275CBFlujCCosto,
               P00D13_A2277CBFlujDsc, P00D13_A2276CBFlujCDsc, P00D13_A79COSCod, P00D13_A2263CBFlujCAno, P00D13_A2264CBFlujCMes, P00D13_A2268CBFlujCItem
               }
               , new Object[] {
               P00D14_A79COSCod, P00D14_A761COSDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1070LBTipo ;
      private short A2263CBFlujCAno ;
      private short A2264CBFlujCMes ;
      private int AV95BanCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A379LBBanCod ;
      private int A1085LBMonCod ;
      private int AV98LBBanCod ;
      private int A2265CBFlujCBanCod ;
      private int A2272CBFlujCMonCod ;
      private int A2268CBFlujCItem ;
      private int AV61MonCod ;
      private decimal AV104Saldo ;
      private decimal A1073LBTHaber ;
      private decimal A1072LBTDebe ;
      private decimal A1071LBTSaldo ;
      private decimal A1082LBHaberTot ;
      private decimal A1069LBDebeTot ;
      private decimal AV26Debe ;
      private decimal AV27Haber ;
      private decimal AV108Mov ;
      private decimal AV109Mov2 ;
      private decimal AV105Dif ;
      private decimal AV85Total ;
      private decimal AV106TDif ;
      private decimal AV107TTotal ;
      private decimal A2275CBFlujCCosto ;
      private decimal AV94Importe ;
      private string AV96LBCBCod ;
      private string AV78Empresa ;
      private string AV72Path ;
      private string scmdbuf ;
      private string A380LBCBCod ;
      private string A1053LBBanAbr ;
      private string A1233MonAbr ;
      private string A1057LBConcepto ;
      private string A1054LBBeneficia ;
      private string A1075LBDocumento ;
      private string A381LBRegistro ;
      private string AV97BanAbr ;
      private string AV53MonAbr ;
      private string AV100LBRegistro ;
      private string AV99CTBco ;
      private string AV102LBConcepto ;
      private string AV103LBBeneficia ;
      private string AV101LBDocumento ;
      private string AV113COSDsc ;
      private string AV110CBFlujDsc ;
      private string AV111CBFlujCDsc ;
      private string A2269CBFlujTip ;
      private string A2270CBFlujCod ;
      private string A2271CBFlujCCod ;
      private string A2267CBFlujCRegistro ;
      private string A2266CBFlujCCuenta ;
      private string A2277CBFlujDsc ;
      private string A2276CBFlujCDsc ;
      private string A79COSCod ;
      private string AV81CosCod ;
      private string A761COSDsc ;
      private DateTime GXt_dtime1 ;
      private DateTime AV79FDesde ;
      private DateTime AV80FHasta ;
      private DateTime A1079LBFech ;
      private DateTime AV93LBFech ;
      private bool returnInSub ;
      private bool n1079LBFech ;
      private bool n1233MonAbr ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private IGxSession AV77Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_BanCod ;
      private DateTime aP1_FDesde ;
      private DateTime aP2_FHasta ;
      private string aP3_LBCBCod ;
      private IDataStoreProvider pr_default ;
      private int[] P00D12_A1085LBMonCod ;
      private DateTime[] P00D12_A1079LBFech ;
      private bool[] P00D12_n1079LBFech ;
      private string[] P00D12_A380LBCBCod ;
      private int[] P00D12_A379LBBanCod ;
      private string[] P00D12_A1053LBBanAbr ;
      private string[] P00D12_A1233MonAbr ;
      private bool[] P00D12_n1233MonAbr ;
      private string[] P00D12_A1057LBConcepto ;
      private string[] P00D12_A1054LBBeneficia ;
      private string[] P00D12_A1075LBDocumento ;
      private string[] P00D12_A381LBRegistro ;
      private decimal[] P00D12_A1073LBTHaber ;
      private decimal[] P00D12_A1072LBTDebe ;
      private short[] P00D12_A1070LBTipo ;
      private string[] P00D13_A2269CBFlujTip ;
      private string[] P00D13_A2270CBFlujCod ;
      private string[] P00D13_A2271CBFlujCCod ;
      private string[] P00D13_A2267CBFlujCRegistro ;
      private string[] P00D13_A2266CBFlujCCuenta ;
      private int[] P00D13_A2265CBFlujCBanCod ;
      private DateTime[] P00D13_A1079LBFech ;
      private bool[] P00D13_n1079LBFech ;
      private int[] P00D13_A2272CBFlujCMonCod ;
      private decimal[] P00D13_A2275CBFlujCCosto ;
      private string[] P00D13_A2277CBFlujDsc ;
      private string[] P00D13_A2276CBFlujCDsc ;
      private string[] P00D13_A79COSCod ;
      private short[] P00D13_A2263CBFlujCAno ;
      private short[] P00D13_A2264CBFlujCMes ;
      private int[] P00D13_A2268CBFlujCItem ;
      private string[] P00D14_A79COSCod ;
      private string[] P00D14_A761COSDsc ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV73Archivo ;
   }

   public class r_reporteflujovsbancosexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00D12( IGxContext context ,
                                             int AV95BanCod ,
                                             string AV96LBCBCod ,
                                             int A379LBBanCod ,
                                             string A380LBCBCod ,
                                             DateTime A1079LBFech ,
                                             DateTime AV79FDesde ,
                                             DateTime AV80FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T3.[MonCod] AS LBMonCod, T1.[LBFech], T1.[LBCBCod] AS LBCBCod, T1.[LBBanCod] AS LBBanCod, T2.[BanAbr] AS LBBanAbr, T4.[MonAbr], T1.[LBConcepto], T1.[LBBeneficia], T1.[LBDocumento], T1.[LBRegistro], T1.[LBTHaber], T1.[LBTDebe], T1.[LBTipo] FROM ((([TSLIBROBANCOS] T1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = T1.[LBBanCod]) INNER JOIN [TSCUENTABANCO] T3 ON T3.[BanCod] = T1.[LBBanCod] AND T3.[CBCod] = T1.[LBCBCod]) INNER JOIN [CMONEDAS] T4 ON T4.[MonCod] = T3.[MonCod])";
         AddWhere(sWhereString, "(T1.[LBFech] >= @AV79FDesde)");
         AddWhere(sWhereString, "(T1.[LBFech] <= @AV80FHasta)");
         if ( ! (0==AV95BanCod) )
         {
            AddWhere(sWhereString, "(T1.[LBBanCod] = @AV95BanCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96LBCBCod)) )
         {
            AddWhere(sWhereString, "(T1.[LBCBCod] = @AV96LBCBCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[LBBanCod], T1.[LBCBCod], T1.[LBRegistro]";
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
                     return conditional_P00D12(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] );
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
          Object[] prmP00D13;
          prmP00D13 = new Object[] {
          new ParDef("@AV98LBBanCod",GXType.Int32,6,0) ,
          new ParDef("@AV99CTBco",GXType.NChar,20,0) ,
          new ParDef("@AV100LBRegistro",GXType.NChar,10,0)
          };
          Object[] prmP00D14;
          prmP00D14 = new Object[] {
          new ParDef("@AV81CosCod",GXType.NChar,10,0)
          };
          Object[] prmP00D12;
          prmP00D12 = new Object[] {
          new ParDef("@AV79FDesde",GXType.Date,8,0) ,
          new ParDef("@AV80FHasta",GXType.Date,8,0) ,
          new ParDef("@AV95BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV96LBCBCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D13", "SELECT T1.[CBFlujTip], T1.[CBFlujCod], T1.[CBFlujCCod], T1.[CBFlujCRegistro] AS CBFlujCRegistro, T1.[CBFlujCCuenta] AS CBFlujCCuenta, T1.[CBFlujCBanCod] AS CBFlujCBanCod, T4.[LBFech], T5.[MonCod] AS CBFlujCMonCod, T1.[CBFlujCCosto], T2.[CBFlujDsc], T3.[CBFlujCDsc], T1.[COSCod], T1.[CBFlujCAno], T1.[CBFlujCMes], T1.[CBFlujCItem] FROM (((([CBFLUJOCONCEPTOSDET] T1 INNER JOIN [CBFLUJOTITULO] T2 ON T2.[CBFlujTip] = T1.[CBFlujTip] AND T2.[CBFlujCod] = T1.[CBFlujCod]) INNER JOIN [CBFLUJOTITULODET] T3 ON T3.[CBFlujTip] = T1.[CBFlujTip] AND T3.[CBFlujCod] = T1.[CBFlujCod] AND T3.[CBFlujCCod] = T1.[CBFlujCCod]) INNER JOIN [TSLIBROBANCOS] T4 ON T4.[LBBanCod] = T1.[CBFlujCBanCod] AND T4.[LBCBCod] = T1.[CBFlujCCuenta] AND T4.[LBRegistro] = T1.[CBFlujCRegistro]) INNER JOIN [TSCUENTABANCO] T5 ON T5.[BanCod] = T1.[CBFlujCBanCod] AND T5.[CBCod] = T1.[CBFlujCCuenta]) WHERE (T1.[CBFlujCBanCod] = @AV98LBBanCod) AND (T1.[CBFlujCCuenta] = @AV99CTBco) AND (T1.[CBFlujCRegistro] = @AV100LBRegistro) ORDER BY T1.[CBFlujCAno], T1.[CBFlujCMes], T1.[CBFlujCBanCod], T1.[CBFlujCCuenta], T1.[CBFlujCRegistro], T1.[CBFlujCItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D14", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV81CosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D14,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 5);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 60);
                ((string[]) buf[8])[0] = rslt.getString(8, 60);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getString(10, 10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 100);
                ((string[]) buf[12])[0] = rslt.getString(12, 10);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((int[]) buf[15])[0] = rslt.getInt(15);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
