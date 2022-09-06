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
namespace GeneXus.Programs.produccion {
   public class maquinaswwexportreport : GXWebProcedure
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

      public maquinaswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public maquinaswwexportreport( IGxContext context )
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
         maquinaswwexportreport objmaquinaswwexportreport;
         objmaquinaswwexportreport = new maquinaswwexportreport();
         objmaquinaswwexportreport.context.SetSubmitInitialConfig(context);
         objmaquinaswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmaquinaswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((maquinaswwexportreport)stateInfo).executePrivate();
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
            AV51Title = "Lista de Maquinas";
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
            H640( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "MAQDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15MAQDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15MAQDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterMAQDscDescription = StringUtil.Format( "%1 (%2)", "Maquina", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterMAQDscDescription = StringUtil.Format( "%1 (%2)", "Maquina", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17MAQDsc = AV15MAQDsc1;
                  H640( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterMAQDscDescription, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17MAQDsc, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "MAQDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21MAQDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21MAQDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterMAQDscDescription = StringUtil.Format( "%1 (%2)", "Maquina", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterMAQDscDescription = StringUtil.Format( "%1 (%2)", "Maquina", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17MAQDsc = AV21MAQDsc2;
                     H640( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterMAQDscDescription, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17MAQDsc, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "MAQDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25MAQDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25MAQDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterMAQDscDescription = StringUtil.Format( "%1 (%2)", "Maquina", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterMAQDscDescription = StringUtil.Format( "%1 (%2)", "Maquina", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17MAQDsc = AV25MAQDsc3;
                        H640( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterMAQDscDescription, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17MAQDsc, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFMAQCod_Sel)) )
         {
            H640( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFMAQCod_Sel, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFMAQCod)) )
            {
               H640( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFMAQCod, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFMAQDsc_Sel)) )
         {
            H640( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Maquina", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFMAQDsc_Sel, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFMAQDsc)) )
            {
               H640( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Maquina", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFMAQDsc, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV37TFMAQSts_Sels.FromJSonString(AV35TFMAQSts_SelsJson, null);
         if ( ! ( AV37TFMAQSts_Sels.Count == 0 ) )
         {
            AV40i = 1;
            AV57GXV1 = 1;
            while ( AV57GXV1 <= AV37TFMAQSts_Sels.Count )
            {
               AV38TFMAQSts_Sel = (short)(AV37TFMAQSts_Sels.GetNumeric(AV57GXV1));
               if ( AV40i == 1 )
               {
                  AV36TFMAQSts_SelDscs = "";
               }
               else
               {
                  AV36TFMAQSts_SelDscs += ", ";
               }
               if ( AV38TFMAQSts_Sel == 1 )
               {
                  AV39FilterTFMAQSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV38TFMAQSts_Sel == 0 )
               {
                  AV39FilterTFMAQSts_SelValueDescription = "INACTIVO";
               }
               AV36TFMAQSts_SelDscs += AV39FilterTFMAQSts_SelValueDescription;
               AV40i = (long)(AV40i+1);
               AV57GXV1 = (int)(AV57GXV1+1);
            }
            H640( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFMAQSts_SelDscs, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H640( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H640( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 179, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Maquina", 183, Gx_line+10, 483, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 487, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV59Produccion_maquinaswwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV60Produccion_maquinaswwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV61Produccion_maquinaswwds_3_maqdsc1 = AV15MAQDsc1;
         AV62Produccion_maquinaswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV63Produccion_maquinaswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV64Produccion_maquinaswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV65Produccion_maquinaswwds_7_maqdsc2 = AV21MAQDsc2;
         AV66Produccion_maquinaswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Produccion_maquinaswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Produccion_maquinaswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV69Produccion_maquinaswwds_11_maqdsc3 = AV25MAQDsc3;
         AV70Produccion_maquinaswwds_12_tfmaqcod = AV31TFMAQCod;
         AV71Produccion_maquinaswwds_13_tfmaqcod_sel = AV32TFMAQCod_Sel;
         AV72Produccion_maquinaswwds_14_tfmaqdsc = AV33TFMAQDsc;
         AV73Produccion_maquinaswwds_15_tfmaqdsc_sel = AV34TFMAQDsc_Sel;
         AV74Produccion_maquinaswwds_16_tfmaqsts_sels = AV37TFMAQSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1221MAQSts ,
                                              AV74Produccion_maquinaswwds_16_tfmaqsts_sels ,
                                              AV59Produccion_maquinaswwds_1_dynamicfiltersselector1 ,
                                              AV60Produccion_maquinaswwds_2_dynamicfiltersoperator1 ,
                                              AV61Produccion_maquinaswwds_3_maqdsc1 ,
                                              AV62Produccion_maquinaswwds_4_dynamicfiltersenabled2 ,
                                              AV63Produccion_maquinaswwds_5_dynamicfiltersselector2 ,
                                              AV64Produccion_maquinaswwds_6_dynamicfiltersoperator2 ,
                                              AV65Produccion_maquinaswwds_7_maqdsc2 ,
                                              AV66Produccion_maquinaswwds_8_dynamicfiltersenabled3 ,
                                              AV67Produccion_maquinaswwds_9_dynamicfiltersselector3 ,
                                              AV68Produccion_maquinaswwds_10_dynamicfiltersoperator3 ,
                                              AV69Produccion_maquinaswwds_11_maqdsc3 ,
                                              AV71Produccion_maquinaswwds_13_tfmaqcod_sel ,
                                              AV70Produccion_maquinaswwds_12_tfmaqcod ,
                                              AV73Produccion_maquinaswwds_15_tfmaqdsc_sel ,
                                              AV72Produccion_maquinaswwds_14_tfmaqdsc ,
                                              AV74Produccion_maquinaswwds_16_tfmaqsts_sels.Count ,
                                              A1220MAQDsc ,
                                              A320MAQCod ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV61Produccion_maquinaswwds_3_maqdsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Produccion_maquinaswwds_3_maqdsc1), 100, "%");
         lV61Produccion_maquinaswwds_3_maqdsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Produccion_maquinaswwds_3_maqdsc1), 100, "%");
         lV65Produccion_maquinaswwds_7_maqdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Produccion_maquinaswwds_7_maqdsc2), 100, "%");
         lV65Produccion_maquinaswwds_7_maqdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Produccion_maquinaswwds_7_maqdsc2), 100, "%");
         lV69Produccion_maquinaswwds_11_maqdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Produccion_maquinaswwds_11_maqdsc3), 100, "%");
         lV69Produccion_maquinaswwds_11_maqdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Produccion_maquinaswwds_11_maqdsc3), 100, "%");
         lV70Produccion_maquinaswwds_12_tfmaqcod = StringUtil.PadR( StringUtil.RTrim( AV70Produccion_maquinaswwds_12_tfmaqcod), 10, "%");
         lV72Produccion_maquinaswwds_14_tfmaqdsc = StringUtil.PadR( StringUtil.RTrim( AV72Produccion_maquinaswwds_14_tfmaqdsc), 100, "%");
         /* Using cursor P00642 */
         pr_default.execute(0, new Object[] {lV61Produccion_maquinaswwds_3_maqdsc1, lV61Produccion_maquinaswwds_3_maqdsc1, lV65Produccion_maquinaswwds_7_maqdsc2, lV65Produccion_maquinaswwds_7_maqdsc2, lV69Produccion_maquinaswwds_11_maqdsc3, lV69Produccion_maquinaswwds_11_maqdsc3, lV70Produccion_maquinaswwds_12_tfmaqcod, AV71Produccion_maquinaswwds_13_tfmaqcod_sel, lV72Produccion_maquinaswwds_14_tfmaqdsc, AV73Produccion_maquinaswwds_15_tfmaqdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1221MAQSts = P00642_A1221MAQSts[0];
            A320MAQCod = P00642_A320MAQCod[0];
            A1220MAQDsc = P00642_A1220MAQDsc[0];
            if ( A1221MAQSts == 1 )
            {
               AV12MAQStsDescription = "ACTIVO";
            }
            else if ( A1221MAQSts == 0 )
            {
               AV12MAQStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H640( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A320MAQCod, "")), 30, Gx_line+10, 179, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1220MAQDsc, "")), 183, Gx_line+10, 483, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12MAQStsDescription, "")), 487, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Produccion.MaquinasWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Produccion.MaquinasWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Produccion.MaquinasWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV75GXV2 = 1;
         while ( AV75GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV75GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFMAQCOD") == 0 )
            {
               AV31TFMAQCod = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFMAQCOD_SEL") == 0 )
            {
               AV32TFMAQCod_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFMAQDSC") == 0 )
            {
               AV33TFMAQDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFMAQDSC_SEL") == 0 )
            {
               AV34TFMAQDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFMAQSTS_SEL") == 0 )
            {
               AV35TFMAQSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV37TFMAQSts_Sels.FromJSonString(AV35TFMAQSts_SelsJson, null);
            }
            AV75GXV2 = (int)(AV75GXV2+1);
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

      protected void H640( bool bFoot ,
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
                  AV49PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV46DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV44AppName = "DVelop Software Solutions";
               AV50Phone = "+1 550 8923";
               AV48Mail = "info@mail.com";
               AV52Website = "http://www.web.com";
               AV41AddressLine1 = "French Boulevard 2859";
               AV42AddressLine2 = "Downtown";
               AV43AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV51Title = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15MAQDsc1 = "";
         AV16FilterMAQDscDescription = "";
         AV17MAQDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21MAQDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25MAQDsc3 = "";
         AV32TFMAQCod_Sel = "";
         AV31TFMAQCod = "";
         AV34TFMAQDsc_Sel = "";
         AV33TFMAQDsc = "";
         AV37TFMAQSts_Sels = new GxSimpleCollection<short>();
         AV35TFMAQSts_SelsJson = "";
         AV36TFMAQSts_SelDscs = "";
         AV39FilterTFMAQSts_SelValueDescription = "";
         AV59Produccion_maquinaswwds_1_dynamicfiltersselector1 = "";
         AV61Produccion_maquinaswwds_3_maqdsc1 = "";
         AV63Produccion_maquinaswwds_5_dynamicfiltersselector2 = "";
         AV65Produccion_maquinaswwds_7_maqdsc2 = "";
         AV67Produccion_maquinaswwds_9_dynamicfiltersselector3 = "";
         AV69Produccion_maquinaswwds_11_maqdsc3 = "";
         AV70Produccion_maquinaswwds_12_tfmaqcod = "";
         AV71Produccion_maquinaswwds_13_tfmaqcod_sel = "";
         AV72Produccion_maquinaswwds_14_tfmaqdsc = "";
         AV73Produccion_maquinaswwds_15_tfmaqdsc_sel = "";
         AV74Produccion_maquinaswwds_16_tfmaqsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV61Produccion_maquinaswwds_3_maqdsc1 = "";
         lV65Produccion_maquinaswwds_7_maqdsc2 = "";
         lV69Produccion_maquinaswwds_11_maqdsc3 = "";
         lV70Produccion_maquinaswwds_12_tfmaqcod = "";
         lV72Produccion_maquinaswwds_14_tfmaqdsc = "";
         A1220MAQDsc = "";
         A320MAQCod = "";
         P00642_A1221MAQSts = new short[1] ;
         P00642_A320MAQCod = new string[] {""} ;
         P00642_A1220MAQDsc = new string[] {""} ;
         AV12MAQStsDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV49PageInfo = "";
         AV46DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV44AppName = "";
         AV50Phone = "";
         AV48Mail = "";
         AV52Website = "";
         AV41AddressLine1 = "";
         AV42AddressLine2 = "";
         AV43AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.maquinaswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00642_A1221MAQSts, P00642_A320MAQCod, P00642_A1220MAQDsc
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
      private short AV38TFMAQSts_Sel ;
      private short AV60Produccion_maquinaswwds_2_dynamicfiltersoperator1 ;
      private short AV64Produccion_maquinaswwds_6_dynamicfiltersoperator2 ;
      private short AV68Produccion_maquinaswwds_10_dynamicfiltersoperator3 ;
      private short A1221MAQSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV57GXV1 ;
      private int AV74Produccion_maquinaswwds_16_tfmaqsts_sels_Count ;
      private int AV75GXV2 ;
      private long AV40i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15MAQDsc1 ;
      private string AV17MAQDsc ;
      private string AV21MAQDsc2 ;
      private string AV25MAQDsc3 ;
      private string AV32TFMAQCod_Sel ;
      private string AV31TFMAQCod ;
      private string AV34TFMAQDsc_Sel ;
      private string AV33TFMAQDsc ;
      private string AV61Produccion_maquinaswwds_3_maqdsc1 ;
      private string AV65Produccion_maquinaswwds_7_maqdsc2 ;
      private string AV69Produccion_maquinaswwds_11_maqdsc3 ;
      private string AV70Produccion_maquinaswwds_12_tfmaqcod ;
      private string AV71Produccion_maquinaswwds_13_tfmaqcod_sel ;
      private string AV72Produccion_maquinaswwds_14_tfmaqdsc ;
      private string AV73Produccion_maquinaswwds_15_tfmaqdsc_sel ;
      private string scmdbuf ;
      private string lV61Produccion_maquinaswwds_3_maqdsc1 ;
      private string lV65Produccion_maquinaswwds_7_maqdsc2 ;
      private string lV69Produccion_maquinaswwds_11_maqdsc3 ;
      private string lV70Produccion_maquinaswwds_12_tfmaqcod ;
      private string lV72Produccion_maquinaswwds_14_tfmaqdsc ;
      private string A1220MAQDsc ;
      private string A320MAQCod ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV62Produccion_maquinaswwds_4_dynamicfiltersenabled2 ;
      private bool AV66Produccion_maquinaswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV35TFMAQSts_SelsJson ;
      private string AV51Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterMAQDscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV36TFMAQSts_SelDscs ;
      private string AV39FilterTFMAQSts_SelValueDescription ;
      private string AV59Produccion_maquinaswwds_1_dynamicfiltersselector1 ;
      private string AV63Produccion_maquinaswwds_5_dynamicfiltersselector2 ;
      private string AV67Produccion_maquinaswwds_9_dynamicfiltersselector3 ;
      private string AV12MAQStsDescription ;
      private string AV49PageInfo ;
      private string AV46DateInfo ;
      private string AV44AppName ;
      private string AV50Phone ;
      private string AV48Mail ;
      private string AV52Website ;
      private string AV41AddressLine1 ;
      private string AV42AddressLine2 ;
      private string AV43AddressLine3 ;
      private GxSimpleCollection<short> AV37TFMAQSts_Sels ;
      private GxSimpleCollection<short> AV74Produccion_maquinaswwds_16_tfmaqsts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00642_A1221MAQSts ;
      private string[] P00642_A320MAQCod ;
      private string[] P00642_A1220MAQDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class maquinaswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00642( IGxContext context ,
                                             short A1221MAQSts ,
                                             GxSimpleCollection<short> AV74Produccion_maquinaswwds_16_tfmaqsts_sels ,
                                             string AV59Produccion_maquinaswwds_1_dynamicfiltersselector1 ,
                                             short AV60Produccion_maquinaswwds_2_dynamicfiltersoperator1 ,
                                             string AV61Produccion_maquinaswwds_3_maqdsc1 ,
                                             bool AV62Produccion_maquinaswwds_4_dynamicfiltersenabled2 ,
                                             string AV63Produccion_maquinaswwds_5_dynamicfiltersselector2 ,
                                             short AV64Produccion_maquinaswwds_6_dynamicfiltersoperator2 ,
                                             string AV65Produccion_maquinaswwds_7_maqdsc2 ,
                                             bool AV66Produccion_maquinaswwds_8_dynamicfiltersenabled3 ,
                                             string AV67Produccion_maquinaswwds_9_dynamicfiltersselector3 ,
                                             short AV68Produccion_maquinaswwds_10_dynamicfiltersoperator3 ,
                                             string AV69Produccion_maquinaswwds_11_maqdsc3 ,
                                             string AV71Produccion_maquinaswwds_13_tfmaqcod_sel ,
                                             string AV70Produccion_maquinaswwds_12_tfmaqcod ,
                                             string AV73Produccion_maquinaswwds_15_tfmaqdsc_sel ,
                                             string AV72Produccion_maquinaswwds_14_tfmaqdsc ,
                                             int AV74Produccion_maquinaswwds_16_tfmaqsts_sels_Count ,
                                             string A1220MAQDsc ,
                                             string A320MAQCod ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [MAQSts], [MAQCod], [MAQDsc] FROM [POMAQUINA]";
         if ( ( StringUtil.StrCmp(AV59Produccion_maquinaswwds_1_dynamicfiltersselector1, "MAQDSC") == 0 ) && ( AV60Produccion_maquinaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_maquinaswwds_3_maqdsc1)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV61Produccion_maquinaswwds_3_maqdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Produccion_maquinaswwds_1_dynamicfiltersselector1, "MAQDSC") == 0 ) && ( AV60Produccion_maquinaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_maquinaswwds_3_maqdsc1)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like '%' + @lV61Produccion_maquinaswwds_3_maqdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV62Produccion_maquinaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Produccion_maquinaswwds_5_dynamicfiltersselector2, "MAQDSC") == 0 ) && ( AV64Produccion_maquinaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Produccion_maquinaswwds_7_maqdsc2)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV65Produccion_maquinaswwds_7_maqdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV62Produccion_maquinaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Produccion_maquinaswwds_5_dynamicfiltersselector2, "MAQDSC") == 0 ) && ( AV64Produccion_maquinaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Produccion_maquinaswwds_7_maqdsc2)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like '%' + @lV65Produccion_maquinaswwds_7_maqdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV66Produccion_maquinaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Produccion_maquinaswwds_9_dynamicfiltersselector3, "MAQDSC") == 0 ) && ( AV68Produccion_maquinaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Produccion_maquinaswwds_11_maqdsc3)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV69Produccion_maquinaswwds_11_maqdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV66Produccion_maquinaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Produccion_maquinaswwds_9_dynamicfiltersselector3, "MAQDSC") == 0 ) && ( AV68Produccion_maquinaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Produccion_maquinaswwds_11_maqdsc3)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like '%' + @lV69Produccion_maquinaswwds_11_maqdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Produccion_maquinaswwds_13_tfmaqcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Produccion_maquinaswwds_12_tfmaqcod)) ) )
         {
            AddWhere(sWhereString, "([MAQCod] like @lV70Produccion_maquinaswwds_12_tfmaqcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Produccion_maquinaswwds_13_tfmaqcod_sel)) )
         {
            AddWhere(sWhereString, "([MAQCod] = @AV71Produccion_maquinaswwds_13_tfmaqcod_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Produccion_maquinaswwds_15_tfmaqdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Produccion_maquinaswwds_14_tfmaqdsc)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV72Produccion_maquinaswwds_14_tfmaqdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Produccion_maquinaswwds_15_tfmaqdsc_sel)) )
         {
            AddWhere(sWhereString, "([MAQDsc] = @AV73Produccion_maquinaswwds_15_tfmaqdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV74Produccion_maquinaswwds_16_tfmaqsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Produccion_maquinaswwds_16_tfmaqsts_sels, "[MAQSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MAQCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MAQCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MAQDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MAQDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MAQSts]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MAQSts] DESC";
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
                     return conditional_P00642(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP00642;
          prmP00642 = new Object[] {
          new ParDef("@lV61Produccion_maquinaswwds_3_maqdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Produccion_maquinaswwds_3_maqdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV65Produccion_maquinaswwds_7_maqdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Produccion_maquinaswwds_7_maqdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV69Produccion_maquinaswwds_11_maqdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Produccion_maquinaswwds_11_maqdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Produccion_maquinaswwds_12_tfmaqcod",GXType.NChar,10,0) ,
          new ParDef("@AV71Produccion_maquinaswwds_13_tfmaqcod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV72Produccion_maquinaswwds_14_tfmaqdsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Produccion_maquinaswwds_15_tfmaqdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00642", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00642,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
