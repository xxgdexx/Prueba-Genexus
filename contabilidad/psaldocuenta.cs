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
   public class psaldocuenta : GXProcedure
   {
      public psaldocuenta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public psaldocuenta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_CueCod ,
                           short aP1_Ano ,
                           short aP2_Mes ,
                           int aP3_MonCod ,
                           out decimal aP4_Saldo )
      {
         this.AV8CueCod = aP0_CueCod;
         this.AV10Ano = aP1_Ano;
         this.AV11Mes = aP2_Mes;
         this.AV20MonCod = aP3_MonCod;
         this.AV12Saldo = 0 ;
         initialize();
         executePrivate();
         aP4_Saldo=this.AV12Saldo;
      }

      public decimal executeUdp( string aP0_CueCod ,
                                 short aP1_Ano ,
                                 short aP2_Mes ,
                                 int aP3_MonCod )
      {
         execute(aP0_CueCod, aP1_Ano, aP2_Mes, aP3_MonCod, out aP4_Saldo);
         return AV12Saldo ;
      }

      public void executeSubmit( string aP0_CueCod ,
                                 short aP1_Ano ,
                                 short aP2_Mes ,
                                 int aP3_MonCod ,
                                 out decimal aP4_Saldo )
      {
         psaldocuenta objpsaldocuenta;
         objpsaldocuenta = new psaldocuenta();
         objpsaldocuenta.AV8CueCod = aP0_CueCod;
         objpsaldocuenta.AV10Ano = aP1_Ano;
         objpsaldocuenta.AV11Mes = aP2_Mes;
         objpsaldocuenta.AV20MonCod = aP3_MonCod;
         objpsaldocuenta.AV12Saldo = 0 ;
         objpsaldocuenta.context.SetSubmitInitialConfig(context);
         objpsaldocuenta.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpsaldocuenta);
         aP4_Saldo=this.AV12Saldo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((psaldocuenta)stateInfo).executePrivate();
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
         AV12Saldo = 0.00m;
         AV16MesAnt = (short)(AV11Mes-1);
         AV19Len = (short)(StringUtil.Len( AV8CueCod));
         /* Using cursor P00B92 */
         pr_default.execute(0, new Object[] {AV10Ano, AV16MesAnt, AV19Len, AV8CueCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A123SalCueCod = P00B92_A123SalCueCod[0];
            A122SalVouMes = P00B92_A122SalVouMes[0];
            A121SalVouAno = P00B92_A121SalVouAno[0];
            A124SalMonCod = P00B92_A124SalMonCod[0];
            A1838SalTipCmb = P00B92_A1838SalTipCmb[0];
            A864CueMon = P00B92_A864CueMon[0];
            n864CueMon = P00B92_n864CueMon[0];
            A1841SalVouHaber = P00B92_A1841SalVouHaber[0];
            A1839SalVouDebe = P00B92_A1839SalVouDebe[0];
            A1842SalVouHaberD = P00B92_A1842SalVouHaberD[0];
            A1840SalVouDebeD = P00B92_A1840SalVouDebeD[0];
            A125SalCueAux = P00B92_A125SalCueAux[0];
            A864CueMon = P00B92_A864CueMon[0];
            n864CueMon = P00B92_n864CueMon[0];
            AV17SalMonCod = A124SalMonCod;
            AV18SalTipCmb = A1838SalTipCmb;
            AV21CueMon = A864CueMon;
            if ( AV20MonCod == 1 )
            {
               AV12Saldo = (decimal)(AV12Saldo+(A1839SalVouDebe-A1841SalVouHaber));
            }
            else
            {
               if ( AV21CueMon == 1 )
               {
                  AV12Saldo = (decimal)(AV12Saldo+(A1840SalVouDebeD-A1842SalVouHaberD));
               }
               else
               {
                  AV12Saldo = (decimal)(AV12Saldo+(NumberUtil.Round( (A1839SalVouDebe-A1841SalVouHaber)/ (decimal)(AV18SalTipCmb), 2)));
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
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
         P00B92_A123SalCueCod = new string[] {""} ;
         P00B92_A122SalVouMes = new short[1] ;
         P00B92_A121SalVouAno = new short[1] ;
         P00B92_A124SalMonCod = new int[1] ;
         P00B92_A1838SalTipCmb = new decimal[1] ;
         P00B92_A864CueMon = new short[1] ;
         P00B92_n864CueMon = new bool[] {false} ;
         P00B92_A1841SalVouHaber = new decimal[1] ;
         P00B92_A1839SalVouDebe = new decimal[1] ;
         P00B92_A1842SalVouHaberD = new decimal[1] ;
         P00B92_A1840SalVouDebeD = new decimal[1] ;
         P00B92_A125SalCueAux = new string[] {""} ;
         A123SalCueCod = "";
         A125SalCueAux = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.psaldocuenta__default(),
            new Object[][] {
                new Object[] {
               P00B92_A123SalCueCod, P00B92_A122SalVouMes, P00B92_A121SalVouAno, P00B92_A124SalMonCod, P00B92_A1838SalTipCmb, P00B92_A864CueMon, P00B92_n864CueMon, P00B92_A1841SalVouHaber, P00B92_A1839SalVouDebe, P00B92_A1842SalVouHaberD,
               P00B92_A1840SalVouDebeD, P00B92_A125SalCueAux
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10Ano ;
      private short AV11Mes ;
      private short AV16MesAnt ;
      private short AV19Len ;
      private short A122SalVouMes ;
      private short A121SalVouAno ;
      private short A864CueMon ;
      private short AV21CueMon ;
      private int AV20MonCod ;
      private int A124SalMonCod ;
      private int AV17SalMonCod ;
      private decimal AV12Saldo ;
      private decimal A1838SalTipCmb ;
      private decimal A1841SalVouHaber ;
      private decimal A1839SalVouDebe ;
      private decimal A1842SalVouHaberD ;
      private decimal A1840SalVouDebeD ;
      private decimal AV18SalTipCmb ;
      private string AV8CueCod ;
      private string scmdbuf ;
      private string A123SalCueCod ;
      private string A125SalCueAux ;
      private bool n864CueMon ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00B92_A123SalCueCod ;
      private short[] P00B92_A122SalVouMes ;
      private short[] P00B92_A121SalVouAno ;
      private int[] P00B92_A124SalMonCod ;
      private decimal[] P00B92_A1838SalTipCmb ;
      private short[] P00B92_A864CueMon ;
      private bool[] P00B92_n864CueMon ;
      private decimal[] P00B92_A1841SalVouHaber ;
      private decimal[] P00B92_A1839SalVouDebe ;
      private decimal[] P00B92_A1842SalVouHaberD ;
      private decimal[] P00B92_A1840SalVouDebeD ;
      private string[] P00B92_A125SalCueAux ;
      private decimal aP4_Saldo ;
   }

   public class psaldocuenta__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00B92;
          prmP00B92 = new Object[] {
          new ParDef("@AV10Ano",GXType.Int16,4,0) ,
          new ParDef("@AV16MesAnt",GXType.Int16,2,0) ,
          new ParDef("@AV19Len",GXType.Int16,2,0) ,
          new ParDef("@AV8CueCod",GXType.Char,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B92", "SELECT T1.[SalCueCod] AS SalCueCod, T1.[SalVouMes], T1.[SalVouAno], T1.[SalMonCod], T1.[SalTipCmb], T2.[CueMon], T1.[SalVouHaber], T1.[SalVouDebe], T1.[SalVouHaberD], T1.[SalVouDebeD], T1.[SalCueAux] FROM ([CBSALDOMENSUAL] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[SalCueCod]) WHERE (T1.[SalVouAno] = @AV10Ano and T1.[SalVouMes] = @AV16MesAnt) AND (SUBSTRING(T1.[SalCueCod], 1, @AV19Len) = @AV8CueCod) ORDER BY T1.[SalVouAno], T1.[SalVouMes], T1.[SalCueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B92,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                return;
       }
    }

 }

}
