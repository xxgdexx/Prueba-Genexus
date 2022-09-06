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
   public class r_rlibroinventariobalancesexcel : GXProcedure
   {
      public r_rlibroinventariobalancesexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_rlibroinventariobalancesexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           out string aP2_Filename ,
                           out string aP3_ErrorMessage )
      {
         this.AV105Ano = aP0_Ano;
         this.AV97Mes = aP1_Mes;
         this.AV11Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV105Ano;
         aP1_Mes=this.AV97Mes;
         aP2_Filename=this.AV11Filename;
         aP3_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                out string aP2_Filename )
      {
         execute(ref aP0_Ano, ref aP1_Mes, out aP2_Filename, out aP3_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 out string aP2_Filename ,
                                 out string aP3_ErrorMessage )
      {
         r_rlibroinventariobalancesexcel objr_rlibroinventariobalancesexcel;
         objr_rlibroinventariobalancesexcel = new r_rlibroinventariobalancesexcel();
         objr_rlibroinventariobalancesexcel.AV105Ano = aP0_Ano;
         objr_rlibroinventariobalancesexcel.AV97Mes = aP1_Mes;
         objr_rlibroinventariobalancesexcel.AV11Filename = "" ;
         objr_rlibroinventariobalancesexcel.AV13ErrorMessage = "" ;
         objr_rlibroinventariobalancesexcel.context.SetSubmitInitialConfig(context);
         objr_rlibroinventariobalancesexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_rlibroinventariobalancesexcel);
         aP0_Ano=this.AV105Ano;
         aP1_Mes=this.AV97Mes;
         aP2_Filename=this.AV11Filename;
         aP3_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_rlibroinventariobalancesexcel)stateInfo).executePrivate();
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
         AV8Archivo.Source = "Excel/PlantillaInventarioBalance.xlsx";
         AV9Path = AV8Archivo.GetPath();
         AV10FilenameOrigen = StringUtil.Trim( AV9Path) + "\\PlantillaInventarioBalance.xlsx";
         AV11Filename = "Excel/InventarioBalance" + ".xlsx";
         AV12ExcelDocument.Clear();
         AV12ExcelDocument.Template = AV10FilenameOrigen;
         AV12ExcelDocument.Open(AV11Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 5;
         AV16FirstColumn = 1;
         AV96FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV97Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV105Ano), 10, 0));
         if ( AV97Mes == 0 )
         {
            AV96FechaC = "01/01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV105Ano), 10, 0));
         }
         AV98FechaD = context.localUtil.CToD( AV96FechaC, 2);
         GXt_date1 = AV28Fecha;
         new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV98FechaD, out  GXt_date1) ;
         AV28Fecha = GXt_date1;
         if ( AV97Mes == 0 )
         {
            AV98FechaD = context.localUtil.CToD( AV96FechaC, 2);
         }
         else
         {
            AV98FechaD = AV28Fecha;
         }
         /* Using cursor P00B72 */
         pr_default.execute(0, new Object[] {AV105Ano, AV97Mes});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A126TASICod = P00B72_A126TASICod[0];
            A2077VouSts = P00B72_A2077VouSts[0];
            A128VouMes = P00B72_A128VouMes[0];
            A127VouAno = P00B72_A127VouAno[0];
            A2074VouFec = P00B72_A2074VouFec[0];
            A129VouNum = P00B72_A129VouNum[0];
            AV98FechaD = A2074VouFec;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV90TTDebeAcumula = 0.00m;
         AV91TTHaberAcumula = 0.00m;
         AV99TDebeMO = 0.00m;
         AV100ThaberMO = 0.00m;
         AV104i = 1;
         AV102TotalPYP = 0.00m;
         AV86nDig = 2;
         while ( AV104i <= 3 )
         {
            if ( AV104i == 1 )
            {
               AV101Titulo3 = "ACTIVO";
            }
            if ( AV104i == 2 )
            {
               AV102TotalPYP = 0.00m;
               AV101Titulo3 = "PASIVO";
            }
            if ( AV104i == 3 )
            {
               AV101Titulo3 = "PATRIMONIO";
            }
            AV103TotalTitulo = 0.00m;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV104i ,
                                                 A91CueCod ,
                                                 AV86nDig } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.INT
                                                 }
            });
            /* Using cursor P00B73 */
            pr_default.execute(1, new Object[] {AV86nDig});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A91CueCod = P00B73_A91CueCod[0];
               A860CueDsc = P00B73_A860CueDsc[0];
               AV87Cuenta = StringUtil.Trim( A91CueCod);
               AV85CueDsc = A860CueDsc;
               AV90TTDebeAcumula = 0.00m;
               AV91TTHaberAcumula = 0.00m;
               /* Execute user subroutine: 'VALIDAMOVIMIENTOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               AV103TotalTitulo = (decimal)(AV103TotalTitulo+AV94Saldo);
               /* Execute user subroutine: 'MOVIMIENTOS' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV104i = (short)(AV104i+1);
         }
         AV12ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV12ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'VALIDAMOVIMIENTOS' Routine */
         returnInSub = false;
         AV94Saldo = 0.00m;
         /* Using cursor P00B74 */
         pr_default.execute(2, new Object[] {AV86nDig, AV87Cuenta});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A867CueMov = P00B74_A867CueMov[0];
            A91CueCod = P00B74_A91CueCod[0];
            AV95CueCod = A91CueCod;
            GXt_char2 = "";
            GXt_char3 = "";
            new GeneXus.Programs.contabilidad.poptienesaldocuentamesactual(context ).execute( ref  AV105Ano, ref  AV97Mes, ref  AV95CueCod, ref  GXt_char2, ref  GXt_char3, out  AV88SaldoDMN, out  AV89SaldoHMN) ;
            AV90TTDebeAcumula = (decimal)(AV90TTDebeAcumula+AV88SaldoDMN);
            AV91TTHaberAcumula = (decimal)(AV91TTHaberAcumula+AV89SaldoHMN);
            AV94Saldo = (decimal)(AV90TTDebeAcumula-AV91TTHaberAcumula);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( StringUtil.StrCmp(StringUtil.Substring( AV95CueCod, 1, 2), "40") >= 0 )
         {
            AV94Saldo = (decimal)(AV94Saldo*(-1));
         }
      }

      protected void S121( )
      {
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         /* Using cursor P00B75 */
         pr_default.execute(3, new Object[] {AV86nDig, AV87Cuenta});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A91CueCod = P00B75_A91CueCod[0];
            A859CueCos = P00B75_A859CueCos[0];
            A70TipACod = P00B75_A70TipACod[0];
            n70TipACod = P00B75_n70TipACod[0];
            A860CueDsc = P00B75_A860CueDsc[0];
            AV70TipACod = A70TipACod;
            AV95CueCod = A91CueCod;
            AV85CueDsc = A860CueDsc;
            GXt_char3 = "";
            GXt_char2 = "";
            new GeneXus.Programs.contabilidad.poptienesaldocuentamesactual(context ).execute( ref  AV105Ano, ref  AV97Mes, ref  AV95CueCod, ref  GXt_char3, ref  GXt_char2, out  AV88SaldoDMN, out  AV89SaldoHMN) ;
            AV94Saldo = (decimal)(AV88SaldoDMN-AV89SaldoHMN);
            if ( StringUtil.StrCmp(StringUtil.Substring( AV95CueCod, 1, 2), "40") >= 0 )
            {
               AV94Saldo = (decimal)(AV94Saldo*-1);
            }
            if ( ( AV94Saldo > Convert.ToDecimal( 0 )) )
            {
               AV88SaldoDMN = AV94Saldo;
               AV89SaldoHMN = 0.00m;
            }
            else
            {
               AV88SaldoDMN = 0.00m;
               AV89SaldoHMN = (decimal)(AV94Saldo*(-1));
            }
            AV99TDebeMO = (decimal)(AV99TDebeMO+AV88SaldoDMN);
            AV100ThaberMO = (decimal)(AV100ThaberMO+AV89SaldoHMN);
            /* Execute user subroutine: 'DETALLESMOVIMIENTO' */
            S135 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S135( )
      {
         /* 'DETALLESMOVIMIENTO' Routine */
         returnInSub = false;
         /* Using cursor P00B76 */
         pr_default.execute(4, new Object[] {AV105Ano, AV95CueCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKB76 = false;
            A134CueAuxCod = P00B76_A134CueAuxCod[0];
            A133CueCodAux = P00B76_A133CueCodAux[0];
            A91CueCod = P00B76_A91CueCod[0];
            A127VouAno = P00B76_A127VouAno[0];
            A128VouMes = P00B76_A128VouMes[0];
            A126TASICod = P00B76_A126TASICod[0];
            A129VouNum = P00B76_A129VouNum[0];
            A130VouDSec = P00B76_A130VouDSec[0];
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00B76_A133CueCodAux[0], A133CueCodAux) == 0 ) )
            {
               BRKB76 = false;
               A134CueAuxCod = P00B76_A134CueAuxCod[0];
               A127VouAno = P00B76_A127VouAno[0];
               A128VouMes = P00B76_A128VouMes[0];
               A126TASICod = P00B76_A126TASICod[0];
               A129VouNum = P00B76_A129VouNum[0];
               A130VouDSec = P00B76_A130VouDSec[0];
               BRKB76 = true;
               pr_default.readNext(4);
            }
            AV92CueDAxu = A133CueCodAux;
            /* Execute user subroutine: 'NOMBREAUXILIAR' */
            S146 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            GXt_char3 = "";
            new GeneXus.Programs.contabilidad.poptienesaldocuentamesactual(context ).execute( ref  AV105Ano, ref  AV97Mes, ref  AV95CueCod, ref  AV92CueDAxu, ref  GXt_char3, out  AV88SaldoDMN, out  AV89SaldoHMN) ;
            AV94Saldo = (decimal)(AV88SaldoDMN-AV89SaldoHMN);
            if ( StringUtil.StrCmp(StringUtil.Substring( AV95CueCod, 1, 1), "4") >= 0 )
            {
               AV94Saldo = (decimal)(AV94Saldo*-1);
            }
            if ( ( AV94Saldo != Convert.ToDecimal( 0 )) )
            {
               /* Execute user subroutine: 'DETALLE' */
               S156 ();
               if ( returnInSub )
               {
                  pr_default.close(4);
                  returnInSub = true;
                  if (true) return;
               }
            }
            if ( ! BRKB76 )
            {
               BRKB76 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S161( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV12ExcelDocument.ErrCode != 0 )
         {
            AV11Filename = "";
            AV13ErrorMessage = AV12ExcelDocument.ErrDescription;
            AV12ExcelDocument.Close();
         }
      }

      protected void S156( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV12ExcelDocument.get_Cells(AV14CellRow, AV16FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV95CueCod);
         AV12ExcelDocument.get_Cells(AV14CellRow, AV16FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV85CueDsc);
         AV12ExcelDocument.get_Cells(AV14CellRow, AV16FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV92CueDAxu);
         AV12ExcelDocument.get_Cells(AV14CellRow, AV16FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV93CueDAxuDsc);
         AV12ExcelDocument.get_Cells(AV14CellRow, AV16FirstColumn+4, 1, 1).Number = (double)(AV94Saldo);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S146( )
      {
         /* 'NOMBREAUXILIAR' Routine */
         returnInSub = false;
         AV114GXLvl202 = 0;
         /* Using cursor P00B77 */
         pr_default.execute(5, new Object[] {AV70TipACod, AV92CueDAxu});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A71TipADCod = P00B77_A71TipADCod[0];
            A70TipACod = P00B77_A70TipACod[0];
            n70TipACod = P00B77_n70TipACod[0];
            A72TipADDsc = P00B77_A72TipADDsc[0];
            AV114GXLvl202 = 1;
            AV93CueDAxuDsc = A72TipADDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
         if ( AV114GXLvl202 == 0 )
         {
            AV93CueDAxuDsc = "SIN AUXILIAR";
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
         AV11Filename = "";
         AV13ErrorMessage = "";
         AV8Archivo = new GxFile(context.GetPhysicalPath());
         AV9Path = "";
         AV10FilenameOrigen = "";
         AV12ExcelDocument = new ExcelDocumentI();
         AV96FechaC = "";
         AV98FechaD = DateTime.MinValue;
         AV28Fecha = DateTime.MinValue;
         GXt_date1 = DateTime.MinValue;
         scmdbuf = "";
         P00B72_A126TASICod = new int[1] ;
         P00B72_A2077VouSts = new short[1] ;
         P00B72_A128VouMes = new short[1] ;
         P00B72_A127VouAno = new short[1] ;
         P00B72_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         P00B72_A129VouNum = new string[] {""} ;
         A2074VouFec = DateTime.MinValue;
         A129VouNum = "";
         AV101Titulo3 = "";
         A91CueCod = "";
         P00B73_A91CueCod = new string[] {""} ;
         P00B73_A860CueDsc = new string[] {""} ;
         A860CueDsc = "";
         AV87Cuenta = "";
         AV85CueDsc = "";
         P00B74_A867CueMov = new short[1] ;
         P00B74_A91CueCod = new string[] {""} ;
         AV95CueCod = "";
         P00B75_A91CueCod = new string[] {""} ;
         P00B75_A859CueCos = new short[1] ;
         P00B75_A70TipACod = new int[1] ;
         P00B75_n70TipACod = new bool[] {false} ;
         P00B75_A860CueDsc = new string[] {""} ;
         GXt_char2 = "";
         P00B76_A134CueAuxCod = new string[] {""} ;
         P00B76_A133CueCodAux = new string[] {""} ;
         P00B76_A91CueCod = new string[] {""} ;
         P00B76_A127VouAno = new short[1] ;
         P00B76_A128VouMes = new short[1] ;
         P00B76_A126TASICod = new int[1] ;
         P00B76_A129VouNum = new string[] {""} ;
         P00B76_A130VouDSec = new int[1] ;
         A134CueAuxCod = "";
         A133CueCodAux = "";
         AV92CueDAxu = "";
         GXt_char3 = "";
         AV93CueDAxuDsc = "";
         P00B77_A71TipADCod = new string[] {""} ;
         P00B77_A70TipACod = new int[1] ;
         P00B77_n70TipACod = new bool[] {false} ;
         P00B77_A72TipADDsc = new string[] {""} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_rlibroinventariobalancesexcel__default(),
            new Object[][] {
                new Object[] {
               P00B72_A126TASICod, P00B72_A2077VouSts, P00B72_A128VouMes, P00B72_A127VouAno, P00B72_A2074VouFec, P00B72_A129VouNum
               }
               , new Object[] {
               P00B73_A91CueCod, P00B73_A860CueDsc
               }
               , new Object[] {
               P00B74_A867CueMov, P00B74_A91CueCod
               }
               , new Object[] {
               P00B75_A91CueCod, P00B75_A859CueCos, P00B75_A70TipACod, P00B75_n70TipACod, P00B75_A860CueDsc
               }
               , new Object[] {
               P00B76_A134CueAuxCod, P00B76_A133CueCodAux, P00B76_A91CueCod, P00B76_A127VouAno, P00B76_A128VouMes, P00B76_A126TASICod, P00B76_A129VouNum, P00B76_A130VouDSec
               }
               , new Object[] {
               P00B77_A71TipADCod, P00B77_A70TipACod, P00B77_A72TipADDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV105Ano ;
      private short AV97Mes ;
      private short A2077VouSts ;
      private short A128VouMes ;
      private short A127VouAno ;
      private short AV104i ;
      private short A867CueMov ;
      private short A859CueCos ;
      private short AV114GXLvl202 ;
      private int AV14CellRow ;
      private int AV16FirstColumn ;
      private int A126TASICod ;
      private int AV86nDig ;
      private int A70TipACod ;
      private int AV70TipACod ;
      private int A130VouDSec ;
      private decimal AV90TTDebeAcumula ;
      private decimal AV91TTHaberAcumula ;
      private decimal AV99TDebeMO ;
      private decimal AV100ThaberMO ;
      private decimal AV102TotalPYP ;
      private decimal AV103TotalTitulo ;
      private decimal AV94Saldo ;
      private decimal AV88SaldoDMN ;
      private decimal AV89SaldoHMN ;
      private string AV96FechaC ;
      private string scmdbuf ;
      private string A129VouNum ;
      private string AV101Titulo3 ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string AV87Cuenta ;
      private string AV85CueDsc ;
      private string AV95CueCod ;
      private string GXt_char2 ;
      private string A134CueAuxCod ;
      private string A133CueCodAux ;
      private string AV92CueDAxu ;
      private string GXt_char3 ;
      private string AV93CueDAxuDsc ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private DateTime AV98FechaD ;
      private DateTime AV28Fecha ;
      private DateTime GXt_date1 ;
      private DateTime A2074VouFec ;
      private bool returnInSub ;
      private bool n70TipACod ;
      private bool BRKB76 ;
      private string AV11Filename ;
      private string AV13ErrorMessage ;
      private string AV9Path ;
      private string AV10FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private IDataStoreProvider pr_default ;
      private int[] P00B72_A126TASICod ;
      private short[] P00B72_A2077VouSts ;
      private short[] P00B72_A128VouMes ;
      private short[] P00B72_A127VouAno ;
      private DateTime[] P00B72_A2074VouFec ;
      private string[] P00B72_A129VouNum ;
      private string[] P00B73_A91CueCod ;
      private string[] P00B73_A860CueDsc ;
      private short[] P00B74_A867CueMov ;
      private string[] P00B74_A91CueCod ;
      private string[] P00B75_A91CueCod ;
      private short[] P00B75_A859CueCos ;
      private int[] P00B75_A70TipACod ;
      private bool[] P00B75_n70TipACod ;
      private string[] P00B75_A860CueDsc ;
      private string[] P00B76_A134CueAuxCod ;
      private string[] P00B76_A133CueCodAux ;
      private string[] P00B76_A91CueCod ;
      private short[] P00B76_A127VouAno ;
      private short[] P00B76_A128VouMes ;
      private int[] P00B76_A126TASICod ;
      private string[] P00B76_A129VouNum ;
      private int[] P00B76_A130VouDSec ;
      private string[] P00B77_A71TipADCod ;
      private int[] P00B77_A70TipACod ;
      private bool[] P00B77_n70TipACod ;
      private string[] P00B77_A72TipADDsc ;
      private string aP2_Filename ;
      private string aP3_ErrorMessage ;
      private ExcelDocumentI AV12ExcelDocument ;
      private GxFile AV8Archivo ;
   }

   public class r_rlibroinventariobalancesexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B73( IGxContext context ,
                                             short AV104i ,
                                             string A91CueCod ,
                                             int AV86nDig )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[1];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [CueCod], [CueDsc] FROM [CBPLANCUENTA]";
         AddWhere(sWhereString, "(LEN([CueCod]) = @AV86nDig)");
         if ( AV104i == 1 )
         {
            AddWhere(sWhereString, "(SUBSTRING([CueCod], 1, 2) >= '10' and SUBSTRING([CueCod], 1, 2) <= '39')");
         }
         if ( AV104i == 2 )
         {
            AddWhere(sWhereString, "(SUBSTRING([CueCod], 1, 2) >= '40' and SUBSTRING([CueCod], 1, 2) <= '49')");
         }
         if ( AV104i == 3 )
         {
            AddWhere(sWhereString, "(SUBSTRING([CueCod], 1, 2) >= '50' and SUBSTRING([CueCod], 1, 2) <= '59')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueCod]";
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
               case 1 :
                     return conditional_P00B73(context, (short)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] );
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
          Object[] prmP00B72;
          prmP00B72 = new Object[] {
          new ParDef("@AV105Ano",GXType.Int16,4,0) ,
          new ParDef("@AV97Mes",GXType.Int16,2,0)
          };
          Object[] prmP00B74;
          prmP00B74 = new Object[] {
          new ParDef("@AV86nDig",GXType.Int32,5,0) ,
          new ParDef("@AV87Cuenta",GXType.Char,15,0)
          };
          Object[] prmP00B75;
          prmP00B75 = new Object[] {
          new ParDef("@AV86nDig",GXType.Int32,5,0) ,
          new ParDef("@AV87Cuenta",GXType.Char,15,0)
          };
          Object[] prmP00B76;
          prmP00B76 = new Object[] {
          new ParDef("@AV105Ano",GXType.Int16,4,0) ,
          new ParDef("@AV95CueCod",GXType.NChar,15,0)
          };
          Object[] prmP00B77;
          prmP00B77 = new Object[] {
          new ParDef("@AV70TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV92CueDAxu",GXType.NChar,20,0)
          };
          Object[] prmP00B73;
          prmP00B73 = new Object[] {
          new ParDef("@AV86nDig",GXType.Int32,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B72", "SELECT TOP 1 [TASICod], [VouSts], [VouMes], [VouAno], [VouFec], [VouNum] FROM [CBVOUCHER] WHERE ([VouAno] = @AV105Ano and [VouMes] = @AV97Mes and [TASICod] = 1) AND ([VouSts] = 1) ORDER BY [VouAno], [VouMes], [TASICod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B72,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00B73", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B73,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B74", "SELECT [CueMov], [CueCod] FROM [CBPLANCUENTA] WHERE (SUBSTRING(RTRIM(LTRIM([CueCod])), 1, @AV86nDig) = RTRIM(LTRIM(@AV87Cuenta))) AND ([CueMov] = 1) ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B74,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B75", "SELECT [CueCod], [CueCos], [TipACod], [CueDsc] FROM [CBPLANCUENTA] WHERE SUBSTRING([CueCod], 1, @AV86nDig) = @AV87Cuenta ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B75,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B76", "SELECT [CueAuxCod], [CueCodAux], [CueCod], [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE ([VouAno] = @AV105Ano) AND ([CueCod] = @AV95CueCod) ORDER BY [CueCodAux], [CueAuxCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B76,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B77", "SELECT [TipADCod], [TipACod], [TipADDsc] FROM [CBAUXILIARES] WHERE [TipACod] = @AV70TipACod and [TipADCod] = @AV92CueDAxu ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B77,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
