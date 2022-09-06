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
   public class conceptoscajachicawwexportreport : GXWebProcedure
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

      public conceptoscajachicawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptoscajachicawwexportreport( IGxContext context )
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
         conceptoscajachicawwexportreport objconceptoscajachicawwexportreport;
         objconceptoscajachicawwexportreport = new conceptoscajachicawwexportreport();
         objconceptoscajachicawwexportreport.context.SetSubmitInitialConfig(context);
         objconceptoscajachicawwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptoscajachicawwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptoscajachicawwexportreport)stateInfo).executePrivate();
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
            AV56Title = "Lista de Conceptos de Caja Chica";
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
            H5Q0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CONCAJDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15ConCajDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ConCajDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterConCajDscDescription = StringUtil.Format( "%1 (%2)", "Concepto Caja Chica", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterConCajDscDescription = StringUtil.Format( "%1 (%2)", "Concepto Caja Chica", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17ConCajDsc = AV15ConCajDsc1;
                  H5Q0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterConCajDscDescription, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ConCajDsc, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CUECOD") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV58CueCod1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58CueCod1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV59FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV59FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV60CueCod = AV58CueCod1;
                  H5Q0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59FilterCueCodDescription, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60CueCod, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONCAJDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21ConCajDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ConCajDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterConCajDscDescription = StringUtil.Format( "%1 (%2)", "Concepto Caja Chica", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterConCajDscDescription = StringUtil.Format( "%1 (%2)", "Concepto Caja Chica", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17ConCajDsc = AV21ConCajDsc2;
                     H5Q0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterConCajDscDescription, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ConCajDsc, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CUECOD") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV61CueCod2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61CueCod2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV59FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV59FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV60CueCod = AV61CueCod2;
                     H5Q0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59FilterCueCodDescription, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60CueCod, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONCAJDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25ConCajDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ConCajDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterConCajDscDescription = StringUtil.Format( "%1 (%2)", "Concepto Caja Chica", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterConCajDscDescription = StringUtil.Format( "%1 (%2)", "Concepto Caja Chica", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17ConCajDsc = AV25ConCajDsc3;
                        H5Q0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterConCajDscDescription, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ConCajDsc, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CUECOD") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV62CueCod3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62CueCod3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV59FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV59FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV60CueCod = AV62CueCod3;
                        H5Q0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59FilterCueCodDescription, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60CueCod, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFConCajCod) && (0==AV32TFConCajCod_To) ) )
         {
            H5Q0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFConCajCod), "ZZZZZ9")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFConCajCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H5Q0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFConCajCod_To_Description, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFConCajCod_To), "ZZZZZ9")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFConCajDsc_Sel)) )
         {
            H5Q0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Concepto de Caja Chica", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFConCajDsc_Sel, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFConCajDsc)) )
            {
               H5Q0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Concepto de Caja Chica", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFConCajDsc, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCueCod_Sel)) )
         {
            H5Q0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFCueCod_Sel, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCueCod)) )
            {
               H5Q0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFCueCod, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCueDsc_Sel)) )
         {
            H5Q0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descripción de Cuenta", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFCueDsc_Sel, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCueDsc)) )
            {
               H5Q0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción de Cuenta", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFCueDsc, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV41TFConCajSts_Sels.FromJSonString(AV39TFConCajSts_SelsJson, null);
         if ( ! ( AV41TFConCajSts_Sels.Count == 0 ) )
         {
            AV45i = 1;
            AV67GXV1 = 1;
            while ( AV67GXV1 <= AV41TFConCajSts_Sels.Count )
            {
               AV42TFConCajSts_Sel = (short)(AV41TFConCajSts_Sels.GetNumeric(AV67GXV1));
               if ( AV45i == 1 )
               {
                  AV40TFConCajSts_SelDscs = "";
               }
               else
               {
                  AV40TFConCajSts_SelDscs += ", ";
               }
               if ( AV42TFConCajSts_Sel == 1 )
               {
                  AV44FilterTFConCajSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV42TFConCajSts_Sel == 0 )
               {
                  AV44FilterTFConCajSts_SelValueDescription = "INACTIVO";
               }
               AV40TFConCajSts_SelDscs += AV44FilterTFConCajSts_SelValueDescription;
               AV45i = (long)(AV45i+1);
               AV67GXV1 = (int)(AV67GXV1+1);
            }
            H5Q0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFConCajSts_SelDscs, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H5Q0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H5Q0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 122, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Concepto de Caja Chica", 126, Gx_line+10, 310, Gx_line+27, 0, 0, 0, 0) ;
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
         AV69Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV70Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV71Bancos_conceptoscajachicawwds_3_concajdsc1 = AV15ConCajDsc1;
         AV72Bancos_conceptoscajachicawwds_4_cuecod1 = AV58CueCod1;
         AV73Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV74Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV75Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV76Bancos_conceptoscajachicawwds_8_concajdsc2 = AV21ConCajDsc2;
         AV77Bancos_conceptoscajachicawwds_9_cuecod2 = AV61CueCod2;
         AV78Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV79Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV80Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV81Bancos_conceptoscajachicawwds_13_concajdsc3 = AV25ConCajDsc3;
         AV82Bancos_conceptoscajachicawwds_14_cuecod3 = AV62CueCod3;
         AV83Bancos_conceptoscajachicawwds_15_tfconcajcod = AV31TFConCajCod;
         AV84Bancos_conceptoscajachicawwds_16_tfconcajcod_to = AV32TFConCajCod_To;
         AV85Bancos_conceptoscajachicawwds_17_tfconcajdsc = AV33TFConCajDsc;
         AV86Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel = AV34TFConCajDsc_Sel;
         AV87Bancos_conceptoscajachicawwds_19_tfcuecod = AV35TFCueCod;
         AV88Bancos_conceptoscajachicawwds_20_tfcuecod_sel = AV36TFCueCod_Sel;
         AV89Bancos_conceptoscajachicawwds_21_tfcuedsc = AV37TFCueDsc;
         AV90Bancos_conceptoscajachicawwds_22_tfcuedsc_sel = AV38TFCueDsc_Sel;
         AV91Bancos_conceptoscajachicawwds_23_tfconcajsts_sels = AV41TFConCajSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A748ConCajSts ,
                                              AV91Bancos_conceptoscajachicawwds_23_tfconcajsts_sels ,
                                              AV69Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 ,
                                              AV70Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 ,
                                              AV71Bancos_conceptoscajachicawwds_3_concajdsc1 ,
                                              AV72Bancos_conceptoscajachicawwds_4_cuecod1 ,
                                              AV73Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 ,
                                              AV74Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 ,
                                              AV75Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 ,
                                              AV76Bancos_conceptoscajachicawwds_8_concajdsc2 ,
                                              AV77Bancos_conceptoscajachicawwds_9_cuecod2 ,
                                              AV78Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 ,
                                              AV79Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 ,
                                              AV80Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 ,
                                              AV81Bancos_conceptoscajachicawwds_13_concajdsc3 ,
                                              AV82Bancos_conceptoscajachicawwds_14_cuecod3 ,
                                              AV83Bancos_conceptoscajachicawwds_15_tfconcajcod ,
                                              AV84Bancos_conceptoscajachicawwds_16_tfconcajcod_to ,
                                              AV86Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel ,
                                              AV85Bancos_conceptoscajachicawwds_17_tfconcajdsc ,
                                              AV88Bancos_conceptoscajachicawwds_20_tfcuecod_sel ,
                                              AV87Bancos_conceptoscajachicawwds_19_tfcuecod ,
                                              AV90Bancos_conceptoscajachicawwds_22_tfcuedsc_sel ,
                                              AV89Bancos_conceptoscajachicawwds_21_tfcuedsc ,
                                              AV91Bancos_conceptoscajachicawwds_23_tfconcajsts_sels.Count ,
                                              A747ConCajDsc ,
                                              A91CueCod ,
                                              A375ConCajCod ,
                                              A860CueDsc ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV71Bancos_conceptoscajachicawwds_3_concajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_conceptoscajachicawwds_3_concajdsc1), 100, "%");
         lV71Bancos_conceptoscajachicawwds_3_concajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_conceptoscajachicawwds_3_concajdsc1), 100, "%");
         lV72Bancos_conceptoscajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_conceptoscajachicawwds_4_cuecod1), 15, "%");
         lV72Bancos_conceptoscajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_conceptoscajachicawwds_4_cuecod1), 15, "%");
         lV76Bancos_conceptoscajachicawwds_8_concajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_conceptoscajachicawwds_8_concajdsc2), 100, "%");
         lV76Bancos_conceptoscajachicawwds_8_concajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_conceptoscajachicawwds_8_concajdsc2), 100, "%");
         lV77Bancos_conceptoscajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_conceptoscajachicawwds_9_cuecod2), 15, "%");
         lV77Bancos_conceptoscajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_conceptoscajachicawwds_9_cuecod2), 15, "%");
         lV81Bancos_conceptoscajachicawwds_13_concajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV81Bancos_conceptoscajachicawwds_13_concajdsc3), 100, "%");
         lV81Bancos_conceptoscajachicawwds_13_concajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV81Bancos_conceptoscajachicawwds_13_concajdsc3), 100, "%");
         lV82Bancos_conceptoscajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV82Bancos_conceptoscajachicawwds_14_cuecod3), 15, "%");
         lV82Bancos_conceptoscajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV82Bancos_conceptoscajachicawwds_14_cuecod3), 15, "%");
         lV85Bancos_conceptoscajachicawwds_17_tfconcajdsc = StringUtil.PadR( StringUtil.RTrim( AV85Bancos_conceptoscajachicawwds_17_tfconcajdsc), 100, "%");
         lV87Bancos_conceptoscajachicawwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV87Bancos_conceptoscajachicawwds_19_tfcuecod), 15, "%");
         lV89Bancos_conceptoscajachicawwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV89Bancos_conceptoscajachicawwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005Q2 */
         pr_default.execute(0, new Object[] {lV71Bancos_conceptoscajachicawwds_3_concajdsc1, lV71Bancos_conceptoscajachicawwds_3_concajdsc1, lV72Bancos_conceptoscajachicawwds_4_cuecod1, lV72Bancos_conceptoscajachicawwds_4_cuecod1, lV76Bancos_conceptoscajachicawwds_8_concajdsc2, lV76Bancos_conceptoscajachicawwds_8_concajdsc2, lV77Bancos_conceptoscajachicawwds_9_cuecod2, lV77Bancos_conceptoscajachicawwds_9_cuecod2, lV81Bancos_conceptoscajachicawwds_13_concajdsc3, lV81Bancos_conceptoscajachicawwds_13_concajdsc3, lV82Bancos_conceptoscajachicawwds_14_cuecod3, lV82Bancos_conceptoscajachicawwds_14_cuecod3, AV83Bancos_conceptoscajachicawwds_15_tfconcajcod, AV84Bancos_conceptoscajachicawwds_16_tfconcajcod_to, lV85Bancos_conceptoscajachicawwds_17_tfconcajdsc, AV86Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel, lV87Bancos_conceptoscajachicawwds_19_tfcuecod, AV88Bancos_conceptoscajachicawwds_20_tfcuecod_sel, lV89Bancos_conceptoscajachicawwds_21_tfcuedsc, AV90Bancos_conceptoscajachicawwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A748ConCajSts = P005Q2_A748ConCajSts[0];
            A860CueDsc = P005Q2_A860CueDsc[0];
            A375ConCajCod = P005Q2_A375ConCajCod[0];
            A91CueCod = P005Q2_A91CueCod[0];
            A747ConCajDsc = P005Q2_A747ConCajDsc[0];
            A860CueDsc = P005Q2_A860CueDsc[0];
            if ( A748ConCajSts == 1 )
            {
               AV12ConCajStsDescription = "ACTIVO";
            }
            else if ( A748ConCajSts == 0 )
            {
               AV12ConCajStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H5Q0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A375ConCajCod), "ZZZZZ9")), 30, Gx_line+10, 122, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A747ConCajDsc, "")), 126, Gx_line+10, 310, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), 314, Gx_line+10, 407, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A860CueDsc, "")), 411, Gx_line+10, 597, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12ConCajStsDescription, "")), 601, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Bancos.ConceptosCajaChicaWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.ConceptosCajaChicaWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Bancos.ConceptosCajaChicaWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV92GXV2 = 1;
         while ( AV92GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV92GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCONCAJCOD") == 0 )
            {
               AV31TFConCajCod = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV32TFConCajCod_To = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCONCAJDSC") == 0 )
            {
               AV33TFConCajDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCONCAJDSC_SEL") == 0 )
            {
               AV34TFConCajDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV35TFCueCod = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV36TFCueCod_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV37TFCueDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV38TFCueDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCONCAJSTS_SEL") == 0 )
            {
               AV39TFConCajSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV41TFConCajSts_Sels.FromJSonString(AV39TFConCajSts_SelsJson, null);
            }
            AV92GXV2 = (int)(AV92GXV2+1);
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

      protected void H5Q0( bool bFoot ,
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
                  AV54PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV51DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV49AppName = "DVelop Software Solutions";
               AV55Phone = "+1 550 8923";
               AV53Mail = "info@mail.com";
               AV57Website = "http://www.web.com";
               AV46AddressLine1 = "French Boulevard 2859";
               AV47AddressLine2 = "Downtown";
               AV48AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV56Title = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15ConCajDsc1 = "";
         AV16FilterConCajDscDescription = "";
         AV17ConCajDsc = "";
         AV58CueCod1 = "";
         AV59FilterCueCodDescription = "";
         AV60CueCod = "";
         AV19DynamicFiltersSelector2 = "";
         AV21ConCajDsc2 = "";
         AV61CueCod2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25ConCajDsc3 = "";
         AV62CueCod3 = "";
         AV43TFConCajCod_To_Description = "";
         AV34TFConCajDsc_Sel = "";
         AV33TFConCajDsc = "";
         AV36TFCueCod_Sel = "";
         AV35TFCueCod = "";
         AV38TFCueDsc_Sel = "";
         AV37TFCueDsc = "";
         AV41TFConCajSts_Sels = new GxSimpleCollection<short>();
         AV39TFConCajSts_SelsJson = "";
         AV40TFConCajSts_SelDscs = "";
         AV44FilterTFConCajSts_SelValueDescription = "";
         AV69Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 = "";
         AV71Bancos_conceptoscajachicawwds_3_concajdsc1 = "";
         AV72Bancos_conceptoscajachicawwds_4_cuecod1 = "";
         AV74Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 = "";
         AV76Bancos_conceptoscajachicawwds_8_concajdsc2 = "";
         AV77Bancos_conceptoscajachicawwds_9_cuecod2 = "";
         AV79Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 = "";
         AV81Bancos_conceptoscajachicawwds_13_concajdsc3 = "";
         AV82Bancos_conceptoscajachicawwds_14_cuecod3 = "";
         AV85Bancos_conceptoscajachicawwds_17_tfconcajdsc = "";
         AV86Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel = "";
         AV87Bancos_conceptoscajachicawwds_19_tfcuecod = "";
         AV88Bancos_conceptoscajachicawwds_20_tfcuecod_sel = "";
         AV89Bancos_conceptoscajachicawwds_21_tfcuedsc = "";
         AV90Bancos_conceptoscajachicawwds_22_tfcuedsc_sel = "";
         AV91Bancos_conceptoscajachicawwds_23_tfconcajsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV71Bancos_conceptoscajachicawwds_3_concajdsc1 = "";
         lV72Bancos_conceptoscajachicawwds_4_cuecod1 = "";
         lV76Bancos_conceptoscajachicawwds_8_concajdsc2 = "";
         lV77Bancos_conceptoscajachicawwds_9_cuecod2 = "";
         lV81Bancos_conceptoscajachicawwds_13_concajdsc3 = "";
         lV82Bancos_conceptoscajachicawwds_14_cuecod3 = "";
         lV85Bancos_conceptoscajachicawwds_17_tfconcajdsc = "";
         lV87Bancos_conceptoscajachicawwds_19_tfcuecod = "";
         lV89Bancos_conceptoscajachicawwds_21_tfcuedsc = "";
         A747ConCajDsc = "";
         A91CueCod = "";
         A860CueDsc = "";
         P005Q2_A748ConCajSts = new short[1] ;
         P005Q2_A860CueDsc = new string[] {""} ;
         P005Q2_A375ConCajCod = new int[1] ;
         P005Q2_A91CueCod = new string[] {""} ;
         P005Q2_A747ConCajDsc = new string[] {""} ;
         AV12ConCajStsDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV54PageInfo = "";
         AV51DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV49AppName = "";
         AV55Phone = "";
         AV53Mail = "";
         AV57Website = "";
         AV46AddressLine1 = "";
         AV47AddressLine2 = "";
         AV48AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.conceptoscajachicawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P005Q2_A748ConCajSts, P005Q2_A860CueDsc, P005Q2_A375ConCajCod, P005Q2_A91CueCod, P005Q2_A747ConCajDsc
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
      private short AV42TFConCajSts_Sel ;
      private short AV70Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 ;
      private short AV75Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 ;
      private short AV80Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 ;
      private short A748ConCajSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV31TFConCajCod ;
      private int AV32TFConCajCod_To ;
      private int AV67GXV1 ;
      private int AV83Bancos_conceptoscajachicawwds_15_tfconcajcod ;
      private int AV84Bancos_conceptoscajachicawwds_16_tfconcajcod_to ;
      private int AV91Bancos_conceptoscajachicawwds_23_tfconcajsts_sels_Count ;
      private int A375ConCajCod ;
      private int AV92GXV2 ;
      private long AV45i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15ConCajDsc1 ;
      private string AV17ConCajDsc ;
      private string AV58CueCod1 ;
      private string AV60CueCod ;
      private string AV21ConCajDsc2 ;
      private string AV61CueCod2 ;
      private string AV25ConCajDsc3 ;
      private string AV62CueCod3 ;
      private string AV34TFConCajDsc_Sel ;
      private string AV33TFConCajDsc ;
      private string AV36TFCueCod_Sel ;
      private string AV35TFCueCod ;
      private string AV38TFCueDsc_Sel ;
      private string AV37TFCueDsc ;
      private string AV71Bancos_conceptoscajachicawwds_3_concajdsc1 ;
      private string AV72Bancos_conceptoscajachicawwds_4_cuecod1 ;
      private string AV76Bancos_conceptoscajachicawwds_8_concajdsc2 ;
      private string AV77Bancos_conceptoscajachicawwds_9_cuecod2 ;
      private string AV81Bancos_conceptoscajachicawwds_13_concajdsc3 ;
      private string AV82Bancos_conceptoscajachicawwds_14_cuecod3 ;
      private string AV85Bancos_conceptoscajachicawwds_17_tfconcajdsc ;
      private string AV86Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel ;
      private string AV87Bancos_conceptoscajachicawwds_19_tfcuecod ;
      private string AV88Bancos_conceptoscajachicawwds_20_tfcuecod_sel ;
      private string AV89Bancos_conceptoscajachicawwds_21_tfcuedsc ;
      private string AV90Bancos_conceptoscajachicawwds_22_tfcuedsc_sel ;
      private string scmdbuf ;
      private string lV71Bancos_conceptoscajachicawwds_3_concajdsc1 ;
      private string lV72Bancos_conceptoscajachicawwds_4_cuecod1 ;
      private string lV76Bancos_conceptoscajachicawwds_8_concajdsc2 ;
      private string lV77Bancos_conceptoscajachicawwds_9_cuecod2 ;
      private string lV81Bancos_conceptoscajachicawwds_13_concajdsc3 ;
      private string lV82Bancos_conceptoscajachicawwds_14_cuecod3 ;
      private string lV85Bancos_conceptoscajachicawwds_17_tfconcajdsc ;
      private string lV87Bancos_conceptoscajachicawwds_19_tfcuecod ;
      private string lV89Bancos_conceptoscajachicawwds_21_tfcuedsc ;
      private string A747ConCajDsc ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV73Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 ;
      private bool AV78Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV39TFConCajSts_SelsJson ;
      private string AV56Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterConCajDscDescription ;
      private string AV59FilterCueCodDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV43TFConCajCod_To_Description ;
      private string AV40TFConCajSts_SelDscs ;
      private string AV44FilterTFConCajSts_SelValueDescription ;
      private string AV69Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 ;
      private string AV74Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 ;
      private string AV79Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 ;
      private string AV12ConCajStsDescription ;
      private string AV54PageInfo ;
      private string AV51DateInfo ;
      private string AV49AppName ;
      private string AV55Phone ;
      private string AV53Mail ;
      private string AV57Website ;
      private string AV46AddressLine1 ;
      private string AV47AddressLine2 ;
      private string AV48AddressLine3 ;
      private GxSimpleCollection<short> AV41TFConCajSts_Sels ;
      private GxSimpleCollection<short> AV91Bancos_conceptoscajachicawwds_23_tfconcajsts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005Q2_A748ConCajSts ;
      private string[] P005Q2_A860CueDsc ;
      private int[] P005Q2_A375ConCajCod ;
      private string[] P005Q2_A91CueCod ;
      private string[] P005Q2_A747ConCajDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class conceptoscajachicawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005Q2( IGxContext context ,
                                             short A748ConCajSts ,
                                             GxSimpleCollection<short> AV91Bancos_conceptoscajachicawwds_23_tfconcajsts_sels ,
                                             string AV69Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 ,
                                             short AV70Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 ,
                                             string AV71Bancos_conceptoscajachicawwds_3_concajdsc1 ,
                                             string AV72Bancos_conceptoscajachicawwds_4_cuecod1 ,
                                             bool AV73Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 ,
                                             string AV74Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 ,
                                             short AV75Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 ,
                                             string AV76Bancos_conceptoscajachicawwds_8_concajdsc2 ,
                                             string AV77Bancos_conceptoscajachicawwds_9_cuecod2 ,
                                             bool AV78Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 ,
                                             string AV79Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 ,
                                             short AV80Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 ,
                                             string AV81Bancos_conceptoscajachicawwds_13_concajdsc3 ,
                                             string AV82Bancos_conceptoscajachicawwds_14_cuecod3 ,
                                             int AV83Bancos_conceptoscajachicawwds_15_tfconcajcod ,
                                             int AV84Bancos_conceptoscajachicawwds_16_tfconcajcod_to ,
                                             string AV86Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel ,
                                             string AV85Bancos_conceptoscajachicawwds_17_tfconcajdsc ,
                                             string AV88Bancos_conceptoscajachicawwds_20_tfcuecod_sel ,
                                             string AV87Bancos_conceptoscajachicawwds_19_tfcuecod ,
                                             string AV90Bancos_conceptoscajachicawwds_22_tfcuedsc_sel ,
                                             string AV89Bancos_conceptoscajachicawwds_21_tfcuedsc ,
                                             int AV91Bancos_conceptoscajachicawwds_23_tfconcajsts_sels_Count ,
                                             string A747ConCajDsc ,
                                             string A91CueCod ,
                                             int A375ConCajCod ,
                                             string A860CueDsc ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ConCajSts], T2.[CueDsc], T1.[ConCajCod], T1.[CueCod], T1.[ConCajDsc] FROM ([TSCONCEPTOCAJA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV69Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CONCAJDSC") == 0 ) && ( AV70Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_conceptoscajachicawwds_3_concajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV71Bancos_conceptoscajachicawwds_3_concajdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CONCAJDSC") == 0 ) && ( AV70Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_conceptoscajachicawwds_3_concajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV71Bancos_conceptoscajachicawwds_3_concajdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV70Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_conceptoscajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV72Bancos_conceptoscajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV70Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_conceptoscajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV72Bancos_conceptoscajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV73Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CONCAJDSC") == 0 ) && ( AV75Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoscajachicawwds_8_concajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV76Bancos_conceptoscajachicawwds_8_concajdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV73Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CONCAJDSC") == 0 ) && ( AV75Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoscajachicawwds_8_concajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV76Bancos_conceptoscajachicawwds_8_concajdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV73Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV75Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoscajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV77Bancos_conceptoscajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV73Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV75Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoscajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV77Bancos_conceptoscajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV78Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CONCAJDSC") == 0 ) && ( AV80Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_conceptoscajachicawwds_13_concajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV81Bancos_conceptoscajachicawwds_13_concajdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV78Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CONCAJDSC") == 0 ) && ( AV80Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_conceptoscajachicawwds_13_concajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV81Bancos_conceptoscajachicawwds_13_concajdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV78Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV80Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_conceptoscajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV82Bancos_conceptoscajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV78Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV80Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_conceptoscajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV82Bancos_conceptoscajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV83Bancos_conceptoscajachicawwds_15_tfconcajcod) )
         {
            AddWhere(sWhereString, "(T1.[ConCajCod] >= @AV83Bancos_conceptoscajachicawwds_15_tfconcajcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV84Bancos_conceptoscajachicawwds_16_tfconcajcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConCajCod] <= @AV84Bancos_conceptoscajachicawwds_16_tfconcajcod_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Bancos_conceptoscajachicawwds_17_tfconcajdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV85Bancos_conceptoscajachicawwds_17_tfconcajdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] = @AV86Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Bancos_conceptoscajachicawwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Bancos_conceptoscajachicawwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV87Bancos_conceptoscajachicawwds_19_tfcuecod)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Bancos_conceptoscajachicawwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV88Bancos_conceptoscajachicawwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Bancos_conceptoscajachicawwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV89Bancos_conceptoscajachicawwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV90Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV91Bancos_conceptoscajachicawwds_23_tfconcajsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV91Bancos_conceptoscajachicawwds_23_tfconcajsts_sels, "T1.[ConCajSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConCajCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConCajCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConCajDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConCajDsc] DESC";
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
            scmdbuf += " ORDER BY T1.[ConCajSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConCajSts] DESC";
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
                     return conditional_P005Q2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP005Q2;
          prmP005Q2 = new Object[] {
          new ParDef("@lV71Bancos_conceptoscajachicawwds_3_concajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV71Bancos_conceptoscajachicawwds_3_concajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV72Bancos_conceptoscajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV72Bancos_conceptoscajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV76Bancos_conceptoscajachicawwds_8_concajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV76Bancos_conceptoscajachicawwds_8_concajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV77Bancos_conceptoscajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV77Bancos_conceptoscajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV81Bancos_conceptoscajachicawwds_13_concajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV81Bancos_conceptoscajachicawwds_13_concajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV82Bancos_conceptoscajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV82Bancos_conceptoscajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV83Bancos_conceptoscajachicawwds_15_tfconcajcod",GXType.Int32,6,0) ,
          new ParDef("@AV84Bancos_conceptoscajachicawwds_16_tfconcajcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV85Bancos_conceptoscajachicawwds_17_tfconcajdsc",GXType.NChar,100,0) ,
          new ParDef("@AV86Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV87Bancos_conceptoscajachicawwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV88Bancos_conceptoscajachicawwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV89Bancos_conceptoscajachicawwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV90Bancos_conceptoscajachicawwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q2,100, GxCacheFrequency.OFF ,true,false )
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
