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
   public class operarioswwexportreport : GXWebProcedure
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

      public operarioswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public operarioswwexportreport( IGxContext context )
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
         operarioswwexportreport objoperarioswwexportreport;
         objoperarioswwexportreport = new operarioswwexportreport();
         objoperarioswwexportreport.context.SetSubmitInitialConfig(context);
         objoperarioswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objoperarioswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((operarioswwexportreport)stateInfo).executePrivate();
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
            AV51Title = "Lista de Operarios";
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
            H670( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "OPEDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15OPEDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15OPEDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterOPEDscDescription = StringUtil.Format( "%1 (%2)", "Operario", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterOPEDscDescription = StringUtil.Format( "%1 (%2)", "Operario", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17OPEDsc = AV15OPEDsc1;
                  H670( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterOPEDscDescription, "")), 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17OPEDsc, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "OPEDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21OPEDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21OPEDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterOPEDscDescription = StringUtil.Format( "%1 (%2)", "Operario", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterOPEDscDescription = StringUtil.Format( "%1 (%2)", "Operario", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17OPEDsc = AV21OPEDsc2;
                     H670( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterOPEDscDescription, "")), 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17OPEDsc, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "OPEDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25OPEDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25OPEDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterOPEDscDescription = StringUtil.Format( "%1 (%2)", "Operario", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterOPEDscDescription = StringUtil.Format( "%1 (%2)", "Operario", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17OPEDsc = AV25OPEDsc3;
                        H670( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterOPEDscDescription, "")), 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17OPEDsc, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFOPECod_Sel)) )
         {
            H670( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Operario", 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFOPECod_Sel, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFOPECod)) )
            {
               H670( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo Operario", 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFOPECod, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFOPEDsc_Sel)) )
         {
            H670( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Operario", 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFOPEDsc_Sel, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFOPEDsc)) )
            {
               H670( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Operario", 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFOPEDsc, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV37TFOPESts_Sels.FromJSonString(AV35TFOPESts_SelsJson, null);
         if ( ! ( AV37TFOPESts_Sels.Count == 0 ) )
         {
            AV40i = 1;
            AV57GXV1 = 1;
            while ( AV57GXV1 <= AV37TFOPESts_Sels.Count )
            {
               AV38TFOPESts_Sel = (short)(AV37TFOPESts_Sels.GetNumeric(AV57GXV1));
               if ( AV40i == 1 )
               {
                  AV36TFOPESts_SelDscs = "";
               }
               else
               {
                  AV36TFOPESts_SelDscs += ", ";
               }
               if ( AV38TFOPESts_Sel == 1 )
               {
                  AV39FilterTFOPESts_SelValueDescription = "ACTIVO";
               }
               else if ( AV38TFOPESts_Sel == 0 )
               {
                  AV39FilterTFOPESts_SelValueDescription = "INACTIVO";
               }
               AV36TFOPESts_SelDscs += AV39FilterTFOPESts_SelValueDescription;
               AV40i = (long)(AV40i+1);
               AV57GXV1 = (int)(AV57GXV1+1);
            }
            H670( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFOPESts_SelDscs, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H670( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H670( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo Operario", 30, Gx_line+10, 279, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Operario", 283, Gx_line+10, 533, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 537, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV59Produccion_operarioswwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV60Produccion_operarioswwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV61Produccion_operarioswwds_3_opedsc1 = AV15OPEDsc1;
         AV62Produccion_operarioswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV63Produccion_operarioswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV64Produccion_operarioswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV65Produccion_operarioswwds_7_opedsc2 = AV21OPEDsc2;
         AV66Produccion_operarioswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Produccion_operarioswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Produccion_operarioswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV69Produccion_operarioswwds_11_opedsc3 = AV25OPEDsc3;
         AV70Produccion_operarioswwds_12_tfopecod = AV31TFOPECod;
         AV71Produccion_operarioswwds_13_tfopecod_sel = AV32TFOPECod_Sel;
         AV72Produccion_operarioswwds_14_tfopedsc = AV33TFOPEDsc;
         AV73Produccion_operarioswwds_15_tfopedsc_sel = AV34TFOPEDsc_Sel;
         AV74Produccion_operarioswwds_16_tfopests_sels = AV37TFOPESts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1423OPESts ,
                                              AV74Produccion_operarioswwds_16_tfopests_sels ,
                                              AV59Produccion_operarioswwds_1_dynamicfiltersselector1 ,
                                              AV60Produccion_operarioswwds_2_dynamicfiltersoperator1 ,
                                              AV61Produccion_operarioswwds_3_opedsc1 ,
                                              AV62Produccion_operarioswwds_4_dynamicfiltersenabled2 ,
                                              AV63Produccion_operarioswwds_5_dynamicfiltersselector2 ,
                                              AV64Produccion_operarioswwds_6_dynamicfiltersoperator2 ,
                                              AV65Produccion_operarioswwds_7_opedsc2 ,
                                              AV66Produccion_operarioswwds_8_dynamicfiltersenabled3 ,
                                              AV67Produccion_operarioswwds_9_dynamicfiltersselector3 ,
                                              AV68Produccion_operarioswwds_10_dynamicfiltersoperator3 ,
                                              AV69Produccion_operarioswwds_11_opedsc3 ,
                                              AV71Produccion_operarioswwds_13_tfopecod_sel ,
                                              AV70Produccion_operarioswwds_12_tfopecod ,
                                              AV73Produccion_operarioswwds_15_tfopedsc_sel ,
                                              AV72Produccion_operarioswwds_14_tfopedsc ,
                                              AV74Produccion_operarioswwds_16_tfopests_sels.Count ,
                                              A1422OPEDsc ,
                                              A321OPECod ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV61Produccion_operarioswwds_3_opedsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Produccion_operarioswwds_3_opedsc1), 100, "%");
         lV61Produccion_operarioswwds_3_opedsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Produccion_operarioswwds_3_opedsc1), 100, "%");
         lV65Produccion_operarioswwds_7_opedsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Produccion_operarioswwds_7_opedsc2), 100, "%");
         lV65Produccion_operarioswwds_7_opedsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Produccion_operarioswwds_7_opedsc2), 100, "%");
         lV69Produccion_operarioswwds_11_opedsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Produccion_operarioswwds_11_opedsc3), 100, "%");
         lV69Produccion_operarioswwds_11_opedsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Produccion_operarioswwds_11_opedsc3), 100, "%");
         lV70Produccion_operarioswwds_12_tfopecod = StringUtil.PadR( StringUtil.RTrim( AV70Produccion_operarioswwds_12_tfopecod), 20, "%");
         lV72Produccion_operarioswwds_14_tfopedsc = StringUtil.PadR( StringUtil.RTrim( AV72Produccion_operarioswwds_14_tfopedsc), 100, "%");
         /* Using cursor P00672 */
         pr_default.execute(0, new Object[] {lV61Produccion_operarioswwds_3_opedsc1, lV61Produccion_operarioswwds_3_opedsc1, lV65Produccion_operarioswwds_7_opedsc2, lV65Produccion_operarioswwds_7_opedsc2, lV69Produccion_operarioswwds_11_opedsc3, lV69Produccion_operarioswwds_11_opedsc3, lV70Produccion_operarioswwds_12_tfopecod, AV71Produccion_operarioswwds_13_tfopecod_sel, lV72Produccion_operarioswwds_14_tfopedsc, AV73Produccion_operarioswwds_15_tfopedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1423OPESts = P00672_A1423OPESts[0];
            A321OPECod = P00672_A321OPECod[0];
            A1422OPEDsc = P00672_A1422OPEDsc[0];
            if ( A1423OPESts == 1 )
            {
               AV12OPEStsDescription = "ACTIVO";
            }
            else if ( A1423OPESts == 0 )
            {
               AV12OPEStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H670( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A321OPECod, "")), 30, Gx_line+10, 279, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1422OPEDsc, "")), 283, Gx_line+10, 533, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12OPEStsDescription, "")), 537, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Produccion.OperariosWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Produccion.OperariosWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Produccion.OperariosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV75GXV2 = 1;
         while ( AV75GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV75GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFOPECOD") == 0 )
            {
               AV31TFOPECod = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFOPECOD_SEL") == 0 )
            {
               AV32TFOPECod_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFOPEDSC") == 0 )
            {
               AV33TFOPEDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFOPEDSC_SEL") == 0 )
            {
               AV34TFOPEDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFOPESTS_SEL") == 0 )
            {
               AV35TFOPESts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV37TFOPESts_Sels.FromJSonString(AV35TFOPESts_SelsJson, null);
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

      protected void H670( bool bFoot ,
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
         AV15OPEDsc1 = "";
         AV16FilterOPEDscDescription = "";
         AV17OPEDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21OPEDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25OPEDsc3 = "";
         AV32TFOPECod_Sel = "";
         AV31TFOPECod = "";
         AV34TFOPEDsc_Sel = "";
         AV33TFOPEDsc = "";
         AV37TFOPESts_Sels = new GxSimpleCollection<short>();
         AV35TFOPESts_SelsJson = "";
         AV36TFOPESts_SelDscs = "";
         AV39FilterTFOPESts_SelValueDescription = "";
         AV59Produccion_operarioswwds_1_dynamicfiltersselector1 = "";
         AV61Produccion_operarioswwds_3_opedsc1 = "";
         AV63Produccion_operarioswwds_5_dynamicfiltersselector2 = "";
         AV65Produccion_operarioswwds_7_opedsc2 = "";
         AV67Produccion_operarioswwds_9_dynamicfiltersselector3 = "";
         AV69Produccion_operarioswwds_11_opedsc3 = "";
         AV70Produccion_operarioswwds_12_tfopecod = "";
         AV71Produccion_operarioswwds_13_tfopecod_sel = "";
         AV72Produccion_operarioswwds_14_tfopedsc = "";
         AV73Produccion_operarioswwds_15_tfopedsc_sel = "";
         AV74Produccion_operarioswwds_16_tfopests_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV61Produccion_operarioswwds_3_opedsc1 = "";
         lV65Produccion_operarioswwds_7_opedsc2 = "";
         lV69Produccion_operarioswwds_11_opedsc3 = "";
         lV70Produccion_operarioswwds_12_tfopecod = "";
         lV72Produccion_operarioswwds_14_tfopedsc = "";
         A1422OPEDsc = "";
         A321OPECod = "";
         P00672_A1423OPESts = new short[1] ;
         P00672_A321OPECod = new string[] {""} ;
         P00672_A1422OPEDsc = new string[] {""} ;
         AV12OPEStsDescription = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.operarioswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00672_A1423OPESts, P00672_A321OPECod, P00672_A1422OPEDsc
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
      private short AV38TFOPESts_Sel ;
      private short AV60Produccion_operarioswwds_2_dynamicfiltersoperator1 ;
      private short AV64Produccion_operarioswwds_6_dynamicfiltersoperator2 ;
      private short AV68Produccion_operarioswwds_10_dynamicfiltersoperator3 ;
      private short A1423OPESts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV57GXV1 ;
      private int AV74Produccion_operarioswwds_16_tfopests_sels_Count ;
      private int AV75GXV2 ;
      private long AV40i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15OPEDsc1 ;
      private string AV17OPEDsc ;
      private string AV21OPEDsc2 ;
      private string AV25OPEDsc3 ;
      private string AV32TFOPECod_Sel ;
      private string AV31TFOPECod ;
      private string AV34TFOPEDsc_Sel ;
      private string AV33TFOPEDsc ;
      private string AV61Produccion_operarioswwds_3_opedsc1 ;
      private string AV65Produccion_operarioswwds_7_opedsc2 ;
      private string AV69Produccion_operarioswwds_11_opedsc3 ;
      private string AV70Produccion_operarioswwds_12_tfopecod ;
      private string AV71Produccion_operarioswwds_13_tfopecod_sel ;
      private string AV72Produccion_operarioswwds_14_tfopedsc ;
      private string AV73Produccion_operarioswwds_15_tfopedsc_sel ;
      private string scmdbuf ;
      private string lV61Produccion_operarioswwds_3_opedsc1 ;
      private string lV65Produccion_operarioswwds_7_opedsc2 ;
      private string lV69Produccion_operarioswwds_11_opedsc3 ;
      private string lV70Produccion_operarioswwds_12_tfopecod ;
      private string lV72Produccion_operarioswwds_14_tfopedsc ;
      private string A1422OPEDsc ;
      private string A321OPECod ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV62Produccion_operarioswwds_4_dynamicfiltersenabled2 ;
      private bool AV66Produccion_operarioswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV35TFOPESts_SelsJson ;
      private string AV51Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterOPEDscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV36TFOPESts_SelDscs ;
      private string AV39FilterTFOPESts_SelValueDescription ;
      private string AV59Produccion_operarioswwds_1_dynamicfiltersselector1 ;
      private string AV63Produccion_operarioswwds_5_dynamicfiltersselector2 ;
      private string AV67Produccion_operarioswwds_9_dynamicfiltersselector3 ;
      private string AV12OPEStsDescription ;
      private string AV49PageInfo ;
      private string AV46DateInfo ;
      private string AV44AppName ;
      private string AV50Phone ;
      private string AV48Mail ;
      private string AV52Website ;
      private string AV41AddressLine1 ;
      private string AV42AddressLine2 ;
      private string AV43AddressLine3 ;
      private GxSimpleCollection<short> AV37TFOPESts_Sels ;
      private GxSimpleCollection<short> AV74Produccion_operarioswwds_16_tfopests_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00672_A1423OPESts ;
      private string[] P00672_A321OPECod ;
      private string[] P00672_A1422OPEDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class operarioswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00672( IGxContext context ,
                                             short A1423OPESts ,
                                             GxSimpleCollection<short> AV74Produccion_operarioswwds_16_tfopests_sels ,
                                             string AV59Produccion_operarioswwds_1_dynamicfiltersselector1 ,
                                             short AV60Produccion_operarioswwds_2_dynamicfiltersoperator1 ,
                                             string AV61Produccion_operarioswwds_3_opedsc1 ,
                                             bool AV62Produccion_operarioswwds_4_dynamicfiltersenabled2 ,
                                             string AV63Produccion_operarioswwds_5_dynamicfiltersselector2 ,
                                             short AV64Produccion_operarioswwds_6_dynamicfiltersoperator2 ,
                                             string AV65Produccion_operarioswwds_7_opedsc2 ,
                                             bool AV66Produccion_operarioswwds_8_dynamicfiltersenabled3 ,
                                             string AV67Produccion_operarioswwds_9_dynamicfiltersselector3 ,
                                             short AV68Produccion_operarioswwds_10_dynamicfiltersoperator3 ,
                                             string AV69Produccion_operarioswwds_11_opedsc3 ,
                                             string AV71Produccion_operarioswwds_13_tfopecod_sel ,
                                             string AV70Produccion_operarioswwds_12_tfopecod ,
                                             string AV73Produccion_operarioswwds_15_tfopedsc_sel ,
                                             string AV72Produccion_operarioswwds_14_tfopedsc ,
                                             int AV74Produccion_operarioswwds_16_tfopests_sels_Count ,
                                             string A1422OPEDsc ,
                                             string A321OPECod ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [OPESts], [OPECod], [OPEDsc] FROM [POOPERARIOS]";
         if ( ( StringUtil.StrCmp(AV59Produccion_operarioswwds_1_dynamicfiltersselector1, "OPEDSC") == 0 ) && ( AV60Produccion_operarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_operarioswwds_3_opedsc1)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV61Produccion_operarioswwds_3_opedsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Produccion_operarioswwds_1_dynamicfiltersselector1, "OPEDSC") == 0 ) && ( AV60Produccion_operarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_operarioswwds_3_opedsc1)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like '%' + @lV61Produccion_operarioswwds_3_opedsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV62Produccion_operarioswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Produccion_operarioswwds_5_dynamicfiltersselector2, "OPEDSC") == 0 ) && ( AV64Produccion_operarioswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Produccion_operarioswwds_7_opedsc2)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV65Produccion_operarioswwds_7_opedsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV62Produccion_operarioswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Produccion_operarioswwds_5_dynamicfiltersselector2, "OPEDSC") == 0 ) && ( AV64Produccion_operarioswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Produccion_operarioswwds_7_opedsc2)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like '%' + @lV65Produccion_operarioswwds_7_opedsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV66Produccion_operarioswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Produccion_operarioswwds_9_dynamicfiltersselector3, "OPEDSC") == 0 ) && ( AV68Produccion_operarioswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Produccion_operarioswwds_11_opedsc3)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV69Produccion_operarioswwds_11_opedsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV66Produccion_operarioswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Produccion_operarioswwds_9_dynamicfiltersselector3, "OPEDSC") == 0 ) && ( AV68Produccion_operarioswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Produccion_operarioswwds_11_opedsc3)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like '%' + @lV69Produccion_operarioswwds_11_opedsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Produccion_operarioswwds_13_tfopecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Produccion_operarioswwds_12_tfopecod)) ) )
         {
            AddWhere(sWhereString, "([OPECod] like @lV70Produccion_operarioswwds_12_tfopecod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Produccion_operarioswwds_13_tfopecod_sel)) )
         {
            AddWhere(sWhereString, "([OPECod] = @AV71Produccion_operarioswwds_13_tfopecod_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Produccion_operarioswwds_15_tfopedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Produccion_operarioswwds_14_tfopedsc)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV72Produccion_operarioswwds_14_tfopedsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Produccion_operarioswwds_15_tfopedsc_sel)) )
         {
            AddWhere(sWhereString, "([OPEDsc] = @AV73Produccion_operarioswwds_15_tfopedsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV74Produccion_operarioswwds_16_tfopests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Produccion_operarioswwds_16_tfopests_sels, "[OPESts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [OPECod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OPECod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [OPEDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OPEDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [OPESts]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OPESts] DESC";
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
                     return conditional_P00672(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP00672;
          prmP00672 = new Object[] {
          new ParDef("@lV61Produccion_operarioswwds_3_opedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Produccion_operarioswwds_3_opedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV65Produccion_operarioswwds_7_opedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Produccion_operarioswwds_7_opedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV69Produccion_operarioswwds_11_opedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Produccion_operarioswwds_11_opedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Produccion_operarioswwds_12_tfopecod",GXType.NChar,20,0) ,
          new ParDef("@AV71Produccion_operarioswwds_13_tfopecod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV72Produccion_operarioswwds_14_tfopedsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Produccion_operarioswwds_15_tfopedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00672", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00672,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
