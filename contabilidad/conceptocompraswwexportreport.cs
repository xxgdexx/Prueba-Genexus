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
namespace GeneXus.Programs.contabilidad {
   public class conceptocompraswwexportreport : GXWebProcedure
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

      public conceptocompraswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptocompraswwexportreport( IGxContext context )
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
         conceptocompraswwexportreport objconceptocompraswwexportreport;
         objconceptocompraswwexportreport = new conceptocompraswwexportreport();
         objconceptocompraswwexportreport.context.SetSubmitInitialConfig(context);
         objconceptocompraswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptocompraswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptocompraswwexportreport)stateInfo).executePrivate();
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
            AV57Title = "Lista de Conceptos de Compras";
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
            H6X0( true, 0) ;
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
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV12DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CCONPDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV14CConpDsc1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14CConpDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterCConpDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterCConpDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16CConpDsc = AV14CConpDsc1;
                  H6X0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCConpDscDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CConpDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CCONPCUECOD") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV60CConpCueCod1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60CConpCueCod1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV61FilterCConpCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV61FilterCConpCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV62CConpCueCod = AV60CConpCueCod1;
                  H6X0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61FilterCConpCueCodDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62CConpCueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV20DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CCONPDSC") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV23CConpDsc2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23CConpDsc2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterCConpDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterCConpDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16CConpDsc = AV23CConpDsc2;
                     H6X0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCConpDscDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CConpDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CCONPCUECOD") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV63CConpCueCod2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63CConpCueCod2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV61FilterCConpCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV61FilterCConpCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV62CConpCueCod = AV63CConpCueCod2;
                     H6X0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61FilterCConpCueCodDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62CConpCueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CCONPDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV28CConpDsc3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28CConpDsc3)) )
                     {
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterCConpDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterCConpDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16CConpDsc = AV28CConpDsc3;
                        H6X0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCConpDscDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CConpDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CCONPCUECOD") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV64CConpCueCod3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64CConpCueCod3)) )
                     {
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV61FilterCConpCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV61FilterCConpCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV62CConpCueCod = AV64CConpCueCod3;
                        H6X0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61FilterCConpCueCodDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62CConpCueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV35TFCConpCod) && (0==AV36TFCConpCod_To) ) )
         {
            H6X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35TFCConpCod), "ZZZZZ9")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV45TFCConpCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H6X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFCConpCod_To_Description, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36TFCConpCod_To), "ZZZZZ9")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCConpDsc_Sel)) )
         {
            H6X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Concepto", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFCConpDsc_Sel, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCConpDsc)) )
            {
               H6X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Concepto", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFCConpDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCConpCueCod_Sel)) )
         {
            H6X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFCConpCueCod_Sel, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCConpCueCod)) )
            {
               H6X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFCConpCueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV67TFCConpSts_Sels.FromJSonString(AV65TFCConpSts_SelsJson, null);
         if ( ! ( AV67TFCConpSts_Sels.Count == 0 ) )
         {
            AV70i = 1;
            AV75GXV1 = 1;
            while ( AV75GXV1 <= AV67TFCConpSts_Sels.Count )
            {
               AV68TFCConpSts_Sel = (short)(AV67TFCConpSts_Sels.GetNumeric(AV75GXV1));
               if ( AV70i == 1 )
               {
                  AV66TFCConpSts_SelDscs = "";
               }
               else
               {
                  AV66TFCConpSts_SelDscs += ", ";
               }
               if ( AV68TFCConpSts_Sel == 1 )
               {
                  AV69FilterTFCConpSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV68TFCConpSts_Sel == 0 )
               {
                  AV69FilterTFCConpSts_SelValueDescription = "INACTIVO";
               }
               AV66TFCConpSts_SelDscs += AV69FilterTFCConpSts_SelValueDescription;
               AV70i = (long)(AV70i+1);
               AV75GXV1 = (int)(AV75GXV1+1);
            }
            H6X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66TFCConpSts_SelDscs, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6X0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6X0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 154, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Concepto", 158, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Cuenta Contable", 410, Gx_line+10, 534, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 538, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV77Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV78Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV79Contabilidad_conceptocompraswwds_3_cconpdsc1 = AV14CConpDsc1;
         AV80Contabilidad_conceptocompraswwds_4_cconpcuecod1 = AV60CConpCueCod1;
         AV81Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV82Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV83Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV84Contabilidad_conceptocompraswwds_8_cconpdsc2 = AV23CConpDsc2;
         AV85Contabilidad_conceptocompraswwds_9_cconpcuecod2 = AV63CConpCueCod2;
         AV86Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV87Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV88Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV89Contabilidad_conceptocompraswwds_13_cconpdsc3 = AV28CConpDsc3;
         AV90Contabilidad_conceptocompraswwds_14_cconpcuecod3 = AV64CConpCueCod3;
         AV91Contabilidad_conceptocompraswwds_15_tfcconpcod = AV35TFCConpCod;
         AV92Contabilidad_conceptocompraswwds_16_tfcconpcod_to = AV36TFCConpCod_To;
         AV93Contabilidad_conceptocompraswwds_17_tfcconpdsc = AV37TFCConpDsc;
         AV94Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel = AV38TFCConpDsc_Sel;
         AV95Contabilidad_conceptocompraswwds_19_tfcconpcuecod = AV39TFCConpCueCod;
         AV96Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel = AV40TFCConpCueCod_Sel;
         AV97Contabilidad_conceptocompraswwds_21_tfcconpsts_sels = AV67TFCConpSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A517CConpSts ,
                                              AV97Contabilidad_conceptocompraswwds_21_tfcconpsts_sels ,
                                              AV77Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 ,
                                              AV78Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 ,
                                              AV79Contabilidad_conceptocompraswwds_3_cconpdsc1 ,
                                              AV80Contabilidad_conceptocompraswwds_4_cconpcuecod1 ,
                                              AV81Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 ,
                                              AV82Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 ,
                                              AV83Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 ,
                                              AV84Contabilidad_conceptocompraswwds_8_cconpdsc2 ,
                                              AV85Contabilidad_conceptocompraswwds_9_cconpcuecod2 ,
                                              AV86Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 ,
                                              AV87Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 ,
                                              AV88Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 ,
                                              AV89Contabilidad_conceptocompraswwds_13_cconpdsc3 ,
                                              AV90Contabilidad_conceptocompraswwds_14_cconpcuecod3 ,
                                              AV91Contabilidad_conceptocompraswwds_15_tfcconpcod ,
                                              AV92Contabilidad_conceptocompraswwds_16_tfcconpcod_to ,
                                              AV94Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel ,
                                              AV93Contabilidad_conceptocompraswwds_17_tfcconpdsc ,
                                              AV96Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel ,
                                              AV95Contabilidad_conceptocompraswwds_19_tfcconpcuecod ,
                                              AV97Contabilidad_conceptocompraswwds_21_tfcconpsts_sels.Count ,
                                              A78CConpDsc ,
                                              A77CConpCueCod ,
                                              A76CConpCod ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV79Contabilidad_conceptocompraswwds_3_cconpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV79Contabilidad_conceptocompraswwds_3_cconpdsc1), 100, "%");
         lV79Contabilidad_conceptocompraswwds_3_cconpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV79Contabilidad_conceptocompraswwds_3_cconpdsc1), 100, "%");
         lV80Contabilidad_conceptocompraswwds_4_cconpcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV80Contabilidad_conceptocompraswwds_4_cconpcuecod1), 15, "%");
         lV80Contabilidad_conceptocompraswwds_4_cconpcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV80Contabilidad_conceptocompraswwds_4_cconpcuecod1), 15, "%");
         lV84Contabilidad_conceptocompraswwds_8_cconpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV84Contabilidad_conceptocompraswwds_8_cconpdsc2), 100, "%");
         lV84Contabilidad_conceptocompraswwds_8_cconpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV84Contabilidad_conceptocompraswwds_8_cconpdsc2), 100, "%");
         lV85Contabilidad_conceptocompraswwds_9_cconpcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV85Contabilidad_conceptocompraswwds_9_cconpcuecod2), 15, "%");
         lV85Contabilidad_conceptocompraswwds_9_cconpcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV85Contabilidad_conceptocompraswwds_9_cconpcuecod2), 15, "%");
         lV89Contabilidad_conceptocompraswwds_13_cconpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV89Contabilidad_conceptocompraswwds_13_cconpdsc3), 100, "%");
         lV89Contabilidad_conceptocompraswwds_13_cconpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV89Contabilidad_conceptocompraswwds_13_cconpdsc3), 100, "%");
         lV90Contabilidad_conceptocompraswwds_14_cconpcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV90Contabilidad_conceptocompraswwds_14_cconpcuecod3), 15, "%");
         lV90Contabilidad_conceptocompraswwds_14_cconpcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV90Contabilidad_conceptocompraswwds_14_cconpcuecod3), 15, "%");
         lV93Contabilidad_conceptocompraswwds_17_tfcconpdsc = StringUtil.PadR( StringUtil.RTrim( AV93Contabilidad_conceptocompraswwds_17_tfcconpdsc), 100, "%");
         lV95Contabilidad_conceptocompraswwds_19_tfcconpcuecod = StringUtil.PadR( StringUtil.RTrim( AV95Contabilidad_conceptocompraswwds_19_tfcconpcuecod), 15, "%");
         /* Using cursor P006X2 */
         pr_default.execute(0, new Object[] {lV79Contabilidad_conceptocompraswwds_3_cconpdsc1, lV79Contabilidad_conceptocompraswwds_3_cconpdsc1, lV80Contabilidad_conceptocompraswwds_4_cconpcuecod1, lV80Contabilidad_conceptocompraswwds_4_cconpcuecod1, lV84Contabilidad_conceptocompraswwds_8_cconpdsc2, lV84Contabilidad_conceptocompraswwds_8_cconpdsc2, lV85Contabilidad_conceptocompraswwds_9_cconpcuecod2, lV85Contabilidad_conceptocompraswwds_9_cconpcuecod2, lV89Contabilidad_conceptocompraswwds_13_cconpdsc3, lV89Contabilidad_conceptocompraswwds_13_cconpdsc3, lV90Contabilidad_conceptocompraswwds_14_cconpcuecod3, lV90Contabilidad_conceptocompraswwds_14_cconpcuecod3, AV91Contabilidad_conceptocompraswwds_15_tfcconpcod, AV92Contabilidad_conceptocompraswwds_16_tfcconpcod_to, lV93Contabilidad_conceptocompraswwds_17_tfcconpdsc, AV94Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel, lV95Contabilidad_conceptocompraswwds_19_tfcconpcuecod, AV96Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A517CConpSts = P006X2_A517CConpSts[0];
            A76CConpCod = P006X2_A76CConpCod[0];
            A77CConpCueCod = P006X2_A77CConpCueCod[0];
            A78CConpDsc = P006X2_A78CConpDsc[0];
            if ( A517CConpSts == 1 )
            {
               AV59CConpStsDescription = "ACTIVO";
            }
            else if ( A517CConpSts == 0 )
            {
               AV59CConpStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6X0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A76CConpCod), "ZZZZZ9")), 30, Gx_line+10, 154, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A78CConpDsc, "")), 158, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A77CConpCueCod, "")), 410, Gx_line+10, 534, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59CConpStsDescription, "")), 538, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV31Session.Get("Contabilidad.ConceptoComprasWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.ConceptoComprasWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Contabilidad.ConceptoComprasWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV98GXV2 = 1;
         while ( AV98GXV2 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV98GXV2));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCCONPCOD") == 0 )
            {
               AV35TFCConpCod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV36TFCConpCod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCCONPDSC") == 0 )
            {
               AV37TFCConpDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCCONPDSC_SEL") == 0 )
            {
               AV38TFCConpDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCCONPCUECOD") == 0 )
            {
               AV39TFCConpCueCod = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCCONPCUECOD_SEL") == 0 )
            {
               AV40TFCConpCueCod_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCCONPSTS_SEL") == 0 )
            {
               AV65TFCConpSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV67TFCConpSts_Sels.FromJSonString(AV65TFCConpSts_SelsJson, null);
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

      protected void H6X0( bool bFoot ,
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
                  AV55PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV52DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV50AppName = "DVelop Software Solutions";
               AV56Phone = "+1 550 8923";
               AV54Mail = "info@mail.com";
               AV58Website = "http://www.web.com";
               AV47AddressLine1 = "French Boulevard 2859";
               AV48AddressLine2 = "Downtown";
               AV49AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV57Title = "";
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14CConpDsc1 = "";
         AV15FilterCConpDscDescription = "";
         AV16CConpDsc = "";
         AV60CConpCueCod1 = "";
         AV61FilterCConpCueCodDescription = "";
         AV62CConpCueCod = "";
         AV21DynamicFiltersSelector2 = "";
         AV23CConpDsc2 = "";
         AV63CConpCueCod2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28CConpDsc3 = "";
         AV64CConpCueCod3 = "";
         AV45TFCConpCod_To_Description = "";
         AV38TFCConpDsc_Sel = "";
         AV37TFCConpDsc = "";
         AV40TFCConpCueCod_Sel = "";
         AV39TFCConpCueCod = "";
         AV67TFCConpSts_Sels = new GxSimpleCollection<short>();
         AV65TFCConpSts_SelsJson = "";
         AV66TFCConpSts_SelDscs = "";
         AV69FilterTFCConpSts_SelValueDescription = "";
         AV77Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 = "";
         AV79Contabilidad_conceptocompraswwds_3_cconpdsc1 = "";
         AV80Contabilidad_conceptocompraswwds_4_cconpcuecod1 = "";
         AV82Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 = "";
         AV84Contabilidad_conceptocompraswwds_8_cconpdsc2 = "";
         AV85Contabilidad_conceptocompraswwds_9_cconpcuecod2 = "";
         AV87Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 = "";
         AV89Contabilidad_conceptocompraswwds_13_cconpdsc3 = "";
         AV90Contabilidad_conceptocompraswwds_14_cconpcuecod3 = "";
         AV93Contabilidad_conceptocompraswwds_17_tfcconpdsc = "";
         AV94Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel = "";
         AV95Contabilidad_conceptocompraswwds_19_tfcconpcuecod = "";
         AV96Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel = "";
         AV97Contabilidad_conceptocompraswwds_21_tfcconpsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV79Contabilidad_conceptocompraswwds_3_cconpdsc1 = "";
         lV80Contabilidad_conceptocompraswwds_4_cconpcuecod1 = "";
         lV84Contabilidad_conceptocompraswwds_8_cconpdsc2 = "";
         lV85Contabilidad_conceptocompraswwds_9_cconpcuecod2 = "";
         lV89Contabilidad_conceptocompraswwds_13_cconpdsc3 = "";
         lV90Contabilidad_conceptocompraswwds_14_cconpcuecod3 = "";
         lV93Contabilidad_conceptocompraswwds_17_tfcconpdsc = "";
         lV95Contabilidad_conceptocompraswwds_19_tfcconpcuecod = "";
         A78CConpDsc = "";
         A77CConpCueCod = "";
         P006X2_A517CConpSts = new short[1] ;
         P006X2_A76CConpCod = new int[1] ;
         P006X2_A77CConpCueCod = new string[] {""} ;
         P006X2_A78CConpDsc = new string[] {""} ;
         AV59CConpStsDescription = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55PageInfo = "";
         AV52DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV50AppName = "";
         AV56Phone = "";
         AV54Mail = "";
         AV58Website = "";
         AV47AddressLine1 = "";
         AV48AddressLine2 = "";
         AV49AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.conceptocompraswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006X2_A517CConpSts, P006X2_A76CConpCod, P006X2_A77CConpCueCod, P006X2_A78CConpDsc
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
      private short AV22DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV68TFCConpSts_Sel ;
      private short AV78Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 ;
      private short AV83Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 ;
      private short AV88Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 ;
      private short A517CConpSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV35TFCConpCod ;
      private int AV36TFCConpCod_To ;
      private int AV75GXV1 ;
      private int AV91Contabilidad_conceptocompraswwds_15_tfcconpcod ;
      private int AV92Contabilidad_conceptocompraswwds_16_tfcconpcod_to ;
      private int AV97Contabilidad_conceptocompraswwds_21_tfcconpsts_sels_Count ;
      private int A76CConpCod ;
      private int AV98GXV2 ;
      private long AV70i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14CConpDsc1 ;
      private string AV16CConpDsc ;
      private string AV60CConpCueCod1 ;
      private string AV62CConpCueCod ;
      private string AV23CConpDsc2 ;
      private string AV63CConpCueCod2 ;
      private string AV28CConpDsc3 ;
      private string AV64CConpCueCod3 ;
      private string AV38TFCConpDsc_Sel ;
      private string AV37TFCConpDsc ;
      private string AV40TFCConpCueCod_Sel ;
      private string AV39TFCConpCueCod ;
      private string AV79Contabilidad_conceptocompraswwds_3_cconpdsc1 ;
      private string AV80Contabilidad_conceptocompraswwds_4_cconpcuecod1 ;
      private string AV84Contabilidad_conceptocompraswwds_8_cconpdsc2 ;
      private string AV85Contabilidad_conceptocompraswwds_9_cconpcuecod2 ;
      private string AV89Contabilidad_conceptocompraswwds_13_cconpdsc3 ;
      private string AV90Contabilidad_conceptocompraswwds_14_cconpcuecod3 ;
      private string AV93Contabilidad_conceptocompraswwds_17_tfcconpdsc ;
      private string AV94Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel ;
      private string AV95Contabilidad_conceptocompraswwds_19_tfcconpcuecod ;
      private string AV96Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel ;
      private string scmdbuf ;
      private string lV79Contabilidad_conceptocompraswwds_3_cconpdsc1 ;
      private string lV80Contabilidad_conceptocompraswwds_4_cconpcuecod1 ;
      private string lV84Contabilidad_conceptocompraswwds_8_cconpdsc2 ;
      private string lV85Contabilidad_conceptocompraswwds_9_cconpcuecod2 ;
      private string lV89Contabilidad_conceptocompraswwds_13_cconpdsc3 ;
      private string lV90Contabilidad_conceptocompraswwds_14_cconpcuecod3 ;
      private string lV93Contabilidad_conceptocompraswwds_17_tfcconpdsc ;
      private string lV95Contabilidad_conceptocompraswwds_19_tfcconpcuecod ;
      private string A78CConpDsc ;
      private string A77CConpCueCod ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV81Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 ;
      private bool AV86Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV65TFCConpSts_SelsJson ;
      private string AV57Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterCConpDscDescription ;
      private string AV61FilterCConpCueCodDescription ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV45TFCConpCod_To_Description ;
      private string AV66TFCConpSts_SelDscs ;
      private string AV69FilterTFCConpSts_SelValueDescription ;
      private string AV77Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 ;
      private string AV82Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 ;
      private string AV87Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 ;
      private string AV59CConpStsDescription ;
      private string AV55PageInfo ;
      private string AV52DateInfo ;
      private string AV50AppName ;
      private string AV56Phone ;
      private string AV54Mail ;
      private string AV58Website ;
      private string AV47AddressLine1 ;
      private string AV48AddressLine2 ;
      private string AV49AddressLine3 ;
      private GxSimpleCollection<short> AV67TFCConpSts_Sels ;
      private GxSimpleCollection<short> AV97Contabilidad_conceptocompraswwds_21_tfcconpsts_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006X2_A517CConpSts ;
      private int[] P006X2_A76CConpCod ;
      private string[] P006X2_A77CConpCueCod ;
      private string[] P006X2_A78CConpDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
   }

   public class conceptocompraswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006X2( IGxContext context ,
                                             short A517CConpSts ,
                                             GxSimpleCollection<short> AV97Contabilidad_conceptocompraswwds_21_tfcconpsts_sels ,
                                             string AV77Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 ,
                                             short AV78Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 ,
                                             string AV79Contabilidad_conceptocompraswwds_3_cconpdsc1 ,
                                             string AV80Contabilidad_conceptocompraswwds_4_cconpcuecod1 ,
                                             bool AV81Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 ,
                                             string AV82Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 ,
                                             short AV83Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 ,
                                             string AV84Contabilidad_conceptocompraswwds_8_cconpdsc2 ,
                                             string AV85Contabilidad_conceptocompraswwds_9_cconpcuecod2 ,
                                             bool AV86Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 ,
                                             string AV87Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 ,
                                             short AV88Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 ,
                                             string AV89Contabilidad_conceptocompraswwds_13_cconpdsc3 ,
                                             string AV90Contabilidad_conceptocompraswwds_14_cconpcuecod3 ,
                                             int AV91Contabilidad_conceptocompraswwds_15_tfcconpcod ,
                                             int AV92Contabilidad_conceptocompraswwds_16_tfcconpcod_to ,
                                             string AV94Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel ,
                                             string AV93Contabilidad_conceptocompraswwds_17_tfcconpdsc ,
                                             string AV96Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel ,
                                             string AV95Contabilidad_conceptocompraswwds_19_tfcconpcuecod ,
                                             int AV97Contabilidad_conceptocompraswwds_21_tfcconpsts_sels_Count ,
                                             string A78CConpDsc ,
                                             string A77CConpCueCod ,
                                             int A76CConpCod ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[18];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CConpSts], [CConpCod], [CConpCueCod], [CConpDsc] FROM [CBCOMPRASCONC]";
         if ( ( StringUtil.StrCmp(AV77Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPDSC") == 0 ) && ( AV78Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_conceptocompraswwds_3_cconpdsc1)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV79Contabilidad_conceptocompraswwds_3_cconpdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV77Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPDSC") == 0 ) && ( AV78Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_conceptocompraswwds_3_cconpdsc1)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like '%' + @lV79Contabilidad_conceptocompraswwds_3_cconpdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV77Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPCUECOD") == 0 ) && ( AV78Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_conceptocompraswwds_4_cconpcuecod1)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV80Contabilidad_conceptocompraswwds_4_cconpcuecod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV77Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPCUECOD") == 0 ) && ( AV78Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_conceptocompraswwds_4_cconpcuecod1)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like '%' + @lV80Contabilidad_conceptocompraswwds_4_cconpcuecod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV81Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPDSC") == 0 ) && ( AV83Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabilidad_conceptocompraswwds_8_cconpdsc2)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV84Contabilidad_conceptocompraswwds_8_cconpdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV81Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPDSC") == 0 ) && ( AV83Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabilidad_conceptocompraswwds_8_cconpdsc2)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like '%' + @lV84Contabilidad_conceptocompraswwds_8_cconpdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV81Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPCUECOD") == 0 ) && ( AV83Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Contabilidad_conceptocompraswwds_9_cconpcuecod2)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV85Contabilidad_conceptocompraswwds_9_cconpcuecod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV81Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPCUECOD") == 0 ) && ( AV83Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Contabilidad_conceptocompraswwds_9_cconpcuecod2)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like '%' + @lV85Contabilidad_conceptocompraswwds_9_cconpcuecod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV86Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPDSC") == 0 ) && ( AV88Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Contabilidad_conceptocompraswwds_13_cconpdsc3)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV89Contabilidad_conceptocompraswwds_13_cconpdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV86Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPDSC") == 0 ) && ( AV88Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Contabilidad_conceptocompraswwds_13_cconpdsc3)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like '%' + @lV89Contabilidad_conceptocompraswwds_13_cconpdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV86Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPCUECOD") == 0 ) && ( AV88Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Contabilidad_conceptocompraswwds_14_cconpcuecod3)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV90Contabilidad_conceptocompraswwds_14_cconpcuecod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV86Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPCUECOD") == 0 ) && ( AV88Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Contabilidad_conceptocompraswwds_14_cconpcuecod3)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like '%' + @lV90Contabilidad_conceptocompraswwds_14_cconpcuecod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV91Contabilidad_conceptocompraswwds_15_tfcconpcod) )
         {
            AddWhere(sWhereString, "([CConpCod] >= @AV91Contabilidad_conceptocompraswwds_15_tfcconpcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV92Contabilidad_conceptocompraswwds_16_tfcconpcod_to) )
         {
            AddWhere(sWhereString, "([CConpCod] <= @AV92Contabilidad_conceptocompraswwds_16_tfcconpcod_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Contabilidad_conceptocompraswwds_17_tfcconpdsc)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV93Contabilidad_conceptocompraswwds_17_tfcconpdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel)) )
         {
            AddWhere(sWhereString, "([CConpDsc] = @AV94Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Contabilidad_conceptocompraswwds_19_tfcconpcuecod)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV95Contabilidad_conceptocompraswwds_19_tfcconpcuecod)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel)) )
         {
            AddWhere(sWhereString, "([CConpCueCod] = @AV96Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV97Contabilidad_conceptocompraswwds_21_tfcconpsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV97Contabilidad_conceptocompraswwds_21_tfcconpsts_sels, "[CConpSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CConpCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CConpCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CConpDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CConpDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CConpCueCod]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CConpCueCod] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CConpSts]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CConpSts] DESC";
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
                     return conditional_P006X2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP006X2;
          prmP006X2 = new Object[] {
          new ParDef("@lV79Contabilidad_conceptocompraswwds_3_cconpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV79Contabilidad_conceptocompraswwds_3_cconpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV80Contabilidad_conceptocompraswwds_4_cconpcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV80Contabilidad_conceptocompraswwds_4_cconpcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV84Contabilidad_conceptocompraswwds_8_cconpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV84Contabilidad_conceptocompraswwds_8_cconpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV85Contabilidad_conceptocompraswwds_9_cconpcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV85Contabilidad_conceptocompraswwds_9_cconpcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV89Contabilidad_conceptocompraswwds_13_cconpdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV89Contabilidad_conceptocompraswwds_13_cconpdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV90Contabilidad_conceptocompraswwds_14_cconpcuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV90Contabilidad_conceptocompraswwds_14_cconpcuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV91Contabilidad_conceptocompraswwds_15_tfcconpcod",GXType.Int32,6,0) ,
          new ParDef("@AV92Contabilidad_conceptocompraswwds_16_tfcconpcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV93Contabilidad_conceptocompraswwds_17_tfcconpdsc",GXType.NChar,100,0) ,
          new ParDef("@AV94Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV95Contabilidad_conceptocompraswwds_19_tfcconpcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV96Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006X2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
