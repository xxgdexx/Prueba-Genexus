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
namespace GeneXus.Programs.contabilidad {
   public class pformato_3_3_excel : GXProcedure
   {
      public pformato_3_3_excel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pformato_3_3_excel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref string aP2_cCuenta1 ,
                           out string aP3_Filename ,
                           out string aP4_ErrorMessage )
      {
         this.AV8Ano = aP0_Ano;
         this.AV9Mes = aP1_Mes;
         this.AV88cCuenta1 = aP2_cCuenta1;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV9Mes;
         aP2_cCuenta1=this.AV88cCuenta1;
         aP3_Filename=this.AV10Filename;
         aP4_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref string aP2_cCuenta1 ,
                                out string aP3_Filename )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_cCuenta1, out aP3_Filename, out aP4_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_cCuenta1 ,
                                 out string aP3_Filename ,
                                 out string aP4_ErrorMessage )
      {
         pformato_3_3_excel objpformato_3_3_excel;
         objpformato_3_3_excel = new pformato_3_3_excel();
         objpformato_3_3_excel.AV8Ano = aP0_Ano;
         objpformato_3_3_excel.AV9Mes = aP1_Mes;
         objpformato_3_3_excel.AV88cCuenta1 = aP2_cCuenta1;
         objpformato_3_3_excel.AV10Filename = "" ;
         objpformato_3_3_excel.AV11ErrorMessage = "" ;
         objpformato_3_3_excel.context.SetSubmitInitialConfig(context);
         objpformato_3_3_excel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpformato_3_3_excel);
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV9Mes;
         aP2_cCuenta1=this.AV88cCuenta1;
         aP3_Filename=this.AV10Filename;
         aP4_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pformato_3_3_excel)stateInfo).executePrivate();
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
         AV47Empresa = AV48Session.Get("Empresa");
         AV46EmpDir = AV48Session.Get("EmpDir");
         AV45EmpRUC = AV48Session.Get("EmpRUC");
         AV18FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV9Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0));
         AV19FechaD = context.localUtil.CToD( AV18FechaC, 2);
         GXt_char1 = AV44cMes;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV9Mes, out  GXt_char1) ;
         AV44cMes = GXt_char1;
         AV39Periodo = StringUtil.Upper( AV44cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0));
         AV37Archivo.Source = "Excel/FORMATO_3_3.xlsx";
         AV38Path = AV37Archivo.GetPath();
         AV41FilenameOrigen = StringUtil.Trim( AV38Path) + "\\FORMATO_3_3.xlsx";
         AV10Filename = "Excel/FORMATO_3_3" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV41FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 3;
         AV15FirstColumn = 2;
         AV13ExcelDocument.get_Cells(4, 2, 1, 1).Text = StringUtil.Trim( AV39Periodo);
         AV13ExcelDocument.get_Cells(5, 2, 1, 1).Text = StringUtil.Trim( AV45EmpRUC);
         AV13ExcelDocument.get_Cells(6, 4, 1, 1).Text = StringUtil.Trim( AV47Empresa);
         AV14CellRow = 11;
         AV15FirstColumn = 1;
         AV49TDebePagMo = 0.00m;
         AV50THaberPagMO = 0.00m;
         AV51TDebePagMe = 0.00m;
         AV52THaberPagMe = 0.00m;
         /* Using cursor P00CP2 */
         pr_default.execute(0, new Object[] {AV8Ano});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKCP2 = false;
            A133CueCodAux = P00CP2_A133CueCodAux[0];
            A91CueCod = P00CP2_A91CueCod[0];
            A127VouAno = P00CP2_A127VouAno[0];
            A860CueDsc = P00CP2_A860CueDsc[0];
            A70TipACod = P00CP2_A70TipACod[0];
            n70TipACod = P00CP2_n70TipACod[0];
            A128VouMes = P00CP2_A128VouMes[0];
            A126TASICod = P00CP2_A126TASICod[0];
            A129VouNum = P00CP2_A129VouNum[0];
            A130VouDSec = P00CP2_A130VouDSec[0];
            A860CueDsc = P00CP2_A860CueDsc[0];
            A70TipACod = P00CP2_A70TipACod[0];
            n70TipACod = P00CP2_n70TipACod[0];
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00CP2_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRKCP2 = false;
               A133CueCodAux = P00CP2_A133CueCodAux[0];
               A127VouAno = P00CP2_A127VouAno[0];
               A128VouMes = P00CP2_A128VouMes[0];
               A126TASICod = P00CP2_A126TASICod[0];
               A129VouNum = P00CP2_A129VouNum[0];
               A130VouDSec = P00CP2_A130VouDSec[0];
               BRKCP2 = true;
               pr_default.readNext(0);
            }
            AV53CueCod = A91CueCod;
            AV54CueDsc = A860CueDsc;
            AV55TipACod = A70TipACod;
            AV56SaldoDMN = 0.00m;
            AV57SaldoHMN = 0.00m;
            AV58SaldoDME = 0.00m;
            AV59SaldoHME = 0.00m;
            AV60TDebeMO = 0.00m;
            AV61ThaberMO = 0.00m;
            AV62TDebeME = 0.00m;
            AV63THaberME = 0.00m;
            new GeneXus.Programs.contabilidad.pobtienesaldoscuenta(context ).execute( ref  AV53CueCod, ref  AV8Ano, ref  AV9Mes, out  AV56SaldoDMN, out  AV57SaldoHMN, out  AV58SaldoDME, out  AV59SaldoHME) ;
            AV64SaldoMN = (decimal)(AV56SaldoDMN-AV57SaldoHMN);
            AV65SaldoME = (decimal)(AV58SaldoDME-AV59SaldoHME);
            AV56SaldoDMN = ((AV64SaldoMN>Convert.ToDecimal(0)) ? AV64SaldoMN : (decimal)(0));
            AV57SaldoHMN = ((AV64SaldoMN<Convert.ToDecimal(0)) ? AV64SaldoMN*-1 : (decimal)(0));
            AV58SaldoDME = ((AV65SaldoME>Convert.ToDecimal(0)) ? AV65SaldoME : (decimal)(0));
            AV59SaldoHME = ((AV65SaldoME<Convert.ToDecimal(0)) ? AV65SaldoME*-1 : (decimal)(0));
            AV66Flag = 0;
            if ( ! (Convert.ToDecimal(0)==AV56SaldoDMN) || ! (Convert.ToDecimal(0)==AV57SaldoHMN) || ! (Convert.ToDecimal(0)==AV58SaldoDME) || ! (Convert.ToDecimal(0)==AV59SaldoHME) )
            {
               AV66Flag = 1;
            }
            /* Execute user subroutine: 'VALIDAMOV' */
            S181 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( AV66Flag == 1 )
            {
               AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV53CueCod);
               AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV54CueDsc);
               AV14CellRow = (int)(AV14CellRow+1);
            }
            /* Execute user subroutine: 'AUXILIARES' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( ! BRKCP2 )
            {
               BRKCP2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV86Saldo = (decimal)(AV49TDebePagMo-AV50THaberPagMO);
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
         /* 'AUXILIARES' Routine */
         returnInSub = false;
         if ( AV55TipACod > 0 )
         {
            AV67TDebe = 0.00m;
            AV68THaber = 0.00m;
            AV69TDebeE = 0.00m;
            AV70THaberE = 0.00m;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV71CueCodAux ,
                                                 A133CueCodAux ,
                                                 A127VouAno ,
                                                 AV8Ano ,
                                                 A91CueCod ,
                                                 AV53CueCod } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00CP3 */
            pr_default.execute(1, new Object[] {AV8Ano, AV53CueCod, AV71CueCodAux});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRKCP4 = false;
               A91CueCod = P00CP3_A91CueCod[0];
               A133CueCodAux = P00CP3_A133CueCodAux[0];
               A127VouAno = P00CP3_A127VouAno[0];
               A128VouMes = P00CP3_A128VouMes[0];
               A126TASICod = P00CP3_A126TASICod[0];
               A129VouNum = P00CP3_A129VouNum[0];
               A130VouDSec = P00CP3_A130VouDSec[0];
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00CP3_A133CueCodAux[0], A133CueCodAux) == 0 ) )
               {
                  BRKCP4 = false;
                  A91CueCod = P00CP3_A91CueCod[0];
                  A127VouAno = P00CP3_A127VouAno[0];
                  A128VouMes = P00CP3_A128VouMes[0];
                  A126TASICod = P00CP3_A126TASICod[0];
                  A129VouNum = P00CP3_A129VouNum[0];
                  A130VouDSec = P00CP3_A130VouDSec[0];
                  BRKCP4 = true;
                  pr_default.readNext(1);
               }
               AV72CueDAxu = A133CueCodAux;
               /* Execute user subroutine: 'NOMBREAUXILIAR' */
               S134 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               AV73SaldoDAMN = 0.00m;
               AV74SaldoHAMN = 0.00m;
               AV75SaldoDAME = 0.00m;
               AV76SaldoHAME = 0.00m;
               AV77TotalSDMN = 0.00m;
               AV78TotalSHMN = 0.00m;
               AV79TotalSDME = 0.00m;
               AV80TotalSHME = 0.00m;
               AV81Flag1 = 0;
               new GeneXus.Programs.contabilidad.pobtienesaldoscuentaauxiliar(context ).execute( ref  AV53CueCod, ref  AV72CueDAxu, ref  AV8Ano, ref  AV9Mes, out  AV73SaldoDAMN, out  AV74SaldoHAMN, out  AV75SaldoDAME, out  AV76SaldoHAME) ;
               AV64SaldoMN = (decimal)(AV73SaldoDAMN-AV74SaldoHAMN);
               AV65SaldoME = (decimal)(AV75SaldoDAME-AV76SaldoHAME);
               AV73SaldoDAMN = ((AV64SaldoMN>Convert.ToDecimal(0)) ? AV64SaldoMN : (decimal)(0));
               AV74SaldoHAMN = ((AV64SaldoMN<Convert.ToDecimal(0)) ? AV64SaldoMN*-1 : (decimal)(0));
               AV75SaldoDAME = ((AV65SaldoME>Convert.ToDecimal(0)) ? AV65SaldoME : (decimal)(0));
               AV76SaldoHAME = ((AV65SaldoME<Convert.ToDecimal(0)) ? AV65SaldoME*-1 : (decimal)(0));
               if ( ! (Convert.ToDecimal(0)==AV73SaldoDAMN) || ! (Convert.ToDecimal(0)==AV74SaldoHAMN) || ! (Convert.ToDecimal(0)==AV75SaldoDAME) || ! (Convert.ToDecimal(0)==AV76SaldoHAME) )
               {
                  AV81Flag1 = 1;
               }
               AV77TotalSDMN = AV73SaldoDAMN;
               AV78TotalSHMN = AV74SaldoHAMN;
               AV79TotalSDME = AV75SaldoDAME;
               AV80TotalSHME = AV76SaldoHAME;
               /* Execute user subroutine: 'VALIDAMOVAUXILIAR' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'MOVIMIENTOSAUXILIAR' */
               S154 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               AV67TDebe = (decimal)(AV67TDebe+AV77TotalSDMN);
               AV68THaber = (decimal)(AV68THaber+AV78TotalSHMN);
               AV69TDebeE = (decimal)(AV69TDebeE+AV79TotalSDME);
               AV70THaberE = (decimal)(AV70THaberE+AV80TotalSHME);
               if ( AV81Flag1 == 1 )
               {
                  AV84DifMN = (decimal)(AV77TotalSDMN-AV78TotalSHMN);
                  AV85DifME = (decimal)(AV79TotalSDME-AV80TotalSHME);
                  if ( ( AV84DifMN != Convert.ToDecimal( 0 )) )
                  {
                     AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV82TipAbr);
                     AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV72CueDAxu);
                     AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV83CuedaxuDsc);
                     AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV84DifMN);
                     AV14CellRow = (int)(AV14CellRow+1);
                  }
               }
               if ( ! BRKCP4 )
               {
                  BRKCP4 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
         }
         else
         {
            AV72CueDAxu = "";
            AV77TotalSDMN = 0.00m;
            AV78TotalSHMN = 0.00m;
            AV79TotalSDME = 0.00m;
            AV80TotalSHME = 0.00m;
            AV67TDebe = AV56SaldoDMN;
            AV68THaber = AV57SaldoHMN;
            AV69TDebeE = AV58SaldoDME;
            AV70THaberE = AV59SaldoHME;
            /* Execute user subroutine: 'MOVIMIENTOS' */
            S161 ();
            if (returnInSub) return;
            AV67TDebe = (decimal)(AV67TDebe+AV77TotalSDMN);
            AV68THaber = (decimal)(AV68THaber+AV78TotalSHMN);
            AV69TDebeE = (decimal)(AV69TDebeE+AV79TotalSDME);
            AV70THaberE = (decimal)(AV70THaberE+AV80TotalSHME);
         }
         AV60TDebeMO = AV67TDebe;
         AV61ThaberMO = AV68THaber;
         AV62TDebeME = AV69TDebeE;
         AV63THaberME = AV70THaberE;
         AV49TDebePagMo = (decimal)(AV49TDebePagMo+AV60TDebeMO);
         AV50THaberPagMO = (decimal)(AV50THaberPagMO+AV61ThaberMO);
         AV51TDebePagMe = (decimal)(AV51TDebePagMe+AV62TDebeME);
         AV52THaberPagMe = (decimal)(AV52THaberPagMe+AV63THaberME);
         if ( AV66Flag == 1 )
         {
            AV84DifMN = (decimal)(AV60TDebeMO-AV61ThaberMO);
            AV85DifME = (decimal)(AV62TDebeME-AV63THaberME);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV84DifMN);
            AV14CellRow = (int)(AV14CellRow+2);
         }
      }

      protected void S134( )
      {
         /* 'NOMBREAUXILIAR' Routine */
         returnInSub = false;
         AV99GXLvl228 = 0;
         /* Using cursor P00CP4 */
         pr_default.execute(2, new Object[] {AV55TipACod, AV72CueDAxu});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A71TipADCod = P00CP4_A71TipADCod[0];
            A70TipACod = P00CP4_A70TipACod[0];
            n70TipACod = P00CP4_n70TipACod[0];
            A72TipADDsc = P00CP4_A72TipADDsc[0];
            AV99GXLvl228 = 1;
            AV83CuedaxuDsc = A72TipADDsc;
            /* Execute user subroutine: 'TIPODOCUMENTO' */
            S176 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( AV99GXLvl228 == 0 )
         {
            AV83CuedaxuDsc = "SIN AUXILIAR";
         }
      }

      protected void S176( )
      {
         /* 'TIPODOCUMENTO' Routine */
         returnInSub = false;
         /* Using cursor P00CP5 */
         pr_default.execute(3, new Object[] {AV72CueDAxu});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A157TipSCod = P00CP5_A157TipSCod[0];
            A45CliCod = P00CP5_A45CliCod[0];
            A1916TipSAbr = P00CP5_A1916TipSAbr[0];
            A1916TipSAbr = P00CP5_A1916TipSAbr[0];
            AV82TipAbr = A1916TipSAbr;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV87cCosto ,
                                              A79COSCod ,
                                              A127VouAno ,
                                              AV8Ano ,
                                              A128VouMes ,
                                              AV9Mes ,
                                              A2077VouSts ,
                                              AV53CueCod ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CP6 */
         pr_default.execute(4, new Object[] {AV53CueCod, AV8Ano, AV9Mes, AV87cCosto});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A126TASICod = P00CP6_A126TASICod[0];
            A129VouNum = P00CP6_A129VouNum[0];
            A2077VouSts = P00CP6_A2077VouSts[0];
            A79COSCod = P00CP6_A79COSCod[0];
            n79COSCod = P00CP6_n79COSCod[0];
            A91CueCod = P00CP6_A91CueCod[0];
            A128VouMes = P00CP6_A128VouMes[0];
            A127VouAno = P00CP6_A127VouAno[0];
            A2069VouDTcmb = P00CP6_A2069VouDTcmb[0];
            A132VouDTipCod = P00CP6_A132VouDTipCod[0];
            A2054VouDGls = P00CP6_A2054VouDGls[0];
            A131VouDMon = P00CP6_A131VouDMon[0];
            A2052VouDDebO = P00CP6_A2052VouDDebO[0];
            A2056VouDHabO = P00CP6_A2056VouDHabO[0];
            A2051VouDDeb = P00CP6_A2051VouDDeb[0];
            A2055VouDHab = P00CP6_A2055VouDHab[0];
            A135VouDFec = P00CP6_A135VouDFec[0];
            A130VouDSec = P00CP6_A130VouDSec[0];
            A2077VouSts = P00CP6_A2077VouSts[0];
            AV90DebeME = 0.00m;
            AV91HaberME = 0.00m;
            AV89VouDTipCod = A132VouDTipCod;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV92Glosa = StringUtil.Trim( A2054VouDGls);
            }
            if ( ! ( A131VouDMon == 1 ) )
            {
               AV90DebeME = A2052VouDDebO;
               AV91HaberME = A2056VouDHabO;
            }
            AV77TotalSDMN = (decimal)(AV77TotalSDMN+A2051VouDDeb);
            AV78TotalSHMN = (decimal)(AV78TotalSHMN+A2055VouDHab);
            AV79TotalSDME = (decimal)(AV79TotalSDME+AV90DebeME);
            AV80TotalSHME = (decimal)(AV80TotalSHME+AV91HaberME);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S154( )
      {
         /* 'MOVIMIENTOSAUXILIAR' Routine */
         returnInSub = false;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV87cCosto ,
                                              A79COSCod ,
                                              A127VouAno ,
                                              AV8Ano ,
                                              A128VouMes ,
                                              AV9Mes ,
                                              A133CueCodAux ,
                                              AV72CueDAxu ,
                                              A2077VouSts ,
                                              AV53CueCod ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CP7 */
         pr_default.execute(5, new Object[] {AV53CueCod, AV8Ano, AV9Mes, AV72CueDAxu, AV87cCosto});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A126TASICod = P00CP7_A126TASICod[0];
            A129VouNum = P00CP7_A129VouNum[0];
            A2077VouSts = P00CP7_A2077VouSts[0];
            A79COSCod = P00CP7_A79COSCod[0];
            n79COSCod = P00CP7_n79COSCod[0];
            A133CueCodAux = P00CP7_A133CueCodAux[0];
            A91CueCod = P00CP7_A91CueCod[0];
            A128VouMes = P00CP7_A128VouMes[0];
            A127VouAno = P00CP7_A127VouAno[0];
            A2069VouDTcmb = P00CP7_A2069VouDTcmb[0];
            A2075VouGls = P00CP7_A2075VouGls[0];
            A132VouDTipCod = P00CP7_A132VouDTipCod[0];
            A2054VouDGls = P00CP7_A2054VouDGls[0];
            A131VouDMon = P00CP7_A131VouDMon[0];
            A2052VouDDebO = P00CP7_A2052VouDDebO[0];
            A2056VouDHabO = P00CP7_A2056VouDHabO[0];
            A2051VouDDeb = P00CP7_A2051VouDDeb[0];
            A2055VouDHab = P00CP7_A2055VouDHab[0];
            A135VouDFec = P00CP7_A135VouDFec[0];
            A130VouDSec = P00CP7_A130VouDSec[0];
            A2077VouSts = P00CP7_A2077VouSts[0];
            A2075VouGls = P00CP7_A2075VouGls[0];
            AV90DebeME = 0.00m;
            AV91HaberME = 0.00m;
            AV92Glosa = StringUtil.Trim( A2075VouGls);
            AV89VouDTipCod = A132VouDTipCod;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV92Glosa = StringUtil.Trim( A2054VouDGls);
            }
            if ( ! ( A131VouDMon == 1 ) )
            {
               AV90DebeME = A2052VouDDebO;
               AV91HaberME = A2056VouDHabO;
            }
            AV77TotalSDMN = (decimal)(AV77TotalSDMN+A2051VouDDeb);
            AV78TotalSHMN = (decimal)(AV78TotalSHMN+A2055VouDHab);
            AV79TotalSDME = (decimal)(AV79TotalSDME+AV90DebeME);
            AV80TotalSHME = (decimal)(AV80TotalSHME+AV91HaberME);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV87cCosto ,
                                              A79COSCod ,
                                              A2077VouSts ,
                                              AV8Ano ,
                                              AV9Mes ,
                                              AV53CueCod ,
                                              A127VouAno ,
                                              A128VouMes ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CP8 */
         pr_default.execute(6, new Object[] {AV8Ano, AV9Mes, AV53CueCod, AV87cCosto});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A126TASICod = P00CP8_A126TASICod[0];
            A129VouNum = P00CP8_A129VouNum[0];
            A79COSCod = P00CP8_A79COSCod[0];
            n79COSCod = P00CP8_n79COSCod[0];
            A2077VouSts = P00CP8_A2077VouSts[0];
            A91CueCod = P00CP8_A91CueCod[0];
            A128VouMes = P00CP8_A128VouMes[0];
            A127VouAno = P00CP8_A127VouAno[0];
            A2069VouDTcmb = P00CP8_A2069VouDTcmb[0];
            A130VouDSec = P00CP8_A130VouDSec[0];
            A2077VouSts = P00CP8_A2077VouSts[0];
            AV66Flag = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S144( )
      {
         /* 'VALIDAMOVAUXILIAR' Routine */
         returnInSub = false;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV87cCosto ,
                                              A79COSCod ,
                                              A2077VouSts ,
                                              AV8Ano ,
                                              AV9Mes ,
                                              AV53CueCod ,
                                              AV72CueDAxu ,
                                              A127VouAno ,
                                              A128VouMes ,
                                              A91CueCod ,
                                              A133CueCodAux } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CP9 */
         pr_default.execute(7, new Object[] {AV8Ano, AV9Mes, AV53CueCod, AV72CueDAxu, AV87cCosto});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A126TASICod = P00CP9_A126TASICod[0];
            A129VouNum = P00CP9_A129VouNum[0];
            A2077VouSts = P00CP9_A2077VouSts[0];
            A79COSCod = P00CP9_A79COSCod[0];
            n79COSCod = P00CP9_n79COSCod[0];
            A133CueCodAux = P00CP9_A133CueCodAux[0];
            A91CueCod = P00CP9_A91CueCod[0];
            A128VouMes = P00CP9_A128VouMes[0];
            A127VouAno = P00CP9_A127VouAno[0];
            A2069VouDTcmb = P00CP9_A2069VouDTcmb[0];
            A130VouDSec = P00CP9_A130VouDSec[0];
            A2077VouSts = P00CP9_A2077VouSts[0];
            AV81Flag1 = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(7);
         }
         pr_default.close(7);
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
         AV47Empresa = "";
         AV48Session = context.GetSession();
         AV46EmpDir = "";
         AV45EmpRUC = "";
         AV18FechaC = "";
         AV19FechaD = DateTime.MinValue;
         AV44cMes = "";
         GXt_char1 = "";
         AV39Periodo = "";
         AV37Archivo = new GxFile(context.GetPhysicalPath());
         AV38Path = "";
         AV41FilenameOrigen = "";
         AV13ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P00CP2_A133CueCodAux = new string[] {""} ;
         P00CP2_A91CueCod = new string[] {""} ;
         P00CP2_A127VouAno = new short[1] ;
         P00CP2_A860CueDsc = new string[] {""} ;
         P00CP2_A70TipACod = new int[1] ;
         P00CP2_n70TipACod = new bool[] {false} ;
         P00CP2_A128VouMes = new short[1] ;
         P00CP2_A126TASICod = new int[1] ;
         P00CP2_A129VouNum = new string[] {""} ;
         P00CP2_A130VouDSec = new int[1] ;
         A133CueCodAux = "";
         A91CueCod = "";
         A860CueDsc = "";
         A129VouNum = "";
         AV53CueCod = "";
         AV54CueDsc = "";
         AV71CueCodAux = "";
         P00CP3_A91CueCod = new string[] {""} ;
         P00CP3_A133CueCodAux = new string[] {""} ;
         P00CP3_A127VouAno = new short[1] ;
         P00CP3_A128VouMes = new short[1] ;
         P00CP3_A126TASICod = new int[1] ;
         P00CP3_A129VouNum = new string[] {""} ;
         P00CP3_A130VouDSec = new int[1] ;
         AV72CueDAxu = "";
         AV82TipAbr = "";
         AV83CuedaxuDsc = "";
         P00CP4_A71TipADCod = new string[] {""} ;
         P00CP4_A70TipACod = new int[1] ;
         P00CP4_n70TipACod = new bool[] {false} ;
         P00CP4_A72TipADDsc = new string[] {""} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         P00CP5_A157TipSCod = new int[1] ;
         P00CP5_A45CliCod = new string[] {""} ;
         P00CP5_A1916TipSAbr = new string[] {""} ;
         A45CliCod = "";
         A1916TipSAbr = "";
         AV87cCosto = "";
         A79COSCod = "";
         P00CP6_A126TASICod = new int[1] ;
         P00CP6_A129VouNum = new string[] {""} ;
         P00CP6_A2077VouSts = new short[1] ;
         P00CP6_A79COSCod = new string[] {""} ;
         P00CP6_n79COSCod = new bool[] {false} ;
         P00CP6_A91CueCod = new string[] {""} ;
         P00CP6_A128VouMes = new short[1] ;
         P00CP6_A127VouAno = new short[1] ;
         P00CP6_A2069VouDTcmb = new decimal[1] ;
         P00CP6_A132VouDTipCod = new string[] {""} ;
         P00CP6_A2054VouDGls = new string[] {""} ;
         P00CP6_A131VouDMon = new int[1] ;
         P00CP6_A2052VouDDebO = new decimal[1] ;
         P00CP6_A2056VouDHabO = new decimal[1] ;
         P00CP6_A2051VouDDeb = new decimal[1] ;
         P00CP6_A2055VouDHab = new decimal[1] ;
         P00CP6_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00CP6_A130VouDSec = new int[1] ;
         A132VouDTipCod = "";
         A2054VouDGls = "";
         A135VouDFec = DateTime.MinValue;
         AV89VouDTipCod = "";
         AV92Glosa = "";
         P00CP7_A126TASICod = new int[1] ;
         P00CP7_A129VouNum = new string[] {""} ;
         P00CP7_A2077VouSts = new short[1] ;
         P00CP7_A79COSCod = new string[] {""} ;
         P00CP7_n79COSCod = new bool[] {false} ;
         P00CP7_A133CueCodAux = new string[] {""} ;
         P00CP7_A91CueCod = new string[] {""} ;
         P00CP7_A128VouMes = new short[1] ;
         P00CP7_A127VouAno = new short[1] ;
         P00CP7_A2069VouDTcmb = new decimal[1] ;
         P00CP7_A2075VouGls = new string[] {""} ;
         P00CP7_A132VouDTipCod = new string[] {""} ;
         P00CP7_A2054VouDGls = new string[] {""} ;
         P00CP7_A131VouDMon = new int[1] ;
         P00CP7_A2052VouDDebO = new decimal[1] ;
         P00CP7_A2056VouDHabO = new decimal[1] ;
         P00CP7_A2051VouDDeb = new decimal[1] ;
         P00CP7_A2055VouDHab = new decimal[1] ;
         P00CP7_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00CP7_A130VouDSec = new int[1] ;
         A2075VouGls = "";
         P00CP8_A126TASICod = new int[1] ;
         P00CP8_A129VouNum = new string[] {""} ;
         P00CP8_A79COSCod = new string[] {""} ;
         P00CP8_n79COSCod = new bool[] {false} ;
         P00CP8_A2077VouSts = new short[1] ;
         P00CP8_A91CueCod = new string[] {""} ;
         P00CP8_A128VouMes = new short[1] ;
         P00CP8_A127VouAno = new short[1] ;
         P00CP8_A2069VouDTcmb = new decimal[1] ;
         P00CP8_A130VouDSec = new int[1] ;
         P00CP9_A126TASICod = new int[1] ;
         P00CP9_A129VouNum = new string[] {""} ;
         P00CP9_A2077VouSts = new short[1] ;
         P00CP9_A79COSCod = new string[] {""} ;
         P00CP9_n79COSCod = new bool[] {false} ;
         P00CP9_A133CueCodAux = new string[] {""} ;
         P00CP9_A91CueCod = new string[] {""} ;
         P00CP9_A128VouMes = new short[1] ;
         P00CP9_A127VouAno = new short[1] ;
         P00CP9_A2069VouDTcmb = new decimal[1] ;
         P00CP9_A130VouDSec = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.pformato_3_3_excel__default(),
            new Object[][] {
                new Object[] {
               P00CP2_A133CueCodAux, P00CP2_A91CueCod, P00CP2_A127VouAno, P00CP2_A860CueDsc, P00CP2_A70TipACod, P00CP2_n70TipACod, P00CP2_A128VouMes, P00CP2_A126TASICod, P00CP2_A129VouNum, P00CP2_A130VouDSec
               }
               , new Object[] {
               P00CP3_A91CueCod, P00CP3_A133CueCodAux, P00CP3_A127VouAno, P00CP3_A128VouMes, P00CP3_A126TASICod, P00CP3_A129VouNum, P00CP3_A130VouDSec
               }
               , new Object[] {
               P00CP4_A71TipADCod, P00CP4_A70TipACod, P00CP4_A72TipADDsc
               }
               , new Object[] {
               P00CP5_A157TipSCod, P00CP5_A45CliCod, P00CP5_A1916TipSAbr
               }
               , new Object[] {
               P00CP6_A126TASICod, P00CP6_A129VouNum, P00CP6_A2077VouSts, P00CP6_A79COSCod, P00CP6_n79COSCod, P00CP6_A91CueCod, P00CP6_A128VouMes, P00CP6_A127VouAno, P00CP6_A2069VouDTcmb, P00CP6_A132VouDTipCod,
               P00CP6_A2054VouDGls, P00CP6_A131VouDMon, P00CP6_A2052VouDDebO, P00CP6_A2056VouDHabO, P00CP6_A2051VouDDeb, P00CP6_A2055VouDHab, P00CP6_A135VouDFec, P00CP6_A130VouDSec
               }
               , new Object[] {
               P00CP7_A126TASICod, P00CP7_A129VouNum, P00CP7_A2077VouSts, P00CP7_A79COSCod, P00CP7_n79COSCod, P00CP7_A133CueCodAux, P00CP7_A91CueCod, P00CP7_A128VouMes, P00CP7_A127VouAno, P00CP7_A2069VouDTcmb,
               P00CP7_A2075VouGls, P00CP7_A132VouDTipCod, P00CP7_A2054VouDGls, P00CP7_A131VouDMon, P00CP7_A2052VouDDebO, P00CP7_A2056VouDHabO, P00CP7_A2051VouDDeb, P00CP7_A2055VouDHab, P00CP7_A135VouDFec, P00CP7_A130VouDSec
               }
               , new Object[] {
               P00CP8_A126TASICod, P00CP8_A129VouNum, P00CP8_A79COSCod, P00CP8_n79COSCod, P00CP8_A2077VouSts, P00CP8_A91CueCod, P00CP8_A128VouMes, P00CP8_A127VouAno, P00CP8_A2069VouDTcmb, P00CP8_A130VouDSec
               }
               , new Object[] {
               P00CP9_A126TASICod, P00CP9_A129VouNum, P00CP9_A2077VouSts, P00CP9_A79COSCod, P00CP9_n79COSCod, P00CP9_A133CueCodAux, P00CP9_A91CueCod, P00CP9_A128VouMes, P00CP9_A127VouAno, P00CP9_A2069VouDTcmb,
               P00CP9_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Ano ;
      private short AV9Mes ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short AV66Flag ;
      private short AV81Flag1 ;
      private short AV99GXLvl228 ;
      private short A2077VouSts ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A70TipACod ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int AV55TipACod ;
      private int A157TipSCod ;
      private int A131VouDMon ;
      private decimal AV49TDebePagMo ;
      private decimal AV50THaberPagMO ;
      private decimal AV51TDebePagMe ;
      private decimal AV52THaberPagMe ;
      private decimal AV56SaldoDMN ;
      private decimal AV57SaldoHMN ;
      private decimal AV58SaldoDME ;
      private decimal AV59SaldoHME ;
      private decimal AV60TDebeMO ;
      private decimal AV61ThaberMO ;
      private decimal AV62TDebeME ;
      private decimal AV63THaberME ;
      private decimal AV64SaldoMN ;
      private decimal AV65SaldoME ;
      private decimal AV86Saldo ;
      private decimal AV67TDebe ;
      private decimal AV68THaber ;
      private decimal AV69TDebeE ;
      private decimal AV70THaberE ;
      private decimal AV73SaldoDAMN ;
      private decimal AV74SaldoHAMN ;
      private decimal AV75SaldoDAME ;
      private decimal AV76SaldoHAME ;
      private decimal AV77TotalSDMN ;
      private decimal AV78TotalSHMN ;
      private decimal AV79TotalSDME ;
      private decimal AV80TotalSHME ;
      private decimal AV84DifMN ;
      private decimal AV85DifME ;
      private decimal A2069VouDTcmb ;
      private decimal A2052VouDDebO ;
      private decimal A2056VouDHabO ;
      private decimal A2051VouDDeb ;
      private decimal A2055VouDHab ;
      private decimal AV90DebeME ;
      private decimal AV91HaberME ;
      private string AV88cCuenta1 ;
      private string AV47Empresa ;
      private string AV46EmpDir ;
      private string AV45EmpRUC ;
      private string AV18FechaC ;
      private string AV44cMes ;
      private string GXt_char1 ;
      private string AV39Periodo ;
      private string AV38Path ;
      private string scmdbuf ;
      private string A133CueCodAux ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string A129VouNum ;
      private string AV53CueCod ;
      private string AV54CueDsc ;
      private string AV71CueCodAux ;
      private string AV72CueDAxu ;
      private string AV82TipAbr ;
      private string AV83CuedaxuDsc ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string A45CliCod ;
      private string A1916TipSAbr ;
      private string AV87cCosto ;
      private string A79COSCod ;
      private string A132VouDTipCod ;
      private string A2054VouDGls ;
      private string AV89VouDTipCod ;
      private string AV92Glosa ;
      private string A2075VouGls ;
      private DateTime AV19FechaD ;
      private DateTime A135VouDFec ;
      private bool returnInSub ;
      private bool BRKCP2 ;
      private bool n70TipACod ;
      private bool BRKCP4 ;
      private bool n79COSCod ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV41FilenameOrigen ;
      private IGxSession AV48Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_cCuenta1 ;
      private IDataStoreProvider pr_default ;
      private string[] P00CP2_A133CueCodAux ;
      private string[] P00CP2_A91CueCod ;
      private short[] P00CP2_A127VouAno ;
      private string[] P00CP2_A860CueDsc ;
      private int[] P00CP2_A70TipACod ;
      private bool[] P00CP2_n70TipACod ;
      private short[] P00CP2_A128VouMes ;
      private int[] P00CP2_A126TASICod ;
      private string[] P00CP2_A129VouNum ;
      private int[] P00CP2_A130VouDSec ;
      private string[] P00CP3_A91CueCod ;
      private string[] P00CP3_A133CueCodAux ;
      private short[] P00CP3_A127VouAno ;
      private short[] P00CP3_A128VouMes ;
      private int[] P00CP3_A126TASICod ;
      private string[] P00CP3_A129VouNum ;
      private int[] P00CP3_A130VouDSec ;
      private string[] P00CP4_A71TipADCod ;
      private int[] P00CP4_A70TipACod ;
      private bool[] P00CP4_n70TipACod ;
      private string[] P00CP4_A72TipADDsc ;
      private int[] P00CP5_A157TipSCod ;
      private string[] P00CP5_A45CliCod ;
      private string[] P00CP5_A1916TipSAbr ;
      private int[] P00CP6_A126TASICod ;
      private string[] P00CP6_A129VouNum ;
      private short[] P00CP6_A2077VouSts ;
      private string[] P00CP6_A79COSCod ;
      private bool[] P00CP6_n79COSCod ;
      private string[] P00CP6_A91CueCod ;
      private short[] P00CP6_A128VouMes ;
      private short[] P00CP6_A127VouAno ;
      private decimal[] P00CP6_A2069VouDTcmb ;
      private string[] P00CP6_A132VouDTipCod ;
      private string[] P00CP6_A2054VouDGls ;
      private int[] P00CP6_A131VouDMon ;
      private decimal[] P00CP6_A2052VouDDebO ;
      private decimal[] P00CP6_A2056VouDHabO ;
      private decimal[] P00CP6_A2051VouDDeb ;
      private decimal[] P00CP6_A2055VouDHab ;
      private DateTime[] P00CP6_A135VouDFec ;
      private int[] P00CP6_A130VouDSec ;
      private int[] P00CP7_A126TASICod ;
      private string[] P00CP7_A129VouNum ;
      private short[] P00CP7_A2077VouSts ;
      private string[] P00CP7_A79COSCod ;
      private bool[] P00CP7_n79COSCod ;
      private string[] P00CP7_A133CueCodAux ;
      private string[] P00CP7_A91CueCod ;
      private short[] P00CP7_A128VouMes ;
      private short[] P00CP7_A127VouAno ;
      private decimal[] P00CP7_A2069VouDTcmb ;
      private string[] P00CP7_A2075VouGls ;
      private string[] P00CP7_A132VouDTipCod ;
      private string[] P00CP7_A2054VouDGls ;
      private int[] P00CP7_A131VouDMon ;
      private decimal[] P00CP7_A2052VouDDebO ;
      private decimal[] P00CP7_A2056VouDHabO ;
      private decimal[] P00CP7_A2051VouDDeb ;
      private decimal[] P00CP7_A2055VouDHab ;
      private DateTime[] P00CP7_A135VouDFec ;
      private int[] P00CP7_A130VouDSec ;
      private int[] P00CP8_A126TASICod ;
      private string[] P00CP8_A129VouNum ;
      private string[] P00CP8_A79COSCod ;
      private bool[] P00CP8_n79COSCod ;
      private short[] P00CP8_A2077VouSts ;
      private string[] P00CP8_A91CueCod ;
      private short[] P00CP8_A128VouMes ;
      private short[] P00CP8_A127VouAno ;
      private decimal[] P00CP8_A2069VouDTcmb ;
      private int[] P00CP8_A130VouDSec ;
      private int[] P00CP9_A126TASICod ;
      private string[] P00CP9_A129VouNum ;
      private short[] P00CP9_A2077VouSts ;
      private string[] P00CP9_A79COSCod ;
      private bool[] P00CP9_n79COSCod ;
      private string[] P00CP9_A133CueCodAux ;
      private string[] P00CP9_A91CueCod ;
      private short[] P00CP9_A128VouMes ;
      private short[] P00CP9_A127VouAno ;
      private decimal[] P00CP9_A2069VouDTcmb ;
      private int[] P00CP9_A130VouDSec ;
      private string aP3_Filename ;
      private string aP4_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV37Archivo ;
   }

   public class pformato_3_3_excel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CP3( IGxContext context ,
                                             string AV71CueCodAux ,
                                             string A133CueCodAux ,
                                             short A127VouAno ,
                                             short AV8Ano ,
                                             string A91CueCod ,
                                             string AV53CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[3];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [CueCod], [CueCodAux], [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET]";
         AddWhere(sWhereString, "([VouAno] = @AV8Ano)");
         AddWhere(sWhereString, "([CueCod] = @AV53CueCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71CueCodAux)) )
         {
            AddWhere(sWhereString, "([CueCodAux] = @AV71CueCodAux)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueCodAux], [CueCod]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00CP6( IGxContext context ,
                                             string AV87cCosto ,
                                             string A79COSCod ,
                                             short A127VouAno ,
                                             short AV8Ano ,
                                             short A128VouMes ,
                                             short AV9Mes ,
                                             short A2077VouSts ,
                                             string AV53CueCod ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[COSCod], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T1.[VouDTipCod], T1.[VouDGls], T1.[VouDMon], T1.[VouDDebO], T1.[VouDHabO], T1.[VouDDeb], T1.[VouDHab], T1.[VouDFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV53CueCod)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV8Ano)");
         AddWhere(sWhereString, "(T1.[VouMes] = @AV9Mes)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV87cCosto)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[VouDFec]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00CP7( IGxContext context ,
                                             string AV87cCosto ,
                                             string A79COSCod ,
                                             short A127VouAno ,
                                             short AV8Ano ,
                                             short A128VouMes ,
                                             short AV9Mes ,
                                             string A133CueCodAux ,
                                             string AV72CueDAxu ,
                                             short A2077VouSts ,
                                             string AV53CueCod ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[5];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[COSCod], T1.[CueCodAux], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T2.[VouGls], T1.[VouDTipCod], T1.[VouDGls], T1.[VouDMon], T1.[VouDDebO], T1.[VouDHabO], T1.[VouDDeb], T1.[VouDHab], T1.[VouDFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV53CueCod)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV8Ano)");
         AddWhere(sWhereString, "(T1.[VouMes] = @AV9Mes)");
         AddWhere(sWhereString, "(T1.[CueCodAux] = @AV72CueDAxu)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV87cCosto)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[VouDFec]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00CP8( IGxContext context ,
                                             string AV87cCosto ,
                                             string A79COSCod ,
                                             short A2077VouSts ,
                                             short AV8Ano ,
                                             short AV9Mes ,
                                             string AV53CueCod ,
                                             short A127VouAno ,
                                             short A128VouMes ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[4];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T1.[COSCod], T2.[VouSts], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV8Ano and T1.[VouMes] = @AV9Mes and T1.[CueCod] = @AV53CueCod)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV87cCosto)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00CP9( IGxContext context ,
                                             string AV87cCosto ,
                                             string A79COSCod ,
                                             short A2077VouSts ,
                                             short AV8Ano ,
                                             short AV9Mes ,
                                             string AV53CueCod ,
                                             string AV72CueDAxu ,
                                             short A127VouAno ,
                                             short A128VouMes ,
                                             string A91CueCod ,
                                             string A133CueCodAux )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[5];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[COSCod], T1.[CueCodAux], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV8Ano and T1.[VouMes] = @AV9Mes and T1.[CueCod] = @AV53CueCod and T1.[CueCodAux] = @AV72CueDAxu)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV87cCosto)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod], T1.[CueCodAux]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00CP3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] );
               case 4 :
                     return conditional_P00CP6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] );
               case 5 :
                     return conditional_P00CP7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
               case 6 :
                     return conditional_P00CP8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] );
               case 7 :
                     return conditional_P00CP9(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
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
          Object[] prmP00CP2;
          prmP00CP2 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0)
          };
          Object[] prmP00CP4;
          prmP00CP4 = new Object[] {
          new ParDef("@AV55TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV72CueDAxu",GXType.NChar,20,0)
          };
          Object[] prmP00CP5;
          prmP00CP5 = new Object[] {
          new ParDef("@AV72CueDAxu",GXType.NChar,20,0)
          };
          Object[] prmP00CP3;
          prmP00CP3 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV53CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV71CueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00CP6;
          prmP00CP6 = new Object[] {
          new ParDef("@AV53CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV9Mes",GXType.Int16,2,0) ,
          new ParDef("@AV87cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00CP7;
          prmP00CP7 = new Object[] {
          new ParDef("@AV53CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV9Mes",GXType.Int16,2,0) ,
          new ParDef("@AV72CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV87cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00CP8;
          prmP00CP8 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV9Mes",GXType.Int16,2,0) ,
          new ParDef("@AV53CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV87cCosto",GXType.NChar,10,0)
          };
          Object[] prmP00CP9;
          prmP00CP9 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV9Mes",GXType.Int16,2,0) ,
          new ParDef("@AV53CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV72CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV87cCosto",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CP2", "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouAno], T2.[CueDsc], T2.[TipACod], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (SUBSTRING(T1.[CueCod], 1, 2) = '12') AND (T1.[VouAno] = @AV8Ano) ORDER BY T1.[CueCod], T1.[CueCodAux] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CP3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CP4", "SELECT [TipADCod], [TipACod], [TipADDsc] FROM [CBAUXILIARES] WHERE [TipACod] = @AV55TipACod and [TipADCod] = @AV72CueDAxu ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00CP5", "SELECT T1.[TipSCod], T1.[CliCod], T2.[TipSAbr] FROM ([CLCLIENTES] T1 INNER JOIN [CTIPDOCS] T2 ON T2.[TipSCod] = T1.[TipSCod]) WHERE T1.[CliCod] = @AV72CueDAxu ORDER BY T1.[CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CP6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CP7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CP8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CP9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP9,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 10);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 3);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(15);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(16);
                ((int[]) buf[17])[0] = rslt.getInt(17);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 15);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 3);
                ((string[]) buf[12])[0] = rslt.getString(12, 100);
                ((int[]) buf[13])[0] = rslt.getInt(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(17);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(18);
                ((int[]) buf[19])[0] = rslt.getInt(19);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 15);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                return;
       }
    }

 }

}
