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
   public class cajachicawwexportreport : GXWebProcedure
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

      public cajachicawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cajachicawwexportreport( IGxContext context )
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
         cajachicawwexportreport objcajachicawwexportreport;
         objcajachicawwexportreport = new cajachicawwexportreport();
         objcajachicawwexportreport.context.SetSubmitInitialConfig(context);
         objcajachicawwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcajachicawwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cajachicawwexportreport)stateInfo).executePrivate();
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
            AV52Title = "Lista de Caja Chica";
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
            H5M0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CAJDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14CajDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14CajDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterCajDscDescription = StringUtil.Format( "%1 (%2)", "Caja Chica", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterCajDscDescription = StringUtil.Format( "%1 (%2)", "Caja Chica", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16CajDsc = AV14CajDsc1;
                  H5M0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCajDscDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CajDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CUECOD") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV61CueCod1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61CueCod1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV62FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV62FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV63CueCod = AV61CueCod1;
                  H5M0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62FilterCueCodDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63CueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "CAJDSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV20CajDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20CajDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterCajDscDescription = StringUtil.Format( "%1 (%2)", "Caja Chica", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterCajDscDescription = StringUtil.Format( "%1 (%2)", "Caja Chica", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16CajDsc = AV20CajDsc2;
                     H5M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCajDscDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CajDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "CUECOD") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV64CueCod2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64CueCod2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV62FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV62FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV63CueCod = AV64CueCod2;
                     H5M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62FilterCueCodDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63CueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "CAJDSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV24CajDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24CajDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterCajDscDescription = StringUtil.Format( "%1 (%2)", "Caja Chica", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterCajDscDescription = StringUtil.Format( "%1 (%2)", "Caja Chica", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16CajDsc = AV24CajDsc3;
                        H5M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCajDscDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CajDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "CUECOD") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV65CueCod3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65CueCod3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV62FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV62FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV63CueCod = AV65CueCod3;
                        H5M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62FilterCueCodDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63CueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV30TFCajCod) && (0==AV31TFCajCod_To) ) )
         {
            H5M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30TFCajCod), "ZZZZZ9")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFCajCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H5M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFCajCod_To_Description, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFCajCod_To), "ZZZZZ9")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFCajDsc_Sel)) )
         {
            H5M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Caja Chica", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFCajDsc_Sel, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFCajDsc)) )
            {
               H5M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Caja Chica", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFCajDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCueCod_Sel)) )
         {
            H5M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFCueCod_Sel, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCueCod)) )
            {
               H5M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFCueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFCueDsc_Sel)) )
         {
            H5M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descripción de Cuenta", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TFCueDsc_Sel, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TFCueDsc)) )
            {
               H5M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción de Cuenta", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66TFCueDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV57TFCajSts_Sels.FromJSonString(AV55TFCajSts_SelsJson, null);
         if ( ! ( AV57TFCajSts_Sels.Count == 0 ) )
         {
            AV60i = 1;
            AV72GXV1 = 1;
            while ( AV72GXV1 <= AV57TFCajSts_Sels.Count )
            {
               AV58TFCajSts_Sel = (short)(AV57TFCajSts_Sels.GetNumeric(AV72GXV1));
               if ( AV60i == 1 )
               {
                  AV56TFCajSts_SelDscs = "";
               }
               else
               {
                  AV56TFCajSts_SelDscs += ", ";
               }
               if ( AV58TFCajSts_Sel == 1 )
               {
                  AV59FilterTFCajSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV58TFCajSts_Sel == 0 )
               {
                  AV59FilterTFCajSts_SelValueDescription = "INACTIVO";
               }
               AV56TFCajSts_SelDscs += AV59FilterTFCajSts_SelValueDescription;
               AV60i = (long)(AV60i+1);
               AV72GXV1 = (int)(AV72GXV1+1);
            }
            H5M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFCajSts_SelDscs, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H5M0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H5M0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 122, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Caja Chica", 126, Gx_line+10, 310, Gx_line+27, 0, 0, 0, 0) ;
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
         AV74Bancos_cajachicawwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV75Bancos_cajachicawwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV76Bancos_cajachicawwds_3_cajdsc1 = AV14CajDsc1;
         AV77Bancos_cajachicawwds_4_cuecod1 = AV61CueCod1;
         AV78Bancos_cajachicawwds_5_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV79Bancos_cajachicawwds_6_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV80Bancos_cajachicawwds_7_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV81Bancos_cajachicawwds_8_cajdsc2 = AV20CajDsc2;
         AV82Bancos_cajachicawwds_9_cuecod2 = AV64CueCod2;
         AV83Bancos_cajachicawwds_10_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV84Bancos_cajachicawwds_11_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV85Bancos_cajachicawwds_12_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV86Bancos_cajachicawwds_13_cajdsc3 = AV24CajDsc3;
         AV87Bancos_cajachicawwds_14_cuecod3 = AV65CueCod3;
         AV88Bancos_cajachicawwds_15_tfcajcod = AV30TFCajCod;
         AV89Bancos_cajachicawwds_16_tfcajcod_to = AV31TFCajCod_To;
         AV90Bancos_cajachicawwds_17_tfcajdsc = AV32TFCajDsc;
         AV91Bancos_cajachicawwds_18_tfcajdsc_sel = AV33TFCajDsc_Sel;
         AV92Bancos_cajachicawwds_19_tfcuecod = AV36TFCueCod;
         AV93Bancos_cajachicawwds_20_tfcuecod_sel = AV37TFCueCod_Sel;
         AV94Bancos_cajachicawwds_21_tfcuedsc = AV66TFCueDsc;
         AV95Bancos_cajachicawwds_22_tfcuedsc_sel = AV67TFCueDsc_Sel;
         AV96Bancos_cajachicawwds_23_tfcajsts_sels = AV57TFCajSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A487CajSts ,
                                              AV96Bancos_cajachicawwds_23_tfcajsts_sels ,
                                              AV74Bancos_cajachicawwds_1_dynamicfiltersselector1 ,
                                              AV75Bancos_cajachicawwds_2_dynamicfiltersoperator1 ,
                                              AV76Bancos_cajachicawwds_3_cajdsc1 ,
                                              AV77Bancos_cajachicawwds_4_cuecod1 ,
                                              AV78Bancos_cajachicawwds_5_dynamicfiltersenabled2 ,
                                              AV79Bancos_cajachicawwds_6_dynamicfiltersselector2 ,
                                              AV80Bancos_cajachicawwds_7_dynamicfiltersoperator2 ,
                                              AV81Bancos_cajachicawwds_8_cajdsc2 ,
                                              AV82Bancos_cajachicawwds_9_cuecod2 ,
                                              AV83Bancos_cajachicawwds_10_dynamicfiltersenabled3 ,
                                              AV84Bancos_cajachicawwds_11_dynamicfiltersselector3 ,
                                              AV85Bancos_cajachicawwds_12_dynamicfiltersoperator3 ,
                                              AV86Bancos_cajachicawwds_13_cajdsc3 ,
                                              AV87Bancos_cajachicawwds_14_cuecod3 ,
                                              AV88Bancos_cajachicawwds_15_tfcajcod ,
                                              AV89Bancos_cajachicawwds_16_tfcajcod_to ,
                                              AV91Bancos_cajachicawwds_18_tfcajdsc_sel ,
                                              AV90Bancos_cajachicawwds_17_tfcajdsc ,
                                              AV93Bancos_cajachicawwds_20_tfcuecod_sel ,
                                              AV92Bancos_cajachicawwds_19_tfcuecod ,
                                              AV95Bancos_cajachicawwds_22_tfcuedsc_sel ,
                                              AV94Bancos_cajachicawwds_21_tfcuedsc ,
                                              AV96Bancos_cajachicawwds_23_tfcajsts_sels.Count ,
                                              A486CajDsc ,
                                              A91CueCod ,
                                              A358CajCod ,
                                              A860CueDsc ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV76Bancos_cajachicawwds_3_cajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_cajachicawwds_3_cajdsc1), 100, "%");
         lV76Bancos_cajachicawwds_3_cajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_cajachicawwds_3_cajdsc1), 100, "%");
         lV77Bancos_cajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_cajachicawwds_4_cuecod1), 15, "%");
         lV77Bancos_cajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_cajachicawwds_4_cuecod1), 15, "%");
         lV81Bancos_cajachicawwds_8_cajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Bancos_cajachicawwds_8_cajdsc2), 100, "%");
         lV81Bancos_cajachicawwds_8_cajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Bancos_cajachicawwds_8_cajdsc2), 100, "%");
         lV82Bancos_cajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV82Bancos_cajachicawwds_9_cuecod2), 15, "%");
         lV82Bancos_cajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV82Bancos_cajachicawwds_9_cuecod2), 15, "%");
         lV86Bancos_cajachicawwds_13_cajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV86Bancos_cajachicawwds_13_cajdsc3), 100, "%");
         lV86Bancos_cajachicawwds_13_cajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV86Bancos_cajachicawwds_13_cajdsc3), 100, "%");
         lV87Bancos_cajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV87Bancos_cajachicawwds_14_cuecod3), 15, "%");
         lV87Bancos_cajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV87Bancos_cajachicawwds_14_cuecod3), 15, "%");
         lV90Bancos_cajachicawwds_17_tfcajdsc = StringUtil.PadR( StringUtil.RTrim( AV90Bancos_cajachicawwds_17_tfcajdsc), 100, "%");
         lV92Bancos_cajachicawwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV92Bancos_cajachicawwds_19_tfcuecod), 15, "%");
         lV94Bancos_cajachicawwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV94Bancos_cajachicawwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005M2 */
         pr_default.execute(0, new Object[] {lV76Bancos_cajachicawwds_3_cajdsc1, lV76Bancos_cajachicawwds_3_cajdsc1, lV77Bancos_cajachicawwds_4_cuecod1, lV77Bancos_cajachicawwds_4_cuecod1, lV81Bancos_cajachicawwds_8_cajdsc2, lV81Bancos_cajachicawwds_8_cajdsc2, lV82Bancos_cajachicawwds_9_cuecod2, lV82Bancos_cajachicawwds_9_cuecod2, lV86Bancos_cajachicawwds_13_cajdsc3, lV86Bancos_cajachicawwds_13_cajdsc3, lV87Bancos_cajachicawwds_14_cuecod3, lV87Bancos_cajachicawwds_14_cuecod3, AV88Bancos_cajachicawwds_15_tfcajcod, AV89Bancos_cajachicawwds_16_tfcajcod_to, lV90Bancos_cajachicawwds_17_tfcajdsc, AV91Bancos_cajachicawwds_18_tfcajdsc_sel, lV92Bancos_cajachicawwds_19_tfcuecod, AV93Bancos_cajachicawwds_20_tfcuecod_sel, lV94Bancos_cajachicawwds_21_tfcuedsc, AV95Bancos_cajachicawwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A487CajSts = P005M2_A487CajSts[0];
            A860CueDsc = P005M2_A860CueDsc[0];
            A358CajCod = P005M2_A358CajCod[0];
            A91CueCod = P005M2_A91CueCod[0];
            A486CajDsc = P005M2_A486CajDsc[0];
            A860CueDsc = P005M2_A860CueDsc[0];
            if ( A487CajSts == 1 )
            {
               AV54CajStsDescription = "ACTIVO";
            }
            else if ( A487CajSts == 0 )
            {
               AV54CajStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H5M0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A358CajCod), "ZZZZZ9")), 30, Gx_line+10, 122, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A486CajDsc, "")), 126, Gx_line+10, 310, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), 314, Gx_line+10, 407, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A860CueDsc, "")), 411, Gx_line+10, 597, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54CajStsDescription, "")), 601, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Bancos.CajaChicaWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.CajaChicaWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Bancos.CajaChicaWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV97GXV2 = 1;
         while ( AV97GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV97GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCAJCOD") == 0 )
            {
               AV30TFCajCod = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV31TFCajCod_To = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCAJDSC") == 0 )
            {
               AV32TFCajDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCAJDSC_SEL") == 0 )
            {
               AV33TFCajDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV36TFCueCod = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV37TFCueCod_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV66TFCueDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV67TFCueDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCAJSTS_SEL") == 0 )
            {
               AV55TFCajSts_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV57TFCajSts_Sels.FromJSonString(AV55TFCajSts_SelsJson, null);
            }
            AV97GXV2 = (int)(AV97GXV2+1);
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

      protected void H5M0( bool bFoot ,
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
         AV14CajDsc1 = "";
         AV15FilterCajDscDescription = "";
         AV16CajDsc = "";
         AV61CueCod1 = "";
         AV62FilterCueCodDescription = "";
         AV63CueCod = "";
         AV18DynamicFiltersSelector2 = "";
         AV20CajDsc2 = "";
         AV64CueCod2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV24CajDsc3 = "";
         AV65CueCod3 = "";
         AV40TFCajCod_To_Description = "";
         AV33TFCajDsc_Sel = "";
         AV32TFCajDsc = "";
         AV37TFCueCod_Sel = "";
         AV36TFCueCod = "";
         AV67TFCueDsc_Sel = "";
         AV66TFCueDsc = "";
         AV57TFCajSts_Sels = new GxSimpleCollection<short>();
         AV55TFCajSts_SelsJson = "";
         AV56TFCajSts_SelDscs = "";
         AV59FilterTFCajSts_SelValueDescription = "";
         AV74Bancos_cajachicawwds_1_dynamicfiltersselector1 = "";
         AV76Bancos_cajachicawwds_3_cajdsc1 = "";
         AV77Bancos_cajachicawwds_4_cuecod1 = "";
         AV79Bancos_cajachicawwds_6_dynamicfiltersselector2 = "";
         AV81Bancos_cajachicawwds_8_cajdsc2 = "";
         AV82Bancos_cajachicawwds_9_cuecod2 = "";
         AV84Bancos_cajachicawwds_11_dynamicfiltersselector3 = "";
         AV86Bancos_cajachicawwds_13_cajdsc3 = "";
         AV87Bancos_cajachicawwds_14_cuecod3 = "";
         AV90Bancos_cajachicawwds_17_tfcajdsc = "";
         AV91Bancos_cajachicawwds_18_tfcajdsc_sel = "";
         AV92Bancos_cajachicawwds_19_tfcuecod = "";
         AV93Bancos_cajachicawwds_20_tfcuecod_sel = "";
         AV94Bancos_cajachicawwds_21_tfcuedsc = "";
         AV95Bancos_cajachicawwds_22_tfcuedsc_sel = "";
         AV96Bancos_cajachicawwds_23_tfcajsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV76Bancos_cajachicawwds_3_cajdsc1 = "";
         lV77Bancos_cajachicawwds_4_cuecod1 = "";
         lV81Bancos_cajachicawwds_8_cajdsc2 = "";
         lV82Bancos_cajachicawwds_9_cuecod2 = "";
         lV86Bancos_cajachicawwds_13_cajdsc3 = "";
         lV87Bancos_cajachicawwds_14_cuecod3 = "";
         lV90Bancos_cajachicawwds_17_tfcajdsc = "";
         lV92Bancos_cajachicawwds_19_tfcuecod = "";
         lV94Bancos_cajachicawwds_21_tfcuedsc = "";
         A486CajDsc = "";
         A91CueCod = "";
         A860CueDsc = "";
         P005M2_A487CajSts = new short[1] ;
         P005M2_A860CueDsc = new string[] {""} ;
         P005M2_A358CajCod = new int[1] ;
         P005M2_A91CueCod = new string[] {""} ;
         P005M2_A486CajDsc = new string[] {""} ;
         AV54CajStsDescription = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.cajachicawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P005M2_A487CajSts, P005M2_A860CueDsc, P005M2_A358CajCod, P005M2_A91CueCod, P005M2_A486CajDsc
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
      private short AV58TFCajSts_Sel ;
      private short AV75Bancos_cajachicawwds_2_dynamicfiltersoperator1 ;
      private short AV80Bancos_cajachicawwds_7_dynamicfiltersoperator2 ;
      private short AV85Bancos_cajachicawwds_12_dynamicfiltersoperator3 ;
      private short A487CajSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV30TFCajCod ;
      private int AV31TFCajCod_To ;
      private int AV72GXV1 ;
      private int AV88Bancos_cajachicawwds_15_tfcajcod ;
      private int AV89Bancos_cajachicawwds_16_tfcajcod_to ;
      private int AV96Bancos_cajachicawwds_23_tfcajsts_sels_Count ;
      private int A358CajCod ;
      private int AV97GXV2 ;
      private long AV60i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14CajDsc1 ;
      private string AV16CajDsc ;
      private string AV61CueCod1 ;
      private string AV63CueCod ;
      private string AV20CajDsc2 ;
      private string AV64CueCod2 ;
      private string AV24CajDsc3 ;
      private string AV65CueCod3 ;
      private string AV33TFCajDsc_Sel ;
      private string AV32TFCajDsc ;
      private string AV37TFCueCod_Sel ;
      private string AV36TFCueCod ;
      private string AV67TFCueDsc_Sel ;
      private string AV66TFCueDsc ;
      private string AV76Bancos_cajachicawwds_3_cajdsc1 ;
      private string AV77Bancos_cajachicawwds_4_cuecod1 ;
      private string AV81Bancos_cajachicawwds_8_cajdsc2 ;
      private string AV82Bancos_cajachicawwds_9_cuecod2 ;
      private string AV86Bancos_cajachicawwds_13_cajdsc3 ;
      private string AV87Bancos_cajachicawwds_14_cuecod3 ;
      private string AV90Bancos_cajachicawwds_17_tfcajdsc ;
      private string AV91Bancos_cajachicawwds_18_tfcajdsc_sel ;
      private string AV92Bancos_cajachicawwds_19_tfcuecod ;
      private string AV93Bancos_cajachicawwds_20_tfcuecod_sel ;
      private string AV94Bancos_cajachicawwds_21_tfcuedsc ;
      private string AV95Bancos_cajachicawwds_22_tfcuedsc_sel ;
      private string scmdbuf ;
      private string lV76Bancos_cajachicawwds_3_cajdsc1 ;
      private string lV77Bancos_cajachicawwds_4_cuecod1 ;
      private string lV81Bancos_cajachicawwds_8_cajdsc2 ;
      private string lV82Bancos_cajachicawwds_9_cuecod2 ;
      private string lV86Bancos_cajachicawwds_13_cajdsc3 ;
      private string lV87Bancos_cajachicawwds_14_cuecod3 ;
      private string lV90Bancos_cajachicawwds_17_tfcajdsc ;
      private string lV92Bancos_cajachicawwds_19_tfcuecod ;
      private string lV94Bancos_cajachicawwds_21_tfcuedsc ;
      private string A486CajDsc ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV78Bancos_cajachicawwds_5_dynamicfiltersenabled2 ;
      private bool AV83Bancos_cajachicawwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV55TFCajSts_SelsJson ;
      private string AV52Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterCajDscDescription ;
      private string AV62FilterCueCodDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV40TFCajCod_To_Description ;
      private string AV56TFCajSts_SelDscs ;
      private string AV59FilterTFCajSts_SelValueDescription ;
      private string AV74Bancos_cajachicawwds_1_dynamicfiltersselector1 ;
      private string AV79Bancos_cajachicawwds_6_dynamicfiltersselector2 ;
      private string AV84Bancos_cajachicawwds_11_dynamicfiltersselector3 ;
      private string AV54CajStsDescription ;
      private string AV50PageInfo ;
      private string AV47DateInfo ;
      private string AV45AppName ;
      private string AV51Phone ;
      private string AV49Mail ;
      private string AV53Website ;
      private string AV42AddressLine1 ;
      private string AV43AddressLine2 ;
      private string AV44AddressLine3 ;
      private GxSimpleCollection<short> AV57TFCajSts_Sels ;
      private GxSimpleCollection<short> AV96Bancos_cajachicawwds_23_tfcajsts_sels ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005M2_A487CajSts ;
      private string[] P005M2_A860CueDsc ;
      private int[] P005M2_A358CajCod ;
      private string[] P005M2_A91CueCod ;
      private string[] P005M2_A486CajDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class cajachicawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005M2( IGxContext context ,
                                             short A487CajSts ,
                                             GxSimpleCollection<short> AV96Bancos_cajachicawwds_23_tfcajsts_sels ,
                                             string AV74Bancos_cajachicawwds_1_dynamicfiltersselector1 ,
                                             short AV75Bancos_cajachicawwds_2_dynamicfiltersoperator1 ,
                                             string AV76Bancos_cajachicawwds_3_cajdsc1 ,
                                             string AV77Bancos_cajachicawwds_4_cuecod1 ,
                                             bool AV78Bancos_cajachicawwds_5_dynamicfiltersenabled2 ,
                                             string AV79Bancos_cajachicawwds_6_dynamicfiltersselector2 ,
                                             short AV80Bancos_cajachicawwds_7_dynamicfiltersoperator2 ,
                                             string AV81Bancos_cajachicawwds_8_cajdsc2 ,
                                             string AV82Bancos_cajachicawwds_9_cuecod2 ,
                                             bool AV83Bancos_cajachicawwds_10_dynamicfiltersenabled3 ,
                                             string AV84Bancos_cajachicawwds_11_dynamicfiltersselector3 ,
                                             short AV85Bancos_cajachicawwds_12_dynamicfiltersoperator3 ,
                                             string AV86Bancos_cajachicawwds_13_cajdsc3 ,
                                             string AV87Bancos_cajachicawwds_14_cuecod3 ,
                                             int AV88Bancos_cajachicawwds_15_tfcajcod ,
                                             int AV89Bancos_cajachicawwds_16_tfcajcod_to ,
                                             string AV91Bancos_cajachicawwds_18_tfcajdsc_sel ,
                                             string AV90Bancos_cajachicawwds_17_tfcajdsc ,
                                             string AV93Bancos_cajachicawwds_20_tfcuecod_sel ,
                                             string AV92Bancos_cajachicawwds_19_tfcuecod ,
                                             string AV95Bancos_cajachicawwds_22_tfcuedsc_sel ,
                                             string AV94Bancos_cajachicawwds_21_tfcuedsc ,
                                             int AV96Bancos_cajachicawwds_23_tfcajsts_sels_Count ,
                                             string A486CajDsc ,
                                             string A91CueCod ,
                                             int A358CajCod ,
                                             string A860CueDsc ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CajSts], T2.[CueDsc], T1.[CajCod], T1.[CueCod], T1.[CajDsc] FROM ([TSCAJACHICA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV74Bancos_cajachicawwds_1_dynamicfiltersselector1, "CAJDSC") == 0 ) && ( AV75Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_cajachicawwds_3_cajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV76Bancos_cajachicawwds_3_cajdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Bancos_cajachicawwds_1_dynamicfiltersselector1, "CAJDSC") == 0 ) && ( AV75Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_cajachicawwds_3_cajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV76Bancos_cajachicawwds_3_cajdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Bancos_cajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV75Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_cajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV77Bancos_cajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Bancos_cajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV75Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_cajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV77Bancos_cajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV78Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Bancos_cajachicawwds_6_dynamicfiltersselector2, "CAJDSC") == 0 ) && ( AV80Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_cajachicawwds_8_cajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV81Bancos_cajachicawwds_8_cajdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV78Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Bancos_cajachicawwds_6_dynamicfiltersselector2, "CAJDSC") == 0 ) && ( AV80Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_cajachicawwds_8_cajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV81Bancos_cajachicawwds_8_cajdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV78Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Bancos_cajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV80Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_cajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV82Bancos_cajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV78Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Bancos_cajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV80Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_cajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV82Bancos_cajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV83Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Bancos_cajachicawwds_11_dynamicfiltersselector3, "CAJDSC") == 0 ) && ( AV85Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Bancos_cajachicawwds_13_cajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV86Bancos_cajachicawwds_13_cajdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV83Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Bancos_cajachicawwds_11_dynamicfiltersselector3, "CAJDSC") == 0 ) && ( AV85Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Bancos_cajachicawwds_13_cajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV86Bancos_cajachicawwds_13_cajdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV83Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Bancos_cajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV85Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Bancos_cajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV87Bancos_cajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV83Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Bancos_cajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV85Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Bancos_cajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV87Bancos_cajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV88Bancos_cajachicawwds_15_tfcajcod) )
         {
            AddWhere(sWhereString, "(T1.[CajCod] >= @AV88Bancos_cajachicawwds_15_tfcajcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV89Bancos_cajachicawwds_16_tfcajcod_to) )
         {
            AddWhere(sWhereString, "(T1.[CajCod] <= @AV89Bancos_cajachicawwds_16_tfcajcod_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_cajachicawwds_18_tfcajdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_cajachicawwds_17_tfcajdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV90Bancos_cajachicawwds_17_tfcajdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_cajachicawwds_18_tfcajdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] = @AV91Bancos_cajachicawwds_18_tfcajdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Bancos_cajachicawwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Bancos_cajachicawwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV92Bancos_cajachicawwds_19_tfcuecod)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Bancos_cajachicawwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV93Bancos_cajachicawwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Bancos_cajachicawwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Bancos_cajachicawwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV94Bancos_cajachicawwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Bancos_cajachicawwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV95Bancos_cajachicawwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV96Bancos_cajachicawwds_23_tfcajsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV96Bancos_cajachicawwds_23_tfcajsts_sels, "T1.[CajSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CajCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CajCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CajDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CajDsc] DESC";
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
            scmdbuf += " ORDER BY T1.[CajSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CajSts] DESC";
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
                     return conditional_P005M2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP005M2;
          prmP005M2 = new Object[] {
          new ParDef("@lV76Bancos_cajachicawwds_3_cajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV76Bancos_cajachicawwds_3_cajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV77Bancos_cajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV77Bancos_cajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV81Bancos_cajachicawwds_8_cajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV81Bancos_cajachicawwds_8_cajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV82Bancos_cajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV82Bancos_cajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV86Bancos_cajachicawwds_13_cajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV86Bancos_cajachicawwds_13_cajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV87Bancos_cajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV87Bancos_cajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV88Bancos_cajachicawwds_15_tfcajcod",GXType.Int32,6,0) ,
          new ParDef("@AV89Bancos_cajachicawwds_16_tfcajcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV90Bancos_cajachicawwds_17_tfcajdsc",GXType.NChar,100,0) ,
          new ParDef("@AV91Bancos_cajachicawwds_18_tfcajdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV92Bancos_cajachicawwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV93Bancos_cajachicawwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV94Bancos_cajachicawwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV95Bancos_cajachicawwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005M2,100, GxCacheFrequency.OFF ,true,false )
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
