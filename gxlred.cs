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
   public class gxlred : GXProcedure
   {
      public gxlred( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public gxlred( IGxContext context )
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
         gxlred objgxlred;
         objgxlred = new gxlred();
         objgxlred.context.SetSubmitInitialConfig(context);
         objgxlred.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgxlred);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gxlred)stateInfo).executePrivate();
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
         new aguiasdetloadredundancy(context ).execute( ) ;
         new aguiasdetloteloadredundancy(context ).execute( ) ;
         new clcotizadetloadredundancy(context ).execute( ) ;
         new clistapreciosloadredundancy(context ).execute( ) ;
         new clpedidosloadredundancy(context ).execute( ) ;
         new clpedidosdetloadredundancy(context ).execute( ) ;
         new clventasloadredundancy(context ).execute( ) ;
         new clventasdetloadredundancy(context ).execute( ) ;
         new cpcomprasloadredundancy(context ).execute( ) ;
         new cpordendetloadredundancy(context ).execute( ) ;
         new cpretenciondetloadredundancy(context ).execute( ) ;
         new tslibrobancosloadredundancy(context ).execute( ) ;
         new tspagosloadredundancy(context ).execute( ) ;
         new actactivosdetloadredundancy(context ).execute( ) ;
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
   }

}
