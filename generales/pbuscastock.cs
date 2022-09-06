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
namespace GeneXus.Programs.generales {
   public class pbuscastock : GXProcedure
   {
      public pbuscastock( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pbuscastock( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_AlmCod ,
                           string aP1_ProdCod ,
                           out decimal aP2_Saldo )
      {
         this.AV8AlmCod = aP0_AlmCod;
         this.AV9ProdCod = aP1_ProdCod;
         this.AV10Saldo = 0 ;
         initialize();
         executePrivate();
         aP2_Saldo=this.AV10Saldo;
      }

      public decimal executeUdp( int aP0_AlmCod ,
                                 string aP1_ProdCod )
      {
         execute(aP0_AlmCod, aP1_ProdCod, out aP2_Saldo);
         return AV10Saldo ;
      }

      public void executeSubmit( int aP0_AlmCod ,
                                 string aP1_ProdCod ,
                                 out decimal aP2_Saldo )
      {
         pbuscastock objpbuscastock;
         objpbuscastock = new pbuscastock();
         objpbuscastock.AV8AlmCod = aP0_AlmCod;
         objpbuscastock.AV9ProdCod = aP1_ProdCod;
         objpbuscastock.AV10Saldo = 0 ;
         objpbuscastock.context.SetSubmitInitialConfig(context);
         objpbuscastock.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpbuscastock);
         aP2_Saldo=this.AV10Saldo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pbuscastock)stateInfo).executePrivate();
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
         AV10Saldo = 0.0000m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8AlmCod ,
                                              A63AlmCod ,
                                              A28ProdCod ,
                                              AV9ProdCod ,
                                              A1158LinStk } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P008K2 */
         pr_default.execute(0, new Object[] {AV9ProdCod, AV8AlmCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A52LinCod = P008K2_A52LinCod[0];
            A1158LinStk = P008K2_A1158LinStk[0];
            A28ProdCod = P008K2_A28ProdCod[0];
            A63AlmCod = P008K2_A63AlmCod[0];
            A1882StkSal = P008K2_A1882StkSal[0];
            A1881StkIng = P008K2_A1881StkIng[0];
            A52LinCod = P008K2_A52LinCod[0];
            A1158LinStk = P008K2_A1158LinStk[0];
            A1880StkAct = (decimal)(A1881StkIng-A1882StkSal);
            AV10Saldo = (decimal)(AV10Saldo+A1880StkAct);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         context.CommitDataStores("generales.pbuscastock",pr_default);
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
         A28ProdCod = "";
         P008K2_A52LinCod = new int[1] ;
         P008K2_A1158LinStk = new short[1] ;
         P008K2_A28ProdCod = new string[] {""} ;
         P008K2_A63AlmCod = new int[1] ;
         P008K2_A1882StkSal = new decimal[1] ;
         P008K2_A1881StkIng = new decimal[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.generales.pbuscastock__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.generales.pbuscastock__default(),
            new Object[][] {
                new Object[] {
               P008K2_A52LinCod, P008K2_A1158LinStk, P008K2_A28ProdCod, P008K2_A63AlmCod, P008K2_A1882StkSal, P008K2_A1881StkIng
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1158LinStk ;
      private int AV8AlmCod ;
      private int A63AlmCod ;
      private int A52LinCod ;
      private decimal AV10Saldo ;
      private decimal A1882StkSal ;
      private decimal A1881StkIng ;
      private decimal A1880StkAct ;
      private string AV9ProdCod ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P008K2_A52LinCod ;
      private short[] P008K2_A1158LinStk ;
      private string[] P008K2_A28ProdCod ;
      private int[] P008K2_A63AlmCod ;
      private decimal[] P008K2_A1882StkSal ;
      private decimal[] P008K2_A1881StkIng ;
      private decimal aP2_Saldo ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class pbuscastock__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class pbuscastock__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P008K2( IGxContext context ,
                                           int AV8AlmCod ,
                                           int A63AlmCod ,
                                           string A28ProdCod ,
                                           string AV9ProdCod ,
                                           short A1158LinStk )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int1 = new short[2];
       Object[] GXv_Object2 = new Object[2];
       scmdbuf = "SELECT T2.[LinCod], T3.[LinStk], T1.[ProdCod], T1.[AlmCod], T1.[StkSal], T1.[StkIng] FROM (([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod])";
       AddWhere(sWhereString, "(T1.[ProdCod] = @AV9ProdCod)");
       AddWhere(sWhereString, "(T3.[LinStk] = 1)");
       if ( ! ( AV8AlmCod == 99 ) )
       {
          AddWhere(sWhereString, "(T1.[AlmCod] = @AV8AlmCod)");
       }
       else
       {
          GXv_int1[1] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY T1.[AlmCod], T1.[ProdCod]";
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
             case 0 :
                   return conditional_P008K2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

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
        Object[] prmP008K2;
        prmP008K2 = new Object[] {
        new ParDef("@AV9ProdCod",GXType.NChar,15,0) ,
        new ParDef("@AV8AlmCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("P008K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008K2,100, GxCacheFrequency.OFF ,false,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              return;
     }
  }

}

}
