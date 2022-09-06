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
   public class r_libromayorgeneralexcel : GXProcedure
   {
      public r_libromayorgeneralexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_libromayorgeneralexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref string aP2_cCuenta1 ,
                           ref string aP3_cCuenta2 ,
                           ref short aP4_cOpc ,
                           ref string aP5_cCosto ,
                           ref string aP6_cCosto2 ,
                           out string aP7_Filename ,
                           out string aP8_ErrorMessage )
      {
         this.AV8Ano = aP0_Ano;
         this.AV9Mes = aP1_Mes;
         this.AV44cCuenta1 = aP2_cCuenta1;
         this.AV45cCuenta2 = aP3_cCuenta2;
         this.AV86cOpc = aP4_cOpc;
         this.AV43cCosto = aP5_cCosto;
         this.AV88cCosto2 = aP6_cCosto2;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV9Mes;
         aP2_cCuenta1=this.AV44cCuenta1;
         aP3_cCuenta2=this.AV45cCuenta2;
         aP4_cOpc=this.AV86cOpc;
         aP5_cCosto=this.AV43cCosto;
         aP6_cCosto2=this.AV88cCosto2;
         aP7_Filename=this.AV10Filename;
         aP8_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref string aP2_cCuenta1 ,
                                ref string aP3_cCuenta2 ,
                                ref short aP4_cOpc ,
                                ref string aP5_cCosto ,
                                ref string aP6_cCosto2 ,
                                out string aP7_Filename )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_cCuenta1, ref aP3_cCuenta2, ref aP4_cOpc, ref aP5_cCosto, ref aP6_cCosto2, out aP7_Filename, out aP8_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_cCuenta1 ,
                                 ref string aP3_cCuenta2 ,
                                 ref short aP4_cOpc ,
                                 ref string aP5_cCosto ,
                                 ref string aP6_cCosto2 ,
                                 out string aP7_Filename ,
                                 out string aP8_ErrorMessage )
      {
         r_libromayorgeneralexcel objr_libromayorgeneralexcel;
         objr_libromayorgeneralexcel = new r_libromayorgeneralexcel();
         objr_libromayorgeneralexcel.AV8Ano = aP0_Ano;
         objr_libromayorgeneralexcel.AV9Mes = aP1_Mes;
         objr_libromayorgeneralexcel.AV44cCuenta1 = aP2_cCuenta1;
         objr_libromayorgeneralexcel.AV45cCuenta2 = aP3_cCuenta2;
         objr_libromayorgeneralexcel.AV86cOpc = aP4_cOpc;
         objr_libromayorgeneralexcel.AV43cCosto = aP5_cCosto;
         objr_libromayorgeneralexcel.AV88cCosto2 = aP6_cCosto2;
         objr_libromayorgeneralexcel.AV10Filename = "" ;
         objr_libromayorgeneralexcel.AV11ErrorMessage = "" ;
         objr_libromayorgeneralexcel.context.SetSubmitInitialConfig(context);
         objr_libromayorgeneralexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_libromayorgeneralexcel);
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV9Mes;
         aP2_cCuenta1=this.AV44cCuenta1;
         aP3_cCuenta2=this.AV45cCuenta2;
         aP4_cOpc=this.AV86cOpc;
         aP5_cCosto=this.AV43cCosto;
         aP6_cCosto2=this.AV88cCosto2;
         aP7_Filename=this.AV10Filename;
         aP8_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_libromayorgeneralexcel)stateInfo).executePrivate();
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
         AV37Archivo.Source = "Excel/PlantillasLibroMayor.xlsx";
         AV38Path = AV37Archivo.GetPath();
         AV41FilenameOrigen = StringUtil.Trim( AV38Path) + "\\PlantillasLibroMayor.xlsx";
         AV10Filename = "Excel/LibroMayorExcel" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV41FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S211 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV18FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV9Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0));
         AV19FechaD = context.localUtil.CToD( AV18FechaC, 2);
         GXt_char1 = AV42cMes;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV9Mes, out  GXt_char1) ;
         AV42cMes = GXt_char1;
         AV39Periodo = "Año : " + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0)) + " Mes : " + AV42cMes;
         AV14CellRow = 3;
         AV15FirstColumn = 5;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV39Periodo);
         AV14CellRow = 7;
         AV15FirstColumn = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44cCuenta1 ,
                                              AV45cCuenta2 ,
                                              AV43cCosto ,
                                              AV88cCosto2 ,
                                              A91CueCod ,
                                              A79COSCod ,
                                              A127VouAno ,
                                              AV8Ano } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BF2 */
         pr_default.execute(0, new Object[] {AV8Ano, AV44cCuenta1, AV45cCuenta2, AV43cCosto, AV88cCosto2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKBF2 = false;
            A133CueCodAux = P00BF2_A133CueCodAux[0];
            A91CueCod = P00BF2_A91CueCod[0];
            A79COSCod = P00BF2_A79COSCod[0];
            n79COSCod = P00BF2_n79COSCod[0];
            A127VouAno = P00BF2_A127VouAno[0];
            A860CueDsc = P00BF2_A860CueDsc[0];
            A70TipACod = P00BF2_A70TipACod[0];
            n70TipACod = P00BF2_n70TipACod[0];
            A128VouMes = P00BF2_A128VouMes[0];
            A126TASICod = P00BF2_A126TASICod[0];
            A129VouNum = P00BF2_A129VouNum[0];
            A130VouDSec = P00BF2_A130VouDSec[0];
            A860CueDsc = P00BF2_A860CueDsc[0];
            A70TipACod = P00BF2_A70TipACod[0];
            n70TipACod = P00BF2_n70TipACod[0];
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BF2_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRKBF2 = false;
               A133CueCodAux = P00BF2_A133CueCodAux[0];
               A127VouAno = P00BF2_A127VouAno[0];
               A128VouMes = P00BF2_A128VouMes[0];
               A126TASICod = P00BF2_A126TASICod[0];
               A129VouNum = P00BF2_A129VouNum[0];
               A130VouDSec = P00BF2_A130VouDSec[0];
               BRKBF2 = true;
               pr_default.readNext(0);
            }
            AV46CueCod = A91CueCod;
            AV47CueDsc = A860CueDsc;
            AV87TipACod = A70TipACod;
            AV48SaldoDMN = 0.00m;
            AV49SaldoHMN = 0.00m;
            AV50SaldoDME = 0.00m;
            AV51SaldoHME = 0.00m;
            AV52TDebeMO = 0.00m;
            AV53ThaberMO = 0.00m;
            AV54TDebeME = 0.00m;
            AV55THaberME = 0.00m;
            new GeneXus.Programs.contabilidad.pobtienesaldoscuenta(context ).execute( ref  AV46CueCod, ref  AV8Ano, ref  AV9Mes, out  AV48SaldoDMN, out  AV49SaldoHMN, out  AV50SaldoDME, out  AV51SaldoHME) ;
            AV56SaldoMN = (decimal)(AV48SaldoDMN-AV49SaldoHMN);
            AV57SaldoME = (decimal)(AV50SaldoDME-AV51SaldoHME);
            AV48SaldoDMN = ((AV56SaldoMN>Convert.ToDecimal(0)) ? AV56SaldoMN : (decimal)(0));
            AV49SaldoHMN = ((AV56SaldoMN<Convert.ToDecimal(0)) ? AV56SaldoMN*-1 : (decimal)(0));
            AV50SaldoDME = ((AV57SaldoME>Convert.ToDecimal(0)) ? AV57SaldoME : (decimal)(0));
            AV51SaldoHME = ((AV57SaldoME<Convert.ToDecimal(0)) ? AV57SaldoME*-1 : (decimal)(0));
            AV62Flag = 0;
            if ( ! (Convert.ToDecimal(0)==AV48SaldoDMN) || ! (Convert.ToDecimal(0)==AV49SaldoHMN) || ! (Convert.ToDecimal(0)==AV50SaldoDME) || ! (Convert.ToDecimal(0)==AV51SaldoHME) )
            {
               AV62Flag = 1;
            }
            /* Execute user subroutine: 'VALIDAMOV' */
            S201 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( AV62Flag == 1 )
            {
               /* Execute user subroutine: 'PRINTAGRUPACUENTA' */
               S221 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
            }
            /* Execute user subroutine: 'AUXILIARES' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( ! BRKBF2 )
            {
               BRKBF2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S211 ();
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
         /* 'AUXILIARES' Routine */
         returnInSub = false;
         if ( AV87TipACod > 0 )
         {
            AV80TDebe = 0.00m;
            AV81THaber = 0.00m;
            AV83TDebeE = 0.00m;
            AV82THaberE = 0.00m;
            /* Using cursor P00BF3 */
            pr_default.execute(1, new Object[] {AV8Ano, AV46CueCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRKBF4 = false;
               A134CueAuxCod = P00BF3_A134CueAuxCod[0];
               A133CueCodAux = P00BF3_A133CueCodAux[0];
               A91CueCod = P00BF3_A91CueCod[0];
               A127VouAno = P00BF3_A127VouAno[0];
               A128VouMes = P00BF3_A128VouMes[0];
               A126TASICod = P00BF3_A126TASICod[0];
               A129VouNum = P00BF3_A129VouNum[0];
               A130VouDSec = P00BF3_A130VouDSec[0];
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00BF3_A133CueCodAux[0], A133CueCodAux) == 0 ) )
               {
                  BRKBF4 = false;
                  A134CueAuxCod = P00BF3_A134CueAuxCod[0];
                  A127VouAno = P00BF3_A127VouAno[0];
                  A128VouMes = P00BF3_A128VouMes[0];
                  A126TASICod = P00BF3_A126TASICod[0];
                  A129VouNum = P00BF3_A129VouNum[0];
                  A130VouDSec = P00BF3_A130VouDSec[0];
                  BRKBF4 = true;
                  pr_default.readNext(1);
               }
               AV64CueDAxu = A133CueCodAux;
               /* Execute user subroutine: 'NOMBREAUXILIAR' */
               S124 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               AV58SaldoDAMN = 0.00m;
               AV59SaldoHAMN = 0.00m;
               AV60SaldoDAME = 0.00m;
               AV61SaldoHAME = 0.00m;
               AV76TotalSDMN = 0.00m;
               AV77TotalSHMN = 0.00m;
               AV78TotalSDME = 0.00m;
               AV79TotalSHME = 0.00m;
               AV63Flag1 = 0;
               new GeneXus.Programs.contabilidad.pobtienesaldoscuentaauxiliar(context ).execute( ref  AV46CueCod, ref  AV64CueDAxu, ref  AV8Ano, ref  AV9Mes, out  AV58SaldoDAMN, out  AV59SaldoHAMN, out  AV60SaldoDAME, out  AV61SaldoHAME) ;
               AV56SaldoMN = (decimal)(AV58SaldoDAMN-AV59SaldoHAMN);
               AV57SaldoME = (decimal)(AV60SaldoDAME-AV61SaldoHAME);
               AV58SaldoDAMN = ((AV56SaldoMN>Convert.ToDecimal(0)) ? AV56SaldoMN : (decimal)(0));
               AV59SaldoHAMN = ((AV56SaldoMN<Convert.ToDecimal(0)) ? AV56SaldoMN*-1 : (decimal)(0));
               AV60SaldoDAME = ((AV57SaldoME>Convert.ToDecimal(0)) ? AV57SaldoME : (decimal)(0));
               AV61SaldoHAME = ((AV57SaldoME<Convert.ToDecimal(0)) ? AV57SaldoME*-1 : (decimal)(0));
               if ( ! (Convert.ToDecimal(0)==AV58SaldoDAMN) || ! (Convert.ToDecimal(0)==AV59SaldoHAMN) || ! (Convert.ToDecimal(0)==AV60SaldoDAME) || ! (Convert.ToDecimal(0)==AV61SaldoHAME) )
               {
                  AV63Flag1 = 1;
               }
               AV76TotalSDMN = AV58SaldoDAMN;
               AV77TotalSHMN = AV59SaldoHAMN;
               AV78TotalSDME = AV60SaldoDAME;
               AV79TotalSHME = AV61SaldoHAME;
               /* Execute user subroutine: 'VALIDAMOVAUXILIAR' */
               S134 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV63Flag1 == 1 )
               {
                  /* Execute user subroutine: 'PRINTAGRUPAAUXILIAR' */
                  S144 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               /* Execute user subroutine: 'MOVIMIENTOSAUXILIAR' */
               S154 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               AV80TDebe = (decimal)(AV80TDebe+AV76TotalSDMN);
               AV81THaber = (decimal)(AV81THaber+AV77TotalSHMN);
               AV83TDebeE = (decimal)(AV83TDebeE+AV78TotalSDME);
               AV82THaberE = (decimal)(AV82THaberE+AV79TotalSHME);
               if ( AV63Flag1 == 1 )
               {
                  AV84DifMN = (decimal)(AV76TotalSDMN-AV77TotalSHMN);
                  AV85DifME = (decimal)(AV78TotalSDME-AV79TotalSHME);
                  /* Execute user subroutine: 'PRINTTOTALAUXILIAR' */
                  S164 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               if ( ! BRKBF4 )
               {
                  BRKBF4 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
         }
         else
         {
            AV64CueDAxu = "";
            AV76TotalSDMN = 0.00m;
            AV77TotalSHMN = 0.00m;
            AV78TotalSDME = 0.00m;
            AV79TotalSHME = 0.00m;
            AV80TDebe = AV48SaldoDMN;
            AV81THaber = AV49SaldoHMN;
            AV83TDebeE = AV50SaldoDME;
            AV82THaberE = AV51SaldoHME;
            /* Execute user subroutine: 'MOVIMIENTOS' */
            S171 ();
            if (returnInSub) return;
            AV80TDebe = (decimal)(AV80TDebe+AV76TotalSDMN);
            AV81THaber = (decimal)(AV81THaber+AV77TotalSHMN);
            AV83TDebeE = (decimal)(AV83TDebeE+AV78TotalSDME);
            AV82THaberE = (decimal)(AV82THaberE+AV79TotalSHME);
         }
         AV52TDebeMO = AV80TDebe;
         AV53ThaberMO = AV81THaber;
         AV54TDebeME = AV83TDebeE;
         AV55THaberME = AV82THaberE;
         if ( AV62Flag == 1 )
         {
            AV84DifMN = (decimal)(AV52TDebeMO-AV53ThaberMO);
            AV85DifME = (decimal)(AV54TDebeME-AV55THaberME);
            /* Execute user subroutine: 'PRINTTOTALCUENTA' */
            S181 ();
            if (returnInSub) return;
         }
      }

      protected void S124( )
      {
         /* 'NOMBREAUXILIAR' Routine */
         returnInSub = false;
         AV96GXLvl197 = 0;
         /* Using cursor P00BF4 */
         pr_default.execute(2, new Object[] {AV87TipACod, AV64CueDAxu});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A71TipADCod = P00BF4_A71TipADCod[0];
            A70TipACod = P00BF4_A70TipACod[0];
            n70TipACod = P00BF4_n70TipACod[0];
            A72TipADDsc = P00BF4_A72TipADDsc[0];
            AV96GXLvl197 = 1;
            AV65CueDAxuDsc = A72TipADDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( AV96GXLvl197 == 0 )
         {
            AV65CueDAxuDsc = "SIN AUXILIAR";
         }
      }

      protected void S171( )
      {
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV43cCosto ,
                                              AV88cCosto2 ,
                                              A79COSCod ,
                                              A127VouAno ,
                                              AV8Ano ,
                                              A128VouMes ,
                                              AV9Mes ,
                                              A2077VouSts ,
                                              AV46CueCod ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BF5 */
         pr_default.execute(3, new Object[] {AV46CueCod, AV8Ano, AV9Mes, AV43cCosto, AV88cCosto2});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A126TASICod = P00BF5_A126TASICod[0];
            A2077VouSts = P00BF5_A2077VouSts[0];
            A79COSCod = P00BF5_A79COSCod[0];
            n79COSCod = P00BF5_n79COSCod[0];
            A91CueCod = P00BF5_A91CueCod[0];
            A128VouMes = P00BF5_A128VouMes[0];
            A127VouAno = P00BF5_A127VouAno[0];
            A2069VouDTcmb = P00BF5_A2069VouDTcmb[0];
            A1894TASIAbr = P00BF5_A1894TASIAbr[0];
            A129VouNum = P00BF5_A129VouNum[0];
            A2053VouDDoc = P00BF5_A2053VouDDoc[0];
            A136VouReg = P00BF5_A136VouReg[0];
            A2051VouDDeb = P00BF5_A2051VouDDeb[0];
            A2055VouDHab = P00BF5_A2055VouDHab[0];
            A2075VouGls = P00BF5_A2075VouGls[0];
            A2054VouDGls = P00BF5_A2054VouDGls[0];
            A131VouDMon = P00BF5_A131VouDMon[0];
            A2052VouDDebO = P00BF5_A2052VouDDebO[0];
            A2056VouDHabO = P00BF5_A2056VouDHabO[0];
            A135VouDFec = P00BF5_A135VouDFec[0];
            A130VouDSec = P00BF5_A130VouDSec[0];
            A1894TASIAbr = P00BF5_A1894TASIAbr[0];
            A2077VouSts = P00BF5_A2077VouSts[0];
            A2075VouGls = P00BF5_A2075VouGls[0];
            AV66TasiAbr = A1894TASIAbr;
            AV67VouNum = A129VouNum;
            AV68VouDFec = A135VouDFec;
            AV69VouDDoc = A2053VouDDoc;
            AV70VouReg = A136VouReg;
            AV71VouDDeb = A2051VouDDeb;
            AV72VouDHab = A2055VouDHab;
            AV89COSCod = A79COSCod;
            AV74DebeME = 0.00m;
            AV75HaberME = 0.00m;
            AV73Glosa = StringUtil.Trim( A2075VouGls);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV73Glosa = StringUtil.Trim( A2054VouDGls);
            }
            if ( ! ( A131VouDMon == 1 ) )
            {
               AV74DebeME = A2052VouDDebO;
               AV75HaberME = A2056VouDHabO;
            }
            /* Execute user subroutine: 'PRINTMOVIMIENTOS' */
            S197 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV76TotalSDMN = (decimal)(AV76TotalSDMN+A2051VouDDeb);
            AV77TotalSHMN = (decimal)(AV77TotalSHMN+A2055VouDHab);
            AV78TotalSDME = (decimal)(AV78TotalSDME+AV74DebeME);
            AV79TotalSHME = (decimal)(AV79TotalSHME+AV75HaberME);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S154( )
      {
         /* 'MOVIMIENTOSAUXILIAR' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV43cCosto ,
                                              AV88cCosto2 ,
                                              A79COSCod ,
                                              A127VouAno ,
                                              AV8Ano ,
                                              A128VouMes ,
                                              AV9Mes ,
                                              A133CueCodAux ,
                                              AV64CueDAxu ,
                                              A2077VouSts ,
                                              AV46CueCod ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BF6 */
         pr_default.execute(4, new Object[] {AV46CueCod, AV8Ano, AV9Mes, AV64CueDAxu, AV43cCosto, AV88cCosto2});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A126TASICod = P00BF6_A126TASICod[0];
            A2077VouSts = P00BF6_A2077VouSts[0];
            A79COSCod = P00BF6_A79COSCod[0];
            n79COSCod = P00BF6_n79COSCod[0];
            A133CueCodAux = P00BF6_A133CueCodAux[0];
            A91CueCod = P00BF6_A91CueCod[0];
            A128VouMes = P00BF6_A128VouMes[0];
            A127VouAno = P00BF6_A127VouAno[0];
            A2069VouDTcmb = P00BF6_A2069VouDTcmb[0];
            A1894TASIAbr = P00BF6_A1894TASIAbr[0];
            A129VouNum = P00BF6_A129VouNum[0];
            A2053VouDDoc = P00BF6_A2053VouDDoc[0];
            A136VouReg = P00BF6_A136VouReg[0];
            A2051VouDDeb = P00BF6_A2051VouDDeb[0];
            A2055VouDHab = P00BF6_A2055VouDHab[0];
            A2075VouGls = P00BF6_A2075VouGls[0];
            A2054VouDGls = P00BF6_A2054VouDGls[0];
            A131VouDMon = P00BF6_A131VouDMon[0];
            A2052VouDDebO = P00BF6_A2052VouDDebO[0];
            A2056VouDHabO = P00BF6_A2056VouDHabO[0];
            A135VouDFec = P00BF6_A135VouDFec[0];
            A130VouDSec = P00BF6_A130VouDSec[0];
            A1894TASIAbr = P00BF6_A1894TASIAbr[0];
            A2077VouSts = P00BF6_A2077VouSts[0];
            A2075VouGls = P00BF6_A2075VouGls[0];
            AV66TasiAbr = A1894TASIAbr;
            AV67VouNum = A129VouNum;
            AV68VouDFec = A135VouDFec;
            AV69VouDDoc = A2053VouDDoc;
            AV70VouReg = A136VouReg;
            AV71VouDDeb = A2051VouDDeb;
            AV72VouDHab = A2055VouDHab;
            AV89COSCod = A79COSCod;
            AV74DebeME = 0.00m;
            AV75HaberME = 0.00m;
            AV73Glosa = StringUtil.Trim( A2075VouGls);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV73Glosa = StringUtil.Trim( A2054VouDGls);
            }
            if ( ! ( A131VouDMon == 1 ) )
            {
               AV74DebeME = A2052VouDDebO;
               AV75HaberME = A2056VouDHabO;
            }
            /* Execute user subroutine: 'PRINTMOVIMIENTOS' */
            S197 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            AV76TotalSDMN = (decimal)(AV76TotalSDMN+A2051VouDDeb);
            AV77TotalSHMN = (decimal)(AV77TotalSHMN+A2055VouDHab);
            AV78TotalSDME = (decimal)(AV78TotalSDME+AV74DebeME);
            AV79TotalSHME = (decimal)(AV79TotalSHME+AV75HaberME);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S201( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV43cCosto ,
                                              AV88cCosto2 ,
                                              A79COSCod ,
                                              A2077VouSts ,
                                              AV8Ano ,
                                              AV9Mes ,
                                              AV46CueCod ,
                                              A127VouAno ,
                                              A128VouMes ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BF7 */
         pr_default.execute(5, new Object[] {AV8Ano, AV9Mes, AV46CueCod, AV43cCosto, AV88cCosto2});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A126TASICod = P00BF7_A126TASICod[0];
            A129VouNum = P00BF7_A129VouNum[0];
            A79COSCod = P00BF7_A79COSCod[0];
            n79COSCod = P00BF7_n79COSCod[0];
            A2077VouSts = P00BF7_A2077VouSts[0];
            A91CueCod = P00BF7_A91CueCod[0];
            A128VouMes = P00BF7_A128VouMes[0];
            A127VouAno = P00BF7_A127VouAno[0];
            A2069VouDTcmb = P00BF7_A2069VouDTcmb[0];
            A130VouDSec = P00BF7_A130VouDSec[0];
            A2077VouSts = P00BF7_A2077VouSts[0];
            AV62Flag = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S134( )
      {
         /* 'VALIDAMOVAUXILIAR' Routine */
         returnInSub = false;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV43cCosto ,
                                              AV88cCosto2 ,
                                              A79COSCod ,
                                              A2077VouSts ,
                                              AV8Ano ,
                                              AV9Mes ,
                                              AV46CueCod ,
                                              AV64CueDAxu ,
                                              A127VouAno ,
                                              A128VouMes ,
                                              A91CueCod ,
                                              A133CueCodAux } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BF8 */
         pr_default.execute(6, new Object[] {AV8Ano, AV9Mes, AV46CueCod, AV64CueDAxu, AV43cCosto, AV88cCosto2});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A126TASICod = P00BF8_A126TASICod[0];
            A129VouNum = P00BF8_A129VouNum[0];
            A2077VouSts = P00BF8_A2077VouSts[0];
            A79COSCod = P00BF8_A79COSCod[0];
            n79COSCod = P00BF8_n79COSCod[0];
            A133CueCodAux = P00BF8_A133CueCodAux[0];
            A91CueCod = P00BF8_A91CueCod[0];
            A128VouMes = P00BF8_A128VouMes[0];
            A127VouAno = P00BF8_A127VouAno[0];
            A2069VouDTcmb = P00BF8_A2069VouDTcmb[0];
            A130VouDSec = P00BF8_A130VouDSec[0];
            A2077VouSts = P00BF8_A2077VouSts[0];
            AV63Flag1 = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S211( )
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

      protected void S221( )
      {
         /* 'PRINTAGRUPACUENTA' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV46CueCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV47CueDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = "Saldo Anterior Cuenta";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV48SaldoDMN);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV49SaldoHMN);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV50SaldoDME);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV51SaldoHME);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S144( )
      {
         /* 'PRINTAGRUPAAUXILIAR' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV64CueDAxu);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV65CueDAxuDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = "Saldo Anterior Auxiliar";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV58SaldoDAMN);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV59SaldoHAMN);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV60SaldoDAME);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV61SaldoHAME);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S197( )
      {
         /* 'PRINTMOVIMIENTOS' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV66TasiAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV67VouNum);
         GXt_dtime2 = DateTimeUtil.ResetTime( AV68VouDFec ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Date = GXt_dtime2;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV69VouDDoc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV70VouReg);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV89COSCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV73Glosa);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV71VouDDeb);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV72VouDHab);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV74DebeME);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV75HaberME);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S164( )
      {
         /* 'PRINTTOTALAUXILIAR' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = "Total Auxiliar "+StringUtil.Trim( AV64CueDAxu);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV76TotalSDMN);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV77TotalSHMN);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV78TotalSDME);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV79TotalSHME);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S181( )
      {
         /* 'PRINTTOTALCUENTA' Routine */
         returnInSub = false;
         AV14CellRow = (int)(AV14CellRow+1);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = "Total Cuenta "+StringUtil.Trim( AV46CueCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV52TDebeMO);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV53ThaberMO);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV54TDebeME);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV55THaberME);
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
         AV37Archivo = new GxFile(context.GetPhysicalPath());
         AV38Path = "";
         AV41FilenameOrigen = "";
         AV13ExcelDocument = new ExcelDocumentI();
         AV18FechaC = "";
         AV19FechaD = DateTime.MinValue;
         AV42cMes = "";
         GXt_char1 = "";
         AV39Periodo = "";
         scmdbuf = "";
         A91CueCod = "";
         A79COSCod = "";
         P00BF2_A133CueCodAux = new string[] {""} ;
         P00BF2_A91CueCod = new string[] {""} ;
         P00BF2_A79COSCod = new string[] {""} ;
         P00BF2_n79COSCod = new bool[] {false} ;
         P00BF2_A127VouAno = new short[1] ;
         P00BF2_A860CueDsc = new string[] {""} ;
         P00BF2_A70TipACod = new int[1] ;
         P00BF2_n70TipACod = new bool[] {false} ;
         P00BF2_A128VouMes = new short[1] ;
         P00BF2_A126TASICod = new int[1] ;
         P00BF2_A129VouNum = new string[] {""} ;
         P00BF2_A130VouDSec = new int[1] ;
         A133CueCodAux = "";
         A860CueDsc = "";
         A129VouNum = "";
         AV46CueCod = "";
         AV47CueDsc = "";
         P00BF3_A134CueAuxCod = new string[] {""} ;
         P00BF3_A133CueCodAux = new string[] {""} ;
         P00BF3_A91CueCod = new string[] {""} ;
         P00BF3_A127VouAno = new short[1] ;
         P00BF3_A128VouMes = new short[1] ;
         P00BF3_A126TASICod = new int[1] ;
         P00BF3_A129VouNum = new string[] {""} ;
         P00BF3_A130VouDSec = new int[1] ;
         A134CueAuxCod = "";
         AV64CueDAxu = "";
         P00BF4_A71TipADCod = new string[] {""} ;
         P00BF4_A70TipACod = new int[1] ;
         P00BF4_n70TipACod = new bool[] {false} ;
         P00BF4_A72TipADDsc = new string[] {""} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         AV65CueDAxuDsc = "";
         P00BF5_A126TASICod = new int[1] ;
         P00BF5_A2077VouSts = new short[1] ;
         P00BF5_A79COSCod = new string[] {""} ;
         P00BF5_n79COSCod = new bool[] {false} ;
         P00BF5_A91CueCod = new string[] {""} ;
         P00BF5_A128VouMes = new short[1] ;
         P00BF5_A127VouAno = new short[1] ;
         P00BF5_A2069VouDTcmb = new decimal[1] ;
         P00BF5_A1894TASIAbr = new string[] {""} ;
         P00BF5_A129VouNum = new string[] {""} ;
         P00BF5_A2053VouDDoc = new string[] {""} ;
         P00BF5_A136VouReg = new string[] {""} ;
         P00BF5_A2051VouDDeb = new decimal[1] ;
         P00BF5_A2055VouDHab = new decimal[1] ;
         P00BF5_A2075VouGls = new string[] {""} ;
         P00BF5_A2054VouDGls = new string[] {""} ;
         P00BF5_A131VouDMon = new int[1] ;
         P00BF5_A2052VouDDebO = new decimal[1] ;
         P00BF5_A2056VouDHabO = new decimal[1] ;
         P00BF5_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BF5_A130VouDSec = new int[1] ;
         A1894TASIAbr = "";
         A2053VouDDoc = "";
         A136VouReg = "";
         A2075VouGls = "";
         A2054VouDGls = "";
         A135VouDFec = DateTime.MinValue;
         AV66TasiAbr = "";
         AV67VouNum = "";
         AV68VouDFec = DateTime.MinValue;
         AV69VouDDoc = "";
         AV70VouReg = "";
         AV89COSCod = "";
         AV73Glosa = "";
         P00BF6_A126TASICod = new int[1] ;
         P00BF6_A2077VouSts = new short[1] ;
         P00BF6_A79COSCod = new string[] {""} ;
         P00BF6_n79COSCod = new bool[] {false} ;
         P00BF6_A133CueCodAux = new string[] {""} ;
         P00BF6_A91CueCod = new string[] {""} ;
         P00BF6_A128VouMes = new short[1] ;
         P00BF6_A127VouAno = new short[1] ;
         P00BF6_A2069VouDTcmb = new decimal[1] ;
         P00BF6_A1894TASIAbr = new string[] {""} ;
         P00BF6_A129VouNum = new string[] {""} ;
         P00BF6_A2053VouDDoc = new string[] {""} ;
         P00BF6_A136VouReg = new string[] {""} ;
         P00BF6_A2051VouDDeb = new decimal[1] ;
         P00BF6_A2055VouDHab = new decimal[1] ;
         P00BF6_A2075VouGls = new string[] {""} ;
         P00BF6_A2054VouDGls = new string[] {""} ;
         P00BF6_A131VouDMon = new int[1] ;
         P00BF6_A2052VouDDebO = new decimal[1] ;
         P00BF6_A2056VouDHabO = new decimal[1] ;
         P00BF6_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BF6_A130VouDSec = new int[1] ;
         P00BF7_A126TASICod = new int[1] ;
         P00BF7_A129VouNum = new string[] {""} ;
         P00BF7_A79COSCod = new string[] {""} ;
         P00BF7_n79COSCod = new bool[] {false} ;
         P00BF7_A2077VouSts = new short[1] ;
         P00BF7_A91CueCod = new string[] {""} ;
         P00BF7_A128VouMes = new short[1] ;
         P00BF7_A127VouAno = new short[1] ;
         P00BF7_A2069VouDTcmb = new decimal[1] ;
         P00BF7_A130VouDSec = new int[1] ;
         P00BF8_A126TASICod = new int[1] ;
         P00BF8_A129VouNum = new string[] {""} ;
         P00BF8_A2077VouSts = new short[1] ;
         P00BF8_A79COSCod = new string[] {""} ;
         P00BF8_n79COSCod = new bool[] {false} ;
         P00BF8_A133CueCodAux = new string[] {""} ;
         P00BF8_A91CueCod = new string[] {""} ;
         P00BF8_A128VouMes = new short[1] ;
         P00BF8_A127VouAno = new short[1] ;
         P00BF8_A2069VouDTcmb = new decimal[1] ;
         P00BF8_A130VouDSec = new int[1] ;
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_libromayorgeneralexcel__default(),
            new Object[][] {
                new Object[] {
               P00BF2_A133CueCodAux, P00BF2_A91CueCod, P00BF2_A79COSCod, P00BF2_n79COSCod, P00BF2_A127VouAno, P00BF2_A860CueDsc, P00BF2_A70TipACod, P00BF2_n70TipACod, P00BF2_A128VouMes, P00BF2_A126TASICod,
               P00BF2_A129VouNum, P00BF2_A130VouDSec
               }
               , new Object[] {
               P00BF3_A134CueAuxCod, P00BF3_A133CueCodAux, P00BF3_A91CueCod, P00BF3_A127VouAno, P00BF3_A128VouMes, P00BF3_A126TASICod, P00BF3_A129VouNum, P00BF3_A130VouDSec
               }
               , new Object[] {
               P00BF4_A71TipADCod, P00BF4_A70TipACod, P00BF4_A72TipADDsc
               }
               , new Object[] {
               P00BF5_A126TASICod, P00BF5_A2077VouSts, P00BF5_A79COSCod, P00BF5_n79COSCod, P00BF5_A91CueCod, P00BF5_A128VouMes, P00BF5_A127VouAno, P00BF5_A2069VouDTcmb, P00BF5_A1894TASIAbr, P00BF5_A129VouNum,
               P00BF5_A2053VouDDoc, P00BF5_A136VouReg, P00BF5_A2051VouDDeb, P00BF5_A2055VouDHab, P00BF5_A2075VouGls, P00BF5_A2054VouDGls, P00BF5_A131VouDMon, P00BF5_A2052VouDDebO, P00BF5_A2056VouDHabO, P00BF5_A135VouDFec,
               P00BF5_A130VouDSec
               }
               , new Object[] {
               P00BF6_A126TASICod, P00BF6_A2077VouSts, P00BF6_A79COSCod, P00BF6_n79COSCod, P00BF6_A133CueCodAux, P00BF6_A91CueCod, P00BF6_A128VouMes, P00BF6_A127VouAno, P00BF6_A2069VouDTcmb, P00BF6_A1894TASIAbr,
               P00BF6_A129VouNum, P00BF6_A2053VouDDoc, P00BF6_A136VouReg, P00BF6_A2051VouDDeb, P00BF6_A2055VouDHab, P00BF6_A2075VouGls, P00BF6_A2054VouDGls, P00BF6_A131VouDMon, P00BF6_A2052VouDDebO, P00BF6_A2056VouDHabO,
               P00BF6_A135VouDFec, P00BF6_A130VouDSec
               }
               , new Object[] {
               P00BF7_A126TASICod, P00BF7_A129VouNum, P00BF7_A79COSCod, P00BF7_n79COSCod, P00BF7_A2077VouSts, P00BF7_A91CueCod, P00BF7_A128VouMes, P00BF7_A127VouAno, P00BF7_A2069VouDTcmb, P00BF7_A130VouDSec
               }
               , new Object[] {
               P00BF8_A126TASICod, P00BF8_A129VouNum, P00BF8_A2077VouSts, P00BF8_A79COSCod, P00BF8_n79COSCod, P00BF8_A133CueCodAux, P00BF8_A91CueCod, P00BF8_A128VouMes, P00BF8_A127VouAno, P00BF8_A2069VouDTcmb,
               P00BF8_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Ano ;
      private short AV9Mes ;
      private short AV86cOpc ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short AV62Flag ;
      private short AV63Flag1 ;
      private short AV96GXLvl197 ;
      private short A2077VouSts ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A70TipACod ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int AV87TipACod ;
      private int A131VouDMon ;
      private decimal AV48SaldoDMN ;
      private decimal AV49SaldoHMN ;
      private decimal AV50SaldoDME ;
      private decimal AV51SaldoHME ;
      private decimal AV52TDebeMO ;
      private decimal AV53ThaberMO ;
      private decimal AV54TDebeME ;
      private decimal AV55THaberME ;
      private decimal AV56SaldoMN ;
      private decimal AV57SaldoME ;
      private decimal AV80TDebe ;
      private decimal AV81THaber ;
      private decimal AV83TDebeE ;
      private decimal AV82THaberE ;
      private decimal AV58SaldoDAMN ;
      private decimal AV59SaldoHAMN ;
      private decimal AV60SaldoDAME ;
      private decimal AV61SaldoHAME ;
      private decimal AV76TotalSDMN ;
      private decimal AV77TotalSHMN ;
      private decimal AV78TotalSDME ;
      private decimal AV79TotalSHME ;
      private decimal AV84DifMN ;
      private decimal AV85DifME ;
      private decimal A2069VouDTcmb ;
      private decimal A2051VouDDeb ;
      private decimal A2055VouDHab ;
      private decimal A2052VouDDebO ;
      private decimal A2056VouDHabO ;
      private decimal AV71VouDDeb ;
      private decimal AV72VouDHab ;
      private decimal AV74DebeME ;
      private decimal AV75HaberME ;
      private string AV44cCuenta1 ;
      private string AV45cCuenta2 ;
      private string AV43cCosto ;
      private string AV88cCosto2 ;
      private string AV38Path ;
      private string AV18FechaC ;
      private string AV42cMes ;
      private string GXt_char1 ;
      private string AV39Periodo ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A79COSCod ;
      private string A133CueCodAux ;
      private string A860CueDsc ;
      private string A129VouNum ;
      private string AV46CueCod ;
      private string AV47CueDsc ;
      private string A134CueAuxCod ;
      private string AV64CueDAxu ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string AV65CueDAxuDsc ;
      private string A1894TASIAbr ;
      private string A2053VouDDoc ;
      private string A136VouReg ;
      private string A2075VouGls ;
      private string A2054VouDGls ;
      private string AV66TasiAbr ;
      private string AV67VouNum ;
      private string AV69VouDDoc ;
      private string AV70VouReg ;
      private string AV89COSCod ;
      private string AV73Glosa ;
      private DateTime GXt_dtime2 ;
      private DateTime AV19FechaD ;
      private DateTime A135VouDFec ;
      private DateTime AV68VouDFec ;
      private bool returnInSub ;
      private bool BRKBF2 ;
      private bool n79COSCod ;
      private bool n70TipACod ;
      private bool BRKBF4 ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV41FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_cCuenta1 ;
      private string aP3_cCuenta2 ;
      private short aP4_cOpc ;
      private string aP5_cCosto ;
      private string aP6_cCosto2 ;
      private IDataStoreProvider pr_default ;
      private string[] P00BF2_A133CueCodAux ;
      private string[] P00BF2_A91CueCod ;
      private string[] P00BF2_A79COSCod ;
      private bool[] P00BF2_n79COSCod ;
      private short[] P00BF2_A127VouAno ;
      private string[] P00BF2_A860CueDsc ;
      private int[] P00BF2_A70TipACod ;
      private bool[] P00BF2_n70TipACod ;
      private short[] P00BF2_A128VouMes ;
      private int[] P00BF2_A126TASICod ;
      private string[] P00BF2_A129VouNum ;
      private int[] P00BF2_A130VouDSec ;
      private string[] P00BF3_A134CueAuxCod ;
      private string[] P00BF3_A133CueCodAux ;
      private string[] P00BF3_A91CueCod ;
      private short[] P00BF3_A127VouAno ;
      private short[] P00BF3_A128VouMes ;
      private int[] P00BF3_A126TASICod ;
      private string[] P00BF3_A129VouNum ;
      private int[] P00BF3_A130VouDSec ;
      private string[] P00BF4_A71TipADCod ;
      private int[] P00BF4_A70TipACod ;
      private bool[] P00BF4_n70TipACod ;
      private string[] P00BF4_A72TipADDsc ;
      private int[] P00BF5_A126TASICod ;
      private short[] P00BF5_A2077VouSts ;
      private string[] P00BF5_A79COSCod ;
      private bool[] P00BF5_n79COSCod ;
      private string[] P00BF5_A91CueCod ;
      private short[] P00BF5_A128VouMes ;
      private short[] P00BF5_A127VouAno ;
      private decimal[] P00BF5_A2069VouDTcmb ;
      private string[] P00BF5_A1894TASIAbr ;
      private string[] P00BF5_A129VouNum ;
      private string[] P00BF5_A2053VouDDoc ;
      private string[] P00BF5_A136VouReg ;
      private decimal[] P00BF5_A2051VouDDeb ;
      private decimal[] P00BF5_A2055VouDHab ;
      private string[] P00BF5_A2075VouGls ;
      private string[] P00BF5_A2054VouDGls ;
      private int[] P00BF5_A131VouDMon ;
      private decimal[] P00BF5_A2052VouDDebO ;
      private decimal[] P00BF5_A2056VouDHabO ;
      private DateTime[] P00BF5_A135VouDFec ;
      private int[] P00BF5_A130VouDSec ;
      private int[] P00BF6_A126TASICod ;
      private short[] P00BF6_A2077VouSts ;
      private string[] P00BF6_A79COSCod ;
      private bool[] P00BF6_n79COSCod ;
      private string[] P00BF6_A133CueCodAux ;
      private string[] P00BF6_A91CueCod ;
      private short[] P00BF6_A128VouMes ;
      private short[] P00BF6_A127VouAno ;
      private decimal[] P00BF6_A2069VouDTcmb ;
      private string[] P00BF6_A1894TASIAbr ;
      private string[] P00BF6_A129VouNum ;
      private string[] P00BF6_A2053VouDDoc ;
      private string[] P00BF6_A136VouReg ;
      private decimal[] P00BF6_A2051VouDDeb ;
      private decimal[] P00BF6_A2055VouDHab ;
      private string[] P00BF6_A2075VouGls ;
      private string[] P00BF6_A2054VouDGls ;
      private int[] P00BF6_A131VouDMon ;
      private decimal[] P00BF6_A2052VouDDebO ;
      private decimal[] P00BF6_A2056VouDHabO ;
      private DateTime[] P00BF6_A135VouDFec ;
      private int[] P00BF6_A130VouDSec ;
      private int[] P00BF7_A126TASICod ;
      private string[] P00BF7_A129VouNum ;
      private string[] P00BF7_A79COSCod ;
      private bool[] P00BF7_n79COSCod ;
      private short[] P00BF7_A2077VouSts ;
      private string[] P00BF7_A91CueCod ;
      private short[] P00BF7_A128VouMes ;
      private short[] P00BF7_A127VouAno ;
      private decimal[] P00BF7_A2069VouDTcmb ;
      private int[] P00BF7_A130VouDSec ;
      private int[] P00BF8_A126TASICod ;
      private string[] P00BF8_A129VouNum ;
      private short[] P00BF8_A2077VouSts ;
      private string[] P00BF8_A79COSCod ;
      private bool[] P00BF8_n79COSCod ;
      private string[] P00BF8_A133CueCodAux ;
      private string[] P00BF8_A91CueCod ;
      private short[] P00BF8_A128VouMes ;
      private short[] P00BF8_A127VouAno ;
      private decimal[] P00BF8_A2069VouDTcmb ;
      private int[] P00BF8_A130VouDSec ;
      private string aP7_Filename ;
      private string aP8_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV37Archivo ;
   }

   public class r_libromayorgeneralexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BF2( IGxContext context ,
                                             string AV44cCuenta1 ,
                                             string AV45cCuenta2 ,
                                             string AV43cCosto ,
                                             string AV88cCosto2 ,
                                             string A91CueCod ,
                                             string A79COSCod ,
                                             short A127VouAno ,
                                             short AV8Ano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CueCodAux], T1.[CueCod], T1.[COSCod], T1.[VouAno], T2.[CueDsc], T2.[TipACod], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV8Ano)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44cCuenta1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] >= @AV44cCuenta1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45cCuenta2)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] <= @AV45cCuenta2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] >= @AV43cCosto)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88cCosto2)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] <= @AV88cCosto2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00BF5( IGxContext context ,
                                             string AV43cCosto ,
                                             string AV88cCosto2 ,
                                             string A79COSCod ,
                                             short A127VouAno ,
                                             short AV8Ano ,
                                             short A128VouMes ,
                                             short AV9Mes ,
                                             short A2077VouSts ,
                                             string AV46CueCod ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T3.[VouSts], T1.[COSCod], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T2.[TASIAbr], T1.[VouNum], T1.[VouDDoc], T1.[VouReg], T1.[VouDDeb], T1.[VouDHab], T3.[VouGls], T1.[VouDGls], T1.[VouDMon], T1.[VouDDebO], T1.[VouDHabO], T1.[VouDFec], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV46CueCod)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV8Ano)");
         AddWhere(sWhereString, "(T1.[VouMes] = @AV9Mes)");
         AddWhere(sWhereString, "(T3.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] >= @AV43cCosto)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88cCosto2)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] <= @AV88cCosto2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[VouDFec]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00BF6( IGxContext context ,
                                             string AV43cCosto ,
                                             string AV88cCosto2 ,
                                             string A79COSCod ,
                                             short A127VouAno ,
                                             short AV8Ano ,
                                             short A128VouMes ,
                                             short AV9Mes ,
                                             string A133CueCodAux ,
                                             string AV64CueDAxu ,
                                             short A2077VouSts ,
                                             string AV46CueCod ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[6];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T3.[VouSts], T1.[COSCod], T1.[CueCodAux], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T2.[TASIAbr], T1.[VouNum], T1.[VouDDoc], T1.[VouReg], T1.[VouDDeb], T1.[VouDHab], T3.[VouGls], T1.[VouDGls], T1.[VouDMon], T1.[VouDDebO], T1.[VouDHabO], T1.[VouDFec], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV46CueCod)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV8Ano)");
         AddWhere(sWhereString, "(T1.[VouMes] = @AV9Mes)");
         AddWhere(sWhereString, "(T1.[CueCodAux] = @AV64CueDAxu)");
         AddWhere(sWhereString, "(T3.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] >= @AV43cCosto)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88cCosto2)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] <= @AV88cCosto2)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[VouDFec]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00BF7( IGxContext context ,
                                             string AV43cCosto ,
                                             string AV88cCosto2 ,
                                             string A79COSCod ,
                                             short A2077VouSts ,
                                             short AV8Ano ,
                                             short AV9Mes ,
                                             string AV46CueCod ,
                                             short A127VouAno ,
                                             short A128VouMes ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[5];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T1.[COSCod], T2.[VouSts], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV8Ano and T1.[VouMes] = @AV9Mes and T1.[CueCod] = @AV46CueCod)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] >= @AV43cCosto)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88cCosto2)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] <= @AV88cCosto2)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00BF8( IGxContext context ,
                                             string AV43cCosto ,
                                             string AV88cCosto2 ,
                                             string A79COSCod ,
                                             short A2077VouSts ,
                                             short AV8Ano ,
                                             short AV9Mes ,
                                             string AV46CueCod ,
                                             string AV64CueDAxu ,
                                             short A127VouAno ,
                                             short A128VouMes ,
                                             string A91CueCod ,
                                             string A133CueCodAux )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[6];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[COSCod], T1.[CueCodAux], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDTcmb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV8Ano and T1.[VouMes] = @AV9Mes and T1.[CueCod] = @AV46CueCod and T1.[CueCodAux] = @AV64CueDAxu)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] >= @AV43cCosto)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88cCosto2)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] <= @AV88cCosto2)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod], T1.[CueCodAux]";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BF2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] );
               case 3 :
                     return conditional_P00BF5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
               case 4 :
                     return conditional_P00BF6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
               case 5 :
                     return conditional_P00BF7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] );
               case 6 :
                     return conditional_P00BF8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BF3;
          prmP00BF3 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV46CueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BF4;
          prmP00BF4 = new Object[] {
          new ParDef("@AV87TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV64CueDAxu",GXType.NChar,20,0)
          };
          Object[] prmP00BF2;
          prmP00BF2 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV44cCuenta1",GXType.Char,15,0) ,
          new ParDef("@AV45cCuenta2",GXType.Char,15,0) ,
          new ParDef("@AV43cCosto",GXType.Char,10,0) ,
          new ParDef("@AV88cCosto2",GXType.Char,10,0)
          };
          Object[] prmP00BF5;
          prmP00BF5 = new Object[] {
          new ParDef("@AV46CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV9Mes",GXType.Int16,2,0) ,
          new ParDef("@AV43cCosto",GXType.Char,10,0) ,
          new ParDef("@AV88cCosto2",GXType.Char,10,0)
          };
          Object[] prmP00BF6;
          prmP00BF6 = new Object[] {
          new ParDef("@AV46CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV9Mes",GXType.Int16,2,0) ,
          new ParDef("@AV64CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV43cCosto",GXType.Char,10,0) ,
          new ParDef("@AV88cCosto2",GXType.Char,10,0)
          };
          Object[] prmP00BF7;
          prmP00BF7 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV9Mes",GXType.Int16,2,0) ,
          new ParDef("@AV46CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV43cCosto",GXType.Char,10,0) ,
          new ParDef("@AV88cCosto2",GXType.Char,10,0)
          };
          Object[] prmP00BF8;
          prmP00BF8 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV9Mes",GXType.Int16,2,0) ,
          new ParDef("@AV46CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV64CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV43cCosto",GXType.Char,10,0) ,
          new ParDef("@AV88cCosto2",GXType.Char,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BF2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BF2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BF3", "SELECT [CueAuxCod], [CueCodAux], [CueCod], [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE ([VouAno] = @AV8Ano) AND ([CueCod] = @AV46CueCod) ORDER BY [CueCodAux], [CueAuxCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BF3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BF4", "SELECT [TipADCod], [TipACod], [TipADDsc] FROM [CBAUXILIARES] WHERE [TipACod] = @AV87TipACod and [TipADCod] = @AV64CueDAxu ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BF4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BF5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BF5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BF6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BF6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BF7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BF7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BF8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BF8,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((short[]) buf[8])[0] = rslt.getShort(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 10);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 5);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                ((string[]) buf[10])[0] = rslt.getString(10, 20);
                ((string[]) buf[11])[0] = rslt.getString(11, 15);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((string[]) buf[14])[0] = rslt.getString(14, 100);
                ((string[]) buf[15])[0] = rslt.getString(15, 100);
                ((int[]) buf[16])[0] = rslt.getInt(16);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(19);
                ((int[]) buf[20])[0] = rslt.getInt(20);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 5);
                ((string[]) buf[10])[0] = rslt.getString(10, 10);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((string[]) buf[12])[0] = rslt.getString(12, 15);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 100);
                ((string[]) buf[16])[0] = rslt.getString(16, 100);
                ((int[]) buf[17])[0] = rslt.getInt(17);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(20);
                ((int[]) buf[21])[0] = rslt.getInt(21);
                return;
             case 5 :
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
             case 6 :
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
