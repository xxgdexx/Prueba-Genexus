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
   public class obtieneitemmenu : GXProcedure
   {
      public obtieneitemmenu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public obtieneitemmenu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_MenuItemId )
      {
         this.AV8MenuItemId = 0 ;
         initialize();
         executePrivate();
         aP0_MenuItemId=this.AV8MenuItemId;
      }

      public short executeUdp( )
      {
         execute(out aP0_MenuItemId);
         return AV8MenuItemId ;
      }

      public void executeSubmit( out short aP0_MenuItemId )
      {
         obtieneitemmenu objobtieneitemmenu;
         objobtieneitemmenu = new obtieneitemmenu();
         objobtieneitemmenu.AV8MenuItemId = 0 ;
         objobtieneitemmenu.context.SetSubmitInitialConfig(context);
         objobtieneitemmenu.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objobtieneitemmenu);
         aP0_MenuItemId=this.AV8MenuItemId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((obtieneitemmenu)stateInfo).executePrivate();
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
         AV8MenuItemId = 0;
         /* Using cursor P001G2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A352MenuItemId = P001G2_A352MenuItemId[0];
            AV8MenuItemId = A352MenuItemId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8MenuItemId = (short)(AV8MenuItemId+1);
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
         P001G2_A352MenuItemId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.obtieneitemmenu__default(),
            new Object[][] {
                new Object[] {
               P001G2_A352MenuItemId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8MenuItemId ;
      private short A352MenuItemId ;
      private string scmdbuf ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P001G2_A352MenuItemId ;
      private short aP0_MenuItemId ;
   }

   public class obtieneitemmenu__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001G2;
          prmP001G2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P001G2", "SELECT [MenuItemId] FROM [SIGERPMenu] ORDER BY [MenuItemId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001G2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
