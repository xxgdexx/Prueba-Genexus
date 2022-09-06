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
   public class psaldolineabalancemesactual : GXProcedure
   {
      public psaldolineabalancemesactual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public psaldolineabalancemesactual( IGxContext context )
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
                           out decimal aP6_Saldo )
      {
         this.AV8TotTipo = aP0_TotTipo;
         this.AV9TotRub = aP1_TotRub;
         this.AV10RubCod = aP2_RubCod;
         this.AV11RubLinCod = aP3_RubLinCod;
         this.AV12Ano = aP4_Ano;
         this.AV13Mes = aP5_Mes;
         this.AV14Saldo = 0 ;
         initialize();
         executePrivate();
         aP6_Saldo=this.AV14Saldo;
      }

      public decimal executeUdp( string aP0_TotTipo ,
                                 int aP1_TotRub ,
                                 int aP2_RubCod ,
                                 int aP3_RubLinCod ,
                                 short aP4_Ano ,
                                 short aP5_Mes )
      {
         execute(aP0_TotTipo, aP1_TotRub, aP2_RubCod, aP3_RubLinCod, aP4_Ano, aP5_Mes, out aP6_Saldo);
         return AV14Saldo ;
      }

      public void executeSubmit( string aP0_TotTipo ,
                                 int aP1_TotRub ,
                                 int aP2_RubCod ,
                                 int aP3_RubLinCod ,
                                 short aP4_Ano ,
                                 short aP5_Mes ,
                                 out decimal aP6_Saldo )
      {
         psaldolineabalancemesactual objpsaldolineabalancemesactual;
         objpsaldolineabalancemesactual = new psaldolineabalancemesactual();
         objpsaldolineabalancemesactual.AV8TotTipo = aP0_TotTipo;
         objpsaldolineabalancemesactual.AV9TotRub = aP1_TotRub;
         objpsaldolineabalancemesactual.AV10RubCod = aP2_RubCod;
         objpsaldolineabalancemesactual.AV11RubLinCod = aP3_RubLinCod;
         objpsaldolineabalancemesactual.AV12Ano = aP4_Ano;
         objpsaldolineabalancemesactual.AV13Mes = aP5_Mes;
         objpsaldolineabalancemesactual.AV14Saldo = 0 ;
         objpsaldolineabalancemesactual.context.SetSubmitInitialConfig(context);
         objpsaldolineabalancemesactual.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpsaldolineabalancemesactual);
         aP6_Saldo=this.AV14Saldo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((psaldolineabalancemesactual)stateInfo).executePrivate();
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
         /* Using cursor P00CS2 */
         pr_default.execute(0, new Object[] {AV8TotTipo, AV9TotRub, AV10RubCod, AV11RubLinCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A118RubLinCod = P00CS2_A118RubLinCod[0];
            A116RubCod = P00CS2_A116RubCod[0];
            A115TotRub = P00CS2_A115TotRub[0];
            A114TotTipo = P00CS2_A114TotTipo[0];
            A1825RubLDPos = P00CS2_A1825RubLDPos[0];
            A1824RubLDNeg = P00CS2_A1824RubLDNeg[0];
            A91CueCod = P00CS2_A91CueCod[0];
            AV23RubLDPos = A1825RubLDPos;
            AV24RubLDNeg = A1824RubLDNeg;
            AV17Len = (short)(StringUtil.Len( A91CueCod));
            AV18Cuenta = A91CueCod;
            AV14Saldo = 0.00m;
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
         /* Using cursor P00CS3 */
         pr_default.execute(1, new Object[] {AV17Len, AV18Cuenta});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A91CueCod = P00CS3_A91CueCod[0];
            AV15CueCod = A91CueCod;
            AV19ImpMov = 0.00m;
            /* Using cursor P00CS4 */
            pr_default.execute(2, new Object[] {AV12Ano, AV13Mes, AV15CueCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A126TASICod = P00CS4_A126TASICod[0];
               A129VouNum = P00CS4_A129VouNum[0];
               A2077VouSts = P00CS4_A2077VouSts[0];
               A128VouMes = P00CS4_A128VouMes[0];
               A127VouAno = P00CS4_A127VouAno[0];
               A91CueCod = P00CS4_A91CueCod[0];
               A2055VouDHab = P00CS4_A2055VouDHab[0];
               A2051VouDDeb = P00CS4_A2051VouDDeb[0];
               A130VouDSec = P00CS4_A130VouDSec[0];
               A2077VouSts = P00CS4_A2077VouSts[0];
               AV19ImpMov = (decimal)(AV19ImpMov+(A2051VouDDeb-A2055VouDHab));
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV14Saldo = (decimal)(AV14Saldo+AV19ImpMov);
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         P00CS2_A118RubLinCod = new int[1] ;
         P00CS2_A116RubCod = new int[1] ;
         P00CS2_A115TotRub = new int[1] ;
         P00CS2_A114TotTipo = new string[] {""} ;
         P00CS2_A1825RubLDPos = new short[1] ;
         P00CS2_A1824RubLDNeg = new short[1] ;
         P00CS2_A91CueCod = new string[] {""} ;
         A114TotTipo = "";
         A91CueCod = "";
         AV18Cuenta = "";
         P00CS3_A91CueCod = new string[] {""} ;
         AV15CueCod = "";
         P00CS4_A126TASICod = new int[1] ;
         P00CS4_A129VouNum = new string[] {""} ;
         P00CS4_A2077VouSts = new short[1] ;
         P00CS4_A128VouMes = new short[1] ;
         P00CS4_A127VouAno = new short[1] ;
         P00CS4_A91CueCod = new string[] {""} ;
         P00CS4_A2055VouDHab = new decimal[1] ;
         P00CS4_A2051VouDDeb = new decimal[1] ;
         P00CS4_A130VouDSec = new int[1] ;
         A129VouNum = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.psaldolineabalancemesactual__default(),
            new Object[][] {
                new Object[] {
               P00CS2_A118RubLinCod, P00CS2_A116RubCod, P00CS2_A115TotRub, P00CS2_A114TotTipo, P00CS2_A1825RubLDPos, P00CS2_A1824RubLDNeg, P00CS2_A91CueCod
               }
               , new Object[] {
               P00CS3_A91CueCod
               }
               , new Object[] {
               P00CS4_A126TASICod, P00CS4_A129VouNum, P00CS4_A2077VouSts, P00CS4_A128VouMes, P00CS4_A127VouAno, P00CS4_A91CueCod, P00CS4_A2055VouDHab, P00CS4_A2051VouDDeb, P00CS4_A130VouDSec
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
      private short A128VouMes ;
      private short A127VouAno ;
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
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private string AV8TotTipo ;
      private string scmdbuf ;
      private string A114TotTipo ;
      private string A91CueCod ;
      private string AV18Cuenta ;
      private string AV15CueCod ;
      private string A129VouNum ;
      private bool returnInSub ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00CS2_A118RubLinCod ;
      private int[] P00CS2_A116RubCod ;
      private int[] P00CS2_A115TotRub ;
      private string[] P00CS2_A114TotTipo ;
      private short[] P00CS2_A1825RubLDPos ;
      private short[] P00CS2_A1824RubLDNeg ;
      private string[] P00CS2_A91CueCod ;
      private string[] P00CS3_A91CueCod ;
      private int[] P00CS4_A126TASICod ;
      private string[] P00CS4_A129VouNum ;
      private short[] P00CS4_A2077VouSts ;
      private short[] P00CS4_A128VouMes ;
      private short[] P00CS4_A127VouAno ;
      private string[] P00CS4_A91CueCod ;
      private decimal[] P00CS4_A2055VouDHab ;
      private decimal[] P00CS4_A2051VouDDeb ;
      private int[] P00CS4_A130VouDSec ;
      private decimal aP6_Saldo ;
   }

   public class psaldolineabalancemesactual__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CS2;
          prmP00CS2 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV10RubCod",GXType.Int32,6,0) ,
          new ParDef("@AV11RubLinCod",GXType.Int32,6,0)
          };
          Object[] prmP00CS3;
          prmP00CS3 = new Object[] {
          new ParDef("@AV17Len",GXType.Int16,2,0) ,
          new ParDef("@AV18Cuenta",GXType.Char,15,0)
          };
          Object[] prmP00CS4;
          prmP00CS4 = new Object[] {
          new ParDef("@AV12Ano",GXType.Int16,4,0) ,
          new ParDef("@AV13Mes",GXType.Int16,2,0) ,
          new ParDef("@AV15CueCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CS2", "SELECT [RubLinCod], [RubCod], [TotRub], [TotTipo], [RubLDPos], [RubLDNeg], [CueCod] FROM [CBRUBROSLD] WHERE [TotTipo] = @AV8TotTipo and [TotRub] = @AV9TotRub and [RubCod] = @AV10RubCod and [RubLinCod] = @AV11RubLinCod ORDER BY [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CS2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CS3", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE SUBSTRING([CueCod], 1, @AV17Len) = @AV18Cuenta ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CS3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CS4", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[VouAno], T1.[CueCod], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV12Ano and T1.[VouMes] = @AV13Mes and T1.[CueCod] = @AV15CueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CS4,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
