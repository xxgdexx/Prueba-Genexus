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
   public class r_cuentasxpagarexcel : GXProcedure
   {
      public r_cuentasxpagarexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_cuentasxpagarexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TprvCod ,
                           ref string aP1_EstCod ,
                           ref string aP2_PrvCod ,
                           ref string aP3_TipCod ,
                           ref int aP4_MonCod ,
                           ref DateTime aP5_FHasta ,
                           ref string aP6_TipFecha ,
                           out string aP7_Filename ,
                           out string aP8_ErrorMessage )
      {
         this.AV104TprvCod = aP0_TprvCod;
         this.AV103EstCod = aP1_EstCod;
         this.AV39PrvCod = aP2_PrvCod;
         this.AV60TipCod = aP3_TipCod;
         this.AV61MonCod = aP4_MonCod;
         this.AV77FHasta = aP5_FHasta;
         this.AV102TipFecha = aP6_TipFecha;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_TprvCod=this.AV104TprvCod;
         aP1_EstCod=this.AV103EstCod;
         aP2_PrvCod=this.AV39PrvCod;
         aP3_TipCod=this.AV60TipCod;
         aP4_MonCod=this.AV61MonCod;
         aP5_FHasta=this.AV77FHasta;
         aP6_TipFecha=this.AV102TipFecha;
         aP7_Filename=this.AV10Filename;
         aP8_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref int aP0_TprvCod ,
                                ref string aP1_EstCod ,
                                ref string aP2_PrvCod ,
                                ref string aP3_TipCod ,
                                ref int aP4_MonCod ,
                                ref DateTime aP5_FHasta ,
                                ref string aP6_TipFecha ,
                                out string aP7_Filename )
      {
         execute(ref aP0_TprvCod, ref aP1_EstCod, ref aP2_PrvCod, ref aP3_TipCod, ref aP4_MonCod, ref aP5_FHasta, ref aP6_TipFecha, out aP7_Filename, out aP8_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_TprvCod ,
                                 ref string aP1_EstCod ,
                                 ref string aP2_PrvCod ,
                                 ref string aP3_TipCod ,
                                 ref int aP4_MonCod ,
                                 ref DateTime aP5_FHasta ,
                                 ref string aP6_TipFecha ,
                                 out string aP7_Filename ,
                                 out string aP8_ErrorMessage )
      {
         r_cuentasxpagarexcel objr_cuentasxpagarexcel;
         objr_cuentasxpagarexcel = new r_cuentasxpagarexcel();
         objr_cuentasxpagarexcel.AV104TprvCod = aP0_TprvCod;
         objr_cuentasxpagarexcel.AV103EstCod = aP1_EstCod;
         objr_cuentasxpagarexcel.AV39PrvCod = aP2_PrvCod;
         objr_cuentasxpagarexcel.AV60TipCod = aP3_TipCod;
         objr_cuentasxpagarexcel.AV61MonCod = aP4_MonCod;
         objr_cuentasxpagarexcel.AV77FHasta = aP5_FHasta;
         objr_cuentasxpagarexcel.AV102TipFecha = aP6_TipFecha;
         objr_cuentasxpagarexcel.AV10Filename = "" ;
         objr_cuentasxpagarexcel.AV11ErrorMessage = "" ;
         objr_cuentasxpagarexcel.context.SetSubmitInitialConfig(context);
         objr_cuentasxpagarexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_cuentasxpagarexcel);
         aP0_TprvCod=this.AV104TprvCod;
         aP1_EstCod=this.AV103EstCod;
         aP2_PrvCod=this.AV39PrvCod;
         aP3_TipCod=this.AV60TipCod;
         aP4_MonCod=this.AV61MonCod;
         aP5_FHasta=this.AV77FHasta;
         aP6_TipFecha=this.AV102TipFecha;
         aP7_Filename=this.AV10Filename;
         aP8_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_cuentasxpagarexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasCuentaPagar.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasCuentaPagar.xlsx";
         AV10Filename = "Excel/CuentaPagar" + ".xlsx";
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
         AV15FirstColumn = 1;
         GXt_char1 = AV66cMes;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV9Mes, out  GXt_char1) ;
         AV66cMes = GXt_char1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Al "+context.localUtil.DToC( AV77FHasta, 2, "/");
         AV14CellRow = 5;
         AV15FirstColumn = 1;
         if ( DateTimeUtil.ResetTime ( AV77FHasta ) == DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
         {
            /* Execute user subroutine: 'CUENTAPAGAR' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'CUENTAPAGARAL' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
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
         /* 'CUENTAPAGAR' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV39PrvCod ,
                                              AV103EstCod ,
                                              AV104TprvCod ,
                                              AV61MonCod ,
                                              AV60TipCod ,
                                              A262CPPrvCod ,
                                              A140EstCod ,
                                              A298TprvCod ,
                                              A263CPMonCod ,
                                              A260CPTipCod ,
                                              A815CPEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P009K2 */
         pr_default.execute(0, new Object[] {AV39PrvCod, AV103EstCod, AV104TprvCod, AV61MonCod, AV60TipCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK9K2 = false;
            A815CPEstado = P009K2_A815CPEstado[0];
            A831CPPrvDsc = P009K2_A831CPPrvDsc[0];
            A856CPTipAbr = P009K2_A856CPTipAbr[0];
            A264CPFech = P009K2_A264CPFech[0];
            A817CPFVcto = P009K2_A817CPFVcto[0];
            A511TipSigno = P009K2_A511TipSigno[0];
            n511TipSigno = P009K2_n511TipSigno[0];
            A820CPImpTotal = P009K2_A820CPImpTotal[0];
            A830CPMonDsc = P009K2_A830CPMonDsc[0];
            A818CPImpPago = P009K2_A818CPImpPago[0];
            A261CPComCod = P009K2_A261CPComCod[0];
            A260CPTipCod = P009K2_A260CPTipCod[0];
            A263CPMonCod = P009K2_A263CPMonCod[0];
            A298TprvCod = P009K2_A298TprvCod[0];
            n298TprvCod = P009K2_n298TprvCod[0];
            A140EstCod = P009K2_A140EstCod[0];
            n140EstCod = P009K2_n140EstCod[0];
            A262CPPrvCod = P009K2_A262CPPrvCod[0];
            A856CPTipAbr = P009K2_A856CPTipAbr[0];
            A511TipSigno = P009K2_A511TipSigno[0];
            n511TipSigno = P009K2_n511TipSigno[0];
            A830CPMonDsc = P009K2_A830CPMonDsc[0];
            A831CPPrvDsc = P009K2_A831CPPrvDsc[0];
            A298TprvCod = P009K2_A298TprvCod[0];
            n298TprvCod = P009K2_n298TprvCod[0];
            A140EstCod = P009K2_A140EstCod[0];
            n140EstCod = P009K2_n140EstCod[0];
            AV105CPPrvCod = A262CPPrvCod;
            AV106CPPrvDsc = A831CPPrvDsc;
            AV79TotImporte = 0.00m;
            AV80TotPagos = 0.00m;
            AV81TotSaldo = 0.00m;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P009K2_A831CPPrvDsc[0], A831CPPrvDsc) == 0 ) )
            {
               BRK9K2 = false;
               A856CPTipAbr = P009K2_A856CPTipAbr[0];
               A264CPFech = P009K2_A264CPFech[0];
               A817CPFVcto = P009K2_A817CPFVcto[0];
               A511TipSigno = P009K2_A511TipSigno[0];
               n511TipSigno = P009K2_n511TipSigno[0];
               A820CPImpTotal = P009K2_A820CPImpTotal[0];
               A830CPMonDsc = P009K2_A830CPMonDsc[0];
               A818CPImpPago = P009K2_A818CPImpPago[0];
               A261CPComCod = P009K2_A261CPComCod[0];
               A260CPTipCod = P009K2_A260CPTipCod[0];
               A263CPMonCod = P009K2_A263CPMonCod[0];
               A262CPPrvCod = P009K2_A262CPPrvCod[0];
               A856CPTipAbr = P009K2_A856CPTipAbr[0];
               A511TipSigno = P009K2_A511TipSigno[0];
               n511TipSigno = P009K2_n511TipSigno[0];
               A830CPMonDsc = P009K2_A830CPMonDsc[0];
               AV96TipAbr = A856CPTipAbr;
               AV107CPComCod = A261CPComCod;
               AV109CPFech = A264CPFech;
               AV108CPFVcto = A817CPFVcto;
               AV84Importe = (decimal)(A820CPImpTotal*A511TipSigno);
               AV99MonDsc = A830CPMonDsc;
               AV85Pagos = (decimal)(A818CPImpPago*A511TipSigno);
               AV95Saldo = (decimal)((A820CPImpTotal-A818CPImpPago)*A511TipSigno);
               AV79TotImporte = (decimal)(AV79TotImporte+AV84Importe);
               AV80TotPagos = (decimal)(AV80TotPagos+AV85Pagos);
               AV81TotSaldo = (decimal)(AV81TotSaldo+AV95Saldo);
               AV89Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A817CPFVcto));
               /* Execute user subroutine: 'DETALLE' */
               S123 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               BRK9K2 = true;
               pr_default.readNext(0);
            }
            AV90TotGImporte = (decimal)(AV90TotGImporte+AV79TotImporte);
            AV91TotGPagos = (decimal)(AV91TotGPagos+AV80TotPagos);
            AV92TotGSaldo = (decimal)(AV92TotGSaldo+AV81TotSaldo);
            if ( ! BRK9K2 )
            {
               BRK9K2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'CUENTAPAGARAL' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV39PrvCod ,
                                              AV103EstCod ,
                                              AV104TprvCod ,
                                              AV61MonCod ,
                                              AV60TipCod ,
                                              AV102TipFecha ,
                                              A262CPPrvCod ,
                                              A140EstCod ,
                                              A298TprvCod ,
                                              A263CPMonCod ,
                                              A260CPTipCod ,
                                              A264CPFech ,
                                              AV77FHasta ,
                                              A816CPFReg ,
                                              A815CPEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P009K3 */
         pr_default.execute(1, new Object[] {AV39PrvCod, AV103EstCod, AV104TprvCod, AV61MonCod, AV60TipCod, AV77FHasta, AV77FHasta});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK9K4 = false;
            A831CPPrvDsc = P009K3_A831CPPrvDsc[0];
            A262CPPrvCod = P009K3_A262CPPrvCod[0];
            A856CPTipAbr = P009K3_A856CPTipAbr[0];
            A264CPFech = P009K3_A264CPFech[0];
            A817CPFVcto = P009K3_A817CPFVcto[0];
            A511TipSigno = P009K3_A511TipSigno[0];
            n511TipSigno = P009K3_n511TipSigno[0];
            A820CPImpTotal = P009K3_A820CPImpTotal[0];
            A830CPMonDsc = P009K3_A830CPMonDsc[0];
            A818CPImpPago = P009K3_A818CPImpPago[0];
            A263CPMonCod = P009K3_A263CPMonCod[0];
            A261CPComCod = P009K3_A261CPComCod[0];
            A260CPTipCod = P009K3_A260CPTipCod[0];
            A815CPEstado = P009K3_A815CPEstado[0];
            A816CPFReg = P009K3_A816CPFReg[0];
            A298TprvCod = P009K3_A298TprvCod[0];
            n298TprvCod = P009K3_n298TprvCod[0];
            A140EstCod = P009K3_A140EstCod[0];
            n140EstCod = P009K3_n140EstCod[0];
            A831CPPrvDsc = P009K3_A831CPPrvDsc[0];
            A298TprvCod = P009K3_A298TprvCod[0];
            n298TprvCod = P009K3_n298TprvCod[0];
            A140EstCod = P009K3_A140EstCod[0];
            n140EstCod = P009K3_n140EstCod[0];
            A830CPMonDsc = P009K3_A830CPMonDsc[0];
            A856CPTipAbr = P009K3_A856CPTipAbr[0];
            A511TipSigno = P009K3_A511TipSigno[0];
            n511TipSigno = P009K3_n511TipSigno[0];
            AV39PrvCod = A262CPPrvCod;
            AV105CPPrvCod = A262CPPrvCod;
            AV106CPPrvDsc = A831CPPrvDsc;
            /* Execute user subroutine: 'VALIDAMOV' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV79TotImporte = 0.00m;
            AV80TotPagos = 0.00m;
            AV81TotSaldo = 0.00m;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P009K3_A831CPPrvDsc[0], A831CPPrvDsc) == 0 ) )
            {
               BRK9K4 = false;
               A262CPPrvCod = P009K3_A262CPPrvCod[0];
               A856CPTipAbr = P009K3_A856CPTipAbr[0];
               A264CPFech = P009K3_A264CPFech[0];
               A817CPFVcto = P009K3_A817CPFVcto[0];
               A511TipSigno = P009K3_A511TipSigno[0];
               n511TipSigno = P009K3_n511TipSigno[0];
               A820CPImpTotal = P009K3_A820CPImpTotal[0];
               A830CPMonDsc = P009K3_A830CPMonDsc[0];
               A818CPImpPago = P009K3_A818CPImpPago[0];
               A263CPMonCod = P009K3_A263CPMonCod[0];
               A261CPComCod = P009K3_A261CPComCod[0];
               A260CPTipCod = P009K3_A260CPTipCod[0];
               A830CPMonDsc = P009K3_A830CPMonDsc[0];
               A856CPTipAbr = P009K3_A856CPTipAbr[0];
               A511TipSigno = P009K3_A511TipSigno[0];
               n511TipSigno = P009K3_n511TipSigno[0];
               AV105CPPrvCod = A262CPPrvCod;
               AV110CPTipCod = A260CPTipCod;
               AV107CPComCod = A261CPComCod;
               AV96TipAbr = A856CPTipAbr;
               AV109CPFech = A264CPFech;
               AV108CPFVcto = A817CPFVcto;
               AV84Importe = (decimal)(A820CPImpTotal*A511TipSigno);
               AV99MonDsc = A830CPMonDsc;
               AV84Importe = (decimal)(A820CPImpTotal*A511TipSigno);
               AV85Pagos = (decimal)(A818CPImpPago*A511TipSigno);
               AV86ImpDoc = A820CPImpTotal;
               AV87PagoDoc = A818CPImpPago;
               AV111CPMonCod = A263CPMonCod;
               /* Execute user subroutine: 'PAGOS' */
               S155 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               if ( ( AV87PagoDoc < Convert.ToDecimal( 0 )) )
               {
                  AV87PagoDoc = 0;
               }
               AV84Importe = (decimal)(AV86ImpDoc*A511TipSigno);
               AV85Pagos = (decimal)(AV87PagoDoc*A511TipSigno);
               AV95Saldo = (decimal)((AV86ImpDoc-AV87PagoDoc)*A511TipSigno);
               AV89Dias = (int)(DateTimeUtil.DDiff(A817CPFVcto,DateTimeUtil.Today( context)));
               if ( ( AV95Saldo != Convert.ToDecimal( 0 )) )
               {
                  AV79TotImporte = (decimal)(AV79TotImporte+AV84Importe);
                  AV80TotPagos = (decimal)(AV80TotPagos+AV85Pagos);
                  AV81TotSaldo = (decimal)(AV81TotSaldo+AV95Saldo);
                  /* Execute user subroutine: 'DETALLE' */
                  S123 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               BRK9K4 = true;
               pr_default.readNext(1);
            }
            if ( ( AV81TotSaldo != Convert.ToDecimal( 0 )) )
            {
            }
            AV90TotGImporte = (decimal)(AV90TotGImporte+AV79TotImporte);
            AV91TotGPagos = (decimal)(AV91TotGPagos+AV80TotPagos);
            AV92TotGSaldo = (decimal)(AV92TotGSaldo+AV81TotSaldo);
            if ( ! BRK9K4 )
            {
               BRK9K4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S155( )
      {
         /* 'PAGOS' Routine */
         returnInSub = false;
         /* Using cursor P009K4 */
         pr_default.execute(2, new Object[] {AV110CPTipCod, AV107CPComCod, AV77FHasta, AV105CPPrvCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A412PagReg = P009K4_A412PagReg[0];
            A418PagFech = P009K4_A418PagFech[0];
            A421PagDComCod = P009K4_A421PagDComCod[0];
            A420PagDTipCod = P009K4_A420PagDTipCod[0];
            A417PagPrvCod = P009K4_A417PagPrvCod[0];
            A413PagMonCod = P009K4_A413PagMonCod[0];
            A1481PagDTot = P009K4_A1481PagDTot[0];
            A1491PagTipCmb = P009K4_A1491PagTipCmb[0];
            A419PagItem = P009K4_A419PagItem[0];
            A418PagFech = P009K4_A418PagFech[0];
            A417PagPrvCod = P009K4_A417PagPrvCod[0];
            A413PagMonCod = P009K4_A413PagMonCod[0];
            A1491PagTipCmb = P009K4_A1491PagTipCmb[0];
            AV113PagMonCod = A413PagMonCod;
            AV112PagDTot = NumberUtil.Round( A1481PagDTot, 2);
            if ( ( AV112PagDTot < Convert.ToDecimal( 0 )) )
            {
               AV112PagDTot = (decimal)(AV112PagDTot*-1);
            }
            if ( AV111CPMonCod == AV113PagMonCod )
            {
               AV87PagoDoc = (decimal)(AV87PagoDoc-AV112PagDTot);
            }
            else
            {
               if ( AV111CPMonCod == 1 )
               {
                  AV87PagoDoc = (decimal)(AV87PagoDoc-(NumberUtil.Round( AV112PagDTot*A1491PagTipCmb, 2)));
               }
               else
               {
                  AV87PagoDoc = (decimal)(AV87PagoDoc-(NumberUtil.Round( AV112PagDTot/ (decimal)(A1491PagTipCmb), 2)));
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S144( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         AV100Flag = 0;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV103EstCod ,
                                              AV104TprvCod ,
                                              AV61MonCod ,
                                              AV60TipCod ,
                                              A140EstCod ,
                                              A298TprvCod ,
                                              A263CPMonCod ,
                                              A260CPTipCod ,
                                              A264CPFech ,
                                              AV77FHasta ,
                                              A815CPEstado ,
                                              A262CPPrvCod ,
                                              AV39PrvCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P009K5 */
         pr_default.execute(3, new Object[] {AV77FHasta, AV39PrvCod, AV103EstCod, AV104TprvCod, AV61MonCod, AV60TipCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A815CPEstado = P009K5_A815CPEstado[0];
            A264CPFech = P009K5_A264CPFech[0];
            A260CPTipCod = P009K5_A260CPTipCod[0];
            A263CPMonCod = P009K5_A263CPMonCod[0];
            A298TprvCod = P009K5_A298TprvCod[0];
            n298TprvCod = P009K5_n298TprvCod[0];
            A140EstCod = P009K5_A140EstCod[0];
            n140EstCod = P009K5_n140EstCod[0];
            A262CPPrvCod = P009K5_A262CPPrvCod[0];
            A820CPImpTotal = P009K5_A820CPImpTotal[0];
            A818CPImpPago = P009K5_A818CPImpPago[0];
            A511TipSigno = P009K5_A511TipSigno[0];
            n511TipSigno = P009K5_n511TipSigno[0];
            A817CPFVcto = P009K5_A817CPFVcto[0];
            A261CPComCod = P009K5_A261CPComCod[0];
            A511TipSigno = P009K5_A511TipSigno[0];
            n511TipSigno = P009K5_n511TipSigno[0];
            A298TprvCod = P009K5_A298TprvCod[0];
            n298TprvCod = P009K5_n298TprvCod[0];
            A140EstCod = P009K5_A140EstCod[0];
            n140EstCod = P009K5_n140EstCod[0];
            AV105CPPrvCod = A262CPPrvCod;
            AV110CPTipCod = A260CPTipCod;
            AV107CPComCod = A261CPComCod;
            AV84Importe = A820CPImpTotal;
            AV85Pagos = A818CPImpPago;
            AV111CPMonCod = A263CPMonCod;
            AV86ImpDoc = A820CPImpTotal;
            AV87PagoDoc = A818CPImpPago;
            AV111CPMonCod = A263CPMonCod;
            /* Execute user subroutine: 'PAGOS' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            if ( ( AV87PagoDoc < Convert.ToDecimal( 0 )) )
            {
               AV87PagoDoc = 0;
            }
            AV84Importe = (decimal)(AV86ImpDoc*A511TipSigno);
            AV85Pagos = (decimal)(AV87PagoDoc*A511TipSigno);
            AV95Saldo = (decimal)((AV86ImpDoc-AV87PagoDoc)*A511TipSigno);
            AV79TotImporte = (decimal)(AV79TotImporte+AV84Importe);
            AV80TotPagos = (decimal)(AV80TotPagos+AV85Pagos);
            AV81TotSaldo = (decimal)(AV81TotSaldo+AV95Saldo);
            AV89Dias = (int)(DateTimeUtil.DDiff(A817CPFVcto,DateTimeUtil.Today( context)));
            if ( ( AV95Saldo != Convert.ToDecimal( 0 )) )
            {
               AV100Flag = 1;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
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

      protected void S123( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV105CPPrvCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV106CPPrvDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV96TipAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV107CPComCod);
         GXt_dtime2 = DateTimeUtil.ResetTime( AV109CPFech ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Date = GXt_dtime2;
         GXt_dtime2 = DateTimeUtil.ResetTime( AV108CPFVcto ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Date = GXt_dtime2;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = AV89Dias;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV99MonDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV84Importe);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV85Pagos);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV95Saldo);
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
         AV72Archivo = new GxFile(context.GetPhysicalPath());
         AV71Path = "";
         AV70FilenameOrigen = "";
         AV13ExcelDocument = new ExcelDocumentI();
         AV66cMes = "";
         GXt_char1 = "";
         scmdbuf = "";
         A262CPPrvCod = "";
         A140EstCod = "";
         A260CPTipCod = "";
         A815CPEstado = "";
         P009K2_A815CPEstado = new string[] {""} ;
         P009K2_A831CPPrvDsc = new string[] {""} ;
         P009K2_A856CPTipAbr = new string[] {""} ;
         P009K2_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009K2_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         P009K2_A511TipSigno = new short[1] ;
         P009K2_n511TipSigno = new bool[] {false} ;
         P009K2_A820CPImpTotal = new decimal[1] ;
         P009K2_A830CPMonDsc = new string[] {""} ;
         P009K2_A818CPImpPago = new decimal[1] ;
         P009K2_A261CPComCod = new string[] {""} ;
         P009K2_A260CPTipCod = new string[] {""} ;
         P009K2_A263CPMonCod = new int[1] ;
         P009K2_A298TprvCod = new int[1] ;
         P009K2_n298TprvCod = new bool[] {false} ;
         P009K2_A140EstCod = new string[] {""} ;
         P009K2_n140EstCod = new bool[] {false} ;
         P009K2_A262CPPrvCod = new string[] {""} ;
         A831CPPrvDsc = "";
         A856CPTipAbr = "";
         A264CPFech = DateTime.MinValue;
         A817CPFVcto = DateTime.MinValue;
         A830CPMonDsc = "";
         A261CPComCod = "";
         AV105CPPrvCod = "";
         AV106CPPrvDsc = "";
         AV96TipAbr = "";
         AV107CPComCod = "";
         AV109CPFech = DateTime.MinValue;
         AV108CPFVcto = DateTime.MinValue;
         AV99MonDsc = "";
         A816CPFReg = DateTime.MinValue;
         P009K3_A831CPPrvDsc = new string[] {""} ;
         P009K3_A262CPPrvCod = new string[] {""} ;
         P009K3_A856CPTipAbr = new string[] {""} ;
         P009K3_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009K3_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         P009K3_A511TipSigno = new short[1] ;
         P009K3_n511TipSigno = new bool[] {false} ;
         P009K3_A820CPImpTotal = new decimal[1] ;
         P009K3_A830CPMonDsc = new string[] {""} ;
         P009K3_A818CPImpPago = new decimal[1] ;
         P009K3_A263CPMonCod = new int[1] ;
         P009K3_A261CPComCod = new string[] {""} ;
         P009K3_A260CPTipCod = new string[] {""} ;
         P009K3_A815CPEstado = new string[] {""} ;
         P009K3_A816CPFReg = new DateTime[] {DateTime.MinValue} ;
         P009K3_A298TprvCod = new int[1] ;
         P009K3_n298TprvCod = new bool[] {false} ;
         P009K3_A140EstCod = new string[] {""} ;
         P009K3_n140EstCod = new bool[] {false} ;
         AV110CPTipCod = "";
         P009K4_A412PagReg = new long[1] ;
         P009K4_A418PagFech = new DateTime[] {DateTime.MinValue} ;
         P009K4_A421PagDComCod = new string[] {""} ;
         P009K4_A420PagDTipCod = new string[] {""} ;
         P009K4_A417PagPrvCod = new string[] {""} ;
         P009K4_A413PagMonCod = new int[1] ;
         P009K4_A1481PagDTot = new decimal[1] ;
         P009K4_A1491PagTipCmb = new decimal[1] ;
         P009K4_A419PagItem = new short[1] ;
         A418PagFech = DateTime.MinValue;
         A421PagDComCod = "";
         A420PagDTipCod = "";
         A417PagPrvCod = "";
         P009K5_A815CPEstado = new string[] {""} ;
         P009K5_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009K5_A260CPTipCod = new string[] {""} ;
         P009K5_A263CPMonCod = new int[1] ;
         P009K5_A298TprvCod = new int[1] ;
         P009K5_n298TprvCod = new bool[] {false} ;
         P009K5_A140EstCod = new string[] {""} ;
         P009K5_n140EstCod = new bool[] {false} ;
         P009K5_A262CPPrvCod = new string[] {""} ;
         P009K5_A820CPImpTotal = new decimal[1] ;
         P009K5_A818CPImpPago = new decimal[1] ;
         P009K5_A511TipSigno = new short[1] ;
         P009K5_n511TipSigno = new bool[] {false} ;
         P009K5_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         P009K5_A261CPComCod = new string[] {""} ;
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_cuentasxpagarexcel__default(),
            new Object[][] {
                new Object[] {
               P009K2_A815CPEstado, P009K2_A831CPPrvDsc, P009K2_A856CPTipAbr, P009K2_A264CPFech, P009K2_A817CPFVcto, P009K2_A511TipSigno, P009K2_n511TipSigno, P009K2_A820CPImpTotal, P009K2_A830CPMonDsc, P009K2_A818CPImpPago,
               P009K2_A261CPComCod, P009K2_A260CPTipCod, P009K2_A263CPMonCod, P009K2_A298TprvCod, P009K2_n298TprvCod, P009K2_A140EstCod, P009K2_n140EstCod, P009K2_A262CPPrvCod
               }
               , new Object[] {
               P009K3_A831CPPrvDsc, P009K3_A262CPPrvCod, P009K3_A856CPTipAbr, P009K3_A264CPFech, P009K3_A817CPFVcto, P009K3_A511TipSigno, P009K3_n511TipSigno, P009K3_A820CPImpTotal, P009K3_A830CPMonDsc, P009K3_A818CPImpPago,
               P009K3_A263CPMonCod, P009K3_A261CPComCod, P009K3_A260CPTipCod, P009K3_A815CPEstado, P009K3_A816CPFReg, P009K3_A298TprvCod, P009K3_n298TprvCod, P009K3_A140EstCod, P009K3_n140EstCod
               }
               , new Object[] {
               P009K4_A412PagReg, P009K4_A418PagFech, P009K4_A421PagDComCod, P009K4_A420PagDTipCod, P009K4_A417PagPrvCod, P009K4_A413PagMonCod, P009K4_A1481PagDTot, P009K4_A1491PagTipCmb, P009K4_A419PagItem
               }
               , new Object[] {
               P009K5_A815CPEstado, P009K5_A264CPFech, P009K5_A260CPTipCod, P009K5_A263CPMonCod, P009K5_A298TprvCod, P009K5_n298TprvCod, P009K5_A140EstCod, P009K5_n140EstCod, P009K5_A262CPPrvCod, P009K5_A820CPImpTotal,
               P009K5_A818CPImpPago, P009K5_A511TipSigno, P009K5_n511TipSigno, P009K5_A817CPFVcto, P009K5_A261CPComCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9Mes ;
      private short A511TipSigno ;
      private short A419PagItem ;
      private short AV100Flag ;
      private int AV104TprvCod ;
      private int AV61MonCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A298TprvCod ;
      private int A263CPMonCod ;
      private int AV89Dias ;
      private int AV111CPMonCod ;
      private int A413PagMonCod ;
      private int AV113PagMonCod ;
      private long A412PagReg ;
      private decimal A820CPImpTotal ;
      private decimal A818CPImpPago ;
      private decimal AV79TotImporte ;
      private decimal AV80TotPagos ;
      private decimal AV81TotSaldo ;
      private decimal AV84Importe ;
      private decimal AV85Pagos ;
      private decimal AV95Saldo ;
      private decimal AV90TotGImporte ;
      private decimal AV91TotGPagos ;
      private decimal AV92TotGSaldo ;
      private decimal AV86ImpDoc ;
      private decimal AV87PagoDoc ;
      private decimal A1481PagDTot ;
      private decimal A1491PagTipCmb ;
      private decimal AV112PagDTot ;
      private string AV103EstCod ;
      private string AV39PrvCod ;
      private string AV60TipCod ;
      private string AV102TipFecha ;
      private string AV71Path ;
      private string AV66cMes ;
      private string GXt_char1 ;
      private string scmdbuf ;
      private string A262CPPrvCod ;
      private string A140EstCod ;
      private string A260CPTipCod ;
      private string A815CPEstado ;
      private string A831CPPrvDsc ;
      private string A856CPTipAbr ;
      private string A830CPMonDsc ;
      private string A261CPComCod ;
      private string AV105CPPrvCod ;
      private string AV106CPPrvDsc ;
      private string AV96TipAbr ;
      private string AV107CPComCod ;
      private string AV99MonDsc ;
      private string AV110CPTipCod ;
      private string A421PagDComCod ;
      private string A420PagDTipCod ;
      private string A417PagPrvCod ;
      private DateTime GXt_dtime2 ;
      private DateTime AV77FHasta ;
      private DateTime A264CPFech ;
      private DateTime A817CPFVcto ;
      private DateTime AV109CPFech ;
      private DateTime AV108CPFVcto ;
      private DateTime A816CPFReg ;
      private DateTime A418PagFech ;
      private bool returnInSub ;
      private bool BRK9K2 ;
      private bool n511TipSigno ;
      private bool n298TprvCod ;
      private bool n140EstCod ;
      private bool BRK9K4 ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TprvCod ;
      private string aP1_EstCod ;
      private string aP2_PrvCod ;
      private string aP3_TipCod ;
      private int aP4_MonCod ;
      private DateTime aP5_FHasta ;
      private string aP6_TipFecha ;
      private IDataStoreProvider pr_default ;
      private string[] P009K2_A815CPEstado ;
      private string[] P009K2_A831CPPrvDsc ;
      private string[] P009K2_A856CPTipAbr ;
      private DateTime[] P009K2_A264CPFech ;
      private DateTime[] P009K2_A817CPFVcto ;
      private short[] P009K2_A511TipSigno ;
      private bool[] P009K2_n511TipSigno ;
      private decimal[] P009K2_A820CPImpTotal ;
      private string[] P009K2_A830CPMonDsc ;
      private decimal[] P009K2_A818CPImpPago ;
      private string[] P009K2_A261CPComCod ;
      private string[] P009K2_A260CPTipCod ;
      private int[] P009K2_A263CPMonCod ;
      private int[] P009K2_A298TprvCod ;
      private bool[] P009K2_n298TprvCod ;
      private string[] P009K2_A140EstCod ;
      private bool[] P009K2_n140EstCod ;
      private string[] P009K2_A262CPPrvCod ;
      private string[] P009K3_A831CPPrvDsc ;
      private string[] P009K3_A262CPPrvCod ;
      private string[] P009K3_A856CPTipAbr ;
      private DateTime[] P009K3_A264CPFech ;
      private DateTime[] P009K3_A817CPFVcto ;
      private short[] P009K3_A511TipSigno ;
      private bool[] P009K3_n511TipSigno ;
      private decimal[] P009K3_A820CPImpTotal ;
      private string[] P009K3_A830CPMonDsc ;
      private decimal[] P009K3_A818CPImpPago ;
      private int[] P009K3_A263CPMonCod ;
      private string[] P009K3_A261CPComCod ;
      private string[] P009K3_A260CPTipCod ;
      private string[] P009K3_A815CPEstado ;
      private DateTime[] P009K3_A816CPFReg ;
      private int[] P009K3_A298TprvCod ;
      private bool[] P009K3_n298TprvCod ;
      private string[] P009K3_A140EstCod ;
      private bool[] P009K3_n140EstCod ;
      private long[] P009K4_A412PagReg ;
      private DateTime[] P009K4_A418PagFech ;
      private string[] P009K4_A421PagDComCod ;
      private string[] P009K4_A420PagDTipCod ;
      private string[] P009K4_A417PagPrvCod ;
      private int[] P009K4_A413PagMonCod ;
      private decimal[] P009K4_A1481PagDTot ;
      private decimal[] P009K4_A1491PagTipCmb ;
      private short[] P009K4_A419PagItem ;
      private string[] P009K5_A815CPEstado ;
      private DateTime[] P009K5_A264CPFech ;
      private string[] P009K5_A260CPTipCod ;
      private int[] P009K5_A263CPMonCod ;
      private int[] P009K5_A298TprvCod ;
      private bool[] P009K5_n298TprvCod ;
      private string[] P009K5_A140EstCod ;
      private bool[] P009K5_n140EstCod ;
      private string[] P009K5_A262CPPrvCod ;
      private decimal[] P009K5_A820CPImpTotal ;
      private decimal[] P009K5_A818CPImpPago ;
      private short[] P009K5_A511TipSigno ;
      private bool[] P009K5_n511TipSigno ;
      private DateTime[] P009K5_A817CPFVcto ;
      private string[] P009K5_A261CPComCod ;
      private string aP7_Filename ;
      private string aP8_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class r_cuentasxpagarexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009K2( IGxContext context ,
                                             string AV39PrvCod ,
                                             string AV103EstCod ,
                                             int AV104TprvCod ,
                                             int AV61MonCod ,
                                             string AV60TipCod ,
                                             string A262CPPrvCod ,
                                             string A140EstCod ,
                                             int A298TprvCod ,
                                             int A263CPMonCod ,
                                             string A260CPTipCod ,
                                             string A815CPEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CPEstado], T4.[PrvDsc] AS CPPrvDsc, T2.[TipAbr] AS CPTipAbr, T1.[CPFech], T1.[CPFVcto], T2.[TipSigno], T1.[CPImpTotal], T3.[MonDsc] AS CPMonDsc, T1.[CPImpPago], T1.[CPComCod], T1.[CPTipCod] AS CPTipCod, T1.[CPMonCod] AS CPMonCod, T4.[TprvCod], T4.[EstCod], T1.[CPPrvCod] AS CPPrvCod FROM ((([CPCUENTAPAGAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CPTipCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[CPMonCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[CPPrvCod])";
         AddWhere(sWhereString, "(T1.[CPEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV39PrvCod)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103EstCod)) )
         {
            AddWhere(sWhereString, "(T4.[EstCod] = @AV103EstCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV104TprvCod) )
         {
            AddWhere(sWhereString, "(T4.[TprvCod] = @AV104TprvCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV61MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV61MonCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPTipCod] = @AV60TipCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.[PrvDsc], T1.[CPTipCod], T1.[CPComCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P009K3( IGxContext context ,
                                             string AV39PrvCod ,
                                             string AV103EstCod ,
                                             int AV104TprvCod ,
                                             int AV61MonCod ,
                                             string AV60TipCod ,
                                             string AV102TipFecha ,
                                             string A262CPPrvCod ,
                                             string A140EstCod ,
                                             int A298TprvCod ,
                                             int A263CPMonCod ,
                                             string A260CPTipCod ,
                                             DateTime A264CPFech ,
                                             DateTime AV77FHasta ,
                                             DateTime A816CPFReg ,
                                             string A815CPEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[7];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T2.[PrvDsc] AS CPPrvDsc, T1.[CPPrvCod] AS CPPrvCod, T4.[TipAbr] AS CPTipAbr, T1.[CPFech], T1.[CPFVcto], T4.[TipSigno], T1.[CPImpTotal], T3.[MonDsc] AS CPMonDsc, T1.[CPImpPago], T1.[CPMonCod] AS CPMonCod, T1.[CPComCod], T1.[CPTipCod] AS CPTipCod, T1.[CPEstado], T1.[CPFReg], T2.[TprvCod], T2.[EstCod] FROM ((([CPCUENTAPAGAR] T1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = T1.[CPPrvCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[CPMonCod]) INNER JOIN [CTIPDOC] T4 ON T4.[TipCod] = T1.[CPTipCod])";
         AddWhere(sWhereString, "(T1.[CPEstado] <> 'A')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV39PrvCod)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103EstCod)) )
         {
            AddWhere(sWhereString, "(T2.[EstCod] = @AV103EstCod)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV104TprvCod) )
         {
            AddWhere(sWhereString, "(T2.[TprvCod] = @AV104TprvCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV61MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV61MonCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPTipCod] = @AV60TipCod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV102TipFecha, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[CPFech] <= @AV77FHasta)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV102TipFecha, "R") == 0 )
         {
            AddWhere(sWhereString, "(T1.[CPFReg] <= @AV77FHasta)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[PrvDsc], T1.[CPTipCod], T1.[CPComCod]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P009K5( IGxContext context ,
                                             string AV103EstCod ,
                                             int AV104TprvCod ,
                                             int AV61MonCod ,
                                             string AV60TipCod ,
                                             string A140EstCod ,
                                             int A298TprvCod ,
                                             int A263CPMonCod ,
                                             string A260CPTipCod ,
                                             DateTime A264CPFech ,
                                             DateTime AV77FHasta ,
                                             string A815CPEstado ,
                                             string A262CPPrvCod ,
                                             string AV39PrvCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[6];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[CPEstado], T1.[CPFech], T1.[CPTipCod] AS CPTipCod, T1.[CPMonCod] AS CPMonCod, T3.[TprvCod], T3.[EstCod], T1.[CPPrvCod] AS CPPrvCod, T1.[CPImpTotal], T1.[CPImpPago], T2.[TipSigno], T1.[CPFVcto], T1.[CPComCod] FROM (([CPCUENTAPAGAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CPTipCod]) INNER JOIN [CPPROVEEDORES] T3 ON T3.[PrvCod] = T1.[CPPrvCod])";
         AddWhere(sWhereString, "(T1.[CPFech] <= @AV77FHasta)");
         AddWhere(sWhereString, "(T1.[CPEstado] <> 'A')");
         AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV39PrvCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103EstCod)) )
         {
            AddWhere(sWhereString, "(T3.[EstCod] = @AV103EstCod)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (0==AV104TprvCod) )
         {
            AddWhere(sWhereString, "(T3.[TprvCod] = @AV104TprvCod)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (0==AV61MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV61MonCod)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPTipCod] = @AV60TipCod)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CPTipCod], T1.[CPComCod], T1.[CPPrvCod]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P009K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
               case 1 :
                     return conditional_P009K3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] );
               case 3 :
                     return conditional_P009K5(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
          Object[] prmP009K4;
          prmP009K4 = new Object[] {
          new ParDef("@AV110CPTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV107CPComCod",GXType.NChar,15,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0) ,
          new ParDef("@AV105CPPrvCod",GXType.NChar,20,0)
          };
          Object[] prmP009K2;
          prmP009K2 = new Object[] {
          new ParDef("@AV39PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV103EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV104TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV61MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV60TipCod",GXType.NChar,3,0)
          };
          Object[] prmP009K3;
          prmP009K3 = new Object[] {
          new ParDef("@AV39PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV103EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV104TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV61MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV60TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0)
          };
          Object[] prmP009K5;
          prmP009K5 = new Object[] {
          new ParDef("@AV77FHasta",GXType.Date,8,0) ,
          new ParDef("@AV39PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV103EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV104TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV61MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV60TipCod",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009K2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009K3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009K4", "SELECT T1.[PagReg], T2.[PagFech], T1.[PagDComCod], T1.[PagDTipCod], T2.[PagPrvCod], T2.[PagMonCod], T1.[PagDTot], T2.[PagTipCmb], T1.[PagItem] FROM ([TSPAGOSDET] T1 INNER JOIN [TSPAGOS] T2 ON T2.[PagReg] = T1.[PagReg]) WHERE (T1.[PagDTipCod] = @AV110CPTipCod and T1.[PagDComCod] = @AV107CPComCod) AND (T2.[PagFech] > @AV77FHasta) AND (T2.[PagPrvCod] = @AV105CPPrvCod) ORDER BY T1.[PagDTipCod], T1.[PagDComCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009K4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009K5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009K5,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 15);
                ((string[]) buf[11])[0] = rslt.getString(11, 3);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((int[]) buf[13])[0] = rslt.getInt(13);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                ((string[]) buf[15])[0] = rslt.getString(14, 4);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                ((string[]) buf[17])[0] = rslt.getString(15, 20);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 15);
                ((string[]) buf[12])[0] = rslt.getString(12, 3);
                ((string[]) buf[13])[0] = rslt.getString(13, 1);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(14);
                ((int[]) buf[15])[0] = rslt.getInt(15);
                ((bool[]) buf[16])[0] = rslt.wasNull(15);
                ((string[]) buf[17])[0] = rslt.getString(16, 4);
                ((bool[]) buf[18])[0] = rslt.wasNull(16);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 4);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 20);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
                ((short[]) buf[11])[0] = rslt.getShort(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 15);
                return;
       }
    }

 }

}
