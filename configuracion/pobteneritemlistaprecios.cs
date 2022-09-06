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
   public class pobteneritemlistaprecios : GXProcedure
   {
      public pobteneritemlistaprecios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobteneritemlistaprecios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TiplCod ,
                           out int aP1_Max )
      {
         this.AV8TiplCod = aP0_TiplCod;
         this.AV9Max = 0 ;
         initialize();
         executePrivate();
         aP0_TiplCod=this.AV8TiplCod;
         aP1_Max=this.AV9Max;
      }

      public int executeUdp( ref int aP0_TiplCod )
      {
         execute(ref aP0_TiplCod, out aP1_Max);
         return AV9Max ;
      }

      public void executeSubmit( ref int aP0_TiplCod ,
                                 out int aP1_Max )
      {
         pobteneritemlistaprecios objpobteneritemlistaprecios;
         objpobteneritemlistaprecios = new pobteneritemlistaprecios();
         objpobteneritemlistaprecios.AV8TiplCod = aP0_TiplCod;
         objpobteneritemlistaprecios.AV9Max = 0 ;
         objpobteneritemlistaprecios.context.SetSubmitInitialConfig(context);
         objpobteneritemlistaprecios.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobteneritemlistaprecios);
         aP0_TiplCod=this.AV8TiplCod;
         aP1_Max=this.AV9Max;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobteneritemlistaprecios)stateInfo).executePrivate();
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
         AV9Max = 0;
         /* Using cursor P004N2 */
         pr_default.execute(0, new Object[] {AV8TiplCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A202TipLCod = P004N2_A202TipLCod[0];
            A1651PreLis = P004N2_A1651PreLis[0];
            A203TipLItem = P004N2_A203TipLItem[0];
            AV9Max = A203TipLItem;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV9Max = (int)(AV9Max+1);
         context.CommitDataStores("configuracion.pobteneritemlistaprecios",pr_default);
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
         P004N2_A202TipLCod = new int[1] ;
         P004N2_A1651PreLis = new decimal[1] ;
         P004N2_A203TipLItem = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.pobteneritemlistaprecios__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.pobteneritemlistaprecios__default(),
            new Object[][] {
                new Object[] {
               P004N2_A202TipLCod, P004N2_A1651PreLis, P004N2_A203TipLItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8TiplCod ;
      private int AV9Max ;
      private int A202TipLCod ;
      private int A203TipLItem ;
      private decimal A1651PreLis ;
      private string scmdbuf ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TiplCod ;
      private IDataStoreProvider pr_default ;
      private int[] P004N2_A202TipLCod ;
      private decimal[] P004N2_A1651PreLis ;
      private int[] P004N2_A203TipLItem ;
      private int aP1_Max ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class pobteneritemlistaprecios__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class pobteneritemlistaprecios__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP004N2;
        prmP004N2 = new Object[] {
        new ParDef("@AV8TiplCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("P004N2", "SELECT [TipLCod], [PreLis], [TipLItem] FROM [CLISTAPRECIOS] WHERE [TipLCod] = @AV8TiplCod ORDER BY [TipLCod], [TipLItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004N2,100, GxCacheFrequency.OFF ,false,false )
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
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
     }
  }

}

}
