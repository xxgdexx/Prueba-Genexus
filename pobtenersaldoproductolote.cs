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
namespace GeneXus.Programs {
   public class pobtenersaldoproductolote : GXProcedure
   {
      public pobtenersaldoproductolote( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtenersaldoproductolote( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProdCod ,
                           ref int aP1_MVAlm ,
                           ref DateTime aP2_Fecha ,
                           ref string aP3_Lote ,
                           out decimal aP4_nSaldo )
      {
         this.AV13ProdCod = aP0_ProdCod;
         this.AV11MVAlm = aP1_MVAlm;
         this.AV8Fecha = aP2_Fecha;
         this.AV9Lote = aP3_Lote;
         this.AV12nSaldo = 0 ;
         initialize();
         executePrivate();
         aP0_ProdCod=this.AV13ProdCod;
         aP1_MVAlm=this.AV11MVAlm;
         aP2_Fecha=this.AV8Fecha;
         aP3_Lote=this.AV9Lote;
         aP4_nSaldo=this.AV12nSaldo;
      }

      public decimal executeUdp( ref string aP0_ProdCod ,
                                 ref int aP1_MVAlm ,
                                 ref DateTime aP2_Fecha ,
                                 ref string aP3_Lote )
      {
         execute(ref aP0_ProdCod, ref aP1_MVAlm, ref aP2_Fecha, ref aP3_Lote, out aP4_nSaldo);
         return AV12nSaldo ;
      }

      public void executeSubmit( ref string aP0_ProdCod ,
                                 ref int aP1_MVAlm ,
                                 ref DateTime aP2_Fecha ,
                                 ref string aP3_Lote ,
                                 out decimal aP4_nSaldo )
      {
         pobtenersaldoproductolote objpobtenersaldoproductolote;
         objpobtenersaldoproductolote = new pobtenersaldoproductolote();
         objpobtenersaldoproductolote.AV13ProdCod = aP0_ProdCod;
         objpobtenersaldoproductolote.AV11MVAlm = aP1_MVAlm;
         objpobtenersaldoproductolote.AV8Fecha = aP2_Fecha;
         objpobtenersaldoproductolote.AV9Lote = aP3_Lote;
         objpobtenersaldoproductolote.AV12nSaldo = 0 ;
         objpobtenersaldoproductolote.context.SetSubmitInitialConfig(context);
         objpobtenersaldoproductolote.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtenersaldoproductolote);
         aP0_ProdCod=this.AV13ProdCod;
         aP1_MVAlm=this.AV11MVAlm;
         aP2_Fecha=this.AV8Fecha;
         aP3_Lote=this.AV9Lote;
         aP4_nSaldo=this.AV12nSaldo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtenersaldoproductolote)stateInfo).executePrivate();
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
         AV12nSaldo = 0.0000m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9Lote ,
                                              A31MVADLRef1 ,
                                              A1370MVSts ,
                                              A25MvAFec ,
                                              AV8Fecha ,
                                              A21MvAlm ,
                                              AV11MVAlm ,
                                              A28ProdCod ,
                                              AV13ProdCod } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P008Q2 */
         pr_default.execute(0, new Object[] {AV8Fecha, AV11MVAlm, AV13ProdCod, AV9Lote});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A31MVADLRef1 = P008Q2_A31MVADLRef1[0];
            A28ProdCod = P008Q2_A28ProdCod[0];
            A21MvAlm = P008Q2_A21MvAlm[0];
            A25MvAFec = P008Q2_A25MvAFec[0];
            A1370MVSts = P008Q2_A1370MVSts[0];
            A1251MVADLCant = P008Q2_A1251MVADLCant[0];
            A14MvACod = P008Q2_A14MvACod[0];
            A13MvATip = P008Q2_A13MvATip[0];
            A30MvADItem = P008Q2_A30MvADItem[0];
            A21MvAlm = P008Q2_A21MvAlm[0];
            A25MvAFec = P008Q2_A25MvAFec[0];
            A1370MVSts = P008Q2_A1370MVSts[0];
            AV12nSaldo = (decimal)(AV12nSaldo+((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1251MVADLCant : A1251MVADLCant*(-1)));
            pr_default.readNext(0);
         }
         pr_default.close(0);
         context.CommitDataStores("pobtenersaldoproductolote",pr_default);
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
         A31MVADLRef1 = "";
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         A28ProdCod = "";
         P008Q2_A31MVADLRef1 = new string[] {""} ;
         P008Q2_A28ProdCod = new string[] {""} ;
         P008Q2_A21MvAlm = new int[1] ;
         P008Q2_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008Q2_A1370MVSts = new string[] {""} ;
         P008Q2_A1251MVADLCant = new decimal[1] ;
         P008Q2_A14MvACod = new string[] {""} ;
         P008Q2_A13MvATip = new string[] {""} ;
         P008Q2_A30MvADItem = new int[1] ;
         A14MvACod = "";
         A13MvATip = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.pobtenersaldoproductolote__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pobtenersaldoproductolote__default(),
            new Object[][] {
                new Object[] {
               P008Q2_A31MVADLRef1, P008Q2_A28ProdCod, P008Q2_A21MvAlm, P008Q2_A25MvAFec, P008Q2_A1370MVSts, P008Q2_A1251MVADLCant, P008Q2_A14MvACod, P008Q2_A13MvATip, P008Q2_A30MvADItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV11MVAlm ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private decimal AV12nSaldo ;
      private decimal A1251MVADLCant ;
      private string AV13ProdCod ;
      private string scmdbuf ;
      private string A1370MVSts ;
      private string A28ProdCod ;
      private string A14MvACod ;
      private string A13MvATip ;
      private DateTime AV8Fecha ;
      private DateTime A25MvAFec ;
      private string AV9Lote ;
      private string A31MVADLRef1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProdCod ;
      private int aP1_MVAlm ;
      private DateTime aP2_Fecha ;
      private string aP3_Lote ;
      private IDataStoreProvider pr_default ;
      private string[] P008Q2_A31MVADLRef1 ;
      private string[] P008Q2_A28ProdCod ;
      private int[] P008Q2_A21MvAlm ;
      private DateTime[] P008Q2_A25MvAFec ;
      private string[] P008Q2_A1370MVSts ;
      private decimal[] P008Q2_A1251MVADLCant ;
      private string[] P008Q2_A14MvACod ;
      private string[] P008Q2_A13MvATip ;
      private int[] P008Q2_A30MvADItem ;
      private decimal aP4_nSaldo ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class pobtenersaldoproductolote__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class pobtenersaldoproductolote__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P008Q2( IGxContext context ,
                                           string AV9Lote ,
                                           string A31MVADLRef1 ,
                                           string A1370MVSts ,
                                           DateTime A25MvAFec ,
                                           DateTime AV8Fecha ,
                                           int A21MvAlm ,
                                           int AV11MVAlm ,
                                           string A28ProdCod ,
                                           string AV13ProdCod )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int1 = new short[4];
       Object[] GXv_Object2 = new Object[2];
       scmdbuf = "SELECT T1.[MVADLRef1], T1.[ProdCod], T2.[MvAlm], T2.[MvAFec], T2.[MVSts], T1.[MVADLCant], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM ([AGUIASDETLOTE] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod])";
       AddWhere(sWhereString, "(T2.[MVSts] <> 'A')");
       AddWhere(sWhereString, "(T2.[MvAFec] < @AV8Fecha)");
       AddWhere(sWhereString, "(T2.[MvAlm] = @AV11MVAlm)");
       AddWhere(sWhereString, "(T1.[ProdCod] = @AV13ProdCod)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Lote)) )
       {
          AddWhere(sWhereString, "(T1.[MVADLRef1] = @AV9Lote)");
       }
       else
       {
          GXv_int1[3] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY T1.[MvATip], T1.[MvACod]";
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
                   return conditional_P008Q2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] );
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
        Object[] prmP008Q2;
        prmP008Q2 = new Object[] {
        new ParDef("@AV8Fecha",GXType.Date,8,0) ,
        new ParDef("@AV11MVAlm",GXType.Int32,6,0) ,
        new ParDef("@AV13ProdCod",GXType.NChar,15,0) ,
        new ParDef("@AV9Lote",GXType.NVarChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("P008Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Q2,100, GxCacheFrequency.OFF ,false,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 12);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
     }
  }

}

}
