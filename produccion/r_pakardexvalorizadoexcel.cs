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
   public class r_pakardexvalorizadoexcel : GXProcedure
   {
      public r_pakardexvalorizadoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_pakardexvalorizadoexcel( IGxContext context )
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
         r_pakardexvalorizadoexcel objr_pakardexvalorizadoexcel;
         objr_pakardexvalorizadoexcel = new r_pakardexvalorizadoexcel();
         objr_pakardexvalorizadoexcel.AV82LinCod = aP0_LinCod;
         objr_pakardexvalorizadoexcel.AV81SublCod = aP1_SublCod;
         objr_pakardexvalorizadoexcel.AV80FamCod = aP2_FamCod;
         objr_pakardexvalorizadoexcel.AV79AlmCod = aP3_AlmCod;
         objr_pakardexvalorizadoexcel.AV78Prodcod = aP4_Prodcod;
         objr_pakardexvalorizadoexcel.AV77FDesde = aP5_FDesde;
         objr_pakardexvalorizadoexcel.AV76FHasta = aP6_FHasta;
         objr_pakardexvalorizadoexcel.AV10Filename = "" ;
         objr_pakardexvalorizadoexcel.AV11ErrorMessage = "" ;
         objr_pakardexvalorizadoexcel.context.SetSubmitInitialConfig(context);
         objr_pakardexvalorizadoexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_pakardexvalorizadoexcel);
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
            ((r_pakardexvalorizadoexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasKardexValorizado.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasKardexValorizado.xlsx";
         AV10Filename = "Excel/KardexValorizado" + ".xlsx";
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
         AV14CellRow = 7;
         AV15FirstColumn = 1;
         AV121CostoTotal = 0;
         AV132TCantidad = 0;
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
                                              A1158LinStk ,
                                              A1269MvAlmCos } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00FP2 */
         pr_default.execute(0, new Object[] {AV79AlmCod, AV82LinCod, AV81SublCod, AV80FamCod, AV78Prodcod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKFP2 = false;
            A13MvATip = P00FP2_A13MvATip[0];
            A14MvACod = P00FP2_A14MvACod[0];
            A49UniCod = P00FP2_A49UniCod[0];
            A55ProdDsc = P00FP2_A55ProdDsc[0];
            A28ProdCod = P00FP2_A28ProdCod[0];
            A1269MvAlmCos = P00FP2_A1269MvAlmCos[0];
            A1158LinStk = P00FP2_A1158LinStk[0];
            A21MvAlm = P00FP2_A21MvAlm[0];
            A50FamCod = P00FP2_A50FamCod[0];
            n50FamCod = P00FP2_n50FamCod[0];
            A51SublCod = P00FP2_A51SublCod[0];
            n51SublCod = P00FP2_n51SublCod[0];
            A52LinCod = P00FP2_A52LinCod[0];
            A1997UniAbr = P00FP2_A1997UniAbr[0];
            A30MvADItem = P00FP2_A30MvADItem[0];
            A21MvAlm = P00FP2_A21MvAlm[0];
            A1269MvAlmCos = P00FP2_A1269MvAlmCos[0];
            A49UniCod = P00FP2_A49UniCod[0];
            A55ProdDsc = P00FP2_A55ProdDsc[0];
            A50FamCod = P00FP2_A50FamCod[0];
            n50FamCod = P00FP2_n50FamCod[0];
            A51SublCod = P00FP2_A51SublCod[0];
            n51SublCod = P00FP2_n51SublCod[0];
            A52LinCod = P00FP2_A52LinCod[0];
            A1997UniAbr = P00FP2_A1997UniAbr[0];
            A1158LinStk = P00FP2_A1158LinStk[0];
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00FP2_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRKFP2 = false;
               A13MvATip = P00FP2_A13MvATip[0];
               A14MvACod = P00FP2_A14MvACod[0];
               A55ProdDsc = P00FP2_A55ProdDsc[0];
               A30MvADItem = P00FP2_A30MvADItem[0];
               A55ProdDsc = P00FP2_A55ProdDsc[0];
               BRKFP2 = true;
               pr_default.readNext(0);
            }
            AV92ProdCodC = StringUtil.Trim( A28ProdCod);
            AV93Producto = A55ProdDsc;
            AV94UniAbr = A1997UniAbr;
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
               /* Execute user subroutine: 'INICIAL' */
               S151 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
            }
            /* Execute user subroutine: 'DETALLEMOVIMIENTOS' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( ( AV112Final <= Convert.ToDecimal( 0 )) )
            {
               AV108CostoU = 0;
               AV110CostoT = 0;
            }
            AV121CostoTotal = (decimal)(AV121CostoTotal+AV110CostoT);
            AV132TCantidad = (decimal)(AV132TCantidad+AV112Final);
            if ( ! BRKFP2 )
            {
               BRKFP2 = true;
               pr_default.readNext(0);
            }
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
         /* 'DETALLEMOVIMIENTOS' Routine */
         returnInSub = false;
         /* Using cursor P00FP3 */
         pr_default.execute(1, new Object[] {AV77FDesde, AV92ProdCodC, AV79AlmCod, AV76FHasta});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A22MvAMov = P00FP3_A22MvAMov[0];
            A21MvAlm = P00FP3_A21MvAlm[0];
            A1370MVSts = P00FP3_A1370MVSts[0];
            A25MvAFec = P00FP3_A25MvAFec[0];
            A28ProdCod = P00FP3_A28ProdCod[0];
            A1278MvARef = P00FP3_A1278MvARef[0];
            A1276MvAOcom = P00FP3_A1276MvAOcom[0];
            A24DocNum = P00FP3_A24DocNum[0];
            n24DocNum = P00FP3_n24DocNum[0];
            A1248MvADCant = P00FP3_A1248MvADCant[0];
            A1274MvAMovDsc = P00FP3_A1274MvAMovDsc[0];
            A1286MvATMov = P00FP3_A1286MvATMov[0];
            A1250MVADPrecio = P00FP3_A1250MVADPrecio[0];
            A1249MVADCosto = P00FP3_A1249MVADCosto[0];
            A14MvACod = P00FP3_A14MvACod[0];
            A13MvATip = P00FP3_A13MvATip[0];
            A30MvADItem = P00FP3_A30MvADItem[0];
            A22MvAMov = P00FP3_A22MvAMov[0];
            A21MvAlm = P00FP3_A21MvAlm[0];
            A1370MVSts = P00FP3_A1370MVSts[0];
            A25MvAFec = P00FP3_A25MvAFec[0];
            A1278MvARef = P00FP3_A1278MvARef[0];
            A1276MvAOcom = P00FP3_A1276MvAOcom[0];
            A24DocNum = P00FP3_A24DocNum[0];
            n24DocNum = P00FP3_n24DocNum[0];
            A1286MvATMov = P00FP3_A1286MvATMov[0];
            A1274MvAMovDsc = P00FP3_A1274MvAMovDsc[0];
            AV122MVATip = A13MvATip;
            AV123MVACod = A14MvACod;
            AV129MVAFec = A25MvAFec;
            AV124DocRef = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? (String.IsNullOrEmpty(StringUtil.RTrim( A1276MvAOcom)) ? A1278MvARef : A1276MvAOcom) : A24DocNum);
            AV37DocNum = A24DocNum;
            AV128OC = A1276MvAOcom;
            AV130OCP = A1278MvARef;
            AV113Ingresa = ((StringUtil.StrCmp(A13MvATip, "ING")==0) ? NumberUtil.Round( A1248MvADCant, 4) : (decimal)(0));
            AV114Salida = ((StringUtil.StrCmp(A13MvATip, "ING")!=0) ? NumberUtil.Round( A1248MvADCant, 4) : (decimal)(0));
            AV108CostoU = 0;
            AV110CostoT = 0;
            AV133MovDsc = StringUtil.Trim( A1274MvAMovDsc);
            AV131MvATMov = A1286MvATMov;
            AV98Ing1 = 0;
            AV99IngCU = 0;
            AV100IngCT = 0;
            AV103Sal1 = 0;
            AV104SalCU = 0;
            AV105SalCT = 0;
            if ( StringUtil.StrCmp(A13MvATip, "ING") == 0 )
            {
               AV108CostoU = NumberUtil.Round( A1250MVADPrecio, 4);
               AV110CostoT = NumberUtil.Round( A1249MVADCosto, 2);
               AV111TCosto = (decimal)(AV111TCosto+AV110CostoT);
               AV118CostoUAnt = 0;
               AV98Ing1 = AV113Ingresa;
               AV99IngCU = AV108CostoU;
               AV100IngCT = AV110CostoT;
               if ( ( AV131MvATMov == 1 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV128OC)) )
               {
                  /* Execute user subroutine: 'VALIDADOC' */
                  S134 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     returnInSub = true;
                     if (true) return;
                  }
               }
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
               AV111TCosto = (decimal)(AV111TCosto+(NumberUtil.Round( AV110CostoT*-1, 2)));
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
            /* Execute user subroutine: 'DETALLE' */
            S144 ();
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

      protected void S134( )
      {
         /* 'VALIDADOC' Routine */
         returnInSub = false;
         /* Using cursor P00FP4 */
         pr_default.execute(2, new Object[] {AV92ProdCodC, AV128OC});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A254ComDProCod = P00FP4_A254ComDProCod[0];
            n254ComDProCod = P00FP4_n254ComDProCod[0];
            A251ComDOrdCod = P00FP4_A251ComDOrdCod[0];
            A243ComCod = P00FP4_A243ComCod[0];
            A149TipCod = P00FP4_A149TipCod[0];
            A244PrvCod = P00FP4_A244PrvCod[0];
            A250ComDItem = P00FP4_A250ComDItem[0];
            AV37DocNum = A243ComCod;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S144( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV92ProdCodC);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV93Producto);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV129MVAFec ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Date = GXt_dtime1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV122MVATip);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV123MVACod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV133MovDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV37DocNum);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV128OC);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Text = StringUtil.Trim( AV130OCP);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV115Ceros);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(AV115Ceros);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Number = (double)(AV115Ceros);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Number = (double)(AV98Ing1);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+14, 1, 1).Number = (double)(AV99IngCU);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+15, 1, 1).Number = (double)(AV100IngCT);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+16, 1, 1).Number = (double)(AV103Sal1);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+17, 1, 1).Number = (double)(AV104SalCU);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+18, 1, 1).Number = (double)(AV105SalCT);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+19, 1, 1).Number = (double)(AV112Final);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+20, 1, 1).Number = (double)(AV110CostoT);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+21, 1, 1).Number = (double)(AV108CostoU);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S151( )
      {
         /* 'INICIAL' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV92ProdCodC);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV93Producto);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV77FDesde ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Date = GXt_dtime1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Text = "Saldo Inicial";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV95CanIni);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(AV96TCosIni);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Number = (double)(AV97TCosTIni);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Number = (double)(AV98Ing1);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+14, 1, 1).Number = (double)(AV99IngCU);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+15, 1, 1).Number = (double)(AV100IngCT);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+16, 1, 1).Number = (double)(AV103Sal1);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+17, 1, 1).Number = (double)(AV104SalCU);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+18, 1, 1).Number = (double)(AV105SalCT);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+19, 1, 1).Number = (double)(AV112Final);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+20, 1, 1).Number = (double)(AV110CostoT);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+21, 1, 1).Number = (double)(AV108CostoU);
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
         scmdbuf = "";
         A28ProdCod = "";
         P00FP2_A13MvATip = new string[] {""} ;
         P00FP2_A14MvACod = new string[] {""} ;
         P00FP2_A49UniCod = new int[1] ;
         P00FP2_A55ProdDsc = new string[] {""} ;
         P00FP2_A28ProdCod = new string[] {""} ;
         P00FP2_A1269MvAlmCos = new short[1] ;
         P00FP2_A1158LinStk = new short[1] ;
         P00FP2_A21MvAlm = new int[1] ;
         P00FP2_A50FamCod = new int[1] ;
         P00FP2_n50FamCod = new bool[] {false} ;
         P00FP2_A51SublCod = new int[1] ;
         P00FP2_n51SublCod = new bool[] {false} ;
         P00FP2_A52LinCod = new int[1] ;
         P00FP2_A1997UniAbr = new string[] {""} ;
         P00FP2_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A55ProdDsc = "";
         A1997UniAbr = "";
         AV92ProdCodC = "";
         AV93Producto = "";
         AV94UniAbr = "";
         P00FP3_A22MvAMov = new int[1] ;
         P00FP3_A21MvAlm = new int[1] ;
         P00FP3_A1370MVSts = new string[] {""} ;
         P00FP3_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FP3_A28ProdCod = new string[] {""} ;
         P00FP3_A1278MvARef = new string[] {""} ;
         P00FP3_A1276MvAOcom = new string[] {""} ;
         P00FP3_A24DocNum = new string[] {""} ;
         P00FP3_n24DocNum = new bool[] {false} ;
         P00FP3_A1248MvADCant = new decimal[1] ;
         P00FP3_A1274MvAMovDsc = new string[] {""} ;
         P00FP3_A1286MvATMov = new short[1] ;
         P00FP3_A1250MVADPrecio = new decimal[1] ;
         P00FP3_A1249MVADCosto = new decimal[1] ;
         P00FP3_A14MvACod = new string[] {""} ;
         P00FP3_A13MvATip = new string[] {""} ;
         P00FP3_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         A1278MvARef = "";
         A1276MvAOcom = "";
         A24DocNum = "";
         A1274MvAMovDsc = "";
         AV122MVATip = "";
         AV123MVACod = "";
         AV129MVAFec = DateTime.MinValue;
         AV124DocRef = "";
         AV37DocNum = "";
         AV128OC = "";
         AV130OCP = "";
         AV133MovDsc = "";
         P00FP4_A254ComDProCod = new string[] {""} ;
         P00FP4_n254ComDProCod = new bool[] {false} ;
         P00FP4_A251ComDOrdCod = new string[] {""} ;
         P00FP4_A243ComCod = new string[] {""} ;
         P00FP4_A149TipCod = new string[] {""} ;
         P00FP4_A244PrvCod = new string[] {""} ;
         P00FP4_A250ComDItem = new short[1] ;
         A254ComDProCod = "";
         A251ComDOrdCod = "";
         A243ComCod = "";
         A149TipCod = "";
         A244PrvCod = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_pakardexvalorizadoexcel__default(),
            new Object[][] {
                new Object[] {
               P00FP2_A13MvATip, P00FP2_A14MvACod, P00FP2_A49UniCod, P00FP2_A55ProdDsc, P00FP2_A28ProdCod, P00FP2_A1269MvAlmCos, P00FP2_A1158LinStk, P00FP2_A21MvAlm, P00FP2_A50FamCod, P00FP2_n50FamCod,
               P00FP2_A51SublCod, P00FP2_n51SublCod, P00FP2_A52LinCod, P00FP2_A1997UniAbr, P00FP2_A30MvADItem
               }
               , new Object[] {
               P00FP3_A22MvAMov, P00FP3_A21MvAlm, P00FP3_A1370MVSts, P00FP3_A25MvAFec, P00FP3_A28ProdCod, P00FP3_A1278MvARef, P00FP3_A1276MvAOcom, P00FP3_A24DocNum, P00FP3_n24DocNum, P00FP3_A1248MvADCant,
               P00FP3_A1274MvAMovDsc, P00FP3_A1286MvATMov, P00FP3_A1250MVADPrecio, P00FP3_A1249MVADCosto, P00FP3_A14MvACod, P00FP3_A13MvATip, P00FP3_A30MvADItem
               }
               , new Object[] {
               P00FP4_A254ComDProCod, P00FP4_n254ComDProCod, P00FP4_A251ComDOrdCod, P00FP4_A243ComCod, P00FP4_A149TipCod, P00FP4_A244PrvCod, P00FP4_A250ComDItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1158LinStk ;
      private short A1269MvAlmCos ;
      private short A1286MvATMov ;
      private short AV131MvATMov ;
      private short A250ComDItem ;
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
      private decimal AV121CostoTotal ;
      private decimal AV132TCantidad ;
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
      private string AV92ProdCodC ;
      private string AV93Producto ;
      private string AV94UniAbr ;
      private string A1370MVSts ;
      private string A1278MvARef ;
      private string A1276MvAOcom ;
      private string A24DocNum ;
      private string A1274MvAMovDsc ;
      private string AV122MVATip ;
      private string AV123MVACod ;
      private string AV124DocRef ;
      private string AV37DocNum ;
      private string AV128OC ;
      private string AV130OCP ;
      private string AV133MovDsc ;
      private string A254ComDProCod ;
      private string A251ComDOrdCod ;
      private string A243ComCod ;
      private string A149TipCod ;
      private string A244PrvCod ;
      private DateTime GXt_dtime1 ;
      private DateTime AV77FDesde ;
      private DateTime AV76FHasta ;
      private DateTime A25MvAFec ;
      private DateTime AV129MVAFec ;
      private bool returnInSub ;
      private bool BRKFP2 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool n24DocNum ;
      private bool n254ComDProCod ;
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
      private string[] P00FP2_A13MvATip ;
      private string[] P00FP2_A14MvACod ;
      private int[] P00FP2_A49UniCod ;
      private string[] P00FP2_A55ProdDsc ;
      private string[] P00FP2_A28ProdCod ;
      private short[] P00FP2_A1269MvAlmCos ;
      private short[] P00FP2_A1158LinStk ;
      private int[] P00FP2_A21MvAlm ;
      private int[] P00FP2_A50FamCod ;
      private bool[] P00FP2_n50FamCod ;
      private int[] P00FP2_A51SublCod ;
      private bool[] P00FP2_n51SublCod ;
      private int[] P00FP2_A52LinCod ;
      private string[] P00FP2_A1997UniAbr ;
      private int[] P00FP2_A30MvADItem ;
      private int[] P00FP3_A22MvAMov ;
      private int[] P00FP3_A21MvAlm ;
      private string[] P00FP3_A1370MVSts ;
      private DateTime[] P00FP3_A25MvAFec ;
      private string[] P00FP3_A28ProdCod ;
      private string[] P00FP3_A1278MvARef ;
      private string[] P00FP3_A1276MvAOcom ;
      private string[] P00FP3_A24DocNum ;
      private bool[] P00FP3_n24DocNum ;
      private decimal[] P00FP3_A1248MvADCant ;
      private string[] P00FP3_A1274MvAMovDsc ;
      private short[] P00FP3_A1286MvATMov ;
      private decimal[] P00FP3_A1250MVADPrecio ;
      private decimal[] P00FP3_A1249MVADCosto ;
      private string[] P00FP3_A14MvACod ;
      private string[] P00FP3_A13MvATip ;
      private int[] P00FP3_A30MvADItem ;
      private string[] P00FP4_A254ComDProCod ;
      private bool[] P00FP4_n254ComDProCod ;
      private string[] P00FP4_A251ComDOrdCod ;
      private string[] P00FP4_A243ComCod ;
      private string[] P00FP4_A149TipCod ;
      private string[] P00FP4_A244PrvCod ;
      private short[] P00FP4_A250ComDItem ;
      private string aP7_Filename ;
      private string aP8_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class r_pakardexvalorizadoexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FP2( IGxContext context ,
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
                                             short A1158LinStk ,
                                             short A1269MvAlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T4.[UniCod], T4.[ProdDsc], T1.[ProdCod], T3.[AlmCos] AS MvAlmCos, T6.[LinStk], T2.[MvAlm] AS MvAlm, T4.[FamCod], T4.[SublCod], T4.[LinCod], T5.[UniAbr], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T5 ON T5.[UniCod] = T4.[UniCod]) INNER JOIN [CLINEAPROD] T6 ON T6.[LinCod] = T4.[LinCod])";
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV79AlmCod)");
         AddWhere(sWhereString, "(T6.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[AlmCos] = 1)");
         if ( ! (0==AV82LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV82LinCod)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV81SublCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV81SublCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV80FamCod) )
         {
            AddWhere(sWhereString, "(T4.[FamCod] = @AV80FamCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV78Prodcod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T4.[ProdDsc]";
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
                     return conditional_P00FP2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
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
          Object[] prmP00FP3;
          prmP00FP3 = new Object[] {
          new ParDef("@AV77FDesde",GXType.Date,8,0) ,
          new ParDef("@AV92ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV79AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV76FHasta",GXType.Date,8,0)
          };
          Object[] prmP00FP4;
          prmP00FP4 = new Object[] {
          new ParDef("@AV92ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV128OC",GXType.NChar,10,0)
          };
          Object[] prmP00FP2;
          prmP00FP2 = new Object[] {
          new ParDef("@AV79AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV82LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV81SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV80FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV78Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FP2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FP2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FP3", "SELECT T2.[MvAMov] AS MvAMov, T2.[MvAlm] AS MvAlm, T2.[MVSts], T2.[MvAFec], T1.[ProdCod], T2.[MvARef], T2.[MvAOcom], T2.[DocNum], T1.[MvADCant], T3.[MovDsc] AS MvAMovDsc, T2.[MvATMov], T1.[MVADPrecio], T1.[MVADCosto], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM (([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T3 ON T3.[MovCod] = T2.[MvAMov]) WHERE (T2.[MvAFec] >= @AV77FDesde) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV92ProdCodC))) AND (T2.[MVSts] <> 'A') AND (T2.[MvAlm] = @AV79AlmCod) AND (T2.[MvAFec] <= @AV76FHasta) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FP3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FP4", "SELECT [ComDProCod], [ComDOrdCod], [ComCod], [TipCod], [PrvCod], [ComDItem] FROM [CPCOMPRASDET] WHERE ([ComDProCod] = @AV92ProdCodC) AND ([ComDOrdCod] = @AV128OC) ORDER BY [ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FP4,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 5);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((string[]) buf[7])[0] = rslt.getString(8, 12);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((string[]) buf[14])[0] = rslt.getString(14, 12);
                ((string[]) buf[15])[0] = rslt.getString(15, 3);
                ((int[]) buf[16])[0] = rslt.getInt(16);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 10);
                ((string[]) buf[3])[0] = rslt.getString(3, 15);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
