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
   public class pobtienesaldoscuentacentrocosto : GXProcedure
   {
      public pobtienesaldoscuentacentrocosto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtienesaldoscuentacentrocosto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CueCod ,
                           ref string aP1_CosCod ,
                           ref short aP2_Ano ,
                           ref short aP3_Mes ,
                           out decimal aP4_SaldoDMN ,
                           out decimal aP5_SaldoHMN ,
                           out decimal aP6_SaldoDME ,
                           out decimal aP7_SaldoHME )
      {
         this.AV8CueCod = aP0_CueCod;
         this.AV17CosCod = aP1_CosCod;
         this.AV9Ano = aP2_Ano;
         this.AV10Mes = aP3_Mes;
         this.AV12SaldoDMN = 0 ;
         this.AV13SaldoHMN = 0 ;
         this.AV14SaldoDME = 0 ;
         this.AV15SaldoHME = 0 ;
         initialize();
         executePrivate();
         aP0_CueCod=this.AV8CueCod;
         aP1_CosCod=this.AV17CosCod;
         aP2_Ano=this.AV9Ano;
         aP3_Mes=this.AV10Mes;
         aP4_SaldoDMN=this.AV12SaldoDMN;
         aP5_SaldoHMN=this.AV13SaldoHMN;
         aP6_SaldoDME=this.AV14SaldoDME;
         aP7_SaldoHME=this.AV15SaldoHME;
      }

      public decimal executeUdp( ref string aP0_CueCod ,
                                 ref string aP1_CosCod ,
                                 ref short aP2_Ano ,
                                 ref short aP3_Mes ,
                                 out decimal aP4_SaldoDMN ,
                                 out decimal aP5_SaldoHMN ,
                                 out decimal aP6_SaldoDME )
      {
         execute(ref aP0_CueCod, ref aP1_CosCod, ref aP2_Ano, ref aP3_Mes, out aP4_SaldoDMN, out aP5_SaldoHMN, out aP6_SaldoDME, out aP7_SaldoHME);
         return AV15SaldoHME ;
      }

      public void executeSubmit( ref string aP0_CueCod ,
                                 ref string aP1_CosCod ,
                                 ref short aP2_Ano ,
                                 ref short aP3_Mes ,
                                 out decimal aP4_SaldoDMN ,
                                 out decimal aP5_SaldoHMN ,
                                 out decimal aP6_SaldoDME ,
                                 out decimal aP7_SaldoHME )
      {
         pobtienesaldoscuentacentrocosto objpobtienesaldoscuentacentrocosto;
         objpobtienesaldoscuentacentrocosto = new pobtienesaldoscuentacentrocosto();
         objpobtienesaldoscuentacentrocosto.AV8CueCod = aP0_CueCod;
         objpobtienesaldoscuentacentrocosto.AV17CosCod = aP1_CosCod;
         objpobtienesaldoscuentacentrocosto.AV9Ano = aP2_Ano;
         objpobtienesaldoscuentacentrocosto.AV10Mes = aP3_Mes;
         objpobtienesaldoscuentacentrocosto.AV12SaldoDMN = 0 ;
         objpobtienesaldoscuentacentrocosto.AV13SaldoHMN = 0 ;
         objpobtienesaldoscuentacentrocosto.AV14SaldoDME = 0 ;
         objpobtienesaldoscuentacentrocosto.AV15SaldoHME = 0 ;
         objpobtienesaldoscuentacentrocosto.context.SetSubmitInitialConfig(context);
         objpobtienesaldoscuentacentrocosto.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtienesaldoscuentacentrocosto);
         aP0_CueCod=this.AV8CueCod;
         aP1_CosCod=this.AV17CosCod;
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
            ((pobtienesaldoscuentacentrocosto)stateInfo).executePrivate();
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
            /* Using cursor P00BE2 */
            pr_default.execute(0, new Object[] {AV9Ano, AV11MesAnt, AV8CueCod, AV17CosCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A126TASICod = P00BE2_A126TASICod[0];
               A129VouNum = P00BE2_A129VouNum[0];
               A2077VouSts = P00BE2_A2077VouSts[0];
               A79COSCod = P00BE2_A79COSCod[0];
               n79COSCod = P00BE2_n79COSCod[0];
               A91CueCod = P00BE2_A91CueCod[0];
               A128VouMes = P00BE2_A128VouMes[0];
               A127VouAno = P00BE2_A127VouAno[0];
               A2051VouDDeb = P00BE2_A2051VouDDeb[0];
               A2055VouDHab = P00BE2_A2055VouDHab[0];
               A2052VouDDebO = P00BE2_A2052VouDDebO[0];
               A131VouDMon = P00BE2_A131VouDMon[0];
               A864CueMon = P00BE2_A864CueMon[0];
               A2056VouDHabO = P00BE2_A2056VouDHabO[0];
               A130VouDSec = P00BE2_A130VouDSec[0];
               A864CueMon = P00BE2_A864CueMon[0];
               A2077VouSts = P00BE2_A2077VouSts[0];
               AV12SaldoDMN = (decimal)(AV12SaldoDMN+A2051VouDDeb);
               AV13SaldoHMN = (decimal)(AV13SaldoHMN+A2055VouDHab);
               AV14SaldoDME = (decimal)(AV14SaldoDME+(((A864CueMon==0) ? (decimal)(0) : ((A131VouDMon==1) ? (decimal)(0) : A2052VouDDebO))));
               AV15SaldoHME = (decimal)(AV15SaldoHME+(((A864CueMon==0) ? (decimal)(0) : ((A131VouDMon==1) ? (decimal)(0) : A2056VouDHabO))));
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         context.CommitDataStores("contabilidad.pobtienesaldoscuentacentrocosto",pr_default);
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
         P00BE2_A126TASICod = new int[1] ;
         P00BE2_A129VouNum = new string[] {""} ;
         P00BE2_A2077VouSts = new short[1] ;
         P00BE2_A79COSCod = new string[] {""} ;
         P00BE2_n79COSCod = new bool[] {false} ;
         P00BE2_A91CueCod = new string[] {""} ;
         P00BE2_A128VouMes = new short[1] ;
         P00BE2_A127VouAno = new short[1] ;
         P00BE2_A2051VouDDeb = new decimal[1] ;
         P00BE2_A2055VouDHab = new decimal[1] ;
         P00BE2_A2052VouDDebO = new decimal[1] ;
         P00BE2_A131VouDMon = new int[1] ;
         P00BE2_A864CueMon = new short[1] ;
         P00BE2_A2056VouDHabO = new decimal[1] ;
         P00BE2_A130VouDSec = new int[1] ;
         A129VouNum = "";
         A79COSCod = "";
         A91CueCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.pobtienesaldoscuentacentrocosto__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.pobtienesaldoscuentacentrocosto__default(),
            new Object[][] {
                new Object[] {
               P00BE2_A126TASICod, P00BE2_A129VouNum, P00BE2_A2077VouSts, P00BE2_A79COSCod, P00BE2_n79COSCod, P00BE2_A91CueCod, P00BE2_A128VouMes, P00BE2_A127VouAno, P00BE2_A2051VouDDeb, P00BE2_A2055VouDHab,
               P00BE2_A2052VouDDebO, P00BE2_A131VouDMon, P00BE2_A864CueMon, P00BE2_A2056VouDHabO, P00BE2_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9Ano ;
      private short AV10Mes ;
      private short AV11MesAnt ;
      private short A2077VouSts ;
      private short A128VouMes ;
      private short A127VouAno ;
      private short A864CueMon ;
      private int A126TASICod ;
      private int A131VouDMon ;
      private int A130VouDSec ;
      private decimal AV12SaldoDMN ;
      private decimal AV13SaldoHMN ;
      private decimal AV14SaldoDME ;
      private decimal AV15SaldoHME ;
      private decimal A2051VouDDeb ;
      private decimal A2055VouDHab ;
      private decimal A2052VouDDebO ;
      private decimal A2056VouDHabO ;
      private string AV8CueCod ;
      private string AV17CosCod ;
      private string scmdbuf ;
      private string A129VouNum ;
      private string A79COSCod ;
      private string A91CueCod ;
      private bool n79COSCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CueCod ;
      private string aP1_CosCod ;
      private short aP2_Ano ;
      private short aP3_Mes ;
      private IDataStoreProvider pr_default ;
      private int[] P00BE2_A126TASICod ;
      private string[] P00BE2_A129VouNum ;
      private short[] P00BE2_A2077VouSts ;
      private string[] P00BE2_A79COSCod ;
      private bool[] P00BE2_n79COSCod ;
      private string[] P00BE2_A91CueCod ;
      private short[] P00BE2_A128VouMes ;
      private short[] P00BE2_A127VouAno ;
      private decimal[] P00BE2_A2051VouDDeb ;
      private decimal[] P00BE2_A2055VouDHab ;
      private decimal[] P00BE2_A2052VouDDebO ;
      private int[] P00BE2_A131VouDMon ;
      private short[] P00BE2_A864CueMon ;
      private decimal[] P00BE2_A2056VouDHabO ;
      private int[] P00BE2_A130VouDSec ;
      private decimal aP4_SaldoDMN ;
      private decimal aP5_SaldoHMN ;
      private decimal aP6_SaldoDME ;
      private decimal aP7_SaldoHME ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class pobtienesaldoscuentacentrocosto__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class pobtienesaldoscuentacentrocosto__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00BE2;
        prmP00BE2 = new Object[] {
        new ParDef("@AV9Ano",GXType.Int16,4,0) ,
        new ParDef("@AV11MesAnt",GXType.Int16,2,0) ,
        new ParDef("@AV8CueCod",GXType.NChar,15,0) ,
        new ParDef("@AV17CosCod",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00BE2", "SELECT T1.[TASICod], T1.[VouNum], T3.[VouSts], T1.[COSCod], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDDeb], T1.[VouDHab], T1.[VouDDebO], T1.[VouDMon], T2.[CueMon], T1.[VouDHabO], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV9Ano and T1.[VouMes] = @AV11MesAnt and T1.[CueCod] = @AV8CueCod) AND (T1.[COSCod] = @AV17CosCod) AND (T3.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BE2,100, GxCacheFrequency.OFF ,false,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 15);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
              ((int[]) buf[11])[0] = rslt.getInt(11);
              ((short[]) buf[12])[0] = rslt.getShort(12);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
              ((int[]) buf[14])[0] = rslt.getInt(14);
              return;
     }
  }

}

}
