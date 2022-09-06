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
   public class distritoswwexportreport : GXWebProcedure
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

      public distritoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public distritoswwexportreport( IGxContext context )
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
         distritoswwexportreport objdistritoswwexportreport;
         objdistritoswwexportreport = new distritoswwexportreport();
         objdistritoswwexportreport.context.SetSubmitInitialConfig(context);
         objdistritoswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdistritoswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((distritoswwexportreport)stateInfo).executePrivate();
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
            AV59Title = "Lista de Distritos";
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
            H3Y0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "DISDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15DisDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15DisDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterDisDscDescription = StringUtil.Format( "%1 (%2)", "Distrito", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterDisDscDescription = StringUtil.Format( "%1 (%2)", "Distrito", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17DisDsc = AV15DisDsc1;
                  H3Y0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterDisDscDescription, "")), 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DisDsc, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "DISDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21DisDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21DisDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterDisDscDescription = StringUtil.Format( "%1 (%2)", "Distrito", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterDisDscDescription = StringUtil.Format( "%1 (%2)", "Distrito", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17DisDsc = AV21DisDsc2;
                     H3Y0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterDisDscDescription, "")), 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DisDsc, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "DISDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25DisDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25DisDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterDisDscDescription = StringUtil.Format( "%1 (%2)", "Distrito", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterDisDscDescription = StringUtil.Format( "%1 (%2)", "Distrito", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17DisDsc = AV25DisDsc3;
                        H3Y0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterDisDscDescription, "")), 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DisDsc, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFDisCod_Sel)) )
         {
            H3Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFDisCod_Sel, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFDisCod)) )
            {
               H3Y0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFDisCod, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFDisDsc_Sel)) )
         {
            H3Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Distrito", 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFDisDsc_Sel, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFDisDsc)) )
            {
               H3Y0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Distrito", 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFDisDsc, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPaiDsc_Sel)) )
         {
            H3Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Pais", 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFPaiDsc_Sel, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPaiDsc)) )
            {
               H3Y0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Pais", 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFPaiDsc, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV45TFDisSts_Sels.FromJSonString(AV43TFDisSts_SelsJson, null);
         if ( ! ( AV45TFDisSts_Sels.Count == 0 ) )
         {
            AV48i = 1;
            AV65GXV1 = 1;
            while ( AV65GXV1 <= AV45TFDisSts_Sels.Count )
            {
               AV46TFDisSts_Sel = (short)(AV45TFDisSts_Sels.GetNumeric(AV65GXV1));
               if ( AV48i == 1 )
               {
                  AV44TFDisSts_SelDscs = "";
               }
               else
               {
                  AV44TFDisSts_SelDscs += ", ";
               }
               if ( AV46TFDisSts_Sel == 1 )
               {
                  AV47FilterTFDisSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV46TFDisSts_Sel == 0 )
               {
                  AV47FilterTFDisSts_SelValueDescription = "INACTIVO";
               }
               AV44TFDisSts_SelDscs += AV47FilterTFDisSts_SelValueDescription;
               AV48i = (long)(AV48i+1);
               AV65GXV1 = (int)(AV65GXV1+1);
            }
            H3Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFDisSts_SelDscs, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H3Y0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H3Y0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 136, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Distrito", 140, Gx_line+10, 352, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Pais", 356, Gx_line+10, 569, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 573, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV67Configuracion_distritoswwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV68Configuracion_distritoswwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV69Configuracion_distritoswwds_3_disdsc1 = AV15DisDsc1;
         AV70Configuracion_distritoswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV71Configuracion_distritoswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV72Configuracion_distritoswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV73Configuracion_distritoswwds_7_disdsc2 = AV21DisDsc2;
         AV74Configuracion_distritoswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV75Configuracion_distritoswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV76Configuracion_distritoswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV77Configuracion_distritoswwds_11_disdsc3 = AV25DisDsc3;
         AV78Configuracion_distritoswwds_12_tfdiscod = AV35TFDisCod;
         AV79Configuracion_distritoswwds_13_tfdiscod_sel = AV36TFDisCod_Sel;
         AV80Configuracion_distritoswwds_14_tfdisdsc = AV39TFDisDsc;
         AV81Configuracion_distritoswwds_15_tfdisdsc_sel = AV40TFDisDsc_Sel;
         AV82Configuracion_distritoswwds_16_tfpaidsc = AV37TFPaiDsc;
         AV83Configuracion_distritoswwds_17_tfpaidsc_sel = AV38TFPaiDsc_Sel;
         AV84Configuracion_distritoswwds_18_tfdissts_sels = AV45TFDisSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A878DisSts ,
                                              AV84Configuracion_distritoswwds_18_tfdissts_sels ,
                                              AV67Configuracion_distritoswwds_1_dynamicfiltersselector1 ,
                                              AV68Configuracion_distritoswwds_2_dynamicfiltersoperator1 ,
                                              AV69Configuracion_distritoswwds_3_disdsc1 ,
                                              AV70Configuracion_distritoswwds_4_dynamicfiltersenabled2 ,
                                              AV71Configuracion_distritoswwds_5_dynamicfiltersselector2 ,
                                              AV72Configuracion_distritoswwds_6_dynamicfiltersoperator2 ,
                                              AV73Configuracion_distritoswwds_7_disdsc2 ,
                                              AV74Configuracion_distritoswwds_8_dynamicfiltersenabled3 ,
                                              AV75Configuracion_distritoswwds_9_dynamicfiltersselector3 ,
                                              AV76Configuracion_distritoswwds_10_dynamicfiltersoperator3 ,
                                              AV77Configuracion_distritoswwds_11_disdsc3 ,
                                              AV79Configuracion_distritoswwds_13_tfdiscod_sel ,
                                              AV78Configuracion_distritoswwds_12_tfdiscod ,
                                              AV81Configuracion_distritoswwds_15_tfdisdsc_sel ,
                                              AV80Configuracion_distritoswwds_14_tfdisdsc ,
                                              AV83Configuracion_distritoswwds_17_tfpaidsc_sel ,
                                              AV82Configuracion_distritoswwds_16_tfpaidsc ,
                                              AV84Configuracion_distritoswwds_18_tfdissts_sels.Count ,
                                              A604DisDsc ,
                                              A142DisCod ,
                                              A1500PaiDsc ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV69Configuracion_distritoswwds_3_disdsc1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_distritoswwds_3_disdsc1), 100, "%");
         lV69Configuracion_distritoswwds_3_disdsc1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_distritoswwds_3_disdsc1), 100, "%");
         lV73Configuracion_distritoswwds_7_disdsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_distritoswwds_7_disdsc2), 100, "%");
         lV73Configuracion_distritoswwds_7_disdsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_distritoswwds_7_disdsc2), 100, "%");
         lV77Configuracion_distritoswwds_11_disdsc3 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_distritoswwds_11_disdsc3), 100, "%");
         lV77Configuracion_distritoswwds_11_disdsc3 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_distritoswwds_11_disdsc3), 100, "%");
         lV78Configuracion_distritoswwds_12_tfdiscod = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_distritoswwds_12_tfdiscod), 4, "%");
         lV80Configuracion_distritoswwds_14_tfdisdsc = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_distritoswwds_14_tfdisdsc), 100, "%");
         lV82Configuracion_distritoswwds_16_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_distritoswwds_16_tfpaidsc), 100, "%");
         /* Using cursor P003Y2 */
         pr_default.execute(0, new Object[] {lV69Configuracion_distritoswwds_3_disdsc1, lV69Configuracion_distritoswwds_3_disdsc1, lV73Configuracion_distritoswwds_7_disdsc2, lV73Configuracion_distritoswwds_7_disdsc2, lV77Configuracion_distritoswwds_11_disdsc3, lV77Configuracion_distritoswwds_11_disdsc3, lV78Configuracion_distritoswwds_12_tfdiscod, AV79Configuracion_distritoswwds_13_tfdiscod_sel, lV80Configuracion_distritoswwds_14_tfdisdsc, AV81Configuracion_distritoswwds_15_tfdisdsc_sel, lV82Configuracion_distritoswwds_16_tfpaidsc, AV83Configuracion_distritoswwds_17_tfpaidsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A878DisSts = P003Y2_A878DisSts[0];
            A1500PaiDsc = P003Y2_A1500PaiDsc[0];
            A142DisCod = P003Y2_A142DisCod[0];
            A604DisDsc = P003Y2_A604DisDsc[0];
            A139PaiCod = P003Y2_A139PaiCod[0];
            A140EstCod = P003Y2_A140EstCod[0];
            A141ProvCod = P003Y2_A141ProvCod[0];
            A1500PaiDsc = P003Y2_A1500PaiDsc[0];
            if ( A878DisSts == 1 )
            {
               AV12DisStsDescription = "ACTIVO";
            }
            else if ( A878DisSts == 0 )
            {
               AV12DisStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H3Y0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A142DisCod, "")), 30, Gx_line+10, 136, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A604DisDsc, "")), 140, Gx_line+10, 352, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1500PaiDsc, "")), 356, Gx_line+10, 569, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12DisStsDescription, "")), 573, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.DistritosWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.DistritosWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.DistritosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV85GXV2 = 1;
         while ( AV85GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV85GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDISCOD") == 0 )
            {
               AV35TFDisCod = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDISCOD_SEL") == 0 )
            {
               AV36TFDisCod_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDISDSC") == 0 )
            {
               AV39TFDisDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDISDSC_SEL") == 0 )
            {
               AV40TFDisDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPAIDSC") == 0 )
            {
               AV37TFPaiDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPAIDSC_SEL") == 0 )
            {
               AV38TFPaiDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDISSTS_SEL") == 0 )
            {
               AV43TFDisSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV45TFDisSts_Sels.FromJSonString(AV43TFDisSts_SelsJson, null);
            }
            AV85GXV2 = (int)(AV85GXV2+1);
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

      protected void H3Y0( bool bFoot ,
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
                  AV57PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV54DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV52AppName = "DVelop Software Solutions";
               AV58Phone = "+1 550 8923";
               AV56Mail = "info@mail.com";
               AV60Website = "http://www.web.com";
               AV49AddressLine1 = "French Boulevard 2859";
               AV50AddressLine2 = "Downtown";
               AV51AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV59Title = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15DisDsc1 = "";
         AV16FilterDisDscDescription = "";
         AV17DisDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21DisDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25DisDsc3 = "";
         AV36TFDisCod_Sel = "";
         AV35TFDisCod = "";
         AV40TFDisDsc_Sel = "";
         AV39TFDisDsc = "";
         AV38TFPaiDsc_Sel = "";
         AV37TFPaiDsc = "";
         AV45TFDisSts_Sels = new GxSimpleCollection<short>();
         AV43TFDisSts_SelsJson = "";
         AV44TFDisSts_SelDscs = "";
         AV47FilterTFDisSts_SelValueDescription = "";
         AV67Configuracion_distritoswwds_1_dynamicfiltersselector1 = "";
         AV69Configuracion_distritoswwds_3_disdsc1 = "";
         AV71Configuracion_distritoswwds_5_dynamicfiltersselector2 = "";
         AV73Configuracion_distritoswwds_7_disdsc2 = "";
         AV75Configuracion_distritoswwds_9_dynamicfiltersselector3 = "";
         AV77Configuracion_distritoswwds_11_disdsc3 = "";
         AV78Configuracion_distritoswwds_12_tfdiscod = "";
         AV79Configuracion_distritoswwds_13_tfdiscod_sel = "";
         AV80Configuracion_distritoswwds_14_tfdisdsc = "";
         AV81Configuracion_distritoswwds_15_tfdisdsc_sel = "";
         AV82Configuracion_distritoswwds_16_tfpaidsc = "";
         AV83Configuracion_distritoswwds_17_tfpaidsc_sel = "";
         AV84Configuracion_distritoswwds_18_tfdissts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV69Configuracion_distritoswwds_3_disdsc1 = "";
         lV73Configuracion_distritoswwds_7_disdsc2 = "";
         lV77Configuracion_distritoswwds_11_disdsc3 = "";
         lV78Configuracion_distritoswwds_12_tfdiscod = "";
         lV80Configuracion_distritoswwds_14_tfdisdsc = "";
         lV82Configuracion_distritoswwds_16_tfpaidsc = "";
         A604DisDsc = "";
         A142DisCod = "";
         A1500PaiDsc = "";
         P003Y2_A878DisSts = new short[1] ;
         P003Y2_A1500PaiDsc = new string[] {""} ;
         P003Y2_A142DisCod = new string[] {""} ;
         P003Y2_A604DisDsc = new string[] {""} ;
         P003Y2_A139PaiCod = new string[] {""} ;
         P003Y2_A140EstCod = new string[] {""} ;
         P003Y2_A141ProvCod = new string[] {""} ;
         A139PaiCod = "";
         A140EstCod = "";
         A141ProvCod = "";
         AV12DisStsDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV57PageInfo = "";
         AV54DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV52AppName = "";
         AV58Phone = "";
         AV56Mail = "";
         AV60Website = "";
         AV49AddressLine1 = "";
         AV50AddressLine2 = "";
         AV51AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.distritoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P003Y2_A878DisSts, P003Y2_A1500PaiDsc, P003Y2_A142DisCod, P003Y2_A604DisDsc, P003Y2_A139PaiCod, P003Y2_A140EstCod, P003Y2_A141ProvCod
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
      private short AV46TFDisSts_Sel ;
      private short AV68Configuracion_distritoswwds_2_dynamicfiltersoperator1 ;
      private short AV72Configuracion_distritoswwds_6_dynamicfiltersoperator2 ;
      private short AV76Configuracion_distritoswwds_10_dynamicfiltersoperator3 ;
      private short A878DisSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV65GXV1 ;
      private int AV84Configuracion_distritoswwds_18_tfdissts_sels_Count ;
      private int AV85GXV2 ;
      private long AV48i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15DisDsc1 ;
      private string AV17DisDsc ;
      private string AV21DisDsc2 ;
      private string AV25DisDsc3 ;
      private string AV36TFDisCod_Sel ;
      private string AV35TFDisCod ;
      private string AV40TFDisDsc_Sel ;
      private string AV39TFDisDsc ;
      private string AV38TFPaiDsc_Sel ;
      private string AV37TFPaiDsc ;
      private string AV69Configuracion_distritoswwds_3_disdsc1 ;
      private string AV73Configuracion_distritoswwds_7_disdsc2 ;
      private string AV77Configuracion_distritoswwds_11_disdsc3 ;
      private string AV78Configuracion_distritoswwds_12_tfdiscod ;
      private string AV79Configuracion_distritoswwds_13_tfdiscod_sel ;
      private string AV80Configuracion_distritoswwds_14_tfdisdsc ;
      private string AV81Configuracion_distritoswwds_15_tfdisdsc_sel ;
      private string AV82Configuracion_distritoswwds_16_tfpaidsc ;
      private string AV83Configuracion_distritoswwds_17_tfpaidsc_sel ;
      private string scmdbuf ;
      private string lV69Configuracion_distritoswwds_3_disdsc1 ;
      private string lV73Configuracion_distritoswwds_7_disdsc2 ;
      private string lV77Configuracion_distritoswwds_11_disdsc3 ;
      private string lV78Configuracion_distritoswwds_12_tfdiscod ;
      private string lV80Configuracion_distritoswwds_14_tfdisdsc ;
      private string lV82Configuracion_distritoswwds_16_tfpaidsc ;
      private string A604DisDsc ;
      private string A142DisCod ;
      private string A1500PaiDsc ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A141ProvCod ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV70Configuracion_distritoswwds_4_dynamicfiltersenabled2 ;
      private bool AV74Configuracion_distritoswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV43TFDisSts_SelsJson ;
      private string AV59Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterDisDscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV44TFDisSts_SelDscs ;
      private string AV47FilterTFDisSts_SelValueDescription ;
      private string AV67Configuracion_distritoswwds_1_dynamicfiltersselector1 ;
      private string AV71Configuracion_distritoswwds_5_dynamicfiltersselector2 ;
      private string AV75Configuracion_distritoswwds_9_dynamicfiltersselector3 ;
      private string AV12DisStsDescription ;
      private string AV57PageInfo ;
      private string AV54DateInfo ;
      private string AV52AppName ;
      private string AV58Phone ;
      private string AV56Mail ;
      private string AV60Website ;
      private string AV49AddressLine1 ;
      private string AV50AddressLine2 ;
      private string AV51AddressLine3 ;
      private GxSimpleCollection<short> AV45TFDisSts_Sels ;
      private GxSimpleCollection<short> AV84Configuracion_distritoswwds_18_tfdissts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003Y2_A878DisSts ;
      private string[] P003Y2_A1500PaiDsc ;
      private string[] P003Y2_A142DisCod ;
      private string[] P003Y2_A604DisDsc ;
      private string[] P003Y2_A139PaiCod ;
      private string[] P003Y2_A140EstCod ;
      private string[] P003Y2_A141ProvCod ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class distritoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003Y2( IGxContext context ,
                                             short A878DisSts ,
                                             GxSimpleCollection<short> AV84Configuracion_distritoswwds_18_tfdissts_sels ,
                                             string AV67Configuracion_distritoswwds_1_dynamicfiltersselector1 ,
                                             short AV68Configuracion_distritoswwds_2_dynamicfiltersoperator1 ,
                                             string AV69Configuracion_distritoswwds_3_disdsc1 ,
                                             bool AV70Configuracion_distritoswwds_4_dynamicfiltersenabled2 ,
                                             string AV71Configuracion_distritoswwds_5_dynamicfiltersselector2 ,
                                             short AV72Configuracion_distritoswwds_6_dynamicfiltersoperator2 ,
                                             string AV73Configuracion_distritoswwds_7_disdsc2 ,
                                             bool AV74Configuracion_distritoswwds_8_dynamicfiltersenabled3 ,
                                             string AV75Configuracion_distritoswwds_9_dynamicfiltersselector3 ,
                                             short AV76Configuracion_distritoswwds_10_dynamicfiltersoperator3 ,
                                             string AV77Configuracion_distritoswwds_11_disdsc3 ,
                                             string AV79Configuracion_distritoswwds_13_tfdiscod_sel ,
                                             string AV78Configuracion_distritoswwds_12_tfdiscod ,
                                             string AV81Configuracion_distritoswwds_15_tfdisdsc_sel ,
                                             string AV80Configuracion_distritoswwds_14_tfdisdsc ,
                                             string AV83Configuracion_distritoswwds_17_tfpaidsc_sel ,
                                             string AV82Configuracion_distritoswwds_16_tfpaidsc ,
                                             int AV84Configuracion_distritoswwds_18_tfdissts_sels_Count ,
                                             string A604DisDsc ,
                                             string A142DisCod ,
                                             string A1500PaiDsc ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[DisSts], T2.[PaiDsc], T1.[DisCod], T1.[DisDsc], T1.[PaiCod], T1.[EstCod], T1.[ProvCod] FROM ([CDISTRITOS] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV67Configuracion_distritoswwds_1_dynamicfiltersselector1, "DISDSC") == 0 ) && ( AV68Configuracion_distritoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_distritoswwds_3_disdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV69Configuracion_distritoswwds_3_disdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Configuracion_distritoswwds_1_dynamicfiltersselector1, "DISDSC") == 0 ) && ( AV68Configuracion_distritoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_distritoswwds_3_disdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV69Configuracion_distritoswwds_3_disdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV70Configuracion_distritoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_distritoswwds_5_dynamicfiltersselector2, "DISDSC") == 0 ) && ( AV72Configuracion_distritoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_distritoswwds_7_disdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV73Configuracion_distritoswwds_7_disdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV70Configuracion_distritoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_distritoswwds_5_dynamicfiltersselector2, "DISDSC") == 0 ) && ( AV72Configuracion_distritoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_distritoswwds_7_disdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV73Configuracion_distritoswwds_7_disdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV74Configuracion_distritoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Configuracion_distritoswwds_9_dynamicfiltersselector3, "DISDSC") == 0 ) && ( AV76Configuracion_distritoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_distritoswwds_11_disdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV77Configuracion_distritoswwds_11_disdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV74Configuracion_distritoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Configuracion_distritoswwds_9_dynamicfiltersselector3, "DISDSC") == 0 ) && ( AV76Configuracion_distritoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_distritoswwds_11_disdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV77Configuracion_distritoswwds_11_disdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_distritoswwds_13_tfdiscod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_distritoswwds_12_tfdiscod)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisCod] like @lV78Configuracion_distritoswwds_12_tfdiscod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_distritoswwds_13_tfdiscod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[DisCod] = @AV79Configuracion_distritoswwds_13_tfdiscod_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_distritoswwds_15_tfdisdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_distritoswwds_14_tfdisdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV80Configuracion_distritoswwds_14_tfdisdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_distritoswwds_15_tfdisdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] = @AV81Configuracion_distritoswwds_15_tfdisdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_distritoswwds_17_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_distritoswwds_16_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV82Configuracion_distritoswwds_16_tfpaidsc)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_distritoswwds_17_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV83Configuracion_distritoswwds_17_tfpaidsc_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV84Configuracion_distritoswwds_18_tfdissts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV84Configuracion_distritoswwds_18_tfdissts_sels, "T1.[DisSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[PaiCod], T1.[DisCod]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DisCod]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DisCod] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DisDsc]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DisDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[PaiDsc]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[PaiDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DisSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DisSts] DESC";
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
                     return conditional_P003Y2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP003Y2;
          prmP003Y2 = new Object[] {
          new ParDef("@lV69Configuracion_distritoswwds_3_disdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_distritoswwds_3_disdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_distritoswwds_7_disdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_distritoswwds_7_disdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV77Configuracion_distritoswwds_11_disdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV77Configuracion_distritoswwds_11_disdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_distritoswwds_12_tfdiscod",GXType.NChar,4,0) ,
          new ParDef("@AV79Configuracion_distritoswwds_13_tfdiscod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV80Configuracion_distritoswwds_14_tfdisdsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Configuracion_distritoswwds_15_tfdisdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_distritoswwds_16_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV83Configuracion_distritoswwds_17_tfpaidsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Y2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                ((string[]) buf[5])[0] = rslt.getString(6, 4);
                ((string[]) buf[6])[0] = rslt.getString(7, 4);
                return;
       }
    }

 }

}
