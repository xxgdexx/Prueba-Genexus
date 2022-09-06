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
   public class conceptobancoswwexportreport : GXWebProcedure
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

      public conceptobancoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptobancoswwexportreport( IGxContext context )
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
         conceptobancoswwexportreport objconceptobancoswwexportreport;
         objconceptobancoswwexportreport = new conceptobancoswwexportreport();
         objconceptobancoswwexportreport.context.SetSubmitInitialConfig(context);
         objconceptobancoswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptobancoswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptobancoswwexportreport)stateInfo).executePrivate();
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
            AV57Title = "Lista de Conceptos de Bancos";
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
            H5I0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CONBDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV14ConBDsc1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14ConBDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterConBDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterConBDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16ConBDsc = AV14ConBDsc1;
                  H5I0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterConBDscDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ConBDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CONBCUECOD") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV66ConBCueCod1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66ConBCueCod1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV67FilterConBCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV67FilterConBCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV68ConBCueCod = AV66ConBCueCod1;
                  H5I0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67FilterConBCueCodDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68ConBCueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV20DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CONBDSC") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV23ConBDsc2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ConBDsc2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterConBDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterConBDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16ConBDsc = AV23ConBDsc2;
                     H5I0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterConBDscDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ConBDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CONBCUECOD") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV69ConBCueCod2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ConBCueCod2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV67FilterConBCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV67FilterConBCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV68ConBCueCod = AV69ConBCueCod2;
                     H5I0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67FilterConBCueCodDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68ConBCueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONBDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV28ConBDsc3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ConBDsc3)) )
                     {
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterConBDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterConBDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16ConBDsc = AV28ConBDsc3;
                        H5I0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterConBDscDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ConBDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONBCUECOD") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV70ConBCueCod3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ConBCueCod3)) )
                     {
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV67FilterConBCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV67FilterConBCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV68ConBCueCod = AV70ConBCueCod3;
                        H5I0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67FilterConBCueCodDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68ConBCueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV35TFConBCod) && (0==AV36TFConBCod_To) ) )
         {
            H5I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35TFConBCod), "ZZZZZ9")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV45TFConBCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H5I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFConBCod_To_Description, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36TFConBCod_To), "ZZZZZ9")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFConBDsc_Sel)) )
         {
            H5I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Concepto", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFConBDsc_Sel, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFConBDsc)) )
            {
               H5I0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Concepto", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFConBDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFConBCueCod_Sel)) )
         {
            H5I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFConBCueCod_Sel, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFConBCueCod)) )
            {
               H5I0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFConBCueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFConBCueDsc_Sel)) )
         {
            H5I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descripción de Cuenta", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFConBCueDsc_Sel, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFConBCueDsc)) )
            {
               H5I0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción de Cuenta", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFConBCueDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV62TFConBSts_Sels.FromJSonString(AV60TFConBSts_SelsJson, null);
         if ( ! ( AV62TFConBSts_Sels.Count == 0 ) )
         {
            AV65i = 1;
            AV75GXV1 = 1;
            while ( AV75GXV1 <= AV62TFConBSts_Sels.Count )
            {
               AV63TFConBSts_Sel = (short)(AV62TFConBSts_Sels.GetNumeric(AV75GXV1));
               if ( AV65i == 1 )
               {
                  AV61TFConBSts_SelDscs = "";
               }
               else
               {
                  AV61TFConBSts_SelDscs += ", ";
               }
               if ( AV63TFConBSts_Sel == 1 )
               {
                  AV64FilterTFConBSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV63TFConBSts_Sel == 0 )
               {
                  AV64FilterTFConBSts_SelValueDescription = "INACTIVO";
               }
               AV61TFConBSts_SelDscs += AV64FilterTFConBSts_SelValueDescription;
               AV65i = (long)(AV65i+1);
               AV75GXV1 = (int)(AV75GXV1+1);
            }
            H5I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61TFConBSts_SelDscs, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H5I0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H5I0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 122, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Concepto", 126, Gx_line+10, 310, Gx_line+27, 0, 0, 0, 0) ;
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
         AV77Bancos_conceptobancoswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV78Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV79Bancos_conceptobancoswwds_3_conbdsc1 = AV14ConBDsc1;
         AV80Bancos_conceptobancoswwds_4_conbcuecod1 = AV66ConBCueCod1;
         AV81Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV82Bancos_conceptobancoswwds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV83Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV84Bancos_conceptobancoswwds_8_conbdsc2 = AV23ConBDsc2;
         AV85Bancos_conceptobancoswwds_9_conbcuecod2 = AV69ConBCueCod2;
         AV86Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV87Bancos_conceptobancoswwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV88Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV89Bancos_conceptobancoswwds_13_conbdsc3 = AV28ConBDsc3;
         AV90Bancos_conceptobancoswwds_14_conbcuecod3 = AV70ConBCueCod3;
         AV91Bancos_conceptobancoswwds_15_tfconbcod = AV35TFConBCod;
         AV92Bancos_conceptobancoswwds_16_tfconbcod_to = AV36TFConBCod_To;
         AV93Bancos_conceptobancoswwds_17_tfconbdsc = AV37TFConBDsc;
         AV94Bancos_conceptobancoswwds_18_tfconbdsc_sel = AV38TFConBDsc_Sel;
         AV95Bancos_conceptobancoswwds_19_tfconbcuecod = AV39TFConBCueCod;
         AV96Bancos_conceptobancoswwds_20_tfconbcuecod_sel = AV40TFConBCueCod_Sel;
         AV97Bancos_conceptobancoswwds_21_tfconbcuedsc = AV43TFConBCueDsc;
         AV98Bancos_conceptobancoswwds_22_tfconbcuedsc_sel = AV44TFConBCueDsc_Sel;
         AV99Bancos_conceptobancoswwds_23_tfconbsts_sels = AV62TFConBSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A746ConBSts ,
                                              AV99Bancos_conceptobancoswwds_23_tfconbsts_sels ,
                                              AV77Bancos_conceptobancoswwds_1_dynamicfiltersselector1 ,
                                              AV78Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 ,
                                              AV79Bancos_conceptobancoswwds_3_conbdsc1 ,
                                              AV80Bancos_conceptobancoswwds_4_conbcuecod1 ,
                                              AV81Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 ,
                                              AV82Bancos_conceptobancoswwds_6_dynamicfiltersselector2 ,
                                              AV83Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 ,
                                              AV84Bancos_conceptobancoswwds_8_conbdsc2 ,
                                              AV85Bancos_conceptobancoswwds_9_conbcuecod2 ,
                                              AV86Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 ,
                                              AV87Bancos_conceptobancoswwds_11_dynamicfiltersselector3 ,
                                              AV88Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 ,
                                              AV89Bancos_conceptobancoswwds_13_conbdsc3 ,
                                              AV90Bancos_conceptobancoswwds_14_conbcuecod3 ,
                                              AV91Bancos_conceptobancoswwds_15_tfconbcod ,
                                              AV92Bancos_conceptobancoswwds_16_tfconbcod_to ,
                                              AV94Bancos_conceptobancoswwds_18_tfconbdsc_sel ,
                                              AV93Bancos_conceptobancoswwds_17_tfconbdsc ,
                                              AV96Bancos_conceptobancoswwds_20_tfconbcuecod_sel ,
                                              AV95Bancos_conceptobancoswwds_19_tfconbcuecod ,
                                              AV98Bancos_conceptobancoswwds_22_tfconbcuedsc_sel ,
                                              AV97Bancos_conceptobancoswwds_21_tfconbcuedsc ,
                                              AV99Bancos_conceptobancoswwds_23_tfconbsts_sels.Count ,
                                              A745ConBDsc ,
                                              A374ConBCueCod ,
                                              A355ConBCod ,
                                              A744ConBCueDsc ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV79Bancos_conceptobancoswwds_3_conbdsc1 = StringUtil.PadR( StringUtil.RTrim( AV79Bancos_conceptobancoswwds_3_conbdsc1), 100, "%");
         lV79Bancos_conceptobancoswwds_3_conbdsc1 = StringUtil.PadR( StringUtil.RTrim( AV79Bancos_conceptobancoswwds_3_conbdsc1), 100, "%");
         lV80Bancos_conceptobancoswwds_4_conbcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV80Bancos_conceptobancoswwds_4_conbcuecod1), 15, "%");
         lV80Bancos_conceptobancoswwds_4_conbcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV80Bancos_conceptobancoswwds_4_conbcuecod1), 15, "%");
         lV84Bancos_conceptobancoswwds_8_conbdsc2 = StringUtil.PadR( StringUtil.RTrim( AV84Bancos_conceptobancoswwds_8_conbdsc2), 100, "%");
         lV84Bancos_conceptobancoswwds_8_conbdsc2 = StringUtil.PadR( StringUtil.RTrim( AV84Bancos_conceptobancoswwds_8_conbdsc2), 100, "%");
         lV85Bancos_conceptobancoswwds_9_conbcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV85Bancos_conceptobancoswwds_9_conbcuecod2), 15, "%");
         lV85Bancos_conceptobancoswwds_9_conbcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV85Bancos_conceptobancoswwds_9_conbcuecod2), 15, "%");
         lV89Bancos_conceptobancoswwds_13_conbdsc3 = StringUtil.PadR( StringUtil.RTrim( AV89Bancos_conceptobancoswwds_13_conbdsc3), 100, "%");
         lV89Bancos_conceptobancoswwds_13_conbdsc3 = StringUtil.PadR( StringUtil.RTrim( AV89Bancos_conceptobancoswwds_13_conbdsc3), 100, "%");
         lV90Bancos_conceptobancoswwds_14_conbcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV90Bancos_conceptobancoswwds_14_conbcuecod3), 15, "%");
         lV90Bancos_conceptobancoswwds_14_conbcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV90Bancos_conceptobancoswwds_14_conbcuecod3), 15, "%");
         lV93Bancos_conceptobancoswwds_17_tfconbdsc = StringUtil.PadR( StringUtil.RTrim( AV93Bancos_conceptobancoswwds_17_tfconbdsc), 100, "%");
         lV95Bancos_conceptobancoswwds_19_tfconbcuecod = StringUtil.PadR( StringUtil.RTrim( AV95Bancos_conceptobancoswwds_19_tfconbcuecod), 15, "%");
         lV97Bancos_conceptobancoswwds_21_tfconbcuedsc = StringUtil.PadR( StringUtil.RTrim( AV97Bancos_conceptobancoswwds_21_tfconbcuedsc), 100, "%");
         /* Using cursor P005I2 */
         pr_default.execute(0, new Object[] {lV79Bancos_conceptobancoswwds_3_conbdsc1, lV79Bancos_conceptobancoswwds_3_conbdsc1, lV80Bancos_conceptobancoswwds_4_conbcuecod1, lV80Bancos_conceptobancoswwds_4_conbcuecod1, lV84Bancos_conceptobancoswwds_8_conbdsc2, lV84Bancos_conceptobancoswwds_8_conbdsc2, lV85Bancos_conceptobancoswwds_9_conbcuecod2, lV85Bancos_conceptobancoswwds_9_conbcuecod2, lV89Bancos_conceptobancoswwds_13_conbdsc3, lV89Bancos_conceptobancoswwds_13_conbdsc3, lV90Bancos_conceptobancoswwds_14_conbcuecod3, lV90Bancos_conceptobancoswwds_14_conbcuecod3, AV91Bancos_conceptobancoswwds_15_tfconbcod, AV92Bancos_conceptobancoswwds_16_tfconbcod_to, lV93Bancos_conceptobancoswwds_17_tfconbdsc, AV94Bancos_conceptobancoswwds_18_tfconbdsc_sel, lV95Bancos_conceptobancoswwds_19_tfconbcuecod, AV96Bancos_conceptobancoswwds_20_tfconbcuecod_sel, lV97Bancos_conceptobancoswwds_21_tfconbcuedsc, AV98Bancos_conceptobancoswwds_22_tfconbcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A746ConBSts = P005I2_A746ConBSts[0];
            A744ConBCueDsc = P005I2_A744ConBCueDsc[0];
            A355ConBCod = P005I2_A355ConBCod[0];
            A374ConBCueCod = P005I2_A374ConBCueCod[0];
            A745ConBDsc = P005I2_A745ConBDsc[0];
            A744ConBCueDsc = P005I2_A744ConBCueDsc[0];
            if ( A746ConBSts == 1 )
            {
               AV59ConBStsDescription = "ACTIVO";
            }
            else if ( A746ConBSts == 0 )
            {
               AV59ConBStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H5I0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A355ConBCod), "ZZZZZ9")), 30, Gx_line+10, 122, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A745ConBDsc, "")), 126, Gx_line+10, 310, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A374ConBCueCod, "")), 314, Gx_line+10, 407, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A744ConBCueDsc, "")), 411, Gx_line+10, 597, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59ConBStsDescription, "")), 601, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV31Session.Get("Bancos.ConceptoBancosWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.ConceptoBancosWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Bancos.ConceptoBancosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV100GXV2 = 1;
         while ( AV100GXV2 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV100GXV2));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONBCOD") == 0 )
            {
               AV35TFConBCod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV36TFConBCod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONBDSC") == 0 )
            {
               AV37TFConBDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONBDSC_SEL") == 0 )
            {
               AV38TFConBDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONBCUECOD") == 0 )
            {
               AV39TFConBCueCod = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONBCUECOD_SEL") == 0 )
            {
               AV40TFConBCueCod_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONBCUEDSC") == 0 )
            {
               AV43TFConBCueDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONBCUEDSC_SEL") == 0 )
            {
               AV44TFConBCueDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONBSTS_SEL") == 0 )
            {
               AV60TFConBSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV62TFConBSts_Sels.FromJSonString(AV60TFConBSts_SelsJson, null);
            }
            AV100GXV2 = (int)(AV100GXV2+1);
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

      protected void H5I0( bool bFoot ,
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
         AV14ConBDsc1 = "";
         AV15FilterConBDscDescription = "";
         AV16ConBDsc = "";
         AV66ConBCueCod1 = "";
         AV67FilterConBCueCodDescription = "";
         AV68ConBCueCod = "";
         AV21DynamicFiltersSelector2 = "";
         AV23ConBDsc2 = "";
         AV69ConBCueCod2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28ConBDsc3 = "";
         AV70ConBCueCod3 = "";
         AV45TFConBCod_To_Description = "";
         AV38TFConBDsc_Sel = "";
         AV37TFConBDsc = "";
         AV40TFConBCueCod_Sel = "";
         AV39TFConBCueCod = "";
         AV44TFConBCueDsc_Sel = "";
         AV43TFConBCueDsc = "";
         AV62TFConBSts_Sels = new GxSimpleCollection<short>();
         AV60TFConBSts_SelsJson = "";
         AV61TFConBSts_SelDscs = "";
         AV64FilterTFConBSts_SelValueDescription = "";
         AV77Bancos_conceptobancoswwds_1_dynamicfiltersselector1 = "";
         AV79Bancos_conceptobancoswwds_3_conbdsc1 = "";
         AV80Bancos_conceptobancoswwds_4_conbcuecod1 = "";
         AV82Bancos_conceptobancoswwds_6_dynamicfiltersselector2 = "";
         AV84Bancos_conceptobancoswwds_8_conbdsc2 = "";
         AV85Bancos_conceptobancoswwds_9_conbcuecod2 = "";
         AV87Bancos_conceptobancoswwds_11_dynamicfiltersselector3 = "";
         AV89Bancos_conceptobancoswwds_13_conbdsc3 = "";
         AV90Bancos_conceptobancoswwds_14_conbcuecod3 = "";
         AV93Bancos_conceptobancoswwds_17_tfconbdsc = "";
         AV94Bancos_conceptobancoswwds_18_tfconbdsc_sel = "";
         AV95Bancos_conceptobancoswwds_19_tfconbcuecod = "";
         AV96Bancos_conceptobancoswwds_20_tfconbcuecod_sel = "";
         AV97Bancos_conceptobancoswwds_21_tfconbcuedsc = "";
         AV98Bancos_conceptobancoswwds_22_tfconbcuedsc_sel = "";
         AV99Bancos_conceptobancoswwds_23_tfconbsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV79Bancos_conceptobancoswwds_3_conbdsc1 = "";
         lV80Bancos_conceptobancoswwds_4_conbcuecod1 = "";
         lV84Bancos_conceptobancoswwds_8_conbdsc2 = "";
         lV85Bancos_conceptobancoswwds_9_conbcuecod2 = "";
         lV89Bancos_conceptobancoswwds_13_conbdsc3 = "";
         lV90Bancos_conceptobancoswwds_14_conbcuecod3 = "";
         lV93Bancos_conceptobancoswwds_17_tfconbdsc = "";
         lV95Bancos_conceptobancoswwds_19_tfconbcuecod = "";
         lV97Bancos_conceptobancoswwds_21_tfconbcuedsc = "";
         A745ConBDsc = "";
         A374ConBCueCod = "";
         A744ConBCueDsc = "";
         P005I2_A746ConBSts = new short[1] ;
         P005I2_A744ConBCueDsc = new string[] {""} ;
         P005I2_A355ConBCod = new int[1] ;
         P005I2_A374ConBCueCod = new string[] {""} ;
         P005I2_A745ConBDsc = new string[] {""} ;
         AV59ConBStsDescription = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.conceptobancoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P005I2_A746ConBSts, P005I2_A744ConBCueDsc, P005I2_A355ConBCod, P005I2_A374ConBCueCod, P005I2_A745ConBDsc
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
      private short AV63TFConBSts_Sel ;
      private short AV78Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 ;
      private short AV83Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 ;
      private short AV88Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 ;
      private short A746ConBSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV35TFConBCod ;
      private int AV36TFConBCod_To ;
      private int AV75GXV1 ;
      private int AV91Bancos_conceptobancoswwds_15_tfconbcod ;
      private int AV92Bancos_conceptobancoswwds_16_tfconbcod_to ;
      private int AV99Bancos_conceptobancoswwds_23_tfconbsts_sels_Count ;
      private int A355ConBCod ;
      private int AV100GXV2 ;
      private long AV65i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14ConBDsc1 ;
      private string AV16ConBDsc ;
      private string AV66ConBCueCod1 ;
      private string AV68ConBCueCod ;
      private string AV23ConBDsc2 ;
      private string AV69ConBCueCod2 ;
      private string AV28ConBDsc3 ;
      private string AV70ConBCueCod3 ;
      private string AV38TFConBDsc_Sel ;
      private string AV37TFConBDsc ;
      private string AV40TFConBCueCod_Sel ;
      private string AV39TFConBCueCod ;
      private string AV44TFConBCueDsc_Sel ;
      private string AV43TFConBCueDsc ;
      private string AV79Bancos_conceptobancoswwds_3_conbdsc1 ;
      private string AV80Bancos_conceptobancoswwds_4_conbcuecod1 ;
      private string AV84Bancos_conceptobancoswwds_8_conbdsc2 ;
      private string AV85Bancos_conceptobancoswwds_9_conbcuecod2 ;
      private string AV89Bancos_conceptobancoswwds_13_conbdsc3 ;
      private string AV90Bancos_conceptobancoswwds_14_conbcuecod3 ;
      private string AV93Bancos_conceptobancoswwds_17_tfconbdsc ;
      private string AV94Bancos_conceptobancoswwds_18_tfconbdsc_sel ;
      private string AV95Bancos_conceptobancoswwds_19_tfconbcuecod ;
      private string AV96Bancos_conceptobancoswwds_20_tfconbcuecod_sel ;
      private string AV97Bancos_conceptobancoswwds_21_tfconbcuedsc ;
      private string AV98Bancos_conceptobancoswwds_22_tfconbcuedsc_sel ;
      private string scmdbuf ;
      private string lV79Bancos_conceptobancoswwds_3_conbdsc1 ;
      private string lV80Bancos_conceptobancoswwds_4_conbcuecod1 ;
      private string lV84Bancos_conceptobancoswwds_8_conbdsc2 ;
      private string lV85Bancos_conceptobancoswwds_9_conbcuecod2 ;
      private string lV89Bancos_conceptobancoswwds_13_conbdsc3 ;
      private string lV90Bancos_conceptobancoswwds_14_conbcuecod3 ;
      private string lV93Bancos_conceptobancoswwds_17_tfconbdsc ;
      private string lV95Bancos_conceptobancoswwds_19_tfconbcuecod ;
      private string lV97Bancos_conceptobancoswwds_21_tfconbcuedsc ;
      private string A745ConBDsc ;
      private string A374ConBCueCod ;
      private string A744ConBCueDsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV81Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 ;
      private bool AV86Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV60TFConBSts_SelsJson ;
      private string AV57Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterConBDscDescription ;
      private string AV67FilterConBCueCodDescription ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV45TFConBCod_To_Description ;
      private string AV61TFConBSts_SelDscs ;
      private string AV64FilterTFConBSts_SelValueDescription ;
      private string AV77Bancos_conceptobancoswwds_1_dynamicfiltersselector1 ;
      private string AV82Bancos_conceptobancoswwds_6_dynamicfiltersselector2 ;
      private string AV87Bancos_conceptobancoswwds_11_dynamicfiltersselector3 ;
      private string AV59ConBStsDescription ;
      private string AV55PageInfo ;
      private string AV52DateInfo ;
      private string AV50AppName ;
      private string AV56Phone ;
      private string AV54Mail ;
      private string AV58Website ;
      private string AV47AddressLine1 ;
      private string AV48AddressLine2 ;
      private string AV49AddressLine3 ;
      private GxSimpleCollection<short> AV62TFConBSts_Sels ;
      private GxSimpleCollection<short> AV99Bancos_conceptobancoswwds_23_tfconbsts_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005I2_A746ConBSts ;
      private string[] P005I2_A744ConBCueDsc ;
      private int[] P005I2_A355ConBCod ;
      private string[] P005I2_A374ConBCueCod ;
      private string[] P005I2_A745ConBDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
   }

   public class conceptobancoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005I2( IGxContext context ,
                                             short A746ConBSts ,
                                             GxSimpleCollection<short> AV99Bancos_conceptobancoswwds_23_tfconbsts_sels ,
                                             string AV77Bancos_conceptobancoswwds_1_dynamicfiltersselector1 ,
                                             short AV78Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV79Bancos_conceptobancoswwds_3_conbdsc1 ,
                                             string AV80Bancos_conceptobancoswwds_4_conbcuecod1 ,
                                             bool AV81Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 ,
                                             string AV82Bancos_conceptobancoswwds_6_dynamicfiltersselector2 ,
                                             short AV83Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 ,
                                             string AV84Bancos_conceptobancoswwds_8_conbdsc2 ,
                                             string AV85Bancos_conceptobancoswwds_9_conbcuecod2 ,
                                             bool AV86Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 ,
                                             string AV87Bancos_conceptobancoswwds_11_dynamicfiltersselector3 ,
                                             short AV88Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 ,
                                             string AV89Bancos_conceptobancoswwds_13_conbdsc3 ,
                                             string AV90Bancos_conceptobancoswwds_14_conbcuecod3 ,
                                             int AV91Bancos_conceptobancoswwds_15_tfconbcod ,
                                             int AV92Bancos_conceptobancoswwds_16_tfconbcod_to ,
                                             string AV94Bancos_conceptobancoswwds_18_tfconbdsc_sel ,
                                             string AV93Bancos_conceptobancoswwds_17_tfconbdsc ,
                                             string AV96Bancos_conceptobancoswwds_20_tfconbcuecod_sel ,
                                             string AV95Bancos_conceptobancoswwds_19_tfconbcuecod ,
                                             string AV98Bancos_conceptobancoswwds_22_tfconbcuedsc_sel ,
                                             string AV97Bancos_conceptobancoswwds_21_tfconbcuedsc ,
                                             int AV99Bancos_conceptobancoswwds_23_tfconbsts_sels_Count ,
                                             string A745ConBDsc ,
                                             string A374ConBCueCod ,
                                             int A355ConBCod ,
                                             string A744ConBCueDsc ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ConBSts], T2.[CueDsc] AS ConBCueDsc, T1.[ConBCod], T1.[ConBCueCod] AS ConBCueCod, T1.[ConBDsc] FROM ([TSCONCEPTOBANCOS] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[ConBCueCod])";
         if ( ( StringUtil.StrCmp(AV77Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBDSC") == 0 ) && ( AV78Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptobancoswwds_3_conbdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV79Bancos_conceptobancoswwds_3_conbdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV77Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBDSC") == 0 ) && ( AV78Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptobancoswwds_3_conbdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV79Bancos_conceptobancoswwds_3_conbdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV77Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBCUECOD") == 0 ) && ( AV78Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_conceptobancoswwds_4_conbcuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV80Bancos_conceptobancoswwds_4_conbcuecod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV77Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBCUECOD") == 0 ) && ( AV78Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_conceptobancoswwds_4_conbcuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV80Bancos_conceptobancoswwds_4_conbcuecod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV81Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBDSC") == 0 ) && ( AV83Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Bancos_conceptobancoswwds_8_conbdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV84Bancos_conceptobancoswwds_8_conbdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV81Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBDSC") == 0 ) && ( AV83Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Bancos_conceptobancoswwds_8_conbdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV84Bancos_conceptobancoswwds_8_conbdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV81Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBCUECOD") == 0 ) && ( AV83Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Bancos_conceptobancoswwds_9_conbcuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV85Bancos_conceptobancoswwds_9_conbcuecod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV81Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBCUECOD") == 0 ) && ( AV83Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Bancos_conceptobancoswwds_9_conbcuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV85Bancos_conceptobancoswwds_9_conbcuecod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV86Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBDSC") == 0 ) && ( AV88Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Bancos_conceptobancoswwds_13_conbdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV89Bancos_conceptobancoswwds_13_conbdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV86Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBDSC") == 0 ) && ( AV88Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Bancos_conceptobancoswwds_13_conbdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV89Bancos_conceptobancoswwds_13_conbdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV86Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBCUECOD") == 0 ) && ( AV88Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_conceptobancoswwds_14_conbcuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV90Bancos_conceptobancoswwds_14_conbcuecod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV86Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBCUECOD") == 0 ) && ( AV88Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_conceptobancoswwds_14_conbcuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV90Bancos_conceptobancoswwds_14_conbcuecod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV91Bancos_conceptobancoswwds_15_tfconbcod) )
         {
            AddWhere(sWhereString, "(T1.[ConBCod] >= @AV91Bancos_conceptobancoswwds_15_tfconbcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV92Bancos_conceptobancoswwds_16_tfconbcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConBCod] <= @AV92Bancos_conceptobancoswwds_16_tfconbcod_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Bancos_conceptobancoswwds_18_tfconbdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Bancos_conceptobancoswwds_17_tfconbdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV93Bancos_conceptobancoswwds_17_tfconbdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Bancos_conceptobancoswwds_18_tfconbdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] = @AV94Bancos_conceptobancoswwds_18_tfconbdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Bancos_conceptobancoswwds_20_tfconbcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Bancos_conceptobancoswwds_19_tfconbcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV95Bancos_conceptobancoswwds_19_tfconbcuecod)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Bancos_conceptobancoswwds_20_tfconbcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] = @AV96Bancos_conceptobancoswwds_20_tfconbcuecod_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Bancos_conceptobancoswwds_21_tfconbcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV97Bancos_conceptobancoswwds_21_tfconbcuedsc)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV98Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV99Bancos_conceptobancoswwds_23_tfconbsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV99Bancos_conceptobancoswwds_23_tfconbsts_sels, "T1.[ConBSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConBCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConBCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConBDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConBDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConBCueCod]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConBCueCod] DESC";
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
            scmdbuf += " ORDER BY T1.[ConBSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConBSts] DESC";
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
                     return conditional_P005I2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP005I2;
          prmP005I2 = new Object[] {
          new ParDef("@lV79Bancos_conceptobancoswwds_3_conbdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV79Bancos_conceptobancoswwds_3_conbdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV80Bancos_conceptobancoswwds_4_conbcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV80Bancos_conceptobancoswwds_4_conbcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV84Bancos_conceptobancoswwds_8_conbdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV84Bancos_conceptobancoswwds_8_conbdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV85Bancos_conceptobancoswwds_9_conbcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV85Bancos_conceptobancoswwds_9_conbcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV89Bancos_conceptobancoswwds_13_conbdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV89Bancos_conceptobancoswwds_13_conbdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV90Bancos_conceptobancoswwds_14_conbcuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV90Bancos_conceptobancoswwds_14_conbcuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV91Bancos_conceptobancoswwds_15_tfconbcod",GXType.Int32,6,0) ,
          new ParDef("@AV92Bancos_conceptobancoswwds_16_tfconbcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV93Bancos_conceptobancoswwds_17_tfconbdsc",GXType.NChar,100,0) ,
          new ParDef("@AV94Bancos_conceptobancoswwds_18_tfconbdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV95Bancos_conceptobancoswwds_19_tfconbcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV96Bancos_conceptobancoswwds_20_tfconbcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV97Bancos_conceptobancoswwds_21_tfconbcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV98Bancos_conceptobancoswwds_22_tfconbcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005I2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
