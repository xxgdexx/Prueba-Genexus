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
   public class clistapreciosloadredundancy : GXProcedure
   {
      public clistapreciosloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clistapreciosloadredundancy( IGxContext context )
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
         clistapreciosloadredundancy objclistapreciosloadredundancy;
         objclistapreciosloadredundancy = new clistapreciosloadredundancy();
         objclistapreciosloadredundancy.context.SetSubmitInitialConfig(context);
         objclistapreciosloadredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objclistapreciosloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clistapreciosloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor CLISTAPREC2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A45CliCod = CLISTAPREC2_A45CliCod[0];
            n45CliCod = CLISTAPREC2_n45CliCod[0];
            A161CliDsc = CLISTAPREC2_A161CliDsc[0];
            n161CliDsc = CLISTAPREC2_n161CliDsc[0];
            A161CliDsc = CLISTAPREC2_A161CliDsc[0];
            n161CliDsc = CLISTAPREC2_n161CliDsc[0];
            A203TipLItem = CLISTAPREC2_A203TipLItem[0];
            A202TipLCod = CLISTAPREC2_A202TipLCod[0];
            O161CliDsc = A161CliDsc;
            n161CliDsc = false;
            A161CliDsc = CLISTAPREC2_A161CliDsc[0];
            n161CliDsc = CLISTAPREC2_n161CliDsc[0];
            O161CliDsc = A161CliDsc;
            n161CliDsc = false;
            A161CliDsc = O161CliDsc;
            n161CliDsc = false;
            O161CliDsc = A161CliDsc;
            n161CliDsc = false;
            /* Using cursor CLISTAPREC3 */
            pr_default.execute(1, new Object[] {n161CliDsc, A161CliDsc, A202TipLCod, A203TipLItem});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("CLISTAPRECIOS");
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
         scmdbuf = "";
         CLISTAPREC2_A45CliCod = new string[] {""} ;
         CLISTAPREC2_n45CliCod = new bool[] {false} ;
         CLISTAPREC2_A161CliDsc = new string[] {""} ;
         CLISTAPREC2_n161CliDsc = new bool[] {false} ;
         CLISTAPREC2_A203TipLItem = new int[1] ;
         CLISTAPREC2_A202TipLCod = new int[1] ;
         A45CliCod = "";
         A161CliDsc = "";
         O161CliDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clistapreciosloadredundancy__default(),
            new Object[][] {
                new Object[] {
               CLISTAPREC2_A45CliCod, CLISTAPREC2_n45CliCod, CLISTAPREC2_A161CliDsc, CLISTAPREC2_n161CliDsc, CLISTAPREC2_A161CliDsc, CLISTAPREC2_n161CliDsc, CLISTAPREC2_A203TipLItem, CLISTAPREC2_A202TipLCod
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A203TipLItem ;
      private int A202TipLCod ;
      private string scmdbuf ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string O161CliDsc ;
      private bool n45CliCod ;
      private bool n161CliDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] CLISTAPREC2_A45CliCod ;
      private bool[] CLISTAPREC2_n45CliCod ;
      private string[] CLISTAPREC2_A161CliDsc ;
      private bool[] CLISTAPREC2_n161CliDsc ;
      private int[] CLISTAPREC2_A203TipLItem ;
      private int[] CLISTAPREC2_A202TipLCod ;
   }

   public class clistapreciosloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmCLISTAPREC2;
          prmCLISTAPREC2 = new Object[] {
          };
          Object[] prmCLISTAPREC3;
          prmCLISTAPREC3 = new Object[] {
          new ParDef("@CliDsc",GXType.NChar,100,0){Nullable=true} ,
          new ParDef("@TipLCod",GXType.Int32,6,0) ,
          new ParDef("@TipLItem",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("CLISTAPREC2", "SELECT T1.[CliCod], T1.[CliDsc], T2.[CliDsc], T1.[TipLItem], T1.[TipLCod] FROM ([CLISTAPRECIOS] T1 WITH (UPDLOCK) LEFT JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[CliCod]) ORDER BY T1.[TipLCod], T1.[TipLItem] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLISTAPREC2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("CLISTAPREC3", "UPDATE [CLISTAPRECIOS] SET [CliDsc]=@CliDsc  WHERE [TipLCod] = @TipLCod AND [TipLItem] = @TipLItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCLISTAPREC3)
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 100);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 100);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
