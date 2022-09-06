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
   public class tipoauxiliarwwexportreport : GXWebProcedure
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

      public tipoauxiliarwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipoauxiliarwwexportreport( IGxContext context )
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
         tipoauxiliarwwexportreport objtipoauxiliarwwexportreport;
         objtipoauxiliarwwexportreport = new tipoauxiliarwwexportreport();
         objtipoauxiliarwwexportreport.context.SetSubmitInitialConfig(context);
         objtipoauxiliarwwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipoauxiliarwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipoauxiliarwwexportreport)stateInfo).executePrivate();
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
            AV52Title = "Lista de Tipos de Auxiliares";
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
            H6M0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "TIPADSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15TipADsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TipADsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterTipADscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterTipADscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Auxiliar", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17TipADsc = AV15TipADsc1;
                  H6M0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipADscDescription, "")), 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipADsc, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPADSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21TipADsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TipADsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterTipADscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterTipADscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Auxiliar", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17TipADsc = AV21TipADsc2;
                     H6M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipADscDescription, "")), 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipADsc, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPADSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25TipADsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TipADsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterTipADscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterTipADscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Auxiliar", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17TipADsc = AV25TipADsc3;
                        H6M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipADscDescription, "")), 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipADsc, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFTipACod) && (0==AV32TFTipACod_To) ) )
         {
            H6M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFTipACod), "ZZZZZ9")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV39TFTipACod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H6M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFTipACod_To_Description, "")), 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFTipACod_To), "ZZZZZ9")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTipADsc_Sel)) )
         {
            H6M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Auxiliar", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFTipADsc_Sel, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTipADsc)) )
            {
               H6M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo de Auxiliar", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTipADsc, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV37TFTipASts_Sels.FromJSonString(AV35TFTipASts_SelsJson, null);
         if ( ! ( AV37TFTipASts_Sels.Count == 0 ) )
         {
            AV41i = 1;
            AV61GXV1 = 1;
            while ( AV61GXV1 <= AV37TFTipASts_Sels.Count )
            {
               AV38TFTipASts_Sel = (short)(AV37TFTipASts_Sels.GetNumeric(AV61GXV1));
               if ( AV41i == 1 )
               {
                  AV36TFTipASts_SelDscs = "";
               }
               else
               {
                  AV36TFTipASts_SelDscs += ", ";
               }
               if ( AV38TFTipASts_Sel == 1 )
               {
                  AV40FilterTFTipASts_SelValueDescription = "Activo";
               }
               else if ( AV38TFTipASts_Sel == 0 )
               {
                  AV40FilterTFTipASts_SelValueDescription = "Inactivo";
               }
               AV36TFTipASts_SelDscs += AV40FilterTFTipASts_SelValueDescription;
               AV41i = (long)(AV41i+1);
               AV61GXV1 = (int)(AV61GXV1+1);
            }
            H6M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFTipASts_SelDscs, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6M0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6M0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 179, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo de Auxiliar", 183, Gx_line+10, 483, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 487, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV63Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV64Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV65Contabilidad_tipoauxiliarwwds_3_tipadsc1 = AV15TipADsc1;
         AV66Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV67Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV68Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV69Contabilidad_tipoauxiliarwwds_7_tipadsc2 = AV21TipADsc2;
         AV70Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV71Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV72Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV73Contabilidad_tipoauxiliarwwds_11_tipadsc3 = AV25TipADsc3;
         AV74Contabilidad_tipoauxiliarwwds_12_tftipacod = AV31TFTipACod;
         AV75Contabilidad_tipoauxiliarwwds_13_tftipacod_to = AV32TFTipACod_To;
         AV76Contabilidad_tipoauxiliarwwds_14_tftipadsc = AV33TFTipADsc;
         AV77Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel = AV34TFTipADsc_Sel;
         AV78Contabilidad_tipoauxiliarwwds_16_tftipasts_sels = AV37TFTipASts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1902TipASts ,
                                              AV78Contabilidad_tipoauxiliarwwds_16_tftipasts_sels ,
                                              AV63Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 ,
                                              AV64Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 ,
                                              AV65Contabilidad_tipoauxiliarwwds_3_tipadsc1 ,
                                              AV66Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 ,
                                              AV67Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 ,
                                              AV68Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 ,
                                              AV69Contabilidad_tipoauxiliarwwds_7_tipadsc2 ,
                                              AV70Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 ,
                                              AV71Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 ,
                                              AV72Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 ,
                                              AV73Contabilidad_tipoauxiliarwwds_11_tipadsc3 ,
                                              AV74Contabilidad_tipoauxiliarwwds_12_tftipacod ,
                                              AV75Contabilidad_tipoauxiliarwwds_13_tftipacod_to ,
                                              AV77Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel ,
                                              AV76Contabilidad_tipoauxiliarwwds_14_tftipadsc ,
                                              AV78Contabilidad_tipoauxiliarwwds_16_tftipasts_sels.Count ,
                                              A1900TipADsc ,
                                              A70TipACod ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV65Contabilidad_tipoauxiliarwwds_3_tipadsc1 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_tipoauxiliarwwds_3_tipadsc1), 100, "%");
         lV65Contabilidad_tipoauxiliarwwds_3_tipadsc1 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_tipoauxiliarwwds_3_tipadsc1), 100, "%");
         lV69Contabilidad_tipoauxiliarwwds_7_tipadsc2 = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_tipoauxiliarwwds_7_tipadsc2), 100, "%");
         lV69Contabilidad_tipoauxiliarwwds_7_tipadsc2 = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_tipoauxiliarwwds_7_tipadsc2), 100, "%");
         lV73Contabilidad_tipoauxiliarwwds_11_tipadsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Contabilidad_tipoauxiliarwwds_11_tipadsc3), 100, "%");
         lV73Contabilidad_tipoauxiliarwwds_11_tipadsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Contabilidad_tipoauxiliarwwds_11_tipadsc3), 100, "%");
         lV76Contabilidad_tipoauxiliarwwds_14_tftipadsc = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_tipoauxiliarwwds_14_tftipadsc), 100, "%");
         /* Using cursor P006M2 */
         pr_default.execute(0, new Object[] {lV65Contabilidad_tipoauxiliarwwds_3_tipadsc1, lV65Contabilidad_tipoauxiliarwwds_3_tipadsc1, lV69Contabilidad_tipoauxiliarwwds_7_tipadsc2, lV69Contabilidad_tipoauxiliarwwds_7_tipadsc2, lV73Contabilidad_tipoauxiliarwwds_11_tipadsc3, lV73Contabilidad_tipoauxiliarwwds_11_tipadsc3, AV74Contabilidad_tipoauxiliarwwds_12_tftipacod, AV75Contabilidad_tipoauxiliarwwds_13_tftipacod_to, lV76Contabilidad_tipoauxiliarwwds_14_tftipadsc, AV77Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1902TipASts = P006M2_A1902TipASts[0];
            A70TipACod = P006M2_A70TipACod[0];
            A1900TipADsc = P006M2_A1900TipADsc[0];
            if ( A1902TipASts == 1 )
            {
               AV12TipAStsDescription = "Activo";
            }
            else if ( A1902TipASts == 0 )
            {
               AV12TipAStsDescription = "Inactivo";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6M0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9")), 30, Gx_line+10, 179, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1900TipADsc, "")), 183, Gx_line+10, 483, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12TipAStsDescription, "")), 487, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Contabilidad.TipoAuxiliarWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.TipoAuxiliarWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Contabilidad.TipoAuxiliarWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV79GXV2 = 1;
         while ( AV79GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV79GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPACOD") == 0 )
            {
               AV31TFTipACod = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV32TFTipACod_To = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPADSC") == 0 )
            {
               AV33TFTipADsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPADSC_SEL") == 0 )
            {
               AV34TFTipADsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPASTS_SEL") == 0 )
            {
               AV35TFTipASts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV37TFTipASts_Sels.FromJSonString(AV35TFTipASts_SelsJson, null);
            }
            AV79GXV2 = (int)(AV79GXV2+1);
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

      protected void H6M0( bool bFoot ,
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
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15TipADsc1 = "";
         AV16FilterTipADscDescription = "";
         AV17TipADsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21TipADsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25TipADsc3 = "";
         AV39TFTipACod_To_Description = "";
         AV34TFTipADsc_Sel = "";
         AV33TFTipADsc = "";
         AV37TFTipASts_Sels = new GxSimpleCollection<short>();
         AV35TFTipASts_SelsJson = "";
         AV36TFTipASts_SelDscs = "";
         AV40FilterTFTipASts_SelValueDescription = "";
         AV63Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 = "";
         AV65Contabilidad_tipoauxiliarwwds_3_tipadsc1 = "";
         AV67Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 = "";
         AV69Contabilidad_tipoauxiliarwwds_7_tipadsc2 = "";
         AV71Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 = "";
         AV73Contabilidad_tipoauxiliarwwds_11_tipadsc3 = "";
         AV76Contabilidad_tipoauxiliarwwds_14_tftipadsc = "";
         AV77Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel = "";
         AV78Contabilidad_tipoauxiliarwwds_16_tftipasts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV65Contabilidad_tipoauxiliarwwds_3_tipadsc1 = "";
         lV69Contabilidad_tipoauxiliarwwds_7_tipadsc2 = "";
         lV73Contabilidad_tipoauxiliarwwds_11_tipadsc3 = "";
         lV76Contabilidad_tipoauxiliarwwds_14_tftipadsc = "";
         A1900TipADsc = "";
         P006M2_A1902TipASts = new short[1] ;
         P006M2_A70TipACod = new int[1] ;
         P006M2_A1900TipADsc = new string[] {""} ;
         AV12TipAStsDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.tipoauxiliarwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006M2_A1902TipASts, P006M2_A70TipACod, P006M2_A1900TipADsc
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
      private short AV38TFTipASts_Sel ;
      private short AV64Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 ;
      private short AV68Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 ;
      private short AV72Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 ;
      private short A1902TipASts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV31TFTipACod ;
      private int AV32TFTipACod_To ;
      private int AV61GXV1 ;
      private int AV74Contabilidad_tipoauxiliarwwds_12_tftipacod ;
      private int AV75Contabilidad_tipoauxiliarwwds_13_tftipacod_to ;
      private int AV78Contabilidad_tipoauxiliarwwds_16_tftipasts_sels_Count ;
      private int A70TipACod ;
      private int AV79GXV2 ;
      private long AV41i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15TipADsc1 ;
      private string AV17TipADsc ;
      private string AV21TipADsc2 ;
      private string AV25TipADsc3 ;
      private string AV34TFTipADsc_Sel ;
      private string AV33TFTipADsc ;
      private string AV65Contabilidad_tipoauxiliarwwds_3_tipadsc1 ;
      private string AV69Contabilidad_tipoauxiliarwwds_7_tipadsc2 ;
      private string AV73Contabilidad_tipoauxiliarwwds_11_tipadsc3 ;
      private string AV76Contabilidad_tipoauxiliarwwds_14_tftipadsc ;
      private string AV77Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel ;
      private string scmdbuf ;
      private string lV65Contabilidad_tipoauxiliarwwds_3_tipadsc1 ;
      private string lV69Contabilidad_tipoauxiliarwwds_7_tipadsc2 ;
      private string lV73Contabilidad_tipoauxiliarwwds_11_tipadsc3 ;
      private string lV76Contabilidad_tipoauxiliarwwds_14_tftipadsc ;
      private string A1900TipADsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV66Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 ;
      private bool AV70Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV35TFTipASts_SelsJson ;
      private string AV52Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterTipADscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV39TFTipACod_To_Description ;
      private string AV36TFTipASts_SelDscs ;
      private string AV40FilterTFTipASts_SelValueDescription ;
      private string AV63Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 ;
      private string AV67Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 ;
      private string AV71Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 ;
      private string AV12TipAStsDescription ;
      private string AV50PageInfo ;
      private string AV47DateInfo ;
      private string AV45AppName ;
      private string AV51Phone ;
      private string AV49Mail ;
      private string AV53Website ;
      private string AV42AddressLine1 ;
      private string AV43AddressLine2 ;
      private string AV44AddressLine3 ;
      private GxSimpleCollection<short> AV37TFTipASts_Sels ;
      private GxSimpleCollection<short> AV78Contabilidad_tipoauxiliarwwds_16_tftipasts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006M2_A1902TipASts ;
      private int[] P006M2_A70TipACod ;
      private string[] P006M2_A1900TipADsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class tipoauxiliarwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006M2( IGxContext context ,
                                             short A1902TipASts ,
                                             GxSimpleCollection<short> AV78Contabilidad_tipoauxiliarwwds_16_tftipasts_sels ,
                                             string AV63Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 ,
                                             short AV64Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 ,
                                             string AV65Contabilidad_tipoauxiliarwwds_3_tipadsc1 ,
                                             bool AV66Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 ,
                                             string AV67Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 ,
                                             short AV68Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 ,
                                             string AV69Contabilidad_tipoauxiliarwwds_7_tipadsc2 ,
                                             bool AV70Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 ,
                                             string AV71Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 ,
                                             short AV72Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 ,
                                             string AV73Contabilidad_tipoauxiliarwwds_11_tipadsc3 ,
                                             int AV74Contabilidad_tipoauxiliarwwds_12_tftipacod ,
                                             int AV75Contabilidad_tipoauxiliarwwds_13_tftipacod_to ,
                                             string AV77Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel ,
                                             string AV76Contabilidad_tipoauxiliarwwds_14_tftipadsc ,
                                             int AV78Contabilidad_tipoauxiliarwwds_16_tftipasts_sels_Count ,
                                             string A1900TipADsc ,
                                             int A70TipACod ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TipASts], [TipACod], [TipADsc] FROM [CBTIPAUXILIAR]";
         if ( ( StringUtil.StrCmp(AV63Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1, "TIPADSC") == 0 ) && ( AV64Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_tipoauxiliarwwds_3_tipadsc1)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like @lV65Contabilidad_tipoauxiliarwwds_3_tipadsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1, "TIPADSC") == 0 ) && ( AV64Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_tipoauxiliarwwds_3_tipadsc1)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like '%' + @lV65Contabilidad_tipoauxiliarwwds_3_tipadsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV66Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2, "TIPADSC") == 0 ) && ( AV68Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_tipoauxiliarwwds_7_tipadsc2)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like @lV69Contabilidad_tipoauxiliarwwds_7_tipadsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV66Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2, "TIPADSC") == 0 ) && ( AV68Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_tipoauxiliarwwds_7_tipadsc2)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like '%' + @lV69Contabilidad_tipoauxiliarwwds_7_tipadsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV70Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3, "TIPADSC") == 0 ) && ( AV72Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_tipoauxiliarwwds_11_tipadsc3)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like @lV73Contabilidad_tipoauxiliarwwds_11_tipadsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV70Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3, "TIPADSC") == 0 ) && ( AV72Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_tipoauxiliarwwds_11_tipadsc3)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like '%' + @lV73Contabilidad_tipoauxiliarwwds_11_tipadsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV74Contabilidad_tipoauxiliarwwds_12_tftipacod) )
         {
            AddWhere(sWhereString, "([TipACod] >= @AV74Contabilidad_tipoauxiliarwwds_12_tftipacod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV75Contabilidad_tipoauxiliarwwds_13_tftipacod_to) )
         {
            AddWhere(sWhereString, "([TipACod] <= @AV75Contabilidad_tipoauxiliarwwds_13_tftipacod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_tipoauxiliarwwds_14_tftipadsc)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like @lV76Contabilidad_tipoauxiliarwwds_14_tftipadsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel)) )
         {
            AddWhere(sWhereString, "([TipADsc] = @AV77Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV78Contabilidad_tipoauxiliarwwds_16_tftipasts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Contabilidad_tipoauxiliarwwds_16_tftipasts_sels, "[TipASts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipACod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipACod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipADsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipADsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipASts]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipASts] DESC";
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
                     return conditional_P006M2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP006M2;
          prmP006M2 = new Object[] {
          new ParDef("@lV65Contabilidad_tipoauxiliarwwds_3_tipadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV65Contabilidad_tipoauxiliarwwds_3_tipadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV69Contabilidad_tipoauxiliarwwds_7_tipadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV69Contabilidad_tipoauxiliarwwds_7_tipadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV73Contabilidad_tipoauxiliarwwds_11_tipadsc3",GXType.NChar,100,0) ,
          new ParDef("@lV73Contabilidad_tipoauxiliarwwds_11_tipadsc3",GXType.NChar,100,0) ,
          new ParDef("@AV74Contabilidad_tipoauxiliarwwds_12_tftipacod",GXType.Int32,6,0) ,
          new ParDef("@AV75Contabilidad_tipoauxiliarwwds_13_tftipacod_to",GXType.Int32,6,0) ,
          new ParDef("@lV76Contabilidad_tipoauxiliarwwds_14_tftipadsc",GXType.NChar,100,0) ,
          new ParDef("@AV77Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006M2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
