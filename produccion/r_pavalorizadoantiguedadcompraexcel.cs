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
   public class r_pavalorizadoantiguedadcompraexcel : GXProcedure
   {
      public r_pavalorizadoantiguedadcompraexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_pavalorizadoantiguedadcompraexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SublCod ,
                           ref int aP2_FamCod ,
                           ref int aP3_AlmCod ,
                           ref string aP4_Prodcod ,
                           ref DateTime aP5_FDesde ,
                           ref DateTime aP6_FHasta ,
                           out string aP7_Filename ,
                           out string aP8_ErrorMessage )
      {
         this.AV73LinCod = aP0_LinCod;
         this.AV103SublCod = aP1_SublCod;
         this.AV41FamCod = aP2_FamCod;
         this.AV10AlmCod = aP3_AlmCod;
         this.AV90Prodcod = aP4_Prodcod;
         this.AV42FDesde = aP5_FDesde;
         this.AV45FHasta = aP6_FHasta;
         this.AV47Filename = "" ;
         this.AV39ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV73LinCod;
         aP1_SublCod=this.AV103SublCod;
         aP2_FamCod=this.AV41FamCod;
         aP3_AlmCod=this.AV10AlmCod;
         aP4_Prodcod=this.AV90Prodcod;
         aP5_FDesde=this.AV42FDesde;
         aP6_FHasta=this.AV45FHasta;
         aP7_Filename=this.AV47Filename;
         aP8_ErrorMessage=this.AV39ErrorMessage;
      }

      public string executeUdp( ref int aP0_LinCod ,
                                ref int aP1_SublCod ,
                                ref int aP2_FamCod ,
                                ref int aP3_AlmCod ,
                                ref string aP4_Prodcod ,
                                ref DateTime aP5_FDesde ,
                                ref DateTime aP6_FHasta ,
                                out string aP7_Filename )
      {
         execute(ref aP0_LinCod, ref aP1_SublCod, ref aP2_FamCod, ref aP3_AlmCod, ref aP4_Prodcod, ref aP5_FDesde, ref aP6_FHasta, out aP7_Filename, out aP8_ErrorMessage);
         return AV39ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SublCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCod ,
                                 ref string aP4_Prodcod ,
                                 ref DateTime aP5_FDesde ,
                                 ref DateTime aP6_FHasta ,
                                 out string aP7_Filename ,
                                 out string aP8_ErrorMessage )
      {
         r_pavalorizadoantiguedadcompraexcel objr_pavalorizadoantiguedadcompraexcel;
         objr_pavalorizadoantiguedadcompraexcel = new r_pavalorizadoantiguedadcompraexcel();
         objr_pavalorizadoantiguedadcompraexcel.AV73LinCod = aP0_LinCod;
         objr_pavalorizadoantiguedadcompraexcel.AV103SublCod = aP1_SublCod;
         objr_pavalorizadoantiguedadcompraexcel.AV41FamCod = aP2_FamCod;
         objr_pavalorizadoantiguedadcompraexcel.AV10AlmCod = aP3_AlmCod;
         objr_pavalorizadoantiguedadcompraexcel.AV90Prodcod = aP4_Prodcod;
         objr_pavalorizadoantiguedadcompraexcel.AV42FDesde = aP5_FDesde;
         objr_pavalorizadoantiguedadcompraexcel.AV45FHasta = aP6_FHasta;
         objr_pavalorizadoantiguedadcompraexcel.AV47Filename = "" ;
         objr_pavalorizadoantiguedadcompraexcel.AV39ErrorMessage = "" ;
         objr_pavalorizadoantiguedadcompraexcel.context.SetSubmitInitialConfig(context);
         objr_pavalorizadoantiguedadcompraexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_pavalorizadoantiguedadcompraexcel);
         aP0_LinCod=this.AV73LinCod;
         aP1_SublCod=this.AV103SublCod;
         aP2_FamCod=this.AV41FamCod;
         aP3_AlmCod=this.AV10AlmCod;
         aP4_Prodcod=this.AV90Prodcod;
         aP5_FDesde=this.AV42FDesde;
         aP6_FHasta=this.AV45FHasta;
         aP7_Filename=this.AV47Filename;
         aP8_ErrorMessage=this.AV39ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_pavalorizadoantiguedadcompraexcel)stateInfo).executePrivate();
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
         AV13Archivo.Source = "Excel/PlantillaValorizadoAntiguedadCompra.xlsx";
         AV89Path = AV13Archivo.GetPath();
         AV48FilenameOrigen = StringUtil.Trim( AV89Path) + "\\PlantillaValorizadoAntiguedadCompra.xlsx";
         AV47Filename = "Excel/ValorizadoAntiguedadCompra" + ".xlsx";
         AV40ExcelDocument.Clear();
         AV40ExcelDocument.Template = AV48FilenameOrigen;
         AV40ExcelDocument.Open(AV47Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV40ExcelDocument.get_Cells(3, 1, 1, 1).Text = "FECHA AL : "+context.localUtil.DToC( AV45FHasta, 2, "/");
         AV16CellRow = 5;
         AV50FirstColumn = 1;
         AV46FHasta1 = DateTimeUtil.DAdd(AV45FHasta,+((int)(1)));
         AV15CantidadTotal = 0.0000m;
         AV23CostoTotal = 0.00m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV73LinCod ,
                                              AV103SublCod ,
                                              AV41FamCod ,
                                              AV90Prodcod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A28ProdCod ,
                                              A21MvAlm ,
                                              AV10AlmCod ,
                                              A1158LinStk } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00G72 */
         pr_default.execute(0, new Object[] {AV10AlmCod, AV73LinCod, AV103SublCod, AV41FamCod, AV90Prodcod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKG72 = false;
            A13MvATip = P00G72_A13MvATip[0];
            A14MvACod = P00G72_A14MvACod[0];
            A49UniCod = P00G72_A49UniCod[0];
            A55ProdDsc = P00G72_A55ProdDsc[0];
            A28ProdCod = P00G72_A28ProdCod[0];
            A1158LinStk = P00G72_A1158LinStk[0];
            A21MvAlm = P00G72_A21MvAlm[0];
            A50FamCod = P00G72_A50FamCod[0];
            n50FamCod = P00G72_n50FamCod[0];
            A51SublCod = P00G72_A51SublCod[0];
            n51SublCod = P00G72_n51SublCod[0];
            A52LinCod = P00G72_A52LinCod[0];
            A1997UniAbr = P00G72_A1997UniAbr[0];
            A1153LinDsc = P00G72_A1153LinDsc[0];
            A30MvADItem = P00G72_A30MvADItem[0];
            A21MvAlm = P00G72_A21MvAlm[0];
            A49UniCod = P00G72_A49UniCod[0];
            A55ProdDsc = P00G72_A55ProdDsc[0];
            A50FamCod = P00G72_A50FamCod[0];
            n50FamCod = P00G72_n50FamCod[0];
            A51SublCod = P00G72_A51SublCod[0];
            n51SublCod = P00G72_n51SublCod[0];
            A52LinCod = P00G72_A52LinCod[0];
            A1997UniAbr = P00G72_A1997UniAbr[0];
            A1158LinStk = P00G72_A1158LinStk[0];
            A1153LinDsc = P00G72_A1153LinDsc[0];
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00G72_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRKG72 = false;
               A13MvATip = P00G72_A13MvATip[0];
               A14MvACod = P00G72_A14MvACod[0];
               A55ProdDsc = P00G72_A55ProdDsc[0];
               A30MvADItem = P00G72_A30MvADItem[0];
               A55ProdDsc = P00G72_A55ProdDsc[0];
               BRKG72 = true;
               pr_default.readNext(0);
            }
            AV91ProdCodC = A28ProdCod;
            AV93Producto = A55ProdDsc;
            AV135UniAbr = A1997UniAbr;
            AV9LinDsc = StringUtil.Trim( A1153LinDsc);
            new GeneXus.Programs.contabilidad.paobtenersaldocostoproductofechas(context ).execute( ref  AV46FHasta1, ref  AV10AlmCod, ref  AV91ProdCodC, out  AV100Saldo, out  AV24CostoU) ;
            AV22CostoT = NumberUtil.Round( AV100Saldo*AV24CostoU, 2);
            AV107TCosto = AV22CostoT;
            AV23CostoTotal = (decimal)(AV23CostoTotal+AV107TCosto);
            AV15CantidadTotal = (decimal)(AV15CantidadTotal+AV100Saldo);
            if ( ! (Convert.ToDecimal(0)==AV100Saldo) )
            {
               /* Execute user subroutine: 'DETALLEPRODUCTO' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'DETALLEINVENTARIO' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               AV16CellRow = (int)(AV16CellRow+1);
               AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+4, 1, 1).Text = "TOTAL GENERAL";
               AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+6, 1, 1).Number = (double)(AV15CantidadTotal);
               AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+9, 1, 1).Number = (double)(AV23CostoTotal);
            }
            if ( ! BRKG72 )
            {
               BRKG72 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV40ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
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
         /* 'DETALLEINVENTARIO' Routine */
         returnInSub = false;
         AV8Cantidad = 0.00m;
         AV136I = 0;
         /* Using cursor P00G73 */
         pr_default.execute(1, new Object[] {AV45FHasta, AV91ProdCodC, AV10AlmCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A28ProdCod = P00G73_A28ProdCod[0];
            A21MvAlm = P00G73_A21MvAlm[0];
            A13MvATip = P00G73_A13MvATip[0];
            A25MvAFec = P00G73_A25MvAFec[0];
            A14MvACod = P00G73_A14MvACod[0];
            A1248MvADCant = P00G73_A1248MvADCant[0];
            A30MvADItem = P00G73_A30MvADItem[0];
            A21MvAlm = P00G73_A21MvAlm[0];
            A25MvAFec = P00G73_A25MvAFec[0];
            AV82MVAFec = A25MvAFec;
            AV78MVACod = A14MvACod;
            AV79MVADCAnt = A1248MvADCant;
            AV81MVADPrecio = AV24CostoU;
            AV80MVADCosto = NumberUtil.Round( AV79MVADCAnt*AV24CostoU, 2);
            AV8Cantidad = (decimal)(AV8Cantidad+AV79MVADCAnt);
            if ( ( AV79MVADCAnt >= AV100Saldo ) && ( AV136I == 1 ) )
            {
               AV80MVADCosto = NumberUtil.Round( AV100Saldo*AV81MVADPrecio, 2);
               AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV78MVACod);
               GXt_dtime1 = DateTimeUtil.ResetTime( AV82MVAFec ) ;
               AV40ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+1, 1, 1).Date = GXt_dtime1;
               AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV9LinDsc);
               AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV91ProdCodC);
               AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV93Producto);
               AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+5, 1, 1).Number = (double)(AV100Saldo);
               AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+7, 1, 1).Number = (double)(AV81MVADPrecio);
               AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+8, 1, 1).Number = (double)(AV80MVADCosto);
               AV16CellRow = (int)(AV16CellRow+1);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            else
            {
               if ( AV100Saldo >= AV8Cantidad )
               {
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV78MVACod);
                  GXt_dtime1 = DateTimeUtil.ResetTime( AV82MVAFec ) ;
                  AV40ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+1, 1, 1).Date = GXt_dtime1;
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV9LinDsc);
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV91ProdCodC);
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV93Producto);
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+5, 1, 1).Number = (double)(AV79MVADCAnt);
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+7, 1, 1).Number = (double)(AV81MVADPrecio);
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+8, 1, 1).Number = (double)(AV80MVADCosto);
                  AV16CellRow = (int)(AV16CellRow+1);
                  if ( AV8Cantidad == AV100Saldo )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV79MVADCAnt = (decimal)(AV100Saldo-(AV8Cantidad-AV79MVADCAnt));
                  AV80MVADCosto = NumberUtil.Round( AV79MVADCAnt*AV81MVADPrecio, 2);
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV78MVACod);
                  GXt_dtime1 = DateTimeUtil.ResetTime( AV82MVAFec ) ;
                  AV40ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+1, 1, 1).Date = GXt_dtime1;
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV9LinDsc);
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV91ProdCodC);
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV93Producto);
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+5, 1, 1).Number = (double)(AV79MVADCAnt);
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+7, 1, 1).Number = (double)(AV81MVADPrecio);
                  AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+8, 1, 1).Number = (double)(AV80MVADCosto);
                  AV16CellRow = (int)(AV16CellRow+1);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV40ExcelDocument.ErrCode != 0 )
         {
            AV47Filename = "";
            AV39ErrorMessage = AV40ExcelDocument.ErrDescription;
            AV40ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S131( )
      {
         /* 'DETALLEPRODUCTO' Routine */
         returnInSub = false;
         AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+0, 1, 1).Text = "";
         AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+1, 1, 1).Text = "";
         AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV9LinDsc);
         AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV91ProdCodC);
         AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV93Producto);
         AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+5, 1, 1).Number = (double)(0.00m);
         AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+6, 1, 1).Number = (double)(AV100Saldo);
         AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+7, 1, 1).Number = (double)(AV24CostoU);
         AV40ExcelDocument.get_Cells(AV16CellRow, AV50FirstColumn+9, 1, 1).Number = (double)(AV22CostoT);
         AV16CellRow = (int)(AV16CellRow+1);
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
         AV47Filename = "";
         AV39ErrorMessage = "";
         AV13Archivo = new GxFile(context.GetPhysicalPath());
         AV89Path = "";
         AV48FilenameOrigen = "";
         AV40ExcelDocument = new ExcelDocumentI();
         AV46FHasta1 = DateTime.MinValue;
         scmdbuf = "";
         A28ProdCod = "";
         P00G72_A13MvATip = new string[] {""} ;
         P00G72_A14MvACod = new string[] {""} ;
         P00G72_A49UniCod = new int[1] ;
         P00G72_A55ProdDsc = new string[] {""} ;
         P00G72_A28ProdCod = new string[] {""} ;
         P00G72_A1158LinStk = new short[1] ;
         P00G72_A21MvAlm = new int[1] ;
         P00G72_A50FamCod = new int[1] ;
         P00G72_n50FamCod = new bool[] {false} ;
         P00G72_A51SublCod = new int[1] ;
         P00G72_n51SublCod = new bool[] {false} ;
         P00G72_A52LinCod = new int[1] ;
         P00G72_A1997UniAbr = new string[] {""} ;
         P00G72_A1153LinDsc = new string[] {""} ;
         P00G72_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A55ProdDsc = "";
         A1997UniAbr = "";
         A1153LinDsc = "";
         AV91ProdCodC = "";
         AV93Producto = "";
         AV135UniAbr = "";
         AV9LinDsc = "";
         P00G73_A28ProdCod = new string[] {""} ;
         P00G73_A21MvAlm = new int[1] ;
         P00G73_A13MvATip = new string[] {""} ;
         P00G73_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00G73_A14MvACod = new string[] {""} ;
         P00G73_A1248MvADCant = new decimal[1] ;
         P00G73_A30MvADItem = new int[1] ;
         A25MvAFec = DateTime.MinValue;
         AV82MVAFec = DateTime.MinValue;
         AV78MVACod = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_pavalorizadoantiguedadcompraexcel__default(),
            new Object[][] {
                new Object[] {
               P00G72_A13MvATip, P00G72_A14MvACod, P00G72_A49UniCod, P00G72_A55ProdDsc, P00G72_A28ProdCod, P00G72_A1158LinStk, P00G72_A21MvAlm, P00G72_A50FamCod, P00G72_n50FamCod, P00G72_A51SublCod,
               P00G72_n51SublCod, P00G72_A52LinCod, P00G72_A1997UniAbr, P00G72_A1153LinDsc, P00G72_A30MvADItem
               }
               , new Object[] {
               P00G73_A28ProdCod, P00G73_A21MvAlm, P00G73_A13MvATip, P00G73_A25MvAFec, P00G73_A14MvACod, P00G73_A1248MvADCant, P00G73_A30MvADItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1158LinStk ;
      private short AV136I ;
      private int AV73LinCod ;
      private int AV103SublCod ;
      private int AV41FamCod ;
      private int AV10AlmCod ;
      private int AV16CellRow ;
      private int AV50FirstColumn ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A21MvAlm ;
      private int A49UniCod ;
      private int A30MvADItem ;
      private decimal AV15CantidadTotal ;
      private decimal AV23CostoTotal ;
      private decimal AV100Saldo ;
      private decimal AV24CostoU ;
      private decimal AV22CostoT ;
      private decimal AV107TCosto ;
      private decimal AV8Cantidad ;
      private decimal A1248MvADCant ;
      private decimal AV79MVADCAnt ;
      private decimal AV81MVADPrecio ;
      private decimal AV80MVADCosto ;
      private string AV90Prodcod ;
      private string AV89Path ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A55ProdDsc ;
      private string A1997UniAbr ;
      private string A1153LinDsc ;
      private string AV91ProdCodC ;
      private string AV93Producto ;
      private string AV135UniAbr ;
      private string AV9LinDsc ;
      private string AV78MVACod ;
      private DateTime GXt_dtime1 ;
      private DateTime AV42FDesde ;
      private DateTime AV45FHasta ;
      private DateTime AV46FHasta1 ;
      private DateTime A25MvAFec ;
      private DateTime AV82MVAFec ;
      private bool returnInSub ;
      private bool BRKG72 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private string AV47Filename ;
      private string AV39ErrorMessage ;
      private string AV48FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SublCod ;
      private int aP2_FamCod ;
      private int aP3_AlmCod ;
      private string aP4_Prodcod ;
      private DateTime aP5_FDesde ;
      private DateTime aP6_FHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P00G72_A13MvATip ;
      private string[] P00G72_A14MvACod ;
      private int[] P00G72_A49UniCod ;
      private string[] P00G72_A55ProdDsc ;
      private string[] P00G72_A28ProdCod ;
      private short[] P00G72_A1158LinStk ;
      private int[] P00G72_A21MvAlm ;
      private int[] P00G72_A50FamCod ;
      private bool[] P00G72_n50FamCod ;
      private int[] P00G72_A51SublCod ;
      private bool[] P00G72_n51SublCod ;
      private int[] P00G72_A52LinCod ;
      private string[] P00G72_A1997UniAbr ;
      private string[] P00G72_A1153LinDsc ;
      private int[] P00G72_A30MvADItem ;
      private string[] P00G73_A28ProdCod ;
      private int[] P00G73_A21MvAlm ;
      private string[] P00G73_A13MvATip ;
      private DateTime[] P00G73_A25MvAFec ;
      private string[] P00G73_A14MvACod ;
      private decimal[] P00G73_A1248MvADCant ;
      private int[] P00G73_A30MvADItem ;
      private string aP7_Filename ;
      private string aP8_ErrorMessage ;
      private ExcelDocumentI AV40ExcelDocument ;
      private GxFile AV13Archivo ;
   }

   public class r_pavalorizadoantiguedadcompraexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00G72( IGxContext context ,
                                             int AV73LinCod ,
                                             int AV103SublCod ,
                                             int AV41FamCod ,
                                             string AV90Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             int A21MvAlm ,
                                             int AV10AlmCod ,
                                             short A1158LinStk )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T3.[UniCod], T3.[ProdDsc], T1.[ProdCod], T5.[LinStk], T2.[MvAlm], T3.[FamCod], T3.[SublCod], T3.[LinCod], T4.[UniAbr], T5.[LinDsc], T1.[MvADItem] FROM (((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T4 ON T4.[UniCod] = T3.[UniCod]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T3.[LinCod])";
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV10AlmCod)");
         AddWhere(sWhereString, "(T5.[LinStk] = 1)");
         if ( ! (0==AV73LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV73LinCod)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV103SublCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV103SublCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV41FamCod) )
         {
            AddWhere(sWhereString, "(T3.[FamCod] = @AV41FamCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV90Prodcod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T3.[ProdDsc]";
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
                     return conditional_P00G72(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmP00G73;
          prmP00G73 = new Object[] {
          new ParDef("@AV45FHasta",GXType.Date,8,0) ,
          new ParDef("@AV91ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV10AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP00G72;
          prmP00G72 = new Object[] {
          new ParDef("@AV10AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV73LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV103SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV41FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV90Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00G72", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G72,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G73", "SELECT T1.[ProdCod], T2.[MvAlm], T1.[MvATip], T2.[MvAFec], T1.[MvACod], T1.[MvADCant], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T2.[MvAFec] <= @AV45FHasta) AND (T1.[ProdCod] = @AV91ProdCodC) AND (T2.[MvAlm] = @AV10AlmCod) AND (T1.[MvATip] = 'ING') ORDER BY T2.[MvAFec] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G73,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 5);
                ((string[]) buf[13])[0] = rslt.getString(12, 100);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
