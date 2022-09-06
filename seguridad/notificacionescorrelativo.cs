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
   public class notificacionescorrelativo : GXProcedure
   {
      public notificacionescorrelativo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public notificacionescorrelativo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_cSGNotificacionID )
      {
         this.AV8cSGNotificacionID = 0 ;
         initialize();
         executePrivate();
         aP0_cSGNotificacionID=this.AV8cSGNotificacionID;
      }

      public long executeUdp( )
      {
         execute(out aP0_cSGNotificacionID);
         return AV8cSGNotificacionID ;
      }

      public void executeSubmit( out long aP0_cSGNotificacionID )
      {
         notificacionescorrelativo objnotificacionescorrelativo;
         objnotificacionescorrelativo = new notificacionescorrelativo();
         objnotificacionescorrelativo.AV8cSGNotificacionID = 0 ;
         objnotificacionescorrelativo.context.SetSubmitInitialConfig(context);
         objnotificacionescorrelativo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objnotificacionescorrelativo);
         aP0_cSGNotificacionID=this.AV8cSGNotificacionID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((notificacionescorrelativo)stateInfo).executePrivate();
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
         /* Using cursor P00D62 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2237SGNotificacionID = P00D62_A2237SGNotificacionID[0];
            AV8cSGNotificacionID = A2237SGNotificacionID;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8cSGNotificacionID = (long)(AV8cSGNotificacionID+1);
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
         P00D62_A2237SGNotificacionID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.notificacionescorrelativo__default(),
            new Object[][] {
                new Object[] {
               P00D62_A2237SGNotificacionID
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long AV8cSGNotificacionID ;
      private long A2237SGNotificacionID ;
      private string scmdbuf ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00D62_A2237SGNotificacionID ;
      private long aP0_cSGNotificacionID ;
   }

   public class notificacionescorrelativo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00D62;
          prmP00D62 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00D62", "SELECT [SGNotificacionID] FROM [SGNOTIFICACIONES] ORDER BY [SGNotificacionID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D62,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
