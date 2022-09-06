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
   public class relojupdatereferentialintegrity : GXProcedure
   {
      public relojupdatereferentialintegrity( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public relojupdatereferentialintegrity( IGxContext context )
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
         relojupdatereferentialintegrity objrelojupdatereferentialintegrity;
         objrelojupdatereferentialintegrity = new relojupdatereferentialintegrity();
         objrelojupdatereferentialintegrity.context.SetSubmitInitialConfig(context);
         objrelojupdatereferentialintegrity.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrelojupdatereferentialintegrity);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((relojupdatereferentialintegrity)stateInfo).executePrivate();
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
         /* Using cursor RELOJUPDAT2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2498Reloj_ID = RELOJUPDAT2_A2498Reloj_ID[0];
            A2431CodigoId = RELOJUPDAT2_A2431CodigoId[0];
            /*
               INSERT RECORD ON TABLE Reloj

            */
            A2430RelojID = A2498Reloj_ID;
            A2425Reloj_Nom = " ";
            A2426Reloj_Dsc = " ";
            A2427Reloj_IP = " ";
            A2428Reloj_Puerto = " ";
            A2429Reloj_Estado = 0;
            /* Using cursor RELOJUPDAT3 */
            pr_default.execute(1, new Object[] {A2430RelojID, A2425Reloj_Nom, A2426Reloj_Dsc, A2427Reloj_IP, A2428Reloj_Puerto, A2429Reloj_Estado});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("Reloj");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
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
         RELOJUPDAT2_A2498Reloj_ID = new short[1] ;
         RELOJUPDAT2_A2431CodigoId = new string[] {""} ;
         A2431CodigoId = "";
         A2425Reloj_Nom = "";
         A2426Reloj_Dsc = "";
         A2427Reloj_IP = "";
         A2428Reloj_Puerto = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.relojupdatereferentialintegrity__default(),
            new Object[][] {
                new Object[] {
               RELOJUPDAT2_A2498Reloj_ID, RELOJUPDAT2_A2431CodigoId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A2498Reloj_ID ;
      private short A2430RelojID ;
      private short A2429Reloj_Estado ;
      private int GX_INS212 ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private string A2431CodigoId ;
      private string A2425Reloj_Nom ;
      private string A2426Reloj_Dsc ;
      private string A2427Reloj_IP ;
      private string A2428Reloj_Puerto ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] RELOJUPDAT2_A2498Reloj_ID ;
      private string[] RELOJUPDAT2_A2431CodigoId ;
   }

   public class relojupdatereferentialintegrity__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmRELOJUPDAT2;
          prmRELOJUPDAT2 = new Object[] {
          };
          Object[] prmRELOJUPDAT3;
          prmRELOJUPDAT3 = new Object[] {
          new ParDef("@RelojID",GXType.Int16,4,0) ,
          new ParDef("@Reloj_Nom",GXType.NVarChar,50,0) ,
          new ParDef("@Reloj_Dsc",GXType.NVarChar,100,0) ,
          new ParDef("@Reloj_IP",GXType.NVarChar,50,0) ,
          new ParDef("@Reloj_Puerto",GXType.NVarChar,50,0) ,
          new ParDef("@Reloj_Estado",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("RELOJUPDAT2", "SELECT [Reloj_ID], [CodigoId] FROM [Reloj_CodigoID] ORDER BY [CodigoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmRELOJUPDAT2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("RELOJUPDAT3", "INSERT INTO [Reloj]([RelojID], [Reloj_Nom], [Reloj_Dsc], [Reloj_IP], [Reloj_Puerto], [Reloj_Estado]) VALUES(@RelojID, @Reloj_Nom, @Reloj_Dsc, @Reloj_IP, @Reloj_Puerto, @Reloj_Estado)", GxErrorMask.GX_NOMASK,prmRELOJUPDAT3)
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
