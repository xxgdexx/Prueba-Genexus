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
namespace GeneXus.Programs.generales {
   public class pobtienenombremes : GXProcedure
   {
      public pobtienenombremes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtienenombremes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref short aP0_jMes ,
                           out string aP1_nMes )
      {
         this.AV8jMes = aP0_jMes;
         this.AV9nMes = "" ;
         initialize();
         executePrivate();
         aP0_jMes=this.AV8jMes;
         aP1_nMes=this.AV9nMes;
      }

      public string executeUdp( ref short aP0_jMes )
      {
         execute(ref aP0_jMes, out aP1_nMes);
         return AV9nMes ;
      }

      public void executeSubmit( ref short aP0_jMes ,
                                 out string aP1_nMes )
      {
         pobtienenombremes objpobtienenombremes;
         objpobtienenombremes = new pobtienenombremes();
         objpobtienenombremes.AV8jMes = aP0_jMes;
         objpobtienenombremes.AV9nMes = "" ;
         objpobtienenombremes.context.SetSubmitInitialConfig(context);
         objpobtienenombremes.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtienenombremes);
         aP0_jMes=this.AV8jMes;
         aP1_nMes=this.AV9nMes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtienenombremes)stateInfo).executePrivate();
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
         if ( AV8jMes == 0 )
         {
            AV9nMes = "Apertura";
         }
         else if ( AV8jMes == 1 )
         {
            AV9nMes = "Enero";
         }
         else if ( AV8jMes == 2 )
         {
            AV9nMes = "Febrero";
         }
         else if ( AV8jMes == 3 )
         {
            AV9nMes = "Marzo";
         }
         else if ( AV8jMes == 4 )
         {
            AV9nMes = "Abril";
         }
         else if ( AV8jMes == 5 )
         {
            AV9nMes = "Mayo";
         }
         else if ( AV8jMes == 6 )
         {
            AV9nMes = "Junio";
         }
         else if ( AV8jMes == 7 )
         {
            AV9nMes = "Julio";
         }
         else if ( AV8jMes == 8 )
         {
            AV9nMes = "Agosto";
         }
         else if ( AV8jMes == 9 )
         {
            AV9nMes = "Septiembre";
         }
         else if ( AV8jMes == 10 )
         {
            AV9nMes = "Octubre";
         }
         else if ( AV8jMes == 11 )
         {
            AV9nMes = "Noviembre";
         }
         else if ( AV8jMes == 12 )
         {
            AV9nMes = "Diciembre";
         }
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
         AV9nMes = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8jMes ;
      private string AV9nMes ;
      private short aP0_jMes ;
      private string aP1_nMes ;
   }

}
