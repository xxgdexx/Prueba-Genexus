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
   public class r_resumenguiasremisionexcel : GXProcedure
   {
      public r_resumenguiasremisionexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenguiasremisionexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SubLCod ,
                           ref string aP2_Prodcod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref short aP5_Flag ,
                           ref string aP6_CliCod ,
                           ref int aP7_MVCliOrigen ,
                           ref int aP8_MovCod ,
                           ref string aP9_MVCCosto ,
                           ref int aP10_ChoCod ,
                           out string aP11_Filename ,
                           out string aP12_ErrorMessage )
      {
         this.AV75LinCod = aP0_LinCod;
         this.AV106SubLCod = aP1_SubLCod;
         this.AV95Prodcod = aP2_Prodcod;
         this.AV49FDesde = aP3_FDesde;
         this.AV52FHasta = aP4_FHasta;
         this.AV121Flag = aP5_Flag;
         this.AV18CliCod = aP6_CliCod;
         this.AV86MVCliOrigen = aP7_MVCliOrigen;
         this.AV79MovCod = aP8_MovCod;
         this.AV84MVCCosto = aP9_MVCCosto;
         this.AV16ChoCod = aP10_ChoCod;
         this.AV53Filename = "" ;
         this.AV46ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV75LinCod;
         aP1_SubLCod=this.AV106SubLCod;
         aP2_Prodcod=this.AV95Prodcod;
         aP3_FDesde=this.AV49FDesde;
         aP4_FHasta=this.AV52FHasta;
         aP5_Flag=this.AV121Flag;
         aP6_CliCod=this.AV18CliCod;
         aP7_MVCliOrigen=this.AV86MVCliOrigen;
         aP8_MovCod=this.AV79MovCod;
         aP9_MVCCosto=this.AV84MVCCosto;
         aP10_ChoCod=this.AV16ChoCod;
         aP11_Filename=this.AV53Filename;
         aP12_ErrorMessage=this.AV46ErrorMessage;
      }

      public string executeUdp( ref int aP0_LinCod ,
                                ref int aP1_SubLCod ,
                                ref string aP2_Prodcod ,
                                ref DateTime aP3_FDesde ,
                                ref DateTime aP4_FHasta ,
                                ref short aP5_Flag ,
                                ref string aP6_CliCod ,
                                ref int aP7_MVCliOrigen ,
                                ref int aP8_MovCod ,
                                ref string aP9_MVCCosto ,
                                ref int aP10_ChoCod ,
                                out string aP11_Filename )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_Prodcod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_Flag, ref aP6_CliCod, ref aP7_MVCliOrigen, ref aP8_MovCod, ref aP9_MVCCosto, ref aP10_ChoCod, out aP11_Filename, out aP12_ErrorMessage);
         return AV46ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref string aP2_Prodcod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref short aP5_Flag ,
                                 ref string aP6_CliCod ,
                                 ref int aP7_MVCliOrigen ,
                                 ref int aP8_MovCod ,
                                 ref string aP9_MVCCosto ,
                                 ref int aP10_ChoCod ,
                                 out string aP11_Filename ,
                                 out string aP12_ErrorMessage )
      {
         r_resumenguiasremisionexcel objr_resumenguiasremisionexcel;
         objr_resumenguiasremisionexcel = new r_resumenguiasremisionexcel();
         objr_resumenguiasremisionexcel.AV75LinCod = aP0_LinCod;
         objr_resumenguiasremisionexcel.AV106SubLCod = aP1_SubLCod;
         objr_resumenguiasremisionexcel.AV95Prodcod = aP2_Prodcod;
         objr_resumenguiasremisionexcel.AV49FDesde = aP3_FDesde;
         objr_resumenguiasremisionexcel.AV52FHasta = aP4_FHasta;
         objr_resumenguiasremisionexcel.AV121Flag = aP5_Flag;
         objr_resumenguiasremisionexcel.AV18CliCod = aP6_CliCod;
         objr_resumenguiasremisionexcel.AV86MVCliOrigen = aP7_MVCliOrigen;
         objr_resumenguiasremisionexcel.AV79MovCod = aP8_MovCod;
         objr_resumenguiasremisionexcel.AV84MVCCosto = aP9_MVCCosto;
         objr_resumenguiasremisionexcel.AV16ChoCod = aP10_ChoCod;
         objr_resumenguiasremisionexcel.AV53Filename = "" ;
         objr_resumenguiasremisionexcel.AV46ErrorMessage = "" ;
         objr_resumenguiasremisionexcel.context.SetSubmitInitialConfig(context);
         objr_resumenguiasremisionexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenguiasremisionexcel);
         aP0_LinCod=this.AV75LinCod;
         aP1_SubLCod=this.AV106SubLCod;
         aP2_Prodcod=this.AV95Prodcod;
         aP3_FDesde=this.AV49FDesde;
         aP4_FHasta=this.AV52FHasta;
         aP5_Flag=this.AV121Flag;
         aP6_CliCod=this.AV18CliCod;
         aP7_MVCliOrigen=this.AV86MVCliOrigen;
         aP8_MovCod=this.AV79MovCod;
         aP9_MVCCosto=this.AV84MVCCosto;
         aP10_ChoCod=this.AV16ChoCod;
         aP11_Filename=this.AV53Filename;
         aP12_ErrorMessage=this.AV46ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenguiasremisionexcel)stateInfo).executePrivate();
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
         AV14Archivo.Source = "Excel/PlantillasResumenGuias.xlsx";
         AV94Path = AV14Archivo.GetPath();
         AV54FilenameOrigen = StringUtil.Trim( AV94Path) + "\\PlantillasResumenGuias.xlsx";
         AV53Filename = "Excel/ResumenGuias" + ".xlsx";
         AV47ExcelDocument.Clear();
         AV47ExcelDocument.Template = AV54FilenameOrigen;
         AV47ExcelDocument.Open(AV53Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV15CellRow = 5;
         AV55FirstColumn = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV18CliCod ,
                                              AV79MovCod ,
                                              AV86MVCliOrigen ,
                                              AV84MVCCosto ,
                                              AV16ChoCod ,
                                              A15MVCliCod ,
                                              A22MvAMov ,
                                              A16MVCliOrigen ,
                                              A1287MVCCosto ,
                                              A10ChoCod ,
                                              A25MvAFec ,
                                              AV49FDesde ,
                                              AV52FHasta ,
                                              A13MvATip } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE
                                              }
         });
         /* Using cursor P00DP2 */
         pr_default.execute(0, new Object[] {AV49FDesde, AV52FHasta, AV18CliCod, AV79MovCod, AV86MVCliOrigen, AV84MVCCosto, AV16ChoCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKDP2 = false;
            A13MvATip = P00DP2_A13MvATip[0];
            A1287MVCCosto = P00DP2_A1287MVCCosto[0];
            A10ChoCod = P00DP2_A10ChoCod[0];
            A16MVCliOrigen = P00DP2_A16MVCliOrigen[0];
            n16MVCliOrigen = P00DP2_n16MVCliOrigen[0];
            A22MvAMov = P00DP2_A22MvAMov[0];
            A15MVCliCod = P00DP2_A15MVCliCod[0];
            n15MVCliCod = P00DP2_n15MVCliCod[0];
            A25MvAFec = P00DP2_A25MvAFec[0];
            A14MvACod = P00DP2_A14MvACod[0];
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00DP2_A1287MVCCosto[0], A1287MVCCosto) == 0 ) )
            {
               BRKDP2 = false;
               A13MvATip = P00DP2_A13MvATip[0];
               A14MvACod = P00DP2_A14MvACod[0];
               BRKDP2 = true;
               pr_default.readNext(0);
            }
            AV23CosCod = StringUtil.Trim( A1287MVCCosto);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23CosCod)) )
            {
               /* Execute user subroutine: 'CENTROCOSTO' */
               S161 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
            }
            /* Execute user subroutine: 'RESUMENGUIAS' */
            S131 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( ! BRKDP2 )
            {
               BRKDP2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV47ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV47ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV47ExcelDocument.ErrCode != 0 )
         {
            AV53Filename = "";
            AV46ErrorMessage = AV47ExcelDocument.ErrDescription;
            AV47ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV31DesCod);
         AV47ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+1, 1, 1).Date = AV32DesFec;
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV24CosDsc);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV80MVACod);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV81MVAFec ) ;
         AV47ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+4, 1, 1).Date = GXt_dtime1;
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV83MVARef);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV85MVCliDsc);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV42DocVendDsc);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+8, 1, 1).Text = StringUtil.Trim( AV114TPedDsc);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+9, 1, 1).Text = StringUtil.Trim( AV87MVPedCod);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+10, 1, 1).Text = StringUtil.Trim( AV41DocTip);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+11, 1, 1).Text = StringUtil.Trim( AV39DocNum);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+12, 1, 1).Text = StringUtil.Trim( AV95Prodcod);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+13, 1, 1).Text = StringUtil.Trim( AV97ProdDsc);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+14, 1, 1).Text = StringUtil.Trim( AV119UniAbr);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+15, 1, 1).Text = StringUtil.Trim( AV77MonAbr);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+16, 1, 1).Number = (double)(AV34DocDCan);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+17, 1, 1).Number = (double)(AV35DocDPre);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+18, 1, 1).Number = (double)(AV36DocDTot);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+19, 1, 1).Text = StringUtil.Trim( AV9AlmacenOrigen);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+20, 1, 1).Text = StringUtil.Trim( AV8AlmacenDestino);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+21, 1, 1).Text = StringUtil.Trim( AV45EmpTDsc);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+22, 1, 1).Text = StringUtil.Trim( AV120UNTDsc);
         AV47ExcelDocument.get_Cells(AV15CellRow, AV55FirstColumn+23, 1, 1).Text = StringUtil.Trim( AV17ChoDsc);
         AV15CellRow = (int)(AV15CellRow+1);
      }

      protected void S131( )
      {
         /* 'RESUMENGUIAS' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV18CliCod ,
                                              AV79MovCod ,
                                              AV86MVCliOrigen ,
                                              A15MVCliCod ,
                                              A22MvAMov ,
                                              A16MVCliOrigen ,
                                              A25MvAFec ,
                                              AV49FDesde ,
                                              AV52FHasta ,
                                              A1287MVCCosto ,
                                              AV23CosCod ,
                                              A13MvATip } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00DP3 */
         pr_default.execute(1, new Object[] {AV49FDesde, AV52FHasta, AV23CosCod, AV18CliCod, AV79MovCod, AV86MVCliOrigen});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A21MvAlm = P00DP3_A21MvAlm[0];
            A49UniCod = P00DP3_A49UniCod[0];
            A16MVCliOrigen = P00DP3_A16MVCliOrigen[0];
            n16MVCliOrigen = P00DP3_n16MVCliOrigen[0];
            A22MvAMov = P00DP3_A22MvAMov[0];
            A15MVCliCod = P00DP3_A15MVCliCod[0];
            n15MVCliCod = P00DP3_n15MVCliCod[0];
            A25MvAFec = P00DP3_A25MvAFec[0];
            A13MvATip = P00DP3_A13MvATip[0];
            A1287MVCCosto = P00DP3_A1287MVCCosto[0];
            A1278MvARef = P00DP3_A1278MvARef[0];
            A1290MVCliDsc = P00DP3_A1290MVCliDsc[0];
            A1370MVSts = P00DP3_A1370MVSts[0];
            A20MVPedCod = P00DP3_A20MVPedCod[0];
            n20MVPedCod = P00DP3_n20MVPedCod[0];
            A23DocTip = P00DP3_A23DocTip[0];
            n23DocTip = P00DP3_n23DocTip[0];
            A24DocNum = P00DP3_A24DocNum[0];
            n24DocNum = P00DP3_n24DocNum[0];
            A28ProdCod = P00DP3_A28ProdCod[0];
            A55ProdDsc = P00DP3_A55ProdDsc[0];
            A1997UniAbr = P00DP3_A1997UniAbr[0];
            A1271MvAlmDsc = P00DP3_A1271MvAlmDsc[0];
            A1270MVAlmDestino = P00DP3_A1270MVAlmDestino[0];
            A17EmpTCod = P00DP3_A17EmpTCod[0];
            n17EmpTCod = P00DP3_n17EmpTCod[0];
            A1248MvADCant = P00DP3_A1248MvADCant[0];
            A14MvACod = P00DP3_A14MvACod[0];
            A30MvADItem = P00DP3_A30MvADItem[0];
            A49UniCod = P00DP3_A49UniCod[0];
            A55ProdDsc = P00DP3_A55ProdDsc[0];
            A1997UniAbr = P00DP3_A1997UniAbr[0];
            A21MvAlm = P00DP3_A21MvAlm[0];
            A16MVCliOrigen = P00DP3_A16MVCliOrigen[0];
            n16MVCliOrigen = P00DP3_n16MVCliOrigen[0];
            A22MvAMov = P00DP3_A22MvAMov[0];
            A15MVCliCod = P00DP3_A15MVCliCod[0];
            n15MVCliCod = P00DP3_n15MVCliCod[0];
            A25MvAFec = P00DP3_A25MvAFec[0];
            A1287MVCCosto = P00DP3_A1287MVCCosto[0];
            A1278MvARef = P00DP3_A1278MvARef[0];
            A1370MVSts = P00DP3_A1370MVSts[0];
            A20MVPedCod = P00DP3_A20MVPedCod[0];
            n20MVPedCod = P00DP3_n20MVPedCod[0];
            A23DocTip = P00DP3_A23DocTip[0];
            n23DocTip = P00DP3_n23DocTip[0];
            A24DocNum = P00DP3_A24DocNum[0];
            n24DocNum = P00DP3_n24DocNum[0];
            A1270MVAlmDestino = P00DP3_A1270MVAlmDestino[0];
            A17EmpTCod = P00DP3_A17EmpTCod[0];
            n17EmpTCod = P00DP3_n17EmpTCod[0];
            A1271MvAlmDsc = P00DP3_A1271MvAlmDsc[0];
            A1290MVCliDsc = P00DP3_A1290MVCliDsc[0];
            AV80MVACod = A14MvACod;
            AV81MVAFec = A25MvAFec;
            AV83MVARef = A1278MvARef;
            AV85MVCliDsc = ((StringUtil.StrCmp(A1370MVSts, "A")==0) ? "ANULADA" : StringUtil.Trim( A1290MVCliDsc));
            AV87MVPedCod = ((StringUtil.StrCmp(A1370MVSts, "A")==0) ? "" : StringUtil.Trim( A20MVPedCod));
            AV41DocTip = ((StringUtil.StrCmp(A1370MVSts, "A")==0) ? "" : StringUtil.Trim( A23DocTip));
            AV39DocNum = ((StringUtil.StrCmp(A1370MVSts, "A")==0) ? "" : StringUtil.Trim( A24DocNum));
            AV95Prodcod = A28ProdCod;
            AV97ProdDsc = StringUtil.Trim( A55ProdDsc);
            AV119UniAbr = StringUtil.Trim( A1997UniAbr);
            AV9AlmacenOrigen = A1271MvAlmDsc;
            AV82MVAlmDestino = A1270MVAlmDestino;
            AV8AlmacenDestino = "";
            AV44EmpTCod = A17EmpTCod;
            AV45EmpTDsc = "";
            AV77MonAbr = "";
            AV34DocDCan = A1248MvADCant;
            AV35DocDPre = 0.00m;
            AV36DocDTot = 0.00m;
            AV31DesCod = "";
            AV32DesFec = (DateTime)(DateTime.MinValue);
            AV42DocVendDsc = "";
            AV120UNTDsc = "";
            AV17ChoDsc = "";
            AV114TPedDsc = "";
            /* Execute user subroutine: 'TIPOPEDIDO' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'DOCUMENTO' */
            S154 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'DETALLE' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S161( )
      {
         /* 'CENTROCOSTO' Routine */
         returnInSub = false;
         AV24CosDsc = "";
         /* Using cursor P00DP4 */
         pr_default.execute(2, new Object[] {AV23CosCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A79COSCod = P00DP4_A79COSCod[0];
            A761COSDsc = P00DP4_A761COSDsc[0];
            AV24CosDsc = StringUtil.Trim( A79COSCod) + "  -  " + StringUtil.Trim( A761COSDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      protected void S144( )
      {
         /* 'TIPOPEDIDO' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87MVPedCod)) )
         {
            /* Using cursor P00DP5 */
            pr_default.execute(3, new Object[] {AV87MVPedCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A212TPedCod = P00DP5_A212TPedCod[0];
               A210PedCod = P00DP5_A210PedCod[0];
               A1931TPedDsc = P00DP5_A1931TPedDsc[0];
               A1931TPedDsc = P00DP5_A1931TPedDsc[0];
               AV114TPedDsc = StringUtil.Trim( A1931TPedDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
         }
      }

      protected void S154( )
      {
         /* 'DOCUMENTO' Routine */
         returnInSub = false;
         /* Using cursor P00DP6 */
         pr_default.execute(4, new Object[] {AV80MVACod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A10ChoCod = P00DP6_A10ChoCod[0];
            A9UNTCod = P00DP6_A9UNTCod[0];
            A12DesGuia = P00DP6_A12DesGuia[0];
            A11DesTipGuia = P00DP6_A11DesTipGuia[0];
            A8DesCod = P00DP6_A8DesCod[0];
            A875DesFec = P00DP6_A875DesFec[0];
            A2002UNTDsc = P00DP6_A2002UNTDsc[0];
            A542ChoDsc = P00DP6_A542ChoDsc[0];
            A10ChoCod = P00DP6_A10ChoCod[0];
            A9UNTCod = P00DP6_A9UNTCod[0];
            A875DesFec = P00DP6_A875DesFec[0];
            A542ChoDsc = P00DP6_A542ChoDsc[0];
            A2002UNTDsc = P00DP6_A2002UNTDsc[0];
            AV31DesCod = A8DesCod;
            AV32DesFec = A875DesFec;
            AV120UNTDsc = A2002UNTDsc;
            AV17ChoDsc = A542ChoDsc;
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Using cursor P00DP7 */
         pr_default.execute(5, new Object[] {AV41DocTip, AV39DocNum, AV95Prodcod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A230DocMonCod = P00DP7_A230DocMonCod[0];
            A227DocVendCod = P00DP7_A227DocVendCod[0];
            A28ProdCod = P00DP7_A28ProdCod[0];
            A24DocNum = P00DP7_A24DocNum[0];
            n24DocNum = P00DP7_n24DocNum[0];
            A149TipCod = P00DP7_A149TipCod[0];
            A1233MonAbr = P00DP7_A1233MonAbr[0];
            n1233MonAbr = P00DP7_n1233MonAbr[0];
            A894DocDpre = P00DP7_A894DocDpre[0];
            A892DocDTot = P00DP7_A892DocDTot[0];
            A953DocVendDsc = P00DP7_A953DocVendDsc[0];
            A233DocItem = P00DP7_A233DocItem[0];
            A230DocMonCod = P00DP7_A230DocMonCod[0];
            A227DocVendCod = P00DP7_A227DocVendCod[0];
            A1233MonAbr = P00DP7_A1233MonAbr[0];
            n1233MonAbr = P00DP7_n1233MonAbr[0];
            A953DocVendDsc = P00DP7_A953DocVendDsc[0];
            AV77MonAbr = A1233MonAbr;
            AV35DocDPre = A894DocDpre;
            AV36DocDTot = A892DocDTot;
            AV42DocVendDsc = A953DocVendDsc;
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( ! (0==AV82MVAlmDestino) )
         {
            /* Using cursor P00DP8 */
            pr_default.execute(6, new Object[] {AV82MVAlmDestino});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A63AlmCod = P00DP8_A63AlmCod[0];
               A436AlmDsc = P00DP8_A436AlmDsc[0];
               AV8AlmacenDestino = StringUtil.Trim( A436AlmDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(6);
         }
         if ( ! (0==AV44EmpTCod) )
         {
            /* Using cursor P00DP9 */
            pr_default.execute(7, new Object[] {AV44EmpTCod});
            while ( (pr_default.getStatus(7) != 101) )
            {
               A17EmpTCod = P00DP9_A17EmpTCod[0];
               n17EmpTCod = P00DP9_n17EmpTCod[0];
               A964EmpTDsc = P00DP9_A964EmpTDsc[0];
               AV45EmpTDsc = StringUtil.Trim( A964EmpTDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(7);
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
         AV53Filename = "";
         AV46ErrorMessage = "";
         AV14Archivo = new GxFile(context.GetPhysicalPath());
         AV94Path = "";
         AV54FilenameOrigen = "";
         AV47ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         A15MVCliCod = "";
         A1287MVCCosto = "";
         A25MvAFec = DateTime.MinValue;
         A13MvATip = "";
         P00DP2_A13MvATip = new string[] {""} ;
         P00DP2_A1287MVCCosto = new string[] {""} ;
         P00DP2_A10ChoCod = new int[1] ;
         P00DP2_A16MVCliOrigen = new int[1] ;
         P00DP2_n16MVCliOrigen = new bool[] {false} ;
         P00DP2_A22MvAMov = new int[1] ;
         P00DP2_A15MVCliCod = new string[] {""} ;
         P00DP2_n15MVCliCod = new bool[] {false} ;
         P00DP2_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00DP2_A14MvACod = new string[] {""} ;
         A14MvACod = "";
         AV23CosCod = "";
         AV31DesCod = "";
         AV32DesFec = (DateTime)(DateTime.MinValue);
         AV24CosDsc = "";
         AV80MVACod = "";
         AV81MVAFec = DateTime.MinValue;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV83MVARef = "";
         AV85MVCliDsc = "";
         AV42DocVendDsc = "";
         AV114TPedDsc = "";
         AV87MVPedCod = "";
         AV41DocTip = "";
         AV39DocNum = "";
         AV97ProdDsc = "";
         AV119UniAbr = "";
         AV77MonAbr = "";
         AV9AlmacenOrigen = "";
         AV8AlmacenDestino = "";
         AV45EmpTDsc = "";
         AV120UNTDsc = "";
         AV17ChoDsc = "";
         P00DP3_A21MvAlm = new int[1] ;
         P00DP3_A49UniCod = new int[1] ;
         P00DP3_A16MVCliOrigen = new int[1] ;
         P00DP3_n16MVCliOrigen = new bool[] {false} ;
         P00DP3_A22MvAMov = new int[1] ;
         P00DP3_A15MVCliCod = new string[] {""} ;
         P00DP3_n15MVCliCod = new bool[] {false} ;
         P00DP3_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00DP3_A13MvATip = new string[] {""} ;
         P00DP3_A1287MVCCosto = new string[] {""} ;
         P00DP3_A1278MvARef = new string[] {""} ;
         P00DP3_A1290MVCliDsc = new string[] {""} ;
         P00DP3_A1370MVSts = new string[] {""} ;
         P00DP3_A20MVPedCod = new string[] {""} ;
         P00DP3_n20MVPedCod = new bool[] {false} ;
         P00DP3_A23DocTip = new string[] {""} ;
         P00DP3_n23DocTip = new bool[] {false} ;
         P00DP3_A24DocNum = new string[] {""} ;
         P00DP3_n24DocNum = new bool[] {false} ;
         P00DP3_A28ProdCod = new string[] {""} ;
         P00DP3_A55ProdDsc = new string[] {""} ;
         P00DP3_A1997UniAbr = new string[] {""} ;
         P00DP3_A1271MvAlmDsc = new string[] {""} ;
         P00DP3_A1270MVAlmDestino = new int[1] ;
         P00DP3_A17EmpTCod = new int[1] ;
         P00DP3_n17EmpTCod = new bool[] {false} ;
         P00DP3_A1248MvADCant = new decimal[1] ;
         P00DP3_A14MvACod = new string[] {""} ;
         P00DP3_A30MvADItem = new int[1] ;
         A1278MvARef = "";
         A1290MVCliDsc = "";
         A1370MVSts = "";
         A20MVPedCod = "";
         A23DocTip = "";
         A24DocNum = "";
         A28ProdCod = "";
         A55ProdDsc = "";
         A1997UniAbr = "";
         A1271MvAlmDsc = "";
         P00DP4_A79COSCod = new string[] {""} ;
         P00DP4_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         P00DP5_A212TPedCod = new int[1] ;
         P00DP5_A210PedCod = new string[] {""} ;
         P00DP5_A1931TPedDsc = new string[] {""} ;
         A210PedCod = "";
         A1931TPedDsc = "";
         P00DP6_A10ChoCod = new int[1] ;
         P00DP6_A9UNTCod = new int[1] ;
         P00DP6_A12DesGuia = new string[] {""} ;
         P00DP6_A11DesTipGuia = new string[] {""} ;
         P00DP6_A8DesCod = new string[] {""} ;
         P00DP6_A875DesFec = new DateTime[] {DateTime.MinValue} ;
         P00DP6_A2002UNTDsc = new string[] {""} ;
         P00DP6_A542ChoDsc = new string[] {""} ;
         A12DesGuia = "";
         A11DesTipGuia = "";
         A8DesCod = "";
         A875DesFec = (DateTime)(DateTime.MinValue);
         A2002UNTDsc = "";
         A542ChoDsc = "";
         P00DP7_A230DocMonCod = new int[1] ;
         P00DP7_A227DocVendCod = new int[1] ;
         P00DP7_A28ProdCod = new string[] {""} ;
         P00DP7_A24DocNum = new string[] {""} ;
         P00DP7_n24DocNum = new bool[] {false} ;
         P00DP7_A149TipCod = new string[] {""} ;
         P00DP7_A1233MonAbr = new string[] {""} ;
         P00DP7_n1233MonAbr = new bool[] {false} ;
         P00DP7_A894DocDpre = new decimal[1] ;
         P00DP7_A892DocDTot = new decimal[1] ;
         P00DP7_A953DocVendDsc = new string[] {""} ;
         P00DP7_A233DocItem = new long[1] ;
         A149TipCod = "";
         A1233MonAbr = "";
         A953DocVendDsc = "";
         P00DP8_A63AlmCod = new int[1] ;
         P00DP8_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         P00DP9_A17EmpTCod = new int[1] ;
         P00DP9_n17EmpTCod = new bool[] {false} ;
         P00DP9_A964EmpTDsc = new string[] {""} ;
         A964EmpTDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_resumenguiasremisionexcel__default(),
            new Object[][] {
                new Object[] {
               P00DP2_A13MvATip, P00DP2_A1287MVCCosto, P00DP2_A10ChoCod, P00DP2_A16MVCliOrigen, P00DP2_n16MVCliOrigen, P00DP2_A22MvAMov, P00DP2_A15MVCliCod, P00DP2_n15MVCliCod, P00DP2_A25MvAFec, P00DP2_A14MvACod
               }
               , new Object[] {
               P00DP3_A21MvAlm, P00DP3_A49UniCod, P00DP3_A16MVCliOrigen, P00DP3_n16MVCliOrigen, P00DP3_A22MvAMov, P00DP3_A15MVCliCod, P00DP3_n15MVCliCod, P00DP3_A25MvAFec, P00DP3_A13MvATip, P00DP3_A1287MVCCosto,
               P00DP3_A1278MvARef, P00DP3_A1290MVCliDsc, P00DP3_A1370MVSts, P00DP3_A20MVPedCod, P00DP3_n20MVPedCod, P00DP3_A23DocTip, P00DP3_n23DocTip, P00DP3_A24DocNum, P00DP3_n24DocNum, P00DP3_A28ProdCod,
               P00DP3_A55ProdDsc, P00DP3_A1997UniAbr, P00DP3_A1271MvAlmDsc, P00DP3_A1270MVAlmDestino, P00DP3_A17EmpTCod, P00DP3_n17EmpTCod, P00DP3_A1248MvADCant, P00DP3_A14MvACod, P00DP3_A30MvADItem
               }
               , new Object[] {
               P00DP4_A79COSCod, P00DP4_A761COSDsc
               }
               , new Object[] {
               P00DP5_A212TPedCod, P00DP5_A210PedCod, P00DP5_A1931TPedDsc
               }
               , new Object[] {
               P00DP6_A10ChoCod, P00DP6_A9UNTCod, P00DP6_A12DesGuia, P00DP6_A11DesTipGuia, P00DP6_A8DesCod, P00DP6_A875DesFec, P00DP6_A2002UNTDsc, P00DP6_A542ChoDsc
               }
               , new Object[] {
               P00DP7_A230DocMonCod, P00DP7_A227DocVendCod, P00DP7_A28ProdCod, P00DP7_A24DocNum, P00DP7_A149TipCod, P00DP7_A1233MonAbr, P00DP7_n1233MonAbr, P00DP7_A894DocDpre, P00DP7_A892DocDTot, P00DP7_A953DocVendDsc,
               P00DP7_A233DocItem
               }
               , new Object[] {
               P00DP8_A63AlmCod, P00DP8_A436AlmDsc
               }
               , new Object[] {
               P00DP9_A17EmpTCod, P00DP9_A964EmpTDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV121Flag ;
      private int AV75LinCod ;
      private int AV106SubLCod ;
      private int AV86MVCliOrigen ;
      private int AV79MovCod ;
      private int AV16ChoCod ;
      private int AV15CellRow ;
      private int AV55FirstColumn ;
      private int A22MvAMov ;
      private int A16MVCliOrigen ;
      private int A10ChoCod ;
      private int A21MvAlm ;
      private int A49UniCod ;
      private int A1270MVAlmDestino ;
      private int A17EmpTCod ;
      private int A30MvADItem ;
      private int AV82MVAlmDestino ;
      private int AV44EmpTCod ;
      private int A212TPedCod ;
      private int A9UNTCod ;
      private int A230DocMonCod ;
      private int A227DocVendCod ;
      private int A63AlmCod ;
      private long A233DocItem ;
      private decimal AV34DocDCan ;
      private decimal AV35DocDPre ;
      private decimal AV36DocDTot ;
      private decimal A1248MvADCant ;
      private decimal A894DocDpre ;
      private decimal A892DocDTot ;
      private string AV95Prodcod ;
      private string AV18CliCod ;
      private string AV84MVCCosto ;
      private string AV94Path ;
      private string scmdbuf ;
      private string A15MVCliCod ;
      private string A1287MVCCosto ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string AV23CosCod ;
      private string AV31DesCod ;
      private string AV24CosDsc ;
      private string AV80MVACod ;
      private string AV83MVARef ;
      private string AV85MVCliDsc ;
      private string AV42DocVendDsc ;
      private string AV114TPedDsc ;
      private string AV87MVPedCod ;
      private string AV41DocTip ;
      private string AV39DocNum ;
      private string AV97ProdDsc ;
      private string AV119UniAbr ;
      private string AV77MonAbr ;
      private string AV120UNTDsc ;
      private string AV17ChoDsc ;
      private string A1278MvARef ;
      private string A1290MVCliDsc ;
      private string A1370MVSts ;
      private string A20MVPedCod ;
      private string A23DocTip ;
      private string A24DocNum ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1997UniAbr ;
      private string A1271MvAlmDsc ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string A210PedCod ;
      private string A1931TPedDsc ;
      private string A12DesGuia ;
      private string A11DesTipGuia ;
      private string A8DesCod ;
      private string A2002UNTDsc ;
      private string A542ChoDsc ;
      private string A149TipCod ;
      private string A1233MonAbr ;
      private string A953DocVendDsc ;
      private string A436AlmDsc ;
      private DateTime AV32DesFec ;
      private DateTime GXt_dtime1 ;
      private DateTime A875DesFec ;
      private DateTime AV49FDesde ;
      private DateTime AV52FHasta ;
      private DateTime A25MvAFec ;
      private DateTime AV81MVAFec ;
      private bool returnInSub ;
      private bool BRKDP2 ;
      private bool n16MVCliOrigen ;
      private bool n15MVCliCod ;
      private bool n20MVPedCod ;
      private bool n23DocTip ;
      private bool n24DocNum ;
      private bool n17EmpTCod ;
      private bool n1233MonAbr ;
      private string AV53Filename ;
      private string AV46ErrorMessage ;
      private string AV54FilenameOrigen ;
      private string AV9AlmacenOrigen ;
      private string AV8AlmacenDestino ;
      private string AV45EmpTDsc ;
      private string A964EmpTDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private string aP2_Prodcod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private short aP5_Flag ;
      private string aP6_CliCod ;
      private int aP7_MVCliOrigen ;
      private int aP8_MovCod ;
      private string aP9_MVCCosto ;
      private int aP10_ChoCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00DP2_A13MvATip ;
      private string[] P00DP2_A1287MVCCosto ;
      private int[] P00DP2_A10ChoCod ;
      private int[] P00DP2_A16MVCliOrigen ;
      private bool[] P00DP2_n16MVCliOrigen ;
      private int[] P00DP2_A22MvAMov ;
      private string[] P00DP2_A15MVCliCod ;
      private bool[] P00DP2_n15MVCliCod ;
      private DateTime[] P00DP2_A25MvAFec ;
      private string[] P00DP2_A14MvACod ;
      private int[] P00DP3_A21MvAlm ;
      private int[] P00DP3_A49UniCod ;
      private int[] P00DP3_A16MVCliOrigen ;
      private bool[] P00DP3_n16MVCliOrigen ;
      private int[] P00DP3_A22MvAMov ;
      private string[] P00DP3_A15MVCliCod ;
      private bool[] P00DP3_n15MVCliCod ;
      private DateTime[] P00DP3_A25MvAFec ;
      private string[] P00DP3_A13MvATip ;
      private string[] P00DP3_A1287MVCCosto ;
      private string[] P00DP3_A1278MvARef ;
      private string[] P00DP3_A1290MVCliDsc ;
      private string[] P00DP3_A1370MVSts ;
      private string[] P00DP3_A20MVPedCod ;
      private bool[] P00DP3_n20MVPedCod ;
      private string[] P00DP3_A23DocTip ;
      private bool[] P00DP3_n23DocTip ;
      private string[] P00DP3_A24DocNum ;
      private bool[] P00DP3_n24DocNum ;
      private string[] P00DP3_A28ProdCod ;
      private string[] P00DP3_A55ProdDsc ;
      private string[] P00DP3_A1997UniAbr ;
      private string[] P00DP3_A1271MvAlmDsc ;
      private int[] P00DP3_A1270MVAlmDestino ;
      private int[] P00DP3_A17EmpTCod ;
      private bool[] P00DP3_n17EmpTCod ;
      private decimal[] P00DP3_A1248MvADCant ;
      private string[] P00DP3_A14MvACod ;
      private int[] P00DP3_A30MvADItem ;
      private string[] P00DP4_A79COSCod ;
      private string[] P00DP4_A761COSDsc ;
      private int[] P00DP5_A212TPedCod ;
      private string[] P00DP5_A210PedCod ;
      private string[] P00DP5_A1931TPedDsc ;
      private int[] P00DP6_A10ChoCod ;
      private int[] P00DP6_A9UNTCod ;
      private string[] P00DP6_A12DesGuia ;
      private string[] P00DP6_A11DesTipGuia ;
      private string[] P00DP6_A8DesCod ;
      private DateTime[] P00DP6_A875DesFec ;
      private string[] P00DP6_A2002UNTDsc ;
      private string[] P00DP6_A542ChoDsc ;
      private int[] P00DP7_A230DocMonCod ;
      private int[] P00DP7_A227DocVendCod ;
      private string[] P00DP7_A28ProdCod ;
      private string[] P00DP7_A24DocNum ;
      private bool[] P00DP7_n24DocNum ;
      private string[] P00DP7_A149TipCod ;
      private string[] P00DP7_A1233MonAbr ;
      private bool[] P00DP7_n1233MonAbr ;
      private decimal[] P00DP7_A894DocDpre ;
      private decimal[] P00DP7_A892DocDTot ;
      private string[] P00DP7_A953DocVendDsc ;
      private long[] P00DP7_A233DocItem ;
      private int[] P00DP8_A63AlmCod ;
      private string[] P00DP8_A436AlmDsc ;
      private int[] P00DP9_A17EmpTCod ;
      private bool[] P00DP9_n17EmpTCod ;
      private string[] P00DP9_A964EmpTDsc ;
      private string aP11_Filename ;
      private string aP12_ErrorMessage ;
      private ExcelDocumentI AV47ExcelDocument ;
      private GxFile AV14Archivo ;
   }

   public class r_resumenguiasremisionexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DP2( IGxContext context ,
                                             string AV18CliCod ,
                                             int AV79MovCod ,
                                             int AV86MVCliOrigen ,
                                             string AV84MVCCosto ,
                                             int AV16ChoCod ,
                                             string A15MVCliCod ,
                                             int A22MvAMov ,
                                             int A16MVCliOrigen ,
                                             string A1287MVCCosto ,
                                             int A10ChoCod ,
                                             DateTime A25MvAFec ,
                                             DateTime AV49FDesde ,
                                             DateTime AV52FHasta ,
                                             string A13MvATip )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [MvATip], [MVCCosto], [ChoCod], [MVCliOrigen], [MvAMov], [MVCliCod] AS MVCliCod, [MvAFec], [MvACod] FROM [AGUIAS]";
         AddWhere(sWhereString, "([MvAFec] >= @AV49FDesde)");
         AddWhere(sWhereString, "([MvAFec] <= @AV52FHasta)");
         AddWhere(sWhereString, "([MvATip] = 'REM')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18CliCod)) )
         {
            AddWhere(sWhereString, "([MVCliCod] = @AV18CliCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV79MovCod) )
         {
            AddWhere(sWhereString, "([MvAMov] = @AV79MovCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV86MVCliOrigen) )
         {
            AddWhere(sWhereString, "([MVCliOrigen] = @AV86MVCliOrigen)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84MVCCosto)) )
         {
            AddWhere(sWhereString, "([MVCCosto] = @AV84MVCCosto)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV16ChoCod) )
         {
            AddWhere(sWhereString, "([ChoCod] = @AV16ChoCod)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MVCCosto], [MvATip]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00DP3( IGxContext context ,
                                             string AV18CliCod ,
                                             int AV79MovCod ,
                                             int AV86MVCliOrigen ,
                                             string A15MVCliCod ,
                                             int A22MvAMov ,
                                             int A16MVCliOrigen ,
                                             DateTime A25MvAFec ,
                                             DateTime AV49FDesde ,
                                             DateTime AV52FHasta ,
                                             string A1287MVCCosto ,
                                             string AV23CosCod ,
                                             string A13MvATip )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T4.[MvAlm] AS MvAlm, T2.[UniCod], T4.[MVCliOrigen], T4.[MvAMov], T4.[MVCliCod] AS MVCliCod, T4.[MvAFec], T1.[MvATip], T4.[MVCCosto], T4.[MvARef], T6.[CliDsc] AS MVCliDsc, T4.[MVSts], T4.[MVPedCod], T4.[DocTip], T4.[DocNum], T1.[ProdCod], T2.[ProdDsc], T3.[UniAbr], T5.[AlmDsc] AS MvAlmDsc, T4.[MVAlmDestino], T4.[EmpTCod], T1.[MvADCant], T1.[MvACod], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [AGUIAS] T4 ON T4.[MvATip] = T1.[MvATip] AND T4.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T5 ON T5.[AlmCod] = T4.[MvAlm]) LEFT JOIN [CLCLIENTES] T6 ON T6.[CliCod] = T4.[MVCliCod])";
         AddWhere(sWhereString, "(T1.[MvATip] = 'REM')");
         AddWhere(sWhereString, "(T4.[MvAFec] >= @AV49FDesde)");
         AddWhere(sWhereString, "(T4.[MvAFec] <= @AV52FHasta)");
         AddWhere(sWhereString, "(T4.[MVCCosto] = @AV23CosCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18CliCod)) )
         {
            AddWhere(sWhereString, "(T4.[MVCliCod] = @AV18CliCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV79MovCod) )
         {
            AddWhere(sWhereString, "(T4.[MvAMov] = @AV79MovCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV86MVCliOrigen) )
         {
            AddWhere(sWhereString, "(T4.[MVCliOrigen] = @AV86MVCliOrigen)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[MvATip], T1.[MvACod]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00DP2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] );
               case 1 :
                     return conditional_P00DP3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
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
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DP4;
          prmP00DP4 = new Object[] {
          new ParDef("@AV23CosCod",GXType.NChar,10,0)
          };
          Object[] prmP00DP5;
          prmP00DP5 = new Object[] {
          new ParDef("@AV87MVPedCod",GXType.NChar,10,0)
          };
          Object[] prmP00DP6;
          prmP00DP6 = new Object[] {
          new ParDef("@AV80MVACod",GXType.NChar,12,0)
          };
          Object[] prmP00DP7;
          prmP00DP7 = new Object[] {
          new ParDef("@AV41DocTip",GXType.NChar,3,0) ,
          new ParDef("@AV39DocNum",GXType.NChar,15,0) ,
          new ParDef("@AV95Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00DP8;
          prmP00DP8 = new Object[] {
          new ParDef("@AV82MVAlmDestino",GXType.Int32,6,0)
          };
          Object[] prmP00DP9;
          prmP00DP9 = new Object[] {
          new ParDef("@AV44EmpTCod",GXType.Int32,6,0)
          };
          Object[] prmP00DP2;
          prmP00DP2 = new Object[] {
          new ParDef("@AV49FDesde",GXType.Date,8,0) ,
          new ParDef("@AV52FHasta",GXType.Date,8,0) ,
          new ParDef("@AV18CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV79MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV86MVCliOrigen",GXType.Int32,6,0) ,
          new ParDef("@AV84MVCCosto",GXType.NChar,10,0) ,
          new ParDef("@AV16ChoCod",GXType.Int32,6,0)
          };
          Object[] prmP00DP3;
          prmP00DP3 = new Object[] {
          new ParDef("@AV49FDesde",GXType.Date,8,0) ,
          new ParDef("@AV52FHasta",GXType.Date,8,0) ,
          new ParDef("@AV23CosCod",GXType.NChar,10,0) ,
          new ParDef("@AV18CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV79MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV86MVCliOrigen",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DP2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DP2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DP3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DP3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DP4", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV23CosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DP4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DP5", "SELECT T1.[TPedCod], T1.[PedCod], T2.[TPedDsc] FROM ([CLPEDIDOS] T1 INNER JOIN [CTIPPEDIDO] T2 ON T2.[TPedCod] = T1.[TPedCod]) WHERE T1.[PedCod] = @AV87MVPedCod ORDER BY T1.[PedCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DP5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DP6", "SELECT T2.[ChoCod], T2.[UNTCod], T1.[DesGuia], T1.[DesTipGuia], T1.[DesCod], T2.[DesFec], T4.[UNTDsc], T3.[ChoDsc] FROM ((([ADESPACHODET] T1 INNER JOIN [ADESPACHO] T2 ON T2.[DesCod] = T1.[DesCod]) INNER JOIN [CCHOFERES] T3 ON T3.[ChoCod] = T2.[ChoCod]) INNER JOIN [AUNITRANSP] T4 ON T4.[UNTCod] = T2.[UNTCod]) WHERE T1.[DesTipGuia] = 'REM' and T1.[DesGuia] = @AV80MVACod ORDER BY T1.[DesTipGuia], T1.[DesGuia] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DP6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DP7", "SELECT T2.[DocMonCod] AS DocMonCod, T2.[DocVendCod] AS DocVendCod, T1.[ProdCod], T1.[DocNum], T1.[TipCod], T3.[MonAbr], T1.[DocDpre], T1.[DocDTot], T4.[VenDsc] AS DocVendDsc, T1.[DocItem] FROM ((([CLVENTASDET] T1 INNER JOIN [CLVENTAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T2.[DocMonCod]) INNER JOIN [CVENDEDORES] T4 ON T4.[VenCod] = T2.[DocVendCod]) WHERE (T1.[TipCod] = @AV41DocTip and T1.[DocNum] = @AV39DocNum) AND (T1.[ProdCod] = @AV95Prodcod) ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DP7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DP8", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV82MVAlmDestino ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DP8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DP9", "SELECT [EmpTCod], [EmpTDsc] FROM [CEMPTRANSPORTE] WHERE [EmpTCod] = @AV44EmpTCod ORDER BY [EmpTCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DP9,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 12);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                ((string[]) buf[9])[0] = rslt.getString(8, 10);
                ((string[]) buf[10])[0] = rslt.getString(9, 20);
                ((string[]) buf[11])[0] = rslt.getString(10, 100);
                ((string[]) buf[12])[0] = rslt.getString(11, 1);
                ((string[]) buf[13])[0] = rslt.getString(12, 10);
                ((bool[]) buf[14])[0] = rslt.wasNull(12);
                ((string[]) buf[15])[0] = rslt.getString(13, 3);
                ((bool[]) buf[16])[0] = rslt.wasNull(13);
                ((string[]) buf[17])[0] = rslt.getString(14, 12);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((string[]) buf[19])[0] = rslt.getString(15, 15);
                ((string[]) buf[20])[0] = rslt.getString(16, 100);
                ((string[]) buf[21])[0] = rslt.getString(17, 5);
                ((string[]) buf[22])[0] = rslt.getString(18, 100);
                ((int[]) buf[23])[0] = rslt.getInt(19);
                ((int[]) buf[24])[0] = rslt.getInt(20);
                ((bool[]) buf[25])[0] = rslt.wasNull(20);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(21);
                ((string[]) buf[27])[0] = rslt.getString(22, 12);
                ((int[]) buf[28])[0] = rslt.getInt(23);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 12);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
