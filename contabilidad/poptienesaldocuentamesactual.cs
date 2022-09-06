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
   public class poptienesaldocuentamesactual : GXProcedure
   {
      public poptienesaldocuentamesactual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poptienesaldocuentamesactual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref string aP2_CueCod ,
                           ref string aP3_CueDAxu ,
                           ref string aP4_CosCod ,
                           out decimal aP5_SaldoDMN ,
                           out decimal aP6_SaldoHMN )
      {
         this.AV9Ano = aP0_Ano;
         this.AV11Mes = aP1_Mes;
         this.AV12CueCod = aP2_CueCod;
         this.AV8CueDAxu = aP3_CueDAxu;
         this.AV15CosCod = aP4_CosCod;
         this.AV13SaldoDMN = 0 ;
         this.AV14SaldoHMN = 0 ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV9Ano;
         aP1_Mes=this.AV11Mes;
         aP2_CueCod=this.AV12CueCod;
         aP3_CueDAxu=this.AV8CueDAxu;
         aP4_CosCod=this.AV15CosCod;
         aP5_SaldoDMN=this.AV13SaldoDMN;
         aP6_SaldoHMN=this.AV14SaldoHMN;
      }

      public decimal executeUdp( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_CueCod ,
                                 ref string aP3_CueDAxu ,
                                 ref string aP4_CosCod ,
                                 out decimal aP5_SaldoDMN )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_CueCod, ref aP3_CueDAxu, ref aP4_CosCod, out aP5_SaldoDMN, out aP6_SaldoHMN);
         return AV14SaldoHMN ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_CueCod ,
                                 ref string aP3_CueDAxu ,
                                 ref string aP4_CosCod ,
                                 out decimal aP5_SaldoDMN ,
                                 out decimal aP6_SaldoHMN )
      {
         poptienesaldocuentamesactual objpoptienesaldocuentamesactual;
         objpoptienesaldocuentamesactual = new poptienesaldocuentamesactual();
         objpoptienesaldocuentamesactual.AV9Ano = aP0_Ano;
         objpoptienesaldocuentamesactual.AV11Mes = aP1_Mes;
         objpoptienesaldocuentamesactual.AV12CueCod = aP2_CueCod;
         objpoptienesaldocuentamesactual.AV8CueDAxu = aP3_CueDAxu;
         objpoptienesaldocuentamesactual.AV15CosCod = aP4_CosCod;
         objpoptienesaldocuentamesactual.AV13SaldoDMN = 0 ;
         objpoptienesaldocuentamesactual.AV14SaldoHMN = 0 ;
         objpoptienesaldocuentamesactual.context.SetSubmitInitialConfig(context);
         objpoptienesaldocuentamesactual.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpoptienesaldocuentamesactual);
         aP0_Ano=this.AV9Ano;
         aP1_Mes=this.AV11Mes;
         aP2_CueCod=this.AV12CueCod;
         aP3_CueDAxu=this.AV8CueDAxu;
         aP4_CosCod=this.AV15CosCod;
         aP5_SaldoDMN=this.AV13SaldoDMN;
         aP6_SaldoHMN=this.AV14SaldoHMN;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((poptienesaldocuentamesactual)stateInfo).executePrivate();
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
         AV10MesAnt = (short)(AV11Mes-1);
         AV13SaldoDMN = 0.00m;
         AV14SaldoHMN = 0.00m;
         if ( ! ( AV11Mes == 0 ) )
         {
            /* Optimized group. */
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8CueDAxu ,
                                                 A125SalCueAux } ,
                                                 new int[]{
                                                 }
            });
            /* Using cursor P00B62 */
            pr_default.execute(0, new Object[] {AV9Ano, AV10MesAnt, AV12CueCod, AV8CueDAxu});
            c1839SalVouDebe = P00B62_A1839SalVouDebe[0];
            c1841SalVouHaber = P00B62_A1841SalVouHaber[0];
            pr_default.close(0);
            AV13SaldoDMN = (decimal)(AV13SaldoDMN+c1839SalVouDebe);
            AV14SaldoHMN = (decimal)(AV14SaldoHMN+c1841SalVouHaber);
            /* End optimized group. */
         }
         /* Optimized group. */
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV15CosCod ,
                                              AV8CueDAxu ,
                                              A79COSCod ,
                                              A133CueCodAux } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00B63 */
         pr_default.execute(1, new Object[] {AV9Ano, AV11Mes, AV12CueCod, AV15CosCod, AV8CueDAxu});
         c2051VouDDeb = P00B63_A2051VouDDeb[0];
         c2055VouDHab = P00B63_A2055VouDHab[0];
         pr_default.close(1);
         AV13SaldoDMN = (decimal)(AV13SaldoDMN+c2051VouDDeb);
         AV14SaldoHMN = (decimal)(AV14SaldoHMN+c2055VouDHab);
         /* End optimized group. */
         context.CommitDataStores("contabilidad.poptienesaldocuentamesactual",pr_default);
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
         A125SalCueAux = "";
         P00B62_A1839SalVouDebe = new decimal[1] ;
         P00B62_A1841SalVouHaber = new decimal[1] ;
         A79COSCod = "";
         A133CueCodAux = "";
         P00B63_A2051VouDDeb = new decimal[1] ;
         P00B63_A2055VouDHab = new decimal[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.poptienesaldocuentamesactual__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.poptienesaldocuentamesactual__default(),
            new Object[][] {
                new Object[] {
               P00B62_A1839SalVouDebe, P00B62_A1841SalVouHaber
               }
               , new Object[] {
               P00B63_A2051VouDDeb, P00B63_A2055VouDHab
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9Ano ;
      private short AV11Mes ;
      private short AV10MesAnt ;
      private decimal AV13SaldoDMN ;
      private decimal AV14SaldoHMN ;
      private decimal c1839SalVouDebe ;
      private decimal c1841SalVouHaber ;
      private decimal c2051VouDDeb ;
      private decimal c2055VouDHab ;
      private string AV12CueCod ;
      private string AV8CueDAxu ;
      private string AV15CosCod ;
      private string scmdbuf ;
      private string A125SalCueAux ;
      private string A79COSCod ;
      private string A133CueCodAux ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_CueCod ;
      private string aP3_CueDAxu ;
      private string aP4_CosCod ;
      private IDataStoreProvider pr_default ;
      private decimal[] P00B62_A1839SalVouDebe ;
      private decimal[] P00B62_A1841SalVouHaber ;
      private decimal[] P00B63_A2051VouDDeb ;
      private decimal[] P00B63_A2055VouDHab ;
      private decimal aP5_SaldoDMN ;
      private decimal aP6_SaldoHMN ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class poptienesaldocuentamesactual__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poptienesaldocuentamesactual__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P00B62( IGxContext context ,
                                           string AV8CueDAxu ,
                                           string A125SalCueAux )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int1 = new short[4];
       Object[] GXv_Object2 = new Object[2];
       scmdbuf = "SELECT SUM([SalVouDebe]), SUM([SalVouHaber]) FROM [CBSALDOMENSUAL]";
       AddWhere(sWhereString, "([SalVouAno] = @AV9Ano and [SalVouMes] = @AV10MesAnt and [SalCueCod] = @AV12CueCod)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CueDAxu)) )
       {
          AddWhere(sWhereString, "([SalCueAux] = @AV8CueDAxu)");
       }
       else
       {
          GXv_int1[3] = 1;
       }
       scmdbuf += sWhereString;
       GXv_Object2[0] = scmdbuf;
       GXv_Object2[1] = GXv_int1;
       return GXv_Object2 ;
    }

    protected Object[] conditional_P00B63( IGxContext context ,
                                           string AV15CosCod ,
                                           string AV8CueDAxu ,
                                           string A79COSCod ,
                                           string A133CueCodAux )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int3 = new short[5];
       Object[] GXv_Object4 = new Object[2];
       scmdbuf = "SELECT SUM(T1.[VouDDeb]), SUM(T1.[VouDHab]) FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
       AddWhere(sWhereString, "(T1.[VouAno] = @AV9Ano and T1.[VouMes] = @AV11Mes and T1.[CueCod] = @AV12CueCod)");
       AddWhere(sWhereString, "(T2.[VouSts] = 1)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15CosCod)) )
       {
          AddWhere(sWhereString, "(T1.[COSCod] = @AV15CosCod)");
       }
       else
       {
          GXv_int3[3] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CueDAxu)) )
       {
          AddWhere(sWhereString, "(T1.[CueCodAux] = @AV8CueDAxu)");
       }
       else
       {
          GXv_int3[4] = 1;
       }
       scmdbuf += sWhereString;
       GXv_Object4[0] = scmdbuf;
       GXv_Object4[1] = GXv_int3;
       return GXv_Object4 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_P00B62(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
             case 1 :
                   return conditional_P00B63(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00B62;
        prmP00B62 = new Object[] {
        new ParDef("@AV9Ano",GXType.Int16,4,0) ,
        new ParDef("@AV10MesAnt",GXType.Int16,2,0) ,
        new ParDef("@AV12CueCod",GXType.NChar,15,0) ,
        new ParDef("@AV8CueDAxu",GXType.NChar,20,0)
        };
        Object[] prmP00B63;
        prmP00B63 = new Object[] {
        new ParDef("@AV9Ano",GXType.Int16,4,0) ,
        new ParDef("@AV11Mes",GXType.Int16,2,0) ,
        new ParDef("@AV12CueCod",GXType.NChar,15,0) ,
        new ParDef("@AV15CosCod",GXType.NChar,10,0) ,
        new ParDef("@AV8CueDAxu",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00B62", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B62,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00B63", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B63,1, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
     }
  }

}

}
