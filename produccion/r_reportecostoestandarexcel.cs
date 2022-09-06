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
   public class r_reportecostoestandarexcel : GXProcedure
   {
      public r_reportecostoestandarexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reportecostoestandarexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProdCod ,
                           ref decimal aP1_TipoCambio ,
                           ref short aP2_MovDolares ,
                           out string aP3_Filename ,
                           out string aP4_ErrorMessage )
      {
         this.AV78ProdCod = aP0_ProdCod;
         this.AV106TipoCambio = aP1_TipoCambio;
         this.AV145MovDolares = aP2_MovDolares;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_ProdCod=this.AV78ProdCod;
         aP1_TipoCambio=this.AV106TipoCambio;
         aP2_MovDolares=this.AV145MovDolares;
         aP3_Filename=this.AV10Filename;
         aP4_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref string aP0_ProdCod ,
                                ref decimal aP1_TipoCambio ,
                                ref short aP2_MovDolares ,
                                out string aP3_Filename )
      {
         execute(ref aP0_ProdCod, ref aP1_TipoCambio, ref aP2_MovDolares, out aP3_Filename, out aP4_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref string aP0_ProdCod ,
                                 ref decimal aP1_TipoCambio ,
                                 ref short aP2_MovDolares ,
                                 out string aP3_Filename ,
                                 out string aP4_ErrorMessage )
      {
         r_reportecostoestandarexcel objr_reportecostoestandarexcel;
         objr_reportecostoestandarexcel = new r_reportecostoestandarexcel();
         objr_reportecostoestandarexcel.AV78ProdCod = aP0_ProdCod;
         objr_reportecostoestandarexcel.AV106TipoCambio = aP1_TipoCambio;
         objr_reportecostoestandarexcel.AV145MovDolares = aP2_MovDolares;
         objr_reportecostoestandarexcel.AV10Filename = "" ;
         objr_reportecostoestandarexcel.AV11ErrorMessage = "" ;
         objr_reportecostoestandarexcel.context.SetSubmitInitialConfig(context);
         objr_reportecostoestandarexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reportecostoestandarexcel);
         aP0_ProdCod=this.AV78ProdCod;
         aP1_TipoCambio=this.AV106TipoCambio;
         aP2_MovDolares=this.AV145MovDolares;
         aP3_Filename=this.AV10Filename;
         aP4_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reportecostoestandarexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasResumenCostoEstandar.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasResumenCostoEstandar.xlsx";
         AV10Filename = "Excel/CostoREAL" + ".xlsx";
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
         AV14CellRow = 6;
         AV15FirstColumn = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV78ProdCod ,
                                              A2382ProGasProdCod } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00FL2 */
         pr_default.execute(0, new Object[] {AV78ProdCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2382ProGasProdCod = P00FL2_A2382ProGasProdCod[0];
            A2398ProGasProdDsc = P00FL2_A2398ProGasProdDsc[0];
            A2395ProGasLoteOpt = P00FL2_A2395ProGasLoteOpt[0];
            A2388ProGasMODUND = P00FL2_A2388ProGasMODUND[0];
            A2389ProGasMODCos = P00FL2_A2389ProGasMODCos[0];
            A2390ProGasMOIUND = P00FL2_A2390ProGasMOIUND[0];
            A2391ProGasMOICos = P00FL2_A2391ProGasMOICos[0];
            A2392ProGasGIFUND = P00FL2_A2392ProGasGIFUND[0];
            A2393ProGASGIFCos = P00FL2_A2393ProGASGIFCos[0];
            A2394ProGasPorcentaje = P00FL2_A2394ProGasPorcentaje[0];
            A2398ProGasProdDsc = P00FL2_A2398ProGasProdDsc[0];
            AV81Codigo = A2382ProGasProdCod;
            AV103Producto = A2398ProGasProdDsc;
            AV99LoteOptimo = ((Convert.ToDecimal(0)==A2395ProGasLoteOpt) ? (decimal)(1) : A2395ProGasLoteOpt);
            AV105Rendimiento = AV99LoteOptimo;
            AV104HorasOptimas = A2388ProGasMODUND;
            AV91ProGasMODUND = A2388ProGasMODUND;
            AV92ProGasMODCos = A2389ProGasMODCos;
            AV93ProGasMOIUND = A2390ProGasMOIUND;
            AV94ProGasMOICos = A2391ProGasMOICos;
            AV95ProGasGIFUND = A2392ProGasGIFUND;
            AV96ProGASGIFCos = A2393ProGASGIFCos;
            AV97ProGasPorcentaje = A2394ProGasPorcentaje;
            AV98Factor = NumberUtil.Round( AV105Rendimiento/ (decimal)(AV99LoteOptimo), 4);
            AV117TotalMateria = 0.00m;
            AV118TCantidad = 0.00m;
            AV119TMateriaP = 0.00m;
            AV120TSubProd = 0.00m;
            AV121TMateria = 0.00m;
            AV122TCostoU = 0.00m;
            AV123TCostoTTMOD = 0.00m;
            AV124Total1 = 0.00m;
            AV125Total2 = 0.00m;
            AV126Total3 = 0.00m;
            AV127Total4 = 0.00m;
            AV128Total5 = 0.00m;
            AV129Total9 = 0.00m;
            AV130Total10 = 0.00m;
            AV131Total11 = 0.00m;
            AV132Total13 = 0.00m;
            AV133Total15 = 0.00m;
            AV134Total18 = 0.00m;
            AV135Total19 = 0.00m;
            AV136Total20 = 0.00m;
            AV137Total21 = 0.00m;
            AV138Total23 = 0.00m;
            AV143TCosUnit = 0.00m;
            AV146Flag = 0;
            if ( AV145MovDolares == 1 )
            {
               AV146Flag = 1;
               /* Execute user subroutine: 'VALIDADOLARES' */
               S151 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( AV146Flag == 0 )
            {
               /* Execute user subroutine: 'GASTOS' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
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
         /* 'GASTOS' Routine */
         returnInSub = false;
         AV115I = 1;
         /* Using cursor P00FL3 */
         pr_default.execute(1, new Object[] {AV81Codigo});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A28ProdCod = P00FL3_A28ProdCod[0];
            A57ProdForProdCod = P00FL3_A57ProdForProdCod[0];
            A1691ProdForProdDsc = P00FL3_A1691ProdForProdDsc[0];
            A1690ProdForCant = P00FL3_A1690ProdForCant[0];
            A1691ProdForProdDsc = P00FL3_A1691ProdForProdDsc[0];
            AV78ProdCod = A57ProdForProdCod;
            AV83ProdDsc = A1691ProdForProdDsc;
            AV107Unidades = (decimal)(A1690ProdForCant*AV105Rendimiento);
            AV53MonAbr = "P";
            AV101CostoTotal = 0.00m;
            AV108CostoTotalSub = 0.00m;
            AV109CostoMOD = ((Convert.ToDecimal(0)==AV91ProGasMODUND) ? (decimal)(0) : AV92ProGasMODCos);
            AV110CostoTMOD = ((Convert.ToDecimal(0)==AV91ProGasMODUND) ? (decimal)(0) : AV91ProGasMODUND*AV109CostoMOD);
            AV111CostoMOI = ((Convert.ToDecimal(0)==AV93ProGasMOIUND) ? (decimal)(0) : AV94ProGasMOICos);
            AV112CostoTMOI = ((Convert.ToDecimal(0)==AV93ProGasMOIUND) ? (decimal)(0) : AV93ProGasMOIUND*AV111CostoMOI);
            AV139Unid = ((Convert.ToDecimal(0)==AV95ProGasGIFUND) ? (decimal)(0) : AV105Rendimiento);
            AV114CostoGF = ((Convert.ToDecimal(0)==AV95ProGasGIFUND) ? (decimal)(0) : AV96ProGASGIFCos);
            AV113CostoTGF = ((Convert.ToDecimal(0)==AV95ProGasGIFUND) ? (decimal)(0) : AV96ProGASGIFCos*AV139Unid);
            if ( ! ( AV115I == 1 ) )
            {
               AV109CostoMOD = 0.00m;
               AV110CostoTMOD = 0.00m;
               AV111CostoMOI = 0.00m;
               AV112CostoTMOI = 0.00m;
               AV114CostoGF = 0.00m;
               AV113CostoTGF = 0.00m;
               AV116CostoUniTMOD = 0.00m;
            }
            /* Execute user subroutine: 'VALIDACOSTO' */
            S133 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV117TotalMateria = (decimal)((AV101CostoTotal+AV108CostoTotalSub));
            AV118TCantidad = (decimal)(AV118TCantidad+AV107Unidades);
            AV119TMateriaP = (decimal)(AV119TMateriaP+AV101CostoTotal);
            AV120TSubProd = (decimal)(AV120TSubProd+AV108CostoTotalSub);
            AV121TMateria = (decimal)(AV121TMateria+AV117TotalMateria);
            AV122TCostoU = (decimal)(AV122TCostoU+(AV117TotalMateria/ (decimal)(AV104HorasOptimas)));
            AV123TCostoTTMOD = (decimal)(AV123TCostoTTMOD+AV110CostoTMOD);
            AV124Total1 = (decimal)(AV124Total1+((AV101CostoTotal+AV108CostoTotalSub+AV110CostoTMOD)));
            AV125Total2 = (decimal)(AV125Total2+AV112CostoTMOI);
            AV126Total3 = (decimal)(AV126Total3+AV113CostoTGF);
            AV127Total4 = (decimal)(AV127Total4+((AV101CostoTotal+AV108CostoTotalSub+AV110CostoTMOD)+AV112CostoTMOI+AV113CostoTGF));
            AV128Total5 = (decimal)(AV128Total5+(((AV101CostoTotal+AV108CostoTotalSub+AV110CostoTMOD)+AV112CostoTMOI+AV113CostoTGF)*AV97ProGasPorcentaje));
            AV129Total9 = (decimal)(AV129Total9+(NumberUtil.Round( AV101CostoTotal/ (decimal)(AV99LoteOptimo), 4)));
            AV130Total10 = (decimal)(AV130Total10+(NumberUtil.Round( AV108CostoTotalSub/ (decimal)(AV99LoteOptimo), 4)));
            AV131Total11 = (decimal)(AV131Total11+(NumberUtil.Round( AV101CostoTotal/ (decimal)(AV99LoteOptimo), 4)+NumberUtil.Round( AV108CostoTotalSub/ (decimal)(AV99LoteOptimo), 4)));
            AV132Total13 = (decimal)(AV132Total13+((AV110CostoTMOD/ (decimal)(AV105Rendimiento))));
            AV133Total15 = (decimal)(AV133Total15+(((AV101CostoTotal+AV108CostoTotalSub+AV110CostoTMOD)/ (decimal)(AV99LoteOptimo))));
            AV134Total18 = (decimal)(AV134Total18+(AV112CostoTMOI/ (decimal)(AV99LoteOptimo)));
            AV135Total19 = (decimal)(AV135Total19+(AV113CostoTGF/ (decimal)(AV99LoteOptimo)));
            AV136Total20 = (decimal)(AV136Total20+(((AV101CostoTotal+AV108CostoTotalSub+AV110CostoTMOD)+AV112CostoTMOI+AV113CostoTGF)));
            AV137Total21 = (decimal)(AV137Total21+(((AV101CostoTotal+AV108CostoTotalSub+AV110CostoTMOD)+AV112CostoTMOI+AV113CostoTGF)/ (decimal)(AV99LoteOptimo)));
            /* Execute user subroutine: 'DETALLE' */
            S143 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV138Total23 = (decimal)(AV138Total23+AV144CostoIncremento);
            AV115I = (int)(AV115I+1);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV81Codigo);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV103Producto);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Number = (double)(AV99LoteOptimo);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV104HorasOptimas);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = "Total Producto";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV118TCantidad);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV119TMateriaP);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV120TSubProd);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV121TMateria);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV129Total9);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV130Total10);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(AV131Total11);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Number = (double)(AV123TCostoTTMOD);
         AV116CostoUniTMOD = (decimal)((AV110CostoTMOD/ (decimal)(AV105Rendimiento)));
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Number = (double)(AV132Total13);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+14, 1, 1).Number = (double)(AV124Total1);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+15, 1, 1).Number = (double)(AV133Total15);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+16, 1, 1).Number = (double)(AV125Total2);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+17, 1, 1).Number = (double)(AV126Total3);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+18, 1, 1).Number = (double)(AV134Total18);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+19, 1, 1).Number = (double)(AV135Total19);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+20, 1, 1).Number = (double)(AV136Total20);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+21, 1, 1).Number = (double)(AV137Total21);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+23, 1, 1).Number = (double)(AV138Total23);
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S143( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV81Codigo);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV103Producto);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Number = (double)(AV99LoteOptimo);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV104HorasOptimas);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV83ProdDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV107Unidades);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV101CostoTotal);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV108CostoTotalSub);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV117TotalMateria);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(NumberUtil.Round( AV101CostoTotal/ (decimal)(AV99LoteOptimo), 4));
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(NumberUtil.Round( AV108CostoTotalSub/ (decimal)(AV99LoteOptimo), 4));
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(NumberUtil.Round( AV101CostoTotal/ (decimal)(AV99LoteOptimo), 4)+NumberUtil.Round( AV108CostoTotalSub/ (decimal)(AV99LoteOptimo), 4));
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Number = (double)(AV110CostoTMOD);
         AV116CostoUniTMOD = (decimal)((AV110CostoTMOD/ (decimal)(AV105Rendimiento)));
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Number = (double)(AV116CostoUniTMOD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+14, 1, 1).Number = (double)((AV101CostoTotal+AV108CostoTotalSub+AV110CostoTMOD));
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+15, 1, 1).Number = (double)((AV101CostoTotal+AV108CostoTotalSub+AV110CostoTMOD)/ (decimal)(AV99LoteOptimo));
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+16, 1, 1).Number = (double)(AV112CostoTMOI);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+17, 1, 1).Number = (double)(AV113CostoTGF);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+18, 1, 1).Number = (double)(AV112CostoTMOI/ (decimal)(AV99LoteOptimo));
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+19, 1, 1).Number = (double)(AV113CostoTGF/ (decimal)(AV99LoteOptimo));
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+20, 1, 1).Number = (double)((AV101CostoTotal+AV108CostoTotalSub+AV110CostoTMOD)+AV112CostoTMOI+AV113CostoTGF);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+21, 1, 1).Number = (double)(((AV101CostoTotal+AV108CostoTotalSub+AV110CostoTMOD)+AV112CostoTMOI+AV113CostoTGF)/ (decimal)(AV99LoteOptimo));
         AV140CostoUnit = (decimal)(((AV101CostoTotal+AV108CostoTotalSub+AV110CostoTMOD)+AV112CostoTMOI+AV113CostoTGF)/ (decimal)(AV99LoteOptimo));
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+22, 1, 1).Number = (double)(AV97ProGasPorcentaje);
         AV141Porcentaje = ((Convert.ToDecimal(0)==AV97ProGasPorcentaje) ? (decimal)(0) : NumberUtil.Round( AV97ProGasPorcentaje/ (decimal)(100), 6));
         AV144CostoIncremento = ((Convert.ToDecimal(0)==AV97ProGasPorcentaje) ? AV140CostoUnit : AV140CostoUnit+NumberUtil.Round( AV140CostoUnit*AV141Porcentaje, 2));
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+23, 1, 1).Number = (double)(AV144CostoIncremento);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+24, 1, 1).Text = StringUtil.Trim( AV53MonAbr);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S133( )
      {
         /* 'VALIDACOSTO' Routine */
         returnInSub = false;
         AV100CostoUnitario = 0.00m;
         AV101CostoTotal = 0.00m;
         /* Using cursor P00FL4 */
         pr_default.execute(2, new Object[] {AV78ProdCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A2385ProCosProdCod = P00FL4_A2385ProCosProdCod[0];
            A2386ProCosMonCod = P00FL4_A2386ProCosMonCod[0];
            A2396ProCosCostoU = P00FL4_A2396ProCosCostoU[0];
            AV61MonCod = A2386ProCosMonCod;
            AV53MonAbr = ((AV61MonCod==2) ? "D" : "P");
            AV100CostoUnitario = NumberUtil.Round( A2396ProCosCostoU*((AV61MonCod==2) ? AV106TipoCambio : (decimal)(1)), 4);
            AV101CostoTotal = NumberUtil.Round( AV107Unidades*AV100CostoUnitario, 4);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         /* Using cursor P00FL5 */
         pr_default.execute(3, new Object[] {AV78ProdCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A2397ProGasSubProducto = P00FL5_A2397ProGasSubProducto[0];
            A2382ProGasProdCod = P00FL5_A2382ProGasProdCod[0];
            A2399ProGasCostoUND = P00FL5_A2399ProGasCostoUND[0];
            AV100CostoUnitario = NumberUtil.Round( A2399ProGasCostoUND, 4);
            AV108CostoTotalSub = NumberUtil.Round( AV107Unidades*AV100CostoUnitario, 4);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         if ( (Convert.ToDecimal(0)==AV100CostoUnitario) )
         {
            /* Using cursor P00FL6 */
            pr_default.execute(4, new Object[] {AV78ProdCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A28ProdCod = P00FL6_A28ProdCod[0];
               A1681ProdCosto = P00FL6_A1681ProdCosto[0];
               A1723ProdVolumen = P00FL6_A1723ProdVolumen[0];
               AV100CostoUnitario = NumberUtil.Round( A1681ProdCosto, 4);
               if ( ! (Convert.ToDecimal(0)==A1723ProdVolumen) )
               {
                  AV100CostoUnitario = NumberUtil.Round( AV100CostoUnitario/ (decimal)(A1723ProdVolumen), 4);
               }
               AV101CostoTotal = NumberUtil.Round( AV107Unidades*AV100CostoUnitario, 4);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
         }
      }

      protected void S151( )
      {
         /* 'VALIDADOLARES' Routine */
         returnInSub = false;
         /* Using cursor P00FL7 */
         pr_default.execute(5, new Object[] {AV81Codigo});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A28ProdCod = P00FL7_A28ProdCod[0];
            A57ProdForProdCod = P00FL7_A57ProdForProdCod[0];
            AV78ProdCod = A57ProdForProdCod;
            /* Execute user subroutine: 'VALIDAMATERIADOLARES' */
            S167 ();
            if ( returnInSub )
            {
               pr_default.close(5);
               returnInSub = true;
               if (true) return;
            }
            if ( AV146Flag == 0 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S167( )
      {
         /* 'VALIDAMATERIADOLARES' Routine */
         returnInSub = false;
         /* Using cursor P00FL8 */
         pr_default.execute(6, new Object[] {AV78ProdCod});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A2385ProCosProdCod = P00FL8_A2385ProCosProdCod[0];
            A2386ProCosMonCod = P00FL8_A2386ProCosMonCod[0];
            AV61MonCod = A2386ProCosMonCod;
            if ( AV61MonCod == 2 )
            {
               AV146Flag = 0;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
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
         A2382ProGasProdCod = "";
         P00FL2_A2382ProGasProdCod = new string[] {""} ;
         P00FL2_A2398ProGasProdDsc = new string[] {""} ;
         P00FL2_A2395ProGasLoteOpt = new decimal[1] ;
         P00FL2_A2388ProGasMODUND = new decimal[1] ;
         P00FL2_A2389ProGasMODCos = new decimal[1] ;
         P00FL2_A2390ProGasMOIUND = new decimal[1] ;
         P00FL2_A2391ProGasMOICos = new decimal[1] ;
         P00FL2_A2392ProGasGIFUND = new decimal[1] ;
         P00FL2_A2393ProGASGIFCos = new decimal[1] ;
         P00FL2_A2394ProGasPorcentaje = new decimal[1] ;
         A2398ProGasProdDsc = "";
         AV81Codigo = "";
         AV103Producto = "";
         P00FL3_A28ProdCod = new string[] {""} ;
         P00FL3_A57ProdForProdCod = new string[] {""} ;
         P00FL3_A1691ProdForProdDsc = new string[] {""} ;
         P00FL3_A1690ProdForCant = new decimal[1] ;
         A28ProdCod = "";
         A57ProdForProdCod = "";
         A1691ProdForProdDsc = "";
         AV83ProdDsc = "";
         AV53MonAbr = "";
         P00FL4_A2385ProCosProdCod = new string[] {""} ;
         P00FL4_A2386ProCosMonCod = new int[1] ;
         P00FL4_A2396ProCosCostoU = new decimal[1] ;
         A2385ProCosProdCod = "";
         P00FL5_A2397ProGasSubProducto = new short[1] ;
         P00FL5_A2382ProGasProdCod = new string[] {""} ;
         P00FL5_A2399ProGasCostoUND = new decimal[1] ;
         P00FL6_A28ProdCod = new string[] {""} ;
         P00FL6_A1681ProdCosto = new decimal[1] ;
         P00FL6_A1723ProdVolumen = new decimal[1] ;
         P00FL7_A28ProdCod = new string[] {""} ;
         P00FL7_A57ProdForProdCod = new string[] {""} ;
         P00FL8_A2385ProCosProdCod = new string[] {""} ;
         P00FL8_A2386ProCosMonCod = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_reportecostoestandarexcel__default(),
            new Object[][] {
                new Object[] {
               P00FL2_A2382ProGasProdCod, P00FL2_A2398ProGasProdDsc, P00FL2_A2395ProGasLoteOpt, P00FL2_A2388ProGasMODUND, P00FL2_A2389ProGasMODCos, P00FL2_A2390ProGasMOIUND, P00FL2_A2391ProGasMOICos, P00FL2_A2392ProGasGIFUND, P00FL2_A2393ProGASGIFCos, P00FL2_A2394ProGasPorcentaje
               }
               , new Object[] {
               P00FL3_A28ProdCod, P00FL3_A57ProdForProdCod, P00FL3_A1691ProdForProdDsc, P00FL3_A1690ProdForCant
               }
               , new Object[] {
               P00FL4_A2385ProCosProdCod, P00FL4_A2386ProCosMonCod, P00FL4_A2396ProCosCostoU
               }
               , new Object[] {
               P00FL5_A2397ProGasSubProducto, P00FL5_A2382ProGasProdCod, P00FL5_A2399ProGasCostoUND
               }
               , new Object[] {
               P00FL6_A28ProdCod, P00FL6_A1681ProdCosto, P00FL6_A1723ProdVolumen
               }
               , new Object[] {
               P00FL7_A28ProdCod, P00FL7_A57ProdForProdCod
               }
               , new Object[] {
               P00FL8_A2385ProCosProdCod, P00FL8_A2386ProCosMonCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV145MovDolares ;
      private short AV146Flag ;
      private short A2397ProGasSubProducto ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV115I ;
      private int A2386ProCosMonCod ;
      private int AV61MonCod ;
      private decimal AV106TipoCambio ;
      private decimal A2395ProGasLoteOpt ;
      private decimal A2388ProGasMODUND ;
      private decimal A2389ProGasMODCos ;
      private decimal A2390ProGasMOIUND ;
      private decimal A2391ProGasMOICos ;
      private decimal A2392ProGasGIFUND ;
      private decimal A2393ProGASGIFCos ;
      private decimal A2394ProGasPorcentaje ;
      private decimal AV99LoteOptimo ;
      private decimal AV105Rendimiento ;
      private decimal AV104HorasOptimas ;
      private decimal AV91ProGasMODUND ;
      private decimal AV92ProGasMODCos ;
      private decimal AV93ProGasMOIUND ;
      private decimal AV94ProGasMOICos ;
      private decimal AV95ProGasGIFUND ;
      private decimal AV96ProGASGIFCos ;
      private decimal AV97ProGasPorcentaje ;
      private decimal AV98Factor ;
      private decimal AV117TotalMateria ;
      private decimal AV118TCantidad ;
      private decimal AV119TMateriaP ;
      private decimal AV120TSubProd ;
      private decimal AV121TMateria ;
      private decimal AV122TCostoU ;
      private decimal AV123TCostoTTMOD ;
      private decimal AV124Total1 ;
      private decimal AV125Total2 ;
      private decimal AV126Total3 ;
      private decimal AV127Total4 ;
      private decimal AV128Total5 ;
      private decimal AV129Total9 ;
      private decimal AV130Total10 ;
      private decimal AV131Total11 ;
      private decimal AV132Total13 ;
      private decimal AV133Total15 ;
      private decimal AV134Total18 ;
      private decimal AV135Total19 ;
      private decimal AV136Total20 ;
      private decimal AV137Total21 ;
      private decimal AV138Total23 ;
      private decimal AV143TCosUnit ;
      private decimal A1690ProdForCant ;
      private decimal AV107Unidades ;
      private decimal AV101CostoTotal ;
      private decimal AV108CostoTotalSub ;
      private decimal AV109CostoMOD ;
      private decimal AV110CostoTMOD ;
      private decimal AV111CostoMOI ;
      private decimal AV112CostoTMOI ;
      private decimal AV139Unid ;
      private decimal AV114CostoGF ;
      private decimal AV113CostoTGF ;
      private decimal AV116CostoUniTMOD ;
      private decimal AV144CostoIncremento ;
      private decimal AV140CostoUnit ;
      private decimal AV141Porcentaje ;
      private decimal AV100CostoUnitario ;
      private decimal A2396ProCosCostoU ;
      private decimal A2399ProGasCostoUND ;
      private decimal A1681ProdCosto ;
      private decimal A1723ProdVolumen ;
      private string AV78ProdCod ;
      private string AV71Path ;
      private string scmdbuf ;
      private string A2382ProGasProdCod ;
      private string A2398ProGasProdDsc ;
      private string AV81Codigo ;
      private string AV103Producto ;
      private string A28ProdCod ;
      private string A57ProdForProdCod ;
      private string A1691ProdForProdDsc ;
      private string AV83ProdDsc ;
      private string AV53MonAbr ;
      private string A2385ProCosProdCod ;
      private bool returnInSub ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProdCod ;
      private decimal aP1_TipoCambio ;
      private short aP2_MovDolares ;
      private IDataStoreProvider pr_default ;
      private string[] P00FL2_A2382ProGasProdCod ;
      private string[] P00FL2_A2398ProGasProdDsc ;
      private decimal[] P00FL2_A2395ProGasLoteOpt ;
      private decimal[] P00FL2_A2388ProGasMODUND ;
      private decimal[] P00FL2_A2389ProGasMODCos ;
      private decimal[] P00FL2_A2390ProGasMOIUND ;
      private decimal[] P00FL2_A2391ProGasMOICos ;
      private decimal[] P00FL2_A2392ProGasGIFUND ;
      private decimal[] P00FL2_A2393ProGASGIFCos ;
      private decimal[] P00FL2_A2394ProGasPorcentaje ;
      private string[] P00FL3_A28ProdCod ;
      private string[] P00FL3_A57ProdForProdCod ;
      private string[] P00FL3_A1691ProdForProdDsc ;
      private decimal[] P00FL3_A1690ProdForCant ;
      private string[] P00FL4_A2385ProCosProdCod ;
      private int[] P00FL4_A2386ProCosMonCod ;
      private decimal[] P00FL4_A2396ProCosCostoU ;
      private short[] P00FL5_A2397ProGasSubProducto ;
      private string[] P00FL5_A2382ProGasProdCod ;
      private decimal[] P00FL5_A2399ProGasCostoUND ;
      private string[] P00FL6_A28ProdCod ;
      private decimal[] P00FL6_A1681ProdCosto ;
      private decimal[] P00FL6_A1723ProdVolumen ;
      private string[] P00FL7_A28ProdCod ;
      private string[] P00FL7_A57ProdForProdCod ;
      private string[] P00FL8_A2385ProCosProdCod ;
      private int[] P00FL8_A2386ProCosMonCod ;
      private string aP3_Filename ;
      private string aP4_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class r_reportecostoestandarexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FL2( IGxContext context ,
                                             string AV78ProdCod ,
                                             string A2382ProGasProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ProGasProdCod] AS ProGasProdCod, T2.[ProdDsc] AS ProGasProdDsc, T1.[ProGasLoteOpt], T1.[ProGasMODUND], T1.[ProGasMODCos], T1.[ProGasMOIUND], T1.[ProGasMOICos], T1.[ProGasGIFUND], T1.[ProGASGIFCos], T1.[ProGasPorcentaje] FROM ([PROCOSTOGASTOS] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProGasProdCod])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProGasProdCod] = @AV78ProdCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProGasProdCod]";
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
               case 0 :
                     return conditional_P00FL2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FL3;
          prmP00FL3 = new Object[] {
          new ParDef("@AV81Codigo",GXType.NChar,15,0)
          };
          Object[] prmP00FL4;
          prmP00FL4 = new Object[] {
          new ParDef("@AV78ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00FL5;
          prmP00FL5 = new Object[] {
          new ParDef("@AV78ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00FL6;
          prmP00FL6 = new Object[] {
          new ParDef("@AV78ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00FL7;
          prmP00FL7 = new Object[] {
          new ParDef("@AV81Codigo",GXType.NChar,15,0)
          };
          Object[] prmP00FL8;
          prmP00FL8 = new Object[] {
          new ParDef("@AV78ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00FL2;
          prmP00FL2 = new Object[] {
          new ParDef("@AV78ProdCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FL2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FL2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FL3", "SELECT T1.[ProdCod], T1.[ProdForProdCod] AS ProdForProdCod, T2.[ProdDsc] AS ProdForProdDsc, T1.[ProdForCant] FROM ([APRODUCTOSFORMULA] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdForProdCod]) WHERE T1.[ProdCod] = @AV81Codigo ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FL3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FL4", "SELECT [ProCosProdCod], [ProCosMonCod], [ProCosCostoU] FROM [PROCOSTOMATERIAS] WHERE [ProCosProdCod] = @AV78ProdCod ORDER BY [ProCosProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FL4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FL5", "SELECT [ProGasSubProducto], [ProGasProdCod] AS ProGasProdCod, [ProGasCostoUND] FROM [PROCOSTOGASTOS] WHERE ([ProGasProdCod] = @AV78ProdCod) AND ([ProGasSubProducto] = 1) ORDER BY [ProGasProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FL5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FL6", "SELECT [ProdCod], [ProdCosto], [ProdVolumen] FROM [APRODUCTOS] WHERE [ProdCod] = @AV78ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FL6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FL7", "SELECT [ProdCod], [ProdForProdCod] AS ProdForProdCod FROM [APRODUCTOSFORMULA] WHERE [ProdCod] = @AV81Codigo ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FL7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FL8", "SELECT [ProCosProdCod], [ProCosMonCod] FROM [PROCOSTOMATERIAS] WHERE [ProCosProdCod] = @AV78ProdCod ORDER BY [ProCosProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FL8,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
