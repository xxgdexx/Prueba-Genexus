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
   public class getmenuitemids : GXProcedure
   {
      public getmenuitemids( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public getmenuitemids( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_MenuItemId ,
                           out GxSimpleCollection<short> aP1_MenuItemIdCollection )
      {
         this.AV8MenuItemId = aP0_MenuItemId;
         this.AV10MenuItemIdCollection = new GxSimpleCollection<short>() ;
         initialize();
         executePrivate();
         aP1_MenuItemIdCollection=this.AV10MenuItemIdCollection;
      }

      public GxSimpleCollection<short> executeUdp( short aP0_MenuItemId )
      {
         execute(aP0_MenuItemId, out aP1_MenuItemIdCollection);
         return AV10MenuItemIdCollection ;
      }

      public void executeSubmit( short aP0_MenuItemId ,
                                 out GxSimpleCollection<short> aP1_MenuItemIdCollection )
      {
         getmenuitemids objgetmenuitemids;
         objgetmenuitemids = new getmenuitemids();
         objgetmenuitemids.AV8MenuItemId = aP0_MenuItemId;
         objgetmenuitemids.AV10MenuItemIdCollection = new GxSimpleCollection<short>() ;
         objgetmenuitemids.context.SetSubmitInitialConfig(context);
         objgetmenuitemids.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetmenuitemids);
         aP1_MenuItemIdCollection=this.AV10MenuItemIdCollection;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getmenuitemids)stateInfo).executePrivate();
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
         /* Using cursor P001V2 */
         pr_default.execute(0, new Object[] {AV8MenuItemId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A353MenuItemFatherId = P001V2_A353MenuItemFatherId[0];
            n353MenuItemFatherId = P001V2_n353MenuItemFatherId[0];
            A352MenuItemId = P001V2_A352MenuItemId[0];
            AV10MenuItemIdCollection.Add(A352MenuItemId, 0);
            GXt_objcol_int1 = AV11MenuItemIdCollectionAux;
            new GeneXus.Programs.wwpbaseobjects.getmenuitemids(context ).execute(  A352MenuItemId, out  GXt_objcol_int1) ;
            AV11MenuItemIdCollectionAux = GXt_objcol_int1;
            AV15GXV1 = 1;
            while ( AV15GXV1 <= AV11MenuItemIdCollectionAux.Count )
            {
               AV9MenuItemIdAux = (short)(AV11MenuItemIdCollectionAux.GetNumeric(AV15GXV1));
               AV10MenuItemIdCollection.Add(AV9MenuItemIdAux, 0);
               AV15GXV1 = (int)(AV15GXV1+1);
            }
            pr_default.readNext(0);
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
         AV10MenuItemIdCollection = new GxSimpleCollection<short>();
         scmdbuf = "";
         P001V2_A353MenuItemFatherId = new short[1] ;
         P001V2_n353MenuItemFatherId = new bool[] {false} ;
         P001V2_A352MenuItemId = new short[1] ;
         AV11MenuItemIdCollectionAux = new GxSimpleCollection<short>();
         GXt_objcol_int1 = new GxSimpleCollection<short>();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.getmenuitemids__default(),
            new Object[][] {
                new Object[] {
               P001V2_A353MenuItemFatherId, P001V2_n353MenuItemFatherId, P001V2_A352MenuItemId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8MenuItemId ;
      private short A353MenuItemFatherId ;
      private short A352MenuItemId ;
      private short AV9MenuItemIdAux ;
      private int AV15GXV1 ;
      private string scmdbuf ;
      private bool n353MenuItemFatherId ;
      private GxSimpleCollection<short> AV10MenuItemIdCollection ;
      private GxSimpleCollection<short> AV11MenuItemIdCollectionAux ;
      private GxSimpleCollection<short> GXt_objcol_int1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P001V2_A353MenuItemFatherId ;
      private bool[] P001V2_n353MenuItemFatherId ;
      private short[] P001V2_A352MenuItemId ;
      private GxSimpleCollection<short> aP1_MenuItemIdCollection ;
   }

   public class getmenuitemids__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001V2;
          prmP001V2 = new Object[] {
          new ParDef("@AV8MenuItemId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001V2", "SELECT [MenuItemFatherId], [MenuItemId] FROM [SIGERPMenu] WHERE [MenuItemFatherId] = @AV8MenuItemId ORDER BY [MenuItemFatherId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001V2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
