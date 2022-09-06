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
   public class plancuentaswwgetfilterdata : GXProcedure
   {
      public plancuentaswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public plancuentaswwgetfilterdata( IGxContext context )
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
         this.AV54DDOName = aP0_DDOName;
         this.AV52SearchTxt = aP1_SearchTxt;
         this.AV53SearchTxtTo = aP2_SearchTxtTo;
         this.AV58OptionsJson = "" ;
         this.AV61OptionsDescJson = "" ;
         this.AV63OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV58OptionsJson;
         aP4_OptionsDescJson=this.AV61OptionsDescJson;
         aP5_OptionIndexesJson=this.AV63OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV63OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         plancuentaswwgetfilterdata objplancuentaswwgetfilterdata;
         objplancuentaswwgetfilterdata = new plancuentaswwgetfilterdata();
         objplancuentaswwgetfilterdata.AV54DDOName = aP0_DDOName;
         objplancuentaswwgetfilterdata.AV52SearchTxt = aP1_SearchTxt;
         objplancuentaswwgetfilterdata.AV53SearchTxtTo = aP2_SearchTxtTo;
         objplancuentaswwgetfilterdata.AV58OptionsJson = "" ;
         objplancuentaswwgetfilterdata.AV61OptionsDescJson = "" ;
         objplancuentaswwgetfilterdata.AV63OptionIndexesJson = "" ;
         objplancuentaswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objplancuentaswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objplancuentaswwgetfilterdata);
         aP3_OptionsJson=this.AV58OptionsJson;
         aP4_OptionsDescJson=this.AV61OptionsDescJson;
         aP5_OptionIndexesJson=this.AV63OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((plancuentaswwgetfilterdata)stateInfo).executePrivate();
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
         AV57Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV60OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV62OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV54DDOName), "DDO_CUECOD") == 0 )
         {
            /* Execute user subroutine: 'LOADCUECODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV54DDOName), "DDO_CUEDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCUEDSCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV54DDOName), "DDO_CUEGASDEBE") == 0 )
         {
            /* Execute user subroutine: 'LOADCUEGASDEBEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV54DDOName), "DDO_CUEGASHABER") == 0 )
         {
            /* Execute user subroutine: 'LOADCUEGASHABEROPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV58OptionsJson = AV57Options.ToJSonString(false);
         AV61OptionsDescJson = AV60OptionsDesc.ToJSonString(false);
         AV63OptionIndexesJson = AV62OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV65Session.Get("Contabilidad.PlanCuentasWWGridState"), "") == 0 )
         {
            AV67GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.PlanCuentasWWGridState"), null, "", "");
         }
         else
         {
            AV67GridState.FromXml(AV65Session.Get("Contabilidad.PlanCuentasWWGridState"), null, "", "");
         }
         AV97GXV1 = 1;
         while ( AV97GXV1 <= AV67GridState.gxTpr_Filtervalues.Count )
         {
            AV68GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV67GridState.gxTpr_Filtervalues.Item(AV97GXV1));
            if ( StringUtil.StrCmp(AV68GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV10TFCueCod = AV68GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV68GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV11TFCueCod_Sel = AV68GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV68GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV12TFCueDsc = AV68GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV68GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV13TFCueDsc_Sel = AV68GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV68GridStateFilterValue.gxTpr_Name, "TFCUEMOV_SEL") == 0 )
            {
               AV87TFCueMov_Sel = (short)(NumberUtil.Val( AV68GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV68GridStateFilterValue.gxTpr_Name, "TFCUEMON_SEL") == 0 )
            {
               AV88TFCueMon_Sel = (short)(NumberUtil.Val( AV68GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV68GridStateFilterValue.gxTpr_Name, "TFCUECOS_SEL") == 0 )
            {
               AV89TFCueCos_Sel = (short)(NumberUtil.Val( AV68GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV68GridStateFilterValue.gxTpr_Name, "TFCUEGASDEBE") == 0 )
            {
               AV24TFCueGasDebe = AV68GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV68GridStateFilterValue.gxTpr_Name, "TFCUEGASDEBE_SEL") == 0 )
            {
               AV25TFCueGasDebe_Sel = AV68GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV68GridStateFilterValue.gxTpr_Name, "TFCUEGASHABER") == 0 )
            {
               AV26TFCueGasHaber = AV68GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV68GridStateFilterValue.gxTpr_Name, "TFCUEGASHABER_SEL") == 0 )
            {
               AV27TFCueGasHaber_Sel = AV68GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV68GridStateFilterValue.gxTpr_Name, "TFCUESTS_SEL") == 0 )
            {
               AV90TFCueSts_SelsJson = AV68GridStateFilterValue.gxTpr_Value;
               AV91TFCueSts_Sels.FromJSonString(AV90TFCueSts_SelsJson, null);
            }
            AV97GXV1 = (int)(AV97GXV1+1);
         }
         if ( AV67GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV69GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV67GridState.gxTpr_Dynamicfilters.Item(1));
            AV70DynamicFiltersSelector1 = AV69GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV70DynamicFiltersSelector1, "CUECOD") == 0 )
            {
               AV71DynamicFiltersOperator1 = AV69GridStateDynamicFilter.gxTpr_Operator;
               AV84CueCod1 = AV69GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV70DynamicFiltersSelector1, "CUEDSC") == 0 )
            {
               AV71DynamicFiltersOperator1 = AV69GridStateDynamicFilter.gxTpr_Operator;
               AV72CueDsc1 = AV69GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV70DynamicFiltersSelector1, "CUEMOV") == 0 )
            {
               AV92CueMov1 = (short)(NumberUtil.Val( AV69GridStateDynamicFilter.gxTpr_Value, "."));
            }
            if ( AV67GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV74DynamicFiltersEnabled2 = true;
               AV69GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV67GridState.gxTpr_Dynamicfilters.Item(2));
               AV75DynamicFiltersSelector2 = AV69GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV75DynamicFiltersSelector2, "CUECOD") == 0 )
               {
                  AV76DynamicFiltersOperator2 = AV69GridStateDynamicFilter.gxTpr_Operator;
                  AV85CueCod2 = AV69GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV75DynamicFiltersSelector2, "CUEDSC") == 0 )
               {
                  AV76DynamicFiltersOperator2 = AV69GridStateDynamicFilter.gxTpr_Operator;
                  AV77CueDsc2 = AV69GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV75DynamicFiltersSelector2, "CUEMOV") == 0 )
               {
                  AV93CueMov2 = (short)(NumberUtil.Val( AV69GridStateDynamicFilter.gxTpr_Value, "."));
               }
               if ( AV67GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV79DynamicFiltersEnabled3 = true;
                  AV69GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV67GridState.gxTpr_Dynamicfilters.Item(3));
                  AV80DynamicFiltersSelector3 = AV69GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV80DynamicFiltersSelector3, "CUECOD") == 0 )
                  {
                     AV81DynamicFiltersOperator3 = AV69GridStateDynamicFilter.gxTpr_Operator;
                     AV86CueCod3 = AV69GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV80DynamicFiltersSelector3, "CUEDSC") == 0 )
                  {
                     AV81DynamicFiltersOperator3 = AV69GridStateDynamicFilter.gxTpr_Operator;
                     AV82CueDsc3 = AV69GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV80DynamicFiltersSelector3, "CUEMOV") == 0 )
                  {
                     AV94CueMov3 = (short)(NumberUtil.Val( AV69GridStateDynamicFilter.gxTpr_Value, "."));
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCUECODOPTIONS' Routine */
         returnInSub = false;
         AV10TFCueCod = AV52SearchTxt;
         AV11TFCueCod_Sel = "";
         AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = AV70DynamicFiltersSelector1;
         AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 = AV71DynamicFiltersOperator1;
         AV101Contabilidad_plancuentaswwds_3_cuecod1 = AV84CueCod1;
         AV102Contabilidad_plancuentaswwds_4_cuedsc1 = AV72CueDsc1;
         AV103Contabilidad_plancuentaswwds_5_cuemov1 = AV92CueMov1;
         AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 = AV74DynamicFiltersEnabled2;
         AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = AV75DynamicFiltersSelector2;
         AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 = AV76DynamicFiltersOperator2;
         AV107Contabilidad_plancuentaswwds_9_cuecod2 = AV85CueCod2;
         AV108Contabilidad_plancuentaswwds_10_cuedsc2 = AV77CueDsc2;
         AV109Contabilidad_plancuentaswwds_11_cuemov2 = AV93CueMov2;
         AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 = AV79DynamicFiltersEnabled3;
         AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = AV80DynamicFiltersSelector3;
         AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 = AV81DynamicFiltersOperator3;
         AV113Contabilidad_plancuentaswwds_15_cuecod3 = AV86CueCod3;
         AV114Contabilidad_plancuentaswwds_16_cuedsc3 = AV82CueDsc3;
         AV115Contabilidad_plancuentaswwds_17_cuemov3 = AV94CueMov3;
         AV116Contabilidad_plancuentaswwds_18_tfcuecod = AV10TFCueCod;
         AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel = AV11TFCueCod_Sel;
         AV118Contabilidad_plancuentaswwds_20_tfcuedsc = AV12TFCueDsc;
         AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel = AV13TFCueDsc_Sel;
         AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel = AV87TFCueMov_Sel;
         AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel = AV88TFCueMon_Sel;
         AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel = AV89TFCueCos_Sel;
         AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe = AV24TFCueGasDebe;
         AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = AV25TFCueGasDebe_Sel;
         AV125Contabilidad_plancuentaswwds_27_tfcuegashaber = AV26TFCueGasHaber;
         AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = AV27TFCueGasHaber_Sel;
         AV127Contabilidad_plancuentaswwds_29_tfcuests_sels = AV91TFCueSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A873CueSts ,
                                              AV127Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                              AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                              AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                              AV101Contabilidad_plancuentaswwds_3_cuecod1 ,
                                              AV102Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                              AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                              AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                              AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                              AV107Contabilidad_plancuentaswwds_9_cuecod2 ,
                                              AV108Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                              AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                              AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                              AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                              AV113Contabilidad_plancuentaswwds_15_cuecod3 ,
                                              AV114Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                              AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                              AV116Contabilidad_plancuentaswwds_18_tfcuecod ,
                                              AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                              AV118Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                              AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                              AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                              AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                              AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                              AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                              AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                              AV125Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                              AV127Contabilidad_plancuentaswwds_29_tfcuests_sels.Count ,
                                              A91CueCod ,
                                              A860CueDsc ,
                                              A867CueMov ,
                                              AV103Contabilidad_plancuentaswwds_5_cuemov1 ,
                                              AV109Contabilidad_plancuentaswwds_11_cuemov2 ,
                                              AV115Contabilidad_plancuentaswwds_17_cuemov3 ,
                                              A864CueMon ,
                                              A859CueCos ,
                                              A109CueGasDebe ,
                                              A110CueGasHaber } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV101Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV101Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV102Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV102Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV107Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV107Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV108Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV108Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV113Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV113Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV114Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV114Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV116Contabilidad_plancuentaswwds_18_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_18_tfcuecod), 15, "%");
         lV118Contabilidad_plancuentaswwds_20_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV118Contabilidad_plancuentaswwds_20_tfcuedsc), 100, "%");
         lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe = StringUtil.PadR( StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe), 15, "%");
         lV125Contabilidad_plancuentaswwds_27_tfcuegashaber = StringUtil.PadR( StringUtil.RTrim( AV125Contabilidad_plancuentaswwds_27_tfcuegashaber), 15, "%");
         /* Using cursor P006G2 */
         pr_default.execute(0, new Object[] {lV101Contabilidad_plancuentaswwds_3_cuecod1, lV101Contabilidad_plancuentaswwds_3_cuecod1, lV102Contabilidad_plancuentaswwds_4_cuedsc1, lV102Contabilidad_plancuentaswwds_4_cuedsc1, AV103Contabilidad_plancuentaswwds_5_cuemov1, lV107Contabilidad_plancuentaswwds_9_cuecod2, lV107Contabilidad_plancuentaswwds_9_cuecod2, lV108Contabilidad_plancuentaswwds_10_cuedsc2, lV108Contabilidad_plancuentaswwds_10_cuedsc2, AV109Contabilidad_plancuentaswwds_11_cuemov2, lV113Contabilidad_plancuentaswwds_15_cuecod3, lV113Contabilidad_plancuentaswwds_15_cuecod3, lV114Contabilidad_plancuentaswwds_16_cuedsc3, lV114Contabilidad_plancuentaswwds_16_cuedsc3, AV115Contabilidad_plancuentaswwds_17_cuemov3, lV116Contabilidad_plancuentaswwds_18_tfcuecod, AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel, lV118Contabilidad_plancuentaswwds_20_tfcuedsc, AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel, lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe, AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel, lV125Contabilidad_plancuentaswwds_27_tfcuegashaber, AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A873CueSts = P006G2_A873CueSts[0];
            A110CueGasHaber = P006G2_A110CueGasHaber[0];
            n110CueGasHaber = P006G2_n110CueGasHaber[0];
            A109CueGasDebe = P006G2_A109CueGasDebe[0];
            n109CueGasDebe = P006G2_n109CueGasDebe[0];
            A859CueCos = P006G2_A859CueCos[0];
            A864CueMon = P006G2_A864CueMon[0];
            A867CueMov = P006G2_A867CueMov[0];
            A860CueDsc = P006G2_A860CueDsc[0];
            A91CueCod = P006G2_A91CueCod[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A91CueCod)) )
            {
               AV56Option = A91CueCod;
               AV57Options.Add(AV56Option, 0);
            }
            if ( AV57Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCUEDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFCueDsc = AV52SearchTxt;
         AV13TFCueDsc_Sel = "";
         AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = AV70DynamicFiltersSelector1;
         AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 = AV71DynamicFiltersOperator1;
         AV101Contabilidad_plancuentaswwds_3_cuecod1 = AV84CueCod1;
         AV102Contabilidad_plancuentaswwds_4_cuedsc1 = AV72CueDsc1;
         AV103Contabilidad_plancuentaswwds_5_cuemov1 = AV92CueMov1;
         AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 = AV74DynamicFiltersEnabled2;
         AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = AV75DynamicFiltersSelector2;
         AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 = AV76DynamicFiltersOperator2;
         AV107Contabilidad_plancuentaswwds_9_cuecod2 = AV85CueCod2;
         AV108Contabilidad_plancuentaswwds_10_cuedsc2 = AV77CueDsc2;
         AV109Contabilidad_plancuentaswwds_11_cuemov2 = AV93CueMov2;
         AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 = AV79DynamicFiltersEnabled3;
         AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = AV80DynamicFiltersSelector3;
         AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 = AV81DynamicFiltersOperator3;
         AV113Contabilidad_plancuentaswwds_15_cuecod3 = AV86CueCod3;
         AV114Contabilidad_plancuentaswwds_16_cuedsc3 = AV82CueDsc3;
         AV115Contabilidad_plancuentaswwds_17_cuemov3 = AV94CueMov3;
         AV116Contabilidad_plancuentaswwds_18_tfcuecod = AV10TFCueCod;
         AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel = AV11TFCueCod_Sel;
         AV118Contabilidad_plancuentaswwds_20_tfcuedsc = AV12TFCueDsc;
         AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel = AV13TFCueDsc_Sel;
         AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel = AV87TFCueMov_Sel;
         AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel = AV88TFCueMon_Sel;
         AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel = AV89TFCueCos_Sel;
         AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe = AV24TFCueGasDebe;
         AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = AV25TFCueGasDebe_Sel;
         AV125Contabilidad_plancuentaswwds_27_tfcuegashaber = AV26TFCueGasHaber;
         AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = AV27TFCueGasHaber_Sel;
         AV127Contabilidad_plancuentaswwds_29_tfcuests_sels = AV91TFCueSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A873CueSts ,
                                              AV127Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                              AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                              AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                              AV101Contabilidad_plancuentaswwds_3_cuecod1 ,
                                              AV102Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                              AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                              AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                              AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                              AV107Contabilidad_plancuentaswwds_9_cuecod2 ,
                                              AV108Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                              AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                              AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                              AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                              AV113Contabilidad_plancuentaswwds_15_cuecod3 ,
                                              AV114Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                              AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                              AV116Contabilidad_plancuentaswwds_18_tfcuecod ,
                                              AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                              AV118Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                              AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                              AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                              AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                              AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                              AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                              AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                              AV125Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                              AV127Contabilidad_plancuentaswwds_29_tfcuests_sels.Count ,
                                              A91CueCod ,
                                              A860CueDsc ,
                                              A867CueMov ,
                                              AV103Contabilidad_plancuentaswwds_5_cuemov1 ,
                                              AV109Contabilidad_plancuentaswwds_11_cuemov2 ,
                                              AV115Contabilidad_plancuentaswwds_17_cuemov3 ,
                                              A864CueMon ,
                                              A859CueCos ,
                                              A109CueGasDebe ,
                                              A110CueGasHaber } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV101Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV101Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV102Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV102Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV107Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV107Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV108Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV108Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV113Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV113Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV114Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV114Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV116Contabilidad_plancuentaswwds_18_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_18_tfcuecod), 15, "%");
         lV118Contabilidad_plancuentaswwds_20_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV118Contabilidad_plancuentaswwds_20_tfcuedsc), 100, "%");
         lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe = StringUtil.PadR( StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe), 15, "%");
         lV125Contabilidad_plancuentaswwds_27_tfcuegashaber = StringUtil.PadR( StringUtil.RTrim( AV125Contabilidad_plancuentaswwds_27_tfcuegashaber), 15, "%");
         /* Using cursor P006G3 */
         pr_default.execute(1, new Object[] {lV101Contabilidad_plancuentaswwds_3_cuecod1, lV101Contabilidad_plancuentaswwds_3_cuecod1, lV102Contabilidad_plancuentaswwds_4_cuedsc1, lV102Contabilidad_plancuentaswwds_4_cuedsc1, AV103Contabilidad_plancuentaswwds_5_cuemov1, lV107Contabilidad_plancuentaswwds_9_cuecod2, lV107Contabilidad_plancuentaswwds_9_cuecod2, lV108Contabilidad_plancuentaswwds_10_cuedsc2, lV108Contabilidad_plancuentaswwds_10_cuedsc2, AV109Contabilidad_plancuentaswwds_11_cuemov2, lV113Contabilidad_plancuentaswwds_15_cuecod3, lV113Contabilidad_plancuentaswwds_15_cuecod3, lV114Contabilidad_plancuentaswwds_16_cuedsc3, lV114Contabilidad_plancuentaswwds_16_cuedsc3, AV115Contabilidad_plancuentaswwds_17_cuemov3, lV116Contabilidad_plancuentaswwds_18_tfcuecod, AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel, lV118Contabilidad_plancuentaswwds_20_tfcuedsc, AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel, lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe, AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel, lV125Contabilidad_plancuentaswwds_27_tfcuegashaber, AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6G3 = false;
            A860CueDsc = P006G3_A860CueDsc[0];
            A873CueSts = P006G3_A873CueSts[0];
            A110CueGasHaber = P006G3_A110CueGasHaber[0];
            n110CueGasHaber = P006G3_n110CueGasHaber[0];
            A109CueGasDebe = P006G3_A109CueGasDebe[0];
            n109CueGasDebe = P006G3_n109CueGasDebe[0];
            A859CueCos = P006G3_A859CueCos[0];
            A864CueMon = P006G3_A864CueMon[0];
            A867CueMov = P006G3_A867CueMov[0];
            A91CueCod = P006G3_A91CueCod[0];
            AV64count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006G3_A860CueDsc[0], A860CueDsc) == 0 ) )
            {
               BRK6G3 = false;
               A91CueCod = P006G3_A91CueCod[0];
               AV64count = (long)(AV64count+1);
               BRK6G3 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A860CueDsc)) )
            {
               AV56Option = A860CueDsc;
               AV57Options.Add(AV56Option, 0);
               AV62OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV64count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV57Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6G3 )
            {
               BRK6G3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCUEGASDEBEOPTIONS' Routine */
         returnInSub = false;
         AV24TFCueGasDebe = AV52SearchTxt;
         AV25TFCueGasDebe_Sel = "";
         AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = AV70DynamicFiltersSelector1;
         AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 = AV71DynamicFiltersOperator1;
         AV101Contabilidad_plancuentaswwds_3_cuecod1 = AV84CueCod1;
         AV102Contabilidad_plancuentaswwds_4_cuedsc1 = AV72CueDsc1;
         AV103Contabilidad_plancuentaswwds_5_cuemov1 = AV92CueMov1;
         AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 = AV74DynamicFiltersEnabled2;
         AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = AV75DynamicFiltersSelector2;
         AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 = AV76DynamicFiltersOperator2;
         AV107Contabilidad_plancuentaswwds_9_cuecod2 = AV85CueCod2;
         AV108Contabilidad_plancuentaswwds_10_cuedsc2 = AV77CueDsc2;
         AV109Contabilidad_plancuentaswwds_11_cuemov2 = AV93CueMov2;
         AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 = AV79DynamicFiltersEnabled3;
         AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = AV80DynamicFiltersSelector3;
         AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 = AV81DynamicFiltersOperator3;
         AV113Contabilidad_plancuentaswwds_15_cuecod3 = AV86CueCod3;
         AV114Contabilidad_plancuentaswwds_16_cuedsc3 = AV82CueDsc3;
         AV115Contabilidad_plancuentaswwds_17_cuemov3 = AV94CueMov3;
         AV116Contabilidad_plancuentaswwds_18_tfcuecod = AV10TFCueCod;
         AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel = AV11TFCueCod_Sel;
         AV118Contabilidad_plancuentaswwds_20_tfcuedsc = AV12TFCueDsc;
         AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel = AV13TFCueDsc_Sel;
         AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel = AV87TFCueMov_Sel;
         AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel = AV88TFCueMon_Sel;
         AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel = AV89TFCueCos_Sel;
         AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe = AV24TFCueGasDebe;
         AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = AV25TFCueGasDebe_Sel;
         AV125Contabilidad_plancuentaswwds_27_tfcuegashaber = AV26TFCueGasHaber;
         AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = AV27TFCueGasHaber_Sel;
         AV127Contabilidad_plancuentaswwds_29_tfcuests_sels = AV91TFCueSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A873CueSts ,
                                              AV127Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                              AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                              AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                              AV101Contabilidad_plancuentaswwds_3_cuecod1 ,
                                              AV102Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                              AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                              AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                              AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                              AV107Contabilidad_plancuentaswwds_9_cuecod2 ,
                                              AV108Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                              AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                              AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                              AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                              AV113Contabilidad_plancuentaswwds_15_cuecod3 ,
                                              AV114Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                              AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                              AV116Contabilidad_plancuentaswwds_18_tfcuecod ,
                                              AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                              AV118Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                              AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                              AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                              AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                              AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                              AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                              AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                              AV125Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                              AV127Contabilidad_plancuentaswwds_29_tfcuests_sels.Count ,
                                              A91CueCod ,
                                              A860CueDsc ,
                                              A867CueMov ,
                                              AV103Contabilidad_plancuentaswwds_5_cuemov1 ,
                                              AV109Contabilidad_plancuentaswwds_11_cuemov2 ,
                                              AV115Contabilidad_plancuentaswwds_17_cuemov3 ,
                                              A864CueMon ,
                                              A859CueCos ,
                                              A109CueGasDebe ,
                                              A110CueGasHaber } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV101Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV101Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV102Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV102Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV107Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV107Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV108Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV108Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV113Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV113Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV114Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV114Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV116Contabilidad_plancuentaswwds_18_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_18_tfcuecod), 15, "%");
         lV118Contabilidad_plancuentaswwds_20_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV118Contabilidad_plancuentaswwds_20_tfcuedsc), 100, "%");
         lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe = StringUtil.PadR( StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe), 15, "%");
         lV125Contabilidad_plancuentaswwds_27_tfcuegashaber = StringUtil.PadR( StringUtil.RTrim( AV125Contabilidad_plancuentaswwds_27_tfcuegashaber), 15, "%");
         /* Using cursor P006G4 */
         pr_default.execute(2, new Object[] {lV101Contabilidad_plancuentaswwds_3_cuecod1, lV101Contabilidad_plancuentaswwds_3_cuecod1, lV102Contabilidad_plancuentaswwds_4_cuedsc1, lV102Contabilidad_plancuentaswwds_4_cuedsc1, AV103Contabilidad_plancuentaswwds_5_cuemov1, lV107Contabilidad_plancuentaswwds_9_cuecod2, lV107Contabilidad_plancuentaswwds_9_cuecod2, lV108Contabilidad_plancuentaswwds_10_cuedsc2, lV108Contabilidad_plancuentaswwds_10_cuedsc2, AV109Contabilidad_plancuentaswwds_11_cuemov2, lV113Contabilidad_plancuentaswwds_15_cuecod3, lV113Contabilidad_plancuentaswwds_15_cuecod3, lV114Contabilidad_plancuentaswwds_16_cuedsc3, lV114Contabilidad_plancuentaswwds_16_cuedsc3, AV115Contabilidad_plancuentaswwds_17_cuemov3, lV116Contabilidad_plancuentaswwds_18_tfcuecod, AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel, lV118Contabilidad_plancuentaswwds_20_tfcuedsc, AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel, lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe, AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel, lV125Contabilidad_plancuentaswwds_27_tfcuegashaber, AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6G5 = false;
            A109CueGasDebe = P006G4_A109CueGasDebe[0];
            n109CueGasDebe = P006G4_n109CueGasDebe[0];
            A873CueSts = P006G4_A873CueSts[0];
            A110CueGasHaber = P006G4_A110CueGasHaber[0];
            n110CueGasHaber = P006G4_n110CueGasHaber[0];
            A859CueCos = P006G4_A859CueCos[0];
            A864CueMon = P006G4_A864CueMon[0];
            A867CueMov = P006G4_A867CueMov[0];
            A860CueDsc = P006G4_A860CueDsc[0];
            A91CueCod = P006G4_A91CueCod[0];
            AV64count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006G4_A109CueGasDebe[0], A109CueGasDebe) == 0 ) )
            {
               BRK6G5 = false;
               A91CueCod = P006G4_A91CueCod[0];
               AV64count = (long)(AV64count+1);
               BRK6G5 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A109CueGasDebe)) )
            {
               AV56Option = A109CueGasDebe;
               AV57Options.Add(AV56Option, 0);
               AV62OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV64count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV57Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6G5 )
            {
               BRK6G5 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADCUEGASHABEROPTIONS' Routine */
         returnInSub = false;
         AV26TFCueGasHaber = AV52SearchTxt;
         AV27TFCueGasHaber_Sel = "";
         AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = AV70DynamicFiltersSelector1;
         AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 = AV71DynamicFiltersOperator1;
         AV101Contabilidad_plancuentaswwds_3_cuecod1 = AV84CueCod1;
         AV102Contabilidad_plancuentaswwds_4_cuedsc1 = AV72CueDsc1;
         AV103Contabilidad_plancuentaswwds_5_cuemov1 = AV92CueMov1;
         AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 = AV74DynamicFiltersEnabled2;
         AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = AV75DynamicFiltersSelector2;
         AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 = AV76DynamicFiltersOperator2;
         AV107Contabilidad_plancuentaswwds_9_cuecod2 = AV85CueCod2;
         AV108Contabilidad_plancuentaswwds_10_cuedsc2 = AV77CueDsc2;
         AV109Contabilidad_plancuentaswwds_11_cuemov2 = AV93CueMov2;
         AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 = AV79DynamicFiltersEnabled3;
         AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = AV80DynamicFiltersSelector3;
         AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 = AV81DynamicFiltersOperator3;
         AV113Contabilidad_plancuentaswwds_15_cuecod3 = AV86CueCod3;
         AV114Contabilidad_plancuentaswwds_16_cuedsc3 = AV82CueDsc3;
         AV115Contabilidad_plancuentaswwds_17_cuemov3 = AV94CueMov3;
         AV116Contabilidad_plancuentaswwds_18_tfcuecod = AV10TFCueCod;
         AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel = AV11TFCueCod_Sel;
         AV118Contabilidad_plancuentaswwds_20_tfcuedsc = AV12TFCueDsc;
         AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel = AV13TFCueDsc_Sel;
         AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel = AV87TFCueMov_Sel;
         AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel = AV88TFCueMon_Sel;
         AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel = AV89TFCueCos_Sel;
         AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe = AV24TFCueGasDebe;
         AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = AV25TFCueGasDebe_Sel;
         AV125Contabilidad_plancuentaswwds_27_tfcuegashaber = AV26TFCueGasHaber;
         AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = AV27TFCueGasHaber_Sel;
         AV127Contabilidad_plancuentaswwds_29_tfcuests_sels = AV91TFCueSts_Sels;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A873CueSts ,
                                              AV127Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                              AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                              AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                              AV101Contabilidad_plancuentaswwds_3_cuecod1 ,
                                              AV102Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                              AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                              AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                              AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                              AV107Contabilidad_plancuentaswwds_9_cuecod2 ,
                                              AV108Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                              AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                              AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                              AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                              AV113Contabilidad_plancuentaswwds_15_cuecod3 ,
                                              AV114Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                              AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                              AV116Contabilidad_plancuentaswwds_18_tfcuecod ,
                                              AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                              AV118Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                              AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                              AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                              AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                              AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                              AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                              AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                              AV125Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                              AV127Contabilidad_plancuentaswwds_29_tfcuests_sels.Count ,
                                              A91CueCod ,
                                              A860CueDsc ,
                                              A867CueMov ,
                                              AV103Contabilidad_plancuentaswwds_5_cuemov1 ,
                                              AV109Contabilidad_plancuentaswwds_11_cuemov2 ,
                                              AV115Contabilidad_plancuentaswwds_17_cuemov3 ,
                                              A864CueMon ,
                                              A859CueCos ,
                                              A109CueGasDebe ,
                                              A110CueGasHaber } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV101Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV101Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV102Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV102Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV107Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV107Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV108Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV108Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV113Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV113Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV114Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV114Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV116Contabilidad_plancuentaswwds_18_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_18_tfcuecod), 15, "%");
         lV118Contabilidad_plancuentaswwds_20_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV118Contabilidad_plancuentaswwds_20_tfcuedsc), 100, "%");
         lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe = StringUtil.PadR( StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe), 15, "%");
         lV125Contabilidad_plancuentaswwds_27_tfcuegashaber = StringUtil.PadR( StringUtil.RTrim( AV125Contabilidad_plancuentaswwds_27_tfcuegashaber), 15, "%");
         /* Using cursor P006G5 */
         pr_default.execute(3, new Object[] {lV101Contabilidad_plancuentaswwds_3_cuecod1, lV101Contabilidad_plancuentaswwds_3_cuecod1, lV102Contabilidad_plancuentaswwds_4_cuedsc1, lV102Contabilidad_plancuentaswwds_4_cuedsc1, AV103Contabilidad_plancuentaswwds_5_cuemov1, lV107Contabilidad_plancuentaswwds_9_cuecod2, lV107Contabilidad_plancuentaswwds_9_cuecod2, lV108Contabilidad_plancuentaswwds_10_cuedsc2, lV108Contabilidad_plancuentaswwds_10_cuedsc2, AV109Contabilidad_plancuentaswwds_11_cuemov2, lV113Contabilidad_plancuentaswwds_15_cuecod3, lV113Contabilidad_plancuentaswwds_15_cuecod3, lV114Contabilidad_plancuentaswwds_16_cuedsc3, lV114Contabilidad_plancuentaswwds_16_cuedsc3, AV115Contabilidad_plancuentaswwds_17_cuemov3, lV116Contabilidad_plancuentaswwds_18_tfcuecod, AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel, lV118Contabilidad_plancuentaswwds_20_tfcuedsc, AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel, lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe, AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel, lV125Contabilidad_plancuentaswwds_27_tfcuegashaber, AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6G7 = false;
            A110CueGasHaber = P006G5_A110CueGasHaber[0];
            n110CueGasHaber = P006G5_n110CueGasHaber[0];
            A873CueSts = P006G5_A873CueSts[0];
            A109CueGasDebe = P006G5_A109CueGasDebe[0];
            n109CueGasDebe = P006G5_n109CueGasDebe[0];
            A859CueCos = P006G5_A859CueCos[0];
            A864CueMon = P006G5_A864CueMon[0];
            A867CueMov = P006G5_A867CueMov[0];
            A860CueDsc = P006G5_A860CueDsc[0];
            A91CueCod = P006G5_A91CueCod[0];
            AV64count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P006G5_A110CueGasHaber[0], A110CueGasHaber) == 0 ) )
            {
               BRK6G7 = false;
               A91CueCod = P006G5_A91CueCod[0];
               AV64count = (long)(AV64count+1);
               BRK6G7 = true;
               pr_default.readNext(3);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A110CueGasHaber)) )
            {
               AV56Option = A110CueGasHaber;
               AV57Options.Add(AV56Option, 0);
               AV62OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV64count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV57Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6G7 )
            {
               BRK6G7 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV58OptionsJson = "";
         AV61OptionsDescJson = "";
         AV63OptionIndexesJson = "";
         AV57Options = new GxSimpleCollection<string>();
         AV60OptionsDesc = new GxSimpleCollection<string>();
         AV62OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV65Session = context.GetSession();
         AV67GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV68GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFCueCod = "";
         AV11TFCueCod_Sel = "";
         AV12TFCueDsc = "";
         AV13TFCueDsc_Sel = "";
         AV24TFCueGasDebe = "";
         AV25TFCueGasDebe_Sel = "";
         AV26TFCueGasHaber = "";
         AV27TFCueGasHaber_Sel = "";
         AV90TFCueSts_SelsJson = "";
         AV91TFCueSts_Sels = new GxSimpleCollection<short>();
         AV69GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV70DynamicFiltersSelector1 = "";
         AV84CueCod1 = "";
         AV72CueDsc1 = "";
         AV75DynamicFiltersSelector2 = "";
         AV85CueCod2 = "";
         AV77CueDsc2 = "";
         AV80DynamicFiltersSelector3 = "";
         AV86CueCod3 = "";
         AV82CueDsc3 = "";
         AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = "";
         AV101Contabilidad_plancuentaswwds_3_cuecod1 = "";
         AV102Contabilidad_plancuentaswwds_4_cuedsc1 = "";
         AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = "";
         AV107Contabilidad_plancuentaswwds_9_cuecod2 = "";
         AV108Contabilidad_plancuentaswwds_10_cuedsc2 = "";
         AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = "";
         AV113Contabilidad_plancuentaswwds_15_cuecod3 = "";
         AV114Contabilidad_plancuentaswwds_16_cuedsc3 = "";
         AV116Contabilidad_plancuentaswwds_18_tfcuecod = "";
         AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel = "";
         AV118Contabilidad_plancuentaswwds_20_tfcuedsc = "";
         AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel = "";
         AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe = "";
         AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = "";
         AV125Contabilidad_plancuentaswwds_27_tfcuegashaber = "";
         AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = "";
         AV127Contabilidad_plancuentaswwds_29_tfcuests_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV101Contabilidad_plancuentaswwds_3_cuecod1 = "";
         lV102Contabilidad_plancuentaswwds_4_cuedsc1 = "";
         lV107Contabilidad_plancuentaswwds_9_cuecod2 = "";
         lV108Contabilidad_plancuentaswwds_10_cuedsc2 = "";
         lV113Contabilidad_plancuentaswwds_15_cuecod3 = "";
         lV114Contabilidad_plancuentaswwds_16_cuedsc3 = "";
         lV116Contabilidad_plancuentaswwds_18_tfcuecod = "";
         lV118Contabilidad_plancuentaswwds_20_tfcuedsc = "";
         lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe = "";
         lV125Contabilidad_plancuentaswwds_27_tfcuegashaber = "";
         A91CueCod = "";
         A860CueDsc = "";
         A109CueGasDebe = "";
         A110CueGasHaber = "";
         P006G2_A873CueSts = new short[1] ;
         P006G2_A110CueGasHaber = new string[] {""} ;
         P006G2_n110CueGasHaber = new bool[] {false} ;
         P006G2_A109CueGasDebe = new string[] {""} ;
         P006G2_n109CueGasDebe = new bool[] {false} ;
         P006G2_A859CueCos = new short[1] ;
         P006G2_A864CueMon = new short[1] ;
         P006G2_A867CueMov = new short[1] ;
         P006G2_A860CueDsc = new string[] {""} ;
         P006G2_A91CueCod = new string[] {""} ;
         AV56Option = "";
         P006G3_A860CueDsc = new string[] {""} ;
         P006G3_A873CueSts = new short[1] ;
         P006G3_A110CueGasHaber = new string[] {""} ;
         P006G3_n110CueGasHaber = new bool[] {false} ;
         P006G3_A109CueGasDebe = new string[] {""} ;
         P006G3_n109CueGasDebe = new bool[] {false} ;
         P006G3_A859CueCos = new short[1] ;
         P006G3_A864CueMon = new short[1] ;
         P006G3_A867CueMov = new short[1] ;
         P006G3_A91CueCod = new string[] {""} ;
         P006G4_A109CueGasDebe = new string[] {""} ;
         P006G4_n109CueGasDebe = new bool[] {false} ;
         P006G4_A873CueSts = new short[1] ;
         P006G4_A110CueGasHaber = new string[] {""} ;
         P006G4_n110CueGasHaber = new bool[] {false} ;
         P006G4_A859CueCos = new short[1] ;
         P006G4_A864CueMon = new short[1] ;
         P006G4_A867CueMov = new short[1] ;
         P006G4_A860CueDsc = new string[] {""} ;
         P006G4_A91CueCod = new string[] {""} ;
         P006G5_A110CueGasHaber = new string[] {""} ;
         P006G5_n110CueGasHaber = new bool[] {false} ;
         P006G5_A873CueSts = new short[1] ;
         P006G5_A109CueGasDebe = new string[] {""} ;
         P006G5_n109CueGasDebe = new bool[] {false} ;
         P006G5_A859CueCos = new short[1] ;
         P006G5_A864CueMon = new short[1] ;
         P006G5_A867CueMov = new short[1] ;
         P006G5_A860CueDsc = new string[] {""} ;
         P006G5_A91CueCod = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.plancuentaswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006G2_A873CueSts, P006G2_A110CueGasHaber, P006G2_n110CueGasHaber, P006G2_A109CueGasDebe, P006G2_n109CueGasDebe, P006G2_A859CueCos, P006G2_A864CueMon, P006G2_A867CueMov, P006G2_A860CueDsc, P006G2_A91CueCod
               }
               , new Object[] {
               P006G3_A860CueDsc, P006G3_A873CueSts, P006G3_A110CueGasHaber, P006G3_n110CueGasHaber, P006G3_A109CueGasDebe, P006G3_n109CueGasDebe, P006G3_A859CueCos, P006G3_A864CueMon, P006G3_A867CueMov, P006G3_A91CueCod
               }
               , new Object[] {
               P006G4_A109CueGasDebe, P006G4_n109CueGasDebe, P006G4_A873CueSts, P006G4_A110CueGasHaber, P006G4_n110CueGasHaber, P006G4_A859CueCos, P006G4_A864CueMon, P006G4_A867CueMov, P006G4_A860CueDsc, P006G4_A91CueCod
               }
               , new Object[] {
               P006G5_A110CueGasHaber, P006G5_n110CueGasHaber, P006G5_A873CueSts, P006G5_A109CueGasDebe, P006G5_n109CueGasDebe, P006G5_A859CueCos, P006G5_A864CueMon, P006G5_A867CueMov, P006G5_A860CueDsc, P006G5_A91CueCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV87TFCueMov_Sel ;
      private short AV88TFCueMon_Sel ;
      private short AV89TFCueCos_Sel ;
      private short AV71DynamicFiltersOperator1 ;
      private short AV92CueMov1 ;
      private short AV76DynamicFiltersOperator2 ;
      private short AV93CueMov2 ;
      private short AV81DynamicFiltersOperator3 ;
      private short AV94CueMov3 ;
      private short AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ;
      private short AV103Contabilidad_plancuentaswwds_5_cuemov1 ;
      private short AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ;
      private short AV109Contabilidad_plancuentaswwds_11_cuemov2 ;
      private short AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ;
      private short AV115Contabilidad_plancuentaswwds_17_cuemov3 ;
      private short AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel ;
      private short AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel ;
      private short AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel ;
      private short A873CueSts ;
      private short A867CueMov ;
      private short A864CueMon ;
      private short A859CueCos ;
      private int AV97GXV1 ;
      private int AV127Contabilidad_plancuentaswwds_29_tfcuests_sels_Count ;
      private long AV64count ;
      private string AV10TFCueCod ;
      private string AV11TFCueCod_Sel ;
      private string AV12TFCueDsc ;
      private string AV13TFCueDsc_Sel ;
      private string AV24TFCueGasDebe ;
      private string AV25TFCueGasDebe_Sel ;
      private string AV26TFCueGasHaber ;
      private string AV27TFCueGasHaber_Sel ;
      private string AV84CueCod1 ;
      private string AV72CueDsc1 ;
      private string AV85CueCod2 ;
      private string AV77CueDsc2 ;
      private string AV86CueCod3 ;
      private string AV82CueDsc3 ;
      private string AV101Contabilidad_plancuentaswwds_3_cuecod1 ;
      private string AV102Contabilidad_plancuentaswwds_4_cuedsc1 ;
      private string AV107Contabilidad_plancuentaswwds_9_cuecod2 ;
      private string AV108Contabilidad_plancuentaswwds_10_cuedsc2 ;
      private string AV113Contabilidad_plancuentaswwds_15_cuecod3 ;
      private string AV114Contabilidad_plancuentaswwds_16_cuedsc3 ;
      private string AV116Contabilidad_plancuentaswwds_18_tfcuecod ;
      private string AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel ;
      private string AV118Contabilidad_plancuentaswwds_20_tfcuedsc ;
      private string AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel ;
      private string AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe ;
      private string AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ;
      private string AV125Contabilidad_plancuentaswwds_27_tfcuegashaber ;
      private string AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ;
      private string scmdbuf ;
      private string lV101Contabilidad_plancuentaswwds_3_cuecod1 ;
      private string lV102Contabilidad_plancuentaswwds_4_cuedsc1 ;
      private string lV107Contabilidad_plancuentaswwds_9_cuecod2 ;
      private string lV108Contabilidad_plancuentaswwds_10_cuedsc2 ;
      private string lV113Contabilidad_plancuentaswwds_15_cuecod3 ;
      private string lV114Contabilidad_plancuentaswwds_16_cuedsc3 ;
      private string lV116Contabilidad_plancuentaswwds_18_tfcuecod ;
      private string lV118Contabilidad_plancuentaswwds_20_tfcuedsc ;
      private string lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe ;
      private string lV125Contabilidad_plancuentaswwds_27_tfcuegashaber ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string A109CueGasDebe ;
      private string A110CueGasHaber ;
      private bool returnInSub ;
      private bool AV74DynamicFiltersEnabled2 ;
      private bool AV79DynamicFiltersEnabled3 ;
      private bool AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ;
      private bool AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ;
      private bool n110CueGasHaber ;
      private bool n109CueGasDebe ;
      private bool BRK6G3 ;
      private bool BRK6G5 ;
      private bool BRK6G7 ;
      private string AV58OptionsJson ;
      private string AV61OptionsDescJson ;
      private string AV63OptionIndexesJson ;
      private string AV90TFCueSts_SelsJson ;
      private string AV54DDOName ;
      private string AV52SearchTxt ;
      private string AV53SearchTxtTo ;
      private string AV70DynamicFiltersSelector1 ;
      private string AV75DynamicFiltersSelector2 ;
      private string AV80DynamicFiltersSelector3 ;
      private string AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ;
      private string AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ;
      private string AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ;
      private string AV56Option ;
      private GxSimpleCollection<short> AV91TFCueSts_Sels ;
      private GxSimpleCollection<short> AV127Contabilidad_plancuentaswwds_29_tfcuests_sels ;
      private IGxSession AV65Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006G2_A873CueSts ;
      private string[] P006G2_A110CueGasHaber ;
      private bool[] P006G2_n110CueGasHaber ;
      private string[] P006G2_A109CueGasDebe ;
      private bool[] P006G2_n109CueGasDebe ;
      private short[] P006G2_A859CueCos ;
      private short[] P006G2_A864CueMon ;
      private short[] P006G2_A867CueMov ;
      private string[] P006G2_A860CueDsc ;
      private string[] P006G2_A91CueCod ;
      private string[] P006G3_A860CueDsc ;
      private short[] P006G3_A873CueSts ;
      private string[] P006G3_A110CueGasHaber ;
      private bool[] P006G3_n110CueGasHaber ;
      private string[] P006G3_A109CueGasDebe ;
      private bool[] P006G3_n109CueGasDebe ;
      private short[] P006G3_A859CueCos ;
      private short[] P006G3_A864CueMon ;
      private short[] P006G3_A867CueMov ;
      private string[] P006G3_A91CueCod ;
      private string[] P006G4_A109CueGasDebe ;
      private bool[] P006G4_n109CueGasDebe ;
      private short[] P006G4_A873CueSts ;
      private string[] P006G4_A110CueGasHaber ;
      private bool[] P006G4_n110CueGasHaber ;
      private short[] P006G4_A859CueCos ;
      private short[] P006G4_A864CueMon ;
      private short[] P006G4_A867CueMov ;
      private string[] P006G4_A860CueDsc ;
      private string[] P006G4_A91CueCod ;
      private string[] P006G5_A110CueGasHaber ;
      private bool[] P006G5_n110CueGasHaber ;
      private short[] P006G5_A873CueSts ;
      private string[] P006G5_A109CueGasDebe ;
      private bool[] P006G5_n109CueGasDebe ;
      private short[] P006G5_A859CueCos ;
      private short[] P006G5_A864CueMon ;
      private short[] P006G5_A867CueMov ;
      private string[] P006G5_A860CueDsc ;
      private string[] P006G5_A91CueCod ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV57Options ;
      private GxSimpleCollection<string> AV60OptionsDesc ;
      private GxSimpleCollection<string> AV62OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV67GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV68GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV69GridStateDynamicFilter ;
   }

   public class plancuentaswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006G2( IGxContext context ,
                                             short A873CueSts ,
                                             GxSimpleCollection<short> AV127Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                             string AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                             short AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                             string AV101Contabilidad_plancuentaswwds_3_cuecod1 ,
                                             string AV102Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                             bool AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                             string AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                             short AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                             string AV107Contabilidad_plancuentaswwds_9_cuecod2 ,
                                             string AV108Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                             bool AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                             string AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                             short AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                             string AV113Contabilidad_plancuentaswwds_15_cuecod3 ,
                                             string AV114Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                             string AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                             string AV116Contabilidad_plancuentaswwds_18_tfcuecod ,
                                             string AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                             string AV118Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                             short AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                             short AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                             short AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                             string AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                             string AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                             string AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                             string AV125Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                             int AV127Contabilidad_plancuentaswwds_29_tfcuests_sels_Count ,
                                             string A91CueCod ,
                                             string A860CueDsc ,
                                             short A867CueMov ,
                                             short AV103Contabilidad_plancuentaswwds_5_cuemov1 ,
                                             short AV109Contabilidad_plancuentaswwds_11_cuemov2 ,
                                             short AV115Contabilidad_plancuentaswwds_17_cuemov3 ,
                                             short A864CueMon ,
                                             short A859CueCos ,
                                             string A109CueGasDebe ,
                                             string A110CueGasHaber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[23];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [CueSts], NULL AS [CueGasHaber], NULL AS [CueGasDebe], NULL AS [CueCos], NULL AS [CueMon], NULL AS [CueMov], NULL AS [CueDsc], [CueCod] FROM ( SELECT TOP(100) PERCENT [CueSts], [CueGasHaber], [CueGasDebe], [CueCos], [CueMon], [CueMov], [CueDsc], [CueCod] FROM [CBPLANCUENTA]";
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV101Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV101Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV102Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV102Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEMOV") == 0 )
         {
            AddWhere(sWhereString, "([CueMov] = @AV103Contabilidad_plancuentaswwds_5_cuemov1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV107Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV107Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV108Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV108Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV109Contabilidad_plancuentaswwds_11_cuemov2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV113Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV113Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV114Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV114Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV115Contabilidad_plancuentaswwds_17_cuemov3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_18_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV116Contabilidad_plancuentaswwds_18_tfcuecod)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "([CueCod] = @AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Contabilidad_plancuentaswwds_20_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV118Contabilidad_plancuentaswwds_20_tfcuedsc)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "([CueDsc] = @AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMov] = 1)");
         }
         if ( AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMov] = 0)");
         }
         if ( AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMon] = 1)");
         }
         if ( AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMon] = 0)");
         }
         if ( AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel == 1 )
         {
            AddWhere(sWhereString, "([CueCos] = 1)");
         }
         if ( AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel == 2 )
         {
            AddWhere(sWhereString, "([CueCos] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe)) ) )
         {
            AddWhere(sWhereString, "([CueGasDebe] like @lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) )
         {
            AddWhere(sWhereString, "([CueGasDebe] = @AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Contabilidad_plancuentaswwds_27_tfcuegashaber)) ) )
         {
            AddWhere(sWhereString, "([CueGasHaber] like @lV125Contabilidad_plancuentaswwds_27_tfcuegashaber)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) )
         {
            AddWhere(sWhereString, "([CueGasHaber] = @AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( AV127Contabilidad_plancuentaswwds_29_tfcuests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV127Contabilidad_plancuentaswwds_29_tfcuests_sels, "[CueSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueCod]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [CueCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006G3( IGxContext context ,
                                             short A873CueSts ,
                                             GxSimpleCollection<short> AV127Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                             string AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                             short AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                             string AV101Contabilidad_plancuentaswwds_3_cuecod1 ,
                                             string AV102Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                             bool AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                             string AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                             short AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                             string AV107Contabilidad_plancuentaswwds_9_cuecod2 ,
                                             string AV108Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                             bool AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                             string AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                             short AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                             string AV113Contabilidad_plancuentaswwds_15_cuecod3 ,
                                             string AV114Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                             string AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                             string AV116Contabilidad_plancuentaswwds_18_tfcuecod ,
                                             string AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                             string AV118Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                             short AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                             short AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                             short AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                             string AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                             string AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                             string AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                             string AV125Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                             int AV127Contabilidad_plancuentaswwds_29_tfcuests_sels_Count ,
                                             string A91CueCod ,
                                             string A860CueDsc ,
                                             short A867CueMov ,
                                             short AV103Contabilidad_plancuentaswwds_5_cuemov1 ,
                                             short AV109Contabilidad_plancuentaswwds_11_cuemov2 ,
                                             short AV115Contabilidad_plancuentaswwds_17_cuemov3 ,
                                             short A864CueMon ,
                                             short A859CueCos ,
                                             string A109CueGasDebe ,
                                             string A110CueGasHaber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[23];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [CueDsc], [CueSts], [CueGasHaber], [CueGasDebe], [CueCos], [CueMon], [CueMov], [CueCod] FROM [CBPLANCUENTA]";
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV101Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV101Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV102Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV102Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEMOV") == 0 )
         {
            AddWhere(sWhereString, "([CueMov] = @AV103Contabilidad_plancuentaswwds_5_cuemov1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV107Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV107Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV108Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV108Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV109Contabilidad_plancuentaswwds_11_cuemov2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV113Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV113Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV114Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV114Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV115Contabilidad_plancuentaswwds_17_cuemov3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_18_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV116Contabilidad_plancuentaswwds_18_tfcuecod)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "([CueCod] = @AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Contabilidad_plancuentaswwds_20_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV118Contabilidad_plancuentaswwds_20_tfcuedsc)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "([CueDsc] = @AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMov] = 1)");
         }
         if ( AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMov] = 0)");
         }
         if ( AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMon] = 1)");
         }
         if ( AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMon] = 0)");
         }
         if ( AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel == 1 )
         {
            AddWhere(sWhereString, "([CueCos] = 1)");
         }
         if ( AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel == 2 )
         {
            AddWhere(sWhereString, "([CueCos] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe)) ) )
         {
            AddWhere(sWhereString, "([CueGasDebe] like @lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) )
         {
            AddWhere(sWhereString, "([CueGasDebe] = @AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Contabilidad_plancuentaswwds_27_tfcuegashaber)) ) )
         {
            AddWhere(sWhereString, "([CueGasHaber] like @lV125Contabilidad_plancuentaswwds_27_tfcuegashaber)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) )
         {
            AddWhere(sWhereString, "([CueGasHaber] = @AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV127Contabilidad_plancuentaswwds_29_tfcuests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV127Contabilidad_plancuentaswwds_29_tfcuests_sels, "[CueSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006G4( IGxContext context ,
                                             short A873CueSts ,
                                             GxSimpleCollection<short> AV127Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                             string AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                             short AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                             string AV101Contabilidad_plancuentaswwds_3_cuecod1 ,
                                             string AV102Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                             bool AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                             string AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                             short AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                             string AV107Contabilidad_plancuentaswwds_9_cuecod2 ,
                                             string AV108Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                             bool AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                             string AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                             short AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                             string AV113Contabilidad_plancuentaswwds_15_cuecod3 ,
                                             string AV114Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                             string AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                             string AV116Contabilidad_plancuentaswwds_18_tfcuecod ,
                                             string AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                             string AV118Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                             short AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                             short AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                             short AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                             string AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                             string AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                             string AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                             string AV125Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                             int AV127Contabilidad_plancuentaswwds_29_tfcuests_sels_Count ,
                                             string A91CueCod ,
                                             string A860CueDsc ,
                                             short A867CueMov ,
                                             short AV103Contabilidad_plancuentaswwds_5_cuemov1 ,
                                             short AV109Contabilidad_plancuentaswwds_11_cuemov2 ,
                                             short AV115Contabilidad_plancuentaswwds_17_cuemov3 ,
                                             short A864CueMon ,
                                             short A859CueCos ,
                                             string A109CueGasDebe ,
                                             string A110CueGasHaber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[23];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [CueGasDebe], [CueSts], [CueGasHaber], [CueCos], [CueMon], [CueMov], [CueDsc], [CueCod] FROM [CBPLANCUENTA]";
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV101Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV101Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV102Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV102Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEMOV") == 0 )
         {
            AddWhere(sWhereString, "([CueMov] = @AV103Contabilidad_plancuentaswwds_5_cuemov1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV107Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV107Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV108Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV108Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV109Contabilidad_plancuentaswwds_11_cuemov2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV113Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV113Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV114Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV114Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV115Contabilidad_plancuentaswwds_17_cuemov3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_18_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV116Contabilidad_plancuentaswwds_18_tfcuecod)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "([CueCod] = @AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Contabilidad_plancuentaswwds_20_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV118Contabilidad_plancuentaswwds_20_tfcuedsc)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "([CueDsc] = @AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMov] = 1)");
         }
         if ( AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMov] = 0)");
         }
         if ( AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMon] = 1)");
         }
         if ( AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMon] = 0)");
         }
         if ( AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel == 1 )
         {
            AddWhere(sWhereString, "([CueCos] = 1)");
         }
         if ( AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel == 2 )
         {
            AddWhere(sWhereString, "([CueCos] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe)) ) )
         {
            AddWhere(sWhereString, "([CueGasDebe] like @lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) )
         {
            AddWhere(sWhereString, "([CueGasDebe] = @AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Contabilidad_plancuentaswwds_27_tfcuegashaber)) ) )
         {
            AddWhere(sWhereString, "([CueGasHaber] like @lV125Contabilidad_plancuentaswwds_27_tfcuegashaber)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) )
         {
            AddWhere(sWhereString, "([CueGasHaber] = @AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( AV127Contabilidad_plancuentaswwds_29_tfcuests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV127Contabilidad_plancuentaswwds_29_tfcuests_sels, "[CueSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueGasDebe]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P006G5( IGxContext context ,
                                             short A873CueSts ,
                                             GxSimpleCollection<short> AV127Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                             string AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                             short AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                             string AV101Contabilidad_plancuentaswwds_3_cuecod1 ,
                                             string AV102Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                             bool AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                             string AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                             short AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                             string AV107Contabilidad_plancuentaswwds_9_cuecod2 ,
                                             string AV108Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                             bool AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                             string AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                             short AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                             string AV113Contabilidad_plancuentaswwds_15_cuecod3 ,
                                             string AV114Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                             string AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                             string AV116Contabilidad_plancuentaswwds_18_tfcuecod ,
                                             string AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                             string AV118Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                             short AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                             short AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                             short AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                             string AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                             string AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                             string AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                             string AV125Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                             int AV127Contabilidad_plancuentaswwds_29_tfcuests_sels_Count ,
                                             string A91CueCod ,
                                             string A860CueDsc ,
                                             short A867CueMov ,
                                             short AV103Contabilidad_plancuentaswwds_5_cuemov1 ,
                                             short AV109Contabilidad_plancuentaswwds_11_cuemov2 ,
                                             short AV115Contabilidad_plancuentaswwds_17_cuemov3 ,
                                             short A864CueMon ,
                                             short A859CueCos ,
                                             string A109CueGasDebe ,
                                             string A110CueGasHaber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[23];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT [CueGasHaber], [CueSts], [CueGasDebe], [CueCos], [CueMon], [CueMov], [CueDsc], [CueCod] FROM [CBPLANCUENTA]";
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV101Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV101Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV102Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV100Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV102Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV99Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEMOV") == 0 )
         {
            AddWhere(sWhereString, "([CueMov] = @AV103Contabilidad_plancuentaswwds_5_cuemov1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV107Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV107Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV108Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV106Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV108Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV104Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV109Contabilidad_plancuentaswwds_11_cuemov2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV113Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV113Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV114Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV112Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV114Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV110Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV115Contabilidad_plancuentaswwds_17_cuemov3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_18_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV116Contabilidad_plancuentaswwds_18_tfcuecod)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "([CueCod] = @AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Contabilidad_plancuentaswwds_20_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV118Contabilidad_plancuentaswwds_20_tfcuedsc)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "([CueDsc] = @AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMov] = 1)");
         }
         if ( AV120Contabilidad_plancuentaswwds_22_tfcuemov_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMov] = 0)");
         }
         if ( AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMon] = 1)");
         }
         if ( AV121Contabilidad_plancuentaswwds_23_tfcuemon_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMon] = 0)");
         }
         if ( AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel == 1 )
         {
            AddWhere(sWhereString, "([CueCos] = 1)");
         }
         if ( AV122Contabilidad_plancuentaswwds_24_tfcuecos_sel == 2 )
         {
            AddWhere(sWhereString, "([CueCos] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_25_tfcuegasdebe)) ) )
         {
            AddWhere(sWhereString, "([CueGasDebe] like @lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) )
         {
            AddWhere(sWhereString, "([CueGasDebe] = @AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Contabilidad_plancuentaswwds_27_tfcuegashaber)) ) )
         {
            AddWhere(sWhereString, "([CueGasHaber] like @lV125Contabilidad_plancuentaswwds_27_tfcuegashaber)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) )
         {
            AddWhere(sWhereString, "([CueGasHaber] = @AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( AV127Contabilidad_plancuentaswwds_29_tfcuests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV127Contabilidad_plancuentaswwds_29_tfcuests_sels, "[CueSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueGasHaber]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006G2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] );
               case 1 :
                     return conditional_P006G3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] );
               case 2 :
                     return conditional_P006G4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] );
               case 3 :
                     return conditional_P006G5(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] );
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
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006G2;
          prmP006G2 = new Object[] {
          new ParDef("@lV101Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV101Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV102Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV102Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@AV103Contabilidad_plancuentaswwds_5_cuemov1",GXType.Int16,1,0) ,
          new ParDef("@lV107Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV107Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV108Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV108Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@AV109Contabilidad_plancuentaswwds_11_cuemov2",GXType.Int16,1,0) ,
          new ParDef("@lV113Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV113Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV114Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV114Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV115Contabilidad_plancuentaswwds_17_cuemov3",GXType.Int16,1,0) ,
          new ParDef("@lV116Contabilidad_plancuentaswwds_18_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV118Contabilidad_plancuentaswwds_20_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe",GXType.NChar,15,0) ,
          new ParDef("@AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel",GXType.NChar,15,0) ,
          new ParDef("@lV125Contabilidad_plancuentaswwds_27_tfcuegashaber",GXType.NChar,15,0) ,
          new ParDef("@AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel",GXType.NChar,15,0)
          };
          Object[] prmP006G3;
          prmP006G3 = new Object[] {
          new ParDef("@lV101Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV101Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV102Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV102Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@AV103Contabilidad_plancuentaswwds_5_cuemov1",GXType.Int16,1,0) ,
          new ParDef("@lV107Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV107Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV108Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV108Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@AV109Contabilidad_plancuentaswwds_11_cuemov2",GXType.Int16,1,0) ,
          new ParDef("@lV113Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV113Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV114Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV114Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV115Contabilidad_plancuentaswwds_17_cuemov3",GXType.Int16,1,0) ,
          new ParDef("@lV116Contabilidad_plancuentaswwds_18_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV118Contabilidad_plancuentaswwds_20_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe",GXType.NChar,15,0) ,
          new ParDef("@AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel",GXType.NChar,15,0) ,
          new ParDef("@lV125Contabilidad_plancuentaswwds_27_tfcuegashaber",GXType.NChar,15,0) ,
          new ParDef("@AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel",GXType.NChar,15,0)
          };
          Object[] prmP006G4;
          prmP006G4 = new Object[] {
          new ParDef("@lV101Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV101Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV102Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV102Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@AV103Contabilidad_plancuentaswwds_5_cuemov1",GXType.Int16,1,0) ,
          new ParDef("@lV107Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV107Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV108Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV108Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@AV109Contabilidad_plancuentaswwds_11_cuemov2",GXType.Int16,1,0) ,
          new ParDef("@lV113Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV113Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV114Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV114Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV115Contabilidad_plancuentaswwds_17_cuemov3",GXType.Int16,1,0) ,
          new ParDef("@lV116Contabilidad_plancuentaswwds_18_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV118Contabilidad_plancuentaswwds_20_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe",GXType.NChar,15,0) ,
          new ParDef("@AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel",GXType.NChar,15,0) ,
          new ParDef("@lV125Contabilidad_plancuentaswwds_27_tfcuegashaber",GXType.NChar,15,0) ,
          new ParDef("@AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel",GXType.NChar,15,0)
          };
          Object[] prmP006G5;
          prmP006G5 = new Object[] {
          new ParDef("@lV101Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV101Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV102Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV102Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@AV103Contabilidad_plancuentaswwds_5_cuemov1",GXType.Int16,1,0) ,
          new ParDef("@lV107Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV107Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV108Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV108Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@AV109Contabilidad_plancuentaswwds_11_cuemov2",GXType.Int16,1,0) ,
          new ParDef("@lV113Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV113Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV114Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV114Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV115Contabilidad_plancuentaswwds_17_cuemov3",GXType.Int16,1,0) ,
          new ParDef("@lV116Contabilidad_plancuentaswwds_18_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV117Contabilidad_plancuentaswwds_19_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV118Contabilidad_plancuentaswwds_20_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV119Contabilidad_plancuentaswwds_21_tfcuedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV123Contabilidad_plancuentaswwds_25_tfcuegasdebe",GXType.NChar,15,0) ,
          new ParDef("@AV124Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel",GXType.NChar,15,0) ,
          new ParDef("@lV125Contabilidad_plancuentaswwds_27_tfcuegashaber",GXType.NChar,15,0) ,
          new ParDef("@AV126Contabilidad_plancuentaswwds_28_tfcuegashaber_sel",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006G4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006G5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 100);
                ((string[]) buf[9])[0] = rslt.getString(8, 15);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((short[]) buf[8])[0] = rslt.getShort(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 15);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 100);
                ((string[]) buf[9])[0] = rslt.getString(8, 15);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 100);
                ((string[]) buf[9])[0] = rslt.getString(8, 15);
                return;
       }
    }

 }

}
