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
   public class cpproveedoresupdateredundancy : GXProcedure
   {
      public cpproveedoresupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpproveedoresupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_PrvCod )
      {
         this.A244PrvCod = aP0_PrvCod;
         initialize();
         executePrivate();
         aP0_PrvCod=this.A244PrvCod;
      }

      public string executeUdp( )
      {
         execute(ref aP0_PrvCod);
         return A244PrvCod ;
      }

      public void executeSubmit( ref string aP0_PrvCod )
      {
         cpproveedoresupdateredundancy objcpproveedoresupdateredundancy;
         objcpproveedoresupdateredundancy = new cpproveedoresupdateredundancy();
         objcpproveedoresupdateredundancy.A244PrvCod = aP0_PrvCod;
         objcpproveedoresupdateredundancy.context.SetSubmitInitialConfig(context);
         objcpproveedoresupdateredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcpproveedoresupdateredundancy);
         aP0_PrvCod=this.A244PrvCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cpproveedoresupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor CPPROVEEDO2 */
         pr_default.execute(0, new Object[] {A244PrvCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A247PrvDsc = CPPROVEEDO2_A247PrvDsc[0];
            AV2GXV247 = A247PrvDsc;
            /* Optimized UPDATE. */
            /* Using cursor CPPROVEEDO3 */
            pr_default.execute(1, new Object[] {AV2GXV247, A244PrvCod});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("CPCOMPRAS");
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
         CPPROVEEDO2_A244PrvCod = new string[] {""} ;
         CPPROVEEDO2_A247PrvDsc = new string[] {""} ;
         A247PrvDsc = "";
         AV2GXV247 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpproveedoresupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               CPPROVEEDO2_A244PrvCod, CPPROVEEDO2_A247PrvDsc
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string A244PrvCod ;
      private string scmdbuf ;
      private string A247PrvDsc ;
      private string AV2GXV247 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_PrvCod ;
      private IDataStoreProvider pr_default ;
      private string[] CPPROVEEDO2_A244PrvCod ;
      private string[] CPPROVEEDO2_A247PrvDsc ;
   }

   public class cpproveedoresupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmCPPROVEEDO2;
          prmCPPROVEEDO2 = new Object[] {
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmCPPROVEEDO3;
          prmCPPROVEEDO3 = new Object[] {
          new ParDef("@PrvDsc",GXType.NChar,100,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("CPPROVEEDO2", "SELECT [PrvCod], [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ORDER BY [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCPPROVEEDO2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("CPPROVEEDO3", "UPDATE [CPCOMPRAS] SET [PrvDsc]=@PrvDsc  WHERE [PrvCod] = @PrvCod", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCPPROVEEDO3)
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
