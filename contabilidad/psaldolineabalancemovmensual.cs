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
   public class psaldolineabalancemovmensual : GXProcedure
   {
      public psaldolineabalancemovmensual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public psaldolineabalancemovmensual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TotTipo ,
                           int aP1_TotRub ,
                           int aP2_RubCod ,
                           int aP3_RubLinCod ,
                           short aP4_Ano ,
                           short aP5_Mes ,
                           string aP6_Tipo ,
                           string aP7_CosCod ,
                           out decimal aP8_Saldo )
      {
         this.AV8TotTipo = aP0_TotTipo;
         this.AV9TotRub = aP1_TotRub;
         this.AV10RubCod = aP2_RubCod;
         this.AV11RubLinCod = aP3_RubLinCod;
         this.AV12Ano = aP4_Ano;
         this.AV13Mes = aP5_Mes;
         this.AV20Tipo = aP6_Tipo;
         this.AV26CosCod = aP7_CosCod;
         this.AV14Saldo = 0 ;
         initialize();
         executePrivate();
         aP8_Saldo=this.AV14Saldo;
      }

      public decimal executeUdp( string aP0_TotTipo ,
                                 int aP1_TotRub ,
                                 int aP2_RubCod ,
                                 int aP3_RubLinCod ,
                                 short aP4_Ano ,
                                 short aP5_Mes ,
                                 string aP6_Tipo ,
                                 string aP7_CosCod )
      {
         execute(aP0_TotTipo, aP1_TotRub, aP2_RubCod, aP3_RubLinCod, aP4_Ano, aP5_Mes, aP6_Tipo, aP7_CosCod, out aP8_Saldo);
         return AV14Saldo ;
      }

      public void executeSubmit( string aP0_TotTipo ,
                                 int aP1_TotRub ,
                                 int aP2_RubCod ,
                                 int aP3_RubLinCod ,
                                 short aP4_Ano ,
                                 short aP5_Mes ,
                                 string aP6_Tipo ,
                                 string aP7_CosCod ,
                                 out decimal aP8_Saldo )
      {
         psaldolineabalancemovmensual objpsaldolineabalancemovmensual;
         objpsaldolineabalancemovmensual = new psaldolineabalancemovmensual();
         objpsaldolineabalancemovmensual.AV8TotTipo = aP0_TotTipo;
         objpsaldolineabalancemovmensual.AV9TotRub = aP1_TotRub;
         objpsaldolineabalancemovmensual.AV10RubCod = aP2_RubCod;
         objpsaldolineabalancemovmensual.AV11RubLinCod = aP3_RubLinCod;
         objpsaldolineabalancemovmensual.AV12Ano = aP4_Ano;
         objpsaldolineabalancemovmensual.AV13Mes = aP5_Mes;
         objpsaldolineabalancemovmensual.AV20Tipo = aP6_Tipo;
         objpsaldolineabalancemovmensual.AV26CosCod = aP7_CosCod;
         objpsaldolineabalancemovmensual.AV14Saldo = 0 ;
         objpsaldolineabalancemovmensual.context.SetSubmitInitialConfig(context);
         objpsaldolineabalancemovmensual.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpsaldolineabalancemovmensual);
         aP8_Saldo=this.AV14Saldo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((psaldolineabalancemovmensual)stateInfo).executePrivate();
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
         AV14Saldo = 0.00m;
         /* Using cursor P00CO2 */
         pr_default.execute(0, new Object[] {AV8TotTipo, AV9TotRub, AV10RubCod, AV11RubLinCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A118RubLinCod = P00CO2_A118RubLinCod[0];
            A116RubCod = P00CO2_A116RubCod[0];
            A115TotRub = P00CO2_A115TotRub[0];
            A114TotTipo = P00CO2_A114TotTipo[0];
            A1825RubLDPos = P00CO2_A1825RubLDPos[0];
            A1824RubLDNeg = P00CO2_A1824RubLDNeg[0];
            A91CueCod = P00CO2_A91CueCod[0];
            AV23RubLDPos = A1825RubLDPos;
            AV24RubLDNeg = A1824RubLDNeg;
            AV17Len = (short)(StringUtil.Len( A91CueCod));
            AV18Cuenta = A91CueCod;
            AV25Signo = ((AV23RubLDPos==0)&&(AV24RubLDNeg==0) ? "" : ((AV23RubLDPos==1) ? "+" : "-"));
            /* Execute user subroutine: 'OBTIENESALDO' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'OBTIENESALDO' Routine */
         returnInSub = false;
         AV19ImpMov = 0.00m;
         /* Using cursor P00CO3 */
         pr_default.execute(1, new Object[] {AV17Len, AV18Cuenta});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A91CueCod = P00CO3_A91CueCod[0];
            AV15CueCod = A91CueCod;
            /* Execute user subroutine: 'SALDOS' */
            S123 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25Signo)) )
            {
               if ( StringUtil.StrCmp(AV25Signo, "+") == 0 )
               {
                  if ( ( AV19ImpMov < Convert.ToDecimal( 0 )) )
                  {
                     AV19ImpMov = 0;
                  }
               }
               else
               {
                  if ( ( AV19ImpMov > Convert.ToDecimal( 0 )) )
                  {
                     AV19ImpMov = 0;
                  }
               }
            }
            if ( ( StringUtil.StrCmp(AV8TotTipo, "BAL") == 0 ) && ( AV9TotRub == 2 ) )
            {
               AV19ImpMov = (decimal)(AV19ImpMov*-1);
            }
            AV14Saldo = (decimal)(AV14Saldo+AV19ImpMov);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S123( )
      {
         /* 'SALDOS' Routine */
         returnInSub = false;
         AV28ImpSaldo = 0.00m;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV26CosCod ,
                                              A79COSCod ,
                                              A2077VouSts ,
                                              AV12Ano ,
                                              AV13Mes ,
                                              AV15CueCod ,
                                              A127VouAno ,
                                              A128VouMes ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CO4 */
         pr_default.execute(2, new Object[] {AV12Ano, AV13Mes, AV15CueCod, AV26CosCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00CO4_A126TASICod[0];
            A129VouNum = P00CO4_A129VouNum[0];
            A79COSCod = P00CO4_A79COSCod[0];
            n79COSCod = P00CO4_n79COSCod[0];
            A91CueCod = P00CO4_A91CueCod[0];
            A2077VouSts = P00CO4_A2077VouSts[0];
            A128VouMes = P00CO4_A128VouMes[0];
            A127VouAno = P00CO4_A127VouAno[0];
            A2055VouDHab = P00CO4_A2055VouDHab[0];
            A2051VouDDeb = P00CO4_A2051VouDDeb[0];
            A130VouDSec = P00CO4_A130VouDSec[0];
            A2077VouSts = P00CO4_A2077VouSts[0];
            AV28ImpSaldo = (decimal)(AV28ImpSaldo+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV19ImpMov = AV28ImpSaldo;
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
         scmdbuf = "";
         P00CO2_A118RubLinCod = new int[1] ;
         P00CO2_A116RubCod = new int[1] ;
         P00CO2_A115TotRub = new int[1] ;
         P00CO2_A114TotTipo = new string[] {""} ;
         P00CO2_A1825RubLDPos = new short[1] ;
         P00CO2_A1824RubLDNeg = new short[1] ;
         P00CO2_A91CueCod = new string[] {""} ;
         A114TotTipo = "";
         A91CueCod = "";
         AV18Cuenta = "";
         AV25Signo = "";
         P00CO3_A91CueCod = new string[] {""} ;
         AV15CueCod = "";
         A79COSCod = "";
         P00CO4_A126TASICod = new int[1] ;
         P00CO4_A129VouNum = new string[] {""} ;
         P00CO4_A79COSCod = new string[] {""} ;
         P00CO4_n79COSCod = new bool[] {false} ;
         P00CO4_A91CueCod = new string[] {""} ;
         P00CO4_A2077VouSts = new short[1] ;
         P00CO4_A128VouMes = new short[1] ;
         P00CO4_A127VouAno = new short[1] ;
         P00CO4_A2055VouDHab = new decimal[1] ;
         P00CO4_A2051VouDDeb = new decimal[1] ;
         P00CO4_A130VouDSec = new int[1] ;
         A129VouNum = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.psaldolineabalancemovmensual__default(),
            new Object[][] {
                new Object[] {
               P00CO2_A118RubLinCod, P00CO2_A116RubCod, P00CO2_A115TotRub, P00CO2_A114TotTipo, P00CO2_A1825RubLDPos, P00CO2_A1824RubLDNeg, P00CO2_A91CueCod
               }
               , new Object[] {
               P00CO3_A91CueCod
               }
               , new Object[] {
               P00CO4_A126TASICod, P00CO4_A129VouNum, P00CO4_A79COSCod, P00CO4_n79COSCod, P00CO4_A91CueCod, P00CO4_A2077VouSts, P00CO4_A128VouMes, P00CO4_A127VouAno, P00CO4_A2055VouDHab, P00CO4_A2051VouDDeb,
               P00CO4_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12Ano ;
      private short AV13Mes ;
      private short A1825RubLDPos ;
      private short A1824RubLDNeg ;
      private short AV23RubLDPos ;
      private short AV24RubLDNeg ;
      private short AV17Len ;
      private short A2077VouSts ;
      private short A127VouAno ;
      private short A128VouMes ;
      private int AV9TotRub ;
      private int AV10RubCod ;
      private int AV11RubLinCod ;
      private int A118RubLinCod ;
      private int A116RubCod ;
      private int A115TotRub ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private decimal AV14Saldo ;
      private decimal AV19ImpMov ;
      private decimal AV28ImpSaldo ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private string AV8TotTipo ;
      private string AV20Tipo ;
      private string AV26CosCod ;
      private string scmdbuf ;
      private string A114TotTipo ;
      private string A91CueCod ;
      private string AV18Cuenta ;
      private string AV25Signo ;
      private string AV15CueCod ;
      private string A79COSCod ;
      private string A129VouNum ;
      private bool returnInSub ;
      private bool n79COSCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00CO2_A118RubLinCod ;
      private int[] P00CO2_A116RubCod ;
      private int[] P00CO2_A115TotRub ;
      private string[] P00CO2_A114TotTipo ;
      private short[] P00CO2_A1825RubLDPos ;
      private short[] P00CO2_A1824RubLDNeg ;
      private string[] P00CO2_A91CueCod ;
      private string[] P00CO3_A91CueCod ;
      private int[] P00CO4_A126TASICod ;
      private string[] P00CO4_A129VouNum ;
      private string[] P00CO4_A79COSCod ;
      private bool[] P00CO4_n79COSCod ;
      private string[] P00CO4_A91CueCod ;
      private short[] P00CO4_A2077VouSts ;
      private short[] P00CO4_A128VouMes ;
      private short[] P00CO4_A127VouAno ;
      private decimal[] P00CO4_A2055VouDHab ;
      private decimal[] P00CO4_A2051VouDDeb ;
      private int[] P00CO4_A130VouDSec ;
      private decimal aP8_Saldo ;
   }

   public class psaldolineabalancemovmensual__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CO4( IGxContext context ,
                                             string AV26CosCod ,
                                             string A79COSCod ,
                                             short A2077VouSts ,
                                             short AV12Ano ,
                                             short AV13Mes ,
                                             string AV15CueCod ,
                                             short A127VouAno ,
                                             short A128VouMes ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T1.[VouNum], T1.[COSCod], T1.[CueCod], T2.[VouSts], T1.[VouMes], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV12Ano and T1.[VouMes] = @AV13Mes and T1.[CueCod] = @AV15CueCod)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26CosCod)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV26CosCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod]";
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
               case 2 :
                     return conditional_P00CO4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] );
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
          Object[] prmP00CO2;
          prmP00CO2 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV10RubCod",GXType.Int32,6,0) ,
          new ParDef("@AV11RubLinCod",GXType.Int32,6,0)
          };
          Object[] prmP00CO3;
          prmP00CO3 = new Object[] {
          new ParDef("@AV17Len",GXType.Int16,2,0) ,
          new ParDef("@AV18Cuenta",GXType.Char,15,0)
          };
          Object[] prmP00CO4;
          prmP00CO4 = new Object[] {
          new ParDef("@AV12Ano",GXType.Int16,4,0) ,
          new ParDef("@AV13Mes",GXType.Int16,2,0) ,
          new ParDef("@AV15CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV26CosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CO2", "SELECT [RubLinCod], [RubCod], [TotRub], [TotTipo], [RubLDPos], [RubLDNeg], [CueCod] FROM [CBRUBROSLD] WHERE [TotTipo] = @AV8TotTipo and [TotRub] = @AV9TotRub and [RubCod] = @AV10RubCod and [RubLinCod] = @AV11RubLinCod ORDER BY [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CO3", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE SUBSTRING([CueCod], 1, @AV17Len) = @AV18Cuenta ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CO3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CO4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CO4,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                return;
       }
    }

 }

}
