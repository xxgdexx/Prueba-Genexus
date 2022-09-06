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
   public class conceptoentregarendirwwexportreport : GXWebProcedure
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

      public conceptoentregarendirwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptoentregarendirwwexportreport( IGxContext context )
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
         conceptoentregarendirwwexportreport objconceptoentregarendirwwexportreport;
         objconceptoentregarendirwwexportreport = new conceptoentregarendirwwexportreport();
         objconceptoentregarendirwwexportreport.context.SetSubmitInitialConfig(context);
         objconceptoentregarendirwwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptoentregarendirwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptoentregarendirwwexportreport)stateInfo).executePrivate();
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
            AV52Title = "Lista de Conceptos Entrega Rendir Cuenta";
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
            H5Y0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CONENTDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14ConEntDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14ConEntDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterConEntDscDescription = StringUtil.Format( "%1 (%2)", "Concepto de Entrega", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterConEntDscDescription = StringUtil.Format( "%1 (%2)", "Concepto de Entrega", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16ConEntDsc = AV14ConEntDsc1;
                  H5Y0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterConEntDscDescription, "")), 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ConEntDsc, "")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CUECOD") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV54CueCod1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54CueCod1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV55FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV55FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV56CueCod = AV54CueCod1;
                  H5Y0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55FilterCueCodDescription, "")), 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56CueCod, "")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "CONENTDSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV20ConEntDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ConEntDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterConEntDscDescription = StringUtil.Format( "%1 (%2)", "Concepto de Entrega", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterConEntDscDescription = StringUtil.Format( "%1 (%2)", "Concepto de Entrega", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16ConEntDsc = AV20ConEntDsc2;
                     H5Y0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterConEntDscDescription, "")), 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ConEntDsc, "")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "CUECOD") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV57CueCod2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57CueCod2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV55FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV55FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV56CueCod = AV57CueCod2;
                     H5Y0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55FilterCueCodDescription, "")), 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56CueCod, "")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "CONENTDSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV24ConEntDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ConEntDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterConEntDscDescription = StringUtil.Format( "%1 (%2)", "Concepto de Entrega", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterConEntDscDescription = StringUtil.Format( "%1 (%2)", "Concepto de Entrega", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16ConEntDsc = AV24ConEntDsc3;
                        H5Y0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterConEntDscDescription, "")), 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ConEntDsc, "")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "CUECOD") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV58CueCod3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58CueCod3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV55FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV55FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV56CueCod = AV58CueCod3;
                        H5Y0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55FilterCueCodDescription, "")), 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56CueCod, "")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV30TFConEntCod) && (0==AV31TFConEntCod_To) ) )
         {
            H5Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30TFConEntCod), "ZZZZZ9")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFConEntCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H5Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFConEntCod_To_Description, "")), 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFConEntCod_To), "ZZZZZ9")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFConEntDsc_Sel)) )
         {
            H5Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Concepto Entrega Rendir", 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFConEntDsc_Sel, "")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFConEntDsc)) )
            {
               H5Y0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Concepto Entrega Rendir", 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFConEntDsc, "")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCueCod_Sel)) )
         {
            H5Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFCueCod_Sel, "")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCueCod)) )
            {
               H5Y0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFCueCod, "")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCueDsc_Sel)) )
         {
            H5Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descripción de Cuenta", 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFCueDsc_Sel, "")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCueDsc)) )
            {
               H5Y0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción de Cuenta", 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFCueDsc, "")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV62TFConEntSts_Sels.FromJSonString(AV60TFConEntSts_SelsJson, null);
         if ( ! ( AV62TFConEntSts_Sels.Count == 0 ) )
         {
            AV65i = 1;
            AV70GXV1 = 1;
            while ( AV70GXV1 <= AV62TFConEntSts_Sels.Count )
            {
               AV63TFConEntSts_Sel = (short)(AV62TFConEntSts_Sels.GetNumeric(AV70GXV1));
               if ( AV65i == 1 )
               {
                  AV61TFConEntSts_SelDscs = "";
               }
               else
               {
                  AV61TFConEntSts_SelDscs += ", ";
               }
               if ( AV63TFConEntSts_Sel == 1 )
               {
                  AV64FilterTFConEntSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV63TFConEntSts_Sel == 0 )
               {
                  AV64FilterTFConEntSts_SelValueDescription = "INACTIVO";
               }
               AV61TFConEntSts_SelDscs += AV64FilterTFConEntSts_SelValueDescription;
               AV65i = (long)(AV65i+1);
               AV70GXV1 = (int)(AV70GXV1+1);
            }
            H5Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 249, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61TFConEntSts_SelDscs, "")), 249, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H5Y0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H5Y0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 122, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Concepto Entrega Rendir", 126, Gx_line+10, 310, Gx_line+27, 0, 0, 0, 0) ;
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
         AV72Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV73Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV74Bancos_conceptoentregarendirwwds_3_conentdsc1 = AV14ConEntDsc1;
         AV75Bancos_conceptoentregarendirwwds_4_cuecod1 = AV54CueCod1;
         AV76Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV77Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV78Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV79Bancos_conceptoentregarendirwwds_8_conentdsc2 = AV20ConEntDsc2;
         AV80Bancos_conceptoentregarendirwwds_9_cuecod2 = AV57CueCod2;
         AV81Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV82Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV83Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV84Bancos_conceptoentregarendirwwds_13_conentdsc3 = AV24ConEntDsc3;
         AV85Bancos_conceptoentregarendirwwds_14_cuecod3 = AV58CueCod3;
         AV86Bancos_conceptoentregarendirwwds_15_tfconentcod = AV30TFConEntCod;
         AV87Bancos_conceptoentregarendirwwds_16_tfconentcod_to = AV31TFConEntCod_To;
         AV88Bancos_conceptoentregarendirwwds_17_tfconentdsc = AV32TFConEntDsc;
         AV89Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = AV33TFConEntDsc_Sel;
         AV90Bancos_conceptoentregarendirwwds_19_tfcuecod = AV34TFCueCod;
         AV91Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = AV35TFCueCod_Sel;
         AV92Bancos_conceptoentregarendirwwds_21_tfcuedsc = AV36TFCueDsc;
         AV93Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = AV37TFCueDsc_Sel;
         AV94Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = AV62TFConEntSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A750ConEntSts ,
                                              AV94Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                              AV72Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                              AV73Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                              AV74Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                              AV75Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                              AV76Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                              AV77Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                              AV78Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                              AV79Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                              AV80Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                              AV81Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                              AV82Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                              AV83Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                              AV84Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                              AV85Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                              AV86Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                              AV87Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                              AV89Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                              AV88Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                              AV91Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                              AV90Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                              AV93Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                              AV92Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                              AV94Bancos_conceptoentregarendirwwds_23_tfconentsts_sels.Count ,
                                              A749ConEntDsc ,
                                              A91CueCod ,
                                              A376ConEntCod ,
                                              A860CueDsc ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
         lV74Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
         lV75Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
         lV75Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
         lV79Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV79Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
         lV79Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV79Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
         lV80Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV80Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
         lV80Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV80Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
         lV84Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV84Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
         lV84Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV84Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
         lV85Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV85Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
         lV85Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV85Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
         lV88Bancos_conceptoentregarendirwwds_17_tfconentdsc = StringUtil.PadR( StringUtil.RTrim( AV88Bancos_conceptoentregarendirwwds_17_tfconentdsc), 100, "%");
         lV90Bancos_conceptoentregarendirwwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV90Bancos_conceptoentregarendirwwds_19_tfcuecod), 15, "%");
         lV92Bancos_conceptoentregarendirwwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV92Bancos_conceptoentregarendirwwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005Y2 */
         pr_default.execute(0, new Object[] {lV74Bancos_conceptoentregarendirwwds_3_conentdsc1, lV74Bancos_conceptoentregarendirwwds_3_conentdsc1, lV75Bancos_conceptoentregarendirwwds_4_cuecod1, lV75Bancos_conceptoentregarendirwwds_4_cuecod1, lV79Bancos_conceptoentregarendirwwds_8_conentdsc2, lV79Bancos_conceptoentregarendirwwds_8_conentdsc2, lV80Bancos_conceptoentregarendirwwds_9_cuecod2, lV80Bancos_conceptoentregarendirwwds_9_cuecod2, lV84Bancos_conceptoentregarendirwwds_13_conentdsc3, lV84Bancos_conceptoentregarendirwwds_13_conentdsc3, lV85Bancos_conceptoentregarendirwwds_14_cuecod3, lV85Bancos_conceptoentregarendirwwds_14_cuecod3, AV86Bancos_conceptoentregarendirwwds_15_tfconentcod, AV87Bancos_conceptoentregarendirwwds_16_tfconentcod_to, lV88Bancos_conceptoentregarendirwwds_17_tfconentdsc, AV89Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel, lV90Bancos_conceptoentregarendirwwds_19_tfcuecod, AV91Bancos_conceptoentregarendirwwds_20_tfcuecod_sel, lV92Bancos_conceptoentregarendirwwds_21_tfcuedsc, AV93Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A750ConEntSts = P005Y2_A750ConEntSts[0];
            A860CueDsc = P005Y2_A860CueDsc[0];
            A376ConEntCod = P005Y2_A376ConEntCod[0];
            A91CueCod = P005Y2_A91CueCod[0];
            A749ConEntDsc = P005Y2_A749ConEntDsc[0];
            A860CueDsc = P005Y2_A860CueDsc[0];
            if ( A750ConEntSts == 1 )
            {
               AV59ConEntStsDescription = "ACTIVO";
            }
            else if ( A750ConEntSts == 0 )
            {
               AV59ConEntStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H5Y0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A376ConEntCod), "ZZZZZ9")), 30, Gx_line+10, 122, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A749ConEntDsc, "")), 126, Gx_line+10, 310, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), 314, Gx_line+10, 407, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A860CueDsc, "")), 411, Gx_line+10, 597, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59ConEntStsDescription, "")), 601, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Bancos.ConceptoEntregaRendirWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.ConceptoEntregaRendirWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Bancos.ConceptoEntregaRendirWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV95GXV2 = 1;
         while ( AV95GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV95GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONENTCOD") == 0 )
            {
               AV30TFConEntCod = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV31TFConEntCod_To = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONENTDSC") == 0 )
            {
               AV32TFConEntDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONENTDSC_SEL") == 0 )
            {
               AV33TFConEntDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV34TFCueCod = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV35TFCueCod_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV36TFCueDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV37TFCueDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONENTSTS_SEL") == 0 )
            {
               AV60TFConEntSts_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV62TFConEntSts_Sels.FromJSonString(AV60TFConEntSts_SelsJson, null);
            }
            AV95GXV2 = (int)(AV95GXV2+1);
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

      protected void H5Y0( bool bFoot ,
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
                  AV50PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV47DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV45AppName = "DVelop Software Solutions";
               AV51Phone = "+1 550 8923";
               AV49Mail = "info@mail.com";
               AV53Website = "http://www.web.com";
               AV42AddressLine1 = "French Boulevard 2859";
               AV43AddressLine2 = "Downtown";
               AV44AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV52Title = "";
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14ConEntDsc1 = "";
         AV15FilterConEntDscDescription = "";
         AV16ConEntDsc = "";
         AV54CueCod1 = "";
         AV55FilterCueCodDescription = "";
         AV56CueCod = "";
         AV18DynamicFiltersSelector2 = "";
         AV20ConEntDsc2 = "";
         AV57CueCod2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV24ConEntDsc3 = "";
         AV58CueCod3 = "";
         AV40TFConEntCod_To_Description = "";
         AV33TFConEntDsc_Sel = "";
         AV32TFConEntDsc = "";
         AV35TFCueCod_Sel = "";
         AV34TFCueCod = "";
         AV37TFCueDsc_Sel = "";
         AV36TFCueDsc = "";
         AV62TFConEntSts_Sels = new GxSimpleCollection<short>();
         AV60TFConEntSts_SelsJson = "";
         AV61TFConEntSts_SelDscs = "";
         AV64FilterTFConEntSts_SelValueDescription = "";
         AV72Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = "";
         AV74Bancos_conceptoentregarendirwwds_3_conentdsc1 = "";
         AV75Bancos_conceptoentregarendirwwds_4_cuecod1 = "";
         AV77Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = "";
         AV79Bancos_conceptoentregarendirwwds_8_conentdsc2 = "";
         AV80Bancos_conceptoentregarendirwwds_9_cuecod2 = "";
         AV82Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = "";
         AV84Bancos_conceptoentregarendirwwds_13_conentdsc3 = "";
         AV85Bancos_conceptoentregarendirwwds_14_cuecod3 = "";
         AV88Bancos_conceptoentregarendirwwds_17_tfconentdsc = "";
         AV89Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = "";
         AV90Bancos_conceptoentregarendirwwds_19_tfcuecod = "";
         AV91Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = "";
         AV92Bancos_conceptoentregarendirwwds_21_tfcuedsc = "";
         AV93Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = "";
         AV94Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV74Bancos_conceptoentregarendirwwds_3_conentdsc1 = "";
         lV75Bancos_conceptoentregarendirwwds_4_cuecod1 = "";
         lV79Bancos_conceptoentregarendirwwds_8_conentdsc2 = "";
         lV80Bancos_conceptoentregarendirwwds_9_cuecod2 = "";
         lV84Bancos_conceptoentregarendirwwds_13_conentdsc3 = "";
         lV85Bancos_conceptoentregarendirwwds_14_cuecod3 = "";
         lV88Bancos_conceptoentregarendirwwds_17_tfconentdsc = "";
         lV90Bancos_conceptoentregarendirwwds_19_tfcuecod = "";
         lV92Bancos_conceptoentregarendirwwds_21_tfcuedsc = "";
         A749ConEntDsc = "";
         A91CueCod = "";
         A860CueDsc = "";
         P005Y2_A750ConEntSts = new short[1] ;
         P005Y2_A860CueDsc = new string[] {""} ;
         P005Y2_A376ConEntCod = new int[1] ;
         P005Y2_A91CueCod = new string[] {""} ;
         P005Y2_A749ConEntDsc = new string[] {""} ;
         AV59ConEntStsDescription = "";
         AV26Session = context.GetSession();
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV50PageInfo = "";
         AV47DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV45AppName = "";
         AV51Phone = "";
         AV49Mail = "";
         AV53Website = "";
         AV42AddressLine1 = "";
         AV43AddressLine2 = "";
         AV44AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.conceptoentregarendirwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P005Y2_A750ConEntSts, P005Y2_A860CueDsc, P005Y2_A376ConEntCod, P005Y2_A91CueCod, P005Y2_A749ConEntDsc
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
      private short AV63TFConEntSts_Sel ;
      private short AV73Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ;
      private short AV78Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ;
      private short AV83Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ;
      private short A750ConEntSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV30TFConEntCod ;
      private int AV31TFConEntCod_To ;
      private int AV70GXV1 ;
      private int AV86Bancos_conceptoentregarendirwwds_15_tfconentcod ;
      private int AV87Bancos_conceptoentregarendirwwds_16_tfconentcod_to ;
      private int AV94Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count ;
      private int A376ConEntCod ;
      private int AV95GXV2 ;
      private long AV65i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14ConEntDsc1 ;
      private string AV16ConEntDsc ;
      private string AV54CueCod1 ;
      private string AV56CueCod ;
      private string AV20ConEntDsc2 ;
      private string AV57CueCod2 ;
      private string AV24ConEntDsc3 ;
      private string AV58CueCod3 ;
      private string AV33TFConEntDsc_Sel ;
      private string AV32TFConEntDsc ;
      private string AV35TFCueCod_Sel ;
      private string AV34TFCueCod ;
      private string AV37TFCueDsc_Sel ;
      private string AV36TFCueDsc ;
      private string AV74Bancos_conceptoentregarendirwwds_3_conentdsc1 ;
      private string AV75Bancos_conceptoentregarendirwwds_4_cuecod1 ;
      private string AV79Bancos_conceptoentregarendirwwds_8_conentdsc2 ;
      private string AV80Bancos_conceptoentregarendirwwds_9_cuecod2 ;
      private string AV84Bancos_conceptoentregarendirwwds_13_conentdsc3 ;
      private string AV85Bancos_conceptoentregarendirwwds_14_cuecod3 ;
      private string AV88Bancos_conceptoentregarendirwwds_17_tfconentdsc ;
      private string AV89Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ;
      private string AV90Bancos_conceptoentregarendirwwds_19_tfcuecod ;
      private string AV91Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ;
      private string AV92Bancos_conceptoentregarendirwwds_21_tfcuedsc ;
      private string AV93Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ;
      private string scmdbuf ;
      private string lV74Bancos_conceptoentregarendirwwds_3_conentdsc1 ;
      private string lV75Bancos_conceptoentregarendirwwds_4_cuecod1 ;
      private string lV79Bancos_conceptoentregarendirwwds_8_conentdsc2 ;
      private string lV80Bancos_conceptoentregarendirwwds_9_cuecod2 ;
      private string lV84Bancos_conceptoentregarendirwwds_13_conentdsc3 ;
      private string lV85Bancos_conceptoentregarendirwwds_14_cuecod3 ;
      private string lV88Bancos_conceptoentregarendirwwds_17_tfconentdsc ;
      private string lV90Bancos_conceptoentregarendirwwds_19_tfcuecod ;
      private string lV92Bancos_conceptoentregarendirwwds_21_tfcuedsc ;
      private string A749ConEntDsc ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV76Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ;
      private bool AV81Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV60TFConEntSts_SelsJson ;
      private string AV52Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterConEntDscDescription ;
      private string AV55FilterCueCodDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV40TFConEntCod_To_Description ;
      private string AV61TFConEntSts_SelDscs ;
      private string AV64FilterTFConEntSts_SelValueDescription ;
      private string AV72Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ;
      private string AV77Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ;
      private string AV82Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ;
      private string AV59ConEntStsDescription ;
      private string AV50PageInfo ;
      private string AV47DateInfo ;
      private string AV45AppName ;
      private string AV51Phone ;
      private string AV49Mail ;
      private string AV53Website ;
      private string AV42AddressLine1 ;
      private string AV43AddressLine2 ;
      private string AV44AddressLine3 ;
      private GxSimpleCollection<short> AV62TFConEntSts_Sels ;
      private GxSimpleCollection<short> AV94Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005Y2_A750ConEntSts ;
      private string[] P005Y2_A860CueDsc ;
      private int[] P005Y2_A376ConEntCod ;
      private string[] P005Y2_A91CueCod ;
      private string[] P005Y2_A749ConEntDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class conceptoentregarendirwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005Y2( IGxContext context ,
                                             short A750ConEntSts ,
                                             GxSimpleCollection<short> AV94Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                             string AV72Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                             short AV73Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                             string AV74Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                             string AV75Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                             bool AV76Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                             string AV77Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                             short AV78Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                             string AV79Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                             string AV80Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                             bool AV81Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                             string AV82Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                             short AV83Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                             string AV84Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                             string AV85Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                             int AV86Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                             int AV87Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                             string AV89Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                             string AV88Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                             string AV91Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                             string AV90Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                             string AV93Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                             string AV92Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                             int AV94Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count ,
                                             string A749ConEntDsc ,
                                             string A91CueCod ,
                                             int A376ConEntCod ,
                                             string A860CueDsc ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ConEntSts], T2.[CueDsc], T1.[ConEntCod], T1.[CueCod], T1.[ConEntDsc] FROM ([TSCONCEPTOENTREGA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV72Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV73Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV74Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV73Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV74Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV73Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV75Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV73Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV75Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV76Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV78Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV79Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV76Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV78Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV79Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV76Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV78Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV80Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV76Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV78Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV80Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV81Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV83Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV84Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV81Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV83Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV84Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV81Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV83Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV85Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV81Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV83Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV85Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV86Bancos_conceptoentregarendirwwds_15_tfconentcod) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] >= @AV86Bancos_conceptoentregarendirwwds_15_tfconentcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV87Bancos_conceptoentregarendirwwds_16_tfconentcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] <= @AV87Bancos_conceptoentregarendirwwds_16_tfconentcod_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Bancos_conceptoentregarendirwwds_17_tfconentdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV88Bancos_conceptoentregarendirwwds_17_tfconentdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] = @AV89Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_conceptoentregarendirwwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV90Bancos_conceptoentregarendirwwds_19_tfcuecod)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV91Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Bancos_conceptoentregarendirwwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV92Bancos_conceptoentregarendirwwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV93Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV94Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV94Bancos_conceptoentregarendirwwds_23_tfconentsts_sels, "T1.[ConEntSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConEntCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConEntCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConEntDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConEntDsc] DESC";
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
            scmdbuf += " ORDER BY T1.[ConEntSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConEntSts] DESC";
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
                     return conditional_P005Y2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP005Y2;
          prmP005Y2 = new Object[] {
          new ParDef("@lV74Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV74Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV75Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV75Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV79Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV79Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV80Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV80Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV84Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV84Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV85Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV85Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV86Bancos_conceptoentregarendirwwds_15_tfconentcod",GXType.Int32,6,0) ,
          new ParDef("@AV87Bancos_conceptoentregarendirwwds_16_tfconentcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV88Bancos_conceptoentregarendirwwds_17_tfconentdsc",GXType.NChar,100,0) ,
          new ParDef("@AV89Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV90Bancos_conceptoentregarendirwwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV91Bancos_conceptoentregarendirwwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV92Bancos_conceptoentregarendirwwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV93Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y2,100, GxCacheFrequency.OFF ,true,false )
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
