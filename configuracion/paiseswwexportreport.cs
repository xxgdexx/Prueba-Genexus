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
   public class paiseswwexportreport : GXWebProcedure
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

      public paiseswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public paiseswwexportreport( IGxContext context )
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
         paiseswwexportreport objpaiseswwexportreport;
         objpaiseswwexportreport = new paiseswwexportreport();
         objpaiseswwexportreport.context.SetSubmitInitialConfig(context);
         objpaiseswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpaiseswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((paiseswwexportreport)stateInfo).executePrivate();
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
            AV53Title = "Lista de Paises";
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
            H3J0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "PAIDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15PaiDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15PaiDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterPaiDscDescription = StringUtil.Format( "%1 (%2)", "Pais", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterPaiDscDescription = StringUtil.Format( "%1 (%2)", "Pais", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17PaiDsc = AV15PaiDsc1;
                  H3J0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterPaiDscDescription, "")), 25, Gx_line+0, 164, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17PaiDsc, "")), 164, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "PAIDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21PaiDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21PaiDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterPaiDscDescription = StringUtil.Format( "%1 (%2)", "Pais", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterPaiDscDescription = StringUtil.Format( "%1 (%2)", "Pais", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17PaiDsc = AV21PaiDsc2;
                     H3J0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterPaiDscDescription, "")), 25, Gx_line+0, 164, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17PaiDsc, "")), 164, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "PAIDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25PaiDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25PaiDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterPaiDscDescription = StringUtil.Format( "%1 (%2)", "Pais", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterPaiDscDescription = StringUtil.Format( "%1 (%2)", "Pais", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17PaiDsc = AV25PaiDsc3;
                        H3J0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterPaiDscDescription, "")), 25, Gx_line+0, 164, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17PaiDsc, "")), 164, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFPaiCod_Sel)) )
         {
            H3J0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 164, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFPaiCod_Sel, "")), 164, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFPaiCod)) )
            {
               H3J0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 164, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFPaiCod, "")), 164, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFPaiDsc_Sel)) )
         {
            H3J0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Pais", 25, Gx_line+0, 164, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFPaiDsc_Sel, "")), 164, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFPaiDsc)) )
            {
               H3J0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Pais", 25, Gx_line+0, 164, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFPaiDsc, "")), 164, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV39TFPaiSts_Sels.FromJSonString(AV37TFPaiSts_SelsJson, null);
         if ( ! ( AV39TFPaiSts_Sels.Count == 0 ) )
         {
            AV42i = 1;
            AV59GXV1 = 1;
            while ( AV59GXV1 <= AV39TFPaiSts_Sels.Count )
            {
               AV40TFPaiSts_Sel = (short)(AV39TFPaiSts_Sels.GetNumeric(AV59GXV1));
               if ( AV42i == 1 )
               {
                  AV38TFPaiSts_SelDscs = "";
               }
               else
               {
                  AV38TFPaiSts_SelDscs += ", ";
               }
               if ( AV40TFPaiSts_Sel == 1 )
               {
                  AV41FilterTFPaiSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV40TFPaiSts_Sel == 0 )
               {
                  AV41FilterTFPaiSts_SelValueDescription = "INACTIVO";
               }
               AV38TFPaiSts_SelDscs += AV41FilterTFPaiSts_SelValueDescription;
               AV42i = (long)(AV42i+1);
               AV59GXV1 = (int)(AV59GXV1+1);
            }
            H3J0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 164, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFPaiSts_SelDscs, "")), 164, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H3J0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H3J0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 179, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Pais", 183, Gx_line+10, 483, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 487, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV61Configuracion_paiseswwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV62Configuracion_paiseswwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV63Configuracion_paiseswwds_3_paidsc1 = AV15PaiDsc1;
         AV64Configuracion_paiseswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Configuracion_paiseswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Configuracion_paiseswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Configuracion_paiseswwds_7_paidsc2 = AV21PaiDsc2;
         AV68Configuracion_paiseswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV69Configuracion_paiseswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV70Configuracion_paiseswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV71Configuracion_paiseswwds_11_paidsc3 = AV25PaiDsc3;
         AV72Configuracion_paiseswwds_12_tfpaicod = AV31TFPaiCod;
         AV73Configuracion_paiseswwds_13_tfpaicod_sel = AV32TFPaiCod_Sel;
         AV74Configuracion_paiseswwds_14_tfpaidsc = AV33TFPaiDsc;
         AV75Configuracion_paiseswwds_15_tfpaidsc_sel = AV34TFPaiDsc_Sel;
         AV76Configuracion_paiseswwds_16_tfpaists_sels = AV39TFPaiSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1501PaiSts ,
                                              AV76Configuracion_paiseswwds_16_tfpaists_sels ,
                                              AV61Configuracion_paiseswwds_1_dynamicfiltersselector1 ,
                                              AV62Configuracion_paiseswwds_2_dynamicfiltersoperator1 ,
                                              AV63Configuracion_paiseswwds_3_paidsc1 ,
                                              AV64Configuracion_paiseswwds_4_dynamicfiltersenabled2 ,
                                              AV65Configuracion_paiseswwds_5_dynamicfiltersselector2 ,
                                              AV66Configuracion_paiseswwds_6_dynamicfiltersoperator2 ,
                                              AV67Configuracion_paiseswwds_7_paidsc2 ,
                                              AV68Configuracion_paiseswwds_8_dynamicfiltersenabled3 ,
                                              AV69Configuracion_paiseswwds_9_dynamicfiltersselector3 ,
                                              AV70Configuracion_paiseswwds_10_dynamicfiltersoperator3 ,
                                              AV71Configuracion_paiseswwds_11_paidsc3 ,
                                              AV73Configuracion_paiseswwds_13_tfpaicod_sel ,
                                              AV72Configuracion_paiseswwds_12_tfpaicod ,
                                              AV75Configuracion_paiseswwds_15_tfpaidsc_sel ,
                                              AV74Configuracion_paiseswwds_14_tfpaidsc ,
                                              AV76Configuracion_paiseswwds_16_tfpaists_sels.Count ,
                                              A1500PaiDsc ,
                                              A139PaiCod ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV63Configuracion_paiseswwds_3_paidsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_paiseswwds_3_paidsc1), 100, "%");
         lV63Configuracion_paiseswwds_3_paidsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_paiseswwds_3_paidsc1), 100, "%");
         lV67Configuracion_paiseswwds_7_paidsc2 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_paiseswwds_7_paidsc2), 100, "%");
         lV67Configuracion_paiseswwds_7_paidsc2 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_paiseswwds_7_paidsc2), 100, "%");
         lV71Configuracion_paiseswwds_11_paidsc3 = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_paiseswwds_11_paidsc3), 100, "%");
         lV71Configuracion_paiseswwds_11_paidsc3 = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_paiseswwds_11_paidsc3), 100, "%");
         lV72Configuracion_paiseswwds_12_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_paiseswwds_12_tfpaicod), 4, "%");
         lV74Configuracion_paiseswwds_14_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_paiseswwds_14_tfpaidsc), 100, "%");
         /* Using cursor P003J2 */
         pr_default.execute(0, new Object[] {lV63Configuracion_paiseswwds_3_paidsc1, lV63Configuracion_paiseswwds_3_paidsc1, lV67Configuracion_paiseswwds_7_paidsc2, lV67Configuracion_paiseswwds_7_paidsc2, lV71Configuracion_paiseswwds_11_paidsc3, lV71Configuracion_paiseswwds_11_paidsc3, lV72Configuracion_paiseswwds_12_tfpaicod, AV73Configuracion_paiseswwds_13_tfpaicod_sel, lV74Configuracion_paiseswwds_14_tfpaidsc, AV75Configuracion_paiseswwds_15_tfpaidsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1501PaiSts = P003J2_A1501PaiSts[0];
            A139PaiCod = P003J2_A139PaiCod[0];
            A1500PaiDsc = P003J2_A1500PaiDsc[0];
            if ( A1501PaiSts == 1 )
            {
               AV12PaiStsDescription = "ACTIVO";
            }
            else if ( A1501PaiSts == 0 )
            {
               AV12PaiStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H3J0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A139PaiCod, "")), 30, Gx_line+10, 179, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1500PaiDsc, "")), 183, Gx_line+10, 483, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12PaiStsDescription, "")), 487, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.PaisesWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.PaisesWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.PaisesWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV77GXV2 = 1;
         while ( AV77GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV77GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPAICOD") == 0 )
            {
               AV31TFPaiCod = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPAICOD_SEL") == 0 )
            {
               AV32TFPaiCod_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPAIDSC") == 0 )
            {
               AV33TFPaiDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPAIDSC_SEL") == 0 )
            {
               AV34TFPaiDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPAISTS_SEL") == 0 )
            {
               AV37TFPaiSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV39TFPaiSts_Sels.FromJSonString(AV37TFPaiSts_SelsJson, null);
            }
            AV77GXV2 = (int)(AV77GXV2+1);
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

      protected void H3J0( bool bFoot ,
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
                  AV51PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV48DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV46AppName = "DVelop Software Solutions";
               AV52Phone = "+1 550 8923";
               AV50Mail = "info@mail.com";
               AV54Website = "http://www.web.com";
               AV43AddressLine1 = "French Boulevard 2859";
               AV44AddressLine2 = "Downtown";
               AV45AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV53Title = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15PaiDsc1 = "";
         AV16FilterPaiDscDescription = "";
         AV17PaiDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21PaiDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25PaiDsc3 = "";
         AV32TFPaiCod_Sel = "";
         AV31TFPaiCod = "";
         AV34TFPaiDsc_Sel = "";
         AV33TFPaiDsc = "";
         AV39TFPaiSts_Sels = new GxSimpleCollection<short>();
         AV37TFPaiSts_SelsJson = "";
         AV38TFPaiSts_SelDscs = "";
         AV41FilterTFPaiSts_SelValueDescription = "";
         AV61Configuracion_paiseswwds_1_dynamicfiltersselector1 = "";
         AV63Configuracion_paiseswwds_3_paidsc1 = "";
         AV65Configuracion_paiseswwds_5_dynamicfiltersselector2 = "";
         AV67Configuracion_paiseswwds_7_paidsc2 = "";
         AV69Configuracion_paiseswwds_9_dynamicfiltersselector3 = "";
         AV71Configuracion_paiseswwds_11_paidsc3 = "";
         AV72Configuracion_paiseswwds_12_tfpaicod = "";
         AV73Configuracion_paiseswwds_13_tfpaicod_sel = "";
         AV74Configuracion_paiseswwds_14_tfpaidsc = "";
         AV75Configuracion_paiseswwds_15_tfpaidsc_sel = "";
         AV76Configuracion_paiseswwds_16_tfpaists_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV63Configuracion_paiseswwds_3_paidsc1 = "";
         lV67Configuracion_paiseswwds_7_paidsc2 = "";
         lV71Configuracion_paiseswwds_11_paidsc3 = "";
         lV72Configuracion_paiseswwds_12_tfpaicod = "";
         lV74Configuracion_paiseswwds_14_tfpaidsc = "";
         A1500PaiDsc = "";
         A139PaiCod = "";
         P003J2_A1501PaiSts = new short[1] ;
         P003J2_A139PaiCod = new string[] {""} ;
         P003J2_A1500PaiDsc = new string[] {""} ;
         AV12PaiStsDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51PageInfo = "";
         AV48DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV46AppName = "";
         AV52Phone = "";
         AV50Mail = "";
         AV54Website = "";
         AV43AddressLine1 = "";
         AV44AddressLine2 = "";
         AV45AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.paiseswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P003J2_A1501PaiSts, P003J2_A139PaiCod, P003J2_A1500PaiDsc
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
      private short AV40TFPaiSts_Sel ;
      private short AV62Configuracion_paiseswwds_2_dynamicfiltersoperator1 ;
      private short AV66Configuracion_paiseswwds_6_dynamicfiltersoperator2 ;
      private short AV70Configuracion_paiseswwds_10_dynamicfiltersoperator3 ;
      private short A1501PaiSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV59GXV1 ;
      private int AV76Configuracion_paiseswwds_16_tfpaists_sels_Count ;
      private int AV77GXV2 ;
      private long AV42i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15PaiDsc1 ;
      private string AV17PaiDsc ;
      private string AV21PaiDsc2 ;
      private string AV25PaiDsc3 ;
      private string AV32TFPaiCod_Sel ;
      private string AV31TFPaiCod ;
      private string AV34TFPaiDsc_Sel ;
      private string AV33TFPaiDsc ;
      private string AV63Configuracion_paiseswwds_3_paidsc1 ;
      private string AV67Configuracion_paiseswwds_7_paidsc2 ;
      private string AV71Configuracion_paiseswwds_11_paidsc3 ;
      private string AV72Configuracion_paiseswwds_12_tfpaicod ;
      private string AV73Configuracion_paiseswwds_13_tfpaicod_sel ;
      private string AV74Configuracion_paiseswwds_14_tfpaidsc ;
      private string AV75Configuracion_paiseswwds_15_tfpaidsc_sel ;
      private string scmdbuf ;
      private string lV63Configuracion_paiseswwds_3_paidsc1 ;
      private string lV67Configuracion_paiseswwds_7_paidsc2 ;
      private string lV71Configuracion_paiseswwds_11_paidsc3 ;
      private string lV72Configuracion_paiseswwds_12_tfpaicod ;
      private string lV74Configuracion_paiseswwds_14_tfpaidsc ;
      private string A1500PaiDsc ;
      private string A139PaiCod ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV64Configuracion_paiseswwds_4_dynamicfiltersenabled2 ;
      private bool AV68Configuracion_paiseswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV37TFPaiSts_SelsJson ;
      private string AV53Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterPaiDscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV38TFPaiSts_SelDscs ;
      private string AV41FilterTFPaiSts_SelValueDescription ;
      private string AV61Configuracion_paiseswwds_1_dynamicfiltersselector1 ;
      private string AV65Configuracion_paiseswwds_5_dynamicfiltersselector2 ;
      private string AV69Configuracion_paiseswwds_9_dynamicfiltersselector3 ;
      private string AV12PaiStsDescription ;
      private string AV51PageInfo ;
      private string AV48DateInfo ;
      private string AV46AppName ;
      private string AV52Phone ;
      private string AV50Mail ;
      private string AV54Website ;
      private string AV43AddressLine1 ;
      private string AV44AddressLine2 ;
      private string AV45AddressLine3 ;
      private GxSimpleCollection<short> AV39TFPaiSts_Sels ;
      private GxSimpleCollection<short> AV76Configuracion_paiseswwds_16_tfpaists_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003J2_A1501PaiSts ;
      private string[] P003J2_A139PaiCod ;
      private string[] P003J2_A1500PaiDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class paiseswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003J2( IGxContext context ,
                                             short A1501PaiSts ,
                                             GxSimpleCollection<short> AV76Configuracion_paiseswwds_16_tfpaists_sels ,
                                             string AV61Configuracion_paiseswwds_1_dynamicfiltersselector1 ,
                                             short AV62Configuracion_paiseswwds_2_dynamicfiltersoperator1 ,
                                             string AV63Configuracion_paiseswwds_3_paidsc1 ,
                                             bool AV64Configuracion_paiseswwds_4_dynamicfiltersenabled2 ,
                                             string AV65Configuracion_paiseswwds_5_dynamicfiltersselector2 ,
                                             short AV66Configuracion_paiseswwds_6_dynamicfiltersoperator2 ,
                                             string AV67Configuracion_paiseswwds_7_paidsc2 ,
                                             bool AV68Configuracion_paiseswwds_8_dynamicfiltersenabled3 ,
                                             string AV69Configuracion_paiseswwds_9_dynamicfiltersselector3 ,
                                             short AV70Configuracion_paiseswwds_10_dynamicfiltersoperator3 ,
                                             string AV71Configuracion_paiseswwds_11_paidsc3 ,
                                             string AV73Configuracion_paiseswwds_13_tfpaicod_sel ,
                                             string AV72Configuracion_paiseswwds_12_tfpaicod ,
                                             string AV75Configuracion_paiseswwds_15_tfpaidsc_sel ,
                                             string AV74Configuracion_paiseswwds_14_tfpaidsc ,
                                             int AV76Configuracion_paiseswwds_16_tfpaists_sels_Count ,
                                             string A1500PaiDsc ,
                                             string A139PaiCod ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [PaiSts], [PaiCod], [PaiDsc] FROM [CPAISES]";
         if ( ( StringUtil.StrCmp(AV61Configuracion_paiseswwds_1_dynamicfiltersselector1, "PAIDSC") == 0 ) && ( AV62Configuracion_paiseswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_paiseswwds_3_paidsc1)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV63Configuracion_paiseswwds_3_paidsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Configuracion_paiseswwds_1_dynamicfiltersselector1, "PAIDSC") == 0 ) && ( AV62Configuracion_paiseswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_paiseswwds_3_paidsc1)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV63Configuracion_paiseswwds_3_paidsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV64Configuracion_paiseswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Configuracion_paiseswwds_5_dynamicfiltersselector2, "PAIDSC") == 0 ) && ( AV66Configuracion_paiseswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_paiseswwds_7_paidsc2)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV67Configuracion_paiseswwds_7_paidsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV64Configuracion_paiseswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Configuracion_paiseswwds_5_dynamicfiltersselector2, "PAIDSC") == 0 ) && ( AV66Configuracion_paiseswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_paiseswwds_7_paidsc2)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV67Configuracion_paiseswwds_7_paidsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV68Configuracion_paiseswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Configuracion_paiseswwds_9_dynamicfiltersselector3, "PAIDSC") == 0 ) && ( AV70Configuracion_paiseswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_paiseswwds_11_paidsc3)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV71Configuracion_paiseswwds_11_paidsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV68Configuracion_paiseswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Configuracion_paiseswwds_9_dynamicfiltersselector3, "PAIDSC") == 0 ) && ( AV70Configuracion_paiseswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_paiseswwds_11_paidsc3)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV71Configuracion_paiseswwds_11_paidsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_paiseswwds_13_tfpaicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_paiseswwds_12_tfpaicod)) ) )
         {
            AddWhere(sWhereString, "([PaiCod] like @lV72Configuracion_paiseswwds_12_tfpaicod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_paiseswwds_13_tfpaicod_sel)) )
         {
            AddWhere(sWhereString, "([PaiCod] = @AV73Configuracion_paiseswwds_13_tfpaicod_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_paiseswwds_15_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_paiseswwds_14_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV74Configuracion_paiseswwds_14_tfpaidsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_paiseswwds_15_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "([PaiDsc] = @AV75Configuracion_paiseswwds_15_tfpaidsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV76Configuracion_paiseswwds_16_tfpaists_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Configuracion_paiseswwds_16_tfpaists_sels, "[PaiSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaiCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaiCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaiDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaiDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaiSts]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaiSts] DESC";
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
                     return conditional_P003J2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP003J2;
          prmP003J2 = new Object[] {
          new ParDef("@lV63Configuracion_paiseswwds_3_paidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_paiseswwds_3_paidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_paiseswwds_7_paidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_paiseswwds_7_paidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_paiseswwds_11_paidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_paiseswwds_11_paidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_paiseswwds_12_tfpaicod",GXType.NChar,4,0) ,
          new ParDef("@AV73Configuracion_paiseswwds_13_tfpaicod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV74Configuracion_paiseswwds_14_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Configuracion_paiseswwds_15_tfpaidsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003J2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
