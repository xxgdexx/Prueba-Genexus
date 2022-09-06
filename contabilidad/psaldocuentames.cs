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
   public class psaldocuentames : GXProcedure
   {
      public psaldocuentames( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public psaldocuentames( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_CueCod ,
                           short aP1_Ano ,
                           short aP2_Mes ,
                           out decimal aP3_TDebe ,
                           out decimal aP4_THaber ,
                           out decimal aP5_Saldo )
      {
         this.AV8CueCod = aP0_CueCod;
         this.AV10Ano = aP1_Ano;
         this.AV11Mes = aP2_Mes;
         this.AV17TDebe = 0 ;
         this.AV18THaber = 0 ;
         this.AV12Saldo = 0 ;
         initialize();
         executePrivate();
         aP3_TDebe=this.AV17TDebe;
         aP4_THaber=this.AV18THaber;
         aP5_Saldo=this.AV12Saldo;
      }

      public decimal executeUdp( string aP0_CueCod ,
                                 short aP1_Ano ,
                                 short aP2_Mes ,
                                 out decimal aP3_TDebe ,
                                 out decimal aP4_THaber )
      {
         execute(aP0_CueCod, aP1_Ano, aP2_Mes, out aP3_TDebe, out aP4_THaber, out aP5_Saldo);
         return AV12Saldo ;
      }

      public void executeSubmit( string aP0_CueCod ,
                                 short aP1_Ano ,
                                 short aP2_Mes ,
                                 out decimal aP3_TDebe ,
                                 out decimal aP4_THaber ,
                                 out decimal aP5_Saldo )
      {
         psaldocuentames objpsaldocuentames;
         objpsaldocuentames = new psaldocuentames();
         objpsaldocuentames.AV8CueCod = aP0_CueCod;
         objpsaldocuentames.AV10Ano = aP1_Ano;
         objpsaldocuentames.AV11Mes = aP2_Mes;
         objpsaldocuentames.AV17TDebe = 0 ;
         objpsaldocuentames.AV18THaber = 0 ;
         objpsaldocuentames.AV12Saldo = 0 ;
         objpsaldocuentames.context.SetSubmitInitialConfig(context);
         objpsaldocuentames.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpsaldocuentames);
         aP3_TDebe=this.AV17TDebe;
         aP4_THaber=this.AV18THaber;
         aP5_Saldo=this.AV12Saldo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((psaldocuentames)stateInfo).executePrivate();
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
         AV17TDebe = 0.00m;
         AV18THaber = 0.00m;
         /* Using cursor P00B32 */
         pr_default.execute(0, new Object[] {AV10Ano, AV11Mes, AV8CueCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A123SalCueCod = P00B32_A123SalCueCod[0];
            A122SalVouMes = P00B32_A122SalVouMes[0];
            A121SalVouAno = P00B32_A121SalVouAno[0];
            A124SalMonCod = P00B32_A124SalMonCod[0];
            A1838SalTipCmb = P00B32_A1838SalTipCmb[0];
            A1839SalVouDebe = P00B32_A1839SalVouDebe[0];
            A1841SalVouHaber = P00B32_A1841SalVouHaber[0];
            A125SalCueAux = P00B32_A125SalCueAux[0];
            AV19SalMonCod = A124SalMonCod;
            AV20SalTipCmb = A1838SalTipCmb;
            AV17TDebe = (decimal)(AV17TDebe+A1839SalVouDebe);
            AV18THaber = (decimal)(AV18THaber+A1841SalVouHaber);
            AV12Saldo = (decimal)(AV12Saldo+(A1839SalVouDebe-A1841SalVouHaber));
            pr_default.readNext(0);
         }
         pr_default.close(0);
         context.CommitDataStores("contabilidad.psaldocuentames",pr_default);
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
         P00B32_A123SalCueCod = new string[] {""} ;
         P00B32_A122SalVouMes = new short[1] ;
         P00B32_A121SalVouAno = new short[1] ;
         P00B32_A124SalMonCod = new int[1] ;
         P00B32_A1838SalTipCmb = new decimal[1] ;
         P00B32_A1839SalVouDebe = new decimal[1] ;
         P00B32_A1841SalVouHaber = new decimal[1] ;
         P00B32_A125SalCueAux = new string[] {""} ;
         A123SalCueCod = "";
         A125SalCueAux = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.psaldocuentames__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.psaldocuentames__default(),
            new Object[][] {
                new Object[] {
               P00B32_A123SalCueCod, P00B32_A122SalVouMes, P00B32_A121SalVouAno, P00B32_A124SalMonCod, P00B32_A1838SalTipCmb, P00B32_A1839SalVouDebe, P00B32_A1841SalVouHaber, P00B32_A125SalCueAux
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10Ano ;
      private short AV11Mes ;
      private short A122SalVouMes ;
      private short A121SalVouAno ;
      private int A124SalMonCod ;
      private int AV19SalMonCod ;
      private decimal AV17TDebe ;
      private decimal AV18THaber ;
      private decimal AV12Saldo ;
      private decimal A1838SalTipCmb ;
      private decimal A1839SalVouDebe ;
      private decimal A1841SalVouHaber ;
      private decimal AV20SalTipCmb ;
      private string AV8CueCod ;
      private string scmdbuf ;
      private string A123SalCueCod ;
      private string A125SalCueAux ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00B32_A123SalCueCod ;
      private short[] P00B32_A122SalVouMes ;
      private short[] P00B32_A121SalVouAno ;
      private int[] P00B32_A124SalMonCod ;
      private decimal[] P00B32_A1838SalTipCmb ;
      private decimal[] P00B32_A1839SalVouDebe ;
      private decimal[] P00B32_A1841SalVouHaber ;
      private string[] P00B32_A125SalCueAux ;
      private decimal aP3_TDebe ;
      private decimal aP4_THaber ;
      private decimal aP5_Saldo ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class psaldocuentames__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class psaldocuentames__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00B32;
        prmP00B32 = new Object[] {
        new ParDef("@AV10Ano",GXType.Int16,4,0) ,
        new ParDef("@AV11Mes",GXType.Int16,2,0) ,
        new ParDef("@AV8CueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00B32", "SELECT [SalCueCod], [SalVouMes], [SalVouAno], [SalMonCod], [SalTipCmb], [SalVouDebe], [SalVouHaber], [SalCueAux] FROM [CBSALDOMENSUAL] WHERE [SalVouAno] = @AV10Ano and [SalVouMes] = @AV11Mes and [SalCueCod] = @AV8CueCod ORDER BY [SalVouAno], [SalVouMes], [SalCueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B32,100, GxCacheFrequency.OFF ,false,false )
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
