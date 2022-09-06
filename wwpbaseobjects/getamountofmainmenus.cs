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
   public class getamountofmainmenus : GXProcedure
   {
      public getamountofmainmenus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public getamountofmainmenus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_MainMenuItemCaption ,
                           out short aP1_Count )
      {
         this.AV8MainMenuItemCaption = aP0_MainMenuItemCaption;
         this.AV9Count = 0 ;
         initialize();
         executePrivate();
         aP1_Count=this.AV9Count;
      }

      public short executeUdp( string aP0_MainMenuItemCaption )
      {
         execute(aP0_MainMenuItemCaption, out aP1_Count);
         return AV9Count ;
      }

      public void executeSubmit( string aP0_MainMenuItemCaption ,
                                 out short aP1_Count )
      {
         getamountofmainmenus objgetamountofmainmenus;
         objgetamountofmainmenus = new getamountofmainmenus();
         objgetamountofmainmenus.AV8MainMenuItemCaption = aP0_MainMenuItemCaption;
         objgetamountofmainmenus.AV9Count = 0 ;
         objgetamountofmainmenus.context.SetSubmitInitialConfig(context);
         objgetamountofmainmenus.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetamountofmainmenus);
         aP1_Count=this.AV9Count;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getamountofmainmenus)stateInfo).executePrivate();
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
         /* Using cursor P001H3 */
         pr_default.execute(0, new Object[] {AV8MainMenuItemCaption});
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P001H3_A40000GXC1[0];
            n40000GXC1 = P001H3_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         AV9Count = (short)(A40000GXC1);
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
         P001H3_A40000GXC1 = new int[1] ;
         P001H3_n40000GXC1 = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.getamountofmainmenus__default(),
            new Object[][] {
                new Object[] {
               P001H3_A40000GXC1, P001H3_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9Count ;
      private int A40000GXC1 ;
      private string scmdbuf ;
      private bool n40000GXC1 ;
      private string AV8MainMenuItemCaption ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001H3_A40000GXC1 ;
      private bool[] P001H3_n40000GXC1 ;
      private short aP1_Count ;
   }

   public class getamountofmainmenus__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001H3;
          prmP001H3 = new Object[] {
          new ParDef("@AV8MainMenuItemCaption",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001H3", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM [SIGERPMenu] WHERE ([MenuItemFatherId] IS NULL) AND ([MenuItemCaption] = @AV8MainMenuItemCaption) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001H3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
