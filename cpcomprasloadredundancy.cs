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
   public class cpcomprasloadredundancy : GXProcedure
   {
      public cpcomprasloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpcomprasloadredundancy( IGxContext context )
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
         cpcomprasloadredundancy objcpcomprasloadredundancy;
         objcpcomprasloadredundancy = new cpcomprasloadredundancy();
         objcpcomprasloadredundancy.context.SetSubmitInitialConfig(context);
         objcpcomprasloadredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcpcomprasloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cpcomprasloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor CPCOMPRASL2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A247PrvDsc = CPCOMPRASL2_A247PrvDsc[0];
            A247PrvDsc = CPCOMPRASL2_A247PrvDsc[0];
            A244PrvCod = CPCOMPRASL2_A244PrvCod[0];
            A243ComCod = CPCOMPRASL2_A243ComCod[0];
            A149TipCod = CPCOMPRASL2_A149TipCod[0];
            O247PrvDsc = A247PrvDsc;
            A247PrvDsc = CPCOMPRASL2_A247PrvDsc[0];
            O247PrvDsc = A247PrvDsc;
            A247PrvDsc = O247PrvDsc;
            O247PrvDsc = A247PrvDsc;
            /* Using cursor CPCOMPRASL3 */
            pr_default.execute(1, new Object[] {A247PrvDsc, A149TipCod, A243ComCod, A244PrvCod});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("CPCOMPRAS");
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
         CPCOMPRASL2_A247PrvDsc = new string[] {""} ;
         CPCOMPRASL2_A244PrvCod = new string[] {""} ;
         CPCOMPRASL2_A243ComCod = new string[] {""} ;
         CPCOMPRASL2_A149TipCod = new string[] {""} ;
         A247PrvDsc = "";
         A244PrvCod = "";
         A243ComCod = "";
         A149TipCod = "";
         O247PrvDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpcomprasloadredundancy__default(),
            new Object[][] {
                new Object[] {
               CPCOMPRASL2_A247PrvDsc, CPCOMPRASL2_A247PrvDsc, CPCOMPRASL2_A244PrvCod, CPCOMPRASL2_A243ComCod, CPCOMPRASL2_A149TipCod
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string scmdbuf ;
      private string A247PrvDsc ;
      private string A244PrvCod ;
      private string A243ComCod ;
      private string A149TipCod ;
      private string O247PrvDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] CPCOMPRASL2_A247PrvDsc ;
      private string[] CPCOMPRASL2_A244PrvCod ;
      private string[] CPCOMPRASL2_A243ComCod ;
      private string[] CPCOMPRASL2_A149TipCod ;
   }

   public class cpcomprasloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmCPCOMPRASL2;
          prmCPCOMPRASL2 = new Object[] {
          };
          Object[] prmCPCOMPRASL3;
          prmCPCOMPRASL3 = new Object[] {
          new ParDef("@PrvDsc",GXType.NChar,100,0) ,
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("CPCOMPRASL2", "SELECT T1.[PrvDsc], T2.[PrvDsc], T1.[PrvCod], T1.[ComCod], T1.[TipCod] FROM ([CPCOMPRAS] T1 WITH (UPDLOCK) INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = T1.[PrvCod]) ORDER BY T1.[TipCod], T1.[ComCod], T1.[PrvCod] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCPCOMPRASL2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("CPCOMPRASL3", "UPDATE [CPCOMPRAS] SET [PrvDsc]=@PrvDsc  WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCPCOMPRASL3)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                return;
       }
    }

 }

}
