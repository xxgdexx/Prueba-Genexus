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
   public class actactivosdetloadredundancy : GXProcedure
   {
      public actactivosdetloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actactivosdetloadredundancy( IGxContext context )
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
         actactivosdetloadredundancy objactactivosdetloadredundancy;
         objactactivosdetloadredundancy = new actactivosdetloadredundancy();
         objactactivosdetloadredundancy.context.SetSubmitInitialConfig(context);
         objactactivosdetloadredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objactactivosdetloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((actactivosdetloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor ACTACTIVOS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2103ACTGrupCod = ACTACTIVOS2_A2103ACTGrupCod[0];
            A2103ACTGrupCod = ACTACTIVOS2_A2103ACTGrupCod[0];
            A426ACTClaCod = ACTACTIVOS2_A426ACTClaCod[0];
            n426ACTClaCod = ACTACTIVOS2_n426ACTClaCod[0];
            A426ACTClaCod = ACTACTIVOS2_A426ACTClaCod[0];
            n426ACTClaCod = ACTACTIVOS2_n426ACTClaCod[0];
            A2104ActActItem = ACTACTIVOS2_A2104ActActItem[0];
            A2100ACTActCod = ACTACTIVOS2_A2100ACTActCod[0];
            O2103ACTGrupCod = A2103ACTGrupCod;
            O426ACTClaCod = A426ACTClaCod;
            n426ACTClaCod = false;
            A2103ACTGrupCod = ACTACTIVOS2_A2103ACTGrupCod[0];
            A426ACTClaCod = ACTACTIVOS2_A426ACTClaCod[0];
            n426ACTClaCod = ACTACTIVOS2_n426ACTClaCod[0];
            O2103ACTGrupCod = A2103ACTGrupCod;
            O426ACTClaCod = A426ACTClaCod;
            n426ACTClaCod = false;
            A2103ACTGrupCod = O2103ACTGrupCod;
            A426ACTClaCod = O426ACTClaCod;
            n426ACTClaCod = false;
            O2103ACTGrupCod = A2103ACTGrupCod;
            O426ACTClaCod = A426ACTClaCod;
            n426ACTClaCod = false;
            /* Using cursor ACTACTIVOS3 */
            pr_default.execute(1, new Object[] {A2103ACTGrupCod, n426ACTClaCod, A426ACTClaCod, A2100ACTActCod, A2104ActActItem});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("ACTACTIVOSDET");
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
         ACTACTIVOS2_A2103ACTGrupCod = new string[] {""} ;
         ACTACTIVOS2_A426ACTClaCod = new string[] {""} ;
         ACTACTIVOS2_n426ACTClaCod = new bool[] {false} ;
         ACTACTIVOS2_A2104ActActItem = new string[] {""} ;
         ACTACTIVOS2_A2100ACTActCod = new string[] {""} ;
         A2103ACTGrupCod = "";
         A426ACTClaCod = "";
         A2104ActActItem = "";
         A2100ACTActCod = "";
         O2103ACTGrupCod = "";
         O426ACTClaCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actactivosdetloadredundancy__default(),
            new Object[][] {
                new Object[] {
               ACTACTIVOS2_A2103ACTGrupCod, ACTACTIVOS2_A2103ACTGrupCod, ACTACTIVOS2_A426ACTClaCod, ACTACTIVOS2_n426ACTClaCod, ACTACTIVOS2_A426ACTClaCod, ACTACTIVOS2_n426ACTClaCod, ACTACTIVOS2_A2104ActActItem, ACTACTIVOS2_A2100ACTActCod
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string scmdbuf ;
      private bool n426ACTClaCod ;
      private string A2103ACTGrupCod ;
      private string A426ACTClaCod ;
      private string A2104ActActItem ;
      private string A2100ACTActCod ;
      private string O2103ACTGrupCod ;
      private string O426ACTClaCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] ACTACTIVOS2_A2103ACTGrupCod ;
      private string[] ACTACTIVOS2_A426ACTClaCod ;
      private bool[] ACTACTIVOS2_n426ACTClaCod ;
      private string[] ACTACTIVOS2_A2104ActActItem ;
      private string[] ACTACTIVOS2_A2100ACTActCod ;
   }

   public class actactivosdetloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmACTACTIVOS2;
          prmACTACTIVOS2 = new Object[] {
          };
          Object[] prmACTACTIVOS3;
          prmACTACTIVOS3 = new Object[] {
          new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
          new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true} ,
          new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@ActActItem",GXType.NVarChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("ACTACTIVOS2", "SELECT T1.[ACTGrupCod], T2.[ACTGrupCod], T1.[ACTClaCod], T2.[ACTClaCod], T1.[ActActItem], T1.[ACTActCod] FROM ([ACTACTIVOSDET] T1 WITH (UPDLOCK) INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) ORDER BY T1.[ACTActCod], T1.[ActActItem] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmACTACTIVOS2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("ACTACTIVOS3", "UPDATE [ACTACTIVOSDET] SET [ACTGrupCod]=@ACTGrupCod, [ACTClaCod]=@ACTClaCod  WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmACTACTIVOS3)
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                return;
       }
    }

 }

}
