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
   public class pobtienemonedabanco : GXProcedure
   {
      public pobtienemonedabanco( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtienemonedabanco( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_BanCod ,
                           string aP1_BanCuenta ,
                           out int aP2_MonCod )
      {
         this.AV11BanCod = aP0_BanCod;
         this.AV12BanCuenta = aP1_BanCuenta;
         this.AV8MonCod = 0 ;
         initialize();
         executePrivate();
         aP2_MonCod=this.AV8MonCod;
      }

      public int executeUdp( int aP0_BanCod ,
                             string aP1_BanCuenta )
      {
         execute(aP0_BanCod, aP1_BanCuenta, out aP2_MonCod);
         return AV8MonCod ;
      }

      public void executeSubmit( int aP0_BanCod ,
                                 string aP1_BanCuenta ,
                                 out int aP2_MonCod )
      {
         pobtienemonedabanco objpobtienemonedabanco;
         objpobtienemonedabanco = new pobtienemonedabanco();
         objpobtienemonedabanco.AV11BanCod = aP0_BanCod;
         objpobtienemonedabanco.AV12BanCuenta = aP1_BanCuenta;
         objpobtienemonedabanco.AV8MonCod = 0 ;
         objpobtienemonedabanco.context.SetSubmitInitialConfig(context);
         objpobtienemonedabanco.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtienemonedabanco);
         aP2_MonCod=this.AV8MonCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtienemonedabanco)stateInfo).executePrivate();
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
         /* Using cursor P00A12 */
         pr_default.execute(0, new Object[] {AV11BanCod, AV12BanCuenta});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A377CBCod = P00A12_A377CBCod[0];
            A372BanCod = P00A12_A372BanCod[0];
            A180MonCod = P00A12_A180MonCod[0];
            AV8MonCod = A180MonCod;
            /* Exiting from a For First loop. */
            if (true) break;
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
         P00A12_A377CBCod = new string[] {""} ;
         P00A12_A372BanCod = new int[1] ;
         P00A12_A180MonCod = new int[1] ;
         A377CBCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.generales.pobtienemonedabanco__default(),
            new Object[][] {
                new Object[] {
               P00A12_A377CBCod, P00A12_A372BanCod, P00A12_A180MonCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV11BanCod ;
      private int AV8MonCod ;
      private int A372BanCod ;
      private int A180MonCod ;
      private string AV12BanCuenta ;
      private string scmdbuf ;
      private string A377CBCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00A12_A377CBCod ;
      private int[] P00A12_A372BanCod ;
      private int[] P00A12_A180MonCod ;
      private int aP2_MonCod ;
   }

   public class pobtienemonedabanco__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00A12;
          prmP00A12 = new Object[] {
          new ParDef("@AV11BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV12BanCuenta",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A12", "SELECT [CBCod], [BanCod], [MonCod] FROM [TSCUENTABANCO] WHERE [BanCod] = @AV11BanCod and [CBCod] = @AV12BanCuenta ORDER BY [BanCod], [CBCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A12,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
