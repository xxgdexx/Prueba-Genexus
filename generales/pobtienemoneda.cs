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
   public class pobtienemoneda : GXProcedure
   {
      public pobtienemoneda( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtienemoneda( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_BanCod ,
                           string aP1_BanCuenta ,
                           out string aP2_Moneda )
      {
         this.AV11BanCod = aP0_BanCod;
         this.AV12BanCuenta = aP1_BanCuenta;
         this.AV9Moneda = "" ;
         initialize();
         executePrivate();
         aP2_Moneda=this.AV9Moneda;
      }

      public string executeUdp( int aP0_BanCod ,
                                string aP1_BanCuenta )
      {
         execute(aP0_BanCod, aP1_BanCuenta, out aP2_Moneda);
         return AV9Moneda ;
      }

      public void executeSubmit( int aP0_BanCod ,
                                 string aP1_BanCuenta ,
                                 out string aP2_Moneda )
      {
         pobtienemoneda objpobtienemoneda;
         objpobtienemoneda = new pobtienemoneda();
         objpobtienemoneda.AV11BanCod = aP0_BanCod;
         objpobtienemoneda.AV12BanCuenta = aP1_BanCuenta;
         objpobtienemoneda.AV9Moneda = "" ;
         objpobtienemoneda.context.SetSubmitInitialConfig(context);
         objpobtienemoneda.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtienemoneda);
         aP2_Moneda=this.AV9Moneda;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtienemoneda)stateInfo).executePrivate();
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
         /* Using cursor P00A02 */
         pr_default.execute(0, new Object[] {AV11BanCod, AV12BanCuenta});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A377CBCod = P00A02_A377CBCod[0];
            A372BanCod = P00A02_A372BanCod[0];
            A180MonCod = P00A02_A180MonCod[0];
            AV8MonCod = A180MonCod;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00A03 */
         pr_default.execute(1, new Object[] {AV8MonCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A180MonCod = P00A03_A180MonCod[0];
            A1234MonDsc = P00A03_A1234MonDsc[0];
            AV9Moneda = A1234MonDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         AV9Moneda = "";
         scmdbuf = "";
         P00A02_A377CBCod = new string[] {""} ;
         P00A02_A372BanCod = new int[1] ;
         P00A02_A180MonCod = new int[1] ;
         A377CBCod = "";
         P00A03_A180MonCod = new int[1] ;
         P00A03_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.generales.pobtienemoneda__default(),
            new Object[][] {
                new Object[] {
               P00A02_A377CBCod, P00A02_A372BanCod, P00A02_A180MonCod
               }
               , new Object[] {
               P00A03_A180MonCod, P00A03_A1234MonDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV11BanCod ;
      private int A372BanCod ;
      private int A180MonCod ;
      private int AV8MonCod ;
      private string AV12BanCuenta ;
      private string AV9Moneda ;
      private string scmdbuf ;
      private string A377CBCod ;
      private string A1234MonDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00A02_A377CBCod ;
      private int[] P00A02_A372BanCod ;
      private int[] P00A02_A180MonCod ;
      private int[] P00A03_A180MonCod ;
      private string[] P00A03_A1234MonDsc ;
      private string aP2_Moneda ;
   }

   public class pobtienemoneda__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00A02;
          prmP00A02 = new Object[] {
          new ParDef("@AV11BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV12BanCuenta",GXType.NChar,20,0)
          };
          Object[] prmP00A03;
          prmP00A03 = new Object[] {
          new ParDef("@AV8MonCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A02", "SELECT [CBCod], [BanCod], [MonCod] FROM [TSCUENTABANCO] WHERE [BanCod] = @AV11BanCod and [CBCod] = @AV12BanCuenta ORDER BY [BanCod], [CBCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A02,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A03", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV8MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A03,1, GxCacheFrequency.OFF ,false,true )
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
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
