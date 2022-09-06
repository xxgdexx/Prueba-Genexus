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
namespace GeneXus.Programs.configuracion {
   public class chofereswwexportreport : GXWebProcedure
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

      public chofereswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public chofereswwexportreport( IGxContext context )
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
         chofereswwexportreport objchofereswwexportreport;
         objchofereswwexportreport = new chofereswwexportreport();
         objchofereswwexportreport.context.SetSubmitInitialConfig(context);
         objchofereswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objchofereswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((chofereswwexportreport)stateInfo).executePrivate();
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
            AV64Title = "Lista de Choferes";
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
            H330( true, 0) ;
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
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV12DynamicFiltersSelector1 = AV25GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CHODSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14ChoDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14ChoDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterChoDscDescription = StringUtil.Format( "%1 (%2)", "Chofer", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterChoDscDescription = StringUtil.Format( "%1 (%2)", "Chofer", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16ChoDsc = AV14ChoDsc1;
                  H330( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterChoDscDescription, "")), 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ChoDsc, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CHOPLACA") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV73ChoPlaca1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73ChoPlaca1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV74FilterChoPlacaDescription = StringUtil.Format( "%1 (%2)", "Placa", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV74FilterChoPlacaDescription = StringUtil.Format( "%1 (%2)", "Placa", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV75ChoPlaca = AV73ChoPlaca1;
                  H330( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74FilterChoPlacaDescription, "")), 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75ChoPlaca, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CHOLICENCIA") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV76ChoLicencia1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ChoLicencia1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV77FilterChoLicenciaDescription = StringUtil.Format( "%1 (%2)", "N° Licencia", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV77FilterChoLicenciaDescription = StringUtil.Format( "%1 (%2)", "N° Licencia", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV78ChoLicencia = AV76ChoLicencia1;
                  H330( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77FilterChoLicenciaDescription, "")), 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78ChoLicencia, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "CHODSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV20ChoDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ChoDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterChoDscDescription = StringUtil.Format( "%1 (%2)", "Chofer", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterChoDscDescription = StringUtil.Format( "%1 (%2)", "Chofer", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16ChoDsc = AV20ChoDsc2;
                     H330( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterChoDscDescription, "")), 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ChoDsc, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "CHOPLACA") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV79ChoPlaca2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79ChoPlaca2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV74FilterChoPlacaDescription = StringUtil.Format( "%1 (%2)", "Placa", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV74FilterChoPlacaDescription = StringUtil.Format( "%1 (%2)", "Placa", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV75ChoPlaca = AV79ChoPlaca2;
                     H330( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74FilterChoPlacaDescription, "")), 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75ChoPlaca, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "CHOLICENCIA") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV80ChoLicencia2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ChoLicencia2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV77FilterChoLicenciaDescription = StringUtil.Format( "%1 (%2)", "N° Licencia", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV77FilterChoLicenciaDescription = StringUtil.Format( "%1 (%2)", "N° Licencia", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV78ChoLicencia = AV80ChoLicencia2;
                     H330( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77FilterChoLicenciaDescription, "")), 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78ChoLicencia, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "CHODSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV24ChoDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ChoDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterChoDscDescription = StringUtil.Format( "%1 (%2)", "Chofer", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterChoDscDescription = StringUtil.Format( "%1 (%2)", "Chofer", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16ChoDsc = AV24ChoDsc3;
                        H330( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterChoDscDescription, "")), 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ChoDsc, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "CHOPLACA") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV81ChoPlaca3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81ChoPlaca3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV74FilterChoPlacaDescription = StringUtil.Format( "%1 (%2)", "Placa", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV74FilterChoPlacaDescription = StringUtil.Format( "%1 (%2)", "Placa", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV75ChoPlaca = AV81ChoPlaca3;
                        H330( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74FilterChoPlacaDescription, "")), 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75ChoPlaca, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "CHOLICENCIA") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV82ChoLicencia3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ChoLicencia3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV77FilterChoLicenciaDescription = StringUtil.Format( "%1 (%2)", "N° Licencia", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV77FilterChoLicenciaDescription = StringUtil.Format( "%1 (%2)", "N° Licencia", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV78ChoLicencia = AV82ChoLicencia3;
                        H330( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77FilterChoLicenciaDescription, "")), 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78ChoLicencia, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV30TFChoCod) && (0==AV31TFChoCod_To) ) )
         {
            H330( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30TFChoCod), "ZZZZZ9")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV52TFChoCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H330( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFChoCod_To_Description, "")), 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFChoCod_To), "ZZZZZ9")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFChoDsc_Sel)) )
         {
            H330( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Chofer", 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFChoDsc_Sel, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFChoDsc)) )
            {
               H330( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Chofer", 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFChoDsc, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFChoDir_Sel)) )
         {
            H330( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Dirección", 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFChoDir_Sel, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFChoDir)) )
            {
               H330( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Dirección", 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFChoDir, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFChoRuc_Sel)) )
         {
            H330( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("R.U.C.", 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFChoRuc_Sel, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFChoRuc)) )
            {
               H330( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("R.U.C.", 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFChoRuc, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFChoPlaca_Sel)) )
         {
            H330( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Placa", 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFChoPlaca_Sel, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFChoPlaca)) )
            {
               H330( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Placa", 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFChoPlaca, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFChoLicencia_Sel)) )
         {
            H330( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("N° Licencia", 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFChoLicencia_Sel, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFChoLicencia)) )
            {
               H330( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Licencia", 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFChoLicencia, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV69TFChoSts_Sels.FromJSonString(AV67TFChoSts_SelsJson, null);
         if ( ! ( AV69TFChoSts_Sels.Count == 0 ) )
         {
            AV72i = 1;
            AV87GXV1 = 1;
            while ( AV87GXV1 <= AV69TFChoSts_Sels.Count )
            {
               AV70TFChoSts_Sel = (short)(AV69TFChoSts_Sels.GetNumeric(AV87GXV1));
               if ( AV72i == 1 )
               {
                  AV68TFChoSts_SelDscs = "";
               }
               else
               {
                  AV68TFChoSts_SelDscs += ", ";
               }
               if ( AV70TFChoSts_Sel == 1 )
               {
                  AV71FilterTFChoSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV70TFChoSts_Sel == 0 )
               {
                  AV71FilterTFChoSts_SelValueDescription = "INACTIVO";
               }
               AV68TFChoSts_SelDscs += AV71FilterTFChoSts_SelValueDescription;
               AV72i = (long)(AV72i+1);
               AV87GXV1 = (int)(AV87GXV1+1);
            }
            H330( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 201, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TFChoSts_SelDscs, "")), 201, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H330( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H330( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 86, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Chofer", 90, Gx_line+10, 202, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Dirección", 206, Gx_line+10, 318, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("R.U.C.", 322, Gx_line+10, 434, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Placa", 438, Gx_line+10, 551, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("N° Licencia", 555, Gx_line+10, 669, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 673, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV89Configuracion_chofereswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV90Configuracion_chofereswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV91Configuracion_chofereswwds_3_chodsc1 = AV14ChoDsc1;
         AV92Configuracion_chofereswwds_4_choplaca1 = AV73ChoPlaca1;
         AV93Configuracion_chofereswwds_5_cholicencia1 = AV76ChoLicencia1;
         AV94Configuracion_chofereswwds_6_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV95Configuracion_chofereswwds_7_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV96Configuracion_chofereswwds_8_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV97Configuracion_chofereswwds_9_chodsc2 = AV20ChoDsc2;
         AV98Configuracion_chofereswwds_10_choplaca2 = AV79ChoPlaca2;
         AV99Configuracion_chofereswwds_11_cholicencia2 = AV80ChoLicencia2;
         AV100Configuracion_chofereswwds_12_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV101Configuracion_chofereswwds_13_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV102Configuracion_chofereswwds_14_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV103Configuracion_chofereswwds_15_chodsc3 = AV24ChoDsc3;
         AV104Configuracion_chofereswwds_16_choplaca3 = AV81ChoPlaca3;
         AV105Configuracion_chofereswwds_17_cholicencia3 = AV82ChoLicencia3;
         AV106Configuracion_chofereswwds_18_tfchocod = AV30TFChoCod;
         AV107Configuracion_chofereswwds_19_tfchocod_to = AV31TFChoCod_To;
         AV108Configuracion_chofereswwds_20_tfchodsc = AV32TFChoDsc;
         AV109Configuracion_chofereswwds_21_tfchodsc_sel = AV33TFChoDsc_Sel;
         AV110Configuracion_chofereswwds_22_tfchodir = AV34TFChoDir;
         AV111Configuracion_chofereswwds_23_tfchodir_sel = AV35TFChoDir_Sel;
         AV112Configuracion_chofereswwds_24_tfchoruc = AV38TFChoRuc;
         AV113Configuracion_chofereswwds_25_tfchoruc_sel = AV39TFChoRuc_Sel;
         AV114Configuracion_chofereswwds_26_tfchoplaca = AV42TFChoPlaca;
         AV115Configuracion_chofereswwds_27_tfchoplaca_sel = AV43TFChoPlaca_Sel;
         AV116Configuracion_chofereswwds_28_tfcholicencia = AV44TFChoLicencia;
         AV117Configuracion_chofereswwds_29_tfcholicencia_sel = AV45TFChoLicencia_Sel;
         AV118Configuracion_chofereswwds_30_tfchosts_sels = AV69TFChoSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A549ChoSts ,
                                              AV118Configuracion_chofereswwds_30_tfchosts_sels ,
                                              AV89Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                              AV90Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                              AV91Configuracion_chofereswwds_3_chodsc1 ,
                                              AV92Configuracion_chofereswwds_4_choplaca1 ,
                                              AV93Configuracion_chofereswwds_5_cholicencia1 ,
                                              AV94Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                              AV95Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                              AV96Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                              AV97Configuracion_chofereswwds_9_chodsc2 ,
                                              AV98Configuracion_chofereswwds_10_choplaca2 ,
                                              AV99Configuracion_chofereswwds_11_cholicencia2 ,
                                              AV100Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                              AV101Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                              AV102Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                              AV103Configuracion_chofereswwds_15_chodsc3 ,
                                              AV104Configuracion_chofereswwds_16_choplaca3 ,
                                              AV105Configuracion_chofereswwds_17_cholicencia3 ,
                                              AV106Configuracion_chofereswwds_18_tfchocod ,
                                              AV107Configuracion_chofereswwds_19_tfchocod_to ,
                                              AV109Configuracion_chofereswwds_21_tfchodsc_sel ,
                                              AV108Configuracion_chofereswwds_20_tfchodsc ,
                                              AV111Configuracion_chofereswwds_23_tfchodir_sel ,
                                              AV110Configuracion_chofereswwds_22_tfchodir ,
                                              AV113Configuracion_chofereswwds_25_tfchoruc_sel ,
                                              AV112Configuracion_chofereswwds_24_tfchoruc ,
                                              AV115Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                              AV114Configuracion_chofereswwds_26_tfchoplaca ,
                                              AV117Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                              AV116Configuracion_chofereswwds_28_tfcholicencia ,
                                              AV118Configuracion_chofereswwds_30_tfchosts_sels.Count ,
                                              A542ChoDsc ,
                                              A543ChoPlaca ,
                                              A546ChoLicencia ,
                                              A10ChoCod ,
                                              A545ChoDir ,
                                              A548ChoRuc ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV91Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV91Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV91Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV91Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV92Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV92Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV92Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV92Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV93Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV93Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV93Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV93Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV97Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV97Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV97Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV97Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV98Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV98Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV98Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV98Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV99Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV99Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV99Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV99Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV103Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV103Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV103Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV103Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV104Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV104Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV104Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV104Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV105Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV105Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV105Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV105Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV108Configuracion_chofereswwds_20_tfchodsc = StringUtil.PadR( StringUtil.RTrim( AV108Configuracion_chofereswwds_20_tfchodsc), 100, "%");
         lV110Configuracion_chofereswwds_22_tfchodir = StringUtil.PadR( StringUtil.RTrim( AV110Configuracion_chofereswwds_22_tfchodir), 100, "%");
         lV112Configuracion_chofereswwds_24_tfchoruc = StringUtil.PadR( StringUtil.RTrim( AV112Configuracion_chofereswwds_24_tfchoruc), 20, "%");
         lV114Configuracion_chofereswwds_26_tfchoplaca = StringUtil.PadR( StringUtil.RTrim( AV114Configuracion_chofereswwds_26_tfchoplaca), 20, "%");
         lV116Configuracion_chofereswwds_28_tfcholicencia = StringUtil.PadR( StringUtil.RTrim( AV116Configuracion_chofereswwds_28_tfcholicencia), 20, "%");
         /* Using cursor P00332 */
         pr_default.execute(0, new Object[] {lV91Configuracion_chofereswwds_3_chodsc1, lV91Configuracion_chofereswwds_3_chodsc1, lV92Configuracion_chofereswwds_4_choplaca1, lV92Configuracion_chofereswwds_4_choplaca1, lV93Configuracion_chofereswwds_5_cholicencia1, lV93Configuracion_chofereswwds_5_cholicencia1, lV97Configuracion_chofereswwds_9_chodsc2, lV97Configuracion_chofereswwds_9_chodsc2, lV98Configuracion_chofereswwds_10_choplaca2, lV98Configuracion_chofereswwds_10_choplaca2, lV99Configuracion_chofereswwds_11_cholicencia2, lV99Configuracion_chofereswwds_11_cholicencia2, lV103Configuracion_chofereswwds_15_chodsc3, lV103Configuracion_chofereswwds_15_chodsc3, lV104Configuracion_chofereswwds_16_choplaca3, lV104Configuracion_chofereswwds_16_choplaca3, lV105Configuracion_chofereswwds_17_cholicencia3, lV105Configuracion_chofereswwds_17_cholicencia3, AV106Configuracion_chofereswwds_18_tfchocod, AV107Configuracion_chofereswwds_19_tfchocod_to, lV108Configuracion_chofereswwds_20_tfchodsc, AV109Configuracion_chofereswwds_21_tfchodsc_sel, lV110Configuracion_chofereswwds_22_tfchodir, AV111Configuracion_chofereswwds_23_tfchodir_sel, lV112Configuracion_chofereswwds_24_tfchoruc, AV113Configuracion_chofereswwds_25_tfchoruc_sel, lV114Configuracion_chofereswwds_26_tfchoplaca, AV115Configuracion_chofereswwds_27_tfchoplaca_sel, lV116Configuracion_chofereswwds_28_tfcholicencia, AV117Configuracion_chofereswwds_29_tfcholicencia_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A549ChoSts = P00332_A549ChoSts[0];
            A548ChoRuc = P00332_A548ChoRuc[0];
            A545ChoDir = P00332_A545ChoDir[0];
            A10ChoCod = P00332_A10ChoCod[0];
            A546ChoLicencia = P00332_A546ChoLicencia[0];
            A543ChoPlaca = P00332_A543ChoPlaca[0];
            A542ChoDsc = P00332_A542ChoDsc[0];
            if ( A549ChoSts == 1 )
            {
               AV66ChoStsDescription = "ACTIVO";
            }
            else if ( A549ChoSts == 0 )
            {
               AV66ChoStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H330( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A10ChoCod), "ZZZZZ9")), 30, Gx_line+10, 86, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A542ChoDsc, "")), 90, Gx_line+10, 202, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A545ChoDir, "")), 206, Gx_line+10, 318, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A548ChoRuc, "")), 322, Gx_line+10, 434, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A543ChoPlaca, "")), 438, Gx_line+10, 551, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A546ChoLicencia, "")), 555, Gx_line+10, 669, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66ChoStsDescription, "")), 673, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Configuracion.ChoferesWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.ChoferesWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Configuracion.ChoferesWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV119GXV2 = 1;
         while ( AV119GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV119GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCHOCOD") == 0 )
            {
               AV30TFChoCod = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV31TFChoCod_To = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCHODSC") == 0 )
            {
               AV32TFChoDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCHODSC_SEL") == 0 )
            {
               AV33TFChoDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCHODIR") == 0 )
            {
               AV34TFChoDir = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCHODIR_SEL") == 0 )
            {
               AV35TFChoDir_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCHORUC") == 0 )
            {
               AV38TFChoRuc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCHORUC_SEL") == 0 )
            {
               AV39TFChoRuc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCHOPLACA") == 0 )
            {
               AV42TFChoPlaca = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCHOPLACA_SEL") == 0 )
            {
               AV43TFChoPlaca_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCHOLICENCIA") == 0 )
            {
               AV44TFChoLicencia = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCHOLICENCIA_SEL") == 0 )
            {
               AV45TFChoLicencia_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCHOSTS_SEL") == 0 )
            {
               AV67TFChoSts_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV69TFChoSts_Sels.FromJSonString(AV67TFChoSts_SelsJson, null);
            }
            AV119GXV2 = (int)(AV119GXV2+1);
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

      protected void H330( bool bFoot ,
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
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV57AppName = "DVelop Software Solutions";
               AV63Phone = "+1 550 8923";
               AV61Mail = "info@mail.com";
               AV65Website = "http://www.web.com";
               AV54AddressLine1 = "French Boulevard 2859";
               AV55AddressLine2 = "Downtown";
               AV56AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV64Title = "";
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14ChoDsc1 = "";
         AV15FilterChoDscDescription = "";
         AV16ChoDsc = "";
         AV73ChoPlaca1 = "";
         AV74FilterChoPlacaDescription = "";
         AV75ChoPlaca = "";
         AV76ChoLicencia1 = "";
         AV77FilterChoLicenciaDescription = "";
         AV78ChoLicencia = "";
         AV18DynamicFiltersSelector2 = "";
         AV20ChoDsc2 = "";
         AV79ChoPlaca2 = "";
         AV80ChoLicencia2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV24ChoDsc3 = "";
         AV81ChoPlaca3 = "";
         AV82ChoLicencia3 = "";
         AV52TFChoCod_To_Description = "";
         AV33TFChoDsc_Sel = "";
         AV32TFChoDsc = "";
         AV35TFChoDir_Sel = "";
         AV34TFChoDir = "";
         AV39TFChoRuc_Sel = "";
         AV38TFChoRuc = "";
         AV43TFChoPlaca_Sel = "";
         AV42TFChoPlaca = "";
         AV45TFChoLicencia_Sel = "";
         AV44TFChoLicencia = "";
         AV69TFChoSts_Sels = new GxSimpleCollection<short>();
         AV67TFChoSts_SelsJson = "";
         AV68TFChoSts_SelDscs = "";
         AV71FilterTFChoSts_SelValueDescription = "";
         AV89Configuracion_chofereswwds_1_dynamicfiltersselector1 = "";
         AV91Configuracion_chofereswwds_3_chodsc1 = "";
         AV92Configuracion_chofereswwds_4_choplaca1 = "";
         AV93Configuracion_chofereswwds_5_cholicencia1 = "";
         AV95Configuracion_chofereswwds_7_dynamicfiltersselector2 = "";
         AV97Configuracion_chofereswwds_9_chodsc2 = "";
         AV98Configuracion_chofereswwds_10_choplaca2 = "";
         AV99Configuracion_chofereswwds_11_cholicencia2 = "";
         AV101Configuracion_chofereswwds_13_dynamicfiltersselector3 = "";
         AV103Configuracion_chofereswwds_15_chodsc3 = "";
         AV104Configuracion_chofereswwds_16_choplaca3 = "";
         AV105Configuracion_chofereswwds_17_cholicencia3 = "";
         AV108Configuracion_chofereswwds_20_tfchodsc = "";
         AV109Configuracion_chofereswwds_21_tfchodsc_sel = "";
         AV110Configuracion_chofereswwds_22_tfchodir = "";
         AV111Configuracion_chofereswwds_23_tfchodir_sel = "";
         AV112Configuracion_chofereswwds_24_tfchoruc = "";
         AV113Configuracion_chofereswwds_25_tfchoruc_sel = "";
         AV114Configuracion_chofereswwds_26_tfchoplaca = "";
         AV115Configuracion_chofereswwds_27_tfchoplaca_sel = "";
         AV116Configuracion_chofereswwds_28_tfcholicencia = "";
         AV117Configuracion_chofereswwds_29_tfcholicencia_sel = "";
         AV118Configuracion_chofereswwds_30_tfchosts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV91Configuracion_chofereswwds_3_chodsc1 = "";
         lV92Configuracion_chofereswwds_4_choplaca1 = "";
         lV93Configuracion_chofereswwds_5_cholicencia1 = "";
         lV97Configuracion_chofereswwds_9_chodsc2 = "";
         lV98Configuracion_chofereswwds_10_choplaca2 = "";
         lV99Configuracion_chofereswwds_11_cholicencia2 = "";
         lV103Configuracion_chofereswwds_15_chodsc3 = "";
         lV104Configuracion_chofereswwds_16_choplaca3 = "";
         lV105Configuracion_chofereswwds_17_cholicencia3 = "";
         lV108Configuracion_chofereswwds_20_tfchodsc = "";
         lV110Configuracion_chofereswwds_22_tfchodir = "";
         lV112Configuracion_chofereswwds_24_tfchoruc = "";
         lV114Configuracion_chofereswwds_26_tfchoplaca = "";
         lV116Configuracion_chofereswwds_28_tfcholicencia = "";
         A542ChoDsc = "";
         A543ChoPlaca = "";
         A546ChoLicencia = "";
         A545ChoDir = "";
         A548ChoRuc = "";
         P00332_A549ChoSts = new short[1] ;
         P00332_A548ChoRuc = new string[] {""} ;
         P00332_A545ChoDir = new string[] {""} ;
         P00332_A10ChoCod = new int[1] ;
         P00332_A546ChoLicencia = new string[] {""} ;
         P00332_A543ChoPlaca = new string[] {""} ;
         P00332_A542ChoDsc = new string[] {""} ;
         AV66ChoStsDescription = "";
         AV26Session = context.GetSession();
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.chofereswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00332_A549ChoSts, P00332_A548ChoRuc, P00332_A545ChoDir, P00332_A10ChoCod, P00332_A546ChoLicencia, P00332_A543ChoPlaca, P00332_A542ChoDsc
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
      private short AV13DynamicFiltersOperator1 ;
      private short AV19DynamicFiltersOperator2 ;
      private short AV23DynamicFiltersOperator3 ;
      private short AV70TFChoSts_Sel ;
      private short AV90Configuracion_chofereswwds_2_dynamicfiltersoperator1 ;
      private short AV96Configuracion_chofereswwds_8_dynamicfiltersoperator2 ;
      private short AV102Configuracion_chofereswwds_14_dynamicfiltersoperator3 ;
      private short A549ChoSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV30TFChoCod ;
      private int AV31TFChoCod_To ;
      private int AV87GXV1 ;
      private int AV106Configuracion_chofereswwds_18_tfchocod ;
      private int AV107Configuracion_chofereswwds_19_tfchocod_to ;
      private int AV118Configuracion_chofereswwds_30_tfchosts_sels_Count ;
      private int A10ChoCod ;
      private int AV119GXV2 ;
      private long AV72i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14ChoDsc1 ;
      private string AV16ChoDsc ;
      private string AV73ChoPlaca1 ;
      private string AV75ChoPlaca ;
      private string AV76ChoLicencia1 ;
      private string AV78ChoLicencia ;
      private string AV20ChoDsc2 ;
      private string AV79ChoPlaca2 ;
      private string AV80ChoLicencia2 ;
      private string AV24ChoDsc3 ;
      private string AV81ChoPlaca3 ;
      private string AV82ChoLicencia3 ;
      private string AV33TFChoDsc_Sel ;
      private string AV32TFChoDsc ;
      private string AV35TFChoDir_Sel ;
      private string AV34TFChoDir ;
      private string AV39TFChoRuc_Sel ;
      private string AV38TFChoRuc ;
      private string AV43TFChoPlaca_Sel ;
      private string AV42TFChoPlaca ;
      private string AV45TFChoLicencia_Sel ;
      private string AV44TFChoLicencia ;
      private string AV91Configuracion_chofereswwds_3_chodsc1 ;
      private string AV92Configuracion_chofereswwds_4_choplaca1 ;
      private string AV93Configuracion_chofereswwds_5_cholicencia1 ;
      private string AV97Configuracion_chofereswwds_9_chodsc2 ;
      private string AV98Configuracion_chofereswwds_10_choplaca2 ;
      private string AV99Configuracion_chofereswwds_11_cholicencia2 ;
      private string AV103Configuracion_chofereswwds_15_chodsc3 ;
      private string AV104Configuracion_chofereswwds_16_choplaca3 ;
      private string AV105Configuracion_chofereswwds_17_cholicencia3 ;
      private string AV108Configuracion_chofereswwds_20_tfchodsc ;
      private string AV109Configuracion_chofereswwds_21_tfchodsc_sel ;
      private string AV110Configuracion_chofereswwds_22_tfchodir ;
      private string AV111Configuracion_chofereswwds_23_tfchodir_sel ;
      private string AV112Configuracion_chofereswwds_24_tfchoruc ;
      private string AV113Configuracion_chofereswwds_25_tfchoruc_sel ;
      private string AV114Configuracion_chofereswwds_26_tfchoplaca ;
      private string AV115Configuracion_chofereswwds_27_tfchoplaca_sel ;
      private string AV116Configuracion_chofereswwds_28_tfcholicencia ;
      private string AV117Configuracion_chofereswwds_29_tfcholicencia_sel ;
      private string scmdbuf ;
      private string lV91Configuracion_chofereswwds_3_chodsc1 ;
      private string lV92Configuracion_chofereswwds_4_choplaca1 ;
      private string lV93Configuracion_chofereswwds_5_cholicencia1 ;
      private string lV97Configuracion_chofereswwds_9_chodsc2 ;
      private string lV98Configuracion_chofereswwds_10_choplaca2 ;
      private string lV99Configuracion_chofereswwds_11_cholicencia2 ;
      private string lV103Configuracion_chofereswwds_15_chodsc3 ;
      private string lV104Configuracion_chofereswwds_16_choplaca3 ;
      private string lV105Configuracion_chofereswwds_17_cholicencia3 ;
      private string lV108Configuracion_chofereswwds_20_tfchodsc ;
      private string lV110Configuracion_chofereswwds_22_tfchodir ;
      private string lV112Configuracion_chofereswwds_24_tfchoruc ;
      private string lV114Configuracion_chofereswwds_26_tfchoplaca ;
      private string lV116Configuracion_chofereswwds_28_tfcholicencia ;
      private string A542ChoDsc ;
      private string A543ChoPlaca ;
      private string A546ChoLicencia ;
      private string A545ChoDir ;
      private string A548ChoRuc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV94Configuracion_chofereswwds_6_dynamicfiltersenabled2 ;
      private bool AV100Configuracion_chofereswwds_12_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV67TFChoSts_SelsJson ;
      private string AV64Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterChoDscDescription ;
      private string AV74FilterChoPlacaDescription ;
      private string AV77FilterChoLicenciaDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV52TFChoCod_To_Description ;
      private string AV68TFChoSts_SelDscs ;
      private string AV71FilterTFChoSts_SelValueDescription ;
      private string AV89Configuracion_chofereswwds_1_dynamicfiltersselector1 ;
      private string AV95Configuracion_chofereswwds_7_dynamicfiltersselector2 ;
      private string AV101Configuracion_chofereswwds_13_dynamicfiltersselector3 ;
      private string AV66ChoStsDescription ;
      private string AV62PageInfo ;
      private string AV59DateInfo ;
      private string AV57AppName ;
      private string AV63Phone ;
      private string AV61Mail ;
      private string AV65Website ;
      private string AV54AddressLine1 ;
      private string AV55AddressLine2 ;
      private string AV56AddressLine3 ;
      private GxSimpleCollection<short> AV69TFChoSts_Sels ;
      private GxSimpleCollection<short> AV118Configuracion_chofereswwds_30_tfchosts_sels ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00332_A549ChoSts ;
      private string[] P00332_A548ChoRuc ;
      private string[] P00332_A545ChoDir ;
      private int[] P00332_A10ChoCod ;
      private string[] P00332_A546ChoLicencia ;
      private string[] P00332_A543ChoPlaca ;
      private string[] P00332_A542ChoDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class chofereswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00332( IGxContext context ,
                                             short A549ChoSts ,
                                             GxSimpleCollection<short> AV118Configuracion_chofereswwds_30_tfchosts_sels ,
                                             string AV89Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                             short AV90Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                             string AV91Configuracion_chofereswwds_3_chodsc1 ,
                                             string AV92Configuracion_chofereswwds_4_choplaca1 ,
                                             string AV93Configuracion_chofereswwds_5_cholicencia1 ,
                                             bool AV94Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                             string AV95Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                             short AV96Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                             string AV97Configuracion_chofereswwds_9_chodsc2 ,
                                             string AV98Configuracion_chofereswwds_10_choplaca2 ,
                                             string AV99Configuracion_chofereswwds_11_cholicencia2 ,
                                             bool AV100Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                             string AV101Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                             short AV102Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                             string AV103Configuracion_chofereswwds_15_chodsc3 ,
                                             string AV104Configuracion_chofereswwds_16_choplaca3 ,
                                             string AV105Configuracion_chofereswwds_17_cholicencia3 ,
                                             int AV106Configuracion_chofereswwds_18_tfchocod ,
                                             int AV107Configuracion_chofereswwds_19_tfchocod_to ,
                                             string AV109Configuracion_chofereswwds_21_tfchodsc_sel ,
                                             string AV108Configuracion_chofereswwds_20_tfchodsc ,
                                             string AV111Configuracion_chofereswwds_23_tfchodir_sel ,
                                             string AV110Configuracion_chofereswwds_22_tfchodir ,
                                             string AV113Configuracion_chofereswwds_25_tfchoruc_sel ,
                                             string AV112Configuracion_chofereswwds_24_tfchoruc ,
                                             string AV115Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                             string AV114Configuracion_chofereswwds_26_tfchoplaca ,
                                             string AV117Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                             string AV116Configuracion_chofereswwds_28_tfcholicencia ,
                                             int AV118Configuracion_chofereswwds_30_tfchosts_sels_Count ,
                                             string A542ChoDsc ,
                                             string A543ChoPlaca ,
                                             string A546ChoLicencia ,
                                             int A10ChoCod ,
                                             string A545ChoDir ,
                                             string A548ChoRuc ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[30];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ChoSts], [ChoRuc], [ChoDir], [ChoCod], [ChoLicencia], [ChoPlaca], [ChoDsc] FROM [CCHOFERES]";
         if ( ( StringUtil.StrCmp(AV89Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV90Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV91Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV90Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV91Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV90Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV92Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV90Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV92Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV90Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV93Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV90Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV93Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV94Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV96Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV97Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV94Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV96Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV97Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV94Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV96Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV98Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV94Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV96Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV98Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV94Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV96Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV99Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV94Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV96Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV99Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV100Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV102Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV103Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV100Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV102Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV103Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV100Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV102Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV104Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV100Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV102Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV104Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV100Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV102Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV105Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV100Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV102Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV105Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (0==AV106Configuracion_chofereswwds_18_tfchocod) )
         {
            AddWhere(sWhereString, "([ChoCod] >= @AV106Configuracion_chofereswwds_18_tfchocod)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (0==AV107Configuracion_chofereswwds_19_tfchocod_to) )
         {
            AddWhere(sWhereString, "([ChoCod] <= @AV107Configuracion_chofereswwds_19_tfchocod_to)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Configuracion_chofereswwds_21_tfchodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Configuracion_chofereswwds_20_tfchodsc)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV108Configuracion_chofereswwds_20_tfchodsc)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Configuracion_chofereswwds_21_tfchodsc_sel)) )
         {
            AddWhere(sWhereString, "([ChoDsc] = @AV109Configuracion_chofereswwds_21_tfchodsc_sel)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Configuracion_chofereswwds_23_tfchodir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Configuracion_chofereswwds_22_tfchodir)) ) )
         {
            AddWhere(sWhereString, "([ChoDir] like @lV110Configuracion_chofereswwds_22_tfchodir)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Configuracion_chofereswwds_23_tfchodir_sel)) )
         {
            AddWhere(sWhereString, "([ChoDir] = @AV111Configuracion_chofereswwds_23_tfchodir_sel)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Configuracion_chofereswwds_25_tfchoruc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Configuracion_chofereswwds_24_tfchoruc)) ) )
         {
            AddWhere(sWhereString, "([ChoRuc] like @lV112Configuracion_chofereswwds_24_tfchoruc)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Configuracion_chofereswwds_25_tfchoruc_sel)) )
         {
            AddWhere(sWhereString, "([ChoRuc] = @AV113Configuracion_chofereswwds_25_tfchoruc_sel)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Configuracion_chofereswwds_27_tfchoplaca_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Configuracion_chofereswwds_26_tfchoplaca)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV114Configuracion_chofereswwds_26_tfchoplaca)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Configuracion_chofereswwds_27_tfchoplaca_sel)) )
         {
            AddWhere(sWhereString, "([ChoPlaca] = @AV115Configuracion_chofereswwds_27_tfchoplaca_sel)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Configuracion_chofereswwds_29_tfcholicencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Configuracion_chofereswwds_28_tfcholicencia)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV116Configuracion_chofereswwds_28_tfcholicencia)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Configuracion_chofereswwds_29_tfcholicencia_sel)) )
         {
            AddWhere(sWhereString, "([ChoLicencia] = @AV117Configuracion_chofereswwds_29_tfcholicencia_sel)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( AV118Configuracion_chofereswwds_30_tfchosts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV118Configuracion_chofereswwds_30_tfchosts_sels, "[ChoSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoDir]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoDir] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoRuc]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoRuc] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoPlaca]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoPlaca] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoLicencia]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoLicencia] DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoSts]";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoSts] DESC";
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
                     return conditional_P00332(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (int)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] );
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
          Object[] prmP00332;
          prmP00332 = new Object[] {
          new ParDef("@lV91Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV91Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV92Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV92Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV93Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV93Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV97Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV97Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV98Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV98Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV99Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV99Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV103Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV103Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV104Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV104Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV105Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@lV105Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@AV106Configuracion_chofereswwds_18_tfchocod",GXType.Int32,6,0) ,
          new ParDef("@AV107Configuracion_chofereswwds_19_tfchocod_to",GXType.Int32,6,0) ,
          new ParDef("@lV108Configuracion_chofereswwds_20_tfchodsc",GXType.NChar,100,0) ,
          new ParDef("@AV109Configuracion_chofereswwds_21_tfchodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV110Configuracion_chofereswwds_22_tfchodir",GXType.NChar,100,0) ,
          new ParDef("@AV111Configuracion_chofereswwds_23_tfchodir_sel",GXType.NChar,100,0) ,
          new ParDef("@lV112Configuracion_chofereswwds_24_tfchoruc",GXType.NChar,20,0) ,
          new ParDef("@AV113Configuracion_chofereswwds_25_tfchoruc_sel",GXType.NChar,20,0) ,
          new ParDef("@lV114Configuracion_chofereswwds_26_tfchoplaca",GXType.NChar,20,0) ,
          new ParDef("@AV115Configuracion_chofereswwds_27_tfchoplaca_sel",GXType.NChar,20,0) ,
          new ParDef("@lV116Configuracion_chofereswwds_28_tfcholicencia",GXType.NChar,20,0) ,
          new ParDef("@AV117Configuracion_chofereswwds_29_tfcholicencia_sel",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00332", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00332,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                return;
       }
    }

 }

}
