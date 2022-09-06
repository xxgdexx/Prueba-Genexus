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
   public class aguiasdetloteloadredundancy : GXProcedure
   {
      public aguiasdetloteloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aguiasdetloteloadredundancy( IGxContext context )
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
         aguiasdetloteloadredundancy objaguiasdetloteloadredundancy;
         objaguiasdetloteloadredundancy = new aguiasdetloteloadredundancy();
         objaguiasdetloteloadredundancy.context.SetSubmitInitialConfig(context);
         objaguiasdetloteloadredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objaguiasdetloteloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aguiasdetloteloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor AGUIASDETL2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A21MvAlm = AGUIASDETL2_A21MvAlm[0];
            A63AlmCod = AGUIASDETL2_A63AlmCod[0];
            A28ProdCod = AGUIASDETL2_A28ProdCod[0];
            A28ProdCod = AGUIASDETL2_A28ProdCod[0];
            A31MVADLRef1 = AGUIASDETL2_A31MVADLRef1[0];
            A30MvADItem = AGUIASDETL2_A30MvADItem[0];
            A14MvACod = AGUIASDETL2_A14MvACod[0];
            A13MvATip = AGUIASDETL2_A13MvATip[0];
            O28ProdCod = A28ProdCod;
            A21MvAlm = AGUIASDETL2_A21MvAlm[0];
            A28ProdCod = O28ProdCod;
            O28ProdCod = A28ProdCod;
            /* Using cursor AGUIASDETL3 */
            pr_default.execute(1, new Object[] {A28ProdCod, A13MvATip, A14MvACod, A30MvADItem, A31MVADLRef1});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("AGUIASDETLOTE");
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
         AGUIASDETL2_A21MvAlm = new int[1] ;
         AGUIASDETL2_A63AlmCod = new int[1] ;
         AGUIASDETL2_A28ProdCod = new string[] {""} ;
         AGUIASDETL2_A31MVADLRef1 = new string[] {""} ;
         AGUIASDETL2_A30MvADItem = new int[1] ;
         AGUIASDETL2_A14MvACod = new string[] {""} ;
         AGUIASDETL2_A13MvATip = new string[] {""} ;
         A28ProdCod = "";
         A31MVADLRef1 = "";
         A14MvACod = "";
         A13MvATip = "";
         O28ProdCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aguiasdetloteloadredundancy__default(),
            new Object[][] {
                new Object[] {
               AGUIASDETL2_A21MvAlm, AGUIASDETL2_A63AlmCod, AGUIASDETL2_A28ProdCod, AGUIASDETL2_A28ProdCod, AGUIASDETL2_A31MVADLRef1, AGUIASDETL2_A30MvADItem, AGUIASDETL2_A14MvACod, AGUIASDETL2_A13MvATip
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A21MvAlm ;
      private int A63AlmCod ;
      private int A30MvADItem ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A14MvACod ;
      private string A13MvATip ;
      private string O28ProdCod ;
      private string A31MVADLRef1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] AGUIASDETL2_A21MvAlm ;
      private int[] AGUIASDETL2_A63AlmCod ;
      private string[] AGUIASDETL2_A28ProdCod ;
      private string[] AGUIASDETL2_A31MVADLRef1 ;
      private int[] AGUIASDETL2_A30MvADItem ;
      private string[] AGUIASDETL2_A14MvACod ;
      private string[] AGUIASDETL2_A13MvATip ;
   }

   public class aguiasdetloteloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmAGUIASDETL2;
          prmAGUIASDETL2 = new Object[] {
          };
          Object[] prmAGUIASDETL3;
          prmAGUIASDETL3 = new Object[] {
          new ParDef("@ProdCod",GXType.NChar,15,0) ,
          new ParDef("@MvATip",GXType.NChar,3,0) ,
          new ParDef("@MvACod",GXType.NChar,12,0) ,
          new ParDef("@MvADItem",GXType.Int32,6,0) ,
          new ParDef("@MVADLRef1",GXType.NVarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("AGUIASDETL2", "SELECT T2.[MvAlm], T3.[AlmCod], T1.[ProdCod], T3.[ProdCod], T1.[MVADLRef1], T1.[MvADItem], T1.[MvACod], T1.[MvATip] FROM (([AGUIASDETLOTE] T1 WITH (UPDLOCK) INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) LEFT JOIN [ASTOCKACTUAL] T3 ON T3.[AlmCod] = T2.[MvAlm] AND T3.[ProdCod] = T1.[ProdCod]) ORDER BY T1.[MvATip], T1.[MvACod], T1.[MvADItem], T1.[MVADLRef1] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmAGUIASDETL2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("AGUIASDETL3", "UPDATE [AGUIASDETLOTE] SET [ProdCod]=@ProdCod  WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem AND [MVADLRef1] = @MVADLRef1", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmAGUIASDETL3)
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 12);
                ((string[]) buf[7])[0] = rslt.getString(8, 3);
                return;
       }
    }

 }

}
