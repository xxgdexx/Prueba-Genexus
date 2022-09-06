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
   public class pobtienesaldoscuentaauxiliar : GXProcedure
   {
      public pobtienesaldoscuentaauxiliar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtienesaldoscuentaauxiliar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CueCod ,
                           ref string aP1_CueCodAux ,
                           ref short aP2_Ano ,
                           ref short aP3_Mes ,
                           out decimal aP4_SaldoDMN ,
                           out decimal aP5_SaldoHMN ,
                           out decimal aP6_SaldoDME ,
                           out decimal aP7_SaldoHME )
      {
         this.AV8CueCod = aP0_CueCod;
         this.AV16CueCodAux = aP1_CueCodAux;
         this.AV9Ano = aP2_Ano;
         this.AV10Mes = aP3_Mes;
         this.AV12SaldoDMN = 0 ;
         this.AV13SaldoHMN = 0 ;
         this.AV14SaldoDME = 0 ;
         this.AV15SaldoHME = 0 ;
         initialize();
         executePrivate();
         aP0_CueCod=this.AV8CueCod;
         aP1_CueCodAux=this.AV16CueCodAux;
         aP2_Ano=this.AV9Ano;
         aP3_Mes=this.AV10Mes;
         aP4_SaldoDMN=this.AV12SaldoDMN;
         aP5_SaldoHMN=this.AV13SaldoHMN;
         aP6_SaldoDME=this.AV14SaldoDME;
         aP7_SaldoHME=this.AV15SaldoHME;
      }

      public decimal executeUdp( ref string aP0_CueCod ,
                                 ref string aP1_CueCodAux ,
                                 ref short aP2_Ano ,
                                 ref short aP3_Mes ,
                                 out decimal aP4_SaldoDMN ,
                                 out decimal aP5_SaldoHMN ,
                                 out decimal aP6_SaldoDME )
      {
         execute(ref aP0_CueCod, ref aP1_CueCodAux, ref aP2_Ano, ref aP3_Mes, out aP4_SaldoDMN, out aP5_SaldoHMN, out aP6_SaldoDME, out aP7_SaldoHME);
         return AV15SaldoHME ;
      }

      public void executeSubmit( ref string aP0_CueCod ,
                                 ref string aP1_CueCodAux ,
                                 ref short aP2_Ano ,
                                 ref short aP3_Mes ,
                                 out decimal aP4_SaldoDMN ,
                                 out decimal aP5_SaldoHMN ,
                                 out decimal aP6_SaldoDME ,
                                 out decimal aP7_SaldoHME )
      {
         pobtienesaldoscuentaauxiliar objpobtienesaldoscuentaauxiliar;
         objpobtienesaldoscuentaauxiliar = new pobtienesaldoscuentaauxiliar();
         objpobtienesaldoscuentaauxiliar.AV8CueCod = aP0_CueCod;
         objpobtienesaldoscuentaauxiliar.AV16CueCodAux = aP1_CueCodAux;
         objpobtienesaldoscuentaauxiliar.AV9Ano = aP2_Ano;
         objpobtienesaldoscuentaauxiliar.AV10Mes = aP3_Mes;
         objpobtienesaldoscuentaauxiliar.AV12SaldoDMN = 0 ;
         objpobtienesaldoscuentaauxiliar.AV13SaldoHMN = 0 ;
         objpobtienesaldoscuentaauxiliar.AV14SaldoDME = 0 ;
         objpobtienesaldoscuentaauxiliar.AV15SaldoHME = 0 ;
         objpobtienesaldoscuentaauxiliar.context.SetSubmitInitialConfig(context);
         objpobtienesaldoscuentaauxiliar.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtienesaldoscuentaauxiliar);
         aP0_CueCod=this.AV8CueCod;
         aP1_CueCodAux=this.AV16CueCodAux;
         aP2_Ano=this.AV9Ano;
         aP3_Mes=this.AV10Mes;
         aP4_SaldoDMN=this.AV12SaldoDMN;
         aP5_SaldoHMN=this.AV13SaldoHMN;
         aP6_SaldoDME=this.AV14SaldoDME;
         aP7_SaldoHME=this.AV15SaldoHME;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtienesaldoscuentaauxiliar)stateInfo).executePrivate();
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
         AV11MesAnt = (short)(AV10Mes-1);
         AV12SaldoDMN = 0.00m;
         AV13SaldoHMN = 0.00m;
         AV14SaldoDME = 0.00m;
         AV15SaldoHME = 0.00m;
         if ( ! ( AV10Mes == 0 ) )
         {
            /* Optimized group. */
            /* Using cursor P00BD2 */
            pr_default.execute(0, new Object[] {AV9Ano, AV11MesAnt, AV8CueCod, AV16CueCodAux});
            c1839SalVouDebe = P00BD2_A1839SalVouDebe[0];
            c1841SalVouHaber = P00BD2_A1841SalVouHaber[0];
            c1840SalVouDebeD = P00BD2_A1840SalVouDebeD[0];
            c1842SalVouHaberD = P00BD2_A1842SalVouHaberD[0];
            pr_default.close(0);
            AV12SaldoDMN = (decimal)(AV12SaldoDMN+c1839SalVouDebe);
            AV13SaldoHMN = (decimal)(AV13SaldoHMN+c1841SalVouHaber);
            AV14SaldoDME = (decimal)(AV14SaldoDME+c1840SalVouDebeD);
            AV15SaldoHME = (decimal)(AV15SaldoHME+c1842SalVouHaberD);
            /* End optimized group. */
         }
         context.CommitDataStores("contabilidad.pobtienesaldoscuentaauxiliar",pr_default);
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
         P00BD2_A1839SalVouDebe = new decimal[1] ;
         P00BD2_A1841SalVouHaber = new decimal[1] ;
         P00BD2_A1840SalVouDebeD = new decimal[1] ;
         P00BD2_A1842SalVouHaberD = new decimal[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.pobtienesaldoscuentaauxiliar__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.pobtienesaldoscuentaauxiliar__default(),
            new Object[][] {
                new Object[] {
               P00BD2_A1839SalVouDebe, P00BD2_A1841SalVouHaber, P00BD2_A1840SalVouDebeD, P00BD2_A1842SalVouHaberD
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9Ano ;
      private short AV10Mes ;
      private short AV11MesAnt ;
      private decimal AV12SaldoDMN ;
      private decimal AV13SaldoHMN ;
      private decimal AV14SaldoDME ;
      private decimal AV15SaldoHME ;
      private decimal c1839SalVouDebe ;
      private decimal c1841SalVouHaber ;
      private decimal c1840SalVouDebeD ;
      private decimal c1842SalVouHaberD ;
      private string AV8CueCod ;
      private string AV16CueCodAux ;
      private string scmdbuf ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CueCod ;
      private string aP1_CueCodAux ;
      private short aP2_Ano ;
      private short aP3_Mes ;
      private IDataStoreProvider pr_default ;
      private decimal[] P00BD2_A1839SalVouDebe ;
      private decimal[] P00BD2_A1841SalVouHaber ;
      private decimal[] P00BD2_A1840SalVouDebeD ;
      private decimal[] P00BD2_A1842SalVouHaberD ;
      private decimal aP4_SaldoDMN ;
      private decimal aP5_SaldoHMN ;
      private decimal aP6_SaldoDME ;
      private decimal aP7_SaldoHME ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class pobtienesaldoscuentaauxiliar__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class pobtienesaldoscuentaauxiliar__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00BD2;
        prmP00BD2 = new Object[] {
        new ParDef("@AV9Ano",GXType.Int16,4,0) ,
        new ParDef("@AV11MesAnt",GXType.Int16,2,0) ,
        new ParDef("@AV8CueCod",GXType.NChar,15,0) ,
        new ParDef("@AV16CueCodAux",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00BD2", "SELECT SUM([SalVouDebe]), SUM([SalVouHaber]), SUM([SalVouDebeD]), SUM([SalVouHaberD]) FROM [CBSALDOMENSUAL] WHERE [SalVouAno] = @AV9Ano and [SalVouMes] = @AV11MesAnt and [SalCueCod] = @AV8CueCod and [SalCueAux] = @AV16CueCodAux ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BD2,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              return;
     }
  }

}

}
