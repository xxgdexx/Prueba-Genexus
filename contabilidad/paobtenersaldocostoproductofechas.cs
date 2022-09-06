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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.contabilidad {
   public class paobtenersaldocostoproductofechas : GXProcedure
   {
      public paobtenersaldocostoproductofechas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public paobtenersaldocostoproductofechas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_Fecha ,
                           ref int aP1_AlmCod ,
                           ref string aP2_ProdCod ,
                           out decimal aP3_Final ,
                           out decimal aP4_CostoU )
      {
         this.AV18Fecha = aP0_Fecha;
         this.AV8AlmCod = aP1_AlmCod;
         this.AV33ProdCod = aP2_ProdCod;
         this.AV21Final = 0 ;
         this.AV13CostoU = 0 ;
         initialize();
         executePrivate();
         aP0_Fecha=this.AV18Fecha;
         aP1_AlmCod=this.AV8AlmCod;
         aP2_ProdCod=this.AV33ProdCod;
         aP3_Final=this.AV21Final;
         aP4_CostoU=this.AV13CostoU;
      }

      public decimal executeUdp( ref DateTime aP0_Fecha ,
                                 ref int aP1_AlmCod ,
                                 ref string aP2_ProdCod ,
                                 out decimal aP3_Final )
      {
         execute(ref aP0_Fecha, ref aP1_AlmCod, ref aP2_ProdCod, out aP3_Final, out aP4_CostoU);
         return AV13CostoU ;
      }

      public void executeSubmit( ref DateTime aP0_Fecha ,
                                 ref int aP1_AlmCod ,
                                 ref string aP2_ProdCod ,
                                 out decimal aP3_Final ,
                                 out decimal aP4_CostoU )
      {
         paobtenersaldocostoproductofechas objpaobtenersaldocostoproductofechas;
         objpaobtenersaldocostoproductofechas = new paobtenersaldocostoproductofechas();
         objpaobtenersaldocostoproductofechas.AV18Fecha = aP0_Fecha;
         objpaobtenersaldocostoproductofechas.AV8AlmCod = aP1_AlmCod;
         objpaobtenersaldocostoproductofechas.AV33ProdCod = aP2_ProdCod;
         objpaobtenersaldocostoproductofechas.AV21Final = 0 ;
         objpaobtenersaldocostoproductofechas.AV13CostoU = 0 ;
         objpaobtenersaldocostoproductofechas.context.SetSubmitInitialConfig(context);
         objpaobtenersaldocostoproductofechas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpaobtenersaldocostoproductofechas);
         aP0_Fecha=this.AV18Fecha;
         aP1_AlmCod=this.AV8AlmCod;
         aP2_ProdCod=this.AV33ProdCod;
         aP3_Final=this.AV21Final;
         aP4_CostoU=this.AV13CostoU;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((paobtenersaldocostoproductofechas)stateInfo).executePrivate();
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
         AV39Saldo = 0.0000m;
         AV13CostoU = 0.00000000m;
         AV9Ano = (short)(DateTimeUtil.Year( AV18Fecha));
         AV27Mes = (short)(DateTimeUtil.Month( AV18Fecha));
         if ( AV27Mes == 1 )
         {
            AV10AnoAnt = (short)(AV9Ano-1);
            AV28MesAnt = 12;
         }
         else
         {
            AV10AnoAnt = AV9Ano;
            AV28MesAnt = (short)(AV27Mes-1);
         }
         AV20FFechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV27Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV9Ano), 4, 0));
         AV16FDesde = context.localUtil.CToD( AV20FFechaC, 2);
         /* Using cursor P00C02 */
         pr_default.execute(0, new Object[] {AV33ProdCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A28ProdCod = P00C02_A28ProdCod[0];
            A55ProdDsc = P00C02_A55ProdDsc[0];
            AV34ProdCodC = StringUtil.Trim( A28ProdCod);
            AV35Producto = A55ProdDsc;
            AV11CanIni = 0;
            AV41TCosIni = 0;
            AV42TCosTIni = 0;
            AV23Ing1 = 0;
            AV25IngCU = 0;
            AV24IngCT = 0;
            AV50TTIngreso = 0;
            AV45TIngresoCT = 0;
            AV46TIngresoCU = 0;
            AV36Sal1 = 0;
            AV38SalCU = 0;
            AV37SalCT = 0;
            AV51TTSalida = 0;
            AV48TsalidaCT = 0;
            AV46TIngresoCU = 0;
            AV21Final = 0;
            /* Execute user subroutine: 'SALDOFINALAÑO' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV12CostoT = NumberUtil.Round( AV39Saldo*AV13CostoU, 2);
            AV43TCosto = AV12CostoT;
            AV21Final = AV39Saldo;
            AV26Ingresa = 0;
            AV40Salida = 0;
            AV44TIngreso = ((AV39Saldo>Convert.ToDecimal(0)) ? AV39Saldo : (decimal)(0));
            AV47TSalida = ((AV39Saldo<Convert.ToDecimal(0)) ? AV39Saldo : (decimal)(0));
            AV14CostoUAnt = AV13CostoU;
            AV11CanIni = AV44TIngreso;
            AV41TCosIni = AV14CostoUAnt;
            AV42TCosTIni = NumberUtil.Round( AV11CanIni*AV41TCosIni, 2);
            /* Using cursor P00C03 */
            pr_default.execute(1, new Object[] {AV16FDesde, A28ProdCod, AV34ProdCodC, AV8AlmCod, AV18Fecha});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A21MvAlm = P00C03_A21MvAlm[0];
               A1272MVAlmSts = P00C03_A1272MVAlmSts[0];
               A1370MVSts = P00C03_A1370MVSts[0];
               A25MvAFec = P00C03_A25MvAFec[0];
               A1278MvARef = P00C03_A1278MvARef[0];
               A1276MvAOcom = P00C03_A1276MvAOcom[0];
               A24DocNum = P00C03_A24DocNum[0];
               n24DocNum = P00C03_n24DocNum[0];
               A1248MvADCant = P00C03_A1248MvADCant[0];
               A1250MVADPrecio = P00C03_A1250MVADPrecio[0];
               A1249MVADCosto = P00C03_A1249MVADCosto[0];
               A14MvACod = P00C03_A14MvACod[0];
               A13MvATip = P00C03_A13MvATip[0];
               A30MvADItem = P00C03_A30MvADItem[0];
               A21MvAlm = P00C03_A21MvAlm[0];
               A1370MVSts = P00C03_A1370MVSts[0];
               A25MvAFec = P00C03_A25MvAFec[0];
               A1278MvARef = P00C03_A1278MvARef[0];
               A1276MvAOcom = P00C03_A1276MvAOcom[0];
               A24DocNum = P00C03_A24DocNum[0];
               n24DocNum = P00C03_n24DocNum[0];
               A1272MVAlmSts = P00C03_A1272MVAlmSts[0];
               AV32MVATip = A13MvATip;
               AV30MVACod = A14MvACod;
               AV15DocRef = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? (String.IsNullOrEmpty(StringUtil.RTrim( A1276MvAOcom)) ? A1278MvARef : A1276MvAOcom) : A24DocNum);
               AV26Ingresa = ((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1248MvADCant : (decimal)(0));
               AV40Salida = ((StringUtil.StrCmp(A13MvATip, "ING")!=0) ? A1248MvADCant : (decimal)(0));
               AV13CostoU = 0;
               AV12CostoT = 0;
               AV23Ing1 = 0;
               AV25IngCU = 0;
               AV24IngCT = 0;
               AV36Sal1 = 0;
               AV38SalCU = 0;
               AV37SalCT = 0;
               if ( StringUtil.StrCmp(A13MvATip, "ING") == 0 )
               {
                  AV13CostoU = A1250MVADPrecio;
                  AV12CostoT = A1249MVADCosto;
                  AV43TCosto = (decimal)(AV43TCosto+AV12CostoT);
                  AV14CostoUAnt = 0;
                  AV23Ing1 = AV26Ingresa;
                  AV25IngCU = AV13CostoU;
                  AV24IngCT = AV12CostoT;
               }
               else
               {
                  if ( ! (Convert.ToDecimal(0)==AV14CostoUAnt) )
                  {
                     AV13CostoU = AV14CostoUAnt;
                  }
                  else
                  {
                     if ( ( AV21Final == Convert.ToDecimal( 0 )) )
                     {
                        AV13CostoU = 0;
                     }
                     else
                     {
                        AV13CostoU = NumberUtil.Round( AV43TCosto/ (decimal)(AV21Final), 8);
                     }
                  }
                  AV12CostoT = NumberUtil.Round( AV13CostoU*AV40Salida, 2);
                  AV43TCosto = (decimal)(AV43TCosto+((AV12CostoT*-1)));
                  AV14CostoUAnt = AV13CostoU;
                  AV36Sal1 = AV40Salida;
                  AV38SalCU = AV13CostoU;
                  AV37SalCT = AV12CostoT;
               }
               AV50TTIngreso = (decimal)(AV50TTIngreso+AV23Ing1);
               AV45TIngresoCT = (decimal)(AV45TIngresoCT+AV24IngCT);
               AV46TIngresoCU = ((AV50TTIngreso>Convert.ToDecimal(0)) ? NumberUtil.Round( AV45TIngresoCT/ (decimal)(AV50TTIngreso), 8) : (decimal)(0));
               AV51TTSalida = (decimal)(AV51TTSalida+AV36Sal1);
               AV48TsalidaCT = (decimal)(AV48TsalidaCT+AV37SalCT);
               AV49TSalidaCU = ((AV51TTSalida>Convert.ToDecimal(0)) ? NumberUtil.Round( AV48TsalidaCT/ (decimal)(AV51TTSalida), 8) : (decimal)(0));
               AV21Final = (decimal)(AV21Final+((AV26Ingresa-AV40Salida)));
               AV44TIngreso = (decimal)(AV44TIngreso+AV26Ingresa);
               AV47TSalida = (decimal)(AV47TSalida+AV40Salida);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( ! (Convert.ToDecimal(0)==AV14CostoUAnt) )
            {
               AV13CostoU = AV14CostoUAnt;
            }
            else
            {
               if ( ( AV21Final == Convert.ToDecimal( 0 )) )
               {
                  AV13CostoU = 0;
               }
               else
               {
                  AV13CostoU = NumberUtil.Round( AV43TCosto/ (decimal)(AV21Final), 8);
               }
            }
            AV12CostoT = NumberUtil.Round( AV13CostoU*AV21Final, 2);
            AV43TCosto = AV12CostoT;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'SALDOFINALAÑO' Routine */
         returnInSub = false;
         /* Using cursor P00C04 */
         pr_default.execute(2, new Object[] {AV10AnoAnt, AV28MesAnt, AV8AlmCod, AV34ProdCodC});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A62SalCosProdCod = P00C04_A62SalCosProdCod[0];
            A61SalCosAlmCod = P00C04_A61SalCosAlmCod[0];
            A60SalCosMes = P00C04_A60SalCosMes[0];
            A59SalCosAno = P00C04_A59SalCosAno[0];
            A1830SalCosCant = P00C04_A1830SalCosCant[0];
            A1831SalCosUni = P00C04_A1831SalCosUni[0];
            AV39Saldo = A1830SalCosCant;
            AV13CostoU = A1831SalCosUni;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
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
         AV20FFechaC = "";
         AV16FDesde = DateTime.MinValue;
         scmdbuf = "";
         P00C02_A28ProdCod = new string[] {""} ;
         P00C02_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         AV34ProdCodC = "";
         AV35Producto = "";
         P00C03_A28ProdCod = new string[] {""} ;
         P00C03_A21MvAlm = new int[1] ;
         P00C03_A1272MVAlmSts = new short[1] ;
         P00C03_A1370MVSts = new string[] {""} ;
         P00C03_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00C03_A1278MvARef = new string[] {""} ;
         P00C03_A1276MvAOcom = new string[] {""} ;
         P00C03_A24DocNum = new string[] {""} ;
         P00C03_n24DocNum = new bool[] {false} ;
         P00C03_A1248MvADCant = new decimal[1] ;
         P00C03_A1250MVADPrecio = new decimal[1] ;
         P00C03_A1249MVADCosto = new decimal[1] ;
         P00C03_A14MvACod = new string[] {""} ;
         P00C03_A13MvATip = new string[] {""} ;
         P00C03_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         A1278MvARef = "";
         A1276MvAOcom = "";
         A24DocNum = "";
         A14MvACod = "";
         A13MvATip = "";
         AV32MVATip = "";
         AV30MVACod = "";
         AV15DocRef = "";
         P00C04_A62SalCosProdCod = new string[] {""} ;
         P00C04_A61SalCosAlmCod = new int[1] ;
         P00C04_A60SalCosMes = new short[1] ;
         P00C04_A59SalCosAno = new int[1] ;
         P00C04_A1830SalCosCant = new decimal[1] ;
         P00C04_A1831SalCosUni = new decimal[1] ;
         A62SalCosProdCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.paobtenersaldocostoproductofechas__default(),
            new Object[][] {
                new Object[] {
               P00C02_A28ProdCod, P00C02_A55ProdDsc
               }
               , new Object[] {
               P00C03_A28ProdCod, P00C03_A21MvAlm, P00C03_A1272MVAlmSts, P00C03_A1370MVSts, P00C03_A25MvAFec, P00C03_A1278MvARef, P00C03_A1276MvAOcom, P00C03_A24DocNum, P00C03_n24DocNum, P00C03_A1248MvADCant,
               P00C03_A1250MVADPrecio, P00C03_A1249MVADCosto, P00C03_A14MvACod, P00C03_A13MvATip, P00C03_A30MvADItem
               }
               , new Object[] {
               P00C04_A62SalCosProdCod, P00C04_A61SalCosAlmCod, P00C04_A60SalCosMes, P00C04_A59SalCosAno, P00C04_A1830SalCosCant, P00C04_A1831SalCosUni
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9Ano ;
      private short AV27Mes ;
      private short AV10AnoAnt ;
      private short AV28MesAnt ;
      private short A1272MVAlmSts ;
      private short A60SalCosMes ;
      private int AV8AlmCod ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private int A61SalCosAlmCod ;
      private int A59SalCosAno ;
      private decimal AV21Final ;
      private decimal AV13CostoU ;
      private decimal AV39Saldo ;
      private decimal AV11CanIni ;
      private decimal AV41TCosIni ;
      private decimal AV42TCosTIni ;
      private decimal AV23Ing1 ;
      private decimal AV25IngCU ;
      private decimal AV24IngCT ;
      private decimal AV50TTIngreso ;
      private decimal AV45TIngresoCT ;
      private decimal AV46TIngresoCU ;
      private decimal AV36Sal1 ;
      private decimal AV38SalCU ;
      private decimal AV37SalCT ;
      private decimal AV51TTSalida ;
      private decimal AV48TsalidaCT ;
      private decimal AV12CostoT ;
      private decimal AV43TCosto ;
      private decimal AV26Ingresa ;
      private decimal AV40Salida ;
      private decimal AV44TIngreso ;
      private decimal AV47TSalida ;
      private decimal AV14CostoUAnt ;
      private decimal A1248MvADCant ;
      private decimal A1250MVADPrecio ;
      private decimal A1249MVADCosto ;
      private decimal AV49TSalidaCU ;
      private decimal A1830SalCosCant ;
      private decimal A1831SalCosUni ;
      private string AV33ProdCod ;
      private string AV20FFechaC ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string AV34ProdCodC ;
      private string AV35Producto ;
      private string A1370MVSts ;
      private string A1278MvARef ;
      private string A1276MvAOcom ;
      private string A24DocNum ;
      private string A14MvACod ;
      private string A13MvATip ;
      private string AV32MVATip ;
      private string AV30MVACod ;
      private string AV15DocRef ;
      private string A62SalCosProdCod ;
      private DateTime AV18Fecha ;
      private DateTime AV16FDesde ;
      private DateTime A25MvAFec ;
      private bool returnInSub ;
      private bool n24DocNum ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_Fecha ;
      private int aP1_AlmCod ;
      private string aP2_ProdCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00C02_A28ProdCod ;
      private string[] P00C02_A55ProdDsc ;
      private string[] P00C03_A28ProdCod ;
      private int[] P00C03_A21MvAlm ;
      private short[] P00C03_A1272MVAlmSts ;
      private string[] P00C03_A1370MVSts ;
      private DateTime[] P00C03_A25MvAFec ;
      private string[] P00C03_A1278MvARef ;
      private string[] P00C03_A1276MvAOcom ;
      private string[] P00C03_A24DocNum ;
      private bool[] P00C03_n24DocNum ;
      private decimal[] P00C03_A1248MvADCant ;
      private decimal[] P00C03_A1250MVADPrecio ;
      private decimal[] P00C03_A1249MVADCosto ;
      private string[] P00C03_A14MvACod ;
      private string[] P00C03_A13MvATip ;
      private int[] P00C03_A30MvADItem ;
      private string[] P00C04_A62SalCosProdCod ;
      private int[] P00C04_A61SalCosAlmCod ;
      private short[] P00C04_A60SalCosMes ;
      private int[] P00C04_A59SalCosAno ;
      private decimal[] P00C04_A1830SalCosCant ;
      private decimal[] P00C04_A1831SalCosUni ;
      private decimal aP3_Final ;
      private decimal aP4_CostoU ;
   }

   public class paobtenersaldocostoproductofechas__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00C02;
          prmP00C02 = new Object[] {
          new ParDef("@AV33ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00C03;
          prmP00C03 = new Object[] {
          new ParDef("@AV16FDesde",GXType.Date,8,0) ,
          new ParDef("@ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV34ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV8AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV18Fecha",GXType.Date,8,0)
          };
          Object[] prmP00C04;
          prmP00C04 = new Object[] {
          new ParDef("@AV10AnoAnt",GXType.Int16,4,0) ,
          new ParDef("@AV28MesAnt",GXType.Int16,2,0) ,
          new ParDef("@AV8AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV34ProdCodC",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C02", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV33ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C02,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00C03", "SELECT T1.[ProdCod], T2.[MvAlm] AS MvAlm, T3.[AlmSts] AS MVAlmSts, T2.[MVSts], T2.[MvAFec], T2.[MvARef], T2.[MvAOcom], T2.[DocNum], T1.[MvADCant], T1.[MVADPrecio], T1.[MVADCosto], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM (([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) WHERE (T2.[MvAFec] >= @AV16FDesde) AND (T1.[ProdCod] = @ProdCod) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV34ProdCodC))) AND (T2.[MVSts] <> 'A') AND (T2.[MvAlm] = @AV8AlmCod) AND (T3.[AlmSts] = 1) AND (T2.[MvAFec] < @AV18Fecha) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C03,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C04", "SELECT [SalCosProdCod], [SalCosAlmCod], [SalCosMes], [SalCosAno], [SalCosCant], [SalCosUni] FROM [ASALDOCOSTOMENSUAL] WHERE [SalCosAno] = @AV10AnoAnt and [SalCosMes] = @AV28MesAnt and [SalCosAlmCod] = @AV8AlmCod and [SalCosProdCod] = @AV34ProdCodC ORDER BY [SalCosAno], [SalCosMes], [SalCosAlmCod], [SalCosProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C04,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((string[]) buf[7])[0] = rslt.getString(8, 12);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((string[]) buf[12])[0] = rslt.getString(12, 12);
                ((string[]) buf[13])[0] = rslt.getString(13, 3);
                ((int[]) buf[14])[0] = rslt.getInt(14);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                return;
       }
    }

 }

}
