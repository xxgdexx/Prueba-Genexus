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
namespace GeneXus.Programs.bancos {
   public class entregarendirwwexportreport : GXWebProcedure
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

      public entregarendirwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public entregarendirwwexportreport( IGxContext context )
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
         entregarendirwwexportreport objentregarendirwwexportreport;
         objentregarendirwwexportreport = new entregarendirwwexportreport();
         objentregarendirwwexportreport.context.SetSubmitInitialConfig(context);
         objentregarendirwwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objentregarendirwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((entregarendirwwexportreport)stateInfo).executePrivate();
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
            AV63Title = "Lista de Entrega Rendir Cuenta";
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
            H5U0( true, 0) ;
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
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "ENTDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV15EntDsc1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15EntDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterEntDscDescription = StringUtil.Format( "%1 (%2)", "Entrega a Rendir", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterEntDscDescription = StringUtil.Format( "%1 (%2)", "Entrega a Rendir", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17EntDsc = AV15EntDsc1;
                  H5U0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEntDscDescription, "")), 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EntDsc, "")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CUEDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV18CueDsc1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18CueDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV19FilterCueDscDescription = StringUtil.Format( "%1 (%2)", "Descripción de Cuenta", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV19FilterCueDscDescription = StringUtil.Format( "%1 (%2)", "Descripción de Cuenta", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV20CueDsc = AV18CueDsc1;
                  H5U0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterCueDscDescription, "")), 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20CueDsc, "")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "ENTDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV24EntDsc2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24EntDsc2)) )
                  {
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterEntDscDescription = StringUtil.Format( "%1 (%2)", "Entrega a Rendir", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterEntDscDescription = StringUtil.Format( "%1 (%2)", "Entrega a Rendir", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17EntDsc = AV24EntDsc2;
                     H5U0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEntDscDescription, "")), 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EntDsc, "")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CUEDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV25CueDsc2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CueDsc2)) )
                  {
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV19FilterCueDscDescription = StringUtil.Format( "%1 (%2)", "Descripción de Cuenta", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV19FilterCueDscDescription = StringUtil.Format( "%1 (%2)", "Descripción de Cuenta", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV20CueDsc = AV25CueDsc2;
                     H5U0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterCueDscDescription, "")), 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20CueDsc, "")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "ENTDSC") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV29EntDsc3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29EntDsc3)) )
                     {
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterEntDscDescription = StringUtil.Format( "%1 (%2)", "Entrega a Rendir", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterEntDscDescription = StringUtil.Format( "%1 (%2)", "Entrega a Rendir", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17EntDsc = AV29EntDsc3;
                        H5U0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEntDscDescription, "")), 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EntDsc, "")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CUEDSC") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30CueDsc3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30CueDsc3)) )
                     {
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV19FilterCueDscDescription = StringUtil.Format( "%1 (%2)", "Descripción de Cuenta", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV19FilterCueDscDescription = StringUtil.Format( "%1 (%2)", "Descripción de Cuenta", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV20CueDsc = AV30CueDsc3;
                        H5U0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterCueDscDescription, "")), 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20CueDsc, "")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV36TFEntCod) && (0==AV37TFEntCod_To) ) )
         {
            H5U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36TFEntCod), "ZZZZZ9")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV50TFEntCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H5U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFEntCod_To_Description, "")), 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFEntCod_To), "ZZZZZ9")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFEntDsc_Sel)) )
         {
            H5U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Entrega a Rendir", 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFEntDsc_Sel, "")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEntDsc)) )
            {
               H5U0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Entrega a Rendir", 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFEntDsc, "")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFCueCod_Sel)) )
         {
            H5U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFCueCod_Sel, "")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFCueCod)) )
            {
               H5U0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFCueCod, "")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCueDsc_Sel)) )
         {
            H5U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descripción de Cuenta", 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFCueDsc_Sel, "")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCueDsc)) )
            {
               H5U0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción de Cuenta", 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFCueDsc, "")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV48TFEntSts_Sels.FromJSonString(AV46TFEntSts_SelsJson, null);
         if ( ! ( AV48TFEntSts_Sels.Count == 0 ) )
         {
            AV52i = 1;
            AV69GXV1 = 1;
            while ( AV69GXV1 <= AV48TFEntSts_Sels.Count )
            {
               AV49TFEntSts_Sel = (short)(AV48TFEntSts_Sels.GetNumeric(AV69GXV1));
               if ( AV52i == 1 )
               {
                  AV47TFEntSts_SelDscs = "";
               }
               else
               {
                  AV47TFEntSts_SelDscs += ", ";
               }
               if ( AV49TFEntSts_Sel == 1 )
               {
                  AV51FilterTFEntSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV49TFEntSts_Sel == 0 )
               {
                  AV51FilterTFEntSts_SelValueDescription = "INACTIVO";
               }
               AV47TFEntSts_SelDscs += AV51FilterTFEntSts_SelValueDescription;
               AV52i = (long)(AV52i+1);
               AV69GXV1 = (int)(AV69GXV1+1);
            }
            H5U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 256, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFEntSts_SelDscs, "")), 256, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H5U0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H5U0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 122, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Entrega a Rendir", 126, Gx_line+10, 310, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Cuenta Contable", 314, Gx_line+10, 407, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descripción de Cuenta", 411, Gx_line+10, 597, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 601, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV71Bancos_entregarendirwwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV72Bancos_entregarendirwwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV73Bancos_entregarendirwwds_3_entdsc1 = AV15EntDsc1;
         AV74Bancos_entregarendirwwds_4_cuedsc1 = AV18CueDsc1;
         AV75Bancos_entregarendirwwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV76Bancos_entregarendirwwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV77Bancos_entregarendirwwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV78Bancos_entregarendirwwds_8_entdsc2 = AV24EntDsc2;
         AV79Bancos_entregarendirwwds_9_cuedsc2 = AV25CueDsc2;
         AV80Bancos_entregarendirwwds_10_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV81Bancos_entregarendirwwds_11_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV82Bancos_entregarendirwwds_12_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV83Bancos_entregarendirwwds_13_entdsc3 = AV29EntDsc3;
         AV84Bancos_entregarendirwwds_14_cuedsc3 = AV30CueDsc3;
         AV85Bancos_entregarendirwwds_15_tfentcod = AV36TFEntCod;
         AV86Bancos_entregarendirwwds_16_tfentcod_to = AV37TFEntCod_To;
         AV87Bancos_entregarendirwwds_17_tfentdsc = AV38TFEntDsc;
         AV88Bancos_entregarendirwwds_18_tfentdsc_sel = AV39TFEntDsc_Sel;
         AV89Bancos_entregarendirwwds_19_tfcuecod = AV42TFCueCod;
         AV90Bancos_entregarendirwwds_20_tfcuecod_sel = AV43TFCueCod_Sel;
         AV91Bancos_entregarendirwwds_21_tfcuedsc = AV44TFCueDsc;
         AV92Bancos_entregarendirwwds_22_tfcuedsc_sel = AV45TFCueDsc_Sel;
         AV93Bancos_entregarendirwwds_23_tfentsts_sels = AV48TFEntSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A973EntSts ,
                                              AV93Bancos_entregarendirwwds_23_tfentsts_sels ,
                                              AV71Bancos_entregarendirwwds_1_dynamicfiltersselector1 ,
                                              AV72Bancos_entregarendirwwds_2_dynamicfiltersoperator1 ,
                                              AV73Bancos_entregarendirwwds_3_entdsc1 ,
                                              AV74Bancos_entregarendirwwds_4_cuedsc1 ,
                                              AV75Bancos_entregarendirwwds_5_dynamicfiltersenabled2 ,
                                              AV76Bancos_entregarendirwwds_6_dynamicfiltersselector2 ,
                                              AV77Bancos_entregarendirwwds_7_dynamicfiltersoperator2 ,
                                              AV78Bancos_entregarendirwwds_8_entdsc2 ,
                                              AV79Bancos_entregarendirwwds_9_cuedsc2 ,
                                              AV80Bancos_entregarendirwwds_10_dynamicfiltersenabled3 ,
                                              AV81Bancos_entregarendirwwds_11_dynamicfiltersselector3 ,
                                              AV82Bancos_entregarendirwwds_12_dynamicfiltersoperator3 ,
                                              AV83Bancos_entregarendirwwds_13_entdsc3 ,
                                              AV84Bancos_entregarendirwwds_14_cuedsc3 ,
                                              AV85Bancos_entregarendirwwds_15_tfentcod ,
                                              AV86Bancos_entregarendirwwds_16_tfentcod_to ,
                                              AV88Bancos_entregarendirwwds_18_tfentdsc_sel ,
                                              AV87Bancos_entregarendirwwds_17_tfentdsc ,
                                              AV90Bancos_entregarendirwwds_20_tfcuecod_sel ,
                                              AV89Bancos_entregarendirwwds_19_tfcuecod ,
                                              AV92Bancos_entregarendirwwds_22_tfcuedsc_sel ,
                                              AV91Bancos_entregarendirwwds_21_tfcuedsc ,
                                              AV93Bancos_entregarendirwwds_23_tfentsts_sels.Count ,
                                              A972EntDsc ,
                                              A860CueDsc ,
                                              A365EntCod ,
                                              A91CueCod ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV73Bancos_entregarendirwwds_3_entdsc1 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_entregarendirwwds_3_entdsc1), 100, "%");
         lV73Bancos_entregarendirwwds_3_entdsc1 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_entregarendirwwds_3_entdsc1), 100, "%");
         lV74Bancos_entregarendirwwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_entregarendirwwds_4_cuedsc1), 100, "%");
         lV74Bancos_entregarendirwwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_entregarendirwwds_4_cuedsc1), 100, "%");
         lV78Bancos_entregarendirwwds_8_entdsc2 = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_entregarendirwwds_8_entdsc2), 100, "%");
         lV78Bancos_entregarendirwwds_8_entdsc2 = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_entregarendirwwds_8_entdsc2), 100, "%");
         lV79Bancos_entregarendirwwds_9_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV79Bancos_entregarendirwwds_9_cuedsc2), 100, "%");
         lV79Bancos_entregarendirwwds_9_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV79Bancos_entregarendirwwds_9_cuedsc2), 100, "%");
         lV83Bancos_entregarendirwwds_13_entdsc3 = StringUtil.PadR( StringUtil.RTrim( AV83Bancos_entregarendirwwds_13_entdsc3), 100, "%");
         lV83Bancos_entregarendirwwds_13_entdsc3 = StringUtil.PadR( StringUtil.RTrim( AV83Bancos_entregarendirwwds_13_entdsc3), 100, "%");
         lV84Bancos_entregarendirwwds_14_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV84Bancos_entregarendirwwds_14_cuedsc3), 100, "%");
         lV84Bancos_entregarendirwwds_14_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV84Bancos_entregarendirwwds_14_cuedsc3), 100, "%");
         lV87Bancos_entregarendirwwds_17_tfentdsc = StringUtil.PadR( StringUtil.RTrim( AV87Bancos_entregarendirwwds_17_tfentdsc), 100, "%");
         lV89Bancos_entregarendirwwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV89Bancos_entregarendirwwds_19_tfcuecod), 15, "%");
         lV91Bancos_entregarendirwwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV91Bancos_entregarendirwwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005U2 */
         pr_default.execute(0, new Object[] {lV73Bancos_entregarendirwwds_3_entdsc1, lV73Bancos_entregarendirwwds_3_entdsc1, lV74Bancos_entregarendirwwds_4_cuedsc1, lV74Bancos_entregarendirwwds_4_cuedsc1, lV78Bancos_entregarendirwwds_8_entdsc2, lV78Bancos_entregarendirwwds_8_entdsc2, lV79Bancos_entregarendirwwds_9_cuedsc2, lV79Bancos_entregarendirwwds_9_cuedsc2, lV83Bancos_entregarendirwwds_13_entdsc3, lV83Bancos_entregarendirwwds_13_entdsc3, lV84Bancos_entregarendirwwds_14_cuedsc3, lV84Bancos_entregarendirwwds_14_cuedsc3, AV85Bancos_entregarendirwwds_15_tfentcod, AV86Bancos_entregarendirwwds_16_tfentcod_to, lV87Bancos_entregarendirwwds_17_tfentdsc, AV88Bancos_entregarendirwwds_18_tfentdsc_sel, lV89Bancos_entregarendirwwds_19_tfcuecod, AV90Bancos_entregarendirwwds_20_tfcuecod_sel, lV91Bancos_entregarendirwwds_21_tfcuedsc, AV92Bancos_entregarendirwwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A973EntSts = P005U2_A973EntSts[0];
            A91CueCod = P005U2_A91CueCod[0];
            A365EntCod = P005U2_A365EntCod[0];
            A860CueDsc = P005U2_A860CueDsc[0];
            A972EntDsc = P005U2_A972EntDsc[0];
            A860CueDsc = P005U2_A860CueDsc[0];
            if ( A973EntSts == 1 )
            {
               AV12EntStsDescription = "ACTIVO";
            }
            else if ( A973EntSts == 0 )
            {
               AV12EntStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H5U0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A365EntCod), "ZZZZZ9")), 30, Gx_line+10, 122, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A972EntDsc, "")), 126, Gx_line+10, 310, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), 314, Gx_line+10, 407, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A860CueDsc, "")), 411, Gx_line+10, 597, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12EntStsDescription, "")), 601, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+36);
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
         if ( StringUtil.StrCmp(AV32Session.Get("Bancos.EntregaRendirWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.EntregaRendirWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("Bancos.EntregaRendirWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV94GXV2 = 1;
         while ( AV94GXV2 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV94GXV2));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFENTCOD") == 0 )
            {
               AV36TFEntCod = (int)(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."));
               AV37TFEntCod_To = (int)(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFENTDSC") == 0 )
            {
               AV38TFEntDsc = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFENTDSC_SEL") == 0 )
            {
               AV39TFEntDsc_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV42TFCueCod = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV43TFCueCod_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV44TFCueDsc = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV45TFCueDsc_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFENTSTS_SEL") == 0 )
            {
               AV46TFEntSts_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV48TFEntSts_Sels.FromJSonString(AV46TFEntSts_SelsJson, null);
            }
            AV94GXV2 = (int)(AV94GXV2+1);
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

      protected void H5U0( bool bFoot ,
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
                  AV61PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV58DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
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
               AV56AppName = "DVelop Software Solutions";
               AV62Phone = "+1 550 8923";
               AV60Mail = "info@mail.com";
               AV64Website = "http://www.web.com";
               AV53AddressLine1 = "French Boulevard 2859";
               AV54AddressLine2 = "Downtown";
               AV55AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+128);
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
         AV63Title = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15EntDsc1 = "";
         AV16FilterEntDscDescription = "";
         AV17EntDsc = "";
         AV18CueDsc1 = "";
         AV19FilterCueDscDescription = "";
         AV20CueDsc = "";
         AV22DynamicFiltersSelector2 = "";
         AV24EntDsc2 = "";
         AV25CueDsc2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29EntDsc3 = "";
         AV30CueDsc3 = "";
         AV50TFEntCod_To_Description = "";
         AV39TFEntDsc_Sel = "";
         AV38TFEntDsc = "";
         AV43TFCueCod_Sel = "";
         AV42TFCueCod = "";
         AV45TFCueDsc_Sel = "";
         AV44TFCueDsc = "";
         AV48TFEntSts_Sels = new GxSimpleCollection<short>();
         AV46TFEntSts_SelsJson = "";
         AV47TFEntSts_SelDscs = "";
         AV51FilterTFEntSts_SelValueDescription = "";
         AV71Bancos_entregarendirwwds_1_dynamicfiltersselector1 = "";
         AV73Bancos_entregarendirwwds_3_entdsc1 = "";
         AV74Bancos_entregarendirwwds_4_cuedsc1 = "";
         AV76Bancos_entregarendirwwds_6_dynamicfiltersselector2 = "";
         AV78Bancos_entregarendirwwds_8_entdsc2 = "";
         AV79Bancos_entregarendirwwds_9_cuedsc2 = "";
         AV81Bancos_entregarendirwwds_11_dynamicfiltersselector3 = "";
         AV83Bancos_entregarendirwwds_13_entdsc3 = "";
         AV84Bancos_entregarendirwwds_14_cuedsc3 = "";
         AV87Bancos_entregarendirwwds_17_tfentdsc = "";
         AV88Bancos_entregarendirwwds_18_tfentdsc_sel = "";
         AV89Bancos_entregarendirwwds_19_tfcuecod = "";
         AV90Bancos_entregarendirwwds_20_tfcuecod_sel = "";
         AV91Bancos_entregarendirwwds_21_tfcuedsc = "";
         AV92Bancos_entregarendirwwds_22_tfcuedsc_sel = "";
         AV93Bancos_entregarendirwwds_23_tfentsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV73Bancos_entregarendirwwds_3_entdsc1 = "";
         lV74Bancos_entregarendirwwds_4_cuedsc1 = "";
         lV78Bancos_entregarendirwwds_8_entdsc2 = "";
         lV79Bancos_entregarendirwwds_9_cuedsc2 = "";
         lV83Bancos_entregarendirwwds_13_entdsc3 = "";
         lV84Bancos_entregarendirwwds_14_cuedsc3 = "";
         lV87Bancos_entregarendirwwds_17_tfentdsc = "";
         lV89Bancos_entregarendirwwds_19_tfcuecod = "";
         lV91Bancos_entregarendirwwds_21_tfcuedsc = "";
         A972EntDsc = "";
         A860CueDsc = "";
         A91CueCod = "";
         P005U2_A973EntSts = new short[1] ;
         P005U2_A91CueCod = new string[] {""} ;
         P005U2_A365EntCod = new int[1] ;
         P005U2_A860CueDsc = new string[] {""} ;
         P005U2_A972EntDsc = new string[] {""} ;
         AV12EntStsDescription = "";
         AV32Session = context.GetSession();
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV61PageInfo = "";
         AV58DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV56AppName = "";
         AV62Phone = "";
         AV60Mail = "";
         AV64Website = "";
         AV53AddressLine1 = "";
         AV54AddressLine2 = "";
         AV55AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.entregarendirwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P005U2_A973EntSts, P005U2_A91CueCod, P005U2_A365EntCod, P005U2_A860CueDsc, P005U2_A972EntDsc
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
      private short AV23DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV49TFEntSts_Sel ;
      private short AV72Bancos_entregarendirwwds_2_dynamicfiltersoperator1 ;
      private short AV77Bancos_entregarendirwwds_7_dynamicfiltersoperator2 ;
      private short AV82Bancos_entregarendirwwds_12_dynamicfiltersoperator3 ;
      private short A973EntSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV36TFEntCod ;
      private int AV37TFEntCod_To ;
      private int AV69GXV1 ;
      private int AV85Bancos_entregarendirwwds_15_tfentcod ;
      private int AV86Bancos_entregarendirwwds_16_tfentcod_to ;
      private int AV93Bancos_entregarendirwwds_23_tfentsts_sels_Count ;
      private int A365EntCod ;
      private int AV94GXV2 ;
      private long AV52i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15EntDsc1 ;
      private string AV17EntDsc ;
      private string AV18CueDsc1 ;
      private string AV20CueDsc ;
      private string AV24EntDsc2 ;
      private string AV25CueDsc2 ;
      private string AV29EntDsc3 ;
      private string AV30CueDsc3 ;
      private string AV39TFEntDsc_Sel ;
      private string AV38TFEntDsc ;
      private string AV43TFCueCod_Sel ;
      private string AV42TFCueCod ;
      private string AV45TFCueDsc_Sel ;
      private string AV44TFCueDsc ;
      private string AV73Bancos_entregarendirwwds_3_entdsc1 ;
      private string AV74Bancos_entregarendirwwds_4_cuedsc1 ;
      private string AV78Bancos_entregarendirwwds_8_entdsc2 ;
      private string AV79Bancos_entregarendirwwds_9_cuedsc2 ;
      private string AV83Bancos_entregarendirwwds_13_entdsc3 ;
      private string AV84Bancos_entregarendirwwds_14_cuedsc3 ;
      private string AV87Bancos_entregarendirwwds_17_tfentdsc ;
      private string AV88Bancos_entregarendirwwds_18_tfentdsc_sel ;
      private string AV89Bancos_entregarendirwwds_19_tfcuecod ;
      private string AV90Bancos_entregarendirwwds_20_tfcuecod_sel ;
      private string AV91Bancos_entregarendirwwds_21_tfcuedsc ;
      private string AV92Bancos_entregarendirwwds_22_tfcuedsc_sel ;
      private string scmdbuf ;
      private string lV73Bancos_entregarendirwwds_3_entdsc1 ;
      private string lV74Bancos_entregarendirwwds_4_cuedsc1 ;
      private string lV78Bancos_entregarendirwwds_8_entdsc2 ;
      private string lV79Bancos_entregarendirwwds_9_cuedsc2 ;
      private string lV83Bancos_entregarendirwwds_13_entdsc3 ;
      private string lV84Bancos_entregarendirwwds_14_cuedsc3 ;
      private string lV87Bancos_entregarendirwwds_17_tfentdsc ;
      private string lV89Bancos_entregarendirwwds_19_tfcuecod ;
      private string lV91Bancos_entregarendirwwds_21_tfcuedsc ;
      private string A972EntDsc ;
      private string A860CueDsc ;
      private string A91CueCod ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV75Bancos_entregarendirwwds_5_dynamicfiltersenabled2 ;
      private bool AV80Bancos_entregarendirwwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV46TFEntSts_SelsJson ;
      private string AV63Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterEntDscDescription ;
      private string AV19FilterCueDscDescription ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV50TFEntCod_To_Description ;
      private string AV47TFEntSts_SelDscs ;
      private string AV51FilterTFEntSts_SelValueDescription ;
      private string AV71Bancos_entregarendirwwds_1_dynamicfiltersselector1 ;
      private string AV76Bancos_entregarendirwwds_6_dynamicfiltersselector2 ;
      private string AV81Bancos_entregarendirwwds_11_dynamicfiltersselector3 ;
      private string AV12EntStsDescription ;
      private string AV61PageInfo ;
      private string AV58DateInfo ;
      private string AV56AppName ;
      private string AV62Phone ;
      private string AV60Mail ;
      private string AV64Website ;
      private string AV53AddressLine1 ;
      private string AV54AddressLine2 ;
      private string AV55AddressLine3 ;
      private GxSimpleCollection<short> AV48TFEntSts_Sels ;
      private GxSimpleCollection<short> AV93Bancos_entregarendirwwds_23_tfentsts_sels ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005U2_A973EntSts ;
      private string[] P005U2_A91CueCod ;
      private int[] P005U2_A365EntCod ;
      private string[] P005U2_A860CueDsc ;
      private string[] P005U2_A972EntDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
   }

   public class entregarendirwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005U2( IGxContext context ,
                                             short A973EntSts ,
                                             GxSimpleCollection<short> AV93Bancos_entregarendirwwds_23_tfentsts_sels ,
                                             string AV71Bancos_entregarendirwwds_1_dynamicfiltersselector1 ,
                                             short AV72Bancos_entregarendirwwds_2_dynamicfiltersoperator1 ,
                                             string AV73Bancos_entregarendirwwds_3_entdsc1 ,
                                             string AV74Bancos_entregarendirwwds_4_cuedsc1 ,
                                             bool AV75Bancos_entregarendirwwds_5_dynamicfiltersenabled2 ,
                                             string AV76Bancos_entregarendirwwds_6_dynamicfiltersselector2 ,
                                             short AV77Bancos_entregarendirwwds_7_dynamicfiltersoperator2 ,
                                             string AV78Bancos_entregarendirwwds_8_entdsc2 ,
                                             string AV79Bancos_entregarendirwwds_9_cuedsc2 ,
                                             bool AV80Bancos_entregarendirwwds_10_dynamicfiltersenabled3 ,
                                             string AV81Bancos_entregarendirwwds_11_dynamicfiltersselector3 ,
                                             short AV82Bancos_entregarendirwwds_12_dynamicfiltersoperator3 ,
                                             string AV83Bancos_entregarendirwwds_13_entdsc3 ,
                                             string AV84Bancos_entregarendirwwds_14_cuedsc3 ,
                                             int AV85Bancos_entregarendirwwds_15_tfentcod ,
                                             int AV86Bancos_entregarendirwwds_16_tfentcod_to ,
                                             string AV88Bancos_entregarendirwwds_18_tfentdsc_sel ,
                                             string AV87Bancos_entregarendirwwds_17_tfentdsc ,
                                             string AV90Bancos_entregarendirwwds_20_tfcuecod_sel ,
                                             string AV89Bancos_entregarendirwwds_19_tfcuecod ,
                                             string AV92Bancos_entregarendirwwds_22_tfcuedsc_sel ,
                                             string AV91Bancos_entregarendirwwds_21_tfcuedsc ,
                                             int AV93Bancos_entregarendirwwds_23_tfentsts_sels_Count ,
                                             string A972EntDsc ,
                                             string A860CueDsc ,
                                             int A365EntCod ,
                                             string A91CueCod ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[EntSts], T1.[CueCod], T1.[EntCod], T2.[CueDsc], T1.[EntDsc] FROM ([TSENTREGAS] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV71Bancos_entregarendirwwds_1_dynamicfiltersselector1, "ENTDSC") == 0 ) && ( AV72Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_entregarendirwwds_3_entdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV73Bancos_entregarendirwwds_3_entdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Bancos_entregarendirwwds_1_dynamicfiltersselector1, "ENTDSC") == 0 ) && ( AV72Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_entregarendirwwds_3_entdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV73Bancos_entregarendirwwds_3_entdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Bancos_entregarendirwwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV72Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_entregarendirwwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV74Bancos_entregarendirwwds_4_cuedsc1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Bancos_entregarendirwwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV72Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_entregarendirwwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV74Bancos_entregarendirwwds_4_cuedsc1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV75Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Bancos_entregarendirwwds_6_dynamicfiltersselector2, "ENTDSC") == 0 ) && ( AV77Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_entregarendirwwds_8_entdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV78Bancos_entregarendirwwds_8_entdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV75Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Bancos_entregarendirwwds_6_dynamicfiltersselector2, "ENTDSC") == 0 ) && ( AV77Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_entregarendirwwds_8_entdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV78Bancos_entregarendirwwds_8_entdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV75Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Bancos_entregarendirwwds_6_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV77Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_entregarendirwwds_9_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV79Bancos_entregarendirwwds_9_cuedsc2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV75Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Bancos_entregarendirwwds_6_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV77Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_entregarendirwwds_9_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV79Bancos_entregarendirwwds_9_cuedsc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV80Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Bancos_entregarendirwwds_11_dynamicfiltersselector3, "ENTDSC") == 0 ) && ( AV82Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Bancos_entregarendirwwds_13_entdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV83Bancos_entregarendirwwds_13_entdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV80Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Bancos_entregarendirwwds_11_dynamicfiltersselector3, "ENTDSC") == 0 ) && ( AV82Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Bancos_entregarendirwwds_13_entdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV83Bancos_entregarendirwwds_13_entdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV80Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Bancos_entregarendirwwds_11_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV82Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Bancos_entregarendirwwds_14_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV84Bancos_entregarendirwwds_14_cuedsc3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV80Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Bancos_entregarendirwwds_11_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV82Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Bancos_entregarendirwwds_14_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV84Bancos_entregarendirwwds_14_cuedsc3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV85Bancos_entregarendirwwds_15_tfentcod) )
         {
            AddWhere(sWhereString, "(T1.[EntCod] >= @AV85Bancos_entregarendirwwds_15_tfentcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV86Bancos_entregarendirwwds_16_tfentcod_to) )
         {
            AddWhere(sWhereString, "(T1.[EntCod] <= @AV86Bancos_entregarendirwwds_16_tfentcod_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Bancos_entregarendirwwds_18_tfentdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Bancos_entregarendirwwds_17_tfentdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV87Bancos_entregarendirwwds_17_tfentdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Bancos_entregarendirwwds_18_tfentdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] = @AV88Bancos_entregarendirwwds_18_tfentdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_entregarendirwwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Bancos_entregarendirwwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV89Bancos_entregarendirwwds_19_tfcuecod)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_entregarendirwwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV90Bancos_entregarendirwwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Bancos_entregarendirwwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_entregarendirwwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV91Bancos_entregarendirwwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Bancos_entregarendirwwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV92Bancos_entregarendirwwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV93Bancos_entregarendirwwds_23_tfentsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV93Bancos_entregarendirwwds_23_tfentsts_sels, "T1.[EntSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EntCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EntCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EntDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EntDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CueCod]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CueCod] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[CueDsc]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[CueDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EntSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EntSts] DESC";
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
                     return conditional_P005U2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP005U2;
          prmP005U2 = new Object[] {
          new ParDef("@lV73Bancos_entregarendirwwds_3_entdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV73Bancos_entregarendirwwds_3_entdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV74Bancos_entregarendirwwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV74Bancos_entregarendirwwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV78Bancos_entregarendirwwds_8_entdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV78Bancos_entregarendirwwds_8_entdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV79Bancos_entregarendirwwds_9_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV79Bancos_entregarendirwwds_9_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV83Bancos_entregarendirwwds_13_entdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV83Bancos_entregarendirwwds_13_entdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV84Bancos_entregarendirwwds_14_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV84Bancos_entregarendirwwds_14_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV85Bancos_entregarendirwwds_15_tfentcod",GXType.Int32,6,0) ,
          new ParDef("@AV86Bancos_entregarendirwwds_16_tfentcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV87Bancos_entregarendirwwds_17_tfentdsc",GXType.NChar,100,0) ,
          new ParDef("@AV88Bancos_entregarendirwwds_18_tfentdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV89Bancos_entregarendirwwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV90Bancos_entregarendirwwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV91Bancos_entregarendirwwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV92Bancos_entregarendirwwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005U2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
