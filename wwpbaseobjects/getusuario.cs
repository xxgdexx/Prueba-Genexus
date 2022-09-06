using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
namespace GeneXus.Programs.wwpbaseobjects {
   public class getusuario : GXProcedure
   {
      public getusuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public getusuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_cUsuCod )
      {
         this.AV8cUsuCod = "" ;
         initialize();
         executePrivate();
         aP0_cUsuCod=this.AV8cUsuCod;
      }

      public string executeUdp( )
      {
         execute(out aP0_cUsuCod);
         return AV8cUsuCod ;
      }

      public void executeSubmit( out string aP0_cUsuCod )
      {
         getusuario objgetusuario;
         objgetusuario = new getusuario();
         objgetusuario.AV8cUsuCod = "" ;
         objgetusuario.context.SetSubmitInitialConfig(context);
         objgetusuario.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetusuario);
         aP0_cUsuCod=this.AV8cUsuCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getusuario)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV8cUsuCod = AV9WWPContext.gxTpr_Username;
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
         AV8cUsuCod = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV8cUsuCod ;
      private string aP0_cUsuCod ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
   }

}
