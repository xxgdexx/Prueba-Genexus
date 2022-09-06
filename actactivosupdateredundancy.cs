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
   public class actactivosupdateredundancy : GXProcedure
   {
      public actactivosupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actactivosupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ACTActCod )
      {
         this.A2100ACTActCod = aP0_ACTActCod;
         initialize();
         executePrivate();
         aP0_ACTActCod=this.A2100ACTActCod;
      }

      public string executeUdp( )
      {
         execute(ref aP0_ACTActCod);
         return A2100ACTActCod ;
      }

      public void executeSubmit( ref string aP0_ACTActCod )
      {
         actactivosupdateredundancy objactactivosupdateredundancy;
         objactactivosupdateredundancy = new actactivosupdateredundancy();
         objactactivosupdateredundancy.A2100ACTActCod = aP0_ACTActCod;
         objactactivosupdateredundancy.context.SetSubmitInitialConfig(context);
         objactactivosupdateredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objactactivosupdateredundancy);
         aP0_ACTActCod=this.A2100ACTActCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((actactivosupdateredundancy)stateInfo).executePrivate();
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
         pr_default.execute(0, new Object[] {A2100ACTActCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A426ACTClaCod = ACTACTIVOS2_A426ACTClaCod[0];
            n426ACTClaCod = ACTACTIVOS2_n426ACTClaCod[0];
            A2103ACTGrupCod = ACTACTIVOS2_A2103ACTGrupCod[0];
            AV2GXV426 = A426ACTClaCod;
            AV3GXV2103 = A2103ACTGrupCod;
            n426ACTClaCod = false;
            /* Optimized UPDATE. */
            /* Using cursor ACTACTIVOS3 */
            pr_default.execute(1, new Object[] {AV3GXV2103, n426ACTClaCod, AV2GXV426, A2100ACTActCod});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("ACTACTIVOSDET");
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
         ACTACTIVOS2_A2100ACTActCod = new string[] {""} ;
         ACTACTIVOS2_A426ACTClaCod = new string[] {""} ;
         ACTACTIVOS2_n426ACTClaCod = new bool[] {false} ;
         ACTACTIVOS2_A2103ACTGrupCod = new string[] {""} ;
         A426ACTClaCod = "";
         A2103ACTGrupCod = "";
         AV2GXV426 = "";
         AV3GXV2103 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actactivosupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               ACTACTIVOS2_A2100ACTActCod, ACTACTIVOS2_A426ACTClaCod, ACTACTIVOS2_A2103ACTGrupCod
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
      private string A2100ACTActCod ;
      private string A426ACTClaCod ;
      private string A2103ACTGrupCod ;
      private string AV2GXV426 ;
      private string AV3GXV2103 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ACTActCod ;
      private IDataStoreProvider pr_default ;
      private string[] ACTACTIVOS2_A2100ACTActCod ;
      private string[] ACTACTIVOS2_A426ACTClaCod ;
      private bool[] ACTACTIVOS2_n426ACTClaCod ;
      private string[] ACTACTIVOS2_A2103ACTGrupCod ;
   }

   public class actactivosupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          new ParDef("@ACTActCod",GXType.NVarChar,20,0)
          };
          Object[] prmACTACTIVOS3;
          prmACTACTIVOS3 = new Object[] {
          new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
          new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true} ,
          new ParDef("@ACTActCod",GXType.NVarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("ACTACTIVOS2", "SELECT [ACTActCod], [ACTClaCod], [ACTGrupCod] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmACTACTIVOS2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("ACTACTIVOS3", "UPDATE [ACTACTIVOSDET] SET [ACTGrupCod]=@ACTGrupCod, [ACTClaCod]=@ACTClaCod  WHERE [ACTActCod] = @ACTActCod", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmACTACTIVOS3)
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
                return;
       }
    }

 }

}
