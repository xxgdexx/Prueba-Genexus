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
   public class prreportepedidospendientesexcel : GXProcedure
   {
      public prreportepedidospendientesexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public prreportepedidospendientesexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CliCod ,
                           ref string aP1_ProdCod ,
                           ref int aP2_VenCod ,
                           ref int aP3_MonCod ,
                           ref DateTime aP4_FDesde ,
                           ref DateTime aP5_FHasta ,
                           ref string aP6_PedSts ,
                           ref int aP7_TPedCod ,
                           out string aP8_Filename ,
                           out string aP9_ErrorMessage )
      {
         this.AV8CliCod = aP0_CliCod;
         this.AV9ProdCod = aP1_ProdCod;
         this.AV48VenCod = aP2_VenCod;
         this.AV10MonCod = aP3_MonCod;
         this.AV11FDesde = aP4_FDesde;
         this.AV12FHasta = aP5_FHasta;
         this.AV13PedSts = aP6_PedSts;
         this.AV14TPedCod = aP7_TPedCod;
         this.AV39Filename = "" ;
         this.AV16ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_CliCod=this.AV8CliCod;
         aP1_ProdCod=this.AV9ProdCod;
         aP2_VenCod=this.AV48VenCod;
         aP3_MonCod=this.AV10MonCod;
         aP4_FDesde=this.AV11FDesde;
         aP5_FHasta=this.AV12FHasta;
         aP6_PedSts=this.AV13PedSts;
         aP7_TPedCod=this.AV14TPedCod;
         aP8_Filename=this.AV39Filename;
         aP9_ErrorMessage=this.AV16ErrorMessage;
      }

      public string executeUdp( ref string aP0_CliCod ,
                                ref string aP1_ProdCod ,
                                ref int aP2_VenCod ,
                                ref int aP3_MonCod ,
                                ref DateTime aP4_FDesde ,
                                ref DateTime aP5_FHasta ,
                                ref string aP6_PedSts ,
                                ref int aP7_TPedCod ,
                                out string aP8_Filename )
      {
         execute(ref aP0_CliCod, ref aP1_ProdCod, ref aP2_VenCod, ref aP3_MonCod, ref aP4_FDesde, ref aP5_FHasta, ref aP6_PedSts, ref aP7_TPedCod, out aP8_Filename, out aP9_ErrorMessage);
         return AV16ErrorMessage ;
      }

      public void executeSubmit( ref string aP0_CliCod ,
                                 ref string aP1_ProdCod ,
                                 ref int aP2_VenCod ,
                                 ref int aP3_MonCod ,
                                 ref DateTime aP4_FDesde ,
                                 ref DateTime aP5_FHasta ,
                                 ref string aP6_PedSts ,
                                 ref int aP7_TPedCod ,
                                 out string aP8_Filename ,
                                 out string aP9_ErrorMessage )
      {
         prreportepedidospendientesexcel objprreportepedidospendientesexcel;
         objprreportepedidospendientesexcel = new prreportepedidospendientesexcel();
         objprreportepedidospendientesexcel.AV8CliCod = aP0_CliCod;
         objprreportepedidospendientesexcel.AV9ProdCod = aP1_ProdCod;
         objprreportepedidospendientesexcel.AV48VenCod = aP2_VenCod;
         objprreportepedidospendientesexcel.AV10MonCod = aP3_MonCod;
         objprreportepedidospendientesexcel.AV11FDesde = aP4_FDesde;
         objprreportepedidospendientesexcel.AV12FHasta = aP5_FHasta;
         objprreportepedidospendientesexcel.AV13PedSts = aP6_PedSts;
         objprreportepedidospendientesexcel.AV14TPedCod = aP7_TPedCod;
         objprreportepedidospendientesexcel.AV39Filename = "" ;
         objprreportepedidospendientesexcel.AV16ErrorMessage = "" ;
         objprreportepedidospendientesexcel.context.SetSubmitInitialConfig(context);
         objprreportepedidospendientesexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprreportepedidospendientesexcel);
         aP0_CliCod=this.AV8CliCod;
         aP1_ProdCod=this.AV9ProdCod;
         aP2_VenCod=this.AV48VenCod;
         aP3_MonCod=this.AV10MonCod;
         aP4_FDesde=this.AV11FDesde;
         aP5_FHasta=this.AV12FHasta;
         aP6_PedSts=this.AV13PedSts;
         aP7_TPedCod=this.AV14TPedCod;
         aP8_Filename=this.AV39Filename;
         aP9_ErrorMessage=this.AV16ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prreportepedidospendientesexcel)stateInfo).executePrivate();
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
         AV36Archivo.Source = "Excel/PlantillasPedidosPendientes.xlsx";
         AV37Path = AV36Archivo.GetPath();
         AV38FilenameOrigen = StringUtil.Trim( AV37Path) + "\\PlantillasPedidosPendientes.xlsx";
         AV39Filename = "Excel/PedidosPendientes" + ".xlsx";
         AV40ExcelDocument.Clear();
         AV40ExcelDocument.Template = AV38FilenameOrigen;
         AV40ExcelDocument.Open(AV39Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Using cursor P00AG2 */
         pr_default.execute(0, new Object[] {AV8CliCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A45CliCod = P00AG2_A45CliCod[0];
            A161CliDsc = P00AG2_A161CliDsc[0];
            AV17Filtro1 = A161CliDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00AG3 */
         pr_default.execute(1, new Object[] {AV10MonCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A180MonCod = P00AG3_A180MonCod[0];
            A1234MonDsc = P00AG3_A1234MonDsc[0];
            AV18Filtro2 = A1234MonDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV44CellRow = 6;
         AV45FirstColumn = 1;
         AV24Item = 0;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV8CliCod ,
                                              AV10MonCod ,
                                              AV13PedSts ,
                                              AV14TPedCod ,
                                              AV48VenCod ,
                                              A45CliCod ,
                                              A180MonCod ,
                                              A1606PedSts ,
                                              A212TPedCod ,
                                              A211PedVendCod ,
                                              A215PedFec ,
                                              AV11FDesde ,
                                              AV12FHasta ,
                                              A1549PedCotiza } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00AG4 */
         pr_default.execute(2, new Object[] {AV11FDesde, AV12FHasta, AV8CliCod, AV10MonCod, AV13PedSts, AV14TPedCod, AV48VenCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A214PedConp = P00AG4_A214PedConp[0];
            A210PedCod = P00AG4_A210PedCod[0];
            A1605PedRef = P00AG4_A1605PedRef[0];
            A215PedFec = P00AG4_A215PedFec[0];
            A1595PedFecAten = P00AG4_A1595PedFecAten[0];
            n1595PedFecAten = P00AG4_n1595PedFecAten[0];
            A1613PedUsuC = P00AG4_A1613PedUsuC[0];
            A1611PedUsuA = P00AG4_A1611PedUsuA[0];
            A1596PedFecC = P00AG4_A1596PedFecC[0];
            A1593PedFecA = P00AG4_A1593PedFecA[0];
            A1615PedVendDsc = P00AG4_A1615PedVendDsc[0];
            A1548PedConpDsc = P00AG4_A1548PedConpDsc[0];
            A1549PedCotiza = P00AG4_A1549PedCotiza[0];
            A211PedVendCod = P00AG4_A211PedVendCod[0];
            A212TPedCod = P00AG4_A212TPedCod[0];
            A1606PedSts = P00AG4_A1606PedSts[0];
            A180MonCod = P00AG4_A180MonCod[0];
            A45CliCod = P00AG4_A45CliCod[0];
            A161CliDsc = P00AG4_A161CliDsc[0];
            A1545PedCliDespacho = P00AG4_A1545PedCliDespacho[0];
            A1931TPedDsc = P00AG4_A1931TPedDsc[0];
            A1604PedObs = P00AG4_A1604PedObs[0];
            A1548PedConpDsc = P00AG4_A1548PedConpDsc[0];
            A1615PedVendDsc = P00AG4_A1615PedVendDsc[0];
            A1931TPedDsc = P00AG4_A1931TPedDsc[0];
            A161CliDsc = P00AG4_A161CliDsc[0];
            AV24Item = (int)(AV24Item+1);
            AV25PedCliCod = A45CliCod;
            AV26CliDsc = A161CliDsc;
            AV27PedCliDespacho = A1545PedCliDespacho;
            AV53Sucursal = "";
            AV61TPedDsc = A1931TPedDsc;
            AV62PedObs = StringUtil.Trim( A1604PedObs);
            if ( ! (0==AV27PedCliDespacho) )
            {
               /* Execute user subroutine: 'RAZONSOCIAL' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
            }
            AV28PedDCan = 0.00m;
            AV29PedDCanDsp = 0.00m;
            AV30PedDCanFac = 0.00m;
            AV31Precio = 0.00m;
            AV32Dscto = 0.00m;
            AV33PreTot = 0.00m;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A1606PedSts)) || P00AG4_n1606PedSts[0] )
            {
               AV51Estado = "Pendiente";
            }
            if ( StringUtil.StrCmp(A1606PedSts, "D") == 0 )
            {
               AV51Estado = "Despachado";
            }
            if ( StringUtil.StrCmp(A1606PedSts, "F") == 0 )
            {
               AV51Estado = "Facturado";
            }
            if ( StringUtil.StrCmp(A1606PedSts, "T") == 0 )
            {
               AV51Estado = "Terminado";
            }
            if ( StringUtil.StrCmp(A1606PedSts, "A") == 0 )
            {
               AV51Estado = "Anulado";
            }
            if ( StringUtil.StrCmp(A1606PedSts, "P") == 0 )
            {
               AV51Estado = "Por Autorizar";
            }
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV9ProdCod ,
                                                 A28ProdCod ,
                                                 A210PedCod } ,
                                                 new int[]{
                                                 }
            });
            /* Using cursor P00AG5 */
            pr_default.execute(3, new Object[] {A210PedCod, AV9ProdCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A49UniCod = P00AG5_A49UniCod[0];
               A28ProdCod = P00AG5_A28ProdCod[0];
               A1558PedDCanDSP = P00AG5_A1558PedDCanDSP[0];
               A1559PedDCanFAC = P00AG5_A1559PedDCanFAC[0];
               A1997UniAbr = P00AG5_A1997UniAbr[0];
               A1555PedDDct = P00AG5_A1555PedDDct[0];
               A1556PedDDct2 = P00AG5_A1556PedDDct2[0];
               A1551PedDTot = P00AG5_A1551PedDTot[0];
               A1572PedDObs = P00AG5_A1572PedDObs[0];
               A55ProdDsc = P00AG5_A55ProdDsc[0];
               A1554PedDCan = P00AG5_A1554PedDCan[0];
               A1553PedDPre = P00AG5_A1553PedDPre[0];
               A216PedDItem = P00AG5_A216PedDItem[0];
               A49UniCod = P00AG5_A49UniCod[0];
               A1997UniAbr = P00AG5_A1997UniAbr[0];
               A1552PedDSub = NumberUtil.Round( A1553PedDPre*A1554PedDCan, 4);
               AV41PedCod = A210PedCod;
               AV42PedRef = A1605PedRef;
               AV43PedFec = A215PedFec;
               AV60PedFecAten = A1595PedFecAten;
               AV28PedDCan = A1554PedDCan;
               AV29PedDCanDsp = A1558PedDCanDSP;
               AV30PedDCanFac = A1559PedDCanFAC;
               AV47UniAbr = StringUtil.Trim( A1997UniAbr);
               AV54PedUsuC = A1613PedUsuC;
               AV55PedUsuA = A1611PedUsuA;
               AV56PedFecC = A1596PedFecC;
               AV57PedFecA = A1593PedFecA;
               AV58PedDDct = A1555PedDDct;
               AV59PedDDct2 = A1556PedDDct2;
               AV52Descuento = NumberUtil.Round( (A1552PedDSub)*(1-(A1555PedDDct/ (decimal)(100)))*(1-(A1556PedDDct2/ (decimal)(100))), 2);
               AV31Precio = A1553PedDPre;
               AV32Dscto = NumberUtil.Round( A1552PedDSub-A1551PedDTot, 2);
               AV33PreTot = A1551PedDTot;
               AV34PedDObs = StringUtil.Trim( A1572PedDObs);
               AV35Producto = StringUtil.Trim( A55ProdDsc);
               AV46Codigo = StringUtil.Trim( A28ProdCod);
               AV49VenDsc = StringUtil.Trim( A1615PedVendDsc);
               AV50ConpDsc = StringUtil.Trim( A1548PedConpDsc);
               /* Execute user subroutine: 'DETALLE' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  this.cleanup();
                  if (true) return;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV20TotGeneral = (decimal)(AV20TotGeneral+AV33PreTot);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV40ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
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

      protected void S121( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV41PedCod);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV61TPedDsc);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+2), 1, 1).Text = StringUtil.Trim( AV42PedRef);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV43PedFec ) ;
         AV40ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+3), 1, 1).Date = GXt_dtime1;
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+4), 1, 1).Text = StringUtil.Trim( AV25PedCliCod);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+5), 1, 1).Text = StringUtil.Trim( AV26CliDsc);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+6), 1, 1).Text = StringUtil.Trim( AV53Sucursal);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+7), 1, 1).Text = StringUtil.Trim( AV46Codigo);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+8), 1, 1).Text = StringUtil.Trim( AV35Producto);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+9), 1, 1).Text = StringUtil.Trim( AV47UniAbr);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+10), 1, 1).Number = (double)(AV31Precio);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+11), 1, 1).Number = (double)(AV58PedDDct);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+12), 1, 1).Number = (double)(AV59PedDDct2);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+13), 1, 1).Number = (double)(AV32Dscto);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+14), 1, 1).Number = (double)(AV33PreTot);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+15), 1, 1).Number = (double)(AV28PedDCan);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+16), 1, 1).Number = (double)(AV29PedDCanDsp);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+17), 1, 1).Number = (double)(AV30PedDCanFac);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+18), 1, 1).Number = (double)(AV28PedDCan-AV29PedDCanDsp);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+19), 1, 1).Text = StringUtil.Trim( AV49VenDsc);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+20), 1, 1).Text = StringUtil.Trim( AV50ConpDsc);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+21), 1, 1).Text = StringUtil.Trim( AV51Estado);
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+22), 1, 1).Text = StringUtil.Trim( AV54PedUsuC);
         AV40ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+23), 1, 1).Date = AV56PedFecC;
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+24), 1, 1).Text = StringUtil.Trim( AV55PedUsuA);
         AV40ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+25), 1, 1).Date = AV57PedFecA;
         AV40ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+26), 1, 1).Date = AV60PedFecAten;
         AV40ExcelDocument.get_Cells((int)(AV44CellRow), (int)(AV45FirstColumn+27), 1, 1).Text = StringUtil.Trim( AV62PedObs);
         AV44CellRow = (long)(AV44CellRow+1);
      }

      protected void S131( )
      {
         /* 'RAZONSOCIAL' Routine */
         returnInSub = false;
         /* Using cursor P00AG6 */
         pr_default.execute(4, new Object[] {AV25PedCliCod, AV27PedCliDespacho});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A164CliDirItem = P00AG6_A164CliDirItem[0];
            A45CliCod = P00AG6_A45CliCod[0];
            A600CliDirDsc = P00AG6_A600CliDirDsc[0];
            AV53Sucursal = StringUtil.Trim( A600CliDirDsc);
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV39Filename = "";
         AV16ErrorMessage = "";
         AV36Archivo = new GxFile(context.GetPhysicalPath());
         AV37Path = "";
         AV38FilenameOrigen = "";
         AV40ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P00AG2_A45CliCod = new string[] {""} ;
         P00AG2_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         AV17Filtro1 = "";
         P00AG3_A180MonCod = new int[1] ;
         P00AG3_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV18Filtro2 = "";
         A1606PedSts = "";
         A215PedFec = DateTime.MinValue;
         P00AG4_A214PedConp = new int[1] ;
         P00AG4_A210PedCod = new string[] {""} ;
         P00AG4_A1605PedRef = new string[] {""} ;
         P00AG4_A215PedFec = new DateTime[] {DateTime.MinValue} ;
         P00AG4_A1595PedFecAten = new DateTime[] {DateTime.MinValue} ;
         P00AG4_n1595PedFecAten = new bool[] {false} ;
         P00AG4_A1613PedUsuC = new string[] {""} ;
         P00AG4_A1611PedUsuA = new string[] {""} ;
         P00AG4_A1596PedFecC = new DateTime[] {DateTime.MinValue} ;
         P00AG4_A1593PedFecA = new DateTime[] {DateTime.MinValue} ;
         P00AG4_A1615PedVendDsc = new string[] {""} ;
         P00AG4_A1548PedConpDsc = new string[] {""} ;
         P00AG4_A1549PedCotiza = new short[1] ;
         P00AG4_A211PedVendCod = new int[1] ;
         P00AG4_A212TPedCod = new int[1] ;
         P00AG4_A1606PedSts = new string[] {""} ;
         P00AG4_A180MonCod = new int[1] ;
         P00AG4_A45CliCod = new string[] {""} ;
         P00AG4_A161CliDsc = new string[] {""} ;
         P00AG4_A1545PedCliDespacho = new int[1] ;
         P00AG4_A1931TPedDsc = new string[] {""} ;
         P00AG4_A1604PedObs = new string[] {""} ;
         A210PedCod = "";
         A1605PedRef = "";
         A1595PedFecAten = (DateTime)(DateTime.MinValue);
         A1613PedUsuC = "";
         A1611PedUsuA = "";
         A1596PedFecC = (DateTime)(DateTime.MinValue);
         A1593PedFecA = (DateTime)(DateTime.MinValue);
         A1615PedVendDsc = "";
         A1548PedConpDsc = "";
         A1931TPedDsc = "";
         A1604PedObs = "";
         AV25PedCliCod = "";
         AV26CliDsc = "";
         AV53Sucursal = "";
         AV61TPedDsc = "";
         AV62PedObs = "";
         P00AG4_n1606PedSts = new bool[] {false} ;
         AV51Estado = "";
         A28ProdCod = "";
         P00AG5_A49UniCod = new int[1] ;
         P00AG5_A210PedCod = new string[] {""} ;
         P00AG5_A28ProdCod = new string[] {""} ;
         P00AG5_A1558PedDCanDSP = new decimal[1] ;
         P00AG5_A1559PedDCanFAC = new decimal[1] ;
         P00AG5_A1997UniAbr = new string[] {""} ;
         P00AG5_A1555PedDDct = new decimal[1] ;
         P00AG5_A1556PedDDct2 = new decimal[1] ;
         P00AG5_A1551PedDTot = new decimal[1] ;
         P00AG5_A1572PedDObs = new string[] {""} ;
         P00AG5_A55ProdDsc = new string[] {""} ;
         P00AG5_A1554PedDCan = new decimal[1] ;
         P00AG5_A1553PedDPre = new decimal[1] ;
         P00AG5_A216PedDItem = new short[1] ;
         A1997UniAbr = "";
         A1572PedDObs = "";
         A55ProdDsc = "";
         AV41PedCod = "";
         AV42PedRef = "";
         AV43PedFec = DateTime.MinValue;
         AV60PedFecAten = (DateTime)(DateTime.MinValue);
         AV47UniAbr = "";
         AV54PedUsuC = "";
         AV55PedUsuA = "";
         AV56PedFecC = (DateTime)(DateTime.MinValue);
         AV57PedFecA = (DateTime)(DateTime.MinValue);
         AV34PedDObs = "";
         AV35Producto = "";
         AV46Codigo = "";
         AV49VenDsc = "";
         AV50ConpDsc = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         P00AG6_A164CliDirItem = new int[1] ;
         P00AG6_A45CliCod = new string[] {""} ;
         P00AG6_A600CliDirDsc = new string[] {""} ;
         A600CliDirDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prreportepedidospendientesexcel__default(),
            new Object[][] {
                new Object[] {
               P00AG2_A45CliCod, P00AG2_A161CliDsc
               }
               , new Object[] {
               P00AG3_A180MonCod, P00AG3_A1234MonDsc
               }
               , new Object[] {
               P00AG4_A214PedConp, P00AG4_A210PedCod, P00AG4_A1605PedRef, P00AG4_A215PedFec, P00AG4_A1595PedFecAten, P00AG4_n1595PedFecAten, P00AG4_A1613PedUsuC, P00AG4_A1611PedUsuA, P00AG4_A1596PedFecC, P00AG4_A1593PedFecA,
               P00AG4_A1615PedVendDsc, P00AG4_A1548PedConpDsc, P00AG4_A1549PedCotiza, P00AG4_A211PedVendCod, P00AG4_A212TPedCod, P00AG4_A1606PedSts, P00AG4_A180MonCod, P00AG4_A45CliCod, P00AG4_A161CliDsc, P00AG4_A1545PedCliDespacho,
               P00AG4_A1931TPedDsc, P00AG4_A1604PedObs
               }
               , new Object[] {
               P00AG5_A49UniCod, P00AG5_A210PedCod, P00AG5_A28ProdCod, P00AG5_A1558PedDCanDSP, P00AG5_A1559PedDCanFAC, P00AG5_A1997UniAbr, P00AG5_A1555PedDDct, P00AG5_A1556PedDDct2, P00AG5_A1551PedDTot, P00AG5_A1572PedDObs,
               P00AG5_A55ProdDsc, P00AG5_A1554PedDCan, P00AG5_A1553PedDPre, P00AG5_A216PedDItem
               }
               , new Object[] {
               P00AG6_A164CliDirItem, P00AG6_A45CliCod, P00AG6_A600CliDirDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1549PedCotiza ;
      private short A216PedDItem ;
      private int AV48VenCod ;
      private int AV10MonCod ;
      private int AV14TPedCod ;
      private int A180MonCod ;
      private int AV24Item ;
      private int A212TPedCod ;
      private int A211PedVendCod ;
      private int A214PedConp ;
      private int A1545PedCliDespacho ;
      private int AV27PedCliDespacho ;
      private int A49UniCod ;
      private int A164CliDirItem ;
      private long AV44CellRow ;
      private long AV45FirstColumn ;
      private decimal AV28PedDCan ;
      private decimal AV29PedDCanDsp ;
      private decimal AV30PedDCanFac ;
      private decimal AV31Precio ;
      private decimal AV32Dscto ;
      private decimal AV33PreTot ;
      private decimal A1558PedDCanDSP ;
      private decimal A1559PedDCanFAC ;
      private decimal A1555PedDDct ;
      private decimal A1556PedDDct2 ;
      private decimal A1551PedDTot ;
      private decimal A1554PedDCan ;
      private decimal A1553PedDPre ;
      private decimal A1552PedDSub ;
      private decimal AV58PedDDct ;
      private decimal AV59PedDDct2 ;
      private decimal AV52Descuento ;
      private decimal AV20TotGeneral ;
      private string AV8CliCod ;
      private string AV9ProdCod ;
      private string AV13PedSts ;
      private string AV37Path ;
      private string scmdbuf ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A1234MonDsc ;
      private string A1606PedSts ;
      private string A210PedCod ;
      private string A1605PedRef ;
      private string A1613PedUsuC ;
      private string A1611PedUsuA ;
      private string A1615PedVendDsc ;
      private string A1548PedConpDsc ;
      private string A1931TPedDsc ;
      private string AV25PedCliCod ;
      private string AV26CliDsc ;
      private string AV53Sucursal ;
      private string AV61TPedDsc ;
      private string AV51Estado ;
      private string A28ProdCod ;
      private string A1997UniAbr ;
      private string A55ProdDsc ;
      private string AV41PedCod ;
      private string AV42PedRef ;
      private string AV47UniAbr ;
      private string AV54PedUsuC ;
      private string AV55PedUsuA ;
      private string AV35Producto ;
      private string AV46Codigo ;
      private string AV49VenDsc ;
      private string AV50ConpDsc ;
      private string A600CliDirDsc ;
      private DateTime A1595PedFecAten ;
      private DateTime A1596PedFecC ;
      private DateTime A1593PedFecA ;
      private DateTime AV60PedFecAten ;
      private DateTime AV56PedFecC ;
      private DateTime AV57PedFecA ;
      private DateTime GXt_dtime1 ;
      private DateTime AV11FDesde ;
      private DateTime AV12FHasta ;
      private DateTime A215PedFec ;
      private DateTime AV43PedFec ;
      private bool returnInSub ;
      private bool n1595PedFecAten ;
      private string A1604PedObs ;
      private string AV62PedObs ;
      private string A1572PedDObs ;
      private string AV34PedDObs ;
      private string AV39Filename ;
      private string AV16ErrorMessage ;
      private string AV38FilenameOrigen ;
      private string AV17Filtro1 ;
      private string AV18Filtro2 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CliCod ;
      private string aP1_ProdCod ;
      private int aP2_VenCod ;
      private int aP3_MonCod ;
      private DateTime aP4_FDesde ;
      private DateTime aP5_FHasta ;
      private string aP6_PedSts ;
      private int aP7_TPedCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00AG2_A45CliCod ;
      private string[] P00AG2_A161CliDsc ;
      private int[] P00AG3_A180MonCod ;
      private string[] P00AG3_A1234MonDsc ;
      private int[] P00AG4_A214PedConp ;
      private string[] P00AG4_A210PedCod ;
      private string[] P00AG4_A1605PedRef ;
      private DateTime[] P00AG4_A215PedFec ;
      private DateTime[] P00AG4_A1595PedFecAten ;
      private bool[] P00AG4_n1595PedFecAten ;
      private string[] P00AG4_A1613PedUsuC ;
      private string[] P00AG4_A1611PedUsuA ;
      private DateTime[] P00AG4_A1596PedFecC ;
      private DateTime[] P00AG4_A1593PedFecA ;
      private string[] P00AG4_A1615PedVendDsc ;
      private string[] P00AG4_A1548PedConpDsc ;
      private short[] P00AG4_A1549PedCotiza ;
      private int[] P00AG4_A211PedVendCod ;
      private int[] P00AG4_A212TPedCod ;
      private string[] P00AG4_A1606PedSts ;
      private int[] P00AG4_A180MonCod ;
      private string[] P00AG4_A45CliCod ;
      private string[] P00AG4_A161CliDsc ;
      private int[] P00AG4_A1545PedCliDespacho ;
      private string[] P00AG4_A1931TPedDsc ;
      private string[] P00AG4_A1604PedObs ;
      private bool[] P00AG4_n1606PedSts ;
      private int[] P00AG5_A49UniCod ;
      private string[] P00AG5_A210PedCod ;
      private string[] P00AG5_A28ProdCod ;
      private decimal[] P00AG5_A1558PedDCanDSP ;
      private decimal[] P00AG5_A1559PedDCanFAC ;
      private string[] P00AG5_A1997UniAbr ;
      private decimal[] P00AG5_A1555PedDDct ;
      private decimal[] P00AG5_A1556PedDDct2 ;
      private decimal[] P00AG5_A1551PedDTot ;
      private string[] P00AG5_A1572PedDObs ;
      private string[] P00AG5_A55ProdDsc ;
      private decimal[] P00AG5_A1554PedDCan ;
      private decimal[] P00AG5_A1553PedDPre ;
      private short[] P00AG5_A216PedDItem ;
      private int[] P00AG6_A164CliDirItem ;
      private string[] P00AG6_A45CliCod ;
      private string[] P00AG6_A600CliDirDsc ;
      private string aP8_Filename ;
      private string aP9_ErrorMessage ;
      private ExcelDocumentI AV40ExcelDocument ;
      private GxFile AV36Archivo ;
   }

   public class prreportepedidospendientesexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AG4( IGxContext context ,
                                             string AV8CliCod ,
                                             int AV10MonCod ,
                                             string AV13PedSts ,
                                             int AV14TPedCod ,
                                             int AV48VenCod ,
                                             string A45CliCod ,
                                             int A180MonCod ,
                                             string A1606PedSts ,
                                             int A212TPedCod ,
                                             int A211PedVendCod ,
                                             DateTime A215PedFec ,
                                             DateTime AV11FDesde ,
                                             DateTime AV12FHasta ,
                                             short A1549PedCotiza )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[PedConp] AS PedConp, T1.[PedCod], T1.[PedRef], T1.[PedFec], T1.[PedFecAten], T1.[PedUsuC], T1.[PedUsuA], T1.[PedFecC], T1.[PedFecA], T3.[VenDsc] AS PedVendDsc, T2.[ConpDsc] AS PedConpDsc, T1.[PedCotiza], T1.[PedVendCod] AS PedVendCod, T1.[TPedCod], T1.[PedSts], T1.[MonCod], T1.[CliCod], T5.[CliDsc], T1.[PedCliDespacho], T4.[TPedDsc], T1.[PedObs] FROM (((([CLPEDIDOS] T1 INNER JOIN [CCONDICIONPAGO] T2 ON T2.[Conpcod] = T1.[PedConp]) INNER JOIN [CVENDEDORES] T3 ON T3.[VenCod] = T1.[PedVendCod]) INNER JOIN [CTIPPEDIDO] T4 ON T4.[TPedCod] = T1.[TPedCod]) INNER JOIN [CLCLIENTES] T5 ON T5.[CliCod] = T1.[CliCod])";
         AddWhere(sWhereString, "(T1.[PedFec] >= @AV11FDesde and T1.[PedFec] <= @AV12FHasta)");
         AddWhere(sWhereString, "(T1.[PedCotiza] = 0)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV8CliCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV10MonCod) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV10MonCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! ( StringUtil.StrCmp(AV13PedSts, "TT") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PedSts] = @AV13PedSts)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV14TPedCod) )
         {
            AddWhere(sWhereString, "(T1.[TPedCod] = @AV14TPedCod)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV48VenCod) )
         {
            AddWhere(sWhereString, "(T1.[PedVendCod] = @AV48VenCod)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CliCod]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00AG5( IGxContext context ,
                                             string AV9ProdCod ,
                                             string A28ProdCod ,
                                             string A210PedCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[2];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T1.[PedCod], T1.[ProdCod], T1.[PedDCanDSP], T1.[PedDCanFAC], T3.[UniAbr], T1.[PedDDct], T1.[PedDDct2], T1.[PedDTot], T1.[PedDObs], T1.[ProdDsc], T1.[PedDCan], T1.[PedDPre], T1.[PedDItem] FROM (([CLPEDIDOSDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod])";
         AddWhere(sWhereString, "(T1.[PedCod] = @PedCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV9ProdCod)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PedCod]";
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
               case 2 :
                     return conditional_P00AG4(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] );
               case 3 :
                     return conditional_P00AG5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
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
          Object[] prmP00AG2;
          prmP00AG2 = new Object[] {
          new ParDef("@AV8CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00AG3;
          prmP00AG3 = new Object[] {
          new ParDef("@AV10MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00AG6;
          prmP00AG6 = new Object[] {
          new ParDef("@AV25PedCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV27PedCliDespacho",GXType.Int32,6,0)
          };
          Object[] prmP00AG4;
          prmP00AG4 = new Object[] {
          new ParDef("@AV11FDesde",GXType.Date,8,0) ,
          new ParDef("@AV12FHasta",GXType.Date,8,0) ,
          new ParDef("@AV8CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV10MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV13PedSts",GXType.NChar,1,0) ,
          new ParDef("@AV14TPedCod",GXType.Int32,6,0) ,
          new ParDef("@AV48VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00AG5;
          prmP00AG5 = new Object[] {
          new ParDef("@PedCod",GXType.NChar,10,0) ,
          new ParDef("@AV9ProdCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AG2", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV8CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AG2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AG3", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV10MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AG3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AG4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AG4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AG5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AG5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AG6", "SELECT [CliDirItem], [CliCod], [CliDirDsc] FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @AV25PedCliCod and [CliDirItem] = @AV27PedCliDespacho ORDER BY [CliCod], [CliDirItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AG6,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 10);
                ((string[]) buf[7])[0] = rslt.getString(7, 10);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 100);
                ((short[]) buf[12])[0] = rslt.getShort(12);
                ((int[]) buf[13])[0] = rslt.getInt(13);
                ((int[]) buf[14])[0] = rslt.getInt(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 1);
                ((int[]) buf[16])[0] = rslt.getInt(16);
                ((string[]) buf[17])[0] = rslt.getString(17, 20);
                ((string[]) buf[18])[0] = rslt.getString(18, 100);
                ((int[]) buf[19])[0] = rslt.getInt(19);
                ((string[]) buf[20])[0] = rslt.getString(20, 100);
                ((string[]) buf[21])[0] = rslt.getLongVarchar(21);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
