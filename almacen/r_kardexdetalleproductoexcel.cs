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
   public class r_kardexdetalleproductoexcel : GXProcedure
   {
      public r_kardexdetalleproductoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_kardexdetalleproductoexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_AlmCod ,
                           ref string aP1_Prodcod ,
                           ref DateTime aP2_cDesde ,
                           ref DateTime aP3_cHasta ,
                           ref string aP4_CliCod ,
                           ref int aP5_MVCliOrigen ,
                           ref int aP6_MovCod ,
                           ref string aP7_CosCod ,
                           out string aP8_Filename ,
                           out string aP9_ErrorMessage )
      {
         this.AV14AlmCod = aP0_AlmCod;
         this.AV94Prodcod = aP1_Prodcod;
         this.AV19cDesde = aP2_cDesde;
         this.AV21cHasta = aP3_cHasta;
         this.AV22CliCod = aP4_CliCod;
         this.AV9MVCliOrigen = aP5_MVCliOrigen;
         this.AV80MovCod = aP6_MovCod;
         this.AV8CosCod = aP7_CosCod;
         this.AV49Filename = "" ;
         this.AV42ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_AlmCod=this.AV14AlmCod;
         aP1_Prodcod=this.AV94Prodcod;
         aP2_cDesde=this.AV19cDesde;
         aP3_cHasta=this.AV21cHasta;
         aP4_CliCod=this.AV22CliCod;
         aP5_MVCliOrigen=this.AV9MVCliOrigen;
         aP6_MovCod=this.AV80MovCod;
         aP7_CosCod=this.AV8CosCod;
         aP8_Filename=this.AV49Filename;
         aP9_ErrorMessage=this.AV42ErrorMessage;
      }

      public string executeUdp( ref int aP0_AlmCod ,
                                ref string aP1_Prodcod ,
                                ref DateTime aP2_cDesde ,
                                ref DateTime aP3_cHasta ,
                                ref string aP4_CliCod ,
                                ref int aP5_MVCliOrigen ,
                                ref int aP6_MovCod ,
                                ref string aP7_CosCod ,
                                out string aP8_Filename )
      {
         execute(ref aP0_AlmCod, ref aP1_Prodcod, ref aP2_cDesde, ref aP3_cHasta, ref aP4_CliCod, ref aP5_MVCliOrigen, ref aP6_MovCod, ref aP7_CosCod, out aP8_Filename, out aP9_ErrorMessage);
         return AV42ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_AlmCod ,
                                 ref string aP1_Prodcod ,
                                 ref DateTime aP2_cDesde ,
                                 ref DateTime aP3_cHasta ,
                                 ref string aP4_CliCod ,
                                 ref int aP5_MVCliOrigen ,
                                 ref int aP6_MovCod ,
                                 ref string aP7_CosCod ,
                                 out string aP8_Filename ,
                                 out string aP9_ErrorMessage )
      {
         r_kardexdetalleproductoexcel objr_kardexdetalleproductoexcel;
         objr_kardexdetalleproductoexcel = new r_kardexdetalleproductoexcel();
         objr_kardexdetalleproductoexcel.AV14AlmCod = aP0_AlmCod;
         objr_kardexdetalleproductoexcel.AV94Prodcod = aP1_Prodcod;
         objr_kardexdetalleproductoexcel.AV19cDesde = aP2_cDesde;
         objr_kardexdetalleproductoexcel.AV21cHasta = aP3_cHasta;
         objr_kardexdetalleproductoexcel.AV22CliCod = aP4_CliCod;
         objr_kardexdetalleproductoexcel.AV9MVCliOrigen = aP5_MVCliOrigen;
         objr_kardexdetalleproductoexcel.AV80MovCod = aP6_MovCod;
         objr_kardexdetalleproductoexcel.AV8CosCod = aP7_CosCod;
         objr_kardexdetalleproductoexcel.AV49Filename = "" ;
         objr_kardexdetalleproductoexcel.AV42ErrorMessage = "" ;
         objr_kardexdetalleproductoexcel.context.SetSubmitInitialConfig(context);
         objr_kardexdetalleproductoexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_kardexdetalleproductoexcel);
         aP0_AlmCod=this.AV14AlmCod;
         aP1_Prodcod=this.AV94Prodcod;
         aP2_cDesde=this.AV19cDesde;
         aP3_cHasta=this.AV21cHasta;
         aP4_CliCod=this.AV22CliCod;
         aP5_MVCliOrigen=this.AV9MVCliOrigen;
         aP6_MovCod=this.AV80MovCod;
         aP7_CosCod=this.AV8CosCod;
         aP8_Filename=this.AV49Filename;
         aP9_ErrorMessage=this.AV42ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_kardexdetalleproductoexcel)stateInfo).executePrivate();
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
         AV18Archivo.Source = "Excel/PlantillaKardexProducto.xlsx";
         AV93Path = AV18Archivo.GetPath();
         AV50FilenameOrigen = StringUtil.Trim( AV93Path) + "\\PlantillaKardexProducto.xlsx";
         AV49Filename = "Excel/KardexProducto" + ".xlsx";
         AV43ExcelDocument.Clear();
         AV43ExcelDocument.Template = AV50FilenameOrigen;
         AV43ExcelDocument.Open(AV49Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV20CellRow = 6;
         AV54FirstColumn = 1;
         AV72Item = 1;
         /* Using cursor P008B2 */
         pr_default.execute(0, new Object[] {AV14AlmCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A63AlmCod = P008B2_A63AlmCod[0];
            A436AlmDsc = P008B2_A436AlmDsc[0];
            AV12Almacen = A436AlmDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV51Filtro1 = "";
         AV52Filtro2 = "";
         /* Using cursor P008B3 */
         pr_default.execute(1, new Object[] {AV94Prodcod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A28ProdCod = P008B3_A28ProdCod[0];
            A55ProdDsc = P008B3_A55ProdDsc[0];
            AV52Filtro2 = A55ProdDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV10Saldo = 0.0000m;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV76LinCod ,
                                              AV94Prodcod ,
                                              AV22CliCod ,
                                              AV80MovCod ,
                                              AV9MVCliOrigen ,
                                              AV8CosCod ,
                                              A52LinCod ,
                                              A28ProdCod ,
                                              A15MVCliCod ,
                                              A22MvAMov ,
                                              A16MVCliOrigen ,
                                              A1287MVCCosto ,
                                              A1158LinStk } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P008B4 */
         pr_default.execute(2, new Object[] {AV76LinCod, AV94Prodcod, AV22CliCod, AV80MovCod, AV9MVCliOrigen, AV8CosCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK8B4 = false;
            A49UniCod = P008B4_A49UniCod[0];
            A1370MVSts = P008B4_A1370MVSts[0];
            A25MvAFec = P008B4_A25MvAFec[0];
            A15MVCliCod = P008B4_A15MVCliCod[0];
            n15MVCliCod = P008B4_n15MVCliCod[0];
            A22MvAMov = P008B4_A22MvAMov[0];
            A21MvAlm = P008B4_A21MvAlm[0];
            A28ProdCod = P008B4_A28ProdCod[0];
            A1287MVCCosto = P008B4_A1287MVCCosto[0];
            A1274MvAMovDsc = P008B4_A1274MvAMovDsc[0];
            A1278MvARef = P008B4_A1278MvARef[0];
            A24DocNum = P008B4_A24DocNum[0];
            n24DocNum = P008B4_n24DocNum[0];
            A1276MvAOcom = P008B4_A1276MvAOcom[0];
            A1248MvADCant = P008B4_A1248MvADCant[0];
            A14MvACod = P008B4_A14MvACod[0];
            A13MvATip = P008B4_A13MvATip[0];
            A1158LinStk = P008B4_A1158LinStk[0];
            A16MVCliOrigen = P008B4_A16MVCliOrigen[0];
            n16MVCliOrigen = P008B4_n16MVCliOrigen[0];
            A52LinCod = P008B4_A52LinCod[0];
            A55ProdDsc = P008B4_A55ProdDsc[0];
            A1997UniAbr = P008B4_A1997UniAbr[0];
            A30MvADItem = P008B4_A30MvADItem[0];
            A49UniCod = P008B4_A49UniCod[0];
            A52LinCod = P008B4_A52LinCod[0];
            A55ProdDsc = P008B4_A55ProdDsc[0];
            A1997UniAbr = P008B4_A1997UniAbr[0];
            A1158LinStk = P008B4_A1158LinStk[0];
            A1370MVSts = P008B4_A1370MVSts[0];
            A25MvAFec = P008B4_A25MvAFec[0];
            A15MVCliCod = P008B4_A15MVCliCod[0];
            n15MVCliCod = P008B4_n15MVCliCod[0];
            A22MvAMov = P008B4_A22MvAMov[0];
            A21MvAlm = P008B4_A21MvAlm[0];
            A1287MVCCosto = P008B4_A1287MVCCosto[0];
            A1278MvARef = P008B4_A1278MvARef[0];
            A24DocNum = P008B4_A24DocNum[0];
            n24DocNum = P008B4_n24DocNum[0];
            A1276MvAOcom = P008B4_A1276MvAOcom[0];
            A16MVCliOrigen = P008B4_A16MVCliOrigen[0];
            n16MVCliOrigen = P008B4_n16MVCliOrigen[0];
            A1274MvAMovDsc = P008B4_A1274MvAMovDsc[0];
            AV26Codigo = A28ProdCod;
            AV97Producto = StringUtil.Trim( A55ProdDsc);
            AV11UniAbr = A1997UniAbr;
            GXt_decimal1 = AV10Saldo;
            GXt_decimal2 = 0;
            GXt_decimal3 = 0;
            new GeneXus.Programs.almacen.pobtenersaldoproducto(context ).execute( ref  AV26Codigo, ref  AV14AlmCod, ref  AV19cDesde, out  GXt_decimal1, out  GXt_decimal2, out  GXt_decimal3) ;
            AV10Saldo = GXt_decimal1;
            AV53Final = AV10Saldo;
            /* Execute user subroutine: 'VALIDA' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               this.cleanup();
               if (true) return;
            }
            if ( ( AV55Flag == 0 ) || ! (Convert.ToDecimal(0)==AV10Saldo) )
            {
               /* Execute user subroutine: 'AGRUPA' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
            }
            AV70Ingresa = 0.0000m;
            AV101Salida = 0.0000m;
            AV109TIngresos = 0.0000m;
            AV115TSalidas = 0.0000m;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P008B4_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRK8B4 = false;
               A1370MVSts = P008B4_A1370MVSts[0];
               A25MvAFec = P008B4_A25MvAFec[0];
               A15MVCliCod = P008B4_A15MVCliCod[0];
               n15MVCliCod = P008B4_n15MVCliCod[0];
               A22MvAMov = P008B4_A22MvAMov[0];
               A21MvAlm = P008B4_A21MvAlm[0];
               A1287MVCCosto = P008B4_A1287MVCCosto[0];
               A1274MvAMovDsc = P008B4_A1274MvAMovDsc[0];
               A1278MvARef = P008B4_A1278MvARef[0];
               A24DocNum = P008B4_A24DocNum[0];
               n24DocNum = P008B4_n24DocNum[0];
               A1276MvAOcom = P008B4_A1276MvAOcom[0];
               A1248MvADCant = P008B4_A1248MvADCant[0];
               A14MvACod = P008B4_A14MvACod[0];
               A13MvATip = P008B4_A13MvATip[0];
               A30MvADItem = P008B4_A30MvADItem[0];
               A1370MVSts = P008B4_A1370MVSts[0];
               A25MvAFec = P008B4_A25MvAFec[0];
               A15MVCliCod = P008B4_A15MVCliCod[0];
               n15MVCliCod = P008B4_n15MVCliCod[0];
               A22MvAMov = P008B4_A22MvAMov[0];
               A21MvAlm = P008B4_A21MvAlm[0];
               A1287MVCCosto = P008B4_A1287MVCCosto[0];
               A1278MvARef = P008B4_A1278MvARef[0];
               A24DocNum = P008B4_A24DocNum[0];
               n24DocNum = P008B4_n24DocNum[0];
               A1276MvAOcom = P008B4_A1276MvAOcom[0];
               A1274MvAMovDsc = P008B4_A1274MvAMovDsc[0];
               if ( DateTimeUtil.ResetTime ( A25MvAFec ) <= DateTimeUtil.ResetTime ( AV21cHasta ) )
               {
                  if ( DateTimeUtil.ResetTime ( A25MvAFec ) >= DateTimeUtil.ResetTime ( AV19cDesde ) )
                  {
                     if ( StringUtil.StrCmp(A1370MVSts, "A") != 0 )
                     {
                        if ( StringUtil.StrCmp(A28ProdCod, AV26Codigo) == 0 )
                        {
                           if ( A21MvAlm == AV14AlmCod )
                           {
                              AV24Cliente = "";
                              AV85MvATip = A13MvATip;
                              AV81MvACod = A14MvACod;
                              AV82MVAFec = A25MvAFec;
                              AV86MVCCosto = A1287MVCCosto;
                              AV83MvAMovDsc = A1274MvAMovDsc;
                              /* Execute user subroutine: 'VALIDACLIENTE' */
                              S121 ();
                              if ( returnInSub )
                              {
                                 pr_default.close(2);
                                 this.cleanup();
                                 if (true) return;
                              }
                              AV39DocRef = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? A1278MvARef : A24DocNum);
                              AV84MvAOcom = StringUtil.Trim( A1276MvAOcom);
                              AV70Ingresa = ((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1248MvADCant : (decimal)(0));
                              AV101Salida = ((StringUtil.StrCmp(A13MvATip, "ING")!=0) ? A1248MvADCant : (decimal)(0));
                              AV53Final = (decimal)(AV53Final+(AV70Ingresa-AV101Salida));
                              AV109TIngresos = (decimal)(AV109TIngresos+AV70Ingresa);
                              AV115TSalidas = (decimal)(AV115TSalidas+AV101Salida);
                              /* Execute user subroutine: 'DETALLE' */
                              S141 ();
                              if ( returnInSub )
                              {
                                 pr_default.close(2);
                                 this.cleanup();
                                 if (true) return;
                              }
                           }
                        }
                     }
                  }
               }
               BRK8B4 = true;
               pr_default.readNext(2);
            }
            if ( AV55Flag == 0 )
            {
            }
            if ( ! BRK8B4 )
            {
               BRK8B4 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         AV43ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV43ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'VALIDA' Routine */
         returnInSub = false;
         AV55Flag = 1;
         /* Using cursor P008B5 */
         pr_default.execute(3, new Object[] {AV19cDesde, AV26Codigo, AV14AlmCod, AV21cHasta});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A28ProdCod = P008B5_A28ProdCod[0];
            A21MvAlm = P008B5_A21MvAlm[0];
            A1370MVSts = P008B5_A1370MVSts[0];
            A25MvAFec = P008B5_A25MvAFec[0];
            A14MvACod = P008B5_A14MvACod[0];
            A13MvATip = P008B5_A13MvATip[0];
            A30MvADItem = P008B5_A30MvADItem[0];
            A21MvAlm = P008B5_A21MvAlm[0];
            A1370MVSts = P008B5_A1370MVSts[0];
            A25MvAFec = P008B5_A25MvAFec[0];
            AV55Flag = 0;
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S121( )
      {
         /* 'VALIDACLIENTE' Routine */
         returnInSub = false;
         /* Using cursor P008B6 */
         pr_default.execute(4, new Object[] {AV85MvATip, AV81MvACod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A14MvACod = P008B6_A14MvACod[0];
            A13MvATip = P008B6_A13MvATip[0];
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86MVCCosto)) )
         {
            /* Using cursor P008B7 */
            pr_default.execute(5, new Object[] {AV86MVCCosto});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A79COSCod = P008B7_A79COSCod[0];
               A761COSDsc = P008B7_A761COSDsc[0];
               AV24Cliente = StringUtil.Trim( A761COSDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
         }
      }

      protected void S131( )
      {
         /* 'AGRUPA' Routine */
         returnInSub = false;
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV26Codigo);
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV97Producto);
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+6, 1, 1).Text = "Saldo Anterior";
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+7, 1, 1).Number = (double)(AV10Saldo);
         AV20CellRow = (int)(AV20CellRow+1);
      }

      protected void S141( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV85MvATip);
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV81MvACod);
         GXt_dtime4 = DateTimeUtil.ResetTime( AV82MVAFec ) ;
         AV43ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+2, 1, 1).Date = GXt_dtime4;
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV39DocRef);
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV84MvAOcom);
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV83MvAMovDsc);
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV24Cliente);
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+7, 1, 1).Number = (double)(AV70Ingresa);
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+8, 1, 1).Number = (double)(AV101Salida);
         AV43ExcelDocument.get_Cells(AV20CellRow, AV54FirstColumn+9, 1, 1).Number = (double)(AV53Final);
         AV20CellRow = (int)(AV20CellRow+1);
      }

      protected void S151( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV43ExcelDocument.ErrCode != 0 )
         {
            AV49Filename = "";
            AV42ErrorMessage = AV43ExcelDocument.ErrDescription;
            AV43ExcelDocument.Close();
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
         AV49Filename = "";
         AV42ErrorMessage = "";
         AV18Archivo = new GxFile(context.GetPhysicalPath());
         AV93Path = "";
         AV50FilenameOrigen = "";
         AV43ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P008B2_A63AlmCod = new int[1] ;
         P008B2_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         AV12Almacen = "";
         AV51Filtro1 = "";
         AV52Filtro2 = "";
         P008B3_A28ProdCod = new string[] {""} ;
         P008B3_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         A15MVCliCod = "";
         A1287MVCCosto = "";
         P008B4_A49UniCod = new int[1] ;
         P008B4_A1370MVSts = new string[] {""} ;
         P008B4_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008B4_A15MVCliCod = new string[] {""} ;
         P008B4_n15MVCliCod = new bool[] {false} ;
         P008B4_A22MvAMov = new int[1] ;
         P008B4_A21MvAlm = new int[1] ;
         P008B4_A28ProdCod = new string[] {""} ;
         P008B4_A1287MVCCosto = new string[] {""} ;
         P008B4_A1274MvAMovDsc = new string[] {""} ;
         P008B4_A1278MvARef = new string[] {""} ;
         P008B4_A24DocNum = new string[] {""} ;
         P008B4_n24DocNum = new bool[] {false} ;
         P008B4_A1276MvAOcom = new string[] {""} ;
         P008B4_A1248MvADCant = new decimal[1] ;
         P008B4_A14MvACod = new string[] {""} ;
         P008B4_A13MvATip = new string[] {""} ;
         P008B4_A1158LinStk = new short[1] ;
         P008B4_A16MVCliOrigen = new int[1] ;
         P008B4_n16MVCliOrigen = new bool[] {false} ;
         P008B4_A52LinCod = new int[1] ;
         P008B4_A55ProdDsc = new string[] {""} ;
         P008B4_A1997UniAbr = new string[] {""} ;
         P008B4_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         A1274MvAMovDsc = "";
         A1278MvARef = "";
         A24DocNum = "";
         A1276MvAOcom = "";
         A14MvACod = "";
         A13MvATip = "";
         A1997UniAbr = "";
         AV26Codigo = "";
         AV97Producto = "";
         AV11UniAbr = "";
         AV24Cliente = "";
         AV85MvATip = "";
         AV81MvACod = "";
         AV82MVAFec = DateTime.MinValue;
         AV86MVCCosto = "";
         AV83MvAMovDsc = "";
         AV39DocRef = "";
         AV84MvAOcom = "";
         P008B5_A28ProdCod = new string[] {""} ;
         P008B5_A21MvAlm = new int[1] ;
         P008B5_A1370MVSts = new string[] {""} ;
         P008B5_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008B5_A14MvACod = new string[] {""} ;
         P008B5_A13MvATip = new string[] {""} ;
         P008B5_A30MvADItem = new int[1] ;
         P008B6_A14MvACod = new string[] {""} ;
         P008B6_A13MvATip = new string[] {""} ;
         P008B7_A79COSCod = new string[] {""} ;
         P008B7_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_kardexdetalleproductoexcel__default(),
            new Object[][] {
                new Object[] {
               P008B2_A63AlmCod, P008B2_A436AlmDsc
               }
               , new Object[] {
               P008B3_A28ProdCod, P008B3_A55ProdDsc
               }
               , new Object[] {
               P008B4_A49UniCod, P008B4_A1370MVSts, P008B4_A25MvAFec, P008B4_A15MVCliCod, P008B4_n15MVCliCod, P008B4_A22MvAMov, P008B4_A21MvAlm, P008B4_A28ProdCod, P008B4_A1287MVCCosto, P008B4_A1274MvAMovDsc,
               P008B4_A1278MvARef, P008B4_A24DocNum, P008B4_n24DocNum, P008B4_A1276MvAOcom, P008B4_A1248MvADCant, P008B4_A14MvACod, P008B4_A13MvATip, P008B4_A1158LinStk, P008B4_A16MVCliOrigen, P008B4_n16MVCliOrigen,
               P008B4_A52LinCod, P008B4_A55ProdDsc, P008B4_A1997UniAbr, P008B4_A30MvADItem
               }
               , new Object[] {
               P008B5_A28ProdCod, P008B5_A21MvAlm, P008B5_A1370MVSts, P008B5_A25MvAFec, P008B5_A14MvACod, P008B5_A13MvATip, P008B5_A30MvADItem
               }
               , new Object[] {
               P008B6_A14MvACod, P008B6_A13MvATip
               }
               , new Object[] {
               P008B7_A79COSCod, P008B7_A761COSDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1158LinStk ;
      private short AV55Flag ;
      private int AV14AlmCod ;
      private int AV9MVCliOrigen ;
      private int AV80MovCod ;
      private int AV20CellRow ;
      private int AV54FirstColumn ;
      private int A63AlmCod ;
      private int AV76LinCod ;
      private int A52LinCod ;
      private int A22MvAMov ;
      private int A16MVCliOrigen ;
      private int A49UniCod ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private long AV72Item ;
      private decimal AV10Saldo ;
      private decimal A1248MvADCant ;
      private decimal GXt_decimal1 ;
      private decimal GXt_decimal2 ;
      private decimal GXt_decimal3 ;
      private decimal AV53Final ;
      private decimal AV70Ingresa ;
      private decimal AV101Salida ;
      private decimal AV109TIngresos ;
      private decimal AV115TSalidas ;
      private string AV94Prodcod ;
      private string AV22CliCod ;
      private string AV8CosCod ;
      private string AV93Path ;
      private string scmdbuf ;
      private string A436AlmDsc ;
      private string AV12Almacen ;
      private string AV51Filtro1 ;
      private string AV52Filtro2 ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A15MVCliCod ;
      private string A1287MVCCosto ;
      private string A1370MVSts ;
      private string A1274MvAMovDsc ;
      private string A1278MvARef ;
      private string A24DocNum ;
      private string A1276MvAOcom ;
      private string A14MvACod ;
      private string A13MvATip ;
      private string A1997UniAbr ;
      private string AV26Codigo ;
      private string AV97Producto ;
      private string AV11UniAbr ;
      private string AV24Cliente ;
      private string AV85MvATip ;
      private string AV81MvACod ;
      private string AV86MVCCosto ;
      private string AV83MvAMovDsc ;
      private string AV39DocRef ;
      private string AV84MvAOcom ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private DateTime GXt_dtime4 ;
      private DateTime AV19cDesde ;
      private DateTime AV21cHasta ;
      private DateTime A25MvAFec ;
      private DateTime AV82MVAFec ;
      private bool returnInSub ;
      private bool BRK8B4 ;
      private bool n15MVCliCod ;
      private bool n24DocNum ;
      private bool n16MVCliOrigen ;
      private string AV49Filename ;
      private string AV42ErrorMessage ;
      private string AV50FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_AlmCod ;
      private string aP1_Prodcod ;
      private DateTime aP2_cDesde ;
      private DateTime aP3_cHasta ;
      private string aP4_CliCod ;
      private int aP5_MVCliOrigen ;
      private int aP6_MovCod ;
      private string aP7_CosCod ;
      private IDataStoreProvider pr_default ;
      private int[] P008B2_A63AlmCod ;
      private string[] P008B2_A436AlmDsc ;
      private string[] P008B3_A28ProdCod ;
      private string[] P008B3_A55ProdDsc ;
      private int[] P008B4_A49UniCod ;
      private string[] P008B4_A1370MVSts ;
      private DateTime[] P008B4_A25MvAFec ;
      private string[] P008B4_A15MVCliCod ;
      private bool[] P008B4_n15MVCliCod ;
      private int[] P008B4_A22MvAMov ;
      private int[] P008B4_A21MvAlm ;
      private string[] P008B4_A28ProdCod ;
      private string[] P008B4_A1287MVCCosto ;
      private string[] P008B4_A1274MvAMovDsc ;
      private string[] P008B4_A1278MvARef ;
      private string[] P008B4_A24DocNum ;
      private bool[] P008B4_n24DocNum ;
      private string[] P008B4_A1276MvAOcom ;
      private decimal[] P008B4_A1248MvADCant ;
      private string[] P008B4_A14MvACod ;
      private string[] P008B4_A13MvATip ;
      private short[] P008B4_A1158LinStk ;
      private int[] P008B4_A16MVCliOrigen ;
      private bool[] P008B4_n16MVCliOrigen ;
      private int[] P008B4_A52LinCod ;
      private string[] P008B4_A55ProdDsc ;
      private string[] P008B4_A1997UniAbr ;
      private int[] P008B4_A30MvADItem ;
      private string[] P008B5_A28ProdCod ;
      private int[] P008B5_A21MvAlm ;
      private string[] P008B5_A1370MVSts ;
      private DateTime[] P008B5_A25MvAFec ;
      private string[] P008B5_A14MvACod ;
      private string[] P008B5_A13MvATip ;
      private int[] P008B5_A30MvADItem ;
      private string[] P008B6_A14MvACod ;
      private string[] P008B6_A13MvATip ;
      private string[] P008B7_A79COSCod ;
      private string[] P008B7_A761COSDsc ;
      private string aP8_Filename ;
      private string aP9_ErrorMessage ;
      private ExcelDocumentI AV43ExcelDocument ;
      private GxFile AV18Archivo ;
   }

   public class r_kardexdetalleproductoexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008B4( IGxContext context ,
                                             int AV76LinCod ,
                                             string AV94Prodcod ,
                                             string AV22CliCod ,
                                             int AV80MovCod ,
                                             int AV9MVCliOrigen ,
                                             string AV8CosCod ,
                                             int A52LinCod ,
                                             string A28ProdCod ,
                                             string A15MVCliCod ,
                                             int A22MvAMov ,
                                             int A16MVCliOrigen ,
                                             string A1287MVCCosto ,
                                             short A1158LinStk )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[6];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T5.[MVSts], T5.[MvAFec], T5.[MVCliCod], T5.[MvAMov] AS MvAMov, T5.[MvAlm], T1.[ProdCod], T5.[MVCCosto], T6.[MovDsc] AS MvAMovDsc, T5.[MvARef], T5.[DocNum], T5.[MvAOcom], T1.[MvADCant], T1.[MvACod], T1.[MvATip], T4.[LinStk], T5.[MVCliOrigen], T2.[LinCod], T2.[ProdDsc], T3.[UniAbr], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T5 ON T5.[MvATip] = T1.[MvATip] AND T5.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T6 ON T6.[MovCod] = T5.[MvAMov])";
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         if ( ! (0==AV76LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV76LinCod)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV94Prodcod)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CliCod)) )
         {
            AddWhere(sWhereString, "(T5.[MVCliCod] = @AV22CliCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV80MovCod) )
         {
            AddWhere(sWhereString, "(T5.[MvAMov] = @AV80MovCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV9MVCliOrigen) )
         {
            AddWhere(sWhereString, "(T5.[MVCliOrigen] = @AV9MVCliOrigen)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CosCod)) )
         {
            AddWhere(sWhereString, "(T5.[MVCCosto] = @AV8CosCod)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T5.[MvAFec], T1.[MvATip], T1.[MvACod]";
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
               case 2 :
                     return conditional_P008B4(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] );
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
          Object[] prmP008B2;
          prmP008B2 = new Object[] {
          new ParDef("@AV14AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP008B3;
          prmP008B3 = new Object[] {
          new ParDef("@AV94Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP008B5;
          prmP008B5 = new Object[] {
          new ParDef("@AV19cDesde",GXType.Date,8,0) ,
          new ParDef("@AV26Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV14AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV21cHasta",GXType.Date,8,0)
          };
          Object[] prmP008B6;
          prmP008B6 = new Object[] {
          new ParDef("@AV85MvATip",GXType.NChar,3,0) ,
          new ParDef("@AV81MvACod",GXType.NChar,12,0)
          };
          Object[] prmP008B7;
          prmP008B7 = new Object[] {
          new ParDef("@AV86MVCCosto",GXType.NChar,10,0)
          };
          Object[] prmP008B4;
          prmP008B4 = new Object[] {
          new ParDef("@AV76LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV94Prodcod",GXType.NChar,15,0) ,
          new ParDef("@AV22CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV80MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV9MVCliOrigen",GXType.Int32,6,0) ,
          new ParDef("@AV8CosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008B2", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV14AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008B3", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV94Prodcod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008B4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008B5", "SELECT T1.[ProdCod], T2.[MvAlm], T2.[MVSts], T2.[MvAFec], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T2.[MvAFec] >= @AV19cDesde) AND (T2.[MVSts] <> 'A') AND (T1.[ProdCod] = @AV26Codigo) AND (T2.[MvAlm] = @AV14AlmCod) AND (T2.[MvAFec] <= @AV21cHasta) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008B6", "SELECT [MvACod], [MvATip] FROM [AGUIAS] WHERE [MvATip] = @AV85MvATip and [MvACod] = @AV81MvACod ORDER BY [MvATip], [MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008B7", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV86MVCCosto ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B7,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 15);
                ((string[]) buf[8])[0] = rslt.getString(8, 10);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((string[]) buf[10])[0] = rslt.getString(10, 20);
                ((string[]) buf[11])[0] = rslt.getString(11, 12);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
                ((string[]) buf[15])[0] = rslt.getString(14, 12);
                ((string[]) buf[16])[0] = rslt.getString(15, 3);
                ((short[]) buf[17])[0] = rslt.getShort(16);
                ((int[]) buf[18])[0] = rslt.getInt(17);
                ((bool[]) buf[19])[0] = rslt.wasNull(17);
                ((int[]) buf[20])[0] = rslt.getInt(18);
                ((string[]) buf[21])[0] = rslt.getString(19, 100);
                ((string[]) buf[22])[0] = rslt.getString(20, 5);
                ((int[]) buf[23])[0] = rslt.getInt(21);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
