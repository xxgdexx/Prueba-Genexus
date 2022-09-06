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
   public class clclientesupdateredundancy : GXProcedure
   {
      public clclientesupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clclientesupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CliCod )
      {
         this.A45CliCod = aP0_CliCod;
         initialize();
         executePrivate();
         aP0_CliCod=this.A45CliCod;
      }

      public string executeUdp( )
      {
         execute(ref aP0_CliCod);
         return A45CliCod ;
      }

      public void executeSubmit( ref string aP0_CliCod )
      {
         clclientesupdateredundancy objclclientesupdateredundancy;
         objclclientesupdateredundancy = new clclientesupdateredundancy();
         objclclientesupdateredundancy.A45CliCod = aP0_CliCod;
         objclclientesupdateredundancy.context.SetSubmitInitialConfig(context);
         objclclientesupdateredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objclclientesupdateredundancy);
         aP0_CliCod=this.A45CliCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clclientesupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor CLCLIENTES2 */
         pr_default.execute(0, new Object[] {n45CliCod, A45CliCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A161CliDsc = CLCLIENTES2_A161CliDsc[0];
            n161CliDsc = CLCLIENTES2_n161CliDsc[0];
            AV2GXV161 = A161CliDsc;
            n161CliDsc = false;
            /* Optimized UPDATE. */
            /* Using cursor CLCLIENTES3 */
            pr_default.execute(1, new Object[] {n161CliDsc, AV2GXV161, n45CliCod, A45CliCod});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("CLISTAPRECIOS");
            /* End optimized UPDATE. */
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
         CLCLIENTES2_A45CliCod = new string[] {""} ;
         CLCLIENTES2_n45CliCod = new bool[] {false} ;
         CLCLIENTES2_A161CliDsc = new string[] {""} ;
         CLCLIENTES2_n161CliDsc = new bool[] {false} ;
         A161CliDsc = "";
         AV2GXV161 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clclientesupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               CLCLIENTES2_A45CliCod, CLCLIENTES2_A161CliDsc
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string A45CliCod ;
      private string scmdbuf ;
      private string A161CliDsc ;
      private string AV2GXV161 ;
      private bool n45CliCod ;
      private bool n161CliDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CliCod ;
      private IDataStoreProvider pr_default ;
      private string[] CLCLIENTES2_A45CliCod ;
      private bool[] CLCLIENTES2_n45CliCod ;
      private string[] CLCLIENTES2_A161CliDsc ;
      private bool[] CLCLIENTES2_n161CliDsc ;
   }

   public class clclientesupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmCLCLIENTES2;
          prmCLCLIENTES2 = new Object[] {
          new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
          };
          Object[] prmCLCLIENTES3;
          prmCLCLIENTES3 = new Object[] {
          new ParDef("@CliDsc",GXType.NChar,100,0){Nullable=true} ,
          new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("CLCLIENTES2", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLCLIENTES2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("CLCLIENTES3", "UPDATE [CLISTAPRECIOS] SET [CliDsc]=@CliDsc  WHERE [CliCod] = @CliCod", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCLCLIENTES3)
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
