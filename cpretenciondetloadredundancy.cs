using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class cpretenciondetloadredundancy : GXProcedure
   {
      public cpretenciondetloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpretenciondetloadredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         cpretenciondetloadredundancy objcpretenciondetloadredundancy;
         objcpretenciondetloadredundancy = new cpretenciondetloadredundancy();
         objcpretenciondetloadredundancy.context.SetSubmitInitialConfig(context);
         objcpretenciondetloadredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcpretenciondetloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cpretenciondetloadredundancy)stateInfo).executePrivate();
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
         /* Optimized UPDATE. */
         /* Using cursor CPRETENCIO2 */
         pr_default.execute(0);
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("CPRETENCIONDET");
         /* End optimized UPDATE. */
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpretenciondetloadredundancy__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class cpretenciondetloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmCPRETENCIO2;
          prmCPRETENCIO2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("CPRETENCIO2", "UPDATE [CPRETENCIONDET] SET [CPRetRet]=ROUND(CAST(( [CPRetTotal] * CAST([CPRetPor] AS decimal( 25, 10))) AS decimal( 29, 10)) / 100, 2) ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCPRETENCIO2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
