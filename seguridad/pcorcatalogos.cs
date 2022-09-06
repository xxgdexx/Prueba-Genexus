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
namespace GeneXus.Programs.seguridad {
   public class pcorcatalogos : GXProcedure
   {
      public pcorcatalogos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pcorcatalogos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CorTip ,
                           out long aP1_CorNum )
      {
         this.AV8CorTip = aP0_CorTip;
         this.AV9CorNum = 0 ;
         initialize();
         executePrivate();
         aP0_CorTip=this.AV8CorTip;
         aP1_CorNum=this.AV9CorNum;
      }

      public long executeUdp( ref string aP0_CorTip )
      {
         execute(ref aP0_CorTip, out aP1_CorNum);
         return AV9CorNum ;
      }

      public void executeSubmit( ref string aP0_CorTip ,
                                 out long aP1_CorNum )
      {
         pcorcatalogos objpcorcatalogos;
         objpcorcatalogos = new pcorcatalogos();
         objpcorcatalogos.AV8CorTip = aP0_CorTip;
         objpcorcatalogos.AV9CorNum = 0 ;
         objpcorcatalogos.context.SetSubmitInitialConfig(context);
         objpcorcatalogos.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcorcatalogos);
         aP0_CorTip=this.AV8CorTip;
         aP1_CorNum=this.AV9CorNum;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcorcatalogos)stateInfo).executePrivate();
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
         AV12GXLvl1 = 0;
         /* Using cursor P001D2 */
         pr_default.execute(0, new Object[] {AV8CorTip});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A138CorTip = P001D2_A138CorTip[0];
            A758CorNum = P001D2_A758CorNum[0];
            AV12GXLvl1 = 1;
            AV9CorNum = (long)(A758CorNum+1);
            A758CorNum = AV9CorNum;
            /* Using cursor P001D3 */
            pr_default.execute(1, new Object[] {A758CorNum, A138CorTip});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("CCORRELATIVOS");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV12GXLvl1 == 0 )
         {
            AV9CorNum = 1;
            /*
               INSERT RECORD ON TABLE CCORRELATIVOS

            */
            A138CorTip = AV8CorTip;
            A758CorNum = AV9CorNum;
            /* Using cursor P001D4 */
            pr_default.execute(2, new Object[] {A138CorTip, A758CorNum});
            pr_default.close(2);
            dsDefault.SmartCacheProvider.SetUpdated("CCORRELATIVOS");
            if ( (pr_default.getStatus(2) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         context.CommitDataStores("seguridad.pcorcatalogos",pr_default);
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
         P001D2_A138CorTip = new string[] {""} ;
         P001D2_A758CorNum = new long[1] ;
         A138CorTip = "";
         Gx_emsg = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.seguridad.pcorcatalogos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.pcorcatalogos__default(),
            new Object[][] {
                new Object[] {
               P001D2_A138CorTip, P001D2_A758CorNum
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12GXLvl1 ;
      private int GX_INS76 ;
      private long AV9CorNum ;
      private long A758CorNum ;
      private string AV8CorTip ;
      private string scmdbuf ;
      private string A138CorTip ;
      private string Gx_emsg ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CorTip ;
      private IDataStoreProvider pr_default ;
      private string[] P001D2_A138CorTip ;
      private long[] P001D2_A758CorNum ;
      private long aP1_CorNum ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class pcorcatalogos__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class pcorcatalogos__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new UpdateCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP001D2;
        prmP001D2 = new Object[] {
        new ParDef("@AV8CorTip",GXType.NChar,10,0)
        };
        Object[] prmP001D3;
        prmP001D3 = new Object[] {
        new ParDef("@CorNum",GXType.Decimal,10,0) ,
        new ParDef("@CorTip",GXType.NChar,10,0)
        };
        Object[] prmP001D4;
        prmP001D4 = new Object[] {
        new ParDef("@CorTip",GXType.NChar,10,0) ,
        new ParDef("@CorNum",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P001D2", "SELECT [CorTip], [CorNum] FROM [CCORRELATIVOS] WITH (UPDLOCK) WHERE [CorTip] = @AV8CorTip ORDER BY [CorTip] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001D2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P001D3", "UPDATE [CCORRELATIVOS] SET [CorNum]=@CorNum  WHERE [CorTip] = @CorTip", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001D3)
           ,new CursorDef("P001D4", "INSERT INTO [CCORRELATIVOS]([CorTip], [CorNum]) VALUES(@CorTip, @CorNum)", GxErrorMask.GX_NOMASK,prmP001D4)
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}
