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
   public class r_stockactualxlotesexcel : GXProcedure
   {
      public r_stockactualxlotesexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_stockactualxlotesexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SubLCod ,
                           ref int aP2_FamCod ,
                           ref int aP3_AlmCod ,
                           ref string aP4_Prodcod ,
                           ref short aP5_nOrden ,
                           out string aP6_Filename ,
                           out string aP7_ErrorMessage )
      {
         this.AV77LinCod = aP0_LinCod;
         this.AV78SubLCod = aP1_SubLCod;
         this.AV79FamCod = aP2_FamCod;
         this.AV80AlmCod = aP3_AlmCod;
         this.AV81Prodcod = aP4_Prodcod;
         this.AV83nOrden = aP5_nOrden;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV77LinCod;
         aP1_SubLCod=this.AV78SubLCod;
         aP2_FamCod=this.AV79FamCod;
         aP3_AlmCod=this.AV80AlmCod;
         aP4_Prodcod=this.AV81Prodcod;
         aP5_nOrden=this.AV83nOrden;
         aP6_Filename=this.AV10Filename;
         aP7_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref int aP0_LinCod ,
                                ref int aP1_SubLCod ,
                                ref int aP2_FamCod ,
                                ref int aP3_AlmCod ,
                                ref string aP4_Prodcod ,
                                ref short aP5_nOrden ,
                                out string aP6_Filename )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_FamCod, ref aP3_AlmCod, ref aP4_Prodcod, ref aP5_nOrden, out aP6_Filename, out aP7_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCod ,
                                 ref string aP4_Prodcod ,
                                 ref short aP5_nOrden ,
                                 out string aP6_Filename ,
                                 out string aP7_ErrorMessage )
      {
         r_stockactualxlotesexcel objr_stockactualxlotesexcel;
         objr_stockactualxlotesexcel = new r_stockactualxlotesexcel();
         objr_stockactualxlotesexcel.AV77LinCod = aP0_LinCod;
         objr_stockactualxlotesexcel.AV78SubLCod = aP1_SubLCod;
         objr_stockactualxlotesexcel.AV79FamCod = aP2_FamCod;
         objr_stockactualxlotesexcel.AV80AlmCod = aP3_AlmCod;
         objr_stockactualxlotesexcel.AV81Prodcod = aP4_Prodcod;
         objr_stockactualxlotesexcel.AV83nOrden = aP5_nOrden;
         objr_stockactualxlotesexcel.AV10Filename = "" ;
         objr_stockactualxlotesexcel.AV11ErrorMessage = "" ;
         objr_stockactualxlotesexcel.context.SetSubmitInitialConfig(context);
         objr_stockactualxlotesexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_stockactualxlotesexcel);
         aP0_LinCod=this.AV77LinCod;
         aP1_SubLCod=this.AV78SubLCod;
         aP2_FamCod=this.AV79FamCod;
         aP3_AlmCod=this.AV80AlmCod;
         aP4_Prodcod=this.AV81Prodcod;
         aP5_nOrden=this.AV83nOrden;
         aP6_Filename=this.AV10Filename;
         aP7_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_stockactualxlotesexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasStockActualxLotes.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasStockActualxLotes.xlsx";
         AV10Filename = "Excel/StockActualxLotes" + ".xlsx";
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
         AV14CellRow = 4;
         AV15FirstColumn = 0;
         AV93I = 1;
         /* Using cursor P00DM2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1914TipLSts = P00DM2_A1914TipLSts[0];
            A1912TipLDsc = P00DM2_A1912TipLDsc[0];
            A202TipLCod = P00DM2_A202TipLCod[0];
            AV13ExcelDocument.get_Cells(AV14CellRow, 6+AV93I, 1, 1).Text = StringUtil.Trim( A1912TipLDsc);
            AV93I = (short)(AV93I+1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV14CellRow = 5;
         AV15FirstColumn = 0;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV80AlmCod ,
                                              AV77LinCod ,
                                              AV78SubLCod ,
                                              AV79FamCod ,
                                              AV81Prodcod ,
                                              A63AlmCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A28ProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00DM3 */
         pr_default.execute(1, new Object[] {AV80AlmCod, AV77LinCod, AV78SubLCod, AV79FamCod, AV81Prodcod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKDM3 = false;
            A28ProdCod = P00DM3_A28ProdCod[0];
            A63AlmCod = P00DM3_A63AlmCod[0];
            A50FamCod = P00DM3_A50FamCod[0];
            n50FamCod = P00DM3_n50FamCod[0];
            A51SublCod = P00DM3_A51SublCod[0];
            n51SublCod = P00DM3_n51SublCod[0];
            A52LinCod = P00DM3_A52LinCod[0];
            A436AlmDsc = P00DM3_A436AlmDsc[0];
            A50FamCod = P00DM3_A50FamCod[0];
            n50FamCod = P00DM3_n50FamCod[0];
            A51SublCod = P00DM3_A51SublCod[0];
            n51SublCod = P00DM3_n51SublCod[0];
            A52LinCod = P00DM3_A52LinCod[0];
            A436AlmDsc = P00DM3_A436AlmDsc[0];
            while ( (pr_default.getStatus(1) != 101) && ( P00DM3_A63AlmCod[0] == A63AlmCod ) )
            {
               BRKDM3 = false;
               A28ProdCod = P00DM3_A28ProdCod[0];
               BRKDM3 = true;
               pr_default.readNext(1);
            }
            AV80AlmCod = A63AlmCod;
            AV88AlmDsc = A436AlmDsc;
            AV84ITemProd = 1;
            /* Execute user subroutine: 'DETALLES' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               this.cleanup();
               if (true) return;
            }
            AV14CellRow = (int)(AV14CellRow+1);
            if ( ! BRKDM3 )
            {
               BRKDM3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         /* 'DETALLES' Routine */
         returnInSub = false;
         if ( AV83nOrden == 1 )
         {
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV77LinCod ,
                                                 AV78SubLCod ,
                                                 AV79FamCod ,
                                                 AV81Prodcod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A28ProdCod ,
                                                 A1158LinStk ,
                                                 AV80AlmCod ,
                                                 A63AlmCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor P00DM4 */
            pr_default.execute(2, new Object[] {AV80AlmCod, AV77LinCod, AV78SubLCod, AV79FamCod, AV81Prodcod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A49UniCod = P00DM4_A49UniCod[0];
               A1158LinStk = P00DM4_A1158LinStk[0];
               A28ProdCod = P00DM4_A28ProdCod[0];
               A50FamCod = P00DM4_A50FamCod[0];
               n50FamCod = P00DM4_n50FamCod[0];
               A51SublCod = P00DM4_A51SublCod[0];
               n51SublCod = P00DM4_n51SublCod[0];
               A52LinCod = P00DM4_A52LinCod[0];
               A63AlmCod = P00DM4_A63AlmCod[0];
               A55ProdDsc = P00DM4_A55ProdDsc[0];
               A1997UniAbr = P00DM4_A1997UniAbr[0];
               A1154LinRef1 = P00DM4_A1154LinRef1[0];
               A1882StkSal = P00DM4_A1882StkSal[0];
               A1881StkIng = P00DM4_A1881StkIng[0];
               A1706ProdRef10 = P00DM4_A1706ProdRef10[0];
               A1714ProdRef9 = P00DM4_A1714ProdRef9[0];
               A1713ProdRef8 = P00DM4_A1713ProdRef8[0];
               A1712ProdRef7 = P00DM4_A1712ProdRef7[0];
               A1711ProdRef6 = P00DM4_A1711ProdRef6[0];
               A1710ProdRef5 = P00DM4_A1710ProdRef5[0];
               A1709ProdRef4 = P00DM4_A1709ProdRef4[0];
               A1708ProdRef3 = P00DM4_A1708ProdRef3[0];
               A1707ProdRef2 = P00DM4_A1707ProdRef2[0];
               A1705ProdRef1 = P00DM4_A1705ProdRef1[0];
               A49UniCod = P00DM4_A49UniCod[0];
               A50FamCod = P00DM4_A50FamCod[0];
               n50FamCod = P00DM4_n50FamCod[0];
               A51SublCod = P00DM4_A51SublCod[0];
               n51SublCod = P00DM4_n51SublCod[0];
               A52LinCod = P00DM4_A52LinCod[0];
               A55ProdDsc = P00DM4_A55ProdDsc[0];
               A1706ProdRef10 = P00DM4_A1706ProdRef10[0];
               A1714ProdRef9 = P00DM4_A1714ProdRef9[0];
               A1713ProdRef8 = P00DM4_A1713ProdRef8[0];
               A1712ProdRef7 = P00DM4_A1712ProdRef7[0];
               A1711ProdRef6 = P00DM4_A1711ProdRef6[0];
               A1710ProdRef5 = P00DM4_A1710ProdRef5[0];
               A1709ProdRef4 = P00DM4_A1709ProdRef4[0];
               A1708ProdRef3 = P00DM4_A1708ProdRef3[0];
               A1707ProdRef2 = P00DM4_A1707ProdRef2[0];
               A1705ProdRef1 = P00DM4_A1705ProdRef1[0];
               A1997UniAbr = P00DM4_A1997UniAbr[0];
               A1158LinStk = P00DM4_A1158LinStk[0];
               A1154LinRef1 = P00DM4_A1154LinRef1[0];
               A1880StkAct = (decimal)(A1881StkIng-A1882StkSal);
               A1715ProdReferencias = StringUtil.Trim( A1705ProdRef1) + " " + StringUtil.Trim( A1707ProdRef2) + " " + StringUtil.Trim( A1708ProdRef3) + " " + StringUtil.Trim( A1709ProdRef4) + " " + StringUtil.Trim( A1710ProdRef5) + " " + StringUtil.Trim( A1711ProdRef6) + " " + StringUtil.Trim( A1712ProdRef7) + " " + StringUtil.Trim( A1713ProdRef8) + " " + StringUtil.Trim( A1714ProdRef9) + " " + StringUtil.Trim( A1706ProdRef10);
               AV89Codigo = A28ProdCod;
               AV90Producto = A55ProdDsc;
               AV91UniAbr = StringUtil.Trim( A1997UniAbr);
               AV92ProdReferencias = A1715ProdReferencias;
               AV85StkSal = A1882StkSal;
               AV86StkIng = A1881StkIng;
               AV87StkAct = A1880StkAct;
               AV93I = 1;
               AV94Precio = (short)(0.0000m);
               AV96LinRef1 = StringUtil.Trim( A1154LinRef1);
               if ( DateTimeUtil.ResetTime ( AV82FDesde ) != DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
               {
                  new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV89Codigo, ref  AV80AlmCod, ref  AV82FDesde, out  AV86StkIng, out  AV85StkSal, out  AV87StkAct) ;
               }
               if ( ! (Convert.ToDecimal(0)==AV87StkAct) )
               {
                  /* Execute user subroutine: 'LOTES' */
                  S135 ();
                  if ( returnInSub )
                  {
                     pr_default.close(2);
                     returnInSub = true;
                     if (true) return;
                  }
                  /* Execute user subroutine: 'DETALLE' */
                  S145 ();
                  if ( returnInSub )
                  {
                     pr_default.close(2);
                     returnInSub = true;
                     if (true) return;
                  }
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV84ITemProd = (long)(AV84ITemProd+1);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         else
         {
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV77LinCod ,
                                                 AV78SubLCod ,
                                                 AV79FamCod ,
                                                 AV81Prodcod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A28ProdCod ,
                                                 A1158LinStk ,
                                                 AV80AlmCod ,
                                                 A63AlmCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor P00DM5 */
            pr_default.execute(3, new Object[] {AV80AlmCod, AV77LinCod, AV78SubLCod, AV79FamCod, AV81Prodcod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A49UniCod = P00DM5_A49UniCod[0];
               A63AlmCod = P00DM5_A63AlmCod[0];
               A1158LinStk = P00DM5_A1158LinStk[0];
               A28ProdCod = P00DM5_A28ProdCod[0];
               A50FamCod = P00DM5_A50FamCod[0];
               n50FamCod = P00DM5_n50FamCod[0];
               A51SublCod = P00DM5_A51SublCod[0];
               n51SublCod = P00DM5_n51SublCod[0];
               A52LinCod = P00DM5_A52LinCod[0];
               A1997UniAbr = P00DM5_A1997UniAbr[0];
               A1154LinRef1 = P00DM5_A1154LinRef1[0];
               A55ProdDsc = P00DM5_A55ProdDsc[0];
               A1882StkSal = P00DM5_A1882StkSal[0];
               A1881StkIng = P00DM5_A1881StkIng[0];
               A1706ProdRef10 = P00DM5_A1706ProdRef10[0];
               A1714ProdRef9 = P00DM5_A1714ProdRef9[0];
               A1713ProdRef8 = P00DM5_A1713ProdRef8[0];
               A1712ProdRef7 = P00DM5_A1712ProdRef7[0];
               A1711ProdRef6 = P00DM5_A1711ProdRef6[0];
               A1710ProdRef5 = P00DM5_A1710ProdRef5[0];
               A1709ProdRef4 = P00DM5_A1709ProdRef4[0];
               A1708ProdRef3 = P00DM5_A1708ProdRef3[0];
               A1707ProdRef2 = P00DM5_A1707ProdRef2[0];
               A1705ProdRef1 = P00DM5_A1705ProdRef1[0];
               A49UniCod = P00DM5_A49UniCod[0];
               A50FamCod = P00DM5_A50FamCod[0];
               n50FamCod = P00DM5_n50FamCod[0];
               A51SublCod = P00DM5_A51SublCod[0];
               n51SublCod = P00DM5_n51SublCod[0];
               A52LinCod = P00DM5_A52LinCod[0];
               A55ProdDsc = P00DM5_A55ProdDsc[0];
               A1706ProdRef10 = P00DM5_A1706ProdRef10[0];
               A1714ProdRef9 = P00DM5_A1714ProdRef9[0];
               A1713ProdRef8 = P00DM5_A1713ProdRef8[0];
               A1712ProdRef7 = P00DM5_A1712ProdRef7[0];
               A1711ProdRef6 = P00DM5_A1711ProdRef6[0];
               A1710ProdRef5 = P00DM5_A1710ProdRef5[0];
               A1709ProdRef4 = P00DM5_A1709ProdRef4[0];
               A1708ProdRef3 = P00DM5_A1708ProdRef3[0];
               A1707ProdRef2 = P00DM5_A1707ProdRef2[0];
               A1705ProdRef1 = P00DM5_A1705ProdRef1[0];
               A1997UniAbr = P00DM5_A1997UniAbr[0];
               A1158LinStk = P00DM5_A1158LinStk[0];
               A1154LinRef1 = P00DM5_A1154LinRef1[0];
               A1880StkAct = (decimal)(A1881StkIng-A1882StkSal);
               A1715ProdReferencias = StringUtil.Trim( A1705ProdRef1) + " " + StringUtil.Trim( A1707ProdRef2) + " " + StringUtil.Trim( A1708ProdRef3) + " " + StringUtil.Trim( A1709ProdRef4) + " " + StringUtil.Trim( A1710ProdRef5) + " " + StringUtil.Trim( A1711ProdRef6) + " " + StringUtil.Trim( A1712ProdRef7) + " " + StringUtil.Trim( A1713ProdRef8) + " " + StringUtil.Trim( A1714ProdRef9) + " " + StringUtil.Trim( A1706ProdRef10);
               AV89Codigo = A28ProdCod;
               AV90Producto = A55ProdDsc;
               AV91UniAbr = StringUtil.Trim( A1997UniAbr);
               AV92ProdReferencias = A1715ProdReferencias;
               AV85StkSal = A1882StkSal;
               AV86StkIng = A1881StkIng;
               AV87StkAct = A1880StkAct;
               AV93I = 1;
               AV94Precio = (short)(0.0000m);
               AV96LinRef1 = StringUtil.Trim( A1154LinRef1);
               if ( DateTimeUtil.ResetTime ( AV82FDesde ) != DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
               {
                  new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV89Codigo, ref  AV80AlmCod, ref  AV82FDesde, out  AV86StkIng, out  AV85StkSal, out  AV87StkAct) ;
               }
               if ( ! (Convert.ToDecimal(0)==AV87StkAct) )
               {
                  /* Execute user subroutine: 'LOTES' */
                  S135 ();
                  if ( returnInSub )
                  {
                     pr_default.close(3);
                     returnInSub = true;
                     if (true) return;
                  }
                  /* Execute user subroutine: 'DETALLE' */
                  S145 ();
                  if ( returnInSub )
                  {
                     pr_default.close(3);
                     returnInSub = true;
                     if (true) return;
                  }
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV84ITemProd = (long)(AV84ITemProd+1);
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
      }

      protected void S145( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV88AlmDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV89Codigo);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV90Producto);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV91UniAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV87StkAct);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = AV92ProdReferencias;
      }

      protected void S135( )
      {
         /* 'LOTES' Routine */
         returnInSub = false;
         AV108Referencia = "";
         /* Using cursor P00DM6 */
         pr_default.execute(4, new Object[] {AV80AlmCod, AV89Codigo});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A1883StkDAct = P00DM6_A1883StkDAct[0];
            A28ProdCod = P00DM6_A28ProdCod[0];
            A63AlmCod = P00DM6_A63AlmCod[0];
            A64StkRef1 = P00DM6_A64StkRef1[0];
            A1888StkRef2 = P00DM6_A1888StkRef2[0];
            A1889StkRef3 = P00DM6_A1889StkRef3[0];
            A1890StkRef4 = P00DM6_A1890StkRef4[0];
            A1884StkDIng = P00DM6_A1884StkDIng[0];
            A1885StkDSal = P00DM6_A1885StkDSal[0];
            AV97StkRef1 = StringUtil.Trim( A64StkRef1);
            AV98StkRef2 = StringUtil.Trim( A1888StkRef2);
            AV95StkRef3 = StringUtil.Trim( A1889StkRef3);
            AV99StkRef4 = StringUtil.Trim( A1890StkRef4);
            AV100StkDAct = A1883StkDAct;
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV88AlmDsc);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV89Codigo);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV90Producto);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV91UniAbr);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Number = (double)(AV100StkDAct);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV97StkRef1);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV98StkRef2);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV95StkRef3);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Text = StringUtil.Trim( AV99StkRef4);
            AV14CellRow = (int)(AV14CellRow+1);
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
         AV72Archivo = new GxFile(context.GetPhysicalPath());
         AV71Path = "";
         AV70FilenameOrigen = "";
         AV13ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P00DM2_A1914TipLSts = new short[1] ;
         P00DM2_A1912TipLDsc = new string[] {""} ;
         P00DM2_A202TipLCod = new int[1] ;
         A1912TipLDsc = "";
         A28ProdCod = "";
         P00DM3_A28ProdCod = new string[] {""} ;
         P00DM3_A63AlmCod = new int[1] ;
         P00DM3_A50FamCod = new int[1] ;
         P00DM3_n50FamCod = new bool[] {false} ;
         P00DM3_A51SublCod = new int[1] ;
         P00DM3_n51SublCod = new bool[] {false} ;
         P00DM3_A52LinCod = new int[1] ;
         P00DM3_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         AV88AlmDsc = "";
         P00DM4_A49UniCod = new int[1] ;
         P00DM4_A1158LinStk = new short[1] ;
         P00DM4_A28ProdCod = new string[] {""} ;
         P00DM4_A50FamCod = new int[1] ;
         P00DM4_n50FamCod = new bool[] {false} ;
         P00DM4_A51SublCod = new int[1] ;
         P00DM4_n51SublCod = new bool[] {false} ;
         P00DM4_A52LinCod = new int[1] ;
         P00DM4_A63AlmCod = new int[1] ;
         P00DM4_A55ProdDsc = new string[] {""} ;
         P00DM4_A1997UniAbr = new string[] {""} ;
         P00DM4_A1154LinRef1 = new string[] {""} ;
         P00DM4_A1882StkSal = new decimal[1] ;
         P00DM4_A1881StkIng = new decimal[1] ;
         P00DM4_A1706ProdRef10 = new string[] {""} ;
         P00DM4_A1714ProdRef9 = new string[] {""} ;
         P00DM4_A1713ProdRef8 = new string[] {""} ;
         P00DM4_A1712ProdRef7 = new string[] {""} ;
         P00DM4_A1711ProdRef6 = new string[] {""} ;
         P00DM4_A1710ProdRef5 = new string[] {""} ;
         P00DM4_A1709ProdRef4 = new string[] {""} ;
         P00DM4_A1708ProdRef3 = new string[] {""} ;
         P00DM4_A1707ProdRef2 = new string[] {""} ;
         P00DM4_A1705ProdRef1 = new string[] {""} ;
         A55ProdDsc = "";
         A1997UniAbr = "";
         A1154LinRef1 = "";
         A1706ProdRef10 = "";
         A1714ProdRef9 = "";
         A1713ProdRef8 = "";
         A1712ProdRef7 = "";
         A1711ProdRef6 = "";
         A1710ProdRef5 = "";
         A1709ProdRef4 = "";
         A1708ProdRef3 = "";
         A1707ProdRef2 = "";
         A1705ProdRef1 = "";
         A1715ProdReferencias = "";
         AV89Codigo = "";
         AV90Producto = "";
         AV91UniAbr = "";
         AV92ProdReferencias = "";
         AV96LinRef1 = "";
         AV82FDesde = DateTime.MinValue;
         P00DM5_A49UniCod = new int[1] ;
         P00DM5_A63AlmCod = new int[1] ;
         P00DM5_A1158LinStk = new short[1] ;
         P00DM5_A28ProdCod = new string[] {""} ;
         P00DM5_A50FamCod = new int[1] ;
         P00DM5_n50FamCod = new bool[] {false} ;
         P00DM5_A51SublCod = new int[1] ;
         P00DM5_n51SublCod = new bool[] {false} ;
         P00DM5_A52LinCod = new int[1] ;
         P00DM5_A1997UniAbr = new string[] {""} ;
         P00DM5_A1154LinRef1 = new string[] {""} ;
         P00DM5_A55ProdDsc = new string[] {""} ;
         P00DM5_A1882StkSal = new decimal[1] ;
         P00DM5_A1881StkIng = new decimal[1] ;
         P00DM5_A1706ProdRef10 = new string[] {""} ;
         P00DM5_A1714ProdRef9 = new string[] {""} ;
         P00DM5_A1713ProdRef8 = new string[] {""} ;
         P00DM5_A1712ProdRef7 = new string[] {""} ;
         P00DM5_A1711ProdRef6 = new string[] {""} ;
         P00DM5_A1710ProdRef5 = new string[] {""} ;
         P00DM5_A1709ProdRef4 = new string[] {""} ;
         P00DM5_A1708ProdRef3 = new string[] {""} ;
         P00DM5_A1707ProdRef2 = new string[] {""} ;
         P00DM5_A1705ProdRef1 = new string[] {""} ;
         AV108Referencia = "";
         P00DM6_A1883StkDAct = new decimal[1] ;
         P00DM6_A28ProdCod = new string[] {""} ;
         P00DM6_A63AlmCod = new int[1] ;
         P00DM6_A64StkRef1 = new string[] {""} ;
         P00DM6_A1888StkRef2 = new string[] {""} ;
         P00DM6_A1889StkRef3 = new string[] {""} ;
         P00DM6_A1890StkRef4 = new string[] {""} ;
         P00DM6_A1884StkDIng = new decimal[1] ;
         P00DM6_A1885StkDSal = new decimal[1] ;
         A64StkRef1 = "";
         A1888StkRef2 = "";
         A1889StkRef3 = "";
         A1890StkRef4 = "";
         AV97StkRef1 = "";
         AV98StkRef2 = "";
         AV95StkRef3 = "";
         AV99StkRef4 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_stockactualxlotesexcel__default(),
            new Object[][] {
                new Object[] {
               P00DM2_A1914TipLSts, P00DM2_A1912TipLDsc, P00DM2_A202TipLCod
               }
               , new Object[] {
               P00DM3_A28ProdCod, P00DM3_A63AlmCod, P00DM3_A50FamCod, P00DM3_n50FamCod, P00DM3_A51SublCod, P00DM3_n51SublCod, P00DM3_A52LinCod, P00DM3_A436AlmDsc
               }
               , new Object[] {
               P00DM4_A49UniCod, P00DM4_A1158LinStk, P00DM4_A28ProdCod, P00DM4_A50FamCod, P00DM4_n50FamCod, P00DM4_A51SublCod, P00DM4_n51SublCod, P00DM4_A52LinCod, P00DM4_A63AlmCod, P00DM4_A55ProdDsc,
               P00DM4_A1997UniAbr, P00DM4_A1154LinRef1, P00DM4_A1882StkSal, P00DM4_A1881StkIng, P00DM4_A1706ProdRef10, P00DM4_A1714ProdRef9, P00DM4_A1713ProdRef8, P00DM4_A1712ProdRef7, P00DM4_A1711ProdRef6, P00DM4_A1710ProdRef5,
               P00DM4_A1709ProdRef4, P00DM4_A1708ProdRef3, P00DM4_A1707ProdRef2, P00DM4_A1705ProdRef1
               }
               , new Object[] {
               P00DM5_A49UniCod, P00DM5_A63AlmCod, P00DM5_A1158LinStk, P00DM5_A28ProdCod, P00DM5_A50FamCod, P00DM5_n50FamCod, P00DM5_A51SublCod, P00DM5_n51SublCod, P00DM5_A52LinCod, P00DM5_A1997UniAbr,
               P00DM5_A1154LinRef1, P00DM5_A55ProdDsc, P00DM5_A1882StkSal, P00DM5_A1881StkIng, P00DM5_A1706ProdRef10, P00DM5_A1714ProdRef9, P00DM5_A1713ProdRef8, P00DM5_A1712ProdRef7, P00DM5_A1711ProdRef6, P00DM5_A1710ProdRef5,
               P00DM5_A1709ProdRef4, P00DM5_A1708ProdRef3, P00DM5_A1707ProdRef2, P00DM5_A1705ProdRef1
               }
               , new Object[] {
               P00DM6_A1883StkDAct, P00DM6_A28ProdCod, P00DM6_A63AlmCod, P00DM6_A64StkRef1, P00DM6_A1888StkRef2, P00DM6_A1889StkRef3, P00DM6_A1890StkRef4, P00DM6_A1884StkDIng, P00DM6_A1885StkDSal
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV83nOrden ;
      private short AV93I ;
      private short A1914TipLSts ;
      private short A1158LinStk ;
      private short AV94Precio ;
      private int AV77LinCod ;
      private int AV78SubLCod ;
      private int AV79FamCod ;
      private int AV80AlmCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A202TipLCod ;
      private int A63AlmCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A49UniCod ;
      private long AV84ITemProd ;
      private decimal A1882StkSal ;
      private decimal A1881StkIng ;
      private decimal A1880StkAct ;
      private decimal AV85StkSal ;
      private decimal AV86StkIng ;
      private decimal AV87StkAct ;
      private decimal A1883StkDAct ;
      private decimal A1884StkDIng ;
      private decimal A1885StkDSal ;
      private decimal AV100StkDAct ;
      private string AV81Prodcod ;
      private string AV71Path ;
      private string scmdbuf ;
      private string A1912TipLDsc ;
      private string A28ProdCod ;
      private string A436AlmDsc ;
      private string AV88AlmDsc ;
      private string A55ProdDsc ;
      private string A1997UniAbr ;
      private string A1706ProdRef10 ;
      private string A1714ProdRef9 ;
      private string A1713ProdRef8 ;
      private string A1712ProdRef7 ;
      private string A1711ProdRef6 ;
      private string A1710ProdRef5 ;
      private string A1709ProdRef4 ;
      private string A1708ProdRef3 ;
      private string A1707ProdRef2 ;
      private string A1705ProdRef1 ;
      private string AV89Codigo ;
      private string AV90Producto ;
      private string AV91UniAbr ;
      private string AV108Referencia ;
      private DateTime AV82FDesde ;
      private bool returnInSub ;
      private bool BRKDM3 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private string A1154LinRef1 ;
      private string A1715ProdReferencias ;
      private string AV92ProdReferencias ;
      private string AV96LinRef1 ;
      private string A64StkRef1 ;
      private string A1888StkRef2 ;
      private string A1889StkRef3 ;
      private string A1890StkRef4 ;
      private string AV97StkRef1 ;
      private string AV98StkRef2 ;
      private string AV95StkRef3 ;
      private string AV99StkRef4 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private int aP2_FamCod ;
      private int aP3_AlmCod ;
      private string aP4_Prodcod ;
      private short aP5_nOrden ;
      private IDataStoreProvider pr_default ;
      private short[] P00DM2_A1914TipLSts ;
      private string[] P00DM2_A1912TipLDsc ;
      private int[] P00DM2_A202TipLCod ;
      private string[] P00DM3_A28ProdCod ;
      private int[] P00DM3_A63AlmCod ;
      private int[] P00DM3_A50FamCod ;
      private bool[] P00DM3_n50FamCod ;
      private int[] P00DM3_A51SublCod ;
      private bool[] P00DM3_n51SublCod ;
      private int[] P00DM3_A52LinCod ;
      private string[] P00DM3_A436AlmDsc ;
      private int[] P00DM4_A49UniCod ;
      private short[] P00DM4_A1158LinStk ;
      private string[] P00DM4_A28ProdCod ;
      private int[] P00DM4_A50FamCod ;
      private bool[] P00DM4_n50FamCod ;
      private int[] P00DM4_A51SublCod ;
      private bool[] P00DM4_n51SublCod ;
      private int[] P00DM4_A52LinCod ;
      private int[] P00DM4_A63AlmCod ;
      private string[] P00DM4_A55ProdDsc ;
      private string[] P00DM4_A1997UniAbr ;
      private string[] P00DM4_A1154LinRef1 ;
      private decimal[] P00DM4_A1882StkSal ;
      private decimal[] P00DM4_A1881StkIng ;
      private string[] P00DM4_A1706ProdRef10 ;
      private string[] P00DM4_A1714ProdRef9 ;
      private string[] P00DM4_A1713ProdRef8 ;
      private string[] P00DM4_A1712ProdRef7 ;
      private string[] P00DM4_A1711ProdRef6 ;
      private string[] P00DM4_A1710ProdRef5 ;
      private string[] P00DM4_A1709ProdRef4 ;
      private string[] P00DM4_A1708ProdRef3 ;
      private string[] P00DM4_A1707ProdRef2 ;
      private string[] P00DM4_A1705ProdRef1 ;
      private int[] P00DM5_A49UniCod ;
      private int[] P00DM5_A63AlmCod ;
      private short[] P00DM5_A1158LinStk ;
      private string[] P00DM5_A28ProdCod ;
      private int[] P00DM5_A50FamCod ;
      private bool[] P00DM5_n50FamCod ;
      private int[] P00DM5_A51SublCod ;
      private bool[] P00DM5_n51SublCod ;
      private int[] P00DM5_A52LinCod ;
      private string[] P00DM5_A1997UniAbr ;
      private string[] P00DM5_A1154LinRef1 ;
      private string[] P00DM5_A55ProdDsc ;
      private decimal[] P00DM5_A1882StkSal ;
      private decimal[] P00DM5_A1881StkIng ;
      private string[] P00DM5_A1706ProdRef10 ;
      private string[] P00DM5_A1714ProdRef9 ;
      private string[] P00DM5_A1713ProdRef8 ;
      private string[] P00DM5_A1712ProdRef7 ;
      private string[] P00DM5_A1711ProdRef6 ;
      private string[] P00DM5_A1710ProdRef5 ;
      private string[] P00DM5_A1709ProdRef4 ;
      private string[] P00DM5_A1708ProdRef3 ;
      private string[] P00DM5_A1707ProdRef2 ;
      private string[] P00DM5_A1705ProdRef1 ;
      private decimal[] P00DM6_A1883StkDAct ;
      private string[] P00DM6_A28ProdCod ;
      private int[] P00DM6_A63AlmCod ;
      private string[] P00DM6_A64StkRef1 ;
      private string[] P00DM6_A1888StkRef2 ;
      private string[] P00DM6_A1889StkRef3 ;
      private string[] P00DM6_A1890StkRef4 ;
      private decimal[] P00DM6_A1884StkDIng ;
      private decimal[] P00DM6_A1885StkDSal ;
      private string aP6_Filename ;
      private string aP7_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class r_stockactualxlotesexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DM3( IGxContext context ,
                                             int AV80AlmCod ,
                                             int AV77LinCod ,
                                             int AV78SubLCod ,
                                             int AV79FamCod ,
                                             string AV81Prodcod ,
                                             int A63AlmCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCod], T1.[AlmCod], T2.[FamCod], T2.[SublCod], T2.[LinCod], T3.[AlmDsc] FROM (([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T1.[AlmCod])";
         if ( ! (0==AV80AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[AlmCod] = @AV80AlmCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV77LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV77LinCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV78SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV78SubLCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV79FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV79FamCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV81Prodcod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[AlmCod], T1.[ProdCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00DM4( IGxContext context ,
                                             int AV77LinCod ,
                                             int AV78SubLCod ,
                                             int AV79FamCod ,
                                             string AV81Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             short A1158LinStk ,
                                             int AV80AlmCod ,
                                             int A63AlmCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T4.[LinStk], T1.[ProdCod], T2.[FamCod], T2.[SublCod], T2.[LinCod], T1.[AlmCod], T2.[ProdDsc], T3.[UniAbr], T4.[LinRef1], T1.[StkSal], T1.[StkIng], T2.[ProdRef10], T2.[ProdRef9], T2.[ProdRef8], T2.[ProdRef7], T2.[ProdRef6], T2.[ProdRef5], T2.[ProdRef4], T2.[ProdRef3], T2.[ProdRef2], T2.[ProdRef1] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod])";
         AddWhere(sWhereString, "(T1.[AlmCod] = @AV80AlmCod)");
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         if ( ! (0==AV77LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV77LinCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV78SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV78SubLCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV79FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV79FamCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV81Prodcod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[AlmCod], T1.[ProdCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00DM5( IGxContext context ,
                                             int AV77LinCod ,
                                             int AV78SubLCod ,
                                             int AV79FamCod ,
                                             string AV81Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             short A1158LinStk ,
                                             int AV80AlmCod ,
                                             int A63AlmCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T1.[AlmCod], T4.[LinStk], T1.[ProdCod], T2.[FamCod], T2.[SublCod], T2.[LinCod], T3.[UniAbr], T4.[LinRef1], T2.[ProdDsc], T1.[StkSal], T1.[StkIng], T2.[ProdRef10], T2.[ProdRef9], T2.[ProdRef8], T2.[ProdRef7], T2.[ProdRef6], T2.[ProdRef5], T2.[ProdRef4], T2.[ProdRef3], T2.[ProdRef2], T2.[ProdRef1] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod])";
         AddWhere(sWhereString, "(T1.[AlmCod] = @AV80AlmCod)");
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         if ( ! (0==AV77LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV77LinCod)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV78SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV78SubLCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV79FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV79FamCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV81Prodcod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[AlmCod], T2.[ProdDsc]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00DM3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] );
               case 2 :
                     return conditional_P00DM4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
               case 3 :
                     return conditional_P00DM5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
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
          Object[] prmP00DM2;
          prmP00DM2 = new Object[] {
          };
          Object[] prmP00DM6;
          prmP00DM6 = new Object[] {
          new ParDef("@AV80AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV89Codigo",GXType.NChar,15,0)
          };
          Object[] prmP00DM3;
          prmP00DM3 = new Object[] {
          new ParDef("@AV80AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV77LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV78SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV79FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV81Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00DM4;
          prmP00DM4 = new Object[] {
          new ParDef("@AV80AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV77LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV78SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV79FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV81Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00DM5;
          prmP00DM5 = new Object[] {
          new ParDef("@AV80AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV77LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV78SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV79FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV81Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DM2", "SELECT [TipLSts], [TipLDsc], [TipLCod] FROM [CTIPOSLISTAS] WHERE [TipLSts] = 1 ORDER BY [TipLCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DM2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DM3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DM3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DM4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DM4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DM5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DM5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DM6", "SELECT [StkDIng] - [StkDSal] AS StkDAct, [ProdCod], [AlmCod], [StkRef1], [StkRef2], [StkRef3], [StkRef4], [StkDIng], [StkDSal] FROM [ASTOCKACTUALDET] WHERE ([AlmCod] = @AV80AlmCod and [ProdCod] = @AV89Codigo) AND (Not ([StkDIng] - [StkDSal] = convert(int, 0))) ORDER BY [AlmCod], [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DM6,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 100);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 20);
                ((string[]) buf[16])[0] = rslt.getString(15, 20);
                ((string[]) buf[17])[0] = rslt.getString(16, 20);
                ((string[]) buf[18])[0] = rslt.getString(17, 20);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((string[]) buf[20])[0] = rslt.getString(19, 20);
                ((string[]) buf[21])[0] = rslt.getString(20, 20);
                ((string[]) buf[22])[0] = rslt.getString(21, 20);
                ((string[]) buf[23])[0] = rslt.getString(22, 20);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 5);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 100);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 20);
                ((string[]) buf[16])[0] = rslt.getString(15, 20);
                ((string[]) buf[17])[0] = rslt.getString(16, 20);
                ((string[]) buf[18])[0] = rslt.getString(17, 20);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((string[]) buf[20])[0] = rslt.getString(19, 20);
                ((string[]) buf[21])[0] = rslt.getString(20, 20);
                ((string[]) buf[22])[0] = rslt.getString(21, 20);
                ((string[]) buf[23])[0] = rslt.getString(22, 20);
                return;
             case 4 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                return;
       }
    }

 }

}
