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
namespace GeneXus.Programs.configuracion {
   public class poptienetipocambio : GXProcedure
   {
      public poptienetipocambio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poptienetipocambio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_MonCod ,
                           ref DateTime aP1_Fecha ,
                           ref string aP2_Tipo ,
                           out decimal aP3_Cambio )
      {
         this.AV8MonCod = aP0_MonCod;
         this.AV9Fecha = aP1_Fecha;
         this.AV10Tipo = aP2_Tipo;
         this.AV11Cambio = 0 ;
         initialize();
         executePrivate();
         aP0_MonCod=this.AV8MonCod;
         aP1_Fecha=this.AV9Fecha;
         aP2_Tipo=this.AV10Tipo;
         aP3_Cambio=this.AV11Cambio;
      }

      public decimal executeUdp( ref int aP0_MonCod ,
                                 ref DateTime aP1_Fecha ,
                                 ref string aP2_Tipo )
      {
         execute(ref aP0_MonCod, ref aP1_Fecha, ref aP2_Tipo, out aP3_Cambio);
         return AV11Cambio ;
      }

      public void executeSubmit( ref int aP0_MonCod ,
                                 ref DateTime aP1_Fecha ,
                                 ref string aP2_Tipo ,
                                 out decimal aP3_Cambio )
      {
         poptienetipocambio objpoptienetipocambio;
         objpoptienetipocambio = new poptienetipocambio();
         objpoptienetipocambio.AV8MonCod = aP0_MonCod;
         objpoptienetipocambio.AV9Fecha = aP1_Fecha;
         objpoptienetipocambio.AV10Tipo = aP2_Tipo;
         objpoptienetipocambio.AV11Cambio = 0 ;
         objpoptienetipocambio.context.SetSubmitInitialConfig(context);
         objpoptienetipocambio.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpoptienetipocambio);
         aP0_MonCod=this.AV8MonCod;
         aP1_Fecha=this.AV9Fecha;
         aP2_Tipo=this.AV10Tipo;
         aP3_Cambio=this.AV11Cambio;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((poptienetipocambio)stateInfo).executePrivate();
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
         AV14GXLvl1 = 0;
         /* Using cursor P007V2 */
         pr_default.execute(0, new Object[] {AV8MonCod, AV9Fecha});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A308TipFech = P007V2_A308TipFech[0];
            A307TipMonCod = P007V2_A307TipMonCod[0];
            A1907TipCompra = P007V2_A1907TipCompra[0];
            A1920TipVenta = P007V2_A1920TipVenta[0];
            AV14GXLvl1 = 1;
            if ( StringUtil.StrCmp(AV10Tipo, "C") == 0 )
            {
               AV11Cambio = A1907TipCompra;
            }
            else
            {
               AV11Cambio = A1920TipVenta;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV14GXLvl1 == 0 )
         {
            AV11Cambio = 1.00000m;
         }
         context.CommitDataStores("configuracion.poptienetipocambio",pr_default);
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
         P007V2_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         P007V2_A307TipMonCod = new int[1] ;
         P007V2_A1907TipCompra = new decimal[1] ;
         P007V2_A1920TipVenta = new decimal[1] ;
         A308TipFech = DateTime.MinValue;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.poptienetipocambio__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.poptienetipocambio__default(),
            new Object[][] {
                new Object[] {
               P007V2_A308TipFech, P007V2_A307TipMonCod, P007V2_A1907TipCompra, P007V2_A1920TipVenta
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14GXLvl1 ;
      private int AV8MonCod ;
      private int A307TipMonCod ;
      private decimal AV11Cambio ;
      private decimal A1907TipCompra ;
      private decimal A1920TipVenta ;
      private string AV10Tipo ;
      private string scmdbuf ;
      private DateTime AV9Fecha ;
      private DateTime A308TipFech ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_MonCod ;
      private DateTime aP1_Fecha ;
      private string aP2_Tipo ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P007V2_A308TipFech ;
      private int[] P007V2_A307TipMonCod ;
      private decimal[] P007V2_A1907TipCompra ;
      private decimal[] P007V2_A1920TipVenta ;
      private decimal aP3_Cambio ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class poptienetipocambio__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poptienetipocambio__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP007V2;
        prmP007V2 = new Object[] {
        new ParDef("@AV8MonCod",GXType.Int32,6,0) ,
        new ParDef("@AV9Fecha",GXType.Date,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("P007V2", "SELECT [TipFech], [TipMonCod], [TipCompra], [TipVenta] FROM [CTIPOCAMBIO] WHERE [TipMonCod] = @AV8MonCod and [TipFech] = @AV9Fecha ORDER BY [TipMonCod], [TipFech] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007V2,1, GxCacheFrequency.OFF ,false,true )
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
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              return;
     }
  }

}

}
