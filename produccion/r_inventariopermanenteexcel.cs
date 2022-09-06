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
   public class r_inventariopermanenteexcel : GXProcedure
   {
      public r_inventariopermanenteexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_inventariopermanenteexcel( IGxContext context )
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
         this.AV82LinCod = aP0_LinCod;
         this.AV81SublCod = aP1_SublCod;
         this.AV80FamCod = aP2_FamCod;
         this.AV79AlmCod = aP3_AlmCod;
         this.AV78Prodcod = aP4_Prodcod;
         this.AV77FDesde = aP5_FDesde;
         this.AV76FHasta = aP6_FHasta;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV82LinCod;
         aP1_SublCod=this.AV81SublCod;
         aP2_FamCod=this.AV80FamCod;
         aP3_AlmCod=this.AV79AlmCod;
         aP4_Prodcod=this.AV78Prodcod;
         aP5_FDesde=this.AV77FDesde;
         aP6_FHasta=this.AV76FHasta;
         aP7_Filename=this.AV10Filename;
         aP8_ErrorMessage=this.AV11ErrorMessage;
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
         return AV11ErrorMessage ;
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
         r_inventariopermanenteexcel objr_inventariopermanenteexcel;
         objr_inventariopermanenteexcel = new r_inventariopermanenteexcel();
         objr_inventariopermanenteexcel.AV82LinCod = aP0_LinCod;
         objr_inventariopermanenteexcel.AV81SublCod = aP1_SublCod;
         objr_inventariopermanenteexcel.AV80FamCod = aP2_FamCod;
         objr_inventariopermanenteexcel.AV79AlmCod = aP3_AlmCod;
         objr_inventariopermanenteexcel.AV78Prodcod = aP4_Prodcod;
         objr_inventariopermanenteexcel.AV77FDesde = aP5_FDesde;
         objr_inventariopermanenteexcel.AV76FHasta = aP6_FHasta;
         objr_inventariopermanenteexcel.AV10Filename = "" ;
         objr_inventariopermanenteexcel.AV11ErrorMessage = "" ;
         objr_inventariopermanenteexcel.context.SetSubmitInitialConfig(context);
         objr_inventariopermanenteexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_inventariopermanenteexcel);
         aP0_LinCod=this.AV82LinCod;
         aP1_SublCod=this.AV81SublCod;
         aP2_FamCod=this.AV80FamCod;
         aP3_AlmCod=this.AV79AlmCod;
         aP4_Prodcod=this.AV78Prodcod;
         aP5_FDesde=this.AV77FDesde;
         aP6_FHasta=this.AV76FHasta;
         aP7_Filename=this.AV10Filename;
         aP8_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_inventariopermanenteexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasInventarioPermanente.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasInventarioPermanente.xlsx";
         AV10Filename = "Excel/InventarioPermanente" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV70FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 6;
         AV15FirstColumn = 1;
         AV83Tot1 = 0;
         AV84Tot2 = 0;
         AV85Tot3 = 0;
         AV86Tot4 = 0;
         AV87Tot5 = 0;
         AV88Tot6 = 0;
         AV89Tot7 = 0;
         AV90Tot8 = 0;
         AV91Tot9 = 0;
         AV121CostoTotal = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV82LinCod ,
                                              AV81SublCod ,
                                              AV80FamCod ,
                                              AV78Prodcod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A28ProdCod ,
                                              A21MvAlm ,
                                              AV79AlmCod ,
                                              A1158LinStk } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00FT2 */
         pr_default.execute(0, new Object[] {AV79AlmCod, AV82LinCod, AV81SublCod, AV80FamCod, AV78Prodcod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKFT2 = false;
            A13MvATip = P00FT2_A13MvATip[0];
            A14MvACod = P00FT2_A14MvACod[0];
            A49UniCod = P00FT2_A49UniCod[0];
            A55ProdDsc = P00FT2_A55ProdDsc[0];
            A28ProdCod = P00FT2_A28ProdCod[0];
            A1158LinStk = P00FT2_A1158LinStk[0];
            A21MvAlm = P00FT2_A21MvAlm[0];
            A50FamCod = P00FT2_A50FamCod[0];
            n50FamCod = P00FT2_n50FamCod[0];
            A51SublCod = P00FT2_A51SublCod[0];
            n51SublCod = P00FT2_n51SublCod[0];
            A52LinCod = P00FT2_A52LinCod[0];
            A1997UniAbr = P00FT2_A1997UniAbr[0];
            A1705ProdRef1 = P00FT2_A1705ProdRef1[0];
            A30MvADItem = P00FT2_A30MvADItem[0];
            A21MvAlm = P00FT2_A21MvAlm[0];
            A49UniCod = P00FT2_A49UniCod[0];
            A55ProdDsc = P00FT2_A55ProdDsc[0];
            A50FamCod = P00FT2_A50FamCod[0];
            n50FamCod = P00FT2_n50FamCod[0];
            A51SublCod = P00FT2_A51SublCod[0];
            n51SublCod = P00FT2_n51SublCod[0];
            A52LinCod = P00FT2_A52LinCod[0];
            A1705ProdRef1 = P00FT2_A1705ProdRef1[0];
            A1997UniAbr = P00FT2_A1997UniAbr[0];
            A1158LinStk = P00FT2_A1158LinStk[0];
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00FT2_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRKFT2 = false;
               A13MvATip = P00FT2_A13MvATip[0];
               A14MvACod = P00FT2_A14MvACod[0];
               A55ProdDsc = P00FT2_A55ProdDsc[0];
               A30MvADItem = P00FT2_A30MvADItem[0];
               A55ProdDsc = P00FT2_A55ProdDsc[0];
               BRKFT2 = true;
               pr_default.readNext(0);
            }
            AV92ProdCodC = A28ProdCod;
            AV93Producto = A55ProdDsc;
            AV94UniAbr = A1997UniAbr;
            AV127ProdRef1 = StringUtil.Trim( A1705ProdRef1);
            AV95CanIni = 0;
            AV96TCosIni = 0;
            AV97TCosTIni = 0;
            AV98Ing1 = 0;
            AV99IngCU = 0;
            AV100IngCT = 0;
            AV101TTIngreso = 0;
            AV102TIngresoCT = 0;
            AV119TIngresoCU = 0;
            AV103Sal1 = 0;
            AV104SalCU = 0;
            AV105SalCT = 0;
            AV106TTSalida = 0;
            AV107TsalidaCT = 0;
            AV120TSalidaCU = 0;
            AV112Final = 0;
            new GeneXus.Programs.contabilidad.paobtenersaldocostoproductofechas(context ).execute( ref  AV77FDesde, ref  AV79AlmCod, ref  AV92ProdCodC, out  AV109Saldo, out  AV108CostoU) ;
            AV110CostoT = NumberUtil.Round( AV109Saldo*AV108CostoU, 2);
            AV111TCosto = AV110CostoT;
            AV112Final = AV109Saldo;
            /* Execute user subroutine: 'VALIDA' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV113Ingresa = 0;
            AV114Salida = 0;
            AV115Ceros = 0;
            AV116TIngreso = ((AV109Saldo>Convert.ToDecimal(0)) ? AV109Saldo : (decimal)(0));
            AV117TSalida = ((AV109Saldo<Convert.ToDecimal(0)) ? AV109Saldo : (decimal)(0));
            AV118CostoUAnt = AV108CostoU;
            if ( ( AV109Saldo != Convert.ToDecimal( 0 )) )
            {
               AV95CanIni = AV116TIngreso;
               AV96TCosIni = AV118CostoUAnt;
               AV97TCosTIni = NumberUtil.Round( AV95CanIni*AV96TCosIni, 2);
            }
            /* Execute user subroutine: 'DETALLEMOVIMIENTO' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( ( AV112Final == Convert.ToDecimal( 0 )) )
            {
               AV108CostoU = 0;
               AV110CostoT = 0;
            }
            if ( ( AV126Flag == 0 ) || ( AV109Saldo != Convert.ToDecimal( 0 )) )
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
            AV83Tot1 = (decimal)(AV83Tot1+AV101TTIngreso);
            AV84Tot2 = (decimal)(AV84Tot2+AV119TIngresoCU);
            AV85Tot3 = (decimal)(AV85Tot3+AV102TIngresoCT);
            AV86Tot4 = (decimal)(AV86Tot4+AV106TTSalida);
            AV87Tot5 = (decimal)(AV87Tot5+AV120TSalidaCU);
            AV88Tot6 = (decimal)(AV88Tot6+AV107TsalidaCT);
            AV89Tot7 = (decimal)(AV89Tot7+AV95CanIni);
            AV91Tot9 = (decimal)(AV91Tot9+AV97TCosTIni);
            AV90Tot8 = (decimal)(AV90Tot8+(((AV89Tot7==Convert.ToDecimal(0)) ? (decimal)(0) : ((AV95CanIni==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( AV97TCosTIni/ (decimal)(AV95CanIni), 2)))));
            if ( ! BRKFT2 )
            {
               BRKFT2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
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
         /* 'VALIDA' Routine */
         returnInSub = false;
         AV126Flag = 1;
         /* Using cursor P00FT3 */
         pr_default.execute(1, new Object[] {AV77FDesde, AV92ProdCodC, AV79AlmCod, AV76FHasta});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A28ProdCod = P00FT3_A28ProdCod[0];
            A21MvAlm = P00FT3_A21MvAlm[0];
            A1370MVSts = P00FT3_A1370MVSts[0];
            A25MvAFec = P00FT3_A25MvAFec[0];
            A14MvACod = P00FT3_A14MvACod[0];
            A13MvATip = P00FT3_A13MvATip[0];
            A30MvADItem = P00FT3_A30MvADItem[0];
            A21MvAlm = P00FT3_A21MvAlm[0];
            A1370MVSts = P00FT3_A1370MVSts[0];
            A25MvAFec = P00FT3_A25MvAFec[0];
            AV126Flag = 0;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'DETALLEMOVIMIENTO' Routine */
         returnInSub = false;
         /* Using cursor P00FT4 */
         pr_default.execute(2, new Object[] {AV77FDesde, AV92ProdCodC, AV79AlmCod, AV76FHasta});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A22MvAMov = P00FT4_A22MvAMov[0];
            A28ProdCod = P00FT4_A28ProdCod[0];
            A21MvAlm = P00FT4_A21MvAlm[0];
            A1370MVSts = P00FT4_A1370MVSts[0];
            A25MvAFec = P00FT4_A25MvAFec[0];
            A1278MvARef = P00FT4_A1278MvARef[0];
            A1276MvAOcom = P00FT4_A1276MvAOcom[0];
            A24DocNum = P00FT4_A24DocNum[0];
            n24DocNum = P00FT4_n24DocNum[0];
            A1248MvADCant = P00FT4_A1248MvADCant[0];
            A1237MovAbr = P00FT4_A1237MovAbr[0];
            n1237MovAbr = P00FT4_n1237MovAbr[0];
            A1250MVADPrecio = P00FT4_A1250MVADPrecio[0];
            A1249MVADCosto = P00FT4_A1249MVADCosto[0];
            A14MvACod = P00FT4_A14MvACod[0];
            A13MvATip = P00FT4_A13MvATip[0];
            A30MvADItem = P00FT4_A30MvADItem[0];
            A22MvAMov = P00FT4_A22MvAMov[0];
            A21MvAlm = P00FT4_A21MvAlm[0];
            A1370MVSts = P00FT4_A1370MVSts[0];
            A25MvAFec = P00FT4_A25MvAFec[0];
            A1278MvARef = P00FT4_A1278MvARef[0];
            A1276MvAOcom = P00FT4_A1276MvAOcom[0];
            A24DocNum = P00FT4_A24DocNum[0];
            n24DocNum = P00FT4_n24DocNum[0];
            A1237MovAbr = P00FT4_A1237MovAbr[0];
            n1237MovAbr = P00FT4_n1237MovAbr[0];
            AV122MVATip = A13MvATip;
            AV123MVACod = A14MvACod;
            AV124DocRef = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? (String.IsNullOrEmpty(StringUtil.RTrim( A1276MvAOcom)) ? A1278MvARef : A1276MvAOcom) : A24DocNum);
            AV113Ingresa = ((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1248MvADCant : (decimal)(0));
            AV114Salida = ((StringUtil.StrCmp(A13MvATip, "ING")!=0) ? A1248MvADCant : (decimal)(0));
            AV108CostoU = 0;
            AV110CostoT = 0;
            AV125MovAbr = A1237MovAbr;
            AV98Ing1 = 0;
            AV99IngCU = 0;
            AV100IngCT = 0;
            AV103Sal1 = 0;
            AV104SalCU = 0;
            AV105SalCT = 0;
            if ( StringUtil.StrCmp(A13MvATip, "ING") == 0 )
            {
               AV108CostoU = A1250MVADPrecio;
               AV110CostoT = A1249MVADCosto;
               AV111TCosto = (decimal)(AV111TCosto+AV110CostoT);
               AV118CostoUAnt = 0;
               AV98Ing1 = AV113Ingresa;
               AV99IngCU = AV108CostoU;
               AV100IngCT = AV110CostoT;
            }
            else
            {
               if ( ! (Convert.ToDecimal(0)==AV118CostoUAnt) )
               {
                  AV108CostoU = AV118CostoUAnt;
               }
               else
               {
                  if ( ( AV112Final <= Convert.ToDecimal( 0 )) )
                  {
                     AV108CostoU = 0;
                  }
                  else
                  {
                     AV108CostoU = NumberUtil.Round( AV111TCosto/ (decimal)(AV112Final), 4);
                  }
               }
               AV110CostoT = NumberUtil.Round( AV108CostoU*AV114Salida, 2);
               AV111TCosto = (decimal)(AV111TCosto+((AV110CostoT*-1)));
               AV118CostoUAnt = AV108CostoU;
               AV103Sal1 = AV114Salida;
               AV104SalCU = AV108CostoU;
               AV105SalCT = AV110CostoT;
            }
            AV101TTIngreso = (decimal)(AV101TTIngreso+AV98Ing1);
            AV102TIngresoCT = (decimal)(AV102TIngresoCT+AV100IngCT);
            AV119TIngresoCU = ((AV101TTIngreso>Convert.ToDecimal(0)) ? NumberUtil.Round( AV102TIngresoCT/ (decimal)(AV101TTIngreso), 6) : (decimal)(0));
            AV106TTSalida = (decimal)(AV106TTSalida+AV103Sal1);
            AV107TsalidaCT = (decimal)(AV107TsalidaCT+AV105SalCT);
            AV120TSalidaCU = ((AV106TTSalida>Convert.ToDecimal(0)) ? NumberUtil.Round( AV107TsalidaCT/ (decimal)(AV106TTSalida), 6) : (decimal)(0));
            AV112Final = (decimal)(AV112Final+((AV113Ingresa-AV114Salida)));
            AV116TIngreso = (decimal)(AV116TIngreso+AV113Ingresa);
            AV117TSalida = (decimal)(AV117TSalida+AV114Salida);
            if ( ! (Convert.ToDecimal(0)==AV118CostoUAnt) )
            {
               AV108CostoU = AV118CostoUAnt;
            }
            else
            {
               if ( ( AV112Final <= Convert.ToDecimal( 0 )) )
               {
                  AV108CostoU = 0;
               }
               else
               {
                  AV108CostoU = NumberUtil.Round( AV111TCosto/ (decimal)(AV112Final), 4);
               }
            }
            AV110CostoT = NumberUtil.Round( AV108CostoU*AV112Final, 2);
            AV111TCosto = AV110CostoT;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'TOTALAGRUPA' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV92ProdCodC);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV93Producto);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV94UniAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV95CanIni);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Number = (double)(AV96TCosIni);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV97TCosTIni);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV101TTIngreso);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV119TIngresoCU);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV102TIngresoCT);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV106TTSalida);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV120TSalidaCU);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(AV107TsalidaCT);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Number = (double)(AV112Final);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Number = (double)(AV110CostoT);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+14, 1, 1).Number = (double)(AV108CostoU);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+15, 1, 1).Text = StringUtil.Trim( AV127ProdRef1);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S141( )
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
         scmdbuf = "";
         A28ProdCod = "";
         P00FT2_A13MvATip = new string[] {""} ;
         P00FT2_A14MvACod = new string[] {""} ;
         P00FT2_A49UniCod = new int[1] ;
         P00FT2_A55ProdDsc = new string[] {""} ;
         P00FT2_A28ProdCod = new string[] {""} ;
         P00FT2_A1158LinStk = new short[1] ;
         P00FT2_A21MvAlm = new int[1] ;
         P00FT2_A50FamCod = new int[1] ;
         P00FT2_n50FamCod = new bool[] {false} ;
         P00FT2_A51SublCod = new int[1] ;
         P00FT2_n51SublCod = new bool[] {false} ;
         P00FT2_A52LinCod = new int[1] ;
         P00FT2_A1997UniAbr = new string[] {""} ;
         P00FT2_A1705ProdRef1 = new string[] {""} ;
         P00FT2_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A55ProdDsc = "";
         A1997UniAbr = "";
         A1705ProdRef1 = "";
         AV92ProdCodC = "";
         AV93Producto = "";
         AV94UniAbr = "";
         AV127ProdRef1 = "";
         P00FT3_A28ProdCod = new string[] {""} ;
         P00FT3_A21MvAlm = new int[1] ;
         P00FT3_A1370MVSts = new string[] {""} ;
         P00FT3_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FT3_A14MvACod = new string[] {""} ;
         P00FT3_A13MvATip = new string[] {""} ;
         P00FT3_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         P00FT4_A22MvAMov = new int[1] ;
         P00FT4_A28ProdCod = new string[] {""} ;
         P00FT4_A21MvAlm = new int[1] ;
         P00FT4_A1370MVSts = new string[] {""} ;
         P00FT4_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FT4_A1278MvARef = new string[] {""} ;
         P00FT4_A1276MvAOcom = new string[] {""} ;
         P00FT4_A24DocNum = new string[] {""} ;
         P00FT4_n24DocNum = new bool[] {false} ;
         P00FT4_A1248MvADCant = new decimal[1] ;
         P00FT4_A1237MovAbr = new string[] {""} ;
         P00FT4_n1237MovAbr = new bool[] {false} ;
         P00FT4_A1250MVADPrecio = new decimal[1] ;
         P00FT4_A1249MVADCosto = new decimal[1] ;
         P00FT4_A14MvACod = new string[] {""} ;
         P00FT4_A13MvATip = new string[] {""} ;
         P00FT4_A30MvADItem = new int[1] ;
         A1278MvARef = "";
         A1276MvAOcom = "";
         A24DocNum = "";
         A1237MovAbr = "";
         AV122MVATip = "";
         AV123MVACod = "";
         AV124DocRef = "";
         AV125MovAbr = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_inventariopermanenteexcel__default(),
            new Object[][] {
                new Object[] {
               P00FT2_A13MvATip, P00FT2_A14MvACod, P00FT2_A49UniCod, P00FT2_A55ProdDsc, P00FT2_A28ProdCod, P00FT2_A1158LinStk, P00FT2_A21MvAlm, P00FT2_A50FamCod, P00FT2_n50FamCod, P00FT2_A51SublCod,
               P00FT2_n51SublCod, P00FT2_A52LinCod, P00FT2_A1997UniAbr, P00FT2_A1705ProdRef1, P00FT2_A30MvADItem
               }
               , new Object[] {
               P00FT3_A28ProdCod, P00FT3_A21MvAlm, P00FT3_A1370MVSts, P00FT3_A25MvAFec, P00FT3_A14MvACod, P00FT3_A13MvATip, P00FT3_A30MvADItem
               }
               , new Object[] {
               P00FT4_A22MvAMov, P00FT4_A28ProdCod, P00FT4_A21MvAlm, P00FT4_A1370MVSts, P00FT4_A25MvAFec, P00FT4_A1278MvARef, P00FT4_A1276MvAOcom, P00FT4_A24DocNum, P00FT4_n24DocNum, P00FT4_A1248MvADCant,
               P00FT4_A1237MovAbr, P00FT4_n1237MovAbr, P00FT4_A1250MVADPrecio, P00FT4_A1249MVADCosto, P00FT4_A14MvACod, P00FT4_A13MvATip, P00FT4_A30MvADItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1158LinStk ;
      private short AV126Flag ;
      private int AV82LinCod ;
      private int AV81SublCod ;
      private int AV80FamCod ;
      private int AV79AlmCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A21MvAlm ;
      private int A49UniCod ;
      private int A30MvADItem ;
      private int A22MvAMov ;
      private decimal AV83Tot1 ;
      private decimal AV84Tot2 ;
      private decimal AV85Tot3 ;
      private decimal AV86Tot4 ;
      private decimal AV87Tot5 ;
      private decimal AV88Tot6 ;
      private decimal AV89Tot7 ;
      private decimal AV90Tot8 ;
      private decimal AV91Tot9 ;
      private decimal AV121CostoTotal ;
      private decimal AV95CanIni ;
      private decimal AV96TCosIni ;
      private decimal AV97TCosTIni ;
      private decimal AV98Ing1 ;
      private decimal AV99IngCU ;
      private decimal AV100IngCT ;
      private decimal AV101TTIngreso ;
      private decimal AV102TIngresoCT ;
      private decimal AV119TIngresoCU ;
      private decimal AV103Sal1 ;
      private decimal AV104SalCU ;
      private decimal AV105SalCT ;
      private decimal AV106TTSalida ;
      private decimal AV107TsalidaCT ;
      private decimal AV120TSalidaCU ;
      private decimal AV112Final ;
      private decimal AV109Saldo ;
      private decimal AV108CostoU ;
      private decimal AV110CostoT ;
      private decimal AV111TCosto ;
      private decimal AV113Ingresa ;
      private decimal AV114Salida ;
      private decimal AV115Ceros ;
      private decimal AV116TIngreso ;
      private decimal AV117TSalida ;
      private decimal AV118CostoUAnt ;
      private decimal A1248MvADCant ;
      private decimal A1250MVADPrecio ;
      private decimal A1249MVADCosto ;
      private string AV78Prodcod ;
      private string AV71Path ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A55ProdDsc ;
      private string A1997UniAbr ;
      private string A1705ProdRef1 ;
      private string AV92ProdCodC ;
      private string AV93Producto ;
      private string AV94UniAbr ;
      private string AV127ProdRef1 ;
      private string A1370MVSts ;
      private string A1278MvARef ;
      private string A1276MvAOcom ;
      private string A24DocNum ;
      private string A1237MovAbr ;
      private string AV122MVATip ;
      private string AV123MVACod ;
      private string AV124DocRef ;
      private string AV125MovAbr ;
      private DateTime AV77FDesde ;
      private DateTime AV76FHasta ;
      private DateTime A25MvAFec ;
      private bool returnInSub ;
      private bool BRKFT2 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool n24DocNum ;
      private bool n1237MovAbr ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
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
      private string[] P00FT2_A13MvATip ;
      private string[] P00FT2_A14MvACod ;
      private int[] P00FT2_A49UniCod ;
      private string[] P00FT2_A55ProdDsc ;
      private string[] P00FT2_A28ProdCod ;
      private short[] P00FT2_A1158LinStk ;
      private int[] P00FT2_A21MvAlm ;
      private int[] P00FT2_A50FamCod ;
      private bool[] P00FT2_n50FamCod ;
      private int[] P00FT2_A51SublCod ;
      private bool[] P00FT2_n51SublCod ;
      private int[] P00FT2_A52LinCod ;
      private string[] P00FT2_A1997UniAbr ;
      private string[] P00FT2_A1705ProdRef1 ;
      private int[] P00FT2_A30MvADItem ;
      private string[] P00FT3_A28ProdCod ;
      private int[] P00FT3_A21MvAlm ;
      private string[] P00FT3_A1370MVSts ;
      private DateTime[] P00FT3_A25MvAFec ;
      private string[] P00FT3_A14MvACod ;
      private string[] P00FT3_A13MvATip ;
      private int[] P00FT3_A30MvADItem ;
      private int[] P00FT4_A22MvAMov ;
      private string[] P00FT4_A28ProdCod ;
      private int[] P00FT4_A21MvAlm ;
      private string[] P00FT4_A1370MVSts ;
      private DateTime[] P00FT4_A25MvAFec ;
      private string[] P00FT4_A1278MvARef ;
      private string[] P00FT4_A1276MvAOcom ;
      private string[] P00FT4_A24DocNum ;
      private bool[] P00FT4_n24DocNum ;
      private decimal[] P00FT4_A1248MvADCant ;
      private string[] P00FT4_A1237MovAbr ;
      private bool[] P00FT4_n1237MovAbr ;
      private decimal[] P00FT4_A1250MVADPrecio ;
      private decimal[] P00FT4_A1249MVADCosto ;
      private string[] P00FT4_A14MvACod ;
      private string[] P00FT4_A13MvATip ;
      private int[] P00FT4_A30MvADItem ;
      private string aP7_Filename ;
      private string aP8_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class r_inventariopermanenteexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FT2( IGxContext context ,
                                             int AV82LinCod ,
                                             int AV81SublCod ,
                                             int AV80FamCod ,
                                             string AV78Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             int A21MvAlm ,
                                             int AV79AlmCod ,
                                             short A1158LinStk )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T3.[UniCod], T3.[ProdDsc], T1.[ProdCod], T5.[LinStk], T2.[MvAlm], T3.[FamCod], T3.[SublCod], T3.[LinCod], T4.[UniAbr], T3.[ProdRef1], T1.[MvADItem] FROM (((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T4 ON T4.[UniCod] = T3.[UniCod]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T3.[LinCod])";
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV79AlmCod)");
         AddWhere(sWhereString, "(T5.[LinStk] = 1)");
         if ( ! (0==AV82LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV82LinCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV81SublCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV81SublCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV80FamCod) )
         {
            AddWhere(sWhereString, "(T3.[FamCod] = @AV80FamCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV78Prodcod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T3.[ProdDsc]";
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
                     return conditional_P00FT2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmP00FT3;
          prmP00FT3 = new Object[] {
          new ParDef("@AV77FDesde",GXType.Date,8,0) ,
          new ParDef("@AV92ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV79AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV76FHasta",GXType.Date,8,0)
          };
          Object[] prmP00FT4;
          prmP00FT4 = new Object[] {
          new ParDef("@AV77FDesde",GXType.Date,8,0) ,
          new ParDef("@AV92ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV79AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV76FHasta",GXType.Date,8,0)
          };
          Object[] prmP00FT2;
          prmP00FT2 = new Object[] {
          new ParDef("@AV79AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV82LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV81SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV80FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV78Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FT2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FT2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FT3", "SELECT T1.[ProdCod], T2.[MvAlm], T2.[MVSts], T2.[MvAFec], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T2.[MvAFec] >= @AV77FDesde) AND (T2.[MVSts] <> 'A') AND (T1.[ProdCod] = @AV92ProdCodC) AND (T2.[MvAlm] = @AV79AlmCod) AND (T2.[MvAFec] <= @AV76FHasta) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FT3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FT4", "SELECT T2.[MvAMov] AS MvAMov, T1.[ProdCod], T2.[MvAlm], T2.[MVSts], T2.[MvAFec], T2.[MvARef], T2.[MvAOcom], T2.[DocNum], T1.[MvADCant], T3.[MovAbr], T1.[MVADPrecio], T1.[MVADCosto], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM (([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T3 ON T3.[MovCod] = T2.[MvAMov]) WHERE (T2.[MvAFec] >= @AV77FDesde) AND (T2.[MVSts] <> 'A') AND (T1.[ProdCod] = @AV92ProdCodC) AND (T2.[MvAlm] = @AV79AlmCod) AND (T2.[MvAFec] <= @AV76FHasta) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FT4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((int[]) buf[6])[0] = rslt.getInt(7);
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
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 12);
                ((string[]) buf[15])[0] = rslt.getString(14, 3);
                ((int[]) buf[16])[0] = rslt.getInt(15);
                return;
       }
    }

 }

}
