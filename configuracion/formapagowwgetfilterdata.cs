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
namespace GeneXus.Programs.configuracion {
   public class formapagowwgetfilterdata : GXProcedure
   {
      public formapagowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public formapagowwgetfilterdata( IGxContext context )
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
         this.AV24DDOName = aP0_DDOName;
         this.AV22SearchTxt = aP1_SearchTxt;
         this.AV23SearchTxtTo = aP2_SearchTxtTo;
         this.AV28OptionsJson = "" ;
         this.AV31OptionsDescJson = "" ;
         this.AV33OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV33OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         formapagowwgetfilterdata objformapagowwgetfilterdata;
         objformapagowwgetfilterdata = new formapagowwgetfilterdata();
         objformapagowwgetfilterdata.AV24DDOName = aP0_DDOName;
         objformapagowwgetfilterdata.AV22SearchTxt = aP1_SearchTxt;
         objformapagowwgetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objformapagowwgetfilterdata.AV28OptionsJson = "" ;
         objformapagowwgetfilterdata.AV31OptionsDescJson = "" ;
         objformapagowwgetfilterdata.AV33OptionIndexesJson = "" ;
         objformapagowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objformapagowwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objformapagowwgetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((formapagowwgetfilterdata)stateInfo).executePrivate();
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
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_FORDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADFORDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_FORABR") == 0 )
         {
            /* Execute user subroutine: 'LOADFORABROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_FORSUNAT") == 0 )
         {
            /* Execute user subroutine: 'LOADFORSUNATOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV28OptionsJson = AV27Options.ToJSonString(false);
         AV31OptionsDescJson = AV30OptionsDesc.ToJSonString(false);
         AV33OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35Session.Get("Configuracion.FormaPagoWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.FormaPagoWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Configuracion.FormaPagoWWGridState"), null, "", "");
         }
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFFORCOD") == 0 )
            {
               AV10TFForCod = (int)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
               AV11TFForCod_To = (int)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFFORDSC") == 0 )
            {
               AV12TFForDsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFFORDSC_SEL") == 0 )
            {
               AV13TFForDsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFFORABR") == 0 )
            {
               AV14TFForAbr = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFFORABR_SEL") == 0 )
            {
               AV15TFForAbr_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFFORSUNAT") == 0 )
            {
               AV16TFForSunat = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFFORSUNAT_SEL") == 0 )
            {
               AV17TFForSunat_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFFORBANSTS_SEL") == 0 )
            {
               AV51TFForBanSts_Sel = (short)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFFORSTS_SEL") == 0 )
            {
               AV20TFForSts_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV21TFForSts_Sels.FromJSonString(AV20TFForSts_SelsJson, null);
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV39GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "FORDSC") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV42ForDsc1 = AV39GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV43DynamicFiltersEnabled2 = true;
               AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV44DynamicFiltersSelector2 = AV39GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "FORDSC") == 0 )
               {
                  AV45DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV46ForDsc2 = AV39GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV39GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "FORDSC") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV50ForDsc3 = AV39GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADFORDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFForDsc = AV22SearchTxt;
         AV13TFForDsc_Sel = "";
         AV56Configuracion_formapagowwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV58Configuracion_formapagowwds_3_fordsc1 = AV42ForDsc1;
         AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV60Configuracion_formapagowwds_5_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV62Configuracion_formapagowwds_7_fordsc2 = AV46ForDsc2;
         AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV64Configuracion_formapagowwds_9_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV66Configuracion_formapagowwds_11_fordsc3 = AV50ForDsc3;
         AV67Configuracion_formapagowwds_12_tfforcod = AV10TFForCod;
         AV68Configuracion_formapagowwds_13_tfforcod_to = AV11TFForCod_To;
         AV69Configuracion_formapagowwds_14_tffordsc = AV12TFForDsc;
         AV70Configuracion_formapagowwds_15_tffordsc_sel = AV13TFForDsc_Sel;
         AV71Configuracion_formapagowwds_16_tfforabr = AV14TFForAbr;
         AV72Configuracion_formapagowwds_17_tfforabr_sel = AV15TFForAbr_Sel;
         AV73Configuracion_formapagowwds_18_tfforsunat = AV16TFForSunat;
         AV74Configuracion_formapagowwds_19_tfforsunat_sel = AV17TFForSunat_Sel;
         AV75Configuracion_formapagowwds_20_tfforbansts_sel = AV51TFForBanSts_Sel;
         AV76Configuracion_formapagowwds_21_tfforsts_sels = AV21TFForSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A989ForSts ,
                                              AV76Configuracion_formapagowwds_21_tfforsts_sels ,
                                              AV56Configuracion_formapagowwds_1_dynamicfiltersselector1 ,
                                              AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 ,
                                              AV58Configuracion_formapagowwds_3_fordsc1 ,
                                              AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 ,
                                              AV60Configuracion_formapagowwds_5_dynamicfiltersselector2 ,
                                              AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 ,
                                              AV62Configuracion_formapagowwds_7_fordsc2 ,
                                              AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 ,
                                              AV64Configuracion_formapagowwds_9_dynamicfiltersselector3 ,
                                              AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 ,
                                              AV66Configuracion_formapagowwds_11_fordsc3 ,
                                              AV67Configuracion_formapagowwds_12_tfforcod ,
                                              AV68Configuracion_formapagowwds_13_tfforcod_to ,
                                              AV70Configuracion_formapagowwds_15_tffordsc_sel ,
                                              AV69Configuracion_formapagowwds_14_tffordsc ,
                                              AV72Configuracion_formapagowwds_17_tfforabr_sel ,
                                              AV71Configuracion_formapagowwds_16_tfforabr ,
                                              AV74Configuracion_formapagowwds_19_tfforsunat_sel ,
                                              AV73Configuracion_formapagowwds_18_tfforsunat ,
                                              AV75Configuracion_formapagowwds_20_tfforbansts_sel ,
                                              AV76Configuracion_formapagowwds_21_tfforsts_sels.Count ,
                                              A988ForDsc ,
                                              A143ForCod ,
                                              A986ForAbr ,
                                              A990ForSunat ,
                                              A987ForBanSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV58Configuracion_formapagowwds_3_fordsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_formapagowwds_3_fordsc1), 100, "%");
         lV58Configuracion_formapagowwds_3_fordsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_formapagowwds_3_fordsc1), 100, "%");
         lV62Configuracion_formapagowwds_7_fordsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_formapagowwds_7_fordsc2), 100, "%");
         lV62Configuracion_formapagowwds_7_fordsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_formapagowwds_7_fordsc2), 100, "%");
         lV66Configuracion_formapagowwds_11_fordsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_formapagowwds_11_fordsc3), 100, "%");
         lV66Configuracion_formapagowwds_11_fordsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_formapagowwds_11_fordsc3), 100, "%");
         lV69Configuracion_formapagowwds_14_tffordsc = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_formapagowwds_14_tffordsc), 100, "%");
         lV71Configuracion_formapagowwds_16_tfforabr = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_formapagowwds_16_tfforabr), 5, "%");
         lV73Configuracion_formapagowwds_18_tfforsunat = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_formapagowwds_18_tfforsunat), 5, "%");
         /* Using cursor P002M2 */
         pr_default.execute(0, new Object[] {lV58Configuracion_formapagowwds_3_fordsc1, lV58Configuracion_formapagowwds_3_fordsc1, lV62Configuracion_formapagowwds_7_fordsc2, lV62Configuracion_formapagowwds_7_fordsc2, lV66Configuracion_formapagowwds_11_fordsc3, lV66Configuracion_formapagowwds_11_fordsc3, AV67Configuracion_formapagowwds_12_tfforcod, AV68Configuracion_formapagowwds_13_tfforcod_to, lV69Configuracion_formapagowwds_14_tffordsc, AV70Configuracion_formapagowwds_15_tffordsc_sel, lV71Configuracion_formapagowwds_16_tfforabr, AV72Configuracion_formapagowwds_17_tfforabr_sel, lV73Configuracion_formapagowwds_18_tfforsunat, AV74Configuracion_formapagowwds_19_tfforsunat_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2M2 = false;
            A988ForDsc = P002M2_A988ForDsc[0];
            A989ForSts = P002M2_A989ForSts[0];
            A987ForBanSts = P002M2_A987ForBanSts[0];
            A990ForSunat = P002M2_A990ForSunat[0];
            A986ForAbr = P002M2_A986ForAbr[0];
            A143ForCod = P002M2_A143ForCod[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002M2_A988ForDsc[0], A988ForDsc) == 0 ) )
            {
               BRK2M2 = false;
               A143ForCod = P002M2_A143ForCod[0];
               AV34count = (long)(AV34count+1);
               BRK2M2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A988ForDsc)) )
            {
               AV26Option = A988ForDsc;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2M2 )
            {
               BRK2M2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADFORABROPTIONS' Routine */
         returnInSub = false;
         AV14TFForAbr = AV22SearchTxt;
         AV15TFForAbr_Sel = "";
         AV56Configuracion_formapagowwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV58Configuracion_formapagowwds_3_fordsc1 = AV42ForDsc1;
         AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV60Configuracion_formapagowwds_5_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV62Configuracion_formapagowwds_7_fordsc2 = AV46ForDsc2;
         AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV64Configuracion_formapagowwds_9_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV66Configuracion_formapagowwds_11_fordsc3 = AV50ForDsc3;
         AV67Configuracion_formapagowwds_12_tfforcod = AV10TFForCod;
         AV68Configuracion_formapagowwds_13_tfforcod_to = AV11TFForCod_To;
         AV69Configuracion_formapagowwds_14_tffordsc = AV12TFForDsc;
         AV70Configuracion_formapagowwds_15_tffordsc_sel = AV13TFForDsc_Sel;
         AV71Configuracion_formapagowwds_16_tfforabr = AV14TFForAbr;
         AV72Configuracion_formapagowwds_17_tfforabr_sel = AV15TFForAbr_Sel;
         AV73Configuracion_formapagowwds_18_tfforsunat = AV16TFForSunat;
         AV74Configuracion_formapagowwds_19_tfforsunat_sel = AV17TFForSunat_Sel;
         AV75Configuracion_formapagowwds_20_tfforbansts_sel = AV51TFForBanSts_Sel;
         AV76Configuracion_formapagowwds_21_tfforsts_sels = AV21TFForSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A989ForSts ,
                                              AV76Configuracion_formapagowwds_21_tfforsts_sels ,
                                              AV56Configuracion_formapagowwds_1_dynamicfiltersselector1 ,
                                              AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 ,
                                              AV58Configuracion_formapagowwds_3_fordsc1 ,
                                              AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 ,
                                              AV60Configuracion_formapagowwds_5_dynamicfiltersselector2 ,
                                              AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 ,
                                              AV62Configuracion_formapagowwds_7_fordsc2 ,
                                              AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 ,
                                              AV64Configuracion_formapagowwds_9_dynamicfiltersselector3 ,
                                              AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 ,
                                              AV66Configuracion_formapagowwds_11_fordsc3 ,
                                              AV67Configuracion_formapagowwds_12_tfforcod ,
                                              AV68Configuracion_formapagowwds_13_tfforcod_to ,
                                              AV70Configuracion_formapagowwds_15_tffordsc_sel ,
                                              AV69Configuracion_formapagowwds_14_tffordsc ,
                                              AV72Configuracion_formapagowwds_17_tfforabr_sel ,
                                              AV71Configuracion_formapagowwds_16_tfforabr ,
                                              AV74Configuracion_formapagowwds_19_tfforsunat_sel ,
                                              AV73Configuracion_formapagowwds_18_tfforsunat ,
                                              AV75Configuracion_formapagowwds_20_tfforbansts_sel ,
                                              AV76Configuracion_formapagowwds_21_tfforsts_sels.Count ,
                                              A988ForDsc ,
                                              A143ForCod ,
                                              A986ForAbr ,
                                              A990ForSunat ,
                                              A987ForBanSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV58Configuracion_formapagowwds_3_fordsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_formapagowwds_3_fordsc1), 100, "%");
         lV58Configuracion_formapagowwds_3_fordsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_formapagowwds_3_fordsc1), 100, "%");
         lV62Configuracion_formapagowwds_7_fordsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_formapagowwds_7_fordsc2), 100, "%");
         lV62Configuracion_formapagowwds_7_fordsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_formapagowwds_7_fordsc2), 100, "%");
         lV66Configuracion_formapagowwds_11_fordsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_formapagowwds_11_fordsc3), 100, "%");
         lV66Configuracion_formapagowwds_11_fordsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_formapagowwds_11_fordsc3), 100, "%");
         lV69Configuracion_formapagowwds_14_tffordsc = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_formapagowwds_14_tffordsc), 100, "%");
         lV71Configuracion_formapagowwds_16_tfforabr = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_formapagowwds_16_tfforabr), 5, "%");
         lV73Configuracion_formapagowwds_18_tfforsunat = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_formapagowwds_18_tfforsunat), 5, "%");
         /* Using cursor P002M3 */
         pr_default.execute(1, new Object[] {lV58Configuracion_formapagowwds_3_fordsc1, lV58Configuracion_formapagowwds_3_fordsc1, lV62Configuracion_formapagowwds_7_fordsc2, lV62Configuracion_formapagowwds_7_fordsc2, lV66Configuracion_formapagowwds_11_fordsc3, lV66Configuracion_formapagowwds_11_fordsc3, AV67Configuracion_formapagowwds_12_tfforcod, AV68Configuracion_formapagowwds_13_tfforcod_to, lV69Configuracion_formapagowwds_14_tffordsc, AV70Configuracion_formapagowwds_15_tffordsc_sel, lV71Configuracion_formapagowwds_16_tfforabr, AV72Configuracion_formapagowwds_17_tfforabr_sel, lV73Configuracion_formapagowwds_18_tfforsunat, AV74Configuracion_formapagowwds_19_tfforsunat_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2M4 = false;
            A986ForAbr = P002M3_A986ForAbr[0];
            A989ForSts = P002M3_A989ForSts[0];
            A987ForBanSts = P002M3_A987ForBanSts[0];
            A990ForSunat = P002M3_A990ForSunat[0];
            A143ForCod = P002M3_A143ForCod[0];
            A988ForDsc = P002M3_A988ForDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002M3_A986ForAbr[0], A986ForAbr) == 0 ) )
            {
               BRK2M4 = false;
               A143ForCod = P002M3_A143ForCod[0];
               AV34count = (long)(AV34count+1);
               BRK2M4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A986ForAbr)) )
            {
               AV26Option = A986ForAbr;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2M4 )
            {
               BRK2M4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADFORSUNATOPTIONS' Routine */
         returnInSub = false;
         AV16TFForSunat = AV22SearchTxt;
         AV17TFForSunat_Sel = "";
         AV56Configuracion_formapagowwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV58Configuracion_formapagowwds_3_fordsc1 = AV42ForDsc1;
         AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV60Configuracion_formapagowwds_5_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV62Configuracion_formapagowwds_7_fordsc2 = AV46ForDsc2;
         AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV64Configuracion_formapagowwds_9_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV66Configuracion_formapagowwds_11_fordsc3 = AV50ForDsc3;
         AV67Configuracion_formapagowwds_12_tfforcod = AV10TFForCod;
         AV68Configuracion_formapagowwds_13_tfforcod_to = AV11TFForCod_To;
         AV69Configuracion_formapagowwds_14_tffordsc = AV12TFForDsc;
         AV70Configuracion_formapagowwds_15_tffordsc_sel = AV13TFForDsc_Sel;
         AV71Configuracion_formapagowwds_16_tfforabr = AV14TFForAbr;
         AV72Configuracion_formapagowwds_17_tfforabr_sel = AV15TFForAbr_Sel;
         AV73Configuracion_formapagowwds_18_tfforsunat = AV16TFForSunat;
         AV74Configuracion_formapagowwds_19_tfforsunat_sel = AV17TFForSunat_Sel;
         AV75Configuracion_formapagowwds_20_tfforbansts_sel = AV51TFForBanSts_Sel;
         AV76Configuracion_formapagowwds_21_tfforsts_sels = AV21TFForSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A989ForSts ,
                                              AV76Configuracion_formapagowwds_21_tfforsts_sels ,
                                              AV56Configuracion_formapagowwds_1_dynamicfiltersselector1 ,
                                              AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 ,
                                              AV58Configuracion_formapagowwds_3_fordsc1 ,
                                              AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 ,
                                              AV60Configuracion_formapagowwds_5_dynamicfiltersselector2 ,
                                              AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 ,
                                              AV62Configuracion_formapagowwds_7_fordsc2 ,
                                              AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 ,
                                              AV64Configuracion_formapagowwds_9_dynamicfiltersselector3 ,
                                              AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 ,
                                              AV66Configuracion_formapagowwds_11_fordsc3 ,
                                              AV67Configuracion_formapagowwds_12_tfforcod ,
                                              AV68Configuracion_formapagowwds_13_tfforcod_to ,
                                              AV70Configuracion_formapagowwds_15_tffordsc_sel ,
                                              AV69Configuracion_formapagowwds_14_tffordsc ,
                                              AV72Configuracion_formapagowwds_17_tfforabr_sel ,
                                              AV71Configuracion_formapagowwds_16_tfforabr ,
                                              AV74Configuracion_formapagowwds_19_tfforsunat_sel ,
                                              AV73Configuracion_formapagowwds_18_tfforsunat ,
                                              AV75Configuracion_formapagowwds_20_tfforbansts_sel ,
                                              AV76Configuracion_formapagowwds_21_tfforsts_sels.Count ,
                                              A988ForDsc ,
                                              A143ForCod ,
                                              A986ForAbr ,
                                              A990ForSunat ,
                                              A987ForBanSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV58Configuracion_formapagowwds_3_fordsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_formapagowwds_3_fordsc1), 100, "%");
         lV58Configuracion_formapagowwds_3_fordsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_formapagowwds_3_fordsc1), 100, "%");
         lV62Configuracion_formapagowwds_7_fordsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_formapagowwds_7_fordsc2), 100, "%");
         lV62Configuracion_formapagowwds_7_fordsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_formapagowwds_7_fordsc2), 100, "%");
         lV66Configuracion_formapagowwds_11_fordsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_formapagowwds_11_fordsc3), 100, "%");
         lV66Configuracion_formapagowwds_11_fordsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_formapagowwds_11_fordsc3), 100, "%");
         lV69Configuracion_formapagowwds_14_tffordsc = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_formapagowwds_14_tffordsc), 100, "%");
         lV71Configuracion_formapagowwds_16_tfforabr = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_formapagowwds_16_tfforabr), 5, "%");
         lV73Configuracion_formapagowwds_18_tfforsunat = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_formapagowwds_18_tfforsunat), 5, "%");
         /* Using cursor P002M4 */
         pr_default.execute(2, new Object[] {lV58Configuracion_formapagowwds_3_fordsc1, lV58Configuracion_formapagowwds_3_fordsc1, lV62Configuracion_formapagowwds_7_fordsc2, lV62Configuracion_formapagowwds_7_fordsc2, lV66Configuracion_formapagowwds_11_fordsc3, lV66Configuracion_formapagowwds_11_fordsc3, AV67Configuracion_formapagowwds_12_tfforcod, AV68Configuracion_formapagowwds_13_tfforcod_to, lV69Configuracion_formapagowwds_14_tffordsc, AV70Configuracion_formapagowwds_15_tffordsc_sel, lV71Configuracion_formapagowwds_16_tfforabr, AV72Configuracion_formapagowwds_17_tfforabr_sel, lV73Configuracion_formapagowwds_18_tfforsunat, AV74Configuracion_formapagowwds_19_tfforsunat_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2M6 = false;
            A990ForSunat = P002M4_A990ForSunat[0];
            A989ForSts = P002M4_A989ForSts[0];
            A987ForBanSts = P002M4_A987ForBanSts[0];
            A986ForAbr = P002M4_A986ForAbr[0];
            A143ForCod = P002M4_A143ForCod[0];
            A988ForDsc = P002M4_A988ForDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P002M4_A990ForSunat[0], A990ForSunat) == 0 ) )
            {
               BRK2M6 = false;
               A143ForCod = P002M4_A143ForCod[0];
               AV34count = (long)(AV34count+1);
               BRK2M6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A990ForSunat)) )
            {
               AV26Option = A990ForSunat;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2M6 )
            {
               BRK2M6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV28OptionsJson = "";
         AV31OptionsDescJson = "";
         AV33OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV30OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV35Session = context.GetSession();
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV12TFForDsc = "";
         AV13TFForDsc_Sel = "";
         AV14TFForAbr = "";
         AV15TFForAbr_Sel = "";
         AV16TFForSunat = "";
         AV17TFForSunat_Sel = "";
         AV20TFForSts_SelsJson = "";
         AV21TFForSts_Sels = new GxSimpleCollection<short>();
         AV39GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42ForDsc1 = "";
         AV44DynamicFiltersSelector2 = "";
         AV46ForDsc2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV50ForDsc3 = "";
         AV56Configuracion_formapagowwds_1_dynamicfiltersselector1 = "";
         AV58Configuracion_formapagowwds_3_fordsc1 = "";
         AV60Configuracion_formapagowwds_5_dynamicfiltersselector2 = "";
         AV62Configuracion_formapagowwds_7_fordsc2 = "";
         AV64Configuracion_formapagowwds_9_dynamicfiltersselector3 = "";
         AV66Configuracion_formapagowwds_11_fordsc3 = "";
         AV69Configuracion_formapagowwds_14_tffordsc = "";
         AV70Configuracion_formapagowwds_15_tffordsc_sel = "";
         AV71Configuracion_formapagowwds_16_tfforabr = "";
         AV72Configuracion_formapagowwds_17_tfforabr_sel = "";
         AV73Configuracion_formapagowwds_18_tfforsunat = "";
         AV74Configuracion_formapagowwds_19_tfforsunat_sel = "";
         AV76Configuracion_formapagowwds_21_tfforsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV58Configuracion_formapagowwds_3_fordsc1 = "";
         lV62Configuracion_formapagowwds_7_fordsc2 = "";
         lV66Configuracion_formapagowwds_11_fordsc3 = "";
         lV69Configuracion_formapagowwds_14_tffordsc = "";
         lV71Configuracion_formapagowwds_16_tfforabr = "";
         lV73Configuracion_formapagowwds_18_tfforsunat = "";
         A988ForDsc = "";
         A986ForAbr = "";
         A990ForSunat = "";
         P002M2_A988ForDsc = new string[] {""} ;
         P002M2_A989ForSts = new short[1] ;
         P002M2_A987ForBanSts = new short[1] ;
         P002M2_A990ForSunat = new string[] {""} ;
         P002M2_A986ForAbr = new string[] {""} ;
         P002M2_A143ForCod = new int[1] ;
         AV26Option = "";
         P002M3_A986ForAbr = new string[] {""} ;
         P002M3_A989ForSts = new short[1] ;
         P002M3_A987ForBanSts = new short[1] ;
         P002M3_A990ForSunat = new string[] {""} ;
         P002M3_A143ForCod = new int[1] ;
         P002M3_A988ForDsc = new string[] {""} ;
         P002M4_A990ForSunat = new string[] {""} ;
         P002M4_A989ForSts = new short[1] ;
         P002M4_A987ForBanSts = new short[1] ;
         P002M4_A986ForAbr = new string[] {""} ;
         P002M4_A143ForCod = new int[1] ;
         P002M4_A988ForDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.formapagowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002M2_A988ForDsc, P002M2_A989ForSts, P002M2_A987ForBanSts, P002M2_A990ForSunat, P002M2_A986ForAbr, P002M2_A143ForCod
               }
               , new Object[] {
               P002M3_A986ForAbr, P002M3_A989ForSts, P002M3_A987ForBanSts, P002M3_A990ForSunat, P002M3_A143ForCod, P002M3_A988ForDsc
               }
               , new Object[] {
               P002M4_A990ForSunat, P002M4_A989ForSts, P002M4_A987ForBanSts, P002M4_A986ForAbr, P002M4_A143ForCod, P002M4_A988ForDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV51TFForBanSts_Sel ;
      private short AV41DynamicFiltersOperator1 ;
      private short AV45DynamicFiltersOperator2 ;
      private short AV49DynamicFiltersOperator3 ;
      private short AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 ;
      private short AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 ;
      private short AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 ;
      private short AV75Configuracion_formapagowwds_20_tfforbansts_sel ;
      private short A989ForSts ;
      private short A987ForBanSts ;
      private int AV54GXV1 ;
      private int AV10TFForCod ;
      private int AV11TFForCod_To ;
      private int AV67Configuracion_formapagowwds_12_tfforcod ;
      private int AV68Configuracion_formapagowwds_13_tfforcod_to ;
      private int AV76Configuracion_formapagowwds_21_tfforsts_sels_Count ;
      private int A143ForCod ;
      private long AV34count ;
      private string AV12TFForDsc ;
      private string AV13TFForDsc_Sel ;
      private string AV14TFForAbr ;
      private string AV15TFForAbr_Sel ;
      private string AV16TFForSunat ;
      private string AV17TFForSunat_Sel ;
      private string AV42ForDsc1 ;
      private string AV46ForDsc2 ;
      private string AV50ForDsc3 ;
      private string AV58Configuracion_formapagowwds_3_fordsc1 ;
      private string AV62Configuracion_formapagowwds_7_fordsc2 ;
      private string AV66Configuracion_formapagowwds_11_fordsc3 ;
      private string AV69Configuracion_formapagowwds_14_tffordsc ;
      private string AV70Configuracion_formapagowwds_15_tffordsc_sel ;
      private string AV71Configuracion_formapagowwds_16_tfforabr ;
      private string AV72Configuracion_formapagowwds_17_tfforabr_sel ;
      private string AV73Configuracion_formapagowwds_18_tfforsunat ;
      private string AV74Configuracion_formapagowwds_19_tfforsunat_sel ;
      private string scmdbuf ;
      private string lV58Configuracion_formapagowwds_3_fordsc1 ;
      private string lV62Configuracion_formapagowwds_7_fordsc2 ;
      private string lV66Configuracion_formapagowwds_11_fordsc3 ;
      private string lV69Configuracion_formapagowwds_14_tffordsc ;
      private string lV71Configuracion_formapagowwds_16_tfforabr ;
      private string lV73Configuracion_formapagowwds_18_tfforsunat ;
      private string A988ForDsc ;
      private string A986ForAbr ;
      private string A990ForSunat ;
      private bool returnInSub ;
      private bool AV43DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 ;
      private bool AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 ;
      private bool BRK2M2 ;
      private bool BRK2M4 ;
      private bool BRK2M6 ;
      private string AV28OptionsJson ;
      private string AV31OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV20TFForSts_SelsJson ;
      private string AV24DDOName ;
      private string AV22SearchTxt ;
      private string AV23SearchTxtTo ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV44DynamicFiltersSelector2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV56Configuracion_formapagowwds_1_dynamicfiltersselector1 ;
      private string AV60Configuracion_formapagowwds_5_dynamicfiltersselector2 ;
      private string AV64Configuracion_formapagowwds_9_dynamicfiltersselector3 ;
      private string AV26Option ;
      private GxSimpleCollection<short> AV21TFForSts_Sels ;
      private GxSimpleCollection<short> AV76Configuracion_formapagowwds_21_tfforsts_sels ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002M2_A988ForDsc ;
      private short[] P002M2_A989ForSts ;
      private short[] P002M2_A987ForBanSts ;
      private string[] P002M2_A990ForSunat ;
      private string[] P002M2_A986ForAbr ;
      private int[] P002M2_A143ForCod ;
      private string[] P002M3_A986ForAbr ;
      private short[] P002M3_A989ForSts ;
      private short[] P002M3_A987ForBanSts ;
      private string[] P002M3_A990ForSunat ;
      private int[] P002M3_A143ForCod ;
      private string[] P002M3_A988ForDsc ;
      private string[] P002M4_A990ForSunat ;
      private short[] P002M4_A989ForSts ;
      private short[] P002M4_A987ForBanSts ;
      private string[] P002M4_A986ForAbr ;
      private int[] P002M4_A143ForCod ;
      private string[] P002M4_A988ForDsc ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV39GridStateDynamicFilter ;
   }

   public class formapagowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002M2( IGxContext context ,
                                             short A989ForSts ,
                                             GxSimpleCollection<short> AV76Configuracion_formapagowwds_21_tfforsts_sels ,
                                             string AV56Configuracion_formapagowwds_1_dynamicfiltersselector1 ,
                                             short AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 ,
                                             string AV58Configuracion_formapagowwds_3_fordsc1 ,
                                             bool AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 ,
                                             string AV60Configuracion_formapagowwds_5_dynamicfiltersselector2 ,
                                             short AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 ,
                                             string AV62Configuracion_formapagowwds_7_fordsc2 ,
                                             bool AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 ,
                                             string AV64Configuracion_formapagowwds_9_dynamicfiltersselector3 ,
                                             short AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 ,
                                             string AV66Configuracion_formapagowwds_11_fordsc3 ,
                                             int AV67Configuracion_formapagowwds_12_tfforcod ,
                                             int AV68Configuracion_formapagowwds_13_tfforcod_to ,
                                             string AV70Configuracion_formapagowwds_15_tffordsc_sel ,
                                             string AV69Configuracion_formapagowwds_14_tffordsc ,
                                             string AV72Configuracion_formapagowwds_17_tfforabr_sel ,
                                             string AV71Configuracion_formapagowwds_16_tfforabr ,
                                             string AV74Configuracion_formapagowwds_19_tfforsunat_sel ,
                                             string AV73Configuracion_formapagowwds_18_tfforsunat ,
                                             short AV75Configuracion_formapagowwds_20_tfforbansts_sel ,
                                             int AV76Configuracion_formapagowwds_21_tfforsts_sels_Count ,
                                             string A988ForDsc ,
                                             int A143ForCod ,
                                             string A986ForAbr ,
                                             string A990ForSunat ,
                                             short A987ForBanSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ForDsc], [ForSts], [ForBanSts], [ForSunat], [ForAbr], [ForCod] FROM [CFORMAPAGO]";
         if ( ( StringUtil.StrCmp(AV56Configuracion_formapagowwds_1_dynamicfiltersselector1, "FORDSC") == 0 ) && ( AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_formapagowwds_3_fordsc1)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV58Configuracion_formapagowwds_3_fordsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Configuracion_formapagowwds_1_dynamicfiltersselector1, "FORDSC") == 0 ) && ( AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_formapagowwds_3_fordsc1)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV58Configuracion_formapagowwds_3_fordsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_formapagowwds_5_dynamicfiltersselector2, "FORDSC") == 0 ) && ( AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_formapagowwds_7_fordsc2)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV62Configuracion_formapagowwds_7_fordsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_formapagowwds_5_dynamicfiltersselector2, "FORDSC") == 0 ) && ( AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_formapagowwds_7_fordsc2)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV62Configuracion_formapagowwds_7_fordsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_formapagowwds_9_dynamicfiltersselector3, "FORDSC") == 0 ) && ( AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_formapagowwds_11_fordsc3)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV66Configuracion_formapagowwds_11_fordsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_formapagowwds_9_dynamicfiltersselector3, "FORDSC") == 0 ) && ( AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_formapagowwds_11_fordsc3)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV66Configuracion_formapagowwds_11_fordsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV67Configuracion_formapagowwds_12_tfforcod) )
         {
            AddWhere(sWhereString, "([ForCod] >= @AV67Configuracion_formapagowwds_12_tfforcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV68Configuracion_formapagowwds_13_tfforcod_to) )
         {
            AddWhere(sWhereString, "([ForCod] <= @AV68Configuracion_formapagowwds_13_tfforcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_formapagowwds_15_tffordsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_formapagowwds_14_tffordsc)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV69Configuracion_formapagowwds_14_tffordsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_formapagowwds_15_tffordsc_sel)) )
         {
            AddWhere(sWhereString, "([ForDsc] = @AV70Configuracion_formapagowwds_15_tffordsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_formapagowwds_17_tfforabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_formapagowwds_16_tfforabr)) ) )
         {
            AddWhere(sWhereString, "([ForAbr] like @lV71Configuracion_formapagowwds_16_tfforabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_formapagowwds_17_tfforabr_sel)) )
         {
            AddWhere(sWhereString, "([ForAbr] = @AV72Configuracion_formapagowwds_17_tfforabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_formapagowwds_19_tfforsunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_formapagowwds_18_tfforsunat)) ) )
         {
            AddWhere(sWhereString, "([ForSunat] like @lV73Configuracion_formapagowwds_18_tfforsunat)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_formapagowwds_19_tfforsunat_sel)) )
         {
            AddWhere(sWhereString, "([ForSunat] = @AV74Configuracion_formapagowwds_19_tfforsunat_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV75Configuracion_formapagowwds_20_tfforbansts_sel == 1 )
         {
            AddWhere(sWhereString, "([ForBanSts] = 1)");
         }
         if ( AV75Configuracion_formapagowwds_20_tfforbansts_sel == 2 )
         {
            AddWhere(sWhereString, "([ForBanSts] = 0)");
         }
         if ( AV76Configuracion_formapagowwds_21_tfforsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Configuracion_formapagowwds_21_tfforsts_sels, "[ForSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ForDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002M3( IGxContext context ,
                                             short A989ForSts ,
                                             GxSimpleCollection<short> AV76Configuracion_formapagowwds_21_tfforsts_sels ,
                                             string AV56Configuracion_formapagowwds_1_dynamicfiltersselector1 ,
                                             short AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 ,
                                             string AV58Configuracion_formapagowwds_3_fordsc1 ,
                                             bool AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 ,
                                             string AV60Configuracion_formapagowwds_5_dynamicfiltersselector2 ,
                                             short AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 ,
                                             string AV62Configuracion_formapagowwds_7_fordsc2 ,
                                             bool AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 ,
                                             string AV64Configuracion_formapagowwds_9_dynamicfiltersselector3 ,
                                             short AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 ,
                                             string AV66Configuracion_formapagowwds_11_fordsc3 ,
                                             int AV67Configuracion_formapagowwds_12_tfforcod ,
                                             int AV68Configuracion_formapagowwds_13_tfforcod_to ,
                                             string AV70Configuracion_formapagowwds_15_tffordsc_sel ,
                                             string AV69Configuracion_formapagowwds_14_tffordsc ,
                                             string AV72Configuracion_formapagowwds_17_tfforabr_sel ,
                                             string AV71Configuracion_formapagowwds_16_tfforabr ,
                                             string AV74Configuracion_formapagowwds_19_tfforsunat_sel ,
                                             string AV73Configuracion_formapagowwds_18_tfforsunat ,
                                             short AV75Configuracion_formapagowwds_20_tfforbansts_sel ,
                                             int AV76Configuracion_formapagowwds_21_tfforsts_sels_Count ,
                                             string A988ForDsc ,
                                             int A143ForCod ,
                                             string A986ForAbr ,
                                             string A990ForSunat ,
                                             short A987ForBanSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [ForAbr], [ForSts], [ForBanSts], [ForSunat], [ForCod], [ForDsc] FROM [CFORMAPAGO]";
         if ( ( StringUtil.StrCmp(AV56Configuracion_formapagowwds_1_dynamicfiltersselector1, "FORDSC") == 0 ) && ( AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_formapagowwds_3_fordsc1)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV58Configuracion_formapagowwds_3_fordsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Configuracion_formapagowwds_1_dynamicfiltersselector1, "FORDSC") == 0 ) && ( AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_formapagowwds_3_fordsc1)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV58Configuracion_formapagowwds_3_fordsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_formapagowwds_5_dynamicfiltersselector2, "FORDSC") == 0 ) && ( AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_formapagowwds_7_fordsc2)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV62Configuracion_formapagowwds_7_fordsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_formapagowwds_5_dynamicfiltersselector2, "FORDSC") == 0 ) && ( AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_formapagowwds_7_fordsc2)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV62Configuracion_formapagowwds_7_fordsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_formapagowwds_9_dynamicfiltersselector3, "FORDSC") == 0 ) && ( AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_formapagowwds_11_fordsc3)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV66Configuracion_formapagowwds_11_fordsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_formapagowwds_9_dynamicfiltersselector3, "FORDSC") == 0 ) && ( AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_formapagowwds_11_fordsc3)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV66Configuracion_formapagowwds_11_fordsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV67Configuracion_formapagowwds_12_tfforcod) )
         {
            AddWhere(sWhereString, "([ForCod] >= @AV67Configuracion_formapagowwds_12_tfforcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV68Configuracion_formapagowwds_13_tfforcod_to) )
         {
            AddWhere(sWhereString, "([ForCod] <= @AV68Configuracion_formapagowwds_13_tfforcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_formapagowwds_15_tffordsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_formapagowwds_14_tffordsc)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV69Configuracion_formapagowwds_14_tffordsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_formapagowwds_15_tffordsc_sel)) )
         {
            AddWhere(sWhereString, "([ForDsc] = @AV70Configuracion_formapagowwds_15_tffordsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_formapagowwds_17_tfforabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_formapagowwds_16_tfforabr)) ) )
         {
            AddWhere(sWhereString, "([ForAbr] like @lV71Configuracion_formapagowwds_16_tfforabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_formapagowwds_17_tfforabr_sel)) )
         {
            AddWhere(sWhereString, "([ForAbr] = @AV72Configuracion_formapagowwds_17_tfforabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_formapagowwds_19_tfforsunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_formapagowwds_18_tfforsunat)) ) )
         {
            AddWhere(sWhereString, "([ForSunat] like @lV73Configuracion_formapagowwds_18_tfforsunat)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_formapagowwds_19_tfforsunat_sel)) )
         {
            AddWhere(sWhereString, "([ForSunat] = @AV74Configuracion_formapagowwds_19_tfforsunat_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV75Configuracion_formapagowwds_20_tfforbansts_sel == 1 )
         {
            AddWhere(sWhereString, "([ForBanSts] = 1)");
         }
         if ( AV75Configuracion_formapagowwds_20_tfforbansts_sel == 2 )
         {
            AddWhere(sWhereString, "([ForBanSts] = 0)");
         }
         if ( AV76Configuracion_formapagowwds_21_tfforsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Configuracion_formapagowwds_21_tfforsts_sels, "[ForSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ForAbr]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002M4( IGxContext context ,
                                             short A989ForSts ,
                                             GxSimpleCollection<short> AV76Configuracion_formapagowwds_21_tfforsts_sels ,
                                             string AV56Configuracion_formapagowwds_1_dynamicfiltersselector1 ,
                                             short AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 ,
                                             string AV58Configuracion_formapagowwds_3_fordsc1 ,
                                             bool AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 ,
                                             string AV60Configuracion_formapagowwds_5_dynamicfiltersselector2 ,
                                             short AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 ,
                                             string AV62Configuracion_formapagowwds_7_fordsc2 ,
                                             bool AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 ,
                                             string AV64Configuracion_formapagowwds_9_dynamicfiltersselector3 ,
                                             short AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 ,
                                             string AV66Configuracion_formapagowwds_11_fordsc3 ,
                                             int AV67Configuracion_formapagowwds_12_tfforcod ,
                                             int AV68Configuracion_formapagowwds_13_tfforcod_to ,
                                             string AV70Configuracion_formapagowwds_15_tffordsc_sel ,
                                             string AV69Configuracion_formapagowwds_14_tffordsc ,
                                             string AV72Configuracion_formapagowwds_17_tfforabr_sel ,
                                             string AV71Configuracion_formapagowwds_16_tfforabr ,
                                             string AV74Configuracion_formapagowwds_19_tfforsunat_sel ,
                                             string AV73Configuracion_formapagowwds_18_tfforsunat ,
                                             short AV75Configuracion_formapagowwds_20_tfforbansts_sel ,
                                             int AV76Configuracion_formapagowwds_21_tfforsts_sels_Count ,
                                             string A988ForDsc ,
                                             int A143ForCod ,
                                             string A986ForAbr ,
                                             string A990ForSunat ,
                                             short A987ForBanSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [ForSunat], [ForSts], [ForBanSts], [ForAbr], [ForCod], [ForDsc] FROM [CFORMAPAGO]";
         if ( ( StringUtil.StrCmp(AV56Configuracion_formapagowwds_1_dynamicfiltersselector1, "FORDSC") == 0 ) && ( AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_formapagowwds_3_fordsc1)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV58Configuracion_formapagowwds_3_fordsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Configuracion_formapagowwds_1_dynamicfiltersselector1, "FORDSC") == 0 ) && ( AV57Configuracion_formapagowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_formapagowwds_3_fordsc1)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV58Configuracion_formapagowwds_3_fordsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_formapagowwds_5_dynamicfiltersselector2, "FORDSC") == 0 ) && ( AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_formapagowwds_7_fordsc2)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV62Configuracion_formapagowwds_7_fordsc2)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV59Configuracion_formapagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_formapagowwds_5_dynamicfiltersselector2, "FORDSC") == 0 ) && ( AV61Configuracion_formapagowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_formapagowwds_7_fordsc2)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV62Configuracion_formapagowwds_7_fordsc2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_formapagowwds_9_dynamicfiltersselector3, "FORDSC") == 0 ) && ( AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_formapagowwds_11_fordsc3)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV66Configuracion_formapagowwds_11_fordsc3)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV63Configuracion_formapagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_formapagowwds_9_dynamicfiltersselector3, "FORDSC") == 0 ) && ( AV65Configuracion_formapagowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_formapagowwds_11_fordsc3)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV66Configuracion_formapagowwds_11_fordsc3)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV67Configuracion_formapagowwds_12_tfforcod) )
         {
            AddWhere(sWhereString, "([ForCod] >= @AV67Configuracion_formapagowwds_12_tfforcod)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV68Configuracion_formapagowwds_13_tfforcod_to) )
         {
            AddWhere(sWhereString, "([ForCod] <= @AV68Configuracion_formapagowwds_13_tfforcod_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_formapagowwds_15_tffordsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_formapagowwds_14_tffordsc)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV69Configuracion_formapagowwds_14_tffordsc)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_formapagowwds_15_tffordsc_sel)) )
         {
            AddWhere(sWhereString, "([ForDsc] = @AV70Configuracion_formapagowwds_15_tffordsc_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_formapagowwds_17_tfforabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_formapagowwds_16_tfforabr)) ) )
         {
            AddWhere(sWhereString, "([ForAbr] like @lV71Configuracion_formapagowwds_16_tfforabr)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_formapagowwds_17_tfforabr_sel)) )
         {
            AddWhere(sWhereString, "([ForAbr] = @AV72Configuracion_formapagowwds_17_tfforabr_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_formapagowwds_19_tfforsunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_formapagowwds_18_tfforsunat)) ) )
         {
            AddWhere(sWhereString, "([ForSunat] like @lV73Configuracion_formapagowwds_18_tfforsunat)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_formapagowwds_19_tfforsunat_sel)) )
         {
            AddWhere(sWhereString, "([ForSunat] = @AV74Configuracion_formapagowwds_19_tfforsunat_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV75Configuracion_formapagowwds_20_tfforbansts_sel == 1 )
         {
            AddWhere(sWhereString, "([ForBanSts] = 1)");
         }
         if ( AV75Configuracion_formapagowwds_20_tfforbansts_sel == 2 )
         {
            AddWhere(sWhereString, "([ForBanSts] = 0)");
         }
         if ( AV76Configuracion_formapagowwds_21_tfforsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Configuracion_formapagowwds_21_tfforsts_sels, "[ForSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ForSunat]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002M2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] );
               case 1 :
                     return conditional_P002M3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] );
               case 2 :
                     return conditional_P002M4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002M2;
          prmP002M2 = new Object[] {
          new ParDef("@lV58Configuracion_formapagowwds_3_fordsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_formapagowwds_3_fordsc1",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_formapagowwds_7_fordsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_formapagowwds_7_fordsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_formapagowwds_11_fordsc3",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_formapagowwds_11_fordsc3",GXType.NChar,100,0) ,
          new ParDef("@AV67Configuracion_formapagowwds_12_tfforcod",GXType.Int32,6,0) ,
          new ParDef("@AV68Configuracion_formapagowwds_13_tfforcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV69Configuracion_formapagowwds_14_tffordsc",GXType.NChar,100,0) ,
          new ParDef("@AV70Configuracion_formapagowwds_15_tffordsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_formapagowwds_16_tfforabr",GXType.NChar,5,0) ,
          new ParDef("@AV72Configuracion_formapagowwds_17_tfforabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV73Configuracion_formapagowwds_18_tfforsunat",GXType.NChar,5,0) ,
          new ParDef("@AV74Configuracion_formapagowwds_19_tfforsunat_sel",GXType.NChar,5,0)
          };
          Object[] prmP002M3;
          prmP002M3 = new Object[] {
          new ParDef("@lV58Configuracion_formapagowwds_3_fordsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_formapagowwds_3_fordsc1",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_formapagowwds_7_fordsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_formapagowwds_7_fordsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_formapagowwds_11_fordsc3",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_formapagowwds_11_fordsc3",GXType.NChar,100,0) ,
          new ParDef("@AV67Configuracion_formapagowwds_12_tfforcod",GXType.Int32,6,0) ,
          new ParDef("@AV68Configuracion_formapagowwds_13_tfforcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV69Configuracion_formapagowwds_14_tffordsc",GXType.NChar,100,0) ,
          new ParDef("@AV70Configuracion_formapagowwds_15_tffordsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_formapagowwds_16_tfforabr",GXType.NChar,5,0) ,
          new ParDef("@AV72Configuracion_formapagowwds_17_tfforabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV73Configuracion_formapagowwds_18_tfforsunat",GXType.NChar,5,0) ,
          new ParDef("@AV74Configuracion_formapagowwds_19_tfforsunat_sel",GXType.NChar,5,0)
          };
          Object[] prmP002M4;
          prmP002M4 = new Object[] {
          new ParDef("@lV58Configuracion_formapagowwds_3_fordsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_formapagowwds_3_fordsc1",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_formapagowwds_7_fordsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_formapagowwds_7_fordsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_formapagowwds_11_fordsc3",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_formapagowwds_11_fordsc3",GXType.NChar,100,0) ,
          new ParDef("@AV67Configuracion_formapagowwds_12_tfforcod",GXType.Int32,6,0) ,
          new ParDef("@AV68Configuracion_formapagowwds_13_tfforcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV69Configuracion_formapagowwds_14_tffordsc",GXType.NChar,100,0) ,
          new ParDef("@AV70Configuracion_formapagowwds_15_tffordsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_formapagowwds_16_tfforabr",GXType.NChar,5,0) ,
          new ParDef("@AV72Configuracion_formapagowwds_17_tfforabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV73Configuracion_formapagowwds_18_tfforsunat",GXType.NChar,5,0) ,
          new ParDef("@AV74Configuracion_formapagowwds_19_tfforsunat_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002M2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002M3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002M4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002M4,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((string[]) buf[4])[0] = rslt.getString(5, 5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
       }
    }

 }

}
