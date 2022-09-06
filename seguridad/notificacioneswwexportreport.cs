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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.seguridad {
   public class notificacioneswwexportreport : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public notificacioneswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public notificacioneswwexportreport( IGxContext context )
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
         notificacioneswwexportreport objnotificacioneswwexportreport;
         objnotificacioneswwexportreport = new notificacioneswwexportreport();
         objnotificacioneswwexportreport.context.SetSubmitInitialConfig(context);
         objnotificacioneswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objnotificacioneswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((notificacioneswwexportreport)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            AV64Title = "Lista de Notificaciones";
            /* Execute user subroutine: 'PRINTFILTERS' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTDATA' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTFOOTER' */
            S171 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7Y0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "SGNOTIFICACIONTITULO") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15SGNotificacionTitulo1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15SGNotificacionTitulo1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterSGNotificacionTituloDescription = StringUtil.Format( "%1 (%2)", "Titulo", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterSGNotificacionTituloDescription = StringUtil.Format( "%1 (%2)", "Titulo", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17SGNotificacionTitulo = AV15SGNotificacionTitulo1;
                  H7Y0( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterSGNotificacionTituloDescription, "")), 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17SGNotificacionTitulo, "")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "SGNOTIFICACIONTITULO") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21SGNotificacionTitulo2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21SGNotificacionTitulo2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterSGNotificacionTituloDescription = StringUtil.Format( "%1 (%2)", "Titulo", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterSGNotificacionTituloDescription = StringUtil.Format( "%1 (%2)", "Titulo", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17SGNotificacionTitulo = AV21SGNotificacionTitulo2;
                     H7Y0( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterSGNotificacionTituloDescription, "")), 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17SGNotificacionTitulo, "")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "SGNOTIFICACIONTITULO") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25SGNotificacionTitulo3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SGNotificacionTitulo3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterSGNotificacionTituloDescription = StringUtil.Format( "%1 (%2)", "Titulo", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterSGNotificacionTituloDescription = StringUtil.Format( "%1 (%2)", "Titulo", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17SGNotificacionTitulo = AV25SGNotificacionTitulo3;
                        H7Y0( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterSGNotificacionTituloDescription, "")), 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17SGNotificacionTitulo, "")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFSGNotificacionID) && (0==AV32TFSGNotificacionID_To) ) )
         {
            H7Y0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("ID", 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFSGNotificacionID), "ZZZZZZZZZ9")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV49TFSGNotificacionID_To_Description = StringUtil.Format( "%1 (%2)", "ID", "Hasta", "", "", "", "", "", "", "");
            H7Y0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFSGNotificacionID_To_Description, "")), 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFSGNotificacionID_To), "ZZZZZZZZZ9")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSGNotificacionTitulo_Sel)) )
         {
            H7Y0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Titulo", 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFSGNotificacionTitulo_Sel, "")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSGNotificacionTitulo)) )
            {
               H7Y0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Titulo", 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFSGNotificacionTitulo, "")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSGNotificacionDescripcion_Sel)) )
         {
            H7Y0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descripción", 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFSGNotificacionDescripcion_Sel, "")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSGNotificacionDescripcion)) )
            {
               H7Y0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción", 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFSGNotificacionDescripcion, "")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (DateTime.MinValue==AV37TFSGNotificacionFecha) && (DateTime.MinValue==AV38TFSGNotificacionFecha_To) ) )
         {
            H7Y0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Hora", 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV37TFSGNotificacionFecha, "99/99/99 99:99"), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV50TFSGNotificacionFecha_To_Description = StringUtil.Format( "%1 (%2)", "Hora", "Hasta", "", "", "", "", "", "", "");
            H7Y0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFSGNotificacionFecha_To_Description, "")), 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV38TFSGNotificacionFecha_To, "99/99/99 99:99"), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSGNotificacionUsuario_Sel)) )
         {
            H7Y0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Usuario", 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFSGNotificacionUsuario_Sel, "")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSGNotificacionUsuario)) )
            {
               H7Y0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuario", 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFSGNotificacionUsuario, "")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSGNotificacionUsuarioDsc_Sel)) )
         {
            H7Y0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Usuario", 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFSGNotificacionUsuarioDsc_Sel, "")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSGNotificacionUsuarioDsc)) )
            {
               H7Y0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuario", 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFSGNotificacionUsuarioDsc, "")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         AV45TFSGNotificacionIconClass_Sels.FromJSonString(AV43TFSGNotificacionIconClass_SelsJson, null);
         if ( ! ( AV45TFSGNotificacionIconClass_Sels.Count == 0 ) )
         {
            AV53i = 1;
            AV70GXV1 = 1;
            while ( AV70GXV1 <= AV45TFSGNotificacionIconClass_Sels.Count )
            {
               AV46TFSGNotificacionIconClass_Sel = ((string)AV45TFSGNotificacionIconClass_Sels.Item(AV70GXV1));
               if ( AV53i == 1 )
               {
                  AV44TFSGNotificacionIconClass_SelDscs = "";
               }
               else
               {
                  AV44TFSGNotificacionIconClass_SelDscs += ", ";
               }
               AV51FilterTFSGNotificacionIconClass_SelValueDescription = gxdomainicononotificaciones.getDescription(context,AV46TFSGNotificacionIconClass_Sel);
               AV44TFSGNotificacionIconClass_SelDscs += AV51FilterTFSGNotificacionIconClass_SelValueDescription;
               AV53i = (long)(AV53i+1);
               AV70GXV1 = (int)(AV70GXV1+1);
            }
            H7Y0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Icon Class", 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFSGNotificacionIconClass_SelDscs, "")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV47TFSGNotificacionTUsuario) && (0==AV48TFSGNotificacionTUsuario_To) ) )
         {
            H7Y0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Usuarios", 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV47TFSGNotificacionTUsuario), "ZZZ9")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV52TFSGNotificacionTUsuario_To_Description = StringUtil.Format( "%1 (%2)", "Usuarios", "Hasta", "", "", "", "", "", "", "");
            H7Y0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFSGNotificacionTUsuario_To_Description, "")), 25, Gx_line+0, 171, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV48TFSGNotificacionTUsuario_To), "ZZZ9")), 171, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H7Y0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H7Y0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("ID", 30, Gx_line+10, 90, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Titulo", 94, Gx_line+10, 214, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descripción", 218, Gx_line+10, 340, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Hora", 344, Gx_line+10, 405, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Usuario", 409, Gx_line+10, 470, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Usuario", 474, Gx_line+10, 596, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Icon Class", 600, Gx_line+10, 722, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Usuarios", 726, Gx_line+10, 787, Gx_line+26, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV72Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV73Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = AV15SGNotificacionTitulo1;
         AV75Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV76Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV77Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = AV21SGNotificacionTitulo2;
         AV79Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV80Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV81Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = AV25SGNotificacionTitulo3;
         AV83Seguridad_notificacioneswwds_12_tfsgnotificacionid = AV31TFSGNotificacionID;
         AV84Seguridad_notificacioneswwds_13_tfsgnotificacionid_to = AV32TFSGNotificacionID_To;
         AV85Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = AV33TFSGNotificacionTitulo;
         AV86Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = AV34TFSGNotificacionTitulo_Sel;
         AV87Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = AV35TFSGNotificacionDescripcion;
         AV88Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = AV36TFSGNotificacionDescripcion_Sel;
         AV89Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = AV37TFSGNotificacionFecha;
         AV90Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = AV38TFSGNotificacionFecha_To;
         AV91Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = AV39TFSGNotificacionUsuario;
         AV92Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = AV40TFSGNotificacionUsuario_Sel;
         AV93Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = AV41TFSGNotificacionUsuarioDsc;
         AV94Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = AV42TFSGNotificacionUsuarioDsc_Sel;
         AV95Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = AV45TFSGNotificacionIconClass_Sels;
         AV96Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario = AV47TFSGNotificacionTUsuario;
         AV97Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to = AV48TFSGNotificacionTUsuario_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A2243SGNotificacionIconClass ,
                                              AV95Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                              AV72Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                              AV73Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                              AV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                              AV75Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                              AV76Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                              AV77Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                              AV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                              AV79Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                              AV80Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                              AV81Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                              AV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                              AV83Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                              AV84Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                              AV86Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                              AV85Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                              AV88Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                              AV87Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                              AV89Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                              AV90Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                              AV92Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                              AV91Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                              AV94Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                              AV93Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                              AV95Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels.Count ,
                                              AV96Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                              AV97Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                              A2238SGNotificacionTitulo ,
                                              A2237SGNotificacionID ,
                                              A2239SGNotificacionDescripcion ,
                                              A2240SGNotificacionFecha ,
                                              A2241SGNotificacionUsuario ,
                                              A2242SGNotificacionUsuarioDsc ,
                                              A2244SGNotificacionTUsuario ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV85Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = StringUtil.Concat( StringUtil.RTrim( AV85Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo), "%", "");
         lV87Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = StringUtil.Concat( StringUtil.RTrim( AV87Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion), "%", "");
         lV91Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = StringUtil.PadR( StringUtil.RTrim( AV91Seguridad_notificacioneswwds_20_tfsgnotificacionusuario), 10, "%");
         lV93Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = StringUtil.PadR( StringUtil.RTrim( AV93Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc), 100, "%");
         /* Using cursor P007Y2 */
         pr_default.execute(0, new Object[] {lV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, lV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, AV83Seguridad_notificacioneswwds_12_tfsgnotificacionid, AV84Seguridad_notificacioneswwds_13_tfsgnotificacionid_to, lV85Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo, AV86Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel, lV87Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion, AV88Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel, AV89Seguridad_notificacioneswwds_18_tfsgnotificacionfecha, AV90Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to, lV91Seguridad_notificacioneswwds_20_tfsgnotificacionusuario, AV92Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel, lV93Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc, AV94Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel, AV96Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario, AV97Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2244SGNotificacionTUsuario = P007Y2_A2244SGNotificacionTUsuario[0];
            A2243SGNotificacionIconClass = P007Y2_A2243SGNotificacionIconClass[0];
            A2242SGNotificacionUsuarioDsc = P007Y2_A2242SGNotificacionUsuarioDsc[0];
            A2241SGNotificacionUsuario = P007Y2_A2241SGNotificacionUsuario[0];
            A2240SGNotificacionFecha = P007Y2_A2240SGNotificacionFecha[0];
            A2239SGNotificacionDescripcion = P007Y2_A2239SGNotificacionDescripcion[0];
            A2237SGNotificacionID = P007Y2_A2237SGNotificacionID[0];
            A2238SGNotificacionTitulo = P007Y2_A2238SGNotificacionTitulo[0];
            A2242SGNotificacionUsuarioDsc = P007Y2_A2242SGNotificacionUsuarioDsc[0];
            AV12SGNotificacionIconClassDescription = gxdomainicononotificaciones.getDescription(context,A2243SGNotificacionIconClass);
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H7Y0( false, 63) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A2237SGNotificacionID), "ZZZZZZZZZ9")), 30, Gx_line+10, 90, Gx_line+52, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2238SGNotificacionTitulo, "")), 94, Gx_line+10, 214, Gx_line+52, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2239SGNotificacionDescripcion, "")), 218, Gx_line+10, 340, Gx_line+52, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A2240SGNotificacionFecha, "99/99/99 99:99"), 344, Gx_line+10, 405, Gx_line+52, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2241SGNotificacionUsuario, "")), 409, Gx_line+10, 470, Gx_line+52, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2242SGNotificacionUsuarioDsc, "")), 474, Gx_line+10, 596, Gx_line+52, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12SGNotificacionIconClassDescription, "")), 600, Gx_line+10, 722, Gx_line+52, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A2244SGNotificacionTUsuario), "ZZZ9")), 726, Gx_line+10, 787, Gx_line+52, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+62, 789, Gx_line+62, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+63);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("Seguridad.NotificacionesWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.NotificacionesWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Seguridad.NotificacionesWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV98GXV2 = 1;
         while ( AV98GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV98GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONID") == 0 )
            {
               AV31TFSGNotificacionID = (long)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV32TFSGNotificacionID_To = (long)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONTITULO") == 0 )
            {
               AV33TFSGNotificacionTitulo = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONTITULO_SEL") == 0 )
            {
               AV34TFSGNotificacionTitulo_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONDESCRIPCION") == 0 )
            {
               AV35TFSGNotificacionDescripcion = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONDESCRIPCION_SEL") == 0 )
            {
               AV36TFSGNotificacionDescripcion_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONFECHA") == 0 )
            {
               AV37TFSGNotificacionFecha = context.localUtil.CToT( AV30GridStateFilterValue.gxTpr_Value, 2);
               AV38TFSGNotificacionFecha_To = context.localUtil.CToT( AV30GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIO") == 0 )
            {
               AV39TFSGNotificacionUsuario = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIO_SEL") == 0 )
            {
               AV40TFSGNotificacionUsuario_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIODSC") == 0 )
            {
               AV41TFSGNotificacionUsuarioDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIODSC_SEL") == 0 )
            {
               AV42TFSGNotificacionUsuarioDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONICONCLASS_SEL") == 0 )
            {
               AV43TFSGNotificacionIconClass_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV45TFSGNotificacionIconClass_Sels.FromJSonString(AV43TFSGNotificacionIconClass_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONTUSUARIO") == 0 )
            {
               AV47TFSGNotificacionTUsuario = (short)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV48TFSGNotificacionTUsuario_To = (short)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV98GXV2 = (int)(AV98GXV2+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H7Y0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV62PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV59DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+39);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               AV57AppName = "DVelop Software Solutions";
               AV63Phone = "+1 550 8923";
               AV61Mail = "info@mail.com";
               AV65Website = "http://www.web.com";
               AV54AddressLine1 = "French Boulevard 2859";
               AV55AddressLine2 = "Downtown";
               AV56AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+127);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV64Title = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15SGNotificacionTitulo1 = "";
         AV16FilterSGNotificacionTituloDescription = "";
         AV17SGNotificacionTitulo = "";
         AV19DynamicFiltersSelector2 = "";
         AV21SGNotificacionTitulo2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25SGNotificacionTitulo3 = "";
         AV49TFSGNotificacionID_To_Description = "";
         AV34TFSGNotificacionTitulo_Sel = "";
         AV33TFSGNotificacionTitulo = "";
         AV36TFSGNotificacionDescripcion_Sel = "";
         AV35TFSGNotificacionDescripcion = "";
         AV37TFSGNotificacionFecha = (DateTime)(DateTime.MinValue);
         AV38TFSGNotificacionFecha_To = (DateTime)(DateTime.MinValue);
         AV50TFSGNotificacionFecha_To_Description = "";
         AV40TFSGNotificacionUsuario_Sel = "";
         AV39TFSGNotificacionUsuario = "";
         AV42TFSGNotificacionUsuarioDsc_Sel = "";
         AV41TFSGNotificacionUsuarioDsc = "";
         AV45TFSGNotificacionIconClass_Sels = new GxSimpleCollection<string>();
         AV43TFSGNotificacionIconClass_SelsJson = "";
         AV46TFSGNotificacionIconClass_Sel = "";
         AV44TFSGNotificacionIconClass_SelDscs = "";
         AV51FilterTFSGNotificacionIconClass_SelValueDescription = "";
         AV52TFSGNotificacionTUsuario_To_Description = "";
         AV72Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = "";
         AV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = "";
         AV76Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = "";
         AV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = "";
         AV80Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = "";
         AV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = "";
         AV85Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = "";
         AV86Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = "";
         AV87Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = "";
         AV88Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = "";
         AV89Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = (DateTime)(DateTime.MinValue);
         AV90Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = (DateTime)(DateTime.MinValue);
         AV91Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = "";
         AV92Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = "";
         AV93Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = "";
         AV94Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = "";
         AV95Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = new GxSimpleCollection<string>();
         scmdbuf = "";
         lV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = "";
         lV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = "";
         lV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = "";
         lV85Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = "";
         lV87Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = "";
         lV91Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = "";
         lV93Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = "";
         A2243SGNotificacionIconClass = "";
         A2238SGNotificacionTitulo = "";
         A2239SGNotificacionDescripcion = "";
         A2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         A2241SGNotificacionUsuario = "";
         A2242SGNotificacionUsuarioDsc = "";
         P007Y2_A2244SGNotificacionTUsuario = new short[1] ;
         P007Y2_A2243SGNotificacionIconClass = new string[] {""} ;
         P007Y2_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         P007Y2_A2241SGNotificacionUsuario = new string[] {""} ;
         P007Y2_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         P007Y2_A2239SGNotificacionDescripcion = new string[] {""} ;
         P007Y2_A2237SGNotificacionID = new long[1] ;
         P007Y2_A2238SGNotificacionTitulo = new string[] {""} ;
         AV12SGNotificacionIconClassDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV62PageInfo = "";
         AV59DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV57AppName = "";
         AV63Phone = "";
         AV61Mail = "";
         AV65Website = "";
         AV54AddressLine1 = "";
         AV55AddressLine2 = "";
         AV56AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.notificacioneswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P007Y2_A2244SGNotificacionTUsuario, P007Y2_A2243SGNotificacionIconClass, P007Y2_A2242SGNotificacionUsuarioDsc, P007Y2_A2241SGNotificacionUsuario, P007Y2_A2240SGNotificacionFecha, P007Y2_A2239SGNotificacionDescripcion, P007Y2_A2237SGNotificacionID, P007Y2_A2238SGNotificacionTitulo
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV14DynamicFiltersOperator1 ;
      private short AV20DynamicFiltersOperator2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV47TFSGNotificacionTUsuario ;
      private short AV48TFSGNotificacionTUsuario_To ;
      private short AV73Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ;
      private short AV77Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ;
      private short AV81Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ;
      private short AV96Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ;
      private short AV97Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ;
      private short A2244SGNotificacionTUsuario ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV70GXV1 ;
      private int AV95Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count ;
      private int AV98GXV2 ;
      private long AV31TFSGNotificacionID ;
      private long AV32TFSGNotificacionID_To ;
      private long AV53i ;
      private long AV83Seguridad_notificacioneswwds_12_tfsgnotificacionid ;
      private long AV84Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ;
      private long A2237SGNotificacionID ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV40TFSGNotificacionUsuario_Sel ;
      private string AV39TFSGNotificacionUsuario ;
      private string AV42TFSGNotificacionUsuarioDsc_Sel ;
      private string AV41TFSGNotificacionUsuarioDsc ;
      private string AV91Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ;
      private string AV92Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ;
      private string AV93Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ;
      private string AV94Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ;
      private string scmdbuf ;
      private string lV91Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ;
      private string lV93Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ;
      private string A2241SGNotificacionUsuario ;
      private string A2242SGNotificacionUsuarioDsc ;
      private DateTime AV37TFSGNotificacionFecha ;
      private DateTime AV38TFSGNotificacionFecha_To ;
      private DateTime AV89Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ;
      private DateTime AV90Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ;
      private DateTime A2240SGNotificacionFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV75Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ;
      private bool AV79Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV43TFSGNotificacionIconClass_SelsJson ;
      private string AV64Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15SGNotificacionTitulo1 ;
      private string AV16FilterSGNotificacionTituloDescription ;
      private string AV17SGNotificacionTitulo ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21SGNotificacionTitulo2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25SGNotificacionTitulo3 ;
      private string AV49TFSGNotificacionID_To_Description ;
      private string AV34TFSGNotificacionTitulo_Sel ;
      private string AV33TFSGNotificacionTitulo ;
      private string AV36TFSGNotificacionDescripcion_Sel ;
      private string AV35TFSGNotificacionDescripcion ;
      private string AV50TFSGNotificacionFecha_To_Description ;
      private string AV46TFSGNotificacionIconClass_Sel ;
      private string AV44TFSGNotificacionIconClass_SelDscs ;
      private string AV51FilterTFSGNotificacionIconClass_SelValueDescription ;
      private string AV52TFSGNotificacionTUsuario_To_Description ;
      private string AV72Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ;
      private string AV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ;
      private string AV76Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ;
      private string AV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ;
      private string AV80Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ;
      private string AV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ;
      private string AV85Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ;
      private string AV86Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ;
      private string AV87Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ;
      private string AV88Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ;
      private string lV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ;
      private string lV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ;
      private string lV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ;
      private string lV85Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ;
      private string lV87Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ;
      private string A2243SGNotificacionIconClass ;
      private string A2238SGNotificacionTitulo ;
      private string A2239SGNotificacionDescripcion ;
      private string AV12SGNotificacionIconClassDescription ;
      private string AV62PageInfo ;
      private string AV59DateInfo ;
      private string AV57AppName ;
      private string AV63Phone ;
      private string AV61Mail ;
      private string AV65Website ;
      private string AV54AddressLine1 ;
      private string AV55AddressLine2 ;
      private string AV56AddressLine3 ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P007Y2_A2244SGNotificacionTUsuario ;
      private string[] P007Y2_A2243SGNotificacionIconClass ;
      private string[] P007Y2_A2242SGNotificacionUsuarioDsc ;
      private string[] P007Y2_A2241SGNotificacionUsuario ;
      private DateTime[] P007Y2_A2240SGNotificacionFecha ;
      private string[] P007Y2_A2239SGNotificacionDescripcion ;
      private long[] P007Y2_A2237SGNotificacionID ;
      private string[] P007Y2_A2238SGNotificacionTitulo ;
      private GxSimpleCollection<string> AV45TFSGNotificacionIconClass_Sels ;
      private GxSimpleCollection<string> AV95Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class notificacioneswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007Y2( IGxContext context ,
                                             string A2243SGNotificacionIconClass ,
                                             GxSimpleCollection<string> AV95Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                             string AV72Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                             short AV73Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                             string AV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                             bool AV75Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                             string AV76Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                             short AV77Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                             string AV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                             bool AV79Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                             string AV80Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                             short AV81Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                             string AV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                             long AV83Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                             long AV84Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                             string AV86Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                             string AV85Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                             string AV88Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                             string AV87Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                             DateTime AV89Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                             DateTime AV90Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                             string AV92Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                             string AV91Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                             string AV94Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                             string AV93Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                             int AV95Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count ,
                                             short AV96Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                             short AV97Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                             string A2238SGNotificacionTitulo ,
                                             long A2237SGNotificacionID ,
                                             string A2239SGNotificacionDescripcion ,
                                             DateTime A2240SGNotificacionFecha ,
                                             string A2241SGNotificacionUsuario ,
                                             string A2242SGNotificacionUsuarioDsc ,
                                             short A2244SGNotificacionTUsuario ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[SGNotificacionTUsuario], T1.[SGNotificacionIconClass], T2.[UsuNom] AS SGNotificacionUsuarioDsc, T1.[SGNotificacionUsuario] AS SGNotificacionUsuario, T1.[SGNotificacionFecha], T1.[SGNotificacionDescripcion], T1.[SGNotificacionID], T1.[SGNotificacionTitulo] FROM ([SGNOTIFICACIONES] T1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = T1.[SGNotificacionUsuario])";
         if ( ( StringUtil.StrCmp(AV72Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV73Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV73Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV75Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV77Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV75Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV77Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV79Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV81Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV79Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV81Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV83Seguridad_notificacioneswwds_12_tfsgnotificacionid) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] >= @AV83Seguridad_notificacioneswwds_12_tfsgnotificacionid)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV84Seguridad_notificacioneswwds_13_tfsgnotificacionid_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] <= @AV84Seguridad_notificacioneswwds_13_tfsgnotificacionid_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV85Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] = @AV86Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] like @lV87Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] = @AV88Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Seguridad_notificacioneswwds_18_tfsgnotificacionfecha) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] >= @AV89Seguridad_notificacioneswwds_18_tfsgnotificacionfecha)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] <= @AV90Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] like @lV91Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] = @AV92Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] like @lV93Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] = @AV94Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV95Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV95Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels, "T1.[SGNotificacionIconClass] IN (", ")")+")");
         }
         if ( ! (0==AV96Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] >= @AV96Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (0==AV97Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] <= @AV97Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionTitulo]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionTitulo] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionID]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionID] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionDescripcion]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionDescripcion] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionFecha]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionFecha] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionUsuario]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionUsuario] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[UsuNom]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[UsuNom] DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionIconClass]";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionIconClass] DESC";
         }
         else if ( ( AV10OrderedBy == 8 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionTUsuario]";
         }
         else if ( ( AV10OrderedBy == 8 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionTUsuario] DESC";
         }
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007Y2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (bool)dynConstraints[36] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP007Y2;
          prmP007Y2 = new Object[] {
          new ParDef("@lV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV74Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV78Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@lV82Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@AV83Seguridad_notificacioneswwds_12_tfsgnotificacionid",GXType.Decimal,10,0) ,
          new ParDef("@AV84Seguridad_notificacioneswwds_13_tfsgnotificacionid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV85Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo",GXType.NVarChar,100,0) ,
          new ParDef("@AV86Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV87Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion",GXType.NVarChar,200,0) ,
          new ParDef("@AV88Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV89Seguridad_notificacioneswwds_18_tfsgnotificacionfecha",GXType.DateTime,8,5) ,
          new ParDef("@AV90Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV91Seguridad_notificacioneswwds_20_tfsgnotificacionusuario",GXType.NChar,10,0) ,
          new ParDef("@AV92Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel",GXType.NChar,10,0) ,
          new ParDef("@lV93Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc",GXType.NChar,100,0) ,
          new ParDef("@AV94Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV96Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario",GXType.Int16,4,0) ,
          new ParDef("@AV97Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Y2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
       }
    }

 }

}
