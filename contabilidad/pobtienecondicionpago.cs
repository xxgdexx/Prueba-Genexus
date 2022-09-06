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
   public class pobtienecondicionpago : GXProcedure
   {
      public pobtienecondicionpago( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtienecondicionpago( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_ConpCod ,
                           out string aP1_ConpDsc )
      {
         this.AV10ConpCod = aP0_ConpCod;
         this.AV11ConpDsc = "" ;
         initialize();
         executePrivate();
         aP0_ConpCod=this.AV10ConpCod;
         aP1_ConpDsc=this.AV11ConpDsc;
      }

      public string executeUdp( ref int aP0_ConpCod )
      {
         execute(ref aP0_ConpCod, out aP1_ConpDsc);
         return AV11ConpDsc ;
      }

      public void executeSubmit( ref int aP0_ConpCod ,
                                 out string aP1_ConpDsc )
      {
         pobtienecondicionpago objpobtienecondicionpago;
         objpobtienecondicionpago = new pobtienecondicionpago();
         objpobtienecondicionpago.AV10ConpCod = aP0_ConpCod;
         objpobtienecondicionpago.AV11ConpDsc = "" ;
         objpobtienecondicionpago.context.SetSubmitInitialConfig(context);
         objpobtienecondicionpago.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtienecondicionpago);
         aP0_ConpCod=this.AV10ConpCod;
         aP1_ConpDsc=this.AV11ConpDsc;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtienecondicionpago)stateInfo).executePrivate();
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
         /* Using cursor P009D2 */
         pr_default.execute(0, new Object[] {AV10ConpCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A137Conpcod = P009D2_A137Conpcod[0];
            A753ConpDsc = P009D2_A753ConpDsc[0];
            AV11ConpDsc = A753ConpDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         context.CommitDataStores("contabilidad.pobtienecondicionpago",pr_default);
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
         AV11ConpDsc = "";
         scmdbuf = "";
         P009D2_A137Conpcod = new int[1] ;
         P009D2_A753ConpDsc = new string[] {""} ;
         A753ConpDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.pobtienecondicionpago__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.pobtienecondicionpago__default(),
            new Object[][] {
                new Object[] {
               P009D2_A137Conpcod, P009D2_A753ConpDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV10ConpCod ;
      private int A137Conpcod ;
      private string AV11ConpDsc ;
      private string scmdbuf ;
      private string A753ConpDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_ConpCod ;
      private IDataStoreProvider pr_default ;
      private int[] P009D2_A137Conpcod ;
      private string[] P009D2_A753ConpDsc ;
      private string aP1_ConpDsc ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class pobtienecondicionpago__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class pobtienecondicionpago__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP009D2;
        prmP009D2 = new Object[] {
        new ParDef("@AV10ConpCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("P009D2", "SELECT [Conpcod], [ConpDsc] FROM [CCONDICIONPAGO] WHERE [Conpcod] = @AV10ConpCod ORDER BY [Conpcod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009D2,1, GxCacheFrequency.OFF ,false,true )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
     }
  }

}

}
