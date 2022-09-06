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
   public class lineasproductoswwexportreport : GXWebProcedure
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

      public lineasproductoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public lineasproductoswwexportreport( IGxContext context )
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
         lineasproductoswwexportreport objlineasproductoswwexportreport;
         objlineasproductoswwexportreport = new lineasproductoswwexportreport();
         objlineasproductoswwexportreport.context.SetSubmitInitialConfig(context);
         objlineasproductoswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlineasproductoswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((lineasproductoswwexportreport)stateInfo).executePrivate();
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
            AV55Title = "Lista de Lineas";
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
            H1X0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "LINDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14LinDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14LinDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterLinDscDescription = StringUtil.Format( "%1 (%2)", "Linea", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterLinDscDescription = StringUtil.Format( "%1 (%2)", "Linea", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16LinDsc = AV14LinDsc1;
                  H1X0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterLinDscDescription, "")), 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16LinDsc, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "LINDSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV20LinDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20LinDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterLinDscDescription = StringUtil.Format( "%1 (%2)", "Linea", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterLinDscDescription = StringUtil.Format( "%1 (%2)", "Linea", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16LinDsc = AV20LinDsc2;
                     H1X0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterLinDscDescription, "")), 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16LinDsc, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "LINDSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV24LinDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24LinDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterLinDscDescription = StringUtil.Format( "%1 (%2)", "Linea", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterLinDscDescription = StringUtil.Format( "%1 (%2)", "Linea", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16LinDsc = AV24LinDsc3;
                        H1X0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterLinDscDescription, "")), 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16LinDsc, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV30TFLinCod) && (0==AV31TFLinCod_To) ) )
         {
            H1X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30TFLinCod), "ZZZZZ9")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFLinCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H1X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFLinCod_To_Description, "")), 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFLinCod_To), "ZZZZZ9")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFLinDsc_Sel)) )
         {
            H1X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descripción", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFLinDsc_Sel, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFLinDsc)) )
            {
               H1X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFLinDsc, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFLinAbr_Sel)) )
         {
            H1X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFLinAbr_Sel, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFLinAbr)) )
            {
               H1X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFLinAbr, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFLinSunat_Sel)) )
         {
            H1X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFLinSunat_Sel, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFLinSunat)) )
            {
               H1X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFLinSunat, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV68TFLinStk_Sels.FromJSonString(AV66TFLinStk_SelsJson, null);
         if ( ! ( AV68TFLinStk_Sels.Count == 0 ) )
         {
            AV64i = 1;
            AV74GXV1 = 1;
            while ( AV74GXV1 <= AV68TFLinStk_Sels.Count )
            {
               AV65TFLinStk_Sel = (short)(AV68TFLinStk_Sels.GetNumeric(AV74GXV1));
               if ( AV64i == 1 )
               {
                  AV67TFLinStk_SelDscs = "";
               }
               else
               {
                  AV67TFLinStk_SelDscs += ", ";
               }
               if ( AV65TFLinStk_Sel == 0 )
               {
                  AV69FilterTFLinStk_SelValueDescription = "NO";
               }
               else if ( AV65TFLinStk_Sel == 1 )
               {
                  AV69FilterTFLinStk_SelValueDescription = "SI";
               }
               AV67TFLinStk_SelDscs += AV69FilterTFLinStk_SelValueDescription;
               AV64i = (long)(AV64i+1);
               AV74GXV1 = (int)(AV74GXV1+1);
            }
            H1X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Controla Stock", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TFLinStk_SelDscs, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV61TFLinSts_Sels.FromJSonString(AV59TFLinSts_SelsJson, null);
         if ( ! ( AV61TFLinSts_Sels.Count == 0 ) )
         {
            AV64i = 1;
            AV75GXV2 = 1;
            while ( AV75GXV2 <= AV61TFLinSts_Sels.Count )
            {
               AV62TFLinSts_Sel = (short)(AV61TFLinSts_Sels.GetNumeric(AV75GXV2));
               if ( AV64i == 1 )
               {
                  AV60TFLinSts_SelDscs = "";
               }
               else
               {
                  AV60TFLinSts_SelDscs += ", ";
               }
               if ( AV62TFLinSts_Sel == 1 )
               {
                  AV63FilterTFLinSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV62TFLinSts_Sel == 0 )
               {
                  AV63FilterTFLinSts_SelValueDescription = "INACTIVO";
               }
               AV60TFLinSts_SelDscs += AV63FilterTFLinSts_SelValueDescription;
               AV64i = (long)(AV64i+1);
               AV75GXV2 = (int)(AV75GXV2+1);
            }
            H1X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60TFLinSts_SelDscs, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H1X0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 10, 77, 152, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H1X0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 10, 77, 152, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 135, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Descripción", 139, Gx_line+10, 349, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Abreviatura", 353, Gx_line+10, 458, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo Sunat", 462, Gx_line+10, 567, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Controla Stock", 571, Gx_line+10, 677, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 681, Gx_line+10, 787, Gx_line+27, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV77Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV78Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV79Configuracion_lineasproductoswwds_3_lindsc1 = AV14LinDsc1;
         AV80Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV81Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV82Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV83Configuracion_lineasproductoswwds_7_lindsc2 = AV20LinDsc2;
         AV84Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV85Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV86Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV87Configuracion_lineasproductoswwds_11_lindsc3 = AV24LinDsc3;
         AV88Configuracion_lineasproductoswwds_12_tflincod = AV30TFLinCod;
         AV89Configuracion_lineasproductoswwds_13_tflincod_to = AV31TFLinCod_To;
         AV90Configuracion_lineasproductoswwds_14_tflindsc = AV32TFLinDsc;
         AV91Configuracion_lineasproductoswwds_15_tflindsc_sel = AV33TFLinDsc_Sel;
         AV92Configuracion_lineasproductoswwds_16_tflinabr = AV34TFLinAbr;
         AV93Configuracion_lineasproductoswwds_17_tflinabr_sel = AV35TFLinAbr_Sel;
         AV94Configuracion_lineasproductoswwds_18_tflinsunat = AV36TFLinSunat;
         AV95Configuracion_lineasproductoswwds_19_tflinsunat_sel = AV37TFLinSunat_Sel;
         AV96Configuracion_lineasproductoswwds_20_tflinstk_sels = AV68TFLinStk_Sels;
         AV97Configuracion_lineasproductoswwds_21_tflinsts_sels = AV61TFLinSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1158LinStk ,
                                              AV96Configuracion_lineasproductoswwds_20_tflinstk_sels ,
                                              A1159LinSts ,
                                              AV97Configuracion_lineasproductoswwds_21_tflinsts_sels ,
                                              AV77Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 ,
                                              AV78Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 ,
                                              AV79Configuracion_lineasproductoswwds_3_lindsc1 ,
                                              AV80Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 ,
                                              AV81Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 ,
                                              AV82Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 ,
                                              AV83Configuracion_lineasproductoswwds_7_lindsc2 ,
                                              AV84Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 ,
                                              AV85Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 ,
                                              AV86Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 ,
                                              AV87Configuracion_lineasproductoswwds_11_lindsc3 ,
                                              AV88Configuracion_lineasproductoswwds_12_tflincod ,
                                              AV89Configuracion_lineasproductoswwds_13_tflincod_to ,
                                              AV91Configuracion_lineasproductoswwds_15_tflindsc_sel ,
                                              AV90Configuracion_lineasproductoswwds_14_tflindsc ,
                                              AV93Configuracion_lineasproductoswwds_17_tflinabr_sel ,
                                              AV92Configuracion_lineasproductoswwds_16_tflinabr ,
                                              AV95Configuracion_lineasproductoswwds_19_tflinsunat_sel ,
                                              AV94Configuracion_lineasproductoswwds_18_tflinsunat ,
                                              AV96Configuracion_lineasproductoswwds_20_tflinstk_sels.Count ,
                                              AV97Configuracion_lineasproductoswwds_21_tflinsts_sels.Count ,
                                              A1153LinDsc ,
                                              A52LinCod ,
                                              A1152LinAbr ,
                                              A1160LinSunat ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV79Configuracion_lineasproductoswwds_3_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_lineasproductoswwds_3_lindsc1), 100, "%");
         lV79Configuracion_lineasproductoswwds_3_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_lineasproductoswwds_3_lindsc1), 100, "%");
         lV83Configuracion_lineasproductoswwds_7_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_lineasproductoswwds_7_lindsc2), 100, "%");
         lV83Configuracion_lineasproductoswwds_7_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_lineasproductoswwds_7_lindsc2), 100, "%");
         lV87Configuracion_lineasproductoswwds_11_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_lineasproductoswwds_11_lindsc3), 100, "%");
         lV87Configuracion_lineasproductoswwds_11_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_lineasproductoswwds_11_lindsc3), 100, "%");
         lV90Configuracion_lineasproductoswwds_14_tflindsc = StringUtil.PadR( StringUtil.RTrim( AV90Configuracion_lineasproductoswwds_14_tflindsc), 100, "%");
         lV92Configuracion_lineasproductoswwds_16_tflinabr = StringUtil.PadR( StringUtil.RTrim( AV92Configuracion_lineasproductoswwds_16_tflinabr), 5, "%");
         lV94Configuracion_lineasproductoswwds_18_tflinsunat = StringUtil.Concat( StringUtil.RTrim( AV94Configuracion_lineasproductoswwds_18_tflinsunat), "%", "");
         /* Using cursor P001X2 */
         pr_default.execute(0, new Object[] {lV79Configuracion_lineasproductoswwds_3_lindsc1, lV79Configuracion_lineasproductoswwds_3_lindsc1, lV83Configuracion_lineasproductoswwds_7_lindsc2, lV83Configuracion_lineasproductoswwds_7_lindsc2, lV87Configuracion_lineasproductoswwds_11_lindsc3, lV87Configuracion_lineasproductoswwds_11_lindsc3, AV88Configuracion_lineasproductoswwds_12_tflincod, AV89Configuracion_lineasproductoswwds_13_tflincod_to, lV90Configuracion_lineasproductoswwds_14_tflindsc, AV91Configuracion_lineasproductoswwds_15_tflindsc_sel, lV92Configuracion_lineasproductoswwds_16_tflinabr, AV93Configuracion_lineasproductoswwds_17_tflinabr_sel, lV94Configuracion_lineasproductoswwds_18_tflinsunat, AV95Configuracion_lineasproductoswwds_19_tflinsunat_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1159LinSts = P001X2_A1159LinSts[0];
            A1158LinStk = P001X2_A1158LinStk[0];
            A1160LinSunat = P001X2_A1160LinSunat[0];
            A1152LinAbr = P001X2_A1152LinAbr[0];
            A52LinCod = P001X2_A52LinCod[0];
            A1153LinDsc = P001X2_A1153LinDsc[0];
            if ( A1158LinStk == 0 )
            {
               AV57LinStkDescription = "NO";
            }
            else if ( A1158LinStk == 1 )
            {
               AV57LinStkDescription = "SI";
            }
            if ( A1159LinSts == 1 )
            {
               AV58LinStsDescription = "ACTIVO";
            }
            else if ( A1159LinSts == 0 )
            {
               AV58LinStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H1X0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A52LinCod), "ZZZZZ9")), 30, Gx_line+10, 135, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1153LinDsc, "")), 139, Gx_line+10, 349, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1152LinAbr, "")), 353, Gx_line+10, 458, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1160LinSunat, "")), 462, Gx_line+10, 567, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57LinStkDescription, "")), 571, Gx_line+10, 677, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58LinStsDescription, "")), 681, Gx_line+10, 787, Gx_line+25, 2, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Configuracion.LineasProductosWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.LineasProductosWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Configuracion.LineasProductosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV98GXV3 = 1;
         while ( AV98GXV3 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV98GXV3));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFLINCOD") == 0 )
            {
               AV30TFLinCod = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV31TFLinCod_To = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFLINDSC") == 0 )
            {
               AV32TFLinDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFLINDSC_SEL") == 0 )
            {
               AV33TFLinDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFLINABR") == 0 )
            {
               AV34TFLinAbr = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFLINABR_SEL") == 0 )
            {
               AV35TFLinAbr_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFLINSUNAT") == 0 )
            {
               AV36TFLinSunat = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFLINSUNAT_SEL") == 0 )
            {
               AV37TFLinSunat_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFLINSTK_SEL") == 0 )
            {
               AV66TFLinStk_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV68TFLinStk_Sels.FromJSonString(AV66TFLinStk_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFLINSTS_SEL") == 0 )
            {
               AV59TFLinSts_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV61TFLinSts_Sels.FromJSonString(AV59TFLinSts_SelsJson, null);
            }
            AV98GXV3 = (int)(AV98GXV3+1);
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

      protected void H1X0( bool bFoot ,
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
                  AV53PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV50DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV48AppName = "DVelop Software Solutions";
               AV54Phone = "+1 550 8923";
               AV52Mail = "info@mail.com";
               AV56Website = "http://www.web.com";
               AV45AddressLine1 = "French Boulevard 2859";
               AV46AddressLine2 = "Downtown";
               AV47AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV55Title = "";
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14LinDsc1 = "";
         AV15FilterLinDscDescription = "";
         AV16LinDsc = "";
         AV18DynamicFiltersSelector2 = "";
         AV20LinDsc2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV24LinDsc3 = "";
         AV42TFLinCod_To_Description = "";
         AV33TFLinDsc_Sel = "";
         AV32TFLinDsc = "";
         AV35TFLinAbr_Sel = "";
         AV34TFLinAbr = "";
         AV37TFLinSunat_Sel = "";
         AV36TFLinSunat = "";
         AV68TFLinStk_Sels = new GxSimpleCollection<short>();
         AV66TFLinStk_SelsJson = "";
         AV67TFLinStk_SelDscs = "";
         AV69FilterTFLinStk_SelValueDescription = "";
         AV61TFLinSts_Sels = new GxSimpleCollection<short>();
         AV59TFLinSts_SelsJson = "";
         AV60TFLinSts_SelDscs = "";
         AV63FilterTFLinSts_SelValueDescription = "";
         AV77Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 = "";
         AV79Configuracion_lineasproductoswwds_3_lindsc1 = "";
         AV81Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 = "";
         AV83Configuracion_lineasproductoswwds_7_lindsc2 = "";
         AV85Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 = "";
         AV87Configuracion_lineasproductoswwds_11_lindsc3 = "";
         AV90Configuracion_lineasproductoswwds_14_tflindsc = "";
         AV91Configuracion_lineasproductoswwds_15_tflindsc_sel = "";
         AV92Configuracion_lineasproductoswwds_16_tflinabr = "";
         AV93Configuracion_lineasproductoswwds_17_tflinabr_sel = "";
         AV94Configuracion_lineasproductoswwds_18_tflinsunat = "";
         AV95Configuracion_lineasproductoswwds_19_tflinsunat_sel = "";
         AV96Configuracion_lineasproductoswwds_20_tflinstk_sels = new GxSimpleCollection<short>();
         AV97Configuracion_lineasproductoswwds_21_tflinsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV79Configuracion_lineasproductoswwds_3_lindsc1 = "";
         lV83Configuracion_lineasproductoswwds_7_lindsc2 = "";
         lV87Configuracion_lineasproductoswwds_11_lindsc3 = "";
         lV90Configuracion_lineasproductoswwds_14_tflindsc = "";
         lV92Configuracion_lineasproductoswwds_16_tflinabr = "";
         lV94Configuracion_lineasproductoswwds_18_tflinsunat = "";
         A1153LinDsc = "";
         A1152LinAbr = "";
         A1160LinSunat = "";
         P001X2_A1159LinSts = new short[1] ;
         P001X2_A1158LinStk = new short[1] ;
         P001X2_A1160LinSunat = new string[] {""} ;
         P001X2_A1152LinAbr = new string[] {""} ;
         P001X2_A52LinCod = new int[1] ;
         P001X2_A1153LinDsc = new string[] {""} ;
         AV57LinStkDescription = "";
         AV58LinStsDescription = "";
         AV26Session = context.GetSession();
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53PageInfo = "";
         AV50DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV48AppName = "";
         AV54Phone = "";
         AV52Mail = "";
         AV56Website = "";
         AV45AddressLine1 = "";
         AV46AddressLine2 = "";
         AV47AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.lineasproductoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P001X2_A1159LinSts, P001X2_A1158LinStk, P001X2_A1160LinSunat, P001X2_A1152LinAbr, P001X2_A52LinCod, P001X2_A1153LinDsc
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
      private short AV65TFLinStk_Sel ;
      private short AV62TFLinSts_Sel ;
      private short AV78Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 ;
      private short AV82Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 ;
      private short AV86Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 ;
      private short A1158LinStk ;
      private short A1159LinSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV30TFLinCod ;
      private int AV31TFLinCod_To ;
      private int AV74GXV1 ;
      private int AV75GXV2 ;
      private int AV88Configuracion_lineasproductoswwds_12_tflincod ;
      private int AV89Configuracion_lineasproductoswwds_13_tflincod_to ;
      private int AV96Configuracion_lineasproductoswwds_20_tflinstk_sels_Count ;
      private int AV97Configuracion_lineasproductoswwds_21_tflinsts_sels_Count ;
      private int A52LinCod ;
      private int AV98GXV3 ;
      private long AV64i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14LinDsc1 ;
      private string AV16LinDsc ;
      private string AV20LinDsc2 ;
      private string AV24LinDsc3 ;
      private string AV33TFLinDsc_Sel ;
      private string AV32TFLinDsc ;
      private string AV35TFLinAbr_Sel ;
      private string AV34TFLinAbr ;
      private string AV79Configuracion_lineasproductoswwds_3_lindsc1 ;
      private string AV83Configuracion_lineasproductoswwds_7_lindsc2 ;
      private string AV87Configuracion_lineasproductoswwds_11_lindsc3 ;
      private string AV90Configuracion_lineasproductoswwds_14_tflindsc ;
      private string AV91Configuracion_lineasproductoswwds_15_tflindsc_sel ;
      private string AV92Configuracion_lineasproductoswwds_16_tflinabr ;
      private string AV93Configuracion_lineasproductoswwds_17_tflinabr_sel ;
      private string scmdbuf ;
      private string lV79Configuracion_lineasproductoswwds_3_lindsc1 ;
      private string lV83Configuracion_lineasproductoswwds_7_lindsc2 ;
      private string lV87Configuracion_lineasproductoswwds_11_lindsc3 ;
      private string lV90Configuracion_lineasproductoswwds_14_tflindsc ;
      private string lV92Configuracion_lineasproductoswwds_16_tflinabr ;
      private string A1153LinDsc ;
      private string A1152LinAbr ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV80Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 ;
      private bool AV84Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV66TFLinStk_SelsJson ;
      private string AV59TFLinSts_SelsJson ;
      private string AV55Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterLinDscDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV42TFLinCod_To_Description ;
      private string AV37TFLinSunat_Sel ;
      private string AV36TFLinSunat ;
      private string AV67TFLinStk_SelDscs ;
      private string AV69FilterTFLinStk_SelValueDescription ;
      private string AV60TFLinSts_SelDscs ;
      private string AV63FilterTFLinSts_SelValueDescription ;
      private string AV77Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 ;
      private string AV81Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 ;
      private string AV85Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 ;
      private string AV94Configuracion_lineasproductoswwds_18_tflinsunat ;
      private string AV95Configuracion_lineasproductoswwds_19_tflinsunat_sel ;
      private string lV94Configuracion_lineasproductoswwds_18_tflinsunat ;
      private string A1160LinSunat ;
      private string AV57LinStkDescription ;
      private string AV58LinStsDescription ;
      private string AV53PageInfo ;
      private string AV50DateInfo ;
      private string AV48AppName ;
      private string AV54Phone ;
      private string AV52Mail ;
      private string AV56Website ;
      private string AV45AddressLine1 ;
      private string AV46AddressLine2 ;
      private string AV47AddressLine3 ;
      private GxSimpleCollection<short> AV68TFLinStk_Sels ;
      private GxSimpleCollection<short> AV61TFLinSts_Sels ;
      private GxSimpleCollection<short> AV96Configuracion_lineasproductoswwds_20_tflinstk_sels ;
      private GxSimpleCollection<short> AV97Configuracion_lineasproductoswwds_21_tflinsts_sels ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P001X2_A1159LinSts ;
      private short[] P001X2_A1158LinStk ;
      private string[] P001X2_A1160LinSunat ;
      private string[] P001X2_A1152LinAbr ;
      private int[] P001X2_A52LinCod ;
      private string[] P001X2_A1153LinDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class lineasproductoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001X2( IGxContext context ,
                                             short A1158LinStk ,
                                             GxSimpleCollection<short> AV96Configuracion_lineasproductoswwds_20_tflinstk_sels ,
                                             short A1159LinSts ,
                                             GxSimpleCollection<short> AV97Configuracion_lineasproductoswwds_21_tflinsts_sels ,
                                             string AV77Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 ,
                                             short AV78Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 ,
                                             string AV79Configuracion_lineasproductoswwds_3_lindsc1 ,
                                             bool AV80Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 ,
                                             string AV81Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 ,
                                             short AV82Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 ,
                                             string AV83Configuracion_lineasproductoswwds_7_lindsc2 ,
                                             bool AV84Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 ,
                                             string AV85Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 ,
                                             short AV86Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 ,
                                             string AV87Configuracion_lineasproductoswwds_11_lindsc3 ,
                                             int AV88Configuracion_lineasproductoswwds_12_tflincod ,
                                             int AV89Configuracion_lineasproductoswwds_13_tflincod_to ,
                                             string AV91Configuracion_lineasproductoswwds_15_tflindsc_sel ,
                                             string AV90Configuracion_lineasproductoswwds_14_tflindsc ,
                                             string AV93Configuracion_lineasproductoswwds_17_tflinabr_sel ,
                                             string AV92Configuracion_lineasproductoswwds_16_tflinabr ,
                                             string AV95Configuracion_lineasproductoswwds_19_tflinsunat_sel ,
                                             string AV94Configuracion_lineasproductoswwds_18_tflinsunat ,
                                             int AV96Configuracion_lineasproductoswwds_20_tflinstk_sels_Count ,
                                             int AV97Configuracion_lineasproductoswwds_21_tflinsts_sels_Count ,
                                             string A1153LinDsc ,
                                             int A52LinCod ,
                                             string A1152LinAbr ,
                                             string A1160LinSunat ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [LinSts], [LinStk], [LinSunat], [LinAbr], [LinCod], [LinDsc] FROM [CLINEAPROD]";
         if ( ( StringUtil.StrCmp(AV77Configuracion_lineasproductoswwds_1_dynamicfiltersselector1, "LINDSC") == 0 ) && ( AV78Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_lineasproductoswwds_3_lindsc1)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like @lV79Configuracion_lineasproductoswwds_3_lindsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV77Configuracion_lineasproductoswwds_1_dynamicfiltersselector1, "LINDSC") == 0 ) && ( AV78Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_lineasproductoswwds_3_lindsc1)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like '%' + @lV79Configuracion_lineasproductoswwds_3_lindsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV80Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV81Configuracion_lineasproductoswwds_5_dynamicfiltersselector2, "LINDSC") == 0 ) && ( AV82Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_lineasproductoswwds_7_lindsc2)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like @lV83Configuracion_lineasproductoswwds_7_lindsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV80Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV81Configuracion_lineasproductoswwds_5_dynamicfiltersselector2, "LINDSC") == 0 ) && ( AV82Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_lineasproductoswwds_7_lindsc2)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like '%' + @lV83Configuracion_lineasproductoswwds_7_lindsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV84Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_lineasproductoswwds_9_dynamicfiltersselector3, "LINDSC") == 0 ) && ( AV86Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_lineasproductoswwds_11_lindsc3)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like @lV87Configuracion_lineasproductoswwds_11_lindsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV84Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_lineasproductoswwds_9_dynamicfiltersselector3, "LINDSC") == 0 ) && ( AV86Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_lineasproductoswwds_11_lindsc3)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like '%' + @lV87Configuracion_lineasproductoswwds_11_lindsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV88Configuracion_lineasproductoswwds_12_tflincod) )
         {
            AddWhere(sWhereString, "([LinCod] >= @AV88Configuracion_lineasproductoswwds_12_tflincod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV89Configuracion_lineasproductoswwds_13_tflincod_to) )
         {
            AddWhere(sWhereString, "([LinCod] <= @AV89Configuracion_lineasproductoswwds_13_tflincod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Configuracion_lineasproductoswwds_15_tflindsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Configuracion_lineasproductoswwds_14_tflindsc)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like @lV90Configuracion_lineasproductoswwds_14_tflindsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Configuracion_lineasproductoswwds_15_tflindsc_sel)) )
         {
            AddWhere(sWhereString, "([LinDsc] = @AV91Configuracion_lineasproductoswwds_15_tflindsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_lineasproductoswwds_17_tflinabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_lineasproductoswwds_16_tflinabr)) ) )
         {
            AddWhere(sWhereString, "([LinAbr] like @lV92Configuracion_lineasproductoswwds_16_tflinabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_lineasproductoswwds_17_tflinabr_sel)) )
         {
            AddWhere(sWhereString, "([LinAbr] = @AV93Configuracion_lineasproductoswwds_17_tflinabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_lineasproductoswwds_19_tflinsunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_lineasproductoswwds_18_tflinsunat)) ) )
         {
            AddWhere(sWhereString, "([LinSunat] like @lV94Configuracion_lineasproductoswwds_18_tflinsunat)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_lineasproductoswwds_19_tflinsunat_sel)) )
         {
            AddWhere(sWhereString, "([LinSunat] = @AV95Configuracion_lineasproductoswwds_19_tflinsunat_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV96Configuracion_lineasproductoswwds_20_tflinstk_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV96Configuracion_lineasproductoswwds_20_tflinstk_sels, "[LinStk] IN (", ")")+")");
         }
         if ( AV97Configuracion_lineasproductoswwds_21_tflinsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV97Configuracion_lineasproductoswwds_21_tflinsts_sels, "[LinSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [LinCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [LinCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [LinDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [LinDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [LinAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [LinAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [LinSunat]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [LinSunat] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [LinStk]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [LinStk] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [LinSts]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [LinSts] DESC";
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
                     return conditional_P001X2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP001X2;
          prmP001X2 = new Object[] {
          new ParDef("@lV79Configuracion_lineasproductoswwds_3_lindsc1",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_lineasproductoswwds_3_lindsc1",GXType.NChar,100,0) ,
          new ParDef("@lV83Configuracion_lineasproductoswwds_7_lindsc2",GXType.NChar,100,0) ,
          new ParDef("@lV83Configuracion_lineasproductoswwds_7_lindsc2",GXType.NChar,100,0) ,
          new ParDef("@lV87Configuracion_lineasproductoswwds_11_lindsc3",GXType.NChar,100,0) ,
          new ParDef("@lV87Configuracion_lineasproductoswwds_11_lindsc3",GXType.NChar,100,0) ,
          new ParDef("@AV88Configuracion_lineasproductoswwds_12_tflincod",GXType.Int32,6,0) ,
          new ParDef("@AV89Configuracion_lineasproductoswwds_13_tflincod_to",GXType.Int32,6,0) ,
          new ParDef("@lV90Configuracion_lineasproductoswwds_14_tflindsc",GXType.NChar,100,0) ,
          new ParDef("@AV91Configuracion_lineasproductoswwds_15_tflindsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV92Configuracion_lineasproductoswwds_16_tflinabr",GXType.NChar,5,0) ,
          new ParDef("@AV93Configuracion_lineasproductoswwds_17_tflinabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV94Configuracion_lineasproductoswwds_18_tflinsunat",GXType.NVarChar,5,0) ,
          new ParDef("@AV95Configuracion_lineasproductoswwds_19_tflinsunat_sel",GXType.NVarChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001X2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
       }
    }

 }

}
