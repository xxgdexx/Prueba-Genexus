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
   public class r_balancecomprobacionhojatrabajoexcel : GXProcedure
   {
      public r_balancecomprobacionhojatrabajoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_balancecomprobacionhojatrabajoexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref short aP2_nDig ,
                           ref int aP3_MonCod ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV8Ano = aP0_Ano;
         this.AV9Mes = aP1_Mes;
         this.AV36nDig = aP2_nDig;
         this.AV42MonCod = aP3_MonCod;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV9Mes;
         aP2_nDig=this.AV36nDig;
         aP3_MonCod=this.AV42MonCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref short aP2_nDig ,
                                ref int aP3_MonCod ,
                                out string aP4_Filename )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_nDig, ref aP3_MonCod, out aP4_Filename, out aP5_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref short aP2_nDig ,
                                 ref int aP3_MonCod ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         r_balancecomprobacionhojatrabajoexcel objr_balancecomprobacionhojatrabajoexcel;
         objr_balancecomprobacionhojatrabajoexcel = new r_balancecomprobacionhojatrabajoexcel();
         objr_balancecomprobacionhojatrabajoexcel.AV8Ano = aP0_Ano;
         objr_balancecomprobacionhojatrabajoexcel.AV9Mes = aP1_Mes;
         objr_balancecomprobacionhojatrabajoexcel.AV36nDig = aP2_nDig;
         objr_balancecomprobacionhojatrabajoexcel.AV42MonCod = aP3_MonCod;
         objr_balancecomprobacionhojatrabajoexcel.AV10Filename = "" ;
         objr_balancecomprobacionhojatrabajoexcel.AV11ErrorMessage = "" ;
         objr_balancecomprobacionhojatrabajoexcel.context.SetSubmitInitialConfig(context);
         objr_balancecomprobacionhojatrabajoexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_balancecomprobacionhojatrabajoexcel);
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV9Mes;
         aP2_nDig=this.AV36nDig;
         aP3_MonCod=this.AV42MonCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_balancecomprobacionhojatrabajoexcel)stateInfo).executePrivate();
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
         AV37Archivo.Source = "Excel/PlantillasBalanceComprobacionHojaTrabajo.xlsx";
         AV38Path = AV37Archivo.GetPath();
         AV41FilenameOrigen = StringUtil.Trim( AV38Path) + "\\PlantillasBalanceComprobacionHojaTrabajo.xlsx";
         AV10Filename = "Excel/BalanceComprobacionHojaTrabajo" + ".xlsx";
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
         AV18FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV9Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0));
         AV19FechaD = context.localUtil.CToD( AV18FechaC, 2);
         GXt_date1 = AV40Fecha;
         new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV19FechaD, out  GXt_date1) ;
         AV40Fecha = GXt_date1;
         if ( AV9Mes == 0 )
         {
            AV18FechaC = "01/01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0));
            AV40Fecha = context.localUtil.CToD( AV18FechaC, 2);
         }
         AV68Titulo = "Balance de Comprobación Hoja de Trabajo";
         AV39Periodo = "Al " + context.localUtil.DToC( AV40Fecha, 2, "/");
         if ( ( AV9Mes == 0 ) || ( AV9Mes == 13 ) )
         {
            AV39Periodo = ((AV9Mes==0) ? "Apertura" : "Cierre");
         }
         AV14CellRow = 7;
         AV15FirstColumn = 1;
         AV42MonCod = 1;
         AV46SaldoIniD = 0.00m;
         AV47SaldoIniH = 0.00m;
         AV48SaldoAcumD = 0.00m;
         AV49SaldoAcumH = 0.00m;
         AV50SaldoAjusD = 0.00m;
         AV51SaldoAjusH = 0.00m;
         AV52SaldoInvD = 0.00m;
         AV53SaldoInvH = 0.00m;
         AV54SaldoNatD = 0.00m;
         AV55SaldoNatH = 0.00m;
         AV56SaldoFunD = 0.00m;
         AV57SaldoFunH = 0.00m;
         AV69TSaldoIniD = 0.00m;
         AV70TSaldoIniH = 0.00m;
         AV71TSaldoAcumD = 0.00m;
         AV72TSaldoAcumH = 0.00m;
         AV73TSaldoAjusD = 0.00m;
         AV74TSaldoAjusH = 0.00m;
         AV75TSaldoInvD = 0.00m;
         AV76TSaldoInvH = 0.00m;
         AV77TSaldoNatD = 0.00m;
         AV78TSaldoNatH = 0.00m;
         AV79TSaldoFunD = 0.00m;
         AV80TSaldoFunH = 0.00m;
         AV81Flag = 0;
         AV58nSaldoA = 0.00m;
         AV59nSaldoD = 0.00m;
         AV60nSaldoInvA = 0.00m;
         AV94nSaldoInvP = 0.00m;
         AV62nSaldoNatP = 0.00m;
         AV63nSaldoNatG = 0.00m;
         AV64nSaldoFunP = 0.00m;
         AV65nSaldoFunG = 0.00m;
         AV82Len = 0;
         AV107CodCueNDig = "";
         AV45DscCueNdig = "";
         if ( ! (0==AV36nDig) )
         {
            AV82Len = AV36nDig;
            /* Using cursor P00BA2 */
            pr_default.execute(0, new Object[] {AV36nDig});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A91CueCod = P00BA2_A91CueCod[0];
               A109CueGasDebe = P00BA2_A109CueGasDebe[0];
               n109CueGasDebe = P00BA2_n109CueGasDebe[0];
               A860CueDsc = P00BA2_A860CueDsc[0];
               A868CueRef1 = P00BA2_A868CueRef1[0];
               A869CueRef2 = P00BA2_A869CueRef2[0];
               A870CueRef3 = P00BA2_A870CueRef3[0];
               A872CueRef5 = P00BA2_A872CueRef5[0];
               AV107CodCueNDig = StringUtil.Trim( A91CueCod);
               AV45DscCueNdig = StringUtil.Trim( A860CueDsc);
               AV66Cuenta = StringUtil.Trim( A91CueCod);
               AV67CueDsc = StringUtil.Trim( A91CueCod) + " - " + StringUtil.Trim( A860CueDsc);
               AV83CueRef1 = A868CueRef1;
               AV84CueRef2 = A869CueRef2;
               AV85CueRef3 = A870CueRef3;
               AV86CueRef5 = A872CueRef5;
               AV46SaldoIniD = 0.00m;
               AV47SaldoIniH = 0.00m;
               AV48SaldoAcumD = 0.00m;
               AV49SaldoAcumH = 0.00m;
               AV50SaldoAjusD = 0.00m;
               AV51SaldoAjusH = 0.00m;
               AV52SaldoInvD = 0.00m;
               AV53SaldoInvH = 0.00m;
               AV54SaldoNatD = 0.00m;
               AV55SaldoNatH = 0.00m;
               AV56SaldoFunD = 0.00m;
               AV57SaldoFunH = 0.00m;
               AV87DebeSaldoT = 0.00m;
               AV88HaberSaldoT = 0.00m;
               AV89nDebeMesT = 0.00m;
               AV90nHaberMesT = 0.00m;
               AV91DebeAcumulaT = 0.00m;
               AV92HaberAcumulaT = 0.00m;
               AV93nSaldoT = 0.00m;
               /* Execute user subroutine: 'VALIDAMOVMES2DIGITOS' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'MOVIMIENTOMES' */
               S141 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( AV81Flag == 0 )
               {
                  AV108Totales = "TOTAL CUENTA " + StringUtil.Trim( AV66Cuenta);
                  /* Execute user subroutine: 'AGRUPANDIG' */
                  S161 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
               }
               AV69TSaldoIniD = (decimal)(AV69TSaldoIniD+AV46SaldoIniD);
               AV70TSaldoIniH = (decimal)(AV70TSaldoIniH+AV47SaldoIniH);
               AV71TSaldoAcumD = (decimal)(AV71TSaldoAcumD+AV48SaldoAcumD);
               AV72TSaldoAcumH = (decimal)(AV72TSaldoAcumH+AV49SaldoAcumH);
               AV73TSaldoAjusD = (decimal)(AV73TSaldoAjusD+AV50SaldoAjusD);
               AV74TSaldoAjusH = (decimal)(AV74TSaldoAjusH+AV51SaldoAjusH);
               AV75TSaldoInvD = (decimal)(AV75TSaldoInvD+AV52SaldoInvD);
               AV76TSaldoInvH = (decimal)(AV76TSaldoInvH+AV53SaldoInvH);
               AV77TSaldoNatD = (decimal)(AV77TSaldoNatD+AV54SaldoNatD);
               AV78TSaldoNatH = (decimal)(AV78TSaldoNatH+AV55SaldoNatH);
               AV79TSaldoFunD = (decimal)(AV79TSaldoFunD+AV56SaldoFunD);
               AV80TSaldoFunH = (decimal)(AV80TSaldoFunH+AV57SaldoFunH);
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            AV36nDig = 2;
            /* Using cursor P00BA3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A91CueCod = P00BA3_A91CueCod[0];
               A109CueGasDebe = P00BA3_A109CueGasDebe[0];
               n109CueGasDebe = P00BA3_n109CueGasDebe[0];
               A860CueDsc = P00BA3_A860CueDsc[0];
               A868CueRef1 = P00BA3_A868CueRef1[0];
               A869CueRef2 = P00BA3_A869CueRef2[0];
               A870CueRef3 = P00BA3_A870CueRef3[0];
               A872CueRef5 = P00BA3_A872CueRef5[0];
               AV66Cuenta = StringUtil.Trim( A91CueCod);
               AV67CueDsc = StringUtil.Trim( A91CueCod) + " - " + StringUtil.Trim( A860CueDsc);
               AV83CueRef1 = A868CueRef1;
               AV84CueRef2 = A869CueRef2;
               AV85CueRef3 = A870CueRef3;
               AV86CueRef5 = A872CueRef5;
               AV46SaldoIniD = 0.00m;
               AV47SaldoIniH = 0.00m;
               AV48SaldoAcumD = 0.00m;
               AV49SaldoAcumH = 0.00m;
               AV50SaldoAjusD = 0.00m;
               AV51SaldoAjusH = 0.00m;
               AV52SaldoInvD = 0.00m;
               AV53SaldoInvH = 0.00m;
               AV54SaldoNatD = 0.00m;
               AV55SaldoNatH = 0.00m;
               AV56SaldoFunD = 0.00m;
               AV57SaldoFunH = 0.00m;
               AV87DebeSaldoT = 0.00m;
               AV88HaberSaldoT = 0.00m;
               AV89nDebeMesT = 0.00m;
               AV90nHaberMesT = 0.00m;
               AV91DebeAcumulaT = 0.00m;
               AV92HaberAcumulaT = 0.00m;
               AV93nSaldoT = 0.00m;
               /* Execute user subroutine: 'VALIDAMOVMES2DIGITOS' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               if ( AV81Flag == 0 )
               {
                  /* Execute user subroutine: 'AGRUPACUENTA2' */
                  S171 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     this.cleanup();
                     if (true) return;
                  }
               }
               /* Execute user subroutine: 'MOVIMIENTOMES' */
               S141 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               if ( AV81Flag == 0 )
               {
                  AV108Totales = "TOTAL CUENTA " + StringUtil.Trim( AV66Cuenta);
                  /* Execute user subroutine: 'AGRUPA2' */
                  S181 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     this.cleanup();
                     if (true) return;
                  }
               }
               AV69TSaldoIniD = (decimal)(AV69TSaldoIniD+AV46SaldoIniD);
               AV70TSaldoIniH = (decimal)(AV70TSaldoIniH+AV47SaldoIniH);
               AV71TSaldoAcumD = (decimal)(AV71TSaldoAcumD+AV48SaldoAcumD);
               AV72TSaldoAcumH = (decimal)(AV72TSaldoAcumH+AV49SaldoAcumH);
               AV73TSaldoAjusD = (decimal)(AV73TSaldoAjusD+AV50SaldoAjusD);
               AV74TSaldoAjusH = (decimal)(AV74TSaldoAjusH+AV51SaldoAjusH);
               AV75TSaldoInvD = (decimal)(AV75TSaldoInvD+AV52SaldoInvD);
               AV76TSaldoInvH = (decimal)(AV76TSaldoInvH+AV53SaldoInvH);
               AV77TSaldoNatD = (decimal)(AV77TSaldoNatD+AV54SaldoNatD);
               AV78TSaldoNatH = (decimal)(AV78TSaldoNatH+AV55SaldoNatH);
               AV79TSaldoFunD = (decimal)(AV79TSaldoFunD+AV56SaldoFunD);
               AV80TSaldoFunH = (decimal)(AV80TSaldoFunH+AV57SaldoFunH);
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         AV95DifBalance1 = 0.00m;
         AV96DifBalance2 = 0.00m;
         AV97TotBalance1 = 0.00m;
         AV98TotBalance2 = 0.00m;
         AV99DifNatura1 = 0.00m;
         AV100DifNatura2 = 0.00m;
         AV101TotNatura1 = 0.00m;
         AV102TotNatura2 = 0.00m;
         AV103DifFuncion1 = 0.00m;
         AV104DifFuncion2 = 0.00m;
         AV105TotFuncion1 = 0.00m;
         AV106TotFuncion2 = 0.00m;
         AV95DifBalance1 = ((AV75TSaldoInvD-AV76TSaldoInvH>Convert.ToDecimal(0)) ? (decimal)(0) : (AV75TSaldoInvD-AV76TSaldoInvH)*-1);
         AV96DifBalance2 = ((AV75TSaldoInvD-AV76TSaldoInvH>Convert.ToDecimal(0)) ? (AV75TSaldoInvD-AV76TSaldoInvH) : (decimal)(0));
         AV97TotBalance1 = (decimal)(AV75TSaldoInvD+AV95DifBalance1);
         AV98TotBalance2 = (decimal)(AV76TSaldoInvH+AV96DifBalance2);
         AV99DifNatura1 = ((AV77TSaldoNatD-AV78TSaldoNatH>Convert.ToDecimal(0)) ? (decimal)(0) : (AV77TSaldoNatD-AV78TSaldoNatH)*-1);
         AV100DifNatura2 = ((AV77TSaldoNatD-AV78TSaldoNatH>Convert.ToDecimal(0)) ? (AV77TSaldoNatD-AV78TSaldoNatH) : (decimal)(0));
         AV101TotNatura1 = (decimal)(AV77TSaldoNatD+AV99DifNatura1);
         AV102TotNatura2 = (decimal)(AV78TSaldoNatH+AV100DifNatura2);
         AV103DifFuncion1 = ((AV79TSaldoFunD-AV80TSaldoFunH>Convert.ToDecimal(0)) ? (decimal)(0) : (AV79TSaldoFunD-AV80TSaldoFunH)*-1);
         AV104DifFuncion2 = ((AV79TSaldoFunD-AV80TSaldoFunH>Convert.ToDecimal(0)) ? (AV79TSaldoFunD-AV80TSaldoFunH) : (decimal)(0));
         AV105TotFuncion1 = (decimal)(AV79TSaldoFunD+AV103DifFuncion1);
         AV106TotFuncion2 = (decimal)(AV80TSaldoFunH+AV104DifFuncion2);
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
         /* 'VALIDAMOVMES' Routine */
         returnInSub = false;
         /* Using cursor P00BA4 */
         pr_default.execute(2, new Object[] {AV8Ano, AV9Mes, AV16nCueCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00BA4_A126TASICod[0];
            A129VouNum = P00BA4_A129VouNum[0];
            A91CueCod = P00BA4_A91CueCod[0];
            A2077VouSts = P00BA4_A2077VouSts[0];
            A128VouMes = P00BA4_A128VouMes[0];
            A127VouAno = P00BA4_A127VouAno[0];
            A2051VouDDeb = P00BA4_A2051VouDDeb[0];
            A2055VouDHab = P00BA4_A2055VouDHab[0];
            A130VouDSec = P00BA4_A130VouDSec[0];
            A2077VouSts = P00BA4_A2077VouSts[0];
            AV31nDebeMes = (decimal)(AV31nDebeMes+(NumberUtil.Round( A2051VouDDeb, 2)));
            AV32nHaberMes = (decimal)(AV32nHaberMes+(NumberUtil.Round( A2055VouDHab, 2)));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'VALIDAMOVMES2DIGITOS' Routine */
         returnInSub = false;
         AV81Flag = 1;
         /* Using cursor P00BA5 */
         pr_default.execute(3, new Object[] {AV8Ano, AV9Mes, AV36nDig, AV66Cuenta});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A126TASICod = P00BA5_A126TASICod[0];
            A129VouNum = P00BA5_A129VouNum[0];
            A91CueCod = P00BA5_A91CueCod[0];
            A2077VouSts = P00BA5_A2077VouSts[0];
            A128VouMes = P00BA5_A128VouMes[0];
            A127VouAno = P00BA5_A127VouAno[0];
            A130VouDSec = P00BA5_A130VouDSec[0];
            A2077VouSts = P00BA5_A2077VouSts[0];
            AV81Flag = 0;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV109MesAnt = (short)(AV9Mes-1);
         /* Using cursor P00BA6 */
         pr_default.execute(4, new Object[] {AV8Ano, AV109MesAnt, AV36nDig, AV66Cuenta});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A123SalCueCod = P00BA6_A123SalCueCod[0];
            A122SalVouMes = P00BA6_A122SalVouMes[0];
            A121SalVouAno = P00BA6_A121SalVouAno[0];
            A124SalMonCod = P00BA6_A124SalMonCod[0];
            A125SalCueAux = P00BA6_A125SalCueAux[0];
            AV81Flag = 0;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S141( )
      {
         /* 'MOVIMIENTOMES' Routine */
         returnInSub = false;
         /* Using cursor P00BA7 */
         pr_default.execute(5, new Object[] {AV36nDig, AV66Cuenta, AV8Ano});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKBA7 = false;
            A133CueCodAux = P00BA7_A133CueCodAux[0];
            A91CueCod = P00BA7_A91CueCod[0];
            A127VouAno = P00BA7_A127VouAno[0];
            A2053VouDDoc = P00BA7_A2053VouDDoc[0];
            A860CueDsc = P00BA7_A860CueDsc[0];
            A868CueRef1 = P00BA7_A868CueRef1[0];
            A869CueRef2 = P00BA7_A869CueRef2[0];
            A870CueRef3 = P00BA7_A870CueRef3[0];
            A872CueRef5 = P00BA7_A872CueRef5[0];
            A128VouMes = P00BA7_A128VouMes[0];
            A126TASICod = P00BA7_A126TASICod[0];
            A129VouNum = P00BA7_A129VouNum[0];
            A130VouDSec = P00BA7_A130VouDSec[0];
            A860CueDsc = P00BA7_A860CueDsc[0];
            A868CueRef1 = P00BA7_A868CueRef1[0];
            A869CueRef2 = P00BA7_A869CueRef2[0];
            A870CueRef3 = P00BA7_A870CueRef3[0];
            A872CueRef5 = P00BA7_A872CueRef5[0];
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00BA7_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRKBA7 = false;
               A133CueCodAux = P00BA7_A133CueCodAux[0];
               A127VouAno = P00BA7_A127VouAno[0];
               A128VouMes = P00BA7_A128VouMes[0];
               A126TASICod = P00BA7_A126TASICod[0];
               A129VouNum = P00BA7_A129VouNum[0];
               A130VouDSec = P00BA7_A130VouDSec[0];
               BRKBA7 = true;
               pr_default.readNext(5);
            }
            AV16nCueCod = StringUtil.Trim( A91CueCod);
            AV17nCueDsc = A860CueDsc;
            AV83CueRef1 = A868CueRef1;
            AV84CueRef2 = A869CueRef2;
            AV85CueRef3 = A870CueRef3;
            AV86CueRef5 = A872CueRef5;
            AV29DebeSaldo = 0.00m;
            AV30HaberSaldo = 0.00m;
            AV31nDebeMes = 0.00m;
            AV32nHaberMes = 0.00m;
            AV33DebeAcumula = 0.00m;
            AV34HaberAcumula = 0.00m;
            AV58nSaldoA = 0.00m;
            AV59nSaldoD = 0.00m;
            AV60nSaldoInvA = 0.00m;
            AV94nSaldoInvP = 0.00m;
            AV62nSaldoNatP = 0.00m;
            AV63nSaldoNatG = 0.00m;
            AV64nSaldoFunP = 0.00m;
            AV65nSaldoFunG = 0.00m;
            /* Execute user subroutine: 'VALIDAMOVMES' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(5);
               returnInSub = true;
               if (true) return;
            }
            GXt_decimal2 = AV35Anterior;
            new GeneXus.Programs.contabilidad.psaldocuenta(context ).execute(  AV16nCueCod,  AV8Ano,  AV9Mes,  AV42MonCod, out  GXt_decimal2) ;
            AV35Anterior = GXt_decimal2;
            AV29DebeSaldo = ((AV35Anterior>Convert.ToDecimal(0)) ? AV35Anterior : (decimal)(0));
            AV30HaberSaldo = ((AV35Anterior<Convert.ToDecimal(0)) ? AV35Anterior*-1 : (decimal)(0));
            AV33DebeAcumula = AV31nDebeMes;
            AV34HaberAcumula = AV32nHaberMes;
            AV28nSaldo = (decimal)((AV31nDebeMes+AV29DebeSaldo)-(AV32nHaberMes+AV30HaberSaldo));
            AV58nSaldoA = (decimal)(AV31nDebeMes+AV29DebeSaldo);
            AV59nSaldoD = (decimal)(AV32nHaberMes+AV30HaberSaldo);
            if ( AV83CueRef1 == 1 )
            {
               AV60nSaldoInvA = ((AV28nSaldo>Convert.ToDecimal(0)) ? AV28nSaldo : (decimal)(0));
               AV94nSaldoInvP = ((AV28nSaldo<Convert.ToDecimal(0)) ? AV28nSaldo*-1 : (decimal)(0));
            }
            if ( AV85CueRef3 == 1 )
            {
               AV62nSaldoNatP = ((AV28nSaldo>Convert.ToDecimal(0)) ? AV28nSaldo : (decimal)(0));
               AV63nSaldoNatG = ((AV28nSaldo<Convert.ToDecimal(0)) ? AV28nSaldo*-1 : (decimal)(0));
            }
            if ( AV84CueRef2 == 1 )
            {
               AV64nSaldoFunP = ((AV28nSaldo>Convert.ToDecimal(0)) ? AV28nSaldo : (decimal)(0));
               AV65nSaldoFunG = ((AV28nSaldo<Convert.ToDecimal(0)) ? AV28nSaldo*-1 : (decimal)(0));
            }
            if ( ( ( AV31nDebeMes > Convert.ToDecimal( 0 )) || ( AV32nHaberMes > Convert.ToDecimal( 0 )) || ( AV35Anterior != Convert.ToDecimal( 0 )) ) && ( AV82Len == 0 ) )
            {
               /* Execute user subroutine: 'MOVIMIENTO' */
               S157 ();
               if ( returnInSub )
               {
                  pr_default.close(5);
                  returnInSub = true;
                  if (true) return;
               }
            }
            AV46SaldoIniD = (decimal)(AV46SaldoIniD+AV29DebeSaldo);
            AV47SaldoIniH = (decimal)(AV47SaldoIniH+AV30HaberSaldo);
            AV48SaldoAcumD = (decimal)(AV48SaldoAcumD+AV33DebeAcumula);
            AV49SaldoAcumH = (decimal)(AV49SaldoAcumH+AV34HaberAcumula);
            AV50SaldoAjusD = (decimal)(AV50SaldoAjusD+AV58nSaldoA);
            AV51SaldoAjusH = (decimal)(AV51SaldoAjusH+AV59nSaldoD);
            AV52SaldoInvD = (decimal)(AV52SaldoInvD+AV60nSaldoInvA);
            AV53SaldoInvH = (decimal)(AV53SaldoInvH+AV94nSaldoInvP);
            AV54SaldoNatD = (decimal)(AV54SaldoNatD+AV62nSaldoNatP);
            AV55SaldoNatH = (decimal)(AV55SaldoNatH+AV63nSaldoNatG);
            AV56SaldoFunD = (decimal)(AV56SaldoFunD+AV64nSaldoFunP);
            AV57SaldoFunH = (decimal)(AV57SaldoFunH+AV65nSaldoFunG);
            if ( ! BRKBA7 )
            {
               BRKBA7 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S161( )
      {
         /* 'AGRUPANDIG' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV107CodCueNDig);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV45DscCueNdig);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Number = (double)(AV46SaldoIniD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV47SaldoIniH);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Number = (double)(AV48SaldoAcumD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV49SaldoAcumH);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV50SaldoAjusD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV51SaldoAjusH);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV52SaldoInvD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV53SaldoInvH);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV54SaldoNatD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(AV55SaldoNatH);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Number = (double)(AV56SaldoFunD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Number = (double)(AV57SaldoFunH);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S171( )
      {
         /* 'AGRUPACUENTA2' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV67CueDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Number = (double)(0.00m);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(0.00m);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Number = (double)(0.00m);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(0.00m);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(0.00m);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(0.00m);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(0.00m);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(0.00m);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(0.00m);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(0.00m);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Number = (double)(0.00m);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Number = (double)(0.00m);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S181( )
      {
         /* 'AGRUPA2' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Number = (double)(AV46SaldoIniD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV47SaldoIniH);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Number = (double)(AV48SaldoAcumD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV49SaldoAcumH);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV50SaldoAjusD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV51SaldoAjusH);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV52SaldoInvD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV53SaldoInvH);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV54SaldoNatD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(AV55SaldoNatH);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Number = (double)(AV56SaldoFunD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Number = (double)(AV57SaldoFunH);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S157( )
      {
         /* 'MOVIMIENTO' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV16nCueCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV17nCueDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Number = (double)(AV29DebeSaldo);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV30HaberSaldo);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Number = (double)(AV33DebeAcumula);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV34HaberAcumula);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV58nSaldoA);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV59nSaldoD);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV60nSaldoInvA);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV94nSaldoInvP);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV62nSaldoNatP);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(AV63nSaldoNatG);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Number = (double)(AV64nSaldoFunP);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Number = (double)(AV65nSaldoFunG);
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
         AV40Fecha = DateTime.MinValue;
         GXt_date1 = DateTime.MinValue;
         AV68Titulo = "";
         AV39Periodo = "";
         AV107CodCueNDig = "";
         AV45DscCueNdig = "";
         scmdbuf = "";
         P00BA2_A91CueCod = new string[] {""} ;
         P00BA2_A109CueGasDebe = new string[] {""} ;
         P00BA2_n109CueGasDebe = new bool[] {false} ;
         P00BA2_A860CueDsc = new string[] {""} ;
         P00BA2_A868CueRef1 = new short[1] ;
         P00BA2_A869CueRef2 = new short[1] ;
         P00BA2_A870CueRef3 = new short[1] ;
         P00BA2_A872CueRef5 = new short[1] ;
         A91CueCod = "";
         A109CueGasDebe = "";
         A860CueDsc = "";
         AV66Cuenta = "";
         AV67CueDsc = "";
         AV108Totales = "";
         P00BA3_A91CueCod = new string[] {""} ;
         P00BA3_A109CueGasDebe = new string[] {""} ;
         P00BA3_n109CueGasDebe = new bool[] {false} ;
         P00BA3_A860CueDsc = new string[] {""} ;
         P00BA3_A868CueRef1 = new short[1] ;
         P00BA3_A869CueRef2 = new short[1] ;
         P00BA3_A870CueRef3 = new short[1] ;
         P00BA3_A872CueRef5 = new short[1] ;
         AV16nCueCod = "";
         P00BA4_A126TASICod = new int[1] ;
         P00BA4_A129VouNum = new string[] {""} ;
         P00BA4_A91CueCod = new string[] {""} ;
         P00BA4_A2077VouSts = new short[1] ;
         P00BA4_A128VouMes = new short[1] ;
         P00BA4_A127VouAno = new short[1] ;
         P00BA4_A2051VouDDeb = new decimal[1] ;
         P00BA4_A2055VouDHab = new decimal[1] ;
         P00BA4_A130VouDSec = new int[1] ;
         A129VouNum = "";
         P00BA5_A126TASICod = new int[1] ;
         P00BA5_A129VouNum = new string[] {""} ;
         P00BA5_A91CueCod = new string[] {""} ;
         P00BA5_A2077VouSts = new short[1] ;
         P00BA5_A128VouMes = new short[1] ;
         P00BA5_A127VouAno = new short[1] ;
         P00BA5_A130VouDSec = new int[1] ;
         P00BA6_A123SalCueCod = new string[] {""} ;
         P00BA6_A122SalVouMes = new short[1] ;
         P00BA6_A121SalVouAno = new short[1] ;
         P00BA6_A124SalMonCod = new int[1] ;
         P00BA6_A125SalCueAux = new string[] {""} ;
         A123SalCueCod = "";
         A125SalCueAux = "";
         P00BA7_A133CueCodAux = new string[] {""} ;
         P00BA7_A91CueCod = new string[] {""} ;
         P00BA7_A127VouAno = new short[1] ;
         P00BA7_A2053VouDDoc = new string[] {""} ;
         P00BA7_A860CueDsc = new string[] {""} ;
         P00BA7_A868CueRef1 = new short[1] ;
         P00BA7_A869CueRef2 = new short[1] ;
         P00BA7_A870CueRef3 = new short[1] ;
         P00BA7_A872CueRef5 = new short[1] ;
         P00BA7_A128VouMes = new short[1] ;
         P00BA7_A126TASICod = new int[1] ;
         P00BA7_A129VouNum = new string[] {""} ;
         P00BA7_A130VouDSec = new int[1] ;
         A133CueCodAux = "";
         A2053VouDDoc = "";
         AV17nCueDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_balancecomprobacionhojatrabajoexcel__default(),
            new Object[][] {
                new Object[] {
               P00BA2_A91CueCod, P00BA2_A109CueGasDebe, P00BA2_n109CueGasDebe, P00BA2_A860CueDsc, P00BA2_A868CueRef1, P00BA2_A869CueRef2, P00BA2_A870CueRef3, P00BA2_A872CueRef5
               }
               , new Object[] {
               P00BA3_A91CueCod, P00BA3_A109CueGasDebe, P00BA3_n109CueGasDebe, P00BA3_A860CueDsc, P00BA3_A868CueRef1, P00BA3_A869CueRef2, P00BA3_A870CueRef3, P00BA3_A872CueRef5
               }
               , new Object[] {
               P00BA4_A126TASICod, P00BA4_A129VouNum, P00BA4_A91CueCod, P00BA4_A2077VouSts, P00BA4_A128VouMes, P00BA4_A127VouAno, P00BA4_A2051VouDDeb, P00BA4_A2055VouDHab, P00BA4_A130VouDSec
               }
               , new Object[] {
               P00BA5_A126TASICod, P00BA5_A129VouNum, P00BA5_A91CueCod, P00BA5_A2077VouSts, P00BA5_A128VouMes, P00BA5_A127VouAno, P00BA5_A130VouDSec
               }
               , new Object[] {
               P00BA6_A123SalCueCod, P00BA6_A122SalVouMes, P00BA6_A121SalVouAno, P00BA6_A124SalMonCod, P00BA6_A125SalCueAux
               }
               , new Object[] {
               P00BA7_A133CueCodAux, P00BA7_A91CueCod, P00BA7_A127VouAno, P00BA7_A2053VouDDoc, P00BA7_A860CueDsc, P00BA7_A868CueRef1, P00BA7_A869CueRef2, P00BA7_A870CueRef3, P00BA7_A872CueRef5, P00BA7_A128VouMes,
               P00BA7_A126TASICod, P00BA7_A129VouNum, P00BA7_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Ano ;
      private short AV9Mes ;
      private short AV36nDig ;
      private short AV81Flag ;
      private short A868CueRef1 ;
      private short A869CueRef2 ;
      private short A870CueRef3 ;
      private short A872CueRef5 ;
      private short AV83CueRef1 ;
      private short AV84CueRef2 ;
      private short AV85CueRef3 ;
      private short AV86CueRef5 ;
      private short A2077VouSts ;
      private short A128VouMes ;
      private short A127VouAno ;
      private short AV109MesAnt ;
      private short A122SalVouMes ;
      private short A121SalVouAno ;
      private int AV42MonCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int A124SalMonCod ;
      private long AV82Len ;
      private decimal AV46SaldoIniD ;
      private decimal AV47SaldoIniH ;
      private decimal AV48SaldoAcumD ;
      private decimal AV49SaldoAcumH ;
      private decimal AV50SaldoAjusD ;
      private decimal AV51SaldoAjusH ;
      private decimal AV52SaldoInvD ;
      private decimal AV53SaldoInvH ;
      private decimal AV54SaldoNatD ;
      private decimal AV55SaldoNatH ;
      private decimal AV56SaldoFunD ;
      private decimal AV57SaldoFunH ;
      private decimal AV69TSaldoIniD ;
      private decimal AV70TSaldoIniH ;
      private decimal AV71TSaldoAcumD ;
      private decimal AV72TSaldoAcumH ;
      private decimal AV73TSaldoAjusD ;
      private decimal AV74TSaldoAjusH ;
      private decimal AV75TSaldoInvD ;
      private decimal AV76TSaldoInvH ;
      private decimal AV77TSaldoNatD ;
      private decimal AV78TSaldoNatH ;
      private decimal AV79TSaldoFunD ;
      private decimal AV80TSaldoFunH ;
      private decimal AV58nSaldoA ;
      private decimal AV59nSaldoD ;
      private decimal AV60nSaldoInvA ;
      private decimal AV94nSaldoInvP ;
      private decimal AV62nSaldoNatP ;
      private decimal AV63nSaldoNatG ;
      private decimal AV64nSaldoFunP ;
      private decimal AV65nSaldoFunG ;
      private decimal AV87DebeSaldoT ;
      private decimal AV88HaberSaldoT ;
      private decimal AV89nDebeMesT ;
      private decimal AV90nHaberMesT ;
      private decimal AV91DebeAcumulaT ;
      private decimal AV92HaberAcumulaT ;
      private decimal AV93nSaldoT ;
      private decimal AV95DifBalance1 ;
      private decimal AV96DifBalance2 ;
      private decimal AV97TotBalance1 ;
      private decimal AV98TotBalance2 ;
      private decimal AV99DifNatura1 ;
      private decimal AV100DifNatura2 ;
      private decimal AV101TotNatura1 ;
      private decimal AV102TotNatura2 ;
      private decimal AV103DifFuncion1 ;
      private decimal AV104DifFuncion2 ;
      private decimal AV105TotFuncion1 ;
      private decimal AV106TotFuncion2 ;
      private decimal A2051VouDDeb ;
      private decimal A2055VouDHab ;
      private decimal AV31nDebeMes ;
      private decimal AV32nHaberMes ;
      private decimal AV29DebeSaldo ;
      private decimal AV30HaberSaldo ;
      private decimal AV33DebeAcumula ;
      private decimal AV34HaberAcumula ;
      private decimal AV35Anterior ;
      private decimal GXt_decimal2 ;
      private decimal AV28nSaldo ;
      private string AV38Path ;
      private string AV18FechaC ;
      private string AV68Titulo ;
      private string AV39Periodo ;
      private string AV107CodCueNDig ;
      private string AV45DscCueNdig ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A109CueGasDebe ;
      private string A860CueDsc ;
      private string AV66Cuenta ;
      private string AV67CueDsc ;
      private string AV108Totales ;
      private string AV16nCueCod ;
      private string A129VouNum ;
      private string A123SalCueCod ;
      private string A125SalCueAux ;
      private string A133CueCodAux ;
      private string A2053VouDDoc ;
      private string AV17nCueDsc ;
      private DateTime AV19FechaD ;
      private DateTime AV40Fecha ;
      private DateTime GXt_date1 ;
      private bool returnInSub ;
      private bool n109CueGasDebe ;
      private bool BRKBA7 ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV41FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private short aP2_nDig ;
      private int aP3_MonCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00BA2_A91CueCod ;
      private string[] P00BA2_A109CueGasDebe ;
      private bool[] P00BA2_n109CueGasDebe ;
      private string[] P00BA2_A860CueDsc ;
      private short[] P00BA2_A868CueRef1 ;
      private short[] P00BA2_A869CueRef2 ;
      private short[] P00BA2_A870CueRef3 ;
      private short[] P00BA2_A872CueRef5 ;
      private string[] P00BA3_A91CueCod ;
      private string[] P00BA3_A109CueGasDebe ;
      private bool[] P00BA3_n109CueGasDebe ;
      private string[] P00BA3_A860CueDsc ;
      private short[] P00BA3_A868CueRef1 ;
      private short[] P00BA3_A869CueRef2 ;
      private short[] P00BA3_A870CueRef3 ;
      private short[] P00BA3_A872CueRef5 ;
      private int[] P00BA4_A126TASICod ;
      private string[] P00BA4_A129VouNum ;
      private string[] P00BA4_A91CueCod ;
      private short[] P00BA4_A2077VouSts ;
      private short[] P00BA4_A128VouMes ;
      private short[] P00BA4_A127VouAno ;
      private decimal[] P00BA4_A2051VouDDeb ;
      private decimal[] P00BA4_A2055VouDHab ;
      private int[] P00BA4_A130VouDSec ;
      private int[] P00BA5_A126TASICod ;
      private string[] P00BA5_A129VouNum ;
      private string[] P00BA5_A91CueCod ;
      private short[] P00BA5_A2077VouSts ;
      private short[] P00BA5_A128VouMes ;
      private short[] P00BA5_A127VouAno ;
      private int[] P00BA5_A130VouDSec ;
      private string[] P00BA6_A123SalCueCod ;
      private short[] P00BA6_A122SalVouMes ;
      private short[] P00BA6_A121SalVouAno ;
      private int[] P00BA6_A124SalMonCod ;
      private string[] P00BA6_A125SalCueAux ;
      private string[] P00BA7_A133CueCodAux ;
      private string[] P00BA7_A91CueCod ;
      private short[] P00BA7_A127VouAno ;
      private string[] P00BA7_A2053VouDDoc ;
      private string[] P00BA7_A860CueDsc ;
      private short[] P00BA7_A868CueRef1 ;
      private short[] P00BA7_A869CueRef2 ;
      private short[] P00BA7_A870CueRef3 ;
      private short[] P00BA7_A872CueRef5 ;
      private short[] P00BA7_A128VouMes ;
      private int[] P00BA7_A126TASICod ;
      private string[] P00BA7_A129VouNum ;
      private int[] P00BA7_A130VouDSec ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV37Archivo ;
   }

   public class r_balancecomprobacionhojatrabajoexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00BA2;
          prmP00BA2 = new Object[] {
          new ParDef("@AV36nDig",GXType.Int16,2,0)
          };
          Object[] prmP00BA3;
          prmP00BA3 = new Object[] {
          };
          Object[] prmP00BA4;
          prmP00BA4 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV9Mes",GXType.Int16,2,0) ,
          new ParDef("@AV16nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BA5;
          prmP00BA5 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV9Mes",GXType.Int16,2,0) ,
          new ParDef("@AV36nDig",GXType.Int16,2,0) ,
          new ParDef("@AV66Cuenta",GXType.Char,15,0)
          };
          Object[] prmP00BA6;
          prmP00BA6 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV109MesAnt",GXType.Int16,2,0) ,
          new ParDef("@AV36nDig",GXType.Int16,2,0) ,
          new ParDef("@AV66Cuenta",GXType.Char,15,0)
          };
          Object[] prmP00BA7;
          prmP00BA7 = new Object[] {
          new ParDef("@AV36nDig",GXType.Int16,2,0) ,
          new ParDef("@AV66Cuenta",GXType.Char,15,0) ,
          new ParDef("@AV8Ano",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BA2", "SELECT [CueCod], [CueGasDebe], [CueDsc], [CueRef1], [CueRef2], [CueRef3], [CueRef5] FROM [CBPLANCUENTA] WHERE LEN([CueCod]) = @AV36nDig ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BA2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BA3", "SELECT [CueCod], [CueGasDebe], [CueDsc], [CueRef1], [CueRef2], [CueRef3], [CueRef5] FROM [CBPLANCUENTA] WHERE LEN([CueCod]) = 2 ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BA3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BA4", "SELECT T1.[TASICod], T1.[VouNum], T1.[CueCod], T2.[VouSts], T1.[VouMes], T1.[VouAno], T1.[VouDDeb], T1.[VouDHab], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = @AV9Mes and T1.[CueCod] = @AV16nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BA4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BA5", "SELECT TOP 1 T1.[TASICod], T1.[VouNum], T1.[CueCod], T2.[VouSts], T1.[VouMes], T1.[VouAno], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = @AV9Mes) AND (SUBSTRING(T1.[CueCod], 1, @AV36nDig) = @AV66Cuenta) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BA5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BA6", "SELECT TOP 1 [SalCueCod], [SalVouMes], [SalVouAno], [SalMonCod], [SalCueAux] FROM [CBSALDOMENSUAL] WHERE ([SalVouAno] = @AV8Ano and [SalVouMes] = @AV109MesAnt) AND (SUBSTRING([SalCueCod], 1, @AV36nDig) = @AV66Cuenta) ORDER BY [SalVouAno], [SalVouMes], [SalCueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BA6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BA7", "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouAno], T1.[VouDDoc], T2.[CueDsc], T2.[CueRef1], T2.[CueRef2], T2.[CueRef3], T2.[CueRef5], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (SUBSTRING(T1.[CueCod], 1, @AV36nDig) = @AV66Cuenta) AND (T1.[VouAno] = @AV8Ano) ORDER BY T1.[CueCod], T1.[CueCodAux] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BA7,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 10);
                ((int[]) buf[12])[0] = rslt.getInt(13);
                return;
       }
    }

 }

}
