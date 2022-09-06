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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.contabilidad {
   public class conceptocompraswwgetfilterdata : GXProcedure
   {
      public conceptocompraswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptocompraswwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxt ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV22DDOName = aP0_DDOName;
         this.AV20SearchTxt = aP1_SearchTxt;
         this.AV21SearchTxtTo = aP2_SearchTxtTo;
         this.AV26OptionsJson = "" ;
         this.AV29OptionsDescJson = "" ;
         this.AV31OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV31OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         conceptocompraswwgetfilterdata objconceptocompraswwgetfilterdata;
         objconceptocompraswwgetfilterdata = new conceptocompraswwgetfilterdata();
         objconceptocompraswwgetfilterdata.AV22DDOName = aP0_DDOName;
         objconceptocompraswwgetfilterdata.AV20SearchTxt = aP1_SearchTxt;
         objconceptocompraswwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objconceptocompraswwgetfilterdata.AV26OptionsJson = "" ;
         objconceptocompraswwgetfilterdata.AV29OptionsDescJson = "" ;
         objconceptocompraswwgetfilterdata.AV31OptionIndexesJson = "" ;
         objconceptocompraswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objconceptocompraswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptocompraswwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptocompraswwgetfilterdata)stateInfo).executePrivate();
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
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_CCONPDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCCONPDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_CCONPCUECOD") == 0 )
         {
            /* Execute user subroutine: 'LOADCCONPCUECODOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV26OptionsJson = AV25Options.ToJSonString(false);
         AV29OptionsDescJson = AV28OptionsDesc.ToJSonString(false);
         AV31OptionIndexesJson = AV30OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get("Contabilidad.ConceptoComprasWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.ConceptoComprasWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Contabilidad.ConceptoComprasWWGridState"), null, "", "");
         }
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCCONPCOD") == 0 )
            {
               AV10TFCConpCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV11TFCConpCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCCONPDSC") == 0 )
            {
               AV12TFCConpDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCCONPDSC_SEL") == 0 )
            {
               AV13TFCConpDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCCONPCUECOD") == 0 )
            {
               AV14TFCConpCueCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCCONPCUECOD_SEL") == 0 )
            {
               AV15TFCConpCueCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCCONPSTS_SEL") == 0 )
            {
               AV52TFCConpSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV53TFCConpSts_Sels.FromJSonString(AV52TFCConpSts_SelsJson, null);
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "CCONPDSC") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV40CConpDsc1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "CCONPCUECOD") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV54CConpCueCod1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV42DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV43DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV43DynamicFiltersSelector2, "CCONPDSC") == 0 )
               {
                  AV44DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV45CConpDsc2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV43DynamicFiltersSelector2, "CCONPCUECOD") == 0 )
               {
                  AV44DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV55CConpCueCod2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "CCONPDSC") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV50CConpDsc3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "CCONPCUECOD") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV56CConpCueCod3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCCONPDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFCConpDsc = AV20SearchTxt;
         AV13TFCConpDsc_Sel = "";
         AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV63Contabilidad_conceptocompraswwds_3_cconpdsc1 = AV40CConpDsc1;
         AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 = AV54CConpCueCod1;
         AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV68Contabilidad_conceptocompraswwds_8_cconpdsc2 = AV45CConpDsc2;
         AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 = AV55CConpCueCod2;
         AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV73Contabilidad_conceptocompraswwds_13_cconpdsc3 = AV50CConpDsc3;
         AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 = AV56CConpCueCod3;
         AV75Contabilidad_conceptocompraswwds_15_tfcconpcod = AV10TFCConpCod;
         AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to = AV11TFCConpCod_To;
         AV77Contabilidad_conceptocompraswwds_17_tfcconpdsc = AV12TFCConpDsc;
         AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel = AV13TFCConpDsc_Sel;
         AV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod = AV14TFCConpCueCod;
         AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel = AV15TFCConpCueCod_Sel;
         AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels = AV53TFCConpSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A517CConpSts ,
                                              AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels ,
                                              AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 ,
                                              AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 ,
                                              AV63Contabilidad_conceptocompraswwds_3_cconpdsc1 ,
                                              AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 ,
                                              AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 ,
                                              AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 ,
                                              AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 ,
                                              AV68Contabilidad_conceptocompraswwds_8_cconpdsc2 ,
                                              AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 ,
                                              AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 ,
                                              AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 ,
                                              AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 ,
                                              AV73Contabilidad_conceptocompraswwds_13_cconpdsc3 ,
                                              AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 ,
                                              AV75Contabilidad_conceptocompraswwds_15_tfcconpcod ,
                                              AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to ,
                                              AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel ,
                                              AV77Contabilidad_conceptocompraswwds_17_tfcconpdsc ,
                                              AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel ,
                                              AV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod ,
                                              AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels.Count ,
                                              A78CConpDsc ,
                                              A77CConpCueCod ,
                                              A76CConpCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV63Contabilidad_conceptocompraswwds_3_cconpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_conceptocompraswwds_3_cconpdsc1), 100, "%");
         lV63Contabilidad_conceptocompraswwds_3_cconpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_conceptocompraswwds_3_cconpdsc1), 100, "%");
         lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1), 15, "%");
         lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1), 15, "%");
         lV68Contabilidad_conceptocompraswwds_8_cconpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_conceptocompraswwds_8_cconpdsc2), 100, "%");
         lV68Contabilidad_conceptocompraswwds_8_cconpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_conceptocompraswwds_8_cconpdsc2), 100, "%");
         lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2), 15, "%");
         lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2), 15, "%");
         lV73Contabilidad_conceptocompraswwds_13_cconpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Contabilidad_conceptocompraswwds_13_cconpdsc3), 100, "%");
         lV73Contabilidad_conceptocompraswwds_13_cconpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Contabilidad_conceptocompraswwds_13_cconpdsc3), 100, "%");
         lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3), 15, "%");
         lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3), 15, "%");
         lV77Contabilidad_conceptocompraswwds_17_tfcconpdsc = StringUtil.PadR( StringUtil.RTrim( AV77Contabilidad_conceptocompraswwds_17_tfcconpdsc), 100, "%");
         lV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod = StringUtil.PadR( StringUtil.RTrim( AV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod), 15, "%");
         /* Using cursor P006V2 */
         pr_default.execute(0, new Object[] {lV63Contabilidad_conceptocompraswwds_3_cconpdsc1, lV63Contabilidad_conceptocompraswwds_3_cconpdsc1, lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1, lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1, lV68Contabilidad_conceptocompraswwds_8_cconpdsc2, lV68Contabilidad_conceptocompraswwds_8_cconpdsc2, lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2, lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2, lV73Contabilidad_conceptocompraswwds_13_cconpdsc3, lV73Contabilidad_conceptocompraswwds_13_cconpdsc3, lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3, lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3, AV75Contabilidad_conceptocompraswwds_15_tfcconpcod, AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to, lV77Contabilidad_conceptocompraswwds_17_tfcconpdsc, AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel, lV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod, AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6V2 = false;
            A78CConpDsc = P006V2_A78CConpDsc[0];
            A517CConpSts = P006V2_A517CConpSts[0];
            A76CConpCod = P006V2_A76CConpCod[0];
            A77CConpCueCod = P006V2_A77CConpCueCod[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006V2_A78CConpDsc[0], A78CConpDsc) == 0 ) )
            {
               BRK6V2 = false;
               A76CConpCod = P006V2_A76CConpCod[0];
               AV32count = (long)(AV32count+1);
               BRK6V2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A78CConpDsc)) )
            {
               AV24Option = A78CConpDsc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6V2 )
            {
               BRK6V2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCCONPCUECODOPTIONS' Routine */
         returnInSub = false;
         AV14TFCConpCueCod = AV20SearchTxt;
         AV15TFCConpCueCod_Sel = "";
         AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV63Contabilidad_conceptocompraswwds_3_cconpdsc1 = AV40CConpDsc1;
         AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 = AV54CConpCueCod1;
         AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV68Contabilidad_conceptocompraswwds_8_cconpdsc2 = AV45CConpDsc2;
         AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 = AV55CConpCueCod2;
         AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV73Contabilidad_conceptocompraswwds_13_cconpdsc3 = AV50CConpDsc3;
         AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 = AV56CConpCueCod3;
         AV75Contabilidad_conceptocompraswwds_15_tfcconpcod = AV10TFCConpCod;
         AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to = AV11TFCConpCod_To;
         AV77Contabilidad_conceptocompraswwds_17_tfcconpdsc = AV12TFCConpDsc;
         AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel = AV13TFCConpDsc_Sel;
         AV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod = AV14TFCConpCueCod;
         AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel = AV15TFCConpCueCod_Sel;
         AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels = AV53TFCConpSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A517CConpSts ,
                                              AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels ,
                                              AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 ,
                                              AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 ,
                                              AV63Contabilidad_conceptocompraswwds_3_cconpdsc1 ,
                                              AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 ,
                                              AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 ,
                                              AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 ,
                                              AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 ,
                                              AV68Contabilidad_conceptocompraswwds_8_cconpdsc2 ,
                                              AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 ,
                                              AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 ,
                                              AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 ,
                                              AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 ,
                                              AV73Contabilidad_conceptocompraswwds_13_cconpdsc3 ,
                                              AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 ,
                                              AV75Contabilidad_conceptocompraswwds_15_tfcconpcod ,
                                              AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to ,
                                              AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel ,
                                              AV77Contabilidad_conceptocompraswwds_17_tfcconpdsc ,
                                              AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel ,
                                              AV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod ,
                                              AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels.Count ,
                                              A78CConpDsc ,
                                              A77CConpCueCod ,
                                              A76CConpCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV63Contabilidad_conceptocompraswwds_3_cconpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_conceptocompraswwds_3_cconpdsc1), 100, "%");
         lV63Contabilidad_conceptocompraswwds_3_cconpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_conceptocompraswwds_3_cconpdsc1), 100, "%");
         lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1), 15, "%");
         lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1), 15, "%");
         lV68Contabilidad_conceptocompraswwds_8_cconpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_conceptocompraswwds_8_cconpdsc2), 100, "%");
         lV68Contabilidad_conceptocompraswwds_8_cconpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_conceptocompraswwds_8_cconpdsc2), 100, "%");
         lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2), 15, "%");
         lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2), 15, "%");
         lV73Contabilidad_conceptocompraswwds_13_cconpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Contabilidad_conceptocompraswwds_13_cconpdsc3), 100, "%");
         lV73Contabilidad_conceptocompraswwds_13_cconpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Contabilidad_conceptocompraswwds_13_cconpdsc3), 100, "%");
         lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3), 15, "%");
         lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3), 15, "%");
         lV77Contabilidad_conceptocompraswwds_17_tfcconpdsc = StringUtil.PadR( StringUtil.RTrim( AV77Contabilidad_conceptocompraswwds_17_tfcconpdsc), 100, "%");
         lV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod = StringUtil.PadR( StringUtil.RTrim( AV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod), 15, "%");
         /* Using cursor P006V3 */
         pr_default.execute(1, new Object[] {lV63Contabilidad_conceptocompraswwds_3_cconpdsc1, lV63Contabilidad_conceptocompraswwds_3_cconpdsc1, lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1, lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1, lV68Contabilidad_conceptocompraswwds_8_cconpdsc2, lV68Contabilidad_conceptocompraswwds_8_cconpdsc2, lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2, lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2, lV73Contabilidad_conceptocompraswwds_13_cconpdsc3, lV73Contabilidad_conceptocompraswwds_13_cconpdsc3, lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3, lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3, AV75Contabilidad_conceptocompraswwds_15_tfcconpcod, AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to, lV77Contabilidad_conceptocompraswwds_17_tfcconpdsc, AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel, lV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod, AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6V4 = false;
            A77CConpCueCod = P006V3_A77CConpCueCod[0];
            A517CConpSts = P006V3_A517CConpSts[0];
            A76CConpCod = P006V3_A76CConpCod[0];
            A78CConpDsc = P006V3_A78CConpDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006V3_A77CConpCueCod[0], A77CConpCueCod) == 0 ) )
            {
               BRK6V4 = false;
               A76CConpCod = P006V3_A76CConpCod[0];
               AV32count = (long)(AV32count+1);
               BRK6V4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A77CConpCueCod)) )
            {
               AV24Option = A77CConpCueCod;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6V4 )
            {
               BRK6V4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
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
         AV26OptionsJson = "";
         AV29OptionsDescJson = "";
         AV31OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV28OptionsDesc = new GxSimpleCollection<string>();
         AV30OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV33Session = context.GetSession();
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV12TFCConpDsc = "";
         AV13TFCConpDsc_Sel = "";
         AV14TFCConpCueCod = "";
         AV15TFCConpCueCod_Sel = "";
         AV52TFCConpSts_SelsJson = "";
         AV53TFCConpSts_Sels = new GxSimpleCollection<short>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40CConpDsc1 = "";
         AV54CConpCueCod1 = "";
         AV43DynamicFiltersSelector2 = "";
         AV45CConpDsc2 = "";
         AV55CConpCueCod2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV50CConpDsc3 = "";
         AV56CConpCueCod3 = "";
         AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 = "";
         AV63Contabilidad_conceptocompraswwds_3_cconpdsc1 = "";
         AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 = "";
         AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 = "";
         AV68Contabilidad_conceptocompraswwds_8_cconpdsc2 = "";
         AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 = "";
         AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 = "";
         AV73Contabilidad_conceptocompraswwds_13_cconpdsc3 = "";
         AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 = "";
         AV77Contabilidad_conceptocompraswwds_17_tfcconpdsc = "";
         AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel = "";
         AV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod = "";
         AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel = "";
         AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV63Contabilidad_conceptocompraswwds_3_cconpdsc1 = "";
         lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 = "";
         lV68Contabilidad_conceptocompraswwds_8_cconpdsc2 = "";
         lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 = "";
         lV73Contabilidad_conceptocompraswwds_13_cconpdsc3 = "";
         lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 = "";
         lV77Contabilidad_conceptocompraswwds_17_tfcconpdsc = "";
         lV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod = "";
         A78CConpDsc = "";
         A77CConpCueCod = "";
         P006V2_A78CConpDsc = new string[] {""} ;
         P006V2_A517CConpSts = new short[1] ;
         P006V2_A76CConpCod = new int[1] ;
         P006V2_A77CConpCueCod = new string[] {""} ;
         AV24Option = "";
         P006V3_A77CConpCueCod = new string[] {""} ;
         P006V3_A517CConpSts = new short[1] ;
         P006V3_A76CConpCod = new int[1] ;
         P006V3_A78CConpDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.conceptocompraswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006V2_A78CConpDsc, P006V2_A517CConpSts, P006V2_A76CConpCod, P006V2_A77CConpCueCod
               }
               , new Object[] {
               P006V3_A77CConpCueCod, P006V3_A517CConpSts, P006V3_A76CConpCod, P006V3_A78CConpDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV39DynamicFiltersOperator1 ;
      private short AV44DynamicFiltersOperator2 ;
      private short AV49DynamicFiltersOperator3 ;
      private short AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 ;
      private short AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 ;
      private short AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 ;
      private short A517CConpSts ;
      private int AV59GXV1 ;
      private int AV10TFCConpCod ;
      private int AV11TFCConpCod_To ;
      private int AV75Contabilidad_conceptocompraswwds_15_tfcconpcod ;
      private int AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to ;
      private int AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels_Count ;
      private int A76CConpCod ;
      private long AV32count ;
      private string AV12TFCConpDsc ;
      private string AV13TFCConpDsc_Sel ;
      private string AV14TFCConpCueCod ;
      private string AV15TFCConpCueCod_Sel ;
      private string AV40CConpDsc1 ;
      private string AV54CConpCueCod1 ;
      private string AV45CConpDsc2 ;
      private string AV55CConpCueCod2 ;
      private string AV50CConpDsc3 ;
      private string AV56CConpCueCod3 ;
      private string AV63Contabilidad_conceptocompraswwds_3_cconpdsc1 ;
      private string AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 ;
      private string AV68Contabilidad_conceptocompraswwds_8_cconpdsc2 ;
      private string AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 ;
      private string AV73Contabilidad_conceptocompraswwds_13_cconpdsc3 ;
      private string AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 ;
      private string AV77Contabilidad_conceptocompraswwds_17_tfcconpdsc ;
      private string AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel ;
      private string AV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod ;
      private string AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel ;
      private string scmdbuf ;
      private string lV63Contabilidad_conceptocompraswwds_3_cconpdsc1 ;
      private string lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 ;
      private string lV68Contabilidad_conceptocompraswwds_8_cconpdsc2 ;
      private string lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 ;
      private string lV73Contabilidad_conceptocompraswwds_13_cconpdsc3 ;
      private string lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 ;
      private string lV77Contabilidad_conceptocompraswwds_17_tfcconpdsc ;
      private string lV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod ;
      private string A78CConpDsc ;
      private string A77CConpCueCod ;
      private bool returnInSub ;
      private bool AV42DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 ;
      private bool AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 ;
      private bool BRK6V2 ;
      private bool BRK6V4 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV52TFCConpSts_SelsJson ;
      private string AV22DDOName ;
      private string AV20SearchTxt ;
      private string AV21SearchTxtTo ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV43DynamicFiltersSelector2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 ;
      private string AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 ;
      private string AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 ;
      private string AV24Option ;
      private GxSimpleCollection<short> AV53TFCConpSts_Sels ;
      private GxSimpleCollection<short> AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006V2_A78CConpDsc ;
      private short[] P006V2_A517CConpSts ;
      private int[] P006V2_A76CConpCod ;
      private string[] P006V2_A77CConpCueCod ;
      private string[] P006V3_A77CConpCueCod ;
      private short[] P006V3_A517CConpSts ;
      private int[] P006V3_A76CConpCod ;
      private string[] P006V3_A78CConpDsc ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV28OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV37GridStateDynamicFilter ;
   }

   public class conceptocompraswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006V2( IGxContext context ,
                                             short A517CConpSts ,
                                             GxSimpleCollection<short> AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels ,
                                             string AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 ,
                                             short AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 ,
                                             string AV63Contabilidad_conceptocompraswwds_3_cconpdsc1 ,
                                             string AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 ,
                                             bool AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 ,
                                             string AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 ,
                                             short AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 ,
                                             string AV68Contabilidad_conceptocompraswwds_8_cconpdsc2 ,
                                             string AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 ,
                                             bool AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 ,
                                             string AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 ,
                                             short AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 ,
                                             string AV73Contabilidad_conceptocompraswwds_13_cconpdsc3 ,
                                             string AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 ,
                                             int AV75Contabilidad_conceptocompraswwds_15_tfcconpcod ,
                                             int AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to ,
                                             string AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel ,
                                             string AV77Contabilidad_conceptocompraswwds_17_tfcconpdsc ,
                                             string AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel ,
                                             string AV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod ,
                                             int AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels_Count ,
                                             string A78CConpDsc ,
                                             string A77CConpCueCod ,
                                             int A76CConpCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[18];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CConpDsc], [CConpSts], [CConpCod], [CConpCueCod] FROM [CBCOMPRASCONC]";
         if ( ( StringUtil.StrCmp(AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPDSC") == 0 ) && ( AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_conceptocompraswwds_3_cconpdsc1)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV63Contabilidad_conceptocompraswwds_3_cconpdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPDSC") == 0 ) && ( AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_conceptocompraswwds_3_cconpdsc1)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like '%' + @lV63Contabilidad_conceptocompraswwds_3_cconpdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPCUECOD") == 0 ) && ( AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPCUECOD") == 0 ) && ( AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like '%' + @lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPDSC") == 0 ) && ( AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_conceptocompraswwds_8_cconpdsc2)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV68Contabilidad_conceptocompraswwds_8_cconpdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPDSC") == 0 ) && ( AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_conceptocompraswwds_8_cconpdsc2)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like '%' + @lV68Contabilidad_conceptocompraswwds_8_cconpdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPCUECOD") == 0 ) && ( AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPCUECOD") == 0 ) && ( AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like '%' + @lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPDSC") == 0 ) && ( AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_conceptocompraswwds_13_cconpdsc3)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV73Contabilidad_conceptocompraswwds_13_cconpdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPDSC") == 0 ) && ( AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_conceptocompraswwds_13_cconpdsc3)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like '%' + @lV73Contabilidad_conceptocompraswwds_13_cconpdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPCUECOD") == 0 ) && ( AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPCUECOD") == 0 ) && ( AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like '%' + @lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV75Contabilidad_conceptocompraswwds_15_tfcconpcod) )
         {
            AddWhere(sWhereString, "([CConpCod] >= @AV75Contabilidad_conceptocompraswwds_15_tfcconpcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to) )
         {
            AddWhere(sWhereString, "([CConpCod] <= @AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_conceptocompraswwds_17_tfcconpdsc)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV77Contabilidad_conceptocompraswwds_17_tfcconpdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel)) )
         {
            AddWhere(sWhereString, "([CConpDsc] = @AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel)) )
         {
            AddWhere(sWhereString, "([CConpCueCod] = @AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels, "[CConpSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CConpDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006V3( IGxContext context ,
                                             short A517CConpSts ,
                                             GxSimpleCollection<short> AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels ,
                                             string AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 ,
                                             short AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 ,
                                             string AV63Contabilidad_conceptocompraswwds_3_cconpdsc1 ,
                                             string AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1 ,
                                             bool AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 ,
                                             string AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 ,
                                             short AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 ,
                                             string AV68Contabilidad_conceptocompraswwds_8_cconpdsc2 ,
                                             string AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2 ,
                                             bool AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 ,
                                             string AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 ,
                                             short AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 ,
                                             string AV73Contabilidad_conceptocompraswwds_13_cconpdsc3 ,
                                             string AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3 ,
                                             int AV75Contabilidad_conceptocompraswwds_15_tfcconpcod ,
                                             int AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to ,
                                             string AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel ,
                                             string AV77Contabilidad_conceptocompraswwds_17_tfcconpdsc ,
                                             string AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel ,
                                             string AV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod ,
                                             int AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels_Count ,
                                             string A78CConpDsc ,
                                             string A77CConpCueCod ,
                                             int A76CConpCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [CConpCueCod], [CConpSts], [CConpCod], [CConpDsc] FROM [CBCOMPRASCONC]";
         if ( ( StringUtil.StrCmp(AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPDSC") == 0 ) && ( AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_conceptocompraswwds_3_cconpdsc1)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV63Contabilidad_conceptocompraswwds_3_cconpdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPDSC") == 0 ) && ( AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_conceptocompraswwds_3_cconpdsc1)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like '%' + @lV63Contabilidad_conceptocompraswwds_3_cconpdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPCUECOD") == 0 ) && ( AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPCUECOD") == 0 ) && ( AV62Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_conceptocompraswwds_4_cconpcuecod1)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like '%' + @lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPDSC") == 0 ) && ( AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_conceptocompraswwds_8_cconpdsc2)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV68Contabilidad_conceptocompraswwds_8_cconpdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPDSC") == 0 ) && ( AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_conceptocompraswwds_8_cconpdsc2)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like '%' + @lV68Contabilidad_conceptocompraswwds_8_cconpdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPCUECOD") == 0 ) && ( AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV65Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPCUECOD") == 0 ) && ( AV67Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_conceptocompraswwds_9_cconpcuecod2)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like '%' + @lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPDSC") == 0 ) && ( AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_conceptocompraswwds_13_cconpdsc3)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV73Contabilidad_conceptocompraswwds_13_cconpdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPDSC") == 0 ) && ( AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_conceptocompraswwds_13_cconpdsc3)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like '%' + @lV73Contabilidad_conceptocompraswwds_13_cconpdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPCUECOD") == 0 ) && ( AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV70Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPCUECOD") == 0 ) && ( AV72Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_conceptocompraswwds_14_cconpcuecod3)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like '%' + @lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV75Contabilidad_conceptocompraswwds_15_tfcconpcod) )
         {
            AddWhere(sWhereString, "([CConpCod] >= @AV75Contabilidad_conceptocompraswwds_15_tfcconpcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to) )
         {
            AddWhere(sWhereString, "([CConpCod] <= @AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_conceptocompraswwds_17_tfcconpdsc)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV77Contabilidad_conceptocompraswwds_17_tfcconpdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel)) )
         {
            AddWhere(sWhereString, "([CConpDsc] = @AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel)) )
         {
            AddWhere(sWhereString, "([CConpCueCod] = @AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Contabilidad_conceptocompraswwds_21_tfcconpsts_sels, "[CConpSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CConpCueCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006V2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] );
               case 1 :
                     return conditional_P006V3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006V2;
          prmP006V2 = new Object[] {
          new ParDef("@lV63Contabilidad_conceptocompraswwds_3_cconpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Contabilidad_conceptocompraswwds_3_cconpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV68Contabilidad_conceptocompraswwds_8_cconpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Contabilidad_conceptocompraswwds_8_cconpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV73Contabilidad_conceptocompraswwds_13_cconpdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV73Contabilidad_conceptocompraswwds_13_cconpdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV75Contabilidad_conceptocompraswwds_15_tfcconpcod",GXType.Int32,6,0) ,
          new ParDef("@AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV77Contabilidad_conceptocompraswwds_17_tfcconpdsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel",GXType.NChar,15,0)
          };
          Object[] prmP006V3;
          prmP006V3 = new Object[] {
          new ParDef("@lV63Contabilidad_conceptocompraswwds_3_cconpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Contabilidad_conceptocompraswwds_3_cconpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV64Contabilidad_conceptocompraswwds_4_cconpcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV68Contabilidad_conceptocompraswwds_8_cconpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Contabilidad_conceptocompraswwds_8_cconpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV69Contabilidad_conceptocompraswwds_9_cconpcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV73Contabilidad_conceptocompraswwds_13_cconpdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV73Contabilidad_conceptocompraswwds_13_cconpdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV74Contabilidad_conceptocompraswwds_14_cconpcuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV75Contabilidad_conceptocompraswwds_15_tfcconpcod",GXType.Int32,6,0) ,
          new ParDef("@AV76Contabilidad_conceptocompraswwds_16_tfcconpcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV77Contabilidad_conceptocompraswwds_17_tfcconpdsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV79Contabilidad_conceptocompraswwds_19_tfcconpcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV80Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006V2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006V3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
