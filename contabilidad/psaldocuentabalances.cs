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
   public class psaldocuentabalances : GXProcedure
   {
      public psaldocuentabalances( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public psaldocuentabalances( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_CueCod ,
                           short aP1_Ano ,
                           short aP2_Mes ,
                           out decimal aP3_Saldo )
      {
         this.AV8CueCod = aP0_CueCod;
         this.AV10Ano = aP1_Ano;
         this.AV11Mes = aP2_Mes;
         this.AV12Saldo = 0 ;
         initialize();
         executePrivate();
         aP3_Saldo=this.AV12Saldo;
      }

      public decimal executeUdp( string aP0_CueCod ,
                                 short aP1_Ano ,
                                 short aP2_Mes )
      {
         execute(aP0_CueCod, aP1_Ano, aP2_Mes, out aP3_Saldo);
         return AV12Saldo ;
      }

      public void executeSubmit( string aP0_CueCod ,
                                 short aP1_Ano ,
                                 short aP2_Mes ,
                                 out decimal aP3_Saldo )
      {
         psaldocuentabalances objpsaldocuentabalances;
         objpsaldocuentabalances = new psaldocuentabalances();
         objpsaldocuentabalances.AV8CueCod = aP0_CueCod;
         objpsaldocuentabalances.AV10Ano = aP1_Ano;
         objpsaldocuentabalances.AV11Mes = aP2_Mes;
         objpsaldocuentabalances.AV12Saldo = 0 ;
         objpsaldocuentabalances.context.SetSubmitInitialConfig(context);
         objpsaldocuentabalances.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpsaldocuentabalances);
         aP3_Saldo=this.AV12Saldo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((psaldocuentabalances)stateInfo).executePrivate();
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
         AV16MesAnt = AV11Mes;
         /* Using cursor P00D22 */
         pr_default.execute(0, new Object[] {AV10Ano, AV16MesAnt, AV8CueCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A123SalCueCod = P00D22_A123SalCueCod[0];
            A122SalVouMes = P00D22_A122SalVouMes[0];
            A121SalVouAno = P00D22_A121SalVouAno[0];
            A124SalMonCod = P00D22_A124SalMonCod[0];
            A1838SalTipCmb = P00D22_A1838SalTipCmb[0];
            A1841SalVouHaber = P00D22_A1841SalVouHaber[0];
            A1839SalVouDebe = P00D22_A1839SalVouDebe[0];
            A125SalCueAux = P00D22_A125SalCueAux[0];
            AV17SalMonCod = A124SalMonCod;
            AV18SalTipCmb = A1838SalTipCmb;
            AV12Saldo = (decimal)(AV12Saldo+((A1839SalVouDebe-A1841SalVouHaber)));
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
         P00D22_A123SalCueCod = new string[] {""} ;
         P00D22_A122SalVouMes = new short[1] ;
         P00D22_A121SalVouAno = new short[1] ;
         P00D22_A124SalMonCod = new int[1] ;
         P00D22_A1838SalTipCmb = new decimal[1] ;
         P00D22_A1841SalVouHaber = new decimal[1] ;
         P00D22_A1839SalVouDebe = new decimal[1] ;
         P00D22_A125SalCueAux = new string[] {""} ;
         A123SalCueCod = "";
         A125SalCueAux = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.psaldocuentabalances__default(),
            new Object[][] {
                new Object[] {
               P00D22_A123SalCueCod, P00D22_A122SalVouMes, P00D22_A121SalVouAno, P00D22_A124SalMonCod, P00D22_A1838SalTipCmb, P00D22_A1841SalVouHaber, P00D22_A1839SalVouDebe, P00D22_A125SalCueAux
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10Ano ;
      private short AV11Mes ;
      private short AV16MesAnt ;
      private short A122SalVouMes ;
      private short A121SalVouAno ;
      private int A124SalMonCod ;
      private int AV17SalMonCod ;
      private decimal AV12Saldo ;
      private decimal A1838SalTipCmb ;
      private decimal A1841SalVouHaber ;
      private decimal A1839SalVouDebe ;
      private decimal AV18SalTipCmb ;
      private string AV8CueCod ;
      private string scmdbuf ;
      private string A123SalCueCod ;
      private string A125SalCueAux ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00D22_A123SalCueCod ;
      private short[] P00D22_A122SalVouMes ;
      private short[] P00D22_A121SalVouAno ;
      private int[] P00D22_A124SalMonCod ;
      private decimal[] P00D22_A1838SalTipCmb ;
      private decimal[] P00D22_A1841SalVouHaber ;
      private decimal[] P00D22_A1839SalVouDebe ;
      private string[] P00D22_A125SalCueAux ;
      private decimal aP3_Saldo ;
   }

   public class psaldocuentabalances__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00D22;
          prmP00D22 = new Object[] {
          new ParDef("@AV10Ano",GXType.Int16,4,0) ,
          new ParDef("@AV16MesAnt",GXType.Int16,2,0) ,
          new ParDef("@AV8CueCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D22", "SELECT [SalCueCod], [SalVouMes], [SalVouAno], [SalMonCod], [SalTipCmb], [SalVouHaber], [SalVouDebe], [SalCueAux] FROM [CBSALDOMENSUAL] WHERE [SalVouAno] = @AV10Ano and [SalVouMes] = @AV16MesAnt and [SalCueCod] = @AV8CueCod ORDER BY [SalVouAno], [SalVouMes], [SalCueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D22,100, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                return;
       }
    }

 }

}
