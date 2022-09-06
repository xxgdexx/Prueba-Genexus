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
namespace GeneXus.Programs.wwpbaseobjects {
   public class updatemenuitemorder : GXProcedure
   {
      public updatemenuitemorder( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public updatemenuitemorder( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_MenuItemId )
      {
         this.A352MenuItemId = aP0_MenuItemId;
         initialize();
         executePrivate();
         aP0_MenuItemId=this.A352MenuItemId;
      }

      public short executeUdp( )
      {
         execute(ref aP0_MenuItemId);
         return A352MenuItemId ;
      }

      public void executeSubmit( ref short aP0_MenuItemId )
      {
         updatemenuitemorder objupdatemenuitemorder;
         objupdatemenuitemorder = new updatemenuitemorder();
         objupdatemenuitemorder.A352MenuItemId = aP0_MenuItemId;
         objupdatemenuitemorder.context.SetSubmitInitialConfig(context);
         objupdatemenuitemorder.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objupdatemenuitemorder);
         aP0_MenuItemId=this.A352MenuItemId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((updatemenuitemorder)stateInfo).executePrivate();
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
         /* Using cursor P001I2 */
         pr_default.execute(0, new Object[] {A352MenuItemId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("SIGERPMenu");
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.updatemenuitemorder__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A352MenuItemId ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_MenuItemId ;
      private IDataStoreProvider pr_default ;
   }

   public class updatemenuitemorder__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001I2;
          prmP001I2 = new Object[] {
          new ParDef("@MenuItemId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001I2", "UPDATE [SIGERPMenu] SET [MenuItemOrder]=[MenuItemId]  WHERE [MenuItemId] = @MenuItemId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001I2)
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
