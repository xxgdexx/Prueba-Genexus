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
   public class pcuentacorrientevendedorexcel : GXProcedure
   {
      public pcuentacorrientevendedorexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pcuentacorrientevendedorexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_TipCod ,
                           ref string aP1_CliCod ,
                           ref int aP2_MonCod ,
                           ref int aP3_VenCod ,
                           ref DateTime aP4_FHasta ,
                           out string aP5_Filename ,
                           out string aP6_ErrorMessage )
      {
         this.AV60TipCod = aP0_TipCod;
         this.AV67CliCod = aP1_CliCod;
         this.AV61MonCod = aP2_MonCod;
         this.AV101VenCod = aP3_VenCod;
         this.AV77FHasta = aP4_FHasta;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_TipCod=this.AV60TipCod;
         aP1_CliCod=this.AV67CliCod;
         aP2_MonCod=this.AV61MonCod;
         aP3_VenCod=this.AV101VenCod;
         aP4_FHasta=this.AV77FHasta;
         aP5_Filename=this.AV10Filename;
         aP6_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref string aP0_TipCod ,
                                ref string aP1_CliCod ,
                                ref int aP2_MonCod ,
                                ref int aP3_VenCod ,
                                ref DateTime aP4_FHasta ,
                                out string aP5_Filename )
      {
         execute(ref aP0_TipCod, ref aP1_CliCod, ref aP2_MonCod, ref aP3_VenCod, ref aP4_FHasta, out aP5_Filename, out aP6_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref string aP0_TipCod ,
                                 ref string aP1_CliCod ,
                                 ref int aP2_MonCod ,
                                 ref int aP3_VenCod ,
                                 ref DateTime aP4_FHasta ,
                                 out string aP5_Filename ,
                                 out string aP6_ErrorMessage )
      {
         pcuentacorrientevendedorexcel objpcuentacorrientevendedorexcel;
         objpcuentacorrientevendedorexcel = new pcuentacorrientevendedorexcel();
         objpcuentacorrientevendedorexcel.AV60TipCod = aP0_TipCod;
         objpcuentacorrientevendedorexcel.AV67CliCod = aP1_CliCod;
         objpcuentacorrientevendedorexcel.AV61MonCod = aP2_MonCod;
         objpcuentacorrientevendedorexcel.AV101VenCod = aP3_VenCod;
         objpcuentacorrientevendedorexcel.AV77FHasta = aP4_FHasta;
         objpcuentacorrientevendedorexcel.AV10Filename = "" ;
         objpcuentacorrientevendedorexcel.AV11ErrorMessage = "" ;
         objpcuentacorrientevendedorexcel.context.SetSubmitInitialConfig(context);
         objpcuentacorrientevendedorexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcuentacorrientevendedorexcel);
         aP0_TipCod=this.AV60TipCod;
         aP1_CliCod=this.AV67CliCod;
         aP2_MonCod=this.AV61MonCod;
         aP3_VenCod=this.AV101VenCod;
         aP4_FHasta=this.AV77FHasta;
         aP5_Filename=this.AV10Filename;
         aP6_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcuentacorrientevendedorexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasCuentaCobrarVendedor.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasCuentaCobrarVendedor.xlsx";
         AV10Filename = "Excel/CuentaCobrarVendedor" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV70FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 3;
         AV15FirstColumn = 0;
         GXt_char1 = AV66cMes;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV9Mes, out  GXt_char1) ;
         AV66cMes = GXt_char1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Al "+context.localUtil.DToC( AV77FHasta, 2, "/");
         AV14CellRow = 5;
         AV15FirstColumn = 1;
         if ( DateTimeUtil.ResetTime ( AV77FHasta ) == DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV101VenCod ,
                                                 AV67CliCod ,
                                                 A186CCVendCod ,
                                                 A188CCCliCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            /* Using cursor P00942 */
            pr_default.execute(0, new Object[] {AV101VenCod, AV67CliCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK942 = false;
               A188CCCliCod = P00942_A188CCCliCod[0];
               A186CCVendCod = P00942_A186CCVendCod[0];
               A2045VenDsc = P00942_A2045VenDsc[0];
               n2045VenDsc = P00942_n2045VenDsc[0];
               A184CCTipCod = P00942_A184CCTipCod[0];
               A185CCDocNum = P00942_A185CCDocNum[0];
               A2045VenDsc = P00942_A2045VenDsc[0];
               n2045VenDsc = P00942_n2045VenDsc[0];
               while ( (pr_default.getStatus(0) != 101) && ( P00942_A186CCVendCod[0] == A186CCVendCod ) )
               {
                  BRK942 = false;
                  A188CCCliCod = P00942_A188CCCliCod[0];
                  A184CCTipCod = P00942_A184CCTipCod[0];
                  A185CCDocNum = P00942_A185CCDocNum[0];
                  BRK942 = true;
                  pr_default.readNext(0);
               }
               AV104TotImpVend = 0.00m;
               AV105TotPagoVend = 0.00m;
               AV106TotSaldoVend = 0.00m;
               AV67CliCod = "";
               AV101VenCod = A186CCVendCod;
               AV102Vendedor = AV101VenCod;
               AV103VenDsc = A2045VenDsc;
               /* Execute user subroutine: 'CUENTACOBRAR' */
               S151 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! BRK942 )
               {
                  BRK942 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
         }
         else
         {
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV101VenCod ,
                                                 AV67CliCod ,
                                                 A186CCVendCod ,
                                                 A188CCCliCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            /* Using cursor P00943 */
            pr_default.execute(1, new Object[] {AV101VenCod, AV67CliCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRK944 = false;
               A188CCCliCod = P00943_A188CCCliCod[0];
               A186CCVendCod = P00943_A186CCVendCod[0];
               A2045VenDsc = P00943_A2045VenDsc[0];
               n2045VenDsc = P00943_n2045VenDsc[0];
               A184CCTipCod = P00943_A184CCTipCod[0];
               A185CCDocNum = P00943_A185CCDocNum[0];
               A2045VenDsc = P00943_A2045VenDsc[0];
               n2045VenDsc = P00943_n2045VenDsc[0];
               while ( (pr_default.getStatus(1) != 101) && ( P00943_A186CCVendCod[0] == A186CCVendCod ) )
               {
                  BRK944 = false;
                  A188CCCliCod = P00943_A188CCCliCod[0];
                  A184CCTipCod = P00943_A184CCTipCod[0];
                  A185CCDocNum = P00943_A185CCDocNum[0];
                  BRK944 = true;
                  pr_default.readNext(1);
               }
               AV104TotImpVend = 0.00m;
               AV105TotPagoVend = 0.00m;
               AV106TotSaldoVend = 0.00m;
               AV67CliCod = "";
               AV101VenCod = A186CCVendCod;
               AV102Vendedor = AV101VenCod;
               AV103VenDsc = A2045VenDsc;
               /* Execute user subroutine: 'CUENTACOBRARAL' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! BRK944 )
               {
                  BRK944 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
         }
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S161 ();
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
         /* 'CUENTACOBRARAL' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV67CliCod ,
                                              AV61MonCod ,
                                              AV60TipCod ,
                                              AV101VenCod ,
                                              A188CCCliCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A186CCVendCod ,
                                              A190CCFech ,
                                              AV77FHasta ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00944 */
         pr_default.execute(2, new Object[] {AV77FHasta, AV67CliCod, AV61MonCod, AV60TipCod, AV101VenCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK946 = false;
            A189CCCliDsc = P00944_A189CCCliDsc[0];
            A306TipAbr = P00944_A306TipAbr[0];
            n306TipAbr = P00944_n306TipAbr[0];
            A185CCDocNum = P00944_A185CCDocNum[0];
            A508CCFVcto = P00944_A508CCFVcto[0];
            A1234MonDsc = P00944_A1234MonDsc[0];
            n1234MonDsc = P00944_n1234MonDsc[0];
            A184CCTipCod = P00944_A184CCTipCod[0];
            A511TipSigno = P00944_A511TipSigno[0];
            n511TipSigno = P00944_n511TipSigno[0];
            A513CCImpTotal = P00944_A513CCImpTotal[0];
            A509CCImpPago = P00944_A509CCImpPago[0];
            A187CCmonCod = P00944_A187CCmonCod[0];
            A190CCFech = P00944_A190CCFech[0];
            A506CCEstado = P00944_A506CCEstado[0];
            A186CCVendCod = P00944_A186CCVendCod[0];
            A188CCCliCod = P00944_A188CCCliCod[0];
            A306TipAbr = P00944_A306TipAbr[0];
            n306TipAbr = P00944_n306TipAbr[0];
            A511TipSigno = P00944_A511TipSigno[0];
            n511TipSigno = P00944_n511TipSigno[0];
            A1234MonDsc = P00944_A1234MonDsc[0];
            n1234MonDsc = P00944_n1234MonDsc[0];
            AV102Vendedor = 0;
            AV67CliCod = A188CCCliCod;
            AV68CliDsc = StringUtil.Trim( A189CCCliDsc);
            /* Execute user subroutine: 'VALIDAMOV' */
            S126 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            AV79TotImporte = 0.00m;
            AV80TotPagos = 0.00m;
            AV81TotSaldo = 0.00m;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00944_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRK946 = false;
               A306TipAbr = P00944_A306TipAbr[0];
               n306TipAbr = P00944_n306TipAbr[0];
               A185CCDocNum = P00944_A185CCDocNum[0];
               A508CCFVcto = P00944_A508CCFVcto[0];
               A1234MonDsc = P00944_A1234MonDsc[0];
               n1234MonDsc = P00944_n1234MonDsc[0];
               A184CCTipCod = P00944_A184CCTipCod[0];
               A511TipSigno = P00944_A511TipSigno[0];
               n511TipSigno = P00944_n511TipSigno[0];
               A513CCImpTotal = P00944_A513CCImpTotal[0];
               A509CCImpPago = P00944_A509CCImpPago[0];
               A187CCmonCod = P00944_A187CCmonCod[0];
               A190CCFech = P00944_A190CCFech[0];
               A306TipAbr = P00944_A306TipAbr[0];
               n306TipAbr = P00944_n306TipAbr[0];
               A511TipSigno = P00944_A511TipSigno[0];
               n511TipSigno = P00944_n511TipSigno[0];
               A1234MonDsc = P00944_A1234MonDsc[0];
               n1234MonDsc = P00944_n1234MonDsc[0];
               AV96TipAbr = StringUtil.Trim( A306TipAbr);
               AV83CCDocNum = StringUtil.Trim( A185CCDocNum);
               AV98CCFech = A190CCFech;
               AV97CCFVcto = A508CCFVcto;
               AV99MonDsc = StringUtil.Trim( A1234MonDsc);
               AV82CCTipCod = A184CCTipCod;
               AV84Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV85Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV88CCmonCod = A187CCmonCod;
               /* Execute user subroutine: 'PAGOS' */
               S137 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV85Pagos < 0.02m )
               {
                  AV85Pagos = 0;
               }
               AV95Saldo = (decimal)((AV84Importe-AV85Pagos)*A511TipSigno);
               AV89Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A508CCFVcto));
               if ( ( AV95Saldo != Convert.ToDecimal( 0 )) )
               {
                  AV79TotImporte = (decimal)(AV79TotImporte+AV84Importe);
                  AV80TotPagos = (decimal)(AV80TotPagos+AV85Pagos);
                  AV81TotSaldo = (decimal)(AV81TotSaldo+AV95Saldo);
                  /* Execute user subroutine: 'DETALLE' */
                  S147 ();
                  if ( returnInSub )
                  {
                     pr_default.close(2);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               BRK946 = true;
               pr_default.readNext(2);
            }
            AV90TotGImporte = (decimal)(AV90TotGImporte+AV79TotImporte);
            AV91TotGPagos = (decimal)(AV91TotGPagos+AV80TotPagos);
            AV92TotGSaldo = (decimal)(AV92TotGSaldo+AV81TotSaldo);
            AV104TotImpVend = (decimal)(AV104TotImpVend+AV79TotImporte);
            AV105TotPagoVend = (decimal)(AV105TotPagoVend+AV80TotPagos);
            AV106TotSaldoVend = (decimal)(AV106TotSaldoVend+AV81TotSaldo);
            if ( ! BRK946 )
            {
               BRK946 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'CUENTACOBRAR' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV67CliCod ,
                                              AV101VenCod ,
                                              AV61MonCod ,
                                              AV60TipCod ,
                                              A188CCCliCod ,
                                              A186CCVendCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00945 */
         pr_default.execute(3, new Object[] {AV67CliCod, AV101VenCod, AV61MonCod, AV60TipCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK948 = false;
            A189CCCliDsc = P00945_A189CCCliDsc[0];
            A306TipAbr = P00945_A306TipAbr[0];
            n306TipAbr = P00945_n306TipAbr[0];
            A185CCDocNum = P00945_A185CCDocNum[0];
            A508CCFVcto = P00945_A508CCFVcto[0];
            A1234MonDsc = P00945_A1234MonDsc[0];
            n1234MonDsc = P00945_n1234MonDsc[0];
            A511TipSigno = P00945_A511TipSigno[0];
            n511TipSigno = P00945_n511TipSigno[0];
            A513CCImpTotal = P00945_A513CCImpTotal[0];
            A509CCImpPago = P00945_A509CCImpPago[0];
            A190CCFech = P00945_A190CCFech[0];
            A506CCEstado = P00945_A506CCEstado[0];
            A184CCTipCod = P00945_A184CCTipCod[0];
            A187CCmonCod = P00945_A187CCmonCod[0];
            A186CCVendCod = P00945_A186CCVendCod[0];
            A188CCCliCod = P00945_A188CCCliCod[0];
            A161CliDsc = P00945_A161CliDsc[0];
            n161CliDsc = P00945_n161CliDsc[0];
            A306TipAbr = P00945_A306TipAbr[0];
            n306TipAbr = P00945_n306TipAbr[0];
            A511TipSigno = P00945_A511TipSigno[0];
            n511TipSigno = P00945_n511TipSigno[0];
            A1234MonDsc = P00945_A1234MonDsc[0];
            n1234MonDsc = P00945_n1234MonDsc[0];
            A161CliDsc = P00945_A161CliDsc[0];
            n161CliDsc = P00945_n161CliDsc[0];
            AV102Vendedor = 0;
            AV68CliDsc = StringUtil.Trim( A161CliDsc);
            AV79TotImporte = 0.00m;
            AV80TotPagos = 0.00m;
            AV81TotSaldo = 0.00m;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00945_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRK948 = false;
               A306TipAbr = P00945_A306TipAbr[0];
               n306TipAbr = P00945_n306TipAbr[0];
               A185CCDocNum = P00945_A185CCDocNum[0];
               A508CCFVcto = P00945_A508CCFVcto[0];
               A1234MonDsc = P00945_A1234MonDsc[0];
               n1234MonDsc = P00945_n1234MonDsc[0];
               A511TipSigno = P00945_A511TipSigno[0];
               n511TipSigno = P00945_n511TipSigno[0];
               A513CCImpTotal = P00945_A513CCImpTotal[0];
               A509CCImpPago = P00945_A509CCImpPago[0];
               A190CCFech = P00945_A190CCFech[0];
               A184CCTipCod = P00945_A184CCTipCod[0];
               A187CCmonCod = P00945_A187CCmonCod[0];
               A306TipAbr = P00945_A306TipAbr[0];
               n306TipAbr = P00945_n306TipAbr[0];
               A511TipSigno = P00945_A511TipSigno[0];
               n511TipSigno = P00945_n511TipSigno[0];
               A1234MonDsc = P00945_A1234MonDsc[0];
               n1234MonDsc = P00945_n1234MonDsc[0];
               AV96TipAbr = StringUtil.Trim( A306TipAbr);
               AV83CCDocNum = StringUtil.Trim( A185CCDocNum);
               AV98CCFech = A190CCFech;
               AV97CCFVcto = A508CCFVcto;
               AV99MonDsc = StringUtil.Trim( A1234MonDsc);
               AV84Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV85Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV95Saldo = (decimal)((A513CCImpTotal-A509CCImpPago)*A511TipSigno);
               AV89Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A508CCFVcto));
               AV79TotImporte = (decimal)(AV79TotImporte+AV84Importe);
               AV80TotPagos = (decimal)(AV80TotPagos+AV85Pagos);
               AV81TotSaldo = (decimal)(AV81TotSaldo+AV95Saldo);
               /* Execute user subroutine: 'DETALLE' */
               S147 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  returnInSub = true;
                  if (true) return;
               }
               BRK948 = true;
               pr_default.readNext(3);
            }
            AV90TotGImporte = (decimal)(AV90TotGImporte+AV79TotImporte);
            AV91TotGPagos = (decimal)(AV91TotGPagos+AV80TotPagos);
            AV92TotGSaldo = (decimal)(AV92TotGSaldo+AV81TotSaldo);
            AV104TotImpVend = (decimal)(AV104TotImpVend+AV79TotImporte);
            AV105TotPagoVend = (decimal)(AV105TotPagoVend+AV80TotPagos);
            AV106TotSaldoVend = (decimal)(AV106TotSaldoVend+AV81TotSaldo);
            if ( ! BRK948 )
            {
               BRK948 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S137( )
      {
         /* 'PAGOS' Routine */
         returnInSub = false;
         /* Using cursor P00946 */
         pr_default.execute(4, new Object[] {AV82CCTipCod, AV83CCDocNum, AV77FHasta});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A166CobTip = P00946_A166CobTip[0];
            A167CobCod = P00946_A167CobCod[0];
            A661CobSts = P00946_A661CobSts[0];
            A655CobFec = P00946_A655CobFec[0];
            A176CobDocNum = P00946_A176CobDocNum[0];
            A175CobTipCod = P00946_A175CobTipCod[0];
            A172CobMon = P00946_A172CobMon[0];
            A654CobDTot = P00946_A654CobDTot[0];
            A663CobTipCam = P00946_A663CobTipCam[0];
            A173Item = P00946_A173Item[0];
            A661CobSts = P00946_A661CobSts[0];
            A655CobFec = P00946_A655CobFec[0];
            A172CobMon = P00946_A172CobMon[0];
            AV93CobMon = A172CobMon;
            AV94CobDtot = NumberUtil.Round( A654CobDTot, 2);
            if ( ( AV94CobDtot < Convert.ToDecimal( 0 )) )
            {
               AV94CobDtot = (decimal)(AV94CobDtot*-1);
            }
            if ( AV88CCmonCod == AV93CobMon )
            {
               AV85Pagos = (decimal)(AV85Pagos-AV94CobDtot);
            }
            else
            {
               if ( AV88CCmonCod == 1 )
               {
                  AV85Pagos = (decimal)(AV85Pagos-(NumberUtil.Round( AV94CobDtot*A663CobTipCam, 2)));
               }
               else
               {
                  AV85Pagos = (decimal)(AV85Pagos-(NumberUtil.Round( AV94CobDtot/ (decimal)(A663CobTipCam), 2)));
               }
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S126( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         AV100Flag = 0;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV67CliCod ,
                                              AV61MonCod ,
                                              AV60TipCod ,
                                              AV102Vendedor ,
                                              A188CCCliCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A186CCVendCod ,
                                              A190CCFech ,
                                              AV77FHasta ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00947 */
         pr_default.execute(5, new Object[] {AV77FHasta, AV67CliCod, AV61MonCod, AV60TipCod, AV102Vendedor});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A506CCEstado = P00947_A506CCEstado[0];
            A190CCFech = P00947_A190CCFech[0];
            A186CCVendCod = P00947_A186CCVendCod[0];
            A184CCTipCod = P00947_A184CCTipCod[0];
            A187CCmonCod = P00947_A187CCmonCod[0];
            A188CCCliCod = P00947_A188CCCliCod[0];
            A513CCImpTotal = P00947_A513CCImpTotal[0];
            A509CCImpPago = P00947_A509CCImpPago[0];
            A511TipSigno = P00947_A511TipSigno[0];
            n511TipSigno = P00947_n511TipSigno[0];
            A185CCDocNum = P00947_A185CCDocNum[0];
            A511TipSigno = P00947_A511TipSigno[0];
            n511TipSigno = P00947_n511TipSigno[0];
            AV82CCTipCod = A184CCTipCod;
            AV83CCDocNum = A185CCDocNum;
            AV84Importe = A513CCImpTotal;
            AV85Pagos = A509CCImpPago;
            AV88CCmonCod = A187CCmonCod;
            /* Execute user subroutine: 'PAGOS' */
            S137 ();
            if ( returnInSub )
            {
               pr_default.close(5);
               returnInSub = true;
               if (true) return;
            }
            if ( AV85Pagos < 0.02m )
            {
               AV85Pagos = 0;
            }
            AV95Saldo = (decimal)((AV84Importe-AV85Pagos)*A511TipSigno);
            if ( ( AV95Saldo != Convert.ToDecimal( 0 )) )
            {
               AV100Flag = 1;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S147( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV103VenDsc);
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
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S161( )
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
         AV66cMes = "";
         GXt_char1 = "";
         scmdbuf = "";
         A188CCCliCod = "";
         P00942_A188CCCliCod = new string[] {""} ;
         P00942_A186CCVendCod = new int[1] ;
         P00942_A2045VenDsc = new string[] {""} ;
         P00942_n2045VenDsc = new bool[] {false} ;
         P00942_A184CCTipCod = new string[] {""} ;
         P00942_A185CCDocNum = new string[] {""} ;
         A2045VenDsc = "";
         A184CCTipCod = "";
         A185CCDocNum = "";
         AV103VenDsc = "";
         P00943_A188CCCliCod = new string[] {""} ;
         P00943_A186CCVendCod = new int[1] ;
         P00943_A2045VenDsc = new string[] {""} ;
         P00943_n2045VenDsc = new bool[] {false} ;
         P00943_A184CCTipCod = new string[] {""} ;
         P00943_A185CCDocNum = new string[] {""} ;
         A190CCFech = DateTime.MinValue;
         A506CCEstado = "";
         P00944_A189CCCliDsc = new string[] {""} ;
         P00944_A306TipAbr = new string[] {""} ;
         P00944_n306TipAbr = new bool[] {false} ;
         P00944_A185CCDocNum = new string[] {""} ;
         P00944_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00944_A1234MonDsc = new string[] {""} ;
         P00944_n1234MonDsc = new bool[] {false} ;
         P00944_A184CCTipCod = new string[] {""} ;
         P00944_A511TipSigno = new short[1] ;
         P00944_n511TipSigno = new bool[] {false} ;
         P00944_A513CCImpTotal = new decimal[1] ;
         P00944_A509CCImpPago = new decimal[1] ;
         P00944_A187CCmonCod = new int[1] ;
         P00944_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00944_A506CCEstado = new string[] {""} ;
         P00944_A186CCVendCod = new int[1] ;
         P00944_A188CCCliCod = new string[] {""} ;
         A189CCCliDsc = "";
         A306TipAbr = "";
         A508CCFVcto = DateTime.MinValue;
         A1234MonDsc = "";
         AV68CliDsc = "";
         AV96TipAbr = "";
         AV83CCDocNum = "";
         AV98CCFech = DateTime.MinValue;
         AV97CCFVcto = DateTime.MinValue;
         AV99MonDsc = "";
         AV82CCTipCod = "";
         P00945_A189CCCliDsc = new string[] {""} ;
         P00945_A306TipAbr = new string[] {""} ;
         P00945_n306TipAbr = new bool[] {false} ;
         P00945_A185CCDocNum = new string[] {""} ;
         P00945_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00945_A1234MonDsc = new string[] {""} ;
         P00945_n1234MonDsc = new bool[] {false} ;
         P00945_A511TipSigno = new short[1] ;
         P00945_n511TipSigno = new bool[] {false} ;
         P00945_A513CCImpTotal = new decimal[1] ;
         P00945_A509CCImpPago = new decimal[1] ;
         P00945_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00945_A506CCEstado = new string[] {""} ;
         P00945_A184CCTipCod = new string[] {""} ;
         P00945_A187CCmonCod = new int[1] ;
         P00945_A186CCVendCod = new int[1] ;
         P00945_A188CCCliCod = new string[] {""} ;
         P00945_A161CliDsc = new string[] {""} ;
         P00945_n161CliDsc = new bool[] {false} ;
         A161CliDsc = "";
         P00946_A166CobTip = new string[] {""} ;
         P00946_A167CobCod = new string[] {""} ;
         P00946_A661CobSts = new string[] {""} ;
         P00946_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         P00946_A176CobDocNum = new string[] {""} ;
         P00946_A175CobTipCod = new string[] {""} ;
         P00946_A172CobMon = new int[1] ;
         P00946_A654CobDTot = new decimal[1] ;
         P00946_A663CobTipCam = new decimal[1] ;
         P00946_A173Item = new int[1] ;
         A166CobTip = "";
         A167CobCod = "";
         A661CobSts = "";
         A655CobFec = DateTime.MinValue;
         A176CobDocNum = "";
         A175CobTipCod = "";
         P00947_A506CCEstado = new string[] {""} ;
         P00947_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00947_A186CCVendCod = new int[1] ;
         P00947_A184CCTipCod = new string[] {""} ;
         P00947_A187CCmonCod = new int[1] ;
         P00947_A188CCCliCod = new string[] {""} ;
         P00947_A513CCImpTotal = new decimal[1] ;
         P00947_A509CCImpPago = new decimal[1] ;
         P00947_A511TipSigno = new short[1] ;
         P00947_n511TipSigno = new bool[] {false} ;
         P00947_A185CCDocNum = new string[] {""} ;
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcuentacorrientevendedorexcel__default(),
            new Object[][] {
                new Object[] {
               P00942_A188CCCliCod, P00942_A186CCVendCod, P00942_A2045VenDsc, P00942_n2045VenDsc, P00942_A184CCTipCod, P00942_A185CCDocNum
               }
               , new Object[] {
               P00943_A188CCCliCod, P00943_A186CCVendCod, P00943_A2045VenDsc, P00943_n2045VenDsc, P00943_A184CCTipCod, P00943_A185CCDocNum
               }
               , new Object[] {
               P00944_A189CCCliDsc, P00944_A306TipAbr, P00944_n306TipAbr, P00944_A185CCDocNum, P00944_A508CCFVcto, P00944_A1234MonDsc, P00944_n1234MonDsc, P00944_A184CCTipCod, P00944_A511TipSigno, P00944_n511TipSigno,
               P00944_A513CCImpTotal, P00944_A509CCImpPago, P00944_A187CCmonCod, P00944_A190CCFech, P00944_A506CCEstado, P00944_A186CCVendCod, P00944_A188CCCliCod
               }
               , new Object[] {
               P00945_A189CCCliDsc, P00945_A306TipAbr, P00945_n306TipAbr, P00945_A185CCDocNum, P00945_A508CCFVcto, P00945_A1234MonDsc, P00945_n1234MonDsc, P00945_A511TipSigno, P00945_n511TipSigno, P00945_A513CCImpTotal,
               P00945_A509CCImpPago, P00945_A190CCFech, P00945_A506CCEstado, P00945_A184CCTipCod, P00945_A187CCmonCod, P00945_A186CCVendCod, P00945_A188CCCliCod, P00945_A161CliDsc, P00945_n161CliDsc
               }
               , new Object[] {
               P00946_A166CobTip, P00946_A167CobCod, P00946_A661CobSts, P00946_A655CobFec, P00946_A176CobDocNum, P00946_A175CobTipCod, P00946_A172CobMon, P00946_A654CobDTot, P00946_A663CobTipCam, P00946_A173Item
               }
               , new Object[] {
               P00947_A506CCEstado, P00947_A190CCFech, P00947_A186CCVendCod, P00947_A184CCTipCod, P00947_A187CCmonCod, P00947_A188CCCliCod, P00947_A513CCImpTotal, P00947_A509CCImpPago, P00947_A511TipSigno, P00947_n511TipSigno,
               P00947_A185CCDocNum
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9Mes ;
      private short A511TipSigno ;
      private short AV100Flag ;
      private int AV61MonCod ;
      private int AV101VenCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A186CCVendCod ;
      private int AV102Vendedor ;
      private int A187CCmonCod ;
      private int AV88CCmonCod ;
      private int AV89Dias ;
      private int A172CobMon ;
      private int A173Item ;
      private int AV93CobMon ;
      private decimal AV104TotImpVend ;
      private decimal AV105TotPagoVend ;
      private decimal AV106TotSaldoVend ;
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
      private decimal A654CobDTot ;
      private decimal A663CobTipCam ;
      private decimal AV94CobDtot ;
      private string AV60TipCod ;
      private string AV67CliCod ;
      private string AV71Path ;
      private string AV66cMes ;
      private string GXt_char1 ;
      private string scmdbuf ;
      private string A188CCCliCod ;
      private string A2045VenDsc ;
      private string A184CCTipCod ;
      private string A185CCDocNum ;
      private string AV103VenDsc ;
      private string A506CCEstado ;
      private string A189CCCliDsc ;
      private string A306TipAbr ;
      private string A1234MonDsc ;
      private string AV68CliDsc ;
      private string AV96TipAbr ;
      private string AV83CCDocNum ;
      private string AV99MonDsc ;
      private string AV82CCTipCod ;
      private string A161CliDsc ;
      private string A166CobTip ;
      private string A167CobCod ;
      private string A661CobSts ;
      private string A176CobDocNum ;
      private string A175CobTipCod ;
      private DateTime GXt_dtime2 ;
      private DateTime AV77FHasta ;
      private DateTime A190CCFech ;
      private DateTime A508CCFVcto ;
      private DateTime AV98CCFech ;
      private DateTime AV97CCFVcto ;
      private DateTime A655CobFec ;
      private bool returnInSub ;
      private bool BRK942 ;
      private bool n2045VenDsc ;
      private bool BRK944 ;
      private bool BRK946 ;
      private bool n306TipAbr ;
      private bool n1234MonDsc ;
      private bool n511TipSigno ;
      private bool BRK948 ;
      private bool n161CliDsc ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_TipCod ;
      private string aP1_CliCod ;
      private int aP2_MonCod ;
      private int aP3_VenCod ;
      private DateTime aP4_FHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P00942_A188CCCliCod ;
      private int[] P00942_A186CCVendCod ;
      private string[] P00942_A2045VenDsc ;
      private bool[] P00942_n2045VenDsc ;
      private string[] P00942_A184CCTipCod ;
      private string[] P00942_A185CCDocNum ;
      private string[] P00943_A188CCCliCod ;
      private int[] P00943_A186CCVendCod ;
      private string[] P00943_A2045VenDsc ;
      private bool[] P00943_n2045VenDsc ;
      private string[] P00943_A184CCTipCod ;
      private string[] P00943_A185CCDocNum ;
      private string[] P00944_A189CCCliDsc ;
      private string[] P00944_A306TipAbr ;
      private bool[] P00944_n306TipAbr ;
      private string[] P00944_A185CCDocNum ;
      private DateTime[] P00944_A508CCFVcto ;
      private string[] P00944_A1234MonDsc ;
      private bool[] P00944_n1234MonDsc ;
      private string[] P00944_A184CCTipCod ;
      private short[] P00944_A511TipSigno ;
      private bool[] P00944_n511TipSigno ;
      private decimal[] P00944_A513CCImpTotal ;
      private decimal[] P00944_A509CCImpPago ;
      private int[] P00944_A187CCmonCod ;
      private DateTime[] P00944_A190CCFech ;
      private string[] P00944_A506CCEstado ;
      private int[] P00944_A186CCVendCod ;
      private string[] P00944_A188CCCliCod ;
      private string[] P00945_A189CCCliDsc ;
      private string[] P00945_A306TipAbr ;
      private bool[] P00945_n306TipAbr ;
      private string[] P00945_A185CCDocNum ;
      private DateTime[] P00945_A508CCFVcto ;
      private string[] P00945_A1234MonDsc ;
      private bool[] P00945_n1234MonDsc ;
      private short[] P00945_A511TipSigno ;
      private bool[] P00945_n511TipSigno ;
      private decimal[] P00945_A513CCImpTotal ;
      private decimal[] P00945_A509CCImpPago ;
      private DateTime[] P00945_A190CCFech ;
      private string[] P00945_A506CCEstado ;
      private string[] P00945_A184CCTipCod ;
      private int[] P00945_A187CCmonCod ;
      private int[] P00945_A186CCVendCod ;
      private string[] P00945_A188CCCliCod ;
      private string[] P00945_A161CliDsc ;
      private bool[] P00945_n161CliDsc ;
      private string[] P00946_A166CobTip ;
      private string[] P00946_A167CobCod ;
      private string[] P00946_A661CobSts ;
      private DateTime[] P00946_A655CobFec ;
      private string[] P00946_A176CobDocNum ;
      private string[] P00946_A175CobTipCod ;
      private int[] P00946_A172CobMon ;
      private decimal[] P00946_A654CobDTot ;
      private decimal[] P00946_A663CobTipCam ;
      private int[] P00946_A173Item ;
      private string[] P00947_A506CCEstado ;
      private DateTime[] P00947_A190CCFech ;
      private int[] P00947_A186CCVendCod ;
      private string[] P00947_A184CCTipCod ;
      private int[] P00947_A187CCmonCod ;
      private string[] P00947_A188CCCliCod ;
      private decimal[] P00947_A513CCImpTotal ;
      private decimal[] P00947_A509CCImpPago ;
      private short[] P00947_A511TipSigno ;
      private bool[] P00947_n511TipSigno ;
      private string[] P00947_A185CCDocNum ;
      private string aP5_Filename ;
      private string aP6_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class pcuentacorrientevendedorexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00942( IGxContext context ,
                                             int AV101VenCod ,
                                             string AV67CliCod ,
                                             int A186CCVendCod ,
                                             string A188CCCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliCod] AS CCCliCod, T1.[CCVendCod] AS CCVendCod, T2.[VenDsc], T1.[CCTipCod] AS CCTipCod, T1.[CCDocNum] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[CCVendCod])";
         AddWhere(sWhereString, "(T1.[CCVendCod] <> 0)");
         if ( ! (0==AV101VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV101VenCod)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV67CliCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCVendCod], T1.[CCCliCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00943( IGxContext context ,
                                             int AV101VenCod ,
                                             string AV67CliCod ,
                                             int A186CCVendCod ,
                                             string A188CCCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[2];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliCod] AS CCCliCod, T1.[CCVendCod] AS CCVendCod, T2.[VenDsc], T1.[CCTipCod] AS CCTipCod, T1.[CCDocNum] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[CCVendCod])";
         if ( ! (0==AV101VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV101VenCod)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV67CliCod)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCVendCod], T1.[CCCliCod]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00944( IGxContext context ,
                                             string AV67CliCod ,
                                             int AV61MonCod ,
                                             string AV60TipCod ,
                                             int AV101VenCod ,
                                             string A188CCCliCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             int A186CCVendCod ,
                                             DateTime A190CCFech ,
                                             DateTime AV77FHasta ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[5];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliDsc], T2.[TipAbr], T1.[CCDocNum], T1.[CCFVcto], T3.[MonDsc], T1.[CCTipCod] AS CCTipCod, T2.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCmonCod] AS CCmonCod, T1.[CCFech], T1.[CCEstado], T1.[CCVendCod] AS CCVendCod, T1.[CCCliCod] AS CCCliCod FROM (([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[CCmonCod])";
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV77FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] <> 'A')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV67CliCod)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (0==AV61MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV61MonCod)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV60TipCod)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (0==AV101VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV101VenCod)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCFech] DESC";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00945( IGxContext context ,
                                             string AV67CliCod ,
                                             int AV101VenCod ,
                                             int AV61MonCod ,
                                             string AV60TipCod ,
                                             string A188CCCliCod ,
                                             int A186CCVendCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[4];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliDsc], T2.[TipAbr], T1.[CCDocNum], T1.[CCFVcto], T3.[MonDsc], T2.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCFech], T1.[CCEstado], T1.[CCTipCod] AS CCTipCod, T1.[CCmonCod] AS CCmonCod, T1.[CCVendCod] AS CCVendCod, T1.[CCCliCod] AS CCCliCod, T4.[CliDsc] FROM ((([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[CCmonCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T1.[CCEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV67CliCod)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! (0==AV101VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV101VenCod)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! (0==AV61MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV61MonCod)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV60TipCod)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCFech] DESC";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00947( IGxContext context ,
                                             string AV67CliCod ,
                                             int AV61MonCod ,
                                             string AV60TipCod ,
                                             int AV102Vendedor ,
                                             string A188CCCliCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             int A186CCVendCod ,
                                             DateTime A190CCFech ,
                                             DateTime AV77FHasta ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[5];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.[CCEstado], T1.[CCFech], T1.[CCVendCod] AS CCVendCod, T1.[CCTipCod] AS CCTipCod, T1.[CCmonCod] AS CCmonCod, T1.[CCCliCod] AS CCCliCod, T1.[CCImpTotal], T1.[CCImpPago], T2.[TipSigno], T1.[CCDocNum] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod])";
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV77FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] <> 'A')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV67CliCod)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ! (0==AV61MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV61MonCod)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV60TipCod)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! (0==AV102Vendedor) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV102Vendedor)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCTipCod], T1.[CCDocNum]";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00942(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] );
               case 1 :
                     return conditional_P00943(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] );
               case 2 :
                     return conditional_P00944(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] );
               case 3 :
                     return conditional_P00945(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] );
               case 5 :
                     return conditional_P00947(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] );
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
          Object[] prmP00946;
          prmP00946 = new Object[] {
          new ParDef("@AV82CCTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV83CCDocNum",GXType.NChar,12,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0)
          };
          Object[] prmP00942;
          prmP00942 = new Object[] {
          new ParDef("@AV101VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV67CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00943;
          prmP00943 = new Object[] {
          new ParDef("@AV101VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV67CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00944;
          prmP00944 = new Object[] {
          new ParDef("@AV77FHasta",GXType.Date,8,0) ,
          new ParDef("@AV67CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV61MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV60TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV101VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00945;
          prmP00945 = new Object[] {
          new ParDef("@AV67CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV101VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV61MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV60TipCod",GXType.NChar,3,0)
          };
          Object[] prmP00947;
          prmP00947 = new Object[] {
          new ParDef("@AV77FHasta",GXType.Date,8,0) ,
          new ParDef("@AV67CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV61MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV60TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV102Vendedor",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00942", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00942,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00943", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00943,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00944", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00944,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00945", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00945,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00946", "SELECT T1.[CobTip], T1.[CobCod], T2.[CobSts], T2.[CobFec], T1.[CobDocNum], T1.[CobTipCod], T2.[CobMon], T1.[CobDTot], T1.[CobTipCam], T1.[Item] FROM ([CLCOBRANZADET] T1 INNER JOIN [CLCOBRANZA] T2 ON T2.[CobTip] = T1.[CobTip] AND T2.[CobCod] = T1.[CobCod]) WHERE (T1.[CobTipCod] = @AV82CCTipCod and T1.[CobDocNum] = @AV83CCDocNum) AND (T2.[CobFec] > @AV77FHasta) AND (T2.[CobSts] <> 'A') ORDER BY T1.[CobTipCod], T1.[CobDocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00946,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00947", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00947,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getString(5, 12);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getString(5, 12);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 12);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 3);
                ((short[]) buf[8])[0] = rslt.getShort(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(9);
                ((int[]) buf[12])[0] = rslt.getInt(10);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 1);
                ((int[]) buf[15])[0] = rslt.getInt(13);
                ((string[]) buf[16])[0] = rslt.getString(14, 20);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 12);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(8);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 1);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((int[]) buf[14])[0] = rslt.getInt(12);
                ((int[]) buf[15])[0] = rslt.getInt(13);
                ((string[]) buf[16])[0] = rslt.getString(14, 20);
                ((string[]) buf[17])[0] = rslt.getString(15, 100);
                ((bool[]) buf[18])[0] = rslt.wasNull(15);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 12);
                return;
       }
    }

 }

}
