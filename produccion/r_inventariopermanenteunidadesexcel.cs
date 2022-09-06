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
   public class r_inventariopermanenteunidadesexcel : GXProcedure
   {
      public r_inventariopermanenteunidadesexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_inventariopermanenteunidadesexcel( IGxContext context )
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
         this.AV69LinCod = aP0_LinCod;
         this.AV95SublCod = aP1_SublCod;
         this.AV38FamCod = aP2_FamCod;
         this.AV8AlmCod = aP3_AlmCod;
         this.AV82Prodcod = aP4_Prodcod;
         this.AV39FDesde = aP5_FDesde;
         this.AV42FHasta = aP6_FHasta;
         this.AV43Filename = "" ;
         this.AV36ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV69LinCod;
         aP1_SublCod=this.AV95SublCod;
         aP2_FamCod=this.AV38FamCod;
         aP3_AlmCod=this.AV8AlmCod;
         aP4_Prodcod=this.AV82Prodcod;
         aP5_FDesde=this.AV39FDesde;
         aP6_FHasta=this.AV42FHasta;
         aP7_Filename=this.AV43Filename;
         aP8_ErrorMessage=this.AV36ErrorMessage;
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
         return AV36ErrorMessage ;
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
         r_inventariopermanenteunidadesexcel objr_inventariopermanenteunidadesexcel;
         objr_inventariopermanenteunidadesexcel = new r_inventariopermanenteunidadesexcel();
         objr_inventariopermanenteunidadesexcel.AV69LinCod = aP0_LinCod;
         objr_inventariopermanenteunidadesexcel.AV95SublCod = aP1_SublCod;
         objr_inventariopermanenteunidadesexcel.AV38FamCod = aP2_FamCod;
         objr_inventariopermanenteunidadesexcel.AV8AlmCod = aP3_AlmCod;
         objr_inventariopermanenteunidadesexcel.AV82Prodcod = aP4_Prodcod;
         objr_inventariopermanenteunidadesexcel.AV39FDesde = aP5_FDesde;
         objr_inventariopermanenteunidadesexcel.AV42FHasta = aP6_FHasta;
         objr_inventariopermanenteunidadesexcel.AV43Filename = "" ;
         objr_inventariopermanenteunidadesexcel.AV36ErrorMessage = "" ;
         objr_inventariopermanenteunidadesexcel.context.SetSubmitInitialConfig(context);
         objr_inventariopermanenteunidadesexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_inventariopermanenteunidadesexcel);
         aP0_LinCod=this.AV69LinCod;
         aP1_SublCod=this.AV95SublCod;
         aP2_FamCod=this.AV38FamCod;
         aP3_AlmCod=this.AV8AlmCod;
         aP4_Prodcod=this.AV82Prodcod;
         aP5_FDesde=this.AV39FDesde;
         aP6_FHasta=this.AV42FHasta;
         aP7_Filename=this.AV43Filename;
         aP8_ErrorMessage=this.AV36ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_inventariopermanenteunidadesexcel)stateInfo).executePrivate();
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
         AV11Archivo.Source = "Excel/PlantillasInventarioPermanenteUnidades.xlsx";
         AV81Path = AV11Archivo.GetPath();
         AV44FilenameOrigen = StringUtil.Trim( AV81Path) + "\\PlantillasInventarioPermanenteUnidades.xlsx";
         AV43Filename = "Excel/InventarioPermanenteUnidades" + ".xlsx";
         AV37ExcelDocument.Clear();
         AV37ExcelDocument.Template = AV44FilenameOrigen;
         AV37ExcelDocument.Open(AV43Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13CellRow = 6;
         AV46FirstColumn = 1;
         AV107Tot1 = 0;
         AV108Tot2 = 0;
         AV109Tot3 = 0;
         AV110Tot4 = 0;
         AV111Tot5 = 0;
         AV112Tot6 = 0;
         AV113Tot7 = 0;
         AV114Tot8 = 0;
         AV115Tot9 = 0;
         AV20CostoTotal = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV69LinCod ,
                                              AV95SublCod ,
                                              AV38FamCod ,
                                              AV82Prodcod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A28ProdCod ,
                                              A1370MVSts ,
                                              A21MvAlm ,
                                              AV8AlmCod ,
                                              A1158LinStk ,
                                              A1269MvAlmCos } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00FW2 */
         pr_default.execute(0, new Object[] {AV8AlmCod, AV69LinCod, AV95SublCod, AV38FamCod, AV82Prodcod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKFW2 = false;
            A13MvATip = P00FW2_A13MvATip[0];
            A14MvACod = P00FW2_A14MvACod[0];
            A49UniCod = P00FW2_A49UniCod[0];
            A21MvAlm = P00FW2_A21MvAlm[0];
            A1158LinStk = P00FW2_A1158LinStk[0];
            A1269MvAlmCos = P00FW2_A1269MvAlmCos[0];
            A28ProdCod = P00FW2_A28ProdCod[0];
            A55ProdDsc = P00FW2_A55ProdDsc[0];
            A1370MVSts = P00FW2_A1370MVSts[0];
            A50FamCod = P00FW2_A50FamCod[0];
            n50FamCod = P00FW2_n50FamCod[0];
            A51SublCod = P00FW2_A51SublCod[0];
            n51SublCod = P00FW2_n51SublCod[0];
            A52LinCod = P00FW2_A52LinCod[0];
            A1997UniAbr = P00FW2_A1997UniAbr[0];
            A30MvADItem = P00FW2_A30MvADItem[0];
            A21MvAlm = P00FW2_A21MvAlm[0];
            A1370MVSts = P00FW2_A1370MVSts[0];
            A1269MvAlmCos = P00FW2_A1269MvAlmCos[0];
            A49UniCod = P00FW2_A49UniCod[0];
            A55ProdDsc = P00FW2_A55ProdDsc[0];
            A50FamCod = P00FW2_A50FamCod[0];
            n50FamCod = P00FW2_n50FamCod[0];
            A51SublCod = P00FW2_A51SublCod[0];
            n51SublCod = P00FW2_n51SublCod[0];
            A52LinCod = P00FW2_A52LinCod[0];
            A1997UniAbr = P00FW2_A1997UniAbr[0];
            A1158LinStk = P00FW2_A1158LinStk[0];
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00FW2_A55ProdDsc[0], A55ProdDsc) == 0 ) )
            {
               BRKFW2 = false;
               A13MvATip = P00FW2_A13MvATip[0];
               A14MvACod = P00FW2_A14MvACod[0];
               A28ProdCod = P00FW2_A28ProdCod[0];
               A30MvADItem = P00FW2_A30MvADItem[0];
               BRKFW2 = true;
               pr_default.readNext(0);
            }
            AV83ProdCodC = StringUtil.Trim( A28ProdCod);
            AV85Producto = A55ProdDsc;
            AV127UniAbr = A1997UniAbr;
            AV12CanIni = 0;
            AV97TCosIni = 0;
            AV98TCosTIni = 0;
            AV62Ing1 = 0;
            AV64IngCU = 0;
            AV63IngCT = 0;
            AV124TTIngreso = 0;
            AV102TIngresoCT = 0;
            AV103TIngresoCU = 0;
            AV89Sal1 = 0;
            AV91SalCU = 0;
            AV90SalCT = 0;
            AV126TTSalida = 0;
            AV119TsalidaCT = 0;
            AV120TSalidaCU = 0;
            AV45Final = 0;
            new GeneXus.Programs.contabilidad.paobtenersaldocostoproductofechas(context ).execute( ref  AV39FDesde, ref  AV8AlmCod, ref  AV83ProdCodC, out  AV92Saldo, out  AV21CostoU) ;
            AV45Final = AV92Saldo;
            /* Execute user subroutine: 'VALIDA' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV65Ingresa = 0;
            AV93Salida = 0;
            AV14Ceros = 0;
            AV101TIngreso = ((AV92Saldo>Convert.ToDecimal(0)) ? AV92Saldo : (decimal)(0));
            AV118TSalida = ((AV92Saldo<Convert.ToDecimal(0)) ? AV92Saldo : (decimal)(0));
            if ( ( AV92Saldo != Convert.ToDecimal( 0 )) )
            {
               AV12CanIni = AV101TIngreso;
            }
            /* Execute user subroutine: 'DETALLEMOVIMIENTO' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( ( AV47Flag == 0 ) || ( AV92Saldo != Convert.ToDecimal( 0 )) )
            {
               /* Execute user subroutine: 'TOTALAGRUPA' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
            }
            AV107Tot1 = (decimal)(AV107Tot1+AV92Saldo);
            AV108Tot2 = (decimal)(AV108Tot2+AV124TTIngreso);
            AV109Tot3 = (decimal)(AV109Tot3+AV126TTSalida);
            AV128SaldoFinal = (decimal)(AV128SaldoFinal+AV45Final);
            if ( ! BRKFW2 )
            {
               BRKFW2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV37ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV37ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'VALIDA' Routine */
         returnInSub = false;
         AV47Flag = 1;
         /* Using cursor P00FW3 */
         pr_default.execute(1, new Object[] {AV39FDesde, AV83ProdCodC, AV8AlmCod, AV42FHasta});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A28ProdCod = P00FW3_A28ProdCod[0];
            A21MvAlm = P00FW3_A21MvAlm[0];
            A1370MVSts = P00FW3_A1370MVSts[0];
            A25MvAFec = P00FW3_A25MvAFec[0];
            A19MVCDesItem = P00FW3_A19MVCDesItem[0];
            n19MVCDesItem = P00FW3_n19MVCDesItem[0];
            A14MvACod = P00FW3_A14MvACod[0];
            A13MvATip = P00FW3_A13MvATip[0];
            A30MvADItem = P00FW3_A30MvADItem[0];
            A21MvAlm = P00FW3_A21MvAlm[0];
            A1370MVSts = P00FW3_A1370MVSts[0];
            A25MvAFec = P00FW3_A25MvAFec[0];
            A19MVCDesItem = P00FW3_A19MVCDesItem[0];
            n19MVCDesItem = P00FW3_n19MVCDesItem[0];
            AV47Flag = 0;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'DETALLEMOVIMIENTO' Routine */
         returnInSub = false;
         /* Using cursor P00FW4 */
         pr_default.execute(2, new Object[] {AV39FDesde, AV83ProdCodC, AV8AlmCod, AV42FHasta});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A22MvAMov = P00FW4_A22MvAMov[0];
            A28ProdCod = P00FW4_A28ProdCod[0];
            A21MvAlm = P00FW4_A21MvAlm[0];
            A1370MVSts = P00FW4_A1370MVSts[0];
            A25MvAFec = P00FW4_A25MvAFec[0];
            A1278MvARef = P00FW4_A1278MvARef[0];
            A1276MvAOcom = P00FW4_A1276MvAOcom[0];
            A24DocNum = P00FW4_A24DocNum[0];
            n24DocNum = P00FW4_n24DocNum[0];
            A1248MvADCant = P00FW4_A1248MvADCant[0];
            A1237MovAbr = P00FW4_A1237MovAbr[0];
            n1237MovAbr = P00FW4_n1237MovAbr[0];
            A14MvACod = P00FW4_A14MvACod[0];
            A13MvATip = P00FW4_A13MvATip[0];
            A19MVCDesItem = P00FW4_A19MVCDesItem[0];
            n19MVCDesItem = P00FW4_n19MVCDesItem[0];
            A30MvADItem = P00FW4_A30MvADItem[0];
            A22MvAMov = P00FW4_A22MvAMov[0];
            A21MvAlm = P00FW4_A21MvAlm[0];
            A1370MVSts = P00FW4_A1370MVSts[0];
            A25MvAFec = P00FW4_A25MvAFec[0];
            A1278MvARef = P00FW4_A1278MvARef[0];
            A1276MvAOcom = P00FW4_A1276MvAOcom[0];
            A24DocNum = P00FW4_A24DocNum[0];
            n24DocNum = P00FW4_n24DocNum[0];
            A19MVCDesItem = P00FW4_A19MVCDesItem[0];
            n19MVCDesItem = P00FW4_n19MVCDesItem[0];
            A1237MovAbr = P00FW4_A1237MovAbr[0];
            n1237MovAbr = P00FW4_n1237MovAbr[0];
            AV75MVATip = A13MvATip;
            AV74MVACod = A14MvACod;
            AV33DocRef = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? (String.IsNullOrEmpty(StringUtil.RTrim( A1276MvAOcom)) ? A1278MvARef : A1276MvAOcom) : A24DocNum);
            AV65Ingresa = ((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1248MvADCant : (decimal)(0));
            AV93Salida = ((StringUtil.StrCmp(A13MvATip, "ING")!=0) ? A1248MvADCant : (decimal)(0));
            AV21CostoU = 0;
            AV19CostoT = 0;
            AV73MovAbr = A1237MovAbr;
            AV62Ing1 = 0;
            AV64IngCU = 0;
            AV63IngCT = 0;
            AV89Sal1 = 0;
            AV91SalCU = 0;
            AV90SalCT = 0;
            if ( StringUtil.StrCmp(A13MvATip, "ING") == 0 )
            {
               AV62Ing1 = AV65Ingresa;
            }
            else
            {
               AV89Sal1 = AV93Salida;
            }
            AV124TTIngreso = (decimal)(AV124TTIngreso+AV62Ing1);
            AV126TTSalida = (decimal)(AV126TTSalida+AV89Sal1);
            AV45Final = (decimal)(AV45Final+((AV65Ingresa-AV93Salida)));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'TOTALAGRUPA' Routine */
         returnInSub = false;
         AV37ExcelDocument.get_Cells(AV13CellRow, AV46FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV83ProdCodC);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV46FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV85Producto);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV46FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV127UniAbr);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV46FirstColumn+3, 1, 1).Number = (double)(AV12CanIni);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV46FirstColumn+4, 1, 1).Number = (double)(AV124TTIngreso);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV46FirstColumn+5, 1, 1).Number = (double)(AV126TTSalida);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV46FirstColumn+6, 1, 1).Number = (double)(AV45Final);
         AV13CellRow = (int)(AV13CellRow+1);
      }

      protected void S141( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV37ExcelDocument.ErrCode != 0 )
         {
            AV43Filename = "";
            AV36ErrorMessage = AV37ExcelDocument.ErrDescription;
            AV37ExcelDocument.Close();
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
         AV43Filename = "";
         AV36ErrorMessage = "";
         AV11Archivo = new GxFile(context.GetPhysicalPath());
         AV81Path = "";
         AV44FilenameOrigen = "";
         AV37ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         A28ProdCod = "";
         A1370MVSts = "";
         P00FW2_A13MvATip = new string[] {""} ;
         P00FW2_A14MvACod = new string[] {""} ;
         P00FW2_A49UniCod = new int[1] ;
         P00FW2_A21MvAlm = new int[1] ;
         P00FW2_A1158LinStk = new short[1] ;
         P00FW2_A1269MvAlmCos = new short[1] ;
         P00FW2_A28ProdCod = new string[] {""} ;
         P00FW2_A55ProdDsc = new string[] {""} ;
         P00FW2_A1370MVSts = new string[] {""} ;
         P00FW2_A50FamCod = new int[1] ;
         P00FW2_n50FamCod = new bool[] {false} ;
         P00FW2_A51SublCod = new int[1] ;
         P00FW2_n51SublCod = new bool[] {false} ;
         P00FW2_A52LinCod = new int[1] ;
         P00FW2_A1997UniAbr = new string[] {""} ;
         P00FW2_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A55ProdDsc = "";
         A1997UniAbr = "";
         AV83ProdCodC = "";
         AV85Producto = "";
         AV127UniAbr = "";
         P00FW3_A28ProdCod = new string[] {""} ;
         P00FW3_A21MvAlm = new int[1] ;
         P00FW3_A1370MVSts = new string[] {""} ;
         P00FW3_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FW3_A19MVCDesItem = new int[1] ;
         P00FW3_n19MVCDesItem = new bool[] {false} ;
         P00FW3_A14MvACod = new string[] {""} ;
         P00FW3_A13MvATip = new string[] {""} ;
         P00FW3_A30MvADItem = new int[1] ;
         A25MvAFec = DateTime.MinValue;
         P00FW4_A22MvAMov = new int[1] ;
         P00FW4_A28ProdCod = new string[] {""} ;
         P00FW4_A21MvAlm = new int[1] ;
         P00FW4_A1370MVSts = new string[] {""} ;
         P00FW4_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FW4_A1278MvARef = new string[] {""} ;
         P00FW4_A1276MvAOcom = new string[] {""} ;
         P00FW4_A24DocNum = new string[] {""} ;
         P00FW4_n24DocNum = new bool[] {false} ;
         P00FW4_A1248MvADCant = new decimal[1] ;
         P00FW4_A1237MovAbr = new string[] {""} ;
         P00FW4_n1237MovAbr = new bool[] {false} ;
         P00FW4_A14MvACod = new string[] {""} ;
         P00FW4_A13MvATip = new string[] {""} ;
         P00FW4_A19MVCDesItem = new int[1] ;
         P00FW4_n19MVCDesItem = new bool[] {false} ;
         P00FW4_A30MvADItem = new int[1] ;
         A1278MvARef = "";
         A1276MvAOcom = "";
         A24DocNum = "";
         A1237MovAbr = "";
         AV75MVATip = "";
         AV74MVACod = "";
         AV33DocRef = "";
         AV73MovAbr = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_inventariopermanenteunidadesexcel__default(),
            new Object[][] {
                new Object[] {
               P00FW2_A13MvATip, P00FW2_A14MvACod, P00FW2_A49UniCod, P00FW2_A21MvAlm, P00FW2_A1158LinStk, P00FW2_A1269MvAlmCos, P00FW2_A28ProdCod, P00FW2_A55ProdDsc, P00FW2_A1370MVSts, P00FW2_A50FamCod,
               P00FW2_n50FamCod, P00FW2_A51SublCod, P00FW2_n51SublCod, P00FW2_A52LinCod, P00FW2_A1997UniAbr, P00FW2_A30MvADItem
               }
               , new Object[] {
               P00FW3_A28ProdCod, P00FW3_A21MvAlm, P00FW3_A1370MVSts, P00FW3_A25MvAFec, P00FW3_A19MVCDesItem, P00FW3_n19MVCDesItem, P00FW3_A14MvACod, P00FW3_A13MvATip, P00FW3_A30MvADItem
               }
               , new Object[] {
               P00FW4_A22MvAMov, P00FW4_A28ProdCod, P00FW4_A21MvAlm, P00FW4_A1370MVSts, P00FW4_A25MvAFec, P00FW4_A1278MvARef, P00FW4_A1276MvAOcom, P00FW4_A24DocNum, P00FW4_n24DocNum, P00FW4_A1248MvADCant,
               P00FW4_A1237MovAbr, P00FW4_n1237MovAbr, P00FW4_A14MvACod, P00FW4_A13MvATip, P00FW4_A19MVCDesItem, P00FW4_n19MVCDesItem, P00FW4_A30MvADItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1158LinStk ;
      private short A1269MvAlmCos ;
      private short AV47Flag ;
      private int AV69LinCod ;
      private int AV95SublCod ;
      private int AV38FamCod ;
      private int AV8AlmCod ;
      private int AV13CellRow ;
      private int AV46FirstColumn ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A21MvAlm ;
      private int A49UniCod ;
      private int A30MvADItem ;
      private int A19MVCDesItem ;
      private int A22MvAMov ;
      private decimal AV107Tot1 ;
      private decimal AV108Tot2 ;
      private decimal AV109Tot3 ;
      private decimal AV110Tot4 ;
      private decimal AV111Tot5 ;
      private decimal AV112Tot6 ;
      private decimal AV113Tot7 ;
      private decimal AV114Tot8 ;
      private decimal AV115Tot9 ;
      private decimal AV20CostoTotal ;
      private decimal AV12CanIni ;
      private decimal AV97TCosIni ;
      private decimal AV98TCosTIni ;
      private decimal AV62Ing1 ;
      private decimal AV64IngCU ;
      private decimal AV63IngCT ;
      private decimal AV124TTIngreso ;
      private decimal AV102TIngresoCT ;
      private decimal AV103TIngresoCU ;
      private decimal AV89Sal1 ;
      private decimal AV91SalCU ;
      private decimal AV90SalCT ;
      private decimal AV126TTSalida ;
      private decimal AV119TsalidaCT ;
      private decimal AV120TSalidaCU ;
      private decimal AV45Final ;
      private decimal AV92Saldo ;
      private decimal AV21CostoU ;
      private decimal AV65Ingresa ;
      private decimal AV93Salida ;
      private decimal AV14Ceros ;
      private decimal AV101TIngreso ;
      private decimal AV118TSalida ;
      private decimal AV128SaldoFinal ;
      private decimal A1248MvADCant ;
      private decimal AV19CostoT ;
      private string AV82Prodcod ;
      private string AV81Path ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A1370MVSts ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A55ProdDsc ;
      private string A1997UniAbr ;
      private string AV83ProdCodC ;
      private string AV85Producto ;
      private string AV127UniAbr ;
      private string A1278MvARef ;
      private string A1276MvAOcom ;
      private string A24DocNum ;
      private string A1237MovAbr ;
      private string AV75MVATip ;
      private string AV74MVACod ;
      private string AV33DocRef ;
      private string AV73MovAbr ;
      private DateTime AV39FDesde ;
      private DateTime AV42FHasta ;
      private DateTime A25MvAFec ;
      private bool returnInSub ;
      private bool BRKFW2 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool n19MVCDesItem ;
      private bool n24DocNum ;
      private bool n1237MovAbr ;
      private string AV43Filename ;
      private string AV36ErrorMessage ;
      private string AV44FilenameOrigen ;
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
      private string[] P00FW2_A13MvATip ;
      private string[] P00FW2_A14MvACod ;
      private int[] P00FW2_A49UniCod ;
      private int[] P00FW2_A21MvAlm ;
      private short[] P00FW2_A1158LinStk ;
      private short[] P00FW2_A1269MvAlmCos ;
      private string[] P00FW2_A28ProdCod ;
      private string[] P00FW2_A55ProdDsc ;
      private string[] P00FW2_A1370MVSts ;
      private int[] P00FW2_A50FamCod ;
      private bool[] P00FW2_n50FamCod ;
      private int[] P00FW2_A51SublCod ;
      private bool[] P00FW2_n51SublCod ;
      private int[] P00FW2_A52LinCod ;
      private string[] P00FW2_A1997UniAbr ;
      private int[] P00FW2_A30MvADItem ;
      private string[] P00FW3_A28ProdCod ;
      private int[] P00FW3_A21MvAlm ;
      private string[] P00FW3_A1370MVSts ;
      private DateTime[] P00FW3_A25MvAFec ;
      private int[] P00FW3_A19MVCDesItem ;
      private bool[] P00FW3_n19MVCDesItem ;
      private string[] P00FW3_A14MvACod ;
      private string[] P00FW3_A13MvATip ;
      private int[] P00FW3_A30MvADItem ;
      private int[] P00FW4_A22MvAMov ;
      private string[] P00FW4_A28ProdCod ;
      private int[] P00FW4_A21MvAlm ;
      private string[] P00FW4_A1370MVSts ;
      private DateTime[] P00FW4_A25MvAFec ;
      private string[] P00FW4_A1278MvARef ;
      private string[] P00FW4_A1276MvAOcom ;
      private string[] P00FW4_A24DocNum ;
      private bool[] P00FW4_n24DocNum ;
      private decimal[] P00FW4_A1248MvADCant ;
      private string[] P00FW4_A1237MovAbr ;
      private bool[] P00FW4_n1237MovAbr ;
      private string[] P00FW4_A14MvACod ;
      private string[] P00FW4_A13MvATip ;
      private int[] P00FW4_A19MVCDesItem ;
      private bool[] P00FW4_n19MVCDesItem ;
      private int[] P00FW4_A30MvADItem ;
      private string aP7_Filename ;
      private string aP8_ErrorMessage ;
      private ExcelDocumentI AV37ExcelDocument ;
      private GxFile AV11Archivo ;
   }

   public class r_inventariopermanenteunidadesexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FW2( IGxContext context ,
                                             int AV69LinCod ,
                                             int AV95SublCod ,
                                             int AV38FamCod ,
                                             string AV82Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             string A1370MVSts ,
                                             int A21MvAlm ,
                                             int AV8AlmCod ,
                                             short A1158LinStk ,
                                             short A1269MvAlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T4.[UniCod], T2.[MvAlm] AS MvAlm, T6.[LinStk], T3.[AlmCos] AS MvAlmCos, T1.[ProdCod], T4.[ProdDsc], T2.[MVSts], T4.[FamCod], T4.[SublCod], T4.[LinCod], T5.[UniAbr], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T5 ON T5.[UniCod] = T4.[UniCod]) INNER JOIN [CLINEAPROD] T6 ON T6.[LinCod] = T4.[LinCod])";
         AddWhere(sWhereString, "(T2.[MVSts] <> 'A')");
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV8AlmCod)");
         AddWhere(sWhereString, "(T6.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[AlmCos] = 1)");
         if ( ! (0==AV69LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV69LinCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV95SublCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV95SublCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV38FamCod) )
         {
            AddWhere(sWhereString, "(T4.[FamCod] = @AV38FamCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV82Prodcod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.[ProdDsc], T1.[ProdCod]";
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
                     return conditional_P00FW2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FW3;
          prmP00FW3 = new Object[] {
          new ParDef("@AV39FDesde",GXType.Date,8,0) ,
          new ParDef("@AV83ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV8AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV42FHasta",GXType.Date,8,0)
          };
          Object[] prmP00FW4;
          prmP00FW4 = new Object[] {
          new ParDef("@AV39FDesde",GXType.Date,8,0) ,
          new ParDef("@AV83ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV8AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV42FHasta",GXType.Date,8,0)
          };
          Object[] prmP00FW2;
          prmP00FW2 = new Object[] {
          new ParDef("@AV8AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV69LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV95SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV38FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV82Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FW2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FW2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FW3", "SELECT T1.[ProdCod], T2.[MvAlm] AS MvAlm, T2.[MVSts], T2.[MvAFec], T2.[MVCDesItem], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T2.[MvAFec] >= @AV39FDesde) AND (T2.[MVSts] <> 'A') AND (T1.[ProdCod] = @AV83ProdCodC) AND (T2.[MvAlm] = @AV8AlmCod) AND (T2.[MvAFec] <= @AV42FHasta) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod], T2.[MVCDesItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FW3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FW4", "SELECT T2.[MvAMov] AS MvAMov, T1.[ProdCod], T2.[MvAlm] AS MvAlm, T2.[MVSts], T2.[MvAFec], T2.[MvARef], T2.[MvAOcom], T2.[DocNum], T1.[MvADCant], T3.[MovAbr], T1.[MvACod], T1.[MvATip], T2.[MVCDesItem], T1.[MvADItem] FROM (([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T3 ON T3.[MovCod] = T2.[MvAMov]) WHERE (T2.[MvAFec] >= @AV39FDesde) AND (T2.[MVSts] <> 'A') AND (T1.[ProdCod] = @AV83ProdCodC) AND (T2.[MvAlm] = @AV8AlmCod) AND (T2.[MvAFec] <= @AV42FHasta) ORDER BY T2.[MvAFec], T2.[MVCDesItem], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FW4,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 1);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 5);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 12);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((string[]) buf[7])[0] = rslt.getString(8, 12);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 5);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 12);
                ((string[]) buf[13])[0] = rslt.getString(12, 3);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                ((bool[]) buf[15])[0] = rslt.wasNull(13);
                ((int[]) buf[16])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
