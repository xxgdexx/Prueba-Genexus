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
namespace GeneXus.Programs.almacen {
   public class pobtenersaldoproducto : GXProcedure
   {
      public pobtenersaldoproducto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtenersaldoproducto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProdCod ,
                           ref int aP1_MVAlm ,
                           ref DateTime aP2_Fecha ,
                           out decimal aP3_TStkIng ,
                           out decimal aP4_TStkSal ,
                           out decimal aP5_nSaldo )
      {
         this.AV9ProdCod = aP0_ProdCod;
         this.AV11MVAlm = aP1_MVAlm;
         this.AV8Fecha = aP2_Fecha;
         this.AV15TStkIng = 0 ;
         this.AV16TStkSal = 0 ;
         this.AV12nSaldo = 0 ;
         initialize();
         executePrivate();
         aP0_ProdCod=this.AV9ProdCod;
         aP1_MVAlm=this.AV11MVAlm;
         aP2_Fecha=this.AV8Fecha;
         aP3_TStkIng=this.AV15TStkIng;
         aP4_TStkSal=this.AV16TStkSal;
         aP5_nSaldo=this.AV12nSaldo;
      }

      public decimal executeUdp( ref string aP0_ProdCod ,
                                 ref int aP1_MVAlm ,
                                 ref DateTime aP2_Fecha ,
                                 out decimal aP3_TStkIng ,
                                 out decimal aP4_TStkSal )
      {
         execute(ref aP0_ProdCod, ref aP1_MVAlm, ref aP2_Fecha, out aP3_TStkIng, out aP4_TStkSal, out aP5_nSaldo);
         return AV12nSaldo ;
      }

      public void executeSubmit( ref string aP0_ProdCod ,
                                 ref int aP1_MVAlm ,
                                 ref DateTime aP2_Fecha ,
                                 out decimal aP3_TStkIng ,
                                 out decimal aP4_TStkSal ,
                                 out decimal aP5_nSaldo )
      {
         pobtenersaldoproducto objpobtenersaldoproducto;
         objpobtenersaldoproducto = new pobtenersaldoproducto();
         objpobtenersaldoproducto.AV9ProdCod = aP0_ProdCod;
         objpobtenersaldoproducto.AV11MVAlm = aP1_MVAlm;
         objpobtenersaldoproducto.AV8Fecha = aP2_Fecha;
         objpobtenersaldoproducto.AV15TStkIng = 0 ;
         objpobtenersaldoproducto.AV16TStkSal = 0 ;
         objpobtenersaldoproducto.AV12nSaldo = 0 ;
         objpobtenersaldoproducto.context.SetSubmitInitialConfig(context);
         objpobtenersaldoproducto.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtenersaldoproducto);
         aP0_ProdCod=this.AV9ProdCod;
         aP1_MVAlm=this.AV11MVAlm;
         aP2_Fecha=this.AV8Fecha;
         aP3_TStkIng=this.AV15TStkIng;
         aP4_TStkSal=this.AV16TStkSal;
         aP5_nSaldo=this.AV12nSaldo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtenersaldoproducto)stateInfo).executePrivate();
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
         AV15TStkIng = 0.0000m;
         AV16TStkSal = 0.0000m;
         /* Using cursor P00DL2 */
         pr_default.execute(0, new Object[] {AV8Fecha, AV11MVAlm, AV9ProdCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A28ProdCod = P00DL2_A28ProdCod[0];
            A21MvAlm = P00DL2_A21MvAlm[0];
            A25MvAFec = P00DL2_A25MvAFec[0];
            A1370MVSts = P00DL2_A1370MVSts[0];
            A1248MvADCant = P00DL2_A1248MvADCant[0];
            A14MvACod = P00DL2_A14MvACod[0];
            A13MvATip = P00DL2_A13MvATip[0];
            A30MvADItem = P00DL2_A30MvADItem[0];
            A21MvAlm = P00DL2_A21MvAlm[0];
            A25MvAFec = P00DL2_A25MvAFec[0];
            A1370MVSts = P00DL2_A1370MVSts[0];
            AV12nSaldo = (decimal)(AV12nSaldo+((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1248MvADCant : A1248MvADCant*(-1)));
            pr_default.readNext(0);
         }
         pr_default.close(0);
         context.CommitDataStores("almacen.pobtenersaldoproducto",pr_default);
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
         P00DL2_A28ProdCod = new string[] {""} ;
         P00DL2_A21MvAlm = new int[1] ;
         P00DL2_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00DL2_A1370MVSts = new string[] {""} ;
         P00DL2_A1248MvADCant = new decimal[1] ;
         P00DL2_A14MvACod = new string[] {""} ;
         P00DL2_A13MvATip = new string[] {""} ;
         P00DL2_A30MvADItem = new int[1] ;
         A28ProdCod = "";
         A25MvAFec = DateTime.MinValue;
         A1370MVSts = "";
         A14MvACod = "";
         A13MvATip = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.almacen.pobtenersaldoproducto__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.pobtenersaldoproducto__default(),
            new Object[][] {
                new Object[] {
               P00DL2_A28ProdCod, P00DL2_A21MvAlm, P00DL2_A25MvAFec, P00DL2_A1370MVSts, P00DL2_A1248MvADCant, P00DL2_A14MvACod, P00DL2_A13MvATip, P00DL2_A30MvADItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV11MVAlm ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private decimal AV15TStkIng ;
      private decimal AV16TStkSal ;
      private decimal AV12nSaldo ;
      private decimal A1248MvADCant ;
      private string AV9ProdCod ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A1370MVSts ;
      private string A14MvACod ;
      private string A13MvATip ;
      private DateTime AV8Fecha ;
      private DateTime A25MvAFec ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProdCod ;
      private int aP1_MVAlm ;
      private DateTime aP2_Fecha ;
      private IDataStoreProvider pr_default ;
      private string[] P00DL2_A28ProdCod ;
      private int[] P00DL2_A21MvAlm ;
      private DateTime[] P00DL2_A25MvAFec ;
      private string[] P00DL2_A1370MVSts ;
      private decimal[] P00DL2_A1248MvADCant ;
      private string[] P00DL2_A14MvACod ;
      private string[] P00DL2_A13MvATip ;
      private int[] P00DL2_A30MvADItem ;
      private decimal aP3_TStkIng ;
      private decimal aP4_TStkSal ;
      private decimal aP5_nSaldo ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class pobtenersaldoproducto__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class pobtenersaldoproducto__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00DL2;
        prmP00DL2 = new Object[] {
        new ParDef("@AV8Fecha",GXType.Date,8,0) ,
        new ParDef("@AV11MVAlm",GXType.Int32,6,0) ,
        new ParDef("@AV9ProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00DL2", "SELECT T1.[ProdCod], T2.[MvAlm], T2.[MvAFec], T2.[MVSts], T1.[MvADCant], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T2.[MVSts] <> 'A') AND (T2.[MvAFec] < @AV8Fecha) AND (T2.[MvAlm] = @AV11MVAlm) AND (T1.[ProdCod] = @AV9ProdCod) ORDER BY T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DL2,100, GxCacheFrequency.OFF ,false,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 12);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              return;
     }
  }

}

}
