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
   public class pobtieneultimodiames : GXProcedure
   {
      public pobtieneultimodiames( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtieneultimodiames( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_Fecha1 ,
                           out DateTime aP1_Fecha2 )
      {
         this.AV8Fecha1 = aP0_Fecha1;
         this.AV9Fecha2 = DateTime.MinValue ;
         initialize();
         executePrivate();
         aP1_Fecha2=this.AV9Fecha2;
      }

      public DateTime executeUdp( DateTime aP0_Fecha1 )
      {
         execute(aP0_Fecha1, out aP1_Fecha2);
         return AV9Fecha2 ;
      }

      public void executeSubmit( DateTime aP0_Fecha1 ,
                                 out DateTime aP1_Fecha2 )
      {
         pobtieneultimodiames objpobtieneultimodiames;
         objpobtieneultimodiames = new pobtieneultimodiames();
         objpobtieneultimodiames.AV8Fecha1 = aP0_Fecha1;
         objpobtieneultimodiames.AV9Fecha2 = DateTime.MinValue ;
         objpobtieneultimodiames.context.SetSubmitInitialConfig(context);
         objpobtieneultimodiames.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtieneultimodiames);
         aP1_Fecha2=this.AV9Fecha2;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtieneultimodiames)stateInfo).executePrivate();
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
         AV15MesU = (short)(DateTimeUtil.Month( AV8Fecha1));
         AV16AnoU = (short)(DateTimeUtil.Year( AV8Fecha1));
         if ( AV15MesU == 12 )
         {
            AV12Mes1 = 1;
            AV13Ano1 = (short)(AV16AnoU+1);
         }
         else
         {
            AV12Mes1 = (short)(AV15MesU+1);
            AV13Ano1 = AV16AnoU;
         }
         if ( AV15MesU != DateTimeUtil.Month( DateTimeUtil.Today( context)) )
         {
            AV14FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes1), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV13Ano1), 10, 0));
            AV9Fecha2 = DateTimeUtil.DAdd(context.localUtil.CToD( AV14FechaC, 2),-((int)(1)));
         }
         else
         {
            if ( AV16AnoU != DateTimeUtil.Year( DateTimeUtil.Today( context)) )
            {
               AV14FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes1), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV13Ano1), 10, 0));
               AV9Fecha2 = DateTimeUtil.DAdd(context.localUtil.CToD( AV14FechaC, 2),-((int)(1)));
            }
            else
            {
               AV9Fecha2 = DateTimeUtil.Today( context);
            }
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
         AV9Fecha2 = DateTime.MinValue;
         AV14FechaC = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV15MesU ;
      private short AV16AnoU ;
      private short AV12Mes1 ;
      private short AV13Ano1 ;
      private string AV14FechaC ;
      private DateTime AV8Fecha1 ;
      private DateTime AV9Fecha2 ;
      private DateTime aP1_Fecha2 ;
   }

}
