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
   public class r_resumencomparativocomprasexcel : GXProcedure
   {
      public r_resumencomparativocomprasexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumencomparativocomprasexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SubLCod ,
                           ref string aP2_ProdCod ,
                           ref DateTime aP3_DDesde ,
                           ref DateTime aP4_DHasta ,
                           ref short aP5_Ref2 ,
                           ref string aP6_nReporte ,
                           out string aP7_Filename ,
                           out string aP8_ErrorMessage )
      {
         this.AV30LinCod = aP0_LinCod;
         this.AV31SubLCod = aP1_SubLCod;
         this.AV21ProdCod = aP2_ProdCod;
         this.AV19DDesde = aP3_DDesde;
         this.AV20DHasta = aP4_DHasta;
         this.AV41Ref2 = aP5_Ref2;
         this.AV53nReporte = aP6_nReporte;
         this.AV35Filename = "" ;
         this.AV39ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV30LinCod;
         aP1_SubLCod=this.AV31SubLCod;
         aP2_ProdCod=this.AV21ProdCod;
         aP3_DDesde=this.AV19DDesde;
         aP4_DHasta=this.AV20DHasta;
         aP5_Ref2=this.AV41Ref2;
         aP6_nReporte=this.AV53nReporte;
         aP7_Filename=this.AV35Filename;
         aP8_ErrorMessage=this.AV39ErrorMessage;
      }

      public string executeUdp( ref int aP0_LinCod ,
                                ref int aP1_SubLCod ,
                                ref string aP2_ProdCod ,
                                ref DateTime aP3_DDesde ,
                                ref DateTime aP4_DHasta ,
                                ref short aP5_Ref2 ,
                                ref string aP6_nReporte ,
                                out string aP7_Filename )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_ProdCod, ref aP3_DDesde, ref aP4_DHasta, ref aP5_Ref2, ref aP6_nReporte, out aP7_Filename, out aP8_ErrorMessage);
         return AV39ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref string aP2_ProdCod ,
                                 ref DateTime aP3_DDesde ,
                                 ref DateTime aP4_DHasta ,
                                 ref short aP5_Ref2 ,
                                 ref string aP6_nReporte ,
                                 out string aP7_Filename ,
                                 out string aP8_ErrorMessage )
      {
         r_resumencomparativocomprasexcel objr_resumencomparativocomprasexcel;
         objr_resumencomparativocomprasexcel = new r_resumencomparativocomprasexcel();
         objr_resumencomparativocomprasexcel.AV30LinCod = aP0_LinCod;
         objr_resumencomparativocomprasexcel.AV31SubLCod = aP1_SubLCod;
         objr_resumencomparativocomprasexcel.AV21ProdCod = aP2_ProdCod;
         objr_resumencomparativocomprasexcel.AV19DDesde = aP3_DDesde;
         objr_resumencomparativocomprasexcel.AV20DHasta = aP4_DHasta;
         objr_resumencomparativocomprasexcel.AV41Ref2 = aP5_Ref2;
         objr_resumencomparativocomprasexcel.AV53nReporte = aP6_nReporte;
         objr_resumencomparativocomprasexcel.AV35Filename = "" ;
         objr_resumencomparativocomprasexcel.AV39ErrorMessage = "" ;
         objr_resumencomparativocomprasexcel.context.SetSubmitInitialConfig(context);
         objr_resumencomparativocomprasexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumencomparativocomprasexcel);
         aP0_LinCod=this.AV30LinCod;
         aP1_SubLCod=this.AV31SubLCod;
         aP2_ProdCod=this.AV21ProdCod;
         aP3_DDesde=this.AV19DDesde;
         aP4_DHasta=this.AV20DHasta;
         aP5_Ref2=this.AV41Ref2;
         aP6_nReporte=this.AV53nReporte;
         aP7_Filename=this.AV35Filename;
         aP8_ErrorMessage=this.AV39ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumencomparativocomprasexcel)stateInfo).executePrivate();
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
         AV32Archivo.Source = "Excel/PlantillasComparativoCompras.xlsx";
         AV33Path = AV32Archivo.GetPath();
         AV34FilenameOrigen = StringUtil.Trim( AV33Path) + "\\PlantillasComparativoCompras.xlsx";
         AV35Filename = "Excel/ReporteComprasAlmacen" + ".xlsx";
         AV36ExcelDocument.Clear();
         AV36ExcelDocument.Template = AV34FilenameOrigen;
         AV36ExcelDocument.Open(AV35Filename);
         /* Optimized DELETE. */
         /* Using cursor P00DA2 */
         pr_default.execute(0);
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("CPALMACENVSCONTA");
         /* End optimized DELETE. */
         context.CommitDataStores("compras.r_resumencomparativocomprasexcel",pr_default);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S181 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV8Ano = (short)(DateTimeUtil.Year( AV19DDesde));
         AV9Mes = (short)(DateTimeUtil.Month( AV19DDesde));
         AV37CellRow = 5;
         AV38FirstColumn = 1;
         if ( StringUtil.StrCmp(AV53nReporte, "I") == 0 )
         {
            AV36ExcelDocument.get_Cells(2, 1, 1, 1).Text = "REPORTE DE CONCILIACION ALMACEN VS CONTABILIDAD - INGRESOS";
            /* Execute user subroutine: 'INGRESOS' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else
         {
            AV36ExcelDocument.get_Cells(2, 1, 1, 1).Text = "REPORTE DE CONCILIACION ALMACEN VS CONTABILIDAD - SALIDAS";
            AV36ExcelDocument.get_Cells(3, 2, 1, 1).Text = "N° SALIDA";
            /* Execute user subroutine: 'SALIDAS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV36ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S181 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV36ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'INGRESOS' Routine */
         returnInSub = false;
         AV50i = 1;
         /* Using cursor P00DA3 */
         pr_default.execute(1, new Object[] {AV8Ano, AV9Mes});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A91CueCod = P00DA3_A91CueCod[0];
            A126TASICod = P00DA3_A126TASICod[0];
            A2077VouSts = P00DA3_A2077VouSts[0];
            A128VouMes = P00DA3_A128VouMes[0];
            A127VouAno = P00DA3_A127VouAno[0];
            A135VouDFec = P00DA3_A135VouDFec[0];
            A132VouDTipCod = P00DA3_A132VouDTipCod[0];
            A2053VouDDoc = P00DA3_A2053VouDDoc[0];
            A2054VouDGls = P00DA3_A2054VouDGls[0];
            A2058VouDProdCod = P00DA3_A2058VouDProdCod[0];
            A129VouNum = P00DA3_A129VouNum[0];
            A2057VouDordCod = P00DA3_A2057VouDordCod[0];
            A2050VouDCant = P00DA3_A2050VouDCant[0];
            A2055VouDHab = P00DA3_A2055VouDHab[0];
            A2051VouDDeb = P00DA3_A2051VouDDeb[0];
            A2056VouDHabO = P00DA3_A2056VouDHabO[0];
            A2052VouDDebO = P00DA3_A2052VouDDebO[0];
            A130VouDSec = P00DA3_A130VouDSec[0];
            A2077VouSts = P00DA3_A2077VouSts[0];
            AV12MVAFec = A135VouDFec;
            AV43TipCod = A132VouDTipCod;
            AV42ComCod = A2053VouDDoc;
            AV44Glosa = A2054VouDGls;
            AV46ComDTot = 0.00m;
            AV21ProdCod = A2058VouDProdCod;
            AV29ProdDsc = "Asiento : " + StringUtil.Trim( A129VouNum);
            AV47OrdCod = A2057VouDordCod;
            AV13MVADCant = 0.0000m;
            AV14MVADCosto = 0.00m;
            AV45ComDCant = A2050VouDCant;
            AV46ComDTot = (decimal)(A2051VouDDeb-A2055VouDHab);
            AV57Dif = (decimal)(A2052VouDDebO-A2056VouDHabO);
            AV58Total = ((AV57Dif<Convert.ToDecimal(0)) ? AV57Dif*-1 : AV57Dif);
            AV54MovDsc = "";
            AV52Flag = 0;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TipCod)) )
            {
               /* Execute user subroutine: 'VALIDACOMPRAS' */
               S123 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
            }
            new pgrabaalmacenvscontabilidad(context ).execute( ref  AV50i, ref  AV12MVAFec, ref  AV47OrdCod, ref  AV11MVACod, ref  AV21ProdCod, ref  AV29ProdDsc, ref  AV43TipCod, ref  AV42ComCod, ref  AV13MVADCant, ref  AV14MVADCosto, ref  AV45ComDCant, ref  AV46ComDTot, ref  AV54MovDsc, ref  AV52Flag) ;
            AV50i = (long)(AV50i+1);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00DA4 */
         pr_default.execute(2, new Object[] {AV19DDesde, AV20DHasta});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A22MvAMov = P00DA4_A22MvAMov[0];
            A21MvAlm = P00DA4_A21MvAlm[0];
            A52LinCod = P00DA4_A52LinCod[0];
            A1158LinStk = P00DA4_A1158LinStk[0];
            A1269MvAlmCos = P00DA4_A1269MvAlmCos[0];
            A13MvATip = P00DA4_A13MvATip[0];
            A1370MVSts = P00DA4_A1370MVSts[0];
            A25MvAFec = P00DA4_A25MvAFec[0];
            A1276MvAOcom = P00DA4_A1276MvAOcom[0];
            A14MvACod = P00DA4_A14MvACod[0];
            A28ProdCod = P00DA4_A28ProdCod[0];
            A55ProdDsc = P00DA4_A55ProdDsc[0];
            A1248MvADCant = P00DA4_A1248MvADCant[0];
            A1249MVADCosto = P00DA4_A1249MVADCosto[0];
            A1271MvAlmDsc = P00DA4_A1271MvAlmDsc[0];
            A1274MvAMovDsc = P00DA4_A1274MvAMovDsc[0];
            A30MvADItem = P00DA4_A30MvADItem[0];
            A22MvAMov = P00DA4_A22MvAMov[0];
            A21MvAlm = P00DA4_A21MvAlm[0];
            A1370MVSts = P00DA4_A1370MVSts[0];
            A25MvAFec = P00DA4_A25MvAFec[0];
            A1276MvAOcom = P00DA4_A1276MvAOcom[0];
            A1274MvAMovDsc = P00DA4_A1274MvAMovDsc[0];
            A1269MvAlmCos = P00DA4_A1269MvAlmCos[0];
            A1271MvAlmDsc = P00DA4_A1271MvAlmDsc[0];
            A52LinCod = P00DA4_A52LinCod[0];
            A55ProdDsc = P00DA4_A55ProdDsc[0];
            A1158LinStk = P00DA4_A1158LinStk[0];
            AV47OrdCod = A1276MvAOcom;
            AV11MVACod = A14MvACod;
            AV12MVAFec = A25MvAFec;
            AV21ProdCod = A28ProdCod;
            AV29ProdDsc = A55ProdDsc;
            AV43TipCod = "";
            AV42ComCod = "";
            AV13MVADCant = A1248MvADCant;
            AV14MVADCosto = A1249MVADCosto;
            AV45ComDCant = 0.0000m;
            AV46ComDTot = 0.00m;
            AV51MVAlmDsc = A1271MvAlmDsc;
            AV54MovDsc = A1274MvAMovDsc;
            /* Execute user subroutine: 'VALIDAMASINGRESOS' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            if ( AV52Flag == 0 )
            {
               new pmodificaalmacenvscontabilidad(context ).execute( ref  AV50i, ref  AV12MVAFec, ref  AV47OrdCod, ref  AV11MVACod, ref  AV21ProdCod, ref  AV29ProdDsc, ref  AV43TipCod, ref  AV42ComCod, ref  AV13MVADCant, ref  AV14MVADCosto, ref  AV45ComDCant, ref  AV46ComDTot, ref  AV54MovDsc, ref  AV52Flag) ;
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor P00DA5 */
         pr_default.execute(3, new Object[] {AV19DDesde, AV20DHasta});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A22MvAMov = P00DA5_A22MvAMov[0];
            A21MvAlm = P00DA5_A21MvAlm[0];
            A52LinCod = P00DA5_A52LinCod[0];
            A1158LinStk = P00DA5_A1158LinStk[0];
            A1269MvAlmCos = P00DA5_A1269MvAlmCos[0];
            A13MvATip = P00DA5_A13MvATip[0];
            A1370MVSts = P00DA5_A1370MVSts[0];
            A25MvAFec = P00DA5_A25MvAFec[0];
            A1276MvAOcom = P00DA5_A1276MvAOcom[0];
            A14MvACod = P00DA5_A14MvACod[0];
            A28ProdCod = P00DA5_A28ProdCod[0];
            A55ProdDsc = P00DA5_A55ProdDsc[0];
            A1248MvADCant = P00DA5_A1248MvADCant[0];
            A1249MVADCosto = P00DA5_A1249MVADCosto[0];
            A1271MvAlmDsc = P00DA5_A1271MvAlmDsc[0];
            A1274MvAMovDsc = P00DA5_A1274MvAMovDsc[0];
            A30MvADItem = P00DA5_A30MvADItem[0];
            A22MvAMov = P00DA5_A22MvAMov[0];
            A21MvAlm = P00DA5_A21MvAlm[0];
            A1370MVSts = P00DA5_A1370MVSts[0];
            A25MvAFec = P00DA5_A25MvAFec[0];
            A1276MvAOcom = P00DA5_A1276MvAOcom[0];
            A1274MvAMovDsc = P00DA5_A1274MvAMovDsc[0];
            A1269MvAlmCos = P00DA5_A1269MvAlmCos[0];
            A1271MvAlmDsc = P00DA5_A1271MvAlmDsc[0];
            A52LinCod = P00DA5_A52LinCod[0];
            A55ProdDsc = P00DA5_A55ProdDsc[0];
            A1158LinStk = P00DA5_A1158LinStk[0];
            AV47OrdCod = A1276MvAOcom;
            AV11MVACod = A14MvACod;
            AV12MVAFec = A25MvAFec;
            AV21ProdCod = A28ProdCod;
            AV29ProdDsc = A55ProdDsc;
            AV43TipCod = "";
            AV42ComCod = "";
            AV13MVADCant = A1248MvADCant;
            AV14MVADCosto = A1249MVADCosto;
            AV45ComDCant = 0.0000m;
            AV46ComDTot = 0.00m;
            AV51MVAlmDsc = A1271MvAlmDsc;
            AV54MovDsc = A1274MvAMovDsc;
            /* Execute user subroutine: 'VALIDAMASINGRESOS' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            if ( AV52Flag == 1 )
            {
               new pgrabaalmacenvscontabilidad(context ).execute( ref  AV50i, ref  AV12MVAFec, ref  AV47OrdCod, ref  AV11MVACod, ref  AV21ProdCod, ref  AV29ProdDsc, ref  AV43TipCod, ref  AV42ComCod, ref  AV13MVADCant, ref  AV14MVADCosto, ref  AV45ComDCant, ref  AV46ComDTot, ref  AV54MovDsc, ref  AV52Flag) ;
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Using cursor P00DA6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A2087VSFecha = P00DA6_A2087VSFecha[0];
            A2092VSTipCod = P00DA6_A2092VSTipCod[0];
            A2086VSDocNum = P00DA6_A2086VSDocNum[0];
            A2084VSCostoFac = P00DA6_A2084VSCostoFac[0];
            A2091VSProdDsc = P00DA6_A2091VSProdDsc[0];
            A2083VSCantIng = P00DA6_A2083VSCantIng[0];
            A2085VSCostoIng = P00DA6_A2085VSCostoIng[0];
            A2082VSCantFac = P00DA6_A2082VSCantFac[0];
            A2093VSTipMov = P00DA6_A2093VSTipMov[0];
            A2090VSProdCod = P00DA6_A2090VSProdCod[0];
            A2088VSMVACod = P00DA6_A2088VSMVACod[0];
            A2089VSOrdCod = P00DA6_A2089VSOrdCod[0];
            A237VSItem = P00DA6_A237VSItem[0];
            AV11MVACod = A2088VSMVACod;
            AV12MVAFec = A2087VSFecha;
            AV43TipCod = A2092VSTipCod;
            AV42ComCod = A2086VSDocNum;
            AV46ComDTot = A2084VSCostoFac;
            AV21ProdCod = A2090VSProdCod;
            AV29ProdDsc = A2091VSProdDsc;
            AV47OrdCod = A2089VSOrdCod;
            AV13MVADCant = A2083VSCantIng;
            AV14MVADCosto = A2085VSCostoIng;
            AV45ComDCant = A2082VSCantFac;
            AV46ComDTot = A2084VSCostoFac;
            AV17DifCant = (decimal)(AV13MVADCant-AV45ComDCant);
            AV18DifCosto = (decimal)(AV14MVADCosto-AV46ComDTot);
            AV54MovDsc = A2093VSTipMov;
            if ( ( AV41Ref2 == 1 ) && ( ( AV17DifCant != Convert.ToDecimal( 0 )) || ( AV18DifCosto != Convert.ToDecimal( 0 )) ) )
            {
               /* Execute user subroutine: 'PRINT' */
               S146 ();
               if ( returnInSub )
               {
                  pr_default.close(4);
                  returnInSub = true;
                  if (true) return;
               }
            }
            if ( ( AV41Ref2 == 2 ) && ( AV17DifCant == Convert.ToDecimal( 0 )) && ( AV18DifCosto != Convert.ToDecimal( 0 )) )
            {
               /* Execute user subroutine: 'PRINT' */
               S146 ();
               if ( returnInSub )
               {
                  pr_default.close(4);
                  returnInSub = true;
                  if (true) return;
               }
            }
            if ( AV41Ref2 == 3 )
            {
               /* Execute user subroutine: 'PRINT' */
               S146 ();
               if ( returnInSub )
               {
                  pr_default.close(4);
                  returnInSub = true;
                  if (true) return;
               }
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S151( )
      {
         /* 'SALIDAS' Routine */
         returnInSub = false;
         /* Using cursor P00DA7 */
         pr_default.execute(5, new Object[] {AV19DDesde, AV20DHasta});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A22MvAMov = P00DA7_A22MvAMov[0];
            A21MvAlm = P00DA7_A21MvAlm[0];
            A52LinCod = P00DA7_A52LinCod[0];
            A1158LinStk = P00DA7_A1158LinStk[0];
            A1269MvAlmCos = P00DA7_A1269MvAlmCos[0];
            A13MvATip = P00DA7_A13MvATip[0];
            A1370MVSts = P00DA7_A1370MVSts[0];
            A25MvAFec = P00DA7_A25MvAFec[0];
            A1276MvAOcom = P00DA7_A1276MvAOcom[0];
            A14MvACod = P00DA7_A14MvACod[0];
            A28ProdCod = P00DA7_A28ProdCod[0];
            A55ProdDsc = P00DA7_A55ProdDsc[0];
            A1248MvADCant = P00DA7_A1248MvADCant[0];
            A1249MVADCosto = P00DA7_A1249MVADCosto[0];
            A1271MvAlmDsc = P00DA7_A1271MvAlmDsc[0];
            A1274MvAMovDsc = P00DA7_A1274MvAMovDsc[0];
            A30MvADItem = P00DA7_A30MvADItem[0];
            A22MvAMov = P00DA7_A22MvAMov[0];
            A21MvAlm = P00DA7_A21MvAlm[0];
            A1370MVSts = P00DA7_A1370MVSts[0];
            A25MvAFec = P00DA7_A25MvAFec[0];
            A1276MvAOcom = P00DA7_A1276MvAOcom[0];
            A1274MvAMovDsc = P00DA7_A1274MvAMovDsc[0];
            A1269MvAlmCos = P00DA7_A1269MvAlmCos[0];
            A1271MvAlmDsc = P00DA7_A1271MvAlmDsc[0];
            A52LinCod = P00DA7_A52LinCod[0];
            A55ProdDsc = P00DA7_A55ProdDsc[0];
            A1158LinStk = P00DA7_A1158LinStk[0];
            AV47OrdCod = A1276MvAOcom;
            AV11MVACod = A14MvACod;
            AV12MVAFec = A25MvAFec;
            AV21ProdCod = A28ProdCod;
            AV29ProdDsc = A55ProdDsc;
            AV43TipCod = "";
            AV42ComCod = "";
            AV13MVADCant = A1248MvADCant;
            AV14MVADCosto = A1249MVADCosto;
            AV45ComDCant = 0.0000m;
            AV46ComDTot = 0.00m;
            AV51MVAlmDsc = A1271MvAlmDsc;
            AV54MovDsc = A1274MvAMovDsc;
            /* Execute user subroutine: 'VALIDASALIDAS' */
            S167 ();
            if ( returnInSub )
            {
               pr_default.close(5);
               returnInSub = true;
               if (true) return;
            }
            if ( AV52Flag == 1 )
            {
               AV45ComDCant = AV13MVADCant;
               AV46ComDTot = AV14MVADCosto;
            }
            AV48SdtConsistenciaDet.gxTpr_Mvafec = AV12MVAFec;
            AV48SdtConsistenciaDet.gxTpr_Ordcod = AV47OrdCod;
            AV48SdtConsistenciaDet.gxTpr_Tipcod = AV43TipCod;
            AV48SdtConsistenciaDet.gxTpr_Mvacod = AV11MVACod;
            AV48SdtConsistenciaDet.gxTpr_Prodcod = AV21ProdCod;
            AV48SdtConsistenciaDet.gxTpr_Proddsc = AV29ProdDsc;
            AV48SdtConsistenciaDet.gxTpr_Comcod = AV42ComCod;
            AV48SdtConsistenciaDet.gxTpr_Comdcant = AV45ComDCant;
            AV48SdtConsistenciaDet.gxTpr_Comdtot = AV46ComDTot;
            AV48SdtConsistenciaDet.gxTpr_Mvadcant = AV13MVADCant;
            AV48SdtConsistenciaDet.gxTpr_Mvadcosto = AV14MVADCosto;
            AV48SdtConsistenciaDet.gxTpr_Movdsc = AV54MovDsc;
            AV49SdtConsistencia.Add(AV48SdtConsistenciaDet, 0);
            AV48SdtConsistenciaDet = new SdtSdtConsistencia_SdtCuentaItem(context);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Using cursor P00DA8 */
         pr_default.execute(6, new Object[] {AV8Ano, AV9Mes});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A91CueCod = P00DA8_A91CueCod[0];
            A126TASICod = P00DA8_A126TASICod[0];
            A128VouMes = P00DA8_A128VouMes[0];
            A127VouAno = P00DA8_A127VouAno[0];
            A2053VouDDoc = P00DA8_A2053VouDDoc[0];
            A135VouDFec = P00DA8_A135VouDFec[0];
            A2058VouDProdCod = P00DA8_A2058VouDProdCod[0];
            A2054VouDGls = P00DA8_A2054VouDGls[0];
            A2055VouDHab = P00DA8_A2055VouDHab[0];
            A2051VouDDeb = P00DA8_A2051VouDDeb[0];
            A129VouNum = P00DA8_A129VouNum[0];
            A130VouDSec = P00DA8_A130VouDSec[0];
            AV47OrdCod = "";
            AV11MVACod = A2053VouDDoc;
            AV12MVAFec = A135VouDFec;
            AV21ProdCod = "";
            AV55Codigo = A2058VouDProdCod;
            AV29ProdDsc = A2054VouDGls;
            AV43TipCod = "";
            AV42ComCod = "";
            AV13MVADCant = 0.00m;
            AV14MVADCosto = 0.00m;
            AV45ComDCant = 0.0000m;
            AV46ComDTot = (decimal)(A2051VouDDeb-A2055VouDHab);
            AV46ComDTot = ((AV46ComDTot<Convert.ToDecimal(0)) ? AV46ComDTot*-1 : AV46ComDTot);
            AV51MVAlmDsc = "";
            AV54MovDsc = "";
            AV52Flag = 0;
            /* Execute user subroutine: 'VALIDASALIDASCONTABILIDAD' */
            S178 ();
            if ( returnInSub )
            {
               pr_default.close(6);
               returnInSub = true;
               if (true) return;
            }
            if ( AV52Flag == 0 )
            {
               AV48SdtConsistenciaDet.gxTpr_Mvafec = AV12MVAFec;
               AV48SdtConsistenciaDet.gxTpr_Ordcod = AV47OrdCod;
               AV48SdtConsistenciaDet.gxTpr_Tipcod = AV43TipCod;
               AV48SdtConsistenciaDet.gxTpr_Mvacod = AV11MVACod;
               AV48SdtConsistenciaDet.gxTpr_Prodcod = AV21ProdCod;
               AV48SdtConsistenciaDet.gxTpr_Proddsc = AV29ProdDsc;
               AV48SdtConsistenciaDet.gxTpr_Comcod = AV42ComCod;
               AV48SdtConsistenciaDet.gxTpr_Comdcant = AV45ComDCant;
               AV48SdtConsistenciaDet.gxTpr_Comdtot = AV46ComDTot;
               AV48SdtConsistenciaDet.gxTpr_Mvadcant = AV13MVADCant;
               AV48SdtConsistenciaDet.gxTpr_Mvadcosto = AV14MVADCosto;
               AV48SdtConsistenciaDet.gxTpr_Movdsc = AV54MovDsc;
               AV49SdtConsistencia.Add(AV48SdtConsistenciaDet, 0);
               AV48SdtConsistenciaDet = new SdtSdtConsistencia_SdtCuentaItem(context);
            }
            pr_default.readNext(6);
         }
         pr_default.close(6);
         AV49SdtConsistencia.Sort("OrdCod,MVACod,ProdCod");
         AV68GXV1 = 1;
         while ( AV68GXV1 <= AV49SdtConsistencia.Count )
         {
            AV48SdtConsistenciaDet = ((SdtSdtConsistencia_SdtCuentaItem)AV49SdtConsistencia.Item(AV68GXV1));
            AV11MVACod = AV48SdtConsistenciaDet.gxTpr_Mvacod;
            AV12MVAFec = AV48SdtConsistenciaDet.gxTpr_Mvafec;
            AV43TipCod = AV48SdtConsistenciaDet.gxTpr_Tipcod;
            AV42ComCod = AV48SdtConsistenciaDet.gxTpr_Comcod;
            AV46ComDTot = AV48SdtConsistenciaDet.gxTpr_Comdtot;
            AV21ProdCod = AV48SdtConsistenciaDet.gxTpr_Prodcod;
            AV29ProdDsc = AV48SdtConsistenciaDet.gxTpr_Proddsc;
            AV47OrdCod = AV48SdtConsistenciaDet.gxTpr_Ordcod;
            AV13MVADCant = AV48SdtConsistenciaDet.gxTpr_Mvadcant;
            AV14MVADCosto = AV48SdtConsistenciaDet.gxTpr_Mvadcosto;
            AV45ComDCant = AV48SdtConsistenciaDet.gxTpr_Comdcant;
            AV46ComDTot = AV48SdtConsistenciaDet.gxTpr_Comdtot;
            AV17DifCant = (decimal)(AV13MVADCant-AV45ComDCant);
            AV18DifCosto = (decimal)(AV14MVADCosto-AV46ComDTot);
            AV54MovDsc = AV48SdtConsistenciaDet.gxTpr_Movdsc;
            if ( ( AV41Ref2 == 1 ) && ( ( AV17DifCant != Convert.ToDecimal( 0 )) || ( AV18DifCosto != Convert.ToDecimal( 0 )) ) )
            {
               /* Execute user subroutine: 'PRINT' */
               S146 ();
               if (returnInSub) return;
            }
            if ( ( AV41Ref2 == 2 ) && ( AV17DifCant == Convert.ToDecimal( 0 )) && ( AV18DifCosto != Convert.ToDecimal( 0 )) )
            {
               /* Execute user subroutine: 'PRINT' */
               S146 ();
               if (returnInSub) return;
            }
            if ( AV41Ref2 == 3 )
            {
               /* Execute user subroutine: 'PRINT' */
               S146 ();
               if (returnInSub) return;
            }
            AV68GXV1 = (int)(AV68GXV1+1);
         }
      }

      protected void S123( )
      {
         /* 'VALIDACOMPRAS' Routine */
         returnInSub = false;
         /* Using cursor P00DA9 */
         pr_default.execute(7, new Object[] {AV21ProdCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A28ProdCod = P00DA9_A28ProdCod[0];
            A55ProdDsc = P00DA9_A55ProdDsc[0];
            AV29ProdDsc = A55ProdDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(7);
      }

      protected void S181( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV36ExcelDocument.ErrCode != 0 )
         {
            AV35Filename = "";
            AV39ErrorMessage = AV36ExcelDocument.ErrDescription;
            AV36ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S146( )
      {
         /* 'PRINT' Routine */
         returnInSub = false;
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+0), 1, 1).Text = AV47OrdCod;
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV11MVACod);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV12MVAFec ) ;
         AV36ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+2), 1, 1).Date = GXt_dtime1;
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+3), 1, 1).Text = StringUtil.Trim( AV21ProdCod);
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+4), 1, 1).Text = StringUtil.Trim( AV29ProdDsc);
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+5), 1, 1).Text = StringUtil.Trim( AV43TipCod);
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+6), 1, 1).Text = StringUtil.Trim( AV42ComCod);
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+7), 1, 1).Number = (double)(AV13MVADCant);
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+8), 1, 1).Number = (double)(AV14MVADCosto);
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+9), 1, 1).Number = (double)(AV45ComDCant);
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+10), 1, 1).Number = (double)(AV46ComDTot);
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+11), 1, 1).Number = (double)(AV17DifCant);
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+12), 1, 1).Number = (double)(AV18DifCosto);
         AV36ExcelDocument.get_Cells((int)(AV37CellRow), (int)(AV38FirstColumn+13), 1, 1).Text = StringUtil.Trim( AV54MovDsc);
         AV37CellRow = (long)(AV37CellRow+1);
      }

      protected void S134( )
      {
         /* 'VALIDAMASINGRESOS' Routine */
         returnInSub = false;
         AV52Flag = 0;
         AV56ii = 0;
         /* Optimized group. */
         /* Using cursor P00DA10 */
         pr_default.execute(8, new Object[] {AV19DDesde, AV20DHasta, AV47OrdCod, AV21ProdCod});
         cV56ii = P00DA10_AV56ii[0];
         pr_default.close(8);
         AV56ii = (int)(AV56ii+cV56ii*1);
         /* End optimized group. */
         if ( AV56ii > 1 )
         {
            AV52Flag = 1;
         }
      }

      protected void S167( )
      {
         /* 'VALIDASALIDAS' Routine */
         returnInSub = false;
         AV52Flag = 0;
         /* Using cursor P00DA11 */
         pr_default.execute(9, new Object[] {AV8Ano, AV9Mes, AV11MVACod, AV29ProdDsc});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A2054VouDGls = P00DA11_A2054VouDGls[0];
            A2053VouDDoc = P00DA11_A2053VouDDoc[0];
            A91CueCod = P00DA11_A91CueCod[0];
            A126TASICod = P00DA11_A126TASICod[0];
            A128VouMes = P00DA11_A128VouMes[0];
            A127VouAno = P00DA11_A127VouAno[0];
            A129VouNum = P00DA11_A129VouNum[0];
            A130VouDSec = P00DA11_A130VouDSec[0];
            AV52Flag = 1;
            pr_default.readNext(9);
         }
         pr_default.close(9);
      }

      protected void S178( )
      {
         /* 'VALIDASALIDASCONTABILIDAD' Routine */
         returnInSub = false;
         /* Using cursor P00DA12 */
         pr_default.execute(10, new Object[] {AV55Codigo, AV12MVAFec});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A14MvACod = P00DA12_A14MvACod[0];
            A21MvAlm = P00DA12_A21MvAlm[0];
            A52LinCod = P00DA12_A52LinCod[0];
            A28ProdCod = P00DA12_A28ProdCod[0];
            A1158LinStk = P00DA12_A1158LinStk[0];
            A1269MvAlmCos = P00DA12_A1269MvAlmCos[0];
            A13MvATip = P00DA12_A13MvATip[0];
            A1370MVSts = P00DA12_A1370MVSts[0];
            A25MvAFec = P00DA12_A25MvAFec[0];
            A30MvADItem = P00DA12_A30MvADItem[0];
            A52LinCod = P00DA12_A52LinCod[0];
            A1158LinStk = P00DA12_A1158LinStk[0];
            A21MvAlm = P00DA12_A21MvAlm[0];
            A1370MVSts = P00DA12_A1370MVSts[0];
            A25MvAFec = P00DA12_A25MvAFec[0];
            A1269MvAlmCos = P00DA12_A1269MvAlmCos[0];
            AV52Flag = 1;
            pr_default.readNext(10);
         }
         pr_default.close(10);
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
         AV35Filename = "";
         AV39ErrorMessage = "";
         AV32Archivo = new GxFile(context.GetPhysicalPath());
         AV33Path = "";
         AV34FilenameOrigen = "";
         AV36ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P00DA3_A91CueCod = new string[] {""} ;
         P00DA3_A126TASICod = new int[1] ;
         P00DA3_A2077VouSts = new short[1] ;
         P00DA3_A128VouMes = new short[1] ;
         P00DA3_A127VouAno = new short[1] ;
         P00DA3_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00DA3_A132VouDTipCod = new string[] {""} ;
         P00DA3_A2053VouDDoc = new string[] {""} ;
         P00DA3_A2054VouDGls = new string[] {""} ;
         P00DA3_A2058VouDProdCod = new string[] {""} ;
         P00DA3_A129VouNum = new string[] {""} ;
         P00DA3_A2057VouDordCod = new string[] {""} ;
         P00DA3_A2050VouDCant = new decimal[1] ;
         P00DA3_A2055VouDHab = new decimal[1] ;
         P00DA3_A2051VouDDeb = new decimal[1] ;
         P00DA3_A2056VouDHabO = new decimal[1] ;
         P00DA3_A2052VouDDebO = new decimal[1] ;
         P00DA3_A130VouDSec = new int[1] ;
         A91CueCod = "";
         A135VouDFec = DateTime.MinValue;
         A132VouDTipCod = "";
         A2053VouDDoc = "";
         A2054VouDGls = "";
         A2058VouDProdCod = "";
         A129VouNum = "";
         A2057VouDordCod = "";
         AV12MVAFec = DateTime.MinValue;
         AV43TipCod = "";
         AV42ComCod = "";
         AV44Glosa = "";
         AV29ProdDsc = "";
         AV47OrdCod = "";
         AV54MovDsc = "";
         AV11MVACod = "";
         P00DA4_A22MvAMov = new int[1] ;
         P00DA4_A21MvAlm = new int[1] ;
         P00DA4_A52LinCod = new int[1] ;
         P00DA4_A1158LinStk = new short[1] ;
         P00DA4_A1269MvAlmCos = new short[1] ;
         P00DA4_A13MvATip = new string[] {""} ;
         P00DA4_A1370MVSts = new string[] {""} ;
         P00DA4_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00DA4_A1276MvAOcom = new string[] {""} ;
         P00DA4_A14MvACod = new string[] {""} ;
         P00DA4_A28ProdCod = new string[] {""} ;
         P00DA4_A55ProdDsc = new string[] {""} ;
         P00DA4_A1248MvADCant = new decimal[1] ;
         P00DA4_A1249MVADCosto = new decimal[1] ;
         P00DA4_A1271MvAlmDsc = new string[] {""} ;
         P00DA4_A1274MvAMovDsc = new string[] {""} ;
         P00DA4_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         A1276MvAOcom = "";
         A14MvACod = "";
         A28ProdCod = "";
         A55ProdDsc = "";
         A1271MvAlmDsc = "";
         A1274MvAMovDsc = "";
         AV51MVAlmDsc = "";
         P00DA5_A22MvAMov = new int[1] ;
         P00DA5_A21MvAlm = new int[1] ;
         P00DA5_A52LinCod = new int[1] ;
         P00DA5_A1158LinStk = new short[1] ;
         P00DA5_A1269MvAlmCos = new short[1] ;
         P00DA5_A13MvATip = new string[] {""} ;
         P00DA5_A1370MVSts = new string[] {""} ;
         P00DA5_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00DA5_A1276MvAOcom = new string[] {""} ;
         P00DA5_A14MvACod = new string[] {""} ;
         P00DA5_A28ProdCod = new string[] {""} ;
         P00DA5_A55ProdDsc = new string[] {""} ;
         P00DA5_A1248MvADCant = new decimal[1] ;
         P00DA5_A1249MVADCosto = new decimal[1] ;
         P00DA5_A1271MvAlmDsc = new string[] {""} ;
         P00DA5_A1274MvAMovDsc = new string[] {""} ;
         P00DA5_A30MvADItem = new int[1] ;
         P00DA6_A2087VSFecha = new DateTime[] {DateTime.MinValue} ;
         P00DA6_A2092VSTipCod = new string[] {""} ;
         P00DA6_A2086VSDocNum = new string[] {""} ;
         P00DA6_A2084VSCostoFac = new decimal[1] ;
         P00DA6_A2091VSProdDsc = new string[] {""} ;
         P00DA6_A2083VSCantIng = new decimal[1] ;
         P00DA6_A2085VSCostoIng = new decimal[1] ;
         P00DA6_A2082VSCantFac = new decimal[1] ;
         P00DA6_A2093VSTipMov = new string[] {""} ;
         P00DA6_A2090VSProdCod = new string[] {""} ;
         P00DA6_A2088VSMVACod = new string[] {""} ;
         P00DA6_A2089VSOrdCod = new string[] {""} ;
         P00DA6_A237VSItem = new long[1] ;
         A2087VSFecha = DateTime.MinValue;
         A2092VSTipCod = "";
         A2086VSDocNum = "";
         A2091VSProdDsc = "";
         A2093VSTipMov = "";
         A2090VSProdCod = "";
         A2088VSMVACod = "";
         A2089VSOrdCod = "";
         P00DA7_A22MvAMov = new int[1] ;
         P00DA7_A21MvAlm = new int[1] ;
         P00DA7_A52LinCod = new int[1] ;
         P00DA7_A1158LinStk = new short[1] ;
         P00DA7_A1269MvAlmCos = new short[1] ;
         P00DA7_A13MvATip = new string[] {""} ;
         P00DA7_A1370MVSts = new string[] {""} ;
         P00DA7_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00DA7_A1276MvAOcom = new string[] {""} ;
         P00DA7_A14MvACod = new string[] {""} ;
         P00DA7_A28ProdCod = new string[] {""} ;
         P00DA7_A55ProdDsc = new string[] {""} ;
         P00DA7_A1248MvADCant = new decimal[1] ;
         P00DA7_A1249MVADCosto = new decimal[1] ;
         P00DA7_A1271MvAlmDsc = new string[] {""} ;
         P00DA7_A1274MvAMovDsc = new string[] {""} ;
         P00DA7_A30MvADItem = new int[1] ;
         AV48SdtConsistenciaDet = new SdtSdtConsistencia_SdtCuentaItem(context);
         AV49SdtConsistencia = new GXBaseCollection<SdtSdtConsistencia_SdtCuentaItem>( context, "SdtCuentaItem", "SIGERP_ADVANCED");
         P00DA8_A91CueCod = new string[] {""} ;
         P00DA8_A126TASICod = new int[1] ;
         P00DA8_A128VouMes = new short[1] ;
         P00DA8_A127VouAno = new short[1] ;
         P00DA8_A2053VouDDoc = new string[] {""} ;
         P00DA8_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00DA8_A2058VouDProdCod = new string[] {""} ;
         P00DA8_A2054VouDGls = new string[] {""} ;
         P00DA8_A2055VouDHab = new decimal[1] ;
         P00DA8_A2051VouDDeb = new decimal[1] ;
         P00DA8_A129VouNum = new string[] {""} ;
         P00DA8_A130VouDSec = new int[1] ;
         AV55Codigo = "";
         P00DA9_A28ProdCod = new string[] {""} ;
         P00DA9_A55ProdDsc = new string[] {""} ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         P00DA10_AV56ii = new int[1] ;
         P00DA11_A2054VouDGls = new string[] {""} ;
         P00DA11_A2053VouDDoc = new string[] {""} ;
         P00DA11_A91CueCod = new string[] {""} ;
         P00DA11_A126TASICod = new int[1] ;
         P00DA11_A128VouMes = new short[1] ;
         P00DA11_A127VouAno = new short[1] ;
         P00DA11_A129VouNum = new string[] {""} ;
         P00DA11_A130VouDSec = new int[1] ;
         P00DA12_A14MvACod = new string[] {""} ;
         P00DA12_A21MvAlm = new int[1] ;
         P00DA12_A52LinCod = new int[1] ;
         P00DA12_A28ProdCod = new string[] {""} ;
         P00DA12_A1158LinStk = new short[1] ;
         P00DA12_A1269MvAlmCos = new short[1] ;
         P00DA12_A13MvATip = new string[] {""} ;
         P00DA12_A1370MVSts = new string[] {""} ;
         P00DA12_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00DA12_A30MvADItem = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.compras.r_resumencomparativocomprasexcel__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_resumencomparativocomprasexcel__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               P00DA3_A91CueCod, P00DA3_A126TASICod, P00DA3_A2077VouSts, P00DA3_A128VouMes, P00DA3_A127VouAno, P00DA3_A135VouDFec, P00DA3_A132VouDTipCod, P00DA3_A2053VouDDoc, P00DA3_A2054VouDGls, P00DA3_A2058VouDProdCod,
               P00DA3_A129VouNum, P00DA3_A2057VouDordCod, P00DA3_A2050VouDCant, P00DA3_A2055VouDHab, P00DA3_A2051VouDDeb, P00DA3_A2056VouDHabO, P00DA3_A2052VouDDebO, P00DA3_A130VouDSec
               }
               , new Object[] {
               P00DA4_A22MvAMov, P00DA4_A21MvAlm, P00DA4_A52LinCod, P00DA4_A1158LinStk, P00DA4_A1269MvAlmCos, P00DA4_A13MvATip, P00DA4_A1370MVSts, P00DA4_A25MvAFec, P00DA4_A1276MvAOcom, P00DA4_A14MvACod,
               P00DA4_A28ProdCod, P00DA4_A55ProdDsc, P00DA4_A1248MvADCant, P00DA4_A1249MVADCosto, P00DA4_A1271MvAlmDsc, P00DA4_A1274MvAMovDsc, P00DA4_A30MvADItem
               }
               , new Object[] {
               P00DA5_A22MvAMov, P00DA5_A21MvAlm, P00DA5_A52LinCod, P00DA5_A1158LinStk, P00DA5_A1269MvAlmCos, P00DA5_A13MvATip, P00DA5_A1370MVSts, P00DA5_A25MvAFec, P00DA5_A1276MvAOcom, P00DA5_A14MvACod,
               P00DA5_A28ProdCod, P00DA5_A55ProdDsc, P00DA5_A1248MvADCant, P00DA5_A1249MVADCosto, P00DA5_A1271MvAlmDsc, P00DA5_A1274MvAMovDsc, P00DA5_A30MvADItem
               }
               , new Object[] {
               P00DA6_A2087VSFecha, P00DA6_A2092VSTipCod, P00DA6_A2086VSDocNum, P00DA6_A2084VSCostoFac, P00DA6_A2091VSProdDsc, P00DA6_A2083VSCantIng, P00DA6_A2085VSCostoIng, P00DA6_A2082VSCantFac, P00DA6_A2093VSTipMov, P00DA6_A2090VSProdCod,
               P00DA6_A2088VSMVACod, P00DA6_A2089VSOrdCod, P00DA6_A237VSItem
               }
               , new Object[] {
               P00DA7_A22MvAMov, P00DA7_A21MvAlm, P00DA7_A52LinCod, P00DA7_A1158LinStk, P00DA7_A1269MvAlmCos, P00DA7_A13MvATip, P00DA7_A1370MVSts, P00DA7_A25MvAFec, P00DA7_A1276MvAOcom, P00DA7_A14MvACod,
               P00DA7_A28ProdCod, P00DA7_A55ProdDsc, P00DA7_A1248MvADCant, P00DA7_A1249MVADCosto, P00DA7_A1271MvAlmDsc, P00DA7_A1274MvAMovDsc, P00DA7_A30MvADItem
               }
               , new Object[] {
               P00DA8_A91CueCod, P00DA8_A126TASICod, P00DA8_A128VouMes, P00DA8_A127VouAno, P00DA8_A2053VouDDoc, P00DA8_A135VouDFec, P00DA8_A2058VouDProdCod, P00DA8_A2054VouDGls, P00DA8_A2055VouDHab, P00DA8_A2051VouDDeb,
               P00DA8_A129VouNum, P00DA8_A130VouDSec
               }
               , new Object[] {
               P00DA9_A28ProdCod, P00DA9_A55ProdDsc
               }
               , new Object[] {
               P00DA10_AV56ii
               }
               , new Object[] {
               P00DA11_A2054VouDGls, P00DA11_A2053VouDDoc, P00DA11_A91CueCod, P00DA11_A126TASICod, P00DA11_A128VouMes, P00DA11_A127VouAno, P00DA11_A129VouNum, P00DA11_A130VouDSec
               }
               , new Object[] {
               P00DA12_A14MvACod, P00DA12_A21MvAlm, P00DA12_A52LinCod, P00DA12_A28ProdCod, P00DA12_A1158LinStk, P00DA12_A1269MvAlmCos, P00DA12_A13MvATip, P00DA12_A1370MVSts, P00DA12_A25MvAFec, P00DA12_A30MvADItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV41Ref2 ;
      private short AV8Ano ;
      private short AV9Mes ;
      private short A2077VouSts ;
      private short A128VouMes ;
      private short A127VouAno ;
      private short AV52Flag ;
      private short A1158LinStk ;
      private short A1269MvAlmCos ;
      private int AV30LinCod ;
      private int AV31SubLCod ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int A22MvAMov ;
      private int A21MvAlm ;
      private int A52LinCod ;
      private int A30MvADItem ;
      private int AV68GXV1 ;
      private int AV56ii ;
      private int cV56ii ;
      private long AV37CellRow ;
      private long AV38FirstColumn ;
      private long AV50i ;
      private long A237VSItem ;
      private decimal A2050VouDCant ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private decimal A2056VouDHabO ;
      private decimal A2052VouDDebO ;
      private decimal AV46ComDTot ;
      private decimal AV13MVADCant ;
      private decimal AV14MVADCosto ;
      private decimal AV45ComDCant ;
      private decimal AV57Dif ;
      private decimal AV58Total ;
      private decimal A1248MvADCant ;
      private decimal A1249MVADCosto ;
      private decimal A2084VSCostoFac ;
      private decimal A2083VSCantIng ;
      private decimal A2085VSCostoIng ;
      private decimal A2082VSCantFac ;
      private decimal AV17DifCant ;
      private decimal AV18DifCosto ;
      private string AV21ProdCod ;
      private string AV53nReporte ;
      private string AV39ErrorMessage ;
      private string AV33Path ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A132VouDTipCod ;
      private string A2053VouDDoc ;
      private string A2054VouDGls ;
      private string A2058VouDProdCod ;
      private string A129VouNum ;
      private string A2057VouDordCod ;
      private string AV43TipCod ;
      private string AV42ComCod ;
      private string AV44Glosa ;
      private string AV29ProdDsc ;
      private string AV47OrdCod ;
      private string AV54MovDsc ;
      private string AV11MVACod ;
      private string A13MvATip ;
      private string A1370MVSts ;
      private string A1276MvAOcom ;
      private string A14MvACod ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1271MvAlmDsc ;
      private string A1274MvAMovDsc ;
      private string AV51MVAlmDsc ;
      private string A2092VSTipCod ;
      private string A2086VSDocNum ;
      private string A2090VSProdCod ;
      private string A2088VSMVACod ;
      private string A2089VSOrdCod ;
      private string AV55Codigo ;
      private DateTime GXt_dtime1 ;
      private DateTime AV19DDesde ;
      private DateTime AV20DHasta ;
      private DateTime A135VouDFec ;
      private DateTime AV12MVAFec ;
      private DateTime A25MvAFec ;
      private DateTime A2087VSFecha ;
      private bool returnInSub ;
      private string AV35Filename ;
      private string AV34FilenameOrigen ;
      private string A2091VSProdDsc ;
      private string A2093VSTipMov ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private string aP2_ProdCod ;
      private DateTime aP3_DDesde ;
      private DateTime aP4_DHasta ;
      private short aP5_Ref2 ;
      private string aP6_nReporte ;
      private IDataStoreProvider pr_default ;
      private string[] P00DA3_A91CueCod ;
      private int[] P00DA3_A126TASICod ;
      private short[] P00DA3_A2077VouSts ;
      private short[] P00DA3_A128VouMes ;
      private short[] P00DA3_A127VouAno ;
      private DateTime[] P00DA3_A135VouDFec ;
      private string[] P00DA3_A132VouDTipCod ;
      private string[] P00DA3_A2053VouDDoc ;
      private string[] P00DA3_A2054VouDGls ;
      private string[] P00DA3_A2058VouDProdCod ;
      private string[] P00DA3_A129VouNum ;
      private string[] P00DA3_A2057VouDordCod ;
      private decimal[] P00DA3_A2050VouDCant ;
      private decimal[] P00DA3_A2055VouDHab ;
      private decimal[] P00DA3_A2051VouDDeb ;
      private decimal[] P00DA3_A2056VouDHabO ;
      private decimal[] P00DA3_A2052VouDDebO ;
      private int[] P00DA3_A130VouDSec ;
      private int[] P00DA4_A22MvAMov ;
      private int[] P00DA4_A21MvAlm ;
      private int[] P00DA4_A52LinCod ;
      private short[] P00DA4_A1158LinStk ;
      private short[] P00DA4_A1269MvAlmCos ;
      private string[] P00DA4_A13MvATip ;
      private string[] P00DA4_A1370MVSts ;
      private DateTime[] P00DA4_A25MvAFec ;
      private string[] P00DA4_A1276MvAOcom ;
      private string[] P00DA4_A14MvACod ;
      private string[] P00DA4_A28ProdCod ;
      private string[] P00DA4_A55ProdDsc ;
      private decimal[] P00DA4_A1248MvADCant ;
      private decimal[] P00DA4_A1249MVADCosto ;
      private string[] P00DA4_A1271MvAlmDsc ;
      private string[] P00DA4_A1274MvAMovDsc ;
      private int[] P00DA4_A30MvADItem ;
      private int[] P00DA5_A22MvAMov ;
      private int[] P00DA5_A21MvAlm ;
      private int[] P00DA5_A52LinCod ;
      private short[] P00DA5_A1158LinStk ;
      private short[] P00DA5_A1269MvAlmCos ;
      private string[] P00DA5_A13MvATip ;
      private string[] P00DA5_A1370MVSts ;
      private DateTime[] P00DA5_A25MvAFec ;
      private string[] P00DA5_A1276MvAOcom ;
      private string[] P00DA5_A14MvACod ;
      private string[] P00DA5_A28ProdCod ;
      private string[] P00DA5_A55ProdDsc ;
      private decimal[] P00DA5_A1248MvADCant ;
      private decimal[] P00DA5_A1249MVADCosto ;
      private string[] P00DA5_A1271MvAlmDsc ;
      private string[] P00DA5_A1274MvAMovDsc ;
      private int[] P00DA5_A30MvADItem ;
      private DateTime[] P00DA6_A2087VSFecha ;
      private string[] P00DA6_A2092VSTipCod ;
      private string[] P00DA6_A2086VSDocNum ;
      private decimal[] P00DA6_A2084VSCostoFac ;
      private string[] P00DA6_A2091VSProdDsc ;
      private decimal[] P00DA6_A2083VSCantIng ;
      private decimal[] P00DA6_A2085VSCostoIng ;
      private decimal[] P00DA6_A2082VSCantFac ;
      private string[] P00DA6_A2093VSTipMov ;
      private string[] P00DA6_A2090VSProdCod ;
      private string[] P00DA6_A2088VSMVACod ;
      private string[] P00DA6_A2089VSOrdCod ;
      private long[] P00DA6_A237VSItem ;
      private int[] P00DA7_A22MvAMov ;
      private int[] P00DA7_A21MvAlm ;
      private int[] P00DA7_A52LinCod ;
      private short[] P00DA7_A1158LinStk ;
      private short[] P00DA7_A1269MvAlmCos ;
      private string[] P00DA7_A13MvATip ;
      private string[] P00DA7_A1370MVSts ;
      private DateTime[] P00DA7_A25MvAFec ;
      private string[] P00DA7_A1276MvAOcom ;
      private string[] P00DA7_A14MvACod ;
      private string[] P00DA7_A28ProdCod ;
      private string[] P00DA7_A55ProdDsc ;
      private decimal[] P00DA7_A1248MvADCant ;
      private decimal[] P00DA7_A1249MVADCosto ;
      private string[] P00DA7_A1271MvAlmDsc ;
      private string[] P00DA7_A1274MvAMovDsc ;
      private int[] P00DA7_A30MvADItem ;
      private string[] P00DA8_A91CueCod ;
      private int[] P00DA8_A126TASICod ;
      private short[] P00DA8_A128VouMes ;
      private short[] P00DA8_A127VouAno ;
      private string[] P00DA8_A2053VouDDoc ;
      private DateTime[] P00DA8_A135VouDFec ;
      private string[] P00DA8_A2058VouDProdCod ;
      private string[] P00DA8_A2054VouDGls ;
      private decimal[] P00DA8_A2055VouDHab ;
      private decimal[] P00DA8_A2051VouDDeb ;
      private string[] P00DA8_A129VouNum ;
      private int[] P00DA8_A130VouDSec ;
      private string[] P00DA9_A28ProdCod ;
      private string[] P00DA9_A55ProdDsc ;
      private int[] P00DA10_AV56ii ;
      private string[] P00DA11_A2054VouDGls ;
      private string[] P00DA11_A2053VouDDoc ;
      private string[] P00DA11_A91CueCod ;
      private int[] P00DA11_A126TASICod ;
      private short[] P00DA11_A128VouMes ;
      private short[] P00DA11_A127VouAno ;
      private string[] P00DA11_A129VouNum ;
      private int[] P00DA11_A130VouDSec ;
      private string[] P00DA12_A14MvACod ;
      private int[] P00DA12_A21MvAlm ;
      private int[] P00DA12_A52LinCod ;
      private string[] P00DA12_A28ProdCod ;
      private short[] P00DA12_A1158LinStk ;
      private short[] P00DA12_A1269MvAlmCos ;
      private string[] P00DA12_A13MvATip ;
      private string[] P00DA12_A1370MVSts ;
      private DateTime[] P00DA12_A25MvAFec ;
      private int[] P00DA12_A30MvADItem ;
      private string aP7_Filename ;
      private string aP8_ErrorMessage ;
      private IDataStoreProvider pr_datastore2 ;
      private ExcelDocumentI AV36ExcelDocument ;
      private GXBaseCollection<SdtSdtConsistencia_SdtCuentaItem> AV49SdtConsistencia ;
      private GxFile AV32Archivo ;
      private SdtSdtConsistencia_SdtCuentaItem AV48SdtConsistenciaDet ;
   }

   public class r_resumencomparativocomprasexcel__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class r_resumencomparativocomprasexcel__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00DA2;
        prmP00DA2 = new Object[] {
        };
        Object[] prmP00DA3;
        prmP00DA3 = new Object[] {
        new ParDef("@AV8Ano",GXType.Int16,4,0) ,
        new ParDef("@AV9Mes",GXType.Int16,2,0)
        };
        Object[] prmP00DA4;
        prmP00DA4 = new Object[] {
        new ParDef("@AV19DDesde",GXType.Date,8,0) ,
        new ParDef("@AV20DHasta",GXType.Date,8,0)
        };
        Object[] prmP00DA5;
        prmP00DA5 = new Object[] {
        new ParDef("@AV19DDesde",GXType.Date,8,0) ,
        new ParDef("@AV20DHasta",GXType.Date,8,0)
        };
        Object[] prmP00DA6;
        prmP00DA6 = new Object[] {
        };
        Object[] prmP00DA7;
        prmP00DA7 = new Object[] {
        new ParDef("@AV19DDesde",GXType.Date,8,0) ,
        new ParDef("@AV20DHasta",GXType.Date,8,0)
        };
        Object[] prmP00DA8;
        prmP00DA8 = new Object[] {
        new ParDef("@AV8Ano",GXType.Int16,4,0) ,
        new ParDef("@AV9Mes",GXType.Int16,2,0)
        };
        Object[] prmP00DA9;
        prmP00DA9 = new Object[] {
        new ParDef("@AV21ProdCod",GXType.NChar,15,0)
        };
        Object[] prmP00DA10;
        prmP00DA10 = new Object[] {
        new ParDef("@AV19DDesde",GXType.Date,8,0) ,
        new ParDef("@AV20DHasta",GXType.Date,8,0) ,
        new ParDef("@AV47OrdCod",GXType.NChar,10,0) ,
        new ParDef("@AV21ProdCod",GXType.NChar,15,0)
        };
        Object[] prmP00DA11;
        prmP00DA11 = new Object[] {
        new ParDef("@AV8Ano",GXType.Int16,4,0) ,
        new ParDef("@AV9Mes",GXType.Int16,2,0) ,
        new ParDef("@AV11MVACod",GXType.NChar,12,0) ,
        new ParDef("@AV29ProdDsc",GXType.NChar,100,0)
        };
        Object[] prmP00DA12;
        prmP00DA12 = new Object[] {
        new ParDef("@AV55Codigo",GXType.NChar,15,0) ,
        new ParDef("@AV12MVAFec",GXType.Date,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00DA2", "DELETE FROM [CPALMACENVSCONTA] ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00DA2)
           ,new CursorDef("P00DA3", "SELECT T1.[CueCod], T1.[TASICod], T2.[VouSts], T1.[VouMes], T1.[VouAno], T1.[VouDFec], T1.[VouDTipCod], T1.[VouDDoc], T1.[VouDGls], T1.[VouDProdCod], T1.[VouNum], T1.[VouDordCod], T1.[VouDCant], T1.[VouDHab], T1.[VouDDeb], T1.[VouDHabO], T1.[VouDDebO], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = @AV9Mes) AND (T1.[TASICod] <> 17) AND (SUBSTRING(T1.[CueCod], 1, 2) = '25') AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DA3,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00DA4", "SELECT T2.[MvAMov] AS MvAMov, T2.[MvAlm] AS MvAlm, T5.[LinCod], T6.[LinStk], T4.[AlmCos] AS MvAlmCos, T1.[MvATip], T2.[MVSts], T2.[MvAFec], T2.[MvAOcom], T1.[MvACod], T1.[ProdCod], T5.[ProdDsc], T1.[MvADCant], T1.[MVADCosto], T4.[AlmDsc] AS MvAlmDsc, T3.[MovDsc] AS MvAMovDsc, T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T3 ON T3.[MovCod] = T2.[MvAMov]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T5 ON T5.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T6 ON T6.[LinCod] = T5.[LinCod]) WHERE (T1.[MvATip] = 'ING') AND (T2.[MvAFec] >= @AV19DDesde) AND (T2.[MvAFec] <= @AV20DHasta) AND (T2.[MVSts] <> 'A') AND (T4.[AlmCos] = 1) AND (T6.[LinStk] = 1) ORDER BY T1.[MvATip] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DA4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00DA5", "SELECT T2.[MvAMov] AS MvAMov, T2.[MvAlm] AS MvAlm, T5.[LinCod], T6.[LinStk], T4.[AlmCos] AS MvAlmCos, T1.[MvATip], T2.[MVSts], T2.[MvAFec], T2.[MvAOcom], T1.[MvACod], T1.[ProdCod], T5.[ProdDsc], T1.[MvADCant], T1.[MVADCosto], T4.[AlmDsc] AS MvAlmDsc, T3.[MovDsc] AS MvAMovDsc, T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T3 ON T3.[MovCod] = T2.[MvAMov]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T5 ON T5.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T6 ON T6.[LinCod] = T5.[LinCod]) WHERE (T1.[MvATip] = 'ING') AND (T2.[MvAFec] >= @AV19DDesde) AND (T2.[MvAFec] <= @AV20DHasta) AND (T2.[MVSts] <> 'A') AND (T4.[AlmCos] = 1) AND (T6.[LinStk] = 1) ORDER BY T1.[MvATip] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DA5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00DA6", "SELECT [VSFecha], [VSTipCod], [VSDocNum], [VSCostoFac], [VSProdDsc], [VSCantIng], [VSCostoIng], [VSCantFac], [VSTipMov], [VSProdCod], [VSMVACod], [VSOrdCod], [VSItem] FROM [CPALMACENVSCONTA] ORDER BY [VSOrdCod], [VSMVACod], [VSProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DA6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00DA7", "SELECT T2.[MvAMov] AS MvAMov, T2.[MvAlm] AS MvAlm, T5.[LinCod], T6.[LinStk], T4.[AlmCos] AS MvAlmCos, T1.[MvATip], T2.[MVSts], T2.[MvAFec], T2.[MvAOcom], T1.[MvACod], T1.[ProdCod], T5.[ProdDsc], T1.[MvADCant], T1.[MVADCosto], T4.[AlmDsc] AS MvAlmDsc, T3.[MovDsc] AS MvAMovDsc, T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T3 ON T3.[MovCod] = T2.[MvAMov]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T5 ON T5.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T6 ON T6.[LinCod] = T5.[LinCod]) WHERE (T2.[MvAFec] >= @AV19DDesde) AND (T2.[MvAFec] <= @AV20DHasta) AND (T2.[MVSts] <> 'A') AND (T1.[MvATip] <> 'ING') AND (T4.[AlmCos] = 1) AND (T6.[LinStk] = 1) ORDER BY T1.[MvATip], T1.[MvACod], T1.[MvADItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DA7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00DA8", "SELECT [CueCod], [TASICod], [VouMes], [VouAno], [VouDDoc], [VouDFec], [VouDProdCod], [VouDGls], [VouDHab], [VouDDeb], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE ([VouAno] = @AV8Ano and [VouMes] = @AV9Mes and [TASICod] = 17) AND (SUBSTRING([CueCod], 1, 2) = '25') ORDER BY [VouAno], [VouMes], [TASICod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DA8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00DA9", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV21ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DA9,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00DA10", "SELECT COUNT(*) FROM (((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T4 ON T4.[MvATip] = T1.[MvATip] AND T4.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T5 ON T5.[AlmCod] = T4.[MvAlm]) WHERE (T1.[MvATip] = 'ING') AND (T4.[MvAFec] >= @AV19DDesde) AND (T4.[MvAFec] <= @AV20DHasta) AND (T4.[MVSts] <> 'A') AND (T5.[AlmCos] = 1) AND (T3.[LinStk] = 1) AND (T4.[MvAOcom] = @AV47OrdCod) AND (T1.[ProdCod] = @AV21ProdCod) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DA10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00DA11", "SELECT [VouDGls], [VouDDoc], [CueCod], [TASICod], [VouMes], [VouAno], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE ([VouAno] = @AV8Ano and [VouMes] = @AV9Mes and [TASICod] = 17) AND (SUBSTRING([CueCod], 1, 2) = '25') AND ([VouDDoc] = @AV11MVACod) AND ([VouDGls] = @AV29ProdDsc) ORDER BY [VouAno], [VouMes], [TASICod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DA11,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00DA12", "SELECT T1.[MvACod], T4.[MvAlm] AS MvAlm, T2.[LinCod], T1.[ProdCod], T3.[LinStk], T5.[AlmCos] AS MvAlmCos, T1.[MvATip], T4.[MVSts], T4.[MvAFec], T1.[MvADItem] FROM (((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T4 ON T4.[MvATip] = T1.[MvATip] AND T4.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T5 ON T5.[AlmCod] = T4.[MvAlm]) WHERE (T1.[ProdCod] = @AV55Codigo) AND (T4.[MVSts] <> 'A') AND (T1.[MvATip] <> 'ING') AND (T4.[MvAFec] = @AV12MVAFec) AND (T5.[AlmCos] = 1) AND (T3.[LinStk] = 1) ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DA12,100, GxCacheFrequency.OFF ,false,false )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 100);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              ((int[]) buf[17])[0] = rslt.getInt(18);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 1);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((string[]) buf[9])[0] = rslt.getString(10, 12);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              ((string[]) buf[11])[0] = rslt.getString(12, 100);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 100);
              ((string[]) buf[15])[0] = rslt.getString(16, 100);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 1);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((string[]) buf[9])[0] = rslt.getString(10, 12);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              ((string[]) buf[11])[0] = rslt.getString(12, 100);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 100);
              ((string[]) buf[15])[0] = rslt.getString(16, 100);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((long[]) buf[12])[0] = rslt.getLong(13);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 1);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((string[]) buf[9])[0] = rslt.getString(10, 12);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              ((string[]) buf[11])[0] = rslt.getString(12, 100);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 100);
              ((string[]) buf[15])[0] = rslt.getString(16, 100);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 12);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
     }
  }

}

}
