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
   public class phistoricocuentacorrienteexcel : GXProcedure
   {
      public phistoricocuentacorrienteexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public phistoricocuentacorrienteexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CliCod ,
                           ref string aP1_TipCod ,
                           ref int aP2_MonCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref string aP5_PedSts ,
                           out string aP6_Filename ,
                           out string aP7_ErrorMessage )
      {
         this.AV67CliCod = aP0_CliCod;
         this.AV60TipCod = aP1_TipCod;
         this.AV61MonCod = aP2_MonCod;
         this.AV104FDesde = aP3_FDesde;
         this.AV77FHasta = aP4_FHasta;
         this.AV105PedSts = aP5_PedSts;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_CliCod=this.AV67CliCod;
         aP1_TipCod=this.AV60TipCod;
         aP2_MonCod=this.AV61MonCod;
         aP3_FDesde=this.AV104FDesde;
         aP4_FHasta=this.AV77FHasta;
         aP5_PedSts=this.AV105PedSts;
         aP6_Filename=this.AV10Filename;
         aP7_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref string aP0_CliCod ,
                                ref string aP1_TipCod ,
                                ref int aP2_MonCod ,
                                ref DateTime aP3_FDesde ,
                                ref DateTime aP4_FHasta ,
                                ref string aP5_PedSts ,
                                out string aP6_Filename )
      {
         execute(ref aP0_CliCod, ref aP1_TipCod, ref aP2_MonCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_PedSts, out aP6_Filename, out aP7_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref string aP0_CliCod ,
                                 ref string aP1_TipCod ,
                                 ref int aP2_MonCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref string aP5_PedSts ,
                                 out string aP6_Filename ,
                                 out string aP7_ErrorMessage )
      {
         phistoricocuentacorrienteexcel objphistoricocuentacorrienteexcel;
         objphistoricocuentacorrienteexcel = new phistoricocuentacorrienteexcel();
         objphistoricocuentacorrienteexcel.AV67CliCod = aP0_CliCod;
         objphistoricocuentacorrienteexcel.AV60TipCod = aP1_TipCod;
         objphistoricocuentacorrienteexcel.AV61MonCod = aP2_MonCod;
         objphistoricocuentacorrienteexcel.AV104FDesde = aP3_FDesde;
         objphistoricocuentacorrienteexcel.AV77FHasta = aP4_FHasta;
         objphistoricocuentacorrienteexcel.AV105PedSts = aP5_PedSts;
         objphistoricocuentacorrienteexcel.AV10Filename = "" ;
         objphistoricocuentacorrienteexcel.AV11ErrorMessage = "" ;
         objphistoricocuentacorrienteexcel.context.SetSubmitInitialConfig(context);
         objphistoricocuentacorrienteexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objphistoricocuentacorrienteexcel);
         aP0_CliCod=this.AV67CliCod;
         aP1_TipCod=this.AV60TipCod;
         aP2_MonCod=this.AV61MonCod;
         aP3_FDesde=this.AV104FDesde;
         aP4_FHasta=this.AV77FHasta;
         aP5_PedSts=this.AV105PedSts;
         aP6_Filename=this.AV10Filename;
         aP7_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((phistoricocuentacorrienteexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasHistoricoCuentaCobrar.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasHistoricoCuentaCobrar.xlsx";
         AV10Filename = "Excel/HistoricoCuentaCobrar" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV70FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 3;
         AV15FirstColumn = 1;
         GXt_char1 = AV66cMes;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV9Mes, out  GXt_char1) ;
         AV66cMes = GXt_char1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Al "+context.localUtil.DToC( AV77FHasta, 2, "/");
         AV14CellRow = 5;
         AV15FirstColumn = 1;
         /* Execute user subroutine: 'HISTORICOCUENTACOBRAR' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
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
         /* 'HISTORICOCUENTACOBRAR' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV67CliCod ,
                                              AV103EstCod ,
                                              AV61MonCod ,
                                              AV60TipCod ,
                                              AV105PedSts ,
                                              A188CCCliCod ,
                                              A140EstCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A506CCEstado ,
                                              A190CCFech ,
                                              AV104FDesde ,
                                              AV77FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00972 */
         pr_default.execute(0, new Object[] {AV104FDesde, AV77FHasta, AV67CliCod, AV103EstCod, AV61MonCod, AV60TipCod, AV105PedSts});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A186CCVendCod = P00972_A186CCVendCod[0];
            A190CCFech = P00972_A190CCFech[0];
            A506CCEstado = P00972_A506CCEstado[0];
            A184CCTipCod = P00972_A184CCTipCod[0];
            A187CCmonCod = P00972_A187CCmonCod[0];
            A140EstCod = P00972_A140EstCod[0];
            n140EstCod = P00972_n140EstCod[0];
            A188CCCliCod = P00972_A188CCCliCod[0];
            A189CCCliDsc = P00972_A189CCCliDsc[0];
            A306TipAbr = P00972_A306TipAbr[0];
            n306TipAbr = P00972_n306TipAbr[0];
            A508CCFVcto = P00972_A508CCFVcto[0];
            A185CCDocNum = P00972_A185CCDocNum[0];
            A511TipSigno = P00972_A511TipSigno[0];
            n511TipSigno = P00972_n511TipSigno[0];
            A513CCImpTotal = P00972_A513CCImpTotal[0];
            A509CCImpPago = P00972_A509CCImpPago[0];
            A1234MonDsc = P00972_A1234MonDsc[0];
            n1234MonDsc = P00972_n1234MonDsc[0];
            A2045VenDsc = P00972_A2045VenDsc[0];
            n2045VenDsc = P00972_n2045VenDsc[0];
            A2045VenDsc = P00972_A2045VenDsc[0];
            n2045VenDsc = P00972_n2045VenDsc[0];
            A306TipAbr = P00972_A306TipAbr[0];
            n306TipAbr = P00972_n306TipAbr[0];
            A511TipSigno = P00972_A511TipSigno[0];
            n511TipSigno = P00972_n511TipSigno[0];
            A1234MonDsc = P00972_A1234MonDsc[0];
            n1234MonDsc = P00972_n1234MonDsc[0];
            A140EstCod = P00972_A140EstCod[0];
            n140EstCod = P00972_n140EstCod[0];
            AV67CliCod = A188CCCliCod;
            AV68CliDsc = A189CCCliDsc;
            AV79TotImporte = 0;
            AV80TotPagos = 0;
            AV81TotSaldo = 0;
            AV96TipAbr = A306TipAbr;
            AV98CCFech = A190CCFech;
            AV97CCFVcto = A508CCFVcto;
            AV82CCTipCod = A184CCTipCod;
            AV83CCDocNum = A185CCDocNum;
            AV106CCEstado = A506CCEstado;
            AV84Importe = ((StringUtil.StrCmp(AV106CCEstado, "A")==0) ? (decimal)(0) : A513CCImpTotal*A511TipSigno);
            AV85Pagos = ((StringUtil.StrCmp(AV106CCEstado, "A")==0) ? (decimal)(0) : A509CCImpPago*A511TipSigno);
            AV88CCmonCod = A187CCmonCod;
            AV99MonDsc = A1234MonDsc;
            AV107Estado = ((StringUtil.StrCmp(AV106CCEstado, "T")==0) ? "Terminado" : ((StringUtil.StrCmp(AV106CCEstado, "A")==0) ? "Anulado" : "Pendiente"));
            AV95Saldo = ((StringUtil.StrCmp(AV106CCEstado, "A")==0) ? (decimal)(0) : (A513CCImpTotal-A509CCImpPago)*A511TipSigno);
            AV89Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A508CCFVcto));
            AV108VenDsc = A2045VenDsc;
            AV109Situacion = "";
            if ( StringUtil.StrCmp(AV82CCTipCod, "LET") == 0 )
            {
               /* Execute user subroutine: 'DATOSLETRAS' */
               S122 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
            }
            /* Execute user subroutine: 'DETALLE' */
            S132 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV90TotGImporte = (decimal)(AV90TotGImporte+AV84Importe);
            AV91TotGPagos = (decimal)(AV91TotGPagos+AV85Pagos);
            AV92TotGSaldo = (decimal)(AV92TotGSaldo+AV95Saldo);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S141( )
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

      protected void S132( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV67CliCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV68CliDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV96TipAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV83CCDocNum);
         GXt_dtime2 = DateTimeUtil.ResetTime( AV98CCFech ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Date = GXt_dtime2;
         GXt_dtime2 = DateTimeUtil.ResetTime( AV97CCFVcto ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Date = GXt_dtime2;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = AV89Dias;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV99MonDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV84Importe);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV85Pagos);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV95Saldo);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Text = StringUtil.Trim( AV107Estado);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Text = StringUtil.Trim( AV108VenDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Text = StringUtil.Trim( AV109Situacion);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S122( )
      {
         /* 'DATOSLETRAS' Routine */
         returnInSub = false;
         /* Using cursor P00973 */
         pr_default.execute(1, new Object[] {AV83CCDocNum});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A1120LetCTipo = P00973_A1120LetCTipo[0];
            A209LetCDocNum = P00973_A209LetCDocNum[0];
            n209LetCDocNum = P00973_n209LetCDocNum[0];
            A1105LetCBanNum = P00973_A1105LetCBanNum[0];
            A1116LetCSec = P00973_A1116LetCSec[0];
            A204LetCLetCod = P00973_A204LetCLetCod[0];
            A207LetCItem = P00973_A207LetCItem[0];
            AV110LetCBanNum = A1105LetCBanNum;
            AV111LetCSec = A1116LetCSec;
            if ( AV111LetCSec == 1 )
            {
               AV109Situacion = "Por Aceptar";
            }
            if ( AV111LetCSec == 2 )
            {
               AV109Situacion = "Descuento";
            }
            if ( AV111LetCSec == 3 )
            {
               AV109Situacion = "Cobranza";
            }
            if ( AV111LetCSec == 4 )
            {
               AV109Situacion = "Cobranza Libre";
            }
            if ( AV111LetCSec == 5 )
            {
               AV109Situacion = "Garantia";
            }
            if ( AV111LetCSec == 6 )
            {
               AV109Situacion = "Protestado";
            }
            if ( AV111LetCSec == 7 )
            {
               AV109Situacion = "Refinanciado";
            }
            if ( AV111LetCSec == 8 )
            {
               AV109Situacion = "Cartera";
            }
            if ( AV111LetCSec == 9 )
            {
               AV109Situacion = "Aceptada";
            }
            pr_default.readNext(1);
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
         AV66cMes = "";
         GXt_char1 = "";
         scmdbuf = "";
         AV103EstCod = "";
         A188CCCliCod = "";
         A140EstCod = "";
         A184CCTipCod = "";
         A506CCEstado = "";
         A190CCFech = DateTime.MinValue;
         P00972_A186CCVendCod = new int[1] ;
         P00972_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00972_A506CCEstado = new string[] {""} ;
         P00972_A184CCTipCod = new string[] {""} ;
         P00972_A187CCmonCod = new int[1] ;
         P00972_A140EstCod = new string[] {""} ;
         P00972_n140EstCod = new bool[] {false} ;
         P00972_A188CCCliCod = new string[] {""} ;
         P00972_A189CCCliDsc = new string[] {""} ;
         P00972_A306TipAbr = new string[] {""} ;
         P00972_n306TipAbr = new bool[] {false} ;
         P00972_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00972_A185CCDocNum = new string[] {""} ;
         P00972_A511TipSigno = new short[1] ;
         P00972_n511TipSigno = new bool[] {false} ;
         P00972_A513CCImpTotal = new decimal[1] ;
         P00972_A509CCImpPago = new decimal[1] ;
         P00972_A1234MonDsc = new string[] {""} ;
         P00972_n1234MonDsc = new bool[] {false} ;
         P00972_A2045VenDsc = new string[] {""} ;
         P00972_n2045VenDsc = new bool[] {false} ;
         A189CCCliDsc = "";
         A306TipAbr = "";
         A508CCFVcto = DateTime.MinValue;
         A185CCDocNum = "";
         A1234MonDsc = "";
         A2045VenDsc = "";
         AV68CliDsc = "";
         AV96TipAbr = "";
         AV98CCFech = DateTime.MinValue;
         AV97CCFVcto = DateTime.MinValue;
         AV82CCTipCod = "";
         AV83CCDocNum = "";
         AV106CCEstado = "";
         AV99MonDsc = "";
         AV107Estado = "";
         AV108VenDsc = "";
         AV109Situacion = "";
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         P00973_A1120LetCTipo = new string[] {""} ;
         P00973_A209LetCDocNum = new string[] {""} ;
         P00973_n209LetCDocNum = new bool[] {false} ;
         P00973_A1105LetCBanNum = new string[] {""} ;
         P00973_A1116LetCSec = new int[1] ;
         P00973_A204LetCLetCod = new string[] {""} ;
         P00973_A207LetCItem = new int[1] ;
         A1120LetCTipo = "";
         A209LetCDocNum = "";
         A1105LetCBanNum = "";
         A204LetCLetCod = "";
         AV110LetCBanNum = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.phistoricocuentacorrienteexcel__default(),
            new Object[][] {
                new Object[] {
               P00972_A186CCVendCod, P00972_A190CCFech, P00972_A506CCEstado, P00972_A184CCTipCod, P00972_A187CCmonCod, P00972_A140EstCod, P00972_n140EstCod, P00972_A188CCCliCod, P00972_A189CCCliDsc, P00972_A306TipAbr,
               P00972_n306TipAbr, P00972_A508CCFVcto, P00972_A185CCDocNum, P00972_A511TipSigno, P00972_n511TipSigno, P00972_A513CCImpTotal, P00972_A509CCImpPago, P00972_A1234MonDsc, P00972_n1234MonDsc, P00972_A2045VenDsc,
               P00972_n2045VenDsc
               }
               , new Object[] {
               P00973_A1120LetCTipo, P00973_A209LetCDocNum, P00973_n209LetCDocNum, P00973_A1105LetCBanNum, P00973_A1116LetCSec, P00973_A204LetCLetCod, P00973_A207LetCItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9Mes ;
      private short A511TipSigno ;
      private int AV61MonCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A187CCmonCod ;
      private int A186CCVendCod ;
      private int AV88CCmonCod ;
      private int AV89Dias ;
      private int A1116LetCSec ;
      private int A207LetCItem ;
      private int AV111LetCSec ;
      private decimal A513CCImpTotal ;
      private decimal A509CCImpPago ;
      private decimal AV79TotImporte ;
      private decimal AV80TotPagos ;
      private decimal AV81TotSaldo ;
      private decimal AV84Importe ;
      private decimal AV85Pagos ;
      private decimal AV95Saldo ;
      private decimal AV90TotGImporte ;
      private decimal AV91TotGPagos ;
      private decimal AV92TotGSaldo ;
      private string AV67CliCod ;
      private string AV60TipCod ;
      private string AV105PedSts ;
      private string AV71Path ;
      private string AV66cMes ;
      private string GXt_char1 ;
      private string scmdbuf ;
      private string AV103EstCod ;
      private string A188CCCliCod ;
      private string A140EstCod ;
      private string A184CCTipCod ;
      private string A506CCEstado ;
      private string A189CCCliDsc ;
      private string A306TipAbr ;
      private string A185CCDocNum ;
      private string A1234MonDsc ;
      private string A2045VenDsc ;
      private string AV68CliDsc ;
      private string AV96TipAbr ;
      private string AV82CCTipCod ;
      private string AV83CCDocNum ;
      private string AV106CCEstado ;
      private string AV99MonDsc ;
      private string AV108VenDsc ;
      private string A1120LetCTipo ;
      private string A209LetCDocNum ;
      private string A1105LetCBanNum ;
      private string A204LetCLetCod ;
      private string AV110LetCBanNum ;
      private DateTime GXt_dtime2 ;
      private DateTime AV104FDesde ;
      private DateTime AV77FHasta ;
      private DateTime A190CCFech ;
      private DateTime A508CCFVcto ;
      private DateTime AV98CCFech ;
      private DateTime AV97CCFVcto ;
      private bool returnInSub ;
      private bool n140EstCod ;
      private bool n306TipAbr ;
      private bool n511TipSigno ;
      private bool n1234MonDsc ;
      private bool n2045VenDsc ;
      private bool n209LetCDocNum ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private string AV107Estado ;
      private string AV109Situacion ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CliCod ;
      private string aP1_TipCod ;
      private int aP2_MonCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private string aP5_PedSts ;
      private IDataStoreProvider pr_default ;
      private int[] P00972_A186CCVendCod ;
      private DateTime[] P00972_A190CCFech ;
      private string[] P00972_A506CCEstado ;
      private string[] P00972_A184CCTipCod ;
      private int[] P00972_A187CCmonCod ;
      private string[] P00972_A140EstCod ;
      private bool[] P00972_n140EstCod ;
      private string[] P00972_A188CCCliCod ;
      private string[] P00972_A189CCCliDsc ;
      private string[] P00972_A306TipAbr ;
      private bool[] P00972_n306TipAbr ;
      private DateTime[] P00972_A508CCFVcto ;
      private string[] P00972_A185CCDocNum ;
      private short[] P00972_A511TipSigno ;
      private bool[] P00972_n511TipSigno ;
      private decimal[] P00972_A513CCImpTotal ;
      private decimal[] P00972_A509CCImpPago ;
      private string[] P00972_A1234MonDsc ;
      private bool[] P00972_n1234MonDsc ;
      private string[] P00972_A2045VenDsc ;
      private bool[] P00972_n2045VenDsc ;
      private string[] P00973_A1120LetCTipo ;
      private string[] P00973_A209LetCDocNum ;
      private bool[] P00973_n209LetCDocNum ;
      private string[] P00973_A1105LetCBanNum ;
      private int[] P00973_A1116LetCSec ;
      private string[] P00973_A204LetCLetCod ;
      private int[] P00973_A207LetCItem ;
      private string aP6_Filename ;
      private string aP7_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class phistoricocuentacorrienteexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00972( IGxContext context ,
                                             string AV67CliCod ,
                                             string AV103EstCod ,
                                             int AV61MonCod ,
                                             string AV60TipCod ,
                                             string AV105PedSts ,
                                             string A188CCCliCod ,
                                             string A140EstCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             string A506CCEstado ,
                                             DateTime A190CCFech ,
                                             DateTime AV104FDesde ,
                                             DateTime AV77FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CCVendCod] AS CCVendCod, T1.[CCFech], T1.[CCEstado], T1.[CCTipCod] AS CCTipCod, T1.[CCmonCod] AS CCmonCod, T5.[EstCod], T1.[CCCliCod] AS CCCliCod, T1.[CCCliDsc], T3.[TipAbr], T1.[CCFVcto], T1.[CCDocNum], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T4.[MonDsc], T2.[VenDsc] FROM (((([CLCUENTACOBRAR] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[CCVendCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CMONEDAS] T4 ON T4.[MonCod] = T1.[CCmonCod]) INNER JOIN [CLCLIENTES] T5 ON T5.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T1.[CCFech] >= @AV104FDesde and T1.[CCFech] <= @AV77FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV67CliCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103EstCod)) )
         {
            AddWhere(sWhereString, "(T5.[EstCod] = @AV103EstCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV61MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV61MonCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV60TipCod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV105PedSts, "TD") != 0 )
         {
            AddWhere(sWhereString, "(T1.[CCEstado] = @AV105PedSts)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliCod], T1.[CCFech]";
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
               case 0 :
                     return conditional_P00972(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] );
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
          Object[] prmP00973;
          prmP00973 = new Object[] {
          new ParDef("@AV83CCDocNum",GXType.NChar,12,0)
          };
          Object[] prmP00972;
          prmP00972 = new Object[] {
          new ParDef("@AV104FDesde",GXType.Date,8,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0) ,
          new ParDef("@AV67CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV103EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV61MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV60TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV105PedSts",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00972", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00972,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00973", "SELECT [LetCTipo], [LetCDocNum], [LetCBanNum], [LetCSec], [LetCLetCod], [LetCItem] FROM [CLLETRASDET] WHERE ([LetCDocNum] = @AV83CCDocNum) AND ([LetCTipo] = 'L') ORDER BY [LetCLetCod], [LetCItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00973,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 4);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getString(9, 5);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 12);
                ((short[]) buf[13])[0] = rslt.getShort(12);
                ((bool[]) buf[14])[0] = rslt.wasNull(12);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(14);
                ((string[]) buf[17])[0] = rslt.getString(15, 100);
                ((bool[]) buf[18])[0] = rslt.wasNull(15);
                ((string[]) buf[19])[0] = rslt.getString(16, 100);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 10);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
